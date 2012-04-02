//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using FarseerPhysics.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using EGMGame.Extensions;
using FarseerPhysics.Common;
namespace EGMGame.Processors
{

    public class AnimationProcessor : Drawable
    {
        // Animation ID
        public int AnimationID;
        // Current Action
        public AnimationAction Action;
        // Action Index
        public EventAction ActionIndex;
        // End Action
        public AnimationAction EndAction;
        // Action Index
        public EventAction EndActionIndex;
        // Direction
        public int Direction;
        // Frequency
        public bool EnableFrequency = false;
        public int Frequency = 0;
        // Frame Index
        public int frameIndex = 0;
        // Animating state
        public bool IsAnimating = false;
        // Animation Frame Counter
        private int animationCounter = 0;
        // Animation Loop Count
        private int animationLoopCount = 0;
        // Event Animation
        public bool animationOn = true;
        // Position
        public Vector2 Position = Vector2.Zero;
        // Rotation
        public float Rotation = 0;
        // Collision Body
        public Vertices CollisionBody = new Vertices();
        public Vector2 CollisionCentroid;
        // Hit Body
        public Vertices HitBody = new Vertices();
        public Vector2 HitCentroid;
        // Offset
        public Vector2 Offset = Vector2.Zero;
        // Origin
        public Vector2 Origin = Vector2.Zero;
        // Still
        public bool Still = false;
        // Begin Erase
        public bool BeginErase = false;
        // Erase Frames
        public int EraseFrames = 0;
        // Use Anchor
        public int UseAnchor;
        // Anchor To
        public int AnchorTo;
        // Particles
        public List<List<ParticleSystemProcessor>> Particles = new List<List<ParticleSystemProcessor>>();
        // Flashes
        List<EffectProcessor> Flashes = new List<EffectProcessor>();
        // Shakes
        List<EffectProcessor> Shakes = new List<EffectProcessor>();
        public AnimationProcessor()
        {
        }
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionID"></param>
        public void Setup(int animationID, int actionID)
        {
            AnimationID = animationID;
            // Assign animation
            AnimationData animation = GameData.Animations.GetData(animationID);
            // Current Animation not null
            AnimationAction action = null;
            if (animation != null)
                action = animation.Actions.GetData(actionID);

            Setup(action);
            frameIndex = -1;
        }
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionID"></param>
        public bool Setup(int animationID, int actionID, EventAction index)
        {
            AnimationID = animationID;
            ActionIndex = index;
            // Assign animation
            AnimationData animation = GameData.Animations.GetData(animationID);
            // Current Animation not null
            AnimationAction action = null;
            if (animation != null)
                action = animation.Actions.GetData(actionID);

            frameIndex = -1;
            return Setup(action);
        }
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionID"></param>
        public void Setup(int animationID, int actionID, int anchorToAniID, EventAction index)
        {
            AnimationID = animationID;
            ActionIndex = index;
            // Assign animation
            AnimationData animation = GameData.Animations.GetData(animationID);
            AnimationData anchorTo = GameData.Animations.GetData(anchorToAniID);
            AnimationAction a = anchorTo.Actions.GetData(actionID);
            if (a != null)
            {
                int i = anchorTo.Actions.IndexOf(a);
                // Current Animation not null
                AnimationAction action = null;
                if (animation != null && i < animation.Actions.Count)
                    action = animation.Actions[i];
                frameIndex = -1;
                Setup(action);
            }
        }
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="action"></param>
        public void Setup(AnimationAction action, EventAction index)
        {
            ActionIndex = index;
            frameIndex = -1;
            Setup(action);
        }
        /// <summary>
        /// Setup animation
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionIndex"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        /// <param name="layerIndex"></param>
        public void Setup(int animationID, int actionIndex, int direction, Vector2 position, int layerIndex)
        {
            AnimationID = animationID;
            // Assign animation
            AnimationData animation = GameData.Animations.GetData(animationID);
            // Current Animation not null
            AnimationAction action = null;
            if (actionIndex > -1 && actionIndex < animation.Actions.Count)
                action = animation.Actions[actionIndex];
            // Settings
            Direction = direction;
            Position = position;

            frameIndex = -1;
            Setup(action);
        }
        /// <summary>
        /// Setup animation
        /// </summary>
        /// <param name="animationName"></param>
        /// <param name="actionIndex"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        /// <param name="layerIndex"></param>
        public void Setup(string animationName, int actionIndex, int direction, Vector2 position, int layerIndex)
        {
            // Assign animation
            AnimationData animation = GameData.Animations.GetData(animationName);
            // AnimationID
            AnimationID = animation.ID;
            // Current Animation not null
            AnimationAction action = null;
            if (actionIndex > -1 && actionIndex < animation.Actions.Count)
                action = animation.Actions[actionIndex];
            // Settings
            Direction = direction;
            Position = position;

            frameIndex = -1;
            Setup(action);
        }
        /// <summary>
        /// Setup Action Settings
        /// </summary>
        /// <param name="action"></param>
        private bool Setup(AnimationAction action)
        {
            bool same = (Action == action);
            SetupParticles(action);
            Action = action;

            if (Action != null)
            {
                if (Action.CollisionBody.Count > 0)
                {
                    CollisionBody = Action.CollisionBody;
                    CollisionCentroid = CollisionBody.GetCentroid();
                }
                if (Action.HitBody.Count > 0)
                {
                    HitBody = Action.HitBody;
                    HitCentroid = HitBody.GetCentroid();
                }
            }
            return same;
        }
        /// <summary>
        /// Setup Particles
        /// </summary>
        /// <param name="action"></param>
        private void SetupParticles(AnimationAction action)
        {
            if (Action != action && action != null)
            {
                // Dispose Previous Particles
                DisposeParticles();
                // Particles
                for (int i = 0; i < 8; i++)
                {
                    if (i >= Particles.Count)
                        Particles.Add(new List<ParticleSystemProcessor>());
                    Particles[i].Clear();
                    for (int j = 0; j < action.Particles[i].Count; j++)
                    {
                        Particles[i].Add(new ParticleSystemProcessor());
                        Particles[i][j].AngularSync = action.Particles[i][j].AngularSync;
                        Particles[i][j].Setup(action.Particles[i][j].Particle, 0, this.Position);
                        Particles[i][j].Offset = action.Particles[i][j].Position - (new Vector2(16, 16));
                    }
                }
            }
            else if (action == null)
                DisposeParticles();
        }
        /// <summary>
        /// Setup Particles
        /// </summary>
        /// <param name="action"></param>
        private void SetupParticles()
        {
            // Dispose Previous Particles
            DisposeParticles();
            // Particles
            for (int i = 0; i < 8; i++)
            {
                if (i >= Particles.Count)
                    Particles.Add(new List<ParticleSystemProcessor>());
                Particles[i].Clear();
                for (int j = 0; j < Action.Particles[i].Count; j++)
                {
                    Particles[i].Add(new ParticleSystemProcessor());
                    Particles[i][j].AngularSync = Action.Particles[i][j].AngularSync;
                    Particles[i][j].Setup(Action.Particles[i][j].Particle, 0, this.Position);
                    Particles[i][j].Offset = Action.Particles[i][j].Position - (new Vector2(16, 16));
                }
            }
        }
        /// <summary>
        /// Dispose Particles
        /// </summary>
        private void DisposeParticles()
        {
            // Particles
            for (int i = 0; i < Particles.Count; i++)
            {
                for (int j = 0; j < Particles[i].Count; j++)
                {
                    Particles[i][j].Clear();
                }
            }
        }
        /// <summary>
        /// Start the animation
        /// </summary>
        public void Start(EventAction index)
        {
            if (animationOn)
            {
                ActionIndex = index;
                IsAnimating = true;
                frameIndex = -1;
                animationCounter = 0;
                animationLoopCount = 0;
                EndAction = null;
                Still = false;
            }
        }
        /// <summary>
        /// Start the animation
        /// </summary>
        /// <param name="eventAction"></param>
        internal void Start()
        {
            if (animationOn)
            {
                IsAnimating = true;
                frameIndex = -1;
                animationCounter = 0;
                animationLoopCount = 0;
                Still = false;
            }
        }
        /// <summary>
        /// Start the animation but end with last frame, not first.
        /// </summary>
        /// <param name="eventAction"></param>
        internal void StartStill()
        {
            if (animationOn)
            {
                EndAnimation();
                IsAnimating = true;
                frameIndex = -1;
                animationCounter = 0;
                animationLoopCount = 0;
                Still = true;
            }
        }
        /// <summary>
        /// Start the animation (but also include an end action); 
        /// </summary>
        /// <param name="eventAction"></param>
        internal void Start(AnimationAction action, EventAction index)
        {
            if (animationOn)
            {
                ActionIndex = index;
                IsAnimating = true;
                frameIndex = -1;
                animationCounter = 0;
                animationLoopCount = 0;
                // End action
                EndAction = action;
                Still = false;
                if (action != null)
                {
                    while (action.Directions.Count < 8)
                        action.Directions.Add(new List<AnimationFrame>());
                }
            }
        }
        /// <summary>
        /// Start Instant Animation
        /// </summary>
        /// <param name="End Action">The action after this action ends</param>
        /// <param name="Index">The current index</param>
        /// <param name="End Index">The index to change to after action ends</param>
        public void InstantStart(AnimationAction endAction, EventAction index, EventAction endIndex)
        {
            if (animationOn)
            {
                Start(endAction, index);
                EndActionIndex = endIndex;
                frameIndex = -1;
                Still = false;
            }
        }
        /// <summary>
        /// Start Instant Animation
        /// </summary>
        public void InstantStart()
        {
            if (animationOn)
            {
                Start();
                frameIndex = -1;
            }
        }
        /// <summary>
        /// End Animation
        /// </summary>
        public void EndAnimation()
        {
            IsAnimating = false;
            if (!Still)
                frameIndex = 0;
            else
            {
                frameIndex--;
            }
            Still = false;
            animationCounter = 0;
            animationLoopCount = 0;
            if (EndAction != null && EndAction != Action)
            {
                ActionIndex = EndActionIndex;
                Action = EndAction;

                if (Action != null)
                {
                    CollisionBody = Action.CollisionBody;
                    HitBody = Action.HitBody;
                }

                // Particles
                SetupParticles();
                // Start
                Start();
            }
            else if (EndAction != null)
            {
                ActionIndex = EndActionIndex;
            }
            EndAction = null;

            // Dispose Particles (If you don't want them to dispose, loop animation or increase frames
            DisposeParticles();
        }
        /// <summary>
        /// Update
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            // Update Shakes
            int count = Shakes.Count;
            for (int i = 0; i < count; i++)
            {
                Shakes[i].Update(gameTime);
                if (Shakes[i].Erase)
                {
                    Shakes.RemoveAt(i);
                    i--; count--;
                }
            }
            // Update Flashes
            count = Flashes.Count;
            for (int i = 0; i < count; i++)
            {
                Flashes[i].Update(gameTime);
                Global.Instance.FlashQue.Add(Flashes[i]);
                if (Flashes[i].Erase)
                {
                    Flashes.RemoveAt(i);
                    i--; count--;
                }
            }
            // Update Animation
            if (Action != null)
            {
                if (IsAnimating)
                {
                    animationCounter++;
                    // Get Frame
                    if (frameIndex < Action.Directions[Direction].Count)
                    {
                        int maxCount;
                        if (EnableFrequency)
                            maxCount = Frequency;
                        else if (frameIndex > -1)
                            maxCount = Action.Directions[Direction][frameIndex].TimeElapse;
                        else
                            maxCount = 0;
                        if (animationCounter >= maxCount)
                        {
                            animationCounter = 0;

                            // Check if there enough frames for another increase
                            if (frameIndex + 1 < Action.Directions[Direction].Count)
                            {
                                frameIndex++;
                                // Play Sound
                                if (Action.Directions[Direction][frameIndex].PlaySE)
                                {
                                    AudioData audioData = GameData.Audios.GetData(Action.Directions[Direction][frameIndex].SoundEffectID);
                                    if (audioData != null)
                                        Global.Instance.AudioManager.Effects.Add(new AudioProcessor(audioData, true));
                                }
                                // Flash Screen
                                if (Action.Directions[Direction][frameIndex].FlashScreen)
                                {
                                    Flashes.Add(new EffectProcessor(EffectType.Flash, ScreenType.Global, Action.Directions[Direction][frameIndex].FlashColor, Action.Directions[Direction][frameIndex].FlashFrames, Action.Directions[Direction][frameIndex].FlashFreq));
                                }
                                // Shake Screen
                                if (Action.Directions[Direction][frameIndex].ShakeScreen)
                                {
                                    Shakes.Add(new EffectProcessor(EffectType.Shake, ScreenType.Global, Action.Directions[Direction][frameIndex].ShakePower, Action.Directions[Direction][frameIndex].ShakeFrames, Action.Directions[Direction][frameIndex].ShakeSpeed, true));
                                }
                            }
                            else // The previous frame was the last frame
                            {
                                if (!animationOn)
                                {
                                    EndAnimation();
                                }
                                // Check if we loop
                                else if (animationLoopCount < Action.LoopCount)
                                {
                                    frameIndex = 0;
                                    animationCounter = 0;
                                    animationLoopCount++;
                                }
                                else if (Action.InfiniteLoop)
                                {
                                    frameIndex = 0;
                                    animationCounter = 0;
                                }
                                else
                                {
                                    EndAnimation();
                                }
                            }
                        }
                    }
                    else
                    {
                        EndAnimation();
                    }
                }
                // Particles
                if (Direction > -1 && Direction < Particles.Count)
                {
                    for (int j = 0; j < Particles[Direction].Count; j++)
                    {
                        if (!Particles[Direction][j].Erase)
                        {
                            if (Particles[Direction][j].AngularSync)
                            {
                                Vector2 point = Particles[Direction][j].Offset;
                                point = Vector2.Transform(point, Matrix.CreateRotationZ(Rotation));
                                Particles[Direction][j].Move(Position + point);
                            }
                            else
                                Particles[Direction][j].Move(Position);

                            Particles[Direction][j].Update(gameTime);
                        }
                    }
                }
            }
            else
            {
                if (IsAnimating)
                    EndAnimation();
            }
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime)
        {
            // Get animation, action, and direction.
            if (Action != null)
            {
                // Loop all the frames in the direction.
                if (Direction > -1 && frameIndex < Action.Directions[Direction].Count)
                {
                    AnimationFrame frame = null;
                    Texture2D tex;
                    if (frameIndex == -1 && 0 < Action.Directions[Direction].Count)
                        frame = Action.Directions[Direction][0];
                    else if (frameIndex > -1)
                        frame = Action.Directions[Direction][frameIndex];
                    if (frame != null)
                    {
                        Color color = new Color();
                        // Loop and draw sprites
                        for (int spriteIndex = 0; spriteIndex < frame.Sprites.Count; spriteIndex++)
                        {
                            tex = Content.Texture2D(frame.Sprites[spriteIndex].MaterialId);
                            if (tex != null)
                            {
                                color = frame.Sprites[spriteIndex].Tint;

                                if (BeginErase)
                                {
                                    int gdt = GetDisplayTime();
                                    color.A = (byte)(255 - (gdt - EraseFrames));
                                    color.B = (byte)(255 - (gdt - EraseFrames));
                                    color.G = (byte)(255 - (gdt - EraseFrames));
                                    if (EraseFrames <= 0)
                                    {
                                        BeginErase = false; EraseFrames = 0;
                                    }
                                    else
                                        EraseFrames--;
                                }
                                Vector2 pos = new Vector2();
                                pos.X = (float)Math.Round(Position.X + Offset.X + (frame.Sprites[spriteIndex].Position.X - Origin.X));
                                pos.Y = (float)Math.Round(Position.Y + Offset.Y + (frame.Sprites[spriteIndex].Position.Y - Origin.Y));

                                Global.SpriteBatch.Draw(
                                    tex,
                                    pos,
                                    frame.Sprites[spriteIndex].DisplayRect,
                                    color,
                                    MathHelper.ToRadians(frame.Sprites[spriteIndex].Rotation) + (frame.Sprites[spriteIndex].TorqueSync ? Rotation : 0),
                                    new Vector2(frame.Sprites[spriteIndex].DisplayRect.Width / 2, frame.Sprites[spriteIndex].DisplayRect.Height / 2) + frame.Sprites[spriteIndex].OriginOffset,
                                    frame.Sprites[spriteIndex].Scale,
                                    (frame.Sprites[spriteIndex].HorizontalFlip ? SpriteEffects.FlipHorizontally : frame.Sprites[spriteIndex].VerticalFlip ? SpriteEffects.FlipVertically : SpriteEffects.None),
                                    0
                                    );
                            }
                        }
                    }
                }
                // Particles
                if (Direction > -1 && Direction < Particles.Count)
                {
                    for (int j = 0; j < Particles[Direction].Count; j++)
                    {
                        Particles[Direction][j].Draw(gameTime);
                    }
                }
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
        /// <summary>
        /// Returns the total display time of the animation
        /// </summary>
        /// <returns></returns>
        public int GetDisplayTime()
        {
            if (Action != null && frameIndex > -1)
            {
                int frameCount = 0;
                for (int i = frameIndex; i < Action.Directions[Direction].Count; i++)
                {
                    frameCount += Action.Directions[Direction][i].TimeElapse;
                }
                return frameCount;
            }
            return 0;
        }
        /// <summary>
        /// Returns the total display time of the animation
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionID"></param>
        /// <param name="directionIndex"></param>
        /// <returns></returns>
        public static int GetDisplayTime(int animationID, int actionID, int directionIndex)
        {
            AnimationData animation = GameData.Animations.GetData(animationID);

            if (animation != null)
            {
                AnimationAction action = animation.Actions.GetData(actionID);
                if (action != null)
                {
                    int frameCount = 0;
                    for (int i = 0; i < action.Directions[directionIndex].Count; i++)
                    {
                        frameCount += action.Directions[directionIndex][i].TimeElapse;
                    }
                    return frameCount;
                }
            }
            return 0;
        }
        /// <summary>
        /// Appl Angle to direction
        /// </summary>
        /// <param name="Angle"></param>
        public void ApplyAngleToDirection(int angle)
        {
            if (Action != null)
            {
                if (Action.Directions.Count < 8)
                    Action.Directions.Add(new List<AnimationFrame>());
                if (angle <= 240 && angle >= 200 && Action.Directions[4].Count > 0) // Up - Left
                {
                    Direction = 4;
                }
                else if (angle >= 300 && angle <= 340 && Action.Directions[5].Count > 0) // Up - Right
                {
                    Direction = 5;
                }
                else if (angle >= 120 && angle <= 160 && Action.Directions[6].Count > 0) // Down - Left
                {
                    Direction = 6;
                }
                else if (angle >= 30 && angle <= 70 && Action.Directions[7].Count > 0) // Down - Right
                {
                    Direction = 7;
                }
                else if (angle > 220 && angle < 320 && Action.Directions[0].Count > 0) // Up
                {
                    Direction = 0;
                }
                else if (angle > 45 && angle < 140 && Action.Directions[1].Count > 0) // Down
                {
                    Direction = 1;
                }
                else if (angle >= 140 && angle <= 220 && Action.Directions[2].Count > 0) // Left
                {
                    Direction = 2;
                }
                else if (((angle >= 320 && angle <= 360) || (angle >= 0 && angle <= 40)) && Action.Directions[3].Count > 0) // Right
                {
                    Direction = 3;
                }
            }
        }
        /// <summary>
        /// Clear
        /// </summary>
        public override void Clear()
        {
            Action = null;
            // Update Shakes
            Shakes.Clear();
            // Update Flashes
            Flashes.Clear();
            // Dispose Particles
            DisposeParticles();
        }
        /// <summary>
        /// Anchor to the animation
        /// </summary>
        /// <param name="Animation"></param>
        public void Anchor(AnimationProcessor anchorTo)
        {

            Direction = anchorTo.Direction;
            Position.X = 0; Position.Y = 0;
            Vector2 x = anchorTo.GetAnchorPosition(AnchorTo);
            Vector2 y = GetAnchorPosition(UseAnchor);
            Position = x - y;
        }
        /// <summary>
        /// Get Anchor Position
        /// </summary>
        /// <param name="AnchorTo"></param>
        /// <returns></returns>
        internal Vector2 GetAnchorPosition(int index)
        {
            // Get animation, action, and direction.
            if (Action != null)
            {
                if (Direction > -1 && frameIndex < Action.Directions[Direction].Count)
                {
                    AnimationFrame frame = null;
                    if (frameIndex > -1 && frameIndex < Action.Directions[Direction].Count)
                    {
                        frame = Action.Directions[Direction][frameIndex];

                        return Position + Offset + (frame.Anchors[index - 1].Position - Origin);
                    }
                    else if (0 < Action.Directions[Direction].Count)
                    {
                        frame = Action.Directions[Direction][0];

                        return Position + Offset + (frame.Anchors[index - 1].Position - Origin);
                    }
                }
            }

            return Vector2.Zero;
        }
        /// <summary>
        /// Get Anchor Position
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="animationProcessor"></param>
        /// <returns></returns>
        internal Vector2 GetAnchorPosition(int useAnchor, int anchorTo, AnimationProcessor animationProcessor)
        {
            return animationProcessor.GetAnchorPosition(anchorTo) - GetAnchorPosition(useAnchor);
        }
        /// <summary>
        /// Go To Next Frame
        /// </summary>
        /// <returns></returns>
        internal int NextFrame()
        {
            // Get animation, action, and direction.
            if (Action != null)
            {
                frameIndex++;
                // Loop all the frames in the direction.
                if (Direction > -1 && frameIndex < Action.Directions[Direction].Count)
                {
                    AnimationFrame frame = null;
                    if (frameIndex < Action.Directions[Direction].Count)
                    {
                        if (frameIndex == -1 && 0 < Action.Directions[Direction].Count)
                            frame = Action.Directions[Direction][0];
                        else if (frameIndex > -1)
                            frame = Action.Directions[Direction][frameIndex];

                        if (frame != null)
                        {
                            // Play Sound
                            if (Action.Directions[Direction][frameIndex].PlaySE)
                            {
                                AudioData audioData = GameData.Audios.GetData(Action.Directions[Direction][frameIndex].SoundEffectID);
                                if (audioData != null)
                                    Global.Instance.AudioManager.Effects.Add(new AudioProcessor(audioData, true));
                            }
                            return frame.TimeElapse;
                        }
                    }
                }
                else
                    frameIndex = 0;
            }
            return 0;
        }
    }
}