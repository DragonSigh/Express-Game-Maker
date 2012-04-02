namespace EGMGame.Docking.Editors.Database
{
    partial class EnemyProgramDialog
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
            this.panelParty = new System.Windows.Forms.Panel();
            this.cbPartyLevel = new System.Windows.Forms.ComboBox();
            this.nudPartyLevel = new EGMGame.CustomUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.panelSwitch = new System.Windows.Forms.Panel();
            this.cbSwitchState = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbSwitches = new EGMGame.Controls.Game.SwitchesComboBox(this.components);
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panelTurn = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.nudEveryTurn = new EGMGame.CustomUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudStartTurn = new EGMGame.CustomUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panelState = new System.Windows.Forms.Panel();
            this.cbStates = new EGMGame.Controls.Game.StatesComboBox(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.panelMp = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.nudMpMax = new EGMGame.CustomUpDown();
            this.nudMpMin = new EGMGame.CustomUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panelSp = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.nudSpMax = new EGMGame.CustomUpDown();
            this.nudSpMin = new EGMGame.CustomUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panelHP = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.nudHpMax = new EGMGame.CustomUpDown();
            this.nudHpMin = new EGMGame.CustomUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.panelItem = new System.Windows.Forms.Panel();
            this.cbItems = new EGMGame.Controls.Game.ItemsComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.panelBasic = new System.Windows.Forms.Panel();
            this.cbActions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMagic = new System.Windows.Forms.Panel();
            this.cbMagic = new EGMGame.Controls.Game.SkillsComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbActionType = new System.Windows.Forms.ComboBox();
            this.panelSkill = new System.Windows.Forms.Panel();
            this.cbSkills = new EGMGame.Controls.Game.SkillsComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.barPriority = new EGMGame.Controls.CustomTrackBar();
            this.nudPriority = new EGMGame.CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox3.SuspendLayout();
            this.panelParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartyLevel)).BeginInit();
            this.panelSwitch.SuspendLayout();
            this.panelTurn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEveryTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartTurn)).BeginInit();
            this.panelState.SuspendLayout();
            this.panelMp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpMin)).BeginInit();
            this.panelSp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpMin)).BeginInit();
            this.panelHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHpMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHpMin)).BeginInit();
            this.impactGroupBox2.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelBasic.SuspendLayout();
            this.panelMagic.SuspendLayout();
            this.panelSkill.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(248, 369);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(163, 369);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.cbCondition);
            this.impactGroupBox3.Controls.Add(this.label11);
            this.impactGroupBox3.Controls.Add(this.panelMp);
            this.impactGroupBox3.Controls.Add(this.panelSp);
            this.impactGroupBox3.Controls.Add(this.panelHP);
            this.impactGroupBox3.Controls.Add(this.panelParty);
            this.impactGroupBox3.Controls.Add(this.panelSwitch);
            this.impactGroupBox3.Controls.Add(this.panelTurn);
            this.impactGroupBox3.Controls.Add(this.panelState);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(12, 232);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(311, 131);
            this.impactGroupBox3.TabIndex = 7;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Conditions";
            // 
            // panelParty
            // 
            this.panelParty.BackColor = System.Drawing.Color.Transparent;
            this.panelParty.Controls.Add(this.cbPartyLevel);
            this.panelParty.Controls.Add(this.nudPartyLevel);
            this.panelParty.Controls.Add(this.label16);
            this.panelParty.Location = new System.Drawing.Point(7, 68);
            this.panelParty.Name = "panelParty";
            this.panelParty.Size = new System.Drawing.Size(294, 51);
            this.panelParty.TabIndex = 20;
            this.panelParty.Visible = false;
            // 
            // cbPartyLevel
            // 
            this.cbPartyLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartyLevel.FormattingEnabled = true;
            this.cbPartyLevel.Items.AddRange(new object[] {
            "Above",
            "Below"});
            this.cbPartyLevel.Location = new System.Drawing.Point(147, 5);
            this.cbPartyLevel.Name = "cbPartyLevel";
            this.cbPartyLevel.Size = new System.Drawing.Size(68, 21);
            this.cbPartyLevel.TabIndex = 20;
            // 
            // nudPartyLevel
            // 
            this.nudPartyLevel.Location = new System.Drawing.Point(72, 6);
            this.nudPartyLevel.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPartyLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPartyLevel.Name = "nudPartyLevel";
            this.nudPartyLevel.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPartyLevel.OnChange = true;
            this.nudPartyLevel.Size = new System.Drawing.Size(51, 20);
            this.nudPartyLevel.TabIndex = 19;
            this.nudPartyLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(0, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Party level is                      or ";
            // 
            // panelSwitch
            // 
            this.panelSwitch.BackColor = System.Drawing.Color.Transparent;
            this.panelSwitch.Controls.Add(this.cbSwitchState);
            this.panelSwitch.Controls.Add(this.label15);
            this.panelSwitch.Controls.Add(this.label14);
            this.panelSwitch.Controls.Add(this.cbSwitches);
            this.panelSwitch.Location = new System.Drawing.Point(7, 68);
            this.panelSwitch.Name = "panelSwitch";
            this.panelSwitch.Size = new System.Drawing.Size(294, 51);
            this.panelSwitch.TabIndex = 10;
            this.panelSwitch.Visible = false;
            // 
            // cbSwitchState
            // 
            this.cbSwitchState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitchState.FormattingEnabled = true;
            this.cbSwitchState.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.cbSwitchState.Location = new System.Drawing.Point(203, 4);
            this.cbSwitchState.Name = "cbSwitchState";
            this.cbSwitchState.Size = new System.Drawing.Size(59, 21);
            this.cbSwitchState.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(183, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "is";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(0, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Switch";
            // 
            // cbSwitches
            // 
            this.cbSwitches.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSwitches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitches.FormattingEnabled = true;
            this.cbSwitches.Location = new System.Drawing.Point(45, 4);
            this.cbSwitches.Name = "cbSwitches";
            this.cbSwitches.SelectedNode = null;
            this.cbSwitches.Size = new System.Drawing.Size(130, 21);
            this.cbSwitches.TabIndex = 0;
            // 
            // cbCondition
            // 
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            "Always",
            "Every Turn/Second",
            "HP",
            "SP",
            "MP",
            "State",
            "Party Level",
            "Switch"});
            this.cbCondition.Location = new System.Drawing.Point(10, 41);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(131, 21);
            this.cbCondition.TabIndex = 2;
            this.cbCondition.SelectedIndexChanged += new System.EventHandler(this.cbCondition_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(7, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Choose the condition type.";
            // 
            // panelTurn
            // 
            this.panelTurn.BackColor = System.Drawing.Color.Transparent;
            this.panelTurn.Controls.Add(this.label9);
            this.panelTurn.Controls.Add(this.label23);
            this.panelTurn.Controls.Add(this.nudEveryTurn);
            this.panelTurn.Controls.Add(this.label8);
            this.panelTurn.Controls.Add(this.nudStartTurn);
            this.panelTurn.Controls.Add(this.label7);
            this.panelTurn.Location = new System.Drawing.Point(7, 68);
            this.panelTurn.Name = "panelTurn";
            this.panelTurn.Size = new System.Drawing.Size(294, 51);
            this.panelTurn.TabIndex = 7;
            this.panelTurn.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(114, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "second(s)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(114, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 13);
            this.label23.TabIndex = 12;
            this.label23.Text = "second(s)";
            // 
            // nudEveryTurn
            // 
            this.nudEveryTurn.Location = new System.Drawing.Point(57, 31);
            this.nudEveryTurn.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudEveryTurn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEveryTurn.Name = "nudEveryTurn";
            this.nudEveryTurn.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudEveryTurn.OnChange = true;
            this.nudEveryTurn.Size = new System.Drawing.Size(51, 20);
            this.nudEveryTurn.TabIndex = 10;
            this.nudEveryTurn.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(0, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "For every";
            // 
            // nudStartTurn
            // 
            this.nudStartTurn.Location = new System.Drawing.Point(57, 7);
            this.nudStartTurn.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudStartTurn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStartTurn.Name = "nudStartTurn";
            this.nudStartTurn.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudStartTurn.OnChange = true;
            this.nudStartTurn.Size = new System.Drawing.Size(51, 20);
            this.nudStartTurn.TabIndex = 4;
            this.nudStartTurn.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(0, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Start from";
            // 
            // panelState
            // 
            this.panelState.BackColor = System.Drawing.Color.Transparent;
            this.panelState.Controls.Add(this.cbStates);
            this.panelState.Controls.Add(this.label25);
            this.panelState.Location = new System.Drawing.Point(7, 68);
            this.panelState.Name = "panelState";
            this.panelState.Size = new System.Drawing.Size(294, 51);
            this.panelState.TabIndex = 10;
            this.panelState.Visible = false;
            // 
            // cbStates
            // 
            this.cbStates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStates.FormattingEnabled = true;
            this.cbStates.Location = new System.Drawing.Point(60, 4);
            this.cbStates.Name = "cbStates";
            this.cbStates.Noneable = false;
            this.cbStates.SelectedNode = null;
            this.cbStates.Size = new System.Drawing.Size(130, 21);
            this.cbStates.TabIndex = 19;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(0, 7);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 13);
            this.label25.TabIndex = 18;
            this.label25.Text = "Has State";
            // 
            // panelMp
            // 
            this.panelMp.BackColor = System.Drawing.Color.Transparent;
            this.panelMp.Controls.Add(this.label20);
            this.panelMp.Controls.Add(this.nudMpMax);
            this.panelMp.Controls.Add(this.nudMpMin);
            this.panelMp.Controls.Add(this.label21);
            this.panelMp.Controls.Add(this.label22);
            this.panelMp.Location = new System.Drawing.Point(7, 68);
            this.panelMp.Name = "panelMp";
            this.panelMp.Size = new System.Drawing.Size(294, 51);
            this.panelMp.TabIndex = 10;
            this.panelMp.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(224, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 13);
            this.label20.TabIndex = 21;
            this.label20.Text = "%";
            // 
            // nudMpMax
            // 
            this.nudMpMax.Location = new System.Drawing.Point(167, 5);
            this.nudMpMax.Name = "nudMpMax";
            this.nudMpMax.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMpMax.OnChange = true;
            this.nudMpMax.Size = new System.Drawing.Size(51, 20);
            this.nudMpMax.TabIndex = 20;
            this.nudMpMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudMpMin
            // 
            this.nudMpMin.Location = new System.Drawing.Point(83, 5);
            this.nudMpMin.Name = "nudMpMin";
            this.nudMpMin.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMpMin.OnChange = false;
            this.nudMpMin.Size = new System.Drawing.Size(51, 20);
            this.nudMpMin.TabIndex = 17;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(140, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 19;
            this.label21.Text = "% -";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(0, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "MP is between";
            // 
            // panelSp
            // 
            this.panelSp.BackColor = System.Drawing.Color.Transparent;
            this.panelSp.Controls.Add(this.label17);
            this.panelSp.Controls.Add(this.nudSpMax);
            this.panelSp.Controls.Add(this.nudSpMin);
            this.panelSp.Controls.Add(this.label18);
            this.panelSp.Controls.Add(this.label19);
            this.panelSp.Location = new System.Drawing.Point(7, 68);
            this.panelSp.Name = "panelSp";
            this.panelSp.Size = new System.Drawing.Size(294, 51);
            this.panelSp.TabIndex = 10;
            this.panelSp.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(221, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "%";
            // 
            // nudSpMax
            // 
            this.nudSpMax.Location = new System.Drawing.Point(164, 8);
            this.nudSpMax.Name = "nudSpMax";
            this.nudSpMax.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpMax.OnChange = true;
            this.nudSpMax.Size = new System.Drawing.Size(51, 20);
            this.nudSpMax.TabIndex = 20;
            this.nudSpMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudSpMin
            // 
            this.nudSpMin.Location = new System.Drawing.Point(80, 8);
            this.nudSpMin.Name = "nudSpMin";
            this.nudSpMin.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudSpMin.OnChange = false;
            this.nudSpMin.Size = new System.Drawing.Size(51, 20);
            this.nudSpMin.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(137, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "% -";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(0, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "SP is between";
            // 
            // panelHP
            // 
            this.panelHP.BackColor = System.Drawing.Color.Transparent;
            this.panelHP.Controls.Add(this.label13);
            this.panelHP.Controls.Add(this.nudHpMax);
            this.panelHP.Controls.Add(this.nudHpMin);
            this.panelHP.Controls.Add(this.label10);
            this.panelHP.Controls.Add(this.label12);
            this.panelHP.Location = new System.Drawing.Point(7, 68);
            this.panelHP.Name = "panelHP";
            this.panelHP.Size = new System.Drawing.Size(294, 51);
            this.panelHP.TabIndex = 9;
            this.panelHP.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(221, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "%";
            // 
            // nudHpMax
            // 
            this.nudHpMax.Location = new System.Drawing.Point(164, 7);
            this.nudHpMax.Name = "nudHpMax";
            this.nudHpMax.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHpMax.OnChange = true;
            this.nudHpMax.Size = new System.Drawing.Size(51, 20);
            this.nudHpMax.TabIndex = 15;
            this.nudHpMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudHpMin
            // 
            this.nudHpMin.Location = new System.Drawing.Point(80, 7);
            this.nudHpMin.Name = "nudHpMin";
            this.nudHpMin.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudHpMin.OnChange = false;
            this.nudHpMin.Size = new System.Drawing.Size(51, 20);
            this.nudHpMin.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(137, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "% -";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(-2, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "HP is between";
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.panelItem);
            this.impactGroupBox2.Controls.Add(this.panelBasic);
            this.impactGroupBox2.Controls.Add(this.panelMagic);
            this.impactGroupBox2.Controls.Add(this.cbActionType);
            this.impactGroupBox2.Controls.Add(this.panelSkill);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(311, 131);
            this.impactGroupBox2.TabIndex = 1;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Action";
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelItem.Controls.Add(this.cbItems);
            this.panelItem.Controls.Add(this.label6);
            this.panelItem.Location = new System.Drawing.Point(7, 68);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(146, 51);
            this.panelItem.TabIndex = 6;
            this.panelItem.Visible = false;
            // 
            // cbItems
            // 
            this.cbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(3, 16);
            this.cbItems.Name = "cbItems";
            this.cbItems.Noneable = false;
            this.cbItems.SelectedNode = null;
            this.cbItems.Size = new System.Drawing.Size(131, 21);
            this.cbItems.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Choose item.";
            // 
            // panelBasic
            // 
            this.panelBasic.BackColor = System.Drawing.Color.Transparent;
            this.panelBasic.Controls.Add(this.cbActions);
            this.panelBasic.Controls.Add(this.label3);
            this.panelBasic.Location = new System.Drawing.Point(7, 68);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(146, 51);
            this.panelBasic.TabIndex = 2;
            // 
            // cbActions
            // 
            this.cbActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Items.AddRange(new object[] {
            "Attack",
            "Defend",
            "Escape",
            "Wait"});
            this.cbActions.Location = new System.Drawing.Point(3, 16);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(131, 21);
            this.cbActions.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Choose action.";
            // 
            // panelMagic
            // 
            this.panelMagic.BackColor = System.Drawing.Color.Transparent;
            this.panelMagic.Controls.Add(this.cbMagic);
            this.panelMagic.Controls.Add(this.label5);
            this.panelMagic.Location = new System.Drawing.Point(7, 68);
            this.panelMagic.Name = "panelMagic";
            this.panelMagic.Size = new System.Drawing.Size(146, 51);
            this.panelMagic.TabIndex = 5;
            this.panelMagic.Visible = false;
            // 
            // cbMagic
            // 
            this.cbMagic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMagic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMagic.FormattingEnabled = true;
            this.cbMagic.Location = new System.Drawing.Point(3, 16);
            this.cbMagic.Name = "cbMagic";
            this.cbMagic.Noneable = false;
            this.cbMagic.SelectedNode = null;
            this.cbMagic.Size = new System.Drawing.Size(131, 21);
            this.cbMagic.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Choose magic.";
            // 
            // cbActionType
            // 
            this.cbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionType.FormattingEnabled = true;
            this.cbActionType.Items.AddRange(new object[] {
            "Basic",
            "Skill",
            "Magic",
            "Item"});
            this.cbActionType.Location = new System.Drawing.Point(10, 41);
            this.cbActionType.Name = "cbActionType";
            this.cbActionType.Size = new System.Drawing.Size(131, 21);
            this.cbActionType.TabIndex = 2;
            this.cbActionType.SelectedIndexChanged += new System.EventHandler(this.cbActionType_SelectedIndexChanged);
            // 
            // panelSkill
            // 
            this.panelSkill.BackColor = System.Drawing.Color.Transparent;
            this.panelSkill.Controls.Add(this.cbSkills);
            this.panelSkill.Controls.Add(this.label4);
            this.panelSkill.Location = new System.Drawing.Point(7, 68);
            this.panelSkill.Name = "panelSkill";
            this.panelSkill.Size = new System.Drawing.Size(146, 51);
            this.panelSkill.TabIndex = 4;
            this.panelSkill.Visible = false;
            // 
            // cbSkills
            // 
            this.cbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Location = new System.Drawing.Point(3, 16);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Noneable = false;
            this.cbSkills.SelectedNode = null;
            this.cbSkills.Size = new System.Drawing.Size(131, 21);
            this.cbSkills.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Choose skill.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose the action type.";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.barPriority);
            this.impactGroupBox1.Controls.Add(this.nudPriority);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 149);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(311, 77);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Priority";
            // 
            // barPriority
            // 
            this.barPriority.BackColor = System.Drawing.Color.Transparent;
            this.barPriority.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.barPriority.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.barPriority.IndentHeight = 6;
            this.barPriority.Location = new System.Drawing.Point(67, 39);
            this.barPriority.Maximum = 10;
            this.barPriority.Minimum = 1;
            this.barPriority.Name = "barPriority";
            this.barPriority.Size = new System.Drawing.Size(179, 31);
            this.barPriority.TabIndex = 3;
            this.barPriority.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.barPriority.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.barPriority.TickHeight = 2;
            this.barPriority.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.barPriority.TrackerSize = new System.Drawing.Size(10, 16);
            this.barPriority.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.barPriority.TrackLineHeight = 3;
            this.barPriority.Value = 10;
            this.barPriority.ValueChanged += new EGMGame.Controls.ValueChangedHandler(this.barPriority_ValueChanged);
            // 
            // nudPriority
            // 
            this.nudPriority.Location = new System.Drawing.Point(10, 46);
            this.nudPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPriority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPriority.Name = "nudPriority";
            this.nudPriority.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPriority.OnChange = true;
            this.nudPriority.Size = new System.Drawing.Size(51, 20);
            this.nudPriority.TabIndex = 2;
            this.nudPriority.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPriority.ValueChanged += new System.EventHandler(this.nudPriority_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the priority of how often the action should be performed.";
            // 
            // EnemyProgramDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(339, 399);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnemyProgramDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Program Dialog";
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.panelParty.ResumeLayout(false);
            this.panelParty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartyLevel)).EndInit();
            this.panelSwitch.ResumeLayout(false);
            this.panelSwitch.PerformLayout();
            this.panelTurn.ResumeLayout(false);
            this.panelTurn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEveryTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartTurn)).EndInit();
            this.panelState.ResumeLayout(false);
            this.panelState.PerformLayout();
            this.panelMp.ResumeLayout(false);
            this.panelMp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpMin)).EndInit();
            this.panelSp.ResumeLayout(false);
            this.panelSp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpMin)).EndInit();
            this.panelHP.ResumeLayout(false);
            this.panelHP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHpMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHpMin)).EndInit();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.panelBasic.ResumeLayout(false);
            this.panelBasic.PerformLayout();
            this.panelMagic.ResumeLayout(false);
            this.panelMagic.PerformLayout();
            this.panelSkill.ResumeLayout(false);
            this.panelSkill.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudPriority;
        private EGMGame.Controls.CustomTrackBar barPriority;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbActionType;
        private System.Windows.Forms.Panel panelBasic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbActions;
        private System.Windows.Forms.Panel panelSkill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelMagic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.Label label6;
        private EGMGame.Controls.Game.SkillsComboBox cbSkills;
        private EGMGame.Controls.Game.SkillsComboBox cbMagic;
        private EGMGame.Controls.Game.ItemsComboBox cbItems;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelTurn;
        private System.Windows.Forms.Label label8;
        private CustomUpDown nudStartTurn;
        private System.Windows.Forms.Label label7;
        private CustomUpDown nudEveryTurn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel panelHP;
        private System.Windows.Forms.Panel panelSwitch;
        private System.Windows.Forms.Panel panelSp;
        private System.Windows.Forms.Panel panelMp;
        private System.Windows.Forms.Panel panelState;
        private System.Windows.Forms.Label label13;
        private CustomUpDown nudHpMax;
        private CustomUpDown nudHpMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private CustomUpDown nudSpMax;
        private CustomUpDown nudSpMin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private CustomUpDown nudMpMax;
        private CustomUpDown nudMpMin;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private EGMGame.Controls.Game.StatesComboBox cbStates;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private EGMGame.Controls.Game.SwitchesComboBox cbSwitches;
        private System.Windows.Forms.Panel panelParty;
        private System.Windows.Forms.Label label16;
        private CustomUpDown nudPartyLevel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSwitchState;
        private System.Windows.Forms.ComboBox cbPartyLevel;
    }
}