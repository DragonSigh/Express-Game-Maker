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
    public partial class MenuEnableStateDialog : Form
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

        public MenuEnableStateDialog()
        {
            InitializeComponent();

            menuPartsComboBox1.RefreshList(false);
            stateList.SelectedIndex = 0;
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Menu;
            action.Code = 1;
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
            stateList.SelectedIndex = (int)action.Value[1];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (menuPartsComboBox1.SelectedIndex > -1)
            {
                action.Value[0] = menuPartsComboBox1.Data().ID;
                action.Value[1] = stateList.SelectedIndex;

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
