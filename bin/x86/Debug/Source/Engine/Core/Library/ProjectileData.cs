//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EGMGame.Library
{
    
    public class ProjectileGroupData : IGameData
    {
        /// <summary>
        /// Name of the animation.
        /// </summary>
        public override string Name
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
        /// The category the data is in. Usage is optional.
        /// </summary>
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// Stores the projectil projectiles
        /// </summary>
        public List<ProjectileData> Projectiles
        {
            get { return projectiles; }
            set { projectiles = value; }
        }
        List<ProjectileData> projectiles = new List<ProjectileData>();

        /// <summary>
        /// String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }


    public class ProjectileData : IGameData
    {
        /// <summary>
        /// Name of the animation.
        /// </summary>
        public override string Name
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
        /// The category the data is in. Usage is optional.
        /// </summary>
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// Direction
        /// </summary>
        public ProjectileDirectionType Direction;

        public int AnimationID;

        public int ActionID;

        public int HitAnimationID;

        public int HitActionID;

        public bool OnHitDecay; // False = Animaition, True = Frames

        public int DecayFrames;

        public int HeightPass;

        public int Speed;

        public int LifeTime; // pixels
        /// <summary>
        /// Movement Type
        /// </summary>
        public bool LockOnTarget;

        public bool DisableMapCollision;
        public bool IsStatic;
        public bool IgnoreGravity;
        public bool CustomMass;
        public bool CustomForce;
        public bool CustomLinearDrag;
        public bool CustomRotationalDrag;
        public bool CustomFriction;
        public bool CustomBounce;
        public bool CustomImpulse;
        public bool CustomMOI;

        public float Mass;
        public float Force;
        public float LinearDrag;
        public float RotationalDrag;
        public float Friction;
        public float Bounce;
        public float Impulse;
        public float MomentOfInertia;

        public float Knockback;
        public int EffectRadius;
        public int Angle;
        public int TargetVarX;
        public int TargetVarY;
        public int TargetAngle;

        public bool Repeat;

        public List<EventProgramData> Programs;

        public bool SyncAngleToRotation;

        public bool FriendlyFire;

        public int OffsetAngle;

        public Vector2 OffsetPosition;

        public bool ProjectileCollision;

        public int UseAnchor;
        public int AnchorTo;

        public int IncreaseEffectParamater;

        public bool EnvironmentalCollision;

        public bool TrackingEnabled;

        public bool IsFixedRotation;


        public bool CustomGravity;
        public Vector2 Gravity;
        public int ProjectileType;
        public int StartImage;
        public int CenterImage;
        public int EndImage;
        public int LaserDirection;
        public int LaserDamageRate;
        /// <summary>
        /// String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
    /// <summary>
    /// Movement Type
    /// </summary>
    public enum ProjectileDirectionType
    {
        User,
        Random,
        Custom,
        VariablePos,
        VariableAngle
    }
}
