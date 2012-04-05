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

namespace EGMGame.Controls.EventControls
{
    public partial class ProjectileForceDialog : Form
    {
        public ProjectileForceDialog()
        {
            InitializeComponent();

            cbUseForce.SelectedIndex = 0;
            cbMovement.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            cbVariable.RefreshList(false);
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

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 1;
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
            try
            {
                cbType.SelectedIndex = (int)action.Value[2];

                if ((int)action.Value[2] == 0)
                    pixelBox.Value = (decimal)(float)action.Value[3];
                else
                    cbVariable.Select((int)action.Value[3]);
            }
            catch { }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)cbMovement.SelectedIndex;
            action.Value[1] = (int)cbUseForce.SelectedIndex;
            action.Value[2] = cbType.SelectedIndex;//(float)pixelBox.Value;
            int i = cbType.SelectedIndex;
            if ((int)action.Value[2] == 0)
                action.Value[3] = (float)pixelBox.Value;
            else
                action.Value[3] = (int)cbVariable.Data().ID;
            // Set Action Name
            if ((int)action.Value[2] == 0)
                action.Name = "Move " + cbMovement.Text + ": " + pixelBox.Value.ToString();
            else
                action.Name = "Move " + cbMovement.Text + ": [Variable]";//  +pixelBox.Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = cbType.SelectedIndex == 0;
            panelVariable.Visible = cbType.SelectedIndex == 1;
        }
    }
}
