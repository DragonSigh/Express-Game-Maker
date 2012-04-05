//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using EGMGame.Library.Interface;
using FarseerPhysics.Collisions;
using Microsoft.Xna.Framework.Content;
using EGMGame.GameLibrary;
using FarseerPhysics.Common;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the map data.
    /// Includes layers, Size, grid, and events.
    /// </summary>
    [Serializable]
    public class MapData : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// Holds the layers for the map.
        /// </summary>
        public List<LayerData> Layers = new List<LayerData>();
        /// <summary>
        /// The size of the map.
        /// </summary>
        public Vector2 Size = new Vector2(640, 640);
        /// <summary>
        /// Grid Size of the map. Pixels instead of rows and columns.
        /// </summary>
        public Vector2 Grid = new Vector2(32, 32);


        public bool CustomGravity = false;
        public Vector2 Gravity = Vector2.Zero;
        public bool EnableBGM;
        public bool EnableBGS;
        public bool EnableTint;
        public bool EnableFog;
        public EventProgramData BGM;
        public EventProgramData BGS;
        public EventProgramData Tint;
        public EventProgramData Fog;
    }

    [Serializable]
    public class TileData
    {
        [Browsable(false)]
        public int TilesetID { get; set; }
        /// <summary>
        /// Gets or sets the size of the tile.
        /// </summary>
        [Browsable(false)]
        public int Width { get; set; }
        [Browsable(false)]
        public int Height { get; set; }
        /// <summary>
        /// Gets or sets whether the tile will be flipped on the horizontal axis.
        /// </summary>
        [DisplayName("Horizontal Flip"), CategoryAttribute("Image"), Description("Determines whether the tile will be flipped on the horizontal axis.")]
        public bool HorizontalFlip { get; set; }
        /// <summary>
        /// Gets or sets whether the tile will be flipped on the vertical axis.
        /// </summary>
        [DisplayName("Vertical Flip"), CategoryAttribute("Image"), Description("Determines whether the tile will be flipped on the vertical axis.")]
        public bool VerticalFlip { get; set; }
        /// <summary>
        /// Gets or sets the opacity of the animation.
        /// </summary>
        [CategoryAttribute("Image"), Description("The tile's opacity."), DefaultValue((byte)255)]
        public byte Opacity { get; set; }
        /// <summary>
        /// Gets or sets the tile's tag.
        /// </summary>
        public ushort Tag { get; set; }
        /// <summary>
        /// Is Platform tile?
        /// </summary>
        public bool IsPlatform { get; set; }
        /// <summary>
        /// Height Pass
        /// </summary>
        [DisplayName("Height"), Description("The Z-height of the tile. Used mainly by projectiles.")]
        public int HeightPass { get; set; }
        [Category("Physics")]
        public float LinearDrag { get; set; }
        [Category("Physics")]
        public float RotationalDrag { get; set; }
        [Category("Physics")]
        public float Friction { get; set; }
        [Category("Physics")]
        public float Bounce { get; set; }
        [Category("Physics")]
        public float Mass { get; set; }
        [Category("Physics")]
        public bool SyncAngleToRotation { get; set; }
        /// <summary>
        /// Displayed rectangle of the tile on the texture.
        /// </summary>
        [Browsable(false)]
        public Rectangle DisplayRect { get; set; }
        /// <summary>
        /// Position of the tile.
        /// </summary>
        [Browsable(false)]
        public Vector2 Position { get; set; }
        /// <summary>
        /// Gets or sets the tile's Scale which determines its size ratio.
        /// </summary>
        [CategoryAttribute("Image"), Description("The tile's Scale which determines its size ratio.")]
        public Vector2 Scale { get; set; }
        /// <summary>
        /// Gets or sets the tile's Rotation angle in degrees.
        /// </summary>
        [CategoryAttribute("Image"), Description("The tile's Rotation angle in degrees.")]
        public float Rotation { get; set; }
        /// <summary>
        /// Gets or sets the body of the tile.
        /// </summary>
        [Browsable(false)]
        public Vertices Body { get; set; }
        /// <summary>
        /// Animation
        /// </summary>
        [CategoryAttribute("Behavior"), Description("Animate the tile by linking it with other tiles.")]
        [Editor(typeof(AnimationTileConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<int[]> Animation { get; set; }
        /// <summary>
        /// Gets or sets whether the body is static or not.
        /// </summary>
        [Category("Physics")]
        public bool IsStatic { get; set; }
        [Category("Physics")]
        public bool IgnoreGravity { get; set; }
        /// <summary>
        /// Gets or sets whether the body is static or not.
        /// </summary>
        [Browsable(false)]
        public bool IsSensor { get; set; }



        [Browsable(false)]
        [ContentSerializerIgnore, DoNotSerialize]
        public int AutotileID { get; set; }

        [Browsable(false)]
        [ContentSerializerIgnore, DoNotSerialize]
        public AutotileType AutotileType { get; set; }

        #region Methods
        /// <summary>
        /// Clone the tile.
        /// </summary>
        /// <returns></returns>
        internal TileData Clone()
        {
            TileData tile = new TileData();
            tile.HorizontalFlip = this.HorizontalFlip;
            tile.Opacity = this.Opacity;
            tile.Position = this.Position;
            tile.Rotation = this.Rotation;
            tile.Scale = this.Scale;
            tile.Width = this.Width;
            tile.Height = this.Height;
            tile.DisplayRect = this.DisplayRect;
            tile.TilesetID = this.TilesetID;
            tile.VerticalFlip = this.VerticalFlip;
            tile.Body = this.Body;
            tile.IsSensor = this.IsSensor;
            tile.IsStatic = this.IsStatic;
            tile.Tag = this.Tag;
            tile.HeightPass = this.HeightPass;
            tile.LinearDrag = this.LinearDrag;
            tile.RotationalDrag = this.RotationalDrag;
            tile.Friction = this.Friction;
            tile.Bounce = this.Bounce;
            tile.Mass = this.Mass;
            tile.SyncAngleToRotation = this.SyncAngleToRotation;
            tile.SetRectangle();
            return tile;
        }
        /// <summary>
        /// Convert tile to the given tile.
        /// </summary>
        /// <param name="tile"></param>
        internal void Convert(TileData tile)
        {
            this.HorizontalFlip = tile.HorizontalFlip;
            this.Opacity = tile.Opacity;
            this.Position = tile.Position;
            this.Rotation = tile.Rotation;
            this.Scale = tile.Scale;
            this.Width = tile.Width;
            this.Height = tile.Height;
            this.DisplayRect = tile.DisplayRect;
            this.TilesetID = tile.TilesetID;
            this.VerticalFlip = tile.VerticalFlip;
            this.Body = tile.Body;
            this.IsSensor = tile.IsSensor;
            this.IsStatic = tile.IsStatic;
            this.Tag = tile.Tag;
            this.HeightPass = tile.HeightPass;
            this.HeightPass = tile.HeightPass;
            this.LinearDrag = tile.LinearDrag;
            this.RotationalDrag = tile.RotationalDrag;
            this.Friction = tile.Friction;
            this.Bounce = tile.Bounce;
            this.Mass = tile.Mass;
            this.SyncAngleToRotation = tile.SyncAngleToRotation;
            this.SetRectangle();
        }
        /// <summary>
        /// Get System Rectangle
        /// </summary>
        /// <returns></returns>
        [ContentSerializerIgnore, DoNotSerialize, NonSerialized]
        internal System.Drawing.RectangleF RectangleF;
        [ContentSerializerIgnore, DoNotSerialize, NonSerialized]
        internal Rectangle Rectangle;


        internal void SetRectangle()
        {
            RectangleF = new System.Drawing.RectangleF(Position.X - (Width / 2) * Scale.X, Position.Y - (Height / 2) * Scale.Y, DisplayRect.Width * Scale.X + 2, DisplayRect.Height * Scale.Y + 2);
            Rectangle = new Rectangle((int)(Position.X - (Width / 2) * Scale.X), (int)(Position.Y - (Height / 2) * Scale.Y), (int)(DisplayRect.Width * Scale.X + 2), (int)(DisplayRect.Height * Scale.Y + 2));
        }
        /// <summary>
        /// Sets the mouse offset with the in tile DisplayRect.
        /// </summary>
        /// <param name="mouseOffx"></param>
        /// <param name="mouseOffy"></param>
        /// <param name="point"></param>
        internal void SetOffSet(out float mouseOffx, out float mouseOffy, Vector2 point)
        {
            mouseOffx = point.X - Position.X;
            mouseOffy = point.Y - Position.Y;
        }
        /// <summary>
        /// Get the Top Left Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetTopLeft()
        {
            Vector2 center = new Vector2(Position.X - (Width / 8), Position.Y - (Height / 8));
            Vector2 pos = Position;
            pos.X += 12;
            pos.Y -= 4;
            return new System.Drawing.RectangleF(ExMath.rotatePoint(center, pos, Rotation).X + 4, ExMath.rotatePoint(center, pos, Rotation).Y, 8, 8);
        }
        /// <summary>
        /// Get the bottom right Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetBottomRight()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Width / 2) + 4, Position.Y - (Height / 2) + 4);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Width / 2) * Scale.X + DisplayRect.Width * Scale.X - 4, Position.Y - (Height / 2) * Scale.Y - 4 + DisplayRect.Height * Scale.Y), 0);
            return new System.Drawing.RectangleF(p.X, p.Y, 8, 8);
        }
        /// <summary>
        /// Get the Top Right Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetTopRight()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Width / 2) + 4, Position.Y - (Height / 2) + 4);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Width / 2) * Scale.X + DisplayRect.Width * Scale.X + 4, Position.Y - (Height / 2) * Scale.Y - 4), 0);
            return new System.Drawing.RectangleF(p.X, p.Y, 8, 8);
        }
        /// <summary>
        /// Get the Top Right Handle Grip in XNA coordinates.
        /// </summary>
        /// <returns></returns>
        internal Rectangle GetTopRightX()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Width / 2) - 4, Position.Y - (Height / 2) - 4);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Width / 2) * Scale.X + DisplayRect.Width * Scale.X + 4, Position.Y - (Height / 2) * Scale.Y - 4), 0);
            return new Rectangle((int)p.X, (int)p.Y, 8, 8);
        }
        /// <summary>
        /// Gets the Scaled System Rectangle
        /// </summary>
        /// <returns></returns>
        public System.Drawing.RectangleF GetScaledRectangle(float zoom)
        {
            return new System.Drawing.RectangleF(Position.X - (Width / 2) * Scale.X, Position.Y - (Height / 2) * Scale.Y, DisplayRect.Width * Scale.X + 4, DisplayRect.Height * Scale.Y + 4);
        }

        internal Vector2 GetMiddleRight()
        {
            Vector2 center = new Vector2(Position.X - (Width / 8), Position.Y - (Height / 8));
            Vector2 pos = Position;
            pos.X += 12;
            pos.Y -= 4;
            return new Vector2(ExMath.rotatePoint(center, pos, Rotation).X + 4, ExMath.rotatePoint(center, pos, Rotation).Y + 4);
        }

        internal Vector2 GetMiddleCenter()
        {
            return Position;
        }

        /// <summary>
        /// Get the Top Left Handle Grip.
        /// </summary>
        /// <returns></returns>
        internal System.Drawing.RectangleF GetMiddleLeft()
        {
            return new System.Drawing.RectangleF(Position.X - 4, Position.Y - 4, 8, 8);
        }
        #endregion
    }
    /// <summary>
    /// Stores the layer data.
    /// Includes background and the tiles on the layer.
    /// </summary>
    [Serializable]
    public class LayerData : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// Determines whether if this layer is visible or not.
        /// </summary>
        public bool IsVisible = true;

        /// <summary>
        /// The tiles in the layer.
        /// </summary>
        public List<TileData> Tiles;
        /// <summary>
        /// The background of the layer.
        /// </summary>
        public List<LayerBackground> Backgrounds = new List<LayerBackground>();
        /// <summary>
        /// Gets or sets the movement speed of the layer in relevalance to the camera.
        /// Good for sidescrollers to create a distance effect.
        /// </summary>
        public Vector2 MoveSpeed = Vector2.Zero;
        /// <summary>
        /// Gets or sets the tint of the layer.
        /// </summary>
        public ColorRGBA Tint = new ColorRGBA(Color.White);
        /// <summary>
        /// The events in the layer.
        /// </summary>
        public Dictionary<int, EventData> Events = new Dictionary<int, EventData>();

        public int ScrollType;

        [ContentSerializerIgnore]
        public List<CollisionData> CollisionData = new List<CollisionData>();
    }
    /// <summary>
    /// Stores data for the dynamic background layer.
    /// </summary>
    [Serializable]
    public class LayerBackground
    {
        /// <summary>
        /// The material id is used to reference a materail in materials list.
        /// </summary>
        public int MaterialId;
        /// <summary>
        /// Gets or sets the rotation of the background.
        /// </summary>
        public float Rotation;
        /// <summary>
        /// Position of the background
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// Size of the background
        /// </summary>
        public Vector2 Size;
        /// <summary>
        /// Scale of the background
        /// </summary>
        public Vector2 Scale = new Vector2(1, 1);

        internal System.Drawing.RectangleF GetTopRight()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Size.X / 2) + 4, Position.Y - (Size.Y / 2) + 4);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Size.X / 2) + Size.X + 4, Position.Y - (Size.Y / 2) - 4), 0);
            return new System.Drawing.RectangleF(p.X, p.Y, 8, 8);
        }

        internal System.Drawing.RectangleF GetTopLeft()
        {
            Vector2 center = new Vector2(Position.X - (Size.X / 8), Position.Y - (Size.Y / 8));
            Vector2 pos = Position;
            pos.X += 12;
            pos.Y -= 4;
            return new System.Drawing.RectangleF(ExMath.rotatePoint(center, pos, Rotation).X + 4, ExMath.rotatePoint(center, pos, Rotation).Y, 8, 8);
        }

        internal void SetOffSet(out float mouseOffx, out float mouseOffy, Vector2 point)
        {
            mouseOffx = point.X - Position.X;
            mouseOffy = point.Y - Position.Y;
        }

        internal System.Drawing.RectangleF GetBottomRight()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Size.X / 2) + 8, Position.Y - (Size.Y / 2) + 8);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Size.X / 2) * Scale.X - 8, Position.Y - (Size.Y / 2) * Scale.Y - 8), 0);
            return new System.Drawing.RectangleF(p.X, p.Y, 16, 16);
        }

        internal System.Drawing.RectangleF GetBottomLeft()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Size.X / 2) + 8, Position.Y - (Size.Y / 2) + 8);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Size.X / 2) - 8, Position.Y - (Size.Y / 2) - 8 + Size.Y), Rotation);
            return new System.Drawing.RectangleF(p.X, p.Y, 16, 16);
        }
        internal System.Drawing.RectangleF GetUpperLeft()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Size.X / 2) + 8, Position.Y - (Size.Y / 2) + 8);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Size.X / 2) - 8, Position.Y - (Size.Y / 2) - 8), Rotation);
            return new System.Drawing.RectangleF(p.X, p.Y, 16, 16);
        }

        internal System.Drawing.RectangleF GetUpperRight()
        {
            Vector2 center, p;
            center = new Vector2(Position.X - (Size.X / 2) + 8, Position.Y - (Size.Y / 2) + 8);
            p = ExMath.rotatePoint(center, new Vector2(Position.X - (Size.X / 2) + Size.X - 8, Position.Y - (Size.Y / 2) - 8), Rotation);
            return new System.Drawing.RectangleF(p.X, p.Y, 16, 16);
        }

    }

    public enum FitType
    {
        Screen,
        Scroll,
        AutoScroll
    }
}
