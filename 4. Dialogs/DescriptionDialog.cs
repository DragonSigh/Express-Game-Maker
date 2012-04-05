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
    public partial class DescriptionDialog : Form
    {
        public string Description;

        public DescriptionDialog()
        {
            InitializeComponent();
            messageEditor1.Repopulate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Description = messageEditor1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void DescriptionDialog_Shown(object sender, EventArgs e)
        {
            messageEditor1.Text = Description;
        }
    }
}
