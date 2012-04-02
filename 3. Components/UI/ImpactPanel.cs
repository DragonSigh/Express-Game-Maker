using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Controls.ImpactUI
{
    class ImpactPanel : Panel
    {
        public ImpactPanel() : base()
        {
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ContainerControl |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
        }
    }
}
