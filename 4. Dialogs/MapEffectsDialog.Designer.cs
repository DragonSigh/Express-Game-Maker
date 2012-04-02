namespace EGMGame.Dialogs
{
    partial class MapEffectsDialog
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
            this.chkBGM = new System.Windows.Forms.CheckBox();
            this.chkBGS = new System.Windows.Forms.CheckBox();
            this.chkTint = new System.Windows.Forms.CheckBox();
            this.chkFog = new System.Windows.Forms.CheckBox();
            this.btnEditFog = new System.Windows.Forms.Button();
            this.playAudioBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tintScreenBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkBGM
            // 
            this.chkBGM.AutoSize = true;
            this.chkBGM.BackColor = System.Drawing.Color.Transparent;
            this.chkBGM.Location = new System.Drawing.Point(12, 22);
            this.chkBGM.Name = "chkBGM";
            this.chkBGM.Size = new System.Drawing.Size(115, 17);
            this.chkBGM.TabIndex = 0;
            this.chkBGM.Text = "Background Music";
            this.chkBGM.UseVisualStyleBackColor = false;
            this.chkBGM.CheckedChanged += new System.EventHandler(this.chkBGM_CheckedChanged);
            // 
            // chkBGS
            // 
            this.chkBGS.AutoSize = true;
            this.chkBGS.BackColor = System.Drawing.Color.Transparent;
            this.chkBGS.Location = new System.Drawing.Point(12, 62);
            this.chkBGS.Name = "chkBGS";
            this.chkBGS.Size = new System.Drawing.Size(118, 17);
            this.chkBGS.TabIndex = 1;
            this.chkBGS.Text = "Background Sound";
            this.chkBGS.UseVisualStyleBackColor = false;
            this.chkBGS.CheckedChanged += new System.EventHandler(this.chkBGS_CheckedChanged);
            // 
            // chkTint
            // 
            this.chkTint.AutoSize = true;
            this.chkTint.BackColor = System.Drawing.Color.Transparent;
            this.chkTint.Location = new System.Drawing.Point(12, 100);
            this.chkTint.Name = "chkTint";
            this.chkTint.Size = new System.Drawing.Size(44, 17);
            this.chkTint.TabIndex = 2;
            this.chkTint.Text = "Tint";
            this.chkTint.UseVisualStyleBackColor = false;
            this.chkTint.CheckedChanged += new System.EventHandler(this.chkTint_CheckedChanged);
            // 
            // chkFog
            // 
            this.chkFog.AutoSize = true;
            this.chkFog.BackColor = System.Drawing.Color.Transparent;
            this.chkFog.Location = new System.Drawing.Point(12, 140);
            this.chkFog.Name = "chkFog";
            this.chkFog.Size = new System.Drawing.Size(44, 17);
            this.chkFog.TabIndex = 3;
            this.chkFog.Text = "Fog";
            this.chkFog.UseVisualStyleBackColor = false;
            this.chkFog.CheckedChanged += new System.EventHandler(this.chkFog_CheckedChanged);
            // 
            // btnEditFog
            // 
            this.btnEditFog.Enabled = false;
            this.btnEditFog.Image = global::EGMGame.Properties.Resources.weather_clouds;
            this.btnEditFog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditFog.Location = new System.Drawing.Point(133, 130);
            this.btnEditFog.Name = "btnEditFog";
            this.btnEditFog.Size = new System.Drawing.Size(136, 34);
            this.btnEditFog.TabIndex = 55;
            this.btnEditFog.Text = "Edit Fog";
            this.btnEditFog.UseVisualStyleBackColor = true;
            this.btnEditFog.Click += new System.EventHandler(this.btnEditFog_Click);
            // 
            // playAudioBtn
            // 
            this.playAudioBtn.Enabled = false;
            this.playAudioBtn.Image = global::EGMGame.Properties.Resources.music_beam_16;
            this.playAudioBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playAudioBtn.Location = new System.Drawing.Point(133, 12);
            this.playAudioBtn.Name = "playAudioBtn";
            this.playAudioBtn.Size = new System.Drawing.Size(136, 34);
            this.playAudioBtn.TabIndex = 56;
            this.playAudioBtn.Text = "Play Audio";
            this.playAudioBtn.UseVisualStyleBackColor = true;
            this.playAudioBtn.Click += new System.EventHandler(this.playAudioBtn_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::EGMGame.Properties.Resources.music_beam_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(133, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 34);
            this.button1.TabIndex = 57;
            this.button1.Text = "Play Audio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tintScreenBtn
            // 
            this.tintScreenBtn.Enabled = false;
            this.tintScreenBtn.Image = global::EGMGame.Properties.Resources.weather_clouds;
            this.tintScreenBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tintScreenBtn.Location = new System.Drawing.Point(133, 90);
            this.tintScreenBtn.Name = "tintScreenBtn";
            this.tintScreenBtn.Size = new System.Drawing.Size(136, 34);
            this.tintScreenBtn.TabIndex = 58;
            this.tintScreenBtn.Text = "Tint Screen";
            this.tintScreenBtn.UseVisualStyleBackColor = true;
            this.tintScreenBtn.Click += new System.EventHandler(this.tintScreenBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(197, 174);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 60;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(116, 174);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 59;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // MapEffectsDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(284, 209);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.tintScreenBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playAudioBtn);
            this.Controls.Add(this.btnEditFog);
            this.Controls.Add(this.chkFog);
            this.Controls.Add(this.chkTint);
            this.Controls.Add(this.chkBGS);
            this.Controls.Add(this.chkBGM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MapEffectsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map Effects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBGM;
        private System.Windows.Forms.CheckBox chkBGS;
        private System.Windows.Forms.CheckBox chkTint;
        private System.Windows.Forms.CheckBox chkFog;
        private System.Windows.Forms.Button btnEditFog;
        private System.Windows.Forms.Button playAudioBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button tintScreenBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}