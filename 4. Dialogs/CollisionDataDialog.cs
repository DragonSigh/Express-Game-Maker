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
using GenericUndoRedo;
using EGMGame.Docking.Editors;
using EGMGame.GameLibrary;
using System.Threading;

namespace EGMGame.Controls.EventControls
{
    public partial class CollisionDataDialog : Form
    {
        CollisionData Data;
        DataPropertyDelegate Delegate;
        UndoRedoHistory<IHistory> SelectedHistory;
        bool allowChange = true;
        public CollisionDataDialog()
        {
            InitializeComponent();
        }

        public void Setup(CollisionData data)
        {
            allowChange = false;
            Data = data;

            nudFriction.Value = (decimal)data.Friction;
            nudBounce.Value = (decimal)data.Bounce;
            nudMass.Value = (decimal)data.Mass;
            chkIsPlatform.Checked = data.IsPlatform;
            allowChange = true;
        }

        private void nudMass_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            Data.Mass = (float)nudMass.Value;
        }

        private void nudFriction_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            Data.Friction = (float)nudFriction.Value;
        }
        private void chkIsPlatform_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            Data.IsPlatform = chkIsPlatform.Checked;
        }

        private void nudBounce_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            Data.Bounce = (float)nudBounce.Value;
        }

        private void CollisionDataDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
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
