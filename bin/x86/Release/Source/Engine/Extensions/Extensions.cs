//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using EGMGame.Components;
using EGMGame.Library;
using System.Collections;
using EGMGame.Extensions;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;

namespace EGMGame
{
    public static class Extension
    {
        #region Vector2
        public static bool Greater(Vector2 a, Vector2 b)
        {
            return (a.X > b.X && a.Y > b.Y);
        }
        public static bool Lesser(Vector2 a, Vector2 b)
        {
            return (a.X < b.X && a.Y < b.Y);
        }
        public static bool GreaterEquals(Vector2 a, Vector2 b)
        {
            return (a.X >= b.X && a.Y >= b.Y);
        }
        public static bool LesserEquals(Vector2 a, Vector2 b)
        {
            return (a.X <= b.X && a.Y <= b.Y);
        }

        public static Vector2 Center(this RectangleF _this)
        {
            return new Vector2(_this.X + _this.Width / 2, _this.Y + _this.Height / 2);
        }

        public static Vector2 Rotate(this Vector2 _this, float C, Vector2 B)
        {
            Vector2 result = new Vector2();

            result.X = (_this.X - B.X) * (float)Math.Cos(C) - (_this.Y - B.Y) * (float)Math.Sin(C) + B.X;
            result.Y = (_this.Y - B.Y) * (float)Math.Cos(C) + (_this.X - B.X) * (float)Math.Sin(C) + B.Y;

            return result;
        }
        /// <summary>
        /// Rotate the vertices with the defined value in radians.
        /// </summary>
        /// <param name="value">The amount to rotate by in radians.</param>
        public static void Rotate(this Vertices _this, float C, Vector2 B)
        {
            for (int i = 0; i < _this.Count; i++)
            {
                Vector2 result = new Vector2();

                result.X = (_this[i].X - B.X) * (float)Math.Cos(C) - (_this[i].Y - B.Y) * (float)Math.Sin(C) + B.X;
                result.Y = (_this[i].Y - B.Y) * (float)Math.Cos(C) + (_this[i].X - B.X) * (float)Math.Sin(C) + B.Y;

                _this[i] = result;
            }
        }
        #endregion

        #region Fixture

        #region Body
        internal static void Reset(this Body _body)
        {
            _body.ResetDynamics();
            _body.LinearVelocityInternal = Vector2.Zero;
            _body.Rotation = 0;
            _body.Mass = 1;
            _body.Position = Vector2.Zero;
            _body.Force = Vector2.Zero;
            _body.IsStatic = false;
            _body.AngularVelocity = 0;
            _body.Enabled = true;
            _body.IgnoreGravity = false;
            _body.LinearDamping = .001f;
            _body.LinearVelocity = Vector2.Zero;
            _body.AngularDamping = .001f;
        }
        #endregion

        #endregion

        #region Containers
        /// <summary>
        /// Try to get a value with the given key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="container"></param>
        /// <param name="key">The key to look up in the container.</param>
        /// <returns>Returns null if value does not exist.</returns>
        public static TValue GetData<TKey, TValue>(this Dictionary<TKey, TValue> container, TKey key)
        {
            TValue value;
            if (container.TryGetValue(key, out value)) return value;
            // If the data does not exist, we make it an error.
            if (key is int) if ((int)(object)key > -1) Error.Do(new Exception("Data does not exist!\nData: " + typeof(TValue).ToString() + "\nID: " + key.ToString() + "\nContainer: " + container.ToString()));
            return default(TValue);
        }

