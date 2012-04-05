//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EGMGame
{
    internal class Reporter
    {
        #region"Error"
        internal static void ShowError(Control control, string cap, string txt)
        {
            DirectForm direct = new DirectForm();
            direct._Text.Text = txt;
            direct._Caption.Text = cap;
            direct.CalculateSize();
            direct.Show((IWin32Window)control.FindForm(), control);
            System.Media.SystemSounds.Beep.Play();
        }

        internal static void ShowWarning(Control control, string cap, string txt)
        {
            DirectForm direct = new DirectForm();
            direct._Text.Text = txt;
            direct._Caption.Text = cap;
            direct.CalculateSize();
            direct.Show((IWin32Window)control.FindForm(), control);
            System.Media.SystemSounds.Asterisk.Play();
        }

        internal static void ShowWarning(Point p, string cap, string txt)
        {
            DirectForm direct = new DirectForm();
            direct._Text.Text = txt;
            direct._Caption.Text = cap;
            direct.CalculateSize();
            direct.Show();
            direct.Location = p;
            System.Media.SystemSounds.Asterisk.Play();
        }
        #endregion

        #region"Direct"
        internal static void ShowDirect(Control control, string txt, string cap)
        {
            Config config = MainForm.Configuration;
            if (config.UseGuide)
            {
                DirectGuide direct = new DirectGuide();
                direct._Text.Text = txt;
                direct._Caption.Text = cap;
                direct._Image.Image = null;
                direct.CalculateSize();
                direct.Show((IWin32Window)control.FindForm(), control);
            }
        }

        internal static void ShowDirectNoSet(Control control, string txt, string cap)
        {
            DirectGuide direct = new DirectGuide();
            direct._Text.Text = txt;
            direct._Caption.Text = cap;
            direct._Image.Image = null;
            direct.CalculateSize();
            direct.ShowNoSet((IWin32Window)control.FindForm(), control);
        }
        #endregion

        internal static void ShowDirectAtMouse(Bitmap bitmap, string txt, string cap)
        {
            Config config = MainForm.Configuration;
            if (config.UseGuide)
            {
                DirectGuide direct = new DirectGuide();
                direct._Text.Text = txt;
                direct._Caption.Text = cap;
                direct._Image.Image = bitmap;
                direct.CalculateSize();
                direct.ShowNoMouseTrans();
            }
        }
    }
}
