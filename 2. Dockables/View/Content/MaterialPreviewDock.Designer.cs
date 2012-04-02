namespace EGMGame.Docking.Explorers
{
    partial class MaterialPreviewDock
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
            this.materialViewer1 = new EGMGame.Controls.MaterialViewer();
            this.SuspendLayout();
            // 
            // materialViewer1
            // 
            this.materialViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialViewer1.Location = new System.Drawing.Point(0, 0);
            this.materialViewer1.Name = "materialViewer1";
            this.materialViewer1.SelectedMaterial = null;
            this.materialViewer1.Size = new System.Drawing.Size(284, 262);
            this.materialViewer1.TabIndex = 0;
            // 
            // MaterialPreviewDock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.materialViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "MaterialPreviewDock";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.Text = "Material Preview";
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.MaterialViewer materialViewer1;
    }
}