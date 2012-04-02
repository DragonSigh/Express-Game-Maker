namespace EGMGame.Controls.EventControls.EventDialogs
{
    partial class SwitchesDialog
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
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.conditionsList = new EGMGame.Controls.AddRemoveList();
            this.conditionBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.orBox = new System.Windows.Forms.CheckBox();
            this.offBtn = new System.Windows.Forms.RadioButton();
            this.onBtn = new System.Windows.Forms.RadioButton();
            this.switchesBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox3.SuspendLayout();
            this.conditionBox.SuspendLayout();
            this.switchesBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(123, 487);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(42, 487);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.conditionsList);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(186, 120);
            this.impactGroupBox3.TabIndex = 8;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Conditions";
            // 
            // conditionsList
            // 
            this.conditionsList.AllowAdd = true;
            this.conditionsList.AllowCategories = false;
            this.conditionsList.AllowRemove = true;
            this.conditionsList.DisplayToolbar = true;
            this.conditionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conditionsList.ImageList = null;
            this.conditionsList.Location = new System.Drawing.Point(4, 25);
            this.conditionsList.Master = false;
            this.conditionsList.MultipleSelection = false;
            this.conditionsList.Name = "conditionsList";
            this.conditionsList.SelectedIndex = -1;
            this.conditionsList.Size = new System.Drawing.Size(178, 90);
            this.conditionsList.TabIndex = 1;
            this.conditionsList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.conditionsList_RemoveItem);
            this.conditionsList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.conditionsList_SelectItem);
            this.conditionsList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.conditionsList_AddItem);
            // 
            // conditionBox
            // 
            this.conditionBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.conditionBox.Controls.Add(this.orBox);
            this.conditionBox.Controls.Add(this.offBtn);
            this.conditionBox.Controls.Add(this.onBtn);
            this.conditionBox.Enabled = false;
            this.conditionBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.conditionBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.conditionBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.conditionBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.conditionBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.conditionBox.Location = new System.Drawing.Point(12, 428);
            this.conditionBox.Name = "conditionBox";
            this.conditionBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.conditionBox.Size = new System.Drawing.Size(186, 53);
            this.conditionBox.TabIndex = 7;
            this.conditionBox.TabStop = false;
            this.conditionBox.Text = "Condition";
            // 
            // orBox
            // 
            this.orBox.AutoSize = true;
            this.orBox.BackColor = System.Drawing.Color.Transparent;
            this.orBox.Location = new System.Drawing.Point(7, 28);
            this.orBox.Name = "orBox";
            this.orBox.Size = new System.Drawing.Size(37, 17);
            this.orBox.TabIndex = 2;
            this.orBox.Text = "Or";
            this.orBox.UseVisualStyleBackColor = false;
            this.orBox.CheckedChanged += new System.EventHandler(this.orBox_CheckedChanged);
            // 
            // offBtn
            // 
            this.offBtn.AutoSize = true;
            this.offBtn.BackColor = System.Drawing.Color.Transparent;
            this.offBtn.Location = new System.Drawing.Point(126, 27);
            this.offBtn.Name = "offBtn";
            this.offBtn.Size = new System.Drawing.Size(39, 17);
            this.offBtn.TabIndex = 1;
            this.offBtn.TabStop = true;
            this.offBtn.Text = "Off";
            this.offBtn.UseVisualStyleBackColor = false;
            // 
            // onBtn
            // 
            this.onBtn.AutoSize = true;
            this.onBtn.BackColor = System.Drawing.Color.Transparent;
            this.onBtn.Location = new System.Drawing.Point(66, 28);
            this.onBtn.Name = "onBtn";
            this.onBtn.Size = new System.Drawing.Size(39, 17);
            this.onBtn.TabIndex = 0;
            this.onBtn.TabStop = true;
            this.onBtn.Text = "On";
            this.onBtn.UseVisualStyleBackColor = false;
            this.onBtn.CheckedChanged += new System.EventHandler(this.onBtn_CheckedChanged);
            // 
            // switchesBox
            // 
            this.switchesBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.switchesBox.Controls.Add(this.addRemoveList);
            this.switchesBox.Enabled = false;
            this.switchesBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.switchesBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.switchesBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.switchesBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.switchesBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.switchesBox.Location = new System.Drawing.Point(12, 138);
            this.switchesBox.Name = "switchesBox";
            this.switchesBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.switchesBox.Size = new System.Drawing.Size(186, 284);
            this.switchesBox.TabIndex = 2;
            this.switchesBox.TabStop = false;
            this.switchesBox.Text = "Switches";
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
            this.addRemoveList.Size = new System.Drawing.Size(178, 254);
            this.addRemoveList.TabIndex = 1;
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            // 
            // SwitchesDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(208, 513);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.conditionBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.switchesBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SwitchesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Switch Conditions";
            this.impactGroupBox3.ResumeLayout(false);
            this.conditionBox.ResumeLayout(false);
            this.conditionBox.PerformLayout();
            this.switchesBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox switchesBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox conditionBox;
        private System.Windows.Forms.RadioButton offBtn;
        private System.Windows.Forms.RadioButton onBtn;
        private AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private AddRemoveList conditionsList;
        private System.Windows.Forms.CheckBox orBox;
    }
}