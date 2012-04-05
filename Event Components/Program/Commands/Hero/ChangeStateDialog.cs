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
    public partial class ChangeStateDialog : Form
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
        public ChangeStateDialog()
        {
            InitializeComponent();

            cbHero.RefreshList(false);
            cbStates.RefreshList(false);
            cbType.SelectedIndex = 0;
        }/// <summary>
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
            action.Code = 3;
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
            cbStates.Select((int)action.Value[2]);

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (cbHero.Data().ID > -1)
            {
                action.Value[0] = cbHero.Data().ID;
                action.Value[1] = cbType.SelectedIndex;
                action.Value[2] = cbStates.Data().ID;

                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
