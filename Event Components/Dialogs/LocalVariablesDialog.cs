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

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class LocalVariablesDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; Setup(); }
        }
        IEvent selectedEvent;

        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set
            {
                selectedPage = value;
                conditions = new List<LocalVariableCondition>(selectedPage.LocalVariableConditions); Setup();
            }
        }
        EventPageData selectedPage;

        public List<LocalVariableCondition> Conditions
        {
            get { return conditions; }
        }
        List<LocalVariableCondition> conditions;

        public LocalVariableCondition SelectedCondition
        {
            get
            {
                if (conditionsList.SelectedIndex > -1)
                    return conditions[conditionsList.SelectedIndex];
                return null;
            }
        }

        public VariableData SelectedVariable
        {
            get
            {
                if (addRemoveList.SelectedIndex > -1)
                    return SelectedEvent.Variables[addRemoveList.SelectedIndex];
                return null;
            }
        }

        public VariableData SelectedCompVariable
        {
            get
            {
                if (variableList.SelectedIndex > -1)
                    return GameData.Variables[variableList.SelectedIndex];
                return null;
            }
        }

        public LocalVariablesDialog()
        {
            InitializeComponent();
            //addRemoveList.AllowCategories = false;
        }

        internal void Setup()
        {
            if (selectedPage != null)
            {
                conditions = new List<LocalVariableCondition>();
                foreach (LocalVariableCondition c in selectedPage.LocalVariableConditions)
                {
                    LocalVariableCondition nc = new LocalVariableCondition();
                    nc.ID = c.ID;
                    nc.Name = c.Name;
                    nc.Value = c.Value;
                    nc.CompVariableID = c.CompVariableID;
                    nc.Condition = c.Condition;
                    nc.VariableID = c.VariableID;
                    nc.Type = c.Type;
                    nc.OR = c.OR;
                    conditions.Add(nc);
                }
                conditionsList.SetupList(conditions, typeof(SwitchCondition));
                addRemoveList.SetupList(SelectedEvent.Variables, typeof(VariableData));
                variableList.RefreshList(false);
            }
        }
        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        /// <summary>
        /// Setup Property
        /// </summary>
        private void SetupProperty()
        {
            if (SelectedCondition != null)
            {
                impactGroupBox2.Enabled = (SelectedEvent.Variables.Count > 0);
                impactGroupBox1.Enabled = true;
                numberBox.Value = (decimal)SelectedCondition.Value;
                variableCondList.SelectedIndex = (int)SelectedCondition.Condition;
                addRemoveList.Select(SelectedCondition.VariableID);
                variableList.Select(SelectedCondition.CompVariableID);
                radioButton1.Checked = (SelectedCondition.Type == 0);
                radioButton2.Checked = (SelectedCondition.Type == 1);
                orBox.Checked = SelectedCondition.OR;
            }
            else
            {
                impactGroupBox1.Enabled = false;
                impactGroupBox2.Enabled = false;
                numberBox.Value = 0;
            }
        }

        private void numberBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedCondition != null)
            {
                SelectedCondition.Value = (int)numberBox.Value;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void conditionsList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            LocalVariableCondition c = new LocalVariableCondition();
            c.ID = Global.GetID(conditions);
            c.Name = Global.GetName("Condition-", conditions);

            conditions.Add(c);
            conditionsList.AddNode(c);
        }

        private void conditionsList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (conditionsList.SelectedIndex >= 0 && SelectedCondition != null)
            {
                conditions.Remove(SelectedCondition);
                conditionsList.RemoveSelectedNode();
                SetupProperty();
            }
        }

        private void conditionsList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (conditionsList.SelectedIndex > -1)
            {
                impactGroupBox2.Enabled = true;
                SetupProperty();
            }
            else
            {
                impactGroupBox2.Enabled = false;
                SetupProperty();
            }
        }

        private void addRemoveList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            VariableData a = new VariableData();
            a.Name = Global.GetName("Variable", SelectedEvent.Variables);
            a.ID = Global.GetID(SelectedEvent.Variables);
            a.Category = ca.Category;
            SelectedEvent.Variables.Add(a.ID, a);
            int index = SelectedEvent.Variables[a.ID].ID;
            // History
            //MainForm*IGameDataAddedHist(a, SelectedEvent.Variables, MainForm.variablesEditor.addRemoveList, MainForm.variablesEditor, index));
            addRemoveList.AddNode(a);
            variableList.RefreshList(false);
            SetupProperty();
        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex >= 0 && SelectedEvent.Variables[addRemoveList.SelectedIndex] != null)
            {
                // History
                //MainForm*IGameDataRemovedHist(SelectedEvent.Variables[addRemoveList.SelectedIndex], SelectedEvent.Variables, MainForm.variablesEditor.addRemoveList, MainForm.variablesEditor, addRemoveList.SelectedIndex));
                SelectedEvent.Variables.Remove(SelectedEvent.Variables[addRemoveList.SelectedIndex].ID);
                addRemoveList.RemoveSelectedNode();
                variableList.RefreshList(false);
                SetupProperty();
            }
        }

        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (SelectedCondition != null)
            {
                if (SelectedVariable != null)
                    SelectedCondition.VariableID = SelectedVariable.ID;
                else
                    SelectedCondition.VariableID = -1;
            }
        }

        private void variableCondList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCondition != null)
            {
                SelectedCondition.Condition = (VariableConditions)variableCondList.SelectedIndex;
            }
        }

        private void varaibleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCondition != null)
            {
                if (SelectedCompVariable != null)
                    SelectedCondition.CompVariableID = SelectedCompVariable.ID;
                else
                    SelectedCondition.CompVariableID = -1;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                numberBox.Enabled = true;
                variableList.Enabled = false;
                SelectedCondition.Type = 0;
            }
            else
            {
                numberBox.Enabled = false;
                variableList.Enabled = true;
                SelectedCondition.Type = 1;
            }
        }

        private void orBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedCondition != null)
            {
                SelectedCondition.OR = orBox.Checked;
            }
        }
    }
}
