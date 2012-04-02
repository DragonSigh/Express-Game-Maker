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
    /// Stores all the necessary variable data.
    /// Including the integer value of the variable.
    /// </summary>
    
    public class StringData : IGameData
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the variable.
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
        /// Gets or sets the integer value of the variabe.
        /// </summary>
        public string Value;
        /// <summary>
        /// Returns the name of the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
}
