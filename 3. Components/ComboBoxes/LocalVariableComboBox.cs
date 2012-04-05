//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    public partial class LocalVariableComboBox : TreeViewComboBox
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public LocalVariableComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public LocalVariableComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(IEvent e, bool memorize)
        {
            // Memorize
            IGameData i = null;
            if (memorize && this.TreeView.SelectedNode != null)
                i = (IGameData)this.TreeView.SelectedNode.Tag;
            this.Nodes.Clear();

            TreeNode firstNode = null;
            TreeNode node;
            // Add Categories
            List<NodeCategory> categories = Global.Project.Categories[typeof(VariableData).ToString()];

            foreach (NodeCategory c in categories)
            {
                TreeNode n = new TreeNode(c.Name);
                this.Nodes.Add(n);
            }
            // Add All Items To list
            if (e != null)
            {
                foreach (VariableData v in e.Variables.Values)
                {
                    if (!(string.IsNullOrEmpty(txtSearch.Text) || e.Name.ToLower().Contains(txtSearch.Text.ToLower())))
                        continue;
                    node = new TreeNode(e.Name);
                    node.Tag = v;
                    this.Nodes[v.Category].Nodes.Add(node);
                    if (firstNode == null)
                        firstNode = node;
                    if (categories[v.Category].Expand)
                        Nodes[v.Category].Expand();
                }
            }
            else
            {
                foreach (VariableData v in GameData.Variables.Values)
                {
                    if (!(string.IsNullOrEmpty(txtSearch.Text) || v.Name.ToLower().Contains(txtSearch.Text.ToLower())))
                        continue;
                    node = new TreeNode(v.Name);
                    node.Tag = v;
                    this.Nodes[v.Category].Nodes.Add(node);
                    if (firstNode == null)
                        firstNode = node;
                    if (categories[v.Category].Expand)
                        Nodes[v.Category].Expand();
                }
            }
            base.RefreshList(memorize);
            // Dump
            if (memorize && i != null)
            {
                Select(i.ID);
            }
            if (firstNode != null && this.TreeView.SelectedNode == null)
                this.SelectedNode = firstNode;
        }
        /// <summary>
        /// Get selected data
        /// </summary>
        /// <returns></returns>
        public VariableData Data()
        {
            if (this.SelectedNode != null && this.SelectedNode.Tag != null)
                return (VariableData)this.SelectedNode.Tag;
            else
            {
                VariableData dd = new VariableData();
                dd.ID = -10;
                dd.Name = "{No Local Variable}";
                return dd;
            }
        }

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
    }
}
