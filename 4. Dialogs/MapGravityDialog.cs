//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace EGMGame.Dialogs
{
    public partial class MapGravityDialog : Form
    {
        public MapGravityDialog()
        {
            InitializeComponent();
            nudGravityX.Value = (decimal)MainForm.SelectedMap.Gravity.X;
            nudGravityY.Value = (decimal)MainForm.SelectedMap.Gravity.Y;
            chGravity.Checked = MainForm.SelectedMap.CustomGravity;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            MainForm.SelectedMap.Gravity = new Vector2((float)nudGravityX.Value, (float)nudGravityY.Value);
            MainForm.SelectedMap.CustomGravity = chGravity.Checked;

            MainForm.NeedSave = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chGravity_CheckedChanged(object sender, EventArgs e)
        {
            nudGravityX.Enabled = nudGravityY.Enabled = chGravity.Checked;
        }
    }
}
