namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs
{
    partial class SetEventLocation
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
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbDirections = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.panelConstant = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.btnShowMap = new System.Windows.Forms.Button();
            this.nudMapY = new EGMGame.CustomUpDown();
            this.nudMapX = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelExchange = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.cbExchange = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.panelVariable = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.cbMapY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbMapX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEvents = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.impactGroupBox3.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.panelConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapX)).BeginInit();
            this.panelExchange.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(128, 324);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 27;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(46, 324);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 26;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.cbDirections);
            this.impactGroupBox3.Controls.Add(this.label3);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(14, 244);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(189, 74);
            this.impactGroupBox3.TabIndex = 3;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Direction";
            // 
            // cbDirections
            // 
            this.cbDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirections.FormattingEnabled = true;
            this.cbDirections.Items.AddRange(new object[] {
            "Don\'t Change",
            "Up",
            "Down",
            "Left",
            "Right",
            "Up/Left",
            "Up/Right",
            "Down/Left",
            "Down/Right"});
            this.cbDirections.Location = new System.Drawing.Point(10, 41);
            this.cbDirections.Name = "cbDirections";
            this.cbDirections.Size = new System.Drawing.Size(136, 21);
            this.cbDirections.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Choose the direction.";
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.panelConstant);
            this.impactGroupBox2.Controls.Add(this.panelExchange);
            this.impactGroupBox2.Controls.Add(this.cbType);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Controls.Add(this.panelVariable);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 87);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(189, 150);
            this.impactGroupBox2.TabIndex = 2;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Location";
            // 
            // panelConstant
            // 
            this.panelConstant.BackColor = System.Drawing.Color.Transparent;
            this.panelConstant.Controls.Add(this.btnShowMap);
            this.panelConstant.Controls.Add(this.nudMapY);
            this.panelConstant.Controls.Add(this.nudMapX);
            this.panelConstant.Controls.Add(this.label4);
            this.panelConstant.Controls.Add(this.label5);
            this.panelConstant.Location = new System.Drawing.Point(6, 68);
            this.panelConstant.Name = "panelConstant";
            this.panelConstant.Size = new System.Drawing.Size(154, 82);
            this.panelConstant.TabIndex = 29;
            this.panelConstant.Visible = false;
            // 
            // btnShowMap
            // 
            this.btnShowMap.Location = new System.Drawing.Point(6, 56);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(76, 23);
            this.btnShowMap.TabIndex = 57;
            this.btnShowMap.Text = "Show Map";
            this.btnShowMap.UseVisualStyleBackColor = true;
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            // 
            // nudMapY
            // 
            this.nudMapY.Location = new System.Drawing.Point(47, 31);
            this.nudMapY.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudMapY.Name = "nudMapY";
            this.nudMapY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMapY.OnChange = false;
            this.nudMapY.Size = new System.Drawing.Size(74, 20);
            this.nudMapY.TabIndex = 30;
            // 
            // nudMapX
            // 
            this.nudMapX.Location = new System.Drawing.Point(47, 5);
            this.nudMapX.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudMapX.Name = "nudMapX";
            this.nudMapX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMapX.OnChange = false;
            this.nudMapX.Size = new System.Drawing.Size(74, 20);
            this.nudMapX.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Map X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Map Y";
            // 
            // panelExchange
            // 
            this.panelExchange.BackColor = System.Drawing.Color.Transparent;
            this.panelExchange.Controls.Add(this.cbExchange);
            this.panelExchange.Location = new System.Drawing.Point(6, 68);
            this.panelExchange.Name = "panelExchange";
            this.panelExchange.Size = new System.Drawing.Size(154, 62);
            this.panelExchange.TabIndex = 32;
            this.panelExchange.Visible = false;
            // 
            // cbExchange
            // 
            this.cbExchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExchange.FormattingEnabled = true;
            this.cbExchange.Location = new System.Drawing.Point(6, 3);
            this.cbExchange.Name = "cbExchange";
            this.cbExchange.ShowPlayer = true;
            this.cbExchange.Size = new System.Drawing.Size(139, 21);
            this.cbExchange.TabIndex = 2;
            this.cbExchange.ThisEvent = true;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbMapY);
            this.panelVariable.Controls.Add(this.cbMapX);
            this.panelVariable.Controls.Add(this.label6);
            this.panelVariable.Controls.Add(this.label7);
            this.panelVariable.Location = new System.Drawing.Point(6, 68);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(154, 62);
            this.panelVariable.TabIndex = 31;
            this.panelVariable.Visible = false;
            // 
            // cbMapY
            // 
            this.cbMapY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapY.FormattingEnabled = true;
            this.cbMapY.Location = new System.Drawing.Point(47, 32);
            this.cbMapY.Name = "cbMapY";
            this.cbMapY.Size = new System.Drawing.Size(104, 21);
            this.cbMapY.TabIndex = 30;
            // 
            // cbMapX
            // 
            this.cbMapX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapX.FormattingEnabled = true;
            this.cbMapX.Location = new System.Drawing.Point(47, 6);
            this.cbMapX.Name = "cbMapX";
            this.cbMapX.Size = new System.Drawing.Size(104, 21);
            this.cbMapX.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Map X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Map Y";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Exchange"});
            this.cbType.Location = new System.Drawing.Point(10, 41);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(136, 21);
            this.cbType.TabIndex = 2;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose the location type.";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbEvents);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(189, 69);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Event";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the event to set location of.";
            // 
            // cbEvents
            // 
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(7, 41);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.ShowPlayer = true;
            this.cbEvents.Size = new System.Drawing.Size(139, 21);
            this.cbEvents.TabIndex = 0;
            this.cbEvents.ThisEvent = true;
            // 
            // SetEventLocation
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(212, 358);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetEventLocation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Event Location";
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.panelConstant.ResumeLayout(false);
            this.panelConstant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapX)).EndInit();
            this.panelExchange.ResumeLayout(false);
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.Game.MapEventComboBox cbEvents;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.ComboBox cbDirections;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelConstant;
        private CustomUpDown nudMapY;
        private CustomUpDown nudMapX;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelVariable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private EGMGame.Controls.Game.VariableComboBox cbMapY;
        private EGMGame.Controls.Game.VariableComboBox cbMapX;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelExchange;
        private EGMGame.Controls.Game.MapEventComboBox cbExchange;
        private System.Windows.Forms.Button btnShowMap;
    }
}