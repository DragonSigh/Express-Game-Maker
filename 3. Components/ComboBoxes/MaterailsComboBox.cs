using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.Collections;
using System.IO;
using EGMGame.Docking.Explorers;

namespace EGMGame.Controls.Game
{
    public partial class MaterialsComboBox : ComboBox
    {
        static int lastSelected = 0;

        List<MaterialData> materials = new List<MaterialData>();

        MaterialDataType materialType = MaterialDataType.All;
        /// <summary>
        /// Initialize
        /// </summary>
        public MaterialsComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMaterials.Add(this);

            Setup();
        }
        public MaterialsComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMaterials.Add(this);

            Setup();
        }

        private void Setup()
        {

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            treeView = new TreeView();

            this.AllowDrop = true;

            treeView.BorderStyle = BorderStyle.None;

            treeView.MouseDoubleClick += new MouseEventHandler(treeView_MouseClick);

            treeViewHost = new ToolStripControlHost(treeView);

            // create drop down and add it


            dropDown = new ToolStripDropDown();
            dropDown.Items.Add(treeViewHost);

            treeView.Width = 200;
            treeView.ItemHeight = 20;

            treeView.AfterExpand += new TreeViewEventHandler(treeView_AfterExpand);
            treeView.AfterCollapse += new TreeViewEventHandler(treeView_AfterCollapse);

            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);

            imageList = new ImageList();
            treeView.ImageList = imageList;
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.ColorDepth = ColorDepth.Depth32Bit;
            this.imageList.Images.Add("folder.png", global::EGMGame.Properties.Resources.folder);
            this.imageList.Images.Add("folder-open.png", global::EGMGame.Properties.Resources.folder_open);
            this.imageList.Images.Add("document.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document-image.png", global::EGMGame.Properties.Resources.document_image);
            this.imageList.Images.Add("document-text.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("folder-zipper.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document_gear.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document-music.png", global::EGMGame.Properties.Resources.document_music);
            this.imageList.Images.Add("document-film.png", global::EGMGame.Properties.Resources.document_film);
            this.imageList.Images.Add("document-c-sharp2.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document-xml.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document-pdf-text.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("application-sidebar.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document-code.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document-table.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("document_edit.png", global::EGMGame.Properties.Resources.document);
            this.imageList.Images.Add("exclamation.png", global::EGMGame.Properties.Resources.exclamation);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            //e.DrawBackground();
            if (lastData != null)
                if (this.Enabled)
                    e.Graphics.DrawString(lastData.Name, e.Font, System.Drawing.Brushes.Black, new System.Drawing.PointF(1, 3));
                else
                    e.Graphics.DrawString(lastData.Name, e.Font, System.Drawing.Brushes.Gray, new System.Drawing.PointF(1, 3));
        }

        public void RefreshList(bool memorize)
        {
            RefreshList(memorize, materialType);
        }

        public void RefreshList(bool memorize, MaterialDataType type)
        {
            int id = -1;
            Nodes.Clear();
            if (memorize)
                id = Data().ID;
            materialType = type;
            TreeNode parent = new TreeNode("(none)");
            MaterialData none = new MaterialData();
            none.Name = "(none)";
            none.ID = -1;
            parent.Tag = new MaterialNode("", false, none);
            parent.ImageIndex = 4;
            parent.SelectedImageIndex = 4;
            this.Nodes.Add(parent);
            FindFiles(null, null, type);
            Select(id);
        }

        internal static void RefreshList(MaterialDataType type)
        {
            //tempList.Clear();
            //TreeNode parent = new TreeNode("(none)");
            //MaterialData none = new MaterialData();
            //none.Name = "(none)";
            //none.ID = -1;
            //parent.Tag = new MaterialNode("", false, none);
            //parent.ImageIndex = 4;
            //parent.SelectedImageIndex = 4;
            //tempList.Add(parent);
            //FindFiles(null, null, type);
        }


        internal void FindFiles(DirectoryInfo dir, TreeNode parent, MaterialDataType type)
        {
            TreeNode node;
            MaterialData material;
            if (dir == null)
            {
                dir = new DirectoryInfo(Path.Combine(Global.Project.Location, "Materials"));

                parent = new TreeNode("Materials");
                parent.Tag = new MaterialNode(dir.FullName, true, null);
                parent.ImageIndex = 0;
                parent.SelectedImageIndex = 1;
                this.Nodes.Add(parent);

                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    if (d.Name != "bin" && d.Name != "obj")
                    {
                        node = new TreeNode(d.Name);
                        node.Tag = new MaterialNode(d.FullName, true, null);
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 1;
                        parent.Nodes.Add(node);
                        FindFiles(d, node, type);
                    }
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    if (IsMaterial(file))
                    {
                        material = GetMaterialData(file);
                        if (material != null && (material.DataType == type || material.DataType == MaterialDataType.All))
                        {
                            node = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                            node.Tag = new MaterialNode(file.FullName, false, material);
                            node.ImageIndex = GetImgIndexFrom(file.Extension);
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
                    node.Tag = new MaterialNode(d.FullName, true, null);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    parent.Nodes.Add(node);
                    FindFiles(d, node, type);
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    if (IsMaterial(file))
                    {
                        material = GetMaterialData(file);
                        if (material != null && (material.DataType == type || material.DataType == MaterialDataType.All))
                        {
                            node = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                            node.Tag = new MaterialNode(file.FullName, false, material);
                            node.ImageIndex = GetImgIndexFrom(file.Extension);
                            node.SelectedImageIndex = node.ImageIndex;
                            parent.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        internal static int GetImgIndexFrom(string ext)
        {
            switch (ext.ToLower())
            {
                case ".png":
                    return 3;
                case ".jpg":
                    return 3;
                case ".jpeg":
                    return 3;
                case ".bmp":
                    return 3;
                case ".txt":
                    return 4;
                case ".rar":
                    return 5;
                case ".zip":
                    return 5;
                case ".ini":
                    return 6;
                case ".mp3":
                    return 7;
                case ".ogg":
                    return 7;
                case ".wav":
                    return 7;
                case ".wma":
                    return 7;
                case ".wmv":
                    return 8;
                case ".mpg":
                    return 8;
                case ".mpeg":
                    return 8;
                case ".cs":
                    return 9;
                case ".fx":
                    return 10;
                case ".pdf":
                    return 11;
                case ".exe":
                    return 12;
                case ".bmpfont":
                    return 15;
                case ".tga":
                    return 15;
            }
            return 2;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (((MaterialNode)this.SelectedNode.Tag).Data.ID == -1)
                Select(lastSelected);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            lastSelected = Data().ID;
        }
        /// <summary>
        /// Check if the file is a material
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        internal static bool IsMaterial(FileInfo file)
        {
            switch (file.Extension.ToLower())
            {
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".bmp":
                    return true;
                case ".mp3":
                    return true;
                case ".wav":
                    return true;
                case ".wma":
                    return true;
                case ".wmv":
                    return true;
                case ".bmpfont":
                    return true;
                case ".tga":
                    return true;
                case ".fx":
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Get Material Data
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static MaterialData GetMaterialData(FileInfo file)
        {
            foreach (MaterialData data in GameData.Materials.Values)
            {
                if (Path.Combine(Global.Project.Location, data.FileName) == file.FullName)
                {
                    return data;
                }
            }

            // Material Doesn't Exist
            return null;
        }
        /// <summary>
        /// Get Selected Event
        /// </summary>
        /// <returns></returns>
        public MaterialData Data()
        {
            if (this.SelectedNode != null && this.SelectedNode.Tag != null && !((MaterialNode)this.SelectedNode.Tag).IsFolder)
                return ((MaterialNode)this.SelectedNode.Tag).Data;
            else
            {
                MaterialData dd = new MaterialData();
                dd.ID = -10;
                dd.Name = "{No Material}";
                return dd;
            }
        }

        public void Select(int id)
        {
            if (this.Nodes != null)
            {
                MaterialNode mNode;
                for (int i = 0; i < this.Nodes.Count; i++)
                {
                    mNode = (MaterialNode)this.Nodes[i].Tag;

                    if (!mNode.IsFolder && mNode.Data.ID == id)
                    {
                        this.SelectedNode = this.Nodes[i];
                        return;
                    }
                    else
                    {
                        if (Select(id, Nodes[i]))
                            return;
                    }
                }
            }
        }

        private bool Select(int id, TreeNode node)
        {
            MaterialNode mNode;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                mNode = (MaterialNode)node.Nodes[i].Tag;

                if (!mNode.IsFolder && mNode.Data.ID == id)
                {
                    this.SelectedNode = node.Nodes[i];
                    return true;
                }
                else
                {
                    if (Select(id, node.Nodes[i]))
                        return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            Global.CbMaterials.Remove(this);

            base.Dispose(disposing);
        }
        /// <summary>
        /// Materials
        /// </summary>
        /// <param name="p"></param>
        internal void Refresh(int p, MaterialDataType type)
        {
            if (type == materialType || type == MaterialDataType.All)
            {
                RefreshList(false, materialType);
                Select(p);
            }
        }

        internal void Refresh(int p, List<MaterialDataType> types)
        {
            if (types.Contains(materialType) || materialType == MaterialDataType.All)
            {
                RefreshList(false, materialType);
                Select(p);
            }
        }

        List<TreeNode> nodeList = new List<TreeNode>();


        ToolStripControlHost treeViewHost;
        ToolStripDropDown dropDown;
        TreeView treeView;
        ImageList imageList;
        IGameData lastData;

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            treeView.Focus();
        }

        internal bool AllowChange = true;

        void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Tag != null && !((MaterialNode)treeView.SelectedNode.Tag).IsFolder)
            {
                lastData = ((MaterialNode)treeView.SelectedNode.Tag).Data;
            }
        }

        void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int height = 0;

            foreach (TreeNode node in Nodes)
            {
                height += node.Bounds.Height;

                if (node.IsExpanded)
                {
                    foreach (TreeNode cNode in node.Nodes)
                    {
                        height += cNode.Bounds.Height;
                    }
                }
            }
            treeView.Height = Math.Min(height, 200);
        }

        void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int height = 0;

            foreach (TreeNode node in Nodes)
            {
                height += node.Bounds.Height;

                if (node.IsExpanded)
                {
                    foreach (TreeNode cNode in node.Nodes)
                    {
                        height += cNode.Bounds.Height;
                    }
                }
            }
            treeView.Height = Math.Min(height, 200);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            treeView.Width = 200;
        }

        private void treeView_MouseClick(object sender, MouseEventArgs e)
        {

            OnSelectedIndexChanged(EventArgs.Empty);
            dropDown.Hide();
        }

        public TreeView TreeView
        {
            get
            {
                return treeView;
            }
        }


        public TreeNodeCollection Nodes
        {
            get
            {
                if (TreeView != null && !treeView.IsDisposed)
                    return TreeView.Nodes;
                return null;
            }
        }
        public TreeNode SelectedNode
        {
            get
            {
                if (TreeView != null)
                    return TreeView.SelectedNode;

                return null;
            }
            set
            {
                TreeView.SelectedNode = value;
                treeView_AfterSelect(this, null);
                this.Invalidate();
            }
        }

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                treeViewHost.Width = DropDownWidth;
                treeViewHost.Height = DropDownHeight;
                dropDown.Show(this, 0, Height);
                int height = 0;

                foreach (TreeNode node in Nodes)
                {
                    height += node.Bounds.Height;

                    if (node.IsExpanded)
                    {
                        foreach (TreeNode cNode in node.Nodes)
                        {
                            height += cNode.Bounds.Height;
                        }
                    }
                }
                treeView.Height = Math.Min(height, 200);
                this.TreeView.Focus();
            }
        }

        private const int WM_USER = 0x0400,
                          WM_REFLECT = WM_USER + 0x1C00,
                          WM_COMMAND = 0x0111,
                          CBN_DROPDOWN = 7;

        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                {
                    ShowDropDown();
                    return;

                }
            }
            base.WndProc(ref m);
        }

        internal void AddMaterial(string path, MaterialData m, List<MaterialDataType> types)
        {
            if (types.Contains(materialType))
            {
                if (Nodes.Count == 0)
                {
                    RefreshList(false);
                }
                TreeNode parentNode = GetParentNode(null, path);

                TreeNode materialNode = new TreeNode(m.Name);
                materialNode.Tag = new MaterialNode(Path.Combine(Global.Project.Location, m.FileName), false, m);
                materialNode.ImageIndex = GetImgIndexFrom(Path.GetExtension(Path.Combine(Global.Project.Location, m.FileName)));
                materialNode.SelectedImageIndex = materialNode.ImageIndex;
                parentNode.Nodes.Add(materialNode);
                treeView.Sort();
            }
        }

        internal void AddMaterial(string path, MaterialData m, MaterialDataType materialDataType)
        {
            if (materialType == materialDataType)
            {
                if (Nodes.Count == 0)
                {
                    RefreshList(false);
                }
                TreeNode parentNode = GetParentNode(null, path);

                TreeNode materialNode = new TreeNode(m.Name);
                materialNode.Tag = new MaterialNode(Path.Combine(Global.Project.Location, m.FileName), false, m);
                materialNode.ImageIndex = GetImgIndexFrom(Path.GetExtension(Path.Combine(Global.Project.Location, m.FileName)));
                materialNode.SelectedImageIndex = materialNode.ImageIndex;
                parentNode.Nodes.Add(materialNode);
                treeView.Sort();
            }
        }

        internal bool Delete(TreeNode parent, string path)
        {
            TreeNode delete = null;
            if (parent == null)
            {
                foreach (TreeNode node in this.Nodes)
                {
                    if (path == ((MaterialNode)node.Tag).Path)
                    {
                        delete = node;
                        break;
                    }
                    if (Delete(node, path))
                        return true;
                }
            }
            else
            {
                foreach (TreeNode node in parent.Nodes)
                {
                    if (path == ((MaterialNode)node.Tag).Path)
                    {
                        delete = node;
                        break;
                    }
                    if (Delete(node, path))
                        return true;
                }
            }
            if (delete != null)
            {
                delete.Remove();
                return true;
            }
            return false;
        }

        internal bool Delete(TreeNode parent, MaterialData data, MaterialDataType materialDataType)
        {
            if (this.Nodes.Count > 1)
                return DeleteD(this.Nodes[1], data, materialDataType);
            return false;
        }

        internal bool DeleteD(TreeNode parent, MaterialData data, MaterialDataType materialDataType)
        {
            TreeNode delete = null;
            if (materialDataType == materialType)
            {
                ;
                foreach (TreeNode node in parent.Nodes)
                {
                    if (data == ((MaterialNode)node.Tag).Data)
                    {
                        delete = node;
                        break;
                    }
                    if (DeleteD(node, data, materialDataType)) return true;
                }
                if (delete != null)
                {
                    delete.Remove();
                    return true;
                }
            }
            return false;
        }



        internal void AddFolder(DirectoryInfo directory, string pathToAdd)
        {
            TreeNode parentNode = GetParentNode(null, pathToAdd);
            if (parentNode != null)
            {
                TreeNode node = new TreeNode(directory.Name);
                node.Tag = new MaterialNode(directory.FullName, true, null);
                node.ImageIndex = 0;
                node.SelectedImageIndex = 1;
                parentNode.Nodes.Insert(0, node);
                treeView.Sort();
            }
        }

        internal void MoveMaterial(string oldPath, string newPath, string parentPath)
        {
            TreeNode node = GetParentNode(null, oldPath);

            if (node != null)
            {
                TreeNode overNode = GetParentNode(null, parentPath);


                node.Remove();
                overNode.Nodes.Insert(0, node);

                RenameChildFileFolders(node, ((MaterialNode)node.Tag).Path, newPath);

                ((MaterialNode)node.Tag).Path = newPath;
                treeView.Sort();
            }
        }

        private void RenameChildFileFolders(TreeNode Node, string oldPath, string newPath)
        {
            MaterialNode cNode;
            string file;
            foreach (TreeNode node in Node.Nodes)
            {
                cNode = (MaterialNode)node.Tag;
                cNode.Path = cNode.Path.Replace(oldPath, newPath);
                node.SelectedImageIndex = 1;
                if (!cNode.IsFolder)
                {
                    file = Path.Combine(Global.Project.Location, cNode.Data.FileName);
                    node.ImageIndex = GetImgIndexFrom(Path.GetExtension(file));
                    node.SelectedImageIndex = node.ImageIndex;
                }
                RenameChildFileFolders(node, oldPath, newPath);
            }
        }

        internal void RenameMaterial(string oldPath, string newPath)
        {
            TreeNode node = GetParentNode(null, oldPath);


            if (node != null)
            {
                MaterialNode mNode = (MaterialNode)node.Tag;
                if (mNode.IsFolder)
                {
                    node.Text = Path.GetFileNameWithoutExtension(newPath);
                    mNode.Path = newPath;
                    MaterialNode cNode;
                    string file;
                    foreach (TreeNode n in node.Nodes)
                    {
                        cNode = (MaterialNode)n.Tag;
                        cNode.Path = cNode.Path.Replace(oldPath, newPath);
                        n.SelectedImageIndex = 1;
                        if (!cNode.IsFolder)
                        {
                            file = Path.Combine(Global.Project.Location, cNode.Data.FileName);
                            n.ImageIndex = GetImgIndexFrom(Path.GetExtension(file));
                            n.SelectedImageIndex = n.ImageIndex;
                        }
                        else if (cNode.IsFolder)
                            RenameChildFileFolders(n, oldPath, newPath);
                    }
                    treeView.Sort();


                }
                else
                {
                    mNode.Path = newPath;
                    node.Text = Path.GetFileNameWithoutExtension(newPath);
                    treeView.Sort();
                }
            }
        }


        TreeNode GetParentNode(TreeNode parent, string path)
        {
            TreeNode found = null;
            if (parent == null)
            {
                foreach (TreeNode node in this.Nodes)
                {
                    if (path == ((MaterialNode)node.Tag).Path)
                    {
                        found = node;
                        break;
                    }
                    found = GetParentNode(node, path);
                    if (found != null)
                        break;
                }
            }
            else
            {
                foreach (TreeNode node in parent.Nodes)
                {
                    if (path == ((MaterialNode)node.Tag).Path)
                    {
                        found = node;
                        break;
                    }
                    found = GetParentNode(node, path);
                    if (found != null)
                        break;
                }
            }
            return found;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);

            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (node.Parent != null)
                {
                    MaterialData m = MainForm.materialExplorer.Data();
                    if (m != null && (materialType == MaterialDataType.All || m.DataType == MaterialDataType.All || m.DataType == materialType))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (node.Parent != null)
                {
                    MaterialData m = MainForm.materialExplorer.Data();
                    if (m != null && (materialType == MaterialDataType.All || m.DataType == MaterialDataType.All || m.DataType == materialType))
                    {
                        Select(m.ID);
                        OnSelectedIndexChanged(EventArgs.Empty);
                    }
                }
            }
        }

    }
}
