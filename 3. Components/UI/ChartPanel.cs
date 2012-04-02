using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EGMGame.Controls.UI
{
    public partial class ChartPanel : UserControl
    {
        public bool IsEditable
        {
            get { return isEditable; }
            set { isEditable = value; }
        }
        bool isEditable = false;

        List<int> curveList;
        bool down = false;

        Point lastPoint = new Point();

        public ChartPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Paint chart
            if (curveList != null && curveList.Count > 0)
            {
                int brushSize = this.Width / curveList.Count + 1;
                int height = 0;
                if (brushSize < 1) brushSize = 1;

                Pen pen = new Pen(Brushes.Crimson);
                pen.Color = Color.Crimson;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                pen.Width = (float)brushSize;
                // Set the LineJoin property.
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

                int i = 0;
                int max = 9999 / this.Height;
                for (int x = 0; x < this.Width; x += brushSize)
                {
                    if (i < curveList.Count)
                    {
                        height = curveList[i];//(int)Math.Floor((double)(curveList[i] / this.Height));
                        e.Graphics.DrawLine(pen, x, this.Height, x, this.Height - (height / max));
                    }
                    else
                        break;
                    i++;
                }
                pen.Dispose();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (isEditable) down = true;
            lastPoint = e.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (down && curveList != null && curveList.Count > 0)
            {
                int max = 9999 / this.Height;
                int brushSize = this.Width / curveList.Count + 1;
                if (brushSize < 1) brushSize = 1;
                int x = (int)Math.Round((double)(e.X / brushSize));
                if (x > -1 && x < curveList.Count)
                {
                    int missing = (int)Math.Round((double)(lastPoint.X / brushSize));
                    bool right = ((missing - x) < 0);
                    missing = (int)Math.Abs((decimal)(missing - x));
                    if (missing > 1)
                    {
                        int indexes = missing;
                        int nX = x;

                        for (int i = 1; i <= missing; i++)
                        {
                            if (right)
                                nX = x - i;
                            else
                                nX = x + i;
                            if (nX > -1 && nX < curveList.Count)
                            {
                                curveList[nX] = (int)Math.Min(9999, Math.Max(0, 9999 - (e.Y * max)));
                            }
                        }
                    }
                    curveList[x] = (int)Math.Min(9999, Math.Max(0, 9999 - (e.Y * max)));

                    if (this.Parent is DatasetListDialog)
                        ((DatasetListDialog)this.Parent).SetIndex(x);
                    Invalidate();
                }
                lastPoint = e.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            down = false;
        }
        internal void Setup(List<int> list)
        {
            curveList = list;
            Refresh();
        }
    }
}
