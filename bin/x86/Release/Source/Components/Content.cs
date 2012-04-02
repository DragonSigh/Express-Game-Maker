using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using EGMGame.Library;

namespace EGMGame.Components
{
    /// <summary>
    /// Used to easily load a content.
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Load a texture from the given content manager and material id.
        /// If the content is alerady loaded, then returns the loaded content.
        /// </summary>
        /// <param name="materialID"></param>
        /// <returns></returns>
        public static Texture2D Texture2D(int materialID)
        {
            MaterialData data = GameData.Materials.GetData(materialID);
            if (data == null) return null;
            return Texture2D(data);
        }
        /// <summary>
        /// Load a texture from the given content manager and material id.
        /// If the content is alerady loaded, then returns the loaded content.
        /// </summary>
        /// <param name="materialI"></param>
        /// <returns></returns>
        public static Texture2D Texture2D(MaterialData material)
        {
            try
            {
                return Global.ContentManager.Load<Texture2D>(GetAssetName(material));
            }
            catch (Exception e)
            {
                Error.Do(e);
            }
            return null;
        }

#if !SILVERLIGHT
        /// <summary>
        /// Get Effect
        /// </summary>
        /// <param name="Material"></param>
        /// <returns></returns>
        public static Effect Effect(MaterialData data)
        {
            try
            {
                if (data == null) return null;
                return Global.ContentManager.Load<Effect>(GetAssetName(data));
            }
            catch (Exception e)
            {
                Error.Do(e);
            }
            return null;
        }
        /// <summary>
        /// Get Effect
        /// </summary>
        /// <param name="MaterialID"></param>
        /// <returns></returns>
        public static Effect Effect(int id)
        {
            try
            {
                MaterialData material = GameData.Materials.GetData(id);
                return Global.ContentManager.Load<Effect>(GetAssetName(material));
            }
            catch (Exception e)
            {
                Error.Do(e);
            }
            return null;
        }
#endif
        /// <summary>
        /// Load a sprite font from the given content manager and material id.
        /// If the content is alerady loaded, then returns the loaded content.
        /// </summary>
        /// <param name="contentManager"></param>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public static SpriteFont SpriteFont(int materialID)
        {
            try
            {
                // Check Cache
                SpriteFont font;
                MaterialData data = GameData.Materials.GetData(materialID);
                if (data != null)
                {
                    font = Global.ContentManager.Load<SpriteFont>(GetAssetName(data));
                    return font;
                }
            }
            catch (Exception e)
            {
                Error.Do(e);
            }
            return null;
        }
        /// <summary>
        /// Loads an auido from the given content maanger and material id.
        /// If the content is alerady loaded, then returns the loaded content.
        /// </summary>
        /// <param name="contentManager"></param>
        /// <param name="materialID"></param>
        /// <returns></returns>
        public static SoundEffect SoundEffect(int materialID)
        {
            try
            {
                MaterialData data = GameData.Materials.GetData(materialID);
                if (data != null)
                {
                    return Global.ContentManager.Load<SoundEffect>(GetAssetName(data));
                }
            }
            catch (Exception e)
            {
                Error.Do(e);
            }
            return null;
        }

#if !SILVERLIGHT
        /// <summary>
        /// Get Video
        /// </summary>
        /// <param name="contentManager"></param>
        /// <param name="materialID"></param>
        /// <returns></returns>
        internal static Video Video(int materialID)
        {
            try
            {
#if WINDOWS
                MaterialData data = GameData.Materials.GetData(materialID);
                if (data != null)
                {
                    return Global.ContentManager.Load<Video>(GetAssetName(data));
                }
#endif
            }
            catch (Exception e)
            {
                Error.Do(e);
            }
            return null;
        }
#endif
        /// <summary>
        /// Disposes and clears cache.
        /// Useful to prevent memory growth.
        /// </summary>
        public static void Clear()
        {
        }

        /// <summary>
        /// Get the name of the asset from the given material data
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="materialData"></param>
        /// <returns></returns>
        private static string GetAssetName(MaterialData materialData)
        {
            //string name = Path.GetFileName(materialData.FileName);
#if VISUAL && !XBOX
            return Path.GetFileName(materialData.FileName);
#elif WINDOWS || SILVERLIGHT
            return Path.GetFileName(materialData.FileName);
#elif XBOX && VISUAL
            return Path.GetFileNameWithoutExtension(materialData.FileName);
#elif XBOX
            return materialData.FileName.Remove(0, 10);
#endif
        }
    }
}
