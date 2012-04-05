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
    public partial class TurnDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                if (action == null) Setup();
                if (value != null)
                {
                    cbLocalVariable.RefreshList(selectedEvent, false);
                    cbLocalVariableX.RefreshList(selectedEvent, false);
                    cbLocalVariableY.RefreshList(selectedEvent, false);
                }
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


        bool allowEdit = true;
        public TurnDialog()
        {
            InitializeComponent();
            allowEdit = false;
            allowEdit = true;

            cbType.SelectedIndex = 0;
            cbVariable.RefreshList(false);
            cbVariableX.RefreshList(false);
            cbVariableY.RefreshList(false);
        }

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 6;
            action.Value[0] = 1;
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

            cbType.SelectedIndex = (int)action.Value[0];
            switch ((int)action.Value[0])
            {
                case 0:
                    nudBaseAngle.Value = (int)action.Value[1];
                    break;
                case 1:
                    cbVariable.Select((int)action.Value[1]);
                    break;
                case 2:
                    cbLocalVariable.Select((int)action.Value[1]);
                    break;
                case 3:
                    cbVariableX.Select((int)action.Value[1]);
                    cbVariableY.Select((int)action.Value[2]);
                    break;
                case 24:
                    cbLocalVariableX.Select((int)action.Value[1]);
                    cbLocalVariableY.Select((int)action.Value[2]);
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            // Set Action Name
            action.Value[0] = cbType.SelectedIndex;

            switch ((int)action.Value[0])
            {
                case 0:
                    action.Value[1] = (int)nudBaseAngle.Value;
                    break;
                case 1:
                    action.Value[1] = cbVariable.Data().ID;
                    break;
                case 2:
                    action.Value[1] = cbLocalVariable.Data().ID;
                    break;
                case 3:
                    action.Value[1] = cbVariableX.Data().ID;
                    action.Value[2] = cbVariableY.Data().ID;
                    break;
                case 4:
                    action.Value[1] = cbLocalVariableX.Data().ID;
                    action.Value[2] = cbLocalVariableY.Data().ID;
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
            panelVariables.Visible = (cbType.SelectedIndex == 3);
            panelLocalVariables.Visible = (cbType.SelectedIndex == 4);
        }

    }
}
