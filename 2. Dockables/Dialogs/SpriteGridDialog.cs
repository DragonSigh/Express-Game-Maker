using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace EGMGame.Dialogs
{
    public partial class SpriteGridDialog : Form
    {

        #region Fields
        public AnimationSprite SelectedSprite
        {
            get { return selSprite; }
            set
            {
                selSprite = value;

                cloneSprite = Global.Duplicate<AnimationSprite>(selSprite);

                spriteGridControl.SelectedSprite = value;
                spriteGridControl.cloneSprite = cloneSprite;

                //Texture2D tex = Loader.LoadTexture2D(spriteGridControl.contentManager, value.MaterialId);
                //if (tex != null)
                //{
                //    spriteH.Value = Math.Max(1, (decimal)(tex.Height / value.DisplayRect.Height));
                //    spriteW.Value = Math.Max(1, (decimal)(tex.Width / value.DisplayRect.Width));
                //}
            }
        }
        AnimationSprite cloneSprite;
        AnimationSprite selSprite;

        #endregion


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (selSprite != null)
            {
                Texture2D tex = Loader.Texture2D(spriteGridControl.contentManager, selSprite.MaterialId);
                if (tex != null)
                {
                    spriteH.Value = Math.Max(1, (decimal)(tex.Height / selSprite.DisplayRect.Height));
                    spriteW.Value = Math.Max(1, (decimal)(tex.Width / selSprite.DisplayRect.Width));
                }
            }
        }

        public SpriteGridDialog()
        {
            InitializeComponent();
            this.KeyPreview = true;

        }

        private void spriteH_ValueChanged(object sender, EventArgs e)
        {
            if (selSprite != null)
            {
                Microsoft.Xna.Framework.Rectangle r = selSprite.DisplayRect;
                selSprite.ForceAspectToTexture();
                r.Height = (int)selSprite.Height / (int)spriteH.Value;
                selSprite.DisplayRect = r;
            }
        }

        private void spriteW_ValueChanged(object sender, EventArgs e)
        {
            if (selSprite != null)
            {
                Microsoft.Xna.Framework.Rectangle r = selSprite.DisplayRect;
                selSprite.ForceAspectToTexture();
                r.Width = (int)selSprite.Width / (int)spriteW.Value;
                selSprite.DisplayRect = r;
            }
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
            spriteGridControl.graphicsControl_KeyDown(null, e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            spriteGridControl.graphicsControl_KeyUp(null, e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            spriteGridControl.MouseScroll(e);
        }
    }
}
