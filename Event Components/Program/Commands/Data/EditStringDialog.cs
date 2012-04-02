using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.DataDialogs
{
    public partial class EditStringDialog : Form
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

        public EditStringDialog()
        {
            InitializeComponent();
            // Add strings
            addRemoveList.SetupList(GameData.Strings, typeof(StringData));
            valueTypeBox.SelectedIndex = 0;
            operationsList.SelectedIndex = 0;
        }        
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Data;
            action.Code = 7;
            // Refresh List
            stringComboBox1.RefreshList(false);
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
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            addRemoveList.Select((int)action.Value[0]);
            operationsList.SelectedIndex = (int)action.Value[1];
            valueTypeBox.SelectedIndex = (int)action.Value[2];
            //
            switch ((int)action.Value[2])
            {
                case 0: // Text
                    textBox.Text = action.Value[3].ToString();
                    break;
                case 1: // String
                    stringComboBox1.Select((int)action.Value[3]);
                    break;
                case 2: // Data
                    databaseList.SelectedIndex = Global.GetIndex((int)action.Value[3], GameData.Databases);

                    if (databaseList.Data().ID > -10)
                        databaseItemList.SelectedIndex = Global.GetIndex((int)action.Value[4], databaseList.Data().Datas);

                    if (databaseItemList.Data().ID > -10)
                        numericDatasetList.Select((int)action.Value[5], databaseItemList.Data().Properties);
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
            textPanel.Visible =
            stringPanel.Visible =
            dataPanel.Visible =false;
            //text 0
            //string 1
            //data 2
            switch (valueTypeBox.SelectedIndex)
            {
                case 0:
                    textPanel.Visible = textPanel.Enabled = true;
                    break;
                case 1:
                    stringPanel.Visible = stringPanel.Enabled = true;
                    break;
                case 2:
                    dataPanel.Enabled = dataPanel.Visible = true;
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
                numericDatasetList.RefreshList(databaseItemList.Data(), true, DataType.Text);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -10)
            {
                action.Value[0] = addRemoveList.Data().ID;
                action.Value[1] = operationsList.SelectedIndex;
                action.Value[2] = valueTypeBox.SelectedIndex;
                //
                switch ((int)action.Value[2])
                {
                    case 0: // Text
                        action.Value[3] = textBox.Text;
                        break;
                    case 1: // String
                        action.Value[3] = stringComboBox1.Data().ID;
                        break;
                    case 2: // Data
                        action.Value[3] = databaseList.Data().ID;
                        action.Value[4] = databaseItemList.Data().ID;
                        action.Value[5] = numericDatasetList.Data().ID;
                        break;
                }

                action.GetName(selectedEvent, selectedPage);
                this.DialogResult = DialogResult.OK;

            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
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
            StringData a = new StringData();
            a.Name = Global.GetName("String", GameData.Strings);
            a.ID = Global.GetID(GameData.Strings);
            a.Category = ca.Category;
            GameData.Strings.Add(a.ID, a);
            int index = a.ID;
            // History
            //MainForm*IGameDataAddedHist(a, GameData.Strings, MainForm.variablesEditor.addRemoveList, MainForm.variablesEditor, index));

            stringComboBox1.RefreshList(true);

            addRemoveList.AddNode(a);
            SetupProperty();

            Global.CBStrings();
        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex >= 0 && addRemoveList.SelectedIndex < GameData.Strings.Count)
            {
                // History
                //MainForm*IGameDataRemovedHist(GameData.Strings[addRemoveList.SelectedID], GameData.Strings, MainForm.variablesEditor.addRemoveList, MainForm.variablesEditor, addRemoveList.SelectedIndex));
                GameData.Strings.Remove(addRemoveList.SelectedID);
                addRemoveList.RemoveSelectedNode();

                stringComboBox1.RefreshList(true);

                SetupProperty();

                Global.CBStrings();
            }
        }
        private void SetupProperty()
        {
            if (GameData.Strings.ContainsKey(addRemoveList.SelectedID))
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

       
    }
}
