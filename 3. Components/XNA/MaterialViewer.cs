using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Docking.Explorers;
using Microsoft.Xna.Framework;
using EGMGame.Controls.XNA;

namespace EGMGame.Controls
{
    public partial class MaterialViewer : UserControl
    {
        #region Fields
        public MaterialData SelectedMaterial
        {
            get { return material; }
            set
            {
                material = value; SetupFrame(value);
                if (value != null)
                    toolStrip.Visible = (value.DataType == MaterialDataType.Bitmap_Font || value.DataType == MaterialDataType.Image) && !hideTools;
                else
                    toolStrip.Visible = false;
            }
        }
        MaterialData material;

        public bool HideTools
        {
            get { return hideTools; }
            set { hideTools = value; }
        }
        bool hideTools = false;
        #endregion

        #region Variables
        // Content variables
        internal ContentManager contentManager;
        // Render variables
        GraphicsDevice graphicsDevice;
        // Drawing variables
        SpriteBatch spriteBatch;
        Texture2D pixelTexture;
        // Camera
        XNA2dCamera camera;

        // Image/Camera Variables
        float zoomLevel = 1.0f;
        #endregion
        public MaterialViewer()
        {
            InitializeComponent();

            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

            // GUI Initialization
            toolStrip.Renderer = new ImpactUI.ImpactToolstripRenderer();

            // Application Event Hooking 
            Application.Idle += delegate { graphicsControl.Invalidate(); };
            this.Resize += delegate { graphicsControl.Invalidate(); };
        }

        private void SetupFrame(MaterialData frame)
        {
            if (frame != null && camera != null)
            {
                camera.ViewingHeight = this.Height;
                camera.ViewingWidth = this.Width;
                UpdateScrollbarsH();
                UpdateScrollbarsW();
            }
        }
        #region Scrollbars
        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Vector2 p = camera.Position;
            p.Y += (e.NewValue > e.OldValue ? e.NewValue - e.OldValue : -(e.OldValue - e.NewValue));
            camera.Position = p;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Vector2 p = camera.Position;
            p.X += (e.NewValue > e.OldValue ? e.NewValue - e.OldValue : -(e.OldValue - e.NewValue));
            camera.Position = p;
        }
        #endregion

        #region Tool Events
        private void tsbZoomIn_Click(object sender, EventArgs e)
        {
            Zoom(25, false);
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            Zoom(-25, false);
        }

        private void tsbmZoom25_Click(object sender, EventArgs e)
        {
            Zoom(25, true);
        }

        private void tsbmZoom50_Click(object sender, EventArgs e)
        {
            Zoom(50, true);
        }

        private void tsbmZoom100_Click(object sender, EventArgs e)
        {
            Zoom(100, true);
        }

        private void tsbmZoom200_Click(object sender, EventArgs e)
        {
            Zoom(200, true);
        }

        private void Zoom(int percent, bool exact)
        {
            hScrollBar.Value = hScrollBar.Minimum;
            vScrollBar.Value = vScrollBar.Minimum;

            if (exact)
            {
                zoomLevel = (float)percent / 100;
                graphicsControl.Invalidate();
            }
            else
            {
                if (zoomLevel * 100 + percent >= Math.Abs(percent))
                    zoomLevel += (float)percent / 100;
                graphicsControl.Invalidate();
            }

            string text;
            if ((zoomLevel * 100) < 100)
                text = "0" + (zoomLevel * 100).ToString() + "%";
            else
                text = (zoomLevel * 100).ToString() + "%";
            camera.Zoom = new Vector2(zoomLevel, zoomLevel);
            lblZoom.Text = text;
            UpdateScrollbarsH();
            UpdateScrollbarsW();

            camera.Position = camera.ScreenPosition / zoomLevel;
        }


