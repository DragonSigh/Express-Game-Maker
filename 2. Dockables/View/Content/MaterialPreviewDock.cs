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
    public partial class MaterialPreviewDock : DockContent
    {
        public MaterialPreviewDock()
        {
            InitializeComponent();

            materialViewer1.EnableControls();
        }

        internal void ShowFont(EGMGame.Library.MaterialData materialData)
        {
            materialViewer1.SelectedMaterial = materialData;
        }

        internal void ShowVideo(EGMGame.Library.MaterialData materialData)
        {
            materialViewer1.SelectedMaterial = materialData;
        }

        internal void ShowImage(EGMGame.Library.MaterialData materialData)
        {
            materialViewer1.SelectedMaterial = materialData;
        }

        internal void ResetProject()
        {
            materialViewer1.ResetContentManager();
            materialViewer1.SelectedMaterial = null;
        }

        internal void Unload()
        {
            materialViewer1.contentManager.Unload();
        }
    }
}
