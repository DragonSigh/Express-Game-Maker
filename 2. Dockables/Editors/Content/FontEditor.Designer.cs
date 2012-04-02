namespace EGMGame.Docking.Editors
{
    partial class FontEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontEditor));
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.groupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.graphicsControl = new EGMGame.Controls.SimpleGraphicsControl();
            this.groupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.stylesAddRemoveList = new EGMGame.Controls.AddRemoveList();
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.panelSettings = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.nbLineSpacing = new EGMGame.CustomUpDown();
            this.nbLetterSpacing = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbLineSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLetterSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtFilename);
            this.groupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox2.Location = new System.Drawing.Point(142, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(142, 68);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assign a font to this style.";
            // 
            // txtFilename
            // 
            this.txtFilename.AllowDrop = true;
            this.txtFilename.Location = new System.Drawing.Point(7, 41);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(128, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.Text = "Drag and drop Font here";
            this.txtFilename.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileNameTxt_DragDrop);
            this.txtFilename.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileNameTxt_DragEnter);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox5.Controls.Add(this.graphicsControl);
            this.groupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox5.Location = new System.Drawing.Point(290, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(117, 447);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Font Preview";
            // 
            // graphicsControl
            // 
            this.graphicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsControl.Location = new System.Drawing.Point(4, 25);
            this.graphicsControl.Name = "graphicsControl";
            this.graphicsControl.Size = new System.Drawing.Size(109, 417);
            this.graphicsControl.TabIndex = 0;
            this.graphicsControl.Text = "graphicsControl";
            this.graphicsControl.OnDraw += new System.EventHandler(this.graphicsControl_OnDraw);
            this.graphicsControl.OnInitialize += new System.EventHandler(this.graphicsControl_OnInitialize);
            // 
            // groupBox3
            // 
            this.groupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox3.Controls.Add(this.stylesAddRemoveList);
            this.groupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox3.Location = new System.Drawing.Point(142, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(142, 162);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Styles";
            // 
            // stylesAddRemoveList
            // 
            this.stylesAddRemoveList.AllowAdd = true;
            this.stylesAddRemoveList.AllowCategories = false;
            this.stylesAddRemoveList.AllowClipboard = true;
            this.stylesAddRemoveList.AllowRemove = true;
            this.stylesAddRemoveList.DisplayToolbar = true;
            this.stylesAddRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stylesAddRemoveList.EnableUpDown = true;
            this.stylesAddRemoveList.Export = true;
            this.stylesAddRemoveList.ImageList = null;
            this.stylesAddRemoveList.Import = true;
            this.stylesAddRemoveList.Location = new System.Drawing.Point(4, 25);
            this.stylesAddRemoveList.Master = false;
            this.stylesAddRemoveList.MultipleSelection = false;
            this.stylesAddRemoveList.Name = "stylesAddRemoveList";
            this.stylesAddRemoveList.SelectedIndex = -1;
            this.stylesAddRemoveList.ShowWarning = true;
            this.stylesAddRemoveList.Size = new System.Drawing.Size(134, 132);
            this.stylesAddRemoveList.TabIndex = 2;
            this.stylesAddRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.stylesAddRemoveList_AddItem);
            this.stylesAddRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.stylesAddRemoveList_RemoveItem);
            this.stylesAddRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.stylesAddRemoveList_SelectItem);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox1.Controls.Add(this.addRemoveList);
            this.groupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(124, 447);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fonts";
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
            this.addRemoveList.Size = new System.Drawing.Size(116, 417);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // panelSettings
            // 
            this.panelSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.panelSettings.Controls.Add(this.nbLineSpacing);
            this.panelSettings.Controls.Add(this.nbLetterSpacing);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.label2);
            this.panelSettings.Enabled = false;
            this.panelSettings.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.panelSettings.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.panelSettings.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.panelSettings.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.panelSettings.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.panelSettings.Location = new System.Drawing.Point(142, 254);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.panelSettings.Size = new System.Drawing.Size(142, 75);
            this.panelSettings.TabIndex = 5;
            this.panelSettings.TabStop = false;
            this.panelSettings.Text = "Font";
            // 
            // nbLineSpacing
            // 
            this.nbLineSpacing.Location = new System.Drawing.Point(89, 49);
            this.nbLineSpacing.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nbLineSpacing.Name = "nbLineSpacing";
            this.nbLineSpacing.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nbLineSpacing.OnChange = false;
            this.nbLineSpacing.Size = new System.Drawing.Size(49, 20);
            this.nbLineSpacing.TabIndex = 11;
            this.nbLineSpacing.ValueChanged += new System.EventHandler(this.nbLineSpacing_ValueChanged);
            // 
            // nbLetterSpacing
            // 
            this.nbLetterSpacing.Location = new System.Drawing.Point(89, 23);
            this.nbLetterSpacing.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nbLetterSpacing.Name = "nbLetterSpacing";
            this.nbLetterSpacing.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nbLetterSpacing.OnChange = false;
            this.nbLetterSpacing.Size = new System.Drawing.Size(49, 20);
            this.nbLetterSpacing.TabIndex = 10;
            this.nbLetterSpacing.ValueChanged += new System.EventHandler(this.nbLetterSpacing_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Letter Spacing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Line Spacing";
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // FontEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(419, 471);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FontEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Font Editor";
            this.Text = "Font Editor";
            this.Activated += new System.EventHandler(this.FontEditor_Activated);
            this.Shown += new System.EventHandler(this.FontEditor_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbLineSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLetterSpacing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        internal EGMGame.Controls.AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox3;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox5;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.SimpleGraphicsControl graphicsControl;
        internal EGMGame.Controls.AddRemoveList stylesAddRemoveList;
        private Controls.ImpactUI.ImpactGroupBox panelSettings;
        private CustomUpDown nbLineSpacing;
        private CustomUpDown nbLetterSpacing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Controls.UI.DockContextMenu dockContextMenu1;
    }
}