namespace EGMGame.Docking.Editors.Database
{
    partial class StealableItemsDialog
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
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.barProb = new EGMGame.Controls.CustomTrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.nudProb = new EGMGame.CustomUpDown();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbEquip = new EGMGame.Controls.Game.EquipmentComboBox(this.components);
            this.cbItems = new EGMGame.Controls.Game.ItemsComboBox(this.components);
            this.rbEquipment = new System.Windows.Forms.RadioButton();
            this.rbItem = new System.Windows.Forms.RadioButton();
            this.impactGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProb)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(166, 191);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 38;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(85, 191);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 37;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.barProb);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Controls.Add(this.nudProb);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 107);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(229, 76);
            this.impactGroupBox2.TabIndex = 39;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Probability";
            // 
            // barProb
            // 
            this.barProb.BackColor = System.Drawing.Color.Transparent;
            this.barProb.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.barProb.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barProb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.barProb.IndentHeight = 6;
            this.barProb.Location = new System.Drawing.Point(68, 41);
            this.barProb.Maximum = 100;
            this.barProb.Minimum = 1;
            this.barProb.Name = "barProb";
            this.barProb.Size = new System.Drawing.Size(149, 31);
            this.barProb.TabIndex = 4;
            this.barProb.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.barProb.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.barProb.TickFrequency = 10;
            this.barProb.TickHeight = 2;
            this.barProb.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.barProb.TrackerSize = new System.Drawing.Size(10, 16);
            this.barProb.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.barProb.TrackLineHeight = 3;
            this.barProb.Value = 100;
            this.barProb.ValueChanged += new EGMGame.Controls.ValueChangedHandler(this.barProb_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set the steal probality.";
            // 
            // nudProb
            // 
            this.nudProb.Location = new System.Drawing.Point(10, 48);
            this.nudProb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudProb.Name = "nudProb";
            this.nudProb.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudProb.OnChange = true;
            this.nudProb.Size = new System.Drawing.Size(52, 20);
            this.nudProb.TabIndex = 0;
            this.nudProb.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudProb.ValueChanged += new System.EventHandler(this.nudProb_ValueChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbEquip);
            this.impactGroupBox1.Controls.Add(this.cbItems);
            this.impactGroupBox1.Controls.Add(this.rbEquipment);
            this.impactGroupBox1.Controls.Add(this.rbItem);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(229, 89);
            this.impactGroupBox1.TabIndex = 36;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Select item";
            // 
            // cbEquip
            // 
            this.cbEquip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquip.FormattingEnabled = true;
            this.cbEquip.Location = new System.Drawing.Point(89, 55);
            this.cbEquip.Name = "cbEquip";
            this.cbEquip.Noneable = true;
            this.cbEquip.Size = new System.Drawing.Size(128, 21);
            this.cbEquip.TabIndex = 3;
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(89, 28);
            this.cbItems.Name = "cbItems";
            this.cbItems.Noneable = true;
            this.cbItems.Size = new System.Drawing.Size(128, 21);
            this.cbItems.TabIndex = 2;
            // 
            // rbEquipment
            // 
            this.rbEquipment.AutoSize = true;
            this.rbEquipment.BackColor = System.Drawing.Color.Transparent;
            this.rbEquipment.Location = new System.Drawing.Point(7, 56);
            this.rbEquipment.Name = "rbEquipment";
            this.rbEquipment.Size = new System.Drawing.Size(75, 17);
            this.rbEquipment.TabIndex = 1;
            this.rbEquipment.Text = "Equipment";
            this.rbEquipment.UseVisualStyleBackColor = false;
            // 
            // rbItem
            // 
            this.rbItem.AutoSize = true;
            this.rbItem.BackColor = System.Drawing.Color.Transparent;
            this.rbItem.Checked = true;
            this.rbItem.Location = new System.Drawing.Point(7, 28);
            this.rbItem.Name = "rbItem";
            this.rbItem.Size = new System.Drawing.Size(45, 17);
            this.rbItem.TabIndex = 0;
            this.rbItem.TabStop = true;
            this.rbItem.Text = "Item";
            this.rbItem.UseVisualStyleBackColor = false;
            // 
            // StealableItemsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(253, 226);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StealableItemsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stealable Item";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProb)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.CustomTrackBar barProb;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudProb;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.ItemsComboBox cbItems;
        private System.Windows.Forms.RadioButton rbEquipment;
        private System.Windows.Forms.RadioButton rbItem;
        private EGMGame.Controls.Game.EquipmentComboBox cbEquip;

    }
}