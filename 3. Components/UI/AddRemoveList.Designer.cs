namespace EGMGame.Controls
{
    partial class AddRemoveList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRemoveList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addCategoryBtn = new System.Windows.Forms.ToolStripButton();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.lblID = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSImportExport = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSclipBoard = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFind = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.listBox = new EGMGame.Controls.AddRemoveListTreeView();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tsSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBtn,
            this.toolStripSeparator1,
            this.removeBtn,
            this.toolStripSeparator2,
            this.addCategoryBtn,
            this.tsbUp,
            this.tsbDown,
            this.toolStripSeparator6,
            this.lblID});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(185, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // addBtn
            // 
            this.addBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBtn.Image = global::EGMGame.Properties.Resources.add;
            this.addBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(23, 22);
            this.addBtn.Text = "Add";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // removeBtn
            // 
            this.removeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeBtn.Image = global::EGMGame.Properties.Resources.delete;
            this.removeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(23, 22);
            this.removeBtn.Text = "toolStripButton2";
            this.removeBtn.ToolTipText = "Remove";
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // addCategoryBtn
            // 
            this.addCategoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.addCategoryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCategoryBtn.Image = global::EGMGame.Properties.Resources.folder_add;
            this.addCategoryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCategoryBtn.Name = "addCategoryBtn";
            this.addCategoryBtn.Size = new System.Drawing.Size(23, 22);
            this.addCategoryBtn.Text = "Add Category";
            this.addCategoryBtn.Click += new System.EventHandler(this.addCategoryBtn_Click);
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUp.Image = global::EGMGame.Properties.Resources.arrow_down;
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(23, 22);
            this.tsbUp.Text = "Move Up";
            this.tsbUp.Visible = false;
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // tsbDown
            // 
            this.tsbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDown.Image = global::EGMGame.Properties.Resources.arrow_up;
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(23, 22);
            this.tsbDown.Text = "Move Down";
            this.tsbDown.Visible = false;
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // lblID
            // 
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(48, 22);
            this.lblID.Text = "ID: NaN";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.tSImportExport,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.tSclipBoard,
            this.duplicateToolStripMenuItem,
            this.copuToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.tsFind,
            this.findToolStripMenuItem,
            this.toolStripSeparator5,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 226);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::EGMGame.Properties.Resources.textfield_rename;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // tSImportExport
            // 
            this.tSImportExport.Name = "tSImportExport";
            this.tSImportExport.Size = new System.Drawing.Size(149, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::EGMGame.Properties.Resources.document_import;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::EGMGame.Properties.Resources.document_export;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // tSclipBoard
            // 
            this.tSclipBoard.Name = "tSclipBoard";
            this.tSclipBoard.Size = new System.Drawing.Size(149, 6);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Image = global::EGMGame.Properties.Resources.document_copy;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // copuToolStripMenuItem
            // 
            this.copuToolStripMenuItem.Image = global::EGMGame.Properties.Resources.document_copy;
            this.copuToolStripMenuItem.Name = "copuToolStripMenuItem";
            this.copuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copuToolStripMenuItem.Text = "Copy";
            this.copuToolStripMenuItem.Click += new System.EventHandler(this.copuToolStripMenuItem_Click);
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
            // tsFind
            // 
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(149, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.CheckOnClick = true;
            this.findToolStripMenuItem.Image = global::EGMGame.Properties.Resources.ui_search_field;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.CheckedChanged += new System.EventHandler(this.findToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Export Data";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Import Data";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // tsSearch
            // 
            this.tsSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch});
            this.tsSearch.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsSearch.Location = new System.Drawing.Point(0, 0);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Size = new System.Drawing.Size(185, 23);
            this.tsSearch.TabIndex = 3;
            this.tsSearch.Text = "Search";
            this.tsSearch.Visible = false;
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.BackColor = System.Drawing.Color.White;
            this.listBox.Category = false;
            this.listBox.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.listBox.FullRowSelect = true;
            this.listBox.HideSelection = false;
            this.listBox.ImageIndex = 0;
            this.listBox.ImageList = this.imageList1;
            this.listBox.Indent = 9;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.MultipleSelection = false;
            this.listBox.Name = "listBox";
            this.listBox.SelectedImageIndex = 0;
            this.listBox.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("listBox.SelectedNodes")));
            this.listBox.ShowLines = false;
            this.listBox.Size = new System.Drawing.Size(185, 318);
            this.listBox.TabIndex = 2;
            this.listBox.ToolboxCategoryBackColor = System.Drawing.Color.White;
            this.listBox.ToolboxCategoryOffset = new System.Drawing.Point(20, 2);
            this.listBox.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            this.listBox.ToolboxCollapsedImage = global::EGMGame.Properties.Resources.plus16;
            this.listBox.ToolboxCollapsedImageOffset = new System.Drawing.Point(5, 4);
            this.listBox.ToolboxExpandedImage = global::EGMGame.Properties.Resources.minus16;
            this.listBox.ToolboxExpandedImageOffset = new System.Drawing.Point(5, 4);
            this.listBox.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.listBox_AfterLabelEdit);
            this.listBox.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.listBox_BeforeCollapse);
            this.listBox.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.listBox_AfterCollapse);
            this.listBox.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.listBox_BeforeExpand);
            this.listBox.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.listBox_AfterExpand);
            this.listBox.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listBox_ItemDrag);
            this.listBox.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.listbox_AfterSelect);
            this.listBox.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.listBox_NodeMouseDoubleClick);
            this.listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox_DragOver);
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
            this.listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // AddRemoveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tsSearch);
            this.DoubleBuffered = true;
            this.Name = "AddRemoveList";
            this.Size = new System.Drawing.Size(185, 343);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tsSearch.ResumeLayout(false);
            this.tsSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton addCategoryBtn;
        public System.Windows.Forms.ToolStripButton addBtn;
        internal System.Windows.Forms.ToolStripButton removeBtn;
        internal AddRemoveListTreeView listBox;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tSclipBoard;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tSImportExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel lblID;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem copuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tsFind;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStrip tsSearch;
    }
}
