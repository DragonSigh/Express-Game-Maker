//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the event data.
    /// </summary>

    public class EventData : IGameData
    {
        /// <summary>
        /// Name of the data
        /// </summary>        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The id
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
        /// The map id
        /// </summary>        
        public int MapID;
        /// <summary>
        /// The unique id
        /// </summary>
        public int TemplateID;
        /// <summary>
        /// Position
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// Pages
        /// </summary>
        public List<EventPageData> Pages;
        /// <summary>
        /// Variables
        /// </summary>
        public Dictionary<int, VariableData> Variables = new Dictionary<int, VariableData>();
        /// <summary>
        /// Switches
        /// </summary>
        public Dictionary<int, SwitchData> Switches = new Dictionary<int, SwitchData>();
        /// <summary>
        /// Initial Rotation of the Event
        /// </summary>
        public int Rotation = 0;
        /// <summary>
        /// Is this event linked to parent?
        /// </summary>
        public bool LinkToParent;
    }

    /// <summary>
    /// Stores the event page data.
    /// </summary>

    public class EventPageData : IEventProgram
    {
        /// <summary>
        /// Name of the data
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
        public int AnimationID
        {
            get { return animationID; }
            set { animationID = value; }
        }
        int animationID = -1;

        public int ActionID
        {
            get { return actionID; }
            set { actionID = value; }
        }
        int actionID = 0;

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        int direction = 0;

        public bool SwitchCondition
        {
            get { return switchCondition; }
            set { switchCondition = value; }
        }
        bool switchCondition = false;

        public bool VariableCondition
        {
            get { return variableCondition; }
            set { variableCondition = value; }
        }
        bool variableCondition = false;

        public bool LocalSwitchCondition
        {
            get { return localSwitchCondition; }
            set { localSwitchCondition = value; }
        }
        bool localSwitchCondition = false;

        public bool LocalVariableCondition
        {
            get { return localVariableCondition; }
            set { localVariableCondition = value; }
        }
        bool localVariableCondition = false;
        public TriggerConditions TriggerConditions
        {
            get { return actionTrigger; }
            set { actionTrigger = value; }
        }
        TriggerConditions actionTrigger = TriggerConditions.ActionButton;

        public EventProgramData InputTriggerProgram
        {
            get { return inputTriggerProgram; }
            set { inputTriggerProgram = value; }
        }
        EventProgramData inputTriggerProgram;

        public EventProgramData MouseTriggerProgram
        {
            get { return mouseTriggerProgram; }
            set { mouseTriggerProgram = value; }
        }
        EventProgramData mouseTriggerProgram;

        public bool MapCollisionTrigger
        {
            get { return mct; }
            set { mct = value; }
        }
        bool mct = false;

        public bool GlobalMouseTrigger
        {
            get { return gmt; }
            set { gmt = value; }
        }
        bool gmt = false;

        public List<int> TouchEventIDs
        {
            get { return touchEventIDs; }
            set { touchEventIDs = value; }
        }
        List<int> touchEventIDs = new List<int>();

        public List<VariableCondition> VariableConditions
        {
            get { return variableConditions; }
            set { variableConditions = value; }
        }
        List<VariableCondition> variableConditions = new List<VariableCondition>();

        public List<SwitchCondition> SwitchConditions
        {
            get { return switchConditions; }
            set { switchConditions = value; }
        }
        List<SwitchCondition> switchConditions = new List<SwitchCondition>();

        public List<LocalVariableCondition> LocalVariableConditions
        {
            get { return localVariableConditions; }
            set { localVariableConditions = value; }
        }
        List<LocalVariableCondition> localVariableConditions = new List<LocalVariableCondition>();

        public List<LocalSwitchCondition> LocalSwitchConditions
        {
            get { return localSwitchConditions; }
            set { localSwitchConditions = value; }
        }
        List<LocalSwitchCondition> localSwitchConditions = new List<LocalSwitchCondition>();

        public int[] EventSwitchConditions
        {
            get { return eventSwitchConditions; }
            set { eventSwitchConditions = value; }
        }
        int[] eventSwitchConditions = new int[] { 0, 0 };

        public bool EventSwitchCondition
        {
            get { return eventSwitchCondition; }
            set { eventSwitchCondition = value; }
        }
        bool eventSwitchCondition;

        /// <summary>
        /// Movement Programs
        /// </summary>
        public List<EventProgramData> MovementPrograms
        {
            get { return actions; }
            set { actions = value; }
        }
        List<EventProgramData> actions = new List<EventProgramData>();

        public bool RepeatMovement
        {
            get { return repeatMovement; }
            set { repeatMovement = value; }
        }
        bool repeatMovement;

        public bool SkipImpassable
        {
            get { return skipImpassable; }
            set { skipImpassable = value; }
        }
        bool skipImpassable;
        /// <summary>
        /// The move speed of the event. The higher the slower.
        /// </summary>
        public bool IgnoreHills
        {
            get { return ignoreHills; }
            set { ignoreHills = value; }
        }
        bool ignoreHills = true;
        /// <summary>
        /// Enabling frequency will override any animation's frame display time.
        /// </summary>
        public bool EnableFrequency
        {
            get { return enableFreq; }
            set { enableFreq = value; }
        }
        bool enableFreq = false;
        /// <summary>
        /// Gets or sets the frequency of the event.
        /// </summary>
        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }
        int frequency = 8;

        #region Battle Settings
        public int Enemy
        {
            get { return enemyID; }
            set { enemyID = value; }
        }
        int enemyID = -1;

        public AttackCondition AttackCondition
        {
            get { return attackCondition; }
            set { attackCondition = value; }
        }
        AttackCondition attackCondition = AttackCondition.OnSeeOrHear;
        public int SeeRange
        {
            get { return seeRange; }
            set { seeRange = value; }
        }
        int seeRange = 640;

        public int HearRange
        {
            get { return hearRange; }
            set { hearRange = value; }
        }
        int hearRange = 320;
        public int BattleSpeed
        {
            get { return battleSpeed; }
            set { battleSpeed = value; }
        }
        int battleSpeed = 2;

        public int Respawn
        {
            get { return respawn; }
            set { respawn = value; }
        }
        int respawn = 0;

        public bool LockOnTarget
        {
            get { return lockOnTarget; }
            set { lockOnTarget = value; }
        }
        bool lockOnTarget = false;

        public List<int> BattleDirections
        {
            get { return battleDirections; }
            set { battleDirections = value; }
        }
        List<int> battleDirections;

        public List<int> Hostiles
        {
            get { return hostiles; }
            set { hostiles = value; }
        }
        List<int> hostiles;

        public int[] DeathTrigger
        {
            get { return deathTrigger; }
            set { deathTrigger = value; }
        }
        int[] deathTrigger;

        public int AttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        int attackSpeed;

        public int BattleMoveDist
        {
            get { return battleMoveDist; }
            set { battleMoveDist = value; }
        }
        int battleMoveDist;
        #endregion

        public int ParticleID;

        public int Speed;

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

        public bool SyncAngleToRotation;

        public bool RushTarget;

        public bool DontErase;

        public bool PassThrough;

        public int Cursor;

        public bool IsMovingPlatform;

        public bool IsFixedRotation;


        public bool CustomGravity;
        public Vector2 Gravity;

        public List<AttachmentJoint> Attachments;

        public List<int> TouchTemplateEventIDs;
    }


    public class AttachmentJoint : IGameData
    {
        public override string Name { get; set; }
        public override int ID { get; set; }
        public override int Category { get; set; }

        public int AttachmentID;
        public AttachmentType Type;
        public Vector2[] Vectors;
        public float[] Numbers;
        public bool[] Booleans;

        internal bool IsSensor()
        {
            switch (Type)
            {
                case AttachmentType.Revolute:
                    return Booleans[3];
                case AttachmentType.Line:
                    return Booleans[2];
                case AttachmentType.Distance:
                    return Booleans[1];
            }
            return false;
        }

        internal bool SyncPosition()
        {
            switch (Type)
            {
                case AttachmentType.Revolute:
                    return Booleans[4];
                case AttachmentType.Line:
                    return Booleans[3];
                case AttachmentType.Distance:
                    return Booleans[2];
            }
            return false;
        }

        internal bool SyncAngle()
        {
            switch (Type)
            {
                case AttachmentType.Revolute:
                    return Booleans[5];
                case AttachmentType.Line:
                    return Booleans[4];
                case AttachmentType.Distance:
                    return Booleans[3];
            }
            return false;
        }

        internal Vector2 OffsetPosition()
        {
            //switch (Type)
            //{
            //    case AttachmentType.Revolute:
            //        return Vectors[0];
            //    case AttachmentType.Line:
            //        return Vectors[0];
            //    case AttachmentType.Distance:
            //        return Vectors[0];
            //}
            return Vector2.Zero;
        }
    }

    public enum AttachmentType
    {
        Revolute,
        Line,
        Distance
    }


    public enum AttackCondition
    {
        OnSeeOrHear,
        OnSee,
        OnHear,
        AllyAttacked,
        DoesntAttack
    }

    public enum TriggerConditions
    {
        ActionButton,
        Collision,
        AutorunOnce,
        AutorunLoop,
        Mouse,
        MouseOver,
        Input,
        BackgroundProcess,
        ProjectileCollision
    }
}
