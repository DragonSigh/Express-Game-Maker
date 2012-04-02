namespace EGMGame
{
    partial class PlayerCommandDialog
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
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCommands = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panelPartyIndex = new System.Windows.Forms.Panel();
            this.nudPartyIndex = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeroes = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbHeroes = new EGMGame.Controls.Game.HeroComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.impactGroupBox1.SuspendLayout();
            this.panelPartyIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartyIndex)).BeginInit();
            this.panelHeroes.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(93, 197);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 197);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.label4);
            this.impactGroupBox1.Controls.Add(this.cbCommands);
            this.impactGroupBox1.Controls.Add(this.cbType);
            this.impactGroupBox1.Controls.Add(this.panelPartyIndex);
            this.impactGroupBox1.Controls.Add(this.panelHeroes);
            this.impactGroupBox1.Controls.Add(this.label1);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(156, 179);
            this.impactGroupBox1.TabIndex = 0;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Select the command.";
            // 
            // cbCommands
            // 
            this.cbCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommands.FormattingEnabled = true;
            this.cbCommands.Items.AddRange(new object[] {
            "Attack",
            "Defend"});
            this.cbCommands.Location = new System.Drawing.Point(10, 144);
            this.cbCommands.Name = "cbCommands";
            this.cbCommands.Size = new System.Drawing.Size(115, 21);
            this.cbCommands.TabIndex = 5;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "By Party Index",
            "By Hero",
            "By Variable"});
            this.cbType.Location = new System.Drawing.Point(10, 41);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(115, 21);
            this.cbType.TabIndex = 4;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // panelPartyIndex
            // 
            this.panelPartyIndex.BackColor = System.Drawing.Color.Transparent;
            this.panelPartyIndex.Controls.Add(this.nudPartyIndex);
            this.panelPartyIndex.Controls.Add(this.label2);
            this.panelPartyIndex.Location = new System.Drawing.Point(10, 68);
            this.panelPartyIndex.Name = "panelPartyIndex";
            this.panelPartyIndex.Size = new System.Drawing.Size(124, 57);
            this.panelPartyIndex.TabIndex = 3;
            this.panelPartyIndex.Visible = false;
            // 
            // nudPartyIndex
            // 
            this.nudPartyIndex.Location = new System.Drawing.Point(6, 24);
            this.nudPartyIndex.Name = "nudPartyIndex";
            this.nudPartyIndex.Size = new System.Drawing.Size(64, 20);
            this.nudPartyIndex.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select the party index.";
            // 
            // panelHeroes
            // 
            this.panelHeroes.BackColor = System.Drawing.Color.Transparent;
            this.panelHeroes.Controls.Add(this.label3);
            this.panelHeroes.Controls.Add(this.cbHeroes);
            this.panelHeroes.Location = new System.Drawing.Point(10, 68);
            this.panelHeroes.Name = "panelHeroes";
            this.panelHeroes.Size = new System.Drawing.Size(126, 57);
            this.panelHeroes.TabIndex = 2;
            this.panelHeroes.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(2, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select the hero.";
            // 
            // cbHeroes
            // 
            this.cbHeroes.AllowCategories = true;
            this.cbHeroes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHeroes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeroes.FormattingEnabled = true;
            this.cbHeroes.Location = new System.Drawing.Point(3, 24);
            this.cbHeroes.Name = "cbHeroes";
            this.cbHeroes.Noneable = true;
            this.cbHeroes.SelectedNode = null;
            this.cbHeroes.Size = new System.Drawing.Size(121, 21);
            this.cbHeroes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select who to command.";
            // 
            // PlayerCommandDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(177, 229);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerCommandDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Command Ally";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox1.PerformLayout();
            this.panelPartyIndex.ResumeLayout(false);
            this.panelPartyIndex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartyIndex)).EndInit();
            this.panelHeroes.ResumeLayout(false);
            this.panelHeroes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private EGMGame.Controls.Game.HeroComboBox cbHeroes;
        private System.Windows.Forms.Panel panelPartyIndex;
        private System.Windows.Forms.NumericUpDown nudPartyIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHeroes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbCommands;
        private System.Windows.Forms.Label label4;
    }
}