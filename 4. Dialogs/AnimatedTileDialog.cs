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

namespace EGMGame
{
    public partial class AnimatedTileDialog : Form
    {

        TileData tile;
        internal List<int[]> animation = new List<int[]>();

        public AnimatedTileDialog()
        {
            InitializeComponent();
            tilesetViewer1.toolStrip1.Visible = false;
        }

        public void SetupTile(TileData _tile)
        {
            tile = _tile;
            if (_tile.Animation == null)
                _tile.Animation = new List<int[]>();
            animation = new List<int[]>(tile.Animation);

        }

        private void okBtn_Click(object sender, EventArgs e)
        {


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            animation.Add(new int[] { 8, 0 });
            listFrames.Items.Add("Frame " + animation.Count.ToString());

            listFrames.SelectedIndex = listFrames.Items.Count - 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listFrames.SelectedIndex > -1)
            {
                int index = listFrames.SelectedIndex;
                animation.RemoveAt(listFrames.SelectedIndex);
                listFrames.Items.RemoveAt(listFrames.SelectedIndex);

                if (listFrames.Items.Count > 0)
                {
                    listFrames.SelectedIndex = index - 1;
                }
                else
                {
                    panelSettings.Enabled = false;
                }
            }
        }

        private void listFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFrames.SelectedIndex > -1 && listFrames.SelectedIndex < animation.Count)
            {
                nudFrames.Value = animation[listFrames.SelectedIndex][0];
                tilesetViewer1.SelectTile(animation[listFrames.SelectedIndex][1]);
                panelSettings.Enabled = true;
            }
            else
                panelSettings.Enabled = false;
        }

        private void nudFrames_ValueChanged(object sender, EventArgs e)
        {
            if (listFrames.SelectedIndex > -1 && listFrames.SelectedIndex < animation.Count)
            {
                animation[listFrames.SelectedIndex][0] = (int)nudFrames.Value;
            }
        }

        private void tilesetViewer1_TileSelectedEvent(Controls.TileEventArgs e)
        {
            if (listFrames.SelectedIndex > -1 && listFrames.SelectedIndex < animation.Count)
            {
                if (tilesetViewer1.selectedTiles.Count > 0)
                    animation[listFrames.SelectedIndex][1] = tilesetViewer1.SelectedTileset.Tiles.IndexOf(tilesetViewer1.selectedTiles[0]);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listFrames.SelectedIndex > 0)
            {
                int index = listFrames.SelectedIndex;
                int[] data = animation[listFrames.SelectedIndex];

                animation.RemoveAt(index);
                animation.Insert(index - 1, data);
                listFrames.Items.Clear();
                int i = 1;
                foreach (int[] frame in animation)
                {
                    listFrames.Items.Add("Frame " + i.ToString());
                    i++;
                }

                listFrames.SelectedIndex = index - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listFrames.SelectedIndex < listFrames.Items.Count - 1)
            {
                int index = listFrames.SelectedIndex;
                int[] data = animation[listFrames.SelectedIndex];

                animation.RemoveAt(index);
                animation.Insert(index + 1, data);
                listFrames.Items.Clear();
                int i = 1;
                foreach (int[] frame in animation)
                {
                    listFrames.Items.Add("Frame " + i.ToString());
                    i++;
                }

                listFrames.SelectedIndex = index + 1;
            }
        }

        private void AnimatedTileDialog_Shown(object sender, EventArgs e)
        {
            tilesetViewer1.SelectedTileset = Global.GetData<TilesetData>(tile.TilesetID, GameData.Tilesets);

            int i = 1;
            foreach (int[] frame in animation)
            {
                listFrames.Items.Add("Frame " + i.ToString());
                i++;
            }

            if (listFrames.Items.Count > 0)
            {
                listFrames.SelectedIndex = 0;
            }
        }

    }
}
