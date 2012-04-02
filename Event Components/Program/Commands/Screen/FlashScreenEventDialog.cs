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
    public partial class FlashScreenEventDialog : Form
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

        public FlashScreenEventDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Screen;
            action.Code = 4;
            //action.TypeCode = 1;
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


            colorPickerCombobox1.SelectedItem = ConvertToSystemColor(action.Value[0]);
            nudFrames.Value = (decimal)(int)action.Value[1];
            nudFreq.Value = (decimal)(int)action.Value[2];
            waitBox.Checked = (bool)action.Value[3];
            chkGlobal.Checked = (bool)action.Value[4];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

            action.Value[0] = ConvertToXNAColor(colorPickerCombobox1.SelectedItem);
            action.Value[1] = (int)nudFrames.Value;
            action.Value[2] = (int)nudFreq.Value;
            action.Value[3] = waitBox.Checked;
            action.Value[4] = chkGlobal.Checked;

            Microsoft.Xna.Framework.Color color = ConvertToXNAColor(colorPickerCombobox1.SelectedItem);
           
            action.Name = "Flash Screen: (" + color.R.ToString() + ", " + color.G.ToString() + ", " + color.B.ToString() + ", " + color.A.ToString() + ") Frequency: " + nudFreq.Value.ToString() + " Seconds: " + nudFrames.Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
