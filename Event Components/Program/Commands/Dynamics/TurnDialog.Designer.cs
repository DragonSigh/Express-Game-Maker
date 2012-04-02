namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class TurnDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.btnBotRight = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnBotLeft = new System.Windows.Forms.Button();
            this.nudBaseAngle = new EGMGame.CustomUpDown();
            this.asBaseAngle = new EGMGame.Controls.ImpactUI.ImpactAngleSelector();
            this.panelConst = new System.Windows.Forms.Panel();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelVariables = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbVariableX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbVariableY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelLocalVariables = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLocalVariableY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cbLocalVariableX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).BeginInit();
            this.panelConst.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.panelVariables.SuspendLayout();
            this.panelLocalVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(103, 135);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(22, 135);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 12;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(92, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Angle:";
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(38, 68);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(14, 13);
            this.btnBottom.TabIndex = 17;
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(72, 37);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(14, 13);
            this.btnRight.TabIndex = 18;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(6, 37);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(14, 13);
            this.btnLeft.TabIndex = 19;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnTop
            // 
            this.btnTop.Location = new System.Drawing.Point(38, 3);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(14, 13);
            this.btnTop.TabIndex = 20;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnBotRight
            // 
            this.btnBotRight.Location = new System.Drawing.Point(72, 68);
            this.btnBotRight.Name = "btnBotRight";
            this.btnBotRight.Size = new System.Drawing.Size(14, 13);
            this.btnBotRight.TabIndex = 21;
            this.btnBotRight.UseVisualStyleBackColor = true;
            this.btnBotRight.Click += new System.EventHandler(this.btnBotRight_Click);
            // 
            // btnTopRight
            // 
            this.btnTopRight.Location = new System.Drawing.Point(72, 3);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(14, 13);
            this.btnTopRight.TabIndex = 22;
            this.btnTopRight.UseVisualStyleBackColor = true;
            this.btnTopRight.Click += new System.EventHandler(this.btnTopRight_Click);
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Location = new System.Drawing.Point(6, 3);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(14, 13);
            this.btnTopLeft.TabIndex = 23;
            this.btnTopLeft.UseVisualStyleBackColor = true;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // btnBotLeft
            // 
            this.btnBotLeft.Location = new System.Drawing.Point(6, 68);
            this.btnBotLeft.Name = "btnBotLeft";
            this.btnBotLeft.Size = new System.Drawing.Size(14, 13);
            this.btnBotLeft.TabIndex = 24;
            this.btnBotLeft.UseVisualStyleBackColor = true;
            this.btnBotLeft.Click += new System.EventHandler(this.btnBotLeft_Click);
            // 
            // nudBaseAngle
            // 
            this.nudBaseAngle.Location = new System.Drawing.Point(135, 35);
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
            this.nudBaseAngle.Size = new System.Drawing.Size(45, 20);
            this.nudBaseAngle.TabIndex = 16;
            this.nudBaseAngle.ValueChanged += new System.EventHandler(this.nudBaseAngle_ValueChanged);
            // 
            // asBaseAngle
            // 
            this.asBaseAngle.Angle = 0;
            this.asBaseAngle.BackColor = System.Drawing.Color.Transparent;
            this.asBaseAngle.Location = new System.Drawing.Point(26, 22);
            this.asBaseAngle.Name = "asBaseAngle";
            this.asBaseAngle.Size = new System.Drawing.Size(40, 40);
            this.asBaseAngle.TabIndex = 14;
            this.asBaseAngle.AngleChanged += new EGMGame.Controls.ImpactUI.ImpactAngleSelector.AngleChangedDelegate(this.asBaseAngle_AngleChanged);
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.btnTopLeft);
            this.panelConst.Controls.Add(this.btnBotLeft);
            this.panelConst.Controls.Add(this.asBaseAngle);
            this.panelConst.Controls.Add(this.label2);
            this.panelConst.Controls.Add(this.btnTopRight);
            this.panelConst.Controls.Add(this.nudBaseAngle);
            this.panelConst.Controls.Add(this.btnBotRight);
            this.panelConst.Controls.Add(this.btnBottom);
            this.panelConst.Controls.Add(this.btnTop);
            this.panelConst.Controls.Add(this.btnRight);
            this.panelConst.Controls.Add(this.btnLeft);
            this.panelConst.Location = new System.Drawing.Point(1, 36);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(188, 92);
            this.panelConst.TabIndex = 25;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Local Variable",
            "Variables (x,y)",
            "Local Variables (x,y)"});
            this.cbType.Location = new System.Drawing.Point(7, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 26;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.label1);
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(1, 36);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(188, 92);
            this.panelVariable.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Angle";
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(38, 7);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.Noneable = false;
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(142, 21);
            this.cbVariable.TabIndex = 28;
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.label3);
            this.panelLocalVariable.Controls.Add(this.cbLocalVariable);
            this.panelLocalVariable.Location = new System.Drawing.Point(1, 36);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(188, 92);
            this.panelLocalVariable.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Angle";
            // 
            // cbLocalVariable
            // 
            this.cbLocalVariable.AllowCategories = true;
            this.cbLocalVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariable.FormattingEnabled = true;
            this.cbLocalVariable.Location = new System.Drawing.Point(38, 7);
            this.cbLocalVariable.Name = "cbLocalVariable";
            this.cbLocalVariable.Noneable = false;
            this.cbLocalVariable.SelectedNode = null;
            this.cbLocalVariable.Size = new System.Drawing.Size(142, 21);
            this.cbLocalVariable.TabIndex = 29;
            // 
            // panelVariables
            // 
            this.panelVariables.BackColor = System.Drawing.Color.Transparent;
            this.panelVariables.Controls.Add(this.label5);
            this.panelVariables.Controls.Add(this.cbVariableY);
            this.panelVariables.Controls.Add(this.label4);
            this.panelVariables.Controls.Add(this.cbVariableX);
            this.panelVariables.Location = new System.Drawing.Point(1, 36);
            this.panelVariables.Name = "panelVariables";
            this.panelVariables.Size = new System.Drawing.Size(188, 92);
            this.panelVariables.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "X";
            // 
            // cbVariableX
            // 
            this.cbVariableX.AllowCategories = true;
            this.cbVariableX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableX.FormattingEnabled = true;
            this.cbVariableX.Location = new System.Drawing.Point(31, 7);
            this.cbVariableX.Name = "cbVariableX";
            this.cbVariableX.Noneable = false;
            this.cbVariableX.SelectedNode = null;
            this.cbVariableX.Size = new System.Drawing.Size(149, 21);
            this.cbVariableX.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Y";
            // 
            // cbVariableY
            // 
            this.cbVariableY.AllowCategories = true;
            this.cbVariableY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableY.FormattingEnabled = true;
            this.cbVariableY.Location = new System.Drawing.Point(31, 34);
            this.cbVariableY.Name = "cbVariableY";
            this.cbVariableY.Noneable = false;
            this.cbVariableY.SelectedNode = null;
            this.cbVariableY.Size = new System.Drawing.Size(149, 21);
            this.cbVariableY.TabIndex = 29;
            // 
            // panelLocalVariables
            // 
            this.panelLocalVariables.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariables.Controls.Add(this.label6);
            this.panelLocalVariables.Controls.Add(this.cbLocalVariableY);
            this.panelLocalVariables.Controls.Add(this.label7);
            this.panelLocalVariables.Controls.Add(this.cbLocalVariableX);
            this.panelLocalVariables.Location = new System.Drawing.Point(1, 36);
            this.panelLocalVariables.Name = "panelLocalVariables";
            this.panelLocalVariables.Size = new System.Drawing.Size(188, 92);
            this.panelLocalVariables.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Y";
            // 
            // cbLocalVariableY
            // 
            this.cbLocalVariableY.AllowCategories = true;
            this.cbLocalVariableY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariableY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariableY.FormattingEnabled = true;
            this.cbLocalVariableY.Location = new System.Drawing.Point(31, 34);
            this.cbLocalVariableY.Name = "cbLocalVariableY";
            this.cbLocalVariableY.Noneable = false;
            this.cbLocalVariableY.SelectedNode = null;
            this.cbLocalVariableY.Size = new System.Drawing.Size(149, 21);
            this.cbLocalVariableY.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "X";
            // 
            // cbLocalVariableX
            // 
            this.cbLocalVariableX.AllowCategories = true;
            this.cbLocalVariableX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariableX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariableX.FormattingEnabled = true;
            this.cbLocalVariableX.Location = new System.Drawing.Point(31, 7);
            this.cbLocalVariableX.Name = "cbLocalVariableX";
            this.cbLocalVariableX.Noneable = false;
            this.cbLocalVariableX.SelectedNode = null;
            this.cbLocalVariableX.Size = new System.Drawing.Size(149, 21);
            this.cbLocalVariableX.TabIndex = 28;
            // 
            // TurnDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(185, 168);
            this.Controls.Add(this.panelLocalVariables);
            this.Controls.Add(this.panelVariables);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelLocalVariable);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TurnDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Turn";
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseAngle)).EndInit();
            this.panelConst.ResumeLayout(false);
            this.panelConst.PerformLayout();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.panelLocalVariable.ResumeLayout(false);
            this.panelLocalVariable.PerformLayout();
            this.panelVariables.ResumeLayout(false);
            this.panelVariables.PerformLayout();
            this.panelLocalVariables.ResumeLayout(false);
            this.panelLocalVariables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private CustomUpDown nudBaseAngle;
        private System.Windows.Forms.Label label2;
        private EGMGame.Controls.ImpactUI.ImpactAngleSelector asBaseAngle;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnBotRight;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnBotLeft;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label label1;
        private Game.VariableComboBox cbVariable;
        private System.Windows.Forms.Panel panelLocalVariable;
        private System.Windows.Forms.Label label3;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.Panel panelVariables;
        private System.Windows.Forms.Label label5;
        private Game.VariableComboBox cbVariableY;
        private System.Windows.Forms.Label label4;
        private Game.VariableComboBox cbVariableX;
        private System.Windows.Forms.Panel panelLocalVariables;
        private System.Windows.Forms.Label label6;
        private Game.VariableComboBox cbLocalVariableY;
        private System.Windows.Forms.Label label7;
        private Game.VariableComboBox cbLocalVariableX;
    }
}