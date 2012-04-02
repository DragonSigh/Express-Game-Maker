namespace EGMGame
{
    partial class BattleCondtionsDialog
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
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.panelBattlerProp = new System.Windows.Forms.Panel();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangeBattlerProp = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBattlerOp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBattlerProp = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.panelProperty = new System.Windows.Forms.Panel();
            this.cbValueProp = new EGMGame.Controls.Game.DataPropertyComboBox(this.components);
            this.panelConstant = new System.Windows.Forms.Panel();
            this.cbBattlerNud = new EGMGame.CustomUpDown();
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConditions = new System.Windows.Forms.ComboBox();
            this.panelOther = new System.Windows.Forms.Panel();
            this.cbOther = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1.SuspendLayout();
            this.panelBattlerProp.SuspendLayout();
            this.panelProperty.SuspendLayout();
            this.panelConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBattlerNud)).BeginInit();
            this.panelOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(159, 283);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(78, 283);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(12, 260);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 75;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.panelBattlerProp);
            this.impactGroupBox1.Controls.Add(this.cbOperator);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbConditions);
            this.impactGroupBox1.Controls.Add(this.panelOther);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(222, 242);
            this.impactGroupBox1.TabIndex = 22;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Condition";
            // 
            // panelBattlerProp
            // 
            this.panelBattlerProp.BackColor = System.Drawing.Color.Transparent;
            this.panelBattlerProp.Controls.Add(this.cbValue);
            this.panelBattlerProp.Controls.Add(this.label3);
            this.panelBattlerProp.Controls.Add(this.btnChangeBattlerProp);
            this.panelBattlerProp.Controls.Add(this.label10);
            this.panelBattlerProp.Controls.Add(this.cbBattlerOp);
            this.panelBattlerProp.Controls.Add(this.label2);
            this.panelBattlerProp.Controls.Add(this.cbBattlerProp);
            this.panelBattlerProp.Controls.Add(this.panelProperty);
            this.panelBattlerProp.Controls.Add(this.panelConstant);
            this.panelBattlerProp.Location = new System.Drawing.Point(0, 68);
            this.panelBattlerProp.Name = "panelBattlerProp";
            this.panelBattlerProp.Size = new System.Drawing.Size(219, 166);
            this.panelBattlerProp.TabIndex = 23;
            // 
            // cbValue
            // 
            this.cbValue.DisplayMember = "Add";
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Items.AddRange(new object[] {
            "Constant",
            "Property"});
            this.cbValue.Location = new System.Drawing.Point(7, 104);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(121, 21);
            this.cbValue.TabIndex = 78;
            this.cbValue.ValueMember = "Add";
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Choose the value to compare to.";
            // 
            // btnChangeBattlerProp
            // 
            this.btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
            this.btnChangeBattlerProp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeBattlerProp.Location = new System.Drawing.Point(141, 20);
            this.btnChangeBattlerProp.Name = "btnChangeBattlerProp";
            this.btnChangeBattlerProp.Size = new System.Drawing.Size(24, 24);
            this.btnChangeBattlerProp.TabIndex = 75;
            this.btnChangeBattlerProp.UseVisualStyleBackColor = true;
            this.btnChangeBattlerProp.Click += new System.EventHandler(this.btnChangeBattlerProp_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(7, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Choose the compare type for the condition.";
            // 
            // cbBattlerOp
            // 
            this.cbBattlerOp.DisplayMember = "Add";
            this.cbBattlerOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBattlerOp.FormattingEnabled = true;
            this.cbBattlerOp.Items.AddRange(new object[] {
            "(=) Equals",
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals",
            "(!=) Does Not Equal"});
            this.cbBattlerOp.Location = new System.Drawing.Point(7, 64);
            this.cbBattlerOp.Name = "cbBattlerOp";
            this.cbBattlerOp.Size = new System.Drawing.Size(121, 21);
            this.cbBattlerOp.TabIndex = 72;
            this.cbBattlerOp.ValueMember = "Add";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Select the property.";
            // 
            // cbBattlerProp
            // 
            this.cbBattlerProp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBattlerProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBattlerProp.FormattingEnabled = true;
            this.cbBattlerProp.Location = new System.Drawing.Point(7, 22);
            this.cbBattlerProp.Name = "cbBattlerProp";
            this.cbBattlerProp.Size = new System.Drawing.Size(128, 21);
            this.cbBattlerProp.TabIndex = 0;
            // 
            // panelProperty
            // 
            this.panelProperty.Controls.Add(this.cbValueProp);
            this.panelProperty.Location = new System.Drawing.Point(7, 131);
            this.panelProperty.Name = "panelProperty";
            this.panelProperty.Size = new System.Drawing.Size(177, 32);
            this.panelProperty.TabIndex = 78;
            // 
            // cbValueProp
            // 
            this.cbValueProp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbValueProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValueProp.FormattingEnabled = true;
            this.cbValueProp.Location = new System.Drawing.Point(3, 3);
            this.cbValueProp.Name = "cbValueProp";
            this.cbValueProp.Size = new System.Drawing.Size(141, 21);
            this.cbValueProp.TabIndex = 1;
            // 
            // panelConstant
            // 
            this.panelConstant.Controls.Add(this.cbBattlerNud);
            this.panelConstant.Location = new System.Drawing.Point(7, 131);
            this.panelConstant.Name = "panelConstant";
            this.panelConstant.Size = new System.Drawing.Size(177, 32);
            this.panelConstant.TabIndex = 77;
            // 
            // cbBattlerNud
            // 
            this.cbBattlerNud.Location = new System.Drawing.Point(3, 3);
            this.cbBattlerNud.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.cbBattlerNud.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.cbBattlerNud.Name = "cbBattlerNud";
            this.cbBattlerNud.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.cbBattlerNud.OnChange = false;
            this.cbBattlerNud.Size = new System.Drawing.Size(115, 20);
            this.cbBattlerNud.TabIndex = 74;
            // 
            // cbOperator
            // 
            this.cbOperator.DisplayMember = "Add";
            this.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Not Equals"});
            this.cbOperator.Location = new System.Drawing.Point(147, 41);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(68, 21);
            this.cbOperator.TabIndex = 73;
            this.cbOperator.ValueMember = "Add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the condition.";
            // 
            // cbConditions
            // 
            this.cbConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditions.FormattingEnabled = true;
            this.cbConditions.Items.AddRange(new object[] {
            "Battler Property",
            "Target Property",
            "Other"});
            this.cbConditions.Location = new System.Drawing.Point(7, 41);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(134, 21);
            this.cbConditions.TabIndex = 0;
            this.cbConditions.SelectedIndexChanged += new System.EventHandler(this.cbConditions_SelectedIndexChanged);
            // 
            // panelOther
            // 
            this.panelOther.BackColor = System.Drawing.Color.Transparent;
            this.panelOther.Controls.Add(this.cbOther);
            this.panelOther.Location = new System.Drawing.Point(0, 68);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(219, 97);
            this.panelOther.TabIndex = 75;
            // 
            // cbOther
            // 
            this.cbOther.DisplayMember = "Add";
            this.cbOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOther.FormattingEnabled = true;
            this.cbOther.Items.AddRange(new object[] {
            "Has Target",
            "Target In Range",
            "Target In Sight",
            "Battler is dead?",
            "Target is dead?"});
            this.cbOther.Location = new System.Drawing.Point(7, 3);
            this.cbOther.Name = "cbOther";
            this.cbOther.Size = new System.Drawing.Size(134, 21);
            this.cbOther.TabIndex = 72;
            this.cbOther.ValueMember = "Add";
            this.cbOther.SelectedIndexChanged += new System.EventHandler(this.cbOther_SelectedIndexChanged);
            // 
            // BattleCondtionsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(246, 318);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BattleCondtionsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Battle Conditions";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelBattlerProp.ResumeLayout(false);
            this.panelBattlerProp.PerformLayout();
            this.panelProperty.ResumeLayout(false);
            this.panelConstant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbBattlerNud)).EndInit();
            this.panelOther.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.ComboBox cbConditions;
        private System.Windows.Forms.Panel panelBattlerProp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.Game.DataPropertyComboBox cbBattlerProp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBattlerOp;
        private CustomUpDown cbBattlerNud;
        private System.Windows.Forms.ComboBox cbOperator;
        private System.Windows.Forms.Panel panelOther;
        private System.Windows.Forms.ComboBox cbOther;
        private System.Windows.Forms.CheckBox elseBranc;
        private System.Windows.Forms.Button btnChangeBattlerProp;
        private System.Windows.Forms.Panel panelProperty;
        private Controls.Game.DataPropertyComboBox cbValueProp;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Panel panelConstant;
        private System.Windows.Forms.Label label3;
    }
}