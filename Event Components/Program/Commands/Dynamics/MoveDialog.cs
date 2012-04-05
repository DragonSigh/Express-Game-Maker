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
    public partial class MoveDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                cbLocalVariable.RefreshList(selectedEvent, false);
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

        public MoveDialog()
        {
            InitializeComponent();

            cbType.SelectedIndex = 0;
            cbVariable.RefreshList(false);
            pixelBox.Value = (decimal)Global.Project.DefaultPixel;
            cbMovement.SelectedIndex = 0;
            cbUseForce.SelectedIndex = 0;
        }


        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 2;
            //action.TypeCode = 1;
            action.Value[0] = 0;
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

            cbMovement.SelectedIndex = (int)action.Value[0];
            cbUseForce.SelectedIndex = (int)action.Value[1];
            nudBaseAngle.Value = (int)action.Value[2];

            cbType.SelectedIndex = (int)action.Value[3];

            switch ((int)action.Value[3])
            {
                case 0:
                    pixelBox.Value = (decimal)(int)action.Value[4];
                    break;
                case 1:
                    cbVariable.Select((int)action.Value[4]);
                    break;
                case 2:
                    cbLocalVariable.Select((int)action.Value[4]);
                    break;
            }

            turnBox.Checked = (bool)action.Value[5];
            chWait.Checked = (bool)action.Value[6];
        }


        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbMovement.SelectedIndex;
            action.Value[1] = cbUseForce.SelectedIndex;
            action.Value[2] = (int)nudBaseAngle.Value;

            action.Value[3] = cbType.SelectedIndex;

            switch ((int)action.Value[3])
            {
                case 0:
                    action.Value[4] = (int)pixelBox.Value;
                    break;
                case 1:
                    action.Value[4] = cbVariable.Data().ID;
                    break;
                case 2:
                    action.Value[4] = cbLocalVariable.Data().ID;
                    break;
            }
            action.Value[5] = turnBox.Checked;
            action.Value[6] = chWait.Checked;

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void asBaseAngle_Load(object sender, EventArgs e)
        {

        }

        private void chWait_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void turnBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pixelBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbMovement_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCustom.Enabled = (cbMovement.SelectedIndex == 0);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = (cbType.SelectedIndex == 0);
            panelVariable.Visible = (cbType.SelectedIndex == 1);
            panelLocalVariable.Visible = (cbType.SelectedIndex == 2);
        }

    }
}
