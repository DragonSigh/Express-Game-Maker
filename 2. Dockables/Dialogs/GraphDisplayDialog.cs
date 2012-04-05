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

namespace EGMGame.Docking.Database
{
    public partial class GraphDisplayDialog : Form
    {
        internal List<int> curveList;
        internal DataProperty Dataset;

        public GraphDisplayDialog()
        {
            InitializeComponent();
        }

        internal void Setup(List<int> list)
        {
            curveList = new List<int>(list);

            chartPanel1.Setup(curveList);
        }

        private void chartPanel1_Click(object sender, EventArgs e)
        {
            DatasetListDialog dialog = new DatasetListDialog();
            dialog.Setup(curveList);
            dialog.Text = Dataset.Name;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                curveList = dialog.curveList;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void chartPanel1_MouseLeave(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chartPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
