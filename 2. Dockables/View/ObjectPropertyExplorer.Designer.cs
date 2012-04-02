namespace EGMGame.Docking.Explorers
{
    partial class ObjectPropertyExplorer
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
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.cbMenus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 21);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(225, 409);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            this.propertyGrid.SelectedObjectsChanged += new System.EventHandler(this.propertyGrid_SelectedObjectsChanged);
            // 
            // cbMenus
            // 
            this.cbMenus.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMenus.FormattingEnabled = true;
            this.cbMenus.Location = new System.Drawing.Point(0, 0);
            this.cbMenus.Name = "cbMenus";
            this.cbMenus.Size = new System.Drawing.Size(225, 21);
            this.cbMenus.TabIndex = 1;
            this.cbMenus.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // MenuPropertyExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 430);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.cbMenus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "MenuPropertyExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide;
            this.TabText = "Object Property Explorer";
            this.Text = "Object Property Explorer";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ComboBox cbMenus;

    }
}