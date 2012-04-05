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
using System.Collections;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class LocalSwitchConditionDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();
                if (selectedEvent != null)
                {
                    addRemoveList.SetupList(SelectedEvent.Switches, typeof(SwitchData));
                    if (selectedEvent.Switches.Count > 0)
                        PopulateSelfSwitches();
                }
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

        public SwitchData SelectedSwitch
        {
            get
            {
                if (addRemoveList.SelectedID > -1)
                    return SelectedEvent.Switches[addRemoveList.SelectedID];
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

        bool allowEdit = true;
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;


        public LocalSwitchConditionDialog()
        {
            InitializeComponent();

            //addRemoveList.AllowCategories = false;
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
            impactGroupBox2.Enabled = (addRemoveList.Count > 0);
            action = new EventProgramData();
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Data;
            action.Code = 3;
            action.Value[2] = 1;
            action.Value[1] = false;
            if (addRemoveList.Count > 0)
                addRemoveList.SelectedIndex = 0;
            PopulateSwitches();
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            addRemoveList.SelectedIndex = Global.GetIndex((int)action.Value[0], SelectedEvent.Switches);
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
                    switchesList.SelectedIndex = Global.GetIndex((int)action.Value[1], GameData.Switches);
                    allowEdit = true;
                    break;
                case 3:
                    allowEdit = false;
                    selfSwitchBtn.Checked = true; selfSwitchesList.Enabled = true;
                    selfSwitchesList.SelectedIndex = Global.GetIndex((int)action.Value[1], SelectedEvent.Switches);
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
            selfSwitchesList.RefreshList(selectedEvent, true);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (SelectedSwitch != null)
            {
                // Set Action Name
                action.Name = "Set Local Switch[ " + SelectedSwitch.Name + " ] to " + GetSwitchText();
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
            switch ((int)action.Value[2])
            {
                case 1:
                    if ((bool)action.Value[1] == true)
                        return "On";
                    else
                        return "Off";
                case 2:
                    return "Switch [" + SelectedSwitch2.Name + "]";
                case 3:
                    return "Local Switch [" + SelectedSelfSwitch.Name + "]";
            }
            return "Error";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void switchesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)action.Value[2] == 2)
            {
                action.Value[1] = SelectedSwitch2.ID;
            }
        }

        private void selfSwitchesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)action.Value[2] == 3)
            {
                action.Value[1] = SelectedSelfSwitch.ID;
            }
        }


        private void addRemoveList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            SwitchData a = new SwitchData();
            a.Name = Global.GetName("Switch", SelectedEvent.Switches);
            a.ID = Global.GetID(SelectedEvent.Switches);
            a.Category = ca.Category;
            SelectedEvent.Switches.Add(a.ID, a);
            int index = SelectedEvent.Switches[a.ID].ID;
            // History
//*IGameDataAddedHist(a, SelectedEvent.Switches, null, MainForm.eventEditor, index));
            addRemoveList.AddNode(a);
            SetupProperty();
        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex >= 0 && SelectedEvent.Switches[addRemoveList.SelectedIndex] != null)
            {
                // History
                //MainForm*IGameDataRemovedHist(SelectedEvent.Switches[addRemoveList.SelectedIndex], SelectedEvent.Switches, null, MainForm.eventEditor, addRemoveList.SelectedIndex));
                SelectedEvent.Switches.Remove(SelectedEvent.Switches[addRemoveList.SelectedIndex].ID);
                addRemoveList.RemoveSelectedNode();
                SetupProperty();
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

