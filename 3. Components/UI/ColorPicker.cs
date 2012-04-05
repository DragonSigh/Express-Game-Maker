 using System;
using System.Drawing;
using System.Drawing.Design;
using System.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using EGMGame;
using System.Runtime.InteropServices;

[DefaultProperty("Color"), DefaultEvent("ColorChanged")]
public class ColorPicker : Control
{
    // The CheckBox which is used to render the required button-like appearance
    // of the control.
    private ComboBox colorBox;
    // Should the control display the color's name?
    private bool _TextDisplayed = true;
    // The IWindowsFormsEditorService implementation - the meat of this code;-)
    private EditorService _EditorService;
    // Raised when the Color property changes.
    public event EventHandler ColorChanged;
    private const string DefaultColorName = "White";
    public ColorPicker(Color c)
        : base()
    {
        // Init the CheckBox to have the correct button-like appearance.
        colorBox = new ComboBox();
        colorBox.Dock = DockStyle.Fill;
        colorBox.DropDownHeight = 1;
        colorBox.DropDownWidth = 1;
        this.SetColor(c);
        this.Controls.Add(colorBox);
        _EditorService = new EditorService(this);

        colorBox.DropDown += new EventHandler(CheckBox_CheckStateChanged);
        colorBox.DropDownClosed += new EventHandler(colorBox_DropDownClosed);
    }
    public ColorPicker()
        : this(System.Drawing.Color.FromName(DefaultColorName))
    {
    }

    [Description("The currently selected color."), Category("Appearance"), DefaultValue(typeof(Color), DefaultColorName)]
    public Color Color
    {
        get { return colorBox.BackColor; }
        set
        {
            this.SetColor(value);
            if (ColorChanged != null)
            {
                ColorChanged(this, null);
            }
        }
    }

    [Description("True meanse the control displays the currently selected color's name, False otherwise."), Category("Appearance"), DefaultValue(true)]
    public bool TextDisplayed
    {
        get { return _TextDisplayed; }
        set
        {
            _TextDisplayed = value;
            this.SetColor(this.Color);
        }
    }

    // Sets the associated CheckBox color and Text according to the TextDisplayed property value.
    private void SetColor(Color c)
    {
        colorBox.BackColor = c;
        colorBox.ForeColor = this.GetInvertedColor(c);
        if (_TextDisplayed)
        {
            colorBox.Text = c.Name;
        }
        else
        {
            colorBox.Text = string.Empty;
        }
    }

    // Primitive color inversion.
    private Color GetInvertedColor(Color c)
    {
        if (((int)c.R + (int)c.G + (int)c.B) > ((255 * 3) / 2))
        {
            return Color.Black;
        }
        else
        {
            return Color.White;
        }
    }

    // If the associated CheckBox is checked, the drop-down UI is displayed.
    // Otherwise it is closed.
    public void CheckBox_CheckStateChanged(object sender, System.EventArgs e)
    {
        this.ShowDropDown();
    }

    public void colorBox_DropDownClosed(object sender, System.EventArgs e)
    {
        this.CloseDropDown();
    }

    private void ShowDropDown()
    {
        try
        {
            // This is the Color type editor - it displays the drop-down UI calling
            // our IWindowsFormsEditorService implementation.
            ColorEditor Editor = new ColorEditor();
            // Display the UI.
            Color C = this.Color;
            object NewValue = Editor.EditValue(_EditorService, C);
            // If the user didn't cancel the selection, remember the new color.
            if (((NewValue != null)) && (!_EditorService.Canceled))
            {
                this.Color = (Color)NewValue;
            }
            // Finally, "pop-up" the associated CheckBox.

        }
        catch (Exception ex)
        {
            Error.ShowLogError(ex, "6x001");
        }
    }

    private void CloseDropDown()
    {
        _EditorService.CloseDropDown();
    }

    // This is a simple Form descendant that hosts the drop-down control provided
    // by the ColorEditor class (in the call to DropDownControl).
    private class DropDownForm : Form
    {
        private bool _Canceled;
        // did the user cancel the color selection?
        private bool _CloseDropDownCalled;
        // was the form closed by calling the CloseDropDown method?
        public DropDownForm()
            : base()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
            // to catch the ESC key
            this.StartPosition = FormStartPosition.Manual;
            // The ColorUI control is hosted by a Panel, which provides the simple border frame
            // not available for Forms.
            Panel P = new Panel();
            P.BorderStyle = BorderStyle.FixedSingle;
            P.Dock = DockStyle.Fill;
            this.Controls.Add(P);
        }

        public void SetControl(Control ctl)
        {
            ((Panel)this.Controls[0]).Controls.Add(ctl);
        }

        public bool Canceled
        {
            get { return _Canceled; }
        }

        public void CloseDropDown()
        {
            _CloseDropDownCalled = true;
            this.Hide();
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((e.Modifiers == 0) && (e.KeyCode == Keys.Escape))
            {
                this.Hide();
            }
        }

