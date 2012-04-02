namespace EGMGame.Controls.EventControls
{
    partial class EventJointsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventJointsDialog));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.impactGroupBox8 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnAT = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nudATY = new EGMGame.CustomUpDown();
            this.nudATX = new EGMGame.CustomUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.impactGroupBox7 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudValue = new EGMGame.CustomUpDown();
            this.listSettings = new System.Windows.Forms.ListBox();
            this.impactGroupBox6 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnTEAP = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudTEAPY = new EGMGame.CustomUpDown();
            this.nudTEAPX = new EGMGame.CustomUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listJoints = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeBtn = new System.Windows.Forms.ToolStripButton();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbJoints = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEvents = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudATX)).BeginInit();
            this.impactGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.impactGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTEAPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTEAPX)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(400, 322);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 39;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(319, 322);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 38;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox8
            // 
            this.impactGroupBox8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox8.CanCollapse = false;
            this.impactGroupBox8.Controls.Add(this.btnAT);
            this.impactGroupBox8.Controls.Add(this.label9);
            this.impactGroupBox8.Controls.Add(this.nudATY);
            this.impactGroupBox8.Controls.Add(this.nudATX);
            this.impactGroupBox8.Controls.Add(this.label10);
            this.impactGroupBox8.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox8.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox8.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox8.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox8.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox8.Image = null;
            this.impactGroupBox8.IsCollapsed = false;
            this.impactGroupBox8.Location = new System.Drawing.Point(315, 229);
            this.impactGroupBox8.Name = "impactGroupBox8";
            this.impactGroupBox8.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox8.Size = new System.Drawing.Size(160, 87);
            this.impactGroupBox8.TabIndex = 48;
            this.impactGroupBox8.TabStop = false;
            this.impactGroupBox8.Text = "Anchor To";
            // 
            // btnAT
            // 
            this.btnAT.Location = new System.Drawing.Point(100, 31);
            this.btnAT.Name = "btnAT";
            this.btnAT.Size = new System.Drawing.Size(53, 41);
            this.btnAT.TabIndex = 26;
            this.btnAT.Text = "Select";
            this.btnAT.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(7, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Y";
            // 
            // nudATY
            // 
            this.nudATY.Location = new System.Drawing.Point(27, 55);
            this.nudATY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudATY.Name = "nudATY";
            this.nudATY.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudATY.OnChange = false;
            this.nudATY.Size = new System.Drawing.Size(67, 20);
            this.nudATY.TabIndex = 24;
            // 
            // nudATX
            // 
            this.nudATX.Location = new System.Drawing.Point(27, 29);
            this.nudATX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudATX.Name = "nudATX";
            this.nudATX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudATX.OnChange = false;
            this.nudATX.Size = new System.Drawing.Size(67, 20);
            this.nudATX.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(7, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "X";
            // 
            // impactGroupBox7
            // 
            this.impactGroupBox7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox7.CanCollapse = false;
            this.impactGroupBox7.Controls.Add(this.label5);
            this.impactGroupBox7.Controls.Add(this.nudValue);
            this.impactGroupBox7.Controls.Add(this.listSettings);
            this.impactGroupBox7.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox7.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox7.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox7.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox7.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox7.Image = null;
            this.impactGroupBox7.IsCollapsed = false;
            this.impactGroupBox7.Location = new System.Drawing.Point(149, 88);
            this.impactGroupBox7.Name = "impactGroupBox7";
            this.impactGroupBox7.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox7.Size = new System.Drawing.Size(322, 135);
            this.impactGroupBox7.TabIndex = 41;
            this.impactGroupBox7.TabStop = false;
            this.impactGroupBox7.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(130, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Enter Value";
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(133, 44);
            this.nudValue.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudValue.Name = "nudValue";
            this.nudValue.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudValue.OnChange = true;
            this.nudValue.Size = new System.Drawing.Size(94, 20);
            this.nudValue.TabIndex = 27;
            // 
            // listSettings
            // 
            this.listSettings.FormattingEnabled = true;
            this.listSettings.Items.AddRange(new object[] {
            "Breakpoint",
            "Softness",
            "Max Angle",
            "Min Angle",
            "Target Angle",
            "Target Distance"});
            this.listSettings.Location = new System.Drawing.Point(7, 28);
            this.listSettings.Name = "listSettings";
            this.listSettings.Size = new System.Drawing.Size(115, 95);
            this.listSettings.TabIndex = 14;
            // 
            // impactGroupBox6
            // 
            this.impactGroupBox6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox6.CanCollapse = false;
            this.impactGroupBox6.Controls.Add(this.btnTEAP);
            this.impactGroupBox6.Controls.Add(this.label8);
            this.impactGroupBox6.Controls.Add(this.nudTEAPY);
            this.impactGroupBox6.Controls.Add(this.nudTEAPX);
            this.impactGroupBox6.Controls.Add(this.label6);
            this.impactGroupBox6.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox6.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox6.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox6.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox6.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox6.Image = null;
            this.impactGroupBox6.IsCollapsed = false;
            this.impactGroupBox6.Location = new System.Drawing.Point(149, 229);
            this.impactGroupBox6.Name = "impactGroupBox6";
            this.impactGroupBox6.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox6.Size = new System.Drawing.Size(160, 87);
            this.impactGroupBox6.TabIndex = 40;
            this.impactGroupBox6.TabStop = false;
            this.impactGroupBox6.Text = "Template Event Anchor Point";
            // 
            // btnTEAP
            // 
            this.btnTEAP.Location = new System.Drawing.Point(100, 31);
            this.btnTEAP.Name = "btnTEAP";
            this.btnTEAP.Size = new System.Drawing.Size(53, 41);
            this.btnTEAP.TabIndex = 26;
            this.btnTEAP.Text = "Select";
            this.btnTEAP.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Y";
            // 
            // nudTEAPY
            // 
            this.nudTEAPY.Location = new System.Drawing.Point(27, 55);
            this.nudTEAPY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudTEAPY.Name = "nudTEAPY";
            this.nudTEAPY.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudTEAPY.OnChange = false;
            this.nudTEAPY.Size = new System.Drawing.Size(67, 20);
            this.nudTEAPY.TabIndex = 24;
            // 
            // nudTEAPX
            // 
            this.nudTEAPX.Location = new System.Drawing.Point(27, 29);
            this.nudTEAPX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudTEAPX.Name = "nudTEAPX";
            this.nudTEAPX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudTEAPX.OnChange = false;
            this.nudTEAPX.Size = new System.Drawing.Size(67, 20);
            this.nudTEAPX.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "X";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.listJoints);
            this.impactGroupBox1.Controls.Add(this.toolStrip1);
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
            this.impactGroupBox1.Size = new System.Drawing.Size(131, 304);
            this.impactGroupBox1.TabIndex = 49;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Joints";
            // 
            // listJoints
            // 
            this.listJoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listJoints.FormattingEnabled = true;
            this.listJoints.Location = new System.Drawing.Point(4, 50);
            this.listJoints.Name = "listJoints";
            this.listJoints.Size = new System.Drawing.Size(123, 249);
            this.listJoints.TabIndex = 46;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBtn,
            this.toolStripSeparator1,
            this.removeBtn});
            this.toolStrip1.Location = new System.Drawing.Point(4, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(123, 25);
            this.toolStrip1.TabIndex = 47;
            // 
            // addBtn
            // 
            this.addBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBtn.Image = global::EGMGame.Properties.Resources.add;
            this.addBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(23, 22);
            this.addBtn.Text = "Add";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // removeBtn
            // 
            this.removeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeBtn.Image = global::EGMGame.Properties.Resources.delete;
            this.removeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(23, 22);
            this.removeBtn.Text = "toolStripButton2";
            this.removeBtn.ToolTipText = "Remove";
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.cbJoints);
            this.impactGroupBox2.Controls.Add(this.label7);
            this.impactGroupBox2.Controls.Add(this.cbEvents);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(149, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(322, 70);
            this.impactGroupBox2.TabIndex = 50;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Event To Anchor To Joint";
            // 
            // cbJoints
            // 
            this.cbJoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJoints.FormattingEnabled = true;
            this.cbJoints.Items.AddRange(new object[] {
            "Revolute joint",
            "Angle joint",
            "Angle limit joint",
            "Pin joint",
            "Slider joint"});
            this.cbJoints.Location = new System.Drawing.Point(174, 38);
            this.cbJoints.Name = "cbJoints";
            this.cbJoints.Size = new System.Drawing.Size(134, 21);
            this.cbJoints.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(170, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Joint Type";
            // 
            // cbEvents
            // 
            this.cbEvents.AllowCategories = true;
            this.cbEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(10, 41);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.SelectedNode = null;
            this.cbEvents.Size = new System.Drawing.Size(148, 21);
            this.cbEvents.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Connect Template Event";
            // 
            // EventJointsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(486, 362);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.impactGroupBox8);
            this.Controls.Add(this.impactGroupBox7);
            this.Controls.Add(this.impactGroupBox6);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventJointsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physics";
            this.impactGroupBox8.ResumeLayout(false);
            this.impactGroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudATY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudATX)).EndInit();
            this.impactGroupBox7.ResumeLayout(false);
            this.impactGroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.impactGroupBox6.ResumeLayout(false);
            this.impactGroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTEAPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTEAPX)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private ImpactUI.ImpactGroupBox impactGroupBox8;
        private System.Windows.Forms.Button btnAT;
        private System.Windows.Forms.Label label9;
        private CustomUpDown nudATY;
        private CustomUpDown nudATX;
        private System.Windows.Forms.Label label10;
        private ImpactUI.ImpactGroupBox impactGroupBox7;
        private System.Windows.Forms.Label label5;
        private CustomUpDown nudValue;
        private System.Windows.Forms.ListBox listSettings;
        private ImpactUI.ImpactGroupBox impactGroupBox6;
        private System.Windows.Forms.Button btnTEAP;
        private System.Windows.Forms.Label label8;
        private CustomUpDown nudTEAPY;
        private CustomUpDown nudTEAPX;
        private System.Windows.Forms.Label label6;
        private ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.ListBox listJoints;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton addBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton removeBtn;
        private ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.ComboBox cbJoints;
        private System.Windows.Forms.Label label7;
        private Game.EventComboBox cbEvents;
        private System.Windows.Forms.Label label1;
    }
}