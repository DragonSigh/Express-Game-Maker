namespace EGMGame.Controls
{
    partial class XnaViewer
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.bgScroller = new System.ComponentModel.BackgroundWorker();
            this.toolStrip.SuspendLayout();
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
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
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
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
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
            this.lblZoom});
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
            // graphicsControl
            // 
            this.graphicsControl.AllowDrop = true;
            this.graphicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl.Location = new System.Drawing.Point(0, 0);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(485, 410);
            this.graphicsControl.TabIndex = 36;
            this.graphicsControl.Text = "graphicsControl";
            this.graphicsControl.OnDraw += new System.EventHandler(this.graphicsControl_OnDraw);
            this.graphicsControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseMove);
            this.graphicsControl.OnInitialize += new System.EventHandler(this.graphicsControl_OnInitialize);
            this.graphicsControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyUp);
            this.graphicsControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseDown);
            this.graphicsControl.Resize += new System.EventHandler(this.graphicsControl_Resize);
            this.graphicsControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphicsControl_MouseUp);
            this.graphicsControl.MouseEnter += new System.EventHandler(this.graphicsControl_MouseEnter);
            this.graphicsControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graphicsControl_KeyDown);
            // 
            // bgScroller
            // 
            this.bgScroller.WorkerSupportsCancellation = true;
            this.bgScroller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgScroller_DoWork);
            // 
            // XnaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.graphicsControl);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.toolStrip);
            this.Name = "XnaViewer";
            this.Size = new System.Drawing.Size(502, 452);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
    }
}
