namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class ShowParticleDialog
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
            this.chkGlobal = new System.Windows.Forms.CheckBox();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbParticles = new EGMGame.Controls.Game.ParticleComboBox(this.components);
            this.nudParticleIndex = new EGMGame.CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.panelEvent = new System.Windows.Forms.Panel();
            this.cbOnEvent = new EGMGame.Controls.Game.MapEventComboBox(this.components);
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
            this.nudLayer = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnShowMap = new System.Windows.Forms.Button();
            this.impactGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudParticleIndex)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.panelEvent.SuspendLayout();
            this.variablesPanel.SuspendLayout();
            this.coordinatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // chkGlobal
            // 
            this.chkGlobal.AutoSize = true;
            this.chkGlobal.BackColor = System.Drawing.Color.Transparent;
            this.chkGlobal.Location = new System.Drawing.Point(139, 256);
            this.chkGlobal.Name = "chkGlobal";
            this.chkGlobal.Size = new System.Drawing.Size(56, 17);
            this.chkGlobal.TabIndex = 69;
            this.chkGlobal.Text = "Global";
            this.chkGlobal.UseVisualStyleBackColor = false;
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.Controls.Add(this.cbParticles);
            this.impactGroupBox4.Controls.Add(this.nudParticleIndex);
            this.impactGroupBox4.Controls.Add(this.label1);
            this.impactGroupBox4.Controls.Add(this.label10);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(183, 113);
            this.impactGroupBox4.TabIndex = 67;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Particle";
            // 
            // cbParticles
            // 
            this.cbParticles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbParticles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParticles.FormattingEnabled = true;
            this.cbParticles.Location = new System.Drawing.Point(7, 82);
            this.cbParticles.Name = "cbParticles";
            this.cbParticles.Noneable = true;
            this.cbParticles.SelectedNode = null;
            this.cbParticles.Size = new System.Drawing.Size(139, 21);
            this.cbParticles.TabIndex = 23;
            // 
            // nudParticleIndex
            // 
            this.nudParticleIndex.Location = new System.Drawing.Point(8, 41);
            this.nudParticleIndex.Name = "nudParticleIndex";
            this.nudParticleIndex.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudParticleIndex.OnChange = false;
            this.nudParticleIndex.Size = new System.Drawing.Size(43, 20);
            this.nudParticleIndex.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Choose the index of the particle.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(5, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Choose the particle system to show.";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(120, 286);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 68;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(39, 286);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 65;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.operationTypeList);
            this.impactGroupBox1.Controls.Add(this.coordinatePanel);
            this.impactGroupBox1.Controls.Add(this.panelEvent);
            this.impactGroupBox1.Controls.Add(this.variablesPanel);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 131);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(183, 118);
            this.impactGroupBox1.TabIndex = 66;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Position";
            // 
            // panelEvent
            // 
            this.panelEvent.BackColor = System.Drawing.Color.Transparent;
            this.panelEvent.Controls.Add(this.cbOnEvent);
            this.panelEvent.Location = new System.Drawing.Point(12, 51);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(156, 57);
            this.panelEvent.TabIndex = 53;
            this.panelEvent.Visible = false;
            // 
            // cbOnEvent
            // 
            this.cbOnEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOnEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOnEvent.FormattingEnabled = true;
            this.cbOnEvent.Location = new System.Drawing.Point(0, 3);
            this.cbOnEvent.Name = "cbOnEvent";
            this.cbOnEvent.ShowPlayer = true;
            this.cbOnEvent.Size = new System.Drawing.Size(143, 21);
            this.cbOnEvent.TabIndex = 47;
            this.cbOnEvent.ThisEvent = true;
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
            this.variableYList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableYList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableYList.FormattingEnabled = true;
            this.variableYList.Location = new System.Drawing.Point(25, 32);
            this.variableYList.Name = "variableYList";
            this.variableYList.SelectedNode = null;
            this.variableYList.Size = new System.Drawing.Size(99, 21);
            this.variableYList.TabIndex = 8;
            // 
            // variableXList
            // 
            this.variableXList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableXList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableXList.FormattingEnabled = true;
            this.variableXList.Location = new System.Drawing.Point(25, 5);
            this.variableXList.Name = "variableXList";
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
            "Event"});
            this.operationTypeList.Location = new System.Drawing.Point(12, 24);
            this.operationTypeList.Name = "operationTypeList";
            this.operationTypeList.Size = new System.Drawing.Size(124, 21);
            this.operationTypeList.TabIndex = 11;
            this.operationTypeList.SelectedIndexChanged += new System.EventHandler(this.operationTypeList_SelectedIndexChanged_1);
            // 
            // coordinatePanel
            // 
            this.coordinatePanel.BackColor = System.Drawing.Color.Transparent;
            this.coordinatePanel.Controls.Add(this.btnShowMap);
            this.coordinatePanel.Controls.Add(this.nudScreenY);
            this.coordinatePanel.Controls.Add(this.label4);
            this.coordinatePanel.Controls.Add(this.nudScreenX);
            this.coordinatePanel.Controls.Add(this.label5);
            this.coordinatePanel.Location = new System.Drawing.Point(12, 51);
            this.coordinatePanel.Name = "coordinatePanel";
            this.coordinatePanel.Size = new System.Drawing.Size(169, 55);
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
            // nudLayer
            // 
            this.nudLayer.Location = new System.Drawing.Point(49, 255);
            this.nudLayer.Name = "nudLayer";
            this.nudLayer.Size = new System.Drawing.Size(55, 20);
            this.nudLayer.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(9, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Layer";
            // 
            // btnShowMap
            // 
            this.btnShowMap.Location = new System.Drawing.Point(92, 3);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(72, 23);
            this.btnShowMap.TabIndex = 57;
            this.btnShowMap.Text = "Show Map";
            this.btnShowMap.UseVisualStyleBackColor = true;
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            // 
            // ShowParticleDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(207, 316);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudLayer);
            this.Controls.Add(this.chkGlobal);
            this.Controls.Add(this.impactGroupBox4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowParticleDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Particle";
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudParticleIndex)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.panelEvent.ResumeLayout(false);
            this.variablesPanel.ResumeLayout(false);
            this.variablesPanel.PerformLayout();
            this.coordinatePanel.ResumeLayout(false);
            this.coordinatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkGlobal;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private EGMGame.Controls.Game.ParticleComboBox cbParticles;
        private CustomUpDown nudParticleIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactPanel variablesPanel;
        private EGMGame.Controls.Game.VariableComboBox variableYList;
        private EGMGame.Controls.Game.VariableComboBox variableXList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox operationTypeList;
        private EGMGame.Controls.ImpactUI.ImpactPanel coordinatePanel;
        private CustomUpDown nudScreenY;
        private System.Windows.Forms.Label label4;
        private CustomUpDown nudScreenX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudLayer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelEvent;
        private EGMGame.Controls.Game.MapEventComboBox cbOnEvent;
        private System.Windows.Forms.Button btnShowMap;

    }
}