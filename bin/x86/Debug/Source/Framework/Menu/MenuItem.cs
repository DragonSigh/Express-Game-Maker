using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Extensions;
using EGMGame.Components;

namespace EGMGame.Framework
{
    public class MenuItem : Drawable
    {
        internal MenuPartProcessor Data;
        internal FontData Font;
        internal FontStyleData Style;
        internal Color Color = Color.White;

        #region Properties
        public Vector2 Position
        {
            get { return Data.Position; }
            set { Data.Position = value; }
        }

        public Vector2 Size
        {
            get { return Data.Size; }
            set { Data.Size = value; }
        }

        public int Padding
        {
            get { return Data.Padding; }
            set { Data.Padding = value; }
        }

        public bool Enabled
        {
            get { return Data.Enabled; }
            set { Data.Enabled = value; }
        }

        public bool Visible
        {
            get { return Data.Visible; }
            set { Data.Visible = value; }
        }
        #endregion

        #region Methods: Properties
        public virtual void SetSkin(int skinId)
        {
            Data.Data.SkinID = skinId;
        }

        public virtual void SetSkin(string skinName)
        {
            Data.Data.SkinID = GameData.Skins.GetData(skinName).ID;
        }
        #endregion

        #region Methods: Draw
        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="spriteBatch"></param>
        public void DrawText(string text, Vector2 position)
        {
            GraphicsHelper.DrawText(Font, Style, text, position, Color);
        }
        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="style"></param>
        /// <param name="spriteBatch"></param>
        public void DrawText(string text, Vector2 position, FontData font, FontStyleData style)
        {
            GraphicsHelper.DrawText(font, style, text, position, Color);
        }
        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="style"></param>
        /// <param name="color"></param>
        /// <param name="spriteBatch"></param>
        public void DrawText(string text, Vector2 position, FontData font, FontStyleData style, Color color)
        {
            GraphicsHelper.DrawText(font, style, text, position, color);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialName"></param>
        /// <param name="position"></param>
        public void DrawImage(string materialName, Vector2 position)
        {
            DrawImage(GameData.Materials.GetData(materialName).ID, position, Color.White);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialName"></param>
        /// <param name="rectangle"></param>
        public void DrawImage(string materialName, Rectangle rectangle)
        {
            DrawImage(GameData.Materials.GetData(materialName).ID, rectangle, Color.White);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialName"></param>
        /// <param name="rectangle"></param>
        /// <param name="color"></param>
        public void DrawImage(string materialName, Rectangle rectangle, Color color)
        {
            DrawImage(GameData.Materials.GetData(materialName).ID, rectangle, color);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialName"></param>
        /// <param name="rectangle"></param>
        /// <param name="color"></param>
        /// <param name="rotation"></param>
        public void DrawImage(string materialName, Rectangle rectangle, Color color, float rotation)
        {
            DrawImage(GameData.Materials.GetData(materialName).ID, rectangle, color, rotation);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialName"></param>
        /// <param name="rectangle"></param>
        /// <param name="color"></param>
        /// <param name="rotation"></param>
        /// <param name="origin"></param>
        public void DrawImage(string materialName, Rectangle rectangle, Color color, float rotation, Vector2 origin)
        {
            DrawImage(GameData.Materials.GetData(materialName).ID, rectangle, color, rotation, origin);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialName"></param>
        /// <param name="position"></param>
        /// <param name="sourceRect"></param>
        /// <param name="color"></param>
        /// <param name="scale"></param>
        public void DrawImage(string materialName, Vector2 position, Rectangle sourceRect, Color color, Vector2 scale)
        {
            DrawImage(GameData.Materials.GetData(materialName).ID, position, sourceRect, color, scale);
        }
        /// <summary>
        /// Draw image 
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        public void DrawImage(int materialId, Vector2 position, Color color)
        {
            Global.SpriteBatch.Draw(materialId, position, color);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="rectangle"></param>
        /// <param name="color"></param>
        public void DrawImage(int materialId, Rectangle rectangle, Color color)
        {
            Global.SpriteBatch.Draw(materialId, rectangle, color);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="rectangle"></param>
        /// <param name="color"></param>
        /// <param name="rotation"></param>
        public void DrawImage(int materialId, Rectangle rectangle, Color color, float rotation)
        {
            Global.SpriteBatch.Draw(materialId, rectangle, new Rectangle(0, 0, rectangle.Width, rectangle.Height), color, rotation);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="rectangle"></param>
        /// <param name="color"></param>
        /// <param name="rotation"></param>
        /// <param name="origin"></param>
        public void DrawImage(int materialId, Rectangle rectangle, Color color, float rotation, Vector2 origin)
        {
            Global.SpriteBatch.Draw(materialId, rectangle, new Rectangle(0, 0, rectangle.Width, rectangle.Height), color, rotation, origin);
        }
        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="position"></param>
        /// <param name="sourceRect"></param>
        /// <param name="color"></param>
        /// <param name="scale"></param>
        public void DrawImage(int materialId, Vector2 position, Rectangle sourceRect, Color color, Vector2 scale)
        {
            Global.SpriteBatch.Draw(materialId, position, sourceRect, color, scale);
        }
        /// <summary>
        /// Fill a solid rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        public void Fill(Rectangle rect, Color color)
        {
            GraphicsHelper.FillRectangle(GraphicsHelper.Texture, rect, color);
        }
        /// <summary>
        /// Fill a gradient rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="topColor"></param>
        /// <param name="bottomColor"></param>
        public void FillGradient(Rectangle rect, Color topColor, Color bottomColor)
        {
            GraphicsHelper.FillGradient(rect, topColor, bottomColor);
        }
        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        public void DrawRectangle(Rectangle rect, Color color)
        {
            GraphicsHelper.DrawRectangle(GraphicsHelper.Texture, rect, color);
        }
        /// <summary>
        /// Draw vertices
        /// </summary>
        public void DrawVertices(List<Vector2> vertices, Color color, int thickness)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (i + 1 == vertices.Count)
                    GraphicsHelper.DrawLine(vertices[i], vertices[0], color, thickness, GraphicsHelper.Texture);
                else
                    GraphicsHelper.DrawLine(vertices[i], vertices[i + 1], color, thickness, GraphicsHelper.Texture);
            }
        }
        #endregion

        #region Create Methods
        #region Window
        public static MenuItem CreateWindow(string skinName, Vector2 position, Vector2 size)
        {
            return CreateWindow(GameData.Skins.GetData(skinName).ID, position, size);
        }

        public static MenuItem CreateWindow(int id, Vector2 position, Vector2 size)
        {
            MenuItem item = new MenuItem();
            item.Data = new MenuPartProcessor(new MenuWindow() { SkinID = id, Position = position, Size = size }, null, null);
            return item;
        }
        #endregion

        #region Button
        public static Button CreateButton(int skinId, Vector2 position, Vector2 size)
        {
            Button item = new Button();
            item.Data = new MenuPartProcessor(new MenuButton() { SkinID = skinId, Position = position, Size = size }, null, null);
            return item;
        }
        #endregion

        #region Option
        public static Option CreateList(string skinName, Vector2 position, Vector2 size, FontData font, FontStyleData style, List<string> options)
        {
            return CreateList(GameData.Skins.GetData(skinName).ID, position, size, font, style, options);
        }

        public static Option CreateList(string skinName, Vector2 position, Vector2 size, FontData font, FontStyleData style, Color color, List<string> options)
        {
            return CreateList(GameData.Skins.GetData(skinName).ID, position, size, font, style, color, options);
        }

        public static Option CreateList(string skinName, Vector2 position, Vector2 size, FontData font, FontStyleData style, Color color, List<string> options, int columns)
        {
            return CreateList(GameData.Skins.GetData(skinName).ID, position, size, font, style, color, options, columns);
        }

        public static Option CreateList(int skinId, Vector2 position, Vector2 size, FontData font, FontStyleData style, List<string> options)
        {
            Option item = new Option();
            item.Data = new MenuPartProcessor(new ListStatic() { SkinID = skinId, Position = position, Size = size }, null, null);
            item.Font = font;
            item.Style = style;
            item.Options = options;
            return item;
        }

        public static Option CreateList(int skinId, Vector2 position, Vector2 size, FontData font, FontStyleData style, Color color, List<string> options)
        {
            Option item = new Option();
            item.Data = new MenuPartProcessor(new ListStatic() { SkinID = skinId, Position = position, Size = size }, null, null);
            item.Font = font;
            item.Style = style;
            item.Color = color;
            item.Options = options;

            return item;
        }

        public static Option CreateList(int skinId, Vector2 position, Vector2 size, FontData font, FontStyleData style, Color color, List<string> options, int columns)
        {
            Option item = new Option();
            item.Data = new MenuPartProcessor(new ListStatic() { SkinID = skinId, Position = position, Size = size }, null, null);
            item.Font = font;
            item.Style = style;
            item.Color = color;
            ((ListStatic)item.Data.Data).Columns = columns;
            item.Options = options;

            return item;
        }
        #endregion

        #region Other: Textbox, Animation, Dynamic Bar
        public static Textbox CreateTextbox(string skinName, Vector2 position, Vector2 size, FontData font, FontStyleData style, Color color, string doNotAllow, bool allowSpaces, bool allowSpecial, bool passwordChars)
        {
            return CreateTextbox(GameData.Skins.GetData(skinName).ID, position, size, font, style, color, doNotAllow, allowSpaces, allowSpecial, passwordChars);
        }

        public static Textbox CreateTextbox(int skinId, Vector2 position, Vector2 size, FontData font, FontStyleData style, Color color, string doNotAllow, bool allowSpaces, bool allowSpecial, bool passwordChars)
        {
            Textbox item = new Textbox();
            item.Data = new MenuPartProcessor(new TextBoxPart() { SkinID = skinId, Position = position, Size = size, Font = font.ID, Style = style.ID, TextColor = color, AllowSpaces = allowSpaces, AllowSpecialChar = allowSpaces, DoNotAllow = doNotAllow, PasswordChars = passwordChars, String = -1 }, null, null);
            item.Font = font;
            item.Style = style;
            item.Color = color;
            return item;
        }

        public static Animation CreateAnimation(string materialName, int rows, int columns, int frames, Vector2 position)
        {
            return CreateAnimation(GameData.Skins.GetData(materialName).ID, rows, columns, frames, position);
        }

        public static Animation CreateAnimation(int materialID, int rows, int columns, int frames, Vector2 position)
        {
            Animation item = new Animation(materialID);
            item.Setup(rows, columns, frames, 0, position);
            return item;
        }

        public static DynamicBar CreateDynamicBar(string skinName, int max, int min, Vector2 position, Vector2 size)
        {
            return CreateDynamicBar(GameData.Skins.GetData(skinName).ID, max, min, position, size);
        }

        public static DynamicBar CreateDynamicBar(int skinId, int max, int min, Vector2 position, Vector2 size)
        {
            DynamicBar item = new DynamicBar() { Skin = skinId, Max = max, Min = min, Position = position, Value = max, Size = size };
            return item;
        }
        #endregion

        #endregion

        public override void Update(GameTime gameTime)
        {
            if (Data != null) Data.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (Data != null) Data.Draw(gameTime);
        }
    }
}
