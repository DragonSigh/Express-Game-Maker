namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs
{
    partial class ChangeParameterDialog
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
            this.numericOperationsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panelLocalVar = new System.Windows.Forms.Panel();
            this.localVariableList = new EGMGame.Controls.Game.LocalVariableComboBox(this.components);
            this.panelRand = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rand2Num = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rand1Num = new EGMGame.CustomUpDown();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.variablesList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelConst = new System.Windows.Forms.Panel();
            this.constantBox = new EGMGame.CustomUpDown();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOpType = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbProperty = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.cbHero = new EGMGame.Controls.Game.HeroComboBox(this.components);
            this.chkDisplayDamage = new System.Windows.Forms.CheckBox();
            this.numericOperationsBox.SuspendLayout();
            this.panelLocalVar.SuspendLayout();
            this.panelRand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rand2Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rand1Num)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(173, 307);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 36;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(92, 307);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 35;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // numericOperationsBox
            // 
            this.numericOperationsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.numericOperationsBox.Controls.Add(this.label17);
            this.numericOperationsBox.Controls.Add(this.label16);
            this.numericOperationsBox.Controls.Add(this.panelLocalVar);
            this.numericOperationsBox.Controls.Add(this.panelRand);
            this.numericOperationsBox.Controls.Add(this.panelVariable);
            this.numericOperationsBox.Controls.Add(this.panelConst);
            this.numericOperationsBox.Controls.Add(this.cbValue);
            this.numericOperationsBox.Controls.Add(this.label1);
            this.numericOperationsBox.Controls.Add(this.cbOpType);
            this.numericOperationsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.numericOperationsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.numericOperationsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.numericOperationsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.numericOperationsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.numericOperationsBox.Location = new System.Drawing.Point(12, 116);
            this.numericOperationsBox.Name = "numericOperationsBox";
            this.numericOperationsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.numericOperationsBox.Size = new System.Drawing.Size(236, 164);
            this.numericOperationsBox.TabIndex = 39;
            this.numericOperationsBox.TabStop = false;
            this.numericOperationsBox.Text = "Value";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(8, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(173, 13);
            this.label17.TabIndex = 73;
            this.label17.Text = "Choose the value for the operation.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(7, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(214, 13);
            this.label16.TabIndex = 72;
            this.label16.Text = "Choose the operation type for the operation.";
            // 
            // panelLocalVar
            // 
            this.panelLocalVar.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVar.Controls.Add(this.localVariableList);
            this.panelLocalVar.Enabled = false;
            this.panelLocalVar.Location = new System.Drawing.Point(7, 112);
            this.panelLocalVar.Name = "panelLocalVar";
            this.panelLocalVar.Size = new System.Drawing.Size(204, 34);
            this.panelLocalVar.TabIndex = 34;
            this.panelLocalVar.Visible = false;
            // 
            // localVariableList
            // 
            this.localVariableList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.localVariableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localVariableList.FormattingEnabled = true;
            this.localVariableList.Location = new System.Drawing.Point(6, 7);
            this.localVariableList.Name = "localVariableList";
            this.localVariableList.SelectedNode = null;
            this.localVariableList.Size = new System.Drawing.Size(113, 21);
            this.localVariableList.TabIndex = 34;
            // 
            // panelRand
            // 
            this.panelRand.BackColor = System.Drawing.Color.Transparent;
            this.panelRand.Controls.Add(this.label3);
            this.panelRand.Controls.Add(this.rand2Num);
            this.panelRand.Controls.Add(this.label2);
            this.panelRand.Controls.Add(this.rand1Num);
            this.panelRand.Enabled = false;
            this.panelRand.Location = new System.Drawing.Point(7, 112);
            this.panelRand.Name = "panelRand";
            this.panelRand.Size = new System.Drawing.Size(204, 37);
            this.panelRand.TabIndex = 5;
            this.panelRand.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(121, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "-";
            // 
            // rand2Num
            // 
            this.rand2Num.Location = new System.Drawing.Point(138, 7);
            this.rand2Num.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rand2Num.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.rand2Num.Name = "rand2Num";
            this.rand2Num.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rand2Num.OnChange = false;
            this.rand2Num.Size = new System.Drawing.Size(54, 20);
            this.rand2Num.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Between";
            // 
            // rand1Num
            // 
            this.rand1Num.Location = new System.Drawing.Point(61, 7);
            this.rand1Num.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rand1Num.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.rand1Num.Name = "rand1Num";
            this.rand1Num.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rand1Num.OnChange = false;
            this.rand1Num.Size = new System.Drawing.Size(54, 20);
            this.rand1Num.TabIndex = 14;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.variablesList);
            this.panelVariable.Enabled = false;
            this.panelVariable.Location = new System.Drawing.Point(7, 112);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(204, 34);
            this.panelVariable.TabIndex = 20;
            this.panelVariable.Visible = false;
            // 
            // variablesList
            // 
            this.variablesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variablesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variablesList.FormattingEnabled = true;
            this.variablesList.Location = new System.Drawing.Point(7, 7);
            this.variablesList.Name = "variablesList";
            this.variablesList.SelectedNode = null;
            this.variablesList.Size = new System.Drawing.Size(113, 21);
            this.variablesList.TabIndex = 33;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.constantBox);
            this.panelConst.Location = new System.Drawing.Point(7, 112);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(201, 37);
            this.panelConst.TabIndex = 20;
            // 
            // constantBox
            // 
            this.constantBox.Location = new System.Drawing.Point(7, 7);
            this.constantBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.constantBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.constantBox.Name = "constantBox";
            this.constantBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.constantBox.OnChange = false;
            this.constantBox.Size = new System.Drawing.Size(95, 20);
            this.constantBox.TabIndex = 8;
            // 
            // cbValue
            // 
            this.cbValue.DisplayMember = "Constant";
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Items.AddRange(new object[] {
            "Constant",
            "Random Number",
            "Variable",
            "Local Variable"});
            this.cbValue.Location = new System.Drawing.Point(47, 85);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(106, 21);
            this.cbValue.TabIndex = 4;
            this.cbValue.ValueMember = "Constant";
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Value";
            // 
            // cbOpType
            // 
            this.cbOpType.DisplayMember = "Add";
            this.cbOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpType.FormattingEnabled = true;
            this.cbOpType.Items.AddRange(new object[] {
            "Set (=)",
            "Add (+)",
            "Subtract (-)",
            "Multiply (*)",
            "Divide (/)",
            "Exponentiate (^)",
            "Modulate (r)"});
            this.cbOpType.Location = new System.Drawing.Point(10, 45);
            this.cbOpType.Name = "cbOpType";
            this.cbOpType.Size = new System.Drawing.Size(121, 21);
            this.cbOpType.TabIndex = 2;
            this.cbOpType.ValueMember = "Add";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbProperty);
            this.impactGroupBox1.Controls.Add(this.label14);
            this.impactGroupBox1.Controls.Add(this.cbHero);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 98);
            this.impactGroupBox1.TabIndex = 34;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Hero";
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
            this.cbProperty.Location = new System.Drawing.Point(7, 68);
            this.cbProperty.Name = "cbProperty";
            this.cbProperty.Size = new System.Drawing.Size(125, 21);
            this.cbProperty.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(4, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 13);
            this.label14.TabIndex = 74;
            this.label14.Text = "Choose the property.";
            // 
            // cbHero
            // 
            this.cbHero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHero.FormattingEnabled = true;
            this.cbHero.Location = new System.Drawing.Point(7, 28);
            this.cbHero.Name = "cbHero";
            this.cbHero.Noneable = false;
            this.cbHero.SelectedNode = null;
            this.cbHero.Size = new System.Drawing.Size(142, 21);
            this.cbHero.TabIndex = 0;
            // 
            // chkDisplayDamage
            // 
            this.chkDisplayDamage.AutoSize = true;
            this.chkDisplayDamage.Location = new System.Drawing.Point(12, 286);
            this.chkDisplayDamage.Name = "chkDisplayDamage";
            this.chkDisplayDamage.Size = new System.Drawing.Size(118, 17);
            this.chkDisplayDamage.TabIndex = 40;
            this.chkDisplayDamage.Text = "Display As Damage";
            this.chkDisplayDamage.UseVisualStyleBackColor = true;
            // 
            // ChangeParameterDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(260, 342);
            this.Controls.Add(this.chkDisplayDamage);
            this.Controls.Add(this.numericOperationsBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeParameterDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Parameter";
            this.numericOperationsBox.ResumeLayout(false);
            this.numericOperationsBox.PerformLayout();
            this.panelLocalVar.ResumeLayout(false);
            this.panelRand.ResumeLayout(false);
            this.panelRand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rand2Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rand1Num)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelConst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.HeroComboBox cbHero;
        private System.Windows.Forms.Label label14;
        private EGMGame.Controls.Game.DataPropertyComboBox cbProperty;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox numericOperationsBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelVariable;
        private EGMGame.Controls.Game.VariableComboBox variablesList;
        private System.Windows.Forms.Panel panelLocalVar;
        private EGMGame.Controls.Game.LocalVariableComboBox localVariableList;
        private System.Windows.Forms.Panel panelRand;
        private System.Windows.Forms.Label label3;
        private CustomUpDown rand2Num;
        private System.Windows.Forms.Label label2;
        private CustomUpDown rand1Num;
        private System.Windows.Forms.Panel panelConst;
        private CustomUpDown constantBox;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOpType;
        private System.Windows.Forms.CheckBox chkDisplayDamage;
    }
}