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
    public partial class ShowAnimationDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();

                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    eventsList.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    eventsList.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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

        #region Constructor
        public ShowAnimationDialog()
        {
            InitializeComponent();
            cbAnimations.RefreshList(false);
            cbVariableX.RefreshList(true);
            cbVariableY.RefreshList(true);

            cbDirection.SelectedIndex = 0;
            operationsTypeList.SelectedIndex = 0;
            cbCoordinate1.SelectedIndex = 0;
            cbCoordinate2.SelectedIndex = 0;
        }
        #endregion
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 5;
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
            cbAnimations.Select((int)action.Value[0]);
            cbActions.RefreshList(false, cbAnimations.Data());
            cbActions.Select((int)action.Value[1]);
            cbDirection.SelectedIndex = (int)action.Value[2];
            operationsTypeList.SelectedIndex = (int)action.Value[3];
            //chkGlobal.Checked = (bool)action.Value[8];

            switch ((int)action.Value[3])
            {
                case 0: // Coordinates
                    nudX.Value = (decimal)(int)action.Value[4];
                    nudY.Value = (decimal)(int)action.Value[5];
                    cbCoordinate2.SelectedIndex = (int)action.Value[6];
                    nudLayer2.Value = (decimal)(int)action.Value[7];
                    break;
                case 1:// Varaibles
                    cbVariableX.Select((int)action.Value[4]);
                    cbVariableY.Select((int)action.Value[5]);
                    cbCoordinate1.SelectedIndex = (int)action.Value[6];
                    nudLayer1.Value = (decimal)(int)action.Value[7];
                    break;
                case 2: // Events
                    eventsList.Select((int)action.Value[4]);
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbAnimations.Data().ID;
            action.Value[1] = cbActions.Data().ID;
            action.Value[2] = cbDirection.SelectedIndex;
            action.Value[3] = operationsTypeList.SelectedIndex;
            //action.Value[8] = chkGlobal.Checked;
            string position = "";
            switch ((int)action.Value[3])
            {
                case 0: // Coordinates
                    action.Value[4] = (int)nudX.Value;
                    action.Value[5] = (int)nudY.Value;
                    action.Value[6] = cbCoordinate2.SelectedIndex;
                    action.Value[7] = (int)nudLayer2.Value;
                    position = "X: [" + nudX.Value.ToString() + "] Y: [" + nudY.Value.ToString() + "]";
                    break;
                case 1:// Varaibles
                    action.Value[4] = cbVariableX.Data().ID;
                    action.Value[5] = cbVariableY.Data().ID;
                    action.Value[6] = cbCoordinate1.SelectedIndex;
                    action.Value[7] = (int)nudLayer1.Value;
                    position = "X: [" + cbVariableX.Data().Name + "] Y: [" + cbVariableY.Data().Name + "]";
                    break;
                case 2: // Events
                    action.Value[4] = eventsList.Data().ID;
                    position = "Event: " + eventsList.Data().Name;
                    break;
            }

            action.Name = "Show Animation: [" + cbAnimations.Data().Name + "] > [" + cbActions.Data().Name + "] > [" + cbDirection.Text + "] ON " + position;
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void operationsTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (operationsTypeList.SelectedIndex)
            {
                case 0: // Coordinates
                    variablePanel.Visible = false;
                    coordinatePanel.Visible = true;
                    eventPanel.Visible = false;
                    break;
                case 1:// Varaibles
                    eventPanel.Visible = false;
                    variablePanel.Visible = true;
                    coordinatePanel.Visible = false;
                    break;
                case 2: // Events
                    eventPanel.Visible = true;
                    variablePanel.Visible = false;
                    coordinatePanel.Visible = false;
                    break;
            }
        }

        private void cbAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnimations.Data().ID > -10)
            {
                cbActions.RefreshList(true, cbAnimations.Data());
            }
        }

        private void cbCoordinate2_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudLayer2.Visible = layerLabel2.Visible = (cbCoordinate2.SelectedIndex == 0);

        }

        private void cbCoordinate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudLayer1.Visible = layerLbl1.Visible = (cbCoordinate1.SelectedIndex == 0);
        }
    }
}
