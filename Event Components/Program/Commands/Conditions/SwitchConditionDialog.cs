using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls;

namespace EGMGame
{
    public partial class SwitchConditionDialog : Form
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

        #region Constructor
        public SwitchConditionDialog()
        {
            InitializeComponent();
            operationsList.SelectedIndex = 0;
        }
        #endregion

        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 1;
            //action.TypeCode = 1;
            action.Branch = true;
            // Refresh List
            addRemoveList.SetupList(GameData.Switches, typeof(VariableData));

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
            action.Else = a.Else; elseBranc.Checked = action.Else;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            action.Branch = true;
            // Setup Data
            switchesBtn.Checked = ((int)action.Value[4] == 0);
            localBtn.Checked = ((int)action.Value[4] == 1);
            addRemoveList.Select((int)action.Value[0]);
            operationsList.SelectedIndex = (int)action.Value[1];

            // Switch
            // Local Switch
            switch ((int)action.Value[2])
            {
                case 0: // Constant
                    if ((bool)action.Value[3])
                    {
                        onBtn.Checked = true;
                    }
                    else
                    {
                        offBtn.Checked = true;
                    }
                    break;
                case 1: // Switch
                    switchesList.Select((int)action.Value[3]);
                   break;
                case 2: // Local switch
                    localSwitchesList.Select((int)action.Value[3]);
                    break;
            }
        }
        /// <summary>
        /// Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (addRemoveList.SelectedIndex > -1)
            {
                if (switchesBtn.Checked)
                    action.Value[4] = 0;
                else
                    action.Value[4] = 1;

                // Set Data
                action.Value[0] = addRemoveList.SelectedID;
                action.Value[1] = operationsList.SelectedIndex;
                if (onBtn.Checked || offBtn.Checked)
                    action.Value[2] = 0;
                else if (switchesBtn.Checked)
                    action.Value[2] = 1;
                else
                    action.Value[2] = 2;
                //Constant 0
                //Random Number 1
                //Variable 2
                //Local Variable 3
                //Event 4
                //Data 5 
                //Other 6
                switch ((int)action.Value[2])
                {
                    case 0:
                        action.Value[3] = (onBtn.Checked);
                        break;
                    case 1:
                        action.Value[3] = switchesList.Data().ID;
                        break;
                    case 2:
                        action.Value[3] = localSwitchesList.Data().ID;
                        break;
                }

                string type = "IF Switch ";
                if (localBtn.Checked)
                    type = "IF Local Switch ";
                action.Name = type + addRemoveList.Data().Name + " " + GetOperator() + " " + GetTypeOperator();
                action.GetName(selectedEvent, selectedPage);
                // Close
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private string GetTypeOperator()
        {
            switch ((int)action.Value[2])
            {
                case 0: // Constant
                    if (onBtn.Checked)
                        return "On";
                    else
                        return "Off";
                case 1: // Rand
                    return "Switch " + switchesList.Data().Name + "";
                case 2:
                    return "Local Switch " + localSwitchesList.Data().Name + "";
            }
            return "Error";
        }

        private string GetOperator()
        {
            switch (operationsList.SelectedIndex)
            {
                case 0:
                    return "(=) Equals";
                case 1:
                    return "(!=) Does Not Equal";
            }
            return "Error";
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Cancel
            this.Close();
        }
        /// <summary>
        /// Variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void variablesBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (switchesBtn.Checked)
            {
                addRemoveList.SetupList(GameData.Switches, typeof(SwitchData));
            }
            else
            {
                addRemoveList.SetupList(SelectedEvent.Switches, typeof(SwitchData));
            }
            operationsBox.Enabled = (addRemoveList.Count > 0);
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID > -10)
                operationsBox.Enabled = true;
            else
                operationsBox.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                switchesList.Enabled = true;
            }
            else
                switchesList.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                localSwitchesList.Enabled = true;
            }
            else
                localSwitchesList.Enabled = false;
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }

    }
}
