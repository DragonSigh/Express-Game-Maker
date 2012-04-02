using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the font data.
    /// Includes font texture material id.
    /// </summary>
    [Serializable]
    public class FontData : IGameData
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

        public List<FontStyleData> Styles
        {
            get { return styles; }
            set { styles = value; }
        }
        private List<FontStyleData> styles = new List<FontStyleData>();

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
        /// To string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }

    [Serializable]
    public class FontStyleData : IGameData
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

        [Browsable(false)]
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;

        /// <summary>
        /// The font filename
        /// </summary>
        [Browsable(false)]
        public int MaterialID
        {
            get { return materialID; }
            set { materialID = value; }
        }
        int materialID = -1;

        public int LetterSpacing
        {
            get { return letterSpacing; }
            set { letterSpacing = value; }
        }
        int letterSpacing = 0;

        public int LineSpacing
        {
            get { return lineSpacing; }
            set { lineSpacing = value; }
        }
        int lineSpacing = 0;

        public override string ToString()
        {
            return name;
        }
    }
}
