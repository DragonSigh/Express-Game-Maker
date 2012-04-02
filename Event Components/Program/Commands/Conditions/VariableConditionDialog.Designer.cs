using EGMGame.Controls;
namespace EGMGame
{
    partial class VariableConditionDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.localBtn = new System.Windows.Forms.RadioButton();
            this.variablesBtn = new System.Windows.Forms.RadioButton();
            this.operationsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox2.SuspendLayout();
            this.operationsBox.SuspendLayout();
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
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(236, 320);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(317, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.localBtn);
            this.impactGroupBox2.Controls.Add(this.variablesBtn);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(170, 10);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(218, 53);
            this.impactGroupBox2.TabIndex = 71;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Variable";
            // 
            // localBtn
            // 
            this.localBtn.AutoSize = true;
            this.localBtn.BackColor = System.Drawing.Color.Transparent;
            this.localBtn.Location = new System.Drawing.Point(85, 28);
            this.localBtn.Name = "localBtn";
            this.localBtn.Size = new System.Drawing.Size(97, 17);
            this.localBtn.TabIndex = 72;
            this.localBtn.Text = "Local Variables";
            this.localBtn.UseVisualStyleBackColor = false;
            // 
            // variablesBtn
            // 
            this.variablesBtn.AutoSize = true;
            this.variablesBtn.BackColor = System.Drawing.Color.Transparent;
            this.variablesBtn.Checked = true;
            this.variablesBtn.Location = new System.Drawing.Point(7, 28);
            this.variablesBtn.Name = "variablesBtn";
            this.variablesBtn.Size = new System.Drawing.Size(68, 17);
            this.variablesBtn.TabIndex = 71;
            this.variablesBtn.TabStop = true;
            this.variablesBtn.Text = "Variables";
            this.variablesBtn.UseVisualStyleBackColor = false;
            this.variablesBtn.CheckedChanged += new System.EventHandler(this.variablesBtn_CheckedChanged);
            // 
            // operationsBox
            // 
            this.operationsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.operationsBox.Controls.Add(this.label11);
            this.operationsBox.Controls.Add(this.label10);
            this.operationsBox.Controls.Add(this.dataPanel);
            this.operationsBox.Controls.Add(this.variablePanel);
            this.operationsBox.Controls.Add(this.localVariablePanel);
            this.operationsBox.Controls.Add(this.eventsPanel);
            this.operationsBox.Controls.Add(this.otherPanel);
            this.operationsBox.Controls.Add(this.randPanel);
            this.operationsBox.Controls.Add(this.constantPanel);
            this.operationsBox.Controls.Add(this.valueTypeBox);
            this.operationsBox.Controls.Add(this.label1);
            this.operationsBox.Controls.Add(this.operationsList);
            this.operationsBox.Enabled = false;
            this.operationsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.operationsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.operationsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.operationsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.operationsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.operationsBox.Location = new System.Drawing.Point(170, 69);
            this.operationsBox.Name = "operationsBox";
            this.operationsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.operationsBox.Size = new System.Drawing.Size(218, 211);
            this.operationsBox.TabIndex = 72;
            this.operationsBox.TabStop = false;
            this.operationsBox.Text = "Operation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(4, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "Choose the value to compare to.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(4, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Choose the compare type for the condition.";
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
            this.dataPanel.Location = new System.Drawing.Point(10, 117);
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
            this.label4.Location = new System.Drawing.Point(179, 35);
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
            this.variablePanel.Location = new System.Drawing.Point(10, 117);
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
            this.localVariablePanel.Location = new System.Drawing.Point(10, 117);
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
            this.eventsPanel.Location = new System.Drawing.Point(10, 117);
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
            this.otherPanel.Location = new System.Drawing.Point(10, 117);
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
            this.randPanel.Location = new System.Drawing.Point(10, 117);
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
            this.constantPanel.Location = new System.Drawing.Point(10, 117);
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
            this.valueTypeBox.Location = new System.Drawing.Point(47, 90);
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
            this.label1.Location = new System.Drawing.Point(7, 93);
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
            "(=) Equals",
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals",
            "(!=) Does Not Equal"});
            this.operationsList.Location = new System.Drawing.Point(7, 44);
            this.operationsList.Name = "operationsList";
            this.operationsList.Size = new System.Drawing.Size(121, 21);
            this.operationsList.TabIndex = 2;
            this.operationsList.ValueMember = "Add";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.addRemoveList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(145, 292);
            this.impactGroupBox1.TabIndex = 73;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Variables";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = false;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowClipboard = true;
            this.addRemoveList.AllowRemove = false;
            this.addRemoveList.DisplayToolbar = false;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.Export = true;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Import = true;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = false;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(137, 262);
            this.addRemoveList.TabIndex = 1;
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(170, 286);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 74;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // VariableConditionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 355);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.operationsBox);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariableConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variable Condition";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.operationsBox.ResumeLayout(false);
            this.operationsBox.PerformLayout();
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
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox operationsBox;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton localBtn;
        private System.Windows.Forms.RadioButton variablesBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private AddRemoveList addRemoveList;
        private System.Windows.Forms.CheckBox elseBranc;
    }
}