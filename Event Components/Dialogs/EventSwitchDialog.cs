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

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class EventSwitchesDialog : Form
    {

        public IEvent SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; }
        }
        IEvent selEvent;

        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set
            {
                selectedPage = value;
                Setup();
            }
        }
        EventPageData selectedPage;

        public int SelectedSwitch
        {
            get
            {
                return localList.SelectedIndex;
            }
        }

        public EventSwitchesDialog()
        {
            InitializeComponent();
        }
        internal void Setup()
        {
            SetupProperty();
        }
        /// <summary>
        /// Setup Property
        /// </summary>
        private void SetupProperty()
        {
            switchesBox.Enabled = true;
            onBtn.Checked = selectedPage.EventSwitchConditions[1] == 0;
            offBtn.Checked = !onBtn.Checked;
            localList.SelectedIndex = selectedPage.EventSwitchConditions[0];
            EventSwitchConditions[0] = selectedPage.EventSwitchConditions[0];
            EventSwitchConditions[1] = selectedPage.EventSwitchConditions[1];
        }

        private void onBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (onBtn.Checked)
                EventSwitchConditions[1] = 0;
            else
                EventSwitchConditions[1] = 1;
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void localList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventSwitchConditions[0] = localList.SelectedIndex;
        }

        public int[] EventSwitchConditions = new int[] { 0, 0 };
    }
}
