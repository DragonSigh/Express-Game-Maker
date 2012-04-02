#region File Description
//-----------------------------------------------------------------------------
// ScreenManager.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Diagnostics;
using System.Collections.Generic;
using EGMGame.Components;
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using EGMGame.Extensions;
#endregion

namespace EGMGame
{
    /// <summary>
    /// The screen manager is a component which manages one or more GameScreen
    /// instances. It maintains a stack of screens, calls their Update and Draw
    /// methods at the appropriate times, and automatically routes input to the
    /// topmost active screen.
    /// </summary>
    public class ScreenManager : DrawableGameComponent
    {
        #region Fields
        // Will contain the game screens.
        public List<GameScreen> Screens = new List<GameScreen>();
        List<GameScreen> screensToUpdate = new List<GameScreen>();
        // The input system.
        InputState input = new InputState();

        bool isInitialized;

        bool traceEnabled;

        public static GameTime GameTime = new GameTime();
        #endregion

        #region Properties
        /// <summary>
        /// If true, the manager prints out a list of all the screens
        /// each time it is updated. This can be useful for making sure
        /// everything is being added and removed at the right times.
        /// </summary>
        public bool TraceEnabled
        {
            get { return traceEnabled; }
            set { traceEnabled = value; }
        }


        #endregion

        #region Initialization


        /// <summary>
        /// Constructs a new screen manager component.
        /// </summary>
        public ScreenManager(Game game)
            : base(game)
        {
        }


        /// <summary>
        /// Initializes the screen manager component.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            isInitialized = true;
#if XBOX
            StorageDevice.DeviceChanged += new EventHandler<EventArgs>(StorageDevice_DeviceChanged);
#endif
        }
#if XBOX
        /// <summary>
        /// Storage Device Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StorageDevice_DeviceChanged(object sender, EventArgs e)
        {
            Global.Storage = null;
        }
#endif
        /// <summary>
        /// Load your graphics content.
        /// </summary>
        protected override void LoadContent()
        {
            // Load content belonging to the screen manager.
            ContentManager content = Game.Content;
            // Load Game Objects
            LoadGameData();
            // Setup Camera
            Global.Instance.ActiveCamera = new Camera(GraphicsDevice.Viewport);
            // Create Spritebatch
            Global.SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Tell each of the screens to load their content.
            foreach (GameScreen screen in Screens)
            {
                screen.LoadContent();
            }
        }

