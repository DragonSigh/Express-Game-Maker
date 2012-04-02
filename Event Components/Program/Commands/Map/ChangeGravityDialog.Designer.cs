namespace EGMGame
{
    partial class ChangeGravityDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudGravityY = new EGMGame.CustomUpDown();
            this.nudGravityX = new EGMGame.CustomUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(109, 64);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(28, 64);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 21;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Vertical Gravity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Horizontal Gravity";
            // 
            // nudGravityY
            // 
            this.nudGravityY.DecimalPlaces = 3;
            this.nudGravityY.Location = new System.Drawing.Point(104, 38);
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
            this.nudGravityY.TabIndex = 75;
            // 
            // nudGravityX
            // 
            this.nudGravityX.DecimalPlaces = 3;
            this.nudGravityX.Location = new System.Drawing.Point(104, 12);
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
            this.nudGravityX.TabIndex = 74;
            // 
            // ChangeGravityDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(195, 101);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudGravityY);
            this.Controls.Add(this.nudGravityX);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeGravityDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Map Gravity";
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudGravityY;
        private CustomUpDown nudGravityX;
    }
}