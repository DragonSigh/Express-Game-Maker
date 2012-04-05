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
    public partial class ErrorDisplayDialog : Form
    {
        string UserMessage;
        public ErrorDisplayDialog()
        {
            InitializeComponent();
        }

        public ErrorDisplayDialog(string code, string message)
        {
            InitializeComponent();

            lblCode.Text = code;
            txtMessage.Text = message;
        }

        public static string Show(string code, string message)
        {
            ErrorDisplayDialog dialog = new ErrorDisplayDialog(code, message);
            dialog.ShowDialog();
            return dialog.UserMessage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UserMessage = txtOther.Text;
            this.Close();
        }
    }
}
