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
        [XmlIgnore] // Gets or sets the event's data.
        public EventData Data
        {
            get { return (data != null ? data : ParentID > -1 ? data = Global.GetParentEvent(ParentID) : id > -1 ? data = Global.GetEvent(id) : data = GameData.Player); }
            set { data = value; }
        } EventData data;

        #region Field: ID, Type, Switches, Variables
        // Parent ID
        public int ParentID = -1;
        // Unique ID Count
        public int UniqueIDCount = 0;
        // Map ID
        public int MapID = -1;
        // IsPlayer, IsClone(in-game created event)
        public bool IsPlayer, IsClone = false;
        // Party
        public int PartyIndex = 0;
        #endregion

        #region Field: Event Program
        // Page Index
        public int pageIndex = -1;
        // Enabled
        public bool Enabled = true;
        // Collision
        [XmlIgnore]
        public Body Body, BattleBody;
        // Allow Movement
        public bool AllowMovement = true;
        // Event Collision
        public bool CollisionOn = true;
        // Direction Fix
        public bool DirectionFix = false;
        // Sync Angle to Rotation
        public bool SyncAngleToRotation;
        // Begin Erase
        public bool BeginErase = false;
        // Erase Frames
        public int EraseFrames = 0;
        #endregion

        #region Field: Position, Movements and Physics
        // Direction
        public int Angle;
        // Position
        public override Vector2 Position
        {
            get
            {
                if (Body != null && CurrentAction != null)
                    NativePosition = ConvertUnits.ToDisplayUnits(Body.Position);
                return NativePosition;
            }
            set
            {
                if (Body != null && CurrentAction != null)
                {
                    Body.Position = ConvertUnits.ToSimUnits(value);
                }
                NativePosition = value;

                if (Animation != null) Animation.Position = value;

            }
        }
        public Vector2 NativePosition = Vector2.Zero;
        public Vector2 OriginPosition
        {
            get
            {
                if (Body != null && CurrentAction != null)
                    return Body.Position;

                return Position;
            }
        }
        public Vector2 NextPosition
        {
            get
            {
                // TODO
                return OriginPosition;
            }
        }
        // Physics Settings
        public bool Static, UseImpulse, PassThrough, IsMovingPlatform, IgnoreGravity, IsFixedRotation, CustomGravity;
        public float Force, Impulse, Mass, LinearDrag, RotationalDrag, Friction, Bounce, MomentOfInertia;
        public Vector2 Gravity;
        private List<Joint> Joints = new List<Joint>();
        private List<EventProcessor> Attachments = new List<EventProcessor>();
        private Body AttachmentClone;
        private Vertices CollisionBody;
        // Moving
        public bool isMoving = false;
        public bool IsMoving
        {
            get
            {
                if (Body != null && !Body.IsStatic)
                    return Body.Moves;
                else
                    return isMoving;
            }
            set
            {
                isMoving = value;
            }
        }
        public bool isBattlerMoving;
        public bool IsJumping
        {
            get
            {
                int c = collisionList.Count;
                for (int i = 0; i < c; i++)
                {
                    if (collisionList[i].FixtureList != null && collisionList[i].BodyType != BodyType.Kinematic && !PassThrough)
                    {
                        if (collisionList[i].UserData is EventProcessor && ((EventProcessor)collisionList[i].UserData).PassThrough)
                            continue;

                        if (Collide(90, collisionList[i], (float)Body.Height / 2 + ConvertUnits.ToSimUnits(4), new float[] { 0, (float)Body.Width * 0.5f, (float)Body.Width * -0.5f }))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        collisionList.RemoveAt(i); c--; i--;
                    }

                }
                return true;
            }
        }
        public bool IsColliding
        {
            get { return collisionList.Count > 0; }
        }
        // New Position
        public Vector2 newPosition = Vector2.Zero;
        // Move Speed, Initial Rotation
        public int MoveSpeed;
        public float InitialRotation;
        // Gravity Point
        public GravityPoint GravityPoint;
        EventGravityController GravityController;
        // Pathfinding 
        public PathfindingPath Path = new PathfindingPath();
        // This Event's Movement Processor
        public MovementProcessor MovementProcessor;
        // This Event's Movement Processor
        public MovementProcessor ActiveMovementProcessor;
        // Movement Processors
        // To avoid lag, each movement processor is saved with the ID of the Event.
        public List<MovementProcessor> MovementProcessors = new List<MovementProcessor>();
        // Colliding Projectile
        public int CollidingProjectile = -1;
        #endregion

        #region Field: Animations And Actions And Effects
        // Animation Processor
        public AnimationProcessor Animation;
        // Current Animation
        public AnimationData CurrentAnimation;
        // Current Action
        public AnimationAction CurrentAction
        {
            get { return Animation.Action; }
        }
        // Equipment Animations
        public Dictionary<int, AnimationProcessor> EquipmentAnimations = new Dictionary<int, AnimationProcessor>();
        // Anchored Animations
        public Dictionary<int, AnimationProcessor> AnchoredAnimations = new Dictionary<int, AnimationProcessor>();
        // Action Index
        EventAction actionIndex = EventAction.Idle;
        public EventAction ActionIndex
        {
            get { return actionIndex; }
            set
            {
                if (actionIndex != EventAction.Idle && value == EventAction.Idle)
                {

                }
                actionIndex = value;
            }
        }
        // Animations to be displayed on this Event
        public List<AnimationProcessor> Animations = new List<AnimationProcessor>();
        // Particle Processor
        public ParticleSystemProcessor ParticleProcessor;
        // Shader Process
        public ShaderProcessor ShaderProcess = new ShaderProcessor();
        #endregion

        #region Constructors and Setup
        public EventProcessor()
        {
        }
        public EventProcessor(EventData eventData, int map_id)
        {
            data = eventData;
            id = data.ID;
            InitialRotation = data.Rotation;
            // Set Position
            Position = data.Position;
            if (data.LinkToParent)
            {
                ParentID = data.TemplateID;
                data = Global.GetParentEvent(ParentID);
            }
            IsPlayer = (data is PlayerData);
            MapID = map_id;
            Animation = new AnimationProcessor();
            Setup();
        }
        public EventProcessor(EventData eventData, int map_id, int _partyIndex)
        {
            id = eventData.ID;
            data = eventData;
            InitialRotation = data.Rotation;
            // Set Position
            Position = data.Position;
            if (data.LinkToParent)
            {
                ParentID = data.TemplateID;
                data = Global.GetParentEvent(ParentID);
            }
            PartyIndex = _partyIndex;
            IsPlayer = (data is PlayerData);
            MapID = map_id;
            Animation = new AnimationProcessor();
            Setup();
        }
        private void Setup()
        {
            try
            {
                MovementProcessor = new MovementProcessor();
                if (data != null)
                {
                    if (data is PlayerData && ((PlayerData)data).PartyList.Count > 0)
                    {
                        // Get Hero
                        Battler = Global.Instance.Party.Heroes[PartyIndex];
                    }
                    BattleState = BattleState.None;
                    // Switches
                    Switches = new Dictionary<int, SwitchData>();
                    Variables = new Dictionary<int, VariableData>();
                    foreach (SwitchData var in data.Switches.Values)
                        Switches.Add(var.ID, new SwitchData() { ID = var.ID, Category = var.Category, Name = var.Name, State = var.State });
                    // Switches
                    foreach (VariableData var in data.Variables.Values)
                        Variables.Add(var.ID, new VariableData() { ID = var.ID, Category = var.Category, Name = var.Name, Value = var.Value });
                    // Player Page Index
                    if (IsPlayer)
                    {
                        pageIndex = 0;
                        SetupPage(ref pageIndex);
                    }

                }
            }
            catch (Exception ex)
            {
                Error.Do(ex);
            }
        }
        public void SetHero(int _partyIndex)
        {
            PartyIndex = _partyIndex;
            // Get Hero
            Battler = Global.Instance.Party.Heroes[PartyIndex];
            if (Battler != null)
                Battler.SetupEquipmentAnimations(this);
            // Set Animation and Action
            SetAnimationAndAction();
            BattleState = BattleState.None;
        }
        /// <summary>
        /// Reset Player
        /// </summary>
        public void ResetPlayer()
        {
            DisposeBodies();
            isBattlerMoving = false;
            // Save Branch if empty
            labels.Clear();
            LastBranch.Clear();
            LastProgramIndex.Clear();
            pageIndex = 0;
            CurrentBranch = data.Pages[pageIndex];
            Position = data.Position;
            SetupCollisionBody();
        }
        #endregion

        #region Update: Event
        /// <summary>
        /// Update the event
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Update only if  data exists
            if (data != null && !BeginErase && !Erase && EraseFrames <= 0)
            {
                // Check For Platformers
                if (Body != null)
                {
                    int pc = platformerList.Count;
                    for (int i = 0; i < pc; i++)
                    {
                        if (!platformerList[i].Collide(Body))
                        {
                            platformerList.RemoveAt(i); i--; pc--;
                        }
                    }
                }
                // Wait
                if (waitFrames > 0)
                    waitFrames--;
                // Update the draw order depending on Y
                if (DrawOrder != (int)Position.Y && Animation.Action != null)
                {
                    DrawOrder = (int)Position.Y;
                }
                // Update Anchored Animations
                UpdateAnchoredAnimations(gameTime);
                // Check and Correct Collision
                if (Battler != null && !Animation.IsAnimating && Animation.Action != null && ActionIndex != Animation.ActionIndex)
                {
                    if (Battler.Actions[(int)ActionIndex] > -1 && Animation.Action.ID != Battler.Actions[(int)ActionIndex])
                        SetupCollisionBody();
                    ActionIndex = Animation.ActionIndex;
                }

                // Process Event Page
                ProcessEventPage(gameTime);

                if ((Global.Instance.AutorunID > -1 && UniqueID == Global.Instance.AutorunID) || Global.Instance.AutorunID == -1)
                {
                    if (Battler != null)
                        Battler.Update(gameTime, this);
                    // If this is player
                    if (IsPlayer)
                    {
                        if (PartyIndex == 0)
                            UpdatePlayer();
                        else
                            UpdateAlly();
                    }
                    // Check if enemy
                    if (Battler != null && Battler is EnemyProcessor)
                        UpdateEnemy(gameTime);
                }
                // Update Animation Position
                if (Body != null)
                {
                    Animation.Position.X = Position.X;
                    Animation.Position.Y = Position.Y;
                    Animation.Rotation = Body.Rotation;
                    if (SyncAngleToRotation)
                        SetAngle((int)MathHelper.ToDegrees(Body.Rotation) - 90, false);

                    if (AttachmentClone != null)
                    {
                        AttachmentClone.Position = Body.Position;
                        AttachmentClone.Rotation = Body.Rotation;
                    }

                    for (int i = 0; i < Attachments.Count; i++)
                    {
                        if (data.Pages[pageIndex].Attachments[i].SyncPosition()) // Sync Position
                        {
                            Attachments[i].Position = this.Position;
                        }
                        else
                        {
                            Attachments[i].Body.LinearVelocity = this.Body.LinearVelocity;
                            Attachments[i].Body.AngularVelocity = this.Body.AngularVelocity;
                        }
                        if (data.Pages[pageIndex].Attachments[i].SyncAngle()) // Sync Angle
                        {
                            Attachments[i].Angle = this.Angle;
                            Attachments[i].Animation.ApplyAngleToDirection(this.Angle);
                        }
                    }
                }
                else
                {
                    Animation.Position.X = Position.X;
                    Animation.Position.Y = Position.Y;
                }
                Animation.ApplyAngleToDirection(Angle);
                // Make sure the Body is inside map
                if (!Global.TransferPlayer)
                {
                    if (!Static && Position.X < 0)
                        Position = new Vector2(0, Position.Y);
                    if (!Static && Position.Y < 0)
                        Position = new Vector2(Position.X, 0);
                    if (!Static && Position.X > Global.Instance.CurrentMap.Data.Size.X)
                        Position = new Vector2(Global.Instance.CurrentMap.Data.Size.X, Position.Y);
                    if (!Static && Position.Y > Global.Instance.CurrentMap.Data.Size.Y)
                        Position = new Vector2(Position.X, Global.Instance.CurrentMap.Data.Size.Y);
                    if (IsPlayer &&
                        (Global.Instance.LockScreen.X > 0 ||
                        Global.Instance.LockScreen.Y > 0 ||
                        Global.Instance.LockScreen.Width > 0 ||
                        Global.Instance.LockScreen.Height > 0))
                    {
                        if (Position.X < Global.Instance.LockScreen.X)
                            Position = new Vector2(Global.Instance.LockScreen.X, Position.Y);
                        if (Position.Y < Global.Instance.LockScreen.Y)
                            Position = new Vector2(Position.X, Global.Instance.LockScreen.Y);
                        if (Position.X > Global.Instance.LockScreen.Width + Global.Instance.LockScreen.X)
                            Position = new Vector2(Global.Instance.LockScreen.Width + Global.Instance.LockScreen.X, Position.Y);
                        if (Position.Y > Global.Instance.LockScreen.Height + Global.Instance.LockScreen.Y)
                            Position = new Vector2(Position.X, Global.Instance.LockScreen.Height + Global.Instance.LockScreen.Y);

                    }
                }
                // Update Battle Hit Box
                if (BattleBody != null)
                {
                    BattleBody.Position = ConvertUnits.ToSimUnits(Position - Animation.CollisionCentroid + Animation.HitCentroid);
                    if (Body != null && pageIndex > -1 && data.Pages[pageIndex].SyncAngleToRotation)
                        BattleBody.Rotation = Body.Rotation;
                }

                if (ParticleProcessor != null)
                {
                    ParticleProcessor.Move(Position);
                    ParticleProcessor.Update(gameTime);
                }
            }
            else if (data != null && (BeginErase || EraseFrames > 0))
            {
                EraseFrames--;
                if (EraseFrames <= 0 || Animation.EraseFrames <= 0)
                {
                    // Erase Event
                    if (BeginErase)
                    {
                        Erase = true;
                        BeginErase = false;
                    }
                    EraseFrames = 0;
                }
                else
                {
                    // Update Animation Position
                    if (Body != null)
                    {
                        Body.BodyType = BodyType.Kinematic;
                        if (BattleBody != null)
                            BattleBody.BodyType = BodyType.Kinematic;
                        Animation.Position = Position;
                        Animation.Rotation = Body.Rotation;
                        if (SyncAngleToRotation)
                            SetAngle((int)MathHelper.ToDegrees(Body.Rotation) - 90, false);
                    }
                    else
                        Animation.Position = Position;
                    Animation.ApplyAngleToDirection(Angle);
                    Animation.Update(gameTime);
                }
            }
            // Update Animations
            int count = Animations.Count;
            for (int i = 0; i < count; i++)
            {
                Animations[i].Position = Animation.Position;
                Animations[i].Origin = Animation.Origin;
                Animations[i].Offset = Animation.Offset;
                Animations[i].Update(gameTime);

                if (!Animations[i].IsAnimating)
                {
                    Animations.RemoveAt(i); i--; count--;
                }
            }
            CollidingProjectile = -1;

            int c = collisionList.Count;
            for (int i = 0; i < c; i++)
            {
                if (this.Body == null || collisionList[i].IsDisposed || !collisionList[i].Collide(this.Body))
                {
                    collisionList.RemoveAt(i); i--; c--;
                }
            }
        }
        /// <summary>
        /// Update Anchored Animations
        /// </summary>
        private void UpdateAnchoredAnimations(GameTime gametime)
        {
            foreach (AnimationProcessor processor in EquipmentAnimations.Values)
            {
                // Set Action
                if (processor.ActionIndex != ActionIndex)
                    processor.Setup(processor.AnimationID, Battler.Actions[(int)ActionIndex], Animation.AnimationID, ActionIndex);

                if (processor.Action != null)
                {
                    processor.Update(gametime);
                }
            }
        }
        #endregion

        #region Method: Check if Event Program is Triggered
        /// <summary>
        /// Process Program Triggers
        /// Parallel Process
        /// AutoRun
        /// </summary>
        private void ProcessProgramTriggers()
        {
            // Auto-run or parallel process triggers
            if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.BackgroundProcess || data.Pages[pageIndex].TriggerConditions == TriggerConditions.AutorunLoop)
            {
                isProgramActive = true;
                if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.AutorunLoop)
                    Global.Instance.AutorunID = UniqueID;
            }
            // Action Trigger
            if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.ActionButton && Global.Instance.Player.Count > 0)
            {
                Keys key = InputState.KeysList[GameData.Player.Keys["Action"]];
                if (InputState.IsNewKeyPress(key, 0))
                    if (Global.Instance.Player[0].TouchInRangeOf(this, 2))
                        isProgramActive = true;

                Buttons button = InputState.ButtonsList[GameData.Player.Buttons["Action"]];
                if (InputState.IsNewButtonPress(button, 0))
                {
                    if (Global.Instance.Player[0].TouchInRangeOf(this, 2))
                    {
                        isProgramActive = true;
                    }
                }
            }
            // Mouse Trigger
            if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.Mouse)
            {
                if (CheckEventTriggerMouse(data.Pages[pageIndex].MouseTriggerProgram, data.Pages[pageIndex].GlobalMouseTrigger))
                {
                    isProgramActive = true;
                }
            }
            // Mouse Over
            if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.MouseOver)
            {
                if (this.Contains(new Vector2((float)Mouse.GetState().X, (float)Mouse.GetState().Y)))
                {
                    isProgramActive = true;
                }
            }
            // Input Trigger
            if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.Input)
            {
                if (CheckEventTriggerInput(data.Pages[pageIndex].InputTriggerProgram))
                {
                    isProgramActive = true;
                }
            }
        }
        /// <summary>
        /// Touch Range of
        /// </summary>
        /// <param name="eventProcessor"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool TouchInRangeOf(EventProcessor obj, int range)
        {
            if (Body != null)
            {
                if (obj.Body != null)
                {
                    return Collide(Angle, obj.Body, Body.Height + ConvertUnits.ToSimUnits(range), Body.Width * 0.5f, 0);
                    // Note: This is the most accurate way to get the distance between two objects,
                    // however, it must be optimized and improved before general use.
                    float _dist2 = Body.GetDistance(obj.Body);
                    return ConvertUnits.ToSimUnits(range) >= _dist2;

                    #region Comment Code
                    //Vector2 objAngle = (this.OriginPosition - obj.OriginPosition);

                    //Vector2 objDiff = new Vector2(0, 0);
                    //objDiff.X = (float)Math.Cos(objAngle.X) * (obj.Body.AABB.Width / 2);
                    //objDiff.Y = (float)Math.Sin(objAngle.Y) * (obj.Body.AABB.Height / 2);

                    //_dist -= (int)Vector2.Distance(thisDiff, objDiff);
                    #endregion
                }
            }
            int _dist = (int)Vector2.Distance(OriginPosition, obj.OriginPosition);
            return ConvertUnits.ToSimUnits(range) >= _dist;
        }
        /// <summary>
        /// Check button input
        /// </summary>
        /// <param name="eventProgramData"></param>
        private bool CheckEventTriggerInput(EventProgramData eventProgramData)
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
                            if (InputState.IsNewKeyPress(key, 0))
                                result = true;
                            break;
                        case 1: // Held
                            if (InputState.IsKeyHeld(key, 0))
                                result = true;
                            break;
                        case 2: // Released
                            if (InputState.IsNewKeyReleased(key, 0))
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
                            if (InputState.IsNewButtonPress(key, (int)eventProgramData.Value[6]))
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
                        case 3: // Move (Stick)
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
                return result;
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
            return false;
        }
        /// <summary>
        /// Check mouse input
        /// </summary>
        /// <param name="eventProgramData"></param>
        private bool CheckEventTriggerMouse(EventProgramData eventProgramData, bool global)
        {
            try
            {
                bool result = false;

                // Check if mouse is not over and not global
                if (!global && !this.Contains(new Vector2((float)Mouse.GetState().X, (float)Mouse.GetState().Y)))
                    return false;
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

                return result;
            }
            catch (Exception ex)
            {
                Error.Do(ex);
#if DEBUG && WINDOWS

#endif
            }
            return false;
        }
        /// <summary>
        /// Check if this coordinate is contained by the event's rectnagle
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns></returns>
        private bool Contains(Vector2 p)
        {
            if (CurrentAction != null)
            {
                Rectangle rect = new Rectangle((int)this.Position.X, (int)this.Position.Y - (int)CurrentAction.CanvasSize.Y, (int)CurrentAction.CanvasSize.X, (int)CurrentAction.CanvasSize.Y);
                // Get Mouse coordinates in camera offset
                Vector2 mouse = Global.Instance.ActiveCamera.GetTransformedPoint(p);

                if (rect.Contains((int)mouse.X, (int)mouse.Y))
                    return true;
            }
            return false;
        }
        #endregion

        #region Helper: Current Action Check
        /// <summary>
        /// Action Complete
        /// Called when an action is complete.
        /// </summary>
        /// <param name="type"></param>
        public void ActionComplete(ActionType type)
        {
            if (type == actionTakingPlace)
            {
                switch (actionTakingPlace)
                {
                    case ActionType.Tint:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Flash:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Shake:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Video:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.FindingPath:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.PictureTint:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.MovementProgram:
                        actionTakingPlace = ActionType.None;
                        break;
                }
            }
        }
        #endregion

        #region Method: Page Setup - Process, Clear, Setup Page
        /// <summary>
        /// Process Event Page
        /// </summary>
        /// <param name="gameTime"></param>
        private void ProcessEventPage(GameTime gameTime)
        {
            bool noPage = true;
            // Check Pages from reverse
            for (int index = data.Pages.Count - 1; index >= 0; index--)
            {
                if (PageActive(index))
                {
                    if (pageIndex != index)
                    {
                        SetupPage(ref index);
                    }
                    ProcessPage(index, gameTime);
                    noPage = false;
                    break;
                }
                else if (pageIndex == index)
                {
                    ClearPage(ref pageIndex);
                }
            }
            // If there is no active page, erase data
            if (noPage && !IsPlayer)
            {
                Battler = null;
            }
        }
        /// <summary>
        /// Clear Page
        /// </summary>
        /// <param name="pageIndex"></param>
        public void ClearPage(ref int pageIndex)
        {
            isBattlerMoving = false;
            // Save Branch if empty
            labels.Clear();
            LastBranch.Clear();
            // Set up movement
            MovementProcessors.Clear();
            // Set enemy data
            if (!IsPlayer)
                Battler = null;
            ParticleProcessor = null;
            // Check Trigger
            isProgramActive = false;
            // Dispose Fixture
            DisposeBodies();
            // Animaition Clear
            Animation.Clear();
            pageIndex = -1;
            // Clear Anchor Animations
            EquipmentAnimations.Clear();
            AnchoredAnimations.Clear();

            UniqueIDCount = 0;
        }
        /// <summary>
        /// Setup the page
        /// </summary>
        /// <param name="index"></param>
        public void SetupPage(ref int index)
        {
            isBattlerMoving = false;
            Animation.Clear();
            if (!IsPlayer)
                Battler = null;
            // Save Branch if empty
            labels.Clear();
            LastBranch.Clear();
            LastProgramIndex.Clear();
            UniqueIDCount = 0;
            pageIndex = index;
            CurrentBranch = data.Pages[pageIndex];
            // Set up movement
            MovementProcessors.Clear();
            MovementProcessor.Setup(this, true, data.Pages[pageIndex].MovementPrograms, data.Pages[pageIndex].RepeatMovement, data.Pages[pageIndex].SkipImpassable, false, this);
            // Set data
            MoveSpeed = data.Pages[pageIndex].Speed;
            Angle = Global.DirectionToAngle(data.Pages[pageIndex].Direction);
            PassThrough = data.Pages[pageIndex].PassThrough;
            // Frequency
            Animation.EnableFrequency = data.Pages[pageIndex].EnableFrequency;
            Animation.Frequency = data.Pages[pageIndex].Frequency;
            // Rotation
            SyncAngleToRotation = data.Pages[pageIndex].SyncAngleToRotation;
            // Physics
            Static = data.Pages[pageIndex].IsStatic;
            IgnoreGravity = data.Pages[pageIndex].IgnoreGravity;
            CustomGravity = data.Pages[pageIndex].CustomGravity;
            Gravity = data.Pages[pageIndex].Gravity;
            Mass = (data.Pages[pageIndex].CustomMass ? data.Pages[pageIndex].Mass : Global.Project.Mass);
            LinearDrag = (data.Pages[pageIndex].CustomLinearDrag ? data.Pages[pageIndex].LinearDrag : Global.Project.LinearDrag);
            RotationalDrag = (data.Pages[pageIndex].CustomRotationalDrag ? data.Pages[pageIndex].RotationalDrag : Global.Project.RotationalDrag);
            Impulse = (data.Pages[pageIndex].CustomImpulse ? data.Pages[pageIndex].Impulse : Global.Project.Impulse);
            Bounce = (data.Pages[pageIndex].CustomBounce ? data.Pages[pageIndex].Bounce : Global.Project.Bounce);
            Friction = (data.Pages[pageIndex].CustomFriction ? data.Pages[pageIndex].Friction : Global.Project.Friction);
            Force = (data.Pages[pageIndex].CustomForce ? data.Pages[pageIndex].Force : Global.Project.Force);
            MomentOfInertia = data.Pages[pageIndex].MomentOfInertia;
            IsFixedRotation = data.Pages[pageIndex].IsFixedRotation;

            IsMovingPlatform = data.Pages[pageIndex].IsMovingPlatform;
            // Clear Anchor Animations
            EquipmentAnimations.Clear();
            AnchoredAnimations.Clear();
            // Set enemy data
            SetupBattler(null);

            SetAnimationAndAction();

            if (ParticleProcessor == null && data.Pages[pageIndex].ParticleID > -1)
                ParticleProcessor = new ParticleSystemProcessor();
            if (data.Pages[pageIndex].ParticleID > -1)
                ParticleProcessor.Setup(data.Pages[pageIndex].ParticleID, 0, Position);
            else if (ParticleProcessor != null)
                ParticleProcessor = null;
            // Check Trigger
            if (data.Pages[index].TriggerConditions == TriggerConditions.AutorunOnce)
            {
                isProgramActive = true;
                Global.Instance.AutorunID = UniqueID;
            }
            if (data is PlayerData)
                SetAngle(Global.DirectionToAngle(((PlayerData)data).StartDirection), true);

            if (SyncAngleToRotation && Body != null)
            {
                Body.Rotation = MathHelper.ToRadians(Angle + 90);
                Body.ResetTorque();
            }

            if (InitialRotation > 0)
            {
                if (Body != null)
                {
                    Body.Rotation += MathHelper.ToRadians(InitialRotation);
                    Animation.Rotation += InitialRotation;
                }
                else
                {
                    Animation.Rotation += InitialRotation;
                }
                InitialRotation = 0;
            }
        }
        /// <summary>
        /// Returns whether if the page is active
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool PageActive(int index)
        {
            bool activate = true;
            // Check Switches
            if (data.Pages[index].SwitchCondition)
            {
                for (int csIndex = 0; csIndex < data.Pages[index].SwitchConditions.Count; csIndex++)
                {
                    if (Global.Switch(data.Pages[index].SwitchConditions[csIndex].SwitchID) == data.Pages[index].SwitchConditions[csIndex].State)
                    {
                        activate = true;
                        if (data.Pages[index].SwitchConditions[csIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].SwitchConditions[csIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Variables
            if (data.Pages[index].VariableCondition)
            {
                for (int cvIndex = 0; cvIndex < data.Pages[index].VariableConditions.Count; cvIndex++)
                {
                    if (CheckVariableCondition(data.Pages[index].VariableConditions[cvIndex]))
                    {
                        activate = true;
                        if (data.Pages[index].VariableConditions[cvIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].VariableConditions[cvIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Local Switches
            if (data.Pages[index].LocalSwitchCondition)
            {
                for (int clsIndex = 0; clsIndex < data.Pages[index].LocalSwitchConditions.Count; clsIndex++)
                {
                    if (Switches[data.Pages[index].LocalSwitchConditions[clsIndex].SwitchID].State == data.Pages[index].LocalSwitchConditions[clsIndex].State)
                    {
                        activate = true;
                        if (data.Pages[index].LocalSwitchConditions[clsIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].LocalSwitchConditions[clsIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Local Variables
            if (data.Pages[index].LocalVariableCondition)
            {
                for (int cvIndex = 0; cvIndex < data.Pages[index].LocalVariableConditions.Count; cvIndex++)
                {
                    if (CheckVariableCondition(data.Pages[index].LocalVariableConditions[cvIndex]))
                    {
                        activate = true;
                        if (data.Pages[index].LocalVariableConditions[cvIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].LocalVariableConditions[cvIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Event Switch
            if (data.Pages[index].EventSwitchCondition)
            {
                if (Global.EventSwitch(data.Pages[index].EventSwitchConditions[0], MapID, ID) == (bool)((int)data.Pages[index].EventSwitchConditions[1] == 0))
                    activate = true;
                else
                    activate = false;
            }
            // Check Screen Location

            // Return result
            return activate;
        }
        /// <summary>
        /// Checks the variable condition
        /// </summary>
        /// <param name="variableCondition"></param>
        /// <returns></returns>
        private bool CheckVariableCondition(VariableCondition variableCondition)
        {
            float variable = Global.Instance.Variables[variableCondition.VariableID].Value;
            switch (variableCondition.Type)
            {
                case 0: // Number
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variableCondition.Value == variable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != variableCondition.Value)
                                return true;
                            break;
                    }
                    break;
                case 1: // Variable
                    float compVariable = Global.Instance.Variables[variableCondition.CompVariableID].Value;
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variable == compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= compVariable)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != compVariable)
                                return true;
                            break;
                    }
                    break;
            }
            return false;
        }
        /// <summary>
        /// Check the local variable's condition
        /// </summary>
        /// <param name="localVariableCondition"></param>
        /// <returns></returns>
        private bool CheckVariableCondition(LocalVariableCondition variableCondition)
        {
            float variable = Variables[variableCondition.VariableID].Value;
            switch (variableCondition.Type)
            {
                case 0: // Number
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variableCondition.Value == variable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != variableCondition.Value)
                                return true;
                            break;
                    }
                    break;
                case 1: // Variable
                    float compVariable = Global.Instance.Variables[variableCondition.CompVariableID].Value;
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variable == compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= compVariable)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != compVariable)
                                return true;
                            break;
                    }
                    break;
            }
            return false;
        }
        /// <summary>
        /// Processes the programs in the page
        /// </summary>
        /// <param name="index"></param>
        private void ProcessPage(int index, GameTime gameTime)
        {
            if ((Global.Instance.AutorunID > -1 && UniqueID == Global.Instance.AutorunID) || Global.Instance.AutorunID == -1)
            {
                // Process trigger if not active
                if (!isProgramActive) ProcessProgramTriggers();
                // Check waiting time
                if (waitFrames <= 0)
                {
                    if (MovementProcessors.Count > 0)
                    {
                        MovementProcessors.Last().Update(gameTime);
                        if (MovementProcessors.Last().IsDone)
                            MovementProcessors.Remove(MovementProcessors.Last());
                    }

                    if (ActiveMovementProcessor != null && actionTakingPlace == ActionType.MovementProgram)
                    {
                        if (ActiveMovementProcessor.IsDone)
                        {
                            ActiveMovementProcessor = null;
                            actionTakingPlace = ActionType.None;
                            waitActionCompelition = false;
                        }
                    }

                    // Return if there is an action taking place and must be completed
                    if (!(actionTakingPlace != ActionType.None && waitActionCompelition))
                    {
                        // Process Page Commands if active
                        if (PartyIndex == 0)
                        {
                            if (isProgramActive && CheckForSure())
                                ProcessPrograms();
                            else if (isProgramActive)
                                isProgramActive = false;

                            if (!(actionTakingPlace != ActionType.None && waitActionCompelition))
                            {
                                // Reset wait
                                waitActionCompelition = false;
                                // Process page movement if the page's program isn't active
                                if (!isProgramActive && Target == null)
                                {
                                    MovementProcessor.Update(gameTime);
                                }
                                else if (isProgramActive && (data.Pages[pageIndex].TriggerConditions == TriggerConditions.AutorunLoop || data.Pages[pageIndex].TriggerConditions == TriggerConditions.BackgroundProcess))
                                {
                                    // If program is active, only process movement if it is a parallel process or auto-loop
                                    MovementProcessor.Update(gameTime);
                                }
                            }
                        }
                    }
                }
                // Update Movement Animation
                UpdateMovement();
                // Update Animation
                Animation.Update(gameTime);
                // Update Cursor
                if (data.Pages[pageIndex].Cursor > -1 && this.Contains(new Vector2((float)Mouse.GetState().X, (float)Mouse.GetState().Y)))
                    Global.Instance.CursorMaterial = data.Pages[pageIndex].Cursor;
            }
        }
        /// <summary>
        /// Check if the program is active for sure.
        /// For some activations, such as collision, activation must be checked twice.
        /// </summary>
        /// <returns></returns>
        private bool CheckForSure()
        {
            if (programIndex > 0) return true;
            if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.Collision)
            {
                for (int i = 0; i < collisionList.Count; i++)
                {
                    if (collisionList[i].UserData is EventProcessor && (data.Pages[pageIndex].TouchEventIDs.Contains(((EventProcessor)collisionList[i].UserData).data.ID) || data.Pages[pageIndex].TouchTemplateEventIDs.Contains(((EventProcessor)collisionList[i].UserData).data.TemplateID)))
                        return true;
                    else if (data.Pages[pageIndex].MapCollisionTrigger)
                        return true;
                    else if (data.Pages[pageIndex].TouchTemplateEventIDs.Count == 0 && data.Pages[pageIndex].TouchEventIDs.Count == 0 && !data.Pages[pageIndex].MapCollisionTrigger)
                        return true;
                }
            }
            else
                return true;
            return false;
        }
        #endregion

        #region Method: Process Programs
        /// <summary>
        /// Process Programs
        /// </summary>
        private void ProcessPrograms()
        {
            if (!(actionTakingPlace != ActionType.None && waitActionCompelition) && waitFrames <= 0)
            {
                if (programIndex > -1 && programIndex < CurrentBranch.Programs.Count)
                {
                    if (CurrentBranch.Enabled && CurrentBranch.Programs[programIndex].Enabled)
                    {
                        if (CurrentBranch.UniqueID == -1)
                            CurrentBranch.UniqueID = UniqueIDCount++;

                        switch (CurrentBranch.Programs[programIndex].ProgramCategory)
                        {
                            case ProgramCategory.Movement: // Movement
                                ProcessCategoryMovement(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Settings: // Settings
                                ProcessCategorySettings(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Display: // Display
                                ProcessCategoryDisplay(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Conditions: // Conditions
                                if (CurrentBranch.Programs[programIndex].Name.Contains("Test"))
                                    waitFrames = waitFrames;
                                ProcessCategoryConditions(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Loops: // Loops
                                ProcessCategoryLoop(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Audio: // Audio
                                ProcessCategoryAudio(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Data: // Data
                                ProcessCategoryData(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Event: // Event
                                ProcessCategoryEvent(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Map: // Map
                                ProcessCategoryMap(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Screen: // Screen
                                ProcessCategoryScreen(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Guide: // Memory
                                ProcessCategoryGuide(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Other: // Other
                                ProcessCategoryOther(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Party: // Party
                                ProcessCategoryParty(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Hero: // Hero
                                ProcessCategoryHero(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Battle: // Battle
                                ProcessCategoryBattle(CurrentBranch.Programs[programIndex], ref programIndex, this);
                                break;
                            case ProgramCategory.Graphics: // Graphics
                                ProcessCategoryGraphics(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                        }
                    }
                    else
                    {
                        programIndex++; NextProgram();
                    }
                }
                else if (programIndex >= CurrentBranch.Programs.Count)
                {
                    // If this is the top most branch, end
                    if (LastBranch.Count == 0)
                    {
                        isProgramActive = false;
                        programIndex = 0;
                        labels.Clear();
                        // If not loop
                        if (data.Pages[pageIndex].TriggerConditions != TriggerConditions.AutorunLoop)
                            Global.Instance.AutorunID = -1;
                        // Check if Player Locked
                        if (Global.Instance.LockPlayer[0] == 0 && Global.Instance.LockPlayer[1] == UniqueID)
                            Global.Instance.LockPlayer[1] = -1;
                        return;
                    }
                    // Check if its a loop
                    if (CurrentBranch.ProgramCategory == ProgramCategory.Loops)
                    {
                        // Loop Do
                        if (CurrentBranch.Code == 1)
                        {
                            programIndex = 0;
                            return;
                        }
                    }
                    // Go to last branch
                    CurrentBranch = LastBranch.Last();
                    programIndex = LastProgramIndex.Last();
                    LastBranch.RemoveAt(LastBranch.Count - 1);
                    LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);

                    NextProgram();
                }
            }
        }
        /// <summary>
        /// Continues to the next program
        /// Called when the program data is simple and doesn't require more frames
        /// </summary>
        public override void NextProgram()
        {
            // Process Page Commands if active
            if (isProgramActive)
            {
                ProcessPrograms();
            }
        }
        /// <summary>
        /// Setup branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupBranch(EventProgramData eventProgramData)
        {
            LastBranch.Add(CurrentBranch);
            LastProgramIndex.Add(++programIndex);
            CurrentBranch = eventProgramData;
            programIndex = -1;
        }
        /// <summary>
        /// Else Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupElseBranch(EventProgramData eventProgramData)
        {
            LastBranch.Add(CurrentBranch);
            LastProgramIndex.Add(++programIndex);
            EventProgramData programData = new EventProgramData();
            programData.Programs = eventProgramData.ElsePrograms;
            CurrentBranch = programData;
            programIndex = -1;
        }
        /// <summary>
        /// Break Current Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void BreakBranch(ref int index, bool ignoreTop)
        {
            // If this is the top most branch
            if (LastBranch.Count == 0)
            {
                if (ignoreTop)
                {
                    index++; NextProgram();
                }
                else
                {
                    isProgramActive = false;
                    programIndex = 0;
                    labels.Clear();
                }
                return;
            }
            // Go to last branch
            CurrentBranch = LastBranch.Last();
            index = LastProgramIndex.Last();
            LastBranch.RemoveAt(LastBranch.Count - 1);
            LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
            index++; NextProgram();
        }
        /// <summary>
        /// Break Current Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void BreakBranch(ref int index)
        {
            // If this is the top most branch
            if (LastBranch.Count == 0)
                return;
            // Go to last branch
            CurrentBranch = LastBranch.Last();
            index = LastProgramIndex.Last();
            LastBranch.RemoveAt(LastBranch.Count - 1);
            LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
        }
        #endregion

        #region Helper: Get Event, Variable Value
        /// <summary>
        /// Get Event
        /// </summary>
        /// <param name="p"></param>
        public override EventProcessor GetEvent(int id)
        {
            EventProcessor ev;
            if (id == -1)
                ev = Global.Instance.Player[0];
            else if (id == -2)
                ev = this;
            else if (id == -3)
                ev = this.Target;
            else
                ev = Global.Instance.CurrentMap.GetEvent(id);
            return ev;
        }
        /// <summary>
        /// Gets a value from either constant, variable, or local variable.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override float GetValue(int type, int id)
        {
            switch (type)
            {
                case 0:
                    return id;
                case 1:
                    return Global.Variable(id);
                case 2:
                    return Global.Variable(id, this);
            }
            return 0;
        }
        /// <summary>
        /// Gets a value from either constant, variable, or local variable.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override float GetValue(int type, float id)
        {
            switch (type)
            {
                case 0:
                    return id;
                case 1:
                    return Global.Variable((int)id);
                case 2:
                    return Global.Variable((int)id, this);
            }
            return 0;
        }
        #endregion

        #region Method: Movement, Direction and Physics (SetupCollision) **
        /// <summary>
        /// Setup Program Movement 
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupProgramMovement(EventProgramData eventProgramData)
        {
            EventProcessor targetEvent = GetEvent((int)eventProgramData.Value[0]);
            if (targetEvent != null)
            {
                MovementProcessor mp = Global.MovementProcessors.Fetch();
                mp = new MovementProcessor();
                mp.Setup(targetEvent, (targetEvent == this), (List<EventProgramData>)eventProgramData.Value[4], (bool)eventProgramData.Value[2], (bool)eventProgramData.Value[3], (bool)eventProgramData.Value[1], this);
                targetEvent.MovementProcessors.Add(mp);

                mp.Update(null);
                actionTakingPlace = ActionType.MovementProgram;
                waitActionCompelition = (bool)eventProgramData.Value[1];

                if (waitActionCompelition)
                    ActiveMovementProcessor = mp;
            }
        }
        /// <summary>
        /// Update movement
        /// </summary>
        private void UpdateMovement()
        {
            // Move to a position if necessarry
            if (isMoving && !Path.IsUsingPath && newPosition != Vector2.Zero)
            {
                if (MoveTo(ref newPosition, (UseImpulse && actionTakingPlace == ActionType.Movement)))
                {
                    Position = newPosition;
                    if (Body != null)
                        Body.ResetBaseDynamics();
                    isMoving = false;
                    // Tell wait to end
                    if (actionTakingPlace == ActionType.Movement)
                    {
                        actionTakingPlace = ActionType.None;
                    }
                }
            }
            // Update Path
            if (Path.IsUsingPath)
            {
                // Face New Point
                if (Path.Turn && (Position - Path.CurrentVector).Length() > MoveSpeed)
                    TurnToward(Path.CurrentVector);
                if (MoveTo(Path.CurrentVector, Path.UseImpulse))
                {
                    // Progress
                    Path.Progress();
                    // Check if path is done
                    if (Path.Done)
                    {
                        Position = newPosition;
                        if (Body != null)
                            Body.ResetBaseDynamics();
                        Path.IsUsingPath = false;
                        if (actionTakingPlace == ActionType.FindingPath)
                            actionTakingPlace = ActionType.None;
                        if (Animation.IsAnimating)
                            EndAnimation();
                    }
                    else
                    {
                        //actionIndex = EventAction.Walk;
                        if (Path.Turn)
                            // Face New Point
                            TurnToward(Path.CurrentVector);
                        if (!Animation.IsAnimating)
                            StartAnimation();
                    }
                }
            }
            // Update Animation if moving
            if (Body != null)
            {
                // Update Animation
                if (IsMoving && !Animation.IsAnimating)
                {
                    if (ActionIndex == EventAction.Walk)
                        StartAnimation();
                }
                else if (!IsMoving && !isBattlerMoving && (!Body.Moves && Body.Force == Vector2.Zero) && Animation.IsAnimating && !Path.IsUsingPath && !MovementProcessor.IsMoving)
                {
                    if (ActionIndex == EventAction.Walk && Animation.ActionIndex == EventAction.Walk)
                        EndAnimation();
                }
                // If Action taking place is movement
                // check impossible counter and decided if movement 
                // program should be stopped;
                if (ActionIndex == EventAction.Jump && !IsJumping)
                {
                    //if (actionTakingPlace == ActionType.Jumping) actionTakingPlace = ActionType.None;
                    //ActionIndex = EventAction.Walk;
                    //SetAnimationAndAction();
                }
                //if (actionTakingPlace == ActionType.Jumping && !IsJumping) actionTakingPlace = ActionType.None;
            }
        }
        /// <summary>
        /// Move Event
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="pixels"></param>
        public void MoveEvent(int angle, int distance, bool turn)
        {
            if (angle < 0) angle += 360;
            if (angle > 360) angle -= 360;

            newPosition.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * distance;
            newPosition.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * distance;
            newPosition.X += Position.X;
            newPosition.Y += Position.Y;
            isMoving = true;

            if (!DirectionFix && turn)
            {
                SetAngle(ref angle, true);

                Animation.ApplyAngleToDirection(Angle);
            }

            ActionIndex = EventAction.Walk;

            if (Animation.animationOn && !Animation.IsAnimating)
                StartAnimation();
        }
        /// <summary>
        /// Apply Jump
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="force"></param>
        /// <param name="turn"></param>
        private void Jump(int angle, float force, bool turn)
        {
            if (turn && !DirectionFix)
            {
                SetAngle(ref angle, false);
                Animation.ApplyAngleToDirection(Angle);
            }
            Vector2 amount = new Vector2(0, 0);
            amount.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * force;
            amount.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * force;
            Body.ApplyLinearImpulse(ref amount);
            ActionIndex = EventAction.Jump;
            SetAnimationAndAction();
            if (Animation.animationOn && !Animation.IsAnimating)
                StartAnimationStill();
        }
        /// <summary>
        /// Apply Angular Impulse
        /// </summary>
        /// <param name="force"></param>
        private void ApplyAngularImpulse(float force)
        {
            if (Body != null)
                Body.ApplyAngularImpulse(force);
            if (!IsJumping)
            {
                ActionIndex = EventAction.Walk;
                if (Animation.animationOn && !Animation.IsAnimating)
                    StartAnimation();
            }
            if (Animation.animationOn && !Animation.IsAnimating)
                StartAnimation();
        }
        /// <summary>
        /// Apply Impulse
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="force"></param>
        /// <param name="turn"></param>
        private void ApplyLinearImpulse(int angle, float force, bool turn)
        {
            if (turn && !DirectionFix)
            {
                SetAngle(ref angle, true);
                Animation.ApplyAngleToDirection(Angle);
            }
            Vector2 amount = new Vector2(0, 0);
            amount.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * force;
            amount.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * force;

            if (Body != null)
            {
                Body.ApplyLinearImpulse(ref amount);
                if (!IsJumping)
                {
                    ActionIndex = EventAction.Walk;
                    if (Animation.animationOn && !Animation.IsAnimating)
                        StartAnimation();
                }
            }
        }
        /// <summary>
        /// Apply Force
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="distance"></param>
        /// <param name="turn"></param>
        private void ApplyForce(int angle, float force, bool turn)
        {
            if (turn && !DirectionFix)
            {
                SetAngle(ref angle, true);
                Animation.ApplyAngleToDirection(Angle);
            }
            Vector2 amount = new Vector2(0, 0);
            amount.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * force;
            amount.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * force;

            if (Body != null)
            {
                Body.ApplyForce(ref amount);
                if (!IsJumping)
                {
                    ActionIndex = EventAction.Walk;
                    if (Animation.animationOn && !Animation.IsAnimating)
                        StartAnimation();
                }
            }
        }
        /// <summary>
        /// Apply Torque
        /// </summary>
        /// <param name="p"></param>
        private void ApplyTorque(float amount)
        {
            if (Body != null)
                Body.ApplyTorque(amount);
        }
        /// <summary>
        /// Move To New Position
        /// </summary>
        /// <param name="newPosition"></param>
        public bool MoveTo(ref Vector2 point)
        {
            if (Body != null && !Body.IsStatic)
            {
                if ((Position - point).Length() < (Force / Mass) * 2 || (Position - point).Length() < 10) // If it is 10 units from the destination, we consider it has arrived
                    return true;

                Vector2 amount = (point - Position);
                amount.X = (float)Math.Round(Math.Cos((float)Math.Atan2(amount.Y, amount.X)), 2) * Force;
                amount.Y = (float)Math.Round(Math.Sin((float)Math.Atan2(amount.Y, amount.X)), 2) * Force;

                Body.ApplyForce(ref amount);


                if (IsMovingPlatform)
                {
                    for (int i = 0; i < collisionList.Count; i++)
                    {
                        if (!collisionList[i].IsStatic)
                        {
                            Vector2 v = collisionList[i].LinearVelocity;
                            if (Math.Abs(collisionList[i].LinearVelocity.X) < Math.Abs(Body.LinearVelocity.X))
                                v.X = Body.LinearVelocity.X;
                            if (Math.Abs(collisionList[i].LinearVelocity.Y) < Math.Abs(Body.LinearVelocity.Y))
                                v.Y = Body.LinearVelocity.Y;

                            collisionList[i].LinearVelocity = v;
                        }
                    }
                }
            }
            else if (Body != null && Body.IsStatic)
            {
                float length = (Position - point).Length();
                if (length < MoveSpeed) // If it is 10 units from the destination, we consider it has arrived
                {
                    Position = point;
                    return true;
                }
                Vector2 amount = (point - Position);
                amount.X = (float)Math.Round(Math.Cos((float)Math.Atan2(amount.Y, amount.X)), 2) * MoveSpeed;
                amount.Y = (float)Math.Round(Math.Sin((float)Math.Atan2(amount.Y, amount.X)), 2) * MoveSpeed;


                Position += amount;

                if (IsMovingPlatform)
                {
                    for (int i = 0; i < collisionList.Count; i++)
                    {
                        if (!collisionList[i].IsStatic)
                        {
                            collisionList[i].Position += ConvertUnits.ToSimUnits(amount);
                        }
                    }
                }
            }
            return false;
        }
        public bool MoveTo(Vector2 point)
        {
            return MoveTo(ref point);
        }
        public bool MoveTo(ref Vector2 point, bool useImpulse)
        {
            if (useImpulse)
                return MoveTo(ref point, Impulse);
            return MoveTo(ref point);
        }
        public bool MoveTo(Vector2 point, bool useImpulse)
        {
            return MoveTo(ref point, useImpulse);
        }
        public bool MoveTo(ref Vector2 point, float impulse)
        {
            if (Body != null && !Body.IsStatic)
            {
                if ((Position - point).Length() < (impulse / Mass)) // If it is 10 units from the destination, we consider it has arrived
                    return true;

                Vector2 amount = (point - Position);
                amount.X = (float)Math.Round(Math.Cos((float)Math.Atan2(amount.Y, amount.X)), 2) * impulse;
                amount.Y = (float)Math.Round(Math.Sin((float)Math.Atan2(amount.Y, amount.X)), 2) * impulse;

                Body.ApplyLinearImpulse(ref amount);
            }
            else if (Body != null && Body.IsStatic)
            {
                float length = (Position - point).Length();
                if (length <= MoveSpeed) // If it is 10 units from the destination, we consider it has arrived
                {
                    Position = point;
                    return true;
                }
                Vector2 amount = (point - Position);
                amount.X = (float)Math.Round(Math.Cos((float)Math.Atan2(amount.Y, amount.X)), 2) * MoveSpeed;
                amount.Y = (float)Math.Round(Math.Sin((float)Math.Atan2(amount.Y, amount.X)), 2) * MoveSpeed;
                Position += amount;
            }
            return false;
        }
        /// <summary>
        /// Turn Toward Events
        /// </summary>
        /// <param name="list"></param>
        /// <param name="list_2"></param>
        public void TurnTowardEvents(List<int> eventIDs, List<int> directions)
        {
            EventProcessor closestEvent = null;
            EventProcessor currentEvent = null;
            // Get Closest Event
            for (int i = 0; i < eventIDs.Count; i++)
            {
                if (closestEvent == null)
                {
                    closestEvent = GetEvent(eventIDs[i]);

                    if (closestEvent.Body == null)
                        closestEvent = null;
                    continue;
                }
                currentEvent = GetEvent(eventIDs[i]);
                if (currentEvent != null && currentEvent.Body != null)
                {
                    Vector2 pos = Position;

                    float distance1 = closestEvent.Body.GetDistance(this.Body);
                    float distance2 = currentEvent.Body.GetDistance(this.Body);

                    if (distance2 < distance1)
                        closestEvent = currentEvent;
                }
            }
            // Get Direction
            if (closestEvent != null)
            {
                TurnTowardEvent(closestEvent, directions);
            }
        }
        /// <summary>
        /// Turn Away From Events
        /// </summary>
        /// <param name="list"></param>
        /// <param name="list_2"></param>
        public void TurnAwayFromEvents(List<int> eventIDs, List<int> directions)
        {
            EventProcessor closestEvent = null;
            EventProcessor currentEvent = null;
            // Get Closest Event

            for (int i = 0; i < eventIDs.Count; i++)
            {
                if (closestEvent == null)
                {
                    closestEvent = GetEvent(eventIDs[i]);

                    if (closestEvent.Body == null)
                        closestEvent = null;
                    continue;
                }
                currentEvent = GetEvent(eventIDs[i]);
                if (currentEvent != null && currentEvent.Body != null)
                {
                    Vector2 pos = Position;

                    float distance1 = closestEvent.Body.GetDistance(this.Body);
                    float distance2 = currentEvent.Body.GetDistance(this.Body);

                    if (distance2 < distance1)
                        closestEvent = currentEvent;
                }
            }
            // Get Direction
            if (closestEvent != null)
            {
                TurnAwayFromEvent(closestEvent, directions);
            }
        }
        /// <summary>
        /// Turn Toward Event
        /// </summary>
        public void TurnToward(Vector2 pos)
        {
            Vector2 targetAngle = (pos - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
            // Calculate target To Move
            SetAngle((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), true);

            Animation.ApplyAngleToDirection(Angle);
        }
        /// <summary>
        /// Turn Toward Event
        /// </summary>
        public void TurnToward(float x, float y)
        {
            Vector2 targetAngle = new Vector2();
            targetAngle.X = x; targetAngle.Y = y;
            targetAngle = (targetAngle - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
            // Calculate target To Move
            SetAngle((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), true);

            Animation.ApplyAngleToDirection(Angle);
        }
        /// <summary>
        /// Turn Toward Event
        /// </summary>
        /// <param name="closestEvent"></param>
        /// <param name="directions"></param>
        public void TurnTowardEvent(EventProcessor ev, List<int> directions)
        {
            TurnToward(ev.OriginPosition);
        }
        /// <summary>
        /// Turn Away From Event
        /// </summary>
        /// <param name="list"></param>
        /// <param name="list_2"></param>
        public void TurnAwayFromEvent(EventProcessor ev, List<int> directions)
        {
            Vector2 targetAngle = (OriginPosition - ev.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
            // Calculate target To Move
            SetAngle((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), true);

            Animation.ApplyAngleToDirection(Angle);
        }
        /// <summary>
        /// Move Toward Events
        /// </summary>
        /// <param name="list"></param>
        /// <param name="p"></param>
        /// <param name="p_3"></param>
        /// <param name="list_4"></param>
        public void MoveTowardEvents(List<int> eventIDs, int pixel, bool turn, List<int> directions)
        {
            EventProcessor closestEvent = null;
            EventProcessor currentEvent = null;
            // Get Closest Event
            for (int i = 0; i < eventIDs.Count; i++)
            {
                if (closestEvent == null)
                {
                    closestEvent = GetEvent(eventIDs[i]);

                    if (closestEvent.Body == null)
                        closestEvent = null;
                    continue;
                }
                currentEvent = GetEvent(eventIDs[i]);
                if (currentEvent != null && currentEvent.Body != null)
                {
                    Vector2 pos = Position;

                    float distance1 = closestEvent.Body.GetDistance(this.Body);
                    float distance2 = currentEvent.Body.GetDistance(this.Body);

                    if (distance2 < distance1)
                        closestEvent = currentEvent;
                }
            }

            if (closestEvent != null)
            {
                MoveTowardEvent(closestEvent, pixel, turn, directions);
            }
        }
        /// <summary>
        /// Move Away Events
        /// </summary>
        /// <param name="list"></param>
        /// <param name="p"></param>
        /// <param name="p_3"></param>
        /// <param name="list_4"></param>
        public void MoveAwayFromEvents(List<int> eventIDs, int pixel, bool turn, List<int> directions)
        {
            EventProcessor closestEvent = null;
            EventProcessor currentEvent = null;
            // Get Closest Event
            for (int i = 0; i < eventIDs.Count; i++)
            {
                if (closestEvent == null)
                {
                    closestEvent = GetEvent(eventIDs[i]);

                    if (closestEvent.Body == null)
                        closestEvent = null;
                    continue;
                }
                currentEvent = GetEvent(eventIDs[i]);
                if (currentEvent != null && currentEvent.Body != null)
                {
                    Vector2 pos = Position;

                    float distance1 = closestEvent.Body.GetDistance(this.Body);
                    float distance2 = currentEvent.Body.GetDistance(this.Body);

                    if (distance2 < distance1)
                        closestEvent = currentEvent;
                }
            }

            if (closestEvent != null)
            {
                MoveAwayFromEvent(closestEvent, pixel, turn, directions);
            }
        }
        /// <summary>
        /// Move Toward Event
        /// </summary>
        /// <param name="closestEvent"></param>
        /// <param name="pixel"></param>
        /// <param name="turn"></param>
        /// <param name="directions"></param>
        private void MoveTowardEvent(EventProcessor ev, int pixel, bool turn, List<int> directions)
        {
            // Turn Toward Event
            TurnTowardEvent(ev, null);
            // Calculate target To Move
            MoveEvent(Angle, pixel, turn);
        }
        /// <summary>
        /// Move Away From Event
        /// </summary>
        /// <param name="closestEvent"></param>
        /// <param name="pixel"></param>
        /// <param name="turn"></param>
        /// <param name="directions"></param>
        private void MoveAwayFromEvent(EventProcessor ev, int pixel, bool turn, List<int> directions)
        {
            Vector2 targetAngle = (ev.Position - this.Position); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
            int angle = (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);
            if (angle < 0) angle += 360;
            angle += 180;
            if (angle > 360) angle -= 360;
            // Calculate target To Move
            MoveEvent(angle, pixel, turn);
        }
        /// <summary>
        /// Knocback
        /// </summary>
        /// <param name="p"></param>
        /// <param name="eventProcessor"></param>
        public void Knocback(float force, Vector2 obj)
        {
            if (this.Position != obj)
            {
                Vector2 targetAngle = (this.Position - obj); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
                float desiredAngle = (float)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);

                if (desiredAngle < 0) desiredAngle += 360;
                if (desiredAngle > 360) desiredAngle -= 360;

                ApplyLinearImpulse((int)desiredAngle, force, false);
            }
        }
        /// <summary>
        /// Set Angle
        /// </summary>
        /// <param name="angle"></param>
        public void SetAngle(ref int angle, bool reset)
        {
            if (angle < 0) angle += 360;
            if (angle > 360) angle -= 360;
            // Set Angle
            Angle = angle;
            // Reset Rotation
            if (reset && SyncAngleToRotation && Body != null)
            {
                Body.ResetTorque();
                Body.Rotation = MathHelper.ToRadians(Angle + 90);
            }
        }
        /// <summary>
        /// Set Angle
        /// </summary>
        /// <param name="angle"></param>
        public void SetAngle(int angle, bool reset)
        {
            if (!DirectionFix)
            {
                if (angle < 0) angle += 360;
                if (angle > 360) angle -= 360;
                // Set Angle
                Angle = angle;
                // Reset Rotation
                if (reset && SyncAngleToRotation && Body != null)
                {
                    Body.ResetTorque();
                    Body.Rotation = MathHelper.ToRadians(Angle + 90);
                }
            }
            else if (SyncAngleToRotation && Body != null)
            {
                Body.ResetTorque();
                Body.Rotation = MathHelper.ToRadians(Angle + 90);
            }
        }
        /// <summary>
        /// Apply a knockback force from owner
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="force"></param>
        public void ApplyKnockback(EventProcessor owner, float force)
        {
            Knocback(force, owner.Position);
        }
        /// <summary>
        /// Resets collision
        /// </summary>
        public void SetupCollisionBody()
        {
            if (Body != null && CurrentAction != null && CollisionBody != CurrentAction.CollisionBody)
            {
                NativePosition = ConvertUnits.ToDisplayUnits(Body.Position) - (CurrentAction.CollisionBody.Count > 0 ? CurrentAction.CollisionBody.GetCentroid() : Vector2.Zero);
            }

            // Get animation, action, and direction.
            if (CurrentAction != null && Global.World != null)
            {
                if (!CheckEquals(CollisionBody, CurrentAction.CollisionBody))
                {
                    // Set offset to zero
                    Animation.Offset = Vector2.Zero;
                    // Only add if there is a body
                    if (CurrentAction.CollisionBody.Count > 1)
                    {
                        Vector2 lv = new Vector2(), ilv = new Vector2();
                        float av = 0f, iav = 0f;
                        if (Body != null && Body.FixtureList != null)
                        {
                            Body.Dispose();
                            if (AttachmentClone != null) AttachmentClone.Dispose();
                            AttachmentClone = null;
                            lv = Body.LinearVelocity;
                            ilv = Body.LinearVelocityInternal;
                            av = Body.AngularVelocity;
                            iav = Body.AngularVelocityInternal;

                            for (int j = 0; j < Attachments.Count; j++)
                            {
                                Attachments[j].DisposeBodies();
                                Global.Instance.CurrentMap.RemoveProcessor(Attachments[j]);
                            }
                        }
                        Vertices clone = new Vertices(CurrentAction.CollisionBody);
                        clone = Vertices.Simplify(clone);
                        Vector2 centroid = -clone.GetCentroid();
                        clone.Translate(ref centroid);

                        List<Vertices> vertices = BayazitDecomposer.ConvexPartition(clone);

                        //scale the vertices from graphics space to sim space
                        Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * 1f;
                        foreach (Vertices v1 in vertices)
                        {
                            v1.Scale(ref vertScale);
                        }
                        if (vertices.Count > 1)
                            Body = BodyFactory.CreateCompoundPolygon(Global.World, vertices, Mass);
                        else
                            Body = BodyFactory.CreatePolygon(Global.World, vertices[0], Mass);

                        Body.UserData = this;
                        Body.OnCollision += OnCollision;
                        Body.OnSeparation += OnSeperation;
                        Body.CollisionCategories = Category.Cat1;
                        Body.CollidesWith = Category.Cat1;


                        if (pageIndex > -1 && pageIndex < data.Pages.Count)
                        {
                            Body.IsStatic = Static;
                            Body.IgnoreGravity = IgnoreGravity;
                            Body.CustomGravity = CustomGravity;
                            Body.Gravity = Gravity;
                            Body.LinearDamping = LinearDrag;
                            Body.AngularDamping = RotationalDrag;
                            Body.Restitution = Bounce;
                            Body.Friction = Friction;
                            Body.IsSensor = PassThrough;
                            if (data.Pages[pageIndex].CustomMOI) Body.Inertia = MomentOfInertia;

                            if (data.Pages[pageIndex].SyncAngleToRotation)
                                Body.Rotation = MathHelper.ToRadians(Angle + 90);
                            Body.FixedRotation = IsFixedRotation;
                            Body.Mass = Mass;
                        }

                        if (GravityPoint != null)
                            SetGravityEmitter(GravityPoint.Strength, GravityPoint.Radius);

                        // If Player
                        if (IsPlayer)
                        {
                            if (PartyIndex > 0)
                            {
                                Global.Instance.Player[0].Body.ResetIgnore();
                                for (int partyIndex = 1; partyIndex < Global.Instance.Player.Count; partyIndex++)
                                {
                                    if (Global.Instance.Player[partyIndex].Body != null)
                                    {
                                        Global.Instance.Player[0].Body.IgnoreCollisionWith(Global.Instance.Player[partyIndex].Body);
                                    }
                                }
                            }
                        }
                        Animation.Origin = CurrentAction.CollisionBody.GetCentroid();
                        // Get Offset
                        Animation.Offset = ConvertUnits.ToDisplayUnits(Body.Position);
                        // Set Position
                        Body.Position = ConvertUnits.ToSimUnits(NativePosition);

                        Body.Position += ConvertUnits.ToSimUnits(CurrentAction.CollisionBody.GetCentroid());


                        // Reset Joints
                        Attachments.Clear();
                        Joints.Clear();

                        if (pageIndex > -1 && pageIndex < data.Pages.Count)
                        {
                            // Add Any Attachments
                            AttachmentJoint attachment;
                            for (int a = 0; a < data.Pages[pageIndex].Attachments.Count; a++)
                            {
                                attachment = data.Pages[pageIndex].Attachments[a];
                                // Setup
                                EventProcessor e = Global.Instance.CurrentMap.AddEvent(GameData.Events.GetData(attachment.AttachmentID), this.Position, LayerIndex);
                                e.SetupAttachment();
                                if (e.Body != null)
                                {
                                    if (attachment.IsSensor()) // Sensor
                                    {
                                        if (AttachmentClone == null || AttachmentClone.IsDisposed) AttachmentClone = Body.DeepClone();
                                        AttachmentClone.IsStatic = true;
                                        AttachmentClone.IsSensor = true;
                                        AttachmentClone.UserData = this;
                                        Joints.Add(SetupJoint(attachment, e, AttachmentClone));
                                    }
                                    else
                                        Joints.Add(SetupJoint(attachment, e, Body));
                                    Attachments.Add(e);

                                }
                                else
                                {
                                    Global.Instance.CurrentMap.RemoveProcessor(e);

                                    Console.WriteLine("Attachment Error: Attachment Requires Collision Box");
                                }
                            }

                        }
                        // Add Any Pins That Exist
                        FixedRevoluteJoint pin;
                        for (int i = 0; i < CurrentAction.Pins.Count; i++)
                        {
                            //pin = JointFactory.CreateFixedRevoluteJoint(Global.World, Body, CurrentAction.Pins[i].Position + Position - Animation.Origin, Body.Position);
                            //pin.MotorEnabled = true;
                            //pin.MotorTorque = 100f;
                            //pin.MotorSpeed = 3f;
                            //Global.World.AddJoint(pin);
                        }
                        if (AttachmentClone != null)
                        {
                            AttachmentClone.Position = Body.Position;
                            AttachmentClone.Rotation = Body.Rotation;
                        }
                        // Set Old Settings
                        Body.AngularVelocity = av;
                        Body.AngularVelocityInternal = iav;
                        Body.LinearVelocity = lv;
                        Body.LinearVelocityInternal = ilv;

                        CollisionBody = CurrentAction.CollisionBody;
                    }
                }
                else if (CurrentAction.CollisionBody.Count == 1)
                {
                    if (Body != null)
                    {
                        Body.OnCollision -= OnCollision;
                        Body.OnSeparation -= OnSeperation;
                        Body.Dispose();
                        if (AttachmentClone != null) AttachmentClone.Dispose();
                        for (int j = 0; j < Attachments.Count; j++)
                            Global.Instance.CurrentMap.RemoveProcessor(Attachments[j]);
                    }

                    CollisionBody = null;
                }
                // Only add if there is a body
                if (CurrentAction.HitBody.Count > 1)
                {
                    if (BattleBody != null && BattleBody.FixtureList != null)
                        BattleBody.Dispose();
                    Vertices clone = new Vertices(CurrentAction.HitBody);
                    clone = Vertices.Simplify(clone);
                    Vector2 centroid = -clone.GetCentroid();
                    clone.Translate(ref centroid);

                    List<Vertices> vertices = BayazitDecomposer.ConvexPartition(clone);

                    //scale the vertices from graphics space to sim space
                    Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * 1f;
                    foreach (Vertices v1 in vertices)
                    {
                        v1.Scale(ref vertScale);
                    }
                    if (vertices.Count > 1)
                        BattleBody = BodyFactory.CreateCompoundPolygon(Global.World, vertices, 1);
                    else
                        BattleBody = BodyFactory.CreatePolygon(Global.World, vertices[0], 1);

                    BattleBody.UserData = this;
                    BattleBody.OnCollision += OnBattleCollision;

                    BattleBody.CollisionCategories = Category.Cat2;
                    BattleBody.CollidesWith = Category.Cat2;
                    BattleBody.IsStatic = true;
                    BattleBody.BodyType = BodyType.Kinematic;
                    // Set Position
                    if (Body != null)
                        BattleBody.Position = Body.Position - ConvertUnits.ToSimUnits(Animation.CollisionBody.GetCentroid() + Animation.Action.HitBody.GetCentroid());
                    else
                        BattleBody.Position = ConvertUnits.ToSimUnits(NativePosition);
                }
                else if (CurrentAction.HitBody.Count == 1)
                {
                    if (BattleBody != null)
                    {
                        BattleBody.OnCollision -= OnBattleCollision;
                        BattleBody.Dispose();
                    }
                }
            }
            else
            {
                DisposeBodies();
            }
        }

        /// <summary>
        /// Setup Attachment
        /// </summary>
        private void SetupAttachment()
        {
            ProcessEventPage(new GameTime());
        }
        /// <summary>
        /// Setup Joint
        /// </summary>
        /// <param name="attachment"></param>
        /// <param name="e"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private Joint SetupJoint(AttachmentJoint attachment, EventProcessor e, Body body)
        {
            Vector2 axis;
            switch (attachment.Type)
            {
                case AttachmentType.Revolute:
                    RevoluteJoint _joint = new RevoluteJoint(body, e.Body,
                                                attachment.Vectors[1],
                                               attachment.Vectors[0]);
                    _joint.MotorSpeed = attachment.Numbers[0];
                    _joint.MaxMotorTorque = attachment.Numbers[1];
                    e.Body.Position = body.Position + attachment.Vectors[1];

                    _joint.CollideConnected = attachment.Booleans[0];
                    _joint.MotorEnabled = attachment.Booleans[1];
                    _joint.LimitEnabled = attachment.Booleans[2];
                    _joint.UpperLimit = MathHelper.ToRadians(attachment.Numbers[2]);
                    _joint.LowerLimit = MathHelper.ToRadians(attachment.Numbers[3]);

                    _joint.UserData = attachment;
                    Global.World.AddJoint(_joint);
                    return _joint;
                case AttachmentType.Line:
                    axis = attachment.Vectors[1];
                    if (axis != Vector2.Zero) axis.Normalize();

                    LineJoint _joint2 = new LineJoint(body, e.Body,
                                                attachment.Vectors[1],
                                               axis);
                    e.Body.Position = body.Position + attachment.Vectors[1];
                    _joint2.LocalAnchorA = attachment.Vectors[0];
                    _joint2.LocalAnchorB = attachment.Vectors[0];
                    _joint2.MotorSpeed = attachment.Numbers[0];
                    _joint2.MaxMotorTorque = attachment.Numbers[1];
                    _joint2.DampingRatio = attachment.Numbers[2];
                    _joint2.Frequency = attachment.Numbers[3];
                    _joint2.CollideConnected = attachment.Booleans[0];
                    _joint2.MotorEnabled = attachment.Booleans[1];
                    _joint2.UserData = attachment;
                    Global.World.AddJoint(_joint2);
                    return _joint2;
                case AttachmentType.Distance:
                    axis = attachment.Vectors[1];
                    if (axis != Vector2.Zero) axis.Normalize();

                    DistanceJoint _joint3 = new DistanceJoint(body, e.Body, attachment.Vectors[1], attachment.Vectors[0]);
                    e.Body.Position = body.Position + attachment.Vectors[1];
                    _joint3.Length = attachment.Numbers[0];
                    _joint3.Breakpoint = attachment.Numbers[1];
                    _joint3.DampingRatio = attachment.Numbers[2];
                    _joint3.Frequency = attachment.Numbers[3];
                    _joint3.CollideConnected = attachment.Booleans[0];
                    _joint3.UserData = attachment;
                    Global.World.AddJoint(_joint3);
                    return _joint3;
            }
            return null;
        }
        /// <summary>
        /// Reset Physics
        /// </summary>
        public void ResetPhysics()
        {
            if (Body != null) Body.ResetBaseDynamics();
        }
        /// <summary>
        /// Set Gravity Emitter
        /// </summary>
        /// <param name="strength"></param>
        /// <param name="radius"></param>
        public void SetGravityEmitter(float str, float r)
        {
            if (Body != null)
            {
                r = ConvertUnits.ToSimUnits(r);
                if (GravityPoint == null) GravityPoint = new GravityPoint();
                GravityPoint.Radius = r;
                GravityPoint.Strength = str;

                if (GravityController == null)
                    GravityController = new EventGravityController(Global.World, this, str, r);

                if (GravityController.Event != this || GravityController.Strength != str || GravityController.MaxRadius != r)
                {
                    GravityController.Event = this;
                    GravityController.Strength = str;
                    GravityController.MaxRadius = r;
                }
            }
        }
        /// <summary>
        /// Dispose Fixtureetries
        /// </summary>
        public void DisposeBodies()
        {
            if (Body != null)
            {
                if (CurrentAction != null)
                    NativePosition -= (CurrentAction.CollisionBody.Count > 0 ? CurrentAction.CollisionBody.GetCentroid() : Vector2.Zero);
                Body.OnCollision -= OnCollision;
                Body.OnSeparation -= OnSeperation;
                Body.Dispose();
                if (AttachmentClone != null) AttachmentClone.Dispose();
            }
            if (BattleBody != null)
            {
                BattleBody.OnCollision -= OnBattleCollision;
                BattleBody.Dispose();
            }
            for (int j = 0; j < Attachments.Count; j++)
                Global.Instance.CurrentMap.RemoveProcessor(Attachments[j]);
            collisionList.Clear();
            Body = null;
            BattleBody = null;
            CollisionBody = null;
        }
        public void ClearBodies()
        {
            for (int j = 0; j < Attachments.Count; j++)
                Global.Instance.CurrentMap.RemoveProcessor(Attachments[j]);
            collisionList.Clear();
            Body = null;
            BattleBody = null;
            CollisionBody = null;
        }
        /// <summary>
        /// Check if vertices == each other
        /// </summary>
        /// <param name="CollisionBody"></param>
        /// <param name="vertices"></param>
        /// <returns></returns>
        private bool CheckEquals(Vertices v1, Vertices v2)
        {
            if (v1 == null || v2 == null) return false;
            return v1.CheckEquals(v2);
        }
        #endregion

        #region Method: Animations
        /// <summary>
        /// Start Animation
        /// </summary>
        public void StartAnimation()
        {
            if (Battler != null && ActionIndex == EventAction.Walk)
                UpdateDefaultAction();
            Animation.Start(ActionIndex);
            // Start Anchored Animations
            StartAnchoredAnimations();
        }
        /// <summary>
        /// Start animation still
        /// </summary>
        public void StartAnimationStill()
        {
            if (Battler != null && ActionIndex == EventAction.Walk)
                UpdateDefaultAction();
            Animation.Start(ActionIndex);
            Animation.Still = true;
            // Start Anchored Animations
            StartAnchoredAnimations();
        }
        /// <summary>
        /// Start Anchored Animations
        /// </summary>
        private void StartAnchoredAnimations()
        {
            foreach (AnimationProcessor processor in EquipmentAnimations.Values)
            {
                // Start
                processor.Start();
            }
        }
        /// <summary>
        /// Update Default Action
        /// </summary>
        private void UpdateDefaultAction()
        {
            if (CurrentAnimation != null && Battler.Actions[(int)ActionIndex] > -1)
            {
                if (Animation.Action != null && Battler.Actions[(int)ActionIndex] != Animation.Action.ID)
                {
                    Animation.Setup(CurrentAnimation.Actions.GetData(Battler.Actions[(int)ActionIndex]), ActionIndex);
                    SetupCollisionBody();
                }
            }
        }
        /// <summary>
        /// End Animation
        /// </summary>
        public void EndAnimation()
        {
            ActionIndex = EventAction.Idle;
            if (Battler != null)
            {
                // Update Action
                UpdateDefaultAction();
                // Start Animation
                StartAnimation();
            }
            else
            {
                // End Animation
                Animation.EndAnimation();
            }
        }
        /// <summary>
        /// Sets the animation and action assigned to the event
        /// to the event processor for convinience.
        /// </summary>
        public void SetAnimationAndAction()
        {
            // Assign animation if player
            if (Battler != null)
            {
                if (CurrentAnimation == null || CurrentAnimation.ID != Battler.AnimationID)
                    CurrentAnimation = GameData.Animations.GetData(Battler.AnimationID);

                if (Battler.Actions[(int)ActionIndex] > -1)
                {
                    bool dontReset = Animation.Setup(Battler.AnimationID, Battler.Actions[(int)ActionIndex], ActionIndex);
                    if (Animation.animationOn)
                        if (ActionIndex == EventAction.Jump)
                            StartAnimationStill();
                        else
                            StartAnimation();
                    if (!dontReset)
                        SetupCollisionBody();
                }
            }
            else if (pageIndex > -1 && pageIndex < data.Pages.Count)
            {
                if (data.Pages[pageIndex].AnimationID > -1)
                {
                    CurrentAnimation = GameData.Animations.GetData(data.Pages[pageIndex].AnimationID);
                    Animation.Setup(data.Pages[pageIndex].AnimationID, data.Pages[pageIndex].ActionID, ActionIndex);
                }
                SetupCollisionBody();
            }
        }
        /// <summary> 
        /// Reset animation to idle
        /// </summary>
        public void ResetAnimation()
        {
            if (Battler != null)
            {
                ActionIndex = EventAction.Idle;
                CurrentAnimation = GameData.Animations.GetData(Battler.AnimationID);
                Animation.Setup(Battler.AnimationID, Battler.Actions[(int)ActionIndex], ActionIndex);
            }
        }
        /// <summary>
        /// Setup Equipment Anchor Animation
        /// </summary>
        /// <param name="equipID"></param>
        public void SetupEquipmentAnchor(int equipID, int slot)
        {
            EquipmentAnimations[slot].Setup(GameData.Equipments[equipID].VisualAnimation, Battler.Actions[(int)ActionIndex], Animation.AnimationID, ActionIndex);
        }
        #endregion

        #region Method: Direction, Range and Collision Check
        /// <summary>
        /// Gets the range between this event and the target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public float RangeOf(EventProcessor obj)
        {
            if (Body == null || obj.Body == null)
                return (int)Vector2.Distance(OriginPosition, obj.OriginPosition);
            return Body.GetDistance(obj.Body);
        }
        Vector2 startLine, endLine = Vector2.Zero;
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool CollideAnyAngle(Body body, float dist)
        {
            Vector2 endPoint = new Vector2();
            startLine = Body.Position;
            Vector2 targetAngle = (body.Position - this.OriginPosition); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
            int angle = (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);
            // Calculate target To Move
            endPoint.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * dist;
            endPoint.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * dist;
            return body.RayCast(Body.Position, Body.Position + endPoint);
        }
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool Collide(Body body, float dist)
        {
            Vector2 endPoint = new Vector2();
            startLine = Body.Position;
            endPoint.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(Angle)), 2) * dist;
            endPoint.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(Angle)), 2) * dist;
            return body.RayCast(Body.Position, Body.Position + endPoint);
        }
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool Collide(Body body, ref Vector2 dist)
        {
            Vector2 endPoint = new Vector2();
            endPoint.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(Angle)), 2) * dist.X;
            endPoint.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(Angle)), 2) * dist.Y;
            startLine = Body.Position;
            endLine = Body.Position + endPoint;
            return body.RayCast(Body.Position, Body.Position + endPoint);
        }
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool Collide(int angle, Body body, float dist)
        {
            endLine = new Vector2();
            endLine.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * dist;
            endLine.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * dist;
            startLine = Body.Position;
            endLine = Body.Position + endLine;
            return body.RayCast(Body.Position, endLine);
        }
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool Collide(int angle, Body body, float dist, float[] diff)
        {
            endLine = new Vector2();
            endLine.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * dist;
            endLine.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * dist;
            startLine = Body.Position;
            endLine = Body.Position + endLine;
            Vector2 s, e;
            for (int i = 0; i < diff.Length; i++)
            {
                DebugViewXNA.RecordRay = true;
                s = startLine; s.X += diff[i];
                e = endLine; e.X += diff[i];
                e.Y += ConvertUnits.ToSimUnits(1);
                if (body.RayCast(s, e)) return true;
            }
            return false;
        }
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool Collide(int angle, Body body, float dist, float diff, float heightoffset)
        {
            endLine = new Vector2();
            endLine.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * dist;
            endLine.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * dist;
            startLine = Body.Position;
            startLine.Y -= heightoffset;
            endLine = startLine + endLine;
            Vector2 s, e;
            s = startLine; s.X -= diff;
            e = endLine; e.X -= diff;

            for (int i = 0; i < ConvertUnits.ToDisplayUnits(diff * 2); i++)
            {
                if (body.RayCast(s, e, 1f))
                    return true;
                e.X += ConvertUnits.ToSimUnits(1);
                s.X += ConvertUnits.ToSimUnits(1);
            }
            return false;
        }
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool Collide(int[] angles, Body body, float dist)
        {
            endLine = new Vector2();
            for (int i = 0; i < angles.Length; i++)
            {
                endLine.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angles[i])), 2) * dist;
                endLine.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angles[i])), 2) * dist;
                startLine = Body.Position;
                endLine = Body.Position + endLine;
                if (body.RayCast(Body.Position, endLine)) return true;
            }
            return false;
        }
        Vector2 startP, endP = Vector2.Zero;
        public bool Collide(int angle, Body body, float dist, Vector2 offset)
        {
            endP = new Vector2();
            endP.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * dist;
            endP.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * dist;
            startP = Body.Position + offset;
            endP = startP + endP;
            return body.RayCast(startP, endP);
        }
        public bool Collide(int[] angles, Body body, float dist, Vector2 offset)
        {
            endP = new Vector2();
            for (int i = 0; i < angles.Length; i++)
            {
                endP.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angles[i])), 2) * dist;
                endP.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angles[i])), 2) * dist;
                startP = Body.Position + offset;
                endP = startP + endP;
                if (body.RayCast(startP, endP)) return true;
            }
            return false;
        }
        /// <summary>
        /// Check if body collides
        /// </summary>
        /// <param name="tempFixture"></param>
        /// <returns></returns>
        public bool Collide(int angle, Body body, ref Vector2 dist)
        {
            Vector2 endPoint = new Vector2();
            endPoint.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * dist.X;
            endPoint.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * dist.Y;
            startLine = this.Body.Position;
            endLine = Body.Position + endPoint;
            return body.RayCast(Body.Position, Body.Position + endPoint);
        }
        /// <summary>
        /// Is Facing
        /// </summary>
        /// <param name="eventProcessor"></param>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool IsFacing(Vector2 pos, Body body)
        {
            if (body == null)
            {
                // Use Rays instead
                Vector2 targetAngle = (pos - this.Position); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
                float desiredAngle = (float)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);

                //if (desiredAngle < 0) desiredAngle += 360;
                //if (desiredAngle > 360) desiredAngle -= 360;

                float min = MathHelper.ToRadians(desiredAngle - 90);
                float max = MathHelper.ToRadians(desiredAngle + 90);
                float angle = MathHelper.ToRadians(Angle);

                return (angle < max && angle > min);
            }
            else
            {
                return Collide(Angle, body, (int)Vector2.Distance(OriginPosition, body.Position) * 2);
            }
        }
        /// <summary>
        /// Is Facing
        /// </summary>
        /// <param name="eventProcessor"></param>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool IsFacing(Body body, float dist)
        {
            return Collide(Angle, body, dist + ConvertUnits.ToSimUnits(16));
        }
        /// <summary>
        /// Is Facing
        /// </summary>
        /// <param name="eventProcessor"></param>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool IsFacing(Vector2 pos, Body body, float dist)
        {
            if (body == null || Body == null)
            {
                // Use Rays instead
                Vector2 targetAngle = (pos - this.Position); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
                float desiredAngle = (float)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);

                //if (desiredAngle < 0) desiredAngle += 360;
                //if (desiredAngle > 360) desiredAngle -= 360;

                float min = MathHelper.ToRadians(desiredAngle - 90);
                float max = MathHelper.ToRadians(desiredAngle + 90);
                float angle = MathHelper.ToRadians(Angle);

                return (angle < max && angle > min);
            }
            else
            {
                return Collide(Angle, body, ConvertUnits.ToSimUnits(9999));
            }
        }
        /// <summary>
        /// Is Facing
        /// </summary>
        /// <param name="eventProcessor"></param>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool IsFacing(Vector2 pos, int _angle)
        {
            Vector2 targetAngle = (pos - this.Position); targetAngle = ConvertUnits.ToDisplayUnits(targetAngle);
            float desiredAngle = (float)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);

            if (desiredAngle < 0) desiredAngle += 360;
            if (desiredAngle > 360) desiredAngle -= 360;

            float min = MathHelper.ToRadians(desiredAngle - 30);
            float max = MathHelper.ToRadians(desiredAngle + 30);
            float angle = MathHelper.ToRadians(_angle);

            return (angle < max && angle > min);
        }
        /// <summary>
        /// Check For Obstacles - Used to make sure there is nothing the way for the this and subject.
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool CheckForObstacles(EventProcessor subject, int dist)
        {
            Vector2 newdist = ConvertUnits.ToSimUnits(Animation.CollisionCentroid);
            newdist.X += dist; newdist.Y += dist;
            // Loop through tempFixtureetries on map to see if anything obstructs target
            for (int j = 0; j < Global.Instance.CurrentMap.MapBodies.Count - 1; j++)
            {
                if (Collide(Global.Instance.CurrentMap.MapBodies[j], ref newdist))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Check For Obstacles - Used to make sure there is nothing the way for the this and subject.
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool CheckForObstacles(EventProcessor subject, Vector2 dist)
        {
            Vector2 newdist = ConvertUnits.ToSimUnits(Animation.CollisionCentroid);
            newdist.X += dist.X; newdist.Y += dist.Y;

            // Loop through tempFixtureetries on map to see if anything obstructs target
            for (int j = 0; j < Global.Instance.CurrentMap.MapBodies.Count - 1; j++)
            {
                if (Collide(Global.Instance.CurrentMap.MapBodies[j], ref newdist))
                    return false;
            }
            return true;
        }
        #endregion

        #region Events: Phyics Collision/Seperation, Menu Closed
        internal List<Body> collisionList = new List<Body>();
        List<Body> platformerList = new List<Body>();
        /// <summary>
        /// Called when a collision occurs.
        /// </summary>
        /// <param name="tempFixtureA"></param>
        /// <param name="tempFixtureB"></param>
        /// <param name="contactList"></param>
        /// <returns></returns>
        public bool OnCollision(Fixture tempFixtureA, Fixture tempFixtureB, Contact contacts)
        {
            if (tempFixtureA.Body.UserData != tempFixtureB.Body.UserData && CollisionOn)
            {

                Fixture thisEvent = (tempFixtureA.Body.UserData == this ? tempFixtureA : tempFixtureB);
                Fixture obj = (tempFixtureA.Body.UserData == this ? tempFixtureB : tempFixtureA);

                // Check if layer is visible
                bool visible = true;
                if (obj.Body.UserData is EventProcessor)
                    visible = (Global.Instance.CurrentMap.IsLayerVisible(((EventProcessor)obj.Body.UserData).LayerIndex));
                else if (obj.Body.UserData is ProjectileProcessor)
                    visible = (Global.Instance.CurrentMap.IsLayerVisible(((ProjectileProcessor)obj.Body.UserData).LayerIndex));
                else if (obj.Body.UserData is TileData)
                    visible = (Global.Instance.CurrentMap.IsLayerVisible(((int)obj.Body.LayerIndex)));
                else if (obj.Body.UserData is CollisionData)
                    visible = (Global.Instance.CurrentMap.IsLayerVisible(((int)obj.Body.LayerIndex)));
                if (!visible)
                    return false;
                if (obj.Body.UserData is ProjectileProcessor)
                {
                    if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.ProjectileCollision)
                        isProgramActive = true;

                    if (obj.Body.UserData is ProjectileProcessor)
                    {
                        CollidingProjectile = ((ProjectileProcessor)obj.Body.UserData).Data.ID;
                    }
                    return visible;
                }
                // Check Program Activation
                if (!isProgramActive && pageIndex > -1 && pageIndex < data.Pages.Count)
                {
                    if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.Collision && !collisionList.Contains(obj.Body))
                    {
                        if (obj.Body.UserData is EventProcessor)
                            isProgramActive = (data.Pages[pageIndex].TouchEventIDs.Contains(((EventProcessor)obj.Body.UserData).data.ID) || data.Pages[pageIndex].TouchTemplateEventIDs.Contains(((EventProcessor)obj.Body.UserData).data.TemplateID));
                        else if (data.Pages[pageIndex].MapCollisionTrigger)
                            isProgramActive = true;
                        else if (data.Pages[pageIndex].TouchEventIDs.Count == 0 && data.Pages[pageIndex].TouchTemplateEventIDs.Count == 0 && !data.Pages[pageIndex].MapCollisionTrigger)
                            isProgramActive = true;
                    }
                }

                if (obj.Body.UserData is TileData)
                {
                    if (((TileData)obj.Body.UserData).IsPlatform)
                    {
                        if (platformerList.Contains(obj.Body)) return false;
                        if (Collide(270, obj.Body, thisEvent.Body.Height, Body.Width * 0.5f, thisEvent.Body.Height * -0.5f))
                        {
                            collisionList.Remove(obj.Body);
                            platformerList.Add(obj.Body);
                            return false;
                        }
                    }
                }
                if (obj.Body.UserData is CollisionData)
                {
                    if (((CollisionData)obj.Body.UserData).IsPlatform)
                    {
                        if (platformerList.Contains(obj.Body)) return false;
                        if (Collide(270, obj.Body, thisEvent.Body.Height, Body.Width * 0.5f, thisEvent.Body.Height * -0.5f))
                        {
                            collisionList.Remove(obj.Body);
                            platformerList.Add(obj.Body);
                            return false;
                        }
                    }
                }
                if (!collisionList.Contains(obj.Body))
                    collisionList.Add(obj.Body);

                bool objPass = (obj.Body.UserData is EventProcessor ? ((EventProcessor)obj.Body.UserData).PassThrough : false);
                if (pageIndex > -1 && (this.PassThrough || objPass))
                    return false;


            }

            if (pageIndex > -1 && PassThrough)
                return false;

            return CollisionOn;
        }
        /// <summary>
        /// Called when a collision occurs.
        /// </summary>
        /// <param name="tempFixtureA"></param>
        /// <param name="tempFixtureB"></param>
        /// <param name="contactList"></param>
        /// <returns></returns>
        public bool OnBattleCollision(Fixture tempFixtureA, Fixture tempFixtureB, Contact contactList)
        {
            if (tempFixtureA.Body.UserData is ProjectileProcessor || tempFixtureB.Body.UserData is ProjectileProcessor)
            {
                Fixture thisEvent = (tempFixtureA.Body.UserData == this ? tempFixtureA : tempFixtureB);
                Fixture obj = (tempFixtureA.Body.UserData == this ? tempFixtureB : tempFixtureA);

                if (obj.Body.UserData is ProjectileProcessor && ((ProjectileProcessor)obj.Body.UserData).Owner != this)
                {
                    CollidingProjectile = ((ProjectileProcessor)obj.Body.UserData).Data.ID;
                }
            }
            return false;
        }
        /// <summary>
        /// Called when a seperation occurs.
        /// </summary>
        /// <param name="tempFixtureA"></param>
        /// <param name="tempFixtureB"></param>
        /// <param name="contactList"></param>
        /// <returns></returns>
        public void OnSeperation(Fixture tempFixtureA, Fixture tempFixtureB)
        {
            Fixture thisEvent = (tempFixtureA.Body.UserData == this ? tempFixtureA : tempFixtureB);
            Fixture obj = (tempFixtureA.Body.UserData == this ? tempFixtureB : tempFixtureA);
            collisionList.Remove(obj.Body);
        }
        /// <summary>
        /// Menu Closed
        /// Call when child menu or message closes.
        /// </summary>
        public void MenuClosed()
        {
            if (actionTakingPlace == ActionType.Message || actionTakingPlace == ActionType.Menu)
            {
                actionTakingPlace = ActionType.None;
                waitActionCompelition = false;
            }
        }
        #endregion

        #region Method: Load Event
        /// <summary>
        /// Load Event
        /// </summary>
        public override void Load()
        {
            DisposeBodies();
            // Get animation, action, and direction.
            if (CurrentAction != null && Global.World != null)
            {
                // Set offset to zero
                Animation.Offset = Vector2.Zero;
                // Only add if there is a body
                if (CurrentAction.CollisionBody.Count > 1)
                {
                    Vertices clone = new Vertices(CurrentAction.CollisionBody);
                    clone = Vertices.Simplify(clone);
                    Vector2 centroid = -clone.GetCentroid();
                    clone.Translate(ref centroid);

                    List<Vertices> vertices = BayazitDecomposer.ConvexPartition(clone);

                    //scale the vertices from graphics space to sim space
                    Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * 1f;
                    foreach (Vertices v1 in vertices)
                    {
                        v1.Scale(ref vertScale);
                    }
                    if (vertices.Count > 1)
                        Body = BodyFactory.CreateCompoundPolygon(Global.World, vertices, Mass);
                    else
                        Body = BodyFactory.CreatePolygon(Global.World, vertices[0], Mass);

                    //Body = BodyFactory.CreateCircle(Global.World, 60f/100f, 1f);
                    Body.UserData = this;
                    Body.OnCollision += OnCollision;
                    Body.OnSeparation += OnSeperation;
                    Body.CollisionCategories = Category.Cat1;
                    Body.CollidesWith = Category.Cat1;


                    if (pageIndex > -1 && pageIndex < data.Pages.Count)
                    {
                        Body.IsStatic = Static;
                        Body.IgnoreGravity = IgnoreGravity;
                        Body.CustomGravity = CustomGravity;
                        Body.Gravity = Gravity;
                        Body.LinearDamping = LinearDrag;
                        Body.AngularDamping = RotationalDrag;
                        Body.Restitution = Bounce;
                        Body.Friction = Friction;
                        Body.IsSensor = PassThrough;
                        Body.Mass = Mass;
                        if (data.Pages[pageIndex].CustomMOI) Body.Inertia = MomentOfInertia;

                        if (data.Pages[pageIndex].SyncAngleToRotation)
                            Body.Rotation = MathHelper.ToRadians(Angle + 90);
                        Body.FixedRotation = IsFixedRotation;
                    }

                    if (GravityPoint != null)
                        SetGravityEmitter(GravityPoint.Strength, GravityPoint.Radius);

                    // If Player
                    if (IsPlayer)
                    {
                        if (PartyIndex > 0)
                        {
                            Global.Instance.Player[0].Body.ResetIgnore();
                            for (int partyIndex = 1; partyIndex < Global.Instance.Player.Count; partyIndex++)
                            {
                                if (Global.Instance.Player[partyIndex].Body != null)
                                {
                                    Global.Instance.Player[0].Body.IgnoreCollisionWith(Global.Instance.Player[partyIndex].Body);
                                }
                            }
                        }
                    }
                    Animation.Origin = CurrentAction.CollisionBody.GetCentroid();
                    // Get Offset
                    Animation.Offset = ConvertUnits.ToDisplayUnits(Body.Position);
                    // Set Position
                    Body.Position = ConvertUnits.ToSimUnits(NativePosition);

                    Body.Position += ConvertUnits.ToSimUnits(CurrentAction.CollisionBody.GetCentroid());

                    // Reset Joints
                    Attachments.Clear();
                    Joints.Clear();

                    if (pageIndex > -1 && pageIndex < data.Pages.Count)
                    {
                        // Add Any Attachments
                        AttachmentJoint attachment;
                        for (int a = 0; a < data.Pages[pageIndex].Attachments.Count; a++)
                        {
                            attachment = data.Pages[pageIndex].Attachments[a];
                            // Setup
                            EventProcessor e = Global.Instance.CurrentMap.AddEvent(GameData.Events.GetData(attachment.AttachmentID), this.Position, LayerIndex);
                            e.SetupAttachment();
                            if (e.Body != null)
                            {
                                if (attachment.Booleans[3]) // Sensor
                                {
                                    if (AttachmentClone == null) AttachmentClone = Body.DeepClone();
                                    AttachmentClone.BodyType = BodyType.Kinematic; AttachmentClone.IsSensor = true; AttachmentClone.UserData = this;
                                    Joints.Add(SetupJoint(attachment, e, AttachmentClone));
                                }
                                else
                                    Joints.Add(SetupJoint(attachment, e, Body));
                                Attachments.Add(e);
                            }
                            else
                                Global.Instance.CurrentMap.RemoveProcessor(e);
                        }

                    }
                    // Add Any Pins That Exist
                    FixedRevoluteJoint pin;
                    for (int i = 0; i < CurrentAction.Pins.Count; i++)
                    {
                        //pin = JointFactory.CreateFixedRevoluteJoint(Global.World, Body, CurrentAction.Pins[i].Position + Position - Animation.Origin, Body.Position);
                        //pin.MotorEnabled = true;
                        //pin.MotorTorque = 100f;
                        //pin.MotorSpeed = 3f;
                        //Global.World.AddJoint(pin);
                    }
                    if (AttachmentClone != null)
                    {
                        AttachmentClone.Position = Body.Position;
                        AttachmentClone.Rotation = Body.Rotation;
                    }

                }
                else if (CurrentAction.CollisionBody.Count == 1)
                {
                    if (Body != null)
                    {
                        Body.OnCollision -= OnCollision;
                        Body.OnSeparation -= OnSeperation;
                        Body.Dispose();
                        if (AttachmentClone != null) AttachmentClone.Dispose();
                    }
                }
                // Only add if there is a body
                if (CurrentAction.HitBody.Count > 1)
                {
                    Vertices clone = new Vertices(CurrentAction.HitBody);
                    clone = Vertices.Simplify(clone);
                    Vector2 centroid = -clone.GetCentroid();
                    clone.Translate(ref centroid);

                    List<Vertices> vertices = BayazitDecomposer.ConvexPartition(clone);

                    //scale the vertices from graphics space to sim space
                    Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * 1f;
                    foreach (Vertices v1 in vertices)
                    {
                        v1.Scale(ref vertScale);
                    }
                    if (vertices.Count > 1)
                        BattleBody = BodyFactory.CreateCompoundPolygon(Global.World, vertices, 1);
                    else
                        BattleBody = BodyFactory.CreatePolygon(Global.World, vertices[0], 1);

                    BattleBody.UserData = this;
                    BattleBody.OnCollision += OnBattleCollision;

                    BattleBody.CollisionCategories = Category.Cat2;
                    BattleBody.CollidesWith = Category.Cat2;
                    BattleBody.IsStatic = true;
                    // Set Position
                    if (Body != null)
                        BattleBody.Position = Body.Position - ConvertUnits.ToSimUnits(Animation.CollisionCentroid + Animation.Action.HitBody.GetCentroid());
                    else
                        BattleBody.Position = ConvertUnits.ToSimUnits(NativePosition);
                }
                else if (CurrentAction.HitBody.Count == 1)
                {
                    if (BattleBody != null)
                    {
                        BattleBody.OnCollision -= OnBattleCollision;
                        BattleBody.Dispose();
                    }
                }
            }

            // Setup Branches
            if (pageIndex > -1 && pageIndex < Data.Pages.Count)
            {
                if (CurrentBranch is EventPageData)
                    CurrentBranch = data.Pages[pageIndex];
                else // Event Program Data
                    CurrentBranch = LoadProgramData(data.Pages[pageIndex], CurrentBranch);

                for (int j = 0; j < LastBranch.Count; j++)
                {
                    if (LastBranch[j] is EventPageData)
                        LastBranch[j] = data.Pages[pageIndex];
                    else // Event Program Data
                        LastBranch[j] = LoadProgramData(data.Pages[pageIndex], LastBranch[j]);
                }

                foreach (Bookmark bookmark in labels.Values)
                {
                    if (bookmark.CurrentBranch is EventPageData)
                        bookmark.CurrentBranch = data.Pages[pageIndex];
                    else // Event Program Data
                        bookmark.CurrentBranch = LoadProgramData(data.Pages[pageIndex], bookmark.CurrentBranch);

                    for (int j = 0; j < bookmark.LastBranch.Count; j++)
                    {
                        if (bookmark.LastBranch[j] is EventPageData)
                            bookmark.LastBranch[j] = data.Pages[pageIndex];
                        else // Event Program Data
                            bookmark.LastBranch[j] = LoadProgramData(data.Pages[pageIndex], bookmark.LastBranch[j]);
                    }

                }
            }
            // Action Taking Place
            if (actionTakingPlace == ActionType.Menu || actionTakingPlace == ActionType.Message)
                actionTakingPlace = ActionType.None;

            MovementProcessor.SetOwner(this);
        }
        /// <summary>
        /// Load Program Data
        /// </summary>
        /// <param name="eventPageData"></param>
        private IEventProgram LoadProgramData(IEventProgram parent, IEventProgram branch)
        {
            IEventProgram temp;
            for (int i = 0; i < parent.Programs.Count; i++)
            {
                if (parent.Programs[i].UniqueID == branch.UniqueID)
                    return parent.Programs[i];
                temp = LoadProgramData(parent.Programs[i], branch);
                if (temp != null)
                    return temp;
            }
            return null;
        }
        #endregion

        #region Draw: Event
        /// <summary>
        /// Draw Event
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            // Draw only if  data exists and page exists
            if (data != null && !Erase)
            {
#if !SILVERLIGHT
                if (!ShaderProcess.IsNull)
                {
                    ShaderProcess.Process();
                    foreach (EffectPass pass in ShaderProcess.Effect.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        Animation.Draw(gameTime);
                        // Draw Anchored Animation
                        DrawAnchoredAnimations(gameTime);
                    }
                }
                else
                {
#endif
                    Animation.Draw(gameTime);
                    // Draw Anchored Animation
                    DrawAnchoredAnimations(gameTime);

#if !SILVERLIGHT
                }
#endif
                // Draw Battler
                if (Battler != null)
                    Battler.Draw(gameTime);
                // Draw Animations
                for (int i = 0; i < Animations.Count; i++)
                    Animations[i].Draw(gameTime);
                // Draw Particle Processor
                if (ParticleProcessor != null)
                    ParticleProcessor.Draw(gameTime);
#if DEBUG
                if (Global.ShowCollisionMapping)
                {
                    GraphicsHelper.DrawLine(startLine, endLine, Color.Yellow, 1, GraphicsHelper.Texture);
                    GraphicsHelper.DrawLine(startP, endP, Color.Purple, 1, GraphicsHelper.Texture);

                    GraphicsHelper.FillRectangle(GraphicsHelper.Texture, new Rectangle((int)Position.X, (int)Position.Y, 8, 8), Color.Purple);
                }
#endif
            }
        }
        /// <summary>
        /// Draw Anchored Animations
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        private void DrawAnchoredAnimations(GameTime gameTime)
        {
            foreach (AnimationProcessor processor in EquipmentAnimations.Values)
            {
                // Set Action
                if (processor.ActionIndex != ActionIndex)
                    processor.Setup(processor.AnimationID, Battler.Actions[(int)ActionIndex], Animation.AnimationID, ActionIndex);
                // Set Position
                processor.Anchor(Animation);
                processor.Draw(gameTime);
            }
        }
        /// <summary>
        /// Returns the sprite's effect
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private SpriteEffects GetSpriteEffect(AnimationSprite sprite)
        {
            if (sprite.HorizontalFlip)
                return SpriteEffects.FlipHorizontally;
            else if (sprite.VerticalFlip)
                return SpriteEffects.FlipVertically;
            else
                return SpriteEffects.None;
        }
        #endregion

        /// <summary>
        /// Dispose the event
        /// </summary>
        public override void Dispose()
        {
            DisposeBodies();
        }
    }

    /// <summary>
    /// Bookmarks the location of program index.
    /// Used by Label and GoToLabel
    /// </summary>
    public class Bookmark
    {
        public IEventProgram CurrentBranch;
        public List<IEventProgram> LastBranch = new List<IEventProgram>();
        public List<int> LastProgramIndex = new List<int>();
        public int programIndex = 0;
    }

    /// <summary>
    /// Determines the action type.
    /// Used for waiting completion.
    /// </summary>
    public enum ActionType
    {
        None,
        Movement,
        Jumping,
        Tint,
        PictureTint,
        Flash,
        Shake,
        Menu,
        Message,
        Video,
        FindingPath,
        MovementProgram
    }

    public enum EventAction
    {
        Idle,
        Walk,
        Attack,
        Defend,
        Skill,
        Magic,
        Item,
        Hit,
        Jump,
        Death
    }

    public enum BattleState
    {
        None,
        Basic,
        Item,
        Skill
    }
}