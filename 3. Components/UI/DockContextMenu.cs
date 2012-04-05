//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.ComponentModel;

namespace EGMGame.Controls.UI
{
    public class DockContextMenu : ContextMenuStrip
    {
        internal DockContent owner;

        public DockContextMenu()
        {
            ToolStripMenuItem closeToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem closeAllButThisToolStripMenuItem = new ToolStripMenuItem();
         
            Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            closeToolStripMenuItem,
            closeAllButThisToolStripMenuItem});
            Name = "contextMenuStrip1";
            Size = new System.Drawing.Size(167, 70);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += new System.EventHandler(closeToolStripMenuItem_Click);
            // 
            // closeAllButThisToolStripMenuItem
            // 
            closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
            closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            closeAllButThisToolStripMenuItem.Text = "Close All But This";
            closeAllButThisToolStripMenuItem.Click += new System.EventHandler(closeAllButThisToolStripMenuItem_Click);
         
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            base.OnOpening(e);

            if (owner.DockState != WeifenLuo.WinFormsUI.Docking.DockState.Document)
                e.Cancel = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.owner.Hide();
        }

        private void closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CMD.CloseAllButThis((DockContent)this.owner);
        }
    }
}
