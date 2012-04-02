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
using System.Globalization;
using RibbonLib.Interop;

namespace EGMGame.Docking.Editors
{
    public partial class MapEditor : DockContent
    {
        public MapEditor()
        {
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (Global.Project != null && MainForm.IsHigherThenXP)
                MainForm._tabMapContext.ContextAvailable = ContextAvailability.Active;
        }

        internal static bool allowActivateChange = true;
        private void SceneEditor_Activated(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.SelectedHistory = MainForm.MapEditorHistory[this.mapEditor2.mapViewer];

            if (!MainForm.loadingLayout)
            {
                ShowFloatingWindows();

                // Ribbon
                if (MainForm.IsHigherThenXP)
                    MainForm._tabMapContext.ContextAvailable = ContextAvailability.Active;
            }
            
            mapEditor2.PopulateTilesets();
        }

        internal void ShowFloatingWindows()
        {
            allowActivateChange = false;
            MainForm.tilesExplorer.CheckVisibility(true);
            MainForm.eventsExplorer.CheckVisibility(true);
            MainForm.layersExplorer.CheckVisibility(true);
            MainForm.mapEventsExplorer.CheckVisibility(true);
            MainForm.mapsExplorer.CheckVisibility(true);

            if (MainForm.tilesExplorer.isActive)
                MainForm.tilesExplorer.Activate();
            if (MainForm.eventsExplorer.isActive)
                MainForm.eventsExplorer.Activate();
            if (MainForm.layersExplorer.isActive)
                MainForm.layersExplorer.Activate();
            if (MainForm.mapEventsExplorer.isActive)
                MainForm.mapEventsExplorer.Activate();
            if (MainForm.mapsExplorer.isActive)
                MainForm.mapsExplorer.Activate();
            allowActivateChange = true;
        }

        internal void PopulateTilesets()
        {
            mapEditor2.PopulateTilesets();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (e.Graphics != null)
                e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        internal void SetupScene(MapData scene)
        {
            mapEditor2.SetupScene(scene);
        }

        internal void DeleteScene(MapData scene)
        {
            mapEditor2.DeleteMap(scene);
        }

        private void SceneEditor_Enter(object sender, EventArgs e)
        {
            // MainForm.HistoryExplorer.SelectedHistory = MainForm.MapEditorHistory[this.mapEditor.mapViewer];
        }

        private void SceneEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.E:

                        break;
                    case Keys.Q:

                        break;
                    case Keys.W:

                        break;
                    case Keys.Z:

                        break;
                    case Keys.X:

                        break;
                    case Keys.A:

                        break;
                    case Keys.S:

                        break;
                    case Keys.D:

                        break;
                }
            }
            else
            {
                //switch (e.KeyCode)
                //{
                //    case Keys.C:
                //        mapEditor2.mapViewer.copyToolStripMenuItem_Click(null, null);
                //        break;
                //    case Keys.X:
                //        mapEditor2.mapViewer.cutToolStripMenuItem_Click(null, null);
                //        break;
                //    case Keys.V:
                //        mapEditor2.mapViewer.pasteToolStripMenuItem_Click(null, null);
                //        break;
                //}

            }
        }

        private void MapEditor_VisibleChanged(object sender, EventArgs e)
        {
            //MainForm.eventsExplorer.CheckVisibility(this.Visible);
            //MainForm.layersExplorer.CheckVisibility(this.Visible);
            //MainForm.mapEventsExplorer.CheckVisibility(this.Visible);
            //MainForm.mapsExplorer.CheckVisibility(this.Visible);
            //MainForm.tilesExplorer.CheckVisibility(this.Visible);
        }

        private void MapEditor_Deactivate(object sender, EventArgs e)
        {
            if (!MainForm.loadingLayout)
            {
                HideFloatingWindows();
            }
        }

        internal void HideFloatingWindows()
        {
            allowActivateChange = false;
            MainForm.tilesExplorer.isActive = false;
            MainForm.eventsExplorer.isActive = false;
            MainForm.layersExplorer.isActive = false;
            MainForm.mapEventsExplorer.isActive = false;
            MainForm.mapsExplorer.isActive = false;
            MainForm.tilesExplorer.RealVisible = !MainForm.tilesExplorer.IsHidden;
            MainForm.eventsExplorer.RealVisible = !MainForm.eventsExplorer.IsHidden;
            MainForm.layersExplorer.RealVisible = !MainForm.layersExplorer.IsHidden;
            MainForm.mapEventsExplorer.RealVisible = !MainForm.mapEventsExplorer.IsHidden;
            MainForm.mapsExplorer.RealVisible = !MainForm.mapsExplorer.IsHidden;
            foreach (FloatWindow fw in MainForm.Instance.dockPanel.FloatWindows)
            {
                if ((MainForm.tilesExplorer.FloatPane != null && fw == MainForm.tilesExplorer.FloatPane.FloatWindow) ||
                    (MainForm.eventsExplorer.FloatPane != null && fw == MainForm.eventsExplorer.FloatPane.FloatWindow) ||
                    (MainForm.layersExplorer.FloatPane != null && fw == MainForm.layersExplorer.FloatPane.FloatWindow) ||
                    (MainForm.mapEventsExplorer.FloatPane != null && fw == MainForm.mapEventsExplorer.FloatPane.FloatWindow) ||
                    (MainForm.mapsExplorer.FloatPane != null && fw == MainForm.mapsExplorer.FloatPane.FloatWindow))
                {
                    for (int index = 0; index < fw.NestedPanes.Count; index++)
                    {
                        if (MainForm.tilesExplorer == fw.NestedPanes[index].ActiveContent)
                            MainForm.tilesExplorer.isActive = true;
                        if (MainForm.eventsExplorer == fw.NestedPanes[index].ActiveContent)
                            MainForm.eventsExplorer.isActive = true;
                        if (MainForm.layersExplorer == fw.NestedPanes[index].ActiveContent)
                            MainForm.layersExplorer.isActive = true;
                        if (MainForm.mapEventsExplorer == fw.NestedPanes[index].ActiveContent)
                            MainForm.mapEventsExplorer.isActive = true;
                        if (MainForm.mapsExplorer == fw.NestedPanes[index].ActiveContent)
                            MainForm.mapsExplorer.isActive = true;
                    }
                }
            }

            MainForm.tilesExplorer.CheckVisibility(false);
            MainForm.eventsExplorer.CheckVisibility(false);
            MainForm.layersExplorer.CheckVisibility(false);
            MainForm.mapEventsExplorer.CheckVisibility(false);
            MainForm.mapsExplorer.CheckVisibility(false);

            mapEditor2.ClearSelected();

            allowActivateChange = true;
        }

        internal void ResetProject()
        {
            mapEditor2.ResetProject();
        }

        internal void Unload()
        {
            mapEditor2.Unload();
        }
    }
}
