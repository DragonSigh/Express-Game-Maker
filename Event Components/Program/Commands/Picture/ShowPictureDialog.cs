﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.IO;
using Microsoft.Xna.Framework;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class ShowPictureDialog : Form
    {
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

        public ShowPictureDialog()
        {
            InitializeComponent();
            materialsList.RefreshList(false, MaterialDataType.Image);
            operationTypeList.SelectedIndex = 0;
            variableXList.RefreshList(true);
            variableYList.RefreshList(false);
            cbOriginType.SelectedIndex = 0;
        }
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
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
            picIndex.Value = (int)action.Value[0];
            materialsList.Select((int)action.Value[1]);
            cbSetDimensions.Checked = (bool)action.Value[2];
            nudPicWidth.Value = (int)action.Value[3];
            nudPicWidth.Value = (int)action.Value[4];
            operationTypeList.SelectedIndex = (int)action.Value[5];
            chkGlobal.Checked = (bool)action.Value[8];
            nudLayer.Value = (int)action.Value[9];

            switch ((int)action.Value[5])
            {
                case 0: // Coordinate
                    nudScreenX.Value = (int)action.Value[6];
                    nudScreenY.Value = (int)action.Value[7];
                    break;
                case 1:// Varaibles
                    variableXList.Select((int)action.Value[6]);
                    variableYList.Select((int)action.Value[7]);
                    break;
            }

            cbOriginType.SelectedIndex = (int)action.Value[10];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)picIndex.Value;
            action.Value[1] = materialsList.Data().ID;
            action.Value[2] = cbSetDimensions.Checked;
            action.Value[3] = (int)nudPicWidth.Value;
            action.Value[4] = (int)nudPicWidth.Value;
            action.Value[5] = operationTypeList.SelectedIndex;
            action.Value[8] = chkGlobal.Checked;
            action.Value[9] = (int)nudLayer.Value;
            action.Value[10] = cbOriginType.SelectedIndex;
            string position = "";
            switch ((int)action.Value[5])
            {
                case 0: // Coordinate
                    action.Value[6] = (int)nudScreenX.Value;
                    action.Value[7] = (int)nudScreenY.Value;
                    position = "X: " + nudScreenX.Value.ToString() + " Y: " + nudScreenY.Value.ToString();
                    break;
                case 1:// Varaibles
                    action.Value[6] = variableXList.Data().ID;
                    action.Value[7] = variableYList.Data().ID;
                    position = "X: [" + variableXList.Data().Name + "] Y: [" + variableYList.Data().Name + "]";
                    break;
            }
            action.Name = "Show Picture: [" + action.Value[0].ToString() + "] Material: [" + materialsList.Data().Name + "] ON " + position;
            action.GetName(selectedEvent, selectedPage);
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
                case 2:
                    variablesPanel.Visible = false;
                    coordinatePanel.Visible = false;
                    break;
            }
        }

        private void cbSetDimensions_CheckedChanged(object sender, EventArgs e)
        {
            nudPicHeight.Enabled = nudPicWidth.Enabled = cbSetDimensions.Checked;
        }


    }
}
