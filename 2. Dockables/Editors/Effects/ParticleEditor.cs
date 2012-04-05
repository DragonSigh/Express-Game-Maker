//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Library;
using Microsoft.Xna.Framework.Content;
using EGMGame.Controls;
using EGMGame.Docking.Explorers;
using WeifenLuo.WinFormsUI.Docking;
using GenericUndoRedo;
using EGMGame.Dialogs;
using System.Diagnostics;
using EGMGame.Controls.XNA;
using FarseerPhysics;

namespace EGMGame.Docking.Editors
{
    public partial class ParticleEditor : DockContent, IHistory, IEditor
    {
        #region Variables
        ContentManager contentManager;
        ContentBuilder contentBuilder;
        SpriteBatch spriteBatch;

        Texture2D pixelTexture;

        ParticleSystemData CurrentSystem;
        ParticleEmitterData CurrentEmitter;

        int[] CurrentMaterialIndexes;

        GraphicsDevice graphicsDevice;
        XNA2dCamera Camera;

        Vector2 MouseStartPoint;
        Vector2 MouseEndPoint;

        Stopwatch timer;

        bool showShapes = true;
        bool canDraw = false;
        bool isDrawing = false;

        List<Vector2> primitiveList = new List<Vector2>();

        //calculate FPS  
        long nCount = 0;
        TimeSpan timeTotal;
        TimeSpan timeLastUpdate;
        TimeSpan timeElapsed;
        float millisecondsElapsed = 0;
        public float FPS;

        //calculate Particles
        long particleCount = 0;

        Pool<ParticleEmitter> EmitterPool = new Pool<ParticleEmitter>();
        List<ParticleEmitter> Emitters = new List<ParticleEmitter>();
        #endregion

        Vector2 Offset = Vector2.Zero;
        bool allowChange = true;

        #region Constructor
        public ParticleEditor()
        {
            MainForm.ParticleHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();



            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

            cbSourceBlend.SelectedIndex = 0;
            cbDestinationBlend.SelectedIndex = 0;
            cbEmitterShapes.SelectedIndex = 0;

            InitializeHandlers();

        }
        #endregion

        #region Initialization
        private void InitializeHandlers()
        {
            simpleGraphicsControl.OnDraw += new EventHandler(simpleGraphicsControl_OnDraw);
            simpleGraphicsControl.OnInitialize += new EventHandler(simpleGraphicsControl_OnInitialize);

            Application.Idle += delegate { simpleGraphicsControl.Invalidate(); };
        }

        void simpleGraphicsControl_OnInitialize(object sender, EventArgs e)
        {
            graphicsDevice = simpleGraphicsControl.GraphicsDevice;
            timer = Stopwatch.StartNew();
            timeLastUpdate = timer.Elapsed;
            millisecondsElapsed = 0;
            nCount = 0;
            InitializeGraphics();
        }

        private void InitializeGraphics()
        {
            contentManager = new ContentManager(simpleGraphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            contentBuilder = MaterialExplorer.contentBuilder;

            spriteBatch = new SpriteBatch(simpleGraphicsControl.GraphicsDevice);

            Camera = new XNA2dCamera(graphicsDevice.Viewport);
            Viewport v = graphicsDevice.Viewport;
            v.Width = simpleGraphicsControl.Width;
            v.Height = simpleGraphicsControl.Height;
            // graphicsDevice.Viewport = v;
            Camera.Viewport = v;

            Offset = -GetCenterOffset();

            this.Camera.MapOffset = Offset;
            this.Camera.Offset = -Offset;
            this.Camera.ViewingHeight += Offset.Y * 2;
            this.Camera.ViewingWidth += Offset.X * 2;
            //Camera.Offset = GetOrigin();

            pixelTexture = Loader.TextureFromStream(simpleGraphicsControl.GraphicsDevice, global::EGMGame.Properties.Resources.pixel, System.Drawing.Imaging.ImageFormat.Png);

        }
        #endregion

        #region Drawing

        private void simpleGraphicsControl_OnDraw(object sender, EventArgs e)
        {
            Offset = -GetCenterOffset();
            //Offset.X = 100;
            //Offset.Y = 100;
            this.Camera.MapOffset = Offset;
            this.Camera.Offset = -Offset;
            this.Camera.ViewingHeight += Offset.Y * 2;
            this.Camera.ViewingWidth += Offset.X * 2;

            simpleGraphicsControl.GraphicsDevice.Clear(Color.CornflowerBlue);

            nCount++;
            timeTotal = timer.Elapsed;
            timeElapsed = timeTotal - timeLastUpdate;

            millisecondsElapsed += (float)timeElapsed.TotalMilliseconds;

            timeLastUpdate = timeTotal;

            GameTime gameTime = new GameTime(timeTotal, timeElapsed);


            if (millisecondsElapsed >= 1000)
            {
                FPS = (float)nCount / (millisecondsElapsed / 1000);
                nCount = 0;
                millisecondsElapsed = 0;
            }

            DrawGuides();

            tslblFPS.Text = ((int)FPS).ToString();

            if (CurrentSystem != null && CurrentSystem.Emitters.Count > 0)
            {
                Viewport viewport = graphicsDevice.Viewport;

                Matrix matrix = Matrix.CreateOrthographicOffCenter(0, graphicsDevice.Viewport.Width,     // left, right
                    graphicsDevice.Viewport.Height, 0,    // bottom, top
                    0, 1);

                foreach (ParticleEmitter emitter in Emitters)
                {
                    particleCount += emitter.AmountOfParticles();
                    emitter.Update(gameTime, Camera.ViewTransformationMatrix(), matrix);
                    emitter.Draw();
                }
                // Draw Shape
                DrawShapes();
            }

            tslblParticles.Text = particleCount.ToString();
            particleCount = 0;

        }

        //float num2 = (viewport.Width > 0) ? (1f / ((float)viewport.Width)) : 0f;
        //float num = (viewport.Height > 0) ? (-1f / ((float)viewport.Height)) : 0f;
        //Matrix matrix = new Matrix();
        //matrix.M11 = num2 * 2f;
        //matrix.M22 = num * 2f;
        //matrix.M33 = 1f;
        //matrix.M44 = 1f;
        //matrix.M41 = -1f;
        //matrix.M42 = 1f;
        //matrix.M41 -= num2;
        //matrix.M42 -= num;
        private void DrawGuides()
        {
            spriteBatch.Begin();

            DrawLine(new Vector2(simpleGraphicsControl.Width / 2, 0), new Vector2(simpleGraphicsControl.Width / 2, simpleGraphicsControl.Height),
                Color.Black, 1);
            DrawLine(new Vector2(0, simpleGraphicsControl.Height / 2), new Vector2(simpleGraphicsControl.Width, simpleGraphicsControl.Height / 2),
                Color.Black, 1);
            spriteBatch.End();
        }

        private void DrawLine(Vector2 PointA, Vector2 PointB, Color color, float priority)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            float rotation;

            if (PointA.Y > PointB.Y)
                rotation = -(float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));
            else
                rotation = (float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, 1), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }

