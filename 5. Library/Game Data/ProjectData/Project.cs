using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using System.ComponentModel;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using EGMGame.Controls;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    [Serializable]
    public class Project
    {
        [ContentSerializerIgnore, DoNotSerialize]
        public string Version = "0";
        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The path of the of the project. Only relevant in the editor!
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        string location;
        /// <summary>
        /// The full path of the project. Only relevant in the editor!
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        public string FullLocation
        {
            get { return location + @"\Project" + Extensions.Project; }
        }
        /// <summary>
        /// The path of the layout configaration of the project. Only releveant in the editor!
        /// </summary>
        public string LayoutConfig
        {
            get { return layoutConfig; }
            set { layoutConfig = value; }
        }
        string layoutConfig;
        /// <summary>
        /// The icon file name of the project. Only releveant in the editor!
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        string icon = "Game.ico";
        /// <summary>
        /// The description of the project.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string description;
        /// <summary>
        /// Langauges
        /// </summary>
        public List<string> Languages
        {
            get { return languages; }
            set { languages = value; }
        }
        List<string> languages = new List<string>() { "English" };
        /// <summary>
        /// The target platform of the project.
        /// </summary>
        public TargetPlatform Platform
        {
            get { return platform; }
            set { platform = value; }
        }
        TargetPlatform platform = TargetPlatform.Windows;
        /// <summary>
        /// Battle Font - used for displaying damages.
        /// </summary>
        public int BattleFont
        {
            get { return battleFont; }
            set { battleFont = value; }
        }
        int battleFont = 0;
        /// <summary>
        /// The size of the screen.
        /// </summary>
        public Vector2 ScreenRatio
        {
            get { return screenRatio; }
            set { screenRatio = value; }
        }
        Vector2 screenRatio = new Vector2(1280, 720);
        /// <summary>
        /// Start Full Screen
        /// </summary>
        public bool StartFullScreen = false;
        /// <summary>
        /// The default pixel to show with movement and other calculations.
        /// </summary>
        public int DefaultPixel
        {
            get { return defaultPixel; }
            set { defaultPixel = value; }
        }
        int defaultPixel = 64;
        /// <summary>
        /// Cursor Material
        /// </summary>
        public int CursorMaterial
        {
            get { return cursorMaterial; }
            set { cursorMaterial = value; }
        }
        int cursorMaterial = -1;
        /// <summary>
        /// The TTAP transparency
        /// </summary>
        public int TTAP_Transparency
        {
            get { return ttap_trans; }
            set { ttap_trans = value; }
        }
        int ttap_trans = 100;
        /// <summary>
        /// The TTAP Radius
        /// </summary>
        public Vector2 TTAP_Radius
        {
            get { return ttap_rad; }
            set { ttap_rad = value; }
        }
        Vector2 ttap_rad = new Vector2(64, 0);
        /// <summary>
        /// Transperent Tiles Above Player Enabled
        /// </summary>
        public bool TTAP_Enabled
        {
            get { return ttap_enabled; }
            set { ttap_enabled = value; }
        }
        bool ttap_enabled = true;
        /// <summary>
        /// Stores the game data.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public GameData GameData
        {
            get { return projectData; }
            set { projectData = value; }
        }
        GameData projectData = new GameData();
        /// <summary>
        /// The paths of sourcefiles.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public List<SourceFile> SourceFiles
        {
            get { return sourceFiles; }
            set { sourceFiles = value; }
        }
        List<SourceFile> sourceFiles = new List<SourceFile>();
        /// <summary>
        /// The default data path. Always same.
        /// </summary>
        public string DataPath
        {
            get { return datapath; }
            set { datapath = value; }
        }
        string datapath;
        /// <summary>
        /// The info on the maps used to load a map.
        /// </summary>
        public Dictionary<int, MapInfo> MapsInfo
        {
            get { return mapsInfo; }
            set { mapsInfo = value; }
        }
        Dictionary<int, MapInfo> mapsInfo = new Dictionary<int, MapInfo>();
        /// <summary>
        /// Equipment Slots
        /// </summary>
        public Dictionary<int, string> EquipmentSlots
        {
            get { return equipmentSlots; }
            set { equipmentSlots = value; }
        }
        Dictionary<int, string> equipmentSlots = new Dictionary<int, string>();
        /// <summary>
        /// Elements
        /// </summary>
        public Dictionary<int, string> Elements
        {
            get { return elements; }
            set { elements = value; }
        }
        Dictionary<int, string> elements = new Dictionary<int, string>();
        /// <summary>
        /// The initial screen's type.
        /// 0 - Menu
        /// 1 - Scene
        /// </summary>
        public int InitialSceneType
        {
            get { return initialSceneType; }
            set { initialSceneType = value; }
        }
        int initialSceneType = 1;
        /// <summary>
        /// The ID of the first scene to show.
        /// </summary>
        public int InitialSceneID
        {
            get { return initialSceneID; }
            set { initialSceneID = value; }
        }
        int initialSceneID = -1;
        /// <summary>
        /// The categories
        /// </summary>
        public Dictionary<string, List<NodeCategory>> Categories
        {
            get { return categories; }
            set { categories = value; }
        }
        Dictionary<string, List<NodeCategory>> categories = new Dictionary<string, List<NodeCategory>>();

        #region Physics
        public Vector2 Gravity = new Vector2(0, 0);
        public float Mass = 1f;
        public float Force = 1f;
        public float LinearDrag = 7.0f;
        public float RotationalDrag = 1.0f;
        public float Friction;
        public float Bounce;
        public float Impulse = 1f;
        #endregion

        #region Other
        public int DeathState = -1;
        public int Gold;
        #endregion

        #region User Preferences

        public decimal SpriteRows = 4;

        public decimal SpriteCols = 4;

        public decimal SpriteFrames = 8;

        public List<object> SpriteDirections = new List<object>()
        {
           "Up",
           "Down",
           "Left",
           "Right",
           "Up/Left",
           "Up/Right",
           "Down/Lef",
           "Down/Right"
        };

        public Vector2 DefaultGridSize
        {
            get { return defaultGrid; }
            set { defaultGrid = value; }
        }
        Vector2 defaultGrid = new Vector2(64, 64);
        public bool DisplayGrid
        {
            get { return displayGrid; }
            set { displayGrid = value; }
        }
        bool displayGrid = true;
        public bool SnapToGrid
        {
            get { return snapToGrid; }
            set { snapToGrid = value; }
        }
        bool snapToGrid = true;
        public bool DimLayers
        {
            get { return dimLayers; }
            set { dimLayers = value; }
        }
        bool dimLayers = true;
        public bool EventView
        {
            get { return eventView; }
            set { eventView = value; }
        }
        bool eventView = false;
        public Vector2 MenuGrid
        {
            get { return menuGrid; }
            set { menuGrid = value; }
        }
        Vector2 menuGrid = new Vector2(16, 16);
        public int SelectedTileset
        {
            get { return selectedTileset; }
            set { selectedTileset = value; }
        }
        int selectedTileset = 0;
        public int SelectedMap
        {
            get { return selectedMap; }
            set { selectedMap = value; }
        }
        int selectedMap = 0;
        public int SelectedLayer
        {
            get { return selectedLayer; }
            set { selectedLayer = value; }
        }
        int selectedLayer = 0;

        public BrushType BrushType
        {
            get { return brushType; }
            set { brushType = value; }
        }
        BrushType brushType = BrushType.Brush;

        public float TilesetZoom
        {
            get { return tilesetZoom; }
            set { tilesetZoom = value; }
        }
        float tilesetZoom = 1f;

        #endregion
    }

    #region Enums
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
    #endregion

    [Serializable]
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

    [Serializable]
    public class SourceFile
    {
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        string path;

        public SourceFile()
        {
        }

        public SourceFile(string p)
        {
            path = p;
        }

    }

    public enum TargetPlatform
    {
        Windows = 0,
        Xbox = 1,
        Silverlight = 2
    }
}
