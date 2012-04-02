namespace EGMGame.Controls.EventControls
{
    partial class ProjectileMovementDialog
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
            this.chWait = new System.Windows.Forms.CheckBox();
            this.turnBox = new System.Windows.Forms.CheckBox();
            this.cbMovement = new System.Windows.Forms.ComboBox();
            this.cbUseForce = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pixelBox = new EGMGame.CustomUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 112);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(12, 112);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 24;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // chWait
            // 
            this.chWait.AutoSize = true;
            this.chWait.BackColor = System.Drawing.Color.Transparent;
            this.chWait.Location = new System.Drawing.Point(126, 84);
            this.chWait.Name = "chWait";
            this.chWait.Size = new System.Drawing.Size(48, 17);
            this.chWait.TabIndex = 59;
            this.chWait.Text = "Wait";
            this.chWait.UseVisualStyleBackColor = false;
            // 
            // turnBox
            // 
            this.turnBox.AutoSize = true;
            this.turnBox.BackColor = System.Drawing.Color.Transparent;
            this.turnBox.Location = new System.Drawing.Point(72, 84);
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(48, 17);
            this.turnBox.TabIndex = 58;
            this.turnBox.Text = "Turn";
            this.turnBox.UseVisualStyleBackColor = false;
            // 
            // cbMovement
            // 
            this.cbMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovement.FormattingEnabled = true;
            this.cbMovement.Items.AddRange(new object[] {
            "Forward",
            "Backward",
            "Leftward",
            "Rightward",
            "Toward Target",
            "Random"});
            this.cbMovement.Location = new System.Drawing.Point(10, 24);
            this.cbMovement.Name = "cbMovement";
            this.cbMovement.Size = new System.Drawing.Size(124, 21);
            this.cbMovement.TabIndex = 60;
            // 
            // cbUseForce
            // 
            this.cbUseForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUseForce.FormattingEnabled = true;
            this.cbUseForce.Items.AddRange(new object[] {
            "Force",
            "Impulse"});
            this.cbUseForce.Location = new System.Drawing.Point(44, 51);
            this.cbUseForce.Name = "cbUseForce";
            this.cbUseForce.Size = new System.Drawing.Size(114, 21);
            this.cbUseForce.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Use ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Choose movement direction.";
            // 
            // pixelBox
            // 
            this.pixelBox.Location = new System.Drawing.Point(14, 83);
            this.pixelBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pixelBox.OnChange = true;
            this.pixelBox.Size = new System.Drawing.Size(52, 20);
            this.pixelBox.TabIndex = 57;
            this.pixelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProjectileMovementDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(180, 147);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUseForce);
            this.Controls.Add(this.cbMovement);
            this.Controls.Add(this.chWait);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.pixelBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProjectileMovementDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move";
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox chWait;
        private System.Windows.Forms.CheckBox turnBox;
        private CustomUpDown pixelBox;
        private System.Windows.Forms.ComboBox cbMovement;
        private System.Windows.Forms.ComboBox cbUseForce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}