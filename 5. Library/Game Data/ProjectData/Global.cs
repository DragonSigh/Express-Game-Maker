//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using System.Collections;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Controls;
using Microsoft.Xna.Framework.Content;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Audio;
using EGMGame.Docking.Explorers;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EGMGame.Controls.Game;
using Microsoft.Xna.Framework;
using System.Text.RegularExpressions;

namespace EGMGame
{
    public class Global
    {
#if DEBUG
        internal const int GameType = 1;
#else
        internal const int GameType = 1;
#endif

        public static bool ImportingAudio;

        public static bool IsTrial
        {
            get { return false; }
        }

        public static SpriteFont Font;
        /// <summary>
        /// Returns the current project
        /// </summary>
        public static Project Project
        {
            get { return MainForm.CurrentProject; }
        }

        public static string TempPath
        {
            get { return Project.Location + @"\Temp"; }
        }
        /// <summary>
        /// Gets a name from the given name and container
        /// </summary>
        /// <param name="name"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static string GetName(string name, IList container)
        {
            // TODO : MAKE SURE NAMES DO NO REPEAT!
            return name + GetID(container).ToString();
        }
        /// <summary>
        /// Returns a new id from the given container.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        internal static int GetID(IList list)
        {
            for (int i = 0; i <= list.Count + 1; i++)
            {
                if (!CheckID(i, list))
                    return i;
            }
            return 0;
        }
        /// <summary>
        /// Checks if the given id exists in the given container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        private static bool CheckID(int id, IList container)
        {
            foreach (IGameData data in container)
            {
                if (data.ID == id)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Returns a data from given id and container.
        /// Returns null if data does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static T2 GetData<T2>(int id, IList container)
        {
            foreach (object data in container)
            {
                if (((IGameData)data).ID == id) return (T2)data;
            }
            return default(T2);
        }

        /// <summary>
        /// Returns a data from given id and container.
        /// Returns null if data does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static T1 GetData<T1>(int id, Dictionary<int, T1> container)
        {
            T1 value;
            if (container.TryGetValue(id, out value))
                return value;
            return default(T1);
        }
        /// <summary>
        /// Returns a data from given id and container.
        /// Returns null if data does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static T2 GetData<T2>(int id, IEnumerable container)
        {
            foreach (object data in container)
            {
                if (container is IList)
                {
                    if (((IGameData)data).ID == id) return (T2)data;
                }
                else if (container is IDictionary)
                {
                    KeyValuePair<int, T2> pair = (KeyValuePair<int, T2>)data;

                    if (((IGameData)(object)pair.Value).ID == id) return (T2)pair.Value;
                }
            }
            return default(T2);
        }
        /// <summary>
        /// Returns the index of an object from its given id and container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static int GetIndex(int id, IList container)
        {
            if (id > -1 && id < container.Count)
            {
                int i = 0;
                foreach (IGameData data in container)
                {
                    if (data.ID == id)
                        return i;
                    i++;
                }
            }
            return -1;
        }
        /// <summary>
        /// Gets a name from the given name and container
        /// </summary>
        /// <param name="name"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static string GetName(string name, IDictionary container)
        {
            return name + GetID(container).ToString();
        }
        /// <summary>
        /// Does name exist?
        /// </summary>
        /// <param name="p"></param>
        /// <param name="serializableDictionary"></param>
        /// <returns></returns>
        internal static bool NameExists(string name, IDictionary container)
        {
            foreach (IGameData data in container.Values)
            {
                if (data.Name.ToLower() == name.ToLower())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Does name exist?
        /// </summary>
        /// <param name="p"></param>
        /// <param name="serializableDictionary"></param>
        /// <returns></returns>
        internal static bool NameExists(string name, IList container)
        {
            foreach (IGameData data in container)
            {
                if (data.Name.ToLower() == name.ToLower())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Returns a new id from the given container.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        internal static int GetID(IDictionary list)
        {
            for (int i = 0; i <= list.Values.Count + 1; i++)
            {
                if (!CheckID(i, list))
                    return i;
            }
            return 0;
        }
        /// <summary>
        /// Checks if the given id exists in the given container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        private static bool CheckID(int id, IDictionary container)
        {
            foreach (IGameData data in container.Values)
            {
                if (data.ID == id)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Returns a data from given id and container.
        /// Returns null if data does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static IGameData GetData(int id, IDictionary container)
        {
            if (container.Contains(id))
                return (IGameData)container[id];
            return null;
        }
        /// <summary>
        /// Returns the index of an object from its given id and container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static int GetIndex(int id, IDictionary container)
        {
            if (id > -1 && id < container.Count)
            {
                int i = 0;
                foreach (IGameData data in container.Values)
                {
                    if (data.ID == id)
                        return i;
                    i++;
                }
            }
            return -1;
        }
        /// <summary>
        /// Gets the property descripter of a given data and a property name
        /// </summary>
        /// <param name="data"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal static PropertyDescriptor GetPropertyDescriptor(IGameData data, string propertyName)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
            foreach (PropertyDescriptor myProperty in properties)
            {
                try
                {
                    if (myProperty.PropertyType.IsSerializable && myProperty.Name == propertyName)
                        return myProperty;
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "18x001");
                }
            }
            return null;
        }
        /// <summary>
        /// Gets the numver of sound effects.
        /// </summary>
        /// <returns></returns>
        internal static int GetSECount()
        {
            int i = 0;
            foreach (AudioData d in GameData.Audios.Values)
                i++;
            return i;
        }
        /// <summary>
        /// Get list of map events
        /// </summary>
        /// <returns></returns>
        internal static IList GetMapEventList(MapData mapData)
        {
            List<EventData> list = new List<EventData>();

            foreach (LayerData layer in mapData.Layers)
            {
                list.AddRange(layer.Events.Values);
            }

            return list;
        }
        /// <summary>
        /// Returns data from the given index and dictionary container
        /// </summary>
        /// <param name="index"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static IGameData GetDataFromIndex(int index, IDictionary container)
        {
            int i = 0;
            foreach (IGameData data in container.Values)
            {
                if (i == index)
                    return data;
                i++;
            }
            return null;
        }
        /// <summary>
        /// Returns data from the given index and list container
        /// </summary>
        /// <param name="index"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        internal static IGameData GetDataFromIndex(int index, IList container)
        {
            if (index > -1 && container.Count > index)
                return (IGameData)container[index];
            else
                return null;
        }
        /// <summary>
        /// Loads the font if its null.
        /// </summary>
        /// <param name="contentManager"></param>
        internal static void LoadFont(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
            if (Global.Font == null)
            {
                ContentManager cm = new ContentManager(contentManager.ServiceProvider, "Content");
                //string dir = contentManager.RootDirectory;
                Global.Font = Loader.SpriteFont(cm, "Tahoma7");
                //contentManager.RootDirectory = dir;
                Global.Font.Spacing = -1;
            }
        }

        internal static void LoadFont(ServiceContainer serviceContainer)
        {
            if (Global.Font == null)
            {
                ContentManager contentManager = new ContentManager(serviceContainer, "Content");
                contentManager.RootDirectory = "Content";
                Global.Font = Loader.SpriteFont(contentManager, "Tahoma7");
                Global.Font.Spacing = -1;
            }
        }
        /// <summary>
        /// Returns the index of the layer the event is in.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="mapData"></param>
        /// <returns></returns>
        internal static int GetLayerIndex(EventData e, MapData mapData)
        {
            int i = 0;
            foreach (LayerData layer in mapData.Layers)
            {
                if (layer.Events.ContainsKey(e.ID))
                    return i;
                i++;
            }
            return 0;
        }


        #region Cursor Helpers
        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        /// <summary>
        /// Create a resized cursor from a bitmap, with the hot-spot as specified.
        /// </summary>
        public static System.Windows.Forms.Cursor CreateCursor(System.Drawing.Bitmap bmp, int width, int height, int xHotSpot, int yHotSpot)
        {
            try
            {
                IntPtr ptr = (ResizeImage((System.Drawing.Image)bmp, width, height)).GetHicon();
                IconInfo tmp = new IconInfo();
                GetIconInfo(ptr, ref tmp);
                tmp.xHotspot = xHotSpot;
                tmp.yHotspot = yHotSpot;
                tmp.fIcon = false;
                ptr = CreateIconIndirect(ref tmp);
                return new Cursor(ptr);
            }
            catch
            {
                return System.Windows.Forms.Cursors.Default;
            }
        }

        private static System.Drawing.Bitmap ResizeImage(System.Drawing.Image img, int width, int height)
        {
            System.Drawing.Bitmap b = new System.Drawing.Bitmap(width, height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage((System.Drawing.Image)b);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return b;
        }
        #endregion
        /// <summary>
        /// Play Sound Effect
        /// </summary>
        public static AudioProcessor systemAudioProcessor = new AudioProcessor();
        internal static void PlaySoundEffect(int p)
        {
            AudioData audio = Global.GetData<AudioData>(p, GameData.Audios);
            if (audio != null)
            {
                MaterialData m = Global.GetData<MaterialData>(audio.MaterialId, GameData.Materials);
                if (m != null)
                {
                    SoundEffect curSound = Loader.SoundEffect(MaterialExplorer.contentBuilder, MainForm.audioEditor.contentManager, m.ID);
                    systemAudioProcessor.Set(curSound, audio);
                }
                systemAudioProcessor.Stop();
                systemAudioProcessor.EndThread();
                systemAudioProcessor.StartThread();
                systemAudioProcessor.Play();
            }
        }

        internal static void PlaySoundEffect(AudioData audioData, AudioSettings settings)
        {
            MaterialData m = Global.GetData<MaterialData>(audioData.MaterialId, GameData.Materials);
            if (m != null)
            {
                AudioData audio = new AudioData();
                audio.Category = audioData.Category;
                audio.FadeAfter = settings.FadeAfter;
                audio.FadeIn = settings.FadeIn;
                audio.FadeOut = settings.FadeOut;
                audio.ID = audioData.ID;
                audio.Loop = settings.Loop;
                audio.MaterialId = audioData.MaterialId;
                audio.Name = audioData.Name;
                audio.Pan = settings.Pan;
                audio.Pitch = settings.Pitch;
                audio.Volume = settings.Volume;
                SoundEffect curSound = Loader.SoundEffect(MaterialExplorer.contentBuilder, MainForm.audioEditor.contentManager, m.ID);

                systemAudioProcessor.Stop();
                systemAudioProcessor.EndThread();
                systemAudioProcessor.Set(curSound, audio);
                systemAudioProcessor.StartThread();
                systemAudioProcessor.Play();
            }
        }

        internal static void PauseAudio()
        {
            systemAudioProcessor.Pause();
        }

        internal static void ResumeAudio()
        {
            systemAudioProcessor.Resume();
        }

        internal static void StopAudio()
        {
            systemAudioProcessor.Stop();
            systemAudioProcessor.EndThread();
        }

        internal static int GetProgramID(List<EventProgramData> list)
        {
            for (int id = 0; id < 999999; id++)
            {
                if (!CheckIfIDExists(list, id))
                {
                    return id;
                }
            }
            throw new Exception("Can't assign ID! Data list passed maximum limit of 999999.");
        }

        private static bool CheckIfIDExists(List<EventProgramData> list, int id)
        {
            foreach (EventProgramData data in list)
            {
                if (data.ID == id)
                    return true;
                if (CheckIfIDExists(data.Programs, id))
                    return true;
            }
            return false;
        }

        static MemoryStream ClipBoard;
        /// <summary>
        /// Copy Data
        /// </summary>
        /// <param name="selectedData"></param>
        internal static void Copy(object data)
        {
            if (ClipBoard != null)
                ClipBoard.Dispose();
            ClipBoard = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(ClipBoard, data);
        }
        /// <summary>
        /// Paste data
        /// </summary>
        /// <returns></returns>
        internal static object PasteData()
        {
            if (ClipBoard == null) return null;
            BinaryFormatter b = new BinaryFormatter();
            ClipBoard.Position = 0;
            Object data = b.Deserialize(ClipBoard);
            return data;
        }

        internal static T1 Duplicate<T1>(object data)
        {
            if (data == null)
                return default(T1);
            MemoryStream stream = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(stream, data);
            stream.Position = 0;
            return (T1)b.Deserialize(stream);
        }

        internal static T1 GetMenuPart<T1>(int id)
        {
            MenuData menu = (MenuData)MainForm.menuEditor.addRemoveList.Data();
            if (menu.ID > -10)
            {
                IMenuParts part = GetMenuPart(menu.MenuParts, id);

                if (part != null && part is T1)
                {
                    T1 pt = (T1)((object)part);
                    return pt;
                }
            }
            return default(T1);
        }

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

        internal static void SetMenuParts(Type type, out List<IMenuParts> parts)
        {
            MenuData menu = (MenuData)MainForm.menuEditor.addRemoveList.Data();
            List<IMenuParts> childs;
            parts = new List<IMenuParts>();
            if (menu.ID > -10)
            {
                foreach (IMenuParts part in menu.MenuParts)
                {
                    if (part.GetType() == type)
                    {
                        parts.Add(part);
                    }
                    SetMenuParts(type, out childs);
                    if (childs.Count > 0)
                        parts.AddRange(childs);
                }
            }
            parts = new List<IMenuParts>();
        }


        #region Editor Only
        internal static List<VariableComboBox> CbVariables = new List<VariableComboBox>();
        internal static List<SwitchesComboBox> CbSwitches = new List<SwitchesComboBox>();
        internal static List<StringComboBox> CbStrings = new List<StringComboBox>();
        internal static List<StatesComboBox> CbStates = new List<StatesComboBox>();
        internal static List<SkillsComboBox> CbSkills = new List<SkillsComboBox>();
        internal static List<WindowsComboBox> CbWindows = new List<WindowsComboBox>();
        internal static List<SEComboBox> CbAudio = new List<SEComboBox>();
        internal static List<ParticleComboBox> CbParticles = new List<ParticleComboBox>();
        internal static List<MenuComboBox> CbMenus = new List<MenuComboBox>();
        internal static List<MessageComboBox> CbMessages = new List<MessageComboBox>();
        internal static List<MaterialsComboBox> CbMaterials = new List<MaterialsComboBox>();
        internal static List<MapsComboBox> CbMaps = new List<MapsComboBox>();
        internal static List<MapEventComboBox> CbMapEvents = new List<MapEventComboBox>();
        internal static List<ListComboBox> CbLists = new List<ListComboBox>();
        internal static List<ItemsComboBox> CbItems = new List<ItemsComboBox>();
        internal static List<ProjectilesComboBox> CbProjectiles = new List<ProjectilesComboBox>();
        internal static List<HeroComboBox> CbHeroes = new List<HeroComboBox>();
        internal static List<GlobalEventComboBox> CbGlobalEvents = new List<GlobalEventComboBox>();
        internal static List<EquipmentComboBox> CbEquipemnts = new List<EquipmentComboBox>();
        internal static List<EnemyComboBox> CbEnemies = new List<EnemyComboBox>();
        internal static List<DatabaseComboBox> CbDatabases = new List<DatabaseComboBox>();
        internal static List<AnimationComboBox> CbAnimations = new List<AnimationComboBox>();
        internal static List<AnimationActionComboBox> CbActions = new List<AnimationActionComboBox>();
        internal static List<FontComboBox> CbFonts = new List<FontComboBox>();
        internal static List<TextComboBox> CbTexts = new List<TextComboBox>();
        #endregion

        internal static void CBEquipments()
        {
            for (int i = 0; i < CbEquipemnts.Count; i++)
            {
                CbEquipemnts[i].Refresh(CbEquipemnts[i].Data().ID);
            }
        }

        internal static void CBStates()
        {
            for (int i = 0; i < CbStates.Count; i++)
            {
                CbStates[i].Refresh(CbStates[i].Data().ID);
            }
            MainForm.heroEditor.RefreshProperty();
            MainForm.enemyEditor.RefreshProperty();
            MainForm.equipmentEditor.RefreshProperty();
            MainForm.skillsEditor.RefreshProperty();
            MainForm.itemEditor.RefreshProperty();
        }

        internal static void CBSkills()
        {
            for (int i = 0; i < CbSkills.Count; i++)
            {
                CbSkills[i].Refresh(CbSkills[i].Data().ID);
            }
            MainForm.heroEditor.RefreshProperty();
            MainForm.enemyEditor.RefreshProperty();
            MainForm.equipmentEditor.RefreshProperty();
            MainForm.skillsEditor.RefreshProperty();
            MainForm.itemEditor.RefreshProperty();
        }
        
        internal static void CBItems()
        {
            for (int i = 0; i < CbItems.Count; i++)
            {
                CbItems[i].Refresh(CbItems[i].Data().ID);
            }
        }

        internal static void CBProjectiles()
        {
            for (int i = 0; i < CbProjectiles.Count; i++)
            {
                CbProjectiles[i].Refresh(CbProjectiles[i].Data().ID);
            }
        }

        internal static void CBEnemies()
        {
            for (int i = 0; i < CbEnemies.Count; i++)
            {
                CbEnemies[i].Refresh(CbEnemies[i].Data().ID);
            }
        }

        internal static void CBHeroes()
        {
            for (int i = 0; i < CbHeroes.Count; i++)
            {
                CbHeroes[i].Refresh(CbHeroes[i].Data().ID);
            }
        }

        internal static void CBAudio()
        {
            for (int i = 0; i < CbAudio.Count; i++)
            {
                CbAudio[i].Refresh(CbAudio[i].Data().ID);
            }
        }

        internal static void CBAnimations()
        {
            for (int i = 0; i < CbAnimations.Count; i++)
            {
                CbAnimations[i].Refresh(CbAnimations[i].Data().ID);
            }
        }

        internal static void CBActions(AnimationData animation)
        {
            for (int i = 0; i < CbActions.Count; i++)
            {
                CbActions[i].Refresh(CbActions[i].Data().ID, animation);
            }
        }

        internal static void CBActions()
        {
            for (int i = 0; i < CbActions.Count; i++)
            {
                CbActions[i].Refresh(CbActions[i].Data().ID);
            }
        }

        internal static void CBVariables()
        {
            for (int i = 0; i < CbVariables.Count; i++)
            {
                CbVariables[i].Refresh(CbVariables[i].Data().ID);
            }
            MainForm.textEditor.Repopulate();
        }

        internal static void CBList()
        {
            for (int i = 0; i < CbLists.Count; i++)
            {
                CbLists[i].Refresh(CbLists[i].Data().ID);
            }
        }

        internal static void CBSwitches()
        {
            for (int i = 0; i < CbSwitches.Count; i++)
            {
                CbSwitches[i].Refresh(CbSwitches[i].Data().ID);
            }
        }

        internal static void CBStrings()
        {
            for (int i = 0; i < CbStrings.Count; i++)
            {
                CbStrings[i].Refresh(CbStrings[i].Data().ID);
            }
            MainForm.textEditor.Repopulate();
        }

        internal static void CBFonts()
        {
            for (int i = 0; i < CbFonts.Count; i++)
            {
                CbFonts[i].Refresh(CbFonts[i].Data().ID);
            }
        }

        internal static void CBTexts()
        {
            for (int i = 0; i < CbTexts.Count; i++)
            {
                CbTexts[i].Refresh(CbTexts[i].Data().ID);
            }
        }

        internal static void CBMenus()
        {
            for (int i = 0; i < CbMenus.Count; i++)
            {
                CbMenus[i].Refresh(CbMenus[i].Data().ID);
            }

            for (int i = 0; i < CbMessages.Count; i++)
            {
                CbMessages[i].Refresh(CbMessages[i].Data().ID);
            }
        }

        internal static void CBGlobalEvents()
        {
            for (int i = 0; i < CbGlobalEvents.Count; i++)
            {
                CbGlobalEvents[i].Refresh(CbGlobalEvents[i].Data().ID);
            }
        }

        internal static void CBMaterials(MaterialDataType type)
        {
            if (type == MaterialDataType.All)
            {
                MaterialsComboBox.RefreshList(MaterialDataType.All);
                MaterialsComboBox.RefreshList(MaterialDataType.Image);
                MaterialsComboBox.RefreshList(MaterialDataType.Bitmap_Font);
                MaterialsComboBox.RefreshList(MaterialDataType.Sound);
                MaterialsComboBox.RefreshList(MaterialDataType.Video);
            }
            else
                MaterialsComboBox.RefreshList(type);
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].Refresh(CbMaterials[i].Data().ID, type);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.Refresh(MainForm.chooseMaterialDialog.Data().ID, type);
        }

        internal static void CBMaterials(List<MaterialDataType> types)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].Refresh(CbMaterials[i].Data().ID, types);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.Refresh(MainForm.chooseMaterialDialog.Data().ID, types);
        }

        internal static void CBAddMaterial(string path, MaterialData newM, List<MaterialDataType> types)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].AddMaterial(path, newM, types);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.AddMaterial(path, newM, types);
        }

        internal static void CBAddMaterial(string path, MaterialData m, MaterialDataType materialDataType)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].AddMaterial(path, m, materialDataType);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.AddMaterial(path, m, materialDataType);
        }

