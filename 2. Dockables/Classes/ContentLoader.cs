/* -----------------------------
 * Loader - Content Loader
 * -----------------------------
 * Purpose:             Loads XNB content such as Images and Audio.
 * Most Used By:        Components, Editors
 * Associated Files:    .xnb Files
 * Modify:              If you want to improve loading or add new content type loading.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using EGMGame.Docking.Explorers;
using System.Drawing;
using EGMGame.Library;

namespace EGMGame.Controls
{
    class Loader
    {
        /// <summary>
        /// Cashes the texures so we can use them later.
        /// </summary>
        public static Dictionary<int, Texture2D> Textures = new Dictionary<int, Texture2D>();
        /// <summary>
        /// Loads the effect file to be used by the ParticleEmitter class. 
        /// </summary>
        public static Effect LoadMainEffect(GraphicsDevice graphicsDevice, string filename, ContentManager contentManager)
        {
            string appContentDir = Path.Combine(Application.StartupPath, "Content");

            string path = Path.Combine(contentManager.RootDirectory, filename + ".fx.xnb");
            if (File.Exists(path))
            {
                Effect ef;
                ef = contentManager.Load<Effect>(Path.Combine(contentManager.RootDirectory, filename + ".fx"));
                return ef;
            }
            return null;
        }
        /// <summary>
        /// Loads a Texture2D file in to memory.
        /// </summary>
        public static Texture2D Texture2D(ContentManager contentManager, int materialID)
        {
            try
            {
                // Check Cache
                MaterialData data = Global.GetData<MaterialData>(materialID, GameData.Materials);
                if (data != null && data.DataType == MaterialDataType.Image && !MainForm.materialExplorer.contentToImport.Contains(data))
                {
                    try
                    {
                        string[] name = data.FileName.Split('\\');
#if DEBUG
                        if (File.Exists(contentManager.RootDirectory + @"\" + name[name.Length - 1] + ".xnb"))
                        {
#endif
                            return contentManager.Load<Texture2D>(name[name.Length - 1]);
#if DEBUG
                        }
#endif
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Error.ShowLogError(e, "59x004");
            }
            return null;
        }
        /// <summary>
        /// Clear cache - Resets Projects
        /// </summary>
        internal static void Clear(bool gc)
        {
            Textures.Clear();

            // Clear Content Managers
            MainForm.materialPreview.ResetProject();
            MainForm.tilesExplorer.ResetProject();
            MainForm.mapEditor.ResetProject();
            MainForm.animationEditor.ResetProject();
            MainForm.tilesetEditor.ResetProject();
            MainForm.audioEditor.ResetProject();
            MainForm.textEditor.ResetProject();
            MainForm.fontEditor.ResetProject();
            MainForm.eventEditor.ResetProject();
            MainForm.playerEditor.ResetProject();
            MainForm.menuEditor.ResetProject();
            MainForm.particleEditor.ResetProject();
            MainForm.skinEditor.ResetProject();
            MainForm.itemEditor.ResetProject();
            MainForm.equipmentEditor.ResetProject();
            MainForm.skillsEditor.ResetProject();
            MainForm.statesEditor.ResetProject();
            MainForm.heroEditor.ResetProject();
            MainForm.enemyEditor.ResetProject();

            if (gc)
                GC.Collect();
        }
        /// <summary>
        /// Clear cache - Unloads Projects
        /// </summary>
        internal static void Clear()
        {
            Textures.Clear();
            // Clear Content Managers
            MainForm.materialPreview.Unload();
            MainForm.materialExplorer.Unload();
            MainForm.tilesExplorer.Unload();
            MainForm.mapEditor.Unload();
            MainForm.animationEditor.Unload();
            MainForm.tilesetEditor.Unload();
            MainForm.audioEditor.Unload();
            MainForm.textEditor.Unload();
            MainForm.fontEditor.Unload();
            MainForm.eventEditor.Unload();
            MainForm.playerEditor.Unload();
            MainForm.menuEditor.Unload();
            MainForm.particleEditor.Unload();
            MainForm.skinEditor.Unload();
            MainForm.itemEditor.Unload();
            MainForm.equipmentEditor.Unload();
            MainForm.skillsEditor.Unload();
            MainForm.statesEditor.Unload();
            MainForm.heroEditor.Unload();
            MainForm.enemyEditor.Unload();
        }
        /// <summary>
        /// Loads a SpriteFont file into memory.
        /// </summary>
        public static SpriteFont SpriteFont(ContentManager contentManager, int materialID)
        {
            try
            {
                MaterialData data = Global.GetData<MaterialData>(materialID, GameData.Materials);

                if (data != null && data.DataType == MaterialDataType.Bitmap_Font)
                {
                    try
                    {
                        string[] name = data.FileName.Split('\\');
#if DEBUG
                        if (File.Exists(contentManager.RootDirectory + @"\" + name[name.Length - 1] + ".xnb"))
                        {
#endif
                            return contentManager.Load<SpriteFont>(name[name.Length - 1]);
#if DEBUG
                        }
#endif
                    }

                    catch
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                Error.ShowLogError(e, "59x005");
            }
            return null;
        }
        /// <summary>
        /// Loads a SpriteFont file into memory.
        /// </summary>
        public static SpriteFont SpriteFont(ContentManager contentManager, string name)
        {
            try
            {

                return contentManager.Load<SpriteFont>(name);
            }
            catch (Exception e)
            {
                Error.ShowLogError(e, "59x006");
            }
            return null;
        }
        /// <summary>
        /// Loads an audio file into memory.
        /// </summary>
        public static SoundEffect SoundEffect(ContentBuilder contentBuilder, ContentManager contentManager, int materialID)
        {
            try
            {
                MaterialData data = Global.GetData<MaterialData>(materialID, GameData.Materials);

                if (data != null && data.DataType == MaterialDataType.Sound)
                {
                    try
                    {
                        string asset = MaterialExplorer.GetAssetName(new FileInfo(Path.Combine(Global.Project.Location, data.FileName)), data);
                        if (File.Exists(Global.Project.Location + @"\Content\" + asset + ".xnb"))
                            return contentManager.Load<SoundEffect>(MaterialExplorer.GetAssetName(new FileInfo(Path.Combine(Global.Project.Location, data.FileName)), data));
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                Error.ShowLogError(e, "59x003");
            }
            return null;
        }
        /// <summary>
        /// Loads a SpriteFont file into memory.
        /// </summary>
        public static Texture2D MainTexture2D(ContentBuilder contentBuilder, ContentManager contentManager, string name)
        {
            try
            {
                return contentManager.Load<Texture2D>(name);
            }
            catch (Exception e)
            {
                Error.ShowLogError(e, "59x001");
            }
            return null;
        }
        /// <summary>
        /// Loads a texture from stream
        /// </summary>
        public static Texture2D TextureFromStream(GraphicsDevice g, Bitmap bitmap, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                Stream s = new MemoryStream();
                bitmap.Save(s, format);
                s.Position = 0;
                return Microsoft.Xna.Framework.Graphics.Texture2D.FromStream(g, s);
            }
            catch (Exception e)
            {
                Error.ShowLogError(e, "59x002");
            }
            return null;
        }
    }
}
