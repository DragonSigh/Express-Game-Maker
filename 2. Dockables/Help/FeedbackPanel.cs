using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using EGMGame.Library;
using Microsoft.Xna.Framework;

namespace EGMGame.Docking.Settings
{
    public partial class FeedbackPanel : DockContent
    {

        public FeedbackPanel()
        {
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
            //webBrowser.Url = new Uri(@"https://expressgamemaker.com/Account/Surveys/");
        }
    }
}
