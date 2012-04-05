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
using EGMGame.Library;
using GenericUndoRedo;
using System.IO;
using EGMGame.Docking.Explorers;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Controls;
using Microsoft.Xna.Framework;

namespace EGMGame.Docking.Editors
{
    public partial class TilesetEditor : DockContent, IHistory, IEditor
    {
        public TilesetEditor()
        {
            MainForm.TilesetHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

            cbAutoTileAreas.SelectedIndex = 0;
        }
        /// <summary>
        /// Called when the tileset editor is shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TilesetEditor_Shown(object sender, EventArgs e)
        {
            SetupList();
        }
        /// <summary>
        /// Sets up the list of tilesets.
        /// </summary>
        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Tilesets, typeof(TilesetData));
            if (selectTileset > -1)
                addRemoveList.Select(selectTileset);
            selectTileset = -1;
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            if (data is TilesetData)
            {
                GameData.Tilesets.Add(data.ID, (TilesetData)data);
                addRemoveList.AddNode(data);
            }
            else if (data is AutoTileData)
            {
                ((TilesetData)hist.Parent).Autotiles.Add((AutoTileData)data);
                autotileList.AddNode(data);
            }
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            if (data is TilesetData)
            {
                GameData.Tilesets.Remove(data.ID);

                addRemoveList.RemoveNode(data);
            }
            else if (data is AutoTileData)
            {
                ((TilesetData)hist.Parent).Autotiles.Remove((AutoTileData)data);
                autotileList.RemoveNode(data);
            }
        }
        #endregion
        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                TilesetData a = new TilesetData();
                a.Name = Global.GetName("Tileset", GameData.Tilesets);
                a.ID = Global.GetID(GameData.Tilesets);
                a.Category = ca.Category;
                a.Grid = new Microsoft.Xna.Framework.Vector2(Global.Project.DefaultGridSize.X, Global.Project.DefaultGridSize.Y);
                GameData.Tilesets.Add(a.ID, a);

                // History
                MainForm.TilesetHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);
                MainForm.mapEditor.PopulateTilesets();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "52x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Tilesets.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.TilesetHistory[this].Do(new IGameDataAddedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Tilesets.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Tilesets[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);
                    MainForm.mapEditor.PopulateTilesets();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "52x003");
            }
        }
        /// <summary>
        /// When an Item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ca"></param>
        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Tilesets.ContainsKey(e.ID))
                {
                    SetupProperty(GameData.Tilesets[e.ID]);
                    tilesetViewer.Tip = "Drag and Drop Image From Material Explorer";
                }
                else
                {
                    SetupProperty(null);
                    tilesetViewer.Tip = "";
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "52x002");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="tilesetData"></param>
        private void SetupProperty(TilesetData obj)
        {
            // Set Tilesetviewer tileset
            tilesetViewer.SelectedTileset = obj;
            if (obj != null)
            {
                tabControl1.Enabled = true;
                undoRedoChange = false;
                if (GetTexture(obj) != null)
                {
                    colBox.Maximum = GetTexture(obj).Width;
                    rowBox.Maximum = GetTexture(obj).Height;
                }
                else
                {
                    colBox.Maximum = 99999;
                    rowBox.Maximum = 99999;
                }
                colBox.Value = Math.Min((decimal)obj.Grid.X, colBox.Maximum);
                rowBox.Value = Math.Min((decimal)obj.Grid.Y, rowBox.Maximum);
                colBox.OnChange = false;
                rowBox.OnChange = false;
                undoRedoChange = true;

                autotileList.SetupList(obj.Autotiles, typeof(AutoTileData));
            }
            else
            {
                tabControl1.Enabled = false;
            }
        }

        private void TilesetEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.TilesetHistory[this];
        }

        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        /// <summary>
        /// Drag drop tileset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tilesetViewer_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Tilesets.ContainsKey(addRemoveList.SelectedID))
                {
                    if (e.Data.GetDataPresent(typeof(TreeNode)))
                    {
                        TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                        MaterialData m = MainForm.materialExplorer.Data();

                        if (m != null)
                        {
                            GameData.Tilesets[addRemoveList.SelectedID].MaterialId = m.ID;
                            tilesetViewer.SelectedTileset = GameData.Tilesets[addRemoveList.SelectedID];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "52x004");
            }
        }
        /// <summary>
        /// When a material is dragged, check if its image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tilesetViewer_DragEnter(object sender, DragEventArgs e)
        {
            if (addRemoveList.SelectedIndex >= 0 && GameData.Tilesets.ContainsKey(addRemoveList.SelectedID))
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    if (node.Parent != null)
                    {
                        MaterialData m = MainForm.materialExplorer.Data();

                        if (m != null)
                        {
                            FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, m.FileName));
                            string ext = file.Extension.ToLower();
                            if (ext == ".png" || ext == ".bmp" || ext == ".jpg" || ext == ".jpeg")
                                e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// When columns changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colBox_ValueChanged(object sender, EventArgs e)
        {
            tilesetViewer.GridWidth = (int)colBox.Value;
            MainForm.TilesetViewer.Setup();
        }
        /// <summary>
        /// When rows changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rowBox_ValueChanged(object sender, EventArgs e)
        {
            tilesetViewer.GridHeight = (int)rowBox.Value;
            MainForm.TilesetViewer.Setup();
        }
        /// <summary>
        /// Update Tile Property
        /// </summary>
        /// <param name="e"></param>
        private void tilesetViewer_TileSelectedEvent(EGMGame.Controls.TileEventArgs e)
        {
            if (GameData.Tilesets.ContainsKey(addRemoveList.SelectedID))
            {
                propertyGrid.SelectedObjects =  (e.SelectedTiles == null ? null : e.SelectedTiles.ToArray());
            }
        }
        /// <summary>
        /// Property Tile Changed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>

        bool undoRedoChange = true;
        internal void PropertyTileChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (data == addRemoveList.Data())
            {
                SetupProperty((TilesetData)data);
            }
            undoRedoChange = true;
        }

        internal void TilePropetyChanged(TileDataChangePropertyHist hist, TileData data)
        {
            undoRedoChange = false;
            if (propertyGrid.SelectedObjects.Contains(data))
            {
                propertyGrid.Refresh();
            }
            undoRedoChange = true;
        }
        internal void TilesPropetyChanged(TilesDataChangePropertyHist hist, object[] data)
        {
            undoRedoChange = false;
            propertyGrid.Refresh();
            undoRedoChange = true;
        }
        /// <summary>
        /// Size grid to the tileset's image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fitToImagebtn_Click(object sender, EventArgs e)
        {
            if (GameData.Tilesets.ContainsKey(addRemoveList.SelectedID))
            {
                Texture2D tex = GetTexture(GameData.Tilesets[addRemoveList.SelectedID]);
                if (tex != null)
                {
                    MainForm.TilesetHistory[this].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyTileChanged)));

                    colBox.Value = (decimal)tex.Width;
                    rowBox.Value = (decimal)tex.Height;
                }
            }
        }

        /// <summary>
        /// Default Btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultBtn_Click(object sender, EventArgs e)
        {
            if (GameData.Tilesets.ContainsKey(addRemoveList.SelectedID))
            {
                MainForm.TilesetHistory[this].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyTileChanged)));
                colBox.Value = Math.Min((decimal)Global.Project.DefaultGridSize.X, colBox.Maximum);
                rowBox.Value = Math.Min((decimal)Global.Project.DefaultGridSize.Y, rowBox.Maximum);
            }
        }
        /// <summary>
        /// Get the texture request from the given tileset
        /// </summary>
        /// <param name="tileset"></param>
        /// <returns></returns>
        private Texture2D GetTexture(TilesetData tileset)
        {
            try
            {
                if (tileset.MaterialId > -1 && GameData.Materials.ContainsKey(tileset.MaterialId))
                {
                    return Loader.Texture2D(tilesetViewer.contentManager, tileset.MaterialId);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            object newValue;
            if (propertyGrid.SelectedObjects.Length == 1)
            {
                foreach (TileData data in propertyGrid.SelectedObjects)
                {
                    newValue = e.ChangedItem.PropertyDescriptor.GetValue(data);
                    e.ChangedItem.PropertyDescriptor.SetValue(data, e.OldValue);
                    MainForm.TilesetHistory[this].Do(new TileDataChangePropertyHist(data, new DataTilePropertyDelegate(TilePropetyChanged)));
                    e.ChangedItem.PropertyDescriptor.SetValue(data, newValue);
                }
            }
            else if (propertyGrid.SelectedObjects.Length > 1)
            {
                newValue = e.ChangedItem.PropertyDescriptor.GetValue(propertyGrid.SelectedObjects);
                e.ChangedItem.PropertyDescriptor.SetValue(propertyGrid.SelectedObjects, e.OldValue);
                MainForm.TilesetHistory[this].Do(new TilesDataChangePropertyHist(propertyGrid.SelectedObjects, e.ChangedItem.PropertyDescriptor, e.OldValue, newValue, new DataTilesPropertyDelegate(TilesPropetyChanged)));
                e.ChangedItem.PropertyDescriptor.SetValue(propertyGrid.SelectedObjects, newValue);
            }
        }

        private void colBox_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (addRemoveList.Data().ID < 0) return;

            if (colBox.OnChange)
            {
                float newValue = addRemoveList.Data<TilesetData>().Grid.X;
                addRemoveList.Data<TilesetData>().Grid = new Vector2((float)colBox.OldValue, addRemoveList.Data<TilesetData>().Grid.Y);
                MainForm.TilesetHistory[this].Do(new IGameDataChangePropertyHist(addRemoveList.Data<TilesetData>(), new DataPropertyDelegate(PropertyTileChanged)));
                addRemoveList.Data<TilesetData>().Grid = new Vector2(newValue, addRemoveList.Data<TilesetData>().Grid.Y);
                colBox.OnChange = false;
            }
        }

        private void rowBox_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (addRemoveList.Data().ID < 0) return;

            if (rowBox.OnChange)
            {
                float newValue = addRemoveList.Data<TilesetData>().Grid.Y;
                addRemoveList.Data<TilesetData>().Grid = new Vector2(addRemoveList.Data<TilesetData>().Grid.X, (float)rowBox.OldValue);

                MainForm.TilesetHistory[this].Do(new IGameDataChangePropertyHist(addRemoveList.Data<TilesetData>(), new DataPropertyDelegate(PropertyTileChanged)));

                addRemoveList.Data<TilesetData>().Grid = new Vector2(addRemoveList.Data<TilesetData>().Grid.X, newValue);
                rowBox.OnChange = false;
            }
        }

        private void btnAutotiles_Click(object sender, EventArgs e)
        {

        }

        internal void ResetProject()
        {
            tilesetViewer.ResetContentManager();
            autoTileViewer.ResetContentManager();
            SetupList();
        }

        #region Autotiles
        private void autotileList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID > -1)
            {
                try
                {
                    AutoTileData a = new AutoTileData();
                    a.Name = Global.GetName("Autotile", addRemoveList.Data<TilesetData>().Autotiles);
                    a.ID = Global.GetID(addRemoveList.Data<TilesetData>().Autotiles);
                    a.Category = ca.Category;
                    addRemoveList.Data<TilesetData>().Autotiles.Add(a);

                    // History
                    MainForm.TilesetHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved), addRemoveList.Data<TilesetData>()));

                    autotileList.AddNode(a);
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "52x007");
                }
            }
        }

        private void autotileList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID > -1)
            {
                try
                {
                    if (autotileList.Data().ID > -1)
                    {
                        // History
                        MainForm.TilesetHistory[this].Do(new IGameDataAddedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved), addRemoveList.Data<TilesetData>()));

                        addRemoveList.Data<TilesetData>().Autotiles.Remove(autotileList.Data<AutoTileData>());
                        autotileList.RemoveSelectedNode();
                        if (autotileList.Data().ID > -1)
                            SetupPropertyAuto(autotileList.Data<AutoTileData>());
                        else
                            SetupPropertyAuto(null);
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "52x005");
                }
            }
        }

        private void autotileList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                if (autotileList.Data().ID > -1)
                {
                    SetupPropertyAuto(autotileList.Data<AutoTileData>());
                }
                else
                {
                    SetupPropertyAuto(null);
                    tilesetViewer.Tip = "";
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "52x006");
            }
        }

        private void SetupPropertyAuto(AutoTileData data)
        {
            if (data != null)
            {
                cbAutoTileAreas.Enabled = true;
                autoTileViewer.Enabled = true;
                btnAddTile.Enabled = true;
                cbAutoTileAreas.SelectedIndex = cbAutoTileAreas.SelectedIndex;
                if (autotileList.Data().ID > -1)
                {
                    autoTileViewer.Tileset = addRemoveList.Data<TilesetData>();
                    int index = autotileList.Data<AutoTileData>().TileIndex[cbAutoTileAreas.SelectedIndex];
                    if (index > -1 && index < addRemoveList.Data<TilesetData>().Tiles.Count)
                        autoTileViewer.Tile = addRemoveList.Data<TilesetData>().Tiles[index];
                    else
                        autoTileViewer.Tile = null;
                }
                else
                {
                    autoTileViewer.Tile = null;
                }
            }
            else
            {
                cbAutoTileAreas.Enabled = false;
                autoTileViewer.Enabled = false;
                btnAddTile.Enabled = false;
            }
        }

        private void cbAutoTileAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autotileList.Data().ID > -1)
            {
                autoTileViewer.Tileset = addRemoveList.Data<TilesetData>();
                int index = autotileList.Data<AutoTileData>().TileIndex[cbAutoTileAreas.SelectedIndex];
                if (index > -1 && index < addRemoveList.Data<TilesetData>().Tiles.Count)
                    autoTileViewer.Tile = addRemoveList.Data<TilesetData>().Tiles[index];
                else
                    autoTileViewer.Tile = null;
            }
            else
            {
                autoTileViewer.Tile = null;
            }
        }
        private void btnAddTile_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                if (autotileList.Data().ID > -1)
                {
                    if (tilesetViewer.selectedTiles.Count > 0)
                    {
                        autotileList.Data<AutoTileData>().TileIndex[cbAutoTileAreas.SelectedIndex] = addRemoveList.Data<TilesetData>().Tiles.IndexOf(tilesetViewer.selectedTiles[0]);
                        autoTileViewer.Tile = tilesetViewer.selectedTiles[0];
                    }
                }
            }
        }
        #endregion


        internal void Unload()
        {
            tilesetViewer.ResetContentManager();
            autoTileViewer.ResetContentManager();
        }

        int selectTileset = -1;
        internal void SelectTilest(int p)
        {
            selectTileset = p;
            addRemoveList.Select(p);
        }
    }
}

//// Check Format
//if (e.Data.GetDataPresent(DataFormats.FileDrop))
//{
//    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
//    // Check if file exist
//    if (File.Exists(files[0]))
//    {
//        FileInfo file = new FileInfo(files[0]);
//        if (file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".bmp" || file.Extension.ToLower() == ".jpg")
//        {
//            GameData.Tilesets[addRemoveList.SelectedID].FileName = file.FullName;
//            SetupProperty(GameData.Tilesets[addRemoveList.SelectedID]);
//        }
//    }
//}
//else 
// Check Format
//if (e.Data.GetDataPresent(DataFormats.FileDrop))
//{
//    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
//    // Check if file exist
//    if (File.Exists(files[0]))
//    {
//        FileInfo file = new FileInfo(files[0]);
//        if (file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".bmp" || file.Extension.ToLower() == ".jpg")
//            e.Effect = DragDropEffects.Copy;
//    }
//}
//else 