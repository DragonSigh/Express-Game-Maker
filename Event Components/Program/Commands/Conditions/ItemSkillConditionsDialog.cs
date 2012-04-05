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

namespace EGMGame
{
    public partial class ItemSkillConditionDialog : Form
    {
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
        /// Constructor
        /// </summary>
        public ItemSkillConditionDialog()
        {
            InitializeComponent();
            cbConditions.SelectedIndex = 0;
            cbCompare.SelectedIndex = 0;
            cbItemScope.SelectedIndex = 0;
            cbItemCondition.SelectedIndex = 0;
            cbItemVar.RefreshList(false);
            cbSkillScope.SelectedIndex = 0;
            cbSkillCondition.SelectedIndex = 0;
            cbSkillVar.RefreshList(false);
            cbItemPartyIndex.RefreshList(false);
            cbSkillPartyIndex.RefreshList(false);
            cbEquipCondition.SelectedIndex = 0;
            cbEquipPartyIndex.RefreshList(false);
            cbEquipVar.RefreshList(false);
            cbEquipmentGoldvar.RefreshList(false);
            cbItemGoldVar.RefreshList(false);
            cbItemCanBeUsedBy.RefreshList(false);
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 11;
            //action.TypeCode = 1;
            action.Branch = true;
        }
        /// <summary>
        /// Setup Action
        /// </summary>
        /// <param name="a"></param>
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Else = a.Else; elseBranc.Checked = action.Else;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            cbConditions.SelectedIndex = (int)action.Value[0];
            cbCompare.SelectedIndex = (int)action.Value[1];
            switch ((int)action.Value[0])
            {
                case 0: // Item
                    cbItemVar.Select((int)action.Value[2]);
                    cbItemCondition.SelectedIndex = (int)action.Value[3];

                    switch ((int)action.Value[3])
                    {
                        case 0:
                            cbItemScope.SelectedIndex = (int)action.Value[4];
                            break;
                        case 1:
                            cbItemPartyIndex.Select((int)action.Value[4]);
                            break;
                        case 3:
                            cbItemGoldVar.Select((int)action.Value[4]);
                            break;
                        case 5:
                            cbItemCanBeUsedBy.Select((int)action.Value[4]);
                            break;
                    }
                    break;
                case 1: // Skill
                    cbSkillVar.Select((int)action.Value[2]);
                    cbSkillCondition.SelectedIndex = (int)action.Value[3];

                    switch ((int)action.Value[3])
                    {
                        case 0:
                            cbSkillScope.SelectedIndex = (int)action.Value[4];
                            break;
                        case 1:
                            cbSkillPartyIndex.Select((int)action.Value[4]);
                            break;
                        case 3:
                            cbSkillPartyIndex.Select((int)action.Value[4]);
                            break;
                    }
                    break;
                case 2: // Equipment
                    cbEquipVar.Select((int)action.Value[2]);
                    cbEquipCondition.SelectedIndex = (int)action.Value[3];

                    switch ((int)action.Value[3])
                    {
                        case 0:
                            cbEquipPartyIndex.Select((int)action.Value[4]);
                            break;
                        case 2:
                            cbEquipmentGoldvar.Select((int)action.Value[4]);
                            break;
                    }
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbConditions.SelectedIndex;
            action.Value[1] = cbCompare.SelectedIndex;
            switch ((int)action.Value[0])
            {
                case 0: // Item
                    action.Value[2] = cbItemVar.Data().ID;
                    action.Value[3] = cbItemCondition.SelectedIndex;

                    switch ((int)action.Value[3])
                    {
                        case 0:
                            action.Value[4] = cbItemScope.SelectedIndex;
                            break;
                        case 1:
                            action.Value[4] = cbItemPartyIndex.Data().ID;
                            break;
                        case 3:
                            action.Value[4] = cbItemGoldVar.Data().ID;
                            break;
                        case 5:
                            action.Value[4] = cbItemCanBeUsedBy.Data().ID;
                            break;
                    }
                    break;
                case 1: // Skill
                    action.Value[2] = cbSkillVar.Data().ID;
                    action.Value[3] = cbSkillCondition.SelectedIndex;

                    switch ((int)action.Value[3])
                    {
                        case 0:
                            action.Value[4] = cbSkillScope.SelectedIndex;
                            break;
                        case 1:
                            action.Value[4] = cbSkillPartyIndex.Data().ID;
                            break;
                        case 3:
                            action.Value[4] = cbSkillPartyIndex.Data().ID;
                            break;
                    }
                    break;
                case 2: // Equipment
                    action.Value[2] = cbEquipVar.Data().ID;
                    action.Value[3] = cbEquipCondition.SelectedIndex;

                    switch ((int)action.Value[3])
                    {
                        case 0:
                            action.Value[4] = cbEquipPartyIndex.Data().ID;
                            break;
                        case 2:
                            action.Value[4] = cbEquipmentGoldvar.Data().ID;
                            break;
                    }
                    break;
            }
            action.GetName(selectedEvent, selectedPage);
            // Close
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }

        private void cbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelItem.Visible = (cbConditions.SelectedIndex == 0);
            panelSkill.Visible = (cbConditions.SelectedIndex == 1);
            panelEquip.Visible = (cbConditions.SelectedIndex == 2);
        }


        private void cbItemCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelItemScope.Visible = (cbItemCondition.SelectedIndex == 0);
            panelItemPartyPanel.Visible = (cbItemCondition.SelectedIndex == 1);
            panelItemBuy.Visible = (cbItemCondition.SelectedIndex == 3);
            panelCanItembeused.Visible = (cbItemCondition.SelectedIndex == 5);
        }

        private void cbSkillCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelSkillScope.Visible = (cbSkillCondition.SelectedIndex == 0);
            panelSkillPartyPanel.Visible = (cbSkillCondition.SelectedIndex == 1 || cbSkillCondition.SelectedIndex == 3);
        }

        private void cbEquipCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelEquipParty.Visible = (cbEquipCondition.SelectedIndex == 0);
            panelEquipmentBuy.Visible = (cbEquipCondition.SelectedIndex == 2);
        }
    }
}
