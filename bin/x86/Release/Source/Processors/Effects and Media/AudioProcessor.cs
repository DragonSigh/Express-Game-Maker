//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using FarseerPhysics;

namespace EGMGame.Processors
{


    public class AudioProcessor
    {
        #region Fields
        [XmlIgnoreAttribute]
        public SoundEffect soundEffect;

        [XmlIgnoreAttribute]
        public SoundEffectInstance instance;

        public AudioData AudioData;
        public bool fadeIn;
        public long TimeLast;
        public long TimeNow;
        public long TimeElapsed = 0;
        public double tickTime = 0;
        public bool resetTimer = true;
        public SoundState currentState = SoundState.Playing;
        public SoundState loadState = SoundState.Playing;
        #endregion

        public bool Active
        {
            set
            {
                if (value)
                {
                    if (currentState == SoundState.Playing)
                        Resume();
                }
                else
                {
                    if (currentState == SoundState.Playing)
                        if (!IsDisposed && instance.State == SoundState.Playing)
                            instance.Pause();
                }
            }
        }

        public AudioProcessor() { }
        /// <summary>
        /// Initializes the audio processor
        /// </summary>
        /// <param name="data"></param>
        public AudioProcessor(AudioData data)
        {
            Set(data);
        }

        /// <summary>
        /// Initializes the audio processor and plays if true
        /// </summary>
        /// <param name="data"></param>
        public AudioProcessor(AudioData data, bool play)
        {
            Set(data);
            if (play) Play();
        }
        /// <summary>
        /// Sets the sound effect from the given data.
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="data"></param>
        public void Set(AudioData data)
        {
            Set(Content.SoundEffect(data.MaterialId), data);
        }
        /// <summary>
        /// Sets the sound effect from the given data and soundeffect.
        /// </summary>
        /// <param name="soundEffect"></param>
        /// <param name="data"></param>
        public void Set(SoundEffect se, AudioData data)
        {
            Dispose();
            // Set Sound
            soundEffect = se;
            AudioData = data;
            if (soundEffect != null)
                instance = GetInstance();
            if (!IsDisposed)
            {
                instance.Volume = data.Volume / 100f;
                instance.Pitch = data.Pitch / 100f;
                instance.Pan = data.Pan / 100f;
            }
        }
        /// <summary>
        /// Get Sound Effect Instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private SoundEffectInstance GetInstance()
        {
            Queue<SoundEffectInstance> cache;
            if (Global.SoundEffectInstaces.TryGetValue(AudioData.ID, out cache))
            {
                if (cache.Count > 0) return instance = cache.Dequeue();
                // If Cache is 0
                instance = soundEffect.CreateInstance();
                IsLooped = AudioData.Loop;
                return instance;
            }
            Global.SoundEffectInstaces.Add(AudioData.ID, new Queue<SoundEffectInstance>());
            instance = soundEffect.CreateInstance();
            IsLooped = AudioData.Loop;
            return instance;
        }
        /// <summary>
        /// Play audio.
        /// </summary>
        public void Play()
        {
            if (!IsDisposed)
            {
                Stop(true);
                instance.Volume = AudioData.Volume / 100f;
                instance.Pitch = AudioData.Pitch / 100f;
                instance.Pan = AudioData.Pan / 100f;
                if (AudioData.FadeIn == 0)
                    instance.Play();
                else
                {
                    instance.Volume = 0f;
                    instance.Play();
                    fadeIn = true;
                }
                currentState = SoundState.Playing;
            }
        }
        /// <summary>
        /// Pause audio
        /// </summary>
        public void Pause()
        {
            if (!IsDisposed && instance.State == SoundState.Playing)
            {
                instance.Pause();
                currentState = SoundState.Paused;
            }
        }
        /// <summary>
        /// Resume audio
        /// </summary>
        public void Resume()
        {
            if (!IsDisposed && instance.State == SoundState.Paused)
            {
                instance.Resume();
                currentState = SoundState.Playing;
            }
        }
        /// <summary>
        /// Stop audio
        /// </summary>
        public void Stop()
        {
            if (!IsDisposed && instance.State == SoundState.Playing)
            {
                Stop(true);
                currentState = SoundState.Stopped;
            }
        }
        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="p"></param>
        private void Stop(bool p)
        {
#if SILVERLIGHT
            instance.Stop();
#else
            instance.Stop(p);
#endif
        }
        /// <summary>
        /// Fade in
        /// </summary>
        /// <param name="fade"></param>
        private void FadeIn(float fade)
        {
            if (!IsDisposed)
            {
                fadeIn = true;
                float max = AudioData.Volume / 100f;
                float inc = max / fade;
                if (instance.Volume + inc >= 0f && instance.Volume + inc <= 1f)
                    instance.Volume += inc;
                else
                {
                    instance.Volume = AudioData.Volume / 100f;
                    fadeIn = false;
                }
                if (instance.Volume >= AudioData.Volume)
                {
                    instance.Volume = AudioData.Volume / 100f;
                    fadeIn = false;
                }
            }
        }
        /// <summary>
        /// Fade out
        /// </summary>
        /// <param name="fadeOut"></param>
        private void FadeOut(float fadeOut)
        {
            float max = AudioData.Volume / 100f;
            float inc = max / fadeOut;
            if (instance.Volume - inc >= 0f && instance.Volume - inc <= 1f)
                instance.Volume -= inc;
            else
            {
                instance.Volume = 0f;
            }
            if (instance.Volume == 0 && AudioData.Volume > 0 && instance.State == SoundState.Playing)
                Stop(true);
        }
        /// <summary>
        /// Update audio
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (!IsDisposed && Global.Game.IsActive)
            {
                loadState = instance.State;
                // Reset Timer for new audio
                if (resetTimer)
                {
                    TimeLast = (long)gameTime.TotalGameTime.TotalMilliseconds;
                    resetTimer = false;
                }
                // Calculate Time
                TimeNow = (long)gameTime.TotalGameTime.TotalMilliseconds;
                long TimeDelta = TimeNow - TimeLast;

                TimeElapsed += TimeDelta;

                TimeLast = TimeNow;

                if (TimeElapsed >= 1)
                {
                    tickTime += TimeElapsed;
                    if (!IsDisposed && instance.State == SoundState.Playing)
                    {
                        // Because the update method can be called in variable milliseconds
                        // the effects are applied in a loop of milliseconds passed.
                        for (int i = 0; i <= TimeElapsed; i++)
                        {
                            if (fadeIn)
                                FadeIn(AudioData.FadeIn);

                            if (AudioData.FadeAfter)
                            {
                                if (AudioData.FadeOut > 0 && tickTime >= AudioData.FadeOut && instance.State == SoundState.Playing)
                                    FadeOut(AudioData.FadeOut);

                            }
                            else
                            {
                                if (AudioData.FadeOut > 0 && tickTime >= (float)Duration.TotalMilliseconds - AudioData.FadeOut && instance.State == SoundState.Playing)
                                    FadeOut(AudioData.FadeOut);

                            }
                        }
                        if (tickTime >= Duration.TotalMilliseconds)
                            tickTime = 0;
                    }
                    else
                    {
                        tickTime = 0;
                    }
                    TimeElapsed = 0;
                }
            }
        }
        /// <summary>
        /// Returns the state of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public SoundState State
        {
            get { return instance.State; }
        }
        /// <summary>
        /// Gets our sets the volume of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public float Volume
        {
            get
            {
                if (IsDisposed) return 0;
                return instance.Volume;
            }

            set
            {
                if (!IsDisposed)
                {
                    instance.Volume = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the pitch of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public float Pitch
        {
            get
            {
                if (IsDisposed) return 0;
                return instance.Pitch;
            }

            set
            {
                if (!IsDisposed)
                {
                    instance.Pitch = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the pan of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public float Pan
        {
            get
            {
                if (IsDisposed) return 0;
                return instance.Pan;
            }

            set
            {
                if (!IsDisposed)
                {
                    instance.Pan = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the duration of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public TimeSpan Duration
        {
            get
            {
                if (IsDisposed) return new TimeSpan();
                return soundEffect.Duration;
            }
        }
        /// <summary>
        /// Gets or sets loop
        /// </summary>
        /// 
        [XmlIgnore, DoNotSerialize]
        public bool IsLooped
        {
            get { return instance.IsLooped; }
            set
            {
#if SILVERLIGHT
                instance.Loop = value;
#else
                instance.IsLooped = value;
#endif
            }
        }
        /// <summary>
        /// Gets a value indicating whether the audio is disposed
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public bool IsDisposed
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    return true;
                if (AudioData == null)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// Releases resources used by the audio
        /// </summary>
        public void Dispose()
        {
            if (!IsDisposed)
            {
                soundEffect = null;
                instance = null;
                AudioData = null;
            }
        }

        internal void FadeOut()
        {
            if (AudioData.FadeOut > 0)
                FadeOut(AudioData.FadeOut);
        }

        /// <summary>
        /// Load audio
        /// </summary>
        internal void Load()
        {
            Set(AudioData);

            if (loadState == SoundState.Playing)
                Play();
        }
        /// <summary>
        /// Remove From System
        /// </summary>
        internal void Remove()
        {
            if (!IsDisposed)
            {
                Stop();
                Global.SoundEffectInstaces[AudioData.ID].Enqueue(instance);
                int count = Global.SoundEffectInstaces[AudioData.ID].Count;
            }
        }
    }


    public class AudioProcessor3D
    {
        #region Fields
        [XmlIgnoreAttribute]
        public SoundEffect soundEffect;
        [XmlIgnoreAttribute]
        public SoundEffectInstance instance;
        public AudioData AudioData;
        public bool fadeIn;
        public long TimeLast;
        public long TimeNow;
        public long TimeElapsed = 0;
        public double tickTime = 0;
        public bool resetTimer = true;
        public SoundState currentState = SoundState.Playing;
        public SoundState loadState = SoundState.Playing;
        public int emitterID;
        public int listenerID;
        public AudioEmitter Emitter;
        public AudioListener Listener;

        EventProcessor EmitterEvent
        {
            get
            {
                if (emitterEvent == null)
                    return emitterEvent = Global.Instance.CurrentMap.GetEvent(emitterID);
                return emitterEvent;
            }
        }

        EventProcessor emitterEvent;

        EventProcessor ListenerEvent
        {
            get
            {
                if (listenerEvent == null)
                    return listenerEvent = Global.Instance.CurrentMap.GetEvent(listenerID);
                return listenerEvent;
            }
        }

        EventProcessor listenerEvent;
        #endregion

        public bool Active
        {
            set
            {
                if (value)
                {
                    if (currentState == SoundState.Playing)
                        Resume();
                }
                else
                {
                    if (currentState == SoundState.Playing)
                        if (!IsDisposed && instance.State == SoundState.Playing)
                            instance.Pause();
                }
            }
        }

        public AudioProcessor3D() { }
        /// <summary>
        /// Initializes the audio processor
        /// </summary>
        /// <param name="data"></param>
        public AudioProcessor3D(AudioData data)
        {
            Set(data);
        }

        /// <summary>
        /// Initializes the audio processor and plays if true
        /// </summary>
        /// <param name="data"></param>
        public AudioProcessor3D(AudioData data, bool play, int _emitter, int _listener)
        {
            Set(data);
            if (play) Play();
        }
        /// <summary>
        /// Sets the sound effect from the given data.
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="data"></param>
        public void Set(AudioData data)
        {
            // Set Sound
            Set(Content.SoundEffect(data.MaterialId), data);
        }
        /// <summary>
        /// Sets the sound effect from the given data and soundeffect.
        /// </summary>
        /// <param name="soundEffect"></param>
        /// <param name="data"></param>
        public void Set(SoundEffect se, AudioData data)
        {
            Dispose();
            // Set Sound
            soundEffect = se;
            AudioData = data;
            if (soundEffect != null)
                instance = GetInstance();
            if (!IsDisposed)
            {
                instance.Volume = data.Volume / 100f;
                instance.Pitch = data.Pitch / 100f;
                instance.Pan = data.Pan / 100f;
            }
        }
        /// <summary>
        /// Get Sound Effect Instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private SoundEffectInstance GetInstance()
        {
            Queue<SoundEffectInstance> cache;
            if (Global.SoundEffectInstaces.TryGetValue(AudioData.ID, out cache))
            {
                if (cache.Count > 0) return instance = cache.Dequeue();
                // If Cache is 0
                instance = soundEffect.CreateInstance();
                IsLooped = AudioData.Loop;
                return instance;
            }
            Global.SoundEffectInstaces.Add(AudioData.ID, new Queue<SoundEffectInstance>());
            instance = soundEffect.CreateInstance();
            IsLooped = AudioData.Loop;
            return instance;
        }
        /// <summary>
        /// Play audio.
        /// </summary>
        public void Play()
        {
            if (!IsDisposed)
            {
                Stop(true);
                instance.Volume = AudioData.Volume / 100f;
                instance.Pitch = AudioData.Pitch / 100f;
                instance.Pan = AudioData.Pan / 100f;
                if (AudioData.FadeIn == 0)
                    instance.Play();
                else
                {
                    instance.Volume = 0f;
                    instance.Play();
                    fadeIn = true;
                }
                currentState = SoundState.Playing;
                if (EmitterEvent != null)
                    Emitter.Position = new Vector3(EmitterEvent.Position, 0);
                if (ListenerEvent != null)
                    Listener.Position = new Vector3(ListenerEvent.Position, 0);
                instance.Apply3D(Listener, Emitter);
            }
        }
        /// <summary>
        /// Pause audio
        /// </summary>
        public void Pause()
        {
            if (!IsDisposed && instance.State == SoundState.Playing)
            {
                instance.Pause();
                currentState = SoundState.Paused;
            }
        }
        /// <summary>
        /// Resume audio
        /// </summary>
        public void Resume()
        {
            if (!IsDisposed && instance.State == SoundState.Paused)
            {
                instance.Resume();
                currentState = SoundState.Playing;
            }
        }
        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="p"></param>
        private void Stop(bool p)
        {
#if SILVERLIGHT
            instance.Stop();
#else
            instance.Stop(p);
#endif
        }
        /// <summary>
        /// Stop audio
        /// </summary>
        public void Stop()
        {
            if (!IsDisposed && instance.State == SoundState.Playing)
            {
                Stop(true);
                currentState = SoundState.Stopped;
            }
        }
        /// <summary>
        /// Fade in
        /// </summary>
        /// <param name="fade"></param>
        private void FadeIn(float fade)
        {
            if (!IsDisposed)
            {
                fadeIn = true;
                float max = AudioData.Volume / 100f;
                float inc = max / fade;
                if (instance.Volume + inc >= 0f && instance.Volume + inc <= 1f)
                    instance.Volume += inc;
                else
                {
                    instance.Volume = AudioData.Volume / 100f;
                    fadeIn = false;
                }
                if (instance.Volume >= AudioData.Volume)
                {
                    instance.Volume = AudioData.Volume / 100f;
                    fadeIn = false;
                }
            }
        }
        /// <summary>
        /// Fade out
        /// </summary>
        /// <param name="fadeOut"></param>
        private void FadeOut(float fadeOut)
        {
            float max = AudioData.Volume / 100f;
            float inc = max / fadeOut;
            if (instance.Volume - inc >= 0f && instance.Volume - inc <= 1f)
                instance.Volume -= inc;
            else
            {
                instance.Volume = 0f;
            }
            if (instance.Volume == 0 && AudioData.Volume > 0 && instance.State == SoundState.Playing)
                Stop(true);
        }
        /// <summary>
        /// Update audio
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Apply 3D
            if (!IsDisposed)
            {
                if (EmitterEvent != null)
                    Emitter.Position = new Vector3(EmitterEvent.Position, 0);
                if (ListenerEvent != null)
                    Listener.Position = new Vector3(ListenerEvent.Position, 0);
                instance.Apply3D(Listener, Emitter);

                loadState = instance.State;
            }
        }
        /// <summary>
        /// Returns the state of the audio
        /// </summary>
        public SoundState State
        {
            get { return instance.State; }
        }
        /// <summary>
        /// Gets our sets the volume of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public float Volume
        {
            get
            {
                if (IsDisposed) return 0;
                return instance.Volume;
            }

            set
            {
                if (!IsDisposed)
                {
                    instance.Volume = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the pitch of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public float Pitch
        {
            get
            {
                if (IsDisposed) return 0;
                return instance.Pitch;
            }

            set
            {
                if (!IsDisposed)
                {
                    instance.Pitch = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the pan of the audio
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public float Pan
        {
            get
            {
                if (IsDisposed) return 0;
                return instance.Pan;
            }

            set
            {
                if (!IsDisposed)
                {
                    instance.Pan = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets loop
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public bool IsLooped
        {
            get { return instance.IsLooped; }
            set
            {
                instance.IsLooped = value;
            }
        }
        /// <summary>
        /// Gets a value indicating whether the audio is disposed
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public bool IsDisposed
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    return true;
                if (AudioData == null)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// Releases resources used by the audio
        /// </summary>
        public void Dispose()
        {
            if (!IsDisposed)
            {
                soundEffect = null;
                instance = null;
                AudioData = null;
            }
        }

        internal void FadeOut()
        {
            FadeOut(AudioData.FadeOut);
        }

        /// <summary>
        /// Load audio
        /// </summary>
        internal void Load()
        {
            Set(AudioData);

            if (loadState == SoundState.Playing)
                Play();
        }
        /// <summary>
        /// Remove From System
        /// </summary>
        internal void Remove()
        {
            if (!IsDisposed)
            {
                Stop();
                Global.SoundEffectInstaces[AudioData.MaterialId].Enqueue(instance);
            }
        }
    }
}
