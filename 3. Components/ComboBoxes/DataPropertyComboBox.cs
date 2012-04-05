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
    public partial class DataPropertyComboBox : ComboBox
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public DataPropertyComboBox()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;

        }
        public DataPropertyComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;
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

        List<IGameData> data = new List<IGameData>();
        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(Data parent, bool memorize, DataType type)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();
            // Add All Items To list
            foreach (DataProperty e in parent.Properties)
            {
                if (e.ValueType == type || (parent.ID == 0 && e.ID < 15 && type == DataType.Number))
                {
                    this.Items.Add(e.Name);
                    data.Add(e);
                }
            }
            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }

        internal void RefreshList(Data parent, bool memorize)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();
            // Add All Items To list
            foreach (DataProperty e in parent.Properties)
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

        internal void RefreshList(Data parent, bool memorize, List<DataType> types)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();
            // Add All Items To list
            foreach (DataProperty e in parent.Properties)
            {
                if (types.Contains(e.ValueType))
                {
                    this.Items.Add(e.Name);
                    data.Add(e);
                }
            }
            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }
        /// <summary>
        /// Refresh Player List
        /// </summary>
        /// <param name="data"></param>
        /// <param name="p"></param>
        internal void RefreshPlayerList(Data parent, bool memorize)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();
            // Add All Items To list
            foreach (DataProperty e in parent.Properties)
            {
                if (e.ValueType == DataType.Number || e.ID < 15)
                {
                    this.Items.Add(e.Name);
                    data.Add(e);
                }
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
        public DataProperty Data()
        {
            if (this.SelectedIndex > -1)
                return (DataProperty)data[this.SelectedIndex];
            else
            {
                DataProperty dd = new DataProperty();
                dd.ID = -10;
                dd.Name = "{No Data Property}";
                return dd;
            }
        }

        internal void Select(int id, List<DataProperty> list)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].ID == id)
                {
                    this.SelectedIndex = i;
                    break;
                }
            }
        }

        public void Select(int id)
        {
            int j = 0;
            foreach (IGameData e in data)
            {
                if (e.ID == id && j < this.Items.Count)
                {
                    this.SelectedIndex = j;
                    break;
                }
                j++;
            }
        }
    }
}
