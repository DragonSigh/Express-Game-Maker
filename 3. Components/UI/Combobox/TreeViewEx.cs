// Author: Vlad Untu/Asterix Software
// For updates: http://www.asterixsoft.ro/dyn/open/treeview_filter/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;

namespace EGMGame.Controls
{
    [DefaultProperty("Nodes")]
    public partial class TreeViewEx : ScrollableControl {
        public const int MinFilterWidth = 150;
        public const int MinFilterPadding = 5;

        bool can_draw = true;
        bool dirty_flag = true;
        Point translation = new Point(0, 0);
        Size content_size = new Size(0, 0);

        internal Size GlyphSize = new Size(15, 9);

        ImageList image_list;
        TreeNodeEx root_node;
        TreeNodeEx selected_node;
        ComponentResourceManager resources = new ComponentResourceManager(typeof(TreeViewEx));
        VisualStyleRenderer vsr;

        public event EventHandler<TreeNodeExMouseClickEventArgs> NodeClick;
        public event EventHandler<TreeNodeExMouseClickEventArgs> NodeDoubleClick;
        public event EventHandler<TreeNodeExExpandEvent> BeforeExpand;

        #region Constructor
        public TreeViewEx() {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.ContainerControl, false);

            this.AutoScroll = true;

            this.BackColor = SystemColors.Window;

