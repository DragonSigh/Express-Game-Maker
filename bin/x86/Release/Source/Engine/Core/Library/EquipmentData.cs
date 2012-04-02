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
    
    public class EquipmentData : IGameData
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

        public List<int> UsableBy;

        public List<int> Elements;

        public List<int> InflictState;

        public List<int> RemoveState;

        public List<int> EquipmentSlots;

        public bool WhileDefending;

        public bool IgnoreDefense;

        public bool CriticalBonus;

        public bool PreventCritical;

        public bool TwoSlots;

        public bool VisualAnchor;

        public int VisualAnimation;

        public EquipType EquipType;

        public int Animation;

        public int Action;

        public int Particle;

        public int Range;

        public int Knockback;

        public int Value;

        public ItemValueType ValueType;
        
        public int Property;

        public int Projectile;

        public int AmmoID;

        public Dictionary<int, List<int>> HeroActions;

        public int Mash;

        public int KnockbackSpeed;
        
        public int UseAnchor;

        public int AnchorTo;

        public int PropertyType;
    }

    public enum WeaponType
    {
        Normal,
        Projectile,
        Bomb,
        Rocket
    }

    public enum EquipType
    {
        Offensive,
        Defensive
    }
}
