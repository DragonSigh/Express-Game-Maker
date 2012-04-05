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

namespace EGMGame.Controls
{
    public partial class MenuEventDialog : Form
    {
        public List<EventProgramData> Programs
        {
            get { return menuBehaviorProgramListBox1.Programs; }
            set { menuBehaviorProgramListBox1.Programs = value; }
        }

        public MenuEventDialog()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuEventDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
