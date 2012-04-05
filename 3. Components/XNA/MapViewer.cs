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
using GenericUndoRedo;

using EGMGame.EventControls;
using System.Threading;
using System.Drawing.Imaging;
using EGMGame.Docking.Editors;
using System.Diagnostics;
using FarseerPhysics.Collisions;
using FarseerPhysics.Common;
using EGMGame.GameLibrary;
using EGMGame.Controls.EventControls;

namespace EGMGame.Controls
{
    public partial class MapViewer : UserControl, IHistory
    {
        #region Variables
        public bool showCollision = false;
        // Content variables
        ContentManager contentManager;
        // Render variables
        GraphicsDevice graphicsDevice;
        // Drawing variables
        SpriteBatch spriteBatch;
        Texture2D pixelTexture;
        Texture2D tileBtnTexture;
        Texture2D layerCircleTexture;
        Texture2D rounded3Texture;
        Texture2D rounded3InTexture;
        Texture2D lightbulbTexture;
        Texture2D playerTexture;
        Texture2D anchorTexture;

        Texture2D lastTilesetTexture;
        int lastTilesetID = -10;

        Texture2D lastPTilesetTexture;
        int lastPTilesetID = -10;

        Color colorTile = new Color();

        Rectangle tileRectangle = new Rectangle();
        // Camera
        XNA2dCamera camera;

        // Grid variables
        int gridWidth = 32;
        int gridHeight = 32;

        // Selection variables
        bool IsMouseDown;
        Vector2 originalMouse;
        Vector2 currentMouse;
        Vector2 lastMouse;

        TileData lastTileHighlighted = null;

        Vector2 MapOffset = new Vector2(128, 128);
        // Image/Camera Variables
        float zoomLevel = 1.0f;

        public TileViewer tilesetViewer;
        // Painting variables
        public BrushType brushType = BrushType.Brush;
        // Map variables
        Scene map;
        LayerData selectedLayer;
        LayerBackground selectedLayerBG;
        // Tile lists
        public List<TileData>[] selectedTiles = new List<TileData>[0];
        List<Vector2>[] selectedOffsets = new List<Vector2>[0];
        Vector2 selectRectOffset = new Vector2();

        List<TileData> previewTiles = new List<TileData>();
        // Rectangular/Elipsical Drawing Variables
        List<TileData> commitalTiles = new List<TileData>();
        bool needsCommit = false;
        // Tiles To Remove
        List<TileData> tilesToRemove = new List<TileData>();
        // Draw Preview
        bool drawPreview = false;

        TileData selectedTile;
        float mouseOffx = 0;
        float mouseOffy = 0;

        bool snapToW = false;
        bool snapToH = false;
        bool ctrl = false;
        bool shift = false;
        bool isMiddleDown;

        bool modified = false;
        Dictionary<Vector2, TileData> clones = new Dictionary<Vector2, TileData>();
        Dictionary<Vector2, TileData> original = new Dictionary<Vector2, TileData>();
        List<EventData> clonesE = new List<EventData>();
        List<EventData> originalE = new List<EventData>();


        Transformation transType = Transformation.Move;
        Vector2 originalScale;
        float originalRotation;

        internal TileSettingsDialog tileSettings = new TileSettingsDialog();
        internal EventSettingsDialog eventSettings = new EventSettingsDialog();
        internal LayerSingleDialog layerSettings = new LayerSingleDialog();
        internal CollisionDataDialog collisionSettings = new CollisionDataDialog();

        System.Drawing.Point mousePoint;


        internal MapEventDialog eventDialog; //= new MapEventDialog();
        internal PlayerEditor playerEditor; //= new PlayerEditor();

        TileData tileToFill;
        TileData tileFilling;
        bool isFilling = false;

        int oldScrollY = 0;
        int oldScrollX = 0;


        System.Drawing.Point lastMousePos = new System.Drawing.Point(0, 0);


        //calculate FPS
        Stopwatch timer;
        long nCount = 0;
        long uCount = 0;
        long TimeLast;
        long TimeNow;
        long TimeElapsed = 0;
        TimeSpan timeTotal;
        TimeSpan timeLastUpdate;
        TimeSpan timeElapsed;
        float millisecondsElapsed = 0;
        public float FPS;
        GameTime gameTime;

        int tileCount = 0;
        int drawnTileCount = 0;

        Rectangle selectionRectangle = new Rectangle();

        List<TileData> tilesHistory = new List<TileData>();
        List<TileData> tilesReplacedHistory = new List<TileData>();
        List<Vector2>[] selectedOriginalPos = null;
        bool pasted = false;

        Vector2 tileSize = new Vector2();


        bool addingNode = false;
        bool addingPhysics;
        PhysicsType physicsType = PhysicsType.Node;
        CollisionData selectedCollision;
        List<int> selectedNodeIndexes = new List<int>();
        int selectedNodeIndex = -1;
        Vertices originalCollisionBody = new Vertices();
        Vector2 selectedCollisionOffset;
        #endregion

        #region Properties
        [Browsable(false)]
        public TilesetData SelectedTileset
        {
            get { return selectedTileset; }
            set { selectedTileset = value; }
        }
        TilesetData selectedTileset;

        [Browsable(false)]
        public int GridWidth
        {
            get { return gridWidth; }
            set { gridWidth = value; UpdateTiles(); }
        }
        [Browsable(false)]
        public int GridHeight
        {
            get { return gridHeight; }
            set { gridHeight = value; UpdateTiles(); }
        }

        [Browsable(false)]
        public Scene Map
        {
            get { return map; }
            set { map = value; Invalidate(); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SnapToGrid
        {
            get
            {
                if (Global.Project != null) return Global.Project.SnapToGrid;
                return false;
            }
            set { if (Global.Project != null) Global.Project.SnapToGrid = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DisplayGrid
        {
            get
            {
                if (Global.Project != null) return Global.Project.DisplayGrid;
                return false;
            }
            set { if (Global.Project != null) Global.Project.DisplayGrid = value; }
        }

        [Browsable(false)]
        public bool EventSelection
        {
            get { return brushType == BrushType.EventSelection; }
        }

        EventData selectedEvent;

        [Browsable(false)]
        public LayerData SelectedLayer
        {
            get { return selectedLayer; }
            set { selectedLayer = value; Invalidate(); }
        }

        [Browsable(false)]
        public TileData SelectedTile
        {
            get { return selectedTile; }
            set
            {
                selectedTile = value;
                tileSettings.SelectedTile = selectedTile;
            }
        }

        public bool IsScreenSelect;
        #endregion

        #region Event Delegate
        // Event variables
        public delegate void TileSelectedHandler(TileEventArgs e);
        public event TileSelectedHandler TileSelectedEvent;

        protected virtual void OnTileSelected(TileEventArgs e)
        {
            if (TileSelectedEvent != null)
                TileSelectedEvent(e);
        }
        #endregion

        #region Constructor
        public MapViewer()
        {
            MainForm.MapEditorHistory[this] = new UndoRedoHistory<IHistory>(this);
            InitializeComponent();

            if (!this.DesignMode)
            {
                eventDialog = new MapEventDialog();
                playerEditor = new PlayerEditor();
            }
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

            // GUI Initialization
            toolStrip2.Renderer = new ImpactUI.ImpactToolstripRenderer();

            // Application Event Hooking 
            Application.Idle += delegate { graphicsControl.Invalidate(); };
            this.Resize += delegate { graphicsControl.Invalidate(); };
            // Scroller
            //bgScroller.RunWorkerAsync();
        }

        public void UpdateTiles()
        {
            if (map != null)
            {
                if (brushType == BrushType.EraserBrush || brushType == BrushType.EraserFill || brushType == BrushType.EraserRect)
                    this.graphicsControl.Cursor = Global.CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20);
                else if (brushType == BrushType.CursorSingle || brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer)
                    this.graphicsControl.Cursor = Cursors.Arrow;
                else
                    this.graphicsControl.Cursor = Global.CreateCursor(Properties.Resources.paint_brush, 20, 20, 0, 20);

                if (tilesetViewer == null)
                {
                    this.graphicsControl.Cursor = Cursors.Arrow;
                    this.SnapToGrid = false;
                }

                if (graphicsDevice != null)
                {
                    Viewport v = graphicsDevice.Viewport;
                    v.Height = Math.Max(1, graphicsControl.Height);
                    v.Width = Math.Max(1, graphicsControl.Width);
                    if (v.Height > map.Data.Size.Y)
                        v.Height = (int)map.Data.Size.Y;
                    if (v.Width > map.Data.Size.X)
                        v.Width = (int)map.Data.Size.X;
                    //graphicsControl.ViewSize = new System.Drawing.Size(v.Width, v.Height);
                    camera.Viewport = v;
                    camera.ViewingHeight = map.Data.Size.Y;
                    camera.ViewingWidth = map.Data.Size.X;

                    MapOffset = new Vector2(256, 256);
                    this.camera.MapOffset = MapOffset;
                    this.camera.Offset = -MapOffset;
                    this.camera.ViewingHeight += MapOffset.Y * 2;
                    this.camera.ViewingWidth += MapOffset.X * 2;
                    UpdateScrollbarsH();
                    UpdateScrollbarsW();
                }
            }
        }
        #endregion

        #region Mouse Events
        private void graphicsControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (map == null)
                return;

            if (Global.Project != null && MainForm.IsHigherThenXP)
                MainForm._tabMapContext.ContextAvailable = RibbonLib.Interop.ContextAvailability.Active;

            this.Focus();
            tilesHistory.Clear();
            commitalTiles.Clear();
            tilesReplacedHistory.Clear();
            mousePoint = e.Location;
            isMiddleDown = (e.Button == MouseButtons.Middle);
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            originalMouse.X = point.X;
            originalMouse.Y = point.Y;
            lastMousePos = e.Location;

            // Mouse down and move
            if (ctrl && e.Button == MouseButtons.Left && !(physicsBtn.Checked && showCollision))
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


            if (e.Button == MouseButtons.Left && shift && !(physicsBtn.Checked && showCollision))
            {
                TileData reflectTile = GetTileR(new Vector2(point.X, point.Y));
                if (reflectTile != null)
                {
                    tilesetViewer.TrySelect(reflectTile);
                }
                return;
            }

            if (tilesetViewer != null)
            {
                if (map != null && selectedLayer != null)
                {
                    if (physicsBtn.Checked && showCollision)
                    {
                        CheckPhysics(e);
                    }
                    else
                    {
                        lastMouse = new Vector2(-1f, -1f);
                        // Divide Point by width and height
                        //System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                        // if (rect.Contains(point))
                        //{
                        IsMouseDown = true;
                        // Edit Type
                        switch (brushType)
                        {
                            case BrushType.CursorSingle:
                                SelectObject(originalMouse);
                                break;
                            case BrushType.CursorMulti:
                                SelectObject(originalMouse);
                                break;
                            case BrushType.CursorMultiLayer:
                                SelectObject(originalMouse);
                                break;
                            case BrushType.EventSelection:
                                SelectObject(originalMouse);
                                break;
                            case BrushType.LayerSelection:
                                SelectLayer(originalMouse);
                                break;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            switch (brushType)
                            {
                                case BrushType.Brush:
                                    DoPencil(originalMouse, false);
                                    break;
                                case BrushType.Fill:
                                    DoPencil(originalMouse, false);
                                    break;
                                case BrushType.Rectangle:
                                    DoPencil(originalMouse, false);
                                    break;
                            }
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            switch (brushType)
                            {
                                case BrushType.Brush:
                                    DoEraser(originalMouse);
                                    break;
                                case BrushType.Fill:
                                    DoEraser(originalMouse);
                                    break;
                                case BrushType.Rectangle:
                                    DoEraser(originalMouse);
                                    break;
                            }
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right && (brushType == BrushType.CursorSingle || brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer || brushType == BrushType.EventSelection))
                {
                    System.Drawing.PointF point1 = camera.GetTransformedPoint(e.Location);
                    transType = Transformation.Move;
                    if (brushType == BrushType.EventSelection)
                        SelectedTile = GetTileR(new Vector2(point1.X, point1.Y));
                    else
                        selectedEvent = GetEvent(new Vector2(point1.X, point1.Y));
                    if (brushType != BrushType.EventSelection && selectedTile != null)
                    {
                        selectedTile.SetOffSet(out mouseOffx, out mouseOffy, new Vector2(point1.X, point1.Y));

                        int x = e.Location.X;
                        int y = e.Location.Y;
                        //if (tileMenu.Enabled)
                        //tileMenu.Show(this, x, y);
                    }
                    else if (brushType == BrushType.EventSelection && selectedEvent != null)
                    {
                        selectedEvent.SetOffSet(out mouseOffx, out mouseOffy, new Vector2(point1.X, point1.Y));

                        int x = e.Location.X;
                        int y = e.Location.Y;
                        //if (tileMenu.Enabled)
                        //tileMenu.Show(this, x, y);
                    }
                    else
                    {
                        int x = e.Location.X;
                        int y = e.Location.Y; ;
                    }
                }
                else if (e.Button == MouseButtons.Right && (brushType != BrushType.CursorSingle && brushType != BrushType.CursorMulti && brushType != BrushType.CursorMultiLayer))
                {
                    lastMouse = new Vector2(-1f, -1f);
                    // Divide Point by width and height
                    System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                    // if (rect.Contains(point))
                    // {
                    IsMouseDown = true;
                    // Edit Type
                    CheckCursor();

                    if (!ctrl)
                    {
                        BrushType bt = brushType;
                        // Edit Type
                        switch (brushType)
                        {
                            //case BrushType.EraserBrush:
                            //    brushType = BrushType.Brush;
                            //    DoPencil(originalMouse, false);
                            //    break;
                            //case BrushType.EraserFill:
                            //    brushType = BrushType.Fill;
                            //    DoPencil(originalMouse, false);
                            //    break;
                            //case BrushType.EraserRect:
                            //    brushType = BrushType.Rectangle;
                            //    DoPencil(originalMouse, false);
                            //    break;
                            case BrushType.Brush:
                                brushType = BrushType.EraserBrush;
                                DoEraser(originalMouse);
                                break;
                            case BrushType.Fill:
                                brushType = BrushType.EraserFill;
                                DoEraser(originalMouse);
                                break;
                            case BrushType.Rectangle:
                                brushType = BrushType.EraserRect;
                                DoEraser(originalMouse);
                                break;
                            case BrushType.LayerSelection:
                                SelectLayer(originalMouse);
                                break;
                        }
                        brushType = bt;
                    }
                    else
                    {
                        TileData data = GetTileR(new Vector2(point.X, point.Y));
                        if (data != null)
                        {
                            tilesetViewer.selectedTiles.Clear();
                            tilesetViewer.selectedTiles.Add(data);
                        }
                    }
                    //}
                }
            }
        }
        /// <summary>
        /// Check Physics
        /// </summary>
        /// <param name="e"></param>
        private void CheckPhysics(MouseEventArgs e)
        {
            if (addingPhysics)
            {
                IsMouseDown = true;
            }
            else
            {
                System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                selectedCollision = null;
                for (int i = selectedLayer.CollisionData.Count - 1; i > -1; i--)
                {
                    if (selectedLayer.CollisionData[i].GetRectangle().Contains(point))
                    {
                        selectedCollision = selectedLayer.CollisionData[i];
                        selectedCollisionOffset.X = point.X - selectedCollision.Position.X;
                        selectedCollisionOffset.Y = point.Y - selectedCollision.Position.Y;
                        break;
                    }
                }
                if (selectedCollision != null)
                {
                    Vector2 pos = new Vector2();
                    Rectangle rect = new Rectangle(0, 0, 8, 8);
                    Point p = new Point((int)point.X, (int)point.Y);
                    Vector2 offset = new Vector2();
                    offset.X = -4;
                    offset.Y = -4;
                    if (shift)
                        addingNode = true;
                    for (int i = 0; i < selectedCollision.Count; i++)
                    {
                        pos = selectedCollision[i] + offset;
                        rect.X = (int)pos.X;
                        rect.Y = (int)pos.Y;

                        if (rect.Contains(p) && !selectedNodeIndexes.Contains(i))
                        {
                            if (!ctrl)
                                selectedNodeIndexes.Clear();
                            selectedNodeIndexes.Add(i);
                            selectedNodeIndex = i;
                            originalCollisionBody = new Vertices(selectedCollision);
                            IsMouseDown = true;
                            return;
                        }
                        else if (rect.Contains(p) && selectedNodeIndexes.Contains(i))
                        {
                            selectedNodeIndex = i;
                            originalCollisionBody = new Vertices(selectedCollision);
                            IsMouseDown = true;
                            return;
                        }
                    }

                    selectedCollision.SetOffSet(out mouseOffx, out mouseOffy, point);

                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        ShowCollisionMenu();
                }
                selectedNodeIndexes.Clear();
                IsMouseDown = true;
            }
        }

        private void graphicsControl_MouseMove(object sender, MouseEventArgs e)
        {
            FocusParent();
            drawPreview = true;
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            currentMouse.X = (int)point.X;
            currentMouse.Y = (int)point.Y;
            // Update mouse position label
            float x = (int)point.X; float y = (int)point.Y;
            if (SnapToGrid || snapToW)
                x = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
            if (SnapToGrid || snapToH)
                y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
            if (map != null)
                mouseLbl.Text = "{" + x.ToString() + ", " + y.ToString() + "}";
            else
                mouseLbl.Text = "{0, 0}";

            if (physicsBtn.Checked && showCollision)
            {
                if (IsMouseDown && selectedCollision != null && e.Button != System.Windows.Forms.MouseButtons.Right && !ctrl && selectedNodeIndexes.Count > 0 && !addingPhysics)
                {

                    Vector2 pos;
                    Vector2 offset = new Vector2();
                    Vector2 finalPos = new Vector2();
                    Rectangle rect = new Rectangle(0, 0, 8, 8);
                    System.Drawing.PointF last = camera.GetTransformedPoint(lastMousePos);
                    Point checkPos = new Point();
                    Vector2 selNodePos = Vector2.Zero;

                    if (selectedNodeIndex > -1 && selectedNodeIndex < selectedCollision.Count)
                        selNodePos = selectedCollision[selectedNodeIndex];
                    else
                        selNodePos = Vector2.Zero;
                    for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                    {
                        if (selectedNodeIndexes[nodeIndex] < selectedCollision.Count)
                        {
                            Point p = new Point((int)last.X, (int)last.Y);
                            offset.X = -4;
                            offset.Y = -4;
                            pos = selectedCollision[selectedNodeIndexes[nodeIndex]] + offset;
                            rect.X = (int)pos.X;
                            rect.Y = (int)pos.Y;
                            offset.X = -4;
                            offset.Y = -4;

                            if (selectedNodeIndex != selectedNodeIndexes[nodeIndex])
                            {
                                offset += selNodePos - selectedCollision[selectedNodeIndexes[nodeIndex]];
                            }

                            pos.X = point.X;
                            pos.Y = point.Y;
                            if (!addingNode)
                            {
                                // Move the node
                                if (!snapToH)
                                    finalPos.X = pos.X - offset.X;
                                else
                                    finalPos.X = selectedCollision[selectedNodeIndexes[nodeIndex]].X;

                                if (!snapToW)
                                    finalPos.Y = pos.Y - offset.Y;
                                else
                                    finalPos.Y = selectedCollision[selectedNodeIndexes[nodeIndex]].Y;
                                checkPos.X = (int)(finalPos.X + offset.X) + 4;
                                checkPos.Y = (int)(finalPos.Y + offset.Y) + 4;
                                selectedCollision[selectedNodeIndexes[nodeIndex]] = finalPos;
                            }
                            else if (shift)
                            {
                                addingNode = false;
                                // Add and connect to new node
                                selectedNodeIndexes[nodeIndex]++;
                                selectedNodeIndex = selectedNodeIndexes[nodeIndex];
                                selectedCollision.Insert(selectedNodeIndexes[nodeIndex], pos - offset);
                                originalCollisionBody = new Vertices(selectedCollision);
                                break;
                            }
                            lastMousePos = e.Location;
                        }
                    }
                }
                else if (IsMouseDown && selectedCollision != null && e.Button != System.Windows.Forms.MouseButtons.Right && !ctrl && selectedNodeIndexes.Count == 0 && physicsBtn.Checked && !addingPhysics)
                {

                    System.Drawing.PointF last = camera.GetTransformedPoint(lastMousePos);
                    System.Drawing.PointF original = camera.GetTransformedPoint(mousePoint);
                    Vector2 movedPos = Vector2.Zero;
                    movedPos.X = point.X - last.X;// +selectedCollisionOffset.X;
                    movedPos.Y = point.Y - last.Y;// +selectedCollisionOffset.Y;
                    //if ((SnapToGrid || snapToW) && Math.Abs(point.X - last.X) >= gridWidth)
                    //    movedPos.X = (int)Math.Floor((double)(movedPos.X / gridWidth)) * gridWidth;
                    //else if (!(Math.Abs(point.X - last.X) > gridWidth))
                    //    movedPos.X = 0;

                    //if ((SnapToGrid || snapToH) && Math.Abs(point.Y - last.Y) >= gridHeight)
                    //    movedPos.Y = (int)Math.Floor((double)(movedPos.Y / gridHeight)) * gridHeight;
                    //else if (!(Math.Abs(point.Y - last.Y) >= gridHeight))
                    //    movedPos.Y = 0;

                    x = (float)(point.X - mouseOffx);
                    y = (float)(point.Y - mouseOffy);
                    if (snapToW || SnapToGrid)
                        x = (float)Math.Floor((double)((point.X - mouseOffx) / gridWidth)) * gridWidth;
                    if (snapToH || SnapToGrid)
                        y = (float)Math.Floor((double)((point.Y - mouseOffy) / gridHeight)) * gridHeight;
                    // Add it to new position

                    if (snapToW || SnapToGrid)
                        movedPos.X = -selectedCollision.Position.X;//-(float)Math.Floor((double)((selectedCollision.Position.X) / gridWidth)) * gridWidth;
                    else
                        movedPos.X = -selectedCollision.Position.X;

                    if (snapToH || SnapToGrid)
                        movedPos.Y = -selectedCollision.Position.Y;//-(float)Math.Floor((double)((selectedCollision.Position.Y) / gridHeight)) * gridHeight;
                    else
                        movedPos.Y = -selectedCollision.Position.Y;


                    selectedCollision.Translate(ref movedPos);
                    movedPos = new Vector2((int)x, (int)y);
                    selectedCollision.Translate(ref movedPos);

                    //if ((SnapToGrid || snapToW) && Math.Abs(point.X - last.X) >= gridWidth)
                    //    lastMousePos.X = e.Location.X;
                    //else if (!(SnapToGrid || snapToW))
                    //    lastMousePos.X = e.Location.X;
                    //if ((SnapToGrid || snapToH) && Math.Abs(point.Y - last.Y) >= gridHeight)
                    //    lastMousePos.Y = e.Location.Y;
                    //else if (!(SnapToGrid || snapToH))
                    //    lastMousePos.Y = e.Location.Y;

                }
            }
            else
            {
                // Only perform actions if mouse is down
                if (IsMouseDown && !ctrl)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        switch (brushType)
                        {
                            case BrushType.CursorSingle:
                                CursorMove(point);
                                break;
                            case BrushType.CursorMulti:
                                CursorMove(point);
                                break;
                            case BrushType.CursorMultiLayer:
                                CursorMove(point);
                                break;
                            case BrushType.EraserBrush:
                                DoEraser(currentMouse);
                                break;
                            case BrushType.EraserFill:
                                DoEraser(currentMouse);
                                break;
                            case BrushType.EraserRect:
                                DoEraser(currentMouse);
                                break;
                            case BrushType.Brush:
                                DoPencil(currentMouse, true);
                                break;
                            case BrushType.Fill:
                                DoPencil(currentMouse, true);
                                break;
                            case BrushType.Rectangle:
                                DoPencil(currentMouse, true);
                                break;
                            case BrushType.EventSelection:
                                CursorMove(point);
                                break;
                            case BrushType.LayerSelection:
                                LayerMove(point);
                                break;
                        }
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        BrushType bt = brushType;
                        // Edit Type
                        switch (brushType)
                        {
                            //case BrushType.EraserBrush:
                            //    brushType = BrushType.Brush;
                            //    DoPencil(currentMouse, true);
                            //    break;
                            //case BrushType.EraserFill:
                            //    brushType = BrushType.Fill;
                            //    DoPencil(currentMouse, true);
                            //    break;
                            //case BrushType.EraserRect:
                            //    brushType = BrushType.Rectangle;
                            //    DoPencil(currentMouse, true);
                            //    break;
                            case BrushType.Brush:
                                brushType = BrushType.EraserBrush;
                                DoEraser(currentMouse);
                                break;
                            case BrushType.Fill:
                                brushType = BrushType.EraserFill;
                                DoEraser(currentMouse);
                                break;
                            case BrushType.Rectangle:
                                brushType = BrushType.EraserRect;
                                DoEraser(currentMouse);
                                break;
                        }
                        brushType = bt;
                    }
                }
            }
            // Is mousedown and ctrl is pressed, scroll the map.
            if (IsMouseDown && ctrl)
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
                newVM = (int)Math.Min(newVM, vScrollBar.Maximum - gridHeight);
                //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newVM, ScrollOrientation.VerticalScroll));
                vScrollBar.Value = Math.Min(vScrollBar.Maximum, Math.Max(vScrollBar.Minimum, newVM));
                int newHM = hScrollBar.Value + (int)diff.X;
                if (!hScrollBar.Enabled) newHM = 0;
                newHM = (int)Math.Max(newHM, hScrollBar.Minimum);
                newHM = (int)Math.Min(newHM, hScrollBar.Maximum - gridWidth);
                //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newHM, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = Math.Min(hScrollBar.Maximum, Math.Max(hScrollBar.Minimum, newHM));
            }
            lastMousePos = e.Location;
        }

        private void LayerMove(System.Drawing.PointF p)
        {
            if (selectedLayerBG != null)
            {
                if (transType == Transformation.Move)
                {
                    float x = (float)(p.X - mouseOffx);
                    float y = (float)(p.Y - mouseOffy);
                    if (snapToW || SnapToGrid)
                        x = (float)Math.Floor((double)((p.X - mouseOffx) / gridWidth)) * gridWidth;
                    if (snapToH || SnapToGrid)
                        y = (float)Math.Floor((double)((p.Y - mouseOffy) / gridHeight)) * gridHeight + gridHeight / 2;
                    // Add it to new position
                    selectedLayerBG.Position = new Vector2((int)x, (int)y);

                }
                else if (transType == Transformation.Rotate)
                {
                    //float x = originalMouse.X - p.X + originalRotation;
                    //if (x <= 360 && x >= 0)
                    //    selectedLayerBG.Rotation = x;
                }
                else if (transType == Transformation.Scale)
                {
                    //if (!original.ContainsKey(selectedTile.Position))
                    //{
                    //    clones.Add(selectedTile.Position, selectedTile.Clone()); modified = true; original.Add(selectedTile.Position, selectedTile);
                    //}
                    Vector2 s = new Vector2((float)(p.X - originalMouse.X) / 100 + originalScale.X, (float)(p.Y - originalMouse.Y) / 100 + originalScale.Y);
                    if (s.X < 0.25f) s.X = 0.25f;
                    if (s.Y < 0.25f) s.Y = 0.25f;
                    if (s.X > 10.0f) s.X = 10.0f;
                    if (s.Y > 10.0f) s.Y = 10.0f;
                    selectedLayerBG.Scale = s;
                }
            }
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
                    newV = (int)Math.Min(newV, vScrollBar.Maximum - gridHeight);
                    //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newV, ScrollOrientation.VerticalScroll));
                    vScrollBar.Value = newV;
                }
            }
            else
            {
                Vector2 point = camera.GetTransformedPointV(e.Location);
                if (e.Delta > 0)
                    Zoom(25, false);
                else if (e.Delta < 0)
                    Zoom(-25, false);
                Vector2 point2 = camera.GetTransformedPointV(e.Location);
                point -= point2;
                //camera.Position += point;

                int newV = vScrollBar.Value + (int)point.Y;
                newV = (int)Math.Max(newV, vScrollBar.Minimum);
                newV = (int)Math.Min(newV, vScrollBar.Maximum - gridHeight);
                vScrollBar.Value = newV;
                int newH = hScrollBar.Value + (int)point.X;
                newH = (int)Math.Max(newH, hScrollBar.Minimum);
                newH = (int)Math.Min(newH, hScrollBar.Maximum - gridWidth);
                hScrollBar.Value = newH;
            }
        }

