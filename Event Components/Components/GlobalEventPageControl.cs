using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls.EventControls.EventDialogs;

namespace EGMGame.Controls.EventControls
{
    public partial class GlobalEventPageControl : UserControl
    {

        [Browsable(false)]
        public GlobalEventData SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; }
        }
        GlobalEventData selEvent;

        [Browsable(false)]
        public EventPageData SelectedEventPage
        {
            get { return selPage; }
            set { selPage = value; SetupPage(); }
        }
        EventPageData selPage;

        public GlobalEventPageControl()
        {
            InitializeComponent();
        }

        bool allowChange = true;

        private void SetupPage()
        {
            if (selPage != null)
            {
                allowChange = false;

                behaviorProgramListBox1.SelectedHistory = MainForm.GlobalEventHistory[MainForm.globalEventEditor];
                // ListBox
                behaviorProgramListBox1.SelectedEvent = SelectedEvent;
                behaviorProgramListBox1.SelectedPage = SelectedEventPage;
                // Activation Condition
                switchChk.Checked = SelectedEventPage.SwitchCondition;
                variablChk.Checked = SelectedEventPage.VariableCondition;
                // Trigger Condition
                autoRunChk.Checked = (SelectedEventPage.TriggerConditions == TriggerConditions.AutorunLoop);
                parellelProcessChk.Checked = (SelectedEventPage.TriggerConditions == TriggerConditions.BackgroundProcess);
                actionChk.Checked = (SelectedEventPage.TriggerConditions == TriggerConditions.ActionButton); ;
                allowChange = true;
            }
            else
            {
                allowChange = false;
                behaviorProgramListBox1.Clear();
                switchChk.Checked = false;
                variablChk.Checked = false;

                allowChange = true;
            }
        }

        internal void PagePropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (SelectedEventPage == data)
            {
                SetupPage();
            }
        }

        private void switchChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                MainForm.GlobalEventHistory[MainForm.globalEventEditor].Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            switchesBtn.Enabled = SelectedEventPage.SwitchCondition = switchChk.Checked;
        }

        private void switchesBtn_Click(object sender, EventArgs e)
        {
            SwitchesDialog dialog = new SwitchesDialog();
            dialog.SelectedPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                MainForm.GlobalEventHistory[MainForm.globalEventEditor].Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                // Remove Old data
                foreach (SwitchCondition data in SelectedEventPage.SwitchConditions)
                {
                    //// IReference key = (// IReference)Global.GetDataFromID(data.SwitchID, GameData.Switches);
                    //if (key != null)
                    //    key.RemoveReference(data);
                }
                // Condition
                SelectedEventPage.SwitchConditions = dialog.Conditions;
                // Add new data
                foreach (SwitchCondition data in SelectedEventPage.SwitchConditions)
                {
                    // IReference key = (// IReference)Global.GetDataFromID(data.SwitchID, GameData.Switches);
                    //if (key != null)
                    //    key.AddReference(data);
                }
            }
        }

        private void variablChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
                MainForm.GlobalEventHistory[MainForm.globalEventEditor].Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
            variablesBtn.Enabled = SelectedEventPage.VariableCondition = variablChk.Checked;
        }

        private void variablesBtn_Click(object sender, EventArgs e)
        {
            VariablesDialog dialog = new VariablesDialog();
            dialog.SelectedPage = SelectedEventPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                MainForm.GlobalEventHistory[MainForm.globalEventEditor].Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                // Remove Old data
                foreach (VariableCondition data in SelectedEventPage.VariableConditions)
                {
                    //// IReference key = (// IReference)Global.GetDataFromID(data.VariableID, GameData.Variables);
                    //if (key != null)
                    //    key.RemoveReference(data);
                }
                SelectedEventPage.VariableConditions = dialog.Conditions;
                // Add Old data
                foreach (VariableCondition data in SelectedEventPage.VariableConditions)
                {
                    // IReference key = (// IReference)Global.GetDataFromID(data.VariableID, GameData.Variables);
                    //if (key != null)
                    //    key.AddReference(data);
                }
            }
        }

        private void autoRunChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                MainForm.GlobalEventHistory[MainForm.globalEventEditor].Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                SelectedEventPage.TriggerConditions = TriggerConditions.AutorunLoop;
            }
        }

        private void parellelProcessChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                MainForm.GlobalEventHistory[MainForm.globalEventEditor].Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                SelectedEventPage.TriggerConditions = TriggerConditions.BackgroundProcess;
            }
        }

        private void actionChk_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                MainForm.GlobalEventHistory[MainForm.globalEventEditor].Do(new IGameDataChangePropertyHist(SelectedEventPage, new DataPropertyDelegate(PagePropertyChanged)));
                SelectedEventPage.TriggerConditions = TriggerConditions.ActionButton;
            }
        }
    }
}
