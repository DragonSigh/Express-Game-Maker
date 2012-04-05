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

namespace EGMGame
{
    public partial class ChangeCustomGravityDialog : Form
    {

        public ChangeCustomGravityDialog()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
        }

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
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 20;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            cbType.SelectedIndex = ((bool)action.Value[0] ? 0 : 1);
            nudGravityX.Value = (decimal)(float)action.Value[1];
            nudGravityY.Value = (decimal)(float)action.Value[2];

            panel.Enabled = (cbType.SelectedIndex == 0);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = (cbType.SelectedIndex == 0);
            action.Value[1] = (float)nudGravityX.Value;
            action.Value[2] = (float)nudGravityY.Value;
            action.Name = "Custom Gravity: " + cbType.Text;
            if (cbType.SelectedIndex == 0)
            {
                action.Name += " X: [" + action.Value[1] + "]" + "Y: [" + action.Value[2] + "]";
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel.Enabled = (cbType.SelectedIndex == 0);
        }
    }
}
