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
using FarseerPhysics.Collisions;
using FarseerPhysics.Common;

namespace EGMGame.Controls
{
    public partial class TilesetViewer : UserControl
    {
        #region Variables
        // Content variables
        internal ContentManager contentManager;
        // Render variables
        GraphicsDevice graphicsDevice;
        // Drawing variables
        SpriteBatch tileBatch;
        Texture2D pixelTexture;
        Texture2D anchorTexture;
        // Camera
        XNA2dCamera camera;

        // Grid variables
        int gridWidth = 32;
        int gridHeight = 32;

        // Selection variables
        bool IsMouseDown;
        Vector2 originalMouse;
        Vector2 currentMouse;
        bool ctrl1 = false;
        bool ctrl2 = false;
        bool shift = false;
        bool isMiddleDown;
        int oldScrollY = 0;
        int oldScrollX = 0;

        bool snapToW = false;
        bool snapToH = false;

        System.Drawing.Point mousePoint = new System.Drawing.Point(0, 0);
        System.Drawing.Point lastMousePos = new System.Drawing.Point(0, 0);

        // Image/Camera Variables
        float zoomLevel = 1.0f;

        // Tile lists
        public List<TileData> selectedTiles = new List<TileData>();

        public String Tip
        {
            get { return tipLabel.Text; }
            set { tipLabel.Text = value; }
        }

        // Physics
        bool addingPhysics = false;
        bool addingNode = false;
        PhysicsType physicsType = PhysicsType.Node;
        List<int> selectedNodeIndexes = new List<int>();
        int selectedNodeIndex = -1;
        TileData selectedTile;
        Vertices originalCollisionBody = new Vertices();
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

        bool multiSelect;

        public bool AllowMultiSelect
        {
            get { return allowMultiSelect; }
            set { allowMultiSelect = value; }
        }
        bool allowMultiSelect = true;
        #endregion

        #region Events
        // Event variables
        public delegate void TileSelectedHandler(TileEventArgs e);
        public event TileSelectedHandler TileSelectedEvent;

        protected virtual void OnTileSelected(TileEventArgs e)
        {
            if (TileSelectedEvent != null)
                TileSelectedEvent(e);
        }
        #endregion

        public TilesetViewer()
        {
            InitializeComponent();

            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

            // GUI Initialization
            toolStrip.Renderer = new ImpactUI.ImpactToolstripRenderer();
            toolStrip1.Renderer = new ImpactUI.ImpactToolstripRenderer();

            // Application Event Hooking 
            Application.Idle += delegate { graphicsControl.Invalidate(); };
            this.Resize += delegate { graphicsControl.Invalidate(); };
            // Scroller
            //bgScroller.RunWorkerAsync();
        }

        internal void Setup()
        {
            try
            {
                selectedTiles.Clear();
                if (selectedTileset != null)
                {
                    physicsBtn.Enabled = true;
                    gridHeight = (int)selectedTileset.Grid.Y;
                    gridWidth = (int)selectedTileset.Grid.X;
                    Viewport v = graphicsDevice.Viewport;
                    v.Height = Math.Max(1, graphicsControl.Height);
                    v.Width = Math.Max(1, graphicsControl.Width);
                    // graphicsDevice.Viewport = v;
                    camera.Viewport = v;
                    Texture2D tex = GetTexture(selectedTileset);
                    if (tex != null)
                    {
                        if (Parent is ImpactUI.ImpactGroupBox && Parent.Parent is TilesetEditor)
                        {
                            ((TilesetEditor)Parent.Parent).rowBox.Maximum = tex.Height;
                            ((TilesetEditor)Parent.Parent).colBox.Maximum = tex.Width;
                        }
                        int x = tex.Width / gridWidth;
                        int y = tex.Height / gridHeight;
                        camera.ViewingWidth = tex.Width;
                        camera.ViewingHeight = tex.Height;
                        RefreshTiles();
                        UpdateScrollbarsH();
                        UpdateScrollbarsW();
                    }
                    else
                    {
                        camera.ViewingHeight = camera.ViewingWidth = 0;
                        UpdateScrollbarsH();
                        UpdateScrollbarsW();
                        OnTileSelected(new TileEventArgs(null));
                    }
                }
                else
                {
                    OnTileSelected(new TileEventArgs(null));
                    physicsBtn.Checked = false;
                    physicsBtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "s53x002");
            }
        }

        private void UpdateTiles()
        {
            if (selectedTileset != null)
            {
                if (!MainForm.TilesetHistory[MainForm.tilesetEditor].InUndoRedo)
                    MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new IGameDataChangePropertyHist(selectedTileset, new DataPropertyDelegate(TilesetEdited)));
                selectedTileset.Grid = new Vector2(gridWidth, gridHeight);
                Texture2D tex = GetTexture(selectedTileset);
                if (tex != null)
                {
                    int x = tex.Width / gridWidth;
                    int y = tex.Height / gridHeight;
                    RefreshTiles();
                }
            }
        }

        private void RefreshTiles()
        {
            Texture2D tex = GetTexture(SelectedTileset);
            if (tex != null)
            {
                List<TileData> tiles = new List<TileData>();
                int i = 0;
                for (int x = 0; x < tex.Width / gridWidth; x++)
                {
                    for (int y = 0; y < tex.Height / gridHeight; y++)
                    {
                        TileData tile = null;
                        if (i < selectedTileset.Tiles.Count)
                            tile = selectedTileset.Tiles[i];
                        if (tile != null)
                        {
                            tile.TilesetID = selectedTileset.ID;
                            tile.DisplayRect = new Rectangle(x * gridWidth, y * gridHeight, gridWidth, gridHeight);
                            tile.Width = gridWidth;
                            tile.Height = gridHeight;
                            tile.SetRectangle();
                            tile.Opacity = 255;
                            tiles.Add(tile);
                        }
                        else
                        {
                            tile = new TileData();
                            tile.TilesetID = selectedTileset.ID;
                            tile.Position = Vector2.Zero;
                            tile.DisplayRect = new Rectangle(x * gridWidth, y * gridHeight, gridWidth, gridHeight);
                            tile.Width = gridWidth;
                            tile.Height = gridHeight;
                            tile.IsSensor = true;
                            tile.IsStatic = true;
                            tile.Animation = new List<int[]>();
                            tile.Scale = new Vector2(1, 1);
                            tile.Body = new Vertices();
                            tile.SetRectangle();
                            tile.Opacity = 255;
                            tiles.Add(tile);
                        }
                        i++;
                    }
                }
                selectedTileset.Tiles = new List<TileData>(tiles);
                selectedTiles.Clear();
                if (selectedTileset.Tiles.Count > 0 && !selectedTiles.Contains(selectedTileset.Tiles[0]))
                    selectedTiles.Add(selectedTileset.Tiles[0]);

                OnTileSelected(new TileEventArgs(selectedTiles));
            }
            else
                OnTileSelected(new TileEventArgs(null));
        }

        #region Mouse Events
        private void graphicsControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
            mousePoint = e.Location;
            isMiddleDown = (e.Button == MouseButtons.Middle);
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            originalMouse.X = point.X;
            originalMouse.Y = point.Y;
            lastMousePos = e.Location;
            txtErrors.Text = "No Error";
            /// Mouse down and move
            if (ctrl1 && e.Button == MouseButtons.Left)
            {
                IsMouseDown = true;
                this.graphicsControl.Cursor = Cursors.NoMove2D;
                return;
            }
            if (isMiddleDown)
            {
                this.graphicsControl.Cursor = Cursors.NoMove2D;
                return;
            }

            this.graphicsControl.Cursor = this.DefaultCursor;

