namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class TimerDialog
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
            this.settingsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.decreaseBtn = new System.Windows.Forms.RadioButton();
            this.increaseBtn = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.secondsBox = new EGMGame.CustomUpDown();
            this.minutesBox = new EGMGame.CustomUpDown();
            this.hoursBox = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.variableList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.controlBox = new System.Windows.Forms.ComboBox();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursBox)).BeginInit();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsBox
            // 
            this.settingsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.settingsBox.Controls.Add(this.decreaseBtn);
            this.settingsBox.Controls.Add(this.increaseBtn);
            this.settingsBox.Controls.Add(this.label5);
            this.settingsBox.Controls.Add(this.label4);
            this.settingsBox.Controls.Add(this.label3);
            this.settingsBox.Controls.Add(this.secondsBox);
            this.settingsBox.Controls.Add(this.minutesBox);
            this.settingsBox.Controls.Add(this.hoursBox);
            this.settingsBox.Controls.Add(this.label2);
            this.settingsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.settingsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.settingsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.settingsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.settingsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.settingsBox.Location = new System.Drawing.Point(12, 162);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.settingsBox.Size = new System.Drawing.Size(200, 148);
            this.settingsBox.TabIndex = 0;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // decreaseBtn
            // 
            this.decreaseBtn.AutoSize = true;
            this.decreaseBtn.BackColor = System.Drawing.Color.Transparent;
            this.decreaseBtn.Location = new System.Drawing.Point(9, 124);
            this.decreaseBtn.Name = "decreaseBtn";
            this.decreaseBtn.Size = new System.Drawing.Size(97, 17);
            this.decreaseBtn.TabIndex = 11;
            this.decreaseBtn.Text = "Decrease Time";
            this.decreaseBtn.UseVisualStyleBackColor = false;
            // 
            // increaseBtn
            // 
            this.increaseBtn.AutoSize = true;
            this.increaseBtn.BackColor = System.Drawing.Color.Transparent;
            this.increaseBtn.Checked = true;
            this.increaseBtn.Location = new System.Drawing.Point(9, 101);
            this.increaseBtn.Name = "increaseBtn";
            this.increaseBtn.Size = new System.Drawing.Size(92, 17);
            this.increaseBtn.TabIndex = 10;
            this.increaseBtn.TabStop = true;
            this.increaseBtn.Text = "Increase Time";
            this.increaseBtn.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(92, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(48, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hours";
            // 
            // secondsBox
            // 
            this.secondsBox.Location = new System.Drawing.Point(95, 66);
            this.secondsBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.secondsBox.OnChange = false;
            this.secondsBox.Size = new System.Drawing.Size(35, 20);
            this.secondsBox.TabIndex = 6;
            // 
            // minutesBox
            // 
            this.minutesBox.Location = new System.Drawing.Point(51, 66);
            this.minutesBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutesBox.Name = "minutesBox";
            this.minutesBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.minutesBox.OnChange = false;
            this.minutesBox.Size = new System.Drawing.Size(35, 20);
            this.minutesBox.TabIndex = 5;
            // 
            // hoursBox
            // 
            this.hoursBox.Location = new System.Drawing.Point(10, 66);
            this.hoursBox.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.hoursBox.Name = "hoursBox";
            this.hoursBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.hoursBox.OnChange = false;
            this.hoursBox.Size = new System.Drawing.Size(35, 20);
            this.hoursBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose start time.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose a varaible to store the time in.";
            // 
            // variableList
            // 
            this.variableList.AllowCategories = true;
            this.variableList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.variableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableList.FormattingEnabled = true;
            this.variableList.Location = new System.Drawing.Point(12, 46);
            this.variableList.Name = "variableList";
            this.variableList.SelectedNode = null;
            this.variableList.Size = new System.Drawing.Size(121, 21);
            this.variableList.TabIndex = 1;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(137, 315);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(56, 315);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 14;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.controlBox);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(200, 60);
            this.impactGroupBox2.TabIndex = 16;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Control";
            // 
            // controlBox
            // 
            this.controlBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.controlBox.FormattingEnabled = true;
            this.controlBox.Items.AddRange(new object[] {
            "Create / Start",
            "Create / Stop",
            "Start",
            "Stop",
            "Reset"});
            this.controlBox.Location = new System.Drawing.Point(12, 28);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(121, 21);
            this.controlBox.TabIndex = 0;
            this.controlBox.SelectedIndexChanged += new System.EventHandler(this.controlBox_SelectedIndexChanged);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.label1);
            this.impactGroupBox3.Controls.Add(this.variableList);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(12, 78);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(200, 78);
            this.impactGroupBox3.TabIndex = 17;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Variable";
            // 
            // TimerDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(222, 350);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.settingsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimerDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Timer";
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursBox)).EndInit();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox settingsBox;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.Game.VariableComboBox variableList;
        private System.Windows.Forms.Label label2;
        private CustomUpDown hoursBox;
        private CustomUpDown minutesBox;
        private CustomUpDown secondsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton decreaseBtn;
        private System.Windows.Forms.RadioButton increaseBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.ComboBox controlBox;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;

    }
}