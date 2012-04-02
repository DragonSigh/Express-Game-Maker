using EGMGame.Controls;
namespace EGMGame
{
    partial class PlayListDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.audioList = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.seList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.loopBtn = new System.Windows.Forms.CheckBox();
            this.numberBox = new CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.playListBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.playList = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.moveDownBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.audioList.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).BeginInit();
            this.playListBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(199, 285);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(118, 285);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // audioList
            // 
            this.audioList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.audioList.Controls.Add(this.seList);
            this.audioList.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.audioList.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.audioList.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.audioList.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.audioList.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.audioList.Location = new System.Drawing.Point(12, 12);
            this.audioList.Name = "audioList";
            this.audioList.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.audioList.Size = new System.Drawing.Size(128, 267);
            this.audioList.TabIndex = 22;
            this.audioList.TabStop = false;
            this.audioList.Text = "Audios";
            // 
            // seList
            // 
            this.seList.AllowAdd = false;
            this.seList.AllowCategories = true;
            this.seList.AllowRemove = false;
            this.seList.DisplayToolbar = false;
            this.seList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seList.ImageList = null;
            this.seList.Location = new System.Drawing.Point(4, 25);
            this.seList.Master = false;
            this.seList.MultipleSelection = false;
            this.seList.Name = "seList";
            this.seList.SelectedIndex = -1;
            this.seList.Size = new System.Drawing.Size(120, 237);
            this.seList.TabIndex = 25;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.loopBtn);
            this.impactGroupBox1.Controls.Add(this.numberBox);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(146, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(128, 59);
            this.impactGroupBox1.TabIndex = 23;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Controls";
            // 
            // loopBtn
            // 
            this.loopBtn.AutoSize = true;
            this.loopBtn.BackColor = System.Drawing.Color.Transparent;
            this.loopBtn.Location = new System.Drawing.Point(78, 29);
            this.loopBtn.Name = "loopBtn";
            this.loopBtn.Size = new System.Drawing.Size(50, 17);
            this.loopBtn.TabIndex = 27;
            this.loopBtn.Text = "Loop";
            this.loopBtn.UseVisualStyleBackColor = false;
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(42, 27);
            this.numberBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(32, 20);
            this.numberBox.TabIndex = 26;
            this.numberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Playlist";
            // 
            // playListBox
            // 
            this.playListBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.playListBox.Controls.Add(this.playList);
            this.playListBox.Controls.Add(this.toolStrip1);
            this.playListBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.playListBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.playListBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.playListBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.playListBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.playListBox.Location = new System.Drawing.Point(146, 77);
            this.playListBox.Name = "playListBox";
            this.playListBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.playListBox.Size = new System.Drawing.Size(128, 202);
            this.playListBox.TabIndex = 24;
            this.playListBox.TabStop = false;
            this.playListBox.Text = "Playlist";
            // 
            // playList
            // 
            this.playList.AllowDrop = true;
            this.playList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playList.Location = new System.Drawing.Point(4, 50);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(120, 147);
            this.playList.TabIndex = 2;
            this.playList.DragDrop += new System.Windows.Forms.DragEventHandler(this.playList_DragDrop);
            this.playList.DragOver += new System.Windows.Forms.DragEventHandler(this.playList_DragOver);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.moveDownBtn,
            this.toolStripSeparator1,
            this.deleteBtn});
            this.toolStrip1.Location = new System.Drawing.Point(4, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(120, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::EGMGame.Properties.Resources.navigation_up;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Move Up";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // moveDownBtn
            // 
            this.moveDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownBtn.Image = global::EGMGame.Properties.Resources.navigation_down;
            this.moveDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownBtn.Name = "moveDownBtn";
            this.moveDownBtn.Size = new System.Drawing.Size(23, 22);
            this.moveDownBtn.Text = "Move Down";
            this.moveDownBtn.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(23, 22);
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // PlayListDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(284, 320);
            this.Controls.Add(this.playListBox);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.audioList);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Playlist";
            this.audioList.ResumeLayout(false);
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).EndInit();
            this.playListBox.ResumeLayout(false);
            this.playListBox.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox audioList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox playListBox;
        private AddRemoveList seList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton moveDownBtn;
        private System.Windows.Forms.Label label1;
        private CustomUpDown numberBox;
        private System.Windows.Forms.TreeView playList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.CheckBox loopBtn;
    }
}