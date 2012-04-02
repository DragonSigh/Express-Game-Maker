using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Extensions;

namespace EGMGame.Framework
{
    /// <summary>
    /// Use this class to create custom sprite animations.
    /// TODO: THIS CLASS IS INCOMPLETE!
    /// </summary>
    public class Animation : Drawable
    {
        #region Fields: Settings
        public MaterialData Material;
        public int Rows = 4, Columns = 4, Frames = 8;
        public int SelectedDirection;
        public int FrameCounter, Index;
        public Vector2 Position;
        public Vector2 Scale, Origin;
        public Color Tint;
        public float Rotation;
        public SpriteEffects SpriteEffect = SpriteEffects.None;
        public AnimationDirection DirectionType = AnimationDirection.LeftToRight;
        Rectangle SourceRect = new Rectangle();
        #endregion

        #region Constructors
        /// <summary>
        /// Create an animation.
        /// </summary>
        /// <param name="materialName">The name of the material that will be used.</param>
        public Animation(string materialName)
        {
            Material = GameData.Materials.GetData(materialName);
        }
        /// <summary>
        /// Create an animation.
        /// </summary>
        /// <param name="materialID">The id of the material that will be used.</param>
        public Animation(int materialID)
        {
            Material = GameData.Materials.GetData(materialID);
        }
        /// <summary>
        /// Create an animation.
        /// </summary>
        /// <param name="material">The material that will be used.</param>
        public Animation(MaterialData material)
        {
            Material = material;
        }
        /// <summary>
        /// Setup the animation
        /// </summary>
        /// <param name="rows">Number of rows the sprite has.</param>
        /// <param name="columns">Number of columns the sprite has.</param>
        /// <param name="frames">The frames per second each frame is displayed.</param>
        public void Setup(int rows, int columns, int frames)
        {
            Rows = rows;
            Columns = columns;
            Frames = frames;
            Texture2D tex = Content.Texture2D(Material);
            SourceRect.Width = tex.Width / Columns;
            SourceRect.Height = tex.Height / Rows;
        }
        /// <summary>
        /// Setup the animation
        /// </summary>
        /// <param name="rows">Number of rows the sprite has.</param>
        /// <param name="columns">Number of columns the sprite has.</param>
        /// <param name="frames">The frames per second each frame is displayed.</param>
        /// <param name="layerIndex">The layer this animation should be showed on.</param>
        /// <param name="position">The position of this animation.</param>
        public void Setup(int rows, int columns, int frames, int layerIndex, Vector2 position)
        {
            Rows = rows;
            Columns = columns;
            Frames = frames;
            LayerIndex = layerIndex;
            Position = position;
            Texture2D tex = Content.Texture2D(Material);
            SourceRect.Width = tex.Width / Columns;
            SourceRect.Height = tex.Height / Rows;
        }
        #endregion

        /// <summary>
        /// Update Animation
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // Increase Frame Counter
            FrameCounter++;

            if (FrameCounter >= Frames)
            {
                FrameCounter = 0;
                Index++;
            }

            switch (DirectionType)
            {
                case AnimationDirection.LeftToRight:
                    if (Index >= Rows) Index = 0;
                    SourceRect.X = SourceRect.Width * Index;
                    SourceRect.Y = SourceRect.Height * SelectedDirection;
                    break;
                case AnimationDirection.TopToBottom:
                    if (Index >= Columns) Index = 0;
                    SourceRect.Y = SourceRect.Height * Index;
                    SourceRect.X = SourceRect.Width * SelectedDirection;
                    break;
            }
        }

        /// <summary>
        /// Draw Animation
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsHelper.LastTexture = Content.Texture2D(Material);
            Global.SpriteBatch.Draw(GraphicsHelper.LastTexture, Position, SourceRect, Tint, Rotation, Origin, Scale, SpriteEffect, 0);
        }
    }

    public enum AnimationDirection
    {
        LeftToRight,
        TopToBottom
    }
}
