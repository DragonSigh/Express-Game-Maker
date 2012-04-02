namespace EGMGame.Controls
{
    partial class MoveMenuDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.menuPartsComboBox1 = new EGMGame.Controls.Game.MenuPartsComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.operationTypeList = new System.Windows.Forms.ComboBox();
            this.variablesPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.cbYVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbXVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.coordinatePanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.nudScreenY = new EGMGame.CustomUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudScreenX = new EGMGame.CustomUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudFrames = new EGMGame.CustomUpDown();
            this.impactGroupBox1.SuspendLayout();
            this.variablesPanel.SuspendLayout();
            this.coordinatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(145, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 73;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(64, 248);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 71;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.nudFrames);
            this.impactGroupBox1.Controls.Add(this.operationTypeList);
            this.impactGroupBox1.Controls.Add(this.label4);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.menuPartsComboBox1);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.variablesPanel);
            this.impactGroupBox1.Controls.Add(this.coordinatePanel);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(204, 228);
            this.impactGroupBox1.TabIndex = 72;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Move Menu";
            // 
            // menuPartsComboBox1
            // 
            this.menuPartsComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.menuPartsComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuPartsComboBox1.FormattingEnabled = true;
            this.menuPartsComboBox1.Location = new System.Drawing.Point(7, 47);
            this.menuPartsComboBox1.Name = "menuPartsComboBox1";
            this.menuPartsComboBox1.Size = new System.Drawing.Size(180, 21);
            this.menuPartsComboBox1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Choose the menu part.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Move Menu To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "How long should it take?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(81, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "Frames";
            // 
            // operationTypeList
            // 
            this.operationTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationTypeList.FormattingEnabled = true;
            this.operationTypeList.Items.AddRange(new object[] {
            "Coordinates",
            "Variables"});
            this.operationTypeList.Location = new System.Drawing.Point(10, 87);
            this.operationTypeList.Name = "operationTypeList";
            this.operationTypeList.Size = new System.Drawing.Size(124, 21);
            this.operationTypeList.TabIndex = 67;
            this.operationTypeList.SelectedIndexChanged += new System.EventHandler(this.operationTypeList_SelectedIndexChanged);
            // 
            // variablesPanel
            // 
            this.variablesPanel.BackColor = System.Drawing.Color.Transparent;
            this.variablesPanel.Controls.Add(this.cbYVar);
            this.variablesPanel.Controls.Add(this.cbXVar);
            this.variablesPanel.Controls.Add(this.label5);
            this.variablesPanel.Controls.Add(this.label6);
            this.variablesPanel.Location = new System.Drawing.Point(10, 114);
            this.variablesPanel.Name = "variablesPanel";
            this.variablesPanel.Size = new System.Drawing.Size(150, 55);
            this.variablesPanel.TabIndex = 68;
            this.variablesPanel.Visible = false;
            // 
            // cbYVar
            // 
            this.cbYVar.AllowCategories = true;
            this.cbYVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYVar.FormattingEnabled = true;
            this.cbYVar.Location = new System.Drawing.Point(25, 31);
            this.cbYVar.Name = "cbYVar";
            this.cbYVar.Noneable = false;
            this.cbYVar.SelectedNode = null;
            this.cbYVar.Size = new System.Drawing.Size(99, 21);
            this.cbYVar.TabIndex = 8;
            // 
            // cbXVar
            // 
            this.cbXVar.AllowCategories = true;
            this.cbXVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbXVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbXVar.FormattingEnabled = true;
            this.cbXVar.Location = new System.Drawing.Point(25, 5);
            this.cbXVar.Name = "cbXVar";
            this.cbXVar.Noneable = false;
            this.cbXVar.SelectedNode = null;
            this.cbXVar.Size = new System.Drawing.Size(99, 21);
            this.cbXVar.TabIndex = 7;
            this.cbXVar.SelectedIndexChanged += new System.EventHandler(this.cbXVar_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Y:";
            // 
            // coordinatePanel
            // 
            this.coordinatePanel.BackColor = System.Drawing.Color.Transparent;
            this.coordinatePanel.Controls.Add(this.nudScreenY);
            this.coordinatePanel.Controls.Add(this.label7);
            this.coordinatePanel.Controls.Add(this.nudScreenX);
            this.coordinatePanel.Controls.Add(this.label8);
            this.coordinatePanel.Location = new System.Drawing.Point(10, 114);
            this.coordinatePanel.Name = "coordinatePanel";
            this.coordinatePanel.Size = new System.Drawing.Size(150, 55);
            this.coordinatePanel.TabIndex = 66;
            // 
            // nudScreenY
            // 
            this.nudScreenY.Location = new System.Drawing.Point(25, 29);
            this.nudScreenY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudScreenY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudScreenY.Name = "nudScreenY";
            this.nudScreenY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudScreenY.OnChange = false;
            this.nudScreenY.Size = new System.Drawing.Size(61, 20);
            this.nudScreenY.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(2, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "X:";
            // 
            // nudScreenX
            // 
            this.nudScreenX.Location = new System.Drawing.Point(25, 3);
            this.nudScreenX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudScreenX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudScreenX.Name = "nudScreenX";
            this.nudScreenX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudScreenX.OnChange = false;
            this.nudScreenX.Size = new System.Drawing.Size(61, 20);
            this.nudScreenX.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(2, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Y:";
            // 
            // nudFrames
            // 
            this.nudFrames.Location = new System.Drawing.Point(14, 191);
            this.nudFrames.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudFrames.Name = "nudFrames";
            this.nudFrames.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudFrames.OnChange = false;
            this.nudFrames.Size = new System.Drawing.Size(61, 20);
            this.nudFrames.TabIndex = 69;
            // 
            // MoveMenuDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(232, 283);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveMenuDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move Menu";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.variablesPanel.ResumeLayout(false);
            this.variablesPanel.PerformLayout();
            this.coordinatePanel.ResumeLayout(false);
            this.coordinatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.MenuPartsComboBox menuPartsComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox operationTypeList;
        private ImpactUI.ImpactPanel variablesPanel;
        private Game.VariableComboBox cbYVar;
        private Game.VariableComboBox cbXVar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ImpactUI.ImpactPanel coordinatePanel;
        private CustomUpDown nudScreenY;
        private System.Windows.Forms.Label label7;
        private CustomUpDown nudScreenX;
        private System.Windows.Forms.Label label8;
        private CustomUpDown nudFrames;
    }
}