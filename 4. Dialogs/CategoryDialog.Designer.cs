﻿namespace EGMGame
{
    partial class CategoryDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.chkAddLayoutCollision = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 96);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 96);
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
            this.impactGroupBox1.Controls.Add(this.cbCategories);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 58);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Select Category";
            // 
            // cbCategories
            // 
            this.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Items.AddRange(new object[] {
            "Target",
            "Event",
            "Position",
            "Variable Position"});
            this.cbCategories.Location = new System.Drawing.Point(7, 28);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(142, 21);
            this.cbCategories.TabIndex = 4;
            // 
            // chkAddLayoutCollision
            // 
            this.chkAddLayoutCollision.AutoSize = true;
            this.chkAddLayoutCollision.Location = new System.Drawing.Point(12, 76);
            this.chkAddLayoutCollision.Name = "chkAddLayoutCollision";
            this.chkAddLayoutCollision.Size = new System.Drawing.Size(121, 17);
            this.chkAddLayoutCollision.TabIndex = 22;
            this.chkAddLayoutCollision.Text = "Add Layout Collision";
            this.chkAddLayoutCollision.UseVisualStyleBackColor = true;
            this.chkAddLayoutCollision.Visible = false;
            // 
            // CategoryDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(179, 131);
            this.Controls.Add(this.chkAddLayoutCollision);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Category";
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.CheckBox chkAddLayoutCollision;
    }
}