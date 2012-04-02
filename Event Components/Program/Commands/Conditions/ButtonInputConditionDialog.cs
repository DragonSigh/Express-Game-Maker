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
    public partial class ButtonInputConditionDialog : Form
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

        /// <summary>
        /// Constructor
        /// </summary>
        public ButtonInputConditionDialog()
        {
            InitializeComponent();

            playerList.SelectedIndex = 0;
            keyStateList.SelectedIndex = 0;
            keyList.SelectedIndex = 0;
            btnList.SelectedIndex = 0;
            btnStateList.SelectedIndex = 0;
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 5;
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
            // Keys
            keyboardBtn.Checked = (bool)action.Value[0];
            keyList.SelectedIndex = (int)action.Value[1];
            keyStateList.SelectedIndex = (int)action.Value[2];

            // Buttons
            xboxBtn.Checked = (bool)action.Value[3];
            btnList.SelectedIndex = (int)action.Value[4];
            btnStateList.SelectedIndex = (int)action.Value[5];
            playerList.SelectedIndex = (int)action.Value[6];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (keyboardBtn.Checked || xboxBtn.Checked)
            {
                // Keys
                action.Value[0] = keyboardBtn.Checked;
                action.Value[1] = keyList.SelectedIndex;
                action.Value[2] = keyStateList.SelectedIndex;

                // Buttons
                action.Value[3] = xboxBtn.Checked;
                action.Value[4] = btnList.SelectedIndex;
                action.Value[5] = btnStateList.SelectedIndex;

                action.Value[6] = playerList.SelectedIndex;

                action.Name = "IF Input ";
                if (keyboardBtn.Checked)
                {
                    action.Name +=  "Keyboard: " + keyList.Text + " is " + keyStateList.Text;
                    if (xboxBtn.Checked)
                        action.Name += " OR ";
                }
                if (xboxBtn.Checked)
                {
                    action.Name += "Controller: " + btnList.Text + " is " + btnStateList.Text;
                }
            }
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void keyboardBtn_CheckedChanged(object sender, EventArgs e)
        {
            keyList.Enabled = keyStateList.Enabled = keyboardBtn.Checked;
        }

        private void xboxBtn_CheckedChanged(object sender, EventArgs e)
        {
            playerList.Enabled = btnList.Enabled = btnStateList.Enabled = xboxBtn.Checked;
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }
    }
}
