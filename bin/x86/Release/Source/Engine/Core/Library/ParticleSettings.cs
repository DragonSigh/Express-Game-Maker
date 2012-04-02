using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    
    public class ParticleSystemData : IGameData
    {
        #region IGameData
        /// <summary>
        /// Name
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
        #endregion

        public List<ParticleEmitterData> Emitters = new List<ParticleEmitterData>();

        public bool OneUse;
    }

    
    public class ParticleEmitterData : IGameData
    {
        #region IGameData
        /// <summary>
        /// Name
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
        #endregion

        // Settings
        public ParticleSettings Settings = new ParticleSettings();
        // Is Paused?
        public bool IsPaused;
    }
    /// <summary>
    /// Settings class describes all the tweakable options used
    /// to control the appearance of a particle system.
    /// </summary>
    
    public class ParticleSettings
    {
        // Particle Shape
        public ParticleEmitterShapes Shape = ParticleEmitterShapes.Point;
        public Point ShapeSize = new Point();
        public Vector2 BasePoint = new Vector2();
        // Emission Rate (Rate * Frame)
        public int EmissionRate = 1;
        // Texture
        public int TextureID = -1;

        // Maximum number of particles that can be displayed at one time.
        public int MaxParticles = 100;

        // Particles To Emit
        public int ParticlesToEmit = 4;

        // How long these particles will last.
        public TimeSpan Duration = TimeSpan.FromSeconds(1);


        // If greater than zero, some particles will last a shorter time than others.
        public float DurationRandomness = 0;

        // Range of values controlling how much X and Z axis velocity to give each
        // particle. Values for individual particles are randomly chosen from somewhere
        // between these limits.
        public float Velocity = 0;
        public float VelocityOffset = 0;
        // Direction of Velocity
        public float Angle = 0;
        // Angle offset
        public float AngleOffset = 0;


        // Strength of the gravity effect. Note that this can point in any
        // direction, not just down! The fire effect points it upward to make the flames
        // rise, and the smoke plume points it sideways to simulate wind.
        public float GravityMagnitude = 0;
        public float GravityAngle = 0;

        // Controls how the particle velocity will change over their lifetime. If set
        // to 1, particles will keep going at the same speed as when they were created.
        // If set to 0, particles will come to a complete stop right before they die.
        // Values greater than 1 make the particles speed up over time.
        public float EndVelocity = 1;


        // Range of values controlling the particle color and alpha. Values for
        // individual particles are randomly chosen from somewhere between these limits.
        public Color MinColor = Color.White;
        public Color MaxColor = Color.White;


        // Range of values controlling how fast the particles rotate. Values for
        // individual particles are randomly chosen from somewhere between these
        // limits. If both these values are set to 0, the particle system will
        // automatically switch to an alternative shader technique that does not
        // support rotation, and thus requires significantly less GPU power. This
        // means if you don't need the rotation effect, you may get a performance
        // boost from leaving these values at 0.
        public float MinRotateSpeed = 0;
        public float MaxRotateSpeed = 0;


        // Range of values controlling how big the particles are when first created.
        // Values for individual particles are randomly chosen from somewhere between
        // these limits.
        public float MinStartSize = 1f;
        public float MaxStartSize = 1f;


        // Range of values controlling how big particles become at the end of their
        // life. Values for individual particles are randomly chosen from somewhere
        // between these limits.
        public float MinEndSize = 1f;
        public float MaxEndSize = 1f;

        public float OscillationFrequency = 0;
        public float OscillationMagnitudeMin = 0;
        public float OscillationMagnitudeMax = 0;

        // Alpha blending settings.
        [ContentSerializerIgnore]
        public BlendState BlendState = BlendState.Additive;


        [ContentSerializer(ElementName = "BlendState")]
        private string BlendStateSerializationHelper
        {
            get { return BlendState.Name.Replace("BlendState.", string.Empty); }

            set
            {
                switch (value)
                {
                    case "AlphaBlend": BlendState = BlendState.AlphaBlend; break;
                    case "Additive": BlendState = BlendState.Additive; break;
                    case "NonPremultiplied": BlendState = BlendState.NonPremultiplied; break;
                    case "Opaque": BlendState = BlendState.Opaque; break;
                    default:
                        throw new ArgumentException("Unknown blend state " + value);
                }
            }
        }
    }


    public enum ParticleEmitterShapes
    {
        Point,
        Rectangle,
        Ellipse
    }
}
