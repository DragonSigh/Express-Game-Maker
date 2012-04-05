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
    public partial class MoveMenuDialog : Form
    {
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

        public MoveMenuDialog()
        {
            InitializeComponent();

            menuPartsComboBox1.RefreshList(false);
            cbXVar.RefreshList(false);
            cbYVar.RefreshList(false);
            operationTypeList.SelectedIndex = 0;
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Menu;
            action.Code = 5;
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
            // Menu ID
            menuPartsComboBox1.Select((int)action.Value[0]);
            operationTypeList.SelectedIndex = (int)action.Value[1];

            switch (operationTypeList.SelectedIndex)
            {
                case 0:
                    nudScreenX.Value = (decimal)(int)action.Value[2];
                    nudScreenY.Value = (decimal)(int)action.Value[3];
                    break;
                case 1:
                    cbXVar.Select((int)action.Value[2]);
                    cbYVar.Select((int)action.Value[3]);
                    break;
            }
            nudFrames.Value = (decimal)(int)action.Value[4];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (menuPartsComboBox1.SelectedIndex > -1)
            {
                action.Value[0] = menuPartsComboBox1.Data().ID;
                action.Value[1] = operationTypeList.SelectedIndex;
                switch (operationTypeList.SelectedIndex)
                {
                    case 0:
                        action.Value[2] = (int)nudScreenX.Value;
                        action.Value[3] = (int)nudScreenY.Value;
                        break;
                    case 1:
                        action.Value[2] = cbXVar.Data().ID;
                        action.Value[3] = cbYVar.Data().ID;
                        break;
                }

                action.Value[4] = (int)nudFrames.Value;

                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void operationTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (operationTypeList.SelectedIndex)
            {
                case 0: // Coordinates
                    variablesPanel.Visible = false;
                    coordinatePanel.Visible = true;
                    break;
                case 1:// Varaibles
                    variablesPanel.Visible = true;
                    coordinatePanel.Visible = false;
                    break;
            }
        }

        private void cbXVar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
