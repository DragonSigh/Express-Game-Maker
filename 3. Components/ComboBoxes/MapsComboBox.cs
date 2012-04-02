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
    public partial class MapsComboBox : ComboBox
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public MapsComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMaps.Add(this);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public MapsComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMaps.Add(this);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        List<MapInfo> data = new List<MapInfo>();

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
        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(bool memorize)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();

            // Add All Items To list
            MapInfo an = new MapInfo();
            an.ID = -2;
            an.Name = "Player Start Position";
            data.Add(an);
            Items.Add(an.Name);

            an = new MapInfo();
            an.ID = -1;
            an.Name = "Current Map";
            data.Add(an);
            Items.Add(an.Name);
            // Add Item
            foreach (MapInfo e in Global.Project.MapsInfo.Values)
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
        /// Get Selected Event
        /// </summary>
        /// <returns></returns>
        public MapInfo Data()
        {
            if (this.SelectedIndex > -1)
                return (MapInfo)data[this.SelectedIndex];
            else
            {
                MapInfo dd = new MapInfo();
                dd.ID = -10;
                dd.Name = "{No Map}";
                return dd;
            }
        }

        public void Select(int id)
        {
            int j = 0;
            foreach (MapInfo e in data)
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

            Global.CbMaps.Remove(this);

            base.Dispose(disposing);
        }
    }
}
