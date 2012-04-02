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
    
    public class SkillData : IGameData
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

        public List<SkillEffect> Effects;

        public List<int> Elements;

        public List<int> InflictState;

        public List<int> RemoveState;

        public SkillType SkillType;

        public Dictionary<int, int> HeroActions;

        public ItemScope Scope;

        public int Range;

        public int Projectile;

        public bool MustFaceTarget;

        public int Cost;

        public int CostID;

        public int Speed;

        public int Knockback;

        public int PropertyType;

        public bool EnableCondition;

        public EventProgramData Condition;
    }

    public class SkillEffect : ItemEffect
    {
        public int Success;

        public bool Flee;

        public bool Steal;

    }


    public enum SkillType
    {
        Skill,
        Magic,
        Both
    }
}
