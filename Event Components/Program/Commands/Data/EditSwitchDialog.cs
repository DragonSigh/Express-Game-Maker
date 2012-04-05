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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class EditSwitchDialog : Form
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

        public SwitchData SelectedSwitch
        {
            get
            {
                if (addRemoveList.SelectedID > -1)
                    return GameData.Switches[addRemoveList.SelectedID];
                else
                    return null;
            }
        }
        public SwitchData SelectedSwitch2
        {
            get
            {
                return switchesList.Data();
            }
        }
        public SwitchData SelectedSelfSwitch
        {
            get
            {
                return selfSwitchesList.Data();
            }
        }

        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;

        bool allowEdit = true;

        public EditSwitchDialog()
        {
            InitializeComponent();
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

        internal void Setup()
        {
            addRemoveList.SetupList(GameData.Switches, typeof(SwitchData));
            impactGroupBox2.Enabled = (addRemoveList.Count > 0);
            action = new EventProgramData();
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Data;
            action.Code = 1;
            action.Value[1] = false;
            action.Value[2] = 1;
            if (addRemoveList.Count > 0)
                addRemoveList.SelectedIndex = 0;
            PopulateSwitches();
            if (selectedEvent != null)
            {
                if (selectedEvent.Switches.Count > 0)
                    PopulateSelfSwitches();
            }
            else
            {
                selfSwitchesList.Enabled = false;
            }
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            addRemoveList.SelectedIndex = Global.GetIndex((int)action.Value[0], GameData.Switches);
            CheckChecked();
        }

        private void onBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (onBtn.Checked)
            {
                action.Value[2] = 1;
                action.Value[1] = true;
            }
        }

        private void offBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (offBtn.Checked)
            {
                action.Value[2] = 1;
                action.Value[1] = false;
            }
        }

        private void switchBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (allowEdit)
            {
                switchesList.Enabled = false;
                if (switchBtn.Checked)
                {
                    if (GameData.Switches.Count > 0)
                    {
                        action.Value[2] = 2;
                        action.Value[1] = 0;
                        switchesList.Enabled = true;
                    }
                    else
                    {
                        CheckChecked();
                    }
                }
            }
        }

        private void selfSwitchBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (allowEdit)
            {
                selfSwitchesList.Enabled = false;
                if (selfSwitchBtn.Checked)
                {
                    if (SelectedEvent.Switches.Count > 0)
                    {
                        action.Value[2] = 3;
                        action.Value[1] = 0;
                        selfSwitchesList.Enabled = true;
                    }
                    else
                    {
                        CheckChecked();
                    }
                }
            }
        }

        private void CheckChecked()
        {
            switch ((int)action.Value[2])
            {
                case 1:
                    if ((bool)action.Value[1] == true)
                        onBtn.Checked = true;
                    else
                        offBtn.Checked = true;
                    break;
                case 2:
                    allowEdit = false;
                    switchBtn.Checked = true; switchesList.Enabled = true;
                    switchesList.Select((int)action.Value[1]);
                    allowEdit = true;
                    break;
                case 3:
                    allowEdit = false;
                    selfSwitchBtn.Checked = true; selfSwitchesList.Enabled = true;
                    selfSwitchesList.Select((int)action.Value[1]);
                    allowEdit = true;
                    break;
            }
        }

        private void PopulateSwitches()
        {
            switchesList.RefreshList(true);
        }

        private void PopulateSelfSwitches()
        {
            selfSwitchesList.RefreshList(SelectedEvent, true);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (SelectedSwitch != null)
            {
                // Set Action Name
                action.Value[0] = addRemoveList.Data().ID;
                if (onBtn.Checked)
                {
                    action.Value[2] = 1;
                    action.Value[1] = true;
                }
                if (offBtn.Checked)
                {
                    action.Value[2] = 1;
                    action.Value[1] = false;
                }
                if (switchBtn.Checked)
                {
                    action.Value[2] = 2;
                    action.Value[1] = switchesList.Data().ID;
                }
                if (selfSwitchBtn.Checked)
                {
                    action.Value[2] = 3;
                    action.Value[1] = selfSwitchesList.Data().ID;
                }
                action.Name = "Set Switch[ " + SelectedSwitch.Name + " ] to " + GetSwitchText();
                action.GetName(selectedEvent, selectedPage);
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
        /// <summary>
        /// Get Switch Text
        /// </summary>
        /// <returns></returns>
        private string GetSwitchText()
        {
            if (onBtn.Checked)
                return "On";
            if (offBtn.Checked)
                return "Off";
            if (switchBtn.Checked)
                return "Switch [" + SelectedSwitch2.Name + "]";
            if (selfSwitchBtn.Checked)
                return "Local Switch [" + SelectedSelfSwitch.Name + "]";
            return "Error";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void switchesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (switchBtn.Checked)
            {
                action.Value[1] = SelectedSwitch2.ID;
            }
        }

        private void selfSwitchesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selfSwitchBtn.Checked)
            {
                action.Value[1] = SelectedSelfSwitch.ID;
            }
        }

        private void addRemoveList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            SwitchData a = new SwitchData();
            a.Name = Global.GetName("Switch", GameData.Switches);
            a.ID = Global.GetID(GameData.Switches);
            a.Category = ca.Category;
            GameData.Switches.Add(a.ID, a);
            int index = GameData.Switches[a.ID].ID;
            // History
            //MainForm*IGameDataAddedHist(a, GameData.Switches, MainForm.switchesEditor.addRemoveList, MainForm.switchesEditor, index));
            addRemoveList.AddNode(a);
            SetupProperty();

            Global.CBSwitches();
        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex >= 0 && GameData.Switches[addRemoveList.SelectedIndex] != null)
            {
                // History
                //MainForm*IGameDataRemovedHist(GameData.Switches[addRemoveList.SelectedIndex], GameData.Switches, MainForm.switchesEditor.addRemoveList, MainForm.switchesEditor, addRemoveList.SelectedIndex));
                GameData.Switches.Remove(GameData.Switches[addRemoveList.SelectedIndex].ID);
                addRemoveList.RemoveSelectedNode();
                SetupProperty();

                Global.CBSwitches();
            }
        }

        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex > -1)
            {
                impactGroupBox2.Enabled = true;
                action.Value[0] = SelectedSwitch.ID;
            }
            else
                SetupProperty();
        }

        private void SetupProperty()
        {
            if (SelectedSwitch != null)
            {
                PopulateSwitches();
                impactGroupBox2.Enabled = true;
                CheckChecked();
            }
            else
            {
                impactGroupBox2.Enabled = false;
            }
        }

    }
}
