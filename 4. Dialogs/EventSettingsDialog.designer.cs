namespace EGMGame
{
    partial class EventSettingsDialog
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
            this.label6 = new System.Windows.Forms.Label();
            this.rotateBox = new EGMGame.CustomUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.rotateBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Rotate";
            // 
            // rotateBox
            // 
            this.rotateBox.Location = new System.Drawing.Point(57, 12);
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
            this.rotateBox.OnChange = false;
            this.rotateBox.Size = new System.Drawing.Size(80, 20);
            this.rotateBox.TabIndex = 10;
            this.rotateBox.ValueChanged += new System.EventHandler(this.rotateBox_ValueChanged);
            this.rotateBox.Validated += new System.EventHandler(this.rotateBox_Validated);
            // 
            // EventSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(149, 45);
            this.Controls.Add(this.rotateBox);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Event";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TileSettingsDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.rotateBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        internal CustomUpDown rotateBox;
    }
}