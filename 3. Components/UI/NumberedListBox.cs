using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace EGMGame.Controls
{
    public class NumberedListBox : ListBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);

            e.Graphics.DrawRectangle(pen, new System.Drawing.Rectangle(0, 0, 8, 8));
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }
    }
}
