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

namespace EGMGame
{
    public partial class EditFogDialog : Form
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

        public EditFogDialog()
        {
            InitializeComponent();
            materialsBox.RefreshList(false, MaterialDataType.Image);
            colorBox.AllowOpacity = true;
        }

        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            if (Programs != null)
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Map;
            action.Code = 3;
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

            materialsBox.Select((int)action.Value[0]);
            colorBox.SelectedItem = ConvertToSystemColor(action.Value[1]);
            nudSpeed.Value = (decimal)(int)action.Value[2];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = materialsBox.Data().ID;
            action.Value[1] = ConvertToXNAColor(colorBox.SelectedItem);
            action.Value[2] = (int)nudSpeed.Value;
            action.GetName(selectedEvent, selectedPage);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Convert To System Color
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Color ConvertToSystemColor(object p)
        {
            Microsoft.Xna.Framework.Color color = (Microsoft.Xna.Framework.Color)p;

            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
        private Microsoft.Xna.Framework.Color ConvertToXNAColor(Color p)
        {
            Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(p.R, p.G, p.B, p.A);

            return color;
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
