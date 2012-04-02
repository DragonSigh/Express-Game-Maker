using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Controls;

namespace EGMGame.Dialogs
{
    public partial class FromSpriteSheetForDirDialog : Form
    {
        internal AnimationAction Action;
        internal int Direction;
        MaterialData data;

        public FromSpriteSheetForDirDialog()
        {
            InitializeComponent();

            cbSprites.RefreshList(false, MaterialDataType.Image);
            spriteH.Value = Global.Project.SpriteRows;
            spriteW.Value = Global.Project.SpriteCols;
            nudFrames.Value = Global.Project.SpriteFrames;
        }

        private void spriteH_ValueChanged(object sender, EventArgs e)
        {
            spriteGridControl.Grid.Y = (float)spriteH.Value;

        }

        private void spriteW_ValueChanged(object sender, EventArgs e)
        {
            spriteGridControl.Grid.X = (float)spriteW.Value;
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
        /// <summary>
        /// Key down
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            //spriteGridControl.graphicsControl_KeyDown(null, e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            //spriteGridControl.graphicsControl_KeyUp(null, e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            //spriteGridControl.MouseScroll(e);
        }

        private void cbSprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            data = cbSprites.Data();
            spriteGridControl.Data = data;
        }

        private void nudFrames_ValueChanged(object sender, EventArgs e)
        {
        }

        private void rbColumns_CheckedChanged(object sender, EventArgs e)
        {
            spriteGridControl.Columns = rbColumns.Checked;
        }

        public bool IsOk;
        public void btnOK_Click(object sender, EventArgs e)
        {
            Global.Project.SpriteRows = spriteH.Value;
            Global.Project.SpriteCols = spriteW.Value;
            Global.Project.SpriteFrames = nudFrames.Value;

            if (rbColumns.Checked)
            {

                for (int col = (int)spriteGridControl.selection.X; col < (int)spriteGridControl.selection.X + (int)nudFrames2.Value && col < (int)spriteW.Value; col++)
                {
                    AnimationFrame a;
                    a = new AnimationFrame();
                    a.ID = Global.GetID(Action.Directions[Direction]);
                    Action.Directions[Direction].Add(a);
                    a.TimeElapse = (int)nudFrames.Value;
                    a.Name = a.TimeElapse.ToString() + " Frames";

                    // History
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.animationEditor.DataFrameAdded), new DataRemoveDelegate(MainForm.animationEditor.DataFrameRemoved), Action.Directions[Direction], Action.Directions[Direction].IndexOf(a)));

                    // Add sprite
                    AnimationSprite sprite = new AnimationSprite();
                    sprite.Name = Global.GetName("Sprite", a.Sprites);
                    sprite.ID = Global.GetID(a.Sprites);

                    sprite.MaterialId = cbSprites.Data().ID;

                    sprite.AspectToTexture();

                    Microsoft.Xna.Framework.Rectangle r = sprite.DisplayRect;
                    r.Height = (int)sprite.Height / (int)spriteH.Value;
                    r.Width = (int)sprite.Width / (int)spriteW.Value;
                    r.X = r.Width * col;
                    r.Y = r.Height * (int)spriteGridControl.selection.Y;
                    sprite.DisplayRect = r;
                    sprite.Position = new Microsoft.Xna.Framework.Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2);
                    a.Sprites.Add(sprite);
                    // History
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(sprite, new DataAddDelegate(MainForm.animationEditor.DataSpriteAdded), new DataRemoveDelegate(MainForm.animationEditor.DataSpriteRemoved), a.Sprites, a.Sprites.IndexOf(sprite)));
                }

            }
            else
            {

                for (int col = (int)spriteGridControl.selection.Y; col < (int)spriteGridControl.selection.Y + (int)nudFrames2.Value && col < (int)spriteH.Value; col++)
                {
                    AnimationFrame a;
                    a = new AnimationFrame();
                    a.ID = Global.GetID(Action.Directions[Direction]);
                    Action.Directions[Direction].Add(a);
                    a.TimeElapse = (int)nudFrames.Value;
                    a.Name = a.TimeElapse.ToString() + " Frames";

                    // History
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.animationEditor.DataFrameAdded), new DataRemoveDelegate(MainForm.animationEditor.DataFrameRemoved), Action.Directions[Direction], Action.Directions[Direction].IndexOf(a)));

                    // Add sprite
                    AnimationSprite sprite = new AnimationSprite();
                    sprite.Name = Global.GetName("Sprite", a.Sprites);
                    sprite.ID = Global.GetID(a.Sprites);

                    sprite.MaterialId = cbSprites.Data().ID;

                    sprite.AspectToTexture();

                    Microsoft.Xna.Framework.Rectangle r = sprite.DisplayRect;
                    r.Height = (int)sprite.Height / (int)spriteH.Value;
                    r.Width = (int)sprite.Width / (int)spriteW.Value;
                    r.X = r.Width * (int)spriteGridControl.selection.Y;
                    r.Y = r.Height * col ;
                    sprite.DisplayRect = r;
                    sprite.Position = new Microsoft.Xna.Framework.Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2);
                    a.Sprites.Add(sprite);
                    // History
                    MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(sprite, new DataAddDelegate(MainForm.animationEditor.DataSpriteAdded), new DataRemoveDelegate(MainForm.animationEditor.DataSpriteRemoved), a.Sprites, a.Sprites.IndexOf(sprite)));
                }
            }
            IsOk = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }

        private void nudFrames2_ValueChanged(object sender, EventArgs e)
        {
            spriteGridControl.Frames = (int)nudFrames2.Value;
        }

        private void FromSpriteSheetForDirDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        internal void ResetContentManager()
        {
            spriteGridControl.ResetContentManager();
        }

    }
}
