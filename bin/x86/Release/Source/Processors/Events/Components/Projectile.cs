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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision;
namespace EGMGame.Processors
{
    /// <summary>
    /// Childs of projectiles
    /// </summary>

    public class Projectile : Drawable
    {
        /// <summary>
        /// Settings
        /// </summary>
        public ProjectileData Data;
        public int LifeTimeCounter, DecayFrames;
        public AnimationProcessor Animation = new AnimationProcessor();
        public AnimationProcessor HitAnimation = new AnimationProcessor();
        public bool Hit = false;
        public float Impulse;
        public float Force;
        // Target
        protected EventProcessor Target;
        public Vector2 TargetVector;
        // Owner Battler
        public EventProcessor Owner;
        public IBattler OwnerBattler;
        protected List<int> Hostiles;
        // Equipment
        public EquipmentData Equipment;
        public SkillData Skill;
        // Position
        public override Vector2 Position
        {
            get
            {
                if (BodyExists)
                {
                    NativePosition = Body.Position;
                    return ConvertUnits.ToDisplayUnits(Body.Position);
                }
                return NativePosition;
            }
            set
            {
                if (BodyExists)
                    Body.Position = value;
                NativePosition = value;
            }
        }
        protected bool BodyExists = false;
        public Vector2 NativePosition = Vector2.Zero;
        // Direction
        public int Angle;
        public int StartAngle = 0;
        // Fixture
        public Body Body;
        // Program
        public List<EventProgramData> Programs;
        public int programIndex;
        public bool RepeatProgram;
        public bool WaitProgram;
        public int Wait = 0;
        // Movement
        public bool isMoving;
        public Vector2 newPosition = Vector2.Zero;
        public ForceType ForceType = ForceType.Force;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public Projectile()
        { }
        /// <summary>
        /// Create Projectile
        /// </summary>
        /// <param name="data"></param>
        /// <param name="owner"></param>
        /// <param name="target"></param>
        /// <param name="equipment"></param>
        /// <param name="hostileList"></param>
        public virtual Projectile Create(ProjectileData data, EventProcessor owner, EventProcessor target, EquipmentData equipment, List<int> hostileList)
        {
            return this;
        }
        /// <summary>
        /// Create Projectile
        /// </summary>
        /// <param name="data"></param>
        /// <param name="owner"></param>
        /// <param name="target"></param>
        /// <param name="skill"></param>
        /// <param name="hostileList"></param>
        public virtual Projectile Create(ProjectileData data, EventProcessor owner, EventProcessor target, SkillData skill, List<int> hostileList)
        {
            return this;
        }
    }


    public enum ForceType
    {
        Force,
        Impulse,
        Torque,
        AngularImpulse
    }
}