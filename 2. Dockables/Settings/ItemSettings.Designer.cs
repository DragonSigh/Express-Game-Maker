namespace EGMGame.Docking.Settings
{
    partial class ItemSettingsForm
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
            System.Windows.Forms.ToolStripButton removeBtnEquip;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSettingsForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listBoxEquip = new EGMGame.Controls.AddRemoveListTreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addBtnEquip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.listBoxElem = new EGMGame.Controls.AddRemoveListTreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.addBtnElem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeBtnElem = new System.Windows.Forms.ToolStripButton();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            removeBtnEquip = new System.Windows.Forms.ToolStripButton();
            this.impactGroupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // removeBtnEquip
            // 
            removeBtnEquip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            removeBtnEquip.Image = ((System.Drawing.Image)(resources.GetObject("removeBtnEquip.Image")));
            removeBtnEquip.ImageTransparentColor = System.Drawing.Color.Magenta;
            removeBtnEquip.Name = "removeBtnEquip";
            removeBtnEquip.Size = new System.Drawing.Size(23, 22);
            removeBtnEquip.Text = "toolStripButton2";
            removeBtnEquip.ToolTipText = "Remove";
            removeBtnEquip.Click += new System.EventHandler(this.removeBtnEquip_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ico";
            this.openFileDialog.Filter = "Icon|*.ico";
            this.openFileDialog.Title = "Choose Icon";
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.Controls.Add(this.listBoxEquip);
            this.impactGroupBox4.Controls.Add(this.toolStrip1);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Location = new System.Drawing.Point(11, 11);
            this.impactGroupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(3, 9, 3, 4);
            this.impactGroupBox4.Size = new System.Drawing.Size(117, 365);
            this.impactGroupBox4.TabIndex = 5;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Equipments";
            this.impactGroupBox4.Enter += new System.EventHandler(this.impactGroupBox4_Enter);
            // 
            // listBoxEquip
            // 
            this.listBoxEquip.AllowDrop = true;
            this.listBoxEquip.BackColor = System.Drawing.Color.White;
            this.listBoxEquip.Category = false;
            this.listBoxEquip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEquip.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.listBoxEquip.FullRowSelect = true;
            this.listBoxEquip.HideSelection = false;
            this.listBoxEquip.Indent = 5;
            this.listBoxEquip.ItemHeight = 20;
            this.listBoxEquip.Location = new System.Drawing.Point(3, 47);
            this.listBoxEquip.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxEquip.MultipleSelection = false;
            this.listBoxEquip.Name = "listBoxEquip";
            this.listBoxEquip.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("listBoxEquip.SelectedNodes")));
            this.listBoxEquip.ShowLines = false;
            this.listBoxEquip.Size = new System.Drawing.Size(111, 314);
            this.listBoxEquip.TabIndex = 18;
            this.listBoxEquip.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            this.listBoxEquip.ToolboxCategoryOffset = new System.Drawing.Point(0, 0);
            this.listBoxEquip.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            this.listBoxEquip.ToolboxCollapsedImage = null;
            this.listBoxEquip.ToolboxCollapsedImageOffset = new System.Drawing.Point(0, 0);
            this.listBoxEquip.ToolboxExpandedImage = null;
            this.listBoxEquip.ToolboxExpandedImageOffset = new System.Drawing.Point(0, 0);
            this.listBoxEquip.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.listBoxEquip_AfterLabelEdit);
            this.listBoxEquip.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.listBoxEquip_NodeMouseDoubleClick);
            this.listBoxEquip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxEquip_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBtnEquip,
            this.toolStripSeparator1,
            removeBtnEquip});
            this.toolStrip1.Location = new System.Drawing.Point(3, 22);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 17;
            // 
            // addBtnEquip
            // 
            this.addBtnEquip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBtnEquip.Image = ((System.Drawing.Image)(resources.GetObject("addBtnEquip.Image")));
            this.addBtnEquip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBtnEquip.Name = "addBtnEquip";
            this.addBtnEquip.Size = new System.Drawing.Size(23, 22);
            this.addBtnEquip.Text = "Add";
            this.addBtnEquip.Click += new System.EventHandler(this.addBtnEquip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // listBoxElem
            // 
            this.listBoxElem.AllowDrop = true;
            this.listBoxElem.BackColor = System.Drawing.Color.White;
            this.listBoxElem.Category = false;
            this.listBoxElem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxElem.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.listBoxElem.FullRowSelect = true;
            this.listBoxElem.HideSelection = false;
            this.listBoxElem.Indent = 5;
            this.listBoxElem.ItemHeight = 20;
            this.listBoxElem.Location = new System.Drawing.Point(3, 47);
            this.listBoxElem.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxElem.MultipleSelection = false;
            this.listBoxElem.Name = "listBoxElem";
            this.listBoxElem.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("listBoxElem.SelectedNodes")));
            this.listBoxElem.ShowLines = false;
            this.listBoxElem.Size = new System.Drawing.Size(111, 314);
            this.listBoxElem.TabIndex = 18;
            this.listBoxElem.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            this.listBoxElem.ToolboxCategoryOffset = new System.Drawing.Point(0, 0);
            this.listBoxElem.ToolboxChildImageOffset = new System.Drawing.Point(0, 0);
            this.listBoxElem.ToolboxCollapsedImage = null;
            this.listBoxElem.ToolboxCollapsedImageOffset = new System.Drawing.Point(0, 0);
            this.listBoxElem.ToolboxExpandedImage = null;
            this.listBoxElem.ToolboxExpandedImageOffset = new System.Drawing.Point(0, 0);
            this.listBoxElem.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.listBoxElem_AfterLabelEdit);
            this.listBoxElem.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.listBoxElem_NodeMouseDoubleClick);
            this.listBoxElem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxElem_MouseDown);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBtnElem,
            this.toolStripSeparator2,
            this.removeBtnElem});
            this.toolStrip2.Location = new System.Drawing.Point(3, 22);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(111, 25);
            this.toolStrip2.TabIndex = 17;
            // 
            // addBtnElem
            // 
            this.addBtnElem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBtnElem.Image = ((System.Drawing.Image)(resources.GetObject("addBtnElem.Image")));
            this.addBtnElem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBtnElem.Name = "addBtnElem";
            this.addBtnElem.Size = new System.Drawing.Size(23, 22);
            this.addBtnElem.Text = "Add";
            this.addBtnElem.Click += new System.EventHandler(this.addBtnElem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // removeBtnElem
            // 
            this.removeBtnElem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeBtnElem.Image = ((System.Drawing.Image)(resources.GetObject("removeBtnElem.Image")));
            this.removeBtnElem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeBtnElem.Name = "removeBtnElem";
            this.removeBtnElem.Size = new System.Drawing.Size(23, 22);
            this.removeBtnElem.Text = "toolStripButton2";
            this.removeBtnElem.ToolTipText = "Remove";
            this.removeBtnElem.Click += new System.EventHandler(this.removeBtnElem_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.listBoxElem);
            this.impactGroupBox1.Controls.Add(this.toolStrip2);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(132, 11);
            this.impactGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(3, 9, 3, 4);
            this.impactGroupBox1.Size = new System.Drawing.Size(117, 365);
            this.impactGroupBox1.TabIndex = 17;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Elements";
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // ItemSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(616, 387);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.impactGroupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ItemSettingsForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Settings";
            this.DockStateChanged += new System.EventHandler(this.SettingsForm_DockStateChanged);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.DockChanged += new System.EventHandler(this.SettingsForm_DockChanged);
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        internal EGMGame.Controls.AddRemoveListTreeView listBoxElem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        public System.Windows.Forms.ToolStripButton addBtnElem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton removeBtnElem;
        internal EGMGame.Controls.AddRemoveListTreeView listBoxEquip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton addBtnEquip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private Controls.UI.DockContextMenu dockContextMenu1;
    }
}