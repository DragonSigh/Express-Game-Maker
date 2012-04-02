//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the audio data.
    /// Includes audio material id, volume, pitch, pan, fade in/out, and ect.
    /// </summary>
    
    public class AudioData : IGameData
    {
        /// <summary>
        /// Name
        /// </summary>
        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        /// <summary>
        /// The category the data is in. Usage is optional.
        /// </summary>
        
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// The material id is used to reference a materail in materials list.
        /// </summary>
        /// 
        public int MaterialId;

        /// <summary>
        /// Number Fade in time in seconds.
        /// </summary>
        public float FadeIn;
        /// <summary>
        /// Number Fade out time in seconds.
        /// </summary>
        public float FadeOut;
        /// <summary>
        /// Determines if the audio should start fading out from start or before end.
        /// </summary>
        public bool FadeAfter;
        /// <summary>
        /// Gets or sets the pan. -1f to 1f.
        /// </summary>
        public float Pan;
        /// <summary>
        /// Gets or sets the pitch of the audio. -1f to 1f.
        /// </summary>
        public float Pitch;
        /// <summary>
        /// Gets or sets the volume of the audio. 0f to 1f.
        /// </summary>
        public float Volume;
        /// <summary>
        /// Gets or sets whether the audio should loop.
        /// </summary>
        public bool Loop;
    }

    
    public class AudioSettings
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AudioSettings(int _fadeIn, int _fadeOut, bool _fadeAfter, float _pan, float _pitch, float _volume, bool _loop)
        {
            FadeIn = _fadeIn;
            FadeOut = _fadeOut;
            FadeAfter = _fadeAfter;
            Pan = _pan;
            Pitch = _pitch;
            Volume = _volume;
            Loop = _loop;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public AudioSettings(float _pan, float _pitch, float _volume, bool _loop)
        {
            Pan = _pan;
            Pitch = _pitch;
            Volume = _volume;
            Loop = _loop;
        }
        /// <summary>
        /// Number Fade in time in seconds.
        /// </summary>
        public float FadeIn;
        public float FadeOut;
        public bool FadeAfter;
        public float Pan;
        public float Pitch;
        public float Volume;
        public bool Loop;
    }
    
    public enum AudioDataType
    {
        BGM,
        BGS,
        SE
    }
}
