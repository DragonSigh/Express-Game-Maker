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
using GenericUndoRedo;
using EGMGame.Library;
using EGMGame.Controls.EventControls;
using EGMGame.Controls;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs;

namespace EGMGame.Docking.Editors.Database
{
    public partial class ProjectileEditor : DockContent, IHistory
    {
        public EventProgramData SelectedAction
        {
            get { return addRemoveList1.Data<ProjectileData>().Programs[listBox.SelectedIndex]; }
        }

        bool allowChange = true;

        public ProjectileEditor()
        {
            MainForm.ProjectileHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);

            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

            cbDirections.SelectedIndex = 0;
            cbAnimation.RefreshList(false);
            cbHitAnimation.RefreshList(false);

            cbVarAngle.RefreshList(false);
            cbVarX.RefreshList(false);
            cbVarY.RefreshList(false);

            cbProjectileType.SelectedIndex = 0;

            cbLCenterImage.RefreshList(false, MaterialDataType.Image);
            cbLStartImage.RefreshList(false, MaterialDataType.Image);
            cbLEndImage.RefreshList(false, MaterialDataType.Image);
        }

        private void ProjectileEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.ProjectileHistory[this];

        }

        private void ProjectileEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Projectiles, typeof(ProjectileGroupData));
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Projectiles.Add(data.ID, (ProjectileGroupData)data);
            addRemoveList.AddNode(data);

            Global.CBProjectiles();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Projectiles.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBProjectiles();
        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void ProjectileDataAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<ProjectileData>)hist.Collection).Add((ProjectileData)data);

            if (((List<ProjectileData>)hist.Collection) == addRemoveList.Data<ProjectileGroupData>().Projectiles)
                addRemoveList1.AddNode(data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void ProjectileDataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<ProjectileData>)hist.Collection).Remove((ProjectileData)data);

            if (((List<ProjectileData>)hist.Collection) == addRemoveList.Data<ProjectileGroupData>().Projectiles)
                addRemoveList1.RemoveNode(data);
        }
        /// <summary>
        /// Projectile Changed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void ProjectilePropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (data == addRemoveList1.Data())
                SetupProjectile((ProjectileData)data);
        }
        #endregion

        /// <summary>
        /// Projectile Groups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ca"></param>
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                ProjectileGroupData a = new ProjectileGroupData();
                a.Name = Global.GetName("Projectiles", GameData.Projectiles);
                a.ID = Global.GetID(GameData.Projectiles);
                a.Category = ca.Category;
                GameData.Projectiles.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.ProjectileHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBProjectiles();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "41x002");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Projectiles.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.ProjectileHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Projectiles.Remove(addRemoveList.SelectedID);
                    // 
                    addRemoveList.RemoveSelectedNode();
                    if (GameData.Projectiles.ContainsKey(addRemoveList.SelectedID))
                        Setup(GameData.Projectiles[addRemoveList.SelectedID]);
                    else
                        Setup(null);

                    Global.CBProjectiles();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "41x003");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.Data().ID > -1)
                {
                    Setup(addRemoveList.Data<ProjectileGroupData>());
                }
                else
                {
                    Setup(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "41x004");
            }
        }

        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="data"></param>
        private void Setup(ProjectileGroupData data)
        {
            if (data != null)
            {
                addRemoveList1.SetupList(data.Projectiles, typeof(ProjectileData));
                addRemoveList1.Select((data.Projectiles.Count > 0 ? data.Projectiles[0].ID : -1));
                
                if (data.Projectiles.Count == 0)
                    SetupProjectile(null);
            }
            else
            {
                addRemoveList1.Clear(true);
                SetupProjectile(null);
            }
        }
        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion
        /// <summary>
        /// Projectiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ca"></param>
        private void addRemoveList1_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID < 0)
                return;
            try
            {
                ProjectileData a = new ProjectileData();
                a.Name = Global.GetName("Projectile", addRemoveList.Data<ProjectileGroupData>().Projectiles);
                a.ID = Global.GetID(addRemoveList.Data<ProjectileGroupData>().Projectiles);
                a.Category = ca.Category;
                addRemoveList.Data<ProjectileGroupData>().Projectiles.Add(a);
                int index = addRemoveList.Data<ProjectileGroupData>().Projectiles.IndexOf(a);
                // History
                MainForm.ProjectileHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(ProjectileDataAdded), new DataRemoveDelegate(ProjectileDataRemoved), addRemoveList.Data<ProjectileGroupData>().Projectiles, index));

                addRemoveList1.AddNode(a);

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "41x007");
            }
        }

        private void addRemoveList1_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID < 0)
                return;
            try
            {
                if (addRemoveList1.Data().ID > -1)
                {
                    int index = addRemoveList.Data<ProjectileGroupData>().Projectiles.IndexOf(addRemoveList1.Data<ProjectileData>());

                    // History
                    MainForm.ProjectileHistory[this].Do(new IGameDataRemovedHist(addRemoveList1.Data(), new DataAddDelegate(ProjectileDataAdded), new DataRemoveDelegate(ProjectileDataRemoved), addRemoveList.Data<ProjectileGroupData>().Projectiles, index));

                    addRemoveList.Data<ProjectileGroupData>().Projectiles.Remove(addRemoveList1.Data<ProjectileData>());
                    // 
                    addRemoveList1.RemoveSelectedNode();
                    if (addRemoveList1.Data().ID > -1)
                        SetupProjectile(addRemoveList1.Data<ProjectileData>());
                    else
                        SetupProjectile(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "41x005");
            }
        }

        private void addRemoveList1_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID < 0)
                return;
            try
            {
                if (addRemoveList1.Data().ID > -1)
                {
                    SetupProjectile(addRemoveList1.Data<ProjectileData>());
                }
                else
                {
                    Setup(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "41x006");
            }
        }
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="data"></param>
        private void SetupProjectile(ProjectileData data)
        {
            allowChange = false;
            if (data != null)
            {

                boxAngle.Enabled = boxProgram.Enabled = boxDirection.Enabled = boxDynamics.Enabled = boxAnimation.Enabled = boxDecayTime.Enabled = boxHitAnimation.Enabled =
                     boxPassability.Enabled = boxSettings.Enabled = true;


                cbDirections.SelectedIndex = (int)data.Direction;

                rbAnimation.Checked = !data.OnHitDecay;
                rbFrames.Checked = data.OnHitDecay;
                nudFrames.Value = data.DecayFrames;

                nudHeight.Value = data.HeightPass;

                nudLifetime.Value = data.LifeTime;

                nudSpeed.Value = data.Speed;
                nudBaseAngle.Value = data.Angle;
                asBaseAngle.Angle = data.Angle;

                allowChange = false;

                nudEffectRadius.Value = data.EffectRadius;
                chkStatic.Checked = data.IsStatic;

                cbAnimation.Select(data.AnimationID);
                cbAction.RefreshList(false, cbAnimation.Data());
                cbAction.Select(data.ActionID);

                cbHitAnimation.Select(data.HitAnimationID);
                cbHitAction.RefreshList(false, cbHitAnimation.Data());
                cbHitAction.Select(data.HitActionID);

                chkRepeat.Checked = data.Repeat;

                listBox.SetupList(data.Programs, typeof(EventProgramData));

                cbVarX.Select(data.TargetVarX);
                cbVarY.Select(data.TargetVarY);
                cbVarAngle.Select(data.TargetAngle);

                chkSyncAngleToRotation.Checked = data.SyncAngleToRotation;

                rbFrames.Checked = data.OnHitDecay;
                rbAnimation.Checked = !data.OnHitDecay;

                nudFrames.Value = data.DecayFrames;

                chkFriendlyfire.Checked = data.FriendlyFire;

                nudKnockback.Value = (decimal)data.Knockback;


                nudOffsetAngle.Value = data.OffsetAngle;

                nudoffsetPosX.Value = (decimal)data.OffsetPosition.X;

                nudOffsetPosy.Value = (decimal)data.OffsetPosition.Y;

                nudFrames.Enabled = rbFrames.Checked;

                chkProjectileCol.Checked = data.ProjectileCollision;

                nudAnchorTo.Value = data.AnchorTo;
                nudUseAnchor.Value = data.UseAnchor;

                nudEffectParam.Value = data.IncreaseEffectParamater;

                chkEnvCol.Checked = data.EnvironmentalCollision;

                cbProjectileType.SelectedIndex = data.ProjectileType;
                cbLaserDirection.SelectedIndex = data.LaserDirection;
                cbLStartImage.Select(data.StartImage);
                cbLEndImage.Select(data.EndImage);
                cbLCenterImage.Select(data.CenterImage);
            }
            else
            {
                listBox.Clear(false);

                cbDirections.SelectedIndex = 0;

                chkSyncAngleToRotation.Checked = false;
                chkFriendlyfire.Checked = false;

                rbAnimation.Checked = true;
                rbFrames.Checked = false;
                nudFrames.Value = nudFrames.Minimum;

                nudHeight.Value = nudHeight.Minimum;

                nudLifetime.Value = nudLifetime.Minimum;

                nudSpeed.Value = nudSpeed.Minimum;
                nudBaseAngle.Value = nudBaseAngle.Minimum;
                nudEffectRadius.Value = nudEffectRadius.Minimum;
                chkStatic.Checked = false;

                cbAnimation.RefreshList(false);
                cbAction.RefreshList(false, null);

                cbHitAnimation.RefreshList(false);
                cbHitAction.RefreshList(false, null);

                chkProjectileCol.Checked = false;
                nudEffectParam.Value = 0;

                chkEnvCol.Checked = false;

                boxAngle.Enabled = boxProgram.Enabled = boxDirection.Enabled = boxDynamics.Enabled = boxAnimation.Enabled = boxDecayTime.Enabled = boxHitAnimation.Enabled =
                     boxPassability.Enabled = boxSettings.Enabled = false;
            }
            allowChange = true;
        }
        /// <summary>
        /// Passability
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0)
                return;

            addRemoveList1.Data<ProjectileData>().HeightPass = (int)nudHeight.Value;
        }
        /// <summary>
        /// Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudLifetime_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0)
                return;

            addRemoveList1.Data<ProjectileData>().LifeTime = (int)nudLifetime.Value;
        }

        private void chkDisableMapCollision_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0)
                return;
            addRemoveList1.Data<ProjectileData>().DisableMapCollision = chkDisableMapCollision.Checked;

        }
        /// <summary>
        /// Animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0)
                return;

            addRemoveList1.Data<ProjectileData>().AnimationID = cbAnimation.Data().ID;

            allowChange = false;
            cbAction.RefreshList(false, cbAnimation.Data());
            addRemoveList1.Data<ProjectileData>().ActionID = cbAction.Data().ID;
            allowChange = true;
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0)
                return;
            addRemoveList1.Data<ProjectileData>().ActionID = cbAction.Data().ID;
        }


        /// <summary>
        /// Hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animationComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0)
                return;

            addRemoveList1.Data<ProjectileData>().HitAnimationID = cbHitAnimation.Data().ID;

            allowChange = false;
            cbHitAction.RefreshList(false, cbHitAnimation.Data());
            addRemoveList1.Data<ProjectileData>().ActionID = cbAction.Data().ID;
            allowChange = true;
        }

        private void animationActionComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0)
                return;
            addRemoveList1.Data<ProjectileData>().HitActionID = cbHitAction.Data().ID;

        }


        /// <summary>
        /// Preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {

        }


        private void cbDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCD.Visible = (cbDirections.SelectedIndex == 2);
            panelPos.Visible = (cbDirections.SelectedIndex == 3);
            panelAngle.Visible = (cbDirections.SelectedIndex == 4);
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().Direction = (ProjectileDirectionType)cbDirections.SelectedIndex;
        }

        private void chkStatic_CheckedChanged(object sender, EventArgs e)
        {
            nudSpeed.Enabled = chkStatic.Checked;
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().IsStatic = chkStatic.Checked;
        }

        private void btnPhysics_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            EventPhysicSettingsDialog dialog = new EventPhysicSettingsDialog();
            dialog.Setup(addRemoveList1.Data<ProjectileData>(), MainForm.ProjectileHistory[this], new DataPropertyDelegate(PropertyChanged));
            dialog.ShowDialog();
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().Speed = (int)nudSpeed.Value;
        }

        private void nudEffectRadius_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().EffectRadius = (int)nudEffectRadius.Value;
        }


        private void nudKnockback_Validated(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().Knockback = (float)nudKnockback.Value;
        }

        private void cbVarX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().TargetVarX = cbVarX.Data().ID;
        }

        private void cbVarY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().TargetVarY = cbVarY.Data().ID;
        }

        private void cbVarAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().TargetAngle = cbVarAngle.Data().ID;
        }

        #region Program
        private void listBox_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

        }
        private void listBox_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

        }

        private void listBox_EditItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0 || ca.Index < 0) return;

            switch (addRemoveList1.Data<ProjectileData>().Programs[ca.Index].ProgramCategory)
            {
                case ProgramCategory.Movement:
                    if (addRemoveList1.Data<ProjectileData>().Programs[ca.Index].Code == 0)
                    {
                        ProjectileMovementDialog dialog1 = new ProjectileMovementDialog();
                        dialog1.Programs = addRemoveList1.Data<ProjectileData>().Programs;
                        dialog1.ProgramData = SelectedAction;
                        if (dialog1.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog1.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;
                            Setup();
                        }
                    }
                    else if (addRemoveList1.Data<ProjectileData>().Programs[ca.Index].Code == 1)
                    {
                        ProjectileForceDialog dialog1 = new ProjectileForceDialog();
                        dialog1.Programs = addRemoveList1.Data<ProjectileData>().Programs;
                        dialog1.ProgramData = SelectedAction;
                        if (dialog1.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog1.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;
                            Setup();
                        }
                    }
                    break;
                case ProgramCategory.Other:
                    WaitDialog dialog13 = new WaitDialog();
                    dialog13.Programs = addRemoveList1.Data<ProjectileData>().Programs;
                    dialog13.ProgramData = SelectedAction;
                    if (dialog13.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog13.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;
                        Setup();
                    }
                    break;
            }
        }

        private void listBox_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            if (listBox.listBox.SelectedNodes.Count > 1)
            {
                List<EventProgramData> toRemove = new List<EventProgramData>();
                foreach (TreeNode node in listBox.listBox.SelectedNodes)
                {
                    toRemove.Add(addRemoveList1.Data<ProjectileData>().Programs[node.Index]);
                }
                for (int i = 0; i < toRemove.Count; i++)
                {
                    addRemoveList1.Data<ProjectileData>().Programs.Remove(toRemove[i]);
                }
                listBox.SetupList(addRemoveList1.Data<ProjectileData>().Programs, typeof(EventProgramData));
            }
            else if (listBox.SelectedIndex > -1)
            {
                addRemoveList1.Data<ProjectileData>().Programs.RemoveAt(listBox.SelectedIndex);
                listBox.SetupList(addRemoveList1.Data<ProjectileData>().Programs, typeof(EventProgramData));

            }
        }

        private void listBox_DownItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.SelectedIndex > -1)
            {
                EventProgramData action = SelectedAction;
                // Down
                int i = addRemoveList1.Data<ProjectileData>().Programs.IndexOf(action);
                if (i < addRemoveList1.Data<ProjectileData>().Programs.Count - 1)
                {
                    addRemoveList1.Data<ProjectileData>().Programs.Remove(action);
                    addRemoveList1.Data<ProjectileData>().Programs.Insert(i + 1, action);

                    listBox.SetupList(addRemoveList1.Data<ProjectileData>().Programs, typeof(EventProgramData));

                    listBox.SelectedIndex = i + 1;
                }
            }
        }

        private void listBox_UpItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.SelectedIndex > -1)
            {
                EventProgramData action = SelectedAction;
                // Up
                int i = addRemoveList1.Data<ProjectileData>().Programs.IndexOf(action);
                if (i > 0)
                {
                    addRemoveList1.Data<ProjectileData>().Programs.Remove(action);
                    addRemoveList1.Data<ProjectileData>().Programs.Insert(i - 1, action);

                    listBox.SetupList(addRemoveList1.Data<ProjectileData>().Programs, typeof(EventProgramData));

                    listBox.SelectedIndex = i - 1;
                }
            }

        }

        private void listBox_ItemCheckedState(object sender, EGMGame.Controls.CheckedAddRemoveListEventArgs ca)
        {
            if (ca.Index > -1)
                addRemoveList1.Data<ProjectileData>().Programs[ca.Index].Enabled = ca.Node.Checked;
        }

        private bool listBox_ItemCheckState(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            ProjectileData data = addRemoveList1.Data<ProjectileData>();
            return data.Programs[ca.Index].Enabled;
        }


        private void btnMove_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            // Wait Frames
            ProjectileMovementDialog dialog = new ProjectileMovementDialog();
            dialog.Programs = addRemoveList1.Data<ProjectileData>().Programs;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                EventProgramData action = dialog.ProgramData;
                addRemoveList1.Data<ProjectileData>().Programs.Add(action);
                // Setup
                Setup();
            }
        }

        private void btnApplyForce_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            // Wait Frames
            ProjectileForceDialog dialog = new ProjectileForceDialog();
            dialog.Programs = addRemoveList1.Data<ProjectileData>().Programs;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                EventProgramData action = dialog.ProgramData;
                addRemoveList1.Data<ProjectileData>().Programs.Add(action);
                // Setup
                Setup();
            }
        }

        private void btnExplode_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(addRemoveList1.Data<ProjectileData>().Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 2;
            action.Name = "Explode";
            addRemoveList1.Data<ProjectileData>().Programs.Add(action);
            Setup();
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            // Wait Frames
            WaitDialog dialog = new WaitDialog();
            dialog.Programs = addRemoveList1.Data<ProjectileData>().Programs;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                EventProgramData action = dialog.ProgramData;
                addRemoveList1.Data<ProjectileData>().Programs.Add(action);
                // Setup
                Setup();
            }
        }

        private void Setup()
        {
            listBox.SetupList(addRemoveList1.Data<ProjectileData>().Programs, typeof(EventProgramData));
        }

        private void chkRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().Repeat = chkRepeat.Checked;
        }

        #endregion

        #region Angle
        private void btnTop_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 270;
        }

        private void btnTopRight_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 320;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 0;
        }
        private void btnBotRight_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 45;
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 90;
        }

        private void btnBotLeft_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 140;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 180;
        }

        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 220;
        }
        private void asBaseAngle_AngleChanged()
        {
            if (allowChange)
            {
                allowChange = false;
                nudBaseAngle.Value = (decimal)asBaseAngle.Angle;

                addRemoveList1.Data<ProjectileData>().Angle = (int)nudBaseAngle.Value;
            }
            allowChange = true;
        }

        private void nudBaseAngle_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                allowChange = false;
                asBaseAngle.Angle = (int)nudBaseAngle.Value;

                addRemoveList1.Data<ProjectileData>().Angle = (int)nudBaseAngle.Value;
            }
            allowChange = true;
        }
        #endregion

        public void PropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {

        }

        private void chkSyncAngleToRotation_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().SyncAngleToRotation = chkSyncAngleToRotation.Checked;
        }

        private void rbFrames_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            nudFrames.Enabled = rbFrames.Checked;

            addRemoveList1.Data<ProjectileData>().OnHitDecay = rbFrames.Checked;
        }

        private void rbAnimation_CheckedChanged(object sender, EventArgs e)
        {
            nudFrames.Enabled = rbFrames.Checked;
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().OnHitDecay = rbFrames.Checked;
        }

        private void nudFrames_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().DecayFrames = (int)nudFrames.Value;
        }

        private void chkFriendlyfire_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().FriendlyFire = chkFriendlyfire.Checked;
        }

        private void nudOffsetAngle_Validated(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().OffsetAngle = (int)nudOffsetAngle.Value;

        }

        private void customUpDown1_Validated(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().OffsetPosition.X = (float)nudoffsetPosX.Value;

        }

        private void customUpDown2_Validated(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;

            addRemoveList1.Data<ProjectileData>().OffsetPosition.Y = (float)nudOffsetPosy.Value;

        }

        private void chkProjectileCol_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().ProjectileCollision = chkProjectileCol.Checked;
        }


        internal void ResetProject()
        {
            addRemoveList.SetupList(GameData.Projectiles, typeof(ProjectileGroupData));
        }

        private void nudUseAnchor_Validated(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().UseAnchor = (int)nudUseAnchor.Value;
        }

        private void nudAnchorTo_Validated(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().AnchorTo = (int)nudAnchorTo.Value;
        }

        private void customUpDown1_Validated_1(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().IncreaseEffectParamater = (int)nudEffectParam.Value;
        }

        private void chkEnvCol_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().EnvironmentalCollision = chkEnvCol.Checked;

        }
        
        private void chkTracking_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().TrackingEnabled = chkTracking.Checked;
        }

        private void asBaseAngle_AngleChanged_1()
        {
            nudBaseAngle.Value = asBaseAngle.Angle;
        }

        private void cbProjectileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelProjectile.Visible = cbProjectileType.SelectedIndex == 0;
            panelLaserSettings.Visible = panelLaser.Visible = cbProjectileType.SelectedIndex == 1;
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().ProjectileType = cbProjectileType.SelectedIndex;
        }

        private void cbLStartImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().StartImage = cbLStartImage.Data().ID;
        }

        private void cbLCenterImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().CenterImage = cbLCenterImage.Data().ID;
        }

        private void cbLEndImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            int i = cbLEndImage.Data().ID;
            addRemoveList1.Data<ProjectileData>().EndImage = i;
        }

        private void cbLaserDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().LaserDirection = cbLaserDirection.SelectedIndex;
        }

        private void nudLaserDamage_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList1.Data().ID < 0) return;
            addRemoveList1.Data<ProjectileData>().LaserDamageRate = (int)nudLaserDamage.Value;
        }
    }
}
