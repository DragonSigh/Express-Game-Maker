using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using EGMGame.Library;
using System.Collections;
using EGMGame.Controls;
using Microsoft.Xna.Framework.Content;
using System.Media;
using EGMGame.Dialogs;
using Microsoft.Xna.Framework;
using EGMGame.Controls.Game;
using EGMGame.Docking.Explorers;
//////////////////////////////////////////////////////////////////////////
// Material Explorer 
//---------------------
// Used for importing game materials such as images, audio, videos.
//////////////////////////////////////////////////////////////////////////
namespace EGMGame.Dialogs
{
    public partial class ChooseMaterialDialog : Form
    {
        #region Constructor
        public ChooseMaterialDialog()
        {
            InitializeComponent();
            RefreshList(false);
        }
        #endregion

        public int Icon
        {
            get { return Data().ID; }
        }
        public bool IsOK = false;
        
        MaterialDataType materialType = MaterialDataType.Image;

        internal void AddMaterial(string path, MaterialData m, List<MaterialDataType> types)
        {
            if (types.Contains(materialType))
            {
                if (explorerList.Nodes.Count == 0)
                {
                    RefreshList(false);
                }
                TreeNode parentNode = GetParentNode(null, path);

                TreeNode materialNode = new TreeNode(m.Name);
                materialNode.Tag = new MaterialNode(Path.Combine(Global.Project.Location, m.FileName), false, m);
                materialNode.ImageIndex = GetImgIndexFrom(Path.GetExtension(Path.Combine(Global.Project.Location, m.FileName)));
                materialNode.SelectedImageIndex = materialNode.ImageIndex;
                parentNode.Nodes.Add(materialNode);
                explorerList.Sort();
            }
        }

        internal void AddMaterial(string path, MaterialData m, MaterialDataType materialDataType)
        {
            if (materialType == materialDataType)
            {
                if (explorerList.Nodes.Count == 0)
                {
                    RefreshList(false);
                }
                TreeNode parentNode = GetParentNode(null, path);

                TreeNode materialNode = new TreeNode(m.Name);
                materialNode.Tag = new MaterialNode(Path.Combine(Global.Project.Location, m.FileName), false, m);
                materialNode.ImageIndex = GetImgIndexFrom(Path.GetExtension(Path.Combine(Global.Project.Location, m.FileName)));
                materialNode.SelectedImageIndex = materialNode.ImageIndex;
                parentNode.Nodes.Add(materialNode);
                explorerList.Sort();
            }
        }

        internal bool Delete(TreeNode parent, string path)
        {
            TreeNode delete = null;
            if (parent == null)
            {
                foreach (TreeNode node in explorerList.Nodes)
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
            if (explorerList.Nodes.Count > 1)
                return DeleteD(explorerList.Nodes[1], data, materialDataType);
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
                explorerList.Sort();
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
                explorerList.Sort();
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
                    explorerList.Sort();


                }
                else
                {
                    mNode.Path = newPath;
                    node.Text = Path.GetFileNameWithoutExtension(newPath);
                    explorerList.Sort();
                }
            }
        }

        TreeNode GetParentNode(TreeNode parent, string path)
        {
            TreeNode found = null;
            if (parent == null)
            {
                foreach (TreeNode node in explorerList.Nodes)
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

        public void RefreshList(bool memorize)
        {
            RefreshList(memorize, materialType);
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

        public void RefreshList(bool memorize, MaterialDataType type)
        {
            int id = -1;
           explorerList.Nodes.Clear();
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
            explorerList.Nodes.Add(parent);
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
                explorerList.Nodes.Add(parent);

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
                case ".xml":
                    return 10;
                case ".pdf":
                    return 11;
                case ".exe":
                    return 12;
                case ".bmpfont":
                    return 15;
            }
            return 2;
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
            }
            return false;
        }
        /// <summary>
        /// Get Selected Event
        /// </summary>
        /// <returns></returns>
        public MaterialData Data()
        {
            if (explorerList.SelectedNode != null && explorerList.SelectedNode.Tag != null && !((MaterialNode)explorerList.SelectedNode.Tag).IsFolder)
                return ((MaterialNode)explorerList.SelectedNode.Tag).Data;
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
            if (explorerList.Nodes != null)
            {
                MaterialNode mNode;
                for (int i = 0; i < explorerList.Nodes.Count; i++)
                {
                    mNode = (MaterialNode)explorerList.Nodes[i].Tag;

                    if (!mNode.IsFolder && mNode.Data.ID == id)
                    {
                        explorerList.SelectedNode = explorerList.Nodes[i];
                        return;
                    }
                    else
                    {
                        if (Select(id,explorerList.Nodes[i]))
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
                    explorerList.SelectedNode = node.Nodes[i];
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            MainForm.NeedSave = true;
            IsOK = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            IsOK = false;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void explorerList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            materialPreview.SelectedMaterial = Data();
        }

        internal void Setup(int p)
        {
            Select(p);
        }

        internal void NodesClear()
        {
            explorerList.Nodes.Clear();
        }

        private void ChooseMaterialDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
