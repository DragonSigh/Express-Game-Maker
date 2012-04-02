namespace EGMGame
{
    partial class TileSettingsDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.rotateBox = new EGMGame.CustomUpDown();
            this.opacityBox = new EGMGame.CustomUpDown();
            this.scaleY = new EGMGame.CustomUpDown();
            this.scaleX = new EGMGame.CustomUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.rotateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opacity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(47, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(115, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Rotate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(47, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(115, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Y";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Flip Horizontal";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(100, 96);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Flip Vertical";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // rotateBox
            // 
            this.rotateBox.Location = new System.Drawing.Point(67, 43);
            this.rotateBox.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotateBox.Name = "rotateBox";
            this.rotateBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rotateBox.OnChange = true;
            this.rotateBox.Size = new System.Drawing.Size(61, 20);
            this.rotateBox.TabIndex = 10;
            this.rotateBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rotateBox.ValueChanged += new System.EventHandler(this.rotateBox_ValueChanged);
            this.rotateBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.opacityBox_KeyUp);
            this.rotateBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseDown);
            this.rotateBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseUp);
            this.rotateBox.Validated += new System.EventHandler(this.rotateBox_Validated);
            // 
            // opacityBox
            // 
            this.opacityBox.Location = new System.Drawing.Point(67, 70);
            this.opacityBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.opacityBox.Name = "opacityBox";
            this.opacityBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.opacityBox.OnChange = true;
            this.opacityBox.Size = new System.Drawing.Size(61, 20);
            this.opacityBox.TabIndex = 9;
            this.opacityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.opacityBox.ValueChanged += new System.EventHandler(this.opacityBox_ValueChanged);
            this.opacityBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.opacityBox_KeyUp);
            this.opacityBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseDown);
            this.opacityBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseUp);
            this.opacityBox.Validated += new System.EventHandler(this.opacityBox_Validated);
            // 
            // scaleY
            // 
            this.scaleY.DecimalPlaces = 1;
            this.scaleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleY.Location = new System.Drawing.Point(135, 14);
            this.scaleY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleY.Name = "scaleY";
            this.scaleY.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.scaleY.OnChange = true;
            this.scaleY.Size = new System.Drawing.Size(42, 20);
            this.scaleY.TabIndex = 7;
            this.scaleY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleY.ValueChanged += new System.EventHandler(this.scaleY_ValueChanged);
            this.scaleY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.opacityBox_KeyUp);
            this.scaleY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseDown);
            this.scaleY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseUp);
            this.scaleY.Validated += new System.EventHandler(this.scaleY_Validated);
            // 
            // scaleX
            // 
            this.scaleX.DecimalPlaces = 1;
            this.scaleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleX.Location = new System.Drawing.Point(67, 14);
            this.scaleX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleX.Name = "scaleX";
            this.scaleX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.scaleX.OnChange = true;
            this.scaleX.Size = new System.Drawing.Size(42, 20);
            this.scaleX.TabIndex = 3;
            this.scaleX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleX.ValueChanged += new System.EventHandler(this.scaleX_ValueChanged);
            this.scaleX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.opacityBox_KeyUp);
            this.scaleX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseDown);
            this.scaleX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.opacityBox_MouseUp);
            this.scaleX.Validated += new System.EventHandler(this.scaleX_Validated);
            // 
            // TileSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(186, 119);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.rotateBox);
            this.Controls.Add(this.opacityBox);
            this.Controls.Add(this.scaleY);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scaleX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TileSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Tile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TileSettingsDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.rotateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal CustomUpDown scaleX;
        internal CustomUpDown scaleY;
        internal CustomUpDown opacityBox;
        internal CustomUpDown rotateBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}