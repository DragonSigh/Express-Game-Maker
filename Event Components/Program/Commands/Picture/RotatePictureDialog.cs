using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Picture
{
    public partial class RotatePictureDialog : Form
    {
        public RotatePictureDialog()
        {
            InitializeComponent();
            operationTypeList.SelectedIndex = 0;
            cbRotateVar.RefreshList(false);
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
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 19;
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
            operationTypeList.SelectedIndex = (int)action.Value[1];

            switch ((int)action.Value[1])
            {
                case 0: // Coordinate
                    cbRotateTo.Value = (int)action.Value[2];
                    break;
                case 1:// Varaibles
                    cbRotateVar.Select((int)action.Value[2]);
                    break;
            }
            chkCenter.Checked = (bool)action.Value[3];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)picIndex.Value;
            action.Value[1] = operationTypeList.SelectedIndex;
            string position = "";
            switch ((int)action.Value[1])
            {
                case 0: // Coordinate
                    action.Value[2] = (int)cbRotateTo.Value;
                    position = "Rotate To: " + cbRotateTo.Value.ToString() + " Degrees ";
                    break;
                case 1:// Varaibles
                    action.Value[2] = cbRotateVar.Data().ID;
                    position = "Rotate To: [" + cbRotateVar.Data().Name + "] Degrees ";
                    break;
            }
            action.Value[3] = chkCenter.Checked;
            position += " Centered: ["+action.Value[3].ToString()+"]";
            action.GetName(selectedEvent, selectedPage);
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

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

        private void cbSetDimensions_CheckedChanged(object sender, EventArgs e)
        {
        }

    }
}
