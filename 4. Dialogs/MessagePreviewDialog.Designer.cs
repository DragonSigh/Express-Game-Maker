﻿namespace EGMGame.Dialogs
{
    partial class MessagePreviewDialog
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
            this.mP = new EGMGame.Controls.MenuViewer();
            this.SuspendLayout();
            // 
            // mP
            // 
            this.mP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mP.Location = new System.Drawing.Point(0, 0);
            this.mP.Name = "mP";
            this.mP.SelectedMenu = null;
            this.mP.SelectedObject = null;
            this.mP.Size = new System.Drawing.Size(538, 460);
            this.mP.TabIndex = 0;
            // 
            // MessagePreviewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 460);
            this.Controls.Add(this.mP);
            this.Name = "MessagePreviewDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Preview";
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.MenuViewer mP;

    }
}