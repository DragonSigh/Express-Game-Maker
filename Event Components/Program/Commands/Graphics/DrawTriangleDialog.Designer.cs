namespace EGMGame.EventControls.EventDialogs.CommandDialogs.DrawingDialogs
{
    partial class DrawTriangleDialog
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
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.rbEndScreen = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudEndScreenY = new CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudEndScreenX = new CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rbEndEvent = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbEndEvent = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.nudEndEventY = new CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudEndEventX = new CustomUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.rbStartScreen = new System.Windows.Forms.RadioButton();
            this.screenPanel = new System.Windows.Forms.Panel();
            this.nudStartScreenY = new CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudStartScreenX = new CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.rbStartEvent = new System.Windows.Forms.RadioButton();
            this.eventPanel = new System.Windows.Forms.Panel();
            this.cbStartEvent = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.nudStartEventY = new CustomUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudStartEventX = new CustomUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.impactGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndScreenY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndScreenX)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndEventY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndEventX)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.screenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartScreenY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartScreenX)).BeginInit();
            this.eventPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartEventY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartEventX)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(189, 308);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 27;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(108, 308);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 26;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.rbEndScreen);
            this.impactGroupBox2.Controls.Add(this.panel1);
            this.impactGroupBox2.Controls.Add(this.rbEndEvent);
            this.impactGroupBox2.Controls.Add(this.panel2);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 160);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(252, 142);
            this.impactGroupBox2.TabIndex = 25;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "End Position";
            // 
            // rbEndScreen
            // 
            this.rbEndScreen.AutoSize = true;
            this.rbEndScreen.BackColor = System.Drawing.Color.Transparent;
            this.rbEndScreen.Checked = true;
            this.rbEndScreen.Location = new System.Drawing.Point(7, 28);
            this.rbEndScreen.Name = "rbEndScreen";
            this.rbEndScreen.Size = new System.Drawing.Size(59, 17);
            this.rbEndScreen.TabIndex = 2;
            this.rbEndScreen.TabStop = true;
            this.rbEndScreen.Text = "Screen";
            this.rbEndScreen.UseVisualStyleBackColor = false;
            this.rbEndScreen.CheckedChanged += new System.EventHandler(this.rbEndScreen_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.nudEndScreenY);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nudEndScreenX);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 55);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            // 
            // nudEndScreenY
            // 
            this.nudEndScreenY.Location = new System.Drawing.Point(25, 29);
            this.nudEndScreenY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudEndScreenY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudEndScreenY.Name = "nudEndScreenY";
            this.nudEndScreenY.Size = new System.Drawing.Size(61, 20);
            this.nudEndScreenY.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X:";
            // 
            // nudEndScreenX
            // 
            this.nudEndScreenX.Location = new System.Drawing.Point(25, 3);
            this.nudEndScreenX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudEndScreenX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudEndScreenX.Name = "nudEndScreenX";
            this.nudEndScreenX.Size = new System.Drawing.Size(61, 20);
            this.nudEndScreenX.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(2, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y:";
            // 
            // rbEndEvent
            // 
            this.rbEndEvent.AutoSize = true;
            this.rbEndEvent.BackColor = System.Drawing.Color.Transparent;
            this.rbEndEvent.Location = new System.Drawing.Point(120, 28);
            this.rbEndEvent.Name = "rbEndEvent";
            this.rbEndEvent.Size = new System.Drawing.Size(53, 17);
            this.rbEndEvent.TabIndex = 11;
            this.rbEndEvent.Text = "Event";
            this.rbEndEvent.UseVisualStyleBackColor = false;
            this.rbEndEvent.CheckedChanged += new System.EventHandler(this.rbEndEvent_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cbEndEvent);
            this.panel2.Controls.Add(this.nudEndEventY);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.nudEndEventX);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(121, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 79);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // cbEndEvent
            // 
            this.cbEndEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndEvent.FormattingEnabled = true;
            this.cbEndEvent.Location = new System.Drawing.Point(7, 3);
            this.cbEndEvent.Name = "cbEndEvent";
            this.cbEndEvent.Size = new System.Drawing.Size(110, 21);
            this.cbEndEvent.TabIndex = 9;
            // 
            // nudEndEventY
            // 
            this.nudEndEventY.Location = new System.Drawing.Point(57, 56);
            this.nudEndEventY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudEndEventY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudEndEventY.Name = "nudEndEventY";
            this.nudEndEventY.Size = new System.Drawing.Size(61, 20);
            this.nudEndEventY.TabIndex = 8;
            this.nudEndEventY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Offset-X:";
            // 
            // nudEndEventX
            // 
            this.nudEndEventX.Location = new System.Drawing.Point(57, 30);
            this.nudEndEventX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudEndEventX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudEndEventX.Name = "nudEndEventX";
            this.nudEndEventX.Size = new System.Drawing.Size(61, 20);
            this.nudEndEventX.TabIndex = 7;
            this.nudEndEventX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(3, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Offset-Y:";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.rbStartScreen);
            this.impactGroupBox1.Controls.Add(this.screenPanel);
            this.impactGroupBox1.Controls.Add(this.rbStartEvent);
            this.impactGroupBox1.Controls.Add(this.eventPanel);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(252, 142);
            this.impactGroupBox1.TabIndex = 24;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Start Position";
            // 
            // rbStartScreen
            // 
            this.rbStartScreen.AutoSize = true;
            this.rbStartScreen.BackColor = System.Drawing.Color.Transparent;
            this.rbStartScreen.Checked = true;
            this.rbStartScreen.Location = new System.Drawing.Point(7, 28);
            this.rbStartScreen.Name = "rbStartScreen";
            this.rbStartScreen.Size = new System.Drawing.Size(59, 17);
            this.rbStartScreen.TabIndex = 2;
            this.rbStartScreen.TabStop = true;
            this.rbStartScreen.Text = "Screen";
            this.rbStartScreen.UseVisualStyleBackColor = false;
            this.rbStartScreen.CheckedChanged += new System.EventHandler(this.rbStartScreen_CheckedChanged);
            // 
            // screenPanel
            // 
            this.screenPanel.BackColor = System.Drawing.Color.Transparent;
            this.screenPanel.Controls.Add(this.nudStartScreenY);
            this.screenPanel.Controls.Add(this.label4);
            this.screenPanel.Controls.Add(this.nudStartScreenX);
            this.screenPanel.Controls.Add(this.label5);
            this.screenPanel.Location = new System.Drawing.Point(8, 51);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(92, 55);
            this.screenPanel.TabIndex = 10;
            this.screenPanel.Visible = false;
            // 
            // nudStartScreenY
            // 
            this.nudStartScreenY.Location = new System.Drawing.Point(25, 29);
            this.nudStartScreenY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudStartScreenY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudStartScreenY.Name = "nudStartScreenY";
            this.nudStartScreenY.Size = new System.Drawing.Size(61, 20);
            this.nudStartScreenY.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(2, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "X:";
            // 
            // nudStartScreenX
            // 
            this.nudStartScreenX.Location = new System.Drawing.Point(25, 3);
            this.nudStartScreenX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudStartScreenX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudStartScreenX.Name = "nudStartScreenX";
            this.nudStartScreenX.Size = new System.Drawing.Size(61, 20);
            this.nudStartScreenX.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(2, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Y:";
            // 
            // rbStartEvent
            // 
            this.rbStartEvent.AutoSize = true;
            this.rbStartEvent.BackColor = System.Drawing.Color.Transparent;
            this.rbStartEvent.Location = new System.Drawing.Point(120, 28);
            this.rbStartEvent.Name = "rbStartEvent";
            this.rbStartEvent.Size = new System.Drawing.Size(53, 17);
            this.rbStartEvent.TabIndex = 11;
            this.rbStartEvent.Text = "Event";
            this.rbStartEvent.UseVisualStyleBackColor = false;
            this.rbStartEvent.CheckedChanged += new System.EventHandler(this.rbStartEvent_CheckedChanged);
            // 
            // eventPanel
            // 
            this.eventPanel.BackColor = System.Drawing.Color.Transparent;
            this.eventPanel.Controls.Add(this.cbStartEvent);
            this.eventPanel.Controls.Add(this.nudStartEventY);
            this.eventPanel.Controls.Add(this.label6);
            this.eventPanel.Controls.Add(this.nudStartEventX);
            this.eventPanel.Controls.Add(this.label7);
            this.eventPanel.Location = new System.Drawing.Point(121, 54);
            this.eventPanel.Name = "eventPanel";
            this.eventPanel.Size = new System.Drawing.Size(120, 79);
            this.eventPanel.TabIndex = 10;
            this.eventPanel.Visible = false;
            // 
            // cbStartEvent
            // 
            this.cbStartEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartEvent.FormattingEnabled = true;
            this.cbStartEvent.Location = new System.Drawing.Point(7, 3);
            this.cbStartEvent.Name = "cbStartEvent";
            this.cbStartEvent.Size = new System.Drawing.Size(110, 21);
            this.cbStartEvent.TabIndex = 9;
            // 
            // nudStartEventY
            // 
            this.nudStartEventY.Location = new System.Drawing.Point(57, 56);
            this.nudStartEventY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudStartEventY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudStartEventY.Name = "nudStartEventY";
            this.nudStartEventY.Size = new System.Drawing.Size(61, 20);
            this.nudStartEventY.TabIndex = 8;
            this.nudStartEventY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Offset-X:";
            // 
            // nudStartEventX
            // 
            this.nudStartEventX.Location = new System.Drawing.Point(57, 30);
            this.nudStartEventX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudStartEventX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudStartEventX.Name = "nudStartEventX";
            this.nudStartEventX.Size = new System.Drawing.Size(61, 20);
            this.nudStartEventX.TabIndex = 7;
            this.nudStartEventX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Offset-Y:";
            // 
            // DrawTriangleDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(278, 342);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrawTriangleDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Draw Triangle";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndScreenY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndScreenX)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndEventY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndEventX)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.screenPanel.ResumeLayout(false);
            this.screenPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartScreenY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartScreenX)).EndInit();
            this.eventPanel.ResumeLayout(false);
            this.eventPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartEventY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartEventX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.RadioButton rbEndScreen;
        private System.Windows.Forms.Panel panel1;
        private CustomUpDown nudEndScreenY;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudEndScreenX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbEndEvent;
        private System.Windows.Forms.Panel panel2;
        private EGMGame.Controls.Game.MapEventComboBox cbEndEvent;
        private CustomUpDown nudEndEventY;
        private System.Windows.Forms.Label label3;
        private CustomUpDown nudEndEventX;
        private System.Windows.Forms.Label label8;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.RadioButton rbStartScreen;
        private System.Windows.Forms.Panel screenPanel;
        private CustomUpDown nudStartScreenY;
        private System.Windows.Forms.Label label4;
        private CustomUpDown nudStartScreenX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbStartEvent;
        private System.Windows.Forms.Panel eventPanel;
        private EGMGame.Controls.Game.MapEventComboBox cbStartEvent;
        private CustomUpDown nudStartEventY;
        private System.Windows.Forms.Label label6;
        private CustomUpDown nudStartEventX;
        private System.Windows.Forms.Label label7;
    }
}