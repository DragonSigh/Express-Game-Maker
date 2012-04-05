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

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class AnimationListDialog : Form
    {


        public int Direction { get { return directionsList.SelectedIndex; } set { directionsList.SelectedIndex = value; } }

        public int SelectedAnimation
        {
            get
            {
                return aniList.Data().ID;
            }
            set
            {
                aniList.TrySelect(value);
            }
        }

        public int SelectedAction
        {
            get
            {
                return actionList.Data().ID;
            }
            set
            {
                actionList.Select(value);
            }
        }

        public bool HideActions
        {
            get { return !actionList.Visible; }
            set
            {
                if (value)
                {
                    actionList.Visible = false;
                    groupBox.Height = 319;
                }
                else
                {
                    actionList.Visible = true;
                    groupBox.Height = 288;
                }
            }
        }

        public AnimationData Animation
        {
            get 
            {
                return aniList.Data<AnimationData>();
            }
        }

        public AnimationListDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Setup List
        /// </summary>
        private void SetupList()
        {
            aniList.SetupList(GameData.Animations, typeof(AnimationData));
        }


        private void aniList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            actionList.Items.Clear();
            if (Animation.ID > -1)
                actionList.RefreshList(true, Animation);

            SetupAnimation();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Setup animation
        /// </summary>
        private void SetupAnimation()
        {
            if (actionList.Data().ID > -1 && actionList.Data().Directions[directionsList.SelectedIndex] != null)
            {
                foreach (AnimationFrame frame in actionList.Data().Directions[directionsList.SelectedIndex])
                {
                    animationViewer.SelectedAction = actionList.Data();
                    animationViewer.SelectedFrame = frame;
                    return;
                }
            }
            animationViewer.SelectedAction = null;
            animationViewer.SelectedFrame = null;
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void directionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupAnimation();
        }

        public int _animation, _action;
        private void AnimationListDialog_Shown(object sender, EventArgs e)
        {
            directionsList.SelectedIndex = 0;
            // Load All Animations
            SetupList();

            SelectedAnimation = _animation;
            SelectedAction = _action;
        }
    }
}
