namespace EGMGame.Controls
{
    partial class MessageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.styleBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.colorBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.chooseColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.variableButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnString = new System.Windows.Forms.ToolStripSplitButton();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.styleBtn,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.colorBtn,
            this.toolStripSeparator3,
            this.variableButton,
            this.toolStripSeparator5,
            this.btnString});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(280, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // styleBtn
            // 
            this.styleBtn.AutoToolTip = false;
            this.styleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.styleBtn.Image = ((System.Drawing.Image)(resources.GetObject("styleBtn.Image")));
            this.styleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.styleBtn.Name = "styleBtn";
            this.styleBtn.Size = new System.Drawing.Size(48, 22);
            this.styleBtn.Text = "Style";
            this.styleBtn.ToolTipText = "List of styles that should be appended to text.";
            this.styleBtn.ButtonClick += new System.EventHandler(this.styleBtn_ButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // colorBtn
            // 
            this.colorBtn.BackColor = System.Drawing.SystemColors.Control;
            this.colorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.colorBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseColorToolStripMenuItem,
            this.toolStripSeparator4});
            this.colorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(52, 22);
            this.colorBtn.Text = "Color";
            this.colorBtn.ButtonClick += new System.EventHandler(this.colorBtn_ButtonClick);
            // 
            // chooseColorToolStripMenuItem
            // 
            this.chooseColorToolStripMenuItem.Name = "chooseColorToolStripMenuItem";
            this.chooseColorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.chooseColorToolStripMenuItem.Text = "Choose Color...";
            this.chooseColorToolStripMenuItem.Click += new System.EventHandler(this.chooseColorToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // variableButton
            // 
            this.variableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.variableButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.variableButton.Name = "variableButton";
            this.variableButton.Size = new System.Drawing.Size(65, 22);
            this.variableButton.Text = "Variable";
            this.variableButton.ButtonClick += new System.EventHandler(this.variableButton_ButtonClick);
            this.variableButton.DropDownOpened += new System.EventHandler(this.variableButton_DropDownOpened);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnString
            // 
            this.btnString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnString.Name = "btnString";
            this.btnString.Size = new System.Drawing.Size(59, 22);
            this.btnString.Text = "Strings";
            this.btnString.ButtonClick += new System.EventHandler(this.btnString_ButtonClick);
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.DetectUrls = false;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 25);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(280, 123);
            this.textBox.TabIndex = 1;
            this.textBox.Text = "";
            this.textBox.WordWrap = false;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // MessageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MessageEditor";
            this.Size = new System.Drawing.Size(280, 148);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.ToolStripSplitButton styleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton colorBtn;
        private System.Windows.Forms.ToolStripMenuItem chooseColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSplitButton variableButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton btnString;
    }
}
