//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using System.ComponentModel;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the global event data.
    /// Includes local variables and switches and pages.
    /// </summary>
    
    public class GlobalEventData : IGameData
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
        /// The id
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
        /// Pages
        /// </summary>
        public List<EventPageData> Pages;
        /// <summary>
        /// Local Variables
        /// </summary>
        public Dictionary<int, VariableData> Variables;
        /// <summary>
        /// Local Switches
        /// </summary>
        public Dictionary<int, SwitchData> Switches;
        [ContentSerializerIgnore, DoNotSerialize]
        public int SelectedPage;
        /// <summary>
        /// The map id
        /// </summary>        
        public int MapID;
    }
}
