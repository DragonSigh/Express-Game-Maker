using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Library;
using Microsoft.Xna.Framework;
using EGMGame.Extensions;

namespace EGMGame.Processors
{
    public class WeatherProcessor : ParticleSystemProcessor
    {
        // Texture to use
        Texture2D Texture = CreateTexture();
        private static Texture2D CreateTexture()
        {
            int s = 1;
            Texture2D texture = new Texture2D(Global.Game.GraphicsDevice, s, 2, false, SurfaceFormat.Color);

            Color[] pixels = new Color[s * 2];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = Color.White;
            // Set the color data and make the sprite texture pure white 
            texture.SetData<Color>(pixels);

            return texture;
        }
        // Weather Type
        public int Type = 0;
        public int TextureID = -1;
        public int Power = 0;
        /// <summary>
        /// Setup Weather
        /// </summary>
        /// <param name="type"></param>
        public void Setup(int type, int power, int textureID)
        {
            // Return if same type
            if (type == Type && textureID == TextureID && Power == power) return;
            TextureID = textureID;
            // Clear Previous System
            Clear();
            // Create Particle System
            switch (type)
            {
                case 1: // Rain
                    CreateRain(power);
                    break;
                case 2: // Storm
                    CreateRain(power);
                    break;
                case 3: // Snow
                    CreateSnow(power);
                    break;
            }
            Type = type;
            Power = power;
        }
        /// <summary>
        /// Create Snow
        /// </summary>
        /// <param name="power"></param>
        private void CreateSnow(int power)
        {
            int s = 1;
            Texture2D texture = new Texture2D(Global.Game.GraphicsDevice, s, 1, false, SurfaceFormat.Color);

            Color[] pixels = new Color[s * 1];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = Color.White;
            // Set the color data and make the sprite texture pure white 
            texture.SetData<Color>(pixels);

            ParticleSettings settings = new ParticleSettings();
            settings.Angle = MathHelper.ToRadians(90);
            settings.GravityAngle = MathHelper.ToRadians(90);
            settings.Duration = TimeSpan.FromSeconds(10);
            settings.DurationRandomness = 3;
            settings.EmissionRate = 20;
            settings.Velocity = power;
            settings.EndVelocity = 20 + power;
            settings.MaxParticles = 10000;
            settings.ParticlesToEmit = power;
            settings.Shape = ParticleEmitterShapes.Rectangle;
            settings.TextureID = TextureID;

            settings.ShapeSize = new Point((int)Global.Project.ScreenRatio.X, 10);
            settings.BasePoint.Y = -10;

            EmitterProcessor e = new EmitterProcessor(Global.Game, settings, false);
            e.Texture = texture;
            Emitters.Add(e);
        }
        /// <summary>
        /// Create Rain
        /// </summary>
        /// <param name="type"></param>
        /// <param name="power"></param>
        private void CreateRain(int power)
        {
            ParticleSettings settings = new ParticleSettings();
            settings.Angle = MathHelper.ToRadians(90);
            settings.GravityAngle = MathHelper.ToRadians(90);
            settings.Duration = TimeSpan.FromSeconds(10);
            settings.DurationRandomness = 3;
            settings.EmissionRate = 20;
            settings.Velocity = power * 2;
            settings.EndVelocity = 20 + power * 2;
            settings.MaxParticles = 20000;
            settings.ParticlesToEmit = power;
            settings.Shape = ParticleEmitterShapes.Rectangle;
            settings.TextureID = TextureID;
            settings.ShapeSize = new Point((int)Global.Project.ScreenRatio.X, 10);
            settings.BasePoint.Y = -10;

            EmitterProcessor e = new EmitterProcessor(Global.Game, settings, false);
            Emitters.Add(e);

        }

        public override void Update(GameTime gameTime)
        {
            return;
            base.Update(gameTime);
            Position = Global.Instance.ActiveCamera.RealPosition;
            // if storm
            if (Type == 2)
            {

            }
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw Emitters
            foreach (EmitterProcessor emitter in Emitters)
            {
                emitter.Draw(gameTime);
            }
            // if storm
            if (Type == 2)
            {

            }
        }
        /// <summary>
        /// Load
        /// </summary>
        public override void Load()
        {

        }
    }
}
