//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    public partial class HotKeysDialog : Form
    {

        public HotKeysDialog()
        {
            InitializeComponent();
            cbActionBtn.SelectedIndex = 0;
            cbActionBtn2.SelectedIndex = 0;
            cbActionKey.SelectedIndex = 0;
            cbActionKey2.SelectedIndex = 0;
            cbConditions.SelectedIndex = 0;
            cbIndexType.SelectedIndex = 0;
            cbItems.RefreshList(false);
            cbSkills.RefreshList(false);
            cbVariable.RefreshList(false);
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
            action.ProgramCategory = ProgramCategory.Other;
            action.Code = 12;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;


            cbActionBtn.SelectedIndex = (int)action.Value[0];
            cbActionBtn2.SelectedIndex = (int)action.Value[1];
            cbActionKey.SelectedIndex = (int)action.Value[2];
            cbActionKey2.SelectedIndex = (int)action.Value[3];
            cbConditions.SelectedIndex = (int)action.Value[4];
            cbIndexType.SelectedIndex = (int)action.Value[5];

            if ((int)action.Value[5] == 0)
            {
                switch ((int)action.Value[4])
                {
                    case 0:
                        cbSkills.Select((int)action.Value[6]);
                        break;
                    case 1:
                        cbItems.Select((int)action.Value[6]);
                        break;
                }
            }
            else
                cbVariable.Select((int)action.Value[6]);
            chkDont.Checked = (bool)action.Value[7];
            btnKeyboard.Checked = (bool)action.Value[8];
            btnController.Checked = !(bool)action.Value[8];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbActionBtn.SelectedIndex;
            action.Value[1] = cbActionBtn2.SelectedIndex;
            action.Value[2] = cbActionKey.SelectedIndex;
            action.Value[3] = cbActionKey2.SelectedIndex;
            action.Value[4] = cbConditions.SelectedIndex;
            action.Value[5] = cbIndexType.SelectedIndex;

            if ((int)action.Value[5] == 0)
            {
                switch ((int)action.Value[4])
                {
                    case 0:
                        action.Value[6] = cbItems.Data().ID;
                        break;
                    case 1:
                        action.Value[6] = cbSkills.Data().ID;
                        break;
                }
            }
            else
            {
                action.Value[6] = cbVariable.Data().ID;
            }
            action.Value[7] = chkDont.Checked;
            action.Value[8] = btnKeyboard.Checked;
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

        private void cbIndexType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = cbIndexType.SelectedIndex == 0;
            panelVariable.Visible = cbIndexType.SelectedIndex == 1;
        }

        private void cbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelSkill.Visible = cbConditions.SelectedIndex == 0;
            panelItem.Visible = cbConditions.SelectedIndex == 1;
        }
    }
}
