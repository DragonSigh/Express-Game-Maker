//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using Microsoft.Xna.Framework;
using EGMGame.Controls.EventControls.EventDialogs;

namespace EGMGame
{
    public partial class TransferPlayerDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
           set { selectedEvent = value; if (action == null ) Setup(); }
        }
        IEvent selectedEvent;
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }
        EventPageData selectedPage;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;


        #region Constructor
        public TransferPlayerDialog()
        {
            InitializeComponent();
            mapsList.RefreshList(false);
            variableXList.RefreshList(false);
            variableYList.RefreshList(false);
            coordinateType.SelectedIndex = 0;
        }
        #endregion

        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Map;
            action.Code = 2;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            mapsList.Select((int)action.Value[0]);
            coordinateType.SelectedIndex = (int)action.Value[1];

            if (coordinateType.SelectedIndex == 0)
            {
                nudX.Value = (decimal)(int)action.Value[2];
                nudY.Value = (decimal)(int)action.Value[3];
            }
            else
            {
                variableXList.Select((int)action.Value[2]);
                variableYList.Select((int)action.Value[3]);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (mapsList.Data().ID > -10)
            {
                action.Value[0] = mapsList.Data().ID;
                action.Value[1] = coordinateType.SelectedIndex;
                string text = "";
                if (coordinateType.SelectedIndex == 0)
                {
                    action.Value[2] = (int)nudX.Value;
                    action.Value[3] = (int)nudY.Value;

                    text = " Constant: (" + action.Value[2].ToString() + ", " + action.Value[3].ToString() + ")";
                }
                else
                {
                    if (variableXList.Data() == null || variableYList.Data() == null)
                    {
                        this.Close(); return;
                    }

                    action.Value[2] = variableXList.Data().ID;
                    action.Value[3] = variableYList.Data().ID;

                    text = " Variable: (" + GameData.Variables[(int)action.Value[2]].Name + ", " + GameData.Variables[(int)action.Value[3]].Name + ")";
                }
                action.Name = "Transfer Player To Map: " + mapsList.Data().Name + text;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
        /// <summary>
        /// Coordinate Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coordinateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coordinateType.SelectedIndex == 0)
            {
                variablePanel.Visible = false;
                constantPanel.Visible = true;
            }
            else
            {
                constantPanel.Visible = false;
                variablePanel.Visible = true;
            }
        }
        /// <summary>
        /// Show map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void constantBtn_Click(object sender, EventArgs e)
        {
            if (mapsList.Data().ID > -10 && MainForm.SelectedMap != null)
            {
                // Show map
                PickPositionOnMapDialog dialog = new PickPositionOnMapDialog();
                dialog.IsNotMap = true;
                if (mapsList.Data().ID == -1 || mapsList.SelectedIndex == 0 || mapsList.Data().ID == MainForm.SelectedMap.ID)
                    dialog.SelectedMap = MainForm.SelectedMap;
                else
                {
                    MapInfo info = Global.Project.MapsInfo[mapsList.Data().ID];
                    MapData scene;
                    string path;
                    if (!MainForm.mapsExplorer.cache.TryGetValue(mapsList.Data().ID, out path))
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
                    dialog.IsNotMap = true;
                    dialog.SelectedMap = scene;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        nudX.Value = (decimal)dialog.Position.X;
                        nudY.Value = (decimal)dialog.Position.Y;
                    }

                    if (scene != MainForm.SelectedMap)
                    {
                        // Remove map from dictionary
                        GameData.Maps.Remove(mapsList.Data().ID);
                        // Collect Garbage
                        GC.Collect();
                    }
                    return;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    nudX.Value = (decimal)dialog.Position.X;
                    nudY.Value = (decimal)dialog.Position.Y;
                }
            }
        }
    }
}
