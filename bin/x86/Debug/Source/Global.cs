using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using EGMGame.Processors;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using FarseerPhysics;
using FarseerPhysics.Collision;
using Microsoft.Xna.Framework.Storage;
using System.Xml.Serialization;
using EGMGame.Interfaces;
using Microsoft.Xna.Framework.Audio;
using FarseerPhysics.Dynamics;
using FarseerPhysics;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores data that can be accessed from anywhere in the project.
    /// </summary>

    public partial class Global
    {
        /// <summary>
        /// Stores an instance of the Global class.
        /// This class is Saved and Loaded.
        /// </summary>
        public static Global Instance = new Global();
        /// <summary>
        /// Stores the game for easy access.
        /// </summary>
        public static Game Game;

        #region Fields
        /// <summary>
        /// Global Spritebatch
        /// </summary>
        public static SpriteBatch SpriteBatch;
        /// <summary>
        /// Thread Manager
        /// </summary>
        public static ThreadManager ThreadsManager;
        /// <summary>
        /// Storage Device Manager
        /// </summary>
        public static StorageDeviceManager StorageDeviceManager;
        /// <summary>
        /// The storage device
        /// </summary>
        public static StorageDevice Storage;
        /// <summary>
        /// Stores the assembly data so it can be re-accessed when needed.
        /// </summary>
        public static Assembly Assembly;
        /// <summary>
        /// Used to calculate how much of an error should be displayed.
        /// 0 - "An error has occured."
        /// 1 - "[ErrorMessage]"
        /// 2 - "[ErrorMessaeg] [Source]"
        /// 3 - "[ErrorMessaeg] [Source] [Statck]"
        /// </summary>
        public static sbyte ErrorLevel = 3;
        /// <summary>
        /// Stores the loaded project.
        /// </summary>
        public static Project Project;
        /// <summary>
        /// Particles Effect
        /// </summary>
        public static Effect ParticlesEffect;
        public static EffectPool ParticlesEffectPool;
        /// <summary>
        /// A cache of sound effect instances to avoid the sound effect intance limit.
        /// </summary>
        public static Dictionary<int, Queue<SoundEffectInstance>> SoundEffectInstaces = new Dictionary<int, Queue<SoundEffectInstance>>();
        /// <summary>
        /// Resolution Independent
        /// </summary>
        public bool ResolutionIndependent = true;
        /// <summary>
        /// Locks the screen. To unlock, set values to 0,0,0,0.
        /// </summary>
        public Rectangle LockScreen = new Rectangle(0, 0, 0, 0);
        /// Stores the game data for easy access and to allow for saving and loading.
        public Dictionary<int, VariableData> Variables;
        public Dictionary<int, StringData> Strings;
        public Dictionary<int, SwitchData> Switches;
        public Dictionary<int, ListData> Lists;
        public Dictionary<int, Dictionary<int, bool>>[] EventSwitches = new Dictionary<int, Dictionary<int, bool>>[5];
        /// <summary>
        /// Stores the game data.
        /// </summary>
        public int HitCount;
        /// <summary>
        /// Stores the game data.
        /// </summary>
        public int LastExpGained;
        /// <summary>
        /// Stores the game data.
        /// </summary>
        public int TotalExpGained;
        /// <summary>
        /// Stores the active camera.
        /// </summary>
        public Camera ActiveCamera;
        /// <summary>
        /// Stores the current map.
        /// </summary>
        public MapProcessor CurrentMap;
        /// <summary>
        /// Reload Map
        /// </summary>
        public static bool ReloadMap;
        /// <summary>
        /// Stores the current menu
        /// </summary>
        public static MenuProcessor CurrentMenu;
        /// <summary>
        /// Stores the ID of the current HUD.
        /// HUDs auto-display when game reloads or scenes change.
        /// </summary>
        public int CurrentHUD = -1;
        /// <summary>
        /// Stores the player variable
        /// </summary>
        public List<EventProcessor> Player = new List<EventProcessor>();
        /// <summary>
        /// Stores the skill hotkeys
        /// </summary>
        public List<Hotkey> SkillKeys;
        /// <summary>
        /// Stores the item hotkeys
        /// </summary>
        public List<Hotkey> ItemKeys;
        /// <summary>
        /// Stores the global events
        /// </summary>
        public List<GlobalEventProcessor> GlobalEvents = new List<GlobalEventProcessor>();
        /// <summary>
        /// Stores the heroes that have been created
        /// </summary>
        public Dictionary<int, HeroProcessor> Heroes = new Dictionary<int, HeroProcessor>();
        /// <summary>
        /// Stores the party processor
        /// </summary>
        public PartyProcessor Party = new PartyProcessor();
        /// <summary>
        /// Picture Processor
        /// </summary>
        public PictureProcessor[] Pictures = new PictureProcessor[101];
        /// <summary>
        /// Particle Processor
        /// </summary>
        public Dictionary<int, ParticleSystemProcessor> Particles = new Dictionary<int, ParticleSystemProcessor>();
        /// <summary>
        /// Weather Processor
        /// </summary>
        public WeatherProcessor Weather;
        /// <summary>
        /// Global Effect processors
        /// </summary>
        public EffectProcessor[] TintScreen = new EffectProcessor[] 
        {
            new EffectProcessor(EffectType.Tint, ScreenType.Global, Color.Transparent, 0, Color.Transparent),   
            new EffectProcessor(EffectType.Tint, ScreenType.Gameplay, Color.Transparent, 0, Color.Transparent),   
            new EffectProcessor(EffectType.Tint, ScreenType.Menu, Color.Transparent, 0, Color.Transparent)          
        };
        public bool IsLastTintGlobal = false;

        public EffectProcessor[] FlashScreen = new EffectProcessor[3];

        public EffectProcessor[] ShakeScreen = new EffectProcessor[3];

        [XmlIgnore, DoNotSerialize]
        public List<EffectProcessor>[] TextScreen = new List<EffectProcessor>[]
        {
            new List<EffectProcessor>(),
            new List<EffectProcessor>(),
            new List<EffectProcessor>()
        };

        /// <summary>
        /// Animations Stack
        /// </summary>
        public List<EffectProcessor> ScreenAnimations = new List<EffectProcessor>();
        /// <summary>
        /// Flash Que to draw
        /// </summary>
        public List<EffectProcessor> FlashQue = new List<EffectProcessor>();
        /// <summary>
        /// If the autorun id is set to an event id, only that event will run 
        /// </summary>
        public int AutorunID = -1;
        /// <summary>
        /// If the autorun id is set to an global event id, only that event will run 
        /// </summary>
        public int GlobalAutorunID = -1;
        /// <summary>
        /// Locks player controls and event.
        /// EventProcessor = 0
        /// GlobalEventProcessor = 1
        /// {0 || 1, Event ID}
        /// </summary>
        public int[] LockPlayer = new int[] { 0, -1 };
        /// <summary>
        /// The id of the map that needs to be load.
        /// </summary>
        public static int MapToLoad = -1;
        /// <summary>
        /// The id of the menu that needs to be load.
        /// </summary>
        public static int MenuToLoad = -1;
        /// <summary>
        /// Stores the game's content manager.
        /// </summary>
        public static ContentManager ContentManager;
        /// <summary>
        /// Stores the game's audio manager.
        /// Manages all audio in game.
        /// </summary>
        public AudioManager AudioManager = new AudioManager();
        /// <summary>
        /// Stores the games physics simulator.
        /// Farseer physics is mainly used to detect collision rather then actual
        /// physics calculations.
        /// </summary>
        public static World World;
        /// <summary>
        /// Event Unique ID count
        /// </summary>
        public int EventUniqueIDCount = 0;
        /// <summary>
        /// Menu Unique ID count
        /// </summary>
        public int MenuUniqueIDCount = 0;
        /// <summary>
        /// Indicates how long the screen takes to
        /// transition on when it is activated.
        /// </summary>
        public int TransitionOnTime = 0;
        /// <summary>
        /// Indicates how long the screen takes to
        /// transition off when it is deactivated.
        /// </summary>
        public int TransitionOffTime = 0;
        // 0 - Opaque 1 - Transperent/// <summary>
        /// Stores the fade/tint color.
        /// </summary>
        public Color FadeColor = Color.Black;
        public Color FadeToColor = Color.Black;
        /// <summary>
        /// Fadeout
        /// </summary>
        public bool FadingOut;
        /// Fog settings
        public int FogMaterialID = -1;
        public Color FogColor;
        public float FogSpeed;
        public float FogPosition;
        // Timers
        public Dictionary<int, Timer> Timers;
        /// <summary>
        /// Layer Background Offset
        /// </summary>
        public Vector2[] LayerBackroundOffset;
        /// <summary>
        /// Gets the current screen transition state.
        /// </summary>
        public ScreenState ScreenState = ScreenState.Active;
        /// <summary>
        /// Shows the collision mapping on the screen for each object if set to true.
        /// </summary>
        public static bool ShowCollisionMapping = false;
        /// <summary>
        /// Transfer Player Settings
        /// </summary>
        public static bool TransferPlayer = false;
        public static int TransferMapID;
        public static int TransferX;
        public static int TransferY;
        /// <summary>
        /// The video player
        /// </summary>
#if !SILVERLIGHT
        public static VideoProcessor VideoPlayer = new VideoProcessor();
#endif
        /// <summary>
        /// The PauseAction determines if and why the game is paused.
        /// </summary>
        public PauseAction Pause = PauseAction.None;
        /// <summary>
        /// Tinting Picture
        /// </summary>
        public bool TintingPicture = false;
        /// <summary>
        /// Alpha Blend Mode
        /// </summary>
        public static BlendState BlendMode = BlendState.NonPremultiplied;
        /// <summary>
        /// Cursor
        /// </summary>
        public int CursorMaterial;
        /// <summary>
        /// Menu Options
        /// </summary>
        public List<object> MenuOptions = new List<object>();
        /// <summary>
        /// Messages
        /// </summary>
        public static List<IMenu> Messages = new List<IMenu>();
        /// <summary>
        /// Stores the menus that show on the map. They are
        /// stored until closed.
        /// </summary>
        public static List<IMenu> Menus = new List<IMenu>();
        /// <summary>
        /// Shop Items
        /// </summary>
        public static List<int> ShopItems = new List<int>();
        /// <summary>
        /// Shop Equipments
        /// </summary>
        public static List<int> ShopEquipments = new List<int>();

        #region Pools - Used to minimize garbage collection
        public static Pool<ProjectileProcessor> Projectiles = new Pool<ProjectileProcessor>(100);
        public static Pool<MovementProcessor> MovementProcessors = new Pool<MovementProcessor>(10);
        #endregion

        /// <summary>
        /// Returns whether or not the game is saving or loading.
        /// </summary>
        public static int IsSavingOrLoading = -1;
        public static bool IsSaving = false;
        #endregion
               
        
        #region Static Methods

        public static void BeginMapSpriteBatch()
        {
            Global.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, null, null, null, null, Global.Instance.ActiveCamera.ViewTransformationMatrix());
        }

        #region Event
        /// <summary>
        /// Returns an event from the current map from the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EventData GetEvent(int id)
        {
            if (Global.Instance.CurrentMap == null)
                Error.Do(new Exception("The current map is null. Make sure the map is loaded."));

            EventData data;
            for (int layerIndex = 0; layerIndex < Global.Instance.CurrentMap.Data.Layers.Count; layerIndex++)
            {
                if (Global.Instance.CurrentMap.Data.Layers[layerIndex].Events.TryGetValue(id, out data))
                    return data;
            }
            Error.Do(new Exception("Event not found from the given id. ID " + id.ToString() + " Map " + Global.Instance.CurrentMap.Data.Name));
            return null;
        }
        /// <summary>
        /// Returns an event from the template events from the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EventData GetParentEvent(int id)
        {
            EventData data;
            if (GameData.Events.TryGetValue(id, out data)) return data;
            Error.Do(new Exception("Event not found from the given id. ID " + id.ToString() + " Template Event"));
            return null;
        }
        /// <summary>
        /// Activate Global Event
        /// </summary>
        /// <param name="p"></param>
        public static void ActivateGlobalEvent(int id)
        {
            foreach (GlobalEventProcessor processor in Global.Instance.GlobalEvents)
                if (processor.ID == id)
                    processor.isProgramActive = true;
        }
        #endregion

        #region Menu
        /// <summary>
        /// Show Menu
        /// </summary>
        /// <param name="id">The data id of the menu</param>
        /// <param name="showOnMap">Show on map</param>
        /// <param name="deactivateMap">Should the previous scenes be deactivated.</param>
        /// <param name="waitForClose">Should events wait for this menu to close.</param>
        /// <param name="exitCurrent">Should the current scene be exited.</param>
        /// <param name="isHUD">Is the menu an heads-up display.</param>
        /// <param name="dr">The owner of this menu. Used for event and menu command processing to know how long to hold.</param>
        public static void ShowMenu(MenuProcessor menu, bool showOnMap, bool deactivateMap, bool waitForClose, bool exitCurrent, bool isHUD)
        {
            if (!exitCurrent)
            {
                if (isHUD)
                {
                    Global.Instance.CurrentHUD = menu.ID;
                    ShowHUD();
                }
                else
                {
                    Global.Menus.Add(menu);
                    menu.UniqueID = Global.Instance.MenuUniqueIDCount++;
                    menu.WaitOnClose = waitForClose;
                    menu.ShowOnScene = showOnMap;
                    menu.DeactivateScene = deactivateMap;
                    menu.NeedShow = menu.ShowOnScene;
                }
            }
            else
            {
                // Add Screen
                Global.MenuToLoad = menu.id;
            }
        }
        /// <summary>
        /// Show Menu
        /// </summary>
        /// <param name="id">The data id of the menu</param>
        /// <param name="showOnMap">Show on map</param>
        /// <param name="deactivateMap">Should the previous scenes be deactivated.</param>
        /// <param name="waitForClose">Should events wait for this menu to close.</param>
        /// <param name="exitCurrent">Should the current scene be exited.</param>
        /// <param name="isHUD">Is the menu an heads-up display.</param>
        /// <param name="dr">The owner of this menu. Used for event and menu command processing to know how long to hold.</param>
        public static void ShowMenu(int id, bool showOnMap, bool deactivateMap, bool waitForClose, bool exitCurrent, bool isHUD, Drawable dr)
        {
            if (!exitCurrent)
            {
                if (isHUD)
                {
                    Global.Instance.CurrentHUD = id;
                    ShowHUD();
                }
                else
                {
                    Global.Menus.Add(new MenuProcessor(id));
                    Global.Menus[Global.Menus.Count - 1].UniqueID = Global.Instance.MenuUniqueIDCount++;
                    Global.Menus[Global.Menus.Count - 1].WaitOnClose = waitForClose;
                    Global.Menus[Global.Menus.Count - 1].ShowOnScene = showOnMap;
                    Global.Menus[Global.Menus.Count - 1].DeactivateScene = deactivateMap;
                    Global.Menus[Global.Menus.Count - 1].Owner = dr;
                    Global.Menus[Global.Menus.Count - 1].NeedShow = Global.Menus[Global.Menus.Count - 1].ShowOnScene;
                }
            }
            else
            {
                // Add Screen
                Global.MenuToLoad = id;
            }
        }
        /// <summary>
        /// Show HUD
        /// Shows the hud with the id stored in Global.Instance.CurrentHUD
        /// </summary>
        public static void ShowHUD()
        {
            int id = Global.Instance.CurrentHUD;
            if (id > -1)
            {
                // Check if HUD Exists
                for (int i = 0; i < Global.Menus.Count; i++)
                    if (Global.Menus[i].ID == id) id = -1;
                // If the HUD Doesn't exist, create it
                if (id > -1)
                {
                    Global.Menus.Add(new MenuProcessor(id));
                    Global.Menus[Global.Menus.Count - 1].UniqueID = Global.Instance.MenuUniqueIDCount++;
                    Global.Menus[Global.Menus.Count - 1].ShowOnScene = true;
                    Global.Menus[Global.Menus.Count - 1].NeedShow = true;
                }
            }
        }
        /// <summary>
        /// Close Menu
        /// </summary>
        /// <param name="p"></param>
        public static void CloseMenu(int id)
        {
            if (id > -1)
            {
                for (int i = 0; i < Global.Menus.Count; i++)
                    if (Global.Menus[i].ID == id)
                        Global.Menus[i].Close();
                for (int i = 0; i < Global.Messages.Count; i++)
                    if (Global.Messages[i].ID == id)
                        Global.Messages[i].Close();
            }
        }
        /// <summary>
        /// Close HUD
        /// </summary>
        public static void CloseHUD()
        {
            if (Global.Instance.CurrentHUD > -1)
            {
                for (int i = 0; i < Global.Menus.Count; i++)
                {
                    if (Global.Menus[i].ID == Global.Instance.CurrentHUD)
                    {
                        Global.Menus[i].Close();
                    }
                }
                Global.Instance.CurrentHUD = 0;
            }
        }
        /// <summary>
        /// Setup Message
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ev"></param>
        public static void SetupMessage(EventProgramData data, Drawable ev)
        {
            string text = "";
            // Get Text
            if ((int)data.Value[0] == 0) // Text
            {
            }
            else // Message
                text = data.Value[1].ToString();

            Global.Messages.Add(new MenuProcessor((int)data.Value[2]));
            if (!Global.Messages[Global.Messages.Count - 1].Erase)
            {
                Global.Messages[Global.Messages.Count - 1].UniqueID = Global.Instance.MenuUniqueIDCount++;
                Global.Messages[Global.Messages.Count - 1].SetupText(text, (int)data.Value[3], (Vector2)data.Value[4], (int)data.Value[5], (int)data.Value[6], (Vector2)data.Value[7], ev);
                Global.Messages[Global.Messages.Count - 1].WaitOnClose = (bool)data.Value[8];
                Global.Messages[Global.Messages.Count - 1].NeedShow = true;
            }
            else
            {
                if (ev is EventProcessor)
                    ((EventProcessor)ev).MenuClosed();
                else if (ev is MenuPartProcessor)
                    ((MenuPartProcessor)ev).MenuClosed();
            }
        }
        /// <summary>
        /// Setup Message
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ev"></param>
        public static void SetupMessage(EventProgramData data)
        {
            string text = "";
            // Get Text
            if ((int)data.Value[0] == 0) // Text
            {
            }
            else // Message=
                text = data.Value[1].ToString();

            Global.Messages.Add(new MenuProcessor((int)data.Value[2]));
            if (!Global.Messages[Global.Messages.Count - 1].Erase)
            {
                Global.Messages[Global.Messages.Count - 1].UniqueID = Global.Instance.MenuUniqueIDCount++;
                Global.Messages[Global.Messages.Count - 1].SetupText(text, (int)data.Value[3], (Vector2)data.Value[4], (int)data.Value[5], (int)data.Value[6], (Vector2)data.Value[7]);
                Global.Messages[Global.Messages.Count - 1].WaitOnClose = (bool)data.Value[8];
            }
        }
        /// <summary>
        /// Gets a menu with the same unique ID
        /// </summary>
        /// <param name="OwnerID"></param>
        /// <returns></returns>
        public static IMenu GetMenuFromUniqueID(int id)
        {
            if (Global.CurrentMenu != null)
                if (Global.CurrentMenu.UniqueID == id)
                    return Global.CurrentMenu;
            for (int i = 0; i < Global.Menus.Count; i++)
            {
                if (((Drawable)Global.Menus[i]).UniqueID == id)
                    return Global.Menus[i];
            }
            for (int i = 0; i < Global.Messages.Count; i++)
            {
                if (((Drawable)Global.Messages[i]).UniqueID == id)
                    return Global.Messages[i];
            }
            return null;
        }
        /// <summary>
        /// Returns a menu part from given id
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static IMenuParts GetMenuPart(List<IMenuParts> list, int id)
        {
            foreach (IMenuParts part in list)
            {
                if (part.ID == id)
                    return part;
                IMenuParts child = GetMenuPart(part.MenuParts, id);
                if (child != null)
                    return child;
            }
            return null;
        }
        #endregion

        #region File/Save/Load
        /// <summary>
        /// Save Game
        /// </summary>
        /// <param name="p"></param>
        public static void SaveGame(EventProgramData data)
        {
            if ((int)data.Value[0] == 0)
                Marshal.SaveGame((int)data.Value[1] + 1);
            else
                Marshal.SaveGame((int)Global.Variable((int)data.Value[1]) + 1);
        }
        /// <summary>
        /// Load Game
        /// </summary>
        /// <param name="p"></param>
        public static void LoadGame(EventProgramData data)
        {
            if ((int)data.Value[0] == 0)
                Marshal.LoadGame((int)data.Value[1] + 1);
            else
                Marshal.LoadGame((int)Global.Variable((int)data.Value[1]) + 1);
        }
        /// <summary>
        /// Save Game
        /// </summary>
        /// <param name="p"></param>
        public static void SaveGame(int fileIndex)
        {
            Marshal.SaveGame(fileIndex + 1);
        }
        /// <summary>
        /// Load Game
        /// </summary>
        /// <param name="p"></param>
        public static void LoadGame(int fileIndex)
        {
            Marshal.LoadGame(fileIndex + 1);
        }
        /// <summary>
        /// Reload game
        /// </summary>
        public static void ReloadGame()
        {
            Instance.Lists = new Dictionary<int, ListData>();
            Instance.Switches = new Dictionary<int, SwitchData>();
            Instance.Variables = new Dictionary<int, VariableData>();
            Instance.Strings = new Dictionary<int, StringData>();
            foreach (KeyValuePair<int, ListData> pair in GameData.Lists)
                Instance.Lists[pair.Key] = new ListData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, Values = new List<int>(pair.Value.Values) };
            foreach (KeyValuePair<int, SwitchData> pair in GameData.Switches)
                Instance.Switches[pair.Key] = new SwitchData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, State = pair.Value.State };
            foreach (KeyValuePair<int, VariableData> pair in GameData.Variables)
                Instance.Variables[pair.Key] = new VariableData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, Value = pair.Value.Value };
            foreach (KeyValuePair<int, StringData> pair in GameData.Strings)
                Instance.Strings[pair.Key] = new StringData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, Value = pair.Value.Value };
            Instance.Heroes = new Dictionary<int, HeroProcessor>();
            Instance.Party = new PartyProcessor();
            Instance.SkillKeys = GameData.Player.SkillKeys;
            Instance.ItemKeys = GameData.Player.ItemKeys;
            Instance.EventSwitches = new Dictionary<int, Dictionary<int, bool>>[5];
            Global.Instance.Player = new List<EventProcessor>();
            foreach (int heroID in GameData.Player.PartyList)
                Global.Instance.Party.AddHero(heroID, false);
        }
        #endregion

        #region Video, Tint, Flash, Shake, Animation, Picture, Particles
        /// <summary>
        /// Setup a video.
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="loop"></param>
        /// <param name="sizeType"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void SetupVideo(int materialID, int x, int y, bool loop, int sizeType, int width, int height)
        {
#if !SILVERLIGHT
            Global.VideoPlayer.PlayVideo(materialID, x, y, loop, sizeType, width, height);

#endif
        }
        /// <summary>
        /// Sets up the tint effect
        /// </summary>
        /// <param name="effectType"></param>
        /// <param name="screenType"></param>
        /// <param name="color"></param>
        /// <param name="p"></param>
        public static void TintEffect(EffectType effectType, ScreenType screenType, Color color, int p)
        {
            Color lastColor = Color.Transparent;
            if (Global.Instance.IsLastTintGlobal)
            {
                lastColor = Global.Instance.TintScreen[0].TintColor;
            }
            else
            {
                lastColor = Global.Instance.TintScreen[(int)screenType].TintColor;
            }
            Global.Instance.TintScreen[0] = new EffectProcessor(effectType, ScreenType.Global, Color.Transparent, 0, Color.Transparent);
            Global.Instance.TintScreen[(int)screenType] = new EffectProcessor(effectType, screenType, color, p, lastColor);
        }
        /// <summary>
        /// Sets up the flash effect
        /// </summary>
        /// <param name="effectType"></param>
        /// <param name="screenType"></param>
        /// <param name="color"></param>
        /// <param name="p"></param>
        /// <param name="p_5"></param>
        public static void FlashEffect(EffectType effectType, ScreenType screenType, Color color, int time, int freq)
        {
            if (Global.Instance.FlashScreen[0] != null)
            {
                Global.Instance.FlashScreen[0] = null;
            }
            Global.Instance.FlashScreen[(int)screenType] = new EffectProcessor(effectType, screenType, color, time, freq);
        }
        /// <summary>
        /// Sets up the shake effect
        /// </summary>
        /// <param name="effectType"></param>
        /// <param name="screenType"></param>
        /// <param name="p"></param>
        /// <param name="p_4"></param>
        /// <param name="p_5"></param>
        public static void ShakeEffect(EffectType effectType, ScreenType screenType, int p, int p_4, int p_5)
        {
            if (Global.Instance.ShakeScreen[0] != null)
            {
                Global.Instance.ShakeScreen[0] = null;
            }
            Global.Instance.ShakeScreen[0] = null;
            Global.Instance.ShakeScreen[(int)screenType] = new EffectProcessor(effectType, screenType, p, p_4, p_5, true);
        }
        /// <summary>
        /// Show Animation
        /// </summary>
        /// <param name="screenType"></param>
        /// <param name="layerIndex"></param>
        /// <param name="showType"></param>
        /// <param name="animationID"></param>
        /// <param name="actionID"></param>
        /// <param name="directionIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ShowAnimation(ScreenType screenType, int layerIndex, int showType, int animationID, int actionID, int directionIndex, int x, int y)
        {
            if (screenType == 0)
                Global.Instance.CurrentMap.AddProcessor(new EffectProcessor(EffectType.Animation, layerIndex, screenType, animationID, actionID, directionIndex, x, y));
            else
                Global.Instance.ScreenAnimations.Add(new EffectProcessor(EffectType.Animation, layerIndex, screenType, animationID, actionID, directionIndex, x, y));
        }
        /// <summary>
        /// Show an animation on an Event.
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionID"></param>
        /// <param name="direction"></param>
        /// <param name="ev"></param>
        /// <returns>Returns the animation's display time.</returns>
        public static int ShowAnimationOnEvent(int animationID, int actionID, int direction, EventProcessor ev)
        {
            if (ev != null)
            {
                AnimationProcessor animation = new AnimationProcessor();
                animation.Setup(animationID, actionID, EventAction.Idle);
                animation.Direction = direction;
                animation.Start();
                ev.AddAnimation(animation);
                return animation.GetDisplayTime();
            }
            return 0;
        }
        /// <summary>
        /// Show Picture
        /// </summary>
        /// <param name="index"></param>
        /// <param name="materialID"></param>
        /// <param name="set"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ShowPicture(int index, int layer, int materialID, bool set, int width, int height, int positon, int x, int y, int originType, ScreenType screenType)
        {
            // Clear Old Pic
            ClearPicture(index);
            // Add new pic
            Global.Instance.Pictures[index] = new PictureProcessor(materialID, set, width, height, x, y, screenType, originType, layer);
            if (positon == 2) Global.Instance.Pictures[index].Center();
        }
        /// <summary>
        /// Move Picture
        /// </summary>
        /// <param name="index"></param>
        /// <param name="set"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MovePicture(int index, bool set, int width, int height, int x, int y)
        {
            if (Global.Instance.Pictures[index] != null)
            {
                Global.Instance.Pictures[index].Set(set, width, height, x, y);
            }
        }
        /// <summary>
        /// Tint Picture
        /// </summary>
        /// <param name="index"></param>
        /// <param name="color"></param>
        /// <param name="frames"></param>
        public static void TintPicture(int index, Color color, int frames)
        {
            if (Global.Instance.Pictures[index] != null)
            {
                Global.Instance.Pictures[index].Tint(color, frames);
            }
        }
        /// <summary>
        /// Clear Picture
        /// </summary>
        /// <param name="index"></param>
        public static void ClearPicture(int index)
        {
            Global.Instance.Pictures[index] = null;
        }
        /// <summary>
        /// Show Particle 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="particleID"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="screenType"></param>
        public static void ShowParticle(int index, int particleID, int x, int y, int layer, ScreenType screenType)
        {
            // Clear Old particle
            ParticleSystemProcessor particle = ClearParticle(index);
            // Add new particle
            if (particle == null)
            {
                particle = new ParticleSystemProcessor();
                Global.Instance.Particles.Add(index, particle);
            }
            particle.Setup(particleID, index, new Vector2(x, y));
            // Layer
            particle.LayerIndex = layer;
            // Add to map
            Global.Instance.CurrentMap.AddProcessor(particle);
        }
        /// <summary>
        /// Show Particle On Event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="target"></param>
        public static void ShowParticleOnEvent(int id, EventProcessor target)
        {
            if (id > -1)
            {
                // Add new particle
                ParticleSystemProcessor particle = new ParticleSystemProcessor();
                particle.Setup(id, -1, target.Position);
                // Layer
                particle.LayerIndex = target.LayerIndex;
                // Add to map
                Global.Instance.CurrentMap.AddProcessor(particle);
            }
        }
        /// <summary>
        /// Move Particle
        /// </summary>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveParticle(int index, int x, int y)
        {
            ParticleSystemProcessor particle;
            if (Global.Instance.Particles.TryGetValue(index, out particle))
            {
                particle.Move(x, y);
            }
        }
        /// <summary>
        /// Clear Particle
        /// </summary>
        /// <param name="p"></param>
        public static ParticleSystemProcessor ClearParticle(int index)
        {
            ParticleSystemProcessor particle = null;

            if (Global.Instance.Particles.TryGetValue(index, out particle))
            {
                if (!particle.Erase)
                {
                    particle.Clear();
                    // Remove Particle
                    Global.Instance.CurrentMap.RemoveProcessor(particle);
                }
            }

            return particle;
        }
        /// <summary>
        /// Display Damage Text
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="damaged"></param>
        /// <param name="target"></param>
        public static void DisplayDamage(int damage, bool damaged, EventProcessor target, int displayTime)
        {
            // Get Font
            FontData font = GameData.Fonts.GetData(Global.Project.BattleFont);
            if (font != null)
            {
                // Damaged
                string text;
                Color startColor;
                Color endColor;
                if (damaged)
                {
                    text = Math.Abs(damage).ToString();
                    if (damage >= 0)
                    {
                        // Damage - Start Red - End orange trasnparenet
                        startColor = Color.Red;
                        endColor = Color.Orange;
                        endColor.A = 100;
                    }
                    else
                    {
                        // Heal - Start Blue - End Yellow Transparent
                        startColor = Color.Blue;
                        endColor = Color.LightBlue;
                        endColor.A = 100;
                    }
                }
                else
                {
                    text = "Miss!";
                    startColor = Color.Purple;
                    endColor = Color.Purple;
                    endColor.A = 50;
                }
                Vector2 position = target.Position;
                if (target.CurrentAction != null)
                    position = target.Position - new Vector2(0, target.CurrentAction.CanvasSize.Y);
                Vector2 targetPosition = new Vector2(position.X, position.Y - 140);
                // Add effect
                if (font.Styles[0].MaterialID > -1)
                    Global.Instance.TextScreen[1].Add(new EffectProcessor(EffectType.Text, ScreenType.Gameplay, font, text, position, targetPosition, startColor, endColor, 140));
            }
        }
        #endregion

        #region Projectiles
        /// <summary>
        /// Create Projectiles
        /// </summary>
        /// <param name="eventProcessor"></param>
        /// <param name="target"></param>
        /// <param name="equipment"></param>
        public static void CreateProjectile(EventProcessor owner, EventProcessor target, EquipmentData equipment, List<int> hostileList)
        {
            if (Global.Instance.CurrentMap != null)
            {
                // Get Data
                ProjectileGroupData data = GameData.Projectiles.GetData(equipment.Projectile);
                if (data != null)
                {
                    // Create Projectiles
                    foreach (ProjectileData projectile in data.Projectiles)
                    {
                        if (projectile.ProjectileType == 0)
                            Instance.CurrentMap.AddProcessor(Projectiles.Fetch().Create(projectile, owner, target, equipment, hostileList));
                        else
                            Instance.CurrentMap.AddProcessor((new LaserProcessor()).Create(projectile, owner, target, equipment, hostileList));
                    }
                }
            }
        }
        /// <summary>
        /// Create Projectiles
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="target"></param>
        /// <param name="skill"></param>
        /// <param name="hostileList"></param>
        public static void CreateProjectile(EventProcessor owner, EventProcessor target, SkillData skill, List<int> hostileList)
        {
            if (Global.Instance.CurrentMap != null)
            {
                // Get Data
                ProjectileGroupData data = GameData.Projectiles.GetData(skill.Projectile);
                if (data != null)
                {
                    // Create Projectiles
                    foreach (ProjectileData projectile in data.Projectiles)
                    {
                        if (projectile.ProjectileType == 0)
                            Instance.CurrentMap.AddProcessor(Projectiles.Fetch().Create(projectile, owner, target, skill, hostileList));
                        else
                            Instance.CurrentMap.AddProcessor((new LaserProcessor()).Create(projectile, owner, target, skill, hostileList));
                    }
                }
            }
        }
        #endregion

        #region Angle
        /// <summary>
        /// Converts a direction to an angle;
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int DirectionToAngle(int direction)
        {
            switch (direction)
            {
                case 0: // Up
                    return 270;
                case 1: // Down
                    return 90;
                case 2: // Left
                    return 180;
                case 3: // Right
                    return 0;
                case 4: // Up/Left
                    return 220;
                case 5: // Up/Right
                    return 320;
                case 6: // Down/Left
                    return 140;
                case 7: // Down/Right
                    return 45;
            }
            return 0;
        }
        /// <summary>
        /// Angle To Direction
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static int AngleToDirection(int angle)
        {
            if (angle <= 240 && angle >= 200) // Up - Left
            {
                return 4;
            }
            else if (angle >= 300 && angle <= 340) // Up - Right
            {
                return 5;
            }
            else if (angle >= 120 && angle <= 160) // Down - Left
            {
                return 6;
            }
            else if (angle >= 30 && angle <= 70) // Down - Right
            {
                return 7;
            }
            else if (angle > 220 && angle < 320) // Up
            {
                return 0;
            }
            else if (angle > 45 && angle < 140) // Down
            {
                return 1;
            }
            else if (angle >= 140 && angle <= 220) // Left
            {
                return 2;
            }
            else if (((angle >= 320 && angle <= 360) || (angle >= 0 && angle <= 40))) // Right
            {
                return 3;
            }
            return 0;
        }
        /// <summary>
        /// Check if the given angle is between p1 and p2
        /// </summary>
        /// <param name="_angle"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool AngleInBetween(int _angle, int p1, int p2)
        {
            if (p1 > p2)
            {
                return (p1 >= _angle && _angle <= 360) || (_angle >= 0 || _angle <= p2);
            }
            else if (p1 < p2)
            {
                return (p1 <= _angle && p2 >= _angle);
            }
            return false;
        }
        #endregion

        #region Game Data

        public static bool Switch(int id)
        {
            SwitchData value;
            if (Global.Instance.Switches.TryGetValue(id, out value)) return value.State;
            // If the data does not exist, we make it an error.
            if (id > -1) Error.Do(new Exception("Data does not exist!\nData: " + typeof(SwitchData).ToString() + "\nID: " + id.ToString() + "\nContainer: " + Global.Instance.Switches.ToString()));
            return false;
        }
        /// <summary>
        /// Get Variable Value
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float Variable(int id)
        {
            VariableData value;
            if (Global.Instance.Variables.TryGetValue(id, out value)) return value.Value;
            // If the data does not exist, we make it an error.
            if (id > -1) Error.Do(new Exception("Data does not exist!\nData: " + typeof(VariableData).ToString() + "\nID: " + id.ToString() + "\nContainer: " + Global.Instance.Variables.ToString()));
            return 0;
        }
        /// <summary>
        /// Get Variable Value
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float SetVariable(int id, float value)
        {
            VariableData variable = Global.Instance.Variables.GetData(id);
            if (variable != null)
                return variable.Value += value;
            return 0;
        }
        /// <summary>
        /// Return Local Variable Value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static float Variable(int id, EventProcessor data)
        {
            VariableData value;
            if (data.Variables.TryGetValue(id, out value)) return value.Value;
            // If the data does not exist, we make it an error.
            if (id > -1) Error.Do(new Exception("Data does not exist!\nData: " + typeof(VariableData).ToString() + "\nID: " + id.ToString() + "\nContainer: " + data.Data.Name));
            return 0;
        }
        /// <summary>
        /// Return Local Variable Value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static float Variable(int id, GlobalEventProcessor data)
        {
            VariableData value;
            if (data.Variables.TryGetValue(id, out value)) return value.Value;
            // If the data does not exist, we make it an error.
            if (id > -1) Error.Do(new Exception("Data does not exist!\nData: " + typeof(VariableData).ToString() + "\nID: " + id.ToString() + "\nContainer: " + data.Data.Name));
            return 0;
        }
        /// <summary>
        /// Return string's value
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string String(int id)
        {
            StringData value;
            if (Global.Instance.Strings.TryGetValue(id, out value)) return value.Value;
            // If the data does not exist, we make it an error.
            if (id > -1) Error.Do(new Exception("Data does not exist!\nData: " + typeof(StringData).ToString() + "\nID: " + id.ToString() + "\nContainer: " + Global.Instance.Strings.ToString()));
            return "";
        }
        /// <summary>
        /// Set Event Switch
        /// </summary>
        /// <param name="index">Index of the event switch</param>
        /// <param name="mapID">The map id of the event</param>
        /// <param name="id">The id of the event</param>
        /// <param name="value">The value to set</param>
        public static void SetEventSwitch(int index, int mapID, int id, bool value)
        {
            if (Global.Instance.EventSwitches[index] == null)
                Global.Instance.EventSwitches[index] = new Dictionary<int, Dictionary<int, bool>>();

            Dictionary<int, bool> swtch;
            if (!Global.Instance.EventSwitches[index].TryGetValue(mapID, out swtch))
                Global.Instance.EventSwitches[index][mapID] = swtch = new Dictionary<int, bool>();

            swtch[id] = value;
        }
        /// <summary>
        /// Returns Event Switch value
        /// </summary>
        /// <param name="index">Index of the event switch</param>
        /// <param name="mapID">The map id of the event</param>
        /// <param name="id">The id of the event</param>
        public static bool EventSwitch(int index, int mapID, int id)
        {
            if (Global.Instance.EventSwitches[index] == null)
                Global.Instance.EventSwitches[index] = new Dictionary<int, Dictionary<int, bool>>();

            Dictionary<int, bool> swtch;
            if (!Global.Instance.EventSwitches[index].TryGetValue(mapID, out swtch))
                Global.Instance.EventSwitches[index][mapID] = swtch = new Dictionary<int, bool>();

            bool value;

            if (swtch.TryGetValue(id, out  value))
                return value;

            return false;
        }
        /// <summary>
        /// Get Data property
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="p_3"></param>
        /// <returns></returns>
        public static DataProperty GetDataProperty(int databaseID, int dataID, int propID)
        {
            Data dataBase;
            Data data;
            DataProperty prop;
            if (GameData.Databases.TryGetValue(databaseID, out dataBase))
            {
                if (dataBase.Datas.TryGetValue(dataID, out data))
                {
                    prop = data.Properties.GetData(propID);
                    if (prop != null)
                        return prop;
                }
            }
            throw new Exception("Database, data, or property does not exist! Please make sure they exist. Database ID: " + databaseID.ToString() + " Data ID: " + dataID.ToString() + " Property ID: " + propID.ToString());
        }
        #endregion

        /// <summary>
        /// Logs given object by data and time.
        /// </summary>
        /// <param name="str"></param>
        public static void Log(object str)
        {
            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + "] : " + str.ToString());
        }
        #endregion
    }
    /// <summary>
    /// Pause Action
    /// </summary>
    public enum PauseAction
    {
        None,
        Video,
        Pause
    }
}
