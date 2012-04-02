namespace EGMGame
{
    partial class PartyConditionsDialog
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
            this.panelIncludes = new System.Windows.Forms.Panel();
            this.cbHeroes = new EGMGame.Controls.Game.HeroComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panelEquip = new System.Windows.Forms.Panel();
            this.cbEquipments = new EGMGame.Controls.Game.EquipmentComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.panelItem = new System.Windows.Forms.Panel();
            this.cbItems = new EGMGame.Controls.Game.ItemsComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panelBattlerProp = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelConstIndex = new System.Windows.Forms.Panel();
            this.cbConstIndex = new EGMGame.CustomUpDown();
            this.cbIndexType = new System.Windows.Forms.ComboBox();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBattlerOp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBattlerProp = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.panelProperty = new System.Windows.Forms.Panel();
            this.cbValueProp = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.panelConstant = new System.Windows.Forms.Panel();
            this.cbBattlerNud = new EGMGame.CustomUpDown();
            this.panelVarIndex = new System.Windows.Forms.Panel();
            this.cbVarIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConditions = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.panelDeadParty = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panelDeadConstant = new System.Windows.Forms.Panel();
            this.nudDeadPartyIndex = new EGMGame.CustomUpDown();
            this.cbDeadMemberType = new System.Windows.Forms.ComboBox();
            this.panelDeadVariable = new System.Windows.Forms.Panel();
            this.cbDeadPartyIndex = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.impactGroupBox1.SuspendLayout();
            this.panelIncludes.SuspendLayout();
            this.panelEquip.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelBattlerProp.SuspendLayout();
            this.panelConstIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbConstIndex)).BeginInit();
            this.panelProperty.SuspendLayout();
            this.panelConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBattlerNud)).BeginInit();
            this.panelVarIndex.SuspendLayout();
            this.panelDeadParty.SuspendLayout();
            this.panelDeadConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeadPartyIndex)).BeginInit();
            this.panelDeadVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(12, 328);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 79;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.panelDeadParty);
            this.impactGroupBox1.Controls.Add(this.panelBattlerProp);
            this.impactGroupBox1.Controls.Add(this.cbOperator);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbConditions);
            this.impactGroupBox1.Controls.Add(this.panelIncludes);
            this.impactGroupBox1.Controls.Add(this.panelEquip);
            this.impactGroupBox1.Controls.Add(this.panelItem);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(222, 310);
            this.impactGroupBox1.TabIndex = 78;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Condition";
            // 
            // panelIncludes
            // 
            this.panelIncludes.BackColor = System.Drawing.Color.Transparent;
            this.panelIncludes.Controls.Add(this.cbHeroes);
            this.panelIncludes.Controls.Add(this.label5);
            this.panelIncludes.Location = new System.Drawing.Point(3, 65);
            this.panelIncludes.Name = "panelIncludes";
            this.panelIncludes.Size = new System.Drawing.Size(219, 242);
            this.panelIncludes.TabIndex = 76;
            this.panelIncludes.Visible = false;
            // 
            // cbHeroes
            // 
            this.cbHeroes.AllowCategories = true;
            this.cbHeroes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHeroes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeroes.FormattingEnabled = true;
            this.cbHeroes.Location = new System.Drawing.Point(4, 20);
            this.cbHeroes.Name = "cbHeroes";
            this.cbHeroes.Noneable = true;
            this.cbHeroes.SelectedNode = null;
            this.cbHeroes.Size = new System.Drawing.Size(134, 21);
            this.cbHeroes.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select the hero.";
            // 
            // panelEquip
            // 
            this.panelEquip.BackColor = System.Drawing.Color.Transparent;
            this.panelEquip.Controls.Add(this.cbEquipments);
            this.panelEquip.Controls.Add(this.label6);
            this.panelEquip.Location = new System.Drawing.Point(3, 65);
            this.panelEquip.Name = "panelEquip";
            this.panelEquip.Size = new System.Drawing.Size(219, 242);
            this.panelEquip.TabIndex = 75;
            this.panelEquip.Visible = false;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Select the equipment.";
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelItem.Controls.Add(this.cbItems);
            this.panelItem.Controls.Add(this.label7);
            this.panelItem.Location = new System.Drawing.Point(3, 65);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(219, 242);
            this.panelItem.TabIndex = 74;
            this.panelItem.Visible = false;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Select the item.";
            // 
            // panelBattlerProp
            // 
            this.panelBattlerProp.BackColor = System.Drawing.Color.Transparent;
            this.panelBattlerProp.Controls.Add(this.label4);
            this.panelBattlerProp.Controls.Add(this.panelConstIndex);
            this.panelBattlerProp.Controls.Add(this.cbIndexType);
            this.panelBattlerProp.Controls.Add(this.cbValue);
            this.panelBattlerProp.Controls.Add(this.label3);
            this.panelBattlerProp.Controls.Add(this.label10);
            this.panelBattlerProp.Controls.Add(this.cbBattlerOp);
            this.panelBattlerProp.Controls.Add(this.label2);
            this.panelBattlerProp.Controls.Add(this.cbBattlerProp);
            this.panelBattlerProp.Controls.Add(this.panelProperty);
            this.panelBattlerProp.Controls.Add(this.panelConstant);
            this.panelBattlerProp.Controls.Add(this.panelVarIndex);
            this.panelBattlerProp.Location = new System.Drawing.Point(3, 65);
            this.panelBattlerProp.Name = "panelBattlerProp";
            this.panelBattlerProp.Size = new System.Drawing.Size(219, 245);
            this.panelBattlerProp.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(1, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Select the party member index.";
            // 
            // panelConstIndex
            // 
            this.panelConstIndex.Controls.Add(this.cbConstIndex);
            this.panelConstIndex.Location = new System.Drawing.Point(4, 47);
            this.panelConstIndex.Name = "panelConstIndex";
            this.panelConstIndex.Size = new System.Drawing.Size(177, 32);
            this.panelConstIndex.TabIndex = 80;
            // 
            // cbConstIndex
            // 
            this.cbConstIndex.Location = new System.Drawing.Point(3, 3);
            this.cbConstIndex.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.cbConstIndex.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.cbConstIndex.Name = "cbConstIndex";
            this.cbConstIndex.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.cbConstIndex.OnChange = false;
            this.cbConstIndex.Size = new System.Drawing.Size(115, 20);
            this.cbConstIndex.TabIndex = 74;
            // 
            // cbIndexType
            // 
            this.cbIndexType.DisplayMember = "Add";
            this.cbIndexType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndexType.FormattingEnabled = true;
            this.cbIndexType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbIndexType.Location = new System.Drawing.Point(4, 20);
            this.cbIndexType.Name = "cbIndexType";
            this.cbIndexType.Size = new System.Drawing.Size(104, 21);
            this.cbIndexType.TabIndex = 79;
            this.cbIndexType.ValueMember = "Add";
            this.cbIndexType.SelectedIndexChanged += new System.EventHandler(this.cbIndexType_SelectedIndexChanged);
            // 
            // cbValue
            // 
            this.cbValue.DisplayMember = "Add";
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Items.AddRange(new object[] {
            "Constant",
            "Property"});
            this.cbValue.Location = new System.Drawing.Point(4, 182);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(121, 21);
            this.cbValue.TabIndex = 78;
            this.cbValue.ValueMember = "Add";
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Choose the value to compare to.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(4, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Choose the compare type for the condition.";
            // 
            // cbBattlerOp
            // 
            this.cbBattlerOp.DisplayMember = "Add";
            this.cbBattlerOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBattlerOp.FormattingEnabled = true;
            this.cbBattlerOp.Items.AddRange(new object[] {
            "(=) Equals",
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals",
            "(!=) Does Not Equal"});
            this.cbBattlerOp.Location = new System.Drawing.Point(4, 142);
            this.cbBattlerOp.Name = "cbBattlerOp";
            this.cbBattlerOp.Size = new System.Drawing.Size(121, 21);
            this.cbBattlerOp.TabIndex = 72;
            this.cbBattlerOp.ValueMember = "Add";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Select the property.";
            // 
            // cbBattlerProp
            // 
            this.cbBattlerProp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBattlerProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBattlerProp.FormattingEnabled = true;
            this.cbBattlerProp.Location = new System.Drawing.Point(4, 100);
            this.cbBattlerProp.Name = "cbBattlerProp";
            this.cbBattlerProp.Size = new System.Drawing.Size(144, 21);
            this.cbBattlerProp.TabIndex = 0;
            // 
            // panelProperty
            // 
            this.panelProperty.Controls.Add(this.cbValueProp);
            this.panelProperty.Location = new System.Drawing.Point(4, 209);
            this.panelProperty.Name = "panelProperty";
            this.panelProperty.Size = new System.Drawing.Size(177, 32);
            this.panelProperty.TabIndex = 78;
            // 
            // cbValueProp
            // 
            this.cbValueProp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbValueProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValueProp.FormattingEnabled = true;
            this.cbValueProp.Location = new System.Drawing.Point(3, 3);
            this.cbValueProp.Name = "cbValueProp";
            this.cbValueProp.Size = new System.Drawing.Size(141, 21);
            this.cbValueProp.TabIndex = 1;
            // 
            // panelConstant
            // 
            this.panelConstant.Controls.Add(this.cbBattlerNud);
            this.panelConstant.Location = new System.Drawing.Point(4, 209);
            this.panelConstant.Name = "panelConstant";
            this.panelConstant.Size = new System.Drawing.Size(177, 32);
            this.panelConstant.TabIndex = 77;
            // 
            // cbBattlerNud
            // 
            this.cbBattlerNud.Location = new System.Drawing.Point(3, 3);
            this.cbBattlerNud.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.cbBattlerNud.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.cbBattlerNud.Name = "cbBattlerNud";
            this.cbBattlerNud.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.cbBattlerNud.OnChange = false;
            this.cbBattlerNud.Size = new System.Drawing.Size(115, 20);
            this.cbBattlerNud.TabIndex = 74;
            // 
            // panelVarIndex
            // 
            this.panelVarIndex.Controls.Add(this.cbVarIndex);
            this.panelVarIndex.Location = new System.Drawing.Point(4, 47);
            this.panelVarIndex.Name = "panelVarIndex";
            this.panelVarIndex.Size = new System.Drawing.Size(177, 32);
            this.panelVarIndex.TabIndex = 81;
            // 
            // cbVarIndex
            // 
            this.cbVarIndex.AllowCategories = true;
            this.cbVarIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVarIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarIndex.FormattingEnabled = true;
            this.cbVarIndex.Location = new System.Drawing.Point(3, 3);
            this.cbVarIndex.Name = "cbVarIndex";
            this.cbVarIndex.SelectedNode = null;
            this.cbVarIndex.Size = new System.Drawing.Size(164, 21);
            this.cbVarIndex.TabIndex = 0;
            // 
            // cbOperator
            // 
            this.cbOperator.DisplayMember = "Add";
            this.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Not Equals"});
            this.cbOperator.Location = new System.Drawing.Point(147, 41);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(68, 21);
            this.cbOperator.TabIndex = 73;
            this.cbOperator.ValueMember = "Add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the condition.";
            // 
            // cbConditions
            // 
            this.cbConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditions.FormattingEnabled = true;
            this.cbConditions.Items.AddRange(new object[] {
            "Party Member Property",
            "Party Has Item?",
            "Party Has Equipment?",
            "Party Includes?",
            "Party Dead?",
            "Party Member Dead?"});
            this.cbConditions.Location = new System.Drawing.Point(7, 41);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(134, 21);
            this.cbConditions.TabIndex = 0;
            this.cbConditions.SelectedIndexChanged += new System.EventHandler(this.cbConditions_SelectedIndexChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(162, 359);
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
            this.okBtn.Location = new System.Drawing.Point(81, 359);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 76;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // panelDeadParty
            // 
            this.panelDeadParty.BackColor = System.Drawing.Color.Transparent;
            this.panelDeadParty.Controls.Add(this.label8);
            this.panelDeadParty.Controls.Add(this.cbDeadMemberType);
            this.panelDeadParty.Controls.Add(this.panelDeadConstant);
            this.panelDeadParty.Controls.Add(this.panelDeadVariable);
            this.panelDeadParty.Location = new System.Drawing.Point(3, 65);
            this.panelDeadParty.Name = "panelDeadParty";
            this.panelDeadParty.Size = new System.Drawing.Size(219, 245);
            this.panelDeadParty.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(1, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Select the party member index.";
            // 
            // panelDeadConstant
            // 
            this.panelDeadConstant.Controls.Add(this.nudDeadPartyIndex);
            this.panelDeadConstant.Location = new System.Drawing.Point(4, 47);
            this.panelDeadConstant.Name = "panelDeadConstant";
            this.panelDeadConstant.Size = new System.Drawing.Size(177, 32);
            this.panelDeadConstant.TabIndex = 80;
            // 
            // nudDeadPartyIndex
            // 
            this.nudDeadPartyIndex.Location = new System.Drawing.Point(3, 3);
            this.nudDeadPartyIndex.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDeadPartyIndex.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudDeadPartyIndex.Name = "nudDeadPartyIndex";
            this.nudDeadPartyIndex.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudDeadPartyIndex.OnChange = false;
            this.nudDeadPartyIndex.Size = new System.Drawing.Size(115, 20);
            this.nudDeadPartyIndex.TabIndex = 74;
            // 
            // cbDeadMemberType
            // 
            this.cbDeadMemberType.DisplayMember = "Add";
            this.cbDeadMemberType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeadMemberType.FormattingEnabled = true;
            this.cbDeadMemberType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbDeadMemberType.Location = new System.Drawing.Point(4, 20);
            this.cbDeadMemberType.Name = "cbDeadMemberType";
            this.cbDeadMemberType.Size = new System.Drawing.Size(104, 21);
            this.cbDeadMemberType.TabIndex = 79;
            this.cbDeadMemberType.ValueMember = "Add";
            this.cbDeadMemberType.SelectedIndexChanged += new System.EventHandler(this.cbDeadMemberType_SelectedIndexChanged);
            // 
            // panelDeadVariable
            // 
            this.panelDeadVariable.Controls.Add(this.cbDeadPartyIndex);
            this.panelDeadVariable.Location = new System.Drawing.Point(4, 47);
            this.panelDeadVariable.Name = "panelDeadVariable";
            this.panelDeadVariable.Size = new System.Drawing.Size(177, 32);
            this.panelDeadVariable.TabIndex = 81;
            // 
            // cbDeadPartyIndex
            // 
            this.cbDeadPartyIndex.AllowCategories = true;
            this.cbDeadPartyIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDeadPartyIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeadPartyIndex.FormattingEnabled = true;
            this.cbDeadPartyIndex.Location = new System.Drawing.Point(3, 3);
            this.cbDeadPartyIndex.Name = "cbDeadPartyIndex";
            this.cbDeadPartyIndex.SelectedNode = null;
            this.cbDeadPartyIndex.Size = new System.Drawing.Size(164, 21);
            this.cbDeadPartyIndex.TabIndex = 0;
            // 
            // PartyConditionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 394);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartyConditionsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Party Conditions";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelIncludes.ResumeLayout(false);
            this.panelIncludes.PerformLayout();
            this.panelEquip.ResumeLayout(false);
            this.panelEquip.PerformLayout();
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.panelBattlerProp.ResumeLayout(false);
            this.panelBattlerProp.PerformLayout();
            this.panelConstIndex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbConstIndex)).EndInit();
            this.panelProperty.ResumeLayout(false);
            this.panelConstant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbBattlerNud)).EndInit();
            this.panelVarIndex.ResumeLayout(false);
            this.panelDeadParty.ResumeLayout(false);
            this.panelDeadParty.PerformLayout();
            this.panelDeadConstant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDeadPartyIndex)).EndInit();
            this.panelDeadVariable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox elseBranc;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Panel panelBattlerProp;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBattlerOp;
        private System.Windows.Forms.Label label2;
        private Controls.Game.DataPropertyComboBox cbBattlerProp;
        private System.Windows.Forms.Panel panelProperty;
        private System.Windows.Forms.Panel panelConstant;
        private CustomUpDown cbBattlerNud;
        private System.Windows.Forms.ComboBox cbOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConditions;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox cbIndexType;
        private System.Windows.Forms.Panel panelVarIndex;
        private System.Windows.Forms.Panel panelConstIndex;
        private CustomUpDown cbConstIndex;
        private Controls.Game.DataPropertyComboBox cbValueProp;
        private Controls.Game.VariableComboBox cbVarIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelEquip;
        private Controls.Game.EquipmentComboBox cbEquipments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelItem;
        private Controls.Game.ItemsComboBox cbItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelIncludes;
        private Controls.Game.HeroComboBox cbHeroes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelDeadParty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelDeadConstant;
        private CustomUpDown nudDeadPartyIndex;
        private System.Windows.Forms.ComboBox cbDeadMemberType;
        private System.Windows.Forms.Panel panelDeadVariable;
        private Controls.Game.VariableComboBox cbDeadPartyIndex;

    }
}