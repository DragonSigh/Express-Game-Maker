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
    
    public class ItemData : IGameData
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

        public string Description;

        public int Icon;

        public int Price;

        public List<ItemEffect> Effects;

        public UsageType Usage;

        public bool Consumable;

        public int Speed;

        public int SucessRate;

        public bool IgnoreDefense;

        public bool AbsorbeDamage;

        public List<int> UsableBy;

        public List<int> Elements;

        public List<int> InflictState;

        public List<int> RemoveState;
        
        public Dictionary<int, int> HeroActions;

        public ItemScope Scope;

        public int Range;

        public bool MustFaceTarget;

        public int PropertyType;

        public bool EnableCondition;

        public EventProgramData Condition;

    }

    
    public class ItemEffect : IGameData
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

        public EffectScope Scope;

        public int GlobalEvent;

        public int Value;

        public ItemValueType ValueType;

        public int Property;

        public int Animation;

        public int Action;

        public int Particle;
    }

    public enum ItemScope
    {
        User,
        OneHero,
        AllAllies,
        OneEnemy,
        AllEnemies,
        OneAllyDead,
        AllPartyDead,
        None
    }

    public enum EffectScope
    {
        User,
        Target
    }

    public enum ItemValueType
    {
        Constant,
        Percentage,
        Damage
    }

    public enum UsageType
    {
        Anytime,
        Battle,
        Menu,
        Never
    }

}
