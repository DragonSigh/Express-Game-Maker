/* -----------------------------
 * Config - User Configuration [Serializable]
 * -----------------------------
 * Purpose:             This class is loaded when the program starts. It holds users' recent projects, crashed projects, and keeps track of other user settings.
 * Most Used By:        MainForm.cs
 * Associated Files:    Config.xml
 * Modify:              When you want to add new user settings. These settings are independent of projects.
 */

//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.IO;

namespace EGMGame
{
    [Serializable]
    public class Config
    {
        public bool UseGuide = true;
        public List<RecentProject> RecentProjects = new List<RecentProject>();
        public List<string> CrashedProjects = new List<string>();
        public bool PlatformerUpdateWarned = false;
        public bool EventCommandsTips = true;
        public bool AnimationTips = true;
        public bool AudioMaterailTip = false;
        public bool VideoMaterailTip = false;
        public bool ImageMaterailTip = false;
        public bool BitmapFontMaterailTip = false;
        public string LastProjectDirectory;


        internal static void Save()
        {
            Marshal.SaveObj(MainForm.Configuration, Path.Combine(Application.StartupPath, "Config.xml"), Application.StartupPath);
        }

    }

    [Serializable]
    public class RecentProject
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }
    }
}
