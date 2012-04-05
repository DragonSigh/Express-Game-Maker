//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Docking.Database;

namespace EGMGame
{
    public partial class DatasetListDialog : Form
    {
        bool allowChange;
        internal List<int> curveList;

        public DatasetListDialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Abort;
        }

        internal void Setup(List<int> list)
        {
            curveList = new List<int>(list);

            chartPanel1.Setup(curveList);

            nudCount.Value = curveList.Count;
            nudIndex.Maximum = curveList.Count;
            if ((int)nudIndex.Value - 1 < curveList.Count && nudIndex.Value > 0)
                nudValue.Value = (decimal)curveList[(int)nudIndex.Value - 1];
            allowChange = true;

            if (nudCount.Value == 0)
            {
                nudCount.Value = 99;
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            CurveGenDialog dialog = new CurveGenDialog();
            dialog.Tag = this;
            dialog.curveList = new List<int>(curveList);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.Tag = null;
                curveList = dialog.curveList;
                chartPanel1.Setup(curveList);
                allowChange = false;
                if ((int)nudIndex.Value - 1  > - 1 && (int)nudIndex.Value - 1 < curveList.Count)
                    nudValue.Value = (decimal)curveList[(int)nudIndex.Value - 1];
                allowChange = true;
            }
            else
            {
                dialog.Tag = null;
                chartPanel1.Setup(curveList);
            }
            this.DialogResult = DialogResult.Abort;
        }

        private void nudCount_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;

            List<int> newList = new List<int>();

            for (int i = 0; i < nudCount.Value; i++)
            {
                if (i < curveList.Count)
                {
                    newList.Add(curveList[i]);
                }
                else
                {
                    newList.Add(0);
                }
            }

            curveList = newList;
            if (curveList.Count == 0)
                nudIndex.Value = 1;
            else if (nudIndex.Value > curveList.Count)
                nudIndex.Value = curveList.Count;
            nudIndex.Maximum = Math.Max(1, curveList.Count);
            nudIndex.Minimum = 1;
            chartPanel1.Setup(curveList);
        }

        private void nudIndex_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;
            allowChange = false;
            if ((int)nudIndex.Value - 1 < curveList.Count)
                nudValue.Value = (decimal)curveList[(int)nudIndex.Value - 1];
            allowChange = true;
        }

        private void nudValue_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;
            if ((int)nudIndex.Value - 1 < curveList.Count)
                curveList[(int)nudIndex.Value - 1] = (int)nudValue.Value;
            chartPanel1.Setup(curveList);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void SetupCurveList(List<int> list)
        {
            chartPanel1.Setup(list);
        }

        internal void SetIndex(int x)
        {
            nudIndex.Value = x + 1;
        }

        private void DatasetListDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Abort)
            {
                e.Cancel = true;
            }
        }
    }
}
