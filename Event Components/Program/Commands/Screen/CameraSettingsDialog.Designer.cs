namespace EGMGame
{
    partial class CameraSettingsDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSpeed = new EGMGame.CustomUpDown();
            this.nudHor = new EGMGame.CustomUpDown();
            this.nudVert = new EGMGame.CustomUpDown();
            this.cbHor = new System.Windows.Forms.ComboBox();
            this.cbVert = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVert)).BeginInit();
            this.SuspendLayout();
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label4);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.nudSpeed);
            this.impactGroupBox1.Controls.Add(this.nudHor);
            this.impactGroupBox1.Controls.Add(this.nudVert);
            this.impactGroupBox1.Controls.Add(this.cbHor);
            this.impactGroupBox1.Controls.Add(this.cbVert);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(179, 122);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Scroll Camera";
            this.impactGroupBox1.Enter += new System.EventHandler(this.impactGroupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(118, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Frames";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Speed";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(62, 82);
            this.nudSpeed.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpeed.OnChange = true;
            this.nudSpeed.Size = new System.Drawing.Size(50, 20);
            this.nudSpeed.TabIndex = 4;
            this.nudSpeed.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // nudHor
            // 
            this.nudHor.Location = new System.Drawing.Point(62, 56);
            this.nudHor.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudHor.Name = "nudHor";
            this.nudHor.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudHor.OnChange = false;
            this.nudHor.Size = new System.Drawing.Size(50, 20);
            this.nudHor.TabIndex = 3;
            // 
            // nudVert
            // 
            this.nudVert.Location = new System.Drawing.Point(62, 28);
            this.nudVert.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudVert.Name = "nudVert";
            this.nudVert.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudVert.OnChange = false;
            this.nudVert.Size = new System.Drawing.Size(50, 20);
            this.nudVert.TabIndex = 2;
            // 
            // cbHor
            // 
            this.cbHor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHor.FormattingEnabled = true;
            this.cbHor.Items.AddRange(new object[] {
            "Left",
            "Right"});
            this.cbHor.Location = new System.Drawing.Point(10, 55);
            this.cbHor.Name = "cbHor";
            this.cbHor.Size = new System.Drawing.Size(46, 21);
            this.cbHor.TabIndex = 1;
            // 
            // cbVert
            // 
            this.cbVert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVert.FormattingEnabled = true;
            this.cbVert.Items.AddRange(new object[] {
            "Up",
            "Down"});
            this.cbVert.Location = new System.Drawing.Point(10, 28);
            this.cbVert.Name = "cbVert";
            this.cbVert.Size = new System.Drawing.Size(46, 21);
            this.cbVert.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(116, 140);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 29;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(35, 140);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 28;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(118, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pixels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(118, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pixels";
            // 
            // CameraSettingsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(200, 175);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox cbHor;
        private System.Windows.Forms.ComboBox cbVert;
        private CustomUpDown nudHor;
        private CustomUpDown nudVert;
        private CustomUpDown nudSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}