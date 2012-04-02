using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Controls
{
    public class CustomTreeView : TreeView
    {
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg != 515)
                base.DefWndProc(ref m);
        }// class members

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
        }
    }
}
