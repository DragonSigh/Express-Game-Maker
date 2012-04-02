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
    public class EnemyData : IGameData
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

        public int AnimationID = -1;

        public int[] Actions = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        public int Database = 0;

        public Dictionary<int, int> Equipments = new Dictionary<int, int>();

        public Dictionary<int, int> Elements = new Dictionary<int, int>();

        public Dictionary<int, int> States = new Dictionary<int, int>();

        public int Gold = 0;

        public int Experience = 0;

        public List<EnemyProgram> Programs = new List<EnemyProgram>();

        public List<int> ItemDrops = new List<int>();

        public List<int> EquipDrops = new List<int>();

        public int DropProbality = 100;

        public int Steal = -1;

        public ItemType StealType= ItemType.Item;

        public int StealProbality= 100;
    }
    //public class EnemyData : IGameData
    //{
    //    /// <summary>
    //    /// Name
    //    /// </summary>
    //    [Browsable(false)]
    //    public override string Name
    //    {
    //        get { return name; }
    //        set { name = value; }
    //    }
    //    string name;
    //    /// <summary>
    //    /// The unique id
    //    /// </summary>
    //    [Browsable(false)]
    //    public override int ID
    //    {
    //        get { return id; }
    //        set { id = value; }
    //    }
    //    int id;
    //    /// <summary>
    //    /// The category the data is in. Usage is optional.
    //    /// </summary>
    //    [Browsable(false)]
    //    public override int Category
    //    {
    //        get { return category; }
    //        set { category = value; }
    //    }
    //    int category = 0;


    //    public int AnimationID
    //    {
    //        get { return animationId; }
    //        set { animationId = value; }
    //    }
    //    int animationId = -1;

    //    public int[] Actions
    //    {
    //        get { return actions; }
    //        set { actions = value; }
    //    }
    //    int[] actions = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 };

    //    public int Database
    //    {
    //        get { return database; }
    //        set { database = value; }
    //    }
    //    int database = -1;

    //    public SerializableDictionary<int, int> Equipments
    //    {
    //        get { return equipments; }
    //        set { equipments = value; }
    //    }
    //    SerializableDictionary<int, int> equipments = new SerializableDictionary<int, int>();

    //    public SerializableDictionary<int, int> Elements
    //    {
    //        get { return elements; }
    //        set { elements = value; }
    //    }
    //    SerializableDictionary<int, int> elements = new SerializableDictionary<int, int>();

    //    public SerializableDictionary<int, int> States
    //    {
    //        get { return elements; }
    //        set { elements = value; }
    //    }
    //    SerializableDictionary<int, int> states = new SerializableDictionary<int, int>();

    //    public int Gold
    //    {
    //        get { return gold; }
    //        set { gold = value; }
    //    }
    //    int gold = 0;

    //    public int Experience
    //    {
    //        get { return experience; }
    //        set { experience = value; }
    //    }
    //    int experience = 0;

    //    public List<EnemyProgram> Programs
    //    {
    //        get { return programs; }
    //        set { programs = value; if (action == null)  Setup(); }
    //    }
    //    List<EnemyProgram> programs = new List<EnemyProgram>();

    //    public List<int> ItemDrops
    //    {
    //        get { return itemDrops; }
    //        set { itemDrops = value; }
    //    }
    //    List<int> itemDrops = new List<int>();

    //    public List<int> EquipDrops
    //    {
    //        get { return equipDrops; }
    //        set { equipDrops = value; }
    //    }
    //    List<int> equipDrops = new List<int>();

    //    public int DropProbality
    //    {
    //        get { return dropProb; }
    //        set { dropProb = value; }
    //    }
    //    int dropProb = 100;

    //    public int Steal
    //    {
    //        get { return steals; }
    //        set { steals = value; }
    //    }
    //    int steals = -1;

    //    public ItemType StealType
    //    {
    //        get { return stealType; }
    //        set { stealType = value; }
    //    }
    //    ItemType stealType = ItemType.Item;

    //    public int StealProbality
    //    {
    //        get { return stealProb; }
    //        set { stealProb = value; }
    //    }
    //    int stealProb = 100;
    //}
    [Serializable]
    public class EnemyProgram
    {
        public string Name
        {
            get
            {
                switch (actionType)
                {
                    case EnemyActionType.Basic:
                        return BasicName();
                    case EnemyActionType.Item:
                        return ItemName();
                    case EnemyActionType.Magic:
                        return MagicName();
                    case EnemyActionType.Skill:
                        return SkillName();
                }
                return "ERROR";
            }
        }

        private string MagicName()
        {
            SkillData data;
            if (GameData.Skills.TryGetValue(item, out data))
            {
                if (data.SkillType == SkillType.Magic)
                    return "Magic: [" + data.Name + "]";
            }
            return "Magic Doesn't Exit";
        }

        private string SkillName()
        {
            SkillData data;
            if (GameData.Skills.TryGetValue(item, out data))
            {
                if (data.SkillType == SkillType.Skill)
                    return "Skill: [" + data.Name + "]";
            }
            return "Skill Doesn't Exit";
        }

        private string ItemName()
        {
            ItemData data;
            if (GameData.Items.TryGetValue(item, out data))
            {
                return "Item: [" + data.Name + "]";
            }
            return "Item Doesn't Exit";
        }

        private string BasicName()
        {
            switch (action)
            {
                case EnemyAction.Attack:
                    return "Attack";
                case EnemyAction.Defend:
                    return "Defend";
                case EnemyAction.Escape:
                    return "Escape";
                case EnemyAction.Wait:
                    return "Wait";
            }
            return "No Action";
        }

        public string ConditionName
        {
            get
            {
                switch (condition)
                {
                    case EnemyActionCondition.Always:
                        return  "Always";
                    case EnemyActionCondition.EveryTurnTime:
                        return "Start From " +conditionValue[0].ToString() + " For Every " + conditionValue[1].ToString();
                    case EnemyActionCondition.HP:
                        return "HP is between [" + conditionValue[0].ToString() + "]% [" + conditionValue[1].ToString() + "]%";
                    case EnemyActionCondition.MP:
                        return "MP is between [" + conditionValue[0].ToString() + "]% [" + conditionValue[1].ToString() + "]%";
                    case EnemyActionCondition.SP:
                        return "SP is between [" + conditionValue[0].ToString() + "]% [" + conditionValue[1].ToString() + "]%";
                    case EnemyActionCondition.State:
                        StateData data;
                        if (GameData.States.TryGetValue(conditionValue[0], out data))
                        {
                            return "Has State: [" + data.Name + "]";
                        }
                        return "State doesn't exist.";
                    case EnemyActionCondition.Switch:
                        SwitchData sdata;
                        if (GameData.Switches.TryGetValue(conditionValue[0], out sdata))
                        {
                            return "Switch [" + sdata.Name + "] is " + (conditionValue[1] == 0 ? "On" : "Off");
                        }
                        return "Switch doesn't exist.";
                    case EnemyActionCondition.PartyLevel:
                        return "Party level is [" + conditionValue[0].ToString() + "] or " + (conditionValue[1] == 0 ? "Above" : "Below");
                }
                return "ERROR";
            }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        int priority = 5;

        public EnemyAction Action
        {
            get { return action; }
            set { action = value; }
        }
        EnemyAction action = EnemyAction.Attack;

        public int Item
        {
            get { return item; }
            set { item = value;    }
        }
        int item = -1;

        public int[] ConditionValue
        {
            get { return conditionValue; }
            set { conditionValue = value; }
        }
        int[] conditionValue = new int[2];

        public EnemyActionType ActionType
        {
            get { return actionType; }
            set { actionType = value; }
        }
        EnemyActionType actionType = EnemyActionType.Basic;

        public EnemyActionCondition Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        EnemyActionCondition condition = EnemyActionCondition.Always;
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

