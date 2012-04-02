namespace EGMGame.Controls.EventControls
{
    partial class GlobalEventPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pageList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.renameBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyBtn = new System.Windows.Forms.ToolStripButton();
            this.cutBtn = new System.Windows.Forms.ToolStripButton();
            this.pasteBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.leftBtn = new System.Windows.Forms.ToolStripButton();
            this.rightBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.eventPage = new EGMGame.Controls.EventControls.GlobalEventPageControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Enabled = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.pageList,
            this.toolStripSeparator4,
            this.renameBtn,
            this.toolStripSeparator1,
            this.copyBtn,
            this.cutBtn,
            this.pasteBtn,
            this.toolStripSeparator2,
            this.leftBtn,
            this.rightBtn,
            this.toolStripSeparator3,
            this.deleteBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Menu";
            this.toolStrip1.Visible = false;
            // 
            // newBtn
            // 
            this.newBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newBtn.Image = global::EGMGame.Properties.Resources.page_add;
            this.newBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(23, 22);
            this.newBtn.Text = "New Page";
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Page:";
            // 
            // pageList
            // 
            this.pageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(121, 25);
            this.pageList.ToolTipText = "Pages";
            this.pageList.SelectedIndexChanged += new System.EventHandler(this.pageList_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // renameBtn
            // 
            this.renameBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameBtn.Image = global::EGMGame.Properties.Resources.textfield_rename;
            this.renameBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(23, 22);
            this.renameBtn.Text = "Rename Page";
            this.renameBtn.ToolTipText = "Rename Page";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // copyBtn
            // 
            this.copyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyBtn.Image = global::EGMGame.Properties.Resources.page_copy;
            this.copyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(23, 22);
            this.copyBtn.Text = "Copy Page";
            // 
            // cutBtn
            // 
            this.cutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutBtn.Image = global::EGMGame.Properties.Resources.cut;
            this.cutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.Size = new System.Drawing.Size(23, 22);
            this.cutBtn.Text = "Cut Page";
            // 
            // pasteBtn
            // 
            this.pasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteBtn.Image = global::EGMGame.Properties.Resources.clipboard_paste;
            this.pasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.Size = new System.Drawing.Size(23, 22);
            this.pasteBtn.Text = "Paste Page";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // leftBtn
            // 
            this.leftBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftBtn.Image = global::EGMGame.Properties.Resources.application_side_contract;
            this.leftBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(23, 22);
            this.leftBtn.Text = "Move Tab To The Left";
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            // 
            // rightBtn
            // 
            this.rightBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightBtn.Image = global::EGMGame.Properties.Resources.application_side_expand;
            this.rightBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(23, 22);
            this.rightBtn.Text = "Move Tab To The Right";
            this.rightBtn.Click += new System.EventHandler(this.rightBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Image = global::EGMGame.Properties.Resources.page_delete;
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(23, 22);
            this.deleteBtn.Text = "Delete Page";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // eventPage
            // 
            this.eventPage.BackColor = System.Drawing.Color.Transparent;
            this.eventPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventPage.Enabled = false;
            this.eventPage.Location = new System.Drawing.Point(0, 0);
            this.eventPage.Name = "eventPage";
            this.eventPage.SelectedEvent = null;
            this.eventPage.SelectedEventPage = null;
            this.eventPage.Size = new System.Drawing.Size(667, 593);
            this.eventPage.TabIndex = 6;
            // 
            // GlobalEventPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.eventPage);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GlobalEventPage";
            this.Size = new System.Drawing.Size(667, 593);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox pageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton renameBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton copyBtn;
        private System.Windows.Forms.ToolStripButton cutBtn;
        private System.Windows.Forms.ToolStripButton pasteBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton leftBtn;
        private System.Windows.Forms.ToolStripButton rightBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private GlobalEventPageControl eventPage;
    }
}
