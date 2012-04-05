//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the tileset data.
    /// Includes the texture's material ID and the tiles' data.
    /// </summary>
    [Serializable]
    public class TilesetData : IGameData
    {
        /// <summary>
        /// Name of the tileset.
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
        /// The tiles which hold the tile data of the tileset.
        /// </summary>
        public List<TileData> Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }
        List<TileData> tiles = new List<TileData>();
        /// <summary>
        /// The number of rows and colums the grid should be drawn to.
        /// Calculation is done by dividing the size of the texture by the grid.
        /// </summary>
        public Vector2 Grid
        {
            get { return grid; }
            set { grid = value; }
        }
        Vector2 grid = new Vector2(1, 1);
        /// <summary>
        /// Number of rows
        /// </summary>
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        int rows;
        /// <summary>
        /// Number of columns
        /// </summary>
        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        /// <summary>
        /// The material id is used to reference a materail in materials list.
        /// </summary>
        public int MaterialId
        {
            get { return materialId; }
            set { materialId = value; }
        }
        int materialId = -1;
        /// <summary>
        /// Autotiles
        /// </summary>
        public List<AutoTileData> Autotiles = new List<AutoTileData>();
    }


    [Serializable]
    public class AutoTileData : IGameData
    {
        /// <summary>
        /// Name of the tileset.
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
