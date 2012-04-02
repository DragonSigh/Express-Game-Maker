using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using EGMGame.Library;
using FarseerPhysics;

namespace EGMGame.Components
{

    public class Camera
    {
        #region Properties and Fields
        #region Position

        public Vector2 Position
        {
            get { return position; }
            set
            {
                oldPosition = position;
                position = value;
                visibleArea.X = position.X + offset.X + scroll.X - visibleArea.Width / 2;
                visibleArea.Y = position.Y + offset.Y + scroll.X - visibleArea.Height / 2;
            }
        }
        protected Vector2 position = Vector2.Zero;

        public bool IsMoving
        {
            get { return oldPosition != position; }
        }
        Vector2 oldPosition = Vector2.Zero;

        public int Direction
        {
            get
            {
                Vector2 r = oldPosition - position;
                int angle = (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(r.Y, r.X)), 0);
                return Global.AngleToDirection(angle);
            }
        }

        protected Vector2 offset = Vector2.Zero;
        public Vector2 Offset
        {
            get { return offset; }
            set
            {
                offset = value;
                visibleArea.X = position.X + offset.X + scroll.X - visibleArea.Width / 2;
                visibleArea.Y = position.Y + offset.Y + scroll.X - visibleArea.Height / 2;
            }
        }

        protected Vector2 scroll = Vector2.Zero;
        public Vector2 Scroll
        {
            get { return scroll; }
            set
            {
                scroll = value;
                visibleArea.X = position.X + offset.X + scroll.X - visibleArea.Width / 2;
                visibleArea.Y = position.Y + offset.Y + scroll.X - visibleArea.Height / 2;
            }
        }
        private Vector2 targetPosition;
        private int Timer;
        private decimal ScrollIncrease;
        private decimal ScrollCounter;
        #endregion Position

        #region Culling
        /// <summary>
        /// Visible Area
        /// </summary>
        protected RectangleF visibleArea;
        public RectangleF VisibleArea
        {
            get { return visibleArea; }
        }

        public float ViewingWidth
        {
            get { return visibleArea.Width; }
            set { visibleArea.Width = value; }
        }

        public float ViewingHeight
        {
            get { return visibleArea.Height; }
            set { visibleArea.Height = value; }
        }
        #endregion Culling


