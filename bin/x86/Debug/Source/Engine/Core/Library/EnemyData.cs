//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EGMGame.Interfaces;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the item data.
    /// </summary>
    
    public class EnemyData : IGameData
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

        public Dictionary<int, int> Equipments;

        public Dictionary<int, int> Elements;

        public Dictionary<int, int> States;

        public int Gold;

        public int Experience;

        public List<EnemyProgram> Programs;

        public List<int> ItemDrops;

        public List<int> EquipDrops;

        public int DropProbality;

        public int Steal;

        public ItemType StealType;

        public int StealProbality;
    }

    public class EnemyProgram
    {
        public int Priority;

        public EnemyAction Action;

        public int Item;

        public int[] ConditionValue;

        public EnemyActionType ActionType;

        public EnemyActionCondition Condition;
    }

    public enum ItemType
    {
        Item,
        Equipment
    }

    public enum EnemyActionCondition
    {
        Always,
        EveryTurnTime,
        HP,
        SP,
        MP,
        State,
        PartyLevel,
        Switch
    }

    public enum EnemyActionType
    {
        Basic,
        Skill,
        Magic,
        Item
    }

    public enum EnemyAction
    {
        Attack,
        Defend,
        Escape,
        Wait
    }
}

