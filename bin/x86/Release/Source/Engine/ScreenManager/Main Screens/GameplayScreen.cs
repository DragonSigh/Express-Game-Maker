#region File Description
//-----------------------------------------------------------------------------
// GameplayScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Threading;
using System.Collections.Generic;
using EGMGame.Library;
using EGMGame.Components;
using EGMGame.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using FarseerPhysics.Dynamics;
using FarseerPhysics.DebugViews;
using FarseerPhysics;
#endregion

namespace EGMGame
{
    /// <summary>
    /// This screen implements the actual game logic.
    /// </summary>
    public class GameplayScreen : GameScreen
    {
        #region Fields
        public static bool IsCurrent = false;
        protected DebugViewXNA DebugView;
        #endregion

        #region Initialization
        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScreen()
        {
            IsCurrent = true;
            // Show HUD
            Global.ShowHUD();
            // Physics Initialize
            if (Global.World == null)
            {
                Global.World = new World(new Vector2(Global.Project.Gravity.X, Global.Project.Gravity.Y));
            }
        }

        /// <summary>
        /// Constructor. Loads a map as well.
        /// </summary>
        /// <param name="initialMapId"></param>
        public GameplayScreen(int initialMapId)
        {

#if DEBUG
            if (initialMapId < 0) Global.Log("No initial selected map!");
#endif
            IsCurrent = true;
            // Physics Initialize
            if (Global.World == null)
            {
                Global.World = new World(new Vector2(Global.Project.Gravity.X, Global.Project.Gravity.Y));
            }
            // Map Initialize
            Global.Instance.CurrentMap = new MapProcessor();
            Global.MapToLoad = initialMapId;
            // Show HUD
            Global.ShowHUD();
        }

