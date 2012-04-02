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
    public partial class DBConditionsDialog : Form
    {

        bool btnBattlerPropIndex = true;
        public DBConditionsDialog()
        {
            InitializeComponent();
            cbBattlerProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            cbValueProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            cbBattlerOp.SelectedIndex = 0;
            cbValue.SelectedIndex = 0;

        }

        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; if (action == null) Setup(); }
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
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
        }

        private void SetupAction(EventProgramData a)
        {
            Setup();
            if (a == null) return;
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            btnBattlerPropIndex = (bool)action.Value[0];
            Setup(btnBattlerPropIndex);

            cbBattlerProp.Select((int)action.Value[1]);
            cbBattlerOp.SelectedIndex = (int)action.Value[2];
            cbValue.SelectedIndex = (int)action.Value[3];
            if ((int)action.Value[3] == 0)
            {
                cbBattlerNud.Value = (decimal)(int)action.Value[4];
            }
            else
            {
                cbValueProp.Select((int)action.Value[4]);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = btnBattlerPropIndex;
            action.Value[1] = cbBattlerProp.Data().ID;
            action.Value[2] = cbBattlerOp.SelectedIndex;
            action.Value[3] = cbValue.SelectedIndex;
            if ((int)action.Value[3] == 0)
            {
                action.Value[4] = (int)cbBattlerNud.Value;
            }
            else
            {
                action.Value[4] = cbValueProp.Data().ID;
            }

            this.DialogResult = DialogResult.OK;
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

        private void btnChangeBattlerProp_Click(object sender, EventArgs e)
        {
            if (btnBattlerPropIndex)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                btnBattlerPropIndex = false;

                cbBattlerProp.RefreshList(GameData.Databases[1], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                btnBattlerPropIndex = true;

                cbBattlerProp.RefreshList(GameData.Databases[0], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            }
        }

        private void Setup(bool btnBattlerPropIndex)
        {
            if (!btnBattlerPropIndex)
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.enemy;
                btnBattlerPropIndex = false;

                cbBattlerProp.RefreshList(GameData.Databases[1], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[1], false, DataType.Number);
            }
            else
            {
                btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
                btnBattlerPropIndex = true;

                cbBattlerProp.RefreshList(GameData.Databases[0], false, DataType.Number);
                cbValueProp.RefreshList(GameData.Databases[0], false, DataType.Number);
            }
        }
        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConstant.Visible = (cbValue.SelectedIndex == 0);
            panelProperty.Visible = (cbValue.SelectedIndex == 1);
        }

    }
}
