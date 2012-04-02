//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using EGMGame.Components;
using System.Xml.Serialization;
namespace EGMGame.Processors
{
#if !SILVERLIGHT
    
    public class VideoProcessor
    {
        // Stores the video
        Video video;
        // Texture
        Texture2D videoTexture;
        // Stores the player
        VideoPlayer player = new VideoPlayer();
        // Material ID
        public int MaterialID;
        // Size Type
        VideoSizeType sizeType = VideoSizeType.Default;
        // Position
        public Vector2 position = new Vector2();
        // Size
        public Vector2 size = new Vector2();
        // State
        public MediaState CurrentState;
        /// <summary>
        /// Returns the player state
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public MediaState State
        {
            get 
            {
                if (player.State == MediaState.Stopped && player.IsLooped && !ignoreLoop)
                {
                    return MediaState.Playing;
                }

                return player.State; 
            }
        }
        public bool ignoreLoop = false;
        /// <summary>
        /// Get Material
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="loop"></param>
        /// <param name="sizeType"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void PlayVideo(int materialID, int x, int y, bool loop, int s, int width, int height)
        {
            video = Content.Video(materialID);
            MaterialID = materialID;
            if (video != null)
                player.Play(video);
            player.IsLooped = loop;
            sizeType = (VideoSizeType)s;
            position.X = x;
            position.Y = y;
            size.X = width;
            size.Y = height;
        }

        public void Clear()
        {
            videoTexture = null;
            video = null;
        }

        public void Pause()
        {
            if (video != null)
            {
                player.Pause();
            }
        }

        public void Resume()
        {
            if (video != null)
            {
                player.Resume();
            }
        }

        public void Play()
        {
            if (video != null)
            {
                if (player.State == MediaState.Paused)
                    Resume();
                else
                    player.Play(video);
            }
        }

        internal void Draw(GameTime gameTime)
        {
            if (video != null)
            {
                CurrentState = player.State;
                // Only call GetTexture if a video is playing or paused
                if (player.State != MediaState.Stopped)
                    videoTexture = player.GetTexture();
                else if (!player.IsLooped)
                    Clear();
                // Draw the video, if we have a texture to draw.
                if (videoTexture != null)
                {
                    Global.SpriteBatch.Begin();
                    Rectangle screen;
                    switch (sizeType)
                    {
                        case VideoSizeType.Default:
                            Global.SpriteBatch.Draw(videoTexture, position, Color.White);
                            break;
                        case VideoSizeType.Stretch:
                            // Drawing to the rectangle will stretch the 
                            // video to fill the screen
                            screen = new Rectangle((int)position.X,
                                (int)position.Y,
                                Global.Game.GraphicsDevice.Viewport.Width,
                                Global.Game.GraphicsDevice.Viewport.Height);
                            Global.SpriteBatch.Draw(videoTexture, screen, Color.White);
                            break;
                        case VideoSizeType.Custom:
                            // Drawing to the rectangle will stretch the 
                            // video to fill the screen
                            screen = new Rectangle((int)position.X,
                                (int)position.Y,
                                (int)size.X,
                                (int)size.Y);
                            Global.SpriteBatch.Draw(videoTexture, screen, Color.White);
                            break;
                    }
                    Global.SpriteBatch.End();
                }

            }
        }

        public void Load()
        {
            video = Content.Video(MaterialID);
            if (video != null && CurrentState == MediaState.Playing)
                player.Play(video);        
        }
    }
#endif
    enum VideoState
    {
        Playing,
        Paused,
        Cleared
    }

    enum VideoSizeType
    {
        Default,
        Stretch,
        Custom
    }
}
