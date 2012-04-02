using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame
{
    public partial class OtherConditionDialog : Form
    {
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

        /// <summary>
        /// Constructor
        /// </summary>
        public OtherConditionDialog()
        {
            InitializeComponent();
            operationTypeList.SelectedIndex = 0;
            cbConditions.SelectedIndex = 0;
            cbTiles.SelectedIndex = 0;
            variableXList.RefreshList(false);
            variableYList.RefreshList(false);
            cbCompare.SelectedIndex = 0;
            cbPlatforms.SelectedIndex = 0;
            cbPositionType.SelectedIndex = 0;
            cbVariable.RefreshList(false);
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 10;
            //action.TypeCode = 1;
            action.Branch = true;
        }
        /// <summary>
        /// Setup Action
        /// </summary>
        /// <param name="a"></param>
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Else = a.Else; elseBranc.Checked = action.Else;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            cbConditions.SelectedIndex = (int)action.Value[0];
            cbCompare.SelectedIndex = (int)action.Value[1];
            switch ((int)action.Value[0])
            {
                case 0: // Tile
                    operationTypeList.SelectedIndex = (int)action.Value[2];
                    switch ((int)action.Value[2])
                    {
                        case 0: // Const
                            nudScreenX.Value = (decimal)(int)action.Value[3];
                            nudScreenY.Value = (decimal)(int)action.Value[4];
                            break;
                        case 1: // Variable
                            variableXList.Select((int)action.Value[3]);
                            variableYList.Select((int)action.Value[4]);
                            break;
                    }

                    cbTiles.SelectedIndex = (int)action.Value[5];
                    switch ((int)action.Value[5])
                    {
                        case 0: // Tag
                            nudTileTag.Value = (decimal)(int)action.Value[6];
                            break;
                    }
                    break;
                case 1: // Platform
                    cbPlatforms.SelectedIndex = (int)action.Value[2];
                    break;
                case 2: // Load Or Save Exists
                    cbPositionType.SelectedIndex = (int)action.Value[2];
                    if (cbPositionType.SelectedIndex == 0)
                        nudFile.Value = (decimal)(int)action.Value[3];
                    else
                        cbVariable.Select((int)action.Value[3]);
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbConditions.SelectedIndex;
            action.Value[1] = cbCompare.SelectedIndex;
            switch ((int)action.Value[0])
            {
                case 0: // Tile 
                    action.Value[2] = operationTypeList.SelectedIndex;
                    switch ((int)action.Value[2])
                    {
                        case 0: // Const
                            action.Value[3] = (int)nudScreenX.Value;
                            action.Value[4] = (int)nudScreenY.Value;
                            break;
                        case 1: // Variable
                            action.Value[3] = variableXList.Data().ID;
                            action.Value[4] = variableYList.Data().ID;
                            break;
                    }
                    action.Value[5] = cbTiles.SelectedIndex;
                    switch ((int)action.Value[5])
                    {
                        case 0: // Tag
                            action.Value[6] = (int)nudTileTag.Value;
                            break;
                    }
                    break;
                case 1: // Platform
                    action.Value[2] = cbPlatforms.SelectedIndex;
                    break;
                case 2: // Load or Save Exists
                    action.Value[2] = cbPositionType.SelectedIndex;
                    action.Value[3] = (cbPositionType.SelectedIndex == 0 ? (int)nudFile.Value : cbVariable.Data().ID);
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

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }

        private void cbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelTile.Visible = (cbConditions.SelectedIndex == 0);
            panelPlatform.Visible = (cbConditions.SelectedIndex == 1);
            panelLoadSave.Visible = (cbConditions.SelectedIndex == 2);
        }

        private void operationTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            constPanel.Visible = (operationTypeList.SelectedIndex == 0);
            variablesPanel.Visible = (operationTypeList.SelectedIndex == 1);
        }

        private void cbTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelTileTag.Visible = (cbTiles.SelectedIndex == 0);
        }

        private void cbPositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = cbPositionType.SelectedIndex == 0;
            panelVariable.Visible = cbPositionType.SelectedIndex == 1;
        }

    }
}
