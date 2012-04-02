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
    public partial class UseItemMDialog : Form
    {

        public UseItemMDialog()
        {
            InitializeComponent();

            cbVariable.RefreshList(false);
            cbPartyIndex.RefreshList(false);
            cbList.RefreshList(false);
            cbListPartyIndex.RefreshList(false);
            cbListType.SelectedIndex = 0;
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
            action.ProgramCategory = ProgramCategory.Party;
            action.Code = 6;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            cbVariable.Select((int)action.Value[0]);
            cbPartyIndex.Select((int)action.Value[1]);
            cbListType.SelectedIndex = (int)action.Value[2];
            switch ((int)action.Value[2])
            {
                case 0:
                    cbListPartyIndex.Select((int)action.Value[3]);
                    break;
                case 1:
                    cbList.Select((int)action.Value[3]);
                    break;
            }
            chkApplyCost.Checked = (bool)action.Value[4];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbVariable.Data().ID;
            action.Value[1] = cbPartyIndex.Data().ID;
            action.Value[2] = cbListType.SelectedIndex;
            switch ((int)action.Value[2])
            {
                case 0:
                    action.Value[3] = cbListPartyIndex.Data().ID;
                    break;
                case 1:
                    action.Value[3] = cbList.Data().ID;
                    break;
            }
            action.Value[4] = chkApplyCost.Checked;

            action.GetName(selectedEvent, selectedPage);

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

        private void cbListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelList.Visible = cbListType.SelectedIndex == 1;
            panelPartyMember.Visible = cbListType.SelectedIndex == 0;
        }
    }
}
