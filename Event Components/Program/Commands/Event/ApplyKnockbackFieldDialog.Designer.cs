namespace EGMGame
{
    partial class ApplyKnockbackFieldDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.nudForce = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDistance = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCustom = new System.Windows.Forms.Panel();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnBotLeft = new System.Windows.Forms.Button();
            this.asBaseAngle = new EGMGame.Controls.ImpactUI.ImpactAngleSelector();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.nudBaseAngle = new EGMGame.CustomUpDown();
            this.btnBotRight = new System.Windows.Forms.Button();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).BeginInit();
            this.panelCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(250, 193);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(169, 193);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.nudForce);
            this.impactGroupBox1.Controls.Add(this.label4);
            this.impactGroupBox1.Controls.Add(this.nudDistance);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.panelCustom);
            this.impactGroupBox1.Controls.Add(this.cbDirection);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(313, 169);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 3;
            this.nudForce.Location = new System.Drawing.Point(204, 81);
            this.nudForce.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudForce.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudForce.Name = "nudForce";
            this.nudForce.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudForce.OnChange = true;
            this.nudForce.Size = new System.Drawing.Size(68, 20);
            this.nudForce.TabIndex = 72;
            this.nudForce.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(201, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Force";
            // 
            // nudDistance
            // 
            this.nudDistance.Location = new System.Drawing.Point(204, 42);
            this.nudDistance.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDistance.Name = "nudDistance";
            this.nudDistance.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudDistance.OnChange = false;
            this.nudDistance.Size = new System.Drawing.Size(68, 20);
            this.nudDistance.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(201, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Distance To Effect";
            // 
            // panelCustom
            // 
            this.panelCustom.BackColor = System.Drawing.Color.Transparent;
            this.panelCustom.Controls.Add(this.btnTopLeft);
            this.panelCustom.Controls.Add(this.btnBotLeft);
            this.panelCustom.Controls.Add(this.asBaseAngle);
            this.panelCustom.Controls.Add(this.label2);
            this.panelCustom.Controls.Add(this.btnTopRight);
            this.panelCustom.Controls.Add(this.nudBaseAngle);
            this.panelCustom.Controls.Add(this.btnBotRight);
            this.panelCustom.Controls.Add(this.btnBottom);
            this.panelCustom.Controls.Add(this.btnTop);
            this.panelCustom.Controls.Add(this.btnRight);
            this.panelCustom.Controls.Add(this.btnLeft);
            this.panelCustom.Enabled = false;
            this.panelCustom.Location = new System.Drawing.Point(10, 68);
            this.panelCustom.Name = "panelCustom";
            this.panelCustom.Size = new System.Drawing.Size(177, 89);
            this.panelCustom.TabIndex = 69;
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Location = new System.Drawing.Point(3, 3);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(14, 13);
            this.btnTopLeft.TabIndex = 66;
            this.btnTopLeft.UseVisualStyleBackColor = true;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // btnBotLeft
            // 
            this.btnBotLeft.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBotLeft.Location = new System.Drawing.Point(3, 68);
            this.btnBotLeft.Name = "btnBotLeft";
            this.btnBotLeft.Size = new System.Drawing.Size(14, 13);
            this.btnBotLeft.TabIndex = 67;
            this.btnBotLeft.UseVisualStyleBackColor = true;
            this.btnBotLeft.Click += new System.EventHandler(this.btnBotLeft_Click);
            // 
            // asBaseAngle
            // 
            this.asBaseAngle.Angle = 0;
            this.asBaseAngle.BackColor = System.Drawing.Color.Transparent;
            this.asBaseAngle.Location = new System.Drawing.Point(23, 22);
            this.asBaseAngle.Name = "asBaseAngle";
            this.asBaseAngle.Size = new System.Drawing.Size(40, 40);
            this.asBaseAngle.TabIndex = 57;
            this.asBaseAngle.AngleChanged += new EGMGame.Controls.ImpactUI.ImpactAngleSelector.AngleChangedDelegate(this.asBaseAngle_AngleChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(89, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Angle:";
            // 
            // btnTopRight
            // 
            this.btnTopRight.Location = new System.Drawing.Point(69, 3);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(14, 13);
            this.btnTopRight.TabIndex = 65;
            this.btnTopRight.UseVisualStyleBackColor = true;
            this.btnTopRight.Click += new System.EventHandler(this.btnTopRight_Click);
            // 
            // nudBaseAngle
            // 
            this.nudBaseAngle.Location = new System.Drawing.Point(132, 35);
            this.nudBaseAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudBaseAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudBaseAngle.Name = "nudBaseAngle";
            this.nudBaseAngle.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudBaseAngle.OnChange = false;
            this.nudBaseAngle.Size = new System.Drawing.Size(39, 20);
            this.nudBaseAngle.TabIndex = 59;
            this.nudBaseAngle.ValueChanged += new System.EventHandler(this.nudBaseAngle_ValueChanged);
            // 
            // btnBotRight
            // 
            this.btnBotRight.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBotRight.Location = new System.Drawing.Point(69, 68);
            this.btnBotRight.Name = "btnBotRight";
            this.btnBotRight.Size = new System.Drawing.Size(14, 13);
            this.btnBotRight.TabIndex = 64;
            this.btnBotRight.UseVisualStyleBackColor = true;
            this.btnBotRight.Click += new System.EventHandler(this.btnBotRight_Click);
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(35, 68);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(14, 13);
            this.btnBottom.TabIndex = 60;
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // btnTop
            // 
            this.btnTop.Location = new System.Drawing.Point(35, 3);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(14, 13);
            this.btnTop.TabIndex = 63;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(69, 37);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(14, 13);
            this.btnRight.TabIndex = 61;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(3, 37);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(14, 13);
            this.btnLeft.TabIndex = 62;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "Forward",
            "Radius",
            "Custom"});
            this.cbDirection.Location = new System.Drawing.Point(10, 41);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(147, 21);
            this.cbDirection.TabIndex = 22;
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.cbDirection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the direction of the knockback.";
            // 
            // ApplyKnockbackFieldDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(333, 223);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplyKnockbackFieldDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply Knockback Field";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplyForceDialog_FormClosing);
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).EndInit();
            this.panelCustom.ResumeLayout(false);
            this.panelCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label4;
        private CustomUpDown nudDistance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelCustom;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnBotLeft;
        private Controls.ImpactUI.ImpactAngleSelector asBaseAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTopRight;
        private CustomUpDown nudBaseAngle;
        private System.Windows.Forms.Button btnBotRight;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private CustomUpDown nudForce;
    }
}