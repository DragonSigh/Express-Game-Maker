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
    public partial class EventExplorer : DockContent
    {

        public EventExplorer()
        {
            InitializeComponent();

        }

        private void EventExplorer_Activated(object sender, EventArgs e)
        {
            Setup();
        }

        public void Setup()
        {
            addRemoveList.SetupList(GameData.Events, typeof(EventData));
        }
        

        internal bool RealVisible = false;
        bool allowVisisbleChange = true;
        private void Explorer_VisibleChanged(object sender, EventArgs e)
        {
            if (allowVisisbleChange && EGMGame.Docking.Editors.MapEditor.allowActivateChange)
            {
                //RealVisible = this.Visible;
            }
        }

        internal void CheckVisibility(bool p)
        {
            allowVisisbleChange = false;
            if (this.dockState == DockState.Float)
            {
                if (p)
                {
                    if (RealVisible)
                    {
                        this.Show(MainForm.Instance.dockPanel);
                    }
                }
                else
                {
                    //RealVisible = this.Visible;
                    this.Hide();
                }
            }
            allowVisisbleChange = true;
        }

        DockState dockState = DockState.Unknown;
        private void Explorer_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState != DockState.Unknown && this.DockState != DockState.Hidden)
                this.dockState = this.DockState;
        }
        internal bool isActive = false;

        internal void ResetProject()
        {
            Setup();
        }

        public TreeNode SelectedNode { get { return addRemoveList.SelectedNode; } }

        internal EventData Data()
        {
            return addRemoveList.Data<EventData>();
        }

        private void addRemoveList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Data().ID > -1)
            {
                MainForm.eventEditor.Show();
                MainForm.eventEditor.SelectedEvent(Data().ID);
            }
        }

        private void btnMenuEditor_Click(object sender, EventArgs e)
        {
            if (Data().ID > -1)
            {
                MainForm.eventEditor.Show();
                MainForm.eventEditor.SelectedEvent(Data().ID);
            }
        }
    }
}
