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

namespace EGMGame.EventControls.EventDialogs.CommandDialogs.DisplayDialogs
{
    public partial class ShowVideoDialog : Form
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
        public ShowVideoDialog()
        {
            InitializeComponent();
            operationTypeList.SelectedIndex = 0;
            cbSizeType.SelectedIndex = 0;
            variableXList.RefreshList(true);
            variableYList.RefreshList(false);
            materialsList.RefreshList(false, MaterialDataType.Video);
        }
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 6;
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
            materialsList.Select((int)action.Value[0]);
            cbSizeType.SelectedIndex = (int)action.Value[1];
            nudPicWidth.Value = (int)action.Value[2];
            nudPicHeight.Value = (int)action.Value[3];
            operationTypeList.SelectedIndex = (int)action.Value[4];
            chkLoop.Checked = (bool)action.Value[7];
            //chWait.Checked = (bool)action.Value[8];
            chkPause.Checked = (bool)action.Value[9];
            //chkGlobal.Checked = (bool)action.Value[10];

            switch ((int)action.Value[4])
            {
                case 0: // Coordinate
                    nudScreenX.Value = (int)action.Value[5];
                    nudScreenY.Value = (int)action.Value[6];
                    break;
                case 1:// Varaibles
                    variableXList.Select((int)action.Value[5]);
                    variableYList.Select((int)action.Value[6]);
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = materialsList.Data().ID;
            action.Value[1] = cbSizeType.SelectedIndex;
            action.Value[2] = (int)nudPicWidth.Value;
            action.Value[3] = (int)nudPicHeight.Value;
            action.Value[4] = operationTypeList.SelectedIndex;
            action.Value[7] = chkLoop.Checked;
            //action.Value[8] = chWait.Checked;
            action.Value[9] = chkPause.Checked;
            //action.Value[10] = chkGlobal.Checked;
            string position = "";
            switch ((int)action.Value[4])
            {
                case 0: // Coordinate
                    action.Value[5] = (int)nudScreenX.Value;
                    action.Value[6] = (int)nudScreenY.Value;
                    position = "X: " + nudScreenX.Value.ToString() + " Y: " + nudScreenY.Value.ToString();
                    break;
                case 1:// Varaibles
                    action.Value[5] = variableXList.Data().ID;
                    action.Value[6] = variableYList.Data().ID;
                    position = "X: [" + variableXList.Data().Name + "] Y: [" + variableYList.Data().Name + "]";
                    break;
            }
            action.Name = "Show Video: Material: [" + materialsList.Data().Name + "] ON " + position;
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
            }
        }

        private void cbSizeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudPicHeight.Enabled = nudPicWidth.Enabled = (cbSizeType.SelectedIndex == 2);
        }
    }
}
