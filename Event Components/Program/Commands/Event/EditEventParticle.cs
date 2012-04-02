using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs
{
    public partial class EditEventParticle : Form
    {
        public EditEventParticle()
        {
            InitializeComponent();
            cbParticles.RefreshList(false);
        }

        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    cbEvents.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    cbEvents.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 8;
        }
        /// <summary>
        /// Setup action
        /// </summary>
        /// <param name="a"></param>
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            cbEvents.Select((int)action.Value[0]);
            cbParticles.Select((int)action.Value[1]);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbEvents.Data().ID;
            action.Value[1] = cbParticles.Data().ID;
            action.GetName(selectedEvent, selectedPage);
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
