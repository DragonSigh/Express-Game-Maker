namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs
{
    partial class ChangeMagicDialog
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
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbSkills = new EGMGame.Controls.Game.SkillsComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbHero = new EGMGame.Controls.Game.HeroComboBox(this.components);
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.cbSkills);
            this.impactGroupBox2.Controls.Add(this.label2);
            this.impactGroupBox2.Controls.Add(this.label1);
            this.impactGroupBox2.Controls.Add(this.cbType);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 79);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(156, 117);
            this.impactGroupBox2.TabIndex = 35;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Magic";
            // 
            // cbSkills
            // 
            this.cbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Location = new System.Drawing.Point(7, 82);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Noneable = false;
            this.cbSkills.SelectedNode = null;
            this.cbSkills.Size = new System.Drawing.Size(131, 21);
            this.cbSkills.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose the magic.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the operation type.";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Learn",
            "Forget"});
            this.cbType.Location = new System.Drawing.Point(7, 42);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(112, 21);
            this.cbType.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 202);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 37;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okBtn.Location = new System.Drawing.Point(12, 202);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 36;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.cbHero);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 61);
            this.impactGroupBox1.TabIndex = 34;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Hero";
            // 
            // cbHero
            // 
            this.cbHero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHero.FormattingEnabled = true;
            this.cbHero.Location = new System.Drawing.Point(7, 28);
            this.cbHero.Name = "cbHero";
            this.cbHero.Noneable = false;
            this.cbHero.SelectedNode = null;
            this.cbHero.Size = new System.Drawing.Size(142, 21);
            this.cbHero.TabIndex = 0;
            // 
            // ChangeMagicDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(182, 240);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeMagicDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Magic";
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private EGMGame.Controls.Game.SkillsComboBox cbSkills;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private EGMGame.Controls.Game.HeroComboBox cbHero;
    }
}