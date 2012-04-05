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
    public partial class CategoryDialog : Form
    {

        public int SelectedIndex
        {
            get { return cbCategories.SelectedIndex; }
        }
        public CategoryDialog()
        {
            InitializeComponent();

        }

        public void RefreshAudio()
        {
            cbCategories.Items.Clear();

            foreach (NodeCategory cat in Global.Project.Categories[typeof(AudioData).ToString()])
            {
                cbCategories.Items.Add(cat.Name);
            }

            cbCategories.SelectedIndex = 0;
        }

        public void RefreshFonts()
        {
            cbCategories.Items.Clear();

            foreach (NodeCategory cat in Global.Project.Categories[typeof(FontData).ToString()])
            {
                cbCategories.Items.Add(cat.Name);
            }

            cbCategories.SelectedIndex = 0;
        }

        internal void RefreshAni()
        {
            cbCategories.Items.Clear();

            foreach (NodeCategory cat in Global.Project.Categories[typeof(AnimationData).ToString()])
            {
                cbCategories.Items.Add(cat.Name);
            }

            cbCategories.SelectedIndex = 0;
        }
        internal void RefreshTileset()
        {
            cbCategories.Items.Clear();

            foreach (NodeCategory cat in Global.Project.Categories[typeof(TilesetData).ToString()])
            {
                cbCategories.Items.Add(cat.Name);
            }

            cbCategories.SelectedIndex = 0;
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


        public bool AddPhysics { get { return chkAddLayoutCollision.Checked; } }

        internal void Physics()
        {
            chkAddLayoutCollision.Visible = true;
        }
    }
}