            root_node = new TreeNodeEx(this);
            if (Application.RenderWithVisualStyles)
                 vsr = new VisualStyleRenderer(VisualStyleElement.TextBox.TextEdit.Normal);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams p = base.CreateParams;
                p.ClassName = "SysTreeView32";
                p.ClassStyle = 8;
                p.ExStyle = 512;
                p.Style = 1442914336;
                return p;
            }
        }
        #endregion

        #region Events

        #region Mouse Events
        TreeNodeEx internal_selected_node = null;

        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_RBUTTONDBLCLK = 0x0206;

        /*#define GET_X_LPARAM(lp) ((int)(short)LOWORD(lp))
        #define GET_Y_LPARAM(lp) ((int)(short)HIWORD(lp))*/

        /*#define LOWORD(l) ((WORD)((DWORD_PTR)(l) & 0xffff))
        #define HIWORD(l) ((WORD)((DWORD_PTR)(l) >> 16))*/

        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_RBUTTONDOWN) {
                OnMouseDown(new MouseEventArgs(MouseButtons.Right, 1,
                    m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16, 0));
                return;
            }
            else
                base.WndProc(ref m);
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            Rectangle mouse = new Rectangle(e.X, e.Y, 1, 1);
            foreach (TreeNodeEx node in this.Nodes) {
                Rectangle node_bounds = node.Bounds;
                Rectangle scr_node_bounds = NodeToScreenBounds(node_bounds);

                if (scr_node_bounds.IntersectsWith(mouse)) {
                    if (e.X < node_bounds.X + GlyphSize.Width && e.X > node_bounds.X) {
                        if (node.IsExpandable && e.Button == MouseButtons.Left) {
                            if (node.IsExpanded)
                                node.Collapse();
                            else
                                node.Expand();
                            dirty_flag = true;
                        }
                    }
                    else
                        InternalOnNodeMouseClick(new TreeNodeExMouseClickEventArgs(node, e), e.X);

                    break;
                }
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            internal_selected_node = null;
            base.OnMouseUp(e);
        }

        protected override void OnDoubleClick(EventArgs e) {
            if (internal_selected_node != null && NodeDoubleClick != null)
                NodeDoubleClick(this, 
                    new TreeNodeExMouseClickEventArgs(internal_selected_node));

            base.OnDoubleClick(e);
        }

        private void InternalOnNodeMouseClick(TreeNodeExMouseClickEventArgs e, int offset) {
            if (!e.Node.IsSelected)
                this.SelectedNode = e.Node;
            else if (e.Node.FilterNode != null)
                this.InvalidateNode(e.Node);

            internal_selected_node = e.Node;

            this.Focus();
            OnNodeMouseClick(e);
        }

        protected virtual void OnNodeMouseClick(TreeNodeExMouseClickEventArgs e) {
            if (NodeClick != null)
                NodeClick(this, e);

        }
        #endregion

        #region Paint Events
        protected override void OnPaint(PaintEventArgs e) {
            DateTime start = DateTime.Now;
         
            translation.X = this.AutoScrollPosition.X;
            translation.Y = this.AutoScrollPosition.Y;
            if (!can_draw) return;

            e.Graphics.TranslateTransform(translation.X, translation.Y);

            Rectangle bounds = Rectangle.Empty;

            content_size.Width = 0;

            foreach (TreeNodeEx n in this.Nodes) {
                if (dirty_flag) n.SetDirty();

                bounds = n.Bounds;

                if (bounds.Right > content_size.Width) content_size.Width = bounds.Right + TextOffset;

                Rectangle node_screen_bounds = NodeToScreenBounds(bounds, n.NodeType == NodeType.Filter);

                if (n.NodeType == NodeType.Filter)
                    ;//draw_filter_node(e.Graphics, n, bounds);
                else
                    if (e.ClipRectangle.IntersectsWith(node_screen_bounds))
                        draw_normal_node(e.Graphics, n, bounds);
            }

            dirty_flag = false;

            content_size.Height = bounds.Bottom;
            this.AutoScrollMinSize = content_size;

            Rectangle remain = new Rectangle(0, bounds.Bottom, this.Width, this.Height - bounds.Bottom);

            if (e.ClipRectangle.IntersectsWith(remain)) {
                if (remain.Contains(e.ClipRectangle))
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.ClipRectangle);
                else
                    e.Graphics.FillRectangle(SystemBrushes.Window, remain);
            }

            TimeSpan time = DateTime.Now - start;

            base.OnPaint(e);
        }
        #endregion

        #region Keyboard Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (this.Nodes.Count == 0)
                return base.ProcessCmdKey(ref msg, keyData);

            if (SelectedNode == null) SelectedNode = this.Nodes[0];

            if (keyData == Keys.Right) {
                if (SelectedNode.IsExpanded)
                    SelectedNode = SelectedNode.Nodes[0];
                else
                    SelectedNode.Expand();
                return true;
            }
            else if (keyData == Keys.Left) {
                if (SelectedNode.IsExpanded)
                    SelectedNode.Collapse();
                else {
                    TreeNodeEx parent = SelectedNode.ParentNode;

                    if (parent != null) {
                        SelectedNode = parent;
                    }
                }
                return true;
            }
            else if (keyData == Keys.Up) {
                TreeNodeEx parent = SelectedNode.ParentNode;
                
                if (SelectedNode.NodeIndex > 0) {
                    TreeNodeEx new_node = parent.Nodes[SelectedNode.NodeIndex - 1];
                    
                    while (new_node.IsExpanded) {
                        new_node = new_node.Nodes[new_node.Nodes.Length - 1];
                    }

                    SelectedNode = new_node;
                }
                else if (parent.ParentNode != null) //do not select root node
                    SelectedNode = parent;
                return true;
            }
            else if(keyData == Keys.Down) {
                if (SelectedNode.IsExpanded) {
                    SelectedNode = SelectedNode.Nodes[0];
                }
                else {
                    TreeNodeEx parent = SelectedNode.ParentNode;

                    if (SelectedNode.NodeIndex < parent.Nodes.Length - 1) {
                        SelectedNode = parent.Nodes[SelectedNode.NodeIndex + 1];
                    }
                    else if (SelectedNode.NodeIndex == parent.Nodes.Length - 1) {                      
                        while (parent.ParentNode != null &&
                               parent.NodeIndex == parent.ParentNode.Nodes.Length - 1) {

                            parent = parent.ParentNode;
                        }

                        if (parent.ParentNode != null)
                            SelectedNode = parent.ParentNode.Nodes[parent.NodeIndex + 1];
                    }
                    else
                        SelectedNode = parent.Nodes[parent.Nodes.Length - 1];
                        
                
                }   
                return true;
            }
            else if (keyData == Keys.Enter && this.Focused) {
                if (NodeDoubleClick != null)
                    NodeDoubleClick(this, new TreeNodeExMouseClickEventArgs(SelectedNode));

                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ScrollNodeIntoView(TreeNodeEx node) {
            /*if (selected_node.Bounds.IntersectsWith(ClientRectangle)) {
            SetDisplayRectLocation(DisplayRectangle.X, selected_node.Bounds.Y * -1);
            AdjustFormScrollbars(true);
            }*/
            ScrollRectIntoView(node.Bounds);
        }

        private void ScrollRectIntoView(Rectangle r) {
            Rectangle screen_bounds = NodeToScreenBounds(r);

            if (!ClientRectangle.Contains(screen_bounds)) {
                int offset = /*selected_node.Bounds*/r.Bottom - ClientRectangle.Bottom;

                SetDisplayRectLocation(DisplayRectangle.X, 
                    ((offset > 0) ? offset : /*selected_node.Bounds*/r.Top) * -1);

                AdjustFormScrollbars(true);
            }
        }
        #endregion

        #endregion

        #region Internal Methods
        void draw_filter_node(Graphics g, TreeNodeEx node, Rectangle bounds) {
            Padding padding = new Padding(5); 

            string text = string.Format("Search in: {0}", node.ParentNode.Text);

            if (node.IsSelected) {
                g.FillRectangle(SystemBrushes.Highlight, bounds);

                bounds.Offset(padding.All, 0);
                g.DrawString(text, node.Font, SystemBrushes.HighlightText, bounds);
            }
            else {
                g.FillRectangle(SystemBrushes.Control, bounds);

                bounds.Offset(padding.All, 0);
                g.DrawString(text, node.Font, SystemBrushes.ControlText, bounds);
            }
            
            node.TextBox.Top = bounds.Y + translation.Y + 15;
            node.TextBox.Left = bounds.X + translation.X;

            if (node.TextBox.Visible == false) 
                node.TextBox.Show();
        }

        void draw_normal_node(Graphics g, TreeNodeEx node, Rectangle bounds) {
            Image glyph = get_glyph(node.IsExpanded);
            Rectangle glyph_rect = new Rectangle(0, 0, GlyphSize.Width, glyph.Height);

            //Fill glyph background
            Rectangle r = new Rectangle(0, bounds.Y, bounds.X, bounds.Height);
            g.FillRectangle(SystemBrushes.Window, r);

            if (node.IsExpandable) {
                //Draw glyph
                g.DrawImageUnscaled(glyph, CenterRect(bounds, glyph_rect, HorizontalAlignment.Left));
            }

            //Draw icon if exists
            if (image_list != null && image_list.Images.Count > 0 && node.ImageIndex >= 0) {
                Rectangle icon_rect = new Rectangle(bounds.X + image_list.ImageSize.Width, bounds.Y, image_list.ImageSize.Width, image_list.ImageSize.Height);
                icon_rect = CenterRect(bounds, icon_rect, HorizontalAlignment.Left);
                icon_rect.Offset(image_list.ImageSize.Width, 0);
                
                if (node.ImageIndex > image_list.Images.Count - 1)
                    node.ImageIndex = image_list.Images.Count - 1;
                if (node.ImageIndex < 0)
                    node.ImageIndex = 0;

                g.DrawImage(image_list.Images[node.ImageIndex], icon_rect);
            }

            //Move bounds in text area
            bounds.Offset(TextOffset, 0);

            
            Size text_size = TextRenderer.MeasureText(node.Text, node.Font);
            Rectangle text_rectangle = new Rectangle(bounds.X, bounds.Y,
                bounds.Width, text_size.Height);

            text_rectangle = CenterRect(bounds, text_rectangle, HorizontalAlignment.Left);

            if (node.IsSelected) {
                g.FillRectangle(SystemBrushes.Highlight, bounds);
                ControlPaint.DrawFocusRectangle(g, bounds);

                //.net 1.1
                g.DrawString(node.Text, node.Font, SystemBrushes.HighlightText, text_rectangle,
                    new StringFormat(StringFormatFlags.FitBlackBox));
                //TextRenderer.DrawText(g, node.Text, node.Font, text_rectangle, SystemColors.HighlightText, TextFormatFlags.SingleLine);
            }
            else {
                g.FillRectangle(SystemBrushes.Window, bounds);

                Brush text_brush = new SolidBrush(node.ForeColor);
                //.net 1.1 
                g.DrawString(node.Text, node.Font, text_brush, text_rectangle,
                    new StringFormat(StringFormatFlags.FitBlackBox));
                //TextRenderer.DrawText(g, node.Text, node.Font, text_rectangle, SystemColors.WindowText, TextFormatFlags.SingleLine);
            }
        }

        /// <summary>
        /// Triggers the BeforeExpand event
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Returns if the node should be expanded or not.</returns>
        internal bool TriggerBeforeExpand(TreeNodeEx node) {
            if (BeforeExpand != null) {
                TreeNodeExExpandEvent e = new TreeNodeExExpandEvent(node);
                BeforeExpand(this, e);
                return !e.Cancel;
            }

            return true;
        }
        /// <summary>
        /// Nu trebuie folosit pentru functii care deseneaza
        /// </summary>
        Rectangle NodeToScreenBounds(TreeNodeEx node) {
            return NodeToScreenBounds(node.Bounds, false);
        }

        Rectangle NodeToScreenBounds(Rectangle node_bounds) {
            return NodeToScreenBounds(node_bounds, false);
        }

        Rectangle NodeToScreenBounds(Rectangle node_bounds, bool integral_width) {
            Rectangle bounds = Rectangle.Empty;

            if (!integral_width)
                bounds = new Rectangle(0, node_bounds.Y, 
                    node_bounds.X + node_bounds.Width + TextOffset, node_bounds.Height);
            else
                //TODO: ar trebui, la latime, sa tina cont si de border
                bounds = new Rectangle(0, node_bounds.Y,
                    (this.Width < content_size.Width) ? content_size.Width : this.Width, node_bounds.Height);

            bounds.Offset(translation.X, translation.Y);
            return bounds;
        }

        Rectangle CenterRect(Rectangle container, Rectangle obj, HorizontalAlignment Alignment) {
            int x = 0;
            switch (Alignment) {
            case HorizontalAlignment.Right:
                x = container.Width - obj.Width;
                break;
            case HorizontalAlignment.Left:
                x = container.Left;
                break;
            case HorizontalAlignment.Center:
                throw new Exception("Cannot draw in center");
            }

            Rectangle result = new Rectangle(
                    x, container.Y + (container.Height - obj.Height) / 2,
                    obj.Width, obj.Height);
            return result;
        }

        Image get_glyph(bool expanded) {
            Image image;
            if (Application.RenderWithVisualStyles) {
                VisualStyleRenderer glyph = new VisualStyleRenderer(
                    (expanded) ? VisualStyleElement.TreeView.Glyph.Opened :
                                 VisualStyleElement.TreeView.Glyph.Closed);

                Size size = Size.Empty;
                size = glyph.GetPartSize(this.CreateGraphics(), ThemeSizeType.Draw);

                if (size.Width > GlyphSize.Width) size.Width = GlyphSize.Width;
                if (size.Height > GlyphSize.Height) size.Width = GlyphSize.Height;

                image = new Bitmap(GlyphSize.Width, GlyphSize.Height);


                Graphics canvas = Graphics.FromImage(image);
                Rectangle canvas_rect = new Rectangle(0, 0, GlyphSize.Width, GlyphSize.Height);
                
                //int a = glyph.GetEnumValue(EnumProperty.SizingType);
                //canvas.FillRectangle(SystemBrushes.Window, canvas_rect);
                glyph.DrawBackground(canvas, canvas_rect);
            }
            else
                image = (expanded) ? (Image)resources.GetObject("minus") :
                                     (Image)resources.GetObject("plus");

            return image;
        }

        #endregion

        #region Methods
        public void ForceReLayout() {
            dirty_flag = true;
        }

        public void BeginUpdate() {
            can_draw = false;
        }

        public void EndUpdate() {
            can_draw = true;
            this.Invalidate();
        }

        public void InvalidateNode(TreeNodeEx node) {
            InvalidateNode(node, false);
        }

        public void InvalidateNode(TreeNodeEx node, bool invalidate_below) {
            Rectangle bounds = NodeToScreenBounds(node.Bounds, true);

            if (invalidate_below) {
                bounds.Height = this.Height - bounds.Y;
            }

            this.Invalidate(bounds, false);
        }
        #endregion

        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollectionEx Nodes {
            get { return root_node.Nodes; }
            set { root_node.Nodes = value; }
        }

        public int SelectedIndex
        {
            get { return this.SelectedNode.NodeIndex; }
            set
            {
                foreach (TreeNodeEx node in this.Nodes)
                {
                    if (node.NodeIndex == value)
                        this.SelectedNode = node;
                }
            }
        }

        private int TextOffset {
            get {
                int offset = 4;
                if (image_list != null) offset += image_list.ImageSize.Width;
                return GlyphSize.Width + offset;
            }
        }

        [Browsable(true)]
        public ImageList ImageList {
            get { return image_list; }
            set { image_list = value; }
        }

        [Browsable(false)]
        public TreeNodeEx SelectedNode {
            get { return selected_node; }
            set {
                if (selected_node != null) {
                    selected_node.is_selected = false;
                    InvalidateNode(selected_node);
                }

                if (value != null) {
                    selected_node = value;
                    selected_node.is_selected = true;

                    ScrollNodeIntoView(selected_node);

                    InvalidateNode(selected_node);

                }
            }
        }
        #endregion
    }
}