//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.Game
{
    public partial class DatabaseComboBox : ComboBox
    {
        public bool Noneable
        {
            get { return noneable; }
            set { noneable = value; }
        }
        bool noneable = false;
        /// <summary>
        /// Initialize
        /// </summary>
        public DatabaseComboBox()
        {
            InitializeComponent();
            Global.CbDatabases.Add(this);
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            this.DrawMode = DrawMode.OwnerDrawFixed;
        }
        public DatabaseComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Global.CbDatabases.Add(this);

            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            e.DrawBackground();
            if (e.Index > -1)
            {
                if (this.Enabled)
                {
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds);
                }
                else
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, System.Drawing.Brushes.Gray, e.Bounds);

                if (e.Index == this.SelectedIndex)
                {
                    e.DrawFocusRectangle();
                }
            }
        }

        Data parentData = null;
        List<IGameData> data = new List<IGameData>();
        /// <summary>
        /// Refreshes List
        /// </summary>
        public  void RefreshList(bool memorize)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();
            if (noneable)
            {
                Data d = new Data();
                d.ID = -1;
                d.Name = "(none)";
                data.Add(d);
                this.Items.Add(d.Name);
            }
            // Add All Items To list
            foreach (Data e in GameData.Databases.Values)
            {
                this.Items.Add(e.Name);
                data.Add(e);
            }
            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }
        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(Data parent, bool memorize)
        {
            parentData = parent;
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();
            if (noneable)
            {
                Data d = new Data();
                d.ID = -1;
                d.Name = "(none)";
                data.Add(d);
                this.Items.Add(d.Name);
            }
            // Add All Items To list
            foreach (Data e in parent.Datas.Values)
            {
                this.Items.Add(e.Name);
                data.Add(e);
            }
            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }
        /// <summary>
        /// Get selected data
        /// </summary>
        /// <returns></returns>
        public Data Data()
        {
            if (this.SelectedIndex > -1)
                return (Data)data[this.SelectedIndex];
            else
            {
                Data dd = new Data();
                dd.ID = -10;
                dd.Name = "{No Data}";
                return dd;
            }
        }

        public void Select(int id)
        {
            int j = 0;
            foreach (Data e in data)
            {
                if (e.ID == id && j < this.Items.Count)
                {
                    this.SelectedIndex = j;
                    break;
                }
                j++;
            }
        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            Global.CbDatabases.Remove(this);

            base.Dispose(disposing);
        }

        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="id"></param>
        internal void Refresh(int id)
        {
            if (parentData == null)
            {
                RefreshList(false);
                Select(id);
            }
        }
        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        internal void Refresh(int id, Data data)
        {
            if (data == null)
            {
                if (parentData != null)
                {
                    RefreshList(parentData, false);
                    Select(id);
                }
                else
                    Refresh(id);
            }
            else if (parentData != null && parentData == data)
            {
                RefreshList(data, false);
                Select(id);
            }
        }
    }
}