        /// <summary>
        /// Loads the game data that is created through EGM.
        /// </summary>
        private void LoadGameData()
        {
            Global.Instance.Timers = new Dictionary<int, Timer>();
#if DEBUG
            Global.Log("Loading Game Data...");
#endif
            // Loading Animations
            GameData.Animations = Marshal.LoadData<Dictionary<int, AnimationData>>("Animations.egm");
            // Loading Lists
            GameData.Lists = Marshal.LoadData<Dictionary<int, ListData>>("Lists.egm");
            // Loading Audios
            GameData.Audios = Marshal.LoadData<Dictionary<int, AudioData>>("Audios.egm");
            // Loading Databases
            GameData.Databases = Marshal.LoadData<Dictionary<int, Data>>("Databases.egm");
            // Loading Fonts
            GameData.Fonts = Marshal.LoadData<Dictionary<int, FontData>>("Fonts.egm");
            // Loading Global Events
            GameData.GlobalEvents = Marshal.LoadData<Dictionary<int, GlobalEventData>>("GEvents.egm");
            // Loading Template Events
            GameData.Events = Marshal.LoadData<Dictionary<int, EventData>>("Events.egm");
            // Loading Items
            GameData.Items = Marshal.LoadData<Dictionary<int, ItemData>>("Items.egm");
            // Loading Materials
            GameData.Materials = Marshal.LoadData<Dictionary<int, MaterialData>>("Materials.egm");
            // Loading Menus
            GameData.Menus = Marshal.LoadData<Dictionary<int, MenuData>>("Menus.egm");
            // Loading Switches
            GameData.Switches = Marshal.LoadData<Dictionary<int, SwitchData>>("Switches.egm");
            // Loading Tilesets
            GameData.Tilesets = Marshal.LoadData<Dictionary<int, TilesetData>>("Tilesets.egm");
            // Loading Variable
            GameData.Variables = Marshal.LoadData<Dictionary<int, VariableData>>("Variables.egm");
            // Loading Strings
            GameData.Strings = Marshal.LoadData<Dictionary<int, StringData>>("Strings.egm");
            // Loading Heroes
            GameData.Heroes = Marshal.LoadData<Dictionary<int, HeroData>>("Heroes.egm");
            // Loading Enemies
            GameData.Enemies = Marshal.LoadData<Dictionary<int, EnemyData>>("Enemies.egm");
            // Loading Equipments
            GameData.Equipments = Marshal.LoadData<Dictionary<int, EquipmentData>>("Equipments.egm");
            // Loading Skills
            GameData.Skills = Marshal.LoadData<Dictionary<int, SkillData>>("Skills.egm");
            // Loading States
            GameData.States = Marshal.LoadData<Dictionary<int, StateData>>("States.egm");
            // Loading Projectiles
            GameData.Projectiles = Marshal.LoadData<Dictionary<int, ProjectileGroupData>>("Projectiles.egm");
            // Loading Combos
            GameData.Combos = Marshal.LoadData<Dictionary<int, ComboData>>("Combos.egm");
            // Loading Particles
            GameData.ParticleSystems = Marshal.LoadData<Dictionary<int, ParticleSystemData>>("ParticleSystems.egm");
            // Loading Skins
            GameData.Skins = Marshal.LoadData<Dictionary<int, SkinData>>("Skins.egm");
            // Set Data
            Global.Instance.Lists = new Dictionary<int, ListData>();
            Global.Instance.Switches = new Dictionary<int, SwitchData>();
            Global.Instance.Variables = new Dictionary<int, VariableData>();
            Global.Instance.Strings = new Dictionary<int, StringData>();
            foreach (KeyValuePair<int, ListData> pair in GameData.Lists)
                Global.Instance.Lists[pair.Key] = new ListData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, Values = new List<int>(pair.Value.Values) };
            foreach (KeyValuePair<int, SwitchData> pair in GameData.Switches)
                Global.Instance.Switches[pair.Key] = new SwitchData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, State = pair.Value.State };
            foreach (KeyValuePair<int, VariableData> pair in GameData.Variables)
                Global.Instance.Variables[pair.Key] = new VariableData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, Value = pair.Value.Value };
            foreach (KeyValuePair<int, StringData> pair in GameData.Strings)
                Global.Instance.Strings[pair.Key] = new StringData() { Name = pair.Value.Name, ID = pair.Value.ID, Category = pair.Value.Category, Value = pair.Value.Value };
            // Load Particles Effect
            Global.ParticlesEffect = Content.Effect(GameData.Materials.GetData("ParticleEffect"));
            Global.ParticlesEffectPool = new EffectPool(100);
            // Loading Player
            GameData.Player = Marshal.LoadData<PlayerData>("Player.egm");
            Global.Instance.SkillKeys = GameData.Player.SkillKeys;
            Global.Instance.ItemKeys = GameData.Player.ItemKeys;
            // Create Party
            Global.Instance.Player = new List<EventProcessor>();
            foreach (int heroID in GameData.Player.PartyList)
                Global.Instance.Party.AddHero(heroID, false);
            // Global Events
            foreach (GlobalEventData gevent in GameData.GlobalEvents.Values)
                Global.Instance.GlobalEvents.Add(new GlobalEventProcessor(gevent));

            // Activate the first screen.
            // 0 - Menu
            // 1 - Map
            if (Global.Project.InitialSceneType == 0)
                AddScreen(new MenuScreen(Global.Project.InitialSceneID), null);
            else
            {
                if (Global.Project.InitialSceneID > -1)
                    AddScreen(new GameplayScreen(Global.Project.InitialSceneID), null);
                else if (GameData.Player.MapID > -1)
                    AddScreen(new GameplayScreen(GameData.Player.MapID), null);
                else
                    AddScreen(new GameplayScreen(0), null);
            }

#if DEBUG
            Global.Log("Game Data Loaded!");
