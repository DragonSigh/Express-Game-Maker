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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs
{
    public partial class ChangeNameDialog : Form
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
        /// Consturctor
        /// </summary>
        public ChangeNameDialog()
        {
            InitializeComponent();

            cbHero.RefreshList(false);
            cbType.SelectedIndex = 0;
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
            action.ProgramCategory = ProgramCategory.Hero;
            action.Code = 1;
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

            cbHero.Select((int)action.Value[0]);
            cbType.SelectedIndex = (int)action.Value[1];

            switch ((int)action.Value[1])
            {
                case 0:
                    txtValue.Text = (string)action.Value[2];
                    break;
                case 1:
                    cbStrings.Select((int)action.Value[2]);
                    break;
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    pnlString.Visible = false;
                    pnlConstant.Visible = true;
                    break;
                case 1:
                    pnlConstant.Visible = false;
                    pnlString.Visible = true;
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (cbHero.Data().ID > -1)
            {
                action.Value[0] = cbHero.Data().ID;
                action.Value[1] = cbType.SelectedIndex;

                switch ((int)action.Value[1])
                {
                    case 0:
                        action.Value[2] = txtValue.Text;
                        break;
                    case 1:
                        action.Value[2] = cbStrings.Data().ID;
                        break;
                }
                action.GetName(selectedEvent, selectedPage);
                this.DialogResult = DialogResult.OK;
            }
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
