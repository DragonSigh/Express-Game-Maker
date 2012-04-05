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
    public partial class AttachmentComboBox : TreeViewComboBox
    {
        EventPageData Page;
        /// <summary>
        /// Initialize
        /// </summary>
        public AttachmentComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public AttachmentComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void RefreshList(bool memorize, EventPageData page)
        {
            Page = page;
            RefreshList(memorize);
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
            // Add All Items To list
            foreach (AttachmentJoint att in Page.Attachments)
            {
                if (!(string.IsNullOrEmpty(txtSearch.Text) || att.Name.ToLower().Contains(txtSearch.Text.ToLower())))
                    continue;
                node = new TreeNode(att.Name);
                node.Tag = att;
                this.Nodes.Add(node);
                if (firstNode == null)
                    firstNode = node;
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
        /// Get Selected Event
        /// </summary>
        /// <returns></returns>
        public AttachmentJoint Data()
        {
            if (this.SelectedNode != null && this.SelectedNode.Tag != null)
                return (AttachmentJoint)this.SelectedNode.Tag;
            else
            {
                AttachmentJoint dd = new AttachmentJoint();
                dd.ID = -10;
                dd.Name = "{No Attachment}";
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
                }
            }
        }
    }
}
