//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the item data.
    /// </summary>
    [Serializable]
    public class HeroData : IGameData
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

        public int AnimationID
        {
            get { return animationId; }
            set { animationId = value; }
        }
        int animationId = -1;

        public int[] Actions
        {
            get { return actions; }
            set { actions = value; }
        }
        int[] actions = new int[] { 0, 1, -1, -1, -1, -1, -1, -1, -1, -1 };

        public int Database
        {
            get { return database; }
            set { database = value; }
        }
        int database = -1;

        public int ItemsInventory
        {
            get { return itemsInventory; }
            set { itemsInventory = value; }
        }
        int itemsInventory = -1;

        public int EquipmentsInventory
        {
            get { return equipInventory; }
            set { equipInventory = value; }
        }
        int equipInventory = -1;

        public int SkillsList
        {
            get { return skillsList; }
            set { skillsList = value; }
        }
        int skillsList = -1;

        public int MagicsList
        {
            get { return magicsList; }
            set { magicsList = value; }
        }
        int magicsList = -1;

        public bool AutoBattle
        {
            get { return autoBattle; }
            set { autoBattle = value; }
        }
        bool autoBattle = false;

        public bool LockEquipment
        {
            get { return lockEquipment; }
            set { lockEquipment = value; }
        }
        bool lockEquipment = false;

        public bool CanUseSkills
        {
            get { return canUseSkills; }
            set { canUseSkills = value; }
        }
        bool canUseSkills = true;

        public bool CanUseMagic
        {
            get { return canUseMagic; }
            set { canUseMagic = value; }
        }
        bool canUseMagic = true;


        public List<SkillToLearn> MagicsToLearn
        {
            get { return magicsToLearn; }
            set { magicsToLearn = value; }
        }
        List<SkillToLearn> magicsToLearn = new List<SkillToLearn>();

        public List<SkillToLearn> SkillsToLearn
        {
            get { return skillsToLearn; }
            set { skillsToLearn = value; }
        }
        List<SkillToLearn> skillsToLearn = new List<SkillToLearn>();

        public Dictionary<int, int> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }
        Dictionary<int, int> equipments = new Dictionary<int, int>();

        public Dictionary<int, int> Elements
        {
            get { return elements; }
            set { elements = value; }
        }
        Dictionary<int, int> elements = new Dictionary<int, int>();

        public Dictionary<int, int> States
        {
            get { return elements; }
            set { elements = value; }
        }
        Dictionary<int, int> states = new Dictionary<int, int>();
    }
    [Serializable]
    public class SkillToLearn
    {
        /// <summary>
        /// Name
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        public string Name
        {
            get 
            {
                if (GameData.Skills.ContainsKey(id))
                {
                    return GameData.Skills[id].Name;
                }
                return "Skill/Magic not found.";
            }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        int level;
        /// <summary>
        /// The unique id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
    }
}


//public int IdleAction
//{
//    get { return idleAction; }
//    set { idleAction = value; }
//}
//int idleAction = -1;

//public int WalkingAction
//{
//    get { return walkingAction; }
//    set { walkingAction = value; }
//}
//int walkingAction = -1;

//public int OffensiveAction
//{
//    get { return offensiveAction; }
//    set { offensiveAction = value; }
//}
//int offensiveAction = -1;

//public int DefensiveAction
//{
//    get { return defensiveAction; }
//    set { defensiveAction = value; }
//}
//int defensiveAction = -1;

//public int SkillAction
//{
//    get { return skillAction; }
//    set { skillAction = value; }
//}
//int skillAction = -1;

//public int Action
//{
//    get { return magicAction; }
//    set { magicAction = value; }
//}
//int magicAction = -1;

//public int ItemAction
//{
//    get { return itemAction; }
//    set { itemAction = value; }
//}
//int itemAction = -1;
