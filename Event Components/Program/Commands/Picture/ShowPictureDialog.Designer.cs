namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class ShowPictureDialog
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
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.nudLayer = new EGMGame.CustomUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.picIndex = new EGMGame.CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.materialsList = new EGMGame.Controls.Game.MaterialsComboBox(this.components);
            this.cbSetDimensions = new System.Windows.Forms.CheckBox();
            this.panel1 = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.nudPicHeight = new EGMGame.CustomUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nudPicWidth = new EGMGame.CustomUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.variablesPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.variableYList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.variableXList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.operationTypeList = new System.Windows.Forms.ComboBox();
            this.coordinatePanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.nudScreenY = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudScreenX = new EGMGame.CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkGlobal = new System.Windows.Forms.CheckBox();
            this.cbOriginType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.impactGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPicHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPicWidth)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.variablesPanel.SuspendLayout();
            this.coordinatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(131, 449);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 23;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(49, 449);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.CanCollapse = false;
            this.impactGroupBox4.Controls.Add(this.label7);
            this.impactGroupBox4.Controls.Add(this.cbOriginType);
            this.impactGroupBox4.Controls.Add(this.nudLayer);
            this.impactGroupBox4.Controls.Add(this.label6);
            this.impactGroupBox4.Controls.Add(this.picIndex);
            this.impactGroupBox4.Controls.Add(this.label1);
            this.impactGroupBox4.Controls.Add(this.materialsList);
            this.impactGroupBox4.Controls.Add(this.cbSetDimensions);
            this.impactGroupBox4.Controls.Add(this.panel1);
            this.impactGroupBox4.Controls.Add(this.label10);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Image = null;
            this.impactGroupBox4.IsCollapsed = false;
            this.impactGroupBox4.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(194, 280);
            this.impactGroupBox4.TabIndex = 22;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Picture";
            // 
            // nudLayer
            // 
            this.nudLayer.Location = new System.Drawing.Point(8, 80);
            this.nudLayer.Name = "nudLayer";
            this.nudLayer.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudLayer.OnChange = false;
            this.nudLayer.Size = new System.Drawing.Size(43, 20);
            this.nudLayer.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(5, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Choose the layer to display picture on.";
            // 
            // picIndex
            // 
            this.picIndex.Location = new System.Drawing.Point(8, 41);
            this.picIndex.Name = "picIndex";
            this.picIndex.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.picIndex.OnChange = false;
            this.picIndex.Size = new System.Drawing.Size(43, 20);
            this.picIndex.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Choose the index of the picture.";
            // 
            // materialsList
            // 
            this.materialsList.AllowDrop = true;
            this.materialsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.materialsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialsList.FormattingEnabled = true;
            this.materialsList.Location = new System.Drawing.Point(7, 119);
            this.materialsList.Name = "materialsList";
            this.materialsList.SelectedNode = null;
            this.materialsList.Size = new System.Drawing.Size(115, 21);
            this.materialsList.TabIndex = 21;
            // 
            // cbSetDimensions
            // 
            this.cbSetDimensions.AutoSize = true;
            this.cbSetDimensions.BackColor = System.Drawing.Color.Transparent;
            this.cbSetDimensions.Location = new System.Drawing.Point(7, 188);
            this.cbSetDimensions.Name = "cbSetDimensions";
            this.cbSetDimensions.Size = new System.Drawing.Size(99, 17);
            this.cbSetDimensions.TabIndex = 20;
            this.cbSetDimensions.Text = "Set Dimensions";
            this.cbSetDimensions.UseVisualStyleBackColor = false;
            this.cbSetDimensions.CheckedChanged += new System.EventHandler(this.cbSetDimensions_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.nudPicHeight);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.nudPicWidth);
            this.panel1.Location = new System.Drawing.Point(6, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 56);
            this.panel1.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(3, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Width:";
            // 
            // nudPicHeight
            // 
            this.nudPicHeight.Enabled = false;
            this.nudPicHeight.Location = new System.Drawing.Point(47, 30);
            this.nudPicHeight.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudPicHeight.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudPicHeight.Name = "nudPicHeight";
            this.nudPicHeight.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPicHeight.OnChange = false;
            this.nudPicHeight.Size = new System.Drawing.Size(61, 20);
            this.nudPicHeight.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(3, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Height:";
            // 
            // nudPicWidth
            // 
            this.nudPicWidth.Enabled = false;
            this.nudPicWidth.Location = new System.Drawing.Point(47, 4);
            this.nudPicWidth.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudPicWidth.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudPicWidth.Name = "nudPicWidth";
            this.nudPicWidth.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPicWidth.OnChange = false;
            this.nudPicWidth.Size = new System.Drawing.Size(61, 20);
            this.nudPicWidth.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(5, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Choose the material for the picture.";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.variablesPanel);
            this.impactGroupBox1.Controls.Add(this.operationTypeList);
            this.impactGroupBox1.Controls.Add(this.coordinatePanel);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 298);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(194, 118);
            this.impactGroupBox1.TabIndex = 19;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Position";
            // 
            // variablesPanel
            // 
            this.variablesPanel.BackColor = System.Drawing.Color.Transparent;
            this.variablesPanel.Controls.Add(this.variableYList);
            this.variablesPanel.Controls.Add(this.variableXList);
            this.variablesPanel.Controls.Add(this.label2);
            this.variablesPanel.Controls.Add(this.label3);
            this.variablesPanel.Location = new System.Drawing.Point(12, 51);
            this.variablesPanel.Name = "variablesPanel";
            this.variablesPanel.Size = new System.Drawing.Size(150, 55);
            this.variablesPanel.TabIndex = 11;
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
            this.variableYList.Noneable = false;
            this.variableYList.SelectedNode = null;
            this.variableYList.Size = new System.Drawing.Size(99, 21);
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
            this.variableXList.Noneable = false;
            this.variableXList.SelectedNode = null;
            this.variableXList.Size = new System.Drawing.Size(99, 21);
            this.variableXList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y:";
            // 
            // operationTypeList
            // 
            this.operationTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationTypeList.FormattingEnabled = true;
            this.operationTypeList.Items.AddRange(new object[] {
            "Coordinates",
            "Variables",
            "Center"});
            this.operationTypeList.Location = new System.Drawing.Point(12, 24);
            this.operationTypeList.Name = "operationTypeList";
            this.operationTypeList.Size = new System.Drawing.Size(110, 21);
            this.operationTypeList.TabIndex = 11;
            this.operationTypeList.SelectedIndexChanged += new System.EventHandler(this.operationTypeList_SelectedIndexChanged);
            // 
            // coordinatePanel
            // 
            this.coordinatePanel.BackColor = System.Drawing.Color.Transparent;
            this.coordinatePanel.Controls.Add(this.nudScreenY);
            this.coordinatePanel.Controls.Add(this.label4);
            this.coordinatePanel.Controls.Add(this.nudScreenX);
            this.coordinatePanel.Controls.Add(this.label5);
            this.coordinatePanel.Location = new System.Drawing.Point(12, 51);
            this.coordinatePanel.Name = "coordinatePanel";
            this.coordinatePanel.Size = new System.Drawing.Size(150, 55);
            this.coordinatePanel.TabIndex = 10;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(2, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "X:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(2, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Y:";
            // 
            // chkGlobal
            // 
            this.chkGlobal.AutoSize = true;
            this.chkGlobal.BackColor = System.Drawing.Color.Transparent;
            this.chkGlobal.Location = new System.Drawing.Point(12, 422);
            this.chkGlobal.Name = "chkGlobal";
            this.chkGlobal.Size = new System.Drawing.Size(56, 17);
            this.chkGlobal.TabIndex = 64;
            this.chkGlobal.Text = "Global";
            this.toolTip1.SetToolTip(this.chkGlobal, "If checked, the effect will be displayed in\r\nboth the gameplay screen and the men" +
                    "u screen.");
            this.chkGlobal.UseVisualStyleBackColor = false;
            // 
            // cbOriginType
            // 
            this.cbOriginType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOriginType.FormattingEnabled = true;
            this.cbOriginType.Items.AddRange(new object[] {
            "Top Left Corner",
            "Center"});
            this.cbOriginType.Location = new System.Drawing.Point(8, 161);
            this.cbOriginType.Name = "cbOriginType";
            this.cbOriginType.Size = new System.Drawing.Size(114, 21);
            this.cbOriginType.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(5, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Choose the picture\'s center.";
            // 
            // ShowPictureDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(214, 484);
            this.Controls.Add(this.chkGlobal);
            this.Controls.Add(this.impactGroupBox4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowPictureDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Picture";
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPicHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPicWidth)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.variablesPanel.ResumeLayout(false);
            this.variablesPanel.PerformLayout();
            this.coordinatePanel.ResumeLayout(false);
            this.coordinatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbSetDimensions;
        private ImpactUI.ImpactPanel panel1;
        private System.Windows.Forms.Label label11;
        private CustomUpDown nudPicHeight;
        private System.Windows.Forms.Label label12;
        private CustomUpDown nudPicWidth;
        private ImpactUI.ImpactPanel coordinatePanel;
        private CustomUpDown nudScreenY;
        private System.Windows.Forms.Label label4;
        private CustomUpDown nudScreenX;
        private System.Windows.Forms.Label label5;
        private EGMGame.Controls.Game.MaterialsComboBox materialsList;
        private System.Windows.Forms.ComboBox operationTypeList;
        private ImpactUI.ImpactPanel variablesPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private EGMGame.Controls.Game.VariableComboBox variableYList;
        private EGMGame.Controls.Game.VariableComboBox variableXList;
        private CustomUpDown picIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkGlobal;
        private CustomUpDown nudLayer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbOriginType;
    }
}