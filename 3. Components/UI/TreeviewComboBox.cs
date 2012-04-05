//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.Drawing;
using System.Collections;
using System.IO;

namespace EGMGame.Controls
{
    public class TreeViewComboBox : ComboBox
    {
        List<TreeNode> nodeList = new List<TreeNode>();
        IEnumerable container;
        Type dataType;

        public bool AllowCategories
        {
            get { return allowCategs; }
            set
            {
                allowCategs = value;
            }
        }
        bool allowCategs = true;

        ToolStripControlHost treeViewHost;
        ToolStripDropDown dropDown;
        AddRemoveListTreeView treeView;
        IGameData lastData;
        internal ToolStripTextBox txtSearch;

        public TreeViewComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            treeView = new AddRemoveListTreeView();
            //treeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeView.Category = true;
            treeView.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            treeView.ToolboxCategoryOffset = new System.Drawing.Point(20, 0);
            treeView.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            treeView.ToolboxCollapsedImage = global::EGMGame.Properties.Resources.plus16;
            treeView.ToolboxCollapsedImageOffset = new System.Drawing.Point(5, 2);
            treeView.ToolboxExpandedImage = global::EGMGame.Properties.Resources.minus16;
            treeView.ToolboxExpandedImageOffset = new System.Drawing.Point(5, 2);
            treeView.FullRowSelect = true;


            treeView.BorderStyle = BorderStyle.None;

            treeView.MouseDoubleClick += new MouseEventHandler(treeView_MouseClick);

            treeViewHost = new ToolStripControlHost(treeView);

            // create drop down and add it

            dropDown = new ToolStripDropDown();
            txtSearch = new ToolStripTextBox();
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            dropDown.Items.Add(txtSearch);
            dropDown.Items.Add(treeViewHost);

            treeView.Width = 200;
            txtSearch.Size = new Size(treeView.Width, txtSearch.Height);
            treeView.ItemHeight = 20;

            treeView.AfterExpand += new TreeViewEventHandler(treeView_AfterExpand);
            treeView.AfterCollapse += new TreeViewEventHandler(treeView_AfterCollapse);

            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);


        }

        void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dropDown.Hide();                
        }

        void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Filter
            RefreshList(false);

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (this.Nodes != null)
                {
                    for (int i = 0; i < this.Nodes.Count; i++)
                    {
                        if (this.Nodes[i].Tag == null)
                        {
                            for (int j = 0; j < this.Nodes[i].Nodes.Count; j++)
                            {
                                if (((IGameData)this.Nodes[i].Nodes[j].Tag).Name.ToLower().Contains(txtSearch.Text.ToLower()))
                                {
                                    this.treeView.SelectedNode = this.Nodes[i].Nodes[j];
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (((IGameData)this.Nodes[i].Tag).Name.ToLower().Contains(txtSearch.Text.ToLower()))
                            {
                                this.treeView.SelectedNode = this.Nodes[i];
                                break;
                            }
                        }
                    }
                }
            }
        }

        public virtual void Select(int id)
        {
        }

        /// <summary>
        /// Sets up listbox from the given list.
        /// </summary>
        /// <param name="list"></param>
        public virtual void RefreshList(bool memorize)
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

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (lastData != null)
                if (this.Enabled)
                    e.Graphics.DrawString(lastData.Name, e.Font, System.Drawing.Brushes.Black, new System.Drawing.PointF(1, 3));
                else
                    e.Graphics.DrawString(lastData.Name, e.Font, System.Drawing.Brushes.Gray, new System.Drawing.PointF(1, 3));
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            treeView.Focus();
        }

        internal bool AllowChange = true;

        void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Tag != null)
            {
                lastData = ((IGameData)treeView.SelectedNode.Tag);
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
            txtSearch.Size = new Size(treeView.Width, txtSearch.Height);
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
                txtSearch.Text = "";
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
                txtSearch.Size = new Size(treeView.Width, txtSearch.Height);
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

        // Edit: 10:37, remember to dispose the dropdown as it's not in the control collection. 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
