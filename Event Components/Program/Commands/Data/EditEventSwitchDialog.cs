//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class EditEventSwitchesDialog : Form
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

        public EditEventSwitchesDialog()
        {
            InitializeComponent();
        }
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Data;
            action.Code = 8;
            //action.TypeCode = 1;
            // Refresh List
            switchesBox.Enabled = true;
            localList.SelectedIndex = 0;
        }
        /// <summary>
        /// Setup action
        /// </summary>
        /// <param name="a"></param>
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            localList.SelectedIndex = (int)action.Value[0];
            if ((int)action.Value[1] == 0)
                onBtn.Checked = true;
            else
                offBtn.Checked = true;
        }
        private void onBtn_CheckedChanged(object sender, EventArgs e)
        {
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = localList.SelectedIndex;
            string on = "OFF";
            if (onBtn.Checked)
            {
                action.Value[1] = 0;
                on = "ON";
            }
            else
                action.Value[1] = 1;
            action.Name = "Event Switch " + (localList.SelectedIndex + 1).ToString() + " = " + on;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void localList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}
