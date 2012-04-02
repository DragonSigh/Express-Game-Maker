//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using EGMGame.Library;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using FarseerPhysics.Collision;
using System.IO;
using System.Collections;
using Microsoft.Xna.Framework.Content;
using FarseerPhysics.Common;

namespace EGMGame.Library
{
    /// <summary>
    /// The AnimationData class is where all the necessary Animation data is stored.
    /// This includes actions, directions, frames, sprites, anchors and physics.
    /// </summary>
    
    public class AnimationData : IGameData
    {
        /// <summary>
        /// Name of the animation.
        /// </summary>
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;

        /// <summary>
        /// List of the actions in the animation
        /// </summary>
        public List<AnimationAction> Actions
        {
            get { return actions; }
            set { actions = value; }
        }
        List<AnimationAction> actions = new List<AnimationAction>();
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
    }
    /// <summary>
    /// Animation Action
    /// </summary>
    
    public class AnimationAction : IGameData
    {
        /// <summary>
        /// Name of the action.
        /// </summary>
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the action.
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
        /// The body of the sprite.
        /// </summary>
        public Vertices CollisionBody
        {
            get { return body; }
            set { body = value; }
        }
        Vertices body = new Vertices();
        /// <summary>
        /// The body of the sprite.
        /// </summary>
        public Vertices HitBody
        {
            get { return hbody; }
            set { hbody = value; }
        }
        Vertices hbody = new Vertices();

        public List<PhysicsPin> Pins
        {
            get { return pins; }
            set { pins = value; }
        }
        List<PhysicsPin> pins = new List<PhysicsPin>();
        /// <summary>
        /// Gets or sets the size of the canvas for all frames of this action.
        /// </summary>
         public Vector2 CanvasSize
        {
            get { return canvasSize; }
            set { canvasSize = value; }
        }
        Vector2 canvasSize = new Vector2(383, 329);
        /// <summary>
        /// Gets or sets whether the action loops infinitely.
        /// </summary>
        public bool InfiniteLoop
        {
            get { return infiniteLoop; }
            set { infiniteLoop = value; }
        }
        bool infiniteLoop;
        /// <summary>
        /// Gets or sets whether the action loops infinitely.
        /// </summary>
        public bool ShowOnScreen
        {
            get { return showOnScreen; }
            set { showOnScreen = value; }
        }
        bool showOnScreen;
        /// <summary>
        /// Gets or sets the number of times the action should be looped.
        /// </summary>
        public int LoopCount
        {
            get { return loopCount; }
            set { loopCount = value; }
        }
        int loopCount = 0;
        /// <summary>
        /// There are 8 directions each contaning a frame.
        /// Directions[DIRECTION_INDEX][FRAME_INDEX]
        /// </summary>        
        public List<List<AnimationFrame>> Directions
        {
            get { return directions; }
            set { directions = value; }
        }
        List<List<AnimationFrame>> directions;
        
        public List<List<AnimationParticle>> Particles
        {
            get { return particles; }
            set { particles = value; }
        }
        List<List<AnimationParticle>> particles;


    }

    /// <summary>
    /// Animation Frames
    /// </summary>
    
    public class AnimationFrame : IGameData
    {
        /// <summary>
        /// Name of the frame.
        /// </summary>
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;

        /// <summary>
        /// The unique id of the frame.
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
        /// The amount of time in milliseconds the frame will display.
        /// </summary>
        public int TimeElapse
        {
            get { return timeElapse; }
            set { timeElapse = value; }
        }
        int timeElapse = 0;

        /// <summary>
        /// Gets or sets the ID of the sound effect that should be played when the frame is displayed.
        /// </summary>
        public int SoundEffectID
        {
            get
            {
                return seID;
            }
            set
            {
                seID = value;
            }
        }
        int seID = 0;
        /// <summary>
        /// Gets or sets whether a sound effect should be played.
        /// </summary>
        public bool PlaySE
        {
            get { return playSE; }
            set { playSE = value; }
        }
        bool playSE;
        /// <summary>
        /// Flash Screen
        /// </summary>
        public bool FlashScreen
        {
            get { return flashScreen; }
            set { flashScreen = value; }
        }
        bool flashScreen = false;
        /// <summary>
        /// Gets or sets whether the frame(s) will be shaked.
        /// </summary>
        public bool ShakeScreen
        {
            get { return shakeScreen; }
            set { shakeScreen = value; }
        }
        bool shakeScreen = false;
        /// <summary>
        /// Gets or sets the number of frames to shake.
        /// </summary>
        public int ShakeFrames
        {
            get { return shakeFrames; }
            set { shakeFrames = value; }
        }
        int shakeFrames = 60;
        /// <summary>
        /// Gets or sets the shake power.
        /// </summary>
        public int ShakePower
        {
            get { return shakePower; }
            set { shakePower = value; }
        }
        int shakePower = 5;
        /// <summary>
        /// Gets or sets the shake speed.
        /// </summary>
        public int ShakeSpeed
        {
            get { return shakeSpeed; }
            set { shakeSpeed = value; }
        }
        int shakeSpeed = 5;
        /// <summary>
        /// Flash Color
        /// </summary>
        public Color FlashColor
        {
            get { return flashColor; }
            set { flashColor = value; }
        }
        Color flashColor = Color.White;
        /// <summary>
        /// Flash Frames
        /// </summary>
        public int FlashFrames
        {
            get { return flashFrames; }
            set { flashFrames = value; }
        }
        int flashFrames = 15;
        /// <summary>
        /// Flash Frequency
        /// </summary>
        public int FlashFreq
        {
            get { return flashFreq; }
            set { flashFreq = value; }
        }
        int flashFreq = 5;
        /// <summary>
        /// Gets or sets whether the frame's screen will be tinted.
        /// </summary>
        public bool TintScreen
        {
            get { return tintScreen; }
            set { tintScreen = value; }
        }
        bool tintScreen = false;
        /// <summary>
        /// Gets or sets the tint color for the frame's screen.
        /// </summary>
        public Color TintColor
        {
            get { return tintColor; }
            set { tintColor = value; }
        }
        Color tintColor = new Color();
        /// <summary>
        /// List of sprites in the frame.
        /// </summary>
        
