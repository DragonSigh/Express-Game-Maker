using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using EGMGame.Extensions;
using EGMGame.Interfaces;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FarseerPhysics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Controllers;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;
using EGMGame.Processors;
using EGMGame;
using Microsoft.Xna.Framework.Storage;

namespace EGMGame.Components
{
    public class Interpreter : Drawable
    {
        #region Method: Process Categories
        /// <summary>
        /// Process Graphics Commands
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="index"></param>
        public void ProcessCategoryGraphics(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1:
                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Battle
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryBattle(EventProgramData eventProgramData, ref int index, EventProcessor parent)
        {
            EventProcessor ev = null;
            switch (eventProgramData.Code)
            {
                case 1: // Command Player
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0:
                            if ((int)eventProgramData.Value[1] > -1 && (int)eventProgramData.Value[1] < Global.Instance.Player.Count)
                                ev = Global.Instance.Player[(int)eventProgramData.Value[1]];
                            break;
                        case 1:
                            ev = Global.Instance.Party.GetPartyMember((int)eventProgramData.Value[1]);
                            break;
                    }
                    if (ev != null)
                    {
                        switch ((int)eventProgramData.Value[2])
                        {
                            case 0: // Attack
                                ev.Attack();
                                break;
                            case 1: // Defend
                                ev.Defend();
                                break;
                        }
                    }
                    index++; NextProgram(); break;
                case 2: // Command ALlies
                    Global.Instance.Party.Command = (PartyCommand)eventProgramData.Value[0];
                    index++; NextProgram(); break;
                case 3: // Assign Ally As Target
                    if (parent != null)
                    {
                        switch ((int)eventProgramData.Value[0])
                        {
                            case 0:
                                if ((int)eventProgramData.Value[1] > -1 && (int)eventProgramData.Value[1] < Global.Instance.Player.Count)
                                    ev = Global.Instance.Player[(int)eventProgramData.Value[1]];
                                break;
                            case 1:
                                ev = Global.Instance.Party.GetPartyMember((int)eventProgramData.Value[1]);
                                break;
                        }
                        parent.Target = ev;
                    }
                    index++; NextProgram(); break;
                case 4: // Find Target(s)
                    if (parent != null)
                    {
                        parent.Targets = parent.GetTargets((int)eventProgramData.Value[0], (bool)eventProgramData.Value[1], ((int)eventProgramData.Value[2] == 0 ? parent.Angle : (int)eventProgramData.Value[3]));
                        if (parent.Targets.Count > 0)
                            parent.Target = parent.Targets[0];
                    }
                    index++; NextProgram(); break;
                case 5: // Force Attack
                    if (parent != null)
                    {
                        parent.Attack();
                    }
                    index++; NextProgram(); break;
                case 6: // Use Item
                    if (parent != null)
                        parent.UseItem((int)eventProgramData.Value[0], (bool)eventProgramData.Value[1], (bool)eventProgramData.Value[2]);
                    index++; NextProgram(); break;
                case 7: // Use Skill/Magic
                    if (parent != null)
                        parent.UseSkill((int)eventProgramData.Value[0], (bool)eventProgramData.Value[1], (bool)eventProgramData.Value[2]);
                    index++; NextProgram(); break;
                case 8: // Battle Conditions
                    if (parent != null)
                        CheckBattleCondition(eventProgramData, parent);
                    index++; NextProgram(); break;
                case 9: // Clear Experience
                    Global.Instance.LastExpGained = 0;
                    Global.Instance.TotalExpGained = 0;
                    index++; NextProgram(); break;
                case 10: // Force Use Slot
                    parent.ForceUseSlot((int)eventProgramData.Value[0]);
                    index++; NextProgram(); break;
                case 11: // Indestructible
                    if (parent != null)
                    {
                        switch ((int)eventProgramData.Value[1])
                        {
                            case 0: // This
                                if (parent.Battler != null)
                                    parent.Battler.Indestructible = ((int)eventProgramData.Value[0] == 0);
                                break;
                            case 1: // Party Member
                                int p = (int)eventProgramData.Value[2];
                                if (p < Global.Instance.Party.Heroes.Count)
                                    Global.Instance.Party.Heroes[p].Indestructible = ((int)eventProgramData.Value[0] == 0);
                                break;
                        }
                    }
                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Party
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryParty(EventProgramData eventProgramData, ref int index)
        {
            int partyIndex;
            switch (eventProgramData.Code)
            {
                case 1: // Change Party Member
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Add
                            Global.Instance.Party.AddHero((int)eventProgramData.Value[0], (bool)eventProgramData.Value[2]);
                            break;
                        case 1: // Remove
                            Global.Instance.Party.RemoveHero((int)eventProgramData.Value[0], (bool)eventProgramData.Value[2]);
                            break;
                    }
                    index++; NextProgram(); break;
                case 2: // Next Party Member
                    Global.Instance.Party.NextMember();
                    index++; NextProgram(); break;
                case 3: // Previous Party Member
                    Global.Instance.Party.LastMember();
                    index++; NextProgram(); break;
                case 4: // Heal All Party
                    Global.Instance.Party.HealAll();
                    index++; NextProgram(); break;
                case 5: // Party Conditions
                    CheckPartyConditions(eventProgramData);
                    index++; NextProgram(); break;
                case 6: // Use Item
                    int itemId = (int)Global.Variable((int)eventProgramData.Value[0]);
                    ItemData item = GameData.Items.GetData(itemId);
                    if (item != null)
                    {
                        HeroProcessor hero = Global.Instance.Party.GetPartyMemberFromIndex((int)Global.Variable((int)eventProgramData.Value[1]));
                        if (hero != null && (item.Scope == ItemScope.User || item.Scope == ItemScope.OneHero || item.Scope == ItemScope.OneAllyDead))
                        {
                            for (int i = 0; i < item.Effects.Count; i++)
                                Battle.UseItem(hero, item, i);
                            // Item Used
                            if ((bool)eventProgramData.Value[4])
                            {
                                // Remove Item
                                switch ((int)eventProgramData.Value[2])
                                {
                                    case 0: // Party Member.
                                        hero = Global.Instance.Party.GetPartyMemberFromIndex((int)Global.Variable((int)eventProgramData.Value[3]));
                                        if (hero != null)
                                            hero.RemoveItem(item.ID);
                                        break;
                                    case 1: // List
                                        ListData items = Global.Instance.Lists.GetData((int)eventProgramData.Value[3]);
                                        // Items
                                        if (items != null && item != null && item.Consumable)
                                            items.Values.Remove(item.ID);
                                        break;
                                }
                            }
                        }
                        else if (item.Scope == ItemScope.AllAllies || item.Scope == ItemScope.AllPartyDead)
                        {
                            for (int j = 0; j < Global.Instance.Party.Heroes.Count; j++)
                            {
                                hero = Global.Instance.Party.Heroes[j];
                                for (int i = 0; i < item.Effects.Count; i++)
                                    Battle.UseItem(hero, item, i);
                            }
                            // Item Used
                            if ((bool)eventProgramData.Value[4])
                            {
                                // Remove Item
                                switch ((int)eventProgramData.Value[2])
                                {
                                    case 0: // Party Member.
                                        hero = Global.Instance.Party.GetPartyMemberFromIndex((int)Global.Variable((int)eventProgramData.Value[3]));
                                        if (hero != null)
                                            hero.RemoveItem(item.ID);
                                        break;
                                    case 1: // List
                                        ListData items = Global.Instance.Lists.GetData((int)eventProgramData.Value[3]);
                                        // Items
                                        if (items != null && item != null && item.Consumable)
                                            items.Values.Remove(item.ID);
                                        break;
                                }
                            }
                        }
                    }
                    index++; NextProgram(); break;
                case 7: // Use Skill
                    int skillId = (int)Global.Variable((int)eventProgramData.Value[0]);
                    SkillData skill = GameData.Skills.GetData(skillId);
                    if (skill != null)
                    {
                        HeroProcessor hero = Global.Instance.Party.GetPartyMemberFromIndex((int)Global.Variable((int)eventProgramData.Value[1]));
                        HeroProcessor user = Global.Instance.Party.GetPartyMemberFromIndex((int)Global.Variable((int)eventProgramData.Value[2]));
                        if (hero != null && user != null && (skill.Scope == ItemScope.User || skill.Scope == ItemScope.OneHero || skill.Scope == ItemScope.OneAllyDead))
                        {
                            for (int i = 0; i < skill.Effects.Count; i++)
                            {
                                if (skill.Effects[i].Scope == EffectScope.User)
                                    Battle.UseSkill(user, user, skill, i);
                                else
                                    Battle.UseSkill(user, hero, skill, i);
                            }
                            // Skill Used
                            if ((bool)eventProgramData.Value[3])
                            {
                                // Apply Cost
                                user.SkillCost(skill.Cost, skill.CostID);
                            }
                        }
                        else if (user != null && (skill.Scope == ItemScope.AllAllies || skill.Scope == ItemScope.AllPartyDead))
                        {
                            for (int j = 0; j < Global.Instance.Party.Heroes.Count; j++)
                            {
                                hero = Global.Instance.Party.Heroes[j];
                                for (int i = 0; i < skill.Effects.Count; i++)
                                {
                                    if (skill.Effects[i].Scope == EffectScope.User)
                                        Battle.UseSkill(user, user, skill, i);
                                    else
                                        Battle.UseSkill(user, hero, skill, i);
                                }
                            }
                            // Skill Used
                            if ((bool)eventProgramData.Value[3])
                            {
                                // Apply Cost
                                user.SkillCost(skill.Cost, skill.CostID);
                            }
                        }
                    }
                    index++; NextProgram(); break;
                case 8: // Change Equipment
                    HeroProcessor heroE = Global.Instance.Party.GetPartyMemberFromIndex((int)Global.Variable((int)eventProgramData.Value[0]));
                    heroE.Equip((int)Global.Variable((int)eventProgramData.Value[2]), (int)Global.Variable((int)eventProgramData.Value[1]), (bool)eventProgramData.Value[3]);
                    index++; NextProgram(); break;
                case 9: // Change Items
                    partyIndex = (int)Global.Variable((int)eventProgramData.Value[0]);

                    if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                    {
                        int value = 0;
                        // Get Value
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Constant
                                value = (int)eventProgramData.Value[4];
                                break;
                            case 1: // Varaible
                                value = (int)Global.Instance.Variables[(int)eventProgramData.Value[4]].Value;
                                break;
                        }
                        // Get Operation
                        for (int x = 0; x < value; x++)
                        {
                            switch ((int)eventProgramData.Value[2])
                            {
                                case 0: // Increase
                                    Global.Instance.Party.Heroes[partyIndex].AddItem((int)Global.Variable((int)eventProgramData.Value[1]));
                                    break;
                                case 1: // Decrease
                                    Global.Instance.Party.Heroes[partyIndex].RemoveItem((int)Global.Variable((int)eventProgramData.Value[1]));
                                    break;
                            }
                        }
                    }
                    index++; NextProgram(); break;
                case 10: // Change Equipments
                    partyIndex = (int)Global.Variable((int)eventProgramData.Value[0]);

                    if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                    {
                        int value = 0;
                        // Get Value
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Constant
                                value = (int)eventProgramData.Value[4];
                                break;
                            case 1: // Varaible
                                value = (int)Global.Instance.Variables[(int)eventProgramData.Value[4]].Value;
                                break;
                        }
                        // Get Operation
                        for (int x = 0; x < value; x++)
                        {
                            switch ((int)eventProgramData.Value[2])
                            {
                                case 0: // Increase
                                    Global.Instance.Party.Heroes[partyIndex].AddEquipment((int)Global.Variable((int)eventProgramData.Value[1]));
                                    break;
                                case 1: // Decrease
                                    Global.Instance.Party.Heroes[partyIndex].RemoveEquipment((int)Global.Variable((int)eventProgramData.Value[1]));
                                    break;
                            }
                        }
                    }
                    index++; NextProgram(); break;
                case 11: // Show/Hide Party
                    if ((int)eventProgramData.Value[0] == 0 && !Global.Instance.Party.DisplayPartyMembers) // Show
                    {
                        Global.Instance.Party.DisplayPartyMembers = true;
                        if (Global.Instance.CurrentMap != null)
                        {
                            for (int i = 1; i < Global.Instance.Party.Heroes.Count; i++)
                            {
                                Global.Instance.CurrentMap.AddProcessor(Global.Instance.Player[i]);
                                Global.Instance.Player[i].Position = Global.Instance.Player[0].Position;
                            }
                        }
                    }
                    else if ((int)eventProgramData.Value[0] == 1 && Global.Instance.Party.DisplayPartyMembers) // Hide
                    {
                        Global.Instance.Party.DisplayPartyMembers = false;
                        if (Global.Instance.CurrentMap != null)
                        {
                            for (int i = 1; i < Global.Instance.Party.Heroes.Count; i++)
                            {
                                Global.Instance.CurrentMap.RemoveProcessor(Global.Instance.Player[i]);
                            }
                        }
                    }
                    index++; NextProgram(); break;
                case 12: // Insert Party Member From List
                    ListData fromList = GameData.Lists.GetData((int)eventProgramData.Value[0]);
                    if (fromList != null)
                    {
                        int ix = (int)GetValue(1, (int)eventProgramData.Value[1]);

                        if (ix > -1 && ix < fromList.Values.Count)
                        {
                            Global.Instance.Party.AddHero(fromList.Values[ix], (bool)eventProgramData.Value[3]);

                            if ((bool)eventProgramData.Value[2])
                                fromList.Values.RemoveAt(ix);
                        }
                    }
                    index++; NextProgram(); break;
                case 13: // Remove Party Member and Insert To List
                    int removeIndex = (int)GetValue(1, (int)eventProgramData.Value[0]);
                    int removedId = Global.Instance.Party.RemoveHeroAt(removeIndex);
                    if ((bool)eventProgramData.Value[1])
                    {
                        ListData addToList = GameData.Lists.GetData((int)eventProgramData.Value[0]);
                        if (addToList != null)
                        {
                            addToList.Values.Add(removedId);
                        }
                    }
                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Hero
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryHero(EventProgramData eventProgramData, ref int index)
        {
            HeroProcessor hero;
            int value = -1;
            switch (eventProgramData.Code)
            {
                case 1: // Change Name
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);
                    // Type
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Constant
                            hero.Name = eventProgramData.Value[2].ToString();
                            break;
                        case 1: // String
                            StringData str = Global.Instance.Strings.GetData((int)eventProgramData.Value[2]);
                            if (str != null)
                                hero.Name = str.Value;
                            break;
                    }

                    index++; NextProgram(); break;
                case 2: // Change Equipment
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);
                    hero.Equip((int)eventProgramData.Value[1], (int)eventProgramData.Value[2], (bool)eventProgramData.Value[3]);
                    index++; NextProgram(); break;
                case 3: // Change State
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);

                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Add 
                            hero.AddState((int)eventProgramData.Value[2]);
                            break;
                        case 1: // Remove
                            hero.RemoveState((int)eventProgramData.Value[2]);
                            break;
                    }
                    index++; NextProgram(); break;
                case 4: // Heal All
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);
                    hero.HealAll();
                    index++; NextProgram(); break;
                case 5: // Skill
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Learn
                            hero.LearnSkill((int)eventProgramData.Value[2]);
                            break;
                        case 1: // Forget
                            hero.ForgetSkill((int)eventProgramData.Value[2]);
                            break;
                    }
                    index++; NextProgram(); break;
                case 6: // Magic
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Learn
                            hero.LearnMagic((int)eventProgramData.Value[2]);
                            break;
                        case 1: // Forget
                            hero.ForgetMagic((int)eventProgramData.Value[2]);
                            break;
                    }
                    index++; NextProgram(); break;
                case 7: // Parameter
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);
                    // Get Value
                    switch ((int)eventProgramData.Value[3])
                    {
                        case 0: // Constant
                            value = (int)eventProgramData.Value[4];
                            break;
                        case 1: // Random
                            Random rand = new Random();
                            value = rand.Next((int)eventProgramData.Value[4], (int)eventProgramData.Value[5]);
                            break;
                        case 2: // Varaible
                            value = (int)Global.Instance.Variables[(int)eventProgramData.Value[4]].Value;
                            break;
                        case 3: // Local Variable
                            value = (int)Variables[(int)eventProgramData.Value[4]].Value;
                            break;
                    }
                    hero.ChangeParameter((int)eventProgramData.Value[1], value, (int)eventProgramData.Value[2]);
                    if ((bool)eventProgramData.Value[6])
                        Global.DisplayDamage(value, true, Global.Instance.Party.GetPartyMember(hero.ID), 144);

                    index++; NextProgram(); break;
                case 8: // Change Items
                    // Items List
                    ListData items = Global.Instance.Lists.GetData((int)eventProgramData.Value[0]);
                    // Get Value
                    switch ((int)eventProgramData.Value[3])
                    {
                        case 0: // Constant
                            value = (int)eventProgramData.Value[4];
                            break;
                        case 1: // Varaible
                            value = (int)Global.Instance.Variables[(int)eventProgramData.Value[4]].Value;
                            break;
                    }
                    // Get Operation
                    for (int x = 0; x < value; x++)
                    {
                        switch ((int)eventProgramData.Value[2])
                        {
                            case 0: // Increase
                                items.Values.Add((int)eventProgramData.Value[1]);
                                break;
                            case 1: // Decrease
                                items.Values.Remove((int)eventProgramData.Value[1]);
                                break;
                        }
                    }
                    index++; NextProgram(); break;
                case 9: // Change Equipments
                    // Items List
                    ListData equipments = Global.Instance.Lists.GetData((int)eventProgramData.Value[0]);
                    // Get Value
                    switch ((int)eventProgramData.Value[3])
                    {
                        case 0: // Constant
                            value = (int)eventProgramData.Value[4];
                            break;
                        case 1: // Varaible
                            value = (int)Global.Instance.Variables[(int)eventProgramData.Value[4]].Value;
                            break;
                    }
                    // Get Operation
                    for (int x = 0; x < value; x++)
                    {
                        switch ((int)eventProgramData.Value[2])
                        {
                            case 0: // Increase
                                equipments.Values.Add((int)eventProgramData.Value[1]);
                                break;
                            case 1: // Decrease
                                if ((bool)eventProgramData.Value[5] && !equipments.Values.Contains((int)eventProgramData.Value[1]))
                                    Global.Instance.Party.RemoveEquipment((int)eventProgramData.Value[1]);
                                else
                                    equipments.Values.Remove((int)eventProgramData.Value[1]);
                                break;
                        }
                    }
                    index++; NextProgram(); break;
                case 10: // Change Hero Animation
                    // Get Hero
                    hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);
                    hero.ChangeAnimation((int)eventProgramData.Value[1], (int)eventProgramData.Value[2], (int)eventProgramData.Value[3]);
                    break;
            }
        }
        /// <summary>
        /// Process Category Screen
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryDisplay(EventProgramData eventProgramData, ref int index)
        {
            int x = 0, y = 0;
            switch (eventProgramData.Code)
            {
                case 1: // Show Message
                    actionTakingPlace = ActionType.Message;
                    waitActionCompelition = (bool)eventProgramData.Value[8];
                    Global.SetupMessage(eventProgramData, this);
                    index++; NextProgram();
                    break;
                case 2: // Show Menu
                    actionTakingPlace = ActionType.Menu;
                    waitActionCompelition = (bool)eventProgramData.Value[3];
                    Global.ShowMenu((int)eventProgramData.Value[0], (bool)eventProgramData.Value[1], (bool)eventProgramData.Value[2], (bool)eventProgramData.Value[3], (bool)eventProgramData.Value[4], (bool)eventProgramData.Value[5], this);
                    index++; NextProgram();
                    break;
                case 3: // Show Picture
                    switch ((int)eventProgramData.Value[5])
                    {
                        case 0: // Coordinate
                            x = (int)eventProgramData.Value[6];
                            y = (int)eventProgramData.Value[7];
                            break;
                        case 1:// Varaibles
                            x = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[6]).Value;
                            y = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[7]).Value;
                            break;
                    }
                    Global.ShowPicture(
                        (int)eventProgramData.Value[0],
                        (int)eventProgramData.Value[9],
                        (int)eventProgramData.Value[1],
                        (bool)eventProgramData.Value[2],
                        (int)eventProgramData.Value[3],
                        (int)eventProgramData.Value[4],
                        (int)eventProgramData.Value[5],
                        (int)eventProgramData.Value[10],
                        x, y,
                        ((bool)eventProgramData.Value[8] == true ? ScreenType.Global : ScreenType.Gameplay)
                    );
                    index++; NextProgram(); break;
                case 4: // Clear Picture    
                    Global.ClearPicture((int)eventProgramData.Value[0]);
                    index++; NextProgram(); break;
                case 5: // Show Animation
                    switch ((int)eventProgramData.Value[3])
                    {
                        case 0: // Coordinate
                            Global.ShowAnimation(ScreenType.Gameplay,
                                (int)eventProgramData.Value[7],
                                (int)eventProgramData.Value[6],
                                (int)eventProgramData.Value[0],
                                (int)eventProgramData.Value[1],
                                (int)eventProgramData.Value[2],
                                (int)eventProgramData.Value[4],
                                (int)eventProgramData.Value[5]);
                            break;
                        case 1:// Varaible
                            Global.ShowAnimation(ScreenType.Gameplay,
                                    (int)eventProgramData.Value[7],
                                    (int)eventProgramData.Value[6],
                                    (int)eventProgramData.Value[0],
                                    (int)eventProgramData.Value[1],
                                    (int)eventProgramData.Value[2],
                                    (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[4]).Value,
                                    (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[5]).Value);
                            break;
                        case 2: // Event
                            Global.Instance.CurrentMap.ShowAnimationOnEvent(
                                (int)eventProgramData.Value[0],
                                (int)eventProgramData.Value[1],
                                (int)eventProgramData.Value[2],
                                (int)eventProgramData.Value[4]);
                            break;
                    }
                    index++; NextProgram(); break;
                case 6: // Show Video
