using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.Game
{
    public partial class AnimationActionComboBox : ComboBox
    {
        public bool Noneable
        {
            get { return noneable; }
            set { noneable = value; }
        }
        bool noneable = false;

        AnimationData animation;
        List<AnimationAction> data = new List<AnimationAction>();
        /// <summary>
        /// Initialize
        /// </summary>
        public AnimationActionComboBox()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbActions.Add(this);
        }
        public AnimationActionComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Global.CbActions.Add(this);


            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            e.DrawBackground();
            if (e.Index > -1)
            {
                if (this.Enabled)
                {
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds);
                }
                else
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, System.Drawing.Brushes.Gray, e.Bounds);

                if (e.Index == this.SelectedIndex)
                {
                    e.DrawFocusRectangle();
                }
            }
        }
        /// <summary>
        /// Link to an animation list
        /// </summary>
        /// <param name="animationList"></param>
        public void LinkTo(AnimationComboBox animationList)
        {
            animationList.SelectedIndexChanged += new EventHandler(animationList_SelectedIndexChanged);
        }
        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(bool memorize, AnimationData a)
        {
            animation = a;
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            data.Clear();

            if (noneable)
            {
                AnimationAction action = new AnimationAction();
                action.ID = -1;
                action.Name = "(none)";
                data.Add(action);
                this.Items.Add(action.Name);
            }

            if (animation != null)
            {
                // Add All Items To list
                foreach (AnimationAction e in animation.Actions)
                {
                    this.Items.Add(e.Name);
                    data.Add(e);
                }
            }
            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }
        /// <summary>
        /// Get Selected Data
        /// </summary>
        /// <returns></returns>
        public AnimationAction Data()
        {
            if (this.SelectedIndex > -1)
                return data[this.SelectedIndex];
            else
            {
                AnimationAction dd = new AnimationAction();
                dd.ID = -10;
                dd.Name = "{No Action}";
                return dd;
            }
        }
        /// <summary>
        /// Animation List Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnimationComboBox list = (AnimationComboBox)sender;

            if (list.SelectedIndex > -1)
                RefreshList(false, GameData.Animations[list.SelectedIndex]);
            else
                RefreshList(false, null);
        }

        public void Select(int id)
        {
            int j = 0;
            bool found = false;
            foreach (AnimationAction e in data)
            {
                if (e.ID == id && j < this.Items.Count)
                {
                    this.SelectedIndex = j;
                    found = true;
                    break;
                }
                j++;
            }
            if (!found)
            {
                this.SelectedIndex = -1;
            }
        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            Global.CbActions.Remove(this);

            base.Dispose(disposing);
        }


        internal void Refresh(int p, AnimationData ani)
        {
            if (animation == ani)
            {
            }
        }

        internal void Refresh(int p)
        {
            RefreshList(false, animation);
            Select(p);
        }
    }
}
