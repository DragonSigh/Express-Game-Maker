using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls
{
    public partial class ProgramOverviewDialog : Form
    {
        public ProgramOverviewDialog()
        {
            InitializeComponent();
        }

        internal void Setup(EventProgramData a)
        {
            if (a.Code == 10 && a.Category == 0)
            {
                // Program Dynamics
                list.Items.Clear();
                List<EventProgramData> programs =  (List<EventProgramData>)a.Value[4];
                foreach (EventProgramData data in programs)
                {
                    list.Items.Add(data.Name);
                }
                
                //list.SelectedIndex = -1;
            }
        }

        private void list_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void list_MouseLeave(object sender, EventArgs e)
        {
            list_Leave(null, null);
        }
    }
}
