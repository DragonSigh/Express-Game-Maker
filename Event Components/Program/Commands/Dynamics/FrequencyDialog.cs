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
    public partial class FrequencyDialog : Form
    {

        public FrequencyDialog()
        {
            InitializeComponent();

            cbType.SelectedIndex = 0;
            cbVariable.RefreshList(false);
        }

        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                cbLocalVariable.RefreshList(selectedEvent, false);
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
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 6;
            //action.TypeCode = 1;
            if (selectedPage != null)
            {
                action.Value[0] = selectedPage.Frequency;
                speedBox.Value = (decimal)(int)action.Value[0];
            }
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

            cbType.SelectedIndex = (int)action.Value[0];
            switch ((int)action.Value[0])
            {
                case 0:
                    speedBox.Value = (decimal)(int)action.Value[1];
                    break;
                case 1:
                    cbVariable.Select((int)action.Value[1]);
                    break;
                case 2:
                    cbLocalVariable.Select((int)action.Value[1]);
                    break;
            }
        }



        private void okBtn_Click(object sender, EventArgs e)
        {
            // Set Action Name
            action.Value[0] = cbType.SelectedIndex;

            switch ((int)action.Value[0])
            {
                case 0:
                    action.Value[1] = (int)speedBox.Value;
                    break;
                case 1:
                    action.Value[1] = cbVariable.Data().ID;
                    break;
                case 2:
                    action.Value[1] = cbLocalVariable.Data().ID;
                    break;
            }
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = (cbType.SelectedIndex == 0);
            panelVariable.Visible = (cbType.SelectedIndex == 1);
            panelLocalVariable.Visible = (cbType.SelectedIndex == 2);
        }
    }
}