        protected override void OnDeactivate(System.EventArgs e)
        {
            // We set the Owner to Nothing BEFORE calling the base class.
            // If we wouldn't do it, the Picker form would lose focus after
            // the dropdown is closed.
            this.Owner = null;
            base.OnDeactivate(e);
            // If the form was closed by any other means as the CloseDropDown call, it is because
            // the user clicked outside the form, or pressed the ESC key.
            if (!_CloseDropDownCalled)
            {
                _Canceled = true;
            }
            this.Hide();
        }
    }

    // This class actually hosts the ColorEditor.ColorUI by implementing the
    // IWindowsFormsEditorService.
    private class EditorService : IWindowsFormsEditorService, IServiceProvider
    {
        // The associated color picker control.
        private ColorPicker _Picker;
        // Reference to the drop down, which hosts the ColorUI control.
        private DropDownForm _DropDownHolder;
        // Cached _DropDownHolder.Canceled flag in order to allow it to be inspected
        // by the owning ColorPicker control.
        private bool _Canceled;

        public EditorService(ColorPicker owner)
        {
            _Picker = owner;
        }

        public bool Canceled
        {
            get { return _Canceled; }
        }

        public void CloseDropDown()
        {
            if ((_DropDownHolder != null))
            {
                _DropDownHolder.CloseDropDown();
            }
        }

        public void DropDownControl(Control control)
        {
            _Canceled = false;
            // Initialize the hosting form for the control.
            _DropDownHolder = new DropDownForm();
            _DropDownHolder.Bounds = control.Bounds;
            _DropDownHolder.SetControl(control);
            // Lookup a parent form for the Picker control and make the dropdown form to be owned
            // by it. This prevents to show the dropdown form icon when the user presses the At+Tab system
            // key while the dropdown form is displayed.
            Control PickerForm = this.GetParentForm(_Picker);
            if (((PickerForm != null)) && (PickerForm is Form))
            {
                _DropDownHolder.Owner = (Form)PickerForm;
            }
            // Ensure the whole drop-down UI is displayed on the screen and show it.
            this.PositionDropDownHolder();
            _DropDownHolder.Show();
            // ShowDialog would disable clicking outside the dropdown area!
            // Wait for the user to select a new color (in which case the ColorUI calls our CloseDropDown
            // method) or cancel the selection (no CloseDropDown called, the Cancel flag is set to True).
            this.DoModalLoop();
            // Remember the cancel flag and get rid of the drop down form.
            _Canceled = _DropDownHolder.Canceled;
            _DropDownHolder.Dispose();
            _DropDownHolder = null;
        }

        public DialogResult ShowDialog(Form dialog)
        {
            throw new NotSupportedException();
        }

        public object GetService(System.Type serviceType)
        {
            if (serviceType.Equals(typeof(IWindowsFormsEditorService)))
            {
                return this;
            }
            return null;
        }

        private void DoModalLoop()
        {
            System.Diagnostics.Debug.Assert((_DropDownHolder != null));
            while (_DropDownHolder.Visible)
            {
                Application.DoEvents();
                // The sollowing is the undocumented User32 call. For more information
                // see the accompanying article at http://www.vbinfozine.com/a_colorpicker.shtml
                MsgWaitForMultipleObjects(1, IntPtr.Zero, 1, 5, 255);
            }
        }

        // Don't forget to declare the DllImport methods
        [DllImport("User32", SetLastError = true)]
        static extern int MsgWaitForMultipleObjects(Int32 nCount, IntPtr pHandles, Int16 bWaitAll, Int32 dwMilliseconds, Int32 dwWakeMask);

        private void PositionDropDownHolder()
        {
            // Convert _Picker location to screen coordinates.
            Point Loc = _Picker.Parent.PointToScreen(_Picker.Location);
            Rectangle ScreenRect = Screen.PrimaryScreen.WorkingArea;
            // Position the dropdown X coordinate in order to be displayed in its entirety.
            if (Loc.X < ScreenRect.X)
            {
                Loc.X = ScreenRect.X;
            }
            else if ((Loc.X + _DropDownHolder.Width) > ScreenRect.Right)
            {
                Loc.X = ScreenRect.Right - _DropDownHolder.Width;
            }
            // Do the same for the Y coordinate.
            if ((Loc.Y + _Picker.Height + _DropDownHolder.Height) > ScreenRect.Bottom)
            {
                // dropdown will be above the picker control
                Loc.Offset(0, -_DropDownHolder.Height);
            }
            else
            {
                // dropdown will be below the picker
                Loc.Offset(0, _Picker.Height);
            }
            _DropDownHolder.Location = Loc;
        }

        private Control GetParentForm(Control ctl)
        {
            do
            {
                if (ctl.Parent == null)
                {
                    return ctl;
                }
                else
                {
                    ctl = ctl.Parent;
                }
            }
            while (true);
        }
    }
    // No need to display ForeColor and BackColor and Text in the property browser:
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override System.Drawing.Color ForeColor
    {
        get { return base.ForeColor; }
        set { base.ForeColor = value; }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override System.Drawing.Color BackColor
    {
        get { return base.BackColor; }
        set { base.BackColor = value; }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
        get { return base.Text; }
        set { base.Text = value; }
    }
}
