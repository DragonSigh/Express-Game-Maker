namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class MoveTowardEvent
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
            this.eventsList = new System.Windows.Forms.CheckedListBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.turnBox = new System.Windows.Forms.CheckBox();
            this.pixelBox = new EGMGame.CustomUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.downRightBtn = new System.Windows.Forms.CheckBox();
            this.upRightBtn = new System.Windows.Forms.CheckBox();
            this.upLeftBtn = new System.Windows.Forms.CheckBox();
            this.downLeftBtn = new System.Windows.Forms.CheckBox();
            this.rightBtn = new System.Windows.Forms.CheckBox();
            this.leftBtn = new System.Windows.Forms.CheckBox();
            this.downBtn = new System.Windows.Forms.CheckBox();
            this.upBtn = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chWait = new System.Windows.Forms.CheckBox();
            this.chImpulse = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // eventsList
            // 
            this.eventsList.CheckOnClick = true;
            this.eventsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsList.FormattingEnabled = true;
            this.eventsList.Location = new System.Drawing.Point(4, 25);
            this.eventsList.Name = "eventsList";
            this.eventsList.Size = new System.Drawing.Size(94, 213);
            this.eventsList.TabIndex = 0;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.eventsList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(102, 243);
            this.impactGroupBox1.TabIndex = 1;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Events";
            // 
            // turnBox
            // 
            this.turnBox.AutoSize = true;
            this.turnBox.BackColor = System.Drawing.Color.Transparent;
            this.turnBox.Checked = true;
            this.turnBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.turnBox.Location = new System.Drawing.Point(190, 40);
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(48, 17);
            this.turnBox.TabIndex = 15;
            this.turnBox.Text = "Turn";
            this.turnBox.UseVisualStyleBackColor = false;
            // 
            // pixelBox
            // 
            this.pixelBox.DecimalPlaces = 3;
            this.pixelBox.Location = new System.Drawing.Point(120, 39);
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
            this.pixelBox.OnChange = false;
            this.pixelBox.Size = new System.Drawing.Size(65, 20);
            this.pixelBox.TabIndex = 14;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(154, 260);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(73, 260);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 12;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // downRightBtn
            // 
            this.downRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downRightBtn.AutoSize = true;
            this.downRightBtn.Image = global::EGMGame.Properties.Resources.arrow_downLeft;
            this.downRightBtn.Location = new System.Drawing.Point(175, 130);
            this.downRightBtn.Name = "downRightBtn";
            this.downRightBtn.Size = new System.Drawing.Size(22, 22);
            this.downRightBtn.TabIndex = 23;
            this.downRightBtn.UseVisualStyleBackColor = true;
            // 
            // upRightBtn
            // 
            this.upRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upRightBtn.AutoSize = true;
            this.upRightBtn.Image = global::EGMGame.Properties.Resources.arrow_upRight;
            this.upRightBtn.Location = new System.Drawing.Point(175, 74);
            this.upRightBtn.Name = "upRightBtn";
            this.upRightBtn.Size = new System.Drawing.Size(22, 22);
            this.upRightBtn.TabIndex = 22;
            this.upRightBtn.UseVisualStyleBackColor = true;
            // 
            // upLeftBtn
            // 
            this.upLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upLeftBtn.AutoSize = true;
            this.upLeftBtn.Image = global::EGMGame.Properties.Resources.arrow_leftUp;
            this.upLeftBtn.Location = new System.Drawing.Point(120, 74);
            this.upLeftBtn.Name = "upLeftBtn";
            this.upLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.upLeftBtn.TabIndex = 21;
            this.upLeftBtn.UseVisualStyleBackColor = true;
            // 
            // downLeftBtn
            // 
            this.downLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downLeftBtn.AutoSize = true;
            this.downLeftBtn.Image = global::EGMGame.Properties.Resources.arrow_dowRgiht;
            this.downLeftBtn.Location = new System.Drawing.Point(120, 130);
            this.downLeftBtn.Name = "downLeftBtn";
            this.downLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.downLeftBtn.TabIndex = 20;
            this.downLeftBtn.UseVisualStyleBackColor = true;
            // 
            // rightBtn
            // 
            this.rightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rightBtn.AutoSize = true;
            this.rightBtn.Checked = true;
            this.rightBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightBtn.Image = global::EGMGame.Properties.Resources.arrow_right;
            this.rightBtn.Location = new System.Drawing.Point(175, 102);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(22, 22);
            this.rightBtn.TabIndex = 19;
            this.rightBtn.UseVisualStyleBackColor = true;
            // 
            // leftBtn
            // 
            this.leftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.leftBtn.AutoSize = true;
            this.leftBtn.Checked = true;
            this.leftBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftBtn.Image = global::EGMGame.Properties.Resources.arrow_left;
            this.leftBtn.Location = new System.Drawing.Point(120, 102);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(22, 22);
            this.leftBtn.TabIndex = 18;
            this.leftBtn.UseVisualStyleBackColor = true;
            // 
            // downBtn
            // 
            this.downBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downBtn.AutoSize = true;
            this.downBtn.Checked = true;
            this.downBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downBtn.Image = global::EGMGame.Properties.Resources.arrow_up;
            this.downBtn.Location = new System.Drawing.Point(147, 130);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(22, 22);
            this.downBtn.TabIndex = 17;
            this.downBtn.UseVisualStyleBackColor = true;
            // 
            // upBtn
            // 
            this.upBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upBtn.AutoSize = true;
            this.upBtn.Checked = true;
            this.upBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.upBtn.Image = global::EGMGame.Properties.Resources.arrow_down;
            this.upBtn.Location = new System.Drawing.Point(147, 74);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(22, 22);
            this.upBtn.TabIndex = 16;
            this.upBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(120, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 39);
            this.label1.TabIndex = 24;
            this.label1.Text = "Click and highlight \r\nthe directions the \r\ncharacter can move.";
            // 
            // chWait
            // 
            this.chWait.AutoSize = true;
            this.chWait.BackColor = System.Drawing.Color.Transparent;
            this.chWait.Checked = true;
            this.chWait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chWait.Location = new System.Drawing.Point(120, 238);
            this.chWait.Name = "chWait";
            this.chWait.Size = new System.Drawing.Size(48, 17);
            this.chWait.TabIndex = 25;
            this.chWait.Text = "Wait";
            this.chWait.UseVisualStyleBackColor = false;
            // 
            // chImpulse
            // 
            this.chImpulse.AutoSize = true;
            this.chImpulse.BackColor = System.Drawing.Color.Transparent;
            this.chImpulse.Location = new System.Drawing.Point(120, 215);
            this.chImpulse.Name = "chImpulse";
            this.chImpulse.Size = new System.Drawing.Size(62, 17);
            this.chImpulse.TabIndex = 26;
            this.chImpulse.Text = "Impulse";
            this.chImpulse.UseVisualStyleBackColor = false;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Distance",
            "Force"});
            this.cbType.Location = new System.Drawing.Point(120, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(109, 21);
            this.cbType.TabIndex = 27;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // MoveTowardEvent
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(241, 295);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.chImpulse);
            this.Controls.Add(this.chWait);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downRightBtn);
            this.Controls.Add(this.upRightBtn);
            this.Controls.Add(this.upLeftBtn);
            this.Controls.Add(this.downLeftBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.upBtn);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.pixelBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveTowardEvent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move Toward Events";
            this.impactGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox eventsList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.CheckBox turnBox;
        private CustomUpDown pixelBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox upBtn;
        private System.Windows.Forms.CheckBox downBtn;
        private System.Windows.Forms.CheckBox leftBtn;
        private System.Windows.Forms.CheckBox rightBtn;
        private System.Windows.Forms.CheckBox downLeftBtn;
        private System.Windows.Forms.CheckBox upLeftBtn;
        private System.Windows.Forms.CheckBox upRightBtn;
        private System.Windows.Forms.CheckBox downRightBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chWait;
        private System.Windows.Forms.CheckBox chImpulse;
        private System.Windows.Forms.ComboBox cbType;
    }
}