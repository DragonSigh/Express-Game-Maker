namespace EGMGame.Dialogs
{
    partial class TilePickerDialog
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
            this.tileViewer = new EGMGame.Controls.TileViewer();
            this.SuspendLayout();
            // 
            // tileViewer
            // 
            this.tileViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileViewer.GridHeight = 32;
            this.tileViewer.GridWidth = 32;
            this.tileViewer.Location = new System.Drawing.Point(0, 0);
            this.tileViewer.Name = "tileViewer";
            this.tileViewer.SelectedCategory = 0;
            this.tileViewer.SelectedTileset = null;
            this.tileViewer.Size = new System.Drawing.Size(304, 498);
            this.tileViewer.TabIndex = 0;
            this.tileViewer.TilesetView = true;
            // 
            // TilePickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 498);
            this.Controls.Add(this.tileViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TilePickerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tileset";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TileViewer tileViewer;
    }
}