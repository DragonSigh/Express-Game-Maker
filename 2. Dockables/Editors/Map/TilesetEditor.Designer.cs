namespace EGMGame.Docking.Editors
{
    partial class TilesetEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilesetEditor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddTile = new System.Windows.Forms.Button();
            this.autotileList = new EGMGame.Controls.AddRemoveList();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAutoTileAreas = new System.Windows.Forms.ComboBox();
            this.autoTileViewer = new EGMGame.Controls.AutoTileEditor();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.fitToImagebtn = new System.Windows.Forms.Button();
            this.colBox = new EGMGame.CustomUpDown();
            this.rowBox = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.tilesetViewer = new EGMGame.Controls.TilesetViewer();
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(479, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(198, 458);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.propertyGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(190, 432);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(184, 426);
            this.propertyGrid.TabIndex = 2;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddTile);
            this.tabPage2.Controls.Add(this.autotileList);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbAutoTileAreas);
            this.tabPage2.Controls.Add(this.autoTileViewer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(190, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Autotiles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddTile
            // 
            this.btnAddTile.Enabled = false;
            this.btnAddTile.Image = global::EGMGame.Properties.Resources.add;
            this.btnAddTile.Location = new System.Drawing.Point(3, 204);
            this.btnAddTile.Name = "btnAddTile";
            this.btnAddTile.Size = new System.Drawing.Size(181, 24);
            this.btnAddTile.TabIndex = 7;
            this.btnAddTile.Text = "Set as selected tile.";
            this.btnAddTile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTile.UseVisualStyleBackColor = true;
            this.btnAddTile.Click += new System.EventHandler(this.btnAddTile_Click);
            // 
            // autotileList
            // 
            this.autotileList.AllowAdd = true;
            this.autotileList.AllowCategories = false;
            this.autotileList.AllowClipboard = true;
            this.autotileList.AllowRemove = true;
            this.autotileList.BackgroundImage = global::EGMGame.Properties.Resources.anchor_circle;
            this.autotileList.DisplayToolbar = false;
            this.autotileList.Dock = System.Windows.Forms.DockStyle.Top;
            this.autotileList.Enabled = false;
            this.autotileList.EnableUpDown = false;
            this.autotileList.Export = true;
            this.autotileList.ImageList = null;
            this.autotileList.Import = true;
            this.autotileList.Location = new System.Drawing.Point(3, 3);
            this.autotileList.Master = false;
            this.autotileList.MultipleSelection = false;
            this.autotileList.Name = "autotileList";
            this.autotileList.SelectedIndex = -1;
            this.autotileList.ShowWarning = true;
            this.autotileList.Size = new System.Drawing.Size(184, 158);
            this.autotileList.TabIndex = 6;
            this.autotileList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.autotileList_AddItem);
            this.autotileList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.autotileList_RemoveItem);
            this.autotileList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.autotileList_SelectItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select the tile area.";
            // 
            // cbAutoTileAreas
            // 
            this.cbAutoTileAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutoTileAreas.Enabled = false;
            this.cbAutoTileAreas.FormattingEnabled = true;
            this.cbAutoTileAreas.Items.AddRange(new object[] {
            "Center",
            "Top",
            "Bottom",
            "Left",
            "Right",
            "Upper Left",
            "Upper Right",
            "Lower Left",
            "Lower Right",
            "Upper Left Corner",
            "Upper Right Corner",
            "Lower  Left Corner",
            "Lower Rigth Corner"});
            this.cbAutoTileAreas.Location = new System.Drawing.Point(3, 180);
            this.cbAutoTileAreas.Name = "cbAutoTileAreas";
            this.cbAutoTileAreas.Size = new System.Drawing.Size(181, 21);
            this.cbAutoTileAreas.TabIndex = 2;
            this.cbAutoTileAreas.SelectedIndexChanged += new System.EventHandler(this.cbAutoTileAreas_SelectedIndexChanged);
            // 
            // autoTileViewer
            // 
            this.autoTileViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.autoTileViewer.Enabled = false;
            this.autoTileViewer.Location = new System.Drawing.Point(3, 230);
            this.autoTileViewer.Name = "autoTileViewer";
            this.autoTileViewer.Size = new System.Drawing.Size(181, 196);
            this.autoTileViewer.TabIndex = 4;
            this.autoTileViewer.Tile = null;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.defaultBtn);
            this.impactGroupBox1.Controls.Add(this.fitToImagebtn);
            this.impactGroupBox1.Controls.Add(this.colBox);
            this.impactGroupBox1.Controls.Add(this.rowBox);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(479, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(198, 88);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Grid Size";
            // 
            // defaultBtn
            // 
            this.defaultBtn.Image = global::EGMGame.Properties.Resources.grid;
            this.defaultBtn.Location = new System.Drawing.Point(104, 57);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(87, 23);
            this.defaultBtn.TabIndex = 6;
            this.defaultBtn.Text = "Default";
            this.defaultBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Click += new System.EventHandler(this.defaultBtn_Click);
            // 
            // fitToImagebtn
            // 
            this.fitToImagebtn.Image = global::EGMGame.Properties.Resources.selection;
            this.fitToImagebtn.Location = new System.Drawing.Point(104, 28);
            this.fitToImagebtn.Name = "fitToImagebtn";
            this.fitToImagebtn.Size = new System.Drawing.Size(87, 23);
            this.fitToImagebtn.TabIndex = 5;
            this.fitToImagebtn.Text = "Fit to Image";
            this.fitToImagebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.fitToImagebtn.UseVisualStyleBackColor = true;
            this.fitToImagebtn.Click += new System.EventHandler(this.fitToImagebtn_Click);
            // 
            // colBox
            // 
            this.colBox.Location = new System.Drawing.Point(48, 28);
            this.colBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colBox.Name = "colBox";
            this.colBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.colBox.OnChange = true;
            this.colBox.Size = new System.Drawing.Size(46, 20);
            this.colBox.TabIndex = 4;
            this.colBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colBox.ValueChanged += new System.EventHandler(this.colBox_ValueChanged);
            this.colBox.Validated += new System.EventHandler(this.colBox_Validated);
            // 
            // rowBox
            // 
            this.rowBox.Location = new System.Drawing.Point(48, 57);
            this.rowBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowBox.Name = "rowBox";
            this.rowBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rowBox.OnChange = true;
            this.rowBox.Size = new System.Drawing.Size(46, 20);
            this.rowBox.TabIndex = 3;
            this.rowBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowBox.ValueChanged += new System.EventHandler(this.rowBox_ValueChanged);
            this.rowBox.Validated += new System.EventHandler(this.rowBox_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox2.Controls.Add(this.tilesetViewer);
            this.groupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox2.Location = new System.Drawing.Point(142, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(331, 552);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tileset";
            // 
            // tilesetViewer
            // 
            this.tilesetViewer.AllowMultiSelect = true;
            this.tilesetViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilesetViewer.GridHeight = 32;
            this.tilesetViewer.GridWidth = 32;
            this.tilesetViewer.Location = new System.Drawing.Point(4, 25);
            this.tilesetViewer.Name = "tilesetViewer";
            this.tilesetViewer.SelectedTileset = null;
            this.tilesetViewer.Size = new System.Drawing.Size(323, 522);
            this.tilesetViewer.TabIndex = 0;
            this.tilesetViewer.Tip = "";
            this.tilesetViewer.TileSelectedEvent += new EGMGame.Controls.TilesetViewer.TileSelectedHandler(this.tilesetViewer_TileSelectedEvent);
            this.tilesetViewer.DragDrop += new System.Windows.Forms.DragEventHandler(this.tilesetViewer_DragDrop);
            this.tilesetViewer.DragEnter += new System.Windows.Forms.DragEventHandler(this.tilesetViewer_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox1.Controls.Add(this.addRemoveList);
            this.groupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(124, 555);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tilesets";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowClipboard = true;
            this.addRemoveList.AllowRemove = true;
            this.addRemoveList.DisplayToolbar = true;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.Export = true;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Import = true;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = true;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(116, 525);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // TilesetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(685, 579);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TilesetEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Tileset Editor";
            this.Text = "Tileset Editor";
            this.Activated += new System.EventHandler(this.TilesetEditor_Activated);
            this.Shown += new System.EventHandler(this.TilesetEditor_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        internal EGMGame.Controls.TilesetViewer tilesetViewer;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal CustomUpDown colBox;
        internal CustomUpDown rowBox;
        private System.Windows.Forms.Button fitToImagebtn;
        private System.Windows.Forms.Button defaultBtn;
        internal Controls.AddRemoveList addRemoveList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbAutoTileAreas;
        private System.Windows.Forms.Label label1;
        private Controls.AutoTileEditor autoTileViewer;
        private Controls.AddRemoveList autotileList;
        private System.Windows.Forms.Button btnAddTile;
        private Controls.UI.DockContextMenu dockContextMenu1;
    }
}