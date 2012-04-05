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
using System.IO;
using EGMGame.Dialogs;

namespace EGMGame.Docking.Editors
{
    public partial class ItemEditor : DockContent, IHistory
    {
        bool allowChange = true;


        public ItemEditor()
        {
            MainForm.ItemHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

            allowChange = false;
            cbOccasion.SelectedIndex = 0;
            cbScope.SelectedIndex = 0;
            cbValueType.SelectedIndex = 0;
            cbProperty.SelectedIndex = 0;
            cbAnimation.RefreshList(true);
            cbParticle.RefreshList(true);
            cbGlobalEvent.RefreshList(true);
            cbEffectScope.SelectedIndex = 0;
            allowChange = true;



            this.tabControl1.ImageList = this.imageList1;
            this.boxAnimation.ImageList = this.imageList1;
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.ColorDepth = ColorDepth.Depth32Bit;
            this.imageList1.Images.Add("lightning.png", global::EGMGame.Properties.Resources.flask);
            this.imageList1.Images.Add("blue_document_list.png", global::EGMGame.Properties.Resources.blue_document_list);
            this.imageList1.Images.Add("film.png", global::EGMGame.Properties.Resources.film);
            this.imageList1.Images.Add("fire.png", global::EGMGame.Properties.Resources.fire1);
            this.imageList1.Images.Add("fire1.png", global::EGMGame.Properties.Resources.fire);
            this.imageList1.Images.SetKeyName(0, "lightning.png");
            this.imageList1.Images.SetKeyName(1, "blue_document_list.png");
            this.imageList1.Images.SetKeyName(2, "film.png");
            this.imageList1.Images.SetKeyName(3, "fire.png");
            this.imageList1.Images.SetKeyName(4, "fire1.png");

            tabPage1.ImageIndex = 2;
            tabPage2.ImageIndex = 4;
            tabPage3.ImageIndex = 0;
            tabPage4.ImageIndex = 1;
            tabPage5.ImageIndex = 3;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.ItemHistory[this];
        }

        private void ItemEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Items, typeof(ItemData));
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
            GameData.Items.Add(data.ID, (ItemData)data);
            addRemoveList.AddNode(data);

