using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Docking.Editors.Database
{
    public partial class EnemyProgramDialog : Form
    {
        internal EnemyProgram Program = new EnemyProgram();

        public EnemyProgramDialog()
        {
            InitializeComponent();

            cbActionType.SelectedIndex = 0;
            cbActions.SelectedIndex = 0;
            cbCondition.SelectedIndex = 0;
            cbSwitchState.SelectedIndex = 0;
            cbPartyLevel.SelectedIndex = 0;
            cbItems.RefreshList(false);
            cbMagic.RefreshList(false, SkillType.Magic);
            cbSkills.RefreshList(false, SkillType.Skill);
            cbStates.RefreshList(false);
            cbSwitches.RefreshList(false);
        }

        internal void Setup(EnemyProgram data)
        {
            Program.Action = data.Action;
            Program.ActionType = data.ActionType;
            Program.Condition = data.Condition;
            Program.ConditionValue = (int[])data.ConditionValue.Clone();
            Program.Priority = data.Priority;


            nudPriority.Value = (decimal)data.Priority;
            cbActionType.SelectedIndex = (int)data.ActionType;
            cbCondition.SelectedIndex = (int)data.Condition;

            switch (data.ActionType)
            {
                case EnemyActionType.Basic:
                    cbActions.SelectedIndex = (int)data.Action;
                    break;
                case EnemyActionType.Item:
                    cbItems.Select(data.Item);
                    break;
                case EnemyActionType.Magic:
                    cbMagic.Select(data.Item);
                    break;
                case EnemyActionType.Skill:
                    cbSkills.Select(data.Item);
                    break;
            }

            switch (data.Condition)
            {
                case EnemyActionCondition.Always:
                    break;
                case EnemyActionCondition.EveryTurnTime:
                    nudStartTurn.Value = data.ConditionValue[0];
                    nudEveryTurn.Value = data.ConditionValue[1];
                    break;
                case EnemyActionCondition.HP:
                    nudHpMin.Value = data.ConditionValue[0];
                    nudHpMax.Value = data.ConditionValue[1];
                    break;
                case EnemyActionCondition.SP:
                    nudSpMin.Value = data.ConditionValue[0];
                    nudSpMax.Value = data.ConditionValue[1];
                    break;
                case EnemyActionCondition.MP:
                    nudMpMin.Value = data.ConditionValue[0];
                    nudMpMax.Value = data.ConditionValue[1];
                    break;
                case EnemyActionCondition.PartyLevel:
                    nudPartyLevel.Value = data.ConditionValue[0];
                    cbPartyLevel.SelectedIndex = data.ConditionValue[1];
                    break;
                case EnemyActionCondition.State:
                    cbStates.Select(data.ConditionValue[0]);
                    break;
                case EnemyActionCondition.Switch:
                    cbSwitches.Select(data.ConditionValue[0]);
                    cbSwitchState.SelectedIndex = data.ConditionValue[1];
                    break;
            }
        }

        private void cbActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelBasic.Visible = false;
            panelSkill.Visible = false;
            panelMagic.Visible = false;
            panelItem.Visible = false;
            switch (cbActionType.SelectedIndex)
            {
                case 0: // Base
                    panelBasic.Visible = true;
                    break;
                case 1: // Skill
                    panelSkill.Visible = true;
                    break;
                case 2: // Magic
                    panelMagic.Visible = true;
                    break;
                case 3: // Item
                    panelItem.Visible = true;
                    break;

            }
        }

        private void cbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelTurn.Visible = false;
            panelHP.Visible = false;
            panelSp.Visible = false;
            panelMp.Visible = false;
            panelState.Visible = false;
            panelParty.Visible = false;
            panelSwitch.Visible = false;
            switch (cbCondition.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    panelTurn.Visible = true;
                    break;
                case 2:
                    panelHP.Visible = true;
                    break;
                case 3:
                    panelSp.Visible = true;
                    break;
                case 4:
                    panelMp.Visible = true;
                    break;
                case 5:
                    panelState.Visible = true;
                    break;
                case 6:
                    panelParty.Visible = true;
                    break;
                case 7:
                    panelSwitch.Visible = true;
                    break;
            }
        }

        private void barPriority_ValueChanged(object sender, decimal value)
        {
            if (value != nudPriority.Value)
            {
                nudPriority.Value = value;
            }
        }

        private void nudPriority_ValueChanged(object sender, EventArgs e)
        {
            if (nudPriority.Value != barPriority.Value)
            {
                barPriority.Value = (int)nudPriority.Value;
            }

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Program.Priority = (int)nudPriority.Value;
            Program.ActionType = (EnemyActionType)cbActionType.SelectedIndex;
            Program.Condition = (EnemyActionCondition)cbCondition.SelectedIndex;

            switch (Program.ActionType)
            {
                case EnemyActionType.Basic:
                    Program.Action = (EnemyAction)cbActions.SelectedIndex;
                    break;
                case EnemyActionType.Item:
                    Program.Item = cbItems.Data().ID;
                    break;
                case EnemyActionType.Magic:
                    Program.Item = cbMagic.Data().ID;
                    break;
                case EnemyActionType.Skill:
                    Program.Item = cbSkills.Data().ID;
                    break;
            }

            switch (Program.Condition)
            {
                case EnemyActionCondition.Always:
                    break;
                case EnemyActionCondition.EveryTurnTime:
                    Program.ConditionValue[0] = (int)nudStartTurn.Value;
                    Program.ConditionValue[1] = (int)nudEveryTurn.Value;
                    break;
                case EnemyActionCondition.HP:
                    Program.ConditionValue[1] = (int)nudHpMin.Value;
                    Program.ConditionValue[1] = (int)nudHpMax.Value;
                    break;
                case EnemyActionCondition.SP:
                    Program.ConditionValue[0] = (int)nudSpMin.Value;
                    Program.ConditionValue[1] = (int)nudSpMax.Value;
                    break;
                case EnemyActionCondition.MP:
                    Program.ConditionValue[0] = (int)nudMpMin.Value;
                    Program.ConditionValue[1] = (int)nudMpMax.Value;
                    break;
                case EnemyActionCondition.PartyLevel:
                    Program.ConditionValue[0] = (int)nudPartyLevel.Value;
                    Program.ConditionValue[1] = cbPartyLevel.SelectedIndex;
                    break;
                case EnemyActionCondition.State:
                    Program.ConditionValue[0] = cbStates.Data().ID;
                    break;
                case EnemyActionCondition.Switch:
                    Program.ConditionValue[0] = cbSwitches.Data().ID;
                    Program.ConditionValue[1] = cbSwitchState.SelectedIndex;
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
