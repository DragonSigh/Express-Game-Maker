using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls
{
    public partial class EventMouseInputDialog : Form
    {
        public EventMouseInputDialog()
        {
            InitializeComponent();
            btnList.SelectedIndex = 0;
            btnStateList.SelectedIndex = 0;
            Setup();
        }
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
        }
        /// <summary>
        /// Setup Action
        /// </summary>
        /// <param name="a"></param>
        private void SetupAction(EventProgramData a)
        {
            if (a == null)
            {
                Setup();
            }
            else
            {
                action.ID = a.ID;
                action.Name = a.Name;
                action.ProgramCategory = a.ProgramCategory;
                action.Code = a.Code;
                action.Value = (object[])a.Value.Clone();
                action.Enabled = a.Enabled;
                // Setup Data
                btnList.SelectedIndex = (int)action.Value[0];
                btnStateList.SelectedIndex = (int)action.Value[1];
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Buttons
            action.Value[0] = btnList.SelectedIndex;
            action.Value[1] = btnStateList.SelectedIndex;

            action.Name = "IF Mouse " + btnList.Text + " is " + btnStateList.Text;

            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
