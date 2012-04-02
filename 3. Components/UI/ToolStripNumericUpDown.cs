using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame
{
    public class ToolStripNumericUpDown : ToolStripControlHost
    {
        public ToolStripNumericUpDown()
            : base(new NumericUpDown())
        {

        }
    }

}
