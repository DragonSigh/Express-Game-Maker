//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EGMGame.Processors
{
    
    public class PictureProcessor
    {
        // Stores the screen type
        public ScreenType ScreenType;
        // Settings
        public Vector2 Position;
        public int Layer;
        public Vector2 Size;
        public bool SetSize;
        public int MaterialID;
        public Color TintColor = Color.White;
        public Vector2 Scale = new Vector2(1, 1);
        public Vector2 Origin;
        public float Rotation;
        // Timer for effects
        public int Time = 0;
        /// <summary>
        // 0 - Opaque 1 - Transperent
        /// Stores the fade/tint color.
        /// </summary>
        public Color LastColor = Color.White;
        /// <summary>
        /// Constructor
        /// </summary>
        public PictureProcessor() { }
        public PictureProcessor(int _materialID, bool set, int width, int height, int x, int y, ScreenType _screenType, int originType, int layer)
        {
            ScreenType = _screenType;
            MaterialID = _materialID;
            SetSize = set;
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            Origin = (originType == 0 ? Vector2.Zero : Size / 2);
            Layer = layer;
        }
        /// <summary>
        /// Edit picture's properties
        /// </summary>
        /// <param name="set"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Set(bool set, int width, int height, int x, int y)
        {
            SetSize = set;
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
        }
        /// <summary>
        /// Tint picture
        /// </summary>
        /// <param name="color"></param>
        /// <param name="frames"></param>
        public void Tint(Color color, int frames)
        {
            Global.Instance.TintingPicture = true;
            LastColor = TintColor;
            TintColor = color;
            Time = frames;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (Time >= 1)
            {
                LastColor.A = (byte)Math.Min(255, ((int)LastColor.A * (Time - 1) + (int)TintColor.A) / Time);
                LastColor.R = (byte)Math.Min(255, ((int)LastColor.R * (Time - 1) + (int)TintColor.R) / Time);
                LastColor.G = (byte)Math.Min(255, ((int)LastColor.G * (Time - 1) + (int)TintColor.G) / Time);
                LastColor.B = (byte)Math.Min(255, ((int)LastColor.B * (Time - 1) + (int)TintColor.B) / Time);

                Time--;
            }
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime)
        {
            if (SetSize)
            {
                Global.SpriteBatch.Draw(MaterialID, Position + Global.Instance.ActiveCamera.RealPosition,
                    new Rectangle(0, 0, (int)Size.X, (int)Size.Y),
                                 LastColor, Scale, Rotation, Origin);
            }
            else
            {
                Global.SpriteBatch.Draw(MaterialID, Position + Global.Instance.ActiveCamera.RealPosition,
                                 LastColor, Scale, Rotation, Origin);
            }
        }

        /// <summary>
        /// Center the picture
        /// </summary>
        internal void Center()
        {
            Texture2D tex = Content.Texture2D(MaterialID);

            if (tex != null)
            {
                Position.X = Global.Project.ScreenRatio.X / 2 - tex.Width / 2;
                Position.Y = Global.Project.ScreenRatio.Y / 2 - tex.Height / 2;
            }
        }
    }
}
