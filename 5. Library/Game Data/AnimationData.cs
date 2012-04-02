using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using EGMGame.Library;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Library.Interface;
using EGMGame.Controls;
using System.Xml.Serialization;
using FarseerPhysics.Collisions;
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
    [Serializable]
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

        public override string ToString()
        {
            return name;
        }
    }
    /// <summary>
    /// Animation Action
    /// </summary>
    [Serializable]
    public class AnimationAction : IGameData
    {
        /// <summary>
        /// Name of the action.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the action.
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
        [DisplayName("Canvas Size"), Category("Properties"), Description("The size of the canvas for all frames of this action.")]
        public Vector2 CanvasSize
        {
            get { return canvasSize; }
            set { canvasSize = value; }
        }
        Vector2 canvasSize = new Vector2(383, 329);

        /// <summary>
        /// Gets or sets whether the action loops infinitely.
        /// </summary>
        [DisplayName("Infinite Loop"), Category("Properties"), Description("If true, the action will loop infinitely until the action is changed.")]
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
        [DisplayName("Loop Count"), Category("Properties"), Description("Determines the number of times the action should be looped.")]
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
        [Browsable(false)]
        public List<List<AnimationFrame>> Directions
        {
            get { return directions; }
            set { directions = value; }
        }
        List<List<AnimationFrame>> directions = new List<List<AnimationFrame>>(8);

        public List<List<AnimationParticle>> Particles
        {
            get { return particles; }
            set { particles = value; }
        }
        List<List<AnimationParticle>> particles = new List<List<AnimationParticle>>()
        {
           new List<AnimationParticle>(),
           new List<AnimationParticle>(),
           new List<AnimationParticle>(),
           new List<AnimationParticle>(),
           new List<AnimationParticle>(),
           new List<AnimationParticle>(),
           new List<AnimationParticle>(),
           new List<AnimationParticle>()
        };
    }
    /// <summary>
    /// Collection of directions
    /// </summary>
    public class DirectionCollection : IList<List<AnimationFrame>>, IList
    {
        // Directions
        List<List<AnimationFrame>> directions = new List<List<AnimationFrame>>(8);
        // Physics


        #region IList<List<AnimationFrame>> Members

        public int IndexOf(List<AnimationFrame> item)
        {
            return directions.IndexOf(item);
        }

        public void Insert(int index, List<AnimationFrame> item)
        {
            directions.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            directions.RemoveAt(index);
        }

        public List<AnimationFrame> this[int index]
        {
            get
            {
                return directions[index];
            }
            set
            {
                directions[index] = value;
            }
        }

        #endregion

        #region ICollection<List<AnimationFrame>> Members

        public void Add(List<AnimationFrame> item)
        {
            directions.Add(item);
        }

        public void Clear()
        {
            directions.Clear();
        }

        public bool Contains(List<AnimationFrame> item)
        {
            return directions.Contains(item);
        }

        public void CopyTo(List<AnimationFrame>[] array, int arrayIndex)
        {
            directions.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return directions.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(List<AnimationFrame> item)
        {
            return directions.Remove(item);
        }

        #endregion

        #region IEnumerable<List<AnimationFrame>> Members

        public IEnumerator<List<AnimationFrame>> GetEnumerator()
        {
            return directions.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return directions.GetEnumerator();
        }

        #endregion



        #region IList Members

        int IList.Add(object value)
        {
            throw new NotImplementedException();
        }

        void IList.Clear()
        {
            throw new NotImplementedException();
        }

        bool IList.Contains(object value)
        {
            throw new NotImplementedException();
        }

        int IList.IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        void IList.Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        bool IList.IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        bool IList.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        void IList.Remove(object value)
        {
            throw new NotImplementedException();
        }

        void IList.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        object IList.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection Members

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        int ICollection.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection.IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        object ICollection.SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
    /// <summary>
    /// Animation Frames
    /// </summary>
    [Serializable]
    public class AnimationFrame : IGameData
    {
        /// <summary>
        /// Name of the frame.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return timeElapse.ToString() + " Frames"; }
            set { name = value; }
        }
        string name;

        /// <summary>
        /// The unique id of the frame.
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
        /// The amount of time in milliseconds the frame will display.
        /// </summary>
        [CategoryAttribute("Properties"), Description("The amount of time in frames the frame will display.")]
        public int TimeElapse
        {
            get { return timeElapse; }
            set { timeElapse = value; }
        }
        int timeElapse = 8;

        /// <summary>
        /// Gets or sets the ID of the sound effect that should be played when the frame is displayed.
        /// </summary>
        [DisplayName("Sound Effect"), CategoryAttribute("Effect"), Description("The sound effect that should be played when the frame is displayed.")]
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
        /// Gets or sets the shake frames.
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
        [Browsable(false)]
        public List<AnimationSprite> Sprites
        {
            get { return sprites; }
            set { sprites = value; }
        }
        List<AnimationSprite> sprites = new List<AnimationSprite>();

        /// <summary>
        /// List of anchors in the frame.
        /// </summary>
        [Browsable(false)]
        public List<AnimationAnchor> Anchors
        {
            get { return anchors; }
            set { anchors = value; }

        }
        List<AnimationAnchor> anchors = new List<AnimationAnchor>()
            {
                new AnimationAnchor(),
                new AnimationAnchor(),
                new AnimationAnchor(),
                new AnimationAnchor(),
                new AnimationAnchor(),
                new AnimationAnchor(),
                new AnimationAnchor(),
                new AnimationAnchor()
            };
    }

    [Serializable]
    public class AnimationSprite : IGameData, IMovable
    {
        /// <summary>
        /// Name of the sprite.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;

        /// <summary>
        /// The unique id of the sprite.
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
        /// Displayed rectangle of the sprite.
        /// </summary>
        public Rectangle DisplayRect
        {
            get { return displayRect; }
            set { displayRect = value; }
        }
        Rectangle displayRect = new Rectangle(0, 0, 0, 0);
        /// <summary>
        /// The rectangle holding the position(x, y) and size(width, height) of the object.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        public Rectangle Bounds
        {
            get { return new Rectangle((int)X, (int)Y, (int)Width, (int)Height); }
        }

        /// <summary>
        /// Position of the sprite.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position = new Vector2(0, 0);

        /// <summary>
        /// The X position of the sprite.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The Y position of the sprite.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        /// <summary>
        /// Gets or sets the size of the sprite.
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
        Vector2 size = new Vector2(0, 0);
        /// <summary>
        /// Gets or sets the width of the sprite.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
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
        /// Gets or sets the height of the sprite.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
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

        /// <summary>
        /// Gets or sets the sprite's scale which determines its size ratio.
        /// </summary>
        [CategoryAttribute("Image"), Description("The sprite's scale which determines its size ratio.")]
        public Vector2 Scale
        {
            get { return scale; }
            set
            {
                scale = value;
            }
        }
        Vector2 scale = new Vector2(1f, 1f);

        /// <summary>
        /// Gets or sets the sprite's rotation angle in degrees.
        /// </summary>
        [CategoryAttribute("Image"), Description("The sprite's rotation angle in degrees.")]
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        float rotation = 0;

        /// <summary>
        /// Gets or sets whether the sprite will be flipped on the horizontal axis.
        /// </summary>
        [DisplayName("Horizontal Flip"), CategoryAttribute("Image"), Description("Determines whether the sprite will be flipped on the horizontal axis.")]
        public bool HorizontalFlip
        {
            get { return horizontalFlip; }
            set { horizontalFlip = value; }
        }
        bool horizontalFlip;

        /// <summary>
        /// Gets or sets whether the sprite will be flipped on the vertical axis.
        /// </summary>
        [DisplayName("Vertical Flip"), CategoryAttribute("Image"), Description("Determines whether the sprite will be flipped on the vertical axis.")]
        public bool VerticalFlip
        {
            get { return verticalFlip; }
            set { verticalFlip = value; }
        }
        bool verticalFlip;

        /// <summary>
        /// Gets or sets the opacity of the animation.
        /// </summary>
        [CategoryAttribute("Image"), Description("The sprite's opacity.")]
        public byte Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }
        byte opacity = 255;

        /// <summary>
        /// Gets or sets the tint of the animation.
        /// </summary>
        [CategoryAttribute("Image"), Description("The sprite's tint.")]
        public Color Tint
        {
            get { return tint; }
            set { tint = value; }
        }
        Color tint = Color.White;

        public bool TorqueSync
        {
            get { return torqueSync; }
            set { torqueSync = value; }
        }
        bool torqueSync = false;

        public Vector2 OriginOffset;
        /// <summary>
        /// Sets the DisplayRect and Bounds to the size of the texture.
        /// </summary>
        internal void AspectToTexture()
        {
            if (materialId > -1 && DisplayRect.Width == 0 && DisplayRect.Height == 0)
            {
                MaterialData data = Global.GetData<MaterialData>(materialId, GameData.Materials);
                // Get Material Texture File
                if (File.Exists(Path.Combine(Global.Project.Location, data.FileName)))
                {
                    using (System.Drawing.Bitmap b = new System.Drawing.Bitmap(Path.Combine(Global.Project.Location, data.FileName)))
                    {

                        size.X = displayRect.Width = b.Width;
                        size.Y = displayRect.Height = b.Height;
                        b.Dispose();
                    }
                }
            }
        }
        internal void ForceAspectToTexture()
        {
            if (materialId > -1)
            {
                MaterialData data = Global.GetData<MaterialData>(materialId, GameData.Materials);
                // Get Material Texture File
                if (File.Exists(Path.Combine(Global.Project.Location, data.FileName)))
                {
                    using (System.Drawing.Bitmap b = new System.Drawing.Bitmap(Path.Combine(Global.Project.Location, data.FileName)))
                    {

                        size.X = displayRect.Width = b.Width;
                        size.Y = displayRect.Height = b.Height;
                        b.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// Get System Rectangle
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetRectangle()
        {
            return new System.Drawing.RectangleF(position.X, position.Y, displayRect.Width, displayRect.Height);
        }
        /// <summary>
        /// Gets the scaled System Rectangle
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetScaledRectangle(float zoom)
        {
            return new System.Drawing.RectangleF(position.X - (size.X / 2) * scale.X, position.Y - (size.Y / 2) * scale.Y, displayRect.Width * scale.X, displayRect.Height * scale.Y);
        }
        /// <summary>
        /// Gets thetransformed RecrangleV
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetTransRectangle()
        {
            return new System.Drawing.RectangleF(position.X - (size.X / 2) * scale.X, position.Y - (size.Y / 2) * scale.Y, displayRect.Width * scale.X, displayRect.Height * scale.Y);
        }
        /// <summary>
        /// Sets the mouse offset with the in sprite DisplayRect.
        /// </summary>
        /// <param name="mouseOffx"></param>
        /// <param name="mouseOffy"></param>
        /// <param name="point"></param>
        internal void SetOffSet(out float mouseOffx, out float mouseOffy, System.Drawing.PointF point)
        {
            mouseOffx = point.X - position.X;
            mouseOffy = point.Y - position.Y;
        }

        /// <summary>
        /// Get the Top Left Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetTopLeft()
        {
            Vector2 center, p;
            center = new Vector2(position.X - 4, position.Y - 4);
            // p = ExMath.rotatePoint(center, new Vector2(position.X  - 4, position.Y - 4), rotation);
            return new System.Drawing.RectangleF(center.X, center.Y, 8, 8);
        }
        /// <summary>
        /// Get the Top Right Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetTopRight()
        {
            Vector2 center, p;
            center = new Vector2(position.X - (size.X / 2) - 4, position.Y - (size.Y / 2) - 4);
            p = ExMath.rotatePoint(center, new Vector2(position.X - (size.X / 2) * scale.X + displayRect.Width * scale.X - 4, position.Y - (size.Y / 2) * scale.Y - 4), 0);
            return new System.Drawing.RectangleF(p.X, p.Y, 8, 8);
        }
        /// <summary>
        /// Get the bottom right Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetBottomRight()
        {
            Vector2 center, p;
            center = new Vector2(position.X - (size.X / 2) - 4, position.Y - (size.Y / 2) - 4);
            p = ExMath.rotatePoint(center, new Vector2(position.X - (size.X / 2) * scale.X + displayRect.Width * scale.X - 4, position.Y - (size.Y / 2) * scale.Y - 4 + displayRect.Height * scale.Y), 0);
            return new System.Drawing.RectangleF(p.X, p.Y, 8, 8);
        }
        /// <summary>
        /// Get the Bottom Left Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetBottomLeft()
        {
            Vector2 center, p;
            center = new Vector2(position.X - (size.X / 2) - 4, position.Y - (size.Y / 2) - 4);
            p = ExMath.rotatePoint(center, new Vector2(position.X - (size.X / 2) - 4, position.Y - (size.Y / 2) + displayRect.Height * scale.Y - 4), 0);
            return new System.Drawing.RectangleF(p.X, p.Y, 8, 8);
        }
        /// <summary>
        /// Get the name of the sprite.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name + " - Sprite";
        }

        internal void SetPosition(Vector2 v)
        {
            position += v;
        }
    }

    [Serializable]
    public class AnimationAnchor : IGameData, IMovable
    {
        /// <summary>
        /// Name of the anchor.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name = "Anchor";

        [CategoryAttribute("Properties"), Description("A brief description for the use of this anchor")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;
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
        /// The unique id
        /// </summary>
        [Browsable(false)]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The Y position of the anchor.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        /// <summary>
        /// Get the rectangle of this.
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetRectangle()
        {
            return new System.Drawing.RectangleF(X, Y, Width, Height);
        }

        internal void SetOffSet(out float mouseOffx, out float mouseOffy, System.Drawing.PointF point)
        {
            mouseOffx = point.X - position.X;
            mouseOffy = point.Y - position.Y;
        }

        /// <summary>
        /// Get the name of the anchor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name + " - Anchor";
        }

        internal void SetPosition(Vector2 v)
        {
            position += v;
        }
    }

    [Serializable]
    public class AnimationParticle : IGameData
    {
        /// <summary>
        /// Name of the anchor.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;

        [CategoryAttribute("Properties"), Description("A brief description for the use of this anchor")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;
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
        /// The unique id
        /// </summary>
        [Browsable(false)]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The Y position of the anchor.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
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
        Vector2 size = new Vector2(16, 16);
        /// <summary>
        /// Gets or sets the width of the anchor.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        /// Get the rectangle of this.
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetRectangle()
        {
            return new System.Drawing.RectangleF(X, Y, Width, Height);
        }

        internal void SetOffSet(out float mouseOffx, out float mouseOffy, System.Drawing.PointF point)
        {
            mouseOffx = point.X - position.X;
            mouseOffy = point.Y - position.Y;
        }

        /// <summary>
        /// Get the name of the anchor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name + " - Anchor";
        }

        internal void SetPosition(Vector2 v)
        {
            position += v;
        }
    }

    [Serializable]
    public class PhysicsPin : IGameData
    {
        /// <summary>
        /// Name of the anchor.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;

        [CategoryAttribute("Properties"), Description("A brief description for the use of this anchor")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;
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
        /// The unique id
        /// </summary>
        [Browsable(false)]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The Y position of the anchor.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        [ContentSerializerIgnore, DoNotSerialize]
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
        float motorTorque = 100;

        public float MotorSpeed
        {
            get { return motorSpeed; }
            set { motorSpeed = value; }
        }
        float motorSpeed = 3;
        /// <summary>
        /// Get the rectangle of this.
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetRectangle()
        {
            return new System.Drawing.RectangleF(X, Y, Width, Height);
        }

        internal void SetOffSet(out float mouseOffx, out float mouseOffy, System.Drawing.PointF point)
        {
            mouseOffx = point.X - position.X;
            mouseOffy = point.Y - position.Y;
        }

        /// <summary>
        /// Get the name of the anchor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name + " - Anchor";
        }
    }

    [Serializable]
    public class RectangleV
    {
        public Vector2 TopLeft;
        public Vector2 TopRight;
        public Vector2 BottomLeft;
        public Vector2 BottomRight;

        public RectangleV()
        {
        }

        public RectangleV(Vector2 topLeft, Vector2 topRight, Vector2 bottomLeft, Vector2 bottomRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }

        public bool Contains(System.Drawing.PointF P)
        {
            try
            {
                return (TopLeft.X <= P.X && TopLeft.Y <= P.Y) &&
                       (TopRight.X >= P.X && TopRight.Y <= P.Y) &&
                       (BottomLeft.X <= P.X) && (BottomLeft.Y >= P.Y) &&
                       (BottomRight.X >= P.X) && (BottomRight.Y >= P.Y);
            }
            catch
            {
                return false;
            }
        }
    }
}
