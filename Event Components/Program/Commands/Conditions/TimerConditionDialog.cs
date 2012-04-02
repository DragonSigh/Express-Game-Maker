using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.ConditionDialogs
{
    public partial class TimerConditionDialog : Form
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

        public TimerConditionDialog()
        {
            InitializeComponent();
            // Refresh variables
            variableList.RefreshList(false);
            operationsList.SelectedIndex = 0;
            settingsBox.Enabled = true;
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
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 8;
            //action.TypeCode = 1;
            action.Branch = true;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Else = a.Else; elseBranc.Checked = action.Else;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Control
            operationsList.SelectedIndex = (int)action.Value[0];
            // Set Data
            if (GameData.Variables.ContainsKey((int)action.Value[1]))
            {
                variableList.Select((int)action.Value[1]);
                hoursBox.Value = (decimal)(int)action.Value[2];
                minutesBox.Value = (decimal)(int)action.Value[3];
                secondsBox.Value = (decimal)(int)action.Value[4];
            }
        }
        /// <summary>
        /// Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (variableList.Data().ID > -10)
            {
                action.Value[0] = operationsList.SelectedIndex;
                action.Value[1] = variableList.Data().ID;
                action.Value[2] = (int)hoursBox.Value;
                action.Value[3] = (int)minutesBox.Value;
                action.Value[4] = (int)secondsBox.Value;

                action.Name = "IF Timer [Variable: " + variableList.Data().Name + "]" + GetOperation() + " [" + hoursBox.Value.ToString() + ":" + minutesBox.Value.ToString() + ":" + secondsBox.Value.ToString() + "]";
                action.GetName(selectedEvent, selectedPage);
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private string GetOperation()
        {
            switch (operationsList.SelectedIndex)
            {
                case 0:
                    return " (=) Equals ";
                case 1:
                    return " (>) Greater Than ";
                case 2:
                    return " (<) Less Than ";
                case 3:
                    return " (>=) Greater Than Or Equals ";
                case 4:
                    return " (<=) Less Than Or Equals ";
                case 5:
                    return " (!=) Does Not Equal ";
            }
            return " Error ";
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Control type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }
    }
}
