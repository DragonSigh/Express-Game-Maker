namespace EGMGame.Docking.Editors
{
    partial class EnemiesEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnemiesEditor));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.workSpace = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.impactGroupBox10 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listStates = new EGMGame.StateboxControl();
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.aniPanel = new EGMGame.AlphaPanel();
            this.btnAssignAnimation = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.animationViewer = new EGMGame.Controls.AnimationViewer();
            this.impactGroupBox8 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listElements = new EGMGame.StateboxControl();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.cbDatabase = new EGMGame.Controls.Game.DatabaseComboBox(this.components);
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnDropItems = new System.Windows.Forms.Button();
            this.btnStealable = new System.Windows.Forms.Button();
            this.nudExperience = new EGMGame.CustomUpDown();
            this.nudGold = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.impactGroupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listSlots = new System.Windows.Forms.ListBox();
            this.cbDefaultEquip = new EGMGame.Controls.Game.EquipmentComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox7 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listPrograms = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.workSpace.SuspendLayout();
            this.impactGroupBox10.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.impactGroupBox8.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGold)).BeginInit();
            this.impactGroupBox5.SuspendLayout();
            this.impactGroupBox7.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::EGMGame.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            this.groupBox1.Size = new System.Drawing.Size(124, 466);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enemies";
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
            this.addRemoveList.Size = new System.Drawing.Size(116, 436);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.Color.Transparent;
            this.workSpace.Controls.Add(this.impactGroupBox10);
            this.workSpace.Controls.Add(this.groupBox2);
            this.workSpace.Controls.Add(this.impactGroupBox8);
            this.workSpace.Controls.Add(this.impactGroupBox1);
            this.workSpace.Controls.Add(this.impactGroupBox2);
            this.workSpace.Controls.Add(this.impactGroupBox5);
            this.workSpace.Controls.Add(this.impactGroupBox7);
            this.workSpace.Enabled = false;
            this.workSpace.Location = new System.Drawing.Point(138, 12);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(538, 454);
            this.workSpace.TabIndex = 46;
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
            this.impactGroupBox10.Location = new System.Drawing.Point(401, 226);
            this.impactGroupBox10.Name = "impactGroupBox10";
            this.impactGroupBox10.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox10.Size = new System.Drawing.Size(124, 210);
            this.impactGroupBox10.TabIndex = 30;
            this.impactGroupBox10.TabStop = false;
            this.impactGroupBox10.Text = "State Efficiency";
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
            this.listStates.Size = new System.Drawing.Size(116, 180);
            this.listStates.TabIndex = 3;
            this.listStates.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            this.listStates.ToolboxCategoryOffset = new System.Drawing.Point(18, 2);
            this.listStates.ToolboxChildImageOffset = new System.Drawing.Point(3, 1);
            this.listStates.ToolboxCollapsedImage = null;
            this.listStates.ToolboxCollapsedImageOffset = new System.Drawing.Point(0, 0);
            this.listStates.ToolboxExpandedImage = null;
            this.listStates.ToolboxExpandedImageOffset = new System.Drawing.Point(0, 0);
            this.toolTip.SetToolTip(this.listStates, "Bonus protection against checked States,");
            this.listStates.ClickStateItem += new EGMGame.StateboxControl.ClickStateItemEvent(this.listStates_ClickStateItem);
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
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(156, 160);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation";
            // 
            // aniPanel
            // 
            this.aniPanel.Location = new System.Drawing.Point(7, 24);
            this.aniPanel.Name = "aniPanel";
            this.aniPanel.Size = new System.Drawing.Size(142, 99);
            this.aniPanel.TabIndex = 39;
            this.aniPanel.DoubleClick += new System.EventHandler(this.label_DoubleClick);
            // 
            // btnAssignAnimation
            // 
            this.btnAssignAnimation.Location = new System.Drawing.Point(7, 129);
            this.btnAssignAnimation.Name = "btnAssignAnimation";
            this.btnAssignAnimation.Size = new System.Drawing.Size(142, 23);
            this.btnAssignAnimation.TabIndex = 38;
            this.btnAssignAnimation.Text = "Assign Actions";
            this.toolTip.SetToolTip(this.btnAssignAnimation, "Assign actions to Enemy. Actions include Idle, Walk, Attack, etc.");
            this.btnAssignAnimation.UseVisualStyleBackColor = true;
            this.btnAssignAnimation.Click += new System.EventHandler(this.btnAssignAnimation_Click);
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
            this.impactGroupBox8.Location = new System.Drawing.Point(401, 6);
            this.impactGroupBox8.Name = "impactGroupBox8";
            this.impactGroupBox8.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox8.Size = new System.Drawing.Size(124, 210);
            this.impactGroupBox8.TabIndex = 29;
            this.impactGroupBox8.TabStop = false;
            this.impactGroupBox8.Text = "Element Efficiency";
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
            this.listElements.Size = new System.Drawing.Size(116, 180);
            this.listElements.TabIndex = 3;
            this.listElements.ToolboxCategoryBackColor = System.Drawing.Color.Empty;
            this.listElements.ToolboxCategoryOffset = new System.Drawing.Point(18, 2);
            this.listElements.ToolboxChildImageOffset = new System.Drawing.Point(3, 1);
            this.listElements.ToolboxCollapsedImage = null;
            this.listElements.ToolboxCollapsedImageOffset = new System.Drawing.Point(0, 0);
            this.listElements.ToolboxExpandedImage = null;
            this.listElements.ToolboxExpandedImageOffset = new System.Drawing.Point(0, 0);
            this.toolTip.SetToolTip(this.listElements, "Bonus protection against Elements.\r\n1-4 = Extra Damage (ex. Water damages Fire)\r\n" +
                    "5 = Neutral\r\n6-8= Lower Damage (ex. Water damages Earth)\r\n9-10 = Healing (ex. Fi" +
                    "re heals Fire)");
            this.listElements.ClickStateItem += new EGMGame.StateboxControl.ClickStateItemEvent(this.listElements_ClickStateItem);
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
            this.impactGroupBox1.Location = new System.Drawing.Point(4, 169);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 62);
            this.impactGroupBox1.TabIndex = 15;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Database";
            // 
            // btnDatabase
            // 
            this.btnDatabase.Image = global::EGMGame.Properties.Resources.database_edit;
            this.btnDatabase.Location = new System.Drawing.Point(113, 28);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(36, 26);
            this.btnDatabase.TabIndex = 24;
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
            this.cbDatabase.Noneable = false;
            this.cbDatabase.Size = new System.Drawing.Size(100, 21);
            this.cbDatabase.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbDatabase, "Choose the database that is linked to this Hero.");
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.btnDropItems);
            this.impactGroupBox2.Controls.Add(this.btnStealable);
            this.impactGroupBox2.Controls.Add(this.nudExperience);
            this.impactGroupBox2.Controls.Add(this.nudGold);
            this.impactGroupBox2.Controls.Add(this.label3);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(166, 125);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(229, 106);
            this.impactGroupBox2.TabIndex = 24;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Settings";
            // 
            // btnDropItems
            // 
            this.btnDropItems.Location = new System.Drawing.Point(9, 69);
            this.btnDropItems.Name = "btnDropItems";
            this.btnDropItems.Size = new System.Drawing.Size(91, 29);
            this.btnDropItems.TabIndex = 30;
            this.btnDropItems.Text = "Drop Items";
            this.btnDropItems.UseVisualStyleBackColor = true;
            this.btnDropItems.Click += new System.EventHandler(this.btnDropItems_Click);
            // 
            // btnStealable
            // 
            this.btnStealable.Location = new System.Drawing.Point(106, 69);
            this.btnStealable.Name = "btnStealable";
            this.btnStealable.Size = new System.Drawing.Size(91, 29);
            this.btnStealable.TabIndex = 29;
            this.btnStealable.Text = "Stealable Items";
            this.btnStealable.UseVisualStyleBackColor = true;
            this.btnStealable.Click += new System.EventHandler(this.btnStealable_Click);
            // 
            // nudExperience
            // 
            this.nudExperience.Location = new System.Drawing.Point(77, 43);
            this.nudExperience.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudExperience.Name = "nudExperience";
            this.nudExperience.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudExperience.OnChange = false;
            this.nudExperience.Size = new System.Drawing.Size(61, 20);
            this.nudExperience.TabIndex = 28;
            this.toolTip.SetToolTip(this.nudExperience, "Experience gained by killing this Enemy.");
            this.nudExperience.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.nudExperience.Validated += new System.EventHandler(this.nudExperience_Validated);
            // 
            // nudGold
            // 
            this.nudGold.Location = new System.Drawing.Point(10, 43);
            this.nudGold.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudGold.Name = "nudGold";
            this.nudGold.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudGold.OnChange = false;
            this.nudGold.Size = new System.Drawing.Size(61, 20);
            this.nudGold.TabIndex = 27;
            this.nudGold.ValueChanged += new System.EventHandler(this.nudPrice_ValueChanged);
            this.nudGold.Validated += new System.EventHandler(this.nudGold_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(74, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Experience";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gold";
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
            this.impactGroupBox5.Location = new System.Drawing.Point(166, 3);
            this.impactGroupBox5.Name = "impactGroupBox5";
            this.impactGroupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox5.Size = new System.Drawing.Size(229, 116);
            this.impactGroupBox5.TabIndex = 17;
            this.impactGroupBox5.TabStop = false;
            this.impactGroupBox5.Text = "Equipment";
            // 
            // listSlots
            // 
            this.listSlots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listSlots.FormattingEnabled = true;
            this.listSlots.Location = new System.Drawing.Point(7, 25);
            this.listSlots.Name = "listSlots";
            this.listSlots.Size = new System.Drawing.Size(85, 80);
            this.listSlots.TabIndex = 16;
            this.listSlots.SelectedIndexChanged += new System.EventHandler(this.listSlots_SelectedIndexChanged);
            // 
            // cbDefaultEquip
            // 
            this.cbDefaultEquip.AllowCategories = true;
            this.cbDefaultEquip.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDefaultEquip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultEquip.FormattingEnabled = true;
            this.cbDefaultEquip.Location = new System.Drawing.Point(98, 38);
            this.cbDefaultEquip.Name = "cbDefaultEquip";
            this.cbDefaultEquip.Noneable = true;
            this.cbDefaultEquip.SelectedNode = null;
            this.cbDefaultEquip.Size = new System.Drawing.Size(108, 21);
            this.cbDefaultEquip.TabIndex = 15;
            this.cbDefaultEquip.SelectedIndexChanged += new System.EventHandler(this.cbDefaultEquip_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(95, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Defaul Equipment";
            // 
            // impactGroupBox7
            // 
            this.impactGroupBox7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox7.CanCollapse = false;
            this.impactGroupBox7.Controls.Add(this.listPrograms);
            this.impactGroupBox7.Controls.Add(this.toolStrip1);
            this.impactGroupBox7.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox7.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox7.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox7.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox7.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox7.Image = null;
            this.impactGroupBox7.IsCollapsed = false;
            this.impactGroupBox7.Location = new System.Drawing.Point(4, 237);
            this.impactGroupBox7.Name = "impactGroupBox7";
            this.impactGroupBox7.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox7.Size = new System.Drawing.Size(391, 206);
            this.impactGroupBox7.TabIndex = 23;
            this.impactGroupBox7.TabStop = false;
            this.impactGroupBox7.Text = "Program";
            // 
            // listPrograms
            // 
            this.listPrograms.BackColor = System.Drawing.Color.White;
            this.listPrograms.ContextMenuStrip = this.contextMenuStrip1;
            this.listPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPrograms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listPrograms.FormattingEnabled = true;
            this.listPrograms.ItemHeight = 24;
            this.listPrograms.Location = new System.Drawing.Point(4, 50);
            this.listPrograms.Name = "listPrograms";
            this.listPrograms.Size = new System.Drawing.Size(383, 151);
            this.listPrograms.TabIndex = 1;
            this.toolTip.SetToolTip(this.listPrograms, "The list of commands to be performed by this Enemy.");
            this.listPrograms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listPrograms_MouseClick);
            this.listPrograms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listPrograms_DrawItem);
            this.listPrograms.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPrograms_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.toolStripLabel3});
            this.toolStrip1.Location = new System.Drawing.Point(4, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(383, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Priority";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(165, 22);
            this.toolStripLabel2.Text = "Action                                         ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel3.Text = "Condition";
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 7000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // EnemiesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(689, 505);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.workSpace);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnemiesEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabPageContextMenuStrip = this.contextMenuStrip1;
            this.Text = "Enemies Editor";
            this.Shown += new System.EventHandler(this.EnemiesEditor_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.workSpace.ResumeLayout(false);
            this.impactGroupBox10.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.impactGroupBox8.ResumeLayout(false);
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGold)).EndInit();
            this.impactGroupBox5.ResumeLayout(false);
            this.impactGroupBox5.PerformLayout();
            this.impactGroupBox7.ResumeLayout(false);
            this.impactGroupBox7.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox7;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        private System.Windows.Forms.Label label;
        private EGMGame.Controls.AnimationViewer animationViewer;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox5;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.DatabaseComboBox cbDatabase;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private EGMGame.Controls.AddRemoveList addRemoveList;
        private System.Windows.Forms.Button btnDatabase;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CustomUpDown nudExperience;
        private CustomUpDown nudGold;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox10;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox8;
        private System.Windows.Forms.Button btnAssignAnimation;
        private System.Windows.Forms.Button btnStealable;
        private EGMGame.StateboxControl listStates;
        private EGMGame.StateboxControl listElements;
        private System.Windows.Forms.ListBox listSlots;
        private EGMGame.Controls.Game.EquipmentComboBox cbDefaultEquip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDropItems;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ListBox listPrograms;
        private EGMGame.Controls.ImpactUI.ImpactPanel workSpace;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private AlphaPanel aniPanel;
        private Controls.UI.DockContextMenu dockContextMenu1;
        private System.Windows.Forms.ToolTip toolTip;

    }
}