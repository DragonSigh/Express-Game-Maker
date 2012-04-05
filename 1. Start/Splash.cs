//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Cache;

namespace EGMGame
{
    public partial class Splash : Form
    {
        #region Vars & Constructor
        List<UpdateFile> updateCue = new List<UpdateFile>();
        List<UpdateFile> downloadCue = new List<UpdateFile>();
        UpdateFile currentFile;
        public UpdateProcess CurrentProcess;
        public string EGMNewVersion = "";
        public string UpdaterNewVersion = "";

        string saveDirectory = Application.StartupPath + "/Temp/";

        public enum UpdateProcess
        {
            Download,
            Update
        }

        Int64 BytesSinceLastTick = 0;
        Int64 CurrentFileBytes = 0;
        Int64 CurrentFileTotalBytes = 0;
        string updaterVersion = "";
        string egmVersion = "";

        public Splash()
        {
            LoadVersions();
            InitializeComponent();
        }
        #endregion

        #region UI Methods
        private void UpdateStatus(string status)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { UpdateStatus(status); })));
            }
            else
            {
                lblLoadingMessage.Text = status + "...";
            }
        }
        public void UpdateLoadingMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { UpdateLoadingMessage(message); })));
            }
            else
            {
                lblLoadingMessage.Text = message;
            }
        }

        public void UpdateProgressBarStyle(ProgressBarStyle style)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { UpdateProgressBarStyle(style); })));
            }
            else
            {
                pbProgress.Style = style;
            }
        }
        #endregion

        private void LoadVersions()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "/version.xml");

            if (doc.SelectSingleNode("config") == null)
            {
                XmlNode root = doc.CreateNode(XmlNodeType.Element, "config", "");
                doc.AppendChild(root);
            }

            if (doc.SelectSingleNode("config/version") == null)
            {
                XmlNode root = doc.SelectSingleNode("config");
                XmlNode versionNode = doc.CreateNode(XmlNodeType.Element, "version", "");
                versionNode.InnerText = "1.0.0";
                root.AppendChild(versionNode);
                doc.Save(Application.StartupPath + "/version.xml");
            }
            if (doc.SelectSingleNode("config/updater") == null)
            {
                XmlNode root = doc.SelectSingleNode("config");
                XmlNode updaterNode = doc.CreateNode(XmlNodeType.Element, "updater", "");
                updaterNode.InnerText = "1.0.0";
                root.AppendChild(updaterNode);
                doc.Save(Application.StartupPath + "/version.xml");
            }

            if (doc.SelectSingleNode("config/engine") == null)
            {
                XmlNode root = doc.SelectSingleNode("config");
                XmlNode updaterNode = doc.CreateNode(XmlNodeType.Element, "engine", "");
                updaterNode.InnerText = "1.0.0";
                root.AppendChild(updaterNode);
                doc.Save(Application.StartupPath + "/version.xml");
            }

            Global.EgmVersion = egmVersion = doc.SelectSingleNode("config/version").InnerText;
            updaterVersion = doc.SelectSingleNode("config/updater").InnerText;
            Global.EngineVersion = doc.SelectSingleNode("config/engine").InnerText;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            lblVersionText.Text = "v" + egmVersion;
            if (CheckValidated())
            {
                UPDATERupdateCheckWorker.RunWorkerAsync();
            }
            else
            {
                allowClose = true; this.Close();
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        #region Pre-Req's
        private bool EGMUpdateRequired(string versionString)
        {
            Version v = new Version(versionString);
            int test = v.CompareTo(new Version(egmVersion));
            return (test > 0);
        }
        private bool UpdaterUpdateRequired(string versionString)
        {
            Version v = new Version(versionString);
            int test = v.CompareTo(new Version(updaterVersion));
            return (test > 0);
        }

        private bool CheckValidated()
        {
            return true;
            //if (!String.IsNullOrEmpty(GameStateManager.LoadData("GUID")) && !String.IsNullOrEmpty(GameStateManager.LoadData("ProductKey")))
            //{
            //    return true;
            //}
            //else return false;
        }
        #endregion

        #region Update Checker
        private void updateCheckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateLoadingMessage("Checking for updates...");
                if (!File.Exists("Updater.exe"))
                {
                    MessageBox.Show("Updater utility not found!");
                    allowClose = true;
                    this.Close();
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }

                XmlDocument doc = new XmlDocument();
#if DEBUG
                doc.Load("http://update.expressgamemaker.com/manifest.xml");
#elif BETA
                doc.Load("http://update.expressgamemaker.com/manifest.xml");
#else
                doc.Load("http://update.expressgamemaker.com/manifest.xml");
#endif
                string version = doc.SelectSingleNode("update/version").InnerText;
                if (EGMUpdateRequired(version))
                {
                    ShowUpdateFound(version);
                }
                else
                {
                    UpdateLoadingMessage("Loading Express Game Maker...");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ShowUpdateFound(string version)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { ShowUpdateFound(version); })));
            }
            else
            {
                System.Windows.Forms.DialogResult result = MessageBox.Show("An update was found! Do you wish to update EGM to version " + version + "?", "Update available", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    UpdateLoadingMessage("Restarting...");
                    ProcessStartInfo oStartInfo = new ProcessStartInfo();
                    oStartInfo.FileName = "Updater.exe";
                    oStartInfo.Arguments = Global.EgmVersion;
                    Process.Start(oStartInfo);
                    allowClose = true;
                    this.Close();
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }

        private void updateCheckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            allowClose = true; this.Close();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion

        #region UPDATE Update Check
        private void UPDATERupdateCheckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateStatus("Checking for Updater Updates");
                XmlDocument doc = new XmlDocument();
#if DEBUG
                doc.Load("http://update.expressgamemaker.com/updater/manifest.xml");
#elif BETA
                doc.Load("http://update.expressgamemaker.com/updater/manifest.xml");
#else
                doc.Load("http://update.expressgamemaker.com/updater/manifest.xml");
#endif

                UpdaterNewVersion = doc.SelectSingleNode("update/version").InnerText;
                if (!UpdaterUpdateRequired(UpdaterNewVersion))
                    return;

                XmlNodeList fileNodeList = doc.GetElementsByTagName("file");
                foreach (XmlNode node in fileNodeList)
                {
                    UpdateFile file = new UpdateFile();
                    file.Version = node.Attributes["version"].Value;
                    if (!UpdaterUpdateRequired(file.Version))
                        continue;
                    file.Type = (FileType)Enum.Parse(typeof(FileType), node.Attributes["type"].Value, true);
                    file.OperationType = (FileOperationType)Enum.Parse(typeof(FileOperationType), node.Attributes["operationtype"].Value, true);

                    file.FileName = node.SelectSingleNode("filename").InnerText;
                    file.URL = ParseUrl(node.SelectSingleNode("url").InnerText);
                    file.Directory = node.SelectSingleNode("directory").InnerText;
                    if (file.OperationType == FileOperationType.Update)
                        downloadCue.Add(file);
                    updateCue.Add(file);
                }
            }
            catch (Exception ex) { MessageBox.Show("The update process failed! Please contact support. \r\n\r\n" + ex.Message); }
        }

        private void UPDATERupdateCheckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (downloadCue.Count > 0)
            {
                currentFile = downloadCue[0];
                UpdateStatus("Downloading Updater Update");
                UPDATERdownloadWorker.RunWorkerAsync();
            }
            else if (updateCue.Count > 0)
            {
                currentFile = updateCue[0];
                UpdateStatus("Updating Updater");
                UPDATERupdateWorker.RunWorkerAsync();
            }
            else
            {
                UpdateStatus("Checking for EGM updates");
                updateCheckWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region UPDATE Downloader
        private void UPDATERdownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CurrentProcess = UpdateProcess.Download;
                UpdateProgressBarStyle(ProgressBarStyle.Blocks);
                while (currentFile != null)
                {
                    downloadCue.Remove(currentFile);

                    if (!Directory.Exists(saveDirectory))
                        Directory.CreateDirectory(saveDirectory);

                    Uri url = new Uri(currentFile.URL);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    response.Close();

                    CurrentFileTotalBytes = response.ContentLength;
                    CurrentFileBytes = 0;
                    BytesSinceLastTick = 0;

                    using (WebClient client = new WebClient())
                    {
                        using (Stream serverStream = client.OpenRead(url))
                        {
                            using (Stream clientStream = new FileStream(saveDirectory + currentFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                int iByteSize = 0;
                                byte[] byteBuffer = new byte[CurrentFileTotalBytes];
                                while ((iByteSize = serverStream.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                                {
                                    clientStream.Write(byteBuffer, 0, iByteSize);

                                    BytesSinceLastTick += iByteSize;
                                    CurrentFileBytes += iByteSize;

                                    double dIndex = (double)(CurrentFileBytes);
                                    double dTotal = (double)CurrentFileTotalBytes;

                                    double dProgressPercentage = (dIndex / dTotal);
                                    int iProgressPercentage = (int)(dProgressPercentage * 100);
                                    UPDATERdownloadWorker.ReportProgress(iProgressPercentage);
                                }
                                clientStream.Close();
                            }
                            serverStream.Close();
                        }
                    }
                    if (downloadCue.Count > 0)
                        currentFile = downloadCue[0];
                    else
                        currentFile = null;
                }

                UpdateProgressBarStyle(ProgressBarStyle.Marquee);
            }
            catch (Exception ex) { MessageBox.Show("The update process failed! Please contact support. \r\n\r\n" + ex.Message); }
        }

        private void UPDATERdownloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
        }

        private void UPDATERdownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CurrentProcess = UpdateProcess.Update;
            if (updateCue.Count > 0)
            {
                currentFile = updateCue[0];
                UpdateStatus("Updating Updater");
                UPDATERupdateWorker.RunWorkerAsync();
            }
            else
            {
                UpdateStatus("Checking for EGM updates");
                updateCheckWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region UPDATE Updater
        private void UPDATERupdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (currentFile != null)
                {
                    updateCue.Remove(currentFile);

                    if (currentFile.OperationType == FileOperationType.Update)
                    {
                        if (!String.IsNullOrEmpty(currentFile.Directory))
                        {
                            string saveLoc = Application.StartupPath + "/" + currentFile.Directory;
                            if (!Directory.Exists(saveLoc))
                                Directory.CreateDirectory(saveLoc);

                            string destFile = saveLoc + "/" + currentFile.FileName;

                            if (File.Exists(destFile))
                            {
                                if (!FileLocked(destFile))
                                    File.Copy(saveDirectory + "/" + currentFile.FileName, destFile, true);
                                else
                                {
                                    if (ResolveFileLock(destFile, currentFile.FileName))
                                        File.Copy(saveDirectory + "/" + currentFile.FileName, destFile, true);
                                }
                            }
                            else
                                File.Copy(saveDirectory + "/" + currentFile.FileName, destFile, true);
                        }
                        else
                        {
                            string destFile = Application.StartupPath + "/" + currentFile.FileName;
                            if (File.Exists(destFile))
                            {
                                if (!FileLocked(destFile))
                                    File.Copy(saveDirectory + "/" + currentFile.FileName, destFile, true);
                                else
                                {
                                    if (ResolveFileLock(destFile, currentFile.FileName))
                                        File.Copy(saveDirectory + "/" + currentFile.FileName, destFile, true);
                                }
                            }
                            else
                                File.Copy(saveDirectory + "/" + currentFile.FileName, destFile, true);
                        }
                    }
                    else if (currentFile.OperationType == FileOperationType.Delete)
                    {
                        if (!String.IsNullOrEmpty(currentFile.FileName))
                        {
                            string deleteLoc;
                            if (!String.IsNullOrEmpty(currentFile.Directory))
                                deleteLoc = Application.StartupPath + "/" + currentFile.Directory + "/" + currentFile.FileName;
                            else
                                deleteLoc = Application.StartupPath + "/" + currentFile.FileName;

                            if (File.Exists(deleteLoc))
                            {
                                if (!FileLocked(deleteLoc))
                                    File.Delete(deleteLoc);
                                else
                                {
                                    if (ResolveFileLock(deleteLoc, currentFile.FileName))
                                        File.Delete(deleteLoc);
                                }
                            }
                        }
                        else
                        {
                            string deleteLoc;
                            if (!String.IsNullOrEmpty(currentFile.Directory))
                                deleteLoc = Application.StartupPath + "/" + currentFile.Directory;
                            else
                                continue;
                            if (Directory.Exists(deleteLoc))
                                Directory.Delete(deleteLoc, true);
                        }
                    }

                    if (updateCue.Count > 0)
                        currentFile = updateCue[0];
                    else
                        currentFile = null;
                }

                SaveVersion();
                Directory.Delete(saveDirectory, true);
            }
            catch (Exception ex) { MessageBox.Show("The update process failed! Please contact support. \r\n\r\n" + ex.Message); }
        }

        private void UPDATERupdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SaveVersion();
            UpdateStatus("Checking for EGM updates");
            updateCheckWorker.RunWorkerAsync();
        }
        #endregion

        #region Methods

        private string ParseUrl(string url)
        {
            return "http://update.expressgamemaker.com/updater/" + url;
        }
        private bool FileLocked(string filePath)
        {
            FileStream stream = null;
            FileInfo file = new FileInfo(filePath);

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }

        private bool ResolveFileLock(string filePath, string fileName)
        {
            DialogResult r = MessageBox.Show("The file " + fileName + " is currently locked or in use. Please close the file in order for the update to continue. Press retry to attempt to update the file again, or cancel if you want to abort the update operation.", "File Error", MessageBoxButtons.RetryCancel);
            if (r == System.Windows.Forms.DialogResult.Retry)
            {
                if (FileLocked(filePath))
                {
                    return ResolveFileLock(filePath, fileName);
                }
                else
                    return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveVersion()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "/version.xml");

            if (doc.SelectSingleNode("config/updater") == null)
            {
                if (doc.SelectSingleNode("config") == null)
                {
                    XmlNode root = doc.CreateNode(XmlNodeType.Element, "config", "");
                    doc.AppendChild(root);
                    XmlNode updaterNode = doc.CreateNode(XmlNodeType.Element, "updater", "");
                    updaterNode.InnerText = UpdaterNewVersion;
                    root.AppendChild(updaterNode);
                }
                else
                {
                    XmlNode root = doc.SelectSingleNode("config");
                    XmlNode updaterNode = doc.CreateNode(XmlNodeType.Element, "updater", "");
                    updaterNode.InnerText = UpdaterNewVersion;
                    root.AppendChild(updaterNode);
                }
            }
            else
            {
                doc.SelectSingleNode("config/updater").InnerText = UpdaterNewVersion;
            }
            
            doc.Save(Application.StartupPath + "/version.xml");
        }
        #endregion

        bool allowClose = false;
        private void Splash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (allowClose)
            {
                if (Directory.Exists(saveDirectory))
                    Directory.Delete(saveDirectory, true);
            }
            else
                e.Cancel = true;
            
            while (!MainForm.Instance.Visible)
            {
            }
            MainForm.Instance.EndInvoke(MainForm.Instance.BeginInvoke(new MethodInvoker(delegate() { MainForm.Instance.Focus(); })));
            MainForm.Instance.EndInvoke(MainForm.Instance.BeginInvoke(new MethodInvoker(delegate() { MainForm.Instance.Show(); })));
            MainForm.Instance.EndInvoke(MainForm.Instance.BeginInvoke(new MethodInvoker(delegate() { MainForm.Instance.BringToFront(); })));
            MainForm.Instance.EndInvoke(MainForm.Instance.BeginInvoke(new MethodInvoker(delegate() { MainForm.Instance.WindowState = FormWindowState.Maximized; })));

            MainForm.Instance.EndInvoke(MainForm.Instance.BeginInvoke(new MethodInvoker(delegate() { MainForm.Instance.TopMost = true; })));
        }

    }

    public enum FileType
    {
        Patch,
        Run
    }
    public enum FileOperationType
    {
        Update,
        Delete
    }
    public class UpdateFile
    {
        public string Version { get; set; }
        public string FileName { get; set; }
        public string URL { get; set; }
        public string Directory { get; set; }
        public FileOperationType OperationType { get; set; }
        public FileType Type { get; set; }
    }
}
