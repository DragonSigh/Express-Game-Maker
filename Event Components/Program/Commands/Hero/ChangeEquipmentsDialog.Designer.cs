namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.PartyDialogs
{
    partial class ChangeEquipmentsDialog
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
            this.numericOperationsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chkEquipped = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.variablesList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelConst = new System.Windows.Forms.Panel();
            this.constantBox = new EGMGame.CustomUpDown();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbOpType = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbList = new EGMGame.Controls.Game.ListComboBox(this.components);
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbEquipment = new EGMGame.Controls.Game.ItemsComboBox(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericOperationsBox.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericOperationsBox
            // 
            this.numericOperationsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.numericOperationsBox.Controls.Add(this.chkEquipped);
            this.numericOperationsBox.Controls.Add(this.label1);
            this.numericOperationsBox.Controls.Add(this.label17);
            this.numericOperationsBox.Controls.Add(this.panelVariable);
            this.numericOperationsBox.Controls.Add(this.panelConst);
            this.numericOperationsBox.Controls.Add(this.cbValue);
            this.numericOperationsBox.Controls.Add(this.label16);
            this.numericOperationsBox.Controls.Add(this.cbOpType);
            this.numericOperationsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.numericOperationsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.numericOperationsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.numericOperationsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.numericOperationsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.numericOperationsBox.Location = new System.Drawing.Point(12, 144);
            this.numericOperationsBox.Name = "numericOperationsBox";
            this.numericOperationsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.numericOperationsBox.Size = new System.Drawing.Size(236, 169);
            this.numericOperationsBox.TabIndex = 47;
            this.numericOperationsBox.TabStop = false;
            this.numericOperationsBox.Text = "Operation";
            // 
            // chkEquipped
            // 
            this.chkEquipped.AutoSize = true;
            this.chkEquipped.BackColor = System.Drawing.Color.Transparent;
            this.chkEquipped.Enabled = false;
            this.chkEquipped.Location = new System.Drawing.Point(5, 148);
            this.chkEquipped.Name = "chkEquipped";
            this.chkEquipped.Size = new System.Drawing.Size(103, 17);
            this.chkEquipped.TabIndex = 82;
            this.chkEquipped.Text = "Include Equiped";
            this.toolTip1.SetToolTip(this.chkEquipped, "When decreasing equipment, the party\'s \r\nequipped equipments will also be affecte" +
                    "d.");
            this.chkEquipped.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Value";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(7, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(173, 13);
            this.label17.TabIndex = 80;
            this.label17.Text = "Choose the value for the operation.";
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.variablesList);
            this.panelVariable.Enabled = false;
            this.panelVariable.Location = new System.Drawing.Point(6, 109);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(204, 34);
            this.panelVariable.TabIndex = 78;
            this.panelVariable.Visible = false;
            // 
            // variablesList
            // 
            this.variablesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variablesList.FormattingEnabled = true;
            this.variablesList.Location = new System.Drawing.Point(7, 7);
            this.variablesList.Name = "variablesList";
            this.variablesList.Size = new System.Drawing.Size(113, 21);
            this.variablesList.TabIndex = 33;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.constantBox);
            this.panelConst.Location = new System.Drawing.Point(6, 109);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(201, 37);
            this.panelConst.TabIndex = 77;
            // 
            // constantBox
            // 
            this.constantBox.Location = new System.Drawing.Point(7, 7);
            this.constantBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.constantBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.constantBox.Name = "constantBox";
            this.constantBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.constantBox.OnChange = false;
            this.constantBox.Size = new System.Drawing.Size(95, 20);
            this.constantBox.TabIndex = 8;
            // 
            // cbValue
            // 
            this.cbValue.DisplayMember = "Constant";
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbValue.Location = new System.Drawing.Point(46, 82);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(106, 21);
            this.cbValue.TabIndex = 75;
            this.cbValue.ValueMember = "Constant";
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(4, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(214, 13);
            this.label16.TabIndex = 74;
            this.label16.Text = "Choose the operation type for the operation.";
            // 
            // cbOpType
            // 
            this.cbOpType.DisplayMember = "Add";
            this.cbOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpType.FormattingEnabled = true;
            this.cbOpType.Items.AddRange(new object[] {
            "Increase",
            "Decrease"});
            this.cbOpType.Location = new System.Drawing.Point(7, 42);
            this.cbOpType.Name = "cbOpType";
            this.cbOpType.Size = new System.Drawing.Size(121, 21);
            this.cbOpType.TabIndex = 73;
            this.cbOpType.ValueMember = "Add";
            this.cbOpType.SelectedIndexChanged += new System.EventHandler(this.cbOpType_SelectedIndexChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(174, 319);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 46;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(93, 319);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 45;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 60);
            this.impactGroupBox1.TabIndex = 44;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "List";
            // 
            // cbList
            // 
            this.cbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(7, 28);
            this.cbList.Name = "cbList";
            this.cbList.Noneable = false;
            this.cbList.Size = new System.Drawing.Size(142, 21);
            this.cbList.TabIndex = 0;
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.cbEquipment);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 78);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(157, 60);
            this.impactGroupBox2.TabIndex = 48;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Equipment";
            // 
            // cbEquipment
            // 
            this.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipment.FormattingEnabled = true;
            this.cbEquipment.Location = new System.Drawing.Point(8, 28);
            this.cbEquipment.Name = "cbEquipment";
            this.cbEquipment.Noneable = true;
            this.cbEquipment.Size = new System.Drawing.Size(142, 21);
            this.cbEquipment.TabIndex = 0;
            // 
            // ChangeEquipmentsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(261, 354);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.numericOperationsBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeEquipmentsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Equipments";
            this.numericOperationsBox.ResumeLayout(false);
            this.numericOperationsBox.PerformLayout();
            this.panelVariable.ResumeLayout(false);
            this.panelConst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constantBox)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox numericOperationsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panelVariable;
        private EGMGame.Controls.Game.VariableComboBox variablesList;
        private System.Windows.Forms.Panel panelConst;
        private CustomUpDown constantBox;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbOpType;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.ListComboBox cbList;
        private System.Windows.Forms.CheckBox chkEquipped;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.Game.ItemsComboBox cbEquipment;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}