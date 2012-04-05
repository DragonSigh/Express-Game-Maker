//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    [Serializable]
    public class GlobalEventData : IGameData, IEvent
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
        /// The id
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
        /// Pages
        /// </summary>
        public List<EventPageData> Pages
        {
            get { return pages; }
            set { pages = value; }
        }
        List<EventPageData> pages = new List<EventPageData>();
        /// <summary>
        /// Local Variables
        /// </summary>
        public Dictionary<int, VariableData> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
        Dictionary<int, VariableData> variables = new Dictionary<int, VariableData>();
        /// <summary>
        /// Local Switches
        /// </summary>
        public Dictionary<int, SwitchData> Switches
        {
            get { return switches; }
            set { switches = value; }
        }
        Dictionary<int, SwitchData> switches = new Dictionary<int, SwitchData>();
        [ContentSerializerIgnore, DoNotSerialize]
        public int SelectedPage
        {
            get { return sp; }
            set { sp = value; }
        }
        int sp = -1;

        #region IEvent Members

        public int MapID
        {
            get
            {
                return -10;
            }
            set
            {
            }
        }

        #endregion
    }
}
