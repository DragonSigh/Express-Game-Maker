//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using EGMGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EGMGame.Extensions;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;

namespace EGMGame.Processors
{

    public class MenuProcessor : IMenu
    {
        public MenuData Data
        {
            get { return data; }
            set { data = value; }
        }
        MenuData data;

        #region Field: Menu Parts, SelectedPart, LastMenu, Position
        /// <summary>
        /// Selected menupart
        /// </summary>
        IMenuParts selected;
        /// <summary>
        /// MenuPart processors
        /// </summary>
        public List<MenuPartProcessor> menuParts = new List<MenuPartProcessor>();
        /// <summary>
        /// Stores the selected menu part
        /// </summary>
        public MenuPartProcessor SelectedPart;
        /// <summary>
        /// Last Menu
        /// </summary>
        public MenuProcessor LastMenu;
        /// <summary>
        /// Position of the menu
        /// </summary>
        public Vector2 Position = Vector2.Zero;
        // Enable/Disable Lists
        public List<MenuPartProcessor> EnableList = new List<MenuPartProcessor>();
        public List<MenuPartProcessor> DisableList = new List<MenuPartProcessor>();
        // Dock Event
        EventProcessor dockEvent;
        /// <summary>
        /// Adjusts position depending on map coordinates
        /// </summary>
        public bool IsMapCoordinates;
        #endregion

        #region Constructor and Setup
        public MenuProcessor() { }
        /// <summary>
        /// Create a menu from the given menu id
        /// </summary>
        /// <param name="id"></param>
        public MenuProcessor(int id)
        {
            data = GameData.Menus.GetData(id);
            if (data == null)
                Close();
            else
                Setup(data.MenuParts);
            ID = id;
        }
        /// <summary>
        /// Create a menu from the given menu data
        /// </summary>
        /// <param name="menuData"></param>
        public MenuProcessor(MenuData menuData)
        {
            data = menuData;
            Setup(data.MenuParts);
            ID = data.ID;
        }
        /// <summary>
        /// Setup the menu
        /// </summary>
        private void Setup(List<IMenuParts> parts)
        {
            for (int index = 0; index < parts.Count; index++)
            {
                menuParts.Add(new MenuPartProcessor(parts[index], null, this));
            }
        }
        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            NeedShow = false;
            // Shown Event
            if (data != null && data.OnShown.Count > 0)
                ActivateEvent(data.OnShown);
        }
        /// <summary>
        /// Activate Event
        /// </summary>
        /// <param name="list"></param>
        public void ActivateEvent(List<EventProgramData> list)
        {
            // Save Branch if empty
            labels.Clear();
            LastBranch.Clear();
            EventProgramData parent = new EventProgramData();
            parent.Programs = list;
            CurrentBranch = parent;
            // Start processing program
            isProgramActive = true;
            // Process Program
            ProcessPrograms();
        }
        #endregion

