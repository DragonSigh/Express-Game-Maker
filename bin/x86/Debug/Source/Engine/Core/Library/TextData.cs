//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the text data.
    /// Includes text and multi-language.
    /// </summary>
    
    public class TextData : IGameData
    {
        /// <summary>
        /// Name of the data
        /// </summary>
        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        /// <summary>
        /// The category the data is in. Usage is optional.
        /// </summary>
        
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// Determines the space between each line.
        /// </summary>
        public int LineSpacing;
        /// <summary>
        /// Determines the space between each space.
        /// </summary>
        public int LetterSpacing;
        /// <summary>
        /// Gets or sets the fonts id from the given name. Gets the name of the font.
        /// </summary>
        public string FontName
        {
            get 
            {
                if (GameData.Fonts.GetData(FontID) != null)
                    return GameData.Fonts.GetData(FontID).Name;
                FontID = 0;
                return "";
            }
        }
        /// <summary>
        /// Gets or sets the font's ID.
        /// </summary>
        public int FontID;
        /// <summary>
        /// The text stored. INDEX is the language index provided from settings.
        /// </summary>
        public List<string> Text;
    }
}
