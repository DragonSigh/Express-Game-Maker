namespace EGMGame
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.lblVersionText = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblLoadingMessage = new System.Windows.Forms.Label();
            this.updateCheckWorker = new System.ComponentModel.BackgroundWorker();
            this.UPDATERupdateCheckWorker = new System.ComponentModel.BackgroundWorker();
            this.UPDATERdownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.UPDATERupdateWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblVersionText
            // 
            this.lblVersionText.AutoSize = true;
            this.lblVersionText.BackColor = System.Drawing.Color.Transparent;
            this.lblVersionText.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblVersionText.ForeColor = System.Drawing.Color.White;
            this.lblVersionText.Location = new System.Drawing.Point(225, 72);
            this.lblVersionText.Name = "lblVersionText";
            this.lblVersionText.Size = new System.Drawing.Size(42, 16);
            this.lblVersionText.TabIndex = 5;
            this.lblVersionText.Text = "v1.0.0";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(64, 230);
            this.pbProgress.MarqueeAnimationSpeed = 30;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(341, 23);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProgress.TabIndex = 4;
            // 
            // lblLoadingMessage
            // 
            this.lblLoadingMessage.AutoSize = true;
            this.lblLoadingMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadingMessage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingMessage.ForeColor = System.Drawing.Color.White;
            this.lblLoadingMessage.Location = new System.Drawing.Point(61, 211);
            this.lblLoadingMessage.Name = "lblLoadingMessage";
            this.lblLoadingMessage.Size = new System.Drawing.Size(65, 16);
            this.lblLoadingMessage.TabIndex = 3;
            this.lblLoadingMessage.Text = "Loading...";
            // 
            // updateCheckWorker
            // 
            this.updateCheckWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateCheckWorker_DoWork);
            this.updateCheckWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateCheckWorker_RunWorkerCompleted);
            // 
            // UPDATERupdateCheckWorker
            // 
            this.UPDATERupdateCheckWorker.WorkerSupportsCancellation = true;
            this.UPDATERupdateCheckWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UPDATERupdateCheckWorker_DoWork);
            this.UPDATERupdateCheckWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UPDATERupdateCheckWorker_RunWorkerCompleted);
            // 
            // UPDATERdownloadWorker
            // 
            this.UPDATERdownloadWorker.WorkerReportsProgress = true;
            this.UPDATERdownloadWorker.WorkerSupportsCancellation = true;
            this.UPDATERdownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UPDATERdownloadWorker_DoWork);
            this.UPDATERdownloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UPDATERdownloadWorker_ProgressChanged);
            this.UPDATERdownloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UPDATERdownloadWorker_RunWorkerCompleted);
            // 
            // UPDATERupdateWorker
            // 
            this.UPDATERupdateWorker.WorkerSupportsCancellation = true;
            this.UPDATERupdateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UPDATERupdateWorker_DoWork);
            this.UPDATERupdateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UPDATERupdateWorker_RunWorkerCompleted);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EGMGame.Properties.Resources.SplashPageSq;
            this.ClientSize = new System.Drawing.Size(473, 282);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersionText);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblLoadingMessage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Express Game Maker";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Splash_FormClosing);
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersionText;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblLoadingMessage;
        private System.ComponentModel.BackgroundWorker updateCheckWorker;
        private System.ComponentModel.BackgroundWorker UPDATERupdateCheckWorker;
        private System.ComponentModel.BackgroundWorker UPDATERdownloadWorker;
        private System.ComponentModel.BackgroundWorker UPDATERupdateWorker;

    }
}

