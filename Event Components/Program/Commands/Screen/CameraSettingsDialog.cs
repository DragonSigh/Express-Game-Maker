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
    public partial class CameraSettingsDialog : Form
    {
        public CameraSettingsDialog()
        {
            InitializeComponent();

            cbHor.SelectedIndex = 0;
            cbVert.SelectedIndex = 0;
        }
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

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Map;
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
            cbVert.SelectedIndex = (int)action.Value[0];
            nudVert.Value = (decimal)(int)action.Value[1];
            cbHor.SelectedIndex = (int)action.Value[2];
            nudHor.Value = (decimal)(int)action.Value[3];
            nudSpeed.Value = (decimal)(int)action.Value[4];
        }
        /// <summary>
        /// Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbVert.SelectedIndex;
            action.Value[1] = (int)nudVert.Value;
            action.Value[2] = cbHor.SelectedIndex;
            action.Value[3] = (int)nudHor.Value;
            action.Value[4] = (int)nudSpeed.Value;

            action.Name = "Scroll Camera: " + cbVert.Text + " [" + nudVert.Value.ToString() + "] " + cbHor.Text + " [" + nudHor.Value.ToString() + "] Speed [" + nudSpeed.Value.ToString() + "]" ; 
            this.DialogResult = DialogResult.OK;
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

        private void impactGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
