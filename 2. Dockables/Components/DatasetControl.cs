//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.Collections;
using EGMGame.Controls;

namespace EGMGame.Docking.Database
{
    public partial class DatasetControl : UserControl
    {

        public DataProperty Dataset
        {
            get { return dataset; }
            set { dataset = value; Setup(); }
        }
        DataProperty dataset;

        public bool Editable
        {
            get { return editable; }
            set { editable = value; SetupEdit(); }
        }
        bool editable = true;

        public AddRemoveList addRemoveList
        {
            get { return arList; }
            set { arList = value; }
        }
        AddRemoveList arList;


        Control _control;

        private void SetupEdit()
        {
            if (editable == false)
            {
                deleteBtn.Visible = false;
                vScrollBar1.Visible = false;
                name.Visible = false;
                label.Visible = true;
            }
        }
        /// <summary>
        ///  Doooo link
        /// </summary>
        public Data CurrentData
        {
            get { return curData; }
            set { curData = value; }
        }
        Data curData;

        bool allowChange = true;

        public DatasetControl()
        {
            InitializeComponent();
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
        }
        /// <summary>
        /// Sets up the dataset control.
        /// </summary>
        internal void Setup()
        {
            name.Text = dataset.Name;
            label.Text = dataset.Name;
            switch (dataset.ValueType)
            {
                case DataType.Text:
                    SetupText();
                    break;
                case DataType.Number:
                    SetupNumber();
                    break;
                case DataType.Link:
                    SetupLink();
                    break;
                case DataType.List:
                    SetupList();
                    break;
            }
        }
        /// <summary>
        /// Setuplist
        /// </summary>
        private void SetupList()
        {
            Label ctrl = (Label)_control;
            if (_control == null) ctrl = new Label();
            List<int> list = (List<int>)dataset.Value;
            if (list.Count > 0)
            {
                string firstVal = "Base: [" + list[0].ToString() + "]";
                string lastVal = " Last: [" + list[list.Count - 1].ToString() + "]";
                string count = " Count: [" + list.Count.ToString() + "]";
                ctrl.Text = firstVal + lastVal + count;
            }
            else
            {
                ctrl.Text = "Empty. Double Click to set value.";
            }
            // Add Control 
            if (_control == null)
            {
                splitContainer.Panel2.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Fill;
                ctrl.DoubleClick += new EventHandler(valueList_Click);
                ctrl.MouseHover += new EventHandler(valueList_MouseHover);
                ctrl.MouseLeave += new EventHandler(valueList_MouseLeave);
            }
            ctrl.ForeColor = Color.Red;

            ctrl.ContextMenuStrip = contextMenu;

            _control = ctrl;
        }
        /// <summary>
        /// Setup Link
        /// </summary>
        private void SetupLink()
        {
            try
            {
                ComboBox ctrl = _control as ComboBox;
                if (_control == null) ctrl = new ComboBox();
                ctrl.DropDownStyle = ComboBoxStyle.DropDownList;
                ctrl.BackColor = Color.White;
                // Populate with Datas
                if (editable)
                {
                    PopulateComboBox(ctrl, GameData.Databases);
                    if (Global.GetData<Data>((int)dataset.Value, GameData.Databases) != null)
                    {
                        ctrl.SelectedIndex = ctrl.Items.IndexOf(Global.GetData<Data>((int)dataset.Value, GameData.Databases).Name);
                    }
                }
                else
                {
                    PopulateComboBox(ctrl, GameData.Databases[dataset.LinkIndex].Datas);
                    if (Global.GetData<Data>((int)dataset.Value, GameData.Databases[dataset.LinkIndex].Datas) != null)
                    {
                        ctrl.SelectedIndex = ctrl.Items.IndexOf(Global.GetData<Data>((int)dataset.Value, GameData.Databases[dataset.LinkIndex].Datas).Name);
                    }
                }
                if (_control == null)
                {
                    // Add Control 
                    splitContainer.Panel2.Controls.Add(ctrl);
                    ctrl.Dock = DockStyle.Fill;
                    ctrl.LostFocus += new EventHandler(valueLink_Changed);

                }
                _control = ctrl;
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "11x001");
            }
        }
        /// <summary>
        /// Populate Combobox
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="list"></param>
        private void PopulateComboBox(ComboBox ctrl, IDictionary list)
        {
            ctrl.Items.Clear();
            foreach (IGameData data in list.Values)
            {
                ctrl.Items.Add(data.Name);
            }
        }
        /// <summary>
        /// Setup Number
        /// </summary>
        private void SetupNumber()
        {
            NumericUpDown ctrl = _control as NumericUpDown;
            if (_control == null) ctrl = new NumericUpDown();
            ctrl.Maximum = (decimal)9999;
            ctrl.Minimum = (decimal)-9999;
            ctrl.BackColor = Color.White;
            ctrl.Value = (int)dataset.Value;
            // Add Control 
            if (_control == null)
            {
                splitContainer.Panel2.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Fill;
                ctrl.LostFocus += new EventHandler(valueNum_Changed);
            }

            _control = ctrl;
        }
        /// <summary>
        /// Setup Text
        /// </summary>
        private void SetupText()
        {
            TextBox ctrl = _control as TextBox;
            if (_control == null) ctrl = new TextBox();
            ctrl.BackColor = Color.White;
            ctrl.Text = dataset.Value.ToString();
            // Add Control 

            if (_control == null)
            {
                splitContainer.Panel2.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Fill;
                ctrl.LostFocus += new EventHandler(valueText_Changed);
            }

            _control = ctrl;
        }
        /// <summary>
        /// Value List Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueList_Click(object sender, EventArgs e)
        {
            DatasetListDialog dialog = new DatasetListDialog();
            dialog.Setup((List<int>)dataset.Value);
            dialog.Text = dataset.Name;
            if (DialogResult.OK == dialog.ShowDialog(this.Parent.Parent))
            {
                dataset.Value = dialog.curveList;

                List<int> list = (List<int>)dataset.Value;
                if (list.Count > 0)
                {
                    string firstVal = "Base: [" + list[0].ToString() + "]";
                    string lastVal = " Last: [" + list[list.Count - 1].ToString() + "]";
                    string count = " Count: [" + list.Count.ToString() + "]";
                    splitContainer.Panel2.Controls[0].Text = firstVal + lastVal + count;
                }
                else
                {
                    splitContainer.Panel2.Controls[0].Text = "Empty. Double Click to set value.";
                }

            }
        }
        /// <summary>
        /// Value List Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        GraphDisplayDialog gdialog;
        private void valueList_MouseHover(object sender, EventArgs e)
        {
            if (gdialog == null || !gdialog.Visible || gdialog.IsDisposed)
            {
                gdialog = new GraphDisplayDialog();
                gdialog.Dataset = dataset;
                gdialog.Setup((List<int>)dataset.Value);
                gdialog.StartPosition = FormStartPosition.Manual;
                gdialog.Location = new Point(((Control)sender).PointToScreen(((Control)sender).Location).X + 50, ((Control)sender).PointToScreen(((Control)sender).Location).Y + 20);//new Point(splitContainer.Panel1.Width + this.Location.X ,this.Location.Y);
                gdialog.Show();
            }
            //else
            //{
            //    if (gdialog.Dataset != dataset)
            //        gdialog.Close();
            //}
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    dataset.Value = dialog.curveList;

            //    List<int> list = (List<int>)dataset.Value;
            //    if (list.Count > 0)
            //    {
            //        string firstVal = "Base: [" + list[0].ToString() + "]";
            //        string lastVal = " Last: [" + list[list.Count - 1].ToString() + "]";
            //        string count = " Count: [" + list.Count.ToString() + "]";
            //        splitContainer.Panel2.Controls[0].Text = firstVal + lastVal + count;
            //    }
            //    else
            //    {
            //        splitContainer.Panel2.Controls[0].Text = "Empty. Double Click to set value.";
            //    }
            //}
        }
        /// <summary>
        /// Mouse Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void valueList_MouseLeave(object sender, EventArgs e)
        {
            if (gdialog != null && gdialog.Visible && !gdialog.IsDisposed)
            {
                gdialog.Close();
            }
        }
        /// <summary>
        /// Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueText_Changed(object sender, EventArgs e)
        {
            PropertyDescriptor pd = Global.GetPropertyDescriptor(dataset, "Value");
            //MainForm.HistoryExplorer.SelectedHistory.Do(new IGameDataChangePropertyHist(dataset, CurrentData.Properties, addRemoveList, null, pd, dataset.Value, ((TextBox)sender).Text));
            dataset.Value = ((TextBox)sender).Text;
        }
        /// <summary>
        /// Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueNum_Changed(object sender, EventArgs e)
        {
            PropertyDescriptor pd = Global.GetPropertyDescriptor(dataset, "Value");
            //MainForm.HistoryExplorer.SelectedHistory.Do(new IGameDataChangePropertyHist(dataset, CurrentData.Properties, addRemoveList, null, pd, dataset.Value, ((NumericUpDown)sender).Value));
            dataset.Value = (int)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueLink_Changed(object sender, EventArgs e)
        {
            try
            {
                if (((ComboBox)sender).SelectedIndex > -1)
                {
                    if (editable)
                    {
                        PropertyDescriptor pd = Global.GetPropertyDescriptor(dataset, "Value");
                        int i = Global.GetDataFromIndex(((ComboBox)sender).SelectedIndex, GameData.Databases).ID;
                        //MainForm.HistoryExplorer.SelectedHistory.Do(new IGameDataChangePropertyHist(dataset, CurrentData.Properties, addRemoveList, null, pd, dataset.Value, i));
                        dataset.Value = i;
                        dataset.LinkIndex = (int)i;
                        // Change Link 
                        foreach (Data data in CurrentData.Datas.Values)
                        {
                            foreach (DataProperty dset in data.Properties)
                            {
                                if (dset.ID == dataset.ID)
                                    dset.LinkIndex = dataset.LinkIndex;
                            }
                        }
                    }
                    else
                    {
                        PropertyDescriptor pd = Global.GetPropertyDescriptor(dataset, "Value");
                        int i = Global.GetDataFromIndex(((ComboBox)sender).SelectedIndex, GameData.Databases[dataset.LinkIndex].Datas).ID;
                        //MainForm.HistoryExplorer.SelectedHistory.Do(new IGameDataChangePropertyHist(dataset, CurrentData.Properties, addRemoveList, null, pd, dataset.Value, i));
                        dataset.Value = i;
                    }
                }

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "11x002");
            }
        }
        /// <summary>
        /// Name Text Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text) != true)
            {
                dataset.Name = name.Text;
                // Change The name of the dataset in real data
                foreach (Data data in CurrentData.Datas.Values)
                {
                    foreach (DataProperty dset in data.Properties)
                    {
                        if (dset.ID == dataset.ID)
                            dset.Name = dataset.Name;
                    }
                }
            }
            else
                name.Text = dataset.Name;
        }
        /// <summary>
        /// Scroll Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (allowChange)
            {
                // Up
                if (e.NewValue == 0)
                {
                    int i = curData.Properties.IndexOf(dataset);
                    if (curData.ID == 0 && i < 16)
                        return;
                    if (curData.ID == 1 && i < 13)
                        return;
                    if (i > 0)
                    {
                        curData.Properties.Remove(dataset);
                        curData.Properties.Insert(i - 1, dataset);
                        ((DatabaseEditor)(Parent.Parent.Parent)).SetupData();


                        // Change The place of the dataset in real data
                        foreach (Data data in CurrentData.Datas.Values)
                        {
                            // Get Dataset
                            DataProperty dset = data.Properties[i];
                            data.Properties.Remove(dset);
                            data.Properties.Insert(i - 1, dset);
                        }
                    }
                }
                // Down
                else if (e.NewValue == 1)
                {
                    int i = curData.Properties.IndexOf(dataset);
                    if (curData.ID == 0 && i < 15)
                        return;
                    if (curData.ID == 1 && i < 12)
                        return;
                    if (i < curData.Properties.Count - 1)
                    {
                        curData.Properties.Remove(dataset);
                        curData.Properties.Insert(i + 1, dataset);
                        ((DatabaseEditor)(Parent.Parent.Parent)).SetupData();
                        // Change The pos of the dataset in real data
                        foreach (Data data in CurrentData.Datas.Values)
                        {
                            // Get Dataset
                            DataProperty dset = data.Properties[i];
                            data.Properties.Remove(dset);
                            data.Properties.Insert(i + 1, dset);
                        }
                    }
                }
                allowChange = false;
            }
            else
                allowChange = true;
        }
        /// <summary>
        /// On Remove.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (deleteBtn.Visible)
            {
                int i = curData.Properties.IndexOf(dataset);
                if (curData.ID == 0 && i < 15)
                    return;
                if (curData.ID == 1 && i < 12)
                    return;
                if (MessageBox.Show("Are you sure you want to delete property " + dataset.Name + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    curData.Properties.Remove(dataset);
                    //((DatabaseEditor)(Parent.Parent.Parent)).SetupData();

                    this.Parent.Controls.Remove(this);

                    List<DataProperty> removed = new List<DataProperty>();
                    // Change The name of the dataset in real data
                    foreach (Data data in CurrentData.Datas.Values)
                    {
                        removed.Add(data.Properties[i]);
                        data.Properties.Remove(data.Properties[i]);
                    }

                    // History
                    MainForm.HistoryExplorer.SelectedHistory.Do(new DatasetRemovedHist(dataset, CurrentData, removed, CurrentData.Properties, addRemoveList, null, i));
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Copy(dataset);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object data = Global.PasteData();

            if (data is DataProperty)
            {
                dataset.Value = ((DataProperty)data).Value;

                List<int> list = (List<int>)dataset.Value;
                if (list.Count > 0)
                {
                    string firstVal = "Base: [" + list[0].ToString() + "]";
                    string lastVal = " Last: [" + list[list.Count - 1].ToString() + "]";
                    string count = " Count: [" + list.Count.ToString() + "]";
                    splitContainer.Panel2.Controls[0].Text = firstVal + lastVal + count;
                }
                else
                {
                    splitContainer.Panel2.Controls[0].Text = "Empty. Double Click to set value.";
                }
            }
        }

        internal void Reset()
        {
            _control = null;
            splitContainer.Panel2.Controls.Clear();
        }
    }
}
