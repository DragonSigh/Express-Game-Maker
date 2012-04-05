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
using System.Threading;

namespace EGMGame
{
    public partial class EventSettingsDialog : Form
    {
        public EventData SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; Setup(); }
        }
        EventData selEvent;

        bool allowChange = true;
        bool modified = false;

        public EventSettingsDialog()
        {
            InitializeComponent();
        }

        internal void Setup()
        {
            if (selEvent == null)
            {
                this.Hide(); return;
            }
            allowChange = false;
            this.Text = "Event Settings: " + selEvent.Name + " (" + selEvent.ID + ")";
            rotateBox.Value = (decimal)selEvent.Rotation;
            allowChange = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        private void rotateBox_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                if (rotate == -1)
                    rotate = selEvent.Rotation;
                selEvent.Rotation = (int)rotateBox.Value;
            }
        }

        float rotate = -1;
        private void rotateBox_Validated(object sender, EventArgs e)
        {
            if (rotate > -1 && selEvent.Rotation != rotate)
            {
                float newRotate = selEvent.Rotation;
                selEvent.Rotation = (int)rotate;
                //MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selEvent));
                selEvent.Rotation = (int)newRotate;
                rotate = -1;
            }
        }

        private void TileSettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
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
            while (this.Opacity > .1 && !isActive)
            {
                Thread.Sleep(2);
                DropOpacityCallBack cb = new DropOpacityCallBack(DeFocusOpaity);
                this.Invoke(cb);
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

    }
}
