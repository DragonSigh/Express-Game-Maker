//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the tileset data.
    /// Includes the texture's material ID and the tiles' data.
    /// </summary>
    
    public class TilesetData : IGameData
    {
        /// <summary>
        /// Name of the tileset.
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

        public List<TileData> Tiles;
        public Vector2 Grid;
        public int Rows;
        public int Columns;
        public int MaterialId;
        /// <summary>
        /// Autotiles
        /// </summary>
        public List<AutoTileData> Autotiles = new List<AutoTileData>();
    }

    
    public class AutoTileData : IGameData
    {
        /// <summary>
        /// Name of the tileset.
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

        public int[] TileIndex = new int[] 
        {
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1,
            -1
        };
    }
    public enum AutotileType
    {
        Center,
        Top,
        Bottom,
        Left,
        Right,
        UpperLeft,
        UpperRight,
        LowerLeft,
        LowerRight,
        UpperLeftCorner,
        UpperRightCorner,
        LowerLeftCorner,
        LowerRigthCorner
    }
}
