namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs
{
    partial class ChangeEquipmentPartyDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkFromInvent = new System.Windows.Forms.CheckBox();
            this.cbPartyIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEquipment = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbSlot = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbPartyIndex);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(179, 57);
            this.impactGroupBox1.TabIndex = 1;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Party Member";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(116, 220);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(35, 220);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 24;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.cbSlot);
            this.impactGroupBox2.Controls.Add(this.cbEquipment);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 75);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(179, 116);
            this.impactGroupBox2.TabIndex = 2;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Equipment";
            // 
            // chkFromInvent
            // 
            this.chkFromInvent.AutoSize = true;
            this.chkFromInvent.BackColor = System.Drawing.Color.Transparent;
            this.chkFromInvent.Location = new System.Drawing.Point(12, 197);
            this.chkFromInvent.Name = "chkFromInvent";
            this.chkFromInvent.Size = new System.Drawing.Size(163, 17);
            this.chkFromInvent.TabIndex = 26;
            this.chkFromInvent.Text = "Add/Remove From Inventory";
            this.chkFromInvent.UseVisualStyleBackColor = false;
            // 
            // cbPartyIndex
            // 
            this.cbPartyIndex.AllowCategories = true;
            this.cbPartyIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPartyIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartyIndex.FormattingEnabled = true;
            this.cbPartyIndex.Location = new System.Drawing.Point(7, 28);
            this.cbPartyIndex.Name = "cbPartyIndex";
            this.cbPartyIndex.SelectedNode = null;
            this.cbPartyIndex.Size = new System.Drawing.Size(156, 21);
            this.cbPartyIndex.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Select the equipment\'s variable.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Select the slot\'s variable.";
            // 
            // cbEquipment
            // 
            this.cbEquipment.AllowCategories = true;
            this.cbEquipment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipment.FormattingEnabled = true;
            this.cbEquipment.Location = new System.Drawing.Point(7, 41);
            this.cbEquipment.Name = "cbEquipment";
            this.cbEquipment.SelectedNode = null;
            this.cbEquipment.Size = new System.Drawing.Size(156, 21);
            this.cbEquipment.TabIndex = 1;
            // 
            // cbSlot
            // 
            this.cbSlot.AllowCategories = true;
            this.cbSlot.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSlot.FormattingEnabled = true;
            this.cbSlot.Location = new System.Drawing.Point(7, 81);
            this.cbSlot.Name = "cbSlot";
            this.cbSlot.SelectedNode = null;
            this.cbSlot.Size = new System.Drawing.Size(156, 21);
            this.cbSlot.TabIndex = 19;
            // 
            // ChangeEquipmentPartyDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(207, 253);
            this.Controls.Add(this.chkFromInvent);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeEquipmentPartyDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Equipment";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.CheckBox chkFromInvent;
        private Game.VariableComboBox cbPartyIndex;
        private Game.VariableComboBox cbSlot;
        private Game.VariableComboBox cbEquipment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}