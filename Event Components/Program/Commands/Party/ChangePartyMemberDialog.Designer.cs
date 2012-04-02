namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.PartyDialogs
{
    partial class ChangePartyMemberDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkReset = new System.Windows.Forms.CheckBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbHero = new EGMGame.Controls.Game.HeroComboBox(this.components);
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(174, 100);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 38;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(93, 100);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 37;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.chkReset);
            this.impactGroupBox1.Controls.Add(this.cbType);
            this.impactGroupBox1.Controls.Add(this.cbHero);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(237, 82);
            this.impactGroupBox1.TabIndex = 35;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Party Member";
            // 
            // chkReset
            // 
            this.chkReset.AutoSize = true;
            this.chkReset.BackColor = System.Drawing.Color.Transparent;
            this.chkReset.Location = new System.Drawing.Point(7, 55);
            this.chkReset.Name = "chkReset";
            this.chkReset.Size = new System.Drawing.Size(145, 17);
            this.chkReset.TabIndex = 36;
            this.chkReset.Text = "Reset party member stats";
            this.chkReset.UseVisualStyleBackColor = false;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Add",
            "Remove"});
            this.cbType.Location = new System.Drawing.Point(157, 28);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(73, 21);
            this.cbType.TabIndex = 2;
            // 
            // cbHero
            // 
            this.cbHero.AllowCategories = true;
            this.cbHero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHero.FormattingEnabled = true;
            this.cbHero.Location = new System.Drawing.Point(7, 28);
            this.cbHero.Name = "cbHero";
            this.cbHero.Noneable = false;
            this.cbHero.SelectedNode = null;
            this.cbHero.Size = new System.Drawing.Size(142, 21);
            this.cbHero.TabIndex = 1;
            // 
            // ChangePartyMemberDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(261, 135);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePartyMemberDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Party Member";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.HeroComboBox cbHero;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.CheckBox chkReset;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}