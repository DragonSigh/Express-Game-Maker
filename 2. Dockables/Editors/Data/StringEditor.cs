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
    public partial class StringEditor : DockContent, IHistory, IEditor
    {
        public StringEditor()
        {
            MainForm.StringsHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }

        private void StringsEditor_Shown(object sender, EventArgs e)
        {
            SetupList();
        }
        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Strings, typeof(StringData));
        }

        private void StringsEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.StringsHistory[this];
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
            GameData.Strings.Add(data.ID, (StringData)data);
            addRemoveList.AddNode(data);

            Global.CBStrings();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Strings.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBStrings();
        }
        #endregion

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                StringData a = new StringData();
                a.Name = Global.GetName("String", GameData.Strings);
                a.ID = Global.GetID(GameData.Strings);
                a.Category = ca.Category;
                GameData.Strings.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.StringsHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBStrings();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "46x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Strings.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.StringsHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    
                    GameData.Strings.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Strings[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);
                    Global.CBStrings();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "46x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Strings.ContainsKey(e.ID))
                    SetupProperty(GameData.Strings[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "46x002");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(StringData obj)
        {
            if (obj != null)
            {
                valueBox.Text = obj.Value;
                valueBox.Enabled = true;
            }
            else
            {
                valueBox.Text = "";
                valueBox.Enabled = false;
            }
        }

        private void valueBox_ValueChanged(object sender, EventArgs e)
        {
            if (addRemoveList.SelectedIndex > -1 && GameData.Strings.ContainsKey(addRemoveList.SelectedID))
            {
                GameData.Strings[addRemoveList.SelectedID].Value = valueBox.Text;
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

        internal void ResetProject()
        {
            SetupList();
        }
    }
}
