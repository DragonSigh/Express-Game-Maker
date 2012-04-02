//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Interfaces;
using Microsoft.Xna.Framework;
using EGMGame.Components;
using Microsoft.Xna.Framework.Graphics;

namespace EGMGame.Processors
{
    
    public class StateProcessor
    {
        public int ID;
        public bool Erase;
        /// <summary>
        /// Data
        /// </summary>
        public StateData Data
        {
            get { return GameData.States.GetData(ID); }
        }
        /// <summary>
        /// Animations
        /// </summary>
        public List<AnimationProcessor> Animations = new List<AnimationProcessor>();
        /// <summary>
        /// Duration (frames)
        /// </summary>
        public int Duration;
        /// <summary>
        /// The frequency count (frames)
        /// </summary>
        public int Frequency;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        public StateProcessor() { }
        public StateProcessor(int id)
        {
            ID = id;

            for (int i = 0; i < Data.Effects.Count; i++)
            {
                Animations.Add(new AnimationProcessor());
                Animations[i].Setup(Data.Effects[i].Animation, Data.Effects[i].Action);
            }
        }
        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="owner"></param>
        /// <param name="battler"></param>
        public void Update(GameTime gameTime, EventProcessor owner, IBattler battler)
        {
            StateData data = Data;
            if (data != null && battler != null)
            {
                if (battler.IsDead() && data.Settings == StateSettings.Death)
                    Erase = true;
                // Timer
                switch (data.TimeType)
                {
                    case TimeType.SecondsOrTurns:
                        Duration++;
                        if ((Duration / Global.Game.TargetElapsedTime.Milliseconds) >= data.Duration)
                            Erase = true;
                        break;
                }
                Frequency++;
                if (data.Frequency > 0 && (Frequency / Global.Game.TargetElapsedTime.Milliseconds) >= data.Frequency)
                {
                    Frequency = 0;
                    // Update Effects
                    for (int i = 0; i < data.Effects.Count; i++)
                    {
                        Battle.StateEffect(battler, data.Effects[i], data);
                        // Update Animations
                        Animations[i].Offset = owner.Animation.Offset;
                        Animations[i].Origin = owner.Animation.Origin;
                        Animations[i].Rotation = owner.Animation.Rotation;
                        Animations[i].Position = owner.Position;
                        Animations[i].Update(gameTime);
                    }
                }
                else
                {
                    // Update Animations
                    for (int i = 0; i < Animations.Count; i++)
                    {
                        Animations[i].Offset = owner.Animation.Offset;
                        Animations[i].Origin = owner.Animation.Origin;
                        Animations[i].Rotation = owner.Animation.Rotation;
                        Animations[i].Position = owner.Position;
                        Animations[i].Update(gameTime);
                    }
                }
            }
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime)
        {
            // Update Animations
            for (int i = 0; i < Animations.Count; i++)
            {
                Animations[i].Draw(gameTime);
            }
        }
    }
}
