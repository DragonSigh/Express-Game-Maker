using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Dialogs
{
    public partial class TilePickerDialog : Form
    {
        public TileData Tile = null;

        public TilesetData Tileset
        {
            set
            {
                tileViewer.SelectedTileset = value;
                tileViewer.Grid = value.Grid;
            }
        }

        public TilePickerDialog()
        {
            InitializeComponent();

            tileViewer.TilePickedEvent += TilePicked;
        }

        public void TilePicked(object sender, EventArgs e)
        {
            Tile = (TileData)sender;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
