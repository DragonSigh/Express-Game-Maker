//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using GenericUndoRedo;
using EGMGame.Library;
using System.IO;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using EGMGame.Controls.UI;
using System.Collections;

namespace EGMGame.Docking.Editors
{
    public partial class SourceEditor : DockContent, IHistory, IEditor
    {
        bool allowChange = true;

        TreeNode clipboard;
        Dictionary<string, SourceControl> sourceControls = new Dictionary<string, SourceControl>();

        public SourceEditor()
        {
            InitializeComponent();
            explorerList.TreeViewNodeSorter = new SourceNodeSorter();

            allowChange = false;
            allowChange = true;
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;


        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void SourceEditor_Activated(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.SelectedHistory = new UndoRedoHistory<IHistory>(this);
        }

        /// <summary>
        /// Refresh Directory
        /// </summary>
        public void RefreshProjectDirectory()
        {
            try
            {
                explorerList.Nodes.Clear();
                // If Project Exists
                if (Global.Project != null)
                {
                    FindFiles(null, null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x001");
            }
        }

        private void FindFiles(DirectoryInfo dir, TreeNode parent)
        {
            TreeNode node;
            SourceFile material;
            if (dir == null)
            {
                dir = new DirectoryInfo(Path.Combine(Global.Project.Location, "Source"));

                parent = new TreeNode("Source");
                parent.Tag = new SourceNode(dir.FullName, true, null);
                parent.ImageIndex = 0;
                parent.SelectedImageIndex = 1;
                explorerList.Nodes.Add(parent);

                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    node = new TreeNode(d.Name);
                    node.Tag = new SourceNode(d.FullName, true, null);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    parent.Nodes.Add(node);
                    FindFiles(d, node);
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    if (IsSource(file))
                    {
                        material = GetSourceData(file);
                        if (material != null)
                        {
                            node = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                            node.Tag = new SourceNode(file.FullName, false, material);
                            node.ImageIndex = 9;
                            node.SelectedImageIndex = node.ImageIndex;
                            parent.Nodes.Add(node);
                        }
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    node = new TreeNode(d.Name);
                    node.Tag = new SourceNode(d.FullName, true, null);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    parent.Nodes.Add(node);
                    FindFiles(d, node);
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    if (IsSource(file))
                    {
                        material = GetSourceData(file);
                        if (material != null)
                        {
                            node = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                            node.Tag = new SourceNode(file.FullName, false, material);
                            node.ImageIndex = 9;
                            node.SelectedImageIndex = node.ImageIndex;
                            parent.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private SourceFile GetSourceData(FileInfo file)
        {
            foreach (SourceFile data in Global.Project.SourceFiles)
            {
                if (Global.Project.Location + data.Path == file.FullName)
                {
                    return data;
                }
            }

            // Material Doesn't Exist
            return null;
        }

        private bool IsSource(FileInfo file)
        {
            return (file.Extension == ".cs");
        }
        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
        }
        #endregion

        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(ComboData obj)
        {
            allowChange = false;

            allowChange = true;
        }


        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        #region IEditor Members

        void IEditor.SetupList()
        {
            throw new NotImplementedException();
        }

        #endregion

        internal void ResetProject()
        {
            RefreshProjectDirectory();
        }

        internal void SetProject()
        {
            RefreshProjectDirectory();
        }

        private void explorerList_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void explorerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!((SourceNode)explorerList.SelectedNode.Tag).IsFolder)
            {
                if (sourceControls.ContainsKey(((SourceNode)explorerList.SelectedNode.Tag).Path.ToLower()))
                {
                    tabControl.SelectedTab = ((TabPage)sourceControls[((SourceNode)explorerList.SelectedNode.Tag).Path.ToLower()].Parent);
                }
                else
                {
                    StreamReader stream = File.OpenText(((SourceNode)explorerList.SelectedNode.Tag).Path);
                    AddNewTab(stream.ReadToEnd(), ((SourceNode)explorerList.SelectedNode.Tag).Path, Path.GetFileName(((SourceNode)explorerList.SelectedNode.Tag).Path));
                    stream.Close();
                }
            }
        }
        /// <summary>
        /// Add New tab
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        private void AddNewTab(string source, string path, string name)
        {
            SourceControl c = new SourceControl();
            c.Setup(source, path, name);
            TabPage page = new TabPage(name);
            page.Controls.Add(c);
            page.Tag = path.ToLower();
            c.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(page);
            sourceControls[path.ToLower()] = c;
            tabControl.SelectedTab = page;

            timerError_Tick(timerError, EventArgs.Empty);
        }

        #region List
        private void explorerList_AfterExpand(object sender, TreeViewEventArgs e)
        {
            ((SourceNode)e.Node.Tag).Expand = true;
        }

        private void explorerList_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            ((SourceNode)e.Node.Tag).Expand = false;
        }

        private void explorerList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != explorerList.Nodes[0])
            {
                if (string.IsNullOrEmpty(e.Label))
                    e.CancelEdit = true;
                else
                {
                    SourceNode mNode = (SourceNode)e.Node.Tag;

                    if (mNode.IsFolder)
                    {
                        string oldPath = mNode.Path;
                        DirectoryInfo dir = new DirectoryInfo(oldPath);
                        string newPath = Path.Combine(dir.Parent.FullName, e.Label);
                        if (!Directory.Exists(newPath))
                        {
                            try
                            {
                                dir.MoveTo(newPath);


                                e.Node.Text = e.Label;
                                mNode.Path = newPath;
                                SourceNode cNode;
                                string file;
                                foreach (TreeNode node in e.Node.Nodes)
                                {
                                    cNode = (SourceNode)node.Tag;
                                    string newP = cNode.Path.Replace(oldPath, newPath);
                                    // Change Path if its open
                                    if (sourceControls.ContainsKey(cNode.Path.ToLower()))
                                    {
                                        sourceControls[newP.ToLower()] = sourceControls[cNode.Path.ToLower()];
                                        sourceControls.Remove(cNode.Path.ToLower());
                                        sourceControls[newP.ToLower()]._Path = newP;
                                        sourceControls[newP.ToLower()]._Name = Path.GetFileName(newP);
                                        ((TabPage)sourceControls[newP.ToLower()].Parent).Text = sourceControls[newP.ToLower()]._Name + (sourceControls[newP.ToLower()].NeedSave ? "*" : "");

                                    }
                                    cNode.Path = cNode.Path.Replace(oldPath, newPath);
                                    node.SelectedImageIndex = 1;
                                    if (!cNode.IsFolder)
                                    {
                                        cNode.Data.Path = cNode.Path.Replace(Global.Project.Location, "");
                                        node.ImageIndex = 9;
                                        node.SelectedImageIndex = node.ImageIndex;
                                    }
                                    else if (cNode.IsFolder)
                                        RenameChildFileFolders(node, oldPath, newPath);
                                }

                                // Save Source
                                Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.CancelEdit = true;
                            }
                        }
                    }
                    else
                    {
                        FileInfo file = new FileInfo(mNode.Path);
                        string ext = file.Extension;
                        try
                        {
                            string newPath = Path.Combine(file.Directory.FullName, e.Label + ext);
                            string oldPath = mNode.Path;

                            file.MoveTo(newPath);

                            if (sourceControls.ContainsKey(oldPath.ToLower()))
                            {
                                sourceControls[newPath.ToLower()] = sourceControls[oldPath.ToLower()];
                                sourceControls.Remove(oldPath.ToLower());
                                sourceControls[newPath.ToLower()]._Path = newPath;
                                sourceControls[newPath.ToLower()]._Name = Path.GetFileName(newPath);
                                ((TabPage)sourceControls[newPath.ToLower()].Parent).Text = sourceControls[newPath.ToLower()]._Name + (sourceControls[newPath.ToLower()].NeedSave ? "*" : "");

                            }
                            mNode.Path = newPath;
                            e.Node.Text = e.Label;
                            mNode.Data.Path = newPath.Replace(Global.Project.Location, "");

                            // Save Source
                            Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.CancelEdit = true;
                        }

                    }
                }
            }
            explorerList.LabelEdit = false;
        }

        private void RenameChildFileFolders(TreeNode Node, string oldPath, string newPath)
        {
            SourceNode cNode;
            string file;
            foreach (TreeNode node in Node.Nodes)
            {
                cNode = (SourceNode)node.Tag;

                // Change Path if its open
                string newP = cNode.Path.Replace(oldPath, newPath);
                if (sourceControls.ContainsKey(cNode.Path.ToLower()))
                {
                    sourceControls[newP.ToLower()] = sourceControls[cNode.Path.ToLower()];
                    sourceControls.Remove(cNode.Path.ToLower());
                    sourceControls[newP.ToLower()]._Path = newP;
                    sourceControls[newP.ToLower()]._Name = Path.GetFileName(newP);
                    ((TabPage)sourceControls[newP.ToLower()].Parent).Text = sourceControls[newP.ToLower()]._Name + (sourceControls[newP.ToLower()].NeedSave ? "*" : "");

                }

                cNode.Path = cNode.Path.Replace(oldPath, newPath);
                node.SelectedImageIndex = 1;
                if (!cNode.IsFolder)
                {
                    cNode.Data.Path = cNode.Path.Replace(Global.Project.Location, "");
                    node.ImageIndex = 9;
                    node.SelectedImageIndex = node.ImageIndex;
                }
                RenameChildFileFolders(node, oldPath, newPath);
            }
        }

        private void explorerList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (explorerList.SelectedNode != explorerList.Nodes[0])
            {
                TreeNode n = (TreeNode)e.Item;
                DoDragDrop(n, DragDropEffects.All);
            }
        }

        private void explorerList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (node == null)
                    node = explorerList.SelectedNode;
                // Get Over Node
                TreeNode overNode = explorerList.GetNodeAt(explorerList.PointToClient(new System.Drawing.Point(e.X, e.Y)));

                if (overNode != node)
                {
                    if (overNode == null)
                        overNode = explorerList.Nodes[0];

                    SourceNode cmNode = (SourceNode)node.Tag;
                    SourceNode omNode = (SourceNode)overNode.Tag;

                    if (!omNode.IsFolder)
                    {
                        overNode = overNode.Parent;
                        omNode = (SourceNode)overNode.Tag;
                    }

                    if (overNode != node.Parent)
                    {
                        if (cmNode.IsFolder)
                        {
                            DirectoryInfo directory = new DirectoryInfo(cmNode.Path);
                            string newPath = directory.FullName.Replace(directory.Parent.FullName, omNode.Path);
                            string oldPath = cmNode.Path;
                            try
                            {
                                directory.MoveTo(newPath);
                                node.Remove();
                                overNode.Nodes.Insert(0, node);
                                RenameChildFileFolders(node, cmNode.Path, newPath);
                                cmNode.Path = newPath;


                                // Save Source
                                Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);

                                explorerList.Sort();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            FileInfo file = new FileInfo(cmNode.Path);
                            string newPath = file.FullName.Replace(file.DirectoryName, omNode.Path);
                            try
                            {
                                file.MoveTo(newPath);
                                string oldPath = cmNode.Path;

                                if (sourceControls.ContainsKey(oldPath.ToLower()))
                                {
                                    sourceControls[newPath.ToLower()] = sourceControls[oldPath.ToLower()];
                                    sourceControls.Remove(oldPath.ToLower());
                                    sourceControls[newPath.ToLower()]._Path = newPath;
                                    sourceControls[newPath.ToLower()]._Name = Path.GetFileName(newPath);
                                    ((TabPage)sourceControls[newPath.ToLower()].Parent).Text = sourceControls[newPath.ToLower()]._Name + (sourceControls[newPath.ToLower()].NeedSave ? "*" : "");

                                }

                                node.Remove();
                                overNode.Nodes.Add(node);
                                cmNode.Path = newPath;
                                cmNode.Data.Path = newPath.Replace(Global.Project.Location, "");


                                // Save Source
                                Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);

                                explorerList.Sort();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void explorerList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (node == explorerList.SelectedNode)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void explorerList_MouseDown(object sender, MouseEventArgs e)
        {
            if (explorerList.GetNodeAt(e.Location) != null)
                explorerList.SelectedNode = explorerList.GetNodeAt(e.Location);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string dir;

            if (explorerList.SelectedNode == null) explorerList.SelectedNode = explorerList.Nodes[0];

            TreeNode parentNode = explorerList.SelectedNode;
            SourceNode mNode = (SourceNode)explorerList.SelectedNode.Tag;

            if (mNode.IsFolder)
                dir = mNode.Path;
            else
            {
                mNode = (SourceNode)explorerList.SelectedNode.Parent.Tag;
                dir = mNode.Path;
                parentNode = explorerList.SelectedNode.Parent;
            }

            FileInfo directory = new FileInfo(dir);
            string name = "New File.cs";
            int i = 1;
            while (File.Exists(Path.Combine(dir, name)))
            {
                name = "New File (" + i.ToString() + ").cs";
                i++;
            }
            SourceFile data = new SourceFile(Path.Combine(dir, name));
            data.Path = data.Path.Replace(Global.Project.Location, "");
            File.Create(Path.Combine(dir, name)).Close();
            directory = new FileInfo(Path.Combine(dir, name));
            TreeNode node = new TreeNode(directory.Name);
            node.Tag = new SourceNode(directory.FullName, false, data);
            node.ImageIndex = 9;
            node.SelectedImageIndex = node.ImageIndex;
            parentNode.Nodes.Insert(0, node);

            Global.Project.SourceFiles.Add(data);
            explorerList.Sort();

            Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);

        }
        private string GetFileName(string name, string extension, string dir)
        {
            int i = 1;
            string newName = name;
            string ext = extension;

            bool found = false;
            string exten = "";
            while (true)
            {
                if (!found)
                {
                    newName = newName + exten;
                    break;
                }
                else
                    exten = "(" + i.ToString() + ")";
                found = false;
                i++;
            }

            i = 1;
            name = newName;
            while (Global.NameExists(newName, Global.Project.SourceFiles))
            {
                newName = name + "(" + i.ToString() + ")";
                i++;
            }
            return newName;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Source File(*.cs)|*.cs";
            openFileDialog.FilterIndex = 5;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string dir;

                    if (explorerList.SelectedNode == null) explorerList.SelectedNode = explorerList.Nodes[0];

                    TreeNode parentNode = explorerList.SelectedNode;
                    SourceNode mNode = (SourceNode)explorerList.SelectedNode.Tag;

                    if (mNode.IsFolder)
                        dir = mNode.Path;
                    else
                    {
                        mNode = (SourceNode)explorerList.SelectedNode.Parent.Tag;
                        dir = mNode.Path;
                        parentNode = explorerList.SelectedNode.Parent;
                    }

                    if (openFileDialog.FileName != null)
                    {
                        FileInfo file;
                        FileStream stream;
                        foreach (string path in openFileDialog.FileNames)
                        {
                            file = new FileInfo(path);
                            using (stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                            {
                                string name = file.Name.Replace(file.Extension, "");

                                name = GetFileName(name, file.Extension, dir);

                                if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                                    == FileAttributes.ReadOnly)
                                    File.SetAttributes(file.FullName, FileAttributes.Normal);

                                try
                                {
                                    if (!File.Exists(Path.Combine(dir, name + file.Extension)))
                                        file.CopyTo(Path.Combine(dir, name + file.Extension), true);
                                }
                                catch (System.IO.IOException iox)
                                {
                                }

                                file = new FileInfo(Path.Combine(dir, name + file.Extension));
                                SourceFile m = new SourceFile();
                                m.Path = file.FullName.Replace(Global.Project.Location, "");

                                Global.Project.SourceFiles.Add(m);

                                //ImportFile(file);

                                TreeNode materialNode = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                                materialNode.Tag = new SourceNode(file.FullName, false, m);
                                materialNode.ImageIndex = 9;
                                materialNode.SelectedImageIndex = materialNode.ImageIndex;
                                parentNode.Nodes.Add(materialNode);

                                explorerList.SelectedNode = materialNode;
                            }
                        }
                        // Save Source
                        Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);

                        explorerList.Sort();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex, "s45x001");
                    MessageBox.Show("There was an error trying to import the resources. Please try again.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool save = false;
            ArrayList list = new ArrayList(explorerList.SelectedNodes);
            if (list.Count > 0 && MessageBox.Show("Delete the selected?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (TreeNode _node in list)
                {
                    if (_node != null && _node != explorerList.Nodes[0])
                    {
                        SourceNode mNode = (SourceNode)_node.Tag;
                        SourceFile data = mNode.Data;
                        if (mNode.IsFolder)
                        {
                            DeleteFolder(_node);
                            if (Directory.Exists(mNode.Path))
                                Directory.Delete(mNode.Path, true);
                            _node.Remove();

                            save = true;
                        }
                        else
                        {
                            try
                            {
                                if (File.Exists(Global.Project.Location + @"\" + data.Path))
                                    File.Delete(Global.Project.Location + @"\" + data.Path);

                            }
                            catch
                            {
                            }
                            Close(Global.Project.Location + data.Path);
                            Global.Project.SourceFiles.Remove(data);
                            _node.Remove();
                            save = true;
                        }
                    }
                }
                // Save Materials
                if (save)
                    Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);
            }
        }
        private void DeleteFolder(TreeNode parentNode)
        {
            SourceNode cNode;
            SourceFile data;
            foreach (TreeNode node in parentNode.Nodes)
            {
                cNode = (SourceNode)node.Tag;

                if (cNode.IsFolder)
                {
                    DeleteFolder(node);
                    if (Directory.Exists(cNode.Path))
                        Directory.Delete(cNode.Path, true);
                }
                else
                {
                    data = cNode.Data;
                    try
                    {
                        if (File.Exists(Global.Project.Location + @"\" + data.Path))
                            File.Delete(Global.Project.Location + @"\" + data.Path);
                    }
                    catch
                    {
                    }
                    Close(Global.Project.Location + data.Path);
                    Global.Project.SourceFiles.Remove(data);
                    node.Remove();
                }
            }
        }
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            string dir;

            if (explorerList.SelectedNode == null) explorerList.SelectedNode = explorerList.Nodes[0];

            TreeNode parentNode = explorerList.SelectedNode;
            SourceNode mNode = (SourceNode)explorerList.SelectedNode.Tag;

            if (mNode.IsFolder)
                dir = mNode.Path;
            else
            {
                mNode = (SourceNode)explorerList.SelectedNode.Parent.Tag;
                dir = mNode.Path;
                parentNode = explorerList.SelectedNode.Parent;
            }

            DirectoryInfo directory = new DirectoryInfo(dir);
            string name = "New Folder";
            int i = 1;
            while (Directory.Exists(Path.Combine(dir, name)))
            {
                name = "New Folder (" + i.ToString() + ")";
                i++;
            }

            directory = Directory.CreateDirectory(Path.Combine(dir, name));
            TreeNode node = new TreeNode(directory.Name);
            node.Tag = new SourceNode(directory.FullName, true, null);
            node.ImageIndex = 0;
            node.SelectedImageIndex = 1;
            parentNode.Nodes.Insert(0, node);

            explorerList.Sort();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (explorerList.SelectedNode != null && explorerList.SelectedNode != explorerList.Nodes[0])
            {
                explorerList.LabelEdit = true;
                explorerList.SelectedNode.BeginEdit();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (explorerList.SelectedNode != explorerList.Nodes[0])
            {

                if (clipboard != null)
                {
                    if (clipboard.Tag is SourceNode)
                        clipboard.ForeColor = Color.Black;
                }

                clipboard = explorerList.SelectedNode;
                explorerList.SelectedNode.ForeColor = Color.Gray;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clipboard != null)
            {
                TreeNode node = clipboard;
                if (node.Tag is SourceNode)
                {
                    node.ForeColor = Color.Black;
                    // Get Over Node
                    TreeNode overNode = explorerList.SelectedNode;

                    if (overNode != node)
                    {
                        if (overNode == null)
                            overNode = explorerList.Nodes[0];

                        SourceNode cmNode = (SourceNode)node.Tag;
                        SourceNode omNode = (SourceNode)overNode.Tag;

                        if (!omNode.IsFolder)
                        {
                            overNode = overNode.Parent;
                            omNode = (SourceNode)overNode.Tag;
                        }

                        if (overNode != node.Parent)
                        {
                            if (cmNode.IsFolder)
                            {
                                DirectoryInfo directory = new DirectoryInfo(cmNode.Path);
                                string newPath = directory.FullName.Replace(directory.Parent.FullName, omNode.Path);
                                string oldPath = cmNode.Path;
                                try
                                {
                                    if (!Directory.Exists(newPath))
                                        directory.MoveTo(newPath);
                                    else
                                    {
                                        SourceNode tempMNode;
                                        foreach (TreeNode temp in overNode.Nodes)
                                        {
                                            tempMNode = (SourceNode)temp.Tag;

                                            if (tempMNode.IsFolder && tempMNode.Path == newPath)
                                            {
                                                MessageBox.Show("A folder with this name already exists!", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }
                                    }
                                    node.Remove();
                                    node.SelectedImageIndex = 1;
                                    overNode.Nodes.Insert(0, node);
                                    RenameChildFileFolders(node, cmNode.Path, newPath);
                                    cmNode.Path = newPath;

                                    clipboard = null;

                                    Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                FileInfo file = new FileInfo(cmNode.Path);
                                string newPath = file.FullName.Replace(file.DirectoryName, omNode.Path);
                                string oldPath = cmNode.Path;
                                try
                                {
                                    if (!File.Exists(newPath))
                                        file.MoveTo(newPath);

                                    node.Remove();
                                    overNode.Nodes.Add(node);
                                    cmNode.Path = newPath;
                                    cmNode.Data.Path = newPath.Replace(Global.Project.Location, "");
                                    node.ImageIndex = 9;
                                    node.SelectedImageIndex = node.ImageIndex;

                                    if (sourceControls.ContainsKey(oldPath.ToLower()))
                                    {
                                        sourceControls[newPath.ToLower()] = sourceControls[oldPath.ToLower()];
                                        sourceControls.Remove(oldPath.ToLower());
                                        sourceControls[newPath.ToLower()]._Path = newPath;
                                        sourceControls[newPath.ToLower()]._Name = Path.GetFileName(newPath);
                                        ((TabPage)sourceControls[newPath.ToLower()].Parent).Text = sourceControls[newPath.ToLower()]._Name + (sourceControls[newPath.ToLower()].NeedSave ? "*" : "");

                                    }

                                    Marshal.SaveObj(Global.Project.SourceFiles, Global.Project.Location + Global.Project.DataPath + Extensions.Source, Global.Project.Location + Global.Project.DataPath);

                                    clipboard = null;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Error Checker
        private void bgwErrorChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> provider_options = new Dictionary<string, string>

                         {

                             {"CompilerVersion","v3.5"}

                         };
            CodeDomProvider provider = new CSharpCodeProvider(provider_options);

            CompilerParameters cp = new CompilerParameters();

            cp.GenerateInMemory = true;
            // Add an assembly reference.
            foreach (AssemblyName assemblyName in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                if (assemblyName.Name == "Microsoft.Xna.Framework.Game")
                {
                    string path = Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.Game)).Location;

                    cp.ReferencedAssemblies.Add(path);

                }
                else if (assemblyName.Name == "Microsoft.Xna.Framework.Content.Pipeline")
                {
                    string path = Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.Content.Pipeline.ContentBuildLogger)).Location;

                    cp.ReferencedAssemblies.Add(path);
                }
                else if (assemblyName.Name == "Microsoft.Xna.Framework")
                {
                    string path = Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.BoundingBox)).Location;

                    cp.ReferencedAssemblies.Add(path);
                }

            }
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Security.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Data.dll");
            cp.ReferencedAssemblies.Add("System.Xml.dll");
            cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            // Set the level at which the compiler 
            // should start displaying warnings.
            cp.WarningLevel = 4;

            // Set compiler argument to optimize output.
            cp.CompilerOptions += @" /platform:x86";
            cp.CompilerOptions += @" /define:DEBUG";
            cp.CompilerOptions += @" /define:WINDOWS";
            cp.CompilerOptions += @" /define:XNA";
            // Invoke compilation.
            string[] files = new string[Global.Project.SourceFiles.Count];
            int i = 0;
            foreach (SourceFile file in Global.Project.SourceFiles)
            {
                if (sourceControls.ContainsKey(Global.Project.Location.ToLower() + file.Path.ToLower()))
                {
                    files[i] = sourceControls[Global.Project.Location.ToLower() + file.Path.ToLower()].SaveTemp();
                }
                else
                {
                    files[i] = Global.Project.Location + @"\" + file.Path;
                }
                i++;
            }
            try
            {
                CompilerResults cr = provider.CompileAssemblyFromFile(
                                            cp, files);

                if (cr.Errors.Count > 0)
                {
                    // Display compilation errors.
                    StringBuilder sb = new StringBuilder();

                    for (int j = 0; j < cr.Errors.Count && j < 5; j++)
                    {
                        sb.Append(cr.Errors[j].ToString());
                        sb.Append("\n");

                    }
                    MainForm.errorExplorer.SetSourceError(sb.ToString());
                }
                else
                {
                    MainForm.errorExplorer.ClearSourceError();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timerError_Tick(object sender, EventArgs e)
        {
            //if (!bgwErrorChecker.IsBusy)
            //    bgwErrorChecker.RunWorkerAsync();
        }

        private void btnCheckForErrors_Click(object sender, EventArgs e)
        {
            if (!bgwErrorChecker.IsBusy)
                bgwErrorChecker.RunWorkerAsync();
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null) return;
            if (sourceControls[(string)tabControl.SelectedTab.Tag].NeedSave)
            {
                switch (MessageBox.Show("Save file? You will lose any unsaved work if you do not save.", "Express Game Maker", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sourceControls[(string)tabControl.SelectedTab.Tag].Save();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                }
            }
            // Close Current Tab
            sourceControls.Remove((string)tabControl.SelectedTab.Tag);
            tabControl.TabPages.Remove(tabControl.SelectedTab);
        }

        void Close(string path)
        {
            if (sourceControls.ContainsKey(path.ToLower()))
            {
                // Close Current Tab
                tabControl.TabPages.Remove((TabPage)sourceControls[path.ToLower()].Parent);
                sourceControls.Remove(path.ToLower());
            }
        }

        internal void Open(string path, int line, int col, string desc)
        {
            if (sourceControls.ContainsKey(path.ToLower()))
            {
                tabControl.SelectedTab = ((TabPage)sourceControls[path.ToLower()].Parent);
                sourceControls[path.ToLower()].GoTo(line, col, desc);
            }
            else
            {
                StreamReader stream = File.OpenText(path);
                AddNewTab(stream.ReadToEnd(), path, Path.GetFileName(path));
                stream.Close();
                sourceControls[path.ToLower()].GoTo(line, col, desc);
            }
        }

        /// <summary>
        /// Set Error Warnings
        /// </summary>
        /// <param name="path"></param>
        /// <param name="lineNumber"></param>
        /// <param name="lineCol"></param>
        /// <param name="type"></param>
        internal void SetErrorWarning(string path, string lineNumber, string lineCol, string type)
        {
            if (sourceControls.ContainsKey(path.ToLower()))
            {
                sourceControls[path.ToLower()].AddErrorWarning(int.Parse(lineNumber), int.Parse(lineCol), type);
            }
        }
        /// <summary>
        /// Clear Error Warnings
        /// </summary>
        internal void ClearErrorWarnings()
        {
            foreach (SourceControl c in sourceControls.Values)
            {
                c.ClearErrorWarnings();
            }
        }

        internal void Save()
        {
            foreach (SourceControl c in sourceControls.Values)
            {
                c.Save();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            explorerList_MouseDoubleClick(null, null);
        }

    }
    [Serializable]
    public class SourceNode
    {
        public bool IsFolder;
        public SourceFile Data;
        public string Path;
        public bool Expand;

        public SourceNode(string path, bool folder, SourceFile data)
        {
            Path = path;
            IsFolder = folder;
            Data = data;
        }
    }


    // Create a node sorter that implements the IComparer interface.
    public class SourceNodeSorter : IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            SourceNode mnodex = ((SourceNode)tx.Tag);
            SourceNode mnodey = ((SourceNode)ty.Tag);

            // Compare the length of the strings, returning the difference.
            if (mnodex.IsFolder && !mnodey.IsFolder)
                return 0;
            if (!mnodex.IsFolder && mnodey.IsFolder)
                return 1;
            // If they are the same length, call Compare.
            return string.Compare(tx.Text, ty.Text);
        }
    }

}
