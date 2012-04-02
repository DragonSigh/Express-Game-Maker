using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EGMGame.Controls.XNA
{
    public class XNA2dCamera
    {
        #region Properties and Fields
        #region Position

        protected Vector2 position = Vector2.Zero;
        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                visibleArea.X = position.X + offset.X - visibleArea.Width / 2;
                visibleArea.Y = position.Y + offset.Y - visibleArea.Height / 2;
            }
        }

        protected Vector2 offset = Vector2.Zero;
        public Vector2 Offset
        {
            get { return offset; }
            set
            {
                offset = value;
                visibleArea.X = position.X + offset.X - visibleArea.Width / 2;
                visibleArea.Y = position.Y + offset.Y - visibleArea.Height / 2;
            }
        }
        #endregion Position

        #region Culling
        // RectangleF = a Rectangle class that uses floats instead of ints
        protected System.Drawing.RectangleF visibleArea;
        public System.Drawing.RectangleF VisibleArea
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
                return new Rectangle((int)RealPosition.X, (int)RealPosition.Y, (int)(Viewport.Width * zoom.X), (int)(Viewport.Height * zoom.Y));
            }
        }

        public Rectangle DrawRectangleOffset
        {
            get
            {
                return new Rectangle((int)RealOffsetPosition.X, (int)RealOffsetPosition.Y, (int)((Viewport.Width + MapOffset.X * 2) / zoom.X), (int)((Viewport.Height + MapOffset.X * 2) / zoom.Y));
            }
        }


        public Vector2 RealPosition
        {
            get { return Position - (ScreenPosition / zoom); }
        }

        public Vector2 RealOffsetPosition
        {
            get { return Position - MapOffset - (ScreenPosition / zoom); }
        }

        public Viewport Viewport
        {
            get { return viewport; }
            set { viewport = value; position = ScreenPosition; visibleArea = new System.Drawing.RectangleF(position.X - (viewport.Width / 2), position.Y - (viewport.Height / 2), viewport.Width, viewport.Height); }
        }

        #endregion Properties and Fields

        #region Constructors
        Viewport viewport;
        public XNA2dCamera(Viewport port)
        {
            viewport = port;
            visibleArea = new System.Drawing.RectangleF(0, 0, viewport.Width, viewport.Height);
            position = ScreenPosition;
        }
        public XNA2dCamera(float width, float height, Viewport port)
        {
            viewport = port;
            visibleArea = new System.Drawing.RectangleF(0, 0, width, height);
            position = ScreenPosition;
        }
        public XNA2dCamera(float x, float y, float width, float height, Viewport port)
        {
            viewport = port;
            visibleArea = new System.Drawing.RectangleF(x - (width / 2), y - (height / 2), width, height);
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
            Vector3 matrixRotOrigin = new Vector3(Position + Offset, 0);
            Vector3 matrixScreenPos = new Vector3(ScreenPosition, 0.0f);

            // Translate back to the origin based on the camera’s offset position, since we’re rotating around the camera
            // Then, we scale and rotate around the origin
            // Finally, we translate to SCREEN coordinates, so translation is based on the ScreenCenter
            Matrix m =  Matrix.CreateTranslation(-matrixRotOrigin) *
                Matrix.CreateScale(zoom.X, zoom.Y, 1.0f) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateTranslation(matrixScreenPos);
            return m;
        }

        internal Matrix ViewTransformationMatrixNoZoom()
        {
            Vector3 matrixRotOrigin = new Vector3(Position + Offset, 0);
            Vector3 matrixScreenPos = new Vector3(ScreenPosition, 0.0f);

            // Translate back to the origin based on the camera’s offset position, since we’re rotating around the camera
            // Then, we scale and rotate around the origin
            // Finally, we translate to SCREEN coordinates, so translation is based on the ScreenCenter
            return Matrix.CreateTranslation(-matrixRotOrigin) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateTranslation(matrixScreenPos);
        }

        internal System.Drawing.PointF GetTransformedPoint(System.Drawing.Point p)
        {
            Matrix m = ViewTransformationMatrix();
            Vector2 location = Vector2.Transform(new Vector2((float)p.X, (float)p.Y), Matrix.Invert(m));
            return new System.Drawing.PointF(location.X, location.Y);
        }


        internal Vector2 GetTransformedPointV(System.Drawing.Point p)
        {
            Matrix m = ViewTransformationMatrix();
            Vector2 location = Vector2.Transform(new Vector2(p.X, p.Y), Matrix.Invert(m));
            return location;
        }

        internal Vector2 GetTransformedPoint(Vector2 p)
        {
            Matrix m = ViewTransformationMatrix();
            Vector2 location = Vector2.Transform(new Vector2(p.X, p.Y), Matrix.Invert(m));
            return location;
        }

        internal Vector2 GetTransformedPointNoZoom(Vector2 p)
        {
            Matrix m = ViewTransformationMatrixNoZoom();
            Vector2 location = Vector2.Transform(new Vector2(p.X, p.Y), Matrix.Invert(m));
            return location;
        }
        #endregion Methods

        int shakeFrames, ShakePower, ShakeFrequency, ShakeCounter;
        Color FlashColor;
        int flashFrames, FlashFrequency;
        byte TargetFlashAlpha = 0;
        byte FlashIncrement = 0;
        int ShakeDirection;
        public Vector2 MapOffset;

        internal void Update(SpriteBatch spriteBatch, Texture2D blank, Vector2 size)
        {
            if (shakeFrames > 0)
            {
                Random rand = new Random();
                if (ShakeDirection == 0)
                {
                    ShakeCounter -= ShakeFrequency;
                    OffsetXTo(-ShakeFrequency);
                    if (rand.Next(0, 100) > 30) // up
                        OffsetYTo(-rand.Next(0, ShakeFrequency));
                    else
                        OffsetYTo(rand.Next(0, ShakeFrequency));
                    if (ShakeCounter <= -ShakePower)
                        ShakeDirection = 1;

                }
                else
                {
                    ShakeCounter += ShakeFrequency;
                    OffsetXTo(ShakeFrequency);
                    if (rand.Next(0, 100) > 70) // up
                        OffsetYTo(-rand.Next(0, ShakeFrequency));
                    else
                        OffsetYTo(rand.Next(0, ShakeFrequency));
                    if (ShakeCounter >= ShakePower)
                        ShakeDirection = 0;
                }


                shakeFrames--;
            }
            else if (shakeFrames <= 0)
            {
                Offset = new Vector2(0, 0);
            }

            if (flashFrames > 0)
            {

                if (FlashIncrement == 0)
                {  // Adjust alpha
                    FlashColor.A = (byte)Math.Min(FlashColor.A + (TargetFlashAlpha / FlashFrequency), TargetFlashAlpha);

                    if (FlashColor.A == TargetFlashAlpha)
                        FlashIncrement = 1;
                }
                else
                {   // Adjust alpha
                    FlashColor.A = (byte)Math.Max(FlashColor.A - (TargetFlashAlpha / FlashFrequency), 0);

                    if (FlashColor.A == 0)
                        FlashIncrement = 0;
                }
                // Flash Screen
                TintScreen(FlashColor, spriteBatch, blank, size);
                flashFrames--;
            }
        }

        private void TintScreen(Color color, SpriteBatch spriteBatch, Texture2D blank, Vector2 size)
        {
            try
            {
                spriteBatch.Begin();

                spriteBatch.Draw(blank,
                                 new Rectangle(0, 0, (int)size.X, (int)size.Y),
                                 color);
            }
            catch
            {
            }
            finally
            {
                spriteBatch.End();
            }
        }

        internal void ShakeScreen(int power, int frames, int speed)
        {
            shakeFrames = frames;
            ShakePower = power;
            ShakeFrequency = speed;
        }

        internal void FlashScreen(Color color, int frames, int freq)
        {
            TargetFlashAlpha = color.A;
            FlashColor = color; flashFrames = frames; FlashFrequency = freq;
        }


        /// <summary>
        /// Changes the offset X but keeps it in map bounds.
        /// </summary>
        /// <param name="p"></param>
        public void OffsetXTo(int p)
        {
            Rectangle rect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, viewport.Width, viewport.Height);
            float value = offset.X + p;
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
            offset.Y = value;
        }

        internal void Reset()
        {
            shakeFrames = 0;
            Offset = new Vector2(0, 0);
            flashFrames = 0;
        }

        internal System.Drawing.Point ReverseTransformPoint(Vector2 p)
        {
            Matrix m = ViewTransformationMatrix();
            Vector2 location = Vector2.Transform(new Vector2(p.X, p.Y), m);
            return new System.Drawing.Point((int)location.X, (int)location.Y);
        }
    }
}
