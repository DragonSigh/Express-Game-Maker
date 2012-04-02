namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class LocalSwitchConditionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalSwitchConditionDialog));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.selfSwitchBtn = new System.Windows.Forms.RadioButton();
            this.switchBtn = new System.Windows.Forms.RadioButton();
            this.offBtn = new System.Windows.Forms.RadioButton();
            this.onBtn = new System.Windows.Forms.RadioButton();
            this.selfSwitchesList = new EGMGame.Controls.Game.SwitchesComboBox(this.components);
            this.switchesList = new EGMGame.Controls.Game.SwitchesComboBox(this.components);
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(249, 360);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(168, 360);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 12;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.addRemoveList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(145, 371);
            this.impactGroupBox1.TabIndex = 10;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Local Switches";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowRemove = true;
            this.addRemoveList.DisplayToolbar = true;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = false;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            
            this.addRemoveList.Size = new System.Drawing.Size(137, 341);
            this.addRemoveList.TabIndex = 1;
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.selfSwitchesList);
            this.impactGroupBox2.Controls.Add(this.switchesList);
            this.impactGroupBox2.Controls.Add(this.selfSwitchBtn);
            this.impactGroupBox2.Controls.Add(this.switchBtn);
            this.impactGroupBox2.Controls.Add(this.offBtn);
            this.impactGroupBox2.Controls.Add(this.onBtn);
            this.impactGroupBox2.Enabled = false;
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(163, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(161, 157);
            this.impactGroupBox2.TabIndex = 11;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Condition";
            // 
            // selfSwitchBtn
            // 
            this.selfSwitchBtn.AutoSize = true;
            this.selfSwitchBtn.BackColor = System.Drawing.Color.Transparent;
            this.selfSwitchBtn.Location = new System.Drawing.Point(7, 101);
            this.selfSwitchBtn.Name = "selfSwitchBtn";
            this.selfSwitchBtn.Size = new System.Drawing.Size(86, 17);
            this.selfSwitchBtn.TabIndex = 3;
            this.selfSwitchBtn.Text = "Local Switch";
            this.selfSwitchBtn.UseVisualStyleBackColor = false;
            this.selfSwitchBtn.CheckedChanged += new System.EventHandler(this.selfSwitchBtn_CheckedChanged);
            // 
            // switchBtn
            // 
            this.switchBtn.AutoSize = true;
            this.switchBtn.BackColor = System.Drawing.Color.Transparent;
            this.switchBtn.Location = new System.Drawing.Point(7, 51);
            this.switchBtn.Name = "switchBtn";
            this.switchBtn.Size = new System.Drawing.Size(57, 17);
            this.switchBtn.TabIndex = 2;
            this.switchBtn.Text = "Switch";
            this.switchBtn.UseVisualStyleBackColor = false;
            this.switchBtn.CheckedChanged += new System.EventHandler(this.switchBtn_CheckedChanged);
            // 
            // offBtn
            // 
            this.offBtn.AutoSize = true;
            this.offBtn.BackColor = System.Drawing.Color.Transparent;
            this.offBtn.Checked = true;
            this.offBtn.Location = new System.Drawing.Point(54, 28);
            this.offBtn.Name = "offBtn";
            this.offBtn.Size = new System.Drawing.Size(39, 17);
            this.offBtn.TabIndex = 1;
            this.offBtn.TabStop = true;
            this.offBtn.Text = "Off";
            this.offBtn.UseVisualStyleBackColor = false;
            this.offBtn.CheckedChanged += new System.EventHandler(this.offBtn_CheckedChanged);
            // 
            // onBtn
            // 
            this.onBtn.AutoSize = true;
            this.onBtn.BackColor = System.Drawing.Color.Transparent;
            this.onBtn.Location = new System.Drawing.Point(7, 28);
            this.onBtn.Name = "onBtn";
            this.onBtn.Size = new System.Drawing.Size(39, 17);
            this.onBtn.TabIndex = 0;
            this.onBtn.Text = "On";
            this.onBtn.UseVisualStyleBackColor = false;
            this.onBtn.CheckedChanged += new System.EventHandler(this.onBtn_CheckedChanged);
            // 
            // selfSwitchesList
            // 
            this.selfSwitchesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selfSwitchesList.Enabled = false;
            this.selfSwitchesList.FormattingEnabled = true;
            this.selfSwitchesList.Location = new System.Drawing.Point(7, 124);
            this.selfSwitchesList.Name = "selfSwitchesList";
            this.selfSwitchesList.Size = new System.Drawing.Size(113, 21);
            this.selfSwitchesList.TabIndex = 7;
            this.selfSwitchesList.SelectedIndexChanged += new System.EventHandler(this.selfSwitchesList_SelectedIndexChanged);
            // 
            // switchesList
            // 
            this.switchesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.switchesList.Enabled = false;
            this.switchesList.FormattingEnabled = true;
            this.switchesList.Location = new System.Drawing.Point(7, 74);
            this.switchesList.Name = "switchesList";
            this.switchesList.Size = new System.Drawing.Size(113, 21);
            this.switchesList.TabIndex = 6;
            this.switchesList.SelectedIndexChanged += new System.EventHandler(this.switchesList_SelectedIndexChanged);
            // 
            // LocalSwitchConditionDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(336, 395);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalSwitchConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Local Switch";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.RadioButton selfSwitchBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.RadioButton switchBtn;
        private System.Windows.Forms.RadioButton offBtn;
        private System.Windows.Forms.RadioButton onBtn;
        private System.Windows.Forms.Button okBtn;
        private AddRemoveList addRemoveList;
        private EGMGame.Controls.Game.SwitchesComboBox selfSwitchesList;
        private EGMGame.Controls.Game.SwitchesComboBox switchesList;
    }
}