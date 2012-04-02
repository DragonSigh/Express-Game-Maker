using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Controls;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace EGMGame.Library
{
    [Serializable]
    public class ParticleEmitter 
    {
        #region Variables
        ParticleSystemData parentSystem;

        GraphicsDevice graphicsDevice;
        ContentManager contentManager;

        QuickAlgorythm random = new QuickAlgorythm();

        public Matrix ViewTransformMatrix;

        public Texture2D Texture
        {
            get
            {
                if (texture == null)
                {
                    texture = Loader.Texture2D(contentManager, settings.TextureID);
                    if (texture != null)
                        UpdateTexture();
                }
                return texture;
            }
            set { texture = value; UpdateTexture(); }
        }
        Texture2D texture;

        public ParticleSettings settings { get; set; }

        System.Timers.Timer emissionTimer;

        public bool IsActive { get { return true; } }


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

        #endregion

        #region Constructor
        public ParticleEmitter() { }
        public ParticleEmitter(GraphicsDevice device, ParticleSettings prop, ContentManager manager, ParticleSystemData parent)
        {
            graphicsDevice = device;
            contentManager = manager;
            settings = prop;
            parentSystem = parent;

            Initialize();
        }
        public void Setup(ParticleSettings s)
        {
            if (emissionTimer != null)
                emissionTimer.Stop();
            settings = s;
            firstActiveParticle = 0;
            firstNewParticle = 0;
            firstFreeParticle = 0;
            firstRetiredParticle = 0;
            // Init
            Initialize();
        }
        /// <summary>
        /// Initialize Emitter
        /// </summary>
        public void Initialize()
        {
            emissionTimer = new System.Timers.Timer(settings.EmissionRate * 16);
            emissionTimer.Elapsed += new System.Timers.ElapsedEventHandler(emissionTimer_Elapsed);

            // Allocate the particle array, and fill in the corner fields (which never change).
            particles = new ParticleVertex[settings.MaxParticles * 4];

            for (int i = 0; i < settings.MaxParticles; i++)
            {
                particles[i * 4 + 0].Corner = new Short2(-1, -1);
                particles[i * 4 + 1].Corner = new Short2(1, -1);
                particles[i * 4 + 2].Corner = new Short2(1, 1);
                particles[i * 4 + 3].Corner = new Short2(-1, 1);
            }

            LoadContent();

            // Create a dynamic vertex buffer.
            vertexBuffer = new DynamicVertexBuffer(graphicsDevice, ParticleVertex.VertexDeclaration,
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

            indexBuffer = new IndexBuffer(graphicsDevice, typeof(ushort), indices.Length, BufferUsage.WriteOnly);

            indexBuffer.SetData(indices);

            emissionTimer.Start();
        }

        void emissionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Texture != null && !parentSystem.OneUse)
                AddParticles();
        }

        internal void Setup(GraphicsDevice _graphicsDevice, ContentManager _contentManager, ParticleSystemData parent)
        {
            graphicsDevice = _graphicsDevice;
            contentManager = _contentManager;
            parentSystem = parent;

            Initialize();
        }

        internal bool IsNull()
        {
            return (graphicsDevice == null || contentManager == null || parentSystem == null);
        }

        public void Burst()
        {
            AddParticles();
        }

        public int AmountOfParticles()
        {
            if (IsNull())
                return 0;
            int x = particles.Length - (firstFreeParticle - firstNewParticle);
            return x;
        }
        #endregion

        #region Load Content
        public void LoadContent()
        {
            Effect effect = Loader.LoadMainEffect(graphicsDevice, "ParticleEffect", contentManager);

            particleEffect = effect.Clone();

            EffectParameterCollection p = particleEffect.Parameters;

            effectViewParameter = p["View"];
            effectProjectionParameter = p["Projection"];
            effectViewportScaleParameter = p["ViewportScale"];
            effectTimeParameter = p["CurrentTime"];

            UpdateSettings();

        }
        #endregion

        #region Settings
        public void UpdateSettings()
        {
            if (particleEffect != null)
            {
                emissionTimer.Interval = settings.EmissionRate * 16;

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

                UpdateTexture();
            }
        }
        public void UpdateTexture()
        {
            EffectParameterCollection p = particleEffect.Parameters;
            p["Texture"].SetValue(Texture);
        }
        #endregion

        #region Update and Draw

        public void Update(GameTime gameTime, Matrix viewTransformMatrix, Matrix projection)
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
                    firstActiveParticle = 0;
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

        public void Draw()
        {
            if (Texture != null)
            {
                GraphicsDevice device = graphicsDevice;

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
                    if (settings.BlendState == null) settings.BlendState = BlendState.Additive;
                    device.BlendState = settings.BlendState;
                    device.DepthStencilState = DepthStencilState.DepthRead;

                    // Set an effect parameter describing the viewport size. This is
                    // needed to convert particle sizes into screen space point sizes.
                    //effectViewportScaleParameter.SetValue(new Vector2(0.5f / device.Viewport.AspectRatio, -0.5f));
                    effectViewportScaleParameter.SetValue(new Vector2(Texture.Width, -texture.Height));

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

        private void SetParticleRenderStates(GraphicsDevice renderState)
        {
            //renderState.DepthStencilState = DepthStencilState.DepthRead;
            //renderState.BlendState = BlendState.NonPremultiplied;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a new particle to the system.
        /// </summary>
        public void AddParticles()
        {
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
                    return settings.BasePoint;
                case ParticleEmitterShapes.Ellipse:
                    double r = Math.Sqrt(random.NextDouble());
                    double theta = 2 * Math.PI * random.NextDouble();
                    double x = settings.ShapeSize.X * r * Math.Cos(theta);
                    double y = settings.ShapeSize.Y * r * Math.Sin(theta);
                    return new Vector2((float)x, (float)y) + settings.BasePoint;
                case ParticleEmitterShapes.Rectangle:
                    float x2 = (float)random.NextDouble() * settings.ShapeSize.X;
                    float y2 = (float)random.NextDouble() * settings.ShapeSize.Y;
                    return new Vector2(x2, y2) + settings.BasePoint;
                default:
                    return settings.BasePoint;
            }
        }
        #endregion

        internal void Dispose()
        {
            emissionTimer.Stop();
            emissionTimer.Dispose();
            vertexBuffer.Dispose();
        }
    }
}