        /// <summary>
        /// Counts and returns the number of items (id) in the list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int Count(this List<int> list, int id)
        {
            int i = 0;

            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] == id)
                    i++;
            }
            return i;
        }
        /// <summary>
        /// Returns a game data from the given type, id and container list
        /// The type must inherit from IGameData.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static TValue GetData<TValue>(this List<TValue> container, int id)
        {
            for (int index = 0; index < container.Count; index++)
            {
                if (((IGameData)(object)container[index]).ID == id)
                    return (TValue)container[index];
            }
            if (id > -1)
                Error.Do(new Exception("Data does not exist!\nData: " + typeof(TValue).ToString() + "\nID: " + id.ToString() + "\nContainer: " + container.ToString()));

            return default(TValue);
        }
        /// <summary>
        /// Returns a game data from the given type, name and container dictionary
        /// The type must inherit from IGameData
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static TValue GetData<TKey, TValue>(this Dictionary<TKey, TValue> container, string name)
        {
            foreach (TValue value in container.Values)
                if (((IGameData)(object)value).Name == name) return value;
            // If the data does not exist, we make it an error.
            Error.Do(new Exception("Data does not exist!\nData: " + typeof(TValue).ToString() + "\nName: " + name + "\nContainer: " + container.ToString()));
            return default(TValue);
        }
        #endregion

        #region XNA
        static Texture2D LastTexture; static int LastTextureID;

        public static void Draw(this SpriteBatch _this, int materialId, Vector2 position, Color color)
        {
            if (LastTextureID != materialId || LastTexture == null) LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, position, color);
        }

        public static void Draw(this SpriteBatch _this, int materialId, Rectangle rectangle, Color color)
        {
            if (LastTextureID != materialId || LastTexture == null) LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, rectangle, color);
        }
        public static void Draw(this SpriteBatch _this, int materialId, Rectangle rectangle, Rectangle source, Color color, float rot)
        {
            if (LastTextureID != materialId || LastTexture == null) LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, rectangle, source, color, rot, Vector2.Zero, SpriteEffects.None, 2);
        }
        public static void Draw(this SpriteBatch _this, int materialId, Rectangle rectangle, Rectangle source, Color color, float rot, Vector2 origin)
        {
            if (LastTextureID != materialId || LastTexture == null) LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, rectangle, source, color, rot, origin, SpriteEffects.None, 2);
        }

        public static void Draw(this SpriteBatch _this, int materialId, Vector2 position, Rectangle source, Color color, Vector2 scale)
        {
            if (LastTextureID != materialId || LastTexture == null) LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, position, source, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public static void Draw(this SpriteBatch _this, int materialId, Vector2 position, Rectangle source, Color color, Vector2 scale, float rotation, Vector2 origin)
        {
            if (LastTextureID != materialId || LastTexture == null) LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, position, source, color, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public static void Draw(this SpriteBatch _this, int materialId, Vector2 position, Color color, Vector2 scale)
        {
            if (LastTextureID != materialId || LastTexture == null) LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, position, new Rectangle(0, 0, LastTexture.Width, LastTexture.Height), color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public static void Draw(this SpriteBatch _this, int materialId, Vector2 position, Color color, Vector2 scale, float rotation, Vector2 origin)
        {
            if (LastTextureID != materialId || LastTexture == null)
                LastTexture = Content.Texture2D(materialId);
            LastTextureID = materialId;
            _this.Draw(LastTexture, position, new Rectangle(0, 0, LastTexture.Width, LastTexture.Height), color, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public static void Draw(this SpriteBatch _this, Texture2D tex, Vector2 position, Color color, Vector2 scale, Vector2 origin)
        {
            _this.Draw(tex, position, new Rectangle(0, 0, tex.Width, tex.Height), color, 0, origin, scale, SpriteEffects.None, 0);
        }

        public static void Draw(this SpriteBatch _this, Texture2D tex, Vector2 position, Color color, float rotation, Vector2 origin)
        {
            _this.Draw(tex, position, new Rectangle(0, 0, tex.Width, tex.Height), color, rotation, origin, new Vector2(1f, 1f), SpriteEffects.None, 0);
        }

        public static void Draw(this SpriteBatch _this, Texture2D tex, Rectangle rect, Color color, float rotation, Vector2 origin)
        {
            _this.Draw(tex, rect, new Rectangle(0, 0, rect.Width, rect.Height), color, rotation, origin, SpriteEffects.None, 0);
        }

        #endregion

#if XBOX
        /// <summary> 
        /// Removes all elements from the List that match the conditions defined by the specified predicate. 
        /// </summary> 
        /// <typeparam name="T">The type of elements held by the List.</typeparam> 
        /// <param name="list">The List to remove the elements from.</param> 
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to remove.</param> 
        public static int RemoveAll<T>(List<T> data, Predicate<T> test)
        {
            int removed = 0;

            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (test(data[(i)]))
                {
                    data.RemoveAt(i);
                    removed++;
                }
            }
            return removed;
        }
        /// <summary> 
        /// Removes all elements from the List that match the conditions defined by the specified predicate. 
        /// </summary> 
        /// <typeparam name="T">The type of elements held by the List.</typeparam> 
        /// <param name="list">The List to remove the elements from.</param> 
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to remove.</param> 
        public static int RemoveAll<T>(this List<T> list, Func<T, bool> match)
        {
            int numberRemoved = 0;

            // Loop through every element in the List, in reverse order since we are removing items. 
            for (int i = (list.Count - 1); i >= 0; i--)
            {
                // If the predicate function returns true for this item, remove it from the List. 
                if (match(list[i]))
                {
                    list.RemoveAt(i);
                    numberRemoved++;
                }
            }

            // Return how many items were removed from the List. 
            return numberRemoved;
        }

        /// <summary> 
        /// Returns true if the List contains elements that match the conditions defined by the specified predicate. 
        /// </summary> 
        /// <typeparam name="T">The type of elements held by the List.</typeparam> 
        /// <param name="list">The List to search for a match in.</param> 
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to match against.</param> 
        public static bool Exists<T>(this List<T> list, Func<T, bool> match)
        {
            // Loop through every element in the List, until a match is found. 
            for (int i = 0; i < list.Count; i++)
            {
                // If the predicate function returns true for this item, return that at least one match was found. 
                if (match(list[i]))
                    return true;
            }

            // Return that no matching elements were found in the List. 
            return false;
        }
#endif
    }
}
