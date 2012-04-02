namespace EGMGame.Controls
{
    partial class AnimationViewer
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
            this.tsmZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblZoom = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
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
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZoomIn,
            this.tsbZoomOut,
            this.tsbZoom,
            this.toolStripSeparator1,
            this.lblZoom,
            this.toolStripSeparator2,
            this.btnPlay});
            this.toolStrip2.Location = new System.Drawing.Point(0, 334);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(348, 25);
            this.toolStrip2.TabIndex = 40;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Enabled = false;
            this.hScrollBar.LargeChange = 2;
            this.hScrollBar.Location = new System.Drawing.Point(0, 317);
            this.hScrollBar.Maximum = 1;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(348, 17);
            this.hScrollBar.TabIndex = 41;
            this.hScrollBar.Visible = false;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Enabled = false;
            this.vScrollBar.LargeChange = 2;
            this.vScrollBar.Location = new System.Drawing.Point(331, 0);
            this.vScrollBar.Maximum = 1;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 317);
            this.vScrollBar.TabIndex = 42;
            this.vScrollBar.Visible = false;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // graphicsControl
            // 
            this.graphicsControl.AllowDrop = true;
            this.graphicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl.Location = new System.Drawing.Point(0, 0);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(331, 317);
            this.graphicsControl.TabIndex = 43;
            this.graphicsControl.Text = "graphicsControl";
            this.graphicsControl.OnDraw += new System.EventHandler(this.graphicsControl_OnDraw);
            this.graphicsControl.OnInitialize += new System.EventHandler(this.graphicsControl_OnInitialize);
            this.graphicsControl.Resize += new System.EventHandler(this.graphicsControl_Resize);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPlay
            // 
            this.btnPlay.CheckOnClick = true;
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = global::EGMGame.Properties.Resources.control_play;
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(23, 22);
            this.btnPlay.Text = "Play Animation";
            this.btnPlay.Visible = false;
            this.btnPlay.CheckedChanged += new System.EventHandler(this.btnPlay_CheckedChanged);
            // 
            // AnimationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.graphicsControl);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.toolStrip2);
            this.Name = "AnimationViewer";
            this.Size = new System.Drawing.Size(348, 359);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmZoom200;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom100;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom50;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom25;
        private System.Windows.Forms.ToolStripDropDownButton tsbZoom;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblZoom;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
        internal SimpleGraphicsControl graphicsControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPlay;
    }
}
