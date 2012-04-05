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

namespace EGMGame
{
    public partial class ItemEquipmentDialog : Form
    {
        public ItemEquipmentDialog()
        {
            InitializeComponent();

            cbItems.RefreshList(false);
            cbEquipments.RefreshList(false);
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
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void rbItems_CheckedChanged(object sender, EventArgs e)
        {
            cbItems.Enabled = rbItems.Checked;
        }

        private void rbEquipments_CheckedChanged(object sender, EventArgs e)
        {
            cbEquipments.Enabled = rbEquipments.Checked;
        }

    }
}
