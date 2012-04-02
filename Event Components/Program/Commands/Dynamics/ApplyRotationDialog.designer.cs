namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class ApplyRotationDialog
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
            this.pixelBox = new EGMGame.CustomUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelConst = new System.Windows.Forms.Panel();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.panelLocalVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pixelBox
            // 
            this.pixelBox.Location = new System.Drawing.Point(6, 7);
            this.pixelBox.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pixelBox.OnChange = true;
            this.pixelBox.Size = new System.Drawing.Size(75, 20);
            this.pixelBox.TabIndex = 70;
            this.pixelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(94, 98);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 69;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(9, 98);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 68;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Amount of rotation to apply.";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Local Variable"});
            this.cbType.Location = new System.Drawing.Point(12, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 74;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.cbLocalVariable);
            this.panelLocalVariable.Location = new System.Drawing.Point(6, 52);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(162, 40);
            this.panelLocalVariable.TabIndex = 75;
            // 
            // cbLocalVariable
            // 
            this.cbLocalVariable.AllowCategories = true;
            this.cbLocalVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariable.FormattingEnabled = true;
            this.cbLocalVariable.Location = new System.Drawing.Point(6, 6);
            this.cbLocalVariable.Name = "cbLocalVariable";
            this.cbLocalVariable.Noneable = false;
            this.cbLocalVariable.SelectedNode = null;
            this.cbLocalVariable.Size = new System.Drawing.Size(142, 21);
            this.cbLocalVariable.TabIndex = 29;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.pixelBox);
            this.panelConst.Location = new System.Drawing.Point(6, 52);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(162, 40);
            this.panelConst.TabIndex = 72;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(6, 52);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(162, 40);
            this.panelVariable.TabIndex = 73;
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(6, 6);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.Noneable = false;
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(142, 21);
            this.cbVariable.TabIndex = 28;
            // 
            // ApplyRotationDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(177, 132);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.Controls.Add(this.panelLocalVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ApplyRotationDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply Rotation";
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.panelLocalVariable.ResumeLayout(false);
            this.panelConst.ResumeLayout(false);
            this.panelVariable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUpDown pixelBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelLocalVariable;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.Panel panelVariable;
        private Game.VariableComboBox cbVariable;

    }
}