namespace EGMGame.Controls.EventControls
{
    partial class ProjectileForceDialog
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
            this.cbMovement = new System.Windows.Forms.ComboBox();
            this.cbUseForce = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pixelBox = new EGMGame.CustomUpDown();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelConst = new System.Windows.Forms.Panel();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.panelConst.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 162);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(12, 162);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 24;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cbMovement
            // 
            this.cbMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovement.FormattingEnabled = true;
            this.cbMovement.Items.AddRange(new object[] {
            "Forward",
            "Backward",
            "Leftward",
            "Rightward",
            "Toward Target",
            "Random"});
            this.cbMovement.Location = new System.Drawing.Point(10, 24);
            this.cbMovement.Name = "cbMovement";
            this.cbMovement.Size = new System.Drawing.Size(124, 21);
            this.cbMovement.TabIndex = 60;
            // 
            // cbUseForce
            // 
            this.cbUseForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUseForce.FormattingEnabled = true;
            this.cbUseForce.Items.AddRange(new object[] {
            "Force",
            "Impulse",
            "Torque",
            "Angular Impulse"});
            this.cbUseForce.Location = new System.Drawing.Point(44, 51);
            this.cbUseForce.Name = "cbUseForce";
            this.cbUseForce.Size = new System.Drawing.Size(114, 21);
            this.cbUseForce.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Use ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Choose movement direction.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Amount";
            // 
            // pixelBox
            // 
            this.pixelBox.DecimalPlaces = 3;
            this.pixelBox.Location = new System.Drawing.Point(52, 7);
            this.pixelBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.pixelBox.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pixelBox.OnChange = true;
            this.pixelBox.Size = new System.Drawing.Size(80, 20);
            this.pixelBox.TabIndex = 57;
            this.pixelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbType.Location = new System.Drawing.Point(10, 78);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 76;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.pixelBox);
            this.panelConst.Controls.Add(this.label3);
            this.panelConst.Location = new System.Drawing.Point(10, 105);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(166, 35);
            this.panelConst.TabIndex = 77;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.label5);
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(10, 105);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(166, 35);
            this.panelVariable.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Amount";
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(43, 7);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.Noneable = false;
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(123, 21);
            this.cbVariable.TabIndex = 28;
            // 
            // ProjectileForceDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(180, 197);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUseForce);
            this.Controls.Add(this.cbMovement);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panelConst);
            this.Controls.Add(this.panelVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProjectileForceDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply Force";
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.panelConst.ResumeLayout(false);
            this.panelConst.PerformLayout();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private CustomUpDown pixelBox;
        private System.Windows.Forms.ComboBox cbMovement;
        private System.Windows.Forms.ComboBox cbUseForce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label label5;
        private Game.VariableComboBox cbVariable;
    }
}