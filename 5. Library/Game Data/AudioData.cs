using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the audio data.
    /// Includes audio material id, volume, pitch, pan, fade in/out, and ect.
    /// </summary>
    [Serializable]
    public class AudioData : IGameData
    {
        /// <summary>
        /// Name
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        [Browsable(false)]
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        /// <summary>
        /// The category the data is in. Usage is optional.
        /// </summary>
        [Browsable(false)]
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// Gets the filename of the audio
        /// </summary>
        public string FileName
        {
            get
            {
                MaterialData material = Global.GetData<MaterialData>(MaterialId, GameData.Materials);
                if (material == null) return "";
                return Path.Combine(Global.Project.Location, material.FileName);
            }
        }
        /// <summary>
        /// The material id is used to reference a materail in materials list.
        /// </summary>
        [Browsable(false)]
        public int MaterialId
        {
            get { return materialId; }
            set { materialId = value; }
        }
        int materialId = -1;
        /// <summary>
        /// Number Fade in time in seconds.
        /// </summary>
        public float FadeIn
        {
            get { return fadeIn; }
            /// Number Fade out time in seconds.
            /// </summary>
            set { fadeIn = value; }
        }
        /// <summary>
        public float FadeOut
        {
            get { return fadeOut; }
            set { fadeOut = value; }
        }
        /// <summary>
        /// Determines if the audio should start fading out from start or before end.
        /// </summary>
        public bool FadeAfter
        {
            get { return fadeAfter; }
            set { fadeAfter = value; }
        }
        /// <summary>
        /// Gets or sets the pan. -1f to 1f.
        /// </summary>
        public float Pan
        {
            get { return panningAngle; }
            set { panningAngle = value; }
        }
        /// <summary>
        /// Gets or sets the pitch of the audio. -1f to 1f.
        /// </summary>
        public float Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }
        /// <summary>
        /// Gets or sets the volume of the audio. 0f to 1f.
        /// </summary>
        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        /// <summary>
        /// Gets or sets whether the audio should loop.
        /// </summary>
        public bool Loop
        {
            get { return infinite; }
            set { infinite = value; }
        }
        float fadeIn = 0;
        float fadeOut = 0;
        float panningAngle = 0;
        float pitch = 0;
        float volume = 100f;
        bool infinite = false;
        bool fadeAfter = false;
    }

    public class AudioSettings
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AudioSettings(int _fadeIn, int _fadeOut, bool _fadeAfter, float _pan, float _pitch, float _volume, bool _loop)
        {
            fadeIn = _fadeIn;
            fadeOut = _fadeOut;
            fadeAfter = _fadeAfter;
            panningAngle = _pan;
            pitch = _pitch;
            volume = _volume;
            infinite = _loop;
        }
        /// <summary>
        /// Number Fade in time in seconds.
        /// </summary>
        public float FadeIn
        {
            get { return fadeIn; }
            set { fadeIn = value; }
        }
        /// <summary>
        /// Number Fade out time in seconds.
        /// </summary>
        public float FadeOut
        {
            get { return fadeOut; }
            set { fadeOut = value; }
        }
        /// <summary>
        /// Determines if the audio should start fading out from start or before end.
        /// </summary>
        public bool FadeAfter
        {
            get { return fadeAfter; }
            set { fadeAfter = value; }
        }
        /// <summary>
        /// Gets or sets the pan. -1f to 1f.
        /// </summary>
        public float Pan
        {
            get { return panningAngle; }
            set { panningAngle = value; }
        }
        /// <summary>
        /// Gets or sets the pitch of the audio. -1f to 1f.
        /// </summary>
        public float Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }
        /// <summary>
        /// Gets or sets the volume of the audio. 0f to 1f.
        /// </summary>
        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        /// <summary>
        /// Gets or sets whether the audio should loop.
        /// </summary>
        public bool Loop
        {
            get { return infinite; }
            set { infinite = value; }
        }
        float fadeIn = 0;
        float fadeOut = 0;
        float panningAngle = 0;
        float pitch = 0;
        float volume = 100f;
        bool infinite = false;
        bool fadeAfter = false;
    }
}
