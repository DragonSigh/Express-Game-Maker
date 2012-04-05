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

namespace EGMGame.Docking.Editors
{
    public partial class ListEditor : DockContent, IHistory, IEditor
    {
        public ListEditor()
        {
            MainForm.ListHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }

        private void ListEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Lists, typeof(ListData));
        }

        private void ListEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.ListHistory[this];
            addRemoveList.SetupList(GameData.Lists, typeof(ListData));
        }
        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Lists.Add(data.ID, (ListData)data);
            addRemoveList.AddNode(data);

            Global.CBList();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Lists.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBList();
        }
        #endregion

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                ListData a = new ListData();
                a.Name = Global.GetName("List", GameData.Lists);
                a.ID = Global.GetID(GameData.Lists);
                a.Category = ca.Category;
                GameData.Lists.Add(a.ID,a);
                int index = a.ID;

                // History
                MainForm.ListHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                
                addRemoveList.AddNode(a);

                Global.CBList();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "24x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Lists.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.ListHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    
                    GameData.Lists.Remove(addRemoveList.SelectedID);
                    // 
                    addRemoveList.RemoveSelectedNode();

                    Global.CBList();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "24x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
        }
        #endregion




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
        #region IEditor Members

        public void SetupList()
        {
            throw new NotImplementedException();
        }

        #endregion

        internal void ResetProject()
        {
            addRemoveList.SetupList(GameData.Lists, typeof(ListData));
        }
    }
}