        internal static void CBDeleteMaterial(MaterialData data, MaterialDataType materialDataType)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].Delete(null, data, materialDataType);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.Delete(null, data, materialDataType);
        }


        internal static void CBDeleteMaterial(string path)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].Delete(null, path);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.Delete(null, path);
        }

        internal static void CBAddMaterials(DirectoryInfo directory, string pathToAdd)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].AddFolder(directory, pathToAdd);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.AddFolder(directory, pathToAdd);
        }

        internal static void CBMoveMaterials(string oldPath, string newPath, string parentPath)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].MoveMaterial(oldPath, newPath, parentPath);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.MoveMaterial(oldPath, newPath, parentPath);
        }

        internal static void CBRenameMaterials(string oldPath, string newPath)
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].RenameMaterial(oldPath, newPath);
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.RenameMaterial(oldPath, newPath);
        }


        internal static void CBMaterials()
        {
            for (int i = 0; i < CbMaterials.Count; i++)
            {
                CbMaterials[i].Nodes.Clear();
            }
            if (MainForm.chooseMaterialDialog != null && !MainForm.chooseMaterialDialog.IsDisposed)
                MainForm.chooseMaterialDialog.NodesClear();
        }

        internal static void CBDatabases()
        {
            for (int i = 0; i < CbDatabases.Count; i++)
            {
                CbDatabases[i].Refresh(CbDatabases[i].Data().ID);
            }
        }

        internal static void CBDatabases(Data data)
        {
            for (int i = 0; i < CbDatabases.Count; i++)
            {
                CbDatabases[i].Refresh(CbDatabases[i].Data().ID, data);
            }
        }

        internal static void CBParticles()
        {
            for (int i = 0; i < CbParticles.Count; i++)
            {
                CbParticles[i].Refresh(CbParticles[i].Data().ID);
            }
        }
        /// <summary>
        /// Refresh Database
        /// </summary>
        /// <param name="dataType"></param>
        internal static void CBRefresh(Type dataType)
        {
            if (dataType == typeof(AnimationAction))
                CBActions();
            else if (dataType == typeof(AnimationData))
                CBAnimations();
            else if (dataType == typeof(ListData))
                CBList();
            else if (dataType == typeof(AudioData))
                CBAudio();
            else if (dataType == typeof(FontData))
                CBFonts();
            else if (dataType == typeof(Data))
                CBDatabases(null);
            else if (dataType == typeof(DataProperty))
            { }
            else if (dataType == typeof(ProjectileGroupData))
                CBProjectiles();
            else if (dataType == typeof(ItemData))
                CBItems();
            else if (dataType == typeof(MenuData))
                CBMenus();
            else if (dataType == typeof(SwitchData))
                CBSwitches();
            else if (dataType == typeof(VariableData))
                CBVariables();
            else if (dataType == typeof(GlobalEventData))
                CBGlobalEvents();
            else if (dataType == typeof(StringData))
                CBStrings();
            else if (dataType == typeof(ParticleSystemData))
                CBParticles();
            else if (dataType == typeof(HeroData))
                CBHeroes();
            else if (dataType == typeof(EnemyData))
                CBEnemies();
            else if (dataType == typeof(EquipmentData))
                CBEquipments();
            else if (dataType == typeof(SkillData))
                CBSkills();
            else if (dataType == typeof(StateData))
                CBStates();
        }


        static List<SpriteFont> spriteFonts = new List<SpriteFont>();
        static TextProperties properties = new TextProperties();
        // RegEx Templates: 
        //
        // 2 Value (Variable and Text) e.g. [url=x]blah[/x]. ($) Group1 = variable, ($) Group2 = text
        //    new Regex(@"\[tag=([^\]]+)\]([^\]]+)\[\/tag\]");
        //
        // Single Value (Text only) e.g. [Tag]Text[/Tag]. $1 = text
        //     new Regex(@"\[u\](.+?)\[\/u\]");
        public static Regex stringExp = new Regex(@"\[t=(\d+)\]");
        public static Regex styleExp = new Regex(@"\[s=([^\]]+)\](.+)\[\/s\]", RegexOptions.Singleline); //@"\[s=([^\]]+)\]([^\]]+)\[\/s\]");
        public static Regex colorExp = new Regex(@"\[c=([0-9a-fA-F]{6})\](.+)\[\/c\]", RegexOptions.Singleline); //@"\[c=([0-9a-fA-F]{6})\]([^\]]+)\[\/c\]");//new Regex(@"\[c=([^\]]+)\]([^\]]+)\[\/c\]");            
        public static Regex variableExp = new Regex(@"\[v=(\d+)\]");
        public static Regex databaseExp = new Regex(@"\[d=(\d+[,]\d+[,]\d+)\]");

        public static Regex tags = new Regex(@"\[s=([^\]]+)\]|\[\/s\]|\[c=([0-9a-fA-F]{6})\]|\[\/c\]");
        /// <summary>
        /// Draw Line
        /// </summary>
        /// <param name="PointA"></param>
        /// <param name="PointB"></param>
        /// <param name="color"></param>
        /// <param name="priority"></param>
        public static void DrawLine(Vector2 PointA, Vector2 PointB, Color color, float priority, SpriteBatch spriteBatch, Texture2D texture)
        {
            int distance = (int)Vector2.Distance(PointA, PointB);
            Vector2 vector = PointB - PointA;
            Vector2 vector2 = new Vector2(1f, 0f);

            float rotation;

            if (PointA.Y > PointB.Y)
                rotation = -(float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));
            else
                rotation = (float)Math.Acos((double)(Vector2.Dot(vector, vector2) / (vector.Length() * vector2.Length())));

            spriteBatch.Draw(texture, new Rectangle((int)PointA.X, (int)PointA.Y, distance, 1), null, color, rotation, Vector2.Zero, SpriteEffects.None, priority);
        }

        #region Draw Text
        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="style"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        public static void DrawText(SpriteBatch spriteBatch, ContentManager contentManager, FontData font, FontStyleData style, string text, Vector2 position, Color color)
        {
            if (font != null)
            {
                LoadFont(font, contentManager);
                properties.Setup(Loader.SpriteFont(contentManager, style.MaterialID), color, position);

                ProcessAndDraw(spriteBatch, text);
                
                //DrawParsedText(spriteBatch, text, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
            }
        }

        private static void ProcessAndDraw(SpriteBatch spriteBatch, string text)
        {
            int styleTagCount = 0;
            Match startStyleTag = null;
            Match endStyleTag = null;
            int currentPosition = 0;
            if (text == null) text = "";
            MatchCollection tagCollection = tags.Matches(text, 0);
            foreach (Match match in tagCollection)
            {
                if (currentPosition - match.Index != 0 && styleTagCount == 0)
                    DrawParsedText(spriteBatch, text.Substring(currentPosition, match.Index - currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                if (!match.Value.Contains('/'))
                {
                    if (styleTagCount == 0)
                    {
                        currentPosition = match.Index;
                        startStyleTag = match;
                    }
                    styleTagCount++;
                }
                else
                {
                    styleTagCount--;
                    if (styleTagCount == 0)
                    {
                        currentPosition = match.Index + match.Length;
                        endStyleTag = match;
                    }
                }

                if (styleTagCount == 0 && startStyleTag != null && endStyleTag != null)
                {
                    string substr = text.Substring(startStyleTag.Index, (endStyleTag.Index + endStyleTag.Length) - startStyleTag.Index);
                    //ProcessAndDraw(spriteBatch, substr);
                    DrawParsedText(spriteBatch, substr, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
                    startStyleTag = null;
                    endStyleTag = null;
                }
            }
            if (styleTagCount != 0 || tagCollection.Count == 0 || currentPosition < text.Length)
            {
                DrawParsedText(spriteBatch, text.Substring(currentPosition), properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
            }
        }
        /// <summary>
        /// Parses and draws the given text
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="text"></param>
        /// <param name="properties"></param>
        /// <param name="styleExp"></param>
        /// <param name="colorExp"></param>
        /// <param name="variableExp"></param>
        /// <param name="databaseExp"></param>
        public static void DrawParsedText(SpriteBatch spriteBatch, string text, TextProperties properties, Regex styleExp, Regex colorExp, Regex variableExp, Regex databaseExp, Regex stringExp)
        {
            string remainingText = text;
            
            if (!string.IsNullOrEmpty(text))
            {
                while (remainingText.Length > 0)
                {
                    int i = remainingText.IndexOf('[');
                    int x = remainingText.IndexOf('\n');
                    if (x != -1 && x < i || (i == -1 && x != -1))
                    {
                        properties.NewLine();

                        string drawString = remainingText.Substring(0, x);
                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                        properties.lines[properties.currentLine].Text += drawString;

                        Vector2 textSize;
                        if (drawString != "")
                        {
                            textSize = properties.styles[properties.currentStyle].MeasureString(drawString);
                            properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X + textSize.X);
                        }
                        else
                        {
                            //textSize = properties.styles[properties.currentStyle].MeasureString("I");
                            properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X);
                        }

                        properties.currentPosition.Y += properties.lines[properties.currentLine].Height; //textSize.Y;
                        properties.currentPosition.X = properties.basePosition.X;
                        remainingText = remainingText.Remove(0, x + ('\n').ToString().Length);
                        properties.currentLine++;
                        properties.NewLine();
                    }
                    else
                    {
                        if (i > -1 && (i + 1) < remainingText.Length)
                        {
                            switch (remainingText[i + 1])
                            {
                                case 's':
                                    Match m = styleExp.Match(remainingText);
                                    int z;
                                    if (m.Groups[0].Captures.Count > 0 && int.TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        properties.tagLevel++;
                                        properties.tagIndexes.Add(m.Groups[0].Index);

                                        string drawString = remainingText.Substring(0, i);
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        if (int.Parse(m.Groups[1].Captures[0].Value) < spriteFonts.Count)
                                        {
                                            properties.styles.Add(spriteFonts[int.Parse(m.Groups[1].Captures[0].Value)]);
                                            properties.currentStyle++;
                                            properties.lines[properties.currentLine].Styles.Add(spriteFonts[int.Parse(m.Groups[1].Captures[0].Value)]);

                                            string centerText = m.Groups[2].Captures[0].Value;

                                            ProcessAndDraw(spriteBatch, centerText);
                                            //DrawParsedText(spriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                                            properties.styles.RemoveAt(properties.currentStyle);
                                            properties.currentStyle--;
                                        }
                                        else
                                        {
                                            string centerText = m.Groups[2].Captures[0].Value;
                                            ProcessAndDraw(spriteBatch, centerText);
                                            //DrawParsedText(spriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);
                                        }

                                        remainingText = remainingText.Remove(m.Groups[0].Index - drawString.Length, m.Groups[0].Length);
                                    }
                                    else
                                    {
                                        int temp = remainingText.IndexOf(']') + 1;
                                        string drawString = remainingText.Substring(0, temp);
                                        if (drawString == "" && remainingText.Length > 1)
                                        {
                                            drawString = remainingText.Substring(0, 1);
                                            temp = 1;
                                        }
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
                                        //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                        //remainingText = "";
                                    }
                                    break;
                                case 'c':
                                    m = colorExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0)
                                    {
                                        properties.tagLevel++;
                                        properties.tagIndexes.Add(m.Groups[0].Index);

                                        string drawString = remainingText.Substring(0, i);
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        properties.colors.Add(ParseHexData(m.Groups[1].Captures[0].Value));
                                        properties.currentColor++;

                                        string centerText = m.Groups[2].Captures[0].Value;
                                        
                                        ProcessAndDraw(spriteBatch, centerText);
                                        //DrawParsedText(spriteBatch, centerText, properties, styleExp, colorExp, variableExp, databaseExp, stringExp);

                                        properties.colors.RemoveAt(properties.currentColor);
                                        properties.currentColor--;

                                        remainingText = remainingText.Remove(m.Groups[0].Index - drawString.Length, m.Groups[0].Length);
                                    }
                                    else
                                    {
                                        int temp = remainingText.IndexOf(']') + 1;
                                        string drawString = remainingText.Substring(0, temp);
                                        if (drawString == "" && remainingText.Length > 1)
                                        {
                                            drawString = remainingText.Substring(0, 1);
                                            temp = 1;
                                        }
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
                                        //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                        //remainingText = "";
                                    }
                                    break;
                                case 'v':
                                    m = variableExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0 && int.TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        string drawString = remainingText.Substring(0, i);

                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        int variableID = int.Parse(m.Groups[1].Captures[0].Value);
                                        string variableValue;
                                        if (GameData.Variables.ContainsKey(variableID))
                                            variableValue = GameData.Variables[variableID].Value.ToString();
                                        else
                                            variableValue = "#NoData";

                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], variableValue, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += variableValue;

                                        Vector2 textSize2 = properties.styles[properties.currentStyle].MeasureString(variableValue);

                                        properties.currentPosition.X += textSize2.X;

                                        remainingText = remainingText.Remove(0, m.Groups[0].Length);
                                    }
                                    else
                                    {
                                        int temp = remainingText.IndexOf(']') + 1;
                                        string drawString = remainingText.Substring(0, temp);
                                        if (drawString == "" && remainingText.Length > 1)
                                        {
                                            drawString = remainingText.Substring(0, 1);
                                            temp = 1;
                                        }
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);



                                        //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                        //remainingText = "";
                                    }
                                    break;
                                case 't':
                                    m = stringExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0 && int.TryParse(m.Groups[1].Captures[0].Value, out z))
                                    {
                                        string drawString = remainingText.Substring(0, i);

                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        int stringID = int.Parse(m.Groups[1].Captures[0].Value);
                                        string stringValue;
                                        if (GameData.Strings.ContainsKey(stringID))
                                            stringValue = GameData.Strings[stringID].Value.ToString();
                                        else
                                            stringValue = "#NoData";

                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], stringValue, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += stringValue;

                                        Vector2 textSize2 = properties.styles[properties.currentStyle].MeasureString(stringValue);

                                        properties.currentPosition.X += textSize2.X;

                                        remainingText = remainingText.Remove(0, m.Groups[0].Length);
                                    }
                                    else
                                    {
                                        int temp = remainingText.IndexOf(']') + 1;
                                        string drawString = remainingText.Substring(0, temp);
                                        if (drawString == "" && remainingText.Length > 1)
                                        {
                                            drawString = remainingText.Substring(0, 1);
                                            temp = 1;
                                        }
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);



                                        //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                        //remainingText = "";
                                    }
                                    break;
                                case 'd':
                                    m = databaseExp.Match(remainingText);
                                    z = 0;
                                    if (m.Groups[0].Captures.Count > 0)
                                    {
                                        properties.tagLevel++;
                                        properties.tagIndexes.Add(m.Groups[0].Index);

                                        string drawString = remainingText.Substring(0, i);
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, i);

                                        string[] dataValues = m.Groups[1].Captures[0].Value.Split(',');

                                        if (dataValues.Length == 3)
                                        {
                                            if (dataValues[0] != "" && dataValues[1] != "" && dataValues[2] != "")
                                            {
                                                string databaseString = "";
                                                int databaseID = int.Parse(dataValues[0]);
                                                int datasetID = int.Parse(dataValues[1]);
                                                int propertyID = int.Parse(dataValues[2]);
                                                if (GameData.Databases.ContainsKey(databaseID) && GameData.Databases[databaseID].Datas.ContainsKey(datasetID) && GameData.Databases[databaseID].Datas[datasetID].Properties.Count > propertyID)
                                                {
                                                    Data db;
                                                    db = GameData.Databases[databaseID];
                                                    DataProperty prop = db.Datas[datasetID].Properties[propertyID];
                                                    if (prop.ValueType == DataType.Text || prop.ValueType == DataType.Number)
                                                        databaseString = prop.Value.ToString();
                                                    else
                                                        databaseString = "#WrongData";
                                                }
                                                else
                                                    databaseString = "#NoData";

                                                spriteBatch.DrawString(properties.styles[properties.currentStyle], databaseString, properties.currentPosition, properties.colors[properties.currentColor]);

                                                properties.lines[properties.currentLine].Text += databaseString;

                                                Vector2 databaseSize = properties.styles[properties.currentStyle].MeasureString(databaseString);
                                                properties.currentPosition.X += databaseSize.X;
                                            }
                                        }

                                        remainingText = remainingText.Remove(0, m.Groups[0].Length);
                                    }
                                    else
                                    {
                                        int temp = remainingText.IndexOf(']') + 1;
                                        string drawString = remainingText.Substring(0, temp);
                                        if (drawString == "" && remainingText.Length > 1)
                                        {
                                            drawString = remainingText.Substring(0, 1);
                                            temp = 1;
                                        }
                                        spriteBatch.DrawString(properties.styles[properties.currentStyle], drawString, properties.currentPosition, properties.colors[properties.currentColor]);

                                        properties.lines[properties.currentLine].Text += drawString;

                                        Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(drawString);

                                        properties.currentPosition.X += textSize.X;
                                        remainingText = remainingText.Remove(0, temp);
                                        //spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);
                                        //remainingText = "";
                                    }
                                    break;

                                default:
                                    int y;
                                    if (remainingText[i + 1] == '\n')
                                        y = i + 1;
                                    else
                                        y = i + 2;
                                    string drawText = remainingText.Substring(0, y);
                                    spriteBatch.DrawString(properties.styles[properties.currentStyle], drawText, properties.currentPosition, properties.colors[properties.currentColor]);

                                    properties.lines[properties.currentLine].Text += drawText;

                                    Vector2 textSize3 = properties.styles[properties.currentStyle].MeasureString(drawText);

                                    properties.currentPosition.X += textSize3.X;
                                    remainingText = remainingText.Remove(0, y);
                                    break;

                            }
                        }
                        else
                        {
                            spriteBatch.DrawString(properties.styles[properties.currentStyle], remainingText, properties.currentPosition, properties.colors[properties.currentColor]);

                            if (properties.currentLine >= properties.lines.Count)
                                properties.NewLine();

                            properties.lines[properties.currentLine].Text += remainingText;

                            Vector2 textSize = properties.styles[properties.currentStyle].MeasureString(remainingText);
                            if (remainingText != "")
                            {
                                textSize = properties.styles[properties.currentStyle].MeasureString(remainingText);
                                properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X + textSize.X);
                            }
                            else
                            {
                                properties.lines[properties.currentLine].Width = (int)(properties.currentPosition.X);
                            }
                            properties.currentPosition.X += textSize.X;
                            remainingText = "";
                        }
                    }
                }
            }
        }

        private static Color ParseHexData(string hexdata)
        {
            if (hexdata.Length != 6)
                return Color.Black;

            string rtext, gtext, btext;
            int r, g, b;

            rtext = hexdata.Substring(0, 2);
            gtext = hexdata.Substring(2, 2);
            btext = hexdata.Substring(4, 2);

            bool red = int.TryParse(rtext, System.Globalization.NumberStyles.HexNumber, null, out r);
            bool green = int.TryParse(gtext, System.Globalization.NumberStyles.HexNumber, null, out g);
            bool blue = int.TryParse(btext, System.Globalization.NumberStyles.HexNumber, null, out b);

            Color c;
            if (red && blue && green)
                c = new Color((byte)r, (byte)g, (byte)b, 255);
            else
                c = Color.Black;

            return c;
        }

        public static void LoadFont(FontData font, ContentManager contentManager)
        {
            spriteFonts.Clear();
            foreach (FontStyleData style in font.Styles)
            {
                if (style.MaterialID > -1)
                {
                    spriteFonts.Add(
                        Loader.SpriteFont(contentManager, style.MaterialID)
                        );
                }
            }
        }
        #endregion


        public static System.Drawing.Point CursorPosition;

        internal static void ClearDevice(GraphicsDevice graphicsDevice, Color color)
        {
            try
            {
                graphicsDevice.Clear(ClearOptions.Target, color, 0.0f, 0);
            }
            catch
            {
                try
                {
                    graphicsDevice.Clear(color);
                }
                catch
                {
                    try
                    {
                        graphicsDevice.Clear(ClearOptions.Stencil, color, 0.0f, 0);
                    }
                    catch
                    {
                        graphicsDevice.Clear(ClearOptions.DepthBuffer, color, 0.0f, 0);
                    }
                }
            }
        }

        public static string EgmVersion;
        public static string EngineVersion;
        public static string DataVersion;

        public static string Username;
        public static int TrialLeft;
    }

    public class TextProperties
    {
        public List<TextLine> lines = new List<TextLine>();
        public int currentLine = 0;

        public int tagLevel = 0;
        public List<int> tagIndexes = new List<int>();

        public List<Color> colors = new List<Color>();
        public int currentColor = 0;

        public List<SpriteFont> styles = new List<SpriteFont>();
        public int currentStyle = 0;

        public Vector2 currentPosition;
        public Vector2 basePosition;

        SpriteFont baseStyle;

        public TextProperties()
        {
        }

        public void Setup(SpriteFont initialStyle, Color initialColor, Vector2 initialPosition)
        {
            foreach (TextLine line in lines)
            {
                line.Reset();
            }
            currentLine = 0;
            tagLevel = 0;
            tagIndexes.Clear();
            colors.Clear();
            currentColor = 0;
            styles.Clear();
            currentStyle = 0;

            colors.Add(initialColor);
            styles.Add(initialStyle);
            baseStyle = initialStyle;
            currentPosition = basePosition = initialPosition;
            NewLine();
        }

        public void NewLine()
        {
            if (currentLine >= lines.Count)
            {
                TextLine temp = new TextLine();
                temp.Styles.Add(baseStyle);
                lines.Add(temp);
            }
            else
            {
                lines[currentLine].Reset();
                lines[currentLine].Styles.Add(baseStyle);
            }
        }

        public Vector2 GetSize()
        {
            int maxWidth = 0;
            int totalHeight = 0;
            foreach (TextLine line in lines)
            {
                totalHeight += line.Height;
                if (line.Width > maxWidth)
                    maxWidth = line.Width;
            }

            return new Vector2(maxWidth, totalHeight);
        }
    }

    public class TextLine
    {
        public List<SpriteFont> Styles = new List<SpriteFont>();
        public string Text = "";
        public int Width = 0;

        public int Height { get { return GetHeight(); } }

        public int GetHeight()
        {
            int maxHeight = 0;
            string t;

            if (Text == "")
                t = "I";
            else
                t = Text;

            foreach (SpriteFont font in Styles)
            {
                if (font.MeasureString(t).Y > maxHeight)
                    maxHeight = (int)font.MeasureString(t).Y;
            }
            return maxHeight;
        }

        internal void Reset()
        {
            Styles.Clear();
            Text = "";
            Width = 0;
        }
    }
}
