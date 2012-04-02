//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
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
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.DebugViews;
using EGMGame.GameLibrary;

namespace EGMGame.Processors
{
    public partial class EventProcessor : Interpreter
    {

        #region Field: Battle
        // Battle Conditions
        public EventProcessor Target;
        public List<EventProcessor> Targets;
        // Target Range in Current Frame
        public float TargetRange;
        // Battler
        public IBattler Battler;
        // Battle State
        public BattleState BattleState = BattleState.None;
        // Finish Attack Frames
        public int FinishAttackFrames;
        // Attack Frames, Enemy Respaw Counter, Cooldown Counter
        public int attackFrames, respawnTime, coolDown = 0;
        // Enemy Program index
        public int enemyProgramIndex = -1;
        // Combo Frame Counter
        public int HitFrameCounter = 60;
        #endregion

        private void SetupBattler(EnemyData _battler)
        {
            // Set enemy data
            if (_battler == null)
            {
                if (data.Pages[pageIndex].Enemy > -1)
                    Battler = new EnemyProcessor(data.Pages[pageIndex].Enemy);
            }
            // Setup Equipment Animations
            if (Battler != null)
            {
                Battler.SetupEquipmentAnimations(this);
            }
            // Enemy Program index
            enemyProgramIndex = -1;
            // Attack Frames 
            attackFrames = 0;
            // Respawn
            respawnTime = 0;
            BattleState = BattleState.None;
        }

