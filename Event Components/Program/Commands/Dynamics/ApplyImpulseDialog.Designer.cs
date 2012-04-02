namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class ApplyImpulseDialog
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
            this.btnBotLeft = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.btnBotRight = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBottom = new System.Windows.Forms.Button();
            this.nudBaseAngle = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.asBaseAngle = new EGMGame.Controls.ImpactUI.ImpactAngleSelector();
            this.chWait = new System.Windows.Forms.CheckBox();
            this.turnBox = new System.Windows.Forms.CheckBox();
            this.pixelBox = new EGMGame.CustomUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBotLeft
            // 
            this.btnBotLeft.Location = new System.Drawing.Point(12, 77);
            this.btnBotLeft.Name = "btnBotLeft";
            this.btnBotLeft.Size = new System.Drawing.Size(14, 13);
            this.btnBotLeft.TabIndex = 51;
            this.btnBotLeft.UseVisualStyleBackColor = true;
            this.btnBotLeft.Click += new System.EventHandler(this.btnBotLeft_Click);
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Location = new System.Drawing.Point(12, 12);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(14, 13);
            this.btnTopLeft.TabIndex = 50;
            this.btnTopLeft.UseVisualStyleBackColor = true;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // btnTopRight
            // 
            this.btnTopRight.Location = new System.Drawing.Point(78, 12);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(14, 13);
            this.btnTopRight.TabIndex = 49;
            this.btnTopRight.UseVisualStyleBackColor = true;
            this.btnTopRight.Click += new System.EventHandler(this.btnTopRight_Click);
            // 
            // btnBotRight
            // 
            this.btnBotRight.Location = new System.Drawing.Point(78, 77);
            this.btnBotRight.Name = "btnBotRight";
            this.btnBotRight.Size = new System.Drawing.Size(14, 13);
            this.btnBotRight.TabIndex = 48;
            this.btnBotRight.UseVisualStyleBackColor = true;
            this.btnBotRight.Click += new System.EventHandler(this.btnBotRight_Click);
            // 
            // btnTop
            // 
            this.btnTop.Location = new System.Drawing.Point(44, 12);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(14, 13);
            this.btnTop.TabIndex = 47;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(12, 46);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(14, 13);
            this.btnLeft.TabIndex = 46;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(78, 46);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(14, 13);
            this.btnRight.TabIndex = 45;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(44, 77);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(14, 13);
            this.btnBottom.TabIndex = 44;
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // nudBaseAngle
            // 
            this.nudBaseAngle.Location = new System.Drawing.Point(141, 44);
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
            this.nudBaseAngle.TabIndex = 43;
            this.nudBaseAngle.ValueChanged += new System.EventHandler(this.nudBaseAngle_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(98, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Angle:";
            // 
            // asBaseAngle
            // 
            this.asBaseAngle.Angle = 0;
            this.asBaseAngle.BackColor = System.Drawing.Color.Transparent;
            this.asBaseAngle.Location = new System.Drawing.Point(32, 31);
            this.asBaseAngle.Name = "asBaseAngle";
            this.asBaseAngle.Size = new System.Drawing.Size(40, 40);
            this.asBaseAngle.TabIndex = 41;
            this.asBaseAngle.AngleChanged += new EGMGame.Controls.ImpactUI.ImpactAngleSelector.AngleChangedDelegate(this.asBaseAngle_AngleChanged);
            // 
            // chWait
            // 
            this.chWait.AutoSize = true;
            this.chWait.BackColor = System.Drawing.Color.Transparent;
            this.chWait.Checked = true;
            this.chWait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chWait.Location = new System.Drawing.Point(132, 101);
            this.chWait.Name = "chWait";
            this.chWait.Size = new System.Drawing.Size(48, 17);
            this.chWait.TabIndex = 40;
            this.chWait.Text = "Wait";
            this.chWait.UseVisualStyleBackColor = false;
            // 
            // turnBox
            // 
            this.turnBox.AutoSize = true;
            this.turnBox.BackColor = System.Drawing.Color.Transparent;
            this.turnBox.Checked = true;
            this.turnBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.turnBox.Location = new System.Drawing.Point(78, 101);
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(48, 17);
            this.turnBox.TabIndex = 39;
            this.turnBox.Text = "Turn";
            this.turnBox.UseVisualStyleBackColor = false;
            // 
            // pixelBox
            // 
            this.pixelBox.DecimalPlaces = 3;
            this.pixelBox.Location = new System.Drawing.Point(20, 100);
            this.pixelBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.pixelBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pixelBox.OnChange = true;
            this.pixelBox.Size = new System.Drawing.Size(52, 20);
            this.pixelBox.TabIndex = 38;
            this.pixelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(105, 137);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 37;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(20, 137);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 36;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // ApplyImpulseDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(192, 172);
            this.Controls.Add(this.btnBotLeft);
            this.Controls.Add(this.btnTopLeft);
            this.Controls.Add(this.btnTopRight);
            this.Controls.Add(this.btnBotRight);
            this.Controls.Add(this.btnTop);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnBottom);
            this.Controls.Add(this.nudBaseAngle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.asBaseAngle);
            this.Controls.Add(this.chWait);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.pixelBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ApplyImpulseDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply Impulse";
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBotLeft;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Button btnBotRight;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBottom;
        private CustomUpDown nudBaseAngle;
        private System.Windows.Forms.Label label2;
        private EGMGame.Controls.ImpactUI.ImpactAngleSelector asBaseAngle;
        private System.Windows.Forms.CheckBox chWait;
        private System.Windows.Forms.CheckBox turnBox;
        private CustomUpDown pixelBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}