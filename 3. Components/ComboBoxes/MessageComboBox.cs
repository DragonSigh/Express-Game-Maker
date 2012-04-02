using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.Game
{
    public partial class MessageComboBox : TreeViewComboBox
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public MessageComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMessages.Add(this);
        }
        public MessageComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMessages.Add(this);
        }
        /// <summary>
        /// Refreshes List
        /// </summary>
        public override void RefreshList(bool memorize)
        {
            // Memorize
            IGameData i = null;
            if (memorize && this.TreeView.SelectedNode != null)
                i = (IGameData)this.TreeView.SelectedNode.Tag;
            this.Nodes.Clear();

            TreeNode firstNode = null;
            TreeNode node;
            // Add Categories
            List<NodeCategory> categories = Global.Project.Categories[typeof(MenuData).ToString()];

            foreach (NodeCategory c in categories)
            {
                TreeNode n = new TreeNode(c.Name);
                this.Nodes.Add(n);
            }
            // Add All Items To list
            foreach (MenuData e in GameData.Menus.Values)
            {
                if (e.IsMessage)
                {
                    if (!(string.IsNullOrEmpty(txtSearch.Text) || e.Name.ToLower().Contains(txtSearch.Text.ToLower())))
                        continue;
                    node = new TreeNode(e.Name);
                    node.Tag = e;
                    this.Nodes[e.Category].Nodes.Add(node);
                    if (firstNode == null)
                        firstNode = node;

                    if (categories[e.Category].Expand)
                        Nodes[e.Category].Expand();
                }
            }
            base.RefreshList(memorize);
            // Dump
            if (memorize && i != null)
                Select(i.ID);
            if (firstNode != null && this.TreeView.SelectedNode == null)
                this.SelectedNode = firstNode;
        }
        /// <summary>
        /// Get selected data
        /// </summary>
        /// <returns></returns>
        public MenuData Data()
        {
            if (this.SelectedNode != null && this.SelectedNode.Tag != null)
                return (MenuData)this.SelectedNode.Tag;
            else
            {
                MenuData dd = new MenuData();
                dd.ID = -10;
                dd.Name = "{No Menu}";
                return dd;
            }
        }
        /// <summary>
        /// ID
        /// </summary>
        /// <param name="p"></param>

        public override void Select(int id)
        {
            if (this.Nodes != null)
            {
                for (int i = 0; i < this.Nodes.Count; i++)
                {
                    if (this.Nodes[i].Tag != null && ((IGameData)this.Nodes[i].Tag).ID == id)
                    {
                        this.SelectedNode = this.Nodes[i]; return;
                    }
                    for (int j = 0; j < this.Nodes[i].Nodes.Count; j++)
                    {
                        if (((IGameData)this.Nodes[i].Nodes[j].Tag).ID == id)
                        {
                            this.SelectedNode = this.Nodes[i].Nodes[j]; return;
                        }
                    }
                }
            }
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
            // Remove from global list
            Global.CbMessages.Remove(this);

            base.Dispose(disposing);
        }


        internal void Refresh(int p)
        {
            RefreshList(false);
            Select(p);
        }
    }
}
