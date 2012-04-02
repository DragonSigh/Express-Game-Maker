using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.IO;

namespace EGMGame.Dialogs
{
    public partial class NewProjectWiz : Form
    {
        #region "Fields"
        // Templates
        public Project project;
        // Warning Shown
        bool warningShown = false;
        #endregion

        #region "Constructor"
        public NewProjectWiz()
        {
            InitializeComponent();

            defaultPlatform.SelectedIndex = 0;

            if (File.Exists(Path.Combine(Application.StartupPath, "Game.ico")))
            {
                iconPic.ImageLocation = Path.Combine(Application.StartupPath, "Game.ico");
                iconBox.Text = Path.Combine(Application.StartupPath, "Game.ico");
            }
            if (string.IsNullOrEmpty(MainForm.Configuration.LastProjectDirectory))
                MainForm.Configuration.LastProjectDirectory = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\EGM Projects";

            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\EGM Projects";
            if (MainForm.Configuration.LastProjectDirectory == path && !Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        #endregion

        #region "Events"
        // This Load
        private void NewPrjDialog_Load(object sender, EventArgs e)
        {
            try
            {
                locationTxt.Text = folderBrwD.SelectedPath = MainForm.Configuration.LastProjectDirectory;
                // Get All Templates
                DirectoryInfo dir;
                Project ptemp = new Project();
                ListViewItem item;
                foreach (string fTemp in Directory.GetDirectories(Application.StartupPath + @"\Express Templates"))
                {
                    // Get Template
                    dir = new DirectoryInfo(fTemp);
                    ptemp = Marshal.LoadData<Project>(fTemp + @"\Project" + Extensions.Project);
                    ptemp.Location = Application.StartupPath + @"\Express Templates" + @"\" + dir.Name;
                    // Add Directories
                    AddDirectories(ptemp, dir);
                    // Add To Listview
                    Icon ico = new System.Drawing.Icon(Path.Combine(ptemp.Location, ptemp.Icon));
                    imageList.Images.Add(ico);
                    item = new ListViewItem(ptemp.Name, imageList.Images.Count - 1);
                    item.Tag = ptemp;
                    listView.Items.Add(item);
                }
                listView.Items[0].Selected = true;
                listView.Select();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "35x001");
            }
        }

        private void AddDirectories(Project temp, DirectoryInfo dir)
        {
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                AddDirectories(temp, d);
            }
        }

