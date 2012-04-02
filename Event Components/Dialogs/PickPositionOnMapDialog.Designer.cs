namespace EGMGame.Controls.EventControls.EventDialogs
{
    partial class PickPositionOnMapDialog
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
            this.mapViewer = new EGMGame.Controls.MapViewer();
            this.SuspendLayout();
            // 
            // mapViewer
            // 
            this.mapViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewer.GridHeight = 32;
            this.mapViewer.GridWidth = 32;
            this.mapViewer.Location = new System.Drawing.Point(0, 0);
            this.mapViewer.Map = null;
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.SelectedLayer = null;
            this.mapViewer.SelectedTile = null;
            this.mapViewer.SelectedTileset = null;
            this.mapViewer.Size = new System.Drawing.Size(679, 572);
            this.mapViewer.TabIndex = 0;
            this.mapViewer.TileSelectedEvent += new EGMGame.Controls.MapViewer.TileSelectedHandler(this.mapViewer_TileSelectedEvent);
            // 
            // PickPositionOnMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 572);
            this.Controls.Add(this.mapViewer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickPositionOnMapDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pick Location";
            this.Shown += new System.EventHandler(this.PickPositionOnMapDialog_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private MapViewer mapViewer;
    }
}