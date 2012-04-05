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
    public class ItemData : IGameData
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

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;

        public int Icon
        {
            get { return iconMaterialID; }
            set { iconMaterialID = value; }
        }
        int iconMaterialID = -1;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        int price = 0;

        public List<ItemEffect> Effects
        {
            get
            {
                return itemEffect;
            }
            set { itemEffect = value; }
        }
        List<ItemEffect> itemEffect = new List<ItemEffect>();

        public UsageType Usage
        {
            get
            {
                return usage;
            }
            set { usage = value; }
        }
        UsageType usage = UsageType.Anytime;

        public bool Consumable
        {
            get { return consumable; }
            set { consumable = value; }
        }
        bool consumable = false;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        int speed = 0;

        public int SucessRate
        {
            get { return sucessRate; }
            set { sucessRate = value; }
        }
        int sucessRate = 100;

        public bool IgnoreDefense
        {
            get { return ignoreDefense; }
            set { ignoreDefense = value; }
        }
        bool ignoreDefense = false;

        public bool AbsorbeDamage
        {
            get { return absorbDamage; }
            set { absorbDamage = value; }
        }
        bool absorbDamage = false;

        public List<int> UsableBy
        {
            get { return usableBy; }
            set { usableBy = value; }
        }
        List<int> usableBy = new List<int>();

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

        public Dictionary<int, int> HeroActions
        {
            get { return heroActions; }
            set { heroActions = value; }
        }
        Dictionary<int, int> heroActions = new Dictionary<int, int>();

        public ItemScope Scope
        {
            get { return scope; }
            set { scope = value; }
        }
        ItemScope scope;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }
        int range = 1;

        public bool MustFaceTarget
        {
            get { return mustFaceTarget; }
            set { mustFaceTarget = value; }
        }
        bool mustFaceTarget = true;


        public int PropertyType
        {
            get { return propertyType; }
            set { propertyType = value; }
        }
        int propertyType;

        public bool EnableCondition
        {
            get { return enableCondition; }
            set { enableCondition = value; }
        }
        bool enableCondition;

        public EventProgramData Condition
        {
            get { return condition; }
            set { condition = value; }
        }
       EventProgramData condition;
    }

    [Serializable]
    public class ItemEffect : IGameData
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

        public EffectScope Scope
        {
            get { return scope; }
            set { scope = value; }
        }
        EffectScope scope = EffectScope.User;

        public int GlobalEvent
        {
            get { return globalEvent; }
            set { globalEvent = value; }
        }
        int globalEvent = -1;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        int _value = 0;

        public ItemValueType ValueType
        {
            get { return valueType; }
            set { valueType = value; }
        }
        ItemValueType valueType = ItemValueType.Constant;

        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property = 0;

        public int Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        int animation = -1;

        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action = -1;

        public int Particle
        {
            get { return particle; }
            set { particle = value; }
        }
        int particle = -1;
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
