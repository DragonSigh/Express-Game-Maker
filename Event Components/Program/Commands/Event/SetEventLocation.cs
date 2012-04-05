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
    public partial class SetEventLocation : Form
    {
        public SetEventLocation()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            cbDirections.SelectedIndex = 0;


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

                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    cbExchange.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    cbExchange.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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
            action.Code = 3;
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
            cbDirections.SelectedIndex = (int)action.Value[2];

            switch ((int)action.Value[1])
            {
                case 0: // Constant
                    nudMapX.Value = (decimal)(int)action.Value[3];
                    nudMapY.Value = (decimal)(int)action.Value[4];
                    break;
                case 1: // Variabe
                    cbMapX.Select((int)action.Value[3]);
                    cbMapY.Select((int)action.Value[4]);
                    break;
                case 2: // Exchange
                    cbExchange.Select((int)action.Value[3]);
                    break;
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    panelVariable.Visible = false;
                    panelExchange.Visible = false;
                    panelConstant.Visible = true;
                    break;
                case 1:
                    panelExchange.Visible = false;
                    panelConstant.Visible = false;
                    panelVariable.Visible = true;
                    break;
                case 2:
                    panelConstant.Visible = false;
                    panelVariable.Visible = false;
                    panelExchange.Visible = true;
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            action.Value[0] = cbEvents.Data().ID;
            action.Value[1] = cbType.SelectedIndex;
            action.Value[2] = cbDirections.SelectedIndex;


            switch ((int)action.Value[1])
            {
                case 0: // Constant
                    action.Value[3] = (int)nudMapX.Value;
                    action.Value[4] = (int)nudMapY.Value;
                    break;
                case 1: // Variabe
                    action.Value[3] = cbMapX.Data().ID;
                    action.Value[4] = cbMapY.Data().ID;
                    break;
                case 2: // Exchange
                    action.Value[3] = cbExchange.Data().ID;
                    break;
            }

            this.DialogResult = DialogResult.OK;


            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            // Show map
            if (MainForm.SelectedMap != null)
            {
                // Show map
                PickPositionOnMapDialog dialog = new PickPositionOnMapDialog();
                dialog.SelectedMap = MainForm.SelectedMap;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    nudMapX.Value = (decimal)dialog.Position.X;
                    nudMapY.Value = (decimal)dialog.Position.Y;
                }
            }
        }
    }
}
