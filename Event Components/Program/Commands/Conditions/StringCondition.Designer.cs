namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.ConditionDialogs
{
    partial class StringCondition
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
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.operationsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.stringPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.stringComboBox1 = new EGMGame.Controls.Game.StringComboBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.textPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dataPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.numericDatasetList = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.databaseItemList = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.databaseList = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.valueTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.operationsList = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.impactGroupBox1.SuspendLayout();
            this.operationsBox.SuspendLayout();
            this.stringPanel.SuspendLayout();
            this.textPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(166, 230);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 80;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
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
            this.impactGroupBox1.Location = new System.Drawing.Point(8, 13);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(145, 234);
            this.impactGroupBox1.TabIndex = 79;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Strings";
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
            this.addRemoveList.Size = new System.Drawing.Size(137, 204);
            this.addRemoveList.TabIndex = 1;
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // operationsBox
            // 
            this.operationsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.operationsBox.Controls.Add(this.stringPanel);
            this.operationsBox.Controls.Add(this.textPanel);
            this.operationsBox.Controls.Add(this.dataPanel);
            this.operationsBox.Controls.Add(this.label11);
            this.operationsBox.Controls.Add(this.label10);
            this.operationsBox.Controls.Add(this.valueTypeBox);
            this.operationsBox.Controls.Add(this.label1);
            this.operationsBox.Controls.Add(this.operationsList);
            this.operationsBox.Enabled = false;
            this.operationsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.operationsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.operationsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.operationsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.operationsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.operationsBox.Location = new System.Drawing.Point(166, 13);
            this.operationsBox.Name = "operationsBox";
            this.operationsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.operationsBox.Size = new System.Drawing.Size(218, 211);
            this.operationsBox.TabIndex = 78;
            this.operationsBox.TabStop = false;
            this.operationsBox.Text = "Operation";
            // 
            // stringPanel
            // 
            this.stringPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stringPanel.BackColor = System.Drawing.Color.Transparent;
            this.stringPanel.Controls.Add(this.stringComboBox1);
            this.stringPanel.Controls.Add(this.label13);
            this.stringPanel.Location = new System.Drawing.Point(7, 117);
            this.stringPanel.Name = "stringPanel";
            this.stringPanel.Size = new System.Drawing.Size(164, 44);
            this.stringPanel.TabIndex = 91;
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
            this.textPanel.Location = new System.Drawing.Point(7, 117);
            this.textPanel.Name = "textPanel";
            this.textPanel.Size = new System.Drawing.Size(164, 44);
            this.textPanel.TabIndex = 90;
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
            this.dataPanel.Location = new System.Drawing.Point(7, 117);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(204, 85);
            this.dataPanel.TabIndex = 89;
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
            this.label4.Location = new System.Drawing.Point(180, 35);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(4, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "Choose the value to compare to.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(4, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Choose the compare type for the condition.";
            // 
            // valueTypeBox
            // 
            this.valueTypeBox.DisplayMember = "Constant";
            this.valueTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueTypeBox.FormattingEnabled = true;
            this.valueTypeBox.Items.AddRange(new object[] {
            "Text",
            "String",
            "Data"});
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
            "(!=) Does Not Equal"});
            this.operationsList.Location = new System.Drawing.Point(7, 44);
            this.operationsList.Name = "operationsList";
            this.operationsList.Size = new System.Drawing.Size(121, 21);
            this.operationsList.TabIndex = 2;
            this.operationsList.ValueMember = "Add";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(309, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(228, 254);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 75;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // StringCondition
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(396, 289);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.operationsBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StringCondition";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "String Condition";
            this.impactGroupBox1.ResumeLayout(false);
            this.operationsBox.ResumeLayout(false);
            this.operationsBox.PerformLayout();
            this.stringPanel.ResumeLayout(false);
            this.stringPanel.PerformLayout();
            this.textPanel.ResumeLayout(false);
            this.textPanel.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox elseBranc;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox operationsBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox valueTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox operationsList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.ImpactUI.ImpactPanel stringPanel;
        private EGMGame.Controls.Game.StringComboBox stringComboBox1;
        private System.Windows.Forms.Label label13;
        private EGMGame.Controls.ImpactUI.ImpactPanel textPanel;
        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label22;
        private EGMGame.Controls.ImpactUI.ImpactPanel dataPanel;
        private EGMGame.Controls.Game.DataPropertyComboBox numericDatasetList;
        private EGMGame.Controls.Game.DatabaseComboBox databaseItemList;
        private EGMGame.Controls.Game.DatabaseComboBox databaseList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
    }
}