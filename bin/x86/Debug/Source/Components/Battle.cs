using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Interfaces;
using EGMGame.Processors;

namespace EGMGame.Components
{
    public class Battle
    {
        public static Random random = new Random();
        /// <summary>
        /// Get's target
        /// </summary>
        /// <param name="enemyProgramIndex"></param>
        public static void GetEnemyProgramIndex(out int enemyProgramIndex, EnemyProcessor enemy)
        {
            int percent;
            bool add = false;
            List<EnemyProgram> programs = new List<EnemyProgram>();
            List<int> table = new List<int>();
            enemyProgramIndex = -1;
            // Loop All Actions from Highest to Lowest Priority
            // And eliminate those that don't meet conditions
            for (int i = 0; i < enemy.Data.Programs.Count; i++)
            {
                switch (enemy.Data.Programs[i].Condition)
                {
                    case EnemyActionCondition.HP:
                        percent = (int)(((float)enemy.Hp / (float)enemy.MaxHP) * 100f);
                        if (percent >= enemy.Data.Programs[i].ConditionValue[0] &&
                         percent <= enemy.Data.Programs[i].ConditionValue[1])
                            add = true;
                        break;
                    case EnemyActionCondition.MP:
                        percent = (int)(((float)enemy.Mp / (float)enemy.MaxMP) * 100f);
                        if (percent >= enemy.Data.Programs[i].ConditionValue[0] &&
                         percent <= enemy.Data.Programs[i].ConditionValue[1])
                            add = true;
                        break;
                    case EnemyActionCondition.SP:
                        percent = (int)(((float)enemy.Sp / (float)enemy.MaxSP) * 100f);
                        if (percent >= enemy.Data.Programs[i].ConditionValue[0] &&
                         percent <= enemy.Data.Programs[i].ConditionValue[1])
                            add = true;
                        break;
                    case EnemyActionCondition.State:
                        for (int j = 0; i < enemy.States.Count; i++)
                            if (enemy.States[j].ID == enemy.Data.Programs[i].ConditionValue[0])
                                add = true;
                        break;
                    case EnemyActionCondition.Switch:
                        bool sw = (enemy.Data.Programs[i].ConditionValue[1] == 0 ? true : false);
                        SwitchData sdata = Global.Instance.Switches.GetData(enemy.Data.Programs[i].ConditionValue[0]);
                        if (sdata != null && sdata.State == sw)
                            add = true;
                        break;
                    case EnemyActionCondition.PartyLevel:
                        switch (enemy.Data.Programs[i].ConditionValue[1])
                        {
                            case 0: // Is and Above
                                if (enemy.Data.Programs[i].ConditionValue[0] <= Global.Instance.Party.Level())
                                    add = true;
                                break;
                            case 1: // Is and Below
                                if (enemy.Data.Programs[i].ConditionValue[0] >= Global.Instance.Party.Level())
                                    add = true;
                                break;
                        }
                        break;
                    case EnemyActionCondition.EveryTurnTime:
                        add = true;
                        break;
                    case EnemyActionCondition.Always:
                        add = true;
                        break;
                }

                if (add)
                {
                    programs.Add(enemy.Data.Programs[i]);
                    // Add Priority to the list
                    if (!table.Contains(enemy.Data.Programs[i].Priority))
                        table.Add(enemy.Data.Programs[i].Priority);
                }
                add = false;
            }
            // Create Table
            List<int> newTable = new List<int>();
            foreach (int value in table)
            {
                for (int i = 0; i < value; i++)
                {
                    newTable.Add(value);
                }
            }
            if (table.Count > 0)
            {
                int priority = newTable[random.Next(0, newTable.Count)];
                // Loop Remaining Programs
                int selectedIndex = -1; ;
                for (int i = 0; i < programs.Count; i++)
                {
                    if (priority >= programs[i].Priority)
                    {
                        selectedIndex = i; break;
                    }
                }
                if (selectedIndex > -1)
                    enemyProgramIndex = enemy.Data.Programs.IndexOf(programs[selectedIndex]);
            }
        }

