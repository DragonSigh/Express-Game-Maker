namespace EGMGame.Docking.Database
{
    partial class GraphDisplayDialog
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
            this.chartPanel1 = new EGMGame.Controls.UI.ChartPanel();
            this.SuspendLayout();
            // 
            // chartPanel1
            // 
            this.chartPanel1.BackColor = System.Drawing.Color.White;
            this.chartPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel1.IsEditable = false;
            this.chartPanel1.Location = new System.Drawing.Point(0, 0);
            this.chartPanel1.Name = "chartPanel1";
            this.chartPanel1.Size = new System.Drawing.Size(273, 200);
            this.chartPanel1.TabIndex = 0;
            this.chartPanel1.MouseLeave += new System.EventHandler(this.chartPanel1_MouseLeave);
            this.chartPanel1.Click += new System.EventHandler(this.chartPanel1_Click);
            this.chartPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartPanel1_MouseMove);
            // 
            // GraphDisplayDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 200);
            this.Controls.Add(this.chartPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphDisplayDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GraphDisplayDialog";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartPanel1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.UI.ChartPanel chartPanel1;
    }
}