namespace EGMGame.Controls.EventControls.EventDialogs
{
    partial class EventSwitchesDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.conditionBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.offBtn = new System.Windows.Forms.RadioButton();
            this.onBtn = new System.Windows.Forms.RadioButton();
            this.switchesBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.localList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.conditionBox.SuspendLayout();
            this.switchesBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(121, 226);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // conditionBox
            // 
            this.conditionBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.conditionBox.CanCollapse = false;
            this.conditionBox.Controls.Add(this.offBtn);
            this.conditionBox.Controls.Add(this.onBtn);
            this.conditionBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.conditionBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.conditionBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.conditionBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.conditionBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.conditionBox.Image = null;
            this.conditionBox.IsCollapsed = false;
            this.conditionBox.Location = new System.Drawing.Point(10, 121);
            this.conditionBox.Name = "conditionBox";
            this.conditionBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.conditionBox.Size = new System.Drawing.Size(186, 53);
            this.conditionBox.TabIndex = 12;
            this.conditionBox.TabStop = false;
            this.conditionBox.Text = "Condition";
            // 
            // offBtn
            // 
            this.offBtn.AutoSize = true;
            this.offBtn.BackColor = System.Drawing.Color.Transparent;
            this.offBtn.Location = new System.Drawing.Point(67, 27);
            this.offBtn.Name = "offBtn";
            this.offBtn.Size = new System.Drawing.Size(39, 17);
            this.offBtn.TabIndex = 1;
            this.offBtn.TabStop = true;
            this.offBtn.Text = "Off";
            this.offBtn.UseVisualStyleBackColor = false;
            // 
            // onBtn
            // 
            this.onBtn.AutoSize = true;
            this.onBtn.BackColor = System.Drawing.Color.Transparent;
            this.onBtn.Checked = true;
            this.onBtn.Location = new System.Drawing.Point(7, 28);
            this.onBtn.Name = "onBtn";
            this.onBtn.Size = new System.Drawing.Size(39, 17);
            this.onBtn.TabIndex = 0;
            this.onBtn.TabStop = true;
            this.onBtn.Text = "On";
            this.onBtn.UseVisualStyleBackColor = false;
            this.onBtn.CheckedChanged += new System.EventHandler(this.onBtn_CheckedChanged);
            // 
            // switchesBox
            // 
            this.switchesBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.switchesBox.CanCollapse = false;
            this.switchesBox.Controls.Add(this.localList);
            this.switchesBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.switchesBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.switchesBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.switchesBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.switchesBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.switchesBox.Image = null;
            this.switchesBox.IsCollapsed = false;
            this.switchesBox.Location = new System.Drawing.Point(10, 12);
            this.switchesBox.Name = "switchesBox";
            this.switchesBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.switchesBox.Size = new System.Drawing.Size(186, 103);
            this.switchesBox.TabIndex = 9;
            this.switchesBox.TabStop = false;
            this.switchesBox.Text = "Event Switches";
            // 
            // localList
            // 
            this.localList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localList.FormattingEnabled = true;
            this.localList.Items.AddRange(new object[] {
            "Switch 1",
            "Switch 2",
            "Switch 3",
            "Switch 4",
            "Switch 5"});
            this.localList.Location = new System.Drawing.Point(4, 25);
            this.localList.Name = "localList";
            this.localList.Size = new System.Drawing.Size(178, 73);
            this.localList.TabIndex = 0;
            this.localList.SelectedIndexChanged += new System.EventHandler(this.localList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 39);
            this.label1.TabIndex = 13;
            this.label1.Text = "Warning: Events that are to be created \r\ndynamically in-game should not use \r\nthi" +
                "s feature.";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(40, 226);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // EventSwitchesDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(208, 259);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conditionBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.switchesBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventSwitchesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event Switch Conditions";
            this.conditionBox.ResumeLayout(false);
            this.conditionBox.PerformLayout();
            this.switchesBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox conditionBox;
        private System.Windows.Forms.RadioButton offBtn;
        private System.Windows.Forms.RadioButton onBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox switchesBox;
        private System.Windows.Forms.ListBox localList;
        private System.Windows.Forms.Label label1;

    }
}