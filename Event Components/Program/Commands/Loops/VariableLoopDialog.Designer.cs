namespace EGMGame
{
    partial class VariableLoopDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbConditionEvent = new EGMGame.Controls.TreeViewComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConditionOther = new System.Windows.Forms.ComboBox();
            this.rbConditionOther = new System.Windows.Forms.RadioButton();
            this.cbConditionEventProperty = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbConditionEvent = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbConditionDatabaseProperty = new System.Windows.Forms.ComboBox();
            this.cbConditionDatabaseItem = new System.Windows.Forms.ComboBox();
            this.cbConditionDatabase = new System.Windows.Forms.ComboBox();
            this.cbConditionLocalVariable = new System.Windows.Forms.ComboBox();
            this.cbConditionVariables = new System.Windows.Forms.ComboBox();
            this.rbConditionLocalVariable = new System.Windows.Forms.RadioButton();
            this.rbConditionVariable = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.nudConditionRandom2 = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudConditionRandom1 = new EGMGame.CustomUpDown();
            this.nudConditionConstant = new EGMGame.CustomUpDown();
            this.rbConditionData = new System.Windows.Forms.RadioButton();
            this.rbConditionRandomNumber = new System.Windows.Forms.RadioButton();
            this.rbConditionConstant = new System.Windows.Forms.RadioButton();
            this.cbConditionOperations = new System.Windows.Forms.ComboBox();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbIncrementEvent = new EGMGame.Controls.TreeViewComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbIncrementOther = new System.Windows.Forms.ComboBox();
            this.rbIncrementOther = new System.Windows.Forms.RadioButton();
            this.cbIncrementEventProperty = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbIncrementEvent = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbIncrementDatabaseProperty = new System.Windows.Forms.ComboBox();
            this.cbIncrementDatabaseItem = new System.Windows.Forms.ComboBox();
            this.cbIncrementDatabase = new System.Windows.Forms.ComboBox();
            this.cbIncrementLocalVariable = new System.Windows.Forms.ComboBox();
            this.cbIncrementVariable = new System.Windows.Forms.ComboBox();
            this.rbIncrementLocalVariable = new System.Windows.Forms.RadioButton();
            this.rbIncrementVariable = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.nudIncrementRandom2 = new EGMGame.CustomUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.nudIncrementRandom1 = new EGMGame.CustomUpDown();
            this.nudIncrementConstant = new EGMGame.CustomUpDown();
            this.rbIncrementData = new System.Windows.Forms.RadioButton();
            this.rbIncrementRandomNumber = new System.Windows.Forms.RadioButton();
            this.rbIncrementConstant = new System.Windows.Forms.RadioButton();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditionRandom2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditionRandom1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditionConstant)).BeginInit();
            this.impactGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrementRandom2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrementRandom1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrementConstant)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(351, 466);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 17;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(269, 466);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 16;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbConditionEvent);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbConditionOther);
            this.impactGroupBox1.Controls.Add(this.rbConditionOther);
            this.impactGroupBox1.Controls.Add(this.cbConditionEventProperty);
            this.impactGroupBox1.Controls.Add(this.label7);
            this.impactGroupBox1.Controls.Add(this.rbConditionEvent);
            this.impactGroupBox1.Controls.Add(this.label6);
            this.impactGroupBox1.Controls.Add(this.label5);
            this.impactGroupBox1.Controls.Add(this.label4);
            this.impactGroupBox1.Controls.Add(this.cbConditionDatabaseProperty);
            this.impactGroupBox1.Controls.Add(this.cbConditionDatabaseItem);
            this.impactGroupBox1.Controls.Add(this.cbConditionDatabase);
            this.impactGroupBox1.Controls.Add(this.cbConditionLocalVariable);
            this.impactGroupBox1.Controls.Add(this.cbConditionVariables);
            this.impactGroupBox1.Controls.Add(this.rbConditionLocalVariable);
            this.impactGroupBox1.Controls.Add(this.rbConditionVariable);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.nudConditionRandom2);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.nudConditionRandom1);
            this.impactGroupBox1.Controls.Add(this.nudConditionConstant);
            this.impactGroupBox1.Controls.Add(this.rbConditionData);
            this.impactGroupBox1.Controls.Add(this.rbConditionRandomNumber);
            this.impactGroupBox1.Controls.Add(this.rbConditionConstant);
            this.impactGroupBox1.Controls.Add(this.cbConditionOperations);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(204, 476);
            this.impactGroupBox1.TabIndex = 18;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Loop Condition";
            // 
            // cbConditionEvent
            // 
            this.cbConditionEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbConditionEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionEvent.Enabled = false;
            this.cbConditionEvent.FormattingEnabled = true;
            this.cbConditionEvent.Location = new System.Drawing.Point(8, 279);
            this.cbConditionEvent.Name = "cbConditionEvent";
            this.cbConditionEvent.SelectedNode = null;
            this.cbConditionEvent.Size = new System.Drawing.Size(83, 21);
            this.cbConditionEvent.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(179, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "\'s";
            // 
            // cbConditionOther
            // 
            this.cbConditionOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionOther.Enabled = false;
            this.cbConditionOther.FormattingEnabled = true;
            this.cbConditionOther.Items.AddRange(new object[] {
            "Current Map ID"});
            this.cbConditionOther.Location = new System.Drawing.Point(8, 442);
            this.cbConditionOther.Name = "cbConditionOther";
            this.cbConditionOther.Size = new System.Drawing.Size(185, 21);
            this.cbConditionOther.TabIndex = 55;
            // 
            // rbConditionOther
            // 
            this.rbConditionOther.AutoSize = true;
            this.rbConditionOther.BackColor = System.Drawing.Color.Transparent;
            this.rbConditionOther.Location = new System.Drawing.Point(8, 419);
            this.rbConditionOther.Name = "rbConditionOther";
            this.rbConditionOther.Size = new System.Drawing.Size(51, 17);
            this.rbConditionOther.TabIndex = 54;
            this.rbConditionOther.Text = "Other";
            this.rbConditionOther.UseVisualStyleBackColor = false;
            this.rbConditionOther.CheckedChanged += new System.EventHandler(this.rbConditionOther_CheckedChanged);
            // 
            // cbConditionEventProperty
            // 
            this.cbConditionEventProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionEventProperty.Enabled = false;
            this.cbConditionEventProperty.FormattingEnabled = true;
            this.cbConditionEventProperty.Items.AddRange(new object[] {
            "Position X (Tiles)",
            "Position Y (Tiles)",
            "Position X (Pixels)",
            "Position Y (Pixels)",
            "Map ID"});
            this.cbConditionEventProperty.Location = new System.Drawing.Point(107, 279);
            this.cbConditionEventProperty.Name = "cbConditionEventProperty";
            this.cbConditionEventProperty.Size = new System.Drawing.Size(87, 21);
            this.cbConditionEventProperty.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(93, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "\'s";
            // 
            // rbConditionEvent
            // 
            this.rbConditionEvent.AutoSize = true;
            this.rbConditionEvent.BackColor = System.Drawing.Color.Transparent;
            this.rbConditionEvent.Location = new System.Drawing.Point(8, 252);
            this.rbConditionEvent.Name = "rbConditionEvent";
            this.rbConditionEvent.Size = new System.Drawing.Size(53, 17);
            this.rbConditionEvent.TabIndex = 51;
            this.rbConditionEvent.Text = "Event";
            this.rbConditionEvent.UseVisualStyleBackColor = false;
            this.rbConditionEvent.CheckedChanged += new System.EventHandler(this.rbConditionEvent_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(5, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(5, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Property";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(5, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Database";
            // 
            // cbConditionDatabaseProperty
            // 
            this.cbConditionDatabaseProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionDatabaseProperty.Enabled = false;
            this.cbConditionDatabaseProperty.FormattingEnabled = true;
            this.cbConditionDatabaseProperty.Location = new System.Drawing.Point(68, 385);
            this.cbConditionDatabaseProperty.Name = "cbConditionDatabaseProperty";
            this.cbConditionDatabaseProperty.Size = new System.Drawing.Size(125, 21);
            this.cbConditionDatabaseProperty.TabIndex = 47;
            // 
            // cbConditionDatabaseItem
            // 
            this.cbConditionDatabaseItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionDatabaseItem.Enabled = false;
            this.cbConditionDatabaseItem.FormattingEnabled = true;
            this.cbConditionDatabaseItem.Location = new System.Drawing.Point(68, 358);
            this.cbConditionDatabaseItem.Name = "cbConditionDatabaseItem";
            this.cbConditionDatabaseItem.Size = new System.Drawing.Size(110, 21);
            this.cbConditionDatabaseItem.TabIndex = 46;
            this.cbConditionDatabaseItem.SelectedIndexChanged += new System.EventHandler(this.cbConditionDatabaseItem_SelectedIndexChanged);
            // 
            // cbConditionDatabase
            // 
            this.cbConditionDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionDatabase.Enabled = false;
            this.cbConditionDatabase.FormattingEnabled = true;
            this.cbConditionDatabase.Location = new System.Drawing.Point(68, 331);
            this.cbConditionDatabase.Name = "cbConditionDatabase";
            this.cbConditionDatabase.Size = new System.Drawing.Size(125, 21);
            this.cbConditionDatabase.TabIndex = 45;
            this.cbConditionDatabase.SelectedIndexChanged += new System.EventHandler(this.cbConditionDatabase_SelectedIndexChanged);
            // 
            // cbConditionLocalVariable
            // 
            this.cbConditionLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionLocalVariable.Enabled = false;
            this.cbConditionLocalVariable.FormattingEnabled = true;
            this.cbConditionLocalVariable.Location = new System.Drawing.Point(8, 128);
            this.cbConditionLocalVariable.Name = "cbConditionLocalVariable";
            this.cbConditionLocalVariable.Size = new System.Drawing.Size(124, 21);
            this.cbConditionLocalVariable.TabIndex = 44;
            // 
            // cbConditionVariables
            // 
            this.cbConditionVariables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionVariables.Enabled = false;
            this.cbConditionVariables.FormattingEnabled = true;
            this.cbConditionVariables.Location = new System.Drawing.Point(8, 78);
            this.cbConditionVariables.Name = "cbConditionVariables";
            this.cbConditionVariables.Size = new System.Drawing.Size(124, 21);
            this.cbConditionVariables.TabIndex = 43;
            // 
            // rbConditionLocalVariable
            // 
            this.rbConditionLocalVariable.AutoSize = true;
            this.rbConditionLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.rbConditionLocalVariable.Location = new System.Drawing.Point(8, 105);
            this.rbConditionLocalVariable.Name = "rbConditionLocalVariable";
            this.rbConditionLocalVariable.Size = new System.Drawing.Size(92, 17);
            this.rbConditionLocalVariable.TabIndex = 42;
            this.rbConditionLocalVariable.Text = "Local Variable";
            this.rbConditionLocalVariable.UseVisualStyleBackColor = false;
            this.rbConditionLocalVariable.CheckedChanged += new System.EventHandler(this.rbConditionLocalVariable_CheckedChanged);
            // 
            // rbConditionVariable
            // 
            this.rbConditionVariable.AutoSize = true;
            this.rbConditionVariable.BackColor = System.Drawing.Color.Transparent;
            this.rbConditionVariable.Checked = true;
            this.rbConditionVariable.Location = new System.Drawing.Point(8, 55);
            this.rbConditionVariable.Name = "rbConditionVariable";
            this.rbConditionVariable.Size = new System.Drawing.Size(63, 17);
            this.rbConditionVariable.TabIndex = 41;
            this.rbConditionVariable.TabStop = true;
            this.rbConditionVariable.Text = "Variable";
            this.rbConditionVariable.UseVisualStyleBackColor = false;
            this.rbConditionVariable.CheckedChanged += new System.EventHandler(this.rbConditionVariable_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(122, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "-";
            // 
            // nudConditionRandom2
            // 
            this.nudConditionRandom2.Enabled = false;
            this.nudConditionRandom2.Location = new System.Drawing.Point(139, 226);
            this.nudConditionRandom2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConditionRandom2.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudConditionRandom2.Name = "nudConditionRandom2";
            this.nudConditionRandom2.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudConditionRandom2.OnChange = false;
            this.nudConditionRandom2.Size = new System.Drawing.Size(54, 20);
            this.nudConditionRandom2.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Between";
            // 
            // nudConditionRandom1
            // 
            this.nudConditionRandom1.Enabled = false;
            this.nudConditionRandom1.Location = new System.Drawing.Point(62, 226);
            this.nudConditionRandom1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConditionRandom1.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudConditionRandom1.Name = "nudConditionRandom1";
            this.nudConditionRandom1.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudConditionRandom1.OnChange = false;
            this.nudConditionRandom1.Size = new System.Drawing.Size(54, 20);
            this.nudConditionRandom1.TabIndex = 37;
            // 
            // nudConditionConstant
            // 
            this.nudConditionConstant.Location = new System.Drawing.Point(7, 178);
            this.nudConditionConstant.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConditionConstant.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudConditionConstant.Name = "nudConditionConstant";
            this.nudConditionConstant.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudConditionConstant.OnChange = false;
            this.nudConditionConstant.Size = new System.Drawing.Size(113, 20);
            this.nudConditionConstant.TabIndex = 36;
            // 
            // rbConditionData
            // 
            this.rbConditionData.AutoSize = true;
            this.rbConditionData.BackColor = System.Drawing.Color.Transparent;
            this.rbConditionData.Location = new System.Drawing.Point(7, 306);
            this.rbConditionData.Name = "rbConditionData";
            this.rbConditionData.Size = new System.Drawing.Size(48, 17);
            this.rbConditionData.TabIndex = 35;
            this.rbConditionData.Text = "Data";
            this.rbConditionData.UseVisualStyleBackColor = false;
            this.rbConditionData.CheckedChanged += new System.EventHandler(this.rbConditionData_CheckedChanged);
            // 
            // rbConditionRandomNumber
            // 
            this.rbConditionRandomNumber.AutoSize = true;
            this.rbConditionRandomNumber.BackColor = System.Drawing.Color.Transparent;
            this.rbConditionRandomNumber.Location = new System.Drawing.Point(7, 204);
            this.rbConditionRandomNumber.Name = "rbConditionRandomNumber";
            this.rbConditionRandomNumber.Size = new System.Drawing.Size(105, 17);
            this.rbConditionRandomNumber.TabIndex = 34;
            this.rbConditionRandomNumber.Text = "Random Number";
            this.rbConditionRandomNumber.UseVisualStyleBackColor = false;
            this.rbConditionRandomNumber.CheckedChanged += new System.EventHandler(this.rbConditionRandomNumber_CheckedChanged);
            // 
            // rbConditionConstant
            // 
            this.rbConditionConstant.AutoSize = true;
            this.rbConditionConstant.BackColor = System.Drawing.Color.Transparent;
            this.rbConditionConstant.Location = new System.Drawing.Point(7, 155);
            this.rbConditionConstant.Name = "rbConditionConstant";
            this.rbConditionConstant.Size = new System.Drawing.Size(67, 17);
            this.rbConditionConstant.TabIndex = 33;
            this.rbConditionConstant.Text = "Constant";
            this.rbConditionConstant.UseVisualStyleBackColor = false;
            this.rbConditionConstant.CheckedChanged += new System.EventHandler(this.rbConditionConstant_CheckedChanged);
            // 
            // cbConditionOperations
            // 
            this.cbConditionOperations.DisplayMember = "Set (=)";
            this.cbConditionOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionOperations.FormattingEnabled = true;
            this.cbConditionOperations.Items.AddRange(new object[] {
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals"});
            this.cbConditionOperations.Location = new System.Drawing.Point(7, 28);
            this.cbConditionOperations.Name = "cbConditionOperations";
            this.cbConditionOperations.Size = new System.Drawing.Size(125, 21);
            this.cbConditionOperations.TabIndex = 32;
            this.cbConditionOperations.ValueMember = "Set (=)";
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.cbIncrementEvent);
            this.impactGroupBox3.Controls.Add(this.label8);
            this.impactGroupBox3.Controls.Add(this.cbIncrementOther);
            this.impactGroupBox3.Controls.Add(this.rbIncrementOther);
            this.impactGroupBox3.Controls.Add(this.cbIncrementEventProperty);
            this.impactGroupBox3.Controls.Add(this.label9);
            this.impactGroupBox3.Controls.Add(this.rbIncrementEvent);
            this.impactGroupBox3.Controls.Add(this.label10);
            this.impactGroupBox3.Controls.Add(this.label11);
            this.impactGroupBox3.Controls.Add(this.label12);
            this.impactGroupBox3.Controls.Add(this.cbIncrementDatabaseProperty);
            this.impactGroupBox3.Controls.Add(this.cbIncrementDatabaseItem);
            this.impactGroupBox3.Controls.Add(this.cbIncrementDatabase);
            this.impactGroupBox3.Controls.Add(this.cbIncrementLocalVariable);
            this.impactGroupBox3.Controls.Add(this.cbIncrementVariable);
            this.impactGroupBox3.Controls.Add(this.rbIncrementLocalVariable);
            this.impactGroupBox3.Controls.Add(this.rbIncrementVariable);
            this.impactGroupBox3.Controls.Add(this.label13);
            this.impactGroupBox3.Controls.Add(this.nudIncrementRandom2);
            this.impactGroupBox3.Controls.Add(this.label14);
            this.impactGroupBox3.Controls.Add(this.nudIncrementRandom1);
            this.impactGroupBox3.Controls.Add(this.nudIncrementConstant);
            this.impactGroupBox3.Controls.Add(this.rbIncrementData);
            this.impactGroupBox3.Controls.Add(this.rbIncrementRandomNumber);
            this.impactGroupBox3.Controls.Add(this.rbIncrementConstant);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(222, 12);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(204, 448);
            this.impactGroupBox3.TabIndex = 58;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Loop Increment";
            // 
            // cbIncrementEvent
            // 
            this.cbIncrementEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIncrementEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementEvent.Enabled = false;
            this.cbIncrementEvent.FormattingEnabled = true;
            this.cbIncrementEvent.Location = new System.Drawing.Point(7, 252);
            this.cbIncrementEvent.Name = "cbIncrementEvent";
            this.cbIncrementEvent.SelectedNode = null;
            this.cbIncrementEvent.Size = new System.Drawing.Size(83, 21);
            this.cbIncrementEvent.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(178, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "\'s";
            // 
            // cbIncrementOther
            // 
            this.cbIncrementOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementOther.Enabled = false;
            this.cbIncrementOther.FormattingEnabled = true;
            this.cbIncrementOther.Items.AddRange(new object[] {
            "Current Map ID"});
            this.cbIncrementOther.Location = new System.Drawing.Point(7, 415);
            this.cbIncrementOther.Name = "cbIncrementOther";
            this.cbIncrementOther.Size = new System.Drawing.Size(185, 21);
            this.cbIncrementOther.TabIndex = 55;
            // 
            // rbIncrementOther
            // 
            this.rbIncrementOther.AutoSize = true;
            this.rbIncrementOther.BackColor = System.Drawing.Color.Transparent;
            this.rbIncrementOther.Location = new System.Drawing.Point(7, 392);
            this.rbIncrementOther.Name = "rbIncrementOther";
            this.rbIncrementOther.Size = new System.Drawing.Size(51, 17);
            this.rbIncrementOther.TabIndex = 54;
            this.rbIncrementOther.Text = "Other";
            this.rbIncrementOther.UseVisualStyleBackColor = false;
            this.rbIncrementOther.CheckedChanged += new System.EventHandler(this.rbIncrementOther_CheckedChanged);
            // 
            // cbIncrementEventProperty
            // 
            this.cbIncrementEventProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementEventProperty.Enabled = false;
            this.cbIncrementEventProperty.FormattingEnabled = true;
            this.cbIncrementEventProperty.Items.AddRange(new object[] {
            "Position X (Tiles)",
            "Position Y (Tiles)",
            "Position X (Pixels)",
            "Position Y (Pixels)",
            "Map ID"});
            this.cbIncrementEventProperty.Location = new System.Drawing.Point(106, 252);
            this.cbIncrementEventProperty.Name = "cbIncrementEventProperty";
            this.cbIncrementEventProperty.Size = new System.Drawing.Size(87, 21);
            this.cbIncrementEventProperty.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(92, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "\'s";
            // 
            // rbIncrementEvent
            // 
            this.rbIncrementEvent.AutoSize = true;
            this.rbIncrementEvent.BackColor = System.Drawing.Color.Transparent;
            this.rbIncrementEvent.Location = new System.Drawing.Point(7, 225);
            this.rbIncrementEvent.Name = "rbIncrementEvent";
            this.rbIncrementEvent.Size = new System.Drawing.Size(53, 17);
            this.rbIncrementEvent.TabIndex = 51;
            this.rbIncrementEvent.Text = "Event";
            this.rbIncrementEvent.UseVisualStyleBackColor = false;
            this.rbIncrementEvent.CheckedChanged += new System.EventHandler(this.rbIncrementEvent_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(4, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Data";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(4, 361);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Property";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(4, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Database";
            // 
            // cbIncrementDatabaseProperty
            // 
            this.cbIncrementDatabaseProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementDatabaseProperty.Enabled = false;
            this.cbIncrementDatabaseProperty.FormattingEnabled = true;
            this.cbIncrementDatabaseProperty.Location = new System.Drawing.Point(67, 358);
            this.cbIncrementDatabaseProperty.Name = "cbIncrementDatabaseProperty";
            this.cbIncrementDatabaseProperty.Size = new System.Drawing.Size(125, 21);
            this.cbIncrementDatabaseProperty.TabIndex = 47;
            // 
            // cbIncrementDatabaseItem
            // 
            this.cbIncrementDatabaseItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementDatabaseItem.Enabled = false;
            this.cbIncrementDatabaseItem.FormattingEnabled = true;
            this.cbIncrementDatabaseItem.Location = new System.Drawing.Point(67, 331);
            this.cbIncrementDatabaseItem.Name = "cbIncrementDatabaseItem";
            this.cbIncrementDatabaseItem.Size = new System.Drawing.Size(110, 21);
            this.cbIncrementDatabaseItem.TabIndex = 46;
            this.cbIncrementDatabaseItem.SelectedIndexChanged += new System.EventHandler(this.cbIncrementDatabaseItem_SelectedIndexChanged);
            // 
            // cbIncrementDatabase
            // 
            this.cbIncrementDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementDatabase.Enabled = false;
            this.cbIncrementDatabase.FormattingEnabled = true;
            this.cbIncrementDatabase.Location = new System.Drawing.Point(67, 304);
            this.cbIncrementDatabase.Name = "cbIncrementDatabase";
            this.cbIncrementDatabase.Size = new System.Drawing.Size(125, 21);
            this.cbIncrementDatabase.TabIndex = 45;
            this.cbIncrementDatabase.SelectedIndexChanged += new System.EventHandler(this.cbIncrementDatabase_SelectedIndexChanged);
            // 
            // cbIncrementLocalVariable
            // 
            this.cbIncrementLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementLocalVariable.Enabled = false;
            this.cbIncrementLocalVariable.FormattingEnabled = true;
            this.cbIncrementLocalVariable.Location = new System.Drawing.Point(7, 101);
            this.cbIncrementLocalVariable.Name = "cbIncrementLocalVariable";
            this.cbIncrementLocalVariable.Size = new System.Drawing.Size(124, 21);
            this.cbIncrementLocalVariable.TabIndex = 44;
            // 
            // cbIncrementVariable
            // 
            this.cbIncrementVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncrementVariable.Enabled = false;
            this.cbIncrementVariable.FormattingEnabled = true;
            this.cbIncrementVariable.Location = new System.Drawing.Point(7, 51);
            this.cbIncrementVariable.Name = "cbIncrementVariable";
            this.cbIncrementVariable.Size = new System.Drawing.Size(124, 21);
            this.cbIncrementVariable.TabIndex = 43;
            // 
            // rbIncrementLocalVariable
            // 
            this.rbIncrementLocalVariable.AutoSize = true;
            this.rbIncrementLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.rbIncrementLocalVariable.Location = new System.Drawing.Point(7, 78);
            this.rbIncrementLocalVariable.Name = "rbIncrementLocalVariable";
            this.rbIncrementLocalVariable.Size = new System.Drawing.Size(92, 17);
            this.rbIncrementLocalVariable.TabIndex = 42;
            this.rbIncrementLocalVariable.Text = "Local Variable";
            this.rbIncrementLocalVariable.UseVisualStyleBackColor = false;
            this.rbIncrementLocalVariable.CheckedChanged += new System.EventHandler(this.rbIncrementLocalVariable_CheckedChanged);
            // 
            // rbIncrementVariable
            // 
            this.rbIncrementVariable.AutoSize = true;
            this.rbIncrementVariable.BackColor = System.Drawing.Color.Transparent;
            this.rbIncrementVariable.Checked = true;
            this.rbIncrementVariable.Location = new System.Drawing.Point(7, 28);
            this.rbIncrementVariable.Name = "rbIncrementVariable";
            this.rbIncrementVariable.Size = new System.Drawing.Size(63, 17);
            this.rbIncrementVariable.TabIndex = 41;
            this.rbIncrementVariable.TabStop = true;
            this.rbIncrementVariable.Text = "Variable";
            this.rbIncrementVariable.UseVisualStyleBackColor = false;
            this.rbIncrementVariable.CheckedChanged += new System.EventHandler(this.rbIncrementVariable_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(121, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "-";
            // 
            // nudIncrementRandom2
            // 
            this.nudIncrementRandom2.Enabled = false;
            this.nudIncrementRandom2.Location = new System.Drawing.Point(138, 199);
            this.nudIncrementRandom2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudIncrementRandom2.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudIncrementRandom2.Name = "nudIncrementRandom2";
            this.nudIncrementRandom2.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudIncrementRandom2.OnChange = false;
            this.nudIncrementRandom2.Size = new System.Drawing.Size(54, 20);
            this.nudIncrementRandom2.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(3, 201);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Between";
            // 
            // nudIncrementRandom1
            // 
            this.nudIncrementRandom1.Enabled = false;
            this.nudIncrementRandom1.Location = new System.Drawing.Point(61, 199);
            this.nudIncrementRandom1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudIncrementRandom1.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudIncrementRandom1.Name = "nudIncrementRandom1";
            this.nudIncrementRandom1.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudIncrementRandom1.OnChange = false;
            this.nudIncrementRandom1.Size = new System.Drawing.Size(54, 20);
            this.nudIncrementRandom1.TabIndex = 37;
            // 
            // nudIncrementConstant
            // 
            this.nudIncrementConstant.Location = new System.Drawing.Point(6, 151);
            this.nudIncrementConstant.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudIncrementConstant.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudIncrementConstant.Name = "nudIncrementConstant";
            this.nudIncrementConstant.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudIncrementConstant.OnChange = false;
            this.nudIncrementConstant.Size = new System.Drawing.Size(113, 20);
            this.nudIncrementConstant.TabIndex = 36;
            // 
            // rbIncrementData
            // 
            this.rbIncrementData.AutoSize = true;
            this.rbIncrementData.BackColor = System.Drawing.Color.Transparent;
            this.rbIncrementData.Location = new System.Drawing.Point(6, 279);
            this.rbIncrementData.Name = "rbIncrementData";
            this.rbIncrementData.Size = new System.Drawing.Size(48, 17);
            this.rbIncrementData.TabIndex = 35;
            this.rbIncrementData.Text = "Data";
            this.rbIncrementData.UseVisualStyleBackColor = false;
            this.rbIncrementData.CheckedChanged += new System.EventHandler(this.rbIncrementData_CheckedChanged);
            // 
            // rbIncrementRandomNumber
            // 
            this.rbIncrementRandomNumber.AutoSize = true;
            this.rbIncrementRandomNumber.BackColor = System.Drawing.Color.Transparent;
            this.rbIncrementRandomNumber.Location = new System.Drawing.Point(6, 177);
            this.rbIncrementRandomNumber.Name = "rbIncrementRandomNumber";
            this.rbIncrementRandomNumber.Size = new System.Drawing.Size(105, 17);
            this.rbIncrementRandomNumber.TabIndex = 34;
            this.rbIncrementRandomNumber.Text = "Random Number";
            this.rbIncrementRandomNumber.UseVisualStyleBackColor = false;
            this.rbIncrementRandomNumber.CheckedChanged += new System.EventHandler(this.rbIncrementRandomNumber_CheckedChanged);
            // 
            // rbIncrementConstant
            // 
            this.rbIncrementConstant.AutoSize = true;
            this.rbIncrementConstant.BackColor = System.Drawing.Color.Transparent;
            this.rbIncrementConstant.Location = new System.Drawing.Point(6, 128);
            this.rbIncrementConstant.Name = "rbIncrementConstant";
            this.rbIncrementConstant.Size = new System.Drawing.Size(67, 17);
            this.rbIncrementConstant.TabIndex = 33;
            this.rbIncrementConstant.Text = "Constant";
            this.rbIncrementConstant.UseVisualStyleBackColor = false;
            this.rbIncrementConstant.CheckedChanged += new System.EventHandler(this.rbIncrementConstant_CheckedChanged);
            // 
            // VariableLoopDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(435, 497);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariableLoopDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variable Loop";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditionRandom2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditionRandom1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditionConstant)).EndInit();
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrementRandom2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrementRandom1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncrementConstant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.TreeViewComboBox cbConditionEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConditionOther;
        private System.Windows.Forms.RadioButton rbConditionOther;
        private System.Windows.Forms.ComboBox cbConditionEventProperty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbConditionEvent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbConditionDatabaseProperty;
        private System.Windows.Forms.ComboBox cbConditionDatabaseItem;
        private System.Windows.Forms.ComboBox cbConditionDatabase;
        private System.Windows.Forms.ComboBox cbConditionLocalVariable;
        private System.Windows.Forms.ComboBox cbConditionVariables;
        private System.Windows.Forms.RadioButton rbConditionLocalVariable;
        private System.Windows.Forms.RadioButton rbConditionVariable;
        private System.Windows.Forms.Label label3;
        private CustomUpDown nudConditionRandom2;
        private System.Windows.Forms.Label label2;
        private CustomUpDown nudConditionRandom1;
        private CustomUpDown nudConditionConstant;
        private System.Windows.Forms.RadioButton rbConditionData;
        private System.Windows.Forms.RadioButton rbConditionRandomNumber;
        private System.Windows.Forms.RadioButton rbConditionConstant;
        private System.Windows.Forms.ComboBox cbConditionOperations;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private EGMGame.Controls.TreeViewComboBox cbIncrementEvent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbIncrementOther;
        private System.Windows.Forms.RadioButton rbIncrementOther;
        private System.Windows.Forms.ComboBox cbIncrementEventProperty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbIncrementEvent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbIncrementDatabaseProperty;
        private System.Windows.Forms.ComboBox cbIncrementDatabaseItem;
        private System.Windows.Forms.ComboBox cbIncrementDatabase;
        private System.Windows.Forms.ComboBox cbIncrementLocalVariable;
        private System.Windows.Forms.ComboBox cbIncrementVariable;
        private System.Windows.Forms.RadioButton rbIncrementLocalVariable;
        private System.Windows.Forms.RadioButton rbIncrementVariable;
        private System.Windows.Forms.Label label13;
        private CustomUpDown nudIncrementRandom2;
        private System.Windows.Forms.Label label14;
        private CustomUpDown nudIncrementRandom1;
        private CustomUpDown nudIncrementConstant;
        private System.Windows.Forms.RadioButton rbIncrementData;
        private System.Windows.Forms.RadioButton rbIncrementRandomNumber;
        private System.Windows.Forms.RadioButton rbIncrementConstant;
    }
}