namespace EGMGame
{
    partial class StateboxControl
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
            this.SuspendLayout();
            // 
            // Toolbox
            // 
            this.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.FullRowSelect = true;
            this.ItemHeight = 20;
            this.Name = "toolboxControl";
            this.ShowLines = false;
            this.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.Toolbox_DrawNode);
            this.ResumeLayout();

        }

        #endregion
    }
}
