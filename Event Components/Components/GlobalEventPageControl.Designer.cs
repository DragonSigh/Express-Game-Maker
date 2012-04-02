namespace EGMGame.Controls.EventControls
{
    partial class GlobalEventPageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.parellelProcessChk = new System.Windows.Forms.RadioButton();
            this.autoRunChk = new System.Windows.Forms.RadioButton();
            this.actionChk = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.variablChk = new System.Windows.Forms.CheckBox();
            this.variablesBtn = new System.Windows.Forms.Button();
            this.switchChk = new System.Windows.Forms.CheckBox();
            this.switchesBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.behaviorProgramListBox1 = new EGMGame.Controls.EventControls.BehaviorProgramListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox1.Controls.Add(this.parellelProcessChk);
            this.groupBox1.Controls.Add(this.autoRunChk);
            this.groupBox1.Controls.Add(this.actionChk);
            this.groupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(141, 106);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trigger Condition";
            // 
            // parellelProcessChk
            // 
            this.parellelProcessChk.AutoSize = true;
            this.parellelProcessChk.BackColor = System.Drawing.Color.Transparent;
            this.parellelProcessChk.Location = new System.Drawing.Point(11, 74);
            this.parellelProcessChk.Name = "parellelProcessChk";
            this.parellelProcessChk.Size = new System.Drawing.Size(124, 17);
            this.parellelProcessChk.TabIndex = 3;
            this.parellelProcessChk.TabStop = true;
            this.parellelProcessChk.Text = "Background Process";
            this.parellelProcessChk.UseVisualStyleBackColor = false;
            this.parellelProcessChk.Click += new System.EventHandler(this.parellelProcessChk_CheckedChanged);
            // 
            // autoRunChk
            // 
            this.autoRunChk.AutoSize = true;
            this.autoRunChk.BackColor = System.Drawing.Color.Transparent;
            this.autoRunChk.Location = new System.Drawing.Point(11, 51);
            this.autoRunChk.Name = "autoRunChk";
            this.autoRunChk.Size = new System.Drawing.Size(89, 17);
            this.autoRunChk.TabIndex = 2;
            this.autoRunChk.TabStop = true;
            this.autoRunChk.Text = "Autorun Loop";
            this.autoRunChk.UseVisualStyleBackColor = false;
            this.autoRunChk.Click += new System.EventHandler(this.autoRunChk_CheckedChanged);
            // 
            // actionChk
            // 
            this.actionChk.AutoSize = true;
            this.actionChk.BackColor = System.Drawing.Color.Transparent;
            this.actionChk.Checked = true;
            this.actionChk.Location = new System.Drawing.Point(11, 28);
            this.actionChk.Name = "actionChk";
            this.actionChk.Size = new System.Drawing.Size(71, 17);
            this.actionChk.TabIndex = 1;
            this.actionChk.TabStop = true;
            this.actionChk.Text = "On Called";
            this.actionChk.UseVisualStyleBackColor = false;
            this.actionChk.CheckedChanged += new System.EventHandler(this.actionChk_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox4.Controls.Add(this.variablChk);
            this.groupBox4.Controls.Add(this.variablesBtn);
            this.groupBox4.Controls.Add(this.switchChk);
            this.groupBox4.Controls.Add(this.switchesBtn);
            this.groupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(141, 93);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Activation Conditions";
            // 
            // variablChk
            // 
            this.variablChk.AutoSize = true;
            this.variablChk.BackColor = System.Drawing.Color.Transparent;
            this.variablChk.Location = new System.Drawing.Point(11, 64);
            this.variablChk.Name = "variablChk";
            this.variablChk.Size = new System.Drawing.Size(15, 14);
            this.variablChk.TabIndex = 5;
            this.variablChk.UseVisualStyleBackColor = false;
            this.variablChk.CheckedChanged += new System.EventHandler(this.variablChk_CheckedChanged);
            // 
            // variablesBtn
            // 
            this.variablesBtn.Enabled = false;
            this.variablesBtn.Location = new System.Drawing.Point(32, 58);
            this.variablesBtn.Name = "variablesBtn";
            this.variablesBtn.Size = new System.Drawing.Size(103, 27);
            this.variablesBtn.TabIndex = 4;
            this.variablesBtn.Text = "Variables";
            this.variablesBtn.UseVisualStyleBackColor = true;
            this.variablesBtn.Click += new System.EventHandler(this.variablesBtn_Click);
            // 
            // switchChk
            // 
            this.switchChk.AutoSize = true;
            this.switchChk.BackColor = System.Drawing.Color.Transparent;
            this.switchChk.Location = new System.Drawing.Point(11, 32);
            this.switchChk.Name = "switchChk";
            this.switchChk.Size = new System.Drawing.Size(15, 14);
            this.switchChk.TabIndex = 1;
            this.switchChk.UseVisualStyleBackColor = false;
            this.switchChk.CheckedChanged += new System.EventHandler(this.switchChk_CheckedChanged);
            // 
            // switchesBtn
            // 
            this.switchesBtn.Enabled = false;
            this.switchesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.switchesBtn.Location = new System.Drawing.Point(32, 25);
            this.switchesBtn.Name = "switchesBtn";
            this.switchesBtn.Size = new System.Drawing.Size(103, 27);
            this.switchesBtn.TabIndex = 1;
            this.switchesBtn.Text = "Switches";
            this.switchesBtn.UseVisualStyleBackColor = false;
            this.switchesBtn.Click += new System.EventHandler(this.switchesBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox5.Controls.Add(this.behaviorProgramListBox1);
            this.groupBox5.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox5.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox5.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox5.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox5.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox5.Location = new System.Drawing.Point(147, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(521, 502);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Program";
            // 
            // behaviorProgramListBox1
            // 
            this.behaviorProgramListBox1.BackColor = System.Drawing.Color.White;
            this.behaviorProgramListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.behaviorProgramListBox1.Location = new System.Drawing.Point(4, 25);
            this.behaviorProgramListBox1.Name = "behaviorProgramListBox1";
            this.behaviorProgramListBox1.SelectedAction = null;
            this.behaviorProgramListBox1.SelectedEvent = null;
            this.behaviorProgramListBox1.SelectedPage = null;
            this.behaviorProgramListBox1.Size = new System.Drawing.Size(513, 472);
            this.behaviorProgramListBox1.TabIndex = 0;
            // 
            // GlobalEventPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Name = "GlobalEventPageControl";
            this.Size = new System.Drawing.Size(668, 508);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox5;
        private BehaviorProgramListBox behaviorProgramListBox1;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox4;
        private System.Windows.Forms.CheckBox variablChk;
        private System.Windows.Forms.Button variablesBtn;
        private System.Windows.Forms.CheckBox switchChk;
        private System.Windows.Forms.Button switchesBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private System.Windows.Forms.RadioButton parellelProcessChk;
        private System.Windows.Forms.RadioButton autoRunChk;
        private System.Windows.Forms.RadioButton actionChk;

    }
}