        public List<AnimationSprite> Sprites
        {
            get { return sprites; }
            set { sprites = value; }
        }
        List<AnimationSprite> sprites;

        /// <summary>
        /// List of anchors in the frame.
        /// </summary>        
        public List<AnimationAnchor> Anchors
        {
            get { return anchors; }
            set { anchors = value; }

        }
        List<AnimationAnchor> anchors;
    }

    
    public class AnimationSprite : IGameData
    {
        /// <summary>
        /// Name of the sprite.
        /// </summary>        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the sprite.
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
        public int MaterialId;
        /// <summary>
        /// Displayed rectangle of the sprite.
        /// </summary>
        public Rectangle DisplayRect;
        /// <summary>
        /// Position of the sprite.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Gets or sets the size of the sprite.
        /// </summary>
        public Vector2 Size;
        /// <summary>
        /// Gets or sets the sprite's scale which determines its size ratio.
        /// </summary>
        public Vector2 Scale;

        /// <summary>
        /// Gets or sets the sprite's rotation angle in degrees.
        /// </summary>
        public float Rotation;

        /// <summary>
        /// Gets or sets whether the sprite will be flipped on the horizontal axis.
        /// </summary>
        public bool HorizontalFlip;

        /// <summary>
        /// Gets or sets whether the sprite will be flipped on the vertical axis.
        /// </summary>
        public bool VerticalFlip;

        /// <summary>
        /// Gets or sets the opacity of the animation.
        /// </summary>
        public byte Opacity;

        /// <summary>
        /// Gets or sets the tint of the animation.
        /// </summary>
        public Color Tint;

        public bool TorqueSync;
        
        public Vector2 OriginOffset;
    }

    
    public class AnimationAnchor : IGameData
    {
        /// <summary>
        /// Name of the anchor.
        /// </summary>        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;
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
        /// The unique id
        /// </summary>
        
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;

        /// <summary>
        /// Location
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position = new Vector2(0, 0);
        /// <summary>
        /// Gets or sets the size of the anchor.
        /// </summary>
        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        Vector2 size = new Vector2(8, 8);
    }

    
    public class PhysicsPin : IGameData
    {
        /// <summary>
        /// Name of the anchor.
        /// </summary>
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;
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
        /// The unique id
        /// </summary>
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        #region IMovable Members
        /// <summary>
        /// Location
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position = new Vector2(0, 0);

        /// <summary>
        /// Gets or sets the size of the anchor.
        /// </summary>
        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        Vector2 size = new Vector2(8, 8);
        /// <summary>
        /// Gets or sets the width of the anchor.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float Width
        {
            get
            {
                return size.X;
            }
            set
            {
                size.X = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the anchor.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float Height
        {
            get
            {
                return size.Y;
            }
            set
            {
                size.Y = value;
            }
        }
        #endregion

        public bool EnableMotor
        {
            get { return enableMotor; }
            set { enableMotor = value; }
        }
        bool enableMotor = false;

        public float MotorTorque
        {
            get { return motorTorque; }
            set { motorTorque = value; }
        }
        float motorTorque;

        public float MotorSpeed
        {
            get { return motorSpeed; }
            set { motorSpeed = value; }
        }
        float motorSpeed;
        /// <summary>
        /// Get the name of the anchor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name + " - Pin";
        }
    }
    
    public class AnimationParticle : IGameData
    {
        /// <summary>
        /// Name of the anchor.
        /// </summary>
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;
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
        /// The unique id
        /// </summary>
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        #region IMovable Members

        /// <summary>
        /// Bounds
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public Rectangle Bounds
        {
            get { return new Rectangle((int)X, (int)Y, (int)Width, (int)Height); }
        }

        /// <summary>
        /// Location
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position = new Vector2(0, 0);

        /// <summary>
        /// The X position of the anchor.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The Y position of the anchor.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        /// <summary>
        /// Gets or sets the size of the anchor.
        /// </summary>
        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        Vector2 size = new Vector2(8, 8);
        /// <summary>
        /// Gets or sets the width of the anchor.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float Width
        {
            get
            {
                return size.X;
            }
            set
            {
                size.X = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the anchor.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float Height
        {
            get
            {
                return size.Y;
            }
            set
            {
                size.Y = value;
            }
        }
        #endregion

        public int Particle
        {
            get { return particle; }
            set { particle = value; }
        }
        int particle;

        public bool AngularSync
        {
            get { return angularSync; }
            set { angularSync = value; }
        }
        bool angularSync;
        /// <summary>
        /// Get the name of the anchor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name + " - Anchor";
        }
    }
}
