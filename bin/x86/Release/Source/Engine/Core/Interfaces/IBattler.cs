//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace EGMGame.Interfaces
{
    public abstract class IBattler
    {
        public virtual int ID { get; set; }

        public virtual void Revive() { }

        public virtual bool IsDead() { return false; }

        public virtual Dictionary<int, int> Equipments { get; set; }

        public virtual List<StateProcessor> States { get; set; }

        public virtual bool IsDefending { get; set; }

        public virtual int[] Actions { get; set; }

        public virtual int AnimationID { get; set; }

        public virtual bool Damaged { get; set; }

        public virtual int Damage { get; set; }

        public virtual bool Indestructible { get; set; }

        public virtual int Strength { get { return 0; } }
        public virtual int Defense { get { return 0; } }
        public virtual int Agility { get { return 0; } }
        public virtual int MagicStr { get { return 0; } }
        public virtual int MagicDef { get { return 0; } }
        public virtual int Luck { get { return 0; } }
        public virtual bool Critical { get; set; }
        public virtual bool PreventCritical { get { return false; } }

        public virtual Dictionary<int, int> Elements { get { return default(Dictionary<int,int>); } }

        public virtual int GetEquipmentAction(EquipmentData equipment) { return 0; }

        public virtual EquipmentData GetOffensiveEquipment() { return default(EquipmentData); }

        public virtual ListData GetSkills() { return default(ListData); }

        public virtual ListData GetMagics() { return default(ListData); }

        public virtual int GetItemAction(ItemData item) { return 0; }

        public virtual int GetSkillAction(SkillData skill) { return 0; }

        public virtual bool CanUseSkill(SkillData skill) { return false; }

        public virtual void ApplyConstantToProperty(int property, int amount) { }

        public virtual int ApplyPercentageToProperty(int property, int amount) { return 0; }

        public virtual void SetupEquipmentAnimations(EventProcessor ev) { }

        public virtual int GetPropertyValue(int id) { return 0; }

        public virtual void Draw(GameTime gameTime) { }

        public virtual void Update(GameTime gameTime, EventProcessor eventProcessor) { }

        public virtual bool CanMove() { return false; }

        public virtual bool AttackAlly() { return false; }

        public virtual void InflictState(int id) { }

        public virtual void RemoveState(int id) { }

        public virtual void SkillCost(int cost, int id) { }

        public virtual bool CanSkillEffect(SkillData skill) { return false; }

        public virtual bool CanItemEffect(ItemData item) { return false; }
    }
}
