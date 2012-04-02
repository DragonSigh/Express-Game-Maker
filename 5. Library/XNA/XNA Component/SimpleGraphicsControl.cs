using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Controls.XNA;

namespace EGMGame.Controls
{
    public class SimpleGraphicsControl : GraphicsDeviceControl
    {
        public event EventHandler OnDraw;
        public event EventHandler OnInitialize;

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            if (OnInitialize != null)
                OnInitialize(this, null);
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            if (OnDraw != null)
                OnDraw(this, null);
        }
    }
}
