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
using EGMGame.Library;
using GenericUndoRedo;
using EGMGame.Dialogs;

namespace EGMGame.Docking.Editors
{
    public partial class EquipmentEditor : DockContent, IHistory
    {
        bool allowChange = true;

        public EquipmentEditor()
        {
            MainForm.EquipmentHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
            allowChange = false;
            cbValueType.SelectedIndex = 0;
            cbProperty.SelectedIndex = 0;
            cbAnimation.RefreshList(true);
            cbParticle.RefreshList(true);
            cbVisualAni.RefreshList(true);
            cbAmmo.RefreshList(true);
            cbProjectiles.RefreshList(true);
            allowChange = true;

            // 
            // imageList
            // 
            this.tabControl1.ImageList = this.imageList;
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.ColorDepth = ColorDepth.Depth32Bit;
            this.imageList.Images.Add("shield.png", global::EGMGame.Properties.Resources.shield);
            this.imageList.Images.Add("blue_document_list.png", global::EGMGame.Properties.Resources.blue_document_list);
            this.imageList.Images.Add("film.png", global::EGMGame.Properties.Resources.film);
            this.imageList.Images.Add("fire.png", global::EGMGame.Properties.Resources.fire1);
            this.imageList.Images.SetKeyName(0, "shield.png");
            this.imageList.Images.SetKeyName(1, "blue_document_list.png");
            this.imageList.Images.SetKeyName(2, "film.png");
            this.imageList.Images.SetKeyName(3, "fire.png");

            tabPage3.ImageIndex = 0;
            tabPage4.ImageIndex = 1;
            tabPage5.ImageIndex = 2;
            tabPage6.ImageIndex = 3;
        }


        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.EquipmentHistory[this];
        }
        private void ItemEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Equipments, typeof(EquipmentData));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }


        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Equipments.Add(data.ID, (EquipmentData)data);
            addRemoveList.AddNode(data);

            Global.CBEquipments();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Equipments.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBEquipments();
        }
        #endregion
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                EquipmentData a = new EquipmentData();
                a.Name = Global.GetName("Equipment", GameData.Equipments);
                a.ID = Global.GetID(GameData.Equipments);
                a.Category = ca.Category;
                GameData.Equipments.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.EquipmentHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBEquipments();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "13x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Equipments.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.EquipmentHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Equipments.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Equipments[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBEquipments();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "13x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0 && GameData.Equipments.ContainsKey(ca.ID))
                    SetupProperty(GameData.Equipments[ca.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "13x003");
            }
        }

        /// <summary>
        /// Setup Items Property
        /// </summary>
        /// <param name="itemData"></param>
        private void SetupProperty(EquipmentData data)
        {
            if (data != null)
            {
                allowChange = false;
                workSpace.Enabled = true;

                Setup(data.PropertyType);

                SetupIcon(data.Icon);
                // Settings
                itemDesc.Text = data.Description;
                nudPrice.Value = (decimal)data.Price;
                cbIgnoreDef.Checked = data.IgnoreDefense;
                cbCriticalBonus.Checked = data.CriticalBonus;
                cbTwoSlots.Checked = data.TwoSlots;
                cbWhileDef.Checked = data.WhileDefending;
                cbVisualAnchor.Checked = data.VisualAnchor;
                cbPreventCrit.Checked = data.PreventCritical;
                cbAmmo.Select(data.AmmoID);
                cbProjectiles.Select(data.Projectile);
                cbVisualAni.Select(data.VisualAnimation);

                cbType.SelectedIndex = (int)data.EquipType;

                listSlots.Items.Clear();
                ItemTag tag;
                foreach (KeyValuePair<int, string> slot in Global.Project.EquipmentSlots)
                {
                    tag = new ItemTag(slot.Key, slot.Value);
                    listSlots.Items.Add(tag, data.EquipmentSlots.Contains(slot.Key));
                }

                listUsable.Items.Clear();
                foreach (HeroData hero in GameData.Heroes.Values)
                {
                    tag = new ItemTag(hero.ID, hero.Name);
                    listUsable.Items.Add(tag, data.UsableBy.Contains(hero.ID));
                }
                listElements.Items.Clear();
                foreach (KeyValuePair<int, string> element in Global.Project.Elements)
                {
                    tag = new ItemTag(element.Key, element.Value);
                    listElements.Items.Add(tag, data.Elements.Contains(element.Key));
                }

                TreeNode node;
                listStates.Nodes.Clear();
                foreach (StateData state in GameData.States.Values)
                {
                    node = new TreeNode(state.Name);
                    node.Tag = state.ID;
                    if (data.InflictState.Contains(state.ID))
                        node.ImageIndex = 0;
                    else if (data.RemoveState.Contains(state.ID))
                        node.ImageIndex = 1;
                    else
                        node.ImageIndex = -1;
                    listStates.Nodes.Add(node);
                }

                nudValue.Value = (decimal)data.Value;
                cbValueType.SelectedIndex = (int)data.ValueType;
                cbProperty.Select(data.Property);
                cbAnimation.Select(data.Animation);
                cbAction.RefreshList(false, cbAnimation.Data());
                cbAction.Select(data.Action);
                cbParticle.Select(data.Particle);
                // cbPropDamage.Select(data.PropertyToDamage);
                nudKnockback.Value = (decimal)data.Knockback;
                nudRange.Value = (decimal)data.Range;
                nudMash.Value = (decimal)data.Mash;
                nudKnockback.Increment = Math.Min((decimal)Global.Project.DefaultGridSize.X, (decimal)Global.Project.DefaultGridSize.Y);
                nudRange.Increment = Math.Min((decimal)Global.Project.DefaultGridSize.X, (decimal)Global.Project.DefaultGridSize.Y);

                allowChange = true;
            }
            else
            {
                workSpace.Enabled = false;
                SetupIcon(-1);
            }
        }

        /// <summary>
        /// Setup Icon
        /// </summary>
        /// <param name="p"></param>
        private void SetupIcon(int p)
        {
            iconViewer.SelectedMaterial = Global.GetData<MaterialData>(p, GameData.Materials);
        }

        #region Events
        private void cbAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnimation.Data().ID > -1)
            {
                cbAction.RefreshList(true, cbAnimation.Data());
            }
            else
            {
                cbAction.Items.Clear();
            }
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Animation = cbAnimation.Data().ID;
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Action = cbAction.Data().ID;
        }

        private void itemDesc_TextChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Description = itemDesc.Text;
        }

        private void cbParticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Particle = cbParticle.Data().ID;
        }

        private void cbProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Property = cbProperty.Data().ID;
        }

        private void nudValue_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Value = (int)nudValue.Value;
        }

        private void cbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().ValueType = (ItemValueType)cbValueType.SelectedIndex;
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Price = (int)nudPrice.Value;
        }

        private void cbWhileDef_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<EquipmentData>().WhileDefending = cbWhileDef.Checked;
        }

        private void cbIgnoreDef_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().IgnoreDefense = cbIgnoreDef.Checked;
        }

        private void cbCriticalBonus_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<EquipmentData>().CriticalBonus = cbCriticalBonus.Checked;
        }

        private void cbPreventCrit_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().PreventCritical = cbPreventCrit.Checked;
        }

        private void cbTwoSlots_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().TwoSlots = cbTwoSlots.Checked;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().EquipType = (EquipType)cbType.SelectedIndex;
        }

        private void cbVisualAnchor_CheckedChanged(object sender, EventArgs e)
        {
            cbVisualAni.Enabled = cbVisualAnchor.Checked;
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().VisualAnchor = cbVisualAnchor.Checked;
        }

        private void cbVisualAni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().VisualAnimation = cbVisualAni.Data().ID;
        }

        private void nudRange_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Range = (int)nudRange.Value;
        }

        private void nudKnockback_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Knockback = (int)nudKnockback.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Knockback = (int)nudKnockback.Value;
        }

        private void cbAmmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().AmmoID = cbAmmo.Data().ID;

        }
        private void cbProjectiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Projectile = cbProjectiles.Data().ID;
        }

        private void nudMash_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<EquipmentData>().Mash = (int)nudMash.Value;
        }
        #endregion

        private void listElements_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listElements.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<EquipmentData>().Elements.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && Global.Project.Elements.ContainsKey(item.ID) &&
                !addRemoveList.Data<EquipmentData>().Elements.Contains(item.ID))
            {
                addRemoveList.Data<EquipmentData>().Elements.Add(item.ID);
            }
        }

        private void listUsable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listUsable.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<EquipmentData>().UsableBy.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && GameData.Heroes.ContainsKey(item.ID) &&
                !addRemoveList.Data<EquipmentData>().UsableBy.Contains(item.ID))
            {
                addRemoveList.Data<EquipmentData>().UsableBy.Add(item.ID);
            }
        }

        private void stateboxControl_ClickStateItem(object sender, TreeNode ca)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            int oldIndex = ca.ImageIndex;
            if (ca.ImageIndex < 1)
                ca.ImageIndex++;
            else
                ca.ImageIndex = -1;

            EquipmentData item = addRemoveList.Data<EquipmentData>();
            if (ca.ImageIndex == 0) // add to add list
            {
                item.RemoveState.Remove((int)ca.Tag);
                if (!item.InflictState.Contains((int)ca.Tag))
                {
                    item.InflictState.Add((int)ca.Tag);
                }
            }
            else if (ca.ImageIndex == 1) // add to remove list
            {
                item.InflictState.Remove((int)ca.Tag);
                if (!item.RemoveState.Contains((int)ca.Tag))
                {
                    item.RemoveState.Add((int)ca.Tag);
                }
            }
            else // Remove from both lists
            {
                item.InflictState.Remove((int)ca.Tag);
                item.RemoveState.Remove((int)ca.Tag);
            }
        }

        private void listSlots_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listSlots.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<EquipmentData>().EquipmentSlots.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && Global.Project.EquipmentSlots.ContainsKey(item.ID) &&
                !addRemoveList.Data<EquipmentData>().EquipmentSlots.Contains(item.ID))
            {
                addRemoveList.Data<EquipmentData>().EquipmentSlots.Add(item.ID);
            }
            Global.CBEquipments();
        }

        internal void RefreshProperty()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty(addRemoveList.Data<EquipmentData>());
            }
        }

        private void iconViewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                if (MainForm.chooseMaterialDialog == null)
                    MainForm.chooseMaterialDialog = new EGMGame.Dialogs.ChooseMaterialDialog();
                MainForm.chooseMaterialDialog.Setup(addRemoveList.Data<EquipmentData>().Icon);

                MainForm.chooseMaterialDialog.ShowDialog();
                if (MainForm.chooseMaterialDialog.IsOK)
                {
                    addRemoveList.Data<EquipmentData>().Icon = MainForm.chooseMaterialDialog.Icon;
                    SetupIcon(MainForm.chooseMaterialDialog.Icon);
                }
            }
        }

        #region IHistory Members

        string IHistory.GetActionName()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void btnAssignAnimation_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                EGMGame.Docking.Editors.Database.HeroActionAssignment dialog = new EGMGame.Docking.Editors.Database.HeroActionAssignment();

                dialog.Setup(addRemoveList.Data<EquipmentData>());

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    addRemoveList.Data<EquipmentData>().HeroActions = dialog.Actions;
                }
            }
        }

        internal void Setup()
        {
            throw new NotImplementedException();
        }

        private void nudUseAnchor_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<EquipmentData>().UseAnchor = (int)nudUseAnchor.Value;
        }

        private void nudAnchorTo_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<EquipmentData>().AnchorTo = (int)nudUseAnchor.Value;
        }

        internal void ResetProject()
        {
            iconViewer.ResetContentManager();
            addRemoveList.SetupList(GameData.Equipments, typeof(EquipmentData));
        }

        private void btnChangeBattlerProp_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            allowChange = false;
            if (addRemoveList.Data<EquipmentData>().PropertyType == 0)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                addRemoveList.Data<EquipmentData>().PropertyType = 1;

                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
                cbPropDamage.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                addRemoveList.Data<EquipmentData>().PropertyType = 0;
                cbProperty.RefreshList(GameData.Databases[0], false, DataType.Number);
                cbPropDamage.RefreshList(GameData.Databases[0], false, DataType.Number);
            }
            cbProperty.Select(addRemoveList.Data<EquipmentData>().Property);
            allowChange = true;
        }
        private void Setup(int index)
        {
            if (index == 1)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;

                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
                cbPropDamage.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;

                cbProperty.RefreshList(GameData.Databases[0], false, DataType.Number);
                cbPropDamage.RefreshList(GameData.Databases[0], false, DataType.Number);
            }
        }

        private void cbPropDamage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            // if (addRemoveList.Count > 0)
            // addRemoveList.Data<EquipmentData>().PropertyToDamage = cbPropDamage.Data().ID;
        }


        private void iconPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    if (node.Parent != null)
                    {
                        MaterialData m = MainForm.materialExplorer.Data();
                        if (m != null)
                        {
                            System.IO.FileInfo file = new System.IO.FileInfo(System.IO.Path.Combine(Global.Project.Location, m.FileName));
                            string ext = file.Extension.ToLower();
                            if (ext == ".png" || ext == ".bmp" || ext == ".jpg" || ext == ".jpeg")
                                e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }

        private void iconPanel_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (addRemoveList.Data().ID > -1)
                {
                    if (e.Data.GetDataPresent(typeof(TreeNode)))
                    {
                        TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                        MaterialData m = MainForm.materialExplorer.Data();

                        if (m != null)
                        {
                            addRemoveList.Data<EquipmentData>().Icon = m.ID;
                            SetupIcon(m.ID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "13x004");
            }
        }

        internal void Unload()
        {
            iconViewer.ResetContentManager();
        }

        private void btnDesc_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                DescriptionDialog dialog = new DescriptionDialog();
                dialog.Description = addRemoveList.Data<EquipmentData>().Description;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    addRemoveList.Data<EquipmentData>().Description = dialog.Description;
                }
            }
        }

        private void impactGroupBox9_Enter(object sender, EventArgs e)
        {

        }
    }
}
