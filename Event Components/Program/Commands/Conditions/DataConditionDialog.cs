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
    public partial class DataConditionDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
           set { selectedEvent = value; if (action == null ) Setup(); }
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


        public DataConditionDialog()
        {
            InitializeComponent();
            databaseBox.RefreshList(false);

            operationsList.SelectedIndex = 0;
            valueTypeBox.SelectedIndex = 0;
            eventPropertyList.SelectedIndex = 0;
            otherList.SelectedIndex = 0;
            textOperationsList.SelectedIndex = 0;
        }
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Conditions;
            action.Code = 4;
            //action.TypeCode = 1;
            // Refresh List
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
            action.Else = a.Else; action.Else = a.Else; elseBranc.Checked = action.Else;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            databaseBox.SelectedIndex = Global.GetIndex((int)action.Value[0], GameData.Databases);

            if (databaseBox.Data().ID > -10)
                dataBox.SelectedIndex = Global.GetIndex((int)action.Value[1], databaseList.Data().Datas);

            if (dataBox.Data().ID > -10)
                propertyBox.Select((int)action.Value[2], databaseItemList.Data().Properties);

            if (propertyBox.Data().ID > -10)
            {
                if (propertyBox.Data().ValueType == DataType.Number && action.Value[3] is int)
                {
                    numericOperationsBox.Enabled = true;
                    numericOperationsBox.Visible = true;
                    operationsList.SelectedIndex = (int)action.Value[3];
                    valueTypeBox.SelectedIndex = (int)action.Value[4];

                    switch ((int)action.Value[4])
                    {
                        case 0:
                            constantBox.Value = (decimal)(int)action.Value[5];
                            break;
                        case 1:
                            rand1Num.Value = (decimal)(int)action.Value[5];
                            rand2Num.Value = (decimal)(int)action.Value[6];
                            break;
                        case 2:
                            variablesList.SelectedIndex = Global.GetIndex((int)action.Value[5], GameData.Variables);
                            break;
                        case 3:
                            localVariableList.SelectedIndex = Global.GetIndex((int)action.Value[5], selectedEvent.Variables);
                            break;
                        case 4:
                            eventList.Select((int)action.Value[5]);

                            if (eventList.Data().ID > -10)
                                eventPropertyList.SelectedIndex = (int)action.Value[6];
                            break;
                        case 5:
                            databaseList.SelectedIndex = Global.GetIndex((int)action.Value[5], GameData.Databases);

                            if (databaseList.Data().ID > -10)
                                databaseItemList.SelectedIndex = Global.GetIndex((int)action.Value[5], databaseList.Data().Datas);

                            if (databaseItemList.Data().ID > -10)
                                numericDatasetList.Select((int)action.Value[6], databaseItemList.Data().Properties);
                            break;
                        case 6:
                            otherList.SelectedIndex = (int)action.Value[5];
                            break;
                    }
                }
                else if (propertyBox.Data().ValueType == DataType.Text && action.Value[3] is string)
                {
                    numericOperationsBox.Visible = false;
                    textOperationsBox.Visible = true;
                    textBox.Text = (string)action.Value[3];
                    textOperationsList.SelectedIndex = (int)action.Value[4];
                }
            }
        }
        /// <summary>
        /// ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (propertyBox.Data().ID > -10)
            {
                action.Value = new object[10];
                if (propertyBox.Data().ValueType == DataType.Number)
                {
                    // Set Data
                    action.Value[0] = databaseBox.Data().ID;
                    action.Value[1] = dataBox.Data().ID;
                    action.Value[2] = propertyBox.Data().ID;
                    action.Value[3] = operationsList.SelectedIndex;
                    action.Value[4] = valueTypeBox.SelectedIndex;

                    switch ((int)action.Value[4])
                    {
                        case 0://Constant 0
                            action.Value[5] = (int)constantBox.Value;
                            break;
                        case 1://Random Number 1
                            action.Value[5] = (int)rand1Num.Value;
                            action.Value[6] = (int)rand2Num.Value;
                            break;
                        case 2://Variable 2
                            action.Value[5] = variablesList.Data().ID;
                            break;
                        case 3://Local Variable 3
                            action.Value[5] = localVariableList.Data().ID;
                            break;
                        case 4://Event 4
                            action.Value[5] = eventList.Data().ID;
                            action.Value[6] = eventPropertyList.SelectedIndex;
                            break;
                        case 5://Data 5
                            if (databaseList.Data().ID > -10)
                                action.Value[5] = databaseList.Data().ID;
                            if (databaseItemList.Data().ID > -10)
                                action.Value[6] = databaseItemList.Data().ID;
                            if (databaseItemList.Data().ID > -10)
                                action.Value[7] = numericDatasetList.Data().ID;
                            break;
                        case 6://Other 6
                            action.Value[5] = otherList.SelectedIndex;
                            break;
                    }
                    action.Name = "IF Database: " + GetDataName() + " " + GetOperator() + " " + GetTypeOperator();

                    action.GetName(selectedEvent, selectedPage);
                    // Close
                    this.DialogResult = DialogResult.OK;
                }
                else if (propertyBox.Data().ValueType == DataType.Text)
                {
                    action.Value[0] = databaseBox.Data().ID;
                    action.Value[1] = dataBox.Data().ID;
                    action.Value[2] = propertyBox.Data().ID;
                    // Text
                    action.Value[3] = textBox.Text;
                    action.Value[4] = textOperationsList.SelectedIndex;

                    action.Name = "IF Database: " + GetDataName() + GetOperator() + textBox.Text;
                    action.GetName(selectedEvent, selectedPage);
                    // Close
                    this.DialogResult = DialogResult.OK;
                }
            }
            this.Close();
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

        private string GetDataName()
        {
            if (propertyBox.Data().ID > -10)
                return databaseBox.Data().Name + "'s " + dataBox.Data().Name + "'s " + propertyBox.Data().Name;
            else
                return "ERROR - Database, Data, or Property doesn't exist!";
        }
        // Get Operator
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
            if (propertyBox.Data().ValueType == DataType.Number)
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
            }
            else if (propertyBox.Data().ValueType == DataType.Text)
            {
                switch (textOperationsList.SelectedIndex)
                {
                    case 0:
                        return " (=) Equals ";
                    case 1:
                        return " (!=) Does Not Equal ";
                }
                return "Error";
            }
            return "Error";
        }

        #region Numeric
        private void valueTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide all panels
            numericOperationsBox.SuspendLayout();
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
            numericOperationsBox.ResumeLayout(true);
        }

        private void databaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseList.Data().ID > -10)
            {
                databaseItemList.Enabled = true;
                databaseItemList.RefreshList(databaseList.Data(), true);
            }
        }

        private void databaseItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseItemList.Data().ID > -10)
            {
                numericDatasetList.Enabled = true;
                numericDatasetList.RefreshList(databaseItemList.Data(), true, DataType.Number);
            }
        }
        #endregion

        private void databaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseBox.Data().ID > -10)
            {
                dataBox.Enabled = true;
                dataBox.RefreshList(databaseBox.Data(), true);
            }
        }

        private void dataBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataBox.Data().ID > -10)
            {
                propertyBox.Enabled = true;
                propertyBox.RefreshList(dataBox.Data(), true);
            }
            else
            {
                numericOperationsBox.Enabled = numericOperationsBox.Visible = false;
                textOperationsBox.Enabled = textOperationsBox.Visible = false;
            }
        }

        private void propertyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (propertyBox.Data().ID > -10)
            {
                if (propertyBox.Data().ValueType == DataType.Number)
                {
                    textOperationsBox.Enabled = textOperationsBox.Visible = false;
                    numericOperationsBox.Enabled = numericOperationsBox.Visible = true;
                }
                else if (propertyBox.Data().ValueType == DataType.Text)
                {
                    numericOperationsBox.Enabled = numericOperationsBox.Visible = false;
                    textOperationsBox.Enabled = textOperationsBox.Visible = true;
                }
            }
            else
            {
                numericOperationsBox.Enabled = numericOperationsBox.Visible = false;
                textOperationsBox.Enabled = textOperationsBox.Visible = false;
            }
        }

        private void elseBranc_CheckedChanged(object sender, EventArgs e)
        {
            action.Else = elseBranc.Checked;
        }
    }
}
