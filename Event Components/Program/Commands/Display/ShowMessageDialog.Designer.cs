namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class ShowMessageDialog
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
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbText = new EGMGame.Controls.Game.TextComboBox(this.components);
            this.cbMessage = new EGMGame.Controls.MessageEditor();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbMenu = new EGMGame.Controls.Game.MessageComboBox(this.components);
            this.cbSizeType = new System.Windows.Forms.ComboBox();
            this.panelSize = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.heightBox = new EGMGame.CustomUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.widthBox = new EGMGame.CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPosType = new System.Windows.Forms.ComboBox();
            this.panelScreen = new System.Windows.Forms.Panel();
            this.nudY = new EGMGame.CustomUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudX = new EGMGame.CustomUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panelEvent = new System.Windows.Forms.Panel();
            this.cbEvents = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.nudOffYBox = new EGMGame.CustomUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudOffXBox = new EGMGame.CustomUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panelDock = new System.Windows.Forms.Panel();
            this.cbDock = new System.Windows.Forms.ComboBox();
            this.nudOffDockY = new EGMGame.CustomUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudOffDockX = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkWait = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.impactGroupBox3.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.panelSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.panelScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            this.panelEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffYBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffXBox)).BeginInit();
            this.panelDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffDockY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffDockX)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(281, 405);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 20;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(200, 405);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 19;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.cbText);
            this.impactGroupBox3.Controls.Add(this.cbMessage);
            this.impactGroupBox3.Controls.Add(this.rbCustom);
            this.impactGroupBox3.Controls.Add(this.rbText);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(344, 193);
            this.impactGroupBox3.TabIndex = 18;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Text";
            // 
            // cbText
            // 
            this.cbText.AllowCategories = true;
            this.cbText.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbText.FormattingEnabled = true;
            this.cbText.Location = new System.Drawing.Point(29, 28);
            this.cbText.Name = "cbText";
            this.cbText.Noneable = true;
            this.cbText.SelectedNode = null;
            this.cbText.Size = new System.Drawing.Size(187, 21);
            this.cbText.TabIndex = 16;
            // 
            // cbMessage
            // 
            this.cbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbMessage.Enabled = false;
            this.cbMessage.Location = new System.Drawing.Point(29, 56);
            this.cbMessage.Name = "cbMessage";
            this.cbMessage.Size = new System.Drawing.Size(308, 124);
            this.cbMessage.TabIndex = 15;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.BackColor = System.Drawing.Color.Transparent;
            this.rbCustom.Location = new System.Drawing.Point(10, 61);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(14, 13);
            this.rbCustom.TabIndex = 13;
            this.rbCustom.UseVisualStyleBackColor = false;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.BackColor = System.Drawing.Color.Transparent;
            this.rbText.Checked = true;
            this.rbText.Location = new System.Drawing.Point(10, 31);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(14, 13);
            this.rbText.TabIndex = 12;
            this.rbText.TabStop = true;
            this.rbText.UseVisualStyleBackColor = false;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.cbMenu);
            this.impactGroupBox2.Controls.Add(this.cbSizeType);
            this.impactGroupBox2.Controls.Add(this.panelSize);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 211);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(186, 159);
            this.impactGroupBox2.TabIndex = 17;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Menu";
            // 
            // cbMenu
            // 
            this.cbMenu.AllowCategories = true;
            this.cbMenu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMenu.FormattingEnabled = true;
            this.cbMenu.Location = new System.Drawing.Point(10, 41);
            this.cbMenu.Name = "cbMenu";
            this.cbMenu.SelectedNode = null;
            this.cbMenu.Size = new System.Drawing.Size(131, 21);
            this.cbMenu.TabIndex = 19;
            // 
            // cbSizeType
            // 
            this.cbSizeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSizeType.FormattingEnabled = true;
            this.cbSizeType.Items.AddRange(new object[] {
            "Default Size",
            "Custom Size",
            "AutoFit To Text"});
            this.cbSizeType.Location = new System.Drawing.Point(10, 68);
            this.cbSizeType.Name = "cbSizeType";
            this.cbSizeType.Size = new System.Drawing.Size(118, 21);
            this.cbSizeType.TabIndex = 18;
            this.cbSizeType.SelectedIndexChanged += new System.EventHandler(this.cbSizeType_SelectedIndexChanged);
            // 
            // panelSize
            // 
            this.panelSize.BackColor = System.Drawing.Color.Transparent;
            this.panelSize.Controls.Add(this.label8);
            this.panelSize.Controls.Add(this.heightBox);
            this.panelSize.Controls.Add(this.label9);
            this.panelSize.Controls.Add(this.widthBox);
            this.panelSize.Location = new System.Drawing.Point(10, 95);
            this.panelSize.Name = "panelSize";
            this.panelSize.Size = new System.Drawing.Size(118, 53);
            this.panelSize.TabIndex = 16;
            this.panelSize.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Width:";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(47, 30);
            this.heightBox.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.heightBox.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.heightBox.Name = "heightBox";
            this.heightBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.heightBox.OnChange = false;
            this.heightBox.Size = new System.Drawing.Size(61, 20);
            this.heightBox.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(3, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Height:";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(47, 4);
            this.widthBox.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.widthBox.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.widthBox.Name = "widthBox";
            this.widthBox.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.widthBox.OnChange = false;
            this.widthBox.Size = new System.Drawing.Size(61, 20);
            this.widthBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the menu to display.";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label10);
            this.impactGroupBox1.Controls.Add(this.cbPosType);
            this.impactGroupBox1.Controls.Add(this.panelScreen);
            this.impactGroupBox1.Controls.Add(this.panelEvent);
            this.impactGroupBox1.Controls.Add(this.panelDock);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(204, 211);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(152, 159);
            this.impactGroupBox1.TabIndex = 16;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Position";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Select Position.";
            // 
            // cbPosType
            // 
            this.cbPosType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPosType.FormattingEnabled = true;
            this.cbPosType.Items.AddRange(new object[] {
            "Dock",
            "Screen",
            "Event"});
            this.cbPosType.Location = new System.Drawing.Point(7, 41);
            this.cbPosType.Name = "cbPosType";
            this.cbPosType.Size = new System.Drawing.Size(120, 21);
            this.cbPosType.TabIndex = 11;
            this.cbPosType.SelectedIndexChanged += new System.EventHandler(this.cbPosType_SelectedIndexChanged);
            // 
            // panelScreen
            // 
            this.panelScreen.BackColor = System.Drawing.Color.Transparent;
            this.panelScreen.Controls.Add(this.nudY);
            this.panelScreen.Controls.Add(this.label4);
            this.panelScreen.Controls.Add(this.nudX);
            this.panelScreen.Controls.Add(this.label5);
            this.panelScreen.Location = new System.Drawing.Point(4, 68);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.Size = new System.Drawing.Size(92, 55);
            this.panelScreen.TabIndex = 10;
            this.panelScreen.Visible = false;
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(25, 29);
            this.nudY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudY.Name = "nudY";
            this.nudY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudY.OnChange = false;
            this.nudY.Size = new System.Drawing.Size(61, 20);
            this.nudY.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(2, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "X:";
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(25, 3);
            this.nudX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudX.Name = "nudX";
            this.nudX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudX.OnChange = false;
            this.nudX.Size = new System.Drawing.Size(61, 20);
            this.nudX.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(2, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Y:";
            // 
            // panelEvent
            // 
            this.panelEvent.BackColor = System.Drawing.Color.Transparent;
            this.panelEvent.Controls.Add(this.cbEvents);
            this.panelEvent.Controls.Add(this.nudOffYBox);
            this.panelEvent.Controls.Add(this.label6);
            this.panelEvent.Controls.Add(this.nudOffXBox);
            this.panelEvent.Controls.Add(this.label7);
            this.panelEvent.Location = new System.Drawing.Point(4, 68);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(141, 79);
            this.panelEvent.TabIndex = 10;
            this.panelEvent.Visible = false;
            // 
            // cbEvents
            // 
            this.cbEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(7, 3);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.ShowPlayer = true;
            this.cbEvents.ShowTarget = true;
            this.cbEvents.ShowTargets = false;
            this.cbEvents.Size = new System.Drawing.Size(131, 21);
            this.cbEvents.TabIndex = 9;
            this.cbEvents.ThisEvent = true;
            // 
            // nudOffYBox
            // 
            this.nudOffYBox.Location = new System.Drawing.Point(57, 56);
            this.nudOffYBox.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudOffYBox.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudOffYBox.Name = "nudOffYBox";
            this.nudOffYBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudOffYBox.OnChange = false;
            this.nudOffYBox.Size = new System.Drawing.Size(61, 20);
            this.nudOffYBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Offset-X:";
            // 
            // nudOffXBox
            // 
            this.nudOffXBox.Location = new System.Drawing.Point(57, 30);
            this.nudOffXBox.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudOffXBox.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudOffXBox.Name = "nudOffXBox";
            this.nudOffXBox.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudOffXBox.OnChange = false;
            this.nudOffXBox.Size = new System.Drawing.Size(61, 20);
            this.nudOffXBox.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Offset-Y:";
            // 
            // panelDock
            // 
            this.panelDock.BackColor = System.Drawing.Color.Transparent;
            this.panelDock.Controls.Add(this.cbDock);
            this.panelDock.Controls.Add(this.nudOffDockY);
            this.panelDock.Controls.Add(this.label2);
            this.panelDock.Controls.Add(this.nudOffDockX);
            this.panelDock.Controls.Add(this.label3);
            this.panelDock.Location = new System.Drawing.Point(4, 68);
            this.panelDock.Name = "panelDock";
            this.panelDock.Size = new System.Drawing.Size(120, 79);
            this.panelDock.TabIndex = 9;
            this.panelDock.Visible = false;
            // 
            // cbDock
            // 
            this.cbDock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDock.FormattingEnabled = true;
            this.cbDock.Items.AddRange(new object[] {
            "Top",
            "Bottom",
            "Left",
            "Right",
            "Middle"});
            this.cbDock.Location = new System.Drawing.Point(3, 3);
            this.cbDock.Name = "cbDock";
            this.cbDock.Size = new System.Drawing.Size(115, 21);
            this.cbDock.TabIndex = 4;
            // 
            // nudOffDockY
            // 
            this.nudOffDockY.Location = new System.Drawing.Point(57, 56);
            this.nudOffDockY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudOffDockY.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudOffDockY.Name = "nudOffDockY";
            this.nudOffDockY.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudOffDockY.OnChange = false;
            this.nudOffDockY.Size = new System.Drawing.Size(61, 20);
            this.nudOffDockY.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Offset-X:";
            // 
            // nudOffDockX
            // 
            this.nudOffDockX.Location = new System.Drawing.Point(57, 30);
            this.nudOffDockX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudOffDockX.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.nudOffDockX.Name = "nudOffDockX";
            this.nudOffDockX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudOffDockX.OnChange = false;
            this.nudOffDockX.Size = new System.Drawing.Size(61, 20);
            this.nudOffDockX.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Offset-Y:";
            // 
            // chkWait
            // 
            this.chkWait.AutoSize = true;
            this.chkWait.Checked = true;
            this.chkWait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWait.Location = new System.Drawing.Point(12, 380);
            this.chkWait.Name = "chkWait";
            this.chkWait.Size = new System.Drawing.Size(159, 17);
            this.chkWait.TabIndex = 21;
            this.chkWait.Text = "Wait until message is closed";
            this.chkWait.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::EGMGame.Properties.Resources.application_blue;
            this.btnPreview.Location = new System.Drawing.Point(281, 376);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 22;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // ShowMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(366, 439);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.chkWait);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowMessageDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Message";
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox3.PerformLayout();
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.panelSize.ResumeLayout(false);
            this.panelSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelScreen.ResumeLayout(false);
            this.panelScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            this.panelEvent.ResumeLayout(false);
            this.panelEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffYBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffXBox)).EndInit();
            this.panelDock.ResumeLayout(false);
            this.panelDock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffDockY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffDockX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomUpDown nudOffDockX;
        private CustomUpDown nudOffDockY;
        private System.Windows.Forms.Panel panelDock;
        private System.Windows.Forms.Panel panelScreen;
        private CustomUpDown nudY;
        private System.Windows.Forms.Label label4;
        private CustomUpDown nudX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelEvent;
        private CustomUpDown nudOffYBox;
        private System.Windows.Forms.Label label6;
        private CustomUpDown nudOffXBox;
        private System.Windows.Forms.Label label7;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private MessageEditor cbMessage;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel panelSize;
        private System.Windows.Forms.Label label8;
        private CustomUpDown heightBox;
        private System.Windows.Forms.Label label9;
        private CustomUpDown widthBox;
        private EGMGame.Controls.Game.MapEventComboBox cbEvents;
        private EGMGame.Controls.Game.TextComboBox cbText;
        private System.Windows.Forms.ComboBox cbPosType;
        private System.Windows.Forms.ComboBox cbSizeType;
        private System.Windows.Forms.Label label10;
        private EGMGame.Controls.Game.MessageComboBox cbMenu;
        private System.Windows.Forms.CheckBox chkWait;
        private System.Windows.Forms.Button btnPreview;
    }
}