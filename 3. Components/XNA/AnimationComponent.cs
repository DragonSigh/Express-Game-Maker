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
using System.Drawing.Imaging;
using System.Diagnostics;
using FarseerPhysics;
using FarseerPhysics.Collisions;
using FarseerPhysics.Common;

namespace EGMGame.Controls
{
    public partial class AnimationComponent : UserControl
    {
        #region Fields
        public AnimationAction SelectedAction;
        public AnimationFrame SelectedFrame
        {
            get { return frame; }
            set { frame = value; SetupFrame(); }
        }
        AnimationFrame frame;
        public AnimationFrame DrawFrame;
        public AnimationFrame PreviousFrame
        {
            get { return pframe; }
            set { pframe = value; }
        }
        AnimationFrame pframe;

        internal List<AnimationFrame> SelectedDirection
        {
            get { return selectedDirection; }
            set { selectedDirection = value; }
        }
        List<AnimationFrame> selectedDirection;


        public object SelectedData
        {
            get { return selectedData; }
            set
            {
                selectedData = value;
                allowChange = false;
                syncSameNumberAnchorsToolStripMenuItem.Visible = false;
                if (SelectedFrame != null && value != null)
                {
                    if (value is AnimationSprite)
                    {
                        int index = SelectedFrame.Sprites.IndexOf((AnimationSprite)value);
                        if (index < selData.Items.Count)
                            selData.SelectedIndex = index;

                        MainForm.animationEditor.SetupSprite((AnimationSprite)value);
                        MainForm.animationEditor.SetupPin(null);
                        MainForm.animationEditor.SetupParticle(null);
                    }
                    else if (value is AnimationAnchor)
                    {
                        int index = SelectedFrame.Anchors.IndexOf((AnimationAnchor)value);
                        if (index < selData.Items.Count)
                            selData.SelectedIndex = index;
                        MainForm.animationEditor.SetupPin(null);
                        MainForm.animationEditor.SetupParticle(null);
                        syncSameNumberAnchorsToolStripMenuItem.Visible = true;
                    }
                    else if (value is PhysicsPin)
                    {
                        int index = SelectedAction.Pins.IndexOf((PhysicsPin)value);
                        if (index < selData.Items.Count)
                            selData.SelectedIndex = index;
                        MainForm.animationEditor.SetupPin((PhysicsPin)value);
                        MainForm.animationEditor.SetupParticle(null);
                    }
                    else if (value is AnimationParticle)
                    {
                        int index = SelectedAction.Particles[SelectedAction.Directions.IndexOf(selectedDirection)].IndexOf((AnimationParticle)value);
                        if (index < selData.Items.Count)
                            selData.SelectedIndex = index;
                        MainForm.animationEditor.SetupParticle((AnimationParticle)value);
                        MainForm.animationEditor.SetupPin(null);
                    }
                }
                else
                {
                    selData.SelectedIndex = -1;
                    if (MainForm.animationEditor != null)
                    {
                        MainForm.animationEditor.SetupPin(null);
                        MainForm.animationEditor.SetupParticle(null);
                    }
                }
                allowChange = true;
            }
        }
        object selectedData;

        bool allowChange = true;

        bool multiSelect = false;

        public bool SelectOrigin;
        #endregion

        #region Variables
        // Content variables
        ContentManager contentManager;
        // Render variables
        GraphicsDevice graphicsDevice;
        // Drawing variables
        SpriteBatch spriteBatch;
        Texture2D pixelTexture;
        Texture2D anchorTexture;
        // Camera
        XNA2dCamera camera;

        AnimationView viewType = AnimationView.Sprite;
        MouseState mouseState = MouseState.Up;
        HandleStyle mouseHandle = HandleStyle.None;

        // Image/Camera Variables
        float zoomLevel = 1.0f;
        // Offsets
        float mouseOffx = 0;
        float mouseOffy = 0;
        System.Drawing.PointF mousePos = new System.Drawing.PointF(0, 0);
        Vector2 originalScale;
        Vector2 originalLocation;
        float originalRotation;

        // Selection variables
        bool IsMouseDown;
        Vector2 originalMouse;
        System.Drawing.Point currentMouse;
        bool ctrl1 = false;
        bool ctrl2 = false;
        bool shift = false;
        bool snapToW = false;
        bool snapToH = false;
        bool dDown = false;
        bool isMiddleDown;
        int oldScrollY = 0;
        int oldScrollX = 0;

        System.Drawing.Point mousePoint = new System.Drawing.Point(0, 0);
        System.Drawing.Point lastMousePos = new System.Drawing.Point(0, 0);

        //calculate FPS
        Stopwatch timer;
        long nCount = 0;
        long uCount = 0;
        long TimeLast;
        long TimeNow;
        long TimeElapsed = 0;

        public float FPS;

        // Animation
        bool playAnimation = false;
        int animationCounter = 0;
        int animationLoopCount = 0;

        // Physics
        bool addingPhysics = false;
        bool addingNode = false;
        PhysicsType physicsType = PhysicsType.Node;
        List<int> selectedNodeIndexes = new List<int>();
        int selectedNodeIndex = -1;

        List<int> selectedHitNodeIndexes = new List<int>();
        int selectedHitNodeIndex = -1;

        Vertices originalCollisionBody = new Vertices();
        Vertices originalHitBody = new Vertices();

        // Particle
        Texture2D particleTexture;
        #endregion

        #region Events
        public delegate void SelectedItemChangeEvent(object sender, SelectedItemEventArgs ca);
        public event SelectedItemChangeEvent SelectedItemChange;
        public class SelectedItemEventArgs : EventArgs
        {
            public object Item;

            public SelectedItemEventArgs(object i)
            {
                Item = i;
            }

        }
        public delegate void ItemAddedEvent(object sender, ItemAddedEventArgs ca);
        public event ItemAddedEvent ItemAdded;
        public class ItemAddedEventArgs : EventArgs
        {
            public object Item;

            public ItemAddedEventArgs(object i)
            {
                Item = i;
            }

        }
        public delegate void ItemRemovedEvent(object sender, ItemRemovedEventArgs ca);
        public event ItemRemovedEvent ItemRemoved;
        public class ItemRemovedEventArgs : EventArgs
        {
            public object Item;

            public ItemRemovedEventArgs(object i)
            {
                Item = i;
            }

        }
        public delegate void UpdatedEvent(object sender);
        public event UpdatedEvent Updated;
        #endregion

        public AnimationComponent()
        {
            InitializeComponent();
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

            // GUI Initialization
            toolStrip1.Renderer = new ImpactUI.ImpactToolstripRenderer();
            toolStrip2.Renderer = new ImpactUI.ImpactToolstripRenderer();

            // Application Event Hooking 
            Application.Idle += delegate { graphicsControl.Invalidate(); };
            this.Resize += delegate { graphicsControl.Invalidate(); };
            // Scroller
            //bgScroller.RunWorkerAsync();

        }

        #region Property
        private void SetupFrame()
        {
            SelectedData = null;
            if (frame != null && graphicsDevice != null)
            {
                Viewport v = graphicsDevice.Viewport;
                v.Height = Math.Max(1, graphicsControl.Height);
                v.Width = Math.Max(1, graphicsControl.Width);
                // graphicsDevice.Viewport = v;
                camera.Viewport = v;
                camera.ViewingHeight = SelectedAction.CanvasSize.Y;
                camera.ViewingWidth = SelectedAction.CanvasSize.X;
                UpdateScrollbarsW();
                UpdateScrollbarsH();

                SetupView();
            }
        }
        #endregion

        #region Mouse Events
        private void graphicsControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();

            multiSelect = false;

            #region Scroll/Move
            mousePoint = e.Location;
            isMiddleDown = (e.Button == MouseButtons.Middle);
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            originalMouse.X = point.X;
            originalMouse.Y = point.Y;
            lastMousePos = e.Location;
            /// Mouse down and move
            if (ctrl1 && e.Button == MouseButtons.Left)
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

            if (e.Button == MouseButtons.Left)
            {
                mousePos = point;
                mouseState = MouseState.Down;
                if (viewType == AnimationView.Physics)
                {
                    originalCollisionBody = new Vertices(SelectedAction.CollisionBody);
                    originalHitBody = new Vertices(SelectedAction.HitBody);
                    if (!addingPhysics)
                    {
                        if (shift)
                            addingNode = true;

                        Vector2 pos = new Vector2();
                        Rectangle rect = new Rectangle(0, 0, 8, 8);
                        Point p = new Point((int)point.X, (int)point.Y);
                        Vector2 offset = new Vector2();
                        offset.X = -4;
                        offset.Y = -4;
                        for (int i = 0; i < SelectedAction.CollisionBody.Count; i++)
                        {
                            pos = SelectedAction.CollisionBody[i] + offset;
                            rect.X = (int)pos.X;
                            rect.Y = (int)pos.Y;
                            if (rect.Contains(p) && !selectedNodeIndexes.Contains(i))
                            {
                                if (!ctrl2)
                                    selectedNodeIndexes.Clear();
                                selectedNodeIndexes.Add(i);
                                selectedNodeIndex = i;
                                return;
                            }
                            else if (rect.Contains(p) && selectedNodeIndexes.Contains(i))
                            {
                                selectedNodeIndex = i;
                                return;
                            }
                        }
                        selectedNodeIndexes.Clear();
                    }
                }
                else if (viewType == AnimationView.BattlePhysics)
                {
                    if (!addingPhysics)
                    {
                        if (shift)
                            addingNode = true;

                        Vector2 pos = new Vector2();
                        Rectangle rect = new Rectangle(0, 0, 8, 8);
                        Point p = new Point((int)point.X, (int)point.Y);
                        Vector2 offset = new Vector2();
                        offset.X = -4;
                        offset.Y = -4;
                        for (int i = 0; i < SelectedAction.HitBody.Count; i++)
                        {
                            pos = SelectedAction.HitBody[i] + offset;
                            rect.X = (int)pos.X;
                            rect.Y = (int)pos.Y;
                            if (rect.Contains(p) && !selectedHitNodeIndexes.Contains(i))
                            {
                                if (!ctrl2)
                                    selectedHitNodeIndexes.Clear();
                                selectedHitNodeIndexes.Add(i);
                                selectedHitNodeIndex = i;
                                return;
                            }
                            else if (rect.Contains(p) && selectedHitNodeIndexes.Contains(i))
                            {
                                selectedHitNodeIndex = i;
                                return;
                            }
                        }
                        selectedHitNodeIndexes.Clear();
                    }
                }
                else
                {
                    if (viewType == AnimationView.Sprite) SelectSprite(e);
                    if (viewType == AnimationView.Anchor) SelectedAnchor(e);
                    if (viewType == AnimationView.Pin) SelectedPin(e);
                    if (viewType == AnimationView.Particle) SelectParticle(e);
                    selectedNodeIndexes.Clear();
                    if (SelectedData is AnimationSprite && SelectedData != null)
                    {
                        originalScale = Sprite(SelectedData).Scale;
                        originalLocation = Sprite(SelectedData).Position;
                        originalRotation = Sprite(SelectedData).Rotation;
                        return;
                    }
                    // Get Handle
                    GetHandle();
                }
            }

            if (!addingPhysics && e.Button == MouseButtons.Left && (viewType == AnimationView.Physics || viewType == AnimationView.BattlePhysics))
                multiSelect = true;
        }

        private void SelectParticle(MouseEventArgs e)
        {
            if (SelectedAction == null) return;
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            foreach (AnimationParticle anchor in SelectedAction.Particles[SelectedAction.Directions.IndexOf(selectedDirection)])
            {
                if (anchor.GetRectangle().Contains(point))
                {
                    SelectedData = anchor;
                    SelectedItemEventArgs ex = new SelectedItemEventArgs(null);
                    SelectedItemChange(this, ex);
                    anchor.SetOffSet(out mouseOffx, out mouseOffy, point);
                    mouseHandle = HandleStyle.Move;
                    return;
                }
            }
        }

