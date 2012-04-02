namespace EGMGame.Controls.EventControls
{
    partial class ProgramOverviewDialog
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
            this.list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.Color.White;
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.FormattingEnabled = true;
            this.list.IntegralHeight = false;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.Name = "list";
            this.list.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.list.Size = new System.Drawing.Size(315, 155);
            this.list.TabIndex = 0;
            this.list.Leave += new System.EventHandler(this.list_Leave);
            this.list.MouseLeave += new System.EventHandler(this.list_MouseLeave);
            // 
            // ProgramOverviewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 155);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramOverviewDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ProgramOverviewDialog";
            this.Deactivate += new System.EventHandler(this.list_Leave);
            this.Leave += new System.EventHandler(this.list_Leave);
            this.MouseLeave += new System.EventHandler(this.list_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list;
    }
}