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
    public partial class EventConditionDialog : Form
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
                    eventRangeList.RefreshList(false, false, false);
                    eventFacingList.RefreshList(false, false, false);
                    eventDirectionList.RefreshList(false, false, false);
                    cbAtAngle.RefreshList(false, false, false);
                    cbCollidingEvents.RefreshList(true, false, false);
                }
                else if (selectedEvent is EventData)
                {
                    eventRangeList.RefreshList(false, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                    eventFacingList.RefreshList(false, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                    eventDirectionList.RefreshList(false, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                    cbAtAngle.RefreshList(false, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                    eventList.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                    cbCollidingEvents.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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
        public EventConditionDialog()
        {
            InitializeComponent();
            // List Events
            conditionsBox.Enabled = true;
            // Index
            cbDirection.SelectedIndex = 0;
            cbEventState.SelectedIndex = 0;
            cbCompare.SelectedIndex = 0;
            cbForce.SelectedIndex = 0;
            cbTorque.SelectedIndex = 0;
            cbForceOp.SelectedIndex = 0;
            cbTorqueOp.SelectedIndex = 0;
            cbPosOp.SelectedIndex = 0;
            cbProjectiles.RefreshList(false);
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
                case 0:
                    rbIs.Checked = true;
                    cbEventState.SelectedIndex = (int)action.Value[2];
                    break;
                case 1:
                    rbDirection.Checked = true;
                    cbDirection.SelectedIndex = (int)action.Value[2];
                    break;
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
                    //rbScreen.Checked = rbPixel.Checked = false;
                    //if ((int)action.Value[4] == 0)
                    //    rbPixel.Checked = true;
                    //else
                    //    rbScreen.Checked = true;
                    break;
                case 5:
                    rbPositionIs.Checked = true;
                    nudPosX.Value = (decimal)(int)action.Value[2];
                    nudPosY.Value = (decimal)(int)action.Value[3];
                    //rbScreen.Checked = rbPixel.Checked = false;
                    //if ((int)action.Value[4] == 0)
                    //    rbPixel.Checked = true;
                    //else
                    //    rbScreen.Checked = true;
                    cbPosOp.SelectedIndex = (int)action.Value[5];
                    break;
                case 6:
                    rbTileTag.Checked = true;
                    nudTag.Value = (decimal)(int)action.Value[2];
                    break;
                case 7:
                    rbAngle.Checked = true;
                    nudAngle1.Value = (decimal)(int)action.Value[2];
                    nudAngle2.Value = (decimal)(int)action.Value[3];
                    break;
                case 8: // Force
                    rbForceApplied.Checked = true;
                    cbForce.SelectedIndex = (int)action.Value[2];
                    nudForceX.Value = (decimal)action.Value[3];
                    nudForceY.Value = (decimal)action.Value[4];
                    cbForceOp.SelectedIndex = (int)action.Value[5];
                    break;
                case 9: // Angular
                    rbTorque.Checked = true;
                    cbTorque.SelectedIndex = (int)action.Value[2];
                    nudTorque.Value = (decimal)action.Value[3];
                    cbTorqueOp.SelectedIndex = (int)action.Value[5];
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
                case 12: // Is Colliding Projectile
                    rbIsCollidingProjectile.Checked = true;
                    cbProjectiles.Select((int)action.Value[2]);
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

                if (rbIs.Checked)
                {
                    action.Value[1] = 0;
                    action.Value[2] = cbEventState.SelectedIndex;

                    action.Name = "IF Event [" + eventList.Data().Name + "] Is " + cbEventState.Text;
                }
                else if (rbDirection.Checked)
                {
                    action.Value[1] = 1;
                    action.Value[2] = cbDirection.SelectedIndex;

                    action.Name = "IF Event [ " + eventList.Data().Name + " ]  facing " + cbDirection.Text;
                }
                else if (rbInDirection.Checked)
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
                else if (rbPositionIs.Checked)
                {
                    action.Value[1] = 5;
                    action.Value[2] = (int)nudPosX.Value;
                    action.Value[3] = (int)nudPosY.Value;
                    action.Value[5] = cbPosOp.SelectedIndex;

                    action.Name = "IF Event [ " + eventList.Data().Name + " ] Position is X: " + nudPosX.Value.ToString() + " Y: " + nudPosY.Value.ToString() + " ";
                }
                else if (rbTileTag.Checked)
                {
                    action.Value[1] = 6;
                    action.Value[2] = (int)nudTag.Value;

                    action.Name = "IF Event [ " + eventList.Data().Name + " ] is on Tag: " + action.Value[2].ToString();
                }
                else if (rbAngle.Checked)
                {
                    action.Value[1] = 7;
                    action.Value[2] = (int)nudAngle1.Value;
                    action.Value[3] = (int)nudAngle2.Value;
                }
                else if (rbForceApplied.Checked)
                {
                    action.Value[1] = 8;
                    action.Value[2] = cbForce.SelectedIndex;
                    action.Value[3] = nudForceX.Value;
                    action.Value[4] = nudForceY.Value;
                    action.Value[5] = cbForceOp.SelectedIndex;
                }
                else if (rbTorque.Checked)
                {
                    action.Value[1] = 9;
                    action.Value[2] = cbTorque.SelectedIndex;
                    action.Value[3] = nudTorque.Value;
                    action.Value[4] = cbTorqueOp.SelectedIndex;
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
                else if (rbIsCollidingProjectile.Checked)
                {
                    action.Value[1] = 12;
                    action.Value[2] = cbProjectiles.Data().ID;
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
        private void rbIs_CheckedChanged(object sender, EventArgs e)
        {
            cbEventState.Enabled = (rbIs.Checked);
        }

        private void rbDirection_CheckedChanged(object sender, EventArgs e)
        {
            cbDirection.Enabled = (rbDirection.Checked);
        }

        private void rbPositionIs_CheckedChanged(object sender, EventArgs e)
        {
            cbPosOp.Enabled = nudPosX.Enabled = nudPosY.Enabled = rbPositionIs.Checked;
        }

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

        private void rbTileTag_CheckedChanged(object sender, EventArgs e)
        {
            nudTag.Enabled = rbTileTag.Checked;
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }

        private void rbAngle_CheckedChanged(object sender, EventArgs e)
        {
            nudAngle1.Enabled = nudAngle2.Enabled = rbAngle.Checked;
        }

        private void rbForceApplied_CheckedChanged(object sender, EventArgs e)
        {
            cbForceOp.Enabled = cbForce.Enabled = nudForceX.Enabled = nudForceY.Enabled = rbForceApplied.Checked;
        }

        private void rbTorque_CheckedChanged(object sender, EventArgs e)
        {
            cbTorqueOp.Enabled = cbTorque.Enabled = nudTorque.Enabled = rbTorque.Enabled;
        }

        private void rbAtAngle_CheckedChanged(object sender, EventArgs e)
        {
            cbAtAngle.Enabled = nudAtAngle1.Enabled = nudAtAngle2.Enabled = rbAtAngle.Checked;
        }

        private void rbIsColliding_CheckedChanged(object sender, EventArgs e)
        {
            cbCollidingEvents.Enabled = rbIsColliding.Checked;
        }

        private void rbIsCollidingProjectile_CheckedChanged(object sender, EventArgs e)
        {
            cbProjectiles.Enabled = rbIsCollidingProjectile.Checked;
        }
    }
        #endregion
}
