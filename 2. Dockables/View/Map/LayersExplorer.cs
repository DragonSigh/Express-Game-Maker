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

namespace EGMGame.Docking.Explorers
{
    public partial class LayersExplorer : DockContent
    {
        public LayersExplorer()
        {
            InitializeComponent();
        }

        private void layersList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            MainForm.mapEditor.mapEditor2.mapViewer.layersList_AddItem(sender, ca);
            if (layersList.Count > 0)
                layersList.SelectedIndex = layersList.Count - 1;
        }

        private void layersList_DownItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            MainForm.mapEditor.mapEditor2.mapViewer.layersList_DownItem(sender, ca);
        }

        private void layersList_UpItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            MainForm.mapEditor.mapEditor2.mapViewer.layersList_UpItem(sender, ca);
        }

        private void layersList_ItemCheckedState(object sender, EGMGame.Controls.CheckedAddRemoveListEventArgs ca)
        {
            MainForm.mapEditor.mapEditor2.mapViewer.layersList_ItemCheckedState(sender, ca);
        }

        private bool layersList_ItemCheckState(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            return MainForm.mapEditor.mapEditor2.mapViewer.layersList_ItemCheckState(sender, ca);
        }

        private void layersList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            MainForm.mapEditor.mapEditor2.mapViewer.layersList_RemoveItem(sender, ca);
            MainForm.mapEventsExplorer.Setup();
        }


        bool selectedOnce = false;
        private void layersList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (selectedOnce)
                Global.Project.SelectedLayer = layersList.SelectedIndex;
            MainForm.mapEditor.mapEditor2.mapViewer.layersList_SelectItem(sender, ca);
            selectedOnce = true;
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

        internal void SelecteLayer(int index)
        {
            if (index > -1 && index < layersList.Count)
                layersList.SelectedIndex = index;
        }

        internal void ResetProject()
        {
        }
    }
}
