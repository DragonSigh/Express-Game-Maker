namespace EGMGame
{
    partial class ChangeCustomGravityDialog
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
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudGravityY = new EGMGame.CustomUpDown();
            this.nudGravityX = new EGMGame.CustomUpDown();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 108);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 108);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.cbType.Location = new System.Drawing.Point(12, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(130, 21);
            this.cbType.TabIndex = 4;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.nudGravityY);
            this.panel.Controls.Add(this.nudGravityX);
            this.panel.Location = new System.Drawing.Point(12, 40);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(167, 62);
            this.panel.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Vertical Gravity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Horizontal Gravity";
            // 
            // nudGravityY
            // 
            this.nudGravityY.DecimalPlaces = 3;
            this.nudGravityY.Location = new System.Drawing.Point(99, 33);
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
            this.nudGravityY.Size = new System.Drawing.Size(57, 20);
            this.nudGravityY.TabIndex = 79;
            // 
            // nudGravityX
            // 
            this.nudGravityX.DecimalPlaces = 3;
            this.nudGravityX.Location = new System.Drawing.Point(99, 7);
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
            this.nudGravityX.Size = new System.Drawing.Size(57, 20);
            this.nudGravityX.TabIndex = 78;
            // 
            // ChangeCustomGravityDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(178, 138);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeCustomGravityDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Ignore Gravity";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudGravityY;
        private CustomUpDown nudGravityX;
    }
}