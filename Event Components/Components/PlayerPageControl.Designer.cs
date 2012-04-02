namespace EGMGame.Controls.EventControls
{
    partial class PlayerPageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerPageControl));
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkSyncAngleToRotation = new System.Windows.Forms.CheckBox();
            this.nudSpeed = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPhysics = new System.Windows.Forms.Button();
            this.chkStatic = new System.Windows.Forms.CheckBox();
            this.nudFreq = new EGMGame.CustomUpDown();
            this.chFreqBox = new System.Windows.Forms.CheckBox();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbDirections = new System.Windows.Forms.ComboBox();
            this.btnControlMapping = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMaxParty = new EGMGame.CustomUpDown();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.partyList = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddParty = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveParty = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPartyUP = new System.Windows.Forms.ToolStripButton();
            this.btnPartyDW = new System.Windows.Forms.ToolStripButton();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.downRightBtn = new System.Windows.Forms.CheckBox();
            this.upBtn = new System.Windows.Forms.CheckBox();
            this.upRightBtn = new System.Windows.Forms.CheckBox();
            this.upLeftBtn = new System.Windows.Forms.CheckBox();
            this.downLeftBtn = new System.Windows.Forms.CheckBox();
            this.rightBtn = new System.Windows.Forms.CheckBox();
            this.leftBtn = new System.Windows.Forms.CheckBox();
            this.downBtn = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.behaviorProgramListBox1 = new EGMGame.Controls.EventControls.BehaviorProgramListBox();
            this.impactGroupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbParticles = new EGMGame.Controls.Game.ParticleComboBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnJoints = new System.Windows.Forms.Button();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).BeginInit();
            this.impactGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxParty)).BeginInit();
            this.impactGroupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.impactGroupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.btnJoints);
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
            this.impactGroupBox1.Location = new System.Drawing.Point(3, 179);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(141, 182);
            this.impactGroupBox1.TabIndex = 14;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Dynamics";
            // 
            // chkSyncAngleToRotation
            // 
            this.chkSyncAngleToRotation.AutoSize = true;
            this.chkSyncAngleToRotation.Location = new System.Drawing.Point(8, 125);
            this.chkSyncAngleToRotation.Name = "chkSyncAngleToRotation";
            this.chkSyncAngleToRotation.Size = new System.Drawing.Size(139, 17);
            this.chkSyncAngleToRotation.TabIndex = 18;
            this.chkSyncAngleToRotation.Text = "Sync Angle To Rotation";
            this.chkSyncAngleToRotation.UseVisualStyleBackColor = true;
            this.chkSyncAngleToRotation.CheckedChanged += new System.EventHandler(this.chkSyncAngleToRotation_CheckedChanged);
            // 
            // nudSpeed
            // 
            this.nudSpeed.Enabled = false;
            this.nudSpeed.Location = new System.Drawing.Point(82, 43);
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
            this.nudSpeed.TabIndex = 17;
            this.nudSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Move Speed";
            // 
            // btnPhysics
            // 
            this.btnPhysics.Image = global::EGMGame.Properties.Resources.rocket_fly;
            this.btnPhysics.Location = new System.Drawing.Point(5, 69);
            this.btnPhysics.Name = "btnPhysics";
            this.btnPhysics.Size = new System.Drawing.Size(130, 27);
            this.btnPhysics.TabIndex = 16;
            this.btnPhysics.Text = "Physics Settings";
            this.btnPhysics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.chkStatic.UseVisualStyleBackColor = true;
            this.chkStatic.CheckedChanged += new System.EventHandler(this.chkStatic_CheckedChanged);
            // 
            // nudFreq
            // 
            this.nudFreq.Location = new System.Drawing.Point(83, 102);
            this.nudFreq.Name = "nudFreq";
            this.nudFreq.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudFreq.OnChange = false;
            this.nudFreq.Size = new System.Drawing.Size(52, 20);
            this.nudFreq.TabIndex = 9;
            this.nudFreq.Validated += new System.EventHandler(this.nudFreq_Validated);
            // 
            // chFreqBox
            // 
            this.chFreqBox.AutoSize = true;
            this.chFreqBox.Location = new System.Drawing.Point(9, 102);
            this.chFreqBox.Name = "chFreqBox";
            this.chFreqBox.Size = new System.Drawing.Size(76, 17);
            this.chFreqBox.TabIndex = 8;
            this.chFreqBox.Text = "Frequency";
            this.chFreqBox.UseVisualStyleBackColor = true;
            this.chFreqBox.CheckedChanged += new System.EventHandler(this.chFreqBox_CheckedChanged);
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.CanCollapse = false;
            this.impactGroupBox4.Controls.Add(this.cbDirections);
            this.impactGroupBox4.Controls.Add(this.btnControlMapping);
            this.impactGroupBox4.Controls.Add(this.label1);
            this.impactGroupBox4.Controls.Add(this.nudMaxParty);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Image = null;
            this.impactGroupBox4.IsCollapsed = false;
            this.impactGroupBox4.Location = new System.Drawing.Point(3, 3);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(141, 109);
            this.impactGroupBox4.TabIndex = 14;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Settings";
            // 
            // cbDirections
            // 
            this.cbDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirections.FormattingEnabled = true;
            this.cbDirections.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right",
            "Up/Left",
            "Up/Right",
            "Down/Left",
            "Down/Right"});
            this.cbDirections.Location = new System.Drawing.Point(9, 23);
            this.cbDirections.Margin = new System.Windows.Forms.Padding(2);
            this.cbDirections.Name = "cbDirections";
            this.cbDirections.Size = new System.Drawing.Size(120, 21);
            this.cbDirections.TabIndex = 10;
            this.cbDirections.SelectedIndexChanged += new System.EventHandler(this.cbDirections_SelectedIndexChanged);
            // 
            // btnControlMapping
            // 
            this.btnControlMapping.Image = ((System.Drawing.Image)(resources.GetObject("btnControlMapping.Image")));
            this.btnControlMapping.Location = new System.Drawing.Point(10, 75);
            this.btnControlMapping.Name = "btnControlMapping";
            this.btnControlMapping.Size = new System.Drawing.Size(124, 27);
            this.btnControlMapping.TabIndex = 1;
            this.btnControlMapping.Text = "Control Mapping";
            this.btnControlMapping.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnControlMapping.UseVisualStyleBackColor = true;
            this.btnControlMapping.Click += new System.EventHandler(this.btnControlMapping_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Max Party";
            // 
            // nudMaxParty
            // 
            this.nudMaxParty.Location = new System.Drawing.Point(82, 49);
            this.nudMaxParty.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaxParty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxParty.Name = "nudMaxParty";
            this.nudMaxParty.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMaxParty.OnChange = true;
            this.nudMaxParty.Size = new System.Drawing.Size(52, 20);
            this.nudMaxParty.TabIndex = 5;
            this.nudMaxParty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxParty.ValueChanged += new System.EventHandler(this.nudMaxParty_ValueChanged);
            this.nudMaxParty.Validated += new System.EventHandler(this.nudMaxParty_Validated);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.CanCollapse = false;
            this.impactGroupBox3.Controls.Add(this.partyList);
            this.impactGroupBox3.Controls.Add(this.toolStrip1);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Image = null;
            this.impactGroupBox3.IsCollapsed = false;
            this.impactGroupBox3.Location = new System.Drawing.Point(3, 0);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(164, 157);
            this.impactGroupBox3.TabIndex = 14;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Party List";
            // 
            // partyList
            // 
            this.partyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partyList.FullRowSelect = true;
            this.partyList.Location = new System.Drawing.Point(4, 50);
            this.partyList.Name = "partyList";
            this.partyList.ShowPlusMinus = false;
            this.partyList.ShowRootLines = false;
            this.partyList.Size = new System.Drawing.Size(156, 102);
            this.partyList.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddParty,
            this.btnRemoveParty,
            this.toolStripSeparator1,
            this.btnPartyUP,
            this.btnPartyDW});
            this.toolStrip1.Location = new System.Drawing.Point(4, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(156, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddParty
            // 
            this.btnAddParty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddParty.Image = ((System.Drawing.Image)(resources.GetObject("btnAddParty.Image")));
            this.btnAddParty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddParty.Name = "btnAddParty";
            this.btnAddParty.Size = new System.Drawing.Size(23, 22);
            this.btnAddParty.Text = "Add Member";
            this.btnAddParty.Click += new System.EventHandler(this.btnAddParty_Click);
            // 
            // btnRemoveParty
            // 
            this.btnRemoveParty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveParty.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveParty.Image")));
            this.btnRemoveParty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveParty.Name = "btnRemoveParty";
            this.btnRemoveParty.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveParty.Text = "Remove Member";
            this.btnRemoveParty.Click += new System.EventHandler(this.btnRemoveParty_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPartyUP
            // 
            this.btnPartyUP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPartyUP.Image = ((System.Drawing.Image)(resources.GetObject("btnPartyUP.Image")));
            this.btnPartyUP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPartyUP.Name = "btnPartyUP";
            this.btnPartyUP.Size = new System.Drawing.Size(23, 22);
            this.btnPartyUP.Text = "Move Up";
            this.btnPartyUP.Click += new System.EventHandler(this.btnPartyUP_Click);
            // 
            // btnPartyDW
            // 
            this.btnPartyDW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPartyDW.Image = ((System.Drawing.Image)(resources.GetObject("btnPartyDW.Image")));
            this.btnPartyDW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPartyDW.Name = "btnPartyDW";
            this.btnPartyDW.Size = new System.Drawing.Size(23, 22);
            this.btnPartyDW.Text = "Move Down";
            this.btnPartyDW.Click += new System.EventHandler(this.btnPartyDW_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.downRightBtn);
            this.impactGroupBox2.Controls.Add(this.upBtn);
            this.impactGroupBox2.Controls.Add(this.upRightBtn);
            this.impactGroupBox2.Controls.Add(this.upLeftBtn);
            this.impactGroupBox2.Controls.Add(this.downLeftBtn);
            this.impactGroupBox2.Controls.Add(this.rightBtn);
            this.impactGroupBox2.Controls.Add(this.leftBtn);
            this.impactGroupBox2.Controls.Add(this.downBtn);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(3, 367);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(141, 112);
            this.impactGroupBox2.TabIndex = 14;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Movement Directions";
            // 
            // downRightBtn
            // 
            this.downRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downRightBtn.AutoSize = true;
            this.downRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("downRightBtn.Image")));
            this.downRightBtn.Location = new System.Drawing.Point(86, 83);
            this.downRightBtn.Name = "downRightBtn";
            this.downRightBtn.Size = new System.Drawing.Size(22, 22);
            this.downRightBtn.TabIndex = 56;
            this.downRightBtn.UseVisualStyleBackColor = true;
            this.downRightBtn.CheckedChanged += new System.EventHandler(this.downRightBtn_CheckedChanged);
            // 
            // upBtn
            // 
            this.upBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upBtn.AutoSize = true;
            this.upBtn.Checked = true;
            this.upBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.upBtn.Image = ((System.Drawing.Image)(resources.GetObject("upBtn.Image")));
            this.upBtn.Location = new System.Drawing.Point(58, 27);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(22, 22);
            this.upBtn.TabIndex = 49;
            this.upBtn.UseVisualStyleBackColor = true;
            this.upBtn.CheckedChanged += new System.EventHandler(this.upBtn_CheckedChanged);
            // 
            // upRightBtn
            // 
            this.upRightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upRightBtn.AutoSize = true;
            this.upRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("upRightBtn.Image")));
            this.upRightBtn.Location = new System.Drawing.Point(86, 27);
            this.upRightBtn.Name = "upRightBtn";
            this.upRightBtn.Size = new System.Drawing.Size(22, 22);
            this.upRightBtn.TabIndex = 55;
            this.upRightBtn.UseVisualStyleBackColor = true;
            this.upRightBtn.CheckedChanged += new System.EventHandler(this.upRightBtn_CheckedChanged);
            // 
            // upLeftBtn
            // 
            this.upLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.upLeftBtn.AutoSize = true;
            this.upLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("upLeftBtn.Image")));
            this.upLeftBtn.Location = new System.Drawing.Point(32, 27);
            this.upLeftBtn.Name = "upLeftBtn";
            this.upLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.upLeftBtn.TabIndex = 54;
            this.upLeftBtn.UseVisualStyleBackColor = true;
            this.upLeftBtn.CheckedChanged += new System.EventHandler(this.upLeftBtn_CheckedChanged);
            // 
            // downLeftBtn
            // 
            this.downLeftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downLeftBtn.AutoSize = true;
            this.downLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("downLeftBtn.Image")));
            this.downLeftBtn.Location = new System.Drawing.Point(32, 83);
            this.downLeftBtn.Name = "downLeftBtn";
            this.downLeftBtn.Size = new System.Drawing.Size(22, 22);
            this.downLeftBtn.TabIndex = 53;
            this.downLeftBtn.UseVisualStyleBackColor = true;
            this.downLeftBtn.CheckedChanged += new System.EventHandler(this.downLeftBtn_CheckedChanged);
            // 
            // rightBtn
            // 
            this.rightBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rightBtn.AutoSize = true;
            this.rightBtn.Checked = true;
            this.rightBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightBtn.Image = ((System.Drawing.Image)(resources.GetObject("rightBtn.Image")));
            this.rightBtn.Location = new System.Drawing.Point(86, 55);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(22, 22);
            this.rightBtn.TabIndex = 52;
            this.rightBtn.UseVisualStyleBackColor = true;
            this.rightBtn.CheckedChanged += new System.EventHandler(this.rightBtn_CheckedChanged);
            // 
            // leftBtn
            // 
            this.leftBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.leftBtn.AutoSize = true;
            this.leftBtn.Checked = true;
            this.leftBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftBtn.Image = ((System.Drawing.Image)(resources.GetObject("leftBtn.Image")));
            this.leftBtn.Location = new System.Drawing.Point(32, 55);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(22, 22);
            this.leftBtn.TabIndex = 51;
            this.leftBtn.UseVisualStyleBackColor = true;
            this.leftBtn.CheckedChanged += new System.EventHandler(this.leftBtn_CheckedChanged);
            // 
            // downBtn
            // 
            this.downBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.downBtn.AutoSize = true;
            this.downBtn.Checked = true;
            this.downBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downBtn.Image = ((System.Drawing.Image)(resources.GetObject("downBtn.Image")));
            this.downBtn.Location = new System.Drawing.Point(58, 83);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(22, 22);
            this.downBtn.TabIndex = 50;
            this.downBtn.UseVisualStyleBackColor = true;
            this.downBtn.CheckedChanged += new System.EventHandler(this.downBtn_CheckedChanged);
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
            this.groupBox5.Location = new System.Drawing.Point(173, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(559, 647);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Program";
            // 
            // behaviorProgramListBox1
            // 
            this.behaviorProgramListBox1.BackColor = System.Drawing.Color.White;
            this.behaviorProgramListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.behaviorProgramListBox1.Location = new System.Drawing.Point(4, 25);
            this.behaviorProgramListBox1.Name = "behaviorProgramListBox1";
            this.behaviorProgramListBox1.SelectedAction = null;
            this.behaviorProgramListBox1.SelectedEvent = null;
            this.behaviorProgramListBox1.SelectedPage = null;
            this.behaviorProgramListBox1.Size = new System.Drawing.Size(551, 617);
            this.behaviorProgramListBox1.TabIndex = 0;
            // 
            // impactGroupBox5
            // 
            this.impactGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox5.CanCollapse = false;
            this.impactGroupBox5.Controls.Add(this.cbParticles);
            this.impactGroupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox5.Image = null;
            this.impactGroupBox5.IsCollapsed = false;
            this.impactGroupBox5.Location = new System.Drawing.Point(3, 118);
            this.impactGroupBox5.Name = "impactGroupBox5";
            this.impactGroupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox5.Size = new System.Drawing.Size(141, 56);
            this.impactGroupBox5.TabIndex = 15;
            this.impactGroupBox5.TabStop = false;
            this.impactGroupBox5.Text = "Particle System";
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
            this.cbParticles.Size = new System.Drawing.Size(124, 21);
            this.cbParticles.TabIndex = 1;
            this.cbParticles.SelectedIndexChanged += new System.EventHandler(this.cbParticles_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.impactGroupBox5);
            this.panel1.Controls.Add(this.impactGroupBox4);
            this.panel1.Controls.Add(this.impactGroupBox1);
            this.panel1.Controls.Add(this.impactGroupBox2);
            this.panel1.Location = new System.Drawing.Point(3, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 484);
            this.panel1.TabIndex = 1;
            // 
            // btnJoints
            // 
            this.btnJoints.Image = global::EGMGame.Properties.Resources.draw_vertex;
            this.btnJoints.Location = new System.Drawing.Point(7, 147);
            this.btnJoints.Name = "btnJoints";
            this.btnJoints.Size = new System.Drawing.Size(130, 27);
            this.btnJoints.TabIndex = 25;
            this.btnJoints.Text = "Attach Events";
            this.btnJoints.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnJoints.UseVisualStyleBackColor = true;
            this.btnJoints.Click += new System.EventHandler(this.btnJoints_Click);
            // 
            // PlayerPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.groupBox5);
            this.DoubleBuffered = true;
            this.Name = "PlayerPageControl";
            this.Size = new System.Drawing.Size(732, 647);
            this.EnabledChanged += new System.EventHandler(this.EventPageControl_EnabledChanged);
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).EndInit();
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxParty)).EndInit();
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.impactGroupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox5;
        private BehaviorProgramListBox behaviorProgramListBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.TreeView partyList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddParty;
        private System.Windows.Forms.ToolStripButton btnRemoveParty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPartyUP;
        private System.Windows.Forms.ToolStripButton btnPartyDW;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudMaxParty;
        private System.Windows.Forms.Button btnControlMapping;
        private System.Windows.Forms.CheckBox downBtn;
        private System.Windows.Forms.CheckBox leftBtn;
        private System.Windows.Forms.CheckBox rightBtn;
        private System.Windows.Forms.CheckBox downLeftBtn;
        private System.Windows.Forms.CheckBox upLeftBtn;
        private System.Windows.Forms.CheckBox upRightBtn;
        private System.Windows.Forms.CheckBox upBtn;
        private System.Windows.Forms.CheckBox downRightBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.CheckBox chkStatic;
        private CustomUpDown nudFreq;
        private System.Windows.Forms.CheckBox chFreqBox;
        private System.Windows.Forms.Button btnPhysics;
        private CustomUpDown nudSpeed;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cbDirections;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox5;
        private EGMGame.Controls.Game.ParticleComboBox cbParticles;
        private System.Windows.Forms.CheckBox chkSyncAngleToRotation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnJoints;
    }
}
