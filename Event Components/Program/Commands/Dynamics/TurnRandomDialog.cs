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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class TurnRandomDialog : Form
    {
        public TurnRandomDialog()
        {
            InitializeComponent();
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

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 13;
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

            // Direction
            List<int> dir = new List<int>((List<int>)action.Value[0]);
            upBtn.Checked = dir.Contains(0);
            downBtn.Checked = dir.Contains(1);
            leftBtn.Checked = dir.Contains(2);
            rightBtn.Checked = dir.Contains(3);
            upLeftBtn.Checked = dir.Contains(4);
            upRightBtn.Checked = dir.Contains(5);
            downLeftBtn.Checked = dir.Contains(6);
            downRightBtn.Checked = dir.Contains(7);
        }


        private void okBtn_Click(object sender, EventArgs e)
        {
            // Save Data
            List<int> dir = new List<int>();
            if (upBtn.Checked)
                dir.Add(0);
            if (downBtn.Checked)
                dir.Add(1);
            if (leftBtn.Checked)
                dir.Add(2);
            if (rightBtn.Checked)
                dir.Add(3);
            if (upLeftBtn.Checked)
                dir.Add(4);
            if (upRightBtn.Checked)
                dir.Add(5);
            if (downLeftBtn.Checked)
                dir.Add(6);
            if (downRightBtn.Checked)
                dir.Add(7);
            action.Value[0] = dir;
            action.Name = "Turn Random";
            // Close
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
