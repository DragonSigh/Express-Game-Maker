namespace EGMGame.Controls
{
    partial class LayeredAddRemoveList
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayeredAddRemoveList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.listBox = new EGMGame.Controls.AddRemoveListTreeView();
            this.addBtn = new System.Windows.Forms.ToolStripButton();
            this.removeBtn = new System.Windows.Forms.ToolStripButton();
            this.moveUpBtn = new System.Windows.Forms.ToolStripButton();
            this.moveDownBtn = new System.Windows.Forms.ToolStripButton();
            this.btnLayerMovement = new System.Windows.Forms.ToolStripButton();
            this.btnLayerTint = new System.Windows.Forms.ToolStripButton();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.moveUpBtn,
            this.moveDownBtn,
            this.toolStripSeparator4,
            this.btnLayerMovement,
            this.btnLayerTint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(197, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 54);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(114, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.White;
            this.listBox.Category = false;
            this.listBox.CheckBoxes = true;
            this.listBox.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.listBox.FullRowSelect = true;
            this.listBox.HideSelection = false;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.MultipleSelection = false;
            this.listBox.Name = "listBox";
            treeNode1.Name = "Node0";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode1.Text = "Node0";
            this.listBox.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.listBox.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("listBox.SelectedNodes")));
            this.listBox.ShowLines = false;
            this.listBox.ShowPlusMinus = false;
            this.listBox.ShowRootLines = false;
            this.listBox.Size = new System.Drawing.Size(197, 318);
            this.listBox.TabIndex = 2;
            this.listBox.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            this.listBox.ToolboxCategoryOffset = new System.Drawing.Point(0, 0);
            this.listBox.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            this.listBox.ToolboxCollapsedImage = global::EGMGame.Properties.Resources.checkBox;
            this.listBox.ToolboxCollapsedImageOffset = new System.Drawing.Point(5, 2);
            this.listBox.ToolboxExpandedImage = global::EGMGame.Properties.Resources.checkboxChecked;
            this.listBox.ToolboxExpandedImageOffset = new System.Drawing.Point(5, 2);
            this.listBox.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.listBox_AfterLabelEdit);
            this.listBox.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.listBox_AfterCheck);
            this.listBox.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.listbox_AfterSelect);
            this.listBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseClick);
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
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
            // moveUpBtn
            // 
            this.moveUpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpBtn.Image = global::EGMGame.Properties.Resources.navigation_up;
            this.moveUpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpBtn.Name = "moveUpBtn";
            this.moveUpBtn.Size = new System.Drawing.Size(23, 22);
            this.moveUpBtn.Text = "Move Up";
            this.moveUpBtn.Click += new System.EventHandler(this.moveUpBtn_Click);
            // 
            // moveDownBtn
            // 
            this.moveDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownBtn.Image = global::EGMGame.Properties.Resources.navigation_down;
            this.moveDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownBtn.Name = "moveDownBtn";
            this.moveDownBtn.Size = new System.Drawing.Size(23, 22);
            this.moveDownBtn.Text = "Move Down";
            this.moveDownBtn.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // btnLayerMovement
            // 
            this.btnLayerMovement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayerMovement.Image = global::EGMGame.Properties.Resources.transform_layer;
            this.btnLayerMovement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayerMovement.Name = "btnLayerMovement";
            this.btnLayerMovement.Size = new System.Drawing.Size(23, 22);
            this.btnLayerMovement.Text = "Layer Movement Settings";
            this.btnLayerMovement.Click += new System.EventHandler(this.btnLayerMovement_Click);
            // 
            // btnLayerTint
            // 
            this.btnLayerTint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayerTint.Image = global::EGMGame.Properties.Resources.color_wheel;
            this.btnLayerTint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayerTint.Name = "btnLayerTint";
            this.btnLayerTint.Size = new System.Drawing.Size(23, 22);
            this.btnLayerTint.Text = "Tint Layer";
            this.btnLayerTint.Click += new System.EventHandler(this.btnLayerTint_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::EGMGame.Properties.Resources.textfield_rename;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // LayeredAddRemoveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LayeredAddRemoveList";
            this.Size = new System.Drawing.Size(197, 343);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton removeBtn;
        private AddRemoveListTreeView listBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton moveDownBtn;
        private System.Windows.Forms.ToolStripButton moveUpBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnLayerTint;
        private System.Windows.Forms.ToolStripButton btnLayerMovement;
    }
}
