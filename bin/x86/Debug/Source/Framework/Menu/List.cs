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
using Microsoft.Xna.Framework.Input;

namespace EGMGame.Framework
{
    /// <summary>
    /// Inherit from this class to make a list.
    /// </summary>
    public class List : MenuItem
    {
        #region Properties
        public int Skin, ItemHeight, Columns, NumberOfItems,
            Index, HighlighterIndex = 1;
        byte HighlighterCount = 50;
        public Color HighlightBorderColor, HighlightStartGradient, HighlightEndGradient,
            DisabledBorderColor, DisabledStartGradient, DisabledEndGradient;

        public new Vector2 Position { get; set; }

        public new Vector2 Size { get; set; }

        public new int Padding { get; set; }

        public new bool Enabled { get; set; }

        public new bool Visible { get; set; }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            if (!Enabled || !Visible)
                return;
            int increment = Columns;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer))
            {
                if (Index > 0) Index--;
                else Index = NumberOfItems - 1;
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer))
            {
                if (Index > 0) Index = Math.Max(Index - increment, 0);
                else Index = NumberOfItems - 1;
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer))
            {
                if (Index < NumberOfItems - 1) Index++;
                else Index = 0;
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer))
            {
                if (Index < NumberOfItems - 1) Index = Math.Min(Index + increment, NumberOfItems - 1);
                else Index = 0;
            }
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            DrawListBackground();
            DrawListItems();
            DrawListHighlighter();
        }

        /// <summary>
        /// Draw List Items
        /// </summary>
        public virtual void DrawListItems()
        {
            // To Do: Draw Items Here
        }

        /// <summary>
        /// Draw The Highlighter
        /// </summary>
        public virtual void DrawListHighlighter()
        {
            int currentColumn = 1;
            int width = ((int)Size.X - (Padding * (Columns - 1))) / Columns;
            int currentx = 10, currenty = 10;
            Vector2 index = new Vector2();
            int maxNumberOfRows = (int)((Size.Y - (Padding * NumberOfItems / Columns)) / ItemHeight) + (NumberOfItems % (Columns + 1));
            int startIndex = 0;
            if (Index / Columns > maxNumberOfRows / Columns) startIndex = Index - maxNumberOfRows - (Index % Columns);
            for (int i = startIndex; (i < NumberOfItems && i <= maxNumberOfRows + startIndex + 1); i++)
            {
                if (i == Index)
                {
                    index.X = currentx;
                    index.Y = currenty;
                    break;
                }
                currentColumn++;

                if (currentColumn > Columns)
                {
                    currentColumn = 1;
                    currenty += ItemHeight + Padding;
                    currentx = 10;
                }
                else
                {
                    currentx += width + Padding;
                }
            }

            if (NumberOfItems > 0)
            {
                index.X += (Position.X);
                index.Y += (Position.Y) + 4;
                Rectangle rect = new Rectangle((int)(index.X), (int)(index.Y) - 2, width - 20, ItemHeight + 9);
                DrawSelectionRectangle(rect, HighlightBorderColor, HighlightStartGradient, HighlightEndGradient, DisabledBorderColor, DisabledStartGradient, DisabledEndGradient);
            }
        }

        /// <summary>
        /// Draw Selection Rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="HighlightBorderColor"></param>
        /// <param name="HighlightStartGradient"></param>
        /// <param name="HighlightEndGradient"></param>
        /// <param name="DisabledBorderColor"></param>
        /// <param name="DisabledStartGradient"></param>
        /// <param name="DisabledEndGradient"></param>
        public virtual void DrawSelectionRectangle(Rectangle rect, Color HighlightBorderColor, Color HighlightStartGradient, Color HighlightEndGradient, Color DisabledBorderColor, Color DisabledStartGradient, Color DisabledEndGradient)
        {
            if (Enabled)
            {
                GraphicsHelper.DrawRectangle(GraphicsHelper.Texture, rect, HighlightBorderColor);
                Color c1, c2;
                if (HighlighterIndex == 0)
                {
                    HighlighterCount--;
                    c1 = HighlightStartGradient;
                    c2 = HighlightEndGradient;
                    c1.A -= HighlighterCount;
                    c2.A -= HighlighterCount;

                    if (HighlighterCount <= (HighlightStartGradient.A > HighlightEndGradient.A ? HighlightEndGradient.A : HighlightStartGradient.A) - 50)
                    {
                        HighlighterIndex = 1;
                        HighlighterCount = (byte)((HighlightStartGradient.A > HighlightEndGradient.A ? HighlightEndGradient.A : HighlightStartGradient.A) - 50);
                    }
                }
                else
                {
                    HighlighterCount++;
                    c1 = HighlightStartGradient;
                    c2 = HighlightEndGradient;
                    c1.A -= HighlighterCount;
                    c2.A -= HighlighterCount;
                    if (HighlighterCount >= HighlightStartGradient.A)
                    {
                        HighlighterIndex = 0; HighlighterCount = (HighlightStartGradient.A > HighlightEndGradient.A ? HighlightEndGradient.A : HighlightStartGradient.A);
                    }
                }
                GraphicsHelper.FillGradient(rect, c1, c2);
            }
            else
            {
                GraphicsHelper.FillGradient(rect, DisabledStartGradient, DisabledEndGradient);
                GraphicsHelper.DrawRectangle(GraphicsHelper.Texture, rect, DisabledBorderColor);
            }

        }

        /// <summary>
        /// Draw Background
        /// </summary>
        public virtual void DrawListBackground()
        {
            #region Draw Background
            // Calculate Areas
            int X = (int)Position.X;
            int Y = (int)Position.Y;
            // Draw the containing list
            if (Skin > -1)
            {
                SkinData skin = GameData.Skins.GetData(Skin);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = Content.Texture2D(skin.List.TopLeftID);
                    Texture2D topCenter = Content.Texture2D(skin.List.TopID);
                    Texture2D topRight = Content.Texture2D(skin.List.TopRightID);

                    Texture2D left = Content.Texture2D(skin.List.LeftID);
                    Texture2D right = Content.Texture2D(skin.List.RightID);

                    Texture2D bottomLeft = Content.Texture2D(skin.List.BottomLeftID);
                    Texture2D bottomCenter = Content.Texture2D(skin.List.BottomID);
                    Texture2D bottomRight = Content.Texture2D(skin.List.BottomRightID);

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)Size.X - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)Size.Y - (int)bottomLeft.Height;

                    int rightX = (int)Size.X - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)Size.X - bottomRight.Width;
                    int bottomRightStart = (int)Size.Y - bottomRight.Height;

                    int bottomY = (int)Size.Y - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)Size.X - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((double)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)Size.Y - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((double)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)Size.Y - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((double)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)Size.X - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((double)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    Global.SpriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        Global.SpriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        Global.SpriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    Global.SpriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    Global.SpriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    Global.SpriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    Global.SpriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        Global.SpriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        Global.SpriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    Global.SpriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = Content.Texture2D(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)Size.X - left.Width - right.Width;
                    int centerHeight = (int)Size.Y - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            Global.SpriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            Global.SpriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                }
            }
            #endregion
        }
        #endregion
    }
}
