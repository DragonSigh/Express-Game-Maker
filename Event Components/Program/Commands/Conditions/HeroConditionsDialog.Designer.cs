namespace EGMGame
{
    partial class HeroConditionsDialog
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
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.cbConditionTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHeroes = new EGMGame.Controls.Game.HeroComboBox(this.components);
            this.panelItem = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbItems = new EGMGame.Controls.Game.ItemsComboBox(this.components);
            this.panelEquip = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEquipments = new EGMGame.Controls.Game.EquipmentComboBox(this.components);
            this.panelSkills = new System.Windows.Forms.Panel();
            this.cbSkills = new EGMGame.Controls.Game.EquipmentComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelEquip.SuspendLayout();
            this.panelSkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(12, 196);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 79;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.panelSkills);
            this.impactGroupBox1.Controls.Add(this.panelEquip);
            this.impactGroupBox1.Controls.Add(this.panelItem);
            this.impactGroupBox1.Controls.Add(this.cbHeroes);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbConditionTypes);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(222, 178);
            this.impactGroupBox1.TabIndex = 78;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Condition";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(162, 223);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 77;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(81, 223);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 76;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cbConditionTypes
            // 
            this.cbConditionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditionTypes.FormattingEnabled = true;
            this.cbConditionTypes.Items.AddRange(new object[] {
            "Has Item?",
            "Has Equipment?",
            "Has Skill/Magic?"});
            this.cbConditionTypes.Location = new System.Drawing.Point(10, 81);
            this.cbConditionTypes.Name = "cbConditionTypes";
            this.cbConditionTypes.Size = new System.Drawing.Size(134, 21);
            this.cbConditionTypes.TabIndex = 0;
            this.cbConditionTypes.SelectedIndexChanged += new System.EventHandler(this.cbConditionTypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the condition type.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the hero.";
            // 
            // cbHeroes
            // 
            this.cbHeroes.AllowCategories = true;
            this.cbHeroes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHeroes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeroes.FormattingEnabled = true;
            this.cbHeroes.Location = new System.Drawing.Point(10, 41);
            this.cbHeroes.Name = "cbHeroes";
            this.cbHeroes.Noneable = true;
            this.cbHeroes.SelectedNode = null;
            this.cbHeroes.Size = new System.Drawing.Size(132, 21);
            this.cbHeroes.TabIndex = 3;
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelItem.Controls.Add(this.cbItems);
            this.panelItem.Controls.Add(this.label3);
            this.panelItem.Location = new System.Drawing.Point(10, 108);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(205, 53);
            this.panelItem.TabIndex = 4;
            this.panelItem.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select the item.";
            // 
            // cbItems
            // 
            this.cbItems.AllowCategories = true;
            this.cbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(6, 19);
            this.cbItems.Name = "cbItems";
            this.cbItems.Noneable = true;
            this.cbItems.SelectedNode = null;
            this.cbItems.Size = new System.Drawing.Size(128, 21);
            this.cbItems.TabIndex = 1;
            // 
            // panelEquip
            // 
            this.panelEquip.BackColor = System.Drawing.Color.Transparent;
            this.panelEquip.Controls.Add(this.cbEquipments);
            this.panelEquip.Controls.Add(this.label4);
            this.panelEquip.Location = new System.Drawing.Point(10, 108);
            this.panelEquip.Name = "panelEquip";
            this.panelEquip.Size = new System.Drawing.Size(205, 53);
            this.panelEquip.TabIndex = 5;
            this.panelEquip.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Select the equipment.";
            // 
            // cbEquipments
            // 
            this.cbEquipments.AllowCategories = true;
            this.cbEquipments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipments.FormattingEnabled = true;
            this.cbEquipments.Location = new System.Drawing.Point(6, 19);
            this.cbEquipments.Name = "cbEquipments";
            this.cbEquipments.Noneable = true;
            this.cbEquipments.SelectedNode = null;
            this.cbEquipments.Size = new System.Drawing.Size(128, 21);
            this.cbEquipments.TabIndex = 1;
            // 
            // panelSkills
            // 
            this.panelSkills.BackColor = System.Drawing.Color.Transparent;
            this.panelSkills.Controls.Add(this.cbSkills);
            this.panelSkills.Controls.Add(this.label5);
            this.panelSkills.Location = new System.Drawing.Point(10, 108);
            this.panelSkills.Name = "panelSkills";
            this.panelSkills.Size = new System.Drawing.Size(205, 53);
            this.panelSkills.TabIndex = 6;
            this.panelSkills.Visible = false;
            // 
            // cbSkills
            // 
            this.cbSkills.AllowCategories = true;
            this.cbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Location = new System.Drawing.Point(6, 19);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Noneable = true;
            this.cbSkills.SelectedNode = null;
            this.cbSkills.Size = new System.Drawing.Size(128, 21);
            this.cbSkills.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select the skill/magic.";
            // 
            // HeroConditionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 258);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeroConditionsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hero Conditions";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.panelEquip.ResumeLayout(false);
            this.panelEquip.PerformLayout();
            this.panelSkills.ResumeLayout(false);
            this.panelSkills.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox elseBranc;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConditionTypes;
        private Controls.Game.HeroComboBox cbHeroes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelItem;
        private Controls.Game.ItemsComboBox cbItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSkills;
        private Controls.Game.EquipmentComboBox cbSkills;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelEquip;
        private Controls.Game.EquipmentComboBox cbEquipments;
        private System.Windows.Forms.Label label4;

    }
}