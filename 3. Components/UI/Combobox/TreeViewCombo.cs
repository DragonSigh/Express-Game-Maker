using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace EGMGame.Controls
{
    public class ComboTree : DropdownContainerControl<TreeNodeEx>
    {
        #region Variables and Properties

        static TreeViewEx m_ComboTreeNode;
        static Panel controlPanel;
        static TextBox filterBox;
        static DropdownContainer<TreeNodeEx> m_container;
        TreeNodeEx oldNode;

        // Event variables
        public delegate void NodeChangedHandler(TreeNodeEx e);
        public event NodeChangedHandler NodeChangedEvent;

        public event EventHandler SelectedIndexChanged;

        public TreeNodeCollection UnfilteredNodes;
        public bool IsFiltered;

        public TreeNodeCollectionEx Nodes
        {
            get { return m_ComboTreeNode.Nodes; }
            set { m_ComboTreeNode.Nodes = value; }

        }
        /// <summary>
        /// Returns this.Nodes;
        /// </summary>
        public TreeNodeCollectionEx Items
        {
            get { return m_ComboTreeNode.Nodes; }
            set { m_ComboTreeNode.Nodes = value; }

        }

        public int SelectedIndex
        {
            get { return TreeView.SelectedIndex; }
            set { TreeView.SelectedIndex = value; }
        }

        public bool ChildNodesOnlySelectable = true;
        public string BranchSeperator = "/";

        public TreeViewEx TreeView
        {
            get { return m_ComboTreeNode; }
            set { m_ComboTreeNode = value; }
        }

        #endregion

        #region Constructor
        public ComboTree()
        {
            if (controlPanel == null)
            {
                m_container = new DropdownContainer<TreeNodeEx>(this);

                controlPanel = new Panel();
                m_ComboTreeNode = new TreeViewEx();
                filterBox = new TextBox();

                //int padding = 2;

                controlPanel.Controls.Add(filterBox);
                controlPanel.Controls.Add(m_ComboTreeNode);

                //filterBox.Text = "Filter";
                filterBox.Dock = DockStyle.Top;
                //filterBox.Visible = false;
                //m_ComboTreeNode.Location = new Point(filterBox.Height + padding, m_ComboTreeNode.Location.Y);
                //m_ComboTreeNode.Size = new Size(100, 10);
                m_ComboTreeNode.Dock = DockStyle.Fill;
                filterBox.SendToBack();

                //TreeView.selectedIndexChane
                //controlPanel.Width = this.txtInput.Width;
                //controlPanel.Height = filterBox.Height + padding + m_ComboTreeNode.Height;

                filterBox.TextChanged += new EventHandler(filterBox_TextChanged);

                m_container.SetControl(controlPanel);
            }

            this.TreeView.DoubleClick += new EventHandler(TreeViewNodeSelect);
            this.TreeView.Location = new Point(0, 0);
            this.TreeView.LostFocus += new EventHandler(TreeViewLostFocus);
            txtInput.KeyDown += new KeyEventHandler(txtInput_KeyDown);
            filterBox.TextChanged += new EventHandler(filterBox_TextChanged);
            //this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //this.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //PopulateAutoComplete();

            DropdownContainer = m_container;
        }

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            ShowDropdown();
            filterBox.Text = e.KeyData.ToString();
            filterBox.Select(filterBox.Text.Length, 0);

        }

        void filterBox_TextChanged(object sender, EventArgs e)
        {
            if (TreeView.Nodes.owner.filter == null)
                TreeView.Nodes.owner.filter = new SearchFilter(TreeView.Nodes.owner.normalNodes);
            TreeView.Nodes.owner.do_search(txtInput.Text);
            //TreeView.Nodes[0].FilterNode = 
        }

        #endregion

        #region Functionality & Methods
        //private TreeNodeCollection FilterNodes(string filter)
        //{
        //TreeNodeCollection collection = ObjectCopier.Clone<TreeNodeCollection>(Nodes);
        //foreach (TreeNode node in collection)
        //{
        //    // is childnode
        //    if (node.Nodes.Count == 0)
        //    {
        //        if (!node.Text.Contains(filter))
        //        {
        //            TreeNode parentCheck = node.Parent;
        //            node.Remove();
        //            while (parentCheck.Parent != null)
        //            {
        //                if (parentCheck.Nodes.Count == 0)
        //                {
        //                    parentCheck.Remove();
        //                    parentCheck = parentCheck.Parent;
        //                }
        //            }
        //        }
        //    }
        //}

        //return collection;
        //}

        private void PopulateAutoComplete()
        {
            //this.AutoCompleteCustomSource.AddRange(new string[] { "bsd5a", "b5sda", "b2sda", "bsd2a", "bsda2", });
        }
        private string FullNodeName(TreeNodeEx n)
        {
            return n.FullPath.Replace(@"\", this.BranchSeperator);
        }

        private void UpdateText()
        {
            this.Text = FullNodeName(SelectedItem);
        }
        #endregion

        #region Events

        private void TreeViewLostFocus(object sender, EventArgs e)
        {
            //m_container.Hide();
        }

        private void TreeViewNodeSelect(object sender, EventArgs e)
        {
            if (this.ChildNodesOnlySelectable)
            {
                if (this.TreeView.SelectedNode.Nodes.Count == 0)
                {
                    m_container.Accept();
                }
            }
            else
            {
                m_container.Accept();
            }
        }
        #endregion

        #region Overrides

        [Browsable(true)]
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
        protected override void ShowDropdown()
        {
            oldNode = SelectedItem;
            m_ComboTreeNode.SelectedNode = SelectedItem;
            // only need to register / unregister because the dropdown is static and shared
            DropdownContainer.KeyDown += new KeyEventHandler(OnDropdownKeyDown);
            base.ShowDropdown();
        }
        public override void CloseDropdown(bool acceptValue)
        {
            DropdownContainer.KeyDown -= new KeyEventHandler(OnDropdownKeyDown);
            base.CloseDropdown(acceptValue);
            if (acceptValue)
            {
                //SelectedItem = (TreeNode)m_ComboTreeNode.SelectedNode.Clone();
                SelectedItem = m_ComboTreeNode.SelectedNode;
                UpdateText();
                if (NodeChangedEvent != null)
                    NodeChangedEvent(SelectedItem);
            }
            else
            {
                SelectedItem = oldNode;
                UpdateText();
                if (NodeChangedEvent != null)
                    NodeChangedEvent(SelectedItem);
            }
        }

        void OnDropdownKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                CloseDropdown(true);
            }
        }

        #endregion

    }

    class SearchFilter : INodeItemsFilter
    {
        TreeNodeCollectionEx Collection;
        public SearchFilter(TreeNodeCollectionEx collection)
        {
            Collection = collection;
        }

        #region INodeItemsFilter Members

        public TreeNodeEx[] GetItems(string query)
        {
            ArrayList items = new ArrayList();

            foreach (TreeNodeEx node in Collection)
            {
                // is childnode
                if (node.Nodes.Count == 0)
                {
                    if (node.Text.Contains(query) && (string)node.Tag != "Category")
                    {
                        items.Add(node);

                        TreeNodeEx parentCheck = node.ParentNode;

                        while (parentCheck != null)
                        {
                            if (parentCheck.Nodes.Count == 0)
                            {
                                parentCheck.Tag = "Category";
                                parentCheck = parentCheck.ParentNode;
                            }
                            else
                                break;
                        }
                    }
                }
            }

            return (TreeNodeEx[])items.ToArray(typeof(TreeNodeEx));
        }

        #endregion
    }

    public class DropdownContainerControl<T> : Control
    {
        #region Properties Variables and Events
        T m_selectedItem;
        bool m_mouseIn = false;
        DropdownContainer<T> m_container = null;

        public TextBox txtInput = new TextBox();
        public delegate void TextChangedHandler(EventArgs e);
        public event TextChangedHandler TextChangedEvent;

        public string Text
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return txtInput.AutoCompleteCustomSource; }
            set { txtInput.AutoCompleteCustomSource = value; }
        }
        public AutoCompleteMode AutoCompleteMode
        {
            get { return txtInput.AutoCompleteMode; }
            set { txtInput.AutoCompleteMode = value; }
        }
        public AutoCompleteSource AutoCompleteSource
        {
            get { return txtInput.AutoCompleteSource; }
            set { txtInput.AutoCompleteSource = value; }
        }

        public T SelectedItem
        {
            get { return m_selectedItem; }
            set { m_selectedItem = value; Invalidate(); }
        }

        public DropdownContainer<T> DropdownContainer
        {
            get { return m_container; }
            set { m_container = value; }
        }
        public bool DroppedDown
        {
            get { return m_container.Visible; }
        }

        public Rectangle ItemRectangle
        {
            get
            {
                Rectangle r = ClientRectangle;
                r.Y += 2;
                r.Height -= 4;
                r.X += 2;
                r.Width = ButtonRectangle.Left - 4;
                return r;
            }
        }
        public Rectangle ButtonRectangle
        {
            get
            {
                Rectangle r = ClientRectangle;
                r.Y += 0;
                r.Height -= 0;
                r.X = r.Right - 18;
                r.Width = 17;
                return r;
            }
        }

        #endregion

        #region Constructor
        public DropdownContainerControl()
        {
            this.DoubleBuffered = true;
            this.txtInput.TextChanged += new EventHandler(txtInput_TextChanged);
            this.Resize += new EventHandler(DropdownContainerControl_Resize);
            txtInput.ReadOnly = true;
            txtInput.BackColor = Color.White;
            this.Controls.Add(txtInput);

            m_container = new DropdownContainer<T>(this);

        }
        #endregion

        #region Events
        void DropdownContainerControl_Resize(object sender, EventArgs e)
        {
            PositionControls();
        }
        void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (TextChangedEvent != null)
                TextChangedEvent(e);
        }
        #endregion

        #region Methods
        private void PositionControls()
        {
            txtInput.Location = new Point(0, 0);//this.ClientRectangle.Location;
            txtInput.Width = this.Width - ButtonRectangle.Width - 1;
            txtInput.Height = ButtonRectangle.Height;
        }
        #endregion

        #region Overrides & Virtuals

        public virtual void CloseDropdown(bool acceptValue)
        {
            HideDropdown();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Rectangle r = ClientRectangle;

            //ComboBoxRenderer.DrawTextBox(e.Graphics, r, System.Windows.Forms.VisualStyles.ComboBoxState.Normal);

            r = ButtonRectangle;
            if (m_mouseIn)
                ComboBoxRenderer.DrawDropDownButton(e.Graphics, r, System.Windows.Forms.VisualStyles.ComboBoxState.Hot);
            else
                ComboBoxRenderer.DrawDropDownButton(e.Graphics, r, System.Windows.Forms.VisualStyles.ComboBoxState.Normal);
            r = ItemRectangle;
            r.Inflate(-1, -1);
            //DrawItem(e.Graphics, ItemRectangle);
            if (Focused)
                ControlPaint.DrawFocusRectangle(e.Graphics, ItemRectangle);
            RaisePaintEvent(this, e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Focus();
                if (DroppedDown)
                    HideDropdown();
                else
                    ShowDropdown();
            }
        }
        protected virtual void ShowDropdown()
        {
            Point location = Parent.PointToScreen(Location);
            location.Y += Height + 2;
            // adjust dropdown location in case it goes off the screen;
            Rectangle r = Parent.RectangleToScreen(Bounds);
            Rectangle screen = Screen.GetWorkingArea(this);
            if (location.X + m_container.Width > screen.Right)
                location.X = r.Right - m_container.Width;
            if (location.X < 0)
                location.X = 0;

            if (location.Y + m_container.Height > screen.Bottom)
                location.Y = r.Top - m_container.Height;
            if (location.Y < 0)
                location.Y = 0;

            m_container.Location = location;
            m_container.ShowDropdown(this);

            //m_container.Focus();
            //txtInput.Focus();
        }
        protected virtual void HideDropdown()
        {
            m_container.Hide();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            m_mouseIn = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            m_mouseIn = false;
            Invalidate();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Down && DroppedDown == false)
            {
                ShowDropdown();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion
    }
    public class DropdownContainer<T> : Form
    {
        #region Properties and Variables

        public bool Resizable = false;

        private ComboTreeLabel lblSizingGrip;

        public Point DragOffset;

        int m_frameMargin = 4;
        DropdownContainerControl<T> m_owner;

        Hook m_hook = new Hook();
        Control ctrl;

        public virtual Rectangle WindowRectangle
        {
            get { return base.ClientRectangle; }
        }
        public virtual new Rectangle ClientRectangle
        {
            get
            {
                Rectangle r = WindowRectangle;
                r.Y += m_frameMargin;// +m_captionHeight;
                r.Height -= m_frameMargin * 2;
                r.X += m_frameMargin;
                r.Width -= m_frameMargin * 2;
                return r;
            }
        }
        #endregion

        #region Constructor

        public DropdownContainer(DropdownContainerControl<T> owner)
        {
            m_owner = owner;

            WinUtil.SetWindowPos(Handle, IntPtr.Zero, 0, 0, 0, 0, WinUtil.SWP_NOACTIVATE);

            this.TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);

            SetTopLevel(true);
            ShowInTaskbar = false;
            Hide();

            m_hook.OnKeyDown += new Hook.KeyboardDelegate(OnHookKeyDown);
        }

        #endregion

        #region Methods
        public void SetControl(Control control)
        {
            Controls.Clear();
            ctrl = control;
            this.lblSizingGrip = new ComboTreeLabel();
            this.lblSizingGrip.Size = new Size(9, 9);
            this.lblSizingGrip.BackColor = Color.Transparent;
            this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
            this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            Controls.Add(lblSizingGrip);

            Rectangle client = ClientRectangle;
            this.Width += ctrl.Width - client.Width;
            this.Height += ctrl.Height - client.Height;

            RelocateGrip();
            ctrl.Location = ClientRectangle.Location;

            Controls.Add(ctrl);

            ctrl.TabIndex = 0;
        }

        public void RelocateGrip()
        {
            this.lblSizingGrip.Top = this.Height - lblSizingGrip.Height - 6;
            this.lblSizingGrip.Left = this.Width - lblSizingGrip.Width - 6;
        }

        public void SetSizes(Size size)
        {
            ctrl.Size = size;
            this.Width += ctrl.Width - ClientRectangle.Width;
            this.Height += ctrl.Height - ClientRectangle.Height;
        }
        #endregion

        #region Virtuals and Overrides
        public virtual void Cancel()
        {
            m_hook.SetHook(false);
            Hide();
            if (m_owner != null)
                m_owner.CloseDropdown(false);
        }
        public virtual void Accept()
        {
            m_hook.SetHook(false);
            Hide();
            if (m_owner != null)
                m_owner.CloseDropdown(true);
        }
        public virtual void ShowDropdown(DropdownContainerControl<T> owner)
        {
            if (owner != null)
                m_owner = owner;

            Show();
            m_hook.SetHook(true);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            Cancel();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            if (ctrl.Location != ClientRectangle.Location)
                ctrl.Location = ClientRectangle.Location;
            Rectangle r = WindowRectangle;
            r.Width--;
            r.Height--;
            DrawFrame(e.Graphics, r, 6, Color.CadetBlue);
        }

        void OnHookKeyDown(KeyEventArgs e)
        {
            OnKeyDown(e);
            if (e.Handled)
                return;
            if (e.KeyCode == Keys.Escape)
            {
                Cancel();
                e.Handled = true;
            }
        }
        #endregion

        #region Events
        private void SizingGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int TvWidth, TvHeight;
                TvWidth = Cursor.Position.X - this.Location.X;
                TvWidth = TvWidth + this.DragOffset.X;
                TvHeight = Cursor.Position.Y - this.Location.Y;
                TvHeight = TvHeight + this.DragOffset.Y;

                if (TvWidth < 50)
                    TvWidth = 50;
                if (TvHeight < 50)
                    TvHeight = 50;

                SetSizes(new Size(TvWidth, TvHeight));
                //this.Size = new System.Drawing.Size(TvWidth, TvHeight);
                //ctrl.Size = this.Size;
                //this.tvTreeView.Size = new System.Drawing.Size(this.frmTreeView.Size.Width - this.lblSizingGrip.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Width); ;
                RelocateGrip();
            }
        }

        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int OffsetX = System.Math.Abs(Cursor.Position.X - this.RectangleToScreen(this.ClientRectangle).Right);
                int OffsetY = System.Math.Abs(Cursor.Position.Y - this.RectangleToScreen(this.ClientRectangle).Bottom);

                this.DragOffset = new Point(OffsetX, OffsetY);
            }
        }
        #endregion

        #region Drawing Helpers
        public static Rectangle Rect(RectangleF rf)
        {
            Rectangle r = new Rectangle();
            r.X = (int)rf.X;
            r.Y = (int)rf.Y;
            r.Width = (int)rf.Width;
            r.Height = (int)rf.Height;
            return r;
        }
        public static RectangleF Rect(Rectangle r)
        {
            RectangleF rf = new RectangleF();
            rf.X = (float)r.X;
            rf.Y = (float)r.Y;
            rf.Width = (float)r.Width;
            rf.Height = (float)r.Height;
            return rf;
        }
        public static Point Point(PointF pf)
        {
            return new Point((int)pf.X, (int)pf.Y);
        }
        public static PointF Center(RectangleF r)
        {
            PointF center = r.Location;
            center.X += r.Width / 2;
            center.Y += r.Height / 2;
            return center;
        }

        public static void DrawFrame(Graphics dc, RectangleF r, float cornerRadius, Color color)
        {
            Pen pen = new Pen(color);
            if (cornerRadius <= 0)
            {
                dc.DrawRectangle(pen, Rect(r));
                return;
            }
            cornerRadius = (float)Math.Min(cornerRadius, Math.Floor(r.Width) - 2);
            cornerRadius = (float)Math.Min(cornerRadius, Math.Floor(r.Height) - 2);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(r.Right - cornerRadius, r.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(r.Right - cornerRadius, r.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(r.X, r.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            dc.DrawPath(pen, path);
        }
        #endregion
    }

    class ComboTreeLabel : Label
    {
        /// <summary>
        /// 
        /// </summary>
        public ComboTreeLabel()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            System.Windows.Forms.ControlPaint.DrawSizeGrip(e.Graphics, System.Drawing.Color.Black, 1, 0, this.Size.Width, this.Size.Height);
        }
    }

    public class Hook
    {
        public delegate void KeyboardDelegate(KeyEventArgs e);
        public KeyboardDelegate OnKeyDown;
        int m_hHook = 0;
        WinUtil.HookProc m_HookCallback;

        public void SetHook(bool enable)
        {
            if (enable && m_hHook == 0)
            {
                m_HookCallback = new WinUtil.HookProc(HookCallbackProc);
                Module module = Assembly.GetExecutingAssembly().GetModules()[0];
                m_hHook = WinUtil.SetWindowsHookEx(WinUtil.WH_KEYBOARD_LL, m_HookCallback, Marshal.GetHINSTANCE(module), 0);
                if (m_hHook == 0)
                {
                    MessageBox.Show("SetHook Failed. Please make sure the 'Visual Studio Host Process' on the debug setting page is disabled");
                    return;
                }
                return;
            }

            if (enable == false && m_hHook != 0)
            {
                WinUtil.UnhookWindowsHookEx(m_hHook);
                m_hHook = 0;
            }
        }
        int HookCallbackProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return WinUtil.CallNextHookEx(m_hHook, nCode, wParam, lParam);
            }
            else
            {
                //Marshall the data from the callback.
                WinUtil.KeyboardHookStruct hookstruct = (WinUtil.KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(WinUtil.KeyboardHookStruct));

                if (OnKeyDown != null && wParam.ToInt32() == WinUtil.WM_KEYDOWN)
                {
                    Keys key = (Keys)hookstruct.vkCode;
                    if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                        key |= Keys.Shift;
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                        key |= Keys.Control;

                    KeyEventArgs e = new KeyEventArgs(key);
                    e.Handled = false;
                    OnKeyDown(e);
                    if (e.Handled)
                        return 1;
                }
                int result = 0;
                if (m_hHook != 0)
                    result = WinUtil.CallNextHookEx(m_hHook, nCode, wParam, lParam);
                return result;
            }
        }
    }

    class WinUtil
    {
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_CHAR = 0x0102;

        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020;  /* The frame changed: send WM_NCCALCSIZE */
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200;  /* Don't do owner Z ordering */
        public const int SWP_NOSENDCHANGING = 0x0400;  /* Don't send WM_WINDOWPOSCHANGING */

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int BringWindowToTop(IntPtr hwnd);

        public const uint WS_OVERLAPPED = WS_BORDER | WS_CAPTION;
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        public const uint WS_CLIPCHILDREN = 0x02000000;
        public const uint WS_CAPTION = 0x00C00000;     /* WS_BORDER | WS_DLGFRAME  */
        public const uint WS_BORDER = 0x00800000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_VSCROLL = 0x00200000;
        public const uint WS_HSCROLL = 0x00100000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_MAXIMIZEBOX = 0x00020000;
        public const uint WS_MINIMIZEBOX = 0x00010000;
        public const uint WS_SIZEBOX = WS_THICKFRAME;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_DISABLED = 0x08000000;

        public const uint WS_EX_DLGMODALFRAME = 0x00000001;
        public const uint WS_EX_TOPMOST = 0x00000008;
        public const uint WS_EX_TOOLWINDOW = 0x00000080;
        public const uint WS_EX_WINDOWEDGE = 0x00000100;
        public const uint WS_EX_CLIENTEDGE = 0x00000200;

        public const uint WS_EX_CONTEXTHELP = 0x00000400;
        public const uint WS_EX_STATICEDGE = 0x00020000;
        public const uint WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);

        public const int GWL_STYLE = (-16);
        public const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);


        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public const int WH_KEYBOARD = 2;
        public const int WH_MOUSE = 7;
        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;

        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/setwindowshookex.asp
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/setwindowshookex.asp
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/setwindowshookex.asp
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        //Declare the wrapper managed POINT class.
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        //Declare the wrapper managed MouseHookStruct class.
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        //Declare the wrapper managed KeyboardHookStruct class.
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
    }

    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

}
