namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class FrequencyDialog
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
            this.speedBox = new EGMGame.CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelConst = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.speedBox)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(153, 81);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 33;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(72, 81);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 32;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // speedBox
            // 
            this.speedBox.Location = new System.Drawing.Point(66, 8);
            this.speedBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.speedBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speedBox.Name = "speedBox";
            this.speedBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speedBox.OnChange = true;
            this.speedBox.Size = new System.Drawing.Size(83, 20);
            this.speedBox.TabIndex = 31;
            this.speedBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Frequency";
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.label2);
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(6, 36);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(221, 35);
            this.panelVariable.TabIndex = 35;
            // 
            // cbVariable
            // 
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(66, 7);
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
            this.cbType.Location = new System.Drawing.Point(12, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 36;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.label5);
            this.panelLocalVariable.Controls.Add(this.cbLocalVariable);
            this.panelLocalVariable.Location = new System.Drawing.Point(6, 36);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(221, 35);
            this.panelLocalVariable.TabIndex = 37;
            // 
            // cbLocalVariable
            // 
            this.cbLocalVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariable.FormattingEnabled = true;
            this.cbLocalVariable.Location = new System.Drawing.Point(66, 7);
            this.cbLocalVariable.Name = "cbLocalVariable";
            this.cbLocalVariable.SelectedNode = null;
            this.cbLocalVariable.Size = new System.Drawing.Size(142, 21);
            this.cbLocalVariable.TabIndex = 29;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.speedBox);
            this.panelConst.Controls.Add(this.label1);
            this.panelConst.Location = new System.Drawing.Point(6, 36);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(221, 35);
            this.panelConst.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Frequency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Frequency";
            // 
            // FrequencyDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(239, 116);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.Controls.Add(this.panelLocalVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrequencyDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Frequency";
            ((System.ComponentModel.ISupportInitialize)(this.speedBox)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.panelLocalVariable.ResumeLayout(false);
            this.panelLocalVariable.PerformLayout();
            this.panelConst.ResumeLayout(false);
            this.panelConst.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private CustomUpDown speedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label label2;
        private Game.VariableComboBox cbVariable;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelLocalVariable;
        private System.Windows.Forms.Label label5;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.Panel panelConst;
    }
}