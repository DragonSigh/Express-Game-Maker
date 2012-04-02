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

namespace EGMGame.Docking.Editors
{
    public partial class GlobalEventEditor : DockContent, IEditor, IHistory
    {
        public GlobalEventEditor()
        {
            MainForm.GlobalEventHistory[this] = new UndoRedoHistory<IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }
        private void EventEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.GlobalEvents, typeof(GlobalEventData));
        }
       
        private void EventEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.GlobalEventHistory[this];
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.GlobalEvents.Add(data.ID, (GlobalEventData)data);
            addRemoveList.AddNode(data);

            Global.CBGlobalEvents();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.GlobalEvents.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBGlobalEvents();
        }
        #endregion
        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                GlobalEventData a = new GlobalEventData();
                a.Name = Global.GetName("Event", GameData.GlobalEvents);
                a.ID = Global.GetID(GameData.GlobalEvents);
                a.Category = ca.Category;
                GameData.GlobalEvents.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.GlobalEventHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                
                addRemoveList.AddNode(a);
                SetupProperty(a);
                MainForm.eventsExplorer.Setup();
                // Add Page
                eventEditorControl.newBtn_Click(null, null);

                Global.CBGlobalEvents();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "19x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.GlobalEvents.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.GlobalEventHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    
                    GameData.GlobalEvents.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.GlobalEvents[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    MainForm.eventsExplorer.Setup();

                    Global.CBGlobalEvents();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "19x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.GlobalEvents.ContainsKey(e.ID))
                    SetupProperty(GameData.GlobalEvents[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "19x003");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(GlobalEventData obj)
        {
            if (obj != null)
            {
                eventEditorControl.Enabled = true;
                eventEditorControl.SelectedEvent = obj;
            }
            else
            {
                eventEditorControl.SelectedEvent = null;
                eventEditorControl.Enabled = false;
            }
        }


        #region IEditor Members

        public void SetupList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            throw new NotImplementedException();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        internal void ResetProject()
        {
            addRemoveList.SetupList(GameData.GlobalEvents, typeof(GlobalEventData));
        }

        internal void RefreshActivePage()
        {
            if (addRemoveList.Data().ID > -1)
            {
                eventEditorControl.RefreshPage();
            }
        }
    }
}
