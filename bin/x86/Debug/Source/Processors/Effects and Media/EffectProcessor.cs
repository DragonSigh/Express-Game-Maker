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
using System.Xml.Serialization;
using EGMGame.Extensions;

namespace EGMGame.Processors
{
    
    public class EffectProcessor : Drawable
    {
        // Stores the type of the effect
        public EffectType Type;
        // Stores the screen type
        public ScreenType ScreenType;
        // Timer for effects
        public int Time = 0;
        /// <summary>
        // 0 - Opaque 1 - Transperent
        /// Stores the fade/tint color.
        /// </summary>
        public Color LastColor;
        /// <summary>
        /// Stores the tint color.
        /// </summary>
        public Color TintColor = Color.White;
        /// <summary>
        /// Flash settings
        /// </summary>
        public Color FlashColor;
        public int FlashFrequency = 0;
        public byte TargetFlashAlpha = 0;
        public byte FlashIncrement = 0;
        /// <summary>
        /// Shake settings
        /// </summary>
        public int ShakePower = 0;
        public int ShakeFrequency = 0;
        public int ShakeDirection = 0; //0 - Left 1 - Right
        public int ShakeCounter = 0;
        /// <summary>
        /// Animation Settings
        /// </summary>
        public AnimationProcessor Animation;
        /// <summary>
        /// The layer the animation should appear on. (Map Only)
        /// </summary>
        public override int LayerIndex
        {
            get
            {
                if (Event != null)
                    return Event.LayerIndex;
                return LayerIndex;
            }
        }
        
        EventProcessor Event;

        /// <summary>
        /// Text Effect Settings
        /// </summary>
        public string Text;
        public FontData Font;
        public Vector2 TextPosition;
        public Vector2 TextTargetPosition;
        public Color TextStartColor;
        public Color TextEndColor;

