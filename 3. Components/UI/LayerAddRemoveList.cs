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

namespace EGMGame.Controls
{
    public partial class LayeredAddRemoveList : UserControl, IAddRemoveList
    {
        #region "Event Declarations"
        public delegate void AddItemEvent(object sender, AddRemoveListEventArgs ca);
        public event AddItemEvent AddItem;
        public delegate void RemoveItemEvent(object sender, AddRemoveListEventArgs ca);
        public event RemoveItemEvent RemoveItem;
        public delegate void SelectItemEvent(object sender, AddRemoveListEventArgs ca);
        public event SelectItemEvent SelectItem;
        public delegate bool ItemCheckStateEvent(object sender, AddRemoveListEventArgs ca);
        public event ItemCheckStateEvent ItemCheckState;
        public delegate void ItemCheckedStateEvent(object sender, CheckedAddRemoveListEventArgs ca);
        public event ItemCheckedStateEvent ItemCheckedState;
        public delegate void UpItemEvent(object sender, AddRemoveListEventArgs ca);
        public event UpItemEvent UpItem;
        public delegate void DownItemEvent(object sender, AddRemoveListEventArgs ca);
        public event DownItemEvent DownItem;
        #endregion

        public bool Master
        {
            get { return master; }
            set { master = value; }
        }
        bool master = false;

        public int SelectedIndex
        {
            get {
                if (listBox.SelectedNode != null)
                    return listBox.SelectedNode.Index;
                else
                    return -1;
            }
            set {
                if (value > -1)
                {
                    listBox.SelectedNode = listBox.Nodes[value];

                    AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                    SelectItem(this, ev);
                }
                else
                    listBox.SelectedNode = null;
                }
        }
        public int Count
        {
            get { return listBox.Nodes.Count; }
        }
        [Browsable(false)]
        public IList SelectedList
        {
            get { return selectedList; }
        }
        IList selectedList;

        public TreeNode SelectedNode
        {
            get { return listBox.SelectedNode; }
        }

        TreeNode memorizedNode;

        public LayeredAddRemoveList()
        {
            InitializeComponent();
            this.toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }
        /// <summary>
        /// Add Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            AddItem(this, ev);
        }
        /// <summary>
        /// Remove Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (SelectedIndex >= 0 && listBox.Nodes.Count > 1)
            {
                if (MessageBox.Show("Are you sure you want to delete " + listBox.SelectedNode.Text + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
                    RemoveItem(this, ev);
                }
            }
        }
        /// <summary>
        /// Called when a new item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listbox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            SelectItem(this, ev);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckedAddRemoveListEventArgs ev = new CheckedAddRemoveListEventArgs(e.Node.Index,e.Node);
            ItemCheckedState(this, ev);
        }

        private void moveUpBtn_Click(object sender, EventArgs e)
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            UpItem(this, ev);
        }

        private void moveDownBtn_Click(object sender, EventArgs e)
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            DownItem(this, ev);
        }
        /// <summary>
        /// Sets up listbox from the given list.
        /// </summary>
        /// <param name="list"></param>
        public void SetupList(IEnumerable list, Type T)
        {
            int i = SelectedIndex;
            if (i < 0)
                i = 0;
            listBox.Nodes.Clear();
            this.Enabled = true;
            int j = 0;
            foreach (IGameData data in list)
            {
                TreeNode node = new TreeNode();
                node.Text = data.Name;
                AddRemoveListEventArgs ev = new AddRemoveListEventArgs(j);
                node.Checked = ItemCheckState(this, ev);
                listBox.Nodes.Add(node);
                j++;
            }
            if (i < listBox.Nodes.Count)
                SelectedIndex = i;

            selectedList = (IList)list;
        }
        /// <summary>
        /// Clear listbox.
        /// </summary>
        internal void Clear(bool disable)
        {
            listBox.Nodes.Clear();

            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            SelectItem(this, ev);

            if (disable)
                this.Enabled = false;
        }

        public void ForceIndexChange()
        {
            AddRemoveListEventArgs ev = new AddRemoveListEventArgs(SelectedIndex);
            SelectItem(this, ev);
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox.SelectedNode != null)
            {
                listBox.LabelEdit = true;
                listBox.SelectedNode.BeginEdit();
            }
        }

        private void listBox_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Label))
            {
                ((IGameData)SelectedList[SelectedIndex]).Name = e.Label;
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

        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
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

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedNode != null)
            {
                listBox.LabelEdit = true;
                listBox.SelectedNode.BeginEdit();
            }
        }

        private void btnLayerMovement_Click(object sender, EventArgs e)
        {
            MainForm.mapEditor.mapEditor2.backgroundToolStripMenuItem_Click(null, null);
        }

        private void btnLayerTint_Click(object sender, EventArgs e)
        {
            MainForm.mapEditor.mapEditor2.layersettingsToolStripMenuItem_Click(null, null);
        }
    }
}
