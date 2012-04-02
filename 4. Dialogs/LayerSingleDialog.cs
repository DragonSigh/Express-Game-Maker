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
    public partial class LayerSingleDialog : Form
    {
        public LayerBackground SelectedBG
        {
            get { return selBG; }
            set { selBG = value; Setup(); }
        }
        LayerBackground selBG;

        bool allowChange = true;
        bool modified = false;

        public LayerSingleDialog()
        {
            InitializeComponent();
        }

        internal void Setup()
        {
            if (selBG == null)
            {
                this.Hide(); return;
            }
            allowChange = false;
            if (selBG.Size.X == 0) selBG.Size.X = 1;
            if (selBG.Size.Y == 0) selBG.Size.Y = 1;
            SizeX.Value = (decimal)selBG.Size.X;
            SizeY.Value = (decimal)selBG.Size.Y;
            posX.Value = (decimal)(selBG.Position.X - selBG.Size.X / 2);
            posY.Value = (decimal)(selBG.Position.Y - selBG.Size.Y / 2);
            rotateBox.Value = (decimal)Microsoft.Xna.Framework.MathHelper.ToDegrees(selBG.Rotation);
            allowChange = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void SizeX_ValueChanged(object sender, EventArgs e)
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
                if (oldSizeX == -1)
                    oldSizeX = selBG.Size.X;
                selBG.Size = new Microsoft.Xna.Framework.Vector2((float)SizeX.Value, (float)SizeY.Value);
                //selBG.Position = new Microsoft.Xna.Framework.Vector2((float)posX.Value + ((float)SizeX.Value - oldSizeX) + selBG.Size.X / 2, (float)posY.Value + selBG.Size.Y / 2);
                selBG.Position = new Microsoft.Xna.Framework.Vector2((float)posX.Value + selBG.Size.X / 2, (float)posY.Value + selBG.Size.Y / 2);
                oldSizeX = -1;
            }
        }

        float oldSizeX = -1;
        private void SizeX_Validated(object sender, EventArgs e)
        {
            if (oldSizeX > -1 && selBG.Size.X != oldSizeX)
            {
                float newSizeX = selBG.Size.X;
                selBG.Size = new Microsoft.Xna.Framework.Vector2(oldSizeX, selBG.Size.Y);
                //MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selBG));
                selBG.Size = new Microsoft.Xna.Framework.Vector2(newSizeX, selBG.Size.Y);
                //selBG.Position = new Microsoft.Xna.Framework.Vector2((float)posX.Value + selBG.Size.X / 2, (float)posY.Value + selBG.Size.Y / 2);
                oldSizeX = -1;
            }
        }
        private void SizeY_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                if (oldSizeY == -1)
                    oldSizeY = selBG.Size.Y;
                selBG.Size = new Microsoft.Xna.Framework.Vector2((float)SizeX.Value, (float)SizeY.Value);
                selBG.Position = new Microsoft.Xna.Framework.Vector2((float)posX.Value + selBG.Size.X / 2, (float)posY.Value + selBG.Size.Y / 2);
                oldSizeY = -1;
            }
        }
        private void posY_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                selBG.Position = new Microsoft.Xna.Framework.Vector2((float)posX.Value + selBG.Size.X / 2, (float)posY.Value + selBG.Size.Y / 2);
            }
        }

        private void posX_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                selBG.Position = new Microsoft.Xna.Framework.Vector2((float)posX.Value + selBG.Size.X / 2, (float)posY.Value + selBG.Size.Y / 2);
            }
        }

        float oldSizeY = -1;
        private void SizeY_Validated(object sender, EventArgs e)
        {
            if (oldSizeY > -1 && selBG.Size.Y != oldSizeY)
            {
                float newSizeY = selBG.Size.Y;
                //.Size = new Microsoft.Xna.Framework.Vector2(selBG.Size.X, oldSizeY);
                // MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selBG));
                selBG.Size = new Microsoft.Xna.Framework.Vector2(selBG.Size.X, newSizeY);
                oldSizeY = -1;
            }
        }

        private void rotateBox_ValueChanged(object sender, EventArgs e)
        {
            if (this.Visible && allowChange)
            {
                if (rotate == -1)
                    rotate = selBG.Rotation;
                selBG.Rotation = Microsoft.Xna.Framework.MathHelper.ToRadians((float)rotateBox.Value);
            }
        }

        float rotate = -1;
        private void rotateBox_Validated(object sender, EventArgs e)
        {
            if (rotate > -1 && selBG.Rotation != rotate)
            {
                float newRotate = selBG.Rotation;
                selBG.Rotation = rotate;
                //MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new TileMod(selBG));
                selBG.Rotation = newRotate;
                rotate = -1;
            }
        }



        private void TileSettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
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
