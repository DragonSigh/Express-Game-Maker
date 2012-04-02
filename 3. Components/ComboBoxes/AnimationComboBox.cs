﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.Game
{
    public partial class AnimationComboBox : TreeViewComboBox
    {
        public bool Noneable
        {
            get { return noneable; }
            set { noneable = value; }
        }
        bool noneable = true;
        /// <summary>
        /// Initialize
        /// </summary>
        public AnimationComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
            Global.CbAnimations.Add(this);
        }
        public AnimationComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
            Global.CbAnimations.Add(this);
        }
        /// <summary>
        /// Refreshes List
        /// </summary>
        public override void RefreshList(bool memorize)
        {
            // Memorize
            try
            {
                IGameData i = null;
                if (memorize && this.TreeView.SelectedNode != null)
                    i = (IGameData)this.TreeView.SelectedNode.Tag;
                if (this.Nodes != null)
                {
                    this.Nodes.Clear();

                    TreeNode firstNode = null;
                    TreeNode node;
                    int catIndex = 0;
                    // Add All Items To list
                    if (noneable)
                    {
                        catIndex = 1;
                        AnimationData an = new AnimationData();
                        an.ID = -1;
                        an.Name = "(none)";
                        node = new TreeNode(an.Name);
                        node.Tag = an;
                        firstNode = node;
                        this.Nodes.Add(node);
                    }

                    // Add Categories
                    List<NodeCategory> categories = Global.Project.Categories[typeof(AnimationData).ToString()];

                    foreach (NodeCategory c in categories)
                    {
                        TreeNode n = new TreeNode(c.Name);
                        this.Nodes.Add(n);
                    }
                    foreach (AnimationData e in GameData.Animations.Values)
                    {
                        if (!(string.IsNullOrEmpty(txtSearch.Text) || e.Name.ToLower().Contains(txtSearch.Text.ToLower())))
                            continue;
                        node = new TreeNode(e.Name);
                        node.Tag = e;
                        this.Nodes[e.Category + catIndex].Nodes.Add(node);
                        if (firstNode == null)
                            firstNode = node;

                        if (categories[e.Category].Expand)
                            Nodes[e.Category + catIndex].Expand();
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
            }
            catch { }
        }
        /// <summary>
        /// Get Selected Animation
        /// </summary>
        /// <returns></returns>
        public AnimationData Data()
        {
            if (this.SelectedNode != null && this.SelectedNode.Tag != null)
                return (AnimationData)this.SelectedNode.Tag;
            else
            {
                AnimationData dd = new AnimationData();
                dd.ID = -10;
                dd.Name = "{No Animation}";
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

            Global.CbAnimations.Remove(this);

            base.Dispose(disposing);
        }

        internal void Refresh(int p)
        {
            RefreshList(false);
            Select(p);
        }
    }
}
