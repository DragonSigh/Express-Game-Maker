namespace EGMGame.Controls
{
    partial class MapViewer
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
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblZoom = new System.Windows.Forms.ToolStripLabel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.mouseLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblFPS = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lblTileCount = new System.Windows.Forms.ToolStripLabel();
            this.tileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontCTRLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backCTRLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.bgScroller = new System.ComponentModel.BackgroundWorker();
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.tbOpacity = new EGMGame.Controls.TrackBarFloat();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.physicsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStrip2.SuspendLayout();
            this.tileMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Enabled = false;
            this.hScrollBar.LargeChange = 2;
            this.hScrollBar.Location = new System.Drawing.Point(0, 430);
            this.hScrollBar.Maximum = 1;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(461, 17);
            this.hScrollBar.TabIndex = 13;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_Scroll);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.vScrollBar.Location = new System.Drawing.Point(461, 0);
            this.vScrollBar.Maximum = 1;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 447);
            this.vScrollBar.TabIndex = 14;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.vScrollBar_Scroll);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Enabled = false;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.tsbZoom,
            this.toolStripSeparator1,
            this.lblZoom,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.mouseLbl,
            this.toolStripSeparator6,
            this.toolStripLabel2,
            this.lblFPS,
            this.toolStripSeparator7,
            this.toolStripLabel3,
            this.lblTileCount});
            this.toolStrip2.Location = new System.Drawing.Point(0, 447);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(478, 25);
            this.toolStrip2.TabIndex = 11;
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel1.Text = "Mouse";
            // 
            // mouseLbl
            // 
            this.mouseLbl.Name = "mouseLbl";
            this.mouseLbl.Size = new System.Drawing.Size(30, 22);
            this.mouseLbl.Text = "{0,0}";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel2.Text = "FPS:";
            // 
            // lblFPS
            // 
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(13, 22);
            this.lblFPS.Text = "0";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel3.Text = "Tile Count:";
            // 
            // lblTileCount
            // 
            this.lblTileCount.Name = "lblTileCount";
            this.lblTileCount.Size = new System.Drawing.Size(13, 22);
            this.lblTileCount.Text = "0";
            // 
            // tileMenu
            // 
            this.tileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripSeparator8,
            this.addEventToolStripMenuItem,
            this.toolStripSeparator2,
            this.bringToFrontToolStripMenuItem,
            this.sendToBackToolStripMenuItem,
            this.frontCTRLDToolStripMenuItem,
            this.backCTRLFToolStripMenuItem,
            this.moveDownLayerToolStripMenuItem,
            this.moveUpLayerToolStripMenuItem,
            this.toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator3,
            this.removeToolStripMenuItem,
            this.toolStripSeparator12,
            this.toolStripMenuItem10});
            this.tileMenu.Name = "tileMenu";
            this.tileMenu.Size = new System.Drawing.Size(186, 320);
            this.tileMenu.Opening += new System.ComponentModel.CancelEventHandler(this.tileMenu_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(182, 6);
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Image = global::EGMGame.Properties.Resources.light_bulb;
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addEventToolStripMenuItem.Text = "Add Event";
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.addEventToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange;
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.bringToFrontToolStripMenuItem.Text = "Bring To Front    D";
            this.bringToFrontToolStripMenuItem.Visible = false;
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange_back;
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.sendToBackToolStripMenuItem.Text = "Send To Back      F";
            this.sendToBackToolStripMenuItem.Visible = false;
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // frontCTRLDToolStripMenuItem
            // 
            this.frontCTRLDToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_stack_arrange_back;
            this.frontCTRLDToolStripMenuItem.Name = "frontCTRLDToolStripMenuItem";
            this.frontCTRLDToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.frontCTRLDToolStripMenuItem.Text = "Front           CTRL + D";
            this.frontCTRLDToolStripMenuItem.Visible = false;
            this.frontCTRLDToolStripMenuItem.Click += new System.EventHandler(this.frontCTRLDToolStripMenuItem_Click);
            // 
            // backCTRLFToolStripMenuItem
            // 
            this.backCTRLFToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_stack_arrange_back;
            this.backCTRLFToolStripMenuItem.Name = "backCTRLFToolStripMenuItem";
            this.backCTRLFToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.backCTRLFToolStripMenuItem.Text = "Back            CTRL + F";
            this.backCTRLFToolStripMenuItem.Visible = false;
            this.backCTRLFToolStripMenuItem.Click += new System.EventHandler(this.backCTRLFToolStripMenuItem_Click);
            // 
            // moveDownLayerToolStripMenuItem
            // 
            this.moveDownLayerToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange_back;
            this.moveDownLayerToolStripMenuItem.Name = "moveDownLayerToolStripMenuItem";
            this.moveDownLayerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.moveDownLayerToolStripMenuItem.Text = "Move Down Layer";
            this.moveDownLayerToolStripMenuItem.Click += new System.EventHandler(this.moveDownLayerToolStripMenuItem_Click);
            // 
            // moveUpLayerToolStripMenuItem
            // 
            this.moveUpLayerToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange;
            this.moveUpLayerToolStripMenuItem.Name = "moveUpLayerToolStripMenuItem";
            this.moveUpLayerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.moveUpLayerToolStripMenuItem.Text = "Move Up Layer";
            this.moveUpLayerToolStripMenuItem.Click += new System.EventHandler(this.moveUpLayerToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(182, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::EGMGame.Properties.Resources.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.clipboard_paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::EGMGame.Properties.Resources.Player;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItem10.Text = "Add Player";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.addPlayerToolStripMenuItem_Click);
            // 
            // bgScroller
            // 
            this.bgScroller.WorkerSupportsCancellation = true;
            this.bgScroller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgScroller_DoWork);
            // 
            // graphicsControl
            // 
            this.graphicsControl.AllowDrop = true;
            this.graphicsControl.ContextMenuStrip = this.tileMenu;
            this.graphicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl.Location = new System.Drawing.Point(0, 0);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(461, 430);
            this.graphicsControl.TabIndex = 12;
            this.graphicsControl.Text = "graphicsControl";
            this.graphicsControl.OnDraw += new System.EventHandler(this.graphicsControl_OnDraw);
            this.graphicsControl.OnInitialize += new System.EventHandler(this.graphicsControl_OnInitialize);
            this.graphicsControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragDrop);
            this.graphicsControl.DragOver += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragEnter);
            this.graphicsControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyDown);
            this.graphicsControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyUp);
            this.graphicsControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseDoubleClick);
            this.graphicsControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseDown);
            this.graphicsControl.MouseEnter += new System.EventHandler(this.graphicsControl_MouseEnter);
            this.graphicsControl.MouseLeave += new System.EventHandler(this.graphicsControl_DragLeave);
            this.graphicsControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseMove);
            this.graphicsControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseUp);
            this.graphicsControl.Resize += new System.EventHandler(this.graphicsControl_Resize);
            // 
            // tbOpacity
            // 
            this.tbOpacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbOpacity.BackColor = System.Drawing.Color.White;
            this.tbOpacity.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbOpacity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOpacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.tbOpacity.IndentHeight = 6;
            this.tbOpacity.LargeChange = 2F;
            this.tbOpacity.Location = new System.Drawing.Point(0, 25);
            this.tbOpacity.Maximum = 255F;
            this.tbOpacity.Minimum = 0F;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new System.Drawing.Size(64, 27);
            this.tbOpacity.SmallChange = 1F;
            this.tbOpacity.TabIndex = 15;
            this.tbOpacity.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.tbOpacity.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.tbOpacity.TickFrequency = 1F;
            this.tbOpacity.TickHeight = 4;
            this.tbOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbOpacity.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.tbOpacity.TrackerSize = new System.Drawing.Size(5, 15);
            this.tbOpacity.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.tbOpacity.TrackLineHeight = 3;
            this.tbOpacity.Value = 255F;
            this.tbOpacity.Visible = false;
            this.tbOpacity.ValueChanged += new EGMGame.Controls.ValueChangedHandler(this.tbOpacity_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.physicsBtn,
            this.toolStripSeparator9,
            this.btnAddNode,
            this.btnAddRectangle,
            this.btnAddCircle,
            this.btnLayout,
            this.seperator,
            this.deleteBtn,
            this.seperator3,
            this.subdivideBtn,
            this.simpifyBtn,
            this.seperator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(461, 25);
            this.toolStrip1.TabIndex = 39;
            this.toolStrip1.Visible = false;
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
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
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
            this.deleteBtn.ButtonClick += new System.EventHandler(this.deleteBtn_ButtonClick);
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
            // MapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.graphicsControl);
            this.Controls.Add(this.tbOpacity);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.toolStrip2);
            this.Name = "MapViewer";
            this.Size = new System.Drawing.Size(478, 472);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tileMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblZoom;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom50;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom100;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom200;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripDropDownButton tsbZoom;
        private System.Windows.Forms.ContextMenuStrip tileMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frontCTRLDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backCTRLFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel mouseLbl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal SimpleGraphicsControl graphicsControl;
        private System.ComponentModel.BackgroundWorker bgScroller;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel lblFPS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel lblTileCount;
        private System.Windows.Forms.ToolStripMenuItem moveDownLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
        private TrackBarFloat tbOpacity;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnAddNode;
        private System.Windows.Forms.ToolStripButton btnAddRectangle;
        private System.Windows.Forms.ToolStripButton btnAddCircle;
        private System.Windows.Forms.ToolStripSeparator seperator;
        private System.Windows.Forms.ToolStripSplitButton deleteBtn;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator seperator3;
        private System.Windows.Forms.ToolStripButton subdivideBtn;
        private System.Windows.Forms.ToolStripButton simpifyBtn;
        private System.Windows.Forms.ToolStripSeparator seperator2;
        private System.Windows.Forms.ToolStripButton btnLayout;
        internal System.Windows.Forms.ToolStripButton physicsBtn;
    }
}
