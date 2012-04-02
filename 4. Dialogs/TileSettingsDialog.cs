using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.Threading;

namespace EGMGame
{
    public partial class TileSettingsDialog : Form
    {
        public TileData SelectedTile
        {
            get { return selTile; }
            set { selTile = value; Setup(); }
        }
        TileData selTile;

        bool allowChange = true;
        bool modified = false;
        List<TileData> clones = new List<TileData>();

        public TileSettingsDialog()
        {
            InitializeComponent();
        }

        internal void Setup()
        {
            if (selTile == null)
            {
                this.Hide(); return;
            }
            allowChange = false;
            scaleX.Value = (decimal)selTile.Scale.X;
            scaleY.Value = (decimal)selTile.Scale.Y;
            rotateBox.Value = (decimal)selTile.Rotation;
            opacityBox.Value = (decimal)selTile.Opacity;
            allowChange = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
            selTile.HorizontalFlip = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
            selTile.VerticalFlip = checkBox2.Checked;
        }

        private void scaleX_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                //if (isMouseDown)
                //{
                //    modified = true;
                //    if (clones.Count == 0)
                //        clones.Add(selTile.Clone());
                //}
                //else
                //{
                //    //MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                //}
                if (oldScaleX == -1)
                    oldScaleX = selTile.Scale.X;
                selTile.Scale = new Microsoft.Xna.Framework.Vector2((float)scaleX.Value, (float)scaleY.Value);
            }
        }

        float oldScaleX = -1;
        private void scaleX_Validated(object sender, EventArgs e)
        {
            if (oldScaleX > -1 && selTile.Scale.X != oldScaleX)
            {
                float newScaleX = selTile.Scale.X;
                selTile.Scale = new Microsoft.Xna.Framework.Vector2(oldScaleX, selTile.Scale.Y);
                MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                selTile.Scale = new Microsoft.Xna.Framework.Vector2(newScaleX, selTile.Scale.Y);
                oldScaleX = -1;
            }
        }
        private void scaleY_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                //if (isMouseDown)
                //{
                //    modified = true;
                //    if (clones.Count == 0)
                //        clones.Add(selTile.Clone());
                //}
                //else
                //{
                //    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                //}
                if (oldScaleY == -1)
                    oldScaleY = selTile.Scale.Y;
                selTile.Scale = new Microsoft.Xna.Framework.Vector2((float)scaleX.Value, (float)scaleY.Value);
            }
        }

        float oldScaleY = -1;
        private void scaleY_Validated(object sender, EventArgs e)
        {
            if (oldScaleY > -1 && selTile.Scale.Y != oldScaleY)
            {
                float newScaleY = selTile.Scale.Y;
                selTile.Scale = new Microsoft.Xna.Framework.Vector2(selTile.Scale.X, oldScaleY);
                MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                selTile.Scale = new Microsoft.Xna.Framework.Vector2(selTile.Scale.X, newScaleY);
                oldScaleY = -1;
            }
        }

        private void rotateBox_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                //if (isMouseDown)
                //{
                //    modified = true;
                //    if (clones.Count == 0)
                //        clones.Add(selTile.Clone());
                //}
                //else
                //{
                //    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                //}
                if (rotate == -1)
                    rotate = selTile.Rotation;
                selTile.Rotation = (float)rotateBox.Value;
            }
        }

        float rotate = -1;
        private void rotateBox_Validated(object sender, EventArgs e)
        {
            if (rotate > -1 && selTile.Rotation != rotate)
            {
                float newRotate = selTile.Rotation;
                selTile.Rotation = rotate;
                MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                selTile.Rotation = newRotate;
                rotate = -1;
            }
        }


        private void opacityBox_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
            //    if (isMouseDown)
            //    {
            //        modified = true;
            //        if (clones.Count == 0)
            //            clones.Add(selTile.Clone());
            //    }
            //    else
            //    {
            //        MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
            //    }
                if (!oChange)
                {
                    oChange = true;
                    opacity = selTile.Opacity;
                }
                selTile.Opacity = (byte)opacityBox.Value;
            }
        }

        byte opacity = 0;
        bool oChange = false;
        private void opacityBox_Validated(object sender, EventArgs e)
        {
            if (oChange && selTile.Opacity != rotate)
            {
                byte newOpacity = selTile.Opacity;
                selTile.Opacity = opacity;
                MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                selTile.Opacity = newOpacity;
                opacity = 0;
                oChange = true;
            }
        }
        private void TileSettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void opacityBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (modified)
            {
                modified = false;
                TileData temp = selTile.Clone();
                selTile.Convert(clones[0]);
                MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selTile));
                selTile.Convert(temp);
                clones.Clear();
            }
        }

        private void opacityBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void opacityBox_MouseDown(object sender, MouseEventArgs e)
        {
        }

        #region Mouse Focus/Defocus Effect
        delegate void DropOpacityCallBack();
        bool isActive = true;

        protected override void OnActivated(EventArgs e)
        {
            this.Opacity = (double)1.0;
            isActive = true;
        }
        protected override void OnDeactivate(EventArgs e)
        {
            Thread thread = new Thread(DropOpacity);
            thread.Start();
            isActive = false;
        }
        
        private void DropOpacity()
        {
            while (this.Opacity > .1 && !isActive)
            {
                Thread.Sleep(2);
                DropOpacityCallBack cb = new DropOpacityCallBack(DeFocusOpaity);
                this.Invoke(cb);
            }
        }
        private void DeFocusOpaity()
        {
            this.Opacity -= 0.01;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.Activate();
        }
        #endregion

    }
}
