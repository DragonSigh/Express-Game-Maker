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
    public partial class GuideConditionDialog : Form
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

        public GuideConditionDialog()
        {
            InitializeComponent();

            cbConditions.SelectedIndex = 0;
            cbCompare.SelectedIndex = 0;
            cbPlayList.SelectedIndex = 0;
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.Branch = true;
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Guide;
            action.Code = 3;

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

            action.Value[0] = cbConditions.SelectedIndex;
            action.Value[1] = cbCompare.SelectedIndex;
            action.Value[2] = cbPlayList.SelectedIndex;
        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbConditions.SelectedIndex;
            action.Value[1] = cbCompare.SelectedIndex;
            action.Value[2] = cbPlayList.SelectedIndex;

            action.Name = "IF ";

            switch ((int)action.Value[0])
            {
                case 0:
                    action.Name += "Game is " + ((int)action.Value[1] == 1 ? "NOT" : "") + " in Trial Mode";
                    break;
                case 1:
                    action.Name += "Storage is " + ((int)action.Value[1] == 1 ? "NOT" : "") + " Selected";
                    break;
                case 2:
                    action.Name += "Player [" + cbPlayList.SelectedIndex + "] is " + ((int)action.Value[1] == 1 ? "NOT" : "") + " Signed In";
                    break;
                case 3:
                    action.Name += "Player [" + cbPlayList.SelectedIndex + "] is " + ((int)action.Value[1] == 1 ? "NOT" : "") + " Signed In Live";
                    break;
                case 4:
                    action.Name += "Player [" + cbPlayList.SelectedIndex + "] is " + ((int)action.Value[1] == 1 ? "NOT" : "") + " Guest";
                    break;
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

        private void cbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelPlayer.Visible = (cbConditions.SelectedIndex != 0);
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }
    }
}
