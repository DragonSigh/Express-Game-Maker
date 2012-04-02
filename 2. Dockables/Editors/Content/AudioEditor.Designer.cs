namespace EGMGame.Docking.Editors
{
    partial class AudioEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioEditor));
            this.groupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.timer = new System.Windows.Forms.Label();
            this.afterBtn = new System.Windows.Forms.CheckBox();
            this.durationlb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.infiniteBtn = new System.Windows.Forms.CheckBox();
            this.panBox = new EGMGame.CustomUpDown();
            this.panBar = new EGMGame.Controls.CustomTrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.fadeOutBox = new EGMGame.CustomUpDown();
            this.fadeInBox = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pitchBox = new EGMGame.CustomUpDown();
            this.pitchBar = new EGMGame.Controls.CustomTrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.volumeBox = new EGMGame.CustomUpDown();
            this.volumeBar = new EGMGame.Controls.CustomTrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.fileNameTxt = new System.Windows.Forms.TextBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeOutBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeInBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox4.CanCollapse = false;
            this.groupBox4.Controls.Add(this.timer);
            this.groupBox4.Controls.Add(this.afterBtn);
            this.groupBox4.Controls.Add(this.durationlb);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.infiniteBtn);
            this.groupBox4.Controls.Add(this.panBox);
            this.groupBox4.Controls.Add(this.panBar);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.fadeOutBox);
            this.groupBox4.Controls.Add(this.fadeInBox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
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
            this.groupBox4.Image = null;
            this.groupBox4.IsCollapsed = false;
            this.groupBox4.Location = new System.Drawing.Point(142, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(284, 247);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.BackColor = System.Drawing.Color.Transparent;
            this.timer.Location = new System.Drawing.Point(159, 30);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(13, 13);
            this.timer.TabIndex = 24;
            this.timer.Text = "0";
            // 
            // afterBtn
            // 
            this.afterBtn.AutoSize = true;
            this.afterBtn.BackColor = System.Drawing.Color.Transparent;
            this.afterBtn.Location = new System.Drawing.Point(162, 209);
            this.afterBtn.Name = "afterBtn";
            this.afterBtn.Size = new System.Drawing.Size(73, 17);
            this.afterBtn.TabIndex = 23;
            this.afterBtn.Text = "After Start";
            this.afterBtn.UseVisualStyleBackColor = false;
            this.afterBtn.CheckedChanged += new System.EventHandler(this.afterBtn_CheckedChanged);
            // 
            // durationlb
            // 
            this.durationlb.AutoSize = true;
            this.durationlb.BackColor = System.Drawing.Color.Transparent;
            this.durationlb.Location = new System.Drawing.Point(67, 30);
            this.durationlb.Name = "durationlb";
            this.durationlb.Size = new System.Drawing.Size(64, 13);
            this.durationlb.TabIndex = 22;
            this.durationlb.Text = "00:00:00.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Duration";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(129, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "ms.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(129, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "ms.";
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
            this.infiniteBtn.CheckedChanged += new System.EventHandler(this.infiniteBtn_CheckedChanged);
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
            // fadeOutBox
            // 
            this.fadeOutBox.Location = new System.Drawing.Point(64, 208);
            this.fadeOutBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.fadeOutBox.Name = "fadeOutBox";
            this.fadeOutBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.fadeOutBox.OnChange = false;
            this.fadeOutBox.Size = new System.Drawing.Size(59, 20);
            this.fadeOutBox.TabIndex = 9;
            this.fadeOutBox.ValueChanged += new System.EventHandler(this.fadeOutBox_ValueChanged);
            // 
            // fadeInBox
            // 
            this.fadeInBox.Location = new System.Drawing.Point(64, 179);
            this.fadeInBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.fadeInBox.Name = "fadeInBox";
            this.fadeInBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.fadeInBox.OnChange = false;
            this.fadeInBox.Size = new System.Drawing.Size(59, 20);
            this.fadeInBox.TabIndex = 8;
            this.fadeInBox.ValueChanged += new System.EventHandler(this.fadeInBox_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fade Out";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fade In";
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
            1,
            0,
            0,
            -2147483648});
            this.volumeBox.OnChange = false;
            this.volumeBox.Size = new System.Drawing.Size(59, 20);
            this.volumeBox.TabIndex = 2;
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
            this.volumeBar.Value = 0;
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
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox2.CanCollapse = false;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnResume);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Controls.Add(this.fileNameTxt);
            this.groupBox2.Controls.Add(this.testBtn);
            this.groupBox2.Enabled = false;
            this.groupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox2.Image = null;
            this.groupBox2.IsCollapsed = false;
            this.groupBox2.Location = new System.Drawing.Point(142, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(284, 86);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio File";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::EGMGame.Properties.Resources.music_beam;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(8, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnResume
            // 
            this.btnResume.Image = global::EGMGame.Properties.Resources.control_stop;
            this.btnResume.Location = new System.Drawing.Point(137, 49);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(70, 22);
            this.btnResume.TabIndex = 8;
            this.btnResume.Text = "Resume";
            this.btnResume.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::EGMGame.Properties.Resources.control_stop_square;
            this.btnStop.Location = new System.Drawing.Point(213, 50);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(59, 22);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Image = global::EGMGame.Properties.Resources.control_pause;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPause.Location = new System.Drawing.Point(72, 50);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(59, 22);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // fileNameTxt
            // 
            this.fileNameTxt.AllowDrop = true;
            this.fileNameTxt.BackColor = System.Drawing.Color.White;
            this.fileNameTxt.Location = new System.Drawing.Point(27, 24);
            this.fileNameTxt.Name = "fileNameTxt";
            this.fileNameTxt.ReadOnly = true;
            this.fileNameTxt.Size = new System.Drawing.Size(167, 20);
            this.fileNameTxt.TabIndex = 5;
            this.fileNameTxt.Text = "Drag and drop Audio here";
            this.fileNameTxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileNameTxt_DragDrop);
            this.fileNameTxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileNameTxt_DragEnter);
            // 
            // testBtn
            // 
            this.testBtn.Image = global::EGMGame.Properties.Resources.control_play;
            this.testBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testBtn.Location = new System.Drawing.Point(7, 50);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(59, 22);
            this.testBtn.TabIndex = 1;
            this.testBtn.Text = "Play";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox1.CanCollapse = false;
            this.groupBox1.Controls.Add(this.addRemoveList);
            this.groupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox1.Image = null;
            this.groupBox1.IsCollapsed = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(124, 372);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowClipboard = true;
            this.addRemoveList.AllowRemove = true;
            this.addRemoveList.DisplayToolbar = true;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.Export = true;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Import = true;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = true;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(116, 342);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // graphicsControl
            // 
            this.graphicsControl.Location = new System.Drawing.Point(432, 12);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(17, 19);
            this.graphicsControl.TabIndex = 5;
            this.graphicsControl.Text = "simpleGraphicsControl1";
            this.graphicsControl.Visible = false;
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AudioEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 396);
            this.Controls.Add(this.graphicsControl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AudioEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Audio Editor";
            this.Text = "Audio Editor";
            this.Activated += new System.EventHandler(this.AudioEditor_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AudioEditor_FormClosed);
            this.Shown += new System.EventHandler(this.AudioEditor_Shown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeOutBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fadeInBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        private System.Windows.Forms.Button testBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox4;
        private System.Windows.Forms.TextBox fileNameTxt;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.CustomTrackBar volumeBar;
        private CustomUpDown volumeBox;
        private CustomUpDown pitchBox;
        private EGMGame.Controls.CustomTrackBar pitchBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private CustomUpDown fadeOutBox;
        private CustomUpDown fadeInBox;
        private System.Windows.Forms.Label label4;
        private CustomUpDown panBox;
        private EGMGame.Controls.CustomTrackBar panBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox infiniteBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label durationlb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox afterBtn;
        private System.Windows.Forms.Label timer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Controls.SimpleGraphicsControl graphicsControl;
        internal Controls.AddRemoveList addRemoveList;
        private Controls.UI.DockContextMenu dockContextMenu1;
        private System.Windows.Forms.Timer timer1;
    }
}