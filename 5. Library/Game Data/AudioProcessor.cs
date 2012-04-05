//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace EGMGame.Library
{
    public class AudioProcessor
    {
        SoundEffect sound;
        SoundEffectInstance instance;
        AudioData data;
        Thread activethread;
        double tickTime = 0;
        bool fadeIn;
        bool thread = true;
        //calculate FPS
        Stopwatch timer;
        long nCount = 0;
        long uCount = 0;
        long TimeLast;
        long TimeNow;
        long TimeElapsed = 0;

        public void Set(SoundEffect s, AudioData d)
        {
            if (s != sound)
                Dispose();
            sound = s;
            data = d;
            if (s != null && !s.IsDisposed)
                instance = s.CreateInstance();
            if (!IsDisposed)
            {
                instance = s.CreateInstance();
                instance.IsLooped = d.Loop;
                instance.Volume = d.Volume / 100f;
                instance.Pitch = d.Pitch / 100f;
                instance.Pan = d.Pan / 100f;
            }
        }

        public void Play()
        {
            if (!IsDisposed)
            {
                instance.Stop();
                instance.Volume = data.Volume / 100f;
                instance.Pitch = data.Pitch / 100f;
                instance.Pan = data.Pan / 100f;
                tickTime = 0;
                if (data.FadeIn == 0)
                    instance.Play();
                else
                {
                    instance.Volume = 0f;
                    instance.Play();
                    fadeIn = true;
                }
            }
        }

        public void Pause()
        {
            if (!IsDisposed && instance.State == SoundState.Playing)
            {
                instance.Pause();
            }
        }

        public void Resume()
        {
            if (!IsDisposed && instance.State == SoundState.Paused)
            {
                instance.Resume();
            }
        }

        public void Stop()
        {
            if (!IsDisposed)
            {
                instance.Stop();
            }
        }

        private void FadeIn(float fade)
        {
            if (!IsDisposed)
            {
                fadeIn = true;
                float max = data.Volume / 100f;
                float inc = max / fade;
                if (instance.Volume + inc >= 0f && instance.Volume + inc <= 1f)
                    instance.Volume += inc;
                else
                {
                    instance.Volume = data.Volume / 100f;
                    fadeIn = false;
                }
                if (instance.Volume >= data.Volume)
                {
                    instance.Volume = data.Volume / 100f;
                    fadeIn = false;
                }
            }
        }

        private void FadeOut(float fadeOut)
        {
            float max = data.Volume / 100f;
            float inc = max / fadeOut;
            if (instance.Volume - inc >= 0f && instance.Volume - inc <= 1f)
                instance.Volume -= inc;
            else
            {
                instance.Volume = 0f;
            }
            if (instance.Volume == 0 && data.Volume > 0 && instance.State == SoundState.Playing)
                instance.Stop(true);
        }

        public void Update()
        {
            thread = true;
            while (thread)
            {
                // Calculate FPS
                if (timer.IsRunning)
                {
                    nCount++;
                    TimeNow = timer.ElapsedMilliseconds;
                    long TimeDelta = TimeNow - TimeLast;

                    TimeElapsed += TimeDelta;
                    uCount += TimeDelta;

                    TimeLast = TimeNow;

                    if (TimeElapsed >= 1)
                    {

                        tickTime++;
                        if (!IsDisposed && instance.State == SoundState.Playing)
                        {
                            if (fadeIn)
                                FadeIn(data.FadeIn);
                            if (data.FadeAfter)
                            {
                                if (data.FadeOut > 0 && tickTime >= data.FadeOut && instance.State == SoundState.Playing)
                                    FadeOut(data.FadeOut);
                            }
                            else
                            {
                                if (data.FadeOut > 0 && tickTime >= (float)Duration.TotalMilliseconds - data.FadeOut && instance.State == SoundState.Playing)
                                    FadeOut(data.FadeOut);
                            }
                            if (tickTime >= Duration.TotalMilliseconds)
                                tickTime = 0;
                        }
                        else
                        {
                            tickTime = 0;
                        }

                        nCount = 0;
                        TimeElapsed = 0;
                        uCount = 0;
                    }
                }

                try
                {
                    if (MainForm.Instance.IsDisposed)
                        thread = false;
                }
                catch
                {
                    thread = false;
                }
                if (!thread)
                    Thread.CurrentThread.Abort();
            }
        }

        internal void StartThread()
        {
            timer = new Stopwatch();
            timer.Start();
            if (activethread == null || !thread)
            {
                activethread = new Thread(Update);
                activethread.Start();
                thread = true;
            }
        }

        internal void EndThread()
        {
            if (timer != null)
                timer.Stop();
            //if (activethread != null)
            //{
            //    activethread.Abort();
            //}
            //activethread = null;
            //thread = false;
        }
        internal void EndThreadFinal()
        {
            if (activethread != null)
            {
                activethread.Abort();
            }
            activethread = null;
            thread = false;
        }

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

        public TimeSpan Duration
        {
            get
            {
                if (IsDisposed) return new TimeSpan();
                return sound.Duration;
            }
        }

        public bool Loop
        {
            get
            {
                if (IsDisposed) return false;
                return instance.IsLooped;
            }

            set
            {
                if (!IsDisposed)
                {
                    bool playing = (instance.State == SoundState.Playing);
                    instance.Dispose();
                    instance = sound.CreateInstance();
                    instance.IsLooped = value;
                    if (playing)
                        Play();
                }
            }
        }

        public bool IsDisposed
        {
            get
            {
                if (sound == null || sound.IsDisposed)
                    return true;
                if (instance == null || instance.IsDisposed)
                    return true;
                if (data == null)
                    return true;
                return false;
            }
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                //sound.Dispose(); 
                sound = null;
                instance = null;
                data = null;
            }
        }
    }
}