        private void FocusParent()
        {
            //this.Focus();
        }

        private void graphicsControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                if (addingPhysics && e.Button == MouseButtons.Left)
                {
                    AddPhysics();
                }
                if (brushType == BrushType.EventSelection && selectedEvent != null)
                {
                    float x = (float)(originalMouse.X - mouseOffx);
                    float y = (float)(originalMouse.Y - mouseOffy);
                    if (new Vector2(x, y) != selectedEvent.Position)
                    {
                        MainForm.MapEditorHistory[this].Do(new EventMoved(selectedEvent, new Vector2(x, y), selectedEvent.Position));
                    }
                }

                if (needsCommit)
                {
                    tilesHistory.Clear();

                    List<Vector2> positions = new List<Vector2>();
                    foreach (TileData tile in commitalTiles)
                    {
                        positions.Add(tile.Position);
                    }
                    // Create Tile
                    List<TileData> rt = ClearTiles(positions);

                    foreach (TileData tile in commitalTiles)
                    {
                        System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                        if (rect.Contains(tile.Position.X, tile.Position.Y))
                        {
                            TileData newTile = new TileData();
                            newTile.Position = new Vector2((int)tile.Position.X, (int)tile.Position.Y);
                            newTile.Width = tile.Width;
                            newTile.Height = tile.Height;
                            newTile.DisplayRect = tile.DisplayRect;
                            newTile.TilesetID = tile.TilesetID;
                            newTile.Opacity = tile.Opacity;
                            newTile.Scale = tile.Scale;
                            newTile.Rotation = tile.Rotation;
                            newTile.HorizontalFlip = tile.HorizontalFlip;
                            newTile.VerticalFlip = tile.VerticalFlip;
                            newTile.Body = tile.Body;
                            newTile.IsSensor = tile.IsSensor;
                            newTile.IsStatic = tile.IsStatic;
                            newTile.Tag = tile.Tag;
                            newTile.SetRectangle();
                            selectedLayer.Tiles.Add(newTile);

                            tilesHistory.Add(newTile);
                        }
                    }
                    if (rt != null)
                        tilesReplacedHistory.AddRange(rt);
                }
                if (tilesReplacedHistory.Count > 0 && tilesHistory.Count == 0)
                    MainForm.MapEditorHistory[this].Do(new TilesRemoved(tilesReplacedHistory, new List<TileData>(), selectedLayer.Tiles, new DataTRemoveDelegate(TileRemoved)));

                if (tilesHistory.Count > 0)
                {
                    //if (tilesReplacedHistory.Count > 0)
                    //    MainForm.MapEditorHistory[this].Do(new TilesRemoved(tilesReplacedHistory, selectedLayer.Tiles));
                    MainForm.MapEditorHistory[this].Do(new TilesAdded(tilesHistory, tilesReplacedHistory, selectedLayer.Tiles, new DataTRemoveDelegate(TileRemoved)));
                }

                if (tilesToRemove.Count > 0)
                {
                    foreach (TileData tr in tilesToRemove)
                    {
                        selectedLayer.Tiles.Remove(tr);
                    }
                    MainForm.MapEditorHistory[this].Do(new TilesRemoved(tilesToRemove, new List<TileData>(), selectedLayer.Tiles, new DataTRemoveDelegate(TileRemoved)));

                    //MainForm.MapEditorHistory[this].Do(new TilesHist(tilesToRemove, false, selectedLayer.Tiles));
                }
                tilesToRemove.Clear();
                tilesHistory.Clear();
                tilesReplacedHistory.Clear();

                if (selectedTile != null && brushType == BrushType.CursorSingle)
                {
                    float x = (float)(originalMouse.X - mouseOffx);
                    float y = (float)(originalMouse.Y - mouseOffy);
                    System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                    if (transType == Transformation.Move)
                    {
                        if (new Vector2(x, y) != selectedTile.Position)
                        {
                            List<TileData> rt = ClearTiles(selectedTile.Position);
                            SelectedLayer.Tiles.Add(selectedTile);
                            MainForm.MapEditorHistory[this].Do(new TilesMoved(new List<TileData>() { selectedTile }, rt, new Vector2(x, y), selectedTile.Position, selectedLayer.Tiles));
                            selectedTile.SetRectangle();
                        }
                    }
                    else if (transType == Transformation.Scale)
                    {
                        if (new Vector2(x, y) != new Vector2(point.X, point.Y))
                        {
                            Vector2 nowS = selectedTile.Scale;
                            selectedTile.Scale = originalScale;
                            MainForm.MapEditorHistory[this].Do(new TileMod(selectedTile));
                            selectedTile.Scale = nowS;
                            selectedTile.SetRectangle();
                        }
                    }
                    else if (transType == Transformation.Rotate)
                    {
                        if (new Vector2(x, y) != new Vector2(point.X, point.Y))
                        {
                            float nowS = selectedTile.Rotation;
                            selectedTile.Rotation = originalRotation;
                            MainForm.MapEditorHistory[this].Do(new TileMod(selectedTile));
                            selectedTile.Rotation = nowS;
                            selectedTile.SetRectangle();
                        }
                    }
                }


                needsCommit = false;
                originalMouse.X = 0;
                originalMouse.Y = 0;
                commitalTiles.Clear();
                transType = Transformation.Move;
                clones.Clear(); modified = false; original.Clear();
                lastMouse = Vector2.Zero;


