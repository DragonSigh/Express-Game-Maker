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
    public partial class PartyConditionsDialog : Form
    {

        public PartyConditionsDialog()
        {
            InitializeComponent();

            cbIndexType.SelectedIndex = 0;
            cbConditions.SelectedIndex = 0;
            cbOperator.SelectedIndex = 0;
            cbVarIndex.RefreshList(false);
            cbBattlerProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            cbValueProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            cbBattlerOp.SelectedIndex = 0;
            cbValue.SelectedIndex = 0;
            cbItems.RefreshList(false);
            cbHeroes.RefreshList(false);
            cbEquipments.RefreshList(false);
            cbDeadPartyIndex.RefreshList(false);
            cbDeadMemberType.SelectedIndex = 0;
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
            action.ProgramCategory = ProgramCategory.Party;
            action.Code = 5;
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

            switch ((int)action.Value[0])
            {
                case 0:// Battler
                    cbIndexType.SelectedIndex = (int)action.Value[2];
                    switch ((int)action.Value[2])
                    {
                        case 0:
                            cbConstIndex.Value = (decimal)(int)action.Value[3];
                            break;
                        case 1:
                            cbVarIndex.Select((int)action.Value[3]);
                            break;
                    }
                    cbBattlerProp.Select((int)action.Value[4]);
                    cbBattlerOp.SelectedIndex = (int)action.Value[5];
                    cbValue.SelectedIndex = (int)action.Value[6];
                    if ((int)action.Value[6] == 0)
                    {
                        cbBattlerNud.Value = (decimal)(int)action.Value[7];
                    }
                    else
                    {
                        cbValueProp.Select((int)action.Value[7]);
                    }
                    break;
                case 1: // Items
                    cbItems.Select((int)action.Value[2]);
                    break;
                case 2: // Equipment
                    cbEquipments.Select((int)action.Value[2]);
                    break;
                case 3: // Includes
                    cbHeroes.Select((int)action.Value[2]);
                    break;
                case 5: // Dead Party MEmber
                    cbDeadMemberType.SelectedIndex = (int)action.Value[2];
                    switch ((int)action.Value[2])
                    {
                        case 0:
                            nudDeadPartyIndex.Value = (decimal)(int)action.Value[3];
                            break;
                        case 1:
                            cbDeadPartyIndex.Select((int)action.Value[3]);
                            break;
                    }
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbConditions.SelectedIndex;
            action.Value[1] = cbOperator.SelectedIndex;
            switch ((int)action.Value[0])
            {
                case 0:// Battler
                    action.Value[2] = cbIndexType.SelectedIndex;
                    switch ((int)action.Value[2])
                    {
                        case 0:
                            action.Value[3] = (int)cbConstIndex.Value;
                            break;
                        case 1:
                            action.Value[3] = cbVarIndex.Data().ID;
                            break;
                    }
                    action.Value[4] = cbBattlerProp.Data().ID;
                    action.Value[5] = cbBattlerOp.SelectedIndex;
                    action.Value[6] = cbValue.SelectedIndex;
                    if ((int)action.Value[6] == 0)
                    {
                        action.Value[7] = (int)cbBattlerNud.Value;
                    }
                    else
                    {
                        action.Value[7] = cbValueProp.Data().ID;
                    }
                    break;
                case 1: // Items
                    action.Value[2] = cbItems.Data().ID;
                    break;
                case 2: // Equipment
                    action.Value[2] = cbEquipments.Data().ID;
                    break;
                case 3: // Includes
                    action.Value[2] = cbHeroes.Data().ID;
                    break;
                case 5:
                    action.Value[2] = cbDeadMemberType.SelectedIndex;
                    if ((int)action.Value[2] == 0)
                        action.Value[3] = (int)nudDeadPartyIndex.Value;
                    else
                        action.Value[3] = cbDeadPartyIndex.Data().ID;
                    break;
            }
            action.Else = elseBranc.Checked;
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

        private void cbIndexType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConstIndex.Visible = (cbIndexType.SelectedIndex == 0);
            panelVarIndex.Visible = (cbIndexType.SelectedIndex == 1);
        }

        private void cbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelBattlerProp.Visible = (cbConditions.SelectedIndex == 0);
            panelItem.Visible = (cbConditions.SelectedIndex == 1);
            panelEquip.Visible = (cbConditions.SelectedIndex == 2);
            panelIncludes.Visible = (cbConditions.SelectedIndex == 3);
            panelDeadParty.Visible = (cbConditions.SelectedIndex == 5);
        }

        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConstant.Visible = (cbValue.SelectedIndex == 0);
            panelProperty.Visible = (cbValue.SelectedIndex == 1);
        }

        private void cbDeadMemberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDeadConstant.Visible = (cbDeadMemberType.SelectedIndex == 0);
            panelDeadVariable.Visible = (cbDeadMemberType.SelectedIndex == 1);
        }
    }
}
