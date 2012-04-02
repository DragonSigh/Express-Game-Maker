using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EGMGame.Library;
using EGMGame.Processors;

namespace EGMGame.Framework
{
    public class Option : MenuItem
    {
        #region Properties
        /// <summary>
        /// Gets or sets the list's options.
        /// </summary>
        public List<string> Options
        {
            get { return _options; }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    ((ListStatic)Data.Data).Options.Add(new ListItem() { Text = value[i], Font = Font.ID, Style = Style.ID, TextColor = Color });
                }
                _options = value;
            }
        }
        List<string> _options;
        #endregion


    }
}
