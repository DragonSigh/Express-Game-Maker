namespace EGMGame
{
    partial class ButtonInputConditionDialog
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
            this.xboxBtn = new System.Windows.Forms.CheckBox();
            this.keyboardBtn = new System.Windows.Forms.CheckBox();
            this.btnStateList = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.keyStateList = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.ComboBox();
            this.keyList = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.playerList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xboxBtn
            // 
            this.xboxBtn.AutoSize = true;
            this.xboxBtn.BackColor = System.Drawing.Color.Transparent;
            this.xboxBtn.Location = new System.Drawing.Point(7, 56);
            this.xboxBtn.Name = "xboxBtn";
            this.xboxBtn.Size = new System.Drawing.Size(70, 17);
            this.xboxBtn.TabIndex = 58;
            this.xboxBtn.Text = "Controller";
            this.xboxBtn.UseVisualStyleBackColor = false;
            this.xboxBtn.CheckedChanged += new System.EventHandler(this.xboxBtn_CheckedChanged);
            // 
            // keyboardBtn
            // 
            this.keyboardBtn.AutoSize = true;
            this.keyboardBtn.BackColor = System.Drawing.Color.Transparent;
            this.keyboardBtn.Location = new System.Drawing.Point(7, 28);
            this.keyboardBtn.Name = "keyboardBtn";
            this.keyboardBtn.Size = new System.Drawing.Size(71, 17);
            this.keyboardBtn.TabIndex = 57;
            this.keyboardBtn.Text = "Keyboard";
            this.keyboardBtn.UseVisualStyleBackColor = false;
            this.keyboardBtn.CheckedChanged += new System.EventHandler(this.keyboardBtn_CheckedChanged);
            // 
            // btnStateList
            // 
            this.btnStateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnStateList.Enabled = false;
            this.btnStateList.FormattingEnabled = true;
            this.btnStateList.Items.AddRange(new object[] {
            "Pressed",
            "Held",
            "Released",
            "New Pressed",
            "Moved (Stick)"});
            this.btnStateList.Location = new System.Drawing.Point(201, 53);
            this.btnStateList.Name = "btnStateList";
            this.btnStateList.Size = new System.Drawing.Size(71, 21);
            this.btnStateList.TabIndex = 56;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(181, 57);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 13);
            this.label21.TabIndex = 55;
            this.label21.Text = "is";
            // 
            // keyStateList
            // 
            this.keyStateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyStateList.Enabled = false;
            this.keyStateList.FormattingEnabled = true;
            this.keyStateList.Items.AddRange(new object[] {
            "Pressed",
            "Held",
            "Released",
            "New Pressed"});
            this.keyStateList.Location = new System.Drawing.Point(201, 26);
            this.keyStateList.Name = "keyStateList";
            this.keyStateList.Size = new System.Drawing.Size(71, 21);
            this.keyStateList.TabIndex = 54;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(181, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 13);
            this.label20.TabIndex = 53;
            this.label20.Text = "is";
            // 
            // btnList
            // 
            this.btnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnList.Enabled = false;
            this.btnList.FormattingEnabled = true;
            this.btnList.Items.AddRange(new object[] {
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
            this.btnList.Location = new System.Drawing.Point(83, 53);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(92, 21);
            this.btnList.TabIndex = 52;
            // 
            // keyList
            // 
            this.keyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyList.Enabled = false;
            this.keyList.FormattingEnabled = true;
            this.keyList.Items.AddRange(new object[] {
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
            this.keyList.Location = new System.Drawing.Point(83, 26);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(92, 21);
            this.keyList.TabIndex = 51;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(144, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.playerList);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Controls.Add(this.keyboardBtn);
            this.impactGroupBox1.Controls.Add(this.keyList);
            this.impactGroupBox1.Controls.Add(this.btnList);
            this.impactGroupBox1.Controls.Add(this.label20);
            this.impactGroupBox1.Controls.Add(this.keyStateList);
            this.impactGroupBox1.Controls.Add(this.xboxBtn);
            this.impactGroupBox1.Controls.Add(this.label21);
            this.impactGroupBox1.Controls.Add(this.btnStateList);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(288, 127);
            this.impactGroupBox1.TabIndex = 63;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Input";
            // 
            // playerList
            // 
            this.playerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerList.Enabled = false;
            this.playerList.FormattingEnabled = true;
            this.playerList.Items.AddRange(new object[] {
            "Player 1",
            "Player 2",
            "Player 3",
            "Player 4",
            "Any"});
            this.playerList.Location = new System.Drawing.Point(7, 98);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(84, 21);
            this.playerList.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Choose the player for the controller.";
            // 
            // elseBranc
            // 
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(12, 145);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 61;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // ButtonInputConditionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(312, 204);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ButtonInputConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Button Input Condition";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox xboxBtn;
        private System.Windows.Forms.CheckBox keyboardBtn;
        private System.Windows.Forms.ComboBox btnStateList;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox keyStateList;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox btnList;
        private System.Windows.Forms.ComboBox keyList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox playerList;
        private System.Windows.Forms.CheckBox elseBranc;

    }
}