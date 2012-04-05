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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Screen_Dialogs
{
    public partial class ZoomDialog : Form
    {
        public ZoomDialog()
        {
            InitializeComponent();

            cbType.SelectedIndex = 0;
            cbVarX.RefreshList(false);
            cbVarY.RefreshList(false);
        }

        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;

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
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            if (Programs != null)
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Screen;
            action.Code = 6;
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
            switch (cbType.SelectedIndex)
            {
                case 0:
                    nudZoomX.Value = (int)action.Value[1];
                    nudZoomY.Value = (int)action.Value[2];
                    break;
                case 1:
                    cbVarX.Select((int)action.Value[1]); 
                    cbVarX.Select((int)action.Value[2]);
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbType.SelectedIndex;
            action.Value[1] = (cbType.SelectedIndex == 0 ? (int)nudZoomX.Value : cbVarX.Data().ID);
            action.Value[2] = (cbType.SelectedIndex == 0 ? (int)nudZoomY.Value : cbVarY.Data().ID);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = cbType.SelectedIndex == 0;
            panelVar.Visible = cbType.SelectedIndex == 1;
        }
    }
}
