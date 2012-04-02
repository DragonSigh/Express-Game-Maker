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
    public partial class SkillsEditor : DockContent, IHistory
    {
        bool allowChange = true;
        public SkillsEditor()
        {
            MainForm.SkillsHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
            allowChange = false;
            cbScope.SelectedIndex = 0;
            cbValueType.SelectedIndex = 0;
            cbProperty.SelectedIndex = 0;
            cbAnimation.RefreshList(true);
            cbParticle.RefreshList(true);
            cbGlobalEvent.RefreshList(true);
            cbEffectScope.SelectedIndex = 0;
            cbCost.SelectedIndex = 0;
            cbProjectiles.RefreshList(false);
            allowChange = true;


            this.tabControl2.ImageList = this.imageList1;
            this.boxAnimation.ImageList = this.imageList1;
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.ColorDepth = ColorDepth.Depth32Bit;
            this.imageList1.Images.Add("lightning.png", global::EGMGame.Properties.Resources.lightning);
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
            tabPage7.ImageIndex = 1;
            tabPage9.ImageIndex = 3;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.SkillsHistory[this];
        }

        private void SkillsEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Skills, typeof(SkillData));
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
            GameData.Skills.Add(data.ID, (SkillData)data);
            addRemoveList.AddNode(data);

            Global.CBSkills();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Skills.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBSkills();
        }
        #endregion

        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                SkillData a = new SkillData();
                a.Name = Global.GetName("Skill", GameData.Skills);
                a.ID = Global.GetID(GameData.Skills);
                a.Category = ca.Category;
                GameData.Skills.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.SkillsHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBSkills();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "43x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Skills.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.SkillsHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Skills.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Skills[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBSkills();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "43x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0 && GameData.Skills.ContainsKey(ca.ID))
                    SetupProperty(GameData.Skills[ca.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "43x003");
            }
        }

        /// <summary>
        /// Setup Items Property
        /// </summary>
        /// <param name="itemData"></param>
        private void SetupProperty(SkillData data)
        {
            if (data != null)
            {
                allowChange = false;
                workSpace.Enabled = true;
                SetupIcon(data.Icon);
                Setup(data.PropertyType);
                // Settings
                itemDesc.Text = data.Description;
                cbScope.SelectedIndex = (int)data.Scope;
                cbCost.SelectedIndex = data.CostID;
                nudCost.Value = (int)data.Cost;
                cbType.SelectedIndex = (int)data.SkillType;
                chkMustFaceTarget.Checked = data.MustFaceTarget;
                cbProjectiles.Select(data.Projectile);
                nudSpeed.Value = (decimal)data.Speed;
                nudKnockback.Value = (decimal)data.Knockback;
                nudRange.Value = (decimal)data.Range;

                chkCondition.Checked = data.EnableCondition;

                listElements.Items.Clear();
                ItemTag tag;
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
                effectsList.SetupList(data.Effects, typeof(SkillEffect));


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

        private void effectsList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.Data().ID > -10)
                {
                    SkillEffect a = new SkillEffect();
                    SkillData data = addRemoveList.Data<SkillData>();
                    a.Name = Global.GetName("Effect", data.Effects);
                    a.ID = Global.GetID(data.Effects);
                    a.Category = ca.Category;
                    data.Effects.Add(a);
                    int index = a.ID;
                    // History
                    ////MainForm*IGameDataAddedHist(a,addRemoveList.Data<SkillData>(), addRemoveList, this, index));
                    effectsList.AddNode(a);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "43x002");
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
                        addRemoveList.Data<SkillData>().Effects.Remove(effectsList.Data<SkillEffect>());
                        effectsList.RemoveSelectedNode();

                        if (effectsList.Data().ID > -10)
                            SetupEffects(effectsList.Data<SkillEffect>());
                        else
                            SetupEffects(null);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "43x002");
            }
        }

        private void effectsList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0)
                    SetupEffects(addRemoveList.Data<SkillData>().Effects[ca.ID]);
                else
                    SetupEffects(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "43x004");
            }
        }
        /// <summary>
        /// Setup Effects
        /// </summary>
        /// <param name="itemEffect"></param>
        private void SetupEffects(SkillEffect data)
        {
            if (data != null)
            {
                allowChange = false;
                boxAnimation.Enabled = true;
                boxEffect.Enabled = true;
                boxPar.Enabled = true;
                boxExtra.Enabled = true;

                nudValue.Value = (decimal)data.Value;
                cbValueType.SelectedIndex = (int)data.ValueType;
                cbProperty.Select(data.Property);
                cbAnimation.Select(data.Animation);
                cbAction.RefreshList(false, cbAnimation.Data());
                cbAction.Select(data.Action);
                cbParticle.Select(data.Particle);
                cbEffectScope.SelectedIndex = (int)data.Scope;

                cbGlobalEvent.Select((int)data.GlobalEvent);

                cbFleeBattle.Checked = data.Flee;
                cbSteal.Checked = data.Steal;
                nudSuccess.Value = (decimal)data.Success;

                allowChange = true;
            }
            else
            {
                boxAnimation.Enabled = false;
                boxEffect.Enabled = false;
                boxPar.Enabled = false;
                boxExtra.Enabled = false;
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
                effectsList.Data<SkillEffect>().Animation = cbAnimation.Data().ID;
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().Action = cbAction.Data().ID;
        }

        private void itemDesc_TextChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<SkillData>().Description = itemDesc.Text;
        }
        private void cbParticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().Particle = cbParticle.Data().ID;
        }

        private void cbScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<SkillData>().Scope = (ItemScope)cbScope.SelectedIndex;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<SkillData>().Knockback = (int)nudKnockback.Value;
        }

        private void cbProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().Property = cbProperty.Data().ID;
        }

        private void nudValue_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().Value = (int)nudValue.Value;
        }

        private void cbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().ValueType = (ItemValueType)cbValueType.SelectedIndex;
        }

        private void nudRange_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<SkillData>().Range = (int)nudRange.Value;
        }

        private void cbSteal_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().Steal = cbSteal.Checked;
        }

        private void cbFleeBattle_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().Flee = cbFleeBattle.Checked;
        }

        private void nudSuccess_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().Success = (int)nudSuccess.Value;
        }

        private void cbGlobalEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<SkillEffect>().GlobalEvent = cbGlobalEvent.Data().ID;
        }
        #endregion

        private void listElements_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listElements.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<SkillData>().Elements.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && Global.Project.Elements.ContainsKey(item.ID) &&
                !addRemoveList.Data<SkillData>().Elements.Contains(item.ID))
            {
                addRemoveList.Data<SkillData>().Elements.Add(item.ID);
            }
        }
        private void listStates_ClickStateSkill(object sender, TreeNode ca)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            int oldIndex = ca.ImageIndex;
            if (ca.ImageIndex < 1)
                ca.ImageIndex++;
            else
                ca.ImageIndex = -1;

            SkillData skill = addRemoveList.Data<SkillData>();
            if (ca.ImageIndex == 0) // add to add list
            {
                skill.RemoveState.Remove((int)ca.Tag);
                if (!skill.InflictState.Contains((int)ca.Tag))
                {
                    skill.InflictState.Add((int)ca.Tag);
                }
            }
            else if (ca.ImageIndex == 1) // add to remove list
            {
                skill.InflictState.Remove((int)ca.Tag);
                if (!skill.RemoveState.Contains((int)ca.Tag))
                {
                    skill.RemoveState.Add((int)ca.Tag);
                }
            }
            else // Remove from both lists
            {
                skill.InflictState.Remove((int)ca.Tag);
                skill.RemoveState.Remove((int)ca.Tag);
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<SkillData>().SkillType = (SkillType)cbType.SelectedIndex;
        }

        internal void RefreshProperty()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty(addRemoveList.Data<SkillData>());
            }
        }

        private void SkillsEditor_Load(object sender, EventArgs e)
        {

        }

        #region IHistory Members

        string IHistory.GetActionName()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void nudCost_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<SkillData>().Cost = (int)nudCost.Value;
        }

        private void cbCost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<SkillData>().CostID = cbCost.SelectedIndex;
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;

            addRemoveList.Data<SkillData>().Speed = (int)nudSpeed.Value;
        }

        private void cbProjectiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<SkillData>().Projectile = cbProjectiles.Data().ID;
        }

        private void cbMustFaceTarget_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;

            addRemoveList.Data<SkillData>().MustFaceTarget = chkMustFaceTarget.Checked;
        }

        private void cbEffectScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (effectsList.Count > 0)
            {
                if (!allowChange || effectsList.Data().ID < 0)
                    return;
                effectsList.Data<SkillEffect>().Scope = (EffectScope)cbEffectScope.SelectedIndex;
            }
        }

        private void btnAssignAnimation_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                EGMGame.Docking.Editors.Database.HeroActionAssignment2 dialog = new EGMGame.Docking.Editors.Database.HeroActionAssignment2();

                dialog.Setup(addRemoveList.Data<SkillData>());

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    addRemoveList.Data<SkillData>().HeroActions = dialog.Actions;
                }
            }
        }

        internal void ResetProject()
        {
            iconViewer.ResetContentManager();
            addRemoveList.SetupList(GameData.Skills, typeof(SkillData));
        }


        private void btnChangeBattlerProp_Click(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            allowChange = false;
            if (addRemoveList.Data<SkillData>().PropertyType == 0)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                addRemoveList.Data<SkillData>().PropertyType = 1;

                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                addRemoveList.Data<SkillData>().PropertyType = 0;
                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            cbProperty.Select(effectsList.Data<SkillEffect>().Property);
            allowChange = true;
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

        private void btnCondition_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            DBConditionsDialog dialog = new DBConditionsDialog();
            dialog.ProgramData = addRemoveList.Data<SkillData>().Condition;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addRemoveList.Data<SkillData>().Condition = dialog.ProgramData;
            }
        }
        private void chkCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            addRemoveList.Data<SkillData>().EnableCondition = chkCondition.Checked;
        }

        private void iconPanel_DoubleClick(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                if (MainForm.chooseMaterialDialog == null)
                    MainForm.chooseMaterialDialog = new EGMGame.Dialogs.ChooseMaterialDialog();
                MainForm.chooseMaterialDialog.Setup(addRemoveList.Data<SkillData>().Icon);
                MainForm.chooseMaterialDialog.ShowDialog();
                if (MainForm.chooseMaterialDialog.IsOK)
                {
                    addRemoveList.Data<SkillData>().Icon = MainForm.chooseMaterialDialog.Icon;
                    SetupIcon(MainForm.chooseMaterialDialog.Icon);
                }
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
                            addRemoveList.Data<SkillData>().Icon = m.ID;
                            SetupIcon(m.ID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "43x005");
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
                dialog.Description = addRemoveList.Data<SkillData>().Description;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    addRemoveList.Data<SkillData>().Description = dialog.Description;
                }
            }
        }
    }
}
