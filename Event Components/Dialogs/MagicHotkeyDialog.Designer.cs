namespace EGMGame.Dialogs
{
    partial class MagicHotkeyDialog
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
            this.cbActionKey2 = new System.Windows.Forms.ComboBox();
            this.cbActionBtn2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbActionKey = new System.Windows.Forms.ComboBox();
            this.cbActionBtn = new System.Windows.Forms.ComboBox();
            this.cbSkills = new EGMGame.Controls.Game.SkillsComboBox(this.components);
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList1 = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(357, 186);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(276, 186);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 13;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.cbActionKey2);
            this.impactGroupBox2.Controls.Add(this.cbActionBtn2);
            this.impactGroupBox2.Controls.Add(this.label3);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Controls.Add(this.label10);
            this.impactGroupBox2.Controls.Add(this.label9);
            this.impactGroupBox2.Controls.Add(this.cbActionKey);
            this.impactGroupBox2.Controls.Add(this.cbActionBtn);
            this.impactGroupBox2.Controls.Add(this.cbSkills);
            this.impactGroupBox2.Enabled = false;
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(124, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(308, 142);
            this.impactGroupBox2.TabIndex = 12;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Settings";
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
            this.cbActionKey2.Location = new System.Drawing.Point(200, 28);
            this.cbActionKey2.Name = "cbActionKey2";
            this.cbActionKey2.Size = new System.Drawing.Size(92, 21);
            this.cbActionKey2.TabIndex = 64;
            this.cbActionKey2.SelectionChangeCommitted += new System.EventHandler(this.cbActionKey2_SelectedIndexChanged);
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
            this.cbActionBtn2.Location = new System.Drawing.Point(200, 59);
            this.cbActionBtn2.Name = "cbActionBtn2";
            this.cbActionBtn2.Size = new System.Drawing.Size(92, 21);
            this.cbActionBtn2.TabIndex = 65;
            this.cbActionBtn2.SelectedIndexChanged += new System.EventHandler(this.cbActionBtn2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "+";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Default Magic";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Image = global::EGMGame.Properties.Resources.controller;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(8, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "      Controller";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Image = global::EGMGame.Properties.Resources.keyboard;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(8, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "      Keyboard";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cbActionKey.Location = new System.Drawing.Point(83, 28);
            this.cbActionKey.Name = "cbActionKey";
            this.cbActionKey.Size = new System.Drawing.Size(92, 21);
            this.cbActionKey.TabIndex = 55;
            this.cbActionKey.SelectedIndexChanged += new System.EventHandler(this.cbActionKey_SelectedIndexChanged);
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
            this.cbActionBtn.Location = new System.Drawing.Point(83, 59);
            this.cbActionBtn.Name = "cbActionBtn";
            this.cbActionBtn.Size = new System.Drawing.Size(92, 21);
            this.cbActionBtn.TabIndex = 56;
            this.cbActionBtn.SelectedIndexChanged += new System.EventHandler(this.cbActionBtn_SelectedIndexChanged);
            // 
            // cbSkills
            // 
            this.cbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Location = new System.Drawing.Point(11, 108);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Noneable = true;
            this.cbSkills.SelectedNode = null;
            this.cbSkills.Size = new System.Drawing.Size(121, 21);
            this.cbSkills.TabIndex = 0;
            this.cbSkills.SelectedIndexChanged += new System.EventHandler(this.cbSkills_SelectedIndexChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.addRemoveList1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(106, 191);
            this.impactGroupBox1.TabIndex = 11;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Hotkeys";
            // 
            // addRemoveList1
            // 
            this.addRemoveList1.AllowAdd = true;
            this.addRemoveList1.AllowCategories = false;
            this.addRemoveList1.AllowClipboard = true;
            this.addRemoveList1.AllowRemove = true;
            this.addRemoveList1.DisplayToolbar = true;
            this.addRemoveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList1.EnableUpDown = false;
            this.addRemoveList1.Export = true;
            this.addRemoveList1.ImageList = null;
            this.addRemoveList1.Import = true;
            this.addRemoveList1.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList1.Master = false;
            this.addRemoveList1.MultipleSelection = false;
            this.addRemoveList1.Name = "addRemoveList1";
            this.addRemoveList1.SelectedIndex = -1;
            this.addRemoveList1.ShowWarning = true;
            this.addRemoveList1.Size = new System.Drawing.Size(98, 161);
            this.addRemoveList1.TabIndex = 1;
            this.addRemoveList1.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList1_AddItem);
            this.addRemoveList1.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList1_RemoveItem);
            this.addRemoveList1.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList1_SelectItem);
            // 
            // MagicHotkeyDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(444, 221);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagicHotkeyDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic Hotkeys";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbActionKey;
        private System.Windows.Forms.ComboBox cbActionBtn;
        private EGMGame.Controls.Game.SkillsComboBox cbSkills;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.AddRemoveList addRemoveList1;
        private System.Windows.Forms.ComboBox cbActionKey2;
        private System.Windows.Forms.ComboBox cbActionBtn2;
    }
}