        #region Method: Enemy AI
        /// <summary>
        /// Update Enemy
        /// </summary>
        private void UpdateEnemy(GameTime gameTime)
        {
            isBattlerMoving = false;
            // Return if there is an action taking place and must be completed
            if (actionTakingPlace != ActionType.None && waitActionCompelition && isProgramActive)
                return;
            // Check if any messages are active
            for (int i = 0; i < Global.Messages.Count; i++)
                if (Global.Messages[i].WaitOnClose)
                    return;
            // Check if any menus are active
            for (int i = 0; i < Global.Menus.Count; i++)
                if (Global.Menus[i].WaitOnClose)
                    return;
            if (coolDown <= 0 && attackFrames <= 0 && BattleState == BattleState.None)
            {
                // Battler dead, return
                if (Battler.IsDead())
                {
                    respawnTime += 1;

                    if (data.Pages[pageIndex].Respawn > 0 && data.Pages[pageIndex].Respawn < respawnTime)
                    {
                        Battler.Revive();
                        respawnTime = 0;
                        SetupBattler(((EnemyProcessor)Battler).Data);
                    }
                    return;
                }
                if (data.Pages[pageIndex].AttackCondition != AttackCondition.DoesntAttack)
                {
                    // Get Target
                    if (Target == null || Target.Battler == null || Target.Battler.IsDead() || TargetIsFar(out TargetRange))
                    {
                        // Erase target
                        Target = null;
                        // Look for target
                        int hearRange = data.Pages[pageIndex].HearRange;
                        int seeRange = data.Pages[pageIndex].SeeRange;
                        // Case the attack condition
                        switch (data.Pages[pageIndex].AttackCondition)
                        {
                            case AttackCondition.OnSeeOrHear:
                                Target = GetEnemyMovingTarget(hearRange, false);
                                if (Target == null)
                                    Target = GetEnemyTarget(seeRange, true);
                                break;
                            case AttackCondition.OnSee:
                                Target = GetEnemyTarget(seeRange, true);
                                break;
                            case AttackCondition.OnHear:
                                Target = GetEnemyTarget(hearRange, false);
                                break;
                            case AttackCondition.AllyAttacked:
                                break;
                        }
                    }
                    if (Target != null)
                    {
                        //TargetRange = RangeOf(Target);// (int)Vector2.Distance(OriginPosition, Target.OriginPosition);

                        // If Target is not null, get its precision range
                        //if (TargetRange < ConvertUnits.ToSimUnits(50) && TargetRange > ConvertUnits.ToSimUnits(10))
                        //    TargetRange = PrecisionRangeOf(Target);
                    }
                    else
                        attackFrames = Data.Pages[pageIndex].AttackSpeed;
                    if (attackFrames <= 0)
                    {
                        Battle.GetEnemyProgramIndex(out enemyProgramIndex, (EnemyProcessor)Battler);

                        // Check Attack Stack Index
                        if (enemyProgramIndex > -1 && enemyProgramIndex < ((EnemyProcessor)Battler).Data.Programs.Count)
                        {
                            // Reset Defense
                            Battler.IsDefending = false;
                            // Perform Action Type
                            switch (((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].ActionType)
                            {
                                case EnemyActionType.Basic:
                                    PerformEnemyBasic();
                                    break;
                                case EnemyActionType.Item:
                                    PerformEnemyItem();
                                    break;
                                case EnemyActionType.Magic:
                                    PerformEnemySkill(false);
                                    break;
                                case EnemyActionType.Skill:
                                    PerformEnemySkill(false);
                                    break;
                            }
                        }
                    }
                }
            }
            else if (FinishAttackFrames <= 0 && BattleState != BattleState.None)
            {
                EnemyFinishAttack();
                BattleState = BattleState.None;
            }
            else if (data.Pages[pageIndex].AttackCondition != AttackCondition.DoesntAttack && BattleState == BattleState.None && data.Pages[pageIndex].RushTarget && Target != null)
            {
                MoveEnemyTowardEvent(Target, null);
            }
            attackFrames--;
            coolDown--;
            FinishAttackFrames--;

        }
        /// <summary>
        /// Perform Basic
        /// </summary>
        private void PerformEnemyBasic()
        {
            switch (((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].Action)
            {
                case EnemyAction.Attack:
                    if (Target != null)
                    {
                        EquipmentData equipment;
                        equipment = ((EnemyProcessor)Battler).GetOffensiveEquipment((int)ConvertUnits.ToDisplayUnits(TargetRange));
                        // If Equipment is not null, then use equipment
                        if (equipment != null)
                        {
                            // Turn Toward Enemy
                            TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                            // If in line to use the equipment, use it
                            if (InLineOf(Target, 9999, true))
                            {
                                // Play Attack Animation
                                FinishAttackFrames = Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                                // Mash Time
                                coolDown = equipment.Mash + FinishAttackFrames;
                                BattleState = BattleState.Basic;
                                // Turn Toward Enemy
                                TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);

                                // Move Closer
                                if (data.Pages[pageIndex].RushTarget)
                                    MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                                return;
                            }
                        }
                        if (TargetRange > 0.01 || IsFacing(Target.Body, TargetRange))
                        {
                            // Move Closer
                            MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        }
                        else
                        {
                            TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        }
                    }
                    break;
                case EnemyAction.Defend:
                    Battler.IsDefending = true;
                    // Animate
                    AnimateStill(EventAction.Defend);
                    // Set attak frames
                    attackFrames = data.Pages[pageIndex].AttackSpeed;
                    break;
                case EnemyAction.Escape:
                    if (Target != null)
                    {
                        MoveAwayFromEvent(Target, data.Pages[pageIndex].BattleMoveDist, true, Data.Pages[pageIndex].BattleDirections);
                        // Set attak frames
                        attackFrames = data.Pages[pageIndex].AttackSpeed;
                    }
                    break;
                case EnemyAction.Wait:
                    // Set attak frames
                    attackFrames = data.Pages[pageIndex].AttackSpeed;
                    break;
            }
        }
        /// <summary>
        /// Perform Item
        /// </summary>
        private void PerformEnemyItem()
        {
            int itemId = ((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].Item;

            if (itemId > -1)
            {

                ItemData item = GameData.Items.GetData(id);

                if (item != null)
                {
                    if (item.Range < TargetRange && item.Scope == ItemScope.OneEnemy)
                    {
                        // Move Towards Target
                        if (TargetRange > 0.01)
                            MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        else
                            TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        return;
                    }
                    attackFrames = Data.Pages[pageIndex].AttackSpeed;
                    // Play Item Animation
                    FinishAttackFrames = Animate(EventAction.Item, Battler.GetItemAction(item));
                    coolDown = item.Speed + FinishAttackFrames;
                    int frames;
                    for (int index = 0; index < item.Effects.Count; index++)
                    {
                        if (item.Effects[index].Scope == EffectScope.User)
                        {
                            // Use on user
                            Battle.UseItem(Battler, Battler, item, index);
                            // Attack
                            frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), this);
                            // Battler's Hit Animation if target hit and damege > 0
                            if (Battler.Damaged)
                            {
                                // Display Damage - Add to screen text effects
                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                // Reset
                                Battler.Damaged = false;
                                Battler.Damage = 0;
                            }
                        }
                    }
                    BattleState = BattleState.Item;
                    // Turn Toward Enemy
                    TurnTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                }
            }
        }
        /// <summary>
        /// Perform Skill
        /// </summary>
        private void PerformEnemySkill(bool ignoreCost)
        {
            int skillId = ((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].Item;
            if (skillId > -1)
            {
                SkillData skill = GameData.Skills.GetData(skillId);

                if (skill != null && (ignoreCost || Battler.CanUseSkill(skill)))
                {
                    if (skill.Range < TargetRange && skill.Scope == ItemScope.OneEnemy)
                    {
                        // Move Towards Target
                        if (TargetRange > 0.01)
                            MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        else
                            TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        return;
                    }
                    attackFrames = Data.Pages[pageIndex].AttackSpeed;

                    int frames;
                    // Play Skill Animation
                    FinishAttackFrames = Animate((skill.SkillType == SkillType.Skill ? EventAction.Skill : EventAction.Magic), Battler.GetSkillAction(skill));
                    coolDown = skill.Speed + FinishAttackFrames;
                    // Skill Cost
                    if (!ignoreCost)
                        Battler.SkillCost(skill.Cost, skill.CostID);
                    for (int index = 0; index < skill.Effects.Count; index++)
                    {
                        // Check if effect scope is user
                        if (skill.Effects[index].Scope == EffectScope.User)
                        {
                            // Use on user
                            if (skill.Effects[index].Value > 0)
                                Battle.UseSkill(Battler, Battler, skill, index);
                            // Attack
                            frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                            // Player target's Hit Animation if target hit and damege > 0
                            if (Battler.Damaged)
                            {
                                // Display Damage - Add to screen text effects
                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                // Reset
                                Battler.Damaged = false;
                                Battler.Damage = 0;
                            }
                        }
                    }
                    BattleState = BattleState.Skill;
                    // Turn Toward Enemy
                    TurnTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                }
            }
        }
        /// <summary>
        /// Called to finish attack
        /// </summary>
        private void EnemyFinishAttack()
        {
            // Set Temp tempTarget
            EventProcessor tempTarget;
            int frames;

            switch (BattleState)
            {
                case BattleState.Basic:
                    #region Basic
                    tempTarget = GetEnemyTarget(((EnemyProcessor)Battler).LastEquipment.Range, true);

                    // If Projectile
                    if (((EnemyProcessor)Battler).LastEquipment.Projectile > -1)
                    {
                        if (tempTarget == null)
                            tempTarget = Target;
                        if (tempTarget != null)
                        {
                            // Turn Toward Enemy
                            TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);

                            // New Projectile
                            Global.CreateProjectile(this, tempTarget, ((EnemyProcessor)Battler).LastEquipment, this.Data.Pages[pageIndex].Hostiles);
                        }
                    }
                    else
                    {
                        if (tempTarget != null)
                        {
                            // Attack
                            attackFrames = Global.ShowAnimationOnEvent(((EnemyProcessor)Battler).LastEquipment.Animation, ((EnemyProcessor)Battler).LastEquipment.Action, Global.AngleToDirection(Angle), tempTarget);
                            // Calculate Damage
                            Battle.Attack(Battler, tempTarget.Battler, ((EnemyProcessor)Battler).LastEquipment);
                            // Display Damage - Add to screen text effects
                            Global.DisplayDamage(tempTarget.Battler.Damage, tempTarget.Battler.Damaged, tempTarget, attackFrames);
                            // Change Direction
                            if (tempTarget != Global.Instance.Player[0])
                            {
                                tempTarget.TurnTowardEvent(this, tempTarget.Data.Pages[tempTarget.pageIndex].BattleDirections);
                                tempTarget.Target = this;
                            }
                            // Player target's Hit Animation if target hit and damege > 0
                            if (tempTarget.Battler.Damaged)
                            {
                                // Animate hit animation
                                if (tempTarget.Battler.Damage > 0)
                                {
                                    tempTarget.Animate(EventAction.Hit);
                                    // Knockback
                                    tempTarget.Knocback(((EnemyProcessor)Battler).LastEquipment.Knockback, this.Position);
                                }
                                // Reset
                                tempTarget.Battler.Damaged = false;
                                tempTarget.Battler.Damage = 0;
                                // Check if target is dead
                                tempTarget.CheckDeath(this);
                            }
                        }
                    }
                    return;
                    #endregion
                case BattleState.Item:
                    #region Item
                    int itemId = ((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].Item;
                    ItemData item = GameData.Items.GetData(itemId);
                    tempTarget = GetEnemyTarget(item.Range, item.MustFaceTarget);
                    if (tempTarget != null)
                    {
                        for (int index = 0; index < item.Effects.Count; index++)
                        {
                            // Check if effect scope is user
                            if (item.Effects[index].Scope != EffectScope.User)
                            {
                                // Check Item Scope
                                switch (item.Scope)
                                {
                                    case ItemScope.User:
                                        // Use on user
                                        Battle.UseItem(Battler, Battler, item, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), this);

                                        Global.ShowParticleOnEvent(item.Effects[index].Particle, this);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                        Battler.Damaged = false;
                                        Battler.Damage = 0;
                                        break;
                                    case ItemScope.AllAllies:
                                        break;
                                    case ItemScope.OneAllyDead:
                                        break;
                                    case ItemScope.AllPartyDead:
                                        break;
                                    case ItemScope.OneEnemy:
                                        // Get Enemy in range
                                        if (tempTarget != null && (InLineOf(tempTarget, true) || !item.MustFaceTarget))
                                        {
                                            // Change Direction
                                            if (tempTarget != Global.Instance.Player[0])
                                            {
                                                tempTarget.TurnTowardEvent(this, tempTarget.Data.Pages[tempTarget.pageIndex].BattleDirections);
                                                tempTarget.Target = this;
                                            }
                                            // Use item on target
                                            Battle.UseItem(Battler, tempTarget.Battler, item, index);
                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), tempTarget);
                                            Global.ShowParticleOnEvent(item.Effects[index].Particle, tempTarget);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(tempTarget.Battler.Damage, tempTarget.Battler.Damaged, tempTarget, frames);
                                            // Battler's Hit Animation if target hit and damege > 0
                                            if (tempTarget.Battler.Damaged)
                                            {
                                                // Animate hit animation
                                                if (tempTarget.Battler.Damage > 0)
                                                {
                                                    tempTarget.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                tempTarget.Battler.Damaged = false;
                                                tempTarget.Battler.Damage = 0;
                                                // Check if target is dead
                                                tempTarget.CheckDeath(this);
                                            }
                                        }
                                        break;
                                    case ItemScope.AllEnemies:
                                        // Get Enemies in range
                                        List<EventProcessor> enemies = GetTargets(item.Range, item.MustFaceTarget);
                                        // Use item on enemies
                                        foreach (EventProcessor e in enemies)
                                        {
                                            if (RangeOf(e) > item.Range)
                                                continue;
                                            Battle.UseItem(Battler, e.Battler, item, index);
                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), e);

                                            Global.ShowParticleOnEvent(item.Effects[index].Particle, e);
                                            // Change Direction
                                            if (e != Global.Instance.Player[0])
                                            {
                                                e.TurnTowardEvent(this, e.Data.Pages[e.pageIndex].BattleDirections);
                                                e.Target = this;
                                            }
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(e.Battler.Damage, e.Battler.Damaged, e, frames);
                                            // Battler's Hit Animation if target hit and damege > 0
                                            if (e.Battler.Damaged)
                                            {
                                                // Animate hit animation
                                                if (e.Battler.Damage > 0)
                                                {
                                                    e.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                e.Battler.Damaged = false;
                                                e.Battler.Damage = 0;
                                                // Check if target is dead
                                                e.CheckDeath(this);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    return;
                    #endregion
                case BattleState.Skill:
                    #region Skill
                    int skillId = ((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].Item;
                    SkillData skill = GameData.Skills.GetData(skillId);
                    tempTarget = GetEnemyTarget(skill.Range, skill.MustFaceTarget);

                    if (skill.Projectile > -1)
                    {
                        Global.CreateProjectile(this, tempTarget, skill, this.Data.Pages[pageIndex].Hostiles); return;
                    }
                    for (int index = 0; index < skill.Effects.Count; index++)
                    {
                        // Check if effect scope is user
                        if (skill.Effects[index].Scope != EffectScope.User)
                        {
                            // Check Skill Scope
                            switch (skill.Scope)
                            {
                                case ItemScope.User:
                                    // Use on user
                                    if (skill.Effects[index].Value > 0)
                                        Battle.UseSkill(Battler, Battler, skill, index);

                                    // Attack
                                    frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);

                                    Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                    break;
                                case ItemScope.AllAllies:
                                    break;
                                case ItemScope.OneAllyDead:
                                    break;
                                case ItemScope.AllPartyDead:
                                    break;
                                case ItemScope.OneEnemy:
                                    // Get Enemy in range
                                    if (tempTarget != null && (InLineOf(tempTarget, true) || !skill.MustFaceTarget))
                                    {
                                        // Change Direction
                                        if (tempTarget != Global.Instance.Player[0])
                                        {
                                            tempTarget.TurnTowardEvent(this, tempTarget.Data.Pages[tempTarget.pageIndex].BattleDirections);
                                            tempTarget.Target = this;
                                        }
                                        // Use skill on tempTarget
                                        Battle.UseSkill(Battler, tempTarget.Battler, skill, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), tempTarget);

                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, tempTarget);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(tempTarget.Battler.Damage, tempTarget.Battler.Damaged, tempTarget, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (tempTarget.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (tempTarget.Battler.Damage > 0)
                                            {
                                                tempTarget.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            tempTarget.Battler.Damaged = false;
                                            tempTarget.Battler.Damage = 0;
                                            // Check if target is dead
                                            tempTarget.CheckDeath(this);
                                        }
                                    }
                                    break;
                                case ItemScope.AllEnemies:
                                    // Get Enemies in range
                                    List<EventProcessor> enemies = GetTargetsForPlayer(skill.Range, skill.MustFaceTarget);
                                    // Use skill on enemies
                                    foreach (EventProcessor e in enemies)
                                    {
                                        if (RangeOf(e) > skill.Range)
                                            continue;
                                        Battle.UseSkill(Battler, e.Battler, skill, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), e);

                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, e);
                                        // Change Direction
                                        if (e != Global.Instance.Player[0])
                                        {
                                            e.TurnTowardEvent(this, e.Data.Pages[e.pageIndex].BattleDirections);
                                            e.Target = this;
                                        }
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(e.Battler.Damage, e.Battler.Damaged, e, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (e.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (e.Battler.Damage > 0)
                                            {
                                                e.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            e.Battler.Damaged = false;
                                            e.Battler.Damage = 0;
                                            // Check if target is dead
                                            e.CheckDeath(this);
                                        }
                                    }
                                    break;
                                case ItemScope.None:
                                    return;
                            }
                        }
                    }
                    return;
                    #endregion
            }

            if (Target != null)
            {
                if (RangeOf(Target) > 1)
                {
                    // Move Closer
                    MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections); ;
                }
                else
                {
                    TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                }
            }
        }
        /// <summary>
        /// Get Target
        /// </summary>
        /// <returns></returns>
        private EventProcessor GetEnemyTarget(int dist, bool mustFace)
        {
            if (Body != null)
            {
                DebugViewXNA.RecordRay = true;
                if (data.Pages[pageIndex].Hostiles.Count == 1 && data.Pages[pageIndex].Hostiles[0] == -1 && !Battler.AttackAlly())
                {
                    Vector2 newdist = Animation.CollisionCentroid;
                    newdist.X += dist;
                    newdist.Y += dist;
                    newdist = ConvertUnits.ToSimUnits(newdist);
                    int currentDistance = 0;
                    int closestDistance = 0;
                    EventProcessor closestEvent = null;
                    List<Vector2> collisionList = new List<Vector2>();
                    EventProcessor ev;
                    if (!mustFace)
                    {
                        Vector2 targetAngle;

                        for (int i = 0; i < Global.Instance.Player.Count; i++)
                        {
                            // Check if a battler
                            ev = Global.Instance.Player[i];
                            if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                            {
                                targetAngle = (ev.Body.Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                                if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), ev.Body, ref newdist))
                                {
                                    Vector2 local = Body.Position;
                                    currentDistance = (int)ev.Body.GetDistance(Body);
                                    if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                    {
                                        closestEvent = ev;
                                        closestDistance = currentDistance;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Global.Instance.Player.Count; i++)
                        {
                            // Check if a battler
                            ev = Global.Instance.Player[i];
                            if (ev != null && ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                            {
                                if (Collide(ev.Body, ref newdist))
                                {
                                    Vector2 local = Body.Position;
                                    currentDistance = (int)ev.Body.GetDistance(Body);
                                    if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                    {
                                        closestEvent = ev;
                                        closestDistance = currentDistance;
                                    }
                                }
                            }
                        }
                    }
                    return closestEvent;
                }
                else
                    return GetTarget(dist, mustFace);
            }
            return null;
        }
        /// <summary>
        /// Get Target
        /// </summary>
        /// <returns></returns>
        private EventProcessor GetEnemyMovingTarget(int dist, bool mustFace)
        {
            if (Body != null && data.Pages[pageIndex].Hostiles.Count == 1 && data.Pages[pageIndex].Hostiles[0] == -1 && !Battler.AttackAlly())
            {
                Vector2 newdist = Animation.CollisionCentroid;
                newdist.X += dist;
                newdist.Y += dist;
                newdist = ConvertUnits.ToSimUnits(newdist);
                EventProcessor closestEvent = null;
                int currentDistance = 0;
                int closestDistance = 0;
                List<Vector2> collisionList = new List<Vector2>();
                EventProcessor ev;
                if (!mustFace)
                {
                    Vector2 targetAngle;

                    for (int i = 0; i < Global.Instance.Player.Count; i++)
                    {
                        ev = Global.Instance.Player[i];
                        // Check if a battler
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null && ev.IsMoving)
                        {
                            targetAngle = (ev.Body.Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                            if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), ev.Body, ref newdist))
                            {
                                Vector2 local = Body.Position;
                                currentDistance = (int)ev.Body.GetDistance(Body);
                                if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                {
                                    closestEvent = ev;
                                    closestDistance = currentDistance;
                                }
                            }
                        }
                    }
                }
                return closestEvent;
            }
            else
                return GetMovingTarget(dist, mustFace);
        }
        /// <summary>
        /// Get Target
        /// </summary>
        /// <returns></returns>
        private EventProcessor GetMovingTarget(int dist, bool mustFace)
        {
            EventProcessor closestEvent = null;
            if (Body != null)
            {
                Vector2 newdist = Animation.CollisionCentroid;
                newdist.X += dist; newdist.Y += dist;
                newdist = ConvertUnits.ToSimUnits(newdist);
                int currentDistance = 0;
                int closestDistance = 0;
                List<Vector2> collisionList = new List<Vector2>();
                //dist = 30;
                int tempBodyCount = Global.World.BodyList.Count;
                EventProcessor ev;
                if (!mustFace)
                {
                    Vector2 targetAngle;
                    // Loop All Bodys Once
                    for (int i = 0; i < tempBodyCount; i++)
                    {
                        if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                        {
                            // Check if a battler
                            ev = Global.World.BodyList[i].UserData as EventProcessor;
                            if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null && ev.Body.Moves)
                            {
                                if (!ev.IsPlayer)
                                {
                                    if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID))
                                        continue;
                                }
                                else if (!data.Pages[pageIndex].Hostiles.Contains(-1))
                                    continue;

                                targetAngle = (Global.World.BodyList[i].Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                                if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), Global.World.BodyList[i], ref newdist))
                                {
                                    Vector2 local = Body.Position;
                                    currentDistance = (int)ev.Body.GetDistance(Body);
                                    if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                    {
                                        closestEvent = ev;
                                        closestDistance = currentDistance;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Loop All Bodys Once
                    for (int i = 0; i < tempBodyCount; i++)
                    {
                        if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                        {
                            // Check if a battler
                            ev = Global.World.BodyList[i].UserData as EventProcessor;
                            if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null && ev.Body.Moves)
                            {
                                if (!ev.IsPlayer)
                                {
                                    if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID))
                                        continue;
                                }
                                else if (!data.Pages[pageIndex].Hostiles.Contains(-1))
                                    continue;
                                if ((!mustFace && Collide(Global.World.BodyList[i], ref newdist)) || Collide(Angle, Global.World.BodyList[i], ref newdist))
                                {
                                    Vector2 local = Body.Position;
                                    currentDistance = (int)ev.Body.GetDistance(Body);
                                    if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                    {
                                        if (CheckForObstacles(ev, closestDistance))
                                        {
                                            closestEvent = ev;
                                            closestDistance = currentDistance;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return closestEvent;
        }
        /// <summary>
        /// Get Target
        /// </summary>
        /// <returns></returns>
        private EventProcessor GetTarget(int dist, bool mustFace)
        {
            Vector2 newdist = Animation.CollisionCentroid;
            newdist.X += dist; newdist.Y += dist;
            newdist = ConvertUnits.ToSimUnits(newdist);
            EventProcessor closestEvent = null;
            int currentDistance = 0;
            int closestDistance = 0;
            List<Vector2> collisionList = new List<Vector2>();
            //dist = 30;
            int tempFixtureCount = Global.World.BodyList.Count;
            EventProcessor ev;
            if (!mustFace)
            {
                Vector2 targetAngle;
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                            {
                                if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID) && !Battler.AttackAlly())
                                    continue;
                            }
                            else if (!data.Pages[pageIndex].Hostiles.Contains(-1) && !Battler.AttackAlly())
                                continue;

                            targetAngle = (Global.World.BodyList[i].Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                            if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), Global.World.BodyList[i], ref newdist))
                            {
                                Vector2 local = Body.Position;
                                currentDistance = (int)ev.Body.GetDistance(Body);
                                if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                {
                                    closestEvent = ev;
                                    closestDistance = currentDistance;
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                            {
                                if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID) && !Battler.AttackAlly())
                                    continue;
                            }
                            else if (!data.Pages[pageIndex].Hostiles.Contains(-1) && !Battler.AttackAlly())
                                continue;
                            if ((!mustFace && Collide(Global.World.BodyList[i], ref newdist)) || Collide(Angle, Global.World.BodyList[i], ref newdist))
                            {
                                Vector2 local = Body.Position;
                                currentDistance = (int)ev.Body.GetDistance(Body);
                                if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                {
                                    if (CheckForObstacles(ev, closestDistance))
                                    {
                                        closestEvent = ev;
                                        closestDistance = currentDistance;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return closestEvent;
        }
        /// <summary>
        /// Get Targets
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal List<EventProcessor> GetTargets(int dist, bool mustFace)
        {
            List<EventProcessor> closestEvents = new List<EventProcessor>();
            List<Vector2> collisionList = new List<Vector2>();
            //dist = 30;
            int tempFixtureCount = Global.World.BodyList.Count;
            EventProcessor ev;
            Vector2 newdist = Animation.CollisionCentroid;
            newdist.X += dist; newdist.Y += dist;
            newdist = ConvertUnits.ToSimUnits(newdist);

            if (!mustFace)
            {
                Vector2 targetAngle;
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                            {
                                if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID) && !Battler.AttackAlly())
                                    continue;
                            }
                            else if (!data.Pages[pageIndex].Hostiles.Contains(-1) && !Battler.AttackAlly())
                                continue;

                            targetAngle = (Global.World.BodyList[i].Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                            if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), Global.World.BodyList[i], ref newdist))
                            {
                                if (CheckForObstacles(ev, newdist))
                                {
                                    closestEvents.Add(ev);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                            {
                                if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID) && !Battler.AttackAlly())
                                    continue;
                            }
                            else if (!data.Pages[pageIndex].Hostiles.Contains(-1) && !Battler.AttackAlly())
                                continue;
                            if ((!mustFace && Collide(Global.World.BodyList[i], ref newdist)) || Collide(Angle, Global.World.BodyList[i], ref newdist))
                            {
                                if (CheckForObstacles(ev, newdist))
                                {
                                    closestEvents.Add(ev);
                                }
                            }
                        }
                    }
                }
            }
            return closestEvents;
        }
        /// <summary>
        /// Get Targets
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="mustFace"></param>
        /// <param name="_angle"></param>
        /// <returns></returns>
        internal List<EventProcessor> GetTargets(int dist, bool mustFace, int _angle)
        {
            List<EventProcessor> closestEvents = new List<EventProcessor>();
            List<Vector2> collisionList = new List<Vector2>();
            //dist = 30;
            int tempFixtureCount = Global.World.BodyList.Count;
            EventProcessor ev;
            Vector2 newdist = Animation.CollisionCentroid;
            newdist.X += dist; newdist.Y += dist;
            newdist = ConvertUnits.ToSimUnits(newdist);

            if (!mustFace)
            {
                Vector2 targetAngle;
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                            {
                                if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID) && !Battler.AttackAlly())
                                    continue;
                            }
                            else if (!data.Pages[pageIndex].Hostiles.Contains(-1) && !Battler.AttackAlly())
                                continue;

