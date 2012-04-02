//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
namespace EGMGame.Processors
{
    /// <summary>
    /// Manages all the audio.
    /// Use the Global.AudioManager to access this class.
    /// </summary>
    
    public class AudioManager
    {
        public bool IsActive = true;
        /// <summary>
        /// Stores the audios that we create.
        /// </summary>
        public Dictionary<int, AudioProcessor> audios = new Dictionary<int, AudioProcessor>();
        /// <summary>
        /// Stores the 3d audios that we create.
        /// </summary>
        public Dictionary<int, AudioProcessor3D> audios3d = new Dictionary<int, AudioProcessor3D>();
        /// <summary>
        /// Stores the playlists
        /// </summary>
        public Dictionary<int, PlayList> playlists = new Dictionary<int, PlayList>();
        /// <summary>
        /// Stores the audios that we create.
        /// </summary>
        public List<AudioProcessor> Effects = new List<AudioProcessor>();
        /// <summary>
        /// Update the audio manager.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Update Audios
            foreach (KeyValuePair<int, AudioProcessor> audio in audios)
            {
                audio.Value.Update(gameTime);
            }
            // Update Audios
            foreach (KeyValuePair<int, AudioProcessor3D> audio in audios3d)
            {
                audio.Value.Update(gameTime);
            }
            // Update Playlists
            foreach (KeyValuePair<int, PlayList> playList in playlists)
            {
                playList.Value.Update(gameTime);
            }
            // Update Effects
            int count = Effects.Count;
            for (int i = 0; i < count; i++)
            {
                if (Effects[i].State == SoundState.Stopped)
                {
                    Effects[i].Remove();
                    Effects.RemoveAt(i); i--; count--;
                }
            }
        }
        /// <summary>
        /// Update Inactivity
        /// </summary>
        /// <param name="p"></param>
        public void UpdateInactivity(bool active)
        {
            if (IsActive != active)
            {
                IsActive = active;
                // Update Audios
                foreach (KeyValuePair<int, AudioProcessor> audio in audios)
                {
                    audio.Value.Active = active;
                }
                // Update Audios
                foreach (KeyValuePair<int, AudioProcessor3D> audio in audios3d)
                {
                    audio.Value.Active = active;
                }
                // Update Playlists
                foreach (KeyValuePair<int, PlayList> playList in playlists)
                {
                    playList.Value.Active = active;
                }
                // Update Effects
                foreach (AudioProcessor audio in Effects)
                {
                    audio.Active = active;
                }
            }
        }
        /// <summary>
        /// Play audio from given channel.
        /// </summary>
        /// <param name="channel"></param>
        public void Play(int channel)
        {
            AudioProcessor audio;
            if (audios.TryGetValue(channel, out audio))
            {
                audio.Play();
            }
        }
        /// <summary>
        /// Play audio from given data id.
        /// </summary>
        /// <param name="id"></param>
        public void Play(int id, int channel)
        {
            Play(GameData.Audios.GetData(id), channel);
        }
        /// <summary>
        /// Play audio from given data.
        /// </summary>
        /// <param name="data"></param>
        public void Play(AudioData data, int channel)
        {
            if (audios.ContainsKey(channel))
            {
                audios[channel].Remove();
                audios.Remove(channel);
            }
            audios.Add(channel, new AudioProcessor(data, true));
        }
        /// <summary>
        /// Play audio at the given channel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="channel"></param>
        /// <param name="settings"></param>
        public void Play(int id, int channel, AudioSettings settings)
        {
            AudioData temp = new AudioData();
            AudioData real = GameData.Audios.GetData(id);
            temp.ID = real.ID;
            temp.Name = real.Name;
            temp.MaterialId = real.MaterialId;
            temp.Category = real.Category;
            temp.FadeAfter = settings.FadeAfter;
            temp.FadeIn = settings.FadeIn;
            temp.FadeOut = settings.FadeOut;
            temp.Loop = settings.Loop;
            temp.Pan = settings.Pan;
            temp.Pitch = settings.Pitch;
            temp.Volume = settings.Volume;
            Play(temp, channel);
        }
        /// <summary>
        /// Resumes audio from given channel.
        /// </summary>
        /// <param name="data"></param>
        public void Resume(int channel)
        {
            AudioProcessor processor;
            // Resume
            if (audios.TryGetValue(channel, out processor))
            {
                processor.Resume();
            }
        }
        /// <summary>
        /// Pause the audio from given channel.
        /// </summary>
        /// <param name="id"></param>
        public void Pause(int channel)
        {
            AudioProcessor processor;
            // Pause
            if (audios.TryGetValue(channel, out processor))
            {
                processor.Pause();
            }
        }
        /// <summary>
        /// Stop audio from the given channel.
        /// </summary>
        /// <param name="id"></param>
        public void Stop(int channel)
        {
            AudioProcessor processor;
            // Stop
            if (audios.TryGetValue(channel, out processor))
            {
                processor.Stop();
            }
        }
        /// <summary>
        /// Fadeout Audio
        /// </summary>
        /// <param name="p"></param>
        public void FadeOut(int channel)
        {
            AudioProcessor processor;
            // Stop
            if (audios.TryGetValue(channel, out processor))
            {
                processor.FadeOut();
            }
        }
        /// <summary>
        /// Create Playlist
        /// </summary>
        /// <param name="list"></param>
        /// <param name="p"></param>
        public void CreatePlaylist(List<int> list, int id, bool loop)
        {
            PlayList playList;
            if (playlists.TryGetValue(id, out playList))
            {
                playList.Stop();
                playlists.Remove(id);
            }
            // Create Playlist
            playlists.Add(id, new PlayList(list, loop));
        }
        /// <summary>
        /// Play playlist
        /// </summary>
        /// <param name="id"></param>
        public void PlayPlaylist(int id)
        {
            PlayList playList;
            if (playlists.TryGetValue(id, out playList))
            {
                playList.Play();
            }
        }
        /// <summary>
        /// Pause playlist
        /// </summary>
        /// <param name="id"></param>
        public void PausePlaylist(int id)
        {
            PlayList playList;
            if (playlists.TryGetValue(id, out playList))
            {
                playList.Pause();
            }
        }
        /// <summary>
        /// Resume playlist
        /// </summary>
        /// <param name="id"></param>
        public void ResumePlaylist(int id)
        {
            PlayList playList;
            if (playlists.TryGetValue(id, out playList))
            {
                playList.Resume();
            }
        }
        /// <summary>
        /// Stop playlist
        /// </summary>
        /// <param name="id"></param>
        public void StopPlaylist(int id)
        {
            PlayList playList;
            if (playlists.TryGetValue(id, out playList))
            {
                playList.Stop();
            }
        }
        /// <summary>
        /// Fadeout Playlist
        /// </summary>
        /// <param name="p"></param>
        public void FadeOutPlayList(int id)
        {
            PlayList playList;
            if (playlists.TryGetValue(id, out playList))
            {
                playList.FadeOut();
            }
        }
        /// <summary>
        /// Play 3D audio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="channel"></param>
        /// <param name="settings"></param>
        /// <param name="emitter"></param>
        /// <param name="listener></param>
        public void Play3D(int id, int channel, AudioSettings settings, int emitter, int listener)
        {
            AudioData temp = new AudioData();
            AudioData real = GameData.Audios.GetData(id);
            temp.ID = real.ID;
            temp.Name = real.Name;
            temp.MaterialId = real.MaterialId;
            temp.Category = real.Category;
            temp.FadeAfter = settings.FadeAfter;
            temp.FadeIn = settings.FadeIn;
            temp.FadeOut = settings.FadeOut;
            temp.Loop = settings.Loop;
            temp.Pan = settings.Pan;
            temp.Pitch = settings.Pitch;
            temp.Volume = settings.Volume;
            Play3D(temp, channel, emitter, listener);
        }
        /// <summary>
        /// Play 3d audio from given data.
        /// </summary>
        /// <param name="data"></param>
        public void Play3D(AudioData data, int channel, int emitter, int listener)
        {
            if (audios3d.ContainsKey(channel))
            {
                audios3d[channel].Remove();
                audios3d.Remove(channel);
            }
            audios3d.Add(channel, new AudioProcessor3D(data, true, emitter, listener));
        }
        /// <summary>
        /// Play 3d audio in given channel
        /// </summary>
        /// <param name="p"></param>
        public void Play3D(int channel)
        {
            AudioProcessor3D audio;
            if (audios3d.TryGetValue(channel, out audio))
            {
                audio.Play();
            }
        }
        /// <summary>
        /// Resumes audio from given channel.
        /// </summary>
        /// <param name="data"></param>
        public void Resume3D(int channel)
        {
            AudioProcessor3D processor;
            // Resume
            if (audios3d.TryGetValue(channel, out processor))
            {
                processor.Resume();
            }
        }
        /// <summary>
        /// Pause the audio from given channel.
        /// </summary>
        /// <param name="id"></param>
        public void Pause3D(int channel)
        {
            AudioProcessor3D processor;
            // Pause
            if (audios3d.TryGetValue(channel, out processor))
            {
                processor.Pause();
            }
        }
        /// <summary>
        /// Stop audio from the given channel.
        /// </summary>
        /// <param name="id"></param>
        public void Stop3D(int channel)
        {
            AudioProcessor3D processor;
            // Stop
            if (audios3d.TryGetValue(channel, out processor))
            {
                processor.Stop();
            }
        }
        public bool Contains(int id, int channel)
        {
            AudioProcessor processor;
            // Stop
            if (audios.TryGetValue(channel, out processor))
            {
                return (processor.AudioData.ID == id);
            }
            return false;
        }
        /// <summary>
        /// Load Audip Processor
        /// </summary>
        public void Load()
        {
            // Update Audios
            foreach (KeyValuePair<int, AudioProcessor> audio in audios)
            {
                audio.Value.Load();
            }
            // Update Audios
            foreach (KeyValuePair<int, AudioProcessor3D> audio in audios3d)
            {
                audio.Value.Load();
            }
            // Update Playlists
            foreach (KeyValuePair<int, PlayList> playList in playlists)
            {
                playList.Value.Load();
            }
        }
        /// <summary>
        /// Stop Audio
        /// </summary>
        public void Stop()
        {
            // Update Audios
            foreach (KeyValuePair<int, AudioProcessor> audio in audios)
            {
                audio.Value.Stop();
            }
            // Update Audios
            foreach (KeyValuePair<int, AudioProcessor3D> audio in audios3d)
            {
                audio.Value.Stop();
            }
            // Update Playlists
            foreach (KeyValuePair<int, PlayList> playList in playlists)
            {
                playList.Value.Stop();
            }
        }
    }
}
