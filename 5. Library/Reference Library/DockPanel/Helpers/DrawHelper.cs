using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
	internal static class DrawHelper
	{
        public static Point RtlTransform(Control control, Point point)
        {
            if (control.RightToLeft != RightToLeft.Yes)
                return point;
            else
                return new Point(control.Right - point.X, point.Y);
        }

        public static Rectangle RtlTransform(Control control, Rectangle rectangle)
        {
            if (control.RightToLeft != RightToLeft.Yes)
                return rectangle;
            else
                return new Rectangle(control.ClientRectangle.Right - rectangle.Right, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public static GraphicsPath GetRoundedCornerTab(GraphicsPath graphicsPath, Rectangle rect, bool upCorner)
        {
            if (graphicsPath == null)
                graphicsPath = new GraphicsPath();
            else
                graphicsPath.Reset();
            
            int curveSize = 6;
            if (upCorner)
            {
                graphicsPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top + curveSize / 2);
                graphicsPath.AddArc(new Rectangle(rect.Left, rect.Top, curveSize, curveSize), 180, 90);
                graphicsPath.AddLine(rect.Left + curveSize / 2, rect.Top, rect.Right - curveSize / 2, rect.Top);
                graphicsPath.AddArc(new Rectangle(rect.Right - curveSize, rect.Top, curveSize, curveSize), -90, 90);
                graphicsPath.AddLine(rect.Right, rect.Top + curveSize / 2, rect.Right, rect.Bottom);
            }
            else
            {
                graphicsPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom - curveSize / 2);
                graphicsPath.AddArc(new Rectangle(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize), 0, 90);
                graphicsPath.AddLine(rect.Right - curveSize / 2, rect.Bottom, rect.Left + curveSize / 2, rect.Bottom);
                graphicsPath.AddArc(new Rectangle(rect.Left, rect.Bottom - curveSize, curveSize, curveSize), 90, 90);
                graphicsPath.AddLine(rect.Left, rect.Bottom - curveSize / 2, rect.Left, rect.Top);
            }

            return graphicsPath;
        }

		public static GraphicsPath CalculateGraphicsPathFromBitmap(Bitmap bitmap)
		{
			return CalculateGraphicsPathFromBitmap(bitmap, Color.Empty);
		}

		// From http://edu.cnzz.cn/show_3281.html
		public static GraphicsPath CalculateGraphicsPathFromBitmap(Bitmap bitmap, Color colorTransparent) 
		{ 
			GraphicsPath graphicsPath = new GraphicsPath(); 
			if (colorTransparent == Color.Empty)
				colorTransparent = bitmap.GetPixel(0, 0); 

			for(int row = 0; row < bitmap.Height; row ++) 
			{ 
				int colOpaquePixel = 0;
				for(int col = 0; col < bitmap.Width; col ++) 
				{ 
					if(bitmap.GetPixel(col, row) != colorTransparent) 
					{ 
						colOpaquePixel = col; 
						int colNext = col; 
						for(colNext = colOpaquePixel; colNext < bitmap.Width; colNext ++) 
							if(bitmap.GetPixel(colNext, row) == colorTransparent) 
								break;
 
						graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1)); 
						col = colNext; 
					} 
				} 
			} 
			return graphicsPath; 
		}
        
        public enum RectangleCorners
        {
            None = 0, TopLeft = 1, TopRight = 2, BottomLeft = 4, BottomRight = 8,
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }

        public static GraphicsPath RoundedRectangle(int x, int y, int width, int height,
                                            int radius, RectangleCorners corners)
        {
            int xw = x + width;
            int yh = y + height;
            int xwr = xw - radius;
            int yhr = yh - radius;
            int xr = x + radius;
            int yr = y + radius;
            int r2 = radius * 2;
            int xwr2 = xw - r2;
            int yhr2 = yh - r2;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            //Top Left Corner
            if ((RectangleCorners.TopLeft & corners) == RectangleCorners.TopLeft)
            {
                p.AddArc(x, y, r2, r2, 180, 90);
            }
            else
            {
                p.AddLine(x, yr, x, y);
                p.AddLine(x, y, xr, y);
            }

            //Top Edge
            p.AddLine(xr, y, xwr, y);

            //Top Right Corner
            if ((RectangleCorners.TopRight & corners) == RectangleCorners.TopRight)
            {
                p.AddArc(xwr2, y, r2, r2, 270, 90);
            }
            else
            {
                p.AddLine(xwr, y, xw, y);
                p.AddLine(xw, y, xw, yr);
            }

            //Right Edge
            p.AddLine(xw, yr, xw, yhr);

            //Bottom Right Corner
            if ((RectangleCorners.BottomRight & corners) == RectangleCorners.BottomRight)
            {
                p.AddArc(xwr2, yhr2, r2, r2, 0, 90);
            }
            else
            {
                p.AddLine(xw, yhr, xw, yh);
                p.AddLine(xw, yh, xwr, yh);
            }

            //Bottom Edge
            p.AddLine(xwr, yh, xr, yh);

            //Bottom Left Corner
            if ((RectangleCorners.BottomLeft & corners) == RectangleCorners.BottomLeft)
            {
                p.AddArc(x, yhr2, r2, r2, 90, 90);
            }
            else
            {
                p.AddLine(xr, yh, x, yh);
                p.AddLine(x, yh, x, yhr);
            }

            //Left Edge
            p.AddLine(x, yhr, x, yr);

            p.CloseFigure();
            return p;
        }

        public static GraphicsPath RoundedRectangle(Rectangle rect, int radius, RectangleCorners c)
        { return RoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height, radius, c); }


        public static void RoundedRectangle(Rectangle rect, int radius, RectangleCorners c, out GraphicsPath g)
        { g = RoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height, radius, c); }

        public static GraphicsPath RoundedRectangle(int x, int y, int width, int height, int radius)
        { return RoundedRectangle(x, y, width, height, radius, RectangleCorners.All); }

        public static GraphicsPath RoundedRectangle(Rectangle rect, int radius)
        { return RoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height, radius); }

        public static GraphicsPath RoundedRectangle(int x, int y, int width, int height)
        { return RoundedRectangle(x, y, width, height, 5); }

        public static GraphicsPath RoundedRectangle(Rectangle rect)
        { return RoundedRectangle(rect.X, rect.Y, rect.Width, rect.Height); }
    }
}