        private void SelectedPin(MouseEventArgs e)
        {
            if (SelectedAction == null) return;
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
            foreach (PhysicsPin anchor in SelectedAction.Pins)
            {
                if (anchor.GetRectangle().Contains(point))
                {
                    SelectedData = anchor;
                    SelectedItemEventArgs ex = new SelectedItemEventArgs(null);
                    SelectedItemChange(this, ex);
                    anchor.SetOffSet(out mouseOffx, out mouseOffy, point);
                    mouseHandle = HandleStyle.Move;
                    return;
                }
            }
        }
        /// <summary>
        /// Add physics to sprite
        /// </summary>
        /// <param name="sprite"></param>
        private void AddPhysicsToSprite(AnimationSprite sprite)
        {
            Vector2 pos = new Vector2(originalMouse.X, originalMouse.Y);
            if (sprite != null)
            {
                pos -= sprite.Position;
                pos -= new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2);
            }
            Vector2 offset = new Vector2(-4, -4);
            Vector2 nodePosition = Vector2.Zero;
            if (sprite != null)
            {
                offset.X += sprite.Position.X;
                offset.Y += sprite.Position.Y;
            }
            Vertices list = new Vertices();
            Vector2 vNew = Vector2.Zero;
            Vector2 cMouse = new Vector2();
            cMouse.X = camera.GetTransformedPoint(currentMouse).X;
            cMouse.Y = camera.GetTransformedPoint(currentMouse).Y;
            switch (physicsType)
            {
                case PhysicsType.Node:
                    if (SelectedAction.CollisionBody.Count > 0)
                    {
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.CollisionBody, SelectedAction.CollisionBody));
                    }
                    SelectedAction.CollisionBody.Clear();
                    pos += sprite.Position;
                    //pos += new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2);
                    if (sprite != null)
                        SelectedAction.CollisionBody.Add(pos + new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                    else
                        SelectedAction.CollisionBody.Add(pos + new Vector2(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2));

                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionAddedHist(SelectedAction.CollisionBody[0], SelectedAction.CollisionBody, 0));
                    break;
                case PhysicsType.Rect:
                    if (originalMouse == cMouse)
                    {
                        if (SelectedAction.CollisionBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.CollisionBody, SelectedAction.CollisionBody));
                        }
                        SelectedAction.CollisionBody.Clear();
                        if (sprite != null)
                            SelectedAction.CollisionBody.AddRange(Vertices.CreateSimpleRectangle(sprite.DisplayRect.Width, sprite.DisplayRect.Height));
                        else
                            SelectedAction.CollisionBody.AddRange(Vertices.CreateSimpleRectangle(SelectedAction.CanvasSize.X, SelectedAction.CanvasSize.Y));
                        SelectedAction.CollisionBody.SubDivideEdges(25f);
                        list = new Vertices();
                        vNew = new Vector2();
                        if (sprite != null)
                            foreach (Vector2 v in SelectedAction.CollisionBody)
                            {
                                vNew = v + (new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                                list.Add(vNew);
                            }
                        else
                            foreach (Vector2 v in SelectedAction.CollisionBody)
                            {
                                vNew = v + (new Vector2(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2));
                                list.Add(vNew);
                            }


                        SelectedAction.CollisionBody.Clear();
                        SelectedAction.CollisionBody.AddRange(list);

                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.CollisionBody));
                    }
                    else
                    {
                        if (SelectedAction.CollisionBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.CollisionBody, SelectedAction.CollisionBody));
                        }

                        System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);

                        EGMGame.Dialogs.CollisionParameterConfirmDialog dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                        dialog.Setup((int)originalMouse.X, (int)originalMouse.Y, difference.X, difference.Y);

                        Vector2 tempOM = originalMouse;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            tempOM.X = (float)dialog.nudX.Value;
                            tempOM.Y = (float)dialog.nudy.Value;
                            difference.X = (int)dialog.nudWidth.Value;
                            difference.Y = (int)dialog.nudHeight.Value;


                            SelectedAction.CollisionBody.Clear();
                            SelectedAction.CollisionBody.AddRange(Vertices.CreateSimpleRectangle(Math.Abs(difference.X), Math.Abs(difference.Y)));
                            SelectedAction.CollisionBody.SubDivideEdges(25f);
                            list = new Vertices();
                            vNew = new Vector2();
                            foreach (Vector2 v in SelectedAction.CollisionBody)
                            {
                                vNew = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                                list.Add(vNew);
                            }
                            SelectedAction.CollisionBody.Clear();
                            SelectedAction.CollisionBody.AddRange(list);
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.CollisionBody));
                        }
                    }
                    break;
                case PhysicsType.Circle:
                    if (originalMouse == cMouse)
                    {
                        if (SelectedAction.CollisionBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.CollisionBody, SelectedAction.CollisionBody));
                        }
                        SelectedAction.CollisionBody.Clear();
                        if (sprite != null)
                            SelectedAction.CollisionBody.AddRange(Vertices.CreateEllipse(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2, 16));
                        else
                            SelectedAction.CollisionBody.AddRange(Vertices.CreateEllipse(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2, 16));

                        list = new Vertices();
                        vNew = new Vector2();

                        if (sprite != null)
                            foreach (Vector2 v in SelectedAction.CollisionBody)
                            {
                                vNew = v + (new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                                list.Add(vNew);
                            }
                        else
                            foreach (Vector2 v in SelectedAction.CollisionBody)
                            {
                                vNew = v + (new Vector2(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2));
                                list.Add(vNew);
                            }

                        SelectedAction.CollisionBody.Clear();
                        SelectedAction.CollisionBody.AddRange(list);
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.CollisionBody));
                    }
                    else
                    {
                        if (SelectedAction.CollisionBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.CollisionBody, SelectedAction.CollisionBody));
                        }
                        System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);

                        EGMGame.Dialogs.CollisionParameterConfirmDialog dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                        dialog.Setup((int)originalMouse.X, (int)originalMouse.Y, difference.X, difference.Y);

                        Vector2 tempOM = originalMouse;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            tempOM.X = (float)dialog.nudX.Value;
                            tempOM.Y = (float)dialog.nudy.Value;
                            difference.X = (int)dialog.nudWidth.Value;
                            difference.Y = (int)dialog.nudHeight.Value;



                            SelectedAction.CollisionBody.Clear();
                            SelectedAction.CollisionBody.AddRange(Vertices.CreateEllipse(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2, 16));

                            list = new Vertices();
                            vNew = new Vector2();
                            foreach (Vector2 v in SelectedAction.CollisionBody)
                            {
                                vNew = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                                list.Add(vNew);
                            }
                            SelectedAction.CollisionBody.Clear();
                            SelectedAction.CollisionBody.AddRange(list);
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.CollisionBody));
                        }
                    }
                    break;
                case PhysicsType.Layout:
                    if (sprite != null)
                    {
                        if (SelectedAction.CollisionBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.CollisionBody, SelectedAction.CollisionBody));
                        }
                        //load texture that will represent the physics body
                        Texture2D tex = GetTexture(sprite);

                        //Create an array to hold the data from the texture
                        uint[] data = new uint[sprite.DisplayRect.Width * sprite.DisplayRect.Height];

                        //Transfer the texture data to the array
                        tex.GetData(0, sprite.DisplayRect, data, 0, sprite.DisplayRect.Width * sprite.DisplayRect.Height);

                        //Calculate the vertices from the array
                        Vertices verts = Vertices.CreatePolygon(data, sprite.DisplayRect.Width, sprite.DisplayRect.Height);

                        //Make sure that the origin of the texture is the centroid (real center of geometry)
                        Vector2 origin = verts.GetCentroid();
                        pos = new Vector2(-sprite.DisplayRect.Width / 2, -sprite.DisplayRect.Height / 2);
                        verts.Translate(ref pos);
                        Vertices.Simplify(verts);

                        SelectedAction.CollisionBody.Clear();
                        SelectedAction.CollisionBody.AddRange(verts);


                        list = new Vertices();
                        vNew = new Vector2();
                        foreach (Vector2 v in SelectedAction.CollisionBody)
                        {
                            vNew = v + (new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                            list.Add(vNew);
                        }
                        SelectedAction.CollisionBody.Clear();
                        SelectedAction.CollisionBody.AddRange(list);
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.CollisionBody));
                    }
                    break;
            }
            addingPhysics = false;
            physicsLbl.Visible = false;
        }

        private void AddHitPhysicsToSprite(AnimationSprite sprite)
        {
            Vector2 pos = new Vector2(originalMouse.X, originalMouse.Y);
            if (sprite != null)
            {
                pos -= sprite.Position;
                pos -= new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2);
            }
            Vector2 offset = new Vector2(-4, -4);
            Vector2 nodePosition = Vector2.Zero;
            if (sprite != null)
            {
                offset.X += sprite.Position.X;
                offset.Y += sprite.Position.Y;
            }
            Vertices list = new Vertices();
            Vector2 vNew = Vector2.Zero;
            Vector2 cMouse = new Vector2();
            cMouse.X = camera.GetTransformedPoint(currentMouse).X;
            cMouse.Y = camera.GetTransformedPoint(currentMouse).Y;
            switch (physicsType)
            {
                case PhysicsType.Node:
                    if (SelectedAction.HitBody.Count > 0)
                    {
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.HitBody, SelectedAction.HitBody));
                    }
                    SelectedAction.HitBody.Clear();
                    if (sprite != null)
                        SelectedAction.HitBody.Add(pos + new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                    else
                        SelectedAction.HitBody.Add(pos + new Vector2(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2));

                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionAddedHist(SelectedAction.HitBody[0], SelectedAction.HitBody, 0));
                    break;
                case PhysicsType.Rect:
                    if (originalMouse == cMouse)
                    {
                        if (SelectedAction.HitBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.HitBody, SelectedAction.HitBody));
                        }
                        SelectedAction.HitBody.Clear();
                        if (sprite != null)
                            SelectedAction.HitBody.AddRange(Vertices.CreateSimpleRectangle(sprite.DisplayRect.Width, sprite.DisplayRect.Height));
                        else
                            SelectedAction.HitBody.AddRange(Vertices.CreateSimpleRectangle(SelectedAction.CanvasSize.X, SelectedAction.CanvasSize.Y));
                        SelectedAction.HitBody.SubDivideEdges(25f);
                        list = new Vertices();
                        vNew = new Vector2();
                        if (sprite != null)
                            foreach (Vector2 v in SelectedAction.HitBody)
                            {
                                vNew = v + (new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                                list.Add(vNew);
                            }
                        else
                            foreach (Vector2 v in SelectedAction.HitBody)
                            {
                                vNew = v + (new Vector2(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2));
                                list.Add(vNew);
                            }


                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(list);

                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.HitBody));
                    }
                    else
                    {
                        if (SelectedAction.HitBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.HitBody, SelectedAction.HitBody));
                        }

                        System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);

                        EGMGame.Dialogs.CollisionParameterConfirmDialog dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                        dialog.Setup((int)originalMouse.X, (int)originalMouse.Y, difference.X, difference.Y);

                        Vector2 tempOM = originalMouse;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            tempOM.X = (float)dialog.nudX.Value;
                            tempOM.Y = (float)dialog.nudy.Value;
                            difference.X = (int)dialog.nudWidth.Value;
                            difference.Y = (int)dialog.nudHeight.Value;
                        }

                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(Vertices.CreateSimpleRectangle(Math.Abs(difference.X), Math.Abs(difference.Y)));
                        SelectedAction.HitBody.SubDivideEdges(25f);
                        list = new Vertices();
                        vNew = new Vector2();
                        foreach (Vector2 v in SelectedAction.HitBody)
                        {
                            vNew = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                            list.Add(vNew);
                        }
                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(list);
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.HitBody));
                    }
                    break;
                case PhysicsType.Circle:
                    if (originalMouse == cMouse)
                    {
                        if (SelectedAction.HitBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.HitBody, SelectedAction.HitBody));
                        }
                        SelectedAction.HitBody.Clear();
                        if (sprite != null)
                            SelectedAction.HitBody.AddRange(Vertices.CreateEllipse(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2, 16));
                        else
                            SelectedAction.HitBody.AddRange(Vertices.CreateEllipse(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2, 16));

                        list = new Vertices();
                        vNew = new Vector2();

                        if (sprite != null)
                            foreach (Vector2 v in SelectedAction.HitBody)
                            {
                                vNew = v + (new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                                list.Add(vNew);
                            }
                        else
                            foreach (Vector2 v in SelectedAction.HitBody)
                            {
                                vNew = v + (new Vector2(SelectedAction.CanvasSize.X / 2, SelectedAction.CanvasSize.Y / 2));
                                list.Add(vNew);
                            }

                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(list);
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.HitBody));
                    }
                    else
                    {
                        if (SelectedAction.HitBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.HitBody, SelectedAction.HitBody));
                        }
                        System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);

                        EGMGame.Dialogs.CollisionParameterConfirmDialog dialog = new EGMGame.Dialogs.CollisionParameterConfirmDialog();
                        dialog.Setup((int)originalMouse.X, (int)originalMouse.Y, difference.X, difference.Y);

                        Vector2 tempOM = originalMouse;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            tempOM.X = (float)dialog.nudX.Value;
                            tempOM.Y = (float)dialog.nudy.Value;
                            difference.X = (int)dialog.nudWidth.Value;
                            difference.Y = (int)dialog.nudHeight.Value;
                        }


                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(Vertices.CreateEllipse(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2, 16));

                        list = new Vertices();
                        vNew = new Vector2();
                        foreach (Vector2 v in SelectedAction.HitBody)
                        {
                            vNew = tempOM + v + (new Vector2(Math.Abs(difference.X) / 2, Math.Abs(difference.Y) / 2));
                            list.Add(vNew);
                        }
                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(list);
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.HitBody));
                    }
                    break;
                case PhysicsType.Layout:
                    if (sprite != null)
                    {
                        if (SelectedAction.HitBody.Count > 0)
                        {
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.HitBody, SelectedAction.HitBody));
                        }
                        //load texture that will represent the physics body
                        Texture2D tex = GetTexture(sprite);

                        //Create an array to hold the data from the texture
                        uint[] data = new uint[sprite.DisplayRect.Width * sprite.DisplayRect.Height];

                        //Transfer the texture data to the array
                        tex.GetData(0, sprite.DisplayRect, data, 0, sprite.DisplayRect.Width * sprite.DisplayRect.Height);

                        //Calculate the vertices from the array
                        Vertices verts = Vertices.CreatePolygon(data, sprite.DisplayRect.Width, sprite.DisplayRect.Height);

                        //Make sure that the origin of the texture is the centroid (real center of geometry)
                        Vector2 origin = verts.GetCentroid();
                        pos = new Vector2(-sprite.DisplayRect.Width / 2, -sprite.DisplayRect.Height / 2);
                        verts.Translate(ref pos);
                        Vertices.Simplify(verts);

                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(verts);


                        list = new Vertices();
                        vNew = new Vector2();
                        foreach (Vector2 v in SelectedAction.HitBody)
                        {
                            vNew = v + (new Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2));
                            list.Add(vNew);
                        }
                        SelectedAction.HitBody.Clear();
                        SelectedAction.HitBody.AddRange(list);
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(list, SelectedAction.HitBody));
                    }
                    break;
            }
            addingPhysics = false;
            physicsLbl.Visible = false;
        }

        private void GetHandle()
        {
            if (SelectedData != null)
            {
                if (mouseHandle == HandleStyle.Move)
                    this.Cursor = Cursors.SizeAll;
                else if (mouseHandle == HandleStyle.TopLeft)
                    this.Cursor = Cursors.SizeNWSE;
                else if (mouseHandle == HandleStyle.TopRight)
                    this.Cursor = Cursors.SizeNESW;
                else if (mouseHandle == HandleStyle.BottomLeft)
                    this.Cursor = Cursors.SizeNESW;
                else if (mouseHandle == HandleStyle.BottomRight)
                    this.Cursor = Cursors.SizeNWSE;
            }
        }

        private void graphicsControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (viewType == AnimationView.Physics || viewType == AnimationView.BattlePhysics)
            {
                if (multiSelect)
                {
                    Vector2 pos = new Vector2();
                    Rectangle rect = new Rectangle(0, 0, 8, 8);
                    Rectangle multiRect = new Rectangle((int)originalMouse.X, (int)originalMouse.Y, (int)camera.GetTransformedPoint(currentMouse).X - (int)originalMouse.X, (int)camera.GetTransformedPoint(currentMouse).Y - (int)originalMouse.Y);

                    if (multiRect.Width < 0)
                    {
                        multiRect.X += multiRect.Width;
                        multiRect.Width = (int)Math.Abs(multiRect.Width);
                    }
                    if (multiRect.Height < 0)
                    {
                        multiRect.Y += multiRect.Height;
                        multiRect.Height = (int)Math.Abs(multiRect.Height);
                    }
                    Vector2 offset = new Vector2();
                    offset.X = -4;
                    offset.Y = -4;
                    if (viewType == AnimationView.Physics)
                    {
                        for (int i = 0; i < SelectedAction.CollisionBody.Count; i++)
                        {
                            pos = SelectedAction.CollisionBody[i] + offset;
                            rect.X = (int)pos.X;
                            rect.Y = (int)pos.Y;
                            if (rect.Intersects(multiRect) && !selectedNodeIndexes.Contains(i))
                            {
                                selectedNodeIndexes.Add(i);
                            }
                        }
                    }
                    else if (viewType == AnimationView.BattlePhysics)
                    {
                        for (int i = 0; i < SelectedAction.HitBody.Count; i++)
                        {
                            pos = SelectedAction.HitBody[i] + offset;
                            rect.X = (int)pos.X;
                            rect.Y = (int)pos.Y;
                            if (rect.Intersects(multiRect) && !selectedHitNodeIndexes.Contains(i))
                            {
                                selectedHitNodeIndexes.Add(i);
                            }
                        }
                    }
                    multiSelect = false;
                }
                else if (addingPhysics)
                {
                    System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                    AnimationSprite sprite = GetSprite(point);
                    if (sprite == null) sprite = Sprite(selectedData);
                    if (viewType == AnimationView.Physics)
                    {
                        AddPhysicsToSprite(sprite);
                        SelectedData = sprite;
                        if (!selectedNodeIndexes.Contains(0))
                        {
                            selectedNodeIndexes.Add(0);
                            selectedNodeIndex = 0;
                        }
                    }
                    else
                    {
                        AddHitPhysicsToSprite(sprite);
                        SelectedData = sprite;
                        if (!selectedHitNodeIndexes.Contains(0))
                        {
                            selectedHitNodeIndexes.Add(0);
                            selectedHitNodeIndex = 0;
                        }
                    }
                    addingNode = false;
                    addingPhysics = false;
                }
                else
                {
                    // Moved
                    if (viewType == AnimationView.Physics)
                    {
                        for (int i = 0; i < originalCollisionBody.Count; i++)
                        {
                            if (i < SelectedAction.CollisionBody.Count && SelectedAction.CollisionBody[i] != originalCollisionBody[i])
                            {
                                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsMovedHist(originalCollisionBody[i], SelectedAction.CollisionBody[i], SelectedAction.CollisionBody, i));
                            }
                        }
                    }
                    else if (viewType == AnimationView.BattlePhysics)
                    {
                        for (int i = 0; i < originalHitBody.Count; i++)
                        {
                            if (i < SelectedAction.HitBody.Count && SelectedAction.HitBody[i] != originalHitBody[i])
                            {
                                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsMovedHist(originalHitBody[i], SelectedAction.HitBody[i], SelectedAction.HitBody, i));
                            }
                        }
                    }
                }
                multiSelect = false;
            }

            if (selectedData != null && selectedData is AnimationSprite)
            {
                float x = (float)(originalMouse.X - mouseOffx);
                float y = (float)(originalMouse.Y - mouseOffy);
                if (mouseHandle == HandleStyle.Move && new Vector2(x, y) != Sprite(selectedData).Position)
                {
                    Vector2 pos = Sprite(selectedData).Position;
                    Sprite(selectedData).Position = new Vector2(x, y);
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist((AnimationSprite)selectedData));
                    Sprite(selectedData).Position = pos;
                }
                else if (mouseHandle == HandleStyle.TopLeft)
                {
                    // Rotate
                    float rot = Sprite(SelectedData).Rotation;
                    Sprite(selectedData).Rotation = originalRotation;
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist((AnimationSprite)selectedData));
                    Sprite(selectedData).Rotation = rot;

                }
                else if (mouseHandle == HandleStyle.BottomRight)
                {
                    // Scale
                    Vector2 scale = Sprite(selectedData).Scale;
                    Sprite(selectedData).Scale = originalScale;
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist((AnimationSprite)selectedData));
                    Sprite(selectedData).Scale = scale;
                }
            }
            else if (SelectedData != null && SelectedData is AnimationAnchor)
            {
                float x = (float)(originalMouse.X - mouseOffx);
                float y = (float)(originalMouse.Y - mouseOffy);
                if (mouseHandle == HandleStyle.Move && new Vector2(x, y) != Anchors(selectedData).Position)
                {
                    Vector2 pos = Anchors(selectedData).Position;
                    Anchors(selectedData).Position = new Vector2(x, y);
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist((AnimationAnchor)selectedData));
                    Anchors(selectedData).Position = pos;
                }
            }
            else if (SelectedData != null && SelectedData is PhysicsPin)
            {
                float x = (float)(originalMouse.X - mouseOffx);
                float y = (float)(originalMouse.Y - mouseOffy);
                if (mouseHandle == HandleStyle.Move && new Vector2(x, y) != Pins(selectedData).Position)
                {
                    Vector2 pos = Pins(selectedData).Position;
                    Pins(selectedData).Position = new Vector2(x, y);
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist((PhysicsPin)selectedData));
                    Pins(selectedData).Position = pos;
                }
            }
            else if (SelectedData != null && SelectedData is AnimationParticle)
            {
                float x = (float)(originalMouse.X - mouseOffx);
                float y = (float)(originalMouse.Y - mouseOffy);
                if (mouseHandle == HandleStyle.Move && new Vector2(x, y) != Particle(selectedData).Position)
                {
                    Vector2 pos = Particle(selectedData).Position;
                    Particle(selectedData).Position = new Vector2(x, y);
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist((AnimationParticle)selectedData));
                    Particle(selectedData).Position = pos;
                }
            }

            mouseState = MouseState.Up;
            mouseHandle = HandleStyle.None;
            if (IsMouseDown)
            {
                originalMouse.X = 0;
                originalMouse.Y = 0;
                currentMouse.X = 0;
                currentMouse.Y = 0;
                originalHitBody.Clear();
                originalCollisionBody.Clear();
                IsMouseDown = false;
            }
            multiSelect = false;
            isMiddleDown = false;
            this.Cursor = Cursors.Arrow;
        }
        private AnimationAnchor Anchors(object selectedData)
        {
            return (AnimationAnchor)selectedData;
        }

        private PhysicsPin Pins(object selectedData)
        {
            return (PhysicsPin)selectedData;
        }

        private AnimationParticle Particle(object selectedData)
        {
            return (AnimationParticle)selectedData;
        }


        private void graphicsControl_MouseMove(object sender, MouseEventArgs e)
        {
            currentMouse = e.Location;
            if (SelectedData != null && mouseState == MouseState.Down && !ctrl1 && viewType != AnimationView.Physics && viewType != AnimationView.BattlePhysics)
            {
                System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                if (mouseHandle == HandleStyle.Move)
                {
                    MoveSelected(point);
                }
                else if (mouseHandle == HandleStyle.TopLeft)
                {
                    float x = mousePos.X - point.X + originalRotation;
                    if (x <= 360 && x >= 0)
                        Sprite(selectedData).Rotation = x;
                }
                else if (mouseHandle == HandleStyle.BottomRight)
                {
                    Vector2 s = new Vector2((float)(point.X - mousePos.X) / 100 + originalScale.X, (float)(point.Y - mousePos.Y) / 100 + originalScale.Y);
                    if (s.X < 0.25f) s.X = 0.25f;
                    if (s.Y < 0.25f) s.Y = 0.25f;
                    if (s.X > 3.0f) s.X = 3.0f;
                    if (s.Y > 3.0f) s.Y = 3.0f;
                    Sprite(SelectedData).Scale = s;
                }
                Updated(this);
                return;
            }

            if (!addingPhysics && mouseState == MouseState.Down && !ctrl1 && selectedHitNodeIndexes.Count > 0 && viewType == AnimationView.BattlePhysics)
            {
                Vector2 pos;
                Vector2 offset = new Vector2();
                Vector2 finalPos = new Vector2();
                Rectangle rect = new Rectangle(0, 0, 8, 8);
                System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                System.Drawing.PointF last = camera.GetTransformedPoint(lastMousePos);

                Point p = new Point((int)last.X, (int)last.Y);
                Vector2 selNodePos = Vector2.Zero;

                if (selectedHitNodeIndex > -1 && selectedHitNodeIndex < SelectedAction.HitBody.Count)
                    selNodePos = SelectedAction.HitBody[selectedHitNodeIndex];
                else
                    selNodePos = Vector2.Zero;
                for (int nodeIndex = 0; nodeIndex < selectedHitNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedHitNodeIndexes[nodeIndex] < SelectedAction.HitBody.Count)
                    {
                        offset.X = -4;
                        offset.Y = -4;
                        pos = SelectedAction.HitBody[selectedHitNodeIndexes[nodeIndex]] + offset;
                        rect.X = (int)pos.X;
                        rect.Y = (int)pos.Y;
                        if (selectedHitNodeIndex != selectedHitNodeIndexes[nodeIndex])
                        {
                            offset += selNodePos - SelectedAction.HitBody[selectedHitNodeIndexes[nodeIndex]];
                        }
                        //if (rect.Contains(p))
                        //{
                        pos.X = point.X;
                        pos.Y = point.Y;
                        if (!addingNode)
                        {
                            // Move the node
                            if (!snapToH)
                                finalPos.X = pos.X - offset.X;
                            else
                                finalPos.X = SelectedAction.HitBody[selectedHitNodeIndexes[nodeIndex]].X;

                            if (!snapToW)
                                finalPos.Y = pos.Y - offset.Y;
                            else
                                finalPos.Y = SelectedAction.HitBody[selectedHitNodeIndexes[nodeIndex]].Y;
                            SelectedAction.HitBody[selectedHitNodeIndexes[nodeIndex]] = finalPos;

                        }
                        else if (shift)
                        {
                            addingNode = false;
                            // Add and connect to new node
                            offset.X = -4;
                            offset.Y = -4;
                            selectedHitNodeIndexes[nodeIndex]++;
                            selectedHitNodeIndex = selectedHitNodeIndexes[nodeIndex];
                            SelectedAction.HitBody.Insert(selectedHitNodeIndexes[nodeIndex], pos - offset);
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionAddedHist(pos - offset, SelectedAction.HitBody, selectedHitNodeIndexes[nodeIndex]));

                            originalHitBody = new Vertices(SelectedAction.HitBody);
                            break;
                        }
                    }
                }
                lastMousePos = e.Location;
                //}
            }

            if (!addingPhysics && mouseState == MouseState.Down && !ctrl1 && selectedNodeIndexes.Count > 0 && viewType == AnimationView.Physics)
            {
                Vector2 pos;
                Vector2 offset = new Vector2();
                Vector2 finalPos = new Vector2();
                Rectangle rect = new Rectangle(0, 0, 8, 8);
                System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                System.Drawing.PointF last = camera.GetTransformedPoint(lastMousePos);

                Point p = new Point((int)last.X, (int)last.Y);
                Vector2 selNodePos = Vector2.Zero;

                if (selectedNodeIndex > -1 && selectedNodeIndex < SelectedAction.CollisionBody.Count)
                    selNodePos = SelectedAction.CollisionBody[selectedNodeIndex];
                else
                    selNodePos = Vector2.Zero;
                for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedNodeIndexes[nodeIndex] < SelectedAction.CollisionBody.Count)
                    {
                        offset.X = -4;
                        offset.Y = -4;
                        pos = SelectedAction.CollisionBody[selectedNodeIndexes[nodeIndex]] + offset;
                        rect.X = (int)pos.X;
                        rect.Y = (int)pos.Y;
                        if (selectedNodeIndex != selectedNodeIndexes[nodeIndex])
                        {
                            offset += selNodePos - SelectedAction.CollisionBody[selectedNodeIndexes[nodeIndex]];
                        }
                        //if (rect.Contains(p))
                        //{
                        pos.X = point.X;
                        pos.Y = point.Y;
                        if (!addingNode)
                        {
                            // Move the node
                            if (!snapToH)
                                finalPos.X = pos.X - offset.X;
                            else
                                finalPos.X = SelectedAction.CollisionBody[selectedNodeIndexes[nodeIndex]].X;

                            if (!snapToW)
                                finalPos.Y = pos.Y - offset.Y;
                            else
                                finalPos.Y = SelectedAction.CollisionBody[selectedNodeIndexes[nodeIndex]].Y;
                            SelectedAction.CollisionBody[selectedNodeIndexes[nodeIndex]] = finalPos;

                        }
                        else if (shift)
                        {
                            addingNode = false;
                            // Add and connect to new node
                            offset.X = -4;
                            offset.Y = -4;
                            selectedNodeIndexes[nodeIndex]++;
                            selectedNodeIndex = selectedNodeIndexes[nodeIndex];
                            SelectedAction.CollisionBody.Insert(selectedNodeIndexes[nodeIndex], pos - offset);
                            MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionAddedHist(pos - offset, SelectedAction.CollisionBody, selectedNodeIndexes[nodeIndex]));

                            originalCollisionBody = new Vertices(SelectedAction.CollisionBody);
                            break;
                        }
                    }
                }
                lastMousePos = e.Location;
                //}
            }
            #region Move Mouse + Scroll
            // Is mousedown and ctrl is pressed, scroll the map.
            if (IsMouseDown && ctrl1)
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
                //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newHM, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = newHM;

                lastMousePos = e.Location;
                return;
            }
            if (isMiddleDown) { lastMousePos = e.Location; return; }
            this.Cursor = Cursors.Arrow;
            #endregion
        }
        /// <summary>
        /// Open sprite table on double click on sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicsControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            this.Cursor = this.DefaultCursor;

            if (e.Button == MouseButtons.Left && viewType == AnimationView.Sprite)
            {
                System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                mousePos = point;
                if (viewType == AnimationView.Sprite) SelectSprite(e);
                if (viewType == AnimationView.Anchor) SelectedAnchor(e);
                if (viewType == AnimationView.Pin) SelectedPin(e);
                if (viewType == AnimationView.Particle) SelectParticle(e);
                mouseState = MouseState.Down;
                if (SelectedData is AnimationSprite && SelectedData != null)
                {
                    originalScale = Sprite(SelectedData).Scale;
                    originalLocation = Sprite(SelectedData).Position;
                    originalRotation = Sprite(SelectedData).Rotation;

                    MainForm.animationEditor.spriteTblBtn_Click(null, null);
                }
            }
        }
        /// <summary>
        /// Focus when the mouse enters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicsControl_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            //this.Focus();
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
            if (MainForm.Instance.dockPanel.ActiveDocument != this.Parent) return;
            if (e.Control) ctrl2 = true;
            if (e.Shift) shift = true;
            if (e.KeyCode == Keys.A) snapToW = true;
            if (e.KeyCode == Keys.S) snapToH = true;
            if (e.KeyCode == Keys.D) dDown = true;

            if (e.KeyCode == Keys.Left) MoveSelected(Keys.Left);
            if (e.KeyCode == Keys.Right) MoveSelected(Keys.Right);
            if (e.KeyCode == Keys.Up) MoveSelected(Keys.Up);
            if (e.KeyCode == Keys.Down) MoveSelected(Keys.Down);

            if (snapToW && ctrl1 && shift)
                CenterAllSprites();
            else if (snapToW && ctrl1)
                CenterSelectedSprite();

        }

        private void MoveSelected(Keys keys)
        {
            if (SelectedData != null)
            {
                Vector2 v = new Vector2();
                switch (keys)
                {
                    case Keys.Left:
                        v.X -= 1;
                        break;
                    case Keys.Right:
                        v.X += 1;
                        break;
                    case Keys.Up:
                        v.Y -= 1;
                        break;
                    case Keys.Down:
                        v.Y += 1;
                        break;
                }
                if (SelectedData is AnimationSprite) ((AnimationSprite)SelectedData).SetPosition(v);
                if (SelectedData is AnimationAnchor) ((AnimationAnchor)SelectedData).SetPosition(v);
                if (SelectedData is AnimationParticle) ((AnimationParticle)SelectedData).SetPosition(v);
            }
        }
        /// <summary>
        /// Center All Sprites
        /// </summary>
        private void CenterAllSprites()
        {
            Vector2 center;
            foreach (AnimationFrame frame in selectedDirection)
            {
                foreach (AnimationSprite sprite in frame.Sprites)
                {
                    // Get ABS center.
                    center = SelectedAction.CanvasSize / 2;
                    // Get sprite offset
                    center -= (new Vector2(sprite.DisplayRect.Width, sprite.DisplayRect.Height)) / 2;
                    // Apply as position
                    sprite.Position = center;
                }
            }
        }
        /// <summary>
        /// Center selected sprite
        /// </summary>
        private void CenterSelectedSprite()
        {
            if (selectedData is AnimationSprite)
            {
                Vector2 center = SelectedAction.CanvasSize / 2;
                // Get sprite offset
                center -= (new Vector2(Sprite(selectedData).DisplayRect.Width, Sprite(selectedData).DisplayRect.Height)) / 2;
                // Apply as position
                Sprite(selectedData).Position = center;
            }
        }

        internal void graphicsControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) ctrl2 = false;
            if (e.KeyCode == Keys.ShiftKey) shift = false;
            if (e.KeyCode == Keys.A) snapToW = false;
            if (e.KeyCode == Keys.S) snapToH = false;
            if (e.KeyCode == Keys.D) dDown = false;
        }
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
                ////hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newH, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = newH;
            }
            //}
        }
        #endregion

        #region Drag and Drop Events
        private void graphicsControl_DragOver(object sender, DragEventArgs e)
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
                        anchorAdd.Visible = anchorViewBtn.Checked = false;
                        physicsAdd.Visible = false;
                        subdivideBtn.Visible =
                        simpifyBtn.Visible = false;
                        physicsBtn.Checked = false;
                        anchorViewBtn.Visible = true;
                        physicsLbl.Visible = false;
                        addingPhysics = false;
                        viewType = AnimationView.Sprite;
                        if (!shift)
                        {
                            if (frame != null)
                            {
                                AnimationSprite data = AddSprite();
                                SetupView();
                                data.MaterialId = m.ID;
                                data.AspectToTexture();
                                System.Drawing.Point p = graphicsControl.PointToClient(new System.Drawing.Point(e.X, e.Y));
                                System.Drawing.PointF c = camera.GetTransformedPoint(p);
                                data.Position = new Microsoft.Xna.Framework.Vector2(c.X, c.Y);
                                SelectedData = data;
                            }
                        }
                        else
                        {
                            // Swap
                            System.Drawing.Point p = graphicsControl.PointToClient(new System.Drawing.Point(e.X, e.Y));
                            System.Drawing.PointF point = camera.GetTransformedPoint(p);
                            AnimationSprite data = GetSprite(point);
                            if (data != null)
                            {
                                data.MaterialId = m.ID;
                                SetupView();
                                SelectedData = data;
                            }
                            else
                            {
                                data = AddSprite();
                                data.MaterialId = m.ID;
                                data.AspectToTexture();
                                data.Position = new Microsoft.Xna.Framework.Vector2(point.X, point.Y);
                                SetupView();
                                SelectedData = data;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x001");
            }
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

        private void pinViewBtn_Click(object sender, EventArgs e)
        {
            anchorViewBtn.Checked = false;
            btnParticle.Checked = false;
            anchorAdd.Visible = pinViewBtn.Checked;
            if (pinViewBtn.Checked)
                viewType = AnimationView.Pin;
            else
                viewType = AnimationView.Sprite;
            SetupView();
        }

        private void btnParticle_Click(object sender, EventArgs e)
        {
            pinViewBtn.Checked = false;
            anchorViewBtn.Checked = false;
            anchorAdd.Visible = btnParticle.Checked;
            if (btnParticle.Checked)
                viewType = AnimationView.Particle;
            else
                viewType = AnimationView.Sprite;
            SetupView();
        }

        private void anchorViewBtn_Click(object sender, EventArgs e)
        {
            pinViewBtn.Checked = false;
            btnParticle.Checked = false;
            deleteBtn.Visible = !anchorViewBtn.Checked;
            if (anchorViewBtn.Checked)
                viewType = AnimationView.Anchor;
            else
                viewType = AnimationView.Sprite;
            SetupView();
        }

        private void anchorAdd_Click(object sender, EventArgs e)
        {
            if (viewType == AnimationView.Anchor)
            {
                AnimationAnchor anchor = new AnimationAnchor();
                anchor.Name = Global.GetName("Anchor", frame.Anchors);
                anchor.Position = SelectedAction.CanvasSize / 2;
                anchor.ID = Global.GetID(frame.Anchors);
                frame.Anchors.Add(anchor);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(anchor, new DataAddDelegate(MainForm.animationEditor.DataAnchorAdded), new DataRemoveDelegate(MainForm.animationEditor.DataAnchorRemoved), frame.Anchors, frame.Anchors.IndexOf(anchor)));
                SetupView();
                SelectedData = anchor;
            }
            else if (viewType == AnimationView.Pin)
            {
                PhysicsPin pin = new PhysicsPin();
                pin.Name = Global.GetName("Pin", SelectedAction.Pins);
                pin.Position = SelectedAction.CanvasSize / 2;
                pin.ID = Global.GetID(SelectedAction.Pins);
                SelectedAction.Pins.Add(pin);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(pin, new DataAddDelegate(MainForm.animationEditor.DataPinAdded), new DataRemoveDelegate(MainForm.animationEditor.DataPinRemoved), SelectedAction.Pins, SelectedAction.Pins.IndexOf(pin)));
                SetupView();
                SelectedData = pin;
            }
            else if (viewType == AnimationView.Particle)
            {
                AnimationParticle pin = new AnimationParticle();
                pin.Name = Global.GetName("Particle", SelectedAction.Particles[SelectedAction.Directions.IndexOf(SelectedDirection)]);
                pin.Position = SelectedAction.CanvasSize / 2;
                pin.ID = Global.GetID(SelectedAction.Particles[SelectedAction.Directions.IndexOf(SelectedDirection)]);
                SelectedAction.Particles[SelectedAction.Directions.IndexOf(SelectedDirection)].Add(pin);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(pin, new DataAddDelegate(MainForm.animationEditor.DataParticleAdded), new DataRemoveDelegate(MainForm.animationEditor.DataParticleRemoved), SelectedAction.Particles[SelectedAction.Directions.IndexOf(SelectedDirection)], SelectedAction.Particles[SelectedAction.Directions.IndexOf(SelectedDirection)].IndexOf(pin)));
                SetupView();
                SelectedData = pin;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedData != null && SelectedData is AnimationSprite && viewType == AnimationView.Sprite)
            {
                DeleteSprite(SelectedData);
                SetupView();
                selData.SelectedIndex = selData.Items.Count - 1;
            }
            else if (viewType == AnimationView.Physics)
            {
                for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedNodeIndexes[nodeIndex] < SelectedAction.CollisionBody.Count)
                    {
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionRemovedHist(SelectedAction.CollisionBody[selectedNodeIndexes[nodeIndex]], SelectedAction.CollisionBody, selectedNodeIndexes[nodeIndex]));
                        SelectedAction.CollisionBody.RemoveAt(selectedNodeIndexes[nodeIndex]);
                        originalCollisionBody = new Vertices(SelectedAction.CollisionBody);
                    }
                }
            }
            else if (viewType == AnimationView.BattlePhysics)
            {
                for (int nodeIndex = 0; nodeIndex < selectedHitNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedHitNodeIndexes[nodeIndex] < SelectedAction.HitBody.Count)
                    {
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionRemovedHist(SelectedAction.HitBody[selectedHitNodeIndexes[nodeIndex]], SelectedAction.HitBody, selectedHitNodeIndexes[nodeIndex]));
                        SelectedAction.HitBody.RemoveAt(selectedHitNodeIndexes[nodeIndex]);
                        originalHitBody = new Vertices(SelectedAction.HitBody);
                    }
                }
            }
            else if (SelectedData != null && SelectedData is AnimationAnchor)
            {
                DeleteAnchor(SelectedData);
                SetupView();
                selData.SelectedIndex = selData.Items.Count - 1;
            }
            else if (SelectedData != null && SelectedData is PhysicsPin)
            {
                DeletePin(SelectedData);
                SetupView();
                selData.SelectedIndex = selData.Items.Count - 1;
            }
            else if (SelectedData != null && SelectedData is AnimationParticle)
            {
                DeleteParticle((AnimationParticle)SelectedData);
                SetupView();
                selData.SelectedIndex = selData.Items.Count - 1;
            }
        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewType == AnimationView.Sprite)
            {
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedFrame, new DataPropertyDelegate(MainForm.animationEditor.DataFrameChanged)));

                SelectedFrame.Sprites.Clear();
                SetupView();
            }
            else if (viewType == AnimationView.Physics)
            {
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(MainForm.animationEditor.DataFrameChanged)));

                SelectedAction.CollisionBody.Clear();

            }
            else if (viewType == AnimationView.BattlePhysics)
            {
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(MainForm.animationEditor.DataFrameChanged)));

                SelectedAction.HitBody.Clear();

            }
            else if (viewType == AnimationView.Anchor)
            {
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedFrame, new DataPropertyDelegate(MainForm.animationEditor.DataFrameChanged)));

                SelectedFrame.Anchors.Clear();
                SetupView();
            }
            else if (viewType == AnimationView.Pin)
            {
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(MainForm.animationEditor.DataFrameChanged)));

                SelectedAction.Pins.Clear();
                SetupView();
            }
            else if (viewType == AnimationView.Particle)
            {
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(MainForm.animationEditor.DataFrameChanged)));

                SelectedAction.Particles[SelectedAction.Directions.IndexOf(selectedDirection)].Clear();
                SetupView();
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
            p.X = hScrollBar.Value + (camera.ScreenPosition.X / zoomLevel);
            camera.Position = p;
            graphicsControl.Invalidate();
        }
        #endregion

        #region Methods
        private void SetupView()
        {
            SelectedData = null;
            selData.Visible = true;
            selData.Items.Clear();
            if (SelectedFrame == null) return;
            if (viewType == AnimationView.Sprite)
            {
                foreach (AnimationSprite data in SelectedFrame.Sprites)
                    selData.Items.Add(data.Name);
                deleteBtn.Visible = true;
            }
            else if (viewType == AnimationView.Anchor)
            {
                for (int i = 0; i < SelectedFrame.Anchors.Count; i++)
                {
                    selData.Items.Add(SelectedFrame.Anchors[i].Name + " " + (i + 1).ToString());
                }
                anchorAdd.Visible = false;
                deleteBtn.Visible = false;
            }
            else if (viewType == AnimationView.Pin)
            {
                foreach (PhysicsPin data in SelectedAction.Pins)
                    selData.Items.Add(data.Name);
                deleteBtn.Visible = true;
            }
            else if (viewType == AnimationView.Particle)
            {
                foreach (AnimationParticle data in SelectedAction.Particles[SelectedAction.Directions.IndexOf(selectedDirection)])
                    selData.Items.Add(data.Name);
                deleteBtn.Visible = true;

            }
            selData.SelectedIndex = (selData.Items.Count > 0 ? 0 : -1);
        }

        private void SelectSprite(MouseEventArgs e)
        {
            if (SelectedFrame == null) return;
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);

            if (SelectedData != null && SelectedData is AnimationSprite)
            {
                AnimationSprite selSprite = Sprite(SelectedData);
                if (selSprite.GetTopLeft().Contains(point))
                {
                    SelectedData = selSprite;
                    selSprite.SetOffSet(out mouseOffx, out mouseOffy, point);
                    SetSprite(selSprite);
                    mouseHandle = HandleStyle.TopLeft;
                    MainForm.animationEditor.SelectSprite();
                    return;
                }
                if (selSprite.GetBottomRight().Contains(point))
                {
                    SelectedData = selSprite;
                    selSprite.SetOffSet(out mouseOffx, out mouseOffy, point);
                    SetSprite(selSprite);
                    mouseHandle = HandleStyle.BottomRight;
                    MainForm.animationEditor.SelectSprite();
                    return;
                }
                if (selSprite.GetTransRectangle().Contains(point))
                {
                    SelectedData = selSprite;
                    selSprite.SetOffSet(out mouseOffx, out mouseOffy, point);
                    SetSprite(selSprite);
                    mouseHandle = HandleStyle.Move;
                    MainForm.animationEditor.SelectSprite();
                    return;
                }
            }
            AnimationSprite sprite;
            for (int i = SelectedFrame.Sprites.Count - 1; i > -1; i--)
            {
                sprite = SelectedFrame.Sprites[i];
                if (sprite.GetTopLeft().Contains(point))
                {
                    SelectedData = sprite;
                    sprite.SetOffSet(out mouseOffx, out mouseOffy, point);
                    SetSprite(sprite);
                    mouseHandle = HandleStyle.TopLeft;
                    MainForm.animationEditor.SelectSprite();
                    return;
                }
                if (sprite.GetBottomRight().Contains(point))
                {
                    SelectedData = sprite;
                    sprite.SetOffSet(out mouseOffx, out mouseOffy, point);
                    SetSprite(sprite);
                    mouseHandle = HandleStyle.BottomRight;
                    MainForm.animationEditor.SelectSprite();
                    return;
                }
                if (sprite.GetTransRectangle().Contains(point))
                {
                    SelectedData = sprite;
                    sprite.SetOffSet(out mouseOffx, out mouseOffy, point);
                    SetSprite(sprite);
                    mouseHandle = HandleStyle.Move;
                    MainForm.animationEditor.SelectSprite();
                    return;
                }
            }
        }
        /// <summary>
        /// Selects and returns a sprite
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private AnimationSprite GetSprite(System.Drawing.PointF point)
        {
            try
            {

                if (SelectedFrame == null) return null;
                AnimationSprite sprite;
                for (int i = SelectedFrame.Sprites.Count - 1; i > -1; i--)
                {
                    sprite = SelectedFrame.Sprites[i];
                    if (sprite.GetTransRectangle().Contains(point))
                    {
                        SelectedData = sprite;
                        sprite.SetOffSet(out mouseOffx, out mouseOffy, point);
                        SetSprite(sprite);
                        mouseHandle = HandleStyle.Move;
                        return sprite;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x002");
            }
            return null;
        }
        private void SelectedAnchor(MouseEventArgs e)
        {
            if (SelectedFrame == null) return;
            System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);

            if (((AnimationAnchor)SelectedData).GetRectangle().Contains(point))
            {
                ((AnimationAnchor)SelectedData).SetOffSet(out mouseOffx, out mouseOffy, point);
                mouseHandle = HandleStyle.Move;
                return;
            }
            foreach (AnimationAnchor anchor in SelectedFrame.Anchors)
            {
                if (anchor.GetRectangle().Contains(point))
                {
                    SelectedData = anchor;
                    SelectedItemEventArgs ex = new SelectedItemEventArgs(null);
                    SelectedItemChange(this, ex);
                    anchor.SetOffSet(out mouseOffx, out mouseOffy, point);
                    mouseHandle = HandleStyle.Move;
                    return;
                }
            }
        }

        private void SetSprite(AnimationSprite sprite)
        {
            SelectedItemEventArgs e = new SelectedItemEventArgs(sprite);
            SelectedItemChange(this, e);
        }

        private AnimationSprite AddSprite()
        {
            if (frame != null)
            {
                AnimationSprite sprite = new AnimationSprite();
                sprite.Name = Global.GetName("Sprite", frame.Sprites);
                sprite.ID = Global.GetID(frame.Sprites);
                frame.Sprites.Add(sprite);

                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(sprite, new DataAddDelegate(MainForm.animationEditor.DataSpriteAdded), new DataRemoveDelegate(MainForm.animationEditor.DataSpriteRemoved), frame.Sprites, frame.Sprites.IndexOf(sprite)));

                ItemAddedEventArgs ev = new ItemAddedEventArgs(sprite);
                ItemAdded(this, ev);
                if (viewType == AnimationView.Sprite)
                {
                    int selDataIndex = selData.SelectedIndex;
                    selData.Items.Clear();
                    foreach (AnimationSprite d in SelectedFrame.Sprites)
                        selData.Items.Add(d.Name);
                    deleteBtn.Visible = true;
                    if (selDataIndex > -1 && selDataIndex < selData.Items.Count)
                        selData.SelectedIndex = selDataIndex;
                }
                return sprite;
            }
            return null;
        }

        private void DeleteAnchor(object data)
        {
            frame.Anchors.Remove((AnimationAnchor)data);
            if (SelectedData == data) SelectedData = null;
        }

        private void DeletePin(object data)
        {
            SelectedAction.Pins.Remove((PhysicsPin)data);
            if (SelectedData == data) SelectedData = null;
        }

        private void DeleteParticle(AnimationParticle data)
        {
            SelectedAction.Particles[SelectedAction.Directions.IndexOf(selectedDirection)].Remove(data);
            if (SelectedData == data) SelectedData = null;
        }


        private void DeleteSprite(object data)
        {
            frame.Sprites.Remove((AnimationSprite)data);
            if (SelectedData == data) SelectedData = null;
            ItemRemovedEventArgs e = new ItemRemovedEventArgs(data);
            ItemRemoved(this, e);

            if (viewType == AnimationView.Sprite)
            {
                int selDataIndex = selData.SelectedIndex;
                selData.Items.Clear();
                foreach (AnimationSprite d in SelectedFrame.Sprites)
                    selData.Items.Add(d.Name);
                deleteBtn.Visible = true;
                if (selDataIndex > -1 && selDataIndex < selData.Items.Count)
                    selData.SelectedIndex = selDataIndex;
            }
        }

        /// <summary>
        /// Move Selected
        /// </summary>
        /// <param name="p"></param>
        private void MoveSelected(System.Drawing.PointF p)
        {
            if (SelectedData is AnimationSprite)
            {
                AnimationSprite sprite = (AnimationSprite)SelectedData;

                if (!dDown)
                {
                    sprite.Position = new Vector2((float)(p.X - mouseOffx), (float)(p.Y - mouseOffy));
                }
                else
                {
                    int frameIndex;
                    int distance = 9999999;
                    int tempDistance = 0;
                    Vector2 position = Vector2.Zero;
                    for (int i = 0; i < SelectedAction.Directions.Count; i++)
                    {
                        if (SelectedAction.Directions[i].Contains(SelectedFrame))
                        {
                            frameIndex = SelectedAction.Directions[i].IndexOf(SelectedFrame);
                            if (frameIndex > 0)
                            {
                                foreach (AnimationSprite lastSprite in SelectedAction.Directions[i][frameIndex - 1].Sprites)
                                {
                                    tempDistance = ExMath.GetDistance(lastSprite.Position, sprite.Position);
                                    if (tempDistance < distance)
                                    {
                                        distance = tempDistance;
                                        position = lastSprite.Position;
                                    }
                                }
                                if (distance < 9999999)
                                {
                                    sprite.Position = position;
                                    break;
                                }
                                else
                                {
                                    sprite.Position = new Vector2((float)(p.X - mouseOffx), (float)(p.Y - mouseOffy));
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                sprite.Position = new Vector2((float)(p.X - mouseOffx), (float)(p.Y - mouseOffy));
                                break;
                            }
                        }
                    }
                }
            }
            else if (SelectedData is AnimationAnchor)
            {
                AnimationAnchor ancor = (AnimationAnchor)SelectedData;
                int ind = SelectedFrame.Anchors.IndexOf(ancor);
                if (!shift)
                    ancor.Position = new Vector2((float)(p.X - mouseOffx), (float)(p.Y - mouseOffy));
                else
                {
                    for (int i = 0; i < selectedDirection.Count; i++)
                    {
                        selectedDirection[i].Anchors[ind].Position = new Vector2((float)(p.X - mouseOffx), (float)(p.Y - mouseOffy));
                    }
                }
            }
            else if (SelectedData is PhysicsPin)
            {
                PhysicsPin pin = (PhysicsPin)SelectedData;

                pin.Position = new Vector2((float)(p.X - mouseOffx), (float)(p.Y - mouseOffy));
            }
            else if (SelectedData is AnimationParticle)
            {
                AnimationParticle pin = (AnimationParticle)SelectedData;

                pin.Position = new Vector2((float)(p.X - mouseOffx), (float)(p.Y - mouseOffy));
            }

        }
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
                vScrollBar.LargeChange = 8;
                vScrollBar.SmallChange = 1;
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
                hScrollBar.Maximum = (int)(camera.ViewingWidth - camera.Viewport.Width / zoomLevel);
                hScrollBar.Value = hScrollBar.Minimum;
                hScrollBar.Enabled = true;
                hScrollBar.LargeChange = 8;
                hScrollBar.SmallChange = 1;
                ////hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeIncrement, 0, Math.Min(oldScrollX, hScrollBar.Maximum), ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = Math.Min(oldScrollX, hScrollBar.Maximum);
                oldScrollX = hScrollBar.Value;
            }
            else
            {
                hScrollBar.Enabled = false;
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
            anchorTexture = Loader.TextureFromStream(graphicsControl.GraphicsDevice, global::EGMGame.Properties.Resources.anchor_circle, System.Drawing.Imaging.ImageFormat.Png);
            particleTexture = Loader.TextureFromStream(graphicsControl.GraphicsDevice, global::EGMGame.Properties.Resources.fire1, System.Drawing.Imaging.ImageFormat.Png);
            // Scroll Reset
            hScrollBar.Minimum = 0;
            vScrollBar.Minimum = 0;

            Global.LoadFont(contentManager);

            // Start the animation timer.  
            timer = Stopwatch.StartNew();

            TimeLast = timer.ElapsedMilliseconds;
            TimeElapsed = 0;
            nCount = 0;
        }
        /// <summary>
        /// On Draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicsControl_OnDraw(object sender, EventArgs e)
        {
            bgScroller_DoWork(null, null);
            if (contentManager.RootDirectory != MaterialExplorer.contentBuilder.OutputDirectory)
            {
                contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            }
            try
            {
                if (playerTimer > 0)
                    playerTimer--;
                bool updateCamera = false;
                // Calculate FPS
                if (timer.IsRunning)
                {
                    nCount++;
                    TimeNow = timer.ElapsedMilliseconds;
                    long TimeDelta = TimeNow - TimeLast;

                    TimeElapsed += TimeDelta;
                    uCount += TimeDelta;

                    TimeLast = TimeNow;
                    if (uCount >= 17)
                    {
                        uCount = 0;
                        UpdateAnimation();
                        // Update Camera
                        updateCamera = true;
                    }

                    if (TimeElapsed >= 1000)
                    {
                        FPS = ((float)nCount / (TimeElapsed / 1000));
                        nCount = 0;
                        TimeElapsed = 0;
                        uCount = 0;
                    }
                }
                fpsLbl.Text = FPS.ToString();
                // Clear device and draw inactive area
                Global.ClearDevice(graphicsDevice, Microsoft.Xna.Framework.Color.DarkGray);
                if (frame != null)
                {
                    // Camera
                    if (SelectedAction.CanvasSize.X != camera.ViewingWidth)
                    {
                        camera.ViewingWidth = SelectedAction.CanvasSize.X;
                        UpdateScrollbarsW();
                    }
                    if (SelectedAction.CanvasSize.Y != camera.ViewingHeight)
                    {
                        camera.ViewingHeight = SelectedAction.CanvasSize.Y;
                        UpdateScrollbarsH();
                    }
                    // Matrix
                    Matrix m = camera.ViewTransformationMatrix();
                    try
                    {
                        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);

                        lblGuide.Width = (int)SelectedAction.CanvasSize.X;
                        lblGuide.Height = (int)SelectedAction.CanvasSize.Y;
                        DrawCanvas();
                        if (viewType == AnimationView.Sprite) DrawPreviousFrame();
                        if (DrawFrame == null)
                        {
                            DrawSprites();
                            DrawAnchors();
                        }
                        else
                        {
                            DrawSprites2();
                            DrawAnchors2();
                        }
                        DrawPins();
                        DrawParticles();

                        if (viewType == AnimationView.Physics) DrawPhysics();
                        if (viewType == AnimationView.BattlePhysics) DrawBattlePhysics();

                        if (multiSelect)
                        {
                            Vector2 op = originalMouse;
                            System.Drawing.PointF cp = camera.GetTransformedPoint(currentMouse);
                            FillRectangle(new System.Drawing.RectangleF(op.X, op.Y, cp.X - op.X, cp.Y - op.Y), Color.White, new Color(0, 0, 255, 100), 1);
                        }
                        #region Move/Scroll
                        if (isMiddleDown)
                        {
                            // Draw 4 dir
                            Texture2D dir = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.fourDCursor, ImageFormat.Png);
                            Vector2 point = camera.GetTransformedPoint(new Vector2(mousePoint.X, mousePoint.Y));
                            spriteBatch.Draw(dir, new Rectangle((int)point.X, (int)point.Y, 22, 22), Color.Black);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex, "s3x001");
                    }
                    finally
                    {
                        spriteBatch.End();
                    }
                    if (updateCamera)
                    {
                        if (SelectedAction != null)
                        {
                            camera.Update(spriteBatch, pixelTexture, SelectedAction.CanvasSize);
                        }
                        updateCamera = false;
                    }
                }

                lblGuide.Visible = (SelectedFrame == null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x003");
            }
        }
        /// <summary>
        /// Draw Physics
        /// </summary>
        private void DrawPhysics()
        {
            int verticeCount;
            Vector2 offset;
            Color lineColor;
            Color nodeColor;
            verticeCount = SelectedAction.CollisionBody.Count;
            for (int i = 0; i < SelectedAction.CollisionBody.Count; i++)
            {
                lineColor = Color.Yellow;
                nodeColor = Color.Yellow;
                for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedNodeIndexes[nodeIndex] == i)
                    {
                        nodeColor = Color.Green;
                        break;
                    }
                }
                if (SelectedAction.CollisionBody[SelectedAction.CollisionBody.NextIndex(i)].Y == SelectedAction.CollisionBody[i].Y)
                    lineColor = Color.Red;
                if (SelectedAction.CollisionBody[SelectedAction.CollisionBody.NextIndex(i)].X == SelectedAction.CollisionBody[i].X)
                    lineColor = Color.Red;

                if (i < verticeCount - 1)
                {
                    DrawLine(SelectedAction.CollisionBody[i + 1], SelectedAction.CollisionBody[i], lineColor, 1, 0);
                }
                else
                {
                    DrawLine(SelectedAction.CollisionBody[i], SelectedAction.CollisionBody[0], lineColor, 1, 0);

                }
                offset.X = 2 - 4;
                offset.Y = -4;
                spriteBatch.Draw(
                                  anchorTexture,
                                  SelectedAction.CollisionBody[i] + offset,
                                  nodeColor);
            }

            for (int nodeIndex = 0; nodeIndex < selectedNodeIndexes.Count; nodeIndex++)
            {
                if (selectedNodeIndexes[nodeIndex] < SelectedAction.CollisionBody.Count)
                {
                    offset.X = -2f;
                    offset.Y = -4.5f;
                    offset = SelectedAction.CollisionBody[selectedNodeIndexes[nodeIndex]] + offset;
                    DrawRectangle(new System.Drawing.RectangleF(offset.X, offset.Y, 9, 9), Color.Blue, 1);
                }
            }

            if (addingPhysics && mouseState == MouseState.Down)
            {
                Vector2 cMouse = new Vector2();
                cMouse.X = camera.GetTransformedPoint(currentMouse).X;
                cMouse.Y = camera.GetTransformedPoint(currentMouse).Y;
                switch (physicsType)
                {
                    case PhysicsType.Rect:
                        if (originalMouse != cMouse)
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);

                            Rectangle rect = new Rectangle((int)originalMouse.X, (int)originalMouse.Y, difference.X, difference.Y);

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
                            originalMouse.X = rect.X;
                            originalMouse.Y = rect.Y;

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
                                    DrawLine(originalMouse + draw[i + 1], originalMouse + draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(originalMouse + draw[i], originalMouse + draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                spriteBatch.Draw(
                                                  anchorTexture,
                                                  originalMouse + draw[i] + offset,
                                                  Color.Pink);
                            }
                        }
                        break;
                    case PhysicsType.Circle:
                        if (originalMouse != cMouse)
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);
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
                                    DrawLine(originalMouse + draw[i + 1], originalMouse + draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(originalMouse + draw[i], originalMouse + draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                spriteBatch.Draw(
                                                  anchorTexture,
                                                  originalMouse + draw[i] + offset,
                                                  Color.Pink);
                            }
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Draw Physics
        /// </summary>
        private void DrawBattlePhysics()
        {
            int verticeCount;
            Vector2 offset;
            Color lineColor;
            Color nodeColor;
            verticeCount = SelectedAction.HitBody.Count;
            for (int i = 0; i < SelectedAction.HitBody.Count; i++)
            {
                lineColor = Color.Red;
                nodeColor = Color.Red;
                for (int nodeIndex = 0; nodeIndex < selectedHitNodeIndexes.Count; nodeIndex++)
                {
                    if (selectedHitNodeIndexes[nodeIndex] == i)
                    {
                        nodeColor = Color.Green;
                        break;
                    }
                }
                if (SelectedAction.HitBody[SelectedAction.HitBody.NextIndex(i)].Y == SelectedAction.HitBody[i].Y)
                    lineColor = Color.Yellow;
                if (SelectedAction.HitBody[SelectedAction.HitBody.NextIndex(i)].X == SelectedAction.HitBody[i].X)
                    lineColor = Color.Yellow;

                if (i < verticeCount - 1)
                {
                    DrawLine(SelectedAction.HitBody[i + 1], SelectedAction.HitBody[i], lineColor, 1, 0);
                }
                else
                {
                    DrawLine(SelectedAction.HitBody[i], SelectedAction.HitBody[0], lineColor, 1, 0);

                }
                offset.X = 2 - 4;
                offset.Y = -4;
                spriteBatch.Draw(
                                  anchorTexture,
                                  SelectedAction.HitBody[i] + offset,
                                  nodeColor);
            }

            for (int nodeIndex = 0; nodeIndex < selectedHitNodeIndexes.Count; nodeIndex++)
            {
                if (selectedHitNodeIndexes[nodeIndex] < SelectedAction.HitBody.Count)
                {
                    offset.X = -2f;
                    offset.Y = -4.5f;
                    offset = SelectedAction.HitBody[selectedHitNodeIndexes[nodeIndex]] + offset;
                    DrawRectangle(new System.Drawing.RectangleF(offset.X, offset.Y, 9, 9), Color.Blue, 1);
                }
            }

            if (addingPhysics && mouseState == MouseState.Down)
            {
                Vector2 cMouse = new Vector2();
                cMouse.X = camera.GetTransformedPoint(currentMouse).X;
                cMouse.Y = camera.GetTransformedPoint(currentMouse).Y;
                switch (physicsType)
                {
                    case PhysicsType.Rect:
                        if (originalMouse != cMouse)
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);
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
                                    DrawLine(originalMouse + draw[i + 1], originalMouse + draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(originalMouse + draw[i], originalMouse + draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                spriteBatch.Draw(
                                                  anchorTexture,
                                                  originalMouse + draw[i] + offset,
                                                  Color.Pink);
                            }
                        }
                        break;
                    case PhysicsType.Circle:
                        if (originalMouse != cMouse)
                        {
                            System.Drawing.Point difference = new System.Drawing.Point((int)cMouse.X - (int)originalMouse.X, (int)cMouse.Y - (int)originalMouse.Y);
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
                                    DrawLine(originalMouse + draw[i + 1], originalMouse + draw[i], Color.Pink, 1, 0);
                                }
                                else
                                {
                                    DrawLine(originalMouse + draw[i], originalMouse + draw[0], Color.Pink, 1, 0);

                                }
                                offset.X = -4;
                                offset.Y = -4;
                                spriteBatch.Draw(
                                                  anchorTexture,
                                                  originalMouse + draw[i] + offset,
                                                  Color.Pink);
                            }
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Draw Anchors
        /// </summary>
        private void DrawAnchors()
        {
            // Draw Anchors
            for (int i = 0; i < frame.Anchors.Count; i++)
            {
                spriteBatch.Draw(
                    anchorTexture,
                    frame.Anchors[i].Position,
                    Color.LightBlue);

                spriteBatch.DrawString(Global.Font, (i + 1).ToString(), frame.Anchors[i].Position - new Vector2(-1, 2), Color.Black);
            }

            if (SelectedData != null && SelectedData is AnimationAnchor)
                DrawSelectedAnchor((AnimationAnchor)SelectedData);
        }
        /// <summary>
        /// Draw Anchors
        /// </summary>
        private void DrawPins()
        {
            // Draw Pins
            foreach (PhysicsPin anchor in SelectedAction.Pins)
            {
                spriteBatch.Draw(
                    anchorTexture,
                    anchor.Position,
                    Color.Red);
            }

            if (SelectedData != null && SelectedData is PhysicsPin)
                DrawSelectedPin((PhysicsPin)SelectedData);
        }
        /// <summary>
        /// Draw Particles
        /// </summary>
        private void DrawParticles()
        {
            // Draw Pins
            int index = SelectedAction.Directions.IndexOf(SelectedDirection);
            if (index > -1)
            {
                foreach (AnimationParticle anchor in SelectedAction.Particles[index])
                {
                    spriteBatch.Draw(
                        particleTexture,
                        anchor.Position,
                        Color.White);
                }

                if (SelectedData != null && SelectedData is AnimationParticle)
                {
                    // Draw Outer Selection Rectangle
                    System.Drawing.RectangleF selectionRect = ((AnimationParticle)SelectedData).GetRectangle();
                    DrawRectangle(selectionRect, Color.Blue, 0);
                }
            }
        }
        /// <summary>
        ///  Draw Sprites With Selection
        /// </summary>
        private void DrawSprites()
        {
            Texture2D tex;
            foreach (AnimationSprite sprite in SelectedFrame.Sprites)
            {
                tex = GetTexture(sprite);
                if (tex != null)
                {
                    sprite.Size = new Vector2((float)sprite.DisplayRect.Width, (float)sprite.DisplayRect.Height);
                    spriteBatch.Draw(
                        tex,
                        sprite.Position,
                        sprite.DisplayRect,
                        sprite.Tint,
                        DegreesToRadian(sprite.Rotation),
                        sprite.Size / 2 + sprite.OriginOffset,
                        sprite.Scale,
                        GetSpriteEffect(sprite),
                        0
                        );
                }
                // Draw Outer Selection Rectangle
                System.Drawing.RectangleF selectionRect = sprite.GetScaledRectangle(zoomLevel);

                DrawRectangle(selectionRect, Color.White, 0, sprite.Rotation);

                // Draw Origin
                Vector2 pos = new Vector2(selectionRect.X + ((sprite.Size / 2) * sprite.Scale.X).X, selectionRect.Y + ((sprite.Size / 2) * sprite.Scale.Y).Y);
                DrawLine(new Vector2(selectionRect.X, pos.Y), new Vector2(selectionRect.X + selectionRect.Width, pos.Y), Color.White, GetScale(), 1);
                DrawLine(new Vector2(pos.X, selectionRect.Y), new Vector2(pos.X, selectionRect.Y + selectionRect.Height), Color.White, GetScale(), 1);


                // Draw Text       
                DrawText(sprite.ID.ToString(), Color.Black, new Vector2(sprite.GetTopRight().X, sprite.GetTopRight().Y));


            }
            if (SelectedData != null && SelectedData is AnimationSprite && viewType == AnimationView.Sprite)
                DrawSelectedSprite((AnimationSprite)SelectedData);
        }


        #region Draw Frame
        /// <summary>
        /// Draw Anchors
        /// </summary>
        private void DrawAnchors2()
        {
            // Draw Anchors
            for (int i = 0; i < DrawFrame.Anchors.Count; i++)
            {
                spriteBatch.Draw(
                    anchorTexture,
                    DrawFrame.Anchors[i].Position,
                    Color.LightBlue);

                spriteBatch.DrawString(Global.Font, (i + 1).ToString(), DrawFrame.Anchors[i].Position - new Vector2(-1, 2), Color.Black);
            }

            if (SelectedData != null && SelectedData is AnimationAnchor)
                DrawSelectedAnchor((AnimationAnchor)SelectedData);
        }
        /// <summary>
        ///  Draw Sprites With Selection
        /// </summary>
        private void DrawSprites2()
        {
            Texture2D tex;
            foreach (AnimationSprite sprite in DrawFrame.Sprites)
            {
                tex = GetTexture(sprite);
                if (tex != null)
                {
                    sprite.Size = new Vector2((float)sprite.DisplayRect.Width, (float)sprite.DisplayRect.Height);
                    spriteBatch.Draw(
                        tex,
                        sprite.Position,
                        sprite.DisplayRect,
                        sprite.Tint,
                        DegreesToRadian(sprite.Rotation),
                        sprite.Size / 2 + sprite.OriginOffset,
                        sprite.Scale,
                        GetSpriteEffect(sprite),
                        0
                        );
                }
                // Draw Outer Selection Rectangle
                System.Drawing.RectangleF selectionRect = sprite.GetScaledRectangle(zoomLevel);

                DrawRectangle(selectionRect, Color.White, 0, sprite.Rotation);

                // Draw Origin
                Vector2 pos = new Vector2(selectionRect.X + ((sprite.Size / 2) * sprite.Scale.X).X, selectionRect.Y + ((sprite.Size / 2) * sprite.Scale.Y).Y);
                DrawLine(new Vector2(selectionRect.X, pos.Y), new Vector2(selectionRect.X + selectionRect.Width, pos.Y), Color.White, GetScale(), 1);
                DrawLine(new Vector2(pos.X, selectionRect.Y), new Vector2(pos.X, selectionRect.Y + selectionRect.Height), Color.White, GetScale(), 1);


                // Draw Text       
                DrawText(sprite.ID.ToString(), Color.Black, new Vector2(sprite.GetTopRight().X, sprite.GetTopRight().Y));


            }
            if (SelectedData != null && SelectedData is AnimationSprite && viewType == AnimationView.Sprite)
                DrawSelectedSprite((AnimationSprite)SelectedData);
        }
        #endregion
        /// <summary>
        /// Draw Previous Frame
        /// </summary>
        private void DrawPreviousFrame()
        {
            if (pframe != null)
            {
                foreach (AnimationSprite sprite in pframe.Sprites)
                {
                    System.Drawing.RectangleF selectionRect = sprite.GetScaledRectangle(zoomLevel);
                    DrawRectangle(selectionRect, Color.White, 0);
                }
            }
        }
        /// <summary>
        /// Draw Canvas
        /// </summary>
        private void DrawCanvas()
        {
            FillRectangle(new System.Drawing.RectangleF(0, 0, SelectedAction.CanvasSize.X, SelectedAction.CanvasSize.Y), Color.LightGray, Color.Black, 0);
            // Draw Center Lines
            float x = (float)(SelectedAction.CanvasSize.X / 2);
            float y = (float)(SelectedAction.CanvasSize.Y);
            float width = (float)(SelectedAction.CanvasSize.X);
            float height = (float)(SelectedAction.CanvasSize.Y);

            // Horizontal
            DrawLine(new Vector2(0, y), new Vector2(width, y), Color.Green, 1, 0);
            // Vertical
            DrawLine(new Vector2(x, 0), new Vector2(x, height), Color.Green, 1, 0);
        }
        /// <summary>
        /// Draw Selected Anchor
        /// </summary>
        /// <param name="animationAnchor"></param>
        private void DrawSelectedPin(PhysicsPin anchor)
        {
            // Draw Outer Selection Rectangle
            System.Drawing.RectangleF selectionRect = anchor.GetRectangle();
            DrawRectangle(selectionRect, Color.Blue, 0);
        }
        /// <summary>
        /// Draw Selected Anchor
        /// </summary>
        /// <param name="animationAnchor"></param>
        private void DrawSelectedAnchor(AnimationAnchor anchor)
        {
            // Draw Outer Selection Rectangle
            System.Drawing.RectangleF selectionRect = anchor.GetRectangle();
            DrawRectangle(selectionRect, Color.Blue, 0);
        }
        /// <summary>
        /// Draw Selected Sprite
        /// </summary>
        /// <param name="animationSprite"></param>
        private void DrawSelectedSprite(AnimationSprite sprite)
        {
            // Draw Outer Selection Rectangle
            System.Drawing.RectangleF selectionRect = sprite.GetScaledRectangle(zoomLevel);

            DrawRectangle(selectionRect, Color.Blue, 0, sprite.Rotation);

            if (viewType == AnimationView.Sprite)
            {
                // Top Left
                FillRectangle(sprite.GetTopLeft(), Color.Black, Color.Yellow, 0);

                // Bottom Right
                FillRectangle(sprite.GetBottomRight(), Color.Black, Color.Blue, 0);
            }
            // Draw Text
            DrawText(sprite.ID.ToString(), Color.Blue, new Vector2(sprite.GetTopRight().X, sprite.GetTopRight().Y));

        }
        /// <summary>
        /// Draw Sprites without selection
        /// </summary>
        private void DrawSpritesBase()
        {
            foreach (AnimationSprite sprite in SelectedFrame.Sprites)
            {
                spriteBatch.Draw(
                    GetTexture(sprite),
                    sprite.Position,
                    sprite.DisplayRect,
                    Color.White,
                    DegreesToRadian(sprite.Rotation),
                    Vector2.Zero,
                    sprite.Scale,
                    GetSpriteEffect(sprite),
                    0
                    );
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
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y), borderColor, 3, priority);
            // Right Side
            DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, 3, priority);
            // Bottom Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y + rectangle.Height), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), borderColor, 3, priority);
            // Left Side
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X, rectangle.Y + rectangle.Height), borderColor, 3, priority);
        }
        private void DrawRectangle(System.Drawing.RectangleF rectangle, Color borderColor, float priority, float rotation)
        {
            Vector2 center;
            rotation = 0;
            Vector2 p1;
            Vector2 p2;
            // Top Side
            center = new Vector2(rectangle.X, rectangle.Y);
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), rotation);
            DrawLine(p1, p2, borderColor, 3, priority);
            // Right Side
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), rotation);
            DrawLine(p1, p2, borderColor, 3, priority);
            // Bottom Side
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y + rectangle.Height), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), rotation);
            DrawLine(p1, p2, borderColor, 3, priority);
            // Left Side
            p1 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y), rotation);
            p2 = ExMath.rotatePoint(center, new Vector2(rectangle.X, rectangle.Y + rectangle.Height), rotation);
            DrawLine(p1, p2, borderColor, 3, priority);
        }
        /// <summary>
        /// Draw Line
        /// </summary>
        /// <param name="PointA"></param>
        /// <param name="PointB"></param>
        /// <param name="color"></param>
        /// <param name="priority"></param>
        private void DrawLine(Vector2 PointA, Vector2 PointB, Color color, int border, float priority)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            float rotation;

            if (PointA.Y > PointB.Y)
                rotation = -(float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));
            else
                rotation = (float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, GetScale()), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }
        private void DrawLine(Vector2 PointA, Vector2 PointB, Color color, float priority, float rotation)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, GetScale()), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
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

            spriteBatch.Draw(pixelTexture, new Rectangle((int)x, (int)y, (int)width, (int)height), null, fillColor, 0f, Vector2.Zero, 0, priority);

            DrawRectangle(rectangle, borderColor, priority - 0.05f);
        }
        /// <summary>
        /// Get Texture of the sprite.
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private Texture2D GetTexture(AnimationSprite sprite)
        {
            return Loader.Texture2D(contentManager, sprite.MaterialId);
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
        private SpriteEffects GetSpriteEffect(AnimationSprite sprite)
        {
            if (sprite.HorizontalFlip)
                return SpriteEffects.FlipHorizontally;
            else if (sprite.VerticalFlip)
                return SpriteEffects.FlipVertically;
            else
                return SpriteEffects.None;
        }
        /// <summary>
        /// Draw Text from given string, color and positon
        /// </summary>
        /// <param name="p"></param>
        /// <param name="color"></param>
        /// <param name="p_3"></param>
        private void DrawText(string text, Color color, Vector2 pos)
        {
            //Vector2 size = Global.Font.MeasureString(text);
            //FillRectangle(new System.Drawing.RectangleF(pos.X - 4, pos.Y, size.X + 3, 16), Color.Green, Color.White, 1);
            //spriteBatch.DrawString(Global.Font, text, pos, color, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
        #endregion

        #region Helper Methods
        private AnimationSprite Sprite(object data)
        {
            return (AnimationSprite)data;
        }
        #endregion
        /// <summary>
        /// On resize, adjust new settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicsControl_Resize(object sender, EventArgs e)
        {
            if (frame != null && graphicsDevice != null)
            {
                oldScrollX = hScrollBar.Value;
                oldScrollY = vScrollBar.Value;
                Viewport v = graphicsDevice.Viewport;
                v.Height = Math.Max(1, graphicsControl.Height);
                v.Width = Math.Max(1, graphicsControl.Width);
                // graphicsDevice.Viewport = v;
                camera.Viewport = v;
                UpdateScrollbarsW();
                UpdateScrollbarsH();
            }
        }
        /// <summary>
        /// Selected Index Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedFrame == null || !allowChange) return;
            if (viewType == AnimationView.Sprite)
            {
                SelectedData = SelectedFrame.Sprites[selData.SelectedIndex];

            }
            else if (viewType == AnimationView.Anchor)
            {
                SelectedData = SelectedFrame.Anchors[selData.SelectedIndex];
            }
            else if (viewType == AnimationView.Pin)
            {
                SelectedData = SelectedAction.Pins[selData.SelectedIndex];
            }
        }
        /// <summary>
        /// Starts animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        int playerTimer = 0;
        private void playAniBtn_Click(object sender, EventArgs e)
        {
            if (playAniBtn.Checked)
            {
                if (playerTimer <= 0)
                {
                    playAniBtn.Image = Properties.Resources.control_pause;
                    playAnimation = true;
                    animationCounter = 0;
                    if (SelectedDirection.Count > 0)
                    {
                        frame = SelectedDirection[0];
                        MainForm.animationEditor.SelectFrame(0);
                        if (frame != null)
                        {
                            // Play Audio
                            if (frame != null)
                            {
                                if (frame.SoundEffectID > -1 && frame.PlaySE)
                                    Global.PlaySoundEffect(frame.SoundEffectID);
                                if (frame.ShakeScreen)
                                    camera.ShakeScreen(frame.ShakePower, frame.ShakeFrames, frame.ShakeSpeed);
                                if (frame.FlashScreen)
                                    camera.FlashScreen(frame.FlashColor, frame.FlashFrames, frame.FlashFreq);
                            }

                        }
                    }
                    playerTimer = 30;
                }
            }
            else
            {
                playAniBtn.Image = Properties.Resources.control_play;
                playAnimation = false;
                animationCounter = 0;
                // Stop Camera Effects
                camera.Reset();
            }
        }
        /// <summary>
        /// Update Animation
        /// </summary>
        private void UpdateAnimation()
        {
            if (playAnimation && SelectedFrame != null)
            {
                animationCounter++;
                if (animationCounter >= SelectedFrame.TimeElapse)
                {
                    animationCounter = 0;
                    // Next Frame
                    //List<AnimationFrame> frames = SelectedAction.Directions[MainForm.animationEditor.directionsList.SelectedIndex];
                    //int index = frames.IndexOf(SelectedFrame);

                    if (MainForm.animationEditor.frameIndex + 1 < MainForm.animationEditor.SelectedDirection.Count)
                    {
                        MainForm.animationEditor.SelectFrame(MainForm.animationEditor.frameIndex + 1);
                        MainForm.animationEditor.SetOriginalFrame();

                        // Play Audio
                        if (frame != null)
                        {
                            if (frame.SoundEffectID > -1 && frame.PlaySE)
                                Global.PlaySoundEffect(frame.SoundEffectID);
                            if (frame.ShakeScreen)
                                camera.ShakeScreen(frame.ShakePower, frame.ShakeFrames, frame.ShakeSpeed);
                            if (frame.FlashScreen)
                                camera.FlashScreen(frame.FlashColor, frame.FlashFrames, frame.FlashFreq);
                        }
                    }
                    else
                    {
                        if (!SelectedAction.InfiniteLoop)
                        {
                            if (animationLoopCount >= SelectedAction.LoopCount)
                            {
                                ResetAnimation();
                            }
                            else
                            {
                                animationCounter = 0;
                                MainForm.animationEditor.SelectFrame(0);
                                MainForm.animationEditor.SetOriginalFrame();

                                // Play Audio
                                if (frame != null)
                                {
                                    if (frame.SoundEffectID > -1 && frame.PlaySE)
                                        Global.PlaySoundEffect(frame.SoundEffectID);
                                    if (frame.ShakeScreen)
                                        camera.ShakeScreen(frame.ShakePower, frame.ShakeFrames, frame.ShakeSpeed);
                                    if (frame.FlashScreen)
                                        camera.FlashScreen(frame.FlashColor, frame.FlashFrames, frame.FlashFreq);
                                }
                            }
                            animationLoopCount++;
                        }
                        else
                        {
                            animationCounter = 0;
                            MainForm.animationEditor.SelectFrame(0);
                            // Play Audio
                            if (frame != null)
                            {
                                if (frame.SoundEffectID > -1 && frame.PlaySE)
                                    Global.PlaySoundEffect(frame.SoundEffectID);
                                if (frame.ShakeScreen)
                                    camera.ShakeScreen(frame.ShakePower, frame.ShakeFrames, frame.ShakeSpeed);
                                if (frame.FlashScreen)
                                    camera.FlashScreen(frame.FlashColor, frame.FlashFrames, frame.FlashFreq);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Resets the animation.
        /// </summary>
        internal void ResetAnimation()
        {
            playAnimation = false;
            animationCounter = 0;
            playAniBtn.Image = Properties.Resources.control_play;
            playAniBtn.Checked = false;
            animationLoopCount = 0;
        }
        /// <summary>
        /// Checked Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void physicsBtn_CheckedChanged(object sender, EventArgs e)
        {
            ResetAnimation();
            if (physicsBtn.Checked)
            {
                battleBtn.Checked = false;
                anchorAdd.Visible = false;
                physicsAdd.Visible = true;
                btnParticle.Visible = false;
                anchorViewBtn.Visible = false;
                pinViewBtn.Visible = false;
                selData.Visible = false;
                viewType = AnimationView.Physics;
                subdivideBtn.Visible =
                simpifyBtn.Visible = true;
                deleteBtn.Visible = true;
            }
            else
            {
                physicsAdd.Visible = false;
                anchorAdd.Visible = (anchorViewBtn.Checked || pinViewBtn.Checked);
                if (anchorViewBtn.Checked)
                    viewType = AnimationView.Anchor;
                else if (pinViewBtn.Checked)
                    viewType = AnimationView.Pin;
                else if (btnParticle.Checked)
                    viewType = AnimationView.Particle;
                else
                    viewType = AnimationView.Sprite;
                anchorViewBtn.Visible = true;
                pinViewBtn.Visible = true;
                physicsLbl.Visible = false;
                addingPhysics = false;
                subdivideBtn.Visible =
                simpifyBtn.Visible = false;
                selData.Visible = true;
                btnParticle.Visible = true;
                SetupView();
            }
        }
        /// <summary>
        /// Battle Physics Checked Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void battleBtn_CheckedChanged(object sender, EventArgs e)
        {
            ResetAnimation();
            if (battleBtn.Checked)
            {
                physicsBtn.Checked = false;
                anchorAdd.Visible = false;
                physicsAdd.Visible = true;
                anchorViewBtn.Visible = false;
                pinViewBtn.Visible = false;
                selData.Visible = false;
                viewType = AnimationView.BattlePhysics;
                subdivideBtn.Visible =
                simpifyBtn.Visible = true;
                btnParticle.Visible = false;
                deleteBtn.Visible = true;
            }
            else
            {
                physicsAdd.Visible = false;
                btnParticle.Visible = true;
                anchorAdd.Visible = (anchorViewBtn.Checked || pinViewBtn.Checked);
                if (anchorViewBtn.Checked)
                    viewType = AnimationView.Anchor;
                else if (pinViewBtn.Checked)
                    viewType = AnimationView.Pin;
                else if (btnParticle.Checked)
                    viewType = AnimationView.Particle;
                else
                    viewType = AnimationView.Sprite;
                anchorViewBtn.Visible = true;
                pinViewBtn.Visible = true;
                physicsLbl.Visible = false;
                addingPhysics = false;
                subdivideBtn.Visible =
                simpifyBtn.Visible = false;
                selData.Visible = true;
                SetupView();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewType == AnimationView.Physics || viewType == AnimationView.BattlePhysics)
            {
                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Node;
                if (viewType == AnimationView.Physics)
                    selectedNodeIndexes.Clear();
                else
                    selectedHitNodeIndexes.Clear();
            }
        }

        private void addRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewType == AnimationView.Physics || viewType == AnimationView.BattlePhysics)
            {
                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Rect;
                if (viewType == AnimationView.Physics)
                    selectedNodeIndexes.Clear();
                else
                    selectedHitNodeIndexes.Clear();
            }
        }

        private void addCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewType == AnimationView.Physics || viewType == AnimationView.BattlePhysics)
            {
                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Circle;
                if (viewType == AnimationView.Physics)
                    selectedNodeIndexes.Clear();
                else
                    selectedHitNodeIndexes.Clear();
            }
        }

        private void layoutSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewType == AnimationView.Physics || viewType == AnimationView.BattlePhysics)
            {
                physicsLbl.Visible = true;
                addingPhysics = true;
                physicsType = PhysicsType.Layout;
                if (viewType == AnimationView.Physics)
                    selectedNodeIndexes.Clear();
                else
                    selectedHitNodeIndexes.Clear();
            }
        }
        /// <summary>
        /// Subdivide nodes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subdivideBtn_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked && SelectedAction.CollisionBody.Count > 0)
            {
                Vertices list = new Vertices(SelectedAction.CollisionBody);
                SelectedAction.CollisionBody.SubDivideEdges(25f);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsEditedHist(list, SelectedAction.CollisionBody, SelectedAction.CollisionBody));

            }
            else if (battleBtn.Checked && SelectedAction.HitBody.Count > 0)
            {
                Vertices list = new Vertices(SelectedAction.HitBody);
                SelectedAction.HitBody.SubDivideEdges(25f);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsEditedHist(list, SelectedAction.HitBody, SelectedAction.HitBody));
            }
        }
        /// <summary>
        /// Simplify nodes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpifyBtn_Click(object sender, EventArgs e)
        {
            if (physicsBtn.Checked && SelectedAction.CollisionBody.Count > 0)
            {
                Vertices list1 = new Vertices(SelectedAction.CollisionBody);
                Vertices list = Vertices.Simplify(SelectedAction.CollisionBody);
                SelectedAction.CollisionBody.Clear();
                SelectedAction.CollisionBody.AddRange(list);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsEditedHist(list1, SelectedAction.CollisionBody, SelectedAction.CollisionBody));
            }
            else if (battleBtn.Checked && SelectedAction.HitBody.Count > 0)
            {
                Vertices list1 = new Vertices(SelectedAction.HitBody);
                Vertices list = Vertices.Simplify(SelectedAction.HitBody);
                SelectedAction.HitBody.Clear();
                SelectedAction.HitBody.AddRange(list);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsEditedHist(list1, SelectedAction.HitBody, SelectedAction.HitBody));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deleteBtn.Visible && deleteBtn.Enabled)
                deleteBtn_Click(null, null);
        }
        /// <summary>
        /// Generate Frames
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genFramesBtn_Click(object sender, EventArgs e)
        {
            // Show message on xna viewer "Drag and drop sprite to generate frames"
            // Show dialog box for detailed settings
            // Left To Right/Number of rows and columns/
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!physicsBtn.Checked && !battleBtn.Checked && selectedData != null && selectedData is AnimationSprite)
            {
                frame.Sprites.Remove((AnimationSprite)selectedData);
                Global.Copy(selectedData);
                selectedData = null;
                if (viewType == AnimationView.Sprite)
                {
                    int selDataIndex = selData.SelectedIndex;
                    selData.Items.Clear();
                    foreach (AnimationSprite d in SelectedFrame.Sprites)
                        selData.Items.Add(d.Name);
                    deleteBtn.Visible = true;
                    if (selDataIndex > -1 && selDataIndex < selData.Items.Count)
                        selData.SelectedIndex = selDataIndex;
                }
            }
            else if (physicsBtn.Checked && SelectedAction.CollisionBody.Count > 0)
            {
                Vertices collection = new Vertices(SelectedAction.CollisionBody);

                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.CollisionBody, SelectedAction.CollisionBody));

                SelectedAction.CollisionBody.Clear();

                if (collection.Count > 0)
                    Global.Copy(collection);
                originalCollisionBody = new Vertices(SelectedAction.CollisionBody);

            }
            else if (battleBtn.Checked && SelectedAction.HitBody.Count > 0)
            {

                Vertices collection = new Vertices(SelectedAction.HitBody);

                MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsRemovedHist(SelectedAction.HitBody, SelectedAction.HitBody));

                SelectedAction.HitBody.Clear();

                if (collection.Count > 0)
                    Global.Copy(collection);
                originalHitBody = new Vertices(SelectedAction.HitBody);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!physicsBtn.Checked && !battleBtn.Checked && selectedData != null && selectedData is AnimationSprite)
            {
                Global.Copy((AnimationSprite)selectedData);
            }
            else if (physicsBtn.Checked && SelectedAction.CollisionBody.Count > 0)
            {
                Vertices collection = new Vertices(SelectedAction.CollisionBody);

                if (collection.Count > 0)
                    Global.Copy(collection);

            }
            else if (battleBtn.Checked && SelectedAction.HitBody.Count > 0)
            {
                Vertices collection = new Vertices(SelectedAction.HitBody);

                if (collection.Count > 0)
                    Global.Copy(collection);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object data = Global.PasteData();

            if (frame != null && data is AnimationSprite)
            {
                anchorAdd.Visible = anchorViewBtn.Checked = false;
                physicsAdd.Visible = false;
                subdivideBtn.Visible =
                simpifyBtn.Visible = false;
                physicsBtn.Checked = false;
                anchorViewBtn.Visible = true;
                physicsLbl.Visible = false;
                addingPhysics = false;
                AnimationSprite sprite = (AnimationSprite)data;
                // Get new id
                sprite.ID = Global.GetID(frame.Sprites);
                // Add
                frame.Sprites.Add(sprite);
                MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(sprite, new DataAddDelegate(MainForm.animationEditor.DataSpriteAdded), new DataRemoveDelegate(MainForm.animationEditor.DataSpriteRemoved), frame.Sprites, frame.Sprites.IndexOf(sprite)));
                ItemAddedEventArgs ev = new ItemAddedEventArgs(sprite);
                ItemAdded(this, ev);
                if (viewType == AnimationView.Sprite)
                {
                    int selDataIndex = selData.SelectedIndex;
                    selData.Items.Clear();
                    foreach (AnimationSprite d in SelectedFrame.Sprites)
                        selData.Items.Add(d.Name);
                    deleteBtn.Visible = true;
                    if (selDataIndex > -1 && selDataIndex < selData.Items.Count)
                        selData.SelectedIndex = selDataIndex;
                }
            }
            else if (frame != null && data is Vertices)
            {
                Vertices collection = (Vertices)data;
                if (physicsBtn.Checked)
                {
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(collection, SelectedAction.CollisionBody));

                    SelectedAction.CollisionBody.AddRange(collection);

                    originalCollisionBody = new Vertices(SelectedAction.CollisionBody);
                }
                else if (battleBtn.Checked)
                {
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new CollisionsAddedHist(collection, SelectedAction.HitBody));

                    SelectedAction.HitBody.AddRange(collection);

                    originalHitBody = new Vertices(SelectedAction.HitBody);
                }
            }
        }

        private void centerSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CenterSelectedSprite();
        }

        private void centerAllSpritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CenterAllSprites();
        }


        internal void ResetContentManager()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
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

        private void bringForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedData is AnimationSprite)
            {
                SelectedFrame.Sprites.Remove(Sprite(selectedData));
                SelectedFrame.Sprites.Add(Sprite(selectedData));
                if (viewType == AnimationView.Sprite)
                {
                    int selDataIndex = selData.SelectedIndex;
                    selData.Items.Clear();
                    foreach (AnimationSprite d in SelectedFrame.Sprites)
                        selData.Items.Add(d.Name);
                    deleteBtn.Visible = true;
                    if (selDataIndex > -1 && selDataIndex < selData.Items.Count)
                        selData.SelectedIndex = selDataIndex;
                }
            }
        }

        private void sendBackwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedData is AnimationSprite)
            {
                SelectedFrame.Sprites.Remove(Sprite(selectedData));
                SelectedFrame.Sprites.Insert(0, Sprite(selectedData));
                if (viewType == AnimationView.Sprite)
                {
                    int selDataIndex = selData.SelectedIndex;
                    selData.Items.Clear();
                    foreach (AnimationSprite d in SelectedFrame.Sprites)
                        selData.Items.Add(d.Name);
                    deleteBtn.Visible = true;
                    if (selDataIndex > -1 && selDataIndex < selData.Items.Count)
                        selData.SelectedIndex = selDataIndex;
                }
            }
        }

        private void syncSameNumberAnchorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedData != null && selectedData is AnimationAnchor)
            {
                int index = SelectedFrame.Anchors.IndexOf((AnimationAnchor)selectedData);
                foreach (AnimationFrame frame in SelectedDirection)
                {
                    frame.Anchors[index].Position = ((AnimationAnchor)selectedData).Position;
                }
            }
        }

        private KeyMessageFilter m_filter = new KeyMessageFilter();
        private void keyTimer_Tick(object sender, EventArgs e)
        {
            if (m_filter.IsKeyPressed(Keys.Left))
            {
                MoveSelected(Keys.Left);
            }
        }
    }
    [Serializable]
    public class CollisionCollection
    {
        public List<int> Index
        {
            get { return index; }
            set { index = value; }
        }
        List<int> index;

        public Vertices Vectors
        {
            get { return vectors; }
            set { vectors = value; }
        }
        Vertices vectors;

        public CollisionCollection(List<int> i, Vertices v)
        {
            index = new List<int>(i);
            vectors = new Vertices(v);
        }
    }

    public enum AnimationView
    {
        Sprite,
        Anchor,
        Physics,
        BattlePhysics,
        Pin,
        Particle
    }

    public enum MouseState
    {
        Down,
        Up
    }

    public enum Transformation
    {
        Scale,
        Rotate,
        Move,
        Select
    }

    public enum HandleStyle
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Move,
        Top,
        Left,
        Right,
        Bottom,
        Anchor,
        None
    }

    public enum PhysicsType
    {
        Node,
        Rect,
        HalfRect,
        Circle,
        Layout
    }
}
