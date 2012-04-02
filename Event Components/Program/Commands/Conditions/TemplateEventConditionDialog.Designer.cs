namespace EGMGame
{
    partial class TEventConditionDialog
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
            this.elseBranc = new System.Windows.Forms.CheckBox();
            this.conditionsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.rbIsColliding = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAtAngle2 = new EGMGame.CustomUpDown();
            this.nudAtAngle1 = new EGMGame.CustomUpDown();
            this.rbAtAngle = new System.Windows.Forms.RadioButton();
            this.rbFacingEvent = new System.Windows.Forms.RadioButton();
            this.rbInDirection = new System.Windows.Forms.RadioButton();
            this.rbInRange = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.nudRange = new EGMGame.CustomUpDown();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbCompare = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventList = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.eventDirectionList = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.eventFacingList = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.cbAtAngle = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.cbCollidingEvents = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.eventRangeList = new EGMGame.Controls.Game.EventComboBox(this.components);
            this.conditionsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(315, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(234, 288);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 41;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // elseBranc
            // 
            this.elseBranc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.elseBranc.AutoSize = true;
            this.elseBranc.BackColor = System.Drawing.Color.Transparent;
            this.elseBranc.Location = new System.Drawing.Point(11, 267);
            this.elseBranc.Name = "elseBranc";
            this.elseBranc.Size = new System.Drawing.Size(165, 17);
            this.elseBranc.TabIndex = 90;
            this.elseBranc.Text = "Branch if condition is not met.";
            this.elseBranc.UseVisualStyleBackColor = false;
            this.elseBranc.CheckedChanged += new System.EventHandler(this.elseBranc_CheckedChanged);
            // 
            // conditionsBox
            // 
            this.conditionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.conditionsBox.CanCollapse = false;
            this.conditionsBox.Controls.Add(this.eventRangeList);
            this.conditionsBox.Controls.Add(this.cbCollidingEvents);
            this.conditionsBox.Controls.Add(this.cbAtAngle);
            this.conditionsBox.Controls.Add(this.eventFacingList);
            this.conditionsBox.Controls.Add(this.eventDirectionList);
            this.conditionsBox.Controls.Add(this.rbIsColliding);
            this.conditionsBox.Controls.Add(this.label5);
            this.conditionsBox.Controls.Add(this.nudAtAngle2);
            this.conditionsBox.Controls.Add(this.nudAtAngle1);
            this.conditionsBox.Controls.Add(this.rbAtAngle);
            this.conditionsBox.Controls.Add(this.rbFacingEvent);
            this.conditionsBox.Controls.Add(this.rbInDirection);
            this.conditionsBox.Controls.Add(this.rbInRange);
            this.conditionsBox.Controls.Add(this.label25);
            this.conditionsBox.Controls.Add(this.nudRange);
            this.conditionsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.conditionsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.conditionsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.conditionsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.conditionsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.conditionsBox.Image = null;
            this.conditionsBox.IsCollapsed = false;
            this.conditionsBox.Location = new System.Drawing.Point(11, 91);
            this.conditionsBox.Name = "conditionsBox";
            this.conditionsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.conditionsBox.Size = new System.Drawing.Size(379, 170);
            this.conditionsBox.TabIndex = 86;
            this.conditionsBox.TabStop = false;
            this.conditionsBox.Text = "Conditions";
            // 
            // rbIsColliding
            // 
            this.rbIsColliding.AutoSize = true;
            this.rbIsColliding.BackColor = System.Drawing.Color.Transparent;
            this.rbIsColliding.Location = new System.Drawing.Point(7, 108);
            this.rbIsColliding.Name = "rbIsColliding";
            this.rbIsColliding.Size = new System.Drawing.Size(75, 17);
            this.rbIsColliding.TabIndex = 114;
            this.rbIsColliding.Text = "Is Colliding";
            this.rbIsColliding.UseVisualStyleBackColor = false;
            this.rbIsColliding.CheckedChanged += new System.EventHandler(this.rbIsColliding_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(306, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "~";
            // 
            // nudAtAngle2
            // 
            this.nudAtAngle2.Enabled = false;
            this.nudAtAngle2.Location = new System.Drawing.Point(326, 82);
            this.nudAtAngle2.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAtAngle2.Name = "nudAtAngle2";
            this.nudAtAngle2.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAtAngle2.OnChange = true;
            this.nudAtAngle2.Size = new System.Drawing.Size(46, 20);
            this.nudAtAngle2.TabIndex = 112;
            this.nudAtAngle2.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // nudAtAngle1
            // 
            this.nudAtAngle1.Enabled = false;
            this.nudAtAngle1.Location = new System.Drawing.Point(254, 82);
            this.nudAtAngle1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAtAngle1.Name = "nudAtAngle1";
            this.nudAtAngle1.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudAtAngle1.OnChange = false;
            this.nudAtAngle1.Size = new System.Drawing.Size(46, 20);
            this.nudAtAngle1.TabIndex = 111;
            // 
            // rbAtAngle
            // 
            this.rbAtAngle.AutoSize = true;
            this.rbAtAngle.BackColor = System.Drawing.Color.Transparent;
            this.rbAtAngle.Location = new System.Drawing.Point(7, 82);
            this.rbAtAngle.Name = "rbAtAngle";
            this.rbAtAngle.Size = new System.Drawing.Size(124, 17);
            this.rbAtAngle.TabIndex = 109;
            this.rbAtAngle.Text = "At an angle on event";
            this.rbAtAngle.UseVisualStyleBackColor = false;
            this.rbAtAngle.CheckedChanged += new System.EventHandler(this.rbAtAngle_CheckedChanged);
            // 
            // rbFacingEvent
            // 
            this.rbFacingEvent.AutoSize = true;
            this.rbFacingEvent.BackColor = System.Drawing.Color.Transparent;
            this.rbFacingEvent.Location = new System.Drawing.Point(7, 55);
            this.rbFacingEvent.Name = "rbFacingEvent";
            this.rbFacingEvent.Size = new System.Drawing.Size(87, 17);
            this.rbFacingEvent.TabIndex = 83;
            this.rbFacingEvent.Text = "Facing event";
            this.rbFacingEvent.UseVisualStyleBackColor = false;
            this.rbFacingEvent.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbInDirection
            // 
            this.rbInDirection.AutoSize = true;
            this.rbInDirection.BackColor = System.Drawing.Color.Transparent;
            this.rbInDirection.Location = new System.Drawing.Point(7, 28);
            this.rbInDirection.Name = "rbInDirection";
            this.rbInDirection.Size = new System.Drawing.Size(129, 17);
            this.rbInDirection.TabIndex = 77;
            this.rbInDirection.Text = "In direction with event";
            this.rbInDirection.UseVisualStyleBackColor = false;
            this.rbInDirection.CheckedChanged += new System.EventHandler(this.rbInDirection_CheckedChanged);
            // 
            // rbInRange
            // 
            this.rbInRange.AutoSize = true;
            this.rbInRange.BackColor = System.Drawing.Color.Transparent;
            this.rbInRange.Location = new System.Drawing.Point(7, 135);
            this.rbInRange.Name = "rbInRange";
            this.rbInRange.Size = new System.Drawing.Size(106, 17);
            this.rbInRange.TabIndex = 72;
            this.rbInRange.Text = "In range of event";
            this.rbInRange.UseVisualStyleBackColor = false;
            this.rbInRange.CheckedChanged += new System.EventHandler(this.rbInRange_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(254, 137);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 13);
            this.label25.TabIndex = 74;
            this.label25.Text = "Range";
            this.label25.Visible = false;
            // 
            // nudRange
            // 
            this.nudRange.Enabled = false;
            this.nudRange.Location = new System.Drawing.Point(301, 135);
            this.nudRange.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRange.Name = "nudRange";
            this.nudRange.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudRange.OnChange = false;
            this.nudRange.Size = new System.Drawing.Size(43, 20);
            this.nudRange.TabIndex = 73;
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.eventList);
            this.impactGroupBox1.Controls.Add(this.cbCompare);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(11, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(379, 73);
            this.impactGroupBox1.TabIndex = 85;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Event";
            // 
            // cbCompare
            // 
            this.cbCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompare.FormattingEnabled = true;
            this.cbCompare.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Not Equals"});
            this.cbCompare.Location = new System.Drawing.Point(142, 44);
            this.cbCompare.Name = "cbCompare";
            this.cbCompare.Size = new System.Drawing.Size(84, 21);
            this.cbCompare.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the event for the condition.";
            // 
            // eventList
            // 
            this.eventList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventList.FormattingEnabled = true;
            this.eventList.Location = new System.Drawing.Point(10, 44);
            this.eventList.Name = "eventList";
            this.eventList.ShowPlayer = true;
            this.eventList.ShowTarget = true;
            this.eventList.ShowTargets = false;
            this.eventList.Size = new System.Drawing.Size(126, 21);
            this.eventList.TabIndex = 95;
            this.eventList.ThisEvent = false;
            // 
            // eventDirectionList
            // 
            this.eventDirectionList.AllowCategories = true;
            this.eventDirectionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventDirectionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventDirectionList.FormattingEnabled = true;
            this.eventDirectionList.Location = new System.Drawing.Point(142, 27);
            this.eventDirectionList.Name = "eventDirectionList";
            this.eventDirectionList.SelectedNode = null;
            this.eventDirectionList.Size = new System.Drawing.Size(106, 21);
            this.eventDirectionList.TabIndex = 116;
            // 
            // eventFacingList
            // 
            this.eventFacingList.AllowCategories = true;
            this.eventFacingList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventFacingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventFacingList.FormattingEnabled = true;
            this.eventFacingList.Location = new System.Drawing.Point(142, 54);
            this.eventFacingList.Name = "eventFacingList";
            this.eventFacingList.SelectedNode = null;
            this.eventFacingList.Size = new System.Drawing.Size(106, 21);
            this.eventFacingList.TabIndex = 117;
            // 
            // cbAtAngle
            // 
            this.cbAtAngle.AllowCategories = true;
            this.cbAtAngle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAtAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtAngle.FormattingEnabled = true;
            this.cbAtAngle.Location = new System.Drawing.Point(142, 81);
            this.cbAtAngle.Name = "cbAtAngle";
            this.cbAtAngle.SelectedNode = null;
            this.cbAtAngle.Size = new System.Drawing.Size(106, 21);
            this.cbAtAngle.TabIndex = 118;
            // 
            // cbCollidingEvents
            // 
            this.cbCollidingEvents.AllowCategories = true;
            this.cbCollidingEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCollidingEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCollidingEvents.FormattingEnabled = true;
            this.cbCollidingEvents.Location = new System.Drawing.Point(142, 108);
            this.cbCollidingEvents.Name = "cbCollidingEvents";
            this.cbCollidingEvents.SelectedNode = null;
            this.cbCollidingEvents.Size = new System.Drawing.Size(106, 21);
            this.cbCollidingEvents.TabIndex = 119;
            // 
            // eventRangeList
            // 
            this.eventRangeList.AllowCategories = true;
            this.eventRangeList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventRangeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventRangeList.FormattingEnabled = true;
            this.eventRangeList.Location = new System.Drawing.Point(142, 134);
            this.eventRangeList.Name = "eventRangeList";
            this.eventRangeList.SelectedNode = null;
            this.eventRangeList.Size = new System.Drawing.Size(106, 21);
            this.eventRangeList.TabIndex = 120;
            // 
            // TEventConditionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(402, 323);
            this.Controls.Add(this.elseBranc);
            this.Controls.Add(this.conditionsBox);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TEventConditionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Template Event Condition";
            this.conditionsBox.ResumeLayout(false);
            this.conditionsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtAngle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Label label1;
        private CustomUpDown nudRange;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.RadioButton rbInRange;
        private System.Windows.Forms.RadioButton rbInDirection;
        private System.Windows.Forms.RadioButton rbFacingEvent;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox conditionsBox;
        private System.Windows.Forms.CheckBox elseBranc;
        private System.Windows.Forms.ComboBox cbCompare;
        private System.Windows.Forms.Label label5;
        private CustomUpDown nudAtAngle2;
        private CustomUpDown nudAtAngle1;
        private System.Windows.Forms.RadioButton rbAtAngle;
        private System.Windows.Forms.RadioButton rbIsColliding;
        private Controls.Game.MapEventComboBox eventList;
        private Controls.Game.EventComboBox eventRangeList;
        private Controls.Game.EventComboBox cbCollidingEvents;
        private Controls.Game.EventComboBox cbAtAngle;
        private Controls.Game.EventComboBox eventFacingList;
        private Controls.Game.EventComboBox eventDirectionList;
    }
}