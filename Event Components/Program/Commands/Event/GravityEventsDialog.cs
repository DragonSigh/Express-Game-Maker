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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs
{
    public partial class GravityEventsDialog : Form
    {
        public GravityEventsDialog()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;


            cbMapX.RefreshList(false);
            cbMapY.RefreshList(false);
        }
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    cbEvents.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    cbEvents.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));

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

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 13;
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
            cbEvents.Select((int)action.Value[0]);
            cbType.SelectedIndex = (int)action.Value[1];

            switch ((int)action.Value[1])
            {
                case 0: // Constant
                    nudMapX.Value = (decimal)(float)action.Value[2];
                    nudMapY.Value = (decimal)(float)action.Value[3];
                    break;
                case 1: // Variabe
                    cbMapX.Select((int)(float)action.Value[2]);
                    cbMapY.Select((int)(float)action.Value[3]);
                    break;
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (cbType.SelectedIndex)
            {
                case 0:
                    panelVariable.Visible = false;
                    panelConstant.Visible = true;
                    break;
                case 1:
                    panelConstant.Visible = false;
                    panelVariable.Visible = true;
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            action.Value[0] = cbEvents.Data().ID;
            action.Value[1] = cbType.SelectedIndex;


            switch ((int)action.Value[1])
            {
                case 0: // Constant
                    action.Value[2] = (float)nudMapX.Value;
                    action.Value[3] = (float)nudMapY.Value;
                    break;
                case 1: // Variabe
                    action.Value[2] = (float)cbMapX.Data().ID;
                    action.Value[3] = (float)cbMapY.Data().ID;
                    break;
            }

            this.DialogResult = DialogResult.OK;


            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
