using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using Microsoft.Xna.Framework;

namespace EGMGame
{
    public partial class TEventConditionDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                {
                    eventList.RefreshList(true, false, false);
                    eventRangeList.RefreshList(false);
                    eventFacingList.RefreshList(false);
                    eventDirectionList.RefreshList(false);
                    cbAtAngle.RefreshList(false);
                    cbCollidingEvents.RefreshList(false);
                }
                else if (selectedEvent is EventData)
                {
                    eventList.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                    eventRangeList.RefreshList(false);
                    eventFacingList.RefreshList(false);
                    eventDirectionList.RefreshList(false);
                    cbAtAngle.RefreshList(false);
                    cbCollidingEvents.RefreshList(false);
                }
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

        #region Constructor
        public TEventConditionDialog()
        {
            InitializeComponent();
            // List Events
            conditionsBox.Enabled = true;
            // Index
            cbCompare.SelectedIndex = 0;
        }
        #endregion
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 7;
            //action.TypeCode = 1;
            action.Branch = true;
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
            action.Else = a.Else; elseBranc.Checked = action.Else;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            // Setup Data
            eventList.Select((int)action.Value[0]);
            // 
            switch ((int)action.Value[1])
            {
                case 2:
                    rbInDirection.Checked = true;
                    eventDirectionList.Select((int)action.Value[2]);
                    break;
                case 3:
                    rbFacingEvent.Checked = true;
                    eventFacingList.Select((int)action.Value[2]);
                    break;
                case 4:
                    rbInRange.Checked = true;
                    eventRangeList.Select((int)action.Value[2]);
                    nudRange.Value = (int)action.Value[3];
                    break;
                case 10: // At Angle
                    rbAtAngle.Checked = true;
                    cbAtAngle.Select((int)action.Value[2]);
                    nudAtAngle1.Value = (decimal)(int)action.Value[3];
                    nudAtAngle2.Value = (decimal)(int)action.Value[4];
                    break;
                case 11: // Is Colliding
                    rbIsColliding.Checked = true;
                    cbCollidingEvents.Select((int)action.Value[2]);
                    break;
            }
            cbCompare.SelectedIndex = (int)action.Value[6];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (eventList.Data().ID > -10)
            {
                action.Value[6] = cbCompare.SelectedIndex;
                // Set Data
                action.Value[0] = eventList.Data().ID;

                if (rbInDirection.Checked)
                {
                    action.Value[1] = 2;
                    action.Value[2] = eventDirectionList.Data().ID;

                    action.Name = "IF Event [ " + eventList.Data().Name + " ] Is in direction of [ " + eventDirectionList.Data().Name + " ]";
                }
                else if (rbFacingEvent.Checked)
                {
                    action.Value[1] = 3;
                    action.Value[2] = eventFacingList.Data().ID;

                    action.Name = "IF Event [ " + eventList.Data().Name + " ] Is facing [ " + eventFacingList.Data().Name + " ]";
                }
                else if (rbInRange.Checked)
                {
                    action.Value[1] = 4;
                    action.Value[2] = eventRangeList.Data().ID;
                    action.Value[3] = (int)nudRange.Value;

                    action.Name = "IF Event [ " + eventList.Data().Name + " ] In range of [ " + eventRangeList.Data().Name + " ]  Range: " + nudRange.Value.ToString();
                }              
                else if (rbAtAngle.Checked)
                {
                    action.Value[1] = 10;
                    action.Value[2] = cbAtAngle.Data().ID;
                    action.Value[3] = (int)nudAtAngle1.Value;
                    action.Value[4] = (int)nudAtAngle2.Value;
                }
                else if (rbIsColliding.Checked)
                {
                    action.Value[1] = 11;
                    action.Value[2] = cbCollidingEvents.Data().ID;
                }
                action.GetName(selectedEvent, selectedPage);
                // Close
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Enable/Disable
       
        private void rbInRange_CheckedChanged(object sender, EventArgs e)
        {
            eventRangeList.Enabled = nudRange.Enabled = rbInRange.Checked;
        }

        private void rbInDirection_CheckedChanged(object sender, EventArgs e)
        {
            eventDirectionList.Enabled = rbInDirection.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            eventFacingList.Enabled = rbFacingEvent.Checked;
        }

        
        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }

       

        private void rbAtAngle_CheckedChanged(object sender, EventArgs e)
        {
            cbAtAngle.Enabled = nudAtAngle1.Enabled = nudAtAngle2.Enabled = rbAtAngle.Checked;
        }

        private void rbIsColliding_CheckedChanged(object sender, EventArgs e)
        {
            cbCollidingEvents.Enabled = rbIsColliding.Checked;
        }

    }
        #endregion
}
