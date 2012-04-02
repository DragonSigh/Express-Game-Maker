using EGMGame.Controls;
namespace EGMGame.Dialogs
{
    partial class SpriteGridDialog
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
            this.spriteH = new EGMGame.CustomUpDown();
            this.spriteW = new EGMGame.CustomUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.spriteGridControl = new EGMGame.Controls.SpriteGridControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spriteH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteW)).BeginInit();
            this.SuspendLayout();
            // 
            // spriteH
            // 
            this.spriteH.Location = new System.Drawing.Point(66, 32);
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
            this.spriteH.TabIndex = 17;
            this.spriteH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spriteH.ValueChanged += new System.EventHandler(this.spriteH_ValueChanged);
            // 
            // spriteW
            // 
            this.spriteW.Location = new System.Drawing.Point(66, 58);
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
            this.spriteW.TabIndex = 16;
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
            this.label8.Location = new System.Drawing.Point(13, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Rows";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(13, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Columns";
            // 
            // spriteGridControl
            // 
            this.spriteGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteGridControl.Location = new System.Drawing.Point(15, 84);
            this.spriteGridControl.Name = "spriteGridControl";
            this.spriteGridControl.SelectedSprite = null;
            this.spriteGridControl.Size = new System.Drawing.Size(767, 478);
            this.spriteGridControl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Adjust rows and columns to divide your spritesheet.";
            // 
            // SpriteGridDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spriteH);
            this.Controls.Add(this.spriteW);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spriteGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpriteGridDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sprite Table";
            ((System.ComponentModel.ISupportInitialize)(this.spriteH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SpriteGridControl spriteGridControl;
        private CustomUpDown spriteH;
        private CustomUpDown spriteW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}