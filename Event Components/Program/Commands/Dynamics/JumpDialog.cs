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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class JumpDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                cbLocalVariable.RefreshList(selectedEvent, false);
                cbLocalVariable2.RefreshList(selectedEvent, false);
            }
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

        public JumpDialog()
        {
            InitializeComponent();

            cbType.SelectedIndex = 0;
            cbVariable.RefreshList(false);
            cbVariable2.RefreshList(false);

        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 11;
        }
        /// <summary>
        /// Setup
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

            cbType.SelectedIndex = (int)action.Value[0];
            switch ((int)action.Value[0])
            {
                case 0:
                    nudBaseAngle.Value = (decimal)(int)action.Value[1];
                    pixelBox.Value = (decimal)(float)action.Value[2];
                    break;
                case 1:
                    cbVariable.Select((int)action.Value[1]);
                    cbVariable2.Select((int)(float)action.Value[2]);
                    break;
                case 2:
                    cbLocalVariable.Select((int)action.Value[1]);
                    cbLocalVariable2.Select((int)(float)action.Value[2]);
                    break;
            }
            chTurn.Checked = (bool)action.Value[3];
            chWait.Checked = (bool)action.Value[4];
        }
        /// <summary>
        /// Ok 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbType.SelectedIndex;

            switch ((int)action.Value[0])
            {
                case 0:
                    action.Value[1] = (int)nudBaseAngle.Value;
                    action.Value[2] = (float)pixelBox.Value;
                    break;
                case 1:
                    action.Value[1] = cbVariable.Data().ID;
                    action.Value[2] = (float)cbVariable2.Data().ID;
                    break;
                case 2:
                    action.Value[1] = cbLocalVariable.Data().ID;
                    action.Value[2] = (float)cbLocalVariable2.Data().ID;
                    break;
            }
            action.Value[3] = chTurn.Checked;
            action.Value[4] = chWait.Checked;
           
            // Close
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 90;
        }

        private void btnBotLeft_Click(object sender, EventArgs e)
        {
            nudBaseAngle.Value = 140;
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = (cbType.SelectedIndex == 0);
            panelVariable.Visible = (cbType.SelectedIndex == 1);
            panelLocalVariable.Visible = (cbType.SelectedIndex == 2);
        }
    }
}
