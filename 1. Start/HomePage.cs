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
using System.IO;

namespace EGMGame.Docking.Homepage
{
    public partial class HomePage : DockContent
    {
        MenuListItem newGameBtn = new MenuListItem("New Project");
        MenuListItem resourcesCat = new MenuListItem("Resources");
        MenuListItem tutorialsBtn = new MenuListItem("Tutorials");
        MenuListItem resourcesBtn = new MenuListItem("Resources");
        MenuListItem loadBtn = new MenuListItem("Load Project");
        MenuListItem recentCat = new MenuListItem("Recent Projects");

        Color[] StartColors = new Color[3];
        Color[] EndColors = new Color[3];

        Color currentStart;
        Color currentEnd;

        int colorID = 0;
        int currentFrame = 0;
        int frames = 900;

        public HomePage()
        {
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

            //Application.Idle += delegate { this.Invalidate(); };

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ContainerControl |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();

            // Add Buttons
            newGameBtn.Icon = global::EGMGame.Properties.Resources.GameController;
            newGameBtn.Clicked += new MenuListItem.ClickeEvent(NewProjectClicked);
            startList.Items.Add(newGameBtn);
            resourcesCat.IsCategory = true;
            startList.Items.Add(resourcesCat);
            tutorialsBtn.IsDetailed = true;
            tutorialsBtn.SubText = "A bunch of guides for you to get started.";
            startList.Items.Add(tutorialsBtn);
            resourcesBtn.SubText = "Extra resources for your game.";
            resourcesBtn.IsDetailed = true;
            startList.Items.Add(resourcesBtn);
            loadBtn.Icon = global::EGMGame.Properties.Resources.folder_open;
            loadBtn.Clicked += new MenuListItem.ClickeEvent(LoadProjectClicked);
            userList.Items.Add(loadBtn);
            recentCat.IsCategory = true;
            userList.Items.Add(recentCat);

            // Add All Recent Projects
            AddRecentProjects();

            //InitializeColors();
        }
        /// <summary>
        /// Add Recent Projects
        /// </summary>
        private void AddRecentProjects()
        {
            
            List<RecentProject> recent = new List<RecentProject>(MainForm.Configuration.RecentProjects);
            foreach (RecentProject rp in recent)
            {
                if (File.Exists(rp.Location))
                {
                    MenuListItem item = new MenuListItem(rp.Name);
                    item.Path = rp.Location;
                    item.IsDetailed = true;
                    item.SubText = rp.Description;
                    item.Clicked += new MenuListItem.ClickeEvent(RecentProjectClicked);
                    userList.Items.Add(item);
                }
                else
                    MainForm.Configuration.RecentProjects.Remove(rp);
            }
        }

        private void NewProjectClicked(object sender)
        {
            MainForm.Instance.newToolStripMenuItem_Click(null, null);
        }

        private void LoadProjectClicked(object sender)
        {
            MainForm.Instance.openToolStripButton_Click(null, null);
        }

        private void RecentProjectClicked(object sender)
        {
            MainForm.Instance.RecentProjectLoad(((MenuListItem)sender).Path);
        }

        private void InitializeColors()
        {
            // Blue
            StartColors[0] = Color.FromArgb(10, 133, 198);
            EndColors[0] = Color.FromArgb(5, 88, 136);
            // Orange
            StartColors[1] = Color.FromArgb(251, 168, 30);
            EndColors[1] = Color.FromArgb(229, 112, 19);
            // Green
            StartColors[2] = Color.FromArgb(161, 195, 39);
            EndColors[2] = Color.FromArgb(81, 90, 11);

            currentStart = StartColors[0];
            currentEnd = EndColors[0];
        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
            base.OnResize(e);
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            newsMenuList1.GetFeed();
        }
    }
}
