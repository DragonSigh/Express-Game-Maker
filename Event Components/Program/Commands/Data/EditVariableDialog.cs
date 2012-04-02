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
    public partial class EditVariableDialog : Form
    {
        public Dictionary<int, VariableData> Variables;

        public bool IsLocal = false;

        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; if (action == null) Setup();

                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    eventList.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    eventList.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                if (IsLocal)
                {
                    Variables = selectedEvent.Variables;
                    addRemoveList.SetupList(Variables, typeof(VariableData));
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


        public EditVariableDialog()
        {
            InitializeComponent();

            //addRemoveList.AllowCategories = false;
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            if (!IsLocal)
            {
                Variables = GameData.Variables;
                addRemoveList.SetupList(Variables, typeof(VariableData));
            }
            operationsList.SelectedIndex = 0;
            valueTypeBox.SelectedIndex = 0;
            eventPropertyList.SelectedIndex = 0;
            otherList.SelectedIndex = 0;
            mousePositionBox.SelectedIndex = 0;
            sitckListBox.SelectedIndex = 0;
            axisListBox.SelectedIndex = 0;
            coordinateTypeList.SelectedIndex = 0;
            cbBattlerProperty.RefreshList(GameData.Databases[1], false, DataType.Number);
            cbNumberOf.RefreshList(false);
            cbNumberOfItem.RefreshList(false);

            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Data;
            if (!IsLocal)
                action.Code = 2;
            else
                action.Code = 4;
            //action.TypeCode = 1;
            // Refresh List
            variablesList.RefreshList(false);
            localVariableList.RefreshList(selectedEvent, false);
            databaseList.RefreshList(false);
            cbEquipments.RefreshList(false);
            cbItems.RefreshList(false);

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
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
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

                    if (databaseList.Data().ID > -10)
                        databaseItemList.Select((int)action.Value[4]);

                    if (databaseItemList.Data().ID > -10)
                        numericDatasetList.Select((int)action.Value[5]);
                    break;
                case 6:
                    mousePositionBox.SelectedIndex = (int)action.Value[3];
                    coordinateTypeList.SelectedIndex = (int)action.Value[4];
                    break;
                case 7:
                    sitckListBox.SelectedIndex = (int)action.Value[3];
                    axisListBox.SelectedIndex = (int)action.Value[4];
                    axisPlayerList.SelectedIndex = (int)action.Value[5];
                    break;
                case 8:
                    cbBattlerProperty.Select((int)action.Value[3]);
                    break;
                case 9:
                    otherList.SelectedIndex = (int)action.Value[3];
                    switch ((int)action.Value[3])
                    {
                        case 4: // Item Proce
                            cbItems.Select((int)action.Value[4]);
                            break;
                        case 5: // Equipment Price
                            cbEquipments.Select((int)action.Value[4]);
                            break;
                        case 7:
                            cbNumberOf.Select((int)action.Value[4]);
                            cbNumberOfItem.Select((int)action.Value[5]);
                            break;
                        case 8:
                            cbNumberOf.Select((int)action.Value[4]);
                            cbNumberOfItem.Select((int)action.Value[5]);
                            break;
                    }
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
            panelBattler.Visible =
            otherPanel.Visible =
            constantPanel.Visible =
             randPanel.Visible =
            variablePanel.Visible =
             localVariablePanel.Visible =
            eventsPanel.Visible =
            dataPanel.Visible =
            mousePanel.Visible =
            axisPanel.Visible =
            otherPanel.Visible = false;
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
                    mousePanel.Visible = true;
                    break;
                case 7:
                    axisPanel.Visible = true;
                    break;
                case 8:
                    panelBattler.Enabled = panelBattler.Visible = true;
                    break;
                case 9:
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
                // Set Data
                action.Value[0] = addRemoveList.SelectedID;
                action.Value[1] = operationsList.SelectedIndex;
                action.Value[2] = valueTypeBox.SelectedIndex;

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
                        if (databaseList.Data().ID > -10)
                            action.Value[3] = databaseList.Data().ID;
                        if (databaseItemList.Data().ID > -10)
                            action.Value[4] = databaseItemList.Data().ID;
                        if (databaseItemList.Data().ID > -10)
                            action.Value[5] = numericDatasetList.Data().ID;
                        break;
                    case 6:
                        action.Value[3] = mousePositionBox.SelectedIndex;
                        action.Value[4] = coordinateTypeList.SelectedIndex;
                        break;
                    case 7:
                        action.Value[3] = sitckListBox.SelectedIndex;
                        action.Value[4] = axisListBox.SelectedIndex;
                        action.Value[5] = axisPlayerList.SelectedIndex;
                        break;
                    case 8:
                        action.Value[3] = cbBattlerProperty.Data().ID;
                        break;
                    case 9:
                        action.Value[3] = otherList.SelectedIndex;
                        switch ((int)action.Value[3])
                        {
                            case 4: // Item Proce
                                action.Value[4] = cbItems.Data().ID;
                                break;
                            case 5: // Equipment Price
                                action.Value[4] = cbEquipments.Data().ID;
                                break;
                            case 7: // Number of items
                                action.Value[4] = cbNumberOf.Data().ID;
                                action.Value[5] = cbNumberOfItem.Data().ID;
                                break;
                            case 8: // Number of equipment
                                action.Value[4] = cbNumberOf.Data().ID;
                                action.Value[5] = cbNumberOfItem.Data().ID;
                                break;
                        }
                        break;
                }

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
                    switch (eventPropertyList.SelectedIndex)
                    {
                        case 0:
                            return eventList.Data().Name + "'s Position X";
                        case 1:
                            return eventList.Data().Name + "'s Position Y";
                        case 2:
                            return eventList.Data().Name + "'s Angle";
                        case 3:
                            return eventList.Data().Name + "'s Force X";
                        case 4:
                            return eventList.Data().Name + "'s Force Y";
                        case 5:
                            return eventList.Data().Name + "'s Mass";
                    }
                    break;
                case 5: // Datas
                    if (numericDatasetList.Data().ID > -10)
                        return "Value of " + databaseList.Data().Name + "'s " + databaseItemList.Data().Name + "'s " + numericDatasetList.Data().Name;
                    else
                        return "ERROR - Database, Data, or Property doesn't exist!";
                case 6: // Mouse
                    return "Mouse " + mousePositionBox.Text;
                case 7: // 
                    return "Controller " + sitckListBox.Text + " " + axisListBox.Text + " [" + axisPlayerList.Text + "]";
                case 8: // Other
                    switch (otherList.SelectedIndex)
                    {
                        case 0: // Map ID
                            return "Current Map ID";
                        case 1:
                            return "Hit Counter";

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
                    return "=";
                case 1:
                    return "+=";
                case 2:
                    return "-=";
                case 3:
                    return "*=";
                case 4:
                    return "/=";
                case 5:
                    return "^=";
                case 6:
                    return "r=";
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
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void addRemoveList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            VariableData a = new VariableData();
            a.Name = Global.GetName("Variable", Variables);
            a.ID = Global.GetID(Variables);
            a.Category = ca.Category;
            Variables.Add(a.ID, a);
            int index = a.ID;
            // History
            ////MainForm*IGameDataAddedHist(a, Variables, MainForm.variablesEditor.addRemoveList, MainForm.variablesEditor, index));

            variablesList.RefreshList(true);

            addRemoveList.AddNode(a);
            SetupProperty();
            Global.CBVariables();
        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex >= 0 && addRemoveList.SelectedIndex < Variables.Count)
            {
                // History
                //MainForm*IGameDataRemovedHist(Variables[addRemoveList.SelectedID], Variables, MainForm.variablesEditor.addRemoveList, MainForm.variablesEditor, addRemoveList.SelectedIndex));
                Variables.Remove(addRemoveList.SelectedID);
                addRemoveList.RemoveSelectedNode();

                variablesList.RefreshList(true);

                SetupProperty();
                Global.CBVariables();
            }
        }
        private void SetupProperty()
        {
            if (Variables.ContainsKey(addRemoveList.SelectedID))
            {
                impactGroupBox2.Enabled = true;
            }
            else
            {
                impactGroupBox2.Enabled = false;
            }
        }

        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            SetupProperty();
        }

        private void mousePositionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coordinateTypeList.Enabled = (mousePositionBox.SelectedIndex != 2);
        }

        private void otherList_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelItem.Visible = (otherList.SelectedIndex == 4);
            panelEquipment.Visible = (otherList.SelectedIndex == 5);
            panelNumberOf.Visible = (otherList.SelectedIndex == 7 || otherList.SelectedIndex == 8);
        }
    }
}
