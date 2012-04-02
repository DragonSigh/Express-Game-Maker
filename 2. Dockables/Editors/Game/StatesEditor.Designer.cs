namespace EGMGame.Docking.Editors
{
    partial class StatesEditor
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.workSpace = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.impactGroupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.iconPanel = new EGMGame.AlphaPanel();
            this.iconViewer = new EGMGame.Controls.MaterialViewer();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSettings = new System.Windows.Forms.ComboBox();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listStates = new System.Windows.Forms.CheckedListBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.effectsList = new EGMGame.Controls.AddRemoveList();
            this.boxAnimation = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbAction = new EGMGame.Controls.Game.AnimationActionComboBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbAnimation = new EGMGame.Controls.Game.AnimationComboBox(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbParticle = new EGMGame.Controls.Game.ParticleComboBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listElements = new System.Windows.Forms.CheckedListBox();
            this.boxPar = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnChangeBattlerProp = new System.Windows.Forms.Button();
            this.cbValueType = new System.Windows.Forms.ComboBox();
            this.nudValue = new EGMGame.CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProperty = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.boxTime = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbTime = new System.Windows.Forms.ComboBox();
            this.nudTime = new EGMGame.CustomUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudDuration = new EGMGame.CustomUpDown();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.workSpace.SuspendLayout();
            this.impactGroupBox5.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.boxAnimation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.impactGroupBox4.SuspendLayout();
            this.boxPar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.boxTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(124, 405);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "States";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowClipboard = true;
            this.addRemoveList.AllowMenu = true;
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
            this.addRemoveList.Size = new System.Drawing.Size(116, 375);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            this.addRemoveList.RenameItem += new EGMGame.Controls.AddRemoveList.RenameItemEvent(this.addRemoveList_RenameItem);
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.Color.Transparent;
            this.workSpace.Controls.Add(this.impactGroupBox5);
            this.workSpace.Controls.Add(this.impactGroupBox3);
            this.workSpace.Controls.Add(this.impactGroupBox2);
            this.workSpace.Controls.Add(this.impactGroupBox1);
            this.workSpace.Controls.Add(this.boxAnimation);
            this.workSpace.Controls.Add(this.impactGroupBox4);
            this.workSpace.Controls.Add(this.boxPar);
            this.workSpace.Controls.Add(this.boxTime);
            this.workSpace.Enabled = false;
            this.workSpace.Location = new System.Drawing.Point(138, 12);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(441, 404);
            this.workSpace.TabIndex = 44;
            // 
            // impactGroupBox5
            // 
            this.impactGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox5.CanCollapse = false;
            this.impactGroupBox5.Controls.Add(this.iconPanel);
            this.impactGroupBox5.Controls.Add(this.iconViewer);
            this.impactGroupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox5.Image = null;
            this.impactGroupBox5.IsCollapsed = false;
            this.impactGroupBox5.Location = new System.Drawing.Point(5, 4);
            this.impactGroupBox5.Name = "impactGroupBox5";
            this.impactGroupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox5.Size = new System.Drawing.Size(54, 73);
            this.impactGroupBox5.TabIndex = 44;
            this.impactGroupBox5.TabStop = false;
            this.impactGroupBox5.Text = "Icon";
            // 
            // iconPanel
            // 
            this.iconPanel.AllowDrop = true;
            this.iconPanel.Location = new System.Drawing.Point(7, 25);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(40, 40);
            this.iconPanel.TabIndex = 2;
            this.toolTip.SetToolTip(this.iconPanel, "Double click to select the icon.");
            this.iconPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.iconPanel_DragDrop);
            this.iconPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.iconPanel_DragEnter);
            this.iconPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iconViewer_MouseDoubleClick);
            // 
            // iconViewer
            // 
            this.iconViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconViewer.HideTools = true;
            this.iconViewer.Location = new System.Drawing.Point(7, 25);
            this.iconViewer.Name = "iconViewer";
            this.iconViewer.SelectedMaterial = null;
            this.iconViewer.Size = new System.Drawing.Size(40, 40);
            this.iconViewer.TabIndex = 0;
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.CanCollapse = false;
            this.impactGroupBox3.Controls.Add(this.label8);
            this.impactGroupBox3.Controls.Add(this.cbSettings);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Image = null;
            this.impactGroupBox3.IsCollapsed = false;
            this.impactGroupBox3.Location = new System.Drawing.Point(65, 4);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(238, 73);
            this.impactGroupBox3.TabIndex = 43;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Battle Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(10, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Choose the effect in battle.";
            // 
            // cbSettings
            // 
            this.cbSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettings.FormattingEnabled = true;
            this.cbSettings.Items.AddRange(new object[] {
            "None",
            "Can not use magic",
            "Can not use skill",
            "Can not move",
            "Always attack ally",
            "Death",
            "Parameter Change",
            "Can not use item"});
            this.cbSettings.Location = new System.Drawing.Point(13, 44);
            this.cbSettings.Name = "cbSettings";
            this.cbSettings.Size = new System.Drawing.Size(175, 21);
            this.cbSettings.TabIndex = 20;
            this.cbSettings.SelectedIndexChanged += new System.EventHandler(this.cbSettings_SelectedIndexChanged);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.listStates);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(309, 4);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(124, 192);
            this.impactGroupBox2.TabIndex = 36;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "States To Cancel";
            // 
            // listStates
            // 
            this.listStates.CheckOnClick = true;
            this.listStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listStates.FormattingEnabled = true;
            this.listStates.IntegralHeight = false;
            this.listStates.Location = new System.Drawing.Point(4, 25);
            this.listStates.Name = "listStates";
            this.listStates.Size = new System.Drawing.Size(116, 162);
            this.listStates.TabIndex = 2;
            this.toolTip.SetToolTip(this.listStates, "Check the states that will be canceled by this state.");
            this.listStates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listStates_ItemCheck);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.effectsList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(4, 83);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(124, 111);
            this.impactGroupBox1.TabIndex = 32;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Effects";
            // 
            // effectsList
            // 
            this.effectsList.AllowAdd = true;
            this.effectsList.AllowCategories = false;
            this.effectsList.AllowClipboard = true;
            this.effectsList.AllowMenu = true;
            this.effectsList.AllowRemove = true;
            this.effectsList.DisplayToolbar = true;
            this.effectsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.effectsList.EnableUpDown = true;
            this.effectsList.Export = true;
            this.effectsList.ImageList = null;
            this.effectsList.Import = true;
            this.effectsList.Location = new System.Drawing.Point(4, 25);
            this.effectsList.Master = true;
            this.effectsList.MultipleSelection = false;
            this.effectsList.Name = "effectsList";
            this.effectsList.SelectedIndex = -1;
            this.effectsList.ShowWarning = true;
            this.effectsList.Size = new System.Drawing.Size(116, 81);
            this.effectsList.TabIndex = 0;
            this.toolTip.SetToolTip(this.effectsList, "A State may have more then one effect.");
            this.effectsList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.effectsList_AddItem);
            this.effectsList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.effectsList_RemoveItem);
            this.effectsList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.effectsList_SelectItem);
            // 
            // boxAnimation
            // 
            this.boxAnimation.Controls.Add(this.tabPage1);
            this.boxAnimation.Controls.Add(this.tabPage2);
            this.boxAnimation.Enabled = false;
            this.boxAnimation.Location = new System.Drawing.Point(5, 200);
            this.boxAnimation.Name = "boxAnimation";
            this.boxAnimation.SelectedIndex = 0;
            this.boxAnimation.Size = new System.Drawing.Size(123, 113);
            this.boxAnimation.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbAction);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.cbAnimation);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(115, 87);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Animation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbAction
            // 
            this.cbAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Location = new System.Drawing.Point(5, 60);
            this.cbAction.Name = "cbAction";
            this.cbAction.Noneable = false;
            this.cbAction.Size = new System.Drawing.Size(104, 21);
            this.cbAction.TabIndex = 31;
            this.toolTip.SetToolTip(this.cbAction, "The animation and action that will be displayed while the State is active.");
            this.cbAction.SelectedIndexChanged += new System.EventHandler(this.cbAction_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(2, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Choose default action.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(2, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Choose animation.";
            // 
            // cbAnimation
            // 
            this.cbAnimation.AllowCategories = true;
            this.cbAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimation.FormattingEnabled = true;
            this.cbAnimation.Location = new System.Drawing.Point(5, 19);
            this.cbAnimation.Name = "cbAnimation";
            this.cbAnimation.Noneable = true;
            this.cbAnimation.SelectedNode = null;
            this.cbAnimation.Size = new System.Drawing.Size(104, 21);
            this.cbAnimation.TabIndex = 1;
            this.toolTip.SetToolTip(this.cbAnimation, "The animation and action that will be displayed while the State is active.");
            this.cbAnimation.SelectedIndexChanged += new System.EventHandler(this.cbAnimation_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbParticle);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(115, 87);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Particle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbParticle
            // 
            this.cbParticle.AllowCategories = true;
            this.cbParticle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbParticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParticle.FormattingEnabled = true;
            this.cbParticle.Location = new System.Drawing.Point(6, 19);
            this.cbParticle.Name = "cbParticle";
            this.cbParticle.Noneable = true;
            this.cbParticle.SelectedNode = null;
            this.cbParticle.Size = new System.Drawing.Size(100, 21);
            this.cbParticle.TabIndex = 31;
            this.toolTip.SetToolTip(this.cbParticle, "The Particle that will be displayed while this State is active.");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Choose particle.";
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.CanCollapse = false;
            this.impactGroupBox4.Controls.Add(this.listElements);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Image = null;
            this.impactGroupBox4.IsCollapsed = false;
            this.impactGroupBox4.Location = new System.Drawing.Point(309, 200);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(124, 195);
            this.impactGroupBox4.TabIndex = 35;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Neglect Elements";
            // 
            // listElements
            // 
            this.listElements.CheckOnClick = true;
            this.listElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listElements.FormattingEnabled = true;
            this.listElements.IntegralHeight = false;
            this.listElements.Location = new System.Drawing.Point(4, 25);
            this.listElements.Name = "listElements";
            this.listElements.Size = new System.Drawing.Size(116, 165);
            this.listElements.TabIndex = 1;
            this.toolTip.SetToolTip(this.listElements, "Check the elements that will be canceled by this state.");
            this.listElements.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listElements_ItemCheck);
            // 
            // boxPar
            // 
            this.boxPar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.boxPar.CanCollapse = false;
            this.boxPar.Controls.Add(this.btnChangeBattlerProp);
            this.boxPar.Controls.Add(this.cbValueType);
            this.boxPar.Controls.Add(this.nudValue);
            this.boxPar.Controls.Add(this.label5);
            this.boxPar.Controls.Add(this.label2);
            this.boxPar.Controls.Add(this.cbProperty);
            this.boxPar.Enabled = false;
            this.boxPar.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.boxPar.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.boxPar.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.boxPar.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.boxPar.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.boxPar.Image = null;
            this.boxPar.IsCollapsed = false;
            this.boxPar.Location = new System.Drawing.Point(134, 83);
            this.boxPar.Name = "boxPar";
            this.boxPar.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.boxPar.Size = new System.Drawing.Size(169, 113);
            this.boxPar.TabIndex = 39;
            this.boxPar.TabStop = false;
            this.boxPar.Text = "Effect Parameter";
            // 
            // btnChangeBattlerProp
            // 
            this.btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
            this.btnChangeBattlerProp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeBattlerProp.Location = new System.Drawing.Point(139, 40);
            this.btnChangeBattlerProp.Name = "btnChangeBattlerProp";
            this.btnChangeBattlerProp.Size = new System.Drawing.Size(24, 24);
            this.btnChangeBattlerProp.TabIndex = 76;
            this.btnChangeBattlerProp.UseVisualStyleBackColor = true;
            this.btnChangeBattlerProp.Click += new System.EventHandler(this.btnChangeBattlerProp_Click);
            // 
            // cbValueType
            // 
            this.cbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValueType.FormattingEnabled = true;
            this.cbValueType.Items.AddRange(new object[] {
            "Constant",
            "Percentage"});
            this.cbValueType.Location = new System.Drawing.Point(85, 80);
            this.cbValueType.Name = "cbValueType";
            this.cbValueType.Size = new System.Drawing.Size(70, 21);
            this.cbValueType.TabIndex = 25;
            this.toolTip.SetToolTip(this.cbValueType, "Constant - Removes a constant value from property.\r\nPercentage - Removes a percen" +
        "tage value from property.");
            this.cbValueType.SelectedIndexChanged += new System.EventHandler(this.cbValueType_SelectedIndexChanged);
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(10, 81);
            this.nudValue.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudValue.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudValue.Name = "nudValue";
            this.nudValue.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudValue.OnChange = false;
            this.nudValue.Size = new System.Drawing.Size(69, 20);
            this.nudValue.TabIndex = 24;
            this.toolTip.SetToolTip(this.nudValue, "The value to remove from property.");
            this.nudValue.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Add value to Property.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Choose the Property to effect.";
            // 
            // cbProperty
            // 
            this.cbProperty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProperty.FormattingEnabled = true;
            this.cbProperty.Items.AddRange(new object[] {
            "HP",
            "SP",
            "MP",
            "Max HP",
            "Max SP",
            "Max MP ",
            "STR ",
            "DEF ",
            "MSTR ",
            "MDEF ",
            "AGI ",
            "LUK",
            "Level"});
            this.cbProperty.Location = new System.Drawing.Point(10, 41);
            this.cbProperty.Name = "cbProperty";
            this.cbProperty.Size = new System.Drawing.Size(125, 21);
            this.cbProperty.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbProperty, "Choose the property to effect, such as HP.");
            this.cbProperty.SelectedIndexChanged += new System.EventHandler(this.cbProperty_SelectedIndexChanged);
            // 
            // boxTime
            // 
            this.boxTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.boxTime.CanCollapse = false;
            this.boxTime.Controls.Add(this.label16);
            this.boxTime.Controls.Add(this.cbTime);
            this.boxTime.Controls.Add(this.nudTime);
            this.boxTime.Controls.Add(this.label17);
            this.boxTime.Controls.Add(this.label7);
            this.boxTime.Controls.Add(this.label6);
            this.boxTime.Controls.Add(this.nudDuration);
            this.boxTime.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.boxTime.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.boxTime.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.boxTime.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.boxTime.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.boxTime.Image = null;
            this.boxTime.IsCollapsed = false;
            this.boxTime.Location = new System.Drawing.Point(134, 202);
            this.boxTime.Name = "boxTime";
            this.boxTime.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.boxTime.Size = new System.Drawing.Size(125, 136);
            this.boxTime.TabIndex = 41;
            this.boxTime.TabStop = false;
            this.boxTime.Text = "Time";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(67, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "sec. ";
            // 
            // cbTime
            // 
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.DropDownWidth = 100;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Items.AddRange(new object[] {
            "Seconds (Turns)",
            "Till Death",
            "Till Negated"});
            this.cbTime.Location = new System.Drawing.Point(7, 28);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(111, 21);
            this.cbTime.TabIndex = 26;
            this.toolTip.SetToolTip(this.cbTime, "Seconds (Turns) - The state will last a certain number of seconds or turns.\r\nTill" +
        " Death - The state will last until death.\r\nTill Negated - The state will last un" +
        "til death or until negated. ");
            this.cbTime.SelectedIndexChanged += new System.EventHandler(this.cbTime_SelectedIndexChanged);
            // 
            // nudTime
            // 
            this.nudTime.Location = new System.Drawing.Point(10, 68);
            this.nudTime.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudTime.OnChange = true;
            this.nudTime.Size = new System.Drawing.Size(57, 20);
            this.nudTime.TabIndex = 26;
            this.toolTip.SetToolTip(this.nudTime, "The frequency of how many seconds it takes between each effect.");
            this.nudTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTime.ValueChanged += new System.EventHandler(this.nudTime_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(7, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Duration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(67, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "sec. ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Frequency";
            // 
            // nudDuration
            // 
            this.nudDuration.Enabled = false;
            this.nudDuration.Location = new System.Drawing.Point(10, 107);
            this.nudDuration.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDuration.OnChange = true;
            this.nudDuration.Size = new System.Drawing.Size(57, 20);
            this.nudDuration.TabIndex = 31;
            this.toolTip.SetToolTip(this.nudDuration, "The number of seconds the state will last");
            this.nudDuration.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDuration.ValueChanged += new System.EventHandler(this.nudDuration_ValueChanged);
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
            // StatesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(590, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.workSpace);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "StatesEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "States";
            this.Shown += new System.EventHandler(this.ItemEditor_Shown);
            this.groupBox1.ResumeLayout(false);
            this.workSpace.ResumeLayout(false);
            this.impactGroupBox5.ResumeLayout(false);
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox1.ResumeLayout(false);
            this.boxAnimation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.impactGroupBox4.ResumeLayout(false);
            this.boxPar.ResumeLayout(false);
            this.boxPar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.boxTime.ResumeLayout(false);
            this.boxTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.TabControl boxAnimation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private EGMGame.Controls.Game.AnimationComboBox cbAnimation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label12;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox boxTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private CustomUpDown nudDuration;
        private System.Windows.Forms.ComboBox cbTime;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox boxPar;
        private System.Windows.Forms.ComboBox cbValueType;
        private CustomUpDown nudValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private EGMGame.Controls.Game.DataPropertyComboBox cbProperty;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox4;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.AddRemoveList effectsList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private EGMGame.Controls.AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSettings;
        private System.Windows.Forms.CheckedListBox listElements;
        private System.Windows.Forms.ImageList imageList1;
        private EGMGame.Controls.Game.ParticleComboBox cbParticle;
        private EGMGame.Controls.Game.AnimationActionComboBox cbAction;
        private EGMGame.Controls.ImpactUI.ImpactPanel workSpace;
        private CustomUpDown nudTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox5;
        private EGMGame.Controls.MaterialViewer iconViewer;
        private AlphaPanel iconPanel;
        private System.Windows.Forms.Button btnChangeBattlerProp;
        private System.Windows.Forms.CheckedListBox listStates;
        private Controls.UI.DockContextMenu dockContextMenu1;
        private System.Windows.Forms.ToolTip toolTip;

    }
}