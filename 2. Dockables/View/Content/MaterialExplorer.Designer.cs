namespace EGMGame.Docking.Explorers
{
    partial class MaterialExplorer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Folder 2", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Example", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialExplorer));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.explorerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAsTileautocollisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.materialPreview = new EGMGame.Controls.MaterialViewer();
            this.materialsList = new EGMGame.TreeViewMS();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.btnImportFolder = new System.Windows.Forms.ToolStripButton();
            this.btnImportFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddFolder = new System.Windows.Forms.ToolStripButton();
            this.bwImport = new System.ComponentModel.BackgroundWorker();
            this.audioImporter = new System.ComponentModel.BackgroundWorker();
            this.explorerMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNG(*.png)|*.png|BMP(*.bmp)|*.bmp|BMP Font(*.bmpfont)|*.bmpfont|MP3(*.mp3)|*.mp3|" +
                "WAV(*.wav)|*.wav|WMA(*.wma)|*.wma";
            this.openFileDialog.Multiselect = true;
            // 
            // explorerMenu
            // 
            this.explorerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToAnimationToolStripMenuItem,
            this.addToFontToolStripMenuItem,
            this.addToAudioToolStripMenuItem,
            this.addToTilesetToolStripMenuItem,
            this.addAsTileautocollisionToolStripMenuItem,
            this.toolStripSeparator7,
            this.toolStripMenuItem1,
            this.importFolderToolStripMenuItem,
            this.importFontToolStripMenuItem,
            this.toolStripSeparator5,
            this.addFolderToolStripMenuItem,
            this.toolStripSeparator6,
            this.renameToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.deleteFolderToolStripMenuItem});
            this.explorerMenu.Name = "explorerMenu";
            this.explorerMenu.Size = new System.Drawing.Size(219, 320);
            this.explorerMenu.Opening += new System.ComponentModel.CancelEventHandler(this.explorerMenu_Opening);
            // 
            // addToAnimationToolStripMenuItem
            // 
            this.addToAnimationToolStripMenuItem.Name = "addToAnimationToolStripMenuItem";
            this.addToAnimationToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addToAnimationToolStripMenuItem.Text = "Add To Animation";
            this.addToAnimationToolStripMenuItem.Visible = false;
            this.addToAnimationToolStripMenuItem.Click += new System.EventHandler(this.addToAnimationToolStripMenuItem_Click);
            // 
            // addToFontToolStripMenuItem
            // 
            this.addToFontToolStripMenuItem.Name = "addToFontToolStripMenuItem";
            this.addToFontToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addToFontToolStripMenuItem.Text = "Add To Font";
            this.addToFontToolStripMenuItem.Visible = false;
            this.addToFontToolStripMenuItem.Click += new System.EventHandler(this.addToFontToolStripMenuItem_Click);
            // 
            // addToAudioToolStripMenuItem
            // 
            this.addToAudioToolStripMenuItem.Name = "addToAudioToolStripMenuItem";
            this.addToAudioToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addToAudioToolStripMenuItem.Text = "Add To Audio";
            this.addToAudioToolStripMenuItem.Visible = false;
            this.addToAudioToolStripMenuItem.Click += new System.EventHandler(this.addToAudioToolStripMenuItem_Click);
            // 
            // addToTilesetToolStripMenuItem
            // 
            this.addToTilesetToolStripMenuItem.Name = "addToTilesetToolStripMenuItem";
            this.addToTilesetToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addToTilesetToolStripMenuItem.Text = "Add To Tileset";
            this.addToTilesetToolStripMenuItem.Visible = false;
            this.addToTilesetToolStripMenuItem.Click += new System.EventHandler(this.addToTilesetToolStripMenuItem_Click);
            // 
            // addAsTileautocollisionToolStripMenuItem
            // 
            this.addAsTileautocollisionToolStripMenuItem.Name = "addAsTileautocollisionToolStripMenuItem";
            this.addAsTileautocollisionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addAsTileautocollisionToolStripMenuItem.Text = "Add As Tile (auto-collision)";
            this.addAsTileautocollisionToolStripMenuItem.Visible = false;
            this.addAsTileautocollisionToolStripMenuItem.Click += new System.EventHandler(this.addAsTileautocollisionToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(215, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::EGMGame.Properties.Resources.document_import;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+I";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItem1.Text = "Import...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // importFolderToolStripMenuItem
            // 
            this.importFolderToolStripMenuItem.Image = global::EGMGame.Properties.Resources.folder_open_image;
            this.importFolderToolStripMenuItem.Name = "importFolderToolStripMenuItem";
            this.importFolderToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.importFolderToolStripMenuItem.Text = "Import Folder";
            this.importFolderToolStripMenuItem.Click += new System.EventHandler(this.btnImportFolder_Click);
            // 
            // importFontToolStripMenuItem
            // 
            this.importFontToolStripMenuItem.Image = global::EGMGame.Properties.Resources.font;
            this.importFontToolStripMenuItem.Name = "importFontToolStripMenuItem";
            this.importFontToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.importFontToolStripMenuItem.Text = "Import Font";
            this.importFontToolStripMenuItem.Click += new System.EventHandler(this.btnImportFont_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(215, 6);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::EGMGame.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(215, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::EGMGame.Properties.Resources.textfield_rename;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(215, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::EGMGame.Properties.Resources.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.clipboard_paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(215, 6);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            this.deleteFolderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.deleteFolderToolStripMenuItem.Text = "Delete";
            this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.materialPreview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.materialsList);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(282, 538);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 2;
            // 
            // materialPreview
            // 
            this.materialPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialPreview.Location = new System.Drawing.Point(0, 0);
            this.materialPreview.Name = "materialPreview";
            this.materialPreview.SelectedMaterial = null;
            this.materialPreview.Size = new System.Drawing.Size(278, 144);
            this.materialPreview.TabIndex = 1;
            // 
            // materialsList
            // 
            this.materialsList.AllowDrop = true;
            this.materialsList.ContextMenuStrip = this.explorerMenu;
            this.materialsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsList.ImageIndex = 0;
            this.materialsList.ImageList = this.imageList;
            this.materialsList.Location = new System.Drawing.Point(0, 25);
            this.materialsList.Name = "materialsList";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Node3";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Folder 2";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Example";
            this.materialsList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.materialsList.SelectedImageIndex = 0;
            this.materialsList.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("materialsList.SelectedNodes")));
            this.materialsList.Size = new System.Drawing.Size(278, 357);
            this.materialsList.TabIndex = 1;
            this.materialsList.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.explorerList_AfterLabelEdit);
            this.materialsList.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.explorerList_AfterCollapse);
            this.materialsList.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.explorerList_AfterExpand);
            this.materialsList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.explorerList_ItemDrag_1);
            this.materialsList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.explorerList_AfterSelect);
            this.materialsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.explorerList_DragDrop);
            this.materialsList.DragEnter += new System.Windows.Forms.DragEventHandler(this.explorerList_DragEnter);
            this.materialsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.explorerList_MouseDoubleClick);
            this.materialsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.explorerList_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "folder-open.png");
            this.imageList.Images.SetKeyName(2, "document.png");
            this.imageList.Images.SetKeyName(3, "document-image.png");
            this.imageList.Images.SetKeyName(4, "document-text.png");
            this.imageList.Images.SetKeyName(5, "folder-zipper.png");
            this.imageList.Images.SetKeyName(6, "document_gear.png");
            this.imageList.Images.SetKeyName(7, "document-music.png");
            this.imageList.Images.SetKeyName(8, "document-film.png");
            this.imageList.Images.SetKeyName(9, "document-c-sharp2.png");
            this.imageList.Images.SetKeyName(10, "document-xml.png");
            this.imageList.Images.SetKeyName(11, "document-pdf-text.png");
            this.imageList.Images.SetKeyName(12, "application-sidebar.png");
            this.imageList.Images.SetKeyName(13, "document-code.png");
            this.imageList.Images.SetKeyName(14, "document-table.png");
            this.imageList.Images.SetKeyName(15, "document_edit.png");
            this.imageList.Images.SetKeyName(16, "exclamation.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.btnImportFolder,
            this.btnImportFont,
            this.toolStripSeparator1,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnAddFolder});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(278, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImport.Image = global::EGMGame.Properties.Resources.document_import;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(23, 22);
            this.btnImport.Text = "Import File";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnImportFolder
            // 
            this.btnImportFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportFolder.Image = global::EGMGame.Properties.Resources.folder_open_image;
            this.btnImportFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportFolder.Name = "btnImportFolder";
            this.btnImportFolder.Size = new System.Drawing.Size(23, 22);
            this.btnImportFolder.Text = "Import Folder";
            this.btnImportFolder.Click += new System.EventHandler(this.btnImportFolder_Click);
            // 
            // btnImportFont
            // 
            this.btnImportFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportFont.Image = global::EGMGame.Properties.Resources.font;
            this.btnImportFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportFont.Name = "btnImportFont";
            this.btnImportFont.Size = new System.Drawing.Size(23, 22);
            this.btnImportFont.Text = "Create Font";
            this.btnImportFont.Click += new System.EventHandler(this.btnImportFont_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::EGMGame.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Remove Selected";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFolder.Image = global::EGMGame.Properties.Resources.folder_add;
            this.btnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(23, 22);
            this.btnAddFolder.Text = "Add Folder";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // bwImport
            // 
            this.bwImport.WorkerReportsProgress = true;
            this.bwImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImport_DoWork);
            this.bwImport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwImport_ProgressChanged);
            this.bwImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwImport_RunWorkerCompleted);
            // 
            // audioImporter
            // 
            this.audioImporter.WorkerReportsProgress = true;
            this.audioImporter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.audioImporter_DoWork);
            this.audioImporter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.audioImporter_ProgressChanged);
            this.audioImporter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.audioImporter_RunWorkerCompleted);
            // 
            // MaterialExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(282, 538);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide;
            this.TabText = "Materials";
            this.Text = "Materials";
            this.explorerMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.ContextMenuStrip explorerMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private Controls.MaterialViewer materialPreview;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TreeViewMS materialsList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAddFolder;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bwImport;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnImportFolder;
        private System.Windows.Forms.ToolStripMenuItem importFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnImportFont;
        private System.Windows.Forms.ToolStripMenuItem addToFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToAudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem addToAnimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAsTileautocollisionToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker audioImporter;
    }
}