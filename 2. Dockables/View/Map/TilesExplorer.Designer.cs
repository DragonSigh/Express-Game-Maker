namespace EGMGame.Docking.Explorers
{
    partial class TilesExplorer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilesExplorer));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.cbTileset = new System.Windows.Forms.ToolStripComboBox();
            this.gridBtn = new System.Windows.Forms.ToolStripButton();
            this.btnEditTileset = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.autoTileViewer1 = new EGMGame.Controls.AutoTileViewer();
            this.tileViewer = new EGMGame.Controls.TileViewer();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbTileset,
            this.gridBtn,
            this.btnEditTileset});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(239, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // cbTileset
            // 
            this.cbTileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTileset.Enabled = false;
            this.cbTileset.Name = "cbTileset";
            this.cbTileset.Size = new System.Drawing.Size(121, 25);
            this.cbTileset.SelectedIndexChanged += new System.EventHandler(this.cbTileset_SelectedIndexChanged);
            // 
            // gridBtn
            // 
            this.gridBtn.Checked = true;
            this.gridBtn.CheckOnClick = true;
            this.gridBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gridBtn.Image = global::EGMGame.Properties.Resources.grid;
            this.gridBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gridBtn.Name = "gridBtn";
            this.gridBtn.Size = new System.Drawing.Size(23, 22);
            this.gridBtn.Text = "Switch Between Tileset and Tiles";
            this.gridBtn.CheckedChanged += new System.EventHandler(this.gridBtn_CheckedChanged);
            // 
            // btnEditTileset
            // 
            this.btnEditTileset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditTileset.Image = global::EGMGame.Properties.Resources.document_prepare;
            this.btnEditTileset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditTileset.Name = "btnEditTileset";
            this.btnEditTileset.Size = new System.Drawing.Size(23, 22);
            this.btnEditTileset.Text = "Edit Tileset";
            this.btnEditTileset.Click += new System.EventHandler(this.btnEditTileset_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.autoTileViewer1);
            this.splitContainer1.Panel1MinSize = 1;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tileViewer);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Panel2MinSize = 1;
            this.splitContainer1.Size = new System.Drawing.Size(239, 425);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 3;
            // 
            // autoTileViewer1
            // 
            this.autoTileViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoTileViewer1.GridHeight = 32;
            this.autoTileViewer1.GridWidth = 32;
            this.autoTileViewer1.Location = new System.Drawing.Point(0, 0);
            this.autoTileViewer1.Name = "autoTileViewer1";
            this.autoTileViewer1.SelectedTileset = null;
            this.autoTileViewer1.Size = new System.Drawing.Size(235, 21);
            this.autoTileViewer1.TabIndex = 0;
            this.autoTileViewer1.Load += new System.EventHandler(this.autoTileViewer1_Load);
            // 
            // tileViewer
            // 
            this.tileViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileViewer.GridHeight = 32;
            this.tileViewer.GridWidth = 32;
            this.tileViewer.Location = new System.Drawing.Point(0, 0);
            this.tileViewer.Name = "tileViewer";
            this.tileViewer.SelectedCategory = 0;
            this.tileViewer.SelectedTileset = null;
            this.tileViewer.Size = new System.Drawing.Size(235, 392);
            this.tileViewer.TabIndex = 2;
            this.tileViewer.TilesetView = true;
            // 
            // TilesExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TilesExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "Tiles";
            this.Text = "Tiles";
            this.DockStateChanged += new System.EventHandler(this.Explorer_DockStateChanged);
            this.DockChanged += new System.EventHandler(this.TilesExplorer_DockChanged);
            this.EnabledChanged += new System.EventHandler(this.TilesExplorer_EnabledChanged);
            this.VisibleChanged += new System.EventHandler(this.Explorer_VisibleChanged);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton gridBtn;
        internal System.Windows.Forms.ToolStripComboBox cbTileset;
        internal EGMGame.Controls.TileViewer tileViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public Controls.AutoTileViewer autoTileViewer1;
        private System.Windows.Forms.ToolStripButton btnEditTileset;

    }
}