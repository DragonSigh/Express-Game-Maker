namespace EGMGame.Controls
{
    partial class MenuViewer
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
            this.lblZoom = new System.Windows.Forms.ToolStripLabel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomChoice = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbmZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSafeArea = new System.Windows.Forms.ToolStripButton();
            this.bgScroller = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bringForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendBackwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideBg = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStripSplitButton1,
            this.btnSafeArea,
            this.toolStripSeparator7,
            this.btnShowHideBg});
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
            this.tsbZoomChoice.Size = new System.Drawing.Size(29, 22);
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
            // tsbmZoom25
            // 
            this.tsbmZoom25.Name = "tsbmZoom25";
            this.tsbmZoom25.Size = new System.Drawing.Size(102, 22);
            this.tsbmZoom25.Text = "25%";
            this.tsbmZoom25.Click += new System.EventHandler(this.tsbmZoom25_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x32ToolStripMenuItem,
            this.x16ToolStripMenuItem,
            this.x8ToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::EGMGame.Properties.Resources.grid;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripSplitButton1.Text = "Grid Size";
            // 
            // x32ToolStripMenuItem
            // 
            this.x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
            this.x32ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x32ToolStripMenuItem.Text = "32x32";
            this.x32ToolStripMenuItem.Click += new System.EventHandler(this.x32ToolStripMenuItem_Click);
            // 
            // x16ToolStripMenuItem
            // 
            this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
            this.x16ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x16ToolStripMenuItem.Text = "16x16";
            this.x16ToolStripMenuItem.Click += new System.EventHandler(this.x16ToolStripMenuItem_Click);
            // 
            // x8ToolStripMenuItem
            // 
            this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            this.x8ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x8ToolStripMenuItem.Text = "8x8";
            this.x8ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // btnSafeArea
            // 
            this.btnSafeArea.CheckOnClick = true;
            this.btnSafeArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSafeArea.Image = global::EGMGame.Properties.Resources.layout_hf_2;
            this.btnSafeArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSafeArea.Name = "btnSafeArea";
            this.btnSafeArea.Size = new System.Drawing.Size(23, 22);
            this.btnSafeArea.Text = "Display Safe Area";
            this.btnSafeArea.ToolTipText = "Display Safe Area\r\nDisplays the safe area that is used by the XBOX. \r\nThe safe ar" +
                "ea is 80% of the inner screen.";
            this.btnSafeArea.CheckedChanged += new System.EventHandler(this.btnSafeArea_CheckedChanged);
            // 
            // bgScroller
            // 
            this.bgScroller.WorkerSupportsCancellation = true;
            this.bgScroller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgScroller_DoWork);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.bringForwardToolStripMenuItem,
            this.sendBackwardToolStripMenuItem,
            this.toolStripSeparator6,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 220);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::EGMGame.Properties.Resources.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::EGMGame.Properties.Resources.document_copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.clipboard_paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // bringForwardToolStripMenuItem
            // 
            this.bringForwardToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange;
            this.bringForwardToolStripMenuItem.Name = "bringForwardToolStripMenuItem";
            this.bringForwardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bringForwardToolStripMenuItem.Text = "Bring To Front";
            this.bringForwardToolStripMenuItem.Click += new System.EventHandler(this.bringForwardToolStripMenuItem_Click);
            // 
            // sendBackwardToolStripMenuItem
            // 
            this.sendBackwardToolStripMenuItem.Image = global::EGMGame.Properties.Resources.layers_arrange_back;
            this.sendBackwardToolStripMenuItem.Name = "sendBackwardToolStripMenuItem";
            this.sendBackwardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sendBackwardToolStripMenuItem.Text = "Send  To Back";
            this.sendBackwardToolStripMenuItem.Click += new System.EventHandler(this.sendBackwardToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::EGMGame.Properties.Resources.arrow_undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::EGMGame.Properties.Resources.arrow_redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // graphicsControl
            // 
            this.graphicsControl.AllowDrop = true;
            this.graphicsControl.ContextMenuStrip = this.contextMenuStrip;
            this.graphicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl.Location = new System.Drawing.Point(0, 0);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(485, 410);
            this.graphicsControl.TabIndex = 36;
            this.graphicsControl.Text = "graphicsControl";
            this.graphicsControl.OnDraw += new System.EventHandler(this.graphicsControl_OnDraw);
            this.graphicsControl.OnInitialize += new System.EventHandler(this.graphicsControl_OnInitialize);
            this.graphicsControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragDrop);
            this.graphicsControl.DragOver += new System.Windows.Forms.DragEventHandler(this.graphicsControl_DragOver);
            this.graphicsControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyDown);
            this.graphicsControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyUp);
            this.graphicsControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseDown);
            this.graphicsControl.MouseEnter += new System.EventHandler(this.graphicsControl_MouseEnter);
            this.graphicsControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseMove);
            this.graphicsControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseUp);
            this.graphicsControl.Resize += new System.EventHandler(this.graphicsControl_Resize);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnShowHideBg
            // 
            this.btnShowHideBg.CheckOnClick = true;
            this.btnShowHideBg.Image = global::EGMGame.Properties.Resources.image_empty;
            this.btnShowHideBg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideBg.Name = "btnShowHideBg";
            this.btnShowHideBg.Size = new System.Drawing.Size(123, 22);
            this.btnShowHideBg.Text = "Show Background";
            this.btnShowHideBg.CheckedChanged += new System.EventHandler(this.btnShowHideBg_CheckedChanged);
            // 
            // MenuViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.graphicsControl);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.toolStrip);
            this.Name = "MenuViewer";
            this.Size = new System.Drawing.Size(502, 452);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblZoom;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private SimpleGraphicsControl graphicsControl;
        private System.ComponentModel.BackgroundWorker bgScroller;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem bringForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendBackwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbZoomChoice;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom200;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom100;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom50;
        private System.Windows.Forms.ToolStripMenuItem tsbmZoom25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSafeArea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnShowHideBg;
    }
}
