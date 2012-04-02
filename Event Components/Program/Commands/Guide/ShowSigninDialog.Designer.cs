namespace EGMGame
{
    partial class ShowSigninDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkOnlineOnly = new System.Windows.Forms.CheckBox();
            this.nudPanels = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanels)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 72);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 26;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 72);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 25;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Number of panels.";
            // 
            // chkOnlineOnly
            // 
            this.chkOnlineOnly.AutoSize = true;
            this.chkOnlineOnly.Location = new System.Drawing.Point(12, 49);
            this.chkOnlineOnly.Name = "chkOnlineOnly";
            this.chkOnlineOnly.Size = new System.Drawing.Size(80, 17);
            this.chkOnlineOnly.TabIndex = 103;
            this.chkOnlineOnly.Text = "Online Only";
            this.chkOnlineOnly.UseVisualStyleBackColor = true;
            // 
            // nudPanels
            // 
            this.nudPanels.Location = new System.Drawing.Point(12, 23);
            this.nudPanels.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudPanels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPanels.Name = "nudPanels";
            this.nudPanels.Size = new System.Drawing.Size(80, 20);
            this.nudPanels.TabIndex = 104;
            this.nudPanels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ShowSigninDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(182, 106);
            this.Controls.Add(this.nudPanels);
            this.Controls.Add(this.chkOnlineOnly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowSigninDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Sign In";
            ((System.ComponentModel.ISupportInitialize)(this.nudPanels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOnlineOnly;
        private System.Windows.Forms.NumericUpDown nudPanels;
    }
}