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

namespace EGMGame.Dialogs
{
    public partial class ShakeFrameDialog : Form
    {
        AnimationFrame SelectedFrame;

        public ShakeFrameDialog()
        {
            InitializeComponent();
        }

        internal void Setup(AnimationFrame selectedFrame)
        {
            SelectedFrame = selectedFrame;

            nudFreq.Value = selectedFrame.ShakeSpeed;
            nudPower.Value = SelectedFrame.ShakePower;
            nudFrames.Value = SelectedFrame.ShakeFrames;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedFrame));
               
            SelectedFrame.ShakeSpeed = (int)nudFreq.Value;
            SelectedFrame.ShakePower = (int)nudPower.Value;
            SelectedFrame.ShakeFrames = (int)nudFrames.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