            Global.CBItems();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Items.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBItems();
        }
        #endregion

        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                ItemData a = new ItemData();
                a.Name = Global.GetName("Item", GameData.Items);
                a.ID = Global.GetID(GameData.Items);
                a.Category = ca.Category;
                GameData.Items.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.ItemHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                addRemoveList.AddNode(a);

                Global.CBItems();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "21x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Items.ContainsKey(addRemoveList.SelectedID))
                {

                    // History
                    MainForm.ItemHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Items.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Items[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBItems();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "21x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0 && GameData.Items.ContainsKey(ca.ID))
                    SetupProperty(GameData.Items[ca.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "21x007");
            }
        }

        /// <summary>
        /// Setup Items Property
        /// </summary>
        /// <param name="itemData"></param>
        private void SetupProperty(ItemData data)
        {
            if (data != null)
            {
                allowChange = false;
                workSpace.Enabled = true;
                Setup(data.PropertyType);
                SetupIcon(data.Icon);
                // Settings
                itemDesc.Text = data.Description;
                cbConsumable.Checked = data.Consumable;
                cbOccasion.SelectedIndex = (int)data.Usage;
                nudPrice.Value = (decimal)data.Price;
                nudSpeed.Value = (decimal)data.Speed;
                nudSuccess.Value = (decimal)data.SucessRate;
                cbIgnoreDef.Checked = data.IgnoreDefense;
                cbAbsorb.Checked = data.AbsorbeDamage;
                cbScope.SelectedIndex = (int)data.Scope;
                nudRange.Value = (decimal)data.Range;
                chkMustFaceTarget.Checked = data.MustFaceTarget;

                chkCondition.Checked = data.EnableCondition;

                listUsable.Items.Clear();
                ItemTag tag;
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

                SetupEffects(null);
                effectsList.SetupList(data.Effects, typeof(ItemEffect));

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

        private void effectsList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.Data().ID > -10)
                {
                    ItemEffect a = new ItemEffect();
                    ItemData data = addRemoveList.Data<ItemData>();
                    a.Name = Global.GetName("Effect", data.Effects);
                    a.ID = Global.GetID(data.Effects);
                    a.Category = ca.Category;
                    data.Effects.Add(a);
                    int index = a.ID;
                    // History
                    ////MainForm*IGameDataAddedHist(a,addRemoveList.Data<ItemData>(), addRemoveList, this, index));
                    effectsList.AddNode(a);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "21x003");
            }
        }

        private void effectsList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.Data().ID > -10)
                {
                    if (effectsList.SelectedIndex >= 0)
                    {
                        // History
                        /////MainForm*IGameDataRemovedHist(GameData.Items[addRemoveList.SelectedID], GameData.Items, addRemoveList, this, addRemoveList.SelectedIndex));
                        addRemoveList.Data<ItemData>().Effects.Remove(effectsList.Data<ItemEffect>());
                        effectsList.RemoveSelectedNode();

                        if (effectsList.Data().ID > -10)
                            SetupEffects(effectsList.Data<ItemEffect>());
                        else
                            SetupEffects(null);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "21x004");
            }
        }

        private void effectsList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0)
                    SetupEffects(addRemoveList.Data<ItemData>().Effects[ca.ID]);
                else
                    SetupEffects(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "21x006");
            }
        }
        /// <summary>
        /// Setup Effects
        /// </summary>
        /// <param name="itemEffect"></param>
        private void SetupEffects(ItemEffect data)
        {
            if (data != null)
            {
                allowChange = false;
                boxAnimation.Enabled = true;
                boxEffect.Enabled = true;
                boxPar.Enabled = true;

                cbEffectScope.SelectedIndex = (int)data.Scope;
                cbGlobalEvent.Select(data.GlobalEvent);
                nudValue.Value = (decimal)data.Value;
                cbValueType.SelectedIndex = (int)data.ValueType;
                cbProperty.Select(data.Property);
                cbAnimation.Select(data.Animation);
                cbAction.RefreshList(false, cbAnimation.Data());
                cbAction.Select(data.Action);
                cbParticle.Select(data.Particle);

                allowChange = true;
            }
            else
            {
                boxAnimation.Enabled = false;
                boxEffect.Enabled = false;
                boxPar.Enabled = false;
            }
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
            if (!allowChange || effectsList.Data().ID < 0)
                return;

            if (effectsList.Count > 0)
            {
                effectsList.Data<ItemEffect>().Animation = cbAnimation.Data().ID;
            }
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<ItemEffect>().Action = cbAction.Data().ID;
        }


        private void itemDesc_TextChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().Description = itemDesc.Text;
        }

        private void cbParticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<ItemEffect>().Particle = cbParticle.Data().ID;
        }

        private void cbScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().Scope = (ItemScope)cbScope.SelectedIndex;
        }

        private void cbGlobalEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<ItemEffect>().GlobalEvent = cbGlobalEvent.Data().ID;
        }

        private void cbProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<ItemEffect>().Property = cbProperty.Data().ID;
        }

        private void nudValue_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<ItemEffect>().Value = (int)nudValue.Value;
        }

        private void cbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<ItemEffect>().ValueType = (ItemValueType)cbValueType.SelectedIndex;
        }

        private void nudRange_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().Range = (int)nudRange.Value;
        }

        private void cbOccasion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().Usage = (UsageType)cbOccasion.SelectedIndex;
        }

        private void cbConsumable_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().Consumable = cbConsumable.Checked;
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().Price = (int)nudPrice.Value;
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().Speed = (int)nudSpeed.Value;
        }

        private void nudSuccess_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().SucessRate = (int)nudSuccess.Value;
        }

        private void cbIgnoreDef_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().IgnoreDefense = cbIgnoreDef.Checked;
        }

        private void cbAbsorb_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<ItemData>().AbsorbeDamage = cbAbsorb.Checked;
        }
        #endregion

        private void listElements_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listElements.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<ItemData>().Elements.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && Global.Project.Elements.ContainsKey(item.ID) &&
                !addRemoveList.Data<ItemData>().Elements.Contains(item.ID))
            {
                addRemoveList.Data<ItemData>().Elements.Add(item.ID);
            }
        }

        private void listUsable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listUsable.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<ItemData>().UsableBy.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && GameData.Heroes.ContainsKey(item.ID) &&
                !addRemoveList.Data<ItemData>().UsableBy.Contains(item.ID))
            {
                addRemoveList.Data<ItemData>().UsableBy.Add(item.ID);
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

            ItemData item = addRemoveList.Data<ItemData>();
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


        internal void RefreshProperty()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty(addRemoveList.Data<ItemData>());
            }
        }

        private void iconViewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                if (MainForm.chooseMaterialDialog == null)
                    MainForm.chooseMaterialDialog = new EGMGame.Dialogs.ChooseMaterialDialog();
                MainForm.chooseMaterialDialog.Setup(addRemoveList.Data<ItemData>().Icon);
                MainForm.chooseMaterialDialog.ShowDialog();
                if (MainForm.chooseMaterialDialog.IsOK)
                {
                    addRemoveList.Data<ItemData>().Icon = MainForm.chooseMaterialDialog.Icon;
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

        private void cbEffectScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (effectsList.Count > 0)
            {
                if (!allowChange || effectsList.Data().ID < 0)
                    return;
                if (effectsList.Count > 0)
                    effectsList.Data<ItemEffect>().Scope = (EffectScope)cbEffectScope.SelectedIndex;
            }
        }

        private void chkMustFaceTarget_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<ItemData>().MustFaceTarget = chkMustFaceTarget.Checked;
        }

        private void btnAssignAnimation_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                EGMGame.Docking.Editors.Database.HeroActionAssignment2 dialog = new EGMGame.Docking.Editors.Database.HeroActionAssignment2();

                dialog.Setup(addRemoveList.Data<ItemData>());

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    addRemoveList.Data<ItemData>().HeroActions = dialog.Actions;
                }
            }
        }

        internal void ResetProject()
        {
            addRemoveList.SetupList(GameData.Items, typeof(ItemData));

            iconViewer.ResetContentManager();
        }

        private void btnChangeBattlerProp_Click(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            allowChange = false;
            if (addRemoveList.Data<ItemData>().PropertyType == 0)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                addRemoveList.Data<ItemData>().PropertyType = 1;

                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                addRemoveList.Data<ItemData>().PropertyType = 0;
                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            allowChange = true;
            cbProperty.Select(effectsList.Data<ItemEffect>().Property);
        }

        private void Setup(int index)
        {
            if (index == 1)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;

                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;

                cbProperty.RefreshList(GameData.Databases[0], false, DataType.Number);
            }
        }

        private void chkCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<ItemData>().EnableCondition = chkCondition.Checked;
        }

        private void btnCondition_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            DBConditionsDialog dialog = new DBConditionsDialog();
            dialog.ProgramData = addRemoveList.Data<ItemData>().Condition;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addRemoveList.Data<ItemData>().Condition = dialog.ProgramData;
            }
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
                            System.IO.FileInfo file = new System.IO.FileInfo(Path.Combine(Global.Project.Location, m.FileName));
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
                            addRemoveList.Data<ItemData>().Icon = m.ID;
                            SetupIcon(m.ID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "21x005");
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
                dialog.Description = addRemoveList.Data<ItemData>().Description;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    addRemoveList.Data<ItemData>().Description = dialog.Description;                    
                }
            }
        }
    }
}
