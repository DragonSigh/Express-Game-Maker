namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class ShowAnimationDialog
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.coordinatePanel = new System.Windows.Forms.Panel();
            this.nudLayer2 = new EGMGame.CustomUpDown();
            this.layerLabel2 = new System.Windows.Forms.Label();
            this.cbCoordinate2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudX = new EGMGame.CustomUpDown();
            this.nudY = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eventPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.eventsList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.variablePanel = new System.Windows.Forms.Panel();
            this.nudLayer1 = new EGMGame.CustomUpDown();
            this.layerLbl1 = new System.Windows.Forms.Label();
            this.cbCoordinate1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVariableX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbVariableY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.operationsTypeList = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAnimations = new EGMGame.Controls.Game.AnimationComboBox(this.components);
            this.cbActions = new EGMGame.Controls.Game.AnimationActionComboBox(this.components);
            this.impactGroupBox2.SuspendLayout();
            this.coordinatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.eventPanel.SuspendLayout();
            this.variablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer1)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(124, 368);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 17;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(43, 368);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 16;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.eventPanel);
            this.impactGroupBox2.Controls.Add(this.variablePanel);
            this.impactGroupBox2.Controls.Add(this.label7);
            this.impactGroupBox2.Controls.Add(this.operationsTypeList);
            this.impactGroupBox2.Controls.Add(this.coordinatePanel);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 129);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(187, 233);
            this.impactGroupBox2.TabIndex = 4;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Settings";
            // 
            // coordinatePanel
            // 
            this.coordinatePanel.BackColor = System.Drawing.Color.Transparent;
            this.coordinatePanel.Controls.Add(this.nudLayer2);
            this.coordinatePanel.Controls.Add(this.layerLabel2);
            this.coordinatePanel.Controls.Add(this.cbCoordinate2);
            this.coordinatePanel.Controls.Add(this.label10);
            this.coordinatePanel.Controls.Add(this.nudX);
            this.coordinatePanel.Controls.Add(this.nudY);
            this.coordinatePanel.Controls.Add(this.label2);
            this.coordinatePanel.Controls.Add(this.label3);
            this.coordinatePanel.Location = new System.Drawing.Point(10, 68);
            this.coordinatePanel.Name = "coordinatePanel";
            this.coordinatePanel.Size = new System.Drawing.Size(170, 156);
            this.coordinatePanel.TabIndex = 63;
            this.coordinatePanel.Visible = false;
            // 
            // nudLayer2
            // 
            this.nudLayer2.Location = new System.Drawing.Point(7, 125);
            this.nudLayer2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLayer2.Name = "nudLayer2";
            this.nudLayer2.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudLayer2.OnChange = false;
            this.nudLayer2.Size = new System.Drawing.Size(53, 20);
            this.nudLayer2.TabIndex = 64;
            // 
            // layerLabel2
            // 
            this.layerLabel2.AutoSize = true;
            this.layerLabel2.BackColor = System.Drawing.Color.Transparent;
            this.layerLabel2.Location = new System.Drawing.Point(4, 96);
            this.layerLabel2.Name = "layerLabel2";
            this.layerLabel2.Size = new System.Drawing.Size(154, 26);
            this.layerLabel2.TabIndex = 63;
            this.layerLabel2.Text = "The layer the animation should \r\nappear on.";
            // 
            // cbCoordinate2
            // 
            this.cbCoordinate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinate2.FormattingEnabled = true;
            this.cbCoordinate2.Items.AddRange(new object[] {
            "Map",
            "Screen"});
            this.cbCoordinate2.Location = new System.Drawing.Point(7, 72);
            this.cbCoordinate2.Name = "cbCoordinate2";
            this.cbCoordinate2.Size = new System.Drawing.Size(100, 21);
            this.cbCoordinate2.TabIndex = 62;
            this.cbCoordinate2.SelectedIndexChanged += new System.EventHandler(this.cbCoordinate2_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(4, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Choose coordiante type.";
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(26, 5);
            this.nudX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudX.OnChange = false;
            this.nudX.Size = new System.Drawing.Size(53, 20);
            this.nudX.TabIndex = 53;
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(26, 31);
            this.nudY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudY.OnChange = false;
            this.nudY.Size = new System.Drawing.Size(53, 20);
            this.nudY.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Y:";
            // 
            // eventPanel
            // 
            this.eventPanel.BackColor = System.Drawing.Color.Transparent;
            this.eventPanel.Controls.Add(this.label8);
            this.eventPanel.Controls.Add(this.eventsList);
            this.eventPanel.Location = new System.Drawing.Point(10, 68);
            this.eventPanel.Name = "eventPanel";
            this.eventPanel.Size = new System.Drawing.Size(141, 50);
            this.eventPanel.TabIndex = 60;
            this.eventPanel.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(0, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Choose event.";
            // 
            // eventsList
            // 
            this.eventsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventsList.FormattingEnabled = true;
            this.eventsList.Location = new System.Drawing.Point(0, 22);
            this.eventsList.Name = "eventsList";
            this.eventsList.ShowPlayer = true;
            this.eventsList.ShowTarget = true;
            this.eventsList.ShowTargets = false;
            this.eventsList.Size = new System.Drawing.Size(104, 21);
            this.eventsList.TabIndex = 59;
            this.eventsList.ThisEvent = true;
            // 
            // variablePanel
            // 
            this.variablePanel.BackColor = System.Drawing.Color.Transparent;
            this.variablePanel.Controls.Add(this.nudLayer1);
            this.variablePanel.Controls.Add(this.layerLbl1);
            this.variablePanel.Controls.Add(this.cbCoordinate1);
            this.variablePanel.Controls.Add(this.label9);
            this.variablePanel.Controls.Add(this.label4);
            this.variablePanel.Controls.Add(this.label5);
            this.variablePanel.Controls.Add(this.cbVariableX);
            this.variablePanel.Controls.Add(this.cbVariableY);
            this.variablePanel.Location = new System.Drawing.Point(10, 68);
            this.variablePanel.Name = "variablePanel";
            this.variablePanel.Size = new System.Drawing.Size(170, 156);
            this.variablePanel.TabIndex = 61;
            this.variablePanel.Visible = false;
            // 
            // nudLayer1
            // 
            this.nudLayer1.Location = new System.Drawing.Point(7, 125);
            this.nudLayer1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLayer1.Name = "nudLayer1";
            this.nudLayer1.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudLayer1.OnChange = false;
            this.nudLayer1.Size = new System.Drawing.Size(53, 20);
            this.nudLayer1.TabIndex = 66;
            // 
            // layerLbl1
            // 
            this.layerLbl1.AutoSize = true;
            this.layerLbl1.BackColor = System.Drawing.Color.Transparent;
            this.layerLbl1.Location = new System.Drawing.Point(4, 96);
            this.layerLbl1.Name = "layerLbl1";
            this.layerLbl1.Size = new System.Drawing.Size(154, 26);
            this.layerLbl1.TabIndex = 65;
            this.layerLbl1.Text = "The layer the animation should \r\nappear on.";
            // 
            // cbCoordinate1
            // 
            this.cbCoordinate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoordinate1.FormattingEnabled = true;
            this.cbCoordinate1.Items.AddRange(new object[] {
            "Map",
            "Screen"});
            this.cbCoordinate1.Location = new System.Drawing.Point(7, 72);
            this.cbCoordinate1.Name = "cbCoordinate1";
            this.cbCoordinate1.Size = new System.Drawing.Size(100, 21);
            this.cbCoordinate1.TabIndex = 62;
            this.cbCoordinate1.SelectedIndexChanged += new System.EventHandler(this.cbCoordinate1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(4, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Choose coordiante type.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(4, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Y:";
            // 
            // cbVariableX
            // 
            this.cbVariableX.AllowCategories = true;
            this.cbVariableX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableX.FormattingEnabled = true;
            this.cbVariableX.Location = new System.Drawing.Point(24, 3);
            this.cbVariableX.Name = "cbVariableX";
            this.cbVariableX.Noneable = false;
            this.cbVariableX.SelectedNode = null;
            this.cbVariableX.Size = new System.Drawing.Size(104, 21);
            this.cbVariableX.TabIndex = 51;
            // 
            // cbVariableY
            // 
            this.cbVariableY.AllowCategories = true;
            this.cbVariableY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableY.FormattingEnabled = true;
            this.cbVariableY.Location = new System.Drawing.Point(24, 30);
            this.cbVariableY.Name = "cbVariableY";
            this.cbVariableY.Noneable = false;
            this.cbVariableY.SelectedNode = null;
            this.cbVariableY.Size = new System.Drawing.Size(104, 21);
            this.cbVariableY.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(7, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Choose where to show animation.";
            // 
            // operationsTypeList
            // 
            this.operationsTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationsTypeList.FormattingEnabled = true;
            this.operationsTypeList.Items.AddRange(new object[] {
            "Coordinates",
            "Variables",
            "Event"});
            this.operationsTypeList.Location = new System.Drawing.Point(10, 41);
            this.operationsTypeList.Name = "operationsTypeList";
            this.operationsTypeList.Size = new System.Drawing.Size(107, 21);
            this.operationsTypeList.TabIndex = 57;
            this.operationsTypeList.SelectedIndexChanged += new System.EventHandler(this.operationsTypeList_SelectedIndexChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.label11);
            this.impactGroupBox1.Controls.Add(this.cbDirection);
            this.impactGroupBox1.Controls.Add(this.label6);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbAnimations);
            this.impactGroupBox1.Controls.Add(this.cbActions);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(187, 111);
            this.impactGroupBox1.TabIndex = 3;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Animation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(7, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Direction:";
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbDirection.Location = new System.Drawing.Point(69, 82);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(106, 21);
            this.cbDirection.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Action:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Animation:";
            // 
            // cbAnimations
            // 
            this.cbAnimations.AllowCategories = true;
            this.cbAnimations.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAnimations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimations.FormattingEnabled = true;
            this.cbAnimations.Location = new System.Drawing.Point(69, 28);
            this.cbAnimations.Name = "cbAnimations";
            this.cbAnimations.Noneable = true;
            this.cbAnimations.SelectedNode = null;
            this.cbAnimations.Size = new System.Drawing.Size(106, 21);
            this.cbAnimations.TabIndex = 0;
            this.cbAnimations.SelectedIndexChanged += new System.EventHandler(this.cbAnimations_SelectedIndexChanged);
            // 
            // cbActions
            // 
            this.cbActions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Location = new System.Drawing.Point(69, 55);
            this.cbActions.Name = "cbActions";
            this.cbActions.Noneable = false;
            this.cbActions.Size = new System.Drawing.Size(106, 21);
            this.cbActions.TabIndex = 1;
            // 
            // ShowAnimationDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(209, 403);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowAnimationDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Animation";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.coordinatePanel.ResumeLayout(false);
            this.coordinatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.eventPanel.ResumeLayout(false);
            this.eventPanel.PerformLayout();
            this.variablePanel.ResumeLayout(false);
            this.variablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer1)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.Game.AnimationComboBox cbAnimations;
        private EGMGame.Controls.Game.AnimationActionComboBox cbActions;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.Game.VariableComboBox cbVariableY;
        private EGMGame.Controls.Game.VariableComboBox cbVariableX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CustomUpDown nudY;
        private CustomUpDown nudX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private EGMGame.Controls.Game.MapEventComboBox eventsList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox operationsTypeList;
        private System.Windows.Forms.Panel variablePanel;
        private System.Windows.Forms.ComboBox cbCoordinate1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel eventPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel coordinatePanel;
        private System.Windows.Forms.ComboBox cbCoordinate2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private CustomUpDown nudLayer2;
        private System.Windows.Forms.Label layerLabel2;
        private CustomUpDown nudLayer1;
        private System.Windows.Forms.Label layerLbl1;

    }
}