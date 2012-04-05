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
    public partial class MoveParticleDialog : Form
    {
        public MoveParticleDialog()
        {
            InitializeComponent();
            operationTypeList.SelectedIndex = 0;
            variableXList.RefreshList(true);
            variableYList.RefreshList(false);
        }


        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
           set { selectedEvent = value; if (action == null ) Setup(); }
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
            nudParticleIndex.Value = (int)action.Value[0];
            operationTypeList.SelectedIndex = (int)action.Value[1];

            switch ((int)action.Value[1])
            {
                case 0: // Coordinate
                    nudScreenX.Value = (int)action.Value[2];
                    nudScreenY.Value = (int)action.Value[3];
                    break;
                case 1:// Varaibles
                    variableXList.Select((int)action.Value[2]);
                    variableYList.Select((int)action.Value[3]);
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)nudParticleIndex.Value;
            action.Value[1] = operationTypeList.SelectedIndex;
            string position = "";
            switch ((int)action.Value[1])
            {
                case 0: // Coordinate
                    action.Value[2] = (int)nudScreenX.Value;
                    action.Value[3] = (int)nudScreenY.Value;
                    position = "X: " + nudScreenX.Value.ToString() + " Y: " + nudScreenY.Value.ToString();
                    break;
                case 1:// Varaibles
                    action.Value[2] = variableXList.Data().ID;
                    action.Value[3] = variableYList.Data().ID;
                    position = "X: [" + variableXList.Data().Name + "] Y: [" + variableYList.Data().Name + "]";
                    break;
            }
            action.Name = "Move Particle: [" + action.Value[0].ToString() + "] TO " + position;
            action.GetName(selectedEvent, selectedPage);
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void operationTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (operationTypeList.SelectedIndex)
            {
                case 0: // Coordinates
                    variablesPanel.Visible = false;
                    coordinatePanel.Visible = true;
                    break;
                case 1:// Varaibles
                    variablesPanel.Visible = true;
                    coordinatePanel.Visible = false;
                    break;
            }
        }
    }
}
