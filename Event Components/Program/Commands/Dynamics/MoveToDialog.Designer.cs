namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class MoveToDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveToDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.downRightBtn = new System.Windows.Forms.CheckBox();
            this.upBtn = new System.Windows.Forms.CheckBox();
            this.turnBox = new System.Windows.Forms.CheckBox();
            this.upRightBtn = new System.Windows.Forms.CheckBox();
            this.upLeftBtn = new System.Windows.Forms.CheckBox();
            this.downLeftBtn = new System.Windows.Forms.CheckBox();
            this.rightBtn = new System.Windows.Forms.CheckBox();
            this.leftBtn = new System.Windows.Forms.CheckBox();
            this.downBtn = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudXPos = new EGMGame.CustomUpDown();
            this.nudYPos = new EGMGame.CustomUpDown();
            this.btnShowMap = new System.Windows.Forms.Button();
            this.chWait = new System.Windows.Forms.CheckBox();
            this.nudPrecision = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chImpulse = new System.Windows.Forms.CheckBox();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelConst = new System.Windows.Forms.Panel();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbLocalVarY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbLocalVarX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbVariableY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbVariableX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudXPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecision)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(195, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 39);
            this.label1.TabIndex = 49;
            this.label1.Text = "Click and highlight \r\nthe directions the \r\ncharacter can move.";
            // 
            // downRightBtn
            // 
            this.downRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downRightBtn.AutoSize = true;
            this.downRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("downRightBtn.Image")));
            this.downRightBtn.Location = new System.Drawing.Point(250, 92);
            this.downRightBtn.Name = "downRightBtn";
            this.downRightBtn.Size = new System.Drawing.Size(22, 22);
            this.downRightBtn.TabIndex = 48;
            this.downRightBtn.UseVisualStyleBackColor = true;
            // 
            // upBtn
            // 
            this.upBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upBtn.AutoSize = true;
            this.upBtn.Checked = true;
            this.upBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.upBtn.Image = ((System.Drawing.Image)(resources.GetObject("upBtn.Image")));
            this.upBtn.Location = new System.Drawing.Point(222, 36);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(22, 22);
            this.upBtn.TabIndex = 41;
            this.upBtn.UseVisualStyleBackColor = true;
            // 
            // turnBox
            // 
            this.turnBox.AutoSize = true;
            this.turnBox.BackColor = System.Drawing.Color.Transparent;
            this.turnBox.Checked = true;
            this.turnBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.turnBox.Location = new System.Drawing.Point(76, 176);
            this.turnBox.Name = "turnBox";
            this.turnBox.Size = new System.Drawing.Size(48, 17);
            this.turnBox.TabIndex = 40;
            this.turnBox.Text = "Turn";
            this.turnBox.UseVisualStyleBackColor = false;
            // 
            // upRightBtn
            // 
            this.upRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upRightBtn.AutoSize = true;
            this.upRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("upRightBtn.Image")));
            this.upRightBtn.Location = new System.Drawing.Point(250, 36);
            this.upRightBtn.Name = "upRightBtn";
            this.upRightBtn.Size = new System.Drawing.Size(22, 22);
            this.upRightBtn.TabIndex = 47;
            this.upRightBtn.UseVisualStyleBackColor = true;
            // 
            // upLeftBtn
            // 
            this.upLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upLeftBtn.AutoSize = true;
            this.upLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("upLeftBtn.Image")));
            this.upLeftBtn.Location = new System.Drawing.Point(196, 36);
            this.upLeftBtn.Name = "upLeftBtn";
            this.upLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.upLeftBtn.TabIndex = 46;
            this.upLeftBtn.UseVisualStyleBackColor = true;
            // 
            // downLeftBtn
            // 
            this.downLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downLeftBtn.AutoSize = true;
            this.downLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("downLeftBtn.Image")));
            this.downLeftBtn.Location = new System.Drawing.Point(196, 92);
            this.downLeftBtn.Name = "downLeftBtn";
            this.downLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.downLeftBtn.TabIndex = 45;
            this.downLeftBtn.UseVisualStyleBackColor = true;
            // 
            // rightBtn
            // 
            this.rightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rightBtn.AutoSize = true;
            this.rightBtn.Checked = true;
            this.rightBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightBtn.Image = ((System.Drawing.Image)(resources.GetObject("rightBtn.Image")));
            this.rightBtn.Location = new System.Drawing.Point(250, 64);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(22, 22);
            this.rightBtn.TabIndex = 44;
            this.rightBtn.UseVisualStyleBackColor = true;
            // 
            // leftBtn
            // 
            this.leftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.leftBtn.AutoSize = true;
            this.leftBtn.Checked = true;
            this.leftBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftBtn.Image = ((System.Drawing.Image)(resources.GetObject("leftBtn.Image")));
            this.leftBtn.Location = new System.Drawing.Point(196, 64);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(22, 22);
            this.leftBtn.TabIndex = 43;
            this.leftBtn.UseVisualStyleBackColor = true;
            // 
            // downBtn
            // 
            this.downBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downBtn.AutoSize = true;
            this.downBtn.Checked = true;
            this.downBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downBtn.Image = ((System.Drawing.Image)(resources.GetObject("downBtn.Image")));
            this.downBtn.Location = new System.Drawing.Point(222, 92);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(22, 22);
            this.downBtn.TabIndex = 42;
            this.downBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(211, 210);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 51;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(130, 210);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 50;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Map X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Map Y";
            // 
            // nudXPos
            // 
            this.nudXPos.Location = new System.Drawing.Point(47, 32);
            this.nudXPos.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudXPos.Name = "nudXPos";
            this.nudXPos.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudXPos.OnChange = false;
            this.nudXPos.Size = new System.Drawing.Size(42, 20);
            this.nudXPos.TabIndex = 54;
            // 
            // nudYPos
            // 
            this.nudYPos.Location = new System.Drawing.Point(47, 58);
            this.nudYPos.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudYPos.Name = "nudYPos";
            this.nudYPos.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudYPos.OnChange = false;
            this.nudYPos.Size = new System.Drawing.Size(42, 20);
            this.nudYPos.TabIndex = 55;
            // 
            // btnShowMap
            // 
            this.btnShowMap.Location = new System.Drawing.Point(6, 3);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(76, 23);
            this.btnShowMap.TabIndex = 56;
            this.btnShowMap.Text = "Show Map";
            this.btnShowMap.UseVisualStyleBackColor = true;
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            // 
            // chWait
            // 
            this.chWait.AutoSize = true;
            this.chWait.BackColor = System.Drawing.Color.Transparent;
            this.chWait.Checked = true;
            this.chWait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chWait.Location = new System.Drawing.Point(8, 195);
            this.chWait.Name = "chWait";
            this.chWait.Size = new System.Drawing.Size(48, 17);
            this.chWait.TabIndex = 57;
            this.chWait.Text = "Wait";
            this.chWait.UseVisualStyleBackColor = false;
            // 
            // nudPrecision
            // 
            this.nudPrecision.Location = new System.Drawing.Point(8, 150);
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
            this.nudPrecision.TabIndex = 59;
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
            this.label4.Location = new System.Drawing.Point(5, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Precision";
            // 
            // chImpulse
            // 
            this.chImpulse.AutoSize = true;
            this.chImpulse.BackColor = System.Drawing.Color.Transparent;
            this.chImpulse.Location = new System.Drawing.Point(8, 176);
            this.chImpulse.Name = "chImpulse";
            this.chImpulse.Size = new System.Drawing.Size(62, 17);
            this.chImpulse.TabIndex = 60;
            this.chImpulse.Text = "Impulse";
            this.chImpulse.UseVisualStyleBackColor = false;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariableY);
            this.panelVariable.Controls.Add(this.label5);
            this.panelVariable.Controls.Add(this.label8);
            this.panelVariable.Controls.Add(this.cbVariableX);
            this.panelVariable.Location = new System.Drawing.Point(2, 39);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(188, 92);
            this.panelVariable.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Map Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Map X";
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.cbLocalVarY);
            this.panelLocalVariable.Controls.Add(this.label6);
            this.panelLocalVariable.Controls.Add(this.label9);
            this.panelLocalVariable.Controls.Add(this.cbLocalVarX);
            this.panelLocalVariable.Location = new System.Drawing.Point(2, 39);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(188, 92);
            this.panelLocalVariable.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Map Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Map X";
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.btnShowMap);
            this.panelConst.Controls.Add(this.label2);
            this.panelConst.Controls.Add(this.label3);
            this.panelConst.Controls.Add(this.nudXPos);
            this.panelConst.Controls.Add(this.nudYPos);
            this.panelConst.Location = new System.Drawing.Point(2, 39);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(188, 92);
            this.panelConst.TabIndex = 61;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Local Variable"});
            this.cbType.Location = new System.Drawing.Point(8, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 57;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // cbLocalVarY
            // 
            this.cbLocalVarY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVarY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVarY.FormattingEnabled = true;
            this.cbLocalVarY.Location = new System.Drawing.Point(47, 31);
            this.cbLocalVarY.Name = "cbLocalVarY";
            this.cbLocalVarY.SelectedNode = null;
            this.cbLocalVarY.Size = new System.Drawing.Size(129, 21);
            this.cbLocalVarY.TabIndex = 60;
            // 
            // cbLocalVarX
            // 
            this.cbLocalVarX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVarX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVarX.FormattingEnabled = true;
            this.cbLocalVarX.Location = new System.Drawing.Point(47, 3);
            this.cbLocalVarX.Name = "cbLocalVarX";
            this.cbLocalVarX.SelectedNode = null;
            this.cbLocalVarX.Size = new System.Drawing.Size(129, 21);
            this.cbLocalVarX.TabIndex = 57;
            // 
            // cbVariableY
            // 
            this.cbVariableY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableY.FormattingEnabled = true;
            this.cbVariableY.Location = new System.Drawing.Point(47, 31);
            this.cbVariableY.Name = "cbVariableY";
            this.cbVariableY.SelectedNode = null;
            this.cbVariableY.Size = new System.Drawing.Size(129, 21);
            this.cbVariableY.TabIndex = 56;
            // 
            // cbVariableX
            // 
            this.cbVariableX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableX.FormattingEnabled = true;
            this.cbVariableX.Location = new System.Drawing.Point(47, 3);
            this.cbVariableX.Name = "cbVariableX";
            this.cbVariableX.SelectedNode = null;
            this.cbVariableX.Size = new System.Drawing.Size(129, 21);
            this.cbVariableX.TabIndex = 28;
            // 
            // MoveToDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(298, 245);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.chImpulse);
            this.Controls.Add(this.nudPrecision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chWait);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downRightBtn);
            this.Controls.Add(this.upBtn);
            this.Controls.Add(this.turnBox);
            this.Controls.Add(this.upRightBtn);
            this.Controls.Add(this.upLeftBtn);
            this.Controls.Add(this.downLeftBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.panelLocalVariable);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveToDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move To Position";
            ((System.ComponentModel.ISupportInitialize)(this.nudXPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecision)).EndInit();
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox downRightBtn;
        private System.Windows.Forms.CheckBox upBtn;
        private System.Windows.Forms.CheckBox turnBox;
        private System.Windows.Forms.CheckBox upRightBtn;
        private System.Windows.Forms.CheckBox upLeftBtn;
        private System.Windows.Forms.CheckBox downLeftBtn;
        private System.Windows.Forms.CheckBox rightBtn;
        private System.Windows.Forms.CheckBox leftBtn;
        private System.Windows.Forms.CheckBox downBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomUpDown nudXPos;
        private CustomUpDown nudYPos;
        private System.Windows.Forms.Button btnShowMap;
        private System.Windows.Forms.CheckBox chWait;
        private CustomUpDown nudPrecision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chImpulse;
        private System.Windows.Forms.Panel panelVariable;
        private Game.VariableComboBox cbVariableY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private Game.VariableComboBox cbVariableX;
        private System.Windows.Forms.Panel panelLocalVariable;
        private System.Windows.Forms.Panel panelConst;
        private Game.VariableComboBox cbLocalVarY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private Game.VariableComboBox cbLocalVarX;
        private System.Windows.Forms.ComboBox cbType;
    }
}