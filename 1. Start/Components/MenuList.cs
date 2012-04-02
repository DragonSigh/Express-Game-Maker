/* -----------------------------
 * MenuList
 * -----------------------------
 * Purpose:             This the class that holds Home Page menu items for "Getting Started" and "Returning User".
 * Most Used By:        HomePage.cs
 * Associated Files:    MenuList.cs, MenuListCollection.cs
 * Modify:              When you want to modify the ways Home Page menu items are displayed.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Collections;

namespace EGMGame.Docking.Homepage
{
    [Serializable]
    public class MenuList : ScrollableControl
    {
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
            base.OnScroll(se);
        }
        public MenuList()
        {
            items = new MenuListItemCollection(this);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer, true);

            AutoScroll = true;
            scrollWidth = this.Width;

            this.ButtonFont = new Font("Tahoma", 15, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(103, 103, 103);
            this.CategoryFont = new Font("Tahoma", 12, FontStyle.Regular);

            this.DetailedFont = new Font("Tahoma", 10, FontStyle.Regular);
            this.SubTextFont = new Font("Tahoma", 8, FontStyle.Regular);

            this.DetailColor = Color.FromArgb(139, 187, 212);
            this.SubTextColor = Color.FromArgb(171, 176, 179);

            this.Dock = DockStyle.Fill;
        }

        #region Variables
        int leftTitleIndent = 10;
        int iconTextIndent = 15;

        int itemModifier = 0;
        int buttonHeight = 50;
        int categoryHeight = 35;
        int buttonNumber = 0;

        int categoryIndent = 7;
        int categoryNumber = 0;

        int scrollWidth = 0;
        #endregion

        #region Properties
        MenuListItemCollection items;
        [Browsable(false), Localizable(true), Category("Behavior"), Description("Collection of menu items."), MergableProperty(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MenuListItemCollection Items
        {
            get { return items; }
            set { items = value; Invalidate(); }

        }
        Font buttonFont;
        [Browsable(true), Category("Items")]
        public Font ButtonFont
        {
            get { return buttonFont; }
            set { buttonFont = value; Invalidate(); }
        }

        Font categoryFont;
        [Browsable(true), Category("Items")]

        public Font CategoryFont
        {
            get { return categoryFont; }
            set { categoryFont = value; Invalidate(); }
        }

        Font detailedFont;
        [Browsable(true), Category("Items")]
        public Font DetailedFont
        {
            get { return detailedFont; }
            set { detailedFont = value; Invalidate(); }
        }

        Font subTextFont;
        [Browsable(true), Category("Items")]
        public Font SubTextFont
        {
            get { return subTextFont; }
            set { subTextFont = value; Invalidate(); }
        }

        Color detailColor;
        public Color DetailColor
        {
            get { return detailColor; }
            set { detailColor = value; Invalidate(); }
        }

        Color subTextColor;
        public Color SubTextColor
        {
            get { return subTextColor; }
            set { subTextColor = value; Invalidate(); }
        }

        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            categoryNumber = 0;
            buttonNumber = 0;

            itemModifier = 0;

            if (VerticalScroll.Enabled && VerticalScroll.Visible)
                scrollWidth = this.Width - 15;
            else
                scrollWidth = this.Width;

            Point pt = AutoScrollPosition;
            e.Graphics.TranslateTransform(pt.X, pt.Y);

            PaintBackground(e.Graphics);
            PaintItems(e.Graphics);

            AutoScrollMinSize = new Size(0, (buttonNumber * buttonHeight) + (categoryNumber * categoryHeight));
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            HighlightAt(e.X, e.Y);
            base.OnMouseMove(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            MenuListItem item = GetItem(e.X, e.Y);

            if (item != null)
                item.Click();

            base.OnMouseClick(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (MenuListItem item in Items)
            {
                item.isHighlighted = false;
            }
            Invalidate();
        }
        #endregion

        #region Painting
        private void PaintBackground(Graphics g)
        {
            Brush fillBrush = new SolidBrush(Color.FromArgb(50, 247, 255, 124));//(Color.FromArgb(238, 241, 243));
            g.FillRectangle(fillBrush, g.VisibleClipBounds.X, g.VisibleClipBounds.Y, g.VisibleClipBounds.Width - 1, g.VisibleClipBounds.Height - 1);

            Pen borderPen = new Pen(Color.FromArgb(50, 0, 0, 0));//(Color.FromArgb(205, 218, 227));
            g.DrawRectangle(borderPen, g.VisibleClipBounds.X, g.VisibleClipBounds.Y, g.VisibleClipBounds.Width - 1, g.VisibleClipBounds.Height - 1);
        }

        private void PaintItems(Graphics g)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (Items[i].IsCategory)
                    PaintCategory(g, Items[i]);
                else
                    PaintButton(g, Items[i]);
            }
        }

        private void PaintButton(Graphics g, MenuListItem item)
        {
            item.Rectangle = new Rectangle(1, (buttonNumber * buttonHeight) + (categoryNumber * categoryHeight)+1, scrollWidth-2, buttonHeight-1);

            buttonNumber++;

            // Draw Background
            if (itemModifier == 0)
            {
                Brush fillBrush = new SolidBrush(Color.FromArgb(100, 226, 233, 238));
                //g.FillRectangle(fillBrush, item.Rectangle);
                SwitchItemModifier();
            }
            else
            {
                //SwitchItemModifier();
            }

            if (item.isHighlighted)
            {
                Pen fillBrush = new Pen(Color.LightBlue);
                SolidBrush brush = new SolidBrush(Color.FromArgb(40, 80, 110, 9));
                g.FillRectangle(brush, item.Rectangle);
                LinearGradientBrush highlightBrush = new LinearGradientBrush(new Point(item.Rectangle.X, item.Rectangle.Y + item.Rectangle.Height), new Point(item.Rectangle.X, item.Rectangle.Y + item.Rectangle.Height - 30), Color.FromArgb(20, 255,255,255), Color.Transparent);
                //g.FillRectangle(highlightBrush, new Rectangle(item.Rectangle.X, item.Rectangle.Y + item.Rectangle.Height - 30, item.Rectangle.Width, 30));
                //g.DrawRectangle(fillBrush, item.Rectangle);
            }

            if (!item.IsDetailed)
            {
                // Draw Text
                string drawText = CalculateItemText(g, item, this.ButtonFont);

                Brush textBrush; //= new SolidBrush(Color.FromArgb(255, 85, 113, 0));
                if (item.isHighlighted)
                {
                    textBrush = new SolidBrush(Color.FromArgb(255, 125, 57, 8));//255, 50, 67, 0));//this.DetailColor);
                }
                else
                {
                    textBrush = new SolidBrush(Color.FromArgb(255, 0, 113, 209));//255, 85, 113, 0));//(255,216,255,0));
                }
                if (drawText != "...")
                    g.DrawString(drawText, this.ButtonFont, textBrush, CalculateTextPoint(g, drawText, item, this.ButtonFont, item.Rectangle.Y));

                // Icon
                if (item.Icon != null)
                    g.DrawImage((Image)item.Icon, CalculateIconPoint(g, drawText, item, item.Rectangle.Y));
            }
            else
            {
                string drawText = CalculateItemText(g, item, this.DetailedFont);
                string subText = item.SubText;
                Brush titleBrush;
                Brush subtextBrush;
                if (item.isHighlighted)
                {
                    titleBrush = new SolidBrush(Color.FromArgb(255, 125, 57, 8));//this.DetailColor);
                    subtextBrush = new SolidBrush(Color.White);
                }
                else
                {
                    titleBrush = new SolidBrush(Color.FromArgb(255, 169, 82, 18));//(255,216,255,0));
                    subtextBrush = new SolidBrush(Color.White);
                }

                if (drawText != "...")
                {
                    g.DrawString(drawText, this.DetailedFont, titleBrush, new PointF(leftTitleIndent, item.Rectangle.Y + 5));
                    if (!String.IsNullOrEmpty(subText)) 
                        g.DrawString(subText, this.SubTextFont, subtextBrush, new PointF(leftTitleIndent, item.Rectangle.Y + 22));
                }
            }
        }

        private void PaintCategory(Graphics g, MenuListItem item)
        {
            item.Rectangle = new Rectangle(0, (buttonNumber * buttonHeight) + (categoryNumber * categoryHeight), scrollWidth, categoryHeight);

            categoryNumber++;

            SizeF stringSize = g.MeasureString(item.Text, this.CategoryFont);

            // Draw Text
            string drawText = CalculateItemText(g, item, this.CategoryFont);
            Brush textBrush = new SolidBrush(Color.FromArgb(255, 85,113,0));
            if (drawText != "...")
                g.DrawString(drawText, this.CategoryFont, textBrush, CalculateTextPoint(g, drawText, item, this.CategoryFont, item.Rectangle.Y));

            // Draw Underline
            g.DrawLine(new Pen(Color.FromArgb(255, 85,113,0),1.5f),//this.ForeColor, 1.5f),
                new Point(0, item.Rectangle.Y + (int)stringSize.Height + 12),
                new Point(scrollWidth, item.Rectangle.Y + (int)stringSize.Height + 12)
                );
        }
        #endregion

        #region Mouse Selection
        private MenuListItem GetItem(int mouseX, int mouseY)
        {
            int positionizedX;
            int positionizedY;

            positionizedX = mouseX + HorizontalScroll.Value;
            positionizedY = mouseY + VerticalScroll.Value;

            Point positionizedMouse = new Point(positionizedX, positionizedY);

            foreach (MenuListItem item in Items)
            {
                if (item.Rectangle.Contains(positionizedMouse))
                {
                    return item;
                }
            }
            return null;
        }

        private void HighlightAt(int mouseX, int mouseY)
        {
            int positionizedX;
            int positionizedY;

            positionizedX = mouseX + HorizontalScroll.Value;
            positionizedY = mouseY + VerticalScroll.Value;

            Point positionizedMouse = new Point(positionizedX, positionizedY);

            foreach (MenuListItem item in Items)
            {
                if (item.Rectangle.Contains(positionizedMouse))
                {
                    HighlightItem(item);
                }
                else
                {
                    UnhighlightItem(item);
                }
            }
        }
        private void HighlightItem(MenuListItem item)
        {
            if (!item.isHighlighted)
            {
                item.isHighlighted = true; Invalidate();
            }
        }
        private void UnhighlightItem(MenuListItem item)
        {
            if (item.isHighlighted)
            {
                item.isHighlighted = false; Invalidate();
            }
        }
        #endregion

        #region Methods
        private void SwitchItemModifier()
        {
            if (itemModifier == 0)
                itemModifier = 1;
            else if (itemModifier == 1)
                itemModifier = 0;
        }


        private string CalculateItemText(Graphics g, MenuListItem item, Font font)
        {
            SizeF stringSize = g.MeasureString(item.Text, font);

            string definatetext = "";
            string trialtext = "";

            SizeF trialSize;

            if (item.Icon != null)
            {
                // The width of the control is less than the size of the text, therefore bad :(
                if (scrollWidth < leftTitleIndent + item.Icon.Width + iconTextIndent + (int)stringSize.Width)
                {
                    for (int i = 0; i < item.Text.Length - 1; i++)
                    {
                        trialtext += item.Text[i];
                        trialSize = g.MeasureString(trialtext + "...", font);

                        if (scrollWidth < leftTitleIndent + item.Icon.Width + iconTextIndent + trialSize.Width)
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
                    return item.Text;
                }
            }
            else
            {
                // The width of the control is less than the size of the text, therefore bad :(
                if (scrollWidth < leftTitleIndent + (int)stringSize.Width)
                {
                    for (int i = 0; i < item.Text.Length - 1; i++)
                    {
                        trialtext += item.Text[i];
                        trialSize = g.MeasureString(trialtext + "...", font);

                        if (scrollWidth < leftTitleIndent + trialSize.Width)
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
                    return item.Text;
                }
            }

            return null;
        }

        private PointF CalculateTextPoint(Graphics g, string text, MenuListItem item, Font font, int yPos)
        {
            SizeF stringSize = g.MeasureString(text, font);

            if (text.EndsWith("..."))
            {
                if (item.Text.EndsWith("...") && !text.EndsWith("...."))
                {
                    int width = scrollWidth;
                    float titleWidth = item.Icon.Width + iconTextIndent + stringSize.Width;
                    int x = (int)((width / 2) - (titleWidth / 2));

                    PointF point;
                    if (item.Icon != null)
                        point = new PointF(x + item.Icon.Width + iconTextIndent, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));
                    else
                        point = new PointF(x, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));

                    return point;
                }
                else if (item.Text.EndsWith("...") && text.EndsWith("...."))
                {
                    if (item.Icon != null)
                        return new PointF(leftTitleIndent + item.Icon.Width + iconTextIndent, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));
                    else
                        return new PointF(leftTitleIndent, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));
                }
                else
                {
                    if (item.IsCategory)
                        return new PointF(categoryIndent, yPos + (int)((categoryHeight / 2) - (stringSize.Height / 2)) + 8);
                    else
                    {
                        if (item.Icon != null)
                            return new PointF(leftTitleIndent + item.Icon.Width + iconTextIndent, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));
                        else
                            return new PointF(leftTitleIndent, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));
                    }
                }
            }
            else
            {
                if (item.IsCategory)
                    return new PointF(categoryIndent, yPos + (int)((categoryHeight / 2) - (stringSize.Height / 2)) + 8);
                else
                {
                    int width = scrollWidth;

                    float titleWidth;
                    if (item.Icon != null)
                        titleWidth = item.Icon.Width + iconTextIndent + stringSize.Width;
                    else
                        titleWidth = stringSize.Width;

                    int x = (int)((width / 2) - (titleWidth / 2));

                    PointF point;
                    if (item.Icon != null)
                        point = new PointF(x + item.Icon.Width + iconTextIndent, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));
                    else
                        point = new PointF(x, yPos + (int)((buttonHeight / 2) - (stringSize.Height / 2)));

                    return point;
                }
            }
        }
        private Point CalculateIconPoint(Graphics g, string text, MenuListItem item, int yPos)
        {
            SizeF stringSize = g.MeasureString(text, this.Font);

            if (text.EndsWith("..."))
            {
                if (item.Text.EndsWith("...") && !text.EndsWith("...."))
                {
                    if (text == "..." || text == "")
                    {
                        int y = (int)((buttonHeight / 2) - (item.Icon.Height / 2));
                        return new Point(leftTitleIndent, yPos + y);
                    }
                    else
                    {
                        int width = scrollWidth;
                        float titleWidth = item.Icon.Width + iconTextIndent + stringSize.Width;
                        int x = (int)((width / 2) - (titleWidth / 2));
                        int y = (int)((buttonHeight / 2) - (item.Icon.Height / 2));
                        Point point = new Point(x, yPos + y);

                        return point;
                    }
                }
                else if (item.Text.EndsWith("...") && text.EndsWith("...."))
                {
                    int y = (int)((buttonHeight / 2) - (item.Icon.Height / 2));
                    return new Point(leftTitleIndent, yPos + y);
                }
                else
                {
                    int y = (int)((buttonHeight / 2) - (item.Icon.Height / 2));
                    return new Point(leftTitleIndent, yPos + y);
                }
            }
            else
            {
                int width = scrollWidth;
                float titleWidth = item.Icon.Width + iconTextIndent + stringSize.Width;
                int x = (int)((width / 2) - (titleWidth / 2));
                int y = (int)((buttonHeight / 2) - (item.Icon.Height / 2));
                Point point = new Point(x, yPos + y);

                return point;
            }
        }
        #endregion

    }
}
