namespace EGMGame
{
    partial class FireLaserDialog
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
            this.animationComboBox1 = new EGMGame.Controls.Game.AnimationComboBox(this.components);
            this.animationActionComboBox1 = new EGMGame.Controls.Game.AnimationActionComboBox(this.components);
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.variableComboBox1 = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.variableComboBox2 = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.variableComboBox3 = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.variableComboBox4 = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(184, 448);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(103, 448);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.animationActionComboBox1);
            this.impactGroupBox1.Controls.Add(this.animationComboBox1);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(247, 88);
            this.impactGroupBox1.TabIndex = 22;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Animation";
            // 
            // animationComboBox1
            // 
            this.animationComboBox1.AllowCategories = true;
            this.animationComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.animationComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animationComboBox1.FormattingEnabled = true;
            this.animationComboBox1.Location = new System.Drawing.Point(7, 28);
            this.animationComboBox1.Name = "animationComboBox1";
            this.animationComboBox1.Noneable = true;
            this.animationComboBox1.SelectedNode = null;
            this.animationComboBox1.Size = new System.Drawing.Size(147, 21);
            this.animationComboBox1.TabIndex = 0;
            // 
            // animationActionComboBox1
            // 
            this.animationActionComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.animationActionComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animationActionComboBox1.FormattingEnabled = true;
            this.animationActionComboBox1.Location = new System.Drawing.Point(7, 55);
            this.animationActionComboBox1.Name = "animationActionComboBox1";
            this.animationActionComboBox1.Noneable = false;
            this.animationActionComboBox1.Size = new System.Drawing.Size(147, 21);
            this.animationActionComboBox1.TabIndex = 1;
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.label11);
            this.impactGroupBox2.Controls.Add(this.label10);
            this.impactGroupBox2.Controls.Add(this.label7);
            this.impactGroupBox2.Controls.Add(this.label8);
            this.impactGroupBox2.Controls.Add(this.variableComboBox3);
            this.impactGroupBox2.Controls.Add(this.variableComboBox4);
            this.impactGroupBox2.Controls.Add(this.label9);
            this.impactGroupBox2.Controls.Add(this.label6);
            this.impactGroupBox2.Controls.Add(this.label5);
            this.impactGroupBox2.Controls.Add(this.variableComboBox2);
            this.impactGroupBox2.Controls.Add(this.variableComboBox1);
            this.impactGroupBox2.Controls.Add(this.label4);
            this.impactGroupBox2.Controls.Add(this.comboBox1);
            this.impactGroupBox2.Controls.Add(this.label3);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 162);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(247, 206);
            this.impactGroupBox2.TabIndex = 23;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Position";
            this.impactGroupBox2.Enter += new System.EventHandler(this.impactGroupBox2_Enter);
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.CanCollapse = false;
            this.impactGroupBox4.Controls.Add(this.numericUpDown2);
            this.impactGroupBox4.Controls.Add(this.numericUpDown1);
            this.impactGroupBox4.Controls.Add(this.label2);
            this.impactGroupBox4.Controls.Add(this.label1);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Image = null;
            this.impactGroupBox4.IsCollapsed = false;
            this.impactGroupBox4.Location = new System.Drawing.Point(12, 374);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(247, 97);
            this.impactGroupBox4.TabIndex = 25;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thickness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Frames Displayed";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(103, 35);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(103, 61);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Type";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Local Variable"});
            this.comboBox1.Location = new System.Drawing.Point(10, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start Position";
            // 
            // variableComboBox1
            // 
            this.variableComboBox1.AllowCategories = true;
            this.variableComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableComboBox1.FormattingEnabled = true;
            this.variableComboBox1.Location = new System.Drawing.Point(33, 81);
            this.variableComboBox1.Name = "variableComboBox1";
            this.variableComboBox1.Noneable = false;
            this.variableComboBox1.SelectedNode = null;
            this.variableComboBox1.Size = new System.Drawing.Size(121, 21);
            this.variableComboBox1.TabIndex = 4;
            // 
            // variableComboBox2
            // 
            this.variableComboBox2.AllowCategories = true;
            this.variableComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableComboBox2.FormattingEnabled = true;
            this.variableComboBox2.Location = new System.Drawing.Point(33, 108);
            this.variableComboBox2.Name = "variableComboBox2";
            this.variableComboBox2.Noneable = false;
            this.variableComboBox2.SelectedNode = null;
            this.variableComboBox2.Size = new System.Drawing.Size(121, 21);
            this.variableComboBox2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(13, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(13, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "X";
            // 
            // variableComboBox3
            // 
            this.variableComboBox3.AllowCategories = true;
            this.variableComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableComboBox3.FormattingEnabled = true;
            this.variableComboBox3.Location = new System.Drawing.Point(33, 175);
            this.variableComboBox3.Name = "variableComboBox3";
            this.variableComboBox3.Noneable = false;
            this.variableComboBox3.SelectedNode = null;
            this.variableComboBox3.Size = new System.Drawing.Size(121, 21);
            this.variableComboBox3.TabIndex = 10;
            // 
            // variableComboBox4
            // 
            this.variableComboBox4.AllowCategories = true;
            this.variableComboBox4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableComboBox4.FormattingEnabled = true;
            this.variableComboBox4.Location = new System.Drawing.Point(33, 148);
            this.variableComboBox4.Name = "variableComboBox4";
            this.variableComboBox4.Noneable = false;
            this.variableComboBox4.SelectedNode = null;
            this.variableComboBox4.Size = new System.Drawing.Size(121, 21);
            this.variableComboBox4.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(7, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Start Position";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(13, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(13, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Y";
            // 
            // FireLaserDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(271, 551);
            this.Controls.Add(this.impactGroupBox4);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FireLaserDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fire Laser";
            this.Load += new System.EventHandler(this.AssigneAllyAsTargetDialog_Load);
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private Controls.Game.AnimationComboBox animationComboBox1;
        private Controls.Game.AnimationActionComboBox animationActionComboBox1;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Controls.Game.VariableComboBox variableComboBox3;
        private Controls.Game.VariableComboBox variableComboBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Controls.Game.VariableComboBox variableComboBox2;
        private Controls.Game.VariableComboBox variableComboBox1;
        private System.Windows.Forms.Label label4;
    }
}