        private void LoadTemplate(Project temp)
        {
            try
            {
                // Load Animations
                GameData.Animations = Marshal.LoadData<Dictionary<int, AnimationData>>(temp.Location + temp.DataPath + Extensions.Animations);
                // Load Audios
                GameData.Audios = Marshal.LoadData<Dictionary<int, AudioData>>(temp.Location + temp.DataPath + Extensions.Audios);
                // Load Tilesets
                GameData.Tilesets = Marshal.LoadData<Dictionary<int, TilesetData>>(temp.Location + temp.DataPath + Extensions.Tilesets);
                // Load Texts
                foreach (string lang in temp.Languages)
                {
                    GameData.Texts[lang] = Marshal.LoadData<Dictionary<int, TextData>>(temp.Location + temp.DataPath + CMD.TextCode(lang) + Extensions.Texts);
                }
                // Load Fonts
                GameData.Fonts = Marshal.LoadData<Dictionary<int, FontData>>(temp.Location + temp.DataPath + Extensions.Fonts);
                // Load Databases
                GameData.Databases = Marshal.LoadData<Dictionary<int, Data>>(temp.Location + temp.DataPath + Extensions.Databases);
                // Load Events
                GameData.Events = Marshal.LoadData<Dictionary<int, EventData>>(temp.Location + temp.DataPath + Extensions.Events);
                // Load Events
                GameData.GlobalEvents = Marshal.LoadData<Dictionary<int, GlobalEventData>>(temp.Location + temp.DataPath + Extensions.GlobalEvents);
                // Load Variables
                GameData.Variables = Marshal.LoadData<Dictionary<int, VariableData>>(temp.Location + temp.DataPath + Extensions.Variables);
                // Load Switches
                GameData.Switches = Marshal.LoadData<Dictionary<int, SwitchData>>(temp.Location + temp.DataPath + Extensions.Switches);
                // Load Arrays
                GameData.Lists = Marshal.LoadData<Dictionary<int, ListData>>(temp.Location + temp.DataPath + Extensions.Arrays);
                // Load Menus
                GameData.Menus = Marshal.LoadData<Dictionary<int, MenuData>>(temp.Location + temp.DataPath + Extensions.Menus);
                // Load Items
                GameData.Items = Marshal.LoadData<Dictionary<int, ItemData>>(temp.Location + temp.DataPath + Extensions.Items);
                // Load Items
                GameData.Materials = Marshal.LoadData<Dictionary<int, MaterialData>>(temp.Location + temp.DataPath + Extensions.Materials);
                // Load Skins
                GameData.Skins = Marshal.LoadData<Dictionary<int, SkinData>>(temp.Location + temp.DataPath + Extensions.Skins);
                // Load String
                GameData.Strings = Marshal.LoadData<Dictionary<int, StringData>>(temp.Location + temp.DataPath + Extensions.Strings);
                // Load String
                GameData.Projectiles = Marshal.LoadData<Dictionary<int, ProjectileGroupData>>(temp.Location + temp.DataPath + Extensions.Projectiles);
                // Load Combo
                GameData.Combos = Marshal.LoadData<Dictionary<int, ComboData>>(temp.Location + temp.DataPath + Extensions.Combos);
                // Save Heros
                GameData.Heroes = Marshal.LoadData<Dictionary<int, HeroData>>(temp.Location + temp.DataPath + Extensions.Heroes);
                // Save Enemies
                GameData.Enemies = Marshal.LoadData<Dictionary<int, EnemyData>>(temp.Location + temp.DataPath + Extensions.Enemies);
                // Save Equipment
                GameData.Equipments = Marshal.LoadData<Dictionary<int, EquipmentData>>(temp.Location + temp.DataPath + Extensions.Equipments);
                // Save Skills
                GameData.Skills = Marshal.LoadData<Dictionary<int, SkillData>>(temp.Location + temp.DataPath + Extensions.Skills);
                // Load Particles
                GameData.ParticleSystems = Marshal.LoadData<Dictionary<int, ParticleSystemData>>(temp.Location + temp.DataPath + Extensions.ParticleSystems);
                // Save States
                GameData.States = Marshal.LoadData<Dictionary<int, StateData>>(temp.Location + temp.DataPath + Extensions.States);
                // Player
                GameData.Player = Marshal.LoadData<PlayerData>(temp.Location + temp.DataPath + Extensions.Player);

                temp.SourceFiles = Marshal.LoadData<List<SourceFile>>(temp.Location + temp.DataPath + Extensions.Source);

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "37x001");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            bool invalid = !CheckInvalidCharacters(nameTxt.Text);
            if (nameTxt.Text.Length > 0 && nameTxt.Text.Length <= 50 && !invalid && Directory.Exists(locationTxt.Text))
            {
                bool cont = true;
                if (warningShown == false)
                {
                    if (directoryChk.Checked && Directory.Exists(locationTxt.Text + "\\" + nameTxt.Text))
                    {
                        cont = (MessageBox.Show("A project folder with the same name already exists in this location. Would you like to overwrite it?", "Express Game Maker - Create a new project", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes);
                    }
                    else if (directoryChk.Checked && File.Exists(locationTxt.Text + "\\" + nameTxt.Text + "\\" + nameTxt.Text + Extensions.Project))
                    {
                        cont = (MessageBox.Show("A project folder with the same name already exists in this location. Would you like to overwrite it?", "Express Game Maker - Create a new project", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes);

                    }
                    else if (!directoryChk.Checked && File.Exists(locationTxt.Text + "\\" + nameTxt.Text + Extensions.Project))
                    {
                        cont = (MessageBox.Show("A project folder with the same name already exists in this location. Would you like to overwrite it?", "Express Game Maker - Create a new project", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes);

                        //warningShown = true;
                        //cont = false;
                        //Reporter.ShowWarning(nextBtn, "Project Location", "A project with the same name already exists in this folder! If continued, it will be deleted!");
                    }
                }
                if (cont) tabControl.SelectedIndex += 1;
            }
            else if (nameTxt.Text.Length <= 0)
            {
                Reporter.ShowError(nameTxt, "Project Name", "Please enter a project name!");
            }
            else if (!Directory.Exists(locationTxt.Text))
            {
                Reporter.ShowError(locationTxt, "Project Location", "Please enter a project location!");
            }
            else if (nameTxt.Text.Length > 50)
            {
                Reporter.ShowError(nameTxt, "Project Name", "Project name must be less than 50 characters!");
            }
            else if (invalid)
            {
                string s = "";
                for (int i = 0; i < Path.GetInvalidFileNameChars().Length; i++)
                {
                    s += Path.GetInvalidFileNameChars()[i].ToString() + " ";
                }
                Reporter.ShowError(nameTxt, "Project Name", "Project name must not contain symbols or the following characters:\n" + " < > : * ? \\ / " + "\"");
            }
        }

        private bool CheckInvalidCharacters(string str)
        {
            string s = "";
            for (int i = 0; i < Path.GetInvalidFileNameChars().Length; i++)
            {
                s += Path.GetInvalidFileNameChars()[i].ToString() + " ";
                if (str.Contains(Path.GetInvalidFileNameChars()[i]))
                    return false;
            }

            return true;
        }


        private void backBtn_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex -= 1;
        }

        private void nextDBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            tabControl.SelectedTab = tabPage2;
        }

        private void backDBtn_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex -= 1;
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (project != null)
                {
                    if (locationTxt.Text[locationTxt.Text.Length - 1] != '\\')
                        locationTxt.Text += @"\";
                    MainForm.Configuration.LastProjectDirectory = locationTxt.Text;
                    if (listView.SelectedItems[0].Tag != null)
                    {
                        IsTemplate = true;

                        MainForm.Instance.progressBar.Enabled = MainForm.Instance.progressBar.Visible = true;
                        MainForm.Instance.progressBar.Style = ProgressBarStyle.Marquee;
                        MainForm.Instance.statusLbl.Enabled = MainForm.Instance.statusLbl.Visible = true;
                        MainForm.Instance.statusLbl.Text = "Setting Up Template...";
                        tabControl.Enabled = false;

                        workerExport.RunWorkerAsync();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
                else
                {
                    Reporter.ShowError(listView, "Template List", "Please select a template!");
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "37x002");
            }
        }

        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }


