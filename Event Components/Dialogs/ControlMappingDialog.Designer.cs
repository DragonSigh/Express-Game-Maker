namespace EGMGame.Controls.EventControls
{
    partial class ControlMappingDialog
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
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbAttackPress = new System.Windows.Forms.ComboBox();
            this.btnItemHotkey = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSkillHotkey = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDefendKey = new System.Windows.Forms.ComboBox();
            this.cbDefendBtn = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAttackKey = new System.Windows.Forms.ComboBox();
            this.cbAttackBtn = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCancelKey = new System.Windows.Forms.ComboBox();
            this.cbCancelBtn = new System.Windows.Forms.ComboBox();
            this.cbActionKey = new System.Windows.Forms.ComboBox();
            this.cbActionBtn = new System.Windows.Forms.ComboBox();
            this.cbMovementBtn = new System.Windows.Forms.ComboBox();
            this.cbMovementKey = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(302, 303);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(219, 303);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.cbAttackPress);
            this.impactGroupBox2.Controls.Add(this.btnItemHotkey);
            this.impactGroupBox2.Controls.Add(this.label8);
            this.impactGroupBox2.Controls.Add(this.btnSkillHotkey);
            this.impactGroupBox2.Controls.Add(this.label7);
            this.impactGroupBox2.Controls.Add(this.cbDefendKey);
            this.impactGroupBox2.Controls.Add(this.cbDefendBtn);
            this.impactGroupBox2.Controls.Add(this.label5);
            this.impactGroupBox2.Controls.Add(this.cbAttackKey);
            this.impactGroupBox2.Controls.Add(this.cbAttackBtn);
            this.impactGroupBox2.Controls.Add(this.label4);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 154);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(365, 143);
            this.impactGroupBox2.TabIndex = 1;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Battle";
            // 
            // cbAttackPress
            // 
            this.cbAttackPress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttackPress.FormattingEnabled = true;
            this.cbAttackPress.Items.AddRange(new object[] {
            "New Pressed",
            "Pressed"});
            this.cbAttackPress.Location = new System.Drawing.Point(288, 28);
            this.cbAttackPress.Name = "cbAttackPress";
            this.cbAttackPress.Size = new System.Drawing.Size(70, 21);
            this.cbAttackPress.TabIndex = 70;
            // 
            // btnItemHotkey
            // 
            this.btnItemHotkey.Location = new System.Drawing.Point(92, 109);
            this.btnItemHotkey.Name = "btnItemHotkey";
            this.btnItemHotkey.Size = new System.Drawing.Size(190, 23);
            this.btnItemHotkey.TabIndex = 68;
            this.btnItemHotkey.Text = "Click To Set";
            this.btnItemHotkey.UseVisualStyleBackColor = true;
            this.btnItemHotkey.Click += new System.EventHandler(this.btnItemHotkey_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Item Hotkeys";
            // 
            // btnSkillHotkey
            // 
            this.btnSkillHotkey.Location = new System.Drawing.Point(92, 80);
            this.btnSkillHotkey.Name = "btnSkillHotkey";
            this.btnSkillHotkey.Size = new System.Drawing.Size(190, 23);
            this.btnSkillHotkey.TabIndex = 65;
            this.btnSkillHotkey.Text = "Click To Set";
            this.btnSkillHotkey.UseVisualStyleBackColor = true;
            this.btnSkillHotkey.Click += new System.EventHandler(this.btnSkillHotkey_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(7, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Skill Hotkeys";
            // 
            // cbDefendKey
            // 
            this.cbDefendKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefendKey.FormattingEnabled = true;
            this.cbDefendKey.Items.AddRange(new object[] {
            "None",
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
            this.cbDefendKey.Location = new System.Drawing.Point(92, 55);
            this.cbDefendKey.Name = "cbDefendKey";
            this.cbDefendKey.Size = new System.Drawing.Size(92, 21);
            this.cbDefendKey.TabIndex = 60;
            // 
            // cbDefendBtn
            // 
            this.cbDefendBtn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefendBtn.FormattingEnabled = true;
            this.cbDefendBtn.Items.AddRange(new object[] {
            "None",
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
            this.cbDefendBtn.Location = new System.Drawing.Point(190, 55);
            this.cbDefendBtn.Name = "cbDefendBtn";
            this.cbDefendBtn.Size = new System.Drawing.Size(92, 21);
            this.cbDefendBtn.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Defend";
            // 
            // cbAttackKey
            // 
            this.cbAttackKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttackKey.FormattingEnabled = true;
            this.cbAttackKey.Items.AddRange(new object[] {
            "None",
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
            this.cbAttackKey.Location = new System.Drawing.Point(92, 28);
            this.cbAttackKey.Name = "cbAttackKey";
            this.cbAttackKey.Size = new System.Drawing.Size(92, 21);
            this.cbAttackKey.TabIndex = 57;
            // 
            // cbAttackBtn
            // 
            this.cbAttackBtn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttackBtn.FormattingEnabled = true;
            this.cbAttackBtn.Items.AddRange(new object[] {
            "None",
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
            this.cbAttackBtn.Location = new System.Drawing.Point(190, 28);
            this.cbAttackBtn.Name = "cbAttackBtn";
            this.cbAttackBtn.Size = new System.Drawing.Size(92, 21);
            this.cbAttackBtn.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Attack";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label10);
            this.impactGroupBox1.Controls.Add(this.label9);
            this.impactGroupBox1.Controls.Add(this.cbCancelKey);
            this.impactGroupBox1.Controls.Add(this.cbCancelBtn);
            this.impactGroupBox1.Controls.Add(this.cbActionKey);
            this.impactGroupBox1.Controls.Add(this.cbActionBtn);
            this.impactGroupBox1.Controls.Add(this.cbMovementBtn);
            this.impactGroupBox1.Controls.Add(this.cbMovementKey);
            this.impactGroupBox1.Controls.Add(this.label3);
            this.impactGroupBox1.Controls.Add(this.label2);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(365, 136);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "General";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Image = global::EGMGame.Properties.Resources.controller;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(187, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "      Controller";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Image = global::EGMGame.Properties.Resources.keyboard;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(89, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "      Keyboard";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCancelKey
            // 
            this.cbCancelKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCancelKey.FormattingEnabled = true;
            this.cbCancelKey.Items.AddRange(new object[] {
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
            this.cbCancelKey.Location = new System.Drawing.Point(92, 80);
            this.cbCancelKey.Name = "cbCancelKey";
            this.cbCancelKey.Size = new System.Drawing.Size(92, 21);
            this.cbCancelKey.TabIndex = 55;
            // 
            // cbCancelBtn
            // 
            this.cbCancelBtn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCancelBtn.FormattingEnabled = true;
            this.cbCancelBtn.Items.AddRange(new object[] {
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
            this.cbCancelBtn.Location = new System.Drawing.Point(190, 79);
            this.cbCancelBtn.Name = "cbCancelBtn";
            this.cbCancelBtn.Size = new System.Drawing.Size(92, 21);
            this.cbCancelBtn.TabIndex = 56;
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
            this.cbActionKey.Location = new System.Drawing.Point(92, 53);
            this.cbActionKey.Name = "cbActionKey";
            this.cbActionKey.Size = new System.Drawing.Size(92, 21);
            this.cbActionKey.TabIndex = 53;
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
            this.cbActionBtn.Location = new System.Drawing.Point(190, 53);
            this.cbActionBtn.Name = "cbActionBtn";
            this.cbActionBtn.Size = new System.Drawing.Size(92, 21);
            this.cbActionBtn.TabIndex = 54;
            // 
            // cbMovementBtn
            // 
            this.cbMovementBtn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovementBtn.FormattingEnabled = true;
            this.cbMovementBtn.Items.AddRange(new object[] {
            "Left Stick",
            "D-Pad"});
            this.cbMovementBtn.Location = new System.Drawing.Point(190, 106);
            this.cbMovementBtn.Name = "cbMovementBtn";
            this.cbMovementBtn.Size = new System.Drawing.Size(92, 21);
            this.cbMovementBtn.TabIndex = 6;
            // 
            // cbMovementKey
            // 
            this.cbMovementKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovementKey.FormattingEnabled = true;
            this.cbMovementKey.Items.AddRange(new object[] {
            "Arrow Keys",
            "WASD"});
            this.cbMovementKey.Location = new System.Drawing.Point(92, 107);
            this.cbMovementKey.Name = "cbMovementKey";
            this.cbMovementKey.Size = new System.Drawing.Size(92, 21);
            this.cbMovementKey.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Movement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cancel ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action ";
            // 
            // ControlMappingDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(384, 335);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlMappingDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control Mapping";
            this.Load += new System.EventHandler(this.ControlMappingDialog_Load);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMovementKey;
        private System.Windows.Forms.ComboBox cbMovementBtn;
        private System.Windows.Forms.ComboBox cbCancelKey;
        private System.Windows.Forms.ComboBox cbCancelBtn;
        private System.Windows.Forms.ComboBox cbActionKey;
        private System.Windows.Forms.ComboBox cbActionBtn;
        private System.Windows.Forms.ComboBox cbAttackKey;
        private System.Windows.Forms.ComboBox cbAttackBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDefendKey;
        private System.Windows.Forms.ComboBox cbDefendBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnItemHotkey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSkillHotkey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbAttackPress;
    }
}