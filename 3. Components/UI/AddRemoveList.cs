using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.Collections;
using System.Media;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EGMGame.Controls
{
    public partial class AddRemoveList : UserControl, IAddRemoveList
    {
        #region "Event Declarations"
        public delegate void AddItemEvent(object sender, AddRemoveListEventArgs ca);
        public event AddItemEvent AddItem;
        public delegate void MoveItemEvent(object sender, AddRemoveListEventArgs ca);
        public event MoveItemEvent MoveItem;
        public delegate void RemoveItemEvent(object sender, AddRemoveListEventArgs ca);
        public event RemoveItemEvent RemoveItem;
        public delegate void SelectItemEvent(object sender, AddRemoveListEventArgs ca);
        public event SelectItemEvent SelectItem;
        public delegate void RenameItemEvent(object sender, AddRemoveListEventArgs ca);
        public event RenameItemEvent RenameItem;
        #endregion

        public bool Master
        {
            get { return master; }
            set { master = value; }
        }
        bool master = false;

        [Browsable(false)]
        public TreeNodeCollection Nodes
        {
            get
            {
                return listBox.Nodes;
            }
        }

        public bool ShowWarning
        {
            get { return showWarning; }
            set { showWarning = value; }
        }
        bool showWarning = true;

        public bool Export
        {
            get { return _export; }
            set
            {
                _export = value;
                if (!value)
                {
                    exportToolStripMenuItem.Visible = false;
                    if (!Import)
                        tSImportExport.Visible = false;
                }
                else
                {
                    exportToolStripMenuItem.Visible = true;
                    tSImportExport.Visible = true;
                }
            }
        }
        bool _export = true;

        public bool Import
        {
            get { return _import; }
            set
            {
                _import = value;
                if (!value)
                {
                    importToolStripMenuItem.Visible = false;
                    if (!Export)
                        tSImportExport.Visible = false;
                }
                else
                {
                    importToolStripMenuItem.Visible = true;
                    tSImportExport.Visible = true;
                }
            }
        }
        bool _import = true;

        public bool AllowClipboard
        {
            get { return _allowClipboard; }
            set
            {
                _allowClipboard = value;
                copuToolStripMenuItem.Visible = value;
                pasteToolStripMenuItem.Visible = value;
                duplicateToolStripMenuItem.Visible = value;
                tSclipBoard.Visible = value;
            }
        }
        bool _allowClipboard = true;

        public bool AllowMenu
        {
            get { return listBox.ContextMenuStrip != null; }
            set
            {
                if (value)
                    listBox.ContextMenuStrip = contextMenuStrip1;
                else
                    listBox.ContextMenuStrip = null;
            }
        }

        public bool EnableUpDown
        {
            get { return tsbUp.Visible; }
            set
            {
                tsbUp.Visible = tsbDown.Visible = value;
                if (value)
                {
                    allowCategs = false;
                    listBox.Category = false;
                    SetupCategories(false);
                }

                if (!allowCategs)
                {
                    if (!value)
                        toolStripSeparator2.Visible = false;
                    else
                        toolStripSeparator2.Visible = true;
                }
            }
        }

        public bool AllowRename
        {
            get { return allowRename; }
            set
            {
                allowRename = value;
                renameToolStripMenuItem.Enabled = value;
            }
        }
        bool allowRename = true;

        List<TreeNode> nodeList = new List<TreeNode>();

        public bool AllowCategories
        {
            get { return allowCategs; }
            set
            {
                allowCategs = value;
                if (listBox != null)
                    listBox.Category = value;
                SetupCategories(value);
                if (value)
                {
                    tsbUp.Visible = tsbDown.Visible = false;
                }
                if (!value)
                    toolStripSeparator2.Visible = false;
                else
                    toolStripSeparator2.Visible = true;
            }
        }
        bool allowCategs = true;

        public bool AllowAdd
        {
            get { return allowAdd; }
            set
            {
                allowAdd = value;
                addBtn.Visible = value;
                toolStripSeparator1.Visible = value;
            }
        }
        bool allowAdd = true;

        public bool AllowRemove
        {
            get { return allowRemove; }
            set
            {
                allowRemove = value;
                removeBtn.Visible = value;
                toolStripSeparator2.Visible = value;
            }
        }
        bool allowRemove = true;

        public bool MultipleSelection
        {
            get { return allowMulti; }
            set { listBox.MultipleSelection = allowMulti = value; }
        }
        bool allowMulti = false;

        public int SelectedIndex
        {
            get
            {
                if (!allowCategs)
                {
                    if (listBox.SelectedNode != null)
                        return listBox.SelectedNode.Index;
                    else
                        return -1;
                }
                else
                    return GetCategIndex();
            }
            set
            {
                if (!allowCategs)
                {
                    if (value > -1)
                        listBox.SelectedNode = listBox.Nodes[value];
                    else
                        listBox.SelectedNode = null;
                }
                else
                    SetCategIndex(value);
            }
        }
        //[Browsable(false)]
        //public ArrayList SelectedIndexes
        //{
        //    get
        //    {
        //        return GetIndexes();
        //    }
        //    set
        //    {
        //        ArrayList list = new ArrayList();
        //        foreach (int i in value)
        //        {
        //            if (!allowCategs)
        //            {
        //                if (i > -1)
        //                    list.Add(listBox.Nodes[i]);
        //            }
        //            else
        //            {
        //                if (i > -1)
        //                    list.Add(nodeList[i]);
        //            }
        //        }
        //        listBox.SelectedNodes = list;
        //    }
        //}

        private ArrayList GetIndexes()
        {
            ArrayList list = new ArrayList();

            foreach (TreeNode n in listBox.SelectedNodes)
            {
                if (allowCategs && n.Parent != null)
                    list.Add(((NodeData)n.Tag).Index);
                else if (!allowCategs)
                    list.Add(((NodeData)n.Tag).Index);
            }
            return list;
        }

        private int GetCategIndex()
        {
            if (listBox.SelectedNode != null)
                if (listBox.SelectedNode.Tag == null)
                    return -1;
                else
                    return ((NodeData)listBox.SelectedNode.Tag).Index;
            else
                return -1;
        }

        [Browsable(false)]
        public TreeNode SelectedNode
        {
            get { return listBox.SelectedNode; }
        }

        public int SelectedCategory
        {
            get
            {
                if (listBox.SelectedNode == null)
                    return 0;
                if (listBox.SelectedNode.Parent == null)
                {
                    return listBox.SelectedNode.Index;
                }
                else
                {
                    return ((NodeData)listBox.SelectedNode.Tag).Data.Category;
                }
            }
        }

        private void SetCategIndex(int value)
        {
            if (value > -1)
                listBox.SelectedNode = nodeList[value];
            else
                listBox.SelectedNode = null;
        }

        public int Count
        {
            get
            {
                if (allowCategs)
                {
                    int c = 0;
                    for (int i = 0; i < listBox.Nodes.Count; i++)
                    {
                        for (int j = 0; j < listBox.Nodes[i].Nodes.Count; j++)
                        {
                            c++;
                        }
                    }
                    return c;
                }
                else
                    return listBox.Nodes.Count;
            }
        }
        IEnumerable container;
        Type dataType
        {
            get
            {
                if (_dataType == null)
                {
                    if (this.Data().ID > -1)
                    {
                        if (this.Data().GetType() == typeof(AnimationAction))
                            _dataType = typeof(AnimationAction);
                        else if (this.Data().GetType() == typeof(AnimationData))
                            _dataType = typeof(AnimationData);
                        else if (this.Data().GetType() == typeof(AnimationFrame))
                            _dataType = typeof(AnimationFrame);
                        else if (this.Data().GetType() == typeof(AnimationAnchor))
                            _dataType = typeof(AnimationAnchor);
                        else if (this.Data().GetType() == typeof(AnimationSprite))
                            _dataType = typeof(AnimationSprite);
                        else if (this.Data().GetType() == typeof(ListData))
                            _dataType = typeof(ListData);
                        else if (this.Data().GetType() == typeof(MapInfo))
                            _dataType = typeof(MapInfo);
                        else if (this.Data().GetType() == typeof(AudioData))
                            _dataType = typeof(AudioData);
                        else if (this.Data().GetType() == typeof(EventProgramData))
                            _dataType = typeof(EventProgramData);
                        else if (this.Data().GetType() == typeof(Data))
                            _dataType = typeof(Data);
                        else if (this.Data().GetType() == typeof(DataProperty))
                            _dataType = typeof(DataProperty);
                        else if (this.Data().GetType() == typeof(EventData))
                            _dataType = typeof(EventData);
                        else if (this.Data().GetType() == typeof(FontData))
                            _dataType = typeof(FontData);
                        else if (this.Data().GetType() == typeof(ItemData))
                            _dataType = typeof(ItemData);
                        else if (this.Data().GetType() == typeof(MenuData))
                            _dataType = typeof(MenuData);
                        else if (this.Data().GetType() == typeof(MapData))
                            _dataType = typeof(MapData);
                        else if (this.Data().GetType() == typeof(LayerData))
                            _dataType = typeof(LayerData);
                        else if (this.Data().GetType() == typeof(SwitchData))
                            _dataType = typeof(SwitchData);
                        else if (this.Data().GetType() == typeof(TextData))
                            _dataType = typeof(TextData);
                        else if (this.Data().GetType() == typeof(TilesetData))
                            _dataType = typeof(TilesetData);
                        else if (this.Data().GetType() == typeof(VariableData))
                            _dataType = typeof(VariableData);
                        else if (this.Data().GetType() == typeof(GlobalEventData))
                            _dataType = typeof(GlobalEventData);
                        else if (this.Data().GetType() == typeof(PlayerData))
                            _dataType = typeof(PlayerData);
                        else if (this.Data().GetType() == typeof(SkinData))
                            _dataType = typeof(SkinData);
                        else if (this.Data().GetType() == typeof(StringData))
                            _dataType = typeof(StringData);
                        else if (this.Data().GetType() == typeof(PlayerData))
                            _dataType = typeof(PlayerData);
                        else if (this.Data().GetType() == typeof(ParticleSystemData))
                            _dataType = typeof(ParticleSystemData);
                        else if (this.Data().GetType() == typeof(ItemEffect))
                            _dataType = typeof(ItemEffect);
                        else if (this.Data().GetType() == typeof(ParticleEmitter))
                            _dataType = typeof(ParticleEmitter);
                        else if (this.Data().GetType() == typeof(HeroData))
                            _dataType = typeof(HeroData);
                        else if (this.Data().GetType() == typeof(EnemyData))
                            _dataType = typeof(EnemyData);
                        else if (this.Data().GetType() == typeof(EquipmentData))
                            _dataType = typeof(EquipmentData);
                        else if (this.Data().GetType() == typeof(SkillData))
                            _dataType = typeof(SkillData);
                        else if (this.Data().GetType() == typeof(StateData))
                            _dataType = typeof(StateData);
                        else if (this.Data().GetType() == typeof(ProjectileData))
                            _dataType = typeof(ProjectileData);
                    }
                }
                return _dataType;
            }
            set { _dataType = value; }
        }
        Type _dataType;
        TreeNode memorizedNode;
        /// <summary>
        /// Returns the id of the selected data.
        /// </summary>
        public int SelectedID
        {
            get
            {
                if (SelectedNode != null && SelectedNode.Tag != null)
                    if (SelectedIndex > -1)
                        return ((NodeData)listBox.SelectedNode.Tag).Data.ID;
                return SelectedIndex;
            }
        }
        /// <summary>
        /// Gets or sets whether the toolbar should be displayed.
        /// </summary>
        public bool DisplayToolbar
        {
            get { return toolStrip1.Visible; }
            set { toolStrip1.Visible = value; }
        }

        [Browsable(false)]
        public ImageList ImageList
        {
            get { return imageList; }
            set { imageList = value; listBox.ImageList = value; }
        }
        ImageList imageList;

        public delegate int GetImageIndex(string ext);
        public event GetImageIndex GetImageIndexFrom;
        /// <summary>
        /// Constructor
        /// </summary>
        public AddRemoveList()
        {
            InitializeComponent();
            listBox.Category = AllowCategories;
            this.toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }
        /// <summary>
        /// Add Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void addBtn_Click(object sender, EventArgs e)
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            ev.ID = SelectedID;
            if (allowCategs && listBox.Nodes.Count > 0 && listBox.SelectedNode != null)
            {
                if (listBox.SelectedNode.Parent == null)
                    ev.Category = listBox.SelectedNode.Index;
                else
                    ev.Category = listBox.SelectedNode.Parent.Index;
            }
            AddItem(this, ev);
        }
        /// <summary>
        /// Remove Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void removeBtn_Click(object sender, EventArgs e)
        {
            if (!this.listBox.LabelEdit)
            {
                if (SelectedIndex > -1 && (this.listBox.SelectedNodes.Count == 1 || !MultipleSelection))
                {
                    if (showWarning)
                    {
                        if (MessageBox.Show("Are you sure you want to delete " + Data().Name + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                            ev.ID = SelectedID;
                            RemoveItem(this, ev);
                        }
                    }
                    else
                    {
                        AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                        ev.ID = SelectedID;
                        RemoveItem(this, ev);
                    }
                }
                else if (allowCategs && listBox.SelectedNode != null && listBox.SelectedNode.Parent == null && listBox.SelectedNode.Index > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete category?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<TreeNode> nodes = new List<TreeNode>();
                        foreach (TreeNode n in listBox.SelectedNode.Nodes)
                        {
                            nodes.Add(n);
                        }
                        listBox.SelectedNode.Nodes.Clear();
                        foreach (TreeNode node in nodes)
                        {
                            ((NodeData)node.Tag).Data.Category = listBox.SelectedNode.Index - 1;
                            listBox.Nodes[listBox.SelectedNode.Index - 1].Nodes.Add(node);
                        }
                        foreach (TreeNode p in listBox.Nodes)
                        {
                            foreach (TreeNode n in p.Nodes)
                            {
                                if (((NodeData)n.Tag).Data.Category > listBox.SelectedNode.Index)
                                {
                                    ((NodeData)n.Tag).Data.Category--;
                                }
                            }
                        }

                        List<NodeCategory> categories = Global.Project.Categories[dataType.ToString()];
                        categories.RemoveAt(listBox.SelectedNode.Index);
                        listBox.SelectedNode.Remove();
                    }
                }
                else if (this.listBox.SelectedNodes.Count > 0 && MultipleSelection)
                {
                    if (showWarning)
                    {
                        if (MessageBox.Show("Are you sure you want to delete the selection?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                            ev.ID = SelectedID;
                            RemoveItem(this, ev);
                        }
                    }
                    else
                    {
                        AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                        ev.ID = SelectedID;
                        RemoveItem(this, ev);
                    }
                }
                else
                {
                    SystemSounds.Beep.Play();
                }
            }
        }
        /// <summary>
        /// Remove node
        /// </summary>
        /// <param name="treeNode"></param>
        internal void RemoveNode(TreeNode treeNode)
        {
            treeNode.Remove();
            nodeList.Remove(treeNode);
            RefreshIndex();
        }
        internal void RemoveNode(IGameData data)
        {
            TreeNode treeNode = null;
            if (!allowCategs)
            {
                foreach (TreeNode node in listBox.Nodes)
                {
                    if (((NodeData)node.Tag).Data == data)
                    {
                        treeNode = node;
                        break;
                    }
                }
            }
            else
            {
                foreach (TreeNode p in listBox.Nodes)
                {
                    foreach (TreeNode n in p.Nodes)
                    {
                        if (((NodeData)n.Tag).Data == data)
                        {
                            treeNode = n;
                            break;
                        }
                    }
                }
            }
            if (treeNode != null)
            {
                treeNode.Remove();
                nodeList.Remove(treeNode);
                RefreshIndex();
            }
        }
        internal void RemoveSelectedNode()
        {
            // Remove Item
            RemoveNode(listBox.SelectedNode);
        }
        /// <summary>
        /// Refresh Index
        /// </summary>
        private void RefreshIndex()
        {
            int i = 0;
            nodeList.Clear();
            if (!allowCategs)
            {
                foreach (TreeNode node in listBox.Nodes)
                {
                    ((NodeData)node.Tag).Index = i;
                    i++;
                }
            }
            else
            {
                foreach (TreeNode p in listBox.Nodes)
                {
                    foreach (TreeNode n in p.Nodes)
                    {
                        ((NodeData)n.Tag).Index = i;
                        nodeList.Add(n);
                        i++;
                    }
                }
            }
        }

        internal void AddNode(IGameData data)
        {
            if (allowCategs)
            {
                if (listBox.Nodes.Count > 0)
                {
                    TreeNode node = new TreeNode(data.Name);
                    node.Tag = new NodeData(0, data);
                    listBox.Nodes[data.Category].Nodes.Add(node);
                    RefreshIndex();
                    listBox.SelectedNode = node;
                    if (ImageList != null && data is MaterialData && GetImageIndexFrom != null)
                    {
                        FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, ((MaterialData)data).FileName));
                        if (file.Exists)
                            node.SelectedImageIndex = node.ImageIndex = GetImageIndexFrom(file.Extension.ToLower());
                    }
                }
                else
                {
                    Type type = data.GetType();
                    if (data is MapInfo)
                        type = typeof(MapData);
                    List<NodeCategory> categories = Global.Project.Categories[type.ToString()];

                    foreach (NodeCategory c in categories)
                    {
                        TreeNode n = new TreeNode(c.Name);
                        listBox.Nodes.Add(n);
                    }
                    TreeNode node = new TreeNode(data.Name);
                    node.Tag = new NodeData(0, data);
                    listBox.Nodes[data.Category].Nodes.Add(node);
                    RefreshIndex();
                    listBox.SelectedNode = node;
                    if (ImageList != null && data is MaterialData && GetImageIndexFrom != null)
                    {
                        FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, ((MaterialData)data).FileName));
                        if (file.Exists)
                            node.SelectedImageIndex = node.ImageIndex = GetImageIndexFrom(file.Extension.ToLower());
                    }
                }
            }
            else
            {
                TreeNode node = new TreeNode(data.Name);
                node.Tag = new NodeData(0, data);
                listBox.Nodes.Add(node);
                RefreshIndex();
                listBox.SelectedNode = node;
                if (ImageList != null && data is MaterialData && GetImageIndexFrom != null)
                {
                    FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, ((MaterialData)data).FileName));
                    if (file.Exists)
                        node.SelectedImageIndex = node.ImageIndex = GetImageIndexFrom(file.Extension.ToLower());
                }
            }
        }
        /// <summary>
        /// Called when a new item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void listbox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            ev.ID = SelectedID;
            if (SelectedID > -1)
                lblID.Text = "ID: " + SelectedID.ToString();
            else
                lblID.Text = "ID: NaN";

            if (SelectItem != null)
                SelectItem(this, ev);
        }

        /// <summary>
        /// Sets up listbox from the given list.
        /// </summary>
        /// <param name="list"></param>
        public virtual void SetupList(IEnumerable list, Type type)
        {
            container = list;
            dataType = type;
            if (list is IDictionary)
                list = ((IDictionary)list).Values;
            if (!allowCategs)
            {
                int i = SelectedIndex;
                if (i < 0)
                    i = 0;
                listBox.Nodes.Clear();
                nodeList.Clear();
                this.Enabled = true;
                FileInfo file;
                foreach (IGameData data in list)
                {
                    if (string.IsNullOrEmpty(txtSearch.Text) || (tsSearch.Visible && data.Name.ToLower().Contains(txtSearch.Text.ToLower())))
                    {
                        TreeNode node = new TreeNode(data.Name);
                        listBox.Nodes.Add(node);
                        nodeList.Add(node);
                        node.Tag = new NodeData(node.Index, data);

                        if (ImageList != null && data is MaterialData && GetImageIndexFrom != null)
                        {
                            file = new FileInfo(Path.Combine(Global.Project.Location, ((MaterialData)data).FileName));
                            if (file.Exists)
                                node.SelectedImageIndex = node.ImageIndex = GetImageIndexFrom(file.Extension.ToLower());
                        }
                    }
                }
                if (i < listBox.Nodes.Count)
                    SelectedIndex = i;
            }
            else
            {
                int i = 0;
                int j = 0;
                if (listBox.SelectedNode != null)
                    i = SelectedIndex;
                listBox.Nodes.Clear();
                nodeList.Clear();
                this.Enabled = true;
                // Add Categories
                List<NodeCategory> categories = Global.Project.Categories[type.ToString()];

                foreach (NodeCategory c in categories)
                {
                    TreeNode n = new TreeNode(c.Name);
                    listBox.Nodes.Add(n);
                    if (ImageList != null)
                    {
                        n.ImageIndex = 0;
                    }
                }

                if (((ICollection)list).Count > 0)
                {
                    FileInfo file;
                    foreach (IGameData data in list)
                    {
                        if (string.IsNullOrEmpty(txtSearch.Text) || (tsSearch.Visible && data.Name.ToLower().Contains(txtSearch.Text.ToLower())))
                        {
                            TreeNode node = new TreeNode(data.Name);
                            node.Tag = new NodeData(j, data);
                            listBox.Nodes[data.Category].Nodes.Add(node);
                            nodeList.Add(node);
                            j++;
                            if (categories[data.Category].Expand)
                                listBox.Nodes[data.Category].Expand();
                            if (ImageList != null && data is MaterialData && GetImageIndexFrom != null)
                            {
                                file = new FileInfo(Path.Combine(Global.Project.Location, ((MaterialData)data).FileName));
                                if (file.Exists)
                                    node.SelectedImageIndex = node.ImageIndex = GetImageIndexFrom(file.Extension.ToLower());
                            }
                        }
                    }
                }
                if (listBox.SelectedNode == null && listBox.Nodes.Count > 0)
                    listBox.SelectedNode = listBox.Nodes[0];
            }
        }
        /// <summary>
        /// Clear listbox.
        /// </summary>
        internal void Clear(bool disable)
        {
            listBox.Nodes.Clear();
            if (disable)
                this.Enabled = false;
        }
        /// <summary>
        /// Forces the call of "SelectItem" event
        /// </summary>
        public void ForceIndexChange()
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            ev.ID = SelectedID;
            SelectItem(this, ev);
        }
        /// <summary>
        /// Start label edit if mouse double clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            ev.ID = SelectedID;
            if (SelectedID > -1)
                lblID.Text = "ID: " + SelectedID.ToString();
            else
                lblID.Text = "ID: NaN";
            ev.MouseDoubleClicked = true;
            if (SelectItem != null)
                SelectItem(this, ev);
        }
        /// <summary>
        /// After label edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Label))
            {
                int i = e.Label.IndexOfAny(System.IO.Path.GetInvalidFileNameChars());
                i += e.Label.IndexOfAny(System.IO.Path.GetInvalidPathChars());
                if (i >= 0)
                {
                    MessageBox.Show(@"This name cannot contain any invalid characters: \ / : * ? " + "\"" + " < > |  ", "Express Game Maker");

                    e.CancelEdit = true;
                    return;
                }
                if (!allowCategs)
                {
                    ((NodeData)e.Node.Tag).Data.Name = e.Label;
                    Global.CBRefresh(dataType);

                    if (RenameItem != null)
                        RenameItem(this, new AddRemoveListEventArgs(this.SelectedID));

                }
                else
                {
                    if (e.Node.Parent == null)
                    {
                        List<NodeCategory> categories = Global.Project.Categories[dataType.ToString()];
                        categories[e.Node.Index].Name = e.Label;
                    }
                    else
                    {
                        ((NodeData)e.Node.Tag).Data.Name = e.Label;
                        Global.CBRefresh(dataType);
                        if (RenameItem != null)
                            RenameItem(this, new AddRemoveListEventArgs(this.SelectedID));
                    }
                }
                if (dataType == typeof(SwitchData) || dataType == typeof(VariableData) || dataType == typeof(ListData) || dataType == typeof(StringData) || dataType == typeof(AnimationData) || dataType == typeof(AnimationAction))
                {
                    // Refresh Events
                    MainForm.globalEventEditor.RefreshActivePage();
                    if (MainForm.mapEditor.mapEditor2.mapViewer.eventDialog != null)
                        MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.RefreshActivePage();
                    MainForm.eventEditor.RefreshActivePage();
                }
            }
            listBox.LabelEdit = false;
        }

        internal void MemorizeIndex()
        {
            memorizedNode = listBox.SelectedNode;
        }

        internal void LoadIndex()
        {
            listBox.SelectedNode = memorizedNode;
        }

        private void SetupCategories(bool value)
        {
            addCategoryBtn.Visible = value;
        }

        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            if (allowCategs)
            {
                //if (SelectedList.Count > 0)
                //{
                List<NodeCategory> categories = Global.Project.Categories[dataType.ToString()];

                NodeCategory c = new NodeCategory();
                c.Name = "Category";
                categories.Add(c);
                TreeNode n = new TreeNode(c.Name);
                listBox.Nodes.Add(n);
                listBox.SelectedNode = n;
                //}
            }
        }

        private void removeCategoryBtn_Click(object sender, EventArgs e)
        {

        }

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode treeNode = listBox.GetNodeAt(e.Location);
            if (treeNode != null)
                listBox.SelectedNode = treeNode;
        }

        private void listBox_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (allowCategs)
            {
                TreeNode n = (TreeNode)e.Item;
                if (n.Parent != null)
                    DoDragDrop(n, DragDropEffects.Copy);
            }
        }

        private void listBox_DragOver(object sender, DragEventArgs e)
        {
            if (allowCategs)
            {
                try
                {
                    if (e.Data.GetDataPresent(typeof(TreeNode)))
                    {
                        TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                        if (listBox.SelectedNode == node)
                            e.Effect = DragDropEffects.All;
                    }
                }
                catch
                {
                }
            }
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (listBox.SelectedNode == node)
                {
                    // Get Mouse Node
                    TreeNode overNode = listBox.GetNodeAt(listBox.PointToClient(new Point(e.X, e.Y)));
                    //
                    if (overNode != null)
                    {
                        if (overNode.Parent != node.Parent)
                        {
                            if (overNode.Parent == null)
                            {
                                if (node.Parent != overNode)
                                {
                                    int i = ((NodeData)node.Tag).Index;
                                    node.Remove();
                                    overNode.Nodes.Add(node);
                                    IGameData data = ((NodeData)node.Tag).Data;
                                    data.Category = overNode.Index;

                                    listBox.SelectedNode = node;
                                }
                            }
                            else
                            {
                                if (!allowCategs)
                                {
                                    int i = ((NodeData)node.Tag).Index;
                                    TreeNode parentNode = overNode.Parent;
                                    node.Remove();
                                    parentNode.Nodes.Add(node);
                                    IGameData data = ((NodeData)node.Tag).Data;
                                    data.Category = parentNode.Index;

                                    listBox.SelectedNode = node;
                                }
                                else
                                {
                                    overNode = overNode.Parent;
                                    int i = ((NodeData)node.Tag).Index;
                                    node.Remove();
                                    overNode.Nodes.Add(node);
                                    IGameData data = ((NodeData)node.Tag).Data;
                                    data.Category = overNode.Index;

                                    listBox.SelectedNode = node;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (allowCategs)
                        {

                            if (node.Parent != listBox.Nodes[listBox.Nodes.Count - 1])
                            {
                                int i = ((NodeData)node.Tag).Index;
                                node.Remove();
                                listBox.Nodes[listBox.Nodes.Count - 1].Nodes.Add(node);
                                IGameData data = ((NodeData)node.Tag).Data;
                                data.Category = listBox.Nodes[listBox.Nodes.Count - 1].Index;

                                listBox.SelectedNode = node;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "2x001");
            }
        }

        private void listBox_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (dataType != null)
            {
                List<NodeCategory> categories = Global.Project.Categories[dataType.ToString()];
                categories[e.Node.Index].Expand = false;
                if (ImageList != null)
                    e.Node.ImageIndex = 0;
            }
        }

        private void listBox_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (dataType != null)
            {
                List<NodeCategory> categories = Global.Project.Categories[dataType.ToString()];
                if (e.Node.Index < categories.Count)
                    categories[e.Node.Index].Expand = true;
                if (ImageList != null)
                    e.Node.ImageIndex = 1;
            }
        }

        private void listBox_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void listBox_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void listBox_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            return;
            if (listBox.SelectedNode != null)
            {
                listBox.LabelEdit = true;
                listBox.SelectedNode.BeginEdit();
            }
        }
        /// <summary>
        /// Tries to select the first node in the list.
        /// </summary>
        internal void SelectFirst()
        {
            if (this.Count > 0)
                this.SelectedIndex = 0;
        }
        /// <summary>
        /// Tries to select given index. If fails, tries to select first in list.
        /// </summary>
        /// <param name="index"></param>
        internal void TrySelect(int index)
        {
            if (index > -1 && index < this.Count)
                this.SelectedIndex = index;
            else
                SelectFirst();
        }
        /// <summary>
        /// Select ID 
        /// </summary>
        /// <param name="p"></param>
        internal void Select(int id)
        {
            if (allowCategs)
            {
                for (int i = 0; i < listBox.Nodes.Count; i++)
                {
                    for (int j = 0; j < listBox.Nodes[i].Nodes.Count; j++)
                    {
                        if (((NodeData)listBox.Nodes[i].Nodes[j].Tag).Data.ID == id)
                        {
                            listBox.SelectedNode = listBox.Nodes[i].Nodes[j];
                            return;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < listBox.Nodes.Count; i++)
                {
                    if (((NodeData)listBox.Nodes[i].Tag).Data.ID == id)
                    {
                        listBox.SelectedNode = listBox.Nodes[i];
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Get Selected Data
        /// </summary>
        /// <returns></returns>
        internal IGameData Data()
        {
            if (listBox.SelectedNode != null && listBox.SelectedNode.Tag != null)
                return ((NodeData)listBox.SelectedNode.Tag).Data;
            IGameData data1 = new SwitchData();
            data1.ID = -10;
            data1.Name = "Unknown Data";
            return data1;
        }

        internal T Data<T>()
        {
            try
            {
                if (listBox.SelectedNode != null && listBox.SelectedNode.Tag != null)
                {
                    return Global.GetData<T>(((NodeData)listBox.SelectedNode.Tag).Data.ID, container);
                }
                T data1 = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
                ((IGameData)(object)data1).ID = -10;
                ((IGameData)(object)data1).Name = "Unknown Data";
                return data1;
            }
            catch
            {
                return default(T);
            }
        }

        internal IGameData GetData(TreeNode node)
        {
            return ((NodeData)node.Tag).Data;
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            MoveUp();
            if (MoveItem != null)
            {
                AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                ev.ID = SelectedID;
                MoveItem(this, ev);
            }
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            MoveDown();
            if (MoveItem != null)
            {
                AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                ev.ID = SelectedID;
                MoveItem(this, ev);
            }
        }

        private T Clone<T>(IGameData source)
        {
            if (!source.GetType().IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addBtn.Visible)
            {
                IGameData d = Data();

                if (d.ID > -1)
                {
                    IGameData data = null;
                    if (dataType == typeof(AnimationAction))
                        data = Clone<AnimationAction>(d);
                    else if (dataType == typeof(AnimationData))
                        data = Clone<AnimationData>(d);
                    else if (dataType == typeof(AnimationFrame))
                        data = Clone<AnimationFrame>(d);
                    else if (dataType == typeof(AnimationAnchor))
                        data = Clone<AnimationAnchor>(d);
                    else if (dataType == typeof(AnimationSprite))
                        data = Clone<AnimationSprite>(d);
                    else if (dataType == typeof(ListData))
                        data = Clone<ListData>(d);
                    else if (dataType == typeof(MapInfo))
                        data = Clone<MapInfo>(d);
                    else if (dataType == typeof(AudioData))
                        data = Clone<AudioData>(d);
                    else if (dataType == typeof(EventProgramData))
                        data = Clone<EventProgramData>(d);
                    else if (dataType == typeof(Data))
                        data = Clone<Data>(d);
                    else if (dataType == typeof(DataProperty))
                        data = Clone<DataProperty>(d);
                    else if (dataType == typeof(EventData))
                        data = Clone<EventData>(d);
                    else if (dataType == typeof(FontData))
                        data = Clone<FontData>(d);
                    else if (dataType == typeof(ItemData))
                        data = Clone<ItemData>(d);
                    else if (dataType == typeof(MenuData))
                        data = Clone<MenuData>(d);
                    else if (dataType == typeof(MapData))
                    {
                        if (GameData.Maps.ContainsKey(d.ID))
                        {
                            data = Clone<MapInfo>(d);
                            int id = data.ID;
                            string n = data.Name;
                            data.Category = SelectedCategory;
                            data.ID = Global.GetID(((IDictionary)container));
                            ((IDictionary)container).Add(data.ID, data);
                            int i = 1; bool repeat = true;
                            while (true)
                            {
                                foreach (MapInfo info in Global.Project.MapsInfo.Values)
                                {
                                    if (data.Name + i.ToString() == info.Name)
                                    {
                                        i++; repeat = true;
                                        break;
                                    }
                                }
                                if (!repeat) break;
                                repeat = false;
                            }
                            data.Name += " - " + i.ToString();

                            // New Map
                            MapData scene;
                            if (GameData.Maps.ContainsKey(id))
                                scene = Global.Duplicate<MapData>(GameData.Maps[id]);
                            else
                            {
                                scene = Global.Duplicate<MapData>(Marshal.LoadData<MapData>(Global.Project.Location + ((MapInfo)data).Path + @"\" + n + Extensions.Scene));
                            }
                            scene.Name = data.Name;
                            scene.ID = data.ID;

                            ((MapInfo)data).Path = @"\Maps\";

                            Marshal.SaveObj(scene, Global.Project.Location + ((MapInfo)data).Path + @"\" + ((MapInfo)data).Name + Extensions.Scene, ((MapInfo)data).Path);

                            AddNode(data);
                        }
                        return;
                    }
                    else if (dataType == typeof(LayerData))
                        data = Clone<LayerData>(d);
                    else if (dataType == typeof(SwitchData))
                        data = Clone<SwitchData>(d);
                    else if (dataType == typeof(TextData))
                        data = Clone<TextData>(d);
                    else if (dataType == typeof(TilesetData))
                        data = Clone<TilesetData>(d);
                    else if (dataType == typeof(VariableData))
                        data = Clone<VariableData>(d);
                    else if (dataType == typeof(GlobalEventData))
                        data = Clone<GlobalEventData>(d);
                    else if (dataType == typeof(PlayerData))
                        data = Clone<PlayerData>(d);
                    else if (dataType == typeof(SkinData))
                        data = Clone<SkinData>(d);
                    else if (dataType == typeof(StringData))
                        data = Clone<StringData>(d);
                    else if (dataType == typeof(PlayerData))
                        data = Clone<PlayerData>(d);
                    else if (dataType == typeof(ParticleSystemData))
                        data = Clone<ParticleSystemData>(d);
                    else if (dataType == typeof(ItemEffect))
                        data = Clone<ItemEffect>(d);
                    else if (dataType == typeof(ParticleEmitterData))
                        data = Clone<ParticleEmitterData>(d);
                    else if (dataType == typeof(HeroData))
                        data = Clone<HeroData>(d);
                    else if (dataType == typeof(EnemyData))
                        data = Clone<EnemyData>(d);
                    else if (dataType == typeof(EquipmentData))
                        data = Clone<EquipmentData>(d);
                    else if (dataType == typeof(SkillData))
                        data = Clone<SkillData>(d);
                    else if (dataType == typeof(StateData))
                        data = Clone<StateData>(d);
                    else if (dataType == typeof(ComboData))
                        data = Clone<ComboData>(d);
                    else if (dataType == typeof(ProjectileData))
                        data = Clone<ProjectileData>(d);
                    else if (dataType == typeof(ProjectileGroupData))
                        data = Clone<ProjectileGroupData>(d);
                    else
                        data = null;

                    if (data != null)
                    {
                        data.Name = "Copy of " + data.Name;
                        if (allowCategs)
                            data.Category = SelectedCategory;
                        else
                            data.Category = 0;
                        if (container is IDictionary)
                        {
                            data.ID = Global.GetID(((IDictionary)container));
                            ((IDictionary)container).Add(data.ID, data);
                        }
                        else if (container is IList)
                        {
                            data.ID = Global.GetID(((IList)container));
                            ((IList)container).Add(data);
                        }
                        AddNode(data);

                        if (data is EventData)
                            MainForm.eventsExplorer.Setup();
                    }
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data().ID > -1)
            {
                saveFileDialog.DefaultExt = dataType.Name;
                saveFileDialog.Filter = "EGM Data|*." + dataType.Name;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    Marshal.SaveObj(Data(), file.FullName, file.Directory.FullName);
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (addBtn.Visible)
                {
                    openFileDialog.DefaultExt = dataType.Name;
                    openFileDialog.Filter = "EGM Data|*." + dataType.Name;
                    openFileDialog.FileName = "";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(openFileDialog.FileName);
                        IGameData data;
                        if (dataType == typeof(AnimationAction))
                        {
                            data = Marshal.LoadData<AnimationAction>(file.FullName);
                        }
                        else if (dataType == typeof(AnimationData))
                        {
                            data = Marshal.LoadData<AnimationData>(file.FullName);
                        }
                        else if (dataType == typeof(AnimationFrame))
                            data = Marshal.LoadData<AnimationFrame>(file.FullName);
                        else if (dataType == typeof(AnimationAnchor))
                            data = Marshal.LoadData<AnimationAnchor>(file.FullName);
                        else if (dataType == typeof(AnimationSprite))
                            data = Marshal.LoadData<AnimationSprite>(file.FullName);
                        else if (dataType == typeof(ListData))
                            data = Marshal.LoadData<ListData>(file.FullName);
                        else if (dataType == typeof(MapInfo))
                            data = Marshal.LoadData<MapInfo>(file.FullName);
                        else if (dataType == typeof(AudioData))
                        {
                            data = Marshal.LoadData<AudioData>(file.FullName);
                        }
                        else if (dataType == typeof(EventProgramData))
                            data = Marshal.LoadData<EventProgramData>(file.FullName);
                        else if (dataType == typeof(Data))
                            data = Marshal.LoadData<Data>(file.FullName);
                        else if (dataType == typeof(DataProperty))
                            data = Marshal.LoadData<DataProperty>(file.FullName);
                        else if (dataType == typeof(EventData))
                            data = Marshal.LoadData<EventData>(file.FullName);
                        else if (dataType == typeof(FontData))
                        {
                            data = Marshal.LoadData<FontData>(file.FullName);
                        }
                        else if (dataType == typeof(ItemData))
                            data = Marshal.LoadData<ItemData>(file.FullName);
                        else if (dataType == typeof(MenuData))
                            data = Marshal.LoadData<MenuData>(file.FullName);
                        else if (dataType == typeof(MapData))
                            data = Marshal.LoadData<MapData>(file.FullName);
                        else if (dataType == typeof(LayerData))
                            data = Marshal.LoadData<LayerData>(file.FullName);
                        else if (dataType == typeof(SwitchData))
                            data = Marshal.LoadData<SwitchData>(file.FullName);
                        else if (dataType == typeof(TextData))
                            data = Marshal.LoadData<TextData>(file.FullName);
                        else if (dataType == typeof(TilesetData))
                            data = Marshal.LoadData<TilesetData>(file.FullName);
                        else if (dataType == typeof(VariableData))
                            data = Marshal.LoadData<VariableData>(file.FullName);
                        else if (dataType == typeof(GlobalEventData))
                            data = Marshal.LoadData<GlobalEventData>(file.FullName);
                        else if (dataType == typeof(PlayerData))
                            data = Marshal.LoadData<PlayerData>(file.FullName);
                        else if (dataType == typeof(SkinData))
                            data = Marshal.LoadData<SkinData>(file.FullName);
                        else if (dataType == typeof(StringData))
                            data = Marshal.LoadData<StringData>(file.FullName);
                        else if (dataType == typeof(PlayerData))
                            data = Marshal.LoadData<PlayerData>(file.FullName);
                        else if (dataType == typeof(ParticleSystemData))
                            data = Marshal.LoadData<ParticleSystemData>(file.FullName);
                        else if (dataType == typeof(ItemEffect))
                            data = Marshal.LoadData<ItemEffect>(file.FullName);
                        else if (dataType == typeof(ParticleEmitterData))
                            data = Marshal.LoadData<ParticleEmitterData>(file.FullName);
                        else if (dataType == typeof(HeroData))
                            data = Marshal.LoadData<HeroData>(file.FullName);
                        else if (dataType == typeof(EnemyData))
                            data = Marshal.LoadData<EnemyData>(file.FullName);
                        else if (dataType == typeof(EquipmentData))
                            data = Marshal.LoadData<EquipmentData>(file.FullName);
                        else if (dataType == typeof(SkillData))
                            data = Marshal.LoadData<SkillData>(file.FullName);
                        else if (dataType == typeof(StateData))
                            data = Marshal.LoadData<StateData>(file.FullName);
                        else if (dataType == typeof(ProjectileData))
                            data = Marshal.LoadData<ProjectileData>(file.FullName);
                        else
                            data = null;
                        if (data != null)
                        {
                            if (allowCategs)
                                data.Category = SelectedCategory;
                            else
                                data.Category = 0;
                            if (container is IDictionary)
                            {
                                data.ID = Global.GetID(((IDictionary)container));
                                ((IDictionary)container).Add(data.ID, data);
                            }
                            else if (container is IList)
                            {
                                data.ID = Global.GetID(((IList)container));
                                ((IList)container).Add(data);
                            }
                            AddNode(data);
                        }
                    }
                }
            }
            catch
            { // Don't Do anything
            }
        }

        public void MoveUp()
        {
            if (container is IList && !allowCategs && listBox.SelectedNode != null && listBox.SelectedNode.Index > 0)
            {
                int index = listBox.SelectedNode.Index;
                IGameData data = (IGameData)((IList)container)[index];

                TreeNode node = listBox.SelectedNode;
                listBox.SelectedNode.Remove();
                listBox.Nodes.Insert(index - 1, node);

                ((IList)container).RemoveAt(index);
                ((IList)container).Insert(index - 1, data);

                listBox.SelectedNode = node;
            }
        }

        public void MoveDown()
        {
            if (container is IList && !allowCategs && listBox.SelectedNode != null)
            {
                if (listBox.SelectedNode != null && listBox.SelectedNode.Index < listBox.Nodes.Count - 1)
                {
                    int index = listBox.SelectedNode.Index;
                    IGameData data = (IGameData)((IList)container)[index];
                    TreeNode node = listBox.SelectedNode;
                    listBox.SelectedNode.Remove();
                    listBox.Nodes.Insert(index + 1, node);

                    ((IList)container).RemoveAt(index);
                    ((IList)container).Insert(index + 1, data);

                    listBox.SelectedNode = node;
                }
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedNode != null)
            {
                listBox.LabelEdit = true;
                listBox.SelectedNode.BeginEdit();
            }
        }

        private void copuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data().ID > -1)
            {
                IGameData dt = Data();
                Global.Copy(dt);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addBtn.Visible)
            {
                object obj = Global.PasteData();
                if (obj != null && obj is MapInfo)
                {
                    IGameData data = (IGameData)obj;
                    int d = data.ID;
                    string n = data.Name;
                    data.Name = data.Name;
                    data.Category = SelectedCategory;
                    data.ID = Global.GetID(((IDictionary)container));
                    ((IDictionary)container).Add(data.ID, data);
                    int i = 1; bool repeat = true;
                    while (true)
                    {
                        foreach (MapInfo info in Global.Project.MapsInfo.Values)
                        {
                            if (data.Name + i.ToString() == info.Name)
                            {
                                i++; repeat = true;
                                break;
                            }
                        }
                        if (!repeat) break;
                        repeat = false;
                    }
                    data.Name += i.ToString();

                    // New Map
                    MapData scene;
                    if (GameData.Maps.ContainsKey(d))
                        scene = Global.Duplicate<MapData>(GameData.Maps[d]);
                    else
                    {
                        scene = Global.Duplicate<MapData>(Marshal.LoadData<MapData>(Global.Project.Location + ((MapInfo)data).Path + @"\" + n + Extensions.Scene));
                    }
                    scene.Name = data.Name;
                    scene.ID = data.ID;

                    ((MapInfo)data).Path = @"\Maps\";

                    Marshal.SaveObj(scene, Global.Project.Location + ((MapInfo)data).Path + @"\" + ((MapInfo)data).Name + Extensions.Scene, ((MapInfo)data).Path);

                    AddNode(data);
                    return;
                }
                if (obj != null && obj.GetType() == dataType)
                {
                    IGameData data = (IGameData)obj;
                    data.Name = data.Name;
                    if (allowCategs)
                        data.Category = SelectedCategory;
                    else
                        data.Category = 0;
                    if (container is IDictionary)
                    {
                        data.ID = Global.GetID(((IDictionary)container));
                        ((IDictionary)container).Add(data.ID, data);
                    }
                    else if (container is IList)
                    {
                        data.ID = Global.GetID(((IList)container));
                        ((IList)container).Add(data);
                    }
                    AddNode(data);

                    if (dataType == typeof(AnimationAction))
                        Global.CBActions();
                    else if (dataType == typeof(AnimationData))
                        Global.CBAnimations();
                    else if (dataType == typeof(ListData))
                        Global.CBList();
                    else if (dataType == typeof(AudioData))
                        Global.CBAudio();
                    else if (dataType == typeof(Data))
                        Global.CBDatabases();
                    else if (dataType == typeof(EventData))
                        MainForm.eventsExplorer.Setup();
                    else if (dataType == typeof(FontData))
                        Global.CBFonts();
                    else if (dataType == typeof(ItemData))
                        Global.CBItems();
                    else if (dataType == typeof(MenuData))
                        Global.CBMenus();
                    else if (dataType == typeof(SwitchData))
                        Global.CBSwitches();
                    else if (dataType == typeof(TextData))
                        Global.CBTexts();
                    else if (dataType == typeof(VariableData))
                        Global.CBVariables();
                    else if (dataType == typeof(GlobalEventData))
                        Global.CBGlobalEvents();
                    else if (dataType == typeof(StringData))
                        Global.CBStrings();
                    else if (dataType == typeof(ParticleSystemData))
                        Global.CBParticles();
                    else if (dataType == typeof(ItemEffect))
                        Global.CBItems();
                    else if (dataType == typeof(HeroData))
                        Global.CBHeroes();
                    else if (dataType == typeof(EnemyData))
                        Global.CBEnemies();
                    else if (dataType == typeof(EquipmentData))
                        Global.CBEquipments();
                    else if (dataType == typeof(SkillData))
                        Global.CBSkills();
                    else if (dataType == typeof(StateData))
                        Global.CBStates();
                    else if (dataType == typeof(ProjectileGroupData))
                        Global.CBProjectiles();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void findToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            tsSearch.Visible = findToolStripMenuItem.Checked;
            tsSearch.BringToFront();
            listBox.BringToFront();
            txtSearch.Select();
            txtSearch.SelectAll();
            if (tsSearch.Visible)
            {
                txtSearch.Size = new Size(tsSearch.Width - 4, txtSearch.Height);
                txtSearch.Focus();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            txtSearch.Size = new Size(tsSearch.Width - 4, txtSearch.Height);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                findToolStripMenuItem.Checked = !findToolStripMenuItem.Checked;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Filter
            SetupList(container, dataType);

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                IEnumerable list = container;
                if (list is IDictionary)
                    list = ((IDictionary)list).Values;
                foreach (IGameData data in list)
                {
                    if (data.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        Select(data.ID);
                        break;
                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        internal T GetDataAt<T>(MouseEventArgs e)
        {
            try
            {
                TreeNode node = listBox.GetNodeAt(new Point(e.X, e.Y));

                if (node != null && node.Tag != null)
                {
                    return Global.GetData<T>(((NodeData)listBox.SelectedNode.Tag).Data.ID, container);
                }
                T data1 = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
                ((IGameData)(object)data1).ID = -10;
                ((IGameData)(object)data1).Name = "Unknown Data";
                return data1;
            }
            catch
            {
                return default(T);
            }
        }
    }

    public class AddRemoveListEventArgs : EventArgs
    {
        public int Index;
        public int Category = 0;
        public int ID;
        public IGameData Data;
        public bool MouseDoubleClicked;

        public AddRemoveListEventArgs(int i)
        {
            Index = i;
        }

    }

    public class NodeData
    {
        public int Index;
        public IGameData Data;

        public NodeData(int index, IGameData data)
        {
            Index = index;
            Data = data;
        }
    }
}
