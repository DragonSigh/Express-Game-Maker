﻿//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls;

namespace EGMGame
{
    public partial class VariableConditionDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();

                if (selectedEvent == null || selectedEvent is GlobalEventData)
                {
                    eventList.RefreshList(true, false, false);
                }
                else
                {

                    eventList.RefreshList(false, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
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
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;

        #region Constructor
        public VariableConditionDialog()
        {
            InitializeComponent();

            operationsList.SelectedIndex = 0;
            valueTypeBox.SelectedIndex = 0;
        }
        #endregion
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 2;
            //action.TypeCode = 1;
            action.Branch = true;
            // Refresh List
            addRemoveList.SetupList(GameData.Variables, typeof(VariableData));
            variablesList.RefreshList(false);
            localVariableList.RefreshList(selectedEvent, false);
            databaseList.RefreshList(false);
        }
        /// <summary>
        /// Setup action
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
            variablesBtn.Checked = ((int)action.Value[6] == 0);
            localBtn.Checked = ((int)action.Value[6] == 1);
            addRemoveList.Select((int)action.Value[0]);
            operationsList.SelectedIndex = (int)action.Value[1];
            valueTypeBox.SelectedIndex = (int)action.Value[2];
            //Constant 0
            //Random Number 1
            //Variable 2
            //Local Variable 3
            //Event 4
            //Data 5 
            //Other 6
            switch ((int)action.Value[2])
            {
                case 0:
                    constantBox.Value = (decimal)(int)action.Value[3];
                    break;
                case 1:
                    rand1Num.Value = (decimal)(int)action.Value[3];
                    rand2Num.Value = (decimal)(int)action.Value[4];
                    break;
                case 2:
                    variablesList.Select((int)action.Value[3]);
                    break;
                case 3:
                    localVariableList.Select((int)action.Value[3]);
                    break;
                case 4:
                    eventList.Select((int)action.Value[3]);

                    if (eventList.Data().ID > -10)
                        eventPropertyList.SelectedIndex = (int)action.Value[4];
                    break;
                case 5:
                    databaseList.Select((int)action.Value[3]);
                    databaseItemList.RefreshList(databaseList.Data(), false);
                    databaseItemList.Select((int)action.Value[4]);
                    numericDatasetList.RefreshList(databaseItemList.Data(), false, DataType.Number);
                    numericDatasetList.Select((int)action.Value[5]);
                    break;
                case 6:
                    otherList.SelectedIndex = (int)action.Value[3];
                    break;
            }
        }
        /// <summary>
        /// Value type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide all panels
            impactGroupBox2.SuspendLayout();
            otherPanel.Enabled = otherPanel.Visible =
            constantPanel.Enabled = constantPanel.Visible =
            randPanel.Enabled = randPanel.Visible =
            variablePanel.Enabled = variablePanel.Visible =
            localVariablePanel.Enabled = localVariablePanel.Visible =
            eventsPanel.Visible = eventsPanel.Enabled =
            dataPanel.Visible = dataPanel.Enabled =
            otherPanel.Visible = otherPanel.Enabled = false;
            //Constant 0
            //Random Number 1
            //Variable 2
            //Local Variable 3
            //Event 4
            //Data 5 
            //Other 6
            switch (valueTypeBox.SelectedIndex)
            {
                case 0:
                    constantPanel.Visible = constantPanel.Enabled = true;
                    break;
                case 1:
                    randPanel.Visible = randPanel.Enabled = true;
                    break;
                case 2:
                    variablePanel.Enabled = variablePanel.Visible = true;
                    break;
                case 3:
                    localVariablePanel.Enabled = localVariablePanel.Visible = true;
                    break;
                case 4:
                    eventsPanel.Enabled = eventsPanel.Visible = true;
                    break;
                case 5:
                    dataPanel.Enabled = dataPanel.Visible = true;
                    break;
                case 6:
                    otherPanel.Enabled = otherPanel.Visible = true;
                    break;

            }
            impactGroupBox2.ResumeLayout(true);
        }
        /// <summary>
        /// Database Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void databaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseList.Data().ID > -10)
            {
                databaseItemList.Enabled = true;
                databaseItemList.RefreshList(databaseList.Data(), true);
            }
        }
        /// <summary>
        /// Database Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void databaseItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseItemList.Data().ID > -10)
            {
                numericDatasetList.Enabled = true;
                numericDatasetList.RefreshList(databaseItemList.Data(), true, DataType.Number);
            }
        }
        /// <summary>
        /// Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (addRemoveList.SelectedIndex > -1)
            {
                if (variablesBtn.Checked)
                    action.Value[6] = 0;
                else
                    action.Value[6] = 1;

                // Set Data
                action.Value[0] = addRemoveList.SelectedID;
                action.Value[1] = operationsList.SelectedIndex;
                action.Value[2] = valueTypeBox.SelectedIndex;
                //Constant 0
                //Random Number 1
                //Variable 2
                //Local Variable 3
                //Event 4
                //Data 5 
                //Other 6
                switch ((int)action.Value[2])
                {
                    case 0:
                        action.Value[3] = (int)constantBox.Value;
                        break;
                    case 1:
                        action.Value[3] = (int)rand1Num.Value;
                        action.Value[4] = (int)rand2Num.Value;
                        break;
                    case 2:
                        action.Value[3] = variablesList.Data().ID;
                        break;
                    case 3:
                        action.Value[3] = localVariableList.Data().ID;
                        break;
                    case 4:
                        action.Value[3] = eventList.Data().ID;
                        action.Value[4] = eventPropertyList.SelectedIndex;
                        break;
                    case 5:
                        action.Value[3] = databaseList.Data().ID;
                        action.Value[4] = databaseItemList.Data().ID;
                        action.Value[5] = numericDatasetList.Data().ID;
                        break;
                    case 6:
                        action.Value[3] = otherList.SelectedIndex;
                        break;
                }

                string type = "IF Variable ";
                if (localBtn.Checked)
                    type = "IF Local Variable ";
                action.Name = type + addRemoveList.Data().Name + " " + GetOperator() + " " + GetTypeOperator();

                action.GetName(selectedEvent, selectedPage);
                // Close
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private string GetTypeOperator()
        {
            switch (valueTypeBox.SelectedIndex)
            {
                case 0: // Constant
                    return constantBox.Value.ToString();
                case 1: // Rand
                    return "Random Number Between " + rand1Num.Value.ToString() + " AND " + rand2Num.Value.ToString();
                case 2:
                    return "Variable " + variablesList.Data().Name + "";
                case 3:
                    return "Local Variable " + localVariableList.Data().Name + "";
                case 4: // Event
                    if (eventPropertyList.SelectedIndex == 0)
                        return eventList.Data().Name + "'s Position X";
                    else
                        return eventList.Data().Name + "'s Position Y";
                case 5: // Datas
                    if (numericDatasetList.Data().ID > -10)
                        return "Value of " + databaseList.Data().Name + "'s " + databaseItemList.Data().Name + "'s " + numericDatasetList.Data().Name;
                    else
                        return "ERROR - Database, Data, or Property doesn't exist!";
                case 6: // Other
                    switch (otherList.SelectedIndex)
                    {
                        case 0: // Map ID
                            return "Current Map ID";
                    }
                    return "";
            }
            return "Error";
        }

        private string GetOperator()
        {
            switch (operationsList.SelectedIndex)
            {
                case 0:
                    return "(=) Equals";
                case 1:
                    return "(>) Greater Than";
                case 2:
                    return "(<) Less Than";
                case 3:
                    return "(>=) Greater Than Or Equals";
                case 4:
                    return "(<=) Less Than Or Equals";
                case 5:
                    return "(!=) Does Not Equal";
            }
            return "Error";
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Cancel
            this.Close();
        }
        /// <summary>
        /// Variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void variablesBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (variablesBtn.Checked)
            {
                addRemoveList.SetupList(GameData.Variables, typeof(VariableData));
            }
            else
            {
                addRemoveList.SetupList(SelectedEvent.Variables, typeof(VariableData));
            }
            operationsBox.Enabled = (addRemoveList.Count > 0);
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

        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            operationsBox.Enabled = (addRemoveList.SelectedID > -1);
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }
    }
}
