namespace EGMGame.Controls.EventControls
{
    partial class EventPageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProgramAI = new System.Windows.Forms.Button();
            this.enemyComboBox1 = new EGMGame.Controls.Game.EnemyComboBox(this.components);
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnJoints = new System.Windows.Forms.Button();
            this.chkMovingPlatform = new System.Windows.Forms.CheckBox();
            this.chkPass = new System.Windows.Forms.CheckBox();
            this.chkSyncAngleToRotation = new System.Windows.Forms.CheckBox();
            this.nudSpeed = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPhysics = new System.Windows.Forms.Button();
            this.chkStatic = new System.Windows.Forms.CheckBox();
            this.nudFreq = new EGMGame.CustomUpDown();
            this.chFreqBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.movementProgramBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbTrigger = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCol = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.chkMapCollision = new System.Windows.Forms.CheckBox();
            this.listEventsBtn = new System.Windows.Forms.Button();
            this.panelMouse = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.chkGBmouse = new System.Windows.Forms.CheckBox();
            this.btnMouseInputCondition = new System.Windows.Forms.Button();
            this.panelInput = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.btnButtonInputCondition = new System.Windows.Forms.Button();
            this.groupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkEventSwitch = new System.Windows.Forms.CheckBox();
            this.btnEventSwitches = new System.Windows.Forms.Button();
            this.nudNearScreen = new EGMGame.CustomUpDown();
            this.chkNearScreen = new System.Windows.Forms.CheckBox();
            this.localVariableChk = new System.Windows.Forms.CheckBox();
            this.localVariablesBtn = new System.Windows.Forms.Button();
            this.localSwitchChk = new System.Windows.Forms.CheckBox();
            this.localSwitchesBtn = new System.Windows.Forms.Button();
            this.variablChk = new System.Windows.Forms.CheckBox();
            this.variablesBtn = new System.Windows.Forms.Button();
            this.switchChk = new System.Windows.Forms.CheckBox();
            this.switchesBtn = new System.Windows.Forms.Button();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbParticles = new EGMGame.Controls.Game.ParticleComboBox(this.components);
            this.groupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.behaviorProgramListBox1 = new EGMGame.Controls.EventControls.BehaviorProgramListBox();
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label = new System.Windows.Forms.Label();
            this.directionsList = new System.Windows.Forms.ComboBox();
            this.animationViewer = new EGMGame.Controls.AnimationViewer();
            this.actionList = new System.Windows.Forms.ComboBox();
            this.impactGroupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbCursor = new EGMGame.Controls.Game.MaterialsComboBox(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.panelCol.SuspendLayout();
            this.panelMouse.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNearScreen)).BeginInit();
            this.impactGroupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.impactGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 317);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(185, 525);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.impactGroupBox2);
            this.tabPage1.Controls.Add(this.impactGroupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(177, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Control";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.label4);
            this.impactGroupBox2.Controls.Add(this.btnProgramAI);
            this.impactGroupBox2.Controls.Add(this.enemyComboBox1);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(6, 301);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(150, 102);
            this.impactGroupBox2.TabIndex = 11;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Enemy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Choose enemy:";
            // 
            // btnProgramAI
            // 
            this.btnProgramAI.Enabled = false;
            this.btnProgramAI.Image = global::EGMGame.Properties.Resources.user_silhouette;
            this.btnProgramAI.Location = new System.Drawing.Point(10, 68);
            this.btnProgramAI.Name = "btnProgramAI";
            this.btnProgramAI.Size = new System.Drawing.Size(133, 26);
            this.btnProgramAI.TabIndex = 5;
            this.btnProgramAI.Text = "Program AI";
            this.btnProgramAI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnProgramAI, "Edit the Enemy\'s AI settings.");
            this.btnProgramAI.UseVisualStyleBackColor = true;
            this.btnProgramAI.Click += new System.EventHandler(this.btnProgramAI_Click);
            // 
            // enemyComboBox1
            // 
            this.enemyComboBox1.AllowCategories = true;
            this.enemyComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.enemyComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enemyComboBox1.FormattingEnabled = true;
            this.enemyComboBox1.Location = new System.Drawing.Point(10, 41);
            this.enemyComboBox1.Name = "enemyComboBox1";
            this.enemyComboBox1.Noneable = true;
            this.enemyComboBox1.SelectedNode = null;
            this.enemyComboBox1.Size = new System.Drawing.Size(133, 21);
            this.enemyComboBox1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.enemyComboBox1, "Select the Enemy this event should represent.\r\nIf an Enemy is selected, the Anima" +
        "tion of this Event will\r\nbe replaced with the Enemy\'s.");
            this.enemyComboBox1.SelectedIndexChanged += new System.EventHandler(this.enemyComboBox1_SelectedIndexChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.btnJoints);
            this.impactGroupBox1.Controls.Add(this.chkMovingPlatform);
            this.impactGroupBox1.Controls.Add(this.chkPass);
            this.impactGroupBox1.Controls.Add(this.chkSyncAngleToRotation);
            this.impactGroupBox1.Controls.Add(this.nudSpeed);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.btnPhysics);
            this.impactGroupBox1.Controls.Add(this.chkStatic);
            this.impactGroupBox1.Controls.Add(this.nudFreq);
            this.impactGroupBox1.Controls.Add(this.chFreqBox);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(6, 68);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(150, 227);
            this.impactGroupBox1.TabIndex = 13;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Dynamics";
            // 
            // btnJoints
            // 
            this.btnJoints.Image = global::EGMGame.Properties.Resources.draw_vertex;
            this.btnJoints.Location = new System.Drawing.Point(6, 196);
            this.btnJoints.Name = "btnJoints";
            this.btnJoints.Size = new System.Drawing.Size(130, 27);
            this.btnJoints.TabIndex = 24;
            this.btnJoints.Text = "Attach Events";
            this.btnJoints.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnJoints, "Attach other events to this event via different joint types.\r\nEach joint type can" +
        " yield different effects.");
            this.btnJoints.UseVisualStyleBackColor = true;
            this.btnJoints.Click += new System.EventHandler(this.btnJoints_Click);
            // 
            // chkMovingPlatform
            // 
            this.chkMovingPlatform.AutoSize = true;
            this.chkMovingPlatform.Location = new System.Drawing.Point(8, 173);
            this.chkMovingPlatform.Name = "chkMovingPlatform";
            this.chkMovingPlatform.Size = new System.Drawing.Size(102, 17);
            this.chkMovingPlatform.TabIndex = 23;
            this.chkMovingPlatform.Text = "Moving Platform";
            this.toolTip1.SetToolTip(this.chkMovingPlatform, "If checked, anything that is on top of this platform\r\nwill move along with this p" +
        "latform.");
            this.chkMovingPlatform.UseVisualStyleBackColor = true;
            this.chkMovingPlatform.CheckedChanged += new System.EventHandler(this.chkMovingPlatform_CheckedChanged);
            // 
            // chkPass
            // 
            this.chkPass.AutoSize = true;
            this.chkPass.Location = new System.Drawing.Point(9, 48);
            this.chkPass.Name = "chkPass";
            this.chkPass.Size = new System.Drawing.Size(92, 17);
            this.chkPass.TabIndex = 22;
            this.chkPass.Text = "Pass Through";
            this.toolTip1.SetToolTip(this.chkPass, "If Pass Through is checked, this event can report collision but will be passable." +
        "");
            this.chkPass.UseVisualStyleBackColor = true;
            this.chkPass.CheckedChanged += new System.EventHandler(this.chkPass_CheckedChanged);
            // 
            // chkSyncAngleToRotation
            // 
            this.chkSyncAngleToRotation.AutoSize = true;
            this.chkSyncAngleToRotation.Location = new System.Drawing.Point(8, 150);
            this.chkSyncAngleToRotation.Name = "chkSyncAngleToRotation";
            this.chkSyncAngleToRotation.Size = new System.Drawing.Size(139, 17);
            this.chkSyncAngleToRotation.TabIndex = 21;
            this.chkSyncAngleToRotation.Text = "Sync Angle To Rotation";
            this.toolTip1.SetToolTip(this.chkSyncAngleToRotation, "If checked, the Angle/Direction of this Event will synchronized\r\nwith it\'s animat" +
        "ion\'s collision box. \r\nUseful for Events that turn by rotation.");
            this.chkSyncAngleToRotation.UseVisualStyleBackColor = true;
            this.chkSyncAngleToRotation.CheckedChanged += new System.EventHandler(this.chkSyncAngleToRotation_CheckedChanged);
            // 
            // nudSpeed
            // 
            this.nudSpeed.Enabled = false;
            this.nudSpeed.Location = new System.Drawing.Point(90, 66);
            this.nudSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpeed.OnChange = true;
            this.nudSpeed.Size = new System.Drawing.Size(52, 20);
            this.nudSpeed.TabIndex = 20;
            this.toolTip1.SetToolTip(this.nudSpeed, "If Static is checked, move speed is determines the rate\r\nthis event can move. Low" +
        "er the faster.");
            this.nudSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSpeed.Validated += new System.EventHandler(this.nudSpeed_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Move Speed";
            // 
            // btnPhysics
            // 
            this.btnPhysics.Image = global::EGMGame.Properties.Resources.rocket_fly;
            this.btnPhysics.Location = new System.Drawing.Point(6, 94);
            this.btnPhysics.Name = "btnPhysics";
            this.btnPhysics.Size = new System.Drawing.Size(130, 27);
            this.btnPhysics.TabIndex = 18;
            this.btnPhysics.Text = "Physics Settings";
            this.btnPhysics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnPhysics, "Contains physics settings such as Mass, Friction, Drag,\r\nForce, and Impulse.");
            this.btnPhysics.UseVisualStyleBackColor = true;
            this.btnPhysics.Click += new System.EventHandler(this.btnPhysics_Click);
            // 
            // chkStatic
            // 
            this.chkStatic.AutoSize = true;
            this.chkStatic.Location = new System.Drawing.Point(9, 25);
            this.chkStatic.Name = "chkStatic";
            this.chkStatic.Size = new System.Drawing.Size(53, 17);
            this.chkStatic.TabIndex = 15;
            this.chkStatic.Text = "Static";
            this.toolTip1.SetToolTip(this.chkStatic, "If Static is checked, the event will not be affected by outside\r\nphysical forces." +
        " Useful for NPCs. \r\nNote: Two static objects can not collide with each other.");
            this.chkStatic.UseVisualStyleBackColor = true;
            this.chkStatic.CheckedChanged += new System.EventHandler(this.chkStatic_CheckedChanged);
            // 
            // nudFreq
            // 
            this.nudFreq.Location = new System.Drawing.Point(90, 127);
            this.nudFreq.Name = "nudFreq";
            this.nudFreq.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudFreq.OnChange = false;
            this.nudFreq.Size = new System.Drawing.Size(52, 20);
            this.nudFreq.TabIndex = 9;
            this.nudFreq.ValueChanged += new System.EventHandler(this.nudFreq_ValueChanged);
            this.nudFreq.Validated += new System.EventHandler(this.nudFreq_Validated);
            // 
            // chFreqBox
            // 
            this.chFreqBox.AutoSize = true;
            this.chFreqBox.Location = new System.Drawing.Point(8, 127);
            this.chFreqBox.Name = "chFreqBox";
            this.chFreqBox.Size = new System.Drawing.Size(76, 17);
            this.chFreqBox.TabIndex = 8;
            this.chFreqBox.Text = "Frequency";
            this.toolTip1.SetToolTip(this.chFreqBox, "If Frequency is checked, the animation\'s frame counts will be ignored.\r\nInstead, " +
        "each frame will be played with a constant value set by the Frequency.");
            this.chFreqBox.UseVisualStyleBackColor = true;
            this.chFreqBox.CheckedChanged += new System.EventHandler(this.chFreqBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox3.CanCollapse = false;
            this.groupBox3.Controls.Add(this.movementProgramBtn);
            this.groupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox3.Image = null;
            this.groupBox3.IsCollapsed = false;
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(150, 56);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movement";
            // 
            // movementProgramBtn
            // 
            this.movementProgramBtn.Location = new System.Drawing.Point(5, 24);
            this.movementProgramBtn.Name = "movementProgramBtn";
            this.movementProgramBtn.Size = new System.Drawing.Size(138, 27);
            this.movementProgramBtn.TabIndex = 4;
            this.movementProgramBtn.Text = "Program Dynamics";
            this.toolTip1.SetToolTip(this.movementProgramBtn, "Program the movement path and other dynamics for \r\nthis Event.");
            this.movementProgramBtn.UseVisualStyleBackColor = true;
            this.movementProgramBtn.Click += new System.EventHandler(this.movementProgramBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.impactGroupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(177, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Activation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.CanCollapse = false;
            this.impactGroupBox3.Controls.Add(this.cbTrigger);
            this.impactGroupBox3.Controls.Add(this.label3);
            this.impactGroupBox3.Controls.Add(this.panelCol);
            this.impactGroupBox3.Controls.Add(this.panelMouse);
            this.impactGroupBox3.Controls.Add(this.panelInput);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Image = null;
            this.impactGroupBox3.IsCollapsed = false;
            this.impactGroupBox3.Location = new System.Drawing.Point(6, 229);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(150, 137);
            this.impactGroupBox3.TabIndex = 12;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Trigger Condition";
            // 
            // cbTrigger
            // 
            this.cbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrigger.FormattingEnabled = true;
            this.cbTrigger.Items.AddRange(new object[] {
            "Action Button",
            "Collision",
            "Autorun Once",
            "Autorun Loop",
            "Mouse Input",
            "Mouse Over",
            "Input",
            "Background Process",
            "Projectile Collision"});
            this.cbTrigger.Location = new System.Drawing.Point(11, 54);
            this.cbTrigger.Name = "cbTrigger";
            this.cbTrigger.Size = new System.Drawing.Size(123, 21);
            this.cbTrigger.TabIndex = 1;
            this.cbTrigger.SelectedIndexChanged += new System.EventHandler(this.cbTrigger_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Choose the trigger that\r\nwill start the programming.";
            // 
            // panelCol
            // 
            this.panelCol.Controls.Add(this.chkMapCollision);
            this.panelCol.Controls.Add(this.listEventsBtn);
            this.panelCol.Location = new System.Drawing.Point(7, 76);
            this.panelCol.Name = "panelCol";
            this.panelCol.Size = new System.Drawing.Size(128, 53);
            this.panelCol.TabIndex = 16;
            this.panelCol.Visible = false;
            // 
            // chkMapCollision
            // 
            this.chkMapCollision.AutoSize = true;
            this.chkMapCollision.Location = new System.Drawing.Point(5, 31);
            this.chkMapCollision.Name = "chkMapCollision";
            this.chkMapCollision.Size = new System.Drawing.Size(88, 17);
            this.chkMapCollision.TabIndex = 11;
            this.chkMapCollision.Text = "Map Collision";
            this.chkMapCollision.UseVisualStyleBackColor = true;
            this.chkMapCollision.CheckedChanged += new System.EventHandler(this.chkMapCollision_CheckedChanged);
            // 
            // listEventsBtn
            // 
            this.listEventsBtn.Location = new System.Drawing.Point(4, 3);
            this.listEventsBtn.Name = "listEventsBtn";
            this.listEventsBtn.Size = new System.Drawing.Size(123, 27);
            this.listEventsBtn.TabIndex = 10;
            this.listEventsBtn.Text = "List Events";
            this.listEventsBtn.UseVisualStyleBackColor = true;
            this.listEventsBtn.Click += new System.EventHandler(this.listEventsBtn_Click);
            // 
            // panelMouse
            // 
            this.panelMouse.Controls.Add(this.chkGBmouse);
            this.panelMouse.Controls.Add(this.btnMouseInputCondition);
            this.panelMouse.Location = new System.Drawing.Point(7, 76);
            this.panelMouse.Name = "panelMouse";
            this.panelMouse.Size = new System.Drawing.Size(128, 53);
            this.panelMouse.TabIndex = 17;
            this.panelMouse.Visible = false;
            // 
            // chkGBmouse
            // 
            this.chkGBmouse.AutoSize = true;
            this.chkGBmouse.Location = new System.Drawing.Point(4, 33);
            this.chkGBmouse.Name = "chkGBmouse";
            this.chkGBmouse.Size = new System.Drawing.Size(91, 17);
            this.chkGBmouse.TabIndex = 63;
            this.chkGBmouse.Text = "Global Mouse";
            this.chkGBmouse.UseVisualStyleBackColor = true;
            this.chkGBmouse.CheckedChanged += new System.EventHandler(this.chkGBmouse_CheckedChanged);
            // 
            // btnMouseInputCondition
            // 
            this.btnMouseInputCondition.Image = global::EGMGame.Properties.Resources.document_number_split;
            this.btnMouseInputCondition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMouseInputCondition.Location = new System.Drawing.Point(3, 3);
            this.btnMouseInputCondition.Name = "btnMouseInputCondition";
            this.btnMouseInputCondition.Size = new System.Drawing.Size(123, 27);
            this.btnMouseInputCondition.TabIndex = 62;
            this.btnMouseInputCondition.Text = "Mouse Input";
            this.btnMouseInputCondition.UseVisualStyleBackColor = true;
            this.btnMouseInputCondition.Click += new System.EventHandler(this.btnMouseInputCondition_Click);
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.btnButtonInputCondition);
            this.panelInput.Location = new System.Drawing.Point(7, 76);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(128, 53);
            this.panelInput.TabIndex = 18;
            this.panelInput.Visible = false;
            // 
            // btnButtonInputCondition
            // 
            this.btnButtonInputCondition.Image = global::EGMGame.Properties.Resources.keyboard_split;
            this.btnButtonInputCondition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnButtonInputCondition.Location = new System.Drawing.Point(3, 4);
            this.btnButtonInputCondition.Name = "btnButtonInputCondition";
            this.btnButtonInputCondition.Size = new System.Drawing.Size(123, 27);
            this.btnButtonInputCondition.TabIndex = 61;
            this.btnButtonInputCondition.Text = "Button Input";
            this.btnButtonInputCondition.UseVisualStyleBackColor = true;
            this.btnButtonInputCondition.Click += new System.EventHandler(this.btnButtonInputCondition_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox4.CanCollapse = false;
            this.groupBox4.Controls.Add(this.chkEventSwitch);
            this.groupBox4.Controls.Add(this.btnEventSwitches);
            this.groupBox4.Controls.Add(this.nudNearScreen);
            this.groupBox4.Controls.Add(this.chkNearScreen);
            this.groupBox4.Controls.Add(this.localVariableChk);
            this.groupBox4.Controls.Add(this.localVariablesBtn);
            this.groupBox4.Controls.Add(this.localSwitchChk);
            this.groupBox4.Controls.Add(this.localSwitchesBtn);
            this.groupBox4.Controls.Add(this.variablChk);
            this.groupBox4.Controls.Add(this.variablesBtn);
            this.groupBox4.Controls.Add(this.switchChk);
            this.groupBox4.Controls.Add(this.switchesBtn);
            this.groupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox4.Image = null;
            this.groupBox4.IsCollapsed = false;
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(150, 217);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Activation Conditions";
            // 
            // chkEventSwitch
            // 
            this.chkEventSwitch.AutoSize = true;
            this.chkEventSwitch.BackColor = System.Drawing.Color.Transparent;
            this.chkEventSwitch.Location = new System.Drawing.Point(11, 163);
            this.chkEventSwitch.Name = "chkEventSwitch";
            this.chkEventSwitch.Size = new System.Drawing.Size(15, 14);
            this.chkEventSwitch.TabIndex = 13;
            this.chkEventSwitch.UseVisualStyleBackColor = false;
            this.chkEventSwitch.CheckedChanged += new System.EventHandler(this.chkEventSwitch_CheckedChanged);
            // 
            // btnEventSwitches
            // 
            this.btnEventSwitches.Enabled = false;
            this.btnEventSwitches.Location = new System.Drawing.Point(32, 157);
            this.btnEventSwitches.Name = "btnEventSwitches";
            this.btnEventSwitches.Size = new System.Drawing.Size(113, 27);
            this.btnEventSwitches.TabIndex = 12;
            this.btnEventSwitches.Text = "Event Switches";
            this.btnEventSwitches.UseVisualStyleBackColor = true;
            this.btnEventSwitches.Click += new System.EventHandler(this.btnEventSwitches_Click);
            // 
            // nudNearScreen
            // 
            this.nudNearScreen.Location = new System.Drawing.Point(108, 189);
            this.nudNearScreen.Name = "nudNearScreen";
            this.nudNearScreen.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudNearScreen.OnChange = false;
            this.nudNearScreen.Size = new System.Drawing.Size(40, 20);
            this.nudNearScreen.TabIndex = 11;
            this.nudNearScreen.Validated += new System.EventHandler(this.nudNearScreen_Validated);
            // 
            // chkNearScreen
            // 
            this.chkNearScreen.AutoSize = true;
            this.chkNearScreen.BackColor = System.Drawing.Color.Transparent;
            this.chkNearScreen.Location = new System.Drawing.Point(11, 190);
            this.chkNearScreen.Name = "chkNearScreen";
            this.chkNearScreen.Size = new System.Drawing.Size(101, 17);
            this.chkNearScreen.TabIndex = 10;
            this.chkNearScreen.Text = "Near Screen By";
            this.chkNearScreen.UseVisualStyleBackColor = false;
            // 
            // localVariableChk
            // 
            this.localVariableChk.AutoSize = true;
            this.localVariableChk.BackColor = System.Drawing.Color.Transparent;
            this.localVariableChk.Location = new System.Drawing.Point(11, 130);
            this.localVariableChk.Name = "localVariableChk";
            this.localVariableChk.Size = new System.Drawing.Size(15, 14);
            this.localVariableChk.TabIndex = 9;
            this.localVariableChk.UseVisualStyleBackColor = false;
            this.localVariableChk.CheckedChanged += new System.EventHandler(this.localVariableChk_CheckedChanged);
            // 
            // localVariablesBtn
            // 
            this.localVariablesBtn.Enabled = false;
            this.localVariablesBtn.Location = new System.Drawing.Point(32, 124);
            this.localVariablesBtn.Name = "localVariablesBtn";
            this.localVariablesBtn.Size = new System.Drawing.Size(113, 27);
            this.localVariablesBtn.TabIndex = 8;
            this.localVariablesBtn.Text = "Local Variables";
            this.localVariablesBtn.UseVisualStyleBackColor = true;
            this.localVariablesBtn.Click += new System.EventHandler(this.localVariablesBtn_Click);
            // 
            // localSwitchChk
            // 
            this.localSwitchChk.AutoSize = true;
            this.localSwitchChk.BackColor = System.Drawing.Color.Transparent;
            this.localSwitchChk.Location = new System.Drawing.Point(11, 97);
            this.localSwitchChk.Name = "localSwitchChk";
            this.localSwitchChk.Size = new System.Drawing.Size(15, 14);
            this.localSwitchChk.TabIndex = 7;
            this.localSwitchChk.UseVisualStyleBackColor = false;
            this.localSwitchChk.CheckedChanged += new System.EventHandler(this.localSwitchChk_CheckedChanged);
            // 
            // localSwitchesBtn
            // 
            this.localSwitchesBtn.Enabled = false;
            this.localSwitchesBtn.Location = new System.Drawing.Point(32, 91);
            this.localSwitchesBtn.Name = "localSwitchesBtn";
            this.localSwitchesBtn.Size = new System.Drawing.Size(113, 27);
            this.localSwitchesBtn.TabIndex = 6;
            this.localSwitchesBtn.Text = "Local Switches";
            this.localSwitchesBtn.UseVisualStyleBackColor = true;
            this.localSwitchesBtn.Click += new System.EventHandler(this.localSwitchesBtn_Click);
            // 
            // variablChk
            // 
            this.variablChk.AutoSize = true;
            this.variablChk.BackColor = System.Drawing.Color.Transparent;
            this.variablChk.Location = new System.Drawing.Point(11, 64);
            this.variablChk.Name = "variablChk";
            this.variablChk.Size = new System.Drawing.Size(15, 14);
            this.variablChk.TabIndex = 5;
            this.variablChk.UseVisualStyleBackColor = false;
            this.variablChk.CheckedChanged += new System.EventHandler(this.variablChk_CheckedChanged);
            // 
            // variablesBtn
            // 
            this.variablesBtn.Enabled = false;
            this.variablesBtn.Location = new System.Drawing.Point(32, 58);
            this.variablesBtn.Name = "variablesBtn";
            this.variablesBtn.Size = new System.Drawing.Size(113, 27);
            this.variablesBtn.TabIndex = 4;
            this.variablesBtn.Text = "Variables";
            this.variablesBtn.UseVisualStyleBackColor = true;
            this.variablesBtn.Click += new System.EventHandler(this.variablesBtn_Click);
            // 
            // switchChk
            // 
            this.switchChk.AutoSize = true;
            this.switchChk.BackColor = System.Drawing.Color.Transparent;
            this.switchChk.Location = new System.Drawing.Point(11, 32);
            this.switchChk.Name = "switchChk";
            this.switchChk.Size = new System.Drawing.Size(15, 14);
            this.switchChk.TabIndex = 1;
            this.switchChk.UseVisualStyleBackColor = false;
            this.switchChk.CheckedChanged += new System.EventHandler(this.switchChk_CheckedChanged);
            // 
            // switchesBtn
            // 
            this.switchesBtn.Enabled = false;
            this.switchesBtn.Location = new System.Drawing.Point(32, 25);
            this.switchesBtn.Name = "switchesBtn";
            this.switchesBtn.Size = new System.Drawing.Size(113, 27);
            this.switchesBtn.TabIndex = 1;
            this.switchesBtn.Text = "Switches";
            this.switchesBtn.UseVisualStyleBackColor = true;
            this.switchesBtn.Click += new System.EventHandler(this.switchesBtn_Click);
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.CanCollapse = false;
            this.impactGroupBox4.Controls.Add(this.cbParticles);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Image = null;
            this.impactGroupBox4.IsCollapsed = false;
            this.impactGroupBox4.Location = new System.Drawing.Point(3, 193);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(181, 56);
            this.impactGroupBox4.TabIndex = 13;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Particle System";
            // 
            // cbParticles
            // 
            this.cbParticles.AllowCategories = true;
            this.cbParticles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbParticles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParticles.FormattingEnabled = true;
            this.cbParticles.Location = new System.Drawing.Point(10, 27);
            this.cbParticles.Name = "cbParticles";
            this.cbParticles.Noneable = true;
            this.cbParticles.SelectedNode = null;
            this.cbParticles.Size = new System.Drawing.Size(145, 21);
            this.cbParticles.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbParticles, "Select the particle system this Event will display on top of it.\r\nUseful for camp" +
        " fires and etc.");
            this.cbParticles.SelectedIndexChanged += new System.EventHandler(this.cbParticles_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox5.CanCollapse = false;
            this.groupBox5.Controls.Add(this.behaviorProgramListBox1);
            this.groupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox5.Image = null;
            this.groupBox5.IsCollapsed = false;
            this.groupBox5.Location = new System.Drawing.Point(190, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(543, 815);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Program";
            // 
            // behaviorProgramListBox1
            // 
            this.behaviorProgramListBox1.BackColor = System.Drawing.Color.White;
            this.behaviorProgramListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.behaviorProgramListBox1.Location = new System.Drawing.Point(4, 25);
            this.behaviorProgramListBox1.Margin = new System.Windows.Forms.Padding(4);
            this.behaviorProgramListBox1.Name = "behaviorProgramListBox1";
            this.behaviorProgramListBox1.SelectedAction = null;
            this.behaviorProgramListBox1.SelectedEvent = null;
            this.behaviorProgramListBox1.SelectedPage = null;
            this.behaviorProgramListBox1.Size = new System.Drawing.Size(535, 785);
            this.behaviorProgramListBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox2.CanCollapse = false;
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Controls.Add(this.directionsList);
            this.groupBox2.Controls.Add(this.animationViewer);
            this.groupBox2.Controls.Add(this.actionList);
            this.groupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox2.Image = null;
            this.groupBox2.IsCollapsed = false;
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(181, 187);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.DarkGray;
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(38, 62);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(108, 26);
            this.label.TabIndex = 4;
            this.label.Text = "Double Click To Add \r\n        Animation";
            this.label.Click += new System.EventHandler(this.label_Click);
            this.label.DoubleClick += new System.EventHandler(this.animationPanel_DoubleClick);
            // 
            // directionsList
            // 
            this.directionsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionsList.FormattingEnabled = true;
            this.directionsList.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right",
            "Up/Left",
            "Up/Right",
            "Down/Left",
            "Down/Right"});
            this.directionsList.Location = new System.Drawing.Point(110, 158);
            this.directionsList.Name = "directionsList";
            this.directionsList.Size = new System.Drawing.Size(64, 21);
            this.directionsList.TabIndex = 10;
            this.toolTip1.SetToolTip(this.directionsList, "Select the Direction.");
            this.directionsList.SelectedIndexChanged += new System.EventHandler(this.directionsList_SelectedIndexChanged);
            // 
            // animationViewer
            // 
            this.animationViewer.AllowZoom = true;
            this.animationViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationViewer.Location = new System.Drawing.Point(7, 25);
            this.animationViewer.Margin = new System.Windows.Forms.Padding(4);
            this.animationViewer.Name = "animationViewer";
            this.animationViewer.SelectedFrame = null;
            this.animationViewer.Size = new System.Drawing.Size(166, 126);
            this.animationViewer.TabIndex = 5;
            this.toolTip1.SetToolTip(this.animationViewer, "Double Click To Add Animation\r\nAfter adding, select action and direction.");
            this.animationViewer.Load += new System.EventHandler(this.animationViewer_Load);
            this.animationViewer.DoubleClick += new System.EventHandler(this.animationPanel_DoubleClick);
            // 
            // actionList
            // 
            this.actionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionList.FormattingEnabled = true;
            this.actionList.Location = new System.Drawing.Point(7, 158);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(97, 21);
            this.actionList.TabIndex = 3;
            this.toolTip1.SetToolTip(this.actionList, "Select the Action.");
            this.actionList.SelectedIndexChanged += new System.EventHandler(this.animationAction_SelectedIndexChanged);
            // 
            // impactGroupBox5
            // 
            this.impactGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox5.CanCollapse = false;
            this.impactGroupBox5.Controls.Add(this.cbCursor);
            this.impactGroupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox5.Image = null;
            this.impactGroupBox5.IsCollapsed = false;
            this.impactGroupBox5.Location = new System.Drawing.Point(3, 255);
            this.impactGroupBox5.Name = "impactGroupBox5";
            this.impactGroupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox5.Size = new System.Drawing.Size(181, 56);
            this.impactGroupBox5.TabIndex = 14;
            this.impactGroupBox5.TabStop = false;
            this.impactGroupBox5.Text = "Cursor";
            // 
            // cbCursor
            // 
            this.cbCursor.AllowDrop = true;
            this.cbCursor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCursor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCursor.FormattingEnabled = true;
            this.cbCursor.Location = new System.Drawing.Point(10, 27);
            this.cbCursor.Name = "cbCursor";
            this.cbCursor.SelectedNode = null;
            this.cbCursor.Size = new System.Drawing.Size(145, 21);
            this.cbCursor.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbCursor, "Select the cursor image that will appear when\r\nthe cursor is on this Event.");
            this.cbCursor.SelectedIndexChanged += new System.EventHandler(this.cbCursor_SelectedIndexChanged);
            // 
            // EventPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.impactGroupBox5);
            this.Controls.Add(this.impactGroupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.Name = "EventPageControl";
            this.Size = new System.Drawing.Size(733, 815);
            this.EnabledChanged += new System.EventHandler(this.EventPageControl_EnabledChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.panelCol.ResumeLayout(false);
            this.panelCol.PerformLayout();
            this.panelMouse.ResumeLayout(false);
            this.panelMouse.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNearScreen)).EndInit();
            this.impactGroupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.impactGroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox5;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox4;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox3;
        private System.Windows.Forms.Button movementProgramBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        private System.Windows.Forms.ComboBox actionList;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.CheckBox localVariableChk;
        private System.Windows.Forms.Button localVariablesBtn;
        private System.Windows.Forms.CheckBox localSwitchChk;
        private System.Windows.Forms.Button localSwitchesBtn;
        private System.Windows.Forms.CheckBox variablChk;
        private System.Windows.Forms.Button variablesBtn;
        private System.Windows.Forms.CheckBox switchChk;
        private System.Windows.Forms.Button switchesBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private CustomUpDown nudNearScreen;
        private System.Windows.Forms.CheckBox chkNearScreen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private AnimationViewer animationViewer;
        private System.Windows.Forms.ComboBox directionsList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.Game.EnemyComboBox enemyComboBox1;
        private System.Windows.Forms.Button btnProgramAI;
        private System.Windows.Forms.Label label4;
        private CustomUpDown nudFreq;
        private System.Windows.Forms.CheckBox chFreqBox;
        private System.Windows.Forms.Button listEventsBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTrigger;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelCol;
        private System.Windows.Forms.CheckBox chkMapCollision;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelMouse;
        private EGMGame.Controls.ImpactUI.ImpactPanel panelInput;
        private System.Windows.Forms.Button btnMouseInputCondition;
        private System.Windows.Forms.Button btnButtonInputCondition;
        private System.Windows.Forms.CheckBox chkGBmouse;
        private System.Windows.Forms.CheckBox chkStatic;
        private System.Windows.Forms.Button btnPhysics;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private EGMGame.Controls.Game.ParticleComboBox cbParticles;
        private CustomUpDown nudSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSyncAngleToRotation;
        private System.Windows.Forms.CheckBox chkPass;
        private ImpactUI.ImpactGroupBox impactGroupBox5;
        private Game.MaterialsComboBox cbCursor;
        internal BehaviorProgramListBox behaviorProgramListBox1;
        private System.Windows.Forms.CheckBox chkEventSwitch;
        private System.Windows.Forms.Button btnEventSwitches;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkMovingPlatform;
        private System.Windows.Forms.Button btnJoints;
    }
}
