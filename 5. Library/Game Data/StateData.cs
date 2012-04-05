//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    [Serializable]
    public class StateData : IGameData
    {
        /// <summary>
        /// Name
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

        public int Icon
        {
            get { return iconMaterialID; }
            set { iconMaterialID = value; }
        }
        int iconMaterialID = -1;

        public List<StateEffect> Effects
        {
            get
            {
                return itemEffect;
            }
            set { itemEffect = value; }
        }
        List<StateEffect> itemEffect = new List<StateEffect>();

        public List<int> Elements
        {
            get { return elements; }
            set { elements = value; }
        }
        List<int> elements = new List<int>();

        public List<int> InflictState
        {
            get { return inflictState; }
            set { inflictState = value; }
        }
        List<int> inflictState = new List<int>();

        public List<int> RemoveState
        {
            get { return removeState; }
            set { removeState = value; }
        }
        List<int> removeState = new List<int>();

        public StateSettings Settings
        {
            get { return settings; }
            set { settings = value; }
        }
        StateSettings settings = StateSettings.None;

        public int Frequency
        {
            get { return freq; }
            set { freq = value; }
        }
        int freq = 1;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        int duration;

        public TimeType TimeType
        {
            get { return timeType; }
            set { timeType = value; }
        }
        TimeType timeType = TimeType.Death;


        public int PropertyType
        {
            get { return propertyType; }
            set { propertyType = value; }
        }
        int propertyType;
    }

    [Serializable]
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
