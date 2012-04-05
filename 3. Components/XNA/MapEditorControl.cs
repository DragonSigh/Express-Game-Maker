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
using Microsoft.Xna.Framework.Content;
using EGMGame.Library;
using EGMGame.Docking.Explorers;
using System.Runtime.InteropServices;
using EGMGame.Dialogs;

namespace EGMGame.Controls
{
    public partial class MapEditorControl : UserControl
    {
        #region Variables
        LayerSettingsDialog layerSettingsDialog;
        LayerBGDialog layerBGDialog;

        public bool showCollision
        {
            get { return mapViewer.showCollision; }
        }
        #endregion

        #region Properties

        public Scene Map
        {
            get { return mapViewer.Map; }
        }
        public TilesetData SelectedTileset
        {
            get
            {
                return (TilesetData)Global.GetDataFromIndex(MainForm.CBTileset.SelectedIndex, GameData.Tilesets);
            }
        }
        #endregion

        #region Events
        // Event variables
        public delegate void TileSelectedHandler(TileEventArgs e);
        public event TileSelectedHandler TileSelectedEvent;

        protected virtual void OnTileSelected(TileEventArgs e)
        {
            TileSelectedEvent(e);
        }
        #endregion

        BrushType lastBrush = BrushType.Brush;

        #region Constructor
        public MapEditorControl()
        {
            InitializeComponent();

            if (!MainForm.IsHigherThenXP)
            {
                toolStrip1.Renderer = new ImpactUI.ImpactToolstripRenderer();
                toolStrip2.Renderer = new ImpactUI.ImpactToolstripRenderer();
                toolStrip1.Visible = true;
                toolStrip2.Visible = true;
            }
            if (!this.DesignMode)
                mapViewer.tilesetViewer = MainForm.TilesetViewer;

            ResetSettings();
        }

