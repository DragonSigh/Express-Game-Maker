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
    public partial class EquipmentComboBox : TreeViewComboBox
    {
        public bool Noneable
        {
            get { return noneable; }
            set { noneable = value; }
        }
        bool noneable = true;
        List<EquipmentData> data = new List<EquipmentData>();

        int SlotId = -1;
        /// <summary>
        /// Initialize
        /// </summary>
        public EquipmentComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbEquipemnts.Add(this);
        }
        public EquipmentComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
            Global.CbEquipemnts.Add(this);
        }
        /// <summary>
        /// Refreshes List
        /// </summary>
        public override void RefreshList(bool memorize)
        {
            if (SlotId > -1)
                RefreshList(false, SlotId);
            else
            {
                // Memorize
                IGameData i = null;
                if (memorize && this.TreeView.SelectedNode != null)
                    i = (IGameData)this.TreeView.SelectedNode.Tag;
                this.Nodes.Clear();

                TreeNode firstNode = null;
                TreeNode node;
                int catIndex = 0;
                // Add All Equipments To list
                if (noneable)
                {
                    catIndex = 1;
                    EquipmentData an = new EquipmentData();
                    an.ID = -1;
                    an.Name = "(none)";
                    node = new TreeNode(an.Name);
                    node.Tag = an;
                    firstNode = node;
                    this.Nodes.Add(node);
                }

                // Add Categories
                List<NodeCategory> categories = Global.Project.Categories[typeof(EquipmentData).ToString()];

                foreach (NodeCategory c in categories)
                {
                    TreeNode n = new TreeNode(c.Name);
                    this.Nodes.Add(n);
                }
                foreach (EquipmentData e in GameData.Equipments.Values)
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


        internal void RefreshList(bool memorize, int slotID)
        {
            SlotId = slotID;

            // Memorize
            IGameData i = null;
            if (memorize && this.TreeView.SelectedNode != null)
                i = (IGameData)this.TreeView.SelectedNode.Tag;
            if (this.Nodes == null)
                return;
            this.Nodes.Clear();

            TreeNode firstNode = null;
            TreeNode node;
            int catIndex = 0;
            // Add All Equipments To list
            if (noneable)
            {
                catIndex = 1;
                EquipmentData an = new EquipmentData();
                an.ID = -1;
                an.Name = "(none)";
                node = new TreeNode(an.Name);
                node.Tag = an;
                firstNode = node;
                this.Nodes.Add(node);
            }

            // Add Categories
            List<NodeCategory> categories = Global.Project.Categories[typeof(EquipmentData).ToString()];

            foreach (NodeCategory c in categories)
            {
                TreeNode n = new TreeNode(c.Name);
                this.Nodes.Add(n);
            }
            foreach (EquipmentData e in GameData.Equipments.Values)
            {
                if (e.EquipmentSlots.Contains(slotID))
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
            }
            // Dump
            if (memorize && i != null)
            {
                Select(i.ID);
            }
            if (firstNode != null && this.TreeView.SelectedNode == null)
                this.SelectedNode = firstNode;

            this.Invalidate();
        }
        /// <summary>
        /// Get Selected Equipment
        /// </summary>
        /// <returns></returns>
        public EquipmentData Data()
        {
            if (this.SelectedNode != null && this.SelectedNode.Tag != null)
                return (EquipmentData)this.SelectedNode.Tag;
            else
            {
                EquipmentData dd = new EquipmentData();
                dd.ID = -10;
                dd.Name = "{No Equipment}";
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

            Global.CbEquipemnts.Remove(this);

            base.Dispose(disposing);
        }

        internal void Refresh(int p)
        {
            if (SlotId > -1)
                RefreshList(false, SlotId);
            else
                RefreshList(false);
            Select(p);
        }
    }
}
