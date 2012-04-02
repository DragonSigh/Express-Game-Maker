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
    public partial class EventLayerDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup(); 
                
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    eventList.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    eventList.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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

        public EventLayerDialog()
        {
            InitializeComponent();

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
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 7;
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

            eventList.Select((int)action.Value[0]);
            nudLayer.Value = (decimal)(int)action.Value[1];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (eventList.Data().ID > -10)
            {
                action.Value[0] = eventList.Data().ID;
                action.Value[1] = (int)nudLayer.Value;
                action.Name = "Change Event " + eventList.Data().Name + "'s Layer To Layer " + nudLayer.Value.ToString();
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
