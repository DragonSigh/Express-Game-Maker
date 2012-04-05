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
using EGMGame.Controls.EventControls.EventDialogs;

namespace EGMGame
{
    public partial class ScrollCameraToDialog : Form
    {
        public ScrollCameraToDialog()
        {
            InitializeComponent();
            variableXList.RefreshList(false);
            variableYList.RefreshList(false);
            coordinateType.SelectedIndex = 0;
        }
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

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Map;
            action.Code = 7;
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
            nudSpeed.Value = (decimal)(int)action.Value[0];
        }
        /// <summary>
        /// Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = (int)nudSpeed.Value;
            action.Value[1] = coordinateType.SelectedIndex;

            if (coordinateType.SelectedIndex == 0)
            {
                action.Value[2] = (int)nudX.Value;
                action.Value[3] = (int)nudY.Value;
            }
            else
            {
                if (variableXList.Data() == null || variableYList.Data() == null)
                {
                    this.Close(); return;
                }

                action.Value[2] = variableXList.Data().ID;
                action.Value[3] = variableYList.Data().ID;
            }

            action.Name = "Scroll Camera To: X [] Y [] Frames [" + action.Value[0].ToString() + "]" ; 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void coordinateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coordinateType.SelectedIndex == 0)
            {
                variablePanel.Visible = false;
                constantPanel.Visible = true;
            }
            else
            {
                constantPanel.Visible = false;
                variablePanel.Visible = true;
            }
        }

        private void showMapBtn_Click(object sender, EventArgs e)
        {
            if (MainForm.SelectedMap != null)
            {
                // Show map
                PickPositionOnMapDialog dialog = new PickPositionOnMapDialog();
                dialog.IsNotMap = true;
                dialog.SelectedMap = MainForm.SelectedMap;
                dialog.IsScreenSelect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    nudX.Value = (decimal)dialog.Position.X;
                    nudY.Value = (decimal)dialog.Position.Y;
                }
            }
        }
    }
}
