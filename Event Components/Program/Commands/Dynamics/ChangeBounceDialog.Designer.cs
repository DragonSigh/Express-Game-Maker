namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Program_Movement_Dialogs
{
    partial class ChangeBounceDialog
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
            this.chkBounce = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelConst = new System.Windows.Forms.Panel();
            this.nudBounce = new EGMGame.CustomUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).BeginInit();
            this.SuspendLayout();
            // 
            // chkBounce
            // 
            this.chkBounce.AutoSize = true;
            this.chkBounce.BackColor = System.Drawing.Color.Transparent;
            this.chkBounce.Checked = true;
            this.chkBounce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBounce.Location = new System.Drawing.Point(12, 12);
            this.chkBounce.Name = "chkBounce";
            this.chkBounce.Size = new System.Drawing.Size(63, 17);
            this.chkBounce.TabIndex = 43;
            this.chkBounce.Text = "Bounce";
            this.toolTip.SetToolTip(this.chkBounce, "If checked, the custom Bounce will be used.\r\nIf unchecked, the default project Bo" +
                    "unce will be used.");
            this.chkBounce.UseVisualStyleBackColor = false;
            this.chkBounce.CheckedChanged += new System.EventHandler(this.chkBounce_CheckedChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(92, 93);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 41;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(11, 93);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 40;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Enabled = false;
            this.panelVariable.Location = new System.Drawing.Point(5, 59);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(160, 28);
            this.panelVariable.TabIndex = 45;
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(6, 2);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(142, 21);
            this.cbVariable.TabIndex = 28;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Local Variable"});
            this.cbType.Location = new System.Drawing.Point(11, 35);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 46;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.cbLocalVariable);
            this.panelLocalVariable.Enabled = false;
            this.panelLocalVariable.Location = new System.Drawing.Point(5, 59);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(160, 28);
            this.panelLocalVariable.TabIndex = 47;
            // 
            // cbLocalVariable
            // 
            this.cbLocalVariable.AllowCategories = true;
            this.cbLocalVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariable.FormattingEnabled = true;
            this.cbLocalVariable.Location = new System.Drawing.Point(6, 2);
            this.cbLocalVariable.Name = "cbLocalVariable";
            this.cbLocalVariable.SelectedNode = null;
            this.cbLocalVariable.Size = new System.Drawing.Size(142, 21);
            this.cbLocalVariable.TabIndex = 29;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.nudBounce);
            this.panelConst.Enabled = false;
            this.panelConst.Location = new System.Drawing.Point(5, 59);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(160, 28);
            this.panelConst.TabIndex = 44;
            // 
            // nudBounce
            // 
            this.nudBounce.DecimalPlaces = 3;
            this.nudBounce.Location = new System.Drawing.Point(6, 3);
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
            this.nudBounce.TabIndex = 42;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.ReshowDelay = 100;
            // 
            // ChangeBounceDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(177, 124);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.chkBounce);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.Controls.Add(this.panelLocalVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeBounceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Bounce";
            this.panelVariable.ResumeLayout(false);
            this.panelLocalVariable.ResumeLayout(false);
            this.panelConst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBounce;
        private CustomUpDown nudBounce;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel panelVariable;
        private Game.VariableComboBox cbVariable;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelLocalVariable;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.ToolTip toolTip;
    }
}