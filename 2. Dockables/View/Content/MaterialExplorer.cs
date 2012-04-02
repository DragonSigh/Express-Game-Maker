using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using EGMGame.Library;
using System.Collections;
using EGMGame.Controls;
using Microsoft.Xna.Framework.Content;
using System.Media;
using EGMGame.Dialogs;
using Microsoft.Xna.Framework;
using EGMGame.Controls.Game;
using System.Threading;
//////////////////////////////////////////////////////////////////////////
// Material Explorer 
//---------------------
// Used for importing game materials such as images, audio, videos.
//////////////////////////////////////////////////////////////////////////
namespace EGMGame.Docking.Explorers
{
    public partial class MaterialExplorer : DockContent
    {
        #region Variables
        public static ContentBuilder contentBuilder = new ContentBuilder();

        public List<MaterialData> contentToImport = new List<MaterialData>();
        public List<MaterialData> audioToImport = new List<MaterialData>();


        TreeNode clipboard;
        #endregion

        #region Constructor
        public MaterialExplorer()
        {
            try
            {
                InitializeComponent();

                toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();

                materialsList.TreeViewNodeSorter = new MaterialNodeSorter();

                contentBuilder.ImportComplete += new ContentBuilder.ImportCompleted(contentBuilder_ImportComplete);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "31x001");
            }
        }
        #endregion

