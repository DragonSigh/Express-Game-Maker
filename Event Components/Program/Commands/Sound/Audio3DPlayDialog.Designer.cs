﻿namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.SoundDialogs
{
    partial class Audio3DPlayDialog
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
            this.groupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Label();
            this.durationlb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.infiniteBtn = new System.Windows.Forms.CheckBox();
            this.panBox = new EGMGame.CustomUpDown();
            this.panBar = new EGMGame.Controls.CustomTrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.pitchBox = new EGMGame.CustomUpDown();
            this.pitchBar = new EGMGame.Controls.CustomTrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.volumeBox = new EGMGame.CustomUpDown();
            this.volumeBar = new EGMGame.Controls.CustomTrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.numberBox = new EGMGame.CustomUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.seList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbListener = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cbEmitter = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBox)).BeginInit();
            this.impactGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(354, 382);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(273, 382);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 24;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox4.Controls.Add(this.defaultBtn);
            this.groupBox4.Controls.Add(this.timer);
            this.groupBox4.Controls.Add(this.durationlb);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.infiniteBtn);
            this.groupBox4.Controls.Add(this.panBox);
            this.groupBox4.Controls.Add(this.panBar);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.pitchBox);
            this.groupBox4.Controls.Add(this.pitchBar);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.volumeBox);
            this.groupBox4.Controls.Add(this.volumeBar);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Enabled = false;
            this.groupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox4.Location = new System.Drawing.Point(145, 185);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(284, 188);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // defaultBtn
            // 
            this.defaultBtn.Location = new System.Drawing.Point(7, 22);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(75, 23);
            this.defaultBtn.TabIndex = 25;
            this.defaultBtn.Text = "Default";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Click += new System.EventHandler(this.defaultBtn_Click);
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.BackColor = System.Drawing.Color.Transparent;
            this.timer.Location = new System.Drawing.Point(240, 27);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(13, 13);
            this.timer.TabIndex = 24;
            this.timer.Text = "0";
            this.timer.Visible = false;
            // 
            // durationlb
            // 
            this.durationlb.AutoSize = true;
            this.durationlb.BackColor = System.Drawing.Color.Transparent;
            this.durationlb.Location = new System.Drawing.Point(142, 27);
            this.durationlb.Name = "durationlb";
            this.durationlb.Size = new System.Drawing.Size(64, 13);
            this.durationlb.TabIndex = 22;
            this.durationlb.Text = "00:00:00.00";
            this.durationlb.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(88, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Duration";
            this.label6.Visible = false;
            // 
            // infiniteBtn
            // 
            this.infiniteBtn.AutoSize = true;
            this.infiniteBtn.BackColor = System.Drawing.Color.Transparent;
            this.infiniteBtn.Location = new System.Drawing.Point(9, 51);
            this.infiniteBtn.Name = "infiniteBtn";
            this.infiniteBtn.Size = new System.Drawing.Size(50, 17);
            this.infiniteBtn.TabIndex = 18;
            this.infiniteBtn.Text = "Loop";
            this.infiniteBtn.UseVisualStyleBackColor = false;
            // 
            // panBox
            // 
            this.panBox.Location = new System.Drawing.Point(212, 148);
            this.panBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.panBox.Name = "panBox";
            this.panBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.panBox.OnChange = false;
            this.panBox.Size = new System.Drawing.Size(59, 20);
            this.panBox.TabIndex = 12;
            this.panBox.ValueChanged += new System.EventHandler(this.panBox_ValueChanged);
            // 
            // panBar
            // 
            this.panBar.BackColor = System.Drawing.Color.Transparent;
            this.panBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.panBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.panBar.IndentHeight = 6;
            this.panBar.LargeChange = 10;
            this.panBar.Location = new System.Drawing.Point(55, 141);
            this.panBar.Maximum = 100;
            this.panBar.Minimum = -100;
            this.panBar.Name = "panBar";
            this.panBar.Size = new System.Drawing.Size(151, 31);
            this.panBar.TabIndex = 11;
            this.panBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.panBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.panBar.TickFrequency = 10;
            this.panBar.TickHeight = 2;
            this.panBar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.panBar.TrackerSize = new System.Drawing.Size(10, 16);
            this.panBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.panBar.TrackLineHeight = 3;
            this.panBar.Value = 0;
            this.panBar.ValueChanged += new EGMGame.Controls.ValueChangedHandler(this.panBar_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pan";
            // 
            // pitchBox
            // 
            this.pitchBox.Location = new System.Drawing.Point(212, 111);
            this.pitchBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.pitchBox.Name = "pitchBox";
            this.pitchBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.pitchBox.OnChange = false;
            this.pitchBox.Size = new System.Drawing.Size(59, 20);
            this.pitchBox.TabIndex = 5;
            this.pitchBox.ValueChanged += new System.EventHandler(this.pitchBox_ValueChanged);
            // 
            // pitchBar
            // 
            this.pitchBar.BackColor = System.Drawing.Color.Transparent;
            this.pitchBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.pitchBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.pitchBar.IndentHeight = 6;
            this.pitchBar.Location = new System.Drawing.Point(55, 104);
            this.pitchBar.Maximum = 100;
            this.pitchBar.Minimum = -100;
            this.pitchBar.Name = "pitchBar";
            this.pitchBar.Size = new System.Drawing.Size(151, 31);
            this.pitchBar.TabIndex = 4;
            this.pitchBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.pitchBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.pitchBar.TickFrequency = 10;
            this.pitchBar.TickHeight = 2;
            this.pitchBar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.pitchBar.TrackerSize = new System.Drawing.Size(10, 16);
            this.pitchBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.pitchBar.TrackLineHeight = 3;
            this.pitchBar.Value = 0;
            this.pitchBar.ValueChanged += new EGMGame.Controls.ValueChangedHandler(this.pitchBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pitch";
            // 
            // volumeBox
            // 
            this.volumeBox.Location = new System.Drawing.Point(212, 74);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.volumeBox.OnChange = true;
            this.volumeBox.Size = new System.Drawing.Size(59, 20);
            this.volumeBox.TabIndex = 2;
            this.volumeBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.volumeBox.ValueChanged += new System.EventHandler(this.volumeBox_ValueChanged);
            // 
            // volumeBar
            // 
            this.volumeBar.BackColor = System.Drawing.Color.Transparent;
            this.volumeBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.volumeBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.volumeBar.IndentHeight = 6;
            this.volumeBar.Location = new System.Drawing.Point(55, 67);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Minimum = 0;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(151, 31);
            this.volumeBar.TabIndex = 1;
            this.volumeBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.volumeBar.TickFrequency = 10;
            this.volumeBar.TickHeight = 2;
            this.volumeBar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.volumeBar.TrackerSize = new System.Drawing.Size(10, 16);
            this.volumeBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.volumeBar.TrackLineHeight = 3;
            this.volumeBar.Value = 100;
            this.volumeBar.ValueChanged += new EGMGame.Controls.ValueChangedHandler(this.volumeBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volume";
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.numberBox);
            this.impactGroupBox2.Controls.Add(this.label9);
            this.impactGroupBox2.Controls.Add(this.btnStop);
            this.impactGroupBox2.Controls.Add(this.btnResume);
            this.impactGroupBox2.Controls.Add(this.btnPause);
            this.impactGroupBox2.Controls.Add(this.testBtn);
            this.impactGroupBox2.Enabled = false;
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(145, 96);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(284, 83);
            this.impactGroupBox2.TabIndex = 29;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Controls";
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(55, 28);
            this.numberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberBox.Name = "numberBox";
            this.numberBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numberBox.OnChange = true;
            this.numberBox.Size = new System.Drawing.Size(52, 20);
            this.numberBox.TabIndex = 28;
            this.numberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(7, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Channel";
            // 
            // btnStop
            // 
            this.btnStop.Image = global::EGMGame.Properties.Resources.control_stop_square;
            this.btnStop.Location = new System.Drawing.Point(213, 53);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(59, 22);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnResume
            // 
            this.btnResume.Image = global::EGMGame.Properties.Resources.control_stop;
            this.btnResume.Location = new System.Drawing.Point(137, 53);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(70, 22);
            this.btnResume.TabIndex = 16;
            this.btnResume.Text = "Resume";
            this.btnResume.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.Image = global::EGMGame.Properties.Resources.control_pause;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPause.Location = new System.Drawing.Point(72, 53);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(59, 22);
            this.btnPause.TabIndex = 14;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // testBtn
            // 
            this.testBtn.Image = global::EGMGame.Properties.Resources.control_play;
            this.testBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testBtn.Location = new System.Drawing.Point(7, 53);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(59, 22);
            this.testBtn.TabIndex = 13;
            this.testBtn.Text = "Play";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.seList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(128, 361);
            this.impactGroupBox1.TabIndex = 26;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Audios";
            // 
            // seList
            // 
            this.seList.AllowAdd = false;
            this.seList.AllowCategories = true;
            this.seList.AllowClipboard = true;
            this.seList.AllowRemove = false;
            this.seList.DisplayToolbar = false;
            this.seList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seList.EnableUpDown = false;
            this.seList.Export = true;
            this.seList.ImageList = null;
            this.seList.Import = true;
            this.seList.Location = new System.Drawing.Point(4, 25);
            this.seList.Master = false;
            this.seList.MultipleSelection = false;
            this.seList.Name = "seList";
            this.seList.SelectedIndex = -1;
            this.seList.ShowWarning = true;
            this.seList.Size = new System.Drawing.Size(120, 331);
            this.seList.TabIndex = 0;
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.label4);
            this.impactGroupBox3.Controls.Add(this.cbListener);
            this.impactGroupBox3.Controls.Add(this.label3);
            this.impactGroupBox3.Controls.Add(this.cbEmitter);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(145, 12);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(284, 78);
            this.impactGroupBox3.TabIndex = 30;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Emitter and Listener";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Choose the listener.";
            // 
            // cbListener
            // 
            this.cbListener.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbListener.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListener.FormattingEnabled = true;
            this.cbListener.Location = new System.Drawing.Point(145, 41);
            this.cbListener.Name = "cbListener";
            this.cbListener.ShowPlayer = true;
            this.cbListener.ShowTarget = true;
            this.cbListener.ShowTargets = false;
            this.cbListener.Size = new System.Drawing.Size(121, 21);
            this.cbListener.TabIndex = 2;
            this.cbListener.ThisEvent = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Choose the emitter.";
            // 
            // cbEmitter
            // 
            this.cbEmitter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEmitter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmitter.FormattingEnabled = true;
            this.cbEmitter.Location = new System.Drawing.Point(11, 41);
            this.cbEmitter.Name = "cbEmitter";
            this.cbEmitter.ShowPlayer = true;
            this.cbEmitter.ShowTarget = true;
            this.cbEmitter.ShowTargets = false;
            this.cbEmitter.Size = new System.Drawing.Size(121, 21);
            this.cbEmitter.TabIndex = 0;
            this.cbEmitter.ThisEvent = true;
            // 
            // Audio3DPlayDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(441, 417);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Audio3DPlayDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Play 3D Audio";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBox)).EndInit();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox4;
        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Label durationlb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox infiniteBtn;
        private CustomUpDown panBox;
        private CustomTrackBar panBar;
        private System.Windows.Forms.Label label5;
        private CustomUpDown pitchBox;
        private CustomTrackBar pitchBar;
        private System.Windows.Forms.Label label2;
        private CustomUpDown volumeBox;
        private CustomTrackBar volumeBar;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private CustomUpDown numberBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button testBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private AddRemoveList seList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.Label label4;
        private EGMGame.Controls.Game.MapEventComboBox cbListener;
        private System.Windows.Forms.Label label3;
        private EGMGame.Controls.Game.MapEventComboBox cbEmitter;
    }
}