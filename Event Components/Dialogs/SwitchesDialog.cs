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
    public partial class SwitchesDialog : Form
    {

        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set
            {
                selectedPage = value;
                Setup();
            }
        }
        EventPageData selectedPage;

        public List<SwitchCondition> Conditions
        {
            get { return conditions; }
        }
        List<SwitchCondition> conditions;

        public SwitchCondition SelectedCondition
        {
            get
            {
                if (conditionsList.SelectedIndex > -1)
                    return conditions[conditionsList.SelectedIndex];
                return null;
            }
        }

        public SwitchData SelectedSwitch
        {
            get
            {
                if (addRemoveList.SelectedIndex > -1)
                    return GameData.Switches[addRemoveList.SelectedIndex];
                return null;
            }
        }

        public SwitchesDialog()
        {
            InitializeComponent();
        }
        internal void Setup()
        {
            conditions = new List<SwitchCondition>();
            foreach (SwitchCondition c in selectedPage.SwitchConditions)
            {
                SwitchCondition nc = new SwitchCondition();
                nc.ID = c.ID;
                nc.Name = c.Name;
                nc.State = c.State;
                nc.SwitchID = c.SwitchID;
                nc.OR = c.OR;
                conditions.Add(nc);
            }
            conditionsList.SetupList(conditions, typeof(SwitchCondition));
            addRemoveList.SetupList(GameData.Switches, typeof(SwitchData));
        }
        /// <summary>
        /// Setup Property
        /// </summary>
        private void SetupProperty()
        {
            if (SelectedCondition != null)
            {
                switchesBox.Enabled = true;
                conditionBox.Enabled = (GameData.Switches.Count > 0);
                onBtn.Checked = SelectedCondition.State;
                offBtn.Checked = !SelectedCondition.State;
                addRemoveList.SelectedIndex = Global.GetIndex(SelectedCondition.SwitchID, GameData.Switches);
                orBox.Checked = SelectedCondition.OR;
            }
            else
            {
                conditionBox.Enabled = false;
                switchesBox.Enabled = false;
            }
        }

        private void onBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedCondition != null)
            {
                if (onBtn.Checked)
                    SelectedCondition.State = true;
                else
                    SelectedCondition.State = false;
            }
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
            SwitchCondition c = new SwitchCondition();
            c.ID = Global.GetID(conditions);
            c.Name = Global.GetName("Condition-", conditions);

            conditions.Add(c);
            conditionsList.SetupList(conditions, typeof(SwitchCondition));
        }

        private void conditionsList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (conditionsList.SelectedIndex >= 0 && SelectedCondition != null)
            {
                conditions.Remove(SelectedCondition);
                conditionsList.SetupList(conditions, typeof(SwitchCondition));
                SetupProperty();
            }
        }

        private void conditionsList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (conditionsList.SelectedIndex > -1)
            {
                conditionBox.Enabled = true;
                SetupProperty();
            }
            else
            {
                conditionBox.Enabled = false;
                SetupProperty();
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
            ////MainForm*IGameDataAddedHist(a, GameData.Switches, MainForm.switchesEditor.addRemoveList, MainForm.switchesEditor, index));
            addRemoveList.AddNode(a);
            SetupProperty();
        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex >= 0 && GameData.Switches[addRemoveList.SelectedIndex] != null)
            {
                // History
                /////MainForm*IGameDataRemovedHist(GameData.Switches[addRemoveList.SelectedIndex], GameData.Switches, MainForm.switchesEditor.addRemoveList, MainForm.switchesEditor, addRemoveList.SelectedIndex));
                GameData.Switches.Remove(GameData.Switches[addRemoveList.SelectedIndex].ID);
                addRemoveList.RemoveSelectedNode();
                SetupProperty();
            }
        }

        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (SelectedCondition != null)
            {
                if (SelectedSwitch != null)
                    SelectedCondition.SwitchID = SelectedSwitch.ID;
                else
                    SelectedCondition.SwitchID = -1;
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