        public EffectProcessor() { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        public EffectProcessor(EffectType _type, ScreenType _screenType, Color color, int p, Color _lastColor)
        {
            Type = _type;
            ScreenType = _screenType;
            // Tint
            TintColor = color;
            LastColor = _lastColor;
            Time = p;
            if (p == 0)
                Erase = true;
            else
                Global.Instance.IsLastTintGlobal = (_screenType == ScreenType.Global);
        }
        public EffectProcessor(EffectType _type, ScreenType _screenType, Color color, int frames, int freq)
        {
            Type = _type;
            ScreenType = _screenType;
            // Flash
            FlashColor = color;
            TargetFlashAlpha = FlashColor.A;
            FlashColor.A = 0;
            Time = frames;
            FlashFrequency = freq;
            FlashIncrement = 0;

        }
        public EffectProcessor(EffectType _type, ScreenType _screenType, int power, int time, int freq, bool shake)
        {
            Type = _type;
            ScreenType = _screenType;
            // Shake
            ShakePower = power;
            Time = time;
            ShakeFrequency = freq;
        }
        public EffectProcessor(EffectType _type, int _layerIndex, ScreenType _screenType, int animationID, int actionID, int directionIndex, int x, int y)
        {
            Type = _type;
            ScreenType = _screenType;
            Animation = new AnimationProcessor();
            Animation.Setup(animationID, actionID);
            Animation.Direction = directionIndex;
            Animation.Position = new Vector2(x, y);
            Animation.Start();
            layerIndex = _layerIndex;
            if (Animation.Action == null)
                Erase = true;
        }
        public EffectProcessor(EffectType _type, ScreenType _screenType, int animationID, int actionID, int angle, EventProcessor ev)
        {
            Type = _type;
            ScreenType = _screenType;
            Animation = new AnimationProcessor();
            Animation.Setup(animationID, actionID);
            Animation.ApplyAngleToDirection(angle);
            Animation.Start();
            Event = ev;
            if (Animation.Action == null)
                Erase = true;
        }
        public EffectProcessor(EffectType _type, ScreenType _screenType, FontData font, string text, Vector2 position, Vector2 targetPosition, Color startColor, Color endColor, int time)
        {
            Type = _type;
            ScreenType = _screenType;
            Font = font;
            Text = text;
            TextPosition = position;
            TextTargetPosition = targetPosition;
            TextStartColor = startColor;
            TextEndColor = endColor;
            Time = time;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            switch (Type)
            {
                case EffectType.Flash:
                    if (Time > 0)
                        Time--;
                    if (Time <= 0)
                        Erase = true;
                    break;
                case EffectType.Shake:
                    if (Time > 0)
                    {
                        Random rand = new Random();
                        if (ShakeDirection == 0)
                        {
                            ShakeCounter -= ShakeFrequency;
                            Global.Instance.ActiveCamera.OffsetXTo(-ShakeFrequency);
                            if (rand.Next(0, 100) > 30) // up
                                Global.Instance.ActiveCamera.OffsetYTo(-rand.Next(0, ShakeFrequency));
                            else
                                Global.Instance.ActiveCamera.OffsetYTo(rand.Next(0, ShakeFrequency));
                            if (ShakeCounter <= -ShakePower)
                                ShakeDirection = 1;

                        }
                        else
                        {
                            ShakeCounter += ShakeFrequency;
                            Global.Instance.ActiveCamera.OffsetXTo(ShakeFrequency);
                            if (rand.Next(0, 100) > 70) // up
                                Global.Instance.ActiveCamera.OffsetYTo(-rand.Next(0, ShakeFrequency));
                            else
                                Global.Instance.ActiveCamera.OffsetYTo(rand.Next(0, ShakeFrequency));
                            if (ShakeCounter >= ShakePower)
                                ShakeDirection = 0;
                        }
                        Time--;
                    }
                    if (Time <= 0)
                    {
                        Erase = true;
                        Global.Instance.ActiveCamera.Offset = new Vector2(0, 0);
                    }
                    break;
                case EffectType.Tint:
                    if (Time >= 1)
                    {
                        LastColor.A = (byte)Math.Min(255, ((int)LastColor.A * (Time - 1) + (int)TintColor.A) / Time);
                        LastColor.R = (byte)Math.Min(255, ((int)LastColor.R * (Time - 1) + (int)TintColor.R) / Time);
                        LastColor.G = (byte)Math.Min(255, ((int)LastColor.G * (Time - 1) + (int)TintColor.G) / Time);
                        LastColor.B = (byte)Math.Min(255, ((int)LastColor.B * (Time - 1) + (int)TintColor.B) / Time);

                        Time--;
                    }
                    if (TintColor == LastColor)
                        Erase = true;
                    break;
                case EffectType.Animation:
                    if (Event != null)
                        Animation.Position = Event.Position + new Vector2(1);
                    if (DrawOrder != Animation.Position.Y) DrawOrder = (int)Animation.Position.Y;
                    Animation.Update(gameTime);
                    if (!Animation.IsAnimating)
                        Erase = true;
                    break;
                case EffectType.Text:
                    if (Time >= 1)
                    {
                        // Update Tint
                        TextStartColor.A = (byte)Math.Min(255, ((int)TextStartColor.A * (Time - 1) + (int)TextEndColor.A) / Time);
                        TextStartColor.R = (byte)Math.Min(255, ((int)TextStartColor.R * (Time - 1) + (int)TextEndColor.R) / Time);
                        TextStartColor.G = (byte)Math.Min(255, ((int)TextStartColor.G * (Time - 1) + (int)TextEndColor.G) / Time);
                        TextStartColor.B = (byte)Math.Min(255, ((int)TextStartColor.B * (Time - 1) + (int)TextEndColor.B) / Time);
                        // Update Position
                        if (TextPosition.X < TextTargetPosition.X)
                            TextPosition.X = Math.Min(TextTargetPosition.X, (TextPosition.X * (Time - 1) + TextTargetPosition.X) / Time);
                        else if (TextPosition.X > TextTargetPosition.X)
                            TextPosition.X = Math.Max(TextTargetPosition.X, (TextPosition.X * (Time - 1) + TextTargetPosition.X) / Time);
                        if (TextPosition.Y < TextTargetPosition.Y)
                            TextPosition.Y = Math.Min(TextTargetPosition.Y, (TextPosition.Y * (Time - 1) + TextTargetPosition.Y) / Time);
                        else if (TextPosition.Y > TextTargetPosition.Y)
                            TextPosition.Y = Math.Max(TextTargetPosition.Y, (TextPosition.Y * (Time - 1) + TextTargetPosition.Y) / Time);

                        Time--;
                    }
                    if (TextPosition == TextTargetPosition)
                        Erase = true;
                    break;
            }
        }
        /// <summary>
        /// Draw the effect
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime)
        {
            switch (Type)
            {
                case EffectType.Flash:
                    if (Time > 0)
                    {
                        if (FlashIncrement == 0)
                        {  // Adjust alpha
                            FlashColor.A = (byte)Math.Min(FlashColor.A + (TargetFlashAlpha / FlashFrequency), TargetFlashAlpha);

                            if (FlashColor.A == TargetFlashAlpha)
                                FlashIncrement = 1;
                        }
                        else
                        {   // Adjust alpha
                            FlashColor.A = (byte)Math.Max(FlashColor.A - (TargetFlashAlpha / FlashFrequency), 0);

                            if (FlashColor.A == 0)
                                FlashIncrement = 0;
                        }
                        // Flash Screen
                        TintScreen(FlashColor);
                    }
                    break;
                case EffectType.Tint:
                    TintScreen(LastColor);
                    break;
                case EffectType.Animation:
                    Animation.Draw(gameTime);
                    break;
                case EffectType.Text:
                    Global.BeginMapSpriteBatch();
                    if (Font != null)
                    {
                        SpriteFont spriteFont = GetSpriteFont(Font.Styles[0].MaterialID);
                        Global.SpriteBatch.DrawString(spriteFont, Text, TextPosition, TextStartColor);
                    }
                    Global.SpriteBatch.End();
                    break;
            }
        }
        /// <summary>
        /// Helper draws a translucent black fullscreen sprite, used for fading
        /// screens in and out, and for darkening the background behind popups.
        /// </summary>
        public void TintScreen(Color color)
        {
            Viewport viewport = Global.Game.GraphicsDevice.Viewport;

            Global.SpriteBatch.Begin();

            Global.SpriteBatch.Draw(GraphicsHelper.Texture,
                             new Rectangle(0, 0, viewport.Width, viewport.Height),
                             color);
            Global.SpriteBatch.End();
        }
        /// <summary>
        /// Returns the sprite's effect
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private SpriteEffects GetSpriteEffect(AnimationSprite sprite)
        {
            if (sprite.HorizontalFlip)
                return SpriteEffects.FlipHorizontally;
            else if (sprite.VerticalFlip)
                return SpriteEffects.FlipVertically;
            else
                return SpriteEffects.None;
        }
        /// <summary>
        /// Sprite Font
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private SpriteFont GetSpriteFont(int materialId)
        {
            return Content.SpriteFont(materialId);
        }
        /// <summary>
        /// Adjust fade color with tint color
        /// </summary>
        /// <param name="FadeColor"></param>
        internal void Adjust(ref Color fadeColor)
        {
            fadeColor = TintColor;
        }
    }

    public enum EffectType
    {
        Tint,
        Flash,
        Shake,
        Animation,
        Text
    }

    public enum ScreenType
    {
        Global,
        Gameplay,
        Menu
    }
}
