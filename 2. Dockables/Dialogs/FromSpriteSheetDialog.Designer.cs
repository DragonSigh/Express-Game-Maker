namespace EGMGame.Dialogs
{
    partial class FromSpriteSheetDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbSprites = new EGMGame.Controls.Game.MaterialsComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nudRows = new EGMGame.CustomUpDown();
            this.nudCols = new EGMGame.CustomUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudFrames = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUp = new System.Windows.Forms.ToolStripButton();
            this.btnDown = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(230, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(149, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbSprites
            // 
            this.cbSprites.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSprites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSprites.FormattingEnabled = true;
            this.cbSprites.Location = new System.Drawing.Point(15, 25);
            this.cbSprites.Name = "cbSprites";
            this.cbSprites.SelectedNode = null;
            this.cbSprites.Size = new System.Drawing.Size(134, 21);
            this.cbSprites.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sprite Sheet";
            // 
            // nudRows
            // 
            this.nudRows.BackColor = System.Drawing.Color.White;
            this.nudRows.Location = new System.Drawing.Point(85, 52);
            this.nudRows.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRows.OnChange = true;
            this.nudRows.Size = new System.Drawing.Size(49, 20);
            this.nudRows.TabIndex = 21;
            this.nudRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudCols
            // 
            this.nudCols.BackColor = System.Drawing.Color.White;
            this.nudCols.Location = new System.Drawing.Point(85, 78);
            this.nudCols.Maximum = new decimal(new int[] {
            98,
            0,
            0,
            0});
            this.nudCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCols.Name = "nudCols";
            this.nudCols.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCols.OnChange = true;
            this.nudCols.Size = new System.Drawing.Size(49, 20);
            this.nudCols.TabIndex = 20;
            this.nudCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(12, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Rows";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(12, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Columns";
            // 
            // nudFrames
            // 
            this.nudFrames.Location = new System.Drawing.Point(85, 104);
            this.nudFrames.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrames.Name = "nudFrames";
            this.nudFrames.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFrames.OnChange = true;
            this.nudFrames.Size = new System.Drawing.Size(49, 20);
            this.nudFrames.TabIndex = 23;
            this.nudFrames.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Display Time";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right",
            "Up/Left",
            "Up/Right",
            "Down/Left",
            "Down/Right"});
            this.listBox1.Location = new System.Drawing.Point(4, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(126, 77);
            this.listBox1.TabIndex = 24;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.listBox1);
            this.impactGroupBox1.Controls.Add(this.toolStrip1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(171, 9);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(134, 132);
            this.impactGroupBox1.TabIndex = 25;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Directions";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUp,
            this.btnDown});
            this.toolStrip1.Location = new System.Drawing.Point(4, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(126, 25);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUp
            // 
            this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUp.Image = global::EGMGame.Properties.Resources.arrow_down;
            this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 22);
            this.btnUp.Text = "Move Up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDown.Image = global::EGMGame.Properties.Resources.arrow_up;
            this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 22);
            this.btnDown.Text = "Move Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // FromSpriteSheetDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(317, 182);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.nudFrames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.nudCols);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSprites);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FromSpriteSheetDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "From Sprite Sheet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FromSpriteSheetDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.Game.MaterialsComboBox cbSprites;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudRows;
        private CustomUpDown nudCols;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private CustomUpDown nudFrames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnUp;
        private System.Windows.Forms.ToolStripButton btnDown;
    }
}