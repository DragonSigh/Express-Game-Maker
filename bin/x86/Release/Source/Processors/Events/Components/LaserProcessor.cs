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

    public class LaserProcessor : Projectile
    {
        Texture2D StartTex, CenterTex, EndTex;
        public int StartDir, Width, Height, CenterWidth, CenterHeight;
        public Vector2 AnchorOffset;
        float AngleOffset;
        Dictionary<EventProcessor, int> Hitting = new Dictionary<EventProcessor, int>();
        /// <summary>
        ///  Start Position
        /// </summary>
        Vector2 StartPosition
        {
            get { return Owner.Position; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public LaserProcessor()
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
            StartDir = data.LaserDirection;
            // 
            StartTex = Content.Texture2D(data.StartImage);
            CenterTex = Content.Texture2D(data.CenterImage);
            EndTex = Content.Texture2D(data.EndImage);
            // Set Direction
            SetupAngle(owner, data.Direction, data);

            // Setup Collision
            SetupCollision(owner, data);

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
                if (DecayFrames <= 0)
                    Erase = true;
                DecayFrames--;
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
            else
            {
                CheckHits();
            }
        }
        /// <summary>
        /// Check Hits
        /// </summary>
        private void CheckHits()
        {
            for (int i = 0; i < Global.Instance.CurrentMap.Processors.Count; i++)
            {
                for (int j = 0; j < Global.Instance.CurrentMap.Processors[i].Count; j++)
                {
                    if (Global.Instance.CurrentMap.Processors[i][j] is EventProcessor)
                    {
                        EventProcessor e = Global.Instance.CurrentMap.Processors[i][j] as EventProcessor;

                        if (e.BattleBody != null && e.Battler != null)
                        {
                            int id = (e.IsPlayer ? id = -1 : e.Battler.ID);
                            if (OwnerBattler is EnemyProcessor && !Hostiles.Contains(id) && !Data.FriendlyFire) continue;
                            if (!Friendly(e.Battler, e))
                            {
                                // Check if Laser Hits
                                if (LaserHits(e))
                                {
                                    if (Hitting.ContainsKey(e) && Hitting[e] > 0)
                                    {
                                        Hitting[e]--; continue;
                                    }
                                    
                                    HitEvent(e);
                                }
                                else if (Hitting.ContainsKey(e))
                                    Hitting.Remove(e);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Ray Cast to check if laser hits
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool LaserHits(EventProcessor e)
        {

            Vector2 endLine = new Vector2();
            Vector2 startLine = ConvertUnits.ToSimUnits(StartPosition + AnchorOffset);
            endLine = Body.Position;
            Vector2 s, en;
            s = startLine;
            s.X -= ConvertUnits.ToSimUnits(CenterWidth / 2);
            en = endLine;
            en.X -= ConvertUnits.ToSimUnits(CenterWidth / 2);
            for (int i = 0; i < CenterWidth; i++)
            {
                if (e.Body.RayCast(s, en, 1f))
                    return true;
                en.X += ConvertUnits.ToSimUnits(1);
                s.X += ConvertUnits.ToSimUnits(1);
            }
            return false;
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
        /// Draw the projectile
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime)
        {
            // Draw Middle
            DrawMiddle();
            // Draw Start
            DrawStart();
            // Draw End
            DrawEnd();
        }
        /// <summary>
        /// Draw Middle
        /// </summary>
        private void DrawMiddle()
        {
            Texture2D tex = null;
            if (CenterTex != null) tex = CenterTex;
            if (tex == null && StartTex != null) tex = StartTex;
            if (tex == null && EndTex != null) tex = EndTex;

            if (tex != null)
            {
                Vector2 pointA = (StartPosition + AnchorOffset);
                Vector2 pointB = (Position);
                int distance = 0;
                double a = Math.Pow((double)(pointB.X - pointA.X), 2);
                double b = Math.Pow((double)(pointB.Y - pointA.Y), 2);
                double aPb = Math.Sqrt(a + b);
                distance = (int)aPb;
                distance /= CenterHeight;
                float angle = 0;

                // Bottom Right
                if (pointB.X >= pointA.X && pointB.Y > pointA.Y) angle = (2 * MathHelper.Pi) - (float)Math.Atan((double)Math.Abs(pointB.X - pointA.X) / (double)Math.Abs(pointB.Y - pointA.Y));
                // Bottom Left
                else if (pointB.Y > pointA.Y && pointB.X <= pointA.X) angle = (float)Math.Atan((double)Math.Abs(pointB.X - pointA.X) / (double)Math.Abs(pointB.Y - pointA.Y));
                // Top Left
                else if (pointB.Y <= pointA.Y && pointB.X < pointA.X) angle = (float)Math.Atan((double)Math.Abs(pointB.Y - pointA.Y) / (double)Math.Abs(pointB.X - pointA.X)) + MathHelper.PiOver2;
                // Top Right
                else if (pointB.Y < pointA.Y && pointB.X >= pointA.X) angle = MathHelper.Pi + (float)Math.Atan((double)Math.Abs(pointB.X - pointA.X) / (double)Math.Abs(pointB.Y - pointA.Y));

                float angle2 = MathHelper.ToDegrees(angle);


                if (distance > 0)
                {
                    Vector2 pos, n = Vector2.Zero;
                    for (int i = 0; i < distance + 1; i++)
                    {
                        pos = pointA + new Vector2(0, i * CenterHeight);

                        n.X = (float)(Math.Cos(angle) * (pos.X - pointA.X) - Math.Sin(angle) * (pos.Y - pointA.Y) + pointA.X);
                        n.Y = (float)(Math.Sin(angle) * (pos.X - pointA.X) + Math.Cos(angle) * (pos.Y - pointA.Y) + pointA.Y);


                        Global.SpriteBatch.Draw(tex, n, Color.White, Body.Rotation + AngleOffset, new Vector2(tex.Width * 0.5f, tex.Height * 0.5f));
                    }
                }
            }
        }
        /// <summary>
        /// Draw End Texture
        /// </summary>
        private void DrawEnd()
        {
            if (EndTex != null)
            {
                // Draw Start
                Global.SpriteBatch.Draw(EndTex, Position, Color.White, Body.Rotation + AngleOffset, new Vector2(EndTex.Width * 0.5f, EndTex.Height * 0.5f));
            }
            else if (CenterTex != null)
            {
                // Draw Start
                Global.SpriteBatch.Draw(CenterTex, Position, Color.White, Body.Rotation + AngleOffset, new Vector2(CenterTex.Width * 0.5f, CenterTex.Height * 0.5f));
            }
            else if (StartTex != null)
            {
                // Draw Start
                Global.SpriteBatch.Draw(StartTex, Position, Color.White, Body.Rotation + AngleOffset, new Vector2(StartTex.Width * 0.5f, StartTex.Height * 0.5f));
            }
        }
        /// <summary>
        /// Draw Start Texture
        /// </summary>
        private void DrawStart()
        {
            if (StartTex != null)
            {
                // Draw Start
                Global.SpriteBatch.Draw(StartTex, StartPosition + AnchorOffset, Color.White, Body.Rotation + AngleOffset, new Vector2(StartTex.Width * 0.5f, StartTex.Height * 0.5f));
            }
            else if (CenterTex != null)
            {
                // Draw Start
                Global.SpriteBatch.Draw(CenterTex, StartPosition + AnchorOffset, Color.White, Body.Rotation + AngleOffset, new Vector2(CenterTex.Width * 0.5f, CenterTex.Height * 0.5f));
            }
            else if (EndTex != null)
            {
                // Draw Start
                Global.SpriteBatch.Draw(EndTex, StartPosition + AnchorOffset, Color.White, Body.Rotation + AngleOffset, new Vector2(EndTex.Width * 0.5f, EndTex.Height * 0.5f));
            }
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
            // Angle Draw Offset
            AngleOffset = MathHelper.ToRadians((StartDir == 0 ? 0 : StartDir == 1 ? 180 : StartDir == 2 ? 270 : StartDir == 3 ? 90 : 0));
        }
        /// <summary>
        /// Setup Collision
        /// </summary>
        private void SetupCollision(EventProcessor owner, ProjectileData data)
        {
            Texture2D hitTexture = null;
            if (EndTex != null) hitTexture = EndTex;
            if (hitTexture == null && CenterTex != null) hitTexture = CenterTex;
            if (hitTexture == null && StartTex != null) hitTexture = StartTex;

            if (hitTexture != null)
            {
                Width = hitTexture.Width; Height = hitTexture.Height;

                Body = BodyFactory.CreateRectangle(Global.World, ConvertUnits.ToSimUnits(Width), ConvertUnits.ToSimUnits(Height), 1);
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

                // Get Position
                NativePosition = Owner.Animation.GetAnchorPosition(data.AnchorTo);

                AnchorOffset = NativePosition - Owner.Position;
                // Set Position
                Body.Position = ConvertUnits.ToSimUnits(NativePosition);


                if (Data.SyncAngleToRotation)
                    Body.Rotation = MathHelper.ToRadians(Angle + 90);

                Texture2D tex = null;
                if (CenterTex != null) tex = CenterTex;
                if (tex == null && StartTex != null) tex = StartTex;
                if (tex == null && EndTex != null) tex = EndTex;

                CenterHeight = (StartDir == 0 ? tex.Height : StartDir == 1 ? tex.Height : StartDir == 2 ? tex.Width : StartDir == 3 ? tex.Width : tex.Height);
                CenterWidth = (StartDir == 0 ? tex.Width : StartDir == 1 ? tex.Width : StartDir == 2 ? tex.Height : StartDir == 3 ? tex.Height : tex.Width);

                BodyExists = true;
            }
            else
                Erase = true;
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
                Hitting[ev] = Data.LaserDamageRate;
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
                Global.DisplayDamage(ev.Battler.Damage, ev.Battler.Damaged, ev, 30);
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