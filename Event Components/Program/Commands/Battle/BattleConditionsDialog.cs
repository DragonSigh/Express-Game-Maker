using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame
{
    public partial class BattleCondtionsDialog : Form
    {
        bool btnBattlerPropIndex = true;

        public BattleCondtionsDialog()
        {
            InitializeComponent();

            cbConditions.SelectedIndex = 0;
            cbOperator.SelectedIndex = 0;
            cbBattlerProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            cbValueProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            cbBattlerOp.SelectedIndex = 0;
            cbOther.SelectedIndex = 0;
            cbValue.SelectedIndex = 0;
        }
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; if (action == null) Setup(); }
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
            action.ProgramCategory = ProgramCategory.Battle;
            action.Code = 8;
            action.Branch = true;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;


            cbConditions.SelectedIndex = (int)action.Value[0];
            cbOperator.SelectedIndex = (int)action.Value[1];

            btnBattlerPropIndex = (bool)action.Value[2];
            Setup(btnBattlerPropIndex);

            switch ((int)action.Value[0])
            {
                case 0:// Battler
                    cbBattlerProp.Select((int)action.Value[3]);
                    cbBattlerOp.SelectedIndex = (int)action.Value[4];
                    cbValue.SelectedIndex = (int)action.Value[5];
                    if ((int)action.Value[5] == 0)
                    {
                        cbBattlerNud.Value = (decimal)(int)action.Value[6];
                    }
                    else
                    {
                        cbValueProp.Select((int)action.Value[6]);
                    }
                    break;
                case 1: // Target
                    cbBattlerProp.Select((int)action.Value[3]);
                    cbBattlerOp.SelectedIndex = (int)action.Value[4];
                    cbValue.SelectedIndex = (int)action.Value[5];
                    if ((int)action.Value[5] == 0)
                    {
                        cbBattlerNud.Value = (decimal)(int)action.Value[6];
                    }
                    else
                    {
                        cbValueProp.Select((int)action.Value[6]);
                    }
                    break;
                case 2: // Other
                    cbOther.SelectedIndex = (int)action.Value[3];
                    break;
            }

        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbConditions.SelectedIndex;
            action.Value[1] = cbOperator.SelectedIndex;
            action.Value[2] = btnBattlerPropIndex;
            switch ((int)action.Value[0])
            {
                case 0:// Battler
                    action.Value[3] = cbBattlerProp.Data().ID;
                    action.Value[4] = cbBattlerOp.SelectedIndex;
                    action.Value[5] = cbValue.SelectedIndex;
                    if ((int)action.Value[5] == 0)
                    {
                        action.Value[6] = (int)cbBattlerNud.Value;
                    }
                    else
                    {
                        action.Value[6] = cbValueProp.Data().ID;
                    }
                    break;
                case 1: // Target
                    action.Value[3] = cbBattlerProp.Data().ID;
                    action.Value[4] = cbBattlerOp.SelectedIndex;
                    action.Value[5] = cbValue.SelectedIndex;
                    if ((int)action.Value[5] == 0)
                    {
                        action.Value[6] = (int)cbBattlerNud.Value;
                    }
                    else
                    {
                        action.Value[6] = cbValueProp.Data().ID;
                    }
                    break;
                case 2: // Other
                    action.Value[3] = cbOther.SelectedIndex;
                    break;
            }
            action.GetName(SelectedEvent, SelectedPage);
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

        private void cbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelBattlerProp.Visible = (cbConditions.SelectedIndex < 2);
            panelOther.Visible = (cbConditions.SelectedIndex == 2);
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }

        private void btnChangeBattlerProp_Click(object sender, EventArgs e)
        {
            if (btnBattlerPropIndex)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                btnBattlerPropIndex = false;

                cbBattlerProp.RefreshList(GameData.Databases[1], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                btnBattlerPropIndex = true;

                cbBattlerProp.RefreshList(GameData.Databases[0], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            }
        }


        private void Setup(bool btnBattlerPropIndex)
        {
            if (!btnBattlerPropIndex)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                btnBattlerPropIndex = false;

                cbBattlerProp.RefreshList(GameData.Databases[1], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                btnBattlerPropIndex = true;

                cbBattlerProp.RefreshList(GameData.Databases[0], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            }
        }

        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConstant.Visible = (cbValue.SelectedIndex == 0);
            panelProperty.Visible = (cbValue.SelectedIndex == 1);
        }

        private void cbOther_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
