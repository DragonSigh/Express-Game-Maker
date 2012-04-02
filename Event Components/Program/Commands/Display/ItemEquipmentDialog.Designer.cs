namespace EGMGame
{
    partial class ItemEquipmentDialog
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
            this.cbEquipments = new EGMGame.Controls.Game.EquipmentComboBox(this.components);
            this.cbItems = new EGMGame.Controls.Game.ItemsComboBox(this.components);
            this.rbEquipments = new System.Windows.Forms.RadioButton();
            this.rbItems = new System.Windows.Forms.RadioButton();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(167, 133);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(86, 133);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbEquipments);
            this.impactGroupBox1.Controls.Add(this.cbItems);
            this.impactGroupBox1.Controls.Add(this.rbEquipments);
            this.impactGroupBox1.Controls.Add(this.rbItems);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(230, 115);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Select Item or Equipment";
            // 
            // cbEquipments
            // 
            this.cbEquipments.AllowCategories = true;
            this.cbEquipments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEquipments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipments.Enabled = false;
            this.cbEquipments.FormattingEnabled = true;
            this.cbEquipments.Location = new System.Drawing.Point(93, 74);
            this.cbEquipments.Name = "cbEquipments";
            this.cbEquipments.Noneable = false;
            this.cbEquipments.SelectedNode = null;
            this.cbEquipments.Size = new System.Drawing.Size(121, 21);
            this.cbEquipments.TabIndex = 3;
            // 
            // cbItems
            // 
            this.cbItems.AllowCategories = true;
            this.cbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(93, 37);
            this.cbItems.Name = "cbItems";
            this.cbItems.Noneable = false;
            this.cbItems.SelectedNode = null;
            this.cbItems.Size = new System.Drawing.Size(121, 21);
            this.cbItems.TabIndex = 2;
            // 
            // rbEquipments
            // 
            this.rbEquipments.AutoSize = true;
            this.rbEquipments.BackColor = System.Drawing.Color.Transparent;
            this.rbEquipments.Location = new System.Drawing.Point(7, 75);
            this.rbEquipments.Name = "rbEquipments";
            this.rbEquipments.Size = new System.Drawing.Size(80, 17);
            this.rbEquipments.TabIndex = 1;
            this.rbEquipments.Text = "Equipments";
            this.rbEquipments.UseVisualStyleBackColor = false;
            this.rbEquipments.CheckedChanged += new System.EventHandler(this.rbEquipments_CheckedChanged);
            // 
            // rbItems
            // 
            this.rbItems.AutoSize = true;
            this.rbItems.BackColor = System.Drawing.Color.Transparent;
            this.rbItems.Checked = true;
            this.rbItems.Location = new System.Drawing.Point(7, 38);
            this.rbItems.Name = "rbItems";
            this.rbItems.Size = new System.Drawing.Size(50, 17);
            this.rbItems.TabIndex = 0;
            this.rbItems.TabStop = true;
            this.rbItems.Text = "Items";
            this.rbItems.UseVisualStyleBackColor = false;
            this.rbItems.CheckedChanged += new System.EventHandler(this.rbItems_CheckedChanged);
            // 
            // ItemEquipmentDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(253, 167);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemEquipmentDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shop Dialog";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        internal Controls.Game.EquipmentComboBox cbEquipments;
        internal Controls.Game.ItemsComboBox cbItems;
        internal System.Windows.Forms.RadioButton rbEquipments;
        internal System.Windows.Forms.RadioButton rbItems;
    }
}