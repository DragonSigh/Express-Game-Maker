namespace EGMGame
{
    partial class TransferPlayerDialog
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
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.constantPanel = new System.Windows.Forms.Panel();
            this.nudY = new CustomUpDown();
            this.nudX = new CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.showMapBtn = new System.Windows.Forms.Button();
            this.coordinateType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mapsList = new EGMGame.Controls.Game.MapsComboBox(this.components);
            this.variablePanel = new System.Windows.Forms.Panel();
            this.variableYList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.variableXList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.impactGroupBox2.SuspendLayout();
            this.constantPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            this.variablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(94, 226);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(13, 226);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.constantPanel);
            this.impactGroupBox2.Controls.Add(this.coordinateType);
            this.impactGroupBox2.Controls.Add(this.label4);
            this.impactGroupBox2.Controls.Add(this.label3);
            this.impactGroupBox2.Controls.Add(this.mapsList);
            this.impactGroupBox2.Controls.Add(this.variablePanel);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(157, 208);
            this.impactGroupBox2.TabIndex = 22;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Location";
            // 
            // constantPanel
            // 
            this.constantPanel.BackColor = System.Drawing.Color.Transparent;
            this.constantPanel.Controls.Add(this.nudY);
            this.constantPanel.Controls.Add(this.nudX);
            this.constantPanel.Controls.Add(this.label5);
            this.constantPanel.Controls.Add(this.label6);
            this.constantPanel.Controls.Add(this.showMapBtn);
            this.constantPanel.Location = new System.Drawing.Point(10, 113);
            this.constantPanel.Name = "constantPanel";
            this.constantPanel.Size = new System.Drawing.Size(137, 90);
            this.constantPanel.TabIndex = 22;
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
            this.showMapBtn.Click += new System.EventHandler(this.constantBtn_Click);
            // 
            // coordinateType
            // 
            this.coordinateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coordinateType.FormattingEnabled = true;
            this.coordinateType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.coordinateType.Location = new System.Drawing.Point(10, 86);
            this.coordinateType.Name = "coordinateType";
            this.coordinateType.Size = new System.Drawing.Size(113, 21);
            this.coordinateType.TabIndex = 21;
            this.coordinateType.SelectedIndexChanged += new System.EventHandler(this.coordinateType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Choose the coordinate type.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Choose the map to transfer to.";
            // 
            // mapsList
            // 
            this.mapsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapsList.FormattingEnabled = true;
            this.mapsList.Location = new System.Drawing.Point(10, 41);
            this.mapsList.Name = "mapsList";
            this.mapsList.Size = new System.Drawing.Size(113, 21);
            this.mapsList.TabIndex = 16;
            // 
            // variablePanel
            // 
            this.variablePanel.BackColor = System.Drawing.Color.Transparent;
            this.variablePanel.Controls.Add(this.variableYList);
            this.variablePanel.Controls.Add(this.variableXList);
            this.variablePanel.Controls.Add(this.label1);
            this.variablePanel.Controls.Add(this.label2);
            this.variablePanel.Location = new System.Drawing.Point(10, 113);
            this.variablePanel.Name = "variablePanel";
            this.variablePanel.Size = new System.Drawing.Size(137, 55);
            this.variablePanel.TabIndex = 15;
            this.variablePanel.Visible = false;
            // 
            // variableYList
            // 
            this.variableYList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableYList.FormattingEnabled = true;
            this.variableYList.Location = new System.Drawing.Point(26, 30);
            this.variableYList.Name = "variableYList";
            this.variableYList.Size = new System.Drawing.Size(104, 21);
            this.variableYList.TabIndex = 8;
            // 
            // variableXList
            // 
            this.variableXList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableXList.FormattingEnabled = true;
            this.variableXList.Location = new System.Drawing.Point(26, 3);
            this.variableXList.Name = "variableXList";
            this.variableXList.Size = new System.Drawing.Size(104, 21);
            this.variableXList.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y:";
            // 
            // TransferPlayerDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(181, 258);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferPlayerDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer Player";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
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
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Panel variablePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private EGMGame.Controls.Game.MapsComboBox mapsList;
        private EGMGame.Controls.Game.VariableComboBox variableYList;
        private EGMGame.Controls.Game.VariableComboBox variableXList;
        private System.Windows.Forms.Button showMapBtn;
        private System.Windows.Forms.ComboBox coordinateType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel constantPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomUpDown nudY;
        private CustomUpDown nudX;
    }
}