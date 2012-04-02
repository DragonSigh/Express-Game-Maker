namespace EGMGame
{
    partial class ScrollCameraToDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSpeed = new EGMGame.CustomUpDown();
            this.constantPanel = new System.Windows.Forms.Panel();
            this.nudY = new EGMGame.CustomUpDown();
            this.nudX = new EGMGame.CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.showMapBtn = new System.Windows.Forms.Button();
            this.coordinateType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.variablePanel = new System.Windows.Forms.Panel();
            this.variableYList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.variableXList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.constantPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            this.variablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(116, 209);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 32;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(35, 209);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 31;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.constantPanel);
            this.impactGroupBox1.Controls.Add(this.coordinateType);
            this.impactGroupBox1.Controls.Add(this.label4);
            this.impactGroupBox1.Controls.Add(this.variablePanel);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.nudSpeed);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(179, 191);
            this.impactGroupBox1.TabIndex = 30;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Scroll Camera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(117, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Frames";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Speed";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(61, 164);
            this.nudSpeed.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpeed.OnChange = true;
            this.nudSpeed.Size = new System.Drawing.Size(50, 20);
            this.nudSpeed.TabIndex = 4;
            this.nudSpeed.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // constantPanel
            // 
            this.constantPanel.BackColor = System.Drawing.Color.Transparent;
            this.constantPanel.Controls.Add(this.nudY);
            this.constantPanel.Controls.Add(this.nudX);
            this.constantPanel.Controls.Add(this.label5);
            this.constantPanel.Controls.Add(this.label6);
            this.constantPanel.Controls.Add(this.showMapBtn);
            this.constantPanel.Location = new System.Drawing.Point(10, 68);
            this.constantPanel.Name = "constantPanel";
            this.constantPanel.Size = new System.Drawing.Size(137, 90);
            this.constantPanel.TabIndex = 26;
            this.constantPanel.Visible = false;
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(51, 31);
            this.nudY.Maximum = new decimal(new int[] {
            999999,
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
            this.nudY.Size = new System.Drawing.Size(48, 20);
            this.nudY.TabIndex = 22;
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(51, 4);
            this.nudX.Maximum = new decimal(new int[] {
            999999,
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
            this.nudX.Size = new System.Drawing.Size(48, 20);
            this.nudX.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Map X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Map Y";
            // 
            // showMapBtn
            // 
            this.showMapBtn.Location = new System.Drawing.Point(10, 55);
            this.showMapBtn.Name = "showMapBtn";
            this.showMapBtn.Size = new System.Drawing.Size(89, 24);
            this.showMapBtn.TabIndex = 18;
            this.showMapBtn.Text = "Show Map";
            this.showMapBtn.UseVisualStyleBackColor = true;
            this.showMapBtn.Click += new System.EventHandler(this.showMapBtn_Click);
            // 
            // coordinateType
            // 
            this.coordinateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coordinateType.FormattingEnabled = true;
            this.coordinateType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.coordinateType.Location = new System.Drawing.Point(10, 41);
            this.coordinateType.Name = "coordinateType";
            this.coordinateType.Size = new System.Drawing.Size(113, 21);
            this.coordinateType.TabIndex = 25;
            this.coordinateType.SelectedIndexChanged += new System.EventHandler(this.coordinateType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Choose the coordinate type.";
            // 
            // variablePanel
            // 
            this.variablePanel.BackColor = System.Drawing.Color.Transparent;
            this.variablePanel.Controls.Add(this.variableYList);
            this.variablePanel.Controls.Add(this.variableXList);
            this.variablePanel.Controls.Add(this.label3);
            this.variablePanel.Controls.Add(this.label7);
            this.variablePanel.Location = new System.Drawing.Point(10, 68);
            this.variablePanel.Name = "variablePanel";
            this.variablePanel.Size = new System.Drawing.Size(137, 55);
            this.variablePanel.TabIndex = 23;
            this.variablePanel.Visible = false;
            // 
            // variableYList
            // 
            this.variableYList.AllowCategories = true;
            this.variableYList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableYList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableYList.FormattingEnabled = true;
            this.variableYList.Location = new System.Drawing.Point(26, 30);
            this.variableYList.Name = "variableYList";
            this.variableYList.SelectedNode = null;
            this.variableYList.Size = new System.Drawing.Size(104, 21);
            this.variableYList.TabIndex = 8;
            // 
            // variableXList
            // 
            this.variableXList.AllowCategories = true;
            this.variableXList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableXList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableXList.FormattingEnabled = true;
            this.variableXList.Location = new System.Drawing.Point(26, 3);
            this.variableXList.Name = "variableXList";
            this.variableXList.SelectedNode = null;
            this.variableXList.Size = new System.Drawing.Size(104, 21);
            this.variableXList.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Y:";
            // 
            // ScrollCameraToDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(199, 241);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScrollCameraToDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scroll Camera To";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.constantPanel.ResumeLayout(false);
            this.constantPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            this.variablePanel.ResumeLayout(false);
            this.variablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudSpeed;
        private System.Windows.Forms.Panel constantPanel;
        private CustomUpDown nudY;
        private CustomUpDown nudX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button showMapBtn;
        private System.Windows.Forms.ComboBox coordinateType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel variablePanel;
        private Controls.Game.VariableComboBox variableYList;
        private Controls.Game.VariableComboBox variableXList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}