//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace EGMGame.Dialogs
{
    public partial class LoadDialog : Form
    {
        System.Timers.Timer dotTimer = new System.Timers.Timer(800);
        int dots = 0;
        delegate void SetTextCallback(string text);

        public bool Closing = false;

        public LoadDialog()
        {
            InitializeComponent();
            dotTimer.Elapsed += new System.Timers.ElapsedEventHandler(dotTimer_Elapsed);
            dotTimer.Start();
        }

        private void dotTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ProgressDots();
            try
            {
                if (!pbProgress.InvokeRequired && this.Visible)
                    pbProgress.Value = MainForm.LoadProgress;
                else if (this.Visible)
                {
                    pbProgress.EndInvoke(pbProgress.BeginInvoke(new MethodInvoker(delegate() { pbProgress.Value = MainForm.LoadProgress; })));
                    this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { this.BringToFront(); })));
                }
            }
            catch
            {
            }
            finally
            {
                if (!MainForm.IsLoadingProject)
                {
                    this.Closing = true;
                    this.Close();
                    dotTimer.Close();
                }
            }
        }
        public void Setup(int min, int max)
        {
            pbProgress.Minimum = min;
            pbProgress.Maximum = max;
            pbProgress.Style = ProgressBarStyle.Continuous;
        }
        private void ProgressDots()
        {
            if (!Closing)
            {
                if (dots == 0)
                {
                    SetDotText("");
                }
                if (dots == 1)
                {
                    SetDotText(".");
                }
                if (dots == 2)
                {
                    SetDotText("..");
                }
                if (dots == 3)
                {
                    SetDotText("...");
                    dots = -1;
                }
                dots++;
            }
        }

        public void SetDotText(string text)
        {
            try
            {
                if (!Closing)
                {
                    // It's on a different thread, so use Invoke.
                    SetTextCallback d = new SetTextCallback(SetText);
                    if (!Closing && lblDots.Visible && !lblDots.IsDisposed)
                        lblDots.Invoke(d, new object[] { text });
                    //if (lblDots.InvokeRequired)
                    //{
                    //}
                    //else
                    //{
                    //    // It's on the same thread, no need for Invoke
                    //    lblDots.Text = text;
                    //}
                }
            }
            catch (System.Exception ex)
            {
                //Error.ShowError(ex);
            }
        }
        private void SetText(string text)
        {
            lblDots.Text = text;
        }
        public void Progress(int percent)
        {
            pbProgress.Value = percent;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetForegroundWindow(this.Handle);
        }

        [DllImport("user32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

    }
}
