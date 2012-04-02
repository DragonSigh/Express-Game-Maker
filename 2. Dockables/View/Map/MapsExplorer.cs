using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;
using EGMGame.Dialogs;
using System.IO;

namespace EGMGame.Docking.Explorers
{
    public partial class MapsExplorer : DockContent
    {
        internal Dictionary<int, string> cache = new Dictionary<int, string>();

        public MapsExplorer()
        {
            InitializeComponent();
        }

        private void MapsExplorer_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(Global.Project.MapsInfo, typeof(MapData));
            addRemoveList.TrySelect(Global.Project.SelectedMap);
        }

        public void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (Global.Project != null)
            {
                MapDirectoryDialog dialog = new MapDirectoryDialog();
                dialog.FileName = Global.GetName("Map", Global.Project.MapsInfo);
                int id = Global.GetID(Global.Project.MapsInfo);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Close Last Map
                    CloseSelectedMap();
                    // New Map
                    FileInfo file = new FileInfo(dialog.FileName);
                    MapData scene = new MapData();
                    scene.Gravity = Global.Project.Gravity;
                    scene.Name = file.Name.Replace(Extensions.Scene, "");
                    scene.ID = id;
                    LayerData layer = new LayerData();
                    layer.Tiles = new List<TileData>();
                    layer.IsVisible = true;
                    layer.Name = "Base";
                    scene.Layers.Add(layer);
                    scene.Grid = Global.Project.DefaultGridSize;

                    MapInfo info = new MapInfo();
                    info.Name = scene.Name;
                    info.ID = scene.ID;
                    info.Path = file.Directory.FullName.Replace(Global.Project.Location, "");

                    Marshal.SaveObj(scene, Global.Project.Location + info.Path + @"\" + info.Name + Extensions.Scene, info.Path);

                    if (Global.Project.MapsInfo.ContainsKey(scene.ID))
                        Global.Project.MapsInfo.Remove(scene.ID);
                    Global.Project.MapsInfo.Add(scene.ID, info);
                    GameData.Maps.Add(scene.ID, scene);

                    addRemoveList.AddNode(info);

                    // Setup Scene
                    MainForm.mapEditor.SetupScene(scene);
                    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Clear();

                    MainForm.NeedSave = true;
                }
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex > -1 && GameData.Maps.ContainsKey(addRemoveList.SelectedID))
                {
                    MapData scene = GameData.Maps[addRemoveList.SelectedID];
                    MapInfo info = null;
                    foreach (MapInfo i in Global.Project.MapsInfo.Values)
                    {
                        if (i.ID == scene.ID)
                            info = i;
                    }
                    if (File.Exists(Global.Project.Location + info.Path + @"\" + info.Name + Extensions.Scene))
                    {
                        File.Delete(Global.Project.Location + info.Path + @"\" + info.Name + Extensions.Scene);
                    }

                    GameData.Maps.Remove(scene.ID);
                    Global.Project.MapsInfo.Remove(scene.ID);

                    MainForm.mapEditor.DeleteScene(scene);

                    addRemoveList.RemoveSelectedNode();

                    if (cache.ContainsKey(scene.ID))
                        cache.Remove(scene.ID);
                    // Refresh Settings
                    MainForm.settingsForm.LoadSettings();

                    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Clear();

                    MainForm.NeedSave = true;
                }
                else
                {
                    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Clear();
                    Global.Project.MapsInfo.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    MainForm.settingsForm.LoadSettings();
                    MainForm.NeedSave = true;
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "28x001");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (addRemoveList.SelectedIndex > -1 && Global.Project.MapsInfo.ContainsKey(addRemoveList.SelectedID))
            {
                MapData scene;
                if (!GameData.Maps.TryGetValue(addRemoveList.SelectedID, out scene))
                {
                    Global.Project.SelectedMap = addRemoveList.Data().ID;
                    // Save last scene
                    CloseLastMap();
                    // Load Scene
                    LoadScene(addRemoveList.SelectedID);
                    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Clear();
                    MainForm.mapEditor.Show();
                }
                else if (MainForm.SelectedMap != null)
                {
                    Global.Project.SelectedMap = addRemoveList.Data().ID;
                    // Save last scene
                    CloseCurrentMap(MainForm.SelectedMap.ID);
                    // Setup Scene
                    LoadScene(addRemoveList.SelectedID);
                    GameData.Maps[scene.ID] = scene;
                    MainForm.mapEditor.SetupScene(scene);

                    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Clear();

                    MainForm.mapEditor.Show();
                }
            }
        }

        private void CloseCurrentMap(int id)
        {
            CloseMap(id);
        }
        /// <summary>
        /// Load Scene
        /// </summary>
        /// <param name="p"></param>
        private void LoadScene(int p)
        {
            MapInfo info = Global.Project.MapsInfo[p];
            MapData scene;
            string path;
            if (!cache.TryGetValue(addRemoveList.SelectedID, out path))
            {
                scene = (MapData)Marshal.LoadData<MapData>(Global.Project.Location + info.Path + @"\" + info.Name + Extensions.Scene);
                if (scene != null)
                    GameData.Maps[scene.ID] = scene;
            }
            else
            {
                scene = (MapData)Marshal.LoadData<MapData>(path);
                if (scene != null)
                    GameData.Maps[scene.ID] = scene;
            }
            // Setup Scene
            MainForm.mapEditor.SetupScene(scene);
        }
        internal void AddScene(MapInfo scene)
        {
            addRemoveList.AddNode(scene);
        }

        public void CloseLastMap()
        {
            if (MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Visible)
                MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Hide();

            List<int> ids = new List<int>();
            foreach (MapData map in GameData.Maps.Values)
            {
                ids.Add(map.ID);
            }

            foreach (int id in ids)
                if (id > -1)
                    CloseMap(id);
        }

        private void CloseSelectedMap()
        {
            if (GameData.Maps.ContainsKey(addRemoveList.SelectedID))
                CloseMap(addRemoveList.SelectedID);
        }

        public void CloseMap(int id)
        {
            if (GameData.Maps.ContainsKey(id))
            {
                MapInfo info = Global.Project.MapsInfo[id];
                // Save Map in cache
                string path = Path.Combine(Global.TempPath, info.Name + Extensions.Scene);
                MapData scene = GameData.Maps[id];
                Marshal.SaveObj(scene, path, Global.TempPath);
                // Save path in cache list
                if (cache.ContainsKey(id)) cache.Remove(id);
                cache.Add(id, path);
                // Remove map from dictionary
                GameData.Maps.Remove(id);
                // Collect Garbage
                GC.Collect();
            }
        }

        internal void SelectMap(int p)
        {
            addRemoveList.SetupList(Global.Project.MapsInfo, typeof(MapData));
            addRemoveList.TrySelect(p);
            // Select Map
            if (Global.Project.MapsInfo.ContainsKey(addRemoveList.SelectedID))
            {
                if (!GameData.Maps.ContainsKey(addRemoveList.SelectedID))
                {
                    Global.Project.SelectedMap = addRemoveList.Data().ID;
                    // Save last scene
                    CloseLastMap();
                    // Load Scene
                    LoadScene(addRemoveList.SelectedID);
                    MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Clear();
                }
            }
            else
            {
                MainForm.mapEditor.SetupScene(null);
            }
        }


        internal bool RealVisible = false;
        bool allowVisisbleChange = true;
        private void Explorer_VisibleChanged(object sender, EventArgs e)
        {
            if (allowVisisbleChange && EGMGame.Docking.Editors.MapEditor.allowActivateChange)
            {
                // RealVisible = this.Visible;
            }
        }

        internal void CheckVisibility(bool p)
        {
            allowVisisbleChange = false;
            if (this.dockState == DockState.Float)
            {
                if (p)
                {
                    if (RealVisible)
                    {
                        this.Show(MainForm.Instance.dockPanel);
                    }
                }
                else
                {
                    //RealVisible = this.Visible;
                    this.Hide();
                }
            }
            allowVisisbleChange = true;
        }

        DockState dockState = DockState.Unknown;
        private void Explorer_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState != DockState.Unknown && this.DockState != DockState.Hidden)
                this.dockState = this.DockState;
        }
        internal bool isActive = false;

        internal void ResetProject()
        {
            addRemoveList.SetupList(Global.Project.MapsInfo, typeof(MapData));
            addRemoveList.TrySelect(Global.Project.SelectedMap);
        }

        internal void CloseAllMaps()
        {
            if (MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Visible)
                MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Hide();

            List<int> ids = new List<int>();
            foreach (MapData map in GameData.Maps.Values)
            {
                ids.Add(map.ID);
            }

            foreach (int id in ids)
                if (id > -1)
                    CloseMap(id);
            MainForm.mapEditor.SetupScene(null);
        }

        internal void Clear()
        {
            cache.Clear();
        }
    }
}