#if !SILVERLIGHT
                    int xVid = 0, yVid = 0;
                    switch ((int)eventProgramData.Value[4])
                    {
                        case 0: // Coordinate
                            xVid = (int)eventProgramData.Value[5];
                            yVid = (int)eventProgramData.Value[6];
                            break;
                        case 1:// Varaibles
                            VariableData varVidX = Global.Instance.Variables.GetData((int)eventProgramData.Value[5]);
                            VariableData varVidY = Global.Instance.Variables.GetData((int)eventProgramData.Value[6]);
                            if (varVidX != null)
                                xVid = (int)varVidX.Value;
                            if (varVidY != null)
                                yVid = (int)varVidY.Value;
                            break;
                    }

                    Global.SetupVideo((int)eventProgramData.Value[0], xVid, yVid, (bool)eventProgramData.Value[7], (int)eventProgramData.Value[1], (int)eventProgramData.Value[2], (int)eventProgramData.Value[3]);

                    actionTakingPlace = ActionType.Video;
                    if ((bool)eventProgramData.Value[9])
                        Global.Instance.Pause = PauseAction.Video;
#endif
                    index++; NextProgram(); break;
                case 7: // Video Controls
#if !SILVERLIGHT
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0: // Play
                            Global.VideoPlayer.Play();
                            break;
                        case 1: // Pause
                            Global.VideoPlayer.Pause();
                            break;
                        case 2: // Clear
                            Global.VideoPlayer.Clear();
                            break;
                    }