        #region Events
        // readStream is the stream you need to read
        // writeStream is the stream you want to write to
        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return;
                output.Write(buffer, 0, read);
            }
        }
        /// <summary>
        /// Get Data type
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private MaterialDataType GetDataType(FileInfo file)
        {
            switch (file.Extension.ToLower())
            {
                case Extensions.PNG:
                    return MaterialDataType.Image;
                case ".jpg":
                    return MaterialDataType.Image;
                case Extensions.BMP:
                    return MaterialDataType.Image;
                case Extensions.MPT:
                    return MaterialDataType.Sound;
                case Extensions.WAV:
                    return MaterialDataType.Sound;
                case Extensions.WMA:
                    return MaterialDataType.Sound;
                case Extensions.BMPFont:
                    return MaterialDataType.Bitmap_Font;
                case Extensions.SpriteFont:
                    return MaterialDataType.Bitmap_Font;
                case Extensions.WMV:
                    return MaterialDataType.Video;
                case ".tga":
                    return MaterialDataType.Bitmap_Font;
                case ".fx":
                    return MaterialDataType.Effect_File;
            }
            return MaterialDataType.All;
        }
        //
        private string GetFileName(string name, string extension, string dir, List<MaterialData> contents)
        {
            int i = 1;
            string newName = name;
            string ext = extension;

            bool found = false;
            string exten = "";
            while (true)
            {
                foreach (MaterialData data in contents)
                {
                    if (data.Name == newName + exten)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    newName = newName + exten;
                    break;
                }
                else
                    exten = "(" + i.ToString() + ")";
                found = false;
                i++;
            }

            i = 1;
            name = newName;
            while (Global.NameExists(newName, GameData.Materials))
            {
                newName = name + "(" + i.ToString() + ")";
                i++;
            }
            return newName;
        }
        //
        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            //RefreshProjectDirectory();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Refresh Directory
        /// </summary>
        public void RefreshProjectDirectory()
        {
            try
            {
                materialsList.Nodes.Clear();
                // If Project Exists
                if (Global.Project != null)
                {
                    FindFiles(null, null);
                }
                if (contentToImport.Count > 0)
                {
                    ImportContent();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "31x002");
            }
        }

        private void FindFiles(DirectoryInfo dir, TreeNode parent)
        {
            TreeNode node;
            MaterialData material;
            if (dir == null)
            {
                dir = new DirectoryInfo(Path.Combine(Global.Project.Location, "Materials"));

                parent = new TreeNode("Materials");
                parent.Tag = new MaterialNode(dir.FullName, true, null);
                parent.ImageIndex = 0;
                parent.SelectedImageIndex = 1;
                materialsList.Nodes.Add(parent);

                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    if (d.Name != "bin" && d.Name != "obj")
                    {
                        node = new TreeNode(d.Name);
                        node.Tag = new MaterialNode(d.FullName, true, null);
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 1;
                        parent.Nodes.Add(node);
                        FindFiles(d, node);
                    }
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    if (IsMaterial(file))
                    {
                        material = GetMaterialData(file);
                        if (material != null)
                        {
                            node = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                            node.Tag = new MaterialNode(file.FullName, false, material);
                            node.ImageIndex = GetImgIndexFrom(file.Extension);
                            node.SelectedImageIndex = node.ImageIndex;
                            parent.Nodes.Add(node);
                        }
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    node = new TreeNode(d.Name);
                    node.Tag = new MaterialNode(d.FullName, true, null);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    parent.Nodes.Add(node);
                    FindFiles(d, node);
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    if (IsMaterial(file))
                    {
                        material = GetMaterialData(file);
                        if (material != null)
                        {
                            node = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                            node.Tag = new MaterialNode(file.FullName, false, material);
                            node.ImageIndex = GetImgIndexFrom(file.Extension);
                            node.SelectedImageIndex = node.ImageIndex;
                            parent.Nodes.Add(node);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Check if the file is a material
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool IsMaterial(FileInfo file)
        {
            switch (file.Extension.ToLower())
            {
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".bmp":
                    return true;
                case ".mp3":
                    return true;
                case ".wav":
                    return true;
                case ".wma":
                    return true;
                case ".wmv":
                    return true;
                case ".bmpfont":
                    return true;
                case ".spritefont":
                    return true;
                case ".tga":
                    return true;
                case ".fx":
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Get Material Data
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private MaterialData GetMaterialData(FileInfo file)
        {
            foreach (MaterialData data in GameData.Materials.Values)
            {
                if (Path.Combine(Global.Project.Location, data.FileName) == file.FullName)
                {
                    return data;
                }
            }

            // Material Doesn't Exist
            return null;
        }
        /// <summary>
        /// Add Material
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private MaterialData AddMaterial(FileInfo file)
        {
            string dir = Path.Combine(Global.Project.Location, "Materials");
            FileStream stream;
            MaterialData m = new MaterialData();
            using (stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                string name = file.Name.Replace(file.Extension, "");
                if (name.Length > 30)
                {
                    name = file.Name.Remove(30);
                }
                name = GetFileName(name, file.Extension, dir, contentToImport);
                string fname = file.FullName.Remove(file.FullName.Length - file.Name.Length) + name;

                m.Name = name;
                m.ID = Global.GetID(GameData.Materials);

                if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                    == FileAttributes.ReadOnly)
                    File.SetAttributes(file.FullName, FileAttributes.Normal);

                try
                {
                    if (!File.Exists(Path.Combine(dir, name + file.Extension)))
                        file.CopyTo(Path.Combine(dir, name + file.Extension), true);
                }
                catch (System.IO.IOException iox)
                {
                }

                file = new FileInfo(Path.Combine(dir, name + file.Extension));
                m.FileName = @"Materials\" + file.Name;


                m.DataType = GetDataType(file);

                GameData.Materials.Add(m.ID, m);

                if (m.DataType == MaterialDataType.Image)
                {
                    Bitmap bit = new Bitmap(file.FullName);
                    if (bit.Height > 1024 || bit.Width > 1084)
                    {
                        MessageBox.Show("Graphics cards with 256MB memory or lower may have problems with this image size.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                contentToImport.Add(m);
            }
        ImportContent:
            try
            {
                ImportContent();
            }
            catch
            {
                DialogResult result = MessageBox.Show("There was an error trying to import the resources. Please try again.", "Express Game Maker", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Retry)
                    goto ImportContent;

            }

            //Global.CBAddMaterial(m, m.DataType, );

            return m;
        }
        /// <summary>
        /// Get Image Index From Extension
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        private int GetImgIndexFrom(string ext)
        {
            switch (ext.ToLower())
            {
                case ".png":
                    return 3;
                case ".jpg":
                    return 3;
                case ".jpeg":
                    return 3;
                case ".bmp":
                    return 3;
                case ".txt":
                    return 4;
                case ".rar":
                    return 5;
                case ".zip":
                    return 5;
                case ".ini":
                    return 6;
                case ".mp3":
                    return 7;
                case ".ogg":
                    return 7;
                case ".wav":
                    return 7;
                case ".wma":
                    return 7;
                case ".wmv":
                    return 8;
                case ".mpg":
                    return 8;
                case ".mpeg":
                    return 8;
                case ".cs":
                    return 9;
                case ".fx":
                    return 10;
                case ".pdf":
                    return 11;
                case ".exe":
                    return 12;
                case ".bmpfont":
                    return 15;
                case ".spritefont":
                    return 15;
                case ".tga":
                    return 15;
            }
            return 2;
        }
        /// <summary>
        /// Check Valid Extensions
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckExtention(FileInfo file)
        {
            switch (file.Extension.ToLower())
            {
                case Extensions.PNG:
                    return true;
                case ".jpg":
                    return true;
                case Extensions.BMP:
                    return true;
                case Extensions.WAV:
                    return true;
                case Extensions.MPT:
                    return true;
                case Extensions.WMA:
                    return true;
                case Extensions.WMV:
                    return true;
                case Extensions.BMPFont:
                    return true;
                case Extensions.SpriteFont:
                    return true;
                case ".tga":
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Delete File
        /// </summary>
        /// <param name="fileInfo"></param>
        private void DeleteFile(FileInfo file)
        {
            switch (file.Extension)
            {
                case Extensions.Scene:
                    break;
                case Extensions.PNG:
                    break;
                case Extensions.BMP:
                    break;
                case Extensions.MPT:
                    break;
                case Extensions.WAV:
                    break;
                case Extensions.WMA:
                    break;
                case Extensions.BMPFont:
                    break;
                case Extensions.SpriteFont:
                    break;
            }
        }
        // Check if name exists
        private bool CheckPath(string path)
        {
            return Directory.Exists(path);
        }

        // Set Project
        internal void SetProject()
        {
            RefreshProjectDirectory();
        }


        /// <summary>
        /// Imports the resources in the material explorer when called.
        /// </summary>
        public void ImportContent()
        {
            MainForm.Instance.progressBar.Enabled = MainForm.Instance.progressBar.Visible = true;
            MainForm.Instance.progressBar.Style = ProgressBarStyle.Marquee;
            MainForm.Instance.statusLbl.Enabled = MainForm.Instance.statusLbl.Visible = true;
            MainForm.Instance.statusLbl.Text = "Importing Content...";
            MainForm.Instance.alphaPanel.BringToFront();
            MainForm.Instance.alphaPanel.Visible = true;
            MainForm.Instance.alphaPanel.Location = new System.Drawing.Point(0, 0);
            MainForm.Instance.alphaPanel.Size = MainForm.Instance.Size;

            if (contentToImport.Count > 1)
            {
                BuildContentDialog dialog = new BuildContentDialog();
                bwImport.RunWorkerAsync(dialog);
                dialog.ShowDialog();
            }
            else
                bwImport.RunWorkerAsync();
        }

        public void AddFileToContentBuilder(FileInfo file, MaterialData m)
        {
            string name = GetAssetName(file, m);
            switch (file.Extension.ToLower())
            {
                case ".png":
                    contentBuilder.Add(file.FullName, name, "TextureImporter", "TextureProcessor");
                    break;
                case ".jpg":
                    contentBuilder.Add(file.FullName, name, "TextureImporter", "TextureProcessor");
                    break;
                case ".jpeg":
                    contentBuilder.Add(file.FullName, name, "TextureImporter", "TextureProcessor");
                    break;
                case ".bmp":
                    contentBuilder.Add(file.FullName, name, "TextureImporter", "TextureProcessor");
                    break;
                case ".mp3":
                    contentBuilder.Add(file.FullName, name, "Mp3Importer", "SoundEffectProcessor");
                    break;
                case ".wav":
                    contentBuilder.Add(file.FullName, name, "WavImporter", "SoundEffectProcessor");
                    break;
                case ".wma":
                    contentBuilder.Add(file.FullName, name, "WmaImporter", "SoundEffectProcessor");
                    break;
                case ".wmv":
                    contentBuilder.Add(file.FullName, name, "WmvImporter", "VideoProcessor");
                    break;
                case ".bmpfont":
                    contentBuilder.Add(file.FullName, name, "TextureImporter", "FontTextureProcessor");
                    break;
                case ".spritefont":
                    contentBuilder.Add(file.FullName, name, "FontDescriptionImporter", "FontDescriptionProcessor");
                    break;
                case ".tga":
                    contentBuilder.Add(file.FullName, name, "TextureImporter", "FontTextureProcessor");
                    break;
                case ".fx":
                    contentBuilder.Add(file.FullName, name, "EffectImporter", "EffectProcessor");
                    break;
            }
        }

        public static string GetAssetName(FileInfo file, MaterialData m)
        {
            return file.Name;
        }
        #endregion

        private void bwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (contentToImport.Count > 0)
                {
                    contentBuilder.Clear();
                    foreach (MaterialData material in contentToImport)
                    {
                        FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, material.FileName));
                        AddFileToContentBuilder(file, material);
                    }
                    if (audioToImport.Count != contentToImport.Count)
                    {
                        MainForm.Instance.statusLbl.Text = "Converting files...";

                        if (e.Argument != null)
                        {
                            contentBuilder.ProgressChanged += new ContentBuilder.ProgressIsChanged(((BuildContentDialog)e.Argument).contentBuilder_ProgressChanged);
                            contentBuilder.ImportComplete += new ContentBuilder.ImportCompleted(((BuildContentDialog)e.Argument).contentBuilder_ImportComplete);

                        }
                        else
                            contentBuilder.ProgressChanged += new ContentBuilder.ProgressIsChanged(contentBuilder_ProgressChanged);
                        contentBuilder.ImportComplete += new ContentBuilder.ImportCompleted(contentBuilder_ImportComplete);
                        // Build this new texture data.
                        string buildError = contentBuilder.Build();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "31x003");
            }
        }

        void contentBuilder_ProgressChanged(object sender, int progress, int maxProgress, string name)
        {
            this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate()
            {
                MainForm.Instance.progressBar.Maximum = maxProgress;
                MainForm.Instance.progressBar.Value = (progress <= maxProgress ? progress : maxProgress);
                MainForm.Instance.statusLbl.Text = name;
            })));
        }

        void contentBuilder_ImportComplete(string buildError)
        {
            if (!String.IsNullOrEmpty(buildError))
            {
                // If the build failed, display an error message.
                MessageBox.Show(buildError, "Error");
            }
            if (audioToImport.Count == 0)
                MainForm.Instance.statusLbl.Text = "Import Complete...!";
        }

        private void bwImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainForm.Instance.progressBar.Value = e.ProgressPercentage;
        }

        private void bwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MainForm.Instance.progressBar.ProgressBar != null)
            {
                MainForm.Instance.progressBar.Enabled = MainForm.Instance.progressBar.Visible = false;
                MainForm.Instance.progressBar.Style = ProgressBarStyle.Blocks;
            }
            contentToImport.Clear();

            if (MainForm.TemplateContent.Length > 0)
            {
                CopyFolder(MainForm.TemplateContent, Global.Project.Location + @"\Content");
                MainForm.TemplateContent = "";
            }

            Thread.Sleep(10);
            MainForm.Instance.statusLbl.Text = "";
            MainForm.Instance.statusLbl.Visible = false;
            MainForm.Instance.alphaPanel.Visible = false;

            this.Show();

            if (audioToImport.Count > 0)
                ImportAudio();
        }

        private void ImportAudio()
        {
            if (Global.systemAudioProcessor != null)
                Global.systemAudioProcessor.Stop();
            MainForm.Instance.progressBar.Enabled = MainForm.Instance.progressBar.Visible = true;
            MainForm.Instance.progressBar.Style = ProgressBarStyle.Marquee;
            MainForm.Instance.statusLbl.Enabled = MainForm.Instance.statusLbl.Visible = true;
            MainForm.Instance.statusLbl.Text = "Importing Audio... Some audio features are disabled during this process.";
            Global.ImportingAudio = true;
            audioImporter.RunWorkerAsync();
        }

        private void audioImporter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (audioToImport.Count > 0)
                {
                    contentBuilder.Clear();

                    foreach (MaterialData material in audioToImport)
                    {
                        FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, material.FileName));
                        AddFileToContentBuilder(file, material);
                    }

                    // Build this new texture data.
                    string buildError = contentBuilder.BuildSlow();

                    if (!String.IsNullOrEmpty(buildError))
                    {
                        // If the build failed, display an error message.
                        MessageBox.Show(buildError, "Error");
                    }
                    MainForm.Instance.statusLbl.Text = "Import Complete...!";
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "31x0025");
            }
        }

        private void audioImporter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void audioImporter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MainForm.Instance.progressBar.ProgressBar != null)
            {
                MainForm.Instance.progressBar.Enabled = MainForm.Instance.progressBar.Visible = false;
                MainForm.Instance.progressBar.Style = ProgressBarStyle.Blocks;
            }
            audioToImport.Clear();

            MainForm.Instance.statusLbl.Text = "";
            MainForm.Instance.statusLbl.Visible = false;

            Global.ImportingAudio = false;
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

        internal void ResetProject()
        {
            Global.CBMaterials();
            RefreshProjectDirectory();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Global.CursorPosition = Cursor.Position;
            openFileDialog.Filter = "Image(*.png,*.jpg,*.bmp)|*.png;*.jpg;*.bmp|BMP Font(*.bmpfont,*.tga,*.spritefont)|*.bmpfont;*.tga;*.spritefont|Audio(*.wav,*.wma,*.mp3)|*.wav;*.wma;*.mp3|Video(*.wmv)|*.wmv|Effects(*.fx)|*.fx|All Valid Files(*.png,*.jpg,*.bmp,*.bmpfont,*.spritefont,*.tga,*.wav,*.mp3,*.wma,*.wmv,*.mp3,*.fx)|*.png;*.jpg;*.bmp;*.bmpfont;*.spritefont;*.tga;*.wav;*.wma;*.wmv;*.mp3;*.fx";
            openFileDialog.FilterIndex = 6;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                contentToImport.Clear();
                try
                {
                    int cat = 0;
                    string dir;

                    if (materialsList.SelectedNode == null) materialsList.SelectedNode = materialsList.Nodes[0];

                    TreeNode parentNode = materialsList.SelectedNode;
                    MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

                    if (mNode.IsFolder)
                        dir = mNode.Path;
                    else
                    {
                        mNode = (MaterialNode)materialsList.SelectedNode.Parent.Tag;
                        dir = mNode.Path;
                        parentNode = materialsList.SelectedNode.Parent;
                    }

                    if (openFileDialog.FileName != null)
                    {
                        List<MaterialDataType> types = new List<MaterialDataType>();
                        FileInfo file;
                        FileStream stream;
                        foreach (string path in openFileDialog.FileNames)
                        {
                            file = new FileInfo(path);
                            using (stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                            {
                                string name = file.Name.Replace(file.Extension, "");
                                if (name.Length > 30)
                                {
                                    if (DialogResult.Yes == MessageBox.Show("The material's name can not be longer then 30 characters. Rename " + '"' + file.Name + '"' + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1))
                                    {
                                        name = file.Name.Remove(30);
                                    }
                                    else
                                        continue;
                                }
                                name = GetFileName(name, file.Extension, dir, contentToImport);
                                MaterialData m = new MaterialData();
                                m.Name = name;
                                m.Category = cat;
                                m.ID = Global.GetID(GameData.Materials);

                                if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                                    == FileAttributes.ReadOnly)
                                    File.SetAttributes(file.FullName, FileAttributes.Normal);

                                try
                                {
                                    if (!File.Exists(Path.Combine(dir, name + file.Extension)))
                                        file.CopyTo(Path.Combine(dir, name + file.Extension), true);
                                }
                                catch (System.IO.IOException iox)
                                {
                                }

                                file = new FileInfo(Path.Combine(dir, name + file.Extension));
                                m.FileName = file.FullName.Replace(Global.Project.Location + @"\", "");


                                m.DataType = GetDataType(file);

                                GameData.Materials.Add(m.ID, m);

                                if (m.DataType == MaterialDataType.Image)
                                {
                                    Bitmap bit = new Bitmap(file.FullName);
                                    if (bit.Height > 1024 || bit.Width > 1084)
                                    {
                                        MessageBox.Show("Graphics cards with 256MB memory or lower may have problems with this image size.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }

                                types.Add(m.DataType);
                                //ImportFile(file);

                                TreeNode materialNode = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                                materialNode.Tag = new MaterialNode(file.FullName, false, m);
                                materialNode.ImageIndex = GetImgIndexFrom(file.Extension);
                                materialNode.SelectedImageIndex = materialNode.ImageIndex;
                                parentNode.Nodes.Add(materialNode);

                                contentToImport.Add(m);
                                materialsList.SelectedNode = materialNode;
                            }
                        }
                    ImportContent:
                        try
                        {
                            ImportContent();
                        }
                        catch
                        {
                            DialogResult result = MessageBox.Show("There was an error trying to import the resources. Please try again.", "Express Game Maker", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Retry)
                                goto ImportContent;

                        }

                        bool shown = false;
                        foreach (MaterialData newM in contentToImport)
                        {
                            Global.CBAddMaterial(((MaterialNode)parentNode.Tag).Path, newM, types);

                            if (!shown && CheckDataType(newM.DataType))
                            {
                                shown = true;
                            }
                        }

                        //contentToImport.Clear();

                        // Save Materials
                        Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);

                        materialsList.Sort();
                    }
                    this.Show();
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "s31x001");
                }
            }
        }

        private bool CheckDataType(MaterialDataType type)
        {
            switch (type)
            {
                case MaterialDataType.Sound:
                    if (MainForm.Configuration.AudioMaterailTip)
                        return false;
                    Reporter.ShowDirectAtMouse(EGMGame.Properties.Resources.music,
                        "To use your audio fast, right click on it and 'Add To Audio'.\n", "Tip: Using Audio in EGM");
                    MainForm.Configuration.AudioMaterailTip = true;
                    return true;
                case MaterialDataType.Video:
                    if (MainForm.Configuration.VideoMaterailTip)
                        return false;
                    MainForm.Configuration.VideoMaterailTip = true;
                    Reporter.ShowDirectAtMouse(EGMGame.Properties.Resources.film,
                                          "Videos can readily be used by Events.", "Tip: Using Video in EGM");
                    return true;
                case MaterialDataType.Image:
                    if (MainForm.Configuration.ImageMaterailTip)
                        return false;
                    MainForm.Configuration.ImageMaterailTip = true;
                    Reporter.ShowDirectAtMouse(EGMGame.Properties.Resources.image,
                                            "Animations: You can quickly add Animations by right clicking image and 'Add To Animations'.\n\n" +
                                           "Tilesets: Add your tileset in the Tileset editor.", "Tip: Using Images In EGM");
                    return true;
                case MaterialDataType.Bitmap_Font:
                    if (MainForm.Configuration.BitmapFontMaterailTip)
                        return false;
                    MainForm.Configuration.BitmapFontMaterailTip = true;
                    Reporter.ShowDirectAtMouse(EGMGame.Properties.Resources.font,
                                    "You can quickly add fonts by right-clicking on font and 'Add To Font'.", "Tip: Using Fonts in EGM");
                    return true;
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool save = false;
            ArrayList list = new ArrayList(materialsList.SelectedNodes);
            if (list.Count > 0 && MessageBox.Show("Delete the selected?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (TreeNode _node in list)
                {
                    if (_node != null && _node != materialsList.Nodes[0])
                    {
                        MaterialNode mNode = (MaterialNode)_node.Tag;
                        MaterialData data = mNode.Data;
                        if (mNode.IsFolder)
                        {
                            DeleteFolder(_node);
                            if (Directory.Exists(mNode.Path))
                                Directory.Delete(mNode.Path, true);
                            _node.Remove();


                            Global.CBDeleteMaterial(mNode.Path);

                            Loader.Clear();
                            save = true;
                        }
                        else
                        {
                            try
                            {
                                try
                                {
                                    if (File.Exists(Path.Combine(Global.Project.Location, data.FileName)))
                                        File.Delete(Path.Combine(Global.Project.Location, data.FileName));
                                }
                                catch { }
                                string name = GetAssetName(new FileInfo(Path.Combine(Global.Project.Location, data.FileName)), data);

                                try
                                {
                                    if (File.Exists(Path.Combine(Global.Project.Location + @"\Content", name + ".xnb")))
                                        File.Delete(Path.Combine(Global.Project.Location + @"\Content", name + ".xnb"));
                                }
                                catch { }

                            }
                            catch
                            {
                            }

                            GameData.Materials.Remove(data.ID);

                            _node.Remove();

                            Global.CBDeleteMaterial(data, data.DataType);

                            Loader.Clear();
                            save = true;
                        }
                    }
                }
                // Save Materials
                if (save)
                    Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);
            }
        }

        private void DeleteFolder(TreeNode parentNode)
        {
            MaterialNode cNode;
            MaterialData data;
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node != null)
                {
                    cNode = (MaterialNode)node.Tag;

                    if (cNode.IsFolder)
                    {
                        DeleteFolder(node);
                        if (Directory.Exists(cNode.Path))
                            Directory.Delete(cNode.Path, true);
                    }
                    else
                    {
                        data = cNode.Data;
                        try
                        {
                            if (File.Exists(Path.Combine(Global.Project.Location, data.FileName)))
                                File.Delete(Path.Combine(Global.Project.Location, data.FileName));

                            string name = GetAssetName(new FileInfo(Path.Combine(Global.Project.Location, data.FileName)), data);

                            if (File.Exists(Path.Combine(Global.Project.Location + @"\Content", name + ".xnb")))
                                File.Delete(Path.Combine(Global.Project.Location + @"\Content", name + ".xnb"));
                        }
                        catch
                        {
                        }

                        GameData.Materials.Remove(data.ID);

                        node.Remove();
                    }
                }
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            string dir;

            if (materialsList.SelectedNode == null) materialsList.SelectedNode = materialsList.Nodes[0];

            TreeNode parentNode = materialsList.SelectedNode;
            MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

            if (mNode.IsFolder)
                dir = mNode.Path;
            else
            {
                mNode = (MaterialNode)materialsList.SelectedNode.Parent.Tag;
                dir = mNode.Path;
                parentNode = materialsList.SelectedNode.Parent;
            }

            DirectoryInfo directory = new DirectoryInfo(dir);
            string name = "New Folder";
            int i = 1;
            while (Directory.Exists(Path.Combine(dir, name)))
            {
                name = "New Folder (" + i.ToString() + ")";
                i++;
            }

            directory = Directory.CreateDirectory(Path.Combine(dir, name));
            TreeNode node = new TreeNode(directory.Name);
            node.Tag = new MaterialNode(directory.FullName, true, null);
            node.ImageIndex = 0;
            node.SelectedImageIndex = 1;
            parentNode.Nodes.Insert(0, node);

            Global.CBAddMaterials(directory, mNode.Path);


            materialsList.Sort();
        }

        internal MaterialData Data()
        {
            if (materialsList.SelectedNode != null)
            {
                MaterialNode data = (MaterialNode)materialsList.SelectedNode.Tag;
                if (data.IsFolder)
                    return null;
                else
                    return data.Data;
            }
            return null;
        }

        internal TreeNode SelectedNode
        {
            get { return materialsList.SelectedNode; }
        }

        private void explorerList_ItemDrag_1(object sender, ItemDragEventArgs e)
        {
            if (!materialsList.SelectedNodes.Contains(materialsList.Nodes[0]) && materialsList.SelectedNode != null)
            {
                DoDragDrop(materialsList.SelectedNode, DragDropEffects.All);
            }
        }

        private void explorerList_MouseDown(object sender, MouseEventArgs e)
        {
            if (materialsList.GetNodeAt(e.Location) != null && !materialsList.SelectedNodes.Contains(materialsList.GetNodeAt(e.Location)))
                materialsList.SelectedNode = materialsList.GetNodeAt(e.Location);
        }

        private void explorerList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            materialPreview.SelectedMaterial = Data();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode != null && materialsList.SelectedNode != materialsList.Nodes[0])
            {
                materialsList.LabelEdit = true;
                materialsList.SelectedNode.BeginEdit();
            }
        }

        private void explorerList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode nodes = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (materialsList.SelectedNodes.Contains(nodes))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void explorerList_DragDrop(object sender, DragEventArgs e)
        {
            ArrayList nodes = null;

            if (nodes == null)
                nodes = materialsList.SelectedNodes;
            // Get Over Node
            TreeNode overNode = materialsList.GetNodeAt(materialsList.PointToClient(new System.Drawing.Point(e.X, e.Y)));

            if (!nodes.Contains(overNode))
            {
                if (overNode == null)
                    overNode = materialsList.Nodes[0];
                ArrayList _nodes = new ArrayList(nodes);
                foreach (TreeNode node in _nodes)
                {
                    MaterialNode cmNode = (MaterialNode)node.Tag;
                    MaterialNode omNode = (MaterialNode)overNode.Tag;

                    if (!omNode.IsFolder)
                    {
                        overNode = overNode.Parent;
                        omNode = (MaterialNode)overNode.Tag;
                    }

                    if (overNode != node.Parent)
                    {
                        if (cmNode.IsFolder)
                        {
                            DirectoryInfo directory = new DirectoryInfo(cmNode.Path);
                            string newPath = directory.FullName.Replace(directory.Parent.FullName, omNode.Path);
                            string oldPath = cmNode.Path;
                            try
                            {
                                directory.MoveTo(newPath);
                                node.Remove();
                                overNode.Nodes.Insert(0, node);
                                RenameChildFileFolders(node, cmNode.Path, newPath);
                                cmNode.Path = newPath;

                                Global.CBMoveMaterials(oldPath, newPath, omNode.Path);
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            FileInfo file = new FileInfo(cmNode.Path);
                            string newPath = file.FullName.Replace(file.DirectoryName, omNode.Path);
                            try
                            {
                                file.MoveTo(newPath);
                                string oldPath = cmNode.Path;
                                node.Remove();
                                overNode.Nodes.Add(node);
                                cmNode.Path = newPath;
                                cmNode.Data.FileName = newPath.Replace(Global.Project.Location + @"\", "");

                                Global.CBMoveMaterials(oldPath, newPath, omNode.Path);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                // Save Materials
                Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);

                materialsList.Sort();
            }
        }

        private void explorerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (materialsList.SelectedNode != null && materialsList.SelectedNode != materialsList.Nodes[0])
            {
                materialsList.LabelEdit = true;
                materialsList.SelectedNode.BeginEdit();
            }
        }

        private void explorerList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != materialsList.Nodes[0])
            {
                if (string.IsNullOrEmpty(e.Label))
                    e.CancelEdit = true;
                else
                {
                    MaterialNode mNode = (MaterialNode)e.Node.Tag;

                    if (mNode.IsFolder)
                    {
                        string oldPath = mNode.Path;
                        DirectoryInfo dir = new DirectoryInfo(oldPath);
                        string newPath = Path.Combine(dir.Parent.FullName, e.Label);
                        if (!Directory.Exists(newPath))
                        {
                            try
                            {
                                dir.MoveTo(newPath);
                                e.Node.Text = e.Label;
                                mNode.Path = newPath;
                                MaterialNode cNode;
                                string file;
                                foreach (TreeNode node in e.Node.Nodes)
                                {
                                    cNode = (MaterialNode)node.Tag;
                                    cNode.Path = cNode.Path.Replace(oldPath, newPath);
                                    node.SelectedImageIndex = 1;
                                    if (!cNode.IsFolder)
                                    {
                                        file = Path.Combine(Global.Project.Location, cNode.Data.FileName);
                                        cNode.Data.FileName = file.Replace(oldPath, newPath).Replace(Global.Project.Location + @"\", "");
                                        node.ImageIndex = GetImgIndexFrom(Path.GetExtension(file));
                                        node.SelectedImageIndex = node.ImageIndex;
                                    }
                                    else if (cNode.IsFolder)
                                        RenameChildFileFolders(node, oldPath, newPath);
                                }


                                Global.CBRenameMaterials(oldPath, newPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.CancelEdit = true;
                            }
                        }
                    }
                    else
                    {
                        FileInfo file = new FileInfo(mNode.Path);
                        string ext = file.Extension;
                        if (!MaterialExists(e.Label))
                        {
                            try
                            {
                                string newPath = Path.Combine(file.Directory.FullName, e.Label + ext);
                                string contentPath = Path.Combine("Content", file.Name + ".xnb");
                                string oldPath = mNode.Path;

                                file.MoveTo(newPath);

                                File.Move(Path.Combine(Global.Project.Location, contentPath), Path.Combine(Global.Project.Location, Path.Combine("Content", file.Name + ".xnb")));

                                mNode.Path = newPath;
                                mNode.Data.Name = e.Label;
                                e.Node.Text = e.Label;
                                mNode.Data.FileName = newPath.Replace(Global.Project.Location + @"\", "");


                                Global.CBRenameMaterials(oldPath, newPath);
                                //
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.CancelEdit = true;
                            }
                        }
                        else
                            e.CancelEdit = true;
                    }
                }
            }
            materialsList.LabelEdit = false;
            // Save Materials
            if (!e.CancelEdit)
                Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);

        }

        private bool MaterialExists(string name)
        {
            foreach (MaterialData data in GameData.Materials.Values)
            {
                if (data.Name.ToLower() == name.ToLower())
                    return true;
            }

            return false;
        }

        private void RenameChildFileFolders(TreeNode Node, string oldPath, string newPath)
        {
            MaterialNode cNode;
            string file;
            foreach (TreeNode node in Node.Nodes)
            {
                cNode = (MaterialNode)node.Tag;
                cNode.Path = cNode.Path.Replace(oldPath, newPath);
                node.SelectedImageIndex = 1;
                if (!cNode.IsFolder)
                {
                    file = Path.Combine(Global.Project.Location, cNode.Data.FileName);
                    cNode.Data.FileName = file.Replace(oldPath, newPath).Replace(Global.Project.Location + @"\", "");
                    node.ImageIndex = GetImgIndexFrom(Path.GetExtension(file));
                    node.SelectedImageIndex = node.ImageIndex;
                }
                RenameChildFileFolders(node, oldPath, newPath);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode != materialsList.Nodes[0])
            {

                if (clipboard != null)
                {
                    if (clipboard.Tag is MaterialNode)
                        clipboard.ForeColor = System.Drawing.Color.Black;
                }

                clipboard = materialsList.SelectedNode;
                materialsList.SelectedNode.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clipboard != null)
            {
                TreeNode node = clipboard;
                if (node.Tag is MaterialNode)
                {
                    node.ForeColor = System.Drawing.Color.Black;
                    // Get Over Node
                    TreeNode overNode = materialsList.SelectedNode;

                    if (overNode != node)
                    {
                        if (overNode == null)
                            overNode = materialsList.Nodes[0];

                        MaterialNode cmNode = (MaterialNode)node.Tag;
                        MaterialNode omNode = (MaterialNode)overNode.Tag;

                        if (!omNode.IsFolder)
                        {
                            overNode = overNode.Parent;
                            omNode = (MaterialNode)overNode.Tag;
                        }

                        if (overNode != node.Parent)
                        {
                            if (cmNode.IsFolder)
                            {
                                DirectoryInfo directory = new DirectoryInfo(cmNode.Path);
                                string newPath = directory.FullName.Replace(directory.Parent.FullName, omNode.Path);
                                string oldPath = cmNode.Path;
                                try
                                {
                                    if (!Directory.Exists(newPath))
                                        directory.MoveTo(newPath);
                                    else
                                    {
                                        MaterialNode tempMNode;
                                        foreach (TreeNode temp in overNode.Nodes)
                                        {
                                            tempMNode = (MaterialNode)temp.Tag;

                                            if (tempMNode.IsFolder && tempMNode.Path == newPath)
                                            {
                                                MessageBox.Show("A folder with this name already exists!", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                        }
                                    }
                                    node.Remove();
                                    node.SelectedImageIndex = 1;
                                    overNode.Nodes.Insert(0, node);
                                    RenameChildFileFolders(node, cmNode.Path, newPath);
                                    cmNode.Path = newPath;

                                    clipboard = null;

                                    Global.CBMoveMaterials(oldPath, newPath, omNode.Path);
                                    // Save Materials
                                    Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                FileInfo file = new FileInfo(cmNode.Path);
                                string newPath = file.FullName.Replace(file.DirectoryName, omNode.Path);
                                string oldPath = cmNode.Path;
                                try
                                {
                                    if (!File.Exists(newPath))
                                        file.MoveTo(newPath);

                                    node.Remove();
                                    overNode.Nodes.Add(node);
                                    cmNode.Path = newPath;
                                    cmNode.Data.FileName = newPath.Replace(Global.Project.Location + @"\", "");
                                    node.ImageIndex = GetImgIndexFrom(file.Extension);
                                    node.SelectedImageIndex = node.ImageIndex;
                                    // Save Materials
                                    Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);

                                    clipboard = null;
                                    Global.CBMoveMaterials(oldPath, newPath, omNode.Path);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnImportFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                contentToImport.Clear();

                try
                {
                    string dir;

                    if (materialsList.SelectedNode == null) materialsList.SelectedNode = materialsList.Nodes[0];

                    TreeNode parentNode = materialsList.SelectedNode;
                    MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

                    if (mNode.IsFolder)
                        dir = mNode.Path;
                    else
                    {
                        mNode = (MaterialNode)materialsList.SelectedNode.Parent.Tag;
                        dir = mNode.Path;
                        parentNode = materialsList.SelectedNode.Parent;
                    }

                    DirectoryInfo parentDir = new DirectoryInfo(folderBrowser.SelectedPath);
                    if (!string.IsNullOrEmpty(folderBrowser.SelectedPath) && parentDir.Exists)
                    {
                        List<MaterialDataType> types = new List<MaterialDataType>();

                        TreeNode parentDirNode;
                        foreach (DirectoryInfo dirS in parentDir.GetDirectories())
                        {
                            parentDirNode = new TreeNode(dirS.Name);
                            parentDirNode.Tag = new MaterialNode(Path.Combine(dir, dirS.Name), true, null);
                            parentDirNode.ImageIndex = 0;
                            parentDirNode.SelectedImageIndex = 1;
                            parentNode.Nodes.Add(parentDirNode);
                            if (!Directory.Exists(Path.Combine(dir, dirS.Name)))
                                Directory.CreateDirectory(Path.Combine(dir, dirS.Name));
                            ImprotFolder(dirS, parentDirNode, Path.Combine(dir, dirS.Name));
                        }

                        foreach (FileInfo file in parentDir.GetFiles())
                        {
                            ImportFile(file, dir, parentNode, types);
                        }

                    ImportContent:
                        try
                        {
                            ImportContent();
                        }
                        catch
                        {
                            DialogResult result = MessageBox.Show("There was an error trying to import the resources. Please try again.", "Express Game Maker", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Retry)
                                goto ImportContent;

                        }


                        foreach (MaterialData newM in contentToImport)
                            Global.CBAddMaterial(((MaterialNode)parentNode.Tag).Path, newM, types);

                        // contentToImport.Clear();

                        // Save Materials
                        Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex, "s31x002");
                    MessageBox.Show("There was an error trying to import the resources. Please try again.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void ImprotFolder(DirectoryInfo parentDir, TreeNode parentNode, string dir)
        {
            try
            {
                if (!string.IsNullOrEmpty(folderBrowser.SelectedPath) && parentDir.Exists)
                {
                    List<MaterialDataType> types = new List<MaterialDataType>();

                    TreeNode parentDirNode;
                    foreach (DirectoryInfo dirS in parentDir.GetDirectories())
                    {
                        parentDirNode = new TreeNode(dirS.Name);
                        parentDirNode.Tag = new MaterialNode(Path.Combine(dir, dirS.Name), true, null);
                        parentDirNode.ImageIndex = 0;
                        parentDirNode.SelectedImageIndex = 1;
                        parentNode.Nodes.Add(parentDirNode);
                        if (!Directory.Exists(Path.Combine(dir, dirS.Name)))
                            Directory.CreateDirectory(Path.Combine(dir, dirS.Name));
                        ImprotFolder(dirS, parentDirNode, Path.Combine(dir, dirS.Name));
                    }

                    foreach (FileInfo file in parentDir.GetFiles())
                    {
                        ImportFile(file, dir, parentNode, types);
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Imports File if cant be found;
        /// </summary>
        /// <param name="file"></param>
        private void ImportFile(FileInfo file, string dir, TreeNode parentNode, List<MaterialDataType> types)
        {
            if (IsMaterial(file))
            {
                FileStream stream;
                FileInfo file2;
                using (stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    string name = file.Name.Replace(file.Extension, "");
                    if (name.Length > 30)
                    {
                        if (DialogResult.Yes == MessageBox.Show("The material's name can not be longer then 30 characters. Rename " + '"' + file.Name + '"' + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1))
                        {
                            name = file.Name.Remove(30);
                        }
                        else
                            return;
                    }
                    name = GetFileName(name, file.Extension, dir, contentToImport);
                    MaterialData m = new MaterialData();
                    m.Name = name;
                    m.Category = 0;
                    m.ID = Global.GetID(GameData.Materials);

                    if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                        == FileAttributes.ReadOnly)
                        File.SetAttributes(file.FullName, FileAttributes.Normal);

                    try
                    {
                        if (!File.Exists(Path.Combine(dir, name + file.Extension)))
                            file.CopyTo(Path.Combine(dir, name + file.Extension), true);
                    }
                    catch (System.IO.IOException iox)
                    {
                    }

                    file2 = new FileInfo(Path.Combine(dir, name + file.Extension));
                    m.FileName = file2.FullName.Replace(Global.Project.Location + @"\", "");


                    m.DataType = GetDataType(file2);

                    GameData.Materials.Add(m.ID, m);

                    if (m.DataType == MaterialDataType.Image)
                    {
                        Bitmap bit = new Bitmap(file2.FullName);
                        if (bit.Height > 1024 || bit.Width > 1084)
                        {
                            MessageBox.Show("Graphics cards with 256MB memory or lower may have problems with this image size.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    types.Add(m.DataType);
                    //ImportFile(file2);

                    TreeNode materialNode = new TreeNode(Path.GetFileNameWithoutExtension(file2.FullName));
                    materialNode.Tag = new MaterialNode(file2.FullName, false, m);
                    materialNode.ImageIndex = GetImgIndexFrom(file2.Extension);
                    materialNode.SelectedImageIndex = materialNode.ImageIndex;
                    parentNode.Nodes.Add(materialNode);

                    contentToImport.Add(m);
                    materialsList.SelectedNode = materialNode;
                }
            }
        }

        private void btnImportFont_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode == null)
                materialsList.SelectedNode = materialsList.Nodes[0];

            FontGenDialog dialog = new FontGenDialog();
            dialog.ShowDialog();
        }

        internal void Import(string temp)
        {
            try
            {
                int cat = 0;
                string dir;

                if (materialsList.SelectedNode == null) materialsList.SelectedNode = materialsList.Nodes[0];

                TreeNode parentNode = materialsList.SelectedNode;
                MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

                if (mNode.IsFolder)
                    dir = mNode.Path;
                else
                {
                    mNode = (MaterialNode)materialsList.SelectedNode.Parent.Tag;
                    dir = mNode.Path;
                    parentNode = materialsList.SelectedNode.Parent;
                }

                List<MaterialDataType> types = new List<MaterialDataType>();
                FileInfo file;
                FileStream stream;
                file = new FileInfo(temp);
                using (stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    string name = file.Name.Replace(file.Extension, "");
                    if (name.Length > 30)
                    {
                        if (DialogResult.Yes == MessageBox.Show("The material's name can not be longer then 30 characters. Rename " + '"' + file.Name + '"' + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1))
                        {
                            name = file.Name.Remove(30);
                        }
                        else
                            return;
                    }
                    name = GetFileName(name, file.Extension, dir, contentToImport);
                    MaterialData m = new MaterialData();
                    m.Name = name;
                    m.Category = cat;
                    m.ID = Global.GetID(GameData.Materials);

                    if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                        == FileAttributes.ReadOnly)
                        File.SetAttributes(file.FullName, FileAttributes.Normal);

                    try
                    {
                        if (!File.Exists(Path.Combine(dir, name + file.Extension)))
                            file.CopyTo(Path.Combine(dir, name + file.Extension), true);
                    }
                    catch (System.IO.IOException iox)
                    {
                    }

                    file = new FileInfo(Path.Combine(dir, name + file.Extension));
                    m.FileName = file.FullName.Replace(Global.Project.Location + @"\", "");


                    m.DataType = GetDataType(file);

                    GameData.Materials.Add(m.ID, m);

                    if (m.DataType == MaterialDataType.Image)
                    {
                        Bitmap bit = new Bitmap(file.FullName);
                        if (bit.Height > 1024 || bit.Width > 1084)
                        {
                            MessageBox.Show("Graphics cards with 256MB memory or lower may have problems with this image size.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    types.Add(m.DataType);
                    //ImportFile(file);

                    TreeNode materialNode = new TreeNode(Path.GetFileNameWithoutExtension(file.FullName));
                    materialNode.Tag = new MaterialNode(file.FullName, false, m);
                    materialNode.ImageIndex = GetImgIndexFrom(file.Extension);
                    materialNode.SelectedImageIndex = materialNode.ImageIndex;
                    parentNode.Nodes.Add(materialNode);

                    materialsList.SelectedNode = materialNode;


                ImportContent:
                    try
                    {
                        // Import Content
                        try
                        {
                            contentBuilder.Clear();
                            file = new FileInfo(Path.Combine(Global.Project.Location, m.FileName));
                            AddFileToContentBuilder(file, m);
                            // Build this new texture data.
                            string buildError = contentBuilder.Build();

                            if (!String.IsNullOrEmpty(buildError))
                            {
                                // If the build failed, display an error message.
                                MessageBox.Show(buildError, "Error");
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.ShowLogError(ex, "31x004");
                        }
                    }
                    catch
                    {
                        DialogResult result = MessageBox.Show("There was an error trying to import the resources. Please try again.", "Express Game Maker", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Retry)
                            goto ImportContent;

                    }


                    foreach (MaterialData newM in contentToImport)
                        Global.CBAddMaterial(((MaterialNode)parentNode.Tag).Path, newM, types);

                    //contentToImport.Clear();

                    // Save Materials
                    Marshal.SaveObj(GameData.Materials, Global.Project.Location + Global.Project.DataPath + Extensions.Materials, Global.Project.Location + Global.Project.DataPath);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "s31x003");
                MessageBox.Show("There was an error trying to import the resources. Please try again.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void addToFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode != null)
            {
                CategoryDialog dialog = new CategoryDialog();
                dialog.RefreshFonts();

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;
                    if (mNode.IsFolder)
                    {
                        FontData a = null;
                        foreach (TreeNode node in materialsList.SelectedNode.Nodes)
                        {
                            mNode = (MaterialNode)node.Tag;
                            if (!mNode.IsFolder && mNode.Data.DataType == MaterialDataType.Bitmap_Font && !Global.NameExists(mNode.Data.Name, GameData.Fonts))
                            {
                                if (a == null)
                                {
                                    a = new FontData();
                                    a.Name = mNode.Data.Name;
                                    a.ID = Global.GetID(GameData.Fonts);
                                    a.Category = dialog.SelectedIndex;
                                    GameData.Fonts.Add(a.ID, a);
                                    MainForm.fontEditor.addRemoveList.AddNode(a);
                                    int index = a.ID;
                                    // History
                                    MainForm.FontHistory[MainForm.fontEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.fontEditor.DataAdded), new DataRemoveDelegate(MainForm.fontEditor.DataRemoved)));
                                }

                                a.Styles.Add(new FontStyleData() { Name = Global.GetName("Style", a.Styles), ID = Global.GetID(a.Styles), MaterialID = mNode.Data.ID });
                            }
                        }
                        Global.CBFonts();
                    }
                    else if (mNode.Data.DataType == MaterialDataType.Bitmap_Font && !Global.NameExists(mNode.Data.Name, GameData.Fonts))
                    {
                        FontData a = new FontData();
                        a.Name = mNode.Data.Name;
                        a.ID = Global.GetID(GameData.Fonts);
                        a.Category = dialog.SelectedIndex;
                        GameData.Fonts.Add(a.ID, a);
                        int index = a.ID;

                        a.Styles.Add(new FontStyleData() { Name = Global.GetName("Style", a.Styles), ID = Global.GetID(a.Styles), MaterialID = mNode.Data.ID });

                        // History
                        MainForm.FontHistory[MainForm.fontEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.fontEditor.DataAdded), new DataRemoveDelegate(MainForm.fontEditor.DataRemoved)));

                        MainForm.fontEditor.addRemoveList.AddNode(a);

                        Global.CBFonts();
                    }
                }
            }
        }

        private void addToAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode != null)
            {
                CategoryDialog dialog = new CategoryDialog();
                dialog.RefreshAudio();

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

                    if (mNode.IsFolder)
                    {
                        foreach (TreeNode node in materialsList.SelectedNode.Nodes)
                        {
                            mNode = (MaterialNode)node.Tag;
                            if (!mNode.IsFolder && mNode.Data.DataType == MaterialDataType.Sound && !Global.NameExists(mNode.Data.Name, GameData.Audios))
                            {
                                AudioData a = new AudioData();
                                a.Name = mNode.Data.Name;
                                a.ID = Global.GetID(GameData.Audios);
                                a.Category = dialog.SelectedIndex;
                                a.MaterialId = mNode.Data.ID;

                                GameData.Audios.Add(a.ID, a);
                                int index = a.ID;
                                // History
                                MainForm.AudioHistory[MainForm.audioEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.audioEditor.DataAdded), new DataRemoveDelegate(MainForm.audioEditor.DataRemoved)));

                                MainForm.audioEditor.addRemoveList.AddNode(a);
                            }
                        }
                        Global.CBAudio();
                    }
                    else if (mNode.Data.DataType == MaterialDataType.Sound && !Global.NameExists(mNode.Data.Name, GameData.Audios))
                    {
                        AudioData a = new AudioData();
                        a.Name = mNode.Data.Name;
                        a.ID = Global.GetID(GameData.Audios);
                        a.Category = dialog.SelectedIndex;
                        a.MaterialId = mNode.Data.ID;

                        GameData.Audios.Add(a.ID, a);
                        int index = a.ID;
                        // History
                        MainForm.AudioHistory[MainForm.audioEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.audioEditor.DataAdded), new DataRemoveDelegate(MainForm.audioEditor.DataRemoved)));

                        MainForm.audioEditor.addRemoveList.AddNode(a);

                        Global.CBAudio();
                    }
                }
            }
        }

        private void addToAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode != null)
            {
                CategoryDialog dialog = new CategoryDialog();
                dialog.RefreshAni();

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

                    if (!mNode.IsFolder)
                    {
                        AnimationData ani = new AnimationData();
                        // Add New Animation
                        ani.Name = mNode.Data.Name;
                        ani.ID = Global.GetID(GameData.Animations);
                        ani.Category = dialog.SelectedIndex;

                        AnimationAction action = new AnimationAction();
                        action.Name = "Default";
                        action.ID = Global.GetID(ani.Actions);

                        action.Directions = new List<List<AnimationFrame>>()
                            {
                                new List<AnimationFrame>(),
                                new List<AnimationFrame>(),
                                new List<AnimationFrame>(),
                                new List<AnimationFrame>(),
                                new List<AnimationFrame>(),
                                new List<AnimationFrame>(),
                                new List<AnimationFrame>(),
                                new List<AnimationFrame>()
                            };
                        ani.Actions.Add(action);

                        FromSpriteSheetDialog dialog1 = new FromSpriteSheetDialog();
                        dialog1.Action = action;
                        dialog1.SelectMaterial(mNode.Data);
                        dialog1.ShowDialog();
                        if (dialog1.IsOk)
                        {
                            action.CanvasSize = dialog1.Canvas;
                         
                            MainForm.animationEditor.AddAnimation(ani);
                        }

                    }
                }
            }
        }

        private void addToTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode != null)
            {
                CategoryDialog dialog = new CategoryDialog();
                dialog.RefreshTileset();

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

                    if (mNode.Data.DataType == MaterialDataType.Image && !Global.NameExists(mNode.Data.Name, GameData.Tilesets))
                    {
                        TilesetData a = new TilesetData();
                        a.Name = mNode.Data.Name;
                        a.ID = Global.GetID(GameData.Tilesets);
                        a.Category = dialog.SelectedIndex;
                        a.MaterialId = mNode.Data.ID;
                        a.Grid = new Microsoft.Xna.Framework.Vector2(Global.Project.DefaultGridSize.X, Global.Project.DefaultGridSize.Y);
                        GameData.Tilesets.Add(a.ID, a);

                        // History
                        MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.tilesetEditor.DataAdded), new DataRemoveDelegate(MainForm.tilesetEditor.DataRemoved)));

                        MainForm.tilesetEditor.addRemoveList.AddNode(a);
                        MainForm.mapEditor.PopulateTilesets();

                        Microsoft.Xna.Framework.Graphics.Texture2D tex = Loader.Texture2D(MainForm.tilesetEditor.tilesetViewer.contentManager, a.MaterialId);

                        TileData tile;
                        //Create an array to hold the data from the texture
                        uint[] data = new uint[(int)(a.Grid.X * a.Grid.Y)];
                        if (tex != null)
                        {
                            List<TileData> tiles = new List<TileData>();
                            int i = 0;
                            for (int x = 0; x < tex.Width / a.Grid.X; x++)
                            {
                                for (int y = 0; y < tex.Height / a.Grid.Y; y++)
                                {
                                    tile = null;
                                    if (i < a.Tiles.Count)
                                        tile = a.Tiles[i];
                                    if (tile != null)
                                    {
                                        tile.TilesetID = a.ID;
                                        tile.DisplayRect = new Microsoft.Xna.Framework.Rectangle(x * (int)a.Grid.X, y * (int)a.Grid.Y, (int)a.Grid.X, (int)a.Grid.Y);
                                        tile.Width = (int)a.Grid.X;
                                        tile.Height = (int)a.Grid.Y;
                                        tile.Opacity = 255;
                                        tiles.Add(tile);
                                    }
                                    else
                                    {
                                        tile = new TileData();
                                        tile.TilesetID = a.ID;
                                        tile.DisplayRect = new Microsoft.Xna.Framework.Rectangle(x * (int)a.Grid.X, y * (int)a.Grid.Y, (int)a.Grid.X, (int)a.Grid.Y);
                                        tile.Width = (int)a.Grid.X;
                                        tile.Height = (int)a.Grid.Y;
                                        tile.Opacity = 255;
                                        tiles.Add(tile);
                                    }
                                    i++;
                                }
                            }
                            a.Tiles = new List<TileData>(tiles);
                            MainForm.TilesetViewer.Setup();
                        }

                    }
                }
            }
        }

        private void addAsTileautocollisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (materialsList.SelectedNode != null)
            {
                CategoryDialog dialog = new CategoryDialog();
                dialog.RefreshTileset();
                dialog.Physics();

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bool addPhysics = dialog.AddPhysics;
                    MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;


                    if (mNode.IsFolder)
                    {
                        foreach (TreeNode node in materialsList.SelectedNode.Nodes)
                        {
                            mNode = (MaterialNode)node.Tag;
                            if (!mNode.IsFolder && mNode.Data.DataType == MaterialDataType.Image && !Global.NameExists(mNode.Data.Name, GameData.Audios))
                            {
                                TilesetData a = new TilesetData();
                                a.Name = mNode.Data.Name;
                                a.ID = Global.GetID(GameData.Tilesets);
                                a.Category = dialog.SelectedIndex;
                                a.MaterialId = mNode.Data.ID;

                                Microsoft.Xna.Framework.Graphics.Texture2D tex = Loader.Texture2D(materialPreview.contentManager, a.MaterialId);
                                if (tex != null)
                                {
                                    a.Grid = new Vector2(tex.Width, tex.Height);
                                }
                                GameData.Tilesets.Add(a.ID, a);

                                // History
                                MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.tilesetEditor.DataAdded), new DataRemoveDelegate(MainForm.tilesetEditor.DataRemoved)));

                                MainForm.tilesetEditor.addRemoveList.AddNode(a);
                                MainForm.mapEditor.PopulateTilesets();

                                TileData tile;
                                //Create an array to hold the data from the texture
                                uint[] data = new uint[(int)(a.Grid.X * a.Grid.Y)];
                                if (tex != null)
                                {
                                    List<TileData> tiles = new List<TileData>();
                                    int i = 0;
                                    for (int x = 0; x < tex.Width / a.Grid.X; x++)
                                    {
                                        for (int y = 0; y < tex.Height / a.Grid.Y; y++)
                                        {
                                            tile = null;
                                            if (i < a.Tiles.Count)
                                                tile = a.Tiles[i];
                                            if (tile != null)
                                            {
                                                tile.TilesetID = a.ID;
                                                tile.DisplayRect = new Microsoft.Xna.Framework.Rectangle(x * (int)a.Grid.X, y * (int)a.Grid.Y, (int)a.Grid.X, (int)a.Grid.Y);
                                                tile.Width = (int)a.Grid.X;
                                                tile.Height = (int)a.Grid.Y;
                                                tile.Opacity = 255;
                                                tiles.Add(tile);
                                            }
                                            else
                                            {
                                                tile = new TileData();
                                                tile.TilesetID = a.ID;
                                                tile.DisplayRect = new Microsoft.Xna.Framework.Rectangle(x * (int)a.Grid.X, y * (int)a.Grid.Y, (int)a.Grid.X, (int)a.Grid.Y);
                                                tile.Width = (int)a.Grid.X;
                                                tile.Height = (int)a.Grid.Y;
                                                tile.Opacity = 255;
                                                tiles.Add(tile);
                                            }
                                            i++;
                                        }
                                    }
                                    a.Tiles = new List<TileData>(tiles);
                                    MainForm.TilesetViewer.Setup();
                                }

                                if (addPhysics)
                                {
                                    tile = a.Tiles[0];
                                    //Transfer the texture data to the array
                                    tex.GetData(0, tile.DisplayRect, data, 0, tile.DisplayRect.Width * tile.DisplayRect.Height);

                                    //Calculate the vertices from the array
                                    FarseerPhysics.Common.Vertices verts = FarseerPhysics.Common.Vertices.CreatePolygon(data, tile.DisplayRect.Width, tile.DisplayRect.Height);

                                    //Make sure that the origin of the texture is the centroid (real center of geometry)
                                    Vector2 origin = verts.GetCentroid();
                                    Vector2 pos = new Vector2(-tile.DisplayRect.Width / 2, -tile.DisplayRect.Height / 2);
                                    verts.Translate(ref pos);
                                    FarseerPhysics.Common.Vertices.Simplify(verts);
                                    tile.Body.Clear();
                                    tile.Body.AddRange(verts);
                                    FarseerPhysics.Common.Vertices list2 = new FarseerPhysics.Common.Vertices();
                                    Vector2 vNew2 = new Vector2();
                                    foreach (Vector2 v in tile.Body)
                                    {
                                        vNew2 = v + (new Vector2(a.Grid.X / 2, a.Grid.Y / 2));
                                        list2.Add(vNew2);
                                    }
                                    tile.Body.Clear();
                                    tile.Body.AddRange(list2);

                                    FarseerPhysics.Common.Vertices.Simplify(tile.Body);
                                }
                            }
                        }
                        Global.CBAudio();
                    }
                    else if (mNode.Data.DataType == MaterialDataType.Image && !Global.NameExists(mNode.Data.Name, GameData.Tilesets))
                    {
                        TilesetData a = new TilesetData();
                        a.Name = mNode.Data.Name;
                        a.ID = Global.GetID(GameData.Tilesets);
                        a.Category = dialog.SelectedIndex;
                        a.MaterialId = mNode.Data.ID;

                        Microsoft.Xna.Framework.Graphics.Texture2D tex = Loader.Texture2D(MainForm.tilesetEditor.tilesetViewer.contentManager, a.MaterialId);
                        if (tex != null)
                        {
                            a.Grid = new Vector2(tex.Width, tex.Height);
                        }
                        GameData.Tilesets.Add(a.ID, a);

                        // History
                        MainForm.TilesetHistory[MainForm.tilesetEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.tilesetEditor.DataAdded), new DataRemoveDelegate(MainForm.tilesetEditor.DataRemoved)));

                        MainForm.tilesetEditor.addRemoveList.AddNode(a);
                        MainForm.mapEditor.PopulateTilesets();

                        TileData tile;
                        //Create an array to hold the data from the texture
                        uint[] data = new uint[(int)(a.Grid.X * a.Grid.Y)];
                        if (tex != null)
                        {
                            List<TileData> tiles = new List<TileData>();
                            int i = 0;
                            for (int x = 0; x < tex.Width / a.Grid.X; x++)
                            {
                                for (int y = 0; y < tex.Height / a.Grid.Y; y++)
                                {
                                    tile = null;
                                    if (i < a.Tiles.Count)
                                        tile = a.Tiles[i];
                                    if (tile != null)
                                    {
                                        tile.TilesetID = a.ID;
                                        tile.DisplayRect = new Microsoft.Xna.Framework.Rectangle(x * (int)a.Grid.X, y * (int)a.Grid.Y, (int)a.Grid.X, (int)a.Grid.Y);
                                        tile.Width = (int)a.Grid.X;
                                        tile.Height = (int)a.Grid.Y;
                                        tile.Opacity = 255;
                                        tiles.Add(tile);
                                    }
                                    else
                                    {
                                        tile = new TileData();
                                        tile.TilesetID = a.ID;
                                        tile.DisplayRect = new Microsoft.Xna.Framework.Rectangle(x * (int)a.Grid.X, y * (int)a.Grid.Y, (int)a.Grid.X, (int)a.Grid.Y);
                                        tile.Width = (int)a.Grid.X;
                                        tile.Height = (int)a.Grid.Y;
                                        tile.Opacity = 255;
                                        tiles.Add(tile);
                                    }
                                    i++;
                                }
                            }
                            a.Tiles = new List<TileData>(tiles);
                            MainForm.TilesetViewer.Setup();
                        }

                        if (addPhysics)
                        {
                            tile = a.Tiles[0];
                            //Transfer the texture data to the array
                            tex.GetData(0, tile.DisplayRect, data, 0, tile.DisplayRect.Width * tile.DisplayRect.Height);

                            //Calculate the vertices from the array
                            FarseerPhysics.Common.Vertices verts = FarseerPhysics.Common.Vertices.CreatePolygon(data, tile.DisplayRect.Width, tile.DisplayRect.Height);

                            //Make sure that the origin of the texture is the centroid (real center of geometry)
                            Vector2 origin = verts.GetCentroid();
                            Vector2 pos = new Vector2(-tile.DisplayRect.Width / 2, -tile.DisplayRect.Height / 2);
                            verts.Translate(ref pos);
                            FarseerPhysics.Common.Vertices.Simplify(verts);
                            tile.Body.Clear();
                            tile.Body.AddRange(verts);
                            FarseerPhysics.Common.Vertices list2 = new FarseerPhysics.Common.Vertices();
                            Vector2 vNew2 = new Vector2();
                            foreach (Vector2 v in tile.Body)
                            {
                                vNew2 = v + (new Vector2(a.Grid.X / 2, a.Grid.Y / 2));
                                list2.Add(vNew2);
                            }
                            tile.Body.Clear();
                            tile.Body.AddRange(list2);

                            FarseerPhysics.Common.Vertices.Simplify(tile.Body);
                        }
                    }
                }
            }
        }

        private void explorerMenu_Opening(object sender, CancelEventArgs e)
        {
            addToAudioToolStripMenuItem.Visible = false;
            addToFontToolStripMenuItem.Visible = false;
            addToAnimationToolStripMenuItem.Visible = false;
            addToTilesetToolStripMenuItem.Visible = false;
            addAsTileautocollisionToolStripMenuItem.Visible = false;
            if (materialsList.SelectedNode != null)
            {
                MaterialNode mNode = (MaterialNode)materialsList.SelectedNode.Tag;

                if (mNode.IsFolder)
                {
                    addToAudioToolStripMenuItem.Visible = true;
                    addToFontToolStripMenuItem.Visible = true;
                    addAsTileautocollisionToolStripMenuItem.Visible = true;
                }
                else
                {
                    if (mNode.Data.DataType == MaterialDataType.Sound)
                        addToAudioToolStripMenuItem.Visible = true;
                    else if (mNode.Data.DataType == MaterialDataType.Bitmap_Font)
                        addToFontToolStripMenuItem.Visible = true;
                    else if (mNode.Data.DataType == MaterialDataType.Image)
                    {
                        addToAnimationToolStripMenuItem.Visible = true;
                        addToTilesetToolStripMenuItem.Visible = true;
                        addAsTileautocollisionToolStripMenuItem.Visible = true;
                    }
                }
            }
        }

        private void explorerList_AfterExpand(object sender, TreeViewEventArgs e)
        {
            ((MaterialNode)e.Node.Tag).Expand = true;
        }

        private void explorerList_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            ((MaterialNode)e.Node.Tag).Expand = false;
        }


        internal void AddMaterial(string path)
        {
            Import(path);
        }

        internal void Unload()
        {
            materialPreview.Unload();
        }
    }
    [Serializable]
    public class MaterialNode
    {
        public bool IsFolder;
        public MaterialData Data;
        public string Path;
        public bool Expand;

        public MaterialNode(string path, bool folder, MaterialData data)
        {
            Path = path;
            IsFolder = folder;
            Data = data;
        }
    }

    // Create a node sorter that implements the IComparer interface.
    public class MaterialNodeSorter : IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            MaterialNode mnodex = ((MaterialNode)tx.Tag);
            MaterialNode mnodey = ((MaterialNode)ty.Tag);

            // Compare the length of the strings, returning the difference.
            if (mnodex.IsFolder && !mnodey.IsFolder)
                return 0;
            if (!mnodex.IsFolder && mnodey.IsFolder)
                return 1;
            // If they are the same length, call Compare.
            return string.Compare(tx.Text, ty.Text);
        }
    }



}
