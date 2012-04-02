using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework.Input;

namespace EGMGame.Framework
{
    /// <summary>
    /// A button can have mouse based events. Check OnMouse... Events.
    /// </summary>
    public class Button : MenuItem
    {
        #region Delegates
        public delegate void OnMouseDownDelegate();
        public delegate void OnMouseUpDelegate();
        public delegate void OnMouseMoveDelegate();
        public delegate void OnMouseLeaveDelegate();
        public delegate void OnMouseEnterDelegate();
        public delegate void OnMouseHoverDelegate();
        #endregion

        #region Events
        public OnMouseDownDelegate OnMouseDown;
        public OnMouseUpDelegate OnMouseUp;
        public OnMouseMoveDelegate OnMouseMove;
        public OnMouseLeaveDelegate OnMouseLeave;
        public OnMouseEnterDelegate OnMouseEnter;
        public OnMouseHoverDelegate OnMouseHover;
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            if (IsMouseOn() && InputState.IsMouseDown())
            {
                if (OnMouseDown != null) OnMouseDown();
            }
            else if (IsMouseOn() && InputState.IsMouseUp())
            {
                if (OnMouseUp != null) OnMouseUp();
            }
            else if (IsMouseOn() && WasMouseOn() && InputState.IsMouseMove())
            {
                if (OnMouseMove != null) OnMouseMove();
            }
            else if (!IsMouseOn() && WasMouseOn() && InputState.IsMouseMove())
            {
                if (OnMouseLeave != null) OnMouseLeave();
            }
            else if (IsMouseOn() && !WasMouseOn() && InputState.IsMouseMove())
            {
                if (OnMouseEnter != null) OnMouseEnter();
            }
            else if (IsMouseOn() && WasMouseOn() && !InputState.IsMouseMove())
            {
                if (OnMouseHover != null) OnMouseHover();
            }
        }
        /// <summary>
        /// Checks if the mouse was on the menu part
        /// </summary>
        /// <returns></returns>
        private bool WasMouseOn()
        {
            return Data.Data.Bounds.Contains(InputState.LastMouseState.X, InputState.LastMouseState.Y);
        }
        /// <summary>
        /// Is Mouse On
        /// </summary>
        /// <returns></returns>
        private bool IsMouseOn()
        {
            return Data.Data.Bounds.Contains(Mouse.GetState().X, Mouse.GetState().Y);
        }
        #endregion
    }
}
