//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EGMGame
{
    public partial class StateboxControl : TreeView
    {

        public bool DrawNumbers
        {
            get { return drawNumbers; }
            set { drawNumbers = value; }
        }
        bool drawNumbers = false;

        #region Constructor
        public StateboxControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Variables
        private Image imgCollapsed;
        private Image imgExpanded;
        private Color colorCategoryBackColor;
        private Point ptCollapsedOffset;
        private Point ptExpandedOffset;
        private Point ptCategoryHeading;
        private Point ptChildImageOffset;
        #endregion

        public delegate void ClickStateItemEvent(object sender, TreeNode ca);
        public event ClickStateItemEvent ClickStateItem;

        #region Puplic Properties
        /// <summary>
        /// Get/Set the image displayed when the toolbox is collapsed.
        /// </summary>
        [CategoryAttribute("Toolbox")]
        [DescriptionAttribute("The image displayed when the toolbox is collapsed.")]
        public Image ToolboxCollapsedImage
        {
            get
            {
                return imgCollapsed;
            }
            set
            {
                imgCollapsed = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the amount to offset the collapsed image.
        /// </summary>
        [CategoryAttribute("Toolbox")]
        [DescriptionAttribute("The amount to offset the collapsed image.")]
        public Point ToolboxCollapsedImageOffset
        {
            get
            {
                return ptCollapsedOffset;
            }
            set
            {
                ptCollapsedOffset = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the image displayed when the toolbox is expanded.
        /// </summary>
        [CategoryAttribute("Toolbox")]
        [DescriptionAttribute("The image displayed with the toolbox is expanded.")]
        public Image ToolboxExpandedImage
        {
            get
            {
                return imgExpanded;
            }
            set
            {
                imgExpanded = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the amount to offset the expanded image.
        /// </summary>
        [CategoryAttribute("Toolbox")]
        [DescriptionAttribute("The amount to offset the expanded image.")]
        public Point ToolboxExpandedImageOffset
        {
            get
            {
                return ptExpandedOffset;
            }
            set
            {
                ptExpandedOffset = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the background color of the toolbox category heading.
        /// </summary>
        [CategoryAttribute("Toolbox")]
        [DescriptionAttribute("The background color of the toolbox category heading.")]
        public Color ToolboxCategoryBackColor
        {
            get
            {
                return colorCategoryBackColor;
            }
            set
            {
                colorCategoryBackColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the amount to offset the category heading text.
        /// </summary>
        [CategoryAttribute("Toolbox")]
        [DescriptionAttribute("The amount to offset the category heading text.")]
        public Point ToolboxCategoryOffset
        {
            get
            {
                return ptCategoryHeading;
            }
            set
            {
                ptCategoryHeading = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Get/Set the amount to offset the child node image.
        /// </summary>
        [CategoryAttribute("Toolbox")]
        [DescriptionAttribute("The amount to offset the child node image.")]
        public Point ToolboxChildImageOffset
        {
            get
            {
                return ptChildImageOffset;
            }
            set
            {
                ptChildImageOffset = value;
                this.Refresh();
            }
        }
        #endregion

        #region Draw Tree View
        private void Toolbox_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            try
            {
                //Get the default font
                Font defaultTreeFont = this.Font;
                // Get Mouse Over Node
                TreeNode mouseNode = this.GetNodeAt(this.PointToClient(MousePosition));
                //Draw the top level item
                if (e.Node.Level == 0)
                {
                    // If Selected
                    if (SelectedNode == e.Node)
                    {
                        Rectangle hrect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 5);
                        Color h2 = Color.FromArgb(255, 206, 237, 250);
                        Color h1 = Color.FromArgb(255, 206, 237, 250);
                        LinearGradientBrush hbackBrush = new LinearGradientBrush(hrect, h1, h2, LinearGradientMode.Horizontal);
                        e.Graphics.FillRectangle(hbackBrush, e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height - 1);
                        Brush br = new SolidBrush(Color.Black);
                        Pen pen = new Pen(Color.FromArgb(51, 153, 255));
                        e.Graphics.DrawRectangle(pen, e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height - 1);


                    }
                    try
                    {
                        Brush br = new SolidBrush(Color.Black);
                        e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(e.Bounds.X + ptChildImageOffset.X + 1, e.Bounds.Y + ptChildImageOffset.Y + 1, 12, 12));
                        //e.Graphics.DrawImageUnscaled(global::EGMGame.Properties.Resources.checkBox, e.Bounds.X + ptChildImageOffset.X + 1, e.Bounds.Y + ptChildImageOffset.Y + 1);

                        int offsetX = 2;
                        int offsetY = 1;
                        if (drawNumbers)
                        {
                            switch (e.Node.ImageIndex + 1)
                            {
                                case 0:
                                    br = new SolidBrush(Color.DarkRed);
                                    break;
                                case 1:
                                    br = new SolidBrush(Color.Red);
                                    break;
                                case 2:
                                    br = new SolidBrush(Color.OrangeRed);
                                    break;
                                case 3:
                                    br = new SolidBrush(Color.Tomato);
                                    break;
                                case 4:
                                    br = new SolidBrush(Color.DarkOrange);
                                    break;
                                case 5:
                                    br = new SolidBrush(Color.Orange);
                                    break;
                                case 6:
                                    br = new SolidBrush(Color.LimeGreen);
                                    break;
                                case 7:
                                    br = new SolidBrush(Color.ForestGreen);
                                    break;
                                case 8:
                                    br = new SolidBrush(Color.OliveDrab);
                                    break;
                                case 9:
                                    br = new SolidBrush(Color.DarkOliveGreen);
                                    break;
                                case 10:
                                    offsetX = -2;
                                    br = new SolidBrush(Color.DarkGreen);
                                    break;
                            }

                            if (e.Node.ImageKey.Length > 0)
                            {
                                if (drawNumbers)
                                {
                                    e.Graphics.DrawString((e.Node.ImageIndex + 1).ToString(), new Font(defaultTreeFont, FontStyle.Regular), br, e.Bounds.X + ptChildImageOffset.X, e.Bounds.Y + ptChildImageOffset.Y);
                                }
                                else
                                {
                                    e.Graphics.DrawImageUnscaled(ImageList.Images[e.Node.ImageKey], e.Bounds.X + ptChildImageOffset.X, e.Bounds.Y + ptChildImageOffset.Y);
                                }
                            }
                            else if (e.Node.ImageIndex > -1)
                            {
                                if (drawNumbers)
                                {
                                    e.Graphics.DrawString((e.Node.ImageIndex + 1).ToString(), new Font(defaultTreeFont, FontStyle.Bold), br, e.Bounds.X + ptChildImageOffset.X + offsetX, e.Bounds.Y + ptChildImageOffset.Y + offsetY);
                                }
                                else
                                {
                                    Image img;
                                    if (e.Node.ImageIndex == 0)
                                        img = EGMGame.Properties.Resources.inflictState;
                                    else if (e.Node.ImageIndex == 1)
                                        img = EGMGame.Properties.Resources.removeState;
                                    else
                                        img = global::EGMGame.Properties.Resources.defaultState;
                                    e.Graphics.DrawImageUnscaled(img, e.Bounds.X + ptChildImageOffset.X, e.Bounds.Y + ptChildImageOffset.Y);
                                }
                            }
                        }
                        else
                        {
                            if (!drawNumbers)
                            {
                                Image img;
                                if (e.Node.ImageIndex == 0)
                                    img = EGMGame.Properties.Resources.inflictState;
                                else if (e.Node.ImageIndex == 1)
                                    img = EGMGame.Properties.Resources.removeState;
                                else
                                    img = global::EGMGame.Properties.Resources.defaultState;
                                e.Graphics.DrawImageUnscaled(img, e.Bounds.X + ptChildImageOffset.X, e.Bounds.Y + ptChildImageOffset.Y);
                            }
                        }
                    }
                    catch
                    {
                        //Catch any errors, but do not provide feedback
                    }
                    finally
                    {
                        //Draw the node with a bold style
                        e.Node.NodeFont = new Font(defaultTreeFont, FontStyle.Regular);
                        e.Graphics.DrawString(e.Node.Text, e.Node.NodeFont, Brushes.Black, e.Bounds.X + ptCategoryHeading.X, e.Bounds.Y + ptCategoryHeading.Y);
                    }
                }
                //Draw Child Node
                else
                {
                    try
                    {
                        // If Selected
                        if (SelectedNode == e.Node)
                        {
                            Rectangle hrect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 5);
                            Color h2 = Color.FromArgb(255, 206, 237, 250);
                            Color h1 = Color.FromArgb(255, 206, 237, 250);
                            LinearGradientBrush hbackBrush = new LinearGradientBrush(hrect, h1, h2, LinearGradientMode.Horizontal);
                            e.Graphics.FillRectangle(hbackBrush, e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height - 1);
                            Brush br = new SolidBrush(Color.Black);
                            Pen pen = new Pen(Color.FromArgb(51, 153, 255));
                            e.Graphics.DrawRectangle(pen, e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height - 1);
                        }
                        //Check if an image exists and draw
                        if (this.ImageList != null)
                        {
                            if (e.Node.ImageKey.Length > 0)
                            {
                                e.Graphics.DrawImageUnscaled(ImageList.Images[e.Node.ImageKey], e.Bounds.X + ptChildImageOffset.X, e.Bounds.Y + ptChildImageOffset.Y);
                            }
                            else if (e.Node.ImageIndex != -1)
                            {
                                e.Graphics.DrawImageUnscaled(ImageList.Images[e.Node.ImageIndex], e.Bounds.X + ptChildImageOffset.X, e.Bounds.Y + ptChildImageOffset.Y);

                            }
                        }
                    }
                    catch
                    {
                        //Catch any errors, but do not provide feedback
                    }
                    finally
                    {
                        //Draw the text of the node
                        e.Node.NodeFont = new Font(defaultTreeFont, FontStyle.Regular);
                        e.Graphics.DrawString(e.Node.Text, e.Node.NodeFont, Brushes.Black, e.Bounds.X + Indent, e.Bounds.Y + 3);
                    }
                }
            }
            catch
            {
                //Catch any errors, but do not provide feedback
            }
        }
        #endregion

        #region"Events"

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Refresh();

            TreeNode node = this.GetNodeAt(e.Location);

            if (node != null)
            {
                Rectangle rect = new Rectangle(ptChildImageOffset.X + 1, node.Bounds.Y + ptChildImageOffset.Y + 1, 12, 12);

                if (rect.Contains(e.Location))
                {
                    if (ClickStateItem != null)
                        ClickStateItem(this, node);
                }
            }
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            base.OnBeforeSelect(e);
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
        }
        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    this.Refresh();
        //}

        //protected override void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
        //{
        //    base.OnNodeMouseHover(e);
        //    this.Refresh();
        //}

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    this.Refresh();
        //}
        #endregion
    }
}
