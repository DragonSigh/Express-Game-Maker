//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;

namespace EGMGame.Docking.Explorers
{
    public partial class DatabaseExplorer : DockContent
    {
        public DatabaseExplorer()
        {
            InitializeComponent();
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Data d = listBox.GetDataAt<Data>(e);

            if (d.ID > -1)
            {
                MainForm.Instance.databaseShow(d);
            }
        }

        private void DatabaseExplorer_Shown(object sender, EventArgs e)
        {
            SetupList();
        }

        internal void SetupList()
        {
            listBox.SetupList(GameData.Databases, typeof(Data));
        }

        internal void ResetProject()
        {
            listBox.Clear(false);
        }

        private void listBox_SelectItem(object sender, Controls.AddRemoveListEventArgs ca)
        {
            if (ca.MouseDoubleClicked && listBox.Data().ID > -1)
            {
                MainForm.Instance.databaseShow(listBox.Data<Data>());
            }
        }
    }
}
