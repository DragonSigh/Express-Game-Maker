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
using Microsoft.Xna.Framework;
using System.Threading;

namespace EGMGame
{
    public partial class LayerSettingsDialog : Form
    {
        LayerData layer;

        bool allowChange = true;
        public LayerSettingsDialog()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        internal void Setup(LayerData l)
        {
            allowChange = false;
            layer = l;
            //speedX.Value = (decimal)l.MoveSpeed.X;
            //speedY.Value = (decimal)l.MoveSpeed.Y;
            //// Tints
            //redBox.Value = (decimal)l.Tint.Red;
            //blueBox.Value = (decimal)l.Tint.Blue;
            //greenBox.Value = (decimal)l.Tint.Green;
            //alphaBox.Value = (decimal)l.Tint.Alpha;
            cbTint.SelectedItem = System.Drawing.Color.FromArgb(l.Tint.Alpha, l.Tint.Red, l.Tint.Blue, l.Tint.Green);
            allowChange = true;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            // Apply changes
            //layer.MoveSpeed = new Vector2((float)speedX.Value, (float)speedY.Value);
            layer.Tint = new ColorRGBA(cbTint.SelectedItem.R, cbTint.SelectedItem.G, cbTint.SelectedItem.B, cbTint.SelectedItem.A);
            // Close
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void redBox_ValueChanged(object sender, EventArgs e)
        {
            //if (allowChange)
            //    layer.Tint = new ColorRGBA(redBox.Value, greenBox.Value, blueBox.Value, alphaBox.Value);
        }

        #region Mouse Focus/Defocus Effect
        delegate void DropOpacityCallBack();
        bool isActive = true;

        protected override void OnActivated(EventArgs e)
        {
            this.Opacity = (double)1.0;
            isActive = true;
        }
        protected override void OnDeactivate(EventArgs e)
        {
            Thread thread = new Thread(DropOpacity);
            thread.Start();
            isActive = false;
        }
        private void DropOpacity()
        {
            while (this.Opacity > 0.3 && !isActive)
            {
                Thread.Sleep(1);
                DropOpacityCallBack cb = new DropOpacityCallBack(DeFocusOpaity);
                try
                {
                    if (this.Created)
                        this.Invoke(cb);
                }
                catch { }
            }
        }
        private void DeFocusOpaity()
        {
            this.Opacity -= 0.01;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.Activate();
        }
        #endregion

        private void LayerSettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void speedX_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
