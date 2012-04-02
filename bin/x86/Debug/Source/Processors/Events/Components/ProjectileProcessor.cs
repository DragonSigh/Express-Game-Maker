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

    public class ProjectileProcessor : Projectile
    {        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public ProjectileProcessor()
        { }
        /// <summary>
        /// Create Projectile
        /// </summary>
        /// <param name="data"></param>
        /// <param name="owner"></param>
        /// <param name="target"></param>
        /// <param name="equipment"></param>
        /// <param name="hostileList"></param>
        public override Projectile Create(ProjectileData data, EventProcessor owner, EventProcessor target, EquipmentData equipment, List<int> hostileList)
        {
            // Setup Projectile
            Setup(data, owner, target, hostileList);
            // Setup Equipment
            Equipment = equipment;

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
        public override Projectile Create(ProjectileData data, EventProcessor owner, EventProcessor target, SkillData skill, List<int> hostileList)
        {
            // Setup Projectile
            Setup(data, owner, target, hostileList);
            // Setup Equipment
            Skill = skill;

            return this;
        }
        /// <summary>
        /// Setup the projectile
        /// </summary>
        /// <param name="data"></param>
        /// <param name="owner"></param>
        /// <param name="target"></param>
        private void Setup(ProjectileData data, EventProcessor owner, EventProcessor target, List<int> hostileList)
        {
            Data = data;
            isMoving = false;
            Wait = 0;
            Hit = false;
            Erase = false;
            // Battle
            Owner = owner;
            OwnerBattler = owner.Battler;
            Target = target;
            Hostiles = hostileList;
            // Settings
            LayerIndex = owner.LayerIndex;
            // Program Settings
            Programs = data.Programs;
            RepeatProgram = data.Repeat;
            LifeTimeCounter = data.LifeTime;
            DecayFrames = data.DecayFrames;
            programIndex = 0;
            // Set Direction
            SetupAngle(owner, data.Direction, data);
            // Set Animation
            Animation.Setup(data.AnimationID, data.ActionID);
            Animation.InstantStart();
            // Setup Collision
            SetupCollision(owner, data);
            // Erase if animation is null
            if (Animation.Action == null)
                Erase = true;
            // Tracking Enabled
            if (data.TrackingEnabled)
            {
                Global.Instance.ActiveCamera.Scroll = Vector2.Zero;
                Global.Instance.ActiveCamera.TrackingObject = this;
            }
        }
        /// <summary>
        /// Update the projectile
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Update the draw order depending on Y
            if (DrawOrder != Position.Y)
            {
                DrawOrder = (int)Position.Y;
            }

            if (!Hit)
            {
                if (Wait <= 0)
                {
                    if (!(isMoving && WaitProgram))
                    {
                        // Update Programs
                        if (programIndex > -1 && programIndex < Programs.Count)
                        {
                            switch (Programs[programIndex].ProgramCategory)
                            {
                                case ProgramCategory.Movement: // Movement/Explode
                                    switch (Programs[programIndex].Code)
                                    {
                                        case 0: // Movement
                                            Movement(Programs[programIndex]);
                                            break;
                                        case 1: // Apply Force
                                            ApplyForce(Programs[programIndex]);
                                            break;
                                        case 2: // Explode
                                            Explode(null);
                                            break;
                                    }
                                    break;
                                case ProgramCategory.Other: // Wait
                                    Wait = (int)Programs[programIndex].Value[0];
                                    programIndex++;
                                    break;
                            }
                        }
                        else
                        {
                            if (RepeatProgram)
                                programIndex = 0;
                        }
                    }
                    // Update Movement
                    if (isMoving)
                    {
                        if (MoveTo(ref newPosition, ForceType))
                        {
                            newPosition = Position;
                            if (Body != null)
                            {
                                Body.ClearForce();
                                Body.ClearImpulse();
                            }
                            isMoving = false;
                            WaitProgram = false;
                        }
                    }
                }
                else
                    Wait--;
            }
            else
            {
                if (Data.OnHitDecay) // Frames
                {
                    if (DecayFrames <= 0)
                        Erase = true;
                    DecayFrames--;
                }
                else // Animation
                {
                    if (!HitAnimation.IsAnimating)
                        Erase = true;
                }
            }
            // Update Position
            if (!Hit || HitAnimation.Action == null)
            {
                if (Body != null)
                {
                    Animation.Rotation = Body.Rotation;
                    if (Data.SyncAngleToRotation)
                        SetAngle((int)MathHelper.ToDegrees(Body.Rotation) - 90);
                }
                Animation.Position = Position;
                Animation.ApplyAngleToDirection(Angle);

                Animation.Update(gameTime);
            }
            else
            {
                HitAnimation.Position = Position;
                HitAnimation.ApplyAngleToDirection(Angle);

                HitAnimation.Update(gameTime);
            }
            // Update Lifetime
            LifeTimeCounter--;
            // Erase if lifetime is 0
            if (LifeTimeCounter <= 0)
                Erase = true;
            // If Erase
            if (Erase)
            {
                if (Data.TrackingEnabled && Global.Instance.ActiveCamera.TrackingObject == this)
                {
                    Vector2 scrollTo = Global.Instance.ActiveCamera.VisibleArea.Center();
                    Global.Instance.ActiveCamera.TrackingObject = Global.Instance.Player[0];
                    Global.Instance.ActiveCamera.Position = Global.Instance.ActiveCamera.TrackingObject.Position;

                    Vector2 cameraPosition = Global.Instance.ActiveCamera.TrackingObject.Position;
                    // Clamp
                    if (Global.Instance.LockScreen.X > 0 ||
                             Global.Instance.LockScreen.Y > 0 ||
                             Global.Instance.LockScreen.Width > 0 ||
                             Global.Instance.LockScreen.Height > 0)
                    {
                        cameraPosition.X = Global.Instance.LockScreen.X + Global.Instance.LockScreen.Width;
                        cameraPosition.Y = Global.Instance.LockScreen.Y + Global.Instance.LockScreen.Height;
                    }
                    else
                    {
                        cameraPosition.X = MathHelper.Min(MathHelper.Max(Global.Instance.ActiveCamera.ScreenPosition.X, Global.Instance.ActiveCamera.TrackingObject.Position.X), Global.Instance.CurrentMap.Data.Size.X - Global.Instance.ActiveCamera.ScreenPosition.X);
                        cameraPosition.Y = MathHelper.Min(MathHelper.Max(Global.Instance.ActiveCamera.ScreenPosition.Y, Global.Instance.ActiveCamera.TrackingObject.Position.Y), Global.Instance.CurrentMap.Data.Size.Y - Global.Instance.ActiveCamera.ScreenPosition.Y);
                    }
                    Global.Instance.ActiveCamera.Position = cameraPosition;

                    Vector2 t = Global.Instance.ActiveCamera.VisibleArea.Center();
                    Global.Instance.ActiveCamera.Scroll = Global.Instance.ActiveCamera.Scroll + scrollTo - t;
                    t = Global.Instance.ActiveCamera.Scroll;
                    Global.Instance.ActiveCamera.Center(60);
                }
            }
        }
        /// <summary>
        /// Hit
        /// </summary>
        public void PerformHit()
        {
            if (!Data.EnvironmentalCollision)
            {
                Hit = true;
                if (Data.HitActionID > -1 && Data.HitAnimationID > -1)
                {
                    HitAnimation.Position = Position;
                    HitAnimation.ApplyAngleToDirection(Angle);
                    HitAnimation.Setup(Data.HitAnimationID, Data.HitActionID);
                }
            }
        }
        /// <summary>
        /// Move To
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="ForceType"></param>
        /// <returns></returns>
        private bool MoveTo(ref Vector2 point, ForceType forceType)
        {
            if (Body != null && !Data.IsStatic)
            {
                if ((Position - point).Length() < 10) // If it is 10 units from the destination, we consider it has arrived
                    return true;

                Vector2 amount = (point - Position);
                amount.X = (float)Math.Round(Math.Cos((float)Math.Atan2(amount.Y, amount.X)), 2) * Force;
                amount.Y = (float)Math.Round(Math.Sin((float)Math.Atan2(amount.Y, amount.X)), 2) * Force;

                if (forceType == ForceType.Force)
                    Body.ApplyForce(ref amount);
                else
                    Body.ApplyLinearImpulse(ref amount);
            }
            else if (Body != null && Data.IsStatic)
            {
                float length = (Position - point).Length();
                if (length <= Data.Speed) // If it is 10 units from the destination, we consider it has arrived
                {
                    Position = point;
                    return true;
                }
                Vector2 amount = (point - Position);
                amount.X = (float)Math.Round(Math.Cos((float)Math.Atan2(amount.Y, amount.X)), 2) * Data.Speed;
                amount.Y = (float)Math.Round(Math.Sin((float)Math.Atan2(amount.Y, amount.X)), 2) * Data.Speed;
                Position += amount;
            }
            return false;
        }
        /// <summary>
        /// Apply Force
        /// </summary>
        /// <param name="data"></param>
        private void ApplyForce(EventProgramData data)
        {
            if (Body != null)
            {
                Vector2 amount = Vector2.Zero;
                float value = ((int)data.Value[2] == 0 ? (float)data.Value[3] : Global.Variable((int)data.Value[3]));
                switch ((int)data.Value[0])
                {
                    case 0: // Forward
                        amount = ForceAmount(Angle, value);
                        break;
                    case 1: // Backward
                        amount = ForceAmount(Angle - 180, value);
                        break;
                    case 2: // Leftward
                        amount = ForceAmount(Angle - 90, value);
                        break;
                    case 3: // Rightward 
                        amount = ForceAmount(Angle + 90, value);
                        break;
                    case 4: // Toward Target
                        if (Target != null)
                        {
                            Vector2 targetAngle = Vector2.Zero;
                            if (Data.Direction != ProjectileDirectionType.VariablePos && Target != null)
                                targetAngle = (Target.Position - this.Position);
                            else if (Data.Direction == ProjectileDirectionType.VariablePos)
                                targetAngle = (TargetVector - this.Position);
                            // Calculate target To Move
                            amount = ForceAmount((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), value);
                            // Turn Toward
                            TurnToward(Target.Position);
                        }
                        break;
                    case 5: // Random
                        Random rand = new Random();
                        int angle = StartAngle;
                        while (ExMath.Between(angle, StartAngle - 30, StartAngle + 30))
                            angle = rand.Next(0, 360);

                        amount = ForceAmount(angle, value);
                        break;
                }
                // Apply Force
                switch ((ForceType)(int)data.Value[1])
                {
                    case ForceType.Force:
                        Body.ApplyForce(ref amount);
                        break;
                    case ForceType.Impulse:
                        Body.ApplyLinearImpulse(ref amount);
                        break;
                    case ForceType.Torque:
                        Body.ApplyTorque(value);
                        break;
                    case ForceType.AngularImpulse:
                        Body.ApplyAngularImpulse(value);
                        break;
                }
                programIndex++;
            }
            else
                programIndex++;
        }
        /// <summary>
        /// Movement
        /// </summary>
        /// <param name="data"></param>
        private void Movement(EventProgramData data)
        {
            ForceType = (ForceType)(int)data.Value[1];
            switch ((int)data.Value[0])
            {
                case 0: // Forward
                    Move(Angle, (int)data.Value[2], (bool)data.Value[3]);
                    WaitProgram = (bool)data.Value[4];
                    programIndex++;
                    break;
                case 1: // Backward
                    Move(Angle - 180, (int)data.Value[2], (bool)data.Value[3]);
                    WaitProgram = (bool)data.Value[4];
                    programIndex++;
                    break;
                case 2: // Leftward
                    Move(Angle - 90, (int)data.Value[2], (bool)data.Value[3]);
                    WaitProgram = (bool)data.Value[4];
                    programIndex++;
                    break;
                case 3: // Rightward
                    Move(Angle + 90, (int)data.Value[2], (bool)data.Value[3]);
                    WaitProgram = (bool)data.Value[4];
                    programIndex++;
                    break;
                case 4: // Toward Target
                    if (Target != null)
                    {
                        WaitProgram = (bool)data.Value[4];
                        Vector2 targetAngle = Vector2.Zero;
                        if (Data.Direction != ProjectileDirectionType.VariablePos && Target != null)
                            targetAngle = (Target.Position - this.Position);
                        else if (Data.Direction == ProjectileDirectionType.VariablePos)
                            targetAngle = (TargetVector - this.Position);
                        // Calculate target To Move
                        Move((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), (int)data.Value[2], (bool)data.Value[3]);
                        programIndex++;
                    }
                    break;
                case 5: // Random
                    WaitProgram = (bool)data.Value[4];
                    Random rand = new Random();
                    int angle = StartAngle;
                    while (ExMath.Between(angle, StartAngle - 30, StartAngle + 30))
                        angle = rand.Next(0, 360);
                    Move(angle, (int)data.Value[2], (bool)data.Value[3]);
                    programIndex++;
                    break;
            }
        }
        /// <summary>
        /// Move
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="pixels"></param>
        public void Move(int angle, int distance, bool turn)
        {
            if (angle < 0) angle += 360;
            if (angle > 360) angle -= 360;

            newPosition.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * distance;
            newPosition.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * distance;
            newPosition += Position;
            isMoving = true;

            if (turn)
                Angle = angle;

            if (Data.SyncAngleToRotation && Body != null)
                Body.Rotation = MathHelper.ToRadians(Angle + 90);

            Animation.ApplyAngleToDirection(Angle);
            if (Animation.animationOn && !Animation.IsAnimating)
                Animation.Start();
        }
        /// <summary>
        /// Force Amount
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Vector2 ForceAmount(int angle, float force)
        {
            if (angle < 0) angle += 360;
            if (angle > 360) angle -= 360;

            Vector2 amount = new Vector2(0, 0);
            amount.X = (float)Math.Cos(MathHelper.ToRadians(angle)) * force;
            amount.Y = (float)Math.Sin(MathHelper.ToRadians(angle)) * force;
            return amount;
        }
        /// <summary>
        /// Turn Toward
        /// </summary>
        /// <param name="vector2"></param>
        private void TurnToward(Vector2 pos)
        {
            Vector2 targetAngle = (pos - this.Position);
            // Calculate target To Move
            SetAngle((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), true);

            Animation.ApplyAngleToDirection(Angle);
        }
        /// <summary>
        /// Set Angle
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="reset"></param>
        private void SetAngle(int angle, bool reset)
        {
            if (angle < 0) angle += 360;
            if (angle > 360) angle -= 360;
            // Set Angle
            Angle = angle;
            // Reset Rotation
            if (reset && Data.SyncAngleToRotation && Body != null)
            {
                //Body.ResetTorque();
                Body.Rotation = MathHelper.ToRadians(Angle + 90);
            }
        }
        /// <summary>
        /// Explode
        /// </summary>
        private void Explode(EventProcessor _default)
        {
            if (!Data.EnvironmentalCollision)
                Body.ResetBaseDynamics();
            bool hit = false;
            AABB aabb;
            float radius = ConvertUnits.ToSimUnits(Data.EffectRadius);
            aabb.LowerBound = Position + new Vector2(-radius, -radius);
            aabb.UpperBound = Position + new Vector2(radius, radius);
            List<EventProcessor> alreadyHit = new List<EventProcessor>();
            // Query the world for overlapping shapes.
            Global.World.QueryAABB(
                fixture =>
                {
                    if (fixture.Body.UserData is EventProcessor && fixture.Body.UserData != Owner)
                    {
                        if (((EventProcessor)fixture.Body.UserData).Battler != null &&
                            !((EventProcessor)fixture.Body.UserData).Battler.IsDead() &&
                            ((EventProcessor)fixture.Body.UserData).BattleBody != null &&
                            !alreadyHit.Contains(((EventProcessor)fixture.Body.UserData)))
                        {
                            hit = true;
                            alreadyHit.Add(((EventProcessor)fixture.Body.UserData));
                            HitEvent(((EventProcessor)fixture.Body.UserData));
                        }
                    }
                    // Continue the query.
                    return true;
                }, ref aabb);

            if (!hit && _default != null && _default.Battler != null && !_default.Battler.IsDead())
                HitEvent(_default);
            PerformHit();
        }
        /// <summary>
        /// Draw the projectile
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime)
        {
            // Draw Animations
            if (!Hit || HitAnimation.Action == null)
                Animation.Draw(gameTime);
            else
                HitAnimation.Draw(gameTime);
#if DEBUG
            if (Global.ShowCollisionMapping)
            {
            }
#endif
        }
        /// <summary>
        /// Opposite Direction
        /// </summary>
        /// <param name="Direction"></param>
        /// <returns></returns>
        private bool IsOppositeDirection(int Direction)
        {
            if (Direction == 0 && StartAngle == 1)
                return true;
            if (StartAngle == 0 && Direction == 1)
                return true;
            if (Direction == 2 && StartAngle == 3)
                return true;
            if (Direction == 3 && StartAngle == 2)
                return true;
            if (Direction == 4 && StartAngle == 7)
                return true;
            if (Direction == 7 && StartAngle == 4)
                return true;
            if (Direction == 5 && StartAngle == 6)
                return true;
            if (Direction == 6 && StartAngle == 5)
                return true;
            return false;
        }
        /// <summary>
        /// Set Angle
        /// </summary>
        /// <param name="angle"></param>
        public void SetAngle(int angle)
        {
            if (angle < 0) angle += 360;
            if (angle > 360) angle -= 360;
            // Set Angle
            Angle = angle;
        }
        /// <summary>
        /// Set direction
        /// </summary>
        /// <param name="p"></param>
        private void SetupAngle(EventProcessor owner, ProjectileDirectionType type, ProjectileData data)
        {
            switch (type)
            {
                case ProjectileDirectionType.User:
                    Angle = Owner.Angle;
                    break;
                case ProjectileDirectionType.Random:
                    Random rand = new Random();
                    Angle = rand.Next(0, 360);
                    break;
                case ProjectileDirectionType.Custom:
                    Angle = data.Angle;
                    break;
                case ProjectileDirectionType.VariableAngle:
                    VariableData varA = Global.Instance.Variables.GetData(data.TargetAngle);
                    if (varA != null)
                        Angle = (int)varA.Value;
                    break;
                case ProjectileDirectionType.VariablePos:
                    VariableData varX = Global.Instance.Variables.GetData(data.TargetVarX);
                    VariableData varY = Global.Instance.Variables.GetData(data.TargetVarY);
                    if (varX != null && varY != null)
                    {
                        TargetVector = new Vector2(varX.Value, varY.Value);
                        Vector2 targetAngle = (TargetVector - owner.Position);
                        // Calculate Angle
                        Angle = (int)MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X));
                    }
                    break;
            }
            // Apply Offset
            Angle += data.OffsetAngle;
            if (Angle < 0) Angle += 360;
            if (Angle > 360) Angle -= 360;
            // Start Angle
            StartAngle = Angle;
            //
            if (Data.SyncAngleToRotation && Body != null)
                Body.Rotation = MathHelper.ToRadians(Angle + 90);
        }
        /// <summary>
        /// Setup Collision
        /// </summary>
        private void SetupCollision(EventProcessor owner, ProjectileData data)
        {
            // Get animation, action, and direction.
            if (Animation.Action != null)
            {
                // Only add if there is a body
                if (Animation.Action.CollisionBody.Count > 1)
                {
                    Vertices clone = new Vertices(Animation.Action.CollisionBody);
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
                        Body = BodyFactory.CreateCompoundPolygon(Global.World, vertices, (data.CustomMass ? data.Mass : Global.Project.Mass));
                    else
                        Body = BodyFactory.CreatePolygon(Global.World, vertices[0], 1);
                    Body.UserData = this;
                    Body.IgnoreGravity = data.IgnoreGravity;
                    Body.BodyType = (data.EnvironmentalCollision ? BodyType.Dynamic : BodyType.Kinematic);
                    Body.IsStatic = data.IsStatic;
                    Body.OnCollision += OnCollision;
                    if (!data.ProjectileCollision)
                        Body.CollisionGroup = 1;
                    else
                        Body.CollisionGroup = 0;

                    if (!data.EnvironmentalCollision)
                    {
                        Body.CollisionCategories = Category.Cat2;
                        Body.CollidesWith = Category.Cat2;
                    }
                    else
                    {
                        Body.CollisionCategories = Category.Cat2 | Category.Cat1;
                        Body.CollidesWith = Category.Cat2 | Category.Cat1;
                    }

                    Body.LinearDamping = (data.CustomLinearDrag ? data.LinearDrag : Global.Project.LinearDrag);
                    Body.AngularDamping = (data.CustomRotationalDrag ? data.RotationalDrag : Global.Project.RotationalDrag);
                    Body.Restitution = (data.CustomBounce ? data.Bounce : Global.Project.Bounce);
                    Body.Friction = (data.CustomFriction ? data.Friction : Global.Project.Friction);
                    Body.FixedRotation = data.IsFixedRotation;
                    Body.CustomGravity = data.CustomGravity;
                    Body.Gravity = data.Gravity;
                    Body.Mass = (data.CustomMass ? data.Mass : Global.Project.Mass);
                    Impulse = (data.CustomImpulse ? data.Impulse : Global.Project.Impulse);
                    Force = (data.CustomForce ? data.Force : Global.Project.Force);
                    if (data.CustomMOI) Body.Inertia = data.MomentOfInertia;


                    Animation.Origin = HitAnimation.Origin = Animation.Action.CollisionBody.GetCentroid();
                    // Get Offset
                    Animation.Offset = HitAnimation.Offset = ConvertUnits.ToDisplayUnits(Body.Position);
                    // Set Position
                    NativePosition = owner.Position;
                    Body.Position = ConvertUnits.ToSimUnits(NativePosition);

                    Animation.Position = NativePosition;

                    if (Animation.Action != null)
                    {
                        Animation.ApplyAngleToDirection(Angle);
                        Vector2 v = Animation.GetAnchorPosition(data.UseAnchor, data.AnchorTo, owner.Animation);
                        NativePosition += v;
                    }

                    Vector2 offset = NativePosition + -data.OffsetPosition;
                    NativePosition = offset.Rotate(MathHelper.ToRadians(Angle + 90), NativePosition);

                    // Set Position
                    Body.Position = ConvertUnits.ToSimUnits(NativePosition);
                    Animation.Position = Position;
                    Animation.ApplyAngleToDirection(Angle);

                    if (Data.SyncAngleToRotation)
                        Body.Rotation = MathHelper.ToRadians(Angle + 90);

                    Animation.Rotation = Body.Rotation;
                    BodyExists = true;

                }
            }
        }
        /// <summary>
        /// Called when a collision occurs.
        /// </summary>
        /// <param name="fixtureA"></param>
        /// <param name="fixtureB"></param>
        /// <param name="contactList"></param>
        /// <returns></returns>
        public bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contactList)
        {
            if (fixtureA.Body.UserData != fixtureB.Body.UserData && !Hit)
            {
                Fixture thisProjectile = (fixtureA.Body.UserData == this ? fixtureA : fixtureB);
                Fixture obj = (fixtureA.Body.UserData == this ? fixtureB : fixtureA);

                bool visible = true;
                if (obj.Body.UserData is EventProcessor)
                    visible = (Global.Instance.CurrentMap.IsLayerVisible(((EventProcessor)obj.Body.UserData).LayerIndex));
                else if (obj.Body.UserData is ProjectileProcessor)
                    visible = (Global.Instance.CurrentMap.IsLayerVisible(((ProjectileProcessor)obj.Body.UserData).LayerIndex));
                else if (obj.Body.UserData is TileData)
                    visible = (Global.Instance.CurrentMap.IsLayerVisible(((int)obj.Body.LayerIndex)));
                if (!visible)
                    return false;

                if (obj.Body.UserData is EventProcessor && ((EventProcessor)obj.Body.UserData) != Owner)
                {
                    if (((EventProcessor)obj.Body.UserData).Battler != null && ((EventProcessor)obj.Body.UserData).BattleBody == obj.Body)
                    {
                        int id = ((EventProcessor)obj.Body.UserData).Battler.ID;
                        if (((EventProcessor)obj.Body.UserData).Data is PlayerData) id = -1;
                        if (OwnerBattler is EnemyProcessor && !Hostiles.Contains(id) && !Data.FriendlyFire)
                            return false;
                        if (!Friendly(((EventProcessor)obj.Body.UserData).Battler, ((EventProcessor)obj.Body.UserData)))
                        {
                            Explode(((EventProcessor)obj.Body.UserData));
                            PerformHit();
                            return true;
                        }
                    }
                    else
                        return true;
                }
                else if (obj.Body.UserData is TileData)
                {
                    if (Data.DisableMapCollision)
                        return false;
                    if (((TileData)obj.Body.UserData).HeightPass >= Data.HeightPass)
                    {
                        if (!Hit)
                        { HitAnimation.Start(); Explode(null); }
                        PerformHit();
                        return true;
                    }
                }
                else if (obj.Body.UserData is ProjectileProcessor)
                {
                    if (Data.ProjectileCollision)
                    {
                        Explode(null);
                        PerformHit();
                        return true;
                    }
                }
                else if (obj.Body.UserData == null)
                    return true;
            }
            else if (HitAnimation.Action == null)
                return true;
            return false;
        }
        /// <summary>
        /// Hit Event
        /// </summary>
        /// <param name="eventProcessor"></param>
        private void HitEvent(EventProcessor ev)
        {
            if (ev.Battler != null && !Friendly(ev.Battler, ev))
            {
                HitAnimation.Start();
                // Force
                int force = 0;
                // If Equipment
                if (Equipment != null)
                {
                    force = Equipment.Knockback + (int)Data.Knockback;
                    // Calculate Damage
                    Battle.Attack(OwnerBattler, ev.Battler, Equipment, Data.IncreaseEffectParamater);
                }
                else if (Skill != null)
                {
                    force = Skill.Knockback + (int)Data.Knockback;
                    for (int index = 0; index < Skill.Effects.Count; index++)
                    {
                        if (Skill.SkillType == SkillType.Skill)
                        {
                            if (Skill.Effects[index].Scope == EffectScope.Target)
                                Battle.UseSkill(OwnerBattler, ev.Battler, Skill, index, Data.IncreaseEffectParamater);
                        }
                        else
                        {
                            if (Skill.Effects[index].Scope == EffectScope.Target)
                                Battle.UseMagic(OwnerBattler, ev.Battler, Skill, index, Data.IncreaseEffectParamater);
                        }
                    }
                }
                // Display Damage - Add to screen text effects
                Global.DisplayDamage(ev.Battler.Damage, ev.Battler.Damaged, ev, HitAnimation.GetDisplayTime());
                // if ev hit and damege > 0
                if (ev.Battler.Damaged)
                {
                    // Animate hit animation
                    if (ev.Battler.Damage > 0)
                    {
                        ev.Animate(EventAction.Hit);
                        // Knockback
                        ev.Knocback(force, Owner.Position);
                    }
                    // Reset
                    ev.Battler.Damaged = false;
                    ev.Battler.Damage = 0;
                    // Cheak if dead
                    ev.CheckDeath(Owner);
                }
                // Change Direction
                if (ev != Global.Instance.Player[0])
                {
                    ev.TurnTowardEvent(Owner, ev.Data.Pages[ev.pageIndex].BattleDirections);
                    if (ev.IsPlayer && !Owner.IsPlayer)
                        ev.Target = Owner;
                    else if (!ev.IsPlayer && Owner.IsPlayer)
                        ev.Target = Owner;
                }
            }
        }
        /// <summary>
        /// Checks if target is a friendly
        /// </summary>
        /// <returns></returns>
        private bool Friendly(IBattler target, EventProcessor ev)
        {
            if (Data.FriendlyFire) return false;
            if (OwnerBattler is HeroProcessor && !ev.Data.Pages[ev.pageIndex].Hostiles.Contains(-1))
                return true;
            else if (OwnerBattler is EnemyProcessor && target is HeroProcessor && !Hostiles.Contains(-1))
                return true;
            else if (OwnerBattler is EnemyProcessor && target is EnemyProcessor && !Hostiles.Contains(target.ID))
                return true;
            return (target is HeroProcessor && OwnerBattler is HeroProcessor);
        }
                /// <summary>
        /// Dispose the projectile
        /// </summary>
        public override void Dispose()
        {
            Global.Projectiles.Insert(this);
            if (Body != null)
            {
                Body.UserData = null;
                Body.Enabled = false;
                Global.World.RemoveBody(Body);
            }
            Body = null;
            BodyExists = false;
        }
    }
}