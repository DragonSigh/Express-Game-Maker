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
    /// Stores all the necessary switch data.
    /// Including the integer sate of the switch.
    /// </summary>
    
    public class SwitchData : IGameData
    {
        /// <summary>
        /// Name of the switch.
        /// </summary>
        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the switch.
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
        /// Switch's state. TRUE = ON/FALSE = OFF.
        /// </summary>
        public bool State;

    }
    /// <summary>
    /// Stores the conditions a switch can be compared to.
    /// </summary>
    
    public class SwitchCondition : IGameData 
    {
        /// <summary>
        /// Name
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
        /// Gets or sets the ID of the switch being compared.
        /// </summary>
        public int SwitchID;
        /// <summary>
        /// Gets or sets the state which the switch will be compared to.
        /// </summary>
        public bool State;
        
        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR;
    }
    /// <summary>
    /// Stores the local conditions a switch can be compared to.
    /// </summary>
    
    public class LocalSwitchCondition : IGameData
    {
        /// <summary>
        /// Name
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
        /// Gets or sets the ID of the switch being compared.
        /// </summary>
        public int SwitchID;
        /// <summary>
        /// Gets or sets the state which the switch will be compared to.
        /// </summary>
        public bool State;

        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR;
    }
}
