namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class MoveSpeedDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.speedBox = new EGMGame.CustomUpDown();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelLocalVariable = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLocalVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelConst = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.speedBox)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.panelLocalVariable.SuspendLayout();
            this.panelConst.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speed";
            // 
            // speedBox
            // 
            this.speedBox.Location = new System.Drawing.Point(47, 5);
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
            this.speedBox.Size = new System.Drawing.Size(64, 20);
            this.speedBox.TabIndex = 1;
            this.speedBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(123, 74);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 29;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(42, 74);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 28;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.label2);
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(4, 30);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(188, 40);
            this.panelVariable.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Speed";
            // 
            // cbVariable
            // 
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(43, 5);
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
            this.cbType.Location = new System.Drawing.Point(10, 3);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 32;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelLocalVariable
            // 
            this.panelLocalVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelLocalVariable.Controls.Add(this.label3);
            this.panelLocalVariable.Controls.Add(this.cbLocalVariable);
            this.panelLocalVariable.Location = new System.Drawing.Point(4, 30);
            this.panelLocalVariable.Name = "panelLocalVariable";
            this.panelLocalVariable.Size = new System.Drawing.Size(188, 40);
            this.panelLocalVariable.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Speed";
            // 
            // cbLocalVariable
            // 
            this.cbLocalVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLocalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalVariable.FormattingEnabled = true;
            this.cbLocalVariable.Location = new System.Drawing.Point(43, 5);
            this.cbLocalVariable.Name = "cbLocalVariable";
            this.cbLocalVariable.SelectedNode = null;
            this.cbLocalVariable.Size = new System.Drawing.Size(142, 21);
            this.cbLocalVariable.TabIndex = 29;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.label1);
            this.panelConst.Controls.Add(this.speedBox);
            this.panelConst.Location = new System.Drawing.Point(4, 30);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(188, 40);
            this.panelConst.TabIndex = 30;
            // 
            // MoveSpeedDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(204, 110);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelLocalVariable);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveSpeedDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move Speed";
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

        private System.Windows.Forms.Label label1;
        private CustomUpDown speedBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label label2;
        private Game.VariableComboBox cbVariable;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelLocalVariable;
        private System.Windows.Forms.Label label3;
        private Game.VariableComboBox cbLocalVariable;
        private System.Windows.Forms.Panel panelConst;
    }
}