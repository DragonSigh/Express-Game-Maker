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

namespace EGMGame.Docking.Editors
{
    public partial class SwitchesEditor : DockContent, IHistory, IEditor
    {
        public SwitchesEditor()
        {
            MainForm.SwitchesHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);

            InitializeComponent();


            dockContextMenu1.owner = this;
        }

        private void SwitchesEditor_Shown(object sender, EventArgs e)
        {
            SetupList();
        }
        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Switches, typeof(SwitchData));
        }

        private void SwitchesEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.SwitchesHistory[this];
            SetupList();
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Switches.Add(data.ID, (SwitchData)data);
            addRemoveList.AddNode(data);

            Global.CBSwitches();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Switches.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBSwitches();
        }
        #endregion

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                SwitchData a = new SwitchData();
                a.Name = Global.GetName("Switch", GameData.Switches);
                a.ID = Global.GetID(GameData.Switches);
                a.Category = ca.Category;
                GameData.Switches.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.SwitchesHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                
                addRemoveList.AddNode(a);

                Global.CBSwitches();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "47x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Switches.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.SwitchesHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    
                    GameData.Switches.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Switches[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBSwitches();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "47x003");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Switches.ContainsKey(e.ID))
                    SetupProperty(GameData.Switches[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "47x002");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(SwitchData obj)
        {
            if (obj != null)
            {
                valueBox.Checked = obj.State;
                valueBox.Enabled = true;
            }
            else
            {
                valueBox.Checked = false;
                valueBox.Enabled = false;
            }
        }
        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void valueBox_CheckedChanged(object sender, EventArgs e)
        {
            if (addRemoveList.SelectedIndex > -1 && GameData.Switches.ContainsKey(addRemoveList.SelectedID))
            {
                GameData.Switches[addRemoveList.SelectedID].State = valueBox.Checked;
            }
        }

        internal void ResetProject()
        {
            SetupList();
        }
    }
}