                            targetAngle = (Global.World.BodyList[i].Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                            if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), Global.World.BodyList[i], ref newdist))
                            {
                                if (CheckForObstacles(ev, newdist))
                                {
                                    closestEvents.Add(ev);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                            {
                                if (!data.Pages[pageIndex].Hostiles.Contains(ev.Battler.ID))
                                    continue;
                            }
                            else if (!data.Pages[pageIndex].Hostiles.Contains(-1))
                                continue;
                            if (IsFacing(Global.World.BodyList[i].Position, _angle) && Collide(Global.World.BodyList[i], ref newdist))
                            {
                                if (CheckForObstacles(ev, newdist))
                                {
                                    closestEvents.Add(ev);
                                }
                            }
                        }
                    }
                }
            }
            return closestEvents;
        }
        /// <summary>
        /// Returns the precision range between obj and this.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private float PrecisionRangeOf(EventProcessor obj)
        {
            if (obj.Body != null)
                return Body.GetDistance(obj.Body);
            return Vector2.Distance(OriginPosition, obj.OriginPosition);
        }
        /// <summary>
        /// Checks if the given object is in range of this.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool InRangeOf(EventProcessor obj, int range)
        {
            return range >= RangeOf(obj);
        }
        /// <summary>
        /// Checks if the given object is in range of this.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool InRangeOf(EventProcessor obj, int range, bool mustfaceTarget)
        {
            float r = RangeOf(obj);
            if (!mustfaceTarget)
                return ConvertUnits.ToSimUnits(range) >= r;
            else
                return ConvertUnits.ToSimUnits(range) >= r && IsFacing(obj.Body, r);
        }
        /// <summary>
        /// Checks if the given object is in range of this.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool InRangeOf(EventProcessor obj, int range, bool mustfaceTarget, out float cRange)
        {
            cRange = RangeOf(obj);
            if (!mustfaceTarget)
                return ConvertUnits.ToSimUnits(range) >= cRange;
            else
                return ConvertUnits.ToSimUnits(range) >= cRange && IsFacing(obj.Body, cRange);
        }
        /// <summary>
        /// Checks if the target is inline
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool InLineOf(EventProcessor target, bool mustFace)
        {
            float dist = ConvertUnits.ToSimUnits(99999);//RangeOf(target) * 2;
            return InLineOf(target, dist, mustFace);
        }
        /// <summary>
        /// Checks if the target is inline
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool InLineOf(EventProcessor target, float dist, bool mustFace)
        {
            if (dist < ConvertUnits.ToSimUnits(2)) dist = ConvertUnits.ToSimUnits(10);
            List<Vector2> collisionList = new List<Vector2>();
            Vector2 newDist = ConvertUnits.ToSimUnits(Animation.CollisionCentroid);
            newDist.X += dist + ConvertUnits.ToSimUnits(16);
            newDist.Y += dist + ConvertUnits.ToSimUnits(16);
            Vector2 endPoint = new Vector2();
            endPoint.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(Angle)), 2) * newDist.X;
            endPoint.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(Angle)), 2) * newDist.Y;
            bool w = false;
            if (target.BattleBody != null) w = target.BattleBody.RayCast(Body.Position, Body.Position + endPoint);
            if (target.Body != null) w = target.Body.RayCast(Body.Position, Body.Position + endPoint);
            bool r = !mustFace || IsFacing(target.Body, (int)dist);
            return (r) && (w);
        }
        /// <summary>
        /// Check Alignment
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool CheckAlignment(EventProcessor target)
        {

            return true;
        }
        /// <summary>
        /// Move Enemy Toward Event
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="directions"></param>
        private void MoveEnemyTowardEvent(EventProcessor target, List<int> directions)
        {
            if (!Battler.CanMove()) return;
            // Turn Toward Event
            TurnEnemyTowardEvent(target, null);
            // Calculate target To Move
            ApplyForce(Angle, Force, true);
            // 
            isBattlerMoving = true;
        }
        /// <summary>
        /// Turn Toward Event
        /// </summary>
        /// <param name="closestEvent"></param>
        /// <param name="directions"></param>
        public void TurnEnemyTowardEvent(EventProcessor ev, List<int> directions)
        {
            if (!DirectionFix)
            {
                Vector2 targetAngle;
                if (ev.IsMoving)
                { targetAngle = (ev.NextPosition - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle); }
                else
                    targetAngle = (ev.OriginPosition - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
                // Calculate target To Move
                SetAngle((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), true);

                Animation.ApplyAngleToDirection(Angle);
            }
        }
        #endregion

        #region Method: Player AI
        /// <summary>
        /// Update Battle Controls
        /// </summary>
        private void UpdateBattleControls()
        {
            // Hit Counter
            if (HitFrameCounter > 0)
                HitFrameCounter--;
            else
                Global.Instance.HitCount = 0;
            if (coolDown <= 0 && BattleState == BattleState.None)
            {
                PlayerData player = (PlayerData)data;
                // Defend
                if ((player.Buttons["Defend"] > 0 && InputState.IsButtonPress(InputState.ButtonsList[player.Buttons["Defend"] - 1], 0) || (player.Keys["Defend"] > 0 && InputState.IsKeyPress(InputState.KeysList[player.Keys["Defend"] - 1], 0))))
                {
                    Battler.IsDefending = true;
                    AllowMovement = false;
                    // If the key is new, show animation, if not, do not show animation
                    if (ActionIndex != EventAction.Defend && InputState.IsNewButtonPress(InputState.ButtonsList[player.Buttons["Defend"]], 0) || InputState.IsNewKeyPress(InputState.KeysList[player.Keys["Defend"]], 0))
                    {
                        AnimateStill(EventAction.Defend);
                    }
                }
                else
                {
                    if (Battler.IsDefending)
                    {
                        AllowMovement = true;
                        Battler.IsDefending = false;
                        Animate(EventAction.Idle);
                    }
                }
                if (Battler.IsDefending)
                    return;
                // Attack
                bool attack = false;
                if (player.AttackPress == 0) // New Press
                {
                    if (player.Keys["Attack"] > 0)
                        attack = InputState.IsNewKeyPress(InputState.KeysList[player.Keys["Attack"] - 1], 0);
                    if (!attack && player.Buttons["Attack"] > 0)
                        attack = InputState.IsNewButtonPress(InputState.ButtonsList[player.Buttons["Attack"] - 1], 0);
                }
                else // Press
                {
                    if (player.Keys["Attack"] > 0)
                        attack = InputState.IsKeyPress(InputState.KeysList[player.Keys["Attack"] - 1], 0);
                    if (!attack && player.Buttons["Attack"] > 0)
                        attack = InputState.IsButtonPress(InputState.ButtonsList[player.Buttons["Attack"] - 1], 0);
                }
                if (attack)
                {
                    if (!Animation.IsAnimating || (Animation.IsAnimating && Animation.ActionIndex != EventAction.Attack))
                    {
                        // Process Attack
                        ProcessPlayerAttack();
                    }
                }
                // Skill Hotkeys
                if (!Animation.IsAnimating || (Animation.IsAnimating && Animation.ActionIndex != EventAction.Skill))
                {
                    foreach (Hotkey hotkey in Global.Instance.SkillKeys)
                    {
                        if (hotkey.Key1 > -1 && InputState.IsKeyPress(InputState.KeysList[hotkey.Key1], 0))
                        {
                            if (hotkey.Key2 > -1)
                            {
                                if (InputState.IsKeyPress(InputState.KeysList[hotkey.Key2], 0))
                                {
                                    ProcessPlayerSkill(hotkey.DefaultID, false); return;
                                }
                            }
                            else
                            {
                                ProcessPlayerSkill(hotkey.DefaultID, false);
                                return;
                            }
                        }
                        else if (hotkey.Button1 > -1 && InputState.IsButtonPress(InputState.ButtonsList[hotkey.Button1], 0))
                        {
                            if (hotkey.Button2 > -1)
                            {
                                if (InputState.IsButtonPress(InputState.ButtonsList[hotkey.Button2], 0))
                                {
                                    ProcessPlayerSkill(hotkey.DefaultID, false); return;
                                }
                            }
                            else
                            {
                                ProcessPlayerSkill(hotkey.DefaultID, false);
                                return;
                            }
                        }
                    }
                }

                if (!Animation.IsAnimating || (Animation.IsAnimating && Animation.ActionIndex != EventAction.Item))
                {
                    // Item Hotkeys
                    foreach (Hotkey hotkey in Global.Instance.ItemKeys)
                    {
                        if (hotkey.Key1 > -1 && InputState.IsKeyPress(InputState.KeysList[hotkey.Key1], 0))
                        {
                            if (hotkey.Key2 > -1)
                            {
                                if (InputState.IsKeyPress(InputState.KeysList[hotkey.Key2], 0))
                                {
                                    ProcessPlayerItem(hotkey.DefaultID, false); return;
                                }
                            }
                            else
                            {
                                ProcessPlayerItem(hotkey.DefaultID, false);
                                return;
                            }
                        }
                        else if (hotkey.Button1 > -1 && InputState.IsButtonPress(InputState.ButtonsList[hotkey.Button1], 0))
                        {
                            if (hotkey.Button2 > -1)
                            {
                                if (InputState.IsButtonPress(InputState.ButtonsList[hotkey.Button2], 0))
                                {
                                    ProcessPlayerItem(hotkey.DefaultID, false); return;
                                }
                            }
                            else
                            {
                                ProcessPlayerItem(hotkey.DefaultID, false); return;
                            }
                        }
                    }
                }
            }
            else if (FinishAttackFrames <= 0 && BattleState != BattleState.None)
            {
                FinishPlayerAttack();
                BattleState = BattleState.None;
            }
            coolDown--;
            FinishAttackFrames--;
        }
        /// <summary>
        /// Process Player Item
        /// </summary>
        /// <param name="p"></param>
        private void ProcessPlayerItem(int itemId, bool ignoreInventory)
        {
            if (itemId > -1)
            {
                // Check if battler has item
                if (((HeroProcessor)Battler).CanUseItem(itemId) && ((HeroProcessor)Battler).HasItem(itemId) || ignoreInventory)
                {
                    ItemData item = GameData.Items.GetData(id);

                    if (item != null)
                    {
                        int frames;
                        ((HeroProcessor)Battler).LastItem = item;
                        // Play Item Animation
                        FinishAttackFrames = Animate(EventAction.Item, Battler.GetItemAction(item));

                        coolDown = item.Speed + FinishAttackFrames;
                        BattleState = BattleState.Item;
                        for (int index = 0; index < item.Effects.Count; index++)
                        {
                            // Check if effect scope is user
                            if (item.Effects[index].Scope == EffectScope.User)
                            {
                                // Use on user
                                Battle.UseItem(Battler, Battler, item, index);

                                // Attack
                                frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                // Player target's Hit Animation if target hit and damege > 0
                                if (Battler.Damaged)
                                {
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                }
                            }
                        }

                        // If Items is used, remove it from list if possible
                        if (item.Consumable && !ignoreInventory)
                        {
                            ((HeroProcessor)Battler).RemoveItem(itemId);
                        }
                        BattleState = BattleState.Item;
                    }
                }
                else
                {
                    // Item Doesn't Exist

                }
            }
        }
        /// <summary>
        /// Process Player Item
        /// </summary>
        private void ProcessPlayerSkill(int skillId, bool ignoreCost)
        {
            if (skillId > -1)
            {
                SkillData skill = GameData.Skills.GetData(skillId);
                ListData skills;

                if (skill.SkillType == SkillType.Skill)
                    skills = Battler.GetSkills();
                else
                    skills = Battler.GetMagics();
                // Check if battler has skill
                if (skills.Values.Contains(skillId))
                {
                    if ((ignoreCost || Battler.CanUseSkill(skill)))
                    {
                        int frames;
                        ((HeroProcessor)Battler).LastSkill = skill;
                        // Skill Cost
                        if (!ignoreCost)
                            Battler.SkillCost(skill.Cost, skill.CostID);
                        // Play Skill Animation
                        FinishAttackFrames = Animate((skill.SkillType == SkillType.Skill ? EventAction.Skill : EventAction.Magic), Battler.GetSkillAction(skill));

                        coolDown = skill.Speed + FinishAttackFrames;
                        for (int index = 0; index < skill.Effects.Count; index++)
                        {
                            // Check if effect scope is user
                            if (skill.Effects[index].Scope == EffectScope.User)
                            {
                                // Use on use
                                if (skill.Effects[index].Value > 0) Battle.UseSkill(Battler, Battler, skill, index);
                                // Attack
                                frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                // Player target's Hit Animation if target hit and damege > 0
                                if (Battler.Damaged)
                                {
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Animate hit animation
                                    if (Battler.Damage > 0)
                                        this.Animate(EventAction.Hit);
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                }
                            }
                        }
                        BattleState = BattleState.Skill;
                    }
                }
            }
        }
        /// <summary>
        /// Process Player Attack
        /// </summary>
        private void ProcessPlayerAttack()
        {
            EquipmentData equipment;
        GetEquipment:
            equipment = Battler.GetOffensiveEquipment();
            if (equipment != null)
            {
                // Check if ammo is required
                if (equipment.AmmoID > -1)
                {
                    // Check if ammo exists
                    if (((HeroProcessor)Battler).HasItem(equipment.AmmoID))
                    {
                        ((HeroProcessor)Battler).RemoveItem(equipment.AmmoID);
                    }
                    else
                        goto GetEquipment;
                }
                // Play Attack Animation
                FinishAttackFrames = Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                // Mash Time
                coolDown = equipment.Mash + FinishAttackFrames;
                BattleState = BattleState.Basic;
            }
            else
            {
                // Play Attack Animation
                FinishAttackFrames = Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                // Mashtime
                coolDown = Animation.GetDisplayTime();
            }
        }
        /// <summary>
        /// Player Attack
        /// </summary>
        private void FinishPlayerAttack()
        {
            EquipmentData equipment;
            ItemData item;
            SkillData skill;
            int frames;
            bool used = false;
            switch (BattleState)
            {
                case BattleState.Basic:
                    #region Basic
                    equipment = ((HeroProcessor)Battler).LastEquipment;
                    if (equipment != null)
                    {
                        // If Projectile
                        if (equipment.Projectile > -1)
                        {
                            // New Projectile
                            Global.CreateProjectile(this, Target, equipment, this.Data.Pages[pageIndex].Hostiles);
                        }
                        else
                        {
                            // Non Projectile
                            Target = GetTargetForPlayer(equipment.Range, true);
                            // If there is a target
                            if (Target != null)
                            {
                                // Attack
                                frames = Global.ShowAnimationOnEvent(equipment.Animation, equipment.Action, Global.AngleToDirection(Angle), Target);
                                // Calculate Damage
                                Battle.Attack(Battler, Target.Battler, equipment);
                                // Display Damage - Add to screen text effects
                                Global.DisplayDamage(Target.Battler.Damage, Target.Battler.Damaged, Target, frames);
                                // Change Direction
                                if (Target != Global.Instance.Player[0])
                                {
                                    Target.TurnTowardEvent(this, Target.Data.Pages[Target.pageIndex].BattleDirections);
                                    Target.Target = this;
                                }
                                // Player target's Hit Animation if target hit and damege > 0
                                if (Target.Battler.Damaged)
                                {
                                    // Increase Combo if combo counter is not zero
                                    if (HitFrameCounter > 0)
                                        Global.Instance.HitCount++;
                                    else
                                    {
                                        HitFrameCounter = 60;
                                        Global.Instance.HitCount = 0;
                                    }
                                    // Animate hit animation
                                    if (Target.Battler.Damage > 0)
                                    {
                                        Target.Animate(EventAction.Hit);
                                        // Knockback
                                        Target.Knocback(equipment.Knockback, this.Position);
                                    }
                                    // Reset
                                    Target.Battler.Damaged = false;
                                    Target.Battler.Damage = 0;
                                    // Check if target is dead
                                    Target.CheckDeath(this);
                                }
                                // Player 
                                if (Battler.Damaged)
                                {
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Animate hit animation
                                    if (Battler.Damage > 0)
                                    {
                                        Animate(EventAction.Hit);
                                        // Knockback
                                        Knocback(equipment.Knockback, this.Position);
                                    }
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                }
                            }
                        }
                    }
                    // If did not attack with an offensive weapon, don't use weapon
                    else
                    {
                        // Get Closest Enemy
                        Target = GetTargetForPlayer(0, true);
                        // Play Attack Animation
                        Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                        // Mashtime
                        coolDown = Animation.GetDisplayTime();
                        // If there is a target
                        if (Target != null)
                        {
                            // Calculate Damage
                            Battle.Attack(Battler, Target.Battler, equipment);
                            // Display Damage - Add to screen text effects
                            Global.DisplayDamage(Target.Battler.Damage, Target.Battler.Damaged, Target, 0);
                            // Change Direction
                            if (Target != Global.Instance.Player[0])
                            {
                                Target.TurnTowardEvent(this, Target.Data.Pages[Target.pageIndex].BattleDirections);
                                Target.Target = this;
                            }
                            // Player target's Hit Animation if target hit and damege > 0
                            if (Target.Battler.Damaged)
                            {
                                // Animate hit animation
                                if (Target.Battler.Damage > 0)
                                {
                                    Target.Animate(EventAction.Hit);
                                }
                                // Reset
                                Target.Battler.Damaged = false;
                                Target.Battler.Damage = 0;
                                // Check if target is dead
                                Target.CheckDeath(this);
                            }
                            // Player 
                            if (Battler.Damaged)
                            {
                                // Display Damage - Add to screen text effects
                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, 0);
                                // Animate hit animation
                                if (Battler.Damage > 0)
                                {
                                    Animate(EventAction.Hit);
                                }
                                // Reset
                                Battler.Damaged = false;
                                Battler.Damage = 0;
                            }
                        }
                    }
                    return;
                    #endregion
                case BattleState.Item:
                    #region Item
                    item = ((HeroProcessor)Battler).LastItem;
                    for (int index = 0; index < item.Effects.Count; index++)
                    {
                        // Check if effect scope is user
                        if (item.Effects[index].Scope != EffectScope.User)
                        {
                            // Check Item Scope
                            switch (item.Scope)
                            {
                                case ItemScope.User:
                                    // Use on user
                                    used = Battle.UseItem(Battler, Battler, item, index);
                                    // Attack
                                    frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                    // Show Particles
                                    Global.ShowParticleOnEvent(item.Effects[index].Particle, this);

                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                    break;
                                case ItemScope.OneHero:
                                    EventProcessor closestEv;
                                    HeroProcessor closest;
                                    GetClosestAlly(item.Range, item, out closest, out closestEv);
                                    if (closest == null)
                                    {
                                        closest = (HeroProcessor)Battler;
                                        closestEv = this;
                                    }
                                    if (closest != null)
                                    {
                                        // Use on user
                                        used = Battle.UseItem(Battler, closest, item, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), closestEv);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(item.Effects[index].Particle, closestEv);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(closest.Damage, closest.Damaged, closestEv, frames);
                                        // Reset
                                        closest.Damaged = false;
                                        closest.Damage = 0;
                                    }
                                    break;
                                case ItemScope.AllAllies:
                                    // Use on party
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.CanItemEffect(item) && InRangeOf(Global.Instance.Party.GetPartyMember(target.ID), item.Range, item.MustFaceTarget))
                                        {
                                            used = Battle.UseItem(Battler, target, item, index);
                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(item.Effects[index].Particle, this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                        }
                                    }
                                    break;
                                case ItemScope.OneAllyDead:
                                    // Find a dead ally 
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.IsDead() && target.CanItemEffect(item) && InRangeOf(Global.Instance.Party.GetPartyMember(target.ID), item.Range, item.MustFaceTarget))
                                        {
                                            used = Battle.UseItem(Battler, target, item, index);

                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(item.Effects[index].Particle, this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                case ItemScope.AllPartyDead:
                                    // Use on party
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.IsDead() && target.CanItemEffect(item) && InRangeOf(Global.Instance.Party.GetPartyMember(target.ID), item.Range, item.MustFaceTarget))
                                        {
                                            used = Battle.UseItem(Battler, target, item, index);

                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(item.Effects[index].Particle, this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                        }
                                    }
                                    break;
                                case ItemScope.OneEnemy:
                                    // Get Enemy in range
                                    EventProcessor enemy = GetTargetForPlayer(item.Range, item.MustFaceTarget);

                                    if (enemy != null)
                                    {
                                        // Change Direction
                                        if (enemy != Global.Instance.Player[0])
                                        {
                                            enemy.TurnTowardEvent(this, enemy.Data.Pages[enemy.pageIndex].BattleDirections);
                                            enemy.Target = this;
                                        }
                                        // Use item on enemy
                                        used = Battle.UseItem(Battler, enemy.Battler, item, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), enemy);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(item.Effects[index].Particle, enemy);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(enemy.Battler.Damage, enemy.Battler.Damaged, enemy, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (enemy.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (enemy.Battler.Damage > 0)
                                            {
                                                enemy.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            enemy.Battler.Damaged = false;
                                            enemy.Battler.Damage = 0;
                                            // Check if target is dead
                                            enemy.CheckDeath(this);
                                        }
                                    }
                                    break;
                                case ItemScope.AllEnemies:
                                    // Get Enemies in range
                                    List<EventProcessor> enemies = GetTargetsForPlayer(item.Range, item.MustFaceTarget);
                                    // Use item on enemies
                                    foreach (EventProcessor e in enemies)
                                    {
                                        if (RangeOf(e) > item.Range)
                                            continue;
                                        // Change Direction
                                        if (e != Global.Instance.Player[0])
                                        {
                                            e.TurnTowardEvent(this, e.Data.Pages[e.pageIndex].BattleDirections);
                                            e.Target = this;
                                        }
                                        used = Battle.UseItem(Battler, e.Battler, item, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(item.Effects[index].Animation, item.Effects[index].Action, Global.AngleToDirection(Angle), e);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(item.Effects[index].Particle, e);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(e.Battler.Damage, e.Battler.Damaged, e, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (e.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (e.Battler.Damage > 0)
                                            {
                                                e.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            e.Battler.Damaged = false;
                                            e.Battler.Damage = 0;
                                            // Check if target is dead
                                            e.CheckDeath(this);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    return;
                    #endregion
                case BattleState.Skill:
                    #region Skill
                    skill = ((HeroProcessor)Battler).LastSkill;
                    // Check Projectile
                    if (skill.Projectile > -1)
                    {
                        Global.CreateProjectile(this, GetTargetForPlayer(skill.Range, skill.MustFaceTarget), skill, this.Data.Pages[pageIndex].Hostiles);
                        return;
                    }
                    for (int index = 0; index < skill.Effects.Count; index++)
                    {
                        // Check if effect scope is user
                        if (skill.Effects[index].Scope != EffectScope.User)
                        {
                            // Check Skill Scope
                            switch (skill.Scope)
                            {
                                case ItemScope.User:
                                    // Use on user
                                    if (skill.Effects[index].Value > 0)
                                        used = Battle.UseSkill(Battler, Battler, skill, index);

                                    // Attack
                                    frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                    // Show Particles
                                    Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Player target's Hit Animation if target hit and damege > 0
                                    if (Battler.Damaged)
                                    {
                                        // Animate hit animation
                                        if (Battler.Damage > 0)
                                        {
                                            this.Animate(EventAction.Hit);
                                        }
                                        // Reset
                                        Battler.Damaged = false;
                                        Battler.Damage = 0;
                                    }
                                    break;
                                case ItemScope.OneHero:
                                    EventProcessor closestEv;
                                    HeroProcessor closest;
                                    GetClosestAlly(skill.Range, skill, out closest, out closestEv);
                                    if (closest == null)
                                    {
                                        closest = (HeroProcessor)Battler;
                                        closestEv = this;
                                    }
                                    // Use on user
                                    if (closest != null)
                                    {
                                        used = Battle.UseSkill(Battler, closest, skill, index);

                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), closestEv);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, closestEv);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(closest.Damage, closest.Damaged, closestEv, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (closest.Damaged)
                                        {
                                            // Animate hit animation
                                            if (closest.Damage > 0)
                                            {
                                                this.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            closest.Damaged = false;
                                            closest.Damage = 0;
                                        }
                                    }
                                    break;
                                case ItemScope.AllAllies:
                                    // Use on party
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.CanSkillEffect(skill) && InRangeOf(Global.Instance.Party.GetPartyMember(target.ID), skill.Range, skill.MustFaceTarget))
                                        {
                                            used = Battle.UseSkill(Battler, target, skill, index);

                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (Battler.Damaged)
                                            {
                                                // Display Damage - Add to screen text effects
                                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                                // Animate hit animation
                                                if (Battler.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                Battler.Damaged = false;
                                                Battler.Damage = 0;
                                            }
                                        }
                                    }
                                    break;
                                case ItemScope.OneAllyDead:
                                    // Find a dead ally 
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.IsDead() && target.CanSkillEffect(skill) && InRangeOf(Global.Instance.Party.GetPartyMember(target.ID), skill.Range, skill.MustFaceTarget))
                                        {
                                            used = Battle.UseSkill(Battler, target, skill, index);

                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (Battler.Damaged)
                                            {
                                                // Display Damage - Add to screen text effects
                                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                                // Animate hit animation
                                                if (Battler.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                Battler.Damaged = false;
                                                Battler.Damage = 0;
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                case ItemScope.AllPartyDead:
                                    // Use on party
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.IsDead() && target.CanSkillEffect(skill) && InRangeOf(Global.Instance.Party.GetPartyMember(target.ID), skill.Range, skill.MustFaceTarget))
                                        {
                                            used = Battle.UseSkill(Battler, target, skill, index);

                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (Battler.Damaged)
                                            {
                                                // Display Damage - Add to screen text effects
                                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                                // Animate hit animation
                                                if (Battler.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                Battler.Damaged = false;
                                                Battler.Damage = 0;
                                            }
                                        }
                                    }
                                    break;
                                case ItemScope.OneEnemy:
                                    // Get Enemy in range
                                    EventProcessor enemy = GetTargetForPlayer(skill.Range, skill.MustFaceTarget);

                                    if (enemy != null)
                                    {
                                        // Change Direction
                                        if (enemy != Global.Instance.Player[0])
                                        {
                                            enemy.TurnTowardEvent(this, enemy.Data.Pages[enemy.pageIndex].BattleDirections);
                                            enemy.Target = this;
                                        }
                                        // Use skill on enemy
                                        used = Battle.UseSkill(Battler, enemy.Battler, skill, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), enemy);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, enemy);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(enemy.Battler.Damage, enemy.Battler.Damaged, enemy, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (enemy.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (enemy.Battler.Damage > 0)
                                            {
                                                enemy.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            enemy.Battler.Damaged = false;
                                            enemy.Battler.Damage = 0;
                                            // Check if target is dead
                                            enemy.CheckDeath(this);
                                        }
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (Battler.Damaged)
                                        {
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                            // Animate hit animation
                                            if (Battler.Damage > 0)
                                            {
                                                this.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            Battler.Damaged = false;
                                            Battler.Damage = 0;
                                        }
                                    }
                                    break;
                                case ItemScope.AllEnemies:
                                    // Get Enemies in range
                                    List<EventProcessor> enemies = GetTargetsForPlayer(skill.Range, skill.MustFaceTarget);
                                    // Use skill on enemies
                                    foreach (EventProcessor e in enemies)
                                    {
                                        if (RangeOf(e) > skill.Range)
                                            continue;
                                        // Change Direction
                                        if (e != Global.Instance.Player[0])
                                        {
                                            e.TurnTowardEvent(this, e.Data.Pages[e.pageIndex].BattleDirections);
                                            e.Target = this;
                                        }
                                        used = Battle.UseSkill(Battler, e.Battler, skill, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), e);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, e);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(e.Battler.Damage, e.Battler.Damaged, e, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (e.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (e.Battler.Damage > 0)
                                            {
                                                e.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            e.Battler.Damaged = false;
                                            e.Battler.Damage = 0;
                                            // Check if target is dead
                                            e.CheckDeath(this);
                                        }
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (Battler.Damaged)
                                        {
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                            // Animate hit animation
                                            if (Battler.Damage > 0)
                                            {
                                                this.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            Battler.Damaged = false;
                                            Battler.Damage = 0;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    return;
                    #endregion
            }
        }
        /// <summary>
        /// Gets the closest ally that meets the conditions
        /// </summary>
        /// <param name="range"></param>
        /// <param name="c"></param>
        /// <param name="closest"></param>
        /// <param name="closetEv"></param>
        private void GetClosestAlly(int range, SkillData c, out HeroProcessor closest, out EventProcessor closestEv)
        {
            float cRange = 0, lRange = int.MaxValue;
            closest = null; closestEv = null;
            for (int i = 0; i < Global.Instance.Player.Count; i++)
            {
                if (Global.Instance.Player[i] != this && Global.Instance.Player[i].Battler.CanSkillEffect(c) && InRangeOf(Global.Instance.Player[i], c.Range, c.MustFaceTarget, out cRange))
                {
                    if (cRange < lRange)
                    {
                        lRange = cRange;
                        closest = (HeroProcessor)Global.Instance.Player[i].Battler;
                        closestEv = Global.Instance.Player[i];
                    }
                }
            }
        }
        /// <summary>
        /// Gets the closest ally that meets the conditions
        /// </summary>
        /// <param name="range"></param>
        /// <param name="c"></param>
        /// <param name="closest"></param>
        /// <param name="closetEv"></param>
        private void GetClosestAlly(int range, ItemData c, out HeroProcessor closest, out EventProcessor closestEv)
        {
            float cRange = 0, lRange = int.MaxValue;
            closest = null; closestEv = null;
            for (int i = 0; i < Global.Instance.Player.Count; i++)
            {
                if (Global.Instance.Player[i].Battler.CanItemEffect(c) && Global.Instance.Player[i] != this && InRangeOf(Global.Instance.Player[i], c.Range, c.MustFaceTarget, out cRange))
                {
                    if (cRange < lRange)
                    {
                        lRange = cRange;
                        closest = (HeroProcessor)Global.Instance.Player[i].Battler;
                        closestEv = Global.Instance.Player[i];
                    }
                }
            }
        }
        /// <summary>
        /// Get Target
        /// </summary>
        /// <returns></returns>
        private List<EventProcessor> GetTargetsForPlayer(int dist, bool mustFace)
        {
            List<EventProcessor> targets = new List<EventProcessor>();
            List<Vector2> collisionList = new List<Vector2>();
            Vector2 newdist = Animation.CollisionCentroid;
            newdist.X += dist; newdist.Y += dist;
            newdist = ConvertUnits.ToSimUnits(newdist);
            int tempFixtureCount = Global.World.BodyList.Count;
            EventProcessor ev;
            if (!mustFace)
            {
                Vector2 targetAngle;
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (!ev.IsPlayer && ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            targetAngle = (Global.World.BodyList[i].Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                            if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), Global.World.BodyList[i], ref newdist))
                            {
                                if (CheckForObstacles(ev, newdist))
                                {
                                    targets.Add(ev);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (!ev.IsPlayer && ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (Collide(Angle, Global.World.BodyList[i], ref newdist))
                            {
                                if (CheckForObstacles(ev, newdist))
                                {
                                    targets.Add(ev);
                                }
                            }
                        }
                    }
                }
            }
            return targets;
        }
        /// <summary>
        /// Get Target
        /// </summary>
        /// <returns></returns>
        private EventProcessor GetTargetForPlayer(int dist, bool mustFace)
        {
            EventProcessor closestEvent = null;
            int currentDistance = 0;
            int closestDistance = 0;
            List<Vector2> collisionList = new List<Vector2>();
            int tempFixtureCount = Global.World.BodyList.Count;
            Vector2 newdist = Animation.CollisionCentroid;
            newdist.X += dist; newdist.Y += dist;
            newdist = ConvertUnits.ToSimUnits(newdist);
            Vector2 targetDist;
            EventProcessor ev;

            if (!mustFace)
            {
                Vector2 targetAngle;
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (!ev.IsPlayer && ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            targetAngle = (Global.World.BodyList[i].Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
                            targetDist = ConvertUnits.ToSimUnits(ev.Animation.Action.HitBody.GetCentroid()) + newdist;

                            if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), ev.BattleBody, ref targetDist))
                            {
                                Vector2 local = Body.Position;
                                currentDistance = (int)ev.Body.GetDistance(Body);
                                if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                {
                                    if (CheckForObstacles(ev, closestDistance))
                                    {
                                        closestEvent = ev;
                                        closestDistance = currentDistance;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (!ev.IsPlayer && ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null && ev.BattleBody != null)
                        {
                            targetDist = ConvertUnits.ToSimUnits(ev.Animation.Action.HitBody.GetCentroid()) + newdist;
                            if (Collide(Angle, ev.Body, ref targetDist))
                            {
                                Vector2 local = Body.Position;
                                currentDistance = (int)ev.Body.GetDistance(Body);
                                if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                {
                                    if (CheckForObstacles(ev, closestDistance))
                                    {
                                        closestEvent = ev;
                                        closestDistance = currentDistance;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return closestEvent;
        }
        #endregion

        #region Method: Ally AI
        /// <summary>
        /// Update Ally
        /// </summary>
        private void UpdateAlly()
        {
            isBattlerMoving = false;
            // Return if there is an action taking place and must be completed
            if (actionTakingPlace != ActionType.None && waitActionCompelition)
                return;
            // Check if any messages are active
            for (int i = 0; i < Global.Messages.Count; i++)
                if (Global.Messages[i].WaitOnClose)
                    return;
            // Check if any menus are active
            for (int i = 0; i < Global.Menus.Count; i++)
                if (Global.Menus[i].WaitOnClose)
                    return;
            if (Target != null && Target.Battler != null && Battler.CanMove() && !Battler.IsDead() && !Target.Battler.IsDead())
            {
                if (coolDown <= 0 && attackFrames <= 0 && BattleState == BattleState.None)
                {
                    // If Target is not null, get its precision range
                    TargetRange = PrecisionRangeOf(Target);
                    ///if ((!isMoving || !IsMoving) &&  attackFrames <= 0)
                    if (attackFrames <= 0)
                    {
                        // Reset Defense
                        Battler.IsDefending = false;
                        // Perform Action Type
                        bool result = false;
                        if (!result)
                            result = PerformAllyAttack();
                        if (!result)
                            result = PerformAllySkill(false);
                        if (!result)
                            result = PerformAllyMagic(false);
                        if (!result)
                            if (TargetRange > 0.01 || IsFacing(Target.Body, TargetRange))
                                MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                            else
                                TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);

                    }
                }
                else if (FinishAttackFrames <= 0 && BattleState != BattleState.None)
                {
                    FinishAllyAttack();
                    BattleState = BattleState.None;
                }
                attackFrames--;
                coolDown--;
                FinishAttackFrames--;
            }
            else
            {
                Target = null;
                if (Body != null)
                {
                    if (!Battler.IsDead() && Battler.CanMove())
                    {
                        switch (Global.Instance.Party.Command)
                        {
                            case PartyCommand.FollowPlayer:
                                if (!Collide(Global.Instance.Player[0].Body, 46 * PartyIndex))
                                {
                                    if (!Body.Collide(Global.Instance.Player[0].Body))
                                    {
                                        // Turn Toward Event
                                        TurnEnemyTowardEvent(Global.Instance.Player[0], null);
                                        // Calculate target To Move
                                        ApplyForce(Angle, Force, true);
                                        // 
                                        isBattlerMoving = true;
                                    }
                                } break;
                            case PartyCommand.SearchAndDestroy:
                                // Look for target
                                // Case the attack condition
                                Target = GetAllyTarget(640, false);
                                if (Target == null)
                                {
                                    if (!Collide(Global.Instance.Player[0].Body, 46 * PartyIndex))
                                    {
                                        if (!Body.Collide(Global.Instance.Player[0].Body))
                                        {
                                            // Turn Toward Event
                                            TurnEnemyTowardEvent(Global.Instance.Player[0], null);
                                            // Calculate target To Move
                                            ApplyForce(Angle, Force, true);
                                            // 
                                            isBattlerMoving = true;
                                        }
                                    }
                                }
                                break;
                            case PartyCommand.HoldArea:
                                break;
                        }
                    }
                }
            }
        }

        private bool PerformAllyMagic(bool ignoreCost)
        {
            foreach (int skillId in ((HeroProcessor)Battler).Magics)
            {
                if (skillId > -1)
                {
                    SkillData skill = GameData.Skills.GetData(skillId);

                    if (skill != null && (ignoreCost || Battler.CanUseSkill(skill)))
                    {
                        attackFrames = 10;
                        if (skill.Range < TargetRange && skill.Scope == ItemScope.OneEnemy)
                            return false;
                        int frames;
                        // Play Skill Animation
                        FinishAttackFrames = Animate((skill.SkillType == SkillType.Skill ? EventAction.Skill : EventAction.Magic), Battler.GetSkillAction(skill));

                        coolDown = skill.Speed + FinishAttackFrames;

                        for (int index = 0; index < skill.Effects.Count; index++)
                        {
                            // Check if effect scope is user
                            if (skill.Effects[index].Scope == EffectScope.User)
                            {
                                // Use on user
                                Battle.UseMagic(Battler, Battler, skill, index);
                                // Attack
                                frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                // Player target's Hit Animation if target hit and damege > 0
                                if (Battler.Damaged)
                                {
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                }
                            }
                        }
                        ((HeroProcessor)Battler).LastSkill = skill;
                        BattleState = BattleState.Skill;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool PerformAllySkill(bool ignoreCost)
        {
            foreach (int skillId in ((HeroProcessor)Battler).Skills)
            {
                if (skillId > -1)
                {
                    SkillData skill = GameData.Skills.GetData(skillId);

                    if (skill != null && (ignoreCost || Battler.CanUseSkill(skill)))
                    {
                        attackFrames = 10;
                        if (skill.Range < TargetRange && skill.Scope == ItemScope.OneEnemy)
                            return false;
                        int frames;
                        // Play Skill Animation
                        FinishAttackFrames = Animate((skill.SkillType == SkillType.Skill ? EventAction.Skill : EventAction.Magic), Battler.GetSkillAction(skill));

                        coolDown = skill.Speed + FinishAttackFrames;

                        for (int index = 0; index < skill.Effects.Count; index++)
                        {
                            // Check if effect scope is user
                            if (skill.Effects[index].Scope == EffectScope.User)
                            {
                                // Use on user
                                if (skill.Effects[index].Value > 0)
                                    Battle.UseSkill(Battler, Battler, skill, index);
                                // Attack
                                frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                // Player target's Hit Animation if target hit and damege > 0
                                if (Battler.Damaged)
                                {
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                }
                            }
                        }
                        ((HeroProcessor)Battler).LastSkill = skill;
                        BattleState = BattleState.Skill;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool PerformAllyAttack()
        {
            if (Target != null)
            {
                EquipmentData equipment;
                equipment = ((HeroProcessor)Battler).GetOffensiveEquipment((int)ConvertUnits.ToDisplayUnits(TargetRange));
                // If Equipment is not null, then use equipment
                if (equipment != null)
                {
                    // Turn Toward Enemy
                    TurnEnemyTowardEvent(Target, null);
                    // If in line to use the equipment, use it
                    if (InLineOf(Target, (float)TargetRange, true))
                    {
                        // Play Attack Animation
                        FinishAttackFrames = Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                        // Mash Time
                        coolDown = equipment.Mash + FinishAttackFrames;
                        BattleState = BattleState.Basic;
                        return true;
                    }
                }
            }
            return false;
        }

        private void FinishAllyAttack()
        {
            EquipmentData equipment;
            SkillData skill;
            int frames;
            bool used = false;
            switch (BattleState)
            {
                case BattleState.Basic:
                    #region Basic
                    equipment = ((HeroProcessor)Battler).LastEquipment;
                    if (equipment != null)
                    {
                        // If Projectile
                        if (equipment.Projectile > -1)
                        {
                            // New Projectile
                            Global.CreateProjectile(this, Target, equipment, this.Data.Pages[pageIndex].Hostiles);
                        }
                        else
                        {
                            // Non Projectile
                            Target = GetTargetForPlayer(equipment.Range, true);
                            // If there is a target
                            if (Target != null)
                            {
                                // Attack
                                frames = Global.ShowAnimationOnEvent(equipment.Animation, equipment.Action, Global.AngleToDirection(Angle), Target);
                                // Calculate Damage
                                Battle.Attack(Battler, Target.Battler, equipment);
                                // Display Damage - Add to screen text effects
                                Global.DisplayDamage(Target.Battler.Damage, Target.Battler.Damaged, Target, frames);
                                // Change Direction
                                if (Target != Global.Instance.Player[0])
                                {
                                    Target.TurnTowardEvent(this, Target.Data.Pages[Target.pageIndex].BattleDirections);
                                    if (!Target.IsPlayer) Target.Target = this;
                                }
                                // Player target's Hit Animation if target hit and damege > 0
                                if (Target.Battler.Damaged)
                                {
                                    // Increase Combo if combo counter is not zero
                                    if (HitFrameCounter > 0)
                                        Global.Instance.HitCount++;
                                    else
                                    {
                                        HitFrameCounter = 60;
                                        Global.Instance.HitCount = 0;
                                    }
                                    // Animate hit animation
                                    if (Target.Battler.Damage > 0)
                                    {
                                        Target.Animate(EventAction.Hit);
                                        // Knockback
                                        Target.Knocback(equipment.Knockback, this.Position);
                                    }
                                    // Reset
                                    Target.Battler.Damaged = false;
                                    Target.Battler.Damage = 0;
                                    // Check if target is dead
                                    Target.CheckDeath(this);
                                }
                                // Player 
                                if (Battler.Damaged)
                                {
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Animate hit animation
                                    if (Battler.Damage > 0)
                                    {
                                        Animate(EventAction.Hit);
                                        // Knockback
                                        Knocback(equipment.Knockback, this.Position);
                                    }
                                    // Reset
                                    Battler.Damaged = false;
                                    Battler.Damage = 0;
                                }
                            }
                        }
                    }
                    // If did not attack with an offensive weapon, don't use weapon
                    else
                    {
                        // Get Closest Enemy
                        Target = GetTargetForPlayer(0, true);
                        // Play Attack Animation
                        Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                        // Mashtime
                        coolDown = Animation.GetDisplayTime();
                        // If there is a target
                        if (Target != null)
                        {
                            // Calculate Damage
                            Battle.Attack(Battler, Target.Battler, equipment);
                            // Display Damage - Add to screen text effects
                            Global.DisplayDamage(Target.Battler.Damage, Target.Battler.Damaged, Target, 0);
                            // Change Direction
                            if (Target != Global.Instance.Player[0])
                            {
                                Target.TurnTowardEvent(this, Target.Data.Pages[Target.pageIndex].BattleDirections);
                                if (!Target.IsPlayer) Target.Target = this;
                            }
                            // Player target's Hit Animation if target hit and damege > 0
                            if (Target.Battler.Damaged)
                            {
                                // Animate hit animation
                                if (Target.Battler.Damage > 0)
                                {
                                    Target.Animate(EventAction.Hit);
                                }
                                // Reset
                                Target.Battler.Damaged = false;
                                Target.Battler.Damage = 0;
                                // Check if target is dead
                                Target.CheckDeath(this);
                            }
                            // Player 
                            if (Battler.Damaged)
                            {
                                // Display Damage - Add to screen text effects
                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, 0);
                                // Animate hit animation
                                if (Battler.Damage > 0)
                                {
                                    Animate(EventAction.Hit);
                                }
                                // Reset
                                Battler.Damaged = false;
                                Battler.Damage = 0;
                            }
                        }
                    }
                    return;
                    #endregion
                case BattleState.Skill:
                    #region Skill
                    skill = ((HeroProcessor)Battler).LastSkill;
                    // Check Projectile
                    if (skill.Projectile > -1)
                    {
                        Global.CreateProjectile(this, GetTargetForPlayer(skill.Range, skill.MustFaceTarget), skill, this.Data.Pages[pageIndex].Hostiles);
                        return;
                    }
                    for (int index = 0; index < skill.Effects.Count; index++)
                    {
                        // Check if effect scope is user
                        if (skill.Effects[index].Scope != EffectScope.User)
                        {
                            // Check Skill Scope
                            switch (skill.Scope)
                            {
                                case ItemScope.User:
                                    // Use on user
                                    if (skill.Effects[index].Value > 0)
                                        used = Battle.UseSkill(Battler, Battler, skill, index);

                                    // Attack
                                    frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                    // Show Particles
                                    Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                    // Display Damage - Add to screen text effects
                                    Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                    // Player target's Hit Animation if target hit and damege > 0
                                    if (Battler.Damaged)
                                    {
                                        // Animate hit animation
                                        if (Battler.Damage > 0)
                                        {
                                            this.Animate(EventAction.Hit);
                                        }
                                        // Reset
                                        Battler.Damaged = false;
                                        Battler.Damage = 0;
                                    }
                                    break;
                                case ItemScope.AllAllies:
                                    // Use on party
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        used = Battle.UseSkill(Battler, target, skill, index);

                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (target.Damaged)
                                        {
                                            // Animate hit animation
                                            if (target.Damage > 0)
                                            {
                                                this.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            target.Damaged = false;
                                            target.Damage = 0;
                                        }
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (Battler.Damaged)
                                        {
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                            // Animate hit animation
                                            if (Battler.Damage > 0)
                                            {
                                                this.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            Battler.Damaged = false;
                                            Battler.Damage = 0;
                                        }
                                    }
                                    break;
                                case ItemScope.OneAllyDead:
                                    // Find a dead ally 
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.IsDead())
                                        {
                                            used = Battle.UseSkill(Battler, target, skill, index);

                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (Battler.Damaged)
                                            {
                                                // Display Damage - Add to screen text effects
                                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                                // Animate hit animation
                                                if (Battler.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                Battler.Damaged = false;
                                                Battler.Damage = 0;
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                case ItemScope.AllPartyDead:
                                    // Use on party
                                    foreach (HeroProcessor target in Global.Instance.Party.Heroes)
                                    {
                                        if (target.IsDead())
                                        {
                                            used = Battle.UseSkill(Battler, target, skill, index);

                                            // Attack
                                            frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), this);
                                            // Show Particles
                                            Global.ShowParticleOnEvent(skill.Effects[index].Particle, this);
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(target.Damage, target.Damaged, this, frames);
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (target.Damaged)
                                            {
                                                // Animate hit animation
                                                if (target.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                target.Damaged = false;
                                                target.Damage = 0;
                                            }
                                            // Player target's Hit Animation if target hit and damege > 0
                                            if (Battler.Damaged)
                                            {
                                                // Display Damage - Add to screen text effects
                                                Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                                // Animate hit animation
                                                if (Battler.Damage > 0)
                                                {
                                                    this.Animate(EventAction.Hit);
                                                }
                                                // Reset
                                                Battler.Damaged = false;
                                                Battler.Damage = 0;
                                            }
                                        }
                                    }
                                    break;
                                case ItemScope.OneEnemy:
                                    // Get Enemy in range
                                    EventProcessor enemy = GetTargetForPlayer(skill.Range, skill.MustFaceTarget);

                                    if (enemy != null)
                                    {
                                        // Change Direction
                                        if (enemy != Global.Instance.Player[0])
                                        {
                                            enemy.TurnTowardEvent(this, enemy.Data.Pages[enemy.pageIndex].BattleDirections);
                                            enemy.Target = this;
                                        }
                                        // Use skill on enemy
                                        used = Battle.UseSkill(Battler, enemy.Battler, skill, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), enemy);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, enemy);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(enemy.Battler.Damage, enemy.Battler.Damaged, enemy, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (enemy.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (enemy.Battler.Damage > 0)
                                            {
                                                enemy.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            enemy.Battler.Damaged = false;
                                            enemy.Battler.Damage = 0;
                                            // Check if target is dead
                                            enemy.CheckDeath(this);
                                        }
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (Battler.Damaged)
                                        {
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                            // Animate hit animation
                                            if (Battler.Damage > 0)
                                            {
                                                this.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            Battler.Damaged = false;
                                            Battler.Damage = 0;
                                        }
                                    }
                                    break;
                                case ItemScope.AllEnemies:
                                    // Get Enemies in range
                                    List<EventProcessor> enemies = GetTargetsForPlayer(skill.Range, skill.MustFaceTarget);
                                    // Use skill on enemies
                                    foreach (EventProcessor e in enemies)
                                    {
                                        if (RangeOf(e) > skill.Range)
                                            continue;
                                        // Change Direction
                                        if (e != Global.Instance.Player[0])
                                        {
                                            e.TurnTowardEvent(this, e.Data.Pages[e.pageIndex].BattleDirections);
                                            e.Target = this;
                                        }
                                        used = Battle.UseSkill(Battler, e.Battler, skill, index);
                                        // Attack
                                        frames = Global.ShowAnimationOnEvent(skill.Effects[index].Animation, skill.Effects[index].Action, Global.AngleToDirection(Angle), e);
                                        // Show Particles
                                        Global.ShowParticleOnEvent(skill.Effects[index].Particle, e);
                                        // Display Damage - Add to screen text effects
                                        Global.DisplayDamage(e.Battler.Damage, e.Battler.Damaged, e, frames);
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (e.Battler.Damaged)
                                        {
                                            // Animate hit animation
                                            if (e.Battler.Damage > 0)
                                            {
                                                e.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            e.Battler.Damaged = false;
                                            e.Battler.Damage = 0;
                                            // Check if target is dead
                                            e.CheckDeath(this);
                                        }
                                        // Player target's Hit Animation if target hit and damege > 0
                                        if (Battler.Damaged)
                                        {
                                            // Display Damage - Add to screen text effects
                                            Global.DisplayDamage(Battler.Damage, Battler.Damaged, this, frames);
                                            // Animate hit animation
                                            if (Battler.Damage > 0)
                                            {
                                                this.Animate(EventAction.Hit);
                                            }
                                            // Reset
                                            Battler.Damaged = false;
                                            Battler.Damage = 0;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    return;
                    #endregion
            }
            if (Target != null)
            {
                if (RangeOf(Target) > 1)
                {
                    // Move Closer
                    MoveEnemyTowardEvent(Target, null); ;
                }
                else
                {
                    TurnEnemyTowardEvent(Target, null);
                }
            }
        }
        /// <summary>
        /// Get Target
        /// </summary>
        /// <returns></returns>
        private EventProcessor GetAllyTarget(int dist, bool mustFace)
        {
            Vector2 newdist = Animation.CollisionCentroid;
            newdist.X += dist; newdist.Y += dist;
            newdist = ConvertUnits.ToSimUnits(newdist);
            EventProcessor closestEvent = null;
            int currentDistance = 0;
            int closestDistance = 0;
            List<Vector2> collisionList = new List<Vector2>();
            //dist = 30;
            int tempFixtureCount = Global.World.BodyList.Count;
            EventProcessor ev;
            if (!mustFace)
            {
                Vector2 targetAngle;
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                                if (!ev.Data.Pages[pageIndex].Hostiles.Contains(-1) && !Battler.AttackAlly())
                                    continue;
                            if (ev.IsPlayer && !Battler.AttackAlly())
                                continue;


                            targetAngle = (Global.World.BodyList[i].Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);

                            if (Collide((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), Global.World.BodyList[i], ref newdist))
                            {
                                Vector2 local = Body.Position;
                                currentDistance = (int)ev.Body.GetDistance(Body);
                                if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                {
                                    closestEvent = ev;
                                    closestDistance = currentDistance;
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                // Loop All Fixtures Once
                for (int i = 0; i < tempFixtureCount; i++)
                {
                    if (Global.World.BodyList[i] != Body && Global.World.BodyList[i].UserData is EventProcessor)
                    {
                        // Check if a battler
                        ev = Global.World.BodyList[i].UserData as EventProcessor;
                        if (ev.Battler != null && !ev.Battler.IsDead() && ev.Body != null)
                        {
                            if (!ev.IsPlayer)
                                if (!ev.Data.Pages[pageIndex].Hostiles.Contains(-1) && !Battler.AttackAlly())
                                    continue;
                            if (ev.IsPlayer && !Battler.AttackAlly())
                                continue;
                            if ((!mustFace && Collide(Global.World.BodyList[i], ref newdist)) || Collide(Angle, Global.World.BodyList[i], ref newdist))
                            {
                                Vector2 local = Body.Position;
                                currentDistance = (int)ev.Body.GetDistance(Body);
                                if ((closestEvent == null || (closestEvent != null && currentDistance < closestDistance)))
                                {
                                    if (CheckForObstacles(ev, closestDistance))
                                    {
                                        closestEvent = ev;
                                        closestDistance = currentDistance;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return closestEvent;
        }
        #endregion

        #region Method: Shared Battle Methods - Attack, Defend, Use Item/Skill, Force Use, Check Death, Animate
        /// <summary>
        /// Force an attack
        /// </summary>
        public void Attack()
        {
            if (IsPlayer)
            {
                if (PartyIndex == 0)
                {
                    if (coolDown <= 0 && BattleState == BattleState.None)
                        ProcessPlayerAttack();
                }
            }
            else if (Battler != null)
            {
                if (coolDown <= 0 && BattleState == BattleState.None)
                    if (Target != null)
                    {
                        EquipmentData equipment;
                        equipment = ((EnemyProcessor)Battler).GetOffensiveEquipment((int)ConvertUnits.ToDisplayUnits(TargetRange));
                        // If Equipment is not null, then use equipment
                        if (equipment != null)
                        {
                            // Turn Toward Enemy
                            TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                            // If in line to use the equipment, use it
                            if (InLineOf(Target, (float)TargetRange, true))
                            {
                                // Play Attack Animation
                                FinishAttackFrames = Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                                // Mash Time
                                coolDown = equipment.Mash + FinishAttackFrames;
                                BattleState = BattleState.Basic;
                                // Turn Toward Enemy
                                TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);

                                // Move Closer
                                if (data.Pages[pageIndex].RushTarget)
                                    MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                                return;
                            }
                        }
                        if (TargetRange > 0.01 || IsFacing(Target.Body, TargetRange))
                        {
                            // Move Closer
                            MoveEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        }
                        else
                        {
                            TurnEnemyTowardEvent(Target, Data.Pages[pageIndex].BattleDirections);
                        }
                    }
            }
        }
        /// <summary>
        /// Force a defend
        /// </summary>
        public void Defend()
        {
            if (IsPlayer)
            {
                if (PartyIndex == 0)
                {
                    Battler.IsDefending = true;
                    AllowMovement = false;
                    // If the key is new, show animation, if not, do not show animation
                    if (ActionIndex != EventAction.Defend)
                        AnimateStill(EventAction.Defend);
                }
            }
        }
        /// <summary>
        /// Use Item
        /// </summary>
        /// <param name="id"></param>
        public void UseItem(int id, bool ignoreInventory, bool ignoreCooldown)
        {
            if (IsPlayer)
            {
                if (PartyIndex == 0)
                {
                    if ((ignoreCooldown || coolDown <= 0) && BattleState == BattleState.None)
                        ProcessPlayerItem(id, ignoreInventory);
                }
            }
            else if (Battler != null)
            {
                if ((ignoreCooldown || coolDown <= 0) && BattleState == BattleState.None)
                {
                    ((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].Item = id;
                    PerformEnemyItem();
                }
            }
        }
        /// <summary>
        /// Use Skill
        /// </summary>
        /// <param name="id"></param>
        public void UseSkill(int id, bool ignoreCost, bool ignoreCooldown)
        {
            if (IsPlayer)
            {
                if (PartyIndex == 0)
                {
                    if ((ignoreCooldown || coolDown <= 0) && BattleState == BattleState.None)
                        ProcessPlayerSkill(id, ignoreCost);
                }
            }
            else if (Battler != null)
            {
                if ((ignoreCooldown || coolDown <= 0) && BattleState == BattleState.None)
                {
                    ((EnemyProcessor)Battler).Data.Programs[enemyProgramIndex].Item = id;
                    PerformEnemySkill(ignoreCost);
                }
            }
        }
        /// <summary>
        /// Forces the use of a slot. Works only for offensive weapons
        /// </summary>
        /// <param name="p"></param>
        public void ForceUseSlot(int id)
        {
            if (Battler == null) return;
            if (coolDown <= 0 && BattleState == BattleState.None)
            {
                EquipmentData equipment;
                if (Battler is HeroProcessor)
                    equipment = GameData.Equipments.GetData(((HeroProcessor)Battler).GetEquipment(id));
                else
                    equipment = GameData.Equipments.GetData(((EnemyProcessor)Battler).GetEquipment(id));

                if (equipment != null)
                {
                    if (equipment.EquipType == EquipType.Offensive)
                    {
                        // Check if ammo is required
                        if (equipment.AmmoID > -1 && Battler is HeroProcessor)
                        {
                            // Check if ammo exists
                            if (((HeroProcessor)Battler).HasItem(equipment.AmmoID))
                            {
                                ((HeroProcessor)Battler).RemoveItem(equipment.AmmoID);
                            }
                            else
                                return;
                        }
                        // Play Attack Animation
                        FinishAttackFrames = Animate(EventAction.Attack, Battler.GetEquipmentAction(equipment));
                        // Mash Time
                        coolDown = equipment.Mash + FinishAttackFrames;
                        BattleState = BattleState.Basic;

                        if (Battler is HeroProcessor)
                            ((HeroProcessor)Battler).LastEquipment = equipment;
                        else
                            ((EnemyProcessor)Battler).LastEquipment = equipment;
                    }
                    else
                    {
                        Animate(EventAction.Defend, Battler.GetEquipmentAction(equipment));
                        coolDown = equipment.Mash;
                        Battler.IsDefending = true;
                    }
                }
            }
        }
        /// <summary>
        /// Check Dead
        /// </summary>
        public void CheckDeath(EventProcessor killer)
        {
            if (Battler is EnemyProcessor && Battler.IsDead())
            {
                // Play Death Animation
                AnimateDeath(EventAction.Death);
                // Death Trigger
                DeathTrigger(Animation.GetDisplayTime());
                // Process Rewards
                if (killer.Battler is HeroProcessor)
                {
                    // Experience
                    int exp = ((EnemyProcessor)Battler).Data.Experience;
                    Battle.ApplyExpCombo(ref exp);
                    foreach (HeroProcessor hero in Global.Instance.Party.Heroes)
                    {
                        hero.IncreaseExperience(exp);
                    }
                    // Add Gold
                    Global.SetVariable(Global.Project.Gold, ((EnemyProcessor)Battler).Data.Gold);
                    // Drop Items
                    Random rand = new Random();
                    foreach (int equipId in ((EnemyProcessor)Battler).Data.EquipDrops)
                    {
                        if (rand.Next(0, 100) <= ((EnemyProcessor)Battler).Data.DropProbality)
                        {
                            ((HeroProcessor)killer.Battler).AddEquipment(equipId);
                        }
                    }
                    foreach (int itemId in ((EnemyProcessor)Battler).Data.ItemDrops)
                    {
                        if (rand.Next(0, 100) <= ((EnemyProcessor)Battler).Data.DropProbality)
                        {
                            ((HeroProcessor)killer.Battler).AddItem(itemId);
                        }
                    }
                }
            }
            else if (Battler is HeroProcessor)
            {
                if (!killer.IsPlayer)
                {
                    for (int i = 1; i < Global.Instance.Player.Count; i++)
                    {
                        if (Global.Instance.Player[i].Target == null)
                            Global.Instance.Player[i].Target = killer;
                    }
                }
                // Play Death Animation
                if (Battler.IsDead())
                {
                    AnimateDeath(EventAction.Death);
                }
            }
        }
        /// <summary>
        /// Death trigger
        /// </summary>
        private void DeathTrigger(int frames)
        {
            SwitchData switc;
            VariableData variable;
            switch (data.Pages[pageIndex].DeathTrigger[0])
            {
                case 0: // None
                    break;
                case 1: // Erase
                    Animation.BeginErase = BeginErase = true;
                    Animation.EraseFrames = EraseFrames = frames;
                    break;
                case 2: // Activate Current Page
                    isProgramActive = true;
                    break;
                case 3: // Switch
                    switc = Global.Instance.Switches.GetData((data.Pages[pageIndex].DeathTrigger[1]));
                    if (switc != null)
                    {
                        switc.State = (data.Pages[pageIndex].DeathTrigger[2] == 0 ? true : false);
                    }
                    Animation.BeginErase = true;
                    BeginErase = !data.Pages[pageIndex].DontErase;
                    EraseFrames = frames;
                    break;
                case 4: // Local Switch
                    switc = Switches.GetData(data.Pages[pageIndex].DeathTrigger[1]);
                    if (switc != null)
                        switc.State = (data.Pages[pageIndex].DeathTrigger[2] == 0 ? true : false);
                    Animation.BeginErase = true;
                    BeginErase = !data.Pages[pageIndex].DontErase;
                    Animation.EraseFrames = EraseFrames = frames;
                    break;
                case 5: // Variable
                    variable = Global.Instance.Variables.GetData(data.Pages[pageIndex].DeathTrigger[1]);
                    if (variable != null)
                    {
                        switch (data.Pages[pageIndex].DeathTrigger[2])
                        {
                            case 0:
                                variable.Value = data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 1:
                                variable.Value += data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 2:
                                variable.Value -= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 3:
                                variable.Value *= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 4:
                                variable.Value /= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 5:
                                variable.Value = (int)Math.Pow((double)variable.Value, (double)data.Pages[pageIndex].DeathTrigger[3]);
                                break;
                            case 6:
                                variable.Value %= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                        }
                    }
                    Animation.BeginErase = true;
                    BeginErase = !data.Pages[pageIndex].DontErase;
                    Animation.EraseFrames = EraseFrames = frames;
                    break;
                case 6: // Local Variable
                    variable = Variables.GetData(data.Pages[pageIndex].DeathTrigger[1]);
                    if (variable != null)
                    {
                        switch (data.Pages[pageIndex].DeathTrigger[2])
                        {
                            case 0:
                                variable.Value = data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 1:
                                variable.Value += data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 2:
                                variable.Value -= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 3:
                                variable.Value *= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 4:
                                variable.Value /= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                            case 5:
                                variable.Value = (int)Math.Pow((double)variable.Value, (double)data.Pages[pageIndex].DeathTrigger[3]);
                                break;
                            case 6:
                                variable.Value %= data.Pages[pageIndex].DeathTrigger[3];
                                break;
                        }
                    }
                    Animation.BeginErase = true;
                    BeginErase = !data.Pages[pageIndex].DontErase;
                    Animation.EraseFrames = EraseFrames = frames;
                    break;
                case 7: // Event Switch
                    Global.SetEventSwitch(data.Pages[pageIndex].DeathTrigger[1], MapID, ID, (data.Pages[pageIndex].DeathTrigger[2] == 0));
                    Animation.BeginErase = true;
                    BeginErase = !data.Pages[pageIndex].DontErase;
                    Animation.EraseFrames = EraseFrames = frames;
                    break;
            }

            if (BeginErase && Body != null)
                Body.IgnoreCollisionWith(Global.Instance.Player[0].Body);
        }
        /// <summary>
        /// Checks if the target is far.
        /// </summary>
        /// <returns></returns>
        public bool TargetIsFar(out float range)
        {
            range = RangeOf(Target);
            return (range > Math.Max(data.Pages[pageIndex].HearRange, data.Pages[pageIndex].SeeRange) &&
                !data.Pages[pageIndex].LockOnTarget);
        }
        /// <summary>
        /// Animate
        /// </summary>
        /// <param name="eventAction"></param>
        public int Animate(EventAction eventAction, int id)
        {
            int displayTime = 0;
            // Play Attack Animation
            ActionIndex = eventAction;
            if (CurrentAnimation != null && id > -1 && Battler.Actions[(int)eventAction] != Animation.Action.ID)
            {
                Animation.Setup(CurrentAnimation.Actions.GetData(id), ActionIndex);
                SetupCollisionBody();
                Animation.InstantStart(CurrentAnimation.Actions.GetData(Battler.Actions[(int)EventAction.Idle]), eventAction, EventAction.Idle);
                displayTime = Animation.GetDisplayTime();
            }
            if (!Animation.IsAnimating)
                Animation.InstantStart(CurrentAnimation.Actions.GetData(Battler.Actions[(int)EventAction.Idle]), eventAction, EventAction.Idle);
            // Start Anchored Animations
            StartAnchoredAnimations();

            return displayTime;
        }
        /// <summary>
        /// Animate
        /// </summary>
        /// <param name="eventAction"></param>
        public void Animate(EventAction eventAction)
        {
            if (eventAction != ActionIndex || !Animation.IsAnimating)
            {
                ActionIndex = eventAction;
                if (CurrentAnimation != null && Battler.Actions[(int)eventAction] > -1 && Battler.Actions[(int)eventAction] != Animation.Action.ID)
                {
                    Animation.Setup(CurrentAnimation.Actions.GetData(Battler.Actions[(int)eventAction]), ActionIndex);
                    SetupCollisionBody();
                }
                Animation.InstantStart(CurrentAnimation.Actions.GetData(Battler.Actions[(int)EventAction.Idle]), eventAction, EventAction.Idle);
                // Start Anchored Animations
                StartAnchoredAnimations();
            }
        }
        /// <summary>
        /// Animate
        /// </summary>
        /// <param name="eventAction"></param>
        public void AnimateDeath(EventAction eventAction)
        {
            if (eventAction != ActionIndex || !Animation.IsAnimating)
            {
                ActionIndex = eventAction;
                if (CurrentAnimation != null && Battler.Actions[(int)eventAction] > -1 && Battler.Actions[(int)eventAction] != Animation.Action.ID)
                {
                    Animation.Setup(CurrentAnimation.Actions.GetData(Battler.Actions[(int)eventAction]), ActionIndex);
                    SetupCollisionBody();
                }
                Animation.Start(eventAction);
                // Start Anchored Animations
                StartAnchoredAnimations();
            }
        }
        /// <summary>
        /// Animate
        /// </summary>
        /// <param name="eventAction"></param>
        public void AnimateStill(EventAction eventAction)
        {
            if (eventAction != ActionIndex || !Animation.IsAnimating)
            {
                ActionIndex = eventAction;
                if (CurrentAnimation != null && Battler.Actions[(int)eventAction] > -1)
                    Animation.Setup(CurrentAnimation.Actions.GetData(Battler.Actions[(int)eventAction]), ActionIndex);
                if (CurrentAnimation != null)
                    Animation.StartStill();
                SetupCollisionBody();
                // Start Anchored Animations
                StartAnchoredAnimations();
            }
        }
        /// <summary>
        /// Add animation
        /// </summary>
        /// <param name="animation"></param>
        internal void AddAnimation(AnimationProcessor animation)
        {
            Animations.Add(animation);
        }
        #endregion
    }
}