        private void nameTxt_Click(object sender, EventArgs e)
        {
            if (nameTxt.Tag == null)
            {
                nameTxt.Text = "";
            }
            nameTxt.Tag = true;
        }

        private void nameTxt_Leave(object sender, EventArgs e)
        {
            //if (directoryChk.Checked && Directory.Exists(locationTxt.Text  + @"\" + "\\" + nameTxt.Text))
            //{
            //    Reporter.ShowWarning(locationTxt, "Project Location", "A project folder with the same name already exists in this location! If continued, it will be deleted!");
            //}
            //if (directoryChk.Checked && File.Exists(locationTxt.Text  + @"\" + "\\" + nameTxt.Text + "\\" + nameTxt.Text + Extensions.Project))
            //{
            //    Reporter.ShowWarning(locationTxt, "Project Location", "A project with the same name already exists in this folder! If continued, it will be deleted!");
            //}
            //if (!directoryChk.Checked && File.Exists(locationTxt.Text  + @"\" + "\\" + nameTxt.Text + Extensions.Project))
            //{
            //    Reporter.ShowWarning(locationTxt, "Project Location", "A project with the same name already exists in this folder! If continued, it will be deleted!");
            //}
        }

        private void directoryChk_CheckedChanged(object sender, EventArgs e)
        {
            if (directoryChk.Checked && Directory.Exists(locationTxt.Text + @"\" + "\\" + nameTxt.Text))
            {
                Reporter.ShowWarning(locationTxt, "Project Location", "A project folder with the same name already exists in this location! If continued, it will be deleted!");
            }
            if (directoryChk.Checked && File.Exists(locationTxt.Text + @"\" + "\\" + nameTxt.Text + "\\" + nameTxt.Text + Extensions.Project))
            {
                Reporter.ShowWarning(locationTxt, "Project Location", "A project with the same name already exists in this folder! If continued, it will be deleted!");
            }
            if (!directoryChk.Checked && File.Exists(locationTxt.Text + @"\" + "\\" + nameTxt.Text + Extensions.Project))
            {
                Reporter.ShowWarning(locationTxt, "Project Location", "A project with the same name already exists in this folder! If continued, it will be deleted!");
            }
        }

        // Browse Folders
        private void browseBtn_Click(object sender, EventArgs e)
        {
            folderBrwD.ShowDialog();
            locationTxt.Text = folderBrwD.SelectedPath;
            if (directoryChk.Checked && Directory.Exists(locationTxt.Text + @"\" + "\\" + nameTxt.Text))
            {
                Reporter.ShowWarning(locationTxt, "Project Location", "A project folder with the same name already exists in this location! If continued, it will be deleted!");
            }
            if (directoryChk.Checked && File.Exists(locationTxt.Text + @"\" + "\\" + nameTxt.Text + "\\" + nameTxt.Text + Extensions.Project))
            {
                Reporter.ShowWarning(locationTxt, "Project Location", "A project with the same name already exists in this folder! If continued, it will be deleted!");
            }
            if (!directoryChk.Checked && File.Exists(locationTxt.Text + @"\" + "\\" + nameTxt.Text + Extensions.Project))
            {
                Reporter.ShowWarning(locationTxt, "Project Location", "A project with the same name already exists in this folder! If continued, it will be deleted!");
            }
        }

        // When a new item is selected
        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item != null && e.IsSelected)
            {
                if (e.Item.Tag != null)
                {
                    Project pt = (Project)e.Item.Tag;
                    project = pt;
                    tDesc.Text = pt.Description;
                }
                else
                {
                    Project pt = new Project();
                    project = pt;
                    tDesc.Text = "A blank project.";
                }
            }
        }

        #endregion

        private void iconBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo iconFile = new FileInfo(openFileDialog.FileName);

                if (iconFile.Exists)
                {
                    iconPic.ImageLocation = iconFile.FullName;
                    iconBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void NewProjectWiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Abort)
            {
                e.Cancel = true;
            }
        }

        private void workerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadTemplate(project);
            TemplateContent = project.Location + @"\Content";
            try
            {
                if (Directory.Exists(locationTxt.Text + nameTxt.Text + @"\Content"))
                {
                    foreach (string p in Directory.GetFiles(locationTxt.Text + nameTxt.Text + @"\Content"))
                    {
                        if (Path.GetExtension(p).ToLower() == ".xnb")
                            File.Delete(p);
                    }
                }
            }
            catch (Exception ex)
            { Error.ShowLogError(ex, "37x003"); }
            CopyFolder(project.Location, locationTxt.Text + nameTxt.Text);
            project.Location = locationTxt.Text + nameTxt.Text;
        }

        private void workerExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MainForm.Instance.progressBar.Enabled = MainForm.Instance.progressBar.Visible = false;
            MainForm.Instance.progressBar.Style = ProgressBarStyle.Blocks;
            MainForm.Instance.statusLbl.Text = "";
            MainForm.Instance.statusLbl.Visible = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region "Methods"

        #endregion


        public string TemplateContent = "";
        public bool IsTemplate = false;

    }
}
