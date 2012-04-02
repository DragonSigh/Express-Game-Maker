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
    public partial class HeroConditionsDialog : Form
    {

        public HeroConditionsDialog()
        {
            InitializeComponent();

            cbHeroes.RefreshList(false);
            cbItems.RefreshList(false);
            cbEquipments.RefreshList(false);
            cbSkills.RefreshList(false);
            cbConditionTypes.SelectedIndex = 0;
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
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 12;
            action.Branch = true;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            cbHeroes.Select((int)action.Value[0]);
            cbConditionTypes.SelectedIndex = (int)action.Value[1];

            switch ((int)action.Value[0])
            {
                case 0: // Items
                    cbItems.Select((int)action.Value[2]);
                    break;
                case 1: // Equipment
                     cbEquipments.Select((int)action.Value[2]);
                    break;
                case 2: // Skills/Magic
                    cbSkills.Select((int)action.Value[2]);
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbHeroes.Data().ID;
            action.Value[1] = cbConditionTypes.SelectedIndex;

            switch ((int)action.Value[0])
            {
                case 0: // Items
                    action.Value[2] = cbItems.Data().ID;
                    break;
                case 1: // Equipment
                    action.Value[2] = cbEquipments.Data().ID;
                    break;
                case 2: // Skills/Magic
                    action.Value[2] = cbSkills.Data().ID;
                    break;
            }
            action.Else = elseBranc.Checked;
            action.GetName(SelectedEvent, SelectedPage);
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

        private void cbConditionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelItem.Visible = (cbConditionTypes.SelectedIndex == 0);
            panelEquip.Visible = (cbConditionTypes.SelectedIndex == 1);
            panelSkills.Visible = (cbConditionTypes.SelectedIndex == 2);
        }
    }
}
