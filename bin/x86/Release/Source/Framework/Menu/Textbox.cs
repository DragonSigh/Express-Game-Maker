using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EGMGame.Library;
using EGMGame.Processors;

namespace EGMGame.Framework
{
    public class Textbox : MenuItem
    {
        #region Properties
        /// <summary>
        /// Gets or sets the list's options.
        /// </summary>
        public string Text
        {
            get { return Data.Text; }
            set { Data.Text = value; }
        }
        #endregion
    }
}
