namespace EGMGame.Dialogs
{
    partial class ListItemDialog
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.itemsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addBTn = new System.Windows.Forms.ToolStripButton();
            this.removeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.upBtn = new System.Windows.Forms.ToolStripButton();
            this.downBtn = new System.Windows.Forms.ToolStripButton();
            this.impactGroupBox1.SuspendLayout();
            this.itemsBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(239, 494);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(320, 494);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.propertyGrid);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(155, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(240, 476);
            this.impactGroupBox1.TabIndex = 9;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Property";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(4, 25);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(232, 446);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // itemsBox
            // 
            this.itemsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.itemsBox.CanCollapse = false;
            this.itemsBox.Controls.Add(this.listBox);
            this.itemsBox.Controls.Add(this.toolStrip1);
            this.itemsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.itemsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.itemsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.itemsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.itemsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.itemsBox.Image = null;
            this.itemsBox.IsCollapsed = false;
            this.itemsBox.Location = new System.Drawing.Point(12, 12);
            this.itemsBox.Name = "itemsBox";
            this.itemsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.itemsBox.Size = new System.Drawing.Size(137, 476);
            this.itemsBox.TabIndex = 8;
            this.itemsBox.TabStop = false;
            this.itemsBox.Text = "Options";
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(4, 50);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(129, 421);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBTn,
            this.removeBtn,
            this.toolStripSeparator1,
            this.upBtn,
            this.downBtn});
            this.toolStrip1.Location = new System.Drawing.Point(4, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(129, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addBTn
            // 
            this.addBTn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBTn.Image = global::EGMGame.Properties.Resources.add;
            this.addBTn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBTn.Name = "addBTn";
            this.addBTn.Size = new System.Drawing.Size(23, 22);
            this.addBTn.Text = "Add";
            this.addBTn.Click += new System.EventHandler(this.addBTn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeBtn.Image = global::EGMGame.Properties.Resources.delete;
            this.removeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(23, 22);
            this.removeBtn.Text = "Remove";
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // upBtn
            // 
            this.upBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upBtn.Image = global::EGMGame.Properties.Resources.arrow_down;
            this.upBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(23, 22);
            this.upBtn.Text = "Up";
            this.upBtn.Click += new System.EventHandler(this.upBtn_Click);
            // 
            // downBtn
            // 
            this.downBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.downBtn.Image = global::EGMGame.Properties.Resources.arrow_up;
            this.downBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(23, 22);
            this.downBtn.Text = "Down";
            this.downBtn.Click += new System.EventHandler(this.downBtn_Click);
            // 
            // ListItemDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(407, 522);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.itemsBox);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListItemDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Options";
            this.impactGroupBox1.ResumeLayout(false);
            this.itemsBox.ResumeLayout(false);
            this.itemsBox.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox itemsBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addBTn;
        private System.Windows.Forms.ToolStripButton removeBtn;
        private System.Windows.Forms.ToolStripButton upBtn;
        private System.Windows.Forms.ToolStripButton downBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}