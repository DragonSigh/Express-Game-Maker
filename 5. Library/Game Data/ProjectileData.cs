//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EGMGame.Library
{
    [Serializable]
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


    [Serializable]
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
        public ProjectileDirectionType Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        ProjectileDirectionType direction = 0;

        public int AnimationID
        {
            get { return animationID; }
            set { animationID = value; }
        }
        int animationID = 0;

        public int ActionID
        {
            get { return actionID; }
            set { actionID = value; }
        }
        int actionID = -1;

        public int HitAnimationID
        {
            get { return hitAnimation; }
            set { hitAnimation = value; }
        }
        int hitAnimation = -1;

        public int HitActionID
        {
            get { return hitAction; }
            set { hitAction = value; }
        }
        int hitAction = -1;

        public bool OnHitDecay // False = Animaition, True = Frames
        {
            get { return onHitDecay; }
            set { onHitDecay = value; }
        }
        bool onHitDecay = false;

        public int DecayFrames
        {
            get { return decayFrames; }
            set { decayFrames = value; }
        }
        int decayFrames = 60;

        public int HeightPass
        {
            get { return heightpass; }
            set { heightpass = value; }
        }
        int heightpass;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        int speed = 4;

        public int LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }
        int lifeTime = 300; // Frames

        public bool LockOnTarget
        {
            get { return lockOnTarget; }
            set { lockOnTarget = value; }
        }
        bool lockOnTarget = false;

        public bool DisableMapCollision
        {
            get { return disableColMap; }
            set { disableColMap = value; }
        }
        bool disableColMap = false;

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

        public float Mass = 1f;
        public float Force = 1f;
        public float LinearDrag = 7.0f;
        public float RotationalDrag = 1.0f;
        public float Friction;
        public float Bounce;
        public float Impulse = 1f;
        public float MomentOfInertia;

        public float Knockback = 0;
        public int EffectRadius = 1;
        public int Angle;
        public int TargetVarX;
        public int TargetVarY;
        public int TargetAngle;

        public bool Repeat;

        public List<EventProgramData> Programs = new List<EventProgramData>();

        public bool SyncAngleToRotation;

        public bool FriendlyFire;

        public int OffsetAngle;

        public Vector2 OffsetPosition;

        public bool ProjectileCollision;

        public int UseAnchor = 1;
        public int AnchorTo = 1;

        public int IncreaseEffectParamater;

        public bool EnvironmentalCollision;

        public bool TrackingEnabled;

        public bool IsFixedRotation;

        public bool CustomGravity;
        public Vector2 Gravity;
        public int ProjectileType;
        public int StartImage = -1;
        public int CenterImage = -1;
        public int EndImage = -1;
        public int LaserDirection;
        public int LaserDamageRate = 10;
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
