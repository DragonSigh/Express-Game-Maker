namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.ConditionDialogs
{
    partial class TimerConditionDialog
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
            this.operationsList = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.variableList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.settingsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.secondsBox = new CustomUpDown();
            this.minutesBox = new CustomUpDown();
            this.hoursBox = new CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1.SuspendLayout();
            this.settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(147, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(66, 259);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 39;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // operationsList
            // 
            this.operationsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationsList.FormattingEnabled = true;
            this.operationsList.Items.AddRange(new object[] {
            "(=) Equals",
            "(>) Greater Than",
            "(<) Less Than",
            "(>=) Greater Than Or Equals",
            "(<=) Less Than Or Equals",
            "(!=) Does Not Equal"});
            this.operationsList.Location = new System.Drawing.Point(9, 45);
            this.operationsList.Name = "operationsList";
            this.operationsList.Size = new System.Drawing.Size(120, 21);
            this.operationsList.TabIndex = 49;
            this.operationsList.SelectedIndexChanged += new System.EventHandler(this.controlBox_SelectedIndexChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.variableList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(210, 72);
            this.impactGroupBox1.TabIndex = 52;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Variable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose the variable the timer is stored in.";
            // 
            // variableList
            // 
            this.variableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableList.FormattingEnabled = true;
            this.variableList.Location = new System.Drawing.Point(10, 41);
            this.variableList.Name = "variableList";
            this.variableList.Size = new System.Drawing.Size(121, 21);
            this.variableList.TabIndex = 3;
            // 
            // settingsBox
            // 
            this.settingsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.settingsBox.Controls.Add(this.label6);
            this.settingsBox.Controls.Add(this.label5);
            this.settingsBox.Controls.Add(this.label4);
            this.settingsBox.Controls.Add(this.label3);
            this.settingsBox.Controls.Add(this.secondsBox);
            this.settingsBox.Controls.Add(this.minutesBox);
            this.settingsBox.Controls.Add(this.hoursBox);
            this.settingsBox.Controls.Add(this.label2);
            this.settingsBox.Controls.Add(this.operationsList);
            this.settingsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.settingsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.settingsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.settingsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.settingsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.settingsBox.Location = new System.Drawing.Point(12, 90);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.settingsBox.Size = new System.Drawing.Size(210, 141);
            this.settingsBox.TabIndex = 53;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Condition";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Choose the comparer to compare time.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(92, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(48, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Hours";
            // 
            // secondsBox
            // 
            this.secondsBox.Location = new System.Drawing.Point(95, 110);
            this.secondsBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.Size = new System.Drawing.Size(35, 20);
            this.secondsBox.TabIndex = 53;
            // 
            // minutesBox
            // 
            this.minutesBox.Location = new System.Drawing.Point(51, 110);
            this.minutesBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutesBox.Name = "minutesBox";
            this.minutesBox.Size = new System.Drawing.Size(35, 20);
            this.minutesBox.TabIndex = 52;
            // 
            // hoursBox
            // 
            this.hoursBox.Location = new System.Drawing.Point(10, 110);
            this.hoursBox.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.hoursBox.Name = "hoursBox";
            this.hoursBox.Size = new System.Drawing.Size(35, 20);
            this.hoursBox.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Choose time to compare to.";
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(12, 236);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 62;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // TimerConditionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(232, 294);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimerConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Timer Condition";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox operationsList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox settingsBox;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.Game.VariableComboBox variableList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private CustomUpDown secondsBox;
        private CustomUpDown minutesBox;
        private CustomUpDown hoursBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox elseBranc;
    }
}