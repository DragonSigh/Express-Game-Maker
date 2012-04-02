using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Extensions;
using EGMGame.Components;

namespace EGMGame.Framework
{
    public class DynamicBar : MenuItem
    {
        #region Properties
        public int Max, Min, Value, Skin;

        public new Vector2 Position { get; set; }

        public new Vector2 Size { get; set; }

        public new int Padding { get; set; }

        public new bool Enabled { get; set; }

        public new bool Visible { get; set; }
        #endregion

        /// <summary>
        /// Draw Dynamicbar
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if (Min < Max)
            {
                Value = Math.Max(Min, Math.Min(Max, Value));
                if (Skin > -1)
                {
                    SkinData skin = GameData.Skins.GetData(Skin);
                    if (skin != null)
                    {
                        if (skin.DynamicBar.Rounded)
                        {
                            // Load Textures
                            Texture2D left = Content.Texture2D(skin.DynamicBar.LeftID);
                            Texture2D center = Content.Texture2D(skin.DynamicBar.BackgroundID);
                            Texture2D right = Content.Texture2D(skin.DynamicBar.RightID);

                            // Load bar Textures
                            Texture2D barleft = Content.Texture2D(skin.DynamicBar.BarLeftID);
                            Texture2D barcenter = Content.Texture2D(skin.DynamicBar.BarBackgroundID);
                            Texture2D barright = Content.Texture2D(skin.DynamicBar.BarRightID);

                            // Calculate areas
                            int centerStart = left.Width;
                            int rightStart = (int)Size.X - right.Width;

                            int centerWidth = (int)Size.X - right.Width - left.Width;
                            int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);


                            // Draw Left
                            Global.SpriteBatch.Draw(left, new Rectangle((int)Position.X, (int)Position.Y, left.Width, (int)Size.Y), Color.White);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(Position.X + centerStart + (i * center.Width)), (int)Position.Y, (int)center.Width, (int)Size.Y), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(Position.X + centerStart + (fullCenterRepeats * center.Width)), (int)Position.Y, (int)center.Width, (int)Size.Y),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }

                            // Draw Right
                            Global.SpriteBatch.Draw(right, new Rectangle((int)(Position.X + rightStart), (int)Position.Y, (int)right.Width, (int)Size.Y), Color.White);

                            // BAR
                            // calculate areas
                            int barcenterStart = barleft.Width;
                            int barrightStart = (int)Size.X - barright.Width;

                            // calucate bar width based on the current value and its min and max
                            int maxval = Max - Min;
                            int valinmax = Value - Min;
                            decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;

                            int barWidth = (int)((decimal)Size.X * percentofvalinmax);

                            if (barWidth < barleft.Width)
                            {
                                // Draw Left
                                Global.SpriteBatch.Draw(barleft, new Rectangle((int)(Position.X), (int)Position.Y, (int)barWidth, (int)Size.Y), new Rectangle(0, 0, barWidth, (int)barleft.Height), Color.White);
                            }
                            else
                            {
                                int barcenterWidth = (int)barWidth - barleft.Width;
                                int barfullCenterRepeats = (int)Math.Floor((double)(barcenterWidth / barcenter.Width));
                                int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                // Draw Left
                                Global.SpriteBatch.Draw(barleft, new Rectangle((int)Position.X, (int)Position.Y, barleft.Width, (int)Size.Y), Color.White);

                                // Draw Repeated Center
                                for (int i = 0; i < barfullCenterRepeats; i++)
                                {
                                    Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(Position.X + barcenterStart + (i * barcenter.Width)), (int)Position.Y, (int)barcenter.Width, (int)Size.Y), Color.White);
                                }
                                // Draw Leftover Center
                                if (barfinalCenterTexels > 0)
                                {
                                    Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(Position.X + barcenterStart + (barfullCenterRepeats * barcenter.Width)), (int)Position.Y, (int)barfinalCenterTexels, (int)Size.Y),
                                        new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                }
                                if (barWidth > barrightStart)
                                {
                                    // Draw Right
                                    Global.SpriteBatch.Draw(barright, new Rectangle((int)(Position.X + barrightStart), (int)Position.Y, (int)(barWidth - barrightStart), (int)Size.Y), new Rectangle(0, 0, barWidth - barrightStart, (int)barright.Height), Color.White);
                                }
                            }
                        }
                        else
                        {
                            // Load Textures
                            Texture2D center = Content.Texture2D(skin.DynamicBar.BackgroundID);
                            Texture2D barcenter = Content.Texture2D(skin.DynamicBar.BarBackgroundID);

                            if (center.Name != "BLANK")
                            {
                                // Calculate areas
                                int centerWidth = (int)Size.X;
                                int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                                int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < fullCenterRepeats; i++)
                                {
                                    Global.SpriteBatch.Draw(center, new Rectangle((int)(Position.X + (i * center.Width)), (int)Position.Y, (int)center.Width, (int)Size.Y), Color.White);
                                }
                                // Draw Leftover Center
                                if (finalCenterTexels > 0)
                                {
                                    Global.SpriteBatch.Draw(center, new Rectangle((int)(Position.X + (fullCenterRepeats * center.Width)), (int)Position.Y, (int)finalCenterTexels, (int)Size.Y),
                                        new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                                }
                            }

                            if (barcenter.Name != "BLANK")
                            {
                                // calucate bar width based on the current value and its min and max
                                int maxval = Max - Min;
                                int valinmax = Value - Min;

                                decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;
                                int barWidth = (int)((decimal)Size.X * percentofvalinmax);

                                int barcenterWidth = (int)barWidth;
                                int barfullCenterRepeats = (int)Math.Floor((double)(barcenterWidth / barcenter.Width));
                                int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < barfullCenterRepeats; i++)
                                {
                                    Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(Position.X + (i * barcenter.Width)), (int)Position.Y, (int)barcenter.Width, (int)Size.Y), Color.White);
                                }
                                // Draw Leftover Center
                                if (barfinalCenterTexels > 0)
                                {
                                    Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(Position.X + (barfullCenterRepeats * barcenter.Width)), (int)Position.Y, (int)barfinalCenterTexels, (int)Size.Y),
                                        new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                }
                            }
                        }
                    }
                }
            }
        }

        #region Methods: Properties
        public override void SetSkin(int skinId)
        {
            Skin = skinId;
        }

        public override void SetSkin(string skinName)
        {
            Skin = GameData.Skins.GetData(skinName).ID;
        }
        #endregion
    }
}
