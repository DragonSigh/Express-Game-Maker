namespace EGMGame.Dialogs
{
    partial class FromSpriteSheetForDirDialog
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
            this.spriteH = new EGMGame.CustomUpDown();
            this.spriteW = new EGMGame.CustomUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSprites = new EGMGame.Controls.Game.MaterialsComboBox(this.components);
            this.spriteGridControl = new EGMGame.Controls.SpriteGridDirControl();
            this.rbColumns = new System.Windows.Forms.RadioButton();
            this.rbRows = new System.Windows.Forms.RadioButton();
            this.nudFrames = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudFrames2 = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spriteH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(707, 537);
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
            this.btnOK.Location = new System.Drawing.Point(626, 537);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // spriteH
            // 
            this.spriteH.Location = new System.Drawing.Point(210, 7);
            this.spriteH.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spriteH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spriteH.Name = "spriteH";
            this.spriteH.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spriteH.OnChange = true;
            this.spriteH.Size = new System.Drawing.Size(49, 20);
            this.spriteH.TabIndex = 22;
            this.spriteH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spriteH.ValueChanged += new System.EventHandler(this.spriteH_ValueChanged);
            // 
            // spriteW
            // 
            this.spriteW.Location = new System.Drawing.Point(210, 33);
            this.spriteW.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spriteW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spriteW.Name = "spriteW";
            this.spriteW.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spriteW.OnChange = true;
            this.spriteW.Size = new System.Drawing.Size(49, 20);
            this.spriteW.TabIndex = 21;
            this.spriteW.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spriteW.ValueChanged += new System.EventHandler(this.spriteW_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(157, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Rows";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(157, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Sprite Sheet";
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
            this.cbSprites.TabIndex = 23;
            this.cbSprites.SelectedIndexChanged += new System.EventHandler(this.cbSprites_SelectedIndexChanged);
            // 
            // spriteGridControl
            // 
            this.spriteGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteGridControl.Location = new System.Drawing.Point(15, 59);
            this.spriteGridControl.Name = "spriteGridControl";
            this.spriteGridControl.SelectedSprite = null;
            this.spriteGridControl.Size = new System.Drawing.Size(767, 472);
            this.spriteGridControl.TabIndex = 25;
            // 
            // rbColumns
            // 
            this.rbColumns.AutoSize = true;
            this.rbColumns.Checked = true;
            this.rbColumns.Location = new System.Drawing.Point(385, 9);
            this.rbColumns.Name = "rbColumns";
            this.rbColumns.Size = new System.Drawing.Size(65, 17);
            this.rbColumns.TabIndex = 26;
            this.rbColumns.TabStop = true;
            this.rbColumns.Text = "Columns";
            this.rbColumns.UseVisualStyleBackColor = true;
            this.rbColumns.CheckedChanged += new System.EventHandler(this.rbColumns_CheckedChanged);
            // 
            // rbRows
            // 
            this.rbRows.AutoSize = true;
            this.rbRows.Location = new System.Drawing.Point(456, 9);
            this.rbRows.Name = "rbRows";
            this.rbRows.Size = new System.Drawing.Size(52, 17);
            this.rbRows.TabIndex = 27;
            this.rbRows.Text = "Rows";
            this.rbRows.UseVisualStyleBackColor = true;
            // 
            // nudFrames
            // 
            this.nudFrames.Location = new System.Drawing.Point(312, 7);
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
            this.nudFrames.TabIndex = 28;
            this.nudFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrames.ValueChanged += new System.EventHandler(this.nudFrames_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(382, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Number of Frames";
            // 
            // nudFrames2
            // 
            this.nudFrames2.Location = new System.Drawing.Point(481, 28);
            this.nudFrames2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFrames2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrames2.Name = "nudFrames2";
            this.nudFrames2.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFrames2.OnChange = true;
            this.nudFrames2.Size = new System.Drawing.Size(65, 20);
            this.nudFrames2.TabIndex = 30;
            this.nudFrames2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrames2.ValueChanged += new System.EventHandler(this.nudFrames2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(265, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Frames";
            // 
            // FromSpriteSheetForDirDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudFrames2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudFrames);
            this.Controls.Add(this.rbRows);
            this.Controls.Add(this.rbColumns);
            this.Controls.Add(this.spriteGridControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSprites);
            this.Controls.Add(this.spriteH);
            this.Controls.Add(this.spriteW);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FromSpriteSheetForDirDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "From Sprite Sheet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FromSpriteSheetForDirDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.spriteH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private CustomUpDown spriteH;
        private CustomUpDown spriteW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private Controls.Game.MaterialsComboBox cbSprites;
        private Controls.SpriteGridDirControl spriteGridControl;
        private System.Windows.Forms.RadioButton rbColumns;
        private System.Windows.Forms.RadioButton rbRows;
        private CustomUpDown nudFrames;
        private System.Windows.Forms.Label label2;
        private CustomUpDown nudFrames2;
        private System.Windows.Forms.Label label3;
    }
}