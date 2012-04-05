//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EGMGame.Controls
{
    public partial class AddRemoveListTreeView : TreeView
    {
        public bool Category
        {
            get { return category; }
            set { category = value; }
        }
        bool category = false;

        public bool MultipleSelection
        {
            get { return allowMulti; }
            set { allowMulti = value; }
        }
        bool allowMulti = false;

        protected ArrayList m_coll = new ArrayList();
        protected TreeNode m_lastNode, m_firstNode;

        public ArrayList SelectedNodes
        {
            get
            {
                return m_coll;
            }
            set
            {
                m_coll.Clear();
                m_coll = value;
            }
        }

        bool shift;
        bool ctrl;

        #region Class Variables
        private Image imgCollapsed;
        private Image imgExpanded;
        private Color colorCategoryBackColor;
        private Point ptCollapsedOffset;
        private Point ptExpandedOffset;
        private Point ptCategoryHeading;
        private Point ptChildImageOffset;
        #endregion

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

        public AddRemoveListTreeView()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg != 515)
                base.DefWndProc(ref m);
        }// class members

        #region Draw Tree View

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            //base.OnDrawNode(e);

            //if (e.Node == this.SelectedNode)
            //{
            //    SolidBrush brush = new SolidBrush(Color.Blue);
            //    Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            //    e.Graphics.FillRectangle(brush, rect);
            //}
            try
            {
                int indent2 = 0;

                //Get the default font
                Font defaultTreeFont = this.Font;
                // Get Mouse Over Node
                TreeNode mouseNode = this.GetNodeAt(this.PointToClient(MousePosition));
                //Draw the top level item
                if (e.Node.Level == 0 && category)
                {
                    Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);
                    Color colourend = Color.FromArgb(226, 226, 226);//Color.FromArgb(255, 205, 210, 224);
                    Color colourbegin = Color.FromArgb(216, 216, 216);//Color.FromArgb(255, 244, 247, 252);
                    Color borderColour = Color.FromArgb(181, 181, 181);
                    if (e.Node == SelectedNode)
                    {
                        colourend = Color.FromArgb(203, 229, 162);
                        colourbegin = Color.FromArgb(189, 225, 140);
                        borderColour = Color.FromArgb(155, 177, 119);
                    }
                    if (rect.Width == 0) rect.Width = 1;
                    LinearGradientBrush backBrush = new LinearGradientBrush(rect, colourbegin, colourend, LinearGradientMode.Vertical);
                    e.Graphics.FillRectangle(backBrush, rect);
                    e.Graphics.DrawRectangle(new Pen(borderColour), rect);

                    try
                    {
                        //Only add images if node has children
                        if (e.Node.Nodes.Count > 0 && imgCollapsed != null && e.Node.Nodes.Count > 0)
                        {
                            //Add the appropriate image to the node
                            if (e.Node.IsExpanded == false)
                            {
                                e.Graphics.DrawImage(Properties.Resources.GroupBoxRestore, new Rectangle(e.Bounds.X + ptCollapsedOffset.X, e.Bounds.Y + 1 + ptCollapsedOffset.Y, 10, 10));
                            }
                            else
                            {
                                e.Graphics.DrawImage(Properties.Resources.GroupBoxCollapse, new Rectangle(e.Bounds.X + ptExpandedOffset.X, e.Bounds.Y + 1 + ptExpandedOffset.Y, 10, 10));
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
                        if (!e.Node.IsEditing)
                        {
                            e.Node.NodeFont = new Font(defaultTreeFont, FontStyle.Regular);
                            e.Graphics.DrawString(e.Node.Text, e.Node.NodeFont, Brushes.Black, e.Bounds.X + ptCategoryHeading.X, e.Bounds.Y + ptCategoryHeading.Y + 1);
                        }
                    }
                }
                //Draw Child Node
                else
                {
                    try
                    {
                        // If Selected
                        if (SelectedNode == e.Node || SelectedNodes.Contains(e.Node))
                        {
                            //e.Node.Bounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                            Rectangle hrect = new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 3, e.Bounds.Height - 1);
                            if (hrect.Width > 0 && hrect.Height > 0)
                            {
                                Color h1 = Color.FromArgb(255, 206, 237, 250);
                                SolidBrush hbackBrush = new SolidBrush(h1);
                                e.Graphics.FillRectangle(hbackBrush, hrect);
                                Brush br = new SolidBrush(Color.Black);
                                Pen pen = new Pen(Color.FromArgb(51, 153, 255));
                                e.Graphics.DrawRectangle(pen, hrect);
                            }
                        }
                        //Check if an image exists and draw
                        if (this.ImageList != null)
                        {
                            if (e.Node.ImageKey.Length > 0)
                            {
                                e.Graphics.DrawImageUnscaled(ImageList.Images[e.Node.ImageKey], e.Bounds.X + ptChildImageOffset.X + ImageList.Images[e.Node.ImageKey].Width + Indent, e.Bounds.Y + ptChildImageOffset.Y);
                                indent2 = ImageList.Images[e.Node.ImageKey].Width;
                            }
                            else if (e.Node.ImageIndex != -1)
                            {
                                e.Graphics.DrawImageUnscaled(ImageList.Images[e.Node.ImageIndex], e.Bounds.X + ptChildImageOffset.X + Indent, e.Bounds.Y + ptChildImageOffset.Y);
                                indent2 = ImageList.Images[e.Node.ImageIndex].Width;
                            }
                        }
                    }
                    catch
                    {
                        //Catch any errors, but do not provide feedback
                    }
                    finally
                    {
                        if (this.CheckBoxes)
                            indent2 += 10;

                        if (this.CheckBoxes)
                        {
                            if (!e.Node.Checked)
                            {
                                e.Graphics.DrawImageUnscaled(imgCollapsed, e.Bounds.X + ptCollapsedOffset.X, e.Bounds.Y + ptCollapsedOffset.Y);
                            }
                            else
                            {
                                e.Graphics.DrawImageUnscaled(imgExpanded, e.Bounds.X + ptExpandedOffset.X, e.Bounds.Y + ptExpandedOffset.Y);
                            }
                        }

                        if (!e.Node.IsEditing)
                        {
                            //Draw the text of the node
                            e.Node.NodeFont = new Font(defaultTreeFont, FontStyle.Regular);
                            if (category)
                                e.Graphics.DrawString(e.Node.Text, e.Node.NodeFont, Brushes.Black, e.Bounds.X + Indent + indent2, e.Bounds.Y + 4);
                            else
                            {
                                float x = e.Node.NodeFont.GetHeight();
                                e.Graphics.DrawString(e.Node.Text, e.Node.NodeFont, Brushes.Black, e.Bounds.X + indent2 + 10, e.Bounds.Y + 2);
                            }
                        }
                    }
                }
            }
            catch
            {
                //Catch any errors, but do not provide feedback
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            TreeNode n = this.GetNodeAt(e.Location);

            if (n != null)
            {
                this.SelectedNode = n;

                Refresh();
            }
        }
        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            base.OnBeforeSelect(e);

            if (allowMulti)
            {
                bool bControl = (ModifierKeys == Keys.Control);
                bool bShift = (ModifierKeys == Keys.Shift);

                // selecting twice the node while pressing CTRL ?
                if (bControl && m_coll.Contains(e.Node))
                {
                    // unselect it (let framework know we don't want selection this time)
                    e.Cancel = true;

                    // update nodes
                    m_coll.Remove(e.Node);
                    return;
                }

                if (!bShift) m_firstNode = e.Node; // store begin of shift sequence
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (this.SelectedNode != null)
            {
                if (this.SelectedNode.Parent == null)
                    if (this.SelectedNode.IsExpanded)
                        this.SelectedNode.Collapse();
                    else
                        this.SelectedNode.Expand();
            }
        }
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
            try
            {
                if (allowMulti)
                {
                    bool bControl = (ModifierKeys == Keys.Control);
                    bool bShift = (ModifierKeys == Keys.Shift);

                    if (bControl)
                    {
                        if (!m_coll.Contains(e.Node)) // new node ?
                        {
                            m_coll.Add(e.Node);
                        }
                        else  // not new, remove it from the collection
                        {
                            m_coll.Remove(e.Node);
                        }
                    }
                    else
                    {
                        // SHIFT is pressed
                        if (bShift)
                        {
                            Queue myQueue = new Queue();

                            TreeNode uppernode = m_firstNode;
                            TreeNode bottomnode = e.Node;
                            // case 1 : begin and end nodes are parent
                            bool bParent = isParent(m_firstNode, e.Node); // is m_firstNode parent (direct or not) of e.Node
                            if (!bParent)
                            {
                                bParent = isParent(bottomnode, uppernode);
                                if (bParent) // swap nodes
                                {
                                    TreeNode t = uppernode;
                                    uppernode = bottomnode;
                                    bottomnode = t;
                                }
                            }
                            if (bParent)
                            {
                                TreeNode n = bottomnode;
                                while (n != uppernode.Parent)
                                {
                                    if (!m_coll.Contains(n)) // new node ?
                                        myQueue.Enqueue(n);

                                    n = n.Parent;
                                }
                            }
                            // case 2 : nor the begin nor the end node are descendant one another
                            else
                            {
                                if ((uppernode.Parent == null && bottomnode.Parent == null) || (uppernode.Parent != null && uppernode.Parent.Nodes.Contains(bottomnode))) // are they siblings ?
                                {
                                    int nIndexUpper = uppernode.Index;
                                    int nIndexBottom = bottomnode.Index;
                                    if (nIndexBottom < nIndexUpper) // reversed?
                                    {
                                        TreeNode t = uppernode;
                                        uppernode = bottomnode;
                                        bottomnode = t;
                                        nIndexUpper = uppernode.Index;
                                        nIndexBottom = bottomnode.Index;
                                    }

                                    TreeNode n = uppernode;
                                    while (nIndexUpper <= nIndexBottom)
                                    {
                                        if (!m_coll.Contains(n)) // new node ?
                                            myQueue.Enqueue(n);

                                        n = n.NextNode;

                                        nIndexUpper++;
                                    } // end while

                                }
                                else
                                {
                                    if (!m_coll.Contains(uppernode)) myQueue.Enqueue(uppernode);
                                    if (!m_coll.Contains(bottomnode)) myQueue.Enqueue(bottomnode);
                                }
                            }

                            m_coll.AddRange(myQueue);

                            m_firstNode = e.Node; // let us chain several SHIFTs if we like it
                        } // end if m_bShift
                        else
                        {
                            // in the case of a simple click, just add this item
                            if (m_coll != null && m_coll.Count > 0)
                            {
                                m_coll.Clear();
                            }
                            m_coll.Add(e.Node);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        #endregion
        // Helpers
        protected bool isParent(TreeNode parentNode, TreeNode childNode)
        {
            if (parentNode == childNode)
                return true;

            TreeNode n = childNode;
            bool bFound = false;
            while (!bFound && n != null)
            {
                n = n.Parent;
                bFound = (n == parentNode);
            }
            return bFound;
        }
    }
}
