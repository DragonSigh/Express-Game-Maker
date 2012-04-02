using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using GenericUndoRedo;

namespace EGMGame.Controls.EventControls.Enemy
{
    public partial class EnemyAIDialog : Form
    {
        internal EventData Event;
        internal EventPageData Page;
        public UndoRedoHistory<IHistory> SelectedHistory;

        public EnemyAIDialog()
        {
            InitializeComponent();

            cbAttackCond.SelectedIndex = 0;
            cbLocalOper.SelectedIndex = 0;
            cbLocalState.SelectedIndex = 0;


            cbSwitches.RefreshList(false);
            cbSwitchState.SelectedIndex = 0;
            cbVariable.RefreshList(false);
            cbVarOperation.SelectedIndex = 0;

            cbEventSwitches.SelectedIndex = 0;
            cbEventSwitchValue.SelectedIndex = 0;
        }

        internal void Setup()
        {
            cbLocalSwitch.RefreshList(Event, false);
            cbLocalVar.RefreshList(Event, false);

            cbAttackCond.SelectedIndex = (int)Page.AttackCondition;
            nudSee.Value = Page.SeeRange;
            // nudSpeed.Value = Page.BattleSpeed;
            nudHear.Value = Page.HearRange;
            nudRespawn.Value = Page.Respawn;
            rbLock.Checked = Page.LockOnTarget;
            nudAttackSpeed.Value = Page.AttackSpeed;

            chkRushTarget.Checked = Page.RushTarget;
            chkDontErase.Checked = Page.DontErase;

            // Hostiles
            ItemTag item;
            listHostiles.Items.Clear();
            item = new ItemTag(-1, "Player");
            listHostiles.Items.Add(item, Page.Hostiles.Contains(-1));

            foreach (EnemyData enemy in GameData.Enemies.Values)
            {
                item = new ItemTag(enemy.ID, enemy.Name);
                listHostiles.Items.Add(item, Page.Hostiles.Contains(enemy.ID));
            }

            // Directions          
            //List<int> dir = Page.BattleDirections;
            //upBtn.Checked = dir.Contains(0);
            //downBtn.Checked = dir.Contains(1);
            //leftBtn.Checked = dir.Contains(2);
            //rightBtn.Checked = dir.Contains(3);
            //upLeftBtn.Checked = dir.Contains(4);
            //upRightBtn.Checked = dir.Contains(5);
            //downLeftBtn.Checked = dir.Contains(6);
            //downRightBtn.Checked = dir.Contains(7);


            cbDeathTrigger.SelectedIndex = Page.DeathTrigger[0];
            // Death Trigger
            switch (Page.DeathTrigger[0])
            {
                case 3:
                    cbSwitches.Select(Page.DeathTrigger[1]);
                    cbSwitchState.SelectedIndex = Page.DeathTrigger[2];
                    break;
                case 4:
                    cbLocalSwitch.Select(Page.DeathTrigger[1]);
                    cbLocalState.SelectedIndex = Page.DeathTrigger[2];
                    break;
                case 5:
                    cbVariable.Select(Page.DeathTrigger[1]);
                    cbVarOperation.SelectedIndex = Page.DeathTrigger[2];
                    nudVarValue.Value = Page.DeathTrigger[3];
                    break;
                case 6:
                    cbLocalVar.Select(Page.DeathTrigger[1]);
                    cbLocalOper.SelectedIndex = Page.DeathTrigger[2];
                    nudLocalVal.Value = Page.DeathTrigger[3];
                    break;
                case 7:
                    cbEventSwitches.SelectedIndex = Page.DeathTrigger[1];
                    cbEventSwitchValue.SelectedIndex = Page.DeathTrigger[2];
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelLocalSwitch.Visible = false;
            panelLocalVariable.Visible = false;
            panelSwitch.Visible = false;
            panelVariable.Visible = false;
            chkDontErase.Visible = false;
            panelEventSwitch.Visible = false;
            switch (cbDeathTrigger.SelectedIndex)
            {
                case 3:
                    panelSwitch.Visible = true;
                    chkDontErase.Visible = true;
                    break;
                case 4:
                    panelLocalSwitch.Visible = true;
                    chkDontErase.Visible = true;
                    break;
                case 5:
                    panelVariable.Visible = true;
                    chkDontErase.Visible = true;
                    break;
                case 6:
                    panelLocalVariable.Visible = true;
                    chkDontErase.Visible = true;
                    break;
                case 7: // Event Switch
                    panelEventSwitch.Visible = true;
                    chkDontErase.Visible = true;
                    break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            SelectedHistory.Do(new IGameDataChangePropertyHist(Page));
               
            Page.AttackCondition = (AttackCondition)cbAttackCond.SelectedIndex;
            Page.SeeRange = (int)nudSee.Value;
            //Page.BattleSpeed = (int)nudSpeed.Value;
            Page.HearRange = (int)nudHear.Value;
            Page.Respawn = (int)nudRespawn.Value;
            Page.LockOnTarget = rbLock.Checked;
            Page.AttackSpeed = (int)nudAttackSpeed.Value;

            Page.RushTarget = chkRushTarget.Checked;

            Page.DontErase = chkDontErase.Checked;

            // Hostiles
            Page.Hostiles.Clear();
            foreach (ItemTag tag in listHostiles.CheckedItems)
            {
                Page.Hostiles.Add(tag.ID);
            }

            // Directions
            List<int> dir = new List<int>();
            //if (upBtn.Checked)
            //    dir.Add(0);
            //if (downBtn.Checked)
            //    dir.Add(1);
            //if (leftBtn.Checked)
            //    dir.Add(2);
            //if (rightBtn.Checked)
            //    dir.Add(3);
            //if (upLeftBtn.Checked)
            //    dir.Add(4);
            //if (upRightBtn.Checked)
            //    dir.Add(5);
            //if (downLeftBtn.Checked)
            //    dir.Add(6);
            //if (downRightBtn.Checked)
            //    dir.Add(7);
            Page.BattleDirections = dir;

            Page.DeathTrigger[0] = cbDeathTrigger.SelectedIndex;
            // Death Trigger
            switch (Page.DeathTrigger[0])
            {
                case 3:
                    Page.DeathTrigger[1] = cbSwitches.Data().ID;
                    Page.DeathTrigger[2] = cbSwitchState.SelectedIndex;
                    break;
                case 4:
                    Page.DeathTrigger[1] = cbLocalSwitch.Data().ID;
                    Page.DeathTrigger[2] = cbLocalState.SelectedIndex;
                    break;
                case 5:
                    Page.DeathTrigger[1] = cbVariable.Data().ID;
                    Page.DeathTrigger[2] = cbVarOperation.SelectedIndex;
                    Page.DeathTrigger[3] = (int)nudVarValue.Value;
                    break;
                case 6:
                    Page.DeathTrigger[1] = cbLocalVar.Data().ID;
                    Page.DeathTrigger[2] = cbLocalOper.SelectedIndex;
                    Page.DeathTrigger[3] = (int)nudLocalVal.Value;
                    break;
                case 7:
                    Page.DeathTrigger[1] = cbEventSwitches.SelectedIndex;
                    Page.DeathTrigger[2] = cbEventSwitchValue.SelectedIndex;
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
