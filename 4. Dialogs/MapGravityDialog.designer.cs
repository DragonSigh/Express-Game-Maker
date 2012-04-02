namespace EGMGame.Dialogs
{
    partial class MapGravityDialog
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
            this.nudGravityY = new EGMGame.CustomUpDown();
            this.nudGravityX = new EGMGame.CustomUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.chGravity = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).BeginInit();
            this.SuspendLayout();
            // 
            // nudGravityY
            // 
            this.nudGravityY.DecimalPlaces = 3;
            this.nudGravityY.Location = new System.Drawing.Point(105, 62);
            this.nudGravityY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudGravityY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudGravityY.Name = "nudGravityY";
            this.nudGravityY.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudGravityY.OnChange = false;
            this.nudGravityY.Size = new System.Drawing.Size(80, 20);
            this.nudGravityY.TabIndex = 67;
            // 
            // nudGravityX
            // 
            this.nudGravityX.DecimalPlaces = 3;
            this.nudGravityX.Location = new System.Drawing.Point(105, 36);
            this.nudGravityX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudGravityX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudGravityX.Name = "nudGravityX";
            this.nudGravityX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudGravityX.OnChange = false;
            this.nudGravityX.Size = new System.Drawing.Size(80, 20);
            this.nudGravityX.TabIndex = 66;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(127, 88);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 70;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(42, 88);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 69;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // chGravity
            // 
            this.chGravity.AutoSize = true;
            this.chGravity.BackColor = System.Drawing.Color.Transparent;
            this.chGravity.Location = new System.Drawing.Point(12, 13);
            this.chGravity.Name = "chGravity";
            this.chGravity.Size = new System.Drawing.Size(136, 17);
            this.chGravity.TabIndex = 71;
            this.chGravity.Text = "Change Default Gravity";
            this.chGravity.UseVisualStyleBackColor = false;
            this.chGravity.CheckedChanged += new System.EventHandler(this.chGravity_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Horizontal Gravity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Vertical Gravity";
            // 
            // MapGravityDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(214, 122);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chGravity);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.nudGravityY);
            this.Controls.Add(this.nudGravityX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MapGravityDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Map Gravity";
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUpDown nudGravityY;
        private CustomUpDown nudGravityX;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox chGravity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}