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
    [Serializable]
    public class TextData : IGameData
    {
        /// <summary>
        /// Name of the data
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        [Browsable(false)]
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        /// <summary>
        /// The category the data is in. Usage is optional.
        /// </summary>
        [Browsable(false)]
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// Determines the space between each line.
        /// </summary>
        public int LineSpacing
        {
            get { return lineSpacing; }
            set { lineSpacing = value; }
        }
        int lineSpacing;
        /// <summary>
        /// Determines the space between each space.
        /// </summary>
        public int LetterSpacing
        {
            get { return letterSpacing; }
            set { letterSpacing = value; }
        }
        int letterSpacing;
        /// <summary>
        /// Gets or sets the fonts id from the given name. Gets the name of the font.
        /// </summary>
        public string FontName
        {
            get 
            {
                if (Global.GetData<FontData>(fontID, GameData.Fonts) != null)
                    return Global.GetData<FontData>(fontID, GameData.Fonts).Name;
                fontID = 0;
                return "";
            }
        }
        /// <summary>
        /// Gets or sets the font's ID.
        /// </summary>
        public int FontID
        {
            get { return fontID; }
            set { fontID = value; }
        }
        int fontID=0;
        /// <summary>
        /// The text stored.
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text = "";
    }
}