#endif
                    index++; NextProgram(); break;
                case 8: // Move Picture
                    switch ((int)eventProgramData.Value[4])
                    {
                        case 0: // Coordinate
                            x = (int)eventProgramData.Value[5];
                            y = (int)eventProgramData.Value[6];
                            break;
                        case 1:// Varaibles
                            x = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[5]).Value;
                            y = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[6]).Value;
                            break;
                    }
                    Global.MovePicture(
                        (int)eventProgramData.Value[0],
                        (bool)eventProgramData.Value[1],
                        (int)eventProgramData.Value[2],
                        (int)eventProgramData.Value[3],
                        x, y
                    );
                    index++; NextProgram(); break;
                case 9: // Tint Picture
                    Global.TintPicture(
                        (int)eventProgramData.Value[0],
                        (Color)eventProgramData.Value[1],
                        (int)eventProgramData.Value[2]);
                    actionTakingPlace = ActionType.PictureTint;
                    if ((bool)eventProgramData.Value[3])
                        waitFrames = (int)eventProgramData.Value[2];
                    index++; if (!waitActionCompelition) NextProgram();
                    break;
                case 10: // Change Cursor
                    Global.Project.CursorMaterial = (int)eventProgramData.Value[0];
                    break;
                case 11: // Show Particle
                    switch ((int)eventProgramData.Value[2])
                    {
                        case 0: // Coordinate
                            x = (int)eventProgramData.Value[3];
                            y = (int)eventProgramData.Value[4];
                            break;
                        case 1:// Varaibles
                            x = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[3]).Value;
                            y = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[4]).Value;
                            break;
                        case 2: // Event
                            EventProcessor eprocessor = GetEvent((int)eventProgramData.Value[3]);
                            if (eprocessor != null)
                            {
                                x = (int)eprocessor.Position.X;
                                y = (int)eprocessor.Position.Y;
                            }
                            break;
                    }
                    Global.ShowParticle(
                        (int)eventProgramData.Value[0],
                        (int)eventProgramData.Value[1],
                        x, y, (int)eventProgramData.Value[6],
                        ((bool)eventProgramData.Value[5] == true ? ScreenType.Global : ScreenType.Gameplay)
                    );
                    index++; NextProgram(); break;
                case 12: // Move Particle
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Coordinate
                            x = (int)eventProgramData.Value[2];
                            y = (int)eventProgramData.Value[3];
                            break;
                        case 1:// Varaibles
                            x = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[2]).Value;
                            y = (int)Global.Instance.Variables.GetData((int)eventProgramData.Value[3]).Value;
                            break;
                    }
                    Global.MoveParticle(
                        (int)eventProgramData.Value[0],
                        x, y
                    );
                    index++; NextProgram(); break;
                case 13: // Clear Particle
                    Global.ClearParticle((int)eventProgramData.Value[0]);
                    index++; NextProgram(); break;
                case 14: // Set Options
                    Global.Instance.MenuOptions = (List<object>)eventProgramData.Value[0];
                    index++; NextProgram(); break;
                case 15: // Show Shop
                    Global.ShopItems = (List<int>)eventProgramData.Value[1];
                    Global.ShopEquipments = (List<int>)eventProgramData.Value[2];

                    Global.ShowMenu((int)eventProgramData.Value[0], true, true, true, false, false, this);
                    actionTakingPlace = ActionType.Menu;
                    index++;
                    break;
                case 16: // Close HUD
                    Global.CloseHUD();
                    index++; NextProgram(); break;
                case 17: // Close Menu
                    Global.CloseMenu((int)eventProgramData.Value[0]);
                    index++; NextProgram(); break;
                case 18: // Scale Picture
                    if (Global.Instance.Pictures[(int)eventProgramData.Value[0]] != null)
                    {

                        Global.Instance.Pictures[(int)eventProgramData.Value[0]].Scale.X = ((int)eventProgramData.Value[1] == 0 ? (int)eventProgramData.Value[2] : Global.Variable((int)eventProgramData.Value[2]));
                        Global.Instance.Pictures[(int)eventProgramData.Value[0]].Scale.Y = ((int)eventProgramData.Value[1] == 0 ? (int)eventProgramData.Value[3] : Global.Variable((int)eventProgramData.Value[3]));
                    }
                    index++; NextProgram(); break;
                case 19: // Rotate Picture
                    if (Global.Instance.Pictures[(int)eventProgramData.Value[0]] != null)
                    {
                        Global.Instance.Pictures[(int)eventProgramData.Value[0]].Rotation = ((int)eventProgramData.Value[1] == 0 ? (int)eventProgramData.Value[2] : Global.Variable((int)eventProgramData.Value[2]));
                    }
                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Screen
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryScreen(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // FadeOut
                    GameScreen.FadeOut();
                    waitFrames = Global.Instance.TransitionOffTime;
                    index++; NextProgram(); break;
                case 2: // FadeIn
                    GameScreen.FadeIn();
                    waitFrames = Global.Instance.TransitionOnTime;
                    index++; NextProgram(); break;
                case 3: // Tint Screen
                    GameScreen.ResetFade((Color)eventProgramData.Value[0]);
                    if (!(bool)eventProgramData.Value[3])
                        Global.TintEffect(EffectType.Tint, ScreenType.Gameplay, (Color)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    else
                        Global.TintEffect(EffectType.Tint, ScreenType.Global, (Color)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    actionTakingPlace = ActionType.Tint;
                    if ((bool)eventProgramData.Value[2])
                        waitFrames = (int)eventProgramData.Value[1];
                    index++;
                    break;
                case 4: // Flash
                    if (!(bool)eventProgramData.Value[4])
                        Global.FlashEffect(EffectType.Flash, ScreenType.Gameplay, (Color)eventProgramData.Value[0], (int)eventProgramData.Value[1] * 60, ((int)eventProgramData.Value[2] * 60) / 2);
                    else
                        Global.FlashEffect(EffectType.Flash, ScreenType.Global, (Color)eventProgramData.Value[0], (int)eventProgramData.Value[1] * 60, ((int)eventProgramData.Value[2] * 60) / 2);
                    actionTakingPlace = ActionType.Flash;
                    if ((bool)eventProgramData.Value[3])
                        waitFrames = (int)eventProgramData.Value[1] * 60;
                    index++;
                    break;
                case 5: // Shake
                    if (!(bool)eventProgramData.Value[4])
                        Global.ShakeEffect(EffectType.Shake, ScreenType.Gameplay, (int)eventProgramData.Value[0], (int)eventProgramData.Value[1], (int)eventProgramData.Value[2]);
                    else
                        Global.ShakeEffect(EffectType.Shake, ScreenType.Global, (int)eventProgramData.Value[0], (int)eventProgramData.Value[1], (int)eventProgramData.Value[2]);
                    actionTakingPlace = ActionType.Shake;

                    if ((bool)eventProgramData.Value[3])
                        waitFrames = (int)eventProgramData.Value[1];
                    index++;
                    break;
                case 6: // Zoom
                    Global.Instance.ActiveCamera.Zoom = new Vector2(GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]), GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[2]));
                    Global.Instance.ActiveCamera.Zoom /= 100;
                    index++; NextProgram();
                    break;
            }
        }
        /// <summary>
        /// Process Category Map
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryMap(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Toggle Map Layer
                    int layerIndex = (int)eventProgramData.Value[1];
                    if (layerIndex > -1 && layerIndex < Global.Instance.CurrentMap.Data.Layers.Count)
                    {
                        Global.Instance.CurrentMap.Data.Layers[layerIndex].IsVisible = ((int)eventProgramData.Value[0] == 0);
                    }
                    index++; NextProgram(); break;
                case 2: // Transfer Event
                    int x = 0, y = 0;
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Constant
                            x = (int)eventProgramData.Value[2];
                            y = (int)eventProgramData.Value[3];
                            break;
                        case 1: // Variable
                            x = (int)Global.Instance.Variables[(int)eventProgramData.Value[2]].Value;
                            y = (int)Global.Instance.Variables[(int)eventProgramData.Value[3]].Value;
                            break;
                    }
                    // Transfer Player
                    Global.TransferPlayer = true;
                    Global.TransferMapID = (int)eventProgramData.Value[0];
                    Global.TransferX = x;
                    Global.TransferY = y;
                    index++; NextProgram(); break;
                case 3: // Fog
                    // Fog material id
                    Global.Instance.FogMaterialID = (int)eventProgramData.Value[0];
                    Global.Instance.FogColor = (Color)eventProgramData.Value[1];
                    Global.Instance.FogSpeed = (int)eventProgramData.Value[2];
                    index++; NextProgram(); break;
                case 4: // Weather
                    Global.Instance.Weather.Setup((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], (int)eventProgramData.Value[2]);
                    index++; NextProgram(); break;
                case 5: // Scroll Camera
                    int horiz, vert;
                    if ((int)eventProgramData.Value[0] == 0) // Up
                        vert = -(int)eventProgramData.Value[1];
                    else
                        vert = (int)eventProgramData.Value[1];
                    if ((int)eventProgramData.Value[2] == 0) // Left
                        horiz = -(int)eventProgramData.Value[3];
                    else
                        horiz = (int)eventProgramData.Value[3];
                    Global.Instance.ActiveCamera.ScrollTo(new Vector2(horiz, vert), (int)eventProgramData.Value[4]);
                    index++; NextProgram(); break;
                case 6: // Center Camera
                    Global.Instance.ActiveCamera.Center((int)eventProgramData.Value[0]);
                    index++; NextProgram(); break;
                case 7: // Scroll To
                    if ((int)eventProgramData.Value[1] < 2)
                        Global.Instance.ActiveCamera.ScrollTo((int)eventProgramData.Value[0], new Vector2(GetValue((int)eventProgramData.Value[1], (int)eventProgramData.Value[2]), GetValue((int)eventProgramData.Value[1], (int)eventProgramData.Value[3])));
                    else
                        Global.Instance.ActiveCamera.ScrollTo((int)eventProgramData.Value[0], GetEvent((int)eventProgramData.Value[2]));
                    index++; NextProgram(); break;
                case 8: // Change Gravity
                    if (Global.Instance.CurrentMap != null)
                        Global.Instance.CurrentMap.ChangeGravity(new Vector2((float)eventProgramData.Value[0], (float)eventProgramData.Value[1]));
                    index++; NextProgram(); break;
                case 9: // Reload Map
                    if (Global.Instance.CurrentMap != null)
                        Global.ReloadMap = true;
                    index++; NextProgram(); break;
                case 10: // Apply Shader Effect
                    if (Global.Instance.CurrentMap != null)
                        Global.Instance.CurrentMap.ShaderProcess.Setup((int)eventProgramData.Value[0], (List<EffectParam>)eventProgramData.Value[1]);
                    index++; NextProgram(); break;
                case 11: // Gravity Points
                    if (Global.Instance.CurrentMap != null)
                    {
                        if ((bool)eventProgramData.Value[1])
                            Global.Instance.CurrentMap.AddGravityPoint((int)eventProgramData.Value[0], GetValue((int)eventProgramData.Value[2], (float)eventProgramData.Value[3]),
                                 GetValue((int)eventProgramData.Value[2], (float)eventProgramData.Value[4]),
                                  GetValue((int)eventProgramData.Value[2], (float)eventProgramData.Value[5]),
                                   GetValue((int)eventProgramData.Value[2], (float)eventProgramData.Value[6]));
                        else
                            Global.Instance.CurrentMap.RemoveGravityPoint((int)eventProgramData.Value[0]);
                    }
                    index++; NextProgram(); break;
                case 12: // Attach Camera to Event
                    if ((bool)eventProgramData.Value[0]) // None
                    {
                        Global.Instance.ActiveCamera.TrackingObject = null;
                    }
                    else
                    {
                        Global.Instance.ActiveCamera.TrackingObject = GetEvent((int)eventProgramData.Value[1]);
                    }
                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Event
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="index"></param>
        public void ProcessCategoryEvent(EventProgramData eventProgramData, ref int index)
        {
            VariableData varX, varY;
            switch (eventProgramData.Code)
            {
                case 1: // Create Event
                    EventData newEvent = GameData.Events.GetData((int)eventProgramData.Value[0]);
                    Vector2 newEventPosition = new Vector2();
                    EventProcessor onEvent;
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Custom
                            newEventPosition.X = (int)eventProgramData.Value[2];
                            newEventPosition.Y = (int)eventProgramData.Value[3];
                            break;
                        case 1:// Varaibles
                            varX = Global.Instance.Variables.GetData((int)eventProgramData.Value[2]);
                            varY = Global.Instance.Variables.GetData((int)eventProgramData.Value[3]);
                            if (varX != null)
                                newEventPosition.X = varX.Value;
                            if (varY != null)
                                newEventPosition.Y = varY.Value;
                            break;
                        case 2: // Event                    
                            onEvent = GetEvent((int)eventProgramData.Value[2]);

                            if (onEvent != null)
                                newEventPosition = onEvent.Position;
                            break;
                    }
                    Global.Instance.CurrentMap.AddEvent(newEvent, newEventPosition, (int)eventProgramData.Value[4]);
                    index++;
                    break;
                case 2: // Change Animation
                    EventProcessor ev1 = GetEvent((int)eventProgramData.Value[0]);
                    if (ev1 != null)
                    {
                        ev1.Animation.Setup((int)eventProgramData.Value[1], (int)eventProgramData.Value[2], EventAction.Idle);
                        ev1.SetupCollisionBody();
                    }
                    index++; NextProgram(); break;
                case 3: // Set Event Location
                    EventProcessor ev = GetEvent((int)eventProgramData.Value[0]);
                    if (ev != null)
                    {
                        // Get Direction
                        int direction = (int)eventProgramData.Value[2] - 1;
                        // Type
                        Vector2 pos = new Vector2();
                        switch ((int)eventProgramData.Value[1])
                        {
                            case 0: // Constant
                                pos.X = (float)(int)eventProgramData.Value[3];
                                pos.Y = (float)(int)eventProgramData.Value[4];
                                break;
                            case 1: // Variabe
                                pos.X = (float)Global.Instance.Variables.GetData((int)eventProgramData.Value[3]).Value;
                                pos.Y = (float)Global.Instance.Variables.GetData((int)eventProgramData.Value[4]).Value;
                                break;
                            case 2: // Exchange
                                EventProcessor exchange = GetEvent((int)eventProgramData.Value[3]);
                                pos = exchange.Position;
                                exchange.Position = ev.Position;
                                break;
                        }
                        // Adjust Position and Direction
                        ev.Position = pos;
                        if (direction > -1)
                            ev.SetAngle(Global.DirectionToAngle(direction), true);
                    }
                    index++; NextProgram(); break;
                case 4: // Delete Event
                    EventProcessor eventToRemove = GetEvent((int)eventProgramData.Value[0]);
                    if (eventToRemove != null) eventToRemove.Erase = true;
                    if (Global.Instance.AutorunID == this.UniqueID) Global.Instance.AutorunID = -1;
                    index++;
                    break;
                case 5: // Exit Branch
                    BreakBranch(ref index, false);
                    break;
                case 6: // Activate Global Event
                    Global.ActivateGlobalEvent((int)eventProgramData.Value[0]);
                    index++; NextProgram(); break;
                case 7: // Change Event Layer
                    EventProcessor ev2 = GetEvent((int)eventProgramData.Value[0]);
                    if (ev2 != null)
                    {
                        int layerIndex = (int)eventProgramData.Value[1];
                        if (layerIndex > -1 && layerIndex < Global.Instance.CurrentMap.Data.Layers.Count)
                        {
                            Global.Instance.CurrentMap.ChangeLayer(ev2, layerIndex);

                            this.DrawOrder = (int)ev2.Position.Y;
                        }
                    }
                    index++; NextProgram(); break;
                case 8: // Change Event Particle
                    EventProcessor particleEvent = GetEvent((int)eventProgramData.Value[0]);
                    if (particleEvent != null)
                        particleEvent.ParticleProcessor.Setup((int)eventProgramData.Value[1]);
                    index++; NextProgram(); break;
                case 9: // Apply Knockback Field
                    if (this is EventProcessor)
                    {
                        List<EventProcessor> _targets;
                        switch ((int)eventProgramData.Value[0])
                        {
                            case 0: // Forward
                                _targets = ((EventProcessor)this).GetTargets((int)eventProgramData.Value[2], true);
                                break;
                            case 1: // Radius
                                _targets = ((EventProcessor)this).GetTargets((int)eventProgramData.Value[2], false);
                                break;
                            default:
                                _targets = ((EventProcessor)this).GetTargets((int)eventProgramData.Value[2], true, (int)eventProgramData.Value[1]);
                                break;
                        }
                        for (int i = 0; i < _targets.Count; i++)
                        {
                            _targets[i].ApplyKnockback((EventProcessor)this, (float)eventProgramData.Value[3]);
                        }
                    }
                    index++; NextProgram(); break;
                case 10: // Lock Player
                    Global.Instance.LockPlayer[0] = 0;
                    Global.Instance.LockPlayer[1] = this.UniqueID;
                    index++; NextProgram(); break;
                case 11: // Lock Game
                    Global.Instance.AutorunID = this.UniqueID;
                    index++; NextProgram(); break;
                case 12: // Apply Shader Effect
                    EventProcessor es = GetEvent((int)eventProgramData.Value[0]);
                    if (es != null) es.ShaderProcess.Setup((int)eventProgramData.Value[1], (List<EffectParam>)eventProgramData.Value[2]);
                    index++; NextProgram(); break;
                case 13: // Attach Gravity
                    EventProcessor gs = GetEvent((int)eventProgramData.Value[0]);

                    gs.SetGravityEmitter(GetValue((int)eventProgramData.Value[1], (float)eventProgramData.Value[2]),
                             GetValue((int)eventProgramData.Value[1], (float)eventProgramData.Value[3]));

                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Page Memory
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryGuide(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Save
                    Global.SaveGame(eventProgramData);
                    index++; NextProgram(); return;
                case 2: // Load
                    Global.LoadGame(eventProgramData);
                    index++; NextProgram(); return;
                case 3: // Guide Conditions
                    CheckGuideConditions(eventProgramData);
                    index++; NextProgram(); return;
#if !SILVERLIGHT
                case 4: // Simulate Trial
                    Guide.SimulateTrialMode = !Guide.SimulateTrialMode;
                    index++;
                    break;
                case 5: // Sign In
                    Guide.ShowSignIn((int)eventProgramData.Value[0], (bool)eventProgramData.Value[1]);
                    index++;
                    break;
                case 6: // Market Place
                    Guide.ShowMarketplace(InputState.GetPlayer((int)eventProgramData.Value[0]).Value);
                    index++;
                    break;
                case 7: // Show Party
                    Guide.ShowParty(InputState.GetPlayer((int)eventProgramData.Value[0]).Value);
                    index++;
                    break;
                case 8: // Show Friends
                    Guide.ShowFriends(InputState.GetPlayer((int)eventProgramData.Value[0]).Value);
                    index++;
                    break;
                case 9: // Show Message
                    Guide.BeginShowMessageBox((string)eventProgramData.Value[0], (string)eventProgramData.Value[1], new string[] { "OK" }, 0, MessageBoxIcon.None, new AsyncCallback(GameplayScreen.EndMessageCallback), null);
                    index++;
                    break;
                case 10: // Show Input
                    Guide.BeginShowKeyboardInput(InputState.GetPlayer((int)eventProgramData.Value[4]).Value, (string)eventProgramData.Value[0], (string)eventProgramData.Value[1], (string)eventProgramData.Value[2], new AsyncCallback(GameplayScreen.EndInputCallback), null);
                    GameplayScreen.DefaultText = (string)eventProgramData.Value[2];
                    GameplayScreen.DefaultString = (int)eventProgramData.Value[3];
                    index++;
                    break;
                case 11: // Show Storage
                    if (Global.Storage == null || (bool)eventProgramData.Value[1])
                        Global.StorageDeviceManager.PromptForDevice();
                    //StorageDevice.BeginShowSelector(InputState.GetPlayer((int)eventProgramData.Value[0]).Value, new AsyncCallback(GameplayScreen.EndStorgeCallback), null);
                    index++;
                    break;
                case 12: // Wait Load Save
                    if (Global.IsSavingOrLoading == -1)
                    { index++; NextProgram(); break; }
                    break;
            }
#else

            }
            index++; NextProgram();
