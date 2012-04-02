namespace EGMGame
{
    partial class DatasetListDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.chartPanel1 = new EGMGame.Controls.UI.ChartPanel();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.nudValue = new EGMGame.CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudIndex = new EGMGame.CustomUpDown();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCount = new EGMGame.CustomUpDown();
            this.impactGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(414, 311);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(333, 311);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 9;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // chartPanel1
            // 
            this.chartPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPanel1.BackColor = System.Drawing.Color.White;
            this.chartPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel1.IsEditable = true;
            this.chartPanel1.Location = new System.Drawing.Point(12, 76);
            this.chartPanel1.Name = "chartPanel1";
            this.chartPanel1.Size = new System.Drawing.Size(477, 229);
            this.chartPanel1.TabIndex = 8;
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.btnGen);
            this.impactGroupBox2.Controls.Add(this.nudValue);
            this.impactGroupBox2.Controls.Add(this.label5);
            this.impactGroupBox2.Controls.Add(this.label4);
            this.impactGroupBox2.Controls.Add(this.nudIndex);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(139, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(350, 58);
            this.impactGroupBox2.TabIndex = 7;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Values";
            // 
            // btnGen
            // 
            this.btnGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGen.Image = global::EGMGame.Properties.Resources.chart_curve_edit;
            this.btnGen.Location = new System.Drawing.Point(232, 25);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(111, 25);
            this.btnGen.TabIndex = 11;
            this.btnGen.Text = "Use Generator";
            this.btnGen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(161, 28);
            this.nudValue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudValue.Name = "nudValue";
            this.nudValue.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudValue.OnChange = false;
            this.nudValue.Size = new System.Drawing.Size(57, 20);
            this.nudValue.TabIndex = 8;
            this.nudValue.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Index: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(115, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Value: ";
            // 
            // nudIndex
            // 
            this.nudIndex.Location = new System.Drawing.Point(52, 28);
            this.nudIndex.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIndex.Name = "nudIndex";
            this.nudIndex.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudIndex.OnChange = true;
            this.nudIndex.Size = new System.Drawing.Size(57, 20);
            this.nudIndex.TabIndex = 3;
            this.nudIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIndex.ValueChanged += new System.EventHandler(this.nudIndex_ValueChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.nudCount);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(121, 58);
            this.impactGroupBox1.TabIndex = 6;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Count: ";
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(54, 28);
            this.nudCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudCount.OnChange = false;
            this.nudCount.Size = new System.Drawing.Size(57, 20);
            this.nudCount.TabIndex = 3;
            this.nudCount.ValueChanged += new System.EventHandler(this.nudCount_ValueChanged);
            // 
            // DatasetListDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(501, 347);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.chartPanel1);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatasetListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatasetListDialog_FormClosing);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomUpDown nudCount;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label4;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Label label5;
        private CustomUpDown nudIndex;
        private CustomUpDown nudValue;
        private EGMGame.Controls.UI.ChartPanel chartPanel1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button btnGen;
    }
}