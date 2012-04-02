namespace EGMGame.DiffEngine
{
    partial class SourceDeleted
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
            this.btnAddAllFiles = new System.Windows.Forms.Button();
            this.btnSkipThisStep = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "The following source files were deleted by the EGM team.\r\n\r\nNote: If you manage y" +
                "our own source and do not wish to delete these files, skip this step.";
            // 
            // btnAddAllFiles
            // 
            this.btnAddAllFiles.Location = new System.Drawing.Point(217, 101);
            this.btnAddAllFiles.Name = "btnAddAllFiles";
            this.btnAddAllFiles.Size = new System.Drawing.Size(176, 23);
            this.btnAddAllFiles.TabIndex = 3;
            this.btnAddAllFiles.Text = "Delete All (Recommended)";
            this.btnAddAllFiles.UseVisualStyleBackColor = true;
            this.btnAddAllFiles.Click += new System.EventHandler(this.btnAddAllFiles_Click);
            // 
            // btnSkipThisStep
            // 
            this.btnSkipThisStep.Location = new System.Drawing.Point(217, 346);
            this.btnSkipThisStep.Name = "btnSkipThisStep";
            this.btnSkipThisStep.Size = new System.Drawing.Size(176, 23);
            this.btnSkipThisStep.TabIndex = 4;
            this.btnSkipThisStep.Text = "Skip This Step";
            this.btnSkipThisStep.UseVisualStyleBackColor = true;
            this.btnSkipThisStep.Click += new System.EventHandler(this.btnSkipThisStep_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.listFiles);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(15, 101);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(196, 268);
            this.impactGroupBox1.TabIndex = 1;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Deleted Files";
            // 
            // listFiles
            // 
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(4, 25);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(188, 238);
            this.listFiles.TabIndex = 2;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(217, 130);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(176, 23);
            this.btnDeleteSelected.TabIndex = 5;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // SourceDeleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 381);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnSkipThisStep);
            this.Controls.Add(this.btnAddAllFiles);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SourceDeleted";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deleted Source Files";
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Button btnAddAllFiles;
        private System.Windows.Forms.Button btnSkipThisStep;
        private System.Windows.Forms.Button btnDeleteSelected;
    }
}