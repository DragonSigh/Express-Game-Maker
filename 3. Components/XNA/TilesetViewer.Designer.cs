namespace EGMGame.Controls
{
    partial class TilesetViewer
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
            this.components = new System.ComponentModel.Container();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tipLabel = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.ToolStripLabel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.tsbmZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomChoice = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbmZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.bgScroller = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.physicsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddNode = new System.Windows.Forms.ToolStripButton();
            this.btnAddRectangle = new System.Windows.Forms.ToolStripButton();
            this.btnAddCircle = new System.Windows.Forms.ToolStripButton();
            this.btnLayout = new System.Windows.Forms.ToolStripButton();
            this.seperator = new System.Windows.Forms.ToolStripSeparator();
            this.deleteBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.subdivideBtn = new System.Windows.Forms.ToolStripButton();
            this.simpifyBtn = new System.Windows.Forms.ToolStripButton();
            this.seperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.physicsLbl = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblGuide = new System.Windows.Forms.Label();
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtErrors = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tipLabel
            // 
            this.tipLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.tipLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipLabel.ForeColor = System.Drawing.Color.Black;
            this.tipLabel.Location = new System.Drawing.Point(0, 25);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(485, 385);
            this.tipLabel.TabIndex = 37;
            this.tipLabel.Visible = false;
            this.tipLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragEnter);
            this.tipLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragDrop);
            // 
            // lblZoom
            // 
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(35, 22);
            this.lblZoom.Text = "100%";
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Enabled = false;
            this.vScrollBar.LargeChange = 2;
            this.vScrollBar.Location = new System.Drawing.Point(485, 0);
            this.vScrollBar.Maximum = 1;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 410);
            this.vScrollBar.TabIndex = 34;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Enabled = false;
            this.hScrollBar.LargeChange = 2;
            this.hScrollBar.Location = new System.Drawing.Point(0, 410);
            this.hScrollBar.Maximum = 1;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(502, 17);
            this.hScrollBar.TabIndex = 35;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_Scroll);
            // 
            // tsbmZoom25
            // 
            this.tsbmZoom25.Name = "tsbmZoom25";
            this.tsbmZoom25.Size = new System.Drawing.Size(102, 22);
            this.tsbmZoom25.Text = "25%";
            this.tsbmZoom25.Click += new System.EventHandler(this.tsbmZoom25_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.tsbZoomChoice,
            this.toolStripSeparator1,
            this.lblZoom,
            this.toolStripSeparator2,
            this.txtErrors});
            this.toolStrip.Location = new System.Drawing.Point(0, 427);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(502, 25);
            this.toolStrip.TabIndex = 33;
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.Image = global::EGMGame.Properties.Resources.zoom_in;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomIn.Text = "toolStripButton2";
            this.tsbZoomIn.ToolTipText = "Zoom In";
            this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomIn_Click);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Image = global::EGMGame.Properties.Resources.zoom_out;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomOut.Text = "toolStripButton1";
            this.tsbZoomOut.ToolTipText = "Zoom Out";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // tsbZoomChoice
            // 
            this.tsbZoomChoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomChoice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbmZoom200,
            this.tsbmZoom100,
            this.tsbmZoom50,
            this.tsbmZoom25});
            this.tsbZoomChoice.Image = global::EGMGame.Properties.Resources.zoom;
            this.tsbZoomChoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomChoice.Name = "tsbZoomChoice";
            this.tsbZoomChoice.Size = new System.Drawing.Size(32, 22);
            this.tsbZoomChoice.Text = "Zoom Setting";
            // 
            // tsbmZoom200
            // 
            this.tsbmZoom200.Name = "tsbmZoom200";
            this.tsbmZoom200.Size = new System.Drawing.Size(102, 22);
            this.tsbmZoom200.Text = "200%";
            this.tsbmZoom200.Click += new System.EventHandler(this.tsbmZoom200_Click);
            // 
            // tsbmZoom100
            // 
            this.tsbmZoom100.Name = "tsbmZoom100";
            this.tsbmZoom100.Size = new System.Drawing.Size(102, 22);
            this.tsbmZoom100.Text = "100%";
            this.tsbmZoom100.ToolTipText = "Zoom 100%";
            this.tsbmZoom100.Click += new System.EventHandler(this.tsbmZoom100_Click);
            // 
            // tsbmZoom50
            // 
            this.tsbmZoom50.Name = "tsbmZoom50";
            this.tsbmZoom50.Size = new System.Drawing.Size(102, 22);
            this.tsbmZoom50.Text = "50%";
            this.tsbmZoom50.Click += new System.EventHandler(this.tsbmZoom50_Click);
            // 
            // bgScroller
            // 
            this.bgScroller.WorkerSupportsCancellation = true;
            this.bgScroller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgScroller_DoWork);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.physicsBtn,
            this.toolStripSeparator4,
            this.btnAddNode,
            this.btnAddRectangle,
            this.btnAddCircle,
            this.btnLayout,
            this.seperator,
            this.deleteBtn,
            this.seperator3,
            this.subdivideBtn,
            this.simpifyBtn,
            this.seperator2,
            this.physicsLbl});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(485, 25);
            this.toolStrip1.TabIndex = 38;
            // 
            // physicsBtn
            // 
            this.physicsBtn.CheckOnClick = true;
            this.physicsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.physicsBtn.Image = global::EGMGame.Properties.Resources.layer_shape_polygon;
            this.physicsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.physicsBtn.Name = "physicsBtn";
            this.physicsBtn.Size = new System.Drawing.Size(23, 22);
            this.physicsBtn.Text = "Collision Map";
            this.physicsBtn.CheckedChanged += new System.EventHandler(this.physicsBtn_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddNode
            // 
            this.btnAddNode.CheckOnClick = true;
            this.btnAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNode.Image = global::EGMGame.Properties.Resources.layer_shape_line;
            this.btnAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(23, 22);
            this.btnAddNode.Text = "Add Node";
            this.btnAddNode.Visible = false;
            this.btnAddNode.CheckedChanged += new System.EventHandler(this.btnAddNode_CheckedChanged);
            // 
            // btnAddRectangle
            // 
            this.btnAddRectangle.CheckOnClick = true;
            this.btnAddRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRectangle.Image = global::EGMGame.Properties.Resources.layer_shape;
            this.btnAddRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRectangle.Name = "btnAddRectangle";
            this.btnAddRectangle.Size = new System.Drawing.Size(23, 22);
            this.btnAddRectangle.Text = "Add Rectangle";
            this.btnAddRectangle.Visible = false;
            this.btnAddRectangle.CheckedChanged += new System.EventHandler(this.btnAddRectangle_CheckedChanged);
            // 
            // btnAddCircle
            // 
            this.btnAddCircle.CheckOnClick = true;
            this.btnAddCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddCircle.Image = global::EGMGame.Properties.Resources.layer_shape_ellipse;
            this.btnAddCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCircle.Name = "btnAddCircle";
            this.btnAddCircle.Size = new System.Drawing.Size(23, 22);
            this.btnAddCircle.Text = "Add Circle";
            this.btnAddCircle.Visible = false;
            this.btnAddCircle.CheckedChanged += new System.EventHandler(this.btnAddCircle_CheckedChanged);
            // 
            // btnLayout
            // 
            this.btnLayout.CheckOnClick = true;
            this.btnLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayout.Image = global::EGMGame.Properties.Resources.layer_shape_curve;
            this.btnLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Size = new System.Drawing.Size(23, 22);
            this.btnLayout.Text = "Layout Tile";
            this.btnLayout.Visible = false;
            this.btnLayout.CheckedChanged += new System.EventHandler(this.btnLayout_CheckedChanged);
            // 
            // seperator
            // 
            this.seperator.Name = "seperator";
            this.seperator.Size = new System.Drawing.Size(6, 25);
            this.seperator.Visible = false;
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllToolStripMenuItem});
            this.deleteBtn.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(32, 22);
            this.deleteBtn.Text = "Delete Selected";
            this.deleteBtn.Visible = false;
            this.deleteBtn.ButtonClick += new System.EventHandler(this.deleteBtn_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // seperator3
            // 
            this.seperator3.Name = "seperator3";
            this.seperator3.Size = new System.Drawing.Size(6, 25);
            this.seperator3.Visible = false;
            // 
            // subdivideBtn
            // 
            this.subdivideBtn.AutoToolTip = false;
            this.subdivideBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subdivideBtn.Image = global::EGMGame.Properties.Resources.grid;
            this.subdivideBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subdivideBtn.Name = "subdivideBtn";
            this.subdivideBtn.Size = new System.Drawing.Size(23, 22);
            this.subdivideBtn.Text = "Subdivide";
            this.subdivideBtn.ToolTipText = "Subdivides the edges of the collision map.\r\nSubdividing can result in more accura" +
                "te collision.";
            this.subdivideBtn.Visible = false;
            this.subdivideBtn.Click += new System.EventHandler(this.subdivideBtn_Click);
            // 
            // simpifyBtn
            // 
            this.simpifyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.simpifyBtn.Image = global::EGMGame.Properties.Resources.black_square;
            this.simpifyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simpifyBtn.Name = "simpifyBtn";
            this.simpifyBtn.Size = new System.Drawing.Size(23, 22);
            this.simpifyBtn.Text = "toolStripButton1";
            this.simpifyBtn.Visible = false;
            this.simpifyBtn.Click += new System.EventHandler(this.simpifyBtn_Click);
            // 
            // seperator2
            // 
            this.seperator2.Name = "seperator2";
            this.seperator2.Size = new System.Drawing.Size(6, 25);
            this.seperator2.Visible = false;
            // 
            // physicsLbl
            // 
            this.physicsLbl.Name = "physicsLbl";
            this.physicsLbl.Size = new System.Drawing.Size(214, 22);
            this.physicsLbl.Text = "Click (or drag) on a tile to add collision.";
            this.physicsLbl.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator10,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(145, 98);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::EGMGame.Properties.Resources.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.clipboard_paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(141, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblGuide
            // 
            this.lblGuide.AllowDrop = true;
            this.lblGuide.BackColor = System.Drawing.Color.DarkGray;
            this.lblGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGuide.Font = new System.Drawing.Font("Georgia", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuide.ForeColor = System.Drawing.Color.White;
            this.lblGuide.Location = new System.Drawing.Point(0, 25);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(485, 385);
            this.lblGuide.TabIndex = 39;
            this.lblGuide.Text = "Drag and drop your tileset image from the materials explorer.";
            this.lblGuide.DragDrop += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragDrop);
            this.lblGuide.DragEnter += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragEnter);
            // 
            // graphicsControl
            // 
            this.graphicsControl.AllowDrop = true;
            this.graphicsControl.ContextMenuStrip = this.contextMenuStrip;
            this.graphicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl.Location = new System.Drawing.Point(0, 25);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(485, 385);
            this.graphicsControl.TabIndex = 36;
            this.graphicsControl.Text = "graphicsControl";
            this.graphicsControl.OnDraw += new System.EventHandler(this.graphicsControl_OnDraw);
            this.graphicsControl.OnInitialize += new System.EventHandler(this.graphicsControl_OnInitialize);
            this.graphicsControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragDrop);
            this.graphicsControl.DragOver += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragEnter);
            this.graphicsControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyDown);
            this.graphicsControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyUp);
            this.graphicsControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseDown);
            this.graphicsControl.MouseEnter += new System.EventHandler(this.graphicsControl_MouseEnter);
            this.graphicsControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseMove);
            this.graphicsControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseUp);
            this.graphicsControl.Resize += new System.EventHandler(this.graphicsControl_Resize);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtErrors
            // 
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(56, 22);
            this.txtErrors.Text = "No Errors";
            // 
            // TilesetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.tipLabel);
            this.Controls.Add(this.graphicsControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.toolStrip);
            this.Name = "TilesetViewer";
            this.Size = new System.Drawing.Size(502, 452);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.Label tipLabel;
        private System.Windows.Forms.ToolStripLabel lblZoom;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom25;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripSplitButton tsbZoomChoice;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom200;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom100;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom50;
        private SimpleGraphicsControl graphicsControl;
        private System.ComponentModel.BackgroundWorker bgScroller;
        private System.Windows.Forms.ToolStripButton physicsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator seperator;
        private System.Windows.Forms.ToolStripButton subdivideBtn;
        private System.Windows.Forms.ToolStripButton simpifyBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton deleteBtn;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel physicsLbl;
        private System.Windows.Forms.ToolStripButton btnAddNode;
        private System.Windows.Forms.ToolStripButton btnAddRectangle;
        private System.Windows.Forms.ToolStripButton btnAddCircle;
        private System.Windows.Forms.ToolStripSeparator seperator3;
        private System.Windows.Forms.ToolStripButton btnLayout;
        private System.Windows.Forms.ToolStripSeparator seperator2;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel txtErrors;
    }
}
