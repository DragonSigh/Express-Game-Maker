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
    public partial class DataEditor : DockContent, IHistory, IEditor
    {

        public Data ParentData
        {
            get { return parentData; }
            set { parentData = value; }
        }
        Data parentData;

        Data CurrentData
        {
            get
            {
                if (addRemoveList.SelectedIndex >= 0 && ParentData.Datas.ContainsKey(addRemoveList.SelectedID))
                    return ParentData.Datas[addRemoveList.SelectedID];
                else
                    return null;
            }
        }


        public DataEditor()
        {
            try
            {
                MainForm.DataHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
                InitializeComponent();
                dockContextMenu1.owner = this;
                this.TabPageContextMenuStrip = dockContextMenu1;
                this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
                this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
                this.DoubleBuffered = true;
                toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "10x001");
            }
        }

        private void DatabaseEditor_Activated(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Text = ParentData.Name;
                // Set History To This
                MainForm.HistoryExplorer.SelectedHistory = MainForm.DataHistory[this];
                // Select
                addRemoveList.MemorizeIndex();
                SetupList();
                addRemoveList.LoadIndex();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "10x002");
            }
        }

        private void DatabaseEditor_Shown(object sender, EventArgs e)
        {
            SetupList();
        }

        public void SetupList()
        {
            addRemoveList.SetupList(ParentData.Datas, typeof(Data));
        }

        public void SetupData()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty((Data)addRemoveList.Data());
            }
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((Data)hist.Parent).Datas.Add(data.ID, (Data)data);
            addRemoveList.AddNode(data);

            Global.CBDatabases((Data)hist.Parent);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((Data)hist.Parent).Datas.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBDatabases((Data)hist.Parent);
        }
        #endregion

        #region List Events
        /// <summary>
        /// Add new data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ca"></param>
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                Data a = new Data();
                a.Name = Global.GetName(ParentData.Name, ParentData.Datas);
                a.ID = Global.GetID(ParentData.Datas);
                a.Category = ca.Category;
                a.Properties = new List<DataProperty>();
                foreach (DataProperty data in ParentData.Properties)
                {
                    DataProperty d = new DataProperty();
                    d.ID = data.ID;
                    d.Name = data.Name;
                    d.ValueType = data.ValueType;
                    d.Value = data.Value;
                    d.LinkIndex = data.LinkIndex;
                    a.Properties.Add(d);
                }
                ParentData.Datas.Add(a.ID, a);
                // History
                int index = a.ID;
                MainForm.DataHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved), ParentData));
                addRemoveList.AddNode(a);

                Global.CBDatabases(parentData);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "10x003");
            }
        }
        /// <summary>
        /// Remove selected data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && ParentData.Datas.ContainsKey(addRemoveList.SelectedID))
                {
                    // 
                    MainForm.DataHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved), ParentData));
                    ParentData.Datas.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(ParentData.Datas[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBDatabases(parentData);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "10x004");
            }
        }
        /// <summary>
        /// Select data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && ParentData.Datas.ContainsKey(e.ID))
                    SetupProperty(ParentData.Datas[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "10x005");
            }
        }
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(Data obj)
        {
            try
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
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "10x007");
            }
        }
        #endregion

        /// <summary>
        /// Sets up the datasets
        /// </summary>
        private void SetupDataset(Data currentData)
        {
            try
            {
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
                }
                //if (currentData != null)
                //{
                //    foreach (DataProperty a in currentData.Properties)
                //    {
                //        DatasetControl d = new DatasetControl();
                //        d.CurrentData = currentData;
                //        d.Editable = false;
                //        d.Dataset = a;
                //        d.addRemoveList = addRemoveList;
                //        panel.Controls.Add(d);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "10x006");
            }
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

        private void DataEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.DataHistory[this].Clear();
            MainForm.DataHistory.Remove(this);
        }


        internal void Select(int id)
        {
            addRemoveList.Select(id);
        }
    }
}
