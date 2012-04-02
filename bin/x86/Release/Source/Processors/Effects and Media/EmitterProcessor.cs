//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace EGMGame.Library
{
    
    public class EmitterProcessor
    {
        #region Variables
        GraphicsDevice GraphicsDevice;

        QuickAlgorythm random = new QuickAlgorythm();

        public Texture2D Texture;

        public ParticleSettings settings { get; set; }

        public Vector2 Offset;

        public Vector2 Position;

        Effect particleEffect;
        EffectParameter effectViewParameter;
        EffectParameter effectProjectionParameter;
        EffectParameter effectViewportScaleParameter;
        EffectParameter effectTimeParameter;

        ParticleVertex[] particles;
        DynamicVertexBuffer vertexBuffer;
        // Index buffer turns sets of four vertices into particle quads (pairs of triangles).
        IndexBuffer indexBuffer;

        int firstActiveParticle;
        int firstNewParticle;
        int firstFreeParticle;
        int firstRetiredParticle;

        float currentTime;
        int drawCounter;

        bool OneUse;

        int emissionRate = 0;

        public bool Pause;

        public bool IsActive { get { return !(firstActiveParticle >= settings.MaxParticles - 1 && OneUse); } }

        #endregion

        #region Constructor
        public EmitterProcessor(Game game, ParticleSettings prop, bool oneUse)
        {
            this.GraphicsDevice = game.GraphicsDevice;
            settings = prop;
            this.OneUse = oneUse;

            Initialize();
            LoadContent();
        }
        /// <summary>
        /// Initialize Emitter
        /// </summary>
        private void Initialize()
        {
            // Allocate the particle array, and fill in the corner fields (which never change).
            particles = new ParticleVertex[settings.MaxParticles * 4];

            for (int i = 0; i < settings.MaxParticles; i++)
            {
                particles[i * 4 + 0].Corner = new Short2(-1, -1);
                particles[i * 4 + 1].Corner = new Short2(1, -1);
                particles[i * 4 + 2].Corner = new Short2(1, 1);
                particles[i * 4 + 3].Corner = new Short2(-1, 1);
            }

        }

        public void Burst()
        {
            AddParticles();
        }

        public int AmountOfParticles()
        {
            return particles.Length - (firstFreeParticle - firstNewParticle);
        }
        #endregion

        #region Load Content
        private void LoadContent()
        {

            Effect effect = Global.ParticlesEffect;

            // If we have several particle systems, the content manager will return
            // a single shared effect instance to them all. But we want to preconfigure
            // the effect with parameters that are specific to this particular
            // particle system. By cloning the effect, we prevent one particle system
            // from stomping over the parameter settings of another.
            particleEffect = Global.ParticlesEffectPool.Fetch();

            EffectParameterCollection p = particleEffect.Parameters;

            effectViewParameter = p["View"];
            effectProjectionParameter = p["Projection"];
            effectViewportScaleParameter = p["ViewportScale"];
            effectTimeParameter = p["CurrentTime"];

            UpdateSettings();


            // Create a dynamic vertex buffer.
            vertexBuffer = new DynamicVertexBuffer(this.GraphicsDevice, ParticleVertex.VertexDeclaration,
                                                   settings.MaxParticles * 4, BufferUsage.WriteOnly);

            // Create and populate the index buffer.
            ushort[] indices = new ushort[settings.MaxParticles * 6];

            for (int i = 0; i < settings.MaxParticles; i++)
            {
                indices[i * 6 + 0] = (ushort)(i * 4 + 0);
                indices[i * 6 + 1] = (ushort)(i * 4 + 1);
                indices[i * 6 + 2] = (ushort)(i * 4 + 2);

                indices[i * 6 + 3] = (ushort)(i * 4 + 0);
                indices[i * 6 + 4] = (ushort)(i * 4 + 2);
                indices[i * 6 + 5] = (ushort)(i * 4 + 3);
            }

            indexBuffer = new IndexBuffer(this.GraphicsDevice, typeof(ushort), indices.Length, BufferUsage.WriteOnly);

            indexBuffer.SetData(indices);


        }
        #endregion

        #region Settings
        public void UpdateSettings()
        {
            if (particleEffect != null)
            {
                EffectParameterCollection p = particleEffect.Parameters;

                // Set the values of p that do not change.
                p["Duration"].SetValue((float)settings.Duration.TotalSeconds);
                p["DurationRandomness"].SetValue(settings.DurationRandomness);
                p["EndVelocity"].SetValue(settings.EndVelocity);
                Vector2 g = new Vector2(settings.GravityMagnitude * (float)Math.Cos(settings.GravityAngle), settings.GravityMagnitude * (float)Math.Sin(settings.GravityAngle));
                p["Gravity"].SetValue(new Vector3(g, 0));
                p["MinColor"].SetValue(settings.MinColor.ToVector4());
                p["MaxColor"].SetValue(settings.MaxColor.ToVector4());
                p["RotateSpeed"].SetValue(
                    new Vector2(settings.MinRotateSpeed, settings.MaxRotateSpeed));
                p["StartSize"].SetValue(
                    new Vector2(settings.MinStartSize, settings.MaxStartSize));
                p["EndSize"].SetValue(
                    new Vector2(settings.MinEndSize, settings.MaxEndSize));

                if (settings.TextureID > -1)
                    Texture = Content.Texture2D(settings.TextureID);
                p["Texture"].SetValue(Texture);
            }
        }
        #endregion

        #region Update and Draw
        public void Update(GameTime gameTime)
        {
            if (gameTime == null)
                throw new ArgumentNullException("gameTime");

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            RetireActiveParticles();
            FreeRetiredParticles();

            // If we let our timer go on increasing for ever, it would eventually
            // run out of floating point precision, at which point the particles
            // would render incorrectly. An easy way to prevent this is to notice
            // that the time value doesn't matter when no particles are being drawn,
            // so we can reset it back to zero any time the active queue is empty.

            if (firstActiveParticle == firstFreeParticle)
                currentTime = 0;

            if (firstRetiredParticle == firstActiveParticle)
                drawCounter = 0;

            emissionRate--;
            // Emission Rate
            if (emissionRate <= 0)
            {
                emissionRate = settings.EmissionRate;
                if (Texture != null && !OneUse)
                    AddParticles();
            }
        }

        internal void SetCamera(Matrix viewTransformMatrix, Matrix projection, Vector2 position)
        {
            Position = position;
            effectViewParameter.SetValue(viewTransformMatrix);
            effectProjectionParameter.SetValue(projection);
        }

        /// <summary>
        /// Helper for checking when active particles have reached the end of
        /// their life. It moves old particles from the active area of the queue
        /// to the retired section.
        /// </summary>
        void RetireActiveParticles()
        {
            float particleDuration = (float)settings.Duration.TotalSeconds;

            while (firstActiveParticle != firstNewParticle)
            {
                // Is this particle old enough to retire?
                // We multiply the active particle index by four, because each
                // particle consists of a quad that is made up of four vertices.
                float particleAge = currentTime - particles[firstActiveParticle * 4].Time;

                if (particleAge < particleDuration)
                    break;

                // Remember the time at which we retired this particle.
                particles[firstActiveParticle * 4].Time = drawCounter;

                // Move the particle from the active to the retired queue.
                firstActiveParticle++;

                if (firstActiveParticle >= settings.MaxParticles)
                {
                    firstActiveParticle = 0;
                }
            }
        }

        /// <summary>
        /// Helper for checking when retired particles have been kept around long
        /// enough that we can be sure the GPU is no longer using them. It moves
        /// old particles from the retired area of the queue to the free section.
        /// </summary>
        void FreeRetiredParticles()
        {
            while (firstRetiredParticle != firstActiveParticle)
            {
                // Has this particle been unused long enough that
                // the GPU is sure to be finished with it?
                // We multiply the retired particle index by four, because each
                // particle consists of a quad that is made up of four vertices.
                int age = drawCounter - (int)particles[firstRetiredParticle * 4].Time;

                // The GPU is never supposed to get more than 2 frames behind the CPU.
                // We add 1 to that, just to be safe in case of buggy drivers that
                // might bend the rules and let the GPU get further behind.
                if (age < 3)
                    break;

                // Move the particle from the retired to the free queue.
                firstRetiredParticle++;

                if (firstRetiredParticle >= settings.MaxParticles)
                    firstRetiredParticle = 0;
            }
        }

        public void Draw(GameTime gametime)
        {
            if (Texture != null || Pause)
            {
                GraphicsDevice device = this.GraphicsDevice;

                // Restore the vertex buffer contents if the graphics device was lost.
                if (vertexBuffer.IsContentLost)
                {
                    vertexBuffer.SetData(particles);
                }

                // If there are any particles waiting in the newly added queue,
                // we'd better upload them to the GPU ready for drawing.
                if (firstNewParticle != firstFreeParticle)
                {
                    AddNewParticlesToVertexBuffer();
                }

                // If there are any active particles, draw them now!
                if (firstActiveParticle != firstFreeParticle)
                {
                    device.BlendState = settings.BlendState;
                    device.DepthStencilState = DepthStencilState.DepthRead;

                    // Set an effect parameter describing the viewport size. This is
                    // needed to convert particle sizes into screen space point sizes.
                    //effectViewportScaleParameter.SetValue(new Vector2(0.5f / device.Viewport.AspectRatio, -0.5f));
                    effectViewportScaleParameter.SetValue(new Vector2(Texture.Width, -Texture.Height));

                    // Set an effect parameter describing the current time. All the vertex
                    // shader particle animation is keyed off this value.
                    effectTimeParameter.SetValue(currentTime);

                    // Set the particle vertex and index buffer.
                    device.SetVertexBuffer(vertexBuffer);
                    device.Indices = indexBuffer;

                    // Activate the particle effect.
                    foreach (EffectPass pass in particleEffect.CurrentTechnique.Passes)
                    {
                        pass.Apply();

                        if (firstActiveParticle < firstFreeParticle)
                        {
                            // If the active particles are all in one consecutive range,
                            // we can draw them all in a single call.
                            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0,
                                                         firstActiveParticle * 4, (firstFreeParticle - firstActiveParticle) * 4,
                                                         firstActiveParticle * 6, (firstFreeParticle - firstActiveParticle) * 2);
                        }
                        else
                        {
                            // If the active particle range wraps past the end of the queue
                            // back to the start, we must split them over two draw calls.
                            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0,
                                                         firstActiveParticle * 4, (settings.MaxParticles - firstActiveParticle) * 4,
                                                         firstActiveParticle * 6, (settings.MaxParticles - firstActiveParticle) * 2);

                            if (firstFreeParticle > 0)
                            {
                                device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0,
                                                             0, firstFreeParticle * 4,
                                                             0, firstFreeParticle * 2);
                            }
                        }
                    }

                    // Reset some of the renderstates that we changed,
                    // so as not to mess up any other subsequent drawing.
                    device.DepthStencilState = DepthStencilState.Default;
                }

                drawCounter++;
            }
        }

        private void AddNewParticlesToVertexBuffer()
        {
            int stride = ParticleVertex.SizeInBytes;

            if (firstNewParticle < firstFreeParticle)
            {
                // If the new particles are all in one consecutive range,
                // we can upload them all in a single call.
                vertexBuffer.SetData(firstNewParticle * stride * 4, particles,
                                     firstNewParticle * 4,
                                     (firstFreeParticle - firstNewParticle) * 4,
                                     stride, SetDataOptions.NoOverwrite);
            }
            else
            {
                // If the new particle range wraps past the end of the queue
                // back to the start, we must split them over two upload calls.
                vertexBuffer.SetData(firstNewParticle * stride * 4, particles,
                                     firstNewParticle * 4,
                                     (settings.MaxParticles - firstNewParticle) * 4,
                                     stride, SetDataOptions.NoOverwrite);

                if (firstFreeParticle > 0)
                {
                    vertexBuffer.SetData(0, particles,
                                         0, firstFreeParticle * 4,
                                         stride, SetDataOptions.NoOverwrite);
                }
            }

            // Move the particles we just uploaded from the new to the active queue.
            firstNewParticle = firstFreeParticle;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a new particle to the system.
        /// </summary>
        public void AddParticles()
        {
            if (Pause) return;
            Vector3 velocity;
            Vector3 position;
            for (int j = 0; j < settings.ParticlesToEmit; j++)
            {

                // Figure out where in the circular queue to allocate the new particle.
                int nextFreeParticle = firstFreeParticle + 1;

                if (nextFreeParticle >= settings.MaxParticles)
                    nextFreeParticle = 0;

                // If there are no free particles, we just have to give up.
                if (nextFreeParticle == firstRetiredParticle)
                    return;

                float min = settings.Angle - settings.AngleOffset;
                float max = settings.Angle + settings.AngleOffset;

                float ang = min + (float)random.NextDouble() * (max - min);

                min = settings.Velocity - settings.VelocityOffset;
                max = settings.Velocity + settings.VelocityOffset;

                float velo = min + (float)random.NextDouble() * (max - min);

                velocity = new Vector3(velo * (float)Math.Cos(ang), velo * (float)Math.Sin(ang), 0);
                position = new Vector3(GetRandomPosition(), 0);

                // Choose four random control values. These will be used by the vertex
                // shader to give each particle a different size, rotation, and color.
                Color randomValues = new Color((byte)random.Next(255),
                                               (byte)random.Next(255),
                                               (byte)random.Next(255),
                                               (byte)random.Next(255));

                // Fill in the particle vertex structure.
                for (int i = 0; i < 4; i++)
                {
                    particles[firstFreeParticle * 4 + i].Position = position;
                    particles[firstFreeParticle * 4 + i].Velocity = velocity;
                    particles[firstFreeParticle * 4 + i].Random = randomValues;
                    particles[firstFreeParticle * 4 + i].Time = currentTime;
                }

                firstFreeParticle = nextFreeParticle;
            }
        }

        #endregion

        #region Randomisation Methods
        private Vector3 GetRandomDirection()
        {
            float min = settings.Angle - settings.AngleOffset;
            float max = settings.Angle + settings.AngleOffset;
            float angle = min + (float)random.NextDouble() * (max - min);
            return new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0);
        }
        private Vector2 GetRandomPosition()
        {
            switch (settings.Shape)
            {
                case ParticleEmitterShapes.Point:
                    return settings.BasePoint + Offset + Position;
                case ParticleEmitterShapes.Ellipse:
                    double r = Math.Sqrt(random.NextDouble());
                    double theta = 2 * Math.PI * random.NextDouble();
                    double x = settings.ShapeSize.X * r * Math.Cos(theta);
                    double y = settings.ShapeSize.Y * r * Math.Sin(theta);
                    return new Vector2((float)x, (float)y) + settings.BasePoint + Offset + Position;
                case ParticleEmitterShapes.Rectangle:
                    float x2 = (float)random.NextDouble() * settings.ShapeSize.X;
                    float y2 = (float)random.NextDouble() * settings.ShapeSize.Y;
                    return new Vector2(x2, y2) + settings.BasePoint + Offset + Position;
                default:
                    return settings.BasePoint;
            }
        }
        #endregion
        /// <summary>
        /// Clear Emitter
        /// </summary>
        internal void Clear()
        {
            Global.ParticlesEffectPool.Insert(particleEffect);
            vertexBuffer.Dispose();
        }
    }
    /// <summary>
    /// Pool used to cache particle effects
    /// </summary>
    /// <typeparam name="Effect"></typeparam>
    
    public class EffectPool
    {
        private Stack<Effect> _stack;

        public EffectPool()
        {
            _stack = new Stack<Effect>();
        }

        public int Count
        {
            get { return _stack.Count; }
        }

        public EffectPool(int size)
        {
            _stack = new Stack<Effect>(size);
            for (int i = 0; i < size; i++)
            {
                _stack.Push(Global.ParticlesEffect.Clone());
            }
        }

        public Effect Fetch()
        {
            if (_stack.Count > 0)
            {
                return _stack.Pop();
            }
            return Global.ParticlesEffect.Clone();
        }

        public void Insert(Effect item)
        {
            _stack.Push(item);
        }

        internal void Insert(IEnumerable<Effect> items)
        {
            foreach (Effect item in items)
            {
                _stack.Push(item);
            }
        }
    }
}
