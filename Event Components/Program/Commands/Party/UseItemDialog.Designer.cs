namespace EGMGame
{
    partial class UseItemMDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPartyIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.panelPartyMember = new System.Windows.Forms.Panel();
            this.cbListPartyIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.cbList = new EGMGame.Controls.Game.ListComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cbListType = new System.Windows.Forms.ComboBox();
            this.chkApplyCost = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.panelPartyMember.SuspendLayout();
            this.panelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 313);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 313);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbVariable);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(181, 72);
            this.impactGroupBox1.TabIndex = 22;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the item\'s id variable.";
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(7, 41);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(156, 21);
            this.cbVariable.TabIndex = 1;
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Controls.Add(this.cbPartyIndex);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 90);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(181, 72);
            this.impactGroupBox2.TabIndex = 23;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Target Party Member";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the party member\'s variable.";
            // 
            // cbPartyIndex
            // 
            this.cbPartyIndex.AllowCategories = true;
            this.cbPartyIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPartyIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartyIndex.FormattingEnabled = true;
            this.cbPartyIndex.Location = new System.Drawing.Point(7, 41);
            this.cbPartyIndex.Name = "cbPartyIndex";
            this.cbPartyIndex.SelectedNode = null;
            this.cbPartyIndex.Size = new System.Drawing.Size(156, 21);
            this.cbPartyIndex.TabIndex = 1;
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.panelPartyMember);
            this.impactGroupBox3.Controls.Add(this.panelList);
            this.impactGroupBox3.Controls.Add(this.cbListType);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(12, 168);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(181, 116);
            this.impactGroupBox3.TabIndex = 26;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "List";
            // 
            // panelPartyMember
            // 
            this.panelPartyMember.BackColor = System.Drawing.Color.Transparent;
            this.panelPartyMember.Controls.Add(this.cbListPartyIndex);
            this.panelPartyMember.Controls.Add(this.label4);
            this.panelPartyMember.Location = new System.Drawing.Point(7, 55);
            this.panelPartyMember.Name = "panelPartyMember";
            this.panelPartyMember.Size = new System.Drawing.Size(174, 50);
            this.panelPartyMember.TabIndex = 2;
            // 
            // cbListPartyIndex
            // 
            this.cbListPartyIndex.AllowCategories = true;
            this.cbListPartyIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbListPartyIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListPartyIndex.FormattingEnabled = true;
            this.cbListPartyIndex.Location = new System.Drawing.Point(6, 16);
            this.cbListPartyIndex.Name = "cbListPartyIndex";
            this.cbListPartyIndex.SelectedNode = null;
            this.cbListPartyIndex.Size = new System.Drawing.Size(156, 21);
            this.cbListPartyIndex.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Select the party member\'s index.";
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.Transparent;
            this.panelList.Controls.Add(this.cbList);
            this.panelList.Controls.Add(this.label3);
            this.panelList.Location = new System.Drawing.Point(7, 55);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(174, 50);
            this.panelList.TabIndex = 1;
            // 
            // cbList
            // 
            this.cbList.AllowCategories = true;
            this.cbList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(6, 16);
            this.cbList.Name = "cbList";
            this.cbList.Noneable = false;
            this.cbList.SelectedNode = null;
            this.cbList.Size = new System.Drawing.Size(161, 21);
            this.cbList.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select the list containing the item.";
            // 
            // cbListType
            // 
            this.cbListType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListType.FormattingEnabled = true;
            this.cbListType.Items.AddRange(new object[] {
            "Party Member",
            "List"});
            this.cbListType.Location = new System.Drawing.Point(7, 28);
            this.cbListType.Name = "cbListType";
            this.cbListType.Size = new System.Drawing.Size(156, 21);
            this.cbListType.TabIndex = 0;
            this.cbListType.SelectedIndexChanged += new System.EventHandler(this.cbListType_SelectedIndexChanged);
            // 
            // chkApplyCost
            // 
            this.chkApplyCost.AutoSize = true;
            this.chkApplyCost.BackColor = System.Drawing.Color.Transparent;
            this.chkApplyCost.Location = new System.Drawing.Point(12, 290);
            this.chkApplyCost.Name = "chkApplyCost";
            this.chkApplyCost.Size = new System.Drawing.Size(89, 17);
            this.chkApplyCost.TabIndex = 27;
            this.chkApplyCost.Text = "Remove Item";
            this.chkApplyCost.UseVisualStyleBackColor = false;
            // 
            // UseItemMDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(205, 348);
            this.Controls.Add(this.chkApplyCost);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UseItemMDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Use Item";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.impactGroupBox3.ResumeLayout(false);
            this.panelPartyMember.ResumeLayout(false);
            this.panelPartyMember.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.CheckBox ckRemoveItem;
        private System.Windows.Forms.Label label1;
        private Controls.Game.VariableComboBox cbVariable;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Label label2;
        private Controls.Game.VariableComboBox cbPartyIndex;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.ComboBox cbListType;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Label label3;
        private Controls.Game.ListComboBox cbList;
        private System.Windows.Forms.Panel panelPartyMember;
        private System.Windows.Forms.Label label4;
        private Controls.Game.VariableComboBox cbListPartyIndex;
        private System.Windows.Forms.CheckBox chkApplyCost;
    }
}