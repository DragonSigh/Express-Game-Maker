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

namespace EGMGame.Controls
{
    public partial class MenuViewer : UserControl
    {
        #region Private Variables
        // Content variables
        public ContentManager contentManager;
        // Render variables
        GraphicsDevice graphicsDevice;
        // Drawing variables
        SpriteBatch spriteBatch;
        Texture2D pixelTexture;
        Texture2D moveHandle;
        Texture2D iconTexture;
        // Camera
        XNA2dCamera camera;
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

        HandleStyle mouseHandle = HandleStyle.None;

        bool snapToW = false;
        bool snapToH = false;

        public bool ShowBG = false;

        Rectangle selectionRectangle = new Rectangle();

        Texture2D bgTexture;
        #endregion

        #region Properties

        public MenuData SelectedMenu
        {
            get { return selectedMenu; }
            set { selectedMenu = value; Setup(); SelectObject(value); }
        }
        MenuData selectedMenu;

        public IMenuParts SelectedObject
        {
            get { return selectedObject; }
            set { selectedObject = value; SelectObject(value); }
        }
        internal IMenuParts selectedObject;

        public List<IMenuParts> SelectedObjects
        {
            get
            {
                return selectedObjects;
            }
            set
            {
                selectedObjects = value;
                if (value != null)
                    MainForm.menuPropertyExplorer.propertyGrid.SelectedObjects = selectedObjects.ToArray();
                else
                    selectedObjects = new List<IMenuParts>();
            }
        }
        List<IMenuParts> selectedObjects = new List<IMenuParts>();
        List<Vector2> selectedOffsets = new List<Vector2>();
        List<Vector2> selectedOriginalPos = new List<Vector2>();
        List<Vector2> selectedOriginalSize = new List<Vector2>();
        List<IGameData> selectedOriginalParent = new List<IGameData>();
        public bool IsEditable
        {
            get { return isEditable; }
            set { isEditable = value; }
        }
        bool isEditable = true;
        int ItemPadding = 5;
        #endregion

