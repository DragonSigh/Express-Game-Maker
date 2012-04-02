using EGMGame.Controls;
namespace EGMGame.Docking.Explorers
{
    partial class HistoryExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryExplorer));
            this.historyTools = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.historyList = new EGMGame.Controls.DataListBox();
            this.undoBtn = new System.Windows.Forms.ToolStripButton();
            this.redoBtn = new System.Windows.Forms.ToolStripButton();
            this.clearBtn = new System.Windows.Forms.ToolStripButton();
            this.historyTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // historyTools
            // 
            this.historyTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoBtn,
            this.redoBtn,
            this.toolStripSeparator1,
            this.clearBtn});
            this.historyTools.Location = new System.Drawing.Point(0, 0);
            this.historyTools.Name = "historyTools";
            this.historyTools.Size = new System.Drawing.Size(252, 25);
            this.historyTools.TabIndex = 0;
            this.historyTools.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // historyList
            // 
            this.historyList.DataList = ((System.Collections.Generic.List<string>)(resources.GetObject("historyList.DataList")));
            this.historyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyList.FormattingEnabled = true;
            this.historyList.Location = new System.Drawing.Point(0, 25);
            this.historyList.Name = "historyList";
            this.historyList.Size = new System.Drawing.Size(252, 482);
            this.historyList.TabIndex = 1;
            this.historyList.SelectedIndexChanged += new System.EventHandler(this.historyList_SelectedIndexChanged);
            // 
            // undoBtn
            // 
            this.undoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoBtn.Enabled = false;
            this.undoBtn.Image = global::EGMGame.Properties.Resources.arrow_undo;
            this.undoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(23, 22);
            this.undoBtn.Text = "Undo";
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // redoBtn
            // 
            this.redoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoBtn.Enabled = false;
            this.redoBtn.Image = global::EGMGame.Properties.Resources.arrow_redo;
            this.redoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoBtn.Name = "redoBtn";
            this.redoBtn.Size = new System.Drawing.Size(23, 22);
            this.redoBtn.Text = "Redo";
            this.redoBtn.Click += new System.EventHandler(this.redoBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearBtn.Enabled = false;
            this.clearBtn.Image = global::EGMGame.Properties.Resources.cancel;
            this.clearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(23, 22);
            this.clearBtn.Text = "Clear";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // HistoryExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 507);
            this.Controls.Add(this.historyList);
            this.Controls.Add(this.historyTools);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoryExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "History";
            this.Text = "History";
            this.historyTools.ResumeLayout(false);
            this.historyTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip historyTools;
        private System.Windows.Forms.ToolStripButton undoBtn;
        private System.Windows.Forms.ToolStripButton redoBtn;
        private DataListBox historyList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton clearBtn;


    }
}