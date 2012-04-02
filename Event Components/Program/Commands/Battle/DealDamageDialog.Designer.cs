namespace EGMGame
{
    partial class DealDamageDialog
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
            this.label9 = new System.Windows.Forms.Label();
            this.cbDamageType = new System.Windows.Forms.ComboBox();
            this.cbValueType = new System.Windows.Forms.ComboBox();
            this.nudValue = new EGMGame.CustomUpDown();
            this.cbProperty = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelConstant = new System.Windows.Forms.Panel();
            this.nudPositionY = new EGMGame.CustomUpDown();
            this.nudPositionX = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariableX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbVariableY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelEvent = new System.Windows.Forms.Panel();
            this.cbOnEvent = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.panelEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(250, 168);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(169, 168);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label9);
            this.impactGroupBox1.Controls.Add(this.cbDamageType);
            this.impactGroupBox1.Controls.Add(this.cbValueType);
            this.impactGroupBox1.Controls.Add(this.nudValue);
            this.impactGroupBox1.Controls.Add(this.cbProperty);
            this.impactGroupBox1.Controls.Add(this.label7);
            this.impactGroupBox1.Controls.Add(this.label8);
            this.impactGroupBox1.Controls.Add(this.numericUpDown1);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.cbType);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.panelConstant);
            this.impactGroupBox1.Controls.Add(this.panelVariable);
            this.impactGroupBox1.Controls.Add(this.panelEvent);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(313, 150);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Deal Damage";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(219, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Damage Type";
            // 
            // cbDamageType
            // 
            this.cbDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDamageType.FormattingEnabled = true;
            this.cbDamageType.Items.AddRange(new object[] {
            "Physical",
            "Magical"});
            this.cbDamageType.Location = new System.Drawing.Point(222, 40);
            this.cbDamageType.Margin = new System.Windows.Forms.Padding(2);
            this.cbDamageType.Name = "cbDamageType";
            this.cbDamageType.Size = new System.Drawing.Size(73, 21);
            this.cbDamageType.TabIndex = 61;
            // 
            // cbValueType
            // 
            this.cbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValueType.FormattingEnabled = true;
            this.cbValueType.Items.AddRange(new object[] {
            "Constant",
            "Percentage",
            "Damage"});
            this.cbValueType.Location = new System.Drawing.Point(210, 115);
            this.cbValueType.Margin = new System.Windows.Forms.Padding(2);
            this.cbValueType.Name = "cbValueType";
            this.cbValueType.Size = new System.Drawing.Size(85, 21);
            this.cbValueType.TabIndex = 60;
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(150, 115);
            this.nudValue.Margin = new System.Windows.Forms.Padding(2);
            this.nudValue.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudValue.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudValue.Name = "nudValue";
            this.nudValue.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudValue.OnChange = false;
            this.nudValue.Size = new System.Drawing.Size(52, 20);
            this.nudValue.TabIndex = 59;
            // 
            // cbProperty
            // 
            this.cbProperty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProperty.FormattingEnabled = true;
            this.cbProperty.Items.AddRange(new object[] {
            "HP",
            "SP",
            "MP",
            "Max HP",
            "Max SP",
            "Max MP ",
            "STR ",
            "DEF ",
            "MSTR ",
            "MDEF ",
            "AGI ",
            "LUK",
            "Level"});
            this.cbProperty.Location = new System.Drawing.Point(150, 78);
            this.cbProperty.Margin = new System.Windows.Forms.Padding(2);
            this.cbProperty.Name = "cbProperty";
            this.cbProperty.Size = new System.Drawing.Size(145, 21);
            this.cbProperty.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(147, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Add value to Property.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(147, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Choose the Property to effect.";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(150, 41);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(147, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Radius";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Target",
            "Event",
            "Position",
            "Variable Position"});
            this.cbType.Location = new System.Drawing.Point(10, 41);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(130, 21);
            this.cbType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Deal Damage To";
            // 
            // panelConstant
            // 
            this.panelConstant.BackColor = System.Drawing.Color.Transparent;
            this.panelConstant.Controls.Add(this.nudPositionY);
            this.panelConstant.Controls.Add(this.nudPositionX);
            this.panelConstant.Controls.Add(this.label3);
            this.panelConstant.Controls.Add(this.label4);
            this.panelConstant.Location = new System.Drawing.Point(10, 68);
            this.panelConstant.Name = "panelConstant";
            this.panelConstant.Size = new System.Drawing.Size(130, 57);
            this.panelConstant.TabIndex = 54;
            this.panelConstant.Visible = false;
            // 
            // nudPositionY
            // 
            this.nudPositionY.Location = new System.Drawing.Point(17, 30);
            this.nudPositionY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudPositionY.Name = "nudPositionY";
            this.nudPositionY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPositionY.OnChange = false;
            this.nudPositionY.Size = new System.Drawing.Size(67, 20);
            this.nudPositionY.TabIndex = 35;
            // 
            // nudPositionX
            // 
            this.nudPositionX.Location = new System.Drawing.Point(17, 3);
            this.nudPositionX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudPositionX.Name = "nudPositionX";
            this.nudPositionX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPositionX.OnChange = false;
            this.nudPositionX.Size = new System.Drawing.Size(67, 20);
            this.nudPositionX.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(-3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(-3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "X:";
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariableX);
            this.panelVariable.Controls.Add(this.label5);
            this.panelVariable.Controls.Add(this.label6);
            this.panelVariable.Controls.Add(this.cbVariableY);
            this.panelVariable.Location = new System.Drawing.Point(10, 68);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(130, 63);
            this.panelVariable.TabIndex = 53;
            this.panelVariable.Visible = false;
            // 
            // cbVariableX
            // 
            this.cbVariableX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableX.FormattingEnabled = true;
            this.cbVariableX.Location = new System.Drawing.Point(20, 3);
            this.cbVariableX.Name = "cbVariableX";
            this.cbVariableX.SelectedNode = null;
            this.cbVariableX.Size = new System.Drawing.Size(110, 21);
            this.cbVariableX.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(0, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(0, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Y:";
            // 
            // cbVariableY
            // 
            this.cbVariableY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableY.FormattingEnabled = true;
            this.cbVariableY.Location = new System.Drawing.Point(20, 30);
            this.cbVariableY.Name = "cbVariableY";
            this.cbVariableY.SelectedNode = null;
            this.cbVariableY.Size = new System.Drawing.Size(110, 21);
            this.cbVariableY.TabIndex = 47;
            // 
            // panelEvent
            // 
            this.panelEvent.BackColor = System.Drawing.Color.Transparent;
            this.panelEvent.Controls.Add(this.cbOnEvent);
            this.panelEvent.Location = new System.Drawing.Point(10, 68);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(130, 57);
            this.panelEvent.TabIndex = 55;
            this.panelEvent.Visible = false;
            // 
            // cbOnEvent
            // 
            this.cbOnEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOnEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOnEvent.FormattingEnabled = true;
            this.cbOnEvent.Location = new System.Drawing.Point(0, 3);
            this.cbOnEvent.Name = "cbOnEvent";
            this.cbOnEvent.ShowPlayer = true;
            this.cbOnEvent.ShowTarget = true;
            this.cbOnEvent.ShowTargets = false;
            this.cbOnEvent.Size = new System.Drawing.Size(130, 21);
            this.cbOnEvent.TabIndex = 47;
            this.cbOnEvent.ThisEvent = false;
            // 
            // DealDamageDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(333, 198);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DealDamageDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deal Damage";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelConstant.ResumeLayout(false);
            this.panelConstant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.panelEvent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel panelConstant;
        private CustomUpDown nudPositionY;
        private CustomUpDown nudPositionX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelVariable;
        private EGMGame.Controls.Game.VariableComboBox cbVariableX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private EGMGame.Controls.Game.VariableComboBox cbVariableY;
        private System.Windows.Forms.Panel panelEvent;
        private EGMGame.Controls.Game.MapEventComboBox cbOnEvent;
        private System.Windows.Forms.ComboBox cbValueType;
        private CustomUpDown nudValue;
        private EGMGame.Controls.Game.DataPropertyComboBox cbProperty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDamageType;
        private System.Windows.Forms.Label label9;
    }
}