// Author: Vlad Untu/Asterix Software
// For updates: http://www.asterixsoft.ro/dyn/open/treeview_filter/
using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Text;

namespace EGMGame.Controls
{
    public enum NodeType { Normal, Filter }

    [TypeConverter(typeof(TreeNodeExConverter)), DefaultProperty("Text")]
    public class TreeNodeEx {
        string text = "NodeEx";
        bool is_expandable;
        bool is_expanded;
        bool search_on_change = true;
        internal bool is_selected;
        int level;
        int image_index;
        object tag;
        const int height_offset = 5;
        const int height_filter = 40;

        TreeNodeCollectionEx nodes;
        public INodeItemsFilter filter;
        TreeViewEx owner;
        TreeNodeEx parent_node;
        NodeType type;
        public TreeNodeCollectionEx filterNodes;
        public TreeNodeCollectionEx normalNodes;

        DirtyZone dirty_zone = DirtyZone.Height | DirtyZone.Width | DirtyZone.Bounds;
        //Size size = Size.Empty;
        Rectangle bounds = Rectangle.Empty;

        Font font;
        TextBox text_box;

        [Flags]
        enum DirtyZone { Height = 0x001, Width = 0x010, Bounds = 0x100 }

        #region Constructors
        public TreeNodeEx() {
            this.type = NodeType.Normal;
            /*Random r = new Random();
            height = r.Next(0, 40);*/
            nodes = new TreeNodeCollectionEx(this);
            filterNodes = new TreeNodeCollectionEx(this);
            normalNodes = new TreeNodeCollectionEx(this);
        }

        void text_box_GotFocus(object sender, EventArgs e) {
            if (this.TreeView != null) {
                this.TreeView.SelectedNode = this;
            }
        }

        /// <summary>
        /// Creates root node
        /// </summary>
        internal TreeNodeEx(TreeViewEx owner)
            : this() {
            this.owner = owner;
            this.level = -1;
        }

        /// <summary>
        /// Creates normal nodes
        /// </summary>
        /// <param name="text">Node text</param>
        public TreeNodeEx(string text)
            : this() {
            this.text = text;
        }

        public TreeNodeEx(string text, int image_index)
            : this(text) {
            this.image_index = image_index;
        }

        public TreeNodeEx(string text, int image_index, object tag)
            : this(text, image_index) {
            this.tag = tag;
        }

        public TreeNodeEx(string text, int image_index, object tag, TreeNodeEx[] nodes)
            : this(text, image_index, nodes) {
            this.tag = tag;
        }

        public TreeNodeEx(string text, int image_index, TreeNodeEx[] nodes)
            : this (text, nodes) {
            this.image_index = image_index;

        }

        public TreeNodeEx(string text, TreeNodeEx[] nodes)
            : this(text) {
            this.Nodes.AddRange(nodes);
        }

        public TreeNodeEx(string text, NodeType type)
            : this(text) {
            this.type = type;
            if (type == NodeType.Filter) {
                text_box = new TextBox();

                text_box.GotFocus += new EventHandler(text_box_GotFocus);
                text_box.KeyPress += new KeyPressEventHandler(text_box_KeyPress);
                text_box.TextChanged += new EventHandler(text_box_TextChanged);
                text_box.MinimumSize = new Size(this.Width -
                    TreeViewEx.MinFilterPadding * 2, text_box.Height);
                text_box.Visible = false;
            }
        }

        void text_box_TextChanged(object sender, EventArgs e) {
            if (search_on_change && parent_node != null)
                do_search(text_box.Text);
        }

