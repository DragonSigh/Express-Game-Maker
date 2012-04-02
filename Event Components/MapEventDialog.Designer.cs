namespace EGMGame.EventControls
{
    partial class MapEventDialog
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
            this.button1 = new System.Windows.Forms.Button();
            this.eventEditorControl = new EGMGame.Controls.MapEventEditorControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(163, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 10);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eventEditorControl
            // 
            this.eventEditorControl.BackColor = System.Drawing.Color.Transparent;
            this.eventEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventEditorControl.Location = new System.Drawing.Point(0, 0);
            this.eventEditorControl.Name = "eventEditorControl";
            this.eventEditorControl.SelectedEvent = null;
            this.eventEditorControl.SelectedIndex = -1;
            this.eventEditorControl.Size = new System.Drawing.Size(776, 752);
            this.eventEditorControl.TabIndex = 0;
            this.eventEditorControl.Load += new System.EventHandler(this.eventEditorControl_Load);
            // 
            // MapEventDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(776, 752);
            this.Controls.Add(this.eventEditorControl);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapEventDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Event";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapEventDialog_FormClosing);
            this.Load += new System.EventHandler(this.MapEventDialog_Load);
            this.Shown += new System.EventHandler(this.MapEventDialog_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEventDialog_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.MapEventEditorControl eventEditorControl;
        private System.Windows.Forms.Button button1;

    }
}