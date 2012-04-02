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
    public partial class VariableLoopDialog : Form
    {
        #region Constructor
        public VariableLoopDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Properties
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; Setup(); }
        }
        EventPageData selectedPage;

        public IEvent SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; }
        }
        IEvent selEvent;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        #endregion
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;


        #region Setup Methods
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Loops;
            action.Code = 5;

            PopulateAll();
        }

        private void SetupAction(EventProgramData a)
        {
            PopulateAll();

            action = new EventProgramData();
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            CheckAll();
            CheckAllUI();
        }
        #endregion        

        #region UI/Value Checks

        private void CheckAll()
        {
            CheckConditionsBox();
            CheckInrementBox();
        }

        private void CheckConditionsBox()
        {
            // Operation
            cbConditionOperations.SelectedIndex = (int)action.Value[0] - 1;

            // Radio buttons
            switch ((int)action.Value[1])
            {
                case 1: // Variable
                    rbConditionVariable.Checked = true;

                    int d = Global.GetIndex((int)action.Value[2], GameData.Variables);
                    if (d > -1)
                        cbConditionVariables.SelectedIndex = d;
                    break;
                case 2: // Local Variables
                    rbConditionLocalVariable.Checked = true;

                    int e = Global.GetIndex((int)action.Value[3], SelectedEvent.Variables);
                    if (e > -1)
                        cbConditionLocalVariable.SelectedIndex = e;
                    break;
                case 3: // Constant
                    rbConditionConstant.Checked = true;

                    nudConditionConstant.Value = (decimal)action.Value[4];
                    break;
                case 4: // Random
                    rbConditionRandomNumber.Checked = true;

                    // Number Up Downs
                    nudConditionRandom1.Value = (decimal)action.Value[5];
                    nudConditionRandom2.Value = (decimal)action.Value[6];
                    break;
                case 5: // Event
                    rbConditionEvent.Checked = true;

                    int f = Global.GetIndex((int)action.Value[7], GameData.Events);
                    if (f > -1)
                        cbConditionEvent.SelectedIndex = f;

                    cbIncrementEventProperty.SelectedIndex = (int)action.Value[8] - 1;
                    break;
                case 6: // Data
                    rbConditionData.Checked = true;

                    int g = Global.GetIndex((int)action.Value[9], GameData.Databases);
                    if (g > -1)
                        cbConditionDatabase.SelectedIndex = g;

                    int h = Global.GetIndex((int)action.Value[10], GameData.Databases[g].Datas);
                    if (h > -1)
                        cbConditionDatabaseItem.SelectedIndex = h;

                    int i = Global.GetIndex((int)action.Value[11], GameData.Databases[g].Datas[h].Properties);
                    if (i > -1)
                        cbConditionDatabaseProperty.SelectedIndex = i;

                    break;
                case 7: // Other
                    rbConditionOther.Checked = true;

                    cbConditionOther.SelectedIndex = (int)action.Value[12] - 1;
                    break;
            }

        }

        private void CheckInrementBox()
        {
            // Radio buttons
            switch ((int)action.Value[13])
            {
                case 1: // Variable
                    rbIncrementVariable.Checked = true;

                    int d = Global.GetIndex((int)action.Value[14], GameData.Variables);
                    if (d > -1)
                        cbIncrementVariable.SelectedIndex = d;
                    break;
                case 2: // Local Variables
                    rbIncrementLocalVariable.Checked = true;

                    int e = Global.GetIndex((int)action.Value[15], SelectedEvent.Variables);
                    if (e > -1)
                        cbIncrementLocalVariable.SelectedIndex = e;
                    break;
                case 3: // Constant
                    rbIncrementConstant.Checked = true;

                    nudIncrementConstant.Value = (decimal)action.Value[16];
                    break;
                case 4: // Random
                    rbIncrementRandomNumber.Checked = true;

                    // Number Up Downs
                    nudIncrementRandom1.Value = (decimal)action.Value[17];
                    nudIncrementRandom2.Value = (decimal)action.Value[18];
                    break;
                case 5: // Event
                    rbIncrementEvent.Checked = true;

                    int f = Global.GetIndex((int)action.Value[19], GameData.Events);
                    if (f > -1)
                        cbIncrementEvent.SelectedIndex = f;

                    cbIncrementEventProperty.SelectedIndex = (int)action.Value[20] - 1;
                    break;
                case 6: // Data
                    rbIncrementData.Checked = true;

                    int g = Global.GetIndex((int)action.Value[21], GameData.Databases);
                    if (g > -1)
                        cbIncrementDatabase.SelectedIndex = g;

                    int h = Global.GetIndex((int)action.Value[22], GameData.Databases[g].Datas);
                    if (h > -1)
                        cbIncrementDatabaseItem.SelectedIndex = h;

                    int i = Global.GetIndex((int)action.Value[23], GameData.Databases[g].Datas[h].Properties);
                    if (i > -1)
                        cbIncrementDatabaseProperty.SelectedIndex = i;

                    break;
                case 7: // Other
                    rbIncrementOther.Checked = true;

                    cbIncrementOther.SelectedIndex = (int)action.Value[24] - 1;
                    break;
            }
        }
        #endregion

        #region UI Checks

        private void CheckAllUI()
        {
            CheckConditionUI();
            CheckIncrementUI();
        }

        private void CheckConditionUI()
        {
            // Radio Buttons
            if (rbConditionVariable.Checked)            
                cbConditionVariables.Enabled = true;
            else
                cbConditionVariables.Enabled = false;

            if (rbConditionLocalVariable.Checked)
                cbConditionLocalVariable.Enabled = true;
            else
                cbConditionLocalVariable.Enabled = false;

            if (rbConditionConstant.Checked)            
                nudConditionConstant.Enabled = true;
            else
                nudConditionConstant.Enabled = false;

            if (rbConditionRandomNumber.Checked)            
                nudConditionRandom1.Enabled = nudConditionRandom2.Enabled = true;
            else
                nudConditionRandom1.Enabled = nudConditionRandom2.Enabled = false;

            if (rbConditionEvent.Checked)            
                cbConditionEvent.Enabled = cbConditionEventProperty.Enabled = true;
            else
                cbConditionEvent.Enabled = cbConditionEventProperty.Enabled = false;

            if (rbConditionData.Checked)            
                cbConditionDatabase.Enabled = cbConditionDatabaseItem.Enabled = cbConditionDatabaseProperty.Enabled = true;
            else
                cbConditionDatabase.Enabled = cbConditionDatabaseItem.Enabled = cbConditionDatabaseProperty.Enabled = false;

            if (rbConditionOther.Checked)            
                cbConditionOther.Enabled = true;
            else
                cbConditionOther.Enabled = false;
        }

        private void CheckIncrementUI()
        {
            // Radio Buttons
            if (rbIncrementVariable.Checked)
                cbIncrementVariable.Enabled = true;
            else
                cbIncrementVariable.Enabled = false;

            if (rbIncrementLocalVariable.Checked)
                cbIncrementLocalVariable.Enabled = true;
            else
                cbIncrementLocalVariable.Enabled = false;

            if (rbIncrementConstant.Checked)
                nudIncrementConstant.Enabled = true;
            else
                nudIncrementConstant.Enabled = false;

            if (rbIncrementRandomNumber.Checked)
                nudIncrementRandom1.Enabled = nudIncrementRandom2.Enabled = true;
            else
                nudIncrementRandom1.Enabled = nudIncrementRandom2.Enabled = false;

            if (rbIncrementEvent.Checked)
                cbIncrementEvent.Enabled = cbIncrementEventProperty.Enabled = true;
            else
                cbIncrementEvent.Enabled = cbIncrementEventProperty.Enabled = false;

            if (rbIncrementData.Checked)
                cbIncrementDatabase.Enabled = cbIncrementDatabaseItem.Enabled = cbIncrementDatabaseProperty.Enabled = true;
            else
                cbIncrementDatabase.Enabled = cbIncrementDatabaseItem.Enabled = cbIncrementDatabaseProperty.Enabled = false;

            if (rbIncrementOther.Checked)
                cbIncrementOther.Enabled = true;
            else
                cbIncrementOther.Enabled = false;
        }

        #endregion

        #region Population
        
        private void PopulateAll()
        {
            PopulateConditionBox();
            PopulateIncrementBox();
        }

        private void PopulateConditionBox()
        {
            // Variables
            cbConditionVariables.Items.Clear();

            foreach (VariableData variable in GameData.Variables.Values)
            {
                cbConditionVariables.Items.Add(variable);
            }
            if (cbConditionVariables.Items.Count > 0)
                cbConditionVariables.SelectedIndex = 0;

            // Local Variables
            cbConditionLocalVariable.Items.Clear();

            foreach (VariableData variable in SelectedEvent.Variables.Values)
            {
                cbConditionLocalVariable.Items.Add(variable);
            }
            if (cbConditionLocalVariable.Items.Count > 0)
                cbConditionLocalVariable.SelectedIndex = 0;

            // Events
            cbConditionEvent.Items.Clear();

            foreach (EventData eventi in GameData.Events.Values)
            {
                cbConditionEvent.Items.Add(eventi);
            }
            if (cbConditionEvent.Items.Count > 0)
                cbConditionEvent.SelectedIndex = 0;

            // Database
            cbConditionEvent.Items.Clear();

            foreach (Data eventi in GameData.Databases.Values)
            {
                cbConditionEvent.Items.Add(eventi);
            }
            if (cbConditionEvent.Items.Count > 0)
                cbConditionEvent.SelectedIndex = 0;            
        }

        private void PopulateConditionDatabaseItem(Data dataItem)
        {
            // Database Items
            cbConditionDatabaseItem.Items.Clear();

            foreach (Data data in dataItem.Datas.Values)
            {
                cbConditionDatabaseItem.Items.Add(data);
            }
            if (cbConditionDatabaseItem.Items.Count > 0)
                cbConditionDatabaseItem.SelectedIndex = 0;
        }

        private void PopulateConditionDatabaseProperty(Data dataItem)
        {
            // Database Property
            cbConditionDatabaseProperty.Items.Clear();

            foreach (DataProperty dataset in dataItem.Properties)
            {
                cbConditionDatabaseProperty.Items.Add(dataset);
            }
            if (cbConditionDatabaseProperty.Items.Count > 0)
                cbConditionDatabaseProperty.SelectedIndex = 0;
        }

        private void PopulateIncrementBox()
        {
            // Variables
            cbIncrementVariable.Items.Clear();

            foreach (VariableData variable in GameData.Variables.Values)
            {
                cbIncrementVariable.Items.Add(variable);
            }
            if (cbIncrementVariable.Items.Count > 0)
                cbIncrementVariable.SelectedIndex = 0;

            // Local Variables
            cbIncrementLocalVariable.Items.Clear();

            foreach (VariableData variable in SelectedEvent.Variables.Values)
            {
                cbIncrementLocalVariable.Items.Add(variable);
            }
            if (cbIncrementLocalVariable.Items.Count > 0)
                cbIncrementLocalVariable.SelectedIndex = 0;

            // Events
            cbIncrementEvent.Items.Clear();

            foreach (EventData eventi in GameData.Events.Values)
            {
                cbIncrementEvent.Items.Add(eventi);
            }
            if (cbIncrementEvent.Items.Count > 0)
                cbIncrementEvent.SelectedIndex = 0;

            // Database
            cbIncrementEvent.Items.Clear();

            foreach (Data eventi in GameData.Databases.Values)
            {
                cbIncrementEvent.Items.Add(eventi);
            }
            if (cbIncrementEvent.Items.Count > 0)
                cbIncrementEvent.SelectedIndex = 0;
        }

        private void PopulateIncrementDatabaseItem(Data dataItem)
        {
            // Database Items
            cbIncrementDatabaseItem.Items.Clear();

            foreach (Data data in dataItem.Datas.Values)
            {
                cbIncrementDatabaseItem.Items.Add(data);
            }
            if (cbIncrementDatabaseItem.Items.Count > 0)
                cbIncrementDatabaseItem.SelectedIndex = 0;
        }

        private void PopulateIncrementDatabaseProperty(Data dataItem)
        {
            // Database Property
            cbIncrementDatabaseProperty.Items.Clear();

            foreach (DataProperty dataset in dataItem.Properties)
            {
                cbIncrementDatabaseProperty.Items.Add(dataset);
            }
            if (cbIncrementDatabaseProperty.Items.Count > 0)
                cbIncrementDatabaseProperty.SelectedIndex = 0;
        }

        #endregion

        #region Form Drawing Code
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        #endregion

        #region Value Setting

        private void SetAll()
        {
            SetCondition();
            SetIncrement();
        }

        private void SetCondition()
        {
            // Operation
            action.Value[0] = cbConditionOperations.SelectedIndex - 1;

            // Radio buttons
            if (rbConditionVariable.Checked)
            {
                action.Value[1] = 1;
                action.Value[2] = ((VariableData)cbConditionVariables.SelectedItem).ID;
            }
            else if (rbConditionLocalVariable.Checked)
            {
                action.Value[1] = 2;
                action.Value[3] = ((VariableData)cbConditionLocalVariable.SelectedItem).ID;
            }
            else if (rbConditionConstant.Checked)
            {
                action.Value[1] = 3;
                action.Value[4] = nudConditionConstant.Value;
            }
            else if (rbConditionRandomNumber.Checked)
            {
                action.Value[1] = 4;
                action.Value[5] = nudConditionRandom1.Value;
                action.Value[6] = nudConditionRandom2.Value;
            }
            else if (rbConditionEvent.Checked)
            {
                action.Value[1] = 5;
                action.Value[7] = ((EventData)cbConditionEvent.SelectedItem).ID;
                action.Value[8] = cbConditionEventProperty.SelectedIndex - 1;
            }
            else if (rbConditionData.Checked)
            {
                action.Value[1] = 6;
                action.Value[9] = ((Data)cbConditionDatabase.SelectedItem).ID;
                action.Value[10] = ((Data)cbConditionDatabaseItem.SelectedItem).ID;
                action.Value[11] = ((DataProperty)cbConditionDatabaseProperty.SelectedItem).ID;
            }
            else if (rbConditionOther.Checked)
            {
                action.Value[1] = 7;
                action.Value[12] = cbConditionOther.SelectedIndex - 1;
            }
        }

        private void SetIncrement()
        {
            // Radio buttons
            if (rbIncrementVariable.Checked)
            {
                action.Value[13] = 1;
                action.Value[14] = ((VariableData)cbIncrementVariable.SelectedItem).ID;
            }
            else if (rbIncrementLocalVariable.Checked)
            {
                action.Value[13] = 2;
                action.Value[15] = ((VariableData)cbIncrementLocalVariable.SelectedItem).ID;
            }
            else if (rbIncrementConstant.Checked)
            {
                action.Value[13] = 3;
                action.Value[16] = nudIncrementConstant.Value;
            }
            else if (rbIncrementRandomNumber.Checked)
            {
                action.Value[13] = 4;
                action.Value[17] = nudIncrementRandom1.Value;
                action.Value[18] = nudIncrementRandom1.Value;
            }
            else if (rbIncrementEvent.Checked)
            {
                action.Value[13] = 5;
                action.Value[19] = ((EventData)cbIncrementEvent.SelectedItem).ID;
                action.Value[20] = cbIncrementEventProperty.SelectedIndex - 1;
            }
            else if (rbIncrementData.Checked)
            {
                action.Value[13] = 6;
                action.Value[21] = ((Data)cbIncrementDatabase.SelectedItem).ID;
                action.Value[22] = ((Data)cbIncrementDatabaseItem.SelectedItem).ID;
                action.Value[23] = ((DataProperty)cbIncrementDatabaseProperty.SelectedItem).ID;
            }
            else if (rbIncrementOther.Checked)
            {
                action.Value[13] = 7;
                action.Value[24] = cbIncrementOther.SelectedIndex - 1;
            }
        }
        #endregion

        #region Name Setting
        private void SetName()
        {
            action.Name = "Variable Loop - " + GetOperationName() + " Condition: " +
                GetConditionName() + " Increment: " +
                GetIncrementName();
        }
        private string GetOperationName()
        {
            switch ((int)action.Value[0])
            {
                case 1:
                    return ">";
                case 2:
                    return "<";
                case 3:
                    return ">=";
                case 4:
                    return "<=";
                
            }
            return "";
        }
        private string GetConditionName()
        {
            switch ((int)action.Value[1])
            {
                case 1:
                    return "Variable(" + cbConditionVariables.SelectedText + ")";
                case 2:
                    return "Local Variable("+cbConditionLocalVariable.SelectedText+")";
                case 3:
                    return "Constant(" + nudConditionConstant.Value.ToString() + ")";
                case 4:
                    return "Random(" + nudConditionRandom1.Value.ToString() + ", " + nudConditionRandom2.Value.ToString() + ")";
                case 5:
                    return "Event(" + cbConditionEvent.SelectedText +", "+ cbConditionEventProperty.SelectedText + ")";
                case 6:
                    return cbConditionDatabase.SelectedText + ", " + cbConditionDatabaseItem.SelectedText + ", " + cbConditionDatabaseProperty.SelectedText;
                case 7:
                    return "Pther(" + cbConditionOther.SelectedText + ")";
            }
            return "";
        }
        private string GetIncrementName()
        {
            switch ((int)action.Value[13])
            {
                case 1:
                    return "Variable(" + cbConditionVariables.SelectedText + ")";
                case 2:
                    return "Local Variable(" + cbConditionLocalVariable.SelectedText + ")";
                case 3:
                    return "Constant(" + nudConditionConstant.Value.ToString() + ")";
                case 4:
                    return "Random(" + nudConditionRandom1.Value.ToString() + ", " + nudConditionRandom2.Value.ToString() + ")";
                case 5:
                    return "Event(" + cbConditionEvent.SelectedText + ", " + cbConditionEventProperty.SelectedText + ")";
                case 6:
                    return cbConditionDatabase.SelectedText + ", " + cbConditionDatabaseItem.SelectedText + ", " + cbConditionDatabaseProperty.SelectedText;
                case 7:
                    return "Pther(" + cbConditionOther.SelectedText + ")";
            }
            return "";
        }
        #endregion

        #region Control Events
        private void okBtn_Click(object sender, EventArgs e)
        {
            // Set Value return
            SetAll();
            // Set name return
            SetName();
        }

        private void rbConditionVariable_CheckedChanged(object sender, EventArgs e)
        {
            CheckConditionUI();
        }

        private void rbConditionLocalVariable_CheckedChanged(object sender, EventArgs e)
        {
            CheckConditionUI();
        }

        private void rbConditionConstant_CheckedChanged(object sender, EventArgs e)
        {
            CheckConditionUI();
        }

        private void rbConditionRandomNumber_CheckedChanged(object sender, EventArgs e)
        {
            CheckConditionUI();
        }

        private void rbConditionEvent_CheckedChanged(object sender, EventArgs e)
        {
            CheckConditionUI();
        }

        private void rbConditionData_CheckedChanged(object sender, EventArgs e)
        {
            CheckConditionUI();
        }

        private void rbConditionOther_CheckedChanged(object sender, EventArgs e)
        {
            CheckConditionUI();
        }

        private void rbIncrementVariable_CheckedChanged(object sender, EventArgs e)
        {
            CheckIncrementUI();
        }

        private void rbIncrementLocalVariable_CheckedChanged(object sender, EventArgs e)
        {
            CheckIncrementUI();
        }

        private void rbIncrementConstant_CheckedChanged(object sender, EventArgs e)
        {
            CheckIncrementUI();
        }

        private void rbIncrementRandomNumber_CheckedChanged(object sender, EventArgs e)
        {
            CheckIncrementUI();
        }

        private void rbIncrementEvent_CheckedChanged(object sender, EventArgs e)
        {
            CheckIncrementUI();
        }

        private void rbIncrementData_CheckedChanged(object sender, EventArgs e)
        {
            CheckIncrementUI();
        }

        private void rbIncrementOther_CheckedChanged(object sender, EventArgs e)
        {
            CheckIncrementUI();
        }
        private void cbConditionDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateConditionDatabaseItem((Data)cbConditionDatabase.SelectedItem);
        }
        private void cbConditionDatabaseItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateConditionDatabaseProperty((Data)cbConditionDatabaseItem.SelectedItem);
        }
        #endregion

        private void cbIncrementDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateIncrementDatabaseItem((Data)cbIncrementDatabase.SelectedItem);
        }

        private void cbIncrementDatabaseItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateIncrementDatabaseProperty((Data)cbIncrementDatabaseItem.SelectedItem);
        }


    }
}
