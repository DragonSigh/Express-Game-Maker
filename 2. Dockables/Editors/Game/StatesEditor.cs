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

namespace EGMGame.Docking.Editors
{
    public partial class StatesEditor : DockContent, IHistory
    {
        bool allowChange = true;

        public StatesEditor()
        {
            MainForm.StatesHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
            allowChange = false;
            cbValueType.SelectedIndex = 0;
            cbProperty.SelectedIndex = 0;
            cbAnimation.RefreshList(true);
            cbParticle.RefreshList(true);
            cbSettings.SelectedIndex = 0;
            cbTime.SelectedIndex = 0;
            allowChange = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.StatesHistory[this];
        }

        private void ItemEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.States, typeof(StateData));
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
            GameData.States.Add(data.ID, (StateData)data);
            addRemoveList.AddNode(data);

            Global.CBStates();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.States.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBStates();
        }
        #endregion


        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                StateData a = new StateData();
                a.Name = Global.GetName("State", GameData.States);
                a.ID = Global.GetID(GameData.States);
                a.Category = ca.Category;
                GameData.States.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.StatesHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBStates();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x002");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.States.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.StatesHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.States.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.States[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBStates();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x008");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0 && GameData.States.ContainsKey(ca.ID))
                    SetupProperty(GameData.States[ca.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x003");
            }
        }

        /// <summary>
        /// Setup Items Property
        /// </summary>
        /// <param name="itemData"></param>
        private void SetupProperty(StateData data)
        {
            if (data != null)
            {
                allowChange = false;
                workSpace.Enabled = true;
                Setup(data.PropertyType);
                SetupIcon(data.Icon);
                cbSettings.SelectedIndex = (int)data.Settings;



                nudDuration.Value = (decimal)data.Duration;
                nudTime.Value = (decimal)data.Frequency;
                cbTime.SelectedIndex = (int)data.TimeType;
                // Settings
                listElements.Items.Clear();
                ItemTag tag;
                foreach (KeyValuePair<int, string> element in Global.Project.Elements)
                {
                    tag = new ItemTag(element.Key, element.Value);
                    listElements.Items.Add(tag, data.Elements.Contains(element.Key));
                }

                listStates.Items.Clear();
                foreach (StateData state in GameData.States.Values)
                {
                    tag = new ItemTag(state.ID, state.Name);
                    listStates.Items.Add(tag, data.RemoveState.Contains(state.ID));
                }

                SetupEffects(null);
                effectsList.SetupList(data.Effects, typeof(StateEffect));

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
                    StateEffect a = new StateEffect();
                    StateData data = addRemoveList.Data<StateData>();
                    a.Name = Global.GetName("Effect", data.Effects);
                    a.ID = Global.GetID(data.Effects);
                    a.Category = ca.Category;
                    data.Effects.Add(a);
                    int index = a.ID;
                    // History
                    ////MainForm*IGameDataAddedHist(a,addRemoveList.Data<StateData>(), addRemoveList, this, index));
                    effectsList.AddNode(a);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x004");
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
                        addRemoveList.Data<StateData>().Effects.Remove(effectsList.Data<StateEffect>());
                        effectsList.RemoveSelectedNode();
                        if (effectsList.Data().ID > -10)
                            SetupEffects(effectsList.Data<StateEffect>());
                        else
                            SetupEffects(null);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x009");
            }
        }

        private void effectsList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0)
                    SetupEffects(addRemoveList.Data<StateData>().Effects[ca.ID]);
                else
                    SetupEffects(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x005");
            }
        }
        /// <summary>
        /// Setup Effects
        /// </summary>
        /// <param name="itemEffect"></param>
        private void SetupEffects(StateEffect data)
        {
            if (data != null)
            {
                allowChange = false;
                boxAnimation.Enabled = true;
                boxPar.Enabled = true;

                nudValue.Value = (decimal)data.Value;
                cbValueType.SelectedIndex = (int)data.ValueType;
                cbProperty.Select(data.Property);
                cbAnimation.Select(data.Animation);
                cbAction.RefreshList(false, cbAnimation.Data());
                cbAction.Select(data.Animation);
                cbParticle.Select(data.Particle);

                allowChange = true;
            }
            else
            {
                boxAnimation.Enabled = false;
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
                effectsList.Data<StateEffect>().Animation = cbAnimation.Data().ID;
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<StateEffect>().Action = cbAction.Data().ID;
        }

        private void cbParticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<StateEffect>().Particle = cbParticle.Data().ID;
        }
        private void cbProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<StateEffect>().Property = cbProperty.Data().ID;
        }

        private void nudValue_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<StateEffect>().Value = (int)nudValue.Value;
        }

        private void cbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            if (effectsList.Count > 0)
                effectsList.Data<StateEffect>().ValueType = (ItemValueType)cbValueType.SelectedIndex;
        }


        private void cbSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<StateData>().Settings = (StateSettings)cbSettings.SelectedIndex;
        }

        private void cbTime_SelectedIndexChanged(object sender, EventArgs e)
        {

            nudDuration.Enabled = (cbTime.SelectedIndex == 0);
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<StateData>().TimeType = (TimeType)cbTime.SelectedIndex;
        }

        private void nudTime_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<StateData>().Frequency = (int)nudTime.Value;
        }

        private void nudDuration_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            if (addRemoveList.Count > 0)
                addRemoveList.Data<StateData>().Duration = (int)nudDuration.Value;
        }
        #endregion

        private void listElements_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listElements.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<StateData>().Elements.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && Global.Project.Elements.ContainsKey(item.ID) &&
                !addRemoveList.Data<StateData>().Elements.Contains(item.ID))
            {
                addRemoveList.Data<StateData>().Elements.Add(item.ID);
            }
        }


        private void listStates_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            ItemTag item = (ItemTag)listStates.Items[e.Index];

            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                addRemoveList.Data<StateData>().RemoveState.Remove(item.ID);
            }
            else if (e.NewValue == CheckState.Checked && GameData.States.ContainsKey(item.ID) &&
                !addRemoveList.Data<StateData>().RemoveState.Contains(item.ID))
            {
                addRemoveList.Data<StateData>().RemoveState.Add(item.ID);
            }
        }
        
        internal void RefreshProperty()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty(addRemoveList.Data<StateData>());
            }
        }

        private void iconViewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                if (MainForm.chooseMaterialDialog == null)
                    MainForm.chooseMaterialDialog = new EGMGame.Dialogs.ChooseMaterialDialog();
                MainForm.chooseMaterialDialog.Setup(addRemoveList.Data<StateData>().Icon);
                MainForm.chooseMaterialDialog.ShowDialog();
                if (MainForm.chooseMaterialDialog.IsOK)
                {
                    addRemoveList.Data<StateData>().Icon = MainForm.chooseMaterialDialog.Icon;
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

        internal void ResetProject()
        {
            iconViewer.ResetContentManager();
            addRemoveList.SetupList(GameData.States, typeof(StateData));
        }


        private void btnChangeBattlerProp_Click(object sender, EventArgs e)
        {
            if (!allowChange || effectsList.Data().ID < 0)
                return;
            allowChange = false;
            if (addRemoveList.Data<StateData>().PropertyType == 0)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                addRemoveList.Data<StateData>().PropertyType = 1;

                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                addRemoveList.Data<StateData>().PropertyType = 0;
                cbProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            allowChange = true;
            cbProperty.Select(effectsList.Data<StateEffect>().Property);
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
                            addRemoveList.Data<StateData>().Icon = m.ID;
                            SetupIcon(m.ID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "45x006");
            }
        }

        private void addRemoveList_RenameItem(object sender, Controls.AddRemoveListEventArgs ca)
        {
            MainForm.heroEditor.RefreshProperty();
            MainForm.enemyEditor.RefreshProperty();
            MainForm.equipmentEditor.RefreshProperty();
            MainForm.skillsEditor.RefreshProperty();
            MainForm.itemEditor.RefreshProperty();

            listStates.Items.Clear();
            ItemTag tag;
            foreach (StateData state in GameData.States.Values)
            {
                tag = new ItemTag(state.ID, state.Name);
                listStates.Items.Add(tag, addRemoveList.Data<StateData>().RemoveState.Contains(state.ID));
            }
        }


        internal void Unload()
        {
            iconViewer.ResetContentManager();
        }
    }
}
