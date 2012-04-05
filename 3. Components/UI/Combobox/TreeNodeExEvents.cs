// Author: Vlad Untu/Asterix Software
// For updates: http://www.asterixsoft.ro/dyn/open/treeview_filter/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Controls
{
    public class TreeNodeExMouseClickEventArgs : MouseEventArgs {
        TreeNodeEx node;

        public TreeNodeExMouseClickEventArgs(TreeNodeEx node)
            : this(node, MouseButtons.Left, 0, 0) {}

        public TreeNodeExMouseClickEventArgs(TreeNodeEx node, MouseEventArgs mouse)
            : this(node, mouse.Button, mouse.X, mouse.Y) {
        }

        public TreeNodeExMouseClickEventArgs(TreeNodeEx node, MouseButtons button, int x, int y) : 
            base(button, 1, x, y, 0) {
            this.node = node;
        }

        public TreeNodeEx Node {
            get { return this.node; }
        }

    }

    public class TreeNodeExExpandEvent : TreeNodeExMouseClickEventArgs {
        bool cancel;

        public TreeNodeExExpandEvent(TreeNodeEx node) : base(node) {
            cancel = false;
        }

        public bool Cancel {
            get { return cancel; }
            set { cancel = value; }
        }
    }
}
