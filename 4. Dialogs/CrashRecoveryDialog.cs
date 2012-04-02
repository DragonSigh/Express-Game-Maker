using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EGMGame.Library;

namespace EGMGame.Dialogs
{
    public partial class CrashRecoveryDialog : Form
    {
        bool close = false;
        public CrashRecoveryDialog()
        {
            InitializeComponent();

            foreach (string folder in MainForm.Configuration.CrashedProjects)
            {
                recoveryList.Items.Add(folder);
            }
            if (recoveryList.Items.Count > 0)
                recoveryList.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void btnRecoverSelected_Click(object sender, EventArgs e)
        {
            if (recoveryList.SelectedIndex > -1 && recoveryList.SelectedIndex < MainForm.Configuration.CrashedProjects.Count)
            {
                string path = Path.Combine(Application.StartupPath, "Crash Recovery");
                Project project;
                bool error = false;
                int loadCount = 0;
                int mapLoadCount = 0;
                string folder = MainForm.Configuration.CrashedProjects[recoveryList.SelectedIndex];
                error = false;
                path = Path.Combine(path, folder);
                if (Directory.Exists(path))
                {
                    project = new Project();
                    try
                    {
                        project = Marshal.LoadData<Project>(path + @"\Project.egmproj");
                    }
                    catch
                    {
                        MessageBox.Show(folder + " is corrupted and can not be recovered.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        error = true;
                    }
                    if (!error)
                    {
                        // Check for corruption
                        try
                        {
                            // Load Animations
                            GameData.Animations = Marshal.LoadData<Dictionary<int, AnimationData>>(path + project.DataPath + Extensions.Animations);
                            loadCount++;
                            // Load Audios
                            GameData.Audios = Marshal.LoadData<Dictionary<int, AudioData>>(path + project.DataPath + Extensions.Audios);
                            loadCount++;
                            // Load Tilesets
                            GameData.Tilesets = Marshal.LoadData<Dictionary<int, TilesetData>>(path + project.DataPath + Extensions.Tilesets);
                            loadCount++;
                            // Load Texts
                            foreach (string lang in project.Languages)
                            {
                                GameData.Texts[lang] = Marshal.LoadData<Dictionary<int, TextData>>(project.Location + project.DataPath + CMD.TextCode(lang) + Extensions.Texts);
                            }
                            loadCount++;
                            // Load Fonts
                            GameData.Fonts = Marshal.LoadData<Dictionary<int, FontData>>(path + project.DataPath + Extensions.Fonts);
                            loadCount++;
                            // Load Databases
                            GameData.Databases = Marshal.LoadData<Dictionary<int, Data>>(path + project.DataPath + Extensions.Databases);
                            loadCount++;
                            // Load Events
                            GameData.Events = Marshal.LoadData<Dictionary<int, EventData>>(path + project.DataPath + Extensions.Events);
                            loadCount++;
                            // Load Events
                            GameData.GlobalEvents = Marshal.LoadData<Dictionary<int, GlobalEventData>>(path + project.DataPath + Extensions.GlobalEvents);
                            loadCount++;
                            // Load Variables
                            GameData.Variables = Marshal.LoadData<Dictionary<int, VariableData>>(path + project.DataPath + Extensions.Variables);
                            loadCount++;
                            // Load Switches
                            GameData.Switches = Marshal.LoadData<Dictionary<int, SwitchData>>(path + project.DataPath + Extensions.Switches);
                            loadCount++;
                            // Load Arrays
                            GameData.Lists = Marshal.LoadData<Dictionary<int, ListData>>(path + project.DataPath + Extensions.Arrays);
                            loadCount++;
                            // Load Menus
                            GameData.Menus = Marshal.LoadData<Dictionary<int, MenuData>>(path + project.DataPath + Extensions.Menus);
                            loadCount++;
                            // Load Items
                            GameData.Items = Marshal.LoadData<Dictionary<int, ItemData>>(path + project.DataPath + Extensions.Items);
                            loadCount++;
                            // Load Items
                            GameData.Materials = Marshal.LoadData<Dictionary<int, MaterialData>>(path + project.DataPath + Extensions.Materials);
                            loadCount++;
                            // Load Skins
                            GameData.Skins = Marshal.LoadData<Dictionary<int, SkinData>>(path + project.DataPath + Extensions.Skins);
                            loadCount++;
                            // Load String
                            GameData.Strings = Marshal.LoadData<Dictionary<int, StringData>>(path + project.DataPath + Extensions.Strings);
                            loadCount++;
                            // Save Heros
                            GameData.Heroes = Marshal.LoadData<Dictionary<int, HeroData>>(path + project.DataPath + Extensions.Heroes);
                            loadCount++;
                            // Save Enemies
                            GameData.Enemies = Marshal.LoadData<Dictionary<int, EnemyData>>(path + project.DataPath + Extensions.Enemies);
                            loadCount++;
                            // Save Equipment
                            GameData.Equipments = Marshal.LoadData<Dictionary<int, EquipmentData>>(path + project.DataPath + Extensions.Equipments);
                            loadCount++;
                            // Save Skills
                            GameData.Skills = Marshal.LoadData<Dictionary<int, SkillData>>(path + project.DataPath + Extensions.Skills);
                            loadCount++;
                            // Save States
                            GameData.States = Marshal.LoadData<Dictionary<int, StateData>>(path + project.DataPath + Extensions.States);
                            loadCount++;
                            // Save Combos
                            GameData.Combos = Marshal.LoadData<Dictionary<int, ComboData>>(path + project.DataPath + Extensions.Combos);
                            loadCount++;
                            // Save Projectiles
                            GameData.Projectiles = Marshal.LoadData<Dictionary<int, ProjectileGroupData>>(path + project.DataPath + Extensions.Projectiles);
                            loadCount++;
                            // Player
                            GameData.Player = Marshal.LoadData<PlayerData>(path + project.DataPath + Extensions.Player);
                            loadCount++;
                            // Check Maps
                            MapData scene;
                            foreach (MapInfo info in project.MapsInfo.Values)
                            {
                                if (File.Exists(path + @"\Maps\" + info.Name + Extensions.Scene))
                                    scene = (MapData)Marshal.LoadData<MapData>(path + @"\Maps\" + info.Name + Extensions.Scene);
                                mapLoadCount++;
                            }
                        }
                        catch
                        {
                            if (MessageBox.Show("Some of " + project.Name + "'s data is corrupted. Would you like to try transfering only non-corrupted data?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                            {
                                error = true;
                            }
                        }
                        try
                        {
                            if (!error)
                            {
                                project.Location = folder.Split('*')[1];
                                // Transfer Project File
                                File.Copy(path + @"\Project.egm", project.FullLocation, true);

                                DirectoryInfo dir = new DirectoryInfo(path + project.DataPath);

                                int errorCount = 0;
                                foreach (FileInfo file in dir.GetFiles())
                                {
                                    if (errorCount == loadCount)
                                        break;
                                    File.Copy(file.FullName, Path.Combine(project.Location + project.DataPath, file.Name), true);
                                    errorCount++;
                                }

                                dir = new DirectoryInfo(path + @"\Maps");
                                errorCount = 0;
                                foreach (MapInfo info in project.MapsInfo.Values)
                                {
                                    if (errorCount == mapLoadCount)
                                        break;
                                    if (File.Exists(path + @"\Maps\" + info.Name + Extensions.Scene))
                                        File.Copy(path + @"\Maps\" + info.Name + Extensions.Scene, project.Location + info.Path + @"\" + info.Name + Extensions.Scene, true);
                                    errorCount++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.ShowLogError(ex, "8x001");
                        }
                        // Remove From List
                        MainForm.Configuration.CrashedProjects.RemoveAt(recoveryList.SelectedIndex);
                        if (MainForm.Configuration.CrashedProjects.Count == 0)
                        {
                            close = true;
                            this.Close();
                        }
                    }
                }
            }
        }
        private void btnRecoverAll_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Crash Recovery");
            Project project;
            int loadCount = 0;
            int mapLoadCount = 0;
            foreach (string folder in MainForm.Configuration.CrashedProjects)
            {
                path = Path.Combine(path, folder);
                if (Directory.Exists(path))
                {
                    project = new Project();
                    try
                    {
                        project = Marshal.LoadData<Project>(path + @"\Project.egm");
                    }
                    catch
                    {
                        MessageBox.Show(folder + " is corrupted and can not be recovered.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        continue;
                    }
                    // Check for corruption
                    try
                    {
                        // Load Animations
                        GameData.Animations = Marshal.LoadData<Dictionary<int, AnimationData>>(path + project.DataPath + Extensions.Animations);
                        loadCount++;
                        // Load Audios
                        GameData.Audios = Marshal.LoadData<Dictionary<int, AudioData>>(path + project.DataPath + Extensions.Audios);
                        loadCount++;
                        // Load Tilesets
                        GameData.Tilesets = Marshal.LoadData<Dictionary<int, TilesetData>>(path + project.DataPath + Extensions.Tilesets);
                        loadCount++;
                        // Load Texts
                        foreach (string lang in project.Languages)
                        {
                            GameData.Texts[lang] = Marshal.LoadData<Dictionary<int, TextData>>(path + project.DataPath + CMD.TextCode(lang) + Extensions.Texts);
                        }
                        loadCount++;
                        // Load Fonts
                        GameData.Fonts = Marshal.LoadData<Dictionary<int, FontData>>(path + project.DataPath + Extensions.Fonts);
                        loadCount++;
                        // Load Databases
                        GameData.Databases = Marshal.LoadData<Dictionary<int, Data>>(path + project.DataPath + Extensions.Databases);
                        loadCount++;
                        // Load Events
                        GameData.Events = Marshal.LoadData<Dictionary<int, EventData>>(path + project.DataPath + Extensions.Events);
                        loadCount++;
                        // Load Events
                        GameData.GlobalEvents = Marshal.LoadData<Dictionary<int, GlobalEventData>>(path + project.DataPath + Extensions.GlobalEvents);
                        loadCount++;
                        // Load Variables
                        GameData.Variables = Marshal.LoadData<Dictionary<int, VariableData>>(path + project.DataPath + Extensions.Variables);
                        loadCount++;
                        // Load Switches
                        GameData.Switches = Marshal.LoadData<Dictionary<int, SwitchData>>(path + project.DataPath + Extensions.Switches);
                        loadCount++;
                        // Load Arrays
                        GameData.Lists = Marshal.LoadData<Dictionary<int, ListData>>(path + project.DataPath + Extensions.Arrays);
                        loadCount++;
                        // Load Menus
                        GameData.Menus = Marshal.LoadData<Dictionary<int, MenuData>>(path + project.DataPath + Extensions.Menus);
                        loadCount++;
                        // Load Items
                        GameData.Items = Marshal.LoadData<Dictionary<int, ItemData>>(path + project.DataPath + Extensions.Items);
                        loadCount++;
                        // Load Items
                        GameData.Materials = Marshal.LoadData<Dictionary<int, MaterialData>>(path + project.DataPath + Extensions.Materials);
                        loadCount++;
                        // Load Skins
                        GameData.Skins = Marshal.LoadData<Dictionary<int, SkinData>>(path + project.DataPath + Extensions.Skins);
                        loadCount++;
                        // Load String
                        GameData.Strings = Marshal.LoadData<Dictionary<int, StringData>>(path + project.DataPath + Extensions.Strings);
                        loadCount++;
                        // Save Heros
                        GameData.Heroes = Marshal.LoadData<Dictionary<int, HeroData>>(path + project.DataPath + Extensions.Heroes);
                        loadCount++;
                        // Save Enemies
                        GameData.Enemies = Marshal.LoadData<Dictionary<int, EnemyData>>(path + project.DataPath + Extensions.Enemies);
                        loadCount++;
                        // Save Equipment
                        GameData.Equipments = Marshal.LoadData<Dictionary<int, EquipmentData>>(path + project.DataPath + Extensions.Equipments);
                        loadCount++;
                        // Save Skills
                        GameData.Skills = Marshal.LoadData<Dictionary<int, SkillData>>(path + project.DataPath + Extensions.Skills);
                        loadCount++;
                        // Save States
                        GameData.States = Marshal.LoadData<Dictionary<int, StateData>>(path + project.DataPath + Extensions.States);
                        // Save Projectiles
                        GameData.Projectiles = Marshal.LoadData<Dictionary<int, ProjectileGroupData>>(path + project.DataPath + Extensions.States);
                        // Save Combos
                        GameData.Combos = Marshal.LoadData<Dictionary<int, ComboData>>(path + project.DataPath + Extensions.Combos);
                        loadCount++;
                        // Player
                        GameData.Player = Marshal.LoadData<PlayerData>(path + project.DataPath + Extensions.Player);
                        loadCount++;
                        // Check Maps
                        MapData scene;
                        foreach (MapInfo info in project.MapsInfo.Values)
                        {
                            if (File.Exists(path + @"\Maps\" + info.Name + Extensions.Scene))
                                scene = (MapData)Marshal.LoadData<MapData>(path + @"\Maps\" + info.Name + Extensions.Scene);
                            mapLoadCount++;
                        }
                    }
                    catch
                    {
                        if (MessageBox.Show("Some of " + project.Name + "'s data is corrupted. Would you like to try transfering only non-corrupted data?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                        }
                        else
                        {
                            continue;
                        }
                    }
                    try
                    {
                        project.Location = folder.Split('*')[1];
                        // Transfer Project File
                        File.Copy(path + @"\Project.egm", project.FullLocation, true);

                        DirectoryInfo dir = new DirectoryInfo(path + project.DataPath);

                        int errorCount = 0;
                        foreach (FileInfo file in dir.GetFiles())
                        {
                            if (errorCount == loadCount)
                                break;
                            File.Copy(file.FullName, Path.Combine(project.Location + project.DataPath, file.Name), true);
                            errorCount++;
                        }

                        dir = new DirectoryInfo(path + @"\Maps");
                        errorCount = 0;
                        foreach (MapInfo info in project.MapsInfo.Values)
                        {
                            if (errorCount == mapLoadCount)
                                break;
                            if (File.Exists(path + @"\Maps\" + info.Name + Extensions.Scene))
                                File.Copy(path + @"\Maps\" + info.Name + Extensions.Scene, project.Location + info.Path + @"\" + info.Name + Extensions.Scene, true);
                            errorCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.ShowLogError(ex, "8x002");
                    }
                }
            }
            Marshal.Clear();
            // Remove All From List
            MainForm.Configuration.CrashedProjects.Clear();
            close = true;
            this.Close();
        }

        private void btnDiscardSelected_Click(object sender, EventArgs e)
        {
            if (recoveryList.SelectedIndex > -1 && recoveryList.SelectedIndex < MainForm.Configuration.CrashedProjects.Count)
            {
                if (MessageBox.Show("Are you sure you want to discard selected recovered project?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    MainForm.Configuration.CrashedProjects.RemoveAt(recoveryList.SelectedIndex);
                    if (MainForm.Configuration.CrashedProjects.Count == 0)
                    {
                        close = true;
                        this.Close();
                    }
                }
            }
        }

        private void btnDiscardAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to discard all recovered projects?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                MainForm.Configuration.CrashedProjects.Clear();
                close = true;
                this.Close();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !close;

            base.OnClosing(e);
        }
    }
}
