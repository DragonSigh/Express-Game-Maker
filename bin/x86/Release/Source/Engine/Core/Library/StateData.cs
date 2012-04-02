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
    /// Stores the item data.
    /// </summary>
    
    public class StateData : IGameData
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

        public int Icon;

        public List<StateEffect> Effects;

        public List<int> Elements;

        public List<int> InflictState;

        public List<int> RemoveState;

        public StateSettings Settings;

        public int Frequency;

        public int Duration;

        public TimeType TimeType;

        public int PropertyType;
    }

    public class StateEffect : ItemEffect
    {
    }


    public enum StateSettings
    {
        None,
        CanNotUsemagic,
        CanNotUseskill,
        CanNotMove,
        AlwaysAttackAlly,
        Death,
        ParameterChange,
        CanNotUseItem
    }

    public enum TimeType
    {
        SecondsOrTurns,
        Death,
        TillNegated
    }
}
