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

namespace EGMGame.Docking.Database
{
    public partial class DatabaseEditor : DockContent, IHistory, IEditor
    {

        Data CurrentData
        {
            get
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Databases.ContainsKey(addRemoveList.SelectedID))
                    return GameData.Databases[addRemoveList.SelectedID];
                else
                    return null;
            }
        }

        public DatabaseEditor()
        {
            try
            {
                MainForm.DatabaseHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
                InitializeComponent();
                dockContextMenu1.owner = this;
                this.TabPageContextMenuStrip = dockContextMenu1;
                this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
                this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);

                toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "9x001");
            }
        }

        private void DatabaseEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.DatabaseHistory[this];
        }

        private void DatabaseEditor_Shown(object sender, EventArgs e)
        {
            SetupList();
        }

        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Databases, typeof(Data));
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Databases.Add(data.ID, (Data)data);
            addRemoveList.AddNode(data);

            Global.CBDatabases();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Databases.Remove(data.ID);
            addRemoveList.RemoveNode(data);

            CMD.RemoveDataEditor(GameData.Databases[addRemoveList.SelectedID]);

            Global.CBDatabases();
        }
        #endregion
        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            Data a = new Data();
            a.Name = Global.GetName("Database", GameData.Databases);
            a.ID = Global.GetID(GameData.Databases);
            a.Category = ca.Category;
            GameData.Databases.Add(a.ID, a);
            // History
            int index = a.ID;
            MainForm.DatabaseHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
            addRemoveList.AddNode(a);

            Global.CBDatabases();

            MainForm.Instance.FillDatabases();
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            if (addRemoveList.Data().ID > 1 && addRemoveList.SelectedIndex >= 0 && GameData.Databases.ContainsKey(addRemoveList.SelectedID))
            {
                if (MessageBox.Show("Are you sure you want to delete " + addRemoveList.Data().Name + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // History
                    MainForm.DatabaseHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                   
                    CMD.RemoveDataEditor(GameData.Databases[addRemoveList.SelectedID]);

                    GameData.Databases.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Databases[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);
                    Global.CBDatabases();
                }
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            if (e.Index >= 0 && GameData.Databases.ContainsKey(e.ID))
                SetupProperty(GameData.Databases[e.ID]);
            else
                SetupProperty(null);
        }
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(Data obj)
        {
            if (obj != null)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
            SetupDataset(obj);
        }
        #endregion

        /// <summary>
        /// Adds a text value data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentData != null)
                {
                    DataProperty a = new DataProperty();
                    a.Name = Global.GetName("Data", CurrentData.Properties);
                    a.ID = Global.GetID(CurrentData.Properties);
                    a.ValueType = DataType.Text;
                    // Add
                    CurrentData.Properties.Add(a);
                    // Add to Real Database
                    foreach (Data d in CurrentData.Datas.Values)
                    {
                        DataProperty b = new DataProperty();
                        b.Name = a.Name;
                        b.ID = a.ID;
                        b.ValueType = a.ValueType;
                        d.Properties.Add(b);
                    }

                    int index = CurrentData.Properties.IndexOf(a);
                    // History
                    MainForm.DatabaseHistory[this].Do(new DatasetAddedHist(a, CurrentData, new List<DataProperty>(), CurrentData.Properties, addRemoveList, this, index));
                    // Refresh DatasetList
                    DatasetControl dc = new DatasetControl();
                    dc.CurrentData = CurrentData;
                    dc.Dataset = a;
                    dc.addRemoveList = addRemoveList;
                    panel.Controls.Add(dc);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "9x002");
            }
        }

        private void addNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentData != null)
                {
                    DataProperty a = new DataProperty();
                    a.Name = Global.GetName("Data", CurrentData.Properties);
                    a.ID = Global.GetID(CurrentData.Properties);
                    a.ValueType = DataType.Number;
                    CurrentData.Properties.Add(a);
                    // Add to Real Database
                    foreach (Data d in CurrentData.Datas.Values)
                    {
                        DataProperty b = new DataProperty();
                        b.Name = a.Name;
                        b.ID = a.ID;
                        b.ValueType = a.ValueType;
                        d.Properties.Add(b);
                    }
                    // History
                    int index = CurrentData.Properties.IndexOf(a);
                    MainForm.DatabaseHistory[this].Do(new DatasetAddedHist(a, CurrentData, new List<DataProperty>(), CurrentData.Properties, addRemoveList, this, index));
                    // Refresh DatasetList
                    DatasetControl dc = new DatasetControl();
                    dc.CurrentData = CurrentData;
                    dc.Dataset = a;
                    dc.addRemoveList = addRemoveList;
                    panel.Controls.Add(dc);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "9x003");
            }
        }
        /// <summary>
        /// Add Link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addDataLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentData != null)
                {
                    DataProperty a = new DataProperty();
                    a.Name = Global.GetName("Data", CurrentData.Properties);
                    a.ID = Global.GetID(CurrentData.Properties);
                    a.ValueType = DataType.Link;
                    CurrentData.Properties.Add(a);
                    // Add to Real Database
                    foreach (Data d in CurrentData.Datas.Values)
                    {
                        DataProperty b = new DataProperty();
                        b.Name = a.Name;
                        b.ID = a.ID;
                        b.ValueType = a.ValueType;
                        d.Properties.Add(b);
                    }
                    // History
                    int index = CurrentData.Properties.IndexOf(a);
                    MainForm.DatabaseHistory[this].Do(new DatasetAddedHist(a, CurrentData, new List<DataProperty>(), CurrentData.Properties, addRemoveList, this, index));
                    // Refresh DatasetList
                    SetupDataset(CurrentData);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "9x005");
            }
        }

        private void addListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentData != null)
                {
                    DataProperty a = new DataProperty();
                    a.Name = Global.GetName("Data", CurrentData.Properties);
                    a.ID = Global.GetID(CurrentData.Properties);
                    a.ValueType = DataType.List;
                    CurrentData.Properties.Add(a);
                    // Add to Real Database
                    foreach (Data d in CurrentData.Datas.Values)
                    {
                        DataProperty b = new DataProperty();
                        b.Name = a.Name;
                        b.ID = a.ID;
                        b.ValueType = a.ValueType;
                        d.Properties.Add(b);
                    }
                    // History
                    int index = CurrentData.Properties.IndexOf(a);
                    MainForm.DatabaseHistory[this].Do(new DatasetAddedHist(a, CurrentData, new List<DataProperty>(), CurrentData.Properties, addRemoveList, this, index));
                    // Refresh DatasetList
                    DatasetControl dc = new DatasetControl();
                    dc.CurrentData = CurrentData;
                    dc.Dataset = a;
                    dc.addRemoveList = addRemoveList;
                    panel.Controls.Add(dc);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "9x004");
            }
        }
        /// <summary>
        /// Sets up the datasets
        /// </summary>
        private void SetupDataset(Data currentData)
        {
            try
            {
                this.panel2.SuspendLayout();
                this.toolStrip1.SuspendLayout();
                this.groupBox1.SuspendLayout();
                panel.SuspendLayout();
                this.SuspendLayout();
                //panel.Controls.Clear();
                if (CurrentData != null)
                {
                    int i = 0;
                    foreach (DatasetControl dc in panel.Controls)
                    {
                        if (i < currentData.Properties.Count)
                        {
                            if (dc.Dataset.ValueType == currentData.Properties[i].ValueType)
                            {
                                dc.CurrentData = CurrentData;
                                dc.addRemoveList = addRemoveList;
                                dc.Dataset = currentData.Properties[i];
                            }
                            else
                            {
                                dc.Reset();
                                dc.CurrentData = CurrentData;
                                dc.addRemoveList = addRemoveList;
                                dc.Dataset = currentData.Properties[i];
                            }
                            i++;
                        }
                    }
                    Control[] controls = new Control[currentData.Properties.Count];

                    for (; i < currentData.Properties.Count; i++)
                    {
                        DatasetControl d = new DatasetControl();
                        d.CurrentData = CurrentData;
                        d.Dataset = currentData.Properties[i];
                        d.addRemoveList = addRemoveList;

                        panel.Controls.Add(d);
                    }
                    //foreach (DataProperty a in currentData.Properties)
                    //{
                    //    DatasetControl d = new DatasetControl();
                    //    d.CurrentData = CurrentData;
                    //    d.Dataset = a;
                    //    d.addRemoveList = addRemoveList;

                    //    controls[i] = d;
                    //    i++;
                    //}
                }
                this.panel2.ResumeLayout(false);
                this.panel2.PerformLayout();
                this.panel.ResumeLayout(false);
                this.panel.PerformLayout();
                this.toolStrip1.ResumeLayout(false);
                this.toolStrip1.PerformLayout();
                this.groupBox1.ResumeLayout(false);
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "9x006");
            }
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            //foreach (Control ctrl in panel.Controls)
            //{
            //    //ctrl.Size = new Size(panel.Width - 10, ctrl.Size.Height);
            //}
        }


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

        internal void SetupData()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty((Data)addRemoveList.Data());
            }
        }

        internal void ResetProject()
        {
            SetupList();
        }
    }
}
