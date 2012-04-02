//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    public class Project
    {
        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name;
        /// <summary>
        /// The path of the layout configaration of the project. Only releveant in the editor!
        /// </summary>
        public string LayoutConfig;
        /// <summary>
        /// The icon file name of the project. Only releveant in the editor!
        /// </summary>
        public string Icon;
        /// <summary>
        /// The description of the project.
        /// </summary>
        public string Description;
        /// <summary>
        /// Langauges
        /// </summary>
        public List<string> Languages;
        /// <summary>
        /// The target platform of the project.
        /// </summary>
        public TargetPlatform Platform;
        /// <summary>
        /// Battle Font - used for displaying damages.
        /// </summary>
        public int BattleFont;
        /// <summary>
        /// The size of the screen.
        /// </summary>
        public Vector2 ScreenRatio;
        /// <summary>
        /// The default pixel to show with movement and other calculations.
        /// </summary>
        public int DefaultPixel;
        /// <summary>
        /// Cursor Material
        /// </summary>
        public int CursorMaterial;
        /// <summary>
        /// The TTAP transparency
        /// </summary>
        public int TTAP_Transparency;
        /// <summary>
        /// The TTAP Radius
        /// </summary>
        public Vector2 TTAP_Radius;
        /// <summary>
        /// Transperent Tiles Above Player Enabled
        /// </summary>
        public bool TTAP_Enabled;
        /// <summary>
        /// The default data path. Always same.
        /// </summary>
        public string DataPath;
        /// <summary>
        /// The info on the maps used to load a map.
        /// </summary>
        public Dictionary<int, MapInfo> MapsInfo;
        /// <summary>
        /// Equipment Slots
        /// </summary>
        public Dictionary<int, string> EquipmentSlots;
        /// <summary>
        /// Elements
        /// </summary>
        public Dictionary<int, string> Elements;
        /// <summary>
        /// The initial screen's type.
        /// 0 - Menu
        /// 1 - Scene
        /// </summary>
        public int InitialSceneType;
        /// <summary>
        /// The ID of the first scene to show.
        /// </summary>
        public int InitialSceneID;
        /// <summary>
        /// The categories
        /// </summary>
        public Dictionary<string, List<NodeCategory>> Categories;
        /// <summary>
        /// Stores the game data.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public GameData GameData;


        #region User Preferences
        public Vector2 DefaultGridSize;
        public bool DisplayGrid;
        public bool SnapToGrid;
        public bool DimLayers;
        public bool EventView;
        public Vector2 MenuGrid;
        public int SelectedTileset;
        public int SelectedMap;
        public int SelectedLayer;
        public BrushType BrushType;
        public float TilesetZoom;
        #endregion

        #region Physics
        public bool StartFullScreen;
        public Vector2 Gravity;
        public float Mass;
        public float Force;
        public float LinearDrag;
        public float RotationalDrag;
        public float Friction;
        public float Bounce;
        public float Impulse;
        #endregion

        #region Other
        public int DeathState;
        public int Gold;
        public decimal SpriteRows;
        public decimal SpriteCols;
        public decimal SpriteFrames;
        public List<object> SpriteDirections;
        #endregion
    }
    public enum TargetPlatform
    {
        Windows = 0,
        Xbox = 1,
        Silverlight = 2
    }

    public enum PaintType
    {
        Cursor,
        Pencil,
        Eraser
    }
    public enum BrushType
    {
        Brush,
        Line,
        Rectangle,
        Fill,
        EraserBrush,
        EraserRect,
        EraserFill,
        CursorSingle,
        CursorMulti,
        CursorMultiLayer,
        LayerSelection,
        EventSelection
    }
    
    public class NodeCategory
    {
        public NodeCategory()
        {
        }

        public NodeCategory(string n)
        {
            name = n;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name = "Default";

        public bool Expand
        {
            get { return expand; }
            set { expand = value; }
        }
        bool expand = true;
    }
}
