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
    public partial class FlashFrameDialog : Form
    {
        AnimationFrame SelectedFrame;

        public FlashFrameDialog()
        {
            InitializeComponent();
        }

        internal void Setup(AnimationFrame selectedFrame)
        {
            SelectedFrame = selectedFrame;

            colorPickerCombobox1.SelectedItem = ConvertToSystemColor(selectedFrame.FlashColor);
            nudFrames.Value = (decimal)selectedFrame.FlashFrames;
            nudFreq.Value = (decimal)selectedFrame.FlashFreq;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedFrame));

            SelectedFrame.FlashColor = ConvertToXNAColor(colorPickerCombobox1.SelectedItem);
            SelectedFrame.FlashFrames = (int)nudFrames.Value;
            SelectedFrame.FlashFreq = (int)nudFreq.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Color ConvertToSystemColor(object p)
        {
            Microsoft.Xna.Framework.Color color = (Microsoft.Xna.Framework.Color)p;

            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
     
        private Microsoft.Xna.Framework.Color ConvertToXNAColor(Color p)
        {
            Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(p.R, p.G, p.B, p.A);

            return color;
        }
    }
}
