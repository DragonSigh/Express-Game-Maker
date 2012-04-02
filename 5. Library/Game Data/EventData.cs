using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the event data.
    /// </summary>
    [Serializable]
    public class EventData : IGameData, IEvent
    {
        /// <summary>
        /// Name of the data
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The id
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
        /// The map id
        /// </summary>
        [Browsable(false)]
        public int MapID
        {
            get { return mapid; }
            set { mapid = value; }
        }
        int mapid = -1;
        /// <summary>
        /// The unique id
        /// </summary>
        [Browsable(false)]
        public int TemplateID
        {
            get { return uniqueid; }
            set { uniqueid = value; }
        }
        int uniqueid = -1;
        /// <summary>
        /// Position
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position = new Vector2(0, 0);
        /// <summary>
        /// Pages
        /// </summary>
        public List<EventPageData> Pages
        {
            get { return pages; }
            set { pages = value; }
        }
        List<EventPageData> pages = new List<EventPageData>();
        /// <summary>
        /// Variables
        /// </summary>
        public Dictionary<int, VariableData> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
        Dictionary<int, VariableData> variables = new Dictionary<int, VariableData>();
        /// <summary>
        /// Switches
        /// </summary>
        public Dictionary<int, SwitchData> Switches
        {
            get { return switches; }
            set { switches = value; }
        }
        Dictionary<int, SwitchData> switches = new Dictionary<int, SwitchData>();


        public int Rotation = 0;

        public bool LinkToParent;

        [ContentSerializerIgnore, DoNotSerialize]
        public int SelectedPage
        {
            get { return sp; }
            set { sp = value; }
        }
        int sp = -1;

        internal System.Drawing.RectangleF GetRectangle(int gridWidth, int gridHeight)
        {
            if (Pages.Count > 0)
            {
                AnimationData ani = Global.GetData<AnimationData>(Pages[0].AnimationID, GameData.Animations);
                if (ani != null)
                {
                    AnimationAction act = Global.GetData<AnimationAction>(Pages[0].ActionID, ani.Actions);
                    if (act != null)
                    {
                        return new System.Drawing.RectangleF(Position.X, Position.Y, act.CanvasSize.X, act.CanvasSize.Y + 12);
                    }
                }
            }
            return new System.Drawing.RectangleF(Position.X, Position.Y, gridWidth, gridHeight);
        }
        internal void SetOffSet(out float mouseOffx, out float mouseOffy, Vector2 point)
        {
            mouseOffx = point.X - position.X;
            mouseOffy = point.Y - position.Y;
        }


        internal TileData Clone()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the name of the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }

        internal Vector2 GetMiddleCenter(Vector2 vector2)
        {
            Vector2 center = new Vector2(position.X + vector2.X / 2, position.Y + vector2.Y / 2);

            return center;
        }

        internal Vector2 GetMiddleRight(Vector2 size)
        {
            Vector2 center = new Vector2(position.X + (size.X / 2), position.Y + (size.Y / 2));
            Vector2 pos = center;
            pos.X += 12;
            pos.Y -= 4;
            return new Vector2(ExMath.rotatePoint(center, pos, Rotation).X + 4, ExMath.rotatePoint(center, pos, Rotation).Y + 4);
        }

        internal System.Drawing.RectangleF GetTopLeft(Vector2 size)
        {
            Vector2 center = new Vector2(position.X + (size.X / 2), position.Y + (size.Y / 2));
            Vector2 pos = new Vector2(position.X + (size.X / 2) + 4, position.Y + (size.Y / 2));
            pos.X += 12;
            pos.Y -= 4;
            return new System.Drawing.RectangleF(ExMath.rotatePoint(center, pos, Rotation).X, ExMath.rotatePoint(center, pos, Rotation).Y, 8, 8);
        }

        internal System.Drawing.RectangleF GetMiddleLeft(Vector2 vector2)
        {
            Vector2 center = new Vector2(position.X + vector2.X / 2, position.Y + vector2.Y / 2);

            return new System.Drawing.RectangleF(center.X - 4, center.Y - 4, 8, 8);
        }

        [NonSerialized, ContentSerializerIgnore]
        public Vector2 Canvas;
    }

    /// <summary>
    /// Stores the event page data.
    /// </summary>
    [Serializable]
    public class EventPageData : IEventProgram
    {
        /// <summary>
        /// Name of the data
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
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
        bool eventSwitchCondition = false;

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
        List<int> battleDirections = new List<int>() { 0, 1, 2, 3 };

        public List<int> Hostiles
        {
            get { return hostiles; }
            set { hostiles = value; }
        }
        List<int> hostiles = new List<int>();

        public int[] DeathTrigger
        {
            get { return deathTrigger; }
            set { deathTrigger = value; }
        }
        int[] deathTrigger = new int[] { 0, 0, 0, 0 };

        public int AttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        int attackSpeed = 30;

        public int BattleMoveDist
        {
            get { return battleMoveDist; }
            set { battleMoveDist = value; }
        }
        int battleMoveDist = 64;
        #endregion

        public int ParticleID = -1;

        public int Speed = 2;

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
        public float MomentOfInertia = 200;

        public bool SyncAngleToRotation;

        public bool RushTarget;

        public bool DontErase;

        public bool PassThrough;

        public int Cursor = -1;

        public bool IsMovingPlatform;

        public bool IsFixedRotation;

        public bool CustomGravity;
        public Vector2 Gravity;

        public List<AttachmentJoint> Attachments = new List<AttachmentJoint>();

        public List<int> TouchTemplateEventIDs = new List<int>();

        internal ParticleSystemData GetParticle(GraphicsDevice device, ContentManager manager)
        {
            return null;
            if (pdata == null)
            {
                pdata = Global.GetData<ParticleSystemData>(ParticleID, GameData.ParticleSystems);
                pdata = Global.Duplicate<ParticleSystemData>(pdata);

                //foreach (ParticleEmitter emitter in pdata.Emitters)
                //{
                //    emitter.Setup(device, manager, pdata);
                //}

            }
            return pdata;
        }
        ParticleSystemData pdata;
    }

    [Serializable]
    public class AttachmentJoint : IGameData
    {
        public override string Name { get; set; }
        public override int ID { get; set; }
        public override int Category { get; set; }

        public int AttachmentID;
        public AttachmentType Type = AttachmentType.Revolute;
        public Vector2[] Vectors = new Vector2[6] { Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero };
        public float[] Numbers = new float[6] { 0, 0, 0, 0, 0, 0 };
        public bool[] Booleans = new bool[6] { false, false, false, false, false, false };
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
