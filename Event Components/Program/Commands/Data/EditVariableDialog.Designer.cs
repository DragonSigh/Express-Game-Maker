using EGMGame.Controls;
namespace EGMGame
{
    partial class EditVariableDialog
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
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.otherPanel = new System.Windows.Forms.Panel();
            this.panelNumberOf = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.cbNumberOfItem = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.cbNumberOf = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelEquipment = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.cbEquipments = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelItem = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.cbItems = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.otherList = new System.Windows.Forms.ComboBox();
            this.panelBattler = new System.Windows.Forms.Panel();
            this.cbBattlerProperty = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.eventsPanel = new System.Windows.Forms.Panel();
            this.eventList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.eventPropertyList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.axisPanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.axisPlayerList = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.axisListBox = new System.Windows.Forms.ComboBox();
            this.sitckListBox = new System.Windows.Forms.ComboBox();
            this.mousePanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.coordinateTypeList = new System.Windows.Forms.ComboBox();
            this.mousePositionBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.numericDatasetList = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.databaseItemList = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.databaseList = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.variablePanel = new System.Windows.Forms.Panel();
            this.variablesList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.localVariablePanel = new System.Windows.Forms.Panel();
            this.localVariableList = new EGMGame.Controls.Game.LocalVariableComboBox(this.components);
            this.randPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rand2Num = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rand1Num = new EGMGame.CustomUpDown();
            this.constantPanel = new System.Windows.Forms.Panel();
            this.constantBox = new EGMGame.CustomUpDown();
            this.valueTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.operationsList = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.otherPanel.SuspendLayout();
            this.panelNumberOf.SuspendLayout();
            this.panelEquipment.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelBattler.SuspendLayout();
            this.eventsPanel.SuspendLayout();
            this.axisPanel.SuspendLayout();
            this.mousePanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.variablePanel.SuspendLayout();
            this.localVariablePanel.SuspendLayout();
            this.randPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rand2Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rand1Num)).BeginInit();
            this.constantPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(322, 274);
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
            this.okBtn.Location = new System.Drawing.Point(241, 274);
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
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.addRemoveList);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(145, 285);
            this.impactGroupBox1.TabIndex = 10;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Variables";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowClipboard = true;
            this.addRemoveList.AllowRemove = true;
            this.addRemoveList.DisplayToolbar = true;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.Export = true;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Import = true;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = false;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(137, 255);
            this.addRemoveList.TabIndex = 1;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.eventsPanel);
            this.impactGroupBox2.Controls.Add(this.axisPanel);
            this.impactGroupBox2.Controls.Add(this.mousePanel);
            this.impactGroupBox2.Controls.Add(this.label10);
            this.impactGroupBox2.Controls.Add(this.label9);
            this.impactGroupBox2.Controls.Add(this.dataPanel);
            this.impactGroupBox2.Controls.Add(this.variablePanel);
            this.impactGroupBox2.Controls.Add(this.localVariablePanel);
            this.impactGroupBox2.Controls.Add(this.randPanel);
            this.impactGroupBox2.Controls.Add(this.constantPanel);
            this.impactGroupBox2.Controls.Add(this.valueTypeBox);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Controls.Add(this.operationsList);
            this.impactGroupBox2.Controls.Add(this.otherPanel);
            this.impactGroupBox2.Controls.Add(this.panelBattler);
            this.impactGroupBox2.Enabled = false;
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(164, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(232, 225);
            this.impactGroupBox2.TabIndex = 20;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Operation";
            // 
            // otherPanel
            // 
            this.otherPanel.BackColor = System.Drawing.Color.Transparent;
            this.otherPanel.Controls.Add(this.panelNumberOf);
            this.otherPanel.Controls.Add(this.panelEquipment);
            this.otherPanel.Controls.Add(this.panelItem);
            this.otherPanel.Controls.Add(this.otherList);
            this.otherPanel.Location = new System.Drawing.Point(10, 112);
            this.otherPanel.Name = "otherPanel";
            this.otherPanel.Size = new System.Drawing.Size(204, 113);
            this.otherPanel.TabIndex = 35;
            this.otherPanel.Visible = false;
            // 
            // panelNumberOf
            // 
            this.panelNumberOf.Controls.Add(this.label18);
            this.panelNumberOf.Controls.Add(this.cbNumberOfItem);
            this.panelNumberOf.Controls.Add(this.label17);
            this.panelNumberOf.Controls.Add(this.cbNumberOf);
            this.panelNumberOf.Location = new System.Drawing.Point(3, 25);
            this.panelNumberOf.Name = "panelNumberOf";
            this.panelNumberOf.Size = new System.Drawing.Size(185, 85);
            this.panelNumberOf.TabIndex = 78;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(3, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(140, 13);
            this.label18.TabIndex = 77;
            this.label18.Text = "Choose the item/equipment.";
            // 
            // cbNumberOfItem
            // 
            this.cbNumberOfItem.AllowCategories = true;
            this.cbNumberOfItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNumberOfItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumberOfItem.FormattingEnabled = true;
            this.cbNumberOfItem.Location = new System.Drawing.Point(4, 59);
            this.cbNumberOfItem.Name = "cbNumberOfItem";
            this.cbNumberOfItem.Noneable = false;
            this.cbNumberOfItem.SelectedNode = null;
            this.cbNumberOfItem.Size = new System.Drawing.Size(133, 21);
            this.cbNumberOfItem.TabIndex = 76;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(1, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 13);
            this.label17.TabIndex = 75;
            this.label17.Text = "Choose the party index.";
            // 
            // cbNumberOf
            // 
            this.cbNumberOf.AllowCategories = true;
            this.cbNumberOf.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNumberOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumberOf.FormattingEnabled = true;
            this.cbNumberOf.Location = new System.Drawing.Point(2, 21);
            this.cbNumberOf.Name = "cbNumberOf";
            this.cbNumberOf.Noneable = false;
            this.cbNumberOf.SelectedNode = null;
            this.cbNumberOf.Size = new System.Drawing.Size(133, 21);
            this.cbNumberOf.TabIndex = 31;
            // 
            // panelEquipment
            // 
            this.panelEquipment.Controls.Add(this.label15);
            this.panelEquipment.Controls.Add(this.cbEquipments);
            this.panelEquipment.Location = new System.Drawing.Point(3, 25);
            this.panelEquipment.Name = "panelEquipment";
            this.panelEquipment.Size = new System.Drawing.Size(185, 58);
            this.panelEquipment.TabIndex = 77;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(1, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(163, 13);
            this.label15.TabIndex = 75;
            this.label15.Text = "Choose the equipment\'s variable.";
            // 
            // cbEquipments
            // 
            this.cbEquipments.AllowCategories = true;
            this.cbEquipments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipments.FormattingEnabled = true;
            this.cbEquipments.Location = new System.Drawing.Point(2, 21);
            this.cbEquipments.Name = "cbEquipments";
            this.cbEquipments.Noneable = false;
            this.cbEquipments.SelectedNode = null;
            this.cbEquipments.Size = new System.Drawing.Size(133, 21);
            this.cbEquipments.TabIndex = 31;
            // 
            // panelItem
            // 
            this.panelItem.Controls.Add(this.label14);
            this.panelItem.Controls.Add(this.cbItems);
            this.panelItem.Location = new System.Drawing.Point(3, 25);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(185, 58);
            this.panelItem.TabIndex = 76;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(1, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 75;
            this.label14.Text = "Choose the item\'s variable.";
            // 
            // cbItems
            // 
            this.cbItems.AllowCategories = true;
            this.cbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(2, 21);
            this.cbItems.Name = "cbItems";
            this.cbItems.Noneable = false;
            this.cbItems.SelectedNode = null;
            this.cbItems.Size = new System.Drawing.Size(133, 21);
            this.cbItems.TabIndex = 31;
            // 
            // otherList
            // 
            this.otherList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.otherList.FormattingEnabled = true;
            this.otherList.Items.AddRange(new object[] {
            "Current Map ID",
            "Hit Counter",
            "Last Exp Gained",
            "Total Exp Gained",
            "Item Price",
            "Equipment Price",
            "Party Size",
            "Number of Items",
            "Number of Equipments"});
            this.otherList.Location = new System.Drawing.Point(3, 4);
            this.otherList.Name = "otherList";
            this.otherList.Size = new System.Drawing.Size(133, 21);
            this.otherList.TabIndex = 30;
            this.otherList.SelectedIndexChanged += new System.EventHandler(this.otherList_SelectedIndexChanged);
            // 
            // panelBattler
            // 
            this.panelBattler.BackColor = System.Drawing.Color.Transparent;
            this.panelBattler.Controls.Add(this.cbBattlerProperty);
            this.panelBattler.Controls.Add(this.label16);
            this.panelBattler.Location = new System.Drawing.Point(10, 112);
            this.panelBattler.Name = "panelBattler";
            this.panelBattler.Size = new System.Drawing.Size(204, 110);
            this.panelBattler.TabIndex = 36;
            this.panelBattler.Visible = false;
            // 
            // cbBattlerProperty
            // 
            this.cbBattlerProperty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBattlerProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBattlerProperty.FormattingEnabled = true;
            this.cbBattlerProperty.Location = new System.Drawing.Point(70, 10);
            this.cbBattlerProperty.Name = "cbBattlerProperty";
            this.cbBattlerProperty.Size = new System.Drawing.Size(125, 21);
            this.cbBattlerProperty.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(9, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Property";
            // 
            // eventsPanel
            // 
            this.eventsPanel.BackColor = System.Drawing.Color.Transparent;
            this.eventsPanel.Controls.Add(this.eventList);
            this.eventsPanel.Controls.Add(this.eventPropertyList);
            this.eventsPanel.Controls.Add(this.label7);
            this.eventsPanel.Location = new System.Drawing.Point(10, 112);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(204, 34);
            this.eventsPanel.TabIndex = 35;
            this.eventsPanel.Visible = false;
            // 
            // eventList
            // 
            this.eventList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventList.FormattingEnabled = true;
            this.eventList.Location = new System.Drawing.Point(9, 7);
            this.eventList.Name = "eventList";
            this.eventList.ShowPlayer = true;
            this.eventList.ShowTarget = true;
            this.eventList.ShowTargets = false;
            this.eventList.Size = new System.Drawing.Size(85, 21);
            this.eventList.TabIndex = 40;
            this.eventList.ThisEvent = true;
            // 
            // eventPropertyList
            // 
            this.eventPropertyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventPropertyList.FormattingEnabled = true;
            this.eventPropertyList.Items.AddRange(new object[] {
            "Position X",
            "Position Y",
            "Map ID",
            "Angle",
            "Force X",
            "Force Y",
            "Mass"});
            this.eventPropertyList.Location = new System.Drawing.Point(108, 7);
            this.eventPropertyList.Name = "eventPropertyList";
            this.eventPropertyList.Size = new System.Drawing.Size(87, 21);
            this.eventPropertyList.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(94, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "\'s";
            // 
            // axisPanel
            // 
            this.axisPanel.BackColor = System.Drawing.Color.Transparent;
            this.axisPanel.Controls.Add(this.label13);
            this.axisPanel.Controls.Add(this.axisPlayerList);
            this.axisPanel.Controls.Add(this.label11);
            this.axisPanel.Controls.Add(this.axisListBox);
            this.axisPanel.Controls.Add(this.sitckListBox);
            this.axisPanel.Location = new System.Drawing.Point(10, 112);
            this.axisPanel.Name = "axisPanel";
            this.axisPanel.Size = new System.Drawing.Size(202, 105);
            this.axisPanel.TabIndex = 74;
            this.axisPanel.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(4, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 75;
            this.label13.Text = "Choose the player.";
            // 
            // axisPlayerList
            // 
            this.axisPlayerList.DisplayMember = "Constant";
            this.axisPlayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.axisPlayerList.FormattingEnabled = true;
            this.axisPlayerList.Items.AddRange(new object[] {
            "Player 1",
            "Player 2",
            "Player 3",
            "Player 4",
            "Last Active Player"});
            this.axisPlayerList.Location = new System.Drawing.Point(7, 46);
            this.axisPlayerList.Name = "axisPlayerList";
            this.axisPlayerList.Size = new System.Drawing.Size(87, 21);
            this.axisPlayerList.TabIndex = 74;
            this.axisPlayerList.ValueMember = "Constant";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(88, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "\'s";
            // 
            // axisListBox
            // 
            this.axisListBox.DisplayMember = "Constant";
            this.axisListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.axisListBox.FormattingEnabled = true;
            this.axisListBox.Items.AddRange(new object[] {
            "X-Axis",
            "Y-Axis"});
            this.axisListBox.Location = new System.Drawing.Point(108, 3);
            this.axisListBox.Name = "axisListBox";
            this.axisListBox.Size = new System.Drawing.Size(78, 21);
            this.axisListBox.TabIndex = 6;
            this.axisListBox.ValueMember = "Constant";
            // 
            // sitckListBox
            // 
            this.sitckListBox.DisplayMember = "Constant";
            this.sitckListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sitckListBox.FormattingEnabled = true;
            this.sitckListBox.Items.AddRange(new object[] {
            "Right Stick",
            "Left Stick"});
            this.sitckListBox.Location = new System.Drawing.Point(7, 3);
            this.sitckListBox.Name = "sitckListBox";
            this.sitckListBox.Size = new System.Drawing.Size(78, 21);
            this.sitckListBox.TabIndex = 5;
            this.sitckListBox.ValueMember = "Constant";
            // 
            // mousePanel
            // 
            this.mousePanel.BackColor = System.Drawing.Color.Transparent;
            this.mousePanel.Controls.Add(this.label12);
            this.mousePanel.Controls.Add(this.coordinateTypeList);
            this.mousePanel.Controls.Add(this.mousePositionBox);
            this.mousePanel.Location = new System.Drawing.Point(10, 112);
            this.mousePanel.Name = "mousePanel";
            this.mousePanel.Size = new System.Drawing.Size(204, 106);
            this.mousePanel.TabIndex = 73;
            this.mousePanel.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(4, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 13);
            this.label12.TabIndex = 78;
            this.label12.Text = "Choose the coordinate type.\r\n";
            // 
            // coordinateTypeList
            // 
            this.coordinateTypeList.DisplayMember = "Constant";
            this.coordinateTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coordinateTypeList.FormattingEnabled = true;
            this.coordinateTypeList.Items.AddRange(new object[] {
            "Screen Coordinates",
            "Map Coordinates"});
            this.coordinateTypeList.Location = new System.Drawing.Point(7, 44);
            this.coordinateTypeList.Name = "coordinateTypeList";
            this.coordinateTypeList.Size = new System.Drawing.Size(113, 21);
            this.coordinateTypeList.TabIndex = 77;
            this.coordinateTypeList.ValueMember = "Constant";
            // 
            // mousePositionBox
            // 
            this.mousePositionBox.DisplayMember = "Constant";
            this.mousePositionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mousePositionBox.FormattingEnabled = true;
            this.mousePositionBox.Items.AddRange(new object[] {
            "Mouse Position X",
            "Mouse Position Y",
            "Scroll Value"});
            this.mousePositionBox.Location = new System.Drawing.Point(7, 3);
            this.mousePositionBox.Name = "mousePositionBox";
            this.mousePositionBox.Size = new System.Drawing.Size(113, 21);
            this.mousePositionBox.TabIndex = 5;
            this.mousePositionBox.ValueMember = "Constant";
            this.mousePositionBox.SelectedIndexChanged += new System.EventHandler(this.mousePositionBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(4, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "Choose the value for the operation.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(4, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 13);
            this.label9.TabIndex = 71;
            this.label9.Text = "Choose the operation type for the operation.";
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.Transparent;
            this.dataPanel.Controls.Add(this.numericDatasetList);
            this.dataPanel.Controls.Add(this.databaseItemList);
            this.dataPanel.Controls.Add(this.databaseList);
            this.dataPanel.Controls.Add(this.label4);
            this.dataPanel.Controls.Add(this.label6);
            this.dataPanel.Controls.Add(this.label5);
            this.dataPanel.Controls.Add(this.label8);
            this.dataPanel.Location = new System.Drawing.Point(10, 112);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(204, 106);
            this.dataPanel.TabIndex = 35;
            this.dataPanel.Visible = false;
            // 
            // numericDatasetList
            // 
            this.numericDatasetList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.numericDatasetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numericDatasetList.Enabled = false;
            this.numericDatasetList.FormattingEnabled = true;
            this.numericDatasetList.Location = new System.Drawing.Point(70, 60);
            this.numericDatasetList.Name = "numericDatasetList";
            this.numericDatasetList.Size = new System.Drawing.Size(105, 21);
            this.numericDatasetList.TabIndex = 43;
            // 
            // databaseItemList
            // 
            this.databaseItemList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.databaseItemList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseItemList.Enabled = false;
            this.databaseItemList.FormattingEnabled = true;
            this.databaseItemList.Location = new System.Drawing.Point(70, 30);
            this.databaseItemList.Name = "databaseItemList";
            this.databaseItemList.Noneable = false;
            this.databaseItemList.Size = new System.Drawing.Size(105, 21);
            this.databaseItemList.TabIndex = 42;
            this.databaseItemList.SelectedIndexChanged += new System.EventHandler(this.databaseItemList_SelectedIndexChanged);
            // 
            // databaseList
            // 
            this.databaseList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.databaseList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseList.FormattingEnabled = true;
            this.databaseList.Location = new System.Drawing.Point(70, 3);
            this.databaseList.Name = "databaseList";
            this.databaseList.Noneable = false;
            this.databaseList.Size = new System.Drawing.Size(125, 21);
            this.databaseList.TabIndex = 41;
            this.databaseList.SelectedIndexChanged += new System.EventHandler(this.databaseList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(181, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "\'s";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Property";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Database";
            // 
            // variablePanel
            // 
            this.variablePanel.BackColor = System.Drawing.Color.Transparent;
            this.variablePanel.Controls.Add(this.variablesList);
            this.variablePanel.Location = new System.Drawing.Point(10, 112);
            this.variablePanel.Name = "variablePanel";
            this.variablePanel.Size = new System.Drawing.Size(204, 34);
            this.variablePanel.TabIndex = 20;
            this.variablePanel.Visible = false;
            // 
            // variablesList
            // 
            this.variablesList.AllowCategories = true;
            this.variablesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variablesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variablesList.FormattingEnabled = true;
            this.variablesList.Location = new System.Drawing.Point(7, 7);
            this.variablesList.Name = "variablesList";
            this.variablesList.Noneable = false;
            this.variablesList.SelectedNode = null;
            this.variablesList.Size = new System.Drawing.Size(113, 21);
            this.variablesList.TabIndex = 33;
            // 
            // localVariablePanel
            // 
            this.localVariablePanel.BackColor = System.Drawing.Color.Transparent;
            this.localVariablePanel.Controls.Add(this.localVariableList);
            this.localVariablePanel.Location = new System.Drawing.Point(10, 112);
            this.localVariablePanel.Name = "localVariablePanel";
            this.localVariablePanel.Size = new System.Drawing.Size(204, 34);
            this.localVariablePanel.TabIndex = 34;
            this.localVariablePanel.Visible = false;
            // 
            // localVariableList
            // 
            this.localVariableList.AllowCategories = true;
            this.localVariableList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.localVariableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localVariableList.FormattingEnabled = true;
            this.localVariableList.Location = new System.Drawing.Point(6, 7);
            this.localVariableList.Name = "localVariableList";
            this.localVariableList.SelectedNode = null;
            this.localVariableList.Size = new System.Drawing.Size(113, 21);
            this.localVariableList.TabIndex = 34;
            // 
            // randPanel
            // 
            this.randPanel.BackColor = System.Drawing.Color.Transparent;
            this.randPanel.Controls.Add(this.label3);
            this.randPanel.Controls.Add(this.rand2Num);
            this.randPanel.Controls.Add(this.label2);
            this.randPanel.Controls.Add(this.rand1Num);
            this.randPanel.Location = new System.Drawing.Point(10, 112);
            this.randPanel.Name = "randPanel";
            this.randPanel.Size = new System.Drawing.Size(204, 37);
            this.randPanel.TabIndex = 5;
            this.randPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(121, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "-";
            // 
            // rand2Num
            // 
            this.rand2Num.Location = new System.Drawing.Point(138, 7);
            this.rand2Num.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rand2Num.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.rand2Num.Name = "rand2Num";
            this.rand2Num.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rand2Num.OnChange = false;
            this.rand2Num.Size = new System.Drawing.Size(54, 20);
            this.rand2Num.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Between";
            // 
            // rand1Num
            // 
            this.rand1Num.Location = new System.Drawing.Point(61, 7);
            this.rand1Num.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.rand1Num.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.rand1Num.Name = "rand1Num";
            this.rand1Num.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rand1Num.OnChange = false;
            this.rand1Num.Size = new System.Drawing.Size(54, 20);
            this.rand1Num.TabIndex = 14;
            // 
            // constantPanel
            // 
            this.constantPanel.BackColor = System.Drawing.Color.Transparent;
            this.constantPanel.Controls.Add(this.constantBox);
            this.constantPanel.Location = new System.Drawing.Point(10, 112);
            this.constantPanel.Name = "constantPanel";
            this.constantPanel.Size = new System.Drawing.Size(201, 37);
            this.constantPanel.TabIndex = 20;
            // 
            // constantBox
            // 
            this.constantBox.Location = new System.Drawing.Point(7, 7);
            this.constantBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.constantBox.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.constantBox.Name = "constantBox";
            this.constantBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.constantBox.OnChange = false;
            this.constantBox.Size = new System.Drawing.Size(113, 20);
            this.constantBox.TabIndex = 8;
            // 
            // valueTypeBox
            // 
            this.valueTypeBox.DisplayMember = "Constant";
            this.valueTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueTypeBox.FormattingEnabled = true;
            this.valueTypeBox.Items.AddRange(new object[] {
            "Constant",
            "Random Number",
            "Variable",
            "Local Variable",
            "Event",
            "Data",
            "Mouse Position",
            "Controller Axis",
            "This Event",
            "Other"});
            this.valueTypeBox.Location = new System.Drawing.Point(47, 85);
            this.valueTypeBox.Name = "valueTypeBox";
            this.valueTypeBox.Size = new System.Drawing.Size(109, 21);
            this.valueTypeBox.TabIndex = 4;
            this.valueTypeBox.ValueMember = "Constant";
            this.valueTypeBox.SelectedIndexChanged += new System.EventHandler(this.valueTypeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Value";
            // 
            // operationsList
            // 
            this.operationsList.DisplayMember = "Add";
            this.operationsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationsList.FormattingEnabled = true;
            this.operationsList.Items.AddRange(new object[] {
            "Set (=)",
            "Add (+)",
            "Subtract (-)",
            "Multiply (*)",
            "Divide (/)",
            "Exponentiate (^)",
            "Modulate (r)"});
            this.operationsList.Location = new System.Drawing.Point(7, 41);
            this.operationsList.Name = "operationsList";
            this.operationsList.Size = new System.Drawing.Size(121, 21);
            this.operationsList.TabIndex = 2;
            this.operationsList.ValueMember = "Add";
            // 
            // EditVariableDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(409, 309);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditVariableDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Variable";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.otherPanel.ResumeLayout(false);
            this.panelNumberOf.ResumeLayout(false);
            this.panelNumberOf.PerformLayout();
            this.panelEquipment.ResumeLayout(false);
            this.panelEquipment.PerformLayout();
            this.panelItem.ResumeLayout(false);
            this.panelItem.PerformLayout();
            this.panelBattler.ResumeLayout(false);
            this.panelBattler.PerformLayout();
            this.eventsPanel.ResumeLayout(false);
            this.eventsPanel.PerformLayout();
            this.axisPanel.ResumeLayout(false);
            this.axisPanel.PerformLayout();
            this.mousePanel.ResumeLayout(false);
            this.mousePanel.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.variablePanel.ResumeLayout(false);
            this.localVariablePanel.ResumeLayout(false);
            this.randPanel.ResumeLayout(false);
            this.randPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rand2Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rand1Num)).EndInit();
            this.constantPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button okBtn;
        private AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Panel dataPanel;
        private EGMGame.Controls.Game.DataPropertyComboBox numericDatasetList;
        private EGMGame.Controls.Game.DatabaseComboBox databaseItemList;
        private EGMGame.Controls.Game.DatabaseComboBox databaseList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel variablePanel;
        private EGMGame.Controls.Game.VariableComboBox variablesList;
        private System.Windows.Forms.Panel localVariablePanel;
        private EGMGame.Controls.Game.LocalVariableComboBox localVariableList;
        private System.Windows.Forms.Panel eventsPanel;
        private EGMGame.Controls.Game.MapEventComboBox eventList;
        private System.Windows.Forms.ComboBox eventPropertyList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel otherPanel;
        private System.Windows.Forms.ComboBox otherList;
        private System.Windows.Forms.Panel randPanel;
        private System.Windows.Forms.Label label3;
        private CustomUpDown rand2Num;
        private System.Windows.Forms.Label label2;
        private CustomUpDown rand1Num;
        private System.Windows.Forms.Panel constantPanel;
        private CustomUpDown constantBox;
        private System.Windows.Forms.ComboBox valueTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox operationsList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel mousePanel;
        private System.Windows.Forms.ComboBox mousePositionBox;
        private System.Windows.Forms.Panel axisPanel;
        private System.Windows.Forms.ComboBox axisListBox;
        private System.Windows.Forms.ComboBox sitckListBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox coordinateTypeList;
        private System.Windows.Forms.ComboBox axisPlayerList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelBattler;
        private Controls.Game.DataPropertyComboBox cbBattlerProperty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.Label label14;
        private Controls.Game.VariableComboBox cbItems;
        private System.Windows.Forms.Panel panelEquipment;
        private System.Windows.Forms.Label label15;
        private Controls.Game.VariableComboBox cbEquipments;
        private System.Windows.Forms.Panel panelNumberOf;
        private System.Windows.Forms.Label label17;
        private Controls.Game.VariableComboBox cbNumberOf;
        private System.Windows.Forms.Label label18;
        private Controls.Game.VariableComboBox cbNumberOfItem;
    }
}