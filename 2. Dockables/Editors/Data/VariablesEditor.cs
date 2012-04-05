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
    public partial class VariablesEditor : DockContent, IEditor, IHistory
    {
        bool allowChange = true;

        public VariablesEditor()
        {
            MainForm.VariablesHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);

            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }

        private void VariablesEditor_Shown(object sender, EventArgs e)
        {
            SetupList();
        }
        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Variables, typeof(VariableData));
        }

        private void VariablesEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.VariablesHistory[this];
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
            GameData.Variables.Add(data.ID, (VariableData)data);
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
            GameData.Variables.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBVariables();
        }
        /// <summary>
        /// Data changed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (data == addRemoveList.Data())
            {
                SetupProperty((VariableData)data);
            }
        }
        #endregion

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                VariableData a = new VariableData();
                a.Name = Global.GetName("Variable", GameData.Variables);
                a.ID = Global.GetID(GameData.Variables);
                a.Category = ca.Category;
                GameData.Variables.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.VariablesHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBVariables();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "54x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Variables.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.VariablesHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    
                    GameData.Variables.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Variables[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBVariables();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "54x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Variables.ContainsKey(e.ID))
                    SetupProperty(GameData.Variables[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "54x003");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(VariableData obj)
        {
            if (obj != null)
            {
                allowChange = false;
                valueBox.Value = (decimal)obj.Value;
                valueBox.Enabled = true;
                allowChange = true;
            }
            else
            {
                allowChange = false;
                valueBox.Value = 0;
                valueBox.Enabled = false;
                allowChange = true;
            }
        }

        private void valueBox_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange && addRemoveList.SelectedIndex > -1 && GameData.Variables.ContainsKey(addRemoveList.SelectedID))
            {
                MainForm.VariablesHistory[this].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(DataChanged)));
                GameData.Variables[addRemoveList.SelectedID].Value = (float)valueBox.Value;
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
            addRemoveList.SetupList(GameData.Variables, typeof(VariableData));
        }
    }
}
