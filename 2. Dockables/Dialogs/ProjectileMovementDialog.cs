using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls
{
    public partial class ProjectileMovementDialog : Form
    {
        public ProjectileMovementDialog()
        {
            InitializeComponent();

            cbUseForce.SelectedIndex = 0;
            cbMovement.SelectedIndex = 0;
        }
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

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 0;
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
            cbMovement.SelectedIndex = (int)action.Value[0];
            cbUseForce.SelectedIndex = (int)action.Value[1];
            pixelBox.Value = (decimal)(int)action.Value[2];
            turnBox.Checked = (bool)action.Value[3];
            chWait.Checked = (bool)action.Value[4];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)cbMovement.SelectedIndex;
            action.Value[1] = (int)cbUseForce.SelectedIndex;
            action.Value[2] = (int)pixelBox.Value;
            action.Value[3] = turnBox.Checked;
            action.Value[4] = chWait.Checked;
            // Set Action Name
            action.Name = "Move " + cbMovement.Text + ": " + pixelBox.Value.ToString() + " - Turn: " + turnBox.Checked.ToString() + " - Wait:" + chWait.Checked.ToString();
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
