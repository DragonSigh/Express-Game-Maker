using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EGMGame
{
    internal partial class DirectGuide : Form
    {
        // Location its suppose to be
        Point loc;
        Control cont;

        public DirectGuide()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
            timer.Start();
        }

        private void DirectForm_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DirectForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void Show(IWin32Window iWin32Window, Control control)
        {
            cont = control;
            loc = control.PointToScreen(control.ClientRectangle.Location);
            loc.X += control.Bounds.Width/3;
            loc.Y += control.Bounds.Height;
            this.SetDesktopLocation(loc.X, loc.Y);
            // Show
            ShowDialog(iWin32Window);
        }

        internal void CalculateSize()
        {
            Size size = _Text.MaximumSize;
            size.Width -= _Image.Width - 2;
            _Text.MaximumSize = size;
            loc = new Point();
            loc.X = _Caption.Location.X + _Image.Width;
            loc.Y = _Caption.Location.Y;
            _Caption.Location = loc;
            this.Width = 56 + _Text.Width + _Image.Width;
            this.Height = 50 + _Caption.Height + _Text.Height + _Image.Height;
        }

        private void DirectForm_Load(object sender, EventArgs e)
        {
            this.Location = loc;
            //Make sure its in screen
            Rectangle scrBound = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            Point directLoc = this.Location;
            if (directLoc.X < 0) loc.X = 0;
            if (directLoc.Y < 0) loc.Y = 0;
            if (directLoc.X + this.Width > scrBound.Width) loc.X = scrBound.Width - this.Width;
            if (directLoc.Y + this.Height > scrBound.Height) loc.Y = scrBound.Height - this.Height;
            this.Location = loc;      
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.Configuration.UseGuide = !_CheckBox.Checked;
            Config.Save();
        }

        internal void ShowNoSet(IWin32Window iWin32Window, Control control)
        {
            cont = control;
            loc = control.PointToScreen(control.ClientRectangle.Location);
            loc.X += control.Bounds.Width / 3;
            loc.Y += control.Bounds.Height;
            _CheckBox.Visible = false;
            this.Height -= _CheckBox.Height;
            this.SetDesktopLocation(loc.X, loc.Y);
            // Show
            ShowDialog(iWin32Window);
        }

        private void DirectGuide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void ShowNoMouseTrans()
        {
            loc.X += Global.CursorPosition.X;
            loc.Y += Global.CursorPosition.Y;
            _CheckBox.Visible = false;
            this.Height -= _CheckBox.Height;

            //this.SetDesktopLocation(this.Location.X, this.Location.Y);
            // Show
            Show();
        }

        int _timer=1;
        private void timer_Tick(object sender, EventArgs e)
        {
            _timer++;

            if (_timer >= 100)
            {
                //this.Close();
            }
        }
    }
}
