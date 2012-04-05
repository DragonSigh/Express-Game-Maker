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
    public partial class CollisionParameterConfirmDialog : Form
    {
        public CollisionParameterConfirmDialog()
        {
            InitializeComponent();
        }

        internal void Setup(int x, int y, int width, int height)
        {
            nudX.Value = Math.Abs(x);
            nudy.Value = Math.Abs(y);
            nudWidth.Value = Math.Abs(width);
            nudHeight.Value = Math.Abs(height);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
