using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Dialogs
{
    public partial class ChooseMemberDialog : Form
    {
        public ChooseMemberDialog()
        {
            InitializeComponent();

            cnHeros.RefreshList(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cnHeros.Data().ID > -1)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
