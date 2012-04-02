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
    public partial class TimerDialog : Form
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
        /// Timer
        /// </summary>
        public TimerDialog()
        {
            InitializeComponent();
            // Refresh variables
            variableList.RefreshList(false);
            controlBox.SelectedIndex = 0;
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
            action.ProgramCategory = ProgramCategory.Other;
            action.Code = 4;
            //action.TypeCode = 1;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Control
            controlBox.SelectedIndex = (int)action.Value[0];
            // Set Data
            if (GameData.Variables.ContainsKey((int)action.Value[1]))
            {
                variableList.Select((int)action.Value[1]);
                hoursBox.Value = (decimal)(int)action.Value[2];
                minutesBox.Value = (decimal)(int)action.Value[3];
                secondsBox.Value = (decimal)(int)action.Value[4];
                if ((int)action.Value[5] == 0)
                {
                    increaseBtn.Checked = true;
                }
                else
                {
                    decreaseBtn.Checked = true;
                }
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
                action.Value[0] = controlBox.SelectedIndex;
                action.Value[1] = variableList.Data().ID;
                action.Value[2] = (int)hoursBox.Value;
                action.Value[3] = (int)minutesBox.Value;
                action.Value[4] = (int)secondsBox.Value;

                string type = "Error";
                if (increaseBtn.Checked)
                {
                    action.Value[5] = 0;
                    type = "Increase";
                }
                else if (decreaseBtn.Checked)
                {
                    action.Value[5] = 1;
                    type = "Decrease";
                }
                action.Name = controlBox.Text + " Timer: Variable " + variableList.Data().Name + " [" + hoursBox.Value.ToString() + ":" + minutesBox.Value.ToString() + ":" + secondsBox.Value.ToString() + "] [" + type + "]";
                action.GetName(selectedEvent, selectedPage);
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
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
            // Enable/disable settings box.
            if (controlBox.SelectedIndex == 0 || controlBox.SelectedIndex == 1)
            {
                settingsBox.Enabled = true;
            }
            else
            {
                settingsBox.Enabled = false;
            }
        }
    }
}
