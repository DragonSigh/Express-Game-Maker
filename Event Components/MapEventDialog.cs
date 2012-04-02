using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.EventControls
{
    public partial class MapEventDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value; 
                eventEditorControl.Enabled = true;
                eventEditorControl.SelectedEvent = (EventData)value;
                if (value != null)
                    this.Text = value.Name + " ID: " + value.ID.ToString();
            }
        }
        IEvent selectedEvent;

        public MapEventDialog()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (e.Graphics != null)
                e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        internal void ShowDialog(EGMGame.Controls.MapViewer mapViewer, IEvent selectedEvent)
        {
            
        }

        private void MapEventDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void MapEventDialog_Shown(object sender, EventArgs e)
        {
            eventEditorControl.RefreshList();
        }

        private void MapEventDialog_Load(object sender, EventArgs e)
        {
            eventEditorControl.RefreshList();
        }

        private void MapEventDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void eventEditorControl_Load(object sender, EventArgs e)
        {

        }

        internal void RefreshActivePage()
        {
            eventEditorControl.RefreshPage();
        }
    }
}
