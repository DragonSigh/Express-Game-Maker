//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace EGMGame.Controls.ImpactUI
{
    class ImpactButton : Button
    {
        #region Variables

        // Usbaility variables
        bool ischecked = false;
        bool mousehover = false;
        bool mousedown = false;

        // Colour variables
        Color borderColor;
        Color highlightColor;
        Color gradient1Color;
        Color gradient2Color;
        Color gradient3Color;
        Color gradient4Color;

        int radius = 4;

        #endregion

        #region Properties

        [BrowsableAttribute(true)]
        public bool Checked
        {
            get { return ischecked; }
            set { ischecked = value; Invalidate(); }
        }

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
        public int Radius
        {
            get { return radius; }
            set { radius = value; Invalidate(); }
        }

        #endregion

        public ImpactButton()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);

            this.BackColor = Color.Transparent;

            // Set default GREEN colours
            borderColor = Color.FromArgb(161,161,161);
            highlightColor = Color.FromArgb(210, 239, 71);
            gradient1Color = Color.FromArgb(195, 231, 20);;
            gradient2Color = Color.FromArgb(169,213,28);
            gradient3Color = Color.FromArgb(157,200,23);
            gradient4Color = Color.FromArgb(126,177,46);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.High;

            // Disabled Draw          
            if(!Enabled)
            {
                DrawDisabled(g);
            }

            // Checked Draw  
            else if (ischecked)
            {
                DrawChecked(g);
            }

            // Draw mouse down effect
            else if (mousedown)
            {
                DrawChecked(g);
            }

            // Normal Draw
            else
            {
                DrawNormal(g);
            }
        }

        #region Draw Methods
        private void DrawNormal(Graphics g)
        {
            if (mousehover)
            {
                // Draw gradient
                Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height-1);
                GraphicsPath path = new GraphicsPath();
                path = RoundedRectangle(r, radius);

                // Interpolate gradient and add stops
                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, this.Height-1),
                    Color.Black,
                    Color.Black
                    );
                ColorBlend colourBlend = new ColorBlend();
                colourBlend.Positions = new float[]{
                0.0f,
                1.0f
                };
                colourBlend.Colors = new Color[] {
                gradient1Color,
                gradient4Color
                };

                headerBrush.InterpolationColors = colourBlend;

                g.FillPath(headerBrush, path);

                // Draw header border
                Pen headerPen = new Pen(borderColor);
                g.DrawPath(headerPen, path);

                // Draw Inner highlight
                Rectangle highlightRect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
                GraphicsPath highlightPath = new GraphicsPath();
                highlightPath = RoundedRectangle(highlightRect, radius);

                Pen highlightPen = new Pen(highlightColor);
                g.DrawPath(highlightPen, highlightPath);

                Rectangle highlightRect2 = new Rectangle(2, 2, this.Width - 4, this.Height - 4);
                GraphicsPath highlightPath2 = new GraphicsPath();
                highlightPath2 = RoundedRectangle(highlightRect, radius);
                g.DrawPath(highlightPen, highlightPath2);

                Rectangle highlightRect3 = new Rectangle(3, 3, this.Width - 5, this.Height - 5);
                GraphicsPath highlightPath3 = new GraphicsPath();
                highlightPath3 = RoundedRectangle(highlightRect, radius);
                g.DrawPath(highlightPen, highlightPath3);

                DrawText(g);
            }
            else
            {
                // Draw gradient
                Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height -1);
                GraphicsPath path = new GraphicsPath();
                path = RoundedRectangle(r, radius);

                // Interpolate gradient and add stops
                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, this.Height),
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
                Rectangle highlightRect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
                GraphicsPath highlightPath = new GraphicsPath();
                highlightPath = RoundedRectangle(highlightRect, radius);

                Pen highlightPen = new Pen(highlightColor);
                g.DrawPath(highlightPen, highlightPath);

                DrawText(g);
            }
        }

        private void DrawChecked(Graphics g)
        {
            if (mousehover)
            {
                // Draw gradient
                Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height-1);
                GraphicsPath path = new GraphicsPath();
                path = RoundedRectangle(r, radius);

                // Interpolate gradient and add stops
                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, this.Height),
                    Color.Black,
                    Color.Black
                    );
                ColorBlend colourBlend = new ColorBlend();
                colourBlend.Positions = new float[]{
                0.0f,
                1.0f
                };
                colourBlend.Colors = new Color[] {
                gradient4Color,
                gradient1Color
                };

                headerBrush.InterpolationColors = colourBlend;

                g.FillPath(headerBrush, path);

                // Draw header border
                Pen headerPen = new Pen(borderColor);
                g.DrawPath(headerPen, path);

                // Draw Inner highlight
                Rectangle highlightRect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
                GraphicsPath highlightPath = new GraphicsPath();
                highlightPath = RoundedRectangle(highlightRect, radius);

                Pen highlightPen = new Pen(highlightColor);
                g.DrawPath(highlightPen, highlightPath);

                Rectangle highlightRect2 = new Rectangle(2, 2, this.Width - 4, this.Height - 4);
                GraphicsPath highlightPath2 = new GraphicsPath();
                highlightPath2 = RoundedRectangle(highlightRect, radius);
                g.DrawPath(highlightPen, highlightPath2);

                Rectangle highlightRect3 = new Rectangle(3, 3, this.Width - 5, this.Height - 5);
                GraphicsPath highlightPath3 = new GraphicsPath();
                highlightPath3 = RoundedRectangle(highlightRect, radius);
                g.DrawPath(highlightPen, highlightPath3);

                DrawText(g);
            }
            else
            {
                // Draw gradient
                Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height-1);
                GraphicsPath path = new GraphicsPath();
                path = RoundedRectangle(r, radius);

                // Interpolate gradient and add stops
                LinearGradientBrush headerBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, this.Height),
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
                gradient4Color,
                gradient3Color,
                gradient2Color,
                gradient1Color
                };

                headerBrush.InterpolationColors = colourBlend;

                g.FillPath(headerBrush, path);

                // Draw header border
                Pen headerPen = new Pen(borderColor);
                g.DrawPath(headerPen, path);

                // Draw Inner highlight
                Rectangle highlightRect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
                GraphicsPath highlightPath = new GraphicsPath();
                highlightPath = RoundedRectangle(highlightRect, radius);

                Pen highlightPen = new Pen(highlightColor);
                g.DrawPath(highlightPen, highlightPath);

                DrawText(g);
            }
        }

        private void DrawDisabled(Graphics g)
        {
            // Draw gradient
            Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height-1);
            GraphicsPath path = new GraphicsPath();
            path = RoundedRectangle(r, radius);

            // Interpolate gradient and add stops
            LinearGradientBrush headerBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, this.Height),
                Color.Black,
                Color.Black
                );
            ColorBlend colourBlend = new ColorBlend();
            colourBlend.Positions = new float[]{
                0.0f,
                1.0f
                };
            colourBlend.Colors = new Color[] {
                Color.FromArgb(247,255,245),
                Color.FromArgb(196,238,183)
                };

            headerBrush.InterpolationColors = colourBlend;

            g.FillPath(headerBrush, path);

            // Draw header border
            Pen headerPen = new Pen(borderColor);
            g.DrawPath(headerPen, path);

            // Draw Inner highlight
            Rectangle highlightRect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
            GraphicsPath highlightPath = new GraphicsPath();
            highlightPath = RoundedRectangle(highlightRect, radius);

            DrawText(g);
        }
        #endregion


        #region Overrides
        protected override void OnMouseEnter(EventArgs e)
        {
            mousehover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            mousehover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mousedown = true;
            Invalidate();
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            mousedown = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }
        #endregion

        #region Helper Methods
        private void DrawText(Graphics g)
        {
            // Draw text
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Rectangle textRectangle = new Rectangle(0, 0, this.Width -1, this.Height - 1);

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
        #endregion
    }
}
