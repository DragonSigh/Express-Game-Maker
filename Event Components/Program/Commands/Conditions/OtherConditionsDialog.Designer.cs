namespace EGMGame
{
    partial class OtherConditionDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbCompare = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConditions = new System.Windows.Forms.ComboBox();
            this.panelPlatform = new System.Windows.Forms.Panel();
            this.cbPlatforms = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panelTile = new System.Windows.Forms.Panel();
            this.cbTiles = new System.Windows.Forms.ComboBox();
            this.operationTypeList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTileTag = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTileTag = new System.Windows.Forms.NumericUpDown();
            this.variablesPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.variableYList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.variableXList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.constPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.nudScreenY = new EGMGame.CustomUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudScreenX = new EGMGame.CustomUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panelLoadSave = new System.Windows.Forms.Panel();
            this.cbPositionType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelConst = new System.Windows.Forms.Panel();
            this.nudFile = new EGMGame.CustomUpDown();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.impactGroupBox1.SuspendLayout();
            this.panelPlatform.SuspendLayout();
            this.panelTile.SuspendLayout();
            this.panelTileTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileTag)).BeginInit();
            this.variablesPanel.SuspendLayout();
            this.constPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).BeginInit();
            this.panelLoadSave.SuspendLayout();
            this.panelConst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFile)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(151, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(70, 282);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(12, 260);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 61;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.panelLoadSave);
            this.impactGroupBox1.Controls.Add(this.cbCompare);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbConditions);
            this.impactGroupBox1.Controls.Add(this.panelPlatform);
            this.impactGroupBox1.Controls.Add(this.panelTile);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(213, 242);
            this.impactGroupBox1.TabIndex = 63;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // cbCompare
            // 
            this.cbCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompare.FormattingEnabled = true;
            this.cbCompare.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Not Equals"});
            this.cbCompare.Location = new System.Drawing.Point(144, 41);
            this.cbCompare.Name = "cbCompare";
            this.cbCompare.Size = new System.Drawing.Size(62, 21);
            this.cbCompare.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Select the condition.";
            // 
            // cbConditions
            // 
            this.cbConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditions.FormattingEnabled = true;
            this.cbConditions.Items.AddRange(new object[] {
            "Tile",
            "Platform",
            "Save/Load File Exist?"});
            this.cbConditions.Location = new System.Drawing.Point(10, 41);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(128, 21);
            this.cbConditions.TabIndex = 51;
            this.cbConditions.SelectedIndexChanged += new System.EventHandler(this.cbConditions_SelectedIndexChanged);
            // 
            // panelPlatform
            // 
            this.panelPlatform.BackColor = System.Drawing.Color.Transparent;
            this.panelPlatform.Controls.Add(this.cbPlatforms);
            this.panelPlatform.Controls.Add(this.label13);
            this.panelPlatform.Location = new System.Drawing.Point(10, 68);
            this.panelPlatform.Name = "panelPlatform";
            this.panelPlatform.Size = new System.Drawing.Size(165, 163);
            this.panelPlatform.TabIndex = 66;
            // 
            // cbPlatforms
            // 
            this.cbPlatforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlatforms.FormattingEnabled = true;
            this.cbPlatforms.Items.AddRange(new object[] {
            "Windows",
            "XBOX",
            "Silverlight"});
            this.cbPlatforms.Location = new System.Drawing.Point(6, 19);
            this.cbPlatforms.Name = "cbPlatforms";
            this.cbPlatforms.Size = new System.Drawing.Size(125, 21);
            this.cbPlatforms.TabIndex = 64;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Select the platform.";
            // 
            // panelTile
            // 
            this.panelTile.BackColor = System.Drawing.Color.Transparent;
            this.panelTile.Controls.Add(this.cbTiles);
            this.panelTile.Controls.Add(this.operationTypeList);
            this.panelTile.Controls.Add(this.label2);
            this.panelTile.Controls.Add(this.panelTileTag);
            this.panelTile.Controls.Add(this.variablesPanel);
            this.panelTile.Controls.Add(this.constPanel);
            this.panelTile.Location = new System.Drawing.Point(10, 68);
            this.panelTile.Name = "panelTile";
            this.panelTile.Size = new System.Drawing.Size(165, 163);
            this.panelTile.TabIndex = 53;
            // 
            // cbTiles
            // 
            this.cbTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTiles.FormattingEnabled = true;
            this.cbTiles.Items.AddRange(new object[] {
            "Tag Is",
            "Has Collision?"});
            this.cbTiles.Location = new System.Drawing.Point(6, 101);
            this.cbTiles.Name = "cbTiles";
            this.cbTiles.Size = new System.Drawing.Size(125, 21);
            this.cbTiles.TabIndex = 64;
            this.cbTiles.SelectedIndexChanged += new System.EventHandler(this.cbTiles_SelectedIndexChanged);
            // 
            // operationTypeList
            // 
            this.operationTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationTypeList.FormattingEnabled = true;
            this.operationTypeList.Items.AddRange(new object[] {
            "Coordinates",
            "Variables"});
            this.operationTypeList.Location = new System.Drawing.Point(6, 16);
            this.operationTypeList.Name = "operationTypeList";
            this.operationTypeList.Size = new System.Drawing.Size(124, 21);
            this.operationTypeList.TabIndex = 63;
            this.operationTypeList.SelectedIndexChanged += new System.EventHandler(this.operationTypeList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Select the position of the tile.";
            // 
            // panelTileTag
            // 
            this.panelTileTag.Controls.Add(this.label3);
            this.panelTileTag.Controls.Add(this.nudTileTag);
            this.panelTileTag.Location = new System.Drawing.Point(3, 128);
            this.panelTileTag.Name = "panelTileTag";
            this.panelTileTag.Size = new System.Drawing.Size(153, 32);
            this.panelTileTag.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(0, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Tile Tag";
            // 
            // nudTileTag
            // 
            this.nudTileTag.Location = new System.Drawing.Point(48, 8);
            this.nudTileTag.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudTileTag.Name = "nudTileTag";
            this.nudTileTag.Size = new System.Drawing.Size(77, 20);
            this.nudTileTag.TabIndex = 0;
            // 
            // variablesPanel
            // 
            this.variablesPanel.BackColor = System.Drawing.Color.Transparent;
            this.variablesPanel.Controls.Add(this.variableYList);
            this.variablesPanel.Controls.Add(this.variableXList);
            this.variablesPanel.Controls.Add(this.label4);
            this.variablesPanel.Controls.Add(this.label5);
            this.variablesPanel.Location = new System.Drawing.Point(6, 43);
            this.variablesPanel.Name = "variablesPanel";
            this.variablesPanel.Size = new System.Drawing.Size(159, 55);
            this.variablesPanel.TabIndex = 62;
            this.variablesPanel.Visible = false;
            // 
            // variableYList
            // 
            this.variableYList.AllowCategories = true;
            this.variableYList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableYList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableYList.FormattingEnabled = true;
            this.variableYList.Location = new System.Drawing.Point(25, 31);
            this.variableYList.Name = "variableYList";
            this.variableYList.SelectedNode = null;
            this.variableYList.Size = new System.Drawing.Size(131, 21);
            this.variableYList.TabIndex = 8;
            // 
            // variableXList
            // 
            this.variableXList.AllowCategories = true;
            this.variableXList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableXList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableXList.FormattingEnabled = true;
            this.variableXList.Location = new System.Drawing.Point(25, 5);
            this.variableXList.Name = "variableXList";
            this.variableXList.SelectedNode = null;
            this.variableXList.Size = new System.Drawing.Size(131, 21);
            this.variableXList.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Y:";
            // 
            // constPanel
            // 
            this.constPanel.BackColor = System.Drawing.Color.Transparent;
            this.constPanel.Controls.Add(this.nudScreenY);
            this.constPanel.Controls.Add(this.label6);
            this.constPanel.Controls.Add(this.nudScreenX);
            this.constPanel.Controls.Add(this.label7);
            this.constPanel.Location = new System.Drawing.Point(6, 43);
            this.constPanel.Name = "constPanel";
            this.constPanel.Size = new System.Drawing.Size(150, 55);
            this.constPanel.TabIndex = 61;
            // 
            // nudScreenY
            // 
            this.nudScreenY.Location = new System.Drawing.Point(25, 29);
            this.nudScreenY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudScreenY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudScreenY.Name = "nudScreenY";
            this.nudScreenY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudScreenY.OnChange = false;
            this.nudScreenY.Size = new System.Drawing.Size(61, 20);
            this.nudScreenY.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(2, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "X:";
            // 
            // nudScreenX
            // 
            this.nudScreenX.Location = new System.Drawing.Point(25, 3);
            this.nudScreenX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudScreenX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudScreenX.Name = "nudScreenX";
            this.nudScreenX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudScreenX.OnChange = false;
            this.nudScreenX.Size = new System.Drawing.Size(61, 20);
            this.nudScreenX.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(2, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Y:";
            // 
            // panelLoadSave
            // 
            this.panelLoadSave.BackColor = System.Drawing.Color.Transparent;
            this.panelLoadSave.Controls.Add(this.cbPositionType);
            this.panelLoadSave.Controls.Add(this.label8);
            this.panelLoadSave.Controls.Add(this.panelConst);
            this.panelLoadSave.Controls.Add(this.panelVariable);
            this.panelLoadSave.Location = new System.Drawing.Point(10, 68);
            this.panelLoadSave.Name = "panelLoadSave";
            this.panelLoadSave.Size = new System.Drawing.Size(165, 163);
            this.panelLoadSave.TabIndex = 67;
            // 
            // cbPositionType
            // 
            this.cbPositionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPositionType.FormattingEnabled = true;
            this.cbPositionType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbPositionType.Location = new System.Drawing.Point(6, 19);
            this.cbPositionType.Name = "cbPositionType";
            this.cbPositionType.Size = new System.Drawing.Size(130, 21);
            this.cbPositionType.TabIndex = 57;
            this.cbPositionType.SelectedIndexChanged += new System.EventHandler(this.cbPositionType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Enter the file number.";
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.nudFile);
            this.panelConst.Location = new System.Drawing.Point(3, 46);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(156, 33);
            this.panelConst.TabIndex = 59;
            this.panelConst.Visible = false;
            // 
            // nudFile
            // 
            this.nudFile.Location = new System.Drawing.Point(3, 4);
            this.nudFile.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudFile.Name = "nudFile";
            this.nudFile.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFile.OnChange = false;
            this.nudFile.Size = new System.Drawing.Size(61, 20);
            this.nudFile.TabIndex = 1;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(3, 46);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(156, 36);
            this.panelVariable.TabIndex = 58;
            this.panelVariable.Visible = false;
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(3, 4);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(130, 21);
            this.cbVariable.TabIndex = 46;
            // 
            // OtherConditionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(238, 317);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OtherConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Other Conditions";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelPlatform.ResumeLayout(false);
            this.panelPlatform.PerformLayout();
            this.panelTile.ResumeLayout(false);
            this.panelTile.PerformLayout();
            this.panelTileTag.ResumeLayout(false);
            this.panelTileTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileTag)).EndInit();
            this.variablesPanel.ResumeLayout(false);
            this.variablesPanel.PerformLayout();
            this.constPanel.ResumeLayout(false);
            this.constPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).EndInit();
            this.panelLoadSave.ResumeLayout(false);
            this.panelLoadSave.PerformLayout();
            this.panelConst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFile)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbConditions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.CheckBox elseBranc;
        private System.Windows.Forms.Panel panelTile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTileTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTileTag;
        private EGMGame.Controls.ImpactUI.ImpactPanel variablesPanel;
        private EGMGame.Controls.Game.VariableComboBox variableYList;
        private EGMGame.Controls.Game.VariableComboBox variableXList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox operationTypeList;
        private System.Windows.Forms.Label label2;
        private EGMGame.Controls.ImpactUI.ImpactPanel constPanel;
        private CustomUpDown nudScreenY;
        private System.Windows.Forms.Label label6;
        private CustomUpDown nudScreenX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTiles;
        private System.Windows.Forms.ComboBox cbCompare;
        private System.Windows.Forms.Panel panelPlatform;
        private System.Windows.Forms.ComboBox cbPlatforms;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelLoadSave;
        private System.Windows.Forms.ComboBox cbPositionType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelConst;
        private CustomUpDown nudFile;
        private System.Windows.Forms.Panel panelVariable;
        private Controls.Game.VariableComboBox cbVariable;

    }
}