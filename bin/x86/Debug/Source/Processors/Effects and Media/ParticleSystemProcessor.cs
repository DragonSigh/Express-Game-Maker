//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace EGMGame.Processors
{
    
    public class ParticleSystemProcessor : Drawable
    {
        #region Variables
        ParticleSystemData System
        {
            get
            {
                return GameData.ParticleSystems.GetData(SystemID);
            }
        }
        public int SystemID = -1;
        public int Channel;
        public Vector2 Offset;
        public bool AngularSync;
        public bool OneUse;
        public bool Pause;
        protected List<EmitterProcessor> Emitters = new List<EmitterProcessor>();
        #endregion

        public ParticleSystemProcessor() { }

        #region Setup
        public void Setup(ParticleSystemData system, int channel, Vector2 position)
        {
            if (system != null)
            {
                SystemID = system.ID;
                OneUse = system.OneUse;
                Position = position;
                Channel = channel;

                EmitterProcessor emitter;
                for (int i = 0; i < system.Emitters.Count; i++)
                {
                    emitter = new EmitterProcessor(Global.Game, system.Emitters[i].Settings, system.OneUse);
                    Matrix matrix = Matrix.CreateOrthographicOffCenter(0, Global.Game.GraphicsDevice.Viewport.Width,     // left, right
                        Global.Game.GraphicsDevice.Viewport.Height, 0,    // bottom, top
                        0, 1);
                    emitter.SetCamera(Global.Instance.ActiveCamera.ViewTransformationMatrix(), matrix, Position);
                    Emitters.Add(emitter);

                    if (system.OneUse)
                        emitter.Burst();
                }
            }
        }
        public void Setup(int particleSystemID, int channel, Vector2 position)
        {
            ParticleSystemData system = GameData.ParticleSystems.GetData(particleSystemID);

            if (system != null)
            {
                SystemID = system.ID;
                OneUse = system.OneUse;
                Position = position;
                Channel = channel;
                EmitterProcessor emitter;
                for (int i = 0; i < system.Emitters.Count; i++)
                {
                    emitter = new EmitterProcessor(Global.Game, system.Emitters[i].Settings, system.OneUse);
                    Emitters.Add(emitter);
                    Matrix matrix = Matrix.CreateOrthographicOffCenter(0, Global.Game.GraphicsDevice.Viewport.Width,     // left, right
                        Global.Game.GraphicsDevice.Viewport.Height, 0,    // bottom, top
                        0, 1);
                    emitter.SetCamera(Global.Instance.ActiveCamera.ViewTransformationMatrix(), matrix, Position);

                    if (system.OneUse)
                        emitter.Burst();
                }
            }
        }
        public void Setup(int particleSystemID)
        {
            ParticleSystemData system = GameData.ParticleSystems.GetData(particleSystemID);

            if (system != null)
            {
                SystemID = system.ID;
                OneUse = system.OneUse;
                EmitterProcessor emitter;
                for (int i = 0; i < system.Emitters.Count; i++)
                {
                    emitter = new EmitterProcessor(Global.Game, system.Emitters[i].Settings, system.OneUse);
                    Matrix matrix = Matrix.CreateOrthographicOffCenter(0, Global.Game.GraphicsDevice.Viewport.Width,     // left, right
                        Global.Game.GraphicsDevice.Viewport.Height, 0,    // bottom, top
                        0, 1);
                    emitter.SetCamera(Global.Instance.ActiveCamera.ViewTransformationMatrix(), matrix, Position);
                    Emitters.Add(emitter);

                    if (system.OneUse)
                        emitter.Burst();
                }
            }
        }
        #endregion
        
        #region Update and Draw
        public override void Update(GameTime gameTime)
        {
            if (Erase) return;
            int eCount = 0;

            Matrix matrix = Matrix.CreateOrthographicOffCenter(0, Global.Game.GraphicsDevice.Viewport.Width,     // left, right
                Global.Game.GraphicsDevice.Viewport.Height, 0,    // bottom, top
                0, 1);

            foreach (EmitterProcessor emitter in Emitters)
            {
                emitter.SetCamera(Global.Instance.ActiveCamera.ViewTransformationMatrix(), matrix, Position);
                emitter.Offset = Offset;
                emitter.Update(gameTime);


                if (!emitter.IsActive)
                    eCount++;
            }

            if (eCount == Emitters.Count)
                Clear();
        }

        public override void Draw(GameTime gameTime)
        {
            if (Erase) return;
            base.Draw(gameTime);
            // Spritebatch needs to end here so we can draw on top of the particles.
            Global.SpriteBatch.End();

            foreach (EmitterProcessor emitter in Emitters)
            {
                emitter.Draw(gameTime);

                if (emitter.Position.X > 410 && emitter.Position.X < 420)
                {

                }
            }
            // Spritebatch restarts here so we can draw the rest of the map.
            Global.BeginMapSpriteBatch();
        }
        #endregion

        #region Methods
        public void Move(Vector2 position)
        {
            Position = position;
        }
        public void Move(float x, float y)
        {
            Position = new Vector2(x, y);
        }
        public void MoveChannels(int channel)
        {
            Channel = channel;
        }
        public void Burst()
        {
            foreach (EmitterProcessor emitter in Emitters)
            {
                emitter.Burst();
            }
        }
        #endregion

        /// <summary>
        /// Clear the particle system.
        /// </summary>
        public override void Clear()
        {
            foreach (EmitterProcessor emitter in Emitters)
            {
                emitter.Clear();
            }
            Position = Vector2.Zero;
            SystemID = -1;
            Channel = 0;
            Emitters.Clear();
            Offset = Position;
            AngularSync = false;
            OneUse = false;
            Erase = true;
        }
        /// <summary>
        /// Load
        /// </summary>
        public override void Load()
        {
            if (System != null)
            {
                OneUse = System.OneUse;
                EmitterProcessor emitter;
                for (int i = 0; i < System.Emitters.Count; i++)
                {
                    emitter = new EmitterProcessor(Global.Game, System.Emitters[i].Settings, System.OneUse);
                    Emitters.Add(emitter);

                    if (System.OneUse)
                        emitter.Burst();
                }
            }
        }
    }
}
