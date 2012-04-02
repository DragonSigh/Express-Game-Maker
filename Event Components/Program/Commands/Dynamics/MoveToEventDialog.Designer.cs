namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class MoveToEventDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveToEventDialog));
            this.nudPrecision = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.chWait = new System.Windows.Forms.CheckBox();
            this.turnBox = new System.Windows.Forms.CheckBox();
            this.cbEvents = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.downRightBtn = new System.Windows.Forms.CheckBox();
            this.upBtn = new System.Windows.Forms.CheckBox();
            this.upRightBtn = new System.Windows.Forms.CheckBox();
            this.upLeftBtn = new System.Windows.Forms.CheckBox();
            this.downLeftBtn = new System.Windows.Forms.CheckBox();
            this.rightBtn = new System.Windows.Forms.CheckBox();
            this.leftBtn = new System.Windows.Forms.CheckBox();
            this.downBtn = new System.Windows.Forms.CheckBox();
            this.chImpulse = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPrecision
            // 
            this.nudPrecision.Location = new System.Drawing.Point(15, 67);
            this.nudPrecision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPrecision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecision.Name = "nudPrecision";
            this.nudPrecision.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPrecision.OnChange = true;
            this.nudPrecision.Size = new System.Drawing.Size(59, 20);
            this.nudPrecision.TabIndex = 63;
            this.nudPrecision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Precision";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(177, 153);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 61;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(96, 153);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 60;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // chWait
            // 
            this.chWait.AutoSize = true;
            this.chWait.BackColor = System.Drawing.Color.Transparent;
            this.chWait.Checked = true;
            this.chWait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chWait.Location = new System.Drawing.Point(69, 93);
            this.chWait.Name = "chWait";
            this.chWait.Size = new System.Drawing.Size(48, 17);
            this.chWait.TabIndex = 66;
            this.chWait.Text = "Wait";
            this.chWait.UseVisualStyleBackColor = false;
            // 
            // turnBox
            // 
            this.turnBox.AutoSize = true;
            this.turnBox.BackColor = System.Drawing.Color.Transparent;
            this.turnBox.Checked = true;
            this.turnBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.turnBox.Location = new System.Drawing.Point(15, 93);
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(48, 17);
            this.turnBox.TabIndex = 65;
            this.turnBox.Text = "Turn";
            this.turnBox.UseVisualStyleBackColor = false;
            // 
            // cbEvents
            // 
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(15, 27);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.ShowPlayer = true;
            this.cbEvents.Size = new System.Drawing.Size(111, 21);
            this.cbEvents.TabIndex = 67;
            this.cbEvents.ThisEvent = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(148, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 39);
            this.label2.TabIndex = 77;
            this.label2.Text = "Click and highlight \r\nthe directions the \r\ncharacter can move.";
            // 
            // downRightBtn
            // 
            this.downRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downRightBtn.AutoSize = true;
            this.downRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("downRightBtn.Image")));
            this.downRightBtn.Location = new System.Drawing.Point(215, 65);
            this.downRightBtn.Name = "downRightBtn";
            this.downRightBtn.Size = new System.Drawing.Size(22, 22);
            this.downRightBtn.TabIndex = 76;
            this.downRightBtn.UseVisualStyleBackColor = true;
            // 
            // upBtn
            // 
            this.upBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upBtn.AutoSize = true;
            this.upBtn.Checked = true;
            this.upBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.upBtn.Image = ((System.Drawing.Image)(resources.GetObject("upBtn.Image")));
            this.upBtn.Location = new System.Drawing.Point(187, 9);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(22, 22);
            this.upBtn.TabIndex = 69;
            this.upBtn.UseVisualStyleBackColor = true;
            // 
            // upRightBtn
            // 
            this.upRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upRightBtn.AutoSize = true;
            this.upRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("upRightBtn.Image")));
            this.upRightBtn.Location = new System.Drawing.Point(215, 9);
            this.upRightBtn.Name = "upRightBtn";
            this.upRightBtn.Size = new System.Drawing.Size(22, 22);
            this.upRightBtn.TabIndex = 75;
            this.upRightBtn.UseVisualStyleBackColor = true;
            // 
            // upLeftBtn
            // 
            this.upLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upLeftBtn.AutoSize = true;
            this.upLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("upLeftBtn.Image")));
            this.upLeftBtn.Location = new System.Drawing.Point(161, 9);
            this.upLeftBtn.Name = "upLeftBtn";
            this.upLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.upLeftBtn.TabIndex = 74;
            this.upLeftBtn.UseVisualStyleBackColor = true;
            // 
            // downLeftBtn
            // 
            this.downLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downLeftBtn.AutoSize = true;
            this.downLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("downLeftBtn.Image")));
            this.downLeftBtn.Location = new System.Drawing.Point(161, 65);
            this.downLeftBtn.Name = "downLeftBtn";
            this.downLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.downLeftBtn.TabIndex = 73;
            this.downLeftBtn.UseVisualStyleBackColor = true;
            // 
            // rightBtn
            // 
            this.rightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rightBtn.AutoSize = true;
            this.rightBtn.Checked = true;
            this.rightBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightBtn.Image = ((System.Drawing.Image)(resources.GetObject("rightBtn.Image")));
            this.rightBtn.Location = new System.Drawing.Point(215, 37);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(22, 22);
            this.rightBtn.TabIndex = 72;
            this.rightBtn.UseVisualStyleBackColor = true;
            // 
            // leftBtn
            // 
            this.leftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.leftBtn.AutoSize = true;
            this.leftBtn.Checked = true;
            this.leftBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftBtn.Image = ((System.Drawing.Image)(resources.GetObject("leftBtn.Image")));
            this.leftBtn.Location = new System.Drawing.Point(161, 37);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(22, 22);
            this.leftBtn.TabIndex = 71;
            this.leftBtn.UseVisualStyleBackColor = true;
            // 
            // downBtn
            // 
            this.downBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downBtn.AutoSize = true;
            this.downBtn.Checked = true;
            this.downBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downBtn.Image = ((System.Drawing.Image)(resources.GetObject("downBtn.Image")));
            this.downBtn.Location = new System.Drawing.Point(187, 65);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(22, 22);
            this.downBtn.TabIndex = 70;
            this.downBtn.UseVisualStyleBackColor = true;
            // 
            // chImpulse
            // 
            this.chImpulse.AutoSize = true;
            this.chImpulse.BackColor = System.Drawing.Color.Transparent;
            this.chImpulse.Location = new System.Drawing.Point(15, 116);
            this.chImpulse.Name = "chImpulse";
            this.chImpulse.Size = new System.Drawing.Size(62, 17);
            this.chImpulse.TabIndex = 78;
            this.chImpulse.Text = "Impulse";
            this.chImpulse.UseVisualStyleBackColor = false;
            // 
            // MoveToEventDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(256, 188);
            this.Controls.Add(this.chImpulse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.downRightBtn);
            this.Controls.Add(this.upBtn);
            this.Controls.Add(this.upRightBtn);
            this.Controls.Add(this.upLeftBtn);
            this.Controls.Add(this.downLeftBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEvents);
            this.Controls.Add(this.chWait);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.nudPrecision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MoveToEventDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move To Event";
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUpDown nudPrecision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox chWait;
        private System.Windows.Forms.CheckBox turnBox;
        private EGMGame.Controls.Game.MapEventComboBox cbEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox downRightBtn;
        private System.Windows.Forms.CheckBox upBtn;
        private System.Windows.Forms.CheckBox upRightBtn;
        private System.Windows.Forms.CheckBox upLeftBtn;
        private System.Windows.Forms.CheckBox downLeftBtn;
        private System.Windows.Forms.CheckBox rightBtn;
        private System.Windows.Forms.CheckBox leftBtn;
        private System.Windows.Forms.CheckBox downBtn;
        private System.Windows.Forms.CheckBox chImpulse;
    }
}