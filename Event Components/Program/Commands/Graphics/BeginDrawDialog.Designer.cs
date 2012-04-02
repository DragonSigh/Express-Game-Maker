namespace EGMGame
{
    partial class BeginDrawDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbStartY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbStartX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnPhysics = new System.Windows.Forms.Button();
            this.cbShape = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudThickness = new EGMGame.CustomUpDown();
            this.chkContDraw = new System.Windows.Forms.CheckBox();
            this.chkFillShape = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbColor = new EGMGame.ColorPickerCombobox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkCollision = new System.Windows.Forms.CheckBox();
            this.nudLayer = new EGMGame.CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbEndY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbEndX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).BeginInit();
            this.impactGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.cbStartY);
            this.impactGroupBox1.Controls.Add(this.cbStartX);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label3);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(140, 91);
            this.impactGroupBox1.TabIndex = 20;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Start Position";
            // 
            // cbStartY
            // 
            this.cbStartY.AllowCategories = true;
            this.cbStartY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStartY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartY.FormattingEnabled = true;
            this.cbStartY.Location = new System.Drawing.Point(29, 56);
            this.cbStartY.Name = "cbStartY";
            this.cbStartY.Noneable = false;
            this.cbStartY.SelectedNode = null;
            this.cbStartY.Size = new System.Drawing.Size(99, 21);
            this.cbStartY.TabIndex = 8;
            // 
            // cbStartX
            // 
            this.cbStartX.AllowCategories = true;
            this.cbStartX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStartX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartX.FormattingEnabled = true;
            this.cbStartX.Location = new System.Drawing.Point(29, 30);
            this.cbStartX.Name = "cbStartX";
            this.cbStartX.Noneable = false;
            this.cbStartX.SelectedNode = null;
            this.cbStartX.Size = new System.Drawing.Size(99, 21);
            this.cbStartX.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(224, 253);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 24);
            this.cancelBtn.TabIndex = 23;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(143, 253);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 24);
            this.okBtn.TabIndex = 22;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.CanCollapse = false;
            this.impactGroupBox3.Controls.Add(this.btnPhysics);
            this.impactGroupBox3.Controls.Add(this.cbShape);
            this.impactGroupBox3.Controls.Add(this.label1);
            this.impactGroupBox3.Controls.Add(this.nudThickness);
            this.impactGroupBox3.Controls.Add(this.chkContDraw);
            this.impactGroupBox3.Controls.Add(this.chkFillShape);
            this.impactGroupBox3.Controls.Add(this.label7);
            this.impactGroupBox3.Controls.Add(this.cbColor);
            this.impactGroupBox3.Controls.Add(this.label6);
            this.impactGroupBox3.Controls.Add(this.chkCollision);
            this.impactGroupBox3.Controls.Add(this.nudLayer);
            this.impactGroupBox3.Controls.Add(this.label5);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Image = null;
            this.impactGroupBox3.IsCollapsed = false;
            this.impactGroupBox3.Location = new System.Drawing.Point(12, 109);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(287, 138);
            this.impactGroupBox3.TabIndex = 21;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Settings";
            // 
            // btnPhysics
            // 
            this.btnPhysics.Enabled = false;
            this.btnPhysics.Location = new System.Drawing.Point(226, 82);
            this.btnPhysics.Name = "btnPhysics";
            this.btnPhysics.Size = new System.Drawing.Size(56, 30);
            this.btnPhysics.TabIndex = 25;
            this.btnPhysics.Text = "Physics";
            this.btnPhysics.UseVisualStyleBackColor = true;
            this.btnPhysics.Click += new System.EventHandler(this.btnPhysics_Click);
            // 
            // cbShape
            // 
            this.cbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShape.FormattingEnabled = true;
            this.cbShape.Items.AddRange(new object[] {
            "Line",
            "Rectangle",
            "Circle"});
            this.cbShape.Location = new System.Drawing.Point(47, 26);
            this.cbShape.Name = "cbShape";
            this.cbShape.Size = new System.Drawing.Size(103, 21);
            this.cbShape.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Shape";
            // 
            // nudThickness
            // 
            this.nudThickness.Location = new System.Drawing.Point(234, 53);
            this.nudThickness.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThickness.Name = "nudThickness";
            this.nudThickness.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudThickness.OnChange = true;
            this.nudThickness.Size = new System.Drawing.Size(43, 20);
            this.nudThickness.TabIndex = 35;
            this.nudThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkContDraw
            // 
            this.chkContDraw.AutoSize = true;
            this.chkContDraw.BackColor = System.Drawing.Color.Transparent;
            this.chkContDraw.Checked = true;
            this.chkContDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContDraw.Location = new System.Drawing.Point(10, 113);
            this.chkContDraw.Name = "chkContDraw";
            this.chkContDraw.Size = new System.Drawing.Size(108, 17);
            this.chkContDraw.TabIndex = 34;
            this.chkContDraw.Text = "Continously Draw";
            this.chkContDraw.UseVisualStyleBackColor = false;
            // 
            // chkFillShape
            // 
            this.chkFillShape.AutoSize = true;
            this.chkFillShape.BackColor = System.Drawing.Color.Transparent;
            this.chkFillShape.Location = new System.Drawing.Point(10, 90);
            this.chkFillShape.Name = "chkFillShape";
            this.chkFillShape.Size = new System.Drawing.Size(72, 17);
            this.chkFillShape.TabIndex = 33;
            this.chkFillShape.Text = "Fill Shape";
            this.chkFillShape.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(156, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Thickness";
            // 
            // cbColor
            // 
            this.cbColor.AllowOpacity = false;
            this.cbColor.Location = new System.Drawing.Point(47, 55);
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedItem = System.Drawing.Color.White;
            this.cbColor.Size = new System.Drawing.Size(103, 21);
            this.cbColor.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Color";
            // 
            // chkCollision
            // 
            this.chkCollision.AutoSize = true;
            this.chkCollision.BackColor = System.Drawing.Color.Transparent;
            this.chkCollision.Location = new System.Drawing.Point(122, 90);
            this.chkCollision.Name = "chkCollision";
            this.chkCollision.Size = new System.Drawing.Size(106, 17);
            this.chkCollision.TabIndex = 25;
            this.chkCollision.Text = "Collision Enabled";
            this.chkCollision.UseVisualStyleBackColor = false;
            this.chkCollision.CheckedChanged += new System.EventHandler(this.chkCollision_CheckedChanged);
            // 
            // nudLayer
            // 
            this.nudLayer.Location = new System.Drawing.Point(234, 27);
            this.nudLayer.Name = "nudLayer";
            this.nudLayer.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudLayer.OnChange = false;
            this.nudLayer.Size = new System.Drawing.Size(43, 20);
            this.nudLayer.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(156, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Draw on layer";
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.cbEndY);
            this.impactGroupBox2.Controls.Add(this.cbEndX);
            this.impactGroupBox2.Controls.Add(this.label4);
            this.impactGroupBox2.Controls.Add(this.label8);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(158, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(141, 91);
            this.impactGroupBox2.TabIndex = 24;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "End Position";
            // 
            // cbEndY
            // 
            this.cbEndY.AllowCategories = true;
            this.cbEndY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEndY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndY.FormattingEnabled = true;
            this.cbEndY.Location = new System.Drawing.Point(27, 56);
            this.cbEndY.Name = "cbEndY";
            this.cbEndY.Noneable = false;
            this.cbEndY.SelectedNode = null;
            this.cbEndY.Size = new System.Drawing.Size(99, 21);
            this.cbEndY.TabIndex = 12;
            // 
            // cbEndX
            // 
            this.cbEndX.AllowCategories = true;
            this.cbEndX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEndX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndX.FormattingEnabled = true;
            this.cbEndX.Location = new System.Drawing.Point(27, 30);
            this.cbEndX.Name = "cbEndX";
            this.cbEndX.Noneable = false;
            this.cbEndX.SelectedNode = null;
            this.cbEndX.Size = new System.Drawing.Size(99, 21);
            this.cbEndX.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(5, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(5, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Y:";
            // 
            // BeginDrawDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(306, 287);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeginDrawDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Begin Draw";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).EndInit();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private Controls.Game.VariableComboBox cbStartY;
        private Controls.Game.VariableComboBox cbStartX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.CheckBox chkCollision;
        private CustomUpDown nudLayer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ColorPickerCombobox cbColor;
        private System.Windows.Forms.CheckBox chkFillShape;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkContDraw;
        private CustomUpDown nudThickness;
        private System.Windows.Forms.ComboBox cbShape;
        private System.Windows.Forms.Label label1;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private Controls.Game.VariableComboBox cbEndY;
        private Controls.Game.VariableComboBox cbEndX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPhysics;
    }
}