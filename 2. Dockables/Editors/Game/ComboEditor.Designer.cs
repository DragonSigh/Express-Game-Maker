namespace EGMGame.Docking.Editors
{
    partial class ComboEditor
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.startNud = new System.Windows.Forms.NumericUpDown();
            this.cbEffects = new System.Windows.Forms.ComboBox();
            this.endNud = new System.Windows.Forms.NumericUpDown();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNud)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.startNud);
            this.impactGroupBox1.Controls.Add(this.cbEffects);
            this.impactGroupBox1.Controls.Add(this.endNud);
            this.impactGroupBox1.Enabled = false;
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(142, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(327, 146);
            this.impactGroupBox1.TabIndex = 8;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Effect";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "End Combo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Starting Combo";
            // 
            // startNud
            // 
            this.startNud.Location = new System.Drawing.Point(118, 42);
            this.startNud.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.startNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startNud.Name = "startNud";
            this.startNud.Size = new System.Drawing.Size(120, 20);
            this.startNud.TabIndex = 4;
            this.startNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startNud.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // cbEffects
            // 
            this.cbEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEffects.FormattingEnabled = true;
            this.cbEffects.Items.AddRange(new object[] {
            "Increase Experience By 5%",
            "Increase Damage By 5%"});
            this.cbEffects.Location = new System.Drawing.Point(118, 102);
            this.cbEffects.Name = "cbEffects";
            this.cbEffects.Size = new System.Drawing.Size(187, 21);
            this.cbEffects.TabIndex = 6;
            this.cbEffects.SelectedIndexChanged += new System.EventHandler(this.cbEffects_SelectedIndexChanged);
            // 
            // endNud
            // 
            this.endNud.Location = new System.Drawing.Point(118, 70);
            this.endNud.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.endNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endNud.Name = "endNud";
            this.endNud.Size = new System.Drawing.Size(120, 20);
            this.endNud.TabIndex = 5;
            this.endNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endNud.ValueChanged += new System.EventHandler(this.endNud_ValueChanged);
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
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
            this.groupBox1.Size = new System.Drawing.Size(124, 275);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Combos";
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
            this.addRemoveList.Margin = new System.Windows.Forms.Padding(4);
            this.addRemoveList.Master = true;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(116, 245);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // ComboEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 299);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.groupBox1);
            this.HideOnClose = true;
            this.Name = "ComboEditor";
            this.Text = "Combos";
            this.Activated += new System.EventHandler(this.ComboEditor_Activated);
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNud)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private EGMGame.Controls.AddRemoveList addRemoveList;
        private System.Windows.Forms.NumericUpDown startNud;
        private System.Windows.Forms.NumericUpDown endNud;
        private System.Windows.Forms.ComboBox cbEffects;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Controls.UI.DockContextMenu dockContextMenu1;
    }
}