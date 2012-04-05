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

namespace EGMGame.Controls
{
    public partial class MenuConditionsDialog : Form
    {
        public MenuConditionsDialog()
        {
            InitializeComponent();

            menuPartsComboBox1.RefreshList(false);
            cbCompare.SelectedIndex = 0;
            cbCondition.SelectedIndex = 0;
        }

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;

        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; Setup(); }
        }
        List<EventProgramData> programs;
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Menu;
            action.Code = 4;
            action.Branch = true;
        }
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Branch = a.Branch;
            action.Else = a.Else; elseBranc.Checked = action.Else;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            menuPartsComboBox1.Select((int)action.Value[0]);
            cbCompare.SelectedIndex = (int)action.Value[1];
            cbCondition.SelectedIndex = (int)action.Value[2];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (menuPartsComboBox1.SelectedIndex > -1)
            {
                action.Else = elseBranc.Checked;
                action.Value[0] = menuPartsComboBox1.Data().ID;
                action.Value[1] = cbCompare.SelectedIndex;
                action.Value[2] = cbCondition.SelectedIndex;

                action.GetName(null, null);

                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
