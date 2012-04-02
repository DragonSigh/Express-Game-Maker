namespace EGMGame.EventControls.EventDialogs.CommandDialogs.DisplayDialogs
{
    partial class ShowMenuDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkExitMap = new System.Windows.Forms.CheckBox();
            this.cbMenuClose = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDeactivateMap = new System.Windows.Forms.CheckBox();
            this.cbShowOnMap = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.menuBox = new EGMGame.Controls.Game.MenuComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHeadsUpDisplay = new System.Windows.Forms.CheckBox();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(96, 271);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(15, 271);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 18;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.chkHeadsUpDisplay);
            this.impactGroupBox2.Controls.Add(this.chkExitMap);
            this.impactGroupBox2.Controls.Add(this.cbMenuClose);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Controls.Add(this.cbDeactivateMap);
            this.impactGroupBox2.Controls.Add(this.cbShowOnMap);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 89);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(158, 171);
            this.impactGroupBox2.TabIndex = 21;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Settings";
            // 
            // chkExitMap
            // 
            this.chkExitMap.AutoSize = true;
            this.chkExitMap.BackColor = System.Drawing.Color.Transparent;
            this.chkExitMap.Location = new System.Drawing.Point(7, 149);
            this.chkExitMap.Name = "chkExitMap";
            this.chkExitMap.Size = new System.Drawing.Size(77, 17);
            this.chkExitMap.TabIndex = 4;
            this.chkExitMap.Text = "Exit Scene";
            this.chkExitMap.UseVisualStyleBackColor = false;
            // 
            // cbMenuClose
            // 
            this.cbMenuClose.AutoSize = true;
            this.cbMenuClose.BackColor = System.Drawing.Color.Transparent;
            this.cbMenuClose.Location = new System.Drawing.Point(7, 126);
            this.cbMenuClose.Name = "cbMenuClose";
            this.cbMenuClose.Size = new System.Drawing.Size(132, 17);
            this.cbMenuClose.TabIndex = 3;
            this.cbMenuClose.Text = "Wait until menu closes";
            this.cbMenuClose.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "The menu can be displayed\r\non the map if you choose.";
            // 
            // cbDeactivateMap
            // 
            this.cbDeactivateMap.AutoSize = true;
            this.cbDeactivateMap.BackColor = System.Drawing.Color.Transparent;
            this.cbDeactivateMap.Location = new System.Drawing.Point(7, 103);
            this.cbDeactivateMap.Name = "cbDeactivateMap";
            this.cbDeactivateMap.Size = new System.Drawing.Size(112, 17);
            this.cbDeactivateMap.TabIndex = 1;
            this.cbDeactivateMap.Text = "Deactivate Scene";
            this.cbDeactivateMap.UseVisualStyleBackColor = false;
            // 
            // cbShowOnMap
            // 
            this.cbShowOnMap.AutoSize = true;
            this.cbShowOnMap.BackColor = System.Drawing.Color.Transparent;
            this.cbShowOnMap.Location = new System.Drawing.Point(7, 60);
            this.cbShowOnMap.Name = "cbShowOnMap";
            this.cbShowOnMap.Size = new System.Drawing.Size(102, 17);
            this.cbShowOnMap.TabIndex = 0;
            this.cbShowOnMap.Text = "Show on Scene";
            this.cbShowOnMap.UseVisualStyleBackColor = false;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.menuBox);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(158, 71);
            this.impactGroupBox1.TabIndex = 20;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Menu";
            // 
            // menuBox
            // 
            this.menuBox.AllowCategories = true;
            this.menuBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.menuBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuBox.FormattingEnabled = true;
            this.menuBox.Location = new System.Drawing.Point(7, 41);
            this.menuBox.Name = "menuBox";
            this.menuBox.SelectedNode = null;
            this.menuBox.Size = new System.Drawing.Size(132, 21);
            this.menuBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Choose the menu to display.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // chkHeadsUpDisplay
            // 
            this.chkHeadsUpDisplay.AutoSize = true;
            this.chkHeadsUpDisplay.BackColor = System.Drawing.Color.Transparent;
            this.chkHeadsUpDisplay.Location = new System.Drawing.Point(7, 80);
            this.chkHeadsUpDisplay.Name = "chkHeadsUpDisplay";
            this.chkHeadsUpDisplay.Size = new System.Drawing.Size(107, 17);
            this.chkHeadsUpDisplay.TabIndex = 5;
            this.chkHeadsUpDisplay.Text = "Heads-up display";
            this.chkHeadsUpDisplay.UseVisualStyleBackColor = false;
            this.chkHeadsUpDisplay.CheckedChanged += new System.EventHandler(this.chkHeadsUpDisplay_CheckedChanged);
            // 
            // ShowMenuDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(183, 306);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowMenuDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Menu";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.CheckBox cbDeactivateMap;
        private System.Windows.Forms.CheckBox cbShowOnMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbMenuClose;
        private EGMGame.Controls.Game.MenuComboBox menuBox;
        private System.Windows.Forms.CheckBox chkExitMap;
        private System.Windows.Forms.CheckBox chkHeadsUpDisplay;
    }
}