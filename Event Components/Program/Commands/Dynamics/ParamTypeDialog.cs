//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class ParamTypeDialog : Form
    {
        public int index;
        public ParamTypeDialog()
        {
            InitializeComponent();

            cbType.SelectedIndex = 0;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            index = cbType.SelectedIndex;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
