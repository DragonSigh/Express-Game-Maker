namespace EGMGame.Controls
{
    partial class MapEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorControl));
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newMapBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMapSize = new System.Windows.Forms.ToolStripButton();
            this.btnGridSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGravity = new System.Windows.Forms.ToolStripButton();
            this.btnEffect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDimLayer = new System.Windows.Forms.ToolStripButton();
            this.btnShowGrid = new System.Windows.Forms.ToolStripButton();
            this.btnSnapToGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSwapLayerDown = new System.Windows.Forms.ToolStripButton();
            this.tsbSwapLayerUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblLayer = new System.Windows.Forms.ToolStripLabel();
            this.btnBG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowCollision = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnBrush = new System.Windows.Forms.ToolStripButton();
            this.btnRect = new System.Windows.Forms.ToolStripButton();
            this.btnFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.btnEraserRect = new System.Windows.Forms.ToolStripButton();
            this.btnEraserFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCursor = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnSelectLayered = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEventView = new System.Windows.Forms.ToolStripButton();
            this.btnLayerSelect = new System.Windows.Forms.ToolStripButton();
            this.mapViewer = new EGMGame.Controls.MapViewer();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapBtn,
            this.toolStripSeparator9,
            this.btnMapSize,
            this.btnGridSize,
            this.toolStripSeparator13,
            this.btnGravity,
            this.btnEffect,
            this.toolStripSeparator12,
            this.btnDimLayer,
            this.btnShowGrid,
            this.btnSnapToGrid,
            this.toolStripSeparator11,
            this.tsbSwapLayerDown,
            this.tsbSwapLayerUp,
            this.toolStripSeparator1,
            this.lblLayer,
            this.btnBG,
            this.toolStripMenuItem2,
            this.toolStripSeparator7,
            this.btnShowCollision});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1234, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            this.toolStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // newMapBtn
            // 
            this.newMapBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newMapBtn.Image = global::EGMGame.Properties.Resources.map__plus;
            this.newMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newMapBtn.Name = "newMapBtn";
            this.newMapBtn.Size = new System.Drawing.Size(23, 22);
            this.newMapBtn.Text = "New Map";
            this.newMapBtn.ToolTipText = "New Map";
            this.newMapBtn.Click += new System.EventHandler(this.newMapBtn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMapSize
            // 
            this.btnMapSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMapSize.Image = global::EGMGame.Properties.Resources.selection;
            this.btnMapSize.Name = "btnMapSize";
            this.btnMapSize.Size = new System.Drawing.Size(23, 22);
            this.btnMapSize.Text = "Map Size";
            this.btnMapSize.Click += new System.EventHandler(this.btnMapSize_Click);
            // 
            // btnGridSize
            // 
            this.btnGridSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGridSize.Image = global::EGMGame.Properties.Resources.ruler;
            this.btnGridSize.Name = "btnGridSize";
            this.btnGridSize.Size = new System.Drawing.Size(23, 22);
            this.btnGridSize.Text = "Grid Size";
            this.btnGridSize.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGravity
            // 
            this.btnGravity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGravity.Image = global::EGMGame.Properties.Resources.balance;
            this.btnGravity.Name = "btnGravity";
            this.btnGravity.Size = new System.Drawing.Size(23, 22);
            this.btnGravity.Text = "Gravity";
            this.btnGravity.Click += new System.EventHandler(this.gravityToolStripMenuItem_Click);
            // 
            // btnEffect
            // 
            this.btnEffect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEffect.Image = global::EGMGame.Properties.Resources.image_empty;
            this.btnEffect.Name = "btnEffect";
            this.btnEffect.Size = new System.Drawing.Size(23, 22);
            this.btnEffect.Text = "Effects";
            this.btnEffect.Click += new System.EventHandler(this.effectsToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDimLayer
            // 
            this.btnDimLayer.Checked = true;
            this.btnDimLayer.CheckOnClick = true;
            this.btnDimLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnDimLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDimLayer.Image = global::EGMGame.Properties.Resources.layer_shade;
            this.btnDimLayer.Name = "btnDimLayer";
            this.btnDimLayer.Size = new System.Drawing.Size(23, 22);
            this.btnDimLayer.Text = "Dim Layers";
            this.btnDimLayer.CheckedChanged += new System.EventHandler(this.btnDimLayer_Click);
            // 
            // btnShowGrid
            // 
            this.btnShowGrid.Checked = true;
            this.btnShowGrid.CheckOnClick = true;
            this.btnShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowGrid.Image = global::EGMGame.Properties.Resources.grid;
            this.btnShowGrid.Name = "btnShowGrid";
            this.btnShowGrid.Size = new System.Drawing.Size(23, 22);
            this.btnShowGrid.Text = "Display Grid";
            this.btnShowGrid.CheckedChanged += new System.EventHandler(this.showGridToolStripMenuItem_CheckedChanged);
            // 
            // btnSnapToGrid
            // 
            this.btnSnapToGrid.Checked = true;
            this.btnSnapToGrid.CheckOnClick = true;
            this.btnSnapToGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnSnapToGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSnapToGrid.Image = global::EGMGame.Properties.Resources.grid_snap;
            this.btnSnapToGrid.Name = "btnSnapToGrid";
            this.btnSnapToGrid.Size = new System.Drawing.Size(23, 22);
            this.btnSnapToGrid.Text = "Snap To Grid";
            this.btnSnapToGrid.CheckedChanged += new System.EventHandler(this.snapToGridToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSwapLayerDown
            // 
            this.tsbSwapLayerDown.BackColor = System.Drawing.SystemColors.Control;
            this.tsbSwapLayerDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSwapLayerDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbSwapLayerDown.Image")));
            this.tsbSwapLayerDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwapLayerDown.Name = "tsbSwapLayerDown";
            this.tsbSwapLayerDown.Size = new System.Drawing.Size(23, 22);
            this.tsbSwapLayerDown.Text = "Layer Down";
            this.tsbSwapLayerDown.ToolTipText = "Layer Down (X)";
            this.tsbSwapLayerDown.Click += new System.EventHandler(this.tsbSwapLayerDown_Click);
            // 
            // tsbSwapLayerUp
            // 
            this.tsbSwapLayerUp.BackColor = System.Drawing.SystemColors.Control;
            this.tsbSwapLayerUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSwapLayerUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbSwapLayerUp.Image")));
            this.tsbSwapLayerUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwapLayerUp.Name = "tsbSwapLayerUp";
            this.tsbSwapLayerUp.Size = new System.Drawing.Size(23, 22);
            this.tsbSwapLayerUp.Text = "Layer Up";
            this.tsbSwapLayerUp.ToolTipText = "Layer Up (Z)";
            this.tsbSwapLayerUp.Click += new System.EventHandler(this.tsbSwapLayerUp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblLayer
            // 
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(35, 22);
            this.lblLayer.Text = "Layer";
            // 
            // btnBG
            // 
            this.btnBG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBG.Image = global::EGMGame.Properties.Resources.transform_layer;
            this.btnBG.Name = "btnBG";
            this.btnBG.Size = new System.Drawing.Size(28, 25);
            this.btnBG.Text = "Background";
            this.btnBG.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem2.Image = global::EGMGame.Properties.Resources.color_wheel;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(28, 25);
            this.toolStripMenuItem2.Text = "Settings";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.layersettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnShowCollision
            // 
            this.btnShowCollision.CheckOnClick = true;
            this.btnShowCollision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowCollision.Image = global::EGMGame.Properties.Resources.layer_shape_polygon;
            this.btnShowCollision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowCollision.Name = "btnShowCollision";
            this.btnShowCollision.Size = new System.Drawing.Size(23, 22);
            this.btnShowCollision.Text = "Show Collision";
            this.btnShowCollision.CheckedChanged += new System.EventHandler(this.btnShowCollision_CheckedChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBrush,
            this.btnRect,
            this.btnFill,
            this.toolStripSeparator3,
            this.btnEraser,
            this.btnEraserRect,
            this.btnEraserFill,
            this.toolStripSeparator8,
            this.btnCursor,
            this.btnSelect,
            this.btnSelectLayered,
            this.toolStripSeparator6,
            this.btnEventView,
            this.btnLayerSelect});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1234, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Visible = false;
            // 
            // btnBrush
            // 
            this.btnBrush.Checked = true;
            this.btnBrush.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBrush.Image = global::EGMGame.Properties.Resources.paint_brush;
            this.btnBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new System.Drawing.Size(23, 22);
            this.btnBrush.Text = "Draw";
            this.btnBrush.Click += new System.EventHandler(this.pencilToolStripMenuItem_Click);
            // 
            // btnRect
            // 
            this.btnRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRect.Image = ((System.Drawing.Image)(resources.GetObject("btnRect.Image")));
            this.btnRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(23, 22);
            this.btnRect.Text = "Rectangle";
            this.btnRect.ToolTipText = "Rectangle (R)";
            this.btnRect.Click += new System.EventHandler(this.tsbRectangle_Click);
            // 
            // btnFill
            // 
            this.btnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFill.Image = global::EGMGame.Properties.Resources.paint_can;
            this.btnFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(23, 22);
            this.btnFill.Text = "Fill";
            this.btnFill.Click += new System.EventHandler(this.tsbFill_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEraser
            // 
            this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraser.Image = global::EGMGame.Properties.Resources.eraser;
            this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(23, 22);
            this.btnEraser.Text = "Erase";
            this.btnEraser.Click += new System.EventHandler(this.eraserToolStripMenuItem_Click);
            // 
            // btnEraserRect
            // 
            this.btnEraserRect.CheckOnClick = true;
            this.btnEraserRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraserRect.Image = global::EGMGame.Properties.Resources.layer_select_erase;
            this.btnEraserRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraserRect.Name = "btnEraserRect";
            this.btnEraserRect.Size = new System.Drawing.Size(23, 22);
            this.btnEraserRect.Text = "toolStripButton1";
            this.btnEraserRect.Click += new System.EventHandler(this.btnEraserRect_Click);
            // 
            // btnEraserFill
            // 
            this.btnEraserFill.CheckOnClick = true;
            this.btnEraserFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraserFill.Image = global::EGMGame.Properties.Resources.erase_fill;
            this.btnEraserFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraserFill.Name = "btnEraserFill";
            this.btnEraserFill.Size = new System.Drawing.Size(23, 22);
            this.btnEraserFill.Text = "toolStripButton2";
            this.btnEraserFill.Click += new System.EventHandler(this.btnEraserFill_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCursor
            // 
            this.btnCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCursor.Image = global::EGMGame.Properties.Resources.cursor;
            this.btnCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(23, 22);
            this.btnCursor.Text = "Single";
            this.btnCursor.Click += new System.EventHandler(this.btnSingleArrow_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelect.Image = global::EGMGame.Properties.Resources.selection;
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(23, 22);
            this.btnSelect.Text = "Selection";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSelectLayered
            // 
            this.btnSelectLayered.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectLayered.Image = global::EGMGame.Properties.Resources.layer_select;
            this.btnSelectLayered.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectLayered.Name = "btnSelectLayered";
            this.btnSelectLayered.Size = new System.Drawing.Size(23, 22);
            this.btnSelectLayered.Text = "Layered Selection";
            this.btnSelectLayered.Click += new System.EventHandler(this.btnLayeredSelect_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEventView
            // 
            this.btnEventView.CheckOnClick = true;
            this.btnEventView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEventView.Image = ((System.Drawing.Image)(resources.GetObject("btnEventView.Image")));
            this.btnEventView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEventView.Name = "btnEventView";
            this.btnEventView.Size = new System.Drawing.Size(23, 22);
            this.btnEventView.Text = "Allow Event Selection";
            this.btnEventView.Click += new System.EventHandler(this.btnEventView_Click);
            // 
            // btnLayerSelect
            // 
            this.btnLayerSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayerSelect.Image = global::EGMGame.Properties.Resources.transform_selection;
            this.btnLayerSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayerSelect.Name = "btnLayerSelect";
            this.btnLayerSelect.Size = new System.Drawing.Size(23, 22);
            this.btnLayerSelect.Text = "Layer Selection";
            this.btnLayerSelect.Click += new System.EventHandler(this.btnLayerSelect_Click);
            // 
            // mapViewer
            // 
            this.mapViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewer.GridHeight = 32;
            this.mapViewer.GridWidth = 32;
            this.mapViewer.Location = new System.Drawing.Point(0, 0);
            this.mapViewer.Map = null;
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.SelectedLayer = null;
            this.mapViewer.SelectedTile = null;
            this.mapViewer.SelectedTileset = null;
            this.mapViewer.Size = new System.Drawing.Size(1234, 818);
            this.mapViewer.TabIndex = 4;
            this.mapViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapViewer_KeyDown);
            this.mapViewer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mapViewer_KeyUp);
            // 
            // MapEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapViewer);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MapEditorControl";
            this.Size = new System.Drawing.Size(1234, 818);
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public MapViewer mapViewer;
        private System.Windows.Forms.ToolStripButton newMapBtn;
        internal System.Windows.Forms.ToolStripButton tsbSwapLayerUp;
        internal System.Windows.Forms.ToolStripButton tsbSwapLayerDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnRect;
        private System.Windows.Forms.ToolStripButton btnFill;
        private System.Windows.Forms.ToolStripButton btnCursor;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripButton btnSelectLayered;
        private System.Windows.Forms.ToolStripButton btnBrush;
        private System.Windows.Forms.ToolStripButton btnEraser;
        private System.Windows.Forms.ToolStripButton btnShowCollision;
        private System.Windows.Forms.ToolStripButton btnEraserRect;
        private System.Windows.Forms.ToolStripButton btnEraserFill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnEventView;
        private System.Windows.Forms.ToolStripButton btnLayerSelect;
        private System.Windows.Forms.ToolStripButton btnMapSize;
        private System.Windows.Forms.ToolStripButton btnGridSize;
        private System.Windows.Forms.ToolStripButton btnGravity;
        private System.Windows.Forms.ToolStripButton btnEffect;
        private System.Windows.Forms.ToolStripButton btnDimLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton btnShowGrid;
        private System.Windows.Forms.ToolStripButton btnSnapToGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnBG;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripLabel lblLayer;
    }
}