#endif
        }
        /// <summary>
        /// Process Page Conditions
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryConditions(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Switch
                    // Get switch
                    SwitchData switche;
                    if ((int)eventProgramData.Value[4] == 0)
                    {
                        if (Global.Instance.Switches.TryGetValue((int)eventProgramData.Value[0], out switche))
                            CheckSwitchCondition(switche, eventProgramData);
                    }
                    else
                    {
                        if (Switches.TryGetValue((int)eventProgramData.Value[0], out switche))
                            CheckSwitchCondition(switche, eventProgramData);
                    }
                    index++; NextProgram(); break;
                case 2: // Variable
                    // Get Variable
                    VariableData variable;
                    if ((int)eventProgramData.Value[6] == 0)
                    {
                        if (Global.Instance.Variables.TryGetValue((int)eventProgramData.Value[0], out variable))
                            CheckVariableCondition(variable, eventProgramData);
                    }
                    else
                    {
                        if (Variables.TryGetValue((int)eventProgramData.Value[0], out variable))
                            CheckVariableCondition(variable, eventProgramData);
                    }
                    index++; NextProgram(); break;
                case 3: // List
                    CheckListCondition(eventProgramData);
                    index++; NextProgram(); break;
                case 4: // Database;
                    CheckDatabaseCondition(eventProgramData);
                    index++; NextProgram(); break;
                case 5: // Button Input
                    CheckButtonInput(eventProgramData);
                    index++; NextProgram(); break;
                case 6: // Mouse Input
                    CheckMouseInput(eventProgramData);
                    index++; NextProgram(); break;
                case 7: // Event
                    CheckEventCondition(eventProgramData);
                    index++; NextProgram(); break;
                case 8: // Timer
                    CheckTimerCondition(eventProgramData);
                    index++; NextProgram(); break;
                case 9: // String
                    CheckStringCondition(eventProgramData);
                    index++; NextProgram(); break;
                case 10: // Other
                    CheckOtherCondition(eventProgramData);
                    index++; NextProgram(); break;
                case 11: // Item/Skill
                    CheckItemSkillCondition(eventProgramData);
                    index++; NextProgram(); break;
                case 12: // Hero
                    CheckHeroCondition(eventProgramData);
                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Loop
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        public void ProcessCategoryLoop(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Loop
                    SetupBranch(eventProgramData);
                    index++; NextProgram();
                    break;
                case 2: // Break Loop
                    if (CurrentBranch.ProgramCategory == ProgramCategory.Loops && CurrentBranch.Code == 1)
                        BreakBranch(ref index);
                    else
                    {
                        int loopCount = 0;
                        for (int i = LastBranch.Count - 1; i > -1; i--)
                        {
                            loopCount++;
                            if (LastBranch[i].ProgramCategory == ProgramCategory.Loops && LastBranch[i].Code == 1)
                            {
                                for (int j = 0; j <= loopCount; j++)
                                    BreakBranch(ref index);
                                break;
                            }
                        }
                    }
                    break;
                case 3: // Label
                    // Remove Label if exists
                    if (labels.ContainsKey(eventProgramData.Value[0].ToString()))
                    {
                        labels.Remove(eventProgramData.Value[0].ToString());
                    }
                    Bookmark mark = new Bookmark();
                    mark.CurrentBranch = CurrentBranch;
                    mark.LastBranch = new List<IEventProgram>(LastBranch);
                    mark.LastProgramIndex = new List<int>(LastProgramIndex);
                    mark.programIndex = index;
                    labels.Add(eventProgramData.Value[0].ToString(), mark);
                    index++; NextProgram(); break;
                case 4: // Go To Label
                    Bookmark goTo;
                    if (labels.TryGetValue(eventProgramData.Value[0].ToString(), out goTo))
                    {
                        CurrentBranch = goTo.CurrentBranch;
                        LastBranch = goTo.LastBranch;
                        LastProgramIndex = goTo.LastProgramIndex;
                        index = goTo.programIndex;
                    }
                    index++; break;
            }
        }
        /// <summary>
        /// Process Audio
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="movementPrgmIndex"></param>
        public void ProcessCategoryAudio(EventProgramData eventProgramData, ref int index)
        {
            AudioSettings settings;
            switch (eventProgramData.Code)
            {
                case 1: // Play Audio
                    settings = new AudioSettings((int)eventProgramData.Value[2], (int)eventProgramData.Value[3], (bool)eventProgramData.Value[4], (float)eventProgramData.Value[5], (float)eventProgramData.Value[6], (float)eventProgramData.Value[7], (bool)eventProgramData.Value[8]);

                    Global.Instance.AudioManager.Play((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], settings);
                    break;
                case 2: // Control Audio Channel
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0: // Play
                            Global.Instance.AudioManager.Play((int)eventProgramData.Value[1]);
                            break;
                        case 1: // Pause
                            Global.Instance.AudioManager.Pause((int)eventProgramData.Value[1]);
                            break;
                        case 2: // Resume
                            Global.Instance.AudioManager.Resume((int)eventProgramData.Value[1]);
                            break;
                        case 3: // Stop
                            Global.Instance.AudioManager.Stop((int)eventProgramData.Value[1]);
                            break;
                        case 4: // Fade Out
                            Global.Instance.AudioManager.FadeOut((int)eventProgramData.Value[1]);
                            break;
                    }
                    break;
                case 3: // Create PlayList
                    Global.Instance.AudioManager.CreatePlaylist((List<int>)eventProgramData.Value[0], (int)eventProgramData.Value[1], (bool)eventProgramData.Value[2]);
                    break;
                case 4: // Control PlayList
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0: // Play
                            Global.Instance.AudioManager.PlayPlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 1: // Pause
                            Global.Instance.AudioManager.PausePlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 2: // Resume
                            Global.Instance.AudioManager.ResumePlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 3: // Stop
                            Global.Instance.AudioManager.StopPlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 4: // Fade Out
                            Global.Instance.AudioManager.FadeOutPlayList((int)eventProgramData.Value[1]);
                            break;
                    }
                    break;
                case 5:  // Play 3D Audio
                    settings = new AudioSettings((float)eventProgramData.Value[2], (float)eventProgramData.Value[3], (float)eventProgramData.Value[4], (bool)eventProgramData.Value[5]);
                    EventProcessor emitter = GetEvent((int)eventProgramData.Value[6]);
                    EventProcessor listener = GetEvent((int)eventProgramData.Value[7]);
                    if (emitter != null && listener != null)
                        Global.Instance.AudioManager.Play3D((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], settings, emitter.id, listener.id);
                    break;
                case 6: // Control 3D audio
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0: // Play
                            Global.Instance.AudioManager.Play3D((int)eventProgramData.Value[1]);
                            break;
                        case 1: // Pause
                            Global.Instance.AudioManager.Pause3D((int)eventProgramData.Value[1]);
                            break;
                        case 2: // Resume
                            Global.Instance.AudioManager.Resume3D((int)eventProgramData.Value[1]);
                            break;
                        case 3: // Stop
                            Global.Instance.AudioManager.Stop3D((int)eventProgramData.Value[1]);
                            break;
                    }
                    break;
            }
            index++; NextProgram();
        }
        /// <summary>
        /// Process Settings
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="movementPrgmIndex"></param>
        public void ProcessCategorySettings(EventProgramData eventProgramData, ref int index)
        {
            if (this is EventProcessor)
            {
                switch (eventProgramData.Code)
                {
                    case 1: // Animation
                        ((EventProcessor)this).Animation.animationOn = (bool)eventProgramData.Value[0];
                        index++; NextProgram(); break;
                    case 2: // Direction Fix
                        ((EventProcessor)this).DirectionFix = (bool)eventProgramData.Value[0];
                        index++; NextProgram(); break;
                    case 3: // Collision
                        ((EventProcessor)this).CollisionOn = (bool)eventProgramData.Value[0];
                        index++; NextProgram(); break;
                    case 4: // Change Animation
                        ((EventProcessor)this).Animation.Setup((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], EventAction.Idle);
                        ((EventProcessor)this).SetupCollisionBody();
                        index++; NextProgram(); break;
                    case 5: // Enable/Disable Frequency
                        ((EventProcessor)this).Animation.EnableFrequency = (bool)eventProgramData.Value[0];
                        index++; NextProgram(); break;
                    case 6: // Change Frequency
                        ((EventProcessor)this).Animation.Frequency = (int)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                        index++; NextProgram(); break;
                    case 7: // Change Move Speed
                        ((EventProcessor)this).MoveSpeed = (int)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                        index++; NextProgram(); break;
                    case 8: // Set Force
                        ((EventProcessor)this).Force = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Force);
                        index++; NextProgram(); break;
                    case 10: // Linear Drag  
                        ((EventProcessor)this).LinearDrag = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.LinearDrag);
                        if (((EventProcessor)this).Body != null)
                            ((EventProcessor)this).Body.LinearDamping = ((EventProcessor)this).LinearDrag;
                        index++; NextProgram(); break;
                    case 11: // Rotational Drag
                        ((EventProcessor)this).RotationalDrag = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.RotationalDrag);
                        if (((EventProcessor)this).Body != null)
                            ((EventProcessor)this).Body.AngularDamping = ((EventProcessor)this).RotationalDrag;
                        index++; NextProgram(); break;
                    case 12: // Friction
                        ((EventProcessor)this).Friction = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Friction);
                        if (((EventProcessor)this).Body != null)
                            ((EventProcessor)this).Body.Friction = ((EventProcessor)this).Friction;
                        index++; NextProgram(); break;
                    case 13: // Bounce
                        ((EventProcessor)this).Bounce = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Bounce);
                        if (((EventProcessor)this).Body != null)
                            ((EventProcessor)this).Body.Restitution = ((EventProcessor)this).Bounce;
                        index++; NextProgram(); break;
                    case 14: // Mass
                        ((EventProcessor)this).Mass = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Mass);
                        if (((EventProcessor)this).Body != null)
                            ((EventProcessor)this).Body.Mass = ((EventProcessor)this).Mass;
                        index++; NextProgram(); break;
                    case 15: // Impulse 
                        if (((EventProcessor)this).Body != null)
                            ((EventProcessor)this).Impulse = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]) : Global.Project.Impulse);
                        index++; NextProgram(); break;
                    case 16: // Change Static
                        ((EventProcessor)this).Static = ((bool)eventProgramData.Value[0]);
                        if (((EventProcessor)this).Body != null) ((EventProcessor)this).Body.IsStatic = ((EventProcessor)this).Static;
                        index++; NextProgram(); break;
                }
            }
            else
            {
                index++; NextProgram();
            }
        }
        /// <summary>
        /// Process Data
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="movementPrgmIndex"></param>
        public void ProcessCategoryData(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Switch
                    SetSwitch(eventProgramData, Global.Instance.Switches.GetData((int)eventProgramData.Value[0]));
                    index++; NextProgram();
                    break;
                case 2: // Variable
                    SetVariable(eventProgramData, Global.Instance.Variables.GetData((int)eventProgramData.Value[0]));
                    index++; NextProgram();
                    break;
                case 3: // Local Switch
                    SetSwitch(eventProgramData, Switches.GetData((int)eventProgramData.Value[0]));
                    index++; NextProgram();
                    break;
                case 4: // Local Variable
                    SetVariable(eventProgramData, Variables.GetData((int)eventProgramData.Value[0]));
                    index++; NextProgram();
                    break;
                case 5: // List
                    SetList(eventProgramData);
                    index++; NextProgram();
                    break;
                case 6: // Database
                    SetDataBase(eventProgramData);
                    index++; NextProgram(); break;
                case 7: // String
                    SetString(eventProgramData);
                    index++; NextProgram(); break;
                case 8: // Event Switch
                    if (this is EventProcessor)
                        Global.SetEventSwitch((int)eventProgramData.Value[0], ((EventProcessor)this).MapID, ID, (bool)((int)eventProgramData.Value[1] == 0));
                    index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Others
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void ProcessCategoryOther(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Wait
                    waitFrames = (int)eventProgramData.Value[0];
                    index++;
                    break;
                case 3: // Comment
                    if (eventProgramData.Branch)
                        SetupBranch(eventProgramData);
                    index++; NextProgram(); break;
                case 4: // Timer
                    // Remove time if it exists on the variable
                    if ((int)eventProgramData.Value[0] == 0 || (int)eventProgramData.Value[0] == 1)
                    {
                        // Create new time
                        Timer timer = new Timer((int)eventProgramData.Value[1], (int)eventProgramData.Value[2], (int)eventProgramData.Value[3], (int)eventProgramData.Value[4], (int)eventProgramData.Value[5]);
                        // Add time to list
                        Global.Instance.Timers[(int)eventProgramData.Value[1]] = timer;
                        // Start or stop
                        if ((int)eventProgramData.Value[0] == 1)
                            timer.Stop();
                    }
                    else
                    {
                        Timer timer;
                        if (Global.Instance.Timers.TryGetValue((int)eventProgramData.Value[0], out timer))
                        {
                            switch ((int)eventProgramData.Value[0])
                            {
                                case 2: // Start
                                    timer.Start();
                                    break;
                                case 3: // Stop
                                    timer.Stop();
                                    break;
                                case 4: // Reset
                                    timer.Reset();
                                    break;
                            }
                        }
                    }
                    index++; NextProgram(); break;
                case 5: // Vibrate Controller
                    int player = (int)eventProgramData.Value[0];
                    if (InputState.GetPlayer(player).HasValue)
                        GamePad.SetVibration(InputState.GetPlayer(player).Value, ((float)(int)eventProgramData.Value[2]) / 10, ((float)(int)eventProgramData.Value[1]) / 10);
                    index++; NextProgram(); break;
                case 6: // Change Controller Deadzone
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0:
                            InputState.DeadZone = GamePadDeadZone.IndependentAxes;
                            break;
                        case 1:
                            InputState.DeadZone = GamePadDeadZone.Circular;
                            break;
                        case 2:
                            InputState.DeadZone = GamePadDeadZone.None;
                            break;
                    }
                    index++; NextProgram(); break;
                case 7: // Memorize Players
                    InputState.Players = InputState.TempPlayers;
                    index++; NextProgram(); break;
                case 8: // Reset Players
                    InputState.Players = new PlayerIndex?[InputState.MaxInputs];
                    index++; NextProgram(); break;
                case 9: // Change Screen Ratio
                    Global.Project.ScreenRatio = new Vector2((float)(int)eventProgramData.Value[0], (float)(int)eventProgramData.Value[1]);
                    index++; NextProgram(); break;
                case 10: // Exit Game
                    Global.Game.Exit();
                    break;
                case 11: // Toggle Player Controls
                    Global.Instance.Player[0].Enabled = ((int)eventProgramData.Value[0] == 0);
                    index++; NextProgram(); break;
                case 12: // Set Hotkey
                    int hotkeyID = 0;
                    // Check Type of Hotkey
                    switch ((int)eventProgramData.Value[5])
                    {
                        case 0: // Constant
                            hotkeyID = (int)eventProgramData.Value[6];
                            break;
                        case 1: // Variable
                            hotkeyID = (int)Global.Variable((int)eventProgramData.Value[6]);
                            break;
                    }
                    switch ((int)eventProgramData.Value[4])
                    {
                        case 0: // Skill
                            // Get Keys
                            if ((bool)eventProgramData.Value[8]) // Keyboard
                            {
                                Hotkey key = GetSkillHotkey((int)eventProgramData.Value[2], (int)eventProgramData.Value[3], 0);
                                if (key == null)
                                {
                                    key = new Hotkey();
                                    Global.Instance.SkillKeys.Add(key);
                                }

                                key.DefaultID = hotkeyID;
                                key.Key1 = (int)eventProgramData.Value[2];
                                key.Key2 = (int)eventProgramData.Value[3] - 1;
                            }
                            else // Controller
                            {
                                Hotkey key = GetSkillHotkey((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], 1);
                                if (key == null)
                                {
                                    key = new Hotkey();
                                    Global.Instance.SkillKeys.Add(key);
                                }
                                key.DefaultID = hotkeyID;
                                key.Button1 = (int)eventProgramData.Value[0];
                                key.Button2 = (int)eventProgramData.Value[1] - 1;
                            }
                            break;
                        case 1: // Item
                            // Get Keys
                            if ((bool)eventProgramData.Value[8]) // Keyboard
                            {
                                Hotkey key = GetItemHotkey((int)eventProgramData.Value[2], (int)eventProgramData.Value[3], 0);
                                if (key == null)
                                {
                                    key = new Hotkey();
                                    Global.Instance.ItemKeys.Add(key);
                                }
                                key.DefaultID = hotkeyID;
                                key.Key1 = (int)eventProgramData.Value[2];
                                key.Key2 = (int)eventProgramData.Value[3] - 1;
                            }
                            else // Controller
                            {
                                Hotkey key = GetItemHotkey((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], 1);
                                if (key == null)
                                {
                                    key = new Hotkey();
                                    Global.Instance.ItemKeys.Add(key);
                                }
                                key.DefaultID = hotkeyID;
                                key.Button1 = (int)eventProgramData.Value[0];
                                key.Button2 = (int)eventProgramData.Value[1] - 1;
                            }
                            break;
                    }
                    index++; NextProgram(); break;
                case 13: // Lock Screen
                    Global.Instance.LockScreen = new Rectangle((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], (int)eventProgramData.Value[2], (int)eventProgramData.Value[3]);
                    index++; NextProgram(); break;
                case 14: // Reload Game
                    Global.ReloadGame(); index++; NextProgram(); break;
            }
        }
        /// <summary>
        /// Process Category Movement
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void ProcessCategoryMovement(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 10: // Program Movement
                    SetupProgramMovement(eventProgramData);
                    break;
            }
            index++; NextProgram();
        }

        #region Helper: Check Conditions
        /// <summary>
        /// Check Hero Conditions
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckHeroCondition(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;
                HeroProcessor hero = Global.Instance.Party.GetHero((int)eventProgramData.Value[0]);

                if (hero != null)
                {
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Has Item?
                            result = hero.HasItem((int)eventProgramData.Value[2]);
                            break;
                        case 1: // Has Equipment?
                            result = hero.HasEquipment((int)eventProgramData.Value[2]);
                            break;
                        case 2: // Has Skill/Magic?
                            result = hero.HasSkillorMagic((int)eventProgramData.Value[2]);
                            break;
                    }
                }

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check switch condition
        /// </summary>
        /// <param name="switche"></param>
        /// <param name="eventProgramData"></param>
        public void CheckSwitchCondition(SwitchData switche, EventProgramData eventProgramData)
        {
            if (eventProgramData.Name.Contains("Test"))
                eventProgramData = eventProgramData;
            try
            {
                bool result = false;
                bool value = false;

                switch ((int)eventProgramData.Value[2])
                {
                    case 0: //Costant
                        value = (bool)eventProgramData.Value[3];
                        break;
                    case 1: // Switch
                        value = Global.Switch((int)eventProgramData.Value[3]);
                        break;
                    case 2: // Local Switch
                        value = Switches.GetData((int)eventProgramData.Value[3]).State;
                        break;
                }

                switch ((int)eventProgramData.Value[1])
                {
                    case 0: // Equals
                        if (switche.State == value)
                            result = true;
                        break;
                    case 1: // Does not equal
                        if (switche.State != value)
                            result = true;
                        break;
                }

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check variable condition
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="eventProgramData"></param>
        public void CheckVariableCondition(VariableData variable, EventProgramData eventProgramData)
        {
            try
            {
                float value = 0;
                switch ((int)eventProgramData.Value[2])
                {
                    case 0: // Constant
                        value = (int)eventProgramData.Value[3];
                        break;
                    case 1: // Random
                        Random rand = new Random();
                        value = rand.Next((int)eventProgramData.Value[3], (int)eventProgramData.Value[4]);
                        break;
                    case 2: // Varaible
                        value = Global.Instance.Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 3: // Local Variable
                        value = Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 4: // Event
                        EventProcessor e = GetEvent((int)eventProgramData.Value[3]);
                        if (e != null)
                        {
                            switch ((int)eventProgramData.Value[4])
                            {
                                case 0: // Position X
                                    value = (int)e.Position.X;
                                    break;
                                case 1: // Position Y
                                    value = (int)e.Position.Y;
                                    break;
                            }
                        }
                        break;
                    case 5: // Data
                        value = (int)Global.GetDataProperty((int)eventProgramData.Value[3], (int)eventProgramData.Value[4], (int)eventProgramData.Value[5]).Value;
                        break;
                    case 6: // Other 
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Map ID
                                if (Global.Instance.CurrentMap == null)
                                    throw new Exception("The current map is null. Make sure the map is loaded.");
                                value = Global.Instance.CurrentMap.Data.ID;
                                break;
                        }
                        break;
                }
                bool result = false;
                switch ((int)eventProgramData.Value[1])
                {
                    case 0:
                        result = (variable.Value == value);
                        break;
                    case 1:
                        result = (variable.Value > value);
                        break;
                    case 2:
                        result = (variable.Value < value);
                        break;
                    case 3:
                        result = (variable.Value >= value);
                        break;
                    case 4:
                        result = (variable.Value <= value);
                        break;
                    case 5:
                        result = (variable.Value != value);
                        break;
                }

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check list condition
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckListCondition(EventProgramData eventProgramData)
        {
            try
            {
                ListData list = Global.Instance.Lists.GetData((int)eventProgramData.Value[0]);
                float value = 0;
                switch ((int)eventProgramData.Value[2])
                {
                    case 0: // Constant
                        value = (int)eventProgramData.Value[3];
                        break;
                    case 1: // Random
                        Random rand = new Random();
                        value = rand.Next((int)eventProgramData.Value[3], (int)eventProgramData.Value[4]);
                        break;
                    case 2: // Varaible
                        value = Global.Instance.Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 3: // Local Variable
                        value = Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 4: // Event
                        EventProcessor e = GetEvent((int)eventProgramData.Value[3]);
                        if (e != null)
                        {
                            switch ((int)eventProgramData.Value[4])
                            {
                                case 0: // Position X
                                    value = (int)e.Position.X;
                                    break;
                                case 1: // Position Y
                                    value = (int)e.Position.Y;
                                    break;
                            }
                        }
                        break;
                    case 5: // Data
                        value = (int)Global.GetDataProperty((int)eventProgramData.Value[3], (int)eventProgramData.Value[4], (int)eventProgramData.Value[5]).Value;
                        break;
                    case 6: // Other 
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Map ID
                                if (Global.Instance.CurrentMap == null)
                                    throw new Exception("The current map is null. Make sure the map is loaded.");
                                value = Global.Instance.CurrentMap.Data.ID;
                                break;
                            case 1: // Has Item?
                                value = (int)eventProgramData.Value[4];
                                break;
                            case 2: // Has Equipment?
                                value = (int)eventProgramData.Value[4];
                                break;
                            case 3: // Has Skill/Magic?
                                value = (int)eventProgramData.Value[4];
                                break;
                        }
                        break;
                }
                bool result = false;
                switch ((int)eventProgramData.Value[1])
                {
                    case 0: // Contains
                        result = list.Values.Contains((int)value);
                        break;
                    case 1: // Does Not Contain
                        result = !list.Values.Contains((int)value);
                        break;
                }

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check database conditon
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckDatabaseCondition(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;
                DataProperty property;

                property = Global.GetDataProperty((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], (int)eventProgramData.Value[2]);

                if (property != null)
                {
                    if (property.ValueType == DataType.Number)
                    {
                        float value = 0;
                        switch ((int)eventProgramData.Value[4])
                        {
                            case 0: // Constant
                                value = (int)eventProgramData.Value[5];
                                break;
                            case 1: // Random
                                Random rand = new Random();
                                value = rand.Next((int)eventProgramData.Value[5], (int)eventProgramData.Value[6]);
                                break;
                            case 2: // Varaible
                                value = Global.Instance.Variables[(int)eventProgramData.Value[5]].Value;
                                break;
                            case 3: // Local Variable
                                value = Variables[(int)eventProgramData.Value[5]].Value;
                                break;
                            case 4: // Event
                                EventProcessor e = GetEvent((int)eventProgramData.Value[5]);
                                if (e != null)
                                {
                                    switch ((int)eventProgramData.Value[6])
                                    {
                                        case 0: // Position X
                                            value = (int)e.Position.X;
                                            break;
                                        case 1: // Position Y
                                            value = (int)e.Position.Y;
                                            break;
                                    }
                                }
                                break;
                            case 5: // Data
                                value = (int)Global.GetDataProperty((int)eventProgramData.Value[5], (int)eventProgramData.Value[6], (int)eventProgramData.Value[7]).Value;
                                break;
                            case 6: // Other 
                                switch ((int)eventProgramData.Value[5])
                                {
                                    case 0: // Map ID
                                        if (Global.Instance.CurrentMap == null)
                                            throw new Exception("The current map is null. Make sure the map is loaded.");
                                        value = Global.Instance.CurrentMap.Data.ID;
                                        break;
                                }
                                break;
                        }
                        switch ((int)eventProgramData.Value[4])
                        {
                            case 0: //Equals (=)
                                result = ((int)property.Value == value);
                                break;
                            case 1: //Greater Than (>)
                                result = ((int)property.Value > value);
                                break;
                            case 2: //Less Than (<)
                                result = ((int)property.Value < value);
                                break;
                            case 3: //Greater Than Or Equals (>=)
                                result = ((int)property.Value >= value);
                                break;
                            case 4: //Less Than Or Equals (<=)
                                result = ((int)property.Value <= value);
                                break;
                            case 5: //Does Not Equal (!=)
                                result = ((int)property.Value != value);
                                break;
                        }
                    }
                    else if (property.ValueType == DataType.Text)
                    {
                        string value = (string)eventProgramData.Value[3];

                        switch ((int)eventProgramData.Value[4])
                        {
                            case 0: //Equals (=)
                                if ((string)property.Value == value)
                                    result = true;
                                break;
                            case 1: //Does Not Equal (!=)
                                if ((string)property.Value != value)
                                    result = true;
                                break;
                        }
                    }
                }

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check event condition
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckEventCondition(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;

                EventProcessor ev = GetEvent((int)eventProgramData.Value[0]);

                if (ev != null)
                {
                    switch ((int)eventProgramData.Value[1])
                    {
                        case 0: // Active
                            switch ((int)eventProgramData.Value[2])
                            {
                                case 0:
                                    result = ev.isProgramActive;
                                    break;
                                case 1:
                                    result = !ev.isProgramActive;
                                    break;
                                case 2: // Moving
                                    result = ev.IsMoving;
                                    break;
                                case 3: // Jumping
                                    result = ev.IsJumping;
                                    break;
                                case 4: // Idle
                                    result = (ev.ActionIndex == EventAction.Idle && !ev.IsJumping && !ev.IsMoving);
                                    break;
                                case 5: // Colliding
                                    if (ev.Body != null)
                                        result = ev.collisionList.Count > 0;
                                    break;
                            }
                            break;
                        case 1: // Direction
                            result = (ev.Animation.Direction == (int)eventProgramData.Value[2]);
                            break;
                        case 2: // In direction
                            EventProcessor inDirection = GetEvent((int)eventProgramData.Value[2]);
                            if (inDirection != null)
                                result = ev.InLineOf(inDirection, false);
                            break;
                        case 3: // Is facing
                            EventProcessor isFacing = GetEvent((int)eventProgramData.Value[2]);
                            if (isFacing != null)
                                result = ev.IsFacing(isFacing.Position, isFacing.Body);
                            break;
                        case 4: // Range
                            if (this is EventProcessor)
                            {
                                EventProcessor inRange = GetEvent((int)eventProgramData.Value[2]);
                                if (inRange != null)
                                    if (((EventProcessor)this).Body == null || inRange.Body == null)
                                        result = ev.RangeOf(inRange) <= (int)eventProgramData.Value[3];
                                    else
                                        result = ((EventProcessor)this).CollideAnyAngle(inRange.Body, ConvertUnits.ToSimUnits((int)eventProgramData.Value[3]));
                            }
                            break;
                        case 5: // Position
                            Vector2 pos = new Vector2((int)eventProgramData.Value[2], (int)eventProgramData.Value[3]);
                            switch ((int)eventProgramData.Value[5])
                            {
                                case 0:
                                    result = (ev.Position == pos);
                                    break;
                                case 1:
                                    result = Extension.Greater(ev.Position, pos);
                                    break;
                                case 2:
                                    result = Extension.Lesser(ev.Position, pos);
                                    break;
                                case 3:
                                    result = Extension.GreaterEquals(ev.Position, pos);
                                    break;
                                case 4:
                                    result = Extension.LesserEquals(ev.Position, pos);
                                    break;
                                case 5:
                                    result = (ev.Position != pos);
                                    break;
                            }
                            break;
                        case 6: // Tile tag
                            List<int> tags = Global.Instance.CurrentMap.TileTags(ev.Position);
                            result = tags.Contains((int)eventProgramData.Value[2]);
                            break;
                        case 7: // Angle
                            result = Global.AngleInBetween(ev.Angle, (int)eventProgramData.Value[2], (int)eventProgramData.Value[3]);
                            break;
                        case 8: // Force
                            if (ev.Body != null)
                            {
                                Vector2 valueForce = Vector2.Zero;
                                Vector2 userForce = new Vector2((float)(decimal)eventProgramData.Value[3], (float)(decimal)eventProgramData.Value[4]);

                                switch ((int)eventProgramData.Value[2])
                                {
                                    case 0: // Force
                                        valueForce = ev.Body.Force;
                                        break;
                                    case 1: // Impulse
                                        valueForce = ev.Body.LinearVelocityInternal;
                                        break;
                                    case 2: // Velocity
                                        valueForce = ev.Body.LinearVelocity;
                                        break;
                                }
                                switch ((int)eventProgramData.Value[5])
                                {
                                    case 0:
                                        result = (valueForce == userForce);
                                        break;
                                    case 1:
                                        result = Extension.Greater(valueForce, userForce);
                                        break;
                                    case 2:
                                        result = Extension.Lesser(valueForce, userForce);
                                        break;
                                    case 3:
                                        result = Extension.GreaterEquals(valueForce, userForce);
                                        break;
                                    case 4:
                                        result = Extension.LesserEquals(valueForce, userForce);
                                        break;
                                    case 5:
                                        result = (valueForce != userForce);
                                        break;
                                }
                            }
                            break;
                        case 9: // Angular
                            if (ev.Body != null)
                            {
                                float value = 0f;
                                float userValue = (float)(decimal)eventProgramData.Value[3];
                                switch ((int)eventProgramData.Value[2])
                                {
                                    case 0: // Torque
                                        value = ev.Body.Torque;
                                        break;
                                    case 1: // Velocity
                                        value = ev.Body.AngularVelocity;
                                        break;
                                }
                                switch ((int)eventProgramData.Value[4])
                                {
                                    case 0:
                                        result = (value == userValue);
                                        break;
                                    case 1:
                                        result = (value > userValue);
                                        break;
                                    case 2:
                                        result = (value < userValue);
                                        break;
                                    case 3:
                                        result = (value >= userValue);
                                        break;
                                    case 4:
                                        result = (value <= userValue);
                                        break;
                                    case 5:
                                        result = (value != userValue);
                                        break;
                                }
                            }
                            break;
                        case 10: // Angle On Event
                            EventProcessor angleEvent = GetEvent((int)eventProgramData.Value[2]);
                            if (angleEvent != null)
                            {
                                Vector2 targetAngle = (angleEvent.OriginPosition - ev.OriginPosition);
                                // Calculate target To Move
                                int _angle = (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);
                                // Check if angle is between given angles
                                result = Global.AngleInBetween(_angle, (int)eventProgramData.Value[3], (int)eventProgramData.Value[4]);
                            }
                            break;
                        case 11: // Is Colliding Event
                            EventProcessor colliding = GetEvent((int)eventProgramData.Value[2]);
                            if (colliding.Body != null && ev.Body != null)
                                result = ev.Body.Collide(colliding.Body);
                            break;
                        case 12: // Is Colliding Projectile
                            if (ev.CollidingProjectile > -1)
                                result = ((int)eventProgramData.Value[2] == -1 || (int)eventProgramData.Value[2] == ev.CollidingProjectile);
                            break;
                    }
                }
                // Opposite
                if ((int)eventProgramData.Value[6] == 1)
                    result = !result;

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check timer condition
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckTimerCondition(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;
                int value = 0;
                VariableData var;
                if (Global.Instance.Variables.TryGetValue((int)eventProgramData.Value[1], out var))
                {
                    value = (int)var.Value;
                }
                int time = (int)eventProgramData.Value[2] * 60 * 60 * 1000;
                time += (int)eventProgramData.Value[3] * 60 * 1000;
                time += (int)eventProgramData.Value[4] * 1000;
                switch ((int)eventProgramData.Value[0])
                {
                    case 0: //Equals (=)
                        result = (time == value);
                        break;
                    case 1: //Greater Than (>)
                        result = (time > value);
                        break;
                    case 2: //Less Than (<)
                        result = (time < value);
                        break;
                    case 3: //Greater Than Or Equals (>=)
                        result = (time >= value);
                        break;
                    case 4: //Less Than Or Equals (<=)
                        result = (time <= value);
                        break;
                    case 5: //Does Not Equal (!=)
                        result = (time != value);
                        break;
                }
                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check button input
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckButtonInput(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;

                if ((bool)eventProgramData.Value[0])
                {
                    // Keyboard
                    Keys key = InputState.KeysList[(int)eventProgramData.Value[1]];
                    switch ((int)eventProgramData.Value[2])
                    {
                        case 0: // Pressed
                            if (InputState.IsKeyPress(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                        case 1: // Held
                            if (InputState.IsKeyHeld(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                        case 2: // Released
                            if (InputState.IsNewKeyReleased(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                        case 3: // New Pressed
                            if (InputState.IsNewKeyPress(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                    }
                }

                if ((bool)eventProgramData.Value[3])
                {
                    // Button
                    Buttons key = InputState.ButtonsList[(int)eventProgramData.Value[4]];
                    switch ((int)eventProgramData.Value[5])
                    {
                        case 0: // Pressed
                            if (InputState.IsButtonPress(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                        case 1: // Held
                            if (InputState.IsButtonHeld(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                        case 2: // Released
                            if (InputState.IsNewButtonReleased(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                        case 3: // New Pressed
                            if (InputState.IsNewButtonPress(key, (int)eventProgramData.Value[6]))
                                result = true;
                            break;
                        case 4: // Move (Stick)
                            if (key == Buttons.LeftStick)
                            {
                                if (InputState.LeftStickMove((int)eventProgramData.Value[6]))
                                    result = true;
                                break;
                            }
                            else if (key == Buttons.RightStick)
                            {
                                if (InputState.RightStickMove((int)eventProgramData.Value[6]))
                                    result = true;
                                break;
                            }
                            break;
                    }
                }
                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check mouse input
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckMouseInput(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;

                // Mouse
                ButtonState state = ButtonState.Pressed;
                switch ((int)eventProgramData.Value[0])
                {
                    case 0:
                        state = Mouse.GetState().LeftButton;
                        if ((int)eventProgramData.Value[1] == 1)
                            result = InputState.IsMouseHeld("Left");
                        break;
                    case 2:
                        state = Mouse.GetState().RightButton;
                        if ((int)eventProgramData.Value[1] == 1)
                            result = InputState.IsMouseHeld("Right");
                        break;
                    case 3:
                        if ((int)eventProgramData.Value[1] != 3)
                            return;
                        break;
#if !SILVERLIGHT
                    case 1:
                        state = Mouse.GetState().MiddleButton;
                        if ((int)eventProgramData.Value[1] == 1)
                            result = InputState.IsMouseHeld("Middle");
                        break;
                    case 4:
                        state = Mouse.GetState().XButton1;
                        if ((int)eventProgramData.Value[1] == 1)
                            result = InputState.IsMouseHeld("X1");
                        break;
                    case 5:
                        state = Mouse.GetState().XButton2;
                        if ((int)eventProgramData.Value[1] == 1)
                            result = InputState.IsMouseHeld("X2");
                        break;
#endif
                }
                switch ((int)eventProgramData.Value[1])
                {
                    case 0: // Pressed
                        if (state == ButtonState.Pressed)
                            result = true;
                        break;
                    case 2: // Released
                        if (state == ButtonState.Released)
                            result = true;
                        break;
#if !SILVERLIGHT
                    case 3: // Scroll (Scroller)
                        if (InputState.LastMouseScrollValue > Mouse.GetState().ScrollWheelValue)
                        {
                            InputState.MouseScrollValue += Math.Abs(InputState.LastMouseScrollValue - Mouse.GetState().ScrollWheelValue);
                            // Record last value
                            InputState.LastMouseScrollValue = Mouse.GetState().ScrollWheelValue;
                            result = true;
                        }
                        else if (InputState.LastMouseScrollValue < Mouse.GetState().ScrollWheelValue)
                        {
                            InputState.MouseScrollValue -= Math.Abs(Mouse.GetState().ScrollWheelValue - InputState.LastMouseScrollValue);
                            // Record last value
                            InputState.LastMouseScrollValue = Mouse.GetState().ScrollWheelValue;
                            result = true;
                        }
                        break;
#endif
                }

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check String Condition
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckStringCondition(EventProgramData eventProgramData)
        {
            try
            {
                StringData strings = Global.Instance.Strings.GetData((int)eventProgramData.Value[0]);
                bool result = false;
                string value = "";

                switch ((int)eventProgramData.Value[2])
                {
                    case 0: //Costant
                        value = (string)eventProgramData.Value[3];
                        break;
                    case 1: // Strings
                        value = Global.Instance.Strings.GetData((int)eventProgramData.Value[3]).Value;
                        break;
                    case 2: // 
                        value = (string)Global.GetDataProperty((int)eventProgramData.Value[3], (int)eventProgramData.Value[4], (int)eventProgramData.Value[5]).Value;
                        break;
                }

                switch ((int)eventProgramData.Value[1])
                {
                    case 0: // Equals
                        if (strings.Value == value)
                            result = true;
                        break;
                    case 1: // Does not equal
                        if (strings.Value != value)
                            result = true;
                        break;
                }

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check Other COndition
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckOtherCondition(EventProgramData eventProgramData)
        {
            try
            {
                int x = 0, y = 0;
                bool result = false;
                switch ((int)eventProgramData.Value[0])
                {
                    case 0: // Tile
                        switch ((int)eventProgramData.Value[2])
                        {
                            case 0: // Const
                                x = (int)eventProgramData.Value[3];
                                y = (int)eventProgramData.Value[4];
                                break;
                            case 1: // Variable
                                x = (int)Global.Variable((int)eventProgramData.Value[3]);
                                y = (int)Global.Variable((int)eventProgramData.Value[4]);
                                break;
                        }

                        switch ((int)eventProgramData.Value[5])
                        {
                            case 0: // Tag
                                result = Global.Instance.CurrentMap.TileTags(x, y).Contains((int)eventProgramData.Value[6]);
                                break;
                        }
                        break;
                    case 1: // Platform
#if WINDOWS
                        result = ((int)eventProgramData.Value[2] == 0);
#elif XBOX
                        result = ((int)eventProgramData.Value[2] == 1);
#elif SILVERLIGHT
                        result = ((int)eventProgramData.Value[2] == 2);
#endif
                        break;
                    case 2: // Check If File Exists
                        int fileIndex = (int)GetValue((int)eventProgramData.Value[2], (int)eventProgramData.Value[3]);
                        string filename = "saved" + (fileIndex + 1).ToString() + ".svdat";
#if WINDOWS
                        result = File.Exists(filename);
#elif XBOX
                        if (Global.StorageDeviceManager.Device != null)
                        {
                            // Open a storage container.
                            IAsyncResult iresult =
                                Global.StorageDeviceManager.Device.BeginOpenContainer(Global.Project.Name, null, null);

                            // Wait for the WaitHandle to become signaled.
                            iresult.AsyncWaitHandle.WaitOne();

                            StorageContainer container = Global.StorageDeviceManager.Device.EndOpenContainer(iresult);

                            // Close the wait handle.
                            iresult.AsyncWaitHandle.Close();
                            // Check to see whether the save exists.
                            result = container.FileExists(filename);
                        }
#endif
                        break;
                }

                // Opposite
                if ((int)eventProgramData.Value[1] == 1)
                    result = !result;

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check Battle Condition
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckBattleCondition(EventProgramData eventProgramData, EventProcessor parent)
        {
            try
            {
                bool result = false;
                IBattler battler = null;
                if ((int)eventProgramData.Value[0] == 0 || (int)eventProgramData.Value[0] == 1)
                {
                    battler = ((int)eventProgramData.Value[0] == 0 ? parent.Battler : parent.Target.Battler);
                    if (battler != null)
                    {
                        int property = battler.GetPropertyValue((int)eventProgramData.Value[3]);
                        int value = 0;
                        if ((int)eventProgramData.Value[5] == 0)
                        {
                            value = (int)eventProgramData.Value[6];
                        }
                        else
                        {
                            value = battler.GetPropertyValue((int)eventProgramData.Value[6]);
                        }

                        switch ((int)eventProgramData.Value[4])
                        {
                            case 0: //Equals (=)
                                result = ((int)property == value);
                                break;
                            case 1: //Greater Than (>)
                                result = ((int)property > value);
                                break;
                            case 2: //Less Than (<)
                                result = ((int)property < value);
                                break;
                            case 3: //Greater Than Or Equals (>=)
                                result = ((int)property >= value);
                                break;
                            case 4: //Less Than Or Equals (<=)
                                result = ((int)property <= value);
                                break;
                            case 5: //Does Not Equal (!=)
                                result = ((int)property != value);
                                break;
                        }
                    }
                }
                else
                {
                    if (this is EventProcessor)
                    {
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Has Target
                                result = (parent.Target != null);
                                break;
                            case 1: //Target Is Far?
                                if (((EventProcessor)this).Target != null)
                                    result = ((EventProcessor)this).TargetIsFar(out ((EventProcessor)this).TargetRange);
                                break;
                            case 2: // Target In Sight?
                                if (((EventProcessor)this).Target != null)
                                    result = ((EventProcessor)this).IsFacing(parent.Target.Position, parent.Target.Body);
                                break;
                            case 3: // Battler is dead?
                                if (((EventProcessor)this).Battler != null)
                                {
                                    if (((EventProcessor)this).IsPlayer)
                                        result = Global.Instance.Party.IsDead();
                                    else
                                        result = battler.IsDead();
                                }
                                else
                                    result = true;
                                break;
                            case 4: // Target is dead
                                result = (((EventProcessor)this).Target == null || ((EventProcessor)this).Target.Battler == null || ((EventProcessor)this).Target.Battler.IsDead() || ((EventProcessor)this).Target.Erase);
                                break;
                        }
                    }
                }

                // Opposite
                if ((int)eventProgramData.Value[1] == 1)
                    result = !result;

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check Item Skill Condition
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckItemSkillCondition(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;
                int id = (int)Global.Variable((int)eventProgramData.Value[2]);
                switch ((int)eventProgramData.Value[0])
                {
                    case 0: // Item
                        ItemData item = GameData.Items.GetData(id);
                        if (item != null)
                        {
                            switch ((int)eventProgramData.Value[3])
                            {
                                case 0: // Scope
                                    result = (item.Scope == (ItemScope)(int)eventProgramData.Value[4]);
                                    break;
                                case 1: // Can be used on party member
                                    if (item.Scope == ItemScope.AllAllies || item.Scope == ItemScope.AllPartyDead || item.Scope == ItemScope.OneAllyDead || item.Scope == ItemScope.OneHero || item.Scope == ItemScope.User)
                                    {
                                        int partyIndex = (int)Global.Variable((int)eventProgramData.Value[4]);

                                        if (item.EnableCondition)
                                            result = Global.Instance.Party.CanItemEffect(partyIndex, item);
                                        else
                                            result = true;
                                    }
                                    break;
                                case 2: // Can be used on party
                                    if (item.Scope == ItemScope.AllAllies || item.Scope == ItemScope.AllPartyDead || item.Scope == ItemScope.OneAllyDead || item.Scope == ItemScope.OneHero || item.Scope == ItemScope.User)
                                    {
                                        if (item.EnableCondition)
                                            result = Global.Instance.Party.CanItemEffect(item);
                                        else
                                            result = true;
                                    }
                                    break;
                                case 3: // Can be bought?
                                    result = (item.Consumable && item.Price <= Global.Variable((int)eventProgramData.Value[4]));
                                    break;
                                case 4: // Can be sold?
                                    result = (item.Consumable);
                                    break;
                                case 5: // Can Item Be Used By
                                    result = Global.Instance.Party.CanUseItem((int)Global.Variable((int)eventProgramData.Value[4]), item);
                                    break;

                            }
                        }
                        break;
                    case 1: // Skill
                        SkillData skill = GameData.Skills.GetData(id);
                        if (skill != null)
                        {
                            switch ((int)eventProgramData.Value[3])
                            {
                                case 0: // Scope
                                    result = (skill.Scope == (ItemScope)(int)eventProgramData.Value[4]);
                                    break;
                                case 1: // Can be used on party member
                                    if (skill.Scope == ItemScope.AllAllies || skill.Scope == ItemScope.AllPartyDead || skill.Scope == ItemScope.OneAllyDead || skill.Scope == ItemScope.OneHero || skill.Scope == ItemScope.User)
                                    {
                                        int partyIndex = (int)Global.Variable((int)eventProgramData.Value[4]);

                                        if (skill.EnableCondition)
                                            result = Global.Instance.Party.CanSkillEffect(partyIndex, skill);
                                        else
                                            result = true;
                                    }
                                    break;
                                case 2: // Can be used on party
                                    if (skill.Scope == ItemScope.AllAllies || skill.Scope == ItemScope.AllPartyDead || skill.Scope == ItemScope.OneAllyDead || skill.Scope == ItemScope.OneHero || skill.Scope == ItemScope.User)
                                    {
                                        if (skill.EnableCondition)
                                            result = Global.Instance.Party.CanSkillEffect(skill);
                                        else
                                            result = true;
                                    }
                                    break;
                                case 3: // Can use skill
                                    if (skill.Scope == ItemScope.AllAllies || skill.Scope == ItemScope.AllPartyDead || skill.Scope == ItemScope.OneAllyDead || skill.Scope == ItemScope.OneHero || skill.Scope == ItemScope.User)
                                    {
                                        int partyIndex = (int)Global.Variable((int)eventProgramData.Value[4]);

                                        result = Global.Instance.Party.CanUseSkill(partyIndex, skill);
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2: // Equipment
                        EquipmentData equip = GameData.Equipments.GetData(id);

                        if (equip != null)
                        {
                            switch ((int)eventProgramData.Value[3])
                            {
                                case 0: // Can be equipped by party member
                                    HeroProcessor hero = Global.Instance.Party.GetPartyMemberFromIndex((int)Global.Variable((int)eventProgramData.Value[4]));
                                    if (hero != null)
                                    {
                                        result = equip.UsableBy.Contains(hero.ID);
                                    }
                                    break;
                                case 1: // Is Offensive
                                    result = (equip.EquipType == EquipType.Offensive);
                                    break;
                                case 2: // Can be bought?
                                    result = (equip.Price <= Global.Variable((int)eventProgramData.Value[4]));
                                    break;
                                case 3: // Can be sold?
                                    result = true;
                                    break;
                            }
                        }
                        else
                            result = true;
                        break;
                }

                // Opposite
                if ((int)eventProgramData.Value[1] == 1)
                    result = !result;

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check Party Conditions
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckPartyConditions(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;

                switch ((int)eventProgramData.Value[0])
                {
                    case 0:
                        HeroProcessor battler = Global.Instance.Party.GetPartyMemberFromIndex((int)GetValue((int)eventProgramData.Value[2], (int)eventProgramData.Value[3]));
                        if (battler != null)
                        {
                            int property = battler.GetPropertyValue((int)eventProgramData.Value[4]);
                            int value = 0;
                            if ((int)eventProgramData.Value[6] == 0)
                                value = (int)eventProgramData.Value[7];
                            else
                                value = battler.GetPropertyValue((int)eventProgramData.Value[7]);
                            switch ((int)eventProgramData.Value[5])
                            {
                                case 0: //Equals (=)
                                    result = ((int)property == value);
                                    break;
                                case 1: //Greater Than (>)
                                    result = ((int)property > value);
                                    break;
                                case 2: //Less Than (<)
                                    result = ((int)property < value);
                                    break;
                                case 3: //Greater Than Or Equals (>=)
                                    result = ((int)property >= value);
                                    break;
                                case 4: //Less Than Or Equals (<=)
                                    result = ((int)property <= value);
                                    break;
                                case 5: //Does Not Equal (!=)
                                    result = ((int)property != value);
                                    break;
                            }
                        }
                        break;
                    case 1: // Has Item
                        result = Global.Instance.Party.HasItem((int)eventProgramData.Value[2]);
                        break;
                    case 2: // Has Equipment
                        result = Global.Instance.Party.HasEquipment((int)eventProgramData.Value[2]);
                        break;
                    case 3: // Party Includes Member?
                        result = Global.Instance.Party.ContainsHero((int)eventProgramData.Value[2]);
                        break;
                    case 4: // Party Dead?
                        result = Global.Instance.Party.IsDead();
                        break;
                    case 5: // Party Member Dead?
                        HeroProcessor dead = Global.Instance.Party.GetPartyMemberFromIndex((int)GetValue((int)eventProgramData.Value[2], (int)eventProgramData.Value[3]));
                        if (dead != null) result = dead.IsDead();
                        break;
                }
                // Opposite
                if ((int)eventProgramData.Value[1] == 1)
                    result = !result;

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Check Guide Conditions
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void CheckGuideConditions(EventProgramData eventProgramData)
        {
            try
            {
                bool result = false;
                SignedInGamer gamer;

                switch ((int)eventProgramData.Value[0])
                {
                    case 0: // Is Game In Trial Mode?
                        result = Guide.IsTrialMode;
                        break;
                    case 1: // Is Storage Selected?
                        result = Global.Storage != null;
                        break;
                    case 2: // Is Player Signed In?
                        if (InputState.GetPlayer((int)eventProgramData.Value[2]) != null)
                        {
                            gamer = Gamer.SignedInGamers[(int)InputState.GetPlayer((int)eventProgramData.Value[2])];
                            result = (gamer != null);
                        }
                        break;
#if !SILVERLIGHT
                    case 3: // Is Player Live?
                        if (InputState.GetPlayer((int)eventProgramData.Value[2]) != null)
                        {
                            gamer = Gamer.SignedInGamers[(int)InputState.GetPlayer((int)eventProgramData.Value[2])];
                            if (gamer != null)
                                result = gamer.IsSignedInToLive;
                        }
                        break;
                    case 4: // Is Player Guest? 
                        if (InputState.GetPlayer((int)eventProgramData.Value[2]) != null)
                        {
                            gamer = Gamer.SignedInGamers[(int)InputState.GetPlayer((int)eventProgramData.Value[2])];
                            if (gamer != null)
                                result = gamer.IsGuest;
                        }
                        break;
#endif
                }
                // Opposite
                if ((int)eventProgramData.Value[1] == 1)
                    result = !result;

                if (result)
                    SetupBranch(eventProgramData);
                else if (eventProgramData.Else)
                    SetupElseBranch(eventProgramData);
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        #endregion

        #region Helper: Set Data (Switch, Variable, Locals, List, Database, String. Used by Event Program
        /// <summary>
        /// Set Switch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void SetSwitch(EventProgramData eventProgramData, SwitchData swi)
        {
            switch ((int)eventProgramData.Value[2])
            {
                case 1: // Bool
                    swi.State = (bool)eventProgramData.Value[1];
                    break;
                case 2: // Switch
                    swi.State = Global.Switch((int)eventProgramData.Value[1]);
                    break;
                case 3: // Local Switch
                    swi.State = Switches[(int)eventProgramData.Value[1]].State;
                    break;
            }
        }
        /// <summary>
        /// Set Variable
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void SetVariable(EventProgramData eventProgramData, VariableData variable)
        {
            try
            {
                float value = 0;
                switch ((int)eventProgramData.Value[2])
                {
                    case 0: // Constant
                        value = (int)eventProgramData.Value[3];
                        break;
                    case 1: // Random
                        Random rand = new Random();
                        value = rand.Next((int)eventProgramData.Value[3], (int)eventProgramData.Value[4]);
                        break;
                    case 2: // Varaible
                        value = Global.Instance.Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 3: // Local Variable
                        value = Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 4: // Event
                        EventProcessor e = GetEvent((int)eventProgramData.Value[3]);
                        if (e != null)
                        {
                            switch ((int)eventProgramData.Value[4])
                            {
                                case 0: // Position X
                                    value = e.Position.X;
                                    break;
                                case 1: // Position Y
                                    value = e.Position.Y;
                                    break;
                                case 2: // Map ID
                                    value = e.MapID;
                                    break;
                                case 3: // Angle
                                    value = e.Angle;
                                    break;
                                case 4: // Force X
                                    if (e.Body != null)
                                        value = e.Body.Force.X;
                                    break;
                                case 5: // Force Y
                                    if (e.Body != null)
                                        value = e.Body.Force.Y;
                                    break;
                                case 6: // Mass
                                    value = e.Mass;
                                    break;
                            }
                        }
                        break;
                    case 5: // Data
                        value = (int)Global.GetDataProperty((int)eventProgramData.Value[3], (int)eventProgramData.Value[4], (int)eventProgramData.Value[5]).Value;
                        break;
                    case 6: // Mouse Pos
                        if ((int)eventProgramData.Value[3] == 0)
                        {
                            value = (int)Mouse.GetState().X;
                            // Convert position to map coordinates if required.
                            if ((int)eventProgramData.Value[4] == 1)
                                value = (int)Global.Instance.ActiveCamera.GetTransformedPoint(new Vector2(value, Mouse.GetState().Y)).X;
                        }
                        else if ((int)eventProgramData.Value[3] == 1)
                        {
                            value = (int)Mouse.GetState().Y;
                            // Convert position to map coordinates if required.
                            if ((int)eventProgramData.Value[4] == 1)
                                value = (int)Global.Instance.ActiveCamera.GetTransformedPoint(new Vector2(Mouse.GetState().X, value)).Y;
                        }
                        else
                        {
                            value = InputState.MouseScrollValue;
                        }
                        break;
                    case 7: // Get stick axis
                        if ((int)eventProgramData.Value[3] == 0)
                        {
                            if ((int)eventProgramData.Value[4] == 0)
                            {
                                value = (int)InputState.GetRightStick((int)eventProgramData.Value[5]).X;
                            }
                            else
                            {
                                value = (int)InputState.GetRightStick((int)eventProgramData.Value[5]).Y;
                            }
                        }
                        else if ((int)eventProgramData.Value[3] == 1)
                        {
                            if ((int)eventProgramData.Value[4] == 0)
                            {
                                value = (int)InputState.GetLeftStick((int)eventProgramData.Value[5]).X;
                            }
                            else
                            {
                                value = (int)InputState.GetLeftStick((int)eventProgramData.Value[5]).Y;
                            }
                        }
                        break;
                    case 8: // Battler
                        if (this is EventProcessor && ((EventProcessor)this).Battler != null)
                        {
                            value = ((EventProcessor)this).Battler.GetPropertyValue((int)eventProgramData.Value[3]);
                        }
                        break;
                    case 9: // Other 
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Map ID
                                value = Global.Instance.CurrentMap.Data.ID;
                                break;
                            case 1: // Hit Counter
                                value = Global.Instance.HitCount;
                                break;
                            case 2: // Last Exp Gained
                                value = Global.Instance.LastExpGained;
                                break;
                            case 3: // Total Exp Gained
                                value = Global.Instance.TotalExpGained;
                                break;
                            case 4: // Item Price
                                ItemData item;
                                if (GameData.Items.TryGetValue((int)Global.Variable((int)eventProgramData.Value[4]), out item))
                                    value = item.Price;
                                break;
                            case 5: // Equipment Price
                                EquipmentData equipment;
                                if (GameData.Equipments.TryGetValue((int)Global.Variable((int)eventProgramData.Value[4]), out equipment))
                                    value = equipment.Price;
                                break;
                            case 6: // Party Size
                                value = Global.Instance.Party.Heroes.Count;
                                break;
                            case 7: // Number of items
                                value = Global.Instance.Party.Heroes[(int)Global.Variable((int)eventProgramData.Value[4])].GetItems().Values.Count((int)Global.Variable((int)eventProgramData.Value[5]));
                                break;
                            case 8: // Number of equipments
                                value = Global.Instance.Party.Heroes[(int)Global.Variable((int)eventProgramData.Value[4])].GetEquipments().Values.Count((int)Global.Variable((int)eventProgramData.Value[5]));
                                break;
                        }
                        break;
                }
                switch ((int)eventProgramData.Value[1])
                {
                    case 0: // Set 
                        variable.Value = value;
                        break;
                    case 1: // Add
                        variable.Value += value;
                        break;
                    case 2: // Sub
                        variable.Value -= value;
                        break;
                    case 3: // Multi
                        variable.Value *= value;
                        break;
                    case 4: // Divide
                        variable.Value /= value;
                        break;
                    case 5: // Exponaniate
                        variable.Value = (int)Math.Pow((double)variable.Value, (double)value);
                        break;
                    case 6: // Modulate
                        variable.Value %= value;
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Set List
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void SetList(EventProgramData eventProgramData)
        {
            try
            {
                float value = 0;
                switch ((int)eventProgramData.Value[2])
                {
                    case 0: // Constant
                        value = (int)eventProgramData.Value[3];
                        break;
                    case 1: // Random
                        Random rand = new Random();
                        value = rand.Next((int)eventProgramData.Value[3], (int)eventProgramData.Value[4]);
                        break;
                    case 2: // Varaible
                        value = Global.Instance.Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 3: // Local Variable
                        value = Variables[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 4: // Event
                        EventProcessor e = GetEvent((int)eventProgramData.Value[3]);
                        if (e != null)
                        {
                            switch ((int)eventProgramData.Value[4])
                            {
                                case 0: // Position X
                                    value = (int)e.Position.X;
                                    break;
                                case 1: // Position Y
                                    value = (int)e.Position.Y;
                                    break;
                            }
                        }
                        break;
                    case 5: // Data
                        value = (int)Global.GetDataProperty((int)eventProgramData.Value[3], (int)eventProgramData.Value[4], (int)eventProgramData.Value[5]).Value;
                        break;
                    case 6: // Other 
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Map ID
                                if (Global.Instance.CurrentMap == null)
                                    throw new Exception("The current map is null. Make sure the map is loaded.");
                                value = Global.Instance.CurrentMap.Data.ID;
                                break;
                        }
                        break;
                }
                switch ((int)eventProgramData.Value[1])
                {
                    case 0: // Add
                        Global.Instance.Lists[(int)eventProgramData.Value[0]].Values.Add((int)value);
                        break;
                    case 1: // Remove
                        Global.Instance.Lists[(int)eventProgramData.Value[0]].Values.Remove((int)value);
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Set Database
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void SetDataBase(EventProgramData eventProgramData)
        {
            try
            {
                DataProperty property;
                property = Global.GetDataProperty((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], (int)eventProgramData.Value[2]);
                if (property != null)
                {
                    if (property.ValueType == DataType.Number)
                    {
                        float value = 0;
                        switch ((int)eventProgramData.Value[4])
                        {
                            case 0: // Constant
                                value = (int)eventProgramData.Value[5];
                                break;
                            case 1: // Random
                                Random rand = new Random();
                                value = rand.Next((int)eventProgramData.Value[5], (int)eventProgramData.Value[6]);
                                break;
                            case 2: // Varaible
                                value = Global.Instance.Variables[(int)eventProgramData.Value[5]].Value;
                                break;
                            case 3: // Local Variable
                                value = Variables[(int)eventProgramData.Value[5]].Value;
                                break;
                            case 4: // Event
                                EventProcessor e = GetEvent((int)eventProgramData.Value[5]);
                                if (e != null)
                                {
                                    switch ((int)eventProgramData.Value[6])
                                    {
                                        case 0: // Position X
                                            value = (int)e.Position.X;
                                            break;
                                        case 1: // Position Y
                                            value = (int)e.Position.Y;
                                            break;
                                    }
                                }
                                break;
                            case 5: // Data
                                value = (int)Global.GetDataProperty((int)eventProgramData.Value[5], (int)eventProgramData.Value[6], (int)eventProgramData.Value[7]).Value;
                                break;
                            case 6: // Other 
                                switch ((int)eventProgramData.Value[5])
                                {
                                    case 0: // Map ID
                                        if (Global.Instance.CurrentMap == null)
                                            throw new Exception("The current map is null. Make sure the map is loaded.");
                                        value = Global.Instance.CurrentMap.Data.ID;
                                        break;
                                }
                                break;
                        }
                        switch ((int)eventProgramData.Value[3])
                        {
                            case 0: // Set 
                                property.Value = value;
                                break;
                            case 1: // Add
                                property.Value = (int)property.Value + value;
                                break;
                            case 2: // Sub
                                property.Value = (int)property.Value - value;
                                break;
                            case 3: // Multi
                                property.Value = (int)property.Value * value;
                                break;
                            case 4: // Divide
                                property.Value = (int)property.Value / value;
                                break;
                            case 5: // Exponaniate
                                property.Value = (int)Math.Pow((double)property.Value, (double)value);
                                break;
                            case 6: // Modulate
                                property.Value = (int)property.Value % value;
                                break;
                        }
                    }
                    else if (property.ValueType == DataType.Text)
                    {
                        property.Value = (string)eventProgramData.Value[3];
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        /// <summary>
        /// Set string
        /// </summary>
        /// <param name="eventProgramData"></param>
        public void SetString(EventProgramData eventProgramData)
        {
            try
            {
                string value = "";
                switch ((int)eventProgramData.Value[2])
                {
                    case 0: // Constant
                        value = (string)eventProgramData.Value[3];
                        break;
                    case 1: // String
                        value = Global.Instance.Strings[(int)eventProgramData.Value[3]].Value;
                        break;
                    case 2: // Data
                        value = (string)Global.GetDataProperty((int)eventProgramData.Value[3], (int)eventProgramData.Value[4], (int)eventProgramData.Value[5]).Value;
                        break;
                }

                switch ((int)eventProgramData.Value[1])
                {
                    case 0: // Set 
                        Global.Instance.Strings[(int)eventProgramData.Value[0]].Value = value;
                        break;
                    case 1: // Append
                        Global.Instance.Strings[(int)eventProgramData.Value[0]].Value += value;
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
        }
        #endregion

        #region Helper: Other
        /// <summary>
        /// Returns a skill hotkey with same settings
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="type">0-keyboard 1-controller</param>
        /// <returns></returns>
        private Hotkey GetSkillHotkey(int key1, int key2, int type)
        {
            if (type == 0)
            {
                foreach (Hotkey key in Global.Instance.SkillKeys)
                {
                    if (key.Key1 == key1 && key.Key2 == key2)
                        return key;
                }
            }
            else
            {
                foreach (Hotkey key in Global.Instance.SkillKeys)
                {
                    if (key.Button1 == key1 && key.Button2 == key2)
                        return key;
                }
            }
            return null;
        }
        /// <summary>
        /// Returns an item hotkey with same settings
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="type">0-keyboard 1-controller</param>
        /// <returns></returns>
        private Hotkey GetItemHotkey(int key1, int key2, int type)
        {
            if (type == 0)
            {
                foreach (Hotkey key in Global.Instance.ItemKeys)
                {
                    if (key.Key1 == key1 && key.Key2 == key2)
                        return key;
                }
            }
            else
            {
                foreach (Hotkey key in Global.Instance.ItemKeys)
                {
                    if (key.Button1 == key1 && key.Button2 == key2)
                        return key;
                }
            }
            return null;
        }
        #endregion
        #endregion

        #region Overrides
        // Program
        public IEventProgram CurrentBranch;
        public List<IEventProgram> LastBranch = new List<IEventProgram>();
        public List<int> LastProgramIndex = new List<int>();
        public Dictionary<string, Bookmark> labels = new Dictionary<string, Bookmark>();
        public Dictionary<int, VariableData> Variables;
        public Dictionary<int, SwitchData> Switches;
        public ActionType actionTakingPlace;
        public bool waitActionCompelition;
        public int waitFrames;
        public bool isProgramActive
        {
            get { return _isactive; }
            set 
            {
                if (this is EventProcessor)
                    if (((EventProcessor)this).Data.ID == 10)
                        _isactive  = value;
                _isactive = value; 
            }
        }
        bool _isactive = false;
        public int programIndex = 0;
        public virtual EventProcessor GetEvent(int id)
        {
            return null;
        }
        public virtual float GetValue(int type, int id)
        {
            return 0;
        }
        public virtual float GetValue(int type, float id)
        {
            return 0;
        }
        public virtual void NextProgram()
        {
        }
        public virtual void SetupBranch(EventProgramData eventProgramData)
        {
        }
        public virtual void SetupElseBranch(EventProgramData eventProgramData)
        {
        }
        public virtual void BreakBranch(ref int index, bool ignoreTop)
        {
        }
        public virtual void BreakBranch(ref int index)
        {
        }
        public virtual void SetupProgramMovement(EventProgramData eventProgramData)
        {
        }
        #endregion
    }
}
