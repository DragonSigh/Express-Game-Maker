using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls.EventControls.EventDialogs;
using EGMGame.Dialogs;
using GenericUndoRedo;

namespace EGMGame.Controls.EventControls
{
    public partial class PlayerPageControl : UserControl
    {

        [Browsable(false)]
        public EventData SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; }
        }
        EventData selEvent;

        [Browsable(false)]
        public EventPageData SelectedEventPage
        {
            get { return selPage; }
            set { selPage = value; SetupPage(); }
        }
        EventPageData selPage;

        bool allowChange = true;

        public UndoRedoHistory<IHistory> SelectedHistory;

        public PlayerPageControl()
        {
            InitializeComponent();

            cbDirections.SelectedIndex = 0;
        }

        private void SetupPage()
        {
            if (selPage != null)
            {
                allowChange = false;
                // ListBox
                behaviorProgramListBox1.SelectedEvent = SelectedEvent;
                behaviorProgramListBox1.SelectedPage = SelectedEventPage;
                behaviorProgramListBox1.SelectedHistory = SelectedHistory = MainForm.PlayerHistory[MainForm.playerEditor];

                // Trigger Condition
                chkStatic.Checked = SelectedEventPage.IsStatic;

                chFreqBox.Checked = SelectedEventPage.EnableFrequency;

                nudFreq.Value = SelectedEventPage.Frequency;

                cbDirections.SelectedIndex = ((PlayerData)SelectedEvent).StartDirection;

                cbParticles.RefreshList(false);
                cbParticles.Select(SelectedEventPage.ParticleID);

                List<int> dir = ((PlayerData)SelectedEvent).MovementType;
                upBtn.Checked = dir.Contains(0);
                downBtn.Checked = dir.Contains(1);
                leftBtn.Checked = dir.Contains(2);
                rightBtn.Checked = dir.Contains(3);
                upLeftBtn.Checked = dir.Contains(4);
                upRightBtn.Checked = dir.Contains(5);
                downLeftBtn.Checked = dir.Contains(6);
                downRightBtn.Checked = dir.Contains(7);

                nudMaxParty.Value = ((PlayerData)SelectedEvent).MaxPartySize;

                partyList.Nodes.Clear();
                List<int> remove = new List<int>();
                TreeNode node;
                foreach (int id in ((PlayerData)SelectedEvent).PartyList)
                {
                    if (GameData.Heroes.ContainsKey(id))
                    {
                        node = new TreeNode(GameData.Heroes[id].Name);
                        node.Tag = id;
                        partyList.Nodes.Add(node);
                    }
                    else
                    {
                        remove.Add(id);
                    }
                }

                foreach (int id in remove)
                {
                    ((PlayerData)SelectedEvent).PartyList.Remove(id);
                }

                allowChange = true;
            }
        }

        private void animationPanel_DoubleClick(object sender, EventArgs e)
        {
            AnimationListDialog dialog = new AnimationListDialog();
            dialog.SelectedAnimation = SelectedEventPage.AnimationID;
            dialog.HideActions = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.SelectedAnimation > -1)
                {
                    if (allowChange)
                        SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));

                    SelectedEventPage.AnimationID = dialog.SelectedAnimation;
                }
                else
                {
                    if (allowChange)
                        SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                    SelectedEventPage.AnimationID = -1;
                }
            }
        }

        private void EventPageControl_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {

            }
        }

        private void btnAddParty_Click(object sender, EventArgs e)
        {
            PlayerData player = ((PlayerData)SelectedEvent);

            ChooseMemberDialog dialog = new ChooseMemberDialog();

            if (dialog.ShowDialog(MainForm.Instance) == DialogResult.OK)
            {
                if (!player.PartyList.Contains(dialog.cnHeros.Data().ID))
                {
                    if (allowChange)
                        SelectedHistory.Do(new IGameDataChangePropertyHist(player, new DataPropertyDelegate(PagePropertyChanged)));
                    player.PartyList.Add(dialog.cnHeros.Data().ID);
                    TreeNode node = new TreeNode(dialog.cnHeros.Data().Name);
                    node.Tag = dialog.cnHeros.Data().ID;
                    partyList.Nodes.Add(node);
                }
            }
        }

        private void btnRemoveParty_Click(object sender, EventArgs e)
        {
            PlayerData player = ((PlayerData)SelectedEvent);

            if (partyList.SelectedNode != null)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(player, new DataPropertyDelegate(PagePropertyChanged)));
                player.PartyList.Remove((int)partyList.SelectedNode.Tag);
                partyList.SelectedNode.Remove();
            }
        }

        private void btnPartyUP_Click(object sender, EventArgs e)
        {
            PlayerData player = ((PlayerData)SelectedEvent);

            if (partyList.SelectedNode != null && partyList.SelectedNode.Index > 0)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(player, new DataPropertyDelegate(PagePropertyChanged)));
                int index = partyList.SelectedNode.Index;
                TreeNode node = partyList.SelectedNode;
                partyList.SelectedNode.Remove();
                partyList.Nodes.Insert(index - 1, node);

                player.PartyList.RemoveAt(index);
                player.PartyList.Insert(index - 1, (int)node.Tag);

                partyList.SelectedNode = node;
            }
        }

        private void btnPartyDW_Click(object sender, EventArgs e)
        {
            PlayerData player = ((PlayerData)SelectedEvent);

            if (partyList.SelectedNode != null && partyList.SelectedNode.Index < partyList.Nodes.Count - 1)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(player, new DataPropertyDelegate(PagePropertyChanged)));
                int index = partyList.SelectedNode.Index;
                TreeNode node = partyList.SelectedNode;
                partyList.SelectedNode.Remove();
                partyList.Nodes.Insert(index + 1, node);

                player.PartyList.RemoveAt(index);
                player.PartyList.Insert(index + 1, (int)node.Tag);

                partyList.SelectedNode = node;
            }
        }

        private void upLeftBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (upLeftBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(4))
                    ((PlayerData)SelectedEvent).MovementType.Add(4);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(4);
            }
        }

        private void upBtn_CheckedChanged(object sender, EventArgs e)
        {
            int dir = 0;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (upBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(dir))
                    ((PlayerData)SelectedEvent).MovementType.Add(dir);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(dir);
            }
        }

        private void upRightBtn_CheckedChanged(object sender, EventArgs e)
        {
            int dir = 5;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (upRightBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(dir))
                    ((PlayerData)SelectedEvent).MovementType.Add(dir);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(dir);
            }
        }

        private void leftBtn_CheckedChanged(object sender, EventArgs e)
        {
            int dir = 2;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (leftBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(dir))
                    ((PlayerData)SelectedEvent).MovementType.Add(dir);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(dir);
            }
        }

        private void downLeftBtn_CheckedChanged(object sender, EventArgs e)
        {
            int dir = 6;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (downLeftBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(dir))
                    ((PlayerData)SelectedEvent).MovementType.Add(dir);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(dir);
            }
        }

        private void downBtn_CheckedChanged(object sender, EventArgs e)
        {
            int dir = 1;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (downBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(dir))
                    ((PlayerData)SelectedEvent).MovementType.Add(dir);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(dir);
            }
        }

        private void downRightBtn_CheckedChanged(object sender, EventArgs e)
        {
            int dir = 7;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (downRightBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(dir))
                    ((PlayerData)SelectedEvent).MovementType.Add(dir);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(dir);
            }
        }

        private void rightBtn_CheckedChanged(object sender, EventArgs e)
        {
            int dir = 3;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist((PlayerData)SelectedEvent, new DataPropertyDelegate(PagePropertyChanged)));

            if (rightBtn.Checked)
            {
                if (!((PlayerData)SelectedEvent).MovementType.Contains(dir))
                    ((PlayerData)SelectedEvent).MovementType.Add(dir);
            }
            else
            {
                ((PlayerData)SelectedEvent).MovementType.Remove(dir);
            }
        }

        private void nudMaxParty_ValueChanged(object sender, EventArgs e)
        {
            ((PlayerData)SelectedEvent).MaxPartySize = (int)nudMaxParty.Value;
        }

        private void btnControlMapping_Click(object sender, EventArgs e)
        {
            ControlMappingDialog dialog = new ControlMappingDialog();
            dialog.ShowDialog();
        }

        private void chFreqBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));

            SelectedEventPage.EnableFrequency = chFreqBox.Checked;
        }

        private void nudFreq_ValueChanged(object sender, EventArgs e)
        {
            SelectedEventPage.Frequency = (int)nudFreq.Value;
        }


        internal void PagePropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            SetupPage();
        }

        private void nudMaxParty_Validated(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;

            CustomUpDown nud = nudMaxParty;
            if (nud.OnChange)
            {
                int newValue = ((PlayerData)SelectedEvent).MaxPartySize;
                SelectedEventPage.Force = (int)nud.OldValue;
                SelectedHistory.Do(new IGameDataChangePropertyHist(((PlayerData)SelectedEvent), new DataPropertyDelegate(PagePropertyChanged)));
                ((PlayerData)SelectedEvent).MaxPartySize = newValue;
                nud.OnChange = false;
            }
        }

        private void nudFreq_Validated(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;

            CustomUpDown nud = nudFreq;
            if (nud.OnChange)
            {
                int newValue = SelectedEventPage.Frequency;
                SelectedEventPage.Frequency = (int)nud.OldValue;
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                SelectedEventPage.Frequency = newValue;
                nud.OnChange = false;
            }
        }

        private void nudSpeed_Validated(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;

            CustomUpDown nud = nudSpeed;
            if (nud.OnChange)
            {
                int newValue = SelectedEventPage.Speed;
                SelectedEventPage.Speed = (int)nud.OldValue;
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                SelectedEventPage.Speed = newValue;
                nud.OnChange = false;
            }
        }

        private void chkStatic_CheckedChanged(object sender, EventArgs e)
        {
            nudSpeed.Enabled = chkStatic.Checked;
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            SelectedEventPage.IsStatic = chkStatic.Checked;
        }

        private void btnPhysics_Click(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            EventPhysicSettingsDialog dialog = new EventPhysicSettingsDialog();
            dialog.Setup(SelectedEventPage, SelectedHistory, new DataPropertyDelegate(PagePropertyChanged));
            dialog.ShowDialog();
        }

        private void cbDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));

            ((PlayerData)SelectedEvent).StartDirection = cbDirections.SelectedIndex;
        }

        private void cbParticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            SelectedEventPage.ParticleID = cbParticles.Data().ID;
        }

        private void chkSyncAngleToRotation_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            SelectedEventPage.SyncAngleToRotation = chkSyncAngleToRotation.Checked;
        }

        internal void ResetProject()
        {
            
        }

        internal void Unload()
        {
        }

        private void btnJoints_Click(object sender, EventArgs e)
        {
            JointsDialog dialog = new JointsDialog(selPage, selEvent);
            dialog.ShowDialog();
        }
    }
}
