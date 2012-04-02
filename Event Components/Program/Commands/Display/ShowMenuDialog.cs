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

namespace EGMGame.EventControls.EventDialogs.CommandDialogs.DisplayDialogs
{
    public partial class ShowMenuDialog : Form
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
        public ShowMenuDialog()
        {
            InitializeComponent();

            menuBox.RefreshList(false);
        }
        #endregion
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 2;
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

            menuBox.Select((int)action.Value[0]);
            cbShowOnMap.Checked = (bool)action.Value[1];
            cbDeactivateMap.Checked =(bool)action.Value[2];
            cbMenuClose.Checked = (bool)action.Value[3];
            chkExitMap.Checked = (bool)action.Value[4];
            if (action.Value[5] != null)
                chkHeadsUpDisplay.Checked = (bool)action.Value[5];
        }
        /// <summary>
        /// Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = menuBox.Data().ID;
            action.Value[1] = cbShowOnMap.Checked;
            action.Value[2] = cbDeactivateMap.Checked;
            action.Value[3] = cbMenuClose.Checked;
            action.Value[4] = chkExitMap.Checked;
            action.Value[5] = chkHeadsUpDisplay.Checked;
            // Set Action Name
            action.Name = "Show Menu: [" + menuBox.Data().Name + "]";
            if (cbShowOnMap.Checked)
                action.Name += ", Show on map";
            if (cbShowOnMap.Checked)
                action.Name += ", Heads-up Display";
            if (cbDeactivateMap.Checked)
                action.Name += ", Deactivate map";
            if (cbMenuClose.Checked)
                action.Name += ", Wait until menu closes";
            if (chkExitMap.Checked)
                action.Name += ", Exit Scene";

            action.GetName(selectedEvent, selectedPage);
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
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void chkHeadsUpDisplay_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
