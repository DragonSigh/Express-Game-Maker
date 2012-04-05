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
    public partial class MapEventComboBox : ComboBox
    {
        public bool ShowPlayer
        {
            get { return showPlayer; }
            set { showPlayer = value; }
        }
        bool showPlayer = true;

        public bool ThisEvent
        {
            get { return thisEvent; }
            set { thisEvent = value; }
        }
        bool thisEvent = false;

        public bool ShowTargets
        {
            get { return showTargets; }
            set { showTargets = value; }
        }
        bool showTargets = false;

        public bool ShowTarget
        {
            get { return showTarget; }
            set { showTarget = value; }
        }
        bool showTarget = true;

        List<EventData> mapEvents = new List<EventData>();
        /// <summary>
        /// Initialize
        /// </summary>
        public MapEventComboBox()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMapEvents.Add(this);
        }
        public MapEventComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbMapEvents.Add(this);


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
        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(bool memorize, bool isMap, bool isTemplate)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            mapEvents.Clear();
            // Add All Items To list
            if (MainForm.SelectedMap != null)
            {
                EventData et;
                if (thisEvent)
                {
                    et = new EventData();
                    et.Name = "This Event";
                    et.ID = -2;
                    mapEvents.Add(et);
                    this.Items.Add(et.Name);
                }

                if (showPlayer)
                {
                    this.Items.Add(GameData.Player.Name);
                    mapEvents.Add(GameData.Player);
                }

                if (showTargets && (isMap || isTemplate))
                {
                    et = new EventData();
                    et.Name = "Targets";
                    et.ID = -4;
                    mapEvents.Add(et);
                    this.Items.Add(et.Name);
                }

                if (showTarget && (isMap || isTemplate))
                {
                    et = new EventData();
                    et.Name = "Target";
                    et.ID = -3;
                    mapEvents.Add(et);
                    this.Items.Add(et.Name);
                }

                if (isMap)
                {
                    foreach (EventData e in Global.GetMapEventList(MainForm.SelectedMap))
                    {
                        this.Items.Add(e.Name + " (" + e.ID + ")");
                        mapEvents.Add(e);
                    }
                }
            }
            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }
        /// <summary>
        /// Refresh List
        /// </summary>
        /// <param name="p"></param>
        internal void RefreshListThisPlayer(bool memorize)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            mapEvents.Clear();
            // Add All Items To list
            if (MainForm.SelectedMap != null)
            {
                EventData et;
                if (thisEvent)
                {
                    et = new EventData();
                    et.Name = "This Event";
                    et.ID = -2;
                    mapEvents.Add(et);
                    this.Items.Add(et.Name);
                }
                if (showPlayer)
                {
                    this.Items.Add(GameData.Player.Name);
                    mapEvents.Add(GameData.Player);
                }

                //if (showTargets)
                //{
                //    et = new EventData();
                //    et.Name = "Targets";
                //    et.ID = -4;
                //    mapEvents.Add(et);
                //    this.Items.Add(et.Name);
                //}

                //if (showTarget)
                //{
                //    et = new EventData();
                //    et.Name = "Target";
                //    et.ID = -3;
                //    mapEvents.Add(et);
                //    this.Items.Add(et.Name);
                //}
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
        public EventData Data()
        {
            if (this.SelectedIndex > -1)
                return mapEvents[this.SelectedIndex];
            else
            {
                EventData data = new EventData();
                data.ID = -10;
                data.Name = "{No Event}";
                return data;
            }
        }

        public void Select(int id)
        {
            int j = 0;
            foreach (EventData e in mapEvents)
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

            Global.CbMapEvents.Remove(this);

            base.Dispose(disposing);
        }
    }
}
