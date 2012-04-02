namespace EGMGame.Docking.Editors
{
    partial class HeroEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeroEditor));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.listStates = new EGMGame.StateboxControl();
            this.cbEquipment = new EGMGame.Controls.Game.ListComboBox(this.components);
            this.btnAssignAnimation = new System.Windows.Forms.Button();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.cbDatabase = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.listElements = new EGMGame.StateboxControl();
            this.cbSkills = new EGMGame.Controls.Game.ListComboBox(this.components);
            this.listMagics = new System.Windows.Forms.TreeView();
            this.cbDefaultEquip = new EGMGame.Controls.Game.EquipmentComboBox(this.components);
            this.listSkills = new System.Windows.Forms.TreeView();
            this.cbItems = new EGMGame.Controls.Game.ListComboBox(this.components);
            this.cbMagic = new EGMGame.Controls.Game.ListComboBox(this.components);
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.workSpace = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.impactGroupBox10 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox11 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.aniPanel = new EGMGame.AlphaPanel();
            this.label = new System.Windows.Forms.Label();
            this.animationViewer = new EGMGame.Controls.AnimationViewer();
            this.impactGroupBox9 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbLockEquipment = new System.Windows.Forms.CheckBox();
            this.cbAutoBattle = new System.Windows.Forms.CheckBox();
            this.cbCanUseSkills = new System.Windows.Forms.CheckBox();
            this.cbCanUseMagic = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox8 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox7 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.addMagicBtn = new System.Windows.Forms.ToolStripButton();
            this.removeMagicBtn = new System.Windows.Forms.ToolStripButton();
            this.impactGroupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listSlots = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox6 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addSkillBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteSkillBtn = new System.Windows.Forms.ToolStripButton();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.groupBox1.SuspendLayout();
            this.workSpace.SuspendLayout();
            this.impactGroupBox10.SuspendLayout();
            this.impactGroupBox11.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.impactGroupBox9.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox8.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox7.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.impactGroupBox5.SuspendLayout();
            this.impactGroupBox6.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.impactGroupBox4.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 7000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // listStates
            // 
            this.listStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listStates.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.listStates.DrawNumbers = true;
            this.listStates.FullRowSelect = true;
            this.listStates.ItemHeight = 20;
            this.listStates.Location = new System.Drawing.Point(4, 25);
            this.listStates.Name = "listStates";
            this.listStates.ShowLines = false;
            this.listStates.Size = new System.Drawing.Size(140, 160);
            this.listStates.TabIndex = 2;
            this.listStates.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            this.listStates.ToolboxCategoryOffset = new System.Drawing.Point(21, 3);
            this.listStates.ToolboxChildImageOffset = new System.Drawing.Point(5, 2);
            this.listStates.ToolboxCollapsedImage = null;
            this.listStates.ToolboxCollapsedImageOffset = new System.Drawing.Point(0, 0);
            this.listStates.ToolboxExpandedImage = null;
            this.listStates.ToolboxExpandedImageOffset = new System.Drawing.Point(0, 0);
            this.toolTip.SetToolTip(this.listStates, "Bonus protection from checked States.");
            this.listStates.ClickStateItem += new EGMGame.StateboxControl.ClickStateItemEvent(this.listStates_ClickStateItem);
            // 
            // cbEquipment
            // 
            this.cbEquipment.AllowCategories = true;
            this.cbEquipment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipment.FormattingEnabled = true;
            this.cbEquipment.Location = new System.Drawing.Point(7, 28);
            this.cbEquipment.Name = "cbEquipment";
            this.cbEquipment.Noneable = true;
            this.cbEquipment.SelectedNode = null;
            this.cbEquipment.Size = new System.Drawing.Size(142, 21);
            this.cbEquipment.TabIndex = 9;
            this.toolTip.SetToolTip(this.cbEquipment, "The List that will store equipments.");
            this.cbEquipment.SelectedIndexChanged += new System.EventHandler(this.cbEquipment_SelectedIndexChanged);
            // 
            // btnAssignAnimation
            // 
            this.btnAssignAnimation.Location = new System.Drawing.Point(7, 130);
            this.btnAssignAnimation.Name = "btnAssignAnimation";
            this.btnAssignAnimation.Size = new System.Drawing.Size(142, 23);
            this.btnAssignAnimation.TabIndex = 37;
            this.btnAssignAnimation.Text = "Assign Actions";
            this.toolTip.SetToolTip(this.btnAssignAnimation, "Assign actions to Hero. Actions include Idle, Walk, Attack, etc.");
            this.btnAssignAnimation.UseVisualStyleBackColor = true;
            this.btnAssignAnimation.Click += new System.EventHandler(this.btnAssignAnimation_Click);
            // 
            // btnDatabase
            // 
            this.btnDatabase.Image = global::EGMGame.Properties.Resources.database_edit;
            this.btnDatabase.Location = new System.Drawing.Point(113, 28);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(36, 26);
            this.btnDatabase.TabIndex = 25;
            this.btnDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnDatabase, "Edit the selected database.");
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // cbDatabase
            // 
            this.cbDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(7, 30);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Noneable = true;
            this.cbDatabase.Size = new System.Drawing.Size(100, 21);
            this.cbDatabase.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbDatabase, "Choose the database that is linked to this Hero.");
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // listElements
            // 
            this.listElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listElements.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.listElements.DrawNumbers = true;
            this.listElements.FullRowSelect = true;
            this.listElements.ItemHeight = 20;
            this.listElements.Location = new System.Drawing.Point(4, 25);
            this.listElements.Name = "listElements";
            this.listElements.ShowLines = false;
            this.listElements.Size = new System.Drawing.Size(140, 160);
            this.listElements.TabIndex = 2;
            this.listElements.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            this.listElements.ToolboxCategoryOffset = new System.Drawing.Point(21, 3);
            this.listElements.ToolboxChildImageOffset = new System.Drawing.Point(5, 2);
            this.listElements.ToolboxCollapsedImage = null;
            this.listElements.ToolboxCollapsedImageOffset = new System.Drawing.Point(0, 0);
            this.listElements.ToolboxExpandedImage = null;
            this.listElements.ToolboxExpandedImageOffset = new System.Drawing.Point(0, 0);
            this.toolTip.SetToolTip(this.listElements, "Bonus protection against Elements.\r\n1-4 = Extra Damage (ex. Water damages Fire)\r\n" +
                    "5 = Neutral\r\n6-8= Lower Damage (ex. Water damages Earth)\r\n9-10 = Healing (ex. Fi" +
                    "re heals Fire)");
            this.listElements.ClickStateItem += new EGMGame.StateboxControl.ClickStateItemEvent(this.listElements_ClickStateItem);
            // 
            // cbSkills
            // 
            this.cbSkills.AllowCategories = true;
            this.cbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Location = new System.Drawing.Point(7, 28);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Noneable = true;
            this.cbSkills.SelectedNode = null;
            this.cbSkills.Size = new System.Drawing.Size(142, 21);
            this.cbSkills.TabIndex = 9;
            this.toolTip.SetToolTip(this.cbSkills, "The List that will store Skills. Can be shared with Magics.");
            this.cbSkills.SelectedIndexChanged += new System.EventHandler(this.cbSkills_SelectedIndexChanged);
            // 
            // listMagics
            // 
            this.listMagics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMagics.Location = new System.Drawing.Point(4, 50);
            this.listMagics.Name = "listMagics";
            this.listMagics.Size = new System.Drawing.Size(206, 112);
            this.listMagics.TabIndex = 0;
            this.toolTip.SetToolTip(this.listMagics, "Add or Remove Magics to learn.");
            this.listMagics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listMagics_MouseDoubleClick);
            // 
            // cbDefaultEquip
            // 
            this.cbDefaultEquip.AllowCategories = true;
            this.cbDefaultEquip.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDefaultEquip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultEquip.FormattingEnabled = true;
            this.cbDefaultEquip.Location = new System.Drawing.Point(98, 41);
            this.cbDefaultEquip.Name = "cbDefaultEquip";
            this.cbDefaultEquip.Noneable = true;
            this.cbDefaultEquip.SelectedNode = null;
            this.cbDefaultEquip.Size = new System.Drawing.Size(108, 21);
            this.cbDefaultEquip.TabIndex = 12;
            this.toolTip.SetToolTip(this.cbDefaultEquip, "The starter equipment equipped by this Hero.");
            this.cbDefaultEquip.SelectedIndexChanged += new System.EventHandler(this.cbDefaultEquip_SelectedIndexChanged);
            // 
            // listSkills
            // 
            this.listSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSkills.Location = new System.Drawing.Point(4, 50);
            this.listSkills.Name = "listSkills";
            this.listSkills.Size = new System.Drawing.Size(206, 102);
            this.listSkills.TabIndex = 1;
            this.toolTip.SetToolTip(this.listSkills, "Add or Remove Skills to learn.");
            this.listSkills.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.listSkills_AfterSelect);
            this.listSkills.DoubleClick += new System.EventHandler(this.listSkills_DoubleClick);
            this.listSkills.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSkills_MouseDoubleClick);
            // 
            // cbItems
            // 
            this.cbItems.AllowCategories = true;
            this.cbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(7, 28);
            this.cbItems.Name = "cbItems";
            this.cbItems.Noneable = true;
            this.cbItems.SelectedNode = null;
            this.cbItems.Size = new System.Drawing.Size(142, 21);
            this.cbItems.TabIndex = 9;
            this.toolTip.SetToolTip(this.cbItems, "The List that will store Items.");
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            // 
            // cbMagic
            // 
            this.cbMagic.AllowCategories = true;
            this.cbMagic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMagic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMagic.FormattingEnabled = true;
            this.cbMagic.Location = new System.Drawing.Point(7, 28);
            this.cbMagic.Name = "cbMagic";
            this.cbMagic.Noneable = true;
            this.cbMagic.SelectedNode = null;
            this.cbMagic.Size = new System.Drawing.Size(142, 21);
            this.cbMagic.TabIndex = 9;
            this.toolTip.SetToolTip(this.cbMagic, "The List that will store Magics. Can be shared with Skills.");
            this.cbMagic.SelectedIndexChanged += new System.EventHandler(this.cbMagic_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox1.CanCollapse = false;
            this.groupBox1.Controls.Add(this.addRemoveList);
            this.groupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox1.Image = null;
            this.groupBox1.IsCollapsed = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(124, 500);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Heroes";
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
            this.addRemoveList.Master = true;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(116, 470);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.Color.Transparent;
            this.workSpace.Controls.Add(this.impactGroupBox10);
            this.workSpace.Controls.Add(this.impactGroupBox11);
            this.workSpace.Controls.Add(this.groupBox2);
            this.workSpace.Controls.Add(this.impactGroupBox9);
            this.workSpace.Controls.Add(this.impactGroupBox1);
            this.workSpace.Controls.Add(this.impactGroupBox8);
            this.workSpace.Controls.Add(this.impactGroupBox2);
            this.workSpace.Controls.Add(this.impactGroupBox7);
            this.workSpace.Controls.Add(this.impactGroupBox5);
            this.workSpace.Controls.Add(this.impactGroupBox6);
            this.workSpace.Controls.Add(this.impactGroupBox4);
            this.workSpace.Controls.Add(this.impactGroupBox3);
            this.workSpace.Enabled = false;
            this.workSpace.Location = new System.Drawing.Point(138, 12);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(541, 506);
            this.workSpace.TabIndex = 45;
            this.workSpace.EnabledChanged += new System.EventHandler(this.workSpace_EnabledChanged);
            // 
            // impactGroupBox10
            // 
            this.impactGroupBox10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox10.CanCollapse = false;
            this.impactGroupBox10.Controls.Add(this.listStates);
            this.impactGroupBox10.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox10.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox10.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox10.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox10.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox10.Image = null;
            this.impactGroupBox10.IsCollapsed = false;
            this.impactGroupBox10.Location = new System.Drawing.Point(386, 200);
            this.impactGroupBox10.Name = "impactGroupBox10";
            this.impactGroupBox10.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox10.Size = new System.Drawing.Size(148, 190);
            this.impactGroupBox10.TabIndex = 29;
            this.impactGroupBox10.TabStop = false;
            this.impactGroupBox10.Text = "State Efficiency";
            // 
            // impactGroupBox11
            // 
            this.impactGroupBox11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox11.CanCollapse = false;
            this.impactGroupBox11.Controls.Add(this.cbEquipment);
            this.impactGroupBox11.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox11.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox11.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox11.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox11.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox11.Image = null;
            this.impactGroupBox11.IsCollapsed = false;
            this.impactGroupBox11.Location = new System.Drawing.Point(3, 301);
            this.impactGroupBox11.Name = "impactGroupBox11";
            this.impactGroupBox11.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox11.Size = new System.Drawing.Size(156, 61);
            this.impactGroupBox11.TabIndex = 11;
            this.impactGroupBox11.TabStop = false;
            this.impactGroupBox11.Text = "Equipment Inventory";
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox2.CanCollapse = false;
            this.groupBox2.Controls.Add(this.aniPanel);
            this.groupBox2.Controls.Add(this.btnAssignAnimation);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Controls.Add(this.animationViewer);
            this.groupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox2.Image = null;
            this.groupBox2.IsCollapsed = false;
            this.groupBox2.Location = new System.Drawing.Point(4, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(156, 160);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation";
            // 
            // aniPanel
            // 
            this.aniPanel.Location = new System.Drawing.Point(7, 25);
            this.aniPanel.Name = "aniPanel";
            this.aniPanel.Size = new System.Drawing.Size(142, 99);
            this.aniPanel.TabIndex = 38;
            this.aniPanel.DoubleClick += new System.EventHandler(this.label_DoubleClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.DarkGray;
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(27, 60);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(108, 26);
            this.label.TabIndex = 4;
            this.label.Text = "Double Click To Add \r\n        Animation";
            this.label.DoubleClick += new System.EventHandler(this.label_DoubleClick);
            // 
            // animationViewer
            // 
            this.animationViewer.AllowZoom = false;
            this.animationViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationViewer.Location = new System.Drawing.Point(7, 25);
            this.animationViewer.Name = "animationViewer";
            this.animationViewer.SelectedFrame = null;
            this.animationViewer.Size = new System.Drawing.Size(142, 99);
            this.animationViewer.TabIndex = 5;
            this.animationViewer.DoubleClick += new System.EventHandler(this.label_DoubleClick);
            this.animationViewer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.animationViewer_MouseDoubleClick);
            // 
            // impactGroupBox9
            // 
            this.impactGroupBox9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox9.CanCollapse = false;
            this.impactGroupBox9.Controls.Add(this.cbLockEquipment);
            this.impactGroupBox9.Controls.Add(this.cbAutoBattle);
            this.impactGroupBox9.Controls.Add(this.cbCanUseSkills);
            this.impactGroupBox9.Controls.Add(this.cbCanUseMagic);
            this.impactGroupBox9.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox9.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox9.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox9.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox9.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox9.Image = null;
            this.impactGroupBox9.IsCollapsed = false;
            this.impactGroupBox9.Location = new System.Drawing.Point(386, 400);
            this.impactGroupBox9.Name = "impactGroupBox9";
            this.impactGroupBox9.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox9.Size = new System.Drawing.Size(148, 95);
            this.impactGroupBox9.TabIndex = 27;
            this.impactGroupBox9.TabStop = false;
            this.impactGroupBox9.Text = "Other";
            // 
            // cbLockEquipment
            // 
            this.cbLockEquipment.AutoSize = true;
            this.cbLockEquipment.BackColor = System.Drawing.Color.Transparent;
            this.cbLockEquipment.Location = new System.Drawing.Point(7, 74);
            this.cbLockEquipment.Name = "cbLockEquipment";
            this.cbLockEquipment.Size = new System.Drawing.Size(103, 17);
            this.cbLockEquipment.TabIndex = 28;
            this.cbLockEquipment.Text = "Lock Equipment";
            this.cbLockEquipment.UseVisualStyleBackColor = false;
            this.cbLockEquipment.CheckedChanged += new System.EventHandler(this.cbLockEquipment_CheckedChanged);
            // 
            // cbAutoBattle
            // 
            this.cbAutoBattle.AutoSize = true;
            this.cbAutoBattle.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoBattle.Location = new System.Drawing.Point(7, 97);
            this.cbAutoBattle.Name = "cbAutoBattle";
            this.cbAutoBattle.Size = new System.Drawing.Size(78, 17);
            this.cbAutoBattle.TabIndex = 27;
            this.cbAutoBattle.Text = "Auto Battle";
            this.cbAutoBattle.UseVisualStyleBackColor = false;
            this.cbAutoBattle.Visible = false;
            this.cbAutoBattle.CheckedChanged += new System.EventHandler(this.cbAutoBattle_CheckedChanged);
            // 
            // cbCanUseSkills
            // 
            this.cbCanUseSkills.AutoSize = true;
            this.cbCanUseSkills.BackColor = System.Drawing.Color.Transparent;
            this.cbCanUseSkills.Location = new System.Drawing.Point(7, 28);
            this.cbCanUseSkills.Name = "cbCanUseSkills";
            this.cbCanUseSkills.Size = new System.Drawing.Size(90, 17);
            this.cbCanUseSkills.TabIndex = 25;
            this.cbCanUseSkills.Text = "Can use skills";
            this.cbCanUseSkills.UseVisualStyleBackColor = false;
            this.cbCanUseSkills.CheckedChanged += new System.EventHandler(this.cbCanUseSkills_CheckedChanged);
            // 
            // cbCanUseMagic
            // 
            this.cbCanUseMagic.AutoSize = true;
            this.cbCanUseMagic.BackColor = System.Drawing.Color.Transparent;
            this.cbCanUseMagic.Location = new System.Drawing.Point(7, 51);
            this.cbCanUseMagic.Name = "cbCanUseMagic";
            this.cbCanUseMagic.Size = new System.Drawing.Size(96, 17);
            this.cbCanUseMagic.TabIndex = 26;
            this.cbCanUseMagic.Text = "Can use magic";
            this.cbCanUseMagic.UseVisualStyleBackColor = false;
            this.cbCanUseMagic.CheckedChanged += new System.EventHandler(this.cbCanUseMagic_CheckedChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.btnDatabase);
            this.impactGroupBox1.Controls.Add(this.cbDatabase);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(4, 166);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 62);
            this.impactGroupBox1.TabIndex = 4;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Database";
            // 
            // impactGroupBox8
            // 
            this.impactGroupBox8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox8.CanCollapse = false;
            this.impactGroupBox8.Controls.Add(this.listElements);
            this.impactGroupBox8.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox8.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox8.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox8.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox8.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox8.Image = null;
            this.impactGroupBox8.IsCollapsed = false;
            this.impactGroupBox8.Location = new System.Drawing.Point(386, 0);
            this.impactGroupBox8.Name = "impactGroupBox8";
            this.impactGroupBox8.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox8.Size = new System.Drawing.Size(148, 190);
            this.impactGroupBox8.TabIndex = 13;
            this.impactGroupBox8.TabStop = false;
            this.impactGroupBox8.Text = "Element Efficiency";
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.cbSkills);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(4, 368);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(156, 61);
            this.impactGroupBox2.TabIndex = 5;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Skills";
            // 
            // impactGroupBox7
            // 
            this.impactGroupBox7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox7.CanCollapse = false;
            this.impactGroupBox7.Controls.Add(this.listMagics);
            this.impactGroupBox7.Controls.Add(this.toolStrip2);
            this.impactGroupBox7.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox7.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox7.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox7.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox7.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox7.Image = null;
            this.impactGroupBox7.IsCollapsed = false;
            this.impactGroupBox7.Location = new System.Drawing.Point(166, 329);
            this.impactGroupBox7.Name = "impactGroupBox7";
            this.impactGroupBox7.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox7.Size = new System.Drawing.Size(214, 167);
            this.impactGroupBox7.TabIndex = 13;
            this.impactGroupBox7.TabStop = false;
            this.impactGroupBox7.Text = "Magics To Learn";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMagicBtn,
            this.removeMagicBtn});
            this.toolStrip2.Location = new System.Drawing.Point(4, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(206, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // addMagicBtn
            // 
            this.addMagicBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addMagicBtn.Image = global::EGMGame.Properties.Resources.add;
            this.addMagicBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addMagicBtn.Name = "addMagicBtn";
            this.addMagicBtn.Size = new System.Drawing.Size(23, 22);
            this.addMagicBtn.Text = "Add Magic";
            this.addMagicBtn.Click += new System.EventHandler(this.addMagicBtn_Click);
            // 
            // removeMagicBtn
            // 
            this.removeMagicBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeMagicBtn.Image = global::EGMGame.Properties.Resources.delete;
            this.removeMagicBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeMagicBtn.Name = "removeMagicBtn";
            this.removeMagicBtn.Size = new System.Drawing.Size(23, 22);
            this.removeMagicBtn.Text = "Remove Magic";
            this.removeMagicBtn.Click += new System.EventHandler(this.removeMagicBtn_Click);
            // 
            // impactGroupBox5
            // 
            this.impactGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox5.CanCollapse = false;
            this.impactGroupBox5.Controls.Add(this.listSlots);
            this.impactGroupBox5.Controls.Add(this.cbDefaultEquip);
            this.impactGroupBox5.Controls.Add(this.label1);
            this.impactGroupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox5.Image = null;
            this.impactGroupBox5.IsCollapsed = false;
            this.impactGroupBox5.Location = new System.Drawing.Point(166, 0);
            this.impactGroupBox5.Name = "impactGroupBox5";
            this.impactGroupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox5.Size = new System.Drawing.Size(214, 160);
            this.impactGroupBox5.TabIndex = 8;
            this.impactGroupBox5.TabStop = false;
            this.impactGroupBox5.Text = "Equipment";
            // 
            // listSlots
            // 
            this.listSlots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listSlots.FormattingEnabled = true;
            this.listSlots.Location = new System.Drawing.Point(7, 28);
            this.listSlots.Name = "listSlots";
            this.listSlots.Size = new System.Drawing.Size(85, 119);
            this.listSlots.TabIndex = 13;
            this.listSlots.SelectedIndexChanged += new System.EventHandler(this.listSlots_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(95, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Default Equipment";
            // 
            // impactGroupBox6
            // 
            this.impactGroupBox6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox6.CanCollapse = false;
            this.impactGroupBox6.Controls.Add(this.listSkills);
            this.impactGroupBox6.Controls.Add(this.toolStrip1);
            this.impactGroupBox6.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox6.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox6.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox6.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox6.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox6.Image = null;
            this.impactGroupBox6.IsCollapsed = false;
            this.impactGroupBox6.Location = new System.Drawing.Point(165, 166);
            this.impactGroupBox6.Name = "impactGroupBox6";
            this.impactGroupBox6.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox6.Size = new System.Drawing.Size(214, 157);
            this.impactGroupBox6.TabIndex = 12;
            this.impactGroupBox6.TabStop = false;
            this.impactGroupBox6.Text = "Skills To Learn";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSkillBtn,
            this.deleteSkillBtn});
            this.toolStrip1.Location = new System.Drawing.Point(4, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(206, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addSkillBtn
            // 
            this.addSkillBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addSkillBtn.Image = global::EGMGame.Properties.Resources.add;
            this.addSkillBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addSkillBtn.Name = "addSkillBtn";
            this.addSkillBtn.Size = new System.Drawing.Size(23, 22);
            this.addSkillBtn.Text = "Add Skill";
            this.addSkillBtn.Click += new System.EventHandler(this.addSkillBtn_Click);
            // 
            // deleteSkillBtn
            // 
            this.deleteSkillBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteSkillBtn.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteSkillBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSkillBtn.Name = "deleteSkillBtn";
            this.deleteSkillBtn.Size = new System.Drawing.Size(23, 22);
            this.deleteSkillBtn.Text = "Delete Skill";
            this.deleteSkillBtn.Click += new System.EventHandler(this.deleteSkillBtn_Click);
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.CanCollapse = false;
            this.impactGroupBox4.Controls.Add(this.cbItems);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Image = null;
            this.impactGroupBox4.IsCollapsed = false;
            this.impactGroupBox4.Location = new System.Drawing.Point(4, 234);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(156, 61);
            this.impactGroupBox4.TabIndex = 10;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Items Inventory";
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.CanCollapse = false;
            this.impactGroupBox3.Controls.Add(this.cbMagic);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Image = null;
            this.impactGroupBox3.IsCollapsed = false;
            this.impactGroupBox3.Location = new System.Drawing.Point(4, 435);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(156, 61);
            this.impactGroupBox3.TabIndex = 10;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Magics";
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // HeroEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(689, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.workSpace);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HeroEditor";
            this.TabText = "Hero Editor";
            this.Text = "Heroe Editor";
            this.Shown += new System.EventHandler(this.HeroEditor_Shown);
            this.groupBox1.ResumeLayout(false);
            this.workSpace.ResumeLayout(false);
            this.impactGroupBox10.ResumeLayout(false);
            this.impactGroupBox11.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.impactGroupBox9.ResumeLayout(false);
            this.impactGroupBox9.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox8.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox7.ResumeLayout(false);
            this.impactGroupBox7.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.impactGroupBox5.ResumeLayout(false);
            this.impactGroupBox5.PerformLayout();
            this.impactGroupBox6.ResumeLayout(false);
            this.impactGroupBox6.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private EGMGame.Controls.AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox5;
        private EGMGame.Controls.Game.DatabaseComboBox cbDatabase;
        private EGMGame.Controls.Game.ListComboBox cbSkills;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private EGMGame.Controls.Game.ListComboBox cbMagic;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private EGMGame.Controls.Game.ListComboBox cbItems;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        private System.Windows.Forms.Label label;
        private EGMGame.Controls.AnimationViewer animationViewer;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox7;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox8;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.CheckBox cbCanUseSkills;
        private System.Windows.Forms.CheckBox cbCanUseMagic;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox9;
        private System.Windows.Forms.CheckBox cbLockEquipment;
        private System.Windows.Forms.CheckBox cbAutoBattle;
        private System.Windows.Forms.Button btnAssignAnimation;
        private EGMGame.Controls.ImpactUI.ImpactPanel workSpace;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox11;
        private EGMGame.Controls.Game.ListComboBox cbEquipment;
        private EGMGame.Controls.Game.EquipmentComboBox cbDefaultEquip;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox10;
        private System.Windows.Forms.ListBox listSlots;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox6;
        private System.Windows.Forms.TreeView listMagics;
        private System.Windows.Forms.TreeView listSkills;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addSkillBtn;
        private System.Windows.Forms.ToolStripButton deleteSkillBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton addMagicBtn;
        private System.Windows.Forms.ToolStripButton removeMagicBtn;
        private EGMGame.StateboxControl listElements;
        private EGMGame.StateboxControl listStates;
        private AlphaPanel aniPanel;
        private Controls.UI.DockContextMenu dockContextMenu1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}