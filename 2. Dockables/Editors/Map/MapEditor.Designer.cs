namespace EGMGame.Docking.Editors
{
    partial class MapEditor
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
            this.mapEditor2 = new EGMGame.Controls.MapEditorControl();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.SuspendLayout();
            // 
            // mapEditor2
            // 
            this.mapEditor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapEditor2.Location = new System.Drawing.Point(0, 0);
            this.mapEditor2.Name = "mapEditor2";
            this.mapEditor2.Size = new System.Drawing.Size(722, 538);
            this.mapEditor2.TabIndex = 0;
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(722, 538);
            this.Controls.Add(this.mapEditor2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.KeyPreview = true;
            this.Name = "MapEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Map Editor";
            this.Text = "Map Editor";
            this.Activated += new System.EventHandler(this.SceneEditor_Activated);
            this.Deactivate += new System.EventHandler(this.MapEditor_Deactivate);
            this.VisibleChanged += new System.EventHandler(this.MapEditor_VisibleChanged);
            this.Enter += new System.EventHandler(this.SceneEditor_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SceneEditor_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public EGMGame.Controls.MapEditorControl mapEditor2;
        private Controls.UI.DockContextMenu dockContextMenu1;


    }
}