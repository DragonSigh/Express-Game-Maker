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
    public partial class AttachCameraToEventDialog : Form
    {
        public AttachCameraToEventDialog()
        {
            InitializeComponent();
        }
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();


                if (selectedEvent == null || selectedEvent is GlobalEventData)
                {
                    cbEvents.RefreshList(true, false, false);
                }
                else
                {

                    cbEvents.RefreshList(false, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Map;
            action.Code = 12;
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
            rbNone.Checked = (bool)action.Value[0];
            rbEvent.Checked = !(bool)action.Value[0];
            cbEvents.Select((int)action.Value[1]);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = rbNone.Checked;
            action.Value[1] = cbEvents.Data().ID;

            this.DialogResult = DialogResult.OK;


            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbEvent_CheckedChanged(object sender, EventArgs e)
        {
            cbEvents.Enabled = rbEvent.Checked;
        }

    
    }
}
