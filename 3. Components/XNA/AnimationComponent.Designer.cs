namespace EGMGame.Controls
{
    partial class AnimationComponent
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.playAniBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.physicsBtn = new System.Windows.Forms.ToolStripButton();
            this.battleBtn = new System.Windows.Forms.ToolStripButton();
            this.pinViewBtn = new System.Windows.Forms.ToolStripButton();
            this.anchorViewBtn = new System.Windows.Forms.ToolStripButton();
            this.btnParticle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.physicsAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.layoutSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anchorAdd = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.selData = new System.Windows.Forms.ToolStripComboBox();
            this.physicsLbl = new System.Windows.Forms.ToolStripLabel();
            this.subdivideBtn = new System.Windows.Forms.ToolStripButton();
            this.simpifyBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bringForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendBackwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.syncSameNumberAnchorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerAllSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.lblZoom = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.labelFPS = new System.Windows.Forms.ToolStripLabel();
            this.fpsLbl = new System.Windows.Forms.ToolStripLabel();
            this.bgScroller = new System.ComponentModel.BackgroundWorker();
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.lblGuide = new System.Windows.Forms.Label();
            this.keyTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playAniBtn,
            this.toolStripSeparator12,
            this.physicsBtn,
            this.battleBtn,
            this.pinViewBtn,
            this.anchorViewBtn,
            this.btnParticle,
            this.toolStripSeparator4,
            this.physicsAdd,
            this.anchorAdd,
            this.deleteBtn,
            this.toolStripSeparator5,
            this.selData,
            this.physicsLbl,
            this.subdivideBtn,
            this.simpifyBtn,
            this.toolStripSeparator9});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 5;
            // 
            // playAniBtn
            // 
            this.playAniBtn.CheckOnClick = true;
            this.playAniBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playAniBtn.Image = global::EGMGame.Properties.Resources.control_play;
            this.playAniBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playAniBtn.Name = "playAniBtn";
            this.playAniBtn.Size = new System.Drawing.Size(23, 22);
            this.playAniBtn.Text = "Play Animation";
            this.playAniBtn.Click += new System.EventHandler(this.playAniBtn_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // physicsBtn
            // 
            this.physicsBtn.CheckOnClick = true;
            this.physicsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.physicsBtn.Image = global::EGMGame.Properties.Resources.layer_shape_polygon;
            this.physicsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.physicsBtn.Name = "physicsBtn";
            this.physicsBtn.Size = new System.Drawing.Size(23, 22);
            this.physicsBtn.Text = "Collision Mapping";
            this.physicsBtn.CheckedChanged += new System.EventHandler(this.physicsBtn_CheckedChanged);
            // 
            // battleBtn
            // 
            this.battleBtn.CheckOnClick = true;
            this.battleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.battleBtn.Image = global::EGMGame.Properties.Resources.layer_shape_polygon_red;
            this.battleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.battleBtn.Name = "battleBtn";
            this.battleBtn.Size = new System.Drawing.Size(23, 22);
            this.battleBtn.Text = "Battle Collision Mapping";
            this.battleBtn.CheckedChanged += new System.EventHandler(this.battleBtn_CheckedChanged);
            // 
            // pinViewBtn
            // 
            this.pinViewBtn.CheckOnClick = true;
            this.pinViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pinViewBtn.Image = global::EGMGame.Properties.Resources.pin;
            this.pinViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pinViewBtn.Name = "pinViewBtn";
            this.pinViewBtn.Size = new System.Drawing.Size(23, 22);
            this.pinViewBtn.Text = "Physics Pin";
            this.pinViewBtn.Click += new System.EventHandler(this.pinViewBtn_Click);
            // 
            // anchorViewBtn
            // 
            this.anchorViewBtn.CheckOnClick = true;
            this.anchorViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.anchorViewBtn.Image = global::EGMGame.Properties.Resources.anchor;
            this.anchorViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.anchorViewBtn.Name = "anchorViewBtn";
            this.anchorViewBtn.Size = new System.Drawing.Size(23, 22);
            this.anchorViewBtn.Text = "Anchor View";
            this.anchorViewBtn.Click += new System.EventHandler(this.anchorViewBtn_Click);
            // 
            // btnParticle
            // 
            this.btnParticle.CheckOnClick = true;
            this.btnParticle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnParticle.Image = global::EGMGame.Properties.Resources.fire1;
            this.btnParticle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParticle.Name = "btnParticle";
            this.btnParticle.Size = new System.Drawing.Size(23, 22);
            this.btnParticle.Text = "Particles";
            this.btnParticle.Click += new System.EventHandler(this.btnParticle_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // physicsAdd
            // 
            this.physicsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.physicsAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem,
            this.toolStripSeparator6,
            this.addRectangleToolStripMenuItem,
            this.addCircleToolStripMenuItem,
            this.toolStripSeparator8,
            this.layoutSpriteToolStripMenuItem});
            this.physicsAdd.Image = global::EGMGame.Properties.Resources.add;
            this.physicsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.physicsAdd.Name = "physicsAdd";
            this.physicsAdd.Size = new System.Drawing.Size(29, 22);
            this.physicsAdd.Text = "Add Physics";
            this.physicsAdd.Visible = false;
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layer_shape_line;
            this.addNodeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addNodeToolStripMenuItem.Text = "Add Node";
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(148, 6);
            // 
            // addRectangleToolStripMenuItem
            // 
            this.addRectangleToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layer_shape;
            this.addRectangleToolStripMenuItem.Name = "addRectangleToolStripMenuItem";
            this.addRectangleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addRectangleToolStripMenuItem.Text = "Add Rectangle";
            this.addRectangleToolStripMenuItem.Click += new System.EventHandler(this.addRectangleToolStripMenuItem_Click);
            // 
            // addCircleToolStripMenuItem
            // 
            this.addCircleToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layer_shape_ellipse;
            this.addCircleToolStripMenuItem.Name = "addCircleToolStripMenuItem";
            this.addCircleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addCircleToolStripMenuItem.Text = "Add Circle";
            this.addCircleToolStripMenuItem.Click += new System.EventHandler(this.addCircleToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(148, 6);
            // 
            // layoutSpriteToolStripMenuItem
            // 
            this.layoutSpriteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layer_shape_curve;
            this.layoutSpriteToolStripMenuItem.Name = "layoutSpriteToolStripMenuItem";
            this.layoutSpriteToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.layoutSpriteToolStripMenuItem.Text = "Sprite Outline";
            this.layoutSpriteToolStripMenuItem.Click += new System.EventHandler(this.layoutSpriteToolStripMenuItem_Click);
            // 
            // anchorAdd
            // 
            this.anchorAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.anchorAdd.Image = global::EGMGame.Properties.Resources.add;
            this.anchorAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.anchorAdd.Name = "anchorAdd";
            this.anchorAdd.Size = new System.Drawing.Size(23, 22);
            this.anchorAdd.Text = "Add Anchor";
            this.anchorAdd.Visible = false;
            this.anchorAdd.Click += new System.EventHandler(this.anchorAdd_Click);
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
            this.deleteBtn.ButtonClick += new System.EventHandler(this.deleteBtn_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // selData
            // 
            this.selData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selData.Name = "selData";
            this.selData.Size = new System.Drawing.Size(75, 25);
            this.selData.SelectedIndexChanged += new System.EventHandler(this.selData_SelectedIndexChanged);
            // 
            // physicsLbl
            // 
            this.physicsLbl.Name = "physicsLbl";
            this.physicsLbl.Size = new System.Drawing.Size(189, 22);
            this.physicsLbl.Text = "Click (and drag) on a sprite to add.";
            this.physicsLbl.Visible = false;
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
            this.simpifyBtn.AutoToolTip = false;
            this.simpifyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.simpifyBtn.Image = global::EGMGame.Properties.Resources.black_square;
            this.simpifyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simpifyBtn.Name = "simpifyBtn";
            this.simpifyBtn.Size = new System.Drawing.Size(23, 22);
            this.simpifyBtn.Text = "toolStripButton1";
            this.simpifyBtn.ToolTipText = "Joins the edges of the collision map if possible.\r\nCan result in faster collision" +
    "s but less accuracy.";
            this.simpifyBtn.Visible = false;
            this.simpifyBtn.Click += new System.EventHandler(this.simpifyBtn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bringForwardToolStripMenuItem,
            this.sendBackwardToolStripMenuItem,
            this.toolStripSeparator2,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator10,
            this.syncSameNumberAnchorsToolStripMenuItem,
            this.centerSpriteToolStripMenuItem,
            this.centerAllSpritesToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(266, 220);
            // 
            // bringForwardToolStripMenuItem
            // 
            this.bringForwardToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange;
            this.bringForwardToolStripMenuItem.Name = "bringForwardToolStripMenuItem";
            this.bringForwardToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.bringForwardToolStripMenuItem.Text = "Bring To Front";
            this.bringForwardToolStripMenuItem.Click += new System.EventHandler(this.bringForwardToolStripMenuItem_Click);
            // 
            // sendBackwardToolStripMenuItem
            // 
            this.sendBackwardToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange_back;
            this.sendBackwardToolStripMenuItem.Name = "sendBackwardToolStripMenuItem";
            this.sendBackwardToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.sendBackwardToolStripMenuItem.Text = "Send To Back";
            this.sendBackwardToolStripMenuItem.Click += new System.EventHandler(this.sendBackwardToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(262, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::EGMGame.Properties.Resources.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::EGMGame.Properties.Resources.document_copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.clipboard_paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(262, 6);
            // 
            // syncSameNumberAnchorsToolStripMenuItem
            // 
            this.syncSameNumberAnchorsToolStripMenuItem.Name = "syncSameNumberAnchorsToolStripMenuItem";
            this.syncSameNumberAnchorsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.syncSameNumberAnchorsToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.syncSameNumberAnchorsToolStripMenuItem.Text = "Sync Same Number Anchors";
            this.syncSameNumberAnchorsToolStripMenuItem.Visible = false;
            this.syncSameNumberAnchorsToolStripMenuItem.Click += new System.EventHandler(this.syncSameNumberAnchorsToolStripMenuItem_Click);
            // 
            // centerSpriteToolStripMenuItem
            // 
            this.centerSpriteToolStripMenuItem.Name = "centerSpriteToolStripMenuItem";
            this.centerSpriteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.centerSpriteToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.centerSpriteToolStripMenuItem.Text = "Center Sprite";
            this.centerSpriteToolStripMenuItem.Click += new System.EventHandler(this.centerSpriteToolStripMenuItem_Click);
            // 
            // centerAllSpritesToolStripMenuItem
            // 
            this.centerAllSpritesToolStripMenuItem.Name = "centerAllSpritesToolStripMenuItem";
            this.centerAllSpritesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.centerAllSpritesToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.centerAllSpritesToolStripMenuItem.Text = "Center All Sprites";
            this.centerAllSpritesToolStripMenuItem.Click += new System.EventHandler(this.centerAllSpritesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(262, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Enabled = false;
            this.vScrollBar.LargeChange = 2;
            this.vScrollBar.Location = new System.Drawing.Point(583, 25);
            this.vScrollBar.Maximum = 1;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 329);
            this.vScrollBar.TabIndex = 9;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar_Scroll);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Sprite";
            this.openFileDialog.Filter = "Image files|*.jpg;*.bmp;*.png;*.gif";
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Enabled = false;
            this.hScrollBar.LargeChange = 1;
            this.hScrollBar.Location = new System.Drawing.Point(0, 354);
            this.hScrollBar.Maximum = 0;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(600, 17);
            this.hScrollBar.TabIndex = 8;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_Scroll);
            // 
            // lblZoom
            // 
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(35, 22);
            this.lblZoom.Text = "100%";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.tsbZoom,
            this.toolStripSeparator1,
            this.lblZoom,
            this.toolStripSeparator7,
            this.labelFPS,
            this.fpsLbl});
            this.toolStrip2.Location = new System.Drawing.Point(0, 371);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(600, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomIn.Image = global::EGMGame.Properties.Resources.zoom_in;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomIn.Text = "Zoom In";
            this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomIn_Click);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomOut.Image = global::EGMGame.Properties.Resources.zoom_out;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomOut.Text = "Zoom Out";
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // tsbZoom
            // 
            this.tsbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmZoom200,
            this.tsmZoom100,
            this.tsmZoom50,
            this.tsmZoom25});
            this.tsbZoom.Image = global::EGMGame.Properties.Resources.zoom;
            this.tsbZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoom.Name = "tsbZoom";
            this.tsbZoom.Size = new System.Drawing.Size(29, 22);
            this.tsbZoom.Text = "Zoom...";
            // 
            // tsmZoom200
            // 
            this.tsmZoom200.Name = "tsmZoom200";
            this.tsmZoom200.Size = new System.Drawing.Size(102, 22);
            this.tsmZoom200.Text = "200%";
            this.tsmZoom200.Click += new System.EventHandler(this.tsbmZoom200_Click);
            // 
            // tsmZoom100
            // 
            this.tsmZoom100.Name = "tsmZoom100";
            this.tsmZoom100.Size = new System.Drawing.Size(102, 22);
            this.tsmZoom100.Text = "100%";
            this.tsmZoom100.Click += new System.EventHandler(this.tsbmZoom100_Click);
            // 
            // tsmZoom50
            // 
            this.tsmZoom50.Name = "tsmZoom50";
            this.tsmZoom50.Size = new System.Drawing.Size(102, 22);
            this.tsmZoom50.Text = "50%";
            this.tsmZoom50.Click += new System.EventHandler(this.tsbmZoom50_Click);
            // 
            // tsmZoom25
            // 
            this.tsmZoom25.Name = "tsmZoom25";
            this.tsmZoom25.Size = new System.Drawing.Size(102, 22);
            this.tsmZoom25.Text = "25%";
            this.tsmZoom25.Click += new System.EventHandler(this.tsbmZoom25_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // labelFPS
            // 
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(32, 22);
            this.labelFPS.Text = "FPS: ";
            // 
            // fpsLbl
            // 
            this.fpsLbl.Name = "fpsLbl";
            this.fpsLbl.Size = new System.Drawing.Size(13, 22);
            this.fpsLbl.Text = "0";
            // 
            // bgScroller
            // 
            this.bgScroller.WorkerSupportsCancellation = true;
            this.bgScroller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgScroller_DoWork);
            // 
            // graphicsControl
            // 
            this.graphicsControl.AllowDrop = true;
            this.graphicsControl.ContextMenuStrip = this.contextMenuStrip;
            this.graphicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl.Location = new System.Drawing.Point(0, 25);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(600, 371);
            this.graphicsControl.TabIndex = 7;
            this.graphicsControl.Text = "graphicsControl";
            this.graphicsControl.OnDraw += new System.EventHandler(this.graphicsControl_OnDraw);
            this.graphicsControl.OnInitialize += new System.EventHandler(this.graphicsControl_OnInitialize);
            this.graphicsControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragDrop);
            this.graphicsControl.DragOver += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragOver);
            this.graphicsControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyDown);
            this.graphicsControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyUp);
            this.graphicsControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseDoubleClick);
            this.graphicsControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseDown);
            this.graphicsControl.MouseEnter += new System.EventHandler(this.graphicsControl_MouseEnter);
            this.graphicsControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseMove);
            this.graphicsControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseUp);
            this.graphicsControl.Resize += new System.EventHandler(this.graphicsControl_Resize);
            // 
            // lblGuide
            // 
            this.lblGuide.AllowDrop = true;
            this.lblGuide.BackColor = System.Drawing.Color.Black;
            this.lblGuide.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuide.ForeColor = System.Drawing.Color.White;
            this.lblGuide.Location = new System.Drawing.Point(0, 25);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(317, 24);
            this.lblGuide.TabIndex = 33;
            this.lblGuide.Text = "Add a new frame or import a sprite sheet.";
            this.lblGuide.Visible = false;
            this.lblGuide.DragDrop += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragDrop);
            this.lblGuide.DragOver += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragOver);
            // 
            // keyTimer
            // 
            this.keyTimer.Tick += new System.EventHandler(this.keyTimer_Tick);
            // 
            // AnimationComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.graphicsControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AnimationComponent";
            this.Size = new System.Drawing.Size(600, 396);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bringForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendBackwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ToolStripLabel lblZoom;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton tsbZoom;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom200;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom100;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom50;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public SimpleGraphicsControl graphicsControl;
        private System.Windows.Forms.ToolStripButton anchorViewBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton anchorAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.ComponentModel.BackgroundWorker bgScroller;
        private System.Windows.Forms.ToolStripComboBox selData;
        private System.Windows.Forms.ToolStripLabel labelFPS;
        private System.Windows.Forms.ToolStripLabel fpsLbl;
        private System.Windows.Forms.ToolStripButton physicsBtn;
        private System.Windows.Forms.ToolStripLabel physicsLbl;
        private System.Windows.Forms.ToolStripButton simpifyBtn;
        private System.Windows.Forms.ToolStripButton subdivideBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton physicsAdd;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem addRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem layoutSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem centerSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerAllSpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton battleBtn;
        private System.Windows.Forms.ToolStripSplitButton deleteBtn;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton pinViewBtn;
        private System.Windows.Forms.ToolStripButton btnParticle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        public System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.ToolStripButton playAniBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem syncSameNumberAnchorsToolStripMenuItem;
        private System.Windows.Forms.Timer keyTimer;
    }
}
