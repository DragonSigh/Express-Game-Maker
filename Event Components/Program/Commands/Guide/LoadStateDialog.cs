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

namespace EGMGame
{
    public partial class LoadStateDialog : Form
    {
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

        public LoadStateDialog()
        {
            InitializeComponent();

            cbPositionType.SelectedIndex = 0;
            cbVariable.RefreshList(false);
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Guide;
            action.Code = 2;
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

            cbPositionType.SelectedIndex = (int)action.Value[0];

            nudFile.Maximum = 10;
            nudFile.Minimum = 1;
            if (cbPositionType.SelectedIndex == 0)
                nudFile.Value = (decimal)(int)action.Value[1];
            else
                cbVariable.Select((int)action.Value[1]);
        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbPositionType.SelectedIndex;
            action.Value[1] = (cbPositionType.SelectedIndex == 0 ? (int)nudFile.Value : cbVariable.Data().ID);

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

        private void cbPositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = cbPositionType.SelectedIndex == 0;
            panelVariable.Visible = cbPositionType.SelectedIndex == 1;
        }
    }
}
