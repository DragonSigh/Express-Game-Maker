namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs
{
    partial class GravityPointsDialog
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
            this.panelSettings = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelConstant = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.btnShowMap = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMapY = new EGMGame.CustomUpDown();
            this.nudMapX = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudR = new EGMGame.CustomUpDown();
            this.nudStr = new EGMGame.CustomUpDown();
            this.panelVariable = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMapY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbMapX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbRadius = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbStrength = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.box = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbAddRemove = new System.Windows.Forms.ComboBox();
            this.nudIndex = new System.Windows.Forms.NumericUpDown();
            this.panelSettings.SuspendLayout();
            this.panelConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStr)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(125, 316);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 27;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(44, 316);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 26;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.panelSettings.CanCollapse = false;
            this.panelSettings.Controls.Add(this.cbType);
            this.panelSettings.Controls.Add(this.label2);
            this.panelSettings.Controls.Add(this.panelConstant);
            this.panelSettings.Controls.Add(this.panelVariable);
            this.panelSettings.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.panelSettings.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.panelSettings.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.panelSettings.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.panelSettings.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.panelSettings.Image = null;
            this.panelSettings.IsCollapsed = false;
            this.panelSettings.Location = new System.Drawing.Point(12, 77);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.panelSettings.Size = new System.Drawing.Size(189, 209);
            this.panelSettings.TabIndex = 2;
            this.panelSettings.TabStop = false;
            this.panelSettings.Text = "Settings";
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
            // panelConstant
            // 
            this.panelConstant.BackColor = System.Drawing.Color.Transparent;
            this.panelConstant.Controls.Add(this.btnShowMap);
            this.panelConstant.Controls.Add(this.label6);
            this.panelConstant.Controls.Add(this.label7);
            this.panelConstant.Controls.Add(this.nudMapY);
            this.panelConstant.Controls.Add(this.nudMapX);
            this.panelConstant.Controls.Add(this.label3);
            this.panelConstant.Controls.Add(this.label4);
            this.panelConstant.Controls.Add(this.nudR);
            this.panelConstant.Controls.Add(this.nudStr);
            this.panelConstant.Location = new System.Drawing.Point(11, 68);
            this.panelConstant.Name = "panelConstant";
            this.panelConstant.Size = new System.Drawing.Size(171, 133);
            this.panelConstant.TabIndex = 29;
            this.panelConstant.Visible = false;
            // 
            // btnShowMap
            // 
            this.btnShowMap.Location = new System.Drawing.Point(6, 107);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(76, 23);
            this.btnShowMap.TabIndex = 58;
            this.btnShowMap.Text = "Show Map";
            this.btnShowMap.UseVisualStyleBackColor = true;
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "X";
            // 
            // nudMapY
            // 
            this.nudMapY.Location = new System.Drawing.Point(56, 84);
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
            this.nudMapY.TabIndex = 38;
            // 
            // nudMapX
            // 
            this.nudMapX.Location = new System.Drawing.Point(56, 58);
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
            this.nudMapX.TabIndex = 37;
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
            // nudR
            // 
            this.nudR.DecimalPlaces = 3;
            this.nudR.Location = new System.Drawing.Point(56, 31);
            this.nudR.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudR.Name = "nudR";
            this.nudR.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudR.OnChange = false;
            this.nudR.Size = new System.Drawing.Size(82, 20);
            this.nudR.TabIndex = 30;
            // 
            // nudStr
            // 
            this.nudStr.DecimalPlaces = 3;
            this.nudStr.Location = new System.Drawing.Point(56, 5);
            this.nudStr.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudStr.Name = "nudStr";
            this.nudStr.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudStr.OnChange = false;
            this.nudStr.Size = new System.Drawing.Size(82, 20);
            this.nudStr.TabIndex = 29;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.label1);
            this.panelVariable.Controls.Add(this.label5);
            this.panelVariable.Controls.Add(this.cbMapY);
            this.panelVariable.Controls.Add(this.cbMapX);
            this.panelVariable.Controls.Add(this.label9);
            this.panelVariable.Controls.Add(this.label8);
            this.panelVariable.Controls.Add(this.cbRadius);
            this.panelVariable.Controls.Add(this.cbStrength);
            this.panelVariable.Location = new System.Drawing.Point(11, 68);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(171, 110);
            this.panelVariable.TabIndex = 31;
            this.panelVariable.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "X";
            // 
            // cbMapY
            // 
            this.cbMapY.AllowCategories = true;
            this.cbMapY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMapY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapY.FormattingEnabled = true;
            this.cbMapY.Location = new System.Drawing.Point(56, 83);
            this.cbMapY.Name = "cbMapY";
            this.cbMapY.Noneable = false;
            this.cbMapY.SelectedNode = null;
            this.cbMapY.Size = new System.Drawing.Size(107, 21);
            this.cbMapY.TabIndex = 36;
            // 
            // cbMapX
            // 
            this.cbMapX.AllowCategories = true;
            this.cbMapX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMapX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapX.FormattingEnabled = true;
            this.cbMapX.Location = new System.Drawing.Point(56, 57);
            this.cbMapX.Name = "cbMapX";
            this.cbMapX.Noneable = false;
            this.cbMapX.SelectedNode = null;
            this.cbMapX.Size = new System.Drawing.Size(107, 21);
            this.cbMapX.TabIndex = 35;
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
            // cbRadius
            // 
            this.cbRadius.AllowCategories = true;
            this.cbRadius.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRadius.FormattingEnabled = true;
            this.cbRadius.Location = new System.Drawing.Point(56, 30);
            this.cbRadius.Name = "cbRadius";
            this.cbRadius.Noneable = false;
            this.cbRadius.SelectedNode = null;
            this.cbRadius.Size = new System.Drawing.Size(107, 21);
            this.cbRadius.TabIndex = 30;
            // 
            // cbStrength
            // 
            this.cbStrength.AllowCategories = true;
            this.cbStrength.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStrength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrength.FormattingEnabled = true;
            this.cbStrength.Location = new System.Drawing.Point(56, 4);
            this.cbStrength.Name = "cbStrength";
            this.cbStrength.Noneable = false;
            this.cbStrength.SelectedNode = null;
            this.cbStrength.Size = new System.Drawing.Size(107, 21);
            this.cbStrength.TabIndex = 29;
            // 
            // box
            // 
            this.box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.box.CanCollapse = false;
            this.box.Controls.Add(this.cbAddRemove);
            this.box.Controls.Add(this.nudIndex);
            this.box.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.box.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.box.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.box.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.box.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.box.Image = null;
            this.box.IsCollapsed = false;
            this.box.Location = new System.Drawing.Point(12, 12);
            this.box.Name = "box";
            this.box.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.box.Size = new System.Drawing.Size(189, 59);
            this.box.TabIndex = 0;
            this.box.TabStop = false;
            this.box.Text = "Index";
            // 
            // cbAddRemove
            // 
            this.cbAddRemove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddRemove.FormattingEnabled = true;
            this.cbAddRemove.Items.AddRange(new object[] {
            "Add",
            "Remove"});
            this.cbAddRemove.Location = new System.Drawing.Point(76, 27);
            this.cbAddRemove.Name = "cbAddRemove";
            this.cbAddRemove.Size = new System.Drawing.Size(105, 21);
            this.cbAddRemove.TabIndex = 32;
            this.cbAddRemove.SelectedIndexChanged += new System.EventHandler(this.cbAddRemove_SelectedIndexChanged);
            // 
            // nudIndex
            // 
            this.nudIndex.Location = new System.Drawing.Point(10, 28);
            this.nudIndex.Name = "nudIndex";
            this.nudIndex.Size = new System.Drawing.Size(60, 20);
            this.nudIndex.TabIndex = 0;
            // 
            // GravityPointsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(212, 351);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GravityPointsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set a Gravity Point";
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelConstant.ResumeLayout(false);
            this.panelConstant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStr)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.box.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox panelSettings;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelConstant;
        private CustomUpDown nudR;
        private CustomUpDown nudStr;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Game.VariableComboBox cbRadius;
        private Game.VariableComboBox cbStrength;
        private ImpactUI.ImpactGroupBox box;
        private System.Windows.Forms.ComboBox cbAddRemove;
        private System.Windows.Forms.NumericUpDown nudIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Game.VariableComboBox cbMapY;
        private Game.VariableComboBox cbMapX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CustomUpDown nudMapY;
        private CustomUpDown nudMapX;
        private System.Windows.Forms.Button btnShowMap;
    }
}