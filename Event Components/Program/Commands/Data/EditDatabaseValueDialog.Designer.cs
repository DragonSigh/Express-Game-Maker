namespace EGMGame
{
    partial class EditDatabaseValueDialog
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
            this.textOperationsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.stringPanel = new System.Windows.Forms.Panel();
            this.stringComboBox1 = new EGMGame.Controls.Game.StringComboBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.textPanel = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.valueTextType = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.propertyBox = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.dataBox = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.databaseBox = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericOperationsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.numericDatasetList = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.databaseItemList = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.databaseList = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.variablePanel = new System.Windows.Forms.Panel();
            this.variablesList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.localVariablePanel = new System.Windows.Forms.Panel();
            this.localVariableList = new EGMGame.Controls.Game.LocalVariableComboBox(this.components);
            this.eventsPanel = new System.Windows.Forms.Panel();
            this.eventList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.eventPropertyList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.otherPanel = new System.Windows.Forms.Panel();
            this.otherList = new System.Windows.Forms.ComboBox();
            this.randPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rand2Num = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rand1Num = new EGMGame.CustomUpDown();
            this.constantPanel = new System.Windows.Forms.Panel();
            this.constantBox = new EGMGame.CustomUpDown();
            this.valueTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.operationsList = new System.Windows.Forms.ComboBox();
            this.textOperationsBox.SuspendLayout();
            this.stringPanel.SuspendLayout();
            this.textPanel.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.numericOperationsBox.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.variablePanel.SuspendLayout();
            this.localVariablePanel.SuspendLayout();
            this.eventsPanel.SuspendLayout();
            this.otherPanel.SuspendLayout();
            this.randPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rand2Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rand1Num)).BeginInit();
            this.constantPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(154, 376);
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
            this.okBtn.Location = new System.Drawing.Point(73, 376);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 14;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // textOperationsBox
            // 
            this.textOperationsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.textOperationsBox.Controls.Add(this.stringPanel);
            this.textOperationsBox.Controls.Add(this.textPanel);
            this.textOperationsBox.Controls.Add(this.label19);
            this.textOperationsBox.Controls.Add(this.valueTextType);
            this.textOperationsBox.Controls.Add(this.label20);
            this.textOperationsBox.Enabled = false;
            this.textOperationsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.textOperationsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.textOperationsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.textOperationsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.textOperationsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.textOperationsBox.Location = new System.Drawing.Point(12, 156);
            this.textOperationsBox.Name = "textOperationsBox";
            this.textOperationsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.textOperationsBox.Size = new System.Drawing.Size(218, 213);
            this.textOperationsBox.TabIndex = 24;
            this.textOperationsBox.TabStop = false;
            this.textOperationsBox.Text = "Text Operations";
            this.textOperationsBox.Visible = false;
            // 
            // stringPanel
            // 
            this.stringPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stringPanel.BackColor = System.Drawing.Color.Transparent;
            this.stringPanel.Controls.Add(this.stringComboBox1);
            this.stringPanel.Controls.Add(this.label13);
            this.stringPanel.Location = new System.Drawing.Point(12, 69);
            this.stringPanel.Name = "stringPanel";
            this.stringPanel.Size = new System.Drawing.Size(164, 44);
            this.stringPanel.TabIndex = 86;
            this.stringPanel.Visible = false;
            // 
            // stringComboBox1
            // 
            this.stringComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.stringComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stringComboBox1.FormattingEnabled = true;
            this.stringComboBox1.Location = new System.Drawing.Point(39, 3);
            this.stringComboBox1.Name = "stringComboBox1";
            this.stringComboBox1.SelectedNode = null;
            this.stringComboBox1.Size = new System.Drawing.Size(104, 21);
            this.stringComboBox1.TabIndex = 79;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(4, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 78;
            this.label13.Text = "String";
            // 
            // textPanel
            // 
            this.textPanel.BackColor = System.Drawing.Color.Transparent;
            this.textPanel.Controls.Add(this.textBox);
            this.textPanel.Controls.Add(this.label22);
            this.textPanel.Location = new System.Drawing.Point(12, 69);
            this.textPanel.Name = "textPanel";
            this.textPanel.Size = new System.Drawing.Size(164, 44);
            this.textPanel.TabIndex = 85;
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Location = new System.Drawing.Point(37, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(118, 20);
            this.textBox.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(4, 5);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 13);
            this.label22.TabIndex = 78;
            this.label22.Text = "Text";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(8, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 13);
            this.label19.TabIndex = 84;
            this.label19.Text = "Choose the value to assign.";
            // 
            // valueTextType
            // 
            this.valueTextType.DisplayMember = "Constant";
            this.valueTextType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueTextType.FormattingEnabled = true;
            this.valueTextType.Items.AddRange(new object[] {
            "Text",
            "String"});
            this.valueTextType.Location = new System.Drawing.Point(49, 42);
            this.valueTextType.Name = "valueTextType";
            this.valueTextType.Size = new System.Drawing.Size(106, 21);
            this.valueTextType.TabIndex = 83;
            this.valueTextType.ValueMember = "Constant";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(9, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 82;
            this.label20.Text = "Value";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label14);
            this.impactGroupBox1.Controls.Add(this.propertyBox);
            this.impactGroupBox1.Controls.Add(this.dataBox);
            this.impactGroupBox1.Controls.Add(this.databaseBox);
            this.impactGroupBox1.Controls.Add(this.label9);
            this.impactGroupBox1.Controls.Add(this.label10);
            this.impactGroupBox1.Controls.Add(this.label11);
            this.impactGroupBox1.Controls.Add(this.label12);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(218, 138);
            this.impactGroupBox1.TabIndex = 23;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Database";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(8, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 13);
            this.label14.TabIndex = 72;
            this.label14.Text = "Choose the database and it\'s property.";
            // 
            // propertyBox
            // 
            this.propertyBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.propertyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propertyBox.Enabled = false;
            this.propertyBox.FormattingEnabled = true;
            this.propertyBox.Location = new System.Drawing.Point(71, 103);
            this.propertyBox.Name = "propertyBox";
            this.propertyBox.Size = new System.Drawing.Size(105, 21);
            this.propertyBox.TabIndex = 50;
            this.propertyBox.SelectedIndexChanged += new System.EventHandler(this.propertyBox_SelectedIndexChanged);
            // 
            // dataBox
            // 
            this.dataBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBox.Enabled = false;
            this.dataBox.FormattingEnabled = true;
            this.dataBox.Location = new System.Drawing.Point(71, 73);
            this.dataBox.Name = "dataBox";
            this.dataBox.Noneable = false;
            this.dataBox.Size = new System.Drawing.Size(105, 21);
            this.dataBox.TabIndex = 49;
            this.dataBox.SelectedIndexChanged += new System.EventHandler(this.dataBox_SelectedIndexChanged);
            // 
            // databaseBox
            // 
            this.databaseBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.databaseBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseBox.FormattingEnabled = true;
            this.databaseBox.Location = new System.Drawing.Point(71, 46);
            this.databaseBox.Name = "databaseBox";
            this.databaseBox.Noneable = false;
            this.databaseBox.Size = new System.Drawing.Size(125, 21);
            this.databaseBox.TabIndex = 48;
            this.databaseBox.SelectedIndexChanged += new System.EventHandler(this.databaseBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(181, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "\'s";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(8, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Data";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(8, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Property";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(8, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Database";
            // 
            // numericOperationsBox
            // 
            this.numericOperationsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.numericOperationsBox.Controls.Add(this.label17);
            this.numericOperationsBox.Controls.Add(this.label16);
            this.numericOperationsBox.Controls.Add(this.dataPanel);
            this.numericOperationsBox.Controls.Add(this.variablePanel);
            this.numericOperationsBox.Controls.Add(this.localVariablePanel);
            this.numericOperationsBox.Controls.Add(this.eventsPanel);
            this.numericOperationsBox.Controls.Add(this.otherPanel);
            this.numericOperationsBox.Controls.Add(this.randPanel);
            this.numericOperationsBox.Controls.Add(this.constantPanel);
            this.numericOperationsBox.Controls.Add(this.valueTypeBox);
            this.numericOperationsBox.Controls.Add(this.label1);
            this.numericOperationsBox.Controls.Add(this.operationsList);
            this.numericOperationsBox.Enabled = false;
            this.numericOperationsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.numericOperationsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.numericOperationsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.numericOperationsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.numericOperationsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.numericOperationsBox.Location = new System.Drawing.Point(12, 156);
            this.numericOperationsBox.Name = "numericOperationsBox";
            this.numericOperationsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.numericOperationsBox.Size = new System.Drawing.Size(218, 213);
            this.numericOperationsBox.TabIndex = 22;
            this.numericOperationsBox.TabStop = false;
            this.numericOperationsBox.Text = "Numeric Operations";
            this.numericOperationsBox.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(8, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(173, 13);
            this.label17.TabIndex = 73;
            this.label17.Text = "Choose the value for the operation.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(7, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(214, 13);
            this.label16.TabIndex = 72;
            this.label16.Text = "Choose the operation type for the operation.";
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.Transparent;
            this.dataPanel.Controls.Add(this.numericDatasetList);
            this.dataPanel.Controls.Add(this.databaseItemList);
            this.dataPanel.Controls.Add(this.databaseList);
            this.dataPanel.Controls.Add(this.label4);
            this.dataPanel.Controls.Add(this.label6);
            this.dataPanel.Controls.Add(this.label5);
            this.dataPanel.Controls.Add(this.label8);
            this.dataPanel.Enabled = false;
            this.dataPanel.Location = new System.Drawing.Point(7, 112);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(204, 85);
            this.dataPanel.TabIndex = 35;
            this.dataPanel.Visible = false;
            // 
            // numericDatasetList
            // 
            this.numericDatasetList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.numericDatasetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numericDatasetList.Enabled = false;
            this.numericDatasetList.FormattingEnabled = true;
            this.numericDatasetList.Location = new System.Drawing.Point(70, 60);
            this.numericDatasetList.Name = "numericDatasetList";
            this.numericDatasetList.Size = new System.Drawing.Size(105, 21);
            this.numericDatasetList.TabIndex = 43;
            // 
            // databaseItemList
            // 
            this.databaseItemList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.databaseItemList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseItemList.Enabled = false;
            this.databaseItemList.FormattingEnabled = true;
            this.databaseItemList.Location = new System.Drawing.Point(70, 30);
            this.databaseItemList.Name = "databaseItemList";
            this.databaseItemList.Noneable = false;
            this.databaseItemList.Size = new System.Drawing.Size(105, 21);
            this.databaseItemList.TabIndex = 42;
            this.databaseItemList.SelectedIndexChanged += new System.EventHandler(this.databaseItemList_SelectedIndexChanged);
            // 
            // databaseList
            // 
            this.databaseList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.databaseList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseList.FormattingEnabled = true;
            this.databaseList.Location = new System.Drawing.Point(70, 3);
            this.databaseList.Name = "databaseList";
            this.databaseList.Noneable = false;
            this.databaseList.Size = new System.Drawing.Size(125, 21);
            this.databaseList.TabIndex = 41;
            this.databaseList.SelectedIndexChanged += new System.EventHandler(this.databaseList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(181, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "\'s";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Property";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Database";
            // 
            // variablePanel
            // 
            this.variablePanel.BackColor = System.Drawing.Color.Transparent;
            this.variablePanel.Controls.Add(this.variablesList);
            this.variablePanel.Enabled = false;
            this.variablePanel.Location = new System.Drawing.Point(7, 112);
            this.variablePanel.Name = "variablePanel";
            this.variablePanel.Size = new System.Drawing.Size(204, 34);
            this.variablePanel.TabIndex = 20;
            this.variablePanel.Visible = false;
            // 
            // variablesList
            // 
            this.variablesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variablesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variablesList.FormattingEnabled = true;
            this.variablesList.Location = new System.Drawing.Point(7, 7);
            this.variablesList.Name = "variablesList";
            this.variablesList.SelectedNode = null;
            this.variablesList.Size = new System.Drawing.Size(113, 21);
            this.variablesList.TabIndex = 33;
            // 
            // localVariablePanel
            // 
            this.localVariablePanel.BackColor = System.Drawing.Color.Transparent;
            this.localVariablePanel.Controls.Add(this.localVariableList);
            this.localVariablePanel.Enabled = false;
            this.localVariablePanel.Location = new System.Drawing.Point(7, 112);
            this.localVariablePanel.Name = "localVariablePanel";
            this.localVariablePanel.Size = new System.Drawing.Size(204, 34);
            this.localVariablePanel.TabIndex = 34;
            this.localVariablePanel.Visible = false;
            // 
            // localVariableList
            // 
            this.localVariableList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.localVariableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localVariableList.FormattingEnabled = true;
            this.localVariableList.Location = new System.Drawing.Point(6, 7);
            this.localVariableList.Name = "localVariableList";
            this.localVariableList.SelectedNode = null;
            this.localVariableList.Size = new System.Drawing.Size(113, 21);
            this.localVariableList.TabIndex = 34;
            // 
            // eventsPanel
            // 
            this.eventsPanel.BackColor = System.Drawing.Color.Transparent;
            this.eventsPanel.Controls.Add(this.eventList);
            this.eventsPanel.Controls.Add(this.eventPropertyList);
            this.eventsPanel.Controls.Add(this.label7);
            this.eventsPanel.Enabled = false;
            this.eventsPanel.Location = new System.Drawing.Point(7, 112);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(204, 34);
            this.eventsPanel.TabIndex = 35;
            this.eventsPanel.Visible = false;
            // 
            // eventList
            // 
            this.eventList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventList.FormattingEnabled = true;
            this.eventList.Location = new System.Drawing.Point(9, 7);
            this.eventList.Name = "eventList";
            this.eventList.ShowPlayer = true;
            this.eventList.ShowTarget = true;
            this.eventList.ShowTargets = false;
            this.eventList.Size = new System.Drawing.Size(85, 21);
            this.eventList.TabIndex = 40;
            this.eventList.ThisEvent = false;
            // 
            // eventPropertyList
            // 
            this.eventPropertyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventPropertyList.FormattingEnabled = true;
            this.eventPropertyList.Items.AddRange(new object[] {
            "Position X",
            "Position Y",
            "Map ID"});
            this.eventPropertyList.Location = new System.Drawing.Point(108, 7);
            this.eventPropertyList.Name = "eventPropertyList";
            this.eventPropertyList.Size = new System.Drawing.Size(87, 21);
            this.eventPropertyList.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(94, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "\'s";
            // 
            // otherPanel
            // 
            this.otherPanel.BackColor = System.Drawing.Color.Transparent;
            this.otherPanel.Controls.Add(this.otherList);
            this.otherPanel.Enabled = false;
            this.otherPanel.Location = new System.Drawing.Point(7, 112);
            this.otherPanel.Name = "otherPanel";
            this.otherPanel.Size = new System.Drawing.Size(204, 34);
            this.otherPanel.TabIndex = 35;
            this.otherPanel.Visible = false;
            // 
            // otherList
            // 
            this.otherList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.otherList.FormattingEnabled = true;
            this.otherList.Items.AddRange(new object[] {
            "Current Map ID"});
            this.otherList.Location = new System.Drawing.Point(10, 6);
            this.otherList.Name = "otherList";
            this.otherList.Size = new System.Drawing.Size(133, 21);
            this.otherList.TabIndex = 30;
            // 
            // randPanel
            // 
            this.randPanel.BackColor = System.Drawing.Color.Transparent;
            this.randPanel.Controls.Add(this.label3);
            this.randPanel.Controls.Add(this.rand2Num);
            this.randPanel.Controls.Add(this.label2);
            this.randPanel.Controls.Add(this.rand1Num);
            this.randPanel.Enabled = false;
            this.randPanel.Location = new System.Drawing.Point(7, 112);
            this.randPanel.Name = "randPanel";
            this.randPanel.Size = new System.Drawing.Size(204, 37);
            this.randPanel.TabIndex = 5;
            this.randPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(121, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "-";
            // 
            // rand2Num
            // 
            this.rand2Num.Location = new System.Drawing.Point(138, 7);
            this.rand2Num.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rand2Num.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.rand2Num.Name = "rand2Num";
            this.rand2Num.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rand2Num.OnChange = false;
            this.rand2Num.Size = new System.Drawing.Size(54, 20);
            this.rand2Num.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Between";
            // 
            // rand1Num
            // 
            this.rand1Num.Location = new System.Drawing.Point(61, 7);
            this.rand1Num.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rand1Num.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.rand1Num.Name = "rand1Num";
            this.rand1Num.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rand1Num.OnChange = false;
            this.rand1Num.Size = new System.Drawing.Size(54, 20);
            this.rand1Num.TabIndex = 14;
            // 
            // constantPanel
            // 
            this.constantPanel.BackColor = System.Drawing.Color.Transparent;
            this.constantPanel.Controls.Add(this.constantBox);
            this.constantPanel.Location = new System.Drawing.Point(7, 112);
            this.constantPanel.Name = "constantPanel";
            this.constantPanel.Size = new System.Drawing.Size(201, 37);
            this.constantPanel.TabIndex = 20;
            // 
            // constantBox
            // 
            this.constantBox.Location = new System.Drawing.Point(7, 7);
            this.constantBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.constantBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.constantBox.Name = "constantBox";
            this.constantBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.constantBox.OnChange = false;
            this.constantBox.Size = new System.Drawing.Size(113, 20);
            this.constantBox.TabIndex = 8;
            // 
            // valueTypeBox
            // 
            this.valueTypeBox.DisplayMember = "Constant";
            this.valueTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueTypeBox.FormattingEnabled = true;
            this.valueTypeBox.Items.AddRange(new object[] {
            "Constant",
            "Random Number",
            "Variable",
            "Local Variable",
            "Event",
            "Data",
            "Other"});
            this.valueTypeBox.Location = new System.Drawing.Point(47, 85);
            this.valueTypeBox.Name = "valueTypeBox";
            this.valueTypeBox.Size = new System.Drawing.Size(106, 21);
            this.valueTypeBox.TabIndex = 4;
            this.valueTypeBox.ValueMember = "Constant";
            this.valueTypeBox.SelectedIndexChanged += new System.EventHandler(this.valueTypeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Value";
            // 
            // operationsList
            // 
            this.operationsList.DisplayMember = "Add";
            this.operationsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationsList.FormattingEnabled = true;
            this.operationsList.Items.AddRange(new object[] {
            "Set (=)",
            "Add (+)",
            "Subtract (-)",
            "Multiply (*)",
            "Divide (/)",
            "Exponentiate (^)",
            "Modulate (r)"});
            this.operationsList.Location = new System.Drawing.Point(10, 45);
            this.operationsList.Name = "operationsList";
            this.operationsList.Size = new System.Drawing.Size(121, 21);
            this.operationsList.TabIndex = 2;
            this.operationsList.ValueMember = "Add";
            // 
            // EditDatabaseValueDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(241, 411);
            this.Controls.Add(this.textOperationsBox);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.numericOperationsBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDatabaseValueDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Database Value";
            this.textOperationsBox.ResumeLayout(false);
            this.textOperationsBox.PerformLayout();
            this.stringPanel.ResumeLayout(false);
            this.stringPanel.PerformLayout();
            this.textPanel.ResumeLayout(false);
            this.textPanel.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.numericOperationsBox.ResumeLayout(false);
            this.numericOperationsBox.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.variablePanel.ResumeLayout(false);
            this.localVariablePanel.ResumeLayout(false);
            this.eventsPanel.ResumeLayout(false);
            this.eventsPanel.PerformLayout();
            this.otherPanel.ResumeLayout(false);
            this.randPanel.ResumeLayout(false);
            this.randPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rand2Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rand1Num)).EndInit();
            this.constantPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox numericOperationsBox;
        private System.Windows.Forms.Panel dataPanel;
        private EGMGame.Controls.Game.DataPropertyComboBox numericDatasetList;
        private EGMGame.Controls.Game.DatabaseComboBox databaseItemList;
        private EGMGame.Controls.Game.DatabaseComboBox databaseList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel variablePanel;
        private EGMGame.Controls.Game.VariableComboBox variablesList;
        private System.Windows.Forms.Panel localVariablePanel;
        private EGMGame.Controls.Game.LocalVariableComboBox localVariableList;
        private System.Windows.Forms.Panel eventsPanel;
        private EGMGame.Controls.Game.MapEventComboBox eventList;
        private System.Windows.Forms.ComboBox eventPropertyList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel otherPanel;
        private System.Windows.Forms.ComboBox otherList;
        private System.Windows.Forms.Panel randPanel;
        private System.Windows.Forms.Label label3;
        private CustomUpDown rand2Num;
        private System.Windows.Forms.Label label2;
        private CustomUpDown rand1Num;
        private System.Windows.Forms.Panel constantPanel;
        private CustomUpDown constantBox;
        private System.Windows.Forms.ComboBox valueTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox operationsList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.DataPropertyComboBox propertyBox;
        private EGMGame.Controls.Game.DatabaseComboBox dataBox;
        private EGMGame.Controls.Game.DatabaseComboBox databaseBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox textOperationsBox;
        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox valueTextType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel textPanel;
        private System.Windows.Forms.Panel stringPanel;
        private System.Windows.Forms.Label label13;
        private EGMGame.Controls.Game.StringComboBox stringComboBox1;
    }
}