//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    public partial class ConfirmRemoveDialog : Form
    {
        public ConfirmRemoveDialog()
        {
            InitializeComponent();
            this.Opacity = 0.1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                timer1.Stop();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Start();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
