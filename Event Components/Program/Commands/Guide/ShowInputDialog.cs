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
    public partial class ShowInputDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; if (action == null) Setup(); }
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

        public ShowInputDialog()
        {
            InitializeComponent();

            cbPlayList.SelectedIndex = 0;
            cbStrings.SelectedIndex = 0;
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
            action.Code = 10;


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

            txtTitle.Text = (string)action.Value[0];
            txtBody.Text = (string)action.Value[1];
            txtDefault.Text = (string)action.Value[2];
            cbStrings.Select((int)action.Value[3]);
            cbPlayList.SelectedIndex = (int)action.Value[4];

        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = txtTitle.Text;
            action.Value[1] = txtBody.Text;
            action.Value[2] = txtDefault.Text;
            action.Value[3] = cbStrings.Data().ID;
            action.Value[4] = cbPlayList.SelectedIndex;

            action.Name = "Show XBOX Input: [" + txtTitle.Text + "] For Player [" + cbPlayList.SelectedIndex + "]";

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

        private void impactGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