        #region Transformations
        protected float rotation = 0.0f;
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        // <0 - <1 = Zoom Out
        // >1 = Zoom In
        // <0 = Funky (flips axis)
        protected Vector2 zoom = Vector2.One;
        public Vector2 Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }
        #endregion Transformations

        public Vector2 ScreenPosition
        {
            get { return new Vector2(viewport.Width / 2, viewport.Height / 2); }
        }

        public Rectangle DrawRectangle
        {
            get
            {
                return new Rectangle((int)RealPosition.X, (int)RealPosition.Y, (int)((Viewport.Width + 64) / zoom.X), (int)((Viewport.Height + 64) / zoom.Y));
            }
        }

        public Vector2 DrawArea
        {
            get
            {
                return new Vector2(RealPosition.X, RealPosition.Y);
            }
        }

        public Vector2 RealPosition
        {
            get { return Position + offset + scroll - (ScreenPosition / zoom); }
        }

        public Viewport Viewport
        {
            get { return viewport; }
            set { viewport = value; position = ScreenPosition; visibleArea = new RectangleF(position.X - (viewport.Width / 2), position.Y - (viewport.Height / 2), viewport.Width, viewport.Height); }
        }

        public Drawable TrackingObject;

        public Vector2 VisiblePosition
        {
            get { return new Vector2(VisibleArea.X, VisibleArea.Y); }
        }
        #endregion Properties and Fields

        #region Constructors
        Viewport viewport;
        public Camera()
        {
        }
        public Camera(Viewport port)
        {
            viewport = port;
            visibleArea = new RectangleF(0, 0, viewport.Width, viewport.Height);
            position = ScreenPosition;
        }
        public Camera(float width, float height, Viewport port)
        {
            viewport = port;
            visibleArea = new RectangleF(0, 0, width, height);
            position = ScreenPosition;
        }
        public Camera(float x, float y, float width, float height, Viewport port)
        {
            viewport = port;
            visibleArea = new RectangleF(x - (width / 2), y - (height / 2), width, height);
            position.X = x;
            position.Y = y;
        }
        #endregion Constructors

        #region Destructors
        public void Dispose()
        {

        }
        #endregion

        #region Methods
        ///
        /// Returns a transformation matrix based on the camera’s position, rotation, and zoom.
        /// Best used as a parameter for the SpriteBatch.Begin() call.
        ///
        public virtual Matrix ViewTransformationMatrix()
        {
            Vector3 matrixRotOrigin;
            Vector2 cameraPosition = Position + Offset + Scroll;
            // Clamp
            if (Global.Instance.CurrentMap != null && Global.Instance.CurrentMap.Data != null)
            {
                cameraPosition.X = (int)MathHelper.Min(MathHelper.Max(ScreenPosition.X, Position.X + Offset.X + Scroll.X), Global.Instance.CurrentMap.Data.Size.X - ScreenPosition.X);
                cameraPosition.Y = (int)MathHelper.Min(MathHelper.Max(ScreenPosition.Y, Position.Y + Offset.Y + Scroll.Y), Global.Instance.CurrentMap.Data.Size.Y - ScreenPosition.Y);
            }
            // Matrix Positioning
            matrixRotOrigin = new Vector3(cameraPosition, 0);

            Vector3 matrixScreenPos = new Vector3(ScreenPosition, 0.0f);
            Vector3 screenScalingFactor;

            if (Global.Instance.ResolutionIndependent)
            {
                float horScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 800;
                float verScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 600;
                screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            }
            else
            {
                screenScalingFactor = new Vector3(1, 1, 1);
            }
            // Translate back to the origin based on the camera’s offset position, since we’re rotating around the camera
            // Then, we scale and rotate around the origin
            // Finally, we translate to SCREEN coordinates, so translation is based on the ScreenCenter
            return Matrix.CreateTranslation(-matrixRotOrigin) *
                Matrix.CreateScale(zoom.X, zoom.Y, 1.0f) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateTranslation(matrixScreenPos);
        }
        ///
        /// Returns a transformation matrix based on the camera’s position, rotation, and zoom.
        /// Best used as a parameter for the SpriteBatch.Begin() call.
        ///
        public virtual Matrix ViewTransformationMatrix2()
        {
            Vector3 matrixRotOrigin;
            Vector2 cameraPosition = Position + Offset + Scroll;
            // Clamp
            if (Global.Instance.CurrentMap != null)
            {
                cameraPosition.X = (int)MathHelper.Min(MathHelper.Max(ScreenPosition.X, Position.X + Offset.X + Scroll.X), Global.Instance.CurrentMap.Data.Size.X - ScreenPosition.X);
                cameraPosition.Y = (int)MathHelper.Min(MathHelper.Max(ScreenPosition.Y, Position.Y + Offset.Y + Scroll.Y), Global.Instance.CurrentMap.Data.Size.Y - ScreenPosition.Y);
            }
            // Matrix Positioning
            matrixRotOrigin = new Vector3(cameraPosition, 0);
            matrixRotOrigin += Matrix.Identity.Forward;

            Vector3 matrixScreenPos = new Vector3(ScreenPosition, 0.0f);
            Vector3 screenScalingFactor;

            if (Global.Instance.ResolutionIndependent)
            {
                float horScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 800;
                float verScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 600;
                screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            }
            else
            {
                screenScalingFactor = new Vector3(1, 1, 1);
            }
            // Translate back to the origin based on the camera’s offset position, since we’re rotating around the camera
            // Then, we scale and rotate around the origin
            // Finally, we translate to SCREEN coordinates, so translation is based on the ScreenCenter
            return Matrix.CreateTranslation(-matrixRotOrigin) *
                Matrix.CreateScale(zoom.X, zoom.Y, 1.0f) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateTranslation(matrixScreenPos);
        }
        /// <summary>
        /// Transformation Matrix used by the simulator
        /// </summary>
        /// <returns></returns>
        internal Matrix ViewTransformationMatrixSim()
        {
            Vector3 matrixRotOrigin;
            Vector2 cameraPosition = Position + Offset + Scroll;
            // Clamp
            if (Global.Instance.CurrentMap != null && Global.Instance.CurrentMap.Data != null)
            {
                cameraPosition.X = (int)MathHelper.Min(MathHelper.Max(ScreenPosition.X, Position.X + Offset.X + Scroll.X), Global.Instance.CurrentMap.Data.Size.X - ScreenPosition.X);
                cameraPosition.Y = (int)MathHelper.Min(MathHelper.Max(ScreenPosition.Y, Position.Y + Offset.Y + Scroll.Y), Global.Instance.CurrentMap.Data.Size.Y - ScreenPosition.Y);
            }
            // Matrix Positioning
            matrixRotOrigin = new Vector3(ConvertUnits.ToSimUnits(cameraPosition), 0);

            Vector3 matrixScreenPos = new Vector3(ConvertUnits.ToSimUnits(ScreenPosition), 0.0f);
            Vector3 screenScalingFactor;

            if (Global.Instance.ResolutionIndependent)
            {
                float horScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 800;
                float verScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 600;
                screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            }
            else
            {
                screenScalingFactor = new Vector3(1, 1, 1);
            }
            // Translate back to the origin based on the camera’s offset position, since we’re rotating around the camera
            // Then, we scale and rotate around the origin
            // Finally, we translate to SCREEN coordinates, so translation is based on the ScreenCenter
            return Matrix.CreateTranslation(-matrixRotOrigin) *
                Matrix.CreateScale(zoom.X, zoom.Y, 1.0f) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateTranslation(matrixScreenPos);
        }
        /// <summary>
        /// Transforms and returns a point to camera relative coordinates.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal Vector2 GetTransformedPoint(Vector2 p)
        {
            Matrix m = ViewTransformationMatrix();
            Vector2 location = Vector2.Transform(p, Matrix.Invert(m));
            return location;
        }
        /// <summary>
        /// Transforms and returns a point to camera relative coordinates.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal Vector2 ToScreenVector(Vector2 p)
        {
            Matrix m = ViewTransformationMatrix();
            Vector2 location = Vector2.Transform(p, m);
            return location;
        }
        /// <summary>
        /// Transforms and returns a point to camera relative coordinates.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal Matrix GetTransformedMatrix(Vector2 p)
        {
            Vector3 matrixRotOrigin;
            Vector2 cameraPosition = Position + Offset + Scroll;
            // Clamp
            // Matrix Positioning
            matrixRotOrigin = new Vector3(p, 0);

            Vector3 matrixScreenPos = new Vector3(ScreenPosition, 0.0f);
            Vector3 screenScalingFactor;

            if (Global.Instance.ResolutionIndependent)
            {
                float horScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 800;
                float verScaling = (float)Global.Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 600;
                screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            }
            else
            {
                screenScalingFactor = new Vector3(1, 1, 1);
            }
            // Translate back to the origin based on the camera’s offset position, since we’re rotating around the camera
            // Then, we scale and rotate around the origin
            // Finally, we translate to SCREEN coordinates, so translation is based on the ScreenCenter
            return Matrix.CreateTranslation(-matrixRotOrigin) *
                //Matrix.CreateScale(screenScalingFactor) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateTranslation(matrixScreenPos);
        }
        #endregion Methods

        /// <summary>
        /// Changes the offset X but keeps it in map bounds.
        /// </summary>
        /// <param name="p"></param>
        public void OffsetXTo(int p)
        {
            Rectangle rect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, viewport.Width, viewport.Height);
            float value = offset.X + p;
            if (Global.Instance.CurrentMap != null)
            {
                if (ExMath.Between((int)value + (int)position.X, (int)rect.X, (int)Global.Instance.CurrentMap.Data.Size.X - rect.X))
                {
                    offset.X = value;
                }
            }
            else
                offset.X = value;
        }
        /// <summary>
        /// Changes the offset Y but keeps it in map bounds.
        /// </summary>
        /// <param name="p"></param>
        public void OffsetYTo(int p)
        {
            Rectangle rect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, viewport.Width, viewport.Height);
            float value = offset.Y + p;
            if (Global.Instance.CurrentMap != null)
            {
                if (ExMath.Between((int)value + (int)position.Y, (int)rect.Y, (int)Global.Instance.CurrentMap.Data.Size.Y - rect.Y))
                {
                    offset.Y = value;
                }
            }
            else
                offset.Y = value;
        }
        /// <summary>
        /// Scroll
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="ftames"></param>
        public void ScrollTo(Vector2 pixels, int frames)
        {
            targetPosition = pixels + scroll;
            ScrollCounter = ScrollIncrease = (Math.Abs(pixels.X) > Math.Abs(pixels.Y) ? (decimal)pixels.X / (decimal)frames : (decimal)pixels.Y / (decimal)frames);
            Timer = frames;
        }
        /// <summary>
        /// Scroll To
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void ScrollTo(int frames, Vector2 goTo)
        {
            Vector2 pixels = goTo - this.Position;
            targetPosition = pixels;
            ScrollCounter = ScrollIncrease = (Math.Abs(pixels.X) > Math.Abs(pixels.Y) ? (decimal)pixels.X / (decimal)frames : (decimal)pixels.Y / (decimal)frames);
            Timer = frames;
        }
        /// <summary>
        /// Scroll To
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void ScrollTo(int frames, EGMGame.Processors.EventProcessor e)
        {
            if (e != null)
            {
                Vector2 pixels = e.Position - this.Position;
                targetPosition = pixels;
                ScrollCounter = ScrollIncrease = (Math.Abs(pixels.X) > Math.Abs(pixels.Y) ? (decimal)pixels.X / (decimal)frames : (decimal)pixels.Y / (decimal)frames);
                Timer = frames;
            }
        }
        /// <summary>
        /// Center Camera
        /// </summary>
        /// <param name="p"></param>
        public void Center(int frames)
        {
            if (scroll.X != 0 || scroll.Y != 0)
            {
                targetPosition = Vector2.Zero;
                Vector2 pixels = new Vector2(-scroll.X, -scroll.Y);
                Timer = frames;
                ScrollCounter = ScrollIncrease = (Math.Abs(pixels.X) > Math.Abs(pixels.Y) ? (decimal)pixels.X / (decimal)frames : (decimal)pixels.Y / (decimal)frames);
            }
        }
        /// <summary>
        /// Update Camera
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(GameTime gameTime)
        {
            // Update Camera
            if (TrackingObject != null && Global.Instance.CurrentMap != null)
            {
                Vector2 cameraPosition = TrackingObject.Position;
                // Clamp
                if (Global.Instance.LockScreen.X > 0 ||
                         Global.Instance.LockScreen.Y > 0 ||
                         Global.Instance.LockScreen.Width > 0 ||
                         Global.Instance.LockScreen.Height > 0)
                {
                    cameraPosition.X = MathHelper.Min(MathHelper.Max(ScreenPosition.X, Global.Instance.LockScreen.X + Global.Instance.LockScreen.Width / 2), Global.Instance.CurrentMap.Data.Size.X - ScreenPosition.X);
                    cameraPosition.Y = MathHelper.Min(MathHelper.Max(ScreenPosition.Y, Global.Instance.LockScreen.Y + Global.Instance.LockScreen.Height / 2), Global.Instance.CurrentMap.Data.Size.Y - ScreenPosition.Y);
                }
                else
                {
                    cameraPosition.X = MathHelper.Min(MathHelper.Max(ScreenPosition.X, TrackingObject.Position.X), Global.Instance.CurrentMap.Data.Size.X - ScreenPosition.X);
                    cameraPosition.Y = MathHelper.Min(MathHelper.Max(ScreenPosition.Y, TrackingObject.Position.Y), Global.Instance.CurrentMap.Data.Size.Y - ScreenPosition.Y);
                }
                Position = cameraPosition;
            }

            if (Timer > 0 && Global.Instance.ScreenState == ScreenState.Active && Global.Instance.CurrentMap != null)
            {
                // Scroll
                if (ScrollCounter != 0)
                {
                    if (targetPosition.X < scroll.X || targetPosition.X > scroll.X)
                        scroll.X = scroll.X + (float)ScrollCounter;

                    if (targetPosition.Y > scroll.Y || targetPosition.Y < scroll.Y)
                        scroll.Y = scroll.Y + (float)ScrollCounter;
                    ScrollCounter = 0;
                }

                ScrollCounter += ScrollIncrease;

                // Decrease Timer
                Timer--;

            }
            oldPosition = position;
        }
    }
}