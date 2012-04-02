namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs
{
    partial class GravityEventsDialog
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
            this.panelConstant = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.nudMapY = new EGMGame.CustomUpDown();
            this.nudMapX = new EGMGame.CustomUpDown();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelVariable = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEvents = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbMapX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbMapY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.impactGroupBox2.SuspendLayout();
            this.panelConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapX)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(125, 246);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 27;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(44, 246);
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
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.cbType);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Controls.Add(this.panelVariable);
            this.impactGroupBox2.Controls.Add(this.panelConstant);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(11, 101);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(189, 139);
            this.impactGroupBox2.TabIndex = 2;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Settings";
            // 
            // panelConstant
            // 
            this.panelConstant.BackColor = System.Drawing.Color.Transparent;
            this.panelConstant.Controls.Add(this.label3);
            this.panelConstant.Controls.Add(this.label4);
            this.panelConstant.Controls.Add(this.nudMapY);
            this.panelConstant.Controls.Add(this.nudMapX);
            this.panelConstant.Location = new System.Drawing.Point(11, 68);
            this.panelConstant.Name = "panelConstant";
            this.panelConstant.Size = new System.Drawing.Size(171, 62);
            this.panelConstant.TabIndex = 29;
            this.panelConstant.Visible = false;
            // 
            // nudMapY
            // 
            this.nudMapY.DecimalPlaces = 3;
            this.nudMapY.Location = new System.Drawing.Point(56, 31);
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
            this.nudMapY.Size = new System.Drawing.Size(82, 20);
            this.nudMapY.TabIndex = 30;
            // 
            // nudMapX
            // 
            this.nudMapX.DecimalPlaces = 3;
            this.nudMapX.Location = new System.Drawing.Point(56, 5);
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
            this.nudMapX.Size = new System.Drawing.Size(82, 20);
            this.nudMapX.TabIndex = 29;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbType.Location = new System.Drawing.Point(11, 41);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(136, 21);
            this.cbType.TabIndex = 2;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.label9);
            this.panelVariable.Controls.Add(this.label8);
            this.panelVariable.Controls.Add(this.cbMapY);
            this.panelVariable.Controls.Add(this.cbMapX);
            this.panelVariable.Location = new System.Drawing.Point(11, 68);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(171, 62);
            this.panelVariable.TabIndex = 31;
            this.panelVariable.Visible = false;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbEvents);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(189, 83);
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
            this.label1.Size = new System.Drawing.Size(156, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the event that will have\r\ngravitational pull.";
            // 
            // cbEvents
            // 
            this.cbEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(9, 54);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.ShowPlayer = true;
            this.cbEvents.ShowTarget = true;
            this.cbEvents.ShowTargets = false;
            this.cbEvents.Size = new System.Drawing.Size(139, 21);
            this.cbEvents.TabIndex = 0;
            this.cbEvents.ThisEvent = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose the value type.";
            // 
            // cbMapX
            // 
            this.cbMapX.AllowCategories = true;
            this.cbMapX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMapX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapX.FormattingEnabled = true;
            this.cbMapX.Location = new System.Drawing.Point(56, 4);
            this.cbMapX.Name = "cbMapX";
            this.cbMapX.Noneable = false;
            this.cbMapX.SelectedNode = null;
            this.cbMapX.Size = new System.Drawing.Size(107, 21);
            this.cbMapX.TabIndex = 29;
            // 
            // cbMapY
            // 
            this.cbMapY.AllowCategories = true;
            this.cbMapY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMapY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapY.FormattingEnabled = true;
            this.cbMapY.Location = new System.Drawing.Point(56, 30);
            this.cbMapY.Name = "cbMapY";
            this.cbMapY.Noneable = false;
            this.cbMapY.SelectedNode = null;
            this.cbMapY.Size = new System.Drawing.Size(107, 21);
            this.cbMapY.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Strength";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(3, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Radius";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Radius";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Strength";
            // 
            // GravityPointsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(212, 280);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GravityPointsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attach Gravity To Event";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.panelConstant.ResumeLayout(false);
            this.panelConstant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapX)).EndInit();
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
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelConstant;
        private CustomUpDown nudMapY;
        private CustomUpDown nudMapX;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Game.VariableComboBox cbMapY;
        private Game.VariableComboBox cbMapX;
    }
}