        #region Method: Use Item
        /// <summary>
        /// Uses item
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="item"></param>
        /// <param name="effectIndex"></param>
        public static bool UseItem(IBattler target, ItemData item, int index)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (item.Effects[index].ValueType)
            {
                case ItemValueType.Constant:
                    ApplyConstant(target, item.Effects[index].Property, item.Effects[index].Value);
                    break;
                case ItemValueType.Percentage:
                    ApplyPercentage(target, item.Effects[index].Property, item.Effects[index].Value);
                    break;
                case ItemValueType.Damage:
                    ApplyItemDamage(target, item, item.Effects[index]);
                    break;
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < item.InflictState.Count; i++)
                    target.InflictState(item.InflictState[i]);
                for (int i = 0; i < item.RemoveState.Count; i++)
                    target.RemoveState(item.InflictState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Apply Item Damage
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="item"></param>
        /// <param name="itemEffect"></param>
        /// <returns></returns>
        private static bool ApplyItemDamage(IBattler target, ItemData item, ItemEffect effect)
        {
            int damage = Math.Max(0, effect.Value * 4 - target.Defense * 2);
            damage = (int)(damage * ElementModification(target, item.Elements));
            // Make the last 20% of the damage a random value
            damage = random.Next((int)(damage * .8f), damage);
            // Apply Constant
            ApplyConstant(target, effect.Property, -damage);
            // Apply Damage
            target.Damage = damage;
            // Return Damage
            return target.Damaged = (damage != 0);
        }
        /// <summary>
        /// Uses item
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="item"></param>
        /// <param name="effectIndex"></param>
        public static bool UseItem(IBattler user, IBattler target, ItemData item, int index)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (item.Effects[index].ValueType)
            {
                case ItemValueType.Constant:
                    ApplyConstant(target, item.Effects[index].Property, item.Effects[index].Value);
                    break;
                case ItemValueType.Percentage:
                    ApplyPercentage(target, item.Effects[index].Property, item.Effects[index].Value);
                    break;
                case ItemValueType.Damage:
                    ApplyItemDamage(user, target, item, item.Effects[index]);
                    break;
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < item.InflictState.Count; i++)
                    target.InflictState(item.InflictState[i]);
                for (int i = 0; i < item.RemoveState.Count; i++)
                    target.RemoveState(item.InflictState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Apply Item Damage
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="item"></param>
        /// <param name="itemEffect"></param>
        /// <returns></returns>
        private static bool ApplyItemDamage(IBattler user, IBattler target, ItemData item, ItemEffect effect)
        {
            // Check if Missed
            if ((float)random.Next(0, 10) / 10f <= ((float)(user.Agility) / (float)target.Agility) || user == target)
            {
                int damage = Math.Max(0, effect.Value * 4 - target.Defense * 2);
                damage = (int)(damage * ElementModification(target, item.Elements));
                if (damage > 0)
                {
                    // Test Critical
                    target.Critical = (random.Next(0, 100) < (user.Luck / target.Luck));
                    if (user.PreventCritical)
                        target.Critical = false;
                    else if (target.Critical)
                        damage *= 2;
                }
                // Make the last 20% of the damage a random value
                damage = random.Next((int)(damage * .8f), damage);
                // Apply Combo Effect
                if (Global.Instance.Party.Heroes[0] == user)
                    ApplyDamageCombo(ref damage);
                // Apply Constant
                ApplyConstant(target, effect.Property, -damage);
                // Apply Damage
                target.Damage = damage;
                // Return Damage
                return target.Damaged = (damage != 0);
            }
            return false;
        }
        #endregion

        #region Method: Use Skill
        /// <summary>
        /// Use Skill + Projectile Effect
        /// </summary>
        /// <param name="OwnerBattler"></param>
        /// <param name="iBattler"></param>
        /// <param name="Skill"></param>
        /// <param name="index"></param>
        /// <param name="increaseEffectParamater"></param>
        internal static bool UseSkill(IBattler user, IBattler target, SkillData skill, int index, int increaseEffectParamater)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (skill.Effects[index].ValueType)
            {
                case ItemValueType.Constant:
                    ApplyConstant(target, skill.Effects[index].Property, skill.Effects[index].Value + increaseEffectParamater);
                    break;
                case ItemValueType.Percentage:
                    ApplyPercentage(target, skill.Effects[index].Property, skill.Effects[index].Value + increaseEffectParamater);
                    break;
                case ItemValueType.Damage:
                    ApplySkillDamage(user, target, skill, skill.Effects[index], increaseEffectParamater);
                    break;
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < skill.InflictState.Count; i++)
                    target.InflictState(skill.InflictState[i]);
                for (int i = 0; i < skill.RemoveState.Count; i++)
                    target.RemoveState(skill.RemoveState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Use Skill
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool UseSkill(IBattler user, IBattler target, SkillData skill, int index)
        {
            if (skill.SkillType == SkillType.Magic) return UseMagic(user, target, skill, index);
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (skill.Effects[index].ValueType)
            {
                case ItemValueType.Constant:
                    ApplyConstant(target, skill.Effects[index].Property, skill.Effects[index].Value);
                    break;
                case ItemValueType.Percentage:
                    ApplyPercentage(target, skill.Effects[index].Property, skill.Effects[index].Value);
                    break;
                case ItemValueType.Damage:
                    ApplySkillDamage(user, target, skill, skill.Effects[index], 0);
                    break;
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < skill.InflictState.Count; i++)
                    target.InflictState(skill.InflictState[i]);
                for (int i = 0; i < skill.RemoveState.Count; i++)
                    target.RemoveState(skill.RemoveState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Apply Skill Damage
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="skill"></param>
        /// <param name="skillEffect"></param>
        /// <returns></returns>
        private static bool ApplySkillDamage(IBattler user, IBattler target, SkillData skill, SkillEffect effect, int effectIncrease)
        {
            // Check if Missed
            if ((float)random.Next(0, 10) / 10f <= ((float)(user.Agility) / (float)target.Agility) || user == target || (user is HeroProcessor && target is HeroProcessor))
            {
                int damage = Math.Max(0, (user.Strength + effect.Value + effectIncrease) * 4 - target.Defense * 2);
                damage = (int)(damage * ElementModification(target, skill.Elements));
                if (damage > 0)
                {
                    // Test Critical
                    target.Critical = (random.Next(0, 100) < (user.Luck / target.Luck));
                    if (user.PreventCritical)
                        target.Critical = false;
                    else if (target.Critical)
                        damage *= 2;
                }
                // Make the last 20% of the damage a random value
                damage = random.Next((int)(damage * .8f), damage);
                // Apply Combo Effect
                if (Global.Instance.Party.Heroes[0] == user)
                    ApplyDamageCombo(ref damage);
                // Apply Constant
                ApplyConstant(target, effect.Property, -damage);
                // Apply Damage
                target.Damage = damage;
                // Return Damage
                return target.Damaged = (damage != 0);
            }
            return false;
        }
        #endregion

        #region Method: Use Magic
        /// <summary>
        /// Use Magic
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="skill"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool UseMagic(IBattler user, IBattler target, SkillData skill, int index, int effectIncrease)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (skill.Effects[index].ValueType)
            {
                case ItemValueType.Constant:
                    return ApplyConstant(target, skill.Effects[index].Property, skill.Effects[index].Value + effectIncrease);
                case ItemValueType.Percentage:
                    return ApplyPercentage(target, skill.Effects[index].Property, skill.Effects[index].Value + effectIncrease);
                case ItemValueType.Damage:
                    return ApplyMagicDamage(user, target, skill, skill.Effects[index], effectIncrease);
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < skill.InflictState.Count; i++)
                    target.InflictState(skill.InflictState[i]);
                for (int i = 0; i < skill.RemoveState.Count; i++)
                    target.RemoveState(skill.RemoveState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Use Magic
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="skill"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool UseMagic(IBattler user, IBattler target, SkillData skill, int index)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (skill.Effects[index].ValueType)
            {
                case ItemValueType.Constant:
                    return ApplyConstant(target, skill.Effects[index].Property, skill.Effects[index].Value);
                case ItemValueType.Percentage:
                    return ApplyPercentage(target, skill.Effects[index].Property, skill.Effects[index].Value);
                case ItemValueType.Damage:
                    return ApplyMagicDamage(user, target, skill, skill.Effects[index], 0);
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < skill.InflictState.Count; i++)
                    target.InflictState(skill.InflictState[i]);
                for (int i = 0; i < skill.RemoveState.Count; i++)
                    target.RemoveState(skill.RemoveState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Apply Magic Damage
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="skill"></param>
        /// <param name="skillEffect"></param>
        /// <returns></returns>
        private static bool ApplyMagicDamage(IBattler user, IBattler target, SkillData skill, SkillEffect effect, int effectIncrease)
        {
            // Check if Missed
            if ((float)random.Next(0, 10) / 10f <= ((float)(user.Agility) / (float)target.Agility))
            {
                int damage = Math.Max(0, (user.MagicStr + effect.Value + effectIncrease) * 4 - target.MagicDef * 2);
                damage = (int)(damage * ElementModification(target, skill.Elements));
                if (damage > 0)
                {
                    // Test Critical
                    target.Critical = (random.Next(0, 100) < (user.Luck / target.Luck));
                    if (user.PreventCritical)
                        target.Critical = false;
                    else if (target.Critical)
                        damage *= 2;
                }
                // Make the last 20% of the damage a random value
                damage = random.Next((int)(damage * .8f), damage);
                // Apply Combo Effect
                if (Global.Instance.Party.Heroes[0] == user)
                    ApplyDamageCombo(ref damage);
                // Apply Constant
                ApplyConstant(target, effect.Property, -damage);
                // Apply Damage
                target.Damage = damage;
                // Return Damage
                return target.Damaged = (damage != 0);
            }
            return false;
        }
        #endregion

        #region Method: Physical Attack
        /// <summary>
        /// Attack + Projectile
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="equipment"></param>
        /// <param name="effectIncrease"></param>
        /// <returns></returns>
        internal static bool Attack(IBattler user, IBattler target, EquipmentData equipment, int effectIncrease)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (equipment.ValueType)
            {
                case ItemValueType.Constant:
                    ApplyConstant(target, equipment.Property, equipment.Value + effectIncrease);
                    break;
                case ItemValueType.Percentage:
                    ApplyPercentage(target, equipment.Property, equipment.Value + effectIncrease);
                    break;
                case ItemValueType.Damage:
                    ApplyWeaponDamage(user, target, equipment, effectIncrease);
                    break;
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < equipment.InflictState.Count; i++)
                    target.InflictState(equipment.InflictState[i]);
                for (int i = 0; i < equipment.RemoveState.Count; i++)
                    target.RemoveState(equipment.InflictState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Attack damage calculations
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public static bool Attack(IBattler user, IBattler target, EquipmentData equipment)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (equipment.ValueType)
            {
                case ItemValueType.Constant:
                    ApplyConstant(target, equipment.Property, equipment.Value);
                    break;
                case ItemValueType.Percentage:
                    ApplyPercentage(target, equipment.Property, equipment.Value);
                    break;
                case ItemValueType.Damage:
                    ApplyWeaponDamage(user, target, equipment, 0);
                    break;
            }
            // Inflict State
            if (target.Damaged)
            {
                for (int i = 0; i < equipment.InflictState.Count; i++)
                    target.InflictState(equipment.InflictState[i]);
                for (int i = 0; i < equipment.RemoveState.Count; i++)
                    target.RemoveState(equipment.InflictState[i]);
            }
            return target.Damaged;
        }
        /// <summary>
        /// Apply Weapon Damage
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="equipment"></param>
        /// <returns></returns>
        private static bool ApplyWeaponDamage(IBattler user, IBattler target, EquipmentData equipment, int effectIncrease)
        {
            // Check if Missed
            if ((float)random.Next(0, 10) / 10f <= ((float)(user.Agility) / (float)target.Agility))
            {
                int damage = Math.Max(0, (user.Strength + effectIncrease) * 4 - target.Defense * 2);
                damage = (int)(damage * ElementModification(target, equipment.Elements));
                if (damage > 0)
                {
                    // Test Critical
                    target.Critical = (random.Next(0, 100) < (user.Luck / target.Luck) + (equipment.CriticalBonus ? 30 : 0));
                    if (user.PreventCritical)
                        target.Critical = false;
                    else if (target.Critical)
                        damage *= 2;
                }
                // Make the last 20% of the damage a random value
                int min = (damage > 0 ? (int)(damage * .8f) : damage);
                int max = (damage > 0 ? damage : (int)(damage * .8f));
                damage = random.Next(min, max);
                // If Target is defending, cut damage by half
                if (target.IsDefending && !equipment.IgnoreDefense && damage > 0)
                    damage /= 2;
                // Apply Combo Effect
                if (Global.Instance.Party.Heroes[0] == user)
                    ApplyDamageCombo(ref damage);
                // Apply Constant
                ApplyConstant(target, 0, -damage);
                // Apply Damage
                target.Damage = damage;
                // Return Damage
                return target.Damaged = (damage != 0);
            }
            return false;
        }
        #endregion

        #region Helper: Shared Methods
        /// <summary>
        /// Attack damage calculations
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public static bool StateEffect(IBattler target, StateEffect effect, StateData state)
        {
            // Reset Damaged
            target.Damaged = false;
            // Equipment Damage Type
            switch (effect.ValueType)
            {
                case ItemValueType.Constant:
                    return ApplyConstant(target, effect.Property, effect.Value);
                case ItemValueType.Percentage:
                    return ApplyPercentage(target, effect.Property, effect.Value);
            }
            return false;
        }
        /// <summary>
        /// Apply Damage Combo
        /// </summary>
        /// <param name="damage"></param>
        private static void ApplyDamageCombo(ref int damage)
        {
            foreach (ComboData combo in GameData.Combos.Values)
            {
                if (combo.StartCombo <= Global.Instance.HitCount && Global.Instance.HitCount <= combo.EndCombo)
                    if (combo.Effect == ComboEffect.DamageIncrease5Percent)
                        damage += (int)(damage * 0.05f);
            }
        }
        /// <summary>
        /// Apply Experience Combo
        /// </summary>
        /// <param name="exp"></param>
        public static void ApplyExpCombo(ref int exp)
        {
            foreach (ComboData combo in GameData.Combos.Values)
            {
                if (combo.StartCombo <= Global.Instance.HitCount && Global.Instance.HitCount <= combo.EndCombo)
                    if (combo.Effect == ComboEffect.ExperienceIncrease5Percent)
                        exp += (int)(exp * 0.05f);
            }
        }
        /// <summary>
        /// Element Modification
        /// </summary>
        /// <param name="target"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static float ElementModification(IBattler target, List<int> elements)
        {
            float[] mod = new float[] { 5, 4, 3, 2, 1, .8f, .5f, .3f, -4, -5 };
            List<float> values = new List<float>();
            float value;
            int _val;
            // Loop present elements
            for (int i = 0; i < elements.Count; i++)
            {
                if (target.Elements.TryGetValue(elements[i], out _val))
                {
                    value = mod[_val - 1];
                    // Include Defense Equipment
                    if (value > 1)
                    {
                        EquipmentData equipment = null;
                        foreach (KeyValuePair<int, int> slot in target.Equipments)
                        {
                            equipment = GameData.Equipments.GetData(slot.Value);
                            if (equipment != null && equipment.EquipType == EquipType.Defensive && equipment.Elements.Contains(elements[i]))
                                value /= 2;
                            if (value <= 1) break;
                        }
                    }
                    // Include states
                    foreach (StateProcessor state in target.States)
                    {
                        if (state.Data.Elements.Contains(elements[i]))
                            value = 0;
                    }


                    values.Add(value);
                }
            }
            // Get the maximum value
            value = (values.Count > 0 ? values.Max() : 1);
            return Math.Max(-80f, value);
        }
        /// <summary>
        /// Apply Percentage
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="property"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static bool ApplyPercentage(IBattler target, int property, int amount)
        {
            target.Damage = target.ApplyPercentageToProperty(property, amount);
            target.Damaged = true;
            return true;
        }
        /// <summary>
        /// Apply constant
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="property"></param>
        /// <param name="amount"></param>
        private static bool ApplyConstant(IBattler target, int property, int amount)
        {
            if (amount < 0 && target.Indestructible)
            {
                target.Damage = 0;
                target.Damaged = false;
                return false;
            }
            target.ApplyConstantToProperty(property, amount);
            target.Damage = -amount;
            target.Damaged = true;
            return true;
        }
        #endregion
    }
}
