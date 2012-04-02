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
using EGMGame.Controls.EventControls.Enemy;
using GenericUndoRedo;

namespace EGMGame.Controls.EventControls
{
    public partial class EventPageControl : UserControl
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

        public UndoRedoHistory<IHistory> SelectedHistory;

        bool allowChange = true;
        bool couldnotrefresh;

        public EventPageControl()
        {
            InitializeComponent();

            cbTrigger.SelectedIndex = 0;
            directionsList.SelectedIndex = 0;
            animationViewer.graphicsControl.DoubleClick += new EventHandler(animationPanel_DoubleClick);


            if (Global.Project != null)
            {
                cbCursor.RefreshList(false, MaterialDataType.Image);

                enemyComboBox1.RefreshList(false);
            }
            else
                couldnotrefresh = true;
        }

        private void SetupPage()
        {
            if (selPage != null)
            {
                allowChange = false;

                // cbCursor.RefreshList(false, MaterialDataType.Image);

                //enemyComboBox1.RefreshList(false);
                // ListBox
                behaviorProgramListBox1.SelectedEvent = SelectedEvent;
                behaviorProgramListBox1.SelectedPage = SelectedEventPage;
                behaviorProgramListBox1.SelectedHistory = SelectedHistory;
                if (directionsList.SelectedIndex < -1)
                    directionsList.SelectedIndex = 0;
                // Action
                PopulateActions();
                // Animation
                AnimationData a = Global.GetData<AnimationData>(SelectedEventPage.AnimationID, GameData.Animations);
                if (a != null && SelectedEventPage.ActionID > -1)
                {
                    actionList.SelectedIndex = Global.GetIndex(SelectedEventPage.ActionID, a.Actions);
                    directionsList.SelectedIndex = SelectedEventPage.Direction;
                }
                UpdateAnimation();
                // Activation Condition
                switchChk.Checked = SelectedEventPage.SwitchCondition;
                variablChk.Checked = SelectedEventPage.VariableCondition;
                localSwitchChk.Checked = SelectedEventPage.LocalSwitchCondition;
                localVariableChk.Checked = SelectedEventPage.LocalVariableCondition;
                // Trigger Condition
                cbTrigger.SelectedIndex = (int)SelectedEventPage.TriggerConditions;


                chkStatic.Checked = SelectedEventPage.IsStatic;

                enemyComboBox1.RefreshList(false);
                enemyComboBox1.Select(SelectedEventPage.Enemy);
                btnProgramAI.Enabled = (enemyComboBox1.Data().ID > -1);
                nudFreq.Value = SelectedEventPage.Frequency;
                chFreqBox.Checked = SelectedEventPage.EnableFrequency;

                cbParticles.RefreshList(false);
                cbParticles.Select(SelectedEventPage.ParticleID);

                chkSyncAngleToRotation.Checked = SelectedEventPage.SyncAngleToRotation;

                chkPass.Checked = SelectedEventPage.PassThrough;

                cbCursor.Select(SelectedEventPage.Cursor);

                chkEventSwitch.Checked = SelectedEventPage.EventSwitchCondition;

                chkMovingPlatform.Checked = SelectedEventPage.IsMovingPlatform;
                
                allowChange = true;
            }
            else
            {
                actionList.Items.Clear();
            }
        }

