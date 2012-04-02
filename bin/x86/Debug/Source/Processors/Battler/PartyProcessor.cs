//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Processors;

namespace EGMGame.Library
{
    /// <summary>
    /// Process party operations and hold the party list.
    /// </summary>
    
    public class PartyProcessor
    {
        /// <summary>
        /// Stores the heroes
        /// </summary>
        public List<HeroProcessor> Heroes = new List<HeroProcessor>();
        /// <summary>
        /// The Command the party members follow.
        /// </summary>
        public PartyCommand Command
        {
            get { return pc; }
            set { pc = value; }
        }
        PartyCommand pc = PartyCommand.FollowPlayer;
        /// <summary>
        /// Display Party Members
        /// </summary>
        public bool DisplayPartyMembers=true;
        /// <summary>
        /// Constructor
        /// </summary>
        public PartyProcessor()
        {
        }
        /// <summary>
        /// Add Hero
        /// </summary>
        /// <param name="id">The id of the hero</param>
        /// <param name="reset">Reset all hero's stats</param>
        public void AddHero(int id, bool reset)
        {
            if (Heroes.Count < GameData.Player.MaxPartySize && !Global.Instance.Party.ContainsHero(id))
            {
                HeroProcessor hero;
                if (Global.Instance.Heroes.TryGetValue(id, out hero))
                {
                    if (!Heroes.Contains(hero))
                    {
                        if (reset)
                            hero = new HeroProcessor(id);
                        Heroes.Add(hero);
                        Global.Instance.Heroes[id] = hero;
                    }
                }
                else
                {
                    hero = new HeroProcessor(id);
                    Heroes.Add(hero);
                    Global.Instance.Heroes[id] = hero;
                }
                if (hero != null )
                {
                    // Get the index
                    int index = Heroes.IndexOf(hero);
                    if (Global.Instance.Player.Count <= index)
                    {
                        Global.Instance.Player.Add(new EventProcessor(GameData.Player, (Global.Instance.CurrentMap != null ? Global.Instance.CurrentMap.Data.ID : -1), index));
                        // Add Processor
                        Global.Instance.Player[index].LayerIndex = Global.Instance.Player[0].LayerIndex;
                        if (Global.Instance.CurrentMap != null && DisplayPartyMembers)
                            Global.Instance.CurrentMap.AddProcessor(Global.Instance.Player[index]);
                    }
                    else
                        Global.Instance.Player[index].SetHero(index);

                }
            }
        }
        /// <summary>
        /// Remove hero
        /// </summary>
        /// <param name="id">The id of the hero</param>
        /// <param name="reset">Reset all hero's stats</param>
        public void RemoveHero(int id, bool reset)
        {
            HeroProcessor hero;
            if (Global.Instance.Heroes.TryGetValue(id, out hero))
            {
                // Get the index
                int index = Heroes.IndexOf(hero);
                // Remove hero from party
                Heroes.Remove(hero);
                // Reset
                if (reset)
                    Global.Instance.Heroes[id] = new HeroProcessor(id);

                if (Global.Instance.CurrentMap != null && DisplayPartyMembers)
                {
                    Global.Instance.CurrentMap.RemoveProcessor(Global.Instance.Player[index]);
                }
                Global.Instance.Player.RemoveAt(index);
            }
        }
        /// <summary>
        /// Remove hero at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The id of the removed hero</returns>
        public int RemoveHeroAt(int index)
        {
            if (index > -1 && index < Heroes.Count)
            {
                // Get the index
                HeroProcessor hero = Heroes[index]; int id = hero.ID;
                // Remove hero from party
                Heroes.Remove(hero);
                // Remove Hero
                if (Global.Instance.CurrentMap != null && DisplayPartyMembers)
                {
                    Global.Instance.CurrentMap.RemoveProcessor(Global.Instance.Player[index]);
                }
                Global.Instance.Player.RemoveAt(index);

                return id;
            }
            return -1;
        }
        /// <summary>
        /// Next Member
        /// </summary>
        public void NextMember()
        {
            if (Heroes.Count > 1)
            {
                // Pop first and add to end
                int i = 0;
                while (i < Heroes.Count)
                {
                    HeroProcessor hero = Heroes[0];
                    Heroes.RemoveAt(0);
                    Heroes.Add(hero);

                    EventProcessor[] players = new EventProcessor[Heroes.Count];

                    for (int k = 0; k < players.Length; k++)
                        players[k] = Global.Instance.Player[k];
                    for (int x = 0; x < players.Length; x++)
                    {
                        if (x + 1 < players.Length)
                            Global.Instance.Player[x] = players[x + 1];
                        else
                            Global.Instance.Player[x] = players[0];
                        Global.Instance.Player[x].PartyIndex = x;
                    }

                    if (Heroes[0].IsDead())
                        i++;
                    else
                        break;
                }
            }
        }
        /// <summary>
        /// Last Member
        /// </summary>
        public void LastMember()
        {
            if (Heroes.Count > 1)
            {
                // Pop first and add to end
                int i = 0;
                while (i < Heroes.Count)
                {
                    HeroProcessor hero = Heroes[Heroes.Count - 1];
                    Heroes.RemoveAt(Heroes.Count - 1);
                    Heroes.Insert(0, hero);
                    EventProcessor[] players = new EventProcessor[Heroes.Count];

                    for (int k = players.Length - 1; k >= 0; k--)
                        players[k] = Global.Instance.Player[k];
                    for (int x = players.Length - 1; x >= 0; x--)
                    {
                        if (x - 1 > 0)
                            Global.Instance.Player[x] = players[x - 1];
                        else
                            Global.Instance.Player[x] = players[players.Length - 1];
                        Global.Instance.Player[x].PartyIndex = x;
                        Global.Instance.Player[x].SetAnimationAndAction();
                    }

                    if (Heroes[Heroes.Count - 1].IsDead())
                        i++;
                    else
                        break;
                }
            }
        }
        /// <summary>
        /// Heal all members
        /// </summary>
        public void HealAll()
        {
            // Heal All Heroes
            for (int heroIndex = 0; heroIndex < Heroes.Count; heroIndex++)
            {
                if (Heroes[heroIndex].Database != null)
                    Heroes[heroIndex].HealAll();
            }
        }
        /// <summary>
        /// Get Hero
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public HeroProcessor GetHero(int heroId)
        {
            HeroProcessor hero;
            if (Global.Instance.Heroes.TryGetValue(heroId, out hero))
                return hero;
            else
            {
                hero = new HeroProcessor(heroId);
                Global.Instance.Heroes.Add(heroId, hero);
                return hero;
            }
        }
        /// <summary>
        /// Remove Equipment
        /// </summary>
        /// <param name="id"></param>
        public void RemoveEquipment(int id)
        {
            foreach (HeroProcessor hero in Heroes)
            {
                // Remove equipment
                foreach (int slot in hero.Equipments.Keys)
                {
                    if (hero.Equipments[slot] == id)
                        hero.Equipments[slot] = -1;
                }
            }
        }
        /// <summary>
        /// Returns the party's avarage level.
        /// </summary>
        /// <returns></returns>
        public int Level()
        {
            int total = 0;
            foreach (HeroProcessor hero in Heroes)
            {
                total += hero.Level;
            }
            return total / Heroes.Count;
        }
        /// <summary>
        /// Get Party Member
        /// </summary>
        /// <param name="heroId"></param>
        /// <returns></returns>
        public EventProcessor GetPartyMember(int heroId)
        {
            // Get Hero Processor
            HeroProcessor hp = GetHero(heroId);
            // Loop player events to find hero
            for (int i = 0; i < Global.Instance.Player.Count; i++)
            {
                if (Global.Instance.Player[i].Battler.ID == hp.ID)
                    return Global.Instance.Player[i];
            }
            return null;
        }
        /// <summary>
        /// Checks if all party is dead
        /// </summary>
        /// <returns></returns>
        public bool IsDead()
        {
            // Loop player events to find hero
            for (int i = 0; i < Global.Instance.Player.Count; i++)
            {
                if (!Global.Instance.Player[i].Battler.IsDead())
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Checks whether the party member at the given index can use the skill
        /// </summary>
        /// <param name="partyIndex"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public bool CanUseSkill(int partyIndex, SkillData skill)
        {
            if (partyIndex > -1 && partyIndex < Heroes.Count)
                return Heroes[partyIndex].CanUseSkill(skill);
            return false;
        }
        /// <summary>
        /// Can Use Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CanUseItem(int partyIndex, ItemData item)
        {
            if (partyIndex > -1 && partyIndex < Heroes.Count)
                return Heroes[partyIndex].CanUseItem(item);
            return false;
        }
        /// <summary>
        /// Checks whether the party can be effected by the skill
        /// </summary>
        /// <param name="partyIndex"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public bool CanSkillEffect(SkillData skill)
        {
            bool result = false;
            for (int partyIndex = 0; partyIndex < Heroes.Count; partyIndex++)
            {
                int value = Heroes[partyIndex].GetModifiedPropertyValue((int)skill.Condition.Value[1]);
                int value2;

                if ((int)skill.Condition.Value[3] == 0)
                    value2 = (int)skill.Condition.Value[4];
                else
                    value2 = Heroes[partyIndex].GetModifiedPropertyValue((int)skill.Condition.Value[4]);

                switch ((int)skill.Condition.Value[2])
                {
                    case 0: //Equals (=)
                        result = (value == value2);
                        break;
                    case 1: //Greater Than (>)
                        result = (value > value2);
                        break;
                    case 2: //Less Than (<)
                        result = (value < value2);
                        break;
                    case 3: //Greater Than Or Equals (>=)
                        result = (value >= value2);
                        break;
                    case 4: //Less Than Or Equals (<=)
                        result = (value <= value2);
                        break;
                    case 5: //Does Not Equal (!=)
                        result = (value != value2);
                        break;
                }

                if (skill.Scope == ItemScope.AllPartyDead || skill.Scope == ItemScope.OneAllyDead)
                {
                    if (Heroes[partyIndex].IsDead())
                        return true;
                    else
                        result = false;
                }
                else
                {
                    if (Heroes[partyIndex].IsDead())
                        result = false;
                }

                if (result)
                    return true;
            }
            return result;
        }
        /// <summary>
        /// Checks whether the party member at the given index can be effected by the skill
        /// </summary>
        /// <param name="partyIndex"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public bool CanSkillEffect(int partyIndex, SkillData skill)
        {
            if (partyIndex > -1 && partyIndex < Heroes.Count)
            {
                if (skill.Scope == ItemScope.AllPartyDead || skill.Scope == ItemScope.OneAllyDead)
                {
                    if (Heroes[partyIndex].IsDead())
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (Heroes[partyIndex].IsDead())
                        return false;
                }

                int value = Heroes[partyIndex].GetModifiedPropertyValue((int)skill.Condition.Value[1]);
                int value2;

                if ((int)skill.Condition.Value[3] == 0)
                    value2 = (int)skill.Condition.Value[4];
                else
                    value2 = Heroes[partyIndex].GetModifiedPropertyValue((int)skill.Condition.Value[4]);

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

            }
            return false;
        }
        /// <summary>
        /// Checks whether the party can be effected by the skill
        /// </summary>
        /// <param name="partyIndex"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public bool CanItemEffect(ItemData item)
        {
            bool result = false;
            for (int partyIndex = 0; partyIndex < Heroes.Count; partyIndex++)
            {
                int value = Heroes[partyIndex].GetModifiedPropertyValue((int)item.Condition.Value[1]);
                int value2;

                if ((int)item.Condition.Value[3] == 0)
                    value2 = (int)item.Condition.Value[4];
                else
                    value2 = Heroes[partyIndex].GetModifiedPropertyValue((int)item.Condition.Value[4]);

                switch ((int)item.Condition.Value[2])
                {
                    case 0: //Equals (=)
                        result = (value == value2);
                        break;
                    case 1: //Greater Than (>)
                        result = (value > value2);
                        break;
                    case 2: //Less Than (<)
                        result = (value < value2);
                        break;
                    case 3: //Greater Than Or Equals (>=)
                        result = (value >= value2);
                        break;
                    case 4: //Less Than Or Equals (<=)
                        result = (value <= value2);
                        break;
                    case 5: //Does Not Equal (!=)
                        result = (value != value2);
                        break;
                }
                if (item.Scope == ItemScope.AllPartyDead || item.Scope == ItemScope.OneAllyDead)
                {
                    if (Heroes[partyIndex].IsDead())
                        return true;
                    else
                        result = false;
                }
                else
                {
                    if (Heroes[partyIndex].IsDead())
                        result = false;
                }
                if (result)
                    return true;
            }
            return result;
        }
        /// <summary>
        /// Checks whether the party member at the given index can be effected by the skill
        /// </summary>
        /// <param name="partyIndex"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public bool CanItemEffect(int partyIndex, ItemData item)
        {
            if (partyIndex > -1 && partyIndex < Heroes.Count)
            {
                if (item.Scope == ItemScope.AllPartyDead || item.Scope == ItemScope.OneAllyDead)
                {
                    if (Heroes[partyIndex].IsDead())
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (Heroes[partyIndex].IsDead())
                        return false;
                }

                int value = Heroes[partyIndex].GetModifiedPropertyValue((int)item.Condition.Value[1]);
                int value2;

                if ((int)item.Condition.Value[3] == 0)
                    value2 = (int)item.Condition.Value[4];
                else
                    value2 = Heroes[partyIndex].GetModifiedPropertyValue((int)item.Condition.Value[4]);

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

            }
            return false;
        }
        /// <summary>
        /// Get Party Member From Index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HeroProcessor GetPartyMemberFromIndex(int partyIndex)
        {
            if (partyIndex > -1 && partyIndex < Heroes.Count)
                return Heroes[partyIndex];
            return null;
        }
        /// <summary>
        /// Check if any of the party members have this item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasItem(int id)
        {
            for (int i = 0; i < Heroes.Count; i++)
            {
                if (Heroes[i].HasItem(id)) return true;
            } return false;
        }
        /// <summary>
        /// Check if any of the party members have this equipment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasEquipment(int id)
        {
            for (int i = 0; i < Heroes.Count; i++)
            {
                if (Heroes[i].HasEquipment(id)) return true;
            } return false;
        }
        /// <summary>
        /// Contains Hero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ContainsHero(int id)
        {
            for (int i = 0; i < Heroes.Count; i++)
            {
                if (Heroes[i].ID == id)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Contains Hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public bool ContainsHero(HeroProcessor hero)
        {
            return Heroes.Contains(hero);
        }

    }

    public enum PartyCommand
    {
        FollowPlayer,
        HoldArea,
        SearchAndDestroy
    }
}