        void text_box_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\r' && text_box.Text.Trim() != "" && filter != null) {
                if (parent_node != null) {
                    do_search(text_box.Text);
                    e.Handled = true;
                }
            }
        }

        public void do_search(string query) {

            if (String.IsNullOrEmpty(query))
            {
                nodes = normalNodes;
                return;
            }

            nodes = filterNodes;

            if (this.parent_node != null)
            {
                parent_node.nodes.Clear();
            }
            else
            {
                nodes.Clear();
            }
            
            TreeNodeEx[] items = filter.GetItems(query);

            if (items.Length > 0)
                parent_node.Nodes.AddRange(items);
            else
                TreeView.ForceReLayout();
        }

        public TreeNodeEx(string text, INodeItemsFilter filter)
            : this(text, NodeType.Filter) {
            this.filter = filter;
        }
        #endregion

        #region Properties

        [Browsable(true), DefaultValue(true)]
        public bool SearchOnChange {
            get { return search_on_change; }
            set { search_on_change = value; }
        }


        [Browsable(false), DefaultValue(null)]
        public object Tag {
            get { return tag; }
            set { tag = value; }
        }

        public string Text {
            get { return text; }
            set {
                text = value;

                dirty_zone |= DirtyZone.Width | DirtyZone.Bounds;
            }
        }

        [TypeConverter(typeof(TreeNodeExImageIndexConverter)),
        Editor(typeof(TreeNodeExImageIndexEditor), typeof(UITypeEditor))]
        public int ImageIndex {
            get { return image_index; }
            set { image_index = value; }
        }

        [Browsable(false)]
        private int Ident {
            get {
                Size size = new Size(0,0);
                if (this.TreeView != null)
                    size = this.TreeView.GlyphSize;

                return size.Width;
            }
        }

        [Browsable(false)]
        public int Height {
            get {
                if (NodeType == NodeType.Filter)
                    return height_filter;
                else {
                    if ((dirty_zone & DirtyZone.Height) == DirtyZone.Height) {
                        bounds.Height = TextRenderer.MeasureText(text, this.Font).Height + height_offset;
                        dirty_zone &= ~DirtyZone.Height;
                    }

                    return bounds.Height;
                }
            }
        }

        [Browsable(false)]
        public int Width {
            get {
                try {
                    if (NodeType == NodeType.Filter)  
                        return TreeViewEx.MinFilterWidth;

                    if (TreeView == null) return 0;

                    if ((dirty_zone & DirtyZone.Width) == DirtyZone.Width) {
                        Graphics g = TreeView.CreateGraphics();

                        float w = g.MeasureString(
                            text, this.Font, int.MaxValue,
                            StringFormat.GenericDefault).Width;

                        bounds.Width = Convert.ToInt32(Math.Ceiling((double)w));
                        
                        dirty_zone &= ~DirtyZone.Width;
                    }

                    return bounds.Width;
                }
                catch (Exception e) {
                    throw new Exception(e.Message + "asx");
                }
            }
        }

        [Browsable(false)]
        public Rectangle Bounds {
            get {
                if ((dirty_zone & DirtyZone.Bounds) == DirtyZone.Bounds) {
                    int top = 0;

                    foreach (TreeNodeEx node in this.TreeView.Nodes) {
                        if (node == this) break;
                        top += node.Height;
                    }

                    int left = this.Level * this.Ident + height_offset;

                    bounds = new Rectangle(left, top, this.Width, this.Height);
                    dirty_zone &= ~DirtyZone.Bounds;
                }

                return bounds;
            }
        }

        [Browsable(false)]
        public TreeNodeEx ParentNode {
            get { return parent_node; }
        }

        [DefaultValue(null)]
        public Font Font {
            get {
                if (font == null && this.TreeView != null)
                    return this.TreeView.Font;
                else
                    return font;
            }
            set {
                font = value;

                dirty_zone |= DirtyZone.Width | DirtyZone.Height | DirtyZone.Bounds;
            }
        }

        Color fore_color = Color.Empty;
        [DefaultValue("ControlText")]
        public Color ForeColor {
            get {
                if (fore_color == Color.Empty)
                    return TreeView.ForeColor;
                else
                    return fore_color;
            }
            set {
                fore_color = value;
            }
        }

        public int Level {
            get {
                if (level == 0 && parent_node != null)
                    level = parent_node.Level + 1;

                return level;
            }
        }

        [Browsable(false)]
        public int NodeIndex {
            get {
                if (ParentNode == null) return 0;

                return ParentNode.Nodes.IndexOf(this);
            }
        }

        [Browsable(false)]
        public bool IsExpanded {
            get { return is_expanded; }
        }

        /// <summary>
        /// If value is false it returns (this.Nodes.Count > 0)
        /// </summary>
        [Browsable(false)]
        public bool IsExpandable {
            get { return (is_expandable) ? true : nodes.Count > 0; }
            set { is_expandable = value; }
        }

        [Browsable(false)]
        public bool IsSelected {
            get { return is_selected; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollectionEx Nodes {
            get { return nodes; }
            set { nodes = value; }
        }

        public TreeViewEx TreeView {
            get {
                if (owner == null && parent_node != null)
                    owner = parent_node.TreeView;

                return owner;
            }
        }

        [DefaultValue(NodeType.Normal)]
        public NodeType NodeType {
            get { return type; }
            set { type = value; }
        }

        internal TextBox TextBox {
            get { return text_box; }
        }

        [Browsable(false)]
        public TreeNodeEx FilterNode {
            get { return this.nodes.FilterNode; }
            set { this.nodes.FilterNode = value; }
        }

        #endregion

        #region Methods
        public void Expand() {
            if (!IsExpandable || is_expanded) return;

            if (FilterNode != null) {
                FilterNode.text_box.Visible = false;
                this.TreeView.Controls.Add(FilterNode.text_box);
            }

            if (TreeView.TriggerBeforeExpand(this)) {
                if (this.Nodes.Count == 0)
                    throw new Exception("Cannot expand to empty collection.");
                
                InvalidateBelow();
                TreeView.ForceReLayout();

                is_expanded = true;
            }
        }

        public void Collapse() {
            if (!IsExpandable || !is_expanded) return;

            foreach (TreeNodeEx node in this.Nodes) {
                node.Collapse();
            }

            if (FilterNode != null && this.TreeView.Controls.Contains(FilterNode.text_box)) {
                this.TreeView.Controls.Remove(FilterNode.text_box);
                FilterNode.text_box.Visible = false;
            }

            InvalidateBelow();
            TreeView.ForceReLayout();

            is_expanded = false;
        }

        void InvalidateBelow() {
            if (this.TreeView != null) {
                this.TreeView.InvalidateNode(this, true);
            }
        }

        internal void SetParent(TreeNodeEx parent) {
            this.parent_node = parent;
        }

        internal void SetDirty() {
            this.dirty_zone |= DirtyZone.Bounds;
        }

        public override string ToString() {
            return "TreeNodeEx: " + this.text;
        }

        public string FullPath
        {
            get
            {
                TreeNodeEx test = this;
                StringBuilder sb = new StringBuilder();
                List<TreeNodeEx> list = new List<TreeNodeEx>();
                while (test.ParentNode != null)
                {
                    list.Add(test.ParentNode);
                    test = test.ParentNode;
                }
                list.RemoveAt(list.Count - 1);
                list.Insert(0, this);
                list.Reverse();
                for(int i = 0; i < list.Count; i++)
                {
                    sb.Append(list[i].Text);
                    if (i != list.Count - 1)
                        sb.Append("/");
                }
                return sb.ToString();
            }
        }
        #endregion
    }

    #region TreeNodeExConverter class
    public class TreeNodeExConverter : TypeConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof(InstanceDescriptor))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType) {

            if (destinationType == typeof(InstanceDescriptor) && value is TreeNodeEx) {
                TreeNodeEx node = (TreeNodeEx)value;

                Type tree_node_ex = typeof(TreeNodeEx);

                ConstructorInfo text_ctor = tree_node_ex.GetConstructor(new Type[] { typeof(string), typeof(int) });
                //ConstructorInfo text_image_ctor = tree_node_ex.GetConstructor(new Type[] { typeof(string) , typeof(int) });
                ConstructorInfo text_nodes_ctor;

                if (node.Nodes.Length > 0) {
                    text_nodes_ctor = tree_node_ex.GetConstructor(
                        new Type[] { typeof(string), typeof(int), typeof(TreeNodeEx[]) });

                    return new InstanceDescriptor(text_nodes_ctor, new object[] {
                        node.Text, node.ImageIndex, node.Nodes.ToArray() });

                }
                else
                    return new InstanceDescriptor(text_ctor, new object[] { node.Text, node.ImageIndex });
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    #endregion

    #region TreeViewExImageIndexConverter class
    public class TreeNodeExImageIndexConverter : ImageIndexConverter {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            List<int> result = new List<int>();
            ImageList ImageList = null;
            if (context.Instance != null) {
                // Step 1 - Determine who has the imagelist. 
                PropertyDescriptorCollection PropertyCollection = TypeDescriptor.GetProperties(context.Instance);
                PropertyDescriptor Property;
                if ((Property = PropertyCollection.Find("TreeView", false)) != null) {
                    object Parent = Property.GetValue(context.Instance);
                    PropertyDescriptorCollection ParentPropertyCollection = TypeDescriptor.GetProperties(Parent);
                    PropertyDescriptor ParentProperty = ParentPropertyCollection.Find("ImageList", false);
                    if (ParentProperty != null)
                        ImageList = (ImageList)ParentProperty.GetValue(Parent);
                }

                // Step 2 - Construct list of index for the images in the ImageList if any.
                if (ImageList != null) {
                    for (int i = 0; i < ImageList.Images.Count; i++) {
                        result.Add(i);
                    }
                    result.Add(-1);
                }
            }
            return new StandardValuesCollection(result);
        }
    }
    #endregion

    #region TreeNodeExImageIndexEditor
    internal class TreeNodeExImageIndexEditor : UITypeEditor {
        public override bool GetPaintValueSupported(
            ITypeDescriptorContext context) {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs pe) {
            // choose the right bitmap based on the value
            Image Image = null;
            int ImageIdx = (int)pe.Value;

            ArrayList ResultList = new ArrayList();
            ImageList ImageList = null;
            if (pe.Context.Instance != null && ImageIdx >= 0) {
                // Step 1 - Determine who has the imagelist. 
                PropertyDescriptorCollection PropertyCollection = TypeDescriptor.GetProperties(pe.Context.Instance);
                PropertyDescriptor Property;
                if ((Property = PropertyCollection.Find("TreeView", false)) != null) {
                    object Parent = Property.GetValue(pe.Context.Instance);
                    PropertyDescriptorCollection ParentPropertyCollection = TypeDescriptor.GetProperties(Parent);
                    PropertyDescriptor ParentProperty = ParentPropertyCollection.Find("ImageList", false);
                    if (ParentProperty != null)
                        ImageList = (ImageList)ParentProperty.GetValue(Parent);
                }
                // Step 2 - Construct list of index for the images in the ImageList if any.
                if (ImageList != null && ImageList.Images.Count > ImageIdx) {
                    Image = ImageList.Images[ImageIdx];
                }
            }
            if (ImageIdx < 0 || Image == null) {	// value -1 : Draws a cross to indicate no image. 
                pe.Graphics.DrawLine(Pens.Black, pe.Bounds.X + 1, pe.Bounds.Y + 1,
                    pe.Bounds.Right - 1, pe.Bounds.Bottom - 1);
                pe.Graphics.DrawLine(Pens.Black, pe.Bounds.Right - 1, pe.Bounds.Y + 1,
                    pe.Bounds.X + 1, pe.Bounds.Bottom - 1);
            }
            else {
                pe.Graphics.DrawImage(Image, pe.Bounds);
            }
        }
    }
    #endregion
}