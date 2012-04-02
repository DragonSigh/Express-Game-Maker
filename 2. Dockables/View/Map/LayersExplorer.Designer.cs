namespace EGMGame.Docking.Explorers
{
    partial class LayersExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayersExplorer));
            this.layersList = new EGMGame.Controls.LayeredAddRemoveList();
            this.SuspendLayout();
            // 
            // layersList
            // 
            this.layersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersList.Enabled = false;
            this.layersList.Location = new System.Drawing.Point(0, 0);
            this.layersList.Master = false;
            this.layersList.Name = "layersList";
            this.layersList.SelectedIndex = -1;
            this.layersList.Size = new System.Drawing.Size(258, 433);
            this.layersList.TabIndex = 1;
            this.layersList.ItemCheckedState += new EGMGame.Controls.LayeredAddRemoveList.ItemCheckedStateEvent(this.layersList_ItemCheckedState);
            this.layersList.SelectItem += new EGMGame.Controls.LayeredAddRemoveList.SelectItemEvent(this.layersList_SelectItem);
            this.layersList.UpItem += new EGMGame.Controls.LayeredAddRemoveList.UpItemEvent(this.layersList_UpItem);
            this.layersList.AddItem += new EGMGame.Controls.LayeredAddRemoveList.AddItemEvent(this.layersList_AddItem);
            this.layersList.DownItem += new EGMGame.Controls.LayeredAddRemoveList.DownItemEvent(this.layersList_DownItem);
            this.layersList.RemoveItem += new EGMGame.Controls.LayeredAddRemoveList.RemoveItemEvent(this.layersList_RemoveItem);
            this.layersList.ItemCheckState += new EGMGame.Controls.LayeredAddRemoveList.ItemCheckStateEvent(this.layersList_ItemCheckState);
            // 
            // LayersExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 433);
            this.Controls.Add(this.layersList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LayersExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.TabText = "Map Layers";
            this.Text = "Map Layers";
            this.VisibleChanged += new System.EventHandler(this.Explorer_VisibleChanged);
            this.DockStateChanged += new System.EventHandler(this.Explorer_DockStateChanged);
            this.ResumeLayout(false);

        }

        #endregion

        public EGMGame.Controls.LayeredAddRemoveList layersList;

    }
}