        private void graphicsControl_Resize(object sender, EventArgs e)
        {
            if (material != null && graphicsDevice != null)
            {
                Viewport v = graphicsDevice.Viewport;
                v.Height = Math.Max(1, graphicsControl.Height);
                v.Width = Math.Max(1, graphicsControl.Width);
                // graphicsDevice.Viewport = v;
                camera.Viewport = v;
                UpdateScrollbarsW();
                UpdateScrollbarsH();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update Scrollbars
        /// </summary>
        private void UpdateScrollbarsH()
        {
        }
        /// <summary>
        /// Update Scrollbars
        /// </summary>
        private void UpdateScrollbarsW()
        {
        }
        #endregion

        #region Graphics
        private void graphicsControl_OnInitialize(object sender, EventArgs e)
        {
            // Initialize the graphics device
            graphicsDevice = graphicsControl.GraphicsDevice;
            camera = new XNA2dCamera(graphicsDevice.Viewport);
            // initialize drawing resources.
            spriteBatch = new SpriteBatch(graphicsDevice);
            //pixelTexture = Loader.LoadStreamTexture(graphicsDevice, global::ExpressGameMaker.Properties.Resources.pixel, System.Drawing.Imaging.ImageFormat.Png);
            // Scroll Reset
            hScrollBar.Minimum = 0;
            vScrollBar.Minimum = 0;
            Viewport v = graphicsDevice.Viewport;
            v.Height = Math.Max(1, graphicsControl.Height);
            v.Width = Math.Max(1, graphicsControl.Width);
            // graphicsDevice.Viewport = v;
            camera.Viewport = v;
            UpdateScrollbarsW();
            UpdateScrollbarsH();
        }

        private void graphicsControl_OnDraw(object sender, EventArgs e)
        {
            if (contentManager.RootDirectory != MaterialExplorer.contentBuilder.OutputDirectory)
            {
                contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            }
            // Clear device and draw inactive area
            Global.ClearDevice(graphicsDevice, Microsoft.Xna.Framework.Color.DarkGray);

            if (SelectedMaterial != null)
            {
                // Matrix
                Matrix m = camera.ViewTransformationMatrix();
                try
                {
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);
                    DrawSprite();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex, "s60x001");
                }
                finally
                {
                    spriteBatch.End();
                }
            }

        }
        /// <summary>
        ///  Draw Sprites With Selection
        /// </summary>
        private void DrawSprite()
        {
            if (material != null)
            {
                switch (material.DataType)
                {
                    case MaterialDataType.Image:
                        Texture2D tex = GetTexture(material);

                        if (tex != null)
                        {
                            spriteBatch.Draw(
                                tex,
                                Vector2.Zero,
                                Color.White
                                );

                        }
                        break;
                    case MaterialDataType.Video:

                        break;
                    case MaterialDataType.Bitmap_Font:
                        SpriteFont font = Loader.SpriteFont(contentManager, material.ID);
                        if (font != null)
                        {
                            try
                            {
                                if (font.Characters.Count > 94)
                                {
                                    spriteBatch.DrawString(font, "The quick brown fox jumped over the LAZY camel.", Vector2.Zero, Color.Black);
                                }
                                else
                                {
                                    System.Collections.ObjectModel.ReadOnlyCollection<char> chars = font.Characters;
                                    string _text = "";

                                    foreach (char c in chars)
                                        _text += c.ToString();
                                    spriteBatch.DrawString(font, _text, Vector2.Zero, Color.Black);
                                }
                            }
                            catch
                            {
                            }

                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Draw Rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="borderColor"></param>
        /// <param name="priority"></param>
        private void DrawRectangle(System.Drawing.RectangleF rectangle, Color borderColor, float priority)
        {
            // Top Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y), borderColor, priority);
            // Right Side
            DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, priority);
            // Bottom Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y + rectangle.Height), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, priority);
            // Left Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X, rectangle.Y + rectangle.Height), borderColor, priority);
        }
        private void DrawRectangle(System.Drawing.RectangleF rectangle, Color borderColor, float priority, float rotation)
        {
            Vector2 center;
            Vector2 p1;
            Vector2 p2;
            // Top Side
            center = new Vector2(rectangle.X, rectangle.Y);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), rotation);
            DrawLine(center, p2, borderColor, priority);
            // Right Side
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), rotation);
            DrawLine(p1, p2, borderColor, priority);
            // Bottom Side
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y + rectangle.Height), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), rotation);
            DrawLine(p1, p2, borderColor, priority);
            // Left Side
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y + rectangle.Height), rotation);
            DrawLine(center, p2, borderColor, priority);
        }
        /// <summary>
        /// Draw Line
        /// </summary>
        /// <param name="PointA"></param>
        /// <param name="PointB"></param>
        /// <param name="color"></param>
        /// <param name="priority"></param>
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
        private void DrawLine(Vector2 PointA, Vector2 PointB, Color color, float priority, float rotation)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, 1), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }
        /// <summary>
        /// Fill Rect
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="borderColor"></param>
        /// <param name="fillColor"></param>
        /// <param name="priority"></param>
        private void FillRectangle(System.Drawing.RectangleF rectangle, Color borderColor, Color fillColor, float priority)
        {
            float x = rectangle.X;
            float y = rectangle.Y;
            float height = rectangle.Height;
            float width = rectangle.Width;

            if (rectangle.Width < 0)
            {
                x = rectangle.X + rectangle.Width;
                width = Math.Abs(rectangle.Width);
            }
            if (rectangle.Height < 0)
            {
                y = rectangle.Y + rectangle.Height;
                height = Math.Abs(rectangle.Height);
            }

            spriteBatch.Draw(pixelTexture, new Rectangle((int)x + 1, (int)y + 1, (int)width - 2, (int)height - 2), null, fillColor, 0f, Vector2.Zero, 0, priority);

            DrawRectangle(rectangle, borderColor, priority - 0.05f);
        }

        private Texture2D GetTexture(MaterialData sprite)
        {
            return Loader.Texture2D(contentManager, sprite.ID);
        }
        /// <summary>
        /// Helpers
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        private float DegreesToRadian(float degrees)
        {
            return MathHelper.ToRadians(degrees);
        }
        #endregion


        internal void EnableControls()
        {
            toolStrip.Enabled = toolStrip.Visible = true;
        }

        internal void ResetContentManager()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
        }

        internal void Unload()
        {
            contentManager.Unload();
        }
    }
}
