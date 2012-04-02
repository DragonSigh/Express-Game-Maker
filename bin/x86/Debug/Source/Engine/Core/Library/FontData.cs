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
    /// Stores the font data.
    /// Includes font texture material id.
    /// </summary>
    
    public class FontData : IGameData
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

        public List<FontStyleData> Styles;

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
        /// To string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }

    
    public class FontStyleData : IGameData
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
               
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// The font filename
        /// </summary>
        public int MaterialID;

        public int LetterSpacing;

        public int LineSpacing;

        public override string ToString()
        {
            return name;
        }
    }
}
