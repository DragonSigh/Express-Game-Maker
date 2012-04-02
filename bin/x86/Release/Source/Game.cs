//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace EGMGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class EGMEngine : Game
    {
        #region Fields
        private GraphicsDeviceManager graphics;
        private ScreenManager screenManager;

        /// <summary>
        /// Used to count FPs
        /// </summary>
        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        #endregion

        public EGMEngine()
        {
            try
            {

                graphics = new GraphicsDeviceManager(this);
                // Set the global content manager
                Global.ContentManager = Content;
#if VISUAL && WINDOWS
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Sidescroller_Test16\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Sidescroller_Test15\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Sidescroller_Test14\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Fighter Testbed\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Platformer Template\Content";
                Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Shooter Template\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Desktop\Sidescroller_Test7\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\RPG Template\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\RPG Tutorial\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Blank\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Project\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Royal Playground\Content";
                //Content.RootDirectory = @"C:\Users\Muhammet\Documents\EGM Projects\Simple Shooter Sample\Content";
#else
				Content.RootDirectory = "Content";
#endif

                // Load the project file
                LoadProject();
                // Title of the game
                this.Window.Title = Global.Project.Name;
#if DEBUG
                this.Window.Title += " - DEBUG Mode";
#endif

                // Window Size
                graphics.PreferredBackBufferWidth = (int)Global.Project.ScreenRatio.X;
                graphics.PreferredBackBufferHeight = (int)Global.Project.ScreenRatio.Y;
#if !DEBUG
                graphics.IsFullScreen = Global.Project.StartFullScreen;
#endif
                graphics.ApplyChanges();

                // Create the screen manager component.
                screenManager = new ScreenManager(this);

                Components.Add(screenManager);
                // Set Game
                Global.Game = this;

                // Thread Manager
                Global.ThreadsManager = new ThreadManager(this);
                Components.Add(Global.ThreadsManager);

#if XBOX
                Components.Add(new GamerServicesComponent(this));
                Global.StorageDeviceManager = new StorageDeviceManager(this);
                Global.StorageDeviceManager.DeviceSelectorCanceled += DeviceSelectorCanceled;
                Global.StorageDeviceManager.DeviceDisconnected += DeviceDisconnected;
                Global.StorageDeviceManager.DeviceSelected += DeviceSelected;
                Components.Add(Global.StorageDeviceManager);
#endif

            }
            catch (Exception ex)
            {
                Error.Do(ex);
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();

            Global.Instance.Weather = new Processors.WeatherProcessor();
#if SILVERLIGHT
#if !WP7
			Microsoft.Xna.Framework.Input.Keyboard.Update();
			Microsoft.Xna.Framework.Input.Mouse.Update();
			Microsoft.Xna.Framework.Input.Keyboard.CreatesNewState = false;
#endif
#endif

        }
        /// <summary>
        /// Load Project
        /// </summary>
        private void LoadProject()
        {
            System.Diagnostics.Debug.WriteLine("Project");
#if DEBUG
            Console.WriteLine("Loading Project...");
#endif
            Global.Assembly = Assembly.GetExecutingAssembly();
            Global.Project = Marshal.LoadData<Project>("Project.egmproj");

            if (Global.Project == null)
                throw new Exception("Project can't be null. Please make sure the Project file's format is correct");
#if DEBUG
            Console.WriteLine("Project " + Global.Project.Name + " Loaded.");
#endif
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Used to calculate the FPS
            frameCounter++;
            GraphicsDevice.Clear(Color.Black);
            // Compute camera matrices.
            float aspectRatio = (float)GraphicsDevice.Viewport.Width /
                                (float)GraphicsDevice.Viewport.Height;

            base.Draw(gameTime);
        }
        /// <summary>
        /// This is called when the game updates every frame.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            // Change Screen Ratio if required.
            if ((int)Global.Project.ScreenRatio.X != graphics.PreferredBackBufferWidth ||
                graphics.PreferredBackBufferHeight != (int)Global.Project.ScreenRatio.Y)
            {
                graphics.PreferredBackBufferWidth = (int)Global.Project.ScreenRatio.X;
                graphics.PreferredBackBufferHeight = (int)Global.Project.ScreenRatio.Y;
                graphics.ApplyChanges();

                Global.Instance.ActiveCamera.Viewport = GraphicsDevice.Viewport;
            }

            base.Update(gameTime);

#if DEBUG
            // Used to calculate the FPS
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
                string fps = string.Format("Fps: {0}", frameRate);

                this.Window.Title = Global.Project.Name;
                this.Window.Title += " - DEBUG Mode ";
                this.Window.Title += fps;
                if (Global.World != null) this.Window.Title += " Bodies: " + Global.World.BodyList.Count.ToString();
            }
#endif

        }

        #region Storage Events
        void DeviceDisconnected(object sender, StorageDeviceEventArgs e)
        {
            // force the user to choose a new storage device
            e.EventResponse = StorageDeviceSelectorEventResponse.Force;
        }

        void DeviceSelectorCanceled(object sender, StorageDeviceEventArgs e)
        {
            // force the user to choose a new storage device
            e.EventResponse = StorageDeviceSelectorEventResponse.Force;
        }

        void DeviceSelected(object sender, EventArgs e)
        {
            Global.Storage = Global.StorageDeviceManager.Device;
        }
        #endregion

    }



    #region Entry Point
#if !SILVERLIGHT
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static class Program
    {
        static void Main()
        {
            using (EGMEngine game = new EGMEngine())
            {
                game.Run();
            }
        }
    }
#endif
    #endregion
}