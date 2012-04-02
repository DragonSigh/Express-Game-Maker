﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Docking.Database
{
    public class DoubleBufferedFlowLayout : FlowLayoutPanel
    {
        public DoubleBufferedFlowLayout() : base()
        {
            this.DoubleBuffered = true;
        }
    }
}
