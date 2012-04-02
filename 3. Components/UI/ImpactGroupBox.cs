using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace EGMGame.Controls.ImpactUI
{
    public partial class ImpactGroupBox : GroupBox
    {
        Color borderColor;
        Color highlightColor;
        Color gradient1Color;
        Color gradient2Color;
        Color gradient3Color;
        Color gradient4Color;
        bool canCollapse = false;
        bool isCollapsed = false;
        int oldHeight;
        Image image;

        #region Properties

        [BrowsableAttribute(true)]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        [BrowsableAttribute(true)]
        public Color HighlightColor
        {
            get { return highlightColor; }
            set { highlightColor = value; Invalidate(); }
        }

        [BrowsableAttribute(true)]
        public Color Gradient1Color
        {
            get { return gradient1Color; }
            set { gradient1Color = value; Invalidate(); }
        }

        [BrowsableAttribute(true)]
        public Color Gradient2Color
        {
            get { return gradient2Color; }
            set { gradient2Color = value; Invalidate(); }
        }

        [BrowsableAttribute(true)]
        public Color Gradient3Color
        {
            get { return gradient3Color; }
            set { gradient3Color = value; Invalidate(); }
        }

        [BrowsableAttribute(true)]
        public Color Gradient4Color
        {
            get { return gradient4Color; }
            set { gradient4Color = value; Invalidate(); }
        }

        [BrowsableAttribute(true)]
        public bool CanCollapse
        {
            get { return canCollapse; }
            set { canCollapse = value; Invalidate(); }
        }

        [BrowsableAttribute(true)]
        public bool IsCollapsed
        {
            get { return isCollapsed; }
            set { isCollapsed = value; CheckCollapse(); }
        }

        [BrowsableAttribute(true)]
        public Image Image
        {
            get { return image; }
            set { image = value; Invalidate(); }
        }

        #endregion

        public ImpactGroupBox()
            : base()
        {
            this.DoubleBuffered = true;

            this.Padding = new Padding(4, 12, 4, 5);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ContainerControl |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();

            // Init colors
            borderColor = Color.FromArgb(115, 126, 133);
            highlightColor = Color.FromArgb(128, 171, 194);

            gradient1Color = Color.FromArgb(213, 237, 254);
            gradient2Color = Color.FromArgb(144, 191, 240);
            gradient3Color = Color.FromArgb(114, 167, 204);
            gradient4Color = Color.FromArgb(76, 135, 172);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;

            PaintBackground(g);
            PaintHeader(g);
            if (canCollapse)
                PaintCollapseButton(g);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Rectangle r = new Rectangle(this.Width - 16, 6, 10, 10);
            if (r.Contains(e.Location))
                ToggleCollapse();
            base.OnMouseClick(e);
        }

        private void ToggleCollapse()
        {
            if (isCollapsed)
                IsCollapsed = false;
            else
                IsCollapsed = true;
        }

        private void CheckCollapse()
        {
            // Going from FULL -> COLLAPSED
            if (isCollapsed)
            {
                oldHeight = this.Height;
                this.Height = 22;
            }
            // Going from COLLAPSED -> FULL
            else
            {
                this.Height = oldHeight;
            }
        }


        private void PaintBackground(Graphics g)
        {
            if (!isCollapsed)
            {
                // Draw main gradient
                Rectangle mainRectangle = new Rectangle(0, 10, this.Width - 1, this.Height - 10 - 1);
                GraphicsPath path = new GraphicsPath();

                path = RoundedRectangle(mainRectangle, 4);

                LinearGradientBrush fillBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, this.Height),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(222, 230, 236)
                    );
                g.FillPath(fillBrush, path);

                fillBrush.Dispose();
                path.Dispose();

                // Draw main border
                GraphicsPath borderPath = new GraphicsPath();
                Rectangle borderRectangle = new Rectangle(0, 5, this.Width - 1, this.Height - 5 - 1);
                borderPath = RoundedRectangle(borderRectangle, 4);
                Pen headerPen = new Pen(Color.FromArgb(115, 126, 133));
                g.DrawPath(headerPen, borderPath);

                headerPen.Dispose();
                borderPath.Dispose();
            }
        }

        private void PaintHeader(Graphics g)
        {
            if (!canCollapse)
            {
                Rectangle r = new Rectangle(0, 0, this.Width - 1, 20);

                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, 20),
                    Color.FromArgb(124, 190, 245),
                    Color.FromArgb(95, 170, 217)
                );
                g.FillRectangle(headerBrush, r);
                headerBrush.Dispose();

                Pen headerPen = new Pen(Color.FromArgb(77, 143, 191));
                g.DrawRectangle(headerPen, r);
                headerPen.Dispose();

                // Draw text
                StringFormat sf = new StringFormat();
                Rectangle textRectangle;

                if (image == null)
                {
                    textRectangle = new Rectangle(10, 4, this.Width - 5, 18);
                }
                else
                {
                    g.DrawImage(Image, new Point(6, 2));
                    textRectangle = new Rectangle(25, 4, this.Width - 20, 18);
                }

                g.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(0, 33, 58)), textRectangle, sf);

                #region Old
                //    // Draw header gradient
                //    Rectangle r = new Rectangle(0, 0, this.Width - 1, 20);
                //    GraphicsPath path = new GraphicsPath();
                //    path = RoundedRectangle(r, 4);

                //    // Interpolate gradient and add stops
                //    LinearGradientBrush headerBrush = new LinearGradientBrush(
                //        new Point(0, 0),
                //        new Point(0, 20),
                //        Color.Black,
                //        Color.Black
                //        );
                //    ColorBlend colourBlend = new ColorBlend();
                //    colourBlend.Positions = new float[]{
                //    0.0f,
                //    0.495f,
                //    0.505f,
                //    1.0f
                //};
                //    colourBlend.Colors = new Color[] {
                //    gradient1Color,
                //    gradient2Color,
                //    gradient3Color,
                //    gradient4Color
                //};

                //    headerBrush.InterpolationColors = colourBlend;

                //    g.FillPath(headerBrush, path);

                //    headerBrush.Dispose();

                //    // Draw header border
                //    Pen headerPen = new Pen(borderColor);
                //    g.DrawPath(headerPen, path);

                //    // Draw Inner highlight
                //    Rectangle highlightRect = new Rectangle(1, 1, this.Width - 1 - 2, 20 - 1 - 2);
                //    GraphicsPath highlightPath = new GraphicsPath();
                //    highlightPath = RoundedRectangle(highlightRect, 4);

                //    Pen highlightPen = new Pen(highlightColor);
                //    g.DrawPath(highlightPen, highlightPath);


                //    path.Dispose();
                //    headerPen.Dispose();
                //    highlightPath.Dispose();

                //    // Draw text
                //    StringFormat sf = new StringFormat();
                //    Rectangle textRectangle = new Rectangle(10, 3, this.Width - 5, 18);

                //    g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRectangle, sf);
                #endregion
            }
            else
            {
                Rectangle r2 = new Rectangle(0, 0, this.Width - 1, 20);

                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, 20),
                    Color.FromArgb(124, 190, 245),
                    Color.FromArgb(95, 170, 217)
                );
                g.FillRectangle(headerBrush, r2);
                headerBrush.Dispose();

                Pen headerPen = new Pen(Color.FromArgb(77, 143, 191));
                g.DrawRectangle(headerPen, r2);
                headerPen.Dispose();

                // Draw text
                StringFormat sf = new StringFormat();
                Rectangle textRectangle;

                if (image == null)
                {
                    textRectangle = new Rectangle(10, 4, this.Width - 5, 18);
                }
                else
                {
                    g.DrawImage(Image, new Point(6, 2));
                    textRectangle = new Rectangle(25, 4, this.Width - 20, 18);
                }
                
                g.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(0, 33, 58)), textRectangle, sf);

                #region Old
            //    // Draw header gradient
            //    Rectangle r = new Rectangle(0, 0, this.Width - 1, 20);
            //    GraphicsPath path = new GraphicsPath();
            //    path = RoundedRectangle(r, 4);

            //    // Interpolate gradient and add stops
            //    LinearGradientBrush headerBrush = new LinearGradientBrush(
            //        new Point(0, 0),
            //        new Point(0, 20),
            //        Color.Black,
            //        Color.Black
            //        );
            //    ColorBlend colourBlend = new ColorBlend();
            //    colourBlend.Positions = new float[]{
            //    0.0f,
            //    0.495f,
            //    0.505f,
            //    1.0f
            //};
            //    colourBlend.Colors = new Color[] {
            //    gradient1Color,
            //    gradient2Color,
            //    gradient3Color,
            //    gradient4Color
            //};

            //    headerBrush.InterpolationColors = colourBlend;

            //    g.FillPath(headerBrush, path);

            //    headerBrush.Dispose();

            //    // Draw header border
            //    Pen headerPen = new Pen(borderColor);
            //    g.DrawPath(headerPen, path);

            //    // Draw Inner highlight
            //    Rectangle highlightRect = new Rectangle(1, 1, this.Width - 1 - 2, 20 - 1 - 2);
            //    GraphicsPath highlightPath = new GraphicsPath();
            //    highlightPath = RoundedRectangle(highlightRect, 4);

            //    Pen highlightPen = new Pen(highlightColor);
            //    g.DrawPath(highlightPen, highlightPath);


            //    path.Dispose();
            //    headerPen.Dispose();
            //    highlightPath.Dispose();

            //    // Draw text
            //    StringFormat sf = new StringFormat();
            //    Rectangle textRectangle = new Rectangle(10, 3, this.Width - 5, 18);

            //    g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRectangle, sf);
#endregion
            }
        }

        private void PaintCollapseButton(Graphics g)
        {
            if (isCollapsed)
                g.DrawImage(Properties.Resources.GroupBoxRestore, new Rectangle(this.Width - 16, 6, 10, 10));
            else
                g.DrawImage(Properties.Resources.GroupBoxCollapse, new Rectangle(this.Width - 16, 6, 10, 10));
        }

        private GraphicsPath RoundedRectangle(Rectangle r, int radius)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddBezier(x, y + radius, x, y, x + radius, y, x + radius, y);
            path.AddLine(x + radius, y, x + w - radius, y);
            path.AddBezier(x + w - radius, y, x + w, y, x + w, y + radius, x + w, y + radius);
            path.AddLine(x + w, y + radius, x + w, y + h - radius);
            path.AddBezier(x + w, y + h - radius, x + w, y + h, x + w - radius, y + h, x + w - radius, y + h);
            path.AddLine(x + w - radius, y + h, x + radius, y + h);
            path.AddBezier(x + radius, y + h, x, y + h, x, y + h - radius, x, y + h - radius);
            path.AddLine(x, y + h - radius, x, y + radius);
            return path;
        }
    }
}
