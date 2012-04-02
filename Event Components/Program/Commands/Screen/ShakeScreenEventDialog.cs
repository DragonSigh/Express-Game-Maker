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
    public partial class ShakeScreenEventDialog : Form
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

        public ShakeScreenEventDialog()
        {
            InitializeComponent();
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
            action.ProgramCategory = ProgramCategory.Screen;
            action.Code = 5;
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


            nudPower.Value = (decimal)(int)action.Value[0];
            nudFrames.Value = (decimal)(int)action.Value[1];
            nudFreq.Value = (decimal)(int)action.Value[2];
            waitBox.Checked = (bool)action.Value[3];
            chkGlobal.Checked = (bool)action.Value[4];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

            action.Value[0] = (int)nudPower.Value;
            action.Value[1] = (int)nudFrames.Value;
            action.Value[2] = (int)nudFreq.Value;
            action.Value[3] = waitBox.Checked;
            action.Value[4] = chkGlobal.Checked;

            action.Name = "Shake Screen: Power: " + nudPower.Value.ToString() + " Frequency: " +  nudFreq.Value.ToString() + " Frames: " + nudFrames.Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