                if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() == 0)
                {
                    if (selectionRectangle.Width < 0)
                    {
                        selectionRectangle.X += selectionRectangle.Width;
                        selectionRectangle.Width = (int)Math.Abs(selectionRectangle.Width);
                    }
                    if (selectionRectangle.Height < 0)
                    {
                        selectionRectangle.Y += selectionRectangle.Height;
                        selectionRectangle.Height = (int)Math.Abs(selectionRectangle.Height);
                    }
                    selectedTiles = new List<TileData>[map.Data.Layers.Count];
                    selectedOffsets = new List<Vector2>[map.Data.Layers.Count];
                    selectedOriginalPos = null;

                    System.Drawing.RectangleF streamArea = new System.Drawing.RectangleF(selectionRectangle.X, selectionRectangle.Y, selectionRectangle.Width, selectionRectangle.Height);
                    switch (brushType)
                    {
                        case BrushType.CursorMulti:
                            for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                            {
                                if (!map.Data.Layers[layerIndex].IsVisible || selectedLayer != map.Data.Layers[layerIndex])
                                    continue;
                                //listOfTiles = map.Data.Layers[layerIndex].Tiles.GetSections(map.Data.Layers[layerIndex].Tiles.GetIndex(drawArea), 3);
                                selectedTiles[layerIndex] = new List<TileData>();
                                selectedOffsets[layerIndex] = new List<Vector2>();
                                for (int tileIndex = 0; tileIndex < map.Data.Layers[layerIndex].Tiles.Count; tileIndex++)
                                {
                                    if (map.Data.Layers[layerIndex].Tiles[tileIndex].RectangleF.IntersectsWith(streamArea))
                                    {
                                        selectedTiles[layerIndex].Add(map.Data.Layers[layerIndex].Tiles[tileIndex]);
                                        MainForm.HistoryExplorer.UndoRedoEnabled = false;
                                    }
                                }
                            }
                            break;
                        case BrushType.CursorMultiLayer:
                            for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                            {
                                if (!map.Data.Layers[layerIndex].IsVisible)
                                    continue;
                                //listOfTiles = map.Data.Layers[layerIndex].Tiles.GetSections(map.Data.Layers[layerIndex].Tiles.GetIndex(drawArea), 3);
                                selectedTiles[layerIndex] = new List<TileData>();
                                selectedOffsets[layerIndex] = new List<Vector2>();
                                for (int tileIndex = 0; tileIndex < map.Data.Layers[layerIndex].Tiles.Count; tileIndex++)
                                {
                                    if (map.Data.Layers[layerIndex].Tiles[tileIndex].RectangleF.IntersectsWith(streamArea))
                                    {
                                        selectedTiles[layerIndex].Add(map.Data.Layers[layerIndex].Tiles[tileIndex]);
                                        MainForm.HistoryExplorer.UndoRedoEnabled = false;
                                    }
                                }
                            }
                            break;
                    }
                }
                else if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
                {
                    //for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                    //{
                    //    if (selectedTiles[layerIndex] != null)
                    //    {
                    //        List<Vector2> selectedNewPositions = new List<Vector2>();
                    //        // Move the selcted tiles
                    //        int offIndex = 0;
                    //        List<Vector2> positions = new List<Vector2>();
                    //        foreach (TileData tile in selectedTiles[layerIndex])
                    //            positions.Add(tile.Position);

                    //        List<TileData> rt = ClearTiles(positions);
                    //        if (rt != null && rt.Count > 0)
                    //        {
                    //            foreach (TileData rep in rt)
                    //            {
                    //                if (!tilesReplacedHistory.Contains(rep))
                    //                {
                    //                    tilesReplacedHistory.Add(rep);
                    //                }
                    //            }
                    //        }

                    //        foreach (TileData tile in selectedTiles[layerIndex])
                    //        {
                    //            if (selectedOriginalPos != null && selectedOriginalPos[layerIndex] != null && offIndex < selectedOriginalPos[layerIndex].Count)
                    //            {
                    //                // Add it to new position
                    //                if (selectedOriginalPos[layerIndex][offIndex] != tile.Position)
                    //                {
                    //                    modified = true;
                    //                }
                    //            }

                    //            tilesReplacedHistory.Remove(tile);

                    //            map.Data.Layers[layerIndex].Tiles.Add(tile);
                    //            tilesHistory.Add(tile);
                    //            offIndex++;
                    //        }
                    //        foreach (TileData rep in tilesHistory)
                    //        {
                    //            tilesReplacedHistory.Remove(rep);
                    //        }
                    //        if (tilesHistory.Count > 0)
                    //        {
                    //            // If pasted, just add, don't move
                    //            if (pasted)
                    //            {
                    //                MainForm.MapEditorHistory[this].Do(new TilesAdded(tilesHistory, tilesReplacedHistory, map.Data.Layers[layerIndex].Tiles, new DataTRemoveDelegate(TileRemoved)));
                    //            }
                    //            else
                    //            {

                    //                if (modified)
                    //                {
                    //                    foreach (TileData tile in tilesHistory)
                    //                    {
                    //                        selectedNewPositions.Add(tile.Position);
                    //                    }
                    //                    MainForm.MapEditorHistory[this].Do(new TilesMoved(tilesHistory, tilesReplacedHistory, selectedOriginalPos[layerIndex], selectedNewPositions, map.Data.Layers[layerIndex].Tiles));
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            IsMouseDown = false;
            isMiddleDown = false;
            CheckCursor();
            if (brushType != BrushType.CursorMulti && brushType != BrushType.CursorMultiLayer)
                MainForm.HistoryExplorer.UndoRedoEnabled = true;

            if (brushType == BrushType.LayerSelection)
            {
                layerSettings.SelectedBG = selectedLayerBG;
            }
        }

        private void AddPhysics()
        {
            Vertices list2 = new Vertices();
            Vector2 vNew2 = Vector2.Zero;
            Vector2 pos = currentMouse;
            Vector2 _position = new Vector2();
            _position.X = camera.GetTransformedPoint(mousePoint).X;
            _position.Y = camera.GetTransformedPoint(mousePoint).Y;
            if (SnapToGrid || snapToW)
                _position.X = (float)Math.Floor((double)(camera.GetTransformedPoint(mousePoint).X / gridWidth)) * gridWidth;
            if (SnapToGrid || snapToH)
                _position.Y = (float)Math.Floor((double)(camera.GetTransformedPoint(mousePoint).Y / gridHeight)) * gridHeight;
            if (SnapToGrid || snapToW)
                pos.X = (float)Math.Floor((double)(pos.X / gridWidth)) * gridWidth + gridWidth;
            if (SnapToGrid || snapToH)
                pos.Y = (float)Math.Floor((double)(pos.Y / gridHeight)) * gridHeight + gridHeight;

            Vector2 offset = new Vector2();
            Vector2 nodePosition = Vector2.Zero;
            Vector2 diff = _position - pos;
            CollisionData collision;
            switch (physicsType)
            {
                #region Node
                case PhysicsType.Node:
                    //tile.Body.Clear();
                    offset.X = _position.X;
                    offset.Y = _position.Y;
                    if (selectedCollision != null)
                    {
                        if (selectedCollision.GetRectangle().Contains(camera.GetTransformedPoint(mousePoint)))
                        {
                            selectedCollision.Add(offset);
                            return;
                        }
                    }
                    collision = new CollisionData();
                    collision.Add(offset);
                    selectedLayer.CollisionData.Add(collision);
                    selectedCollision = collision;
                    collisionSettings.Setup(selectedCollision);

                    MainForm.MapEditorHistory[this].Do(new ColAddedHist(selectedCollision, new DataColAddDelegate(ColAdded), new DataColRemoveDelegate(ColRemoved), selectedLayer));
                    break;
                #endregion
                #region Rectangle
                case PhysicsType.Rect:
                    System.Drawing.Point difference = new System.Drawing.Point((int)pos.X - (int)_position.X, (int)pos.Y - (int)_position.Y);

                    Rectangle rect = new Rectangle((int)_position.X, (int)_position.Y, difference.X, difference.Y);


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

                    difference.X = rect.Width;
                    difference.Y = rect.Height;
                    _position.X = rect.X;
                    _position.Y = rect.Y;

                    EGMGame.Dialogs.CollisionParameterConfirmDialog dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                    dialog.Setup((int)_position.X, (int)_position.Y, difference.X, difference.Y);

                    Vector2 tempOM = _position;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        tempOM.X = (float)dialog.nudX.Value;
                        tempOM.Y = (float)dialog.nudy.Value;
                        difference.X = (int)dialog.nudWidth.Value;
                        difference.Y = (int)dialog.nudHeight.Value;



                        Vertices body = Vertices.CreateSimpleRectangle(Math.Abs(difference.X), Math.Abs(difference.Y));

                        list2 = new Vertices();
                        vNew2 = new Vector2();
                        foreach (Vector2 v in body)
                        {
                            vNew2 = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                            list2.Add(vNew2);
                        }
                        collision = new CollisionData();
                        collision.AddRange(list2);
                        selectedLayer.CollisionData.Add(collision);
                        selectedCollision = collision;
                        collisionSettings.Setup(selectedCollision);


                        MainForm.MapEditorHistory[this].Do(new ColAddedHist(selectedCollision, new DataColAddDelegate(ColAdded), new DataColRemoveDelegate(ColRemoved), selectedLayer));
                        return;
                    }
                    break;
                #endregion
                #region Circle
                case PhysicsType.Circle:
                    difference = new System.Drawing.Point((int)pos.X - (int)_position.X, (int)pos.Y - (int)_position.Y);

                    rect = new Rectangle((int)_position.X, (int)_position.Y, difference.X, difference.Y);


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

                    difference.X = rect.Width;
                    difference.Y = rect.Height;
                    _position.X = rect.X;
                    _position.Y = rect.Y;

                    dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                    dialog.Setup((int)_position.X, (int)_position.Y, difference.X, difference.Y);

                    tempOM = _position;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        tempOM.X = (float)dialog.nudX.Value;
                        tempOM.Y = (float)dialog.nudy.Value;
                        difference.X = (int)dialog.nudWidth.Value;
                        difference.Y = (int)dialog.nudHeight.Value;



                        Vertices body = Vertices.CreateCircle(Math.Abs(difference.X), Math.Abs(difference.Y));

                        list2 = new Vertices();
                        vNew2 = new Vector2();
                        foreach (Vector2 v in body)
                        {
                            vNew2 = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                            list2.Add(vNew2);
                        }
                        collision = new CollisionData();
                        collision.AddRange(list2);
                        selectedLayer.CollisionData.Add(collision);
                        selectedCollision = collision;
                        collisionSettings.Setup(selectedCollision);


                        MainForm.MapEditorHistory[this].Do(new ColAddedHist(selectedCollision, new DataColAddDelegate(ColAdded), new DataColRemoveDelegate(ColRemoved), selectedLayer));
                        return;
                    }
                    break;
                #endregion
                #region Layout
                case PhysicsType.Layout:
                    FillTiles = new List<TileData>();
                    Vector2 point = _position;
                    float i = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                    float j = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
                    Vector2 p = new Vector2(i, j);
                    // Tile To Fill
                    tileToFill = GetTileR(p);

                    if (tileToFill != null)
                    {
                        // Fill
                        List<Vector2> stack = new List<Vector2>();
                        // Position
                        Vector2 position = Vector2.Zero;
                        // Y to go
                        float y1;
                        // Span direction
                        bool spanLeft, spanRight;

                        p = tileToFill.Position;
                        // Add the first vector to stack.
                        stack.Add(p);
                        // Loop stack
                        while (stack.Count > 0)
                        {
                            y1 = stack[0].Y;
                            position = stack[0];
                            while (y1 >= 0 && CheckTileEquality(tileToFill, GetFillTile(position)))
                            {
                                y1 -= gridHeight;
                                position.Y = y1;
                            }
                            y1 += gridHeight;
                            position.Y = y1;
                            spanLeft = spanRight = false;
                            while (y1 < map.Data.Size.Y && CheckTileEquality(tileToFill, GetFillTile(position)))
                            {
                                LayoutDo(position);
                                if (!spanLeft && position.X >= 0 && CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X - gridWidth, position.Y))))
                                {
                                    stack.Add(new Vector2(position.X - gridWidth, position.Y));
                                    spanLeft = true;
                                }
                                else if (spanLeft && position.X >= 0 && !CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X - gridWidth, position.Y))))
                                {
                                    spanLeft = false;
                                }
                                if (!spanRight && position.X <= map.Data.Size.X - gridWidth && CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X + gridWidth, position.Y))))
                                {
                                    stack.Add(new Vector2(position.X + gridWidth, position.Y));
                                    spanRight = true;
                                }
                                else if (spanRight && position.X <= map.Data.Size.X - gridWidth && !CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X + gridWidth, position.Y))))
                                {
                                    spanRight = false;
                                }
                                y1 += gridHeight;
                                position.Y = y1;
                            }
                            stack.RemoveAt(0);

                            if (stack.Count > (map.Data.Size.X / gridWidth) * (map.Data.Size.Y / gridHeight))
                                break;
                        }

                        if (FillTiles.Count > 0)
                        {
                            SortCollisionTiles();
                            int width = 0, height = FillTiles[0].DisplayRect.Height;
                            float x = 0, y = FillTiles[0].Position.Y;
                            int m = 0;
                            List<List<TileData>> markTiles = new List<List<TileData>>() { new List<TileData>() };
                            List<Point> markPoints = new List<Point>();
                            foreach (TileData tile in FillTiles)
                            {
                                if (y != tile.Position.Y)
                                {
                                    height += tile.DisplayRect.Height;
                                    x = 0;
                                    if (x > width) width = (int)x;
                                }
                                x += tile.DisplayRect.Width;

                                markTiles[m].Add(tile);

                                if (x > width) width = (int)x;

                                if (width > 1024 || height > 1024)
                                {
                                    markPoints.Add(new Point(width, height));
                                    width = 0;
                                    height = 0;
                                    markTiles.Add(new List<TileData>());
                                    m++;
                                }
                            }
                            markPoints.Add(new Point(width, height));

                            tempOM = FillTiles[0].Position;

                            list2 = new Vertices();
                            vNew2 = new Vector2();
                            m = 0;
                            for (int t = 0; t < markTiles.Count; t++)
                            {

                                System.Drawing.Bitmap bit = new System.Drawing.Bitmap(markPoints[t].X, markPoints[t].Y);
                                System.Drawing.Graphics gbit = System.Drawing.Graphics.FromImage(bit);

                                System.Drawing.Bitmap bit2 = GetTilesetBitmap(FillTiles[0].TilesetID);
                                tempOM = markTiles[t][0].Position;
                                foreach (TileData tile in markTiles[t])
                                {
                                    System.Drawing.RectangleF dest = new System.Drawing.RectangleF(tile.Position.X - tempOM.X, tile.Position.Y - tempOM.Y, tile.Width, tile.Height);
                                    System.Drawing.RectangleF source = new System.Drawing.RectangleF(tile.DisplayRect.X, tile.DisplayRect.Y, tile.Width, tile.Height);
                                    gbit.DrawImage(bit2, dest, source, System.Drawing.GraphicsUnit.Pixel);

                                }

                                Texture2D tex = Loader.TextureFromStream(graphicsDevice, bit, ImageFormat.Png);
                                //Create an array to hold the data from the texture
                                uint[] data = new uint[markPoints[t].X * markPoints[t].Y];
                                //Transfer the texture data to the array
                                tex.GetData(data);

                                //Calculate the vertices from the array
                                Vertices verts = Vertices.CreatePolygon(data, markPoints[t].X, markPoints[t].Y);

                                //Make sure that the origin of the texture is the centroid (real center of geometry)
                                Vector2 origin = -verts.GetCentroid();
                                pos = new Vector2(-gridWidth / 2, -gridHeight / 2);
                                verts.Translate(ref pos);
                                Vertices.Simplify(verts);

                                foreach (Vector2 v in verts)
                                {
                                    vNew2 = tempOM + v;
                                    list2.Add(vNew2);
                                }
                                break;
                            }
                            collision = new CollisionData();
                            list2 = Vertices.Simplify(list2);
                            collision.AddRange(list2);
                            selectedLayer.CollisionData.Add(collision);
                            selectedCollision = collision;
                            collisionSettings.Setup(selectedCollision);


                            MainForm.MapEditorHistory[this].Do(new ColAddedHist(selectedCollision, new DataColAddDelegate(ColAdded), new DataColRemoveDelegate(ColRemoved), selectedLayer));
                        }
                    }
                    break;
                #endregion
            }
        }

        private System.Drawing.Bitmap GetTilesetBitmap(int p)
        {
            TilesetData t = Global.GetData<TilesetData>(p, GameData.Tilesets);
            if (t != null)
            {
                MaterialData m = Global.GetData<MaterialData>(t.MaterialId, GameData.Materials);
                if (m != null)
                {
                    System.Drawing.Bitmap bit = new System.Drawing.Bitmap(Global.Project.Location + @"\" + m.FileName);
                    return bit;
                }
            }
            return null;
        }

        private void SortCollisionTiles()
        {
            FillTiles = FillTiles.OrderBy(x => x.Position.X).ThenBy(x => x.Position.Y).ToList();
        }
        /// <summary>
        /// LayoutDo
        /// </summary>
        /// <param name="point"></param>
        private bool LayoutDo(Vector2 p)
        {
            Vector2 point = p;
            Rectangle rect = new Rectangle(0, 0, (int)map.Data.Size.X + gridWidth, (int)map.Data.Size.Y + gridHeight);

            TileData t = GetTile(point);
            // Make sure we are still in map and that the tile is right
            if (rect.Contains(new Point((int)point.X, (int)point.Y)) && CheckTileEquality(tileToFill, t) && !FillTiles.Contains(t))
            {
                FillTiles.Add(t);
                // Continue this way
                return true;
            }
            // Break this way
            return false;
        }
        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool snaptogrid = SnapToGrid;
            System.Drawing.PointF p = camera.GetTransformedPoint(mousePoint);
            MainForm.mapEditor.mapEditor2.eventBtn_CheckedChanged(true);
            // Check if there is an event there
            selectedEvent = GetEvent(new Vector2(p.X, p.Y));
            if (selectedEvent != null)
            {
                if (selectedEvent is PlayerData)
                {
                    //if (!playerEditor.Visible)
                    //    playerEditor.Show(MainForm.curForm);
                    MainForm.playerEditor.Show(MainForm.Instance.dockPanel);
                    return;
                }
                //eventDialog = new MapEventDialog();
                eventDialog.SelectedEvent = selectedEvent;
                eventDialog.ShowDialog();
            }
            else
            {
                float x = (float)(p.X);
                float y = (float)(p.Y);
                if (snapToW || SnapToGrid)
                    x = (float)Math.Floor((double)(x / gridWidth)) * gridWidth;
                if (snapToH || SnapToGrid)
                    y = (float)Math.Floor((double)(y / gridHeight)) * gridHeight;
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                if (rect.Contains(x, y))
                {
                    EventData a = new EventData();
                    a.Name = Global.GetName("Event", Global.GetMapEventList(map.Data));
                    a.ID = Global.GetID(Global.GetMapEventList(map.Data));
                    selectedLayer.Events.Add(a.ID, a);
                    int index = a.ID;

                    MainForm.mapEventsExplorer.Setup();
                    EventPageData page = new EventPageData();
                    page.Enabled = true;
                    page.Name = Global.GetName("Page", a.Pages);
                    page.ID = Global.GetID(a.Pages);
                    a.MapID = map.Data.ID;
                    a.Pages.Add(page);
                    a.SelectedPage = 0;
                    selectedEvent = a;

                    a.Position = new Vector2((int)x, (int)y);
                    //eventDialog = new MapEventDialog();
                    eventDialog.SelectedEvent = selectedEvent;
                    eventDialog.ShowDialog();

                    SnapToGrid = snaptogrid;
                    // Event Added
                    selectedEvent = a;
                    MainForm.MapEditorHistory[this].Do(new EventAddedHist(selectedEvent, new DataEAddDelegate(EventAdded), new DataERemoveDelegate(EventRemoved), selectedLayer));

                }
            }
        }

        private void graphicsControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool snaptogrid = SnapToGrid;
            System.Drawing.PointF p = camera.GetTransformedPoint(mousePoint);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (tilesetViewer != null)
                {
                    if (showCollision && physicsBtn.Checked && !addingPhysics && selectedCollision != null)
                    {
                        ShowCollisionMenu();
                        return;
                    }
                    if (brushType == BrushType.EventSelection && map != null && map.Data != null)
                    {
                        // Check if there is an event there
                        selectedEvent = GetEvent(new Vector2(p.X, p.Y));
                        if (selectedEvent != null)
                        {
                            if (selectedEvent is PlayerData)
                            {
                                //if (!playerEditor.Visible)
                                //    playerEditor.Show(MainForm.curForm);
                                MainForm.playerEditor.Show(MainForm.Instance.dockPanel);
                                return;

                            }
                            //eventDialog = new MapEventDialog();
                            eventDialog.SelectedEvent = selectedEvent;
                            eventDialog.ShowDialog();
                        }
                        else
                        {
                            float x = (float)(p.X);
                            float y = (float)(p.Y);
                            if (snapToW || SnapToGrid)
                                x = (float)Math.Floor((double)(x / gridWidth)) * gridWidth;
                            if (snapToH || SnapToGrid)
                                y = (float)Math.Floor((double)(y / gridHeight)) * gridHeight;
                            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                            if (rect.Contains(x, y))
                            {
                                EventData a = new EventData();
                                a.Name = Global.GetName("Event", Global.GetMapEventList(map.Data));
                                a.ID = Global.GetID(Global.GetMapEventList(map.Data));
                                selectedLayer.Events.Add(a.ID, a);
                                int index = a.ID;

                                MainForm.mapEventsExplorer.Setup();
                                EventPageData page = new EventPageData();
                                page.Enabled = true;
                                page.Name = Global.GetName("Page", a.Pages);
                                page.ID = Global.GetID(a.Pages);
                                a.MapID = map.Data.ID;
                                a.Pages.Add(page);
                                a.SelectedPage = 0;
                                selectedEvent = a;

                                //eventDialog = new MapEventDialog();
                                eventDialog.SelectedEvent = selectedEvent;
                                eventDialog.ShowDialog();

                                SnapToGrid = snaptogrid;
                                // Event Added
                                selectedEvent = a;
                                MainForm.MapEditorHistory[this].Do(new EventAddedHist(selectedEvent, new DataEAddDelegate(EventAdded), new DataERemoveDelegate(EventRemoved), selectedLayer));

                                a.Position = new Vector2((int)x, (int)y);
                            }
                        }
                    }
                    else if (selectedTile != null && map != null && map.Data != null)
                    {
                        ShowTileMenu();
                    }
                }
                else
                {
                    TileEventArgs targs = new TileEventArgs(new List<TileData>());
                    targs.Position = new Vector2((int)p.X, (int)p.Y);
                    OnTileSelected(targs);
                }
            }
        }

        internal void EventAdded(EventAddedHist hist, IGameData data)
        {
            ((LayerData)hist.Parent).Events.Add(data.ID, (EventData)data);
            selectedEvent = (EventData)data;
        }

        internal void EventRemoved(EventRemovedHist hist, IGameData data)
        {
            ((LayerData)hist.Parent).Events.Remove(data.ID);

            if (selectedEvent == data)
                selectedEvent = null;
        }

        internal void ColAdded(ColAddedHist hist, CollisionData data)
        {
            ((LayerData)hist.Parent).CollisionData.Add(data);
            selectedCollision = data;
        }

        internal void ColRemoved(ColRemovedHist hist, CollisionData data)
        {
            ((LayerData)hist.Parent).CollisionData.Remove(data);

            if (selectedCollision == data)
                selectedCollision = null;
        }

        #region Tools
        /// <summary>
        /// Do Pencil
        /// </summary>
        /// <param name="originalMouse"></param>
        private void DoPencil(Vector2 point, bool moving)
        {
            // Get Grid Position
            float x;
            float y;
            Vector2 pos;
            // Add Tile
            bool gotOff;
            Vector2 off;
            if (SnapToGrid)
            {
                #region Tiled
                if (tilesetViewer.selectedTiles.Count > 0)
                {
                    switch (brushType)
                    {
                        #region Brush
                        case BrushType.Brush:
                            // Get Grid Position
                            x = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                            y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
                            pos = new Vector2(x, y);
                            float lastX = (float)Math.Floor((double)(lastMouse.X / gridWidth)) * gridWidth;
                            float lastY = (float)Math.Floor((double)(lastMouse.Y / gridHeight)) * gridHeight;
                            if (lastX != x || lastY != y)
                            {
                                float originalX = (float)Math.Floor((double)(originalMouse.X / gridWidth)) * gridWidth;
                                float originalY = (float)Math.Floor((double)(originalMouse.Y / gridHeight)) * gridHeight;

                                float diffX = Math.Abs(originalX - x);
                                float diffY = Math.Abs(originalY - y);

                                int lastXTile = 0;
                                int lastYTile = 0;
                                int countX = 1;
                                int countY = 0;
                                // Add Tile
                                gotOff = false;
                                off = Vector2.Zero;
                                TileData tile;

                                List<List<TileData>> table = new List<List<TileData>>();
                                int tIndex = 0;
                                float oldX = tilesetViewer.selectedTiles[0].DisplayRect.X;
                                foreach (TileData s in tilesetViewer.selectedTiles)
                                {
                                    if (s.DisplayRect.X > oldX) tIndex++; oldX = s.DisplayRect.X;
                                    if (tIndex > table.Count - 1) table.Add(new List<TileData>());
                                    table[tIndex].Add(s);
                                }

                                if (diffX / gridWidth >= table.Count)
                                {
                                    originalMouse.X = currentMouse.X;
                                    diffX = 0;
                                }
                                if (diffY / gridHeight >= table[0].Count)
                                {
                                    originalMouse.Y = currentMouse.Y;
                                    diffY = 0;
                                }
                                Vector2 tileSize = new Vector2();
                                for (int i = (int)diffX; i < table.Count; i++)
                                {
                                    for (int z = (int)diffY; z < table[i].Count; z++)
                                    {
                                        tile = table[i][z];


                                        // Get Off set
                                        if (!gotOff)
                                        {
                                            off = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                            gotOff = true;
                                        }
                                        if ((diffX <= tile.DisplayRect.X - off.X && diffY <= tile.DisplayRect.Y - off.Y))
                                        {
                                            tileSize.X = tile.Width;
                                            tileSize.Y = tile.Height;
                                            // 
                                            Vector2 c = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                            Vector2 pp = (c - off) + pos + tileSize / 2;

                                            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                                            if (rect.Contains(pp.X, pp.Y) && !TilesContain(commitalTiles, tile, pp))
                                            {
                                                //// Create Tile
                                                //List<TileData> rt = ClearTiles(pp);
                                                //if (rt != null && rt.Count > 0)
                                                //{
                                                //    foreach (TileData rep in rt)
                                                //    {
                                                //        if (!tilesHistory.Contains(rep) && !tilesReplacedHistory.Contains(rep))
                                                //        {
                                                //            tilesReplacedHistory.Add(rep);
                                                //        }
                                                //    }
                                                //}



                                                TileData commit = new TileData();
                                                tileSize.X = tile.Width;
                                                tileSize.Y = tile.Height;
                                                commit.Position = new Vector2((int)pp.X, (int)pp.Y);
                                                commit.Opacity = tile.Opacity;
                                                commit.Scale = tile.Scale;
                                                commit.Rotation = tile.Rotation;
                                                commit.HorizontalFlip = tile.HorizontalFlip;
                                                commit.VerticalFlip = tile.VerticalFlip;
                                                commit.Width = tile.Width;
                                                commit.Height = tile.Height;
                                                commit.Body = tile.Body;
                                                commit.IsSensor = tile.IsSensor;
                                                commit.IsStatic = tile.IsStatic;
                                                commit.Tag = tile.Tag;
                                                if (tilesetViewer.SelectedTileset != null) commit.TilesetID = tilesetViewer.SelectedTileset.ID;
                                                commit.DisplayRect = tile.DisplayRect;
                                                commit.SetRectangle();
                                                commitalTiles.Add(commit);

                                                needsCommit = true;

                                                //TileData newTile = new TileData();
                                                //newTile.Position = new Vector2((int)pp.X, (int)pp.Y);
                                                //newTile.Width = tile.Width;
                                                //newTile.Height = tile.Height;
                                                //newTile.DisplayRect = tile.DisplayRect;
                                                //newTile.TilesetID = tile.TilesetID;
                                                //newTile.Opacity = tile.Opacity;
                                                //newTile.Scale = tile.Scale;
                                                //newTile.Rotation = tile.Rotation;
                                                //newTile.HorizontalFlip = tile.HorizontalFlip;
                                                //newTile.VerticalFlip = tile.VerticalFlip;
                                                //newTile.Body = tile.Body;
                                                //newTile.IsSensor = tile.IsSensor;
                                                //newTile.IsStatic = tile.IsStatic;
                                                //newTile.Tag = tile.Tag;
                                                //newTile.SetRectangle();
                                                //selectedLayer.Tiles.Add(newTile);
                                                //tilesHistory.Add(newTile);
                                                //commitalTiles.Add(newTile);
                                            }
                                        }
                                    }
                                }
                                return;
                            }
                            break;
                        #endregion
                        #region Rectangle
                        case BrushType.Rectangle:
                            needsCommit = false;
                            if (tilesetViewer.selectedTiles.Count > 0)
                            {
                                // Get Grid Position
                                x = (float)Math.Floor((double)(originalMouse.X / gridWidth)) * gridWidth;
                                y = (float)Math.Floor((double)(originalMouse.Y / gridHeight)) * gridHeight;
                                point.X = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                                point.Y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
                                pos = new Vector2(x, y);
                                // Add Tile
                                gotOff = false;
                                // Get Off set
                                List<List<TileData>> table = new List<List<TileData>>();
                                int tIndex = 0;
                                float oldX = tilesetViewer.selectedTiles[0].DisplayRect.X;
                                foreach (TileData s in tilesetViewer.selectedTiles)
                                {
                                    if (s.DisplayRect.X > oldX) tIndex++; oldX = s.DisplayRect.X;
                                    if (tIndex > table.Count - 1) table.Add(new List<TileData>());
                                    table[tIndex].Add(s);
                                }
                                // Clear Tiles
                                commitalTiles.Clear();
                                tilesHistory.Clear();

                                int rec_selectwidth = (int)(point.X - x);
                                int rec_selectheight = (int)(point.Y - y);

                                int rec_x = (int)x;
                                int rec_y = (int)y;
                                int rec_width = rec_selectwidth;
                                int rec_height = rec_selectheight;

                                if (rec_selectwidth < 0)
                                {
                                    rec_x = (int)x + rec_selectwidth;
                                    rec_width = Math.Abs(rec_selectwidth);
                                }
                                if (rec_selectheight < 0)
                                {
                                    rec_y = (int)y + rec_selectheight;
                                    rec_height = Math.Abs(rec_selectheight);
                                }
                                // If selection width/height is zero, it means only one tile.
                                rec_width += gridWidth;
                                rec_height += gridHeight;

                                Vector2 tileSize = new Vector2();
                                // Loop through selected tiles and add as needed to map.
                                int j = 0, k = 0;
                                for (float i = rec_x; i < rec_x + rec_width; i += gridWidth)
                                {
                                    for (float z = rec_y; z < rec_y + rec_height; z += gridHeight)
                                    {
                                        TileData sTile = table[j][k];
                                        TileData commit = new TileData();
                                        tileSize.X = sTile.Width;
                                        tileSize.Y = sTile.Height;
                                        commit.Position = new Vector2((int)i, (int)z) + tileSize / 2;
                                        commit.Opacity = sTile.Opacity;
                                        commit.Scale = sTile.Scale;
                                        commit.Rotation = sTile.Rotation;
                                        commit.HorizontalFlip = sTile.HorizontalFlip;
                                        commit.VerticalFlip = sTile.VerticalFlip;
                                        commit.Width = sTile.Width;
                                        commit.Height = sTile.Height;
                                        commit.Body = sTile.Body;
                                        commit.IsSensor = sTile.IsSensor;
                                        commit.IsStatic = sTile.IsStatic;
                                        commit.Tag = sTile.Tag;
                                        if (tilesetViewer.SelectedTileset != null) commit.TilesetID = tilesetViewer.SelectedTileset.ID;
                                        commit.DisplayRect = sTile.DisplayRect;
                                        commit.SetRectangle();
                                        commitalTiles.Add(commit);
                                        // History
                                        //tilesHistory.Add(commit);

                                        k++; if (k >= table[j].Count) k = 0;
                                    }
                                    j++; if (j >= table.Count) j = 0;
                                    k = 0;
                                }
                                needsCommit = true;
                            }
                            break;
                        #endregion
                        #region Line
                        case BrushType.Line:

                            break;
                        #endregion
                        #region Fill
                        case BrushType.Fill:
                            if (!moving && !isFilling)
                            {
                                isFilling = true;
                                Fill(point);
                                //Thread fillThread = new Thread(new ParameterizedThreadStart(this.Fill));
                                //fillThread.Start(point);
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
                #region Autotile
                else if (MainForm.tilesExplorer.autoTileViewer1.selectedTile != null)
                {
                    switch (brushType)
                    {
                        case BrushType.Brush:
                            // Get Grid Position
                            x = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                            y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
                            pos = new Vector2(x, y);
                            float lastX = (float)Math.Floor((double)(lastMouse.X / gridWidth)) * gridWidth;
                            float lastY = (float)Math.Floor((double)(lastMouse.Y / gridHeight)) * gridHeight;
                            if (lastX != x || lastY != y)
                            {

                            }
                            break;
                    }
                }
                #endregion
            }
            else
            {
                switch (brushType)
                {
                    #region Brush
                    case BrushType.Brush:
                        if (!moving)
                        {
                            x = point.X; y = point.Y;
                            if (snapToW)
                                x = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth + gridWidth / 2;
                            if (snapToH)
                                y = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight + gridHeight / 2;
                            pos = new Vector2(x, y);
                            // Add Tile
                            gotOff = false;
                            off = Vector2.Zero;
                            List<TileData> hist = new List<TileData>();
                            foreach (TileData tile in tilesetViewer.selectedTiles)
                            {
                                // Get Off set
                                if (!gotOff)
                                {
                                    off = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                    gotOff = true;
                                }
                                // 
                                Vector2 c = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                Vector2 pp = (c - off) + pos;

                                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                                //if (rect.Contains(pp.X, pp.Y))
                                //{
                                // Create Tile

                                // List<TileData> rt = ClearTiles(pp);
                                //  if (rt != null && rt.Count > 0)
                                // {
                                // foreach (TileData rep in rt)
                                //  {
                                //  if (!tilesHistory.Contains(rep) && !tilesReplacedHistory.Contains(rep))
                                //  {
                                // tilesReplacedHistory.Add(rep);
                                // }
                                // }
                                // }
                                TileData newTile = new TileData();
                                newTile.Position = new Vector2((int)pp.X, (int)pp.Y);
                                newTile.Width = tile.Width;
                                newTile.Height = tile.Height;
                                newTile.DisplayRect = tile.DisplayRect;
                                newTile.TilesetID = tile.TilesetID;
                                newTile.Opacity = tile.Opacity;
                                newTile.Scale = tile.Scale;
                                newTile.Rotation = tile.Rotation;
                                newTile.HorizontalFlip = tile.HorizontalFlip;
                                newTile.Body = tile.Body;
                                newTile.IsSensor = tile.IsSensor;
                                newTile.IsStatic = tile.IsStatic;
                                newTile.Tag = tile.Tag;
                                newTile.SetRectangle();
                                selectedLayer.Tiles.Add(newTile);
                                tilesHistory.Add(newTile);
                                //}
                            }
                            //MainForm.MapEditorHistory[this].Do(new TilesHist(hist, true, selectedLayer.Tiles));
                        }
                        break;
                    #endregion
                    #region Rectangle
                    case BrushType.Rectangle:
                        needsCommit = false;
                        if (tilesetViewer.selectedTiles.Count > 0)
                        {
                            // Get Grid Position
                            x = originalMouse.X;
                            y = originalMouse.Y;
                            pos = new Vector2(x, y);
                            // Get Off set
                            List<List<TileData>> table = new List<List<TileData>>();
                            int tIndex = 0;
                            float oldX = tilesetViewer.selectedTiles[0].DisplayRect.X;
                            foreach (TileData s in tilesetViewer.selectedTiles)
                            {
                                if (s.DisplayRect.X > oldX) tIndex++; oldX = s.DisplayRect.X;
                                if (tIndex > table.Count - 1) table.Add(new List<TileData>());
                                table[tIndex].Add(s);
                            }
                            // Clear Tiles
                            commitalTiles.Clear();
                            int rec_selectwidth = (int)(point.X - x);
                            int rec_selectheight = (int)(point.Y - y);
                            int rec_x = (int)x;
                            int rec_y = (int)y;
                            int rec_width = rec_selectwidth;
                            int rec_height = rec_selectheight;

                            if (rec_selectwidth < 0)
                            {
                                rec_x = (int)x + rec_selectwidth;
                                rec_width = Math.Abs(rec_selectwidth);
                            }
                            if (rec_selectheight < 0)
                            {
                                rec_y = (int)y + rec_selectheight;
                                rec_height = Math.Abs(rec_selectheight);
                            }
                            // If selection width/height is zero, it means only one tile.
                            rec_width += (int)tilesetViewer.selectedTiles[0].Width;
                            //rec_height += (int)tilesetViewer.selectedTiles[0].Height;
                            // Loop through selected tiles and add as needed to map.
                            int j = 0, k = 0;
                            for (float i = rec_x; i < rec_x + rec_width; i += tilesetViewer.selectedTiles[0].Width)
                            {
                                for (float z = rec_y; z < rec_y + rec_height; z += tilesetViewer.selectedTiles[0].Height)
                                {
                                    TileData commit = new TileData();
                                    commit.Position = new Vector2(i, z);
                                    TileData sTile = table[j][k];
                                    commit.Opacity = sTile.Opacity;
                                    commit.Scale = sTile.Scale;
                                    commit.Rotation = sTile.Rotation;
                                    commit.HorizontalFlip = sTile.HorizontalFlip;
                                    commit.VerticalFlip = sTile.VerticalFlip;
                                    commit.Width = sTile.Width;
                                    commit.Height = sTile.Height;
                                    commit.Body = sTile.Body;
                                    commit.IsSensor = sTile.IsSensor;
                                    commit.IsStatic = sTile.IsStatic;
                                    commit.Tag = sTile.Tag;
                                    if (tilesetViewer.SelectedTileset != null) commit.TilesetID = sTile.TilesetID;
                                    commit.DisplayRect = sTile.DisplayRect;
                                    commit.SetRectangle();
                                    commitalTiles.Add(commit);
                                    k++; if (k >= table[j].Count) k = 0;
                                }
                                j++; if (j >= table.Count) j = 0;
                                k = 0;
                            }
                            needsCommit = true;
                        }
                        break;
                    #endregion
                }
            }
            lastMouse = point;
        }

        private bool TilesContain(List<TileData> commitalTiles, TileData tile, Vector2 pp)
        {
            for (int i = 0; i < commitalTiles.Count; i++)
            {
                if (commitalTiles[i].Position == pp && CheckTileEquality(tile, commitalTiles[i]))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Fill
        /// </summary>
        /// <param name="point"></param>
        /// 
        List<TileData> FillTiles;
        private void Fill(Object pObj)
        {
            if (tilesetViewer.selectedTiles.Count > 0)
            {
                FillTiles = new List<TileData>();
                Vector2 point = (Vector2)pObj;
                float i = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
                float j = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
                Vector2 p = new Vector2(i, j);
                // Tile To Fill
                tileToFill = GetFillTile(p);
                // Tile Doing The Filling
                tileFilling = tilesetViewer.selectedTiles[0];
                if (tileFilling != null && !CheckTileEquality(tileToFill, tileFilling))
                {
                    // Fill
                    List<Vector2> stack = new List<Vector2>();
                    // Position
                    Vector2 position = Vector2.Zero;
                    // Y to go
                    float y1;
                    // Span direction
                    bool spanLeft, spanRight;


                    // Add the first vector to stack.
                    stack.Add(p);
                    // Loop stack
                    while (stack.Count > 0)
                    {
                        y1 = stack[0].Y;
                        position = stack[0];
                        while (y1 >= 0 && CheckTileEquality(tileToFill, GetFillTile(position)))
                        {
                            y1 -= gridHeight;
                            position.Y = y1;
                        }
                        y1 += gridHeight;
                        position.Y = y1;
                        spanLeft = spanRight = false;
                        while (y1 < map.Data.Size.Y && CheckTileEquality(tileToFill, GetFillTile(position)))
                        {
                            FillDo(position);
                            if (!spanLeft && position.X >= 0 && CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X - gridWidth, position.Y))))
                            {
                                stack.Add(new Vector2(position.X - gridWidth, position.Y));
                                spanLeft = true;
                            }
                            else if (spanLeft && position.X >= 0 && !CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X - gridWidth, position.Y))))
                            {
                                spanLeft = false;
                            }
                            if (!spanRight && position.X <= map.Data.Size.X - gridWidth && CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X + gridWidth, position.Y))))
                            {
                                stack.Add(new Vector2(position.X + gridWidth, position.Y));
                                spanRight = true;
                            }
                            else if (spanRight && position.X <= map.Data.Size.X - gridWidth && !CheckTileEquality(tileToFill, GetFillTile(new Vector2(position.X + gridWidth, position.Y))))
                            {
                                spanRight = false;
                            }
                            y1 += gridHeight;
                            position.Y = y1;
                        }
                        stack.RemoveAt(0);

                        if (stack.Count > (map.Data.Size.X / gridWidth) * (map.Data.Size.Y / gridHeight))
                            break;
                    }

                    if (FillTiles.Count > 0)
                    {
                        List<Vector2> positions = new List<Vector2>();
                        for (int m = 0; m < FillTiles.Count; m++)
                            positions.Add(FillTiles[m].Position);
                        // Clear Tile
                        List<TileData> rt = ClearTiles(positions);
                        if (rt != null && rt.Count > 0)
                            tilesReplacedHistory.AddRange(rt);
                    }
                }
            }
            isFilling = false;
        }
        /// <summary>
        /// Fill up
        /// </summary>
        /// <param name="point"></param>
        private bool FillDo(Vector2 p)
        {
            Vector2 point = p;
            Rectangle rect = new Rectangle(0, 0, (int)map.Data.Size.X + gridWidth, (int)map.Data.Size.Y + gridHeight);

            // Make sure we are still in map and that the tile is right
            if (rect.Contains(new Point((int)point.X, (int)point.Y)) && CheckTileEquality(tileToFill, GetTile(point)))
            {
                // Add new tile
                TileData newTile = new TileData();
                newTile.Position = point;
                newTile.Width = tileFilling.Width;
                newTile.Height = tileFilling.Height;
                newTile.DisplayRect = tileFilling.DisplayRect;
                newTile.TilesetID = tileFilling.TilesetID;
                newTile.Opacity = tileFilling.Opacity;
                newTile.Scale = tileFilling.Scale;
                newTile.Rotation = tileFilling.Rotation;
                newTile.HorizontalFlip = tileFilling.HorizontalFlip;
                newTile.Body = tileFilling.Body;
                newTile.IsSensor = tileFilling.IsSensor;
                newTile.IsStatic = tileFilling.IsStatic;
                newTile.Tag = tileFilling.Tag;
                newTile.SetRectangle();

                FillTiles.Add(newTile);

                // History
                tilesHistory.Add(newTile);

                // Continue this way
                return true;
            }
            // Break this way
            return false;
        }
        /// <summary>
        /// Check if tiles are equal.
        /// </summary>
        /// <param name="tileToFill"></param>
        /// <param name="tileData"></param>
        /// <returns></returns>
        private bool CheckTileEquality(TileData tile1, TileData tile2)
        {
            if (tile1 == null || tile2 == null) return false;
            if (tile1 == tile2)
                return true;
            if (tile1.TilesetID == tile2.TilesetID && tile1.DisplayRect == tile2.DisplayRect)
                return true;
            return false;
        }
        /// <summary>
        /// Eraser action
        /// </summary>
        /// <param name="point"></param>
        private void DoEraser(Vector2 point)
        {
            try
            {
                point.X = Math.Min(point.X, map.Size.X);
                point.X = Math.Max(point.X, 0);
                point.Y = Math.Min(point.Y, map.Size.Y);
                point.Y = Math.Max(point.Y, 0);

                BrushType oldBrush = brushType;
                switch (brushType)
                {
                    case BrushType.Brush:
                        brushType = BrushType.EraserBrush;
                        break;
                    case BrushType.Fill:
                        brushType = BrushType.EraserRect;
                        break;
                    case BrushType.Rectangle:
                        brushType = BrushType.EraserFill;
                        break;
                }

                if (selectedLayer != null)
                {
                    switch (brushType)
                    {
                        #region Brush
                        case BrushType.EraserBrush:
                            List<TileData> tiles = new List<TileData>();
                            for (int j = selectedLayer.Tiles.Count - 1; j > -1; j--)
                            {
                                if (selectedLayer.Tiles[j].RectangleF.Contains(point.X, point.Y))
                                {
                                    tiles.Add(selectedLayer.Tiles[j]); break;
                                }
                            }
                            tilesReplacedHistory.AddRange(tiles);
                            foreach (TileData r in tiles)
                            {
                                selectedLayer.Tiles.Remove(r);
                            }
                            //MainForm.MapEditorHistory[this].Do(new TilesHist(tiles, false, selectedLayer.Tiles));

                            break;
                        #endregion
                        #region Rectangle
                        case BrushType.EraserRect:
                            tilesToRemove.Clear();
                            // Clear Tiles
                            int rec_selectwidth = (int)(point.X - originalMouse.X);
                            int rec_selectheight = (int)(point.Y - originalMouse.Y);
                            int rec_x = (int)originalMouse.X;
                            int rec_y = (int)originalMouse.Y;
                            int rec_width = rec_selectwidth;
                            int rec_height = rec_selectheight;

                            if (rec_selectwidth < 0)
                            {
                                rec_x = (int)originalMouse.X + rec_selectwidth;
                                rec_width = Math.Abs(rec_selectwidth);
                            }
                            if (rec_selectheight < 0)
                            {
                                rec_y = (int)originalMouse.Y + rec_selectheight;
                                rec_height = Math.Abs(rec_selectheight);
                            }

                            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(rec_x, rec_y, rec_width, rec_height);

                            foreach (TileData tile in selectedLayer.Tiles)
                            {
                                if (rect.IntersectsWith(tile.RectangleF))
                                {
                                    if (!tilesToRemove.Contains(tile))
                                        tilesToRemove.Add(tile);
                                }
                            }
                            break;
                        #endregion
                        #region Line
                        case BrushType.Line:

                            break;
                        #endregion
                        #region Fill
                        case BrushType.EraserFill:
                            if (!isFilling)
                            {
                                isFilling = true;
                                EraseFill(point);
                                selectedTile = null;
                            }
                            break;
                        #endregion
                    }
                }
                brushType = oldBrush;
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "29x001");
            }
        }
        /// <summary>
        /// Erase fill
        /// </summary>
        /// <param name="point"></param>
        private void EraseFill(Vector2 point)
        {
            float i = (float)Math.Floor((double)(point.X / gridWidth)) * gridWidth;
            float j = (float)Math.Floor((double)(point.Y / gridHeight)) * gridHeight;
            Vector2 p = new Vector2(i, j);
            List<TileData> rt;
            // Tile To Fill
            tileToFill = GetTile(p);
            if (!CheckTileEquality(tileToFill, null))
            {
                List<Vector2> eraseAt = new List<Vector2>();
                // Fill
                List<Vector2> stack = new List<Vector2>();
                // Position
                Vector2 position = Vector2.Zero;
                // Y to go
                float y1;
                // Span direction
                bool spanLeft, spanRight;
                // Add the first vector to stack.
                stack.Add(p);
                // Loop stack
                while (stack.Count > 0)
                {
                    y1 = stack[0].Y;
                    position = stack[0];
                    while (y1 >= 0 && CheckTileEquality(tileToFill, GetTile(position)))
                    {
                        y1 -= gridHeight;
                        position.Y = y1;
                    }
                    y1 += gridHeight;
                    position.Y = y1;
                    spanLeft = spanRight = false;
                    while (y1 < map.Data.Size.Y && CheckTileEquality(tileToFill, GetTile(position)))
                    {
                        eraseAt.Add(position);

                        if (!spanLeft && position.X >= 0 && CheckTileEquality(tileToFill, GetTile(new Vector2(position.X - gridWidth, position.Y))))
                        {
                            stack.Add(new Vector2(position.X - gridWidth, position.Y));
                            spanLeft = true;
                        }
                        else if (spanLeft && position.X >= 0 && !CheckTileEquality(tileToFill, GetTile(new Vector2(position.X - gridWidth, position.Y))))
                        {
                            spanLeft = false;
                        }
                        if (!spanRight && position.X <= map.Data.Size.X - gridWidth && CheckTileEquality(tileToFill, GetTile(new Vector2(position.X + gridWidth, position.Y))))
                        {
                            stack.Add(new Vector2(position.X + gridWidth, position.Y));
                            spanRight = true;
                        }
                        else if (spanRight && position.X <= map.Data.Size.X - gridWidth && !CheckTileEquality(tileToFill, GetTile(new Vector2(position.X + gridWidth, position.Y))))
                        {
                            spanRight = false;
                        }
                        y1 += gridHeight;
                        position.Y = y1;
                    }
                    stack.RemoveAt(0);

                    if (stack.Count > (map.Data.Size.X / gridWidth) * (map.Data.Size.Y / gridHeight))
                        break;
                }
                rt = ClearTiles(eraseAt);

                if (rt != null && rt.Count > 0)
                    tilesReplacedHistory.AddRange(rt);
            }
            isFilling = false;
        }

        private void SelectObject(Vector2 point)
        {
            if (brushType != BrushType.EventSelection)
            {
                if (brushType == BrushType.CursorSingle)
                {
                    if (selectedTile != null)
                    {
                        if (selectedTile.GetTopRight().Contains(point.X, point.Y))
                        {
                            IsMouseDown = false;
                            ShowTileMenu();
                            return;
                        }

                        if (selectedTile.GetTopLeft().Contains(point.X, point.Y))
                        {
                            transType = Transformation.Rotate;
                            originalRotation = selectedTile.Rotation;
                            selectedTile.SetOffSet(out mouseOffx, out mouseOffy, point);
                            return;
                        }

                        if (selectedTile.GetBottomRight().Contains(point.X, point.Y))
                        {
                            transType = Transformation.Scale;
                            originalScale = selectedTile.Scale;
                            selectedTile.SetOffSet(out mouseOffx, out mouseOffy, point);
                            return;
                        }
                    }
                    transType = Transformation.Move;
                    SelectedTile = GetTileR(point);
                    if (selectedTile != null)
                    {
                        selectedTile.SetOffSet(out mouseOffx, out mouseOffy, point);
                        tbOpacity.Value = (float)selectedTile.Opacity;
                    }


                    // MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = SelectedTile;
                }
                else
                {
                    Point lp = new Point((int)point.X, (int)point.Y);
                    // Erase the selection rect and start a new one.
                    if (!SelectdTilesContains(lp))
                    {
                        if (selectedTiles.Length > 0)
                        {
                            for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                            {
                                if (selectedTiles[layerIndex] != null)
                                {
                                    List<Vector2> selectedNewPositions = new List<Vector2>();
                                    // Move the selcted tiles
                                    int offIndex = 0;
                                    List<Vector2> positions = new List<Vector2>();
                                    foreach (TileData tile in selectedTiles[layerIndex])
                                        positions.Add(tile.Position);

                                    List<TileData> rt = ClearTiles(positions);
                                    if (rt != null && rt.Count > 0)
                                    {
                                        foreach (TileData rep in rt)
                                        {
                                            if (!tilesReplacedHistory.Contains(rep))
                                            {
                                                tilesReplacedHistory.Add(rep);
                                            }
                                        }
                                    }

                                    foreach (TileData tile in selectedTiles[layerIndex])
                                    {
                                        if (selectedOriginalPos != null && selectedOriginalPos[layerIndex] != null && offIndex < selectedOriginalPos[layerIndex].Count)
                                        {
                                            // Add it to new position
                                            if (selectedOriginalPos[layerIndex][offIndex] != tile.Position)
                                            {
                                                modified = true;
                                            }
                                        }

                                        tilesReplacedHistory.Remove(tile);

                                        map.Data.Layers[layerIndex].Tiles.Add(tile);
                                        tilesHistory.Add(tile);
                                        offIndex++;
                                    }
                                    foreach (TileData rep in tilesHistory)
                                    {
                                        tilesReplacedHistory.Remove(rep);
                                    }
                                    if (tilesHistory.Count > 0)
                                    {
                                        // If pasted, just add, don't move
                                        if (pasted)
                                        {
                                            MainForm.MapEditorHistory[this].Do(new TilesAdded(tilesHistory, tilesReplacedHistory, map.Data.Layers[layerIndex].Tiles, new DataTRemoveDelegate(TileRemoved)));
                                        }
                                        else
                                        {

                                            if (modified)
                                            {
                                                foreach (TileData tile in tilesHistory)
                                                {
                                                    selectedNewPositions.Add(tile.Position);
                                                }
                                                MainForm.MapEditorHistory[this].Do(new TilesMoved(tilesHistory, tilesReplacedHistory, selectedOriginalPos[layerIndex], selectedNewPositions, map.Data.Layers[layerIndex].Tiles));
                                            }
                                        }
                                    }
                                    modified = false;
                                    tilesReplacedHistory.Clear();
                                    tilesHistory.Clear();

                                    MainForm.HistoryExplorer.UndoRedoEnabled = true;
                                }
                            }
                        }
                        // MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = SelectedTile;
                        // MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = GetSelectedTiles();
                        pasted = false;
                        ClearSelected();
                        selectedTiles = new List<TileData>[0];
                        selectionRectangle.X = lp.X - 1;
                        selectionRectangle.Y = lp.Y - 1;
                        selectionRectangle.Width = 0;
                        selectionRectangle.Height = 0;
                        selectedOriginalPos = null;
                    }
                    else if (selectedTiles.Count() > 0)
                    {
                        selectedOffsets = new List<Vector2>[map.Data.Layers.Count];
                        bool doOrg = false;
                        if (selectedOriginalPos == null)
                            doOrg = true;
                        if (doOrg)
                            selectedOriginalPos = new List<Vector2>[map.Data.Layers.Count];
                        selectRectOffset = (new Vector2(lp.X, lp.Y)) - (new Vector2(selectionRectangle.X, selectionRectangle.Y));
                        for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                        {
                            if (selectedTiles[layerIndex] != null)
                            {
                                selectedOffsets[layerIndex] = new List<Vector2>();
                                if (doOrg)
                                    selectedOriginalPos[layerIndex] = new List<Vector2>();
                                foreach (TileData tile in selectedTiles[layerIndex])
                                {
                                    selectedOffsets[layerIndex].Add(new Vector2(lp.X, lp.Y) - tile.Position);
                                    if (doOrg)
                                        selectedOriginalPos[layerIndex].Add(tile.Position);
                                }
                            }
                        }
                        // MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = SelectedTile;
                        // MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = GetSelectedTiles();


                    }
                }
            }
            else
            {
                selectedEvent = GetEvent(point);
                eventSettings.SelectedEvent = selectedEvent;
                if (selectedEvent != null && selectedEvent.GetRectangle(gridWidth, gridHeight).Contains(point.X, point.Y))
                {
                    ShowEventMenu();
                    if (selectedEvent.GetTopLeft(selectedEvent.Canvas).Contains(point.X, point.Y))
                    {
                        transType = Transformation.Rotate;
                        originalRotation = selectedEvent.Rotation;
                        selectedEvent.SetOffSet(out mouseOffx, out mouseOffy, point);
                        return;
                    }
                    transType = Transformation.Move;
                    selectedEvent.SetOffSet(out mouseOffx, out mouseOffy, point);
                }
                else
                {
                    transType = Transformation.Move;
                    selectedEvent = GetEvent(point);
                    if (selectedEvent != null)
                        selectedEvent.SetOffSet(out mouseOffx, out mouseOffy, point);
                }
                // MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = selectedEvent;
            }
        }

        private void SelectLayer(Vector2 point)
        {
            if (selectedLayerBG != null)
            {
                layerSettings.SelectedBG = selectedLayerBG;
                ShowLayerMenu();
                if (selectedLayerBG.GetTopRight().Contains(point.X, point.Y))
                {
                    IsMouseDown = false;
                    //ShowLayerMenu();
                    return;
                }

                if (selectedLayerBG.GetTopLeft().Contains(point.X, point.Y))
                {
                    transType = Transformation.Rotate;
                    originalRotation = selectedLayerBG.Rotation;
                    selectedLayerBG.SetOffSet(out mouseOffx, out mouseOffy, point);
                    return;
                }

                if (//selectedLayerBG.GetUpperLeft().Contains(point.X, point.Y) || selectedLayerBG.GetUpperRight().Contains(point.X, point.Y) ||
                    //selectedLayerBG.GetBottomLeft().Contains(point.X, point.Y) || 
                    selectedLayerBG.GetBottomRight().Contains(point.X, point.Y))
                {
                    transType = Transformation.Scale;
                    originalScale = selectedLayerBG.Size;
                    selectedLayerBG.SetOffSet(out mouseOffx, out mouseOffy, point);
                    return;
                }
            }
            transType = Transformation.Move;
            selectedLayerBG = GetBackground(point);
            if (selectedLayerBG != null)
            {
                selectedLayerBG.SetOffSet(out mouseOffx, out mouseOffy, point);
                ShowLayerMenu();
            }

            layerSettings.SelectedBG = selectedLayerBG;
            // MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = selectedLayerBG;
        }

        private LayerBackground GetBackground(Vector2 point)
        {
            for (int i = selectedLayer.Backgrounds.Count - 1; i > -1; i--)
            {
                if ((((selectedLayer.Backgrounds[i].Position.X - selectedLayer.Backgrounds[i].Size.X / 2 <= point.X) && (point.X < (selectedLayer.Backgrounds[i].Position.X + selectedLayer.Backgrounds[i].Size.X / 2))) && (selectedLayer.Backgrounds[i].Position.Y - selectedLayer.Backgrounds[i].Size.Y / 2 <= point.Y)) && (point.Y < (selectedLayer.Backgrounds[i].Position.Y + selectedLayer.Backgrounds[i].Size.Y / 2)))
                {
                    return selectedLayer.Backgrounds[i];
                }
            }
            return null;
        }


        private object[] GetSelectedTiles()
        {
            List<TileData> tiles = new List<TileData>();
            if (selectedTiles.Length > 0)
            {
                for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                {
                    if (selectedTiles[layerIndex] != null)
                    {
                        foreach (TileData tile in selectedTiles[layerIndex])
                        {
                            tiles.Add(tile);
                        }
                    }
                }
            }
            return tiles.ToArray();
        }

        private bool SelectdTilesContains(Point lp)
        {
            if (selectedTiles.Length > 0)
            {
                for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                {
                    if (selectedTiles[layerIndex] != null)
                    {
                        foreach (TileData tile in selectedTiles[layerIndex])
                        {
                            if (tile.RectangleF.Contains(lp.X, lp.Y))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void CursorMove(System.Drawing.PointF p)
        {
            if (brushType != BrushType.EventSelection)
            {
                if (brushType == BrushType.CursorSingle)
                {
                    if (selectedTile != null)
                    {
                        if (transType == Transformation.Move)
                        {

                            if (!original.ContainsKey(selectedTile.Position))
                            {
                                clones.Add(selectedTile.Position, selectedTile.Clone()); modified = true;
                                original.Add(selectedTile.Position, selectedTile);
                            }
                            float x = (float)(p.X - mouseOffx);
                            float y = (float)(p.Y - mouseOffy);
                            if (snapToW || SnapToGrid)
                                x = (float)Math.Floor((double)((p.X - mouseOffx) / gridWidth)) * gridWidth + gridWidth / 2;
                            if (snapToH || SnapToGrid)
                                y = (float)Math.Floor((double)((p.Y - mouseOffy) / gridHeight)) * gridHeight + gridHeight / 2;
                            // Add it to new position
                            selectedTile.Position = new Vector2((int)x, (int)y);
                            selectedTile.SetRectangle();

                        }
                        else if (transType == Transformation.Rotate)
                        {
                            if (!original.ContainsKey(selectedTile.Position))
                            {
                                clones.Add(selectedTile.Position, selectedTile.Clone()); modified = true;
                                original.Add(selectedTile.Position, selectedTile);
                            }
                            float x = originalMouse.X - p.X + originalRotation;
                            if (x <= 360 && x >= 0)
                                selectedTile.Rotation = x;
                            selectedTile.SetRectangle();
                        }
                        else if (transType == Transformation.Scale)
                        {
                            if (!original.ContainsKey(selectedTile.Position))
                            {
                                clones.Add(selectedTile.Position, selectedTile.Clone()); modified = true; original.Add(selectedTile.Position, selectedTile);
                            }
                            Vector2 s = new Vector2((float)(p.X - originalMouse.X) / 100 + originalScale.X, (float)(p.Y - originalMouse.Y) / 100 + originalScale.Y);
                            if (s.X < 0.25f) s.X = 0.25f;
                            if (s.Y < 0.25f) s.Y = 0.25f;
                            if (s.X > 10.0f) s.X = 10.0f;
                            if (s.Y > 10.0f) s.Y = 10.0f;
                            selectedTile.Scale = s;
                            selectedTile.SetRectangle();
                        }
                        tileSettings.SelectedTile = selectedTile;
                    }
                }
                else
                {
                    // It can only be move or select
                    // Check if clicking inside the selection rectangle
                    Point lp = new Point((int)p.X, (int)p.Y);
                    if (selectedTiles.Count() > 0)
                    {
                        int offIndex = 0;
                        for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                        {
                            if (selectedTiles[layerIndex] != null)
                            {
                                // Move the selcted tiles
                                offIndex = 0;
                                foreach (TileData tile in selectedTiles[layerIndex])
                                {
                                    float x = (float)(p.X - selectedOffsets[layerIndex][offIndex].X);
                                    float y = (float)(p.Y - selectedOffsets[layerIndex][offIndex].Y);
                                    if (snapToW || SnapToGrid)
                                        x = (float)Math.Floor((double)((p.X - selectedOffsets[layerIndex][offIndex].X) / gridWidth)) * gridWidth;
                                    if (snapToH || SnapToGrid)
                                        y = (float)Math.Floor((double)((p.Y - selectedOffsets[layerIndex][offIndex].Y) / gridHeight)) * gridHeight;
                                    // Add it to new position
                                    //map.Data.Layers[layerIndex].Tiles.Remove(tile);
                                    tile.Position = new Vector2((int)x - gridWidth / 2, (int)y - gridHeight / 2);
                                    tile.SetRectangle();
                                    // map.Data.Layers[layerIndex].Tiles.Add(tile);
                                    modified = true;
                                    offIndex++;
                                }
                            }
                        }
                    }
                    else
                    {
                        selectionRectangle.Width = lp.X - selectionRectangle.X;
                        selectionRectangle.Height = lp.Y - selectionRectangle.Y;
                    }
                }
            }
            else
            {
                if (selectedEvent != null)
                {
                    eventSettings.SelectedEvent = selectedEvent;
                    if (transType == Transformation.Move)
                    {
                        //if (!originalE.Contains(selectedEvent))
                        //{
                        //    clones.Add(selectedEvent.Clone()); modified = true; original.Add(selectedEvent);
                        //}
                        float x = (float)(p.X);// - mouseOffx);
                        float y = (float)(p.Y);// - mouseOffy);
                        if (snapToW || SnapToGrid)
                            x = (float)Math.Floor((double)(x / gridWidth)) * gridWidth;
                        if (snapToH || SnapToGrid)
                            y = (float)Math.Floor((double)(y / gridHeight)) * gridHeight;
                        if (SnapToGrid)
                            selectedEvent.Position = new Vector2(x, y);
                        else
                            selectedEvent.Position = new Vector2(x - mouseOffx, y - mouseOffy);
                    }
                    else if (transType == Transformation.Rotate)
                    {
                        //    if (!original.ContainsKey(selectedEvent.Position))
                        //    {
                        //        clones.Add(selectedTile.Position, selectedTile.Clone()); modified = true;
                        //        original.Add(selectedTile.Position, selectedTile);
                        //    }
                        float x = originalMouse.X - p.X + originalRotation;
                        if (x <= 360 && x >= 0)
                            selectedEvent.Rotation = (int)x;
                    }
                }
            }
        }

        private void ShowTileMenu()
        {
            System.Drawing.Point p = this.PointToScreen(mousePoint);
            p.Y += gridHeight;
            tileSettings.Location = p;
            if (!tileSettings.Visible)
                tileSettings.Show(this);
            tileSettings.Location = p;
        }
        private void ShowEventMenu()
        {
            System.Drawing.Point p = this.PointToScreen(mousePoint);
            p.Y += gridHeight;
            eventSettings.Location = p;
            //if (!eventSettings.Visible)
            //eventSettings.Show(this);
            eventSettings.Location = p;
            this.Select();
        }
        private void ShowLayerMenu()
        {
            System.Drawing.Point p = this.PointToScreen(mousePoint);
            p.Y += gridHeight;
            layerSettings.Location = p;
            if (!layerSettings.Visible)
                layerSettings.Show(this);
            layerSettings.Location = p;
            this.Focus();
        }
        private void ShowCollisionMenu()
        {
            collisionSettings.Setup(selectedCollision);
            System.Drawing.Point p = this.PointToScreen(mousePoint);
            p.Y += (int)selectedCollision.GetRectangle().Height;
            collisionSettings.Location = p;
            if (!collisionSettings.Visible)
                collisionSettings.Show(this);
            collisionSettings.Location = p;
        }
        #endregion

        private void graphicsControl_DragLeave(object sender, EventArgs e)
        {
            drawPreview = false;
        }

        internal void graphicsControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) snapToW = true;
            if (e.KeyCode == Keys.S) snapToH = true;
            if (e.Shift) shift = true;
            if (e.Control) ctrl = true;
            if (ctrl && e.KeyCode == Keys.D)
            {
                frontCTRLDToolStripMenuItem_Click(null, null);
                return;
            }
            if (ctrl && e.KeyCode == Keys.F)
            {
                backCTRLFToolStripMenuItem_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.D)
            {
                bringToFrontToolStripMenuItem_Click(null, null);
            }
            if (e.KeyCode == Keys.F)
            {
                sendToBackToolStripMenuItem_Click(null, null);
            }
            if (e.KeyCode == Keys.Delete)
            {
                removeToolStripMenuItem_Click(null, null);
            }

            //if (e.Control)
            //{
            //    if (e.KeyData == Keys.C)
            //        copyToolStripMenuItem_Click(null, null);
            //    else if (e.KeyData == Keys.X)
            //        cutToolStripMenuItem_Click(null, null);
            //    else if (e.KeyData == Keys.V)
            //        pasteToolStripMenuItem_Click(null, null);
            //}
        }

        internal void graphicsControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) snapToW = false;
            if (e.KeyCode == Keys.S) snapToH = false;
            if (e.KeyCode == Keys.ControlKey) ctrl = false;
            if (e.KeyCode == Keys.ShiftKey) shift = false;
        }

        private void CheckCursor()
        {
            if (physicsBtn.Checked && showCollision)
            { this.graphicsControl.Cursor = Cursors.Arrow; return; }
            if (brushType == BrushType.EraserBrush || brushType == BrushType.EraserRect || brushType == BrushType.EraserFill)
                this.graphicsControl.Cursor = (!ctrl ? Global.CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20) : Global.CreateCursor(Properties.Resources.eyedropper, 20, 20, 0, 20));
            else if (brushType == BrushType.CursorSingle || brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer || brushType == BrushType.EventSelection || brushType == BrushType.LayerSelection)
                this.graphicsControl.Cursor = Cursors.Arrow;
            else
                this.graphicsControl.Cursor = (!ctrl ? Global.CreateCursor(Properties.Resources.paint_brush, 20, 20, 0, 20) : Global.CreateCursor(Properties.Resources.eyedropper, 20, 20, 0, 20)); ;

            if (tilesetViewer == null)
                this.graphicsControl.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Scroll if the middle mouse is down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgScroller_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //while (!bgScroller.CancellationPending)
                //{
                //    try
                //    {
                //        System.Threading.Thread.Sleep(10);
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
                    newV = (int)Math.Min(newV, vScrollBar.Maximum - gridHeight);
                    //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newV, ScrollOrientation.VerticalScroll));
                    vScrollBar.Value = Math.Min(vScrollBar.Maximum, Math.Max(vScrollBar.Minimum, newV));
                    int newH = hScrollBar.Value + (int)diff.X;
                    if (!hScrollBar.Enabled) newH = 0;
                    newH = (int)Math.Max(newH, hScrollBar.Minimum);
                    newH = (int)Math.Min(newH, hScrollBar.Maximum - gridWidth);
                    //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newH, ScrollOrientation.HorizontalScroll));
                    hScrollBar.Value = Math.Min(hScrollBar.Maximum, Math.Max(hScrollBar.Minimum, newH));
                }
                //    }
                //    catch (Exception ex)
                //    {
                //        Error.ShowLogError(ex, "29x003");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "29x003");
            }
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
            p.X = hScrollBar.Value + (camera.ScreenPosition.X / zoomLevel); //+ gridHeight;
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
            oldScrollX = hScrollBar.Value;
            oldScrollY = vScrollBar.Value;
            UpdateTiles();
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
                vScrollBar.Maximum = (int)(camera.ViewingHeight - camera.Viewport.Height / zoomLevel + gridHeight);// +gridHeight;
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
                hScrollBar.Maximum = (int)(camera.ViewingWidth - camera.Viewport.Width / zoomLevel + gridWidth);// +gridWidth;
                hScrollBar.Value = hScrollBar.Minimum;
                hScrollBar.Enabled = true;
                hScrollBar.LargeChange = gridWidth;
                hScrollBar.SmallChange = gridWidth;
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
        /// Get Tile From Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private TileData GetTile(Vector2 pos)
        {
            for (int i = 0; i < selectedLayer.Tiles.Count; i++)
                if (selectedLayer.Tiles[i].Position == pos)
                    return selectedLayer.Tiles[i];
            return null;
        }
        /// <summary>
        /// Get Tile From Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private TileData GetFillTile(Vector2 pos)
        {
            for (int i = 0; i < FillTiles.Count; i++)
                if (FillTiles[i].Position == pos)
                    return null;
            for (int i = 0; i < selectedLayer.Tiles.Count; i++)
                if (selectedLayer.Tiles[i].Position == pos)
                    return selectedLayer.Tiles[i];
            return null;
        }
        /// <summary>
        /// Get Tile From Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private TileData GetTileR(Vector2 pos)
        {
            for (int j = selectedLayer.Tiles.Count - 1; j > -1; j--)
            {
                if (selectedLayer.Tiles[j].RectangleF.Contains(pos.X, pos.Y))
                    return selectedLayer.Tiles[j];
            }
            return null;
        }
        /// <summary>
        /// Event Data
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private EventData GetEvent(Vector2 pos)
        {
            if (map == null) return null;
            if (GameData.Player.MapID == map.Data.ID && GameData.Player.LayerIndex == map.Data.Layers.IndexOf(selectedLayer))
            {
                if (GameData.Player.GetRectangle(gridWidth, gridHeight).Contains(pos.X, pos.Y))
                    return GameData.Player;
            }
            foreach (KeyValuePair<int, EventData> ev in selectedLayer.Events.Reverse())
            {
                if (ev.Value.GetRectangle(gridWidth, gridHeight).Contains(pos.X, pos.Y))
                    return ev.Value;
            }
            return null;
        }
        /// <summary>
        /// Get Tile From Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private List<TileData> ClearTiles(List<Vector2> pos)
        {
            List<TileData> tiles = new List<TileData>();
            int c = selectedLayer.Tiles.Count;
            for (int i = 0; i < c; i++)
                if (pos.Contains(selectedLayer.Tiles[i].Position))
                {
                    tiles.Add(selectedLayer.Tiles[i]);
                    selectedLayer.Tiles.RemoveAt(i);
                    c--; i--;
                }
            return tiles;
            //if (tiles.Count > 0)
            //MainForm.MapEditorHistory[this].Do(new TilesHist(tiles, false, selectedLayer.Tiles));
        }
        /// <summary>
        /// Get Tile From Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private List<TileData> ClearTiles(Vector2 pos)
        {
            List<TileData> tiles = new List<TileData>();
            int c = selectedLayer.Tiles.Count;
            for (int i = 0; i < c; i++)
                if (pos == selectedLayer.Tiles[i].Position)
                {
                    tiles.Add(selectedLayer.Tiles[i]);
                    selectedLayer.Tiles.RemoveAt(i);
                    c--; i--;
                }
            return tiles;
            //if (tiles.Count > 0)
            //MainForm.MapEditorHistory[this].Do(new TilesHist(tiles, false, selectedLayer.Tiles));
        }
        #endregion

        #region Graphics
        private void graphicsControl_OnInitialize(object sender, EventArgs e)
        {
            // Initialize the graphics device
            graphicsDevice = graphicsControl.GraphicsDevice;
            this.camera = new XNA2dCamera(graphicsDevice.Viewport);
            // initialize drawing resources.
            spriteBatch = new SpriteBatch(graphicsDevice);
            pixelTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.pixel, System.Drawing.Imaging.ImageFormat.Png);
            tileBtnTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.arrow_expand, System.Drawing.Imaging.ImageFormat.Png);
            layerCircleTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.LayerCircle, System.Drawing.Imaging.ImageFormat.Png);
            rounded3Texture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.Rounded3, System.Drawing.Imaging.ImageFormat.Png);
            rounded3InTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.Rounded3In, System.Drawing.Imaging.ImageFormat.Png);
            lightbulbTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.lightbulb, System.Drawing.Imaging.ImageFormat.Png);
            playerTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.Player, System.Drawing.Imaging.ImageFormat.Png);

            anchorTexture = Loader.TextureFromStream(graphicsControl.GraphicsDevice, global::EGMGame.Properties.Resources.anchor_circle, System.Drawing.Imaging.ImageFormat.Png);

            // Scroll Reset
            hScrollBar.Minimum = 0;
            vScrollBar.Minimum = 0;
            Viewport v = graphicsDevice.Viewport;
            v.Height = Math.Max(1, graphicsControl.Height);
            v.Width = Math.Max(1, graphicsControl.Width);
            //// graphicsDevice.Viewport = v;
            camera.Viewport = v;
            this.camera.Offset = -MapOffset;
            this.camera.ViewingHeight += MapOffset.Y * 2;
            this.camera.ViewingWidth += MapOffset.X * 2;
            UpdateScrollbarsW();
            UpdateScrollbarsH();
            // Font
            Global.LoadFont(graphicsControl.Services);
            // Start the animation timer.  
            timer = Stopwatch.StartNew();
            TimeLast = timer.ElapsedMilliseconds;
            TimeElapsed = 0;
            nCount = 0;
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        EventData mouseOverEvent;
        public bool LayerSelection;
        private void graphicsControl_OnDraw(object sender, EventArgs e)
        {
            if (toolStrip1.Visible != showCollision)
            {
                toolStrip1.Visible = showCollision;
            }

            //bgScroller_DoWork(null, null);

            mouseOverEvent = GetEvent(currentMouse);
            lastTileHighlighted = null;
            if (contentManager.RootDirectory != MaterialExplorer.contentBuilder.OutputDirectory)
            {
                contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            }
            // Calculate FPS
            if (timer.IsRunning)
            {
                nCount++;
                timeTotal = timer.Elapsed;
                timeElapsed = timeTotal - timeLastUpdate;

                millisecondsElapsed += (float)timeElapsed.TotalMilliseconds;

                timeLastUpdate = timeTotal;

                gameTime = new GameTime(timeTotal, timeElapsed);

                if (millisecondsElapsed >= 1000)
                {
                    FPS = (float)nCount / (millisecondsElapsed / 1000);
                    nCount = 0;
                    millisecondsElapsed = 0;
                }

            }
            lblFPS.Text = ((int)FPS).ToString();
            // Clear device and draw inactive area
            if (!graphicsDevice.IsDisposed)
            {
                Global.ClearDevice(graphicsDevice,
                Microsoft.Xna.Framework.Color.LightSkyBlue);
                if (map != null)
                {
                    // Matrix
                    Matrix m = camera.ViewTransformationMatrix();
                    try
                    {
                        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);


                        DrawLayers();
                        if (showCollision)
                            DrawCollision();
                        if (tilesetViewer != null && !(physicsBtn.Checked && showCollision))
                            DrawPreview();
                        // spriteBatch.End();
                        //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);
                        if (DisplayGrid) DrawGrid();

                        DrawEvents();

                        DrawBorder();

                        if (tilesetViewer != null)
                            DrawSelected();
                        if (tilesetViewer == null)
                        {
                            if (DoNotDrawPlayer)
                            {
                                System.Drawing.RectangleF rect = new System.Drawing.RectangleF();
                                rect.Width = 16;
                                rect.Height = 16;
                                rect.X = currentMouse.X - 8;
                                rect.Y = currentMouse.Y - 8;
                                DrawRectangle(rect, Color.BlueViolet, 3, 0);
                            }
                            else if (!IsScreenSelect)
                            {
                                DrawPlayerTransferPreview();
                            }
                            else
                            {
                                System.Drawing.RectangleF rect = new System.Drawing.RectangleF();
                                rect.Width = this.Width / 2;
                                rect.Height = this.Height / 2;
                                rect.X = currentMouse.X - rect.Width / 2;
                                rect.Y = currentMouse.Y - rect.Height / 2;
                                DrawRectangle(rect, Color.BlueViolet, 3, 0);
                            }
                        }
                        // Draw Middle Mouse Move
                        if (isMiddleDown)
                        {
                            // Draw 4 dir
                            Texture2D dir = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.fourDCursor, ImageFormat.Png);
                            Vector2 point = camera.GetTransformedPoint(new Vector2(mousePoint.X, mousePoint.Y));
                            spriteBatch.Draw(dir, new Rectangle((int)point.X, (int)point.Y, 22, 22), Color.Black);
                        }

                        lastTilesetID = -10;
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex, "s29x001");
                    }
                    finally
                    {
                        spriteBatch.End();
                    }
                }
            }
            else
            {
                ResetDevice();
            }


            lblTileCount.Text = tileCount.ToString() + " (" + drawnTileCount + ")";

            if (tileCount < 250000)
                lblTileCount.ForeColor = System.Drawing.Color.Green;
            else if (tileCount >= 250000)
                lblTileCount.ForeColor = System.Drawing.Color.Red;
        }

        private void ResetDevice()
        {
            graphicsControl.ResetDevice();
            // Initialize the graphics device
            graphicsDevice = graphicsControl.GraphicsDevice;
            this.camera = new XNA2dCamera(graphicsDevice.Viewport);
            // initialize drawing resources.
            spriteBatch = new SpriteBatch(graphicsDevice);
            pixelTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.pixel, System.Drawing.Imaging.ImageFormat.Png);
            tileBtnTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.arrow_expand, System.Drawing.Imaging.ImageFormat.Png);
            layerCircleTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.LayerCircle, System.Drawing.Imaging.ImageFormat.Png);
            rounded3Texture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.Rounded3, System.Drawing.Imaging.ImageFormat.Png);
            rounded3InTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.Rounded3In, System.Drawing.Imaging.ImageFormat.Png);
            lightbulbTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.lightbulb, System.Drawing.Imaging.ImageFormat.Png);
            playerTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.Player, System.Drawing.Imaging.ImageFormat.Png);

            // Scroll Reset
            hScrollBar.Minimum = 0;
            vScrollBar.Minimum = 0;
            Viewport v = graphicsDevice.Viewport;
            v.Height = Math.Max(1, graphicsControl.Height);
            v.Width = Math.Max(1, graphicsControl.Width);
            //// graphicsDevice.Viewport = v;
            camera.Viewport = v;
            this.camera.Offset = -MapOffset;
            this.camera.ViewingHeight += MapOffset.Y * 2;
            this.camera.ViewingWidth += MapOffset.X * 2;
            UpdateScrollbarsW();
            UpdateScrollbarsH();
            // Font
            Global.LoadFont(graphicsControl.Services);
            // Start the animation timer.  
            timer = Stopwatch.StartNew();
            TimeLast = timer.ElapsedMilliseconds;
            TimeElapsed = 0;
            nCount = 0;
        }

        private void DrawPlayerTransferPreview()
        {


            System.Drawing.RectangleF rect =
                new System.Drawing.RectangleF(currentMouse.X - 16, currentMouse.Y - 16, 32, 32);


            DrawRectangle(rect, Color.White, 1, 1);
            FillRectangle(rect, Color.White, new Color(0, 0, 255, 100), 1);

            return;
            int index = 0;
            int gridPadding = 0;
            //System.Drawing.RectangleF rect =
            //    new System.Drawing.RectangleF(currentMouse.X, currentMouse.Y, gridWidth, gridHeight);

            if (GameData.Player.Pages.Count > 0)
            {
                if (GameData.Player.PartyList.Count > 0)
                {
                    HeroData hdata = Global.GetData<HeroData>(GameData.Player.PartyList[0], GameData.Heroes);
                    AnimationData ani = null;
                    if (hdata != null)
                        ani = Global.GetData<AnimationData>(hdata.AnimationID, GameData.Animations);
                    if (ani != null)
                    {
                        AnimationAction act = Global.GetData<AnimationAction>(hdata.Actions[0], ani.Actions);
                        if (act != null && act.Directions.Count > 0 && act.Directions[GameData.Player.StartDirection] != null && act.Directions[GameData.Player.StartDirection].Count > 0 && act.Directions[GameData.Player.StartDirection][0] != null)
                        {
                            AnimationFrame frame = act.Directions[GameData.Player.StartDirection][0];
                            foreach (AnimationSprite sprite in frame.Sprites)
                            {
                                Texture2D tex = GetMTexture(sprite.MaterialId);
                                Color fillColor = Color.White;
                                if (tex != null)
                                {
                                    //offset.Y = act.CanvasSize.Y;
                                    spriteBatch.Draw(
                                        tex,
                                        new Vector2(rect.X, rect.Y) + sprite.Position,
                                        sprite.DisplayRect,
                                        sprite.Tint,
                                        DegreesToRadian(sprite.Rotation),
                                        sprite.Size / 2 + sprite.OriginOffset,
                                        sprite.Scale,
                                        (sprite.HorizontalFlip ? SpriteEffects.FlipHorizontally : sprite.VerticalFlip ? SpriteEffects.FlipVertically : SpriteEffects.None),
                                        0
                                    );
                                }
                            }
                        }
                    }
                }
            }
            // Draw Base Outline
            Color baseBorderColor;
            Color textColor = Color.White;
            if (selectedEvent == GameData.Player)
            {
                baseBorderColor = new Color(135, 135, 235, 155);
                textColor = Color.Black;
            }
            else
                baseBorderColor = new Color(77, 77, 77, 255);
            Color textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);
            int textAreaShift = 20 - gridPadding;

            DrawRoundedRectangle(rect, baseBorderColor, new Color(255, 255, 255, 100), 0, true, 3, new List<int>() { 1, 2 });
            DrawLine(new Vector2(rect.X, rect.Y + 3), new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);
            DrawLine(new Vector2(rect.X + rect.Width, rect.Y + 3), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);

            // Draw Text Area
            DrawRoundedRectangle(new System.Drawing.RectangleF(rect.X, rect.Y + rect.Height - textAreaShift - 2, rect.Width, 20), baseBorderColor, textAreaColor, 0, true, 3, new List<int>() { 3, 4 });
            FillRectangle(new System.Drawing.RectangleF(rect.X - 1, rect.Y + rect.Height - textAreaShift, rect.Width + 1, 15), baseBorderColor, textAreaColor, 0, false);
            DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
            DrawLine(new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X + rect.Width, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
            DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift + 1), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift + 1), baseBorderColor, 1, 0);

            // Draw Layer Index
            spriteBatch.Draw(
                layerCircleTexture,
                new Vector2(rect.Right - 7f, rect.Y - 6f),
                new Rectangle(0, 0, 14, 14),
                Color.White,
                0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0
            );

            spriteBatch.Draw(
                playerTexture,
                new Vector2(rect.Left - 7f, rect.Y - 6f),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0
            );

            Vector2 layerPos = new Vector2(rect.Right - 3f, rect.Y - 5f);
            if (index.ToString().Length > 1)
            {
                layerPos = new Vector2(rect.Right - 5, rect.Y - 5f);
            }

            DrawText(index.ToString(), Color.White, layerPos);

            if (Global.Font.MeasureString(GameData.Player.Name).X > rect.Width - 6)
            {
                string s = "";
                foreach (char c in GameData.Player.Name)
                {
                    s += c + "..";
                    if (Global.Font.MeasureString(s).X > rect.Width - 6)
                    {
                        s = s.Substring(0, s.Length - 3);
                        s += "..";
                        DrawText(s, textColor, new Vector2(currentMouse.X + 2 + gridPadding, currentMouse.Y + gridHeight - textAreaShift + 3 - gridPadding));
                        break;
                    }
                    else
                    {
                        s = s.Substring(0, s.Length - 2);
                    }
                }
            }
            else
            {
                DrawText(GameData.Player.Name, textColor, new Vector2(currentMouse.X + 2 + gridPadding, currentMouse.Y + gridHeight - textAreaShift + 3 - gridPadding));
            }
        }

        private void DrawCollision()
        {
            int verticeCount;
            Vector2 offset = new Vector2();
            Vector2 finalPos = new Vector2();
            int realIndex;
            System.Drawing.RectangleF streamArea = new System.Drawing.RectangleF(camera.DrawRectangle.X, camera.DrawRectangle.Y, camera.DrawRectangle.Width, camera.DrawRectangle.Height);
            Vector2 drawArea = new Vector2(streamArea.X, streamArea.Y);
            TilesetData tileset = null;
            Vertices body;
            for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
            {
                if (!map.Data.Layers[layerIndex].IsVisible)
                    continue;
                // Draw Layer
                for (int tileIndex = 0; tileIndex < map.Data.Layers[layerIndex].Tiles.Count; tileIndex++)
                {
                    if (tileset == null || tileset.ID != map.Data.Layers[layerIndex].Tiles[tileIndex].TilesetID)
                        tileset = Global.GetData<TilesetData>(map.Data.Layers[layerIndex].Tiles[tileIndex].TilesetID, GameData.Tilesets);
                    if (tileset != null)
                    {
                        tileSize.X = map.Data.Layers[layerIndex].Tiles[tileIndex].Width;
                        tileSize.Y = map.Data.Layers[layerIndex].Tiles[tileIndex].Height;
                        realIndex = (int)(map.Data.Layers[layerIndex].Tiles[tileIndex].DisplayRect.X / tileset.Grid.X) * tileset.Rows + (int)(map.Data.Layers[layerIndex].Tiles[tileIndex].DisplayRect.Y / tileset.Grid.Y);

                        if (realIndex > -1 && realIndex < tileset.Tiles.Count)
                        {
                            body = new Vertices(tileset.Tiles[realIndex].Body);
                            body.Scale(map.Data.Layers[layerIndex].Tiles[tileIndex].Scale);
                            Vector2 v = -(map.Data.Layers[layerIndex].Tiles[tileIndex].Scale - new Vector2(1, 1)) * tileSize / 2;
                            body.Translate(ref v);
                            body.Rotate(MathHelper.ToRadians(map.Data.Layers[layerIndex].Tiles[tileIndex].Rotation));
                            for (int b = 0; b < body.Count; b++)
                            {
                                verticeCount = body.Count;

                                finalPos = map.Data.Layers[layerIndex].Tiles[tileIndex].Position - tileSize / 2;
                                //offset.X = 64 / 2;
                                //offset.Y = 64 / 2;
                                if (b < verticeCount - 1)
                                {
                                    DrawLine(finalPos + body[b + 1], finalPos + body[b], Color.Yellow, 2, 1);
                                }
                                else
                                {
                                    DrawLine(finalPos + body[b], finalPos + body[0], Color.Yellow, 2, 1);
                                }
                            }
                        }
                    }
                }


                Color lineColor = Color.Yellow;
                for (int i = 0; i < map.Data.Layers[layerIndex].CollisionData.Count; i++)
                {
                    if (map.Data.Layers[layerIndex] == selectedLayer)
                    {
                        if (map.Data.Layers[layerIndex].CollisionData[i] == selectedCollision)
                        {
                            FillRectangle(map.Data.Layers[layerIndex].CollisionData[i].GetRectangle(), Color.Blue, new Color(Color.Blue.R, Color.Blue.G, Color.Blue.B, 50), 1);
                        }
                        else
                            FillRectangle(map.Data.Layers[layerIndex].CollisionData[i].GetRectangle(), Color.LightBlue, new Color(Color.LightBlue.R, Color.LightBlue.G, Color.LightBlue.B, 100), 1);
                    }
                    verticeCount = map.Data.Layers[layerIndex].CollisionData[i].Count;
                    for (int b = 0; b < map.Data.Layers[layerIndex].CollisionData[i].Count; b++)
                    {

                        lineColor = Color.Yellow;
                        if (map.Data.Layers[layerIndex].CollisionData[i][map.Data.Layers[layerIndex].CollisionData[i].NextIndex(b)].Y == map.Data.Layers[layerIndex].CollisionData[i][b].Y)
                            lineColor = Color.Red;
                        if (map.Data.Layers[layerIndex].CollisionData[i][map.Data.Layers[layerIndex].CollisionData[i].NextIndex(b)].X == map.Data.Layers[layerIndex].CollisionData[i][b].X)
                            lineColor = Color.Red;

                        finalPos = map.Data.Layers[layerIndex].CollisionData[i].Position;
                        if (b < verticeCount - 1)
                        {
                            DrawLine(map.Data.Layers[layerIndex].CollisionData[i][b + 1], map.Data.Layers[layerIndex].CollisionData[i][b], lineColor, 2, 1);
                        }
                        else
                        {
                            DrawLine(map.Data.Layers[layerIndex].CollisionData[i][b], map.Data.Layers[layerIndex].CollisionData[i][0], lineColor, 2, 1);
                        }
                        offset = map.Data.Layers[layerIndex].CollisionData[i][b] - new Vector2(4, 4);
                        spriteBatch.Draw(anchorTexture,
                                          offset,
                                          Color.Pink);
                    }
                }
            }
            if (selectedCollision != null && selectedNodeIndexes.Count > 0)
            {
                for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedNodeIndexes[nodeIndex] < selectedCollision.Count)
                    {
                        finalPos.X = selectedCollision.Position.X;
                        finalPos.Y = selectedCollision.Position.Y;
                        offset.X = -4;
                        offset.Y = -4;
                        offset = selectedCollision[selectedNodeIndexes[nodeIndex]] + offset;
                        DrawRectangle(new System.Drawing.RectangleF(offset.X, offset.Y, 9, 9), Color.Blue, 1, 1);
                    }
                }
            }

            if (addingPhysics && IsMouseDown)
            {

                Vector2 pos = currentMouse;
                Vector2 originalMousePos = new Vector2();
                originalMousePos.X = camera.GetTransformedPoint(mousePoint).X;
                originalMousePos.Y = camera.GetTransformedPoint(mousePoint).Y;

                if (SnapToGrid || snapToW)
                    originalMousePos.X = (float)Math.Floor((double)(camera.GetTransformedPoint(mousePoint).X / gridWidth)) * gridWidth;
                if (SnapToGrid || snapToH)
                    originalMousePos.Y = (float)Math.Floor((double)(camera.GetTransformedPoint(mousePoint).Y / gridHeight)) * gridHeight;

                if (SnapToGrid || snapToW)
                    pos.X = (float)Math.Floor((double)(camera.GetTransformedPoint(pos).X / gridWidth)) * gridWidth + gridWidth;
                if (SnapToGrid || snapToH)
                    pos.Y = (float)Math.Floor((double)(camera.GetTransformedPoint(pos).Y / gridHeight)) * gridHeight + gridHeight;


                Vertices list2 = new Vertices();
                Vector2 vNew2 = Vector2.Zero;
                pos = currentMouse;
                Vector2 _position = new Vector2();
                _position.X = camera.GetTransformedPoint(mousePoint).X;
                _position.Y = camera.GetTransformedPoint(mousePoint).Y;
                if (SnapToGrid || snapToW)
                    _position.X = (float)Math.Floor((double)(originalMouse.X / gridWidth)) * gridWidth;
                if (SnapToGrid || snapToH)
                    _position.Y = (float)Math.Floor((double)(originalMouse.Y / gridHeight)) * gridHeight;
                if (SnapToGrid || snapToW)
                    pos.X = (float)Math.Floor((double)(pos.X / gridWidth)) * gridWidth + gridWidth;
                if (SnapToGrid || snapToH)
                    pos.Y = (float)Math.Floor((double)(pos.Y / gridHeight)) * gridHeight + gridHeight;

                offset = new Vector2();
                Vector2 nodePosition = Vector2.Zero;
                Vector2 diff = _position - pos;

                switch (physicsType)
                {
                    case PhysicsType.Rect:
                        if (originalMousePos != pos)
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)pos.X - (int)_position.X, (int)pos.Y - (int)_position.Y);

                            Rectangle rect = new Rectangle((int)_position.X, (int)_position.Y, difference.X, difference.Y);


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

                            difference.X = rect.Width;
                            difference.Y = rect.Height;
                            _position.X = rect.X;
                            _position.Y = rect.Y;

                            Vector2 tempOM = _position;

                            tempOM.X = _position.X;
                            tempOM.Y = _position.Y;
                            difference.X = difference.X;
                            difference.Y = difference.Y;



                            body = Vertices.CreateSimpleRectangle(Math.Abs(difference.X), Math.Abs(difference.Y));

                            list2 = new Vertices();
                            vNew2 = new Vector2();
                            foreach (Vector2 v in body)
                            {
                                vNew2 = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                                list2.Add(vNew2);
                            }
                            Vertices draw = list2;

                            verticeCount = draw.Count;
                            for (int i = 0; i < draw.Count; i++)
                            {

                                if (i < verticeCount - 1)
                                {
                                    DrawLine(draw[i + 1], draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(draw[i], draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                spriteBatch.Draw(
                                                  anchorTexture,
                                                 draw[i] + offset,
                                                  Color.Pink);
                            }
                            return;


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

                            difference.X = rect.Width;
                            difference.Y = rect.Height;
                            originalMousePos.X = rect.X;
                            originalMousePos.Y = rect.Y;

                            Vertices draw = Vertices.CreateCircle(Math.Abs(difference.X), Math.Abs(difference.Y));

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
                                    DrawLine(draw[i + 1], draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(draw[i], draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                spriteBatch.Draw(
                                                  anchorTexture,
                                                  draw[i] + offset,
                                                  Color.Pink);
                            }
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Draw the map's border
        /// </summary>
        private void DrawBorder()
        {
            DrawRectangle(new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y), Color.Red, 4, 1);
        }
        /// <summary>
        /// Draw the events
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="isDim"></param>
        /// <param name="isAbove"></param>
        /// <param name="index"></param>

        private void DrawEvents(LayerData layer, bool isDim, bool isAbove, int index)
        {
            // Default fill colour
            Color fillColor = new Color(245, 245, 245, 0.5f);
            System.Drawing.RectangleF streamArea = new System.Drawing.RectangleF(camera.DrawRectangle.X, camera.DrawRectangle.Y, camera.DrawRectangle.Width, camera.DrawRectangle.Height);
            Vector2 offset = new Vector2();
            // Draw a Transparent square.
            foreach (EventData e in layer.Events.Values)
            {
                if (e.Pages.Count > 0)
                {
                    AnimationData ani = Global.GetData<AnimationData>(e.Pages[0].AnimationID, GameData.Animations);
                    if (ani != null)
                    {
                        AnimationAction act = Global.GetData<AnimationAction>(e.Pages[0].ActionID, ani.Actions);
                        if (act != null && act.Directions.Count > 0 && act.Directions[e.Pages[0].Direction] != null && act.Directions[e.Pages[0].Direction].Count > 0 && act.Directions[e.Pages[0].Direction][0] != null)
                        {
                            AnimationFrame frame = act.Directions[e.Pages[0].Direction][0];
                            foreach (AnimationSprite sprite in frame.Sprites)
                            {
                                Texture2D tex = GetMTexture(sprite.MaterialId);
                                if (!isDim)
                                {
                                    fillColor = Color.White;
                                }
                                if (tex != null)
                                {
                                    spriteBatch.Draw(
                                        tex,
                                        e.Position - offset + sprite.Position,
                                        sprite.DisplayRect,
                                        sprite.Tint,
                                        DegreesToRadian(sprite.Rotation) + DegreesToRadian(e.Rotation),
                                        sprite.Size / 2 + sprite.OriginOffset,
                                        sprite.Scale,
                                        (sprite.HorizontalFlip ? SpriteEffects.FlipHorizontally : sprite.VerticalFlip ? SpriteEffects.FlipVertically : SpriteEffects.None),
                                        0
                                    );
                                }
                            }

                            DrawEvent(index, e, true, act);

                            if (e.Pages[0].GetParticle(graphicsControl.GraphicsDevice, contentManager) != null)
                            {
                                ParticleSystemData pdata = e.Pages[0].GetParticle(graphicsControl.GraphicsDevice, contentManager);
                                DrawParticles(pdata, e.Position);
                            }
                        }
                        else
                        {
                            DrawEvent(index, e, false, act);
                            if (e.Pages[0].GetParticle(graphicsControl.GraphicsDevice, contentManager) != null)
                            {
                                ParticleSystemData pdata = e.Pages[0].GetParticle(graphicsControl.GraphicsDevice, contentManager);
                                DrawParticles(pdata, e.Position);
                            }
                        }
                    }
                    else
                    {
                        DrawEvent(index, e, false, null);

                        if (e.Pages[0].GetParticle(graphicsControl.GraphicsDevice, contentManager) != null)
                        {
                            ParticleSystemData pdata = e.Pages[0].GetParticle(graphicsControl.GraphicsDevice, contentManager);
                            DrawParticles(pdata, e.Position);
                        }
                    }
                }
                else
                {
                    DrawEvent(index, e, false, null);
                }
            }
            // Draw Player
            if (GameData.Player.MapID == map.Data.ID && GameData.Player.LayerIndex == index)
            {
                if (GameData.Player.Pages.Count > 0)
                {
                    if (GameData.Player.PartyList.Count > 0)
                    {
                        HeroData hdata = Global.GetData<HeroData>(GameData.Player.PartyList[0], GameData.Heroes);
                        AnimationData ani = null;
                        if (hdata != null)
                            ani = Global.GetData<AnimationData>(hdata.AnimationID, GameData.Animations);
                        if (ani != null)
                        {
                            AnimationAction act = Global.GetData<AnimationAction>(hdata.Actions[0], ani.Actions);
                            if (act != null && act.Directions.Count > 0 && act.Directions[GameData.Player.StartDirection] != null && act.Directions[GameData.Player.StartDirection].Count > 0 && act.Directions[GameData.Player.StartDirection][0] != null)
                            {
                                AnimationFrame frame = act.Directions[GameData.Player.StartDirection][0];
                                foreach (AnimationSprite sprite in frame.Sprites)
                                {
                                    Texture2D tex = GetMTexture(sprite.MaterialId);
                                    if (!isDim)
                                    {
                                        fillColor = Color.White;
                                    }
                                    if (tex != null)
                                    {
                                        //offset.Y = act.CanvasSize.Y;
                                        spriteBatch.Draw(
                                            tex,
                                            GameData.Player.Position - offset + sprite.Position,
                                            sprite.DisplayRect,
                                            sprite.Tint,
                                            DegreesToRadian(sprite.Rotation),
                                            sprite.Size / 2 + sprite.OriginOffset,
                                            sprite.Scale,
                                            (sprite.HorizontalFlip ? SpriteEffects.FlipHorizontally : sprite.VerticalFlip ? SpriteEffects.FlipVertically : SpriteEffects.None),
                                            0
                                        );
                                    }
                                }
                                DrawPlayer(index);
                                if (GameData.Player.Page.GetParticle(graphicsControl.GraphicsDevice, contentManager) != null)
                                {
                                    ParticleSystemData pdata = GameData.Player.Page.GetParticle(graphicsControl.GraphicsDevice, contentManager);
                                    Vector2 geomOffset = Vector2.Zero;
                                    if (act.CollisionBody != null && act.CollisionBody.Count > 0)
                                    {
                                        geomOffset = act.CollisionBody.GetCentroid();
                                        //geomOffset.Y -= (act.CanvasSize.Y);
                                    }
                                    DrawParticles(pdata, GameData.Player.Position + geomOffset);
                                }
                            }
                            else
                            {
                                DrawPlayer(index);
                                if (GameData.Player.Page.GetParticle(graphicsControl.GraphicsDevice, contentManager) != null)
                                {
                                    ParticleSystemData pdata = GameData.Player.Page.GetParticle(graphicsControl.GraphicsDevice, contentManager);
                                    Vector2 geomOffset = Vector2.Zero;
                                    if (act.CollisionBody != null && act.CollisionBody.Count > 0)
                                    {
                                        geomOffset = act.CollisionBody.GetCentroid();
                                    }
                                    DrawParticles(pdata, GameData.Player.Position + geomOffset);
                                }
                            }
                        }
                        else
                        {
                            DrawPlayer(index);
                        }

                    }
                    else
                    {
                        DrawPlayer(index);
                    }
                }
                else
                {
                    DrawPlayer(index);
                }

            }
        }

        private void DrawParticles(ParticleSystemData pdata, Vector2 pos)
        {
            for (int emitterIndex = 0; emitterIndex < pdata.Emitters.Count; emitterIndex++)
            {
                //pdata.Emitters[emitterIndex].Update(gameTime, camera.ViewTransformationMatrix(), Matrix.CreateTranslation(pos.X, pos.Y, 0));
                //pdata.Emitters[emitterIndex].Draw();
            }
        }
        private void DrawEvent(int index, EventData e, bool hasAnimation, AnimationAction act)
        {
            if (hasAnimation && act != null)
            {
                int offRect = 12;
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y, act.CanvasSize.X, act.CanvasSize.Y + offRect);

                if (showCollision && act != null)
                {
                    Vertices body = new Vertices(act.CollisionBody);
                    for (int b = 0; b < body.Count; b++)
                    {
                        int verticeCount = body.Count;

                        Vector2 finalPos = e.Position;
                        if (b < verticeCount - 1)
                        {
                            DrawLine(finalPos + body[b + 1], finalPos + body[b], Color.Yellow, 2, 1);
                        }
                        else
                        {
                            DrawLine(finalPos + body[b], finalPos + body[0], Color.Yellow, 2, 1);
                        }
                    }
                }
                // Draw Base Outline
                Color baseBorderColor;
                Color textColor = Color.White; Color textAreaColor;
                if (selectedEvent == e)
                {
                    baseBorderColor = new Color(135, 135, 235, 155);
                    textColor = Color.Black;
                    textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                }
                else if (e == mouseOverEvent)
                {
                    baseBorderColor = Color.Yellow;
                    textColor = Color.Black;
                    textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                }
                else
                {
                    if (selectedLayer == map.Data.Layers[index])
                    {
                        baseBorderColor = new Color(77, 77, 77, 255);//0.63f);//0.37f);
                        textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                    }
                    else
                    {
                        baseBorderColor = new Color(155, 155, 155, 100);

                        textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 100);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                    }
                }
                int textAreaShift = 10;

                DrawRoundedRectangle(rect, baseBorderColor, new Color(255, 255, 255, 0), 0, true, 3, new List<int>() { 1, 2 });
                DrawLine(new Vector2(rect.X, rect.Y + 3), new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);
                DrawLine(new Vector2(rect.X + rect.Width, rect.Y + 3), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);

                // Draw Text Area
                DrawRoundedRectangle(new System.Drawing.RectangleF(rect.X, rect.Y + rect.Height - textAreaShift - 2, rect.Width, 20), baseBorderColor, textAreaColor, 0, true, 3, new List<int>() { 3, 4 });
                FillRectangle(new System.Drawing.RectangleF(rect.X - 1, rect.Y + rect.Height - textAreaShift, rect.Width + 1, 15), baseBorderColor, textAreaColor, 0, false);
                DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
                DrawLine(new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X + rect.Width, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
                DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift + 1), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift + 1), baseBorderColor, 1, 0);

                // Draw Layer Index
                spriteBatch.Draw(
                    layerCircleTexture,
                    new Vector2(e.Position.X + act.CanvasSize.X - (layerCircleTexture.Width / 2), e.Position.Y - (layerCircleTexture.Height / 2)),
                    new Rectangle(0, 0, 14, 14),
                    Color.White,
                    0f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0
                );

                Vector2 layerPos = new Vector2(rect.Right - 3f, rect.Y - 5f);
                if (index.ToString().Length > 1)
                {
                    layerPos = new Vector2(rect.Right - 5, rect.Y - 5f);
                }

                DrawText(index.ToString(), Color.White, layerPos);


                if (Global.Font.MeasureString(e.Name).X > rect.Width - 6)
                {
                    string s = "";
                    foreach (char c in e.Name)
                    {
                        s += c + "..";
                        if (Global.Font.MeasureString(s).X > rect.Width - 6)
                        {
                            s = s.Substring(0, s.Length - 3);
                            s += "..";
                            DrawText(s, textColor, new Vector2(e.Position.X + 2, e.Position.Y + act.CanvasSize.Y + offRect - textAreaShift + 3));
                            break;
                        }
                        else
                        {
                            s = s.Substring(0, s.Length - 2);
                        }
                    }
                }
                else
                {
                    DrawText(e.Name, textColor, new Vector2(e.Position.X + 2, e.Position.Y + act.CanvasSize.Y + offRect - textAreaShift + 3));
                }

                e.Canvas = new Vector2(gridWidth, gridHeight);
                if (selectedEvent == e)
                {
                   
                    selectedEvent.Canvas = act.CanvasSize;
                    // Draw Event Rotation
                    System.Drawing.RectangleF rectF = new System.Drawing.RectangleF(e.Position.X, e.Position.Y, act.CanvasSize.X, act.CanvasSize.Y);

                    DrawLine(e.GetMiddleCenter(act.CanvasSize), e.GetMiddleRight(act.CanvasSize), Color.Black, GetScale(), 1);

                    FillRectangle(e.GetTopLeft(act.CanvasSize), Color.Black, Color.Yellow, 0);

                    FillRectangle(e.GetMiddleLeft(act.CanvasSize), Color.Black, Color.White, 0);


                    DrawText("Position: (" + ((int)e.Position.X).ToString() + ", " + ((int)e.Position.Y).ToString() + ")", Color.White, new Vector2(rect.Right - rect.Width, rect.Y + rect.Height + 10f));
                    DrawText("Size: (" + rect.Width.ToString() + ", " + rect.Height.ToString() + ")", Color.White, new Vector2(rect.Right - rect.Width, rect.Y + rect.Height + 20f));
                }
            }
            else
            {
                int gridPadding = 0;
               System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y, gridWidth, gridHeight);
                // Draw Base Outline
                Color baseBorderColor;
                Color textColor = Color.White; Color textAreaColor;
                if (selectedEvent == e)
                {
                    baseBorderColor = new Color(135, 135, 235, 155);
                    textColor = Color.Black;
                    textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                }
                else if (e == mouseOverEvent)
                {
                    baseBorderColor = Color.Yellow;
                    textColor = Color.Black;
                    textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                }
                else
                {
                    if (selectedLayer == map.Data.Layers[index])
                    {
                        baseBorderColor = new Color(77, 77, 77, 255);//0.63f);//0.37f);
                        textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                    }
                    else
                    {
                        baseBorderColor = new Color(155, 155, 155, 100);

                        textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 100);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                    }
                }
                int textAreaShift = 20 - gridPadding;

                DrawRoundedRectangle(rect, baseBorderColor, new Color(255, 255, 255, 100), 0, true, 3, new List<int>() { 1, 2 });
                DrawLine(new Vector2(rect.X, rect.Y + 3), new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);
                DrawLine(new Vector2(rect.X + rect.Width, rect.Y + 3), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);
                FillRectangle(new System.Drawing.RectangleF(rect.X - 1, rect.Y + 3, rect.Width + 1, rect.Height - textAreaShift), baseBorderColor, new Color(255, 255, 255, 100), 1, false);

                // Draw Text Area
                DrawRoundedRectangle(new System.Drawing.RectangleF(rect.X, rect.Y + rect.Height - textAreaShift - 2, rect.Width, 20), baseBorderColor, textAreaColor, 0, true, 3, new List<int>() { 3, 4 });
                FillRectangle(new System.Drawing.RectangleF(rect.X - 1, rect.Y + rect.Height - textAreaShift, rect.Width + 1, 15), baseBorderColor, textAreaColor, 0, false);
                DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
                DrawLine(new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X + rect.Width, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
                DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift + 1), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift + 1), baseBorderColor, 1, 0);

                // Draw Layer Index
                spriteBatch.Draw(
                    layerCircleTexture,
                    new Vector2(rect.Right - 7f, rect.Y - 6f),
                    new Rectangle(0, 0, 14, 14),
                    Color.White,
                    0f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0
                );

                spriteBatch.Draw(
                    lightbulbTexture,
                    new Vector2(rect.X + (rect.Width / 2) - (lightbulbTexture.Width / 2) - 1, rect.Y + (rect.Height / 2) - (lightbulbTexture.Height / 2) - 1 - gridPadding),
                    null,
                    new Color(255, 255, 255, 155),
                    0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    0
                );

                Vector2 layerPos = new Vector2(rect.Right - 3f, rect.Y - 5f);
                if (index.ToString().Length > 1)
                {
                    layerPos = new Vector2(rect.Right - 5, rect.Y - 5f);
                }

                DrawText(index.ToString(), Color.White, layerPos);

                if (Global.Font.MeasureString(e.Name).X > rect.Width - 6)
                {
                    string s = "";
                    foreach (char c in e.Name)
                    {
                        s += c + "..";
                        if (Global.Font.MeasureString(s).X > rect.Width - 6)
                        {
                            s = s.Substring(0, s.Length - 3);
                            s += "..";
                            DrawText(s, textColor, new Vector2(e.Position.X + 2 + gridPadding, e.Position.Y + gridHeight - textAreaShift + 3 - gridPadding));
                            break;
                        }
                        else
                        {
                            s = s.Substring(0, s.Length - 2);
                        }
                    }
                }
                else
                {
                    DrawText(e.Name, textColor, new Vector2(e.Position.X + 2 + gridPadding, e.Position.Y + gridHeight - textAreaShift + 3 - gridPadding));
                }
                e.Canvas = new Vector2(gridWidth, gridHeight);


            }
        }
        private void DrawPlayer(int index)
        {
            int gridPadding = 0;
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(GameData.Player.Position.X, GameData.Player.Position.Y, gridWidth, gridHeight);
            if (showCollision)
            {
                if (GameData.Player.PartyList.Count > 0)
                {
                    HeroData hdata = Global.GetData<HeroData>(GameData.Player.PartyList[0], GameData.Heroes);
                    AnimationData ani = null;
                    if (hdata != null)
                        ani = Global.GetData<AnimationData>(hdata.AnimationID, GameData.Animations);
                    if (ani != null)
                    {
                        AnimationAction act = Global.GetData<AnimationAction>(hdata.Actions[0], ani.Actions);
                        Vertices body = new Vertices(act.CollisionBody);
                        for (int b = 0; b < body.Count; b++)
                        {
                            int verticeCount = body.Count;

                            Vector2 finalPos = GameData.Player.Position;
                            if (b < verticeCount - 1)
                            {
                                DrawLine(finalPos + body[b + 1], finalPos + body[b], Color.Yellow, 2, 1);
                            }
                            else
                            {
                                DrawLine(finalPos + body[b], finalPos + body[0], Color.Yellow, 2, 1);
                            }
                        }
                    }
                }
            }
            // Draw Base Outline
            Color baseBorderColor;
            Color textColor = Color.White; Color textAreaColor;
            if (selectedEvent == GameData.Player)
            {
                baseBorderColor = new Color(135, 135, 235, 155);
                textColor = Color.Black;
                textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
            }
            else if (GameData.Player == mouseOverEvent)
            {
                baseBorderColor = Color.Yellow;
                textColor = Color.Black;
                textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
            }
            else
            {
                if (selectedLayer == map.Data.Layers[index])
                {
                    baseBorderColor = new Color(77, 77, 77, 255);//0.63f);//0.37f);
                    textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 200);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                }
                else
                {
                    baseBorderColor = new Color(155, 155, 155, 100);

                    textAreaColor = new Color(baseBorderColor.R, baseBorderColor.G, baseBorderColor.B, 100);//new Color(46, 46, 46, 255);//0.34f);//0.66f);
                }
            }
            int textAreaShift = 20 - gridPadding;

            DrawRoundedRectangle(rect, baseBorderColor, new Color(255, 255, 255, 100), 0, true, 3, new List<int>() { 1, 2 });
            DrawLine(new Vector2(rect.X, rect.Y + 3), new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);
            DrawLine(new Vector2(rect.X + rect.Width, rect.Y + 3), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), baseBorderColor, 1, 0);

            // Draw Text Area
            DrawRoundedRectangle(new System.Drawing.RectangleF(rect.X, rect.Y + rect.Height - textAreaShift - 2, rect.Width, 20), baseBorderColor, textAreaColor, 0, true, 3, new List<int>() { 3, 4 });
            FillRectangle(new System.Drawing.RectangleF(rect.X - 1, rect.Y + rect.Height - textAreaShift, rect.Width + 1, 15), baseBorderColor, textAreaColor, 0, false);
            DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
            DrawLine(new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift), new Vector2(rect.X + rect.Width, rect.Y + rect.Height + 15 - textAreaShift), baseBorderColor, 1, 0);
            DrawLine(new Vector2(rect.X, rect.Y + rect.Height - textAreaShift + 1), new Vector2(rect.X + rect.Width, rect.Y + rect.Height - textAreaShift + 1), baseBorderColor, 1, 0);

            // Draw Layer Index
            spriteBatch.Draw(
                layerCircleTexture,
                new Vector2(rect.Right - 7f, rect.Y - 6f),
                new Rectangle(0, 0, 14, 14),
                Color.White,
                0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0
            );

            spriteBatch.Draw(
                playerTexture,
                new Vector2(rect.Left - 7f, rect.Y - 6f),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0
            );


            Vector2 layerPos = new Vector2(rect.Right - 3f, rect.Y - 5f);
            if (index.ToString().Length > 1)
            {
                layerPos = new Vector2(rect.Right - 5, rect.Y - 5f);
            }

            DrawText(index.ToString(), Color.White, layerPos);

            if (Global.Font.MeasureString(GameData.Player.Name).X > rect.Width - 6)
            {
                string s = "";
                foreach (char c in GameData.Player.Name)
                {
                    s += c + "..";
                    if (Global.Font.MeasureString(s).X > rect.Width - 6)
                    {
                        s = s.Substring(0, s.Length - 3);
                        s += "..";
                        DrawText(s, textColor, new Vector2(GameData.Player.Position.X + 2 + gridPadding, GameData.Player.Position.Y + gridHeight - textAreaShift + 3 - gridPadding));
                        break;
                    }
                    else
                    {
                        s = s.Substring(0, s.Length - 2);
                    }
                }
            }
            else
            {
                DrawText(GameData.Player.Name, textColor, new Vector2(GameData.Player.Position.X + 2 + gridPadding, GameData.Player.Position.Y + gridHeight - textAreaShift + 3 - gridPadding));
            }

            if (selectedEvent == GameData.Player)
            {
                DrawText("Position: (" + GameData.Player.Position.X.ToString() + ", " + GameData.Player.Position.Y.ToString() + ")", Color.White, new Vector2(rect.Right - rect.Width, rect.Y + rect.Height + 0f));
                DrawText("Size: (" + rect.Width.ToString() + ", " + rect.Height.ToString() + ")", Color.White, new Vector2(rect.Right - rect.Width, rect.Y + rect.Height + 10f));
            }
        }
        /// <summary>
        /// Draw Text from given string, color and positon
        /// </summary>
        /// <param name="p"></param>
        /// <param name="color"></param>
        /// <param name="p_3"></param>
        private void DrawText(string text, Color color, Vector2 pos)
        {
            Vector2 size = Global.Font.MeasureString(text);
            if (text.Contains(GameData.Player.Name))
            {
                size.X -= 28;
            }
            //FillRectangle(new System.Drawing.RectangleF(pos.X - 4, pos.Y, Width + 3, 16), Color.Black, Color.White, 1);
            //spriteBatch.DrawString(Global.Font, text, pos, color, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Global.Font, text, pos, color, 0, Vector2.Zero, 1, SpriteEffects.None, 1f);//0.6f, SpriteEffects.None, 1f);
        }
        /// <summary>
        ///  Draw Sprites With Selection
        /// </summary>
        private void DrawLayers()
        {
            tileCount = 0;
            drawnTileCount = 0;
            Rectangle streamArea = new Rectangle(camera.DrawRectangleOffset.X, camera.DrawRectangleOffset.Y, camera.DrawRectangleOffset.Width, camera.DrawRectangleOffset.Height);

            bool isAbove = false;
            LayerData layer;
            for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
            {
                layer = map.Data.Layers[layerIndex];
                if (!layer.IsVisible)
                    continue;

                // Draw Layer
                if (SelectedLayer == layer)
                {
                    DrawLayerBackground(layer, false, isAbove);


                    for (int tileIndex = 0; tileIndex < layer.Tiles.Count; tileIndex++)
                    {
                        tileCount++;

                        if ((((layer.Tiles[tileIndex].Rectangle.X < (streamArea.X + streamArea.Width)) && (streamArea.X < (layer.Tiles[tileIndex].Rectangle.X + layer.Tiles[tileIndex].Rectangle.Width))) && (layer.Tiles[tileIndex].Rectangle.Y < (streamArea.Y + streamArea.Height))) && (streamArea.Y < (layer.Tiles[tileIndex].Rectangle.Y + layer.Tiles[tileIndex].Rectangle.Height)))
                        {
                            DrawTile(layer, layer.Tiles[tileIndex], (brushType == BrushType.LayerSelection), isAbove);
                            drawnTileCount++;
                        }
                    }
                    isAbove = true;
                    //DrawEvents(layer, (brushType == BrushType.LayerSelection), isAbove, layerIndex);
                }
                else
                {
                    DrawLayerBackground(layer, true, isAbove);

                    for (int tileIndex = 0; tileIndex < layer.Tiles.Count; tileIndex++)
                    {
                        tileCount++;
                        if ((((layer.Tiles[tileIndex].Rectangle.X < (streamArea.X + streamArea.Width)) && (streamArea.X < (layer.Tiles[tileIndex].Rectangle.X + layer.Tiles[tileIndex].Rectangle.Width))) && (layer.Tiles[tileIndex].Rectangle.Y < (streamArea.Y + streamArea.Height))) && (streamArea.Y < (layer.Tiles[tileIndex].Rectangle.Y + layer.Tiles[tileIndex].Rectangle.Height)))
                        {
                            DrawTile(layer, layer.Tiles[tileIndex], true, isAbove);
                            drawnTileCount++;
                        }
                    }

                    //DrawEvents(layer, true, isAbove, layerIndex);
                }
            }
        }

        private void DrawEvents()
        {
            Rectangle streamArea = new Rectangle(camera.DrawRectangleOffset.X, camera.DrawRectangleOffset.Y, camera.DrawRectangleOffset.Width, camera.DrawRectangleOffset.Height);

            bool isAbove = false;
            LayerData layer;
            for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
            {
                layer = map.Data.Layers[layerIndex];
                if (!layer.IsVisible)
                    continue;
                // Draw Layer
                if (SelectedLayer == layer)
                {
                    isAbove = true;
                    DrawEvents(layer, (brushType == BrushType.LayerSelection), isAbove, layerIndex);
                }
                else
                {
                    DrawEvents(layer, true, isAbove, layerIndex);
                }
            }
        }
        /// <summary>
        /// Draw layer background.
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="isDim"></param>
        /// <param name="isAbove"></param>
        private void DrawLayerBackground(LayerData layer, bool isDim, bool isAbove)
        {
            for (int i = 0; i < layer.Backgrounds.Count; i++)
            {
                Texture2D tex = GetMTexture(layer.Backgrounds[i].MaterialId);
                Color color = Color.White;
                if (!isDim || tilesetViewer == null)
                {
                    color = Color.White;
                }
                else if (isAbove)
                {
                    color = new Color(169, 169, 169, 80);
                }
                else
                {
                    color = new Color(169, 169, 169, 200);
                }
                // Draw tile texture
                if (tex != null)
                {
                    spriteBatch.Draw(tex,
                        new Rectangle((int)layer.Backgrounds[i].Position.X, (int)layer.Backgrounds[i].Position.Y, (int)layer.Backgrounds[i].Size.X, (int)layer.Backgrounds[i].Size.Y),
                         new Rectangle(0, 0, (int)tex.Width, (int)tex.Height),
                        color, layer.Backgrounds[i].Rotation, new Vector2(tex.Width * 0.5f, tex.Height * 0.5f), SpriteEffects.None, 0);

                    if (brushType == BrushType.LayerSelection && selectedLayerBG == layer.Backgrounds[i])
                    {
                        System.Drawing.RectangleF rect = new System.Drawing.RectangleF(layer.Backgrounds[i].Position.X, layer.Backgrounds[i].Position.Y, layer.Backgrounds[i].Size.X, layer.Backgrounds[i].Size.Y);
                        rect.X -= layer.Backgrounds[i].Size.X * 0.5f;
                        rect.Y -= layer.Backgrounds[i].Size.Y * 0.5f;
                        DrawRectangle(rect, Color.Yellow, GetScale() + 1, 1);

                        //DrawLine(new Vector2(layer.Backgrounds[i].Position.X - (layer.Backgrounds[i].Size * 0.5f).X, layer.Backgrounds[i].Position.Y), layer.Backgrounds[i].Position + new Vector2(layer.Backgrounds[i].Size.X * 0.5f, 0), Color.Yellow, GetScale() + 1, 1);
                        //DrawLine(new Vector2(layer.Backgrounds[i].Position.X, layer.Backgrounds[i].Position.Y - (layer.Backgrounds[i].Size * 0.5f).Y), layer.Backgrounds[i].Position + new Vector2(0, layer.Backgrounds[i].Size.Y * 0.5f), Color.Yellow, GetScale() + 1, 1);

                        // Bottom Right
                        FillRectangle(selectedLayerBG.GetBottomRight(), Color.Yellow, Color.Black, 1);
                        // Bottom Left
                        //FillRectangle(selectedLayerBG.GetBottomLeft(), Color.Yellow, Color.Black, 1);
                        // Top Left
                        //FillRectangle(selectedLayerBG.GetUpperLeft(), Color.Yellow, Color.Black, 1);
                        // Top Right
                        //FillRectangle(selectedLayerBG.GetUpperRight(), Color.Yellow, Color.Black, 1);
                    }
                    else
                        DrawRectangle(new System.Drawing.RectangleF(layer.Backgrounds[i].Position.X - (layer.Backgrounds[i].Size * 0.5f).X, layer.Backgrounds[i].Position.Y - (layer.Backgrounds[i].Size * 0.5f).Y, layer.Backgrounds[i].Size.X, layer.Backgrounds[i].Size.Y), Color.Black, GetScale() + 1, 1);

                }
            }
        }
        /// <summary>
        /// Draw Tile
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="isDim"></param>
        /// <param name="isAbove"></param>
        private void DrawTile(LayerData layer, TileData tile, bool isDim, bool isAbove)
        {
            Texture2D texture;
            if (lastTilesetID == tile.TilesetID)
                texture = lastTilesetTexture;
            else
                texture = GetTexture(tile.TilesetID);
            lastTilesetID = tile.TilesetID;
            lastTilesetTexture = texture;
            tileRectangle.X = (int)tile.DisplayRect.X;
            tileRectangle.Y = (int)tile.DisplayRect.Y;
            tileRectangle.Width = (int)tile.Width;
            tileRectangle.Height = (int)tile.Height;

            if (!isDim || tilesetViewer == null)
            {
                // Draw tile texture
                if (texture != null)
                {
                    colorTile.R = layer.Tint.Red; colorTile.G = layer.Tint.Green; colorTile.B = layer.Tint.Blue;
                    colorTile.A = (tile.Opacity != (byte)255 ? tile.Opacity : layer.Tint.Alpha);
#if DEBUG
                    if (FillTiles != null && FillTiles.Contains(tile))
                        colorTile.R = 100;
#endif
                    tileSize.X = tile.Width; tileSize.Y = tile.Height;
                    // Draw tile texture
                    spriteBatch.Draw(texture,
                        tile.Position,
                        tileRectangle,
                        colorTile, DegreesToRadian(tile.Rotation), tileSize * 0.5f, tile.Scale, (tile.VerticalFlip == true ? SpriteEffects.FlipVertically : tile.HorizontalFlip == true ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);

                    if (brushType == BrushType.CursorSingle && !SnapToGrid && tile.RectangleF.Contains(currentMouse.X, currentMouse.Y) && (selectedTile == null || !selectedTile.RectangleF.Contains(currentMouse.X, currentMouse.Y)))
                    {
                        lastTileHighlighted = tile;
                    }
                }
            }
            else if (isAbove)
            {
                if (texture != null)
                {
                    if (Global.Project.DimLayers)
                    {
                        colorTile.R = 255; colorTile.G = 255; colorTile.B = 255; colorTile.A = 153;
                        // color = new Color(128, 128, 128, 0.6f);
                    }
                    else
                    {
                        colorTile.R = layer.Tint.Red; colorTile.G = layer.Tint.Green; colorTile.B = layer.Tint.Blue; colorTile.A = (tile.Opacity != (byte)255 ? tile.Opacity : layer.Tint.Alpha);
                        //color = Color.White;
                    }
                    tileSize.X = tile.Width; tileSize.Y = tile.Height;
                    spriteBatch.Draw(texture,
                        tile.Position,
                        tileRectangle,
                        colorTile, DegreesToRadian(tile.Rotation), tileSize * 0.5f, tile.Scale, (tile.VerticalFlip == true ? SpriteEffects.FlipVertically : tile.HorizontalFlip == true ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 1);
                }
            }
            else
            {
                if (texture != null)
                {
                    if (Global.Project.DimLayers)
                    {
                        colorTile.R = 255; colorTile.G = 255; colorTile.B = 255; colorTile.A = 179;
                        // color = new Color(128, 128, 128, 0.7f);
                    }
                    else
                    {
                        colorTile.R = layer.Tint.Red; colorTile.G = layer.Tint.Green; colorTile.B = layer.Tint.Blue; colorTile.A = (tile.Opacity != (byte)255 ? tile.Opacity : layer.Tint.Alpha);
                        //color = Color.White;
                    }
                    tileSize.X = tile.Width; tileSize.Y = tile.Height;
                    spriteBatch.Draw(texture,
                        tile.Position,
                        tileRectangle,
                        colorTile, DegreesToRadian(tile.Rotation), tileSize * 0.5f, tile.Scale, (tile.VerticalFlip == true ? SpriteEffects.FlipVertically : tile.HorizontalFlip == true ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 1);
                }
            }

        }
        /// <summary>
        /// Draw Selected Sprite
        /// </summary>
        /// <param name="TilesetData"></param>
        private void DrawSelected()
        {
            if (lastTileHighlighted != null && selectedTile != lastTileHighlighted)
            {
                tileSize.X = lastTileHighlighted.Width; tileSize.Y = lastTileHighlighted.Height;
                spriteBatch.Draw(GetTexture(lastTileHighlighted.TilesetID),
                       lastTileHighlighted.Position,
                       new Rectangle((int)lastTileHighlighted.DisplayRect.X, (int)lastTileHighlighted.DisplayRect.Y, (int)lastTileHighlighted.Width, (int)lastTileHighlighted.Height),
                       Color.Magenta, DegreesToRadian(lastTileHighlighted.Rotation), tileSize / 2, lastTileHighlighted.Scale, (lastTileHighlighted.VerticalFlip == true ? SpriteEffects.FlipVertically : lastTileHighlighted.HorizontalFlip == true ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);

                FillRectangle(lastTileHighlighted.RectangleF, Color.Yellow, new Color(255, 255, 255, 25), 0f);
            }
            //tbOpacity.Visible = (!eventSelection && selectedTile != null && !tileSettings.Visible);

            if (brushType != BrushType.EventSelection && selectedTile != null)
            {

                //DrawRectangle(selectedTile.Rectangle, Color.Blue, 0, selectedTile.Rotation);
                spriteBatch.Draw(tileBtnTexture, selectedTile.GetTopRightX(), Color.White);

                System.Drawing.RectangleF rectF = selectedTile.RectangleF;
                FillRectangle(rectF, Color.Blue, new Color(255, 255, 255, 50), 1);

                DrawLine(selectedTile.GetMiddleCenter(), selectedTile.GetMiddleRight(), Color.Black, GetScale(), 1);

                // Top Left
                FillRectangle(selectedTile.GetTopLeft(), Color.Black, Color.Yellow, 0);

                FillRectangle(selectedTile.GetMiddleLeft(), Color.Black, Color.White, 0);
                // Bottom Right
                FillRectangle(selectedTile.GetBottomRight(), Color.Black, Color.White, 0);

                //DrawRectangle(rectF, Color.Blue, 3, 0f);

                // System.Drawing.Point _size = new System.Drawing.Point(-(int)selectedtile.Width / 2, (int)(selectedtile.Height / 1.5f));
                // _Width += camera.ReverseTransformPoint(selectedTile.Position).X - 255 / 2;
                // _size.Y += camera.ReverseTransformPoint(selectedTile.Position).Y;
                // tbOpacity.Location = _size;
                // tbOpacity.Width = 255;
                // if (tileSettings.Visible)
                // tbOpacity.Value = (float)tileSettings.opacityBox.Value;
            }
            else if (brushType == BrushType.EventSelection && selectedEvent != null)
            {
                //EventData e = selectedEvent;
                //if (e.Pages.Count > 0)
                //{
                //    AnimationData ani = Global.GetData<AnimationData>(e.Pages[0].AnimationID, GameData.Animations);
                //    if (ani != null)
                //    {
                //        AnimationAction act = Global.GetData<AnimationAction>(e.Pages[0].ActionID, ani.Actions);
                //        if (act != null && act.Directions.Count > 0 && act.Directions[e.Pages[0].Direction] != null && act.Directions[e.Pages[0].Direction].Count > 0 && act.Directions[e.Pages[0].Direction][0] != null)
                //        {
                //            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y - (act.CanvasSize.Y), act.CanvasSize.X, act.CanvasSize.Y);
                //            //DrawRectangle(rect, Color.Blue, 1, 1);
                //            if (e is PlayerData)
                //                DrawText(GameData.Player.LayerIndex.ToString() + " " + e.Name, Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //            else
                //                DrawText(Global.GetLayerIndex(e, map.Data).ToString(), Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //        }
                //        else
                //        {
                //            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y - gridHeight, gridWidth, gridHeight);
                //            //FillRectangle(rect, Color.Blue, new Color(Color.Wheat, 0.5f), 1);
                //            if (e is PlayerData)
                //                DrawText(GameData.Player.LayerIndex.ToString() + " " + e.Name, Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //            else
                //                DrawText(Global.GetLayerIndex(e, map.Data).ToString(), Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //        }
                //    }
                //    else if (selectedEvent is PlayerData)
                //    {

                //        HeroData hdata = null;
                //        if (GameData.Player.PartyList.Count > 0)
                //            hdata = Global.GetData<HeroData>(GameData.Player.PartyList[0], GameData.Heroes);
                //        ani = null;
                //        if (hdata != null)
                //            ani = Global.GetData<AnimationData>(hdata.AnimationID, GameData.Animations);
                //        if (ani != null)
                //        {
                //            AnimationAction act = Global.GetData<AnimationAction>(hdata.Actions[0], ani.Actions);
                //            if (act != null && act.Directions.Count > 0 && act.Directions[GameData.Player.StartDirection] != null && act.Directions[GameData.Player.StartDirection].Count > 0 && act.Directions[GameData.Player.StartDirection][0] != null)
                //            {
                //                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y - (act.CanvasSize.Y), act.CanvasSize.X, act.CanvasSize.Y);
                //                DrawRectangle(rect, Color.Blue, 1, 1);
                //                if (e is PlayerData)
                //                    DrawText(GameData.Player.LayerIndex.ToString() + " " + e.Name, Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //                else
                //                    DrawText(Global.GetLayerIndex(e, map.Data).ToString(), Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //            }
                //            else
                //            {
                //                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y - gridHeight, gridWidth, gridHeight);
                //                FillRectangle(rect, Color.Blue, new Color(Color.Wheat, 0.5f), 1);
                //                if (e is PlayerData)
                //                    DrawText(GameData.Player.LayerIndex.ToString() + " " + e.Name, Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //                else
                //                    DrawText(Global.GetLayerIndex(e, map.Data).ToString(), Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //            }
                //        }
                //        else
                //        {
                //            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y - gridHeight, gridWidth, gridHeight);
                //            FillRectangle(rect, Color.Blue, new Color(Color.Wheat, 0.5f), 1);
                //            if (e is PlayerData)
                //                DrawText(GameData.Player.LayerIndex.ToString() + " " + e.Name, Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //            else
                //                DrawText(Global.GetLayerIndex(e, map.Data).ToString(), Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //        }
                //    }
                //    else
                //    {
                //        System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y - gridHeight, gridWidth, gridHeight);
                //        FillRectangle(rect, Color.Blue, new Color(Color.Wheat, 0.5f), 1);
                //        if (e is PlayerData)
                //            DrawText(GameData.Player.LayerIndex.ToString() + " " + e.Name, Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //        else
                //            DrawText(Global.GetLayerIndex(e, map.Data).ToString(), Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //    }
                //}
                //else
                //{
                //    System.Drawing.RectangleF rect = new System.Drawing.RectangleF(e.Position.X, e.Position.Y - gridHeight, gridWidth, gridHeight);
                //    FillRectangle(rect, Color.Blue, new Color(Color.Wheat, 0.5f), 1);
                //    if (e is PlayerData)
                //        DrawText(GameData.Player.LayerIndex.ToString() + " " + e.Name, Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //    else
                //        DrawText(Global.GetLayerIndex(e, map.Data).ToString(), Color.Red, new Vector2(rect.Right - 7f, rect.Y - 10f));
                //}
            }


            if (IsMouseDown && (brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() == 0)
            {
                FillRectangle(new System.Drawing.RectangleF(selectionRectangle.X, selectionRectangle.Y, selectionRectangle.Width, selectionRectangle.Height), Color.White, new Color(0, 0, 255, 100), 1);
            }
            else if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
            {
                for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                {
                    if (selectedTiles[layerIndex] != null)
                    {
                        foreach (TileData sTile in selectedTiles[layerIndex])
                        {
                            System.Drawing.RectangleF rec = sTile.RectangleF;
                            rec.Width += 2;
                            rec.Height += 2;
                            rec.X -= 2;
                            rec.Y--;
                            FillRectangle(rec, Color.DarkGray, new Color(0, 0, 255, 25), 0);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Draw Grid
        /// </summary>
        private void DrawGrid()
        {
            if (map != null && selectedLayer != null)
            {
                for (int x = 0; x <= map.Data.Size.X; x += (int)(gridWidth))
                {
                    // Horizontal
                    if (x == 0)
                    {
                        DrawLine(new Vector2(1, 0), new Vector2(1, map.Data.Size.Y), new Color(0, 0, 0, 100), GetGridSize(), 0);
                    }
                    else
                    {
                        DrawLine(new Vector2(x, 0), new Vector2(x, map.Data.Size.Y), new Color(0, 0, 0, 100), GetGridSize(), 0);
                    }
                }
                // Vertical
                for (int y = 0; y <= map.Data.Size.Y + 1; y += (int)(gridHeight))
                {
                    if (y == map.Data.Size.Y)
                    {
                        DrawLine(new Vector2(0, y), new Vector2(map.Data.Size.X, y - 1), new Color(0, 0, 0, 100), GetGridSize(), 0);
                    }
                    else
                    {
                        DrawLine(new Vector2(0, y), new Vector2(map.Data.Size.X, y), new Color(0, 0, 0, 100), GetGridSize(), 0);
                    }
                }
            }
        }

        private int GetGridSize()
        {
            if (zoomLevel == 0.25f)
                return 5;
            else if (zoomLevel == 0.50f)
                return 4;
            else if (zoomLevel == 0.25f)
                return 3;
            else
                return 2;
        }
        /// <summary>
        /// Draw Preview
        /// </summary>
        private void DrawPreview()
        {
            if (!drawPreview) return;
            #region Pencil
            if (brushType == BrushType.Brush || brushType == BrushType.Rectangle || brushType == BrushType.Fill)
            {
                if (SnapToGrid)
                {
                    // Get Grid Position
                    float x;
                    float y;
                    Vector2 pos;
                    // Add Tile
                    bool gotOff;
                    Vector2 off;
                    if (commitalTiles.Count > 0)
                    {
                        Texture2D texture;
                        // Get Grid Position
                        x = (float)Math.Floor((double)(originalMouse.X / gridWidth)) * gridWidth;
                        y = (float)Math.Floor((double)(originalMouse.Y / gridHeight)) * gridHeight;
                        pos = new Vector2((int)x, (int)y);
                        foreach (TileData tile in commitalTiles)
                        {
                            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                            if (rect.Contains(tile.Position.X, tile.Position.Y))
                            {
                                if (lastPTilesetID == tile.TilesetID)
                                    texture = lastPTilesetTexture;
                                else
                                    texture = GetTexture(tile.TilesetID);
                                lastPTilesetID = tile.TilesetID;
                                lastPTilesetTexture = texture;
                                // Draw tile texture
                                if (texture != null)
                                {
                                    Color color = new Color(255, 255, 255, 150); ;
                                    tileSize.X = tile.Width; tileSize.Y = tile.Height;
                                    spriteBatch.Draw(texture,
                                        tile.Position,
                                        new Rectangle((int)tile.DisplayRect.X, (int)tile.DisplayRect.Y, (int)tile.Width, (int)tile.Height),
                                        color, 0, tileSize * 0.5f, tile.Scale, SpriteEffects.None, 0);

                                    if (showCollision)
                                    {
                                        Vector2 finalPos = Vector2.Zero;
                                        for (int b = 0; b < tile.Body.Count; b++)
                                        {
                                            int verticeCount = tile.Body.Count;

                                            finalPos = tile.Position - tileSize / 2;
                                            if (b < verticeCount - 1)
                                            {
                                                DrawLine(finalPos + tile.Body[b + 1], finalPos + tile.Body[b], Color.Yellow, 2, 1);
                                            }
                                            else
                                            {
                                                DrawLine(finalPos + tile.Body[b], finalPos + tile.Body[0], Color.Yellow, 2, 1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        #region Commented
                        switch (brushType)
                        {
                            #region Brush
                            case BrushType.Brush:

                                // Get Grid Position
                                x = (float)Math.Floor((double)(currentMouse.X / gridWidth)) * gridWidth;
                                y = (float)Math.Floor((double)(currentMouse.Y / gridHeight)) * gridHeight;
                                pos = new Vector2((int)x, (int)y);
                                // Add Tile
                                gotOff = false;
                                off = Vector2.Zero;
                                foreach (TileData tile in tilesetViewer.selectedTiles)
                                {
                                    if (!gotOff)
                                    {
                                        off = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                        gotOff = true;
                                    }
                                    // 
                                    Vector2 c = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                    Vector2 pp = (c - off) + pos;

                                    System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                                    if (rect.Contains(pp.X, pp.Y))
                                    {
                                        // Draw tile texture
                                        if (GetTexture(tile.TilesetID) != null)
                                        {
                                            Color color = new Color(255, 255, 255, 120); ;
                                            spriteBatch.Draw(GetTexture(tile.TilesetID),
                                                pp,
                                                new Rectangle((int)tile.DisplayRect.X, (int)tile.DisplayRect.Y, (int)tile.Width, (int)tile.Height),
                                                color, 0, Vector2.Zero, tile.Scale, SpriteEffects.None, 1);

                                            if (showCollision)
                                            {
                                                Vector2 finalPos = Vector2.Zero;
                                                for (int b = 0; b < tile.Body.Count; b++)
                                                {
                                                    int verticeCount = tile.Body.Count;

                                                    finalPos.X = pp.X;
                                                    finalPos.Y = pp.Y;
                                                    if (b < verticeCount - 1)
                                                    {
                                                        DrawLine(finalPos + tile.Body[b + 1], finalPos + tile.Body[b], Color.Yellow, 2, 1);
                                                    }
                                                    else
                                                    {
                                                        DrawLine(finalPos + tile.Body[b], finalPos + tile.Body[0], Color.Yellow, 2, 1);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            #endregion
                            #region Rectangle
                            case BrushType.Rectangle:
                                if (commitalTiles.Count > 0)
                                {
                                    // Get Grid Position
                                    x = (float)Math.Floor((double)(originalMouse.X / gridWidth)) * gridWidth;
                                    y = (float)Math.Floor((double)(originalMouse.Y / gridHeight)) * gridHeight;
                                    pos = new Vector2((int)x, (int)y);
                                    foreach (TileData tile in commitalTiles)
                                    {
                                        System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                                        if (rect.Contains(tile.Position.X, tile.Position.Y))
                                        {
                                            // Draw tile texture
                                            if (GetTexture(tile.TilesetID) != null)
                                            {
                                                Color color = new Color(255, 255, 255, 120); ;
                                                tileSize.X = tile.Width; tileSize.Y = tile.Height;
                                                spriteBatch.Draw(GetTexture(tile.TilesetID),
                                                    tile.Position,
                                                    new Rectangle((int)tile.DisplayRect.X, (int)tile.DisplayRect.Y, (int)tile.Width, (int)tile.Height),
                                                    color, 0, tileSize / 2, tile.Scale, SpriteEffects.None, 0);

                                                if (showCollision)
                                                {
                                                    Vector2 finalPos = Vector2.Zero;
                                                    for (int b = 0; b < tile.Body.Count; b++)
                                                    {
                                                        int verticeCount = tile.Body.Count;

                                                        finalPos = tile.Position - tileSize / 2;
                                                        if (b < verticeCount - 1)
                                                        {
                                                            DrawLine(finalPos + tile.Body[b + 1], finalPos + tile.Body[b], Color.Yellow, 2, 1);
                                                        }
                                                        else
                                                        {
                                                            DrawLine(finalPos + tile.Body[b], finalPos + tile.Body[0], Color.Yellow, 2, 1);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    goto case BrushType.Brush;
                                }
                                break;
                            #endregion
                        }
                        #endregion
                    }
                }
                else
                {
                    // Get Grid Position
                    float x;
                    float y;
                    Vector2 pos;
                    // Add Tile
                    bool gotOff;
                    Vector2 off;
                    Texture2D texture;
                    switch (brushType)
                    {
                        #region Brush
                        case BrushType.Brush:
                            // Current Mouse                            
                            x = currentMouse.X; y = currentMouse.Y;
                            if (snapToW)
                                x = (float)Math.Floor((double)(currentMouse.X / gridWidth)) * gridWidth + gridWidth / 2;
                            if (snapToH)
                                y = (float)Math.Floor((double)(currentMouse.Y / gridHeight)) * gridHeight + gridHeight / 2;
                            pos = new Vector2((int)x, (int)y);
                            // Add Tile
                            gotOff = false;
                            off = Vector2.Zero;
                            foreach (TileData tile in tilesetViewer.selectedTiles)
                            {
                                // Get Off set
                                if (!gotOff)
                                {
                                    off = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                    gotOff = true;
                                }
                                // 
                                Vector2 c = new Vector2(tile.DisplayRect.X, tile.DisplayRect.Y);
                                tileSize.X = tile.Width; tileSize.Y = tile.Height;
                                Vector2 pp = (c - off) + pos - tileSize / 2;

                                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);

                                if (lastPTilesetID == tile.TilesetID)
                                    texture = lastPTilesetTexture;
                                else
                                    texture = GetTexture(tile.TilesetID);
                                lastPTilesetID = tile.TilesetID;
                                lastPTilesetTexture = texture;
                                // Draw tile texture
                                if (texture != null)
                                {
                                    Color color = new Color(255, 255, 255, 120); ;
                                    spriteBatch.Draw(texture,
                                        pp,
                                        new Rectangle((int)tile.DisplayRect.X, (int)tile.DisplayRect.Y, (int)tile.Width, (int)tile.Height),
                                        color, 0, Vector2.Zero, tile.Scale, SpriteEffects.None, 0);

                                    System.Drawing.RectangleF prect = new System.Drawing.RectangleF(pp.X, pp.Y, tile.Width, tile.Height);
                                    DrawRectangle(prect, Color.Blue, 0, 0);


                                    if (showCollision)
                                    {
                                        Vector2 finalPos = Vector2.Zero;
                                        for (int b = 0; b < tile.Body.Count; b++)
                                        {
                                            int verticeCount = tile.Body.Count;

                                            finalPos.X = pp.X;
                                            finalPos.Y = pp.Y;
                                            if (b < verticeCount - 1)
                                            {
                                                DrawLine(finalPos + tile.Body[b + 1], finalPos + tile.Body[b], Color.Yellow, 2, 1);
                                            }
                                            else
                                            {
                                                DrawLine(finalPos + tile.Body[b], finalPos + tile.Body[0], Color.Yellow, 2, 1);
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        #endregion
                        #region Rectangle
                        case BrushType.Rectangle:
                            if (commitalTiles.Count > 0)
                            {
                                foreach (TileData tile in commitalTiles)
                                {
                                    System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, map.Data.Size.X, map.Data.Size.Y);
                                    if (rect.Contains(tile.Position.X, tile.Position.Y))
                                    {
                                        if (lastPTilesetID == tile.TilesetID)
                                            texture = lastPTilesetTexture;
                                        else
                                            texture = GetTexture(tile.TilesetID);
                                        lastPTilesetID = tile.TilesetID;
                                        lastPTilesetTexture = texture;
                                        // Draw tile texture
                                        if (texture != null)
                                        {
                                            Color color = new Color(255, 255, 255, 120); ;
                                            tileSize.X = tile.Width; tileSize.Y = tile.Height;
                                            spriteBatch.Draw(texture,
                                                tile.Position,
                                                new Rectangle((int)tile.DisplayRect.X, (int)tile.DisplayRect.Y, (int)tile.Width, (int)tile.Height),
                                                color, 0, tileSize / 2, tile.Scale, SpriteEffects.None, 0);
                                            if (showCollision)
                                            {
                                                Vector2 finalPos = Vector2.Zero;
                                                for (int b = 0; b < tile.Body.Count; b++)
                                                {
                                                    int verticeCount = tile.Body.Count;

                                                    finalPos.X = tile.Position.X;
                                                    finalPos.Y = tile.Position.Y;
                                                    if (b < verticeCount - 1)
                                                    {
                                                        DrawLine(finalPos + tile.Body[b + 1], finalPos + tile.Body[b], Color.Yellow, 2, 1);
                                                    }
                                                    else
                                                    {
                                                        DrawLine(finalPos + tile.Body[b], finalPos + tile.Body[0], Color.Yellow, 2, 1);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                goto case BrushType.Brush;
                            }
                            break;
                        #endregion
                    }
                }
            }
            #endregion

            if (brushType == BrushType.EraserRect && IsMouseDown)
            {
                float rec_selectwidth = (currentMouse.X - originalMouse.X);
                float rec_selectheight = (currentMouse.Y - originalMouse.Y);
                float rec_x = originalMouse.X;
                float rec_y = originalMouse.Y;
                float rec_width = rec_selectwidth;
                float rec_height = rec_selectheight;

                if (rec_selectwidth < 0)
                {
                    rec_x = originalMouse.X + rec_selectwidth;
                    rec_width = Math.Abs(rec_selectwidth);
                }
                if (rec_selectheight < 0)
                {
                    rec_y = originalMouse.Y + rec_selectheight;
                    rec_height = Math.Abs(rec_selectheight);
                }

                FillRectangle(new System.Drawing.RectangleF(rec_x, rec_y, rec_width, rec_height), Color.White, Color.Pink, 1);
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

            if (scale <= 0) scale = 1;

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

            DrawRectangle(new System.Drawing.RectangleF(x + 1, y + 1, width - 2, height - 2), borderColor, GetScale(), 1);
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
        private void DrawRoundedRectangle(System.Drawing.RectangleF rectangle, Color borderColor, Color fillColor, float priority, bool border, int radius)
        {
            //fillColor = new Color(255, 255, 255, 0);
            if (border)
            {
                // Top Side
                DrawLine(new Vector2(rectangle.X + radius, rectangle.Y), new Vector2(rectangle.X + rectangle.Width - radius, rectangle.Y), borderColor, 1, priority);
                // Right Side
                DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y + radius), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height - radius), borderColor, 1, priority);
                // Bottom Side
                DrawLine(new Vector2(rectangle.X + radius, rectangle.Y + rectangle.Height), new Vector2(rectangle.X + rectangle.Width - radius, rectangle.Y + rectangle.Height), borderColor, 1, priority);
                // Left Side
                DrawLine(new Vector2(rectangle.X, rectangle.Y + radius), new Vector2(rectangle.X, rectangle.Y + rectangle.Height - radius), borderColor, 1, priority);
            }
            // Top Left
            if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), borderColor);
            spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), fillColor);

            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), fillColor);
            // Top Right
            if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), borderColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), fillColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);

            //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y), new Rectangle(12 - radius, 0, radius + 1, radius + 1), borderColor);
            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y), new Rectangle(12 - radius, 0, radius + 1, radius + 1), fillColor);
            // Bottom Left
            //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 0, radius + 1, radius + 1), borderColor, 0, Vector2.Zero, 1, SpriteEffects.FlipVertically, 0);
            if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), borderColor);
            spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), fillColor);

            //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius, radius + 1, radius + 1), borderColor);
            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius, radius + 1, radius + 1), fillColor);
            // Bottom Right
            if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), borderColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0); ;
            spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), fillColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0); ;

            //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius-1, rectangle.Y + rectangle.Height - radius-1), new Rectangle(12 - radius, 12 - radius, radius, radius+1), borderColor);
            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius-1, rectangle.Y + rectangle.Height - radius-1), new Rectangle(12 - radius, 12 - radius, radius, radius+1), fillColor);
            // Fill Main
            FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + radius - 1, (int)rectangle.Y + radius - 1, (int)rectangle.Width - radius * 2 + 2, (int)rectangle.Height - radius * 2 + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Top Gap
            FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + radius - 1, (int)rectangle.Y, (int)rectangle.Width - radius * 2 + 2, radius + 1), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Bottom Gap
            FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + radius - 1, (int)rectangle.Y + rectangle.Height - radius - 1, (int)rectangle.Width - radius * 2 + 2, radius + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Left Gap
            FillRectangle(new System.Drawing.RectangleF((int)rectangle.X - 1, (int)rectangle.Y + radius - 1, radius + 2, rectangle.Height - radius * 2 + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Right Gap
            FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + rectangle.Width - radius - 1, (int)rectangle.Y + radius - 1, radius + 1, rectangle.Height - radius * 2 + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
        }
        private void DrawRoundedRectangle(System.Drawing.RectangleF rectangle, Color borderColor, Color fillColor, float priority, bool border, int radius, List<int> corners)
        {
            //fillColor = new Color(255, 255, 255, 0);
            if (border)
            {
                // Top Side
                if (corners.Contains(1) && corners.Contains(2))
                    DrawLine(new Vector2(rectangle.X + radius, rectangle.Y), new Vector2(rectangle.X + rectangle.Width - radius, rectangle.Y), borderColor, 1, priority);
                // Right Side
                if (corners.Contains(2) && corners.Contains(4))
                    DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y + radius), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height - radius), borderColor, 1, priority);
                // Bottom Side
                if (corners.Contains(3) && corners.Contains(4))
                    DrawLine(new Vector2(rectangle.X + radius, rectangle.Y + rectangle.Height - 1), new Vector2(rectangle.X + rectangle.Width - radius - 1, rectangle.Y + rectangle.Height - 1), borderColor, 1, priority);
                // Left Side
                if (corners.Contains(1) && corners.Contains(3))
                    DrawLine(new Vector2(rectangle.X, rectangle.Y + radius), new Vector2(rectangle.X, rectangle.Y + rectangle.Height - radius), borderColor, 1, priority);
            }
            // Top Left
            if (corners.Contains(1))
            {
                if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), borderColor);
                spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), fillColor);
            }
            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), fillColor);
            // Top Right
            if (corners.Contains(2))
            {
                if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), borderColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius - 1, rectangle.Y), new Rectangle(0, 0, radius + 1, radius + 1), fillColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            }
            //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y), new Rectangle(12 - radius, 0, radius + 1, radius + 1), borderColor);
            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius - 2, rectangle.Y), new Rectangle(12 - radius, 0, radius + 1, radius + 1), fillColor);
            // Bottom Left
            if (corners.Contains(3))
            {
                //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 0, radius + 1, radius + 1), borderColor, 0, Vector2.Zero, 1, SpriteEffects.FlipVertically, 0);
                if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), borderColor);
                spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), fillColor);
            }
            //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius, radius + 1, radius + 1), borderColor);
            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius, radius + 1, radius + 1), fillColor);
            // Bottom Right            
            if (corners.Contains(4))
            {
                if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), borderColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0); ;
                spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius - 1, rectangle.Y + rectangle.Height - radius - 1), new Rectangle(0, 12 - radius - 1, radius + 1, radius + 1), fillColor, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0); ;
            }
            //if (border) spriteBatch.Draw(rounded3Texture, new Vector2(rectangle.X + rectangle.Width - radius-1, rectangle.Y + rectangle.Height - radius-1), new Rectangle(12 - radius, 12 - radius, radius, radius+1), borderColor);
            //spriteBatch.Draw(rounded3InTexture, new Vector2(rectangle.X + rectangle.Width - radius-1, rectangle.Y + rectangle.Height - radius-1), new Rectangle(12 - radius, 12 - radius, radius, radius+1), fillColor);
            // Fill Main
            //FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + radius - 1, (int)rectangle.Y + radius - 1, (int)rectangle.Width - radius * 2 + 2, (int)rectangle.Height - radius * 2 + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Top Gap
            if (corners.Contains(1) && corners.Contains(2))
                FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + radius - 1, (int)rectangle.Y, (int)rectangle.Width - radius * 2 + 1, radius + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Bottom Gap
            if (corners.Contains(3) && corners.Contains(4))
                FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + radius - 1, (int)rectangle.Y + rectangle.Height - radius - 2, (int)rectangle.Width - radius * 2 + 1, radius + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Left Gap
            if (corners.Contains(1) && corners.Contains(3))
                FillRectangle(new System.Drawing.RectangleF((int)rectangle.X - 1, (int)rectangle.Y + radius - 1, radius + 2, rectangle.Height - radius * 2 + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
            // Fill Right Gap
            if (corners.Contains(2) && corners.Contains(4))
                FillRectangle(new System.Drawing.RectangleF((int)rectangle.X + rectangle.Width - radius - 1, (int)rectangle.Y + radius - 1, radius + 1, rectangle.Height - radius * 2 + 2), new Color(255, 255, 255, 0), fillColor, 0, false);
        }

        private Texture2D GetTexture(int p)
        {
            TilesetData t = Global.GetData<TilesetData>(p, GameData.Tilesets);
            if (t != null)
            {
                return Loader.Texture2D(contentManager, t.MaterialId);
            }
            else
                return null;
        }

        private Texture2D GetMTexture(int p)
        {
            return Loader.Texture2D(contentManager, p);
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
        /// <summary>
        /// Gets scale by zoom
        /// </summary>
        /// <returns></returns>
        private int GetScale()
        {
            if (zoomLevel == 1.0f)
                return 1;
            else if (zoomLevel == 0.5f)
                return 2;
            else if (zoomLevel == 0.25f)
                return 3;
            return 1;
        }
        #endregion

        #region Drag Drop
        private void graphicsControl_DragEnter(object sender, DragEventArgs e)
        {
            if (map != null && (e.Data.GetDataPresent(typeof(TreeNode))))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (node == MainForm.eventsExplorer.SelectedNode && MainForm.eventsExplorer.Data() != null)
                {

                    e.Effect = DragDropEffects.Copy;
                }
                else if (node == MainForm.materialExplorer.SelectedNode && MainForm.materialExplorer.Data() != null && MainForm.materialExplorer.Data().DataType == MaterialDataType.Image)
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void graphicsControl_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (map != null)
                {
                    TreeNode _node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    if (_node == MainForm.eventsExplorer.SelectedNode && MainForm.eventsExplorer.Data() != null)
                    {
                        if (e.Data.GetDataPresent(typeof(TreeNode)))
                        {
                            EventData node = MainForm.eventsExplorer.Data();

                            System.Drawing.Point cp = this.PointToClient(new System.Drawing.Point(e.X, e.Y));
                            System.Drawing.PointF p = camera.GetTransformedPoint(cp);
                            float x = p.X;
                            float y = p.Y;
                            if (snapToW || SnapToGrid)
                                x = (float)Math.Floor((double)(p.X / gridWidth)) * gridWidth;
                            if (snapToH || SnapToGrid)
                                y = (float)Math.Floor((double)(p.Y / gridHeight)) * gridHeight;
                            map.AddEvent(node, new Vector2(x, y), selectedLayer);
                            selectedEvent = node;
                            MainForm.NeedSave = true;
                            MainForm.mapEditor.mapEditor2.eventBtn_CheckedChanged(true);
                        }
                        else if (e.Data.GetDataPresent(typeof(PlayerData)))
                        {
                            PlayerData node = (PlayerData)e.Data.GetData(typeof(PlayerData));
                            System.Drawing.Point cp = this.PointToClient(new System.Drawing.Point(e.X, e.Y));
                            System.Drawing.PointF p = camera.GetTransformedPoint(cp);
                            float x = p.X;
                            float y = p.Y;
                            if (snapToW || SnapToGrid)
                                x = (float)Math.Floor((double)(p.X / gridWidth)) * gridWidth;
                            if (snapToH || SnapToGrid)
                                y = (float)Math.Floor((double)(p.Y / gridHeight)) * gridHeight;
                            map.AddEvent(node, new Vector2(x, y), selectedLayer);
                            selectedEvent = node;
                            MainForm.mapEditor.mapEditor2.eventBtn_CheckedChanged(true);
                        }
                    }
                    else if (_node == MainForm.materialExplorer.SelectedNode && MainForm.materialExplorer.Data() != null && MainForm.materialExplorer.Data().DataType == MaterialDataType.Image)
                    {
                        System.Drawing.Point cp = this.PointToClient(new System.Drawing.Point(e.X, e.Y));
                        System.Drawing.PointF p = camera.GetTransformedPoint(cp);
                        Vector2 size = GetTextureSize(MainForm.materialExplorer.Data().ID);
                        float x = p.X + size.X / 2;
                        float y = p.Y + size.Y / 2;
                        selectedLayer.Backgrounds.Add(new LayerBackground() { MaterialId = MainForm.materialExplorer.Data().ID, Size = size, Position = new Vector2(x, y) - size / 2 });

                        MainForm.mapEditor.mapEditor2.tsbEnableLayer_Click(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "29x002");
            }
        }

        private Vector2 GetTextureSize(int id)
        {
            Texture2D tex = Loader.Texture2D(contentManager, id);
            if (tex == null)
                return Vector2.Zero;
            return new Vector2(tex.Width, tex.Height);
        }
        #endregion

        #region Layer
        private void LayerAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<LayerData>)hist.Collection).Insert(hist.Index, (LayerData)data);
            SetupLayers();
        }

        private void LayerRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<LayerData>)hist.Collection).RemoveAt(hist.Index);
            SetupLayers();
        }

        private void LayerIndexChanged(IGameDataIndexHist hist, IGameData data)
        {
            ((List<LayerData>)hist.Collection).Remove((LayerData)data);
            ((List<LayerData>)hist.Collection).Insert(hist.NewIndex, (LayerData)data);

            MainForm.layersExplorer.layersList.SelectedIndex = hist.NewIndex;
            SetupLayers();
        }

        public bool layersList_ItemCheckState(object sender, AddRemoveListEventArgs ca)
        {
            return map.Layers[ca.Index].IsVisible;
        }

        public void layersList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            LayerData layer = new LayerData();
            layer.Name = Global.GetName("Layer", map.Layers);
            layer.ID = Global.GetID(map.Layers);
            layer.Tiles = new List<TileData>();
            layer.IsVisible = true;

            ///layer.Tiles.CreateCollection(Map.Data.Size, layer.Tiles.DisplayRect * 2);

            map.NewLayer(layer);

            // History
            MainForm.MapEditorHistory[this].Do(new IGameDataAddedHist(layer, new DataAddDelegate(LayerAdded), new DataRemoveDelegate(LayerRemoved), map.Layers, map.Layers.IndexOf(layer)));

            SetupLayers();
        }

        public void layersList_ItemCheckedState(object sender, CheckedAddRemoveListEventArgs ca)
        {
            map.Layers[ca.Index].IsVisible = ca.Node.Checked;
        }

        public void layersList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (MainForm.layersExplorer.layersList.Count > 1)
            {
                // History
                MainForm.MapEditorHistory[this].Do(new IGameDataRemovedHist(map.Layers[ca.Index], new DataAddDelegate(LayerAdded), new DataRemoveDelegate(LayerRemoved), map.Layers, ca.Index));

                map.DeleteLayer(ca.Index);
                SetupLayers();
            }
        }

        public void layersList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (MainForm.layersExplorer.layersList.SelectedIndex > -1 && map != null)
            {

                selectedLayer = map.Data.Layers[MainForm.layersExplorer.layersList.SelectedIndex];
                MainForm.mapEditor.mapEditor2.SelectLayer(selectedLayer);
                ClearSelected();
            }
        }

        public void layersList_UpItem(object sender, AddRemoveListEventArgs ca)
        {
            if (MainForm.layersExplorer.layersList.SelectedIndex > -1)
            {
                LayerData action = map.Layers[MainForm.layersExplorer.layersList.SelectedIndex];
                // Up
                int i = map.Layers.IndexOf(action);
                if (i > 0)
                {
                    MainForm.MapEditorHistory[this].Do(new IGameDataIndexHist(action, new DataIndexDelegate(LayerIndexChanged), map.Layers, i - 1, i));
                    map.Layers.Remove(action);
                    map.Layers.Insert(i - 1, action);
                    SetupLayers();
                    MainForm.layersExplorer.layersList.SelectedIndex = i - 1;
                    MainForm.mapEventsExplorer.Setup();
                }
            }
        }

        public void layersList_DownItem(object sender, AddRemoveListEventArgs ca)
        {
            if (MainForm.layersExplorer.layersList.SelectedIndex > -1)
            {
                LayerData action = map.Layers[MainForm.layersExplorer.layersList.SelectedIndex];
                // Up
                int i = map.Layers.IndexOf(action);
                if (i < map.Layers.Count - 1)
                {
                    MainForm.MapEditorHistory[this].Do(new IGameDataIndexHist(action, new DataIndexDelegate(LayerIndexChanged), map.Layers, i + 1, i));
                    map.Layers.Remove(action);
                    map.Layers.Insert(i + 1, action);
                    SetupLayers();
                    MainForm.layersExplorer.layersList.SelectedIndex = i + 1;
                    MainForm.mapEventsExplorer.Setup();
                }
            }
        }
        #endregion

        private void TileRemoved(TileData data)
        {
            if (selectedTile == data)
                selectedTile = null;
        }

        internal void ClearSelected()
        {
            selectedTiles = new List<TileData>[0];
            selectionRectangle = new Rectangle();
            selectedEvent = null;
            selectedTile = null;
            MainForm.HistoryExplorer.UndoRedoEnabled = true;
            tileSettings.Hide();
            eventSettings.Hide();
            layerSettings.Hide();
        }

        internal void SetupScene(MapData scene)
        {
            NewMap(scene);
        }

        public void NewMap(MapData data)
        {
            MainForm.CBTileset.Enabled = false;
            ClearSelected();
            if (data == null)
            {
                map = null;
                SetupLayers();
                return;
            }
            if (map == null)
            {
                map = new Scene(data);
                CheckUI();
                UpdateTiles();
                SetupLayers();
                MainForm.SelectedMap = data;
                gridHeight = (int)data.Grid.Y;
                gridWidth = (int)data.Grid.X;

                MainForm.CBTileset.Enabled = true;

                for (int i = 0; i < map.Data.Layers.Count; i++)
                    for (int j = 0; j < map.Data.Layers[i].Tiles.Count; j++)
                        map.Data.Layers[i].Tiles[j].SetRectangle();

            }
            else if (map.Data != data)
            {
                map = new Scene(data);
                MainForm.SelectedMap = data;
                CheckUI();
                UpdateTiles();
                SetupLayers();
                gridHeight = (int)data.Grid.Y;
                gridWidth = (int)data.Grid.X;

                MainForm.CBTileset.Enabled = true;

                for (int i = 0; i < map.Data.Layers.Count; i++)
                    for (int j = 0; j < map.Data.Layers[i].Tiles.Count; j++)
                        map.Data.Layers[i].Tiles[j].SetRectangle();

            }
        }

        internal void CheckUI()
        {
            if (MainForm.mapEditor.mapEditor2.mapViewer == this)
                MainForm.layersExplorer.layersList.Enabled = (map != null);

            toolStrip2.Enabled = (map != null);
        }

        internal void SetupLayers()
        {
            if (!IsNotMap)
            {
                if (map != null)
                {
                    MainForm.layersExplorer.layersList.SetupList(map.Layers, typeof(LayerData));
                    if (map.Layers.Count > 0 && MainForm.layersExplorer.layersList.SelectedIndex < 0)
                    {
                        MainForm.layersExplorer.layersList.TrySelect(Global.Project.SelectedLayer);
                    }
                    else
                    { layersList_SelectItem(null, null); }
                }
                else
                    MainForm.layersExplorer.layersList.Clear(true);
                MainForm.mapEventsExplorer.SetupList();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brushType != BrushType.EventSelection)
            {
                if (selectedTile != null)
                    ShowTileMenu();
            }
            else if (selectedEvent != null)
            {
                if (selectedEvent is PlayerData)
                {
                    //if (!playerEditor.Visible)
                    //    playerEditor.Show(MainForm.curForm);
                    MainForm.playerEditor.Show(MainForm.Instance.dockPanel);
                    return;
                }
                //eventDialog = new MapEventDialog();
                eventDialog.SelectedEvent = selectedEvent;
                eventDialog.ShowDialog();
            }
        }

        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
            {
                for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                {
                    if (selectedTiles[layerIndex] != null)
                    {
                        foreach (TileData tile in selectedTiles[layerIndex])
                        {
                            map.Data.Layers[layerIndex].Tiles.Remove(tile);
                            map.Data.Layers[layerIndex].Tiles.Add(tile);
                        }
                    }
                }
                ClearSelected();
            }
            else if (brushType == BrushType.CursorSingle)
            {
                TileData tile = selectedTile;
                if (tile != null)
                {
                    selectedLayer.Tiles.Remove(tile);
                    selectedLayer.Tiles.Add(tile);
                }
            }
            else if (selectedEvent != null)
            {

            }
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
            {
                for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                {
                    if (selectedTiles[layerIndex] != null)
                    {
                        foreach (TileData tile in selectedTiles[layerIndex])
                        {
                            map.Data.Layers[layerIndex].Tiles.Remove(tile);
                            map.Data.Layers[layerIndex].Tiles.Insert(0, tile);
                        }
                    }
                }
                ClearSelected();
            }
            else if (brushType == BrushType.CursorSingle)
            {
                TileData tile = selectedTile;
                if (tile != null)
                {
                    selectedLayer.Tiles.Remove(tile);
                    selectedLayer.Tiles.Insert(0, tile);
                }
            }
            else if (selectedEvent != null)
            {

            }
        }

        internal void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked && showCollision)
            {
                if (selectedCollision != null)
                {
                    selectedLayer.CollisionData.Remove(selectedCollision);
                    Global.Copy(selectedCollision);
                    ClearSelected();

                    MainForm.MapEditorHistory[this].Do(new ColRemovedHist(selectedCollision, new DataColAddDelegate(ColAdded), new DataColRemoveDelegate(ColRemoved), selectedLayer));

                    selectedCollision = null;



                }
            }
            else
            {

                if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
                {
                    for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                    {
                        if (selectedTiles[layerIndex] != null)
                        {
                            foreach (TileData tile in selectedTiles[layerIndex])
                            {
                                tilesReplacedHistory.Add(tile);
                                map.Data.Layers[layerIndex].Tiles.Remove(tile);
                            }
                            if (tilesReplacedHistory.Count > 0)
                                MainForm.MapEditorHistory[this].Do(new TilesRemoved(tilesReplacedHistory, new List<TileData>(), map.Data.Layers[layerIndex].Tiles, new DataTRemoveDelegate(TileRemoved)));
                            tilesReplacedHistory.Clear();
                        }
                    }

                    Global.Copy(new TileClipboard(selectedTiles, selectionRectangle));
                    ClearSelected();
                }
                else
                {
                    if (brushType == BrushType.CursorSingle)
                    {
                        if (selectedTile != null)
                        {
                            Global.Copy(selectedTile);
                            MainForm.MapEditorHistory[this].Do(new TilesRemoved(new List<TileData>() { selectedTile }, new List<TileData>(), selectedLayer.Tiles, new DataTRemoveDelegate(TileRemoved)));

                            selectedLayer.Tiles.Remove(selectedTile);
                        }
                        selectedTile = null;
                    }
                    else if (selectedEvent != null && brushType == BrushType.EventSelection)
                    {
                        if (selectedLayer.Events.ContainsKey(selectedEvent.ID))
                        {
                            Global.Copy(selectedEvent);
                            selectedLayer.Events.Remove(selectedEvent.ID);

                            // Event Removed
                            MainForm.MapEditorHistory[this].Do(new EventRemovedHist(selectedEvent, new DataEAddDelegate(EventAdded), new DataERemoveDelegate(EventRemoved), selectedLayer));

                            MainForm.mapEventsExplorer.SetupList();
                            selectedEvent = null;
                        }
                    }
                }
            }
        }

        internal void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked && showCollision)
            {
                if (selectedCollision != null)
                {
                    Global.Copy(selectedCollision);
                }
            }
            else
            {
                if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
                {
                    Global.Copy(new TileClipboard(selectedTiles, selectionRectangle));
                }
                else
                {
                    if (brushType == BrushType.CursorSingle)
                    {
                        if (selectedTile != null)
                        {
                            Global.Copy(selectedTile);
                        }
                    }
                    else if (selectedEvent != null && brushType == BrushType.EventSelection)
                    {
                        if (selectedLayer.Events.ContainsKey(selectedEvent.ID))
                        {
                            Global.Copy(selectedEvent);
                        }
                    }
                }
            }
        }

        internal void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object obj = Global.PasteData();
            // Update mouse position label
            float x = currentMouse.X; float y = currentMouse.Y;
            if (SnapToGrid || snapToW)
                x = (float)Math.Floor((double)(currentMouse.X / gridWidth)) * gridWidth;
            if (SnapToGrid || snapToH)
                y = (float)Math.Floor((double)(currentMouse.Y / gridHeight)) * gridHeight;

            if (obj is TileClipboard)
            {
                ClearSelected();
                TileClipboard tilesClipboard = (TileClipboard)obj;
                selectedTiles = new List<TileData>[map.Data.Layers.Count];

                if (tilesClipboard.SelectedTiles.Count() > 1)
                {
                    for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                    {
                        selectedTiles[layerIndex] = new List<TileData>();
                        if (tilesClipboard.SelectedTiles[layerIndex] != null)
                        {
                            foreach (TileData tile in tilesClipboard.SelectedTiles[layerIndex])
                            {
                                tile.Position += new Vector2(x, y);
                                map.Data.Layers[layerIndex].Tiles.Add(tile);
                                selectedTiles[layerIndex].Add(tile);
                                tile.SetRectangle();
                            }
                        }
                    }
                }
                else
                {
                    if (selectedLayer != null)
                    {
                        List<TileData> rt = new List<TileData>();
                        for (int layerIndex = 0; layerIndex < 999999; layerIndex++)
                        {
                            selectedTiles[layerIndex] = new List<TileData>();
                            if (tilesClipboard.SelectedTiles[layerIndex] != null)
                            {
                                foreach (TileData tile in tilesClipboard.SelectedTiles[layerIndex])
                                {
                                    tile.Position += new Vector2(x, y);
                                    selectedLayer.Tiles.Add(tile);
                                    tile.SetRectangle();
                                    selectedTiles[layerIndex].Add(tile);
                                }
                                break;
                            }
                        }
                    }
                }
                pasted = true;
            }
            else if (obj is TileData)
            {
                TileData tile = (TileData)obj;
                tile.Position = new Vector2((int)x, (int)y);
                tile.SetRectangle();
                tilesHistory.Add(tile);
                List<TileData> rt = ClearTiles(tile.Position);
                selectedLayer.Tiles.Add(tile);

                //if (rt != null && rt.Count > 0)
                //    MainForm.MapEditorHistory[this].Do(new TilesRemoved(rt, new List<TileData>(), selectedLayer.Tiles));

                if (tilesHistory.Count > 0)
                    MainForm.MapEditorHistory[this].Do(new TilesAdded(tilesHistory, rt, selectedLayer.Tiles, new DataTRemoveDelegate(TileRemoved)));
                tilesHistory.Clear();
            }
            else if (obj is EventData)
            {
                EventData ev = (EventData)obj;
                y += gridHeight;
                ev.Position = new Vector2((int)x, (int)y);
                ev.ID = Global.GetID(Global.GetMapEventList(map.Data));
                ev.MapID = map.Data.ID;
                selectedLayer.Events.Add(ev.ID, ev);
                // Event Added
                MainForm.MapEditorHistory[this].Do(new EventAddedHist(ev, new DataEAddDelegate(EventAdded), new DataERemoveDelegate(EventRemoved), selectedLayer));
            }
            else if (obj is CollisionData)
            {
                CollisionData cd = (CollisionData)obj;
                cd.ResetAABB();
                selectedLayer.CollisionData.Add(cd);
                selectedCollision = cd;
                Vector2 movedPos = Vector2.Zero;

                if (snapToW || SnapToGrid)
                    movedPos.X = -selectedCollision.Position.X;
                else
                    movedPos.X = -selectedCollision.Position.X;

                if (snapToH || SnapToGrid)
                    movedPos.Y = -selectedCollision.Position.Y;
                else
                    movedPos.Y = -selectedCollision.Position.Y;


                selectedCollision.Translate(ref movedPos);
                movedPos = new Vector2((int)x, (int)y);
                selectedCollision.Translate(ref movedPos);


                MainForm.MapEditorHistory[this].Do(new ColAddedHist(selectedCollision, new DataColAddDelegate(ColAdded), new DataColRemoveDelegate(ColRemoved), selectedLayer));
            }
        }

        private void moveDownLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TileData> tiles;
            if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
            {
                for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                {
                    if (selectedTiles[layerIndex] != null && layerIndex > 0)
                    {
                        tiles = new List<TileData>(selectedTiles[layerIndex]);
                        foreach (TileData tile in tiles)
                        {
                            map.Data.Layers[layerIndex].Tiles.Remove(tile);
                            map.Data.Layers[layerIndex - 1].Tiles.Add(tile);
                            selectedTiles[layerIndex].Remove(tile);
                            if (selectedTiles[layerIndex - 1] == null)
                                selectedTiles[layerIndex - 1] = new List<TileData>();
                            selectedTiles[layerIndex - 1].Add(tile);
                        }
                    }
                }
            }
            else
            {
                if (brushType == BrushType.CursorSingle)
                {
                    if (selectedTile != null)
                    {
                        for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                        {
                            if (selectedLayer == map.Data.Layers[layerIndex] && layerIndex > 0)
                            {
                                map.Data.Layers[layerIndex].Tiles.Remove(selectedTile);
                                map.Data.Layers[layerIndex - 1].Tiles.Add(selectedTile);
                            }
                        }
                    }
                }
                else if (selectedEvent != null && brushType == BrushType.EventSelection)
                {
                    if (selectedEvent is PlayerData)
                    {
                        if (GameData.Player.LayerIndex > 0)
                            GameData.Player.LayerIndex -= 1;
                    }
                    else
                    {
                        for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                        {
                            if (selectedLayer == map.Data.Layers[layerIndex] && layerIndex > 0)
                            {
                                map.Data.Layers[layerIndex].Events.Remove(selectedEvent.ID);
                                map.Data.Layers[layerIndex - 1].Events.Add(selectedEvent.ID, selectedEvent);
                            }
                        }
                    }
                }
            }
        }

        private void moveUpLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TileData> tiles;
            if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
            {
                for (int layerIndex = map.Data.Layers.Count - 1; layerIndex > -1; layerIndex--)
                {
                    if (selectedTiles[layerIndex] != null && layerIndex + 1 < map.Data.Layers.Count)
                    {
                        tiles = new List<TileData>(selectedTiles[layerIndex]);
                        foreach (TileData tile in tiles)
                        {
                            map.Data.Layers[layerIndex].Tiles.Remove(tile);
                            map.Data.Layers[layerIndex + 1].Tiles.Add(tile);
                            selectedTiles[layerIndex].Remove(tile);
                            if (selectedTiles[layerIndex + 1] == null)
                                selectedTiles[layerIndex + 1] = new List<TileData>();
                            selectedTiles[layerIndex + 1].Add(tile);
                        }
                    }
                }
            }
            else
            {
                if (brushType == BrushType.CursorSingle)
                {
                    if (selectedTile != null)
                    {
                        for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                        {
                            if (selectedLayer == map.Data.Layers[layerIndex] && layerIndex + 1 < map.Data.Layers.Count)
                            {
                                map.Data.Layers[layerIndex].Tiles.Remove(selectedTile);
                                map.Data.Layers[layerIndex + 1].Tiles.Add(selectedTile);
                            }
                        }
                    }
                }
                else if (selectedEvent != null && brushType == BrushType.EventSelection)
                {
                    if (selectedEvent is PlayerData)
                    {
                        if (GameData.Player.LayerIndex + 1 < map.Data.Layers.Count)
                            GameData.Player.LayerIndex += 1;
                    }
                    else
                    {
                        for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                        {
                            if (selectedLayer == map.Data.Layers[layerIndex] && layerIndex + 1 < map.Data.Layers.Count)
                            {
                                map.Data.Layers[layerIndex].Events.Remove(selectedEvent.ID);
                                map.Data.Layers[layerIndex + 1].Events.Add(selectedEvent.ID, selectedEvent);
                            }
                        }
                    }
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked && showCollision)
            {
                if (selectedNodeIndexes.Count > 0)
                {
                    deleteBtn_ButtonClick(null, null);
                }
                else
                    clearAllToolStripMenuItem_Click(null, null);
            }
            else
            {
                if ((brushType == BrushType.CursorMulti || brushType == BrushType.CursorMultiLayer) && selectedTiles.Count() > 0)
                {
                    for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                    {
                        if (selectedTiles[layerIndex] != null)
                        {
                            foreach (TileData tile in selectedTiles[layerIndex])
                            {
                                tilesReplacedHistory.Add(tile);
                                map.Data.Layers[layerIndex].Tiles.Remove(tile);
                            }
                            if (tilesReplacedHistory.Count > 0)
                                MainForm.MapEditorHistory[this].Do(new TilesRemoved(tilesReplacedHistory, new List<TileData>(), map.Data.Layers[layerIndex].Tiles, new DataTRemoveDelegate(TileRemoved)));
                            tilesReplacedHistory.Clear();
                        }
                    }
                    ClearSelected();
                }
                else
                {
                    if (brushType == BrushType.CursorSingle)
                    {
                        if (selectedTile != null)
                        {
                            tilesReplacedHistory.Add(selectedTile);
                            MainForm.MapEditorHistory[this].Do(new TilesRemoved(tilesReplacedHistory, new List<TileData>(), selectedLayer.Tiles, new DataTRemoveDelegate(TileRemoved)));

                            selectedLayer.Tiles.Remove(selectedTile);
                        }
                        tilesReplacedHistory.Clear();
                        selectedTile = null;

                        if (tileSettings != null)
                            tileSettings.Hide();
                    }
                    else if (selectedEvent != null && brushType == BrushType.EventSelection)
                    {
                        if (selectedLayer.Events.ContainsKey(selectedEvent.ID))
                        {
                            selectedLayer.Events.Remove(selectedEvent.ID);
                            // Event Removed
                            MainForm.MapEditorHistory[this].Do(new EventRemovedHist(selectedEvent, new DataEAddDelegate(EventAdded), new DataERemoveDelegate(EventRemoved), selectedLayer));

                            MainForm.mapEventsExplorer.SetupList();
                            selectedEvent = null;

                            if (eventSettings != null)
                                eventSettings.Hide();
                        }
                    }
                    else if (brushType == BrushType.LayerSelection)
                    {
                        if (selectedLayerBG != null)
                        {
                            selectedLayer.Backgrounds.Remove(selectedLayerBG);
                            selectedLayerBG = null;

                            if (layerSettings != null)
                                layerSettings.Hide();
                        }
                    }
                }
            }
        }

        private void frontCTRLDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brushType == BrushType.CursorSingle)
            {
                TileData tile = selectedTile;
                if (tile != null)
                {
                    //selectedLayer.Tiles.Remove(tile);
                    //selectedLayer.Tiles.Add(tile);
                }
            }
            else if (selectedEvent != null)
            {
                if (selectedLayer.Events.ContainsKey(selectedEvent.ID))
                {
                    selectedLayer.Events.Remove(selectedEvent.ID);
                    selectedLayer.Events.Add(selectedEvent.ID, selectedEvent);
                }
            }
        }

        private void backCTRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brushType == BrushType.CursorSingle)
            {
                TileData tile = selectedTile;
                if (tile != null)
                {
                    //selectedLayer.Tiles.Remove(tile);
                    // selectedLayer.Tiles.Insert(0, tile);
                }
            }
            else if (selectedEvent != null)
            {
                EventData ev = selectedEvent;
            }
        }

        #region IHistory Members

        public string GetActionName()
        {
            throw new NotImplementedException();
        }

        #endregion


        internal void ResetContentManager()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            lastPTilesetID = -1;
            lastTilesetID = -1;
        }

        private void addPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerData node = GameData.Player;
            float x = currentMouse.X;
            float y = currentMouse.Y;
            if (snapToW || SnapToGrid)
                x = (float)Math.Floor((double)(x / gridWidth)) * gridWidth;
            if (snapToH || SnapToGrid)
                y = (float)Math.Floor((double)(y / gridHeight)) * gridHeight;
            map.AddEvent(node, new Vector2(x, y), selectedLayer);
            selectedEvent = node;
        }

        private void tileMenu_Opening(object sender, CancelEventArgs e)
        {
            if (brushType != BrushType.CursorSingle && brushType != BrushType.EventSelection && brushType != BrushType.CursorMulti && brushType != BrushType.CursorMultiLayer && brushType != BrushType.LayerSelection)
                e.Cancel = true;
        }

        private void btnCorrectMap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you upgraded to version 0.9.2, your tiles might be offplaced. This will correct your tile coordinates. You cannot undo this. Proceed?", "Correct Tile Placement?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //List<List<TileData>> listOfTiles;
                //for (int layerIndex = 0; layerIndex < map.Data.Layers.Count; layerIndex++)
                //{
                //    listOfTiles = map.Data.Layers[layerIndex].Tiles.GetSections(map.Data.Layers[layerIndex].Tiles.GetIndex(map.Data.Size), 10000);

                //    for (int tilesIndex = 0; tilesIndex < listOfTiles.Count; tilesIndex++)
                //    {
                //        for (int tileIndex = 0; tileIndex < map.Data.Layers[layerIndex].Tiles.Count; tileIndex++)
                //        {
                //            map.Data.Layers[layerIndex].Tiles[tileIndex].Position += map.Data.Layers[layerIndex].Tiles[tileIndex].Size / 2;
                //        }
                //    }
                //}
            }
        }

        private void tbOpacity_ValueChanged(object sender, decimal value)
        {
            if (selectedTile != null && !tileSettings.Visible)
            {
                selectedTile.Opacity = (byte)tbOpacity.Value;
            }
        }

        private void graphicsControl_MouseEnter(object sender, EventArgs e)
        {
            CheckCursor();
        }

        private void physicsBtn_CheckedChanged(object sender, EventArgs e)
        {
            btnLayout.Checked = btnAddRectangle.Checked = btnAddNode.Checked = btnAddCircle.Checked = false;
            if (physicsBtn.Checked)
            {
                btnLayout.Visible = btnAddCircle.Visible =
                btnAddNode.Visible =
                btnAddRectangle.Visible =
                seperator3.Visible =
                seperator2.Visible =
                subdivideBtn.Visible =
                simpifyBtn.Visible =
                deleteBtn.Visible = true;
                seperator.Visible = true;
            }
            else
            {
                seperator.Visible =
                btnLayout.Visible = btnAddCircle.Visible =
                btnAddNode.Visible =
                btnAddRectangle.Visible =
                seperator3.Visible =
                seperator2.Visible =
                subdivideBtn.Visible =
                simpifyBtn.Visible =
                deleteBtn.Visible = false;
                addingPhysics = false;
            }
        }

        private void btnAddNode_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddNode.Checked)
            {
                btnAddRectangle.Checked = false;
                btnAddCircle.Checked = false;

                addingPhysics = true;
                physicsType = PhysicsType.Node;
                selectedNodeIndexes.Clear();

            }
            else
                addingPhysics = false;
        }

        private void btnAddRectangle_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddRectangle.Checked)
            {
                btnAddNode.Checked = false;
                btnAddCircle.Checked = false;
                btnLayout.Checked = false;

                addingPhysics = true;
                physicsType = PhysicsType.Rect;
                selectedNodeIndexes.Clear();

            }
            else
                addingPhysics = false;
        }

        private void btnLayout_CheckedChanged(object sender, EventArgs e)
        {
            if (btnLayout.Checked)
            {
                btnAddRectangle.Checked = false;
                btnAddCircle.Checked = false;
                btnAddNode.Checked = false;

                addingPhysics = true;
                physicsType = PhysicsType.Layout;
                selectedNodeIndexes.Clear();
            }
            else
                addingPhysics = false;
        }

        private void btnAddCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddCircle.Checked)
            {
                btnAddRectangle.Checked = false;
                btnAddNode.Checked = false;
                btnLayout.Checked = false;

                addingPhysics = true;
                physicsType = PhysicsType.Circle;
                selectedNodeIndexes.Clear();

            }
            else
                addingPhysics = false;
        }

        private void deleteBtn_ButtonClick(object sender, EventArgs e)
        {
            if (selectedNodeIndexes.Count > 0)
            {
                //bool remove = false;
                List<List<Vector2>> removeList = new List<List<Vector2>>();
                List<Vertices> bodies = new List<Vertices>();
                bodies.Add(selectedCollision);
                removeList.Add(new List<Vector2>());
                for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedNodeIndexes[nodeIndex] < selectedCollision.Count)
                    {
                        //remove = true;
                        //removeList[i].Add(selectedTiles[i].Body[selectedNodeIndexes[nodeIndex]]);
                        selectedCollision.RemoveAt(selectedNodeIndexes[nodeIndex]);
                    }
                }
                //if (remove)
                // MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new TilesetCollisionRemovedHist(removeList, bodies, selectedNodeIndexes));

                if (selectedCollision.Count == 0)
                    selectedLayer.CollisionData.Remove(selectedCollision);

            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedCollision != null)
            {
                selectedLayer.CollisionData.Remove(selectedCollision);
                MainForm.MapEditorHistory[this].Do(new ColRemovedHist(selectedCollision, new DataColAddDelegate(ColAdded), new DataColRemoveDelegate(ColRemoved), selectedLayer));
                selectedCollision = null;
            }
        }

        private void subdivideBtn_Click(object sender, EventArgs e)
        {
            if (selectedCollision != null)
            {
                selectedCollision.SubDivideEdges(25f);
            }
        }

        private void simpifyBtn_Click(object sender, EventArgs e)
        {
            if (selectedCollision != null)
            {
                for (int i = 0; i < selectedLayer.CollisionData.Count; i++)
                {
                    if (selectedCollision == selectedLayer.CollisionData[i])
                    {
                        selectedLayer.CollisionData[i] = selectedCollision = CollisionData.Simplify(selectedCollision);
                    }
                }
            }
        }




        public bool DoNotDrawPlayer;


        public bool IsNotMap;
    }
    [Serializable]
    public class TileClipboard
    {
        public List<TileData>[] SelectedTiles
        {
            get { return selectedTiles; }
            set { selectedTiles = value; }
        }
        List<TileData>[] selectedTiles = new List<TileData>[0];

        public Rectangle SelectionRectangle
        {
            get { return selectionRectangle; }
            set { selectionRectangle = value; }
        }
        Rectangle selectionRectangle;

        public List<Vector2>[] SelectedOffsets
        {
            get { return selectedOffsets; }
            set { selectedOffsets = value; }
        }
        List<Vector2>[] selectedOffsets = new List<Vector2>[0];

        public TileClipboard()
        {
        }

        public TileClipboard(List<TileData>[] sel, Rectangle selection)
        {
            selectedTiles = new List<TileData>[sel.Count()];
            for (int layerIndex = 0; layerIndex < 999999; layerIndex++)
            {
                if (selectedTiles.Count() - 1 < layerIndex)
                    break;
                if (sel[layerIndex] != null)
                {
                    selectedTiles[layerIndex] = new List<TileData>(sel[layerIndex].Count);

                    foreach (TileData tile in sel[layerIndex])
                    {
                        selectedTiles[layerIndex].Add(tile.Clone());
                    }
                }
            }
            selectionRectangle = new Rectangle(selection.X, selection.Y, selection.Width, selection.Height);
            SetOffset();
        }

        private void SetOffset()
        {
            Vector2 lowestPos = new Vector2();
            bool assigned = false;
            selectedOffsets = new List<Vector2>[selectedTiles.Count()];
            for (int layerIndex = 0; layerIndex < 999999; layerIndex++)
            {
                if (selectedTiles.Count() - 1 < layerIndex)
                    break;
                if (selectedTiles[layerIndex] != null)
                {
                    selectedOffsets[layerIndex] = new List<Vector2>();
                    foreach (TileData tile in selectedTiles[layerIndex])
                    {
                        if (!assigned)
                        {
                            lowestPos.X = tile.Position.X;
                            lowestPos.Y = tile.Position.Y;
                            assigned = true;
                        }
                        if (tile.Position.X < lowestPos.X)
                            lowestPos.X = tile.Position.X;
                        if (tile.Position.Y < lowestPos.Y)
                            lowestPos.Y = tile.Position.Y;
                    }
                }
            }
            for (int layerIndex = 0; layerIndex < 999999; layerIndex++)
            {
                if (selectedTiles.Count() - 1 < layerIndex)
                    break;
                if (selectedTiles[layerIndex] != null)
                {
                    foreach (TileData tile in selectedTiles[layerIndex])
                    {
                        tile.Position -= lowestPos;
                    }
                }
            }
            selectionRectangle.X -= (int)lowestPos.X;
            selectionRectangle.Y -= (int)lowestPos.Y;
        }
    }
}

//#region OffSet SpriteBatch


//private void Draw(Texture2D dir, Rectangle rectangle, Color color)
//{
//    rectangle.X += (int)MapOffset.X;
//    rectangle.Y += (int)MapOffset.Y;
//    spriteBatch.Draw(dir, rectangle, color);
//}
//public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color);

//public void Draw(Texture2D texture, Vector2 position, Color color);

//public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color);

//public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color);

//public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);

//public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);


//public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);


//public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color);


//public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color);


//public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);


//public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);


//public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);


//public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);

//#endregion