namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    partial class AddEventDialog
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
            this.cbPositionType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudPositionY = new EGMGame.CustomUpDown();
            this.nudPositionX = new EGMGame.CustomUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.cbVariableX = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVariableY = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.panelEvent = new System.Windows.Forms.Panel();
            this.cbOnEvent = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbEvents = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nudLayer = new System.Windows.Forms.NumericUpDown();
            this.impactGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.panelEvent.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 224);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 224);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.cbPositionType);
            this.impactGroupBox2.Controls.Add(this.panel1);
            this.impactGroupBox2.Controls.Add(this.panelVariable);
            this.impactGroupBox2.Controls.Add(this.panelEvent);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 73);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(156, 119);
            this.impactGroupBox2.TabIndex = 44;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Position";
            // 
            // cbPositionType
            // 
            this.cbPositionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPositionType.FormattingEnabled = true;
            this.cbPositionType.Items.AddRange(new object[] {
            "Constant",
            "Variable",
            "Event"});
            this.cbPositionType.Location = new System.Drawing.Point(7, 24);
            this.cbPositionType.Name = "cbPositionType";
            this.cbPositionType.Size = new System.Drawing.Size(130, 21);
            this.cbPositionType.TabIndex = 49;
            this.cbPositionType.SelectedIndexChanged += new System.EventHandler(this.cbPositionType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.nudPositionY);
            this.panel1.Controls.Add(this.nudPositionX);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 57);
            this.panel1.TabIndex = 51;
            this.panel1.Visible = false;
            // 
            // nudPositionY
            // 
            this.nudPositionY.Location = new System.Drawing.Point(17, 30);
            this.nudPositionY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudPositionY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudPositionY.Name = "nudPositionY";
            this.nudPositionY.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPositionY.OnChange = false;
            this.nudPositionY.Size = new System.Drawing.Size(67, 20);
            this.nudPositionY.TabIndex = 35;
            // 
            // nudPositionX
            // 
            this.nudPositionX.Location = new System.Drawing.Point(17, 3);
            this.nudPositionX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudPositionX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudPositionX.Name = "nudPositionX";
            this.nudPositionX.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPositionX.OnChange = false;
            this.nudPositionX.Size = new System.Drawing.Size(67, 20);
            this.nudPositionX.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(-3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(-3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "X:";
            // 
            // panelVariable
            // 
            this.panelVariable.BackColor = System.Drawing.Color.Transparent;
            this.panelVariable.Controls.Add(this.cbVariableX);
            this.panelVariable.Controls.Add(this.label4);
            this.panelVariable.Controls.Add(this.label5);
            this.panelVariable.Controls.Add(this.cbVariableY);
            this.panelVariable.Location = new System.Drawing.Point(7, 51);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(156, 63);
            this.panelVariable.TabIndex = 50;
            this.panelVariable.Visible = false;
            // 
            // cbVariableX
            // 
            this.cbVariableX.AllowCategories = true;
            this.cbVariableX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableX.FormattingEnabled = true;
            this.cbVariableX.Location = new System.Drawing.Point(20, 3);
            this.cbVariableX.Name = "cbVariableX";
            this.cbVariableX.SelectedNode = null;
            this.cbVariableX.Size = new System.Drawing.Size(110, 21);
            this.cbVariableX.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(0, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(0, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Y:";
            // 
            // cbVariableY
            // 
            this.cbVariableY.AllowCategories = true;
            this.cbVariableY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariableY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableY.FormattingEnabled = true;
            this.cbVariableY.Location = new System.Drawing.Point(20, 30);
            this.cbVariableY.Name = "cbVariableY";
            this.cbVariableY.SelectedNode = null;
            this.cbVariableY.Size = new System.Drawing.Size(110, 21);
            this.cbVariableY.TabIndex = 47;
            // 
            // panelEvent
            // 
            this.panelEvent.BackColor = System.Drawing.Color.Transparent;
            this.panelEvent.Controls.Add(this.cbOnEvent);
            this.panelEvent.Location = new System.Drawing.Point(7, 51);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(156, 57);
            this.panelEvent.TabIndex = 52;
            this.panelEvent.Visible = false;
            // 
            // cbOnEvent
            // 
            this.cbOnEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOnEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOnEvent.FormattingEnabled = true;
            this.cbOnEvent.Location = new System.Drawing.Point(0, 3);
            this.cbOnEvent.Name = "cbOnEvent";
            this.cbOnEvent.ShowPlayer = true;
            this.cbOnEvent.ShowTarget = true;
            this.cbOnEvent.ShowTargets = false;
            this.cbOnEvent.Size = new System.Drawing.Size(130, 21);
            this.cbOnEvent.TabIndex = 47;
            this.cbOnEvent.ThisEvent = false;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbEvents);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 55);
            this.impactGroupBox1.TabIndex = 43;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Template Event";
            // 
            // cbEvents
            // 
            this.cbEvents.AllowCategories = true;
            this.cbEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(7, 26);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.SelectedNode = null;
            this.cbEvents.Size = new System.Drawing.Size(130, 21);
            this.cbEvents.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(8, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Layer";
            // 
            // nudLayer
            // 
            this.nudLayer.Location = new System.Drawing.Point(48, 198);
            this.nudLayer.Name = "nudLayer";
            this.nudLayer.Size = new System.Drawing.Size(55, 20);
            this.nudLayer.TabIndex = 72;
            // 
            // AddEventDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(179, 256);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.nudLayer);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEventDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Event";
            this.impactGroupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.panelEvent.ResumeLayout(false);
            this.impactGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private CustomUpDown nudPositionX;
        private CustomUpDown nudPositionY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private EGMGame.Controls.Game.VariableComboBox cbVariableY;
        private EGMGame.Controls.Game.VariableComboBox cbVariableX;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.Game.MapEventComboBox cbOnEvent;
        private EGMGame.Controls.Game.EventComboBox cbEvents;
        private System.Windows.Forms.ComboBox cbPositionType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Panel panelEvent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudLayer;
    }
}