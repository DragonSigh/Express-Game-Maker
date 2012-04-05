//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Controls;

namespace EGMGame.Dialogs
{
    public partial class BuildContentDialog : Form
    {
        System.Timers.Timer dotTimer = new System.Timers.Timer(800);
        int dots = 0;
        delegate void SetTextCallback(string text);
        bool Closing = false;

        public BuildContentDialog()
        {
            InitializeComponent();
            dotTimer.Elapsed += new System.Timers.ElapsedEventHandler(dotTimer_Elapsed);
            dotTimer.Start();
        }

        public void UpdateProgress(string txt, int val, int max)
        {
            lblStatus.Text = txt;
            progressBar.Maximum = max;
            progressBar.Value = (max >= val ? val : max);
        }

        public void contentBuilder_ProgressChanged(object sender, int progress, int maxProgress, string name)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        UpdateProgress(name, progress, maxProgress);
                    })));
                }
                else
                    UpdateProgress(name, progress, maxProgress);
            }
            catch
            {
            }
        }
        public void contentBuilder_ImportComplete(string buildError)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        Closing = true;
                        this.Close();
                    })));
                }
                else
                {
                    Closing = true;
                    this.Close();
                }
            }
            catch
            {
            }
        }

        #region Dots
        private void dotTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ProgressDots();
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
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        private void SetText(string text)
        {
            lblDots.Text = text;
        }
        #endregion


    }
}