#endif
        }


        /// <summary>
        /// Unload your graphics content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Tell each of the screens to unload their content.
            foreach (GameScreen screen in Screens)
            {
                screen.UnloadContent();
            }
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Allows each screen to run logic.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
#if XBOX
            // Do not update if guide is visible, pause the game.
            if (!Guide.IsVisible)
            {
#endif
            if (Global.IsSavingOrLoading == -1)
            {
                // Read the keyboard and gamepad.
                InputState.Update();
                // Update Cursor
                Global.Instance.CursorMaterial = Global.Project.CursorMaterial;
                // Make a copy of the master screen list, to avoid confusion if
                // the process of updating one screen adds or removes others.
                screensToUpdate.Clear();
                // Update Camera
                if (Global.Instance.ActiveCamera != null) Global.Instance.ActiveCamera.Update(gameTime);
                // Update Audio
                Global.Instance.AudioManager.Update(gameTime);
                // Check Pause 
                CheckPause();
                // Update screens if the game is not paused
                if (Global.Instance.Pause == PauseAction.None)
                {

                    if (!MenuScreen.DeactivateScene)
                    {
                        foreach (GameScreen screen in Screens)
                            screensToUpdate.Add(screen);
                    }

                    bool otherScreenHasFocus = !Game.IsActive;
                    bool coveredByOtherScreen = false;

                    // Loop as long as there are screens waiting to be updated.
                    while (screensToUpdate.Count > 0)
                    {
                        // Pop the topmost screen off the waiting list.
                        GameScreen screen = screensToUpdate[screensToUpdate.Count - 1];

                        screensToUpdate.RemoveAt(screensToUpdate.Count - 1);

                        // Update the screen.
                        screen.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

                        if (Global.Instance.ScreenState == ScreenState.TransitionOn ||
                            GameplayScreen.IsCurrent)
                        {
                            // If this is the first active screen we came across,
                            // give it a chance to handle input.
                            if (!otherScreenHasFocus)
                            {
                                screen.HandleInput(input);

                                otherScreenHasFocus = true;
                            }

                            // If this is an active non-popup, inform any subsequent
                            // screens that they are covered by it.
                            if (!screen.IsPopup)
                                coveredByOtherScreen = true;
                        }
                    }
                    // Update Screen Animations
                    int count = Global.Instance.ScreenAnimations.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Global.Instance.ScreenAnimations[i].Update(gameTime);
                        if (Global.Instance.ScreenAnimations[i].Erase)
                        {
                            Global.Instance.ScreenAnimations.RemoveAt(i);
                            i--; count--;
                        }
                    }
                    // Update Pictures
                    for (int i = 0; i < Global.Instance.Pictures.Length; i++)
                    {
                        if (Global.Instance.Pictures[i] != null)
                        {
                            if (Global.Instance.Pictures[i].ScreenType == ScreenType.Global ||
                                (Global.Instance.Pictures[i].ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                               (Global.Instance.Pictures[i].ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                            {
                                Global.Instance.Pictures[i].Update(gameTime);
                            }
                        }
                    }
                    // Update Messages                
                    count = Global.Messages.Count;
                    for (int index = 0; index < count; index++)
                    {
                        if (Global.Messages[index].NeedShow && !Global.Messages[index].Erase)
                        {
                            Global.Messages[index].Show();
                        }
                        else
                        {
                            Global.Messages[index].Update(gameTime);
                            // Erase message if required
                            if (Global.Messages[index].Erase)
                            {
                                Global.Messages.RemoveAt(index);
                                index--; count--;
                            }
                        }
                    }
                    // Update Menus
                    count = Global.Menus.Count;
                    for (int index = count - 1; index > -1; index--)
                    {
                        if (Global.Menus[index].NeedShow)
                        {
                            Global.Menus[index].Show();
                            if (Global.Menus[index].DeactivateScene)
                                break;
                        }
                        else
                        {
                            Global.Menus[index].Update(gameTime);
                            // Erase message if required
                            if (Global.Menus[index].Erase)
                            {
                                Global.Menus.RemoveAt(index);
                                index--; count--;
                                if (index > -1 && Global.Menus[index].DeactivateScene)
                                    break;
                            }
                            else if (Global.Menus[index].DeactivateScene)
                                break;
                        }
                    }

                    // Check if going to new menu
                    if (Global.MenuToLoad > -1)
                    {
                        if (Screens[0] is GameplayScreen)
                            GameplayScreen.IsCurrent = false;
                        if (Screens[0] is MenuScreen)
                            MenuScreen.IsCurrent = false;
                        this.RemoveScreen(Screens[0]);
                        // Add Screen
                        if (Screens.Count == 0)
                            AddScreen(new MenuScreen(Global.MenuToLoad), InputState.Players[InputState.LastPlayer]);
                        Global.MenuToLoad = -1;

                        // Close Messages                
                        count = Global.Messages.Count;
                        for (int index = 0; index < count; index++)
                            Global.Messages[index].Close();
                        // Close Menus
                        count = Global.Menus.Count;
                        for (int index = count - 1; index > -1; index--)
                            Global.Menus[index].Close();
                    }

                    // Update Effects
                    for (int i = 0; i < 3; i++)
                    {
                        // Update Tint
                        if (Global.Instance.TintScreen[i].ScreenType == ScreenType.Global ||
                            (Global.Instance.TintScreen[i].ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                           (Global.Instance.TintScreen[i].ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                        {
                            Global.Instance.TintScreen[i].Update(gameTime);
                        }
                        // Update Flash
                        if (Global.Instance.FlashScreen[i] != null)
                        {
                            if (Global.Instance.FlashScreen[i].ScreenType == ScreenType.Global ||
                                (Global.Instance.FlashScreen[i].ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                               (Global.Instance.FlashScreen[i].ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                            {
                                Global.Instance.FlashScreen[i].Update(gameTime);
                                if (Global.Instance.FlashScreen[i].Erase) Global.Instance.FlashScreen[i] = null;
                            }
                        }
                        // Update Shake
                        if (Global.Instance.ShakeScreen[i] != null)
                        {
                            if (Global.Instance.ShakeScreen[i].ScreenType == ScreenType.Global ||
                                (Global.Instance.ShakeScreen[i].ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                               (Global.Instance.ShakeScreen[i].ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                            {
                                Global.Instance.ShakeScreen[i].Update(gameTime);
                                if (Global.Instance.ShakeScreen[i].Erase) Global.Instance.ShakeScreen[i] = null;
                            }
                        }

                        // Update Text
                        if (Global.Instance.TextScreen[i] != null)
                        {
                            count = Global.Instance.TextScreen[i].Count;
                            for (int j = 0; j < count; j++)
                            {
                                if (Global.Instance.TextScreen[i][j].ScreenType == ScreenType.Global ||
                                    (Global.Instance.TextScreen[i][j].ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                                   (Global.Instance.TextScreen[i][j].ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                                {
                                    Global.Instance.TextScreen[i][j].Update(gameTime);
                                    if (Global.Instance.TextScreen[i][j].Erase)
                                    {
                                        Global.Instance.TextScreen[i].RemoveAt(j);
                                        j--; count--;
                                    }
                                }
                            }
                        }
                    }
                    // Update Fade
                    if (Global.Instance.ScreenState == ScreenState.TransitionOn)
                    {
                        // Fade In
                        if (Global.Instance.TransitionOnTime > 0)
                        {
                            Global.Instance.TransitionOnTime--;
                        }
                        else
                        {
                            Global.Instance.ScreenState = ScreenState.Active;
                        }
                    }
                    else if (Global.Instance.ScreenState == ScreenState.TransitionOff)
                    {
                        // Fade Out
                        if (Global.Instance.TransitionOffTime > 0)
                        {
                            Global.Instance.TransitionOffTime--;
                        }
                        else
                        {
                            Global.Instance.ScreenState = ScreenState.Active;
                        }
                    }
                }
            }
#if XBOX
            }
#endif
            // Print debug trace?
            if (traceEnabled)
                TraceScreens();
        }
        /// <summary>
        /// Checks the pause state
        /// </summary>
        private void CheckPause()
        {
            switch (Global.Instance.Pause)
            {
                case PauseAction.Video:
#if !SILVERLIGHT
                    if (Global.VideoPlayer.State == MediaState.Stopped)
                        Global.Instance.Pause = PauseAction.None;
#endif
                    break;
            }
        }
        /// <summary>
        /// Prints a list of all the screens, for debugging.
        /// </summary>
        void TraceScreens()
        {
            List<string> screenNames = new List<string>();

            foreach (GameScreen screen in Screens)
                screenNames.Add(screen.GetType().Name);
        }
        /// <summary>
        /// Tells each screen to draw itself.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < Screens.Count; i++)
            {
                if (Global.Instance.ScreenState == ScreenState.Hidden)
                    continue;
                if (MenuScreen.ShowOnScene)
                    Screens[i].Draw(gameTime);
            }
            // Draw Screen Animations
            Global.SpriteBatch.Begin();
            for (int i = 0; i < Global.Instance.ScreenAnimations.Count; i++)
            {
                Global.Instance.ScreenAnimations[i].Draw(gameTime);
            }
            Global.SpriteBatch.End();
            // Draw Video
#if !SILVERLIGHT
            Global.VideoPlayer.Draw(gameTime);
#endif
            // Draw Screen Effects
            // If the game is transitioning on or off, fade it out to black.
            // Tint the screen
            if ((Global.Instance.TransitionOffTime == 0 || !Global.Instance.FadingOut) && Global.Instance.TransitionOnTime == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Global.Instance.TintScreen[i].ScreenType == ScreenType.Global ||
                        (Global.Instance.TintScreen[i].ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                       (Global.Instance.TintScreen[i].ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                    {
                        Global.Instance.TintScreen[i].Draw(gameTime);
                    }
                }
            }
            // Fog
            if (Global.Instance.FogMaterialID > -1) DrawFog();
            // Draw flash
            for (int i = 0; i < 3; i++)
            {
                if (Global.Instance.FlashScreen[i] != null)
                {
                    if (Global.Instance.FlashScreen[i].ScreenType == ScreenType.Global ||
                        (Global.Instance.FlashScreen[i].ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                       (Global.Instance.FlashScreen[i].ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                    {
                        // Flash Screen
                        if (Global.Instance.FlashScreen[i] != null)
                            Global.Instance.FlashScreen[i].Draw(gameTime);
                    }
                }
                // Update Text
                if (Global.Instance.TextScreen[i] != null)
                {
                    foreach (EffectProcessor effect in Global.Instance.TextScreen[i])
                    {
                        if (effect.ScreenType == ScreenType.Global ||
                            (effect.ScreenType == ScreenType.Gameplay && GameplayScreen.IsCurrent) ||
                           (effect.ScreenType == ScreenType.Menu && MenuScreen.IsCurrent))
                        {
                            effect.Draw(gameTime);
                        }
                    }
                }
            }
            // Flash Que
            foreach (EffectProcessor flash in Global.Instance.FlashQue)
            {
                flash.Draw(gameTime);
            }
            Global.Instance.FlashQue.Clear();

            // Draw Menus
            Global.SpriteBatch.Begin();
            for (int index = 0; index < Global.Messages.Count; index++)
            {
                Global.Messages[index].Draw(gameTime);
            }
            for (int index = 0; index < Global.Menus.Count; index++)
            {
                Global.Menus[index].Draw(gameTime);
            }
            Global.SpriteBatch.End();

            if (Global.Instance.FadingOut)
            {
                if (Global.Instance.TransitionOffTime > 0)
                {
                    Global.Instance.FadeColor.A = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.A * (Global.Instance.TransitionOffTime - 1) + (int)Color.Black.A) / Global.Instance.TransitionOffTime);
                    Global.Instance.FadeColor.R = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.R * (Global.Instance.TransitionOffTime - 1) + (int)Color.Black.R) / Global.Instance.TransitionOffTime);
                    Global.Instance.FadeColor.G = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.G * (Global.Instance.TransitionOffTime - 1) + (int)Color.Black.G) / Global.Instance.TransitionOffTime);
                    Global.Instance.FadeColor.B = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.B * (Global.Instance.TransitionOffTime - 1) + (int)Color.Black.B) / Global.Instance.TransitionOffTime);
                }
                TintScreen(Global.Instance.FadeColor);
            }
            else if (Global.Instance.TransitionOnTime > 0)
            {
                if (Global.Instance.TransitionOnTime > 0)
                {
                    Global.Instance.FadeColor.A = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.A * (Global.Instance.TransitionOnTime - 1) + (int)Global.Instance.FadeToColor.A) / Global.Instance.TransitionOnTime);
                    Global.Instance.FadeColor.R = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.R * (Global.Instance.TransitionOnTime - 1) + (int)Global.Instance.FadeToColor.R) / Global.Instance.TransitionOnTime);
                    Global.Instance.FadeColor.G = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.G * (Global.Instance.TransitionOnTime - 1) + (int)Global.Instance.FadeToColor.G) / Global.Instance.TransitionOnTime);
                    Global.Instance.FadeColor.B = (byte)Math.Min(255, ((int)Global.Instance.FadeColor.B * (Global.Instance.TransitionOnTime - 1) + (int)Global.Instance.FadeToColor.B) / Global.Instance.TransitionOnTime);
                }
                TintScreen(Global.Instance.FadeColor);
            }
            // Draw Mouse Cursor
            if (Global.Project.CursorMaterial > -1)
            {
                Texture2D cursor = Content.Texture2D(Global.Instance.CursorMaterial);

                if (cursor != null)
                {
                    Global.SpriteBatch.Begin();

                    Global.SpriteBatch.Draw(cursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

                    Global.SpriteBatch.End();
                }
            }
            // Pause if screen is inactive
            Global.Instance.AudioManager.UpdateInactivity(Game.IsActive);
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a new screen to the screen manager.
        /// </summary>
        public void AddScreen(GameScreen screen, PlayerIndex? controllingPlayer)
        {
            screen.ControllingPlayer = controllingPlayer;
            screen.ScreenManager = this;
            screen.IsExiting = false;

            // If we have a graphics device, tell the screen to load content.
            if (isInitialized)
            {
                screen.LoadContent();
            }

            Screens.Add(screen);
        }
        /// <summary>
        /// Removes a screen from the screen manager. You should normally
        /// use GameScreen.ExitScreen instead of calling this directly, so
        /// the screen can gradually transition off rather than just being
        /// instantly removed.
        /// </summary>
        public void RemoveScreen(GameScreen screen)
        {
            // If we have a graphics device, tell the screen to unload content.
            if (isInitialized)
            {
                screen.UnloadContent();
            }
            Screens.Remove(screen);
            screensToUpdate.Remove(screen);
        }
        /// <summary>
        /// Expose an array holding all the screens. We return a copy rather
        /// than the real master list, because screens should only ever be added
        /// or removed using the AddScreen and RemoveScreen methods.
        /// </summary>
        public GameScreen[] GetScreens()
        {
            return Screens.ToArray();
        }
        /// <summary>
        /// Helper draws a translucent black fullscreen sprite, used for fading
        /// screens in and out, and for darkening the background behind popups.
        /// </summary>
        public void TintScreen(Color color)
        {
            Viewport viewport = GraphicsDevice.Viewport;

            Global.SpriteBatch.Begin();

            Global.SpriteBatch.Draw(GraphicsHelper.Texture,
                             new Rectangle(0, 0, viewport.Width, viewport.Height),
                             color);
            Global.SpriteBatch.End();
        }
        /// <summary>
        /// Draw Fog
        /// </summary>
        /// <param name="p"></param>
        public void DrawFog()
        {
            Texture2D fogTexture = Content.Texture2D(Global.Instance.FogMaterialID);
            // Draw fog if its not null
            if (fogTexture != null)
            {
                Viewport viewport = GraphicsDevice.Viewport;

                if (Global.Instance.FogPosition >= viewport.Width + 100)
                    Global.Instance.FogPosition = 0;

                if (!Global.Instance.ActiveCamera.IsMoving || Global.Instance.ActiveCamera.Direction == 0 || Global.Instance.ActiveCamera.Direction == 1)
                    Global.Instance.FogPosition += Global.Instance.FogSpeed;
                else if ((Global.Instance.ActiveCamera.IsMoving && Global.Instance.ActiveCamera.Direction == 2 && Global.Instance.FogSpeed < 0) || (Global.Instance.ActiveCamera.IsMoving && Global.Instance.ActiveCamera.Direction == 3 && Global.Instance.FogSpeed > 0) || (Global.Instance.ActiveCamera.IsMoving && Global.Instance.ActiveCamera.Direction == 3 && Global.Instance.FogSpeed > 0))
                    Global.Instance.FogPosition += Global.Instance.FogSpeed * 2;

                Global.SpriteBatch.Begin();

                Global.SpriteBatch.Draw(fogTexture,
                                 new Rectangle((int)Global.Instance.FogPosition, -100, viewport.Width + 100, viewport.Height + 100),
                                  Global.Instance.FogColor);

                Global.SpriteBatch.Draw(fogTexture,
                                 new Rectangle((int)Global.Instance.FogPosition - viewport.Width - 100, -100, viewport.Width + 100, viewport.Height + 100),
                                  Global.Instance.FogColor);
                Global.SpriteBatch.End();
            }
        }
        #endregion
    }


    public class CrazyContainer
    {
        public EventProcessor Insanse;
        public EventProcessor Mental;
    }
}
