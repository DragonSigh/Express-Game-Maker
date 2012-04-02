namespace EGMGame.Controls.EventControls.Enemy
{
    partial class EnemyAIDialog
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
            this.impactGroupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.panelEventSwitch = new System.Windows.Forms.Panel();
            this.cbEventSwitches = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEventSwitchValue = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDontErase = new System.Windows.Forms.CheckBox();
            this.cbDeathTrigger = new System.Windows.Forms.ComboBox();
            this.panelSwitch = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSwitchState = new System.Windows.Forms.ComboBox();
            this.cbSwitches = new EGMGame.Controls.Game.SwitchesComboBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.panelLocalSwitch = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLocalState = new System.Windows.Forms.ComboBox();
            this.cbLocalSwitch = new EGMGame.Controls.Game.SwitchesComboBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.cbLocalVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.nudLocalVal = new EGMGame.CustomUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cbLocalOper = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.nudVarValue = new EGMGame.CustomUpDown();
            this.cbVarOperation = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listHostiles = new System.Windows.Forms.CheckedListBox();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkRushTarget = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.nudAttackSpeed = new EGMGame.CustomUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudRespawn = new EGMGame.CustomUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.rbLock = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHear = new EGMGame.CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSee = new EGMGame.CustomUpDown();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAttackCond = new System.Windows.Forms.ComboBox();
            this.impactGroupBox5.SuspendLayout();
            this.panelEventSwitch.SuspendLayout();
            this.panelSwitch.SuspendLayout();
            this.panelLocalSwitch.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalVal)).BeginInit();
            this.panelVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVarValue)).BeginInit();
            this.impactGroupBox4.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttackSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRespawn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSee)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(268, 486);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(187, 486);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 21;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox5
            // 
            this.impactGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox5.Controls.Add(this.panelEventSwitch);
            this.impactGroupBox5.Controls.Add(this.chkDontErase);
            this.impactGroupBox5.Controls.Add(this.cbDeathTrigger);
            this.impactGroupBox5.Controls.Add(this.panelSwitch);
            this.impactGroupBox5.Controls.Add(this.panelLocalSwitch);
            this.impactGroupBox5.Controls.Add(this.panelLocalVariable);
            this.impactGroupBox5.Controls.Add(this.panelVariable);
            this.impactGroupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox5.Location = new System.Drawing.Point(12, 292);
            this.impactGroupBox5.Name = "impactGroupBox5";
            this.impactGroupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox5.Size = new System.Drawing.Size(169, 181);
            this.impactGroupBox5.TabIndex = 24;
            this.impactGroupBox5.TabStop = false;
            this.impactGroupBox5.Text = "Death Trigger";
            // 
            // panelEventSwitch
            // 
            this.panelEventSwitch.BackColor = System.Drawing.Color.Transparent;
            this.panelEventSwitch.Controls.Add(this.cbEventSwitches);
            this.panelEventSwitch.Controls.Add(this.label4);
            this.panelEventSwitch.Controls.Add(this.cbEventSwitchValue);
            this.panelEventSwitch.Controls.Add(this.label5);
            this.panelEventSwitch.Location = new System.Drawing.Point(0, 55);
            this.panelEventSwitch.Name = "panelEventSwitch";
            this.panelEventSwitch.Size = new System.Drawing.Size(169, 95);
            this.panelEventSwitch.TabIndex = 26;
            this.panelEventSwitch.Visible = false;
            // 
            // cbEventSwitches
            // 
            this.cbEventSwitches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEventSwitches.FormattingEnabled = true;
            this.cbEventSwitches.Items.AddRange(new object[] {
            "Switch 1",
            "Switch 2",
            "Switch 3",
            "Switch 4",
            "Switch 5"});
            this.cbEventSwitches.Location = new System.Drawing.Point(10, 19);
            this.cbEventSwitches.Name = "cbEventSwitches";
            this.cbEventSwitches.Size = new System.Drawing.Size(127, 21);
            this.cbEventSwitches.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Set switch state.";
            // 
            // cbEventSwitchValue
            // 
            this.cbEventSwitchValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEventSwitchValue.FormattingEnabled = true;
            this.cbEventSwitchValue.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.cbEventSwitchValue.Location = new System.Drawing.Point(10, 63);
            this.cbEventSwitchValue.Name = "cbEventSwitchValue";
            this.cbEventSwitchValue.Size = new System.Drawing.Size(60, 21);
            this.cbEventSwitchValue.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Choose Event Switch.";
            // 
            // chkDontErase
            // 
            this.chkDontErase.AutoSize = true;
            this.chkDontErase.BackColor = System.Drawing.Color.Transparent;
            this.chkDontErase.Location = new System.Drawing.Point(10, 156);
            this.chkDontErase.Name = "chkDontErase";
            this.chkDontErase.Size = new System.Drawing.Size(117, 17);
            this.chkDontErase.TabIndex = 29;
            this.chkDontErase.Text = "Do not erase event";
            this.chkDontErase.UseVisualStyleBackColor = false;
            this.chkDontErase.Visible = false;
            // 
            // cbDeathTrigger
            // 
            this.cbDeathTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeathTrigger.FormattingEnabled = true;
            this.cbDeathTrigger.Items.AddRange(new object[] {
            "None",
            "Erase Event",
            "Trigger Current Page",
            "Switch",
            "Local Switch",
            "Variable",
            "Local Variable",
            "Event Switch"});
            this.cbDeathTrigger.Location = new System.Drawing.Point(10, 28);
            this.cbDeathTrigger.Name = "cbDeathTrigger";
            this.cbDeathTrigger.Size = new System.Drawing.Size(133, 21);
            this.cbDeathTrigger.TabIndex = 14;
            this.cbDeathTrigger.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // panelSwitch
            // 
            this.panelSwitch.BackColor = System.Drawing.Color.Transparent;
            this.panelSwitch.Controls.Add(this.label9);
            this.panelSwitch.Controls.Add(this.cbSwitchState);
            this.panelSwitch.Controls.Add(this.cbSwitches);
            this.panelSwitch.Controls.Add(this.label8);
            this.panelSwitch.Location = new System.Drawing.Point(0, 55);
            this.panelSwitch.Name = "panelSwitch";
            this.panelSwitch.Size = new System.Drawing.Size(169, 95);
            this.panelSwitch.TabIndex = 25;
            this.panelSwitch.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(7, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Set switch state.";
            // 
            // cbSwitchState
            // 
            this.cbSwitchState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitchState.FormattingEnabled = true;
            this.cbSwitchState.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.cbSwitchState.Location = new System.Drawing.Point(10, 63);
            this.cbSwitchState.Name = "cbSwitchState";
            this.cbSwitchState.Size = new System.Drawing.Size(60, 21);
            this.cbSwitchState.TabIndex = 14;
            // 
            // cbSwitches
            // 
            this.cbSwitches.AllowCategories = true;
            this.cbSwitches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSwitches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitches.FormattingEnabled = true;
            this.cbSwitches.Location = new System.Drawing.Point(10, 22);
            this.cbSwitches.Name = "cbSwitches";
            this.cbSwitches.SelectedNode = null;
            this.cbSwitches.Size = new System.Drawing.Size(133, 21);
            this.cbSwitches.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Choose Switch.";
            // 
            // panelLocalSwitch
            // 
            this.panelLocalSwitch.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalSwitch.Controls.Add(this.label10);
            this.panelLocalSwitch.Controls.Add(this.cbLocalState);
            this.panelLocalSwitch.Controls.Add(this.cbLocalSwitch);
            this.panelLocalSwitch.Controls.Add(this.label11);
            this.panelLocalSwitch.Location = new System.Drawing.Point(0, 55);
            this.panelLocalSwitch.Name = "panelLocalSwitch";
            this.panelLocalSwitch.Size = new System.Drawing.Size(169, 95);
            this.panelLocalSwitch.TabIndex = 26;
            this.panelLocalSwitch.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(7, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Set switch state.";
            // 
            // cbLocalState
            // 
            this.cbLocalState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalState.FormattingEnabled = true;
            this.cbLocalState.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.cbLocalState.Location = new System.Drawing.Point(10, 65);
            this.cbLocalState.Name = "cbLocalState";
            this.cbLocalState.Size = new System.Drawing.Size(60, 21);
            this.cbLocalState.TabIndex = 14;
            // 
            // cbLocalSwitch
            // 
            this.cbLocalSwitch.AllowCategories = true;
            this.cbLocalSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalSwitch.FormattingEnabled = true;
            this.cbLocalSwitch.Location = new System.Drawing.Point(10, 24);
            this.cbLocalSwitch.Name = "cbLocalSwitch";
            this.cbLocalSwitch.SelectedNode = null;
            this.cbLocalSwitch.Size = new System.Drawing.Size(133, 21);
            this.cbLocalSwitch.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(7, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Choose Local Switch.";
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.cbLocalVar);
            this.panelLocalVariable.Controls.Add(this.nudLocalVal);
            this.panelLocalVariable.Controls.Add(this.label14);
            this.panelLocalVariable.Controls.Add(this.cbLocalOper);
            this.panelLocalVariable.Controls.Add(this.label15);
            this.panelLocalVariable.Location = new System.Drawing.Point(0, 55);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(169, 95);
            this.panelLocalVariable.TabIndex = 28;
            this.panelLocalVariable.Visible = false;
            // 
            // cbLocalVar
            // 
            this.cbLocalVar.AllowCategories = true;
            this.cbLocalVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVar.FormattingEnabled = true;
            this.cbLocalVar.Location = new System.Drawing.Point(10, 18);
            this.cbLocalVar.Name = "cbLocalVar";
            this.cbLocalVar.SelectedNode = null;
            this.cbLocalVar.Size = new System.Drawing.Size(138, 21);
            this.cbLocalVar.TabIndex = 25;
            // 
            // nudLocalVal
            // 
            this.nudLocalVal.Location = new System.Drawing.Point(98, 64);
            this.nudLocalVal.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudLocalVal.Name = "nudLocalVal";
            this.nudLocalVal.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLocalVal.OnChange = true;
            this.nudLocalVal.Size = new System.Drawing.Size(54, 20);
            this.nudLocalVal.TabIndex = 23;
            this.nudLocalVal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(7, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Choose operation and value.";
            // 
            // cbLocalOper
            // 
            this.cbLocalOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalOper.FormattingEnabled = true;
            this.cbLocalOper.Items.AddRange(new object[] {
            "Set (=)",
            "Add (+)",
            "Subtract (-)",
            "Multiply (*)",
            "Divide (/)",
            "Exponentiate (^)",
            "Modulate (r)"});
            this.cbLocalOper.Location = new System.Drawing.Point(10, 63);
            this.cbLocalOper.Name = "cbLocalOper";
            this.cbLocalOper.Size = new System.Drawing.Size(82, 21);
            this.cbLocalOper.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(7, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Choose Local Variable.";
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Controls.Add(this.nudVarValue);
            this.panelVariable.Controls.Add(this.cbVarOperation);
            this.panelVariable.Controls.Add(this.label13);
            this.panelVariable.Controls.Add(this.label12);
            this.panelVariable.Location = new System.Drawing.Point(0, 55);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(169, 95);
            this.panelVariable.TabIndex = 27;
            this.panelVariable.Visible = false;
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(12, 19);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(131, 21);
            this.cbVariable.TabIndex = 24;
            // 
            // nudVarValue
            // 
            this.nudVarValue.Location = new System.Drawing.Point(100, 64);
            this.nudVarValue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudVarValue.Name = "nudVarValue";
            this.nudVarValue.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudVarValue.OnChange = true;
            this.nudVarValue.Size = new System.Drawing.Size(54, 20);
            this.nudVarValue.TabIndex = 23;
            this.nudVarValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbVarOperation
            // 
            this.cbVarOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarOperation.FormattingEnabled = true;
            this.cbVarOperation.Items.AddRange(new object[] {
            "Set (=)",
            "Add (+)",
            "Subtract (-)",
            "Multiply (*)",
            "Divide (/)",
            "Exponentiate (^)",
            "Modulate (r)"});
            this.cbVarOperation.Location = new System.Drawing.Point(12, 63);
            this.cbVarOperation.Name = "cbVarOperation";
            this.cbVarOperation.Size = new System.Drawing.Size(82, 21);
            this.cbVarOperation.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(9, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Choose Variable.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(9, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Choose operation and value.";
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.Controls.Add(this.listHostiles);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Location = new System.Drawing.Point(187, 12);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(160, 461);
            this.impactGroupBox4.TabIndex = 20;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Hostile To";
            // 
            // listHostiles
            // 
            this.listHostiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listHostiles.FormattingEnabled = true;
            this.listHostiles.IntegralHeight = false;
            this.listHostiles.Items.AddRange(new object[] {
            "Player"});
            this.listHostiles.Location = new System.Drawing.Point(4, 25);
            this.listHostiles.Name = "listHostiles";
            this.listHostiles.Size = new System.Drawing.Size(152, 431);
            this.listHostiles.TabIndex = 0;
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.chkRushTarget);
            this.impactGroupBox2.Controls.Add(this.label17);
            this.impactGroupBox2.Controls.Add(this.nudAttackSpeed);
            this.impactGroupBox2.Controls.Add(this.label16);
            this.impactGroupBox2.Controls.Add(this.label7);
            this.impactGroupBox2.Controls.Add(this.nudRespawn);
            this.impactGroupBox2.Controls.Add(this.label6);
            this.impactGroupBox2.Controls.Add(this.rbLock);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Controls.Add(this.nudHear);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Controls.Add(this.nudSee);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 95);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(169, 191);
            this.impactGroupBox2.TabIndex = 14;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Settings";
            // 
            // chkRushTarget
            // 
            this.chkRushTarget.AutoSize = true;
            this.chkRushTarget.BackColor = System.Drawing.Color.Transparent;
            this.chkRushTarget.Location = new System.Drawing.Point(10, 168);
            this.chkRushTarget.Name = "chkRushTarget";
            this.chkRushTarget.Size = new System.Drawing.Size(85, 17);
            this.chkRushTarget.TabIndex = 27;
            this.chkRushTarget.Text = "Rush Target";
            this.chkRushTarget.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(70, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "frames";
            // 
            // nudAttackSpeed
            // 
            this.nudAttackSpeed.Location = new System.Drawing.Point(10, 119);
            this.nudAttackSpeed.Name = "nudAttackSpeed";
            this.nudAttackSpeed.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAttackSpeed.OnChange = true;
            this.nudAttackSpeed.Size = new System.Drawing.Size(54, 20);
            this.nudAttackSpeed.TabIndex = 25;
            this.nudAttackSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(7, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Attack Speed";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(69, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "sec.";
            // 
            // nudRespawn
            // 
            this.nudRespawn.Location = new System.Drawing.Point(10, 80);
            this.nudRespawn.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudRespawn.Name = "nudRespawn";
            this.nudRespawn.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudRespawn.OnChange = false;
            this.nudRespawn.Size = new System.Drawing.Size(54, 20);
            this.nudRespawn.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Respawn Rate";
            // 
            // rbLock
            // 
            this.rbLock.AutoSize = true;
            this.rbLock.BackColor = System.Drawing.Color.Transparent;
            this.rbLock.Location = new System.Drawing.Point(10, 145);
            this.rbLock.Name = "rbLock";
            this.rbLock.Size = new System.Drawing.Size(95, 17);
            this.rbLock.TabIndex = 15;
            this.rbLock.Text = "Lock on target";
            this.rbLock.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(80, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Hear Range";
            // 
            // nudHear
            // 
            this.nudHear.Location = new System.Drawing.Point(83, 41);
            this.nudHear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudHear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHear.Name = "nudHear";
            this.nudHear.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHear.OnChange = true;
            this.nudHear.Size = new System.Drawing.Size(54, 20);
            this.nudHear.TabIndex = 17;
            this.nudHear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "See Range";
            // 
            // nudSee
            // 
            this.nudSee.Location = new System.Drawing.Point(10, 41);
            this.nudSee.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudSee.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSee.Name = "nudSee";
            this.nudSee.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSee.OnChange = true;
            this.nudSee.Size = new System.Drawing.Size(54, 20);
            this.nudSee.TabIndex = 15;
            this.nudSee.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.cbAttackCond);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(169, 77);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Conditions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Choose attack conditions.";
            // 
            // cbAttackCond
            // 
            this.cbAttackCond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttackCond.FormattingEnabled = true;
            this.cbAttackCond.Items.AddRange(new object[] {
            "On See or Hear",
            "On See",
            "On Hear",
            "Ally Attacked",
            "Doesn\'t Attack"});
            this.cbAttackCond.Location = new System.Drawing.Point(10, 41);
            this.cbAttackCond.Name = "cbAttackCond";
            this.cbAttackCond.Size = new System.Drawing.Size(127, 21);
            this.cbAttackCond.TabIndex = 12;
            // 
            // EnemyAIDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 517);
            this.Controls.Add(this.impactGroupBox5);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox4);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnemyAIDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Program AI";
            this.impactGroupBox5.ResumeLayout(false);
            this.impactGroupBox5.PerformLayout();
            this.panelEventSwitch.ResumeLayout(false);
            this.panelEventSwitch.PerformLayout();
            this.panelSwitch.ResumeLayout(false);
            this.panelSwitch.PerformLayout();
            this.panelLocalSwitch.ResumeLayout(false);
            this.panelLocalSwitch.PerformLayout();
            this.panelLocalVariable.ResumeLayout(false);
            this.panelLocalVariable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalVal)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVarValue)).EndInit();
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttackSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRespawn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSee)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAttackCond;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudSee;
        private System.Windows.Forms.Label label2;
        private CustomUpDown nudHear;
        private System.Windows.Forms.CheckBox rbLock;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckedListBox listHostiles;
        private CustomUpDown nudRespawn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox5;
        private System.Windows.Forms.ComboBox cbDeathTrigger;
        private System.Windows.Forms.Panel panelSwitch;
        private System.Windows.Forms.Label label8;
        private EGMGame.Controls.Game.SwitchesComboBox cbSwitches;
        private System.Windows.Forms.ComboBox cbSwitchState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelLocalSwitch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLocalState;
        private EGMGame.Controls.Game.SwitchesComboBox cbLocalSwitch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbVarOperation;
        private System.Windows.Forms.Label label13;
        private CustomUpDown nudVarValue;
        private System.Windows.Forms.Panel panelLocalVariable;
        private CustomUpDown nudLocalVal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbLocalOper;
        private System.Windows.Forms.Label label15;
        private EGMGame.Controls.Game.VariableComboBox cbVariable;
        private EGMGame.Controls.Game.VariableComboBox cbLocalVar;
        private CustomUpDown nudAttackSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkDontErase;
        private System.Windows.Forms.CheckBox chkRushTarget;
        private System.Windows.Forms.Panel panelEventSwitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEventSwitchValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEventSwitches;
    }
}