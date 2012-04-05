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
using EGMGame.Library;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace EGMGame.Docking.Settings
{
    public partial class SettingsForm : DockContent
    {
        bool allowChange = true;

        public List<string> Languages;

        public SettingsForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            // Load Project
            if (Global.Project != null)
            {
                LoadProject(Global.Project);
            }
            if (this.FloatPane != null)
            {
                this.FloatPane.FloatWindow.Size = this.Size;
                this.FloatPane.FloatWindow.Size = this.MaximumSize;
            }
        }
        /// <summary>
        /// Load the project settings.
        /// </summary>
        /// <param name="project"></param>
        private void LoadProject(EGMGame.Library.Project project)
        {
            allowChange = false;

            cbDeathState.RefreshList(false);
            cbGold.RefreshList(false);
            cbMaterials.RefreshList(false, MaterialDataType.Image);
            cbBattleFonts.RefreshList(false);
            nameBox.Text = project.Name;
            descBox.Text = project.Description;
            iconBox.Text = project.Icon;

            FileInfo iconFile = new FileInfo(project.Location + @"\" + project.Icon);

            if (iconFile.Exists)
            {
                iconPic.ImageLocation = iconFile.FullName;
            }

            defaultPlatform.SelectedIndex = (int)project.Platform;
            screenWidth.Value = (decimal)project.ScreenRatio.X;
            screenHeight.Value = (decimal)project.ScreenRatio.Y;
            menuBtn.Checked = (project.InitialSceneType == 0);
            mapBtn.Checked = (project.InitialSceneType != 0);
            gridHeight.Value = (decimal)project.DefaultGridSize.Y;
            gridWidth.Value = (decimal)project.DefaultGridSize.X;
            defaultPixel.Value = (decimal)project.DefaultPixel;

            cbBattleFonts.Select(project.BattleFont);

            chkTTAP.Checked = project.TTAP_Enabled;
            nudTTAPRadX.Value = (decimal)project.TTAP_Radius.X;
            nudTTAPRadY.Value = (decimal)project.TTAP_Radius.Y;
            nudTransTTAP.Value = (decimal)project.TTAP_Transparency;

            nudFriction.Value = (decimal)project.Friction;
            nudBounce.Value = (decimal)project.Bounce;
            nudVelocityX.Value = (decimal)project.Impulse;
            nudMass.Value = (decimal)project.Mass;
            nudForce.Value = (decimal)project.Force;
            nudDrag.Value = (decimal)project.LinearDrag;
            nudRotDrag.Value = (decimal)project.RotationalDrag;
            nudGravityX.Value = (decimal)project.Gravity.X;
            nudGravityY.Value = (decimal)project.Gravity.Y;

            cbDeathState.Select(project.DeathState);
            cbGold.Select(project.Gold);

            chkStartFullScreen.Checked = Global.Project.StartFullScreen;

            PopulateScenes(project.InitialSceneType);
            if (project.InitialSceneType == 0)
                initialSceneBox.SelectedIndex = Global.GetIndex(project.InitialSceneID, GameData.Menus);
            else
                initialSceneBox.SelectedIndex = Global.GetIndex(project.InitialSceneID, project.MapsInfo) + 1;

            if (initialSceneBox.SelectedIndex < 0 && initialSceneBox.Items.Count > 0)
            { initialSceneBox.SelectedIndex = 0; }


            GetSize();

            cbMaterials.Select(project.CursorMaterial);

            cbLanguages.Items.Clear();
            cbCurrentLanguages.Items.Clear();

            Languages = new List<string>(project.Languages);
            foreach (string lang in Languages)
            {
                cbCurrentLanguages.Items.Add(lang);
            }

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                if (!Languages.Contains(ci.EnglishName))
                    cbLanguages.Items.Add(ci.EnglishName);
            }

            if (cbLanguages.Items.Count > 0)
                cbLanguages.SelectedIndex = 0;
            if (cbCurrentLanguages.Items.Count > 0)
                cbCurrentLanguages.SelectedIndex = 0;

            allowChange = true;
        }

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

        private void GetSize()
        {
            FileInfo projectExe = new FileInfo(Global.Project.Location + @"\" + Global.Project.Name + ".exe");

            if (projectExe.Exists)
            {
                DirectoryInfo contents = new DirectoryInfo(Global.Project.Location + @"\Content");

                if (contents.Exists)
                {
                    int size = (int)(projectExe.Length / 1048576);
                    foreach (FileInfo file in contents.GetFiles())
                    {
                        size += (int)(file.Length / 1048576);
                    }
                    label8.Text = size.ToString() + " MB uncompressed.";
                }
            }
        }

        private void PopulateScenes(int type)
        {
            initialSceneBox.Items.Clear();
            if (type == 1)
            {
                initialSceneBox.Items.Add("Player Start Position");
                foreach (MapInfo data in Global.Project.MapsInfo.Values)
                {
                    initialSceneBox.Items.Add(data.Name);
                }
            }
            else
            {
                foreach (MenuData data in GameData.Menus.Values)
                {
                    initialSceneBox.Items.Add(data.Name);
                }
            }
        }

        internal void LoadSettings()
        {
            // Load Project
            if (Global.Project != null)
            {
                LoadProject(Global.Project);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            applyBtn_Click(null, null);
            this.Close();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("You can not undo these changes! Are you sure you want to apply?", "Express Game Maker", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
            //{
                try
                {

                    EGMGame.Library.Project project = Global.Project;

                    project.Name = nameBox.Text;
                    project.Description = descBox.Text;
                    project.Platform = (EGMGame.Library.TargetPlatform)defaultPlatform.SelectedIndex;
                    project.ScreenRatio = new Microsoft.Xna.Framework.Vector2((float)screenWidth.Value, (float)screenHeight.Value);
                    project.DefaultPixel = (int)defaultPixel.Value;

                    project.TTAP_Enabled = chkTTAP.Checked;
                    project.TTAP_Radius = new Microsoft.Xna.Framework.Vector2((float)nudTTAPRadX.Value, (float)nudTTAPRadY.Value);
                    project.TTAP_Transparency = (int)nudTransTTAP.Value;

                    project.BattleFont = cbBattleFonts.Data().ID;
                    project.CursorMaterial = cbMaterials.Data().ID;

                    Global.Project.DefaultGridSize = new Microsoft.Xna.Framework.Vector2((float)gridWidth.Value, (float)gridHeight.Value);
                    // Delete Old Icon
                    if (Path.Combine(project.Location, project.Icon) != iconBox.Text)
                    {
                        if (project.Icon != iconBox.Text)
                        {
                            if (File.Exists(Path.Combine(project.Location, project.Icon)))
                            {
                                if ((File.GetAttributes(Path.Combine(project.Location, project.Icon)) & FileAttributes.ReadOnly)
                                    == FileAttributes.ReadOnly)
                                    File.SetAttributes(Path.Combine(project.Location, project.Icon), FileAttributes.Normal);
                                File.Delete(Path.Combine(project.Location, project.Icon));
                            }
                            FileInfo iFile = new FileInfo(iconBox.Text);
                            project.Icon = iFile.Name;
                            // Import Icon if necessary
                            iFile.CopyTo(Path.Combine(project.Location, iFile.Name));
                        }
                    }

                    project.InitialSceneType = (menuBtn.Checked ? 0 : 1);
                    if (initialSceneBox.SelectedIndex > -1)
                    {
                        if (project.InitialSceneType == 0 && GameData.Menus.Count > initialSceneBox.SelectedIndex)
                        {
                            project.InitialSceneID = GameData.Menus[initialSceneBox.SelectedIndex].ID;
                        }
                        else if (Global.Project.MapsInfo.Count > initialSceneBox.SelectedIndex)
                        {
                            if (initialSceneBox.SelectedIndex - 1 > -1)
                            {
                                int mapIndex = 0;
                                foreach (MapInfo map in Global.Project.MapsInfo.Values)
                                {
                                    if (mapIndex == initialSceneBox.SelectedIndex - 1)
                                    {
                                        project.InitialSceneID = map.ID;
                                    }
                                    mapIndex++;
                                }
                            }
                            else
                                project.InitialSceneID = -1;
                        }
                    }
                    else
                        project.InitialSceneID = -1;

                    Global.Project.Gravity = new Vector2((float)nudGravityX.Value, (float)nudGravityY.Value);
                    Global.Project.Mass = (float)nudMass.Value;
                    Global.Project.Force = (float)nudForce.Value;
                    Global.Project.LinearDrag = (float)nudDrag.Value;
                    Global.Project.RotationalDrag = (float)nudRotDrag.Value;
                    Global.Project.Friction = (float)nudFriction.Value;
                    Global.Project.Bounce = (float)nudBounce.Value;
                    Global.Project.Impulse = (float)nudVelocityX.Value;

                    Global.Project.StartFullScreen = chkStartFullScreen.Checked;

                    Global.Project.DeathState = cbDeathState.Data().ID;

                    Global.Project.Gold = cbGold.Data().ID;

                    Global.Project.Languages = Languages;

                    MainForm.textEditor.RefreshLanguages();

                    MainForm.NeedSave = true;
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "42x001");
                }
            //}
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            //LoadProject(Global.Project);
        }

        private void menuBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (menuBtn.Checked)
            {
                PopulateScenes(0);
                if (initialSceneBox.SelectedIndex < 0 && initialSceneBox.Items.Count > 0)
                { initialSceneBox.SelectedIndex = 0; }
            }
            else
            {
                PopulateScenes(1);
                if (initialSceneBox.SelectedIndex < 0 && initialSceneBox.Items.Count > 0)
                { initialSceneBox.SelectedIndex = 0; }
            }
        }

        private void impactGroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Float)
            {
                if (this.FloatPane != null)
                {
                    this.FloatPane.FloatWindow.Size = this.MaximumSize;
                }
            }
        }

        private void SettingsForm_DockChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.Float)
            {
                if (this.FloatPane != null)
                {
                    this.FloatPane.FloatWindow.Size = this.MaximumSize;
                }
            }
        }

        internal void ResetProject()
        {

        }

        private void cbDeathState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddLanguage_Click(object sender, EventArgs e)
        {
            if (cbLanguages.SelectedIndex > -1)
            {
                Languages.Add(cbLanguages.Text);
                cbCurrentLanguages.Items.Add(cbLanguages.Text);
                cbLanguages.Items.RemoveAt(cbLanguages.SelectedIndex);

                if (cbLanguages.Items.Count > 0)
                    cbLanguages.SelectedIndex = 0;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cbCurrentLanguages.SelectedIndex > 0)
            {
                cbLanguages.Items.Add(Languages[cbCurrentLanguages.SelectedIndex]);
                Languages.Remove(cbCurrentLanguages.Text);
                cbCurrentLanguages.Items.Remove(cbCurrentLanguages.Text);

                if (cbCurrentLanguages.Items.Count > 0)
                    cbCurrentLanguages.SelectedIndex = 0;
            }
        }
    }
}
