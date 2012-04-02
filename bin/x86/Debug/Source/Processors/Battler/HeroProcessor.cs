//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Interfaces;
using EGMGame.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace EGMGame.Processors
{
    
    public class HeroProcessor : IBattler
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
        /// Returns the hero data this hero is linked to
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public HeroData Data
        {
            get { return GameData.Heroes.GetData(ID); }
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
        public List<int> BonusStats = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// Stores the states
        /// </summary>
        public override List<StateProcessor> States
        {
            get { return states; }
            set { states = value; }
        }
        List<StateProcessor> states = new List<StateProcessor>();
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
        int damage = 0;
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
        /// <summary>
        /// The Hero's level
        /// </summary>
        public int Level
        {
            get
            {
                if ((int)Database.Properties[12].Value == 0)
                    return 0;
                return (int)Database.Properties[12].Value - 1;
            }
        }
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
        }
        /// <summary>
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

                return extra + (int)((List<int>)Database.Properties[3].Value)[Level] + BonusStats[0];
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

                return extra + (int)((List<int>)Database.Properties[4].Value)[Level] + BonusStats[1];
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

                return extra + (int)((List<int>)Database.Properties[5].Value)[Level] + BonusStats[2];
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
                return extra + (int)((List<int>)Database.Properties[6].Value)[Level] + BonusStats[3];
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
                return extra + (int)((List<int>)Database.Properties[7].Value)[Level] + BonusStats[4];
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

                return extra + (int)((List<int>)Database.Properties[8].Value)[Level] + BonusStats[5];
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
                return extra + (int)((List<int>)Database.Properties[9].Value)[Level] + BonusStats[6];
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
                return extra + (int)((List<int>)Database.Properties[10].Value)[Level] + BonusStats[7];
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

                return extra + (int)((List<int>)Database.Properties[11].Value)[Level] + BonusStats[8];
            }
        }
        /// <summary>
        /// Prevent Critical
        /// </summary>
        public override bool PreventCritical
        {
            get
            {
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
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
        /// <summary>
        /// Get Skills
        /// </summary>
        public List<int> Skills
        {
            get
            {
                if (Data.SkillsList > -1)
                {
                    ListData list = Global.Instance.Lists.GetData(Data.SkillsList);
                    if (list != null)
                        return list.Values;
                }
                return new List<int>();
            }
        }
        /// <summary>
        /// Get Magics
        /// </summary>
        public List<int> Magics
        {
            get
            {
                if (Data.MagicsList > -1)
                {
                    ListData list = Global.Instance.Lists.GetData(Data.MagicsList);
                    if (list != null)
                        return list.Values;
                }
                return new List<int>();
            }
        }
        // Database
        public Data Database;
        // Experience
        public int experience = 0;
        // Equipment Action
        public int equipmentOffensiveActionIndex = 0;
        // Equipment Hero Action
        public List<int> equipmentHeroActionIndex = new List<int>();
        /// Stores the last used equipment.
        public EquipmentData LastEquipment;
        /// Stores the last used item.
        public ItemData LastItem;
        /// Stores the last used skill.
        public SkillData LastSkill;
        /// <summary>
        /// Deserialization Constructor
        /// </summary>
        public HeroProcessor()
        { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        public HeroProcessor(int id)
        {
            HeroData hero = GameData.Heroes.GetData(id);
            ID = hero.ID;
            Name = hero.Name;
            // Clone Values
            Data defaultDatabase = GameData.Databases[0].Datas.GetData(hero.Database);
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
                for (int i = 0; i < GameData.Databases[0].Properties.Count; i++)
                {
                    prop = GameData.Databases[0].Properties[i].Clone();
                    Database.Properties.Add(prop);
                }
            }
            // Equipments
            Equipments = new Dictionary<int, int>(hero.Equipments);
            for (int i = 0; i < Equipments.Keys.Count; i++)
                equipmentHeroActionIndex.Add(0);
            // Skills
            LevelChange();
            // Aniamtion ID and actions
            AnimationID = hero.AnimationID;
            Actions = (int[])hero.Actions.Clone();
            // Check Experience
            CheckExperience();
        }
        /// <summary>
        /// Check Experience
        /// </summary>
        private void CheckExperience()
        {
            List<DataProperty> property = Database.Properties;
            List<int> curvelist = ((List<int>)property[14].Value);
            // Check Level
            if (curvelist.Count > 0 && experience < curvelist[Level])
                experience = curvelist[Level];
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
                            ev.EquipmentAnimations[slot.Key] = ani;
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
        /// Can hero use skill?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CanUseSkill(int id)
        {
            SkillData skill = GameData.Skills.GetData(id);
            if (skill != null)
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
            }
            else
                return false;
            return true;
        }
        /// <summary>
        /// Can Use Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CanUseItem(ItemData item)
        {
            if (!item.UsableBy.Contains(id)) return false;
            // Check States
            for (int i = 0; i < States.Count; i++)
            {
                if (States[i].Data.Settings == StateSettings.CanNotUseItem)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Can Use Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CanUseItem(int id)
        {
            ItemData item = GameData.Items.GetData(id);

            if (item != null)
            {
                if (!item.UsableBy.Contains(id)) return false;
                // Check States
                for (int i = 0; i < States.Count; i++)
                {
                    if (States[i].Data.Settings == StateSettings.CanNotUseItem)
                        return false;
                }
            }
            else
                return false;
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
        /// Equip Hero
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="equipID"></param>
        public void Equip(int slot, int equipID, bool includeInventory)
        {
            EquipmentData equipment;
            EventProcessor ev = Global.Instance.Party.GetPartyMember(id);
            // Remove Equipped Animation
            if (Equipments[slot] > -1 && ev != null)
            {
                equipment = GameData.Equipments.GetData(Equipments[slot]);

                if (equipment != null && equipment.VisualAnchor)
                {
                    ev.EquipmentAnimations.Remove(Equipments[slot]);
                }
            }
            // Remove old equipment from equipment and remove new equipment from invetory
            if (includeInventory && Equipments[slot] > -1)
            {
                if (Data.EquipmentsInventory > -1)
                {
                    ListData inventory = Global.Instance.Lists.GetData(Data.EquipmentsInventory);

                    if (equipID == -1)
                    {
                        // Add equipment to inventory
                        inventory.Values.Add(Equipments[slot]);

                        equipmentOffensiveActionIndex = 0;
                        // Equip
                        Equipments[slot] = equipID;
                    }
                    // If equipping
                    if (equipID > -1 && inventory.Values.Contains(equipID))
                    {
                        // Add old equipment to inventory
                        inventory.Values.Add(Equipments[slot]);
                        // Remove new equipment from inventory
                        inventory.Values.Remove(equipID);
                        // Equip
                        Equipments[slot] = equipID;

                        equipmentOffensiveActionIndex = 0;
                    }
                }
            }
            else
            {
                if (includeInventory)
                {
                    ListData inventory = Global.Instance.Lists.GetData(Data.EquipmentsInventory);
                    inventory.Values.Remove(equipID);
                }

                equipmentOffensiveActionIndex = 0;
                // Equip
                Equipments[slot] = equipID;
            }
            // Anchor new equipment
            if (Equipments[slot] > -1 && ev != null)
            {
                equipment = GameData.Equipments.GetData(Equipments[slot]);

                if (equipment != null && equipment.VisualAnchor)
                {
                    AnimationData animation = GameData.Animations.GetData(equipment.VisualAnimation);
                    if (animation != null)
                    {
                        AnimationProcessor ani = new AnimationProcessor();
                        ani.UseAnchor = equipment.UseAnchor;
                        ani.AnchorTo = equipment.AnchorTo;
                        ev.EquipmentAnimations[slot] = ani;
                        ev.SetupEquipmentAnchor(Equipments[slot], slot);
                    }
                }
            }
        }
        /// <summary>
        /// Add Equipment
        /// </summary>
        /// <param name="equipId"></param>
        public void AddEquipment(int equipId)
        {
            ListData list = Global.Instance.Lists.GetData(Data.EquipmentsInventory);

            if (list != null)
            {
                int count = 0;

                for (int i = 0; i < list.Values.Count; i++)
                    if (list.Values[i] == equipId)
                        count++;
                if (count < 100)
                    list.Values.Add(equipId);
            }
        }
        /// <summary>
        /// Remove an equipment from the given id
        /// </summary>
        /// <param name="itemID"></param>
        public void RemoveEquipment(int equipID)
        {
            if (Data.EquipmentsInventory > -1)
            {
                ListData Equipments = Global.Instance.Lists.GetData(Data.EquipmentsInventory);
                EquipmentData Equipment = GameData.Equipments.GetData(equipID);
                // Equipments
                if (Equipments != null && Equipment != null)
                {
                    Equipments.Values.Remove(equipID);
                }
            }
        }
        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="itemId"></param>
        public void AddItem(int itemId)
        {
            ListData list = Global.Instance.Lists.GetData(Data.ItemsInventory);

            if (list != null)
            {
                int count = 0;

                for (int i = 0; i < list.Values.Count; i++)
                    if (list.Values[i] == itemId)
                        count++;
                if (count < 100)
                    list.Values.Add(itemId);
            }
        }
        /// <summary>
        /// Remove an item from the given id
        /// </summary>
        /// <param name="itemID"></param>
        public void RemoveItem(int itemID)
        {
            if (Data.ItemsInventory > -1)
            {
                ListData items = Global.Instance.Lists.GetData(Data.ItemsInventory);
                ItemData item = GameData.Items.GetData(itemID);
                // Items
                if (items != null && item != null && item.Consumable)
                {
                    items.Values.Remove(itemID);
                }
            }
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
            if (level < ((List<int>)property[3].Value).Count)
                property[0].Value = (int)((List<int>)property[3].Value)[level];
            // Sp
            if (level < ((List<int>)property[4].Value).Count)
                property[1].Value = (int)((List<int>)property[4].Value)[level];
            // Mp
            if (level < ((List<int>)property[5].Value).Count)
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
        /// Learn skill
        /// </summary>
        /// <param name="id"></param>
        public void LearnSkill(int id)
        {
            if (Data.SkillsList > -1)
            {
                ListData list = Global.Instance.Lists.GetData(Data.SkillsList);
                if (!list.Values.Contains(id))
                {
                    list.Values.Add(id);
                }
            }
        }
        /// <summary>
        /// Forget skill
        /// </summary>
        /// <param name="id"></param>
        public void ForgetSkill(int id)
        {
            if (Data.SkillsList > -1)
            {
                ListData list = Global.Instance.Lists.GetData(Data.SkillsList);
                list.Values.Remove(id);
            }
        }
        /// <summary>
        /// Learn magic
        /// </summary>
        /// <param name="id"></param>
        public void LearnMagic(int id)
        {
            if (Data.MagicsList > -1)
            {
                ListData list = Global.Instance.Lists.GetData(Data.MagicsList);
                if (!list.Values.Contains(id))
                {
                    list.Values.Add(id);
                }
            }
        }
        /// <summary>
        /// Forget magic
        /// </summary>
        /// <param name="id"></param>
        public void ForgetMagic(int id)
        {
            if (Data.MagicsList > -1)
            {
                ListData list = Global.Instance.Lists.GetData(Data.MagicsList);
                list.Values.Remove(id);
            }
        }
        /// <summary>
        /// Increase Parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public int ChangeParameter(int id, int value, int operation)
        {
            List<DataProperty> property;
            int newValue = value;
            int oldValue = 0;
            // Get properties for ease of access
            property = Database.Properties;
            if (id < 3)
            {
                // Get Operation
                switch (operation)
                {
                    case 0: // Set
                        newValue = value;
                        break;
                    case 1: // Add
                        newValue = (int)property[id].Value + value;
                        break;
                    case 2: // Subtract
                        newValue = (int)property[id].Value - value;
                        break;
                    case 3: // Multiply
                        newValue = (int)property[id].Value * value;
                        break;
                    case 4: // Divide
                        newValue = (int)property[id].Value / value;
                        break;
                    case 5: // Exponantiate
                        newValue = (int)property[id].Value * value;
                        break;
                    case 6: // Modulate
                        newValue = (int)property[id].Value % value;
                        break;
                    case 7: // Percentage
                        newValue = (int)property[id].Value + ((int)(((List<int>)property[id + 3].Value)[Level]) * (value / 100));
                        break;
                }
                oldValue = (int)property[id].Value;
                // Hp, Sp, or Mp
                property[id].Value = (int)Math.Max(0, Math.Min(newValue, (int)((List<int>)property[id + 3].Value)[Level]));

                // HP - Check Death
                if (id == 0)
                {
                    if ((int)property[id].Value == 0)
                        InflictDeath();
                }
            }
            else if (id < 12)
            {
                // Get Operation
                switch (operation)
                {
                    case 0: // Set
                        newValue = value;
                        break;
                    case 1: // Add
                        newValue = BonusStats[id - 3] + value;
                        break;
                    case 2: // Subtract
                        newValue = BonusStats[id - 3] - value;
                        break;
                    case 3: // Multiply
                        newValue = BonusStats[id - 3] * value;
                        break;
                    case 4: // Divide
                        newValue = BonusStats[id - 3] / value;
                        break;
                    case 5: // Exponantiate
                        newValue = BonusStats[id - 3] * value;
                        break;
                    case 6: // Modulate
                        newValue = BonusStats[id - 3] % value;
                        break;
                    case 7: // Percentage
                        newValue = BonusStats[id - 3] + ((int)((List<int>)property[id].Value)[Level] * (value / 100));
                        break;
                }
                oldValue = (int)((List<int>)property[id].Value)[Level];
                // Stats Bonuses
                BonusStats[id - 3] = newValue;
            }
            else if (id == 12)
            {
                // Get Operation
                switch (operation)
                {
                    case 0: // Set
                        newValue = value;
                        break;
                    case 1: // Add
                        newValue = (int)property[id].Value + value;
                        break;
                    case 2: // Subtract
                        newValue = (int)property[id].Value - value;
                        break;
                    case 3: // Multiply
                        newValue = (int)property[id].Value * value;
                        break;
                    case 4: // Divide
                        newValue = (int)property[id].Value / value;
                        break;
                    case 5: // Exponantiate
                        newValue = (int)property[id].Value * value;
                        break;
                    case 6: // Modulate
                        newValue = (int)property[id].Value % value;
                        break;
                    case 7: // Percentage
                        newValue = (int)property[id].Value + ((int)property[id].Value * (value / 100));
                        break;
                }
                oldValue = (int)property[id].Value;
                // Record Old Level
                int level = (int)property[id].Value;
                // Level
                property[id].Value = (int)Math.Max(0, Math.Min(newValue, (int)property[id + 1].Value));
                // Change Level
                if (level != (int)property[id].Value)
                    LevelChange();
            }
            else if (id == 13)
            {
                // Get Operation
                switch (operation)
                {
                    case 0: // Set
                        newValue = value;
                        break;
                    case 1: // Add
                        newValue = (int)property[id].Value + value;
                        break;
                    case 2: // Subtract
                        newValue = (int)property[id].Value - value;
                        break;
                    case 3: // Multiply
                        newValue = (int)property[id].Value * value;
                        break;
                    case 4: // Divide
                        newValue = (int)property[id].Value / value;
                        break;
                    case 5: // Exponantiate
                        newValue = (int)property[id].Value * value;
                        break;
                    case 6: // Modulate
                        newValue = (int)property[id].Value % value;
                        break;
                    case 7: // Percentage
                        newValue = (int)property[id].Value + ((int)property[id].Value * (value / 100));
                        break;
                }
                oldValue = (int)property[id].Value;
                // Max Level
                property[id].Value = (int)Math.Max(0, newValue);
                // Level
                property[12].Value = (int)Math.Max(0, Math.Min(Level, (int)property[id].Value));
                // Change Level
                if (Level != (int)property[id].Value)
                    LevelChange();

            }
            else if (id == 14)
            {
                // Get Operation
                switch (operation)
                {
                    case 0: // Set
                        newValue = value;
                        break;
                    case 1: // Add
                        newValue = experience + value;
                        break;
                    case 2: // Subtract
                        newValue = experience - value;
                        break;
                    case 3: // Multiply
                        newValue = experience * value;
                        break;
                    case 4: // Divide
                        newValue = experience / value;
                        break;
                    case 5: // Exponantiate
                        newValue = experience * value;
                        break;
                    case 6: // Modulate
                        newValue = experience % value;
                        break;
                    case 7: // Percentage
                        newValue = experience + (experience * (value / 100));
                        break;
                }
                oldValue = experience;
                // Experience
                SetExperience(newValue);
            }
            else
            {
                // Custom Parameter
                DataProperty prop =property.GetData(id);

                if (prop != null && prop.ValueType == DataType.Number)
                {
                    // Get Operation
                    switch (operation)
                    {
                        case 0: // Set
                            newValue = value;
                            break;
                        case 1: // Add
                            newValue = (int)prop.Value + value;
                            break;
                        case 2: // Subtract
                            newValue = (int)prop.Value - value;
                            break;
                        case 3: // Multiply
                            newValue = (int)prop.Value * value;
                            break;
                        case 4: // Divide
                            newValue = (int)prop.Value / value;
                            break;
                        case 5: // Exponantiate
                            newValue = (int)prop.Value * value;
                            break;
                        case 6: // Modulate
                            newValue = (int)prop.Value % value;
                            break;
                        case 7: // Percentage
                            newValue = (int)prop.Value + ((int)prop.Value * (value / 100));
                            break;
                    }
                    oldValue = (int)prop.Value;
                    prop.Value = newValue;
                }
            }
            return newValue - oldValue;
        }
        /// <summary>
        /// Increase Experience
        /// </summary>
        /// <param name="newValue"></param>
        public void IncreaseExperience(int value)
        {
            List<DataProperty> property = Database.Properties;
            List<int> curvelist = ((List<int>)property[14].Value);
            experience += value;
            int lastExp = 0;
            // Check Level
            for (int levelIndex = 0; levelIndex < curvelist.Count; levelIndex++)
            {
                if (lastExp < experience && experience < curvelist[levelIndex] && Level < levelIndex)
                {
                    property[12].Value = (int)Math.Max(0, Math.Min(levelIndex, (int)property[13].Value));
                    LevelChange();
                    break;
                }
                lastExp = curvelist[levelIndex];
            }
        }
        /// <summary>
        /// Set Experience
        /// </summary>
        /// <param name="newValue"></param>
        public void SetExperience(int value)
        {
            List<DataProperty> property = Database.Properties;
            List<int> curvelist = ((List<int>)property[14].Value);
            experience = value;
            int lastExp = 0;
            // Check Level
            for (int levelIndex = 0; levelIndex < curvelist.Count; levelIndex++)
            {
                if (lastExp < experience && experience < curvelist[levelIndex])
                {
                    if ((int)property[12].Value != levelIndex)
                    {
                        property[12].Value = (int)Math.Max(0, Math.Min(levelIndex, (int)property[13].Value));
                        LevelChange();
                    }
                }
                lastExp = curvelist[levelIndex];
            }
        }
        /// <summary>
        /// Level Change 
        /// Learn Skills and Magic
        /// </summary>
        private void LevelChange()
        {
            if (Database != null)
            {
                int level = (int)Database.Properties[12].Value;
                // Learn Skill
                if (Data.CanUseSkills && Data.SkillsList > -1)
                {
                    ListData skills = Global.Instance.Lists.GetData(Data.SkillsList);
                    if (skills != null)
                    {
                        foreach (SkillToLearn skill in Data.SkillsToLearn)
                        {
                            if (skill.Level <= level && !skills.Values.Contains(skill.ID))
                            {
                                skills.Values.Add(skill.ID);
                            }
                        }
                    }
                }
                // Learn Magic
                if (Data.CanUseMagic && Data.MagicsList > -1)
                {
                    ListData magics = Global.Instance.Lists.GetData(Data.MagicsList);
                    if (magics != null)
                    {
                        foreach (SkillToLearn magic in Data.MagicsToLearn)
                        {
                            if (magic.Level <= level && !magics.Values.Contains(magic.ID))
                            {
                                magics.Values.Add(magic.ID);
                            }
                        }
                    }
                }
            }
            else
            {
                Error.Do(new Exception(Data.Name + " has no database!"));
            }
        }
        /// <summary>
        /// Has Item?
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool HasItem(int itemID)
        {
            if (Data.ItemsInventory > -1)
            {
                ListData items = Global.Instance.Lists.GetData(Data.ItemsInventory);

                // Items
                if (items != null)
                {
                    return items.Values.Contains(itemID);
                }
            }
            return false;
        }
        /// <summary>
        /// Get Items
        /// </summary>
        public ListData GetItems()
        {
            if (Data.ItemsInventory > -1)
            {
                return Global.Instance.Lists.GetData(Data.ItemsInventory);
            }
            return new ListData() { Values = new List<int>() };
        }
        /// <summary>
        /// Get Equipments
        /// </summary>
        /// <returns></returns>
        public ListData GetEquipments()
        {
            if (Data.EquipmentsInventory > -1)
            {
                return Global.Instance.Lists.GetData(Data.EquipmentsInventory);
            }
            return new ListData() { Values = new List<int>() };
        }
        /// <summary>
        /// Has Equipment?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasEquipment(int id)
        {
            if (Data.ItemsInventory > -1)
            {
                ListData items = Global.Instance.Lists.GetData(Data.EquipmentsInventory);
                // Items
                if (items != null)
                    return items.Values.Contains(id);
            }
            return false;
        }
        /// <summary>
        /// Get SLots
        /// </summary>
        /// <returns></returns>
        public List<int> GetSlots()
        {
            List<int> slots = new List<int>();
            foreach (KeyValuePair<int, int> slot in Equipments)
                slots.Add(slot.Key);
            return slots;
        }
        /// <summary>
        /// Has Skill or Magic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasSkillorMagic(int id)
        {
            SkillData skill = GameData.Skills.GetData(id);
            if (skill != null)
            {
                if (skill.SkillType == SkillType.Magic)
                    return GetMagics().Values.Contains(id);
                else
                    return GetSkills().Values.Contains(id);
            }
            return false;
        }
        /// <summary>
        /// Get Skills
        /// </summary>
        public override ListData GetSkills()
        {
            if (Data.SkillsList > -1)
            {
                return Global.Instance.Lists.GetData(Data.SkillsList);
            }
            return new ListData() { Values = new List<int>() };
        }
        /// <summary>
        /// Get Magics
        /// </summary>
        public override ListData GetMagics()
        {
            if (Data.MagicsList > -1)
            {
                return Global.Instance.Lists.GetData(Data.MagicsList);
            }
            return new ListData() { Values = new List<int>() };
        }
        /// <summary>
        /// Get Equipment
        /// </summary>
        /// <returns></returns>
        public override EquipmentData GetOffensiveEquipment()
        {
            int i = 0;
            EquipmentData firstEquipment = null;
            EquipmentData equipment = null;
            foreach (KeyValuePair<int, int> slot in Equipments)
            {
                equipment = GameData.Equipments.GetData(slot.Value);
                if (equipment != null && equipment.EquipType == EquipType.Offensive)
                {
                    if (firstEquipment == null)
                        firstEquipment = equipment;
                    if (i == equipmentOffensiveActionIndex)
                    {
                        equipmentOffensiveActionIndex++;
                        break;
                    }
                    i++;
                }
                else
                    equipment = null;
            }
            if (i == equipmentOffensiveActionIndex)
                equipmentOffensiveActionIndex = 0;

            if (equipment == null)
                equipment = firstEquipment;

            return LastEquipment = equipment;
        }
        /// <summary>
        /// Returns the current equipment action
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public override int GetEquipmentAction(EquipmentData equipment)
        {
            int index = 0;
            List<int> actions;

            if (equipment != null && equipment.HeroActions.TryGetValue(ID, out actions))
            {
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    if (equipment.ID == slot.Value)
                    {
                        for (int i = 0; i < actions.Count; i++)
                        {
                            if (i == equipmentHeroActionIndex[index])
                            {
                                equipmentHeroActionIndex[index]++;
                                return actions[i];
                            }
                        }
                        equipmentHeroActionIndex[index] = 0;
                        return actions[0];
                    }
                    index++;
                }
            }
            return Data.Actions[(int)EventAction.Attack];
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
        /// Returns the item action
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public override int GetItemAction(ItemData item)
        {
            int action;

            if (item != null && item.HeroActions.TryGetValue(ID, out action))
            {
                if (action > -1)
                    return action;
            }
            return Data.Actions[(int)EventAction.Item];
        }
        /// <summary>
        /// Returns the skill action
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public override int GetSkillAction(SkillData skill)
        {
            int action;

            if (skill != null && skill.HeroActions.TryGetValue(ID, out action))
            {
                if (action > -1)
                    return action;
            }
            return Data.Actions[(int)EventAction.Skill];
        }
        /// <summary>
        /// Apply Value to property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="amount"></param>
        public override void ApplyConstantToProperty(int property, int amount)
        {
            ChangeParameter(property, amount, 1);
        }
        /// <summary>
        /// Apply percentage to property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override int ApplyPercentageToProperty(int property, int amount)
        {
            return ChangeParameter(property, amount, 7);
        }
        /// <summary>
        /// Get Property Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override int GetPropertyValue(int id)
        {
            List<DataProperty> property;
            int level;
            // Get properties for ease of access
            property = Database.Properties;
            level = (int)property[12].Value - 1;
            if (id < 3)
            {
                // Hp, Sp, or Mp
                return (int)property[id].Value;
            }
            else if (id < 12)
            {
                return BonusStats[id - 3] + ((int)((List<int>)property[id].Value)[level]);
            }
            else if (id == 12)
            {
                // Record Old Level
                return level;
            }
            else if (id == 13)
            {
                // Max Level
                return (int)property[id].Value;

            }
            else if (id == 14)
            {
                return experience;
            }
            else
            {
                // Custom Parameter
                DataProperty prop =property.GetData(id);

                if (prop != null && prop.ValueType == DataType.Number)
                {
                    return (int)prop.Value;
                }
            }

            return 0;
        }
        /// <summary>
        /// Get Property Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetModifiedPropertyValue(int id)
        {
            List<DataProperty> property;
            int level;
            // Get properties for ease of access
            property = Database.Properties;
            level = (int)property[12].Value - 1;

            switch (id)
            {
                case 0:
                    return Hp;
                case 1:
                    return Sp;
                case 2:
                    return Mp;
                case 3:
                    return MaxHP;
                case 4:
                    return MaxSP;
                case 5:
                    return MaxMP;
                case 6:
                    return Strength;
                case 7:
                    return Defense;
                case 8:
                    return MagicStr;
                case 9:
                    return MagicDef;
                case 10:
                    return Agility;
                case 11:
                    return Luck;
                default:
                    if (id == 12)
                        return level;
                    else if (id == 13)
                        return (int)property[id].Value;
                    else if (id == 14)
                        return experience;
                    else
                    {
                        // Custom Parameter
                        DataProperty prop =property.GetData(id);

                        if (prop != null && prop.ValueType == DataType.Number)
                        {
                            return (int)prop.Value;
                        }
                    }
                    return 0;
            }
        }
        /// <summary>
        /// Get Property Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetPropertyValue(int id, int levelPlus)
        {
            List<DataProperty> property;
            int level;
            // Get properties for ease of access
            property = Database.Properties;
            level = (int)property[12].Value + levelPlus - 1;

            if (level > (int)property[13].Value - 1)
                level = (int)property[13].Value - 1;
            if (id < 3)
            {
                // Hp, Sp, or Mp
                return (int)property[id].Value;
            }
            else if (id < 12)
            {
                return BonusStats[id - 3] + ((int)((List<int>)property[id].Value)[level]);
            }
            else if (id == 12)
            {
                return level + 1;
            }
            else if (id == 13)
            {
                return (int)property[id].Value;

            }
            else if (id == 14)
            {
                if (levelPlus > 0)
                {
                    List<int> curvelist = ((List<int>)property[14].Value);
                    // Check Level
                    for (int levelIndex = 0; levelIndex < curvelist.Count; levelIndex++)
                    {
                        if (level == levelIndex)
                        {
                            return curvelist[levelIndex];
                        }
                    }
                }
                return experience;
            }
            else
            {
                // Custom Parameter
                DataProperty prop =property.GetData(id);

                if (prop != null && prop.ValueType == DataType.Number)
                {
                    return (int)prop.Value;
                }
            }

            return 0;
        }
        /// <summary>
        /// Get Property Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetModifiedPropertyValue(int id, int levelPlus)
        {
            List<DataProperty> property;
            int level;
            // Get properties for ease of access
            property = Database.Properties;
            level = (int)property[12].Value + levelPlus - 1;

            if (level > (int)property[13].Value - 1)
                level = (int)property[13].Value - 1;
            if (id < 3)
            {
                // Hp, Sp, or Mp
                return (int)property[id].Value;
            }
            else if (id < 12)
            {
                int extra = 0;
                // Loop all equipment
                EquipmentData equipment = null;
                foreach (KeyValuePair<int, int> slot in Equipments)
                {
                    equipment = GameData.Equipments.GetData(slot.Value);
                    if (equipment != null && equipment.Property == id && equipment.ValueType == ItemValueType.Constant)
                        extra += equipment.Value;
                }
                return BonusStats[id - 3] + ((int)((List<int>)property[id].Value)[level]) + extra;
            }
            else if (id == 12)
            {
                // Record Old Level
                return level + 1;
            }
            else if (id == 13)
            {
                // Max Level
                return (int)property[id].Value;
            }
            else if (id == 14)
            {
                if (levelPlus > 0)
                {
                    List<int> curvelist = ((List<int>)property[14].Value);
                    // Check Level
                    for (int levelIndex = 0; levelIndex < curvelist.Count; levelIndex++)
                    {
                        if (level == levelIndex)
                        {
                            return curvelist[levelIndex];
                        }
                    }
                }
                return experience;
            }
            else
            {
                // Custom Parameter
                DataProperty prop = property.GetData(id);

                if (prop != null && prop.ValueType == DataType.Number)
                {
                    return (int)prop.Value;
                }
            }

            return 0;
        }
        /// <summary>
        /// Returns an equipment in range of the given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public EquipmentData GetOffensiveEquipment(int range)
        {
            EquipmentData equipment = null;
            foreach (KeyValuePair<int, int> slot in Equipments)
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

            int value = this.GetModifiedPropertyValue((int)skill.Condition.Value[1]);
            int value2;

            if ((int)skill.Condition.Value[3] == 0)
                value2 = (int)skill.Condition.Value[4];
            else
                value2 = this.GetModifiedPropertyValue((int)skill.Condition.Value[4]);

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

            int value = this.GetModifiedPropertyValue((int)item.Condition.Value[1]);
            int value2;

            if ((int)item.Condition.Value[3] == 0)
                value2 = (int)item.Condition.Value[4];
            else
                value2 = this.GetModifiedPropertyValue((int)item.Condition.Value[4]);

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

        internal void ChangeAnimation(int index, int animation, int action)
        {
            animationId = animation;
            Actions[index] = action;

            EventProcessor ev = Global.Instance.Party.GetPartyMember(id);
            if (ev != null && (int)ev.ActionIndex == index)
            {
                ev.CurrentAnimation = GameData.Animations.GetData(animationId);
                if (ev.CurrentAnimation != null)
                    ev.Animation.Setup(ev.CurrentAnimation.Actions.GetData(Actions[index]), EventAction.Idle);
            }
        }
    }
}
