using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.OtherDialogs
{
    public partial class LockScreenDialog : Form
    {
        public LockScreenDialog()
        {
            InitializeComponent();
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
            action.Code = 13;
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

            nudX.Value = (decimal)(int)action.Value[0];
            nudY.Value = (decimal)(int)action.Value[1];
            nudWidth.Value = (decimal)(int)action.Value[2];
            nudHeight.Value = (decimal)(int)action.Value[3];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)nudX.Value;
            action.Value[1] = (int)nudY.Value;
            action.Value[2] = (int)nudWidth.Value;
            action.Value[3] = (int)nudHeight.Value;
            action.Name = "Lock Screen: X: " + action.Value[0].ToString() + " Y: " + action.Value[1].ToString() + " Width [" + action.Value[2].ToString() + "] Height [" + action.Value[3].ToString() + "]";
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
