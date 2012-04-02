﻿namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Program_Movement_Dialogs
{
    partial class ChangeForceDialog
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
            this.chkForce = new System.Windows.Forms.CheckBox();
            this.nudForce = new EGMGame.CustomUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelConst = new System.Windows.Forms.Panel();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            this.panelConst.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkForce
            // 
            this.chkForce.AutoSize = true;
            this.chkForce.BackColor = System.Drawing.Color.Transparent;
            this.chkForce.Checked = true;
            this.chkForce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForce.Location = new System.Drawing.Point(12, 12);
            this.chkForce.Name = "chkForce";
            this.chkForce.Size = new System.Drawing.Size(53, 17);
            this.chkForce.TabIndex = 43;
            this.chkForce.Text = "Force";
            this.toolTip.SetToolTip(this.chkForce, "If checked, the custom Force will be used.\r\nIf unchecked, the default project For" +
                    "ce will be used.");
            this.chkForce.UseVisualStyleBackColor = false;
            this.chkForce.CheckedChanged += new System.EventHandler(this.chkForce_CheckedChanged);
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 3;
            this.nudForce.Location = new System.Drawing.Point(6, 3);
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
            this.nudForce.Size = new System.Drawing.Size(75, 20);
            this.nudForce.TabIndex = 42;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(91, 92);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 41;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 92);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 40;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
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
            this.panelConst.Controls.Add(this.nudForce);
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
            // ChangeForceDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(176, 127);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.Controls.Add(this.panelLocalVariable);
            this.Controls.Add(this.chkForce);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeForceDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Force";
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            this.panelConst.ResumeLayout(false);
            this.panelVariable.ResumeLayout(false);
            this.panelLocalVariable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkForce;
        private CustomUpDown nudForce;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.Panel panelVariable;
        private Game.VariableComboBox cbVariable;
        private System.Windows.Forms.Panel panelLocalVariable;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.ToolTip toolTip;
    }
}