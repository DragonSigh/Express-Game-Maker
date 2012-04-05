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
    public partial class TilesExplorer : DockContent
    {
        public TilesExplorer()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // GUI Initialization
            toolStrip.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }

        private void cbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm.mapEditor.mapEditor2.cbTileset_SelectedIndexChanged(sender, e);
        }
        /// <summary>
        /// Checked Change Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridBtn_CheckedChanged(object sender, EventArgs e)
        {
            tileViewer.TilesetView = gridBtn.Checked;

            MainForm.mapEditor.mapEditor2.PopulateTilesets();
        }

        private void cbTileset_EnabledChanged(object sender, EventArgs e)
        {
            gridBtn.Enabled = cbTileset.Enabled;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            tileViewer.graphicsControl_KeyDown(null, e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            tileViewer.graphicsControl_KeyUp(null, e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            //tileViewer.MouseScroll(e);
        }


        internal bool RealVisible = false;
        bool allowVisisbleChange = true;
        private void Explorer_VisibleChanged(object sender, EventArgs e)
        {
            if (allowVisisbleChange && EGMGame.Docking.Editors.MapEditor.allowActivateChange)
            {
                // RealVisible = this.Visible;
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
                        this.Show(MainForm.Instance.dockPanel);
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

        private void TilesExplorer_DockChanged(object sender, EventArgs e)
        {

        }

        private void TilesExplorer_EnabledChanged(object sender, EventArgs e)
        {

        }

        internal void Zoom(float p)
        {
            tileViewer.Zoom((int)(p * 100), true);
        }

        internal void ResetProject()
        {
            MainForm.mapEditor.mapEditor2.PopulateTilesets();
            tileViewer.ResetContentManager();
            autoTileViewer1.ResetContentManager();
        }

        private void autoTileViewer1_Load(object sender, EventArgs e)
        {

        }

        internal void Unload()
        {
            tileViewer.ResetContentManager();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditTileset_Click(object sender, EventArgs e)
        {
            if (tileViewer.TilesetView && MainForm.TilesetViewer.SelectedTileset != null)
            {
                MainForm.tilesetEditor.Show();
                MainForm.tilesetEditor.SelectTilest(MainForm.TilesetViewer.SelectedTileset.ID);
            }
            else if (!tileViewer.TilesetView && MainForm.TilesetViewer.selectedTiles.Count > 0) 
            {
                MainForm.tilesetEditor.Show();
                MainForm.tilesetEditor.SelectTilest(MainForm.TilesetViewer.selectedTiles[0].TilesetID);
            }
        }
    }
}
