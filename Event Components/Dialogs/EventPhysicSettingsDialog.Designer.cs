namespace EGMGame.Controls.EventControls
{
    partial class EventPhysicSettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventPhysicSettingsDialog));
            this.chkVelocity = new System.Windows.Forms.CheckBox();
            this.chkMass = new System.Windows.Forms.CheckBox();
            this.chkForce = new System.Windows.Forms.CheckBox();
            this.chkLinearDrag = new System.Windows.Forms.CheckBox();
            this.chkRotationalDrag = new System.Windows.Forms.CheckBox();
            this.chkBounce = new System.Windows.Forms.CheckBox();
            this.chkFriction = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkIgnoreGravity = new System.Windows.Forms.CheckBox();
            this.chkMOI = new System.Windows.Forms.CheckBox();
            this.chkIsFixedRotatio = new System.Windows.Forms.CheckBox();
            this.chkCustomGravity = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbQuick = new System.Windows.Forms.ComboBox();
            this.btnEditQuickset = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudGravityY = new EGMGame.CustomUpDown();
            this.nudGravityX = new EGMGame.CustomUpDown();
            this.nudMOI = new EGMGame.CustomUpDown();
            this.nudForce = new EGMGame.CustomUpDown();
            this.nudMass = new EGMGame.CustomUpDown();
            this.nudDrag = new EGMGame.CustomUpDown();
            this.nudRotDrag = new EGMGame.CustomUpDown();
            this.nudVelocityX = new EGMGame.CustomUpDown();
            this.nudBounce = new EGMGame.CustomUpDown();
            this.nudFriction = new EGMGame.CustomUpDown();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMOI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotDrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocityX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFriction)).BeginInit();
            this.SuspendLayout();
            // 
            // chkVelocity
            // 
            this.chkVelocity.AutoSize = true;
            this.chkVelocity.BackColor = System.Drawing.Color.Transparent;
            this.chkVelocity.Location = new System.Drawing.Point(3, 55);
            this.chkVelocity.Name = "chkVelocity";
            this.chkVelocity.Size = new System.Drawing.Size(62, 17);
            this.chkVelocity.TabIndex = 28;
            this.chkVelocity.Text = "Impulse";
            this.toolTip.SetToolTip(this.chkVelocity, "The default impulse applied when this event is told to move\r\nby the player or pro" +
        "gram dynamics. Impulse must be selected\r\nas the force type for impulse to be use" +
        "d.");
            this.chkVelocity.UseVisualStyleBackColor = false;
            this.chkVelocity.CheckedChanged += new System.EventHandler(this.chkVelocity_CheckedChanged);
            // 
            // chkMass
            // 
            this.chkMass.AutoSize = true;
            this.chkMass.BackColor = System.Drawing.Color.Transparent;
            this.chkMass.Location = new System.Drawing.Point(3, 3);
            this.chkMass.Name = "chkMass";
            this.chkMass.Size = new System.Drawing.Size(51, 17);
            this.chkMass.TabIndex = 29;
            this.chkMass.Text = "Mass";
            this.toolTip.SetToolTip(this.chkMass, "The mass of the event. Makes the event heavier.");
            this.chkMass.UseVisualStyleBackColor = false;
            this.chkMass.CheckedChanged += new System.EventHandler(this.chkMass_CheckedChanged);
            // 
            // chkForce
            // 
            this.chkForce.AutoSize = true;
            this.chkForce.BackColor = System.Drawing.Color.Transparent;
            this.chkForce.Location = new System.Drawing.Point(3, 29);
            this.chkForce.Name = "chkForce";
            this.chkForce.Size = new System.Drawing.Size(53, 17);
            this.chkForce.TabIndex = 30;
            this.chkForce.Text = "Force";
            this.toolTip.SetToolTip(this.chkForce, "The default force applied when this event is told to move\r\nby the player or progr" +
        "am dynamics.");
            this.chkForce.UseVisualStyleBackColor = false;
            this.chkForce.CheckedChanged += new System.EventHandler(this.chkForce_CheckedChanged);
            // 
            // chkLinearDrag
            // 
            this.chkLinearDrag.AutoSize = true;
            this.chkLinearDrag.BackColor = System.Drawing.Color.Transparent;
            this.chkLinearDrag.Location = new System.Drawing.Point(3, 81);
            this.chkLinearDrag.Name = "chkLinearDrag";
            this.chkLinearDrag.Size = new System.Drawing.Size(81, 17);
            this.chkLinearDrag.TabIndex = 31;
            this.chkLinearDrag.Text = "Linear Drag";
            this.toolTip.SetToolTip(this.chkLinearDrag, "Linear drag is a negative force on to this event. It will\r\nmake the event move sl" +
        "ower.");
            this.chkLinearDrag.UseVisualStyleBackColor = false;
            this.chkLinearDrag.CheckedChanged += new System.EventHandler(this.chkLinearDrag_CheckedChanged);
            // 
            // chkRotationalDrag
            // 
            this.chkRotationalDrag.AutoSize = true;
            this.chkRotationalDrag.BackColor = System.Drawing.Color.Transparent;
            this.chkRotationalDrag.Location = new System.Drawing.Point(3, 107);
            this.chkRotationalDrag.Name = "chkRotationalDrag";
            this.chkRotationalDrag.Size = new System.Drawing.Size(100, 17);
            this.chkRotationalDrag.TabIndex = 32;
            this.chkRotationalDrag.Text = "Rotational Drag";
            this.toolTip.SetToolTip(this.chkRotationalDrag, "Rotational drag is a negative force on to this event. It will\r\nmake the event rot" +
        "ate slower.");
            this.chkRotationalDrag.UseVisualStyleBackColor = false;
            this.chkRotationalDrag.CheckedChanged += new System.EventHandler(this.chkRotationalDrag_CheckedChanged);
            // 
            // chkBounce
            // 
            this.chkBounce.AutoSize = true;
            this.chkBounce.BackColor = System.Drawing.Color.Transparent;
            this.chkBounce.Location = new System.Drawing.Point(3, 159);
            this.chkBounce.Name = "chkBounce";
            this.chkBounce.Size = new System.Drawing.Size(63, 17);
            this.chkBounce.TabIndex = 33;
            this.chkBounce.Text = "Bounce";
            this.toolTip.SetToolTip(this.chkBounce, "The bounciness of this event when it collides. ");
            this.chkBounce.UseVisualStyleBackColor = false;
            this.chkBounce.CheckedChanged += new System.EventHandler(this.chkBounce_CheckedChanged);
            // 
            // chkFriction
            // 
            this.chkFriction.AutoSize = true;
            this.chkFriction.BackColor = System.Drawing.Color.Transparent;
            this.chkFriction.Location = new System.Drawing.Point(3, 133);
            this.chkFriction.Name = "chkFriction";
            this.chkFriction.Size = new System.Drawing.Size(60, 17);
            this.chkFriction.TabIndex = 34;
            this.chkFriction.Text = "Friction";
            this.toolTip.SetToolTip(this.chkFriction, "Friction is a resistance encountered when one body is moved in contact with anoth" +
        "er.\r\nThe other body must contain a friction value as well. ");
            this.chkFriction.UseVisualStyleBackColor = false;
            this.chkFriction.CheckedChanged += new System.EventHandler(this.chkFriction_CheckedChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(122, 400);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 39;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(41, 400);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 38;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Check to overwrite default values.";
            // 
            // chkIgnoreGravity
            // 
            this.chkIgnoreGravity.AutoSize = true;
            this.chkIgnoreGravity.BackColor = System.Drawing.Color.Transparent;
            this.chkIgnoreGravity.Location = new System.Drawing.Point(3, 286);
            this.chkIgnoreGravity.Name = "chkIgnoreGravity";
            this.chkIgnoreGravity.Size = new System.Drawing.Size(92, 17);
            this.chkIgnoreGravity.TabIndex = 38;
            this.chkIgnoreGravity.Text = "Ignore Gravity";
            this.toolTip.SetToolTip(this.chkIgnoreGravity, "The bounciness of this event when it collides. ");
            this.chkIgnoreGravity.UseVisualStyleBackColor = false;
            // 
            // chkMOI
            // 
            this.chkMOI.AutoSize = true;
            this.chkMOI.BackColor = System.Drawing.Color.Transparent;
            this.chkMOI.Location = new System.Drawing.Point(3, 185);
            this.chkMOI.Name = "chkMOI";
            this.chkMOI.Size = new System.Drawing.Size(110, 17);
            this.chkMOI.TabIndex = 39;
            this.chkMOI.Text = "Moment Of Inertia";
            this.toolTip.SetToolTip(this.chkMOI, "The bounciness of this event when it collides. ");
            this.chkMOI.UseVisualStyleBackColor = false;
            this.chkMOI.CheckedChanged += new System.EventHandler(this.chkMOI_CheckedChanged);
            // 
            // chkIsFixedRotatio
            // 
            this.chkIsFixedRotatio.AutoSize = true;
            this.chkIsFixedRotatio.BackColor = System.Drawing.Color.Transparent;
            this.chkIsFixedRotatio.Location = new System.Drawing.Point(3, 309);
            this.chkIsFixedRotatio.Name = "chkIsFixedRotatio";
            this.chkIsFixedRotatio.Size = new System.Drawing.Size(105, 17);
            this.chkIsFixedRotatio.TabIndex = 41;
            this.chkIsFixedRotatio.Text = "Is Fixed Rotation";
            this.toolTip.SetToolTip(this.chkIsFixedRotatio, "The bounciness of this event when it collides. ");
            this.chkIsFixedRotatio.UseVisualStyleBackColor = false;
            // 
            // chkCustomGravity
            // 
            this.chkCustomGravity.AutoSize = true;
            this.chkCustomGravity.BackColor = System.Drawing.Color.Transparent;
            this.chkCustomGravity.Location = new System.Drawing.Point(3, 211);
            this.chkCustomGravity.Name = "chkCustomGravity";
            this.chkCustomGravity.Size = new System.Drawing.Size(97, 17);
            this.chkCustomGravity.TabIndex = 42;
            this.chkCustomGravity.Text = "Custom Gravity";
            this.toolTip.SetToolTip(this.chkCustomGravity, "The bounciness of this event when it collides. ");
            this.chkCustomGravity.UseVisualStyleBackColor = false;
            this.chkCustomGravity.CheckedChanged += new System.EventHandler(this.chkCustomGravity_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Quick";
            // 
            // cbQuick
            // 
            this.cbQuick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuick.FormattingEnabled = true;
            this.cbQuick.Location = new System.Drawing.Point(48, 30);
            this.cbQuick.Name = "cbQuick";
            this.cbQuick.Size = new System.Drawing.Size(127, 21);
            this.cbQuick.TabIndex = 42;
            this.cbQuick.SelectedIndexChanged += new System.EventHandler(this.cbQuick_SelectedIndexChanged);
            // 
            // btnEditQuickset
            // 
            this.btnEditQuickset.Image = global::EGMGame.Properties.Resources.cog;
            this.btnEditQuickset.Location = new System.Drawing.Point(181, 28);
            this.btnEditQuickset.Name = "btnEditQuickset";
            this.btnEditQuickset.Size = new System.Drawing.Size(29, 23);
            this.btnEditQuickset.TabIndex = 43;
            this.btnEditQuickset.UseVisualStyleBackColor = true;
            this.btnEditQuickset.Click += new System.EventHandler(this.btnEditQuickset_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.nudGravityY);
            this.panelSettings.Controls.Add(this.nudGravityX);
            this.panelSettings.Controls.Add(this.chkCustomGravity);
            this.panelSettings.Controls.Add(this.chkIsFixedRotatio);
            this.panelSettings.Controls.Add(this.nudMOI);
            this.panelSettings.Controls.Add(this.chkMOI);
            this.panelSettings.Controls.Add(this.chkIgnoreGravity);
            this.panelSettings.Controls.Add(this.chkMass);
            this.panelSettings.Controls.Add(this.nudForce);
            this.panelSettings.Controls.Add(this.nudMass);
            this.panelSettings.Controls.Add(this.nudDrag);
            this.panelSettings.Controls.Add(this.nudRotDrag);
            this.panelSettings.Controls.Add(this.chkVelocity);
            this.panelSettings.Controls.Add(this.chkForce);
            this.panelSettings.Controls.Add(this.nudVelocityX);
            this.panelSettings.Controls.Add(this.chkLinearDrag);
            this.panelSettings.Controls.Add(this.nudBounce);
            this.panelSettings.Controls.Add(this.chkRotationalDrag);
            this.panelSettings.Controls.Add(this.nudFriction);
            this.panelSettings.Controls.Add(this.chkBounce);
            this.panelSettings.Controls.Add(this.chkFriction);
            this.panelSettings.Location = new System.Drawing.Point(10, 57);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(187, 337);
            this.panelSettings.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Vertical Gravity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Horizontal Gravity";
            // 
            // nudGravityY
            // 
            this.nudGravityY.DecimalPlaces = 3;
            this.nudGravityY.Enabled = false;
            this.nudGravityY.Location = new System.Drawing.Point(116, 257);
            this.nudGravityY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudGravityY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudGravityY.Name = "nudGravityY";
            this.nudGravityY.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudGravityY.OnChange = false;
            this.nudGravityY.Size = new System.Drawing.Size(63, 20);
            this.nudGravityY.TabIndex = 79;
            // 
            // nudGravityX
            // 
            this.nudGravityX.DecimalPlaces = 3;
            this.nudGravityX.Enabled = false;
            this.nudGravityX.Location = new System.Drawing.Point(116, 231);
            this.nudGravityX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudGravityX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudGravityX.Name = "nudGravityX";
            this.nudGravityX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudGravityX.OnChange = false;
            this.nudGravityX.Size = new System.Drawing.Size(63, 20);
            this.nudGravityX.TabIndex = 78;
            // 
            // nudMOI
            // 
            this.nudMOI.DecimalPlaces = 3;
            this.nudMOI.Enabled = false;
            this.nudMOI.Location = new System.Drawing.Point(116, 184);
            this.nudMOI.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMOI.Name = "nudMOI";
            this.nudMOI.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMOI.OnChange = false;
            this.nudMOI.Size = new System.Drawing.Size(63, 20);
            this.nudMOI.TabIndex = 40;
            // 
            // nudForce
            // 
            this.nudForce.DecimalPlaces = 3;
            this.nudForce.Enabled = false;
            this.nudForce.Location = new System.Drawing.Point(116, 28);
            this.nudForce.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudForce.Name = "nudForce";
            this.nudForce.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudForce.OnChange = false;
            this.nudForce.Size = new System.Drawing.Size(63, 20);
            this.nudForce.TabIndex = 16;
            // 
            // nudMass
            // 
            this.nudMass.DecimalPlaces = 3;
            this.nudMass.Enabled = false;
            this.nudMass.Location = new System.Drawing.Point(116, 2);
            this.nudMass.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudMass.Name = "nudMass";
            this.nudMass.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMass.OnChange = true;
            this.nudMass.Size = new System.Drawing.Size(63, 20);
            this.nudMass.TabIndex = 19;
            this.nudMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // nudDrag
            // 
            this.nudDrag.DecimalPlaces = 3;
            this.nudDrag.Enabled = false;
            this.nudDrag.Location = new System.Drawing.Point(116, 80);
            this.nudDrag.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDrag.Name = "nudDrag";
            this.nudDrag.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDrag.OnChange = false;
            this.nudDrag.Size = new System.Drawing.Size(63, 20);
            this.nudDrag.TabIndex = 23;
            // 
            // nudRotDrag
            // 
            this.nudRotDrag.DecimalPlaces = 3;
            this.nudRotDrag.Enabled = false;
            this.nudRotDrag.Location = new System.Drawing.Point(116, 106);
            this.nudRotDrag.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRotDrag.Name = "nudRotDrag";
            this.nudRotDrag.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRotDrag.OnChange = false;
            this.nudRotDrag.Size = new System.Drawing.Size(63, 20);
            this.nudRotDrag.TabIndex = 25;
            // 
            // nudVelocityX
            // 
            this.nudVelocityX.DecimalPlaces = 3;
            this.nudVelocityX.Enabled = false;
            this.nudVelocityX.Location = new System.Drawing.Point(116, 54);
            this.nudVelocityX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudVelocityX.Name = "nudVelocityX";
            this.nudVelocityX.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudVelocityX.OnChange = false;
            this.nudVelocityX.Size = new System.Drawing.Size(63, 20);
            this.nudVelocityX.TabIndex = 37;
            // 
            // nudBounce
            // 
            this.nudBounce.DecimalPlaces = 3;
            this.nudBounce.Enabled = false;
            this.nudBounce.Location = new System.Drawing.Point(116, 158);
            this.nudBounce.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudBounce.Name = "nudBounce";
            this.nudBounce.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBounce.OnChange = false;
            this.nudBounce.Size = new System.Drawing.Size(63, 20);
            this.nudBounce.TabIndex = 36;
            // 
            // nudFriction
            // 
            this.nudFriction.DecimalPlaces = 3;
            this.nudFriction.Enabled = false;
            this.nudFriction.Location = new System.Drawing.Point(116, 132);
            this.nudFriction.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudFriction.Name = "nudFriction";
            this.nudFriction.OldValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFriction.OnChange = false;
            this.nudFriction.Size = new System.Drawing.Size(63, 20);
            this.nudFriction.TabIndex = 35;
            // 
            // EventPhysicSettingsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(222, 435);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.btnEditQuickset);
            this.Controls.Add(this.cbQuick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventPhysicSettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physics";
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGravityX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMOI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotDrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocityX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFriction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUpDown nudRotDrag;
        private CustomUpDown nudDrag;
        private CustomUpDown nudMass;
        private CustomUpDown nudForce;
        private System.Windows.Forms.CheckBox chkVelocity;
        private System.Windows.Forms.CheckBox chkMass;
        private System.Windows.Forms.CheckBox chkForce;
        private System.Windows.Forms.CheckBox chkLinearDrag;
        private System.Windows.Forms.CheckBox chkRotationalDrag;
        private System.Windows.Forms.CheckBox chkBounce;
        private System.Windows.Forms.CheckBox chkFriction;
        private CustomUpDown nudBounce;
        private CustomUpDown nudFriction;
        private CustomUpDown nudVelocityX;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbQuick;
        private System.Windows.Forms.Button btnEditQuickset;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox chkIgnoreGravity;
        private CustomUpDown nudMOI;
        private System.Windows.Forms.CheckBox chkMOI;
        private System.Windows.Forms.CheckBox chkIsFixedRotatio;
        private System.Windows.Forms.CheckBox chkCustomGravity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CustomUpDown nudGravityY;
        private CustomUpDown nudGravityX;
    }
}