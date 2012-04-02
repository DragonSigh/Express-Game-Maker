namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.PartyDialogs
{
    partial class RemoveMemberDialog
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
            this.chkRemove = new System.Windows.Forms.CheckBox();
            this.cbIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbFromList = new EGMGame.Controls.Game.ListComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(174, 135);
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
            this.okBtn.Location = new System.Drawing.Point(93, 135);
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
            this.impactGroupBox1.Controls.Add(this.chkRemove);
            this.impactGroupBox1.Controls.Add(this.cbIndex);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.cbFromList);
            this.impactGroupBox1.Controls.Add(this.label1);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(237, 116);
            this.impactGroupBox1.TabIndex = 35;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Party Member";
            // 
            // chkRemove
            // 
            this.chkRemove.AutoSize = true;
            this.chkRemove.BackColor = System.Drawing.Color.Transparent;
            this.chkRemove.Checked = true;
            this.chkRemove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemove.Location = new System.Drawing.Point(7, 57);
            this.chkRemove.Name = "chkRemove";
            this.chkRemove.Size = new System.Drawing.Size(80, 17);
            this.chkRemove.TabIndex = 4;
            this.chkRemove.Text = "Add To List";
            this.chkRemove.UseVisualStyleBackColor = false;
            this.chkRemove.CheckedChanged += new System.EventHandler(this.chkRemove_CheckedChanged);
            // 
            // cbIndex
            // 
            this.cbIndex.AllowCategories = true;
            this.cbIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndex.FormattingEnabled = true;
            this.cbIndex.Location = new System.Drawing.Point(62, 28);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Noneable = false;
            this.cbIndex.SelectedNode = null;
            this.cbIndex.Size = new System.Drawing.Size(154, 21);
            this.cbIndex.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "At Index";
            // 
            // cbFromList
            // 
            this.cbFromList.AllowCategories = true;
            this.cbFromList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFromList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFromList.FormattingEnabled = true;
            this.cbFromList.Location = new System.Drawing.Point(62, 80);
            this.cbFromList.Name = "cbFromList";
            this.cbFromList.Noneable = false;
            this.cbFromList.SelectedNode = null;
            this.cbFromList.Size = new System.Drawing.Size(154, 21);
            this.cbFromList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add To";
            // 
            // RemoveMemberDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(261, 170);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveMemberDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remove Party Member";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private Game.VariableComboBox cbIndex;
        private System.Windows.Forms.Label label2;
        private Game.ListComboBox cbFromList;
        private System.Windows.Forms.CheckBox chkRemove;
    }
}