namespace EGMGame.Docking.Editors
{
    partial class PhysicsQuicksetDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudVelocityX = new EGMGame.CustomUpDown();
            this.nudBounce = new EGMGame.CustomUpDown();
            this.nudFriction = new EGMGame.CustomUpDown();
            this.nudRotDrag = new EGMGame.CustomUpDown();
            this.nudDrag = new EGMGame.CustomUpDown();
            this.nudMass = new EGMGame.CustomUpDown();
            this.nudForce = new EGMGame.CustomUpDown();
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocityX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFriction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotDrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(238, 242);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 41;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(157, 242);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 40;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.label9);
            this.impactGroupBox1.Controls.Add(this.label8);
            this.impactGroupBox1.Controls.Add(this.label7);
            this.impactGroupBox1.Controls.Add(this.label6);
            this.impactGroupBox1.Controls.Add(this.label5);
            this.impactGroupBox1.Controls.Add(this.label4);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.nudVelocityX);
            this.impactGroupBox1.Controls.Add(this.nudBounce);
            this.impactGroupBox1.Controls.Add(this.nudFriction);
            this.impactGroupBox1.Controls.Add(this.nudRotDrag);
            this.impactGroupBox1.Controls.Add(this.nudDrag);
            this.impactGroupBox1.Controls.Add(this.nudMass);
            this.impactGroupBox1.Controls.Add(this.nudForce);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(171, 224);
            this.impactGroupBox1.TabIndex = 8;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(10, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Bounce";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(10, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Friction";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(10, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Rotational Drag";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(10, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Linear Drag";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(10, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Impulse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(10, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Force";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Mass";
            // 
            // nudVelocityX
            // 
            this.nudVelocityX.DecimalPlaces = 3;
            this.nudVelocityX.Location = new System.Drawing.Point(107, 83);
            this.nudVelocityX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudVelocityX.Name = "nudVelocityX";
            this.nudVelocityX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudVelocityX.OnChange = false;
            this.nudVelocityX.Size = new System.Drawing.Size(52, 20);
            this.nudVelocityX.TabIndex = 51;
            this.nudVelocityX.ValueChanged += new System.EventHandler(this.nudVelocityX_ValueChanged);
            // 
            // nudBounce
            // 
            this.nudBounce.DecimalPlaces = 3;
            this.nudBounce.Location = new System.Drawing.Point(107, 187);
            this.nudBounce.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudBounce.Name = "nudBounce";
            this.nudBounce.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBounce.OnChange = false;
            this.nudBounce.Size = new System.Drawing.Size(52, 20);
            this.nudBounce.TabIndex = 50;
            this.nudBounce.ValueChanged += new System.EventHandler(this.nudBounce_ValueChanged);
            // 
            // nudFriction
            // 
            this.nudFriction.DecimalPlaces = 3;
            this.nudFriction.Location = new System.Drawing.Point(107, 161);
            this.nudFriction.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudFriction.Name = "nudFriction";
            this.nudFriction.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFriction.OnChange = false;
            this.nudFriction.Size = new System.Drawing.Size(52, 20);
            this.nudFriction.TabIndex = 49;
            this.nudFriction.ValueChanged += new System.EventHandler(this.nudFriction_ValueChanged);
            // 
            // nudRotDrag
            // 
            this.nudRotDrag.DecimalPlaces = 3;
            this.nudRotDrag.Location = new System.Drawing.Point(107, 135);
            this.nudRotDrag.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRotDrag.Name = "nudRotDrag";
            this.nudRotDrag.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRotDrag.OnChange = false;
            this.nudRotDrag.Size = new System.Drawing.Size(52, 20);
            this.nudRotDrag.TabIndex = 41;
            this.nudRotDrag.ValueChanged += new System.EventHandler(this.nudRotDrag_ValueChanged);
            // 
            // nudDrag
            // 
            this.nudDrag.DecimalPlaces = 3;
            this.nudDrag.Location = new System.Drawing.Point(107, 109);
            this.nudDrag.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDrag.Name = "nudDrag";
            this.nudDrag.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDrag.OnChange = false;
            this.nudDrag.Size = new System.Drawing.Size(52, 20);
            this.nudDrag.TabIndex = 40;
            this.nudDrag.ValueChanged += new System.EventHandler(this.nudDrag_ValueChanged);
            // 
            // nudMass
            // 
            this.nudMass.DecimalPlaces = 3;
            this.nudMass.Location = new System.Drawing.Point(107, 31);
            this.nudMass.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMass.Name = "nudMass";
            this.nudMass.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMass.OnChange = false;
            this.nudMass.Size = new System.Drawing.Size(52, 20);
            this.nudMass.TabIndex = 39;
            this.nudMass.ValueChanged += new System.EventHandler(this.nudMass_ValueChanged);
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 3;
            this.nudForce.Location = new System.Drawing.Point(107, 57);
            this.nudForce.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudForce.Name = "nudForce";
            this.nudForce.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudForce.OnChange = false;
            this.nudForce.Size = new System.Drawing.Size(52, 20);
            this.nudForce.TabIndex = 38;
            this.nudForce.ValueChanged += new System.EventHandler(this.nudForce_ValueChanged);
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
            this.groupBox1.Size = new System.Drawing.Size(124, 224);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quickset";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = false;
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
            this.addRemoveList.Size = new System.Drawing.Size(116, 194);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // PhysicsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 272);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HideOnClose = true;
            this.Name = "PhysicsEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Physics Quickset";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocityX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFriction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotDrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private EGMGame.Controls.AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private Controls.UI.DockContextMenu dockContextMenu1;
        private CustomUpDown nudVelocityX;
        private CustomUpDown nudBounce;
        private CustomUpDown nudFriction;
        private CustomUpDown nudRotDrag;
        private CustomUpDown nudDrag;
        private CustomUpDown nudMass;
        private CustomUpDown nudForce;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}