namespace EGMGame
{
    partial class ItemSkillConditionDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbCompare = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConditions = new System.Windows.Forms.ComboBox();
            this.panelItem = new System.Windows.Forms.Panel();
            this.panelCanItembeused = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cbItemCanBeUsedBy = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelItemBuy = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbItemGoldVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelItemPartyPanel = new System.Windows.Forms.Panel();
            this.cbItemPartyIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbItemVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.cbItemCondition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelItemScope = new System.Windows.Forms.Panel();
            this.cbItemScope = new System.Windows.Forms.ComboBox();
            this.panelEquip = new System.Windows.Forms.Panel();
            this.panelEquipmentBuy = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEquipmentGoldvar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbEquipVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbEquipCondition = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEquipParty = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEquipPartyIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelSkill = new System.Windows.Forms.Panel();
            this.cbSkillVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cbSkillCondition = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panelSkillPartyPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSkillPartyIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelSkillScope = new System.Windows.Forms.Panel();
            this.cbSkillScope = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelCanItembeused.SuspendLayout();
            this.panelItemBuy.SuspendLayout();
            this.panelItemPartyPanel.SuspendLayout();
            this.panelItemScope.SuspendLayout();
            this.panelEquip.SuspendLayout();
            this.panelEquipmentBuy.SuspendLayout();
            this.panelEquipParty.SuspendLayout();
            this.panelSkill.SuspendLayout();
            this.panelSkillPartyPanel.SuspendLayout();
            this.panelSkillScope.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(153, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(72, 282);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(12, 260);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 61;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbCompare);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbConditions);
            this.impactGroupBox1.Controls.Add(this.panelItem);
            this.impactGroupBox1.Controls.Add(this.panelEquip);
            this.impactGroupBox1.Controls.Add(this.panelSkill);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(213, 242);
            this.impactGroupBox1.TabIndex = 63;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // cbCompare
            // 
            this.cbCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompare.FormattingEnabled = true;
            this.cbCompare.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Not Equals"});
            this.cbCompare.Location = new System.Drawing.Point(144, 41);
            this.cbCompare.Name = "cbCompare";
            this.cbCompare.Size = new System.Drawing.Size(62, 21);
            this.cbCompare.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Select the condition.";
            // 
            // cbConditions
            // 
            this.cbConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditions.FormattingEnabled = true;
            this.cbConditions.Items.AddRange(new object[] {
            "Item",
            "Skill",
            "Equipment"});
            this.cbConditions.Location = new System.Drawing.Point(10, 41);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(128, 21);
            this.cbConditions.TabIndex = 51;
            this.cbConditions.SelectedIndexChanged += new System.EventHandler(this.cbConditions_SelectedIndexChanged);
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelItem.Controls.Add(this.panelCanItembeused);
            this.panelItem.Controls.Add(this.panelItemBuy);
            this.panelItem.Controls.Add(this.panelItemPartyPanel);
            this.panelItem.Controls.Add(this.cbItemVar);
            this.panelItem.Controls.Add(this.label9);
            this.panelItem.Controls.Add(this.cbItemCondition);
            this.panelItem.Controls.Add(this.label8);
            this.panelItem.Controls.Add(this.panelItemScope);
            this.panelItem.Location = new System.Drawing.Point(10, 68);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(165, 163);
            this.panelItem.TabIndex = 64;
            // 
            // panelCanItembeused
            // 
            this.panelCanItembeused.Controls.Add(this.label12);
            this.panelCanItembeused.Controls.Add(this.cbItemCanBeUsedBy);
            this.panelCanItembeused.Location = new System.Drawing.Point(6, 83);
            this.panelCanItembeused.Name = "panelCanItembeused";
            this.panelCanItembeused.Size = new System.Drawing.Size(153, 68);
            this.panelCanItembeused.TabIndex = 67;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(0, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Select the party member\'s index.";
            // 
            // cbItemCanBeUsedBy
            // 
            this.cbItemCanBeUsedBy.AllowCategories = true;
            this.cbItemCanBeUsedBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItemCanBeUsedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemCanBeUsedBy.FormattingEnabled = true;
            this.cbItemCanBeUsedBy.Location = new System.Drawing.Point(3, 17);
            this.cbItemCanBeUsedBy.Name = "cbItemCanBeUsedBy";
            this.cbItemCanBeUsedBy.SelectedNode = null;
            this.cbItemCanBeUsedBy.Size = new System.Drawing.Size(129, 21);
            this.cbItemCanBeUsedBy.TabIndex = 0;
            // 
            // panelItemBuy
            // 
            this.panelItemBuy.Controls.Add(this.label7);
            this.panelItemBuy.Controls.Add(this.cbItemGoldVar);
            this.panelItemBuy.Location = new System.Drawing.Point(6, 83);
            this.panelItemBuy.Name = "panelItemBuy";
            this.panelItemBuy.Size = new System.Drawing.Size(153, 68);
            this.panelItemBuy.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(0, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Select the gold. ";
            // 
            // cbItemGoldVar
            // 
            this.cbItemGoldVar.AllowCategories = true;
            this.cbItemGoldVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItemGoldVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemGoldVar.FormattingEnabled = true;
            this.cbItemGoldVar.Location = new System.Drawing.Point(3, 17);
            this.cbItemGoldVar.Name = "cbItemGoldVar";
            this.cbItemGoldVar.SelectedNode = null;
            this.cbItemGoldVar.Size = new System.Drawing.Size(129, 21);
            this.cbItemGoldVar.TabIndex = 0;
            // 
            // panelItemPartyPanel
            // 
            this.panelItemPartyPanel.Controls.Add(this.cbItemPartyIndex);
            this.panelItemPartyPanel.Location = new System.Drawing.Point(6, 83);
            this.panelItemPartyPanel.Name = "panelItemPartyPanel";
            this.panelItemPartyPanel.Size = new System.Drawing.Size(153, 68);
            this.panelItemPartyPanel.TabIndex = 56;
            // 
            // cbItemPartyIndex
            // 
            this.cbItemPartyIndex.AllowCategories = true;
            this.cbItemPartyIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItemPartyIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemPartyIndex.FormattingEnabled = true;
            this.cbItemPartyIndex.Location = new System.Drawing.Point(3, 3);
            this.cbItemPartyIndex.Name = "cbItemPartyIndex";
            this.cbItemPartyIndex.SelectedNode = null;
            this.cbItemPartyIndex.Size = new System.Drawing.Size(129, 21);
            this.cbItemPartyIndex.TabIndex = 0;
            // 
            // cbItemVar
            // 
            this.cbItemVar.AllowCategories = true;
            this.cbItemVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItemVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemVar.FormattingEnabled = true;
            this.cbItemVar.Location = new System.Drawing.Point(6, 16);
            this.cbItemVar.Name = "cbItemVar";
            this.cbItemVar.SelectedNode = null;
            this.cbItemVar.Size = new System.Drawing.Size(151, 21);
            this.cbItemVar.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(3, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 65;
            this.label9.Text = "Select the condition.";
            // 
            // cbItemCondition
            // 
            this.cbItemCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemCondition.FormattingEnabled = true;
            this.cbItemCondition.Items.AddRange(new object[] {
            "Scope",
            "Can Use On Party Member",
            "Can Use On Party",
            "Can be Bought",
            "Can be Sold",
            "Can be used by"});
            this.cbItemCondition.Location = new System.Drawing.Point(6, 56);
            this.cbItemCondition.Name = "cbItemCondition";
            this.cbItemCondition.Size = new System.Drawing.Size(153, 21);
            this.cbItemCondition.TabIndex = 64;
            this.cbItemCondition.SelectedIndexChanged += new System.EventHandler(this.cbItemCondition_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Select the item.";
            // 
            // panelItemScope
            // 
            this.panelItemScope.Controls.Add(this.cbItemScope);
            this.panelItemScope.Location = new System.Drawing.Point(6, 83);
            this.panelItemScope.Name = "panelItemScope";
            this.panelItemScope.Size = new System.Drawing.Size(153, 68);
            this.panelItemScope.TabIndex = 55;
            // 
            // cbItemScope
            // 
            this.cbItemScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemScope.FormattingEnabled = true;
            this.cbItemScope.Items.AddRange(new object[] {
            "User",
            "One Ally",
            "All Party",
            "One Enemy",
            "All Enemies",
            "One Ally (Dead)",
            "All Party (Dead)",
            "None"});
            this.cbItemScope.Location = new System.Drawing.Point(0, 3);
            this.cbItemScope.Name = "cbItemScope";
            this.cbItemScope.Size = new System.Drawing.Size(110, 21);
            this.cbItemScope.TabIndex = 19;
            // 
            // panelEquip
            // 
            this.panelEquip.BackColor = System.Drawing.Color.Transparent;
            this.panelEquip.Controls.Add(this.panelEquipmentBuy);
            this.panelEquip.Controls.Add(this.cbEquipVar);
            this.panelEquip.Controls.Add(this.label2);
            this.panelEquip.Controls.Add(this.cbEquipCondition);
            this.panelEquip.Controls.Add(this.label3);
            this.panelEquip.Controls.Add(this.panelEquipParty);
            this.panelEquip.Location = new System.Drawing.Point(10, 68);
            this.panelEquip.Name = "panelEquip";
            this.panelEquip.Size = new System.Drawing.Size(165, 163);
            this.panelEquip.TabIndex = 66;
            // 
            // panelEquipmentBuy
            // 
            this.panelEquipmentBuy.Controls.Add(this.label6);
            this.panelEquipmentBuy.Controls.Add(this.cbEquipmentGoldvar);
            this.panelEquipmentBuy.Location = new System.Drawing.Point(6, 83);
            this.panelEquipmentBuy.Name = "panelEquipmentBuy";
            this.panelEquipmentBuy.Size = new System.Drawing.Size(153, 68);
            this.panelEquipmentBuy.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(0, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Select the gold. ";
            // 
            // cbEquipmentGoldvar
            // 
            this.cbEquipmentGoldvar.AllowCategories = true;
            this.cbEquipmentGoldvar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipmentGoldvar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentGoldvar.FormattingEnabled = true;
            this.cbEquipmentGoldvar.Location = new System.Drawing.Point(3, 17);
            this.cbEquipmentGoldvar.Name = "cbEquipmentGoldvar";
            this.cbEquipmentGoldvar.SelectedNode = null;
            this.cbEquipmentGoldvar.Size = new System.Drawing.Size(129, 21);
            this.cbEquipmentGoldvar.TabIndex = 0;
            // 
            // cbEquipVar
            // 
            this.cbEquipVar.AllowCategories = true;
            this.cbEquipVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipVar.FormattingEnabled = true;
            this.cbEquipVar.Location = new System.Drawing.Point(6, 16);
            this.cbEquipVar.Name = "cbEquipVar";
            this.cbEquipVar.SelectedNode = null;
            this.cbEquipVar.Size = new System.Drawing.Size(151, 21);
            this.cbEquipVar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Select the condition.";
            // 
            // cbEquipCondition
            // 
            this.cbEquipCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipCondition.FormattingEnabled = true;
            this.cbEquipCondition.Items.AddRange(new object[] {
            "Can be equippped by",
            "Is Offensive",
            "Can be Bought",
            "Can be Sold"});
            this.cbEquipCondition.Location = new System.Drawing.Point(6, 56);
            this.cbEquipCondition.Name = "cbEquipCondition";
            this.cbEquipCondition.Size = new System.Drawing.Size(153, 21);
            this.cbEquipCondition.TabIndex = 64;
            this.cbEquipCondition.SelectedIndexChanged += new System.EventHandler(this.cbEquipCondition_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Select the equipment.";
            // 
            // panelEquipParty
            // 
            this.panelEquipParty.Controls.Add(this.label4);
            this.panelEquipParty.Controls.Add(this.cbEquipPartyIndex);
            this.panelEquipParty.Location = new System.Drawing.Point(6, 83);
            this.panelEquipParty.Name = "panelEquipParty";
            this.panelEquipParty.Size = new System.Drawing.Size(153, 68);
            this.panelEquipParty.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Select the party member\'s index.";
            // 
            // cbEquipPartyIndex
            // 
            this.cbEquipPartyIndex.AllowCategories = true;
            this.cbEquipPartyIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipPartyIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipPartyIndex.FormattingEnabled = true;
            this.cbEquipPartyIndex.Location = new System.Drawing.Point(3, 17);
            this.cbEquipPartyIndex.Name = "cbEquipPartyIndex";
            this.cbEquipPartyIndex.SelectedNode = null;
            this.cbEquipPartyIndex.Size = new System.Drawing.Size(129, 21);
            this.cbEquipPartyIndex.TabIndex = 0;
            // 
            // panelSkill
            // 
            this.panelSkill.BackColor = System.Drawing.Color.Transparent;
            this.panelSkill.Controls.Add(this.cbSkillVar);
            this.panelSkill.Controls.Add(this.label10);
            this.panelSkill.Controls.Add(this.cbSkillCondition);
            this.panelSkill.Controls.Add(this.label11);
            this.panelSkill.Controls.Add(this.panelSkillPartyPanel);
            this.panelSkill.Controls.Add(this.panelSkillScope);
            this.panelSkill.Location = new System.Drawing.Point(10, 68);
            this.panelSkill.Name = "panelSkill";
            this.panelSkill.Size = new System.Drawing.Size(165, 163);
            this.panelSkill.TabIndex = 65;
            // 
            // cbSkillVar
            // 
            this.cbSkillVar.AllowCategories = true;
            this.cbSkillVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkillVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkillVar.FormattingEnabled = true;
            this.cbSkillVar.Location = new System.Drawing.Point(6, 16);
            this.cbSkillVar.Name = "cbSkillVar";
            this.cbSkillVar.SelectedNode = null;
            this.cbSkillVar.Size = new System.Drawing.Size(151, 21);
            this.cbSkillVar.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(3, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Select the condition.";
            // 
            // cbSkillCondition
            // 
            this.cbSkillCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkillCondition.FormattingEnabled = true;
            this.cbSkillCondition.Items.AddRange(new object[] {
            "Scope",
            "Can Use On Party Member",
            "Can Use On Party",
            "Can be used by"});
            this.cbSkillCondition.Location = new System.Drawing.Point(6, 56);
            this.cbSkillCondition.Name = "cbSkillCondition";
            this.cbSkillCondition.Size = new System.Drawing.Size(153, 21);
            this.cbSkillCondition.TabIndex = 64;
            this.cbSkillCondition.SelectedIndexChanged += new System.EventHandler(this.cbSkillCondition_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Select the skill.";
            // 
            // panelSkillPartyPanel
            // 
            this.panelSkillPartyPanel.Controls.Add(this.label5);
            this.panelSkillPartyPanel.Controls.Add(this.cbSkillPartyIndex);
            this.panelSkillPartyPanel.Location = new System.Drawing.Point(6, 83);
            this.panelSkillPartyPanel.Name = "panelSkillPartyPanel";
            this.panelSkillPartyPanel.Size = new System.Drawing.Size(153, 68);
            this.panelSkillPartyPanel.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(0, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Select the party member\'s index.";
            // 
            // cbSkillPartyIndex
            // 
            this.cbSkillPartyIndex.AllowCategories = true;
            this.cbSkillPartyIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkillPartyIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkillPartyIndex.FormattingEnabled = true;
            this.cbSkillPartyIndex.Location = new System.Drawing.Point(3, 17);
            this.cbSkillPartyIndex.Name = "cbSkillPartyIndex";
            this.cbSkillPartyIndex.SelectedNode = null;
            this.cbSkillPartyIndex.Size = new System.Drawing.Size(129, 21);
            this.cbSkillPartyIndex.TabIndex = 0;
            // 
            // panelSkillScope
            // 
            this.panelSkillScope.Controls.Add(this.cbSkillScope);
            this.panelSkillScope.Location = new System.Drawing.Point(6, 83);
            this.panelSkillScope.Name = "panelSkillScope";
            this.panelSkillScope.Size = new System.Drawing.Size(153, 68);
            this.panelSkillScope.TabIndex = 55;
            // 
            // cbSkillScope
            // 
            this.cbSkillScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkillScope.FormattingEnabled = true;
            this.cbSkillScope.Items.AddRange(new object[] {
            "User",
            "One Ally",
            "All Party",
            "One Enemy",
            "All Enemies",
            "One Ally (Dead)",
            "All Party (Dead)",
            "None"});
            this.cbSkillScope.Location = new System.Drawing.Point(0, 3);
            this.cbSkillScope.Name = "cbSkillScope";
            this.cbSkillScope.Size = new System.Drawing.Size(132, 21);
            this.cbSkillScope.TabIndex = 19;
            // 
            // ItemSkillConditionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(240, 317);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSkillConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item/Skill/Equip. Conditions";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.panelCanItembeused.ResumeLayout(false);
            this.panelCanItembeused.PerformLayout();
            this.panelItemBuy.ResumeLayout(false);
            this.panelItemBuy.PerformLayout();
            this.panelItemPartyPanel.ResumeLayout(false);
            this.panelItemScope.ResumeLayout(false);
            this.panelEquip.ResumeLayout(false);
            this.panelEquip.PerformLayout();
            this.panelEquipmentBuy.ResumeLayout(false);
            this.panelEquipmentBuy.PerformLayout();
            this.panelEquipParty.ResumeLayout(false);
            this.panelEquipParty.PerformLayout();
            this.panelSkill.ResumeLayout(false);
            this.panelSkill.PerformLayout();
            this.panelSkillPartyPanel.ResumeLayout(false);
            this.panelSkillPartyPanel.PerformLayout();
            this.panelSkillScope.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbConditions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.CheckBox elseBranc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCompare;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.ComboBox cbItemCondition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelItemScope;
        private Controls.Game.VariableComboBox cbItemVar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbItemScope;
        private System.Windows.Forms.Panel panelSkill;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSkillCondition;
        private System.Windows.Forms.Panel panelSkillScope;
        private System.Windows.Forms.ComboBox cbSkillScope;
        private System.Windows.Forms.Panel panelItemPartyPanel;
        private Controls.Game.VariableComboBox cbItemPartyIndex;
        private System.Windows.Forms.Panel panelSkillPartyPanel;
        private Controls.Game.VariableComboBox cbSkillPartyIndex;
        private Controls.Game.VariableComboBox cbSkillVar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelEquip;
        private System.Windows.Forms.Panel panelEquipParty;
        private System.Windows.Forms.Label label4;
        private Controls.Game.VariableComboBox cbEquipPartyIndex;
        private Controls.Game.VariableComboBox cbEquipVar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEquipCondition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelEquipmentBuy;
        private System.Windows.Forms.Label label6;
        private Controls.Game.VariableComboBox cbEquipmentGoldvar;
        private System.Windows.Forms.Panel panelItemBuy;
        private System.Windows.Forms.Label label7;
        private Controls.Game.VariableComboBox cbItemGoldVar;
        private System.Windows.Forms.Panel panelCanItembeused;
        private System.Windows.Forms.Label label12;
        private Controls.Game.VariableComboBox cbItemCanBeUsedBy;

    }
}