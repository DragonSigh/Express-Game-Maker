#region File Description
//-----------------------------------------------------------------------------
// MenuScreen.cs
//
// XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace EGMGame
{
    /// <summary>
    /// Base class for screens that contain a menu of options. The user can
    /// move up and down to select an entry, or cancel to back out of the screen.
    /// </summary>
    public class MenuScreen : GameScreen
    {
        #region Fields
        MenuProcessor processor;

        public static bool IsCurrent = false;

        public static bool DeactivateScene
        {
            get
            {
                for (int i = 0; i < Global.Menus.Count; i++)
                {
                    if (Global.Menus[i].DeactivateScene)
                        return true;
                }
                return false;
            }

        }

        public static bool ShowOnScene
        {
            get
            {
                for (int i = 0; i < Global.Menus.Count; i++)
                {
                    if (Global.Menus[i].ShowOnScene)
                        return true;
                }
                return (Global.Menus.Count == 0);
            }

        }
        #endregion

        #region Properties



        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public MenuScreen(MenuData menuData)
        {
            Global.CurrentMenu = processor = new MenuProcessor(menuData);
            processor.UniqueID = Global.Instance.MenuUniqueIDCount++;
            IsCurrent = true;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MenuScreen(int id)
        {
            Global.MenuToLoad = id;
            IsCurrent = true;

        }


        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {
            // Load Initial Map From ID
            if (Global.MenuToLoad > -1)
            {
                Global.CurrentMenu = processor = new MenuProcessor(GameData.Menus.GetData(Global.MenuToLoad));
                processor.UniqueID = Global.Instance.MenuUniqueIDCount++;
                Global.CurrentMenu.Show();
            }
            Global.MenuToLoad = -1;
            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
#if !SILVERLIGHT
            ScreenManager.Game.ResetElapsedTime();
#endif
        }
        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the menu.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            if (IsActive)
            {
                if (processor != null)
                {
                    processor.Update(gameTime);

                    if (processor.Erase)
                    {

                        if (processor.LastMenu != null)
                        {
                            processor = processor.LastMenu;
                        }
                        else if (Global.Instance.CurrentMap != null) // Go back to map
                        {
                            this.ScreenManager.RemoveScreen(this);
                            // Add Screen
                            if (ScreenManager.Screens.Count == 0)
                                ScreenManager.AddScreen(new GameplayScreen(Global.Instance.CurrentMap), InputState.Players[InputState.LastPlayer]);
                            IsCurrent = false;
                        }
                        else // Exit The Game
                        {
                            Global.Game.Exit();
                        }
                    }

                    if (Global.TransferPlayer)
                    {
                        for (int i = 0; i < Global.Instance.Player.Count; i++)
                        {
                            if (Global.TransferMapID == -1) Global.TransferMapID = Global.Instance.Player[i].MapID;
                            if (Global.TransferMapID == -2)
                            {
                                Global.TransferMapID = GameData.Player.MapID;
                                Global.TransferX = (int)GameData.Player.Position.X;
                                Global.TransferY = (int)GameData.Player.Position.Y;
                            }
                            Global.Instance.Player[i].MapID = Global.TransferMapID;
                            Global.Instance.Player[i].waitFrames = 10;
                            Global.Instance.Player[i].DisposeBodies();
                            Global.Instance.Player[i].ResetAnimation();
                            Global.Instance.Player[i].Position = new Vector2(Global.TransferX, Global.TransferY);
                            Global.Instance.ActiveCamera.Position = new Vector2(Global.TransferX, Global.TransferY);
                            Global.Instance.Player[i].SetupCollisionBody();
                        }
                        Global.TransferPlayer = false;
                        IsCurrent = false;
                        this.ScreenManager.RemoveScreen(this);
                        // Add Screen
                        if (ScreenManager.Screens.Count == 0)
                            ScreenManager.AddScreen(new GameplayScreen(Global.TransferMapID), InputState.Players[InputState.LastPlayer]);
                    }

                    // Load Map
                    if (Global.MapToLoad > -1)
                    {
                        Global.MapToLoad = -1;
                        IsCurrent = false;
                        this.ScreenManager.RemoveScreen(this);
                        // Add Screen
                        if (ScreenManager.Screens.Count == 0)
                            ScreenManager.AddScreen(new GameplayScreen(), InputState.Players[InputState.LastPlayer]);
                        Global.Instance.CurrentMap.Update(gameTime);
                    }

                    // Check if going to new menu
                    if (Global.MenuToLoad > -1)
                    {
                        this.ScreenManager.RemoveScreen(this);
                        // Add Screen
                        if (ScreenManager.Screens.Count == 0)
                            ScreenManager.AddScreen(new MenuScreen(Global.MenuToLoad), InputState.Players[InputState.LastPlayer]);
                        IsCurrent = false;
                        Global.MenuToLoad = -1;
                        // Close Messages                
                        int count = Global.Messages.Count;
                        for (int index = 0; index < count; index++)
                            Global.Messages[index].Close();
                        Global.Messages.Clear();
                        // Close Menus
                        count = Global.Menus.Count;
                        for (int index = count - 1; index > -1; index--)
                            Global.Menus[index].Close();
                        Global.Menus.Clear();
                    }
                }
            }

        }


        /// <summary>
        /// Draws the menu.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            Global.SpriteBatch.Begin();

            if (processor != null)
                processor.Draw(gameTime);

            Global.SpriteBatch.End();
        }


        #endregion
    }
}
