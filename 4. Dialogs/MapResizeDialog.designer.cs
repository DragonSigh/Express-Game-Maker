namespace EGMGame
{
    partial class MapResizeDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.widthBox = new CustomUpDown();
            this.heightBox = new CustomUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rbTiles = new System.Windows.Forms.RadioButton();
            this.rbPixels = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(12, 92);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 92);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(56, 16);
            this.widthBox.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            this.widthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(112, 20);
            this.widthBox.TabIndex = 6;
            this.widthBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(56, 42);
            this.heightBox.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            this.heightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(112, 20);
            this.heightBox.TabIndex = 7;
            this.heightBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // rbTiles
            // 
            this.rbTiles.AutoSize = true;
            this.rbTiles.BackColor = System.Drawing.Color.Transparent;
            this.rbTiles.Checked = true;
            this.rbTiles.Location = new System.Drawing.Point(15, 68);
            this.rbTiles.Name = "rbTiles";
            this.rbTiles.Size = new System.Drawing.Size(47, 17);
            this.rbTiles.TabIndex = 9;
            this.rbTiles.TabStop = true;
            this.rbTiles.Text = "Tiles";
            this.rbTiles.UseVisualStyleBackColor = false;
            this.rbTiles.CheckedChanged += new System.EventHandler(this.rbTiles_CheckedChanged);
            // 
            // rbPixels
            // 
            this.rbPixels.AutoSize = true;
            this.rbPixels.BackColor = System.Drawing.Color.Transparent;
            this.rbPixels.Location = new System.Drawing.Point(68, 68);
            this.rbPixels.Name = "rbPixels";
            this.rbPixels.Size = new System.Drawing.Size(52, 17);
            this.rbPixels.TabIndex = 10;
            this.rbPixels.Text = "Pixels";
            this.rbPixels.UseVisualStyleBackColor = false;
            this.rbPixels.CheckedChanged += new System.EventHandler(this.rbPixels_CheckedChanged);
            // 
            // MapResizeDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(180, 127);
            this.Controls.Add(this.rbPixels);
            this.Controls.Add(this.rbTiles);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapResizeDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resize Map";
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal CustomUpDown widthBox;
        internal CustomUpDown heightBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.RadioButton rbTiles;
        private System.Windows.Forms.RadioButton rbPixels;
    }
}