namespace EGMGame.Dialogs
{
    partial class NewProjectWiz
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Blank", "application-blue.png");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectWiz));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nextBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.directoryChk = new System.Windows.Forms.CheckBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.locationTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.backDBtn = new System.Windows.Forms.Button();
            this.nextDBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.defaultPixel = new EGMGame.CustomUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.gridHeight = new EGMGame.CustomUpDown();
            this.gridWidth = new EGMGame.CustomUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.screenHeight = new EGMGame.CustomUpDown();
            this.screenWidth = new EGMGame.CustomUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.defaultPlatform = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.iconPic = new System.Windows.Forms.PictureBox();
            this.iconBtn = new System.Windows.Forms.Button();
            this.iconBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backBtn = new System.Windows.Forms.Button();
            this.finishBtn = new System.Windows.Forms.Button();
            this.cancelBtn2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tDesc = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrwD = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.workerExport = new System.ComponentModel.BackgroundWorker();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPixel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(-9, -25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(323, 336);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.nextBtn);
            this.tabPage1.Controls.Add(this.cancelBtn);
            this.tabPage1.Controls.Add(this.directoryChk);
            this.tabPage1.Controls.Add(this.browseBtn);
            this.tabPage1.Controls.Add(this.locationTxt);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.nameTxt);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(315, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(222, 274);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 17;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(17, 274);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // directoryChk
            // 
            this.directoryChk.AutoSize = true;
            this.directoryChk.Checked = true;
            this.directoryChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.directoryChk.Location = new System.Drawing.Point(17, 174);
            this.directoryChk.Name = "directoryChk";
            this.directoryChk.Size = new System.Drawing.Size(138, 17);
            this.directoryChk.TabIndex = 15;
            this.directoryChk.Text = "Create Project Directory";
            this.directoryChk.UseVisualStyleBackColor = true;
            this.directoryChk.CheckedChanged += new System.EventHandler(this.directoryChk_CheckedChanged);
            this.directoryChk.Click += new System.EventHandler(this.directoryChk_CheckedChanged);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(203, 148);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(59, 20);
            this.browseBtn.TabIndex = 14;
            this.browseBtn.Text = "Browse...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // locationTxt
            // 
            this.locationTxt.Location = new System.Drawing.Point(17, 148);
            this.locationTxt.Name = "locationTxt";
            this.locationTxt.Size = new System.Drawing.Size(180, 20);
            this.locationTxt.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Choose Project Location:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(17, 100);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(180, 20);
            this.nameTxt.TabIndex = 11;
            this.nameTxt.Text = "Project";
            this.nameTxt.Click += new System.EventHandler(this.nameTxt_Click);
            this.nameTxt.Leave += new System.EventHandler(this.nameTxt_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Enter Project Name:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "The new project wizard will lead you through creating your \r\nnew project in just " +
                "a few steps.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Project Wizard";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.backDBtn);
            this.tabPage3.Controls.Add(this.nextDBtn);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.defaultPixel);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.gridHeight);
            this.tabPage3.Controls.Add(this.gridWidth);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.screenHeight);
            this.tabPage3.Controls.Add(this.screenWidth);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.defaultPlatform);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.iconPic);
            this.tabPage3.Controls.Add(this.iconBtn);
            this.tabPage3.Controls.Add(this.iconBox);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.descBox);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(315, 310);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // backDBtn
            // 
            this.backDBtn.Location = new System.Drawing.Point(144, 274);
            this.backDBtn.Name = "backDBtn";
            this.backDBtn.Size = new System.Drawing.Size(75, 23);
            this.backDBtn.TabIndex = 31;
            this.backDBtn.Text = "Back";
            this.backDBtn.UseVisualStyleBackColor = true;
            this.backDBtn.Click += new System.EventHandler(this.backDBtn_Click);
            // 
            // nextDBtn
            // 
            this.nextDBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.nextDBtn.Location = new System.Drawing.Point(225, 274);
            this.nextDBtn.Name = "nextDBtn";
            this.nextDBtn.Size = new System.Drawing.Size(75, 23);
            this.nextDBtn.TabIndex = 30;
            this.nextDBtn.Text = "Next";
            this.nextDBtn.UseVisualStyleBackColor = true;
            this.nextDBtn.Click += new System.EventHandler(this.nextDBtn_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(17, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(246, 26);
            this.label12.TabIndex = 28;
            this.label12.Text = "Enter the project details. \r\nThese can be changed anytime at project settings.";
            // 
            // defaultPixel
            // 
            this.defaultPixel.Location = new System.Drawing.Point(120, 239);
            this.defaultPixel.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.defaultPixel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.defaultPixel.Name = "defaultPixel";
            this.defaultPixel.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.defaultPixel.OnChange = true;
            this.defaultPixel.Size = new System.Drawing.Size(55, 20);
            this.defaultPixel.TabIndex = 27;
            this.defaultPixel.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(15, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Default Pixel";
            // 
            // gridHeight
            // 
            this.gridHeight.Location = new System.Drawing.Point(181, 213);
            this.gridHeight.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.gridHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gridHeight.Name = "gridHeight";
            this.gridHeight.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.gridHeight.OnChange = true;
            this.gridHeight.Size = new System.Drawing.Size(55, 20);
            this.gridHeight.TabIndex = 25;
            this.gridHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // gridWidth
            // 
            this.gridWidth.Location = new System.Drawing.Point(120, 213);
            this.gridWidth.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.gridWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gridWidth.Name = "gridWidth";
            this.gridWidth.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.gridWidth.OnChange = true;
            this.gridWidth.Size = new System.Drawing.Size(55, 20);
            this.gridWidth.TabIndex = 24;
            this.gridWidth.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(15, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Default Grid";
            // 
            // screenHeight
            // 
            this.screenHeight.Location = new System.Drawing.Point(181, 187);
            this.screenHeight.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.screenHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.screenHeight.Name = "screenHeight";
            this.screenHeight.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenHeight.OnChange = true;
            this.screenHeight.Size = new System.Drawing.Size(55, 20);
            this.screenHeight.TabIndex = 22;
            this.screenHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // screenWidth
            // 
            this.screenWidth.Location = new System.Drawing.Point(120, 187);
            this.screenWidth.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.screenWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.screenWidth.Name = "screenWidth";
            this.screenWidth.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenWidth.OnChange = true;
            this.screenWidth.Size = new System.Drawing.Size(55, 20);
            this.screenWidth.TabIndex = 21;
            this.screenWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(15, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Screen Ratio";
            // 
            // defaultPlatform
            // 
            this.defaultPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultPlatform.FormattingEnabled = true;
            this.defaultPlatform.Items.AddRange(new object[] {
            "Windows",
            "Xbox 360",
            "Silverlight"});
            this.defaultPlatform.Location = new System.Drawing.Point(120, 160);
            this.defaultPlatform.Name = "defaultPlatform";
            this.defaultPlatform.Size = new System.Drawing.Size(111, 21);
            this.defaultPlatform.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(15, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Default Platofrm";
            // 
            // iconPic
            // 
            this.iconPic.BackColor = System.Drawing.Color.Transparent;
            this.iconPic.Location = new System.Drawing.Point(83, 115);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(32, 32);
            this.iconPic.TabIndex = 9;
            this.iconPic.TabStop = false;
            // 
            // iconBtn
            // 
            this.iconBtn.Location = new System.Drawing.Point(272, 118);
            this.iconBtn.Name = "iconBtn";
            this.iconBtn.Size = new System.Drawing.Size(25, 23);
            this.iconBtn.TabIndex = 13;
            this.iconBtn.Text = "...";
            this.iconBtn.UseVisualStyleBackColor = true;
            this.iconBtn.Click += new System.EventHandler(this.iconBtn_Click);
            // 
            // iconBox
            // 
            this.iconBox.BackColor = System.Drawing.Color.White;
            this.iconBox.Location = new System.Drawing.Point(120, 120);
            this.iconBox.Name = "iconBox";
            this.iconBox.ReadOnly = true;
            this.iconBox.Size = new System.Drawing.Size(146, 20);
            this.iconBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(15, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Icon";
            // 
            // descBox
            // 
            this.descBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descBox.Location = new System.Drawing.Point(120, 55);
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(177, 57);
            this.descBox.TabIndex = 8;
            this.descBox.Text = "A game made with EGM.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(15, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Description";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.backBtn);
            this.tabPage2.Controls.Add(this.finishBtn);
            this.tabPage2.Controls.Add(this.cancelBtn2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.listView);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(315, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(144, 274);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 20;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(225, 274);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(75, 23);
            this.finishBtn.TabIndex = 19;
            this.finishBtn.Text = "Finish";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // cancelBtn2
            // 
            this.cancelBtn2.Location = new System.Drawing.Point(17, 274);
            this.cancelBtn2.Name = "cancelBtn2";
            this.cancelBtn2.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn2.TabIndex = 18;
            this.cancelBtn2.Text = "Cancel";
            this.cancelBtn2.UseVisualStyleBackColor = true;
            this.cancelBtn2.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tDesc);
            this.panel1.Location = new System.Drawing.Point(17, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 29);
            this.panel1.TabIndex = 14;
            // 
            // tDesc
            // 
            this.tDesc.Location = new System.Drawing.Point(3, 0);
            this.tDesc.MaximumSize = new System.Drawing.Size(275, 27);
            this.tDesc.Name = "tDesc";
            this.tDesc.Size = new System.Drawing.Size(275, 27);
            this.tDesc.TabIndex = 0;
            this.tDesc.Text = "Please select a template.";
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            listViewItem2.UseItemStyleForSubItems = false;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(17, 32);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(283, 111);
            this.listView.SmallImageList = this.imageList;
            this.listView.StateImageList = this.imageList;
            this.listView.TabIndex = 13;
            this.listView.TileSize = new System.Drawing.Size(36, 36);
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.SmallIcon;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "application-blue.png");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Choose the project template:";
            // 
            // folderBrwD
            // 
            this.folderBrwD.Description = "Choose project location.";
            this.folderBrwD.SelectedPath = "C:\\";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ico";
            this.openFileDialog.Filter = "Icon|*.ico";
            this.openFileDialog.Title = "Choose Icon";
            // 
            // workerExport
            // 
            this.workerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerExport_DoWork);
            this.workerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerExport_RunWorkerCompleted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(33, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(248, 39);
            this.label13.TabIndex = 18;
            this.label13.Text = "If checked, a new directory for the project \r\nwill be created at the selected Pro" +
                "ject Location. \r\nThe directory will be named after the Project Name.";
            // 
            // NewProjectWiz
            // 
            this.AcceptButton = this.finishBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 307);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectWiz";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Wizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewProjectWiz_FormClosing);
            this.Load += new System.EventHandler(this.NewPrjDialog_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPixel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TextBox locationTxt;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Button cancelBtn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.FolderBrowserDialog folderBrwD;
        public System.Windows.Forms.CheckBox directoryChk;
        private System.Windows.Forms.Label tDesc;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox iconPic;
        private System.Windows.Forms.Button iconBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button backDBtn;
        private System.Windows.Forms.Button nextDBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        internal System.Windows.Forms.TextBox iconBox;
        internal System.Windows.Forms.RichTextBox descBox;
        internal System.Windows.Forms.ComboBox defaultPlatform;
        internal CustomUpDown defaultPixel;
        internal CustomUpDown gridHeight;
        internal CustomUpDown gridWidth;
        internal CustomUpDown screenHeight;
        internal CustomUpDown screenWidth;
        private System.ComponentModel.BackgroundWorker workerExport;
        private System.Windows.Forms.Label label13;

    }
}