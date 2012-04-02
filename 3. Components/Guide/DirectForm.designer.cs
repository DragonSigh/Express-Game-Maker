namespace EGMGame
{
    partial class DirectForm
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
            this._HelpButton = new System.Windows.Forms.Button();
            this._CheckBox = new System.Windows.Forms.CheckBox();
            this._Text = new System.Windows.Forms.Label();
            this._CloseButton = new System.Windows.Forms.Button();
            this._Image = new System.Windows.Forms.PictureBox();
            this._Caption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._Image)).BeginInit();
            this.SuspendLayout();
            // 
            // _HelpButton
            // 
            this._HelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._HelpButton.BackColor = System.Drawing.Color.Transparent;
            this._HelpButton.BackgroundImage = global::EGMGame.Properties.Resources.help;
            this._HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._HelpButton.Cursor = System.Windows.Forms.Cursors.Help;
            this._HelpButton.FlatAppearance.BorderSize = 0;
            this._HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._HelpButton.Location = new System.Drawing.Point(249, 127);
            this._HelpButton.Name = "_HelpButton";
            this._HelpButton.Size = new System.Drawing.Size(16, 16);
            this._HelpButton.TabIndex = 13;
            this._HelpButton.UseVisualStyleBackColor = false;
            this._HelpButton.Visible = false;
            // 
            // _CheckBox
            // 
            this._CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._CheckBox.AutoSize = true;
            this._CheckBox.BackColor = System.Drawing.Color.Transparent;
            this._CheckBox.Location = new System.Drawing.Point(14, 127);
            this._CheckBox.Name = "_CheckBox";
            this._CheckBox.Size = new System.Drawing.Size(75, 17);
            this._CheckBox.TabIndex = 12;
            this._CheckBox.Text = "CheckBox";
            this._CheckBox.UseVisualStyleBackColor = false;
            this._CheckBox.Visible = false;
            // 
            // _Text
            // 
            this._Text.AutoSize = true;
            this._Text.BackColor = System.Drawing.Color.Transparent;
            this._Text.Location = new System.Drawing.Point(22, 33);
            this._Text.MaximumSize = new System.Drawing.Size(241, 91);
            this._Text.Name = "_Text";
            this._Text.Size = new System.Drawing.Size(28, 13);
            this._Text.TabIndex = 11;
            this._Text.Text = "Text";
            this._Text.Click += new System.EventHandler(this.DirectForm_Click);
            // 
            // _CloseButton
            // 
            this._CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._CloseButton.BackgroundImage = global::EGMGame.Properties.Resources.cancel;
            this._CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._CloseButton.FlatAppearance.BorderSize = 0;
            this._CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._CloseButton.Location = new System.Drawing.Point(254, 6);
            this._CloseButton.Name = "_CloseButton";
            this._CloseButton.Size = new System.Drawing.Size(14, 14);
            this._CloseButton.TabIndex = 10;
            this._CloseButton.UseVisualStyleBackColor = true;
            this._CloseButton.Click += new System.EventHandler(this._CloseButton_Click);
            // 
            // _Image
            // 
            this._Image.BackColor = System.Drawing.Color.Transparent;
            this._Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._Image.Location = new System.Drawing.Point(14, 33);
            this._Image.Name = "_Image";
            this._Image.Size = new System.Drawing.Size(2, 2);
            this._Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._Image.TabIndex = 9;
            this._Image.TabStop = false;
            // 
            // _Caption
            // 
            this._Caption.AutoSize = true;
            this._Caption.BackColor = System.Drawing.Color.Transparent;
            this._Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Caption.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._Caption.Location = new System.Drawing.Point(11, 6);
            this._Caption.Name = "_Caption";
            this._Caption.Size = new System.Drawing.Size(50, 13);
            this._Caption.TabIndex = 8;
            this._Caption.Text = "Caption";
            // 
            // DirectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::EGMGame.Properties.Resources.DirectBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(275, 150);
            this.ControlBox = false;
            this.Controls.Add(this._HelpButton);
            this.Controls.Add(this._CheckBox);
            this.Controls.Add(this._Text);
            this.Controls.Add(this._CloseButton);
            this.Controls.Add(this._Image);
            this.Controls.Add(this._Caption);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(275, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(216, 91);
            this.Name = "DirectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DirectForm";
            this.Deactivate += new System.EventHandler(this.DirectForm_Deactivate);
            this.Load += new System.EventHandler(this.DirectForm_Load);
            this.Leave += new System.EventHandler(this.DirectForm_Leave);
            this.Click += new System.EventHandler(this.DirectForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this._Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button _HelpButton;
        public System.Windows.Forms.CheckBox _CheckBox;
        public System.Windows.Forms.Button _CloseButton;
        public System.Windows.Forms.PictureBox _Image;
        public System.Windows.Forms.Label _Caption;
        public System.Windows.Forms.Label _Text;

    }
}