//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using EGMGame.Interfaces;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the item data.
    /// </summary>
    
    public class HeroData : IGameData
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

        public int AnimationID;

        public int[] Actions;

        public int Database;

        public int ItemsInventory;

        public int EquipmentsInventory;

        public int SkillsList;

        public int MagicsList;

        public bool AutoBattle;

        public bool LockEquipment;

        public bool CanUseSkills;

        public bool CanUseMagic;


        public List<SkillToLearn> MagicsToLearn;

        public List<SkillToLearn> SkillsToLearn;

        public Dictionary<int, int> Equipments;

        public Dictionary<int, int> Elements;

        public Dictionary<int, int> States;
    }

    public class SkillToLearn
    {
        /// <summary>
        /// The unique id
        /// </summary>
        public int Level;
        /// <summary>
        /// The unique id
        /// </summary>
        public int ID;
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
