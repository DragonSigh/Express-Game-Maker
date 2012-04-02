using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace EGMGame.Controls.ImpactUI
{
    public class StyledPanel : Panel
    {
        Color borderColor;
        Color highlightColor;
        Color gradient1Color;
        Color gradient2Color;
        Color gradient3Color;
        Color gradient4Color;
        string text;

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

        [Browsable(true)]
        public override string Text
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }
        #endregion

        public StyledPanel()
            : base()
        {
            this.DoubleBuffered = true;
            
            this.BackColor = Color.Transparent;
            this.Text = "Box";

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ContainerControl |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();

            this.Padding = new Padding(4, 12, 4, 5);

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
            base.OnPaint(e);

            //e.Graphics.Clear(Color.Red);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;

            PaintBackground(g);
            PaintHeader(g);
        }
        private void PaintBackground(Graphics g)
        {
            // REGION
            //Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            //GraphicsPath regionPath = new GraphicsPath();
            //regionPath = RoundedRectangle(r, 4);

            //this.Region = new Region(regionPath);

            // Draw main gradient
            Rectangle mainRectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 2);
            GraphicsPath path = new GraphicsPath();

            path = RoundedRectangle(mainRectangle, 4);

            LinearGradientBrush fillBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, this.Height),
                Color.FromArgb(255, 255, 255),
                Color.FromArgb(222, 230, 236)
                );
            g.FillPath(fillBrush, path);

            // Draw main border
            GraphicsPath borderPath = new GraphicsPath();
            Rectangle borderRectangle = new Rectangle(0, 5, this.Width - 1, this.Height - 7);
            borderPath = RoundedRectangle(borderRectangle, 4);
            Pen headerPen = new Pen(Color.FromArgb(115, 126, 133));
            g.DrawPath(headerPen, borderPath);
        }

        private void PaintHeader(Graphics g)
        {
            // Draw header gradient
            Rectangle r = new Rectangle(0, 0, this.Width - 1, 20);
            GraphicsPath path = new GraphicsPath();
            path = RoundedRectangle(r, 4);

            // Interpolate gradient and add stops
            LinearGradientBrush headerBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, 20),
                Color.Black,
                Color.Black
                );
            ColorBlend colourBlend = new ColorBlend();
            colourBlend.Positions = new float[]{
                0.0f,
                0.495f,
                0.505f,
                1.0f
            };
            colourBlend.Colors = new Color[] {
                gradient1Color,
                gradient2Color,
                gradient3Color,
                gradient4Color
            };

            headerBrush.InterpolationColors = colourBlend;

            g.FillPath(headerBrush, path);

            // Draw header border
            Pen headerPen = new Pen(borderColor);
            g.DrawPath(headerPen, path);

            // Draw Inner highlight
            Rectangle highlightRect = new Rectangle(1, 1, this.Width - 3, 18);
            GraphicsPath highlightPath = new GraphicsPath();
            highlightPath = RoundedRectangle(highlightRect, 4);

            Pen highlightPen = new Pen(highlightColor);
            g.DrawPath(highlightPen, highlightPath);

            // Draw text
            StringFormat sf = new StringFormat();
            Rectangle textRectangle = new Rectangle(10, 3, this.Width - 5, 18);

            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRectangle, sf);


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
