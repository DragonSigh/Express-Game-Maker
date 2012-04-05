//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Controls
{
    public partial class FlowPanel : Panel
    {
        public FlowPanel()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer, true);
        }
        [DisplayName("Spacing Horizantal"), Category("Behavior"), Description("Spacign between controls.")]
        public int SpacingHorizantal
        {
            get { return spacingh; }
            set { spacingh = value; RefreshContentLayout(); }
        }
        int spacingh = 15;
        [DisplayName("Spacing Vertial"), Category("Behavior"), Description("Spacign between controls.")]
        public int SpacingVertical
        {
            get { return spacingv; }
            set { spacingv = value; RefreshContentLayout(); }
        }
        int spacingv = 10;

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            // RefreshLayout
            RefreshContentLayout();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            // RefreshLayout
            RefreshContentLayout();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            // RefreshLayout
            RefreshContentLayout();
        }
        /// <summary>
        /// Refresh the content layout
        /// </summary>
        private void RefreshContentLayout()
        {
            if (this.Controls.Count > 0)
            {
                int controlHeight = this.Height - (this.SpacingVertical * 2);
                int controlWidth = this.Size.Width / Controls.Count - this.SpacingHorizantal;
                int x = this.SpacingHorizantal;
                int y = this.SpacingVertical;

                foreach (Control control in Controls)
                {
                    control.Width = controlWidth;
                    control.Height = controlHeight;
                    control.Location = new System.Drawing.Point(x, y);
                    x += this.SpacingHorizantal + controlWidth;
                }
            }
        }
    }
}
