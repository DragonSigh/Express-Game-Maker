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
    public partial class ChangeHeroAnimationDialog : Form
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

        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }

        EventProgramData action;

        public int SelectedAnimation
        {
            get
            {
                return listBox.Data().ID;
            }
            set
            {
                listBox.Select(value);
            }
        }

        public int SelectedAction
        {
            get
            {
                return actionList.Data().ID;
            }
            set
            {
                actionList.Select(value);
            }
        }

        public bool HideActions
        {
            get { return !actionList.Visible; }
            set
            {
                if (value)
                {
                    actionList.Visible = false;
                    groupBox.Height = 319;
                }
                else
                {
                    actionList.Visible = true;
                    groupBox.Height = 288;
                }
            }
        }


        public ChangeHeroAnimationDialog()
        {
            InitializeComponent();

            directionsList.SelectedIndex = 0;
            cbActionType.SelectedIndex = 0;
            cbHero.Noneable = false;
            cbHero.RefreshList(true);
            // Load All Animations
            SetupList();
        }

        private void SetupList()
        {
            listBox.SetupList(GameData.Animations, typeof(AnimationData));
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Hero;
            action.Code = 10;
            //action.TypeCode = 1;
            action.Value[0] = new List<int>();
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

            cbHero.Select((int)action.Value[0]);
            cbActionType.SelectedIndex = (int)action.Value[1];
            listBox.Select((int)action.Value[2]);
            actionList.Select((int)action.Value[3]);
        }

        private void listBox_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (SelectedAnimation > -1)
            {
                actionList.RefreshList(true, listBox.Data<AnimationData>());
            }
            else
                actionList.Items.Clear();

            SetupAnimation();
        }
        /// <summary>
        /// Setup animation
        /// </summary>
        private void SetupAnimation()
        {
            if (actionList.Data().ID > -1 && actionList.Data().Directions[directionsList.SelectedIndex] != null)
            {
                foreach (AnimationFrame frame in actionList.Data().Directions[directionsList.SelectedIndex])
                {
                    animationViewer.SelectedAction = actionList.Data();
                    animationViewer.SelectedFrame = frame;
                    break;
                }
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
            if (cbHero.Data().ID > -10 && listBox.SelectedIndex > -1 && actionList.SelectedIndex > -1)
            {
                action.Value[0] = cbHero.Data().ID;
                action.Value[1] = cbActionType.SelectedIndex;
                action.Value[2] = listBox.Data().ID;
                action.Value[3] = actionList.Data().ID;
               
                action.GetName(selectedEvent, selectedPage);
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void directionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupAnimation();
        }

        private void ChangeAnimationDialog_Shown(object sender, EventArgs e)
        {
        }

    }
}