        public MenuViewer()
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
        /// <summary>
        /// Select Object for Property grid
        /// </summary>
        /// <param name="value"></param>
        private void SelectObject(object value)
        {
            MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = value;
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            selectedObject = null;
            if (selectedMenu != null)
            {
                for (int index = 0; index < selectedMenu.MenuParts.Count; index++)
                {
                    if (selectedMenu.MenuParts[index].IsContainer)
                    {
                        CheckForChilds(selectedMenu.MenuParts[index]);
                    }
                }
                if (graphicsDevice != null)
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
        }
        private void CheckForChilds(IMenuParts iMenuParts)
        {
            for (int index = 0; index < iMenuParts.MenuParts.Count; index++)
            {
                if (iMenuParts.MenuParts[index].Parent == null)
                    iMenuParts.MenuParts[index].Parent = iMenuParts;
                if (iMenuParts.MenuParts[index].IsContainer)
                {
                    CheckForChilds(iMenuParts.MenuParts[index]);
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
            //if (ctrl && e.Button == MouseButtons.Left)
            //{
            //    IsMouseDown = true;
            //    this.graphicsControl.Cursor = Cursors.NoMove2D;
            //    return;
            //}
            if (isMiddleDown)
            {
                this.graphicsControl.Cursor = Cursors.NoMove2D;
                return;
            }
            #endregion

            this.graphicsControl.Cursor = this.DefaultCursor;
            if (selectedMenu != null && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (!IsEditable)
                    return;
                foreach (IMenuParts obj in selectedObjects)
                {
                    System.Drawing.RectangleF rectF = new System.Drawing.RectangleF(0, 0, 12, 12);

                    // Top Left
                    rectF.X = obj.Bounds.X - 6;
                    rectF.Y = obj.Bounds.Y - 6;

                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.Move;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();
                        selectedOriginalParent.Clear();
                        selectedOriginalSize.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOriginalSize.Add(obj2.Size);
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                            selectedOriginalParent.Add(obj2.Parent);
                        }
                        return;
                    }
                    // Top Right
                    rectF.Width = 8;
                    rectF.Height = 8;
                    rectF.X = obj.Bounds.X + obj.Bounds.Width - 4;
                    rectF.Y = obj.Bounds.Y + obj.Bounds.Height - 4;
                    // Check if clicking handle.
                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.BottomRight;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();
                        selectedOriginalParent.Clear();
                        selectedOriginalSize.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOriginalSize.Add(obj2.Size);
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                            selectedOriginalParent.Add(obj2.Parent);
                        }
                        return;
                    }
                    // Bottom Left
                    rectF.X = obj.Bounds.X - 4;
                    rectF.Y = obj.Bounds.Y + obj.Bounds.Height - 4;
                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.BottomLeft;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();
                        selectedOriginalParent.Clear();
                        selectedOriginalSize.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOriginalSize.Add(obj2.Size);
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                            selectedOriginalParent.Add(obj2.Parent);
                        }
                        return;
                    }
                    // Top Right
                    rectF.X = obj.Bounds.X + obj.Bounds.Width - 4;
                    rectF.Y = obj.Bounds.Y - 4;
                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.TopRight;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();
                        selectedOriginalParent.Clear();
                        selectedOriginalSize.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOriginalSize.Add(obj2.Size);
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                            selectedOriginalParent.Add(obj2.Parent);
                        }
                        return;
                    }
                    // Top
                    rectF.X = obj.Bounds.X + (obj.Bounds.Width / 2) - 4;
                    rectF.Y = obj.Bounds.Y - 4;
                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.Top;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                        }
                        return;
                    }
                    // Left
                    rectF.X = obj.Bounds.X - 4;
                    rectF.Y = obj.Bounds.Y + (obj.Bounds.Height / 2) - 4;

                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.Left;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();
                        selectedOriginalParent.Clear();
                        selectedOriginalSize.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOriginalSize.Add(obj2.Size);
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                            selectedOriginalParent.Add(obj2.Parent);
                        }
                        return;
                    }
                    // Bottom
                    rectF.X = obj.Bounds.X + (obj.Bounds.Width / 2) - 4;
                    rectF.Y = obj.Bounds.Y + obj.Bounds.Height - 4;
                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.Bottom;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();
                        selectedOriginalParent.Clear();
                        selectedOriginalSize.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOriginalSize.Add(obj2.Size);
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                            selectedOriginalParent.Add(obj2.Parent);
                        }
                        return;
                    }
                    // Right
                    rectF.X = obj.Bounds.X + obj.Bounds.Width - 4;
                    rectF.Y = obj.Bounds.Y + (obj.Bounds.Height / 2) - 4;
                    if (rectF.Contains(point))
                    {
                        IsMouseDown = true;
                        mouseHandle = HandleStyle.Right;
                        selectedObject = obj;
                        selectedOffsets.Clear();
                        selectedOriginalPos.Clear();
                        selectedOriginalParent.Clear();
                        selectedOriginalSize.Clear();

                        foreach (IMenuParts obj2 in selectedObjects)
                        {
                            selectedOriginalSize.Add(obj2.Size);
                            selectedOffsets.Add(new Vector2(point.X, point.Y) - obj2.RealPosition);
                            selectedOriginalPos.Add(obj2.RealPosition);
                            selectedOriginalParent.Add(obj2.Parent);
                        }
                        return;
                    }
                }

                if (selectedObject == null && selectedObjects.Count > 0)
                    selectedObject = selectedObjects[0];
                if (!ctrl || selectedObject == null)
                {
                    SelectedObject = GetMenuPart(point);
                    selectedObjects.Clear();
                }
                else
                {
                    IMenuParts o = GetMenuPart(SelectedObject.Parent, point);
                    if (o != null)
                        if (!SelectedObjects.Contains(o))
                            SelectedObjects.Add(o);
                        else
                        {
                            SelectedObjects.Remove(o);
                            if (o == selectedObject && selectedObjects.Count > 0)
                                selectedObject = selectedObjects[0];
                        }
                    if (selectedObjects.Count > 0)
                        SelectedObjects = SelectedObjects;
                    else
                        selectedObject = null;
                }
                if (selectedObject != null)
                {
                    if (!SelectedObjects.Contains(selectedObject))
                        selectedObjects.Add(selectedObject);
                    IsMouseDown = true;
                }
                else
                {
                    SelectObject(selectedMenu);
                }

                IsMouseDown = true;
                selectionRectangle.X = (int)point.X;
                selectionRectangle.Y = (int)point.Y;
                selectionRectangle.Width = 0;
                selectionRectangle.Height = 0;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // Select Only
                IMenuParts part = GetMenuPart(point);
                if (!SelectedObjects.Contains(part))
                {
                    SelectedObject = part;
                    selectedObjects.Clear();
                    if (selectedObject != null)
                    {
                        selectedObjects.Add(selectedObject);
                        IsMouseDown = true;
                    }
                    else
                    {
                        SelectObject(selectedMenu);
                    }

                    IsMouseDown = true;
                    selectionRectangle.X = (int)point.X;
                    selectionRectangle.Y = (int)point.Y;
                    selectionRectangle.Width = 0;
                    selectionRectangle.Height = 0;

                    this.graphicsControl.Cursor = this.DefaultCursor;
                    Cursor.Current = this.DefaultCursor;
                }
            }
        }

        MenuPartChangePropertyHist propertyChangedHist;
        private void graphicsControl_MouseMove(object sender, MouseEventArgs e)
        {
            currentMouse.X = camera.GetTransformedPoint(e.Location).X;
            currentMouse.Y = camera.GetTransformedPoint(e.Location).Y;
            if (IsMouseDown && !ctrl && selectedObject != null)
            {
                System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);

                float x = point.X; float y = point.Y;
                if (snapToW)
                    x = (float)Math.Floor((double)(point.X / Global.Project.MenuGrid.X)) * Global.Project.MenuGrid.X;
                if (snapToH)
                    y = (float)Math.Floor((double)(point.Y / Global.Project.MenuGrid.Y)) * Global.Project.MenuGrid.Y;
                point.X = x;
                point.Y = y;
                Vector2 pointV = new Vector2(point.X, point.Y);

                if (propertyChangedHist != null && currentMouse == originalMouse)
                    propertyChangedHist = null;

                if (mouseHandle == HandleStyle.Move)
                {
                    Vector2 pos = selectedObject.Position;
                    IMenuParts parent = GetMenuPart(pointV, selectedObjects);

                    for (int index = selectedObjects.Count - 1; index >= 0; index--)
                    {
                        pointV.X = (float)(point.X - selectedOffsets[index].X);
                        pointV.Y = (float)(point.Y - selectedOffsets[index].Y);
                        if (parent != null && selectedObjects[index].Parent != parent)
                        {
                            if (selectedObjects[index].Parent != null)
                                selectedObjects[index].Parent.MenuParts.Remove(selectedObjects[index]);
                            else
                                selectedMenu.MenuParts.Remove(selectedObjects[index]);
                            if (!parent.MenuParts.Contains(selectedObjects[index]))
                                parent.MenuParts.Add(selectedObjects[index]);
                            selectedObjects[index].Position = pointV - parent.RealPosition;
                            selectedObjects[index].Parent = parent;
                        }
                        else if (parent == null && selectedObjects[index].Parent != parent)
                        {
                            if (selectedObjects[index].Parent != null)
                                selectedObjects[index].Parent.MenuParts.Remove(selectedObjects[index]);
                            else
                                selectedMenu.MenuParts.Remove(selectedObjects[index]);

                            if (!selectedMenu.MenuParts.Contains(selectedObjects[index]))
                                selectedMenu.MenuParts.Add(selectedObjects[index]);

                            selectedObjects[index].Position = pointV;
                            selectedObjects[index].Parent = parent;
                        }
                        else
                        {
                            if (selectedObjects[index].Parent != null)
                                pos = pointV - selectedObjects[index].Parent.Position;
                            else
                                pos = pointV;
                            selectedObjects[index].Position = pos;
                        }
                    }
                }
                else if (mouseHandle == HandleStyle.BottomRight)
                {
                    if (propertyChangedHist == null && currentMouse != originalMouse)
                        propertyChangedHist = new MenuPartChangePropertyHist(selectedObject, new DataMenuPartPropertyDelegate(MenuPartPropertyChanged), selectedMenu);
                    selectedOriginalPos.Clear();

                    Vector2 size = selectedObject.Size;
                    float width, height;

                    //for (int index = selectedObjects.Count - 1; index >= 0; index--)
                    // {
                    width = (pointV.X - selectedObject.RealPosition.X);
                    height = (pointV.Y - selectedObject.RealPosition.Y);

                    width = (float)Math.Max(width, 6);
                    height = (float)Math.Max(height, 6);

                    selectedObject.Size = new Vector2(width, height);
                    // }
                }
                else if (mouseHandle == HandleStyle.BottomLeft)
                {
                    if (propertyChangedHist == null && currentMouse != originalMouse)
                        propertyChangedHist = new MenuPartChangePropertyHist(selectedObject, new DataMenuPartPropertyDelegate(MenuPartPropertyChanged), selectedMenu);
                    selectedOriginalPos.Clear();
                    Vector2 size = selectedObject.Size;
                    float width, height;

                    width = (selectedObject.RealPosition.X - pointV.X);
                    height = (pointV.Y - selectedObject.RealPosition.Y);

                    size.X = (float)Math.Max(size.X + width, 6);
                    height = (float)Math.Max(height, 6);

                    if (size.X != selectedObject.Size.X)
                    {
                        selectedObject.Size = new Vector2(size.X, height);
                        selectedObject.Position = new Vector2(selectedObject.Position.X - width, selectedObject.Position.Y);
                    }
                    else
                    {
                        selectedObject.Position = new Vector2(selectedObject.Position.X, selectedObject.Position.Y);
                    }
                }
                else if (mouseHandle == HandleStyle.Bottom)
                {
                    if (propertyChangedHist == null && currentMouse != originalMouse)
                        propertyChangedHist = new MenuPartChangePropertyHist(selectedObject, new DataMenuPartPropertyDelegate(MenuPartPropertyChanged), selectedMenu);
                    selectedOriginalPos.Clear();
                    float width, height;

                    width = selectedObject.Size.X;
                    height = (pointV.Y - selectedObject.RealPosition.Y);

                    width = (float)Math.Max(width, 6);
                    height = (float)Math.Max(height, 6);

                    selectedObject.Size = new Vector2(width, height);
                }
                else if (mouseHandle == HandleStyle.Top)
                {
                    if (propertyChangedHist == null && currentMouse != originalMouse)
                        propertyChangedHist = new MenuPartChangePropertyHist(selectedObject, new DataMenuPartPropertyDelegate(MenuPartPropertyChanged), selectedMenu);
                    selectedOriginalPos.Clear();
                    Vector2 size = selectedObject.Size;
                    float width, height;

                    width = selectedObject.Size.X;
                    height = (selectedObject.RealPosition.Y - pointV.Y);

                    width = (float)Math.Max(width, 6);
                    size.Y = (float)Math.Max(size.Y + height, 6);

                    if (size.Y != selectedObject.Size.Y)
                    {
                        selectedObject.Size = new Vector2(width, size.Y);
                        selectedObject.Position = new Vector2(selectedObject.Position.X, selectedObject.Position.Y - height);
                    }
                }
                else if (mouseHandle == HandleStyle.TopRight)
                {
                    if (propertyChangedHist == null && currentMouse != originalMouse)
                        propertyChangedHist = new MenuPartChangePropertyHist(selectedObject, new DataMenuPartPropertyDelegate(MenuPartPropertyChanged), selectedMenu);
                    selectedOriginalPos.Clear();
                    Vector2 size = selectedObject.Size;
                    float width, height;

                    width = (pointV.X - selectedObject.RealPosition.X);
                    height = (selectedObject.RealPosition.Y - pointV.Y);

                    size.X = (float)Math.Max(width, 6);
                    size.Y = (float)Math.Max(size.Y + height, 6);

                    if (size.Y != selectedObject.Size.Y)
                    {
                        selectedObject.Size = new Vector2(size.X, size.Y);
                        selectedObject.Position = new Vector2(selectedObject.Position.X, selectedObject.Position.Y - height);
                    }
                    else
                    {
                        selectedObject.Size = new Vector2(size.X, selectedObject.Size.Y);
                    }
                }
                else if (mouseHandle == HandleStyle.Left)
                {
                    if (propertyChangedHist == null && currentMouse != originalMouse)
                        propertyChangedHist = new MenuPartChangePropertyHist(selectedObject, new DataMenuPartPropertyDelegate(MenuPartPropertyChanged), selectedMenu);
                    selectedOriginalPos.Clear();
                    Vector2 size = selectedObject.Size;
                    float width, height;

                    width = (selectedObject.RealPosition.X - pointV.X);
                    height = size.Y;

                    size.X = (float)Math.Max(size.X + width, 6);
                    height = (float)Math.Max(height, 6);

                    if (size.X != selectedObject.Size.X)
                    {
                        selectedObject.Size = new Vector2(size.X, height);
                        selectedObject.Position = new Vector2(selectedObject.Position.X - width, selectedObject.Position.Y);
                    }
                }
                else if (mouseHandle == HandleStyle.Right)
                {
                    if (propertyChangedHist == null && currentMouse != originalMouse)
                        propertyChangedHist = new MenuPartChangePropertyHist(selectedObject, new DataMenuPartPropertyDelegate(MenuPartPropertyChanged), selectedMenu);
                    selectedOriginalPos.Clear();
                    float width, height;

                    width = (pointV.X - selectedObject.RealPosition.X);
                    height = selectedObject.Size.Y;

                    width = (float)Math.Max(width, 6);
                    height = (float)Math.Max(height, 6);

                    selectedObject.Size = new Vector2(width, height);
                }
                else
                {
                    propertyChangedHist = null;
                    selectionRectangle.Width = (int)currentMouse.X - selectionRectangle.X;
                    selectionRectangle.Height = (int)currentMouse.Y - selectionRectangle.Y;
                }
            }
            else if (IsMouseDown && !ctrl)
            {
                propertyChangedHist = null;
                selectionRectangle.Width = (int)currentMouse.X - selectionRectangle.X;
                selectionRectangle.Height = (int)currentMouse.Y - selectionRectangle.Y;
            }
            #region Move Mouse + Scroll
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
                newVM = (int)Math.Max(newVM, vScrollBar.Minimum);
                newVM = (int)Math.Min(newVM, vScrollBar.Maximum);
                //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newVM, ScrollOrientation.VerticalScroll));
                vScrollBar.Value = newVM;
                int newHM = hScrollBar.Value + (int)diff.X;
                newHM = (int)Math.Max(newHM, hScrollBar.Minimum);
                newHM = (int)Math.Min(newHM, hScrollBar.Maximum);
                //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, hScrollBar.Value, newHM, ScrollOrientation.HorizontalScroll));
                hScrollBar.Value = newHM;
            }
            lastMousePos = e.Location;
            if (!isMiddleDown)
            {
                if ((!ctrl && !IsMouseDown) || (ctrl && !IsMouseDown))
                {
                    this.graphicsControl.Cursor = this.DefaultCursor;
                }
            }
            #endregion
        }

        private void graphicsControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                IsMouseDown = false;

                if (selectedObjects.Count > 0 && selectedOriginalPos.Count > 0)
                {
                    if (selectedObjects[0].RealPosition != selectedOriginalPos[0])
                    {
                        List<Vector2> newPositions = new List<Vector2>();
                        for (int i = 0; i < selectedObjects.Count; i++)
                        {
                            newPositions.Add(selectedObjects[i].RealPosition);
                        }
                        System.Drawing.PointF point = camera.GetTransformedPoint(e.Location);
                        Vector2 pointV = new Vector2(point.X, point.Y);
                        MainForm.MenuEditorHistory[this].Do(new MenuPartsPositionChangeHist(selectedObjects, selectedOriginalPos, newPositions, pointV, new MenuPartsPositionDelegate(MenuPartsPositionChanged), selectedMenu));
                        selectedOriginalPos.Clear();
                        propertyChangedHist = null;
                    }
                }

                if (propertyChangedHist != null && currentMouse != originalMouse)
                {
                    MainForm.MenuEditorHistory[this].Do(propertyChangedHist);
                }

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
                if (selectionRectangle.Width > 2 && selectionRectangle.Height > 2)
                {

                    selectedObjects.Clear();

                    if (selectedObject != null)
                    {
                        if (selectedObject.Parent != null)
                        {
                            GetChildMenuPart(selectedObject.Parent, selectionRectangle);
                            selectedObject = null;
                        }
                        else
                        {
                            if (selectedObject.IsContainer)
                            {
                                GetChildMenuPart(selectedObject, selectionRectangle);
                                selectedObject = null;
                            }
                            else
                            {
                                GetMenuPart(selectionRectangle);
                            }
                        }
                    }
                    else
                    {
                        GetMenuPart(selectionRectangle);
                    }

                    SelectedObjects = selectedObjects;
                }
                else
                {
                    if (selectedObject != null && selectedObjects.Count < 2)
                        SelectObject(selectedObject);
                }
            }
            originalMouse.X = 0;
            originalMouse.Y = 0;
            isMiddleDown = false;
            mouseHandle = HandleStyle.None;
            selectionRectangle = new Rectangle();
            this.graphicsControl.Cursor = this.DefaultCursor;
            propertyChangedHist = null;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
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
            if (e.KeyCode == Keys.A) snapToW = true;
            if (e.KeyCode == Keys.S) snapToH = true;
        }

        internal void graphicsControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) ctrl = false;
            if (e.KeyCode == Keys.A) snapToW = false;
            if (e.KeyCode == Keys.S) snapToH = false;

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
                newV = (int)Math.Max(newV, vScrollBar.Minimum);
                newV = (int)Math.Min(newV, vScrollBar.Maximum);
                //vScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeDecrement, vScrollBar.Value, newV, ScrollOrientation.VerticalScroll));
                vScrollBar.Value = newV;
                int newH = hScrollBar.Value + (int)diff.X;
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
            if (selectedMenu != null)
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
                vScrollBar.LargeChange = (int)Global.Project.MenuGrid.Y * 2;
                vScrollBar.SmallChange = (int)Global.Project.MenuGrid.Y;
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
                hScrollBar.LargeChange = (int)Global.Project.MenuGrid.X * 2;
                hScrollBar.SmallChange = (int)Global.Project.MenuGrid.X;
                //hScrollBar_Scroll(null, new ScrollEventArgs(ScrollEventType.LargeIncrement, 0, Math.Min(oldScrollX, hScrollBar.Maximum), ScrollOrientation.HorizontalScroll));
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
            iconTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.iconHolder, System.Drawing.Imaging.ImageFormat.Png);
            pixelTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.pixel, System.Drawing.Imaging.ImageFormat.Png);
            moveHandle = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.moveHandle, System.Drawing.Imaging.ImageFormat.Png);
            bgTexture = Loader.TextureFromStream(graphicsDevice, global::EGMGame.Properties.Resources.alarm_clock, System.Drawing.Imaging.ImageFormat.Png);
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
            bgScroller_DoWork(null, null);
            if (contentManager.RootDirectory != MaterialExplorer.contentBuilder.OutputDirectory)
            {
                contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            }
            // Clear device and draw inactive area
            if (selectedMenu != null && ShowBG)
                Global.ClearDevice(graphicsDevice, selectedMenu.BackgroundColor);
            else
                Global.ClearDevice(graphicsDevice, Microsoft.Xna.Framework.Color.Gray);


            // Matrix
            Matrix m = camera.ViewTransformationMatrix();

            try
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, m);


                // Draw Menu
                if (selectedMenu != null)
                {
                    //CheckMenuPosition(null);
                    // Camera
                    if (selectedMenu.CanvasSize.X != camera.ViewingWidth)
                    {
                        camera.ViewingWidth = selectedMenu.CanvasSize.X;
                        UpdateScrollbarsW();
                    }
                    if (selectedMenu.CanvasSize.Y != camera.ViewingHeight)
                    {
                        camera.ViewingHeight = selectedMenu.CanvasSize.Y;
                        UpdateScrollbarsH();
                    }
                    // Draw Background
                    if (ShowBG)
                    {
                        DrawBackground();
                    }
                    DrawGrid();
                    DrawMenu(null);
                    DrawSelectedMenuPart();

                    if (IsMouseDown && selectionRectangle.X > 2 && selectionRectangle.Y > 2)
                    {
                        FillRectangle(new System.Drawing.RectangleF(selectionRectangle.X, selectionRectangle.Y, selectionRectangle.Width, selectionRectangle.Height), Color.White, new Color(0, 0, 255, 100), 1);
                    }
                    if (btnSafeArea.Checked)
                        DrawSafeArea();
                }
                // Draw Middle Mouse Move
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
                Error.LogError(ex, "s61x001");
            }
            finally
            {
                spriteBatch.End();
            }
        }

        public void DrawSafeArea()
        {
            // Look up the current viewport and safe area dimensions.
            Viewport viewport = camera.Viewport;
            viewport.Width = (int)Global.Project.ScreenRatio.X;
            viewport.Height = (int)Global.Project.ScreenRatio.Y;

            Rectangle safeArea = viewport.TitleSafeArea;
            safeArea.X = (int)(viewport.Width * 0.10f);
            safeArea.Y = (int)(viewport.Height * 0.10f);
            safeArea.Height = (int)(viewport.Height * .90f);
            safeArea.Width = (int)(viewport.Width * .90f);

            int viewportRight = viewport.X + viewport.Width;
            int viewportBottom = viewport.Y + viewport.Height;

            // Compute four border rectangles around the edges of the safe area.
            Rectangle leftBorder = new Rectangle(viewport.X,
                                                 viewport.Y,
                                                 safeArea.X - viewport.X,
                                                 viewport.Height);

            Rectangle rightBorder = new Rectangle(safeArea.Width,
                                                  viewport.Y,
                                                  viewportRight - safeArea.Width,
                                                  viewport.Height);

            Rectangle topBorder = new Rectangle(safeArea.Left,
                                                viewport.Y,
                                                safeArea.Width - (viewportRight - safeArea.Width) + 1,
                                                safeArea.Top - viewport.Y);

            Rectangle bottomBorder = new Rectangle(safeArea.Left,
                                                   safeArea.Height,
                                                   safeArea.Width - (viewportRight - safeArea.Width) + 1,
                                                   viewportBottom - safeArea.Height);

            // Draw the safe area borders.
            Color translucentRed = new Color(0, 0, 255, 0.5f);

            spriteBatch.Draw(pixelTexture, leftBorder, translucentRed);
            spriteBatch.Draw(pixelTexture, rightBorder, translucentRed);
            spriteBatch.Draw(pixelTexture, topBorder, translucentRed);
            spriteBatch.Draw(pixelTexture, bottomBorder, translucentRed);

        }

        private void CheckMenuPosition(IMenuParts menuParent)
        {
            System.Drawing.PointF point = new System.Drawing.PointF();
            IMenuParts parent;
            Vector2 pos;
            Vector2 pointV;
            IMenuParts part;
            int count;
            if (menuParent == null)
            {
                count = selectedMenu.MenuParts.Count;
                for (int i = 0; i < count; i++)
                {
                    part = selectedMenu.MenuParts[i];
                    pos = part.RealPosition;
                    point.X = pos.X; point.Y = pos.Y;
                    pointV = new Vector2(point.X, point.Y);

                    parent = GetMenuPart(point, part);

                    if (parent != null && part.Parent != parent)
                    {
                        selectedMenu.MenuParts.Remove(part);
                        i--; count--;
                        parent.MenuParts.Add(part);
                        part.Position = pointV - parent.RealPosition;
                        part.Parent = parent;
                    }
                    CheckMenuPosition(part);
                }
            }
            else
            {
                count = menuParent.MenuParts.Count;
                for (int i = 0; i < count; i++)
                {
                    part = menuParent.MenuParts[i];
                    pos = part.RealPosition;
                    point.X = pos.X; point.Y = pos.Y;
                    pointV = new Vector2(point.X, point.Y);
                    parent = GetMenuPart(point, part);

                    if (parent != null && part.Parent != parent)
                    {
                        if (part.Parent != null)
                            part.Parent.MenuParts.Remove(part);
                        else
                            selectedMenu.MenuParts.Remove(part);
                        i--; count--;
                        parent.MenuParts.Add(part);
                        part.Position = pointV - parent.RealPosition;
                        part.Parent = parent;
                    }
                    else if (parent == null && part.Parent != null)
                    {
                        if (part.Parent != null)
                            part.Parent.MenuParts.Remove(part);
                        else
                            selectedMenu.MenuParts.Remove(part);
                        i--; count--;
                        menuParent.MenuParts.Add(part);

                        part.Position = pointV;
                        part.Parent = parent;
                    }
                    CheckMenuPosition(part);
                }
            }
        }

        private void DrawBackground()
        {
            Texture2D texture = Loader.Texture2D(contentManager, selectedMenu.Background);
            if (texture != null)
            {
                spriteBatch.Draw(texture, new Rectangle(0, 0, (int)selectedMenu.CanvasSize.X, (int)selectedMenu.CanvasSize.Y), Microsoft.Xna.Framework.Color.White);
            }
        }
        /// <summary>
        /// Draw Grid
        /// </summary>
        private void DrawGrid()
        {
            Color gridColor = new Color(0, 0, 0, 80);
            for (int x = 0; x <= selectedMenu.CanvasSize.X; x += (int)Global.Project.MenuGrid.X)
            {
                // Horizontal
                if (x == 0)
                {
                    DrawLineScaled(new Vector2(1, 0), new Vector2(1, selectedMenu.CanvasSize.Y), gridColor, 0, 3);
                }
                else
                {
                    DrawLineScaled(new Vector2(x, 0), new Vector2(x, selectedMenu.CanvasSize.Y), gridColor, 0, 3);
                }
            }
            // Vertical
            for (int y = 0; y <= selectedMenu.CanvasSize.Y + 1; y += (int)Global.Project.MenuGrid.Y)
            {
                if (y == selectedMenu.CanvasSize.Y)
                {
                    DrawLineScaled(new Vector2(0, y), new Vector2(selectedMenu.CanvasSize.X, y - 1), gridColor, 0, 3);
                }
                else
                {
                    DrawLineScaled(new Vector2(0, y), new Vector2(selectedMenu.CanvasSize.X, y), gridColor, 0, 3);
                }
            }

        }
        /// <summary>
        /// Draw Menu
        /// </summary>
        private void DrawMenu(IMenuParts menuPart)
        {
            List<IMenuParts> parts;
            if (menuPart == null)
                parts = selectedMenu.MenuParts;
            else
                parts = menuPart.MenuParts;
            for (int index = 0; index < parts.Count; index++)
            {
                parts[index].Position = new Vector2((int)parts[index].Position.X, (int)parts[index].Position.Y);
                parts[index].Size = new Vector2((int)parts[index].Size.X, (int)parts[index].Size.Y);
                //parts.Remove(selectedObject);
                // Draw Menupart
                if (parts[index] is MenuWindow)
                {
                    DrawWindow((MenuWindow)parts[index]);
                }
                else if (parts[index] is MenuButton)
                {
                    DrawButton((MenuButton)parts[index]);
                }
                else if (parts[index] is HighlighterStatic)
                {
                    DrawListStatic((HighlighterStatic)parts[index]);
                }
                else if (parts[index] is BackgroundProcessPart)
                {
                    DrawBGProcess((BackgroundProcessPart)parts[index]);
                }
                else if (parts[index] is TextPartStatic)
                {
                    DrawTextPartStatic((TextPartStatic)parts[index]);
                }
                else if (parts[index] is TextPartPartyFromList)
                {
                    DrawTextPartParty((TextPartPartyFromList)parts[index]);
                }
                else if (parts[index] is TextPartParty)
                {
                    DrawTextPartParty((TextPartParty)parts[index]);
                }
                else if (parts[index] is TextPartNameParty)
                {
                    DrawTextPartNameParty((TextPartNameParty)parts[index]);
                }
                else if (parts[index] is TextPartNamePartyFromList)
                {
                    DrawTextPartNameParty((TextPartNamePartyFromList)parts[index]);
                }
                else if (parts[index] is TextPartItem)
                {
                    DrawTextPartItem((TextPartItem)parts[index]);
                }
                else if (parts[index] is TextPartSource)
                {
                    DrawTextPartSource((TextPartSource)parts[index]);
                }
                else if (parts[index] is TextPartData)
                {
                    DrawTextPartData((TextPartData)parts[index]);
                }
                else if (parts[index] is TextPartString)
                {
                    DrawTextPartString((TextPartString)parts[index]);
                }
                else if (parts[index] is TextPartVariable)
                {
                    DrawTextPartVariable((TextPartVariable)parts[index]);
                }
                else if (parts[index] is ListStatic)
                {
                    DrawListStatic((ListStatic)parts[index]);
                }
                else if (parts[index] is MenuOptions)
                {
                    DrawListMenuOptions((MenuOptions)parts[index]);
                }
                else if (parts[index] is DynamicBarVariable)
                {
                    DrawDynamicBarVariable((DynamicBarVariable)parts[index]);
                }
                else if (parts[index] is AnimationPartStatic)
                {
                    DrawAnimationPartStatic((AnimationPartStatic)parts[index]);
                }
                else if (parts[index] is AnimationPartParty)
                {
                    DrawAnimationPartParty((AnimationPartParty)parts[index]);
                }
                else if (parts[index] is AnimationPartPartyFromList)
                {
                    DrawAnimationPartParty((AnimationPartPartyFromList)parts[index]);
                }
                else if (parts[index] is DynamicBarParty)
                {
                    DrawDynamicBarParty((DynamicBarParty)parts[index]);
                }
                else if (parts[index] is DynamicBarPartyFromList)
                {
                    DrawDynamicBarParty((DynamicBarPartyFromList)parts[index]);
                }
                else if (parts[index] is ListItemParty)
                {
                    ListItemParty((ListItemParty)parts[index]);
                }
                else if (parts[index] is ListEquipmentParty)
                {
                    ListEquipmentParty((ListEquipmentParty)parts[index]);
                }
                else if (parts[index] is ListSkillParty)
                {
                    ListSkillParty((ListSkillParty)parts[index]);
                }
                else if (parts[index] is ListEquippedParty)
                {
                    ListEquippedParty((ListEquippedParty)parts[index]);
                }
                else if (parts[index] is ListItemPartyFromList)
                {
                    ListItemParty((ListItemPartyFromList)parts[index]);
                }
                else if (parts[index] is ListEquipmentPartyFromList)
                {
                    ListEquipmentParty((ListEquipmentPartyFromList)parts[index]);
                }
                else if (parts[index] is ListSkillPartyFromList)
                {
                    ListSkillParty((ListSkillPartyFromList)parts[index]);
                }
                else if (parts[index] is ListEquippedPartyFromList)
                {
                    ListEquippedParty((ListEquippedPartyFromList)parts[index]);
                }
                else if (parts[index] is ImagePart)
                {
                    DrawImagePart((ImagePart)parts[index]);
                }
                else if (parts[index] is TextPartItem)
                {
                    TextPartItem((TextPartItem)parts[index]);
                }
                else if (parts[index] is TextPartEquipment)
                {
                    TextPartEquipment((TextPartEquipment)parts[index]);
                }
                else if (parts[index] is TextPartEquipped)
                {
                    TextPartEquipment((TextPartEquipped)parts[index]);
                }
                else if (parts[index] is TextPartEquippedFromList)
                {
                    TextPartEquipment((TextPartEquippedFromList)parts[index]);
                }
                else if (parts[index] is TextPartEquipped2)
                {
                    TextPartEquipment((TextPartEquipped2)parts[index]);
                }
                else if (parts[index] is TextPartEquipStat)
                {
                    TextPartEquipment((TextPartEquipStat)parts[index]);
                }
                else if (parts[index] is TextPartEquippedStat)
                {
                    TextPartEquipment((TextPartEquippedStat)parts[index]);
                }
                else if (parts[index] is TextPartCount)
                {
                    TextPartCount((TextPartCount)parts[index]);
                }
                else if (parts[index] is TextPartSkill)
                {
                    TextPartSkill((TextPartSkill)parts[index]);
                }
                else if (parts[index] is ListParty)
                {
                    DrawListParty((ListParty)parts[index]);
                }
                else if (parts[index] is ListPartyFromList)
                {
                    DrawListParty((ListPartyFromList)parts[index]);
                }
                else if (parts[index] is ListItemShop)
                {
                    DrawList((ListItemShop)parts[index]);
                }
                else if (parts[index] is ListItemShop)
                {
                    DrawList((ListItemShop)parts[index]);
                }
                else if (parts[index] is ListEquipmentShop)
                {
                    DrawList((ListEquipmentShop)parts[index]);
                }
                else if (parts[index] is ListItemSource)
                {
                    DrawList((ListItemSource)parts[index]);
                }
                else if (parts[index] is ListEquipmentSource)
                {
                    DrawList((ListEquipmentSource)parts[index]);
                }
                else if (parts[index] is ListSkillSource)
                {
                    DrawList((ListSkillSource)parts[index]);
                }
                else if (parts[index] is TextBoxPart)
                {
                    Draw((TextBoxPart)parts[index]);
                }
                else if (parts[index] is ListSaveLoad)
                {
                    Draw((ListSaveLoad)parts[index]);
                }
                else if (parts[index] is TextPartSaveLoad)
                {
                    Draw((TextPartSaveLoad)parts[index]);
                }
                // Draw its border
                DrawRectangle(parts[index].Bounds, Color.Pink, 1f, 0f);
                // Draw its child parts
                DrawMenu(parts[index]);
            }
        }

        private void Draw(TextBoxPart menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    if (skin.Text.Rounded)
                    {
                        // Load Textures
                        Texture2D left = GetTextureFromID(skin.Text.LeftID);
                        Texture2D center = GetTextureFromID(skin.Text.BackgroundID);
                        Texture2D right = GetTextureFromID(skin.Text.RightID);

                        // Calculate areas
                        int centerStart = left.Width;
                        int rightStart = (int)menuPart.Width - right.Width;

                        int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                        int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                        int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                        // Draw Left
                        spriteBatch.Draw(left, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, left.Width, (int)menuPart.Height), Color.White);

                        if (center.Name != "BLANK")
                        {
                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            DrawGradient(new Rectangle((int)menuPart.RealPosition.X + centerStart, (int)menuPart.RealPosition.Y, (int)centerWidth, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }

                        // Draw Right
                        spriteBatch.Draw(right, new Rectangle((int)(menuPart.RealPosition.X + rightStart), (int)menuPart.RealPosition.Y, (int)right.Width, (int)menuPart.Height), Color.White);
                    }
                    else
                    {

                        // Load Textures
                        Texture2D center = GetTextureFromID(skin.Text.BackgroundID);

                        if (center.Name != "BLANK")
                        {
                            // Calculate areas
                            int centerWidth = (int)menuPart.Width;
                            int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
        }

        private void Draw(TextPartSaveLoad menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void Draw(ListSaveLoad menuPart)
        {
            #region Back
            // Draw the containing list
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion
            // Draw each list item
            // Calculate positions etc.

            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;

            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
            Vector2 current = new Vector2(10, 15);
            if (menuPart.Width > rect.Width + 10 && menuPart.Height > rect.Height + 10 + ItemPadding - 4)
            {
                FontData font = Global.GetData<FontData>(menuPart.Font, GameData.Fonts);
                if (font != null && menuPart.Style > -1 && menuPart.Style < font.Styles.Count)
                {
                    // Draw Content
                    if (menuPart.ShowName)
                    {
                        DrawText(font, font.Styles[menuPart.Style], "Save 1", menuPart.RealPosition + menuPart.NamePos + current, menuPart.TextColor);
                    }
                    if (menuPart.ShowDate)
                    {
                        DrawText(font, font.Styles[menuPart.Style], "Date: " + DateTime.Now.Date.ToShortDateString(), menuPart.RealPosition + menuPart.DatePos + current, menuPart.TextColor);
                    }
                    if (menuPart.ShowTime)
                    {
                        DrawText(font, font.Styles[menuPart.Style], "Time: " + DateTime.Now.Date.ToShortTimeString(), menuPart.RealPosition + menuPart.TimePos + current, menuPart.TextColor);
                    }
                }
                // Draw Highlighter
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void TextPartSkill(TextPartSkill menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void TextPartEquipment(TextPartEquipment menuPart)
        {
            if (menuPart.Show == ShowItemType.Icon)
            {
                Vector2 _offset = menuPart.Size / 2;
                _offset.X -= iconTexture.Width / 2;
                _offset.Y -= iconTexture.Height / 2;
                if (_offset.X >= 0 && _offset.Y >= 0)
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition + _offset, Color.White);
                else
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition, new Rectangle(0, 0, (int)menuPart.Width, (int)menuPart.Height), Color.White);
            }
            else
            {
                if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                    return;
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
            }
        }

        private void TextPartEquipment(TextPartEquipped2 menuPart)
        {
            if (menuPart.Show == ShowItemType.Icon)
            {
                Vector2 _offset = menuPart.Size / 2;
                _offset.X -= iconTexture.Width / 2;
                _offset.Y -= iconTexture.Height / 2;
                if (_offset.X >= 0 && _offset.Y >= 0)
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition + _offset, Color.White);
                else
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition, new Rectangle(0, 0, (int)menuPart.Width, (int)menuPart.Height), Color.White);
            }
            else
            {
                if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                    return;
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
            }
        }

        private void TextPartEquipment(TextPartEquipped menuPart)
        {
            if (menuPart.Show == ShowItemType.Icon)
            {
                Vector2 _offset = menuPart.Size / 2;
                _offset.X -= iconTexture.Width / 2;
                _offset.Y -= iconTexture.Height / 2;
                if (_offset.X >= 0 && _offset.Y >= 0)
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition + _offset, Color.White);
                else
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition, new Rectangle(0, 0, (int)menuPart.Width, (int)menuPart.Height), Color.White);
            }
            else
            {
                if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                    return;
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
            }
        }

        private void TextPartEquipment(TextPartEquippedFromList menuPart)
        {
            if (menuPart.Show == ShowItemType.Icon)
            {
                Vector2 _offset = menuPart.Size / 2;
                _offset.X -= iconTexture.Width / 2;
                _offset.Y -= iconTexture.Height / 2;
                if (_offset.X >= 0 && _offset.Y >= 0)
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition + _offset, Color.White);
                else
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition, new Rectangle(0, 0, (int)menuPart.Width, (int)menuPart.Height), Color.White);
            }
            else
            {
                if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                    return;
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
            }
        }

        private void TextPartEquipment(TextPartEquipStat menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void TextPartEquipment(TextPartEquippedStat menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void TextPartCount(TextPartCount menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void TextPartItem(TextPartItem menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void ListEquippedParty(ListEquippedParty menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            } List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void ListEquippedParty(ListEquippedPartyFromList menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            } List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void ListSkillParty(ListSkillParty menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void ListSkillParty(ListSkillPartyFromList menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void ListEquipmentParty(ListEquipmentParty menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void ListEquipmentParty(ListEquipmentPartyFromList menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawList(ListEquipmentShop menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawList(ListItemShop menuPart)
        {
            #region Background
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawList(ListItemSource menuPart)
        {
            #region Background
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion

            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }

        }

        private void DrawList(ListEquipmentSource menuPart)
        {
            #region Background
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion  
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawList(ListSkillSource menuPart)
        {
            #region Background
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion
            List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void ListItemParty(ListItemParty menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            } List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void ListItemParty(ListItemPartyFromList menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            } List<ListItem> Options = new List<ListItem>();
            Options.Add(new ListItem() { Text = "Option 1", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 2", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 3", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            Options.Add(new ListItem() { Text = "Option 4", Font = menuPart.Font, Style = menuPart.Style, TextColor = menuPart.TextColor });
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawDynamicBarParty(DynamicBarParty menuPart)
        {
            int PropertyMin;
            int PropertyMax;
            int PropertyValue;

            // if (GameData.Variables.ContainsKey(PropertyMin))
            PropertyMin = 0;//(int)GameData.Variables[PropertyMin].Value;
            // else
            //    return;

            // if (GameData.Variables.ContainsKey(menuPart.VariableMax))
            PropertyMax = 100;//(int)GameData.Variables[menuPart.VariableMax].Value;
            // else
            //   return;

            // if (GameData.Variables.ContainsKey(menuPart.VaraibleValue))
            PropertyValue = 100;//(int)GameData.Variables[menuPart.VaraibleValue].Value;
            //else
            //return;

            if (PropertyMin < PropertyMax)
                PropertyValue = Math.Max(PropertyMin, Math.Min(PropertyMax, PropertyValue));
            {
                if (menuPart.SkinID > -1)
                {
                    SkinData skin = GetSkinFromID(menuPart.SkinID);
                    if (skin != null)
                    {
                        if (skin.DynamicBar.Rounded)
                        {
                            // Load Textures
                            Texture2D left = GetTextureFromID(skin.DynamicBar.LeftID);
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D right = GetTextureFromID(skin.DynamicBar.RightID);

                            // Load bar Textures
                            Texture2D barleft = GetTextureFromID(skin.DynamicBar.BarLeftID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);
                            Texture2D barright = GetTextureFromID(skin.DynamicBar.BarRightID);

                            // Calculate areas
                            int centerStart = left.Width;
                            int rightStart = (int)menuPart.Width - right.Width;

                            int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                            int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);


                            // Draw Left
                            spriteBatch.Draw(left, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, left.Width, (int)menuPart.Height), Color.White);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }

                            // Draw Right
                            spriteBatch.Draw(right, new Rectangle((int)(menuPart.RealPosition.X + rightStart), (int)menuPart.RealPosition.Y, (int)right.Width, (int)menuPart.Height), Color.White);

                            ///// BAR
                            // calculate areas
                            int barcenterStart = barleft.Width;
                            int barrightStart = (int)menuPart.Width - barright.Width;

                            // calucate bar width based on the current value and its min and max
                            int min = PropertyMin;
                            int max = PropertyMax;
                            int val = PropertyValue;
                            int maxval = max - min;
                            int valinmax = val - min;
                            decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;

                            int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                            if (barWidth < barleft.Width)
                            {
                                // Draw Left
                                spriteBatch.Draw(barleft, new Rectangle((int)(menuPart.RealPosition.X), (int)menuPart.RealPosition.Y, (int)barWidth, (int)menuPart.Height), new Rectangle(0, 0, barWidth, (int)barleft.Height), Color.White);
                            }
                            else
                            {
                                int barcenterWidth = (int)barWidth - barleft.Width; //- barright.Width;
                                if (barcenterWidth > 0)
                                {
                                    if (barcenterWidth > (menuPart.Width - barleft.Width - barright.Width))
                                        barcenterWidth = (int)(menuPart.Width - barleft.Width - barright.Width);

                                    int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                    int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                    // Draw Left
                                    spriteBatch.Draw(barleft, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, barleft.Width, (int)menuPart.Height), Color.White);

                                    // Draw Repeated Center
                                    for (int i = 0; i < barfullCenterRepeats; i++)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                    }
                                    // Draw Leftover Center
                                    if (barfinalCenterTexels > 0)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                            new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                    }
                                    if (barWidth >= barrightStart)
                                    {
                                        // Draw Right
                                        spriteBatch.Draw(barright, new Rectangle((int)(menuPart.RealPosition.X + barrightStart), (int)menuPart.RealPosition.Y, (int)(barWidth - barrightStart), (int)menuPart.Height), new Rectangle(0, 0, barWidth - barrightStart, (int)barright.Height), Color.White);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Load Textures
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);

                            if (center.Name != "BLANK")
                            {
                                // Calculate areas
                                int centerWidth = (int)menuPart.Width;
                                int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                                int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < fullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (finalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                                }
                            }
                            else if (skin.DynamicBar.BackgroundID > -1)
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                            }

                            if (barcenter.Name != "BLANK")
                            {
                                // calucate bar width based on the current value and its min and max
                                int min = PropertyMin;
                                int max = PropertyMax;
                                int val = PropertyValue;
                                int maxval = max - min;
                                int valinmax = val - min;
                                decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;
                                int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                                int barcenterWidth = (int)barWidth;
                                int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < barfullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (barfinalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                }
                            }
                            else
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.EndGradient, menuPart.StartGradient);
                            }
                        }
                    }
                    else
                    {
                        DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
        }

        private void DrawDynamicBarParty(DynamicBarPartyFromList menuPart)
        {
            int PropertyMin;
            int PropertyMax;
            int PropertyValue;

            // if (GameData.Variables.ContainsKey(PropertyMin))
            PropertyMin = 0;//(int)GameData.Variables[PropertyMin].Value;
            // else
            //    return;

            // if (GameData.Variables.ContainsKey(menuPart.VariableMax))
            PropertyMax = 100;//(int)GameData.Variables[menuPart.VariableMax].Value;
            // else
            //   return;

            // if (GameData.Variables.ContainsKey(menuPart.VaraibleValue))
            PropertyValue = 100;//(int)GameData.Variables[menuPart.VaraibleValue].Value;
            //else
            //return;

            if (PropertyMin < PropertyMax)
                PropertyValue = Math.Max(PropertyMin, Math.Min(PropertyMax, PropertyValue));
            {
                if (menuPart.SkinID > -1)
                {
                    SkinData skin = GetSkinFromID(menuPart.SkinID);
                    if (skin != null)
                    {
                        if (skin.DynamicBar.Rounded)
                        {
                            // Load Textures
                            Texture2D left = GetTextureFromID(skin.DynamicBar.LeftID);
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D right = GetTextureFromID(skin.DynamicBar.RightID);

                            // Load bar Textures
                            Texture2D barleft = GetTextureFromID(skin.DynamicBar.BarLeftID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);
                            Texture2D barright = GetTextureFromID(skin.DynamicBar.BarRightID);

                            // Calculate areas
                            int centerStart = left.Width;
                            int rightStart = (int)menuPart.Width - right.Width;

                            int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                            int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);


                            // Draw Left
                            spriteBatch.Draw(left, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, left.Width, (int)menuPart.Height), Color.White);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }

                            // Draw Right
                            spriteBatch.Draw(right, new Rectangle((int)(menuPart.RealPosition.X + rightStart), (int)menuPart.RealPosition.Y, (int)right.Width, (int)menuPart.Height), Color.White);

                            ///// BAR
                            // calculate areas
                            int barcenterStart = barleft.Width;
                            int barrightStart = (int)menuPart.Width - barright.Width;

                            // calucate bar width based on the current value and its min and max
                            int min = PropertyMin;
                            int max = PropertyMax;
                            int val = PropertyValue;
                            int maxval = max - min;
                            int valinmax = val - min;
                            decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;

                            int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                            if (barWidth < barleft.Width)
                            {
                                // Draw Left
                                spriteBatch.Draw(barleft, new Rectangle((int)(menuPart.RealPosition.X), (int)menuPart.RealPosition.Y, (int)barWidth, (int)menuPart.Height), new Rectangle(0, 0, barWidth, (int)barleft.Height), Color.White);
                            }
                            else
                            {
                                int barcenterWidth = (int)barWidth - barleft.Width; //- barright.Width;
                                if (barcenterWidth > 0)
                                {
                                    if (barcenterWidth > (menuPart.Width - barleft.Width - barright.Width))
                                        barcenterWidth = (int)(menuPart.Width - barleft.Width - barright.Width);

                                    int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                    int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                    // Draw Left
                                    spriteBatch.Draw(barleft, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, barleft.Width, (int)menuPart.Height), Color.White);

                                    // Draw Repeated Center
                                    for (int i = 0; i < barfullCenterRepeats; i++)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                    }
                                    // Draw Leftover Center
                                    if (barfinalCenterTexels > 0)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                            new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                    }
                                    if (barWidth >= barrightStart)
                                    {
                                        // Draw Right
                                        spriteBatch.Draw(barright, new Rectangle((int)(menuPart.RealPosition.X + barrightStart), (int)menuPart.RealPosition.Y, (int)(barWidth - barrightStart), (int)menuPart.Height), new Rectangle(0, 0, barWidth - barrightStart, (int)barright.Height), Color.White);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Load Textures
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);

                            if (center.Name != "BLANK")
                            {
                                // Calculate areas
                                int centerWidth = (int)menuPart.Width;
                                int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                                int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < fullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (finalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                                }
                            }
                            else if (skin.DynamicBar.BackgroundID > -1)
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                            }

                            if (barcenter.Name != "BLANK")
                            {
                                // calucate bar width based on the current value and its min and max
                                int min = PropertyMin;
                                int max = PropertyMax;
                                int val = PropertyValue;
                                int maxval = max - min;
                                int valinmax = val - min;
                                decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;
                                int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                                int barcenterWidth = (int)barWidth;
                                int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < barfullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (barfinalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                }
                            }
                            else
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.EndGradient, menuPart.StartGradient);
                            }
                        }
                    }
                    else
                    {
                        DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
        }
        private void DrawAnimationPartParty(AnimationPartParty menuPart)
        {
            Texture2D tex;

            VariableData var = Global.GetData<VariableData>(menuPart.PartyIndex, GameData.Variables);

            if (var != null && var.Value > -1 && var.Value < GameData.Player.PartyList.Count)
            {
                int id = GameData.Player.PartyList[(int)var.Value];
                HeroData hero = Global.GetData<HeroData>(id, GameData.Heroes);
                if (hero != null)
                {
                    AnimationData ani = Global.GetData<AnimationData>(hero.AnimationID, GameData.Animations);
                    if (ani != null && menuPart.Action > -1 && menuPart.Action < ani.Actions.Count)
                    {
                        AnimationAction action = ani.Actions[menuPart.Action];

                        if (action != null && action.Directions.Count > menuPart.Direction && menuPart.Direction > -1 && action.Directions[menuPart.Direction] != null && action.Directions[menuPart.Direction].Count > 0)
                        {
                            AnimationFrame frame = action.Directions[menuPart.Direction][0];
                            foreach (AnimationSprite sprite in frame.Sprites)
                            {
                                tex = Loader.Texture2D(contentManager, sprite.MaterialId);
                                if (tex != null)
                                {
                                    sprite.Size = new Vector2((float)sprite.DisplayRect.Width, (float)sprite.DisplayRect.Height);
                                    spriteBatch.Draw(
                                        tex,
                                        menuPart.RealPosition + sprite.Position,
                                        sprite.DisplayRect,
                                        sprite.Tint,
                                        DegreesToRadian(sprite.Rotation),
                                        sprite.Size / 2,
                                        sprite.Scale,
                                        GetSpriteEffect(sprite),
                                        0
                                        );
                                }
                            }
                        }
                    }
                }
            }
        }
        private void DrawAnimationPartParty(AnimationPartPartyFromList menuPart)
        {
            Texture2D tex;

            VariableData var = Global.GetData<VariableData>(menuPart.PartyIndex, GameData.Variables);

            if (var != null && var.Value > -1 && var.Value < GameData.Player.PartyList.Count)
            {
                int id = GameData.Player.PartyList[(int)var.Value];
                HeroData hero = Global.GetData<HeroData>(id, GameData.Heroes);
                if (hero != null)
                {
                    AnimationData ani = Global.GetData<AnimationData>(hero.AnimationID, GameData.Animations);
                    if (ani != null && menuPart.Action > -1 && menuPart.Action < ani.Actions.Count)
                    {
                        AnimationAction action = ani.Actions[menuPart.Action];

                        if (action != null && action.Directions.Count > menuPart.Direction && menuPart.Direction > -1 && action.Directions[menuPart.Direction] != null && action.Directions[menuPart.Direction].Count > 0)
                        {
                            AnimationFrame frame = action.Directions[menuPart.Direction][0];
                            foreach (AnimationSprite sprite in frame.Sprites)
                            {
                                tex = Loader.Texture2D(contentManager, sprite.MaterialId);
                                if (tex != null)
                                {
                                    sprite.Size = new Vector2((float)sprite.DisplayRect.Width, (float)sprite.DisplayRect.Height);
                                    spriteBatch.Draw(
                                        tex,
                                        menuPart.RealPosition + sprite.Position,
                                        sprite.DisplayRect,
                                        sprite.Tint,
                                        DegreesToRadian(sprite.Rotation),
                                        sprite.Size / 2,
                                        sprite.Scale,
                                        GetSpriteEffect(sprite),
                                        0
                                        );
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Draw Message Option
        /// </summary>
        /// <param name="menuPart"></param>
        private void DrawListMenuOptions(MenuOptions menuPart)
        {// Draw the containing list
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.Window.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.Window.TopID);
                    Texture2D topRight = GetTextureFromID(skin.Window.TopRightID);

                    Texture2D left = GetTextureFromID(skin.Window.LeftID);
                    Texture2D right = GetTextureFromID(skin.Window.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.Window.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.Window.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.Window.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.Window.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }

            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            foreach (ListItem item in menuPart.Options)
            {
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding + (int)menuPart.TextOffset.X;
                    currentx = 10;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (menuPart.Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }

        }
        /// <summary>
        /// Draw Menu Window
        /// </summary>
        /// <param name="menuPart"></param>
        private void DrawWindow(MenuWindow menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.Window.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.Window.TopID);
                    Texture2D topRight = GetTextureFromID(skin.Window.TopRightID);

                    Texture2D left = GetTextureFromID(skin.Window.LeftID);
                    Texture2D right = GetTextureFromID(skin.Window.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.Window.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.Window.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.Window.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.Window.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
        }
        /// <summary>
        /// Draw Menu Button
        /// </summary>
        /// <param name="menuPart"></param>
        private void DrawButton(MenuButton menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    if (skin.Button.Rounded)
                    {
                        // Load Textures
                        Texture2D left = GetTextureFromID(skin.Button.LeftID);
                        Texture2D center = GetTextureFromID(skin.Button.BackgroundID);
                        Texture2D right = GetTextureFromID(skin.Button.RightID);

                        // Calculate areas
                        int centerStart = left.Width;
                        int rightStart = (int)menuPart.Width - right.Width;

                        int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                        int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                        int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                        // Draw Left
                        spriteBatch.Draw(left, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, left.Width, (int)menuPart.Height), Color.White);

                        if (center.Name != "BLANK")
                        {
                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            DrawGradient(new Rectangle((int)menuPart.RealPosition.X + centerStart, (int)menuPart.RealPosition.Y, (int)centerWidth, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }

                        // Draw Right
                        spriteBatch.Draw(right, new Rectangle((int)(menuPart.RealPosition.X + rightStart), (int)menuPart.RealPosition.Y, (int)right.Width, (int)menuPart.Height), Color.White);
                    }
                    else
                    {

                        // Load Textures
                        Texture2D center = GetTextureFromID(skin.Button.BackgroundID);

                        if (center.Name != "BLANK")
                        {
                            // Calculate areas
                            int centerWidth = (int)menuPart.Width;
                            int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
        }

        private void DrawTextPartStatic(TextPartStatic menuPart)
        {
            if (menuPart.Font > -1 && GameData.Fonts.ContainsKey(menuPart.Font) && menuPart.Style < GameData.Fonts[menuPart.Font].Styles.Count)
            {
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                DrawText(GameData.Fonts[menuPart.Font], style, menuPart.Text, menuPart.RealPosition, menuPart.TextColor);
            }
        }

        private void DrawTextPartItem(TextPartItem menuPart)
        {
            if (menuPart.Show == ShowItemType.Icon)
            {
                Vector2 _offset = menuPart.Size / 2;
                _offset.X -= iconTexture.Width / 2;
                _offset.Y -= iconTexture.Height / 2;
                if (_offset.X >= 0 && _offset.Y >= 0)
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition + _offset, Color.White);
                else
                    spriteBatch.Draw(iconTexture, menuPart.RealPosition, new Rectangle(0, 0, (int)menuPart.Width, (int)menuPart.Height), Color.White);
            }
            else
            {
                if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                    return;
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
            }
        }

        private void DrawTextPartSource(TextPartSource menuPart)
        {
            if (menuPart.Font > -1 && GameData.Fonts.ContainsKey(menuPart.Font))
            {
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
            }
        }

        private void DrawTextPartData(TextPartData menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void DrawTextPartParty(TextPartParty menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void DrawTextPartParty(TextPartPartyFromList menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }
        private void DrawTextPartNameParty(TextPartNameParty menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }
        private void DrawTextPartNameParty(TextPartNamePartyFromList menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void DrawTextPartString(TextPartString menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void DrawTextPartVariable(TextPartVariable menuPart)
        {
            if (menuPart.Font < 0 || !GameData.Fonts.ContainsKey(menuPart.Font))
                return;
            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
            DrawText(GameData.Fonts[menuPart.Font], style, "[" + menuPart.Name + "]", menuPart.RealPosition, menuPart.TextColor);
        }

        private void DrawListStatic(ListStatic menuPart)
        {
            #region Back
            // Draw the containing list
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * menuPart.Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (menuPart.Options.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < menuPart.Options.Count && i <= maxNumberOfRows); i++)
            {
                ListItem item = menuPart.Options[i];
                item.Parent = menuPart;
                item.Height = menuPart.ItemHeight;
                item.Width = width;
                item.Position = new Vector2(currentx, currenty);
                DrawListItem(item, 2);

                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + ItemPadding;
                    currentx = 10 + (int)menuPart.TextOffset.X;
                }
                else
                {
                    currentx += width + ItemPadding;
                }
            }

            if (menuPart.Options.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }

        }
        /// <summary>
        /// Pointer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pointer"></param>
        private void DrawPointer(float x, float y, SkinObjectPointer pointer)
        {
            x += 10; y += 14;
            AnimationData Animation = Global.GetData<AnimationData>(pointer.AnimationID, GameData.Animations);
            if (Animation != null)
            {
                AnimationAction Action = Global.GetData<AnimationAction>(pointer.ActionID, Animation.Actions);
                int Direction = pointer.Direction;
                int frameIndex = 0;
                if (Action != null)
                {
                    // Loop all the frames in the direction.
                    if (Direction > -1 && frameIndex < Action.Directions[Direction].Count)
                    {
                        AnimationFrame frame = null;
                        Texture2D tex;
                        if (frameIndex == -1 && 0 < Action.Directions[Direction].Count)
                            frame = Action.Directions[Direction][0];
                        else if (frameIndex > -1)
                            frame = Action.Directions[Direction][frameIndex];
                        if (frame != null)
                        {
                            Color color = new Color();
                            // Loop and draw sprites
                            for (int spriteIndex = 0; spriteIndex < frame.Sprites.Count; spriteIndex++)
                            {
                                tex = Loader.Texture2D(contentManager, frame.Sprites[spriteIndex].MaterialId);
                                if (tex != null)
                                {
                                    Vector2 pos = new Vector2();
                                    pos.X = (float)Math.Round(x + (frame.Sprites[spriteIndex].Position.X));
                                    pos.Y = (float)Math.Round(y + (frame.Sprites[spriteIndex].Position.Y));

                                    spriteBatch.Draw(
                                        tex,
                                        pos,
                                        frame.Sprites[spriteIndex].DisplayRect,
                                        frame.Sprites[spriteIndex].Tint,
                                        MathHelper.ToRadians(frame.Sprites[spriteIndex].Rotation),
                                        //Vector2.Zero,
                                        new Vector2(frame.Sprites[spriteIndex].DisplayRect.Width / 2, frame.Sprites[spriteIndex].DisplayRect.Height / 2) + frame.Sprites[spriteIndex].OriginOffset,
                                        frame.Sprites[spriteIndex].Scale,
                                        (frame.Sprites[spriteIndex].HorizontalFlip ? SpriteEffects.FlipHorizontally : frame.Sprites[spriteIndex].VerticalFlip ? SpriteEffects.FlipVertically : SpriteEffects.None),
                                        0
                                        );
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Draw List item
        /// </summary>
        /// <param name="menuPart"></param>
        /// <param name="padding"></param>
        private void DrawListItem(ListItem menuPart, int padding)
        {
            int icontextpadding = 5;
            int height = (int)menuPart.Height - (padding * 2);
            int width = (int)menuPart.Width - (padding * 2);

            Texture2D icon = Loader.Texture2D(contentManager, menuPart.Icon);
            int iconPadding = 0;
            if (icon != null)
            {
                iconPadding = icon.Width;
                spriteBatch.Draw(icon, new Vector2(menuPart.RealPosition.X + padding, menuPart.RealPosition.Y + padding + (height - icon.Height) / 2), Color.White);
            }
            FontData font = Global.GetData<FontData>(menuPart.Font, GameData.Fonts);
            if (font != null)
            {
                if (menuPart.Style < font.Styles.Count)
                {
                    FontStyleData style = font.Styles[menuPart.Style];
                    DrawText(GameData.Fonts[menuPart.Font], style, menuPart.Text, new Vector2(menuPart.RealPosition.X + padding + icontextpadding, menuPart.RealPosition.Y + padding + iconPadding + height / 4), menuPart.TextColor);
                }
            }
        }

        private void DrawListStatic(HighlighterStatic menuPart)
        {
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X, menuPart.RealPosition.Y, menuPart.Size.X, menuPart.Size.Y);
            GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
            DrawRectangle(rect, menuPart.HighlightBorderColor, 1);
        }

        private void DrawBGProcess(BackgroundProcessPart menuPart)
        {
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X, menuPart.RealPosition.Y, menuPart.Size.X, menuPart.Size.Y);

            spriteBatch.Draw(bgTexture, new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height), Color.White);
        }
        /// <summary>
        /// Draw List Party
        /// </summary>
        /// <param name="listParty"></param>
        private void DrawListParty(ListParty menuPart)
        {
            #region Back
            // Draw the containing list
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            HeroData hero;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * GameData.Player.PartyList.Count / menuPart.Columns)) / menuPart.ItemHeight) + (GameData.Player.PartyList.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < GameData.Player.PartyList.Count && i <= maxNumberOfRows); i++)
            {
                hero = Global.GetData<HeroData>(GameData.Player.PartyList[i], GameData.Heroes);
                if (hero != null)
                {
                    DrawItemText(hero.Name, new Vector2(currentx, currenty) + menuPart.RealPosition, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor);
                    currentColumn++;

                    if (currentColumn > menuPart.Columns)
                    {
                        currentColumn = 1;
                        currenty += menuPart.ItemHeight + ItemPadding;
                        currentx = 10 + (int)menuPart.TextOffset.X;
                    }
                    else
                    {
                        currentx += width + ItemPadding;
                    }
                }
            }

            if (GameData.Player.PartyList.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawListParty(ListPartyFromList menuPart)
        {
            #region Back
            // Draw the containing list
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.List.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.List.TopID);
                    Texture2D topRight = GetTextureFromID(skin.List.TopRightID);

                    Texture2D left = GetTextureFromID(skin.List.LeftID);
                    Texture2D right = GetTextureFromID(skin.List.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.List.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.List.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuPart.RealPosition.X;
                    int Y = (int)menuPart.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion
            // Draw each list item
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (ItemPadding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10 + (int)menuPart.TextOffset.X;
            int currenty = 10 + (int)menuPart.TextOffset.Y;
            HeroData hero;
            int maxNumberOfRows = (int)((menuPart.Height - (ItemPadding * GameData.Player.PartyList.Count / menuPart.Columns)) / menuPart.ItemHeight) + (GameData.Player.PartyList.Count % (menuPart.Columns + 1));
            for (int i = 0; (i < GameData.Player.PartyList.Count && i <= maxNumberOfRows); i++)
            {
                hero = Global.GetData<HeroData>(GameData.Player.PartyList[i], GameData.Heroes);
                if (hero != null)
                {
                    DrawItemText(hero.Name, new Vector2(currentx, currenty) + menuPart.RealPosition, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor);
                    currentColumn++;

                    if (currentColumn > menuPart.Columns)
                    {
                        currentColumn = 1;
                        currenty += menuPart.ItemHeight + ItemPadding;
                        currentx = 10 + (int)menuPart.TextOffset.X;
                    }
                    else
                    {
                        currentx += width + ItemPadding;
                    }
                }
            }

            if (GameData.Player.PartyList.Count > 0)
            {
                System.Drawing.RectangleF rect = new System.Drawing.RectangleF(menuPart.RealPosition.X + 10, menuPart.RealPosition.Y + 10 + ItemPadding - 4, width - 20, menuPart.ItemHeight + 8);
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        GradientFillRectangle(rect, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GetSkinFromID(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(menuPart.RealPosition.X + menuPart.CursorOffset.X, menuPart.RealPosition.Y + menuPart.CursorOffset.Y, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawItemText(string txt, Vector2 position, Vector2 size, int padding, int font, int style, Color textColor)
        {
            int height = (int)size.Y - (padding * 2);
            int width = (int)size.X - (padding * 2);

            FontData _font = Global.GetData<FontData>(font, GameData.Fonts);
            if (_font != null)
            {
                FontStyleData _style = _font.Styles[style];
                DrawText(_font, _style, txt, new Vector2(position.X + padding, position.Y + padding + height / 4), textColor);
            }
        }

        private void GradientFillRectangle(System.Drawing.RectangleF rect, Color border, Color ColorTop, Color ColorBottom)
        {
            // Store the screen width and height into here. 
            // These values are used in 'texture', forloop,  
            // and used in the color function. 
            // 
            // You could change this in anyway you seem fit! 
            int width = (int)rect.Width;
            int height = (int)rect.Height;

            // Init all ColorTop & ColorBottom values.  
            int R1 = ColorTop.R, R2 = ColorBottom.R; // Red 
            int G1 = ColorTop.G, G2 = ColorBottom.G; // Green 
            int B1 = ColorTop.B, B2 = ColorBottom.B; // Blue 
            int A1 = ColorTop.A, A2 = ColorBottom.A; // Alpha 

            // Make a forloop that goes from the top of the 
            // screen to the bottom of the screen 
            for (int i = 0; i < height; i++)
            {
                // This color function to make the top colors 
                // blend with the bottom colors gradually. 
                // 
                // This also works for alpha too! You can make the bottom 
                // or top trasparent! 
                int r = R1 + (i * (R2 - R1) / height); // Red Colors 
                int g = G1 + (i * (G2 - G1) / height); // Green Colors 
                int b = B1 + (i * (B2 - B1) / height); // Blue Colors 
                int a = A1 + (i * (A2 - A1) / height); // Aplha Channels 

                // Put all colors into 'colordata' 
                Color ColorData = new Color((byte)r, (byte)g, (byte)b, (byte)a);

                // Draw the spriteline on the screen with the color data 
                spriteBatch.Draw(pixelTexture,           // Texture 
                    new Vector2(rect.X, rect.Y + i),              // Position 
                    new Rectangle(0, 0, width, 1),  // Coverage Area 
                    ColorData);                     // Color 
            }

            DrawRectangle(rect, border, 1);
        }

        private void DrawDynamicBarVariable(DynamicBarVariable menuPart)
        {
            int PropertyMin;
            int PropertyMax;
            int PropertyValue;

            // if (GameData.Variables.ContainsKey(PropertyMin))
            PropertyMin = 0;//(int)GameData.Variables[PropertyMin].Value;
            // else
            //    return;

            // if (GameData.Variables.ContainsKey(menuPart.VariableMax))
            PropertyMax = 100;//(int)GameData.Variables[menuPart.VariableMax].Value;
            // else
            //   return;

            // if (GameData.Variables.ContainsKey(menuPart.VaraibleValue))
            PropertyValue = 100;//(int)GameData.Variables[menuPart.VaraibleValue].Value;
            //else
            //return;

            if (PropertyMin < PropertyMax)
                PropertyValue = Math.Max(PropertyMin, Math.Min(PropertyMax, PropertyValue));
            {
                if (menuPart.SkinID > -1)
                {
                    SkinData skin = GetSkinFromID(menuPart.SkinID);
                    if (skin != null)
                    {
                        if (skin.DynamicBar.Rounded)
                        {
                            // Load Textures
                            Texture2D left = GetTextureFromID(skin.DynamicBar.LeftID);
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D right = GetTextureFromID(skin.DynamicBar.RightID);

                            // Load bar Textures
                            Texture2D barleft = GetTextureFromID(skin.DynamicBar.BarLeftID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);
                            Texture2D barright = GetTextureFromID(skin.DynamicBar.BarRightID);

                            // Calculate areas
                            int centerStart = left.Width;
                            int rightStart = (int)menuPart.Width - right.Width;

                            int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                            int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);


                            // Draw Left
                            spriteBatch.Draw(left, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, left.Width, (int)menuPart.Height), Color.White);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }

                            // Draw Right
                            spriteBatch.Draw(right, new Rectangle((int)(menuPart.RealPosition.X + rightStart), (int)menuPart.RealPosition.Y, (int)right.Width, (int)menuPart.Height), Color.White);

                            ///// BAR
                            // calculate areas
                            int barcenterStart = barleft.Width;
                            int barrightStart = (int)menuPart.Width - barright.Width;

                            // calucate bar width based on the current value and its min and max
                            int min = PropertyMin;
                            int max = PropertyMax;
                            int val = PropertyValue;
                            int maxval = max - min;
                            int valinmax = val - min;
                            decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;

                            int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                            if (barWidth < barleft.Width)
                            {
                                // Draw Left
                                spriteBatch.Draw(barleft, new Rectangle((int)(menuPart.RealPosition.X), (int)menuPart.RealPosition.Y, (int)barWidth, (int)menuPart.Height), new Rectangle(0, 0, barWidth, (int)barleft.Height), Color.White);
                            }
                            else
                            {
                                int barcenterWidth = (int)barWidth - barleft.Width; //- barright.Width;
                                if (barcenterWidth > 0)
                                {
                                    if (barcenterWidth > (menuPart.Width - barleft.Width - barright.Width))
                                        barcenterWidth = (int)(menuPart.Width - barleft.Width - barright.Width);

                                    int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                    int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                    // Draw Left
                                    spriteBatch.Draw(barleft, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, barleft.Width, (int)menuPart.Height), Color.White);

                                    // Draw Repeated Center
                                    for (int i = 0; i < barfullCenterRepeats; i++)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                    }
                                    // Draw Leftover Center
                                    if (barfinalCenterTexels > 0)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                            new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                    }
                                    if (barWidth >= barrightStart)
                                    {
                                        // Draw Right
                                        spriteBatch.Draw(barright, new Rectangle((int)(menuPart.RealPosition.X + barrightStart), (int)menuPart.RealPosition.Y, (int)(barWidth - barrightStart), (int)menuPart.Height), new Rectangle(0, 0, barWidth - barrightStart, (int)barright.Height), Color.White);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Load Textures
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);

                            if (center.Name != "BLANK")
                            {
                                // Calculate areas
                                int centerWidth = (int)menuPart.Width;
                                int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                                int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < fullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (finalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                                }
                            }
                            else if (skin.DynamicBar.BackgroundID > -1)
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                            }

                            if (barcenter.Name != "BLANK")
                            {
                                // calucate bar width based on the current value and its min and max
                                int min = PropertyMin;
                                int max = PropertyMax;
                                int val = PropertyValue;
                                int maxval = max - min;
                                int valinmax = val - min;
                                decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;
                                int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                                int barcenterWidth = (int)barWidth;
                                int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < barfullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (barfinalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                }
                            }
                            else
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.EndGradient, menuPart.StartGradient);
                            }
                        }
                    }
                    else
                    {
                        DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
        }

        private void DrawAnimationPartStatic(AnimationPartStatic menuPart)
        {
            Texture2D tex;
            AnimationData ani = Global.GetData<AnimationData>(menuPart.Animation, GameData.Animations);
            if (ani != null)
            {
                AnimationAction action = Global.GetData<AnimationAction>(menuPart.Action, ani.Actions);

                if (action != null && action.Directions.Count > menuPart.Direction && menuPart.Direction > -1 && action.Directions[menuPart.Direction] != null && action.Directions[menuPart.Direction].Count > 0)
                {
                    AnimationFrame frame = action.Directions[menuPart.Direction][0];
                    foreach (AnimationSprite sprite in frame.Sprites)
                    {
                        tex = Loader.Texture2D(contentManager, sprite.MaterialId);
                        if (tex != null)
                        {
                            sprite.Size = new Vector2((float)sprite.DisplayRect.Width, (float)sprite.DisplayRect.Height);
                            spriteBatch.Draw(
                                tex,
                                menuPart.RealPosition + sprite.Position,
                                sprite.DisplayRect,
                                sprite.Tint,
                                DegreesToRadian(sprite.Rotation),
                                sprite.Size / 2,
                                sprite.Scale,
                                GetSpriteEffect(sprite),
                                0
                                );
                        }
                    }
                }
            }
        }

        private void DrawImagePart(ImagePart menuPart)
        {
            // Load image
            Texture2D image = Loader.Texture2D(contentManager, menuPart.Image);
            if (image != null && image.Name != "BLANK")
            {
                spriteBatch.Draw(image, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), new Rectangle(0, 0, (int)image.Width, (int)image.Height), Color.White, 0, Vector2.Zero, (menuPart.VerticalFlip ? SpriteEffects.FlipVertically : menuPart.HorizontalFlip ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 1f);
            }
        }

        private void DrawText(FontData font, FontStyleData style, string text, Vector2 position, Color color)
        {
            Global.DrawText(spriteBatch, contentManager, font, style, text, position, color);
        }

        /// <summary>
        /// Draw Selected Menupart
        /// </summary>
        private void DrawSelectedMenuPart()
        {
            System.Drawing.RectangleF rectF = new System.Drawing.RectangleF(0, 0, 12, 12);
            if (selectedObject != null)
            {
                // Draw its border
                DrawRectangle(selectedObject.Bounds, Color.Blue, 1f, 0f);

                rectF.X = selectedObject.Bounds.X - 6;
                rectF.Y = selectedObject.Bounds.Y - 6;
                // Top Left
                //FillRectangle(rectF, Color.Black, Color.Yellow, 0);
                spriteBatch.Draw(moveHandle, new Vector2(rectF.X, rectF.Y), Color.White);

                rectF.Width = 8;
                rectF.Height = 8;
                rectF.X = selectedObject.Bounds.X + selectedObject.Bounds.Width - 4;
                rectF.Y = selectedObject.Bounds.Y + SelectedObject.Bounds.Height - 4;
                // Bottom Right
                FillRectangle(rectF, Color.Black, Color.Blue, 0); rectF.Width = 8;
                // Bottom Left
                rectF.X = selectedObject.Bounds.X - 4;
                rectF.Y = selectedObject.Bounds.Y + SelectedObject.Bounds.Height - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Top Right
                rectF.X = selectedObject.Bounds.X + selectedObject.Bounds.Width - 4;
                rectF.Y = selectedObject.Bounds.Y - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Top
                rectF.X = selectedObject.Bounds.X + (selectedObject.Bounds.Width / 2) - 4;
                rectF.Y = selectedObject.Bounds.Y - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Top Line
                if (IsMouseDown && mouseHandle != HandleStyle.None)
                    DrawLineScaled(new Vector2(0, rectF.Y + 4), new Vector2(selectedMenu.CanvasSize.X, rectF.Y + 4), Color.Blue, 1, GetScale());
                // Left
                rectF.X = selectedObject.Bounds.X - 4;
                rectF.Y = selectedObject.Bounds.Y + (SelectedObject.Bounds.Height / 2) - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Left Line
                if (IsMouseDown && mouseHandle != HandleStyle.None)
                    DrawLineScaled(new Vector2(rectF.X + 4, 0), new Vector2(rectF.X + 4, selectedMenu.CanvasSize.Y), Color.Blue, 1, GetScale());
                // Bottom
                rectF.X = selectedObject.Bounds.X + (selectedObject.Bounds.Width / 2) - 4;
                rectF.Y = selectedObject.Bounds.Y + SelectedObject.Bounds.Height - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Bottom Line
                if (IsMouseDown && mouseHandle != HandleStyle.None)
                    DrawLineScaled(new Vector2(0, rectF.Y + 4), new Vector2(selectedMenu.CanvasSize.X, rectF.Y + 4), Color.Blue, 1, GetScale());
                // Right
                rectF.X = selectedObject.Bounds.X + selectedObject.Bounds.Width - 4;
                rectF.Y = selectedObject.Bounds.Y + (SelectedObject.Bounds.Height / 2) - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Right Line
                if (IsMouseDown && mouseHandle != HandleStyle.None)
                    DrawLineScaled(new Vector2(rectF.X + 4, 0), new Vector2(rectF.X + 4, selectedMenu.CanvasSize.Y), Color.Blue, 1, GetScale());

            }

            foreach (IMenuParts obj in selectedObjects)
            {
                // Draw its border
                DrawRectangle(obj.Bounds, Color.Blue, 1f, 0f);

                rectF.X = obj.Bounds.X - 6;
                rectF.Y = obj.Bounds.Y - 6;
                // Top Left
                //FillRectangle(rectF, Color.Black, Color.Yellow, 0);
                spriteBatch.Draw(moveHandle, new Vector2(rectF.X, rectF.Y), Color.White);

                rectF.Width = 8;
                rectF.Height = 8;
                rectF.X = obj.Bounds.X + obj.Bounds.Width - 4;
                rectF.Y = obj.Bounds.Y + obj.Bounds.Height - 4;
                // Bottom Right
                FillRectangle(rectF, Color.Black, Color.Blue, 0); rectF.Width = 8;
                // Bottom Left
                rectF.X = obj.Bounds.X - 4;
                rectF.Y = obj.Bounds.Y + obj.Bounds.Height - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Top Right
                rectF.X = obj.Bounds.X + obj.Bounds.Width - 4;
                rectF.Y = obj.Bounds.Y - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Top
                rectF.X = obj.Bounds.X + (obj.Bounds.Width / 2) - 4;
                rectF.Y = obj.Bounds.Y - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Top Line
                // Left
                rectF.X = obj.Bounds.X - 4;
                rectF.Y = obj.Bounds.Y + (obj.Bounds.Height / 2) - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Left Line
                // Bottom
                rectF.X = obj.Bounds.X + (obj.Bounds.Width / 2) - 4;
                rectF.Y = obj.Bounds.Y + obj.Bounds.Height - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Bottom Line

                rectF.X = obj.Bounds.X + obj.Bounds.Width - 4;
                rectF.Y = obj.Bounds.Y + (obj.Bounds.Height / 2) - 4;
                FillRectangle(rectF, Color.Black, Color.Blue, 0);
                // Draw Right Line

            }
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
        private void DrawRectangle(Rectangle rectangle, Color borderColor, float priority, float rotation)
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

            spriteBatch.Draw(pixelTexture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, GetScale()), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }/// <summary>
        /// Draw Line
        /// </summary>
        /// <param name="PointA"></param>
        /// <param name="PointB"></param>
        /// <param name="color"></param>
        /// <param name="priority"></param>
        private void DrawLineScaled(Vector2 PointA, Vector2 PointB, Color color, float priority, int scale)
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
        /// Gradient
        /// </summary>
        /// <param name="ColorTop"></param>
        /// <param name="ColorBottom"></param>
        public void DrawGradient(Rectangle rect, Color ColorTop, Color ColorBottom)
        {
            // Store the screen width and height into here. 
            // These values are used in 'texture', forloop,  
            // and used in the color function. 
            // 
            // You could change this in anyway you seem fit! 
            int width = rect.Width;
            int height = rect.Height;

            // Init all ColorTop & ColorBottom values.  
            int R1 = ColorTop.R, R2 = ColorBottom.R; // Red 
            int G1 = ColorTop.G, G2 = ColorBottom.G; // Green 
            int B1 = ColorTop.B, B2 = ColorBottom.B; // Blue 
            int A1 = ColorTop.A, A2 = ColorBottom.A; // Alpha 

            // Making a new texture with 1x1 pixel size 
            Texture2D texture =
                new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            // Set the color data and make the sprite texture pure white 
            texture.SetData<Color>(new Color[] { Color.White });

            // Make a forloop that goes from the top of the 
            // screen to the bottom of the screen 
            for (int i = 0; i < height; i++)
            {
                // This color function to make the top colors 
                // blend with the bottom colors gradually. 
                // 
                // This also works for alpha too! You can make the bottom 
                // or top trasparent! 
                int r = R1 + (i * (R2 - R1) / height); // Red Colors 
                int g = G1 + (i * (G2 - G1) / height); // Green Colors 
                int b = B1 + (i * (B2 - B1) / height); // Blue Colors 
                int a = A1 + (i * (A2 - A1) / height); // Aplha Channels 

                // Put all colors into 'colordata' 
                Color ColorData = new Color((byte)r, (byte)g, (byte)b, (byte)a);

                // Draw the spriteline on the screen with the color data 
                spriteBatch.Draw(texture,           // Texture 
                    new Vector2(rect.X, rect.Y + i),              // Position 
                    new Rectangle(0, 0, width, 1),  // Coverage Area 
                    ColorData);                     // Color 
            }
        }
        #endregion

        #region Drag/Drop
        private void graphicsControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if ((node.Parent != null && node == MainForm.menuPartsExplorer.toolBox.SelectedNode) || node == MainForm.materialExplorer.SelectedNode)
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void graphicsControl_DragDrop(object sender, DragEventArgs e)
        {
            if (selectedMenu != null && e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                System.Drawing.Point cp = this.PointToClient(new System.Drawing.Point(e.X, e.Y));
                System.Drawing.PointF p = camera.GetTransformedPoint(cp);
                if (node.Parent != null && node == MainForm.menuPartsExplorer.toolBox.SelectedNode)
                {
                    #region Add Menu Part
                    switch (node.Name)
                    {
                        case "Containers":
                            switch (node.Text)
                            {
                                case "Window":
                                    SelectedObject = new MenuWindow();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Window");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(50, 50);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                            }
                            break;
                        case "Static":
                            switch (node.Text)
                            {
                                case "Button":
                                    SelectedObject = new MenuButton();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Button");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Text":
                                    SelectedObject = new TextPartStatic();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "List":
                                    SelectedObject = new ListStatic();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("List");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Image":
                                    SelectedObject = new ImagePart();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Image");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(50, 50);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Animation":
                                    SelectedObject = new AnimationPartStatic();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Animation");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(50, 50);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Options":
                                    SelectedObject = new MenuOptions();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Option");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(50, 50);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Highlighter":
                                    SelectedObject = new HighlighterStatic();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Highlighter");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(50, 50);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Background Process":
                                    SelectedObject = new BackgroundProcessPart();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("BackgroundProcess");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(50, 50);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                            }
                            break;
                        case "Source":
                            switch (node.Text)
                            {
                                case "Text":
                                    SelectedObject = new TextPartSource();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Item":
                                    SelectedObject = new TextPartItem();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Item");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Skill":
                                    SelectedObject = new TextPartSkill();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Skill");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipment":
                                    SelectedObject = new TextPartEquipment();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipment");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipped":
                                    SelectedObject = new TextPartEquipped();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipped");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipped 2":
                                    SelectedObject = new TextPartEquipped2();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipped2");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipment Stat":
                                    SelectedObject = new TextPartEquipStat();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipment Stat");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Count":
                                    SelectedObject = new TextPartCount();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Count");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Shop Items":
                                    SelectedObject = new ListItemShop();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Shop Item");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Shop Equipments":
                                    SelectedObject = new ListEquipmentShop();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Shop Equipments");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Items":
                                    SelectedObject = new ListItemSource();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Items");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipments":
                                    SelectedObject = new ListEquipmentSource();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipments");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Skills":
                                    SelectedObject = new ListSkillSource();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Skills");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Save/Load List":
                                    SelectedObject = new ListSaveLoad();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("SaveLoad List");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Save/Load":
                                    SelectedObject = new TextPartSaveLoad();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("SaveLoad");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                            }
                            break;
                        case "Party":
                            switch (node.Text)
                            {
                                case "Equipped Stat":
                                    SelectedObject = new TextPartEquippedStat();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipped Stat");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Party List":
                                    SelectedObject = new ListParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Party List");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Property":
                                    SelectedObject = new TextPartParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Name":
                                    SelectedObject = new TextPartNameParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Dynamic Bar":
                                    SelectedObject = new DynamicBarParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Dynamic Bar");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Animation":
                                    SelectedObject = new AnimationPartParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Animation");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipped":
                                    SelectedObject = new ListEquippedParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipped");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipments":
                                    SelectedObject = new ListEquipmentParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipments");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Items":
                                    SelectedObject = new ListItemParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Items");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Skills":
                                    SelectedObject = new ListSkillParty();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Skills");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                            }
                            break;
                        case "Party (List)":
                            switch (node.Text)
                            {
                                case "Equipped Stat":
                                    SelectedObject = new TextPartEquippedStatFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipped Stat");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Party List":
                                    SelectedObject = new ListPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Party List");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Property":
                                    SelectedObject = new TextPartPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Name":
                                    SelectedObject = new TextPartNamePartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Dynamic Bar":
                                    SelectedObject = new DynamicBarPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Dynamic Bar");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Animation":
                                    SelectedObject = new AnimationPartPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Animation");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipped":
                                    SelectedObject = new ListEquippedPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipped");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Equipments":
                                    SelectedObject = new ListEquipmentPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Equipments");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Items":
                                    SelectedObject = new ListItemPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Items");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Skills":
                                    SelectedObject = new ListSkillPartyFromList();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Skills");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                            }
                            break;
                        case "Variable":
                            switch (node.Text)
                            {
                                case "Text": // Text
                                    SelectedObject = new TextPartString();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Number": // Variable
                                    SelectedObject = new TextPartVariable();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Text");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Dynamic Bar":
                                    SelectedObject = new DynamicBarVariable();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Dynamic Bar");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                                case "Textbox":
                                    SelectedObject = new TextBoxPart();
                                    SelectedObject.SkinID = selectedMenu.SkinID;
                                    SelectedObject.Name = GetName("Textbox");
                                    SelectedObject.ID = GetID();
                                    selectedObject.Size = new Vector2(75, 23);

                                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                                    break;
                            }
                            break;
                    }
                    #endregion
                }
                else if (node == MainForm.materialExplorer.SelectedNode && MainForm.materialExplorer.Data() != null && MainForm.materialExplorer.Data().DataType == MaterialDataType.Image)
                {

                    SelectedObject = new ImagePart();
                    SelectedObject.SkinID = selectedMenu.SkinID;
                    SelectedObject.Name = GetName("Image");
                    SelectedObject.ID = GetID();
                    ((ImagePart)selectedObject).ImageName = MainForm.materialExplorer.Data();

                    AddObject(selectedObject, new Vector2(p.X, p.Y));
                }
            }
        }
        /// <summary>
        /// Get the name of the menupart
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetName(string name)
        {
            for (int index = 0; index < 999999; index++)
            {
                if (!CheckIfNameExists(name + index.ToString()))
                {
                    return name + index.ToString();
                }
            }
            return name;
        }

        private bool CheckIfNameExists(string name)
        {
            foreach (IMenuParts part in selectedMenu.MenuParts)
            {
                if (part.Name == name)
                {
                    return true;
                }
                if (CheckIfNameExistsChild(part, name))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfNameExistsChild(IMenuParts parent, string name)
        {
            foreach (IMenuParts part in parent.MenuParts)
            {
                if (part.Name == name)
                {
                    return true;
                }
                if (CheckIfNameExistsChild(part, name))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get ID
        /// </summary>
        /// <returns></returns>
        private int GetID()
        {
            for (int index = 0; index < 999999; index++)
            {
                if (!CheckIfIDExists(index))
                {
                    return index;
                }
            }
            return 0;
        }
        /// <summary>
        /// Get id
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool CheckIfIDExists(int id)
        {
            foreach (IMenuParts part in selectedMenu.MenuParts)
            {
                if (part.ID == id)
                {
                    return true;
                }
                if (CheckIfIDExistsChild(part, id))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfIDExistsChild(IMenuParts parent, int id)
        {
            foreach (IMenuParts part in parent.MenuParts)
            {
                if (part.ID == id)
                {
                    return true;
                }
                if (CheckIfIDExistsChild(part, id))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Add object
        /// </summary>
        /// <param name="selectedObject"></param>
        private void AddObject(IMenuParts obj, Vector2 realPoint)
        {
            for (int reverseIndex = selectedMenu.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (AddObjectToChild(obj, selectedMenu.MenuParts[reverseIndex], realPoint))
                    return;
                if (selectedMenu.MenuParts[reverseIndex].IsContainer && selectedMenu.MenuParts[reverseIndex].Bounds.Contains((int)realPoint.X, (int)realPoint.Y))
                {
                    MainForm.MenuEditorHistory[this].Do(new MenuPartAddedHist(obj, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), selectedMenu.MenuParts[reverseIndex], selectedMenu));
                    selectedMenu.MenuParts[reverseIndex].MenuParts.Add(obj);
                    obj.Parent = selectedMenu.MenuParts[reverseIndex];
                    obj.Position = realPoint - selectedMenu.MenuParts[reverseIndex].RealPosition;
                    return;
                }
            }
            MainForm.MenuEditorHistory[this].Do(new MenuPartAddedHist(obj, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), selectedMenu));
            selectedMenu.MenuParts.Add(obj);
            obj.Position = realPoint;
            MainForm.menuPropertyExplorer.PopulateMenuParts(selectedMenu);
            SelectedObject = selectedObject;
        }
        /// <summary>
        /// Add object to child
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="iMenuParts"></param>
        /// <returns></returns>
        private bool AddObjectToChild(IMenuParts obj, IMenuParts iMenuParts, Vector2 realPoint)
        {
            for (int reverseIndex = iMenuParts.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (AddObjectToChild(obj, iMenuParts.MenuParts[reverseIndex], realPoint))
                    return true;
                if (iMenuParts.MenuParts[reverseIndex].IsContainer && iMenuParts.MenuParts[reverseIndex].Bounds.Contains((int)realPoint.X, (int)realPoint.Y))
                {
                    // MainForm.MenuEditorHistory[this].Do(new MenuPartAddedHist(obj, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), iMenuParts.MenuParts[reverseIndex]));
                    iMenuParts.MenuParts[reverseIndex].MenuParts.Add(obj);
                    obj.Parent = iMenuParts.MenuParts[reverseIndex];
                    obj.Position = realPoint - iMenuParts.MenuParts[reverseIndex].RealPosition;
                }
            }
            return false;
        }
        #endregion

        private void GetMenuPart(Rectangle rect)
        {
            for (int reverseIndex = selectedMenu.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (selectionRectangle.Intersects(selectedMenu.MenuParts[reverseIndex].Bounds))
                {
                    selectedObjects.Add(selectedMenu.MenuParts[reverseIndex]);
                }
            }
        }

        private void GetChildMenuPart(IMenuParts parent, Rectangle rect)
        {
            for (int reverseIndex = parent.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (selectionRectangle.Intersects(parent.MenuParts[reverseIndex].Bounds))
                {
                    selectedObjects.Add(parent.MenuParts[reverseIndex]);
                }
            }
        }

        private IMenuParts GetMenuPart(System.Drawing.PointF point, IMenuParts obj)
        {
            IMenuParts part;
            for (int reverseIndex = selectedMenu.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (selectedMenu.MenuParts[reverseIndex] == obj)
                    continue;


                part = GetChildMenuPart(selectedMenu.MenuParts[reverseIndex], point, obj);


                if (part != null)
                {
                    if (part is MenuWindow)
                    {
                        if (part.Bounds.Contains((int)point.X, (int)point.Y))
                        {
                            return part;
                        }
                    }
                }

                if (selectedMenu.MenuParts[reverseIndex] is MenuWindow)
                {
                    if (selectedMenu.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                    {
                        return selectedMenu.MenuParts[reverseIndex];
                    }
                }
            }
            return null;
        }

        private IMenuParts GetMenuPart(MenuData menu, Vector2 point, List<IMenuParts> obj)
        {
            IMenuParts part;
            for (int reverseIndex = menu.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (obj.Contains(menu.MenuParts[reverseIndex]))
                    continue;


                part = GetChildMenuPart(menu.MenuParts[reverseIndex], point, obj);


                if (part != null)
                {
                    if (part is MenuWindow)
                    {
                        if (part.Bounds.Contains((int)point.X, (int)point.Y))
                        {
                            return part;
                        }
                    }
                }

                if (menu.MenuParts[reverseIndex] is MenuWindow)
                {
                    if (menu.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                    {
                        return menu.MenuParts[reverseIndex];
                    }
                }
            }
            return null;
        }


        private IMenuParts GetMenuPart(Vector2 point, List<IMenuParts> obj)
        {
            IMenuParts part;
            for (int reverseIndex = selectedMenu.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (obj.Contains(selectedMenu.MenuParts[reverseIndex]))
                    continue;


                part = GetChildMenuPart(selectedMenu.MenuParts[reverseIndex], point, obj);


                if (part != null)
                {
                    if (part is MenuWindow)
                    {
                        if (part.Bounds.Contains((int)point.X, (int)point.Y))
                        {
                            return part;
                        }
                    }
                }

                if (selectedMenu.MenuParts[reverseIndex] is MenuWindow)
                {
                    if (selectedMenu.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                    {
                        return selectedMenu.MenuParts[reverseIndex];
                    }
                }
            }
            return null;
        }

        private IMenuParts GetMenuPart(Vector2 v, IMenuParts obj)
        {
            System.Drawing.PointF n = new System.Drawing.PointF(v.X, v.Y);
            return GetMenuPart(n, obj);
        }

        private IMenuParts GetChildMenuPart(IMenuParts parent, System.Drawing.PointF point, IMenuParts obj)
        {
            IMenuParts part;
            for (int reverseIndex = parent.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (parent.MenuParts[reverseIndex] == obj)
                    continue;
                part = GetChildMenuPart(parent.MenuParts[reverseIndex], point, obj);

                if (part != null)
                {
                    if (part is MenuWindow)
                    {
                        if (part.Bounds.Contains((int)point.X, (int)point.Y))
                        {
                            return part;
                        }
                    }
                }

                if (parent.MenuParts[reverseIndex] is MenuWindow)
                {
                    if (parent.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                    {
                        return parent.MenuParts[reverseIndex];
                    }
                }
            }
            return null;
        }
        private IMenuParts GetChildMenuPart(IMenuParts parent, Vector2 point, List<IMenuParts> obj)
        {
            IMenuParts part;
            for (int reverseIndex = parent.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                if (obj.Contains(parent.MenuParts[reverseIndex]))
                    continue;
                part = GetChildMenuPart(parent.MenuParts[reverseIndex], point, obj);

                if (part != null)
                {
                    if (part is MenuWindow)
                    {
                        if (part.Bounds.Contains((int)point.X, (int)point.Y))
                        {
                            return part;
                        }
                    }
                }

                if (parent.MenuParts[reverseIndex] is MenuWindow)
                {
                    if (parent.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                    {
                        return parent.MenuParts[reverseIndex];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get menu part
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private IMenuParts GetMenuPart(System.Drawing.PointF point)
        {
            IMenuParts part;
            for (int reverseIndex = selectedMenu.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                part = GetChildMenuPart(selectedMenu.MenuParts[reverseIndex], point);
                if (part != null)
                    return part;
                if (selectedMenu.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                {
                    return selectedMenu.MenuParts[reverseIndex];
                }
            }
            return null;
        }
        private IMenuParts GetMenuPart(Vector2 point)
        {
            System.Drawing.PointF n = new System.Drawing.PointF(point.X, point.Y);
            return GetMenuPart(n);
        }


        private IMenuParts GetChildMenuPart(IMenuParts parent, System.Drawing.PointF point)
        {
            for (int reverseIndex = parent.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
            {
                IMenuParts part;
                part = GetChildMenuPart(parent.MenuParts[reverseIndex], point);
                if (part != null)
                    return part;
                if (parent.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                {
                    return parent.MenuParts[reverseIndex];
                }
            }
            return null;
        }

        private IMenuParts GetMenuPart(IMenuParts parent, System.Drawing.PointF point)
        {
            if (parent != null)
            {
                for (int reverseIndex = parent.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
                {
                    if (parent.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                    {
                        return parent.MenuParts[reverseIndex];
                    }
                }
            }
            else
            {
                for (int reverseIndex = SelectedMenu.MenuParts.Count - 1; reverseIndex >= 0; reverseIndex--)
                {
                    if (SelectedMenu.MenuParts[reverseIndex].Bounds.Contains((int)point.X, (int)point.Y))
                    {
                        return SelectedMenu.MenuParts[reverseIndex];
                    }
                }
            }
            return null;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedObject != null && selectedObjects.Count == 0)
            {
                FindandRemovePart(null, selectedObject);
                if (selectedObject.Parent == null)
                {
                    selectedMenu.MenuParts.Remove(selectedObject);
                    MainForm.MenuEditorHistory[this].Do(new MenuPartRemovedHist(selectedObject, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), selectedMenu));
                }
                else
                {
                    selectedObject.Parent.MenuParts.Remove(selectedObject);
                    MainForm.MenuEditorHistory[this].Do(new MenuPartRemovedHist(selectedObject, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), selectedObject.Parent, selectedMenu));
                }
                selectedObject = null;
                MainForm.menuPropertyExplorer.PopulateMenuParts(selectedMenu);
                SelectObject(selectedMenu);
            }
            else if (selectedObjects.Count > 0)
            {
                IMenuParts p;
                MenuClipboard clipboard = new MenuClipboard();
                List<IGameData> parents = new List<IGameData>();
                for (int i = 0; i < selectedObjects.Count; i++)
                {
                    FindandRemovePart(null, selectedObjects[i]);

                    if (selectedObjects[i].Parent == null)
                    {
                        parents.Add(selectedMenu);
                        selectedMenu.MenuParts.Remove(selectedObjects[i]);
                    }
                    else
                    {
                        parents.Add(SelectedObjects[i].Parent);
                        selectedObjects[i].Parent.MenuParts.Remove(selectedObjects[i]);
                    }
                }
                if (selectedObjects.Count > 0)
                {
                    MainForm.MenuEditorHistory[this].Do(new MenuPartsRemovedHist(selectedObjects, new DataMenuPartsAddDelegate(MenuPartsAdded), new DataMenuPartsRemoveDelegate(MenuPartsRemoved), parents, selectedMenu));
                }
                selectedObjects.Clear();
                selectedObject = null;
                MainForm.menuPropertyExplorer.PopulateMenuParts(selectedMenu);
                SelectObject(selectedMenu);
            }
        }

        private void FindandRemovePart(IMenuParts menuParent, IMenuParts obj)
        {
            int count;
            IMenuParts part;
            if (menuParent == null)
            {
                count = selectedMenu.MenuParts.Count;
                for (int i = 0; i < count; i++)
                {
                    part = selectedMenu.MenuParts[i];
                    FindandRemovePart(part, obj);
                    if (part == obj)
                    {
                        selectedMenu.MenuParts.RemoveAt(i);
                        i--; count--;
                    }
                }
            }
            else
            {
                count = menuParent.MenuParts.Count;
                for (int i = 0; i < count; i++)
                {
                    part = menuParent.MenuParts[i];
                    FindandRemovePart(part, obj);
                    if (part == obj)
                    {
                        menuParent.MenuParts.RemoveAt(i);
                        i--; count--;
                    }
                }
            }
        }

        private void bringForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedObject != null)
            {
                int index;
                if (selectedObject.Parent == null)
                {
                    index = selectedMenu.MenuParts.IndexOf(selectedObject);
                    if (index + 1 < selectedMenu.MenuParts.Count)
                    {
                        selectedMenu.MenuParts.Remove(selectedObject);
                        selectedMenu.MenuParts.Add(selectedObject);
                    }
                }
                else
                {
                    index = selectedObject.Parent.MenuParts.IndexOf(selectedObject);
                    if (index + 1 < selectedObject.Parent.MenuParts.Count)
                    {
                        selectedObject.Parent.MenuParts.Remove(selectedObject);
                        selectedObject.Parent.MenuParts.Add(selectedObject);
                    }
                }
            }
        }

        private void sendBackwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedObject != null)
            {
                int index;
                if (selectedObject.Parent == null)
                {
                    index = selectedMenu.MenuParts.IndexOf(selectedObject);
                    if (index - 1 > -1)
                    {
                        selectedMenu.MenuParts.Remove(selectedObject);
                        selectedMenu.MenuParts.Insert(0, selectedObject);
                    }
                }
                else
                {
                    index = selectedObject.Parent.MenuParts.IndexOf(selectedObject);
                    if (index - 1 > -1)
                    {
                        selectedObject.Parent.MenuParts.Remove(selectedObject);
                        selectedObject.Parent.MenuParts.Insert(0, selectedObject);
                    }
                }
            }
        }

        #region Tools and methods
        private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Project.MenuGrid = new Vector2(8, 8);
        }

        private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Project.MenuGrid = new Vector2(16, 16);
        }

        private void x32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Project.MenuGrid = new Vector2(32, 32);
        }

        // Jaime Addition
        private SkinData GetSkinFromID(int id)
        {
            return Global.GetData(id, GameData.Skins);
        }
        private Texture2D GetTextureFromID(int id)
        {
            Texture2D t = Loader.Texture2D(contentManager, id);
            if (t == null)
            {
                t = new Texture2D(graphicsControl.GraphicsDevice, 1, 1);
                t.Name = "BLANK";
            }
            return t;
        }

        public void SetupMessage(string text, int sizeType, Vector2 size, int positionType, int id, Vector2 pos)
        {
            List<TextPartStatic> list = new List<TextPartStatic>();
            // Get Label
            for (int index = 0; index < SelectedMenu.MenuParts.Count; index++)
            {
                list.AddRange(LoopChildPartsForMessage(SelectedMenu.MenuParts[index]));

                // Check if message
                if (SelectedMenu.MenuParts[index] is TextPartStatic && ((TextPartStatic)SelectedMenu.MenuParts[index]).IsMessage)
                    list.Add((TextPartStatic)SelectedMenu.MenuParts[index]);
            }
            // Edit text
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Text = text;

                // Edit size of window if necessary
                switch (sizeType)
                {
                    case 1: // Custom
                        if (list[i].Parent is MenuWindow)
                            list[i].Size = size;
                        break;
                    case 2: // AutoFit

                        break;
                }
            }
        }
        /// <summary>
        /// Loop
        /// </summary>
        /// <param name="iMenuParts"></param>
        /// <returns></returns>
        private List<TextPartStatic> LoopChildPartsForMessage(IMenuParts parent)
        {
            List<TextPartStatic> list = new List<TextPartStatic>();

            for (int index = 0; index < parent.MenuParts.Count; index++)
            {
                LoopChildPartsForMessage(parent.MenuParts[index]);
                // Check if message
                if (parent.MenuParts[index] is TextPartStatic && ((TextPartStatic)parent.MenuParts[index]).IsMessage)
                    list.Add((TextPartStatic)parent.MenuParts[index]);
            }

            return list;
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

        internal void ResetContentManager()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedObject != null && selectedObjects.Count == 0)
            {
                IMenuParts p = selectedObject.Parent;
                selectedObject.Parent = null;
                Global.Copy(selectedObject);
                selectedObject.Parent = p;
            }
            else if (selectedObjects.Count > 0)
            {
                IMenuParts p;
                MenuClipboard clipboard = new MenuClipboard();
                for (int i = 0; i < selectedObjects.Count; i++)
                {
                    p = selectedObjects[i].Parent;
                    if (i == 0)
                    {
                        clipboard.Positions.Add(Vector2.Zero);
                    }
                    else
                    {
                        clipboard.Positions.Add(selectedObjects[0].RealPosition - selectedObjects[i].RealPosition);
                    }
                    selectedObjects[i].Parent = null;
                    clipboard.Parts.Add(Global.Duplicate<IMenuParts>(selectedObjects[i]));
                    selectedObjects[i].Parent = p;
                }
                Global.Copy(clipboard);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedObject != null && selectedObjects.Count == 0)
            {
                IMenuParts p = selectedObject.Parent;
                selectedObject.Parent = null;
                Global.Copy(selectedObject);
                selectedObject.Parent = p;

                if (selectedObject.Parent == null)
                {
                    selectedMenu.MenuParts.Remove(selectedObject);
                    MainForm.MenuEditorHistory[this].Do(new MenuPartRemovedHist(selectedObject, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), selectedMenu));
                }
                else
                {
                    selectedObject.Parent.MenuParts.Remove(selectedObject);
                    MainForm.MenuEditorHistory[this].Do(new MenuPartRemovedHist(selectedObject, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), selectedObject.Parent, selectedMenu));
                }
                selectedObject = null;
                SelectObject(selectedMenu);
            }
            else if (selectedObjects.Count > 0)
            {
                IMenuParts p;
                MenuClipboard clipboard = new MenuClipboard();
                List<IGameData> parents = new List<IGameData>();
                List<IMenuParts> parts = new List<IMenuParts>();
                for (int i = 0; i < selectedObjects.Count; i++)
                {
                    p = selectedObjects[i].Parent;
                    if (i == 0)
                    {
                        clipboard.Positions.Add(Vector2.Zero);
                    }
                    else
                    {
                        clipboard.Positions.Add(selectedObjects[0].RealPosition - selectedObjects[i].RealPosition);
                    }
                    selectedObjects[i].Parent = null;
                    clipboard.Parts.Add(Global.Duplicate<IMenuParts>(selectedObjects[i]));
                    parts.Add(clipboard.Parts[i]);


                    selectedObjects[i].Parent = p;
                    if (selectedObjects[i].Parent == null)
                    {
                        selectedMenu.MenuParts.Remove(selectedObjects[i]);
                        parents.Add(selectedMenu);
                    }
                    else
                    {
                        parents.Add(selectedObjects[i].Parent);
                        selectedObjects[i].Parent.MenuParts.Remove(selectedObjects[i]);
                    }
                }
                if (parts.Count > 0)
                {
                    MainForm.MenuEditorHistory[this].Do(new MenuPartsRemovedHist(parts, new DataMenuPartsAddDelegate(MenuPartsAdded), new DataMenuPartsRemoveDelegate(MenuPartsRemoved), parents, selectedMenu));
                }
                Global.Copy(clipboard);
                selectedObjects.Clear();
                selectedObject = null;
                SelectObject(selectedMenu);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object obj = Global.PasteData();

            if (obj is IMenuParts)
            {
                System.Drawing.PointF p = new System.Drawing.PointF(currentMouse.X, currentMouse.Y);
                IMenuParts parent = GetMenuPart(p);
                IMenuParts part = (IMenuParts)obj;
                part.ID = GetID();
                if (parent is MenuWindow)
                {
                    parent.MenuParts.Add(part);
                    part.Position = currentMouse - parent.RealPosition;
                    // MainForm.MenuEditorHistory[this].Do(new MenuPartAddedHist(part, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), parent));
                }
                else
                {
                    selectedMenu.MenuParts.Add(part);
                    part.Position = currentMouse;
                    // MainForm.MenuEditorHistory[this].Do(new MenuPartAddedHist(part, new DataMenuPartAddDelegate(MenuPartAdded), new DataMenuPartRemoveDelegate(MenuPartRemoved), selectedMenu));
                }
                part.Parent = parent;

                MainForm.menuPropertyExplorer.PopulateMenuParts(selectedMenu);
            }
            else if (obj is MenuClipboard)
            {
                System.Drawing.PointF p = new System.Drawing.PointF(currentMouse.X, currentMouse.Y);
                IMenuParts parent = GetMenuPart(p);
                MenuClipboard clipboard = (MenuClipboard)obj;
                int index = 0;
                List<IMenuParts> parts = Global.Duplicate<List<IMenuParts>>(clipboard.Parts);
                List<IGameData> parents = new List<IGameData>();
                if (parent is MenuWindow)
                {
                    index = parent.MenuParts.Count;
                }
                else
                {
                    index = selectedMenu.MenuParts.Count;
                }
                for (int i = 0; i < clipboard.Parts.Count; i++)
                {
                    clipboard.Parts[i].ID = GetID();
                    if (parent is MenuWindow)
                    {
                        parent.MenuParts.Insert(index, clipboard.Parts[i]);

                        if (i == 0)
                        {
                            clipboard.Parts[i].Position = currentMouse - parent.RealPosition;
                        }
                        else
                        {
                            clipboard.Parts[i].Position = clipboard.Parts[0].RealPosition - clipboard.Positions[i] - parent.RealPosition;
                        }
                        parents.Add(parent);
                    }
                    else
                    {
                        selectedMenu.MenuParts.Insert(index, clipboard.Parts[i]);

                        if (i == 0)
                        {
                            clipboard.Parts[i].Position = currentMouse;
                        }
                        else
                        {
                            clipboard.Parts[i].Position = clipboard.Parts[0].RealPosition - clipboard.Positions[i];
                        }
                        parents.Add(selectedMenu);
                    }
                    parts[i].Position = clipboard.Parts[i].Position;
                    clipboard.Parts[i].Parent = parent;

                    MainForm.menuPropertyExplorer.PopulateMenuParts(selectedMenu);
                }
                if (parts.Count > 0)
                {
                    // MainForm.MenuEditorHistory[this].Do(new MenuPartsAddedHist(clipboard.Parts, new DataMenuPartsAddDelegate(MenuPartsAdded), new DataMenuPartsRemoveDelegate(MenuPartsRemoved), parents));
                }
            }
        }
        #endregion



        #region History
        public void MenuPartAdded(MenuPartAddedHist hist, IGameData data, MenuData menu)
        {
            IMenuParts part = (IMenuParts)data;

            if (hist.Parent is MenuData)
            {
                ((MenuData)hist.Parent).MenuParts.Add(part);
            }
            else if (hist.Parent is IMenuParts)
            {
                ((IMenuParts)hist.Parent).MenuParts.Add(part);
            }
            if (menu == selectedMenu)
                SelectedObject = part;
        }

        public void MenuPartRemoved(MenuPartRemovedHist hist, IGameData data, MenuData menu)
        {
            IMenuParts part = (IMenuParts)data;

            if (hist.Parent is MenuData)
            {
                ((MenuData)hist.Parent).MenuParts.Remove(part);
            }
            else if (hist.Parent is IMenuParts)
            {
                ((IMenuParts)hist.Parent).MenuParts.Remove(part);
            }
            if (menu == selectedMenu)
            {
                selectedObject = null;
                selectedObjects.Clear();
                SelectObject(menu);
            }
        }

        public void MenuPartsAdded(MenuPartsAddedHist hist, List<IMenuParts> data, MenuData menu)
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (hist.Parent[i] is MenuData)
                {
                    ((MenuData)hist.Parent[i]).MenuParts.Add(data[i]);
                    if (menu == selectedMenu)
                        selectedObjects.Add(data[i]);
                    data[i].Parent = null;
                }
                else if (hist.Parent[i] is IMenuParts)
                {
                    ((IMenuParts)hist.Parent[i]).MenuParts.Add(data[i]);
                    if (menu == selectedMenu)
                        selectedObjects.Add(data[i]);
                    data[i].Parent = ((IMenuParts)hist.Parent[i]);
                }
            }
            if (menu == selectedMenu)
                SelectedObjects = selectedObjects;
        }

        public void MenuPartsRemoved(MenuPartsRemovedHist hist, List<IMenuParts> data, MenuData menu)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (hist.Parent[i] is MenuData)
                {
                    ((MenuData)hist.Parent[i]).MenuParts.Remove(data[i]);
                }
                else if (hist.Parent[i] is IMenuParts)
                {
                    ((IMenuParts)hist.Parent[i]).MenuParts.Remove(data[i]);
                }
                data[i].Parent = null;
            }
            if (menu == selectedMenu)
            {
                selectedObjects.Clear();
                selectedObject = null;
                SelectObject(menu);
            }
        }

        public void MenuPartsPropertyChanged(MenuPartsChangePropertyHist hist, List<IMenuParts> datas, MenuData menu)
        {
            if (menu == selectedMenu)
                SelectedObjects = datas;
        }
        public void MenuPartPropertyChanged(MenuPartChangePropertyHist hist, IMenuParts datas, MenuData menu)
        {
            if (menu == selectedMenu)
            {
                selectedObjects.Clear();
                selectedObjects.Add(datas);
                SelectedObjects = selectedObjects;
            }
        }

        public void MenuPartsPositionChanged(MenuPartsPositionChangeHist hist, List<IMenuParts> datas, List<Vector2> positions, Vector2 parentPoint, MenuData menu)
        {
            IMenuParts parent = GetMenuPart(menu, parentPoint, datas);
            for (int v = 0; v < datas.Count; v++)
            {
                if (parent == null)
                {
                    if (datas[v].Parent != parent)
                    {
                        datas[v].Parent.MenuParts.Remove(datas[v]);
                        menu.MenuParts.Add(datas[v]);
                    }
                    datas[v].Position = positions[v];
                    datas[v].Parent = null;
                }
                else
                {
                    if (datas[v].Parent != parent)
                    {
                        if (datas[v].Parent == null)
                            menu.MenuParts.Remove(datas[v]);
                        else
                            datas[v].Parent.MenuParts.Remove(datas[v]);
                        parent.MenuParts.Add(datas[v]);
                    }
                    datas[v].Position = positions[v] - parent.RealPosition;
                    datas[v].Parent = parent;
                }
            }
            if (menu == selectedMenu)
            {
                selectedObject = null;
                SelectedObjects = datas;
            }
        }
        #endregion

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Redo();
        }

        private void btnSafeArea_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSetAsStart_Click(object sender, EventArgs e)
        {
            if (selectedMenu != null)
            {
                Global.Project.InitialSceneType = 0;
                Global.Project.InitialSceneID = selectedMenu.ID;
            }
        }

        private void btnShowHideBg_CheckedChanged(object sender, EventArgs e)
        {
            ShowBG = btnShowHideBg.Checked;
        }

    }
    [Serializable]
    public class MenuClipboard
    {
        public List<IMenuParts> Parts = new List<IMenuParts>();
        public List<Vector2> Positions = new List<Vector2>();
    }


}
