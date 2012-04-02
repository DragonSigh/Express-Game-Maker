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
        /// <summary>
        /// Update Player
        /// </summary>
        private void UpdatePlayer()
        {
            if (Enabled)
            {
                // Return if there is an action taking place and must be completed
                if (actionTakingPlace != ActionType.None && waitActionCompelition)
                    return;
                // Return if Player Locked
                if (Global.Instance.LockPlayer[1] > -1)
                    return;
                // Check if any messages are active
                for (int i = 0; i < Global.Messages.Count; i++)
                    if (Global.Messages[i].WaitOnClose)
                        return;
                // Check if any menus are active
                for (int i = 0; i < Global.Menus.Count; i++)
                    if (Global.Menus[i].WaitOnClose)
                        return;

                UpdateMovementControl();
                // Update Battle Controls
                if (Battler != null)
                    UpdateBattleControls();
            }
        }
        /// <summary>
        /// Update 4 directional control
        /// </summary>
        private void UpdateMovementControl()
        {
            if (AllowMovement && !Path.IsUsingPath && waitFrames <= 0)// && (ActionIndex == EventAction.Walk || ActionIndex == EventAction.Idle || ActionIndex == EventAction.Jump || ActionIndex == EventAction.Attack || ActionIndex == EventAction.Hit))
            {
                if (!Battler.CanMove()) return;

                bool leftk, rightk, downk, upk,
                 leftb, rightb, downb, upb;

                #region Get Keys
                if (GameData.Player.Keys["Movement"] == 0)
                {
                    // Arrow Keys
                    leftk = InputState.IsKeyPress(Keys.Left, 0);
                    rightk = InputState.IsKeyPress(Keys.Right, 0);
                    downk = InputState.IsKeyPress(Keys.Down, 0);
                    upk = InputState.IsKeyPress(Keys.Up, 0);
                }
                else
                {
                    // ASWD
                    leftk = InputState.IsKeyPress(Keys.A, 0);
                    rightk = InputState.IsKeyPress(Keys.S, 0);
                    downk = InputState.IsKeyPress(Keys.W, 0);
                    upk = InputState.IsKeyPress(Keys.D, 0);
                }
                if (GameData.Player.Buttons["Movement"] == 0)
                {
                    // Left Stick
                    leftb = (InputState.GetLeftStick(0).X <= -0.5f && InputState.GetLeftStick(0).X != 0);
                    rightb = (InputState.GetLeftStick(0).X >= 0.5f && InputState.GetLeftStick(0).X != 0);
                    upb = (InputState.GetLeftStick(0).Y >= 0.5f && InputState.GetLeftStick(0).Y != 0);
                    downb = (InputState.GetLeftStick(0).Y <= -0.5f && InputState.GetLeftStick(0).Y != 0);
                }
                else
                {
                    // DPAD
                    leftb = InputState.IsButtonPress(Buttons.DPadLeft, 0);
                    rightb = InputState.IsButtonPress(Buttons.DPadRight, 0);
                    downb = InputState.IsButtonPress(Buttons.DPadDown, 0);
                    upb = InputState.IsButtonPress(Buttons.DPadUp, 0);
                }
                #endregion

                if (GameData.Player.MovementType.Contains(4) && ((upk && leftk) || (upb && leftb)))
                {
                    ApplyForceToPlayer(0, Force, true);
                    ApplyForceToPlayer(2, Force, true);
                }
                else if (GameData.Player.MovementType.Contains(5) && ((upk && rightk) || (upb && rightb)))
                {
                    ApplyForceToPlayer(0, Force, true);
                    ApplyForceToPlayer(3, Force, true);
                }
                else if (GameData.Player.MovementType.Contains(6) && ((downk && leftk) || (downb && leftb)))
                {
                    ApplyForceToPlayer(1, Force, true);
                    ApplyForceToPlayer(2, Force, true);
                }
                else if (GameData.Player.MovementType.Contains(7) && ((downk && rightk) || (downb && rightb)))
                {
                    ApplyForceToPlayer(1, Force, true);
                    ApplyForceToPlayer(3, Force, true);
                }
                else if (GameData.Player.MovementType.Contains(0) && (upk || upb))
                {
                    ApplyForceToPlayer(0, Force, true);
                }
                else if (GameData.Player.MovementType.Contains(1) && (downk || downb))
                {
                    ApplyForceToPlayer(1, Force, true);
                }
                else if (GameData.Player.MovementType.Contains(2) && (leftk || leftb))
                {
                    ApplyForceToPlayer(2, Force, true);
                }
                else if (GameData.Player.MovementType.Contains(3) && (rightk || rightb))
                {
                    ApplyForceToPlayer(3, Force, true);
                }
            }
        }
        /// <summary>
        /// Move the event by applying given force in a given direction.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="p"></param>
        /// <param name="p_3"></param>
        private void ApplyForceToPlayer(int direction, float force, bool turn)
        {
            if (turn && !DirectionFix)
            {
                SetAngle(Global.DirectionToAngle(direction), true);
                Animation.Direction = direction;
            }
            if ((ActionIndex != EventAction.Jump || !IsJumping) && ActionIndex != EventAction.Attack && ActionIndex != EventAction.Hit)
            {
                if (ActionIndex != EventAction.Walk)
                {
                    ActionIndex = EventAction.Walk;
                    if (Animation.animationOn)
                        StartAnimation();
                }
                else if (Animation.animationOn && !Animation.IsAnimating)
                    StartAnimation();

            }

            if (Body != null)
            {
                int _ang = Global.DirectionToAngle(direction);
                if (!Static)
                {
                    Vector2 amount = new Vector2(0, 0);
                    amount.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(_ang)), 2) * Force;
                    amount.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(_ang)), 2) * Force;

                    Body.ApplyForce(ref amount);
                }
                else
                {
                    newPosition.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(_ang)), 2) * MoveSpeed;
                    newPosition.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(_ang)), 2) * MoveSpeed;
                    newPosition.X += Position.X;
                    newPosition.Y += Position.Y;
                    isMoving = true;
                }
            }
        }
    }
}