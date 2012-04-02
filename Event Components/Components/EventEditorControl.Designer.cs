namespace EGMGame.Controls
{
    partial class EventEditorControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.pageList = new System.Windows.Forms.ToolStripComboBox();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.lblcp = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lblTP = new System.Windows.Forms.ToolStripLabel();
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
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.syncBtn = new System.Windows.Forms.ToolStripButton();
            this.btnMemorizeEvent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.eventPage = new EGMGame.Controls.EventControls.EventPageControl();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Click To Program Dynamics";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 151);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 126);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Click To Add Animation";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.btnPrev,
            this.pageList,
            this.btnNext,
            this.lblcp,
            this.toolStripLabel3,
            this.lblTP,
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
            this.deleteBtn,
            this.toolStripSeparator6,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator7,
            this.syncBtn,
            this.btnMemorizeEvent,
            this.toolStripSeparator8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(718, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "Menu";
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
            // btnPrev
            // 
            this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrev.Image = global::EGMGame.Properties.Resources.arrow_left;
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(23, 22);
            this.btnPrev.Text = "toolStripButton1";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // pageList
            // 
            this.pageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(121, 25);
            this.pageList.ToolTipText = "Pages";
            this.pageList.SelectedIndexChanged += new System.EventHandler(this.pageList_SelectedIndexChanged);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::EGMGame.Properties.Resources.arrow_right;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 22);
            this.btnNext.Text = "Next Page";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblcp
            // 
            this.lblcp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblcp.Name = "lblcp";
            this.lblcp.Size = new System.Drawing.Size(14, 22);
            this.lblcp.Text = "0";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel3.Text = "/";
            // 
            // lblTP
            // 
            this.lblTP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(14, 22);
            this.lblTP.Text = "0";
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
            this.renameBtn.Visible = false;
            this.renameBtn.Click += new System.EventHandler(this.renameBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // copyBtn
            // 
            this.copyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyBtn.Image = global::EGMGame.Properties.Resources.page_copy;
            this.copyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(23, 22);
            this.copyBtn.Text = "Copy Page";
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // cutBtn
            // 
            this.cutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutBtn.Image = global::EGMGame.Properties.Resources.cut;
            this.cutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.Size = new System.Drawing.Size(23, 22);
            this.cutBtn.Text = "Cut Page";
            this.cutBtn.Click += new System.EventHandler(this.cutBtn_Click);
            // 
            // pasteBtn
            // 
            this.pasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteBtn.Image = global::EGMGame.Properties.Resources.clipboard_paste;
            this.pasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.Size = new System.Drawing.Size(23, 22);
            this.pasteBtn.Text = "Paste Page";
            this.pasteBtn.Click += new System.EventHandler(this.pasteBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // leftBtn
            // 
            this.leftBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftBtn.Image = global::EGMGame.Properties.Resources.arrow_down;
            this.leftBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(23, 22);
            this.leftBtn.Text = "Move Tab Up";
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            // 
            // rightBtn
            // 
            this.rightBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightBtn.Image = global::EGMGame.Properties.Resources.arrow_up;
            this.rightBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(23, 22);
            this.rightBtn.Text = "Move Tab Down";
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = global::EGMGame.Properties.Resources.arrow_undo;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = global::EGMGame.Properties.Resources.arrow_redo;
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator7.Visible = false;
            // 
            // syncBtn
            // 
            this.syncBtn.Image = global::EGMGame.Properties.Resources.link;
            this.syncBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.Size = new System.Drawing.Size(116, 22);
            this.syncBtn.Text = "Sync Map Events";
            this.syncBtn.Visible = false;
            this.syncBtn.Click += new System.EventHandler(this.syncBtn_Click);
            // 
            // btnMemorizeEvent
            // 
            this.btnMemorizeEvent.Checked = true;
            this.btnMemorizeEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnMemorizeEvent.Image = global::EGMGame.Properties.Resources.drive;
            this.btnMemorizeEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMemorizeEvent.Name = "btnMemorizeEvent";
            this.btnMemorizeEvent.Size = new System.Drawing.Size(112, 22);
            this.btnMemorizeEvent.Text = "Memorize Event";
            this.btnMemorizeEvent.Visible = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // eventPage
            // 
            this.eventPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventPage.BackColor = System.Drawing.Color.Transparent;
            this.eventPage.Enabled = false;
            this.eventPage.Location = new System.Drawing.Point(4, 29);
            this.eventPage.Margin = new System.Windows.Forms.Padding(4);
            this.eventPage.Name = "eventPage";
            this.eventPage.SelectedEvent = null;
            this.eventPage.SelectedEventPage = null;
            this.eventPage.Size = new System.Drawing.Size(714, 589);
            this.eventPage.TabIndex = 4;
            // 
            // EventEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.eventPage);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EventEditorControl";
            this.Size = new System.Drawing.Size(718, 615);
            this.Load += new System.EventHandler(this.EventEditorControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newBtn;
        private System.Windows.Forms.ToolStripButton copyBtn;
        private System.Windows.Forms.ToolStripButton pasteBtn;
        private System.Windows.Forms.ToolStripButton cutBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton leftBtn;
        private System.Windows.Forms.ToolStripButton rightBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton renameBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripComboBox pageList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private EGMGame.Controls.EventControls.EventPageControl eventPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton syncBtn;
        private System.Windows.Forms.ToolStripButton btnMemorizeEvent;
        private System.Windows.Forms.ToolStripButton btnPrev;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripLabel lblTP;
        private System.Windows.Forms.ToolStripLabel lblcp;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}