        public void ResetSettings()
        {
            if (Global.Project != null)
            {
                this.btnShowGrid.Checked = Global.Project.DisplayGrid;
                this.btnSnapToGrid.Checked = Global.Project.SnapToGrid;
                this.btnDimLayer.Checked = Global.Project.DimLayers;
                this.btnEventView.Checked = Global.Project.EventView;



                if (Global.Project.EventView)
                {
                    btnEventView.Checked = true;
                }

                if (MainForm.IsHigherThenXP)
                {
                    MainForm._ribbonToggleButton["btnMapShowGrid"].BooleanValue = Global.Project.DisplayGrid;
                    MainForm._ribbonToggleButton["btnMapSnapToGrid"].BooleanValue = Global.Project.SnapToGrid;
                    MainForm._ribbonToggleButton["btnMapDimLayer"].BooleanValue = Global.Project.DimLayers;
                    MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = Global.Project.EventView;


                    switch (Global.Project.BrushType)
                    {
                        case BrushType.Brush:
                            pencilToolStripMenuItem_Click(true);
                            break;
                        case BrushType.Rectangle:
                            tsbRectangle_Click(true);
                            break;
                        case BrushType.Fill:
                            tsbFill_Click(true);
                            break;
                        case BrushType.EraserBrush:
                            eraserToolStripMenuItem_Click(true);
                            break;
                        case BrushType.EraserRect:
                            tsbEraseRect_Click(true);
                            break;
                        case BrushType.EraserFill:
                            tsbEraseFill_Click(true);
                            break;
                        case BrushType.EventSelection:
                            eventBtn_CheckedChanged(true);
                            break;
                        case BrushType.LayerSelection:
                            tsbEnableLayer_Click(true);
                            break;
                        case BrushType.CursorSingle:
                            cursorToolStripMenuItem_Click(true);
                            break;
                        case BrushType.CursorMulti:
                            eraserToolStripMenuItem_Click(true);
                            break;
                        case BrushType.CursorMultiLayer:
                            pencilToolStripMenuItem_Click(false);
                            break;
                    }

                    if (Global.Project.EventView)
                    {
                        MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = true;
                    }
                }
                else
                {
                    switch (Global.Project.BrushType)
                    {
                        case BrushType.Brush:
                            pencilToolStripMenuItem_Click(null, null);
                            break;
                        case BrushType.Rectangle:
                            tsbRectangle_Click(null, null);
                            break;
                        case BrushType.Fill:
                            tsbFill_Click(null, null);
                            break;
                        case BrushType.CursorSingle:
                            btnSingleArrow_Click(null, null);
                            break;
                        case BrushType.CursorMulti:
                            btnSelect_Click(null, null);
                            break;
                        case BrushType.CursorMultiLayer:
                            btnLayeredSelect_Click(null, null);
                            break;
                        case BrushType.EraserBrush:
                            eraserToolStripMenuItem_Click(null, null);
                            break;
                        case BrushType.EraserRect:
                            btnEraserRect_Click(null, null);
                            break;
                        case BrushType.EraserFill:
                            btnEraserFill_Click(null, null);
                            break;
                        case BrushType.EventSelection:
                            btnEventView_Click(null, null);
                            break;
                        case BrushType.LayerSelection:
                            btnLayerSelect_Click(null, null);
                            break;
                    }
                }
            }
            lastBrush = BrushType.Brush;
        }
        private void SelectBrush(BrushType brush)
        {
            if ((brush == BrushType.Fill || brush == BrushType.EraserFill) && !btnSnapToGrid.Checked)
            {
                brush = BrushType.Brush;
            }
            Global.Project.BrushType = brush;
            if (MainForm.IsHigherThenXP)
            {
                switch (Global.Project.BrushType)
                {
                    case BrushType.Brush:
                        pencilToolStripMenuItem_Click(true);
                        break;
                    case BrushType.Rectangle:
                        tsbRectangle_Click(true);
                        break;
                    case BrushType.Fill:
                        tsbFill_Click(true);
                        break;
                    case BrushType.EraserBrush:
                        eraserToolStripMenuItem_Click(true);
                        break;
                    case BrushType.EraserRect:
                        tsbEraseRect_Click(true);
                        break;
                    case BrushType.EraserFill:
                        tsbEraseFill_Click(true);
                        break;
                    case BrushType.EventSelection:
                        eventBtn_CheckedChanged(true);
                        break;
                    case BrushType.LayerSelection:
                        tsbEnableLayer_Click(true);
                        break;
                    case BrushType.CursorSingle:
                        cursorToolStripMenuItem_Click(true);
                        break;
                    case BrushType.CursorMulti:
                        eraserToolStripMenuItem_Click(true);
                        break;
                    case BrushType.CursorMultiLayer:
                        pencilToolStripMenuItem_Click(false);
                        break;
                }
            }
            else
            {
                switch (Global.Project.BrushType)
                {
                    case BrushType.Brush:
                        pencilToolStripMenuItem_Click(null, null);
                        break;
                    case BrushType.Rectangle:
                        tsbRectangle_Click(null, null);
                        break;
                    case BrushType.Fill:
                        tsbFill_Click(null, null);
                        break;
                    case BrushType.CursorSingle:
                        btnSingleArrow_Click(null, null);
                        break;
                    case BrushType.CursorMulti:
                        btnSelect_Click(null, null);
                        break;
                    case BrushType.CursorMultiLayer:
                        btnLayeredSelect_Click(null, null);
                        break;
                    case BrushType.EraserBrush:
                        eraserToolStripMenuItem_Click(null, null);
                        break;
                    case BrushType.EraserRect:
                        btnEraserRect_Click(null, null);
                        break;
                    case BrushType.EraserFill:
                        btnEraserFill_Click(null, null);
                        break;
                    case BrushType.EventSelection:
                        btnEventView_Click(null, null);
                        break;
                    case BrushType.LayerSelection:
                        btnLayerSelect_Click(null, null);
                        break;
                }
            }

        }

