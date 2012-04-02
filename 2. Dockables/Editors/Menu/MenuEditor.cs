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
using EGMGame.Library;
namespace EGMGame.Docking.Editors
{
    public partial class MenuEditor : DockContent, IHistory, IEditor
    {
        public MenuEditor()
        {

            InitializeComponent();
            
            MainForm.MenuEditorHistory[menuViewer1] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);

            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }

        private void MenuEditor_Activated(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
                SetupProperty(addRemoveList.Data<MenuData>());
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.MenuEditorHistory[menuViewer1];
        }

        private void MenuEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Menus, typeof(MenuData));
            MainForm.menuPropertyExplorer.propertyGrid.SelectedObject = addRemoveList.Data();
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Menus.Add(data.ID, (MenuData)data);
            addRemoveList.AddNode(data);

            Global.CBMenus();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Menus.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBMenus();
        }
        #endregion

        #region Add Remove List Events
        private void menuList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                MenuData a = new MenuData();
                a.Name = Global.GetName("Menu", GameData.Menus);
                a.ID = Global.GetID(GameData.Menus);
                a.Category = ca.Category;
                a.CanvasSize = new Microsoft.Xna.Framework.Vector2(Global.Project.ScreenRatio.X, Global.Project.ScreenRatio.Y);
                GameData.Menus.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.MenuEditorHistory[menuViewer1].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                
                addRemoveList.AddNode(a);

                Global.CBMenus();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "33x002");
            }
        }

        private void menuList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Menus.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.MenuEditorHistory[menuViewer1].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    
                    GameData.Menus.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Menus[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBMenus();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "33x003");
            }
        }

        private void menuList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Menus.ContainsKey(e.ID))
                    SetupProperty(GameData.Menus[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "33x004");
            }
        }
        #endregion

        #region Methods
        private void SetupProperty(MenuData menuData)
        {
            menuViewer1.SelectedMenu = menuData;

            MainForm.menuPropertyExplorer.PopulateMenuParts(menuData);
        }

        public void SetupList()
        {

        }

        #endregion

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

        private void addRemoveList_Load(object sender, EventArgs e)
        {

        }


        internal void ResetProject()
        {
            addRemoveList.SetupList(GameData.Menus, typeof(MenuData));
            menuViewer1.ResetContentManager();
        }

        internal void Unload()
        {
            menuViewer1.ResetContentManager();
        }
    }
}
