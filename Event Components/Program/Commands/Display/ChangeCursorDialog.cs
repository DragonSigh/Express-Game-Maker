﻿//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.DisplayDialogs
{
    public partial class ChangeCursorDialog : Form
    {
        public ChangeCursorDialog()
        {
            InitializeComponent();
            materialsComboBox1.RefreshList(false, MaterialDataType.Image);
        }
        
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
           set { selectedEvent = value; if (action == null ) Setup(); }
        }
        IEvent selectedEvent;
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }
        EventPageData selectedPage;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Screen;
            action.Code = 4;
            //action.TypeCode = 1;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            materialsComboBox1.Select((int)action.Value[0]);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (materialsComboBox1.Data().ID > -1)
            {
                action.Value[0] = materialsComboBox1.Data().ID;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
    }
}
