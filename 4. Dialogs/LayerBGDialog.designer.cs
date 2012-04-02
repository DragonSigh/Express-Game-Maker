namespace EGMGame
{
    partial class LayerBGDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerBGDialog));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.settingsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.sizeType = new System.Windows.Forms.ComboBox();
            this.speedY = new EGMGame.CustomUpDown();
            this.speedX = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedX)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(121, 138);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okBtn.Location = new System.Drawing.Point(40, 138);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
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
            // settingsBox
            // 
            this.settingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.settingsBox.CanCollapse = false;
            this.settingsBox.Controls.Add(this.sizeType);
            this.settingsBox.Controls.Add(this.speedY);
            this.settingsBox.Controls.Add(this.speedX);
            this.settingsBox.Controls.Add(this.label2);
            this.settingsBox.Controls.Add(this.label1);
            this.settingsBox.Enabled = false;
            this.settingsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.settingsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.settingsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.settingsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.settingsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.settingsBox.Image = null;
            this.settingsBox.IsCollapsed = false;
            this.settingsBox.Location = new System.Drawing.Point(12, 12);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.settingsBox.Size = new System.Drawing.Size(184, 120);
            this.settingsBox.TabIndex = 5;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // sizeType
            // 
            this.sizeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeType.FormattingEnabled = true;
            this.sizeType.Items.AddRange(new object[] {
            "Screen (Stationary)",
            "Scrolling",
            "Auto-Scrolling"});
            this.sizeType.Location = new System.Drawing.Point(10, 28);
            this.sizeType.Name = "sizeType";
            this.sizeType.Size = new System.Drawing.Size(160, 21);
            this.sizeType.TabIndex = 5;
            this.sizeType.SelectedIndexChanged += new System.EventHandler(this.sizeType_SelectedIndexChanged);
            // 
            // speedY
            // 
            this.speedY.DecimalPlaces = 1;
            this.speedY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.speedY.Location = new System.Drawing.Point(112, 82);
            this.speedY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.speedY.Name = "speedY";
            this.speedY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.speedY.OnChange = false;
            this.speedY.Size = new System.Drawing.Size(58, 20);
            this.speedY.TabIndex = 3;
            // 
            // speedX
            // 
            this.speedX.DecimalPlaces = 1;
            this.speedX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.speedX.Location = new System.Drawing.Point(112, 55);
            this.speedX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.speedX.Name = "speedX";
            this.speedX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.speedX.OnChange = false;
            this.speedX.Size = new System.Drawing.Size(58, 20);
            this.speedX.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scroll Speed-Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scroll Speed-X";
            // 
            // LayerBGDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(212, 173);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerBGDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layer Settings";
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox settingsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomUpDown speedY;
        private CustomUpDown speedX;
        private System.Windows.Forms.ComboBox sizeType;
        private System.Windows.Forms.ImageList imageList;
    }
}