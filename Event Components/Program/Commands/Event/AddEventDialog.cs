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
using Microsoft.Xna.Framework;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class AddEventDialog : Form
    {
        #region Constructor
        public AddEventDialog()
        {
            InitializeComponent();
        }
        #endregion


        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    cbOnEvent.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    cbOnEvent.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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
            action.Code = 1;

            cbEvents.RefreshList(false);
            cbPositionType.SelectedIndex = 0;
            cbVariableX.RefreshList(false);
            cbVariableY.RefreshList(false);
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
            cbPositionType.SelectedIndex = (int)action.Value[1];

            switch ((int)action.Value[1])
            {
                case 0: // Custom
                    nudPositionX.Value = (decimal)(int)action.Value[2];
                    nudPositionY.Value = (decimal)(int)action.Value[3];
                    break;
                case 1: // Variable
                    cbVariableX.Select((int)action.Value[2]);
                    cbVariableY.Select((int)action.Value[3]);
                    break;
                case 2: // Event
                    cbOnEvent.Select((int)action.Value[2]);
                    break;
            }
            nudLayer.Value = (int)action.Value[4];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (cbEvents.Data().ID > -1)
            {
                action.Value[0] = cbEvents.Data().ID;
                action.Value[1] = cbPositionType.SelectedIndex;
                action.Value[4] = (int)nudLayer.Value;

                switch ((int)action.Value[1])
                {
                    case 0: // Custom
                        action.Value[2] = (int)nudPositionX.Value;
                        action.Value[3] = (int)nudPositionY.Value;
                        break;
                    case 1: // Variable
                        action.Value[2] = cbVariableX.Data().ID;
                        action.Value[3] = cbVariableY.Data().ID;
                        break;
                    case 2: // Event
                        action.Value[2] = cbOnEvent.Data().ID;
                        break;
                }

               
                action.GetName(selectedEvent, selectedPage);

                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = (cbPositionType.SelectedIndex == 0);
            panelVariable.Visible = (cbPositionType.SelectedIndex == 1);
            panelEvent.Visible = (cbPositionType.SelectedIndex == 2);
        }


    }
}
