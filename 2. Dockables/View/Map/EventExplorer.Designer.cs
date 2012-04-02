namespace EGMGame.Docking.Explorers
{
    partial class EventExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventExplorer));
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMenuEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = false;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowClipboard = false;
            this.addRemoveList.AllowMenu = false;
            this.addRemoveList.AllowRemove = false;
            this.addRemoveList.DisplayToolbar = false;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.Export = false;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Import = false;
            this.addRemoveList.Location = new System.Drawing.Point(0, 25);
            this.addRemoveList.Master = true;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(272, 456);
            this.addRemoveList.TabIndex = 1;
            this.addRemoveList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.addRemoveList_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuEditor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(272, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // btnMenuEditor
            // 
            this.btnMenuEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMenuEditor.Image = global::EGMGame.Properties.Resources.arrow_right;
            this.btnMenuEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMenuEditor.Name = "btnMenuEditor";
            this.btnMenuEditor.Size = new System.Drawing.Size(23, 22);
            this.btnMenuEditor.Text = "Open Template Event Editor";
            this.btnMenuEditor.Click += new System.EventHandler(this.btnMenuEditor_Click);
            // 
            // EventExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 481);
            this.Controls.Add(this.addRemoveList);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide;
            this.TabText = "Template Events";
            this.Text = "Template Events";
            this.DockStateChanged += new System.EventHandler(this.Explorer_DockStateChanged);
            this.Shown += new System.EventHandler(this.EventExplorer_Activated);
            this.VisibleChanged += new System.EventHandler(this.Explorer_VisibleChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.AddRemoveList addRemoveList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMenuEditor;


    }
}