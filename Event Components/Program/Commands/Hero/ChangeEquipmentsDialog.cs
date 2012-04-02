using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.PartyDialogs
{
    public partial class ChangeEquipmentsDialog : Form
    {
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
        public ChangeEquipmentsDialog()
        {
            InitializeComponent();
            cbList.RefreshList(false);
            cbOpType.SelectedIndex = 0;
            cbValue.SelectedIndex = 0;
            cbEquipment.RefreshList(false);

            variablesList.RefreshList(false);

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
            action.ProgramCategory = ProgramCategory.Hero;
            action.Code = 9;
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

            cbList.Select((int)action.Value[0]);
            cbEquipment.Select((int)action.Value[1]);
            cbOpType.SelectedIndex = (int)action.Value[2];
            cbValue.SelectedIndex = (int)action.Value[3];

            chkEquipped.Checked = (bool)action.Value[5];

            switch ((int)action.Value[3])
            {
                case 0:
                    action.Value[4] = (int)constantBox.Value;
                    break;
                case 1:
                    variablesList.Select((int)action.Value[4]);
                    break;
            }

        }
        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = false;
            panelVariable.Visible = false;
            switch (cbValue.SelectedIndex)
            {
                case 0:
                    panelConst.Visible = true;
                    panelConst.Enabled = true;
                    break;
                case 1:
                    panelVariable.Visible = true;
                    panelVariable.Enabled = true;
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            if (cbList.Data().ID > -1)
            {
                action.Value[0] = cbList.Data().ID;
                action.Value[1] = cbEquipment.Data().ID;
                action.Value[2] = cbOpType.SelectedIndex;
                action.Value[3] = cbValue.SelectedIndex;
                action.Value[5] = chkEquipped.Checked;
                switch ((int)action.Value[3])
                {
                    case 0:
                        action.Value[4] = (int)constantBox.Value;
                        break;
                    case 1:
                        action.Value[4] = variablesList.Data().ID;
                        break;
                }
            }
            this.DialogResult = DialogResult.OK;
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

        private void cbOpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkEquipped.Enabled = (cbOpType.SelectedIndex == 1 ? true : false);
        }

    }
}
