namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Picture
{
    partial class TintPictureDialog
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
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.picIndex = new CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.waitBox = new System.Windows.Forms.CheckBox();
            this.nudFrames = new CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.colorPickerCombobox1 = new EGMGame.ColorPickerCombobox();
            this.label3 = new System.Windows.Forms.Label();
            this.impactGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.Controls.Add(this.waitBox);
            this.impactGroupBox4.Controls.Add(this.picIndex);
            this.impactGroupBox4.Controls.Add(this.nudFrames);
            this.impactGroupBox4.Controls.Add(this.label1);
            this.impactGroupBox4.Controls.Add(this.label2);
            this.impactGroupBox4.Controls.Add(this.label3);
            this.impactGroupBox4.Controls.Add(this.colorPickerCombobox1);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(191, 185);
            this.impactGroupBox4.TabIndex = 27;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Picture";
            // 
            // picIndex
            // 
            this.picIndex.Location = new System.Drawing.Point(8, 41);
            this.picIndex.Name = "picIndex";
            this.picIndex.Size = new System.Drawing.Size(43, 20);
            this.picIndex.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Choose the index of the picture.";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(130, 203);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 29;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(49, 203);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 28;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // waitBox
            // 
            this.waitBox.AutoSize = true;
            this.waitBox.BackColor = System.Drawing.Color.Transparent;
            this.waitBox.Checked = true;
            this.waitBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.waitBox.Location = new System.Drawing.Point(8, 152);
            this.waitBox.Name = "waitBox";
            this.waitBox.Size = new System.Drawing.Size(135, 17);
            this.waitBox.TabIndex = 34;
            this.waitBox.Text = "Wait Frame Completion";
            this.waitBox.UseVisualStyleBackColor = false;
            // 
            // nudFrames
            // 
            this.nudFrames.Location = new System.Drawing.Point(8, 126);
            this.nudFrames.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudFrames.Name = "nudFrames";
            this.nudFrames.Size = new System.Drawing.Size(49, 20);
            this.nudFrames.TabIndex = 33;
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
            this.label2.Location = new System.Drawing.Point(5, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Enter the numer of frames to tint.";
            // 
            // colorPickerCombobox1
            // 
            this.colorPickerCombobox1.Location = new System.Drawing.Point(8, 80);
            this.colorPickerCombobox1.Name = "colorPickerCombobox1";
            this.colorPickerCombobox1.SelectedItem = System.Drawing.Color.White;
            this.colorPickerCombobox1.Size = new System.Drawing.Size(119, 21);
            this.colorPickerCombobox1.TabIndex = 30;
            this.colorPickerCombobox1.Text = "colorPickerCombobox1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(5, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Choose the color for the screen tint.";
            // 
            // TintPictureDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(217, 237);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TintPictureDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tint Picture";
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private CustomUpDown picIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox waitBox;
        private CustomUpDown nudFrames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ColorPickerCombobox colorPickerCombobox1;
    }
}