        internal void pencilToolStripMenuItem_Click(bool p)
        {

            if (mapViewer.brushType != BrushType.Brush)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.paint_brush, 20, 20, 0, 20);

                mapViewer.brushType =
                Global.Project.BrushType = BrushType.Brush;

                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;

                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = true;
                ClearSelected(); mapViewer.SelectedTile = null;

            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }


        internal void tsbRectangle_Click(bool p)
        {

            if (mapViewer.brushType != BrushType.Rectangle)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.brushType =
               Global.Project.BrushType = BrushType.Rectangle;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = true;


                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.paint_brush, 20, 20, 0, 20);
                ClearSelected(); mapViewer.SelectedTile = null;
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void tsbFill_Click(bool p)
        {

            if (mapViewer.brushType != BrushType.Fill)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.brushType =
                Global.Project.BrushType = BrushType.Fill;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = true;
                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.paint_brush, 20, 20, 0, 20);
                ClearSelected(); mapViewer.SelectedTile = null;
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void eraserToolStripMenuItem_Click(bool p)
        {
            if (mapViewer.brushType != BrushType.EraserBrush)
            {
                lastBrush = mapViewer.brushType;

                mapViewer.brushType =
                Global.Project.BrushType = BrushType.EraserBrush;

                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;

                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = true;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20);
                ClearSelected(); mapViewer.SelectedTile = null;
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }


