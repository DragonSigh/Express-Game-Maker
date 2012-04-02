namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Program_Movement_Dialogs
{
    partial class ChangeMassDialog
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
            this.nudMass = new EGMGame.CustomUpDown();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelConst = new System.Windows.Forms.Panel();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkMass = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).BeginInit();
            this.panelConst.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(92, 93);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 37;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(11, 93);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 36;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // nudMass
            // 
            this.nudMass.DecimalPlaces = 3;
            this.nudMass.Location = new System.Drawing.Point(6, 5);
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
            this.nudMass.Size = new System.Drawing.Size(74, 20);
            this.nudMass.TabIndex = 38;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Local Variable"});
            this.cbType.Location = new System.Drawing.Point(12, 35);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 50;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.nudMass);
            this.panelConst.Enabled = false;
            this.panelConst.Location = new System.Drawing.Point(6, 59);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(160, 28);
            this.panelConst.TabIndex = 48;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Enabled = false;
            this.panelVariable.Location = new System.Drawing.Point(6, 59);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(160, 28);
            this.panelVariable.TabIndex = 49;
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
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.cbLocalVariable);
            this.panelLocalVariable.Enabled = false;
            this.panelLocalVariable.Location = new System.Drawing.Point(6, 59);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(160, 28);
            this.panelLocalVariable.TabIndex = 51;
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
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.ReshowDelay = 100;
            // 
            // chkMass
            // 
            this.chkMass.AutoSize = true;
            this.chkMass.BackColor = System.Drawing.Color.Transparent;
            this.chkMass.Checked = true;
            this.chkMass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMass.Location = new System.Drawing.Point(12, 12);
            this.chkMass.Name = "chkMass";
            this.chkMass.Size = new System.Drawing.Size(51, 17);
            this.chkMass.TabIndex = 39;
            this.chkMass.Text = "Mass";
            this.toolTip.SetToolTip(this.chkMass, "If checked, the custom Mass will be used.\r\nIf unchecked, the default project Mass" +
                    " will be used.");
            this.chkMass.UseVisualStyleBackColor = false;
            this.chkMass.CheckedChanged += new System.EventHandler(this.chkMass_CheckedChanged);
            // 
            // ChangeMassDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(179, 121);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.Controls.Add(this.panelLocalVariable);
            this.Controls.Add(this.chkMass);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeMassDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Mass";
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).EndInit();
            this.panelConst.ResumeLayout(false);
            this.panelVariable.ResumeLayout(false);
            this.panelLocalVariable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private CustomUpDown nudMass;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.Panel panelVariable;
        private Game.VariableComboBox cbVariable;
        private System.Windows.Forms.Panel panelLocalVariable;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkMass;
    }
}