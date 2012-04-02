/* -----------------------------
 * MenuContainer
 * -----------------------------
 * Purpose:             This the class that holds the three lists in the Home Page (Getting Started, Returning User, News).
 * Most Used By:        HomePage.cs
 * Associated Files:    MenuList.cs, NewsMenuList.cs
 * Modify:              When you want to modify the ways Home Page menu items are displayed.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace EGMGame.Docking.Homepage
{
    public partial class MenuContainer : GroupBox
    {
        public MenuContainer()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer, true);

            this.Font = new Font("Tahoma", 14, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(120, 138, 142);

            this.LinkFont = new Font("Tahoma", 10, FontStyle.Underline);
            this.LinkColor = Color.FromArgb(98, 170, 208);

            this.Icon = Properties.Resources.cancel;
        }

        #region Variables
        int leftTitleIndent = 10;
        int iconTextIndent = 10;

        int titleTopIndent = 10;
        int linkIndent = 20;
        int linkBottomIndent = 10;

        Rectangle linkHotspot;

        int leftPadding = 14;
        int topPadding = 0;
        int rightPadding = 14;
        int bottomPadding = 15;
        #endregion

        #region Properties
        Bitmap icon;
        public Bitmap Icon
        {
            get { return icon; }
            set { icon = value; Invalidate(); }
        }

        string linkText;
        [Browsable(true), Category("Link")]
        public string LinkText
        {
            get { return linkText; }
            set { linkText = value; Invalidate(); }
        }

        string linkURL;
        [Browsable(true), Category("Link")]
        public string LinkURL
        {
            get { return linkURL; }
            set { linkURL = value; Invalidate(); }
        }

        Font linkFont;
        [Browsable(true), Category("Link")]
        public Font LinkFont
        {
            get { return linkFont; }
            set { linkFont = value; Invalidate(); }
        }

        Color linkColor;
        [Browsable(true), Category("Link")]
        public Color LinkColor
        {
            get { return linkColor; }
            set { linkColor = value; Invalidate(); }
        }

        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            PaintBackground(e.Graphics);
            PaintTitle(e.Graphics);
            PaintLink(e.Graphics);

            this.Padding = new Padding(leftPadding, topPadding, rightPadding, bottomPadding);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            CheckMouseMove(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            CheckMouseDown(e);
        }
        #endregion

        #region Paint
        private void PaintBackground(Graphics g)
        {
            Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            GraphicsPath path = new GraphicsPath();
            path = RoundedRectangle(r, 15);

            //LinearGradientBrush headerBrush = new LinearGradientBrush(
            //    new Point(0, 0),
            //    new Point(0, this.Height),
            //    Color.Black,
            //    Color.Black
            //    );
            //ColorBlend colourBlend = new ColorBlend();
            //colourBlend.Positions = new float[]{
            //    0.0f,
            //    1.0f
            //};
            //colourBlend.Colors = new Color[] {
            //    Color.FromArgb(255,255,255),
            //    Color.FromArgb(241,241,241)
            //};
            //colourBlend.Positions = new float[]{
            //    0.0f,
            //    0.9f,
            //    1.0f
            //};
            //colourBlend.Colors = new Color[] {
            //    Color.FromArgb(248,248,248),
            //    Color.FromArgb(234,234,234),
            //    Color.FromArgb(207,207,207)
            //};

            //headerBrush.InterpolationColors = colourBlend;

            //g.FillPath(headerBrush, path);
            SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(40,80,110,9));
            g.FillPath(backgroundBrush, path);

            Pen border = new Pen(Color.FromArgb(50,0,0,0));//Color.FromArgb(104, 104, 104), 1f);
            //g.DrawRectangle(border, r);
            g.DrawPath(border, path);
        }

        private void PaintTitle(Graphics g)
        {
            string drawText = CalculateText(g);

            Brush textBrush = new SolidBrush(this.ForeColor);
            PointF texPoint = CalculateTitlePoint(g, drawText);
            if(drawText != "...")
                g.DrawString(drawText, this.Font, textBrush, texPoint);

            //Point beg = new Point((int)15,(int)(texPoint.Y + g.MeasureString(drawText,this.Font).Height));            
            //Point end = new Point((int)this.Width-15,(int)(texPoint.Y + g.MeasureString(drawText,this.Font).Height));
            //g.DrawLine(new Pen(Color.FromArgb(200, 80, 80, 80), 1), beg, end);
            
            //LinearGradientBrush brush = new LinearGradientBrush(beg, new Point(beg.X, beg.Y+5), Color.FromArgb(50, 80, 80, 80), Color.Transparent);
            //g.FillRectangle(brush, new Rectangle(beg.X, beg.Y, this.Width-30, 5));
            // Icon
            g.DrawImage((Image)icon, CalculateIconPoint(g, drawText));
        }

        private void PaintLink(Graphics g)
        {
            string drawText = CalculateLinkText(g);

            Brush textBrush = new SolidBrush(Color.FromArgb(255,0,79,146));//this.LinkColor);

            if (drawText != "...")
                g.DrawString(drawText, this.LinkFont, textBrush, CalculateLinkPoint(g,drawText));
            
            // Set hotspot
            SizeF stringSize = g.MeasureString(drawText, this.LinkFont);

            linkHotspot = new Rectangle(
                CalculateLinkPoint(g, drawText),
                new Size((int)stringSize.Width, (int)stringSize.Height)
                );
        }
        #endregion

        #region Drawing Methods
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

        #region Other Methods
        private void OpenURL(string URL)
        {
            if (URL != null && URL.StartsWith("http://"))
            {
                try
                {
                    System.Diagnostics.Process.Start(URL);
                }
                catch (System.ComponentModel.Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2147467259)
                        MessageBox.Show(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
            }
        }
        private PointF CalculateTitlePoint(Graphics g, string text)
        {            
            SizeF stringSize = g.MeasureString(text, this.Font);
            topPadding = (int)stringSize.Height - 5;

            if (text.EndsWith("..."))
            {
                return new PointF(leftTitleIndent + icon.Width + iconTextIndent, titleTopIndent);
            }
            else
            {
                int width = this.Width;
                float titleWidth = icon.Width + iconTextIndent + stringSize.Width;
                int x = (int)( (width/2) - (titleWidth/2) );
                PointF point = new PointF(x + icon.Width + iconTextIndent, titleTopIndent);

                return point;
            }
        }
        private Point CalculateIconPoint(Graphics g, string text)
        {
            SizeF stringSize = g.MeasureString(text, this.Font);

            if (text.EndsWith("..."))
            {
                int y = (int)( (stringSize.Height/2) - (icon.Height/2) );
                return new Point(leftTitleIndent, titleTopIndent + y);
            }
            else
            {
                int width = this.Width;
                float titleWidth = icon.Width + iconTextIndent + stringSize.Width;
                int x = (int)((width / 2) - (titleWidth / 2));
                int y = (int)((stringSize.Height / 2) - (icon.Height / 2));
                Point point = new Point(x, titleTopIndent + y);

                return point;
            }
        }
        private Point CalculateLinkPoint(Graphics g, string text)
        {
            SizeF stringSize = g.MeasureString(text, this.LinkFont);

            Point point = new Point(linkIndent, this.Height - linkBottomIndent - (int)stringSize.Height);

            bottomPadding = linkBottomIndent + (int)stringSize.Height + 10;

            return point;
        }

        private string CalculateText(Graphics g)
        {
            SizeF stringSize = g.MeasureString(this.Text, this.Font);

            string definatetext = "";
            string trialtext = "";

            SizeF trialSize;

            // The width of the control is less than the size of the text, therefore bad :(
            if (this.Width < leftTitleIndent + icon.Width + iconTextIndent + (int)stringSize.Width)
            {
                for(int i = 0; i < this.Text.Length; i++)
                {
                    trialtext += this.Text[i];
                    trialSize = g.MeasureString(trialtext + "...", this.Font);

                    if (this.Width < leftTitleIndent + icon.Width + iconTextIndent + trialSize.Width)
                    {
                        return definatetext + "...";
                    }
                    else
                    {
                        definatetext = trialtext;
                        continue;
                    }
                }
            }
            else
            {
                return this.Text;
            }

            return null;
        }

        private string CalculateLinkText(Graphics g)
        {
            SizeF stringSize = g.MeasureString(this.LinkText, this.LinkFont);

            string definatetext = "";
            string trialtext = "";

            SizeF trialSize;

            // The width of the control is less than the size of the text, therefore bad :(
            if (this.Width < linkIndent + stringSize.Width)
            {
                for (int i = 0; i < this.LinkText.Length; i++)
                {
                    trialtext += this.LinkText[i];
                    trialSize = g.MeasureString(trialtext + "...", this.Font);

                    if (this.Width < linkIndent + trialSize.Width)
                    {
                        return definatetext + "...";
                    }
                    else
                    {
                        definatetext = trialtext;
                        continue;
                    }
                }
            }
            else
            {
                return this.LinkText;
            }

            return null;
        }

        private void CheckMouseMove(MouseEventArgs e)
        {
            if (linkHotspot.Contains(new Point(e.X, e.Y)) && this.Cursor != Cursors.Hand)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }
        private void CheckMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && linkHotspot.Contains(new Point(e.X, e.Y)))
            {
                OpenURL(this.LinkURL);
            }
        }
        #endregion
    }
}
