namespace EGMGame.DiffEngine
{
    partial class SourceModified
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceModified));
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.btnSkipThisStep = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnMergeFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReplaceSelected = new System.Windows.Forms.Button();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "The following files will be modified by the update.\r\n\r\nNote: If you manage your o" +
                "wn source and do not want to update it, skip this step.";
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
            this.impactGroupBox1.Location = new System.Drawing.Point(15, 72);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(196, 352);
            this.impactGroupBox1.TabIndex = 2;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Modified Files";
            // 
            // listFiles
            // 
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(4, 25);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(188, 322);
            this.listFiles.TabIndex = 2;
            // 
            // btnSkipThisStep
            // 
            this.btnSkipThisStep.Location = new System.Drawing.Point(220, 401);
            this.btnSkipThisStep.Name = "btnSkipThisStep";
            this.btnSkipThisStep.Size = new System.Drawing.Size(190, 23);
            this.btnSkipThisStep.TabIndex = 5;
            this.btnSkipThisStep.Text = "Skip This Step";
            this.btnSkipThisStep.UseVisualStyleBackColor = true;
            this.btnSkipThisStep.Click += new System.EventHandler(this.btnSkipThisStep_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(220, 310);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(190, 23);
            this.btnReplaceAll.TabIndex = 6;
            this.btnReplaceAll.Text = "Repleace All Files (Recommended)";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnMergeFile
            // 
            this.btnMergeFile.Location = new System.Drawing.Point(220, 368);
            this.btnMergeFile.Name = "btnMergeFile";
            this.btnMergeFile.Size = new System.Drawing.Size(190, 23);
            this.btnMergeFile.TabIndex = 7;
            this.btnMergeFile.Text = "Merge Selected File";
            this.btnMergeFile.UseVisualStyleBackColor = true;
            this.btnMergeFile.Click += new System.EventHandler(this.btnMergeFile_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(217, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 235);
            this.label2.TabIndex = 8;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // btnReplaceSelected
            // 
            this.btnReplaceSelected.Location = new System.Drawing.Point(220, 339);
            this.btnReplaceSelected.Name = "btnReplaceSelected";
            this.btnReplaceSelected.Size = new System.Drawing.Size(190, 23);
            this.btnReplaceSelected.TabIndex = 9;
            this.btnReplaceSelected.Text = "Repleace Selected File";
            this.btnReplaceSelected.UseVisualStyleBackColor = true;
            this.btnReplaceSelected.Click += new System.EventHandler(this.btnReplaceSelected_Click);
            // 
            // SourceModified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 434);
            this.Controls.Add(this.btnReplaceSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMergeFile);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnSkipThisStep);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SourceModified";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Source Modified";
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Button btnSkipThisStep;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnMergeFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReplaceSelected;
    }
}