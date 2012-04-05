/* -----------------------------
 * NewsMenuList - Needs Work
 * -----------------------------
 * Purpose:             This the class that holds Home Page menu items for News.
 * Most Used By:        HomePage.cs
 * Associated Files:    MenuContainer.cs, NewsMenuListItem.cs, NewsMenuListItemCollection.cs
 * Modify:              When you want to modify the ways News are displayed.
 */
//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Collections;
using System.Xml;
using System.IO;
using System.Net;

namespace EGMGame.Docking.Homepage
{
    [Serializable]
    public class NewsMenuList : ScrollableControl
    {
        public NewsMenuList()
        {
            items = new NewsMenuListItemCollection(this);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer, true);

            AutoScroll = true;
            scrollWidth = this.Width;

            this.ButtonFont = new Font("Verdana", 15, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(103, 103, 103);
            this.CategoryFont = new Font("Verdana", 12, FontStyle.Regular);

            this.DetailedFont = new Font("Verdana", 10, FontStyle.Regular);
            this.SubTextFont = new Font("Verdana", 8, FontStyle.Regular);

            this.ErrorFont = new Font("Verdana", 8, FontStyle.Regular);

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

        bool GettingFeed = false;
        bool FeedError = false;

        bool doublec = false;
        int mouseX;
        int mouseY;
        #endregion

        #region Properties
        NewsMenuListItemCollection items;
        [Browsable(false), Localizable(true), Category("Behavior"), Description("Collection of menu items."), MergableProperty(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NewsMenuListItemCollection Items
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

        Font errorFont;
        [Browsable(true), Category("Items")]
        public Font ErrorFont
        {
            get { return errorFont; }
            set { errorFont = value; Invalidate(); }
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

        bool hasFeed;
        public bool HasFeed
        {
            get { return hasFeed; }
            set { hasFeed = value; }
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
            if (HasFeed)
                PaintItems(e.Graphics);
            else
            {
                if (FeedError)
                {
                    PaintError(e.Graphics);
                }
                else if (GettingFeed)
                {
                    PaintLoading(e.Graphics);
                }

            }

            AutoScrollMinSize = new Size(0, (buttonNumber * buttonHeight) + (categoryNumber * categoryHeight));
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            HighlightAt(e.X, e.Y);
            base.OnMouseMove(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!FeedError)
            {
                NewsMenuListItem item = GetItem(e.X, e.Y);

                if (item != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        mouseX = e.X;
                        mouseY = e.Y;
                        doublec = true;

                        if (item.IsExpanded)
                            item.IsExpanded = false;
                        else
                            item.IsExpanded = true;
                        this.Invalidate();
                    }                    
                }
            }
            else
            {
                GetFeed();
            }

            base.OnMouseClick(e);
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            if (!FeedError && mouseX != null && mouseY != null && doublec)
            {
                NewsMenuListItem item = GetItem(mouseX, mouseY);
                item.IsExpanded = true;

                string URL = item.URL;

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
                Invalidate();
            }
            base.OnDoubleClick(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (NewsMenuListItem item in Items)
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
        private void PaintError(Graphics g)
        {
            string line1 = "An error occurred when obtaining the feed.";
            string line2 = "Please check your network connection.";
            string line3 = "Click here to try again.";

            int line2y = (int)(g.MeasureString(line1,this.ErrorFont).Height + 5);
            int line3y = (int)(line2y + g.MeasureString(line2, this.ErrorFont).Height + 5);

            SolidBrush b = new SolidBrush(this.DetailColor);

            g.DrawString(line1,this.ErrorFont,b,new PointF(5,5));
            g.DrawString(line2, this.ErrorFont, b, new PointF(5, 5 + line2y));
            g.DrawString(line3, this.ErrorFont, b, new PointF(5, 5 + line3y));
        }
        private void PaintLoading(Graphics g)
        {
            string line1 = "Loading Feed...";

            SolidBrush b = new SolidBrush(this.DetailColor);

            g.DrawString(line1, this.ErrorFont, b, new PointF(5, 5));
        }
        private void PaintItems(Graphics g)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (!Items[i].IsCategory)
                    PaintButton(g, Items[i]);
            }
        }

        private void PaintButton(Graphics g, NewsMenuListItem item)
        {
            string drawText = CalculateItemText(g, item, this.DetailedFont, true);
            string subText = CalculateItemText(g, item, this.DetailedFont, false);

            if(!item.IsExpanded)
            {
                int heightSoFar = 0;
                for (int i = 0; i < buttonNumber; i++)
                {
                    heightSoFar += this.Items[i].Rectangle.Height;
                }
                item.Rectangle = new Rectangle(0, heightSoFar, scrollWidth, buttonHeight);
            }                
            else
            {
                int heightSoFar = 0;
                for(int i = 0; i < buttonNumber; i++)
                {
                    heightSoFar += this.Items[i].Rectangle.Height;
                }

                int thisHeight = buttonHeight;
                float stringHeight = g.MeasureString(subText, this.DetailedFont).Height;
                int heightDifference = (int)Math.Abs((buttonHeight - 20) - stringHeight);
                thisHeight += heightDifference;
                item.Rectangle = new Rectangle(0, heightSoFar, scrollWidth, thisHeight);
            }


            buttonNumber++;

            // Draw Background
            if (itemModifier == 0)
            {
                Brush fillBrush = new SolidBrush(Color.FromArgb(226, 233, 238));
                g.FillRectangle(fillBrush, item.Rectangle);
                SwitchItemModifier();
            }
            else
            {
                //SwitchItemModifier();
            }

            if (item.isHighlighted)
            {
                Brush fillBrush = new SolidBrush(Color.LightBlue);
                g.FillRectangle(fillBrush, item.Rectangle);
            }

            Brush titleBrush = new SolidBrush(this.DetailColor);
            Brush subtextBrush = new SolidBrush(this.SubTextColor);

            if (drawText != "...")
            {
                if (!String.IsNullOrEmpty(drawText)) g.DrawString(drawText, this.DetailedFont, titleBrush, new PointF(leftTitleIndent, item.Rectangle.Y + 5));
                if (!String.IsNullOrEmpty(subText)) g.DrawString(subText, this.SubTextFont, subtextBrush, new PointF(leftTitleIndent, item.Rectangle.Y + 20));
            }
        }
        #endregion

        #region Mouse Selection
        private NewsMenuListItem GetItem(int mouseX, int mouseY)
        {
            int positionizedX;
            int positionizedY;

            positionizedX = mouseX + VerticalScroll.Value;
            positionizedY = mouseY + HorizontalScroll.Value;

            Point positionizedMouse = new Point(positionizedX, positionizedY);

            foreach (NewsMenuListItem item in Items)
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

            positionizedX = mouseX + VerticalScroll.Value;
            positionizedY = mouseY + HorizontalScroll.Value;

            Point positionizedMouse = new Point(positionizedX, positionizedY);

            foreach (NewsMenuListItem item in Items)
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
        private void HighlightItem(NewsMenuListItem item)
        {
            if (!item.isHighlighted)
            {
                item.isHighlighted = true; Invalidate();
            }
        }
        private void UnhighlightItem(NewsMenuListItem item)
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


        private string CalculateItemText(Graphics g, NewsMenuListItem item, Font font, bool IsTitle)
        {
            SizeF stringSize;
            if(IsTitle)
                stringSize = g.MeasureString(item.Text, font);
            else
                stringSize = g.MeasureString(item.SubText, font);

            string definatetext = "";
            string trialtext = "";

            SizeF trialSize;
            if (IsTitle)
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
            else
            {
                if (!item.IsExpanded)
                {
                    // The width of the control is less than the size of the text, therefore bad :(
                    if (scrollWidth < leftTitleIndent + (int)stringSize.Width)
                    {
                        for (int i = 0; i < item.SubText.Length - 1; i++)
                        {
                            trialtext += item.SubText[i];
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
                        return item.SubText;
                    }
                }
                else
                {
                    // The width of the control is less than the size of the text, therefore bad :(
                    if (scrollWidth < leftTitleIndent + (int)stringSize.Width)
                    {
                        for (int i = 0; i < item.SubText.Length - 1; i++)
                        {
                            trialtext += item.SubText[i];
                            trialSize = g.MeasureString(trialtext + "...", font);

                            if (scrollWidth < leftTitleIndent + trialSize.Width)
                            {
                                trialtext += "\r\n";
                                definatetext = trialtext;
                                continue;
                            }
                            else
                            {
                                definatetext = trialtext;
                                continue;
                            }
                        }
                        return definatetext;
                    }
                    else
                    {
                        return item.Text;
                    }
                }
            }

            return null;
        }

        private PointF CalculateTextPoint(Graphics g, string text, NewsMenuListItem item, Font font, int yPos)
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
        private Point CalculateIconPoint(Graphics g, string text, NewsMenuListItem item, int yPos)
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

        internal void GetFeed()
        {
            //string xmlsrc = "http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/technology/rss.xml";
            ////string Password = "xxxxx";
            ////string UserAccount = "xxxxx";
            ////string DomainName = "xxxxx";
            ////string ProxyServer = "192.168.1.1:8080";

            //this.GettingFeed = true;
            //this.FeedError = false;
            //this.HasFeed = false;
            //this.Invalidate();

            //// make remote request
            //HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(xmlsrc);

            //// set the HTTP properties
            //wr.Timeout = 10000;

            //BackgroundWorker feeder = new BackgroundWorker();
            //feeder.DoWork += new DoWorkEventHandler(feeder_DoWork);
            //feeder.RunWorkerCompleted += new RunWorkerCompletedEventHandler(feeder_RunWorkerCompleted);
            //feeder.WorkerReportsProgress = true;
            //feeder.RunWorkerAsync(wr);
        }

        void feeder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null && e.Cancelled != true)
            {
                NewsMenuList list = (NewsMenuList)e.Result;
                //NewsMenuListItemCollection collection = new NewsMenuListItemCollection((NewsMenuList)e.Result);
                foreach (NewsMenuListItem i in list.Items)
                {
                    this.Items.Add(i);
                }
                this.Invalidate();
            }
            else
            {
                FeedError = true;
                GettingFeed = false;                
                this.Invalidate();
            }
        }

        private void feeder_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = FeedWeb((HttpWebRequest)e.Argument, worker, e);            
        }
        private NewsMenuList FeedWeb(HttpWebRequest wr, BackgroundWorker worker, DoWorkEventArgs e)
        {
            NewsMenuList list = new NewsMenuList();

            XmlNode nodeRss = null;
            XmlNode nodeChannel = null;
            XmlNode nodeItem = null;
            NewsMenuListItem rowNews;

            try
            {
                // read the response
                WebResponse resp = wr.GetResponse();

                Stream stream = resp.GetResponseStream();

                // load XML document
                XmlTextReader reader = new XmlTextReader(stream);
                reader.XmlResolver = null;
                XmlDocument rssDoc = new XmlDocument();
                rssDoc.Load(reader);

                // Loop for the <rss> tag
                for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
                {
                    // If it is the rss tag
                    if (rssDoc.ChildNodes[i].Name == "rss")
                    {
                        // <rss> tag found
                        nodeRss = rssDoc.ChildNodes[i];
                    }
                }

                // Loop for the <channel> tag
                for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
                {
                    // If it is the channel tag
                    if (nodeRss.ChildNodes[i].Name == "channel")
                    {
                        // <channel> tag found
                        nodeChannel = nodeRss.ChildNodes[i];
                    }
                }

                // Loop for the <title>, <link>, <description> and all the other tags
                for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
                {
                    // If it is the item tag, then it has children tags which we will add as items to the ListView
                    if (nodeChannel.ChildNodes[i].Name == "item")
                    {
                        nodeItem = nodeChannel.ChildNodes[i];

                        // Create a new row in the ListView containing information from inside the nodes
                        rowNews = new NewsMenuListItem();
                        rowNews.Text = nodeItem["title"].InnerText;
                        rowNews.SubText = nodeItem["description"].InnerText;
                        rowNews.URL = nodeItem["link"].InnerText;
                        list.Items.Add(rowNews);
                    }
                }

                FeedError = false;
                GettingFeed = false;
                HasFeed = true;
                worker.ReportProgress(100);
                return list;
            }
            catch (System.Exception ex)
            {
                FeedError = true;
                GettingFeed = false;
                e.Cancel = true;
                return null;
            }
        }
        #endregion

    }
}
