namespace EGMGame.Controls.EventControls.EventDialogs
{
    partial class AnimationListDialog
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
            this.components = new System.ComponentModel.Container();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.directionsList = new System.Windows.Forms.ComboBox();
            this.animationViewer = new EGMGame.Controls.AnimationViewer();
            this.actionList = new EGMGame.Controls.Game.AnimationActionComboBox(this.components);
            this.groupBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.aniList = new EGMGame.Controls.AddRemoveList();
            this.groupBox2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(235, 304);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(316, 304);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox2.CanCollapse = false;
            this.groupBox2.Controls.Add(this.directionsList);
            this.groupBox2.Controls.Add(this.animationViewer);
            this.groupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox2.Image = null;
            this.groupBox2.IsCollapsed = false;
            this.groupBox2.Location = new System.Drawing.Point(171, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(220, 223);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation";
            // 
            // directionsList
            // 
            this.directionsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionsList.FormattingEnabled = true;
            this.directionsList.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right",
            "Up/Left",
            "Up/Right",
            "Down/Left",
            "Down/Right"});
            this.directionsList.Location = new System.Drawing.Point(7, 194);
            this.directionsList.Name = "directionsList";
            this.directionsList.Size = new System.Drawing.Size(72, 21);
            this.directionsList.TabIndex = 10;
            this.directionsList.SelectedIndexChanged += new System.EventHandler(this.directionsList_SelectedIndexChanged);
            // 
            // animationViewer
            // 
            this.animationViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationViewer.Location = new System.Drawing.Point(7, 25);
            this.animationViewer.Name = "animationViewer";
            this.animationViewer.SelectedFrame = null;
            this.animationViewer.Size = new System.Drawing.Size(206, 163);
            this.animationViewer.TabIndex = 5;
            // 
            // actionList
            // 
            this.actionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.actionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionList.FormattingEnabled = true;
            this.actionList.Location = new System.Drawing.Point(9, 306);
            this.actionList.Name = "actionList";
            this.actionList.Noneable = false;
            this.actionList.Size = new System.Drawing.Size(156, 21);
            this.actionList.TabIndex = 5;
            // 
            // groupBox
            // 
            this.groupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox.CanCollapse = false;
            this.groupBox.Controls.Add(this.aniList);
            this.groupBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox.Image = null;
            this.groupBox.IsCollapsed = false;
            this.groupBox.Location = new System.Drawing.Point(9, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox.Size = new System.Drawing.Size(156, 288);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Animations";
            // 
            // aniList
            // 
            this.aniList.AllowAdd = false;
            this.aniList.AllowCategories = true;
            this.aniList.AllowClipboard = false;
            this.aniList.AllowRemove = false;
            this.aniList.DisplayToolbar = false;
            this.aniList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aniList.EnableUpDown = false;
            this.aniList.Export = false;
            this.aniList.ImageList = null;
            this.aniList.Import = false;
            this.aniList.Location = new System.Drawing.Point(4, 25);
            this.aniList.Master = false;
            this.aniList.MultipleSelection = false;
            this.aniList.Name = "aniList";
            this.aniList.SelectedIndex = -1;
            this.aniList.ShowWarning = true;
            this.aniList.Size = new System.Drawing.Size(148, 258);
            this.aniList.TabIndex = 0;
            this.aniList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.aniList_SelectItem);
            // 
            // AnimationListDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(403, 336);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.actionList);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnimationListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Animations";
            this.Shown += new System.EventHandler(this.AnimationListDialog_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        internal EGMGame.Controls.Game.AnimationActionComboBox actionList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        private System.Windows.Forms.ComboBox directionsList;
        private AnimationViewer animationViewer;
        private AddRemoveList aniList;
    }
}