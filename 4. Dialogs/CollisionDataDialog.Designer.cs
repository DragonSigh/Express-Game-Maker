namespace EGMGame.Controls.EventControls
{
    partial class CollisionDataDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollisionDataDialog));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudFriction = new EGMGame.CustomUpDown();
            this.nudMass = new EGMGame.CustomUpDown();
            this.nudBounce = new EGMGame.CustomUpDown();
            this.chkIsPlatform = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudFriction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Bounce";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Friction";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Mass";
            // 
            // nudFriction
            // 
            this.nudFriction.DecimalPlaces = 3;
            this.nudFriction.Location = new System.Drawing.Point(109, 38);
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
            this.nudFriction.ValueChanged += new System.EventHandler(this.nudFriction_ValueChanged);
            // 
            // nudMass
            // 
            this.nudMass.DecimalPlaces = 3;
            this.nudMass.Location = new System.Drawing.Point(109, 12);
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
            this.nudMass.ValueChanged += new System.EventHandler(this.nudMass_ValueChanged);
            // 
            // nudBounce
            // 
            this.nudBounce.DecimalPlaces = 3;
            this.nudBounce.Location = new System.Drawing.Point(109, 64);
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
            this.nudBounce.ValueChanged += new System.EventHandler(this.nudBounce_ValueChanged);
            // 
            // chkIsPlatform
            // 
            this.chkIsPlatform.AutoSize = true;
            this.chkIsPlatform.Location = new System.Drawing.Point(14, 95);
            this.chkIsPlatform.Name = "chkIsPlatform";
            this.chkIsPlatform.Size = new System.Drawing.Size(75, 17);
            this.chkIsPlatform.TabIndex = 40;
            this.chkIsPlatform.Text = "Is Platform";
            this.chkIsPlatform.UseVisualStyleBackColor = true;
            this.chkIsPlatform.CheckedChanged += new System.EventHandler(this.chkIsPlatform_CheckedChanged);
            // 
            // CollisionDataDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 125);
            this.Controls.Add(this.chkIsPlatform);
            this.Controls.Add(this.nudFriction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMass);
            this.Controls.Add(this.nudBounce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollisionDataDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CollisionDataDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudFriction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBounce)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUpDown nudMass;
        private CustomUpDown nudBounce;
        private CustomUpDown nudFriction;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsPlatform;
    }
}