            if (SelectedTileset != null)// && e.Button == MouseButtons.Left)
            {
                if (physicsBtn.Checked && e.Button == MouseButtons.Left)
                {
                    if (!addingPhysics)
                    {
                        if (shift)
                            addingNode = true;
                        Vector2 position = new Vector2();
                        foreach (TileData tile in selectedTiles)
                        {
                            Vector2 pos = new Vector2();
                            Rectangle rect = new Rectangle(0, 0, 8, 8);
                            Point p = new Point((int)point.X, (int)point.Y);
                            Vector2 offset = new Vector2();
                            offset.X = -4;
                            offset.Y = -4;
                            for (int i = 0; i < tile.Body.Count; i++)
                            {
                                position.X = tile.DisplayRect.X;
                                position.Y = tile.DisplayRect.Y;
                                pos = tile.Body[i] + position + offset;
                                rect.X = (int)pos.X;
                                rect.Y = (int)pos.Y;
                                if (rect.Contains(p) && !selectedNodeIndexes.Contains(i))
                                {
                                    if (!ctrl2)
                                        selectedNodeIndexes.Clear();
                                    selectedNodeIndexes.Add(i);
                                    selectedNodeIndex = i;
                                    selectedTile = tile;
                                    originalCollisionBody = new Vertices(selectedTile.Body);
                                    IsMouseDown = true;
                                    return;
                                }
                                else if (rect.Contains(p) && selectedNodeIndexes.Contains(i))
                                {
                                    selectedNodeIndex = i;
                                    selectedTile = tile;
                                    originalCollisionBody = new Vertices(selectedTile.Body);
                                    IsMouseDown = true;
                                    return;
                                }
                            }
                        }
                        selectedNodeIndexes.Clear();
                    }
                    // If No body is picked, try selecting  a tile
                    // Divide Point by width and height
                    Texture2D tex = GetTexture(SelectedTileset);
                    if (tex != null)
                    {
                        selectedTile = null;
                        System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, tex.Width, tex.Height);
                        if (rect.Contains(point))
                        {
                            originalMouse.X = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                            originalMouse.Y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;

                            if (selectedTiles.Count > 0 && addingPhysics)
                            {
                                for (int j = 0; j < selectedTiles.Count; j++)
                                {
                                    Vector2 tilePos = new Vector2(selectedTiles[j].DisplayRect.X, selectedTiles[j].DisplayRect.Y);
                                    if (tilePos == originalMouse)
                                    {
                                        IsMouseDown = true;
                                        return;
                                    }
                                }
                            }

                            if (!IsMouseDown)
                                selectedTiles.Clear();
                            IsMouseDown = true;
                            TileData tile = GetTile(originalMouse);
                            if (!selectedTiles.Contains(tile) && tile != null)
                            {
                                if (selectedTile == null)
                                    selectedTile = tile;
                                selectedTiles.Add(tile);
                                IsMouseDown = true;
                            }
                        }
                    }
                    if (addingPhysics)
                    {
                        OnTileSelected(new TileEventArgs(selectedTiles));
                        IsMouseDown = false; 
                    }
                }
                else
                {
                    // Divide Point by width and height
                    Texture2D tex = GetTexture(SelectedTileset);
                    if (tex != null)
                    {
                        System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, tex.Width, tex.Height);
                        if (rect.Contains(point))
                        {
                            if (!IsMouseDown)
                                selectedTiles.Clear();
                            IsMouseDown = true;
                            originalMouse.X = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                            originalMouse.Y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
                            TileData tile = GetTile(originalMouse);
                            if (!selectedTiles.Contains(tile) && tile != null)
                            {
                                selectedTiles.Add(tile);
                            }
                        }
                    }
                    return;
                }
            }
            if (!addingPhysics && e.Button == MouseButtons.Left)
                multiSelect = true;
        }

        /// <summary>
        /// Get Tile From Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private TileData GetTile(Vector2 pos)
        {
            foreach (TileData tile in selectedTileset.Tiles)
            {
                Vector2 tilePos = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                if (pos == tilePos) return tile;
            }
            return null;
        }

        private void graphicsControl_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            currentMouse.X = point.X;
            currentMouse.Y = point.Y;

            if (IsMouseDown && !ctrl1 && (selectedNodeIndexes.Count == 0 || !physicsBtn.Checked) && allowMultiSelect && !addingPhysics)
            {
                selectedTiles.Clear();

                int selectwidth = (int)(currentMouse.X - originalMouse.X);
                int selectheight = (int)(currentMouse.Y - originalMouse.Y);

                int x = (int)Math.Floor((decimal)(originalMouse.X / gridWidth));
                int y = (int)Math.Floor((decimal)(originalMouse.Y / gridHeight));
                int width = (int)Math.Floor((decimal)(selectwidth / gridWidth));
                int height = (int)Math.Floor((decimal)(selectheight / gridHeight));

                if (selectwidth < 0)
                {
                    x += width - 1;
                    width = Math.Abs(width) + 1;
                }
                if (selectheight < 0)
                {
                    y += height - 1;
                    height = Math.Abs(height) + 1;
                }

                if (SelectedTileset != null)
                {

                    for (int i = x; i <= x + width; i++)
                    {
                        if (i < 0) continue;
                        if (i >= selectedTileset.Tiles.Count) break;
                        for (int z = y; z <= y + height; z++)
                        {
                            if (z < 0) continue;
                            TileData tile = GetTile(new Vector2(i * gridWidth, z * gridHeight));
                            if (tile != null)
                                selectedTiles.Add(tile);
                        }
                    }
                }
            }

            if (IsMouseDown && e.Button != System.Windows.Forms.MouseButtons.Right && selectedTiles.Count > 0 && !ctrl1 && selectedNodeIndexes.Count > 0 && physicsBtn.Checked && !addingPhysics)
            {

                Vector2 pos;
                Vector2 offset = new Vector2();
                Vector2 finalPos = new Vector2();
                Rectangle rect = new Rectangle(0, 0, 8, 8);
                System.Drawing.PointF last = camera.GetTransformedPoint(lastMousePos);
                Point checkPos = new Point();
                Vector2 position = new Vector2();
                Vector2 selNodePos = Vector2.Zero;
                foreach (TileData tile in selectedTiles)
                {
                    if (tile != selectedTile)
                        continue;
                    if (selectedNodeIndex > -1 && selectedNodeIndex < tile.Body.Count)
                        selNodePos = tile.Body[selectedNodeIndex];
                    else
                        selNodePos = Vector2.Zero;
                    for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                    {
                        if (selectedNodeIndexes[nodeIndex] < tile.Body.Count)
                        {
                            position.X = tile.DisplayRect.X;
                            position.Y = tile.DisplayRect.Y;
                            Point p = new Point((int)last.X, (int)last.Y);
                            offset.X = -4;
                            offset.Y = -4;
                            pos = tile.Body[selectedNodeIndexes[nodeIndex]] + position + offset;
                            rect.X = (int)position.X;
                            rect.Y = (int)position.Y;
                            rect.Width = tile.DisplayRect.Width;
                            rect.Height = tile.DisplayRect.Height;
                            offset.X = -4;
                            offset.Y = -4;

                            if (selectedNodeIndex != selectedNodeIndexes[nodeIndex])
                            {
                                offset += selNodePos - tile.Body[selectedNodeIndexes[nodeIndex]];
                                //Console.WriteLine(offset);
                            }

                            //if (rect.Contains(p))
                            //{
                            pos.X = point.X;
                            pos.Y = point.Y;
                            if (!addingNode)
                            {
                                // Move the node
                                if (!snapToH)
                                    finalPos.X = pos.X - position.X - offset.X;
                                else
                                    finalPos.X = tile.Body[selectedNodeIndexes[nodeIndex]].X;

                                if (!snapToW)
                                    finalPos.Y = pos.Y - position.Y - offset.Y;
                                else
                                    finalPos.Y = tile.Body[selectedNodeIndexes[nodeIndex]].Y;
                                checkPos.X = (int)(finalPos.X + position.X + offset.X) + 4;
                                checkPos.Y = (int)(finalPos.Y + position.Y + offset.Y) + 4;
                                if (checkPos.X > rect.X + rect.Width || checkPos.X < rect.X)
                                    finalPos.X = tile.Body[selectedNodeIndexes[nodeIndex]].X;
                                if (checkPos.Y > rect.Y + rect.Height || checkPos.Y < rect.Y)
                                    finalPos.Y = tile.Body[selectedNodeIndexes[nodeIndex]].Y;
                                tile.Body[selectedNodeIndexes[nodeIndex]] = finalPos;
                            }
                            else if (shift)
                            {
                                addingNode = false;
                                // Add and connect to new node
                                selectedNodeIndexes[nodeIndex]++;
                                selectedNodeIndex = selectedNodeIndexes[nodeIndex];
                                tile.Body.Insert(selectedNodeIndexes[nodeIndex], pos - position - offset);

                                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionAddedHist(pos - position - offset, tile.Body, selectedNodeIndexes[nodeIndex]));

                                originalCollisionBody = new Vertices(tile.Body);
                                break;
                            }
                            lastMousePos = e.Location;
                        }
                    }
                }
            }
            #region Move Mouse + Scroll
            // Is mousedown and ctrl is pressed, scroll the map.
            if (IsMouseDown && ctrl1)
            {
                this.graphicsControl.Cursor = Cursors.NoMove2D;
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
                newHM = (int)Math.Min(newHM, hScrollBar.Maximum - gridWidth);
                //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newHM, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = newHM;
            }
            lastMousePos = e.Location;
            if (!isMiddleDown && (!ctrl1 && !IsMouseDown))
            {
                this.graphicsControl.Cursor = this.DefaultCursor;
            }
            #endregion
        }

        private void graphicsControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (addingPhysics && selectedTiles.Count > 0 && e.Button == MouseButtons.Left && IsMouseDown)
            {
                AddPhysics();
                if (!selectedNodeIndexes.Contains(0))
                {
                    selectedNodeIndexes.Add(0);
                    selectedNodeIndex = 0;
                }
            }
            if (multiSelect && selectedTile != null)
            {
                System.Drawing.PointF op = camera.GetTransformedPoint(mousePoint);
                op.X -= (new System.Drawing.PointF(selectedTile.DisplayRect.X, selectedTile.DisplayRect.Y).X);
                op.Y -= (new System.Drawing.PointF(selectedTile.DisplayRect.X, selectedTile.DisplayRect.Y).Y);
                Vector2 cp = currentMouse - (new Vector2(selectedTile.DisplayRect.X, selectedTile.DisplayRect.Y));
                Rectangle mrect = new Rectangle((int)op.X, (int)op.Y, (int)cp.X - (int)op.X, (int)cp.Y - (int)op.Y);
                if (mrect.Width < 0)
                {
                    mrect.X += mrect.Width;
                    mrect.Width = (int)Math.Abs(mrect.Width);
                }
                if (mrect.Height < 0)
                {
                    mrect.Y += mrect.Height;
                    mrect.Height = (int)Math.Abs(mrect.Height);
                }

                Vector2 pos = new Vector2();
                Rectangle rect = new Rectangle(0, 0, 8, 8);
                Vector2 offset = new Vector2();
                offset.X = -4;
                offset.Y = -4;
                for (int i = 0; i < selectedTile.Body.Count; i++)
                {
                    pos = selectedTile.Body[i] + offset;
                    rect.X = (int)pos.X;
                    rect.Y = (int)pos.Y;
                    if (mrect.Intersects(rect) && !selectedNodeIndexes.Contains(i))
                    {
                        selectedNodeIndexes.Add(i);
                        selectedNodeIndex = i;
                        originalCollisionBody = new Vertices(selectedTile.Body);
                    }
                    else if (mrect.Intersects(rect) && selectedNodeIndexes.Contains(i))
                    {
                        selectedNodeIndex = i;
                        originalCollisionBody = new Vertices(selectedTile.Body);
                    }
                }

                multiSelect = false;
            }
            if (IsMouseDown)
            {
                if (selectedTile != null && physicsBtn.Checked)
                {
                    for (int i = 0; i < originalCollisionBody.Count; i++)
                    {
                        if (i < selectedTile.Body.Count && selectedTile.Body[i] != originalCollisionBody[i])
                        {
                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsMovedHist(originalCollisionBody[i], selectedTile.Body[i], selectedTile.Body, i));
                        }
                    }
                }
                originalCollisionBody.Clear();

                IsMouseDown = false;
                originalMouse.X = 0;
                originalMouse.Y = 0;
                currentMouse.X = 0;
                currentMouse.Y = 0;
                addingNode = false;
                OnTileSelected(new TileEventArgs(selectedTiles));
            }
            isMiddleDown = false;
            this.graphicsControl.Cursor = this.DefaultCursor;
            multiSelect = false;
        }

        private void AddPhysics()
        {
            Vertices list2 = new Vertices();
            Vector2 vNew2 = Vector2.Zero;
            foreach (TileData tile in selectedTiles)
            {
                Vector2 pos = currentMouse;
                Vector2 originalMousePos = new Vector2();
                originalMousePos.X = camera.GetTransformedPoint(mousePoint).X;
                originalMousePos.Y = camera.GetTransformedPoint(mousePoint).Y;
                Vector2 offset = new Vector2();
                Vector2 nodePosition = Vector2.Zero;
                offset.X = -4 + tile.Position.X;
                offset.Y = -4 + tile.Position.Y;
                Vector2 diff = originalMousePos - pos;
                switch (physicsType)
                {
                    case PhysicsType.Node:
                        //tile.Body.Clear();
                        offset.X = originalMousePos.X - tile.DisplayRect.X;
                        offset.Y = originalMousePos.Y - tile.DisplayRect.Y;
                        tile.Body.Add(offset);

                        MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionAddedHist(tile.Body[0], tile.Body, 0));
                        break;
                    case PhysicsType.Rect:
                        if (Vector2.Distance(originalMousePos, pos) < 4f)
                        {
                            if (tile.Body.Count > 0)
                            {
                                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsRemovedHist(tile.Body, tile.Body));
                            }
                            tile.Body.Clear();
                            tile.Body.AddRange(Vertices.CreateSimpleRectangle(tile.DisplayRect.Width, tile.DisplayRect.Height));
                            tile.Body.SubDivideEdges(25f);
                            list2 = new Vertices();
                            vNew2 = new Vector2();
                            foreach (Vector2 v in tile.Body)
                            {
                                vNew2 = v + (new Vector2(tile.DisplayRect.Width / 2, tile.DisplayRect.Height / 2));
                                list2.Add(vNew2);
                            }
                            tile.Body.Clear();
                            tile.Body.AddRange(list2);

                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                        }
                        else
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)pos.X - (int)originalMousePos.X, (int)pos.Y - (int)originalMousePos.Y);

                            Rectangle rect = new Rectangle((int)originalMousePos.X, (int)originalMousePos.Y, difference.X, difference.Y);


                            if (rect.Width < 0)
                            {
                                rect.X += rect.Width;
                                rect.Width = (int)Math.Abs(rect.Width);
                            }
                            if (rect.Height < 0)
                            {
                                rect.Y += rect.Height;
                                rect.Height = (int)Math.Abs(rect.Height);
                            }
                            if (rect.X < tile.DisplayRect.X)
                                rect.X = tile.DisplayRect.X;
                            if (rect.X > tile.DisplayRect.X + tile.DisplayRect.Width)
                                rect.X = tile.DisplayRect.X + tile.DisplayRect.Width;
                            if (rect.Y < tile.DisplayRect.Y)
                                rect.Y = tile.DisplayRect.Y;
                            if (rect.Y > tile.DisplayRect.Y + tile.DisplayRect.Height)
                                rect.Y = tile.DisplayRect.Y + tile.DisplayRect.Height;
                            if (rect.Width > tile.DisplayRect.Width - (rect.X - tile.DisplayRect.X))
                                rect.Width = tile.DisplayRect.Width - (rect.X - tile.DisplayRect.X);
                            if (rect.Height > tile.DisplayRect.Height - (rect.Y - tile.DisplayRect.Y))
                                rect.Height = tile.DisplayRect.Height - (rect.Y - tile.DisplayRect.Y);
                            difference.X = rect.Width;
                            difference.Y = rect.Height;
                            originalMousePos.X = rect.X;
                            originalMousePos.Y = rect.Y;

                            EGMGame.Dialogs.CollisionParameterConfirmDialog dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                            dialog.Setup((int)originalMousePos.X - tile.DisplayRect.X, (int)originalMousePos.Y - tile.DisplayRect.Y, difference.X, difference.Y);

                            Vector2 tempOM = originalMousePos;

                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                tempOM.X = (float)dialog.nudX.Value;
                                tempOM.Y = (float)dialog.nudy.Value;
                                difference.X = (int)dialog.nudWidth.Value;
                                difference.Y = (int)dialog.nudHeight.Value;



                                Vertices body = Vertices.CreateSimpleRectangle(Math.Abs(difference.X), Math.Abs(difference.Y));

                                body.SubDivideEdges(25f);

                                list2 = new Vertices();
                                vNew2 = new Vector2();
                                foreach (Vector2 v in body)
                                {
                                    vNew2 = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                                    list2.Add(vNew2);
                                }

                                if (tile.Body.Count > 0)
                                {
                                    PolyUnionError error = new PolyUnionError();
                                    body = Vertices.Union(tile.Body, list2, out error);

                                    switch (error)
                                    {
                                        case PolyUnionError.NoIntersections:
                                            txtErrors.Text = "ERROR: Collisions do not intersect!";
                                            return;
                                        case PolyUnionError.Poly1InsidePoly2:
                                            txtErrors.Text = "Collosion 1 completely inside collision 2.";
                                            return;
                                        case PolyUnionError.InfiniteLoop:
                                            txtErrors.Text = "Infinite Loop detected.";
                                            break;
                                        case PolyUnionError.None:
                                            txtErrors.Text = "";
                                            tile.Body = body;
                                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                                            break;
                                    }
                                }
                                else
                                {
                                    tile.Body.AddRange(list2);
                                    MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                                }
                            }
                            return;
                        }
                        break;
                    case PhysicsType.Circle:
                        if (Vector2.Distance(originalMousePos, pos) < 4f)
                        {
                            if (tile.Body.Count > 0)
                            {
                                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsRemovedHist(tile.Body, tile.Body));
                            }
                            tile.Body.Clear();
                            tile.Body.AddRange(Vertices.CreateEllipse(tile.DisplayRect.Width / 2, tile.DisplayRect.Height / 2, 16));

                            list2 = new Vertices();
                            vNew2 = new Vector2();
                            foreach (Vector2 v in tile.Body)
                            {
                                vNew2 = v + (new Vector2(tile.DisplayRect.Width / 2, tile.DisplayRect.Height / 2));
                                list2.Add(vNew2);
                            }
                            tile.Body.Clear();
                            tile.Body.AddRange(list2);
                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                        }
                        else
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)pos.X - (int)originalMousePos.X, (int)pos.Y - (int)originalMousePos.Y);

                            Rectangle rect = new Rectangle((int)originalMousePos.X, (int)originalMousePos.Y, difference.X, difference.Y);


                            if (rect.Width < 0)
                            {
                                rect.X += rect.Width;
                                rect.Width = (int)Math.Abs(rect.Width);
                            }
                            if (rect.Height < 0)
                            {
                                rect.Y += rect.Height;
                                rect.Height = (int)Math.Abs(rect.Height);
                            }
                            if (rect.X < tile.DisplayRect.X)
                                rect.X = tile.DisplayRect.X;
                            if (rect.X > tile.DisplayRect.X + tile.DisplayRect.Width)
                                rect.X = tile.DisplayRect.X + tile.DisplayRect.Width;
                            if (rect.Y < tile.DisplayRect.Y)
                                rect.Y = tile.DisplayRect.Y;
                            if (rect.Y > tile.DisplayRect.Y + tile.DisplayRect.Height)
                                rect.Y = tile.DisplayRect.Y + tile.DisplayRect.Height;
                            if (rect.Width > tile.DisplayRect.Width - (rect.X - tile.DisplayRect.X))
                                rect.Width = tile.DisplayRect.Width - (rect.X - tile.DisplayRect.X);
                            if (rect.Height > tile.DisplayRect.Height - (rect.Y - tile.DisplayRect.Y))
                                rect.Height = tile.DisplayRect.Height - (rect.Y - tile.DisplayRect.Y);

                            difference.X = rect.Width;
                            difference.Y = rect.Height;
                            originalMousePos.X = rect.X;
                            originalMousePos.Y = rect.Y;
                            EGMGame.Dialogs.CollisionParameterConfirmDialog dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                            dialog.Setup((int)originalMousePos.X - tile.DisplayRect.X, (int)originalMousePos.Y - tile.DisplayRect.Y, difference.X, difference.Y);

                            Vector2 tempOM = originalMousePos;

                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                tempOM.X = (float)dialog.nudX.Value;
                                tempOM.Y = (float)dialog.nudy.Value;
                                difference.X = (int)dialog.nudWidth.Value;
                                difference.Y = (int)dialog.nudHeight.Value;

                                Vertices body = Vertices.CreateEllipse(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2, 16);

                                body.SubDivideEdges(25f);

                                list2 = new Vertices();
                                vNew2 = new Vector2();
                                foreach (Vector2 v in body)
                                {
                                    vNew2 = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                                    list2.Add(vNew2);
                                }

                                if (tile.Body.Count > 0)
                                {
                                    PolyUnionError error = new PolyUnionError();
                                    body = Vertices.Union(tile.Body, list2, out error);

                                    switch (error)
                                    {
                                        case PolyUnionError.NoIntersections:
                                            txtErrors.Text = "ERROR: Collisions do not intersect!";
                                            return;
                                        case PolyUnionError.Poly1InsidePoly2:
                                            txtErrors.Text = "Collosion 1 completely inside collision 2.";
                                            return;
                                        case PolyUnionError.InfiniteLoop:
                                            txtErrors.Text = "Infinite Loop detected.";
                                            break;
                                        case PolyUnionError.None:
                                            txtErrors.Text = "";
                                            tile.Body = body;
                                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                                            break;
                                    }
                                }
                                else
                                {
                                    tile.Body.AddRange(list2);
                                    MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                                }
                            }
                        }
                        break;
                    case PhysicsType.Layout:
                        if (tile.Body.Count > 0)
                        {
                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsRemovedHist(tile.Body, tile.Body));
                        }

                        //Create an array to hold the data from the texture
                        uint[] data = new uint[gridWidth * gridHeight];
                        Texture2D tex = GetTexture(selectedTileset);
                        //Transfer the texture data to the array
                        tex.GetData(0, tile.DisplayRect, data, 0, tile.DisplayRect.Width * tile.DisplayRect.Height);

                        //Calculate the vertices from the array
                        Vertices verts = Vertices.CreatePolygon(data, tile.DisplayRect.Width, tile.DisplayRect.Height);

                        //Make sure that the origin of the texture is the centroid (real center of geometry)
                        Vector2 origin = verts.GetCentroid();
                        pos = new Vector2(-tile.DisplayRect.Width / 2, -tile.DisplayRect.Height / 2);
                        verts.Translate(ref pos);
                        Vertices.Simplify(verts);
                        tile.Body.Clear();
                        tile.Body.AddRange(verts);
                        list2 = new Vertices();
                        vNew2 = new Vector2();
                        foreach (Vector2 v in tile.Body)
                        {
                            vNew2 = v + (new Vector2(gridWidth / 2, gridHeight / 2));
                            list2.Add(vNew2);
                        }
                        tile.Body.Clear();
                        tile.Body.AddRange(list2);
                        MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                        break;
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!ctrl1)
            {
                if (vScrollBar.Enabled)
                {
                    int newV = vScrollBar.Value;
                    if (e.Delta > 0)
                        newV = vScrollBar.Value - gridWidth / 2;
                    else if (e.Delta < 0)
                        newV = vScrollBar.Value + gridHeight / 2;
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
            if (e.Control) ctrl2 = true;
            if (e.Shift) shift = true;
            if (e.KeyCode == Keys.Delete) deleteBtn_Click(null, null);
            if (e.KeyCode == Keys.A) snapToW = true;
            if (e.KeyCode == Keys.S) snapToH = true;
        }

        internal void graphicsControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) ctrl2 = false;
            if (e.KeyCode == Keys.ShiftKey) shift = false;
            if (e.KeyCode == Keys.A) snapToW = false;
            if (e.KeyCode == Keys.S) snapToH = false;
        }

        /// <summary>

        /// <summary>
        /// Scroll if the middle mouse is down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newH, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = newH;
            }
            // }
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
            graphicsControl.Invalidate();
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
            camera.Zoom = new Vector2(zoomLevel, zoomLevel);
            lblZoom.Text = text;
            UpdateScrollbarsH();
            UpdateScrollbarsW();
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
                    //graphicsDevice.Viewport = v;
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
            Vector2 p = camera.Position;
            p.Y = camera.ScreenPosition.Y / zoomLevel;
            camera.Position = p;
            if (camera.ViewingHeight > camera.Viewport.Height / zoomLevel)
            {
                vScrollBar.Maximum = (int)(camera.ViewingHeight - camera.Viewport.Height / zoomLevel);
                vScrollBar.Value = vScrollBar.Minimum;
                vScrollBar.Enabled = true;
                vScrollBar.LargeChange = 1;//gridHeight;
                vScrollBar.SmallChange = 1;// gridHeight;
                //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeIncrement, 0, Math.Min(oldScrollY, vScrollBar.Maximum), ScrollOrientation.VerticalScroll));
                vScrollBar.Value = Math.Min(oldScrollY, vScrollBar.Maximum);
                oldScrollY = vScrollBar.Value;
            }
            else
            {
                vScrollBar.Enabled = false;
            }
        }
        /// <summary>
        /// Update Scrollbars
        /// </summary>
        private void UpdateScrollbarsW()
        {
            Vector2 p = camera.Position;
            p.X = camera.ScreenPosition.X / zoomLevel;
            camera.Position = p;
            if (camera.ViewingWidth > camera.Viewport.Width / zoomLevel)
            {
                hScrollBar.Maximum = (int)(camera.ViewingWidth - camera.Viewport.Width / zoomLevel) + gridWidth;
                hScrollBar.Value = hScrollBar.Minimum;
                hScrollBar.Enabled = true;
                hScrollBar.LargeChange = 1;//gridWidth;
                hScrollBar.SmallChange = 1;//gridWidth;
                //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeIncrement, 0, Math.Min(oldScrollX, hScrollBar.Maximum), ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = Math.Min(oldScrollX, hScrollBar.Maximum);
                oldScrollX = hScrollBar.Value;
            }
            else
            {
                hScrollBar.Enabled = false;
            }
        }
        /// <summary>
        /// Focus when the mouse enters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicsControl_MouseEnter(object sender, EventArgs e)
        {
            //this.Focus();
        }
        #endregion

        #region Graphics
        private void graphicsControl_OnInitialize(object sender, EventArgs e)
        {
            // Initialize the graphics device
            graphicsDevice = graphicsControl.GraphicsDevice;
            camera = new XNA2dCamera(graphicsDevice.Viewport);
            // initialize drawing resources.
            tileBatch = new SpriteBatch(graphicsDevice);
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

            anchorTexture = Loader.TextureFromStream(graphicsControl.GraphicsDevice, global::EGMGame.Properties.Resources.anchor_circle, System.Drawing.Imaging.ImageFormat.Png);

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
            // Clear device and draw inactive area
            Global.ClearDevice(graphicsDevice, Microsoft.Xna.Framework.Color.DarkGray);



            if (SelectedTileset != null)
            {
                // Matrix
                Matrix m = camera.ViewTransformationMatrix();
                try
                {
                    tileBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);
                    Texture2D tex = GetTexture(selectedTileset);
                    if (tex != null)
                    {
                        lblGuide.Visible = false;
                        DrawTileset();
                        DrawGrid();
                        DrawSelected();
                        if (physicsBtn.Checked) DrawPhysics();
                        if (multiSelect)
                        {
                            System.Drawing.PointF op = camera.GetTransformedPoint(mousePoint);
                            Vector2 cp = currentMouse;
                            System.Drawing.RectangleF r = new System.Drawing.RectangleF(op.X, op.Y, cp.X - op.X, cp.Y - op.Y);


                            if (r.Width < 0)
                            {
                                r.X += r.Width;
                                r.Width = (int)Math.Abs(r.Width);
                            }
                            if (r.Height < 0)
                            {
                                r.Y += r.Height;
                                r.Height = (int)Math.Abs(r.Height);
                            }

                            if (r.Width > 2 && r.Height > 2)
                                FillRectangle(r, Color.White, new Color(0, 0, 255, 100), 1);
                        }
                        // Draw Middle Mouse Move
                        if (isMiddleDown)
                        {
                            // Draw 4 dir
                            Texture2D dir = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.fourDCursor, ImageFormat.Png);
                            Vector2 point = camera.GetTransformedPoint(new Vector2(mousePoint.X, mousePoint.Y));
                            tileBatch.Draw(dir, new Rectangle((int)point.X, (int)point.Y, 22, 22), Color.Black);
                        }
                    }
                    else
                    {
                        lblGuide.Visible = true;
                    }

                }
                catch (Exception ex)
                {
                    Error.LogError(ex, "s53x001");
                }
                finally
                {
                    tileBatch.End();
                }
            }

        }
        /// <summary>
        /// Draw Physics
        /// </summary>
        private void DrawPhysics()
        {
            int verticeCount;
            Vector2 offset = new Vector2();
            Vector2 finalPos = new Vector2();
            TileData sp;
            Color lineColor;
            Color nodeColor;
            int j = 0;
            foreach (TileData tile in selectedTileset.Tiles)
            {
                if (tile.Body == null)
                    tile.Body = new Vertices();
                verticeCount = tile.Body.Count;
                for (int i = 0; i < tile.Body.Count; i++)
                {

                    lineColor = Color.Yellow;
                    nodeColor = Color.Yellow;
                    finalPos.X = tile.DisplayRect.X;
                    finalPos.Y = tile.DisplayRect.Y;


                    if (tile.Body[tile.Body.NextIndex(i)].Y == tile.Body[i].Y)
                        lineColor = Color.Red;
                    if (tile.Body[tile.Body.NextIndex(i)].X == tile.Body[i].X)
                        lineColor = Color.Red;

                    if (i < verticeCount - 1)
                    {
                        DrawLine(tile.Body[i + 1] + finalPos, tile.Body[i] + finalPos, lineColor, 1, 0);
                    }
                    else
                    {
                        DrawLine(tile.Body[i] + finalPos, tile.Body[0] + finalPos, lineColor, 1, 0);
                    }
                    offset.X = -4;
                    offset.Y = -4;
                    tileBatch.Draw(
                                      anchorTexture,
                                      finalPos + tile.Body[i] + offset,
                                      nodeColor);
                }
                j++;
            }
            if (selectedTiles.Count > 0 && selectedNodeIndexes.Count > 0)
            {
                for (int ti = 0; ti < selectedTiles.Count; ti++)
                {
                    sp = selectedTiles[ti];
                    for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                    {
                        if (selectedTile != sp)
                            continue;
                        if (selectedNodeIndexes[nodeIndex] < sp.Body.Count)
                        {
                            finalPos.X = sp.DisplayRect.X;
                            finalPos.Y = sp.DisplayRect.Y;
                            offset.X = -4;
                            offset.Y = -4;
                            offset = sp.Body[selectedNodeIndexes[nodeIndex]] + finalPos + offset;
                            DrawRectangle(new System.Drawing.RectangleF(offset.X, offset.Y, 9, 9), Color.Blue, 1, 1);
                        }
                    }
                }
            }

            if (addingPhysics && IsMouseDown)
            {

                Vector2 pos = currentMouse;
                Vector2 originalMousePos = new Vector2();
                originalMousePos.X = camera.GetTransformedPoint(mousePoint).X;
                originalMousePos.Y = camera.GetTransformedPoint(mousePoint).Y;
                switch (physicsType)
                {
                    case PhysicsType.Rect:
                        if (originalMousePos != pos)
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)pos.X - (int)originalMousePos.X, (int)pos.Y - (int)originalMousePos.Y);

                            Rectangle rect = new Rectangle((int)originalMousePos.X, (int)originalMousePos.Y, difference.X, difference.Y);

                            if (rect.Width < 0)
                            {
                                rect.X += rect.Width;
                                rect.Width = (int)Math.Abs(rect.Width);
                            }
                            if (rect.Height < 0)
                            {
                                rect.Y += rect.Height;
                                rect.Height = (int)Math.Abs(rect.Height);
                            }

                            if (rect.X < selectedTiles[0].DisplayRect.X)
                                rect.X = selectedTiles[0].DisplayRect.X;
                            if (rect.X > selectedTiles[0].DisplayRect.X + selectedTiles[0].DisplayRect.Width)
                                rect.X = selectedTiles[0].DisplayRect.X + selectedTiles[0].DisplayRect.Width;
                            if (rect.Y < selectedTiles[0].DisplayRect.Y)
                                rect.Y = selectedTiles[0].DisplayRect.Y;
                            if (rect.Y > selectedTiles[0].DisplayRect.Y + selectedTiles[0].DisplayRect.Height)
                                rect.Y = selectedTiles[0].DisplayRect.Y + selectedTiles[0].DisplayRect.Height;
                            if (rect.Width > selectedTiles[0].DisplayRect.Width - (rect.X - selectedTiles[0].DisplayRect.X))
                                rect.Width = selectedTiles[0].DisplayRect.Width - (rect.X - selectedTiles[0].DisplayRect.X);
                            if (rect.Height > selectedTiles[0].DisplayRect.Height - (rect.Y - selectedTiles[0].DisplayRect.Y))
                                rect.Height = selectedTiles[0].DisplayRect.Height - (rect.Y - selectedTiles[0].DisplayRect.Y);
                            difference.X = rect.Width;
                            difference.Y = rect.Height;
                            originalMousePos.X = rect.X;
                            originalMousePos.Y = rect.Y;

                            Vertices draw = Vertices.CreateSimpleRectangle(Math.Abs(difference.X), Math.Abs(difference.Y));

                            Vertices list = new Vertices();
                            Vector2 vNew = new Vector2();
                            foreach (Vector2 v in draw)
                            {
                                vNew = v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                                list.Add(vNew);
                            }
                            draw = list;

                            verticeCount = draw.Count;
                            for (int i = 0; i < draw.Count; i++)
                            {

                                if (i < verticeCount - 1)
                                {
                                    DrawLine(originalMousePos + draw[i + 1], originalMousePos + draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(originalMousePos + draw[i], originalMousePos + draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                tileBatch.Draw(
                                                  anchorTexture,
                                                  originalMousePos + draw[i] + offset,
                                                  Color.Pink);
                            }
                        }
                        break;
                    case PhysicsType.Circle:
                        if (originalMousePos != pos)
                        {

                            System.Drawing.Point difference = new System.Drawing.Point((int)pos.X - (int)originalMousePos.X, (int)pos.Y - (int)originalMousePos.Y);

                            Rectangle rect = new Rectangle((int)originalMousePos.X, (int)originalMousePos.Y, difference.X, difference.Y);


                            if (rect.Width < 0)
                            {
                                rect.X += rect.Width;
                                rect.Width = (int)Math.Abs(rect.Width);
                            }
                            if (rect.Height < 0)
                            {
                                rect.Y += rect.Height;
                                rect.Height = (int)Math.Abs(rect.Height);
                            }
                            if (rect.X < selectedTiles[0].DisplayRect.X)
                                rect.X = selectedTiles[0].DisplayRect.X;
                            if (rect.X > selectedTiles[0].DisplayRect.X + selectedTiles[0].DisplayRect.Width)
                                rect.X = selectedTiles[0].DisplayRect.X + selectedTiles[0].DisplayRect.Width;
                            if (rect.Y < selectedTiles[0].DisplayRect.Y)
                                rect.Y = selectedTiles[0].DisplayRect.Y;
                            if (rect.Y > selectedTiles[0].DisplayRect.Y + selectedTiles[0].DisplayRect.Height)
                                rect.Y = selectedTiles[0].DisplayRect.Y + selectedTiles[0].DisplayRect.Height;
                            if (rect.Width > selectedTiles[0].DisplayRect.Width - (rect.X - selectedTiles[0].DisplayRect.X))
                                rect.Width = selectedTiles[0].DisplayRect.Width - (rect.X - selectedTiles[0].DisplayRect.X);
                            if (rect.Height > selectedTiles[0].DisplayRect.Height - (rect.Y - selectedTiles[0].DisplayRect.Y))
                                rect.Height = selectedTiles[0].DisplayRect.Height - (rect.Y - selectedTiles[0].DisplayRect.Y);

                            difference.X = rect.Width;
                            difference.Y = rect.Height;
                            originalMousePos.X = rect.X;
                            originalMousePos.Y = rect.Y;

                            Vertices draw = Vertices.CreateEllipse(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2, 8);

                            Vertices list = new Vertices();
                            Vector2 vNew = new Vector2();
                            foreach (Vector2 v in draw)
                            {
                                vNew = v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                                list.Add(vNew);
                            }
                            draw = list;


                            verticeCount = draw.Count;
                            for (int i = 0; i < draw.Count; i++)
                            {

                                if (i < verticeCount - 1)
                                {
                                    DrawLine(originalMousePos + draw[i + 1], originalMousePos + draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(originalMousePos + draw[i], originalMousePos + draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                tileBatch.Draw(
                                                  anchorTexture,
                                                  originalMousePos + draw[i] + offset,
                                                  Color.Pink);
                            }
                        }
                        break;
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
            if (tex != null)
            {
                tileBatch.Draw(
                    tex,
                    Vector2.Zero,
                    Color.White
                    );
                if (camera.ViewingHeight != tex.Height)
                {
                    camera.ViewingHeight = tex.Height;
                    UpdateScrollbarsH();
                }
                if (camera.ViewingWidth != tex.Width)
                {
                    camera.ViewingWidth = tex.Width;
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
            int x = 99999999, y = 99999999, width = 0, height = 0;
            // Draw Outer Selection Rectangle
            foreach (TileData tile in selectedTiles)
            {
                if (tile.DisplayRect.X < x)
                    x = tile.DisplayRect.X;
                if (tile.DisplayRect.Y < y)
                    y = tile.DisplayRect.Y;
                if (tile.DisplayRect.X > width)
                    width = tile.DisplayRect.X;
                if (tile.DisplayRect.Y > height)
                    height = tile.DisplayRect.Y;
                FillRectangle(
                    new System.Drawing.RectangleF(
                        (tile.DisplayRect.X - 1f),
                        (tile.DisplayRect.Y),
                        ((tile.Width)),
                        ((tile.Height + 1))
                        ),
                        new Color(255, 0, 200, 50), new Color(255, 0, 200, 50), 0.1f);

            }
            if (selectedTiles.Count > 0)
                DrawRectangle(new System.Drawing.RectangleF(x, y, width - x + gridWidth + 1, height - y + gridHeight), Color.White, 3, 0);
        }
        /// <summary>
        /// Draw Grid
        /// </summary>
        private void DrawGrid()
        {
            Texture2D tex = GetTexture(SelectedTileset);
            if (tex != null)
            {
                for (int x = 0; x <= tex.Width; x += gridWidth)
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
                for (int y = 0; y <= tex.Height + 1; y += gridHeight)
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
            DrawLine(new Vector2(rectangle.X - scale, rectangle.Y + rectangle.Height), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, scale, priority);
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

            tileBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, scale), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }
        private void DrawLine(Vector2 PointA, Vector2 PointB, Color color, int scale, float priority, float rotation)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            tileBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, scale), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
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

            tileBatch.Draw(pixelTexture, new Rectangle((int)x + 1, (int)y + 1, (int)width - 2, (int)height - 2), null, fillColor, 0f, Vector2.Zero, 0, priority);

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

            tileBatch.Draw(pixelTexture, new Rectangle((int)x + 1, (int)y + 1, (int)width - 2, (int)height - 2), null, fillColor, 0f, Vector2.Zero, 0, priority);
            if (border)
                DrawRectangle(new System.Drawing.RectangleF(x + 1, y + 1, width - 2, height - 2), borderColor, 1, priority - 0.05f);
        }

        private Texture2D GetTexture(TilesetData tile)
        {
            try
            {
                if (tile.MaterialId > -1 && Global.GetData<MaterialData>(tile.MaterialId, GameData.Materials) != null)
                {
                    return Loader.Texture2D(contentManager, tile.MaterialId);
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

        #region Drag Drop
        private void graphicsControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (node.Parent != null)
                {
                    MaterialData m = MainForm.materialExplorer.Data();
                    if (m != null)
                    {
                        FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, m.FileName));
                        string ext = file.Extension.ToLower();
                        if (ext == ".png" || ext == ".bmp" || ext == ".jpg" || ext == ".jpeg")
                            e.Effect = DragDropEffects.Copy;
                    }
                }
            }
        }

        private void graphicsControl_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    MaterialData m = MainForm.materialExplorer.Data();

                    if (m != null)
                    {
                        if (selectedTileset == null)
                        {
                            TilesetData a = new TilesetData();
                            a.Name = Global.GetName("Tileset", GameData.Tilesets);
                            a.ID = Global.GetID(GameData.Tilesets);
                            a.Category = MainForm.tilesetEditor.addRemoveList.SelectedCategory;
                            a.Grid = new Microsoft.Xna.Framework.Vector2(Global.Project.DefaultGridSize.X, Global.Project.DefaultGridSize.Y);
                            GameData.Tilesets.Add(a.ID, a);

                            // History
                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.tilesetEditor.DataAdded), new DataRemoveDelegate(MainForm.tilesetEditor.DataRemoved)));

                            MainForm.tilesetEditor.addRemoveList.AddNode(a);
                            MainForm.mapEditor.PopulateTilesets();

                            selectedTileset = a;
                        }

                        selectedTileset.MaterialId = m.ID;
                        Texture2D tex = GetTexture(selectedTileset);
                        if (tex != null)
                        {
                            if (Parent is ImpactUI.ImpactGroupBox && Parent.Parent is TilesetEditor)
                            {
                                ((TilesetEditor)Parent.Parent).colBox.Maximum = tex.Width;
                                ((TilesetEditor)Parent.Parent).rowBox.Maximum = tex.Height;

                                ((TilesetEditor)Parent.Parent).colBox.Value = Math.Min((decimal)Global.Project.DefaultGridSize.X, tex.Width);
                                ((TilesetEditor)Parent.Parent).rowBox.Value = Math.Min((decimal)Global.Project.DefaultGridSize.Y, tex.Height);
                                MainForm.TilesetViewer.Setup();
                            }
                            selectedTiles.Clear();
                            int x = tex.Width / gridWidth;
                            int y = tex.Height / gridHeight;

                            camera.ViewingWidth = tex.Width;
                            camera.ViewingHeight = tex.Height;
                            UpdateScrollbarsH();
                            UpdateScrollbarsW();
                            RefreshTiles();

                            this.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "53x001");
            }
        }
        #endregion

        private void physicsBtn_CheckedChanged(object sender, EventArgs e)
        {
            btnAddRectangle.Checked = btnAddNode.Checked = btnAddCircle.Checked = btnLayout.Checked = false;
            if (physicsBtn.Checked)
            {
                contextMenuStrip.Enabled =
                btnAddCircle.Visible =
                btnAddNode.Visible =
                btnAddRectangle.Visible =
                btnLayout.Visible =
                seperator3.Visible =
                seperator2.Visible =
                subdivideBtn.Visible =
                simpifyBtn.Visible =
                deleteBtn.Visible = true;
                seperator.Visible = true;
            }
            else
            {
                contextMenuStrip.Enabled =
                seperator.Visible =
                btnAddCircle.Visible =
                btnAddNode.Visible =
                btnAddRectangle.Visible =
                btnLayout.Visible =
                seperator3.Visible =
                seperator2.Visible =
                subdivideBtn.Visible =
                simpifyBtn.Visible =
                deleteBtn.Visible = false;
                addingPhysics = false;
                physicsLbl.Visible = false;
            }
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked)
            {
                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Node;
                selectedNodeIndexes.Clear();
            }
        }

        private void addRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked)
            {
                if (selectedTiles.Count == 1)
                {
                    physicsLbl.Visible = true;
                    addingPhysics = true;
                    physicsType = PhysicsType.Rect;
                    selectedNodeIndexes.Clear();
                }
                else if (selectedTiles.Count > 1)
                {
                    foreach (TileData tile in selectedTiles)
                    {
                        if (tile.Body.Count > 0)
                        {
                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsRemovedHist(tile.Body, tile.Body));
                        }
                        tile.Body.Clear();
                        tile.Body.AddRange(Vertices.CreateSimpleRectangle(tile.DisplayRect.Width, tile.DisplayRect.Height));
                        tile.Body.SubDivideEdges(25f);
                        Vertices list2 = new Vertices();
                        Vector2 vNew2 = new Vector2();
                        foreach (Vector2 v in tile.Body)
                        {
                            vNew2 = v + (new Vector2(tile.DisplayRect.Width / 2, tile.DisplayRect.Height / 2));
                            list2.Add(vNew2);
                        }
                        tile.Body.Clear();
                        tile.Body.AddRange(list2);

                        MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));
                    }
                }
            }
        }

        private void addCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked)
            {
                if (selectedTiles.Count == 1)
                {
                    physicsLbl.Visible = true;
                    addingPhysics = true;
                    physicsType = PhysicsType.Circle;
                    selectedNodeIndexes.Clear();
                }
                else if (selectedTiles.Count > 1)
                {
                    foreach (TileData tile in selectedTiles)
                    {
                        if (tile.Body.Count > 0)
                        {
                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsRemovedHist(tile.Body, tile.Body));
                        }
                        tile.Body.Clear();
                        tile.Body.AddRange(Vertices.CreateEllipse(tile.DisplayRect.Width / 2, tile.DisplayRect.Height / 2, 16));

                        Vertices list2 = new Vertices();
                        Vector2 vNew2 = new Vector2();
                        foreach (Vector2 v in tile.Body)
                        {
                            vNew2 = v + (new Vector2(tile.DisplayRect.Width / 2, tile.DisplayRect.Height / 2));
                            list2.Add(vNew2);
                        }
                        tile.Body.Clear();
                        tile.Body.AddRange(list2);
                        MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));

                    }
                }
            }
        }

        private void layoutSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked)
            {
                if (selectedTiles.Count == 1)
                {
                    physicsLbl.Visible = true;
                    addingPhysics = true;
                    physicsType = PhysicsType.Layout;
                    selectedNodeIndexes.Clear();
                }
                else if (selectedTiles.Count > 1)
                {
                    foreach (TileData tile in selectedTiles)
                    {

                        if (tile.Body.Count > 0)
                        {
                            MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsRemovedHist(tile.Body, tile.Body));
                        }

                        //Create an array to hold the data from the texture
                        uint[] data = new uint[gridWidth * gridHeight];
                        Texture2D tex = GetTexture(selectedTileset);
                        //Transfer the texture data to the array
                        tex.GetData(0, tile.DisplayRect, data, 0, tile.DisplayRect.Width * tile.DisplayRect.Height);

                        //Calculate the vertices from the array
                        Vertices verts = Vertices.CreatePolygon(data, tile.DisplayRect.Width, tile.DisplayRect.Height);

                        //Make sure that the origin of the texture is the centroid (real center of geometry)
                        Vector2 origin = verts.GetCentroid();
                        Vector2 pos = new Vector2(-tile.DisplayRect.Width / 2, -tile.DisplayRect.Height / 2);
                        verts.Translate(ref pos);
                        Vertices.Simplify(verts);
                        tile.Body.Clear();
                        tile.Body.AddRange(verts);
                        Vertices list2 = new Vertices();
                        Vector2 vNew2 = new Vector2();
                        foreach (Vector2 v in tile.Body)
                        {
                            vNew2 = v + (new Vector2(gridWidth / 2, gridHeight / 2));
                            list2.Add(vNew2);
                        }
                        tile.Body.Clear();
                        tile.Body.AddRange(list2);
                        MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(tile.Body, tile.Body));

                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedTiles.Count > 0 && selectedNodeIndexes.Count > 0)
            {
                bool remove = false;
                List<List<Vector2>> removeList = new List<List<Vector2>>();
                List<Vertices> bodies = new List<Vertices>();
                for (int i = 0; i < selectedTiles.Count; i++)
                {
                    bodies.Add(selectedTiles[i].Body);
                    removeList.Add(new List<Vector2>());
                    for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                    {
                        if (selectedNodeIndexes[nodeIndex] < selectedTiles[i].Body.Count)
                        {
                            remove = true;
                            removeList[i].Add(selectedTiles[i].Body[selectedNodeIndexes[nodeIndex]]);
                            selectedTiles[i].Body.RemoveAt(selectedNodeIndexes[nodeIndex]);
                        }
                    }
                }
                if (remove)
                    MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new TilesetCollisionRemovedHist(removeList, bodies, selectedNodeIndexes));
            }
        }

        private void subdivideBtn_Click(object sender, EventArgs e)
        {
            if (selectedTiles.Count > 0)
            {
                List<Vertices> lists = new List<Vertices>();
                List<Vertices> bodies = new List<Vertices>();
                for (int i = 0; i < selectedTiles.Count; i++)
                {
                    lists.Add(new Vertices(selectedTiles[i].Body));
                    bodies.Add(selectedTiles[i].Body);
                    selectedTiles[i].Body.SubDivideEdges(25f);
                }
                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new TilesetCollisionsEditedHist(lists, bodies, bodies));
            }
        }

        private void simpifyBtn_Click(object sender, EventArgs e)
        {
            if (selectedTiles.Count > 0)
            {
                List<Vertices> lists = new List<Vertices>();
                List<Vertices> bodies = new List<Vertices>();
                for (int i = 0; i < selectedTiles.Count; i++)
                {
                    lists.Add(new Vertices(selectedTiles[i].Body));
                    bodies.Add(selectedTiles[i].Body);
                    Vertices list = Vertices.Simplify(selectedTiles[i].Body);
                    selectedTiles[i].Body.Clear();
                    selectedTiles[i].Body.AddRange(list);
                }
                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new TilesetCollisionsEditedHist(lists, bodies, bodies));
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTiles.Count > 0 && selectedTile == null)
                selectedTile = selectedTiles[0];
            if (selectedTile != null && selectedTile.Body.Count > 0)
            {
                Vertices collection = new Vertices(selectedTile.Body);

                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsRemovedHist(selectedTile.Body, selectedTile.Body));

                selectedTile.Body.Clear();

                if (collection.Count > 0)
                    Global.Copy(collection);
                originalCollisionBody = new Vertices(selectedTile.Body);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTiles.Count > 0 && selectedTile == null)
                selectedTile = selectedTiles[0];
            if (selectedTile != null && selectedTile.Body.Count > 0)
            {
                Vertices collection = new Vertices(selectedTile.Body);

                if (collection.Count > 0)
                    Global.Copy(collection);
                originalCollisionBody = new Vertices(selectedTile.Body);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTiles.Count > 0 && selectedTile == null)
                selectedTile = selectedTiles[0];
            if (selectedTile != null)
            {
                object data = Global.PasteData();

                if (data is Vertices)
                {
                    Vertices collection = (Vertices)data;

                    MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new CollisionsAddedHist(collection, selectedTile.Body));

                    selectedTile.Body.AddRange(collection);

                    originalCollisionBody = new Vertices(selectedTile.Body);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteBtn_Click(null, EventArgs.Empty);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTiles.Count > 0)
            {
                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new IGameDataChangePropertyHist(selectedTileset, new DataPropertyDelegate(TilesetEdited)));
                for (int i = 0; i < selectedTiles.Count; i++)
                {
                    selectedTiles[i].Body.Clear();
                }

            }
        }

        public void TilesetEdited(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (selectedTileset == data)
            {
                SelectedTileset = (TilesetData)data;
            }
        }

        internal void ResetContentManager()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

        }

        private void btnAddNode_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddNode.Checked)
            {
                btnAddRectangle.Checked = false;
                btnAddCircle.Checked = false;
                btnLayout.Checked = false;

                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Node;
                selectedNodeIndexes.Clear();
            }
            else
                physicsLbl.Visible = addingPhysics = false;
        }

        private void btnAddRectangle_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddRectangle.Checked)
            {
                btnAddNode.Checked = false;
                btnAddCircle.Checked = false;
                btnLayout.Checked = false;

                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Rect;
                selectedNodeIndexes.Clear();
            }
            else
                physicsLbl.Visible = addingPhysics = false;
        }

        private void btnAddCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddCircle.Checked)
            {
                btnAddRectangle.Checked = false;
                btnAddNode.Checked = false;
                btnLayout.Checked = false;

                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Circle;
                selectedNodeIndexes.Clear();
            }
            else
                physicsLbl.Visible = addingPhysics = false;
        }

        private void btnLayout_CheckedChanged(object sender, EventArgs e)
        {
            if (btnLayout.Checked)
            {
                btnAddRectangle.Checked = false;
                btnAddCircle.Checked = false;
                btnAddNode.Checked = false;

                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Layout;
                selectedNodeIndexes.Clear();
            }
            else
                physicsLbl.Visible = addingPhysics = false;
        }

        internal void SelectTile(int index)
        {
            selectedTiles.Clear();
            if (index > -1 && index < selectedTileset.Tiles.Count)
            {
                selectedTiles.Add(selectedTileset.Tiles[index]);
            }
        }
    }
}
