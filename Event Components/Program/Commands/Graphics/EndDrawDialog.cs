using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using Microsoft.Xna.Framework;

namespace EGMGame.EventControls.EventDialogs.CommandDialogs.DrawingDialogs
{
    public partial class EndDrawDialog : Form
    {
        #region Constructor
        public EndDrawDialog()
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
            action.ProgramCategory = ProgramCategory.Graphics;
            action.Code = 1;


        }

        private void SetupAction(EventProgramData a)
        {


            action = new EventProgramData();
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;


        }
        #endregion        

    }
}