        internal void cursorToolStripMenuItem_Click(bool p)
        {
            if (p)
            {
                lastBrush = mapViewer.brushType;
                Global.Project.BrushType = mapViewer.brushType = BrushType.CursorSingle;
                mapViewer.graphicsControl.Cursor = Cursors.Arrow;
                // Disable Every other tool
                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;


                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = true;
                ClearSelected(); mapViewer.SelectedTile = null;
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
            //if (p)
            //{
            //    ClearSelected();
            //    mapViewer.selectType = SelectType.Single;
            //    Global.Project.PaintType = mapViewer.paintType = PaintType.Cursor;
            //    paintBtn.Image = global::EGMGame.Properties.Resources.cursor;

            //    //MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
            //    MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = true;
            //    MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
            //    MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;

            //    mapViewer.graphicsControl.Cursor = Cursors.Arrow;

            //}
            //else
            //{
            //    eraserToolStripMenuItem_Click(MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue);
            //}
        }

        internal void btnLayeredSelect_Click(bool p)
        {
            if (p)
            {
                lastBrush = mapViewer.brushType;
                Global.Project.BrushType = mapViewer.brushType = BrushType.CursorMultiLayer;


                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;

                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = true;

                mapViewer.graphicsControl.Cursor = Cursors.Arrow;
                ClearSelected();

            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }


        internal void btnSelect_Click(bool p)
        {
            if (p)
            {
                lastBrush = mapViewer.brushType;
                Global.Project.BrushType = mapViewer.brushType = BrushType.CursorMulti;
                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;

                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = true;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;

                mapViewer.graphicsControl.Cursor = Cursors.Arrow;
                ClearSelected();

            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void PopulateTilesets()
        {
            int oldIndex = Global.Project.SelectedTileset;
            MainForm.CBTileset.Items.Clear();
            if (Map != null)
            {
                MainForm.TilesetViewer.SelectedTileset = null;
                MainForm.CBTileset.Enabled = true;
                if (MainForm.TilesetViewer.TilesetView)
                {
                    foreach (TilesetData data in GameData.Tilesets.Values)
                    {
                        MainForm.CBTileset.Items.Add(data.Name);
                    }
                }
                else
                {
                    foreach (NodeCategory category in Global.Project.Categories[typeof(TilesetData).ToString()])
                    {
                        MainForm.CBTileset.Items.Add(category.Name);
                    }
                }
                if (oldIndex < 0 && MainForm.CBTileset.Items.Count > 0)
                    oldIndex = 0;
                if (oldIndex < MainForm.CBTileset.Items.Count)
                {
                    MainForm.CBTileset.SelectedIndex = oldIndex;
                }
                else
                {
                    MainForm.CBTileset.SelectedIndex = (MainForm.CBTileset.Items.Count > 0 ? 0 : -1);
                }
            }
            else
            {
                MainForm.CBTileset.Enabled = false;
                MainForm.TilesetViewer.SelectedTileset = null;
            }
        }
        #endregion

        #region PaintType Controls
        internal void pencilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBrush.Checked = true;
            if (mapViewer.brushType != BrushType.Brush)
            {
                lastBrush = mapViewer.brushType;

                mapViewer.brushType =
                Global.Project.BrushType = BrushType.Brush;

                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.paint_brush, 20, 20, 0, 20);
                ClearSelected();
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void tsbRectangle_Click(object sender, EventArgs e)
        {
            btnRect.Checked = true;
            if (mapViewer.brushType != BrushType.Rectangle)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.brushType =
                Global.Project.BrushType = BrushType.Rectangle;
                //lineBtn.Checked = false;
                btnFill.Checked = false;
                btnBrush.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        public void tsbFill_Click(object sender, EventArgs e)
        {
            btnFill.Checked = true;
            if (mapViewer.brushType != BrushType.Fill)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.brushType =
                Global.Project.BrushType = BrushType.Fill;

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.paint_can, 20, 20, 0, 20);
                ClearSelected();

            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEraser.Checked = true;
            if (mapViewer.brushType != BrushType.EraserBrush)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.EraserBrush;

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20);
                ClearSelected();
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        private void btnEraserRect_Click(object sender, EventArgs e)
        {
            btnEraserRect.Checked = true;
            if (mapViewer.brushType != BrushType.EraserRect)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.EraserRect;
                ClearSelected();

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        private void btnEraserFill_Click(object sender, EventArgs e)
        {
            btnEraserFill.Checked = true;
            if (mapViewer.brushType != BrushType.EraserFill)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.EraserFill;
                ClearSelected();

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        private void btnSingleArrow_Click(object sender, EventArgs e)
        {
            btnCursor.Checked = true;
            if (BrushType.CursorSingle != mapViewer.brushType)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.CursorSingle;
                ClearSelected();

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.cursor, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        public void btnSelect_Click(object sender, EventArgs e)
        {
            btnSelect.Checked = true;
            if (mapViewer.brushType != BrushType.CursorMulti)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.CursorMulti;
                ClearSelected();

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.cursor, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        public void btnLayeredSelect_Click(object sender, EventArgs e)
        {
            btnSelectLayered.Checked = true;
            if (mapViewer.brushType != BrushType.CursorMultiLayer)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.CursorMultiLayer;
                ClearSelected();

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnEventView.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.cursor, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        private void btnEventView_Click(object sender, EventArgs e)
        {
            btnEventView.Checked = true;
            if (mapViewer.brushType != BrushType.EventSelection)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.EventSelection;
                ClearSelected();

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnLayerSelect.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.cursor, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        private void btnLayerSelect_Click(object sender, EventArgs e)
        {
            btnLayerSelect.Checked = true;
            if (mapViewer.brushType != BrushType.LayerSelection)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.SelectedTile = null;
                Global.Project.BrushType = mapViewer.brushType = BrushType.LayerSelection;
                ClearSelected();

                btnBrush.Checked = false;
                btnRect.Checked = false;
                btnFill.Checked = false;
                btnEraser.Checked = false;
                btnEraserRect.Checked = false;
                btnEraserFill.Checked = false;
                btnCursor.Checked = false;
                btnSelect.Checked = false;
                btnSelectLayered.Checked = false;
                btnEventView.Checked = false;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.cursor, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }
        #endregion

        internal void cbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {

            Global.Project.SelectedTileset = MainForm.tilesExplorer.cbTileset.SelectedIndex;
            if (MainForm.TilesetViewer.TilesetView && SelectedTileset != null)
            {
                MainForm.TilesetViewer.SelectedTileset = SelectedTileset;
                mapViewer.SelectedTileset = SelectedTileset;
            }
            else if (!MainForm.TilesetViewer.TilesetView)
            {
                MainForm.TilesetViewer.SelectedCategory = MainForm.tilesExplorer.cbTileset.SelectedIndex;
            }
            else
            {
                MainForm.TilesetViewer.SelectedTileset = null;
            }
        }

        internal void tsbSwapLayerUp_Click(object sender, EventArgs e)
        {
            if (MainForm.layersExplorer.layersList.SelectedIndex < MainForm.layersExplorer.layersList.Count - 1)
                MainForm.layersExplorer.layersList.SelectedIndex = MainForm.layersExplorer.layersList.SelectedIndex + 1;
        }

        internal void tsbSwapLayerDown_Click(object sender, EventArgs e)
        {
            if (MainForm.layersExplorer.layersList.SelectedIndex > 0)
                MainForm.layersExplorer.layersList.SelectedIndex = MainForm.layersExplorer.layersList.SelectedIndex - 1;
        }

        internal void ClearSelected()
        {
            mapViewer.ClearSelected();
            if (mapViewer.brushType != BrushType.CursorSingle)
                mapViewer.tileSettings.Hide();
            if (!mapViewer.showCollision || !mapViewer.physicsBtn.Checked)
                mapViewer.collisionSettings.Hide();
            if (mapViewer.brushType != BrushType.EventSelection)
                mapViewer.eventSettings.Hide();
            if (mapViewer.brushType != BrushType.LayerSelection)
                mapViewer.layerSettings.Hide();
        }

        internal void SetupScene(MapData scene)
        {
            mapViewer.SetupScene(scene);
            if (scene != null)
                PopulateTilesets();
        }

        internal void DeleteMap(MapData data)
        {
            if (mapViewer.Map != null && mapViewer.Map.Data == data)
            {
                mapViewer.Map = null;
                mapViewer.CheckUI();
                PopulateTilesets();
                mapViewer.UpdateTiles();
                mapViewer.SetupLayers();
            }
        }

        private void newMapBtn_Click(object sender, EventArgs e)
        {
            MainForm.Instance.addNewMapToolStripMenuItem_Click(null, null);
        }

        internal void SelectLayer(LayerData s)
        {
            lblLayer.Text = s.Name;
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {

        }

        public void eventBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (btnEventView.Checked)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.brushType =
                Global.Project.BrushType = BrushType.EventSelection;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb;
                //cursorToolStripMenuItem_Click(null, null);
                mapViewer.graphicsControl.Cursor = Cursors.Arrow;

                ClearSelected();
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        public void eventBtn_CheckedChanged(bool Checked)
        {
            if (Checked)
            {
                lastBrush = mapViewer.brushType;
                mapViewer.brushType =
                Global.Project.BrushType = BrushType.EventSelection;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb;
                mapViewer.graphicsControl.Cursor = Cursors.Arrow;

                ClearSelected();
                // Disable Every other tool
                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = true;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void tsbEraseRect_Click(bool p)
        {
            if (mapViewer.brushType != BrushType.EraserRect)
            {
                lastBrush = mapViewer.brushType;

                mapViewer.brushType =
                Global.Project.BrushType = BrushType.EraserRect;
                ClearSelected(); mapViewer.SelectedTile = null;

                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;

                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = true;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void tsbEraseFill_Click(bool p)
        {
            if (mapViewer.brushType != BrushType.EraserFill)
            {
                lastBrush = mapViewer.brushType;

                mapViewer.brushType =
                Global.Project.BrushType = BrushType.EraserFill;
                ClearSelected(); mapViewer.SelectedTile = null;

                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;

                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = true;

                mapViewer.graphicsControl.Cursor = CreateCursor(Properties.Resources.eraser, 20, 20, 0, 20);
            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        internal void tsbEnableLayer_Click(bool Checked)
        {
            if (Checked)
            {
                lastBrush = mapViewer.brushType;
                Global.Project.BrushType = mapViewer.brushType = BrushType.LayerSelection;
                mapViewer.graphicsControl.Cursor = Cursors.Arrow;
                MainForm._ribbonToggleButton["btnMapEnableLayer"].BooleanValue = true;
                // Disable Every other tool
                MainForm._ribbonToggleButton["btnMapEvents"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionRectAll"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnSelectionPointer"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseRect"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraseFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawPencil"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawRectangle"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawFill"].BooleanValue = false;
                MainForm._ribbonToggleButton["btnDrawEraser"].BooleanValue = false;
                btnEventView.Image = global::EGMGame.Properties.Resources.light_bulb_off;
                ClearSelected();

            }
            else if (lastBrush != mapViewer.brushType)
            {
                BrushType b = mapViewer.brushType;
                SelectBrush(lastBrush);
                lastBrush = b;
            }
        }

        private void mapViewer_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void mapViewer_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        #region Cursor Helpers
        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        /// <summary>
        /// Create a resized cursor from a bitmap, with the hot-spot as specified.
        /// </summary>
        public System.Windows.Forms.Cursor CreateCursor(System.Drawing.Bitmap bmp, int width, int height, int xHotSpot, int yHotSpot)
        {
            try
            {
                IntPtr ptr = (ResizeImage((System.Drawing.Image)bmp, width, height)).GetHicon();
                IconInfo tmp = new IconInfo();
                GetIconInfo(ptr, ref tmp);
                tmp.xHotspot = xHotSpot;
                tmp.yHotspot = yHotSpot;
                tmp.fIcon = false;
                ptr = CreateIconIndirect(ref tmp);
                return new Cursor(ptr);
            }
            catch
            {
                return Cursor.Current;
            }
            return Cursor.Current;
        }

        private System.Drawing.Bitmap ResizeImage(System.Drawing.Image img, int width, int height)
        {
            System.Drawing.Bitmap b = new System.Drawing.Bitmap(width, height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage((System.Drawing.Image)b);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return b;
        }
        #endregion

        #region Map Settings
        public void btnBG_Click(object sender, EventArgs e)
        {
            if (Map != null && mapViewer.SelectedLayer != null)
            {
                LayerBGDialog layerBGDialog = new LayerBGDialog();
                layerBGDialog.Setup(mapViewer.SelectedLayer);
                layerBGDialog.Location = new System.Drawing.Point(toolStrip1.Location.X + btnBG.Bounds.X, toolStrip1.Location.Y + btnBG.Bounds.Y);
                layerBGDialog.ShowDialog(this);
            }
        }

        public void btnMapSize_Click(object sender, EventArgs e)
        {
            if (Map != null)
            {
                MapResizeDialog dialog = new MapResizeDialog();
                //dialog.widthBox.Value = (decimal)Map.Data.Size.X;
                //dialog.heightBox.Value = (decimal)Map.Data.Size.Y;
                dialog.Location = new System.Drawing.Point(toolStrip1.Location.X + btnMapSize.Bounds.X, toolStrip1.Location.Y + btnMapSize.Bounds.Y);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Map.Data.Size = new Vector2((float)dialog.widthBox.Value, (float)dialog.heightBox.Value);
                    List<TileData> toRemove = new List<TileData>();
                    System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, Map.Data.Size.X, Map.Data.Size.Y);
                    List<EventData> eToRemove = new List<EventData>();
                    foreach (LayerData layer in Map.Data.Layers)
                    {
                        toRemove.Clear();
                        // Tiles
                        //layer.Tiles.CreateCollection(Map.Data.Size, layer.Tiles.DisplayRect * 2);
                        // Events
                        foreach (EventData ev in layer.Events.Values)
                        {
                            if (!rect.IntersectsWith(new System.Drawing.RectangleF(ev.Position.X, ev.Position.Y, 1, 1)))
                            {
                                eToRemove.Add(ev);
                            }
                        }
                        foreach (EventData er in eToRemove)
                        {
                            layer.Events.Remove(er.ID);
                        }
                    }
                    mapViewer.UpdateTiles();
                }
            }
        }

        public void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapGridDialog dialog = new MapGridDialog();
            dialog.widthBox.Maximum = (decimal)Map.Data.Size.X;
            dialog.heightBox.Maximum = (decimal)Map.Data.Size.Y;
            // Values
            dialog.widthBox.Value = (decimal)Map.Data.Grid.X;
            dialog.heightBox.Value = (decimal)Map.Data.Grid.Y;

            if (DialogResult.OK == dialog.ShowDialog(this))
            {
                Map.Data.Grid = new Vector2((int)dialog.widthBox.Value, (int)dialog.heightBox.Value);
                mapViewer.GridWidth = (int)Map.Data.Grid.X;
                mapViewer.GridHeight = (int)Map.Data.Grid.Y;
            }
        }

        public void showGridToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            mapViewer.DisplayGrid = this.btnShowGrid.Checked;
        }

        public void snapToGridToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            mapViewer.SnapToGrid = btnSnapToGrid.Checked;
            if (btnSnapToGrid.Checked)
            {
                //rectangleToolStripMenuItem.Enabled = true;
                //lineToolStripMenuItem.Enabled = true;
                //fillToolStripMenuItem.Enabled = true;
                btnRect.Enabled = btnRect.Visible = true;
                //lineBtn.Enabled = //lineBtn.Visible = true;
                btnFill.Enabled = btnFill.Visible = btnEraserFill.Enabled = btnEraserFill.Visible = true;

                if (MainForm.IsHigherThenXP) MainForm._ribbonToggleButton["btnDrawFill"].Enabled = MainForm._ribbonToggleButton["btnDrawEraseFill"].Enabled = true;
            }
            else
            {
                //rectangleToolStripMenuItem.Enabled = false;
                //lineToolStripMenuItem.Enabled = false;
                //fillToolStripMenuItem.Enabled = false;
                //lineBtn.Enabled = //lineBtn.Visible = false;
                btnFill.Enabled = btnFill.Visible = btnEraserFill.Enabled = btnEraserFill.Visible = false;
                if (MainForm.IsHigherThenXP) MainForm._ribbonToggleButton["btnDrawFill"].Enabled = MainForm._ribbonToggleButton["btnDrawEraseFill"].Enabled = false;
            }
        }

        public void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Map != null && mapViewer.SelectedLayer != null)
            {

                layerBGDialog = new LayerBGDialog();
                layerBGDialog.Setup(mapViewer.SelectedLayer);

                layerBGDialog.ShowDialog();
                layerBGDialog.Location = new System.Drawing.Point(toolStrip1.Location.X + btnBG.Bounds.X, toolStrip1.Location.Y + btnBG.Bounds.Y);
            }
        }

        public void layersettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Map != null && mapViewer.SelectedLayer != null)
            {

                ColorPickerDialog dialog = new ColorPickerDialog();
                dialog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                dialog.colorPickerCtrl.SelectedColor = System.Drawing.Color.FromArgb(mapViewer.SelectedLayer.Tint.Alpha, mapViewer.SelectedLayer.Tint.Red, mapViewer.SelectedLayer.Tint.Green, mapViewer.SelectedLayer.Tint.Blue);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ColorChanged += new ColorPickerDialog.ColorChangedEvent(dialog_ColorChanged);
                ColorRGBA oldC = mapViewer.SelectedLayer.Tint;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.Drawing.Color c = dialog.colorPickerCtrl.SelectedColor;

                    mapViewer.SelectedLayer.Tint = new ColorRGBA(c.R, c.G, c.B, c.A);
                }
                else
                    mapViewer.SelectedLayer.Tint = oldC;

                //if (layerSettingsDialog == null || layerSettingsDialog.IsDisposed)
                //    layerSettingsDialog = new LayerSettingsDialog();
                //layerSettingsDialog.StartPosition = FormStartPosition.CenterScreen;
                //layerSettingsDialog.Setup(mapViewer.SelectedLayer);
                ////layerSettingsDialog.Location = new System.Drawing.Point(toolStrip1.Location.X + settingsToolStripMenuItem.Bounds.X, toolStrip1.Location.Y + settingsToolStripMenuItem.Bounds.Y);
                //if (!layerSettingsDialog.Visible)
                //    layerSettingsDialog.Show(this);
                //layerSettingsDialog.Location = new System.Drawing.Point(toolStrip1.Location.X + settingsToolStripMenuItem.Bounds.X, toolStrip1.Location.Y + settingsToolStripMenuItem.Bounds.Y);
            }
        }

        void dialog_ColorChanged(object sender, System.Drawing.Color c)
        {
            mapViewer.SelectedLayer.Tint = new ColorRGBA(c.R, c.G, c.B, c.A);
        }

        public void btnDimLayer_Click(object sender, EventArgs e)
        {
            Global.Project.DimLayers = btnDimLayer.Checked;
        }
        #endregion


        public void gravityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapViewer.Map != null && mapViewer.Map.Data != null)
            {
                EGMGame.Dialogs.MapGravityDialog dialog = new EGMGame.Dialogs.MapGravityDialog();
                dialog.ShowDialog();
            }
        }

        internal void ResetProject()
        {
            mapViewer.ResetContentManager();
            if (Global.Project != null)
            {
                this.btnShowGrid.Checked = Global.Project.DisplayGrid;
                this.btnSnapToGrid.Checked = Global.Project.SnapToGrid;
                this.btnDimLayer.Checked = Global.Project.DimLayers;
                this.btnEventView.Checked = Global.Project.EventView;
            }
        }

        public void btnShowCollision_CheckedChanged(object sender, EventArgs e)
        {
            mapViewer.showCollision = btnShowCollision.Checked;
        }

        public void effectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainForm.SelectedMap != null)
            {
                MapEffectsDialog dialog = new MapEffectsDialog();
                dialog.Setup(MainForm.SelectedMap);
                dialog.ShowDialog();
            }
        }

        internal void snapToGridToolStripMenuItem_CheckedChanged(bool p)
        {
            mapViewer.SnapToGrid = p;
            if (p)
            {
                //rectangleToolStripMenuItem.Enabled = true;
                //lineToolStripMenuItem.Enabled = true;
                //fillToolStripMenuItem.Enabled = true;
                btnRect.Enabled = btnRect.Visible = true;
                //lineBtn.Enabled = //lineBtn.Visible = true;
                btnFill.Enabled = btnFill.Visible = btnEraserFill.Enabled = btnEraserFill.Visible = true;
                if (MainForm.IsHigherThenXP) MainForm._ribbonToggleButton["btnDrawFill"].Enabled = MainForm._ribbonToggleButton["btnDrawEraseFill"].Enabled = true;
            }
            else
            {
                //rectangleToolStripMenuItem.Enabled = false;
                //lineToolStripMenuItem.Enabled = false;
                //fillToolStripMenuItem.Enabled = false;
                //lineBtn.Enabled = //lineBtn.Visible = false;
                btnFill.Enabled = btnFill.Visible = btnEraserFill.Enabled = btnEraserFill.Visible = false;
                if (MainForm.IsHigherThenXP) MainForm._ribbonToggleButton["btnDrawFill"].Enabled = MainForm._ribbonToggleButton["btnDrawEraseFill"].Enabled = false;
            }
        }

        internal void showGridToolStripMenuItem_CheckedChanged(bool p)
        {
            mapViewer.DisplayGrid = p;
        }

        internal void btnDimLayer_Click(bool p)
        {
            Global.Project.DimLayers = p;
        }


        internal void btnShowCollision_CheckedChanged(bool p)
        {
            mapViewer.showCollision = p;
        }


        internal void Unload()
        {
            mapViewer.ResetContentManager();
        }

    }

}
