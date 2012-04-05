//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using GenericUndoRedo;
using System.Reflection;
using System.IO;

namespace EGMGame.Docking.Explorers
{
    public partial class TutorialExplorer : DockContent
    {
        internal int CurrentStep = 1;
        internal DirectoryInfo CurrentDirectory;
        // Construct
        public TutorialExplorer()
        {
            InitializeComponent();

            string path = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetModules()
                [0].FullyQualifiedName) +
                "\\Tutorials";
            CurrentDirectory = new DirectoryInfo(path);
            ChangeStep(1);

            Navigate("HowTo/GettingStarted/index.htm");

            //webBrowser.Url = new Uri(@"\Tutorials\");
        }
        private void Navigate(string localPath)
        {
            try
            {
                while (localPath.StartsWith("../"))
                {
                    CurrentDirectory = CurrentDirectory.Parent;
                    localPath = localPath.Remove(0, 3);
                }

                localPath = CurrentDirectory.FullName + "\\" + localPath;
                webBrowser.Navigate(localPath);
            }
            catch
            {
                MessageBox.Show("An error has occured in the Tutorial Explorer. Tutorial Explorer is disabled.\nPlease report this error.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GoTo(string localPath)
        {
            string path = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetModules()
                [0].FullyQualifiedName) +
                "\\Tutorials";
            path = Path.Combine(path, localPath);
            CurrentDirectory = new DirectoryInfo(path);
            webBrowser.Navigate(path);
            CurrentStep = 1;
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            ChangeStep(CurrentStep - 1);
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            ChangeStep(CurrentStep + 1);
        }

        private void creatingAParticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Advanced/Particle/index.htm");
        }

        private void creatingAMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Maps/index.htm");
        }

        private void ChangeStep(int step)
        {
            string url = "step" + step.ToString() + ".htm";
            if (step == 1)
            {
                CurrentStep = 1;
                Navigate("index.htm");
            }
            else if (step > 1)
            {
                bool success = false;
                if (!CurrentDirectory.Exists)
                {
                    CurrentDirectory = new DirectoryInfo(Path.GetDirectoryName(CurrentDirectory.FullName));
                }
                foreach (FileInfo f in CurrentDirectory.GetFiles())
                {
                    if (f.Name == url)
                    {
                        Navigate(url);
                        CurrentStep = step;
                        success = true;
                    }
                }

                if (!success)
                {
                    switch (CurrentDirectory.Name)
                    {
                        case "GettingStarted":
                            GoTo("HowTo/Materials/index.htm");
                            break;
                        case "Materials":
                            GoTo("HowTo/Animations/index.htm");
                            break;
                        case "Animations":
                            GoTo("HowTo/Collision/index.htm");
                            break;
                        case "Collision":
                            GoTo("HowTo/Tilesets/index.htm");
                            break;
                        case "Tilesets":
                            GoTo("HowTo/Maps/index.htm");
                            break;
                        case "Maps":
                            GoTo("HowTo/MapEvent/index.htm");
                            break;
                        case "MapEvent":
                            GoTo("HowTo/CreatingHero/index.htm");
                            break;
                        case "CreatingHero":
                            GoTo("HowTo/CreatingPlayer/index.htm");
                            break;
                        case "CreatingPlayer":
                            GoTo("HowTo/Playtesting/index.htm");
                            break;
                        case "Playtesting":
                            break;
                    }
                }
            }
            else if (step < 1)
            {
                switch (CurrentDirectory.Name)
                {
                    case "Materials":
                        GoTo("HowTo/GettingStarted/index.htm");
                        break;
                    case "Animations":
                        GoTo("HowTo/Materials/index.htm");
                        break;
                    case "Collision":
                        GoTo("HowTo/Animations/index.htm");
                        break;
                    case "Tilesets":
                        GoTo("HowTo/Collision/index.htm");
                        break;
                    case "Maps":
                        GoTo("HowTo/Tilesets/index.htm");
                        break;
                    case "MapEvent":
                        GoTo("HowTo/Maps/index.htm");
                        break;
                    case "CreatingHero":
                        GoTo("HowTo/MapEvent/index.htm");
                        break;
                    case "CreatingPlayer":
                        GoTo("HowTo/CreatingHero/index.htm");
                        break;
                    case "Playtesting":
                        GoTo("HowTo/CreatingPlayer/index.htm");
                        break;
                }
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            CurrentDirectory = new DirectoryInfo(webBrowser.Url.LocalPath).Parent;
            //if (CurrentStep == 1)
            //    btnPrevPage.Enabled = false;
            //else
            //    btnPrevPage.Enabled = true;
            bool test = File.Exists(CurrentDirectory.FullName + "\\step2.htm");
            //if (CurrentStep == CurrentDirectory.GetFiles().Length || test == false)
            //    btnNextPage.Enabled = false;
            //else
            //    btnNextPage.Enabled = true;

            if (webBrowser.CanGoBack)
                btnBack.Enabled = true;
            else
                btnBack.Enabled = false;
            if (webBrowser.CanGoForward)
                btnForward.Enabled = true;
            else
                btnForward.Enabled = false;

            if (CurrentDirectory.Name != "Tutorials")
                btnUp.Enabled = true;
            else btnUp.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Navigate("../index.htm");

        }

        private void importingAMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Materials/index.htm");
        }

        private void creatingAnAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Animations/index.htm");
        }

        private void creatingATilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Tilesets/index.htm");
        }

        private void creatingAMapEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/MapEvent/index.htm");
        }

        private void playtestYourGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Playtesting/index.htm");
        }

        private void creatingHeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/CreatingHero/index.htm");
        }

        private void creatingPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/CreatingPlayer/index.htm");
        }

        private void importingMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Materials/index.htm");
        }

        private void makingUseOfUnlimitedLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creatingASkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Advanced/Skin/index.htm");
        }

        private void creatingAMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo("HowTo/Advanced/Menu/index.htm");
        }
    }
}
