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
    public class SkillData : IGameData
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

        public List<SkillEffect> Effects
        {
            get
            {
                return itemEffect;
            }
            set { itemEffect = value; }
        }
        List<SkillEffect> itemEffect = new List<SkillEffect>();

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

        public SkillType SkillType
        {
            get { return skillType; }
            set { skillType = value; }
        }
        SkillType skillType = SkillType.Skill;

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
        int range = 64;

        public int Projectile
        {
            get { return projectile; }
            set { projectile = value; }
        }
        int projectile = -1;

        public bool MustFaceTarget
        {
            get { return mustFaceTarget; }
            set { mustFaceTarget = value; }
        }
        bool mustFaceTarget = true;

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        int cost;

        public int CostID
        {
            get { return costId; }
            set { costId = value; }
        }
        int costId;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        int speed;

        public int Knockback
        {
            get { return knockback; }
            set { knockback = value; }
        }
        int knockback;

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
    public class SkillEffect : ItemEffect
    {

        public int Success
        {
            get { return success; }
            set { success = value; }
        }
        int success = 100;

        public bool Flee
        {
            get { return flee; }
            set { flee = value; }
        }
        bool flee;

        public bool Steal
        {
            get { return steal; }
            set { steal = value; }
        }
        bool steal = false;

    }


    public enum SkillType
    {
        Skill,
        Magic,
        Both
    }
}
