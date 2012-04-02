//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Collision;
using Microsoft.Xna.Framework.Content;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics;
using FarseerPhysics.Common.PolygonManipulation;
using EGMGame.GameLibrary;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the map data.
    /// Includes layers, size, grid, and events.
    /// </summary>

    public class MapData : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// Holds the layers for the map.
        /// </summary>
        public List<LayerData> Layers;
        /// <summary>
        /// The size of the map.
        /// </summary>
        public Vector2 Size;
        /// <summary>
        /// Grid Size of the map. Pixels instead of rows and columns.
        /// </summary>
        public Vector2 Grid;

        public bool CustomGravity;

        public Vector2 Gravity;
        public bool EnableBGM;
        public bool EnableBGS;
        public bool EnableTint;
        public bool EnableFog;
        public EventProgramData BGM;
        public EventProgramData BGS;
        public EventProgramData Tint;
        public EventProgramData Fog;
    }

    public class TileData
    {
        public int TilesetID;
        /// <summary>
        /// Gets or sets the size of the tile.
        /// </summary>
        public int Width;
        public int Height;
        /// <summary>
        /// Gets or sets whether the tile will be flipped on the horizontal axis.
        /// </summary>
        public bool HorizontalFlip;
        /// <summary>
        /// Gets or sets whether the tile will be flipped on the vertical axis.
        /// </summary>
        public bool VerticalFlip;
        /// <summary>
        /// Gets or sets the opacity of the animation.
        /// </summary>
        public byte Opacity;
        /// <summary>
        /// Gets or sets the tile's tag.
        /// </summary>
        public ushort Tag;
        /// <summary>
        /// Is Platform tile?
        /// </summary>
        public bool IsPlatform;
        /// <summary>
        /// Height Pass
        /// </summary>
        public int HeightPass;
        /// <summary>
        /// Gets or sets whether the body is static or not.
        /// </summary>
        public float LinearDrag;
        public float RotationalDrag;
        public float Friction;
        public float Bounce;
        public float Mass;
        public bool SyncAngleToRotation;
        /// <summary>
        /// Displayed rectangle of the tile on the texture.
        /// </summary>
        public Rectangle DisplayRect;
        /// <summary>
        /// Position of the tile.
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// Gets or sets the tile's Scale which determines its size ratio.
        /// </summary>
        public Vector2 Scale;
        /// <summary>
        /// Gets or sets the tile's Rotation angle in degrees.
        /// </summary>
        public float Rotation;
        /// <summary>
        /// Gets or sets the body of the tile.
        /// </summary>
        public Vertices Body;
        /// <summary>
        /// Animation
        /// </summary>
        public List<int[]> Animation;
        [ContentSerializerIgnore, DoNotSerialize]
        public int AnimationIndex = -1;
        [ContentSerializerIgnore, DoNotSerialize]
        public int AnimationFrames = 0;
        /// <summary>
        /// Gets or sets whether the body is static or not.
        /// </summary>
        public bool IsStatic;
        public bool IgnoreGravity;
        public bool IsSensor;
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
        }
        [DoNotSerialize, ContentSerializerIgnore]
        public Vector2 offset;
        [DoNotSerialize, ContentSerializerIgnore]
        public Vector2 origin;
        [DoNotSerialize, ContentSerializerIgnore]
        public Body body;

        internal float GetRotation()
        {
            if (body != null)
                return body.Rotation;
            return MathHelper.ToRadians(Rotation);
        }

        internal Vector2 GetPosition()
        {
            if (body != null)
                return ConvertUnits.ToDisplayUnits(body.Position) - offset;
            return Position;
        }

    }
    /// <summary>
    /// Stores the layer data.
    /// Includes background and the tiles on the layer.
    /// </summary>
    public class LayerData : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// Determines whether if this layer is visible or not.
        /// </summary>
        public bool IsVisible;

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
        public Vector2 MoveSpeed;
        /// <summary>
        /// Gets or sets the tint of the layer.
        /// </summary>
        public ColorRGBA Tint;
        /// <summary>
        /// The events in the layer.
        /// </summary>
        public Dictionary<int, EventData> Events;

        public int ScrollType;

        public List<CollisionData> CollisionData;
    }
    /// <summary>
    /// Stores data for the dynamic background layer.
    /// </summary>

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
        /// Position of the background
        /// </summary>
        public Vector2 Size;
        /// <summary>
        /// Scale of the background
        /// </summary>
        public Vector2 Scale;
    }

    public enum FitType
    {
        Normal,
        ScreenStationary,
        ScaleToFitScreen,
        ScaleToFitMap,
        CenterScreen,
        CenterMap,
        Tiled,
        Parallax
    }
}
