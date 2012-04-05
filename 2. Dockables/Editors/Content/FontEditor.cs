//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;
using GenericUndoRedo;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using EGMGame.Docking.Explorers;
using EGMGame.Controls;

namespace EGMGame.Docking.Editors
{
    public partial class FontEditor : DockContent, IEditor, IHistory
    {
        public FontData CurrentFont;

        SpriteBatch spriteBatch;
        ContentManager contentManager;

        public FontStyleData CurrentStyle;

        bool allowChange = true;

        public FontEditor()
        {
            MainForm.FontHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

            // Application Event Hooking 
            Application.Idle += delegate { graphicsControl.Invalidate(); };
            this.Resize += delegate { graphicsControl.Invalidate(); };
        }

        private void FontEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Fonts, typeof(FontData));
        }

        private void FontEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.FontHistory[this];
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Fonts.Add(data.ID, (FontData)data);
            addRemoveList.AddNode(data);

        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Fonts.Remove(data.ID);

            addRemoveList.RemoveNode(data);

        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataSAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<FontStyleData>)hist.Collection).Insert(hist.Index, (FontStyleData)data);
            stylesAddRemoveList.AddNode(data);

        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataSRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<FontStyleData>)hist.Collection).Remove((FontStyleData)data);

            stylesAddRemoveList.RemoveNode(data);

        }
        #endregion

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                FontData a = new FontData();
                a.Name = Global.GetName("Font", GameData.Fonts);
                a.ID = Global.GetID(GameData.Fonts);
                a.Category = ca.Category;
                GameData.Fonts.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.FontHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);
                SetupProperty(a);

                AddInitialNode();

                MainForm.textEditor.SetupFontList();

                Global.CBFonts();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "17x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Fonts.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.FontHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Fonts.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Fonts[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);
                    MainForm.textEditor.SetupFontList();
                    Global.CBFonts();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "17x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Fonts.ContainsKey(e.ID))
                    SetupProperty(GameData.Fonts[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "17x003");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        private void SetupProperty(FontData obj)
        {
            allowChange = false;
            if (obj != null)
            {
                // Change current font
                CurrentFont = obj;
                stylesAddRemoveList.Enabled = true;
                stylesAddRemoveList.Clear(false);
                // Populate listbox
                stylesAddRemoveList.SetupList(obj.Styles, typeof(FontStyleData));
            }
            else
            {
                CurrentFont = null;
                stylesAddRemoveList.Enabled = false;
                stylesAddRemoveList.Clear(false);
            }
            allowChange = true;
        }

        private void SetupStyleProperty(FontStyleData obj)
        {
            allowChange = false;
            if (obj != null)
            {
                CurrentStyle = obj;

                if (obj.MaterialID > -1)
                    txtFilename.Text = Global.GetData(obj.MaterialID, GameData.Materials).Name;
                else
                    txtFilename.Text = "Drag font from Materials.";

                nbLetterSpacing.Value = obj.LetterSpacing;
                nbLineSpacing.Value = obj.LineSpacing;

                panelSettings.Enabled = true;
            }
            else
            {
                CurrentStyle = null;
                txtFilename.Text = "Drag font from Materials.";

                panelSettings.Enabled = false;
            }
            allowChange = true;
        }

        private void AddInitialNode()
        {
            // Add initial style
            FontStyleData style = new FontStyleData();
            style.Name = "Regular";
            style.ID = 0;
            CurrentFont.Styles.Add(style);

            SetupProperty(CurrentFont);
        }

        private void fileNameTxt_DragDrop(object sender, DragEventArgs e)
        {
            if (addRemoveList.SelectedIndex >= 0 && GameData.Fonts.ContainsKey(addRemoveList.SelectedID) && stylesAddRemoveList.SelectedIndex >= 0)
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    MaterialData m = MainForm.materialExplorer.Data();

                    if (m != null)
                    {
                        txtFilename.Text = m.Name;
                        GameData.Fonts[addRemoveList.SelectedID].Styles[stylesAddRemoveList.SelectedIndex].MaterialID = m.ID;
                        SetupStyleProperty(GameData.Fonts[addRemoveList.SelectedID].Styles[stylesAddRemoveList.SelectedIndex]);
                    }
                }
            }
        }

        private void fileNameTxt_DragEnter(object sender, DragEventArgs e)
        {
            if (addRemoveList.SelectedIndex >= 0 && GameData.Fonts.ContainsKey(addRemoveList.SelectedID) && stylesAddRemoveList.SelectedIndex >= 0)
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
                            if (ext == ".bmpfont")
                                e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }

        #region IEditor Members

        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Fonts, typeof(FontData));
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

        private void stylesAddRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            FontStyleData a = new FontStyleData();
            a.Name = Global.GetName("Style", CurrentFont.Styles);
            a.ID = Global.GetID(CurrentFont.Styles);

            CurrentFont.Styles.Add(a);
            stylesAddRemoveList.AddNode(a);
            // History
            MainForm.FontHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataSAdded), new DataRemoveDelegate(DataSRemoved), addRemoveList.Data<FontData>().Styles, CurrentFont.Styles.IndexOf(a)));


            MainForm.textEditor.SetupFontList();
        }

        private void stylesAddRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (stylesAddRemoveList.SelectedIndex < 1)
                stylesAddRemoveList.removeBtn.Enabled = false;
            else
                stylesAddRemoveList.removeBtn.Enabled = true;

            SetupStyleProperty(CurrentFont.Styles[stylesAddRemoveList.SelectedIndex]);
        }

        private void stylesAddRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            // History
            MainForm.FontHistory[this].Do(new IGameDataRemovedHist(stylesAddRemoveList.Data(), new DataAddDelegate(DataSAdded), new DataRemoveDelegate(DataSRemoved), addRemoveList.Data<FontData>().Styles, CurrentFont.Styles.IndexOf(stylesAddRemoveList.Data<FontStyleData>())));

            CurrentFont.Styles.Remove(CurrentFont.Styles[stylesAddRemoveList.SelectedID]);
            stylesAddRemoveList.RemoveSelectedNode();
        }

        private void graphicsControl_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(graphicsControl.GraphicsDevice);
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

        }

        private void graphicsControl_OnDraw(object sender, EventArgs e)
        {
            graphicsControl.GraphicsDevice.Clear(Color.DarkGray);

            if (CurrentStyle != null && CurrentStyle.MaterialID > -1)
            {
                spriteBatch.Begin();

                SpriteFont font = Loader.SpriteFont(contentManager, CurrentStyle.MaterialID);

                if (font != null)
                {
                    font.Spacing = CurrentStyle.LetterSpacing;
                    font.LineSpacing = CurrentStyle.LineSpacing;

                    int i = 0;
                    StringBuilder charList = new StringBuilder();
                    Vector2 drawStringPosition = new Vector2(10, 10);
                    bool didntDraw = true;
                    foreach (Char c in font.Characters)
                    {
                        i++;
                        if (i == 26)
                        {
                            i = 0;
                            spriteBatch.DrawString(font, charList, drawStringPosition, Color.Black);
                            drawStringPosition.Y += font.MeasureString(charList).Y;
                            charList.Remove(0, charList.Length);
                            didntDraw = false;
                        }
                        charList.Append(c);

                    }

                    if (didntDraw)
                    {
                        spriteBatch.DrawString(font, charList, drawStringPosition, Color.Black);
                        drawStringPosition.Y += font.MeasureString(charList).Y;
                        charList.Remove(0, charList.Length);
                    }

                    if (font.Characters.Count > 94)
                    {
                        // spriteBatch.DrawString(font, "The quick brown fox jumped over the LAZY camel.", Vector2.Zero, Color.Black);
                    }
                    else
                    {
                        //System.Collections.ObjectModel.ReadOnlyCollection<char> chars = font.Characters;
                        // string _text = "";
                        //
                        // foreach (char c in chars)
                        //     _text += c.ToString();
                        // spriteBatch.DrawString(font, _text, Vector2.Zero, Color.Black);
                    }
                }
                spriteBatch.End();
            }
        }

        internal void ResetProject()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            addRemoveList.SetupList(GameData.Fonts, typeof(FontData));
        }

        private void nbLetterSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || CurrentStyle == null)
                return;
            CurrentStyle.LetterSpacing = (int)nbLetterSpacing.Value;
        }

        private void nbLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || CurrentStyle == null)
                return;
            CurrentStyle.LineSpacing = (int)nbLineSpacing.Value;
        }

        internal void Unload()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

        }
    }
}
