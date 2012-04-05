//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the event's program data.
    /// </summary>
    [Serializable]
    public class EventProgramData : IEventProgram
    {
        /// <summary>
        /// Name of the program. Often represents its display in program list.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// GetName
        /// </summary>
        /// <returns></returns>
        #region GET NAME
        internal string GetName(IEvent ev, EventPageData page)
        {
            switch (ProgramCategory)
            {
                case ProgramCategory.Movement: // Movement
                    return GetMovementName(ev, page);
                case ProgramCategory.Settings: // Settings
                    return GetSettingsName(ev, page);
                case ProgramCategory.Display: // Display
                    return GetDisplayName(ev, page);
                case ProgramCategory.Conditions: // Conditions
                    return GetConditionsName(ev, page);
                case ProgramCategory.Loops: // Loops
                    return name;
                case ProgramCategory.Audio: // Audio
                    return GetAudioName(ev, page);
                case ProgramCategory.Data: // Data
                    return GetDataName(ev, page);
                case ProgramCategory.Event: // Event
                    return GetEventName(ev, page);
                case ProgramCategory.Map: // Map
                    return GetMapName(ev, page);
                case ProgramCategory.Screen: // Screen
                    return GetScreenName(ev, page);
                case ProgramCategory.Graphics: // Graphics
                    return GetGraphicsName(ev, page);
                case ProgramCategory.Guide: // Memory
                    return GetMemoryName(ev, page);
                case ProgramCategory.Other: // Other
                    return GetOtherName(ev, page);
                case ProgramCategory.Party: // Party
                    return GetPartyName(ev, page);
                case ProgramCategory.Hero: // Hero
                    return GetHeroName(ev, page);
                case ProgramCategory.Menu: // menu
                    return GetMenuName(ev, page);
                case ProgramCategory.Battle: // Battle
                    return GetBattleName(ev, page);
                case ProgramCategory.Attachment:
                    return GetAttachmentName(ev, page);
            }
            return "ERROR - PROGRAM OUT OF RANGE {" + ProgramCategory.ToString() + "}";
        }

        private string GetAttachmentName(IEvent ev, EventPageData page)
        {
            AttachmentJoint att;
            string attName = "No Attachment";
            switch (Code)
            {
                case 1: // Edit Attachment Animation
                    AnimationData animation = Global.GetData<AnimationData>((int)val[1], GameData.Animations);
                    if (animation != null)
                    {
                        AnimationAction action = Global.GetData<AnimationAction>((int)val[2], animation.Actions);
                        att = Global.GetData<AttachmentJoint>((int)val[0], page.Attachments);
                        if (att != null) attName = att.Name;
                        if (action != null)
                            return name = "Change Event [" + attName + "]'s Animation To [" + animation.Name + "] > [" + action.Name + "]";
                        else
                            return name = "Change Event [" + attName + "]'s Animation To [" + animation.Name + "] > [No Action]";
                    }
                    return name = "Change Event [" + attName + "]'s Animation To [No Animation] > [No Action]";
            }
            return name;
        }

        private string GetGraphicsName(IEvent ev, EventPageData page)
        {
            switch (Code)
            {
                case 1:
                    name = "Begin Draw: " + ((int)Value[4] == 0 ? "Line" : (int)Value[4] == 1 ? "Rectangle" : "Circle") + " ";
                    return name;
            }
            return "ERROR - PROGRAM OUT OF RANGE {" + ProgramCategory.ToString() + ", " + Code.ToString() + "}";
        }

        private string GetMemoryName(IEvent ev, EventPageData page)
        {
            VariableData var;
            switch (code)
            {
                case 1: //save
                    name = "Save Game: ";
                    if ((int)val[0] == 0)
                    {
                        name += val[1].ToString();
                    }
                    else
                    {
                        var = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                        if (var != null)
                            name += "[" + var.Name + "]";
                        else
                            name += "[No Variable]";
                    }
                    return name;
                case 2: // Load
                    name = "Load Game: ";
                    if ((int)val[0] == 0)
                    {
                        name += val[1].ToString();
                    }
                    else
                    {
                        var = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                        if (var != null)
                            name += "[" + var.Name + "]";
                        else
                            name += "[No Variable]";
                    }
                    return name;
            }
            return name;
        }

        private string GetBattleName(IEvent ev, EventPageData page)
        {
            HeroData hero;
            switch (Code)
            {
                case 1: // Command Player
                    switch ((int)val[0])
                    {
                        case 0:
                            name = "Command Ally: Party Index [" + val[1].ToString() + "] ";
                            break;
                        case 1:
                            hero = Global.GetData<HeroData>((int)val[1], GameData.Heroes);

                            name = "Command Ally: Hero [" + (hero != null ? hero.Name : "No Hero") + "] ";
                            break;
                    }
                    name += ((int)val[2] == 0 ? "Attack" : "Defend");
                    break;
                case 2: // Command ALlies
                    return name;
                case 3: // Assign Ally As Target
                    switch ((int)val[0])
                    {
                        case 0:
                            name = "Assign Ally As Target: Party Index [" + val[1].ToString() + "] ";
                            break;
                        case 1:
                            hero = Global.GetData<HeroData>((int)val[1], GameData.Heroes);

                            name = "Assign Ally As Target: Hero [" + (hero != null ? hero.Name : "No Hero") + "] ";
                            break;
                    }
                    break;
                case 4: // Find Target(s)
                    return name;
                case 5: // Force Attack
                    return name;
                case 6: // Use Item
                    ItemData item = Global.GetData<ItemData>((int)val[0], GameData.Items);
                    if (item != null)
                        name = "Use Item [" + item.Name + "]";
                    else
                        name = "Use Item [No Item]";
                    break;
                case 7: // Use Skill/Magic
                    SkillData skill = Global.GetData<SkillData>((int)val[0], GameData.Skills);
                    if (skill != null)
                        name = "Use Skill [" + skill.Name + "]";
                    else
                        name = "Use Skill [No Skill]";
                    break;
                case 8: // Battle Conditions
                    name = "IF " + ((int)val[0] == 0 ? "Battler's " : (int)val[0] == 1 ? "Target's " : "");

                    List<DataProperty> prop;
                    if ((bool)Value[2])
                        prop = GameData.Databases[0].Properties;
                    else
                        prop = GameData.Databases[1].Properties;

                    DataProperty property;
                    switch ((int)Value[0])
                    {
                        case 0:// Battler
                            property = Global.GetData<DataProperty>((int)val[3], prop);

                            if (property != null)
                                name += "[" + property.Name + "]";
                            else
                                name = "[No Property]";

                            name += ((int)val[1] == 0 ? "" : " Does Not");

                            name += CompareToString((int)Value[4]);

                            if ((int)Value[5] == 0)
                            {
                                name += "[" + Value[6].ToString() + "]";
                            }
                            else
                            {
                                property = Global.GetData<DataProperty>((int)val[6], prop);
                                if (property != null)
                                    name += "[" + property.Name + "]";
                                else
                                    name = "[No Property]";
                            }
                            break;
                        case 1: // Target
                            property = Global.GetData<DataProperty>((int)val[3], prop);

                            if (property != null)
                                name += "[" + property.Name + "]";
                            else
                                name = "[No Property]";

                            name += ((int)val[1] == 0 ? "" : " Does Not");

                            name += CompareToString((int)Value[4]);

                            if ((int)Value[5] == 0)
                            {
                                name += "[" + Value[6].ToString() + "]";
                            }
                            else
                            {
                                property = Global.GetData<DataProperty>((int)val[6], prop);
                                if (property != null)
                                    name += "[" + property.Name + "]";
                                else
                                    name = "[No Property]";
                            }
                            break;
                        case 2: // Other
                            switch ((int)Value[3])
                            {
                                case 0: // Has Target
                                    name += ((int)val[1] == 0 ? "Has " : " Does Not Have ");
                                    name += "Target";
                                    break;
                                case 1: //Target Is Far?
                                    name += ((int)val[1] == 0 ? "" : "Does Not Have ");
                                    name += "Target In Range";
                                    break;
                                case 2: // Target In Sight?
                                    name += ((int)val[1] == 0 ? "Has " : "Does Not Have ");
                                    name += "Target In Sight";
                                    break;
                                case 3: // Battler is dead?
                                    name += ((int)val[1] == 0 ? "Is Battler Dead?" : "Is Battler Not Dead?");
                                    break;
                                case 4: // Target is dead?
                                    name += ((int)val[1] == 0 ? "Is Target Dead?" : "Is Target Not Dead?");
                                    break;
                            }
                            break;
                    }
                    break;
                case 9: // Clear Experience
                    return name;
                case 10: // Force Use SLot
                    string txt;

                    if (Global.Project.EquipmentSlots.TryGetValue((int)val[0], out txt))
                    {
                        name = "Force Use Slot: " + txt;
                    }
                    else
                        name = "Force Use Slot: NO SLOT";

                    return name;
            }
            return name;
        }

        private string GetMenuName(IEvent ev, EventPageData page)
        {
            IMenuParts part;
            string partName = "";
            switch (Code)
            {
                case 0: // Close Menu
                    return name;
                case 1: // Toggle Enable
                    part = Global.GetMenuPart<IMenuParts>((int)val[0]);
                    if (part != null)
                        partName = part.Name;
                    else if ((int)val[0] == -1)
                        partName = "This Menupart";
                    else
                        partName = "No Menupart";
                    switch ((int)val[1])
                    {
                        case 0:// Enable
                            name = "Enable Menupart [" + partName + "]";
                            return name;
                        case 1: // Disable
                            name = "Disable Menupart [" + partName + "]";
                            return name;

                    }
                    break;
                case 2: // Toggle Visible
                    part = Global.GetMenuPart<IMenuParts>((int)val[0]);
                    if (part != null)
                        partName = part.Name;
                    else if ((int)val[0] == -1)
                        partName = "This Menupart";
                    else
                        partName = "No Menupart";
                    switch ((int)val[1])
                    {
                        case 0:// Enable
                            name = "Show Menupart [" + partName + "]";
                            return name;
                        case 1: // Disable
                            name = "Hide Menupart [" + partName + "]";
                            return name;

                    }
                    break;
                case 3: // Select
                    part = Global.GetMenuPart<IMenuParts>((int)val[0]);

                    if (part != null)
                        partName = part.Name;
                    else if ((int)val[0] == -1)
                        partName = "This Menupart";
                    else
                        partName = "No Menupart";
                    name = "Select Menupart [" + partName + "]";

                    return name;
                case 4: // Conditions
                    part = Global.GetMenuPart<IMenuParts>((int)val[0]);
                    if (part != null)
                        partName = part.Name;
                    else if ((int)val[0] == -1)
                        partName = "This Menupart";
                    else
                        partName = "No Menupart";

                    name = "IF [" + partName + "] ";

                    switch ((int)val[1])
                    {
                        case 0:// Is
                            name += "Is "; break;
                        case 1: // Is Not
                            name += "Is Not "; break;
                    }
                    switch ((int)val[2])
                    {
                        case 0:// Enabled
                            name += "Enabled";
                            return name;
                        case 1: // Visible
                            name += "Visible";
                            return name;
                        case 2: // Selected
                            name += "Selected";
                            return name;
                    }
                    return name;
                case 5: // Move Menu
                    part = Global.GetMenuPart<IMenuParts>((int)val[0]);

                    if (part != null)
                        partName = part.Name;
                    else if ((int)val[0] == -1)
                        partName = "This Menupart";
                    else
                        partName = "No Menupart";

                    name = "Move Menupart [" + partName + "] To X [" + GetValue((int)val[1], (int)val[2]) + "] Y [" + GetValue((int)val[1], (int)val[3]) + "] In [" + val[4].ToString() + "] Frames";

                    return name;
            }
            return "ERROR - CODE OUT OF RANGE {" + Code.ToString() + "}";
        }

        private string GetHeroName(IEvent ev, EventPageData page)
        {
            HeroData hero;
            string strName = "";
            string text = "";
            string text2 = ""; string text3 = "";
            StringData stringD;
            hero = Global.GetData<HeroData>((int)val[0], GameData.Heroes);
            if (hero != null)
                strName = hero.Name;
            else
                strName = "No Hero";
            switch (Code)
            {
                case 1: // Change Name
                    switch ((int)val[1])
                    {
                        case 0:
                            text = "[ " + (string)val[2] + " ]";
                            break;
                        case 1:
                            stringD = Global.GetData<StringData>((int)val[2], GameData.Strings);
                            if (stringD != null)
                                text = "[" + stringD.Name + "]";
                            else
                                text = "[No String]";
                            break;
                    }
                    return "Change Name: Hero [" + strName + "] to " + text;
                case 2: // Change Equipment
                    if (!Global.Project.EquipmentSlots.TryGetValue((int)val[1], out text))
                        text = "[No Slot]";
                    EquipmentData equip = Global.GetData<EquipmentData>((int)val[2], GameData.Equipments);
                    if (equip != null)
                        text2 = "[" + equip.Name + "]";
                    else
                        text2 = "[No Equipment]";
                    return "Change Equipment: Hero [" + strName + "] Slot " + text + " Equipment " + text2;
                case 3: // Change State
                    switch ((int)val[1])
                    {
                        case 0:
                            text = "Add";
                            break;
                        case 2:
                            text = "Remove";
                            break;
                    }
                    StateData state = Global.GetData<StateData>((int)val[2], GameData.States);
                    if (state != null)
                        text2 = "[" + state.Name + "]";
                    else
                        text2 = "[No State]";
                    return "Change State: Hero [" + strName + "] " + text + " State " + text2;
                case 4: //Heal All
                    return "Heal All: Hero [" + strName + "]";
                case 5: // Skill
                    SkillData skill = Global.GetData<SkillData>((int)val[2], GameData.Skills);
                    if (skill != null && skill.SkillType == SkillType.Skill)
                        text2 = "[" + skill.Name + "]";
                    else
                        text2 = "[No Skill]";
                    switch ((int)val[1])
                    {
                        case 0:
                            text = "Learn";
                            break;
                        case 2:
                            text = "Forget";
                            break;
                    }
                    return "Change Skill: Hero [" + strName + "] " + text + " Skill " + text2;
                case 6: // Magic
                    SkillData magic = Global.GetData<SkillData>((int)val[2], GameData.Skills);
                    if (magic != null && magic.SkillType == SkillType.Magic)
                        text2 = "[" + magic.Name + "]";
                    else
                        text2 = "[No Magic]";
                    switch ((int)val[1])
                    {
                        case 0:
                            text = "Learn";
                            break;
                        case 2:
                            text = "Forget";
                            break;
                    }
                    return "Change Magic: Hero [" + strName + "] " + text + " Magic " + text2;
                case 7: // Change Parameter
                    string[] op = new string[] { "Set (=)", "Add (+)", "Subtract (-)", "Multiply (*)", "Divide (/)", "Exponentiate (^)", "Modulate (r)" };
                    string[] value = new string[] { "Constant", "Random Number", "Variable", "Local Variable" };
                    string[] parameters = new string[] { "HP", "SP", "MP", "Max HP", "Max SP", "Max MP", "STR", "DEF", "MSTR", "MDEF", "AGI", "LUK", "Level" };

                    switch ((int)val[3])
                    {
                        case 0:
                            text = "[" + val[4].ToString() + "]";
                            break;
                        case 1:
                            text = "Between [" + val[4].ToString() + "] and [" + val[5].ToString() + "]";
                            break;
                        case 2:
                            VariableData var = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                            if (var != null)
                                text = "[" + var.Name + "]";
                            else
                                text = "[No Variable]";
                            break;
                        case 3:
                            VariableData lvar = Global.GetData<VariableData>((int)val[4], ev.Variables);
                            if (lvar != null)
                                text = "[" + lvar.Name + "]";
                            else
                                text = "[No Variable]";
                            break;
                    }

                    DataProperty prop = Global.GetData<DataProperty>((int)val[1], GameData.Databases[0].Properties);
                    if (prop != null)
                    {

                        return "Change Parameter: Hero [" + strName + "] Parameter [" + prop.Name + "] " + op[(int)val[2]] + " " + value[(int)val[3]] + " " + text;
                    }

                    return "Change Parameter: Hero [" + strName + "] Parameter [No Propertt] " + op[(int)val[2]] + " " + value[(int)val[3]] + " " + text;
                case 8: // Change Items
                    ListData items = Global.GetData<ListData>((int)val[0], GameData.Lists);

                    if (items != null)
                        strName = items.Name;
                    else
                        strName = "No List";

                    text = ((int)val[2] == 0 ? "Increase" : "Decrease");

                    ItemData item = Global.GetData<ItemData>((int)val[1], GameData.Items);

                    text2 = (item != null ? item.Name : "No Item");

                    if ((int)val[3] == 0)
                        text3 = "[" + val[4].ToString() + "]";
                    else
                    {
                        VariableData itemVar = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                        text3 = (itemVar != null ? "Variable [" + itemVar.Name + "]" : "Variable [No Variable]");
                    }

                    return "Change Items: List [" + strName + "] " + text + " Item [" + text2 + "] By " + text3;
                case 9: // Change Equipments
                    ListData equips = Global.GetData<ListData>((int)val[0], GameData.Lists);

                    if (equips != null)
                        strName = equips.Name;
                    else
                        strName = "No List";

                    text = ((int)val[2] == 0 ? "Increase" : "Decrease");

                    EquipmentData eq = Global.GetData<EquipmentData>((int)val[1], GameData.Equipments);

                    text2 = (eq != null ? eq.Name : "No Item");

                    if ((int)val[3] == 0)
                        text3 = "[" + val[4].ToString() + "]";
                    else
                    {
                        VariableData eqVar = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                        text3 = (eqVar != null ? "Variable [" + eqVar.Name + "]" : "Variable [No Variable]");
                    }
                    if ((bool)val[5])
                        return "Change Equipments: List [" + strName + "] " + text + " Equipment [" + text2 + "] By " + text3 + " [Include Equipped]";
                    else
                        return "Change Equipments: List [" + strName + "] " + text + " Equipment [" + text2 + "] By " + text3;
                case 10: // Change Animation
                    HeroData h = Global.GetData<HeroData>((int)val[0], GameData.Heroes);
                    string[] actionTypes = new string[] {"Idle",
                        "Walking",
                        "Equipment (Offensive)", "Equipment (Defensive)", "Skill", "Magic","Item","Hit",
                        "Jump","Death",};

                    AnimationData animation = Global.GetData<AnimationData>((int)val[2], GameData.Animations);
                    if (animation != null)
                    {
                        AnimationAction action = Global.GetData<AnimationAction>((int)val[3], animation.Actions);
                        if (action != null)
                            return name = "Change Hero [" + (h != null ? h.Name : "No Hero") + "]'s [" + actionTypes[(int)val[1]] + "] Animation To [" + animation.Name + "] > [" + action.Name + "]";
                        else
                            return name = "Change Hero [" + (h != null ? h.Name : "No Hero") + "]'s [" + actionTypes[(int)val[1]] + "] Animation To [" + animation.Name + "] > [No Action]";
                    }
                    return name = "Change Hero [" + (h != null ? h.Name : "No Hero") + "]'s [" + actionTypes[(int)val[1]] + "] Animation To [No Animation] > [No Action]";
            }
            return "ERROR - CODE OUT OF RANGE {" + Code.ToString() + "}";
        }

        private string GetPartyName(IEvent ev, EventPageData page)
        {
            HeroData hero = null;
            string strName = "";
            string text = "";
            string text2 = "";
            if (val[0] != null)
            {
                hero = Global.GetData<HeroData>((int)val[0], GameData.Heroes);
                if (hero != null)
                    strName = hero.Name;
                else
                    strName = "No Hero";
            }
            switch (Code)
            {
                case 1: // Change Party Member
                    if ((int)val[1] == 0)
                        text = "Add";
                    else
                        text = "Remove";
                    if ((bool)val[2])
                        text2 = "[Reset]";
                    return "Change Party Member: " + text + " Hero [" + strName + "] " + text2;
                case 5: // Party Conditions

                    List<DataProperty> prop = GameData.Databases[0].Properties;

                    DataProperty property;
                    switch ((int)Value[0])
                    {
                        case 0:// Battler
                            name = "IF " + ((int)val[0] == 0 ? "Party Member " : "");
                            VariableData vari = null;
                            if ((int)val[2] == 1)
                                vari = Global.GetData<VariableData>((int)Value[3], GameData.Variables);
                            name += "[" + ((int)val[2] == 0 ? val[3].ToString() : vari != null ? vari.Name : "No Variable") + "]'s ";

                            property = Global.GetData<DataProperty>((int)val[4], prop);

                            if (property != null)
                                name += "[" + property.Name + "]";
                            else
                                name = "[No Property]";

                            name += ((int)val[1] == 0 ? "" : " Does Not");

                            name += CompareToString((int)Value[5]);

                            if ((int)Value[6] == 0)
                            {
                                name += "[" + Value[7].ToString() + "]";
                            }
                            else
                            {
                                property = Global.GetData<DataProperty>((int)val[7], prop);
                                if (property != null)
                                    name += "[" + property.Name + "]";
                                else
                                    name = "[No Property]";
                            }
                            break;
                        case 1: // has Item
                            name = "IF Party Has Item [" + ItemName((int)val[2]) + "]?";
                            break;
                        case 2: // has equip
                            name = "IF Party Has Equipment [" + EquipName((int)val[2]) + "]?";
                            break;
                        case 3: // Includes
                            name = "IF Party Includes [" + HeroName((int)val[2]) + "]";
                            break;
                        case 4: // // Party Dead
                            name = "IF Party Is Dead";
                            break;
                        case 5: // Party Member dead
                            name = "IF Party Member [" + GetValue((int)Value[2], (int)Value[3]) + "] Is Dead";
                            break;
                    }
                    return name;
                case 6: // Use Item
                    VariableData varItem = Global.GetData<VariableData>((int)val[0], GameData.Variables);
                    name = "Use Item [" + (varItem != null ? varItem.Name : "No Variable") + "] ";
                    VariableData varItemIndex = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                    name += "On Party Member [" + (varItemIndex != null ? varItemIndex.Name : "No Variable") + "] ";
                    switch ((int)val[2])
                    {
                        case 0:
                            varItem = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            name += "From Party Member [" + (varItem != null ? varItem.Name : "No Variable") + "]";
                            break;
                        case 1:
                            ListData listItem = Global.GetData<ListData>((int)val[3], GameData.Lists);
                            name += "From List [" + (listItem != null ? listItem.Name : "No List") + "]";
                            break;
                    }
                    if ((bool)val[4])
                    {
                        name += ", Remove Item";
                    }
                    break;
                case 7: // Use Skill
                    VariableData varSkill = Global.GetData<VariableData>((int)val[0], GameData.Variables);
                    name = "Use Skill [" + (varSkill != null ? varSkill.Name : "No Variable") + "] ";
                    VariableData varSkillIndex = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                    name += "On Party Member [" + (varSkillIndex != null ? varSkillIndex.Name : "No Variable") + "] ";
                    varSkill = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                    name += "From Party Member [" + (varSkill != null ? varSkill.Name : "No Variable") + "]";
                    if ((bool)val[3])
                    {
                        name += ", Apply Skill Cost";
                    }
                    break;
                case 8: // Change Equipment
                    VariableData varEquip = Global.GetData<VariableData>((int)val[0], GameData.Variables);
                    name = "Change Equipment Party Member [" + (varEquip != null ? varEquip.Name : "No Variable") + "] Equipment ";
                    varEquip = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                    name += "[" + (varEquip != null ? varEquip.Name : "No Variable") + "] Slot ";
                    varEquip = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                    name += "[" + (varEquip != null ? varEquip.Name : "No Variable") + "]";

                    if ((bool)val[3])
                    {
                        name += ", Add/Remove Equipment";
                    }
                    break;
                case 9: // Change Item
                    name = "Change Items ";

                    VariableData item = Global.GetData<VariableData>((int)val[1], GameData.Variables);

                    name += (item != null ? "[" + item.Name + "]" : "[No Variable]");

                    item = Global.GetData<VariableData>((int)val[0], GameData.Variables);

                    if (item != null)
                        name += " Party Index [" + item.Name + "]";
                    else
                        name += " Party Index [No Variable]";


                    name += ((int)val[2] == 0 ? " Increase" : " Decrease");

                    if ((int)val[3] == 0)
                        name += " [" + val[4].ToString() + "]";
                    else
                    {
                        item = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                        name += (item != null ? " [" + item.Name + "]" : " [No Variable]");
                    }
                    break;
                case 10: // Change Equipments
                    name = "Change Equipments ";

                    VariableData equip = Global.GetData<VariableData>((int)val[1], GameData.Variables);

                    name += (equip != null ? "[" + equip.Name + "]" : "[No Variable]");

                    equip = Global.GetData<VariableData>((int)val[0], GameData.Variables);

                    if (equip != null)
                        name += " Party Index [" + equip.Name + "]";
                    else
                        name += " Party Index [No Variable]";


                    name += ((int)val[2] == 0 ? " Increase" : " Decrease");

                    if ((int)val[3] == 0)
                        name += " [" + val[4].ToString() + "]";
                    else
                    {
                        equip = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                        name += (equip != null ? " [" + equip.Name + "]" : " [No Variable]");
                    }
                    break;
                case 12: // Insert Party Member from a list
                    name = "Inster Party Member From [" + GetList((int)val[0]) + "] at Index [" + GetValue(1, (int)val[1]) + "]";
                    break;
                case 13: // Remove Party Member and add to a list
                    name = "Remove Party Member At Index [" + GetValue(1, (int)val[0]) + "]";
                    if ((bool)val[1])
                        name += " AND Add To [" + GetList((int)val[2]) + "]";
                    break;
            }
            return name;
        }

        private string HeroName(int p)
        {
            HeroData hero = Global.GetData<HeroData>(p, GameData.Heroes);
            if (hero != null) return hero.Name;
            return "No Hero";
        }

        private string GetSettingsName(IEvent ev, EventPageData page)
        {
            VariableData variable;
            switch (code)
            {
                case 6:
                    #region Move Frequency
                    name = "Set Frequency [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 7:
                    #region Move Speed
                    name = "Set Move Speed [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 8:
                    #region Set Force
                    name = "Set Force [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 10:
                    #region Linear Drag
                    name = "Set Linear Drag [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 11:
                    #region Rotational Drag
                    name = "Set Rotational Drag [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 12:
                    #region Friction
                    name = "Set Friction [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 13:
                    #region Bounce
                    name = "Set Bounce [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 14:
                    #region Mass
                    name = "Set Mass [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 15:
                    #region Impulse
                    name = "Set Impulse [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 4:
                    name = "";
                    AnimationData animation = Global.GetData<AnimationData>((int)val[0], GameData.Animations);
                    if (animation != null)
                    {
                        AnimationAction action = Global.GetData<AnimationAction>((int)val[1], animation.Actions);
                        if (action != null)
                            return name = "Change Animation To [" + animation.Name + "] - [" + action.Name + "]";
                        else
                            return name = "Change Animation To [" + animation.Name + "] - [No Action]";
                    }
                    return name = "Change Animation To [No Animation] - [No Action]";
            }
            return name;
        }

        private string GetDisplayName(IEvent ev, EventPageData page)
        {
            string position = "";
            switch (Code)
            {
                case 1: // Show Message
                    return "Show Message";
                case 2: // Show Menu
                    MenuData menu = Global.GetData<MenuData>((int)val[0], GameData.Menus);

                    if (menu != null)
                    {
                        // Set Action Name
                        name = "Show Menu: [" + menu.Name + "]";
                        if ((bool)Value[1])
                            name += ", Show on scene";
                        if (Value[5] != null && (bool)Value[5])
                            name += ", Heads-up display";
                        if ((bool)Value[2])
                            name += ", Deactivate scene";
                        if ((bool)Value[3])
                            name += ", Wait until scene closes";
                        if ((bool)Value[4])
                            name += ", Exit Scene";
                        return name;
                    }
                    return name = "Show Menu: [No Menu]";
                case 3: // Show Picture
                    MaterialData material = Global.GetData<MaterialData>((int)val[1], GameData.Materials);

                    if (material != null)
                    {
                        switch ((int)Value[5])
                        {
                            case 0: // Coordinate
                                position = "X: " + Value[6].ToString() + " Y: " + Value[7].ToString();
                                break;
                            case 1:// Varaibles
                                VariableData varX = Global.GetData<VariableData>((int)val[6], GameData.Variables);
                                VariableData varY = Global.GetData<VariableData>((int)val[7], GameData.Variables);
                                if (varX != null && varY != null)
                                {
                                    position = "X: [" + varX.Name + "] Y: [" + varY.Name + "]";
                                }
                                else
                                    position = "X: [No Variable] Y: [No Variable]";
                                break;
                            case 2: // Center
                                position = "[Center]";
                                break;
                        }
                        return name = "Show Picture [" + Value[0].ToString() + "]: Layer [" + Value[9].ToString() + "] Material: [" + material.Name + "] ON " + position + "";
                    }
                    return "Show Picture: [No Material]";
                case 4: // Clear Picture   
                    return name;
                case 5: // Show Animation
                    switch ((int)Value[3])
                    {
                        case 0: // Coordinates
                            position = "X: " + Value[4].ToString() + " Y: " + Value[5].ToString();
                            break;
                        case 1:// Varaibles
                            VariableData varX = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                            VariableData varY = Global.GetData<VariableData>((int)val[5], GameData.Variables);
                            if (varX != null && varY != null)
                            {
                                position = "X: [" + varX.Name + "] Y: [" + varY.Name + "]";
                            }
                            else
                                position = "X: [No Variable] Y: [No Variable]";
                            break;
                        case 2: // Events
                            position = "Event: [" + GetEvent((int)val[4]) + "]";
                            break;
                    }

                    AnimationData animation = Global.GetData<AnimationData>((int)val[0], GameData.Animations);
                    if (animation != null)
                    {
                        AnimationAction action = Global.GetData<AnimationAction>((int)val[1], animation.Actions);
                        if (action != null)
                            return name = "Show Animation: [" + animation.Name + "] > [" + action.Name + "] > [" + GetDirection((int)val[2]) + "] ON " + position;
                        else
                            return name = "Show Animation: [" + animation.Name + "] > [No Action] > [" + GetDirection((int)val[2]) + "] ON " + position;
                    }
                    return name = "Show Animation: [No Animation] > [No Action] > [" + GetDirection((int)val[2]) + "] ON " + position;
                case 6: // Show Video
                    MaterialData vidMat = Global.GetData<MaterialData>((int)val[0], GameData.Materials);
                    string vidname = "No Material";
                    if (vidMat != null)
                    {
                        vidname = vidMat.Name;
                    }
                    string positionVid = "";
                    switch ((int)val[4])
                    {
                        case 0: // Coordinate
                            positionVid = "X: " + val[5].ToString() + " Y: " + val[6].ToString();
                            break;
                        case 1:// Varaibles
                            VariableData varVidX = Global.GetData<VariableData>((int)val[5], GameData.Variables);
                            VariableData varVidY = Global.GetData<VariableData>((int)val[6], GameData.Variables);
                            if (varVidX != null)
                                position = "X: [" + varVidX.Name + "]";
                            else
                                position = "X: [No Variable]";
                            if (varVidY != null)
                                position += " Y: [" + varVidY.Name + "]";
                            else
                                position += " Y: [No Variable]";
                            break;
                    }
                    name = "Show Video: Material: [" + vidname + "] ON " + positionVid;
                    return name;
                case 7: // Control Video
                    return name;
                case 8: // Move Picture
                    switch ((int)Value[4])
                    {
                        case 0: // Coordinate
                            position = "X: " + Value[5].ToString() + " Y: " + Value[6].ToString();
                            break;
                        case 1:// Varaibles
                            VariableData varX = Global.GetData<VariableData>((int)val[5], GameData.Variables);
                            VariableData varY = Global.GetData<VariableData>((int)val[6], GameData.Variables);
                            if (varX != null)
                                position = "X: [" + varX.Name + "]";
                            else
                                position = "X: [No Variable]";
                            if (varY != null)
                                position += " Y: [" + varY.Name + "]";
                            else
                                position += " Y: [No Variable]";
                            break;
                        case 2: // Center
                            position = "[Center]";
                            break;
                    }
                    return name = "Move Picture: [" + Value[0].ToString() + "] ON " + position + "";
                case 9: // Tint Picture
                    return name;
                case 10: // Change Cursor
                    MaterialData cursorMat = Global.GetData<MaterialData>((int)val[0], GameData.Materials);
                    string cursorName = "No Material";
                    if (cursorMat != null)
                    {
                        cursorName = cursorMat.Name;
                    }
                    return name = "Change Cursor To: [" + cursorName + "]";
                case 11: // Show Particle
                    ParticleSystemData particle = Global.GetData<ParticleSystemData>((int)val[1], GameData.ParticleSystems);

                    if (particle != null)
                    {
                        switch ((int)Value[2])
                        {
                            case 0: // Coordinate
                                position = "X: " + Value[3].ToString() + " Y: " + Value[4].ToString();
                                break;
                            case 1:// Varaibles
                                VariableData varX = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                                VariableData varY = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                if (varX != null && varY != null)
                                {
                                    position = "X: [" + varX.Name + "] Y: [" + varY.Name + "]";
                                }
                                else
                                    position = "X: [No Variable] Y: [No Variable]";
                                break;
                            case 2: // Event
                                position = "Event: [" + GetEvent((int)val[3]) + "]";
                                break;
                        }
                        return name = "Show Particle: [" + Value[0].ToString() + "] System: [" + particle.Name + "] ON " + position + "";
                    }
                    return "Show Particle: [No System]";
                case 12: // Move Particle
                    switch ((int)Value[2])
                    {
                        case 0: // Coordinate
                            position = "X: " + Value[3].ToString() + " Y: " + Value[4].ToString();
                            break;
                        case 1:// Varaibles
                            VariableData varX = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            VariableData varY = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                            if (varX != null)
                                position = "X: [" + varX.Name + "]";
                            else
                                position = "X: [No Variable]";
                            if (varY != null)
                                position += " Y: [" + varY.Name + "]";
                            else
                                position += " Y: [No Variable]";
                            break;
                    }
                    return name = "Move Particle: [" + Value[0].ToString() + "] ON " + position + "";

                case 13: // Clear Particle   
                    return name;
                case 14:
                    name = "Set Options";
                    return name;
                case 15:
                    MenuData shop = Global.GetData<MenuData>((int)val[0], GameData.Menus);
                    name = "Show Shop: [" + (shop != null ? shop.Name : "No Menu") + "]";
                    return name;
                case 17: // Close Menu
                    MenuData menu1 = Global.GetData<MenuData>((int)val[0], GameData.Menus);

                    if (menu1 != null)
                    {
                        return "Close Menu [" + menu1.Name + "]";
                    }
                    return name = "Close Menu [No Menu]";
                case 18: // Scale Picture
                    switch ((int)Value[1])
                    {
                        case 0: // Coordinate
                            position = "X: " + Value[2].ToString() + " Y: " + Value[3].ToString();
                            break;
                        case 1:// Varaibles
                            VariableData varX = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            VariableData varY = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            if (varX != null)
                                position = "X: [" + varX.Name + "]";
                            else
                                position = "X: [No Variable]";
                            if (varY != null)
                                position += " Y: [" + varY.Name + "]";
                            else
                                position += " Y: [No Variable]";
                            break;
                    }
                    return name = "Scale Picture: [" + Value[0].ToString() + "] ON " + position + "";
                case 19: // Rotate Picture
                    switch ((int)Value[1])
                    {
                        case 0: // Coordinate
                            position = "" + Value[2].ToString() + " Degrees ";
                            break;
                        case 1:// Varaibles
                            VariableData varX = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            if (varX != null)
                                position = "[" + varX.Name + "] Degrees ";
                            else
                                position = "[No Variable] Degrees ";
                            break;
                    }
                    position = "Centered [" + Value[3].ToString() + "]";
                    return name = "Rotate Picture: [" + Value[0].ToString() + "] TO " + position + "";
            }
            return name;
        }

        private string GetConditionsName(IEvent ev, EventPageData page)
        {
            string type = "";
            string op = "";
            string typeOp = "";
            switch (Code)
            {
                case 1: // Switch
                    #region Switch
                    // Set Data
                    SwitchData cSwitch;
                    if ((int)val[4] == 0)
                    {
                        cSwitch = Global.GetData<SwitchData>((int)val[0], GameData.Switches);
                    }
                    else
                    {
                        cSwitch = Global.GetData<SwitchData>((int)val[0], ev.Switches);
                    }
                    typeOp = "";
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            if ((bool)val[3])
                                typeOp = "On";
                            else
                                typeOp = "Off";
                            break;
                        case 1: // Rand
                            SwitchData switche = Global.GetData<SwitchData>((int)val[3], GameData.Switches);
                            if (switche != null)
                                typeOp = "Switch [" + switche.Name + "]";
                            else
                                typeOp = "Switch [No Switch]";
                            break;
                        case 2:
                            SwitchData localSwitch = Global.GetData<SwitchData>((int)val[3], ev.Switches);
                            if (localSwitch != null)
                                typeOp = "Local Switch [" + localSwitch.Name + "]";
                            else
                                typeOp = "Local Switch [No Switch]";
                            break;
                    }
                    op = "";
                    switch ((int)Value[1])
                    {
                        case 0:
                            op = "(=) Equals";
                            break;
                        case 1:
                            op = "(!=) Does Not Equal";
                            break;
                    }
                    type = "IF Switch [";
                    if ((int)val[4] == 1)
                        type = "IF Local Switch [";
                    if (cSwitch != null)
                    {
                        Name = type + cSwitch.Name + "] " + op + " " + typeOp;
                    }
                    else
                    {
                        name = type + "No Switch" + "] " + op + " " + typeOp;
                    }
                    #endregion
                    return name;
                case 2: // Variable
                    #region Variable
                    VariableData cVariable;
                    if ((int)val[6] == 0)
                    {
                        cVariable = Global.GetData<VariableData>((int)val[0], GameData.Variables);
                    }
                    else
                    {
                        cVariable = Global.GetData<VariableData>((int)val[0], ev.Variables);
                    }
                    // Set Data
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            typeOp = Value[3].ToString();
                            break;
                        case 1: // Rand
                            typeOp = "Random Number Between [" + Value[3].ToString() + "] AND [" + Value[4].ToString() + "]";
                            break;
                        case 2:
                            VariableData varA = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            if (varA != null)
                                typeOp = "Variable [" + varA.Name + "]";
                            else
                                typeOp = "Variable [No Variable]";
                            break;
                        case 3:
                            VariableData varB = Global.GetData<VariableData>((int)val[3], ev.Variables);
                            if (varB != null)
                                typeOp = "Local Variable [" + varB.Name + "]";
                            else
                                typeOp = "Local Variable [No Variable]";
                            break;
                        case 4: // Event
                            if ((int)val[4] == 0)
                                typeOp = "[" + GetEvent((int)val[3]) + "'s Position X" + "]";
                            else
                                typeOp = "[" + GetEvent((int)val[3]) + "'s Position Y" + "]";
                            break;
                        case 5: // Datas
                            Data databaseA = Global.GetData<Data>((int)val[3], GameData.Databases);
                            if (databaseA != null)
                            {
                                Data dataA = Global.GetData<Data>((int)val[4], databaseA.Datas);
                                if (dataA != null)
                                {
                                    DataProperty propA = Global.GetData<DataProperty>((int)val[5], dataA.Properties);
                                    if (propA != null)
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                    else
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                }
                                else
                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                            }
                            else
                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                            break;
                        case 6: // Other
                            switch ((int)val[3])
                            {
                                case 0: // Map ID
                                    typeOp = "[Current Map ID]";
                                    break;
                            }
                            break;
                    }

                    switch ((int)Value[1])
                    {
                        case 0:
                            op = "(=) Equals";
                            break;
                        case 1:
                            op = "(>) Greater Than";
                            break;
                        case 2:
                            op = "(<) Less Than";
                            break;
                        case 3:
                            op = "(>=) Greater Than Or Equals";
                            break;
                        case 4:
                            op = "(<=) Less Than Or Equals";
                            break;
                        case 5:
                            op = "(!=) Does Not Equal";
                            break;
                    }
                    type = "IF Variable [";
                    if ((int)Value[6] == 1)
                        type = "IF Local Variable [";
                    if (cVariable != null)
                        Name = type + cVariable.Name + "] " + op + " " + typeOp;
                    else
                        Name = type + "No Variable" + "] " + op + " " + typeOp;
                    return name;
                    #endregion
                case 3: // List
                    #region List
                    ListData cList = Global.GetData<ListData>((int)val[0], GameData.Lists);
                    // Set Data
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            typeOp = Value[3].ToString();
                            break;
                        case 1: // Rand
                            typeOp = "Random Number Between [" + Value[3].ToString() + "] AND [" + Value[4].ToString() + "]";
                            break;
                        case 2:
                            VariableData varA = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            if (varA != null)
                                typeOp = "Variable [" + varA.Name + "]";
                            else
                                typeOp = "Variable [No Variable]";
                            break;
                        case 3:
                            VariableData varB = Global.GetData<VariableData>((int)val[3], ev.Variables);
                            if (varB != null)
                                typeOp = "Local Variable [" + varB.Name + "]";
                            else
                                typeOp = "Local Variable [No Variable]";
                            break;
                        case 4: // Event
                            if ((int)val[4] == 0)
                                typeOp = "[" + GetEvent((int)val[3]) + "'s Position X" + "]";
                            else
                                typeOp = "[" + GetEvent((int)val[3]) + "'s Position Y" + "]";
                            break;
                        case 5: // Datas
                            Data databaseA = Global.GetData<Data>((int)val[3], GameData.Databases);
                            if (databaseA != null)
                            {
                                Data dataA = Global.GetData<Data>((int)val[4], databaseA.Datas);
                                if (dataA != null)
                                {
                                    DataProperty propA = Global.GetData<DataProperty>((int)val[5], dataA.Properties);
                                    if (propA != null)
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                    else
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                }
                                else
                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                            }
                            else
                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                            break;
                        case 6: // Other
                            switch ((int)val[3])
                            {
                                case 0: // Map ID
                                    typeOp = "[Current Map ID]";
                                    break;
                                case 1: // has Item
                                    name += " Item [" + ItemName((int)val[4]) + "]?";
                                    break;
                                case 2: // has equip
                                    name += " Equipment [" + EquipName((int)val[4]) + "]?";
                                    break;
                                case 3: // has skill/magic
                                    name += " Skill/Magic [" + SkillName((int)val[4]) + "]?";
                                    break;
                            }
                            break;
                    }
                    switch ((int)val[1])
                    {
                        case 0: // Add
                            op = "Contains"; break;
                        case 1: // Remove
                            op = "Does Not Contain"; break;
                    }
                    if (cList != null)
                        Name = "IF List [" + cList.Name + "] " + op + " [" + typeOp + "]";
                    else
                        name = "IF List [No List]" + " " + op + " [" + typeOp + "]";
                    return name;
                    #endregion
                case 4: // Database;
                    #region Database
                    Data cDatabase = Global.GetData<Data>((int)val[0], GameData.Databases);
                    Data cData;
                    DataProperty cProp;
                    if (cDatabase != null)
                    {
                        cData = Global.GetData<Data>((int)val[1], cDatabase.Datas);
                        if (cData != null)
                        {
                            cProp = Global.GetData<DataProperty>((int)val[2], cData.Properties);
                            if (cProp != null)
                            {
                                if (cProp.ValueType == DataType.Number)
                                {

                                    switch ((int)Value[4])
                                    {
                                        case 0: // Constant
                                            typeOp = Value[5].ToString();
                                            break;
                                        case 1: // Rand
                                            typeOp = "Random Number Between [" + Value[5].ToString() + "] AND [" + Value[6].ToString() + "]";
                                            break;
                                        case 2:
                                            VariableData varA = Global.GetData<VariableData>((int)val[5], GameData.Variables);
                                            if (varA != null)
                                                typeOp = "Variable [" + varA.Name + "]";
                                            else
                                                typeOp = "Variable [No Variable]";
                                            break;
                                        case 3:
                                            VariableData varB = Global.GetData<VariableData>((int)val[5], ev.Variables);
                                            if (varB != null)
                                                typeOp = "Local Variable [" + varB.Name + "]";
                                            else
                                                typeOp = "Local Variable [No Variable]";
                                            break;
                                        case 4: // Event
                                            if ((int)val[6] == 0)
                                                typeOp = "[" + GetEvent((int)val[5]) + "'s Position X" + "]";
                                            else
                                                typeOp = "[" + GetEvent((int)val[5]) + "'s Position Y" + "]";
                                            break;
                                        case 5: // Datas
                                            Data databaseA = Global.GetData<Data>((int)val[5], GameData.Databases);
                                            if (databaseA != null)
                                            {
                                                Data dataA = Global.GetData<Data>((int)val[6], databaseA.Datas);
                                                if (dataA != null)
                                                {
                                                    DataProperty propA = Global.GetData<DataProperty>((int)val[7], dataA.Properties);
                                                    if (propA != null)
                                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                                    else
                                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                                }
                                                else
                                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                                            }
                                            else
                                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                                            break;
                                        case 6: // Other
                                            switch ((int)val[5])
                                            {
                                                case 0: // Map ID
                                                    typeOp = "[Current Map ID]";
                                                    break;
                                            }
                                            break;
                                    }

                                    switch ((int)Value[3])
                                    {
                                        case 0:
                                            op = "(=) Equals";
                                            break;
                                        case 1:
                                            op = "(>) Greater Than";
                                            break;
                                        case 2:
                                            op = "(<) Less Than";
                                            break;
                                        case 3:
                                            op = "(>=) Greater Than Or Equals";
                                            break;
                                        case 4:
                                            op = "(<=) Less Than Or Equals";
                                            break;
                                        case 5:
                                            op = "(!=) Does Not Equal";
                                            break;
                                    }
                                    name = "IF Database [" + cDatabase.Name + "] > [" + cData.Name + "] > [" + cProp.Name + "] " +
                                        op + " " + typeOp;

                                }
                                else if (cProp.ValueType == DataType.Text)
                                {
                                    // Text
                                    switch ((int)val[4])
                                    {
                                        case 0:
                                            op = " (=) Equals "; break;
                                        case 1:
                                            op = " (!=) Does Not Equal "; break;
                                    }

                                    name = "IF Database [" + cDatabase.Name + "] > [" + cData.Name + "] > [" + cProp.Name + "]" +
                                        op + val[3].ToString();
                                }
                            }
                            else
                            {
                                name = "IF Database [" + cDatabase.Name + "] > [" + cData.Name + "] > [No Property]";
                            }
                        }
                        else
                        {
                            name = "IF Database [" + cDatabase.Name + "] > [No Data] > [No Property]";
                        }
                    }
                    else
                    {
                        name = "IF Database [No Database] > [No Data] > [No Property]";
                    }
                    #endregion
                    return name;
                case 5: // Button Input
                    return name;
                case 6: // Mouse Input
                    return name;
                case 7: // Event
                    // Set Data
                    #region Event

                    name = "IF Event [" + GetEvent((int)val[0]) + "] ";

                    string comapareType = ((int)val[6] == 0 ? "Is " : "Not ");
                    name += comapareType;

                    if ((int)val[1] == 0)
                    {
                        string active = "";
                        switch ((int)Value[2])
                        {
                            case 0:
                                active = "Activated";
                                break;
                            case 1:
                                active = "Deactivated";
                                break;
                            case 2:
                                active = "Moving";
                                break;
                            case 3:
                                active = "Jumping";
                                break;
                            case 4:
                                active = "Idle";
                                break;
                            case 5:
                                active = "Colliding";
                                break;
                        }
                        Name += active;
                    }
                    else if ((int)val[1] == 1)
                    {

                        Name += "facing " + GetDirection((int)val[2]);
                    }
                    else if ((int)val[1] == 2)
                    {
                        name += "in direction of [" + GetEvent((int)val[2]) + "]";
                    }
                    else if ((int)val[1] == 3)
                    {
                        name += "facing [" + GetEvent((int)val[2]) + "]";
                    }
                    else if ((int)val[1] == 4)
                    {
                        Name += "In range of [" + GetEvent((int)val[2]) + "]  Range: [" + val[3].ToString() + "] ";
                    }
                    else if ((int)val[1] == 5)
                    {
                        Name += "Position " + CompareToString((int)val[5]) + " [" + Value[2].ToString() + ", " + Value[3].ToString() + "] ";
                    }
                    else if ((int)val[1] == 6)
                    {
                        Name += "on Tag [" + Value[2].ToString() + "]";
                    }
                    else if ((int)val[1] == 7)
                    {
                        Name += "Angle is between [" + val[2].ToString() + "]~[" + val[3].ToString() + "]";
                    }
                    else if ((int)val[1] == 8)
                    {
                        Name += ((int)val[2] == 0 ? "Force" : (int)val[2] == 1 ? "Impulse" : "Velocity") + " " + CompareToString((int)val[5]) + " [" + val[3].ToString() + ", " + val[4].ToString() + "]";
                    }
                    else if ((int)val[1] == 9)
                    {
                        Name += ((int)val[2] == 0 ? "Torque" : "Angular Velocity") + " " + CompareToString((int)val[4]) + " [" + val[3].ToString() + "]";
                    }
                    else if ((int)val[1] == 10)
                    {
                        Name += "At an angle on [" + GetEvent((int)val[2]) + "] Angle [" + val[3].ToString() + "] ~ [" + val[4].ToString() + "]";
                    }
                    else if ((int)val[1] == 11)
                    {
                        Name += "Is Colliding with [" + GetEvent((int)val[2]) + "]";
                    }
                    else if ((int)val[1] == 12)
                    {
                        Name += "Is Colliding with Projectile [" + GetProjectile((int)val[2]) + "]";
                    }
                    #endregion
                    return name;
                case 8: // Timer
                    #region Timer
                    VariableData timerVar = Global.GetData<VariableData>((int)val[1], GameData.Variables);

                    switch ((int)val[0])
                    {
                        case 0:
                            op = " (=) Equals "; break;
                        case 1:
                            op = " (>) Greater Than "; break;
                        case 2:
                            op = " (<) Less Than "; break;
                        case 3:
                            op = " (>=) Greater Than Or Equals "; break;
                        case 4:
                            op = " (<=) Less Than Or Equals "; break;
                        case 5:
                            op = " (!=) Does Not Equal "; break;
                    }
                    if (timerVar != null)
                        name = "IF Timer [Variable: " + timerVar.Name + "]" + op + " [" + Value[2].ToString() + ":" + Value[3].ToString() + ":" + Value[4].ToString() + "]";
                    else
                        name = "IF Timer [Variable: No Variable]" + op + " [" + Value[2].ToString() + ":" + Value[3].ToString() + ":" + Value[4].ToString() + "]";
                    return name;
                    #endregion
                case 9: // String
                    #region String
                    StringData cString = Global.GetData<StringData>((int)val[0], GameData.Strings);
                    // Set Data
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            typeOp = Value[3].ToString();
                            break;
                        case 1:
                            StringData varA = Global.GetData<StringData>((int)val[3], GameData.Strings);
                            if (varA != null)
                                typeOp = "String [" + varA.Name + "]";
                            else
                                typeOp = "String [No String]";
                            break;
                        case 2: // Datas
                            Data databaseA = Global.GetData<Data>((int)val[3], GameData.Databases);
                            if (databaseA != null)
                            {
                                Data dataA = Global.GetData<Data>((int)val[4], databaseA.Datas);
                                if (dataA != null)
                                {
                                    DataProperty propA = Global.GetData<DataProperty>((int)val[5], dataA.Properties);
                                    if (propA != null)
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                    else
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                }
                                else
                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                            }
                            else
                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                            break;
                    }

                    switch ((int)Value[1])
                    {
                        case 0:
                            op = "(=) Equals";
                            break;
                        case 1:
                            op = "(!=) Does Not Equal";
                            break;
                    }
                    type = "IF String [";
                    if (cString != null)
                        Name = type + cString.Name + "] " + op + " " + typeOp;
                    else
                        Name = type + "No String" + "] " + op + " " + typeOp;
                    return name;
                    #endregion
                case 10: // Other
                    #region Other
                    switch ((int)Value[0])
                    {
                        case 0: // Tile
                            name = "IF Tile At ";
                            switch ((int)Value[2])
                            {
                                case 0: // Const
                                    name += "[" + Value[3].ToString() + ", " + Value[4].ToString() + "] ";
                                    break;
                                case 1: // Variable
                                    VariableData vx1 = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                                    VariableData vx2 = Global.GetData<VariableData>((int)val[4], GameData.Variables);

                                    name += "[" + (vx1 != null ? vx1.Name : "No Variable") + ", " + (vx2 != null ? vx2.Name : "No Variable") + "] ";
                                    break;
                            }
                            switch ((int)Value[5])
                            {
                                case 0: // Tag
                                    name += ((int)val[1] == 0 ? "Tag is " + Value[6].ToString() : "Tag is not " + Value[6].ToString());
                                    break;
                                case 1: // Colision
                                    name += ((int)val[1] == 0 ? "Has Collision" : "Has No Collision");
                                    break;
                            }
                            break;
                        case 1: // Platform
                            name = "IF Platform IS " + ((int)val[1] == 0 ? "" : "NOT") + ((int)val[2] == 0 ? "Windows" : (int)val[2] == 1 ? "Xbox" : "SilverLight");
                            break;
                        case 2: // Save/Load Exists
                            name = "IF Save/Load [" + GetValue((int)val[2], (int)val[3]) + "]" + ((int)val[1] == 0 ? "" : " NOT") + " Exists";
                            break;
                    }
                    return name;
                    #endregion
                case 11: // Item/Skill
                    #region Item/Skill
                    switch ((int)Value[0])
                    {
                        case 0: // Item
                            VariableData varItem = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            name = "IF Item [" + (varItem == null ? "No Variable" : varItem.Name) + "]";

                            switch ((int)val[3])
                            {
                                case 0: // Scope
                                    string[] scope = new string[]{"User",
                                                                "One Ally",
                                                                "All Party",
                                                                "One Enemy",
                                                                "All Enemies",
                                                                "One Ally (Dead)",
                                                                "All Party (Dead)",
                                                                "None"};
                                    name += ((int)val[1] == 0 ? "'s Scope is [" + scope[(int)val[4]] + "]" : "'s Scope is not [" + scope[(int)val[4]] + "]");
                                    break;
                                case 1:
                                    varItem = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    name += " Can be used on Party Member [" + (varItem == null ? "No Variable" : varItem.Name) + "]";
                                    break;
                                case 2:
                                    name += " Can be used on Party";
                                    break;
                                case 3:
                                    varItem = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    name += " Can be Bought [" + (varItem == null ? "No Variable" : varItem.Name) + "]";
                                    break;
                                case 4:
                                    name += " Can be Sold";
                                    break;
                                case 5:
                                    name += " Can be used by Party Member [" + GetValue(1, (int)val[4]) + "]";
                                    break;
                            }
                            break;
                        case 1: // Skill
                            VariableData varSkill = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            name = "IF Skill [" + (varSkill == null ? "No Variable" : varSkill.Name) + "]";

                            switch ((int)val[3])
                            {
                                case 0: // Scope
                                    string[] scope = new string[]{"User",
                                                                "One Ally",
                                                                "All Party",
                                                                "One Enemy",
                                                                "All Enemies",
                                                                "One Ally (Dead)",
                                                                "All Party (Dead)",
                                                                "None"};
                                    name += ((int)val[1] == 0 ? "'s Scope is [" + scope[(int)val[4]] + "]" : "'s Scope is not [" + scope[(int)val[4]] + "]");
                                    break;
                                case 1:
                                    varSkill = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    name += " Can be used on Party Member [" + (varSkill == null ? "No Variable" : varSkill.Name) + "]";
                                    break;
                                case 2:
                                    name += " Can be used on Party";
                                    break;
                                case 3:
                                    varSkill = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    name += " Can be used by Party Member [" + (varSkill == null ? "No Variable" : varSkill.Name) + "]";
                                    break;
                            }
                            break;
                        case 2: // Equipment
                            VariableData varEquipment = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            name = "IF Equipment [" + (varEquipment == null ? "No Variable" : varEquipment.Name) + "]";

                            switch ((int)val[3])
                            {
                                case 0: // Scope
                                    varEquipment = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    name += " Can be equipped by Party Member [" + (varEquipment == null ? "No Variable" : varEquipment.Name) + "]";
                                    break;
                                case 1:
                                    name += " Is Offensive";
                                    break;
                                case 2:
                                    varEquipment = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    name += " Can be Bought [" + (varEquipment == null ? "No Variable" : varEquipment.Name) + "]";
                                    break;
                                case 3:
                                    name += " Can be Sold";
                                    break;

                            }
                            break;
                    }
                    return name;
                    #endregion
                case 12: // Hero Condtions
                    #region Hero Conditions
                    HeroData hero = Global.GetData<HeroData>((int)val[0], GameData.Heroes);
                    name = "IF Hero [" + (hero != null ? hero.Name : "No Hero") + "]";

                    switch ((int)val[1])
                    {
                        case 0: // has Item
                            name += " Has Item [" + ItemName((int)val[2]) + "]?";
                            break;
                        case 1: // has equip
                            name += " Has Equipment [" + EquipName((int)val[2]) + "]?";
                            break;
                        case 2: // has skill/magic
                            name += " Has Skill/Magic [" + SkillName((int)val[2]) + "]?";
                            break;
                    }
                    return name;
                    #endregion
            }
            return "ERROR - CODE OUT OF RANGE {" + Code.ToString() + "}";
        }

        string ItemName(int id)
        {
            ItemData item = Global.GetData<ItemData>(id, GameData.Items);
            if (item != null) return item.Name;
            return "No Item";
        }
        string SkillName(int id)
        {
            SkillData Skill = Global.GetData<SkillData>(id, GameData.Skills);
            if (Skill != null) return Skill.Name;
            return "No Skill";
        }
        string EquipName(int id)
        {
            EquipmentData item = Global.GetData<EquipmentData>(id, GameData.Equipments);
            if (item != null) return item.Name;
            return "No Equipment";
        }
        private string GetValue(int type, int value)
        {
            switch (type)
            {
                case 0:
                    return value.ToString();
                case 1:
                    VariableData var = Global.GetData<VariableData>(value, GameData.Variables);
                    if (var != null)
                        return var.Name;
                    else
                        return "No Variable";
            }
            return "NONE";
        }

        private string GetList(int value)
        {
            ListData var = Global.GetData<ListData>(value, GameData.Lists);
            if (var != null)
                return var.Name;
            else
                return "No List";
        }

        string Keyboard(int index)
        {
            if (index == -1) return "";
            string[] keys = new string[] {
            "Up",
"Down",
"Left",
"Right",
"Back",
"Tab",
"Enter",
"Escape",
"Space",
"PageUp",
"PageDown",
"End",
"Home",
"PrintScreen",
"Insert",
"Delete",
"0",
"1",
"2",
"3",
"4",
"5",
"6",
"7",
"8",
"9",
"A",
"B",
"C",
"D",
"E",
"F",
"G",
"H",
"I",
"J",
"K",
"L",
"M",
"N",
"O",
"P",
"Q",
"R",
"S",
"T",
"U",
"V",
"W",
"X",
"Y",
"Z",
"NumPad0",
"NumPad1",
"NumPad2",
"NumPad3",
"NumPad4",
"NumPad5",
"NumPad6",
"NumPad7",
"NumPad8",
"NumPad9",
"Multiply",
"Add",
"Separator",
"Subtract",
"Decimal",
"Divide",
"F1",
"F2",
"F3",
"F4",
"F5",
"F6",
"F7",
"F8",
"F9",
"F10",
"F11",
"F12",
"F13",
"F14",
"F15",
"F16",
"F17",
"F18",
"F19",
"F20",
"F21",
"F22",
"F23",
"F24",
"NumLock",
"Scroll",
"LeftShift",
"RightShift",
"LeftControl",
"RightControl",
"LeftAlt",
"RightAlt",
"Semicolon",
"Plus",
"Comma",
"Minus",
"Period",
"Question",
"Tilde",
"OpenBrackets",
"OemPipe",
"CloseBrackets",
"Quotes",
"Backslash"            };

            return keys[index];
        }

        string Button(int index)
        {
            if (index == -1) return "";

            string[] buttons = new string[]
            {"Left Stick","Right Stick","Up","Down","Left","Right","X","A",
             "B","Y","Left Trigger","Right Trigger","Left Bumper","Right Bumper","Back","Start"
            };

            return buttons[index];
        }

        private string CompareToString(int p)
        {
            switch (p)
            {
                case 0:
                    return " (=) Equals ";
                case 1:
                    return " (>) Greater Than ";
                case 2:
                    return " (<) Less Than ";
                case 3:
                    return " (>=) Greater Than Or Equals ";
                case 4:
                    return " (<=) Less Than Or Equals ";
                case 5:
                    return " (!=) Does Not Equal ";
            }
            return "Operation Out Of Index";
        }

        private string GetAudioName(IEvent ev, EventPageData page)
        {
            AudioData audio;
            switch (Code)
            {
                case 1: // Play Audio
                    audio = Global.GetData<AudioData>((int)val[0], GameData.Audios);
                    if (audio != null)
                        name = "Play Audio [" + audio.Name + "] Channel [" + val[1].ToString() + "]";
                    else
                        name = "Play Audio [No Audio] Channel [" + val[1].ToString() + "]";
                    break;
                case 2: // Control Audio Channel
                    return name;
                case 3: // Create PlayList
                    return name;
                case 4: // Control PlayList
                    return name;
                case 5: // Playe 3D Audio
                    // EventData emitter = Global.GetData<EventData>((int)val[6], Global.GetMapEventList(MainForm.SelectedMap));
                    //EventData listener = Global.GetData<EventData>((int)val[7], Global.GetMapEventList(MainForm.SelectedMap));

                    audio = Global.GetData<AudioData>((int)val[0], GameData.Audios);
                    if (audio != null)
                        name = "Play 3D Audio [" + audio.Name + "] Channel [" + val[1].ToString() + "]";
                    else
                        name = "Play 3D Audio [No Audio] Channel [" + val[1].ToString() + "]";
                    break;
                case 6: // Control 3D audio
                    return name;
            }
            return name;
        }

        private string GetDataName(IEvent ev, EventPageData page)
        {
            string switchText = "";
            SwitchData switchData;
            SwitchData cSwitch;
            VariableData cVariable;
            string type = "";
            string op = "";
            string typeOp = "";
            switch (code)
            {
                case 1: // Switch
                    switch ((int)Value[2])
                    {
                        case 1:
                            if ((bool)Value[1] == true)
                                switchText = "On";
                            else
                                switchText = "Off";
                            break;
                        case 2:
                            switchData = Global.GetData<SwitchData>((int)val[1], GameData.Switches);
                            if (switchData != null)
                                switchText = "Switch [" + switchData.Name + "]";
                            else
                                switchText = "Switch [No Switch]";
                            break;
                        case 3:
                            switchData = Global.GetData<SwitchData>((int)val[1], ev.Switches);
                            if (switchData != null)
                                switchText = "Local Switch [" + switchData.Name + "]";
                            else
                                switchText = "Local Switch [No Local Switch]";
                            break;
                    }
                    cSwitch = Global.GetData<SwitchData>((int)val[0], GameData.Switches);
                    if (cSwitch != null)
                        return "Set Switch [" + cSwitch.Name + "] to " + switchText;
                    return "Set Switch [No Switch] to " + switchText;
                case 2: // Variable
                    #region Variable
                    cVariable = Global.GetData<VariableData>((int)val[0], GameData.Variables);
                    // Set Data
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            typeOp = Value[3].ToString();
                            break;
                        case 1: // Rand
                            typeOp = "Random Number Between [" + Value[3].ToString() + "] AND [" + Value[4].ToString() + "]";
                            break;
                        case 2:
                            VariableData varA = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            if (varA != null)
                                typeOp = "Variable [" + varA.Name + "]";
                            else
                                typeOp = "Variable [No Variable]";
                            break;
                        case 3:
                            VariableData varB = Global.GetData<VariableData>((int)val[3], ev.Variables);
                            if (varB != null)
                                typeOp = "Local Variable [" + varB.Name + "]";
                            else
                                typeOp = "Local Variable [No Variable]";
                            break;
                        case 4: // Event
                            switch ((int)val[4])
                            {
                                case 0:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Position X" + "]";
                                    break;
                                case 1:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Position Y" + "]";
                                    break;
                                case 2:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Angle" + "]";
                                    break;
                                case 3:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Force X" + "]";
                                    break;
                                case 4:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Force Y" + "]";
                                    break;
                                case 5:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Mass" + "]";
                                    break;
                            }
                            break;
                        case 5: // Datas
                            Data databaseA = Global.GetData<Data>((int)val[3], GameData.Databases);
                            if (databaseA != null)
                            {
                                Data dataA = Global.GetData<Data>((int)val[4], databaseA.Datas);
                                if (dataA != null)
                                {
                                    DataProperty propA = Global.GetData<DataProperty>((int)val[5], dataA.Properties);
                                    if (propA != null)
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                    else
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                }
                                else
                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                            }
                            else
                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                            break;
                        case 6: // Mouse
                            if ((int)val[3] == 0)
                                typeOp = "Mouse Position X";
                            else if ((int)val[3] == 1)
                                typeOp = "Mouse Position Y";
                            else
                                typeOp = "Mouse Scroll Value";
                            break;
                        case 7: // 
                            string stickText = "";
                            string axistText = "";
                            string playerText = "";
                            switch ((int)val[3])
                            {
                                case 0:
                                    stickText = "Right Stick";
                                    break;
                                case 1:
                                    stickText = "Left Stick";
                                    break;
                            }
                            switch ((int)val[4])
                            {
                                case 0:
                                    axistText = "X-Axis";
                                    break;
                                case 1:
                                    axistText = "Y-Axis";
                                    break;
                            }
                            playerText = "Player " + ((int)val[5] + 1).ToString();
                            typeOp = "Controller " + stickText + " " + axistText + " [" + playerText + "]";
                            break;
                        case 8: // Battler
                            DataProperty bP = Global.GetData<DataProperty>((int)val[3], GameData.Databases[1].Properties);
                            if (bP != null)
                            {
                                typeOp = "This Battler's [" + bP.Name + "]";
                            }
                            break;
                        case 9: // Other
                            switch ((int)val[3])
                            {
                                case 0: // Map ID
                                    typeOp = "[Current Map ID]";
                                    break;
                                case 1:
                                    typeOp = "[Hit Counter]";
                                    break;
                                case 2:
                                    typeOp = "[Last Exp Gained]";
                                    break;
                                case 3:
                                    typeOp = "[Total Exp Gained]";
                                    break;
                                case 4: // Item Price
                                    VariableData itemPrice = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    typeOp = "Item [" + (itemPrice != null ? itemPrice.Name : "No Variable") + "]'s Price";
                                    break;
                                case 5: // Equipment Price
                                    VariableData ePrice = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    typeOp = "Equipment [" + (ePrice != null ? ePrice.Name : "No Variable") + "]'s Price";
                                    break;
                                case 6:
                                    typeOp = "[Party Size]";
                                    break;
                                case 7:
                                    VariableData partyIndex1 = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    VariableData partyItem1 = Global.GetData<VariableData>((int)val[5], GameData.Variables);
                                    typeOp = "Number of Items [" + (partyItem1 != null ? partyItem1.Name : "No Variable") + "]";
                                    break;
                                case 8:
                                    VariableData partyIndex2 = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    VariableData partyItem2 = Global.GetData<VariableData>((int)val[5], GameData.Variables);
                                    typeOp = "Number of Equipments [" + (partyItem2 != null ? partyItem2.Name : "No Variable") + "]";
                                    break;
                            }
                            break;
                    }

                    switch ((int)Value[1])
                    {
                        case 0:
                            op = "="; break;
                        case 1:
                            op = "+="; break;
                        case 2:
                            op = "-="; break;
                        case 3:
                            op = "*="; break;
                        case 4:
                            op = "/="; break;
                        case 5:
                            op = "^="; break;
                        case 6:
                            op = "r="; break;
                    }
                    type = "Variable [";
                    if (cVariable != null)
                        return Name = type + cVariable.Name + "] " + op + " " + typeOp;
                    else
                        return Name = type + "No Variable" + "] " + op + " " + typeOp;
                    #endregion
                case 3: // Local Switch
                    switch ((int)Value[2])
                    {
                        case 1:
                            if ((bool)Value[1] == true)
                                switchText = "On";
                            else
                                switchText = "Off";
                            break;
                        case 2:
                            switchData = Global.GetData<SwitchData>((int)val[1], GameData.Switches);
                            if (switchData != null)
                                switchText = "Switch [" + switchData.Name + "]";
                            else
                                switchText = "Switch [No Switch]";
                            break;
                        case 3:
                            switchData = Global.GetData<SwitchData>((int)val[1], ev.Switches);
                            if (switchData != null)
                                switchText = "Local Switch [" + switchData.Name + "]";
                            else
                                switchText = "Local Switch [No Local Switch]";
                            break;
                    }
                    cSwitch = Global.GetData<SwitchData>((int)val[0], ev.Switches);
                    if (cSwitch != null)
                    {
                        return "Set Local Switch [" + cSwitch.Name + "] to " + switchText;
                    }
                    return "Set Local Switch [No Local Switch] to " + switchText;
                case 4: // Local Variable
                    #region Variable
                    cVariable = Global.GetData<VariableData>((int)val[0], ev.Variables);
                    // Set Data
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            typeOp = Value[3].ToString();
                            break;
                        case 1: // Rand
                            typeOp = "Random Number Between [" + Value[3].ToString() + "] AND [" + Value[4].ToString() + "]";
                            break;
                        case 2:
                            VariableData varA = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            if (varA != null)
                                typeOp = "Variable [" + varA.Name + "]";
                            else
                                typeOp = "Variable [No Variable]";
                            break;
                        case 3:
                            VariableData varB = Global.GetData<VariableData>((int)val[3], ev.Variables);
                            if (varB != null)
                                typeOp = "Local Variable [" + varB.Name + "]";
                            else
                                typeOp = "Local Variable [No Variable]";
                            break;
                        case 4: // Event
                            switch ((int)val[4])
                            {
                                case 0:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Position X" + "]";
                                    break;
                                case 1:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Position Y" + "]";
                                    break;
                                case 2:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Angle" + "]";
                                    break;
                                case 3:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Force X" + "]";
                                    break;
                                case 4:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Force Y" + "]";
                                    break;
                                case 5:
                                    typeOp = "[" + GetEvent((int)val[3]) + "'s Mass" + "]";
                                    break;
                            }
                            break;
                        case 5: // Datas
                            Data databaseA = Global.GetData<Data>((int)val[3], GameData.Databases);
                            if (databaseA != null)
                            {
                                Data dataA = Global.GetData<Data>((int)val[4], databaseA.Datas);
                                if (dataA != null)
                                {
                                    DataProperty propA = Global.GetData<DataProperty>((int)val[5], dataA.Properties);
                                    if (propA != null)
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                    else
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                }
                                else
                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                            }
                            else
                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                            break;
                        case 6: // Mouse
                            if ((int)val[3] == 0)
                                typeOp = "Mouse Position X";
                            else if ((int)val[3] == 1)
                                typeOp = "Mouse Position Y";
                            else
                                typeOp = "Mouse Scroll Value";
                            break;
                        case 7: // 
                            string stickText = "";
                            string axistText = "";
                            string playerText = "";
                            switch ((int)val[3])
                            {
                                case 0:
                                    stickText = "Right Stick";
                                    break;
                                case 1:
                                    stickText = "Left Stick";
                                    break;
                            }
                            switch ((int)val[4])
                            {
                                case 0:
                                    axistText = "X-Axis";
                                    break;
                                case 1:
                                    axistText = "Y-Axis";
                                    break;
                            }
                            playerText = "Player " + ((int)val[5] + 1).ToString();
                            typeOp = "Controller " + stickText + " " + axistText + " [" + playerText + "]";
                            break;
                        case 8: // Battler
                            DataProperty bP = Global.GetData<DataProperty>((int)val[3], GameData.Databases[1].Properties);
                            if (bP != null)
                            {
                                typeOp = "This Battler's [" + bP.Name + "]";
                            }
                            break;
                        case 9: // Other
                            switch ((int)val[3])
                            {
                                case 0: // Map ID
                                    typeOp = "[Current Map ID]";
                                    break;
                                case 1:
                                    typeOp = "[Hit Counter]";
                                    break;
                                case 2:
                                    typeOp = "[Last Exp Gained]";
                                    break;
                                case 3:
                                    typeOp = "[Total Exp Gained]";
                                    break;
                                case 4: // Item Price
                                    VariableData itemPrice = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    typeOp = "Item [" + (itemPrice != null ? itemPrice.Name : "No Variable") + "]'s Price";
                                    break;
                                case 5: // Equipment Price
                                    VariableData ePrice = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                                    typeOp = "Equipment [" + (ePrice != null ? ePrice.Name : "No Variable") + "]'s Price";
                                    break;
                                case 6:
                                    typeOp = "[Party Size]";
                                    break;
                            }
                            break;
                    }

                    switch ((int)Value[1])
                    {
                        case 0:
                            op = "="; break;
                        case 1:
                            op = "+="; break;
                        case 2:
                            op = "-="; break;
                        case 3:
                            op = "*="; break;
                        case 4:
                            op = "/="; break;
                        case 5:
                            op = "^="; break;
                        case 6:
                            op = "r="; break;
                    }
                    type = "Local Variable [";
                    if (cVariable != null)
                        return Name = type + cVariable.Name + "] " + op + " " + typeOp;
                    else
                        return Name = type + "No Variable" + "] " + op + " " + typeOp;
                    #endregion
                case 5: // List
                    #region List
                    ListData listData = Global.GetData<ListData>((int)val[0], GameData.Lists);
                    // Set Data
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            typeOp = Value[3].ToString();
                            break;
                        case 1: // Rand
                            typeOp = "Random Number Between [" + Value[3].ToString() + "] AND [" + Value[4].ToString() + "]";
                            break;
                        case 2:
                            VariableData varA = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            if (varA != null)
                                typeOp = "Variable [" + varA.Name + "]";
                            else
                                typeOp = "Variable [No Variable]";
                            break;
                        case 3:
                            VariableData varB = Global.GetData<VariableData>((int)val[3], ev.Variables);
                            if (varB != null)
                                typeOp = "Local Variable [" + varB.Name + "]";
                            else
                                typeOp = "Local Variable [No Variable]";
                            break;
                        case 4: // Event
                            if ((int)val[4] == 0)
                                typeOp = "[" + GetEvent((int)val[3]) + "'s Position X" + "]";
                            else
                                typeOp = "[" + GetEvent((int)val[3]) + "'s Position Y" + "]";
                            break;
                        case 5: // Datas
                            Data databaseA = Global.GetData<Data>((int)val[3], GameData.Databases);
                            if (databaseA != null)
                            {
                                Data dataA = Global.GetData<Data>((int)val[4], databaseA.Datas);
                                if (dataA != null)
                                {
                                    DataProperty propA = Global.GetData<DataProperty>((int)val[5], dataA.Properties);
                                    if (propA != null)
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                    else
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                }
                                else
                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                            }
                            else
                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                            break;
                        case 6: // Other
                            switch ((int)val[3])
                            {
                                case 0: // Map ID
                                    typeOp = "[Current Map ID]";
                                    break;
                            }
                            break;
                    }

                    switch ((int)Value[1])
                    {
                        case 0:
                            op = "Add"; break;
                        case 1:
                            op = "Remove"; break;
                    }
                    type = "List [";
                    if (listData != null)
                        return Name = type + listData.Name + "] " + op + " " + typeOp;
                    else
                        return Name = type + "No List" + "] " + op + " " + typeOp;
                    #endregion
                case 6: // Database
                    #region Database
                    Data cDatabase = Global.GetData<Data>((int)val[0], GameData.Databases);
                    Data cData;
                    DataProperty cProp;
                    if (cDatabase != null)
                    {
                        cData = Global.GetData<Data>((int)val[1], cDatabase.Datas);
                        if (cData != null)
                        {
                            cProp = Global.GetData<DataProperty>((int)val[2], cData.Properties);
                            if (cProp != null)
                            {
                                if (cProp.ValueType == DataType.Number)
                                {

                                    switch ((int)Value[4])
                                    {
                                        case 0: // Constant
                                            typeOp = Value[5].ToString();
                                            break;
                                        case 1: // Rand
                                            typeOp = "Random Number Between [" + Value[5].ToString() + "] AND [" + Value[6].ToString() + "]";
                                            break;
                                        case 2:
                                            VariableData varA = Global.GetData<VariableData>((int)val[5], GameData.Variables);
                                            if (varA != null)
                                                typeOp = "Variable [" + varA.Name + "]";
                                            else
                                                typeOp = "Variable [No Variable]";
                                            break;
                                        case 3:
                                            VariableData varB = Global.GetData<VariableData>((int)val[5], ev.Variables);
                                            if (varB != null)
                                                typeOp = "Local Variable [" + varB.Name + "]";
                                            else
                                                typeOp = "Local Variable [No Variable]";
                                            break;
                                        case 4: // Event
                                            if ((int)val[6] == 0)
                                                typeOp = "[" + GetEvent((int)val[5]) + "'s Position X" + "]";
                                            else
                                                typeOp = "[" + GetEvent((int)val[5]) + "'s Position Y" + "]";
                                            break;
                                        case 5: // Datas
                                            Data databaseA = Global.GetData<Data>((int)val[5], GameData.Databases);
                                            if (databaseA != null)
                                            {
                                                Data dataA = Global.GetData<Data>((int)val[6], databaseA.Datas);
                                                if (dataA != null)
                                                {
                                                    DataProperty propA = Global.GetData<DataProperty>((int)val[7], dataA.Properties);
                                                    if (propA != null)
                                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                                    else
                                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                                }
                                                else
                                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                                            }
                                            else
                                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                                            break;
                                        case 6: // Other
                                            switch ((int)val[5])
                                            {
                                                case 0: // Map ID
                                                    typeOp = "[Current Map ID]";
                                                    break;
                                            }
                                            break;
                                    }

                                    switch ((int)Value[3])
                                    {
                                        case 0:
                                            op = "="; break;
                                        case 1:
                                            op = "+="; break;
                                        case 2:
                                            op = "-="; break;
                                        case 3:
                                            op = "*="; break;
                                        case 4:
                                            op = "/="; break;
                                        case 5:
                                            op = "^="; break;
                                        case 6:
                                            op = "r="; break;
                                    }
                                    return name = "Database [" + cDatabase.Name + "] > [" + cData.Name + "] > [" + cProp.Name + "] " +
                                        op + " " + typeOp;

                                }
                                else if (cProp.ValueType == DataType.Text)
                                {
                                    // Text
                                    return name = "Database [" + cDatabase.Name + "] > [" + cData.Name + "] > [" + cProp.Name + "]" +
                                        op + val[3].ToString();
                                }
                            }
                            else
                            {
                                return name = "Database [" + cDatabase.Name + "] > [" + cData.Name + "] > [No Property]";
                            }
                        }
                        else
                        {
                            return name = "Database [" + cDatabase.Name + "] > [No Data] > [No Property]";
                        }
                    }
                    else
                    {
                        return name = "Database [No Database] > [No Data] > [No Property]";
                    }
                    #endregion
                    break;
                case 7: // String
                    #region String
                    StringData cString = Global.GetData<StringData>((int)val[0], GameData.Strings);
                    // Set Data
                    switch ((int)Value[2])
                    {
                        case 0: // Constant
                            typeOp = Value[3].ToString();
                            break;
                        case 1:
                            StringData varA = Global.GetData<StringData>((int)val[3], GameData.Strings);
                            if (varA != null)
                                typeOp = "String [" + varA.Name + "]";
                            else
                                typeOp = "String [No String]";
                            break;
                        case 2: // Datas
                            Data databaseA = Global.GetData<Data>((int)val[3], GameData.Databases);
                            if (databaseA != null)
                            {
                                Data dataA = Global.GetData<Data>((int)val[4], databaseA.Datas);
                                if (dataA != null)
                                {
                                    DataProperty propA = Global.GetData<DataProperty>((int)val[5], dataA.Properties);
                                    if (propA != null)
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [" + propA.Name + "]";

                                    else
                                        typeOp = "Value of [" + databaseA.Name + "] > [" + dataA.Name + "] > [No Property]";
                                }
                                else
                                    typeOp = "Value of [" + databaseA.Name + "] > [No Data] > [No Property]";
                            }
                            else
                                typeOp = "Value of [No Database] > [No Data] > [No Property]";
                            break;
                    }

                    switch ((int)Value[1])
                    {
                        case 0:
                            op = "Set";
                            break;
                        case 1:
                            op = "Append";
                            break;
                    }
                    type = "String [";
                    if (cString != null)
                        Name = type + cString.Name + "] " + op + " " + typeOp;
                    else
                        Name = type + "No String" + "] " + op + " " + typeOp;
                    return name;
                    #endregion
            }
            return name;
        }

        private string GetEventName(IEvent ev, EventPageData page)
        {
            VariableData varX;
            VariableData varY;
            switch (Code)
            {
                case 1: // Create Event
                    EventData tmpEvent = Global.GetData<EventData>((int)val[0], GameData.Events);
                    if (tmpEvent == null)
                        name = "Add Template Event [No Event] ";
                    else
                        name = "Add Template Event [" + tmpEvent.Name + "] ";

                    switch ((int)Value[1])
                    {
                        case 0: // Custom
                            name += "Position [" + val[2].ToString() + ", " + val[3].ToString() + "] ";
                            break;
                        case 1:// Varaibles
                            varX = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            varY = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            if (varX != null && varY != null)
                            {
                                name += "Position [" + varX.Name + ", " + varY.Name + "] ";
                            }
                            else
                                name += "Position [No Variable] ";
                            break;
                        case 2: // Event
                            name += "Position On Event [" + GetEvent((int)val[2]) + "] ";
                            break;
                    }
                    name += "Layer [" + val[4].ToString() + "]";
                    return name;
                case 2: // Edit Event Animation
                    AnimationData animation = Global.GetData<AnimationData>((int)val[1], GameData.Animations);
                    if (animation != null)
                    {
                        AnimationAction action = Global.GetData<AnimationAction>((int)val[2], animation.Actions);
                        if (action != null)
                            return name = "Change Event [" + GetEvent((int)val[0]) + "]'s Animation To [" + animation.Name + "] > [" + action.Name + "]";
                        else
                            return name = "Change Event [" + GetEvent((int)val[0]) + "]'s Animation To [" + animation.Name + "] > [No Action]";
                    }
                    return name = "Change Event [" + GetEvent((int)val[0]) + "]'s Animation To [No Animation] > [No Action]";
                case 3: // Move Event
                    // Events
                    name = "Set Event Location: ";
                    name += "[" + GetEvent((int)val[0]) + "]";

                    switch ((int)val[1])
                    {
                        case 0:
                            name += " Map X [" + val[3].ToString() + "]";
                            name += " Map Y [" + val[4].ToString() + "]";
                            break;
                        case 1:
                            VariableData mapxVar = Global.GetData<VariableData>((int)val[3], GameData.Variables);
                            VariableData mapyVar = Global.GetData<VariableData>((int)val[4], GameData.Variables);

                            if (mapxVar != null)
                                name += " Map X [" + mapxVar.ToString() + "]";
                            else
                                name += " Map X [No Variable]";
                            if (mapyVar != null)
                                name += " Map Y [" + mapyVar.ToString() + "]";
                            else
                                name += " Map Y [No Variable]";
                            break;
                        case 2:
                            name += " Exchange With [" + GetEvent((int)val[3]) + "]";
                            break;
                    }
                    string[] dirs = new string[] { "Don't Change", "Up", "Down", "Left", "Right", "Up/Left", "Up/Right", "Down/Left", "Down/Right" };
                    name += " Direction [" + dirs[(int)val[2]] + "]";
                    return name;
                case 4: // Delete Event
                    return name = "Delete Event: " + GetEvent((int)val[0]) + "";
                case 5: // Exit Branch
                    return name;
                case 6: // Activate Global 
                    GlobalEventData globEvent = Global.GetData<GlobalEventData>((int)val[0], GameData.GlobalEvents);
                    if (globEvent != null)
                        return name = "Activate Global Event: " + globEvent.Name;
                    else
                        return name = "Activate Global Event: No Global Event";
                case 7: // Change Event Layer
                    return name = "Change Event [" + GetEvent((int)val[0]) + "]'s Layer [" + Value[1].ToString() + "]";
                case 8: // Change Event Particle
                    ParticleSystemData particle = Global.GetData<ParticleSystemData>((int)val[1], GameData.ParticleSystems);
                    name = "Change Event Particle: Event [" + GetEvent((int)val[0]) + "] Particle [" + (particle != null ? particle.Name : "No Particle") + "]";

                    return name;
                case 9: // Apply Knockback Field
                    return name;
                case 12: // Shader Effect
                    MaterialData effect = Global.GetData<MaterialData>((int)val[1], GameData.Materials);

                    name = "Apply Shader Effect [" + (effect != null ? effect.Name : "No Effect") + "] To Event [" + GetEvent((int)val[0]) + "]";
                    return name;
                case 13: // Attach Gravity
                    // Events
                    name = "Attach Gravity To Event: ";
                    name += "[" + GetEvent((int)val[0]) + "]";

                    switch ((int)val[1])
                    {
                        case 0:
                            name += " Strength [" + val[2].ToString() + "]";
                            name += " Radius [" + val[3].ToString() + "]";
                            break;
                        case 1:
                            VariableData mapxVar = Global.GetData<VariableData>((int)(float)val[2], GameData.Variables);
                            VariableData mapyVar = Global.GetData<VariableData>((int)(float)val[3], GameData.Variables);

                            if (mapxVar != null)
                                name += " Strength [" + mapxVar.ToString() + "]";
                            else
                                name += " Strength [No Variable]";
                            if (mapyVar != null)
                                name += " Radius [" + mapyVar.ToString() + "]";
                            else
                                name += " Radius [No Variable]";
                            break;
                    }
                    return name;
            }
            return name;
        }

        private string GetMapName(IEvent ev, EventPageData page)
        {
            switch (Code)
            {
                case 1: // Toggle Map Layer
                    return name;
                case 2: // Transfer Event
                    MapInfo map = Global.GetData<MapInfo>((int)val[0], Global.Project.MapsInfo);

                    string text = ""; string mapName;
                    if (map != null)
                        mapName = map.Name;
                    else if ((int)val[0] == -1)
                        mapName = "Current Map";
                    else if ((int)val[0] == -2)
                        mapName = "Player Start Position";
                    else
                        mapName = "No Map";


                    if ((int)Value[1] == 0)
                    {
                        text = " Constant: X: [" + Value[2].ToString() + "] Y: [" + Value[3].ToString() + "]";
                    }
                    else
                    {
                        VariableData varX = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                        VariableData varY = Global.GetData<VariableData>((int)val[3], GameData.Variables);

                        text = " Variable: X: [" + varX.Name + "] Y: [" + varY.Name + "]";
                    }
                    return name = "Transfer Player To Map: [" + mapName + "]" + text;

                case 3: // Fog
                    if ((int)val[0] > -1)
                    {
                        MaterialData material = Global.GetData<MaterialData>((int)val[0], GameData.Materials);
                        if (material != null && material.DataType == MaterialDataType.Image)
                            return name = "Show Fog: Material [" + material.Name + "] Speed [" + val[2].ToString() + "]";
                        return name = "Show Fog: Material [No Material] Speed [" + val[2].ToString() + "]";
                    }
                    return "Clear Fog";
                case 4: // Weather
                    string[] weathers = new string[] { "None", "Rain", "Storm", "Snow" };
                    MaterialData tx = Global.GetData<MaterialData>((int)val[2], GameData.Materials);
                    name = "Set Weather to [" + weathers[(int)val[0]] + "]" + " Power: " + val[1].ToString() + " Texture: " + (tx != null ? tx.Name : "No Texture");
                    return name;
                case 5: // Camera Scroll
                    return name;
                case 6: // Camera Center
                    return name;
                case 7: // Scroll Camera To
                    if ((int)Value[1] < 2)
                    {
                        text = " X: [" + GetValue((int)val[1], (int)Value[2]) + "] Y: [" + GetValue((int)val[1], (int)Value[3]) + "]";
                    }
                    else
                    {
                        text = " Event [" + GetEvent((int)val[2]) + "]";
                    }
                    name = "Scroll Camera To: " + text + " Frames [" + Value[0].ToString() + "]";

                    return name;
                case 9: // Reload Map
                    return name;
                case 10: // Shader Effect
                    MaterialData effect = Global.GetData<MaterialData>((int)val[0], GameData.Materials);

                    name = "Apply Shader Effect [" + (effect != null ? effect.Name : "No Effect") + "] To Current Map";
                    return name;
                case 11: // Attach Gravity
                    // Events
                    name = "Gravity Points: Index ";
                    name += "[" + (int)val[0] + "]";

                    if (!(bool)val[1])
                        name += " Remove";
                    else
                    {
                        name += " Add";
                        switch ((int)val[2])
                        {
                            case 0:
                                name += " X [" + val[5].ToString() + "]";
                                name += " Y [" + val[6].ToString() + "]";
                                name += " Strength [" + val[3].ToString() + "]";
                                name += " Radius [" + val[4].ToString() + "]";
                                break;
                            case 1:
                                VariableData mapxVar = Global.GetData<VariableData>((int)(float)val[3], GameData.Variables);
                                VariableData mapyVar = Global.GetData<VariableData>((int)(float)val[4], GameData.Variables);
                                VariableData mapxVar2 = Global.GetData<VariableData>((int)(float)val[5], GameData.Variables);
                                VariableData mapyVar2 = Global.GetData<VariableData>((int)(float)val[6], GameData.Variables);

                                if (mapxVar2 != null)
                                    name += " X [" + mapxVar2.ToString() + "]";
                                else
                                    name += " X [No Variable]";
                                if (mapyVar2 != null)
                                    name += " Y [" + mapyVar2.ToString() + "]";
                                else
                                    name += " Y [No Variable]";

                                if (mapxVar != null)
                                    name += " Strength [" + mapxVar.ToString() + "]";
                                else
                                    name += " Strength [No Variable]";
                                if (mapyVar != null)
                                    name += " Radius [" + mapyVar.ToString() + "]";
                                else
                                    name += " Radius [No Variable]";
                                break;
                        }
                    }
                    return name;
                case 12: // Attach Camera to Event
                    if ((bool)val[0])
                    {
                        name = "Attach Camera to Event: None";
                    }
                    else
                    { 
                        name = "Attach Camera to Event: " + GetEvent((int)val[1]);
                    }
                    break;
            }
            return name;
        }

        private string GetScreenName(IEvent ev, EventPageData page)
        {
            switch (code)
            {
                case 1:
                    name = "Fadeout";
                    break;
                case 2:
                    name = "Fadein";
                    break;
                case 6: // Zoom
                    name = "Zoom: [";
                    name += GetValue((int)val[0], (int)val[1]) + "] / 100 [";
                    name += GetValue((int)val[0], (int)val[2]) + "] / 100";
                    break;
            }
            return name;
        }

        private string GetOtherName(IEvent ev, EventPageData page)
        {
            if (code == 4)
            {
                string control = "";
                switch ((int)val[0])
                {
                    case 0:
                        control = "Create / Start";
                        break;
                    case 1:
                        control = "Create / Stop";
                        break;
                    case 2:
                        control = "Start";
                        break;
                    case 3:
                        control = "Stop";
                        break;
                    case 4:
                        control = "Reset";
                        break;
                }
                VariableData variable = Global.GetData<VariableData>((int)Value[1], GameData.Variables);

                string type = "Error";
                if ((int)val[5] == 0)
                {
                    type = "Increase";
                }
                else
                {
                    type = "Decrease";
                }

                if (variable != null)
                    return name = control + " Timer: Variable [" + variable.Name + "] [" + Value[2].ToString() + ":" + Value[3].ToString() + ":" + Value[4].ToString() + "] [" + type + "]";
                else
                    return name = control + " Timer: Variable [No Variable] [" + Value[2].ToString() + ":" + Value[3].ToString() + ":" + Value[4].ToString() + "] [" + type + "]";
            }
            else if (code == 12)
            {
                if ((int)val[5] == 0)
                    name = "Set " + ((bool)val[8] ? "Keyboard" : "Controller") + " Hotkey " + ((int)val[4] == 0 ? "Skill [" + GetSkill((int)val[6]) + "]" : "Item [" + GetItem((int)val[6]) + "]") + "  " + ((bool)val[8] ? "Keys [" + Keyboard((int)val[2]) + ((int)val[3] - 1 == -1 ? "" : " + " + Keyboard((int)val[3] - 1)) : "Button [" + Button((int)val[0]) + ((int)val[1] - 1 == -1 ? "" : " + " + Button((int)val[1] - 1))) + "]";
                else
                    name = "Set " + ((bool)val[8] ? "Keyboard" : "Controller") + " Hotkey Variable " + ((int)val[4] == 0 ? "Skill [" + GetValue(1, (int)val[6]) + "]" : "Item [" + GetValue(1, (int)val[6])) + " " + ((bool)val[8] ? "Keys [" + Keyboard((int)val[2]) + ((int)val[3] - 1 == -1 ? "" : " + " + Keyboard((int)val[3] - 1)) : "Button [" + Button((int)val[0]) + ((int)val[1] - 1 == -1 ? "" : " + " + Button((int)val[1] - 1))) + "]";
            }
            return name;
        }

        private string GetItem(int id)
        {
            ItemData data = Global.GetData<ItemData>(id, GameData.Items);
            if (data != null) return data.Name;
            return "No Item";
        }

        private string GetSkill(int id)
        {
            SkillData data = Global.GetData<SkillData>(id, GameData.Skills);
            if (data != null) return data.Name;
            return "No Skill";
        }

        private string GetMovementName(IEvent ev, EventPageData page)
        {
            VariableData variable = null;
            VariableData variable2 = null;
            switch (code)
            {
                case 10:
                    string pmevName = GetEvent((int)val[0]);

                    name = "Program Dynamics - " + pmevName;
                    break;
                case 2: // Move 
                    #region Move
                    string[] array = new string[]{"Custom Angle [" + val[2].ToString() + "] by" ,
                        "Forward by",
                        "Backward by",
                        "Leftward by",
                        "Rightward by"};
                    name = "Move " + array[(int)val[0]] + " [" + ((int)val[1] == 0 ? "Force] " : "Impulse]") + " Distance ";
                    switch ((int)val[3])
                    {
                        case 0: // Constant
                            name += "[" + val[4].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[4], GameData.Variables);
                            if (variable != null)
                                name += "[" + variable.Name + "]";
                            else
                                name += "[" + "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)val[4], ev.Variables);
                            if (variable != null)
                                name += "[" + variable.Name + "]";
                            else
                                name += "[" + "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 6: // Turn
                    #region Turn
                    name = "Turn: Angle [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            if (ev != null)
                            {
                                variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            }
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                        case 3: // Variable
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            variable2 = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            name += (variable == null ? "No Variable" : variable.Name) + ", " + (variable2 == null ? "No Variable" : variable2.Name) + "]";
                            break;
                        case 4: // Local Variable
                            if (ev != null)
                            {
                                variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                                variable2 = Global.GetData<VariableData>((int)val[2], ev.Variables);
                            }
                            name += (variable == null ? "No Variable" : variable.Name) + ", " + (variable2 == null ? "No Variable" : variable2.Name) + "]";
                            break;
                    }
                    return name;
                    #endregion
                case 9: // Move To
                    #region Move To
                    name = "Move To: ";
                    switch ((int)val[0])
                    {
                        case 0:
                            name += "[" + val[1].ToString() + ", " + val[2].ToString() + "]";
                            break;
                        case 1:
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            variable2 = Global.GetData<VariableData>((int)val[2], GameData.Variables);
                            name += "[" + (variable != null ? variable.Name : "No Variable") + ", " + (variable2 != null ? variable2.Name : "No Variable") + "]";
                            break;
                        case 2:
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            variable2 = Global.GetData<VariableData>((int)val[2], ev.Variables);
                            name += "[" + (variable != null ? variable.Name : "No Local Variable") + ", " + (variable2 != null ? variable2.Name : "No Local Variable") + "]";
                            break;
                    }
                    name += " Precision [" + val[6].ToString() + "]";
                    return name;
                    #endregion
                case 11: // Jump
                    #region Jump
                    name = "Jump: Angle ";
                    switch ((int)val[0])
                    {
                        case 0:
                            name += "[" + val[1].ToString() + "] Force [" + val[2].ToString() + "]";
                            break;
                        case 1:
                            variable = Global.GetData<VariableData>((int)val[1], GameData.Variables);
                            variable2 = Global.GetData<VariableData>((int)(float)val[2], GameData.Variables);
                            name += "[" + (variable != null ? variable.Name : "No Variable") + "] Force [" + (variable2 != null ? variable2.Name : "No Variable") + "]";
                            break;
                        case 2:
                            variable = Global.GetData<VariableData>((int)val[1], ev.Variables);
                            variable2 = Global.GetData<VariableData>((int)(float)val[2], ev.Variables);
                            name += "[" + (variable != null ? variable.Name : "No Local Variable") + "] Force [ " + (variable2 != null ? variable2.Name : "No Local Variable") + "]";
                            break;
                    }
                    return name;
                    #endregion
                case 14: // Apply Force
                    #region Apply Force
                    string[] array2 = new string[]{"Custom Angle [" + val[2].ToString() + "] " ,
                        "Forward",
                        "Backward",
                        "Leftward",
                        "Rightward"};
                    name = "Apply " + "[" + ((int)val[1] == 0 ? "Force] " : "Impulse] ");
                    switch ((int)val[3])
                    {
                        case 0: // Constant
                            name += "[" + val[4].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)(float)val[4], GameData.Variables);
                            if (variable != null)
                                name += "[" + variable.Name + "]";
                            else
                                name += "[" + "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)(float)val[4], ev.Variables);
                            if (variable != null)
                                name += "[" + variable.Name + "]";
                            else
                                name += "[" + "No Local Variable]";
                            break;
                    }
                    return name + " " + array2[(int)val[0]];
                    #endregion
                case 15: // Apply Rotation
                    #region Apply Rotation
                    name = "Apply Rotation [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)(float)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)(float)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 17: // Apply Torque
                    #region Apply Torque
                    name = "Apply Torque [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)(float)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)(float)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
                case 18: // Apply Angular Impulse
                    #region Apply Angular Impulse
                    name = "Apply Angular Impulse [";
                    switch ((int)val[0])
                    {
                        case 0: // Constant
                            name += val[1].ToString() + "]";
                            break;
                        case 1: // Variable
                            variable = Global.GetData<VariableData>((int)(float)val[1], GameData.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Variable]";
                            break;
                        case 2: // Local Variable
                            variable = Global.GetData<VariableData>((int)(float)val[1], ev.Variables);
                            if (variable != null)
                                name += variable.Name + "]";
                            else
                                name += "No Local Variable]";
                            break;
                    }
                    return name;
                    #endregion
            }
            return name;
        }
        /// <summary>
        /// Get direction
        /// </summary>
        /// <param name="dirIndex"></param>
        /// <returns></returns>
        private string GetDirection(int dirIndex)
        {
            switch (dirIndex)
            {
                case 0:
                    return "Up";
                case 1:
                    return "Down";
                case 2:
                    return "Left";
                case 3:
                    return "Right";
                case 4:
                    return "Up/Left";
                case 5:
                    return "Up/Right";
                case 6:
                    return "Down/Left";
                case 7:
                    return "Down/Right";
            }
            return "No Direction";
        }

        private string GetEvent(int id)
        {
            if (id == -3)
                return "Target";
            if (id == -2)
                return "This Event";
            else if (id == -1)
                return "Player";
            else
            {
                EventData ev = Global.GetData<EventData>(id, Global.GetMapEventList(MainForm.SelectedMap));
                if (ev != null) return ev.Name;
            }
            return "No Event";
        }

        private string GetProjectile(int id)
        {
            if (id == -1)
                return "Any Projectile";
            else
            {
                ProjectileGroupData ev = Global.GetData<ProjectileGroupData>(id, GameData.Projectiles);
                if (ev != null) return ev.Name;
            }
            return "No Projectile";
        }
        #endregion
        /// <summary>
        /// The unique id of the program.
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
        /// <summary>
        /// The child programs of the program.
        /// </summary>
        public override List<EventProgramData> Programs
        {
            get { return childActions; }
            set { childActions = value; }
        }
        List<EventProgramData> childActions = new List<EventProgramData>();
        /// <summary>
        /// The category of the program.
        /// </summary>
        public override ProgramCategory ProgramCategory
        {
            get { return acategory; }
            set { acategory = value; }
        }
        ProgramCategory acategory;
        /// <summary>
        /// Determines if its enabled or not.
        /// </summary>
        public override bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        bool enabled = true;
        public override int Code
        {
            get { return code; }
            set { code = value; }
        }
        int code;
        /// <summary>
        /// Determines whether if the program is a branch.
        /// </summary>
        public bool Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        bool branch = false;
        /// <summary>
        /// Determines whether if the program is a else.
        /// </summary>
        public bool Else
        {
            get { return _else; }
            set { _else = value; }
        }
        bool _else = false;
        /// <summary>
        /// The child programs of the program.
        /// </summary>
        public List<EventProgramData> ElsePrograms
        {
            get { return elseActions; }
            set { elseActions = value; }
        }
        List<EventProgramData> elseActions = new List<EventProgramData>();
        /// <summary>
        /// Determines if the program is expanded (if its branch).
        /// </summary>
        public bool Expand
        {
            get { return expand; }
            set { expand = value; }
        }
        bool expand = true;

        public object[] Value
        {
            get { return val; }
            set { val = value; }
        }
        object[] val = new object[12];
    }

    public enum ProgramCategory
    {
        Movement,
        Settings,
        Display,
        Conditions,
        Loops,
        Audio,
        Data,
        Event,
        Map,
        Screen,
        Graphics,
        Guide,
        Other,
        Party,
        Hero,
        Menu,
        Battle,
        Attachment
    }
}
