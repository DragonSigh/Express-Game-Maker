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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs
{
    public partial class ChangeParameterDialog : Form
    {
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

        public ChangeParameterDialog()
        {
            InitializeComponent();

            cbHero.RefreshList(false);
            cbProperty.RefreshPlayerList(GameData.Databases[0], false);
            cbOpType.SelectedIndex = 0;
            cbValue.SelectedIndex = 0;

            variablesList.RefreshList(false);
            if (selectedEvent != null)
                localVariableList.RefreshList(selectedEvent, false);

        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Hero;
            action.Code = 7;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            cbHero.Select((int)action.Value[0]);
            cbProperty.Select((int)action.Value[1]);
            cbOpType.SelectedIndex = (int)action.Value[2];
            cbValue.SelectedIndex = (int)action.Value[3];

            switch ((int)action.Value[3])
            {
                case 0:
                    constantBox.Value = (decimal)(int)action.Value[4];
                    break;
                case 1:
                    rand1Num.Value = (decimal)(int)action.Value[4];
                    rand2Num.Value = (decimal)(int)action.Value[5];
                    break;
                case 2:
                    variablesList.Select((int)action.Value[4]);
                    break;
                case 3:
                    localVariableList.Select((int)action.Value[4]);
                    break;
            }
            chkDisplayDamage.Checked = (bool)action.Value[6];

        }
        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelConst.Visible = false;
            panelRand.Visible = false;
            panelVariable.Visible = false;
            panelLocalVar.Visible = false;
            switch (cbValue.SelectedIndex)
            {
                case 0:
                    panelConst.Enabled = panelConst.Visible = true;
                    break;
                case 1:
                    panelRand.Enabled = panelRand.Visible = true;
                    break;
                case 2:
                    panelVariable.Visible = true;
                    panelVariable.Enabled = true;
                    break;
                case 3:
                    panelLocalVar.Enabled = panelLocalVar.Visible = true;
                    break;
            }

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            if (cbHero.Data().ID > -1)
            {
                action.Value[0] = cbHero.Data().ID;
                action.Value[1] = cbProperty.Data().ID;
                action.Value[2] = cbOpType.SelectedIndex;
                action.Value[3] = cbValue.SelectedIndex;
                action.Value[6] = chkDisplayDamage.Checked;

                switch ((int)action.Value[3])
                {
                    case 0:
                        action.Value[4] = (int)constantBox.Value;
                        break;
                    case 1:
                        action.Value[4] = (int)rand1Num.Value;
                        action.Value[5] = (int)rand2Num.Value;
                        break;
                    case 2:
                        action.Value[4] = variablesList.Data().ID;
                        break;
                    case 3:
                        action.Value[4] = localVariableList.Data().ID;
                        break;
                }
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
    }
}
