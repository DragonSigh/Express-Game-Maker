//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Storage;
#if WINDOWS
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
#endif
using EGMGame.Library;
using EGMGame.Processors;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics;
using FarseerPhysics.Collision;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
#if SILVERLIGHT
using System.Windows.Resources;
using System.Windows;
using SilverArcade.SilverSprite.Manifest;
#endif
namespace EGMGame.Components
{
    public class Marshal
    {
        /// <summary>
        /// Load data from name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DataType LoadData<DataType>(string name)
        {
            try
            {
#if WINDOWS && VISUAL
                Stream r;
                string _base = Directory.GetParent(Global.ContentManager.RootDirectory).FullName;

                if (name.Contains("Project."))
                    name = _base + @"\" + name;
                else if (name.Contains(".egmmap"))
                    name = _base + @"\Maps\" + name;
                else
                    name = _base + @"\Data\" + name;

                r = File.OpenRead(name);
                XmlReaderSettings settings = new XmlReaderSettings();

                using (XmlReader reader = XmlReader.Create(r))
                {
                    return IntermediateSerializer.Deserialize<DataType>(reader, name);
                }
#elif WINDOWS && !VISUAL
                Console.WriteLine(name);
                TextReader r;
                r = new StreamReader(Global.Assembly.GetManifestResourceStream(name));
                XmlReaderSettings settings = new XmlReaderSettings();

                using (XmlReader reader = XmlReader.Create(r))
                {
                    return IntermediateSerializer.Deserialize<DataType>(reader, name);
                }
#elif XBOX
                if (name.Contains(".egmmap"))
                {
                    name = @"Maps\" + name;
                }
                else if (!name.Contains(".egmproj"))
                {
                    name = @"Data\" + name;
                }


                return Global.ContentManager.Load<DataType>(name);
#endif
            }
            catch (Exception ex)
            {
                // > EGM ERROR
                Console.Write("Error > Unable to load " + name + "\n");
                Error.Do(ex);
            }
            return default(DataType);
        }
        /// <summary>
        /// Clear Cache
        /// </summary>
        internal static void Clear()
        {
            GC.Collect();
        }
        /// <summary>
        /// Save Game
        /// </summary>
        /// <param name="fileIndex"></param>
        internal static void SaveGame(int fileIndex)
        {
            if (Global.IsSavingOrLoading > -1)
                return;
            string fileName;
            byte[] bytes;
#if WINDOWS

            fileName = "saved" + fileIndex + ".svdat";

            bytes = CustomSerializer.Serialize(Global.Instance);

            using (FileStream stream = File.OpenWrite(fileName))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
#elif XBOX
            if (Global.Storage != null)
            {
                //// Open a storage container.
                IAsyncResult result =
                    Global.Storage.BeginOpenContainer(Global.Project.Name, null, null);

                // Wait for the WaitHandle to become signaled.
                result.AsyncWaitHandle.WaitOne();

                StorageContainer container = Global.Storage.EndOpenContainer(result);

                // Close the wait handle.
                result.AsyncWaitHandle.Close();

                fileName = "saved" + fileIndex + ".svdat";

                // Check to see whether the save exists.
                if (container.FileExists(fileName))
                    // Delete it so that we can create one fresh.
                    container.DeleteFile(fileName);
                // Create the file.
                bytes = CustomSerializer.Serialize(Global.Instance);

                using (Stream stream = container.CreateFile(fileName))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
                // Dispose the container, to commit changes.
                container.Dispose();
            }
#endif
        }
        /// <summary>
        /// Load Game
        /// </summary>
        /// <param name="fileIndex"></param>
        internal static void LoadGame(int fileIndex)
        {
            string filename = "saved" + fileIndex.ToString() + ".svdat";

            bool fadedout = Global.Instance.FadingOut;
#if WINDOWS && VISUAL

            filename = System.IO.Directory.GetParent(Global.ContentManager.RootDirectory).FullName + "\\" + filename;
#endif
#if WINDOWS
            if (File.Exists(filename))
            {
                // Audio
                Global.Instance.AudioManager.Stop();
                using (Stream stream = File.OpenRead(filename))
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Position = 0;
                    stream.Read(bytes, 0, (int)stream.Length);
                    Global.Instance = (Global)CustomSerializer.Deserialize(bytes);
                }
#elif XBOX

            if (Global.StorageDeviceManager.Device != null)
            {
                // Open a storage container.
                IAsyncResult result =
                    Global.StorageDeviceManager.Device.BeginOpenContainer(Global.Project.Name, null, null);

                // Wait for the WaitHandle to become signaled.
                result.AsyncWaitHandle.WaitOne();

                StorageContainer container = Global.StorageDeviceManager.Device.EndOpenContainer(result);

                // Close the wait handle.
                result.AsyncWaitHandle.Close();
                // Check to see whether the save exists.
                if (!container.FileExists(filename))
                {
                    // If not, dispose of the container and return.
                    container.Dispose();
                    return;
                }
                // Audio
                Global.Instance.AudioManager.Stop();
                // Open the file.

                using (Stream stream = container.OpenFile(filename, FileMode.Open))
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Position = 0;
                    stream.Read(bytes, 0, (int)stream.Length);
                    Global.Instance = (Global)CustomSerializer.Deserialize(bytes);
                }
                container.Dispose();
#endif

                // Fade out
                if (fadedout)
                {
                    Global.Instance.FadingOut = true;
                    Global.Instance.FadeColor = Color.Black;
                }
                // Setup Map
                if (Global.Instance.CurrentMap != null)
                {
                    Global.Instance.CurrentMap.Load();
                    Global.Instance.CurrentMap.RemovePlayers();
                    if (MenuScreen.IsCurrent)
                        Global.MapToLoad = Global.Instance.CurrentMap.ID;
                }
                for (int i = 0; i < Global.Instance.Player.Count; i++)
                {
                    Global.Instance.CurrentMap.AddProcessor(Global.Instance.Player[i]);
                    Global.Instance.Player[i].Load();
                }
                // Setup Global Events
                for (int i = 0; i < Global.Instance.GlobalEvents.Count; i++)
                {
                    Global.Instance.GlobalEvents[i].Load();
                }
                // Setup Audio
                Global.Instance.AudioManager.Load();
                // Setup Particles
                foreach (ParticleSystemProcessor sys in Global.Instance.Particles.Values)
                {
                    sys.Load();
                }
                // Load Weather
                Global.Instance.Weather.Load();
            }

        }
        /// <summary>
        /// The thread that manges saves and loads as they may take a bit long on some
        /// systems.
        /// </summary>
        /// <param name="gameTime"></param>
        public static void SaveLoadThread(GameTime gameTime)
        {
            while (true)
            {
                if (Global.IsSaving && Global.IsSavingOrLoading > -1)
                {
                    try
                    {
                        string fileName = "saved" + Global.IsSavingOrLoading.ToString() + ".svdat";

                        byte[] bytes = CustomSerializer.Serialize(Global.Instance);

                        using (FileStream stream = File.OpenWrite(fileName))
                        {
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Close();
                        }

                        Global.IsSavingOrLoading = -1;
                        Global.IsSaving = false;
                    }
                    catch
                    {

                    }
                }
                else if (Global.IsSavingOrLoading > -1)
                {
                    string fileName = "saved" + Global.IsSavingOrLoading.ToString() + ".svdat";

                    if (File.Exists(fileName))
                    {
                        bool fadedout = Global.Instance.FadingOut;
                        // Audio
                        Global.Instance.AudioManager.Stop();

                        using (Stream stream = File.OpenRead(fileName))
                        {
                            byte[] bytes = new byte[stream.Length];
                            stream.Position = 0;
                            stream.Read(bytes, 0, (int)stream.Length);
                            Global.Instance = (Global)CustomSerializer.Deserialize(bytes);
                        }
                        // Fade out
                        if (fadedout)
                        {
                            Global.Instance.FadingOut = true;
                            Global.Instance.FadeColor = Color.Black;
                        }
                        // Setup Map
                        if (Global.Instance.CurrentMap != null)
                        {
                            Global.Instance.CurrentMap.Load();
                            Global.Instance.CurrentMap.RemovePlayers();
                            if (MenuScreen.IsCurrent)
                                Global.MapToLoad = Global.Instance.CurrentMap.ID;
                        }
                        for (int i = 0; i < Global.Instance.Player.Count; i++)
                        {
                            Global.Instance.CurrentMap.AddProcessor(Global.Instance.Player[i]);
                            Global.Instance.Player[i].Load();
                        }
                        // Setup Global Events
                        for (int i = 0; i < Global.Instance.GlobalEvents.Count; i++)
                        {
                            Global.Instance.GlobalEvents[i].Load();
                        }
                        // Setup Audio
                        Global.Instance.AudioManager.Load();
                        // Setup Particles
                        foreach (ParticleSystemProcessor sys in Global.Instance.Particles.Values)
                        {
                            sys.Load();
                        }
                        // Load Weather
                        Global.Instance.Weather.Load();

                        Global.IsSavingOrLoading = -1;
                        Global.IsSaving = false;
                    }
                }

            }
        }
        /// <summary>
        /// The thread that manges saves and loads as they may take a bit long on some
        /// systems.
        /// </summary>
        /// <param name="gameTime"></param>
        public static void SaveLoadThreadXbox(GameTime gameTime)
        {
            while (true)
            {
                if (Global.IsSaving && Global.IsSavingOrLoading > -1)
                {
                }
                else if (Global.IsSavingOrLoading > -1)
                {
                }

            }
        }
    }

}