        #region Method: Process Program
        /// <summary>
        /// Process Program
        /// </summary>
        private void ProcessPrograms()
        {
            if (CurrentBranch != null)
            {
                if (!(actionTakingPlace != ActionType.None && waitActionCompelition) && waitFrames <= 0)
                {
                    if (programIndex > -1 && programIndex < CurrentBranch.Programs.Count)
                    {
                        if (CurrentBranch.Enabled)
                        {
                            switch (CurrentBranch.Programs[programIndex].ProgramCategory)
                            {
                                case ProgramCategory.Display: // Display
                                    break;
                                case ProgramCategory.Conditions: // Conditions
                                    ProcessCategoryConditions(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Loops: // Loops
                                    ProcessCategoryLoop(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Audio: // Audio
                                    ProcessCategoryAudio(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Data: // Data
                                    ProcessCategoryData(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Map: // Map
                                    ProcessCategoryMap(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Screen: // Screen
                                    ProcessCategoryScreen(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Guide: // Memory
                                    ProcessCategoryGuide(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Other: // Other
                                    ProcessCategoryOther(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Party: // Party
                                    ProcessCategoryParty(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Hero: // Hero
                                    ProcessCategoryHero(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                                case ProgramCategory.Menu: // Menu
                                    ProcessCategoryMenu(CurrentBranch.Programs[programIndex], ref programIndex);
                                    break;
                            }
                        }
                        else
                        {
                            programIndex++;
                        }
                    }
                    else if (programIndex >= CurrentBranch.Programs.Count)
                    {
                        // If this is the top most branch, end
                        if (LastBranch.Count == 0)
                        {
                            isProgramActive = false;
                            programIndex = 0;
                            labels.Clear();
                            return;
                        }
                        // Check if its a loop
                        if (CurrentBranch.ProgramCategory == ProgramCategory.Loops)
                        {
                            // Loop Do
                            if (CurrentBranch.Code == 1)
                            {
                                programIndex = 0;
                                return;
                            }
                        }
                        // Go to last branch
                        CurrentBranch = LastBranch.Last();
                        programIndex = LastProgramIndex.Last();
                        LastBranch.Remove(LastBranch.Last());
                        LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
                        NextProgram();
                    }
                }
            }
        }
        /// <summary>
        /// Continues to the next program
        /// Called when the program data is simple and doesn't require more frames
        /// </summary>
        public override void NextProgram()
        {
            // Process Page Commands if active
            if (isProgramActive)
            {
                ProcessPrograms();
            }
        }
        /// <summary>
        /// Setup branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupBranch(EventProgramData eventProgramData)
        {
            LastBranch.Add(CurrentBranch);
            LastProgramIndex.Add(++programIndex);
            CurrentBranch = eventProgramData;
            programIndex = -1;
        }
        /// <summary>
        /// Else Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupElseBranch(EventProgramData eventProgramData)
        {
            LastBranch.Add(CurrentBranch);
            LastProgramIndex.Add(++programIndex);
            EventProgramData programData = new EventProgramData();
            programData.Programs = eventProgramData.ElsePrograms;
            CurrentBranch = programData;
            programIndex = -1;
        }
        /// <summary>
        /// Break Current Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void BreakBranch(ref int index, bool ignoreTop)
        {
            // If this is the top most branch
            if (LastBranch.Count == 0)
            {
                if (ignoreTop)
                {
                    index++; NextProgram();
                }
                else
                {
                    isProgramActive = false;
                    programIndex = 0;
                    labels.Clear();
                }
                return;
            }
            // Go to last branch
            CurrentBranch = LastBranch.Last();
            index = LastProgramIndex.Last();
            LastBranch.Remove(LastBranch.Last());
            LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
            index++; NextProgram();
        }
        /// <summary>
        /// Break Current Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void BreakBranch(ref int index)
        {
            // If this is the top most branch
            if (LastBranch.Count == 0)
            {
                return;
            }
            // Go to last branch
            CurrentBranch = LastBranch.Last();
            index = LastProgramIndex.Last();
            LastBranch.Remove(LastBranch.Last());
            LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
        }
        #endregion

        #region Method: Process Categories
        /// <summary>
        /// Process Category Menu
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        private void ProcessCategoryMenu(EventProgramData eventProgramData, ref int programIndex)
        {
            MenuPartProcessor part = null;
            switch (eventProgramData.Code)
            {
                case 0: // Close Menu
                    Close();
                    programIndex++;
                    break;
                case 1: // Toggle Enable
                    if ((int)eventProgramData.Value[0] > -1)
                        ToggleEnable((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    programIndex++; NextProgram();
                    break;
                case 2: // Toggle Visible
                    if ((int)eventProgramData.Value[0] > -1)
                        ToggleVisible((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    programIndex++; NextProgram();
                    break;
                case 3: // Select
                    if ((int)eventProgramData.Value[0] > -1)
                        Select((int)eventProgramData.Value[0]);
                    programIndex++; NextProgram();
                    break;
                case 4: // Conditions
                    bool result = false;
                    if ((int)eventProgramData.Value[0] > -1)
                        part = GetMenuPart((int)eventProgramData.Value[0]);

                    if (part != null)
                    {
                        switch ((int)eventProgramData.Value[2])
                        {
                            case 0: // Enabled
                                result = (part.Enabled);
                                break;
                            case 1: // Visible
                                result = (part.Visible);
                                break;
                            case 2: // Selected
                                result = (SelectedPart == part);
                                break;
                        }
                    }

                    if ((int)eventProgramData.Value[1] == 1)
                        result = !result;
                    if (result)
                        SetupBranch(eventProgramData);
                    else if (eventProgramData.Else)
                        SetupElseBranch(eventProgramData);
                    programIndex++; NextProgram();
                    break;
                case 5: // Move Menu To

                    part = GetMenuPart((int)eventProgramData.Value[0]);

                    if (part != null)
                        part.MoveTo((int)GetValue((int)eventProgramData.Value[1], (int)eventProgramData.Value[2]), (int)GetValue((int)eventProgramData.Value[1], (int)eventProgramData.Value[3]), (int)eventProgramData.Value[4]);
                    break;
            }
        }
        /// <summary>
        /// Action Complete
        /// Called when an action is complete.
        /// </summary>
        /// <param name="type"></param>
        public void ActionComplete(ActionType type)
        {
            if (type == actionTakingPlace)
            {
                switch (actionTakingPlace)
                {
                    case ActionType.Tint:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Flash:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Shake:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Video:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.PictureTint:
                        actionTakingPlace = ActionType.None;
                        break;
                }
            }
        }

        #region Helper: Get Event, Variable Value
        /// <summary>
        /// Get Event
        /// </summary>
        /// <param name="p"></param>
        public override EventProcessor GetEvent(int id)
        {
            return Global.Instance.Player[0];
        }
        /// <summary>
        /// Gets a value from either constant, variable, or local variable.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override float GetValue(int type, int id)
        {
            switch (type)
            {
                case 0:
                    return id;
                case 1:
                    return Global.Variable(id);
            }
            return 0;
        }
        /// <summary>
        /// Gets a value from either constant, variable, or local variable.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override float GetValue(int type, float id)
        {
            switch (type)
            {
                case 0:
                    return id;
                case 1:
                    return Global.Variable((int)id);
            }
            return 0;
        }
        #endregion
        #endregion

        #region Update: Update Menu Processing and Menuparts
        /// <summary>
        /// Update the event
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Update only if  data exists
            if (data != null && !NeedShow)
            {
                // Return if there is an action taking place and must be completed
                if (!(actionTakingPlace != ActionType.None && waitActionCompelition))
                {
                    // Reset wait
                    waitActionCompelition = false;

                    // If Program is active
                    if (isProgramActive)
                    {
                        ProcessPrograms();
                    }
                }
                // Check mouse hover
                Vector2 mousePosition = new Vector2();
                mousePosition.X = Mouse.GetState().X; mousePosition.Y = Mouse.GetState().Y;
                mousePosition = Global.Instance.ActiveCamera.GetTransformedPoint(mousePosition);
                CheckMouseHover(menuParts, ref mousePosition);
                // Update Menuparts
                UpdateMenuParts(gameTime);

                waitFrames--;
                if (waitFrames > 0)
                    return;
            }
        }
        /// <summary>
        /// Check mouse hover
        /// </summary>
        private bool CheckMouseHover(List<MenuPartProcessor> parts, ref Vector2 mousePosition)
        {
#if !XBOX
            for (int index = parts.Count - 1; index > -1; index--)
            {
                if (parts[index].Enabled && parts[index].Visible)
                {
                    // Check chidren
                    if (!CheckMouseHover(parts[index].MenuParts, ref mousePosition))
                    {
                        // Check if mouse is hovering
                        if (parts[index].Data.Bounds.Contains((int)mousePosition.X, (int)mousePosition.Y))
                        {
                            selected = parts[index].Data;
                            // Check if its button
                            if (parts[index].Data is MenuButton)
                            {
                                // Activate event
                                if (((MenuButton)parts[index].Data).OnSelected.Count > 0)
                                {
                                    parts[index].ActivateEvent(((MenuButton)parts[index].Data).OnSelected);
                                }
                            }
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
#endif
            return false;
        }
        /// <summary>
        /// Update menu parts
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateMenuParts(GameTime gameTime)
        {
            for (int index = 0; index < menuParts.Count; index++)
            {
                // Update Self
                if (!this.Erase)
                    menuParts[index].Update(gameTime);
            }
            for (int index = 0; index < EnableList.Count; index++)
            {
                EnableList[index].Enabled = true;
            }
            EnableList.Clear();

            for (int index = 0; index < DisableList.Count; index++)
            {
                DisableList[index].Enabled = false;
            }
            DisableList.Clear();
        }
        #endregion

        #region Method: Close, Toggle Visiblity, Select, Get Menupart
        public override void Close()
        {
            this.Erase = true;
            // If there is an owner event, let it know this menu is closing
            if (Owner != null)
            {
                if (Owner is EventProcessor)
                    ((EventProcessor)Owner).MenuClosed();
                else if (Owner is MenuPartProcessor)
                    ((MenuPartProcessor)Owner).MenuClosed();
                else if (Owner is GlobalEventProcessor)
                    ((GlobalEventProcessor)Owner).MenuClosed();
            }
        }

        public void ToggleEnable(int id, int toggle)
        {
            MenuPartProcessor part = GetMenuPart(id);
            if (toggle == 0) // Enable
                part.Enable();
            else if (toggle == 1)// Disable
                part.Disable();
        }

        public void ToggleVisible(int id, int toggle)
        {
            MenuPartProcessor part = GetMenuPart(id);
            if (toggle == 0) // Show
                part.Show();
            else if (toggle == 1)// Hide
                part.Hide();
        }

        public void Select(int id)
        {
            MenuPartProcessor part = GetMenuPart(id);
            SelectedPart = part;
        }

        public void Select(MenuPartProcessor part)
        {
            SelectedPart = part;
        }

        public MenuPartProcessor GetMenuPart(int id)
        {
            MenuPartProcessor found;
            foreach (MenuPartProcessor part in menuParts)
            {
                if (part.ID == id)
                    return part;
                found = GetChildMenuPart(part, id);
                if (found != null)
                    return found;
            }
            return null;
        }

        private MenuPartProcessor GetChildMenuPart(MenuPartProcessor parent, int id)
        {
            MenuPartProcessor found;
            foreach (MenuPartProcessor part in parent.MenuParts)
            {
                if (part.ID == id)
                    return part;
                found = GetChildMenuPart(part, id);
                if (found != null)
                    return found;
            }
            return null;
        }
        #endregion

        #region Method: Dock, SetupText
        /// <summary>
        /// Dock Menu
        /// </summary>
        /// <param name="id"></param>
        private void Dock(int index)
        {
            if (data == null) return;
            float screenW = Global.Project.ScreenRatio.X;
            float screenH = Global.Project.ScreenRatio.Y;
            Vector2 newPos = Vector2.Zero;
            switch (index)
            {
                case 0: // Top
                    newPos.X = (screenW / 2) - (data.CanvasSize.X / 2);
                    break;
                case 1: // Bottom
                    newPos.X = (screenW / 2) - (data.CanvasSize.X / 2);
                    newPos.Y = screenH - data.CanvasSize.Y;
                    break;
                case 2: // Left
                    newPos.X = screenW - data.CanvasSize.X;
                    newPos.Y = (screenH / 2) - (data.CanvasSize.Y / 2);
                    break;
                case 3: // Right
                    newPos.Y = (screenH / 2) - (data.CanvasSize.Y / 2);
                    break;
                case 4: // Middle
                    newPos.X = (screenW / 2) - (data.CanvasSize.X / 2);
                    newPos.Y = (screenH / 2) - (data.CanvasSize.Y / 2);
                    break;
            }
            Position = newPos;
        }
        /// <summary>
        /// Setup Text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sizeType"></param>
        /// <param name="size"></param>
        /// <param name="positionType"></param>
        /// <param name="id"></param>
        /// <param name="pos"></param>
        public override void SetupText(string text, int sizeType, Vector2 size, int positionType, int id, Vector2 pos, Drawable dd)
        {
            List<MenuPartProcessor> list = new List<MenuPartProcessor>();
            // Get Label
            for (int index = 0; index < menuParts.Count; index++)
            {
                list.AddRange(LoopChildPartsForMessage(menuParts[index]));

                // Check if message
                if (menuParts[index].Data is TextPartStatic && ((TextPartStatic)menuParts[index].Data).IsMessage)
                    list.Add(menuParts[index]);
            }
            // Edit text
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Text = text;

                // Edit size of window if necessary
                switch (sizeType)
                {
                    case 1: // Custom
                        if (list[i].Parent.Data is MenuWindow)
                            list[i].Size = size;
                        break;
                    case 2: // AutoFit
                        list[i].IsParentAutoFit = true;
                        FontData font; TextPartStatic menuPart = (TextPartStatic)list[i].Data;
                        if (menuPart.Style > -1 && GameData.Fonts.TryGetValue(menuPart.Font, out font) && menuPart.Style < font.Styles.Count)
                            list[i].Parent.Size = (list[i].Position * 2) + GraphicsHelper.GetTextSize(font, font.Styles[menuPart.Style], text);
                        break;
                }
            }
            // Menu Position
            switch (positionType)
            {
                case 0: // Dock
                    Dock(id);
                    Position += pos;
                    break;
                case 1: // Screen
                    Position = pos;
                    break;
                case 2: // Event
                    if (id == -1)
                        dockEvent = Global.Instance.Player[0];
                    else if (id == -2)
                        dockEvent = (dd is EventProcessor ? (EventProcessor)dd : null);
                    else
                        dockEvent = Global.Instance.CurrentMap.GetEvent(id);

                    Position = pos;
                    break;
            }
            // Owner Event
            Owner = dd;
        }
        /// <summary>
        /// Setup Text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sizeType"></param>
        /// <param name="size"></param>
        /// <param name="positionType"></param>
        /// <param name="id"></param>
        /// <param name="pos"></param>
        public override void SetupText(string text, int sizeType, Vector2 size, int positionType, int id, Vector2 pos)
        {
            List<MenuPartProcessor> list = new List<MenuPartProcessor>();
            // Get Label
            for (int index = 0; index < menuParts.Count; index++)
            {
                list.AddRange(LoopChildPartsForMessage(menuParts[index]));

                // Check if message
                if (menuParts[index].Data is TextPartStatic && ((TextPartStatic)menuParts[index].Data).IsMessage)
                    list.Add(menuParts[index]);
            }
            // Edit text
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Text = text;

                // Edit size of window if necessary
                switch (sizeType)
                {
                    case 1: // Custom
                        if (list[i].Parent.Data is MenuWindow)
                            list[i].Parent.Size = size;
                        break;
                    case 2: // AutoFit
                        list[i].IsParentAutoFit = true;
                        FontData font; TextPartStatic menuPart = (TextPartStatic)list[i].Data;
                        if (menuPart.Style > -1 && GameData.Fonts.TryGetValue(menuPart.Font, out font) && menuPart.Style < font.Styles.Count)
                            list[i].Parent.Size = list[i].Position + GraphicsHelper.GetTextSize(font, font.Styles[menuPart.Style], text);
                        break;
                }
            }
            // Menu Position
            switch (positionType)
            {
                case 0: // Dock
                    Dock(id);
                    Position += pos;
                    break;
                case 1: // Screen
                    Position = pos;
                    break;
                case 2: // Event
                    if (id == -1)
                        dockEvent = Global.Instance.Player[0];
                    else
                        dockEvent = Global.Instance.CurrentMap.GetEvent(id);

                    Position = pos;
                    break;
            }
        }
        /// <summary>
        /// Loop child pars
        /// </summary>
        /// <param name="parentr"></param>
        private List<MenuPartProcessor> LoopChildPartsForMessage(MenuPartProcessor parent)
        {
            List<MenuPartProcessor> list = new List<MenuPartProcessor>();

            for (int index = 0; index < parent.MenuParts.Count; index++)
            {
                LoopChildPartsForMessage(parent.MenuParts[index]);
                // Check if message
                if (parent.MenuParts[index].Data is TextPartStatic && ((TextPartStatic)parent.MenuParts[index].Data).IsMessage)
                    list.Add(parent.MenuParts[index]);
            }

            return list;
        }
        /// <summary>
        /// Menu Closed
        /// </summary>
        public void MenuClosed()
        {
            if (actionTakingPlace == ActionType.Message || actionTakingPlace == ActionType.Menu)
            {
                actionTakingPlace = ActionType.None;
                waitActionCompelition = false;
            }
        }
        /// <summary>
        /// Add to enable list
        /// </summary>
        /// <param name="part"></param>
        public void AddToEnable(MenuPartProcessor part)
        {
            EnableList.Add(part);
        }
        /// <summary>
        /// Add to disable list
        /// </summary>
        /// <param name="part"></param>
        public void AddToDisable(MenuPartProcessor part)
        {
            DisableList.Add(part);
        }
        #endregion

        #region Draw: Draw Menu and Menuparts
        /// <summary>
        /// Draw Event
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            // Draw only if  data exists and page exists
            if (data != null && !NeedShow)
            {
                // Draw Menu
                GraphicsHelper.FillRectangle(GraphicsHelper.Texture, Position, data.CanvasSize, data.BackgroundColor);
                // Draw Background
                GraphicsHelper.LastTexture = GetTexture(data.Background);
                if (GraphicsHelper.LastTexture != null)
                    Global.SpriteBatch.Draw(GraphicsHelper.LastTexture, new Rectangle(0, 0, (int)data.CanvasSize.X, (int)data.CanvasSize.Y), Color.White);
                // Draw Menuparts
                for (int index = 0; index < menuParts.Count; index++)
                {
                    if (menuParts[index].Visible)
                    {
                        // Update Self
                        menuParts[index].Draw(gameTime, selected, (dockEvent != null ? Global.Instance.ActiveCamera.ToScreenVector(dockEvent.Position) + Position : Position));
                    }
                }
            }

            // Draw Pictures
            for (int i = 0; i < Global.Instance.Pictures.Length; i++)
            {
                if (Global.Instance.Pictures[i] != null)
                {
                    if (Global.Instance.Pictures[i].ScreenType == ScreenType.Global ||
                       (Global.Instance.Pictures[i].ScreenType == ScreenType.Menu))
                    {
                        Global.Instance.Pictures[i].Draw(gameTime);
                    }
                }
            }
        }
        /// <summary>
        /// Returns the material's texture
        /// </summary>
        /// <param name="animationSprite"></param>
        /// <returns></returns>
        private Texture2D GetTexture(int materialId)
        {
            return Content.Texture2D(materialId);
        }
        #endregion

        public override void Load()
        {
            for (int i = 0; i < menuParts.Count; i++)
            {
                menuParts[i].ParentMenu = this;
                menuParts[i].Load();
            }
        }
    }
}