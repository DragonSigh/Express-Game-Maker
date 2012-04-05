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
    public partial class ApplyKnockbackFieldDialog : Form
    {

        public ApplyKnockbackFieldDialog()
        {
            InitializeComponent();
            cbDirection.SelectedIndex = 0;
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
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 9;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            cbDirection.SelectedIndex = (int)action.Value[0];
            nudBaseAngle.Value = (int)action.Value[1];
            nudDistance.Value = (decimal)(int)action.Value[2];
            nudForce.Value = (decimal)(float)action.Value[3];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbDirection.SelectedIndex;
            action.Value[1] = (int)nudBaseAngle.Value;
            action.Value[2] = (int)nudDistance.Value;
            action.Value[3] = (float)nudForce.Value;
            action.Name += "Apply Knockback Field: " + cbDirection.Text + (cbDirection.SelectedIndex == 2 ? " [" + nudBaseAngle.Value.ToString() + "]" : "") + " Distance [" + nudDistance.Value.ToString() + "] Force [" + nudForce.Value.ToString() + "]";
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

        private void btnTop_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 270;
        }

        private void btnTopRight_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 320;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 0;
        }
        private void btnBotRight_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 45;
            dontClose = true;
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 90;
        }

        private void btnBotLeft_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 140;
            dontClose = true;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 180;
        }

        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 220;
        }
        bool allowChange = true;
        private void asBaseAngle_AngleChanged()
        {
            if (allowChange)
            {
                allowChange = false;
                nudBaseAngle.Value = (decimal)asBaseAngle.Angle;
            }
            allowChange = true;
        }

        private void nudBaseAngle_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                allowChange = false;
                asBaseAngle.Angle = (int)nudBaseAngle.Value;
            }
            allowChange = true;
        }

        bool dontClose = false;
        private void ApplyForceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dontClose)
                e.Cancel = true;
            dontClose = false;
        }


        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCustom.Enabled = (cbDirection.SelectedIndex == 2);
        }
    }
}
