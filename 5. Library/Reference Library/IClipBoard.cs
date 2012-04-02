using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGMGame
{
    public interface IClipBoard
    {
        void Cut();
        void Copy();
        void Paste();
    }
}