        private void DrawShapes()
        {
            if (showShapes)
            {
                Color drawColor = new Color(255, 0, 0, 100);
                foreach (ParticleEmitterData emitter in CurrentSystem.Emitters)
                {
                    if (emitter == CurrentEmitter)
                        drawColor.A = 255;

                    switch (emitter.Settings.Shape)
                    {
                        case ParticleEmitterShapes.Point:
                            DrawPoint(emitter.Settings.BasePoint);
                            break;
                        case ParticleEmitterShapes.Rectangle:
                            DrawRectangle(new Rectangle((int)emitter.Settings.BasePoint.X, (int)emitter.Settings.BasePoint.Y, emitter.Settings.ShapeSize.X, emitter.Settings.ShapeSize.Y), drawColor);
                            break;
                        case ParticleEmitterShapes.Ellipse:
                            DrawEllipse(emitter.Settings.BasePoint, new Vector2(emitter.Settings.ShapeSize.X, emitter.Settings.ShapeSize.Y), drawColor, 20);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Form Paint
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        #endregion

        #region Methods
        private void UpdateProperties(bool initialize)
        {
            if (!allowChange) return;
            ParticleSettings p = new ParticleSettings();

            //if (CurrentEmitter != null)
            //CurrentEmitter.Settings.BasePoint = p.BasePoint;

            if (CurrentSystem != null)
                CurrentSystem.OneUse = cbOneUse.Checked;
            if (CurrentEmitter != null)
                p = CurrentEmitter.Settings;

            p.MaxParticles = (int)nudMaxParticles.Value;
            p.EmissionRate = (int)nudEmissionRate.Value;
            p.ParticlesToEmit = (int)nudParticlesToEmit.Value;

            p.Angle = DegreesToRadians((float)nudAngleBase.Value);
            p.AngleOffset = DegreesToRadians((float)nudAngleOffset.Value);

            p.Duration = TimeSpan.FromSeconds((int)nudLifeTimeBase.Value);
            p.DurationRandomness = (float)nudLifeTimeOffset.Value;

            p.Velocity = (float)nudSpeedInitialBase.Value;
            p.VelocityOffset = (float)nudSpeedInitialOffset.Value;
            p.EndVelocity = (float)nudSpeedFinalBase.Value;

            p.MaxStartSize = (float)nudScaleInitialBase.Value;
            p.MaxEndSize = (float)nudScaleInitialOffset.Value;
            p.MinStartSize = (float)nudScaleFinalBase.Value;
            p.MinEndSize = (float)nudScaleFinalOffset.Value;

            p.MaxRotateSpeed = DegreesToRadians((float)nudRotationBase.Value);
            p.MinRotateSpeed = DegreesToRadians((float)nudRotationIncrease.Value);

            p.GravityMagnitude = (float)nudGravityMagnitude.Value;
            p.GravityAngle = DegreesToRadians((float)nudGravityAngle.Value);

            p.OscillationFrequency = (float)nudOscillationFrequency.Value;
            p.OscillationMagnitudeMin = (float)nudOscillationMin.Value;
            p.OscillationMagnitudeMax = (float)nudOscillationMax.Value;


            p.MaxColor.R = (byte)nudRedBase.Value;
            p.MinColor.R = (byte)nudRedFinal.Value;
            p.MaxColor.G = (byte)nudGreenBase.Value;
            p.MinColor.G = (byte)nudGreenFinal.Value;
            p.MaxColor.B = (byte)nudBlueBase.Value;
            p.MinColor.B = (byte)nudBlueFinal.Value;
            p.MaxColor.A = (byte)nudOpacityBase.Value;
            p.MinColor.A = (byte)nudOpacityFinal.Value;


            p.MaxRotateSpeed = (float)nudRotationBase.Value;
            p.MinRotateSpeed = (float)nudRotationIncrease.Value;

            switch (cbSourceBlend.SelectedIndex)
            {
                case 0:
                    p.BlendState = BlendState.Additive;
                    break;
                case 1:
                    p.BlendState = BlendState.AlphaBlend;
                    break;
                case 2:
                    p.BlendState = BlendState.NonPremultiplied;
                    break;
                case 3:
                    p.BlendState = BlendState.Opaque;
                    break;
            }


            if (CurrentEmitter != null)
            {
                CurrentEmitter.Settings = p;
                Emitters[emitterList.SelectedIndex].settings = p;
                if (initialize)
                    Emitters[emitterList.SelectedIndex].Setup(p);
                else
                    Emitters[emitterList.SelectedIndex].UpdateSettings();
            }
        }

        private float DegreesToRadians(float degrees)
        {
            return MathHelper.ToRadians(degrees);
        }
        private float RadiansToDegrees(float radians)
        {
            return MathHelper.ToDegrees(radians);
        }
        #endregion

        #region Panel Control Events
        #region Basic Panel
        #region Max Particles
        private void nudMaxParticles_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(true);
        }
        #endregion
        #region One Use
        private void cbOneUse_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
        }
        #endregion
        #region Angle
        private void nudBaseAngle_ValueChanged(object sender, EventArgs e)
        {
            asBaseAngle.Angle = (int)nudAngleBase.Value;
            UpdateProperties(false);
        }
        private void asBaseAngle_AngleChanged()
        {
            nudAngleBase.Value = (decimal)asBaseAngle.Angle;
        }

        private void nudOffsetAngle_ValueChanged(object sender, EventArgs e)
        {
            tbAngleOffset.Value = (float)nudAngleOffset.Value;
            UpdateProperties(false);
        }
        private void tbAngleOffset_ValueChanged(object sender, decimal value)
        {
            nudAngleOffset.Value = (decimal)tbAngleOffset.Value;
        }

        #endregion
        #region Life Time
        private void nudBaseLifeTime_ValueChanged(object sender, EventArgs e)
        {
            tbLifeTimeBase.Value = (float)nudLifeTimeBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetLifeTime_ValueChanged(object sender, EventArgs e)
        {
            tbLifeTimeOffset.Value = (float)nudLifeTimeOffset.Value;
            UpdateProperties(false);
        }
        private void tbLifeTimeBase_ValueChanged(object sender, decimal value)
        {
            nudLifeTimeBase.Value = (decimal)tbLifeTimeBase.Value;
        }

        private void tbLifeTimeOffset_ValueChanged(object sender, decimal value)
        {
            nudLifeTimeOffset.Value = (decimal)tbLifeTimeOffset.Value;
        }
        #endregion
        #region Emission Rate
        private void nudBaseEmissionRate_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
        }
        private void nudParticlesToEmit_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
        }
        #endregion

        private void btnSelectStartPoint_Click(object sender, EventArgs e)
        {
            ToggleDraw();
        }

        private void btnBurst_Click(object sender, EventArgs e)
        {
            foreach (ParticleEmitter emitter in Emitters)
            {
                emitter.Burst();
            }
        }
        #endregion
        #region Texture Panel
        private void btnSelectImages_Click(object sender, EventArgs e)
        {
            ChooseImagesDialog dialog = new ChooseImagesDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                CurrentMaterialIndexes = new int[dialog.SelectedImages.Count];
                for (int i = 0; i < dialog.SelectedImages.Count; i++)
                {
                    CurrentMaterialIndexes[i] = dialog.SelectedImages[i].ID;
                }
            }

            UpdateProperties(false);
        }
        private void cbBlendMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
        }
        private void cbDestinationBlend_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
        }
        #endregion

        #region Speed Panel
        #region Velocity
        private void nudBaseVelocity_ValueChanged(object sender, EventArgs e)
        {
            tbSpeedInitialBase.Value = (float)nudSpeedInitialBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetVelocity_ValueChanged(object sender, EventArgs e)
        {
            tbSpeedInitialOffset.Value = (float)nudSpeedInitialOffset.Value;
            UpdateProperties(false);
        }
        private void tbVelocityBase_ValueChanged(object sender, decimal value)
        {
            nudSpeedInitialBase.Value = (decimal)tbSpeedInitialBase.Value;
        }
        private void tbVelocityOffset_ValueChanged(object sender, decimal value)
        {
            nudSpeedInitialOffset.Value = (decimal)tbSpeedInitialOffset.Value;
        }
        #endregion
        #region Acceleration
        private void nudBaseAcceleration_ValueChanged(object sender, EventArgs e)
        {
            tbSpeedFinalBase.Value = (float)nudSpeedFinalBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetAcceleration_ValueChanged(object sender, EventArgs e)
        {
            tbSpeedFinalOffset.Value = (float)nudSpeedFinalOffset.Value;
            UpdateProperties(false);
        }

        private void tbAccelerationBase_ValueChanged(object sender, decimal value)
        {
            nudSpeedFinalBase.Value = (decimal)tbSpeedFinalBase.Value;
        }

        private void tbAccelerationOffset_ValueChanged(object sender, decimal value)
        {
            nudSpeedFinalOffset.Value = (decimal)tbSpeedFinalOffset.Value;
        }
        #endregion
        #endregion

        #region Transform Panel
        #region Scale
        private void nudBaseScale_ValueChanged(object sender, EventArgs e)
        {
            tbScaleInitialBase.Value = (float)nudScaleInitialBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetScale_ValueChanged(object sender, EventArgs e)
        {
            tbScaleInitialOffset.Value = (float)nudScaleInitialOffset.Value;
            UpdateProperties(false);
        }

        private void tbScaleBase_ValueChanged(object sender, decimal value)
        {
            nudScaleInitialBase.Value = (decimal)tbScaleInitialBase.Value;
        }

        private void tbScaleOffset_ValueChanged(object sender, decimal value)
        {
            nudScaleInitialOffset.Value = (decimal)tbScaleInitialOffset.Value;
        }

        private void nudScaleFinalBase_ValueChanged(object sender, EventArgs e)
        {
            tbScaleFinalBase.Value = (float)nudScaleFinalBase.Value;
            UpdateProperties(false);
        }

        private void tbScaleFinalBase_ValueChanged(object sender, decimal value)
        {
            nudScaleFinalBase.Value = (decimal)tbScaleFinalBase.Value;
            UpdateProperties(false);
        }

        private void nudScaleFinalOffset_ValueChanged(object sender, EventArgs e)
        {
            tbScaleFinalOffset.Value = (float)nudScaleFinalOffset.Value;
            UpdateProperties(false);
        }

        private void tbScaleFinalOffset_ValueChanged(object sender, decimal value)
        {
            nudScaleFinalOffset.Value = (decimal)tbScaleFinalOffset.Value;
            UpdateProperties(false);
        }
        #endregion

        #region Rotation
        private void nudBaseRotation_ValueChanged(object sender, EventArgs e)
        {
            tbRotationBase.Value = (float)nudRotationBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetRotation_ValueChanged(object sender, EventArgs e)
        {
            tbRotationOffset.Value = (float)nudRotationOffset.Value;
            UpdateProperties(false);
        }

        private void nudRotationIncrease_ValueChanged(object sender, EventArgs e)
        {
            tbRotationIncrease.Value = (float)nudRotationIncrease.Value;
            UpdateProperties(false);
        }
        private void tbRotationBase_ValueChanged(object sender, decimal value)
        {
            nudRotationBase.Value = (decimal)tbRotationBase.Value;
        }

        private void tbRotationOffset_ValueChanged(object sender, decimal value)
        {
            nudRotationOffset.Value = (decimal)tbRotationOffset.Value;
        }

        private void tbRotationIncrease_ValueChanged(object sender, decimal value)
        {
            nudRotationIncrease.Value = (decimal)tbRotationIncrease.Value;
        }
        #endregion
        #endregion

        #region Force Panel
        #region Gravity
        private void nudGravityMagnitude_ValueChanged(object sender, EventArgs e)
        {
            tbGravityMagnitude.Value = (float)nudGravityMagnitude.Value;
            UpdateProperties(false);
        }
        private void tbGravityMagnitude_ValueChanged(object sender, decimal value)
        {
            nudGravityMagnitude.Value = (decimal)tbGravityMagnitude.Value;
        }

        private void asGravityAngle_AngleChanged()
        {
            nudGravityAngle.Value = (decimal)asGravityAngle.Angle;
        }

        private void nudGravityAngle_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            asGravityAngle.Angle = (int)nudGravityAngle.Value;
        }
        #endregion

        #region Oscillation
        private void tbOscillationFrequency_ValueChanged(object sender, decimal value)
        {
            UpdateProperties(false);
            nudOscillationFrequency.Value = (decimal)tbOscillationFrequency.Value;
        }

        private void nudOscillationFrequency_ValueChanged(object sender, EventArgs e)
        {
            tbOscillationFrequency.Value = (float)nudOscillationFrequency.Value;
        }
        private void nudOscillationMin_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            tbOscillationMin.Value = (float)nudOscillationMin.Value;
        }

        private void tbOscillationMin_ValueChanged(object sender, decimal value)
        {
            nudOscillationMin.Value = (decimal)tbOscillationMin.Value;
        }

        private void nudOscillationMax_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            tbOscillationMax.Value = (float)nudOscillationMax.Value;
        }

        private void tbOscillationMax_ValueChanged(object sender, decimal value)
        {
            nudOscillationMax.Value = (decimal)tbOscillationMax.Value;
        }
        #endregion

        #region Wind
        private void asWindAngle_AngleChanged()
        {
            nudWindAngle.Value = (decimal)asWindAngle.Angle;
        }

        private void nudWindAngle_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            asWindAngle.Angle = (int)nudWindAngle.Value;
        }

        private void nudWindMagnitudeMin_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            tbWindMagnitudeMin.Value = (float)nudWindMagnitudeMin.Value;
        }

        private void tbWindMagnitudeMin_ValueChanged(object sender, decimal value)
        {
            nudWindMagnitudeMin.Value = (decimal)tbWindMagnitudeMin.Value;
        }

        private void nudWindMagnitudeMax_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            tbWindMagnitudeMax.Value = (float)nudWindMagnitudeMax.Value;
        }

        private void tbWindMagnitudeMax_ValueChanged(object sender, decimal value)
        {
            nudWindMagnitudeMax.Value = (decimal)tbWindMagnitudeMax.Value;
        }

        private void nudWindStrength_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            tbWindStrength.Value = (float)nudWindStrength.Value;
        }

        private void tbWindStrength_ValueChanged(object sender, decimal value)
        {
            nudWindStrength.Value = (decimal)tbWindStrength.Value;
        }
        #endregion
        #endregion

        #region Color Panel
        #region Opacity
        private void nudBaseOpacity_ValueChanged(object sender, EventArgs e)
        {
            tbOpacityBase.Value = (float)nudOpacityBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetOpacity_ValueChanged(object sender, EventArgs e)
        {
            //tbOpacityOffset.Value = (float)nudOpacityOffset.Value;
            UpdateProperties(false);
        }

        private void nudOpacityIncrease_ValueChanged(object sender, EventArgs e)
        {
            tbOpacityIncrease.Value = (float)nudOpacityFinal.Value;
            UpdateProperties(false);
        }
        private void tbOpacityBase_ValueChanged(object sender, decimal value)
        {
            nudOpacityBase.Value = (decimal)tbOpacityBase.Value;
        }
        private void tbOpacityOffset_ValueChanged(object sender, decimal value)
        {
            //nudOpacityOffset.Value = (decimal)tbOpacityOffset.Value;
        }

        private void tbOpacityIncrease_ValueChanged(object sender, decimal value)
        {
            nudOpacityFinal.Value = (decimal)tbOpacityIncrease.Value;
        }

        private void cbOpacitySmoothing_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
        }
        #endregion
        #region Color Red
        private void nudBaseColorRed_ValueChanged(object sender, EventArgs e)
        {
            tbRedBase.Value = (float)nudRedBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetColorRed_ValueChanged(object sender, EventArgs e)
        {
            //tbRedOffset.Value = (float)nudRedOffset.Value;
            UpdateProperties(false);
        }

        private void nudIncreaseColorRed_ValueChanged(object sender, EventArgs e)
        {
            tbRedIncrease.Value = (float)nudRedFinal.Value;
            UpdateProperties(false);
        }
        private void tbRedBase_ValueChanged(object sender, decimal value)
        {
            nudRedBase.Value = (decimal)tbRedBase.Value;
        }

        private void tbRedOffset_ValueChanged(object sender, decimal value)
        {
            //nudRedOffset.Value = (decimal)tbRedOffset.Value;
        }

        private void tbRedIncrease_ValueChanged(object sender, decimal value)
        {
            nudRedFinal.Value = (decimal)tbRedIncrease.Value;
        }
        #endregion
        #region Color Green
        private void nudBaseGreenColor_ValueChanged(object sender, EventArgs e)
        {
            tbGreenBase.Value = (float)nudGreenBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetGreenColor_ValueChanged(object sender, EventArgs e)
        {
            //tbGreenOffset.Value = (float)nudGreenOffset.Value;
            UpdateProperties(false);
        }

        private void nudIncreaseGreenColor_ValueChanged(object sender, EventArgs e)
        {
            tbGreenIncrease.Value = (float)nudGreenFinal.Value;
            UpdateProperties(false);
        }

        private void tbGreenBase_ValueChanged(object sender, decimal value)
        {
            nudGreenBase.Value = (decimal)tbGreenBase.Value;
        }

        private void tbGreenOffset_ValueChanged(object sender, decimal value)
        {
            //nudGreenOffset.Value = (decimal)tbGreenOffset.Value;
        }

        private void tbGreenIncrease_ValueChanged(object sender, decimal value)
        {
            nudGreenFinal.Value = (decimal)tbGreenIncrease.Value;
        }
        #endregion
        #region Color Blue
        private void nudBaseBlueColor_ValueChanged(object sender, EventArgs e)
        {
            tbBlueBase.Value = (float)nudBlueBase.Value;
            UpdateProperties(false);
        }

        private void nudOffsetBlueColor_ValueChanged(object sender, EventArgs e)
        {
            //tbBlueOffset.Value = (float)nudBlueOffset.Value;
            UpdateProperties(false);
        }

        private void nudIncreaseBlueColor_ValueChanged(object sender, EventArgs e)
        {
            tbBlueIncrease.Value = (float)nudBlueFinal.Value;
            UpdateProperties(false);
        }

        private void tbBlueBase_ValueChanged(object sender, decimal value)
        {
            nudBlueBase.Value = (decimal)tbBlueBase.Value;
        }

        private void tbBlueOffset_ValueChanged(object sender, decimal value)
        {
            //nudBlueOffset.Value = (decimal)tbBlueOffset.Value;
        }

        private void tbBlueIncrease_ValueChanged(object sender, decimal value)
        {
            nudBlueFinal.Value = (decimal)tbBlueIncrease.Value;
        }
        #endregion

        #endregion
        #endregion

        #region Particle Editor Window
        private void ParticleEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.ParticleSystems, typeof(ParticleSystemData));
            cbMaterialList.RefreshList(false, MaterialDataType.Image);

        }

        private void ParticleEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.ParticleHistory[this];

        }
        #endregion

        #region UI Checks
        private void CheckEmitters()
        {
            if (CurrentSystem != null)
            {
                emitterList.Enabled = true;
                emitterList.SetupList(CurrentSystem.Emitters, typeof(ParticleEmitter));
                emitterList.SelectedIndex = (emitterList.Count > 0 ? 0 : -1);

                gbEmitterList.Enabled = true;

                for (int i = 0; i < Emitters.Count; i++)
                {
                    Emitters[i].Dispose();
                }
                Emitters.Clear();

                for (int i = 0; i < CurrentSystem.Emitters.Count; i++)
                {
                    Emitters.Add(new ParticleEmitter(graphicsDevice, CurrentSystem.Emitters[i].Settings, contentManager, CurrentSystem));
                }

                if (emitterList.SelectedIndex < 0)
                {
                    CurrentEmitter = null; CheckEmitterProperties();
                }
            }
            else
            {
                for (int i = 0; i < Emitters.Count; i++)
                {
                    Emitters[i].Dispose();
                }
                Emitters.Clear();

                emitterList.Clear(true);
                gbEmitterList.Enabled = false;
                splitContainer1.Enabled = false;
            }
        }
        private void CheckEmitterProperties()
        {
            if (CurrentEmitter != null)
            {
                allowChange = false;
                splitContainer1.Enabled = true;

                ParticleSettings p = CurrentEmitter.Settings;

                if (CurrentSystem != null)
                    cbOneUse.Checked = CurrentSystem.OneUse;

                nudMaxParticles.Value = p.MaxParticles;
                nudEmissionRate.Value = p.EmissionRate;
                nudParticlesToEmit.Value = p.ParticlesToEmit;

                nudAngleBase.Value = (decimal)RadiansToDegrees(p.Angle);
                nudAngleOffset.Value = (decimal)RadiansToDegrees(p.AngleOffset);

                nudLifeTimeBase.Value = (decimal)p.Duration.TotalSeconds;
                nudLifeTimeOffset.Value = (decimal)p.DurationRandomness;

                nudSpeedInitialBase.Value = (decimal)p.Velocity;
                nudSpeedInitialOffset.Value = (decimal)p.VelocityOffset;
                nudSpeedFinalBase.Value = (decimal)p.EndVelocity;

                nudScaleInitialBase.Value = (decimal)p.MaxStartSize;
                nudScaleInitialOffset.Value = (decimal)p.MaxEndSize;
                nudScaleFinalBase.Value = (decimal)p.MinStartSize;
                nudScaleFinalOffset.Value = (decimal)p.MinEndSize;

                nudRotationBase.Value = (decimal)p.MaxRotateSpeed;
                nudRotationIncrease.Value = (decimal)p.MinRotateSpeed;

                nudGravityMagnitude.Value = (decimal)p.GravityMagnitude;
                nudGravityAngle.Value = (decimal)RadiansToDegrees(p.GravityAngle);

                nudOscillationFrequency.Value = (decimal)p.OscillationFrequency;
                nudOscillationMin.Value = (decimal)p.OscillationMagnitudeMin;
                nudOscillationMax.Value = (decimal)p.OscillationMagnitudeMax;


                nudRedBase.Value = p.MaxColor.R;
                nudRedFinal.Value = p.MinColor.R;
                nudGreenBase.Value = p.MaxColor.G;
                nudGreenFinal.Value = p.MinColor.G;
                nudBlueBase.Value = p.MaxColor.B;
                nudBlueFinal.Value = p.MinColor.B;
                nudOpacityBase.Value = p.MaxColor.A;
                nudOpacityFinal.Value = p.MinColor.A;

                nudRotationBase.Value = (decimal)p.MaxRotateSpeed;
                nudRotationIncrease.Value = (decimal)p.MinRotateSpeed;

                if (p.BlendState == BlendState.Additive)
                    cbSourceBlend.SelectedIndex = 0;
                if (p.BlendState == BlendState.AlphaBlend)
                    cbSourceBlend.SelectedIndex = 1;
                if (p.BlendState == BlendState.NonPremultiplied)
                    cbSourceBlend.SelectedIndex = 2;
                if (p.BlendState == BlendState.Opaque)
                    cbSourceBlend.SelectedIndex = 3;

                cbEmitterShapes.SelectedIndex = (int)p.Shape;
                nudShapeX.Value = (int)p.BasePoint.X;
                nudShapeY.Value = (int)p.BasePoint.Y;
                nudShapeWidth.Value = (int)p.ShapeSize.X;
                nudShapeHeight.Value = (int)p.ShapeSize.Y;

                cbMaterialList.Select(CurrentEmitter.Settings.TextureID);

                allowChange = true;
                //if (CurrentEmitter != null)
                //{
                //    CurrentEmitter.Settings = p;
                //    Emitters[emitterList.SelectedIndex].settings = p;
                //    Emitters[emitterList.SelectedIndex].UpdateSettings();
                //}
            }
            else
            {
                splitContainer1.Enabled = false;
            }
        }
        #endregion

        #region Graphics Control
        private void simpleGraphicsControl_Resize(object sender, EventArgs e)
        {
            if (graphicsDevice != null)
            {
                Viewport v = graphicsDevice.Viewport;
                v.Width = simpleGraphicsControl.Width;
                v.Height = simpleGraphicsControl.Height;
                Viewport nv = new Viewport();
                nv.Width = 800;
                nv.Height = 600;
                nv.MinDepth = 0;
                nv.MaxDepth = 1;
                try
                {
                    graphicsDevice.Viewport = nv;
                }
                catch
                {
                    nv.Width = 1;
                    nv.Height = 1;
                    graphicsDevice.Viewport = nv;
                }
                Camera.Viewport = v;
            }
        }

        private void simpleGraphicsControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Vector2 end = Camera.GetTransformedPoint(new Vector2(e.X, e.Y));
                Rectangle rect = GetSelectionRectangle(CurrentEmitter.Settings.BasePoint, end);
                CurrentEmitter.Settings.ShapeSize.X = rect.Width;
                CurrentEmitter.Settings.ShapeSize.Y = rect.Height;
                nudShapeWidth.Value = Math.Abs(rect.Width);
                nudShapeHeight.Value = Math.Abs(rect.Height);
            }
        }
        private void simpleGraphicsControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (canDraw)
            {
                CurrentEmitter.Settings.BasePoint = Camera.GetTransformedPoint(new Vector2(e.X, e.Y));
                nudShapeX.Value = (decimal)CurrentEmitter.Settings.BasePoint.X;
                nudShapeY.Value = (decimal)CurrentEmitter.Settings.BasePoint.Y;
                if (CurrentEmitter.Settings.Shape != ParticleEmitterShapes.Point)
                    isDrawing = true;

                ToggleDraw();
            }

        }
        private void simpleGraphicsControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
                isDrawing = false;
        }
        #endregion

        #region AddRemoveList
        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (ca.ID > -1)
            {
                CurrentSystem = GameData.ParticleSystems[ca.ID];
                CheckEmitters();
            }
            else
            {
                CurrentSystem = null;
                emitterList.Clear(true);
                CheckEmitters();
            }
        }

        #region Particle Systems List
        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.ParticleSystems.Add(data.ID, (ParticleSystemData)data);
            addRemoveList.AddNode(data);

        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.ParticleSystems.Remove(data.ID);

            addRemoveList.RemoveNode(data);

        }
        #endregion

        private void addRemoveList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                ParticleSystemData a = new ParticleSystemData();
                a.Name = Global.GetName("ParticleSystem", GameData.ParticleSystems);
                a.ID = Global.GetID(GameData.ParticleSystems);
                a.Category = ca.Category;
                GameData.ParticleSystems.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.ParticleHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                addRemoveList.AddNode(a);

                Global.CBParticles();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "38x002");
            }
        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.ParticleSystems.ContainsKey(addRemoveList.SelectedID))
                {
                    CurrentSystem = null;
                    // History
                    MainForm.ParticleHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.ParticleSystems.Remove(addRemoveList.SelectedID);
                    // 
                    addRemoveList.RemoveSelectedNode();
                    Global.CBParticles();

                    if (addRemoveList.Data().ID < 0)
                    {
                        emitterList.Clear(true);
                        CheckEmitters();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "38x001");
            }
        }
        #endregion

        //        private void ParticleEditor_Shown(object sender, EventArgs e)
        //        {
        //#if !BETA
        //            addRemoveList.SetupList(GameData.ParticleSystems, typeof(ParticleSystemData));
        //#endif
        //        }

        //private void ParticleEditor_Activated(object sender, EventArgs e)
        //{
        //    // Set History To This
        //    MainForm.HistoryExplorer.SelectedHistory = MainForm.ParticleHistory[this];

        //    addRemoveList.SetupList(GameData.ParticleSystems, typeof(ParticleSystemData));
        //}

        #region Particle Emitter List

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataEmitterAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((ParticleSystemData)hist.Parent).Emitters.Add((ParticleEmitterData)data);

            if (CurrentSystem == (ParticleSystemData)hist.Parent)
            {
                CheckEmitters();
                emitterList.AddNode(data);
            }
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataEmitterRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((ParticleSystemData)hist.Parent).Emitters.Remove((ParticleEmitterData)data);

            if (CurrentSystem == (ParticleSystemData)hist.Parent)
            {
                emitterList.RemoveNode(data);
                CheckEmitters();
            }
        }
        #endregion
        private void emitterList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                ParticleEmitterData a = new ParticleEmitterData();
                a.Name = Global.GetName("Emitter", CurrentSystem.Emitters);
                a.ID = Global.GetID(CurrentSystem.Emitters);
                CurrentSystem.Emitters.Add(a);
                Emitters.Add(new ParticleEmitter(graphicsDevice, a.Settings, contentManager, CurrentSystem));
                int index = a.ID;

                // History
                MainForm.ParticleHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataEmitterAdded), new DataRemoveDelegate(DataEmitterRemoved), CurrentSystem));

                emitterList.AddNode(a);
                if (emitterList.Count == 0)
                    splitContainer1.Enabled = true;
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "38x003");
            }
        }

        private void emitterList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                if (emitterList.Data().ID > -1)
                {
                    CurrentEmitter = null;
                    // History
                    MainForm.ParticleHistory[this].Do(new IGameDataRemovedHist(emitterList.Data(), new DataAddDelegate(DataEmitterAdded), new DataRemoveDelegate(DataEmitterRemoved), CurrentSystem));

                    CurrentSystem.Emitters.Remove(emitterList.Data<ParticleEmitterData>());

                    Emitters[emitterList.SelectedIndex].Dispose();
                    Emitters.RemoveAt(emitterList.SelectedIndex);
                    // 
                    emitterList.RemoveSelectedNode();
                    if (emitterList.Count == 0)
                        splitContainer1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "38x004");
            }
        }

        private void emitterList_SelectItem(object sender, AddRemoveListEventArgs e)
        {
            if (emitterList.Data().ID > -1)
            {
                CurrentEmitter = emitterList.Data<ParticleEmitterData>();

                CheckEmitterProperties();
                splitContainer1.Enabled = true;
            }
            else
            {
                CurrentEmitter = null;
                CheckEmitterProperties();
                splitContainer1.Enabled = false;
            }
        }
        #endregion
        #endregion

        #region Draw Shape
        private void ToggleDraw()
        {
            if (!canDraw)
            {
                canDraw = true;
                btnDrawShape.Checked = true;
                tsbDraw.Checked = true;
            }
            else
            {
                //canDraw = false;
                //btnDrawShape.Checked = false;
                //tsbDraw.Checked = false;
            }
        }
        private Rectangle GetSelectionRectangle(Vector2 startPoint, Vector2 endPoint)
        {
            return new Rectangle((int)startPoint.X, (int)startPoint.Y, (int)(endPoint.X - startPoint.X), (int)(endPoint.Y - startPoint.Y));
        }
        private void DrawRectangle(Rectangle rectangle, Color color)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, null, null, null, null, Camera.ViewTransformationMatrix());

            // Top Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y), color, 2, 1);
            // Right Side
            DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), color, 2, 1);
            // Bottom Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y + rectangle.Height), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), color, 2, 1);
            // Left Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X, rectangle.Y + rectangle.Height), color, 2, 1);

            spriteBatch.End();
        }
        private void DrawEllipse(Vector2 startPoint, Vector2 endPoint, Color color, int sides)
        {
            primitiveList.Clear();
            float fMax = (float)MathHelper.TwoPi;
            float fStep = fMax / (float)sides;
            for (float fTheta = fMax; fTheta >= -1; fTheta -= fStep)
            {
                primitiveList.Add(new Vector2((float)((endPoint.X - startPoint.X) * Math.Cos(fTheta)),
                                             (float)((endPoint.Y - startPoint.Y) * Math.Sin(fTheta))));
            }

            if (primitiveList.Count < 2)
                return;

            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero, vLength = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            int nCount = 0;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, null, null, null, null, Camera.ViewTransformationMatrix());

            for (int i = primitiveList.Count - 1; i >= 1; --i)
            {
                vPosition1 = primitiveList[i - 1];
                vPosition2 = primitiveList[i];
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                vLength = vPosition2 - vPosition1;
                vLength.Normalize();

                nCount = (int)Math.Round(fDistance);
                while (nCount-- > 0)
                {
                    vPosition1 += vLength;

                    spriteBatch.Draw(pixelTexture,
                                      startPoint + vPosition1 + 0.5f * (vPosition2 - vPosition1),
                                      null,
                                      color,
                                      fAngle,
                                      new Vector2(0.5f, 0.5f),
                                      new Vector2(fDistance, 1),
                                      SpriteEffects.None,
                                      0);
                }
            }
            spriteBatch.End();
        }
        private void DrawPoint(Vector2 point)
        {

        }
        /// <summary>
        /// Draw Line
        /// </summary>
        /// <param name="PointA"></param>
        /// <param name="PointB"></param>
        /// <param name="color"></param>
        /// <param name="priority"></param>
        private void DrawLine(Vector2 PointA, Vector2 PointB, Color color, int scale, float priority)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            float rotation;

            if (scale <= 0) scale = 1;

            if (PointA.Y > PointB.Y)
                rotation = -(float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));
            else
                rotation = (float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, scale), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }
        #endregion

        #region Location Helpers
        private Vector2 GetCenterOffset()
        {
            return new Vector2(-simpleGraphicsControl.Width / 2, -simpleGraphicsControl.Height / 2);
        }
        #endregion

        #region Public Methods
        internal void ResetProject()
        {
            addRemoveList.SetupList(GameData.ParticleSystems, typeof(ParticleSystemData));
            contentManager = new ContentManager(simpleGraphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
        }

        internal void Unload()
        {
            contentManager = new ContentManager(simpleGraphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
        }
        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion

        #region IEditor Members

        public void SetupList()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void tsbDraw_Click(object sender, EventArgs e)
        {
            if (!tsbDraw.Checked)
            {
                canDraw = true;
                btnDrawShape.Checked = true;
                tsbDraw.Checked = true;
            }
            else
            {
                canDraw = false;
                btnDrawShape.Checked = false;
                tsbDraw.Checked = false;
            }
        }

        private void tsbShowShapes_Click(object sender, EventArgs e)
        {
            if (showShapes)
            {
                canDraw = false;
                isDrawing = false;
                showShapes = false;
                tsbDraw.Enabled = false;
                btnDrawShape.Enabled = false;
            }
            else
            {
                canDraw = false;
                isDrawing = false;
                showShapes = true;
                tsbDraw.Enabled = true;
                btnDrawShape.Enabled = true;
            }
        }

        private void cbEmitterShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbEmitterShapes.SelectedItem.ToString()) && CurrentEmitter != null)
                CurrentEmitter.Settings.Shape = (ParticleEmitterShapes)Enum.Parse(typeof(ParticleEmitterShapes), cbEmitterShapes.SelectedItem.ToString());
        }

        private void cbMaterialList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaterialList.Data().DataType == MaterialDataType.Image)
            {
                if (CurrentEmitter != null)
                {
                    Texture2D tex = Loader.Texture2D(contentManager, cbMaterialList.Data().ID);
                    CurrentEmitter.Settings.TextureID = cbMaterialList.Data().ID;
                    Emitters[emitterList.SelectedIndex].Texture = tex;
                }
            }
            else
                MessageBox.Show("You can only add materials which are images here.");
        }

        private void impactGroupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nudShapeX_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentEmitter != null)
            {
                CurrentEmitter.Settings.BasePoint.X = (float)nudShapeX.Value;
            }
        }

        private void nudShapeY_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentEmitter != null)
            {
                CurrentEmitter.Settings.BasePoint.Y = (float)nudShapeY.Value;
            }
        }

        private void nudShapeWidth_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentEmitter != null)
            {
                CurrentEmitter.Settings.ShapeSize.X = (int)nudShapeWidth.Value;
            }
        }

        private void nudShapeHeight_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentEmitter != null)
            {
                CurrentEmitter.Settings.ShapeSize.Y = (int)nudShapeHeight.Value;
            }
        }

        private void emitterList_MoveItem(object sender, AddRemoveListEventArgs ca)
        {
            for (int i = 0; i < Emitters.Count; i++)
            {
                Emitters[i].Dispose();
            }
            Emitters.Clear();

            for (int i = 0; i < CurrentSystem.Emitters.Count; i++)
            {
                Emitters.Add(new ParticleEmitter(graphicsDevice, CurrentSystem.Emitters[i].Settings, contentManager, CurrentSystem));
            }
        }
    }
}
