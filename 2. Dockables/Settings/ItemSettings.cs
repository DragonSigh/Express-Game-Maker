//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
using Microsoft.Xna.Framework;

namespace EGMGame.Docking.Settings
{
    public partial class ItemSettingsForm : DockContent
    {

        public ItemSettingsForm()
        {
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            // Load Project
            if (Global.Project != null)
            {
                LoadProject(Global.Project);
            }
        }
        /// <summary>
        /// Load the project settings.
        /// </summary>
        /// <param name="project"></param>
        private void LoadProject(EGMGame.Library.Project project)
        {

            // Add Lists
            listBoxEquip.Nodes.Clear();
            listBoxElem.Nodes.Clear();
            TreeNode node;
            foreach (KeyValuePair<int, string> slot in Global.Project.EquipmentSlots)
            {
                node = new TreeNode();
                node.Text = slot.Value;
                node.Tag = slot.Key;
                listBoxEquip.Nodes.Add(node);
            }

            foreach (KeyValuePair<int, string> slot in Global.Project.Elements)
            {
                node = new TreeNode();
                node.Text = slot.Value;
                node.Tag = slot.Key;
                listBoxElem.Nodes.Add(node);
            }
        }
        

        internal void LoadSettings()
        {
            // Load Project
            if (Global.Project != null)
            {
                LoadProject(Global.Project);
            }
        }

