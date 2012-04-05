//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
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
using EGMGame.Docking.Editors;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace EGMGame.Controls
{
    public partial class AutoTileViewer : UserControl
    {
        #region Private Variables
        // Content variables
        ContentManager contentManager;
        // Render variables
        GraphicsDevice graphicsDevice;
        // Drawing variables
        SpriteBatch spriteBatch;
        Texture2D pixelTexture;
        // Camera
        XNA2dCamera camera;

        // Grid variables
        int gridWidth = 32;
        int gridHeight = 32;

        // Selection variables
        bool IsMouseDown;
        Vector2 originalMouse;
        Vector2 currentMouse;
        bool ctrl = false;
        bool isMiddleDown;
        int oldScrollY = 0;
        int oldScrollX = 0;

        System.Drawing.Point mousePoint = new System.Drawing.Point(0, 0);
        System.Drawing.Point lastMousePos = new System.Drawing.Point(0, 0);
        // Image/Camera Variables
        float zoomLevel = 1.0f;

        // Tile lists
        public AutoTileData selectedTile;
        #endregion

        #region Properties
        public TilesetData SelectedTileset
        {
            get { return selectedTileset; }
            set { selectedTileset = value; Setup(); }
        }
        TilesetData selectedTileset;
        public Texture2D Tileset
        {
            get { return GetTexture(SelectedTileset); }
        }
        public int GridWidth
        {
            get { return gridWidth; }
            set { gridWidth = value; UpdateTiles(); }
        }
        public int GridHeight
        {
            get { return gridHeight; }
            set { gridHeight = value; UpdateTiles(); }
        }


        public Vector2 Grid
        {
            set
            {
                gridWidth = (int)value.X;
                gridHeight = (int)value.Y;
                UpdateTiles();
            }
        }

        public EventHandler TilePickedEvent;
        #endregion

        public AutoTileViewer()
        {
            InitializeComponent();

            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

            // GUI Initialization
            toolStrip.Renderer = new ImpactUI.ImpactToolstripRenderer();

            // Application Event Hooking 
            Application.Idle += delegate { graphicsControl.Invalidate(); };
            this.Resize += delegate { graphicsControl.Invalidate(); };
            // Scroller
            //bgScroller.RunWorkerAsync();
        }

        public void Setup()
        {
            if (selectedTileset != null && graphicsDevice != null)
            {
                gridHeight = (int)selectedTileset.Grid.Y;
                gridWidth = (int)selectedTileset.Grid.X;
                Viewport v = graphicsDevice.Viewport;
                v.Height = Math.Max(1, graphicsControl.Height);
                v.Width = Math.Max(1, graphicsControl.Width);
                //graphicsDevice.Viewport = v;
                camera.Viewport = v;
                Texture2D tex = GetTexture(selectedTileset);
                if (tex != null)
                {
                    selectedTileset.Columns = tex.Width / gridWidth;
                    selectedTileset.Rows = tex.Height / gridHeight;
                    if (Parent is ImpactUI.ImpactGroupBox && Parent.Parent is TilesetEditor)
                    {
                        ((TilesetEditor)Parent.Parent).rowBox.Maximum = tex.Height;
                        ((TilesetEditor)Parent.Parent).colBox.Maximum = tex.Width;
                    }
                    camera.ViewingWidth = tex.Width;
                    camera.ViewingHeight = tex.Height;
                    UpdateScrollbarsH();
                    UpdateScrollbarsW();
                }
                if (selectedTileset.Tiles.Count > 0)
                {
                    Vector2 pos = Vector2.Zero;

                }
            }
            else if (camera != null)
            {
                camera.ViewingHeight = camera.ViewingWidth = 0;
                UpdateScrollbarsH();
                UpdateScrollbarsW();
            }
        }

        private void UpdateTiles()
        {
            if (selectedTileset != null)
            {
                selectedTileset.Grid = new Vector2((float)gridWidth, (float)gridHeight);
                Texture2D tex = GetTexture(selectedTileset);
                if (tex != null)
                {
                    selectedTileset.Columns = tex.Width / gridWidth;
                    selectedTileset.Rows = tex.Height / gridHeight;
                }
            }
        }

        #region Mouse Events
        private void graphicsControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();

            #region Scroll/Move
            mousePoint = e.Location;
            isMiddleDown = (e.Button == MouseButtons.Middle);
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            originalMouse.X = point.X;
            originalMouse.Y = point.Y;
            lastMousePos = e.Location;
            /// Mouse down and move
            if (ctrl && e.Button == MouseButtons.Left)
            {
                IsMouseDown = true;
                this.Cursor = Cursors.NoMove2D;
                return;
            }
            if (isMiddleDown)
            {
                this.Cursor = Cursors.NoMove2D;
                return;
            }
            #endregion

            this.Cursor = this.DefaultCursor;
            if (SelectedTileset != null && e.Button == MouseButtons.Left)
            {
                MainForm.tilesExplorer.tileViewer.selectedTiles.Clear();
                // Divide Point by width and height
                int x = 0, y = 0;
                for (int i = 0; i < selectedTileset.Autotiles.Count; i++)
                {
                    if (x == 4)
                    {
                        x = 0;
                        y++;
                    }
                    // Draw tile texture
                    Vector2 pos = new Vector2(x * gridWidth, y * gridHeight);
                    Vector2 gridPos = Vector2.Zero;
                    gridPos.X = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                    gridPos.Y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;

                    if (pos == gridPos)
                    {
                        selectedTile = selectedTileset.Autotiles[i];
                        MainForm.tilesExplorer.tileViewer.selectedTiles.Clear();
                        break;
                    }
                    x++;
                }
            }

        }
        /// <summary>
        /// Get Tile From Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private TileData GetTile(Vector2 pos)
        {
            Texture2D tex = GetTexture(selectedTileset);
            if (tex != null)
            {
                int index = (int)(pos.X / gridWidth) * selectedTileset.Rows + (int)(pos.Y / gridHeight);

                if (index > -1 && index < selectedTileset.Tiles.Count)
                    return selectedTileset.Tiles[index];
                return null;
            }
            return null;
        }

        private void graphicsControl_MouseMove(object sender, MouseEventArgs e)
        {
            #region Move Mouse + Scroll
            // Is mousedown and ctrl is pressed, scroll the map.
            if (IsMouseDown && ctrl)
            {
                this.Cursor = Cursors.NoMove2D;
                // Get differences
                Vector2 diff = new Vector2(0, 0);
                if (lastMousePos.X > e.Location.X)
                    diff.X = -(lastMousePos.X - e.Location.X);
                else if (lastMousePos.X < e.Location.X)
                    diff.X = (e.Location.X - lastMousePos.X);
                if (lastMousePos.Y > e.Location.Y)
                    diff.Y = -(lastMousePos.Y - e.Location.Y);
                else if (lastMousePos.Y < e.Location.Y)
                    diff.Y = e.Location.Y - lastMousePos.Y;
                // Scroll
                diff *= 2;
                int newVM = vScrollBar.Value + (int)diff.Y;
                if (!vScrollBar.Enabled) newVM = 0;
                newVM = (int)Math.Max(newVM, vScrollBar.Minimum);
                newVM = (int)Math.Min(newVM, vScrollBar.Maximum);
                //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newVM, ScrollOrientation.VerticalScroll));
                vScrollBar.Value = newVM;
                int newHM = hScrollBar.Value + (int)diff.X;
                if (!hScrollBar.Enabled) newHM = 0;
                newHM = (int)Math.Max(newHM, hScrollBar.Minimum);
                newHM = (int)Math.Min(newHM, hScrollBar.Maximum);
                ////hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newHM, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = newHM;
            }
            lastMousePos = e.Location;

            if (!isMiddleDown && (!ctrl && !IsMouseDown))
            {
                this.Cursor = this.DefaultCursor;
            }
            #endregion
        }

        private void graphicsControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                IsMouseDown = false;
                originalMouse.X = 0;
                originalMouse.Y = 0;
                currentMouse.X = 0;
                currentMouse.Y = 0;
                IsMouseDown = false;
            }
            isMiddleDown = false;
            this.Cursor = this.DefaultCursor;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (!ctrl)
            {
                if (vScrollBar.Enabled)
                {
                    int newV = vScrollBar.Value;
                    if (e.Delta > 0)
                        newV = vScrollBar.Value - vScrollBar.LargeChange;
                    else if (e.Delta < 0)
                        newV = vScrollBar.Value + vScrollBar.LargeChange;
                    newV = (int)Math.Max(newV, vScrollBar.Minimum);
                    newV = (int)Math.Min(newV, vScrollBar.Maximum);
                    //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newV, ScrollOrientation.VerticalScroll));
                    vScrollBar.Value = newV;
                }
            }
            else
            {
                if (e.Delta > 0)
                    Zoom(25, false);
                else if (e.Delta < 0)
                    Zoom(-25, false);
            }
        }

        internal void graphicsControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control) ctrl = true;
        }

        internal void graphicsControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) ctrl = false;

        }
        /// <summary>
        /// Focus when the mouse enters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicsControl_MouseEnter(object sender, EventArgs e)
        {
            //SendClick(new System.Drawing.Point(0,0));
            //this.Focus();
        }

        /// <summary>
        /// Scroll if the middle mouse is down
        /// </summary>
        /// <param name="sender"></param>
        /// <param na me="e"></param>
        private void bgScroller_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (!bgScroller.CancellationPending)
            //{
            //    System.Threading.Thread.Sleep(10);
            // Scroll map if middle mouse is clicked
            if (isMiddleDown)
            {
                // Get differences
                Vector2 diff = new Vector2(0, 0);
                if (mousePoint.X > lastMousePos.X && !ExMath.Between(mousePoint.X, lastMousePos.X - 16, lastMousePos.X + 16))
                    diff.X = -(mousePoint.X - lastMousePos.X) / 10;
                else if (mousePoint.X < lastMousePos.X && !ExMath.Between(mousePoint.X, lastMousePos.X - 16, lastMousePos.X + 16))
                    diff.X = (lastMousePos.X - mousePoint.X) / 10;
                if (mousePoint.Y > lastMousePos.Y && !ExMath.Between(mousePoint.Y, lastMousePos.Y - 16, lastMousePos.Y + 16))
                    diff.Y = -(mousePoint.Y - lastMousePos.Y) / 10;
                else if (mousePoint.Y < lastMousePos.Y && !ExMath.Between(mousePoint.Y, lastMousePos.Y - 16, lastMousePos.Y + 16))
                    diff.Y = (lastMousePos.Y - mousePoint.Y) / 10;

                if (diff.X < 0 && diff.Y < 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanNW;
                }
                else if (diff.X < 0 && diff.Y > 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanSW;
                }
                else if (diff.X > 0 && diff.Y < 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanNE;
                }
                else if (diff.X > 0 && diff.Y > 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanSE;
                }
                else if (diff.X > 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanEast;
                }
                else if (diff.Y > 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanSouth;
                }
                else if (diff.X < 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanWest;
                }
                else if (diff.Y < 0)
                {
                    this.graphicsControl.Cursor = Cursors.PanNorth;
                }
                else
                {
                    this.graphicsControl.Cursor = Cursors.NoMove2D;
                }
                // Scroll
                int newV = vScrollBar.Value + (int)diff.Y;
                if (!vScrollBar.Enabled) newV = 0;
                newV = (int)Math.Max(newV, vScrollBar.Minimum);
                newV = (int)Math.Min(newV, vScrollBar.Maximum);
                //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newV, ScrollOrientation.VerticalScroll));
                vScrollBar.Value = newV;
                int newH = hScrollBar.Value + (int)diff.X;
                if (!hScrollBar.Enabled) newH = 0;
                newH = (int)Math.Max(newH, hScrollBar.Minimum);
                newH = (int)Math.Min(newH, hScrollBar.Maximum);
                ////hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newH, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = newH;
            }
            //}
        }
        #endregion

        #region Scrollbars
        private void vScrollBar_Scroll(object sender, EventArgs e)
        {
            Vector2 p = camera.Position;
            p.Y = vScrollBar.Value + (camera.ScreenPosition.Y / zoomLevel);
            camera.Position = p;
            graphicsControl.Invalidate();
        }
        private void hScrollBar_Scroll(object sender, EventArgs e)
        {
            Vector2 p = camera.Position;
            p.X = hScrollBar.Value + (camera.ScreenPosition.X / zoomLevel);
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

        internal void Zoom(int percent, bool exact)
        {

            oldScrollX = hScrollBar.Value;
            oldScrollY = vScrollBar.Value;
            hScrollBar.Value = hScrollBar.Minimum;
            vScrollBar.Value = vScrollBar.Minimum;

            if (exact)
            {
                zoomLevel = (float)percent / 100;
            }
            else
            {
                if (zoomLevel * 100 + percent >= Math.Abs(percent))
                    zoomLevel += (float)percent / 100;
            }
            zoomLevel = (float)Math.Min(3, zoomLevel);
            zoomLevel = (float)Math.Max(0.25, zoomLevel);
            graphicsControl.Invalidate();

            string text;
            if ((zoomLevel * 100) < 100)
                text = "0" + (zoomLevel * 100).ToString() + "%";
            else
                text = (zoomLevel * 100).ToString() + "%";
            if (camera != null)
                camera.Zoom = new Vector2(zoomLevel, zoomLevel);
            lblZoom.Text = text;
            UpdateScrollbarsH();
            UpdateScrollbarsW();

            Global.Project.TilesetZoom = zoomLevel;
        }


        private void graphicsControl_Resize(object sender, EventArgs e)
        {
            if (SelectedTileset != null)
            {
                oldScrollX = hScrollBar.Value;
                oldScrollY = vScrollBar.Value;
                if (graphicsDevice != null)
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
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update Scrollbars
        /// </summary>
        private void UpdateScrollbarsH()
        {

            if (camera != null)
            {
                Vector2 p = camera.Position;
                p.Y = camera.ScreenPosition.Y / zoomLevel;
                camera.Position = p;
                if (camera.ViewingHeight > camera.Viewport.Height / zoomLevel)
                {
                    vScrollBar.Maximum = (int)(camera.ViewingHeight - camera.Viewport.Height / zoomLevel) + gridHeight;
                    vScrollBar.Value = vScrollBar.Minimum;
                    vScrollBar.Enabled = true;
                    vScrollBar.LargeChange = gridHeight;
                    vScrollBar.SmallChange = gridHeight;
                    //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeIncrement, 0, Math.Min(oldScrollY, vScrollBar.Maximum), ScrollOrientation.VerticalScroll));
                    vScrollBar.Value = Math.Min(oldScrollY, vScrollBar.Maximum);
                    oldScrollY = vScrollBar.Value;
                }
                else
                {
                    vScrollBar.Enabled = false;
                }
            }
        }
        /// <summary>
        /// Update Scrollbars
        /// </summary>
        private void UpdateScrollbarsW()
        {
            if (camera != null)
            {
                Vector2 p = camera.Position;
                p.X = camera.ScreenPosition.X / zoomLevel;
                camera.Position = p;
                if (camera.ViewingWidth > camera.Viewport.Width / zoomLevel)
                {
                    hScrollBar.Maximum = (int)(camera.ViewingWidth - camera.Viewport.Width / zoomLevel) + gridWidth;
                    hScrollBar.Value = hScrollBar.Minimum;
                    hScrollBar.Enabled = true;
                    hScrollBar.LargeChange = gridWidth;
                    hScrollBar.SmallChange = gridWidth;
                    ////hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeIncrement, 0, Math.Min(oldScrollX, hScrollBar.Maximum), ScrollOrientation.HorizontalScroll));
                    hScrollBar.Value = Math.Min(oldScrollX, hScrollBar.Maximum);
                    oldScrollX = hScrollBar.Value;
                }
                else
                {
                    hScrollBar.Enabled = false;
                }
            }
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
            pixelTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.pixel, System.Drawing.Imaging.ImageFormat.Png);
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
            if (SelectedTileset != null)
            {
                Texture2D tex = GetTexture(SelectedTileset);

                if (tex != null)
                {
                    camera.ViewingHeight = tex.Height;
                    camera.ViewingWidth = tex.Width;
                    UpdateScrollbarsH();
                    UpdateScrollbarsW();
                }
            }
        }

        private void graphicsControl_OnDraw(object sender, EventArgs e)
        {
            bgScroller_DoWork(null, null);
            if (contentManager.RootDirectory != MaterialExplorer.contentBuilder.OutputDirectory)
            {
                contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            }
            // Clear device and draw inactive areatry
            Global.ClearDevice(graphicsDevice, Microsoft.Xna.Framework.Color.DarkGray);



            if (SelectedTileset != null)
            {
                // Matrix
                Matrix m = camera.ViewTransformationMatrix();
                try
                {
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);
                    DrawTileset();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex, "s57x001");
                }
                finally
                {
                    spriteBatch.End();
                }

                try
                {
                    //m = camera.ViewTransformationMatrixNoZoom();
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);
                    DrawGrid();
                    DrawSelected();
                    // Draw Middle Mouse Move
                    if (isMiddleDown)
                    {
                        // Draw 4 dir
                        Texture2D dir = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.fourDCursor, ImageFormat.Png);
                        Vector2 point = camera.GetTransformedPointNoZoom(new Vector2(mousePoint.X, mousePoint.Y));
                        spriteBatch.Draw(dir, new Rectangle((int)point.X, (int)point.Y, 22, 22), Color.Black);
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex, "s57x002");
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
        private void DrawTileset()
        {
            TilesetData tileset = SelectedTileset;
            Texture2D tex = GetTexture(tileset);
            TileData tile;
            int index;
            if (tex != null)
            {
                int x = 0, y = 0;
                for (int i = 0; i < selectedTileset.Autotiles.Count; i++)
                {
                    if (x == 4)
                    {
                        x = 0;
                        y++;
                    }
                    index = selectedTileset.Autotiles[i].TileIndex[0];
                    if (index > -1 && index < selectedTileset.Tiles.Count)
                    {
                        tile = selectedTileset.Tiles[index];
                        // Draw tile texture
                        spriteBatch.Draw(tex,
                            new Vector2(x * gridWidth, y * gridHeight),
                            new Rectangle((int)tile.DisplayRect.X, (int)tile.DisplayRect.Y, (int)tile.Width, (int)tile.Height), Color.White);

                        if (selectedTile == selectedTileset.Autotiles[i])
                        {
                            FillRectangle(
                                new System.Drawing.RectangleF(
                                    x * gridWidth, y * gridHeight,
                                    tile.Width,
                                    tile.Height + 1
                                    ),
                                    new Color(255, 0, 255, 50), new Color(255, 0, 255, 50), 0.1f);

                            DrawRectangle(new System.Drawing.RectangleF(
                                    x * gridWidth + 1, y * gridHeight + 1,
                                    tile.Width - 1,
                                    tile.Height - 1
                                    ), Color.White, 3, 1);
                        }
                    }
                    x++;
                }
                if (camera.ViewingHeight != y * gridHeight)
                {
                    camera.ViewingHeight = y * gridHeight;
                    UpdateScrollbarsH();
                }
                if (camera.ViewingWidth != 4 * gridWidth)
                {
                    camera.ViewingWidth = 4 * gridWidth;
                    UpdateScrollbarsW();
                }
            }
        }
        /// <summary>
        /// Draw Selected Sprite
        /// </summary>
        /// <param name="TilesetData"></param>
        private void DrawSelected()
        {

        }
        /// <summary>
        /// Draw Grid
        /// </summary>
        private void DrawGrid()
        {
            Texture2D tex = GetTexture(SelectedTileset);
            if (tex != null)
            {
                for (int x = 0; (x <= selectedTileset.Autotiles.Count * gridWidth && x <= 4 * gridWidth); x += (int)(gridWidth))// * zoomLevel))
                {
                    // Horizontal
                    if (x == 0)
                    {
                        DrawLine(new Vector2(1, 0), new Vector2(1, tex.Height), new Color(0, 0, 0, 100), 3, 0);
                    }
                    else
                    {
                        DrawLine(new Vector2(x, 0), new Vector2(x, tex.Height), new Color(0, 0, 0, 100), 3, 0);
                    }
                }
                // Vertical
                for (int y = 0; y <= selectedTileset.Autotiles.Count * gridWidth / 4; y += (int)(gridHeight))// * zoomLevel))
                {
                    if (y == tex.Height)
                    {
                        DrawLine(new Vector2(0, y), new Vector2(tex.Width, y - 1), new Color(0, 0, 0, 100), 3, 0);
                    }
                    else
                    {
                        DrawLine(new Vector2(0, y), new Vector2(tex.Width, y), new Color(0, 0, 0, 100), 3, 0);
                    }
                }
            }
        }
        /// <summary>
        /// Draw Rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="borderColor"></param>
        /// <param name="priority"></param>
        private void DrawRectangle(System.Drawing.RectangleF rectangle, Color borderColor, int scale, float priority)
        {
            // Top Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y), borderColor, scale, priority);
            // Right Side
            DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, scale, priority);
            // Bottom Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y + rectangle.Height), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, scale, priority);
            // Left Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X, rectangle.Y + rectangle.Height), borderColor, scale, priority);
        }
        private void DrawRectangle(System.Drawing.RectangleF rectangle, Color borderColor, int scale, float priority, float rotation)
        {
            Vector2 center;
            Vector2 p1;
            Vector2 p2;
            // Top Side
            center = new Vector2(rectangle.X, rectangle.Y);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), rotation);
            DrawLine(center, p2, borderColor, scale, priority);
            // Right Side
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), rotation);
            DrawLine(p1, p2, borderColor, scale, priority);
            // Bottom Side
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y + rectangle.Height), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), rotation);
            DrawLine(p1, p2, borderColor, scale, priority);
            // Left Side
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y + rectangle.Height), rotation);
            DrawLine(center, p2, borderColor, scale, priority);
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

            if (PointA.Y > PointB.Y)
                rotation = -(float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));
            else
                rotation = (float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, scale), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }
        private void DrawLine(Vector2 PointA, Vector2 PointB, Color color, int scale, float priority, float rotation)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, scale), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
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

            DrawRectangle(new System.Drawing.RectangleF(x + 1, y + 1, width - 2, height - 2), borderColor, 1, priority - 0.05f);
        }
        /// <summary>
        /// Fill Rect
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="borderColor"></param>
        /// <param name="fillColor"></param>
        /// <param name="priority"></param>
        private void FillRectangle(System.Drawing.RectangleF rectangle, Color borderColor, Color fillColor, float priority, bool border)
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
            if (border)
                DrawRectangle(new System.Drawing.RectangleF(x + 1, y + 1, width - 2, height - 2), borderColor, 1, priority - 0.05f);
        }

        private Texture2D GetTexture(TilesetData sprite)
        {
            try
            {
                if (sprite.MaterialId > -1 && Global.GetData<MaterialData>(sprite.MaterialId, GameData.Materials) != null)
                {
                    return Loader.Texture2D(contentManager, sprite.MaterialId);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
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

        #region Helper Methods
        private TilesetData Sprite(IGameData data)
        {
            return (TilesetData)data;
        }
        #endregion


        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        private static extern void mouse_event(
            UInt32 dwFlags, // motion and click options
            UInt32 dx, // horizontal position or change
            UInt32 dy, // vertical position or change
            UInt32 dwData, // wheel movement
            IntPtr dwExtraInfo // application-defined information
            );

        public static void SendClick(System.Drawing.Point location)
        {
            Cursor.Position = location;
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new System.IntPtr());
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new System.IntPtr());
        }


        internal void ResetContentManager()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
        }

    }
}