        /// <summary>
        /// Constructor. Loads a map as well.
        /// </summary>
        /// <param name="initialMapId"></param>
        public GameplayScreen(MapProcessor map)
        {
            // Physics Initialize
            if (Global.World == null)
            {
                Global.World = new World(new Vector2(Global.Project.Gravity.X, Global.Project.Gravity.Y));
            }
            IsCurrent = true;
            // Map Initialize
            Global.Instance.CurrentMap = map;
            // Show HUD
            Global.ShowHUD();
        }
        /// <summary>
        /// Load map from given id.
        /// </summary>
        /// <param name="initialMapId"></param>
        private void LoadMap(int id)
        {
            if (Global.Project.MapsInfo.ContainsKey(id))
            {

#if DEBUG
                Global.Log("Loading Map...");
#endif
                Global.Instance.CurrentMap.Data = Marshal.LoadData<MapData>(Global.Project.MapsInfo[id].Name + ".egmmap");

#if DEBUG
                Global.Log("Map " + Global.Instance.CurrentMap.Data.Name + " Loaded.");
#endif
                Global.Instance.CurrentMap.Setup();

#if DEBUG
                Global.Log("Map setup done.");
#endif
            }
            else
            {
#if DEBUG
                Global.Log("Can't load map! Invailid ID.");
#endif
            }
        }

        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {
            // Load Initial Map From ID
            if (Global.MapToLoad > -1)
                LoadMap(Global.MapToLoad);
            Global.MapToLoad = -1;
            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
#if !SILVERLIGHT
            ScreenManager.Game.ResetElapsedTime();
#endif

            if (DebugView == null)
            {
                DebugView = new DebugViewXNA(Global.World);
                DebugView.RemoveFlags(DebugViewFlags.Shape);
                DebugView.RemoveFlags(DebugViewFlags.Joint);
                DebugView.DefaultShapeColor = Color.White;
                DebugView.SleepingShapeColor = Color.LightGray;
                DebugView.LoadContent(ScreenManager.GraphicsDevice, Global.ContentManager);
                DebugView.Enabled = true;

                // TODO
                //EnableOrDisableFlag(DebugViewFlags.Shape);
                //EnableOrDisableFlag(DebugViewFlags.DebugPanel);
                //EnableOrDisableFlag(DebugViewFlags.PerformanceGraph);
                //EnableOrDisableFlag(DebugViewFlags.Joint);
                //EnableOrDisableFlag(DebugViewFlags.Controllers);
                //EnableOrDisableFlag(DebugViewFlags.PolygonPoints);
                //EnableOrDisableFlag(DebugViewFlags.AABB);
            }
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void UnloadContent()
        {

        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            // This portion is only updated if the screen is active
            if (IsActive)
            {
                if (Global.TransferPlayer)
                {
                    bool load = false;
                    for (int i = 0; i < Global.Instance.Player.Count; i++)
                    {
                        if (Global.TransferMapID == -1) Global.TransferMapID = Global.Instance.Player[i].MapID;
                        if (Global.TransferMapID == -2)
                        {
                            Global.TransferMapID = GameData.Player.MapID;
                            Global.TransferX = (int)GameData.Player.Position.X;
                            Global.TransferY = (int)GameData.Player.Position.Y;
                        }
                        load = (Global.Instance.Player[i].MapID != Global.TransferMapID);
                        Global.Instance.Player[i].MapID = Global.TransferMapID;
                        Global.Instance.Player[i].waitFrames = 10;
                        if (Global.Instance.Player[i].Body != null) Global.TransferY -= (int)ConvertUnits.ToDisplayUnits(Global.Instance.Player[i].Body.Height * 2);
                        Global.Instance.Player[i].DisposeBodies();
                        Global.Instance.Player[i].Position = new Vector2(Global.TransferX, Global.TransferY);
                        Global.Instance.ActiveCamera.Position = new Vector2(Global.TransferX, Global.TransferY);
                        Global.Instance.Player[i].ResetAnimation();
                        Global.Instance.Player[i].SetupCollisionBody();
                        Global.Instance.Player[i].Update(gameTime);
                    }
                    if (load) LoadMap(Global.TransferMapID);
                    Global.TransferPlayer = false;
                }

                // Update the physics
                if (!coveredByOtherScreen && !otherScreenHasFocus)
                {
                    // Update the map
                    if (Global.Instance.CurrentMap != null)
                    {
                        // Update Global Process
                        bool dontUpdate = false;
                        for (int i = 0; i < Global.Instance.GlobalEvents.Count; i++)
                        {
                            Global.Instance.GlobalEvents[i].Update(gameTime);

                            if (Global.Instance.GlobalEvents[i].isProgramActive && Global.Instance.GlobalEvents[i].IsAutoRun)
                            {
                                dontUpdate = true;
                                break;
                            }
                        }
                        if (!dontUpdate) Global.Instance.CurrentMap.Update(gameTime);
                        if (!dontUpdate) Global.Instance.Weather.Update(gameTime);
                    }
                    // Update Physics                        
                    Global.World.Step(Math.Min((float)gameTime.ElapsedGameTime.TotalSeconds, (1f / 30f)));
                }
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



#if DEBUG
            // Show Collision Mapping
            if (InputState.IsNewKeyPress(Microsoft.Xna.Framework.Input.Keys.F2, 0))
            {
                EnableOrDisableFlag(DebugViewFlags.Shape);
                EnableOrDisableFlag(DebugViewFlags.DebugPanel);
                EnableOrDisableFlag(DebugViewFlags.PerformanceGraph);
                EnableOrDisableFlag(DebugViewFlags.Joint);
                EnableOrDisableFlag(DebugViewFlags.Controllers);
                Global.ShowCollisionMapping = !Global.ShowCollisionMapping;
            }
            else if (InputState.IsNewKeyPress(Microsoft.Xna.Framework.Input.Keys.F3, 0))
            {
                // Show Variable

            }
            else if (InputState.IsNewKeyPress(Microsoft.Xna.Framework.Input.Keys.F4, 0))
            {
                // Show Switches

            }
#endif
        }

        private void EnableOrDisableFlag(DebugViewFlags flag)
        {
            if ((DebugView.Flags & flag) == flag)
            {
                DebugView.RemoveFlags(flag);
            }
            else
            {
                DebugView.AppendFlags(flag);
            }
        }

        /// <summary>
        /// End Input Call Back
        /// </summary>
        /// <param name="result"></param>
        public static void EndInputCallback(IAsyncResult result)
        {
            string retval = Guide.EndShowKeyboardInput(result);

            if (retval == null)
            {
                // User cancelled input  

            }

            else
            {
                // Do whatever you want with the string you got from the user, which is now stored in retval

            }
        }
        public static int DefaultString;
        public static string DefaultText;
        /// <summary>
        /// End Message Call Back
        /// </summary>
        /// <param name="result"></param>
        public static void EndMessageCallback(IAsyncResult result)
        {
            int? retval = Guide.EndShowMessageBox(result);

            if (!retval.HasValue)
            {
                // User cancelled input  

            }
            else
            {
                // Do whatever you want with the string you got from the user, which is now stored in retval
            }
        }
        /// <summary>
        /// End Storage Call Back
        /// </summary>
        /// <param name="result"></param>
        public static void EndStorgeCallback(IAsyncResult result)
        {
            Global.Storage = StorageDevice.EndShowSelector(result);
        }
        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (ControllingPlayer.HasValue)
            {
                // Look up inputs for the active player profile.
                int playerIndex = (int)ControllingPlayer.Value;
                KeyboardState keyboardState = InputState.CurrentKeyboardStates[playerIndex];
                GamePadState gamePadState = InputState.CurrentGamePadStates[playerIndex];

                // The game pauses either if the user presses the pause button, or if
                // they unplug the active gamepad. This requires us to keep track of
                // whether a gamepad was ever plugged in, because we don't want to pause
                // on PC if they are playing with a keyboard and have no gamepad at all!
                bool gamePadDisconnected = !gamePadState.IsConnected &&
                                           InputState.GamePadWasConnected[playerIndex];
                if (gamePadDisconnected)
                {
                    //ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
                }
                else
                {

                }
            }
            else
            {

            }
        }
        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // This game has a black background.
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.Black, 0, 0);

            SpriteBatch spriteBatch = Global.SpriteBatch;
            // Draw Map
            if (Global.Instance.CurrentMap != null)
            {
                // Begin Draw 
                Global.BeginMapSpriteBatch();
                Global.Instance.CurrentMap.Draw(gameTime);
                // End Draw
                Global.SpriteBatch.End();
            }
            // Draw Weather
            Global.Instance.Weather.Draw(gameTime);

            Matrix projection = Matrix.CreateOrthographicOffCenter(0f, ConvertUnits.ToSimUnits(ScreenManager.GraphicsDevice.Viewport.Width),
                                                       ConvertUnits.ToSimUnits(ScreenManager.GraphicsDevice.Viewport.Height), 0f, 0f,
                                                       1f);
            Matrix view = Global.Instance.ActiveCamera.ViewTransformationMatrixSim();
            DebugView.RenderDebugData(ref projection, ref view);
        }
        #endregion
    }
}
