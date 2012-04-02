namespace EGMGame
{
    partial class HotKeysDialog
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
            this.chkDont = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnController = new System.Windows.Forms.RadioButton();
            this.btnKeyboard = new System.Windows.Forms.RadioButton();
            this.panelConst = new System.Windows.Forms.Panel();
            this.panelSkill = new System.Windows.Forms.Panel();
            this.cbSkills = new EGMGame.Controls.Game.SkillsComboBox(this.components);
            this.panelItem = new System.Windows.Forms.Panel();
            this.cbItems = new EGMGame.Controls.Game.ItemsComboBox(this.components);
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariable = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.cbIndexType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbActionKey2 = new System.Windows.Forms.ComboBox();
            this.cbActionBtn2 = new System.Windows.Forms.ComboBox();
            this.cbActionKey = new System.Windows.Forms.ComboBox();
            this.cbActionBtn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConditions = new System.Windows.Forms.ComboBox();
            this.impactGroupBox1.SuspendLayout();
            this.panelConst.SuspendLayout();
            this.panelSkill.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(259, 186);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(178, 186);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // chkDont
            // 
            this.chkDont.AutoSize = true;
            this.chkDont.Location = new System.Drawing.Point(12, 192);
            this.chkDont.Name = "chkDont";
            this.chkDont.Size = new System.Drawing.Size(134, 17);
            this.chkDont.TabIndex = 22;
            this.chkDont.Text = "Do not allow duplicate.";
            this.chkDont.UseVisualStyleBackColor = true;
            this.chkDont.Visible = false;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.btnController);
            this.impactGroupBox1.Controls.Add(this.btnKeyboard);
            this.impactGroupBox1.Controls.Add(this.panelConst);
            this.impactGroupBox1.Controls.Add(this.panelVariable);
            this.impactGroupBox1.Controls.Add(this.cbIndexType);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label10);
            this.impactGroupBox1.Controls.Add(this.label9);
            this.impactGroupBox1.Controls.Add(this.cbActionKey2);
            this.impactGroupBox1.Controls.Add(this.cbActionBtn2);
            this.impactGroupBox1.Controls.Add(this.cbActionKey);
            this.impactGroupBox1.Controls.Add(this.cbActionBtn);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.cbConditions);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(322, 168);
            this.impactGroupBox1.TabIndex = 64;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // btnController
            // 
            this.btnController.AutoSize = true;
            this.btnController.Location = new System.Drawing.Point(7, 65);
            this.btnController.Name = "btnController";
            this.btnController.Size = new System.Drawing.Size(14, 13);
            this.btnController.TabIndex = 83;
            this.btnController.UseVisualStyleBackColor = true;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.AutoSize = true;
            this.btnKeyboard.Checked = true;
            this.btnKeyboard.Location = new System.Drawing.Point(7, 32);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(14, 13);
            this.btnKeyboard.TabIndex = 82;
            this.btnKeyboard.TabStop = true;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            // 
            // panelConst
            // 
            this.panelConst.BackColor = System.Drawing.Color.Transparent;
            this.panelConst.Controls.Add(this.panelSkill);
            this.panelConst.Controls.Add(this.panelItem);
            this.panelConst.Location = new System.Drawing.Point(7, 126);
            this.panelConst.Name = "panelConst";
            this.panelConst.Size = new System.Drawing.Size(138, 34);
            this.panelConst.TabIndex = 81;
            // 
            // panelSkill
            // 
            this.panelSkill.BackColor = System.Drawing.Color.Transparent;
            this.panelSkill.Controls.Add(this.cbSkills);
            this.panelSkill.Location = new System.Drawing.Point(4, 2);
            this.panelSkill.Name = "panelSkill";
            this.panelSkill.Size = new System.Drawing.Size(131, 28);
            this.panelSkill.TabIndex = 76;
            // 
            // cbSkills
            // 
            this.cbSkills.AllowCategories = true;
            this.cbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Location = new System.Drawing.Point(3, 3);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Noneable = false;
            this.cbSkills.SelectedNode = null;
            this.cbSkills.Size = new System.Drawing.Size(128, 21);
            this.cbSkills.TabIndex = 0;
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.Transparent;
            this.panelItem.Controls.Add(this.cbItems);
            this.panelItem.Location = new System.Drawing.Point(4, 2);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(131, 28);
            this.panelItem.TabIndex = 75;
            // 
            // cbItems
            // 
            this.cbItems.AllowCategories = true;
            this.cbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(3, 3);
            this.cbItems.Name = "cbItems";
            this.cbItems.Noneable = true;
            this.cbItems.SelectedNode = null;
            this.cbItems.Size = new System.Drawing.Size(128, 21);
            this.cbItems.TabIndex = 74;
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariable);
            this.panelVariable.Location = new System.Drawing.Point(7, 126);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(131, 28);
            this.panelVariable.TabIndex = 80;
            // 
            // cbVariable
            // 
            this.cbVariable.AllowCategories = true;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(3, 3);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.SelectedNode = null;
            this.cbVariable.Size = new System.Drawing.Size(128, 21);
            this.cbVariable.TabIndex = 0;
            // 
            // cbIndexType
            // 
            this.cbIndexType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndexType.FormattingEnabled = true;
            this.cbIndexType.Items.AddRange(new object[] {
            "Constant",
            "Variable"});
            this.cbIndexType.Location = new System.Drawing.Point(144, 105);
            this.cbIndexType.Name = "cbIndexType";
            this.cbIndexType.Size = new System.Drawing.Size(92, 21);
            this.cbIndexType.TabIndex = 79;
            this.cbIndexType.SelectedIndexChanged += new System.EventHandler(this.cbIndexType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "+";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Image = global::EGMGame.Properties.Resources.controller;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(27, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "      Controller";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Image = global::EGMGame.Properties.Resources.keyboard;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(27, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 69;
            this.label9.Text = "      Keyboard";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbActionKey2
            // 
            this.cbActionKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionKey2.FormattingEnabled = true;
            this.cbActionKey2.Items.AddRange(new object[] {
            "(none)",
            "Up",
            "Down",
            "Left",
            "Right",
            "Back",
            "Tab",
            "Enter",
            "Escape",
            "Space",
            "PageUp",
            "PageDown",
            "End",
            "Home",
            "PrintScreen",
            "Insert",
            "Delete",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "Multiply",
            "Add",
            "Separator",
            "Subtract",
            "Decimal",
            "Divide",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F22",
            "F23",
            "F24",
            "NumLock",
            "Scroll",
            "LeftShift",
            "RightShift ",
            "LeftControl",
            "RightControl",
            "LeftAlt",
            "RightAlt",
            "Semicolon",
            "Plus",
            "Comma",
            "Minus ",
            "Period ",
            "Question ",
            "Tilde",
            "OpenBrackets",
            "OemPipe",
            "CloseBrackets",
            "Quotes",
            "Backslash"});
            this.cbActionKey2.Location = new System.Drawing.Point(219, 29);
            this.cbActionKey2.Name = "cbActionKey2";
            this.cbActionKey2.Size = new System.Drawing.Size(92, 21);
            this.cbActionKey2.TabIndex = 67;
            // 
            // cbActionBtn2
            // 
            this.cbActionBtn2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionBtn2.FormattingEnabled = true;
            this.cbActionBtn2.Items.AddRange(new object[] {
            "(none)",
            "Left Stick",
            "Right Stick",
            "Up",
            "Down",
            "Left",
            "Right",
            "X",
            "A",
            "B",
            "Y",
            "Left Trigger",
            "Right Trigger",
            "Left Bumper",
            "Right Bumper",
            "Back",
            "Start"});
            this.cbActionBtn2.Location = new System.Drawing.Point(219, 60);
            this.cbActionBtn2.Name = "cbActionBtn2";
            this.cbActionBtn2.Size = new System.Drawing.Size(92, 21);
            this.cbActionBtn2.TabIndex = 68;
            // 
            // cbActionKey
            // 
            this.cbActionKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionKey.FormattingEnabled = true;
            this.cbActionKey.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right",
            "Back",
            "Tab",
            "Enter",
            "Escape",
            "Space",
            "PageUp",
            "PageDown",
            "End",
            "Home",
            "PrintScreen",
            "Insert",
            "Delete",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "Multiply",
            "Add",
            "Separator",
            "Subtract",
            "Decimal",
            "Divide",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F22",
            "F23",
            "F24",
            "NumLock",
            "Scroll",
            "LeftShift",
            "RightShift ",
            "LeftControl",
            "RightControl",
            "LeftAlt",
            "RightAlt",
            "Semicolon",
            "Plus",
            "Comma",
            "Minus ",
            "Period ",
            "Question ",
            "Tilde",
            "OpenBrackets",
            "OemPipe",
            "CloseBrackets",
            "Quotes",
            "Backslash"});
            this.cbActionKey.Location = new System.Drawing.Point(102, 29);
            this.cbActionKey.Name = "cbActionKey";
            this.cbActionKey.Size = new System.Drawing.Size(92, 21);
            this.cbActionKey.TabIndex = 65;
            // 
            // cbActionBtn
            // 
            this.cbActionBtn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionBtn.FormattingEnabled = true;
            this.cbActionBtn.Items.AddRange(new object[] {
            "Left Stick",
            "Right Stick",
            "Up",
            "Down",
            "Left",
            "Right",
            "X",
            "A",
            "B",
            "Y",
            "Left Trigger",
            "Right Trigger",
            "Left Bumper",
            "Right Bumper",
            "Back",
            "Start"});
            this.cbActionBtn.Location = new System.Drawing.Point(102, 60);
            this.cbActionBtn.Name = "cbActionBtn";
            this.cbActionBtn.Size = new System.Drawing.Size(92, 21);
            this.cbActionBtn.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Select type.";
            // 
            // cbConditions
            // 
            this.cbConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConditions.FormattingEnabled = true;
            this.cbConditions.Items.AddRange(new object[] {
            "Skill",
            "Item"});
            this.cbConditions.Location = new System.Drawing.Point(10, 105);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(128, 21);
            this.cbConditions.TabIndex = 51;
            this.cbConditions.SelectedIndexChanged += new System.EventHandler(this.cbConditions_SelectedIndexChanged);
            // 
            // HotKeysDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(344, 219);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.chkDont);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotKeysDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hotkeys";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelConst.ResumeLayout(false);
            this.panelSkill.ResumeLayout(false);
            this.panelItem.ResumeLayout(false);
            this.panelVariable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox chkDont;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConditions;
        private Controls.Game.ItemsComboBox cbItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbActionKey2;
        private System.Windows.Forms.ComboBox cbActionBtn2;
        private System.Windows.Forms.ComboBox cbActionKey;
        private System.Windows.Forms.ComboBox cbActionBtn;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.Panel panelSkill;
        private Controls.Game.SkillsComboBox cbSkills;
        private System.Windows.Forms.ComboBox cbIndexType;
        private System.Windows.Forms.Panel panelVariable;
        private Controls.Game.VariableComboBox cbVariable;
        private System.Windows.Forms.Panel panelConst;
        private System.Windows.Forms.RadioButton btnController;
        private System.Windows.Forms.RadioButton btnKeyboard;
    }
}