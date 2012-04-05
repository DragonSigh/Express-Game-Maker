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
    public partial class ShowParticleDialog : Form
    {
        public ShowParticleDialog()
        {
            InitializeComponent();
            cbParticles.RefreshList(false);
            operationTypeList.SelectedIndex = 0;
            variableXList.RefreshList(true);
            variableYList.RefreshList(false);
        }

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
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 11;
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
            nudParticleIndex.Value = (int)action.Value[0];
            cbParticles.Select((int)action.Value[1]);
            operationTypeList.SelectedIndex = (int)action.Value[2];
            chkGlobal.Checked = (bool)action.Value[5];
            nudLayer.Value = (decimal)(int)action.Value[6];

            switch ((int)action.Value[2])
            {
                case 0: // Coordinate
                    nudScreenX.Value = (int)action.Value[3];
                    nudScreenY.Value = (int)action.Value[4];
                    break;
                case 1:// Varaibles
                    variableXList.Select((int)action.Value[3]);
                    variableYList.Select((int)action.Value[4]);
                    break;
                case 2: // Event
                    cbOnEvent.Select((int)action.Value[3]);
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)nudParticleIndex.Value;
            action.Value[1] = cbParticles.Data().ID;
            action.Value[2] = operationTypeList.SelectedIndex;
            action.Value[5] = chkGlobal.Checked;
            action.Value[6] = (int)nudLayer.Value;
            string position = "";
            switch ((int)action.Value[2])
            {
                case 0: // Coordinate
                    action.Value[3] = (int)nudScreenX.Value;
                    action.Value[4] = (int)nudScreenY.Value;
                    position = "X: " + nudScreenX.Value.ToString() + " Y: " + nudScreenY.Value.ToString();
                    break;
                case 1:// Varaibles
                    action.Value[3] = variableXList.Data().ID;
                    action.Value[4] = variableYList.Data().ID;
                    position = "X: [" + variableXList.Data().Name + "] Y: [" + variableYList.Data().Name + "]";
                    break;
                case 2: // Event
                    action.Value[3] = cbOnEvent.Data().ID;
                    break;
            }
            action.GetName(selectedEvent, selectedPage);
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void operationTypeList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            coordinatePanel.Visible = (operationTypeList.SelectedIndex == 0);
            variablesPanel.Visible = (operationTypeList.SelectedIndex == 1);
            panelEvent.Visible = (operationTypeList.SelectedIndex == 2);
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
                    nudScreenX.Value = (decimal)dialog.Position.X;
                    nudScreenY.Value = (decimal)dialog.Position.Y;
                }
            }
        }
    }
}
