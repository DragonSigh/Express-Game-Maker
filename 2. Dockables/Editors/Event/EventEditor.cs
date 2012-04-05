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

namespace EGMGame.Docking.Editors
{
    public partial class EventEditor : DockContent, IHistory, IEditor
    {
        public EventEditor()
        {
            MainForm.EventHistory[this] = new UndoRedoHistory<IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

        }
        private void EventEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Events, typeof(EventData));
            if (selectEvent > -1)
                addRemoveList.Select(selectEvent);
            selectEvent = -1;
        }
        private void EventEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.EventHistory[this];
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Events.Add(data.ID, (EventData)data);
            addRemoveList.AddNode(data);

            Global.CBVariables();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Events.Remove(data.ID);

            addRemoveList.RemoveNode(data);

        }
        #endregion
        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                EventData a = new EventData();
                a.Name = Global.GetName("Event", GameData.Events);
                a.ID = GameData.TemplateEventIDs++;
                a.Category = ca.Category;

                while (GameData.Events.ContainsKey(a.ID))
                {
                    a.ID = GameData.TemplateEventIDs++;
                }
                GameData.Events.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.EventHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);
                SetupProperty(a);
                MainForm.eventsExplorer.Setup();
                // Add Page
                eventEditorControl.newBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "14x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Events.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.EventHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Events.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Events[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    MainForm.eventsExplorer.Setup();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "14x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Events.ContainsKey(e.ID))
                    SetupProperty(GameData.Events[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "14x003");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(EventData obj)
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
            addRemoveList.SetupList(GameData.Events, typeof(EventData));
            MainForm.eventsExplorer.Setup();
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
            eventEditorControl.ResetProject();
            addRemoveList.SetupList(GameData.Events, typeof(EventData));
        }

        internal void Unload()
        {
            eventEditorControl.ResetProject();
        }

        private void EventEditor_Scroll(object sender, ScrollEventArgs e)
        { 
        }

        private void EventEditor_Load(object sender, EventArgs e)
        {

        }

        int selectEvent = -1;
        internal void SelectedEvent(int p)
        {
            selectEvent = p;
            addRemoveList.Select(p);
        }

        internal void RefreshActivePage()
        {
            eventEditorControl.RefreshPage();
        }
    }
}
