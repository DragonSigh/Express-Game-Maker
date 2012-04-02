using Microsoft.Xna.Framework;
using EGMGame.Controls;
using EGMGame.Controls.Game;
namespace EGMGame
{
    partial class JointsDialog
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
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbAttachment = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.boxRevolute = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkRevSyncDir = new System.Windows.Forms.CheckBox();
            this.chkRevAutoCorrectPos = new System.Windows.Forms.CheckBox();
            this.chkRevSensor = new System.Windows.Forms.CheckBox();
            this.nudRevLowLim = new System.Windows.Forms.NumericUpDown();
            this.nudRevUpLim = new System.Windows.Forms.NumericUpDown();
            this.nudRevMotTorq = new System.Windows.Forms.NumericUpDown();
            this.nudRevMotSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudRevOJPY = new System.Windows.Forms.NumericUpDown();
            this.nudRevOJPX = new System.Windows.Forms.NumericUpDown();
            this.nudRevAJPY = new System.Windows.Forms.NumericUpDown();
            this.nudRevAJPX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkRevCollide = new System.Windows.Forms.CheckBox();
            this.chkRevAngleLimit = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkRevEnableMotor = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkLineSyncDirection = new System.Windows.Forms.CheckBox();
            this.chkLineSyncPos = new System.Windows.Forms.CheckBox();
            this.chkLineSensor = new System.Windows.Forms.CheckBox();
            this.chkLineCollide = new System.Windows.Forms.CheckBox();
            this.chkDisSyncDir = new System.Windows.Forms.CheckBox();
            this.chkDisSyncPos = new System.Windows.Forms.CheckBox();
            this.chkDisSensor = new System.Windows.Forms.CheckBox();
            this.chkDisCollide = new System.Windows.Forms.CheckBox();
            this.boxLine = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.nudLineFreq = new System.Windows.Forms.NumericUpDown();
            this.nudLineDampingRatio = new System.Windows.Forms.NumericUpDown();
            this.nudLineTorque = new System.Windows.Forms.NumericUpDown();
            this.nudLineMSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudLineAxisY = new System.Windows.Forms.NumericUpDown();
            this.nudLineAxisX = new System.Windows.Forms.NumericUpDown();
            this.nudLineAJPY = new System.Windows.Forms.NumericUpDown();
            this.nudLineAJPX = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chkLineEnableMotor = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.boxDistance = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.nudDisDistance = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.nudDisBreakpoint = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.nudDisFreq = new System.Windows.Forms.NumericUpDown();
            this.nudDisDampingRatio = new System.Windows.Forms.NumericUpDown();
            this.nudDisOJPY = new System.Windows.Forms.NumericUpDown();
            this.nudDisOJPX = new System.Windows.Forms.NumericUpDown();
            this.nudDisAJPY = new System.Windows.Forms.NumericUpDown();
            this.nudDisAJPX = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            this.boxRevolute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevLowLim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevUpLim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevMotTorq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevMotSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevOJPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevOJPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevAJPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevAJPX)).BeginInit();
            this.boxLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineDampingRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineTorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineMSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAxisY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAxisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAJPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAJPX)).BeginInit();
            this.boxDistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisBreakpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisDampingRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisOJPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisOJPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisAJPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisAJPX)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(386, 489);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(305, 489);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 14;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = false;
            this.addRemoveList.AllowClipboard = false;
            this.addRemoveList.AllowMenu = true;
            this.addRemoveList.AllowRemove = true;
            this.addRemoveList.AllowRename = false;
            this.addRemoveList.DisplayToolbar = true;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.Export = false;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Import = false;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = false;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(143, 469);
            this.addRemoveList.TabIndex = 16;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.addRemoveList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(151, 499);
            this.impactGroupBox1.TabIndex = 17;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Attachments";
            // 
            // cbAttachment
            // 
            this.cbAttachment.AllowCategories = true;
            this.cbAttachment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAttachment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttachment.FormattingEnabled = true;
            this.cbAttachment.Location = new System.Drawing.Point(172, 28);
            this.cbAttachment.Name = "cbAttachment";
            this.cbAttachment.SelectedNode = null;
            this.cbAttachment.Size = new System.Drawing.Size(149, 21);
            this.cbAttachment.TabIndex = 18;
            this.cbAttachment.SelectedIndexChanged += new System.EventHandler(this.cbAttachment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Event to Attach";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Attachment Type";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Revolute",
            "Line",
            "Distance"});
            this.cbType.Location = new System.Drawing.Point(172, 68);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(125, 21);
            this.cbType.TabIndex = 21;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // boxRevolute
            // 
            this.boxRevolute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.boxRevolute.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.boxRevolute.CanCollapse = false;
            this.boxRevolute.Controls.Add(this.chkRevSyncDir);
            this.boxRevolute.Controls.Add(this.chkRevAutoCorrectPos);
            this.boxRevolute.Controls.Add(this.chkRevSensor);
            this.boxRevolute.Controls.Add(this.nudRevLowLim);
            this.boxRevolute.Controls.Add(this.nudRevUpLim);
            this.boxRevolute.Controls.Add(this.nudRevMotTorq);
            this.boxRevolute.Controls.Add(this.nudRevMotSpeed);
            this.boxRevolute.Controls.Add(this.nudRevOJPY);
            this.boxRevolute.Controls.Add(this.nudRevOJPX);
            this.boxRevolute.Controls.Add(this.nudRevAJPY);
            this.boxRevolute.Controls.Add(this.nudRevAJPX);
            this.boxRevolute.Controls.Add(this.label10);
            this.boxRevolute.Controls.Add(this.label5);
            this.boxRevolute.Controls.Add(this.chkRevCollide);
            this.boxRevolute.Controls.Add(this.chkRevAngleLimit);
            this.boxRevolute.Controls.Add(this.label8);
            this.boxRevolute.Controls.Add(this.label9);
            this.boxRevolute.Controls.Add(this.chkRevEnableMotor);
            this.boxRevolute.Controls.Add(this.label7);
            this.boxRevolute.Controls.Add(this.label6);
            this.boxRevolute.Controls.Add(this.label4);
            this.boxRevolute.Controls.Add(this.label3);
            this.boxRevolute.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.boxRevolute.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.boxRevolute.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.boxRevolute.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.boxRevolute.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.boxRevolute.Image = null;
            this.boxRevolute.IsCollapsed = false;
            this.boxRevolute.Location = new System.Drawing.Point(173, 95);
            this.boxRevolute.Name = "boxRevolute";
            this.boxRevolute.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.boxRevolute.Size = new System.Drawing.Size(285, 382);
            this.boxRevolute.TabIndex = 22;
            this.boxRevolute.TabStop = false;
            this.boxRevolute.Text = "Attachment Settings";
            this.boxRevolute.Visible = false;
            // 
            // chkRevSyncDir
            // 
            this.chkRevSyncDir.AutoSize = true;
            this.chkRevSyncDir.BackColor = System.Drawing.Color.Transparent;
            this.chkRevSyncDir.Location = new System.Drawing.Point(7, 353);
            this.chkRevSyncDir.Name = "chkRevSyncDir";
            this.chkRevSyncDir.Size = new System.Drawing.Size(129, 17);
            this.chkRevSyncDir.TabIndex = 63;
            this.chkRevSyncDir.Text = "Synchronize Direction";
            this.toolTip1.SetToolTip(this.chkRevSyncDir, "If checked, the attachment will face the same Direction\r\nas the owner.");
            this.chkRevSyncDir.UseVisualStyleBackColor = false;
            this.chkRevSyncDir.CheckedChanged += new System.EventHandler(this.chkRevSyncDir_CheckedChanged);
            // 
            // chkRevAutoCorrectPos
            // 
            this.chkRevAutoCorrectPos.AutoSize = true;
            this.chkRevAutoCorrectPos.BackColor = System.Drawing.Color.Transparent;
            this.chkRevAutoCorrectPos.Location = new System.Drawing.Point(7, 330);
            this.chkRevAutoCorrectPos.Name = "chkRevAutoCorrectPos";
            this.chkRevAutoCorrectPos.Size = new System.Drawing.Size(124, 17);
            this.chkRevAutoCorrectPos.TabIndex = 62;
            this.chkRevAutoCorrectPos.Text = "Synchronize Position";
            this.toolTip1.SetToolTip(this.chkRevAutoCorrectPos, "If checked, the attachment will try to stick to the owner.");
            this.chkRevAutoCorrectPos.UseVisualStyleBackColor = false;
            this.chkRevAutoCorrectPos.CheckedChanged += new System.EventHandler(this.chkRevAutoCorrectPos_CheckedChanged);
            // 
            // chkRevSensor
            // 
            this.chkRevSensor.AutoSize = true;
            this.chkRevSensor.BackColor = System.Drawing.Color.Transparent;
            this.chkRevSensor.Location = new System.Drawing.Point(8, 307);
            this.chkRevSensor.Name = "chkRevSensor";
            this.chkRevSensor.Size = new System.Drawing.Size(59, 17);
            this.chkRevSensor.TabIndex = 61;
            this.chkRevSensor.Text = "Sensor";
            this.toolTip1.SetToolTip(this.chkRevSensor, "If checked, the attachment will not effect the physical state of\r\nthe main body s" +
        "uch as mass and velocity.");
            this.chkRevSensor.UseVisualStyleBackColor = false;
            this.chkRevSensor.CheckedChanged += new System.EventHandler(this.chkRevSensor_CheckedChanged);
            // 
            // nudRevLowLim
            // 
            this.nudRevLowLim.Location = new System.Drawing.Point(150, 274);
            this.nudRevLowLim.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevLowLim.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevLowLim.Name = "nudRevLowLim";
            this.nudRevLowLim.Size = new System.Drawing.Size(69, 20);
            this.nudRevLowLim.TabIndex = 60;
            this.nudRevLowLim.ValueChanged += new System.EventHandler(this.nudRevLowLim_ValueChanged);
            // 
            // nudRevUpLim
            // 
            this.nudRevUpLim.Location = new System.Drawing.Point(150, 251);
            this.nudRevUpLim.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevUpLim.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevUpLim.Name = "nudRevUpLim";
            this.nudRevUpLim.Size = new System.Drawing.Size(69, 20);
            this.nudRevUpLim.TabIndex = 59;
            this.nudRevUpLim.ValueChanged += new System.EventHandler(this.nudRevUpLim_ValueChanged);
            // 
            // nudRevMotTorq
            // 
            this.nudRevMotTorq.DecimalPlaces = 2;
            this.nudRevMotTorq.Location = new System.Drawing.Point(150, 187);
            this.nudRevMotTorq.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevMotTorq.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevMotTorq.Name = "nudRevMotTorq";
            this.nudRevMotTorq.Size = new System.Drawing.Size(69, 20);
            this.nudRevMotTorq.TabIndex = 58;
            this.nudRevMotTorq.ValueChanged += new System.EventHandler(this.nudRevMotTorq_ValueChanged);
            // 
            // nudRevMotSpeed
            // 
            this.nudRevMotSpeed.DecimalPlaces = 2;
            this.nudRevMotSpeed.Location = new System.Drawing.Point(150, 164);
            this.nudRevMotSpeed.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevMotSpeed.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevMotSpeed.Name = "nudRevMotSpeed";
            this.nudRevMotSpeed.Size = new System.Drawing.Size(69, 20);
            this.nudRevMotSpeed.TabIndex = 57;
            this.nudRevMotSpeed.ValueChanged += new System.EventHandler(this.nudRevMotSpeed_ValueChanged);
            // 
            // nudRevOJPY
            // 
            this.nudRevOJPY.DecimalPlaces = 2;
            this.nudRevOJPY.Location = new System.Drawing.Point(216, 72);
            this.nudRevOJPY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevOJPY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevOJPY.Name = "nudRevOJPY";
            this.nudRevOJPY.Size = new System.Drawing.Size(60, 20);
            this.nudRevOJPY.TabIndex = 56;
            this.nudRevOJPY.ValueChanged += new System.EventHandler(this.nudRevOJPY_ValueChanged);
            // 
            // nudRevOJPX
            // 
            this.nudRevOJPX.DecimalPlaces = 2;
            this.nudRevOJPX.Location = new System.Drawing.Point(150, 72);
            this.nudRevOJPX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevOJPX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevOJPX.Name = "nudRevOJPX";
            this.nudRevOJPX.Size = new System.Drawing.Size(60, 20);
            this.nudRevOJPX.TabIndex = 55;
            this.nudRevOJPX.ValueChanged += new System.EventHandler(this.nudRevOJPX_ValueChanged);
            // 
            // nudRevAJPY
            // 
            this.nudRevAJPY.DecimalPlaces = 2;
            this.nudRevAJPY.Location = new System.Drawing.Point(216, 46);
            this.nudRevAJPY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevAJPY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevAJPY.Name = "nudRevAJPY";
            this.nudRevAJPY.Size = new System.Drawing.Size(60, 20);
            this.nudRevAJPY.TabIndex = 54;
            this.nudRevAJPY.ValueChanged += new System.EventHandler(this.nudRevAJPY_ValueChanged);
            // 
            // nudRevAJPX
            // 
            this.nudRevAJPX.DecimalPlaces = 2;
            this.nudRevAJPX.Location = new System.Drawing.Point(150, 46);
            this.nudRevAJPX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRevAJPX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudRevAJPX.Name = "nudRevAJPX";
            this.nudRevAJPX.Size = new System.Drawing.Size(60, 20);
            this.nudRevAJPX.TabIndex = 53;
            this.nudRevAJPX.ValueChanged += new System.EventHandler(this.nudRevAJPX_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(162, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(239, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Y";
            // 
            // chkRevCollide
            // 
            this.chkRevCollide.AutoSize = true;
            this.chkRevCollide.BackColor = System.Drawing.Color.Transparent;
            this.chkRevCollide.Location = new System.Drawing.Point(8, 113);
            this.chkRevCollide.Name = "chkRevCollide";
            this.chkRevCollide.Size = new System.Drawing.Size(148, 17);
            this.chkRevCollide.TabIndex = 50;
            this.chkRevCollide.Text = "Collide Connected Events";
            this.toolTip1.SetToolTip(this.chkRevCollide, "If checked, the attachment can collide with the main body.\r\nIf Sensor is checked," +
        " this effect will be neglected.");
            this.chkRevCollide.UseVisualStyleBackColor = false;
            this.chkRevCollide.CheckedChanged += new System.EventHandler(this.chkRevCollide_CheckedChanged);
            // 
            // chkRevAngleLimit
            // 
            this.chkRevAngleLimit.AutoSize = true;
            this.chkRevAngleLimit.BackColor = System.Drawing.Color.Transparent;
            this.chkRevAngleLimit.Location = new System.Drawing.Point(8, 223);
            this.chkRevAngleLimit.Name = "chkRevAngleLimit";
            this.chkRevAngleLimit.Size = new System.Drawing.Size(113, 17);
            this.chkRevAngleLimit.TabIndex = 49;
            this.chkRevAngleLimit.Text = "Enable Angle Limit";
            this.chkRevAngleLimit.UseVisualStyleBackColor = false;
            this.chkRevAngleLimit.CheckedChanged += new System.EventHandler(this.chkRevAngleLimit_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(5, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Lower Limit (degrees)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(5, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Upper Limit (degrees)";
            // 
            // chkRevEnableMotor
            // 
            this.chkRevEnableMotor.AutoSize = true;
            this.chkRevEnableMotor.BackColor = System.Drawing.Color.Transparent;
            this.chkRevEnableMotor.Location = new System.Drawing.Point(8, 136);
            this.chkRevEnableMotor.Name = "chkRevEnableMotor";
            this.chkRevEnableMotor.Size = new System.Drawing.Size(89, 17);
            this.chkRevEnableMotor.TabIndex = 46;
            this.chkRevEnableMotor.Text = "Enable Motor";
            this.chkRevEnableMotor.UseVisualStyleBackColor = false;
            this.chkRevEnableMotor.CheckedChanged += new System.EventHandler(this.chkRevEnableMotor_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Motor Torque";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(5, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Motor Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(9, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Owner Joint Position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Attachment Joint Anchor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(327, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 26);
            this.label11.TabIndex = 61;
            this.label11.Text = "Only Events with a collision\r\nbox will attach.";
            // 
            // chkLineSyncDirection
            // 
            this.chkLineSyncDirection.AutoSize = true;
            this.chkLineSyncDirection.BackColor = System.Drawing.Color.Transparent;
            this.chkLineSyncDirection.Location = new System.Drawing.Point(6, 320);
            this.chkLineSyncDirection.Name = "chkLineSyncDirection";
            this.chkLineSyncDirection.Size = new System.Drawing.Size(129, 17);
            this.chkLineSyncDirection.TabIndex = 63;
            this.chkLineSyncDirection.Text = "Synchronize Direction";
            this.toolTip1.SetToolTip(this.chkLineSyncDirection, "If checked, the attachment will face the same Direction\r\nas the owner.");
            this.chkLineSyncDirection.UseVisualStyleBackColor = false;
            this.chkLineSyncDirection.CheckedChanged += new System.EventHandler(this.chkLineSyncDirection_CheckedChanged);
            // 
            // chkLineSyncPos
            // 
            this.chkLineSyncPos.AutoSize = true;
            this.chkLineSyncPos.BackColor = System.Drawing.Color.Transparent;
            this.chkLineSyncPos.Location = new System.Drawing.Point(6, 297);
            this.chkLineSyncPos.Name = "chkLineSyncPos";
            this.chkLineSyncPos.Size = new System.Drawing.Size(124, 17);
            this.chkLineSyncPos.TabIndex = 62;
            this.chkLineSyncPos.Text = "Synchronize Position";
            this.toolTip1.SetToolTip(this.chkLineSyncPos, "If checked, the attachment will try to stick to the owner.");
            this.chkLineSyncPos.UseVisualStyleBackColor = false;
            this.chkLineSyncPos.CheckedChanged += new System.EventHandler(this.chkLineSyncPos_CheckedChanged);
            // 
            // chkLineSensor
            // 
            this.chkLineSensor.AutoSize = true;
            this.chkLineSensor.BackColor = System.Drawing.Color.Transparent;
            this.chkLineSensor.Location = new System.Drawing.Point(7, 274);
            this.chkLineSensor.Name = "chkLineSensor";
            this.chkLineSensor.Size = new System.Drawing.Size(59, 17);
            this.chkLineSensor.TabIndex = 61;
            this.chkLineSensor.Text = "Sensor";
            this.toolTip1.SetToolTip(this.chkLineSensor, "If checked, the attachment will not effect the physical state of\r\nthe main body s" +
        "uch as mass and velocity.");
            this.chkLineSensor.UseVisualStyleBackColor = false;
            this.chkLineSensor.CheckedChanged += new System.EventHandler(this.chkLineSensor_CheckedChanged);
            // 
            // chkLineCollide
            // 
            this.chkLineCollide.AutoSize = true;
            this.chkLineCollide.BackColor = System.Drawing.Color.Transparent;
            this.chkLineCollide.Location = new System.Drawing.Point(8, 113);
            this.chkLineCollide.Name = "chkLineCollide";
            this.chkLineCollide.Size = new System.Drawing.Size(148, 17);
            this.chkLineCollide.TabIndex = 50;
            this.chkLineCollide.Text = "Collide Connected Events";
            this.toolTip1.SetToolTip(this.chkLineCollide, "If checked, the attachment can collide with the main body.\r\nIf Sensor is checked," +
        " this effect will be neglected.");
            this.chkLineCollide.UseVisualStyleBackColor = false;
            this.chkLineCollide.CheckedChanged += new System.EventHandler(this.chkLineCollide_CheckedChanged);
            // 
            // chkDisSyncDir
            // 
            this.chkDisSyncDir.AutoSize = true;
            this.chkDisSyncDir.BackColor = System.Drawing.Color.Transparent;
            this.chkDisSyncDir.Location = new System.Drawing.Point(6, 294);
            this.chkDisSyncDir.Name = "chkDisSyncDir";
            this.chkDisSyncDir.Size = new System.Drawing.Size(129, 17);
            this.chkDisSyncDir.TabIndex = 63;
            this.chkDisSyncDir.Text = "Synchronize Direction";
            this.toolTip1.SetToolTip(this.chkDisSyncDir, "If checked, the attachment will face the same Direction\r\nas the owner.");
            this.chkDisSyncDir.UseVisualStyleBackColor = false;
            this.chkDisSyncDir.CheckedChanged += new System.EventHandler(this.chkDisSyncDir_CheckedChanged);
            // 
            // chkDisSyncPos
            // 
            this.chkDisSyncPos.AutoSize = true;
            this.chkDisSyncPos.BackColor = System.Drawing.Color.Transparent;
            this.chkDisSyncPos.Location = new System.Drawing.Point(6, 271);
            this.chkDisSyncPos.Name = "chkDisSyncPos";
            this.chkDisSyncPos.Size = new System.Drawing.Size(124, 17);
            this.chkDisSyncPos.TabIndex = 62;
            this.chkDisSyncPos.Text = "Synchronize Position";
            this.toolTip1.SetToolTip(this.chkDisSyncPos, "If checked, the attachment will try to stick to the owner.");
            this.chkDisSyncPos.UseVisualStyleBackColor = false;
            this.chkDisSyncPos.CheckedChanged += new System.EventHandler(this.chkDisSyncPos_CheckedChanged);
            // 
            // chkDisSensor
            // 
            this.chkDisSensor.AutoSize = true;
            this.chkDisSensor.BackColor = System.Drawing.Color.Transparent;
            this.chkDisSensor.Location = new System.Drawing.Point(7, 248);
            this.chkDisSensor.Name = "chkDisSensor";
            this.chkDisSensor.Size = new System.Drawing.Size(59, 17);
            this.chkDisSensor.TabIndex = 61;
            this.chkDisSensor.Text = "Sensor";
            this.toolTip1.SetToolTip(this.chkDisSensor, "If checked, the attachment will not effect the physical state of\r\nthe main body s" +
        "uch as mass and velocity.");
            this.chkDisSensor.UseVisualStyleBackColor = false;
            this.chkDisSensor.CheckedChanged += new System.EventHandler(this.chkDisSensor_CheckedChanged);
            // 
            // chkDisCollide
            // 
            this.chkDisCollide.AutoSize = true;
            this.chkDisCollide.BackColor = System.Drawing.Color.Transparent;
            this.chkDisCollide.Location = new System.Drawing.Point(8, 113);
            this.chkDisCollide.Name = "chkDisCollide";
            this.chkDisCollide.Size = new System.Drawing.Size(148, 17);
            this.chkDisCollide.TabIndex = 50;
            this.chkDisCollide.Text = "Collide Connected Events";
            this.toolTip1.SetToolTip(this.chkDisCollide, "If checked, the attachment can collide with the main body.\r\nIf Sensor is checked," +
        " this effect will be neglected.");
            this.chkDisCollide.UseVisualStyleBackColor = false;
            this.chkDisCollide.CheckedChanged += new System.EventHandler(this.chkDisCollide_CheckedChanged);
            // 
            // boxLine
            // 
            this.boxLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.boxLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.boxLine.CanCollapse = false;
            this.boxLine.Controls.Add(this.chkLineSyncDirection);
            this.boxLine.Controls.Add(this.chkLineSyncPos);
            this.boxLine.Controls.Add(this.chkLineSensor);
            this.boxLine.Controls.Add(this.nudLineFreq);
            this.boxLine.Controls.Add(this.nudLineDampingRatio);
            this.boxLine.Controls.Add(this.nudLineTorque);
            this.boxLine.Controls.Add(this.nudLineMSpeed);
            this.boxLine.Controls.Add(this.nudLineAxisY);
            this.boxLine.Controls.Add(this.nudLineAxisX);
            this.boxLine.Controls.Add(this.nudLineAJPY);
            this.boxLine.Controls.Add(this.nudLineAJPX);
            this.boxLine.Controls.Add(this.label12);
            this.boxLine.Controls.Add(this.label13);
            this.boxLine.Controls.Add(this.chkLineCollide);
            this.boxLine.Controls.Add(this.label14);
            this.boxLine.Controls.Add(this.label15);
            this.boxLine.Controls.Add(this.chkLineEnableMotor);
            this.boxLine.Controls.Add(this.label16);
            this.boxLine.Controls.Add(this.label17);
            this.boxLine.Controls.Add(this.label18);
            this.boxLine.Controls.Add(this.label19);
            this.boxLine.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.boxLine.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.boxLine.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.boxLine.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.boxLine.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.boxLine.Image = null;
            this.boxLine.IsCollapsed = false;
            this.boxLine.Location = new System.Drawing.Point(173, 95);
            this.boxLine.Name = "boxLine";
            this.boxLine.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.boxLine.Size = new System.Drawing.Size(285, 382);
            this.boxLine.TabIndex = 64;
            this.boxLine.TabStop = false;
            this.boxLine.Text = "Attachment Settings";
            this.boxLine.Visible = false;
            // 
            // nudLineFreq
            // 
            this.nudLineFreq.DecimalPlaces = 2;
            this.nudLineFreq.Location = new System.Drawing.Point(150, 242);
            this.nudLineFreq.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLineFreq.Name = "nudLineFreq";
            this.nudLineFreq.Size = new System.Drawing.Size(69, 20);
            this.nudLineFreq.TabIndex = 60;
            this.nudLineFreq.ValueChanged += new System.EventHandler(this.nudLineFreq_ValueChanged);
            // 
            // nudLineDampingRatio
            // 
            this.nudLineDampingRatio.DecimalPlaces = 2;
            this.nudLineDampingRatio.Location = new System.Drawing.Point(150, 216);
            this.nudLineDampingRatio.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLineDampingRatio.Name = "nudLineDampingRatio";
            this.nudLineDampingRatio.Size = new System.Drawing.Size(69, 20);
            this.nudLineDampingRatio.TabIndex = 59;
            this.nudLineDampingRatio.ValueChanged += new System.EventHandler(this.nudLineDampingRatio_ValueChanged);
            // 
            // nudLineTorque
            // 
            this.nudLineTorque.DecimalPlaces = 2;
            this.nudLineTorque.Location = new System.Drawing.Point(150, 190);
            this.nudLineTorque.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLineTorque.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudLineTorque.Name = "nudLineTorque";
            this.nudLineTorque.Size = new System.Drawing.Size(69, 20);
            this.nudLineTorque.TabIndex = 58;
            this.nudLineTorque.ValueChanged += new System.EventHandler(this.nudLineTorque_ValueChanged);
            // 
            // nudLineMSpeed
            // 
            this.nudLineMSpeed.DecimalPlaces = 2;
            this.nudLineMSpeed.Location = new System.Drawing.Point(150, 164);
            this.nudLineMSpeed.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLineMSpeed.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudLineMSpeed.Name = "nudLineMSpeed";
            this.nudLineMSpeed.Size = new System.Drawing.Size(69, 20);
            this.nudLineMSpeed.TabIndex = 57;
            this.nudLineMSpeed.ValueChanged += new System.EventHandler(this.nudLineMSpeed_ValueChanged);
            // 
            // nudLineAxisY
            // 
            this.nudLineAxisY.DecimalPlaces = 2;
            this.nudLineAxisY.Location = new System.Drawing.Point(216, 72);
            this.nudLineAxisY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLineAxisY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudLineAxisY.Name = "nudLineAxisY";
            this.nudLineAxisY.Size = new System.Drawing.Size(60, 20);
            this.nudLineAxisY.TabIndex = 56;
            this.nudLineAxisY.ValueChanged += new System.EventHandler(this.nudLineAxisY_ValueChanged);
            // 
            // nudLineAxisX
            // 
            this.nudLineAxisX.DecimalPlaces = 2;
            this.nudLineAxisX.Location = new System.Drawing.Point(150, 72);
            this.nudLineAxisX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLineAxisX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudLineAxisX.Name = "nudLineAxisX";
            this.nudLineAxisX.Size = new System.Drawing.Size(60, 20);
            this.nudLineAxisX.TabIndex = 55;
            this.nudLineAxisX.ValueChanged += new System.EventHandler(this.nudLineAxisX_ValueChanged);
            // 
            // nudLineAJPY
            // 
            this.nudLineAJPY.DecimalPlaces = 2;
            this.nudLineAJPY.Location = new System.Drawing.Point(216, 46);
            this.nudLineAJPY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLineAJPY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudLineAJPY.Name = "nudLineAJPY";
            this.nudLineAJPY.Size = new System.Drawing.Size(60, 20);
            this.nudLineAJPY.TabIndex = 54;
            this.nudLineAJPY.ValueChanged += new System.EventHandler(this.nudLineAJPY_ValueChanged);
            // 
            // nudLineAJPX
            // 
            this.nudLineAJPX.DecimalPlaces = 2;
            this.nudLineAJPX.Location = new System.Drawing.Point(150, 46);
            this.nudLineAJPX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLineAJPX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudLineAJPX.Name = "nudLineAJPX";
            this.nudLineAJPX.Size = new System.Drawing.Size(60, 20);
            this.nudLineAJPX.TabIndex = 53;
            this.nudLineAJPX.ValueChanged += new System.EventHandler(this.nudLineAJPX_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(162, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "X";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(239, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(5, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Frequency";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(5, 218);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "Damping Ratio";
            // 
            // chkLineEnableMotor
            // 
            this.chkLineEnableMotor.AutoSize = true;
            this.chkLineEnableMotor.BackColor = System.Drawing.Color.Transparent;
            this.chkLineEnableMotor.Location = new System.Drawing.Point(8, 136);
            this.chkLineEnableMotor.Name = "chkLineEnableMotor";
            this.chkLineEnableMotor.Size = new System.Drawing.Size(89, 17);
            this.chkLineEnableMotor.TabIndex = 46;
            this.chkLineEnableMotor.Text = "Enable Motor";
            this.chkLineEnableMotor.UseVisualStyleBackColor = false;
            this.chkLineEnableMotor.CheckedChanged += new System.EventHandler(this.chkLineEnableMotor_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(5, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "Motor Torque";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(5, 166);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "Motor Speed";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(9, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "Axis";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(7, 53);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Attachment Joint Anchor";
            // 
            // boxDistance
            // 
            this.boxDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.boxDistance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.boxDistance.CanCollapse = false;
            this.boxDistance.Controls.Add(this.nudDisDistance);
            this.boxDistance.Controls.Add(this.label25);
            this.boxDistance.Controls.Add(this.nudDisBreakpoint);
            this.boxDistance.Controls.Add(this.label24);
            this.boxDistance.Controls.Add(this.chkDisSyncDir);
            this.boxDistance.Controls.Add(this.chkDisSyncPos);
            this.boxDistance.Controls.Add(this.chkDisSensor);
            this.boxDistance.Controls.Add(this.nudDisFreq);
            this.boxDistance.Controls.Add(this.nudDisDampingRatio);
            this.boxDistance.Controls.Add(this.nudDisOJPY);
            this.boxDistance.Controls.Add(this.nudDisOJPX);
            this.boxDistance.Controls.Add(this.nudDisAJPY);
            this.boxDistance.Controls.Add(this.nudDisAJPX);
            this.boxDistance.Controls.Add(this.label20);
            this.boxDistance.Controls.Add(this.label21);
            this.boxDistance.Controls.Add(this.chkDisCollide);
            this.boxDistance.Controls.Add(this.label22);
            this.boxDistance.Controls.Add(this.label23);
            this.boxDistance.Controls.Add(this.label26);
            this.boxDistance.Controls.Add(this.label27);
            this.boxDistance.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.boxDistance.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.boxDistance.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.boxDistance.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.boxDistance.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.boxDistance.Image = null;
            this.boxDistance.IsCollapsed = false;
            this.boxDistance.Location = new System.Drawing.Point(173, 95);
            this.boxDistance.Name = "boxDistance";
            this.boxDistance.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.boxDistance.Size = new System.Drawing.Size(285, 382);
            this.boxDistance.TabIndex = 65;
            this.boxDistance.TabStop = false;
            this.boxDistance.Text = "Attachment Settings";
            this.boxDistance.Visible = false;
            // 
            // nudDisDistance
            // 
            this.nudDisDistance.DecimalPlaces = 2;
            this.nudDisDistance.Location = new System.Drawing.Point(150, 138);
            this.nudDisDistance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDisDistance.Name = "nudDisDistance";
            this.nudDisDistance.Size = new System.Drawing.Size(69, 20);
            this.nudDisDistance.TabIndex = 67;
            this.nudDisDistance.ValueChanged += new System.EventHandler(this.nudDisDistance_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(5, 140);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 13);
            this.label25.TabIndex = 66;
            this.label25.Text = "Distance";
            // 
            // nudDisBreakpoint
            // 
            this.nudDisBreakpoint.DecimalPlaces = 2;
            this.nudDisBreakpoint.Location = new System.Drawing.Point(150, 164);
            this.nudDisBreakpoint.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDisBreakpoint.Name = "nudDisBreakpoint";
            this.nudDisBreakpoint.Size = new System.Drawing.Size(69, 20);
            this.nudDisBreakpoint.TabIndex = 65;
            this.nudDisBreakpoint.ValueChanged += new System.EventHandler(this.nudDisBreakpoint_ValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(5, 166);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 13);
            this.label24.TabIndex = 64;
            this.label24.Text = "Break Point";
            // 
            // nudDisFreq
            // 
            this.nudDisFreq.DecimalPlaces = 2;
            this.nudDisFreq.Location = new System.Drawing.Point(150, 216);
            this.nudDisFreq.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDisFreq.Name = "nudDisFreq";
            this.nudDisFreq.Size = new System.Drawing.Size(69, 20);
            this.nudDisFreq.TabIndex = 60;
            this.nudDisFreq.ValueChanged += new System.EventHandler(this.nudDisFreq_ValueChanged);
            // 
            // nudDisDampingRatio
            // 
            this.nudDisDampingRatio.DecimalPlaces = 2;
            this.nudDisDampingRatio.Location = new System.Drawing.Point(150, 190);
            this.nudDisDampingRatio.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDisDampingRatio.Name = "nudDisDampingRatio";
            this.nudDisDampingRatio.Size = new System.Drawing.Size(69, 20);
            this.nudDisDampingRatio.TabIndex = 59;
            this.nudDisDampingRatio.ValueChanged += new System.EventHandler(this.nudDisDampingRatio_ValueChanged);
            // 
            // nudDisOJPY
            // 
            this.nudDisOJPY.DecimalPlaces = 2;
            this.nudDisOJPY.Location = new System.Drawing.Point(216, 72);
            this.nudDisOJPY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDisOJPY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudDisOJPY.Name = "nudDisOJPY";
            this.nudDisOJPY.Size = new System.Drawing.Size(60, 20);
            this.nudDisOJPY.TabIndex = 56;
            this.nudDisOJPY.ValueChanged += new System.EventHandler(this.nudDisOJPY_ValueChanged);
            // 
            // nudDisOJPX
            // 
            this.nudDisOJPX.DecimalPlaces = 2;
            this.nudDisOJPX.Location = new System.Drawing.Point(150, 72);
            this.nudDisOJPX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDisOJPX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudDisOJPX.Name = "nudDisOJPX";
            this.nudDisOJPX.Size = new System.Drawing.Size(60, 20);
            this.nudDisOJPX.TabIndex = 55;
            this.nudDisOJPX.ValueChanged += new System.EventHandler(this.nudDisOJPX_ValueChanged);
            // 
            // nudDisAJPY
            // 
            this.nudDisAJPY.DecimalPlaces = 2;
            this.nudDisAJPY.Location = new System.Drawing.Point(216, 46);
            this.nudDisAJPY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDisAJPY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudDisAJPY.Name = "nudDisAJPY";
            this.nudDisAJPY.Size = new System.Drawing.Size(60, 20);
            this.nudDisAJPY.TabIndex = 54;
            this.nudDisAJPY.ValueChanged += new System.EventHandler(this.nudDisAJPY_ValueChanged);
            // 
            // nudDisAJPX
            // 
            this.nudDisAJPX.DecimalPlaces = 2;
            this.nudDisAJPX.Location = new System.Drawing.Point(150, 46);
            this.nudDisAJPX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDisAJPX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudDisAJPX.Name = "nudDisAJPX";
            this.nudDisAJPX.Size = new System.Drawing.Size(60, 20);
            this.nudDisAJPX.TabIndex = 53;
            this.nudDisAJPX.ValueChanged += new System.EventHandler(this.nudDisAJPX_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(162, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "X";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(239, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 13);
            this.label21.TabIndex = 51;
            this.label21.Text = "Y";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(5, 218);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "Frequency";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(5, 192);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 13);
            this.label23.TabIndex = 47;
            this.label23.Text = "Damping Ratio";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(9, 79);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 13);
            this.label26.TabIndex = 43;
            this.label26.Text = "Owner Joint Anchor";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(7, 53);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(123, 13);
            this.label27.TabIndex = 42;
            this.label27.Text = "Attachment Joint Anchor";
            // 
            // JointsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(473, 524);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAttachment);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.boxDistance);
            this.Controls.Add(this.boxLine);
            this.Controls.Add(this.boxRevolute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "JointsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attach Events Dialog";
            this.impactGroupBox1.ResumeLayout(false);
            this.boxRevolute.ResumeLayout(false);
            this.boxRevolute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevLowLim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevUpLim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevMotTorq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevMotSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevOJPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevOJPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevAJPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevAJPX)).EndInit();
            this.boxLine.ResumeLayout(false);
            this.boxLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineDampingRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineTorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineMSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAxisY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAxisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAJPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineAJPX)).EndInit();
            this.boxDistance.ResumeLayout(false);
            this.boxDistance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisBreakpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisDampingRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisOJPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisOJPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisAJPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisAJPX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EventComboBox cbAttachment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbType;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox boxRevolute;
        private System.Windows.Forms.NumericUpDown nudRevLowLim;
        private System.Windows.Forms.NumericUpDown nudRevUpLim;
        private System.Windows.Forms.NumericUpDown nudRevMotTorq;
        private System.Windows.Forms.NumericUpDown nudRevMotSpeed;
        private System.Windows.Forms.NumericUpDown nudRevOJPY;
        private System.Windows.Forms.NumericUpDown nudRevOJPX;
        private System.Windows.Forms.NumericUpDown nudRevAJPY;
        private System.Windows.Forms.NumericUpDown nudRevAJPX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkRevCollide;
        private System.Windows.Forms.CheckBox chkRevAngleLimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkRevEnableMotor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkRevSensor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkRevAutoCorrectPos;
        private System.Windows.Forms.CheckBox chkRevSyncDir;
        private Controls.ImpactUI.ImpactGroupBox boxLine;
        private System.Windows.Forms.CheckBox chkLineSyncDirection;
        private System.Windows.Forms.CheckBox chkLineSensor;
        private System.Windows.Forms.NumericUpDown nudLineFreq;
        private System.Windows.Forms.NumericUpDown nudLineDampingRatio;
        private System.Windows.Forms.NumericUpDown nudLineTorque;
        private System.Windows.Forms.NumericUpDown nudLineMSpeed;
        private System.Windows.Forms.NumericUpDown nudLineAxisY;
        private System.Windows.Forms.NumericUpDown nudLineAxisX;
        private System.Windows.Forms.NumericUpDown nudLineAJPY;
        private System.Windows.Forms.NumericUpDown nudLineAJPX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkLineCollide;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkLineEnableMotor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkLineSyncPos;
        private Controls.ImpactUI.ImpactGroupBox boxDistance;
        private System.Windows.Forms.CheckBox chkDisSyncDir;
        private System.Windows.Forms.CheckBox chkDisSyncPos;
        private System.Windows.Forms.CheckBox chkDisSensor;
        private System.Windows.Forms.NumericUpDown nudDisFreq;
        private System.Windows.Forms.NumericUpDown nudDisDampingRatio;
        private System.Windows.Forms.NumericUpDown nudDisOJPY;
        private System.Windows.Forms.NumericUpDown nudDisOJPX;
        private System.Windows.Forms.NumericUpDown nudDisAJPY;
        private System.Windows.Forms.NumericUpDown nudDisAJPX;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chkDisCollide;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown nudDisDistance;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown nudDisBreakpoint;
        private System.Windows.Forms.Label label24;

    }
}