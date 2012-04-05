//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame
{
    public partial class MapResizeDialog : Form
    {
        public MapResizeDialog()
        {
            InitializeComponent();
            if (rbTiles.Checked)
            {
                widthBox.Minimum = 1;
                heightBox.Minimum = 1;
                widthBox.Value = Math.Min((decimal)MainForm.SelectedMap.Size.X / (decimal)MainForm.SelectedMap.Grid.X, widthBox.Maximum);
                heightBox.Value = Math.Min((decimal)MainForm.SelectedMap.Size.Y / (decimal)MainForm.SelectedMap.Grid.Y, heightBox.Maximum);
            }
            else
            {
                widthBox.Minimum = (decimal)MainForm.SelectedMap.Grid.X;
                heightBox.Minimum = (decimal)MainForm.SelectedMap.Grid.Y;
                widthBox.Value = (decimal)MainForm.SelectedMap.Size.X;
                heightBox.Value = (decimal)MainForm.SelectedMap.Size.Y;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (rbTiles.Checked)
            {
                decimal width = widthBox.Value;
                decimal height = heightBox.Value;
                widthBox.Minimum = (decimal)MainForm.SelectedMap.Grid.X;
                heightBox.Minimum = (decimal)MainForm.SelectedMap.Grid.Y;
                widthBox.Value = Math.Min(width * (decimal)MainForm.SelectedMap.Grid.X, widthBox.Maximum);
                heightBox.Value = Math.Min(height * (decimal)MainForm.SelectedMap.Grid.Y, heightBox.Maximum);
            }
            MainForm.NeedSave = true;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbTiles_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTiles.Checked)
            {
                widthBox.Minimum = 1;
                heightBox.Minimum = 1;
                widthBox.Value = Math.Min(widthBox.Value / (decimal)MainForm.SelectedMap.Grid.X, widthBox.Maximum);
                heightBox.Value = Math.Min(heightBox.Value / (decimal)MainForm.SelectedMap.Grid.Y, heightBox.Maximum);
            }
        }

        private void rbPixels_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPixels.Checked)
            {
                decimal width = widthBox.Value;
                decimal height = heightBox.Value;
                widthBox.Minimum = (decimal)MainForm.SelectedMap.Grid.X;
                heightBox.Minimum = (decimal)MainForm.SelectedMap.Grid.Y;
                widthBox.Value = Math.Min(width * (decimal)MainForm.SelectedMap.Grid.X, widthBox.Maximum);
                heightBox.Value = Math.Min(height * (decimal)MainForm.SelectedMap.Grid.Y, heightBox.Maximum);
            }
        }
    }
}
