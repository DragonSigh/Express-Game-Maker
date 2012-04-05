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
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs;
using GenericUndoRedo;
using EGMGame.EventControls.EventDialogs.CommandDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Program_Movement_Dialogs;

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class ProgramMovementDialog : Form, IHistory, IEditor
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; }
        }
        IEvent selectedEvent;

        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }
        EventPageData selectedPage;

        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; }
        }
        List<EventProgramData> programs;

        public EventProgramData SelectedAction
        {
            get { return Programs[listBox.SelectedIndex]; }
        }

        internal object[] Values
        {
            get { return values; }
            set { values = value; }
        }
        object[] values;

        internal bool IsProgramMovement
        {
            get { return isProgramMovement; }
            set { isProgramMovement = value; Setup(); }
        }
        bool isProgramMovement = true;

        public ProgramMovementDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            SetupList();

            repeatBtn.Checked = selectedPage.RepeatMovement;
            ignoreBtn.Checked = selectedPage.SkipImpassable;

            if (!isProgramMovement)
            {
                chkWait.Enabled = true;
                cbEvents.Enabled = true;
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    cbEvents.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    cbEvents.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));

                if (values[0] != null)
                {
                    cbEvents.Select((int)values[0]);
                    chkWait.Checked = (bool)values[1];
                    repeatBtn.Checked = (bool)values[2];
                    ignoreBtn.Checked = (bool)values[3];
                }
            }
        }

        #region Categories
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (e.Graphics != null)
                e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            physicsBox.Visible = false;
            physicsBox.Enabled = false;
            physicsBtn.Checked = false;

            movementBox.Visible = true;
            movementBox.Enabled = true;
            movementBtn.Checked = true;

            settingsBox.Visible = false;
            settingsBox.Enabled = false;
            settingsBtn.Checked = false;


            conditionsBox.Visible = false;
            conditionsBox.Enabled = false;
            conditionsBtn.Checked = false;
        }

        private void physicsBtn_Click(object sender, EventArgs e)
        {
            movementBox.Visible = false;
            movementBox.Enabled = false;
            movementBtn.Checked = false;

            settingsBox.Visible = false;
            settingsBox.Enabled = false;
            settingsBtn.Checked = false;


            conditionsBox.Visible = false;
            conditionsBox.Enabled = false;
            conditionsBtn.Checked = false;

            physicsBox.Visible = true;
            physicsBox.Enabled = true;
            physicsBtn.Checked = true;
        }

        private void btnMoveVar_Click(object sender, EventArgs e)
        {
            physicsBox.Visible = false;
            physicsBox.Enabled = false;
            physicsBtn.Checked = false;


            movementBox.Visible = false;
            movementBox.Enabled = false;
            movementBtn.Checked = false;

            settingsBox.Visible = false;
            settingsBox.Enabled = false;
            settingsBtn.Checked = false;


            conditionsBox.Visible = false;
            conditionsBox.Enabled = false;
            conditionsBtn.Checked = false;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            physicsBox.Visible = false;
            physicsBox.Enabled = false;
            physicsBtn.Checked = false;

            movementBox.Visible = false;
            movementBox.Enabled = false;
            movementBtn.Checked = false;

            settingsBox.Visible = true;
            settingsBox.Enabled = true;
            settingsBtn.Checked = true;


            conditionsBox.Visible = false;
            conditionsBox.Enabled = false;
            conditionsBtn.Checked = false;
        }

        private void conditionsBtn_Click(object sender, EventArgs e)
        {
            physicsBox.Visible = false;
            physicsBox.Enabled = false;
            physicsBtn.Checked = false;

            movementBox.Visible = false;
            movementBox.Enabled = false;
            movementBtn.Checked = false;

            settingsBox.Visible = false;
            settingsBox.Enabled = false;
            settingsBtn.Checked = false;


            conditionsBox.Visible = true;
            conditionsBox.Enabled = true;
            conditionsBtn.Checked = true;
        }
        #endregion

        private void chngSwitchCondBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            EditSwitchDialog dialog = new EditSwitchDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void chngVariableValueBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            EditVariableDialog dialog = new EditVariableDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void chngLocalSwitchBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            LocalSwitchConditionDialog dialog = new LocalSwitchConditionDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void chngLocalVariableValueBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            EditVariableDialog dialog = new EditVariableDialog();
            dialog.IsLocal = true;
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void chngSpdBtn_Click(object sender, EventArgs e)
        {
            MoveSpeedDialog dialog = new MoveSpeedDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void animationOnBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 1;
            //action.TypeCode = 1;
            action.Value[0] = true;
            action.Name = "Turn Animation ON";
            Programs.Add(action);
            // History           

            // History


            SetupList();
        }

        private void animationOffBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 1;
            //action.TypeCode = 2;
            action.Value[0] = false;
            action.Name = "Turn Animation OFF";
            Programs.Add(action);
            SetupList();
        }

        private void directionFixOnBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 2;
            //action.TypeCode = 1;
            action.Value[0] = true;
            action.Name = "Direction Fix ON";
            Programs.Add(action);

            SetupList();
        }

        private void directionFixOffBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 2;
            //action.TypeCode = 2;
            action.Value[0] = false;
            action.Name = "Direction Fix OFF";
            Programs.Add(action);
            // History           

            // History


            SetupList();
        }

        private void turnCollisionOnBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 3;
            //action.TypeCode = 1;
            action.Value[0] = true;
            action.Name = "Turn Collision ON";
            Programs.Add(action);
            SetupList();
        }

        private void turnCollisionOffBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 3;
            //action.TypeCode = 2;
            action.Value[0] = false;
            action.Name = "Turn Collision OFF";
            Programs.Add(action);
            // History           

            // History


            SetupList();
        }

        private void chngAnimeBtn_Click(object sender, EventArgs e)
        {
            AnimationListDialog dialog = new AnimationListDialog();

            if (dialog.ShowDialog() == DialogResult.OK && dialog.SelectedAnimation > -1)
            {
                EventProgramData action = new EventProgramData();
                action.ID = Global.GetID(Programs);
                action.ProgramCategory = ProgramCategory.Settings;
                action.Code = 4;
                //action.TypeCode = 1;
                action.Value[0] = dialog.SelectedAnimation;
                action.Value[1] = dialog.SelectedAction;
                action.GetName(selectedEvent, null);
                Programs.Add(action);
                // History           

                // History

                // Setup
                SetupList();
            }
        }

        private void chngOpacityBtn_Click(object sender, EventArgs e)
        {

        }

        private void chngBlendingBtn_Click(object sender, EventArgs e)
        {

        }

        private void playSeBtn_Click(object sender, EventArgs e)
        {
            AudioPlayDialog dialog = new AudioPlayDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void waitBtn_Click(object sender, EventArgs e)
        {
            // Wait Frames
            WaitDialog dialog = new WaitDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = selectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                EventProgramData action = dialog.ProgramData;
                Programs.Add(action);
                // Setup
                SetupList();
            }
        }

        private void waitActionBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Other;
            action.Code = 3;
            action.Name = "Wait Action Completion";
            Programs.Add(action);
            SetupList();
        }

        private void genPathBtn_Click(object sender, EventArgs e)
        {
            MoveToDialog dialog = new MoveToDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = selectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                EventProgramData action = dialog.ProgramData;
                Programs.Add(action);
                // Setup
                SetupList();
            }
        }

        private void moveBtn_Click_1(object sender, EventArgs e)
        {
            MoveDialog dialog = new MoveDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);
                // History           
                int index = Programs.IndexOf(dialog.ProgramData);
                // History
                ////MainForm*IGameDataAddedHist(dialog.ProgramData, Programs, null, this, index));

                SetupList();
            }
        }

        private void moveTowardEventBtn_Click(object sender, EventArgs e)
        {
            MoveTowardEvent dialog = new MoveTowardEvent();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void moveAwayFromEventsBtn_Click(object sender, EventArgs e)
        {
            MoveAwayEvent dialog = new MoveAwayEvent();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnChangeSTatic_Click(object sender, EventArgs e)
        {

            ChangeStaticDialog dialog = new ChangeStaticDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void turnBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            TurnDialog dialog = new TurnDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);
                SetupList();
            }
        }

        private void turnTowardEventBtn_Click(object sender, EventArgs e)
        {
            TurnToEventDialog dialog = new TurnToEventDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void turnAwayEventBtn_Click(object sender, EventArgs e)
        {
            TurnAwayEventDialog dialog = new TurnAwayEventDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void jumpBtn_Click(object sender, EventArgs e)
        {
            JumpDialog dialog = new JumpDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }


        private void btnFreqOn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 5;
            action.Value[0] = true;
            action.Name = "Enable Frequency";
            Programs.Add(action);

            SetupList();
        }

        private void btnFreqOff_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 5;
            action.Value[0] = false;
            action.Name = "Disable Frequency";
            Programs.Add(action);

            SetupList();
        }

        private void btnChangeFreq_Click(object sender, EventArgs e)
        {
            FrequencyDialog dialog = new FrequencyDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }



        private void btnChangeForce_Click(object sender, EventArgs e)
        {
            ChangeForceDialog dialog = new ChangeForceDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnChangeImpulse_Click(object sender, EventArgs e)
        {
            ChangeImpulseDialog dialog = new ChangeImpulseDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnChangeMass_Click(object sender, EventArgs e)
        {
            ChangeMassDialog dialog = new ChangeMassDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnChangeLinearDrag_Click(object sender, EventArgs e)
        {
            ChangeLinearDragDialog dialog = new ChangeLinearDragDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnChangeRotationalDrag_Click(object sender, EventArgs e)
        {
            ChangeRotationalDragDialog dialog = new ChangeRotationalDragDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnChangeBounce_Click(object sender, EventArgs e)
        {
            ChangeBounceDialog dialog = new ChangeBounceDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnChangeFriction_Click(object sender, EventArgs e)
        {
            ChangeFrictionDialog dialog = new ChangeFrictionDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            if (isProgramMovement)
            {
                selectedPage.RepeatMovement = repeatBtn.Checked;
                selectedPage.SkipImpassable = ignoreBtn.Checked;
            }
            else
            {
                values[0] = cbEvents.Data().ID;
                values[1] = chkWait.Checked;
                values[2] = repeatBtn.Checked;
                values[3] = ignoreBtn.Checked;
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox_AddItem(object sender, AddRemoveListEventArgs ca)
        {

        }

        private void listBox_ItemCheckedState(object sender, CheckedAddRemoveListEventArgs ca)
        {
            if (ca.Index > -1)
                Programs[ca.Index].Enabled = ca.Node.Checked;
        }

        private bool listBox_ItemCheckState(object sender, AddRemoveListEventArgs ca)
        {
            return Programs[ca.Index].Enabled;
        }

        private void listBox_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.SelectedIndex > -1)
            {
                SelectAction(Programs[ca.Index]);
            }
            else
            {
                SelectAction(null);
            }
        }

        private void SelectAction(EventProgramData obj)
        {

        }

        private void listBox_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.listBox.SelectedNodes.Count > 1)
            {
                List<EventProgramData> toRemove = new List<EventProgramData>();
                foreach (TreeNode node in listBox.listBox.SelectedNodes)
                {
                    toRemove.Add(Programs[node.Index]);
                }
                for (int i = 0; i < toRemove.Count; i++)
                {
                    Programs.Remove(toRemove[i]);
                }
                SetupList();
                if (listBox.SelectedIndex == -1)
                    SelectAction(null);
            }
            else if (listBox.SelectedIndex > -1)
            {
                Programs.RemoveAt(listBox.SelectedIndex);
                SetupList();
                if (listBox.SelectedIndex == -1)
                    SelectAction(null);
            }
        }

        #region IEditor Members

        public void SetupList()
        {
            listBox.SetupList(Programs, typeof(EventProgramData), selectedEvent, selectedPage);
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void listBox_EditItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.SelectedIndex > -1)
            {
                switch (SelectedAction.ProgramCategory)
                {
                    case ProgramCategory.Movement: // Movement
                        EditMovementItem();
                        break;
                    case ProgramCategory.Settings: // Settings
                        EditSettingsItem();
                        break;
                    case ProgramCategory.Conditions: // Conditions
                        EditConditionItem();
                        break;
                    case ProgramCategory.Audio: // Sound Effect
                        AudioPlayDialog dialog = new AudioPlayDialog();
                        dialog.Programs = selectedPage.MovementPrograms;
                        dialog.SelectedPage = selectedPage;
                        dialog.SelectedEvent = SelectedEvent;
                        dialog.ProgramData = SelectedAction;
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;
                            SetupList();
                        }
                        break;
                    case ProgramCategory.Other: // Others
                        EditOthers();
                        break;
                }
            }
        }

        private void EditOthers()
        {
            switch (SelectedAction.Code)
            {
                case 1: // Wait
                    // Wait Frames
                    WaitDialog dialog1 = new WaitDialog();
                    dialog1.Programs = selectedPage.MovementPrograms;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.ProgramData = SelectedAction;
                    if (dialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog1.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;
                        // Setup
                        SetupList();
                    }
                    break;
            }
        }

        private void EditMovementItem()
        {
            try
            {
                switch (SelectedAction.Code)
                {
                    case 2: // Move
                        MoveDialog dialog1 = new MoveDialog();
                        dialog1.Programs = selectedPage.MovementPrograms;
                        dialog1.SelectedPage = selectedPage;
                        dialog1.SelectedEvent = SelectedEvent;
                        dialog1.ProgramData = SelectedAction;
                        if (dialog1.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog1.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            // History
                            ////MainForm*IGameDataAddedHist(dialog1.ProgramData, SelectedPage.MovementActions, listBox, this, index));

                            SetupList();
                        }
                        break;
                    case 4: // Move Toward
                        MoveTowardEvent dialog4 = new MoveTowardEvent();
                        dialog4.Programs = selectedPage.MovementPrograms;
                        dialog4.SelectedPage = selectedPage;
                        dialog4.SelectedEvent = SelectedEvent;
                        dialog4.ProgramData = SelectedAction;
                        if (dialog4.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog4.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 5: // Move Away
                        MoveAwayEvent dialog5 = new MoveAwayEvent();
                        dialog5.Programs = selectedPage.MovementPrograms;
                        dialog5.SelectedPage = selectedPage;
                        dialog5.SelectedEvent = SelectedEvent;
                        dialog5.ProgramData = SelectedAction;
                        if (dialog5.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog5.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 6: // Move
                        TurnDialog dialog3 = new TurnDialog();
                        dialog3.Programs = selectedPage.MovementPrograms;
                        dialog3.SelectedPage = selectedPage;
                        dialog3.SelectedEvent = SelectedEvent;
                        dialog3.ProgramData = SelectedAction;
                        if (dialog3.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog3.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 7:
                        TurnToEventDialog dialog7 = new TurnToEventDialog();
                        dialog7.Programs = selectedPage.MovementPrograms;
                        dialog7.SelectedPage = selectedPage;
                        dialog7.SelectedEvent = SelectedEvent;
                        dialog7.ProgramData = SelectedAction;
                        if (dialog7.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog7.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 8:
                        TurnToEventDialog dialog8 = new TurnToEventDialog();
                        dialog8.Programs = selectedPage.MovementPrograms;
                        dialog8.SelectedPage = selectedPage;
                        dialog8.SelectedEvent = SelectedEvent;
                        dialog8.ProgramData = SelectedAction;
                        if (dialog8.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog8.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 9:
                        MoveToDialog dialog9 = new MoveToDialog();
                        dialog9.Programs = selectedPage.MovementPrograms;
                        dialog9.SelectedPage = selectedPage;
                        dialog9.SelectedEvent = SelectedEvent;
                        dialog9.ProgramData = SelectedAction;
                        if (dialog9.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog9.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 11:
                        JumpDialog dialog11 = new JumpDialog();
                        dialog11.Programs = selectedPage.MovementPrograms;
                        dialog11.SelectedPage = selectedPage;
                        dialog11.SelectedEvent = SelectedEvent;
                        dialog11.ProgramData = SelectedAction;
                        if (dialog11.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog11.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 12:
                        MoveRandomDialog dialog12 = new MoveRandomDialog();
                        dialog12.Programs = selectedPage.MovementPrograms;
                        dialog12.SelectedPage = selectedPage;
                        dialog12.SelectedEvent = SelectedEvent;
                        dialog12.ProgramData = SelectedAction;
                        if (dialog12.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog12.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 13:
                        TurnRandomDialog dialog13 = new TurnRandomDialog();
                        dialog13.Programs = selectedPage.MovementPrograms;
                        dialog13.SelectedPage = selectedPage;
                        dialog13.SelectedEvent = SelectedEvent;
                        dialog13.ProgramData = SelectedAction;
                        if (dialog13.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog13.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 14:
                        ApplyForceDialog dialog14 = new ApplyForceDialog();
                        dialog14.Programs = selectedPage.MovementPrograms;
                        dialog14.SelectedPage = selectedPage;
                        dialog14.SelectedEvent = SelectedEvent;
                        dialog14.ProgramData = SelectedAction;
                        if (dialog14.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog14.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            //action.TypeCode = a.TypeCode;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 15:
                        ApplyRotationDialog dialog15 = new ApplyRotationDialog();
                        dialog15.Programs = selectedPage.MovementPrograms;
                        dialog15.SelectedPage = selectedPage;
                        dialog15.SelectedEvent = SelectedEvent;
                        dialog15.ProgramData = SelectedAction;
                        if (dialog15.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog15.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 16:
                        MoveToEventDialog dialog16 = new MoveToEventDialog();
                        dialog16.Programs = selectedPage.MovementPrograms;
                        dialog16.SelectedPage = selectedPage;
                        dialog16.SelectedEvent = SelectedEvent;
                        dialog16.ProgramData = SelectedAction;
                        if (dialog16.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog16.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 17:
                        ApplyTorqueDialog dialog17 = new ApplyTorqueDialog();
                        dialog17.Programs = selectedPage.MovementPrograms;
                        dialog17.SelectedPage = selectedPage;
                        dialog17.SelectedEvent = SelectedEvent;
                        dialog17.ProgramData = SelectedAction;
                        if (dialog17.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog17.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 18:
                        ApplyAngularImpulse dialog18 = new ApplyAngularImpulse();
                        dialog18.Programs = selectedPage.MovementPrograms;
                        dialog18.SelectedPage = selectedPage;
                        dialog18.SelectedEvent = SelectedEvent;
                        dialog18.ProgramData = SelectedAction;
                        if (dialog18.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog18.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                    case 20:
                        AnimateDialog dialog20 = new AnimateDialog();
                        dialog20.Programs = selectedPage.MovementPrograms;
                        dialog20.SelectedPage = selectedPage;
                        dialog20.SelectedEvent = SelectedEvent;
                        dialog20.ProgramData = SelectedAction;
                        if (dialog20.ShowDialog(this) == DialogResult.OK)
                        {
                            EventProgramData action = SelectedAction;
                            EventProgramData a = dialog20.ProgramData;
                            action.Name = a.Name;
                            action.ProgramCategory = a.ProgramCategory;
                            action.Code = a.Code;
                            action.Value = (object[])a.Value.Clone();
                            action.Enabled = a.Enabled;

                            SetupList();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "41x001");
            }
        }

        private void EditSettingsItem()
        {
            switch (SelectedAction.Code)
            {
                case 4: // Animation
                    AnimationListDialog dialog1 = new AnimationListDialog();
                    dialog1._animation = (int)SelectedAction.Value[0];
                    dialog1._action = (int)SelectedAction.Value[1];
                    if (dialog1.ShowDialog() == DialogResult.OK && dialog1.SelectedAnimation > -1)
                    {
                        EventProgramData action = SelectedAction;
                        // Data Used
                        action.ID = Global.GetID(Programs);

                        action.Value[0] = dialog1.SelectedAnimation;
                        action.Value[1] = dialog1.SelectedAction;

                        action.Name = "Change Animation To " + GameData.Animations[dialog1.SelectedAnimation].Name;
                        // Setup
                        SetupList();
                    }
                    break;
                case 7: // Move speed
                    MoveSpeedDialog dialog7 = new MoveSpeedDialog();
                    dialog7.Programs = selectedPage.MovementPrograms;
                    dialog7.SelectedPage = selectedPage;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = SelectedAction;
                    if (dialog7.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog7.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 8: // Change Forge
                    ChangeForceDialog dialog8 = new ChangeForceDialog();
                    dialog8.Programs = selectedPage.MovementPrograms;
                    dialog8.SelectedPage = selectedPage;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = SelectedAction;
                    if (dialog8.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog8.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 10: // Change Linear Drag
                    ChangeLinearDragDialog dialog10 = new ChangeLinearDragDialog();
                    dialog10.Programs = selectedPage.MovementPrograms;
                    dialog10.SelectedPage = selectedPage;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = SelectedAction;
                    if (dialog10.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog10.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 11: // Change Rotational Drag
                    ChangeRotationalDragDialog dialog11 = new ChangeRotationalDragDialog();
                    dialog11.Programs = selectedPage.MovementPrograms;
                    dialog11.SelectedPage = selectedPage;
                    dialog11.SelectedEvent = SelectedEvent;
                    dialog11.SelectedPage = SelectedPage;
                    dialog11.ProgramData = SelectedAction;
                    if (dialog11.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog11.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 12: // Change Friction
                    ChangeFrictionDialog dialog12 = new ChangeFrictionDialog();
                    dialog12.Programs = selectedPage.MovementPrograms;
                    dialog12.SelectedPage = selectedPage;
                    dialog12.SelectedEvent = SelectedEvent;
                    dialog12.SelectedPage = SelectedPage;
                    dialog12.ProgramData = SelectedAction;
                    if (dialog12.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog12.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 13: // Change Bounce
                    ChangeBounceDialog dialog13 = new ChangeBounceDialog();
                    dialog13.Programs = selectedPage.MovementPrograms;
                    dialog13.SelectedPage = selectedPage;
                    dialog13.SelectedEvent = SelectedEvent;
                    dialog13.SelectedPage = SelectedPage;
                    dialog13.ProgramData = SelectedAction;
                    if (dialog13.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog13.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 15: // Change Impulse
                    ChangeImpulseDialog dialog15 = new ChangeImpulseDialog();
                    dialog15.Programs = selectedPage.MovementPrograms;
                    dialog15.SelectedPage = selectedPage;
                    dialog15.SelectedEvent = SelectedEvent;
                    dialog15.SelectedPage = SelectedPage;
                    dialog15.ProgramData = SelectedAction;
                    if (dialog15.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog15.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 16: // Move speed
                    ChangeStaticDialog dialog16 = new ChangeStaticDialog();
                    dialog16.Programs = selectedPage.MovementPrograms;
                    dialog16.SelectedPage = selectedPage;
                    dialog16.SelectedEvent = SelectedEvent;
                    dialog16.SelectedPage = SelectedPage;
                    dialog16.ProgramData = SelectedAction;
                    if (dialog16.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog16.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 18: // Move speed
                    ChangeFixedRotationDialog dialog18 = new ChangeFixedRotationDialog();
                    dialog18.Programs = selectedPage.MovementPrograms;
                    dialog18.SelectedPage = selectedPage;
                    dialog18.SelectedEvent = SelectedEvent;
                    dialog18.SelectedPage = SelectedPage;
                    dialog18.ProgramData = SelectedAction;
                    if (dialog18.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog18.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 19: // Move speed
                    ChangeIgnoreGravityDialog dialog19 = new ChangeIgnoreGravityDialog();
                    dialog19.Programs = selectedPage.MovementPrograms;
                    dialog19.SelectedPage = selectedPage;
                    dialog19.SelectedEvent = SelectedEvent;
                    dialog19.SelectedPage = SelectedPage;
                    dialog19.ProgramData = SelectedAction;
                    if (dialog19.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog19.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 20: // Move speed
                    ChangeCustomGravityDialog dialog20 = new ChangeCustomGravityDialog();
                    dialog20.Programs = selectedPage.MovementPrograms;
                    dialog20.SelectedPage = selectedPage;
                    dialog20.SelectedEvent = SelectedEvent;
                    dialog20.SelectedPage = SelectedPage;
                    dialog20.ProgramData = SelectedAction;
                    if (dialog20.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog20.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 14: // Edit Mass
                    ChangeMassDialog dialog14 = new ChangeMassDialog();
                    dialog14.Programs = selectedPage.MovementPrograms;
                    dialog14.SelectedPage = selectedPage;
                    dialog14.SelectedEvent = SelectedEvent;
                    dialog14.SelectedPage = SelectedPage;
                    dialog14.ProgramData = SelectedAction;
                    if (dialog14.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog14.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
            }
        }

        private void EditConditionItem()
        {
            switch (SelectedAction.Code)
            {
                case 1: // Switches
                    // Set to Bool, to Switch
                    EditSwitchDialog dialog1 = new EditSwitchDialog();
                    dialog1.Programs = selectedPage.MovementPrograms;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.ProgramData = SelectedAction;
                    if (dialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog1.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 2: // Variable
                    EditVariableDialog dialog2 = new EditVariableDialog();
                    dialog2.Programs = selectedPage.MovementPrograms;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.ProgramData = SelectedAction;
                    if (dialog2.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog2.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 3: // Local Switches
                    LocalSwitchConditionDialog dialog3 = new LocalSwitchConditionDialog();
                    dialog3.Programs = selectedPage.MovementPrograms;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.ProgramData = SelectedAction;
                    if (dialog3.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog3.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
                case 4: // Local Varaible
                    EditVariableDialog dialog4 = new EditVariableDialog();
                    dialog4.IsLocal = true; dialog4.Variables = selectedEvent.Variables;
                    dialog4.Programs = selectedPage.MovementPrograms;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.ProgramData = SelectedAction;
                    if (dialog4.ShowDialog(this) == DialogResult.OK)
                    {
                        EventProgramData action = SelectedAction;
                        EventProgramData a = dialog4.ProgramData;
                        action.Name = a.Name;
                        action.ProgramCategory = a.ProgramCategory;
                        action.Code = a.Code;
                        //action.TypeCode = a.TypeCode;
                        action.Value = (object[])a.Value.Clone();
                        action.Enabled = a.Enabled;

                        SetupList();
                    }
                    break;
            }
        }

        private void listBox_DownItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.SelectedIndex > -1)
            {
                EventProgramData action = SelectedAction;
                // Down
                int i = Programs.IndexOf(action);
                if (i < Programs.Count - 1)
                {
                    Programs.Remove(action);
                    Programs.Insert(i + 1, action);
                    SetupList();
                    listBox.SelectedIndex = i + 1;
                }
            }
        }

        private void listBox_UpItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.SelectedIndex > -1)
            {
                EventProgramData action = SelectedAction;
                // Up
                int i = Programs.IndexOf(action);
                if (i > 0)
                {
                    Programs.Remove(action);
                    Programs.Insert(i - 1, action);
                    SetupList();
                    listBox.SelectedIndex = i - 1;
                }
            }

        }

        private void ignoreBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void repeatBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkWait_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnMoveToEvent_Click(object sender, EventArgs e)
        {
            MoveToEventDialog dialog = new MoveToEventDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnApplyForce_Click(object sender, EventArgs e)
        {
            ApplyForceDialog dialog = new ApplyForceDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnApplyImpulse_Click(object sender, EventArgs e)
        {
            ApplyImpulseDialog dialog = new ApplyImpulseDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnTurnRand_Click(object sender, EventArgs e)
        {
            TurnRandomDialog dialog = new TurnRandomDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnMoveRand_Click(object sender, EventArgs e)
        {
            MoveRandomDialog dialog = new MoveRandomDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnSetRotation_Click(object sender, EventArgs e)
        {
            ChangeFixedRotationDialog dialog = new ChangeFixedRotationDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnApplyTorque_Click(object sender, EventArgs e)
        {
            ApplyTorqueDialog dialog = new ApplyTorqueDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnApplyAngularImpulse_Click(object sender, EventArgs e)
        {
            ApplyAngularImpulse dialog = new ApplyAngularImpulse();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnApplyRotation_Click(object sender, EventArgs e)
        {
            ApplyRotationDialog dialog = new ApplyRotationDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnClearForce_Click(object sender, EventArgs e)
        {
            ClearForceDialog dialog = new ClearForceDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }

        }

        private void btnNextFrame_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 21;
            action.Name = "Next Frame";
            Programs.Add(action);

            SetupList();
        }
        private void btnStopAnimation_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 22;
            action.Name = "Stop Animation";
            Programs.Add(action);

            SetupList();
        }


        private void btnAnimate_Click(object sender, EventArgs e)
        {
            AnimateDialog dialog = new AnimateDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void listBox_CopyItem(object sender, AddRemoveListEventArgs ca)
        {
            if (listBox.SelectedIndex > -1)
            {
                Global.Copy(SelectedAction);
            }
        }

        private void listBox_PasteItem(object sender, AddRemoveListEventArgs ca)
        {

            object obj = Global.PasteData();

            if (obj != null && obj.GetType() == typeof(EventProgramData))
            {
                EventProgramData d = (EventProgramData)obj;
                d.ID = Global.GetID(Programs);

                Programs.Add(d);

                SetupList();

            }
        }

        private void btnPassOn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 17;
            //action.TypeCode = 1;
            action.Value[0] = true;
            action.Name = "Passthrough ON";
            Programs.Add(action);
            SetupList();
        }

        private void btnPassOff_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 17;
            //action.TypeCode = 1;
            action.Value[0] = false;
            action.Name = "Passthrough OFF";
            Programs.Add(action);
            SetupList();
        }

        private void btnIgnoreGravity_Click(object sender, EventArgs e)
        {
            ChangeIgnoreGravityDialog dialog = new ChangeIgnoreGravityDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }

        private void btnCustomGravity_Click(object sender, EventArgs e)
        {
            ChangeCustomGravityDialog dialog = new ChangeCustomGravityDialog();
            dialog.Programs = selectedPage.MovementPrograms;
            dialog.SelectedPage = selectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Programs.Add(dialog.ProgramData);

                SetupList();
            }
        }


        
        bool isAttachment = false;

        public bool IsAttachment
        {
            get { return isAttachment; }
            set
            {
                isAttachment = value;

                if (isAttachment)
                {
                    cbEvents.Visible = false;
                    attachmentList.Visible = true;
                    attachmentList.RefreshList(false, selectedPage);
                }
                else
                {
                    cbEvents.Visible = true;
                    attachmentList.Visible = false;
                }
            }
        }

        private void btnSyncAngleRotOn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 21;
            action.Value[0] = false;
            action.Name = "Sycn Angle To Rotation ON";
            Programs.Add(action);
            SetupList();
        }

        private void btnSyncAngleRotOff_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetID(Programs);
            action.ProgramCategory = ProgramCategory.Settings;
            action.Code = 21;
            action.Value[0] = false;
            action.Name = "Sycn Angle To Rotation OFF";
            Programs.Add(action);
            SetupList();
        }
    }
}
