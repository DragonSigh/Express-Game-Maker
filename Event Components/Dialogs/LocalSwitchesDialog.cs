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
    public partial class LocalSwitchesDialog : Form
    {

        public IEvent SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; }
        }
        IEvent selEvent;

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

        public List<LocalSwitchCondition> Conditions
        {
            get { return conditions; }
        }
        List<LocalSwitchCondition> conditions;

        public LocalSwitchCondition SelectedCondition
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
                    return SelectedEvent.Switches[addRemoveList.SelectedIndex];
                return null;
            }
        }

        public LocalSwitchesDialog()
        {
            InitializeComponent();
        }
        internal void Setup()
        {
            conditions = new List<LocalSwitchCondition>();
            foreach (LocalSwitchCondition c in selectedPage.LocalSwitchConditions)
            {
                LocalSwitchCondition nc = new LocalSwitchCondition();
                nc.ID = c.ID;
                nc.Name = c.Name;
                nc.State = c.State;
                nc.SwitchID = c.SwitchID;
                nc.OR = c.OR;
                conditions.Add(nc);
            }
            conditionsList.SetupList(conditions, typeof(LocalSwitchCondition));
            addRemoveList.SetupList(SelectedEvent.Switches, typeof(SwitchData));
        }
        /// <summary>
        /// Setup Property
        /// </summary>
        private void SetupProperty()
        {
            if (SelectedCondition != null)
            {
                switchesBox.Enabled = true;
                conditionBox.Enabled = (SelectedEvent.Switches.Count > 0);
                onBtn.Checked = SelectedCondition.State;
                offBtn.Checked = !SelectedCondition.State;
                addRemoveList.SelectedIndex = Global.GetIndex(SelectedCondition.SwitchID, SelectedEvent.Switches);
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
            LocalSwitchCondition c = new LocalSwitchCondition();
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
            a.Name = Global.GetName("Switch", SelectedEvent.Switches);
            a.ID = Global.GetID(SelectedEvent.Switches);
            a.Category = ca.Category;
            SelectedEvent.Switches.Add(a.ID, a);
            int index = SelectedEvent.Switches[a.ID].ID;
            // History
            //MainForm*IGameDataAddedHist(a, SelectedEvent.Switches, null, MainForm.eventEditor, index));
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
