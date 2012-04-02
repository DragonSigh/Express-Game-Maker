using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace EGMGame.Docking.Explorers
{
    public partial class MenuPartsExplorer : DockContent
    {
        public MenuPartsExplorer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Occurs when an item from the toolbox is dragged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBox_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode n = (TreeNode)e.Item;
            if (n.Parent != null)
                DoDragDrop(n, DragDropEffects.All);
        }
        private void toolBox_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = toolBox.GetNodeAt(e.Location);
            if (node != null)
                toolBox.SelectedNode = node;
        }

        internal void ResetProject()
        {

        }

        private void btnMenuEditor_Click(object sender, EventArgs e)
        {
            if (MainForm.menuEditor != null)
                MainForm.menuEditor.Show();
        }
    }
}