        private void addBtnEquip_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 99999; i++)
            {
                if (!Global.Project.EquipmentSlots.Keys.Contains(i))
                {
                    Global.Project.EquipmentSlots.Add(i, "New Slot" + i.ToString());

                    // Loop All Heroes
                    foreach (HeroData hero in GameData.Heroes.Values)
                    {
                        if (!hero.Equipments.ContainsKey(i))
                            hero.Equipments.Add(i, -1);
                    }
                    // Loop All Enemies
                    foreach (EnemyData enemy in GameData.Enemies.Values)
                    {
                        if (!enemy.Equipments.ContainsKey(i))
                            enemy.Equipments.Add(i, -1);
                    }
                    TreeNode node = new TreeNode("New Slot" + i.ToString());
                    node.Tag = i;
                    listBoxEquip.Nodes.Add(node);

                    MainForm.heroEditor.RefreshProperty();
                    MainForm.enemyEditor.RefreshProperty();
                    break;
                }
            }
        }

        private void removeBtnEquip_Click(object sender, EventArgs e)
        {
            if (listBoxEquip.SelectedNode != null)
            {

                if (MessageBox.Show("Are you sure you want to delete slot?\nYou will not be able to undo this change.", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Loop All Heroes
                    foreach (HeroData hero in GameData.Heroes.Values)
                    {
                        hero.Equipments.Remove((int)listBoxEquip.SelectedNode.Tag);
                    }
                    // Loop All Enemies
                    foreach (EnemyData enemy in GameData.Enemies.Values)
                    {
                        enemy.Equipments.Remove((int)listBoxEquip.SelectedNode.Tag);
                    }
                    // Loop All Equipments
                    foreach (EquipmentData equipment in GameData.Equipments.Values)
                    {
                        equipment.EquipmentSlots.Remove((int)listBoxEquip.SelectedNode.Tag);
                    }
                    Global.Project.EquipmentSlots.Remove((int)listBoxEquip.SelectedNode.Tag);
                    listBoxEquip.SelectedNode.Remove();

                    MainForm.heroEditor.RefreshProperty();
                    MainForm.enemyEditor.RefreshProperty();
                    MainForm.equipmentEditor.RefreshProperty();
                }
            }
        }

        private void addBtnElem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 99999; i++)
            {
                if (!Global.Project.Elements.Keys.Contains(i))
                {
                    Global.Project.Elements.Add(i, "New Element" + i.ToString());
                    TreeNode node = new TreeNode("New Element" + i.ToString());
                    node.Tag = i;
                    listBoxElem.Nodes.Add(node);
                    // 
                    MainForm.heroEditor.RefreshProperty();
                    MainForm.enemyEditor.RefreshProperty();
                    MainForm.equipmentEditor.RefreshProperty();
                    MainForm.statesEditor.RefreshProperty();
                    MainForm.itemEditor.RefreshProperty();
                    MainForm.skillsEditor.RefreshProperty();
                    break;
                }
            }
        }

        private void removeBtnElem_Click(object sender, EventArgs e)
        {
            if (listBoxElem.SelectedNode != null)
            {
                if (MessageBox.Show("Are you sure you want to delete element?\nYou will not be able to undo this change.", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Loop All Heroes
                    foreach (HeroData hero in GameData.Heroes.Values)
                    {
                        hero.Elements.Remove((int)listBoxElem.SelectedNode.Tag);
                    }
                    // Loop All Enemies
                    foreach (EnemyData enemy in GameData.Enemies.Values)
                    {
                        enemy.Equipments.Remove((int)listBoxElem.SelectedNode.Tag);
                    }
                    // Loop All Equipments
                    foreach (EquipmentData equipment in GameData.Equipments.Values)
                    {
                        equipment.Elements.Remove((int)listBoxElem.SelectedNode.Tag);
                    }
                    // Loop All Skills
                    foreach (SkillData skill in GameData.Skills.Values)
                    {
                        skill.Elements.Remove((int)listBoxElem.SelectedNode.Tag);
                    }
                    // Loop All Items
                    foreach (ItemData item in GameData.Items.Values)
                    {
                        item.Elements.Remove((int)listBoxElem.SelectedNode.Tag);
                    }
                    // Loop All States
                    foreach (StateData state in GameData.States.Values)
                    {
                        state.Elements.Remove((int)listBoxElem.SelectedNode.Tag);
                    }
                    Global.Project.Elements.Remove((int)listBoxElem.SelectedNode.Tag);
                    listBoxElem.SelectedNode.Remove();

                    // 
                    MainForm.heroEditor.RefreshProperty();
                    MainForm.enemyEditor.RefreshProperty();
                    MainForm.equipmentEditor.RefreshProperty();
                    MainForm.statesEditor.RefreshProperty();
                    MainForm.itemEditor.RefreshProperty();
                    MainForm.skillsEditor.RefreshProperty();
                }
            }
        }

        private void listBoxEquip_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = listBoxEquip.GetNodeAt(e.Location);
            if (node != null)
                listBoxEquip.SelectedNode = node;
        }

        private void listBoxElem_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = listBoxElem.GetNodeAt(e.Location);
            if (node != null)
                listBoxElem.SelectedNode = node;
        }

        private void listBoxEquip_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                listBoxEquip.LabelEdit = true;
                e.Node.BeginEdit();
            }
        }

        private void listBoxElem_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                listBoxElem.LabelEdit = true;
                e.Node.BeginEdit();
            }
        }

        private void listBoxEquip_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Label))
            {
                if (listBoxEquip.SelectedNode != null)
                {
                    Global.Project.EquipmentSlots[(int)listBoxEquip.SelectedNode.Tag] = e.Label;
                    MainForm.heroEditor.RefreshProperty();
                    MainForm.enemyEditor.RefreshProperty();
                    MainForm.equipmentEditor.RefreshProperty();
                    MainForm.statesEditor.RefreshProperty();
                    MainForm.itemEditor.RefreshProperty();
                    MainForm.skillsEditor.RefreshProperty();
                }
            }
            listBoxEquip.LabelEdit = false;
        }

        private void listBoxElem_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Label))
            {
                if (listBoxElem.SelectedNode != null)
                {
                    Global.Project.Elements[(int)listBoxElem.SelectedNode.Tag] = e.Label;
                    MainForm.heroEditor.RefreshProperty();
                    MainForm.enemyEditor.RefreshProperty();
                    MainForm.equipmentEditor.RefreshProperty();
                    MainForm.statesEditor.RefreshProperty();
                    MainForm.itemEditor.RefreshProperty();
                    MainForm.skillsEditor.RefreshProperty();
                }
            }
            listBoxElem.LabelEdit = false;
        }

        private void impactGroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Float)
            {
                if (this.FloatPane != null)
                {
                    this.FloatPane.FloatWindow.Size = this.MaximumSize;
                }
            }
        }

        private void SettingsForm_DockChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Float)
            {
                if (this.FloatPane != null)
                {
                    this.FloatPane.FloatWindow.Size = this.MaximumSize;
                }
            }
        }

        internal void ResetProject()
        {
            LoadSettings();
        }
    }
}
