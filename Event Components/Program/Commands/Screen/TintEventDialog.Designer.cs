namespace EGMGame
{
    partial class TintEventDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkGlobal = new System.Windows.Forms.CheckBox();
            this.waitBox = new System.Windows.Forms.CheckBox();
            this.nudFrames = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.colorPickerCombobox1 = new EGMGame.ColorPickerCombobox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(132, 178);
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
            this.okBtn.Location = new System.Drawing.Point(51, 178);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.chkGlobal);
            this.impactGroupBox1.Controls.Add(this.waitBox);
            this.impactGroupBox1.Controls.Add(this.nudFrames);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.colorPickerCombobox1);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(197, 160);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Tint Settings";
            // 
            // chkGlobal
            // 
            this.chkGlobal.AutoSize = true;
            this.chkGlobal.BackColor = System.Drawing.Color.Transparent;
            this.chkGlobal.Location = new System.Drawing.Point(10, 136);
            this.chkGlobal.Name = "chkGlobal";
            this.chkGlobal.Size = new System.Drawing.Size(56, 17);
            this.chkGlobal.TabIndex = 22;
            this.chkGlobal.Text = "Global";
            this.toolTip1.SetToolTip(this.chkGlobal, "If checked, the effect will be displayed in\r\nboth the gameplay screen and the men" +
                    "u screen.");
            this.chkGlobal.UseVisualStyleBackColor = false;
            // 
            // waitBox
            // 
            this.waitBox.AutoSize = true;
            this.waitBox.BackColor = System.Drawing.Color.Transparent;
            this.waitBox.Checked = true;
            this.waitBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.waitBox.Location = new System.Drawing.Point(10, 113);
            this.waitBox.Name = "waitBox";
            this.waitBox.Size = new System.Drawing.Size(135, 17);
            this.waitBox.TabIndex = 4;
            this.waitBox.Text = "Wait Frame Completion";
            this.waitBox.UseVisualStyleBackColor = false;
            // 
            // nudFrames
            // 
            this.nudFrames.Location = new System.Drawing.Point(10, 87);
            this.nudFrames.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudFrames.Name = "nudFrames";
            this.nudFrames.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFrames.OnChange = true;
            this.nudFrames.Size = new System.Drawing.Size(49, 20);
            this.nudFrames.TabIndex = 3;
            this.nudFrames.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter the numer of frames to tint.";
            // 
            // colorPickerCombobox1
            // 
            this.colorPickerCombobox1.AllowOpacity = true;
            this.colorPickerCombobox1.Location = new System.Drawing.Point(10, 41);
            this.colorPickerCombobox1.Name = "colorPickerCombobox1";
            this.colorPickerCombobox1.SelectedItem = System.Drawing.Color.White;
            this.colorPickerCombobox1.Size = new System.Drawing.Size(119, 21);
            this.colorPickerCombobox1.TabIndex = 1;
            this.colorPickerCombobox1.Text = "colorPickerCombobox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the color for the screen tint.";
            // 
            // TintEventDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(219, 213);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TintEventDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tint Screen";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private ColorPickerCombobox colorPickerCombobox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private CustomUpDown nudFrames;
        private System.Windows.Forms.CheckBox waitBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkGlobal;
    }
}