        internal void PagePropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (SelectedEventPage == data)
            {
                SetupPage();
            }
        }

        private void PopulateActions()
        {
            actionList.Items.Clear();

            if (SelectedEventPage.AnimationID > -1)
            {
                AnimationData animation = Global.GetData<AnimationData>(SelectedEventPage.AnimationID, GameData.Animations);
                if (animation != null)
                {
                    foreach (AnimationAction action in animation.Actions)
                    {
                        actionList.Items.Add(action.Name);
                    }
                    AnimationAction a = Global.GetData<AnimationAction>(SelectedEventPage.ActionID, animation.Actions);
                    if (a != null)
                    {
                        actionList.SelectedIndex = Global.GetIndex(SelectedEventPage.ActionID, animation.Actions);
                    }
                }
            }
        }
        private void animationAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selPage != null && allowChange)
            {
                AnimationData animation = Global.GetData<AnimationData>(SelectedEventPage.AnimationID, GameData.Animations);
                if (animation != null)
                {
                    if (actionList.SelectedIndex > -1)
                    {
                        if (allowChange)
                            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                        //IGameData data = Global.GetData<IGameData>(SelectedEventPage.ActionID, animation.Actions);
                        SelectedEventPage.ActionID = animation.Actions[actionList.SelectedIndex].ID;

                    }
                    else
                    {
                        if (allowChange)
                            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                        SelectedEventPage.ActionID = -1;
                    }
                    UpdateAnimation();
                }
            }
        }

        private void directionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selPage != null && allowChange)
            {
                AnimationData animation = Global.GetData<AnimationData>(SelectedEventPage.AnimationID, GameData.Animations);
                if (animation != null && actionList.SelectedIndex > -1)
                {
                    if (directionsList.SelectedIndex > -1)
                    {
                        if (allowChange)
                            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                        SelectedEventPage.Direction = directionsList.SelectedIndex;

                    }
                    else
                    {
                        if (allowChange)
                            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                        SelectedEventPage.Direction = 0;
                    }
                    UpdateAnimation();
                }
            }
        }

        private void movementProgramBtn_Click(object sender, EventArgs e)
        {
            ProgramMovementDialog dialog = new ProgramMovementDialog();
            dialog.SelectedEvent = SelectedEvent;
            dialog.SelectedPage = SelectedEventPage;
            List<EventProgramData> programs = new List<EventProgramData>();

            EventProgramData action;
            foreach (EventProgramData pData in SelectedEventPage.MovementPrograms)
            {
                action = new EventProgramData();
                action.ID = pData.ID;
                action.Name = pData.Name;
                action.ProgramCategory = pData.ProgramCategory;
                action.Code = pData.Code;
                //action.TypeCode = pData.TypeCode;
                action.Value = (object[])pData.Value.Clone();
                action.Enabled = pData.Enabled;
                programs.Add(action);
                CloneChildPrograms(pData, action);
            }
            dialog.Programs = programs;
            dialog.IsProgramMovement = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));
                SelectedEventPage.MovementPrograms = dialog.Programs;
            }
        }

        private void CloneChildPrograms(EventProgramData parent, EventProgramData clone)
        {
            EventProgramData action;
            foreach (EventProgramData pData in parent.Programs)
            {
                action = new EventProgramData();
                action.ID = pData.ID;
                action.Name = pData.Name;
                action.ProgramCategory = pData.ProgramCategory;
                action.Code = pData.Code;
                //action.TypeCode = pData.TypeCode;
                action.Value = (object[])pData.Value.Clone();
                action.Enabled = pData.Enabled;
                clone.Programs.Add(action);
                CloneChildPrograms(pData, action);
            }
        }

        private void switchChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            switchesBtn.Enabled = SelectedEventPage.SwitchCondition = switchChk.Checked;
        }

        private void switchesBtn_Click(object sender, EventArgs e)
        {
            SwitchesDialog dialog = new SwitchesDialog();
            dialog.SelectedPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));
                // Condition
                SelectedEventPage.SwitchConditions = dialog.Conditions;
            }
        }

        private void variablChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            variablesBtn.Enabled = SelectedEventPage.VariableCondition = variablChk.Checked;
        }

        private void variablesBtn_Click(object sender, EventArgs e)
        {
            VariablesDialog dialog = new VariablesDialog();
            dialog.SelectedPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));
                SelectedEventPage.VariableConditions = dialog.Conditions;
            }
        }

        private void localSwitchChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            localSwitchesBtn.Enabled = SelectedEventPage.LocalSwitchCondition = localSwitchChk.Checked;
        }

        private void localSwitchesBtn_Click(object sender, EventArgs e)
        {
            LocalSwitchesDialog dialog = new LocalSwitchesDialog();
            dialog.SelectedEvent = SelectedEvent;
            dialog.SelectedPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));
                // Remove Old data
                foreach (LocalSwitchCondition data in SelectedEventPage.LocalSwitchConditions)
                {
                    //// IReference key = (// IReference)Global.GetDataFromID(data.SwitchID, SelectedEvent.Switches);
                    //if (key != null)
                    //    key.RemoveReference(data);
                }
                SelectedEventPage.LocalSwitchConditions = dialog.Conditions;
                // Add New data
                foreach (LocalSwitchCondition data in SelectedEventPage.LocalSwitchConditions)
                {
                    //// IReference key = (// IReference)Global.GetDataFromID(data.SwitchID, SelectedEvent.Switches);
                    //if (key != null)
                    //    key.AddReference(data);
                }
            }
        }

        private void localVariableChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            localVariablesBtn.Enabled = SelectedEventPage.LocalVariableCondition = localVariableChk.Checked;
        }

        private void localVariablesBtn_Click(object sender, EventArgs e)
        {
            LocalVariablesDialog dialog = new LocalVariablesDialog();
            dialog.SelectedEvent = SelectedEvent;
            dialog.SelectedPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));
                // Remove Old data
                foreach (LocalVariableCondition data in SelectedEventPage.LocalVariableConditions)
                {
                    //// IReference key = (// IReference)Global.GetDataFromID(data.VariableID, SelectedEvent.Variables);
                    //if (key != null)
                    //    key.RemoveReference(data);
                }
                SelectedEventPage.LocalVariableConditions = dialog.Conditions;
                // Add New data
                foreach (LocalVariableCondition data in SelectedEventPage.LocalVariableConditions)
                {
                    // IReference key = (// IReference)Global.GetDataFromID(data.VariableID, SelectedEvent.Variables);
                    //if (key != null)
                    //    key.AddReference(data);
                }
            }
        }

        private void listEventsBtn_Click(object sender, EventArgs e)
        {
            ListEventsDialog dialog = new ListEventsDialog();
            dialog.SelectedEvent = SelectedEvent;
            dialog.EventPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));
                SelectedEventPage.TouchEventIDs = dialog.TouchEventIDs;
                SelectedEventPage.TouchTemplateEventIDs = dialog.TouchTEventIDs;
            }
        }

        private void animationPanel_DoubleClick(object sender, EventArgs e)
        {
            AnimationListDialog dialog = new AnimationListDialog();
            dialog.SelectedAnimation = SelectedEventPage.AnimationID;
            dialog.Direction = SelectedEventPage.Direction;
            dialog.HideActions = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.SelectedAnimation > -1)
                {
                    if (allowChange)
                        SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                    // IReference data = (// IReference)Global.GetDataFromID(SelectedEventPage.AnimationID, GameData.Animations);
                    //if (data != null && MainForm.ReferenceList.ContainsKey((IGameData)data))
                    //    data.RemoveReference(SelectedEventPage);
                    SelectedEventPage.AnimationID = dialog.SelectedAnimation;
                    SelectedEventPage.Direction = dialog.Direction;
                    directionsList.SelectedIndex = dialog.Direction;
                }
                else
                {
                    if (allowChange)
                        SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                    //// IReference data = (// IReference)Global.GetDataFromID(SelectedEventPage.AnimationID, GameData.Animations);
                    //if (data != null && MainForm.ReferenceList.ContainsKey((IGameData)data))
                    //    data.RemoveReference(SelectedEventPage);
                    SelectedEventPage.AnimationID = -1;
                }
                UpdateAnimation();
                PopulateActions();
            }
        }

        private void UpdateAnimation()
        {
            if (SelectedEventPage.AnimationID > -1)
            {
                label.Visible = false;
            }
            else
            {
                label.Visible = true;
            }
            if (SelectedEventPage != null && SelectedEventPage.AnimationID > -1 && SelectedEventPage.ActionID > -1)
            {
                AnimationData a = Global.GetData<AnimationData>(SelectedEventPage.AnimationID, GameData.Animations);
                if (a != null)
                {
                    AnimationAction ac = Global.GetData<AnimationAction>(SelectedEventPage.ActionID, a.Actions);

                    if (ac != null)
                    {

                        if (directionsList.SelectedIndex > -1 && ac.Directions.Count > directionsList.SelectedIndex && ac.Directions[directionsList.SelectedIndex] != null && ac.Directions[directionsList.SelectedIndex].Count > 0)
                        {
                            animationViewer.SelectedAction = ac;
                            animationViewer.SelectedFrame = ac.Directions[directionsList.SelectedIndex][0];
                        }
                        else
                        {
                            animationViewer.SelectedFrame = null;
                        }
                    }
                }

            }
            else
            {
                animationViewer.SelectedFrame = null;
            }
        }

        private void EventPageControl_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {
                animationViewer.SelectedFrame = null;
            }
        }

        private void enemyComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enemyComboBox1.Data().ID > -1)
            {
                btnProgramAI.Enabled = true;
            }
            else
            {
                btnProgramAI.Enabled = false;
            }
            if (allowChange && SelectedEventPage != null)
            {
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));

                SelectedEventPage.Enemy = enemyComboBox1.Data().ID;
            }
        }

        private void btnProgramAI_Click(object sender, EventArgs e)
        {
            EnemyAIDialog dialog = new EnemyAIDialog();
            dialog.Event = SelectedEvent;
            dialog.Page = SelectedEventPage;
            dialog.SelectedHistory = SelectedHistory;
            dialog.Setup();
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

        private void cbTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTrigger.SelectedIndex == 1)
            {
                panelCol.Visible = true;
                panelMouse.Visible = false;
                panelInput.Visible = false;
            }
            else if (cbTrigger.SelectedIndex == 4)
            {
                panelMouse.Visible = true;
                panelCol.Visible = false;
                panelInput.Visible = false;
            }
            else if (cbTrigger.SelectedIndex == 6)
            {
                panelInput.Visible = true;
                panelCol.Visible = false;
                panelMouse.Visible = false;
            }
            else
            {
                panelCol.Visible = false;
                panelMouse.Visible = false;
                panelInput.Visible = false;
            }

            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));

            SelectedEventPage.TriggerConditions = (TriggerConditions)cbTrigger.SelectedIndex;
        }

        private void chkMapCollision_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            SelectedEventPage.MapCollisionTrigger = chkMapCollision.Checked;
        }

        private void btnMouseInputCondition_Click(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            EventMouseInputDialog dialog = new EventMouseInputDialog();
            dialog.ProgramData = SelectedEventPage.MouseTriggerProgram;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));

                SelectedEventPage.MouseTriggerProgram = dialog.ProgramData;
            }
        }

        private void chkGBmouse_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            SelectedEventPage.GlobalMouseTrigger = chkGBmouse.Checked;
        }

        private void btnButtonInputCondition_Click(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedEventPage == null) return;
            EventInputDialog dialog = new EventInputDialog();
            dialog.ProgramData = SelectedEventPage.InputTriggerProgram;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));

                SelectedEventPage.InputTriggerProgram = dialog.ProgramData;
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

        private void nudNearScreen_Validated(object sender, EventArgs e)
        {
            //if (!allowChange) return;
            //if (SelectedEventPage == null) return;

            //CustomUpDown nud = nudNearScreen;
            //if (nud.OnChange)
            //{
            //    int newValue = SelectedEventPage.;
            //    SelectedEventPage.Acceleration = (int)nud.OldValue;
            //    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            //    SelectedEventPage. = newValue;
            //    nud.OnChange = false;
            //}
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

        private void cbParticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selPage != null && allowChange)
            {
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                SelectedEventPage.ParticleID = cbParticles.Data().ID;
            }
        }
        private void chkSyncAngleToRotation_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (selPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            selPage.SyncAngleToRotation = chkSyncAngleToRotation.Checked;
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (selPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            selPage.PassThrough = chkPass.Checked;
        }

        private void cbCursor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (selPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            selPage.Cursor = cbCursor.Data().ID;
        }

        internal void ResetProject()
        {
            animationViewer.ResetContentManger();
        }

        private void btnEventSwitches_Click(object sender, EventArgs e)
        {
            EventSwitchesDialog dialog = new EventSwitchesDialog();
            dialog.SelectedEvent = SelectedEvent;
            dialog.SelectedPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (allowChange)
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage));

                SelectedEventPage.EventSwitchConditions = dialog.EventSwitchConditions;
            }
        }

        private void chkEventSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            btnEventSwitches.Enabled = SelectedEventPage.EventSwitchCondition = chkEventSwitch.Checked;
 
        }



        internal void RefreshList()
        {
            if (couldnotrefresh)
                cbCursor.RefreshList(true);
            enemyComboBox1.RefreshList(true);
        }

        private void chkMovingPlatform_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (selPage == null) return;
            SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            selPage.IsMovingPlatform = chkMovingPlatform.Checked;
        }

        private void btnJoints_Click(object sender, EventArgs e)
        {
            JointsDialog dialog = new JointsDialog(selPage, selEvent);
            dialog.ShowDialog();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void animationViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
