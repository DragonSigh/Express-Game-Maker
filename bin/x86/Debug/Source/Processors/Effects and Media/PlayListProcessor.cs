//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
namespace EGMGame.Library
{
    /// <summary>
    /// Playlist
    /// Contains a list of audios to play.
    /// </summary>
    public class PlayList
    {
        /// <summary>
        /// Audios
        /// </summary>
        public List<AudioProcessor> audios = new List<AudioProcessor>();
        public SoundState State = SoundState.Playing;
        public int index = 0;
        public bool loop = false;


        public bool Active
        {
            set
            {
                if (index > -1 && index < audios.Count)
                    audios[index].Active = value;
            }
        }
        public PlayList() { }
        /// <summary>
        /// Create playlist from given ids.
        /// </summary>
        /// <param name="ids"></param>
        public PlayList(List<int> ids, bool _loop)
        {
            AudioData audio;
            for (int i = 0; i < ids.Count; i++)
            {
                if (GameData.Audios.TryGetValue(ids[i], out audio))
                {
                    audios.Add(new AudioProcessor(audio));
                }
            }
            loop = _loop;
        }
        /// <summary>
        /// Update the audio manager.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (audios[index].State == SoundState.Stopped && State != SoundState.Stopped)
            {
                Stop();
                index++;
                Play();
            }
        }
        /// <summary>
        /// Play playlist.
        /// </summary>
        /// <param name="data"></param>
        public void Play()
        {
            if (index > -1 && index < audios.Count)
            {
                audios[index].Play();
            }
            else if (index >= audios.Count && loop)
            {
                index = 0;
                if (index > -1 && index < audios.Count)
                {
                    audios[index].Play();
                }
            }
            State = SoundState.Playing;
        }
        /// <summary>
        /// Resume playlist.
        /// </summary>
        /// <param name="data"></param>
        public void Resume()
        {
            if (index > -1 && index < audios.Count)
            {
                audios[index].Resume();
            }
            State = SoundState.Playing;
        }
        /// <summary>
        /// Pause playlist.
        /// </summary>
        /// <param name="id"></param>
        public void Pause()
        {
            if (index > -1 && index < audios.Count)
            {
                audios[index].Pause();
            }
            State = SoundState.Paused;
        }
        /// <summary>
        /// Stop playlist.
        /// </summary>
        /// <param name="id"></param>
        public void Stop()
        {
            if (index > -1 && index < audios.Count)
            {
                audios[index].Stop();
            }
            State = SoundState.Stopped;
        }
        /// <summary>
        /// Fade out playlist.
        /// </summary>
        internal void FadeOut()
        {
            if (index > -1 && index < audios.Count)
            {
                audios[index].FadeOut();
            }
        }
        /// <summary>
        /// Load audio
        /// </summary>
        internal void Load()
        {
            for (int i = 0; i < audios.Count; i++)
                audios[i].Load();
        }
    }
}
