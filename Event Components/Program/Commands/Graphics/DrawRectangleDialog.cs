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

namespace EGMGame.EventControls.EventDialogs.CommandDialogs.DrawingDialogs
{
    public partial class DrawRectangleDialog : Form
    {
        #region Constructor
        public DrawRectangleDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Properties
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; Setup(); }
        }
        EventPageData selectedPage;

        public IEvent SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; 
            
            }
        }
        IEvent selEvent;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        #endregion
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;


        #region Setup Methods
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Graphics;
            action.Code = 2;

            PopulateAll();
        }

        private void SetupAction(EventProgramData a)
        {
            PopulateAll();

            action = new EventProgramData();
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            CheckAll();
            CheckAllUI();
        }
        #endregion        

        #region UI/Value Checks

        private void CheckAll()
        {
            CheckDrawRectangleBox();
        }

        private void CheckDrawRectangleBox()
        {

            switch ((int)action.Value[0])
            {
                case 1:
                    rbStartEvent.Checked = true;

                    nudStartScreenX.Value = (decimal)((Vector2)action.Value[1]).X;
                    nudStartScreenY.Value = (decimal)((Vector2)action.Value[1]).Y;
                    break;
                case 2:
                    rbStartScreen.Checked = true;

                    nudStartEventX.Value = (decimal)((Vector2)action.Value[1]).X;
                    nudStartEventY.Value = (decimal)((Vector2)action.Value[1]).Y;

                    cbStartEvent.Select((int)action.Value[2]);

                    break;
            }
            switch ((int)action.Value[3])
            {
                case 1:
                    rbEndEvent.Checked = true;

                    nudEndScreenX.Value = (decimal)((Vector2)action.Value[4]).X;
                    nudEndScreenY.Value = (decimal)((Vector2)action.Value[4]).Y;
                    break;
                case 2:
                    rbEndScreen.Checked = true;

                    nudEndEventX.Value = (decimal)((Vector2)action.Value[4]).X;
                    nudEndEventY.Value = (decimal)((Vector2)action.Value[4]).Y;

                    cbEndEvent.Select((int)action.Value[5]);

                    break;
            }
        }
        #endregion

        #region UI Checks

        private void CheckAllUI()
        {
            CheckDrawRectangleUI();
        }

        private void CheckDrawRectangleUI()
        {
            if (rbStartEvent.Checked)
                cbStartEvent.Enabled = nudStartEventX.Enabled = nudStartEventY.Enabled = true;
            else
                cbStartEvent.Enabled = nudStartEventX.Enabled = nudStartEventY.Enabled = false;

            if (rbStartScreen.Checked)
                nudStartScreenX.Enabled = nudStartScreenY.Enabled = true;
            else
                nudStartScreenX.Enabled = nudStartScreenY.Enabled = false;

            if (rbEndEvent.Checked)
                cbEndEvent.Enabled = nudEndEventX.Enabled = nudEndEventY.Enabled = true;
            else
                cbEndEvent.Enabled = nudEndEventX.Enabled = nudEndEventY.Enabled = false;

            if (rbEndScreen.Checked)
                nudEndScreenX.Enabled = nudEndScreenY.Enabled = true;
            else
                nudEndScreenX.Enabled = nudEndScreenY.Enabled = false;
        }
        #endregion

        #region Population
        
        private void PopulateAll()
        {
            PopulateEventCondBox();
        }

        private void PopulateEventCondBox()
        {
            // Events
            cbStartEvent.Items.Clear();
            cbEndEvent.Items.Clear();

        }

        #endregion

        #region Form Drawing Code
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        #endregion

        #region Value Setting

        private void SetAll()
        {
            SetDrawRectangle();
        }

        private void SetDrawRectangle()
        {
            // Radio buttons
            if (rbStartScreen.Checked)
            {
                action.Value[0] = 1;
                action.Value[1] = new Vector2((float)nudStartScreenX.Value, (float)nudStartScreenY.Value);
            }
            else if (rbStartEvent.Checked)
            {
                action.Value[0] = 2;
                action.Value[1] = new Vector2((float)nudStartEventX.Value, (float)nudStartEventY.Value);
                action.Value[2] = ((EventData)cbStartEvent.SelectedItem).ID;
            }

            if (rbEndScreen.Checked)
            {
                action.Value[0] = 1;
                action.Value[1] = new Vector2((float)nudEndScreenX.Value, (float)nudEndScreenY.Value);
            }
            else if (rbEndEvent.Checked)
            {
                action.Value[0] = 2;
                action.Value[1] = new Vector2((float)nudEndEventX.Value, (float)nudEndEventY.Value);
                action.Value[2] = ((EventData)cbEndEvent.SelectedItem).ID;
            }
        }
        #endregion

        #region Name Setting
        private void SetName()
        {
            action.Name = "Draw Rectangle - Start: " + 
                GetStartPointName() + " End: " +
                GetEndPointName();
        }
        private string GetStartPointName()
        {
            switch ((int)action.Value[0])
            {
                case 1:
                    return "Position (" + nudStartScreenX.Value.ToString() + ", " + nudStartScreenY.Value.ToString() + ")";
                case 2:
                    return "Event " + cbStartEvent.SelectedText + " Offset: (" + nudStartEventX.Value.ToString() + ", " + nudStartEventY.Value.ToString() + ")";
            }
            return "";
        }
        private string GetEndPointName()
        {
            switch ((int)action.Value[3])
            {
                case 1:
                    return "Position (" + nudEndScreenX.Value.ToString() + ", " + nudEndScreenY.Value.ToString() + ")";
                case 2:
                    return "Event " + cbEndEvent.SelectedText + " Offset: (" + nudEndEventX.Value.ToString() + ", " + nudEndEventY.Value.ToString() + ")";
            }
            return "";
        }
        #endregion

        #region Control Events
        private void okBtn_Click(object sender, EventArgs e)
        {
            // Set Value return
            SetAll();
            // Set name return
            SetName();
        }

        private void rbStartScreen_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllUI();
        }

        private void rbStartEvent_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllUI();
        }

        private void rbEndScreen_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllUI();
        }

        private void rbEndEvent_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllUI();
        }
        #endregion
    }
}
