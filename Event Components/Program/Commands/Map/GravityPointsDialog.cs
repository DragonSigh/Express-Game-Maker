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
    public partial class GravityPointsDialog : Form
    {
        public GravityPointsDialog()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;


            cbStrength.RefreshList(false);
            cbRadius.RefreshList(false);
            cbMapX.RefreshList(false);
            cbMapY.RefreshList(false);
            cbAddRemove.SelectedIndex = 0;
        }
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();

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
            nudIndex.Value = (decimal)(int)action.Value[0];
            cbAddRemove.SelectedIndex = ((bool)action.Value[1] ? 0 : 1);

            cbType.SelectedIndex = (int)action.Value[2];

            switch ((int)action.Value[2])
            {
                case 0: // Constant
                    nudStr.Value = (decimal)(float)action.Value[3];
                    nudR.Value = (decimal)(float)action.Value[4];
                    nudMapX.Value = (decimal)(float)action.Value[5];
                    nudMapY.Value = (decimal)(float)action.Value[6];
                    break;
                case 1: // Variabe
                    cbStrength.Select((int)(float)action.Value[3]);
                    cbRadius.Select((int)(float)action.Value[4]);
                    cbMapX.Select((int)(float)action.Value[5]);
                    cbMapY.Select((int)(float)action.Value[6]);
                    break;
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    panelVariable.Visible = false;
                    panelConstant.Visible = true;
                    break;
                case 1:
                    panelConstant.Visible = false;
                    panelVariable.Visible = true;
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)nudIndex.Value;
            action.Value[1] = (cbAddRemove.SelectedIndex == 0);
            action.Value[2] = cbType.SelectedIndex;


            switch ((int)action.Value[2])
            {
                case 0: // Constant
                    action.Value[3] = (float)nudStr.Value;
                    action.Value[4] = (float)nudR.Value;
                    action.Value[5] = (float)nudMapX.Value;
                    action.Value[6] = (float)nudMapY.Value;
                    break;
                case 1: // Variabe
                    action.Value[3] = (float)cbStrength.Data().ID;
                    action.Value[4] = (float)cbRadius.Data().ID;
                    action.Value[5] = (float)cbMapX.Data().ID;
                    action.Value[6] = (float)cbMapY.Data().ID;
                    break;
            }

            this.DialogResult = DialogResult.OK;


            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbAddRemove_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelSettings.Enabled = cbAddRemove.SelectedIndex == 0;
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            // Show map
            if (MainForm.SelectedMap != null)
            {
                // Show map
                PickPositionOnMapDialog dialog = new PickPositionOnMapDialog();
                dialog.DoNotDrawPlayer = true;
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
