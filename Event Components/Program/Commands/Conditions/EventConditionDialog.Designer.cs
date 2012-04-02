namespace EGMGame
{
    partial class EventConditionDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.conditionsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbProjectiles = new EGMGame.Controls.Game.ProjectilesComboBox(this.components);
            this.rbIsCollidingProjectile = new System.Windows.Forms.RadioButton();
            this.cbCollidingEvents = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.rbIsColliding = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAtAngle2 = new EGMGame.CustomUpDown();
            this.nudAtAngle1 = new EGMGame.CustomUpDown();
            this.cbAtAngle = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.rbAtAngle = new System.Windows.Forms.RadioButton();
            this.cbTorqueOp = new System.Windows.Forms.ComboBox();
            this.cbPosOp = new System.Windows.Forms.ComboBox();
            this.cbForceOp = new System.Windows.Forms.ComboBox();
            this.nudTorque = new EGMGame.CustomUpDown();
            this.cbTorque = new System.Windows.Forms.ComboBox();
            this.rbTorque = new System.Windows.Forms.RadioButton();
            this.nudForceY = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudForceX = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbForce = new System.Windows.Forms.ComboBox();
            this.rbForceApplied = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAngle2 = new EGMGame.CustomUpDown();
            this.nudAngle1 = new EGMGame.CustomUpDown();
            this.rbAngle = new System.Windows.Forms.RadioButton();
            this.nudTag = new EGMGame.CustomUpDown();
            this.rbTileTag = new System.Windows.Forms.RadioButton();
            this.eventFacingList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.eventDirectionList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.eventRangeList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.rbIs = new System.Windows.Forms.RadioButton();
            this.rbPositionIs = new System.Windows.Forms.RadioButton();
            this.nudPosY = new EGMGame.CustomUpDown();
            this.rbDirection = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.nudPosX = new EGMGame.CustomUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.rbFacingEvent = new System.Windows.Forms.RadioButton();
            this.cbEventState = new System.Windows.Forms.ComboBox();
            this.rbInDirection = new System.Windows.Forms.RadioButton();
            this.rbInRange = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.nudRange = new EGMGame.CustomUpDown();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbCompare = new System.Windows.Forms.ComboBox();
            this.eventList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.conditionsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(315, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(234, 496);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 41;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(11, 475);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 90;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // conditionsBox
            // 
            this.conditionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.conditionsBox.CanCollapse = false;
            this.conditionsBox.Controls.Add(this.cbProjectiles);
            this.conditionsBox.Controls.Add(this.rbIsCollidingProjectile);
            this.conditionsBox.Controls.Add(this.cbCollidingEvents);
            this.conditionsBox.Controls.Add(this.rbIsColliding);
            this.conditionsBox.Controls.Add(this.label5);
            this.conditionsBox.Controls.Add(this.nudAtAngle2);
            this.conditionsBox.Controls.Add(this.nudAtAngle1);
            this.conditionsBox.Controls.Add(this.cbAtAngle);
            this.conditionsBox.Controls.Add(this.rbAtAngle);
            this.conditionsBox.Controls.Add(this.cbTorqueOp);
            this.conditionsBox.Controls.Add(this.cbPosOp);
            this.conditionsBox.Controls.Add(this.cbForceOp);
            this.conditionsBox.Controls.Add(this.nudTorque);
            this.conditionsBox.Controls.Add(this.cbTorque);
            this.conditionsBox.Controls.Add(this.rbTorque);
            this.conditionsBox.Controls.Add(this.nudForceY);
            this.conditionsBox.Controls.Add(this.label3);
            this.conditionsBox.Controls.Add(this.nudForceX);
            this.conditionsBox.Controls.Add(this.label4);
            this.conditionsBox.Controls.Add(this.cbForce);
            this.conditionsBox.Controls.Add(this.rbForceApplied);
            this.conditionsBox.Controls.Add(this.label2);
            this.conditionsBox.Controls.Add(this.nudAngle2);
            this.conditionsBox.Controls.Add(this.nudAngle1);
            this.conditionsBox.Controls.Add(this.rbAngle);
            this.conditionsBox.Controls.Add(this.nudTag);
            this.conditionsBox.Controls.Add(this.rbTileTag);
            this.conditionsBox.Controls.Add(this.eventFacingList);
            this.conditionsBox.Controls.Add(this.eventDirectionList);
            this.conditionsBox.Controls.Add(this.eventRangeList);
            this.conditionsBox.Controls.Add(this.rbIs);
            this.conditionsBox.Controls.Add(this.rbPositionIs);
            this.conditionsBox.Controls.Add(this.nudPosY);
            this.conditionsBox.Controls.Add(this.rbDirection);
            this.conditionsBox.Controls.Add(this.label19);
            this.conditionsBox.Controls.Add(this.cbDirection);
            this.conditionsBox.Controls.Add(this.nudPosX);
            this.conditionsBox.Controls.Add(this.label18);
            this.conditionsBox.Controls.Add(this.rbFacingEvent);
            this.conditionsBox.Controls.Add(this.cbEventState);
            this.conditionsBox.Controls.Add(this.rbInDirection);
            this.conditionsBox.Controls.Add(this.rbInRange);
            this.conditionsBox.Controls.Add(this.label25);
            this.conditionsBox.Controls.Add(this.nudRange);
            this.conditionsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.conditionsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.conditionsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.conditionsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.conditionsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.conditionsBox.Image = null;
            this.conditionsBox.IsCollapsed = false;
            this.conditionsBox.Location = new System.Drawing.Point(11, 91);
            this.conditionsBox.Name = "conditionsBox";
            this.conditionsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.conditionsBox.Size = new System.Drawing.Size(379, 378);
            this.conditionsBox.TabIndex = 86;
            this.conditionsBox.TabStop = false;
            this.conditionsBox.Text = "Conditions";
            // 
            // cbProjectiles
            // 
            this.cbProjectiles.AllowCategories = true;
            this.cbProjectiles.AllProjectiles = true;
            this.cbProjectiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProjectiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectiles.Enabled = false;
            this.cbProjectiles.FormattingEnabled = true;
            this.cbProjectiles.Location = new System.Drawing.Point(142, 294);
            this.cbProjectiles.Name = "cbProjectiles";
            this.cbProjectiles.Noneable = true;
            this.cbProjectiles.SelectedNode = null;
            this.cbProjectiles.Size = new System.Drawing.Size(106, 21);
            this.cbProjectiles.TabIndex = 117;
            // 
            // rbIsCollidingProjectile
            // 
            this.rbIsCollidingProjectile.AutoSize = true;
            this.rbIsCollidingProjectile.BackColor = System.Drawing.Color.Transparent;
            this.rbIsCollidingProjectile.Location = new System.Drawing.Point(7, 295);
            this.rbIsCollidingProjectile.Name = "rbIsCollidingProjectile";
            this.rbIsCollidingProjectile.Size = new System.Drawing.Size(121, 17);
            this.rbIsCollidingProjectile.TabIndex = 116;
            this.rbIsCollidingProjectile.Text = "Is Colliding Projectile";
            this.rbIsCollidingProjectile.UseVisualStyleBackColor = false;
            this.rbIsCollidingProjectile.CheckedChanged += new System.EventHandler(this.rbIsCollidingProjectile_CheckedChanged);
            // 
            // cbCollidingEvents
            // 
            this.cbCollidingEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCollidingEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCollidingEvents.Enabled = false;
            this.cbCollidingEvents.FormattingEnabled = true;
            this.cbCollidingEvents.Location = new System.Drawing.Point(142, 267);
            this.cbCollidingEvents.Name = "cbCollidingEvents";
            this.cbCollidingEvents.ShowPlayer = true;
            this.cbCollidingEvents.ShowTarget = true;
            this.cbCollidingEvents.ShowTargets = false;
            this.cbCollidingEvents.Size = new System.Drawing.Size(106, 21);
            this.cbCollidingEvents.TabIndex = 115;
            this.cbCollidingEvents.ThisEvent = false;
            // 
            // rbIsColliding
            // 
            this.rbIsColliding.AutoSize = true;
            this.rbIsColliding.BackColor = System.Drawing.Color.Transparent;
            this.rbIsColliding.Location = new System.Drawing.Point(7, 267);
            this.rbIsColliding.Name = "rbIsColliding";
            this.rbIsColliding.Size = new System.Drawing.Size(75, 17);
            this.rbIsColliding.TabIndex = 114;
            this.rbIsColliding.Text = "Is Colliding";
            this.rbIsColliding.UseVisualStyleBackColor = false;
            this.rbIsColliding.CheckedChanged += new System.EventHandler(this.rbIsColliding_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(306, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "~";
            // 
            // nudAtAngle2
            // 
            this.nudAtAngle2.Enabled = false;
            this.nudAtAngle2.Location = new System.Drawing.Point(326, 161);
            this.nudAtAngle2.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAtAngle2.Name = "nudAtAngle2";
            this.nudAtAngle2.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAtAngle2.OnChange = true;
            this.nudAtAngle2.Size = new System.Drawing.Size(46, 20);
            this.nudAtAngle2.TabIndex = 112;
            this.nudAtAngle2.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // nudAtAngle1
            // 
            this.nudAtAngle1.Enabled = false;
            this.nudAtAngle1.Location = new System.Drawing.Point(254, 161);
            this.nudAtAngle1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAtAngle1.Name = "nudAtAngle1";
            this.nudAtAngle1.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudAtAngle1.OnChange = false;
            this.nudAtAngle1.Size = new System.Drawing.Size(46, 20);
            this.nudAtAngle1.TabIndex = 111;
            // 
            // cbAtAngle
            // 
            this.cbAtAngle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAtAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtAngle.Enabled = false;
            this.cbAtAngle.FormattingEnabled = true;
            this.cbAtAngle.Location = new System.Drawing.Point(142, 160);
            this.cbAtAngle.Name = "cbAtAngle";
            this.cbAtAngle.ShowPlayer = true;
            this.cbAtAngle.ShowTarget = true;
            this.cbAtAngle.ShowTargets = false;
            this.cbAtAngle.Size = new System.Drawing.Size(106, 21);
            this.cbAtAngle.TabIndex = 110;
            this.cbAtAngle.ThisEvent = false;
            // 
            // rbAtAngle
            // 
            this.rbAtAngle.AutoSize = true;
            this.rbAtAngle.BackColor = System.Drawing.Color.Transparent;
            this.rbAtAngle.Location = new System.Drawing.Point(7, 161);
            this.rbAtAngle.Name = "rbAtAngle";
            this.rbAtAngle.Size = new System.Drawing.Size(124, 17);
            this.rbAtAngle.TabIndex = 109;
            this.rbAtAngle.Text = "At an angle on event";
            this.rbAtAngle.UseVisualStyleBackColor = false;
            this.rbAtAngle.CheckedChanged += new System.EventHandler(this.rbAtAngle_CheckedChanged);
            // 
            // cbTorqueOp
            // 
            this.cbTorqueOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTorqueOp.FormattingEnabled = true;
            this.cbTorqueOp.Items.AddRange(new object[] {
            "(=) Equals",
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals",
            "(!=) Does Not Equal"});
            this.cbTorqueOp.Location = new System.Drawing.Point(142, 240);
            this.cbTorqueOp.Name = "cbTorqueOp";
            this.cbTorqueOp.Size = new System.Drawing.Size(63, 21);
            this.cbTorqueOp.TabIndex = 108;
            // 
            // cbPosOp
            // 
            this.cbPosOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPosOp.FormattingEnabled = true;
            this.cbPosOp.Items.AddRange(new object[] {
            "(=) Equals",
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals",
            "(!=) Does Not Equal"});
            this.cbPosOp.Location = new System.Drawing.Point(141, 346);
            this.cbPosOp.Name = "cbPosOp";
            this.cbPosOp.Size = new System.Drawing.Size(63, 21);
            this.cbPosOp.TabIndex = 107;
            // 
            // cbForceOp
            // 
            this.cbForceOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForceOp.FormattingEnabled = true;
            this.cbForceOp.Items.AddRange(new object[] {
            "(=) Equals",
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals",
            "(!=) Does Not Equal"});
            this.cbForceOp.Location = new System.Drawing.Point(142, 213);
            this.cbForceOp.Name = "cbForceOp";
            this.cbForceOp.Size = new System.Drawing.Size(63, 21);
            this.cbForceOp.TabIndex = 106;
            // 
            // nudTorque
            // 
            this.nudTorque.DecimalPlaces = 3;
            this.nudTorque.Enabled = false;
            this.nudTorque.Location = new System.Drawing.Point(214, 241);
            this.nudTorque.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudTorque.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudTorque.Name = "nudTorque";
            this.nudTorque.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudTorque.OnChange = false;
            this.nudTorque.Size = new System.Drawing.Size(55, 20);
            this.nudTorque.TabIndex = 103;
            // 
            // cbTorque
            // 
            this.cbTorque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTorque.FormattingEnabled = true;
            this.cbTorque.Items.AddRange(new object[] {
            "Torque",
            "Angular Velocity"});
            this.cbTorque.Location = new System.Drawing.Point(25, 240);
            this.cbTorque.Name = "cbTorque";
            this.cbTorque.Size = new System.Drawing.Size(86, 21);
            this.cbTorque.TabIndex = 101;
            // 
            // rbTorque
            // 
            this.rbTorque.AutoSize = true;
            this.rbTorque.BackColor = System.Drawing.Color.Transparent;
            this.rbTorque.Location = new System.Drawing.Point(7, 244);
            this.rbTorque.Name = "rbTorque";
            this.rbTorque.Size = new System.Drawing.Size(14, 13);
            this.rbTorque.TabIndex = 100;
            this.rbTorque.UseVisualStyleBackColor = false;
            this.rbTorque.CheckedChanged += new System.EventHandler(this.rbTorque_CheckedChanged);
            // 
            // nudForceY
            // 
            this.nudForceY.DecimalPlaces = 3;
            this.nudForceY.Enabled = false;
            this.nudForceY.Location = new System.Drawing.Point(309, 213);
            this.nudForceY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudForceY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudForceY.Name = "nudForceY";
            this.nudForceY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudForceY.OnChange = false;
            this.nudForceY.Size = new System.Drawing.Size(55, 20);
            this.nudForceY.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(292, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Y";
            // 
            // nudForceX
            // 
            this.nudForceX.DecimalPlaces = 3;
            this.nudForceX.Enabled = false;
            this.nudForceX.Location = new System.Drawing.Point(231, 214);
            this.nudForceX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudForceX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudForceX.Name = "nudForceX";
            this.nudForceX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudForceX.OnChange = false;
            this.nudForceX.Size = new System.Drawing.Size(55, 20);
            this.nudForceX.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(211, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "X";
            // 
            // cbForce
            // 
            this.cbForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForce.FormattingEnabled = true;
            this.cbForce.Items.AddRange(new object[] {
            "Force",
            "Impulse",
            "Velocity"});
            this.cbForce.Location = new System.Drawing.Point(25, 213);
            this.cbForce.Name = "cbForce";
            this.cbForce.Size = new System.Drawing.Size(86, 21);
            this.cbForce.TabIndex = 95;
            // 
            // rbForceApplied
            // 
            this.rbForceApplied.AutoSize = true;
            this.rbForceApplied.BackColor = System.Drawing.Color.Transparent;
            this.rbForceApplied.Location = new System.Drawing.Point(7, 217);
            this.rbForceApplied.Name = "rbForceApplied";
            this.rbForceApplied.Size = new System.Drawing.Size(14, 13);
            this.rbForceApplied.TabIndex = 94;
            this.rbForceApplied.UseVisualStyleBackColor = false;
            this.rbForceApplied.CheckedChanged += new System.EventHandler(this.rbForceApplied_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(194, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "~";
            // 
            // nudAngle2
            // 
            this.nudAngle2.Enabled = false;
            this.nudAngle2.Location = new System.Drawing.Point(214, 81);
            this.nudAngle2.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngle2.Name = "nudAngle2";
            this.nudAngle2.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAngle2.OnChange = true;
            this.nudAngle2.Size = new System.Drawing.Size(46, 20);
            this.nudAngle2.TabIndex = 92;
            this.nudAngle2.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // nudAngle1
            // 
            this.nudAngle1.Enabled = false;
            this.nudAngle1.Location = new System.Drawing.Point(142, 81);
            this.nudAngle1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngle1.Name = "nudAngle1";
            this.nudAngle1.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudAngle1.OnChange = false;
            this.nudAngle1.Size = new System.Drawing.Size(46, 20);
            this.nudAngle1.TabIndex = 91;
            // 
            // rbAngle
            // 
            this.rbAngle.AutoSize = true;
            this.rbAngle.BackColor = System.Drawing.Color.Transparent;
            this.rbAngle.Location = new System.Drawing.Point(7, 81);
            this.rbAngle.Name = "rbAngle";
            this.rbAngle.Size = new System.Drawing.Size(106, 17);
            this.rbAngle.TabIndex = 90;
            this.rbAngle.Text = "Angle is between";
            this.rbAngle.UseVisualStyleBackColor = false;
            this.rbAngle.CheckedChanged += new System.EventHandler(this.rbAngle_CheckedChanged);
            // 
            // nudTag
            // 
            this.nudTag.Enabled = false;
            this.nudTag.Location = new System.Drawing.Point(142, 190);
            this.nudTag.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudTag.Name = "nudTag";
            this.nudTag.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudTag.OnChange = false;
            this.nudTag.Size = new System.Drawing.Size(43, 20);
            this.nudTag.TabIndex = 89;
            // 
            // rbTileTag
            // 
            this.rbTileTag.AutoSize = true;
            this.rbTileTag.BackColor = System.Drawing.Color.Transparent;
            this.rbTileTag.Location = new System.Drawing.Point(7, 190);
            this.rbTileTag.Name = "rbTileTag";
            this.rbTileTag.Size = new System.Drawing.Size(82, 17);
            this.rbTileTag.TabIndex = 88;
            this.rbTileTag.Text = "Is on tile tag";
            this.rbTileTag.UseVisualStyleBackColor = false;
            this.rbTileTag.CheckedChanged += new System.EventHandler(this.rbTileTag_CheckedChanged);
            // 
            // eventFacingList
            // 
            this.eventFacingList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventFacingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventFacingList.Enabled = false;
            this.eventFacingList.FormattingEnabled = true;
            this.eventFacingList.Location = new System.Drawing.Point(142, 133);
            this.eventFacingList.Name = "eventFacingList";
            this.eventFacingList.ShowPlayer = true;
            this.eventFacingList.ShowTarget = true;
            this.eventFacingList.ShowTargets = false;
            this.eventFacingList.Size = new System.Drawing.Size(106, 21);
            this.eventFacingList.TabIndex = 87;
            this.eventFacingList.ThisEvent = false;
            // 
            // eventDirectionList
            // 
            this.eventDirectionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventDirectionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventDirectionList.Enabled = false;
            this.eventDirectionList.FormattingEnabled = true;
            this.eventDirectionList.Location = new System.Drawing.Point(142, 107);
            this.eventDirectionList.Name = "eventDirectionList";
            this.eventDirectionList.ShowPlayer = true;
            this.eventDirectionList.ShowTarget = true;
            this.eventDirectionList.ShowTargets = false;
            this.eventDirectionList.Size = new System.Drawing.Size(106, 21);
            this.eventDirectionList.TabIndex = 86;
            this.eventDirectionList.ThisEvent = false;
            // 
            // eventRangeList
            // 
            this.eventRangeList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventRangeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventRangeList.Enabled = false;
            this.eventRangeList.FormattingEnabled = true;
            this.eventRangeList.Location = new System.Drawing.Point(142, 321);
            this.eventRangeList.Name = "eventRangeList";
            this.eventRangeList.ShowPlayer = true;
            this.eventRangeList.ShowTarget = true;
            this.eventRangeList.ShowTargets = false;
            this.eventRangeList.Size = new System.Drawing.Size(106, 21);
            this.eventRangeList.TabIndex = 85;
            this.eventRangeList.ThisEvent = false;
            // 
            // rbIs
            // 
            this.rbIs.AutoSize = true;
            this.rbIs.BackColor = System.Drawing.Color.Transparent;
            this.rbIs.Checked = true;
            this.rbIs.Location = new System.Drawing.Point(7, 28);
            this.rbIs.Name = "rbIs";
            this.rbIs.Size = new System.Drawing.Size(33, 17);
            this.rbIs.TabIndex = 67;
            this.rbIs.TabStop = true;
            this.rbIs.Text = "Is";
            this.rbIs.UseVisualStyleBackColor = false;
            this.rbIs.CheckedChanged += new System.EventHandler(this.rbIs_CheckedChanged);
            // 
            // rbPositionIs
            // 
            this.rbPositionIs.AutoSize = true;
            this.rbPositionIs.BackColor = System.Drawing.Color.Transparent;
            this.rbPositionIs.Location = new System.Drawing.Point(7, 349);
            this.rbPositionIs.Name = "rbPositionIs";
            this.rbPositionIs.Size = new System.Drawing.Size(72, 17);
            this.rbPositionIs.TabIndex = 66;
            this.rbPositionIs.Text = "Position is";
            this.rbPositionIs.UseVisualStyleBackColor = false;
            this.rbPositionIs.CheckedChanged += new System.EventHandler(this.rbPositionIs_CheckedChanged);
            // 
            // nudPosY
            // 
            this.nudPosY.Enabled = false;
            this.nudPosY.Location = new System.Drawing.Point(301, 346);
            this.nudPosY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudPosY.Name = "nudPosY";
            this.nudPosY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPosY.OnChange = false;
            this.nudPosY.Size = new System.Drawing.Size(44, 20);
            this.nudPosY.TabIndex = 70;
            // 
            // rbDirection
            // 
            this.rbDirection.AutoSize = true;
            this.rbDirection.BackColor = System.Drawing.Color.Transparent;
            this.rbDirection.Location = new System.Drawing.Point(7, 54);
            this.rbDirection.Name = "rbDirection";
            this.rbDirection.Size = new System.Drawing.Size(67, 17);
            this.rbDirection.TabIndex = 64;
            this.rbDirection.Text = "Direction";
            this.rbDirection.UseVisualStyleBackColor = false;
            this.rbDirection.CheckedChanged += new System.EventHandler(this.rbDirection_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(281, 348);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 13);
            this.label19.TabIndex = 69;
            this.label19.Text = "Y";
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.Enabled = false;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right",
            "Up/Left",
            "Up/Right",
            "Down/Left",
            "Down/Right"});
            this.cbDirection.Location = new System.Drawing.Point(142, 53);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(106, 21);
            this.cbDirection.TabIndex = 65;
            // 
            // nudPosX
            // 
            this.nudPosX.Enabled = false;
            this.nudPosX.Location = new System.Drawing.Point(230, 346);
            this.nudPosX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudPosX.Name = "nudPosX";
            this.nudPosX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPosX.OnChange = false;
            this.nudPosX.Size = new System.Drawing.Size(46, 20);
            this.nudPosX.TabIndex = 68;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(210, 349);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 63;
            this.label18.Text = "X";
            // 
            // rbFacingEvent
            // 
            this.rbFacingEvent.AutoSize = true;
            this.rbFacingEvent.BackColor = System.Drawing.Color.Transparent;
            this.rbFacingEvent.Location = new System.Drawing.Point(7, 134);
            this.rbFacingEvent.Name = "rbFacingEvent";
            this.rbFacingEvent.Size = new System.Drawing.Size(87, 17);
            this.rbFacingEvent.TabIndex = 83;
            this.rbFacingEvent.Text = "Facing event";
            this.rbFacingEvent.UseVisualStyleBackColor = false;
            this.rbFacingEvent.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // cbEventState
            // 
            this.cbEventState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEventState.FormattingEnabled = true;
            this.cbEventState.Items.AddRange(new object[] {
            "Activated",
            "Deactivated",
            "Moving",
            "Jumping",
            "Idle",
            "Colliding"});
            this.cbEventState.Location = new System.Drawing.Point(142, 28);
            this.cbEventState.Name = "cbEventState";
            this.cbEventState.Size = new System.Drawing.Size(84, 21);
            this.cbEventState.TabIndex = 81;
            // 
            // rbInDirection
            // 
            this.rbInDirection.AutoSize = true;
            this.rbInDirection.BackColor = System.Drawing.Color.Transparent;
            this.rbInDirection.Location = new System.Drawing.Point(7, 107);
            this.rbInDirection.Name = "rbInDirection";
            this.rbInDirection.Size = new System.Drawing.Size(129, 17);
            this.rbInDirection.TabIndex = 77;
            this.rbInDirection.Text = "In direction with event";
            this.rbInDirection.UseVisualStyleBackColor = false;
            this.rbInDirection.CheckedChanged += new System.EventHandler(this.rbInDirection_CheckedChanged);
            // 
            // rbInRange
            // 
            this.rbInRange.AutoSize = true;
            this.rbInRange.BackColor = System.Drawing.Color.Transparent;
            this.rbInRange.Location = new System.Drawing.Point(7, 321);
            this.rbInRange.Name = "rbInRange";
            this.rbInRange.Size = new System.Drawing.Size(106, 17);
            this.rbInRange.TabIndex = 72;
            this.rbInRange.Text = "In range of event";
            this.rbInRange.UseVisualStyleBackColor = false;
            this.rbInRange.CheckedChanged += new System.EventHandler(this.rbInRange_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(254, 323);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 13);
            this.label25.TabIndex = 74;
            this.label25.Text = "Range";
            this.label25.Visible = false;
            // 
            // nudRange
            // 
            this.nudRange.Enabled = false;
            this.nudRange.Location = new System.Drawing.Point(301, 321);
            this.nudRange.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRange.Name = "nudRange";
            this.nudRange.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudRange.OnChange = false;
            this.nudRange.Size = new System.Drawing.Size(43, 20);
            this.nudRange.TabIndex = 73;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.cbCompare);
            this.impactGroupBox1.Controls.Add(this.eventList);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(11, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(379, 73);
            this.impactGroupBox1.TabIndex = 85;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Event";
            // 
            // cbCompare
            // 
            this.cbCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompare.FormattingEnabled = true;
            this.cbCompare.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Not Equals"});
            this.cbCompare.Location = new System.Drawing.Point(142, 44);
            this.cbCompare.Name = "cbCompare";
            this.cbCompare.Size = new System.Drawing.Size(84, 21);
            this.cbCompare.TabIndex = 94;
            // 
            // eventList
            // 
            this.eventList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventList.FormattingEnabled = true;
            this.eventList.Location = new System.Drawing.Point(10, 44);
            this.eventList.Name = "eventList";
            this.eventList.ShowPlayer = true;
            this.eventList.ShowTarget = true;
            this.eventList.ShowTargets = false;
            this.eventList.Size = new System.Drawing.Size(119, 21);
            this.eventList.TabIndex = 1;
            this.eventList.ThisEvent = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the event for the condition.";
            // 
            // EventConditionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(402, 531);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.conditionsBox);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event Condition";
            this.conditionsBox.ResumeLayout(false);
            this.conditionsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.Game.MapEventComboBox eventList;
        private CustomUpDown nudRange;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.RadioButton rbInRange;
        private System.Windows.Forms.RadioButton rbInDirection;
        private System.Windows.Forms.ComboBox cbEventState;
        private System.Windows.Forms.RadioButton rbFacingEvent;
        private System.Windows.Forms.Label label18;
        private CustomUpDown nudPosX;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton rbDirection;
        private CustomUpDown nudPosY;
        private System.Windows.Forms.RadioButton rbPositionIs;
        private System.Windows.Forms.RadioButton rbIs;
        private EGMGame.Controls.Game.MapEventComboBox eventRangeList;
        private EGMGame.Controls.Game.MapEventComboBox eventDirectionList;
        private EGMGame.Controls.Game.MapEventComboBox eventFacingList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox conditionsBox;
        private CustomUpDown nudTag;
        private System.Windows.Forms.RadioButton rbTileTag;
        private System.Windows.Forms.CheckBox elseBranc;
        private System.Windows.Forms.RadioButton rbAngle;
        private CustomUpDown nudAngle1;
        private System.Windows.Forms.Label label2;
        private CustomUpDown nudAngle2;
        private System.Windows.Forms.ComboBox cbCompare;
        private CustomUpDown nudTorque;
        private System.Windows.Forms.ComboBox cbTorque;
        private System.Windows.Forms.RadioButton rbTorque;
        private CustomUpDown nudForceY;
        private System.Windows.Forms.Label label3;
        private CustomUpDown nudForceX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbForce;
        private System.Windows.Forms.RadioButton rbForceApplied;
        private System.Windows.Forms.ComboBox cbForceOp;
        private System.Windows.Forms.ComboBox cbPosOp;
        private System.Windows.Forms.ComboBox cbTorqueOp;
        private System.Windows.Forms.Label label5;
        private CustomUpDown nudAtAngle2;
        private CustomUpDown nudAtAngle1;
        private Controls.Game.MapEventComboBox cbAtAngle;
        private System.Windows.Forms.RadioButton rbAtAngle;
        private Controls.Game.MapEventComboBox cbCollidingEvents;
        private System.Windows.Forms.RadioButton rbIsColliding;
        private System.Windows.Forms.RadioButton rbIsCollidingProjectile;
        private Controls.Game.ProjectilesComboBox cbProjectiles;
    }
}