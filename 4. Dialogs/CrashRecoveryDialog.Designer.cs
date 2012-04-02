namespace EGMGame.Dialogs
{
    partial class CrashRecoveryDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.recoveryList = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRecoverSelected = new System.Windows.Forms.Button();
            this.btnDiscardAll = new System.Windows.Forms.Button();
            this.btnDiscardSelected = new System.Windows.Forms.Button();
            this.btnRecoverAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Express Game Maker is detecting recovery files.\r\nRecover files?";
            // 
            // recoveryList
            // 
            this.recoveryList.FormattingEnabled = true;
            this.recoveryList.Location = new System.Drawing.Point(15, 38);
            this.recoveryList.Name = "recoveryList";
            this.recoveryList.Size = new System.Drawing.Size(158, 95);
            this.recoveryList.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(208, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRecoverSelected
            // 
            this.btnRecoverSelected.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRecoverSelected.Location = new System.Drawing.Point(15, 140);
            this.btnRecoverSelected.Name = "btnRecoverSelected";
            this.btnRecoverSelected.Size = new System.Drawing.Size(103, 23);
            this.btnRecoverSelected.TabIndex = 2;
            this.btnRecoverSelected.Text = "Recover Selected";
            this.btnRecoverSelected.UseVisualStyleBackColor = true;
            this.btnRecoverSelected.Click += new System.EventHandler(this.btnRecoverSelected_Click);
            // 
            // btnDiscardAll
            // 
            this.btnDiscardAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDiscardAll.Location = new System.Drawing.Point(179, 110);
            this.btnDiscardAll.Name = "btnDiscardAll";
            this.btnDiscardAll.Size = new System.Drawing.Size(104, 23);
            this.btnDiscardAll.TabIndex = 4;
            this.btnDiscardAll.Text = "Discard All";
            this.btnDiscardAll.UseVisualStyleBackColor = true;
            this.btnDiscardAll.Click += new System.EventHandler(this.btnDiscardAll_Click);
            // 
            // btnDiscardSelected
            // 
            this.btnDiscardSelected.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDiscardSelected.Location = new System.Drawing.Point(179, 81);
            this.btnDiscardSelected.Name = "btnDiscardSelected";
            this.btnDiscardSelected.Size = new System.Drawing.Size(104, 23);
            this.btnDiscardSelected.TabIndex = 5;
            this.btnDiscardSelected.Text = "Discard Selected";
            this.btnDiscardSelected.UseVisualStyleBackColor = true;
            this.btnDiscardSelected.Click += new System.EventHandler(this.btnDiscardSelected_Click);
            // 
            // btnRecoverAll
            // 
            this.btnRecoverAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRecoverAll.Location = new System.Drawing.Point(124, 139);
            this.btnRecoverAll.Name = "btnRecoverAll";
            this.btnRecoverAll.Size = new System.Drawing.Size(78, 23);
            this.btnRecoverAll.TabIndex = 6;
            this.btnRecoverAll.Text = "Recover All";
            this.btnRecoverAll.UseVisualStyleBackColor = true;
            this.btnRecoverAll.Click += new System.EventHandler(this.btnRecoverAll_Click);
            // 
            // CrashRecoveryDialog
            // 
            this.AcceptButton = this.btnRecoverAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(300, 175);
            this.Controls.Add(this.btnRecoverAll);
            this.Controls.Add(this.btnDiscardSelected);
            this.Controls.Add(this.btnDiscardAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRecoverSelected);
            this.Controls.Add(this.recoveryList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrashRecoveryDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crash Recovery";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox recoveryList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRecoverSelected;
        private System.Windows.Forms.Button btnDiscardAll;
        private System.Windows.Forms.Button btnDiscardSelected;
        private System.Windows.Forms.Button btnRecoverAll;
    }
}