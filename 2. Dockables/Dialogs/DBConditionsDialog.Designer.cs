namespace EGMGame
{
    partial class DBConditionsDialog
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
            this.panelProperty.SuspendLayout();
            this.panelConstant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBattlerNud)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(146, 172);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(65, 172);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cbValue
            // 
            this.cbValue.DisplayMember = "Add";
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Items.AddRange(new object[] {
            "Constant",
            "Property"});
            this.cbValue.Location = new System.Drawing.Point(12, 107);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(121, 21);
            this.cbValue.TabIndex = 86;
            this.cbValue.ValueMember = "Add";
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Choose the value to compare to.";
            // 
            // btnChangeBattlerProp
            // 
            this.btnChangeBattlerProp.BackgroundImage = global::EGMGame.Properties.Resources.hero24;
            this.btnChangeBattlerProp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeBattlerProp.Location = new System.Drawing.Point(146, 23);
            this.btnChangeBattlerProp.Name = "btnChangeBattlerProp";
            this.btnChangeBattlerProp.Size = new System.Drawing.Size(24, 24);
            this.btnChangeBattlerProp.TabIndex = 83;
            this.btnChangeBattlerProp.UseVisualStyleBackColor = true;
            this.btnChangeBattlerProp.Click += new System.EventHandler(this.btnChangeBattlerProp_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(12, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 13);
            this.label10.TabIndex = 82;
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
            this.cbBattlerOp.Location = new System.Drawing.Point(12, 67);
            this.cbBattlerOp.Name = "cbBattlerOp";
            this.cbBattlerOp.Size = new System.Drawing.Size(121, 21);
            this.cbBattlerOp.TabIndex = 81;
            this.cbBattlerOp.ValueMember = "Add";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Select the target\'s property.";
            // 
            // cbBattlerProp
            // 
            this.cbBattlerProp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBattlerProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBattlerProp.FormattingEnabled = true;
            this.cbBattlerProp.Location = new System.Drawing.Point(12, 25);
            this.cbBattlerProp.Name = "cbBattlerProp";
            this.cbBattlerProp.Size = new System.Drawing.Size(128, 21);
            this.cbBattlerProp.TabIndex = 79;
            // 
            // panelProperty
            // 
            this.panelProperty.Controls.Add(this.cbValueProp);
            this.panelProperty.Location = new System.Drawing.Point(12, 134);
            this.panelProperty.Name = "panelProperty";
            this.panelProperty.Size = new System.Drawing.Size(177, 32);
            this.panelProperty.TabIndex = 87;
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
            this.panelConstant.Location = new System.Drawing.Point(12, 134);
            this.panelConstant.Name = "panelConstant";
            this.panelConstant.Size = new System.Drawing.Size(177, 32);
            this.panelConstant.TabIndex = 85;
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
            // DBConditionsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(231, 208);
            this.Controls.Add(this.cbValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChangeBattlerProp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbBattlerOp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBattlerProp);
            this.Controls.Add(this.panelProperty);
            this.Controls.Add(this.panelConstant);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBConditionsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conditions";
            this.panelProperty.ResumeLayout(false);
            this.panelConstant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbBattlerNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangeBattlerProp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBattlerOp;
        private System.Windows.Forms.Label label2;
        private Controls.Game.DataPropertyComboBox cbBattlerProp;
        private System.Windows.Forms.Panel panelProperty;
        private Controls.Game.DataPropertyComboBox cbValueProp;
        private System.Windows.Forms.Panel panelConstant;
        private CustomUpDown cbBattlerNud;
    }
}