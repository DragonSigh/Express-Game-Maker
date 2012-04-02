using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class MoveToDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                if (action == null) Setup();


                cbLocalVarX.RefreshList(selectedEvent, false);
                cbLocalVarY.RefreshList(selectedEvent, false);
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

        public MoveToDialog()
        {
            InitializeComponent();

            cbType.SelectedIndex = 0;
            cbVariableX.RefreshList(false);
            cbVariableY.RefreshList(false);
        }

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
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

            cbType.SelectedIndex = (int)action.Value[0];

            switch ((int)action.Value[0])
            {
                case 0:
                    nudXPos.Value = (decimal)(int)action.Value[1];
                    nudYPos.Value = (decimal)(int)action.Value[2];
                    break;
                case 1:
                    cbVariableX.Select((int)action.Value[1]);
                    cbVariableY.Select((int)action.Value[2]);
                    break;
                case 2:
                    cbLocalVarX.Select((int)action.Value[1]);
                    cbLocalVarY.Select((int)action.Value[2]);
                    break;
            }


            turnBox.Checked = (bool)action.Value[3];


            // Direction
            List<int> dir = new List<int>((List<int>)action.Value[4]);
            upBtn.Checked = dir.Contains(0);
            downBtn.Checked = dir.Contains(1);
            leftBtn.Checked = dir.Contains(2);
            rightBtn.Checked = dir.Contains(3);
            upLeftBtn.Checked = dir.Contains(4);
            upRightBtn.Checked = dir.Contains(5);
            downLeftBtn.Checked = dir.Contains(6);
            downRightBtn.Checked = dir.Contains(7);

            chWait.Checked = (bool)action.Value[5];

            nudPrecision.Value = (int)action.Value[6];
            chImpulse.Checked = (bool)action.Value[7];
        }


        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbType.SelectedIndex;

            switch ((int)action.Value[0])
            {
                case 0:
                    action.Value[1] = (int)nudXPos.Value;
                    action.Value[2] = (int)nudYPos.Value;
                    break;
                case 1:
                    action.Value[1] = cbVariableX.Data().ID;
                    action.Value[2] = cbVariableY.Data().ID;                 
                    break;
                case 2:
                    action.Value[1] = cbLocalVarX.Data().ID;
                    action.Value[2] = cbLocalVarY.Data().ID;   
                    break;
            }

            action.Value[3] = turnBox.Checked;
            action.Value[7] = chImpulse.Checked;
            List<int> dir = new List<int>();
            if (upBtn.Checked)
                dir.Add(0);
            if (downBtn.Checked)
                dir.Add(1);
            if (leftBtn.Checked)
                dir.Add(2);
            if (rightBtn.Checked)
                dir.Add(3);
            if (upLeftBtn.Checked)
                dir.Add(4);
            if (upRightBtn.Checked)
                dir.Add(5);
            if (downLeftBtn.Checked)
                dir.Add(6);
            if (downRightBtn.Checked)
                dir.Add(7);
            action.Value[4] = dir;
            action.Value[5] = chWait.Checked;
            action.Value[6] = (int)nudPrecision.Value;
            
            // Close
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

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            // Show map
            if (MainForm.SelectedMap != null)
            {
                // Show map
                PickPositionOnMapDialog dialog = new PickPositionOnMapDialog();
                dialog.SelectedMap = MainForm.SelectedMap;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    nudXPos.Value = (decimal)dialog.Position.X;
                    nudYPos.Value = (decimal)dialog.Position.Y;
                }
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = (cbType.SelectedIndex == 0);
            panelVariable.Visible = (cbType.SelectedIndex == 1);
            panelLocalVariable.Visible = (cbType.SelectedIndex == 2);
        }
    }
}
