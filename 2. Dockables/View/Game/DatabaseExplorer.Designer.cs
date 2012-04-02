namespace EGMGame.Docking.Explorers
{
    partial class DatabaseExplorer
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
            this.listBox = new EGMGame.Controls.AddRemoveList();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.AllowAdd = false;
            this.listBox.AllowCategories = true;
            this.listBox.AllowClipboard = false;
            this.listBox.AllowRemove = false;
            this.listBox.DisplayToolbar = false;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.EnableUpDown = false;
            this.listBox.Export = true;
            this.listBox.ImageList = null;
            this.listBox.Import = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Master = false;
            this.listBox.MultipleSelection = false;
            this.listBox.Name = "listBox";
            this.listBox.SelectedIndex = -1;
            this.listBox.ShowWarning = true;
            this.listBox.Size = new System.Drawing.Size(187, 450);
            this.listBox.TabIndex = 0;
            this.listBox.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.listBox_SelectItem);
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
            // 
            // DatabaseExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 450);
            this.Controls.Add(this.listBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HideOnClose = true;
            this.Name = "DatabaseExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.ShowIcon = false;
            this.TabText = "Databases";
            this.Text = "Databases";
            this.Shown += new System.EventHandler(this.DatabaseExplorer_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AddRemoveList listBox;



    }
}