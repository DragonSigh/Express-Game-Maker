//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Interfaces;
using EGMGame.Library;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EGMGame.Components;
using System.Xml.Serialization;

namespace EGMGame.Processors
{
    
    public class EnemyProcessor : IBattler
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name
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
        /// Stores the animation id
        /// </summary>
        public override int AnimationID
        {
            get { return animationId; }
            set { animationId = value; }
        }
        int animationId = -1;
        /// <summary>
        /// Stores the actions
        /// </summary>
        public override int[] Actions
        {
            get { return actions; }
            set { actions = value; }
        }
        int[] actions = new int[] { -1, -1, -1, -1, -1, -1, -1 };
        /// <summary>
        /// Damaged
        /// </summary>
        public override bool Damaged
        {
            get { return damaged; }
            set { damaged = value; }
        }
        bool damaged = false;
        /// <summary>
        /// Damage
        /// </summary>
        public override int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        int damage;
        /// <summary>
        /// IsDefending
        /// </summary>
        public override bool IsDefending
        {
            get { return defend; }
            set { defend = value; }
        }
        bool defend;
        /// <summary>
        /// Indestructible
        /// </summary>
        public override bool Indestructible
        {
            get { return indestructible; }
            set { indestructible = value; }
        }
        bool indestructible;
        /// Stores the last used equipment.
        public EquipmentData LastEquipment;
        /// <summary>
        /// Returns the enemy data this enemy is linked to
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public EnemyData Data
        {
            get { return GameData.Enemies.GetData(ID); }
        }
        /// <summary>
        /// Stores the equipments
        /// </summary>
        public override Dictionary<int, int> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }
        Dictionary<int, int> equipments = new Dictionary<int, int>();
        /// <summary>
        /// Stores the bonus stats
        /// </summary>
        List<int> BonusStats = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// Stores the states
        /// </summary>
        public override List<StateProcessor> States
        {
            get { return states; }
            set { states = value; }
        }
        List<StateProcessor> states = new List<StateProcessor>();
        // Database
        public Data Database;
        // Equipment Action
        public int equipmentOffensiveActionIndex = 0;
        // Equipment Hero Action
        public List<int> equipmentHeroActionIndex = new List<int>();
        /// <summary>
        /// Returns the HP
        /// </summary>
        public int Hp
        {
            get { return (int)Database.Properties[0].Value; }
        }
        /// <summary>
        /// Returns the Mp
        /// </summary>
        public int Sp
        {
            get { return (int)Database.Properties[1].Value; }
        }
        /// <summary>
        /// Returns the Mp
        /// </summary>
        public int Mp
        {
            get { return (int)Database.Properties[2].Value; }
        }   /// <summary>
        /// Max HP
        /// </summary>
        /// <returns></returns>
        public int MaxHP
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 3 && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }

                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 3)
                                extra += states[i].Data.Effects[j].Value;

                return extra + (int)Database.Properties[3].Value + BonusStats[0];
            }
        }
        /// <summary>
        /// Max SP
        /// </summary>
        /// <returns></returns>
        public int MaxSP
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 4 && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }

                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 4)
                                extra += states[i].Data.Effects[j].Value;

                return extra + (int)Database.Properties[4].Value + BonusStats[1];
            }
        }
        /// <summary>
        /// Max MP
        /// </summary>
        /// <returns></returns>
        public int MaxMP
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 5 && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }

                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 5)
                                extra += states[i].Data.Effects[j].Value;

                return extra + (int)Database.Properties[5].Value + BonusStats[2];
            }
        }
        /// <summary>
        /// Strength
        /// </summary>
        public override int Strength
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 6 && equipment.ValueType == ItemValueType.Damage)
                        extra += equipment.Value;
                }
                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 6)
                                extra += states[i].Data.Effects[j].Value;
                return extra + (int)Database.Properties[6].Value + BonusStats[3];
            }
        }
        /// <summary>
        /// Defense
        /// </summary>
        public override int Defense
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 7 && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }
                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 7)
                                extra += states[i].Data.Effects[j].Value;
                return extra + (int)Database.Properties[7].Value + BonusStats[4];
            }
        }
        /// <summary>
        /// Magic Strength
        /// </summary>
        public override int MagicStr
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 8 && equipment.ValueType == ItemValueType.Damage)
                        extra += equipment.Value;
                }

                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 8)
                                extra += states[i].Data.Effects[j].Value;

                return extra + (int)Database.Properties[8].Value + BonusStats[5];
            }
        }
        /// <summary>
        /// Magic Defense
        /// </summary>
        public override int MagicDef
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 9 && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }

                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 9)
                                extra += states[i].Data.Effects[j].Value;
                return extra + (int)Database.Properties[9].Value + BonusStats[6];
            }
        }
        /// <summary>
        /// Agility
        /// </summary>
        public override int Agility
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 10 && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }

                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 10)
                                extra += states[i].Data.Effects[j].Value;
                return extra + (int)Database.Properties[10].Value + BonusStats[7];
            }
        }
        /// <summary>
        /// Luck
        /// </summary>
        public override int Luck
        {
            get
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == 11 && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }

                for (int i = 0; i < states.Count; i++)
                    if (states[i].Data.Settings == StateSettings.ParameterChange)
                        for (int j = 0; j < states[i].Data.Effects.Count; j++)
                            if (states[i].Data.Effects[i].Property == 11)
                                extra += states[i].Data.Effects[j].Value;

                return extra + (int)Database.Properties[11].Value + BonusStats[8];
            }
        }
        /// <summary>
        /// Prevent Critical
        /// </summary>
        public override bool PreventCritical
        {
            get
            {
                // Loop all Armor
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Data.Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.PreventCritical)
                        return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Critical
        /// </summary>
        public override bool Critical
        {
            get { return crit; }
            set { crit = value; }
        }
        bool crit;
        /// <summary>
        /// Elements
        /// </summary>
        public override Dictionary<int, int> Elements
        {
            get { return Data.Elements; }
        }
        public EnemyProcessor()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        public EnemyProcessor(int id)
        {
            EnemyData enemy = GameData.Enemies.GetData(id);
            ID = enemy.ID;
            Name = enemy.Name;
            // Clone Values
            Data defaultDatabase = GameData.Databases[1].Datas.GetData(enemy.Database);
            if (defaultDatabase != null)
            {
                Database = new Data();
                Database.Properties = new List<DataProperty>();
                DataProperty prop;
                // Add Properties of the database
                for (int i = 0; i < defaultDatabase.Properties.Count; i++)
                {
                    prop = defaultDatabase.Properties[i].Clone();
                    Database.Properties.Add(prop);
                }
            }
            else
            {
                Database = new Data();
                Database.Properties = new List<DataProperty>();
                DataProperty prop;
                // Add Properties of the database
                for (int i = 0; i < GameData.Databases[1].Properties.Count; i++)
                {
                    prop = GameData.Databases[1].Properties[i].Clone();
                    Database.Properties.Add(prop);
                }
            }
            // Equipments
            Equipments = new Dictionary<int, int>(enemy.Equipments);
            // Aniamtion ID and actions
            AnimationID = enemy.AnimationID;
            Actions = (int[])enemy.Actions.Clone();
            // Setup AI

        }
        /// <summary>
        /// Setup Equipment Animations
        /// </summary>
        /// <param name="ev"></param>
        public override void SetupEquipmentAnimations(EventProcessor ev)
        {
            EquipmentData equipment;

            foreach (KeyValuePair<int, int> slot in Equipments)
            {
                // Anchor new equipment
                if (slot.Value > -1 && ev != null)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);

                    if (equipment != null && equipment.VisualAnchor)
                    {
                        AnimationData animation = GameData.Animations.GetData(equipment.VisualAnimation);
                        if (animation != null)
                        {
                            AnimationProcessor ani = new AnimationProcessor();
                            ani.UseAnchor = equipment.UseAnchor;
                            ani.AnchorTo = equipment.AnchorTo;
                            ev.EquipmentAnimations.Add(slot.Key, ani);
                            ev.SetupEquipmentAnchor(slot.Value, slot.Key);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Is Dead?
        /// </summary>
        /// <returns></returns>
        public override bool IsDead()
        {
            // Check States
            for (int i = 0; i < States.Count; i++)
            {
                if (States[i].Data.Settings == StateSettings.Death) return true;
            }
            return (Hp <= 0);
        }
        /// <summary>
        /// Inflict Death
        /// </summary>
        private void InflictDeath()
        {
            if (Global.Project.DeathState > -1)
            {
                AddState(Global.Project.DeathState);
            }
        }
        /// <summary>
        /// Revive
        /// </summary>
        public override void Revive()
        {
            HealAll();
        }
        /// <summary>
        /// Heal all
        /// </summary>
        public void HealAll()
        {
            List<DataProperty> property;
            int level;
            // Get properties for ease of access
            property = Database.Properties;
            // Get Level
            level = (int)property[12].Value - 1;
            // Hp
            property[0].Value = (int)((List<int>)property[3].Value)[level];
            // Sp
            property[1].Value = (int)((List<int>)property[4].Value)[level];
            // Mp
            property[2].Value = (int)((List<int>)property[5].Value)[level];
            // Remove Death state
            StateProcessor death = null;
            foreach (StateProcessor state in States)
            {
                if (state.ID == Global.Project.DeathState)
                {
                    death = state;
                    break;
                }
            }
            if (death != null) States.Remove(death);
        }
        /// <summary>
        /// Can use skill? (skill)
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public override bool CanUseSkill(SkillData skill)
        {
            if ((int)Database.Properties[skill.CostID].Value <= skill.Cost)
                return false;
            // Check States
            for (int i = 0; i < States.Count; i++)
            {
                if (States[i].Data.Settings == StateSettings.CanNotUseskill && skill.SkillType == SkillType.Skill)
                    return false;
                if (States[i].Data.Settings == StateSettings.CanNotUsemagic && skill.SkillType == SkillType.Magic)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Skill Cost
        /// </summary>
        public override void SkillCost(int cost, int costId)
        {
            ApplyConstantToProperty(costId, -cost);
        }
        /// <summary>
        /// Can Move
        /// </summary>
        /// <returns></returns>
        public override bool CanMove()
        {
            // Check States
            for (int i = 0; i < states.Count; i++)
                if (States[i].Data.Settings == StateSettings.CanNotMove)
                    return false;
            return true;
        }
        /// <summary>
        /// Attack Ally
        /// </summary>
        /// <returns></returns>
        public override bool AttackAlly()
        {
            // Check States
            for (int i = 0; i < states.Count; i++)
                if (States[i].Data.Settings == StateSettings.AlwaysAttackAlly)
                    return false;
            return false;
        }
        /// <summary>
        /// Add State
        /// </summary>
        /// <param name="id"></param>
        public void AddState(int id)
        {
            foreach (StateProcessor state in States)
            {
                if (state.ID == id)
                    return;
            }
            StateProcessor s = new StateProcessor(id);
            States.Add(s);

            foreach (int i in s.Data.InflictState)
            {
                if (id != i)
                    AddState(i);
            }
            foreach (int i in s.Data.RemoveState)
            {
                if (id != i)
                    RemoveState(i);
            }
        }
        /// <summary>
        /// Remove State
        /// </summary>
        /// <param name="id"></param>
        public override void RemoveState(int id)
        {
            StateProcessor remove = null;
            foreach (StateProcessor state in States)
            {
                if (state.ID == id)
                    remove = state;
            }
            if (remove != null)
                States.Remove(remove);
        }
        /// <summary>
        /// Get Items
        /// </summary>
        /// <returns></returns>
        public ListData GetItems()
        {
            return null;
        }
        /// <summary>
        /// Get skills
        /// </summary>
        /// <returns></returns>
        public override ListData GetSkills()
        {
            return null;
        }
        /// <summary>
        /// Get Magics
        /// </summary>
        public override ListData GetMagics()
        {
            return null;
        }
        /// <summary>
        /// Returns the item action
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public override int GetItemAction(ItemData item)
        {
            return Data.Actions[(int)EventAction.Item];
        }
        /// <summary>
        /// Returns the skill action
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public override int GetSkillAction(SkillData skill)
        {
            return Data.Actions[(int)EventAction.Skill];
        }
        /// <summary>
        /// Get Equipment
        /// </summary>
        /// <returns></returns>
        public override EquipmentData GetOffensiveEquipment()
        {
            return null;
        }
        /// <summary>
        /// Get weapon from slot
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        public int GetEquipment(int slot)
        {
            int value = -1;
            Equipments.TryGetValue(slot, out value);
            return value;
        }
        /// <summary>
        /// Get Equipment
        /// </summary>
        /// <returns></returns>
        public EquipmentData GetOffensiveEquipment(int range)
        {
            EquipmentData equipment = null;
            foreach (KeyValuePair<int, int> slot in Data.Equipments)
            {
                equipment = GameData.Equipments.GetData(slot.Value);
                if (equipment != null && equipment.EquipType == EquipType.Offensive)
                {
                    if (equipment.Range >= range)
                    {
                        return LastEquipment = equipment;
                    }
                }
            }
            return LastEquipment = null;
        }
        /// <summary>
        /// Returns the current equipment action
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public override int GetEquipmentAction(EquipmentData equipment)
        {
            return Data.Actions[(int)EventAction.Attack];
        }
        /// <summary>
        /// Apply Value to property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="amount"></param>
        public override void ApplyConstantToProperty(int id, int value)
        {
            List<DataProperty> property;
            int newValue = value;
            // Get properties for ease of access
            property = Database.Properties;
            if (id < 3)
            {
                newValue = (int)property[id].Value + value;
                // Hp, Sp, or Mp
                property[id].Value = (int)Math.Max(0, Math.Min(newValue, (int)property[id].Value));

                // HP - Check Death
                if (id == 0)
                {
                    if ((int)property[id].Value == 0)
                        InflictDeath();
                }
            }
            else if (id < 12)
            {
                newValue = (int)property[id].Value + value;
                // Stats Bonuses
                property[id].Value = (int)Math.Max(0, newValue);
            }
            else
            {
                DataProperty dataP = Database.Properties.GetData(id);
                if (dataP != null)
                {
                    newValue = (int)dataP.Value + value;
                    // Stats Bonuses
                    dataP.Value = (int)Math.Max(0, newValue);
                }
            }
        }
        /// <summary>
        /// Apply percentage to property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override int ApplyPercentageToProperty(int id, int value)
        {
            List<DataProperty> property;
            int newValue = value;
            int oldValue = 0;
            // Get properties for ease of access
            property = Database.Properties;
            if (id < 3)
            {
                oldValue = (int)property[id].Value;
                newValue = (int)property[id].Value + ((int)property[id + 3].Value * (value / 100));
                // Hp, Sp, or Mp
                property[id].Value = (int)Math.Max(0, Math.Min(newValue, (int)property[id + 3].Value));

                // HP - Check Death
                if (id == 0)
                {
                    if ((int)property[id].Value == 0)
                        InflictDeath();
                }
            }
            else if (id < 12)
            {
                oldValue = (int)property[id].Value;
                newValue = (int)property[id].Value + ((int)property[id].Value * (value / 100));
                // Stats Bonuses
                property[id].Value = (int)Math.Max(0, newValue);
            }
            else
            {
                DataProperty dataP = Database.Properties.GetData(id);
                if (dataP != null)
                {
                    oldValue = (int)dataP.Value;
                    newValue = (int)dataP.Value + ((int)dataP.Value * (value / 100));
                    // Stats Bonuses
                    dataP.Value = (int)Math.Max(0, newValue);
                }
            }

            return newValue - oldValue;
        }
        /// <summary>
        /// Get Property Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override int GetPropertyValue(int id)
        {
            DataProperty property;
            // Get properties for ease of access
            property = Database.Properties.GetData(id);

            if (property != null && property.ValueType == DataType.Number)
                return (int)property.Value;

            return 0;
        }
        /// <summary>
        /// Inflict State
        /// </summary>
        /// <param name="id"></param>
        public override void InflictState(int id)
        {
            if (Battle.random.Next(1, 100) <= 50)
            {
                AddState(id);
            }
        }
        /// <summary>
        /// Checks whether the party member at the given index can be effected by the skill
        /// </summary>
        /// <param name="partyIndex"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public override bool CanSkillEffect(SkillData skill)
        {
            if (skill.Scope == ItemScope.AllPartyDead || skill.Scope == ItemScope.OneAllyDead)
            {
                if (this.IsDead())
                    return true;
                else
                    return false;
            }
            else
            {
                if (this.IsDead())
                    return false;
            }

            int value = this.GetPropertyValue((int)skill.Condition.Value[1]);
            int value2;

            if ((int)skill.Condition.Value[3] == 0)
                value2 = (int)skill.Condition.Value[4];
            else
                value2 = this.GetPropertyValue((int)skill.Condition.Value[4]);

            switch ((int)skill.Condition.Value[2])
            {
                case 0: //Equals (=)
                    return (value == value2);
                case 1: //Greater Than (>)
                    return (value > value2);
                case 2: //Less Than (<)
                    return (value < value2);
                case 3: //Greater Than Or Equals (>=)
                    return (value >= value2);
                case 4: //Less Than Or Equals (<=)
                    return (value <= value2);
                case 5: //Does Not Equal (!=)
                    return (value != value2);
            }

            return false;
        }
        /// <summary>
        /// Checks whether the party member at the given index can be effected by the skill
        /// </summary>
        /// <param name="partyIndex"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public override bool CanItemEffect(ItemData item)
        {
            if (item.Scope == ItemScope.AllPartyDead || item.Scope == ItemScope.OneAllyDead)
            {
                if (this.IsDead())
                    return true;
                else
                    return false;
            }
            else
            {
                if (this.IsDead())
                    return false;
            }

            int value = this.GetPropertyValue((int)item.Condition.Value[1]);
            int value2;

            if ((int)item.Condition.Value[3] == 0)
                value2 = (int)item.Condition.Value[4];
            else
                value2 = this.GetPropertyValue((int)item.Condition.Value[4]);

            switch ((int)item.Condition.Value[2])
            {
                case 0: //Equals (=)
                    return (value == value2);
                case 1: //Greater Than (>)
                    return (value > value2);
                case 2: //Less Than (<)
                    return (value < value2);
                case 3: //Greater Than Or Equals (>=)
                    return (value >= value2);
                case 4: //Less Than Or Equals (<=)
                    return (value <= value2);
                case 5: //Does Not Equal (!=)
                    return (value != value2);
            }

            return false;
        }
        #region Draw And Update
        public override void Update(GameTime gameTime, EventProcessor ev)
        {
            // Update States
            for (int i = 0; i < States.Count; i++)
            {
                States[i].Update(gameTime, ev, this);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw States
            for (int i = 0; i < States.Count; i++)
            {
                States[i].Draw(gameTime);
            }
        }
        #endregion
    }
}
