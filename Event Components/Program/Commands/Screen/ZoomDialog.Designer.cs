namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Screen_Dialogs
{
    partial class ZoomDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudZoomX = new System.Windows.Forms.NumericUpDown();
            this.nudZoomY = new System.Windows.Forms.NumericUpDown();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelConst = new System.Windows.Forms.Panel();
            this.panelVar = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbVarX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbVarY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomY)).BeginInit();
            this.panelConst.SuspendLayout();
            this.panelVar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(165, 140);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 24;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(84, 140);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 23;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.panelVar);
            this.impactGroupBox1.Controls.Add(this.panelConst);
            this.impactGroupBox1.Controls.Add(this.cbType);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label1);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(228, 122);
            this.impactGroupBox1.TabIndex = 22;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Zoom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoom-X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zoom-Y";
            // 
            // nudZoomX
            // 
            this.nudZoomX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudZoomX.Location = new System.Drawing.Point(3, 3);
            this.nudZoomX.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudZoomX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZoomX.Name = "nudZoomX";
            this.nudZoomX.Size = new System.Drawing.Size(75, 20);
            this.nudZoomX.TabIndex = 2;
            this.nudZoomX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudZoomY
            // 
            this.nudZoomY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudZoomY.Location = new System.Drawing.Point(3, 29);
            this.nudZoomY.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudZoomY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZoomY.Name = "nudZoomY";
            this.nudZoomY.Size = new System.Drawing.Size(75, 20);
            this.nudZoomY.TabIndex = 3;
            this.nudZoomY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbType.Location = new System.Drawing.Point(12, 28);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 4;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(84, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "/ 100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(84, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "/ 100";
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.nudZoomX);
            this.panelConst.Controls.Add(this.label3);
            this.panelConst.Controls.Add(this.nudZoomY);
            this.panelConst.Controls.Add(this.label4);
            this.panelConst.Location = new System.Drawing.Point(56, 55);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(132, 53);
            this.panelConst.TabIndex = 7;
            // 
            // panelVar
            // 
            this.panelVar.BackColor = System.Drawing.Color.Transparent;
            this.panelVar.Controls.Add(this.cbVarY);
            this.panelVar.Controls.Add(this.cbVarX);
            this.panelVar.Controls.Add(this.label5);
            this.panelVar.Controls.Add(this.label6);
            this.panelVar.Location = new System.Drawing.Point(56, 55);
            this.panelVar.Name = "panelVar";
            this.panelVar.Size = new System.Drawing.Size(163, 53);
            this.panelVar.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(122, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "/ 100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(122, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "/ 100";
            // 
            // cbVarX
            // 
            this.cbVarX.AllowCategories = true;
            this.cbVarX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVarX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarX.FormattingEnabled = true;
            this.cbVarX.Location = new System.Drawing.Point(4, 3);
            this.cbVarX.Name = "cbVarX";
            this.cbVarX.Noneable = false;
            this.cbVarX.SelectedNode = null;
            this.cbVarX.Size = new System.Drawing.Size(113, 21);
            this.cbVarX.TabIndex = 7;
            // 
            // cbVarY
            // 
            this.cbVarY.AllowCategories = true;
            this.cbVarY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVarY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarY.FormattingEnabled = true;
            this.cbVarY.Location = new System.Drawing.Point(4, 28);
            this.cbVarY.Name = "cbVarY";
            this.cbVarY.Noneable = false;
            this.cbVarY.SelectedNode = null;
            this.cbVarY.Size = new System.Drawing.Size(113, 21);
            this.cbVarY.TabIndex = 8;
            // 
            // ZoomDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(252, 175);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZoomDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zoom";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomY)).EndInit();
            this.panelConst.ResumeLayout(false);
            this.panelConst.PerformLayout();
            this.panelVar.ResumeLayout(false);
            this.panelVar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudZoomY;
        private System.Windows.Forms.NumericUpDown nudZoomX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.Panel panelVar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Game.VariableComboBox cbVarY;
        private Game.VariableComboBox cbVarX;

    }
}