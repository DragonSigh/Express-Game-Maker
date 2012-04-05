//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using Microsoft.Xna.Framework;

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class PickPositionOnMapDialog : Form
    {
        public MapData SelectedMap
        {
            get { return selectedMap; }
            set
            {
                selectedMap = value; mapViewer.SetupScene(value); mapViewer.SelectedLayer = value.Layers[0];
            }
        }
        MapData selectedMap;

        public bool IsScreenSelect { set { mapViewer.IsScreenSelect = value; ; } }

        public Vector2 Position
        {
            get { return pos; }
            set { pos = value; }
        }
        Vector2 pos;
        bool snapToGrid;
        public PickPositionOnMapDialog()
        {
            snapToGrid = Global.Project.SnapToGrid;
            InitializeComponent();
        }
        /// <summary>
        /// Position selected
        /// </summary>
        /// <param name="e"></param>
        private void mapViewer_TileSelectedEvent(TileEventArgs e)
        {
            Global.Project.SnapToGrid = snapToGrid;
            Position = e.Position;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PickPositionOnMapDialog_Shown(object sender, EventArgs e)
        {
            mapViewer.UpdateTiles();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Global.Project.SnapToGrid = snapToGrid; 
            base.OnClosing(e);
        }

        public bool DoNotDrawPlayer { set { mapViewer.DoNotDrawPlayer = value; } }

        public bool IsNotMap { set { mapViewer.IsNotMap = value; } }
    }
}
