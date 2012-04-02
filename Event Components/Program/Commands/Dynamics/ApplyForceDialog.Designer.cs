namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class ApplyForceDialog
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
            this.btnBotLeft = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.btnBotRight = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBottom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chWait = new System.Windows.Forms.CheckBox();
            this.turnBox = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.nudBaseAngle = new EGMGame.CustomUpDown();
            this.asBaseAngle = new EGMGame.Controls.ImpactUI.ImpactAngleSelector();
            this.pixelBox = new EGMGame.CustomUpDown();
            this.panelCustom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUseForce = new System.Windows.Forms.ComboBox();
            this.cbMovement = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelConst = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMovement = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.panelCustom.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBotLeft
            // 
            this.btnBotLeft.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBotLeft.Location = new System.Drawing.Point(3, 68);
            this.btnBotLeft.Name = "btnBotLeft";
            this.btnBotLeft.Size = new System.Drawing.Size(14, 13);
            this.btnBotLeft.TabIndex = 67;
            this.btnBotLeft.UseVisualStyleBackColor = true;
            this.btnBotLeft.Click += new System.EventHandler(this.btnBotLeft_Click);
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Location = new System.Drawing.Point(3, 3);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(14, 13);
            this.btnTopLeft.TabIndex = 66;
            this.btnTopLeft.UseVisualStyleBackColor = true;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // btnTopRight
            // 
            this.btnTopRight.Location = new System.Drawing.Point(69, 3);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(14, 13);
            this.btnTopRight.TabIndex = 65;
            this.btnTopRight.UseVisualStyleBackColor = true;
            this.btnTopRight.Click += new System.EventHandler(this.btnTopRight_Click);
            // 
            // btnBotRight
            // 
            this.btnBotRight.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBotRight.Location = new System.Drawing.Point(69, 68);
            this.btnBotRight.Name = "btnBotRight";
            this.btnBotRight.Size = new System.Drawing.Size(14, 13);
            this.btnBotRight.TabIndex = 64;
            this.btnBotRight.UseVisualStyleBackColor = true;
            this.btnBotRight.Click += new System.EventHandler(this.btnBotRight_Click);
            // 
            // btnTop
            // 
            this.btnTop.Location = new System.Drawing.Point(35, 3);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(14, 13);
            this.btnTop.TabIndex = 63;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(3, 37);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(14, 13);
            this.btnLeft.TabIndex = 62;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(69, 37);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(14, 13);
            this.btnRight.TabIndex = 61;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(35, 68);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(14, 13);
            this.btnBottom.TabIndex = 60;
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(89, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Angle:";
            // 
            // chWait
            // 
            this.chWait.AutoSize = true;
            this.chWait.BackColor = System.Drawing.Color.Transparent;
            this.chWait.Checked = true;
            this.chWait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chWait.Location = new System.Drawing.Point(147, 239);
            this.chWait.Name = "chWait";
            this.chWait.Size = new System.Drawing.Size(48, 17);
            this.chWait.TabIndex = 56;
            this.chWait.Text = "Wait";
            this.chWait.UseVisualStyleBackColor = false;
            // 
            // turnBox
            // 
            this.turnBox.AutoSize = true;
            this.turnBox.BackColor = System.Drawing.Color.Transparent;
            this.turnBox.Checked = true;
            this.turnBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.turnBox.Location = new System.Drawing.Point(93, 239);
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(48, 17);
            this.turnBox.TabIndex = 55;
            this.turnBox.Text = "Turn";
            this.turnBox.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(117, 262);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 53;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(32, 262);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 52;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // nudBaseAngle
            // 
            this.nudBaseAngle.Location = new System.Drawing.Point(132, 35);
            this.nudBaseAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudBaseAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudBaseAngle.Name = "nudBaseAngle";
            this.nudBaseAngle.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudBaseAngle.OnChange = false;
            this.nudBaseAngle.Size = new System.Drawing.Size(39, 20);
            this.nudBaseAngle.TabIndex = 59;
            this.nudBaseAngle.ValueChanged += new System.EventHandler(this.nudBaseAngle_ValueChanged);
            // 
            // asBaseAngle
            // 
            this.asBaseAngle.Angle = 0;
            this.asBaseAngle.BackColor = System.Drawing.Color.Transparent;
            this.asBaseAngle.Location = new System.Drawing.Point(23, 22);
            this.asBaseAngle.Name = "asBaseAngle";
            this.asBaseAngle.Size = new System.Drawing.Size(40, 40);
            this.asBaseAngle.TabIndex = 57;
            this.asBaseAngle.AngleChanged += new EGMGame.Controls.ImpactUI.ImpactAngleSelector.AngleChangedDelegate(this.asBaseAngle_AngleChanged);
            // 
            // pixelBox
            // 
            this.pixelBox.DecimalPlaces = 3;
            this.pixelBox.Location = new System.Drawing.Point(40, 8);
            this.pixelBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.pixelBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pixelBox.OnChange = true;
            this.pixelBox.Size = new System.Drawing.Size(66, 20);
            this.pixelBox.TabIndex = 54;
            this.pixelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panelCustom
            // 
            this.panelCustom.BackColor = System.Drawing.Color.Transparent;
            this.panelCustom.Controls.Add(this.btnTopLeft);
            this.panelCustom.Controls.Add(this.btnBotLeft);
            this.panelCustom.Controls.Add(this.asBaseAngle);
            this.panelCustom.Controls.Add(this.label2);
            this.panelCustom.Controls.Add(this.btnTopRight);
            this.panelCustom.Controls.Add(this.nudBaseAngle);
            this.panelCustom.Controls.Add(this.btnBotRight);
            this.panelCustom.Controls.Add(this.btnBottom);
            this.panelCustom.Controls.Add(this.btnTop);
            this.panelCustom.Controls.Add(this.btnRight);
            this.panelCustom.Controls.Add(this.btnLeft);
            this.panelCustom.Location = new System.Drawing.Point(15, 79);
            this.panelCustom.Name = "panelCustom";
            this.panelCustom.Size = new System.Drawing.Size(177, 89);
            this.panelCustom.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Choose movement direction.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Use ";
            // 
            // cbUseForce
            // 
            this.cbUseForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUseForce.FormattingEnabled = true;
            this.cbUseForce.Items.AddRange(new object[] {
            "Force",
            "Impulse"});
            this.cbUseForce.Location = new System.Drawing.Point(49, 52);
            this.cbUseForce.Name = "cbUseForce";
            this.cbUseForce.Size = new System.Drawing.Size(114, 21);
            this.cbUseForce.TabIndex = 70;
            // 
            // cbMovement
            // 
            this.cbMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovement.FormattingEnabled = true;
            this.cbMovement.Items.AddRange(new object[] {
            "Custom",
            "Forward",
            "Backward",
            "Leftward",
            "Rightward"});
            this.cbMovement.Location = new System.Drawing.Point(15, 25);
            this.cbMovement.Name = "cbMovement";
            this.cbMovement.Size = new System.Drawing.Size(124, 21);
            this.cbMovement.TabIndex = 69;
            this.cbMovement.SelectedIndexChanged += new System.EventHandler(this.cbMovement_SelectedIndexChanged);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Local Variable"});
            this.cbType.Location = new System.Drawing.Point(15, 174);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 75;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.label5);
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(9, 198);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(183, 35);
            this.panelVariable.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Force";
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(43, 7);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(142, 21);
            this.cbVariable.TabIndex = 28;
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.label6);
            this.panelLocalVariable.Controls.Add(this.cbLocalVariable);
            this.panelLocalVariable.Location = new System.Drawing.Point(9, 198);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(183, 35);
            this.panelLocalVariable.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Force";
            // 
            // cbLocalVariable
            // 
            this.cbLocalVariable.AllowCategories = true;
            this.cbLocalVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariable.FormattingEnabled = true;
            this.cbLocalVariable.Location = new System.Drawing.Point(44, 7);
            this.cbLocalVariable.Name = "cbLocalVariable";
            this.cbLocalVariable.SelectedNode = null;
            this.cbLocalVariable.Size = new System.Drawing.Size(142, 21);
            this.cbLocalVariable.TabIndex = 29;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.label4);
            this.panelConst.Controls.Add(this.pixelBox);
            this.panelConst.Location = new System.Drawing.Point(9, 198);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(183, 35);
            this.panelConst.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Force";
            // 
            // chkMovement
            // 
            this.chkMovement.AutoSize = true;
            this.chkMovement.BackColor = System.Drawing.Color.Transparent;
            this.chkMovement.Checked = true;
            this.chkMovement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovement.Location = new System.Drawing.Point(9, 239);
            this.chkMovement.Name = "chkMovement";
            this.chkMovement.Size = new System.Drawing.Size(76, 17);
            this.chkMovement.TabIndex = 78;
            this.chkMovement.Text = "Movement";
            this.chkMovement.UseVisualStyleBackColor = false;
            // 
            // ApplyForceDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(207, 295);
            this.Controls.Add(this.chkMovement);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbUseForce);
            this.Controls.Add(this.cbMovement);
            this.Controls.Add(this.panelCustom);
            this.Controls.Add(this.chWait);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelVariable);
            this.Controls.Add(this.panelLocalVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ApplyForceDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply Force";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplyForceDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.panelCustom.ResumeLayout(false);
            this.panelCustom.PerformLayout();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.panelLocalVariable.ResumeLayout(false);
            this.panelLocalVariable.PerformLayout();
            this.panelConst.ResumeLayout(false);
            this.panelConst.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBotLeft;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Button btnBotRight;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBottom;
        private CustomUpDown nudBaseAngle;
        private System.Windows.Forms.Label label2;
        private EGMGame.Controls.ImpactUI.ImpactAngleSelector asBaseAngle;
        private System.Windows.Forms.CheckBox chWait;
        private System.Windows.Forms.CheckBox turnBox;
        private CustomUpDown pixelBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel panelCustom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUseForce;
        private System.Windows.Forms.ComboBox cbMovement;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label label5;
        private Game.VariableComboBox cbVariable;
        private System.Windows.Forms.Panel panelLocalVariable;
        private System.Windows.Forms.Label label6;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMovement;
    }
}