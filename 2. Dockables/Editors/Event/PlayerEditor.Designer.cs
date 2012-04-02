namespace EGMGame.Docking.Editors
{
    partial class PlayerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerEditor));
            this.playerPageControl1 = new EGMGame.Controls.EventControls.PlayerPageControl();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.SuspendLayout();
            // 
            // playerPageControl1
            // 
            this.playerPageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playerPageControl1.BackColor = System.Drawing.Color.Transparent;
            this.playerPageControl1.Location = new System.Drawing.Point(0, 0);
            this.playerPageControl1.Name = "playerPageControl1";
            this.playerPageControl1.SelectedEvent = null;
            this.playerPageControl1.SelectedEventPage = null;
            this.playerPageControl1.Size = new System.Drawing.Size(569, 609);
            this.playerPageControl1.TabIndex = 0;
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // PlayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(570, 611);
            this.Controls.Add(this.playerPageControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayerEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Player Editor";
            this.Text = "Player Editor";
            this.Activated += new System.EventHandler(this.PlayerEditor_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerEditor_FormClosing);
            this.Shown += new System.EventHandler(this.PlayerEditor_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.EventControls.PlayerPageControl playerPageControl1;
        private Controls.UI.DockContextMenu dockContextMenu1;



    }
}