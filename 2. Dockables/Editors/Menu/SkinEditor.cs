using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using GenericUndoRedo;
using Microsoft.Xna.Framework;
using WeifenLuo.WinFormsUI.Docking;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using EGMGame.Controls;
using EGMGame.Docking.Explorers;

namespace EGMGame.Docking.Editors
{
    public partial class SkinEditor : DockContent, IHistory, IEditor
    {
        // XNA Vars
        ContentManager contentManager;
        SpriteBatch spriteBatch;
        // Sample Menu Parts
        MenuWindow sampleWindow;
        MenuButton sampleButton;
        DynamicBarVariable sampleDynamicBar;

        bool allowChange = true;

        bool barUp = true;

        public SkinData CurrentSkin = new SkinData();

        public SkinEditor()
        {
            MainForm.SkinHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();

            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
            // Application Event Hooking 
            Application.Idle += delegate { graphicsControl.Invalidate(); };
            this.Resize += delegate { graphicsControl.Invalidate(); };

            this.cbMenuPart.SelectedIndex = 0;
        }

        #region Activation/Shown Events
        private void SkinEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Skins, typeof(SkinData));
            PopulateComboBoxes();
        }

        private void SkinEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.SkinHistory[this];

            //addRemoveList.SetupList(GameData.Skins, typeof(SkinData));
        }
        #endregion

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Skins.Add(data.ID, (SkinData)data);
            addRemoveList.AddNode(data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Skins.Remove(data.ID);

            addRemoveList.RemoveNode(data);
        }
        /// <summary>
        /// Property Changed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        bool undoRedoChange = true;
        internal void PropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (addRemoveList.Data() == data)
            {
                CheckSkin();
                UpdateSampleIDs();
            }
            undoRedoChange = true;
        }
        #endregion

        #region Add Remove List
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                SkinData a = new SkinData();
                a.Name = Global.GetName("Skin", GameData.Skins);
                a.ID = Global.GetID(GameData.Skins);
                a.Category = ca.Category;
                GameData.Skins.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.SkinHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);
                CheckMain();
                PopulateComboBoxes();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "44x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Skins.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.SkinHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Skins.Remove(addRemoveList.SelectedID);
                    // 
                    addRemoveList.RemoveSelectedNode();
                    CheckMain();
                    PopulateComboBoxes();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "44x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (ca.ID > -1)
            {
                CurrentSkin = GameData.Skins[ca.ID];
                CheckSkin();
                UpdateSampleIDs();
                gbMain.Enabled = true;
            }
            else
            {
                gbMain.Enabled = false;
            }
        }
        #endregion

        #region UI Checks
        private void CheckMain()
        {
            if (addRemoveList.Count > 0)
                gbMain.Enabled = true;
            else
                gbMain.Enabled = false;
        }
        private void CheckSkin()
        {
            undoRedoChange = false;
            if (CurrentSkin != null)
            {
                AssignControls();
            }
            undoRedoChange = true;
        }

        bool rfbutton, rflist, rfwindow, rfcursor, rftext, rfdynamicbar, rfpointer;
        public void PopulateComboBoxes()
        {
            undoRedoChange = false;
            allowChange = false;

            switch (cbMenuPart.SelectedIndex)
            {
                case 0:
                    if (!rfbutton)
                    {
                        //Button
                        cbButtonBack.RefreshList(true, MaterialDataType.Image);
                        cbButtonLeft.RefreshList(true, MaterialDataType.Image);
                        cbButtonRight.RefreshList(true, MaterialDataType.Image);
                        rfbutton = true;

                        if (CurrentSkin != null)
                        {
                            cbButtonBack.Select(CurrentSkin.Button.BackgroundID);
                            cbButtonLeft.Select(CurrentSkin.Button.LeftID);
                            cbButtonRight.Select(CurrentSkin.Button.RightID);
                        }
                    }
                    break;
                case 1:
                    //List
                    if (!rflist)
                    {
                        cbListBackground.RefreshList(true, MaterialDataType.Image);
                        cbListTop.RefreshList(true, MaterialDataType.Image);
                        cbListBottom.RefreshList(true, MaterialDataType.Image);
                        cbListLeft.RefreshList(true, MaterialDataType.Image);
                        cbListRight.RefreshList(true, MaterialDataType.Image);
                        cbListTopLeft.RefreshList(true, MaterialDataType.Image);
                        cbListTopRight.RefreshList(true, MaterialDataType.Image);
                        cbListBottomLeft.RefreshList(true, MaterialDataType.Image);
                        cbListBottomRight.RefreshList(true, MaterialDataType.Image);
                        rflist = true;

                        if (CurrentSkin != null)
                        {
                            cbListBackground.Select(CurrentSkin.List.BackgroundID);

                            cbListTop.Select(CurrentSkin.List.TopID);
                            cbListBottom.Select(CurrentSkin.List.BottomID);

                            cbListLeft.Select(CurrentSkin.List.LeftID);
                            cbListRight.Select(CurrentSkin.List.RightID);

                            cbListTopLeft.Select(CurrentSkin.List.TopLeftID);
                            cbListTopRight.Select(CurrentSkin.List.TopRightID);

                            cbListBottomLeft.Select(CurrentSkin.List.BottomLeftID);
                            cbListBottomRight.Select(CurrentSkin.List.BottomRightID);
                        }
                    }
                    break;
                case 2:
                    //Text
                    if (!rftext)
                    {
                        cbTextBackground.RefreshList(true, MaterialDataType.Image);
                        cbTextLeft.RefreshList(true, MaterialDataType.Image);
                        cbTextRight.RefreshList(true, MaterialDataType.Image);
                        rftext = true;

                        if (CurrentSkin != null)
                        {
                            //Text
                            cbTextBackground.Select(CurrentSkin.Text.BackgroundID);
                            cbTextLeft.Select(CurrentSkin.Text.LeftID);
                            cbTextRight.Select(CurrentSkin.Text.RightID);
                        }
                    }
                    break;
                case 3:
                    //Dynamic Bar
                    if (!rfdynamicbar)
                    {
                        cbDynamicBarBackground.RefreshList(true, MaterialDataType.Image);
                        cbDynamicBarLeft.RefreshList(true, MaterialDataType.Image);
                        cbDynamicBarRight.RefreshList(true, MaterialDataType.Image);
                        cbDynamicBarBarBackground.RefreshList(true, MaterialDataType.Image);
                        cbDynamicBarBarLeft.RefreshList(true, MaterialDataType.Image);
                        cbDynamicBarBarRight.RefreshList(true, MaterialDataType.Image);
                        rfdynamicbar = true;

                        if (CurrentSkin != null)
                        {
                            cbDynamicBarBackground.Select(CurrentSkin.DynamicBar.BackgroundID);
                            cbDynamicBarLeft.Select(CurrentSkin.DynamicBar.LeftID);
                            cbDynamicBarRight.Select(CurrentSkin.DynamicBar.RightID);
                            cbDynamicBarBarBackground.Select(CurrentSkin.DynamicBar.BarBackgroundID);
                            cbDynamicBarBarLeft.Select(CurrentSkin.DynamicBar.BarLeftID);
                            cbDynamicBarBarRight.Select(CurrentSkin.DynamicBar.BarRightID);
                        }
                    }
                    break;
                case 4:
                    //Window
                    if (!rfwindow)
                    {
                        cbWindowBackground.RefreshList(true, MaterialDataType.Image);
                        cbBorderTop.RefreshList(true, MaterialDataType.Image);
                        cbBorderBottom.RefreshList(true, MaterialDataType.Image);
                        cbBorderLeft.RefreshList(true, MaterialDataType.Image);
                        cbBorderRight.RefreshList(true, MaterialDataType.Image);
                        cbBorderTopLeft.RefreshList(true, MaterialDataType.Image);
                        cbBorderTopRight.RefreshList(true, MaterialDataType.Image);
                        cbBorderBottomLeft.RefreshList(true, MaterialDataType.Image);
                        cbBorderBottomRight.RefreshList(true, MaterialDataType.Image);
                        rfwindow = true;

                        if (CurrentSkin != null)
                        {
                            cbWindowBackground.Select(CurrentSkin.Window.BackgroundID);

                            cbBorderTop.Select(CurrentSkin.Window.TopID);
                            cbBorderBottom.Select(CurrentSkin.Window.BottomID);

                            cbBorderLeft.Select(CurrentSkin.Window.LeftID);
                            cbBorderRight.Select(CurrentSkin.Window.RightID);

                            cbBorderTopLeft.Select(CurrentSkin.Window.TopLeftID);
                            cbBorderTopRight.Select(CurrentSkin.Window.TopRightID);

                            cbBorderBottomLeft.Select(CurrentSkin.Window.BottomLeftID);
                            cbBorderBottomRight.Select(CurrentSkin.Window.BottomRightID);
                        }
                    }
                    break;
                case 5:
                    //Pointer
                    if (!rfpointer)
                    {
                        cbPointerAni.RefreshList(false);
                        cbPointerAction.RefreshList(false, cbPointerAni.Data());
                        cbPointerDir.SelectedIndex = 0;

                        rfpointer = true;
                        if (CurrentSkin != null)
                        {
                            cbPointerAni.Select(CurrentSkin.Pointer.AnimationID);
                            cbPointerAction.RefreshList(false, cbPointerAni.Data());
                            cbPointerAction.Select(CurrentSkin.Pointer.ActionID);
                        }
                    }
                    break;
                case 6:
                    //Cursor
                    if (!rfcursor)
                    {
                        cbCursorBackground.RefreshList(true, MaterialDataType.Image);
                        rfcursor = true;
                        if (CurrentSkin != null)
                        {
                            cbCursorBackground.Select(CurrentSkin.Cursor.BackgroundID);
                        }
                    }
                    break;
            }

            allowChange = true;
            undoRedoChange = true;
        }
        private void AssignControls()
        {
            undoRedoChange = false;
            allowChange = false;
            // --------- Combo Boxes ---------//
            //Button
            cbButtonBack.Select(CurrentSkin.Button.BackgroundID);
            cbButtonLeft.Select(CurrentSkin.Button.LeftID);
            cbButtonRight.Select(CurrentSkin.Button.RightID);
            //Text
            cbTextBackground.Select(CurrentSkin.Text.BackgroundID);
            cbTextLeft.Select(CurrentSkin.Text.LeftID);
            cbTextRight.Select(CurrentSkin.Text.RightID);
            //Dynamic Bar
            cbDynamicBarBackground.Select(CurrentSkin.DynamicBar.BackgroundID);
            cbDynamicBarLeft.Select(CurrentSkin.DynamicBar.LeftID);
            cbDynamicBarRight.Select(CurrentSkin.DynamicBar.RightID);
            cbDynamicBarBarBackground.Select(CurrentSkin.DynamicBar.BarBackgroundID);
            cbDynamicBarBarLeft.Select(CurrentSkin.DynamicBar.BarLeftID);
            cbDynamicBarBarRight.Select(CurrentSkin.DynamicBar.BarRightID);
            //Cursor
            cbCursorBackground.Select(CurrentSkin.Cursor.BackgroundID);
            //Window
            cbWindowBackground.Select(CurrentSkin.Window.BackgroundID);

            cbBorderTop.Select(CurrentSkin.Window.TopID);
            cbBorderBottom.Select(CurrentSkin.Window.BottomID);

            cbBorderLeft.Select(CurrentSkin.Window.LeftID);
            cbBorderRight.Select(CurrentSkin.Window.RightID);

            cbBorderTopLeft.Select(CurrentSkin.Window.TopLeftID);
            cbBorderTopRight.Select(CurrentSkin.Window.TopRightID);

            cbBorderBottomLeft.Select(CurrentSkin.Window.BottomLeftID);
            cbBorderBottomRight.Select(CurrentSkin.Window.BottomRightID);

            //List
            cbListBackground.Select(CurrentSkin.List.BackgroundID);

            cbListTop.Select(CurrentSkin.List.TopID);
            cbListBottom.Select(CurrentSkin.List.BottomID);

            cbListLeft.Select(CurrentSkin.List.LeftID);
            cbListRight.Select(CurrentSkin.List.RightID);

            cbListTopLeft.Select(CurrentSkin.List.TopLeftID);
            cbListTopRight.Select(CurrentSkin.List.TopRightID);

            cbListBottomLeft.Select(CurrentSkin.List.BottomLeftID);
            cbListBottomRight.Select(CurrentSkin.List.BottomRightID);

            // Pointer
            cbPointerAni.Select(CurrentSkin.Pointer.AnimationID);
            cbPointerAction.RefreshList(false, cbPointerAni.Data());
            cbPointerAction.Select(CurrentSkin.Pointer.ActionID);
            cbPointerDir.SelectedIndex = CurrentSkin.Pointer.Direction;

            // --------- NuD Boxes ---------//
            //Cursor
            nudCursorHotX.Value = (decimal)CurrentSkin.Cursor.Hotspot.X;
            nudCursorHotY.Value = (decimal)CurrentSkin.Cursor.Hotspot.Y;
            nudCursorHotX.OnChange = false;
            nudCursorHotY.OnChange = false;
            allowChange = true;
            // --------- Check Boxes ---------//
            //Button
            cbButtonRounded.Checked = CurrentSkin.Button.Rounded;
            //Text
            cbTextRounded.Checked = CurrentSkin.Text.Rounded;
            //DynamicBar
            cbDynamicBarRounded.Checked = CurrentSkin.DynamicBar.Rounded;

            undoRedoChange = true;
        }
        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion

        #region IEditor Members

        public void SetupList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CheckBox Events
        private void cbButtonRounded_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;

            if (undoRedoChange)
                MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            if (cbButtonRounded.Checked)
            {
                lblButtonBackground.Text = "Center:";
                cbButtonLeft.Enabled = true;
                cbButtonRight.Enabled = true;
            }
            else
            {
                lblButtonBackground.Text = "Background:";
                cbButtonLeft.Enabled = false;
                cbButtonRight.Enabled = false;
            }

            CurrentSkin.Button.Rounded = cbButtonRounded.Checked;
        }

        private void cbTextRounded_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (undoRedoChange)
                MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            if (cbTextRounded.Checked)
            {
                lblTextBackground.Text = "Center:";
                cbTextLeft.Enabled = true;
                cbTextRight.Enabled = true;
            }
            else
            {
                lblTextBackground.Text = "Background:";
                cbTextLeft.Enabled = false;
                cbTextRight.Enabled = false;
            }

            CurrentSkin.Text.Rounded = cbTextRounded.Checked;
        }

        private void cbDynamicBarRounded_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (undoRedoChange)
                MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            if (cbDynamicBarRounded.Checked)
            {
                lblDynamicBarBackground.Text = "Center:";
                cbDynamicBarLeft.Enabled = true;
                cbDynamicBarRight.Enabled = true;
                lblDynamicBarBarBackground.Text = "Center:";
                cbDynamicBarBarLeft.Enabled = true;
                cbDynamicBarBarRight.Enabled = true;
            }
            else
            {
                lblDynamicBarBackground.Text = "Background:";
                cbDynamicBarLeft.Enabled = false;
                cbDynamicBarRight.Enabled = false;
                lblDynamicBarBarBackground.Text = "Background:";
                cbDynamicBarBarLeft.Enabled = false;
                cbDynamicBarBarRight.Enabled = false;
            }

            CurrentSkin.DynamicBar.Rounded = cbDynamicBarRounded.Checked;
        }
        #endregion

        #region ComboBox Events
        private void cbButtonBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Button.BackgroundID = cbButtonBack.Data().ID;
        }
        private void cbButtonLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Button.LeftID = cbButtonLeft.Data().ID;
        }

        private void cbButtonRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Button.RightID = cbButtonRight.Data().ID;
        }

        private void cbTextBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Text.BackgroundID = cbTextBackground.Data().ID;
        }

        private void cbTextLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Text.LeftID = cbTextLeft.Data().ID;
        }

        private void cbTextRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Text.RightID = cbTextRight.Data().ID;
        }

        private void cbDynamicBarBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.DynamicBar.BackgroundID = cbDynamicBarBackground.Data().ID;
        }

        private void cbDynamicBarLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.DynamicBar.LeftID = cbDynamicBarLeft.Data().ID;
        }

        private void cbDynamicBarRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.DynamicBar.RightID = cbDynamicBarRight.Data().ID;
        }

        private void cbDynamicBarBarBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.DynamicBar.BarBackgroundID = cbDynamicBarBarBackground.Data().ID;
        }

        private void cbDynamicBarBarLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.DynamicBar.BarLeftID = cbDynamicBarBarLeft.Data().ID;
        }

        private void cbDynamicBarBarRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.DynamicBar.BarRightID = cbDynamicBarBarRight.Data().ID;
        }

        private void cbCursorBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Cursor.BackgroundID = cbCursorBackground.Data().ID;
        }

        private void cbWindowBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.BackgroundID = cbWindowBackground.Data().ID;
        }

        private void cbBorderTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.TopID = cbBorderTop.Data().ID;
        }

        private void cbBorderBottom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.BottomID = cbBorderBottom.Data().ID;
        }

        private void cbBorderLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.LeftID = cbBorderLeft.Data().ID;
        }

        private void cbBorderRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.RightID = cbBorderRight.Data().ID;
        }

        private void cbBorderTopLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.TopLeftID = cbBorderTopLeft.Data().ID;
        }

        private void cbBorderTopRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.TopRightID = cbBorderTopRight.Data().ID;
        }

        private void cbBorderBottomLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.BottomLeftID = cbBorderBottomLeft.Data().ID;
        }

        private void cbBorderBottomRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Window.BottomRightID = cbBorderBottomRight.Data().ID;
        }


        private void cbListBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.BackgroundID = cbListBackground.Data().ID;
        }

        private void cbListTopLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.TopLeftID = cbListTopLeft.Data().ID;
        }

        private void cbListTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.TopID = cbListTop.Data().ID;
        }

        private void cbListTopRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.TopRightID = cbListTopRight.Data().ID;
        }

        private void cbListLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.LeftID = cbListLeft.Data().ID;
        }

        private void cbListRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.RightID = cbListRight.Data().ID;
        }

        private void cbListBottomLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.BottomLeftID = cbListBottomLeft.Data().ID;
        }

        private void cbListBottom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.BottomID = cbListBottom.Data().ID;
        }

        private void cbListBottomRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.List.BottomRightID = cbListBottomRight.Data().ID;
        }
        #endregion

        #region NuD Events & Other
        private void nudCursorHotX_ValueChanged(object sender, EventArgs e)
        {
            CurrentSkin.Cursor.Hotspot = new Vector2((float)nudCursorHotX.Value, (float)nudCursorHotY.Value);
        }

        private void nudCursorHotY_ValueChanged(object sender, EventArgs e)
        {
            CurrentSkin.Cursor.Hotspot = new Vector2((float)nudCursorHotX.Value, (float)nudCursorHotY.Value);
        }

        private void nudCursorHotX_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (addRemoveList.Data().ID < 0) return;

            if (nudCursorHotX.OnChange)
            {
                float newValue = addRemoveList.Data<SkinData>().Cursor.Hotspot.X;
                addRemoveList.Data<SkinData>().Cursor.Hotspot = new Vector2((float)nudCursorHotX.OldValue, addRemoveList.Data<SkinData>().Cursor.Hotspot.Y);
                MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                addRemoveList.Data<SkinData>().Cursor.Hotspot = new Vector2(newValue, addRemoveList.Data<SkinData>().Cursor.Hotspot.Y);
                nudCursorHotX.OnChange = false;
            }
        }

        private void nudCursorHotY_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (addRemoveList.Data().ID < 0) return;

            if (nudCursorHotY.OnChange)
            {
                float newValue = addRemoveList.Data<SkinData>().Cursor.Hotspot.Y;
                addRemoveList.Data<SkinData>().Cursor.Hotspot = new Vector2(addRemoveList.Data<SkinData>().Cursor.Hotspot.X, (float)nudCursorHotY.OldValue);
                MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                addRemoveList.Data<SkinData>().Cursor.Hotspot = new Vector2(addRemoveList.Data<SkinData>().Cursor.Hotspot.X, newValue);
                nudCursorHotY.OnChange = false;
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void cbMenuPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide all panels
            gbMain.SuspendLayout();
            pnPointer.Visible = pnButton.Visible =
             pnList.Visible =
             pnText.Visible =
              pnDynamicBar.Visible =
             pnWindow.Visible =
              pnCursor.Visible = false;
            //Button 0
            //Text 1 
            //Dynamic Bar 2
            //Window 3
            //Selection Pointer 4
            switch (cbMenuPart.SelectedIndex)
            {
                case 0:
                    pnButton.Visible = true; PopulateComboBoxes();
                    break;
                case 1:
                    pnList.Visible = true; PopulateComboBoxes();
                    break;
                case 2:
                    pnText.Visible = true; PopulateComboBoxes();
                    break;
                case 3:
                    pnDynamicBar.Visible = true; PopulateComboBoxes();
                    break;
                case 4:
                    pnWindow.Visible = true; PopulateComboBoxes();
                    break;
                case 5:
                    pnPointer.Visible = true; PopulateComboBoxes();
                    //pnCursor.Visible = true; PopulateComboBoxes();
                    break;
            }
            gbMain.ResumeLayout(true);
        }

        private void graphicsControl_OnDraw(object sender, EventArgs e)
        {
            graphicsControl.GraphicsDevice.Clear(Color.DarkGray);

            if (CurrentSkin != null && addRemoveList.Count > 0)
            {
                spriteBatch.Begin();
                DrawWindow(sampleWindow);
                DrawButton(sampleButton);
                DrawDynamicBarData(sampleDynamicBar);
                
                spriteBatch.End();
            }
        }

        private void graphicsControl_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(graphicsControl.GraphicsDevice);
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

            // Initialize Window
            sampleWindow = new MenuWindow();
            sampleWindow.Position = new Vector2(10, 10);
            sampleWindow.Width = 250;
            sampleWindow.Height = 150;
            sampleWindow.SkinID = CurrentSkin.ID;

            // Initialize Button
            sampleButton = new MenuButton();
            sampleButton.Position = new Vector2(10, 170);
            sampleButton.Width = 250;
            sampleButton.Height = 40;
            sampleButton.SkinID = CurrentSkin.ID;

            sampleDynamicBar = new DynamicBarVariable();
            sampleDynamicBar.Position = new Vector2(10, 210);
            sampleDynamicBar.Width = 250;
            sampleDynamicBar.Height = 40;
            sampleDynamicBar.SkinID = CurrentSkin.ID;
            sampleDynamicBar.VariableMin = 0;
            sampleDynamicBar.VariableMax = 100;
            sampleDynamicBar.VariableValue = 65;
        }

        private SkinData GetSkinFromID(int id)
        {
            return Global.GetData(id, GameData.Skins);
        }
        private Texture2D GetTextureFromID(int id)
        {
            Texture2D t = Loader.Texture2D(contentManager, id);
            if (t == null)
            {
                t = new Texture2D(graphicsControl.GraphicsDevice, 1, 1);
                t.Name = "BLANK";
            }
            return t;
        }

        /// <summary>
        /// Draw Menu Window
        /// </summary>
        /// <param name="menuWindow"></param>
        private void DrawWindow(MenuWindow menuWindow)
        {
            if (menuWindow.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuWindow.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTextureFromID(skin.Window.TopLeftID);
                    Texture2D topCenter = GetTextureFromID(skin.Window.TopID);
                    Texture2D topRight = GetTextureFromID(skin.Window.TopRightID);

                    Texture2D left = GetTextureFromID(skin.Window.LeftID);
                    Texture2D right = GetTextureFromID(skin.Window.RightID);

                    Texture2D bottomLeft = GetTextureFromID(skin.Window.BottomLeftID);
                    Texture2D bottomCenter = GetTextureFromID(skin.Window.BottomID);
                    Texture2D bottomRight = GetTextureFromID(skin.Window.BottomRightID);

                    // Calculate Areas
                    int X = (int)menuWindow.RealPosition.X;
                    int Y = (int)menuWindow.RealPosition.Y;

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuWindow.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuWindow.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuWindow.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuWindow.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuWindow.Height - bottomRight.Height;

                    int bottomY = (int)menuWindow.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuWindow.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((decimal)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuWindow.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((decimal)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuWindow.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((decimal)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuWindow.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((decimal)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    spriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        spriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    spriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    spriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    spriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    spriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        spriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    spriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTextureFromID(skin.Window.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuWindow.Width - left.Width - right.Width;
                    int centerHeight = (int)menuWindow.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            spriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        DrawGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuWindow.StartGradient, menuWindow.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuWindow.RealPosition.X, (int)menuWindow.RealPosition.Y, (int)menuWindow.Width, (int)menuWindow.Height), menuWindow.StartGradient, menuWindow.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuWindow.RealPosition.X, (int)menuWindow.RealPosition.Y, (int)menuWindow.Width, (int)menuWindow.Height), menuWindow.StartGradient, menuWindow.EndGradient);
            }
        }
        /// <summary>
        /// Draw Menu Button
        /// </summary>
        /// <param name="menuButton"></param>
        private void DrawButton(MenuButton menuButton)
        {
            if (menuButton.SkinID > -1)
            {
                SkinData skin = GetSkinFromID(menuButton.SkinID);
                if (skin != null)
                {
                    if (skin.Button.Rounded)
                    {
                        // Load Textures
                        Texture2D left = GetTextureFromID(skin.Button.LeftID);
                        Texture2D center = GetTextureFromID(skin.Button.BackgroundID);
                        Texture2D right = GetTextureFromID(skin.Button.RightID);

                        // Calculate areas
                        int centerStart = left.Width;
                        int rightStart = (int)menuButton.Width - right.Width;

                        int centerWidth = (int)menuButton.Width - right.Width - left.Width;
                        int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                        int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                        // Draw Left
                        spriteBatch.Draw(left, new Rectangle((int)menuButton.RealPosition.X, (int)menuButton.RealPosition.Y, left.Width, (int)menuButton.Height), Color.White);

                        if (center.Name != "BLANK")
                        {
                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuButton.RealPosition.X + centerStart + (i * center.Width)), (int)menuButton.RealPosition.Y, (int)center.Width, (int)menuButton.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuButton.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuButton.RealPosition.Y, (int)finalCenterTexels, (int)menuButton.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            DrawGradient(new Rectangle((int)menuButton.RealPosition.X + centerStart, (int)menuButton.RealPosition.Y, (int)centerWidth, (int)menuButton.Height), menuButton.StartGradient, menuButton.EndGradient);
                        }

                        // Draw Right
                        spriteBatch.Draw(right, new Rectangle((int)(menuButton.RealPosition.X + rightStart), (int)menuButton.RealPosition.Y, (int)right.Width, (int)menuButton.Height), Color.White);
                    }
                    else
                    {

                        // Load Textures
                        Texture2D center = GetTextureFromID(skin.Button.BackgroundID);

                        if (center.Name != "BLANK")
                        {
                            // Calculate areas
                            int centerWidth = (int)menuButton.Width;
                            int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuButton.RealPosition.X + (i * center.Width)), (int)menuButton.RealPosition.Y, (int)center.Width, (int)menuButton.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuButton.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuButton.RealPosition.Y, (int)finalCenterTexels, (int)menuButton.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            DrawGradient(new Rectangle((int)menuButton.RealPosition.X, (int)menuButton.RealPosition.Y, (int)menuButton.Width, (int)menuButton.Height), menuButton.StartGradient, menuButton.EndGradient);
                        }
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuButton.RealPosition.X, (int)menuButton.RealPosition.Y, (int)menuButton.Width, (int)menuButton.Height), menuButton.StartGradient, menuButton.EndGradient);
                }
            }
            else
            {
                DrawGradient(new Rectangle((int)menuButton.RealPosition.X, (int)menuButton.RealPosition.Y, (int)menuButton.Width, (int)menuButton.Height), menuButton.StartGradient, menuButton.EndGradient);
            }
        }

        private void DrawDynamicBarData(DynamicBarVariable menuPart)
        {
            if (menuPart.VariableValue >= 100)
            {
                barUp = false;
            }
            else if (menuPart.VariableValue <= 0)
            {
                barUp = true;
            }

            if (barUp)
            {
                menuPart.VariableValue++;
            }
            else
            {
                menuPart.VariableValue--;
            }

            if (menuPart.VariableValue >= menuPart.VariableMin && menuPart.VariableValue <= menuPart.VariableMax)
            {
                if (menuPart.SkinID > -1)
                {
                    SkinData skin = GetSkinFromID(menuPart.SkinID);
                    if (skin != null)
                    {
                        if (skin.DynamicBar.Rounded)
                        {
                            // Load Textures
                            Texture2D left = GetTextureFromID(skin.DynamicBar.LeftID);
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D right = GetTextureFromID(skin.DynamicBar.RightID);

                            // Load bar Textures
                            Texture2D barleft = GetTextureFromID(skin.DynamicBar.BarLeftID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);
                            Texture2D barright = GetTextureFromID(skin.DynamicBar.BarRightID);

                            // Calculate areas
                            int centerStart = left.Width;
                            int rightStart = (int)menuPart.Width - right.Width;

                            int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                            int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);


                            // Draw Left
                            spriteBatch.Draw(left, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, left.Width, (int)menuPart.Height), Color.White);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }

                            // Draw Right
                            spriteBatch.Draw(right, new Rectangle((int)(menuPart.RealPosition.X + rightStart), (int)menuPart.RealPosition.Y, (int)right.Width, (int)menuPart.Height), Color.White);

                            ///// BAR
                            // calculate areas
                            int barcenterStart = barleft.Width;
                            int barrightStart = (int)menuPart.Width - barright.Width;

                            // calucate bar width based on the current value and its min and max
                            int min = menuPart.VariableMin;
                            int max = menuPart.VariableMax;
                            int val = menuPart.VariableValue;
                            int maxval = max - min;
                            int valinmax = val - min;
                            decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;

                            int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                            if (barWidth < barleft.Width)
                            {
                                // Draw Left
                                spriteBatch.Draw(barleft, new Rectangle((int)(menuPart.RealPosition.X), (int)menuPart.RealPosition.Y, (int)barWidth, (int)menuPart.Height), new Rectangle(0, 0, barWidth, (int)barleft.Height), Color.White);
                            }
                            else
                            {
                                int barcenterWidth = (int)barWidth - barleft.Width; //- barright.Width;
                                if (barcenterWidth > 0)
                                {
                                    if (barcenterWidth > (menuPart.Width - barleft.Width - barright.Width))
                                        barcenterWidth = (int)(menuPart.Width - barleft.Width - barright.Width);

                                    int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                    int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                    // Draw Left
                                    spriteBatch.Draw(barleft, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, barleft.Width, (int)menuPart.Height), Color.White);

                                    // Draw Repeated Center
                                    for (int i = 0; i < barfullCenterRepeats; i++)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                    }
                                    // Draw Leftover Center
                                    if (barfinalCenterTexels > 0)
                                    {
                                        spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                            new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                    }
                                    if (barWidth >= barrightStart)
                                    {
                                        // Draw Right
                                        spriteBatch.Draw(barright, new Rectangle((int)(menuPart.RealPosition.X + barrightStart), (int)menuPart.RealPosition.Y, (int)(barWidth - barrightStart), (int)menuPart.Height), new Rectangle(0, 0, barWidth - barrightStart, (int)barright.Height), Color.White);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Load Textures
                            Texture2D center = GetTextureFromID(skin.DynamicBar.BackgroundID);
                            Texture2D barcenter = GetTextureFromID(skin.DynamicBar.BarBackgroundID);

                            if (center.Name != "BLANK")
                            {
                                // Calculate areas
                                int centerWidth = (int)menuPart.Width;
                                int fullCenterRepeats = (int)Math.Floor((decimal)(centerWidth / center.Width));
                                int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < fullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (finalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                                }
                            }
                            else
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                            }

                            if (barcenter.Name != "BLANK")
                            {
                                // calucate bar width based on the current value and its min and max
                                int min = menuPart.VariableMin;
                                int max = menuPart.VariableMax;
                                int val = menuPart.VariableValue;
                                int maxval = max - min;
                                int valinmax = val - min;
                                decimal percentofvalinmax = (decimal)valinmax / (decimal)maxval;
                                int barWidth = (int)((decimal)menuPart.Width * percentofvalinmax);

                                int barcenterWidth = (int)barWidth;
                                int barfullCenterRepeats = (int)Math.Floor((decimal)(barcenterWidth / barcenter.Width));
                                int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                // Draw Repeated Center
                                for (int i = 0; i < barfullCenterRepeats; i++)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (barfinalCenterTexels > 0)
                                {
                                    spriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                }
                            }
                            else
                            {
                                DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.EndGradient, menuPart.StartGradient);
                            }
                        }
                    }
                    else
                    {
                        DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    DrawGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
        }

        public void DrawGradient(Rectangle rect, Color ColorTop, Color ColorBottom)
        {
            // Store the screen width and height into here. 
            // These values are used in 'texture', forloop,  
            // and used in the color function. 
            // 
            // You could change this in anyway you seem fit! 
            int width = rect.Width;
            int height = rect.Height;

            // Init all ColorTop & ColorBottom values.  
            int R1 = ColorTop.R, R2 = ColorBottom.R; // Red 
            int G1 = ColorTop.G, G2 = ColorBottom.G; // Green 
            int B1 = ColorTop.B, B2 = ColorBottom.B; // Blue 
            int A1 = ColorTop.A, A2 = ColorBottom.A; // Alpha 

            // Making a new texture with 1x1 pixel size 
            Texture2D texture =
                new Texture2D(graphicsControl.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            // Set the color data and make the sprite texture pure white 
            texture.SetData<Color>(new Color[] { Color.White });

            // Make a forloop that goes from the top of the 
            // screen to the bottom of the screen 
            for (int i = 0; i < height; i++)
            {
                // This color function to make the top colors 
                // blend with the bottom colors gradually. 
                // 
                // This also works for alpha too! You can make the bottom 
                // or top trasparent! 
                int r = R1 + (i * (R2 - R1) / height); // Red Colors 
                int g = G1 + (i * (G2 - G1) / height); // Green Colors 
                int b = B1 + (i * (B2 - B1) / height); // Blue Colors 
                int a = A1 + (i * (A2 - A1) / height); // Aplha Channels 

                // Put all colors into 'colordata' 
                Color ColorData = new Color((byte)r, (byte)g, (byte)b, (byte)a);

                // Draw the spriteline on the screen with the color data 
                spriteBatch.Draw(texture,           // Texture 
                    new Vector2(rect.X, rect.Y + i),              // Position 
                    new Rectangle(0, 0, width, 1),  // Coverage Area 
                    ColorData);                     // Color 
            }
        }

        private void UpdateSampleIDs()
        {
            sampleWindow.SkinID = CurrentSkin.ID;
            sampleButton.SkinID = CurrentSkin.ID;
            sampleDynamicBar.SkinID = CurrentSkin.ID;
        }

        internal void ResetProject()
        {
            addRemoveList.SetupList(GameData.Skins, typeof(SkinData));
            PopulateComboBoxes();
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
        }

        internal void Unload()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

        }

        private void cbPointerAni_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPointerAction.RefreshList(false, cbPointerAni.Data());

            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Pointer.AnimationID = cbPointerAni.Data().ID;
        }

        private void cbPointerAction_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Pointer.ActionID = cbPointerAction.Data().ID;

        }

        private void cbPointerDir_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!allowChange) return;
            MainForm.SkinHistory[MainForm.skinEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            CurrentSkin.Pointer.Direction = cbPointerDir.SelectedIndex;
        }
    }
}
