using EGMGame.Controls;
namespace EGMGame
{
    partial class SwitchConditionDialog
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
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.localBtn = new System.Windows.Forms.RadioButton();
            this.switchesBtn = new System.Windows.Forms.RadioButton();
            this.operationsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.operationsList = new System.Windows.Forms.ComboBox();
            this.localSwitchesList = new EGMGame.Controls.Game.SwitchesComboBox(this.components);
            this.switchesList = new EGMGame.Controls.Game.SwitchesComboBox(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.offBtn = new System.Windows.Forms.RadioButton();
            this.onBtn = new System.Windows.Forms.RadioButton();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox2.SuspendLayout();
            this.operationsBox.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(305, 325);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(224, 325);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 12;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.localBtn);
            this.impactGroupBox2.Controls.Add(this.switchesBtn);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(163, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(218, 53);
            this.impactGroupBox2.TabIndex = 72;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Switch";
            // 
            // localBtn
            // 
            this.localBtn.AutoSize = true;
            this.localBtn.BackColor = System.Drawing.Color.Transparent;
            this.localBtn.Location = new System.Drawing.Point(85, 28);
            this.localBtn.Name = "localBtn";
            this.localBtn.Size = new System.Drawing.Size(97, 17);
            this.localBtn.TabIndex = 72;
            this.localBtn.Text = "Local Switches";
            this.localBtn.UseVisualStyleBackColor = false;
            // 
            // switchesBtn
            // 
            this.switchesBtn.AutoSize = true;
            this.switchesBtn.BackColor = System.Drawing.Color.Transparent;
            this.switchesBtn.Checked = true;
            this.switchesBtn.Location = new System.Drawing.Point(7, 28);
            this.switchesBtn.Name = "switchesBtn";
            this.switchesBtn.Size = new System.Drawing.Size(68, 17);
            this.switchesBtn.TabIndex = 71;
            this.switchesBtn.TabStop = true;
            this.switchesBtn.Text = "Switches";
            this.switchesBtn.UseVisualStyleBackColor = false;
            this.switchesBtn.CheckedChanged += new System.EventHandler(this.variablesBtn_CheckedChanged);
            // 
            // operationsBox
            // 
            this.operationsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.operationsBox.Controls.Add(this.label1);
            this.operationsBox.Controls.Add(this.label2);
            this.operationsBox.Controls.Add(this.operationsList);
            this.operationsBox.Controls.Add(this.localSwitchesList);
            this.operationsBox.Controls.Add(this.switchesList);
            this.operationsBox.Controls.Add(this.radioButton1);
            this.operationsBox.Controls.Add(this.radioButton2);
            this.operationsBox.Controls.Add(this.offBtn);
            this.operationsBox.Controls.Add(this.onBtn);
            this.operationsBox.Enabled = false;
            this.operationsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.operationsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.operationsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.operationsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.operationsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.operationsBox.Location = new System.Drawing.Point(163, 71);
            this.operationsBox.Name = "operationsBox";
            this.operationsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.operationsBox.Size = new System.Drawing.Size(219, 221);
            this.operationsBox.TabIndex = 14;
            this.operationsBox.TabStop = false;
            this.operationsBox.Text = "Condition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Choose the value to compare to.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Choose the compare type for the condition.";
            // 
            // operationsList
            // 
            this.operationsList.DisplayMember = "Add";
            this.operationsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationsList.FormattingEnabled = true;
            this.operationsList.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Does Not Equal"});
            this.operationsList.Location = new System.Drawing.Point(7, 43);
            this.operationsList.Name = "operationsList";
            this.operationsList.Size = new System.Drawing.Size(121, 21);
            this.operationsList.TabIndex = 10;
            this.operationsList.ValueMember = "Add";
            // 
            // localSwitchesList
            // 
            this.localSwitchesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.localSwitchesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localSwitchesList.Enabled = false;
            this.localSwitchesList.FormattingEnabled = true;
            this.localSwitchesList.Location = new System.Drawing.Point(7, 186);
            this.localSwitchesList.Name = "localSwitchesList";
            this.localSwitchesList.SelectedNode = null;
            this.localSwitchesList.Size = new System.Drawing.Size(113, 21);
            this.localSwitchesList.TabIndex = 5;
            // 
            // switchesList
            // 
            this.switchesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.switchesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.switchesList.Enabled = false;
            this.switchesList.FormattingEnabled = true;
            this.switchesList.Location = new System.Drawing.Point(7, 136);
            this.switchesList.Name = "switchesList";
            this.switchesList.SelectedNode = null;
            this.switchesList.Size = new System.Drawing.Size(113, 21);
            this.switchesList.TabIndex = 4;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Location = new System.Drawing.Point(7, 163);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Local Switch";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Location = new System.Drawing.Point(7, 113);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Switch";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // offBtn
            // 
            this.offBtn.AutoSize = true;
            this.offBtn.BackColor = System.Drawing.Color.Transparent;
            this.offBtn.Checked = true;
            this.offBtn.Location = new System.Drawing.Point(54, 90);
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
            this.onBtn.Location = new System.Drawing.Point(7, 90);
            this.onBtn.Name = "onBtn";
            this.onBtn.Size = new System.Drawing.Size(39, 17);
            this.onBtn.TabIndex = 0;
            this.onBtn.Text = "On";
            this.onBtn.UseVisualStyleBackColor = false;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.addRemoveList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(145, 303);
            this.impactGroupBox1.TabIndex = 10;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Switches";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = false;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowClipboard = true;
            this.addRemoveList.AllowRemove = false;
            this.addRemoveList.DisplayToolbar = false;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.Export = true;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Import = true;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = false;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(137, 273);
            this.addRemoveList.TabIndex = 0;
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(163, 298);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 73;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // SwitchConditionDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(392, 360);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.operationsBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SwitchConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Switch Condition";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.operationsBox.ResumeLayout(false);
            this.operationsBox.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private AddRemoveList addRemoveList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox operationsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox operationsList;
        private EGMGame.Controls.Game.SwitchesComboBox localSwitchesList;
        private EGMGame.Controls.Game.SwitchesComboBox switchesList;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton offBtn;
        private System.Windows.Forms.RadioButton onBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.RadioButton localBtn;
        private System.Windows.Forms.RadioButton switchesBtn;
        private System.Windows.Forms.CheckBox elseBranc;

    }
}